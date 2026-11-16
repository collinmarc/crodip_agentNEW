#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$HealthPath = Join-Path $Root "modules\Crodip.Runtime.Health.psm1"
$CheckPath = Join-Path $Root "commands\02-check.ps1"

$health = Get-Content -LiteralPath $HealthPath -Raw
$check = Get-Content -LiteralPath $CheckPath -Raw

if ($check -match '\$checks\s*\+=') {
    throw "Régression : 02-check.ps1 utilise encore `$checks +=."
}

if ($check -match "Add-CrodipCheckResult") {
    throw "Régression : helper Add-CrodipCheckResult présent."
}

foreach ($name in @(
    "Architecture",
    "Virtualisation BIOS/UEFI",
    "Virtual Machine Platform",
    "WSL2"
)) {
    if ($health -notmatch [regex]::Escape("-Name `"$name`"")) {
        throw "Contrôle Health absent : $name"
    }
}

foreach ($path in @($HealthPath, $CheckPath)) {
    $tokens = $null
    $errors = $null

    [System.Management.Automation.Language.Parser]::ParseFile(
        $path,
        [ref]$tokens,
        [ref]$errors
    ) | Out-Null

    if ($errors.Count -gt 0) {
        throw "Erreur de parsing $path : $($errors.Message -join ' | ')"
    }
}

Write-Host "[OK] Health Preflight 2.2.42 intégré au dashboard." -ForegroundColor Green
