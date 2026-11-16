#Requires -Version 7.4
[CmdletBinding()]
param()

Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'

$RuntimeRoot=Split-Path -Parent $PSScriptRoot
Import-Module (Join-Path $RuntimeRoot 'modules\Crodip.Runtime.Common.psm1') -Force
$config=Get-CrodipRuntimeConfig
$effective=Get-CrodipEffectiveRelease
$results=[System.Collections.Generic.List[object]]::new()

function Add-DbCheck {
    param(
        [string]$Scope,[string]$Name,[string]$Status,[string]$Detail=''
    )
    $success = $Status -in @('OK','NON DEPLOYE','NON TESTE')
    $script:results.Add([pscustomobject]@{
        scope=$Scope; name=$Name; status=$Status; success=$success; detail=$Detail
    })
    $label = switch($Status) {
        'OK'          {'[OK]'}
        'NON DEPLOYE' {'[NON DEPLOYE]'}
        'NON TESTE'   {'[NON TESTE]'}
        default       {'[ERREUR]'}
    }
    Write-Host ("{0,-8} {1,-30} {2} {3}" -f $Scope,$Name,$label,$Detail)
}

function Get-ComposeContainerId {
    param([string]$Project,[string]$Service)
    $id=@(& docker ps --filter "label=com.docker.compose.project=$Project" `
        --filter "label=com.docker.compose.service=$Service" `
        --format "{{.ID}}" 2>$null | Select-Object -First 1)
    if($LASTEXITCODE -ne 0 -or $id.Count -eq 0){return $null}
    $value=([string]$id[0]).Trim()
    if([string]::IsNullOrWhiteSpace($value)){return $null}
    return $value
}


function Get-ImageAlembicHead {
    param([string]$Container,[ValidateSet('local','central')][string]$Target)
    $ini="/app/$Target/alembic.ini"
    $cmd="cd /app/$Target && PYTHONPATH=/app /app/.venv/bin/alembic -c $ini heads"
    $out=@(& docker exec $Container sh -c $cmd 2>&1)
    if($LASTEXITCODE -ne 0){return $null}
    $line=$out|Where-Object{[string]$_ -match '^([0-9a-f]+) \(head\)$'}|Select-Object -First 1
    if($null -eq $line){return $null}
    return ([regex]::Match([string]$line,'^([0-9a-f]+)')).Groups[1].Value
}

function Get-ContainerEnv {
    param([string]$Container,[string]$Name)
    $lines=@(& docker inspect --format '{{range .Config.Env}}{{println .}}{{end}}' $Container 2>$null)
    if($LASTEXITCODE -ne 0){return $null}
    $prefix=$Name+'='
    $line=$lines|Where-Object{[string]$_ -like "$prefix*"}|Select-Object -First 1
    if($null -eq $line){return $null}
    return ([string]$line).Substring($prefix.Length)
}

function Test-DbHealth {
    param([string]$Scope,[string]$Url)
    try {
        $r=Invoke-WebRequest -Uri $Url -UseBasicParsing -TimeoutSec 10
        if($r.StatusCode -eq 200){Add-DbCheck $Scope '/health/db' 'OK' ("HTTP {0}" -f $r.StatusCode)}
        else {Add-DbCheck $Scope '/health/db' 'ERREUR' ("HTTP {0}" -f $r.StatusCode)}
    } catch {
        Add-DbCheck $Scope '/health/db' 'ERREUR' $_.Exception.Message
    }
}

function Get-SqlitePathFromUrl {
    param([string]$DatabaseUrl)
    if([string]::IsNullOrWhiteSpace($DatabaseUrl)){return $null}
    # SQLAlchemy absolute SQLite URL: sqlite:////absolute/path/file.db
    if($DatabaseUrl -match '^sqlite(?:\+[^:]+)?:////(.+)$'){
        return '/' + $Matches[1].TrimStart('/')
    }
    if($DatabaseUrl -match '^sqlite(?:\+[^:]+)?:///([^?]+)'){
        return $Matches[1]
    }
    return $null
}

Write-Host ''
Write-Host '============================================================'
Write-Host ' VERIFICATION BASES DE DONNEES RUNTIME'
Write-Host '============================================================'
Write-Host ("Runtime     : {0}" -f $config.version)
Write-Host ("Application : {0}" -f $effective.applicationVersion)
Write-Host ("Run actif   : #{0} / {1}" -f $effective.runNumber,$effective.runId)
Write-Host ("Source      : {0}" -f $effective.source)
Write-Host ''

