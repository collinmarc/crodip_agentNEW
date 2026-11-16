#Requires -Version 7.4
$ErrorActionPreference="Stop"
$Root=Split-Path -Parent $PSScriptRoot
$u=Get-Content (Join-Path $Root "commands\08-update.ps1") -Raw
$d=Get-Content (Join-Path $Root "modules\Crodip.Runtime.Docker.psm1") -Raw
foreach($fn in @("Get-CrodipComposeServices","Get-CrodipComposeServiceImage")){
 if($d -notmatch [regex]::Escape("function $fn")){throw "Fonction absente : $fn"}
}
if($u -notmatch "Get-CrodipComposeServices"){throw "Découverte dynamique absente"}
foreach($x in @('Name  = "frontend"','Name  = "backend"','Name  = "postgres"')){
 if($u -match [regex]::Escape($x)){throw "Service codé en dur : $x"}
}
Write-Host "[OK] Découverte dynamique Compose 2.2.42 validée." -ForegroundColor Green
