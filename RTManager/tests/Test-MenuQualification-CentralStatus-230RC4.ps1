#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$bootstrap = Get-Content (Join-Path $root "bootstrap-runtime.ps1") -Raw
$central = Get-Content (Join-Path $root "commands\12-central-runtime.ps1") -Raw

foreach($needle in @(
    '6. Qualification technique Runtime',
    '17. Quitter',
    'commands\13-qualify-runtime.ps1'
)){
    if($bootstrap -notmatch [regex]::Escape($needle)){
        throw "Menu principal incomplet : $needle"
    }
}

foreach($needle in @(
    'ÉTAT DU RUNTIME CENTRAL',
    'docker inspect --format "{{.Config.Image}}"',
    'Backend /health',
    'Backend /docs',
    'Frontend /',
    'RUNTIME CENTRAL TECHNICALLY OPERATIONAL'
)){
    if($central -notmatch [regex]::Escape($needle)){
        throw "Page état CENTRAL incomplète : $needle"
    }
}

Write-Host "[OK] RC4 : menu qualification et page état CENTRAL conformes."
