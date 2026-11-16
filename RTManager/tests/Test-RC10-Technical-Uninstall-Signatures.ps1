#Requires -Version 7.4
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$tech=Get-Content (Join-Path $root "commands\16-technical-components.ps1") -Raw
$provider=Get-Content (Join-Path $root "modules\Crodip.Runtime.DockerProvider.psm1") -Raw
$github=Get-Content (Join-Path $root "modules\Crodip.Runtime.GitHub.psm1") -Raw

# Functions without SupportsShouldProcess MUST NOT receive -Confirm.
foreach($fn in @(
 "Uninstall-CrodipDockerDesktop",
 "Uninstall-CrodipWslDistribution",
 "Disable-CrodipWslWindowsFeatures",
 "Uninstall-CrodipDockerWslStack"
)){
 if($tech -match ($fn + '[^\r\n]*-Confirm')){
   throw "RC10 : paramètre -Confirm invalide encore transmis à $fn."
 }
}

# Existing provider owns destructive confirmations.
foreach($token in @(
 "DESINSTALLER DOCKER",
 "SUPPRIMER $Distribution",
 "DESACTIVER WSL2",
 "DESINSTALLATION COMPLETE"
)){
 if($provider -notmatch [regex]::Escape($token)){ throw "Confirmation provider absente : $token" }
}

if($github -notmatch 'Get-CrodipGitHubCliExecutable'){throw "Détection robuste gh absente."}
if($github -notmatch [regex]::Escape('GitHub CLI\gh.exe')){throw "Chemin standard GitHub CLI non contrôlé."}
if($github -notmatch [regex]::Escape('"repos/$Repository/contents/${Path}?ref=$Ref"')){throw "Correctif GitHub RC9 perdu."}

Write-Host "[OK] RC10 : signatures de désinstallation + détection GitHub CLI."
