#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$ModuleRoot = Join-Path $Root "modules"

Import-Module `
    (Join-Path $ModuleRoot "Crodip.Runtime.DockerProvider.Loader.psm1") `
    -Force `
    -DisableNameChecking `
    -ErrorAction Stop

$module = Import-CrodipDockerProvider -ModuleRoot $ModuleRoot

foreach ($name in @(
    "Get-CrodipDockerProviderInfo",
    "Get-CrodipDockerProvider",
    "Set-CrodipDockerProvider",
    "Install-CrodipDockerDesktop",
    "Install-CrodipWslUbuntu",
    "Install-CrodipUbuntuDockerEngine"
)) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Commande non disponible : $name"
    }
}

Write-Host "[OK] Docker Provider chargé et fonctions exportées." -ForegroundColor Green
