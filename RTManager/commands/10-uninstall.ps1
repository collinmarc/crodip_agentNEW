###############################################################
# CRODIP Runtime Manager
# Script   : commands\10-uninstall.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 2 Clean
###############################################################

[CmdletBinding(
    SupportsShouldProcess = $true,
    ConfirmImpact = "High"
)]
param(
    [switch]$RemoveData,
    [switch]$RemoveUserPreferences
)

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


Write-CrodipRuntimeHeader "10-uninstall.ps1"

if (-not (Test-CrodipAdministrator)) {
    Write-CrodipError "Ouvrir PowerShell 7 en administrateur."
    return
}

$runtimeHome = Get-CrodipHome
$dataRoot = Get-CrodipDataRoot
$userRoot = Get-CrodipUserRoot

$desktopShortcut = Join-Path `
    ([Environment]::GetFolderPath("Desktop")) `
    "CRODIP Runtime Manager.lnk"

$startMenuShortcut = Join-Path `
    $env:APPDATA `
    "Microsoft\Windows\Start Menu\Programs\CRODIP Runtime Manager.lnk"

foreach ($shortcutPath in @(
    $desktopShortcut,
    $startMenuShortcut
)) {
    if (
        (Test-Path -LiteralPath $shortcutPath) -and
        $PSCmdlet.ShouldProcess(
            $shortcutPath,
            "Supprimer le raccourci"
        )
    ) {
        Remove-Item `
            -LiteralPath $shortcutPath `
            -Force
    }
}

Remove-CrodipEnvironmentVariables `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

if (
    (Test-Path -LiteralPath $runtimeHome) -and
    $PSCmdlet.ShouldProcess(
        $runtimeHome,
        "Supprimer l'application CRODIP"
    )
) {
    Remove-Item `
        -LiteralPath $runtimeHome `
        -Recurse `
        -Force
}

if (
    $RemoveData -and
    (Test-Path -LiteralPath $dataRoot) -and
    $PSCmdlet.ShouldProcess(
        $dataRoot,
        "SUPPRIMER DEFINITIVEMENT LES DONNEES METIER"
    )
) {
    Remove-Item `
        -LiteralPath $dataRoot `
        -Recurse `
        -Force
}

if (
    $RemoveUserPreferences -and
    (Test-Path -LiteralPath $userRoot) -and
    $PSCmdlet.ShouldProcess(
        $userRoot,
        "Supprimer les préférences utilisateur"
    )
) {
    Remove-Item `
        -LiteralPath $userRoot `
        -Recurse `
        -Force
}

if ($WhatIfPreference) {
    Write-CrodipWarning "Désinstallation simulée."
    return
}

Write-CrodipSuccess "Désinstallation terminée."

if (-not $RemoveData) {
    Write-CrodipSuccess "Données conservées : $dataRoot"
}


# ------------------------------------------------------------------
# Composants techniques
# ------------------------------------------------------------------
# Par sécurité, la désinstallation standard du Runtime ne supprime
# JAMAIS automatiquement Docker, WSL2 ou GitHub CLI.
# Leur cycle de vie est géré séparément via le menu 16.
Write-Host ""
Write-CrodipWarning "Les composants techniques partagés (Docker, WSL2, GitHub CLI) sont conservés."
Write-CrodipWarning "Pour les supprimer explicitement, utiliser le menu 16 avant de désinstaller le Runtime."
