$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$runtime=Get-Content (Join-Path $root "config\runtime.json") -Raw | ConvertFrom-Json
$env=Get-Content (Join-Path $root "templates\.env.example") -Raw
$manifest=Get-Content (Join-Path $root "images\images-manifest.json") -Raw | ConvertFrom-Json
$common=Get-Content (Join-Path $root "modules\Crodip.Runtime.Common.psm1") -Raw
$install=Get-Content (Join-Path $root "commands\01-install.ps1") -Raw
$update=Get-Content (Join-Path $root "commands\08-update.ps1") -Raw
$docker=Get-Content (Join-Path $root "modules\Crodip.Runtime.Docker.psm1") -Raw

if($runtime.version -ne "2.2.46"){throw "runtime.json version incorrecte."}
if($runtime.docker.imageTag -ne "2.2.1"){throw "Tag image attendu absent."}

foreach($target in @("local","central")){
    foreach($service in @("backend","frontend")){
        $repo=$runtime.docker.imageRepositories.$target.$service
        if([string]::IsNullOrWhiteSpace([string]$repo)){throw "Repository absent : $target/$service"}
        if($repo -match ':[0-9]+\.[0-9]+\.[0-9]+$'){throw "Tag dupliqué dans repository : $repo"}
    }
}

if($env -match '(?m)^CRODIP_(BACKEND|FRONTEND)_IMAGE='){
    throw ".env.example contient encore une image versionnée."
}
if($env -match '(?m)^CRODIP_IMAGE_TAG='){
    throw ".env.example contient encore une duplication du tag."
}
if($manifest.sourceOfTruth -ne "config/runtime.json#docker.imageTag"){
    throw "Manifest non relié à la source de vérité."
}
if(($manifest | ConvertTo-Json -Depth 10) -match ':[0-9]+\.[0-9]+\.[0-9]+'){
    throw "Manifest contient encore un tag d'image en dur."
}

foreach($content in @($install,$update)){
    if($content -notmatch "Set-CrodipRuntimeImageEnvironment"){
        throw "Synchronisation des images absente d'un workflow."
    }
}

foreach($fn in @("Get-CrodipRuntimeImageTag","Get-CrodipRuntimeImage","Set-CrodipRuntimeImageEnvironment")){
    if($common -notmatch ("function\s+"+[regex]::Escape($fn))){
        throw "Fonction absente : $fn"
    }
}

if($docker -match 'ghcr\.io/idwebconcept/crodip-local-backend:2\.2\.1'){
    throw "Image backend versionnée encore codée dans le module Docker."
}

Write-Host "[OK] docker.imageTag est la source unique de version des images."
