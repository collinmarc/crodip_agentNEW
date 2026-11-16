#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$DockerModule=Join-Path $Root "modules\Crodip.Runtime.Docker.psm1"

$content=Get-Content -LiteralPath $DockerModule -Raw

foreach($expected in @(
    "Services détectés dans Compose",
    "Vérification de l'accès GHCR",
    "Test-CrodipRegistryCredentialConfigured",
    "Test-CrodipRegistryReadAccess",
    "Pull du service",
    "Get-CrodipDockerPullFailureKind",
    "Résumé téléchargement Docker",
    "AUTH",
    "NOT_FOUND",
    "NETWORK"
)){
    if($content -notmatch [regex]::Escape($expected)){
        throw "Élément de diagnostic pull absent : $expected"
    }
}

$tokens=$null
$errors=$null
[System.Management.Automation.Language.Parser]::ParseFile(
    $DockerModule,[ref]$tokens,[ref]$errors
) | Out-Null

if($errors.Count){
    throw "Parsing Docker module : $($errors.Message -join ' | ')"
}

Write-Host "[OK] Start Pull Diagnostics 2.2.42 validé." -ForegroundColor Green
