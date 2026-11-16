###############################################################
# CRODIP Runtime Manager
# Test     : tests\Test-Lot4-Update.ps1
# Version  : historique 2.2.1
###############################################################

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$updatePath = Join-Path $root "commands\08-update.ps1"
$content = Get-Content -LiteralPath $updatePath -Raw

foreach ($required in @(
    "Crodip.Runtime.Compose.psm1",
    "Get-CrodipComposeFile",
    "Invoke-CrodipCompose",
    "06-backup.ps1",
    '-Mode "quick"',
    'Write-CrodipRuntimeHeader "08-update.ps1"'
)) {
    if ($content -notmatch [regex]::Escape($required)) {
        throw "Élément attendu absent : $required"
    }
}

if ($content -match "Find-CrodipComposeFile") {
    throw "Ancien nom de fonction encore présent."
}

Write-Host `
    "[OK] Mise à jour Lot 4 validée statiquement." `
    -ForegroundColor Green
