###############################################################
# CRODIP Runtime Manager
# Test     : tests\Test-Lot4-Docker.ps1
# Version  : 2.2.1
###############################################################

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot

foreach ($relativePath in @(
    "modules\Crodip.Runtime.Docker.psm1",
    "modules\Crodip.Runtime.Compose.psm1",
    "commands\03-start.ps1",
    "commands\04-stop.ps1",
    "commands\05-status.ps1"
)) {
    if (-not (Test-Path -LiteralPath (Join-Path $root $relativePath))) {
        throw "Fichier absent : $relativePath"
    }
}

$dockerModule = Get-Content -LiteralPath (Join-Path $root "modules\Crodip.Runtime.Docker.psm1") -Raw
$composeModule = Get-Content -LiteralPath (Join-Path $root "modules\Crodip.Runtime.Compose.psm1") -Raw

foreach ($functionName in @(
    "Test-CrodipDockerEngine",
    "Start-CrodipDockerDesktop",
    "Get-CrodipFixedContainerStatus",
    "Get-CrodipDockerInventory",
    "Export-CrodipDockerReports"
)) {
    if ($dockerModule -notmatch "function\s+$functionName\b") {
        throw "Fonction Docker absente : $functionName"
    }
}

foreach ($functionName in @("Get-CrodipComposeFile", "Invoke-CrodipCompose")) {
    if ($composeModule -notmatch "function\s+$functionName\b") {
        throw "Fonction Compose absente : $functionName"
    }
}

Write-Host "[OK] Validation statique du Lot 4 Docker réussie." -ForegroundColor Green
