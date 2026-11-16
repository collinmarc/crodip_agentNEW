#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$ModuleRoot = Join-Path $Root "modules"

Import-Module `
    (Join-Path $ModuleRoot "Crodip.Runtime.Common.psm1") `
    -Force -DisableNameChecking -ErrorAction Stop

Import-Module `
    (Join-Path $ModuleRoot "Crodip.Runtime.DockerProvider.psm1") `
    -Force -Global -DisableNameChecking -ErrorAction Stop

foreach ($name in @(
    "Get-CrodipWslStatus",
    "Install-CrodipWsl2Prerequisite",
    "Test-CrodipDockerDesktopReadiness",
    "Assert-CrodipDockerDesktopReady"
)) {
    if (-not (Get-Command $name -ErrorAction SilentlyContinue)) {
        throw "Commande WSL/Docker readiness absente : $name"
    }
}

$start = Get-Content `
    (Join-Path $Root "commands\03-start.ps1") `
    -Raw

foreach ($expected in @(
    "WSL2 n'est pas installé.",
    "Docker Desktop est installé, mais le moteur Linux ne répond pas.",
    "Assert-CrodipDockerDesktopReady"
)) {
    if ($start -notmatch [regex]::Escape($expected)) {
        throw "Contrôle de readiness absent : $expected"
    }
}

Write-Host "[OK] WSL2 / Docker Desktop readiness validé." -ForegroundColor Green
