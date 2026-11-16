#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$Update = Join-Path $Root "commands\08-update.ps1"
$Compose = Join-Path $Root "modules\Crodip.Runtime.Compose.psm1"

$u = Get-Content -LiteralPath $Update -Raw
$c = Get-Content -LiteralPath $Compose -Raw

foreach ($service in @("frontend","backend","postgres")) {
    if ($u -notmatch [regex]::Escape("Name  = `"$service`"")) {
        throw "Service absent de la mise à jour : $service"
    }
}

if ($u -notmatch "Image locale conservée") {
    throw "Fallback local par service absent."
}

if ($u -notmatch "Fallback offline") {
    throw "Fallback offline par service absent."
}

if ($c -notmatch '\[string\[\]\]\$Services') {
    throw "Invoke-CrodipCompose ne supporte pas le ciblage de services."
}

Write-Host "[OK] Pull Docker service par service 2.2.42 validé." -ForegroundColor Green
