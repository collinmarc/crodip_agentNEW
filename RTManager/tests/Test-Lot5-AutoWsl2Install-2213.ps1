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

if (-not (Get-Command Ensure-CrodipWsl2Prerequisite -ErrorAction SilentlyContinue)) {
    throw "Ensure-CrodipWsl2Prerequisite absent."
}

$start = Get-Content `
    (Join-Path $Root "commands\03-start.ps1") `
    -Raw

$install = Get-Content `
    (Join-Path $Root "commands\01-install.ps1") `
    -Raw

foreach ($content in @($start, $install)) {
    if ($content -notmatch "Ensure-CrodipWsl2Prerequisite") {
        throw "Installation automatique WSL2 non intégrée."
    }

    if ($content -notmatch "InstallIfMissing") {
        throw "Option InstallIfMissing absente."
    }
}

Write-Host "[OK] Installation automatique WSL2 intégrée au Runtime." -ForegroundColor Green
