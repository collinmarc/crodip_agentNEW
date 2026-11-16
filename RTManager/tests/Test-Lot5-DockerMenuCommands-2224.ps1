#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$ModuleRoot = Join-Path $Root "modules"
$Admin = Join-Path $Root "commands\11-docker-admin.ps1"

foreach ($m in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1"
)) {
    Import-Module `
        (Join-Path $ModuleRoot $m) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

$content = Get-Content -LiteralPath $Admin -Raw

if ($content -match "Write-CrodipInfo") {
    throw "Référence interdite restante : Write-CrodipInfo"
}

foreach ($name in @(
    "Write-CrodipStep",
    "Write-CrodipSuccess",
    "Write-CrodipWarning",
    "Write-CrodipError"
)) {
    if ($content -match [regex]::Escape($name)) {
        if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
            throw "Helper utilisé mais indisponible : $name"
        }
    }
}

$tokens = $null
$errors = $null

[System.Management.Automation.Language.Parser]::ParseFile(
    $Admin,
    [ref]$tokens,
    [ref]$errors
) | Out-Null

if ($errors.Count -gt 0) {
    throw "Erreur de parsing : $($errors.Message -join ' | ')"
}

Write-Host "[OK] Commandes du menu Docker 2.2.42 validées." -ForegroundColor Green
