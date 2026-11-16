#Requires -Version 7.4
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$provider=Join-Path $root "modules\Crodip.Runtime.DockerProvider.psm1"
if(-not(Test-Path $provider)){throw "Module DockerProvider absent."}
Import-Module (Join-Path $root "modules\Crodip.Runtime.Common.psm1") -Force
Import-Module $provider -Force
foreach($f in @("Get-CrodipDockerProvider","Set-CrodipDockerProvider","Invoke-CrodipDockerCli","Get-CrodipDockerProviderInfo")){
 if(-not(Get-Command $f -ErrorAction SilentlyContinue)){throw "Fonction absente : $f"}
}
$envExample=Get-Content (Join-Path $root "templates\.env.example") -Raw
if($envExample -notmatch "CRODIP_DOCKER_PROVIDER"){throw "Variable provider absente du .env.example"}
Write-Host "[OK] Lot 5 Docker Provider - structure valide." -ForegroundColor Green
