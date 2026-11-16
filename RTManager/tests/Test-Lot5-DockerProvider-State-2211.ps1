#Requires -Version 7.4

$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$ModuleRoot = Join-Path $Root "modules"
$ProviderPath = Join-Path $ModuleRoot "Crodip.Runtime.DockerProvider.psm1"

Import-Module `
    (Join-Path $ModuleRoot "Crodip.Runtime.Common.psm1") `
    -Force `
    -DisableNameChecking `
    -ErrorAction Stop

Import-Module `
    $ProviderPath `
    -Force `
    -Global `
    -DisableNameChecking `
    -ErrorAction Stop

$content = Get-Content -LiteralPath $ProviderPath -Raw

if ($content -match '\$script:lines') {
    throw "Régression : `$script:lines est encore présent dans DockerProvider."
}

foreach ($name in @(
    "Get-CrodipDockerProvider",
    "Set-CrodipDockerProvider",
    "Get-CrodipDockerProviderInfo"
)) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Commande Provider absente : $name"
    }
}

Write-Host "[OK] État du provider Docker - correctif 2.2.42 validé." -ForegroundColor Green