# ---------------------------------------------------------------------------
# LOCAL / SQLite — detect DATABASE_URL dynamically from the running backend.
# ---------------------------------------------------------------------------
$localId=Get-ComposeContainerId -Project 'crodip-runtime-local' -Service 'backend'
if($null -eq $localId){
    Add-DbCheck 'LOCAL' 'topologie' 'NON DEPLOYE' 'backend LOCAL absent'
}else{
    Add-DbCheck 'LOCAL' 'backend' 'OK' $localId
    $dbUrl=Get-ContainerEnv -Container $localId -Name 'DATABASE_URL'

    if([string]::IsNullOrWhiteSpace($dbUrl)){
        Add-DbCheck 'LOCAL' 'DATABASE_URL' 'ERREUR' 'variable absente du conteneur'
    }else{
        $safeUrl=$dbUrl
        Add-DbCheck 'LOCAL' 'DATABASE_URL' 'OK' $safeUrl
        $sqlitePath=Get-SqlitePathFromUrl -DatabaseUrl $dbUrl

        if([string]::IsNullOrWhiteSpace($sqlitePath)){
            Add-DbCheck 'LOCAL' 'Chemin SQLite' 'ERREUR' 'DATABASE_URL SQLite non reconnue'
        }else{
            Add-DbCheck 'LOCAL' 'Chemin SQLite' 'OK' $sqlitePath

            $probe=@'
import os, sqlite3, sys
p=sys.argv[1]
assert os.path.isfile(p), "fichier SQLite absent: "+p
c=sqlite3.connect("file:"+p+"?mode=ro", uri=True)
assert c.execute("SELECT 1").fetchone()[0] == 1
tables=[r[0] for r in c.execute("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name")]
assert "alembic_version" in tables, "table alembic_version absente"
row=c.execute("SELECT version_num FROM alembic_version").fetchone()
assert row and row[0], "version Alembic absente"
print("ALEMBIC="+row[0])
print("TABLES="+str(len(tables)))
c.close()
'@
            $out=@(& docker exec $localId python -c $probe $sqlitePath 2>&1)
            if($LASTEXITCODE -eq 0){
                Add-DbCheck 'LOCAL' 'SQLite SELECT lecture seule' 'OK' (($out -join ' | ').Trim())
                $line=$out|Where-Object{[string]$_ -match '^ALEMBIC='}|Select-Object -First 1
                $head=if($line){([string]$line).Substring(8).Trim()}else{''}
                $imageHead=Get-ImageAlembicHead -Container $localId -Target local
                if([string]::IsNullOrWhiteSpace($imageHead)){
                    Add-DbCheck 'LOCAL' 'Alembic head image active' 'ERREUR' 'head embarqué introuvable'
                }elseif($head -eq $imageHead){
                    Add-DbCheck 'LOCAL' 'Alembic head image active' 'OK' $head
                }else{
                    Add-DbCheck 'LOCAL' 'Alembic head image active' 'ERREUR' ("attendu={0} obtenu={1}" -f $imageHead,$head)
                }
            }else{
                Add-DbCheck 'LOCAL' 'SQLite SELECT lecture seule' 'ERREUR' (($out -join ' | ').Trim())
            }
        }
    }
    Test-DbHealth 'LOCAL' 'http://localhost:8110/health/db'
}

# ---------------------------------------------------------------------------
# CENTRAL / PostgreSQL — absence of topology is informational, not a failure.
# ---------------------------------------------------------------------------
$pgId=Get-ComposeContainerId -Project 'crodip-runtime-central' -Service 'postgres'
$centralId=Get-ComposeContainerId -Project 'crodip-runtime-central' -Service 'backend'

