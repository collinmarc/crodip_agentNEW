#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$ProviderModule = Join-Path $Root "modules\Crodip.Runtime.DockerProvider.psm1"

if (-not (Test-Path -LiteralPath $ProviderModule)) {
    throw "Module DockerProvider absent."
}

Import-Module (Join-Path $Root "modules\Crodip.Runtime.Common.psm1") -Force -DisableNameChecking
Import-Module (Join-Path $Root "modules\Crodip.Runtime.Windows.psm1") -Force -DisableNameChecking
Import-Module $ProviderModule -Force -DisableNameChecking

foreach ($Function in @(
    "Get-CrodipDockerProviderInfo",
    "Get-CrodipDockerProvider",
    "Set-CrodipDockerProvider",
    "Invoke-CrodipDockerCli",
    "Start-CrodipUbuntuDockerEngine"
)) {
    if (-not (Get-Command $Function -ErrorAction SilentlyContinue)) {
        throw "Fonction provider absente : $Function"
    }
}

$StartScript = Join-Path $Root "commands\03-start.ps1"
$StartContent = Get-Content -LiteralPath $StartScript -Raw

if ($StartContent -notmatch "Crodip\.Runtime\.DockerProvider\.psm1") {
    throw "03-start.ps1 n'importe pas DockerProvider."
}

Write-Host "[OK] Import DockerProvider validé dans le Runtime." -ForegroundColor Green
