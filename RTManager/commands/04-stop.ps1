###############################################################
# CRODIP Runtime Manager
# Script   : commands\04-stop.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 4
###############################################################

[CmdletBinding(SupportsShouldProcess = $true)]
param([switch]$RemoveContainers)

#Requires -Version 7.4

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$moduleRoot = Join-Path $PSScriptRoot "..\modules"
foreach ($moduleName in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1",
    "Crodip.Runtime.DockerProvider.psm1",
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Compose.psm1"
)) {
    Import-Module (Join-Path $moduleRoot $moduleName) -Force -DisableNameChecking -ErrorAction Stop
}

Write-CrodipRuntimeHeader "04-stop.ps1"

$composeFile = Get-CrodipComposeFile
if ([string]::IsNullOrWhiteSpace($composeFile)) {
    Write-CrodipError "compose.yaml absent."
    return
}

$action = if ($RemoveContainers) { "down" } else { "stop" }
$result = Invoke-CrodipCompose `
    -Action $action `
    -ComposeFile $composeFile `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

if ($result.ExitCode -ne 0) {
    Write-CrodipError "Échec de l'arrêt Compose."
    $result.Output | ForEach-Object { Write-Host $_ }
    return
}

if ($WhatIfPreference) {
    Write-CrodipWarning "Arrêt simulé."
    return
}

Write-CrodipSuccess "Services CRODIP arrêtés."
