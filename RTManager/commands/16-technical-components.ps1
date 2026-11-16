###############################################################
# CRODIP Runtime Manager
# Script   : commands\16-technical-components.ps1
# Version  : 2.3.0-RC17
###############################################################
#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"

$root=Split-Path -Parent $PSScriptRoot
foreach($m in @(
 "Crodip.Runtime.Common.psm1",
 "Crodip.Runtime.Windows.psm1",
 "Crodip.Runtime.GitHub.psm1",
 "Crodip.Runtime.DockerProvider.psm1"
)){
 Import-Module (Join-Path $root "modules\$m") -Force -DisableNameChecking -ErrorAction Stop
}

function Confirm-TechnicalRemoval {
 param([string]$Name,[string]$Warning)
 Write-Host ""
 Write-Host "ATTENTION — DÉSINSTALLATION : $Name" -ForegroundColor Red
 if($Warning){ Write-Host $Warning -ForegroundColor Yellow }
 $answer=Read-Host "Confirmer la désinstallation ? Saisir OUI"
 return $answer -ceq "OUI"
}

function Uninstall-CrodipGitHubCliManaged {
 if(-not(Test-CrodipGitHubCli)){ Write-Host "[ABSENT] GitHub CLI"; return }
 if(-not(Confirm-TechnicalRemoval "GitHub CLI" "Les fonctions de mise à jour depuis le dépôt privé seront indisponibles.")){ return }
 $ghExe=Get-CrodipGitHubCliExecutable
 if($ghExe){
   try { & $ghExe auth logout --hostname github.com 2>$null } catch {}
 }
 & winget uninstall --id GitHub.cli --exact --source winget --accept-source-agreements
 if($LASTEXITCODE -eq 0){ Write-Host "[OK] GitHub CLI désinstallé." -ForegroundColor Green }
 else { Write-Host "[ERREUR] Désinstallation GitHub CLI en échec." -ForegroundColor Red }
}

do{
 Clear-Host
 Write-Host "============================================================" -ForegroundColor Cyan
 Write-Host " COMPOSANTS TECHNIQUES — INSTALLATION / DÉSINSTALLATION" -ForegroundColor Cyan
 Write-Host "============================================================" -ForegroundColor Cyan
 Write-Host ""
 $ghExecutable=Get-CrodipGitHubCliExecutable
 Write-Host "GitHub CLI    : $(if($ghExecutable){'INSTALLÉ'}else{'ABSENT'})"
 if($ghExecutable){ Write-Host "gh.exe        : $ghExecutable" }
 $dockerExecutable=Get-CrodipDockerCliExecutable
 Write-Host "Docker CLI    : $(if($dockerExecutable){'INSTALLÉ'}else{'ABSENT'})"
 if($dockerExecutable){ Write-Host "docker.exe    : $dockerExecutable" }
 Write-Host ""
 Write-Host "--- GitHub CLI ----------------------------------"
 Write-Host "1. Installer / réparer GitHub CLI"
 Write-Host "2. Désinstaller GitHub CLI"
 Write-Host ""
 Write-Host "--- Docker / WSL2 -------------------------------"
 Write-Host "3. Installer Docker Desktop"
 Write-Host "4. Désinstaller Docker Desktop"
 Write-Host "5. Installer / préparer WSL2 + Ubuntu"
 Write-Host "6. Supprimer Ubuntu / distribution WSL"
 Write-Host "7. Désactiver les composants Windows WSL2"
 Write-Host "8. Désinstallation complète Docker + Ubuntu + WSL2"
 Write-Host ""
 Write-Host "--- Maintenance ---------------------------------"
 Write-Host "9. Ouvrir l'administration Docker complète"
 Write-Host "10. Retour"
 Write-Host ""
 $c=Read-Host "Choix"
 try{
  switch($c){
   "1"{ $null=Install-CrodipGitHubCli }
   "2"{ Uninstall-CrodipGitHubCliManaged }
   "3"{ $null=Install-CrodipDockerDesktop -Confirm:$false }
   "4"{ Uninstall-CrodipDockerDesktop }
   "5"{ $null=Install-CrodipWsl2Prerequisite -InstallIfMissing }
   "6"{
      $dist=Read-Host "Nom exact de la distribution WSL à supprimer"
      if($dist){ Uninstall-CrodipWslDistribution -Distribution $dist }
   }
   "7"{ Disable-CrodipWslWindowsFeatures }
   "8"{ Uninstall-CrodipDockerWslStack }
   "9"{ & (Join-Path $root "commands\11-docker-admin.ps1") }
   "10"{ return }
  }
 }catch{ Write-Host "[ERREUR] $($_.Exception.Message)" -ForegroundColor Red }
 if($c -ne "10"){ Read-Host "Entrée pour continuer"|Out-Null }
}while($true)
