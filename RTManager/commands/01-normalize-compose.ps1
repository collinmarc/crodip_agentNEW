###############################################################
# CRODIP Runtime Manager
# Script   : commands\01-normalize-compose.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Installed Compose Normalization
###############################################################

#Requires -Version 7.4

[CmdletBinding()]
param(
    [switch]$NonInteractive
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$moduleRoot = Join-Path $PSScriptRoot "..\modules"

foreach($moduleName in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.DockerProvider.psm1",
    "Crodip.Runtime.Compose.psm1"
)){
    Import-Module (Join-Path $moduleRoot $moduleName) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

$composeFile = Get-CrodipComposeFile -ApplicationRoot (Get-CrodipHome)

if([string]::IsNullOrWhiteSpace($composeFile)){
    Write-CrodipWarning "Aucun compose.yaml installé à normaliser."
    return
}


# Synchronisation des images du Runtime LOCAL depuis la source de vérité.
$envFile = Join-Path (Get-CrodipHome) ".env"
if (Test-Path -LiteralPath $envFile -PathType Leaf) {
    $imageEnvironment = Set-CrodipRuntimeImageEnvironment `
        -EnvFile $envFile `
        -Target "local" `
        -Confirm:$false

    Write-CrodipSuccess ".env : images réalignées sur config\runtime.json."
    Write-CrodipSuccess "Tag : $($imageEnvironment.Tag)"
}

Write-CrodipStep "Normalisation du Compose Runtime installé"

if($NonInteractive){
    $content = Get-Content -LiteralPath $composeFile -Raw
    $original = $content

    $content = $content -replace '(?m)^name:\s*crodip-local\s*$','name: crodip-runtime-local'
    $content = [regex]::Replace(
        $content,
        '(?m)^\s*container_name:\s*crodip-(backend|frontend)\s*\r?\n',
        ''
    )

    if($content -ne $original){
        $stamp=Get-Date -Format "yyyyMMdd-HHmmss"
        $backup="$composeFile.before-project-isolation-$stamp.bak"
        Copy-Item -LiteralPath $composeFile -Destination $backup -Force
        Set-Content -LiteralPath $composeFile -Value $content -Encoding utf8
        Write-CrodipSuccess "Compose installé normalisé : crodip-runtime-local"
        Write-CrodipSuccess "Sauvegarde : $backup"
    }
    else{
        Write-CrodipSuccess "Compose installé déjà normalisé."
    }
}
else{
    $result = Repair-CrodipRuntimeComposeIsolation `
        -ComposeFile $composeFile `
        -Confirm:$false

    if(-not $result.Changed){
        Write-CrodipSuccess "Aucune modification Compose nécessaire."
    }
}
