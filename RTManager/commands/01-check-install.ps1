###############################################################
# CRODIP Runtime Manager
# Script   : commands\01-check-install.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 2 Clean
###############################################################

[CmdletBinding()]
param()

#Requires -Version 7.4

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

Import-Module `
    (Join-Path $PSScriptRoot "..\modules\Crodip.Runtime.Common.psm1") `
    -Force `
    -DisableNameChecking

Import-Module `
    (Join-Path $PSScriptRoot "..\modules\Crodip.Runtime.Windows.psm1") `
    -Force `
    -DisableNameChecking

Import-Module `
    (Join-Path $PSScriptRoot "..\modules\Crodip.Runtime.Logging.psm1") `
    -Force `
    -DisableNameChecking


Write-CrodipRuntimeHeader "01-check-install.ps1"

$runtimeHome = Get-CrodipHome
$dataRoot = Get-CrodipDataRoot
$userRoot = Get-CrodipUserRoot

$checks = @(
    @{ Name = "CRODIP_HOME"; Path = $runtimeHome },
    @{ Name = "CRODIP_DATA_ROOT"; Path = $dataRoot },
    @{ Name = "CRODIP_USER_ROOT"; Path = $userRoot },
    @{ Name = "bootstrap-runtime.ps1"; Path = (Join-Path $runtimeHome "bootstrap-runtime.ps1") },
    @{ Name = "VERSION"; Path = (Join-Path $runtimeHome "VERSION") },
    @{ Name = "runtime.json"; Path = (Join-Path $runtimeHome "config\runtime.json") },
    @{ Name = "compose.yaml"; Path = (Join-Path $runtimeHome "templates\compose.yaml") },
    @{ Name = ".env"; Path = (Join-Path $runtimeHome ".env") },
    @{ Name = "commands"; Path = (Join-Path $runtimeHome "commands") },
    @{ Name = "modules"; Path = (Join-Path $runtimeHome "modules") }
)

$errors = 0

foreach ($check in $checks) {
    if (Test-Path -LiteralPath $check.Path) {
        Write-CrodipSuccess "$($check.Name) : $($check.Path)"
    }
    else {
        Write-CrodipError "$($check.Name) absent : $($check.Path)"
        $errors++
    }
}

foreach ($directoryName in @(
    "sqlite",
    "documents",
    "pdf",
    "photos",
    "signatures",
    "exports",
    "imports",
    "logs",
    "backups",
    "cache",
    "config"
)) {
    $directoryPath = Join-Path $dataRoot $directoryName

    if (Test-Path -LiteralPath $directoryPath) {
        Write-CrodipSuccess "Données/$directoryName"
    }
    else {
        Write-CrodipError "Données/$directoryName absent"
        $errors++
    }
}


# Qualification de la version des images Docker.
try {
    $expectedTag = Get-CrodipRuntimeImageTag
    $expectedBackend = Get-CrodipRuntimeImage -Service "backend" -Target "local"
    $expectedFrontend = Get-CrodipRuntimeImage -Service "frontend" -Target "local"
    $installedEnv = Join-Path $runtimeHome ".env"

    $envContent = if(Test-Path -LiteralPath $installedEnv){
        Get-Content -LiteralPath $installedEnv -Raw
    } else { "" }

    if($envContent -match "(?m)^CRODIP_IMAGE_TAG=$([regex]::Escape($expectedTag))\s*$"){
        Write-CrodipSuccess "Tag images Docker : $expectedTag"
    } else {
        Write-CrodipError "Tag images Docker installé non aligné sur runtime.json."
        $errors++
    }

    foreach($expected in @(
        "CRODIP_BACKEND_IMAGE=$expectedBackend",
        "CRODIP_FRONTEND_IMAGE=$expectedFrontend"
    )){
        if($envContent -notmatch ("(?m)^" + [regex]::Escape($expected) + "\s*$")){
            Write-CrodipError "Image Docker non alignée : $expected"
            $errors++
        }
    }
}
catch {
    Write-CrodipError "Qualification images Docker impossible : $($_.Exception.Message)"
    $errors++
}


# Runtime CENTRAL : optionnel, jamais bloquant pour la qualification LOCAL.
$centralCompose = Join-Path $runtimeHome "central\compose.yaml"
if(Test-Path -LiteralPath $centralCompose -PathType Leaf){
    Write-CrodipSuccess "Runtime CENTRAL simulation installé : $centralCompose"
    Write-CrodipSuccess "CENTRAL frontend : http://localhost:9120"
    Write-CrodipSuccess "CENTRAL backend  : http://localhost:8120"
}
else {
    Write-CrodipWarning "Runtime CENTRAL simulation non installé (optionnel)."
}

if ($errors -eq 0) {
    Write-CrodipSuccess "INSTALLATION QUALIFIÉE"
}
else {
    Write-CrodipError "INSTALLATION NON QUALIFIÉE : $errors erreur(s)"
}
