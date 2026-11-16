###############################################################
# CRODIP Runtime Manager
# Test     : tests\Test-Lot3-Health.ps1
# Version  : 2.2.1
###############################################################

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot

foreach ($relativePath in @(
    "modules\Crodip.Runtime.Health.psm1",
    "commands\02-check.ps1",
    "config\runtime.json"
)) {
    $path = Join-Path $root $relativePath

    if (-not (Test-Path -LiteralPath $path)) {
        throw "Fichier absent : $relativePath"
    }
}

$healthModule = Get-Content `
    -LiteralPath (
        Join-Path $root "modules\Crodip.Runtime.Health.psm1"
    ) `
    -Raw

foreach ($functionName in @(
    "New-CrodipHealthResult",
    "Invoke-CrodipHealthCheck",
    "Get-CrodipRuntimeHealth",
    "Get-CrodipHealthSummary",
    "Export-CrodipHealthReports"
)) {
    if ($healthModule -notmatch "function\s+$functionName\b") {
        throw "Fonction Health absente : $functionName"
    }
}

$checkScript = Get-Content `
    -LiteralPath (
        Join-Path $root "commands\02-check.ps1"
    ) `
    -Raw

foreach ($token in @(
    "Get-CrodipRuntimeHealth",
    "Get-CrodipHealthSummary",
    "Export-CrodipHealthReports",
    "READY WITH WARNINGS",
    "NOT READY"
)) {
    if ($checkScript -notmatch [regex]::Escape($token)) {
        throw "Élément absent : $token"
    }
}

Write-Host `
    "[OK] Validation statique du Lot 3 Health réussie." `
    -ForegroundColor Green
