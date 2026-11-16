#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
Import-Module (Join-Path $root "modules\Crodip.Runtime.GitHub.psm1") -Force -DisableNameChecking
do {
 Clear-Host
 Write-Host "============================================================" -ForegroundColor Cyan
 Write-Host " GITHUB CLI / AUTHENTIFICATION" -ForegroundColor Cyan
 Write-Host "============================================================" -ForegroundColor Cyan
 $installed=Test-CrodipGitHubCli
 $auth=if($installed){Test-CrodipGitHubAuthentication}else{$false}
 Write-Host "GitHub CLI      : $(if($installed){'INSTALLÉ'}else{'ABSENT'})"
 Write-Host "Authentification: $(if($auth){'OK'}else{'NON CONNECTÉ'})"
 Write-Host ""
 Write-Host "1. Installer GitHub CLI"
 Write-Host "2. Vérifier la version"
 Write-Host "3. Vérifier l'authentification"
 Write-Host "4. Se connecter à GitHub"
 Write-Host "5. Se déconnecter de GitHub"
 Write-Host "6. Tester l'accès au pin officiel"
 Write-Host "7. Retour"
 $c=Read-Host "Choix"
 switch($c){
  "1"{$null=Install-CrodipGitHubCli}
  "2"{if(Test-CrodipGitHubCli){& (Get-CrodipGitHubCliExecutable) --version}}
  "3"{if(Test-CrodipGitHubCli){& (Get-CrodipGitHubCliExecutable) auth status --hostname github.com}}
  "4"{if(-not(Test-CrodipGitHubCli)){$null=Install-CrodipGitHubCli}; if(Test-CrodipGitHubCli){$null=Connect-CrodipGitHub}}
  "5"{if(Test-CrodipGitHubCli){& (Get-CrodipGitHubCliExecutable) auth logout --hostname github.com}}
  "6"{
    $cfg=Get-Content (Join-Path $root "config\runtime.json") -Raw|ConvertFrom-Json
    if(Test-CrodipGitHubAuthentication){
      $tmp=Join-Path $env:TEMP "crodip-pin-test.json"
      try { Get-CrodipGitHubFile -Repository $cfg.releaseUpdate.githubRepository -Path $cfg.releaseUpdate.githubPinPath -Ref $cfg.releaseUpdate.githubBranch -Destination $tmp|Out-Null; Get-Content $tmp }
      catch { Write-Host "[ERREUR] $($_.Exception.Message)" -ForegroundColor Red }
      Remove-Item $tmp -Force -ErrorAction SilentlyContinue
    } else { Write-Host "[ATTENTION] GitHub non authentifié." -ForegroundColor Yellow }
  }
  "7"{return}
 }
 if($c -ne "7"){Read-Host "Entrée pour continuer"|Out-Null}
}while($true)
