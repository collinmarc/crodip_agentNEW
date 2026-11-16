#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"

$root=Split-Path -Parent $PSScriptRoot
$module=Join-Path $root "modules\Crodip.Runtime.GitHub.psm1"
Import-Module $module -Force -DisableNameChecking -ErrorAction Stop

$required=@(
 "Get-CrodipGitHubCliExecutable",
 "Test-CrodipGitHubCli",
 "Install-CrodipGitHubCli",
 "Test-CrodipGitHubAuthentication",
 "Connect-CrodipGitHub",
 "Get-CrodipGitHubFile"
)

foreach($name in $required){
 $cmd=Get-Command $name -ErrorAction Stop
 if($cmd.CommandType -ne "Function"){
   throw "Contrat module invalide pour $name : $($cmd.CommandType)"
 }
 Write-Host "[OK] Export : $name"
}

# Invocation réelle du détecteur sous StrictMode.
$gh=Get-CrodipGitHubCliExecutable
if($gh){
 if(-not(Test-Path -LiteralPath $gh -PathType Leaf)){
   throw "gh.exe retourné mais introuvable : $gh"
 }
 Write-Host "[OK] GitHub CLI : $gh"
}else{
 Write-Host "[OK] GitHub CLI absent : détection sans erreur."
}

Write-Host "[OK] Contrat Crodip.Runtime.GitHub RC12 qualifié."
