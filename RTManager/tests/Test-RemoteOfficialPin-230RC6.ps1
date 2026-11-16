#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$command = Get-Content (Join-Path $root "commands\14-update-test-release.ps1") -Raw
$config = Get-Content (Join-Path $root "config\runtime.json") -Raw | ConvertFrom-Json

if($command -match [regex]::Escape('C:\Dev\crodip-saas\config\official-release-pin.json')){
    throw "RC6 ne doit plus dépendre du workspace DEV."
}

foreach($needle in @(
    'officialPinUrl',
    'incomingPinPath',
    'cachedPinPath',
    'Invoke-WebRequest',
    'GITHUB_TOKEN',
    'RELEASE READY FOR TEST',
    'images.localBackend',
    'images.centralFrontend'
)){
    if($command -notmatch [regex]::Escape($needle)){
        throw "RC6 incomplet : $needle"
    }
}

if($config.releaseUpdate.sourceMode -ne "remote-first"){
    throw "releaseUpdate.sourceMode doit être remote-first."
}

if($config.releaseUpdate.incomingPinPath -notmatch '^C:\\ProgramData\\CRODIP\\'){
    throw "Le pin incoming doit être sous ProgramData."
}

Write-Host "[OK] RC6 : Runtime autonome / pin officiel distant conforme."
