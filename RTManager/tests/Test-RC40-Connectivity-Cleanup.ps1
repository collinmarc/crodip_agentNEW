$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$dockerModule = Get-Content (Join-Path $root "modules\Crodip.Runtime.Docker.psm1") -Raw
$central = Get-Content (Join-Path $root "commands\12-central-runtime.ps1") -Raw

if ($central -match 'Politique de connectivité CENTRAL') {
    throw "RC40 cleanup: affichage CENTRAL redondant encore présent."
}
if ($dockerModule -notmatch '\$isLocalRuntime') {
    throw "RC40 cleanup: garde LOCAL pour import archives offline absente."
}
if ($dockerModule -notmatch 'Assert-CrodipRequiredImagesLocal') {
    throw "RC40 cleanup: contrôle générique des images Compose absent."
}
if ($dockerModule -notmatch 'PullPolicy "never"') {
    throw "RC40 cleanup: politique OFFLINE --pull never absente."
}
Write-Host "[OK] RC40 - nettoyage connectivité CENTRAL/LOCAL conforme." -ForegroundColor Green
