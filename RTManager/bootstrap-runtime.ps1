###############################################################
# CRODIP Runtime Manager
# Script   : bootstrap-runtime.ps1
# Version  : 2.3.0-RC41
# Statut   : Release Candidate - Safe Database Migration & Release Compatibility
###############################################################

#Requires -Version 7.4

[CmdletBinding()]
param(
    [switch]$AutoStart
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$moduleRoot = Join-Path $PSScriptRoot "modules"

$requiredModules = @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1",
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Compose.psm1",
    "Crodip.Runtime.Health.psm1"
)

try {
    foreach ($moduleName in $requiredModules) {
        $modulePath = Join-Path $moduleRoot $moduleName

        if (-not (Test-Path -LiteralPath $modulePath)) {
            throw "Module requis absent : $modulePath"
        }

        Import-Module `
            $modulePath `
            -Force `
            -DisableNameChecking `
            -ErrorAction Stop
    }


    $providerModulePath = Join-Path $moduleRoot "Crodip.Runtime.DockerProvider.psm1"

    if (-not (Test-Path -LiteralPath $providerModulePath -PathType Leaf)) {
        throw "Module Docker Provider absent : $providerModulePath"
    }

    $null = Get-CrodipRuntimeConfig

    Write-CrodipRuntimeLog `
        -Message "Démarrage du Runtime Manager" `
        -LogName "runtime" |
        Out-Null
}
catch {
    Write-Host `
        "[ERREUR] Initialisation impossible : $($_.Exception.Message)" `
        -ForegroundColor Red
    exit 1
}

# RC41 FIX4 : une commande enfant peut réimporter un module avec -Force et
# invalider les commandes exportées visibles par le bootstrap. Le bootstrap
# restaure donc explicitement ses helpers avant de reprendre le menu.
function Restore-CrodipBootstrapHelpers {
    [CmdletBinding()]
    param()

    foreach ($moduleName in @(
        "Crodip.Runtime.Common.psm1",
        "Crodip.Runtime.Logging.psm1"
    )) {
        $modulePath = Join-Path $moduleRoot $moduleName
        if (Test-Path -LiteralPath $modulePath -PathType Leaf) {
            Import-Module $modulePath -Force -DisableNameChecking -ErrorAction Stop
        }
    }
}

function Invoke-CrodipMenuCommand {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$RelativePath,

        [hashtable]$Arguments
    )

    $commandPath = Join-Path $PSScriptRoot $RelativePath

    if (-not (Test-Path -LiteralPath $commandPath)) {
        $message = "Commande absente : $commandPath"
        if (Get-Command Write-CrodipError -ErrorAction SilentlyContinue) {
            Write-CrodipError $message
        }
        else {
            Write-Host "[ERREUR] $message" -ForegroundColor Red
        }
        return
    }

    try {
        if ($Arguments) {
            & $commandPath @Arguments
        }
        else {
            & $commandPath
        }
    }
    catch {
        $errorMessage = $_.Exception.Message
        if (Get-Command Write-CrodipError -ErrorAction SilentlyContinue) {
            Write-CrodipError $errorMessage
        }
        else {
            Write-Host "[ERREUR] $errorMessage" -ForegroundColor Red
        }

        # La journalisation ne doit jamais masquer l'erreur métier ni casser le retour au menu.
        $runtimeLogCommand = Get-Command Write-CrodipRuntimeLog -ErrorAction SilentlyContinue
        if ($runtimeLogCommand) {
            try {
                Write-CrodipRuntimeLog `
                    -Message "Échec $RelativePath : $errorMessage" `
                    -Level "ERROR" `
                    -LogName "runtime" |
                    Out-Null
            }
            catch {
                Write-Host "[ATTENTION] Journalisation Runtime impossible : $($_.Exception.Message)" -ForegroundColor Yellow
            }
        }
    }
    finally {
        # RC41 FIX4 : Wait-CrodipUser et les autres helpers restent la responsabilité du bootstrap.
        Restore-CrodipBootstrapHelpers
    }
}

function Show-CrodipInstallationMenu {
    do {
        Clear-Host
        Write-Host "========================================" -ForegroundColor Cyan
        Write-Host " Installation CRODIP" -ForegroundColor Cyan
        Write-Host "========================================" -ForegroundColor Cyan
        Write-Host ""
        Write-Host "1. Installer"
        Write-Host "2. Réparer"
        Write-Host "3. Vérifier l'installation"
        Write-Host "4. Réinstaller"
        Write-Host "5. Désinstaller"
        Write-Host "6. Retour"
        Write-Host ""

        $installationChoice = Read-Host "Votre choix"

        switch ($installationChoice) {
            "1" {
                Invoke-CrodipMenuCommand `
                    "commands\01-install.ps1"
                Wait-CrodipUser
            }
            "2" {
                Invoke-CrodipMenuCommand `
                    "commands\01-repair.ps1"
                Wait-CrodipUser
            }
            "3" {
                Invoke-CrodipMenuCommand `
                    "commands\01-check-install.ps1"
                Wait-CrodipUser
            }
            "4" {
                Invoke-CrodipMenuCommand `
                    "commands\01-reinstall.ps1"
                Wait-CrodipUser
            }
            "5" {
                Invoke-CrodipMenuCommand `
                    "commands\10-uninstall.ps1"
                Wait-CrodipUser
            }
            "6" {
                return
            }
            default {
                Write-CrodipWarning "Choix invalide."
                Start-Sleep -Seconds 1
            }
        }
    }
    while ($true)
}

