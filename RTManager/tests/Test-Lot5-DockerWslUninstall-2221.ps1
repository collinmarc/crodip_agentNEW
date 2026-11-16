#Requires -Version 7.4
$ErrorActionPreference="Stop"
$Root=Split-Path -Parent $PSScriptRoot
$Provider=Join-Path $Root "modules\Crodip.Runtime.DockerProvider.psm1"
$Admin=Join-Path $Root "commands\11-docker-admin.ps1"

Import-Module $Provider -Force -Global -DisableNameChecking -ErrorAction Stop

foreach($name in @(
 "Uninstall-CrodipDockerDesktop",
 "Uninstall-CrodipWslDistribution",
 "Disable-CrodipWslWindowsFeatures",
 "Uninstall-CrodipDockerWslStack"
)){
 if(-not(Get-Command $name -ErrorAction SilentlyContinue)){throw "Fonction absente : $name"}
}

$content=Get-Content -LiteralPath $Admin -Raw
foreach($text in @(
 "15. Désinstaller Docker Desktop",
 "16. Supprimer Ubuntu / distribution WSL",
 "17. Désactiver les composants Windows WSL2",
 "18. Désinstallation complète Docker + Ubuntu + WSL2",
 "19. Retour"
)){
 if($content -notmatch [regex]::Escape($text)){throw "Option absente : $text"}
}

Write-Host "[OK] Désinstallation Docker / WSL2 2.2.42 intégrée." -ForegroundColor Green
