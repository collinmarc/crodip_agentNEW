#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$Status=Join-Path $Root "commands\05-status.ps1"

$s=Get-Content -LiteralPath $Status -Raw

foreach($expected in @(
    "Get-CrodipComposeServiceRuntimeStatus",
    "NormalizedState",
    "ContainerName",
    "ExitCode",
    "Tous les services Runtime sont opérationnels"
)){
    if($s -notmatch [regex]::Escape($expected)){
        throw "Élément status absent : $expected"
    }
}

if($s -match "Get-CrodipFixedContainerStatus"){
    throw "Ancienne détection par nom fixe encore présente."
}

Write-Host "[OK] Status Compose Object Fix 2.2.42 validé." -ForegroundColor Green
