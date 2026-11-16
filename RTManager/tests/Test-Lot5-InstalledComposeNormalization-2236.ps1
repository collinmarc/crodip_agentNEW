#Requires -Version 7.4
$ErrorActionPreference="Stop"
$Root=Split-Path -Parent $PSScriptRoot
$Normalize=Join-Path $Root "commands\01-normalize-compose.ps1"
$Template=Join-Path $Root "templates\compose.yaml"

if(-not(Test-Path $Normalize)){throw "Commande de normalisation absente."}

$c=Get-Content $Template -Raw
if($c -notmatch '(?m)^name:\s*crodip-runtime-local\s*$'){throw "Template non normalisé."}
if($c -match '(?m)^\s*container_name:'){throw "container_name fixe encore présent."}

foreach($rel in @("01-install.ps1","01-repair.ps1")){
    $p=Join-Path $Root "commands\$rel"
    if(Test-Path $p){
        $s=Get-Content $p -Raw
        if($s -notmatch "01-normalize-compose.ps1"){
            throw "Normalisation non câblée dans $rel"
        }
    }
}

Write-Host "[OK] Installed Compose Normalization 2.2.42 validée." -ForegroundColor Green
