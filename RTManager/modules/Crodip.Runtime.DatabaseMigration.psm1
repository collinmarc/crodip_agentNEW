#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Get-CrodipRuntimeContainerId {
    [CmdletBinding()]
    param([Parameter(Mandatory)][string]$Project,[Parameter(Mandatory)][string]$Service)
    $ids=@(& docker ps --filter "label=com.docker.compose.project=$Project" --filter "label=com.docker.compose.service=$Service" --format '{{.ID}}' 2>$null)
    if($LASTEXITCODE -ne 0){ throw "Docker indisponible pendant la détection $Project/$Service." }
    $id=($ids|Select-Object -First 1)
    if([string]::IsNullOrWhiteSpace([string]$id)){ return $null }
    return ([string]$id).Trim()
}

function Get-CrodipExpectedAlembicHead {
    [CmdletBinding()]
    param([Parameter(Mandatory)][ValidateSet('local','central')][string]$Target)
    # FIX11: during an atomic TEST release switch, the target release is not the
    # official pin. Command 17 provides the already-qualified target snapshot head
    # in Process scope. Outside that narrow transaction, keep the official config
    # as the source of truth.
    $overrideName='CRODIP_TARGET_ALEMBIC_'+$Target.ToUpperInvariant()
    $transactionHead=[Environment]::GetEnvironmentVariable($overrideName,'Process')
    if(-not [string]::IsNullOrWhiteSpace([string]$transactionHead)){
        if([string]$transactionHead -notmatch '^[0-9a-f]+$'){throw "Head Alembic transactionnel invalide pour $Target."}
        return ([string]$transactionHead).Trim()
    }
    $configPath=Join-Path $PSScriptRoot '..\config\runtime.json'
    if(-not(Test-Path -LiteralPath $configPath)){ throw "Configuration Runtime absente : $configPath" }
    $cfg=Get-Content -LiteralPath $configPath -Raw -Encoding UTF8 | ConvertFrom-Json
    $node=$cfg.databaseVerification.$Target
    $head=[string]$node.expectedOfficialAlembicHead
    if([string]::IsNullOrWhiteSpace($head)){ throw "Head Alembic attendu par la release absent pour $Target." }
    return $head.Trim()
}

function Write-CrodipMigrationReport {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Target,
        [string]$Previous,
        [Parameter(Mandatory)][string]$ExpectedHead,
        [Parameter(Mandatory)][string]$ImageHead,
        [Parameter(Mandatory)][AllowEmptyString()][string]$Current,
        [Parameter(Mandatory)][ValidateSet('PASS','FAIL')][string]$Result,
        [string]$Detail
    )
    $configPath=Join-Path $PSScriptRoot '..\config\runtime.json'
    $cfg=Get-Content -LiteralPath $configPath -Raw -Encoding UTF8 | ConvertFrom-Json
    $root=[string]$cfg.databaseMigration.migrationReportRoot
    if([string]::IsNullOrWhiteSpace($root)){ $root='C:\ProgramData\CRODIP\migration-history' }
    New-Item -ItemType Directory -Path $root -Force | Out-Null
    $stamp=Get-Date -Format 'yyyyMMdd-HHmmss'
    $path=Join-Path $root ("migration-{0}-{1}.json" -f $Target,$stamp)
    [ordered]@{
        schemaVersion=1
        createdAt=(Get-Date).ToString('o')
        runtimeVersion=(Get-CrodipRuntimeVersion)
        target=$Target
        previousRevision=$Previous
        releaseExpectedHead=$ExpectedHead
        imageHead=$ImageHead
        databaseCurrent=$Current
        result=$Result
        detail=$Detail
        automaticDowngrade=$false
        automaticRestore=$false
    } | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $path -Encoding UTF8
    return $path
}

