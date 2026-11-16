#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$Update=Join-Path $Root "commands\08-update.ps1"
$content=Get-Content -LiteralPath $Update -Raw

if($content -match '\$pullResult'){
    throw "Référence legacy `$pullResult encore présente."
}

if($content -notmatch "Services détectés dans Compose"){
    throw "Logique dynamique Compose absente."
}

if($content -notmatch "Mise à jour Docker terminée service par service"){
    throw "Résumé service par service absent."
}

# Only one update-up phase should remain
$matches=[regex]::Matches($content,'-Action "up"')
if($matches.Count -ne 1){
    throw "Nombre inattendu de phases docker compose up : $($matches.Count)"
}

$tokens=$null
$errors=$null
[System.Management.Automation.Language.Parser]::ParseFile(
    $Update,[ref]$tokens,[ref]$errors
) | Out-Null

if($errors.Count -gt 0){
    throw "Erreur de parsing : $($errors.Message -join ' | ')"
}

Write-Host "[OK] Nettoyage update 2.2.42 validé." -ForegroundColor Green
