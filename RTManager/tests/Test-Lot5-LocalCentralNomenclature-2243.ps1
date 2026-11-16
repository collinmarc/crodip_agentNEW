$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$runtime=Get-Content (Join-Path $root "config\runtime.json") -Raw | ConvertFrom-Json
$env=Get-Content (Join-Path $root "templates\.env.example") -Raw
$manifest=Get-Content (Join-Path $root "images\images-manifest.json") -Raw | ConvertFrom-Json
$common=Get-Content (Join-Path $root "modules\Crodip.Runtime.Common.psm1") -Raw
$normalize=Get-Content (Join-Path $root "commands\01-normalize-compose.ps1") -Raw

if($runtime.docker.projectName -ne "crodip-runtime-local"){throw "Projet runtime incorrect."}
if($runtime.docker.topology.local.composeProject -ne "crodip-runtime-local"){throw "Topologie LOCAL incorrecte."}
if($runtime.docker.topology.central.composeProject -ne "crodip-central"){throw "Topologie CENTRAL incorrecte."}
if([string]::IsNullOrWhiteSpace([string]$runtime.docker.imageTag)){throw "docker.imageTag absent."}

if($env -match 'crodip-(local-)?(backend|frontend):[0-9]'){
    throw "Une version d'image ne doit plus être codée dans .env.example."
}
if($manifest.sourceOfTruth -ne "config/runtime.json#docker.imageTag"){
    throw "Manifest images sans source de vérité runtime.json."
}
foreach($token in @("Get-CrodipRuntimeImageTag","Get-CrodipRuntimeImage","Set-CrodipRuntimeImageEnvironment")){
    if($common -notmatch [regex]::Escape($token)){throw "Helper absent : $token"}
}
if($normalize -notmatch "Set-CrodipRuntimeImageEnvironment"){
    throw "Normalisation .env non reliée à runtime.json."
}
Write-Host "[OK] Nomenclature Runtime LOCAL / CENTRAL et source unique du tag conformes."
