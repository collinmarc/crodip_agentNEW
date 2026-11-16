[CmdletBinding()]
param([Parameter(Mandatory)][int]$RunNumber)
$ErrorActionPreference='Stop'
$runtimeRoot=Split-Path -Parent $PSScriptRoot
Import-Module (Join-Path $runtimeRoot 'modules\Crodip.Runtime.Common.psm1') -Force -DisableNameChecking
Import-Module (Join-Path $runtimeRoot 'modules\Crodip.Runtime.ReleaseRollback.psm1') -Force -DisableNameChecking

function Get-Step3DImageReference([object]$img){("{0}@{1}" -f [string]$img.repository,[string]$img.digest).ToLowerInvariant()}
function Get-Step3DImages([object]$m){
 $o=[ordered]@{local=[ordered]@{};central=[ordered]@{}}
 foreach($x in @(@('local-backend','local','backend'),@('local-frontend','local','frontend'),@('central-backend','central','backend'),@('central-frontend','central','frontend'))){
  $a=@($m.images|Where-Object{[string]$_.key -eq $x[0]});if($a.Count-ne 1){throw "Image $($x[0]) absente/non unique."}
  $o[$x[1]][$x[2]]=[ordered]@{repository=[string]$a[0].repository;digest=[string]$a[0].digest;reference=(Get-Step3DImageReference $a[0])}
 };$o
}
function Resolve-Step3DRelease([int]$Number){
 # Réutilise volontairement STEP3C/FIX3 comme résolveur officiel. Un exit 2 signifie seulement
 # qu'aucun backup historique n'existe ; le manifest officiel téléchargé reste exploitable.
 & pwsh.exe -NoProfile -ExecutionPolicy Bypass -File (Join-Path $PSScriptRoot '20-bootstrap-historical-release-snapshot.ps1') -RunNumber $Number
 $rc=$LASTEXITCODE
 if($rc -ne 0 -and $rc -ne 2){throw "Résolution STEP3C du Build #$Number en échec (code $rc)."}
 $cfg=Get-CrodipRuntimeConfig
 $root=[string]$cfg.releaseUpdate.historyRoot
 $dirs=@(Get-ChildItem -LiteralPath $root -Directory -Filter ("snapshot-bootstrap-run-{0}-*" -f $Number) -ErrorAction SilentlyContinue|Sort-Object LastWriteTime -Descending)
 foreach($d in $dirs){
  foreach($f in @(Get-ChildItem $d.FullName -Recurse -File -Filter manifest.json -ErrorAction SilentlyContinue)){
   try{$m=Get-Content $f.FullName -Raw|ConvertFrom-Json}catch{continue}
   if(-not($m.PSObject.Properties.Name -contains 'images') -or -not($m.PSObject.Properties.Name -contains 'applicationVersion')){continue}
   $imgs=Get-Step3DImages $m
   $rn=[regex]::Match($d.Name,'snapshot-bootstrap-run-(\d+)-(\d+)')
   if($rn.Success){return [pscustomobject]@{RunNumber=$Number;RunId=$rn.Groups[2].Value;ApplicationVersion=[string]$m.applicationVersion;Commit=[string]$m.gitCommit;ManifestPath=$f.FullName;Images=$imgs}}
  }
 }
 throw "Manifest officiel STEP3C du Build #$Number introuvable après résolution."
}
function Invoke-Step3DDocker {
 param(
  [Parameter(Mandatory, Position=0)]
  [string[]]$DockerArgs,
  [Parameter(Mandatory, Position=1)]
  [string]$ErrorMessage
 )
 & docker @DockerArgs
 if($LASTEXITCODE -ne 0){throw $ErrorMessage}
}

