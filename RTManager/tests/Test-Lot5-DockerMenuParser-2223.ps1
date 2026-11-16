#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root = Split-Path -Parent $PSScriptRoot
$Admin = Join-Path $Root "commands\11-docker-admin.ps1"

$tokens = $null
$errors = $null

[System.Management.Automation.Language.Parser]::ParseFile(
    $Admin,
    [ref]$tokens,
    [ref]$errors
) | Out-Null

if ($errors.Count -gt 0) {
    throw "Erreurs de parsing : $($errors.Message -join ' | ')"
}

$content = Get-Content -LiteralPath $Admin -Raw

foreach ($choice in 1..19) {
    if ($content -notmatch [regex]::Escape("`"$choice`" {")) {
        throw "Choix switch absent : $choice"
    }
}

Write-Host "[OK] Menu Administration Docker 2.2.42 parse correctement." -ForegroundColor Green
