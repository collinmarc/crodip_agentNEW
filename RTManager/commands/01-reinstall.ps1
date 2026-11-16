###############################################################
# CRODIP Runtime Manager
# Script   : commands\01-reinstall.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 2 Clean
###############################################################

[CmdletBinding(
    SupportsShouldProcess = $true,
    ConfirmImpact = "High"
)]
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


Write-CrodipRuntimeHeader "01-reinstall.ps1"

if (-not (Test-CrodipAdministrator)) {
    Write-CrodipError "Ouvrir PowerShell 7 en administrateur."
    return
}

$runtimeHome = Get-CrodipHome

if (
    (Test-Path -LiteralPath $runtimeHome) -and
    $PSCmdlet.ShouldProcess(
        $runtimeHome,
        "Supprimer l'application avant réinstallation"
    )
) {
    Remove-Item `
        -LiteralPath $runtimeHome `
        -Recurse `
        -Force
}

& (Join-Path $PSScriptRoot "01-install.ps1") `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

if ($WhatIfPreference) {
    Write-CrodipWarning "Réinstallation simulée."
    return
}


# Normalisation systématique du Compose Runtime installé
$normalizeCompose = Join-Path $PSScriptRoot "01-normalize-compose.ps1"
if(Test-Path -LiteralPath $normalizeCompose){
    try{
        & $normalizeCompose -NonInteractive
    }
    catch{
        Write-CrodipWarning "Normalisation Compose : $($_.Exception.Message)"
    }
}

Write-CrodipSuccess "Réinstallation terminée."
