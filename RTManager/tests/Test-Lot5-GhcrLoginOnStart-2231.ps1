#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$DockerModule=Join-Path $Root "modules\Crodip.Runtime.Docker.psm1"

$content=Get-Content -LiteralPath $DockerModule -Raw

foreach($expected in @(
    "Se connecter à GHCR maintenant ? [O/n]",
    "Connect-CrodipRegistry",
    "Nouveau test d'accès GHCR",
    "Authentification GHCR validée",
    "Test-CrodipRegistryReadAccess"
)){
    if($content -notmatch [regex]::Escape($expected)){
        throw "Élément GHCR Login On Start absent : $expected"
    }
}

$tokens=$null
$errors=$null

[System.Management.Automation.Language.Parser]::ParseFile(
    $DockerModule,
    [ref]$tokens,
    [ref]$errors
) | Out-Null

if($errors.Count){
    throw "Parsing Docker module : $($errors.Message -join ' | ')"
}

Write-Host "[OK] GHCR Login On Start 2.2.42 validé." -ForegroundColor Green
