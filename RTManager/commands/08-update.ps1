###############################################################
# CRODIP Runtime Manager
# Script   : commands\08-update.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - DEV Runtime Coherence Fix
###############################################################

#Requires -Version 7.4

[CmdletBinding(SupportsShouldProcess = $true)]
param()

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$moduleRoot = Join-Path $PSScriptRoot "..\modules"

foreach ($moduleName in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1",
            "Crodip.Runtime.DockerProvider.psm1",
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Compose.psm1",
    "Crodip.Runtime.DatabaseMigration.psm1"
)) {
    Import-Module `
        (Join-Path $moduleRoot $moduleName) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

Write-CrodipRuntimeHeader "08-update.ps1"

Write-CrodipStep "Mise à jour Runtime - la sauvegarde PRE-MIGRATION sera imposée par le moteur Alembic si une migration est nécessaire"

$runtimeHome = Get-CrodipHome
$envFile = Join-Path $runtimeHome ".env"

Write-CrodipStep "Synchronisation des images Docker officielles"
$imageEnvironment = Set-CrodipRuntimeImageEnvironment `
    -EnvFile $envFile `
    -Target "local" `
    -Confirm:$false

Write-CrodipSuccess "Application : $($imageEnvironment.ApplicationVersion)"
Write-CrodipSuccess "Mode images : $($imageEnvironment.ReferenceMode)"
Write-CrodipSuccess "Backend : $($imageEnvironment.BackendImage)"
Write-CrodipSuccess "Frontend : $($imageEnvironment.FrontendImage)"

$composeFile = Get-CrodipComposeFile `
    -ApplicationRoot $runtimeHome

if ([string]::IsNullOrWhiteSpace($composeFile)) {
    Write-CrodipError "Aucun fichier Compose trouvé."
    Write-CrodipWarning "Correction : Menu Installation > Réparer."
    return
}

if (-not (Test-CrodipDockerEngine)) {
    if ((Get-CrodipDockerProvider) -eq "desktop") {
        Write-CrodipWarning "Docker Engine arrêté. Démarrage de Docker Desktop..."
        $dockerStarted = Start-CrodipDockerDesktop -WhatIf:$WhatIfPreference -Confirm:$false
    }
    else {
        Write-CrodipWarning "Docker Engine Ubuntu arrêté. Tentative de démarrage..."
        $dockerStarted = Start-CrodipUbuntuDockerEngine
    }

    if (-not $dockerStarted) {
        Write-CrodipError "Docker Engine indisponible pour le provider sélectionné."
        return
    }
}

Write-CrodipStep "Téléchargement des images Docker"

$deploymentMode = Get-CrodipDeploymentMode

$composeServices = @(Get-CrodipComposeServices -ComposeFile $composeFile)

if ($composeServices.Count -eq 0) {
    Write-CrodipError "Aucun service détecté dans compose.yaml."
    return
}

Write-CrodipStep "Services détectés dans Compose"
$services = @()

foreach ($serviceName in $composeServices) {
    $image = Get-CrodipComposeServiceImage -ComposeFile $composeFile -Service $serviceName
    if ([string]::IsNullOrWhiteSpace($image)) { $image = "<build/local>" }

    Write-Host (" - {0,-15} {1}" -f $serviceName, $image)
    $services += [pscustomobject]@{ Name=$serviceName; Image=$image }
}

$serviceResults = @()

foreach ($service in $services) {
    Write-CrodipStep "Pull du service $($service.Name)"

    $pull = Invoke-CrodipCompose `
        -Action "pull" `
        -ComposeFile $composeFile `
        -Services @($service.Name) `
        -Confirm:$false

    if ($pull.ExitCode -eq 0) {
        Write-CrodipSuccess "Service mis à jour : $($service.Name)"

        $serviceResults += [pscustomobject]@{
            Service = $service.Name
            Image   = $service.Image
            Result  = "PULLED"
        }

        continue
    }

    $kind = Get-CrodipDockerPullFailureKind `
        -Output $pull.Output

    Write-CrodipWarning "Pull impossible pour $($service.Name) [$kind]."

    $pull.Output | ForEach-Object {
        Write-Host " $_"
    }

    if ($deploymentMode -eq "online") {
        $serviceResults += [pscustomobject]@{
            Service = $service.Name
            Image   = $service.Image
            Result  = "FAILED_ONLINE"
        }

        continue
    }

    if (
        $deploymentMode -eq "auto" -and
        ($service.Image -ne "<build/local>" -and (Test-CrodipDockerImageLocal -Image $service.Image))
    ) {
        Write-CrodipWarning "Image locale conservée pour $($service.Name)."

        $serviceResults += [pscustomobject]@{
            Service = $service.Name
            Image   = $service.Image
            Result  = "LOCAL"
        }

        continue
    }

    if ($deploymentMode -in @("auto","offline")) {
        Write-CrodipStep "Fallback offline pour $($service.Name)"

        try {
            Import-CrodipOfflineImages
        }
        catch {
            Write-CrodipWarning "Import offline impossible : $($_.Exception.Message)"
        }

        if ($service.Image -ne "<build/local>" -and (Test-CrodipDockerImageLocal -Image $service.Image)) {
            Write-CrodipSuccess "Image offline disponible pour $($service.Name)."

            $serviceResults += [pscustomobject]@{
                Service = $service.Name
                Image   = $service.Image
                Result  = "OFFLINE"
            }

            continue
        }
    }

    Write-CrodipError "Aucune image utilisable pour $($service.Name)."

    $serviceResults += [pscustomobject]@{
        Service = $service.Name
        Image   = $service.Image
        Result  = "MISSING"
    }
}

