###############################################################
# CRODIP Runtime Manager
# Test     : tests\Test-Lot3-Formatting.ps1
# Version  : 2.2.1
###############################################################

$ErrorActionPreference = "Stop"

$modulePath = Join-Path `
    $PSScriptRoot `
    "..\modules\Crodip.Runtime.Health.psm1"

$content = Get-Content -LiteralPath $modulePath -Raw

if ($content -match '\.Add\(\s*"\[[^"]+"\s+-f\s*\r?\n') {
    throw "Formatage TXT risqué encore présent dans un appel Add()."
}

if ($content -match '\.Add\(\s*"\|[^"]+"\s+-f\s*\r?\n') {
    throw "Formatage Markdown risqué encore présent dans un appel Add()."
}

foreach ($required in @(
    '$formattedTextLine',
    '$formattedMarkdownLine',
    '-f @('
)) {
    if ($content -notmatch [regex]::Escape($required)) {
        throw "Correctif de formatage absent : $required"
    }
}

Write-Host `
    "[OK] Correctif de formatage du Lot 3 validé." `
    -ForegroundColor Green
