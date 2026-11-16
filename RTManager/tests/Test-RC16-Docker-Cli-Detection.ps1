#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$module=Join-Path $root "modules\Crodip.Runtime.DockerProvider.psm1"
Import-Module $module -Force -DisableNameChecking -ErrorAction Stop

foreach($name in "Get-CrodipDockerCliExecutable","Update-CrodipDockerCliPath","Test-CrodipDockerCli","Invoke-CrodipDockerCli"){
    Get-Command $name -ErrorAction Stop | Out-Null
    Write-Host "[OK] Export : $name"
}

$text=Get-Content $module -Raw
$required=@(
    'Docker\Docker\resources\bin\docker.exe',
    'Get-Command docker.exe',
    '$dockerExe = Get-CrodipDockerCliExecutable',
    '& $dockerExe @Arguments'
)
foreach($token in $required){
    if($text -notmatch [regex]::Escape($token)){throw "RC16 : contrat absent : $token"}
    Write-Host "[OK] $token"
}

$menu=Get-Content (Join-Path $root "commands\16-technical-components.ps1") -Raw
if($menu -notmatch [regex]::Escape('$dockerExecutable=Get-CrodipDockerCliExecutable')){
    throw "RC16 : menu composants techniques n'utilise pas le résolveur canonique."
}
Write-Host "[OK] Menu composants techniques aligné."
