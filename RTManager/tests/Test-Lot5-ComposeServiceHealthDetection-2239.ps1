#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$ComposeModule=Join-Path $Root "modules\Crodip.Runtime.Compose.psm1"
$Start=Join-Path $Root "commands\03-start.ps1"

$m=Get-Content -LiteralPath $ComposeModule -Raw
$s=Get-Content -LiteralPath $Start -Raw

foreach($expected in @(
    "Get-CrodipComposeServiceRuntimeStatus",
    "Get-CrodipComposeServiceStatusByName",
    "compose",
    "ps",
    "--format",
    "json",
    "RESTARTING",
    "UNHEALTHY",
    "EXITED"
)){
    if($m -notmatch [regex]::Escape($expected)){
        throw "Élément Compose Health absent : $expected"
    }
}

foreach($expected in @(
    "API Backend : Restarting",
    "Dernières lignes du journal Backend",
    "Runtime démarré avec services non opérationnels",
    "Lecture état services Compose"
)){
    if($s -notmatch [regex]::Escape($expected)){
        throw "Élément démarrage absent : $expected"
    }
}

if($s -match "Get-CrodipFixedContainerStatus"){
    throw "Ancienne détection par nom fixe encore présente dans 03-start.ps1."
}

Write-Host "[OK] Compose Service Health Detection 2.2.42 validée." -ForegroundColor Green
