#Requires -Version 7.4
# ==============================================================================
# CRODIP SaaS Runtime Manager
# Script  : 13-qualify-runtime.ps1
# Version  : 2.3.0-RC40
# Objet   : Qualification technique Runtime TEST LOCAL + CENTRAL
# ==============================================================================

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$script:RuntimeRoot = Split-Path -Parent $PSScriptRoot
Import-Module (Join-Path $script:RuntimeRoot "modules\Crodip.Runtime.Common.psm1") -Force
Import-Module (Join-Path $script:RuntimeRoot "modules\Crodip.Runtime.DatabaseMigration.psm1") -Force

$config = Get-CrodipRuntimeConfig
$timeout = 10
if ($config.PSObject.Properties.Name -contains "qualification" -and
    $config.qualification.PSObject.Properties.Name -contains "httpTimeoutSeconds") {
    $timeout = [int]$config.qualification.httpTimeoutSeconds
}

$checks = [System.Collections.Generic.List[object]]::new()

function Add-Check {
    param([string]$Scope,[string]$Name,[bool]$Success,[string]$Detail)
    $script:checks.Add([pscustomobject]@{
        scope=$Scope; name=$Name; success=$Success; detail=$Detail
    })
    $mark = if ($Success) { "[OK]" } else { "[ERREUR]" }
    Write-Host ("{0,-9} {1,-34} {2} {3}" -f $Scope,$Name,$mark,$Detail)
}

function Test-Http200 {
    param([string]$Scope,[string]$Name,[string]$Url)
    try {
        $r = Invoke-WebRequest -Uri $Url -UseBasicParsing -TimeoutSec $timeout
        Add-Check $Scope $Name ($r.StatusCode -eq 200) ("HTTP {0} - {1}" -f $r.StatusCode,$Url)
    } catch {
        Add-Check $Scope $Name $false ("{0} - {1}" -f $_.Exception.Message,$Url)
    }
}

function Get-AlembicRuntimeState {
    param(
        [Parameter(Mandatory)][ValidateSet("local","central")][string]$Target,
        [Parameter(Mandatory)][string]$Engine
    )

    $project = "crodip-runtime-$Target"
    $backend = Get-CrodipRuntimeContainerId -Project $project -Service "backend"
    $expectedHead = Get-CrodipExpectedAlembicHead -Target $Target

    if ([string]::IsNullOrWhiteSpace([string]$backend)) {
        Add-Check $Target.ToUpperInvariant() "Database engine" $false "$Engine / backend absent"
        Add-Check $Target.ToUpperInvariant() "Alembic database revision" $false "backend absent"
        Add-Check $Target.ToUpperInvariant() "Alembic image head" $false "backend absent"
        Add-Check $Target.ToUpperInvariant() "Alembic release expected" $true $expectedHead
        Add-Check $Target.ToUpperInvariant() "Alembic compatibility" $false "contrôle impossible"
        return [pscustomobject]@{ engine=$Engine; releaseExpectedHead=$expectedHead; imageHead=""; databaseCurrent=""; compatible=$false }
    }

    $scope = $Target.ToUpperInvariant()
    Add-Check $scope "Database engine" $true $Engine
    $ini = "/app/$Target/alembic.ini"
    $headsCmd = "cd /app/$Target && PYTHONPATH=/app /app/.venv/bin/alembic -c $ini heads"
    $currentCmd = "cd /app/$Target && PYTHONPATH=/app /app/.venv/bin/alembic -c $ini current"

    $heads = @(& docker exec $backend sh -c $headsCmd 2>&1)
    $headsExit = $LASTEXITCODE
    $headLine = @($heads | Where-Object { [string]$_ -match '^([0-9a-f]+) \(head\)$' } | Select-Object -First 1)
    $imageHead = if ($headsExit -eq 0 -and $headLine.Count -gt 0) { ([regex]::Match([string]$headLine[0],'^([0-9a-f]+)')).Groups[1].Value } else { "" }

    $current = @(& docker exec $backend sh -c $currentCmd 2>&1)
    $currentExit = $LASTEXITCODE
    $currentLine = @($current | Where-Object { [string]$_ -match '^([0-9a-f]+)( \(head\))?$' } | Select-Object -First 1)
    $databaseCurrent = if ($currentExit -eq 0 -and $currentLine.Count -gt 0) { ([regex]::Match([string]$currentLine[0],'^([0-9a-f]+)')).Groups[1].Value } else { "" }

    Add-Check $scope "Alembic database revision" (-not [string]::IsNullOrWhiteSpace($databaseCurrent)) $(if($databaseCurrent){$databaseCurrent}else{"indisponible"})
    Add-Check $scope "Alembic image head" (-not [string]::IsNullOrWhiteSpace($imageHead)) $(if($imageHead){$imageHead}else{"indisponible"})
    Add-Check $scope "Alembic release expected" (-not [string]::IsNullOrWhiteSpace($expectedHead)) $expectedHead

    $compatible = (-not [string]::IsNullOrWhiteSpace($databaseCurrent)) -and
                  (-not [string]::IsNullOrWhiteSpace($imageHead)) -and
                  ($expectedHead -eq $imageHead) -and
                  ($expectedHead -eq $databaseCurrent)
    $detail = "release={0} / image={1} / database={2}" -f $expectedHead,$imageHead,$databaseCurrent
    Add-Check $scope "Alembic compatibility" $compatible $detail

    return [pscustomobject]@{
        engine = $Engine
        releaseExpectedHead = $expectedHead
        imageHead = $imageHead
        databaseCurrent = $databaseCurrent
        compatible = $compatible
    }
}