Write-Host ""
Write-Host "Résumé mise à jour Docker" -ForegroundColor Cyan
Write-Host "--------------------------"

foreach ($r in $serviceResults) {
    Write-Host ("{0,-10} {1,-15} {2}" -f $r.Service, $r.Result, $r.Image)
}

$blocking = @(
    $serviceResults |
        Where-Object {
            $_.Result -in @(
                "FAILED_ONLINE",
                "MISSING"
            )
        }
)

if (
    $deploymentMode -eq "online" -and
    $blocking.Count -gt 0
) {
    Write-CrodipError "Mise à jour incomplète en mode ONLINE."
    return
}

if (
    $deploymentMode -in @("auto","offline") -and
    $blocking.Count -gt 0
) {
    Write-CrodipError "Mise à jour impossible : au moins un service ne possède aucune image utilisable."
    return
}

Write-CrodipSuccess "Mise à jour Docker terminée service par service."

# v2.2.45 : le pull global historique est supprimé.
# Chaque service Compose a déjà été traité ci-dessus avec son propre résultat,
# son fallback AUTO/OFFLINE et son image réellement déclarée dans Compose.
# Cela évite un second téléchargement et la réutilisation de la variable $pull
# issue du dernier service traité.

Write-CrodipStep "Application de la mise à jour"

$upResult = Invoke-CrodipCompose `
    -Action "up" `
    -ComposeFile $composeFile `
    -Detached `
    -RemoveOrphans `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

if ($upResult.ExitCode -ne 0) {
    Write-CrodipError "Échec du redémarrage de la stack CRODIP."

    foreach ($line in $upResult.Output) {
        Write-Host $line
    }

    return
}

if ($WhatIfPreference) {
    Write-CrodipWarning "Mise à jour simulée : aucune modification Docker effectuée."
    return
}

Write-CrodipStep "Migration / validation Alembic LOCAL"
try { $null = Invoke-CrodipRuntimeDatabaseMigration -Target local } catch { Write-CrodipError $_.Exception.Message; return }

Write-CrodipRuntimeLog `
    -Message "Mise à jour Docker Compose terminée" `
    -LogName "update" |
    Out-Null

Write-CrodipSuccess "Mise à jour terminée."
