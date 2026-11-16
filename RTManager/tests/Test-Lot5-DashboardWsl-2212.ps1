#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$CheckPath = Join-Path $Root "commands\02-check.ps1"

$content = Get-Content -LiteralPath $CheckPath -Raw

if ($content -match "Add-CrodipCheckResult") {
    throw "Ancien helper Add-CrodipCheckResult encore présent."
}

if ($content -notmatch '\$checks\s*\+=\s*\[pscustomobject\]') {
    throw "Le contrôle WSL2 n'utilise pas la structure native du dashboard."
}

$tokens = $null
$errors = $null

[System.Management.Automation.Language.Parser]::ParseFile(
    $CheckPath,
    [ref]$tokens,
    [ref]$errors
) | Out-Null

if ($errors.Count -gt 0) {
    throw "Erreur de parsing 02-check.ps1 : $($errors.Message -join ' | ')"
}

Write-Host "[OK] Dashboard WSL2 - correctif 2.2.42 validé." -ForegroundColor Green
