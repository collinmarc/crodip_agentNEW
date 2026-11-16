#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$DockerModule = Join-Path $Root "modules\Crodip.Runtime.Docker.psm1"
$UpdateScript = Join-Path $Root "commands\08-update.ps1"

Import-Module `
    (Join-Path $Root "modules\Crodip.Runtime.Common.psm1") `
    -Force -DisableNameChecking -ErrorAction Stop

Import-Module `
    (Join-Path $Root "modules\Crodip.Runtime.DockerProvider.psm1") `
    -Force -Global -DisableNameChecking -ErrorAction Stop

Import-Module `
    $DockerModule `
    -Force -DisableNameChecking -ErrorAction Stop

foreach ($name in @(
    "Test-CrodipDockerImageLocal",
    "Get-CrodipDockerPullFailureKind"
)) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Helper Docker absent : $name"
    }
}

if ((Get-CrodipDockerPullFailureKind -Output @("manifest unknown: not found")) -ne "NOT_FOUND") {
    throw "Classification NOT_FOUND incorrecte."
}

if ((Get-CrodipDockerPullFailureKind -Output @("unauthorized: denied")) -ne "AUTH") {
    throw "Classification AUTH incorrecte."
}

$content = Get-Content -LiteralPath $UpdateScript -Raw

foreach ($expected in @(
    "Mode AUTO : poursuite avec les images locales.",
    "Test-CrodipDockerImageLocal",
    "Import-CrodipOfflineImages"
)) {
    if ($content -notmatch [regex]::Escape($expected)) {
        throw "Fallback update absent : $expected"
    }
}

Write-Host "[OK] Fallback de mise à jour Docker 2.2.42 validé." -ForegroundColor Green
