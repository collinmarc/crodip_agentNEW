#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$ModuleRoot = Join-Path $Root "modules"

foreach ($name in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1"
)) {
    Import-Module `
        (Join-Path $ModuleRoot $name) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

$providerPath = Join-Path $ModuleRoot "Crodip.Runtime.DockerProvider.psm1"

Import-Module `
    $providerPath `
    -Force `
    -Global `
    -DisableNameChecking `
    -ErrorAction Stop

$required = @(
    "Get-CrodipDockerProviderInfo",
    "Get-CrodipDockerProvider",
    "Set-CrodipDockerProvider",
    "Install-CrodipDockerDesktop",
    "Install-CrodipWslUbuntu",
    "Install-CrodipUbuntuDockerEngine"
)

foreach ($name in $required) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Avant Docker/Compose, commande absente : $name"
    }
}

foreach ($name in @(
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Compose.psm1"
)) {
    Import-Module `
        (Join-Path $ModuleRoot $name) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

foreach ($name in $required) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Après Docker/Compose, commande provider perdue : $name"
    }
}

Write-Host "[OK] Docker Provider reste visible après Docker/Compose." -ForegroundColor Green