function Show-CrodipLocalRuntimeMenu {
    do {
        Clear-Host
        $config = Get-CrodipRuntimeConfig
        Write-Host "============================================================" -ForegroundColor Cyan
        Write-Host "                     RUNTIME LOCAL" -ForegroundColor Cyan
        Write-Host "============================================================" -ForegroundColor Cyan
        Write-Host ""
        Write-Host ("Runtime      : {0}" -f (Get-CrodipRuntimeVersion))
        Write-Host ("Application  : {0}" -f $config.compatibility.applicationVersion)
        Write-Host "Base         : SQLite"
        Write-Host "Frontend     : http://localhost:9110"
        Write-Host "Backend      : http://localhost:8110"
        Write-Host ""
        Write-Host "1. Installation"
        Write-Host "2. Démarrer"
        Write-Host "3. Arrêter"
        Write-Host "4. État"
        Write-Host "5. Mettre à jour"
        Write-Host "6. Journaux"
        Write-Host "7. Désinstaller"
        Write-Host "8. Retour"
        Write-Host ""

        $localChoice = Read-Host "Votre choix"
        switch ($localChoice) {
            "1" { Show-CrodipInstallationMenu }
            "2" { Invoke-CrodipMenuCommand "commands\03-start.ps1"; Wait-CrodipUser }
            "3" { Invoke-CrodipMenuCommand "commands\04-stop.ps1"; Wait-CrodipUser }
            "4" { Invoke-CrodipMenuCommand "commands\05-status.ps1"; Wait-CrodipUser }
            "5" { Invoke-CrodipMenuCommand "commands\08-update.ps1"; Wait-CrodipUser }
            "6" { Invoke-CrodipMenuCommand "commands\09-logs.ps1"; Wait-CrodipUser }
            "7" { Invoke-CrodipMenuCommand "commands\10-uninstall.ps1"; Wait-CrodipUser }
            "8" { return }
            default { Write-CrodipWarning "Choix invalide."; Start-Sleep -Seconds 1 }
        }
    }
    while ($true)
}

function Show-CrodipBackupMenu {
    do {
        Clear-Host
        Write-Host "========================================" -ForegroundColor Cyan
        Write-Host " Sauvegarde CRODIP" -ForegroundColor Cyan
        Write-Host "========================================" -ForegroundColor Cyan
        Write-Host ""
        Write-Host "1. Sauvegarde rapide"
        Write-Host "2. Sauvegarde complète"
        Write-Host "3. Retour"
        Write-Host ""

        $backupChoice = Read-Host "Votre choix"

        switch ($backupChoice) {
            "1" {
                Invoke-CrodipMenuCommand `
                    "commands\06-backup.ps1" `
                    @{ Mode = "quick" }
                Wait-CrodipUser
            }
            "2" {
                Invoke-CrodipMenuCommand `
                    "commands\06-backup.ps1" `
                    @{ Mode = "full" }
                Wait-CrodipUser
            }
            "3" {
                return
            }
            default {
                Write-CrodipWarning "Choix invalide."
                Start-Sleep -Seconds 1
            }
        }
    }
    while ($true)
}

if ($AutoStart) {
    Invoke-CrodipMenuCommand "commands\03-start.ps1"
    return
}

