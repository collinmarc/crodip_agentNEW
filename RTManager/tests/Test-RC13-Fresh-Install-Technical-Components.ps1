#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$install=Get-Content (Join-Path $root "commands\01-install.ps1") -Raw

$required=@(
 "Crodip.Runtime.DockerProvider.psm1",
 "Ensure-CrodipWsl2Prerequisite",
 "Test-CrodipDockerDesktopInstalled",
 "Install-CrodipDockerDesktop",
 "Test-CrodipDockerDesktopReadiness",
 "Docker Desktop.exe",
 'Invoke-CrodipDockerCli -Arguments @("--version")',
 'Invoke-CrodipDockerCli -Arguments @("compose","version")',
 'Invoke-CrodipDockerCli -Arguments @("info","--format","{{.ServerVersion}}")',
 "Test-CrodipGitHubCli",
 "Install-CrodipGitHubCli"
)
foreach($token in $required){
 if($install -notmatch [regex]::Escape($token)){throw "RC13 : élément Fresh Install absent : $token"}
 Write-Host "[OK] $token"
}

# Docker Desktop doit être installé seulement lorsqu'il est absent.
if($install -notmatch 'if \(-not \(Test-CrodipDockerDesktopInstalled\)\)'){
 throw "RC13 : garde idempotente Docker Desktop absente."
}

# L'installation Docker ne doit pas recevoir de paramètre invalide ; Install supporte ShouldProcess/Confirm.
$provider=Get-Content (Join-Path $root "modules\Crodip.Runtime.DockerProvider.psm1") -Raw
if($provider -notmatch 'function Install-CrodipDockerDesktop[\s\S]*?SupportsShouldProcess=\$true'){
 throw "RC13 : contrat ShouldProcess Docker Desktop absent."
}

Write-Host "[OK] RC13 : contrat Fresh Install WSL2 + Docker Desktop + GitHub CLI."
