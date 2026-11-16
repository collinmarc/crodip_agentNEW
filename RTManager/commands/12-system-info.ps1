###############################################################
# CRODIP Runtime Manager
# Script   : commands\12-system-info.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 5 System Inventory
###############################################################

#Requires -Version 7.4

[CmdletBinding()]
param(
    [switch]$Quiet
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$moduleRoot = Join-Path $PSScriptRoot "..\modules"

foreach ($moduleName in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.SystemInfo.psm1"
)) {
    Import-Module `
        (Join-Path $moduleRoot $moduleName) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

Write-CrodipRuntimeHeader "12-system-info.ps1"

$inventory = Get-CrodipSystemInventory
$reports = Export-CrodipSystemInventory -Inventory $inventory

if (-not $Quiet) {
    Write-Host ""
    Write-Host "==========================================================" -ForegroundColor Cyan
    Write-Host "        CRODIP - Informations système" -ForegroundColor Cyan
    Write-Host "==========================================================" -ForegroundColor Cyan
    Write-Host ""

    Write-Host "Ordinateur     : $($inventory.Computer.ComputerName)"
    Write-Host "Fabricant      : $($inventory.Computer.Manufacturer)"
    Write-Host "Modèle         : $($inventory.Computer.Model)"
	

# Affichage des résultats
	Write-Host "Utilisateur    : $($inventory.Computer.Utilisateur)"
	Write-Host "Administrateur : $($inventory.Computer.administrateur)"
	Write-Host "CRODIP_PC      : $($inventory.Computer.CRODIP_PC)"


    Write-Host ""
    Write-Host "OS             : $($inventory.OperatingSystem.Caption)"
    Write-Host "Version        : $($inventory.OperatingSystem.Version)"
    Write-Host "Build          : $($inventory.OperatingSystem.BuildNumber)"
    Write-Host "Architecture   : $($inventory.OperatingSystem.Architecture)"
    Write-Host ""
    Write-Host "Firmware       : $($inventory.Firmware.Type)"
    Write-Host "Secure Boot    : $($inventory.Firmware.SecureBoot)"
    Write-Host "BIOS           : $($inventory.Firmware.BIOSManufacturer) $($inventory.Firmware.BIOSVersion)"
    Write-Host ""

    foreach ($cpu in $inventory.Processor) {
        Write-Host "CPU            : $($cpu.Name)"
        Write-Host "Cœurs / Threads: $($cpu.Cores) / $($cpu.LogicalProcessors)"
    }

    Write-Host ""
    Write-Host "RAM totale     : $($inventory.Memory.TotalGB) Go"
    Write-Host "RAM utilisée   : $($inventory.Memory.UsedGB) Go"
    Write-Host "RAM disponible : $($inventory.Memory.FreeGB) Go"
    Write-Host ""
    Write-Host "Disques :"
    foreach ($disk in $inventory.Disks.Logical) {
        Write-Host ("  {0,-4} {1,8} Go total ; {2,8} Go libres ({3}%)" -f `
            $disk.DeviceID,$disk.SizeGB,$disk.FreeGB,$disk.FreePercent)
    }

    Write-Host ""
    Write-Host "Hyperviseur    : $($inventory.Virtualization.HypervisorPresent)"
    Write-Host "Docker Client  : $($inventory.Virtualization.DockerClient)"
    Write-Host "Docker Engine  : $($inventory.Virtualization.DockerServer)"
    Write-Host "Docker Compose : $($inventory.Virtualization.DockerCompose)"
    Write-Host ""
    Write-CrodipSuccess "Inventaire système généré."
    Write-Host ""
    Write-Host "Rapport TXT      : $($reports.Text)"
    Write-Host "Rapport Markdown : $($reports.Markdown)"
    Write-Host "Rapport JSON     : $($reports.Json)"
}