do {
    Clear-Host
    $config = Get-CrodipRuntimeConfig
    Write-Host "============================================================" -ForegroundColor Cyan
    Write-Host ("           CRODIP SaaS Runtime Manager {0}" -f (Get-CrodipRuntimeVersion)) -ForegroundColor Cyan
    Write-Host "============================================================" -ForegroundColor Cyan
    Write-Host ""
    Write-Host ("Application : {0}" -f $config.compatibility.applicationVersion)
    Write-Host ("Cycle       : {0}" -f $config.docker.activeLifecycle)
    Write-Host ("Connectivité: {0}" -f (Get-CrodipDeploymentMode).ToUpperInvariant())
    Write-Host ""
    Write-Host "-------------------- RUNTIMES -------------------------------"
    Write-Host " 1. Runtime LOCAL"
    Write-Host " 2. Runtime CENTRAL"
    Write-Host ""
    Write-Host "-------------------- DONNÉES --------------------------------"
    Write-Host " 3. Sauvegarder"
    Write-Host " 4. Restaurer"
    Write-Host " 5. Vérifier les bases de données"
    Write-Host ""
    Write-Host "-------------------- RELEASE / TEST --------------------------"
    Write-Host " 6. Qualification technique Runtime"
    Write-Host " 7. Mettre à jour la release TEST"
    Write-Host " 8. Changer la release Runtime TEST"
    Write-Host " 9. Revenir à la release officielle"
    Write-Host "10. Informations sur la release active"
    Write-Host ""
    Write-Host "-------------------- SYSTÈME --------------------------------"
    Write-Host "11. Vérifier l'environnement"
    Write-Host "12. Administration Docker"
    Write-Host "13. Journaux LOCAL"
    Write-Host "14. Informations système"
    Write-Host "15. Composants techniques"
    Write-Host "16. GitHub CLI / Authentification"
    Write-Host ""
    Write-Host "------------------------------------------------------------"
    Write-Host "17. Quitter"
    Write-Host ""

    $choice = Read-Host "Votre choix"
    switch ($choice) {
        "1" { Show-CrodipLocalRuntimeMenu }
        "2" { Invoke-CrodipMenuCommand "commands\12-central-runtime.ps1" }
        "3" { Show-CrodipBackupMenu }
        "4" { Invoke-CrodipMenuCommand "commands\07-restore.ps1"; Wait-CrodipUser }
        "5" { Invoke-CrodipMenuCommand "commands\19-verify-databases.ps1"; Wait-CrodipUser }
        "6" { Invoke-CrodipMenuCommand "commands\13-qualify-runtime.ps1"; Wait-CrodipUser }
        "7" { Invoke-CrodipMenuCommand "commands\14-update-test-release.ps1"; Wait-CrodipUser }
        "8" { Invoke-CrodipMenuCommand "commands\17-historical-test-run.ps1"; Wait-CrodipUser }
        "9" { & (Join-Path $PSScriptRoot "commands\17-historical-test-run.ps1") -Action restore; Wait-CrodipUser }
        "10" { Invoke-CrodipMenuCommand "commands\18-active-run-info.ps1"; Wait-CrodipUser }
        "11" { Invoke-CrodipMenuCommand "commands\02-check.ps1"; Wait-CrodipUser }
        "12" {
            $dockerAdminPath = Join-Path $PSScriptRoot "commands\11-docker-admin.ps1"
            if (-not (Test-Path -LiteralPath $dockerAdminPath -PathType Leaf)) {
                Write-CrodipError "Menu Administration Docker absent : $dockerAdminPath"
                Wait-CrodipUser
                continue
            }
            try { & $dockerAdminPath }
            catch { Write-CrodipError "Administration Docker : $($_.Exception.Message)"; Wait-CrodipUser }
        }
        "13" { Invoke-CrodipMenuCommand "commands\09-logs.ps1"; Wait-CrodipUser }
        "14" { Invoke-CrodipMenuCommand "commands\12-system-info.ps1"; Wait-CrodipUser }
        "15" { Invoke-CrodipMenuCommand "commands\16-technical-components.ps1"; Wait-CrodipUser }
        "16" { Invoke-CrodipMenuCommand "commands\15-github-cli.ps1"; Wait-CrodipUser }
        "17" { return }
        default { Write-CrodipWarning "Choix invalide."; Start-Sleep -Seconds 1 }
    }
}
while ($true)
