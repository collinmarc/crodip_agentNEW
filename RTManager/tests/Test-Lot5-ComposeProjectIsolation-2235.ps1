#Requires -Version 7.4
$ErrorActionPreference="Stop"
$Root=Split-Path -Parent $PSScriptRoot
$Compose=Join-Path $Root "templates\compose.yaml"
$Module=Join-Path $Root "modules\Crodip.Runtime.Compose.psm1"
$Start=Join-Path $Root "commands\03-start.ps1"

$c=Get-Content $Compose -Raw
if($c -notmatch '(?m)^name:\s*crodip-runtime-local\s*$'){throw "Projet runtime-local absent."}
if($c -match '(?m)^\s*container_name:'){throw "container_name fixe encore présent."}

$m=Get-Content $Module -Raw
foreach($expected in @("Repair-CrodipRuntimeComposeIsolation","Test-CrodipRuntimePortAvailability","before-project-isolation")){
 if($m -notmatch [regex]::Escape($expected)){throw "Fonction isolation absente : $expected"}
}

$s=Get-Content $Start -Raw
foreach($expected in @("Isolation du projet Compose Runtime local","Contrôle des ports Runtime","Contrôle ports publiés")){
 if($s -notmatch [regex]::Escape($expected)){throw "Contrôle démarrage absent : $expected"}
}

foreach($file in @($Module,$Start)){
 $t=$null;$e=$null
 [Management.Automation.Language.Parser]::ParseFile($file,[ref]$t,[ref]$e)|Out-Null
 if($e.Count){throw "Parsing $file : $($e.Message -join ' | ')"}
}
Write-Host "[OK] Compose Project Isolation 2.2.42 validée." -ForegroundColor Green
