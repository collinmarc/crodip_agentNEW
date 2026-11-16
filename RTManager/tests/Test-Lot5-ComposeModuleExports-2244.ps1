$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$module=Join-Path $root "modules\Crodip.Runtime.Compose.psm1"

Remove-Module Crodip.Runtime.Compose -Force -ErrorAction SilentlyContinue
Import-Module $module -Force -DisableNameChecking -ErrorAction Stop

foreach($command in @(
    "Get-CrodipComposeFile",
    "Invoke-CrodipCompose",
    "Repair-CrodipRuntimeComposeIsolation",
    "Test-CrodipRuntimePortAvailability",
    "Get-CrodipComposeServiceRuntimeStatus",
    "Get-CrodipComposeServiceStatusByName"
)){
    if(-not (Get-Command $command -ErrorAction SilentlyContinue)){
        throw "Commande non exportée : $command"
    }
}

$normalize=Get-Content (Join-Path $root "commands\01-normalize-compose.ps1") -Raw
if($normalize -notmatch "Get-CrodipComposeFile"){
    throw "01-normalize-compose.ps1 n'utilise plus Get-CrodipComposeFile."
}

Write-Host "[OK] Exports Compose requis présents."
