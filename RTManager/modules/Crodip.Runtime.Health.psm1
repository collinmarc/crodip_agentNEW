###############################################################
# CRODIP Runtime Manager
# Module   : Crodip.Runtime.Health.psm1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 5 Health Preflight Fix
###############################################################

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"


if (-not (Get-Command Get-CrodipHardwareWindowsPreflight -ErrorAction SilentlyContinue)) {
    Import-Module `
        (Join-Path $PSScriptRoot "Crodip.Runtime.Preflight.psm1") `
        -Global `
        -DisableNameChecking `
        -ErrorAction Stop
}

if (-not (Get-Command Get-CrodipWslStatus -ErrorAction SilentlyContinue)) {
    Import-Module `
        (Join-Path $PSScriptRoot "Crodip.Runtime.DockerProvider.psm1") `
        -Global `
        -DisableNameChecking `
        -ErrorAction Stop
}


function New-CrodipHealthResult {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Name,
        [Parameter(Mandatory)]
        [ValidateSet("OK", "WARNING", "ERROR", "INFO")]
        [string]$Status,
        [Parameter(Mandatory)]
        [ValidateSet("CRITICAL", "MAJOR", "IMPORTANT", "MINOR", "INFO")]
        [string]$Severity,
        [Parameter(Mandatory)][int]$Score,
        [Parameter(Mandatory)][int]$MaxScore,
        [Parameter(Mandatory)][string]$Message,
        [string]$Details = "",
        [string]$Correction = "",
        [long]$DurationMs = 0
    )

    [pscustomobject]@{
        Name       = $Name
        Status     = $Status
        Severity   = $Severity
        Score      = $Score
        MaxScore   = $MaxScore
        Message    = $Message
        Details    = $Details
        Correction = $Correction
        DurationMs = $DurationMs
    }
}

function Invoke-CrodipHealthCheck {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Name,
        [Parameter(Mandatory)]
        [ValidateSet("CRITICAL", "MAJOR", "IMPORTANT", "MINOR", "INFO")]
        [string]$Severity,
        [Parameter(Mandatory)][int]$MaxScore,
        [Parameter(Mandatory)][scriptblock]$Test,
        [Parameter(Mandatory)][string]$SuccessMessage,
        [Parameter(Mandatory)][string]$FailureMessage,
        [string]$Correction = ""
    )

    $watch = [System.Diagnostics.Stopwatch]::StartNew()

    try {
        $rawResult = & $Test
        $watch.Stop()

        if ($rawResult -is [hashtable]) {
            $success = [bool]$rawResult.Success
            $details = [string]$rawResult.Details
        }
        else {
            $success = [bool]$rawResult
            $details = ""
        }

        if ($success) {
            return New-CrodipHealthResult `
                -Name $Name `
                -Status "OK" `
                -Severity $Severity `
                -Score $MaxScore `
                -MaxScore $MaxScore `
                -Message $SuccessMessage `
                -Details $details `
                -DurationMs $watch.ElapsedMilliseconds
        }

        return New-CrodipHealthResult `
            -Name $Name `
            -Status "ERROR" `
            -Severity $Severity `
            -Score 0 `
            -MaxScore $MaxScore `
            -Message $FailureMessage `
            -Details $details `
            -Correction $Correction `
            -DurationMs $watch.ElapsedMilliseconds
    }
    catch {
        $watch.Stop()

        return New-CrodipHealthResult `
            -Name $Name `
            -Status "ERROR" `
            -Severity $Severity `
            -Score 0 `
            -MaxScore $MaxScore `
            -Message $FailureMessage `
            -Details $_.Exception.Message `
            -Correction $Correction `
            -DurationMs $watch.ElapsedMilliseconds
    }
}

