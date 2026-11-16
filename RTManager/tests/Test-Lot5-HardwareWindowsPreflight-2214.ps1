#Requires -Version 7.4
$ErrorActionPreference = "Stop"
$Root = Split-Path -Parent $PSScriptRoot
$Module = Join-Path $Root "modules\Crodip.Runtime.Preflight.psm1"

Import-Module $Module -Force -DisableNameChecking -ErrorAction Stop

foreach ($name in @(
    "Get-CrodipHardwareWindowsPreflight",
    "Show-CrodipHardwareWindowsPreflight",
    "Assert-CrodipHardwareWindowsPreflight"
)) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Commande preflight absente : $name"
    }
}

$r = Get-CrodipHardwareWindowsPreflight
if ($null -eq $r.Architecture64Bit) { throw "Architecture non qualifiée." }
if ($null -eq $r.FirmwareVirtualizationEnabled) { throw "Virtualisation firmware non qualifiée." }

foreach ($script in @("01-install.ps1","03-start.ps1")) {
    $content=Get-Content (Join-Path $Root "commands\$script") -Raw
    if ($content -notmatch "Assert-CrodipHardwareWindowsPreflight") {
        throw "Preflight bloquant absent de $script"
    }
}

Write-Host "[OK] Preflight matériel / Windows 2.2.42 validé." -ForegroundColor Green