function Invoke-CrodipRuntimeDatabaseMigration {
    [CmdletBinding()]
    param([Parameter(Mandatory)][ValidateSet('local','central')][string]$Target)

    $project="crodip-runtime-$Target"
    $backend=Get-CrodipRuntimeContainerId -Project $project -Service 'backend'
    if($null -eq $backend){ throw "Migration $($Target.ToUpperInvariant()) impossible : backend absent." }

    if($Target -eq 'central'){
        $postgres=Get-CrodipRuntimeContainerId -Project $project -Service 'postgres'
        if($null -eq $postgres){ throw 'Migration CENTRAL impossible : PostgreSQL absent.' }
        $ready=$false
        for($i=0;$i -lt 30;$i++){
            & docker exec $postgres pg_isready 1>$null 2>$null
            if($LASTEXITCODE -eq 0){$ready=$true;break}
            Start-Sleep -Seconds 2
        }
        if(-not $ready){ throw 'Migration CENTRAL impossible : PostgreSQL non prêt après 60 secondes.' }
    }

    $expectedHead=Get-CrodipExpectedAlembicHead -Target $Target
    $ini="/app/$Target/alembic.ini"
    $base=@('exec',$backend,'sh','-c')
    $headsCmd="cd /app/$Target && PYTHONPATH=/app /app/.venv/bin/alembic -c $ini heads"
    $currentCmd="cd /app/$Target && PYTHONPATH=/app /app/.venv/bin/alembic -c $ini current"
    $upgradeCmd="cd /app/$Target && PYTHONPATH=/app /app/.venv/bin/alembic -c $ini upgrade $expectedHead"

    $heads=@(& docker @base $headsCmd 2>&1)
    if($LASTEXITCODE -ne 0){ throw "Migration $($Target.ToUpperInvariant()) : lecture du head image impossible : $($heads -join ' ')" }
    $headLine=@($heads|Where-Object{[string]$_ -match '^([0-9a-f]+) \(head\)$'}|Select-Object -First 1)
    if($headLine.Count -eq 0){ throw "Migration $($Target.ToUpperInvariant()) : head Alembic de l'image introuvable." }
    $imageHead=([regex]::Match([string]$headLine[0],'^([0-9a-f]+)')).Groups[1].Value

    if($imageHead -ne $expectedHead){
        $detail="Incompatibilité release/image : release=$expectedHead image=$imageHead"
        $report=Write-CrodipMigrationReport -Target $Target -ExpectedHead $expectedHead -ImageHead $imageHead -Current '' -Result FAIL -Detail $detail
        throw "$detail. Migration refusée. Rapport : $report"
    }

    $current=@(& docker @base $currentCmd 2>&1)
    if($LASTEXITCODE -ne 0){
        $detail="Révision courante incompatible avec l'image cible : $($current -join ' ')"
        $report=Write-CrodipMigrationReport -Target $Target -ExpectedHead $expectedHead -ImageHead $imageHead -Current '' -Result FAIL -Detail $detail
        throw "Migration $($Target.ToUpperInvariant()) refusée. Aucun downgrade automatique n'est exécuté. $detail Rapport : $report"
    }
    $currentLine=@($current | ForEach-Object { ([string]$_).Trim() } | Where-Object { $_ -match '^([0-9a-f]+)( \(head\))?$' } | Select-Object -First 1)
    $previous=if($currentLine.Count){([regex]::Match([string]$currentLine[0],'^([0-9a-f]+)')).Groups[1].Value}else{''}

    if($previous -eq $expectedHead){
        $report=Write-CrodipMigrationReport -Target $Target -Previous $previous -ExpectedHead $expectedHead -ImageHead $imageHead -Current $previous -Result PASS -Detail 'Base déjà compatible ; aucune migration nécessaire.'
        Write-Host ("[OK] {0} Alembic déjà compatible : release=image=database={1}" -f $Target.ToUpperInvariant(),$expectedHead) -ForegroundColor Green
        Write-Host ("[OK] Rapport migration : {0}" -f $report) -ForegroundColor Green
        return [pscustomobject]@{Target=$Target;Previous=$previous;Head=$expectedHead;Changed=$false;Report=$report}
    }

    Write-Host ("[INFO] Compatibilité {0} : DB {1} -> release/image {2}" -f $Target.ToUpperInvariant(),$(if($previous){$previous}else{'<vierge>'}),$expectedHead) -ForegroundColor Cyan

    # RC40 safety invariant:
    # every effective schema migration MUST be preceded by a verified PRE-MIGRATION backup,
    # regardless of the entry point that triggered migration (start/update/reconciliation).
    $backupScript=Join-Path $PSScriptRoot '..\commands\06-backup.ps1'
    if(-not(Test-Path -LiteralPath $backupScript)){
        $detail="Sauvegarde PRE-MIGRATION impossible : script absent ($backupScript)."
        $report=Write-CrodipMigrationReport -Target $Target -Previous $previous -ExpectedHead $expectedHead -ImageHead $imageHead -Current $previous -Result FAIL -Detail $detail
        throw "$detail Migration Alembic interdite. Rapport : $report"
    }

    Write-Host ("[INFO] Sauvegarde PRE-MIGRATION obligatoire avant modification {0}..." -f $Target.ToUpperInvariant()) -ForegroundColor Cyan
    try {
        & $backupScript -Mode 'quick' -Purpose 'pre-migration'
    } catch {
        $detail="Sauvegarde PRE-MIGRATION en échec : $($_.Exception.Message)"
        $report=Write-CrodipMigrationReport -Target $Target -Previous $previous -ExpectedHead $expectedHead -ImageHead $imageHead -Current $previous -Result FAIL -Detail $detail
        throw "$detail Alembic upgrade NON exécuté. Rapport : $report"
    }

    Write-Host ("[OK] Sauvegarde PRE-MIGRATION validée ; migration {0} autorisée." -f $Target.ToUpperInvariant()) -ForegroundColor Green
    $upgrade=@(& docker @base $upgradeCmd 2>&1)
    if($LASTEXITCODE -ne 0){
        $detail="Alembic upgrade vers $expectedHead en échec : $($upgrade -join ' ')"
        $report=Write-CrodipMigrationReport -Target $Target -Previous $previous -ExpectedHead $expectedHead -ImageHead $imageHead -Current $previous -Result FAIL -Detail $detail
        throw "Migration $($Target.ToUpperInvariant()) échouée. Aucun downgrade ni restauration automatique n'est tenté. Utilisez la sauvegarde PRE-MIGRATION. Rapport : $report"
    }

    $verify=@(& docker @base $currentCmd 2>&1)
    $finalLine=@($verify | ForEach-Object { ([string]$_).Trim() } | Where-Object { $_ -match "^$([regex]::Escape($expectedHead))( \(head\))?$" } | Select-Object -First 1)
    if($LASTEXITCODE -ne 0 -or $finalLine.Count -eq 0){
        $detail="Contrôle final du head $expectedHead en échec."
        $report=Write-CrodipMigrationReport -Target $Target -Previous $previous -ExpectedHead $expectedHead -ImageHead $imageHead -Current '' -Result FAIL -Detail $detail
        throw "Migration $($Target.ToUpperInvariant()) : $detail Aucun rollback automatique. Rapport : $report"
    }

    $report=Write-CrodipMigrationReport -Target $Target -Previous $previous -ExpectedHead $expectedHead -ImageHead $imageHead -Current $expectedHead -Result PASS -Detail 'Migration et contrôle post-migration réussis.'
    Write-Host ("[OK] {0} : release = image = database = {1}" -f $Target.ToUpperInvariant(),$expectedHead) -ForegroundColor Green
    Write-Host ("[OK] Rapport migration : {0}" -f $report) -ForegroundColor Green
    return [pscustomobject]@{Target=$Target;Previous=$previous;Head=$expectedHead;Changed=$true;Report=$report}
}

Export-ModuleMember -Function Get-CrodipRuntimeContainerId,Get-CrodipExpectedAlembicHead,Write-CrodipMigrationReport,Invoke-CrodipRuntimeDatabaseMigration