$r=Resolve-Step3DRelease $RunNumber
$localImage=[string]$r.Images.local.backend.reference;$centralImage=[string]$r.Images.central.backend.reference
$localHead=Get-CrodipImageAlembicHead -Image $localImage -Target local
$centralHead=Get-CrodipImageAlembicHead -Image $centralImage -Target central
$token=(Get-Date -Format 'yyyyMMddHHmmss')+'-'+([guid]::NewGuid().ToString('N').Substring(0,8))
$work=Join-Path $env:TEMP "crodip-step3d-$token";$sqliteDir=Join-Path $work 'sqlite';$dbDir=Join-Path $work 'databases'
New-Item -ItemType Directory -Force -Path $sqliteDir,$dbDir|Out-Null
$network="crodip-step3d-$token";$pg="crodip-step3d-pg-$token"
$pgUser='crodip';$pgDb='crodip';$pgPassword=[guid]::NewGuid().ToString('N')
$archiveDir=Join-Path (Get-CrodipReleaseSnapshotRoot) ("run-{0}-{1}" -f $r.RunNumber,$r.RunId)
$archive=Join-Path $archiveDir ("crodip-runtime-reconstructed-{0}.zip" -f (Get-Date -Format 'yyyyMMdd-HHmmss'))
Write-Host '============================================================' -ForegroundColor Cyan
Write-Host ' RC41 STEP3D - ISOLATED HISTORICAL RELEASE RECONSTRUCTION' -ForegroundColor Cyan
Write-Host '============================================================' -ForegroundColor Cyan
Write-Host ("Release cible : #{0} / {1}" -f $r.RunNumber,$r.ApplicationVersion)
Write-Host ("Run ID        : {0}" -f $r.RunId)
Write-Host '[GARDE-FOU] Bases LOCAL/CENTRAL actives : JAMAIS montees, restaurees ou modifiees.' -ForegroundColor Yellow
try{
 Write-Host '';Write-Host '==> Reconstruction SQLite LOCAL isolée' -ForegroundColor Cyan
 $mount=($sqliteDir -replace '\\','/')
 Invoke-Step3DDocker @('run','--rm','--entrypoint','sh','-e','CRODIP_DATA_ROOT=/app/runtime','-e','DATABASE_URL=sqlite:////app/runtime/sqlite/crodip.db','-v',"${mount}:/app/runtime/sqlite",$localImage,'-c','cd /app/local && PYTHONPATH=/app /app/.venv/bin/alembic -c /app/local/alembic.ini upgrade head') 'Alembic LOCAL STEP3D en échec.'
 $sqliteFile=Join-Path $sqliteDir 'crodip.db';if(-not(Test-Path $sqliteFile)){throw 'SQLite reconstruite introuvable après Alembic.'}
 Write-Host ("[OK] SQLite reconstruite au head {0}" -f $localHead) -ForegroundColor Green

 Write-Host '';Write-Host '==> Reconstruction PostgreSQL CENTRAL isolée' -ForegroundColor Cyan
 Invoke-Step3DDocker @('network','create',$network) 'Création réseau Docker STEP3D en échec.'
 Invoke-Step3DDocker @('run','-d','--name',$pg,'--network',$network,'-e',"POSTGRES_DB=$pgDb",'-e',"POSTGRES_USER=$pgUser",'-e',"POSTGRES_PASSWORD=$pgPassword",'postgres:17') 'Démarrage PostgreSQL STEP3D en échec.'
 $ready=$false;for($i=0;$i-lt 60;$i++){& docker exec $pg pg_isready -U $pgUser -d $pgDb *> $null;if($LASTEXITCODE-eq 0){$ready=$true;break};Start-Sleep -Seconds 1};if(-not $ready){throw 'PostgreSQL STEP3D non prêt.'}
 $url="postgresql+psycopg://${pgUser}:${pgPassword}@${pg}:5432/${pgDb}"
 Invoke-Step3DDocker @('run','--rm','--network',$network,'--entrypoint','sh','-e',"DATABASE_URL=$url",$centralImage,'-c','cd /app/central && PYTHONPATH=/app /app/.venv/bin/alembic -c /app/central/alembic.ini upgrade head') 'Alembic CENTRAL STEP3D en échec.'
 $rev=(& docker exec $pg psql -U $pgUser -d $pgDb -tAc 'SELECT version_num FROM alembic_version LIMIT 1;'|Select-Object -First 1).Trim();if($LASTEXITCODE-ne 0 -or $rev-ne $centralHead){throw "Qualification Alembic CENTRAL échouée : db=$rev image=$centralHead"}
 $tmp='/tmp/step3d.dump';Invoke-Step3DDocker @('exec',$pg,'pg_dump','-U',$pgUser,'-d',$pgDb,'-Fc','-f',$tmp) 'pg_dump STEP3D en échec.'
 Invoke-Step3DDocker @('cp',"${pg}:$tmp",(Join-Path $dbDir 'central-postgresql.dump')) 'docker cp dump STEP3D en échec.'
 Write-Host ("[OK] PostgreSQL reconstruite au head {0}" -f $centralHead) -ForegroundColor Green

 $manifest=[ordered]@{schemaVersion=2;createdAt=(Get-Date).ToString('o');backupMode='reconstructed';purpose='historical-release-reconstruction';runtimeVersion=(Get-CrodipRuntimeVersion);origin='reconstructed';dataState='EMPTY';qualified=$true;releaseIdentity=[ordered]@{applicationVersion=$r.ApplicationVersion;runNumber=$r.RunNumber;runId=$r.RunId;commit=$r.Commit;source='RECONSTRUCTED_OFFICIAL_RELEASE'};database=[ordered]@{local=[ordered]@{deployed=$true;engine='SQLite';alembicRevision=$localHead;databaseFile='sqlite/crodip.db'};central=[ordered]@{deployed=$true;engine='PostgreSQL';alembicRevision=$centralHead;database=$pgDb;user=$pgUser;dumpIncluded=$true;dumpFile='databases/central-postgresql.dump'}};images=$r.Images;qualification=[ordered]@{identityMatched=$true;databaseCompatibility=$true;liveDatabasesModified=$false;isolatedDocker=$true;historicalBusinessData=$false}}
 $manifest|ConvertTo-Json -Depth 14|Set-Content (Join-Path $work 'BACKUP-MANIFEST.json') -Encoding utf8
 New-Item -ItemType Directory -Force -Path $archiveDir|Out-Null
 Compress-Archive -Path (Join-Path $work '*') -DestinationPath $archive -CompressionLevel Optimal -Force
 $meta=[ordered]@{schemaVersion=2;createdAt=(Get-Date).ToString('o');runtimeVersion=(Get-CrodipRuntimeVersion);reason='historical-release-reconstruction';origin='reconstructed';dataState='EMPTY';release=[ordered]@{applicationVersion=$r.ApplicationVersion;runNumber=$r.RunNumber;runId=$r.RunId;commit=$r.Commit;source='RECONSTRUCTED_OFFICIAL_RELEASE'};archive=$archive;status='RECONSTRUCTED_READY_NOT_AUTO_RESTORABLE';qualification=$manifest.qualification}
 $meta|ConvertTo-Json -Depth 14|Set-Content (Join-Path $archiveDir 'release-snapshot-reconstructed.json') -Encoding utf8
 Write-Host '';Write-Host '[OK] Snapshot reconstruit qualifié.' -ForegroundColor Green
 Write-Host ("Archive : {0}" -f $archive)
 Write-Host ("LOCAL Alembic   : {0}" -f $localHead);Write-Host ("CENTRAL Alembic : {0}" -f $centralHead)
 Write-Host 'Données métier historiques : NON (EMPTY)'
 Write-Host 'Bases actives modifiées     : NON'
 Write-Host '[GARDE-FOU] Ce snapshot reconstruit reste NON ELIGIBLE au DOWNGRADE automatique STEP3B.' -ForegroundColor Yellow
}finally{
 & docker rm -f $pg *> $null
 & docker network rm $network *> $null
 if(Test-Path $work){Remove-Item $work -Recurse -Force -ErrorAction SilentlyContinue}
}

