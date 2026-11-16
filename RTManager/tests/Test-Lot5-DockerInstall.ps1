#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot

Import-Module `
    (Join-Path $Root "modules\Crodip.Runtime.Common.psm1") `
    -Force `
    -DisableNameChecking

Import-Module `
    (Join-Path $Root "modules\Crodip.Runtime.Windows.psm1") `
    -Force `
    -DisableNameChecking

Import-Module `
    (Join-Path $Root "modules\Crodip.Runtime.DockerProvider.psm1") `
    -Force `
    -DisableNameChecking

foreach ($name in @(
    "Install-CrodipDockerDesktop",
    "Install-CrodipWslUbuntu",
    "Install-CrodipUbuntuDockerEngine",
    "Test-CrodipDockerDesktopInstalled",
    "Test-CrodipUbuntuDockerInstalled"
)) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Fonction d'installation absente : $name"
    }
}

$menu = Get-Content `
    (Join-Path $Root "commands\11-docker-admin.ps1") `
    -Raw

foreach ($text in @(
    "Installer Docker Desktop",
    "Installer / préparer WSL2 + Ubuntu",
    "Installer Docker Engine dans Ubuntu / WSL2"
)) {
    if ($menu -notmatch [regex]::Escape($text)) {
        throw "Option menu absente : $text"
    }
}

Write-Host `
    "[OK] Options d'installation Docker présentes." `
    -ForegroundColor Green