if($null -eq $pgId -and $null -eq $centralId){
    Add-DbCheck 'CENTRAL' 'topologie' 'NON DEPLOYE' 'Runtime CENTRAL absent'
    Add-DbCheck 'CENTRAL' '/health/db' 'NON TESTE' 'topologie non déployée'
}else{
    if($null -eq $pgId){
        Add-DbCheck 'CENTRAL' 'PostgreSQL' 'ERREUR' 'backend présent mais PostgreSQL absent'
    }else{
        $pgUser=Get-ContainerEnv -Container $pgId -Name 'POSTGRES_USER'
        $pgDb=Get-ContainerEnv -Container $pgId -Name 'POSTGRES_DB'
        if([string]::IsNullOrWhiteSpace($pgUser)){$pgUser='crodip'}
        if([string]::IsNullOrWhiteSpace($pgDb)){$pgDb='crodip'}

        $ready=@(& docker exec $pgId pg_isready -U $pgUser -d $pgDb 2>&1)
        if($LASTEXITCODE -eq 0){
            Add-DbCheck 'CENTRAL' 'PostgreSQL pg_isready' 'OK' (($ready -join ' ').Trim())
        }else{
            Add-DbCheck 'CENTRAL' 'PostgreSQL pg_isready' 'ERREUR' (($ready -join ' ').Trim())
        }

        $one=@(& docker exec $pgId psql -U $pgUser -d $pgDb -Atqc 'SELECT 1;' 2>&1)
        if($LASTEXITCODE -eq 0 -and ($one -join '').Trim() -eq '1'){
            Add-DbCheck 'CENTRAL' 'PostgreSQL SELECT 1' 'OK' '1'
        }else{
            Add-DbCheck 'CENTRAL' 'PostgreSQL SELECT 1' 'ERREUR' (($one -join ' ').Trim())
        }

        $headOut=@(& docker exec $pgId psql -U $pgUser -d $pgDb -Atqc 'SELECT version_num FROM alembic_version;' 2>&1)
        $head=($headOut -join '').Trim()
        if($LASTEXITCODE -eq 0 -and -not [string]::IsNullOrWhiteSpace($head)){
            if($null -eq $centralId){
                Add-DbCheck 'CENTRAL' 'Alembic head image active' 'ERREUR' 'backend absent pour déterminer le head'
            }else{
                $imageHead=Get-ImageAlembicHead -Container $centralId -Target central
                if([string]::IsNullOrWhiteSpace($imageHead)){
                    Add-DbCheck 'CENTRAL' 'Alembic head image active' 'ERREUR' 'head embarqué introuvable'
                }elseif($head -eq $imageHead){
                    Add-DbCheck 'CENTRAL' 'Alembic head image active' 'OK' $head
                }else{
                    Add-DbCheck 'CENTRAL' 'Alembic head image active' 'ERREUR' ("attendu={0} obtenu={1}" -f $imageHead,$head)
                }
            }
        }else{
            Add-DbCheck 'CENTRAL' 'Alembic version' 'ERREUR' (($headOut -join ' ').Trim())
        }
    }

    if($null -eq $centralId){
        Add-DbCheck 'CENTRAL' 'backend' 'ERREUR' 'PostgreSQL présent mais backend absent'
    }else{
        Add-DbCheck 'CENTRAL' 'backend' 'OK' $centralId
        Test-DbHealth 'CENTRAL' 'http://localhost:8120/health/db'
    }
}

$errors=@($results|Where-Object{$_.status -eq 'ERREUR'})
$localDeployed=@($results|Where-Object{$_.scope -eq 'LOCAL' -and $_.status -ne 'NON DEPLOYE'}).Count -gt 0
$centralDeployed=@($results|Where-Object{$_.scope -eq 'CENTRAL' -and $_.status -notin @('NON DEPLOYE','NON TESTE')}).Count -gt 0

Write-Host ''
Write-Host '------------------------------------------------------------'
if($localDeployed){
    $le=@($errors|Where-Object{$_.scope -eq 'LOCAL'}).Count
    Write-Host ("LOCAL   : {0}" -f $(if($le -eq 0){'PASS'}else{'FAIL'}))
}else{ Write-Host 'LOCAL   : NON DEPLOYE' }

if($centralDeployed){
    $ce=@($errors|Where-Object{$_.scope -eq 'CENTRAL'}).Count
    Write-Host ("CENTRAL : {0}" -f $(if($ce -eq 0){'PASS'}else{'FAIL'}))
}else{ Write-Host 'CENTRAL : NON DEPLOYE' }

if($errors.Count -eq 0){
    Write-Host 'GLOBAL  : PASS (périmètre des topologies déployées)' -ForegroundColor Green
    exit 0
}
Write-Host ("GLOBAL  : FAIL ({0} erreur(s))" -f $errors.Count) -ForegroundColor Red
exit 1
