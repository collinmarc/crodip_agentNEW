#Requires -Version 7.4
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$gh=Get-Content (Join-Path $root "modules\Crodip.Runtime.GitHub.psm1") -Raw
$menu=Get-Content (Join-Path $root "bootstrap-runtime.ps1") -Raw
$tech=Get-Content (Join-Path $root "commands\16-technical-components.ps1") -Raw

if($gh -notmatch [regex]::Escape('"repos/$Repository/contents/${Path}?ref=$Ref"')){throw "Interpolation GitHub RC9 non corrigée."}
if($gh -match [regex]::Escape('"repos/$Repository/contents/$Path?ref=$Ref"')){throw "Interpolation RC8 encore présente."}
foreach($n in @("16. Composants techniques","17. Quitter")){
 if($menu -notmatch [regex]::Escape($n)){throw "Menu absent : $n"}
}
foreach($n in @("GitHub CLI","Désinstaller GitHub CLI","Désinstaller Docker Desktop","Désinstallation complète Docker + Ubuntu + WSL2","Saisir OUI")){
 if($tech -notmatch [regex]::Escape($n)){throw "Gestion composants incomplète : $n"}
}
Write-Host "[OK] RC9 : interpolation GitHub + cycle de vie composants techniques."
