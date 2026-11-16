###############################################################
# CRODIP Runtime Manager
# Test     : tests\Test-ModuleExports.ps1
# Version  : 2.2.1
# Statut   : Stable
###############################################################

$ErrorActionPreference = "Stop"

$moduleRoot = Join-Path $PSScriptRoot "..\modules"

Import-Module (Join-Path $moduleRoot "Crodip.Runtime.Common.psm1") -Force -DisableNameChecking
Import-Module (Join-Path $moduleRoot "Crodip.Runtime.Windows.psm1") -Force -DisableNameChecking
Import-Module (Join-Path $moduleRoot "Crodip.Runtime.Docker.psm1") -Force -DisableNameChecking
Import-Module (Join-Path $moduleRoot "Crodip.Runtime.Logging.psm1") -Force -DisableNameChecking

$requiredCommands = @(
    "Write-CrodipStep",
    "Write-CrodipSuccess",
    "Write-CrodipWarning",
    "Write-CrodipError",
    "New-CrodipDirectory",
    "Write-CrodipRuntimeHeader",
    "Get-CrodipHome",
    "Get-CrodipDataRoot",
    "Get-CrodipUserRoot",
    "Initialize-CrodipDirectories",
    "Test-CrodipAdministrator",
    "Test-CrodipDockerDesktopInstalled",
    "Test-CrodipDockerEngine",
    "Start-CrodipDockerDesktop",
    "Find-CrodipComposeFile",
    "Write-CrodipRuntimeLog"
)

$missingBefore = @(
    $requiredCommands | Where-Object {
        -not (Get-Command $_ -ErrorAction SilentlyContinue)
    }
)

if ($missingBefore.Count -gt 0) {
    throw "Commandes absentes après import : $($missingBefore -join ', ')"
}

# Reproduit le point qui faisait disparaître Write-CrodipSuccess.
$paths = Initialize-CrodipDirectories

if (-not $paths.Home -or -not $paths.Data -or -not $paths.User) {
    throw "Initialize-CrodipDirectories n'a pas retourné les chemins attendus."
}

$missingAfter = @(
    $requiredCommands | Where-Object {
        -not (Get-Command $_ -ErrorAction SilentlyContinue)
    }
)

if ($missingAfter.Count -gt 0) {
    throw "Commandes disparues après initialisation : $($missingAfter -join ', ')"
}

Write-CrodipSuccess "Tous les modules, exports et appels d'initialisation sont valides."
