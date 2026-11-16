#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$bootstrap = Get-Content (Join-Path $root "bootstrap-runtime.ps1") -Raw
$command = Get-Content (Join-Path $root "commands\14-update-test-release.ps1") -Raw
$config = Get-Content (Join-Path $root "config\runtime.json") -Raw | ConvertFrom-Json

foreach($needle in @(
    '14. Mettre à jour la release TEST',
    '15. Quitter',
    'commands\14-update-test-release.ps1'
)){
    if($bootstrap -notmatch [regex]::Escape($needle)){
        throw "Menu RC5 incomplet : $needle"
    }
}

foreach($needle in @(
    'official-release-pin.json',
    'docker pull',
    'release-history',
    'Set-CrodipRuntimeImageEnvironment',
    '12-central-runtime.ps1',
    '13-qualify-runtime.ps1',
    'UPDATE-TEST'
)){
    if($command -notmatch [regex]::Escape($needle)){
        throw "Commande RC5 incomplète : $needle"
    }
}

if(-not $config.releaseUpdate.enabled){
    throw "releaseUpdate.enabled doit être true."
}

if($config.releaseUpdate.preserveCentralPostgresVolume -ne $true){
    throw "Le volume PostgreSQL CENTRAL doit être explicitement conservé."
}

Write-Host "[OK] RC5 : mise à jour release TEST conforme."
