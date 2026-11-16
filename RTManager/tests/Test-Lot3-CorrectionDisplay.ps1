###############################################################
# CRODIP Runtime Manager
# Test     : tests\Test-Lot3-CorrectionDisplay.ps1
# Version  : 2.2.1
###############################################################

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot

$healthPath = Join-Path `
    $root `
    "modules\Crodip.Runtime.Health.psm1"

$checkPath = Join-Path `
    $root `
    "commands\02-check.ps1"

$healthContent = Get-Content -LiteralPath $healthPath -Raw
$checkContent = Get-Content -LiteralPath $checkPath -Raw

if (
    $healthContent -notmatch
    '\$result\.Status\s+-ne\s+"OK"'
) {
    throw "Le filtrage des corrections dans les rapports est absent."
}

if (
    $checkContent -notmatch
    '\$result\.Status\s+-ne\s+"OK"'
) {
    throw "Le filtrage des corrections dans le dashboard est absent."
}

if (
    $healthContent -notmatch
    '-Correction\s+\$\(if\s*\(\$exists\)'
) {
    throw "Le champ Correction conditionnel est absent du module Health."
}

Write-Host `
    "[OK] Affichage conditionnel des corrections validé." `
    -ForegroundColor Green
