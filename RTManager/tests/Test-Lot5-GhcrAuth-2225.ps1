#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$DockerModule = Join-Path $Root "modules\Crodip.Runtime.Docker.psm1"
$AdminScript = Join-Path $Root "commands\11-docker-admin.ps1"

$content = Get-Content -LiteralPath $DockerModule -Raw

foreach ($expected in @(
    "Test-CrodipRegistryCredentialConfigured",
    "Test-CrodipRegistryReadAccess",
    "[System.Text.UTF8Encoding]::new($false)",
    "--password-stdin",
    "read:packages"
)) {
    if ($content -notmatch [regex]::Escape($expected)) {
        throw "Élément GHCR absent : $expected"
    }
}

if ($content -match '\$cfg\.auths\.\$Registry') {
    throw "Accès StrictMode fragile encore présent."
}

$admin = Get-Content -LiteralPath $AdminScript -Raw
if ($admin -notmatch "Accès lecture GHCR") {
    throw "Statut lecture GHCR absent du menu."
}

foreach ($path in @($DockerModule,$AdminScript)) {
    $tokens=$null
    $errors=$null

    [System.Management.Automation.Language.Parser]::ParseFile(
        $path,
        [ref]$tokens,
        [ref]$errors
    ) | Out-Null

    if ($errors.Count -gt 0) {
        throw "Erreur de parsing $path : $($errors.Message -join ' | ')"
    }
}

Write-Host "[OK] Authentification GHCR Runtime 2.2.42 validée." -ForegroundColor Green
