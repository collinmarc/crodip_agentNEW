#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$Module = Join-Path $Root "modules\Crodip.Runtime.Preflight.psm1"

Import-Module `
    $Module `
    -Force `
    -DisableNameChecking `
    -ErrorAction Stop

$r = Get-CrodipHardwareWindowsPreflight

foreach ($property in @(
    "HypervisorPresent",
    "VirtualizationBasedSecurityRunning",
    "VirtualizationState",
    "VirtualizationSource"
)) {
    if (-not ($r.PSObject.Properties.Name -contains $property)) {
        throw "Propriété absente : $property"
    }
}

if ($r.HypervisorPresent -and $r.VirtualizationState -ne "ENABLED") {
    throw "Hyperviseur actif mais virtualisation non reconnue comme ENABLED."
}

if ($r.VirtualizationBasedSecurityRunning -and $r.VirtualizationState -ne "ENABLED") {
    throw "VBS active mais virtualisation non reconnue comme ENABLED."
}

Write-Host ""
Write-Host "VirtualizationState  : $($r.VirtualizationState)"
Write-Host "VirtualizationSource : $($r.VirtualizationSource)"
Write-Host "HypervisorPresent    : $($r.HypervisorPresent)"
Write-Host "VBS Running          : $($r.VirtualizationBasedSecurityRunning)"
Write-Host ""
Write-Host "[OK] Détection multi-source de la virtualisation 2.2.42 validée." -ForegroundColor Green
