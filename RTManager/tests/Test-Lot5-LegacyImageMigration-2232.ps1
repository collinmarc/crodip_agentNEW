#Requires -Version 7.4
$ErrorActionPreference="Stop"
$Root=Split-Path -Parent $PSScriptRoot
$Module=Join-Path $Root "modules\Crodip.Runtime.Docker.psm1"

Import-Module $Module -Force -DisableNameChecking -ErrorAction Stop

foreach($fn in @(
 "Get-CrodipPackagedImagesManifest",
 "Get-CrodipExpectedImageForService",
 "Test-CrodipLegacyImageReference",
 "Repair-CrodipLegacyImageConfiguration"
)){
 if(-not(Get-Command $fn -ErrorAction SilentlyContinue)){
  throw "Fonction migration absente : $fn"
 }
}

if(-not(Test-CrodipLegacyImageReference -Image "idwebconcept/crodip-backend:2.1.0")){
 throw "Image legacy backend non détectée."
}
if(Test-CrodipLegacyImageReference -Image "ghcr.io/idwebconcept/crodip-backend:2.2.1"){
 throw "Image GHCR moderne détectée à tort comme legacy."
}

$content=Get-Content -LiteralPath $Module -Raw
foreach($expected in @(
 "Migrer maintenant la configuration des images vers GHCR ? [O/n]",
 "CRODIP_BACKEND_IMAGE",
 "CRODIP_FRONTEND_IMAGE",
 "before-ghcr-",
 "Relecture de la configuration Compose après migration GHCR"
)){
 if($content -notmatch [regex]::Escape($expected)){
  throw "Élément migration absent : $expected"
 }
}

$tokens=$null;$errors=$null
[System.Management.Automation.Language.Parser]::ParseFile($Module,[ref]$tokens,[ref]$errors)|Out-Null
if($errors.Count){throw "Parsing : $($errors.Message -join ' | ')"}

Write-Host "[OK] Legacy Image Migration 2.2.42 validée." -ForegroundColor Green