function Get-CrodipRuntimeHealth {
    [CmdletBinding()]
    param()

    $runtimeHome = Get-CrodipHome
    $dataRoot = Get-CrodipDataRoot
    $userRoot = Get-CrodipUserRoot
    $results = [System.Collections.Generic.List[object]]::new()

    # -------------------------------------------------------------
    # Préflight matériel / Windows
    # -------------------------------------------------------------
    $preflight = Get-CrodipHardwareWindowsPreflight

    $results.Add((New-CrodipHealthResult `
        -Name "Architecture" `
        -Status $(if ($preflight.Architecture64Bit) { "OK" } else { "ERROR" }) `
        -Severity "CRITICAL" `
        -Score $(if ($preflight.Architecture64Bit) { 5 } else { 0 }) `
        -MaxScore 5 `
        -Message $(if ($preflight.Architecture64Bit) {
            "Architecture 64 bits compatible."
        } else {
            "Architecture 64 bits requise."
        }) `
        -Details ([string]$preflight.Architecture) `
        -Correction $(if ($preflight.Architecture64Bit) {
            ""
        } else {
            "Utiliser un poste Windows 64 bits."
        })))

    $virtStatus = if ($preflight.VirtualizationState -eq "ENABLED") {
        "OK"
    }
    elseif ($preflight.VirtualizationState -eq "DISABLED") {
        "ERROR"
    }
    else {
        "WARNING"
    }

    $virtScore = if ($virtStatus -eq "OK") { 8 } else { 0 }

    $results.Add((New-CrodipHealthResult `
        -Name "Virtualisation BIOS/UEFI" `
        -Status $virtStatus `
        -Severity "CRITICAL" `
        -Score $virtScore `
        -MaxScore 8 `
        -Message $(if ($virtStatus -eq "OK") {
            "Virtualisation matérielle opérationnelle."
        }
        elseif ($virtStatus -eq "ERROR") {
            "Virtualisation matérielle désactivée."
        }
        else {
            "État de la virtualisation indéterminé."
        }) `
        -Details "$($preflight.VirtualizationSource)" `
        -Correction $(if ($virtStatus -eq "ERROR") {
            "Activer Intel VT-x ou AMD SVM/AMD-V dans le BIOS/UEFI puis redémarrer."
        }
        elseif ($virtStatus -eq "WARNING") {
            "Vérifier HyperVisorPresent, VBS et le BIOS/UEFI."
        }
        else {
            ""
        })))

    # -------------------------------------------------------------
    # Virtual Machine Platform
    #
    # L'état Windows peut être "Unknown" lorsque Get-WindowsOptionalFeature
    # n'est pas exploitable dans le contexte courant. Dans ce cas, ne pas
    # dégrader le Runtime si la chaîne WSL2 + hyperviseur + Docker Engine
    # prouve que la plateforme de virtualisation est opérationnelle.
    # -------------------------------------------------------------
    $wslStatus = Get-CrodipWslStatus

    $dockerEngineOperational = $false
    try {
        $dockerCommand = Get-Command docker -ErrorAction SilentlyContinue
        if ($dockerCommand) {
            $dockerServerVersion = & docker info --format "{{.ServerVersion}}" 2>$null
            $dockerEngineOperational = (
                $LASTEXITCODE -eq 0 -and
                -not [string]::IsNullOrWhiteSpace([string]$dockerServerVersion)
            )
        }
    }
    catch {
        $dockerEngineOperational = $false
    }

    $vmpNativeEnabled = (
        [string]$preflight.VirtualMachinePlatformState -match "^(?i:enabled|enable pending)$"
    )

    $vmpOperationalByEvidence = (
        -not $vmpNativeEnabled -and
        [string]$preflight.VirtualMachinePlatformState -match "^(?i:unknown|indeterminate|)$" -and
        [bool]$preflight.HypervisorPresent -and
        [bool]$wslStatus.Installed -and
        $dockerEngineOperational
    )

    $vmpOperational = ($vmpNativeEnabled -or $vmpOperationalByEvidence)

    $vmpDetails = if ($vmpNativeEnabled) {
        [string]$preflight.VirtualMachinePlatformState
    }
    elseif ($vmpOperationalByEvidence) {
        "OperationalByEvidence ; HyperVisorPresent=True ; WSL2 opérationnel ; Docker Engine opérationnel"
    }
    else {
        [string]$preflight.VirtualMachinePlatformState
    }

    $results.Add((New-CrodipHealthResult `
        -Name "Virtual Machine Platform" `
        -Status $(if ($vmpOperational) { "OK" } else { "WARNING" }) `
        -Severity "MAJOR" `
        -Score $(if ($vmpOperational) { 4 } else { 0 }) `
        -MaxScore 4 `
        -Message $(if ($vmpNativeEnabled) {
            "Virtual Machine Platform activé."
        }
        elseif ($vmpOperationalByEvidence) {
            "Virtual Machine Platform opérationnel par preuve d'exécution."
        }
        else {
            "État Virtual Machine Platform non confirmé."
        }) `
        -Details $vmpDetails `
        -Correction $(if ($vmpOperational) {
            ""
        } else {
            "La préparation WSL2 peut activer ce composant Windows."
        })))

    $results.Add((New-CrodipHealthResult `
        -Name "WSL2" `
        -Status $(if ($wslStatus.Installed) { "OK" } else { "ERROR" }) `
        -Severity "CRITICAL" `
        -Score $(if ($wslStatus.Installed) { 8 } else { 0 }) `
        -MaxScore 8 `
        -Message $(if ($wslStatus.Installed) {
            "WSL2 installé."
        } else {
            "WSL2 non installé."
        }) `
        -Details $(if ($wslStatus.Installed) {
            if ([string]::IsNullOrWhiteSpace([string]$wslStatus.Version)) {
                "Installé"
            } else {
                ([string]$wslStatus.Version -split "`r?`n" | Select-Object -First 1)
            }
        } else {
            "Requis pour Docker Desktop Linux."
        }) `
        -Correction $(if ($wslStatus.Installed) {
            ""
        } else {
            "Relancer Installation ou Démarrer en administrateur : WSL2 sera installé automatiquement."
        })))


    $results.Add((Invoke-CrodipHealthCheck `
        -Name "PowerShell" `
        -Severity "CRITICAL" `
        -MaxScore 10 `
        -SuccessMessage "PowerShell compatible." `
        -FailureMessage "Version PowerShell insuffisante." `
        -Correction "Installer PowerShell 7.4 ou supérieur." `
        -Test {
            @{
                Success = $PSVersionTable.PSVersion -ge [version]"7.4"
                Details = $PSVersionTable.PSVersion.ToString()
            }
        }))

    $results.Add((Invoke-CrodipHealthCheck `
        -Name "Runtime" `
        -Severity "CRITICAL" `
        -MaxScore 15 `
        -SuccessMessage "Runtime installé." `
        -FailureMessage "Runtime absent." `
        -Correction "Menu Installation > Installer." `
        -Test {
            @{
                Success = Test-Path -LiteralPath $runtimeHome
                Details = $runtimeHome
            }
        }))

    foreach ($item in @(
        @{
            Name = "runtime.json"
            Path = (Join-Path $runtimeHome "config\runtime.json")
            Severity = "MAJOR"
            MaxScore = 8
        },
        @{
            Name = "compose.yaml"
            Path = (Join-Path $runtimeHome "compose.yaml")
            Severity = "MAJOR"
            MaxScore = 8
        },
        @{
            Name = ".env"
            Path = (Join-Path $runtimeHome ".env")
            Severity = "MAJOR"
            MaxScore = 8
        }
    )) {
        $itemCopy = $item

        $results.Add((Invoke-CrodipHealthCheck `
            -Name $itemCopy.Name `
            -Severity $itemCopy.Severity `
            -MaxScore $itemCopy.MaxScore `
            -SuccessMessage "$($itemCopy.Name) présent." `
            -FailureMessage "$($itemCopy.Name) absent." `
            -Correction "Menu Installation > Réparer." `
            -Test {
                @{
                    Success = Test-Path -LiteralPath $itemCopy.Path
                    Details = $itemCopy.Path
                }
            }))
    }

    $results.Add((Invoke-CrodipHealthCheck `
        -Name "Variables CRODIP" `
        -Severity "IMPORTANT" `
        -MaxScore 8 `
        -SuccessMessage "Variables d'environnement définies." `
        -FailureMessage "Variables d'environnement incomplètes." `
        -Correction "Menu Installation > Réparer." `
        -Test {
            $ok = (
                -not [string]::IsNullOrWhiteSpace($env:CRODIP_HOME) -and
                -not [string]::IsNullOrWhiteSpace($env:CRODIP_DATA_ROOT) -and
                -not [string]::IsNullOrWhiteSpace($env:CRODIP_USER_ROOT)
            )

            @{
                Success = $ok
                Details = "HOME=$env:CRODIP_HOME ; DATA=$env:CRODIP_DATA_ROOT ; USER=$env:CRODIP_USER_ROOT"
            }
        }))

    $requiredDataDirectories = @(
        "sqlite",
        "documents",
        "pdf",
        "photos",
        "signatures",
        "exports",
        "imports",
        "logs",
        "backups",
        "cache",
        "config"
    )

    $results.Add((Invoke-CrodipHealthCheck `
        -Name "Répertoires de données" `
        -Severity "IMPORTANT" `
        -MaxScore 10 `
        -SuccessMessage "Répertoires de données présents." `
        -FailureMessage "Répertoires de données manquants." `
        -Correction "Menu Installation > Réparer." `
        -Test {
            $missing = @(
                $requiredDataDirectories |
                    Where-Object {
                        -not (
                            Test-Path -LiteralPath (
                                Join-Path $dataRoot $_
                            )
                        )
                    }
            )

            @{
                Success = $missing.Count -eq 0
                Details = if ($missing.Count -eq 0) {
                    $dataRoot
                }
                else {
                    "Absents : $($missing -join ', ')"
                }
            }
        }))

    $results.Add((Invoke-CrodipHealthCheck `
        -Name "Docker Desktop" `
        -Severity "CRITICAL" `
        -MaxScore 10 `
        -SuccessMessage "Docker Desktop installé." `
        -FailureMessage "Docker Desktop absent." `
        -Correction "Installer Docker Desktop." `
        -Test {
            $paths = @(
                "$env:ProgramFiles\Docker\Docker\Docker Desktop.exe",
                "$env:LOCALAPPDATA\Docker\Docker Desktop.exe"
            )

            $found = $paths |
                Where-Object {
                    Test-Path -LiteralPath $_
                } |
                Select-Object -First 1

            @{
                Success = [bool]$found
                Details = [string]$found
            }
        }))

    $results.Add((Invoke-CrodipHealthCheck `
        -Name "Docker CLI" `
        -Severity "CRITICAL" `
        -MaxScore 8 `
        -SuccessMessage "Docker CLI disponible." `
        -FailureMessage "Docker CLI indisponible." `
        -Correction "Installer ou réparer Docker Desktop." `
        -Test {
            $command = Get-Command docker -ErrorAction SilentlyContinue

            @{
                Success = [bool]$command
                Details = if ($command) {
                    $command.Source
                }
                else {
                    ""
                }
            }
        }))

    $results.Add((Invoke-CrodipHealthCheck `
        -Name "Docker Engine" `
        -Severity "CRITICAL" `
        -MaxScore 8 `
        -SuccessMessage "Docker Engine opérationnel." `
        -FailureMessage "Docker Engine indisponible." `
        -Correction "Démarrer Docker Desktop." `
        -Test {
            $output = & docker info --format "{{.ServerVersion}}" 2>$null

            @{
                Success = (
                    $LASTEXITCODE -eq 0 -and
                    -not [string]::IsNullOrWhiteSpace($output)
                )
                Details = [string]$output
            }
        }))

    $results.Add((Invoke-CrodipHealthCheck `
        -Name "Docker Compose" `
        -Severity "MAJOR" `
        -MaxScore 5 `
        -SuccessMessage "Docker Compose disponible." `
        -FailureMessage "Docker Compose indisponible." `
        -Correction "Mettre à jour Docker Desktop." `
        -Test {
            $output = & docker compose version 2>$null

            @{
                Success = $LASTEXITCODE -eq 0
                Details = [string]($output -join " ")
            }
        }))

    foreach ($item in @(
        @{
            Name = "Journaux"
            Path = (Join-Path $dataRoot "logs")
        },
        @{
            Name = "Sauvegardes"
            Path = (Join-Path $dataRoot "backups")
        },
        @{
            Name = "Répertoire utilisateur"
            Path = $userRoot
        }
    )) {
        $exists = Test-Path -LiteralPath $item.Path

        $results.Add((New-CrodipHealthResult `
            -Name $item.Name `
            -Status $(if ($exists) { "OK" } else { "WARNING" }) `
            -Severity "MINOR" `
            -Score $(if ($exists) { 1 } else { 0 }) `
            -MaxScore 1 `
            -Message $(if ($exists) {
                "$($item.Name) disponible."
            } else {
                "$($item.Name) absent."
            }) `
            -Details $item.Path `
            -Correction $(if ($exists) {
                ""
            } else {
                "Menu Installation > Réparer."
            })))
    }

    return $results
}

function Get-CrodipHealthSummary {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [object[]]$Results
    )

    $score = ($Results | Measure-Object -Property Score -Sum).Sum
    $maxScore = ($Results | Measure-Object -Property MaxScore -Sum).Sum

    $percentage = if ($maxScore -gt 0) {
        [math]::Round(($score / $maxScore) * 100)
    }
    else {
        0
    }

    $criticalErrors = @(
        $Results |
            Where-Object {
                $_.Status -eq "ERROR" -and
                $_.Severity -eq "CRITICAL"
            }
    ).Count

    $majorErrors = @(
        $Results |
            Where-Object {
                $_.Status -eq "ERROR" -and
                $_.Severity -eq "MAJOR"
            }
    ).Count

    $warnings = @(
        $Results |
            Where-Object {
                $_.Status -eq "WARNING"
            }
    ).Count

    $status = if ($criticalErrors -gt 0) {
        "NOT READY"
    }
    elseif ($majorErrors -gt 0 -or $warnings -gt 0) {
        "READY WITH WARNINGS"
    }
    else {
        "READY"
    }

    [pscustomobject]@{
        Score          = $score
        MaxScore       = $maxScore
        Percentage     = $percentage
        CriticalErrors = $criticalErrors
        MajorErrors    = $majorErrors
        Warnings       = $warnings
        Status         = $status
    }
}

function Export-CrodipHealthReports {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][object[]]$Results,
        [Parameter(Mandatory)][pscustomobject]$Summary,
        [string]$ReportsRoot
    )

    if ([string]::IsNullOrWhiteSpace($ReportsRoot)) {
        $ReportsRoot = Join-Path (
            Get-CrodipDataRoot
        ) "logs\reports"
    }

    $historyRoot = Join-Path $ReportsRoot "history"

    foreach ($path in @($ReportsRoot, $historyRoot)) {
        if (-not (Test-Path -LiteralPath $path)) {
            New-Item `
                -ItemType Directory `
                -Path $path `
                -Force |
                Out-Null
        }
    }

    $timestamp = Get-Date -Format "yyyyMMdd-HHmmss"
    $generatedAt = (Get-Date).ToString("o")

    $payload = [ordered]@{
        generatedAt = $generatedAt
        version = (Get-CrodipRuntimeVersion)
        summary = $Summary
        results = $Results
    }

    $jsonPath = Join-Path $ReportsRoot "runtime-report.json"
    $txtPath = Join-Path $ReportsRoot "runtime-report.txt"
    $mdPath = Join-Path $ReportsRoot "runtime-report.md"

    $payload |
        ConvertTo-Json -Depth 10 |
        Set-Content `
            -LiteralPath $jsonPath `
            -Encoding utf8

    $txtLines = [System.Collections.Generic.List[string]]::new()
    $txtLines.Add("CRODIP Runtime Dashboard")
    $txtLines.Add("Généré : $generatedAt")
    $txtLines.Add("Version : $(Get-CrodipRuntimeVersion)")
    $txtLines.Add("Statut : $($Summary.Status)")
    $txtLines.Add("Score : $($Summary.Percentage)%")
    $txtLines.Add("")

    foreach ($result in $Results) {
        $formattedTextLine = (
            "[{0}] {1} - {2} - {3}" -f @(
                $result.Status,
                $result.Name,
                $result.Message,
                $result.Details
            )
        )

        $txtLines.Add($formattedTextLine)

        if (
            $result.Status -ne "OK" -and
            -not [string]::IsNullOrWhiteSpace($result.Correction)
        ) {
            $txtLines.Add(
                "  Correction : $($result.Correction)"
            )
        }
    }

    $txtLines |
        Set-Content `
            -LiteralPath $txtPath `
            -Encoding utf8

    $mdLines = [System.Collections.Generic.List[string]]::new()
    $mdLines.Add("# CRODIP Runtime Dashboard")
    $mdLines.Add("")
    $mdLines.Add("- Généré : $generatedAt")
    $mdLines.Add("- Version : $(Get-CrodipRuntimeVersion)")
    $mdLines.Add("- Statut : **$($Summary.Status)**")
    $mdLines.Add("- Score : **$($Summary.Percentage)%**")
    $mdLines.Add("")
    $mdLines.Add("| Statut | Contrôle | Gravité | Détails | Correction |")
    $mdLines.Add("|---|---|---|---|---|")

    foreach ($result in $Results) {
        $details = ([string]$result.Details).Replace("|", "\|")

        $correction = if (
            $result.Status -ne "OK" -and
            -not [string]::IsNullOrWhiteSpace($result.Correction)
        ) {
            ([string]$result.Correction).Replace("|", "\|")
        }
        else {
            ""
        }

        $formattedMarkdownLine = (
            "| {0} | {1} | {2} | {3} | {4} |" -f @(
                $result.Status,
                $result.Name,
                $result.Severity,
                $details,
                $correction
            )
        )

        $mdLines.Add($formattedMarkdownLine)
    }

    $mdLines |
        Set-Content `
            -LiteralPath $mdPath `
            -Encoding utf8

    Copy-Item `
        -LiteralPath $jsonPath `
        -Destination (Join-Path $historyRoot "$timestamp.json") `
        -Force

    Copy-Item `
        -LiteralPath $txtPath `
        -Destination (Join-Path $historyRoot "$timestamp.txt") `
        -Force

    Copy-Item `
        -LiteralPath $mdPath `
        -Destination (Join-Path $historyRoot "$timestamp.md") `
        -Force

    [pscustomobject]@{
        Json = $jsonPath
        Text = $txtPath
        Markdown = $mdPath
        History = $historyRoot
    }
}

Export-ModuleMember -Function @(
    "New-CrodipHealthResult",
    "Invoke-CrodipHealthCheck",
    "Get-CrodipRuntimeHealth",
    "Get-CrodipHealthSummary",
    "Export-CrodipHealthReports"
)


