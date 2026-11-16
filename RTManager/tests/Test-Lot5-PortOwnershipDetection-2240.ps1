#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$Module=Join-Path $Root "modules\Crodip.Runtime.Compose.psm1"
$Start=Join-Path $Root "commands\03-start.ps1"

$m=Get-Content -LiteralPath $Module -Raw
$s=Get-Content -LiteralPath $Start -Raw

foreach($expected in @(
    "Get-CrodipDockerPublishedPortOwners",
    "Get-CrodipWindowsPortListeners",
    "OWNED_BY_CURRENT_RUNTIME",
    "CONFLICT_DOCKER",
    "CONFLICT_WINDOWS",
    "DOCKER_RELAY_ONLY",
    "wslrelay"
)){
    if($m -notmatch [regex]::Escape($expected)){
        throw "Élément Port Ownership absent : $expected"
    }
}

foreach($expected in @(
    "déjà utilisé par le service Runtime courant",
    "Conflit Docker sur le port",
    "Conflit Windows sur le port",
    "Relais Docker/WSL"
)){
    if($s -notmatch [regex]::Escape($expected)){
        throw "Rendu Port Ownership absent : $expected"
    }
}

Write-Host "[OK] Port Ownership Detection 2.2.42 validée." -ForegroundColor Green
