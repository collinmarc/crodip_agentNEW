[CmdletBinding()]
param(
    [ValidateSet("quick","full")][string]$Mode = "quick",
    [string]$DestinationDirectory,
    [ValidateSet("manual","pre-migration","pre-release-change","rollback-safety")][string]$Purpose = "manual"
)
$ErrorActionPreference = "Stop"
# RC41 Fix2 - Do not force-reload shared Runtime modules when this
# script is invoked from another Runtime module. A forced reload can
# invalidate commands imported in the caller scope.
foreach ($runtimeModule in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1"
)) {
    $modulePath = Join-Path $PSScriptRoot "..\modules\$runtimeModule"
    $moduleBaseName = [System.IO.Path]::GetFileNameWithoutExtension($runtimeModule)

    if (-not (Get-Module -Name $moduleBaseName)) {
        Import-Module $modulePath -DisableNameChecking -ErrorAction Stop
    }
}
Write-CrodipRuntimeHeader "06-backup.ps1"

function Get-ComposeContainerId([string]$Project,[string]$Service) {
    $ids=@(& docker ps --filter "label=com.docker.compose.project=$Project" --filter "label=com.docker.compose.service=$Service" --format "{{.ID}}" 2>$null)
    if($LASTEXITCODE -ne 0 -or $ids.Count -eq 0){ return $null }
    $v=([string]$ids[0]).Trim(); if([string]::IsNullOrWhiteSpace($v)){return $null}; return $v
}
function Get-ContainerEnv([string]$Id,[string]$Name) {
    $line=@(& docker inspect $Id --format '{{range .Config.Env}}{{println .}}{{end}}' 2>$null | Where-Object {$_ -like "$Name=*"} | Select-Object -First 1)
    if($line.Count -eq 0){return $null}; return ([string]$line[0]).Substring($Name.Length+1)
}

function Get-LocalAlembic([string]$Backend) {
    if(-not $Backend){return $null}

    $out=@(
        & docker exec $Backend sh -c `
            'cd /app/local && PYTHONPATH=/app /app/.venv/bin/alembic -c /app/local/alembic.ini current' `
            2>$null
    )

    if($LASTEXITCODE -ne 0){
        return $null
    }

    $m = ($out -join "`n") |
        Select-String `
            -Pattern '([0-9a-f]+)\s+\(head\)' `
            -AllMatches

    if($null -ne $m -and $m.Matches.Count -gt 0){
        return $m.Matches[0].Groups[1].Value
    }

    return $null
}

$dataRoot=Get-CrodipDataRoot; $homeRoot=Get-CrodipHome
$cfg=Get-CrodipRuntimeConfig
$effectiveOverride=Get-CrodipPersistentTestOverride
$releaseIdentity=[ordered]@{
 applicationVersion=if($effectiveOverride -and $effectiveOverride.active){[string]$effectiveOverride.applicationVersion}else{[string]$cfg.application.version}
 runNumber=if($effectiveOverride -and $effectiveOverride.active){[int]$effectiveOverride.runNumber}else{[int]$cfg.release.runNumber}
 runId=if($effectiveOverride -and $effectiveOverride.active){[string]$effectiveOverride.runId}else{[string]$cfg.release.runId}
 commit=if($effectiveOverride -and $effectiveOverride.active){[string]$effectiveOverride.commit}else{[string]$cfg.release.commit}
 source=if($effectiveOverride -and $effectiveOverride.active){'TEST_OVERRIDE'}else{'OFFICIAL'}
}

if(-not(Test-Path -LiteralPath $dataRoot)){Write-CrodipError "CRODIP_DATA_ROOT introuvable : $dataRoot"; return}
if(-not $DestinationDirectory){$DestinationDirectory=Join-Path $dataRoot 'backups'}
New-CrodipDirectory -Path $DestinationDirectory|Out-Null
$timestamp=Get-Date -Format 'yyyyMMdd-HHmmss'
$archivePath=Join-Path $DestinationDirectory "crodip-runtime-$Mode-$timestamp.zip"
$stagingRoot=Join-Path $env:TEMP "crodip-runtime-backup-$Mode-$timestamp"
$requiredDirectories=@('sqlite','documents','pdf','photos','signatures','exports','imports','config')

