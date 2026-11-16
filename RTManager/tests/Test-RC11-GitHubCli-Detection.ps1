#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$modulePath=Join-Path $root "modules\Crodip.Runtime.GitHub.psm1"
Import-Module $modulePath -Force -DisableNameChecking
$detected=Get-CrodipGitHubCliExecutable
if($detected -and -not(Test-Path -LiteralPath $detected -PathType Leaf)){
 throw "Exécutable GitHub CLI retourné mais introuvable : $detected"
}
Write-Host "[OK] Détection GitHub CLI terminée sans erreur StrictMode."
if($detected){Write-Host "[OK] gh.exe : $detected"}else{Write-Host "[OK] gh.exe absent."}
