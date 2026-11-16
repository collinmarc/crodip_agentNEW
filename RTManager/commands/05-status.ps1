###############################################################
# CRODIP Runtime Manager
# Script   : commands\05-status.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 4 Docker Dashboard
###############################################################

[CmdletBinding()]
param([switch]$Quiet)

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

Write-CrodipRuntimeHeader "05-status.ps1"

$desktopInstalled = Test-CrodipDockerDesktopInstalled
$engineRunning = Test-CrodipDockerEngine
$versions = Get-CrodipDockerVersionInfo
$composeFile = Get-CrodipComposeFile

if ([string]::IsNullOrWhiteSpace($composeFile)) {
    Write-CrodipError "compose.yaml absent."
    return
}

Write-CrodipStep "État des services Compose"

$services = @(Get-CrodipComposeServiceRuntimeStatus -ComposeFile $composeFile)

if ($services.Count -eq 0) {
    Write-CrodipWarning "Aucun service Compose détecté."
    return
}

$labels = @{
    "backend"  = "API Backend"
    "frontend" = "Frontend"
}

$allOperational = $true

foreach ($serviceName in @("backend","frontend")) {
    $service = @(
        $services |
            Where-Object { $_.Service -eq $serviceName }
    ) | Select-Object -First 1

    $displayName = if ($labels.ContainsKey($serviceName)) {
        $labels[$serviceName]
    }
    else {
        $serviceName
    }

    if ($null -eq $service) {
        Write-CrodipWarning "$displayName : Absent du projet Compose."
        $allOperational = $false
        continue
    }

    switch ($service.NormalizedState) {
        "RUNNING" {
            Write-CrodipSuccess "$displayName : Running"
        }

        "RESTARTING" {
            Write-CrodipError "$displayName : Restarting"
            $allOperational = $false
        }

        "UNHEALTHY" {
            Write-CrodipError "$displayName : Unhealthy"
            $allOperational = $false
        }

        "EXITED" {
            Write-CrodipError "$displayName : Exited"
            $allOperational = $false
        }

        "DEAD" {
            Write-CrodipError "$displayName : Dead"
            $allOperational = $false
        }

        default {
            Write-CrodipWarning "$displayName : $($service.NormalizedState)"
            $allOperational = $false
        }
    }

    Write-Host "         Service   : $($service.Service)"
    Write-Host "         Conteneur : $($service.ContainerName)"
    Write-Host "         Image     : $($service.Image)"
    Write-Host "         State     : $($service.State)"
    Write-Host "         Status    : $($service.Status)"

    if (-not [string]::IsNullOrWhiteSpace([string]$service.Health)) {
        Write-Host "         Health    : $($service.Health)"
    }

    if ($null -ne $service.ExitCode -and [string]$service.ExitCode -ne "") {
        Write-Host "         ExitCode  : $($service.ExitCode)"
    }

    Write-Host ""
}

if ($allOperational) {
    Write-CrodipSuccess "Tous les services Runtime sont opérationnels."
}
else {
    Write-CrodipWarning "Un ou plusieurs services Runtime ne sont pas opérationnels."
}