function Test-ComposeService {
    param(
        [string]$Scope,
        [string]$Project,
        [string]$Service,
        [string]$ExpectedImage
    )

    # `docker ps` peut afficher un ID d'image abrégé dans le champ Image
    # lorsque le conteneur a été créé depuis une référence repo@sha256:digest.
    # La source fiable pour la référence demandée à la création du conteneur
    # est `.Config.Image` retournée par `docker inspect`.
    $rows = @(& docker ps `
        --filter "label=com.docker.compose.project=$Project" `
        --filter "label=com.docker.compose.service=$Service" `
        --format "{{json .}}" 2>$null)

    if ($LASTEXITCODE -ne 0 -or $rows.Count -eq 0) {
        Add-Check $Scope "$Service container" $false "absent"
        Add-Check $Scope "$Service digest" $false "conteneur absent"
        return
    }

    $row = $rows[0] | ConvertFrom-Json
    Add-Check $Scope "$Service container" ($row.State -eq "running") $row.Status

    $containerId = [string]$row.ID
    $configuredImage = (& docker inspect --format "{{.Config.Image}}" $containerId 2>$null | Select-Object -First 1)

    if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace([string]$configuredImage)) {
        Add-Check $Scope "$Service digest" $false "docker inspect .Config.Image indisponible"
        return
    }

    $configuredImage = ([string]$configuredImage).Trim()
    $isExact = [string]::Equals(
        $configuredImage,
        $ExpectedImage,
        [System.StringComparison]::OrdinalIgnoreCase
    )

    Add-Check $Scope "$Service digest" $isExact $configuredImage
}

Write-Host ""
Write-Host "============================================================"
Write-Host " QUALIFICATION TECHNIQUE RUNTIME"
Write-Host "============================================================"
Write-Host ("Runtime     : {0}" -f $config.version)
Write-Host ("Application : {0}" -f $config.application.version)
Write-Host ("Cycle       : {0}" -f $config.docker.activeLifecycle)
Write-Host ("Run CI      : #{0} / {1}" -f $config.release.runNumber,$config.release.runId)
Write-Host ("Commit      : {0}" -f $config.release.commit)
Write-Host ""

$localBack  = [string](Get-CrodipEffectiveImageNode -Target local -Service backend).reference
$localFront = [string](Get-CrodipEffectiveImageNode -Target local -Service frontend).reference
$centBack   = [string](Get-CrodipEffectiveImageNode -Target central -Service backend).reference
$centFront  = [string](Get-CrodipEffectiveImageNode -Target central -Service frontend).reference

Test-ComposeService "LOCAL" "crodip-runtime-local" "backend"  $localBack
Test-ComposeService "LOCAL" "crodip-runtime-local" "frontend" $localFront
$localDbCompatibility = Get-AlembicRuntimeState -Target local -Engine "SQLite"
Test-Http200 "LOCAL" "Backend /health" "http://localhost:8110/health"
Test-Http200 "LOCAL" "Backend /health/db" "http://localhost:8110/health/db"
Test-Http200 "LOCAL" "Backend /docs"   "http://localhost:8110/docs"
Test-Http200 "LOCAL" "Frontend /"      "http://localhost:9110/"

Test-ComposeService "CENTRAL" "crodip-runtime-central" "backend"  $centBack
Test-ComposeService "CENTRAL" "crodip-runtime-central" "frontend" $centFront

$pgRows = @(& docker ps --filter "label=com.docker.compose.project=crodip-runtime-central" --filter "label=com.docker.compose.service=postgres" --format "{{json .}}" 2>$null)
if ($LASTEXITCODE -eq 0 -and $pgRows.Count -gt 0) {
    $pg = $pgRows[0] | ConvertFrom-Json
    $healthy = ($pg.State -eq "running" -and $pg.Status -match "healthy")
    Add-Check "CENTRAL" "PostgreSQL 17" $healthy $pg.Status
} else {
    Add-Check "CENTRAL" "PostgreSQL 17" $false "absent"
}
$centralDbCompatibility = Get-AlembicRuntimeState -Target central -Engine "PostgreSQL 17"

Test-Http200 "CENTRAL" "Backend /health" "http://localhost:8120/health"
Test-Http200 "CENTRAL" "Backend /health/db" "http://localhost:8120/health/db"
Test-Http200 "CENTRAL" "Backend /docs"   "http://localhost:8120/docs"
Test-Http200 "CENTRAL" "Frontend /"      "http://localhost:9120/"

$allOk = @($checks | Where-Object { -not $_.success }).Count -eq 0
$status = if ($allOk) { "RUNTIME TEST TECHNICALLY QUALIFIED" } else { "RUNTIME TEST TECHNICAL QUALIFICATION FAILED" }

$artifact = [ordered]@{
    schemaVersion = 1
    generatedAt = (Get-Date).ToString("o")
    runtimeVersion = [string]$config.version
    applicationVersion = [string]$config.application.version
    lifecycle = [string]$config.docker.activeLifecycle
    qualificationStatus = $status
    functionalQualification = "NOT_APPLICABLE"
    officialRelease = [ordered]@{
        runNumber = $config.release.runNumber
        runId = [string]$config.release.runId
        commit = [string]$config.release.commit
        officialStatus = [string]$config.release.officialStatus
        buildPolicy = [string]$config.release.buildPolicy
    }
    databaseCompatibility = [ordered]@{
        local = [ordered]@{
            engine = $localDbCompatibility.engine
            releaseExpectedHead = $localDbCompatibility.releaseExpectedHead
            imageHead = $localDbCompatibility.imageHead
            databaseCurrent = $localDbCompatibility.databaseCurrent
            compatible = $localDbCompatibility.compatible
        }
        central = [ordered]@{
            engine = $centralDbCompatibility.engine
            engineVersion = "17"
            releaseExpectedHead = $centralDbCompatibility.releaseExpectedHead
            imageHead = $centralDbCompatibility.imageHead
            databaseCurrent = $centralDbCompatibility.databaseCurrent
            compatible = $centralDbCompatibility.compatible
        }
    }
    checks = @($checks)
}

$artifactPath = [string]$config.qualification.artifact
$artifactDir = Split-Path -Parent $artifactPath
New-Item -ItemType Directory -Force -Path $artifactDir | Out-Null
$artifact | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $artifactPath -Encoding utf8

Write-Host ""
Write-Host "============================================================"
Write-Host (" {0}" -f $status)
Write-Host "============================================================"
Write-Host ("Artefact : {0}" -f $artifactPath)

if (-not $allOk) { exit 1 }
