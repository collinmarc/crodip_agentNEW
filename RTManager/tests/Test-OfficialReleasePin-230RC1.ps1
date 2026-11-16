#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$config = Get-Content -LiteralPath (Join-Path $root "config\runtime.json") -Raw | ConvertFrom-Json

if ($config.version -ne "2.3.0-RC1") { throw "Version runtime incorrecte." }
if ($config.application.version -ne "2.3.0-dev.1") { throw "Version application incorrecte." }
if ($config.release.runId -ne "34317428903") { throw "Run officiel incorrect." }
if ($config.docker.imageReferenceMode -ne "digest") { throw "Le mode image doit être digest." }
if ($config.docker.activeLifecycle -ne "TEST") { throw "Le profil actif doit rester TEST." }
if ($config.release.promotionToPreprodOrProdAllowed -ne $false) { throw "Promotion PREPROD/PROD ne doit pas être autorisée." }

foreach ($target in @("local","central")) {
    foreach ($service in @("backend","frontend")) {
        $ref = $config.docker.officialImages.$target.$service.reference
        if ($ref -notmatch "@sha256:[0-9a-f]{64}$") {
            throw "Référence digest invalide : $target/$service => $ref"
        }
    }
}

if ($config.docker.topology.local.backendPort -ne 8110 -or
    $config.docker.topology.local.frontendPort -ne 9110) {
    throw "Ports TEST LOCAL incorrects."
}
if ($config.docker.topology.central.backendPort -ne 8120 -or
    $config.docker.topology.central.frontendPort -ne 9120) {
    throw "Ports TEST CENTRAL incorrects."
}

Write-Host "[OK] Runtime 2.3.0-RC1 : pin officiel, digests et profil TEST cohérents."
