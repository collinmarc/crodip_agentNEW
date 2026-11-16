###############################################################
# CRODIP Runtime Manager
# Script   : commands\11-docker-admin.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 5 Docker Menu Parser Fix
###############################################################
#Requires -Version 7.4

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$moduleRoot = Join-Path $PSScriptRoot "..\modules"

foreach ($m in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1",
    "Crodip.Runtime.DockerProvider.psm1",
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Compose.psm1"
)) {
    Import-Module `
        (Join-Path $moduleRoot $m) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

foreach ($requiredCommand in @(
    "Get-CrodipDockerProviderInfo",
    "Set-CrodipDockerProvider",
    "Install-CrodipDockerDesktop",
    "Install-CrodipWsl2Prerequisite",
    "Install-CrodipUbuntuDockerEngine",
    "Uninstall-CrodipDockerDesktop",
    "Uninstall-CrodipWslDistribution",
    "Disable-CrodipWslWindowsFeatures",
    "Uninstall-CrodipDockerWslStack"
)) {
    if (-not (Get-Command $requiredCommand -ErrorAction SilentlyContinue)) {
        throw "Commande Docker Provider indisponible : $requiredCommand"
    }
}

do {
    Clear-Host

    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host " Administration Docker" -ForegroundColor Cyan
    Write-Host "========================================" -ForegroundColor Cyan

    $providerInfo = Get-CrodipDockerProviderInfo

    Write-Host "Provider actuel : $($providerInfo.DisplayName)" -ForegroundColor Yellow
    if ($providerInfo.WslDistribution) {
        Write-Host "Distribution WSL : $($providerInfo.WslDistribution)"
    }

    Write-Host ""
    Write-Host "--- Docker Desktop ------------------------------"
    Write-Host "1. Installer Docker Desktop"
    Write-Host "2. Utiliser Docker Desktop"
    Write-Host ""
    Write-Host "--- Docker Engine sous WSL2 ---------------------"
    Write-Host "3. Installer / préparer WSL2 + Ubuntu"
    Write-Host "4. Installer Docker Engine dans Ubuntu / WSL2"
    Write-Host "5. Utiliser Docker Engine Ubuntu / WSL2"
    Write-Host ""
    Write-Host "--- Diagnostic ----------------------------------"
    Write-Host "6. État du provider Docker"
    Write-Host ""
    Write-Host "--- Registre / Déploiement ----------------------"
    Write-Host "7. Connexion GHCR"
    Write-Host "8. Déconnexion GHCR"
    Write-Host "9. Vérifier le registre"
    Write-Host "10. Mode déploiement AUTO"
    Write-Host "11. Mode déploiement ONLINE"
    Write-Host "12. Mode déploiement OFFLINE"
    Write-Host "13. Importer les images offline"
    Write-Host "14. Afficher le mode de déploiement"
    Write-Host ""
    Write-Host "--- Désinstallation ------------------------------"
    Write-Host "15. Désinstaller Docker Desktop"
    Write-Host "16. Supprimer Ubuntu / distribution WSL"
    Write-Host "17. Désactiver les composants Windows WSL2"
    Write-Host "18. Désinstallation complète Docker + Ubuntu + WSL2"
    Write-Host ""
    Write-Host "19. Retour"
    Write-Host ""

    $choice = Read-Host "Votre choix"

    try {
        switch ($choice) {
            "1" {
                Write-CrodipStep "Docker Desktop n'a pas besoin d'une distribution Ubuntu CRODIP dédiée."
                $null = Install-CrodipDockerDesktop -Confirm:$false
                Wait-CrodipUser
            }

            "2" {
                $x = Set-CrodipDockerProvider -Provider desktop
                Write-CrodipSuccess "Provider Docker sélectionné : $($x.DisplayName)"
                Wait-CrodipUser
            }

            "3" {
                $d = Read-Host "Distribution WSL [Ubuntu]"
                if ([string]::IsNullOrWhiteSpace($d)) {
                    $d = "Ubuntu"
                }

                $result = Install-CrodipWsl2Prerequisite `
                    -Distribution $d `
                    -Confirm:$false

                if ($result.RebootRequired) {
                    Write-CrodipWarning "Redémarrage Windows recommandé avant de poursuivre."
                }

                Wait-CrodipUser
            }

            "4" {
                $d = Read-Host "Distribution WSL [Ubuntu]"
                if ([string]::IsNullOrWhiteSpace($d)) {
                    $d = "Ubuntu"
                }

                $null = Install-CrodipUbuntuDockerEngine `
                    -Distribution $d `
                    -Confirm:$false

                Wait-CrodipUser
            }

            "5" {
                $d = Read-Host "Distribution WSL [Ubuntu]"
                if ([string]::IsNullOrWhiteSpace($d)) {
                    $d = "Ubuntu"
                }

                $x = Set-CrodipDockerProvider `
                    -Provider ubuntu `
                    -WslDistribution $d

                Write-CrodipSuccess "Provider Docker sélectionné : $($x.DisplayName) / $d"

                if (-not (Test-CrodipWslDistribution -Distribution $d)) {
                    Write-CrodipWarning "Distribution WSL '$d' absente."
                }

                Wait-CrodipUser
            }

            "6" {
                $x = Get-CrodipDockerProviderInfo

                Write-Host "Provider                : $($x.DisplayName)"
                Write-Host "Distribution WSL        : $($x.WslDistribution)"
                Write-Host "Docker Desktop installé : $(Test-CrodipDockerDesktopInstalled)"
                Write-Host "Docker Ubuntu installé  : $(Test-CrodipUbuntuDockerInstalled)"
                Write-Host "Engine actif            : $($x.EngineRunning)"
                Write-Host "Version serveur         : $($x.ServerVersion)"

                if ((Get-CrodipDockerProvider) -eq "desktop") {
                    $ready = Test-CrodipDockerDesktopReadiness
                    Write-Host "WSL installé            : $($ready.WslInstalled)"
                    Write-Host "Distribution WSL        : $($ready.WslDistribution)"
                    Write-Host "Docker Desktop READY    : $($ready.Ready)"
                }

                Wait-CrodipUser
            }

            "7" {
                Connect-CrodipRegistry
                Wait-CrodipUser
            }

            "8" {
                Disconnect-CrodipRegistry
                Wait-CrodipUser
            }

            "9" {
                $status = Get-CrodipRegistryStatus
                Write-Host "Registre              : $($status.Registry)"
                Write-Host "Réseau disponible     : $($status.NetworkAvailable)"
                Write-Host "Credential configuré  : $($status.CredentialsConfigured)"
                Write-Host "Accès lecture GHCR    : $($status.ReadAccess)"
                Write-Host "Image de test         : $($status.TestImage)"

                if ($status.ReadAccess) {
                    Write-CrodipSuccess "Accès GHCR opérationnel."
                }
                elseif ($status.CredentialsConfigured) {
                    Write-CrodipWarning "Credential Docker détecté mais accès GHCR non validé."
                }
                else {
                    Write-CrodipWarning "Aucune authentification GHCR opérationnelle détectée."
                }

                Wait-CrodipUser
            }

            "10" {
                Set-CrodipEnvValue `
                    -Name "CRODIP_DEPLOYMENT_MODE" `
                    -Value "auto"

                Write-CrodipSuccess "Mode AUTO activé."
                Wait-CrodipUser
            }

            "11" {
                Set-CrodipEnvValue `
                    -Name "CRODIP_DEPLOYMENT_MODE" `
                    -Value "online"

                Write-CrodipSuccess "Mode ONLINE activé."
                Wait-CrodipUser
            }

            "12" {
                Set-CrodipEnvValue `
                    -Name "CRODIP_DEPLOYMENT_MODE" `
                    -Value "offline"

                Write-CrodipSuccess "Mode OFFLINE activé."
                Wait-CrodipUser
            }

            "13" {
                Import-CrodipOfflineImages
                Wait-CrodipUser
            }

            "14" {
                Write-CrodipSuccess "Mode actuel : $(Get-CrodipDeploymentMode)"
                Wait-CrodipUser
            }

            "15" {
                $null = Uninstall-CrodipDockerDesktop
                Wait-CrodipUser
            }

            "16" {
                $d = Read-Host "Distribution WSL à supprimer [Ubuntu]"
                if ([string]::IsNullOrWhiteSpace($d)) {
                    $d = "Ubuntu"
                }

                $null = Uninstall-CrodipWslDistribution -Distribution $d
                Wait-CrodipUser
            }

            "17" {
                $null = Disable-CrodipWslWindowsFeatures
                Wait-CrodipUser
            }

            "18" {
                $d = Read-Host "Distribution WSL [Ubuntu]"
                if ([string]::IsNullOrWhiteSpace($d)) {
                    $d = "Ubuntu"
                }

                $null = Uninstall-CrodipDockerWslStack -Distribution $d
                Wait-CrodipUser
            }

            "19" {
                return
            }

            default {
                Write-CrodipWarning "Choix invalide."
                Start-Sleep -Seconds 1
            }
        }
    }
    catch {
        Write-CrodipError $_.Exception.Message
        Wait-CrodipUser
    }
}
while ($true)
