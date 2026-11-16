$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot

foreach ($f in @(
    "commands\11-docker-admin.ps1",
    "images\images-manifest.json",
    "modules\Crodip.Runtime.Docker.psm1"
)) {
    if (-not (Test-Path (Join-Path $root $f))) {
        throw "Absent : $f"
    }
}

$d = Get-Content `
    (Join-Path $root "modules\Crodip.Runtime.Docker.psm1") `
    -Raw

foreach ($fn in @(
    "Connect-CrodipRegistry",
    "Import-CrodipOfflineImages",
    "Start-CrodipRuntimeAuto",
    "Get-CrodipDeploymentMode"
)) {
    if ($d -notmatch "function\s+$fn\b") {
        throw "Fonction absente : $fn"
    }
}

Write-Host "[OK] Lot 4 AUTO GHCR validé statiquement." -ForegroundColor Green
