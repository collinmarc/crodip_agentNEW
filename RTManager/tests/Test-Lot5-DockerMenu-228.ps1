#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot

$bootstrap = Join-Path $Root "bootstrap-runtime.ps1"
$admin = Join-Path $Root "commands\11-docker-admin.ps1"
$provider = Join-Path $Root "modules\Crodip.Runtime.DockerProvider.psm1"

foreach ($path in @($bootstrap, $admin, $provider)) {
    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) {
        throw "Fichier requis absent : $path"
    }
}

$adminContent = Get-Content -LiteralPath $admin -Raw
$bootContent = Get-Content -LiteralPath $bootstrap -Raw

if ($adminContent -match "DockerProvider\.Loader") {
    throw "Le menu Docker utilise encore le Loader."
}

if ($adminContent -notmatch "Crodip\.Runtime\.DockerProvider\.psm1") {
    throw "Le menu Docker n'importe pas directement DockerProvider."
}

if ($bootContent -notmatch 'commands\\11-docker-admin\.ps1') {
    throw "Le choix 10 ne référence pas 11-docker-admin.ps1."
}

Import-Module `
    (Join-Path $Root "modules\Crodip.Runtime.Common.psm1") `
    -Force `
    -DisableNameChecking `
    -ErrorAction Stop

Import-Module `
    $provider `
    -Force `
    -Global `
    -DisableNameChecking `
    -ErrorAction Stop

foreach ($name in @(
    "Get-CrodipDockerProviderInfo",
    "Install-CrodipDockerDesktop",
    "Install-CrodipUbuntuDockerEngine"
)) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Commande provider invisible : $name"
    }
}

Write-Host "[OK] Choix 10 et import direct Docker Provider validés." -ForegroundColor Green
