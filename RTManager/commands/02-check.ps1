
###############################################################
# CRODIP Runtime Manager
# Script   : commands\02-check.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 3 Runtime Dashboard
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
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1",
    "Crodip.Runtime.DockerProvider.psm1",
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Health.psm1",
    "Crodip.Runtime.Performance.psm1"
)) {
    Import-Module `
        (Join-Path $moduleRoot $moduleName) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

Write-CrodipRuntimeHeader "02-check.ps1"

$performanceSession=New-CrodipPerformanceSession -Name "Vérification environnement" -Type "check"

$perfTimer=[Diagnostics.Stopwatch]::StartNew()
$results = @(Get-CrodipRuntimeHealth)
$perfTimer.Stop()
Add-CrodipPerformanceMeasurement -Session $performanceSession -Name "Diagnostic Runtime complet" -Seconds $perfTimer.Elapsed.TotalSeconds

foreach ($healthResult in $results) {
    $durationSeconds = 0

    if ($healthResult.PSObject.Properties.Name -contains "DurationMs") {
        $durationSeconds = [math]::Round(([double]$healthResult.DurationMs / 1000),3)
    }

    Add-CrodipPerformanceMeasurement `
        -Session $performanceSession `
        -Name $healthResult.Name `
        -Seconds $durationSeconds `
        -Category "HealthCheck" `
        -Details ("Status={0}; Severity={1}" -f $healthResult.Status,$healthResult.Severity)
}

$summary = Get-CrodipHealthSummary -Results $results

$reports = Export-CrodipHealthReports `
    -Results $results `
    -Summary $summary

if (-not $Quiet) {
    Write-Host ""
    Write-Host "==========================================================" -ForegroundColor Cyan
    Write-Host "        CRODIP Runtime Dashboard" -ForegroundColor Cyan
    Write-Host "==========================================================" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Version : $(Get-CrodipRuntimeVersion)"
    Write-Host ""

    foreach ($result in $results) {
        $label = "[{0}] {1}" -f $result.Status, $result.Name

        switch ($result.Status) {
            "OK" {
                Write-Host $label -ForegroundColor Green
            }
            "WARNING" {
                Write-Host $label -ForegroundColor Yellow
            }
            "ERROR" {
                Write-Host $label -ForegroundColor Red
            }
            default {
                Write-Host $label -ForegroundColor Cyan
            }
        }

        if (-not [string]::IsNullOrWhiteSpace($result.Details)) {
            Write-Host "         $($result.Details)"
        }

        if (
            $result.Status -ne "OK" -and
            -not [string]::IsNullOrWhiteSpace($result.Correction)
        ) {
            Write-Host `
                "         Correction : $($result.Correction)" `
                -ForegroundColor Yellow
        }
    }

    Write-Host ""
    Write-Host "----------------------------------------------------------"

    Write-Host "Score              : $($summary.Percentage)%"
    Write-Host "Erreurs critiques  : $($summary.CriticalErrors)"
    Write-Host "Erreurs majeures   : $($summary.MajorErrors)"
    Write-Host "Avertissements     : $($summary.Warnings)"
    Write-Host "----------------------------------------------------------"
}

switch ($summary.Status) {
    "READY" {
        Write-CrodipSuccess "READY"
    }
    "READY WITH WARNINGS" {
        Write-CrodipWarning "READY WITH WARNINGS"
    }
    default {
        Write-CrodipError "NOT READY"
    }
}

if (-not $Quiet) {
    Write-Host ""
    Write-Host "Rapport TXT      : $($reports.Text)"
    Write-Host "Rapport Markdown : $($reports.Markdown)"
    Write-Host "Rapport JSON     : $($reports.Json)"

$performanceReport=Export-CrodipPerformanceReport -Session $performanceSession
Show-CrodipPerformanceSummary -Report $performanceReport -Label "vérification"
}