try {
 New-CrodipDirectory -Path $stagingRoot|Out-Null
 foreach($name in $requiredDirectories){
   $src=Join-Path $dataRoot $name; $dst=Join-Path $stagingRoot $name; New-CrodipDirectory -Path $dst|Out-Null
   if(Test-Path $src){$children=@(Get-ChildItem $src -Force -ErrorAction SilentlyContinue);if($children.Count){Copy-Item (Join-Path $src '*') $dst -Recurse -Force}}
 }
 $dbDir=Join-Path $stagingRoot 'databases'; New-CrodipDirectory -Path $dbDir|Out-Null
 $localBackend=Get-ComposeContainerId 'crodip-runtime-local' 'backend'
 $centralBackend=Get-ComposeContainerId 'crodip-runtime-central' 'backend'
 $pg=Get-ComposeContainerId 'crodip-runtime-central' 'postgres'
 $localAlembic=Get-LocalAlembic $localBackend
 $centralAlembic=$null; $pgUser=$null; $pgDb=$null; $pgDumpIncluded=$false
 if($pg){
   $pgUser=Get-ContainerEnv $pg 'POSTGRES_USER'; $pgDb=Get-ContainerEnv $pg 'POSTGRES_DB'
   if(-not $pgUser){$pgUser='postgres'}; if(-not $pgDb){$pgDb=$pgUser}
   $centralAlembic=(& docker exec $pg sh -c "psql -U '$pgUser' -d '$pgDb' -tAc 'SELECT version_num FROM alembic_version LIMIT 1;'" 2>$null | Select-Object -First 1)
   if($LASTEXITCODE -ne 0){$centralAlembic=$null}else{$centralAlembic=([string]$centralAlembic).Trim()}
   $tmp='/tmp/crodip-runtime-backup.dump'
   & docker exec $pg sh -c "rm -f '$tmp' && pg_dump -U '$pgUser' -d '$pgDb' -Fc -f '$tmp'" | Out-Null
   if($LASTEXITCODE -ne 0){throw 'pg_dump CENTRAL a échoué.'}
   & docker cp "${pg}:$tmp" (Join-Path $dbDir 'central-postgresql.dump') | Out-Null
   if($LASTEXITCODE -ne 0){throw 'docker cp du dump PostgreSQL a échoué.'}
   & docker exec $pg rm -f $tmp | Out-Null
   $pgDumpIncluded=$true
 }
 $dbMeta=[ordered]@{
   local=[ordered]@{deployed=[bool]$localBackend;engine='SQLite';alembicRevision=$localAlembic;databaseFile='sqlite/crodip.db'}
   central=[ordered]@{deployed=[bool]$pg;engine='PostgreSQL';alembicRevision=$centralAlembic;database=$pgDb;user=$pgUser;dumpIncluded=$pgDumpIncluded;dumpFile=if($pgDumpIncluded){'databases/central-postgresql.dump'}else{$null}}
 }
 $dbMeta|ConvertTo-Json -Depth 10|Set-Content (Join-Path $dbDir 'ALEMBIC-DATABASE-METADATA.json') -Encoding utf8
 if($Mode -eq 'full'){
   $logsDst=Join-Path $stagingRoot 'logs';New-CrodipDirectory -Path $logsDst|Out-Null;$logsSrc=Join-Path $dataRoot 'logs';if(Test-Path $logsSrc){Copy-Item (Join-Path $logsSrc '*') $logsDst -Recurse -Force -ErrorAction SilentlyContinue}
   $appDst=Join-Path $stagingRoot 'application';New-CrodipDirectory -Path $appDst|Out-Null
   foreach($f in @('compose.yaml','compose.yml','docker-compose.yml','docker-compose.yaml','.env','VERSION')){$s=Join-Path $homeRoot $f;if(Test-Path $s){Copy-Item $s (Join-Path $appDst $f) -Force}}
   $rc=Join-Path $PSScriptRoot '..\config\runtime.json';if(Test-Path $rc){Copy-Item $rc (Join-Path $appDst 'runtime.json') -Force}
 }
 $manifest=[ordered]@{createdAt=(Get-Date).ToString('o');backupMode=$Mode;purpose=$Purpose;runtimeVersion=(Get-CrodipRuntimeVersion);releaseIdentity=$releaseIdentity;sourceDataRoot=$dataRoot;sourceApplicationRoot=$homeRoot;directories=$requiredDirectories;database=$dbMeta;computerName=$env:COMPUTERNAME;userName=$env:USERNAME}
 $manifest|ConvertTo-Json -Depth 12|Set-Content (Join-Path $stagingRoot 'BACKUP-MANIFEST.json') -Encoding utf8
 if(Test-Path $archivePath){Remove-Item $archivePath -Force};Compress-Archive -Path (Join-Path $stagingRoot '*') -DestinationPath $archivePath -CompressionLevel Optimal
 $a=Get-Item $archivePath
 Write-CrodipSuccess "Sauvegarde $Mode créée avec traçabilité Alembic (purpose=$Purpose)"
 Write-Host "Archive : $archivePath";Write-Host "Taille  : $($a.Length) octets"
 Write-Host ("LOCAL   Alembic : {0}" -f $(if($localAlembic){$localAlembic}else{'NON DEPLOYE / INDISPONIBLE'}))
 Write-Host ("CENTRAL Alembic : {0}" -f $(if($centralAlembic){$centralAlembic}else{'NON DEPLOYE / INDISPONIBLE'}))
 Write-Host ("CENTRAL pg_dump : {0}" -f $(if($pgDumpIncluded){'INCLUS'}else{'NON DEPLOYE'}))
}catch{Write-CrodipError "Échec de la sauvegarde : $($_.Exception.Message)";throw}
finally{if(Test-Path $stagingRoot){Remove-Item $stagingRoot -Recurse -Force -ErrorAction SilentlyContinue}}


