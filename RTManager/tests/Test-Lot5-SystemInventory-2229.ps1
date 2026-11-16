#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$Module=Join-Path $Root "modules\Crodip.Runtime.SystemInfo.psm1"
$Command=Join-Path $Root "commands\12-system-info.ps1"
$Bootstrap=Join-Path $Root "bootstrap-runtime.ps1"

Import-Module $Module -Force -DisableNameChecking -ErrorAction Stop

foreach($fn in @("Get-CrodipSystemInventory","Export-CrodipSystemInventory")){
    if(-not(Get-Command $fn -ErrorAction SilentlyContinue)){
        throw "Fonction inventaire absente : $fn"
    }
}

$inventory=Get-CrodipSystemInventory

foreach($prop in @("Computer","OperatingSystem","Firmware","Processor","Memory","Disks","Virtualization","Network","PowerShell")){
    if(-not($inventory.PSObject.Properties.Name -contains $prop)){
        throw "Propriété inventaire absente : $prop"
    }
}

$boot=Get-Content -LiteralPath $Bootstrap -Raw
if($boot -notmatch "Informations système"){throw "Menu Informations système absent."}
if($boot -notmatch "12-system-info.ps1"){throw "Commande système non câblée au menu."}

foreach($path in @($Module,$Command,$Bootstrap)){
    $tokens=$null;$errors=$null
    [System.Management.Automation.Language.Parser]::ParseFile($path,[ref]$tokens,[ref]$errors)|Out-Null
    if($errors.Count){throw "Parsing $path : $($errors.Message -join ' | ')"}
}

Write-Host "[OK] System Inventory 2.2.42 validé." -ForegroundColor Green
