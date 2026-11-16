#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$module=Join-Path $root "modules\Crodip.Runtime.DockerProvider.psm1"
$text=Get-Content $module -Raw

$required=@(
 "TimeoutSeconds = 900",
 "Start-Process",
 "RedirectStandardOutput",
 "RedirectStandardError",
 "--disable-interactivity",
 "--verbose-logs",
 "[EN COURS] Winget / Docker Desktop",
 "Get-Process winget",
 "Stop-Process -Id",
 "winget-docker-",
 "Winget terminé"
)
foreach($token in $required){
 if($text -notmatch [regex]::Escape($token)){throw "RC14 : supervision Winget absente : $token"}
 Write-Host "[OK] $token"
}

Import-Module $module -Force -DisableNameChecking -ErrorAction Stop
$cmd=Get-Command Install-CrodipDockerDesktop -ErrorAction Stop
if(-not $cmd.Parameters.ContainsKey("TimeoutSeconds")){
 throw "RC14 : TimeoutSeconds non exposé par Install-CrodipDockerDesktop."
}
if(-not $cmd.Parameters.ContainsKey("Confirm")){
 throw "RC14 : contrat ShouldProcess/Confirm perdu."
}
Write-Host "[OK] Contrat Install-CrodipDockerDesktop RC14."
