#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$ModuleRoot = Join-Path $Root "modules"

Import-Module `
    (Join-Path $ModuleRoot "Crodip.Runtime.DockerProvider.Loader.psm1") `
    -Force `
    -DisableNameChecking `
    -ErrorAction Stop

$null = Import-CrodipDockerProvider -ModuleRoot $ModuleRoot

foreach ($Name in @(
    "Get-CrodipDockerProviderInfo",
    "Get-CrodipDockerProvider",
    "Set-CrodipDockerProvider",
    "Install-CrodipDockerDesktop",
    "Install-CrodipWslUbuntu",
    "Install-CrodipUbuntuDockerEngine"
)) {
    $cmd = Get-Command $Name -ErrorAction SilentlyContinue

    if (-not $cmd) {
        throw "Commande non visible dans le scope appelant : $Name"
    }

    Write-Host "[OK] $Name" -ForegroundColor Green
}

Write-Host ""
Write-Host "[OK] Scope Docker Provider validé." -ForegroundColor Green
