###############################################################
# CRODIP Runtime Manager
# Script   : commands\01-install.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 2 Clean
###############################################################

#Requires -Version 7.4

[CmdletBinding(SupportsShouldProcess = $true)]
param()

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$preflightModule = Join-Path (Join-Path $PSScriptRoot "..\modules") "Crodip.Runtime.Preflight.psm1"
Import-Module $preflightModule -Force -DisableNameChecking -ErrorAction Stop


# ------------------------------------------------------------------
# Chargement des modules
# ------------------------------------------------------------------

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

Import-Module `
    (Join-Path $PSScriptRoot "..\modules\Crodip.Runtime.GitHub.psm1") `
    -Force `
    -DisableNameChecking

Import-Module `
    (Join-Path $PSScriptRoot "..\modules\Crodip.Runtime.DockerProvider.psm1") `
    -Force `
    -DisableNameChecking


Write-CrodipRuntimeHeader "01-install.ps1"

# ------------------------------------------------------------------
# Vérification des droits administrateur
# ------------------------------------------------------------------

if (-not (Test-CrodipAdministrator)) {
    Write-CrodipError "Ouvrir PowerShell 7 en administrateur."
    return
}

# ------------------------------------------------------------------
# Composants techniques — GitHub CLI
# ------------------------------------------------------------------
# GitHub CLI est un composant technique du Runtime au même titre que
# les prérequis nécessaires à Docker. Sur une installation fraîche,
# il est installé automatiquement via Winget s'il est absent.
#
# L'authentification n'est PAS forcée ici : elle est demandée lors
# de la première utilisation d'une fonction GitHub (menu 14 ou 15).

if (-not $WhatIfPreference) {
    if (-not (Test-CrodipGitHubCli)) {
        Write-CrodipStep "Composant technique absent : GitHub CLI"
        if (-not (Install-CrodipGitHubCli)) {
            Write-CrodipWarning "GitHub CLI n'est pas opérationnel."
            Write-CrodipWarning "L'installation Runtime continue, mais les mises à jour TEST via GitHub seront indisponibles."
            Write-CrodipWarning "Utiliser ensuite le menu 15 pour installer/réparer GitHub CLI."
        }
    }
    else {
        Write-CrodipSuccess "GitHub CLI déjà installé."
    }
}
else {
    Write-CrodipWarning "[WhatIf] GitHub CLI serait installé via Winget s'il est absent."
}

# ------------------------------------------------------------------
# Initialisation des répertoires
# ------------------------------------------------------------------

$paths = Initialize-CrodipDirectories `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

$runtimeHome = $paths.Home
$dataRoot = $paths.Data
$userRoot = $paths.User

$sourceRoot = Split-Path -Parent $PSScriptRoot

# RC39 - SQLite doit rester inscriptible depuis le bind mount Docker.
Set-CrodipSqliteWriteAcl -SqlitePath (Join-Path $dataRoot "sqlite") -WhatIf:$WhatIfPreference -Confirm:$false

# ------------------------------------------------------------------
# Variables d'environnement
# ------------------------------------------------------------------

Set-CrodipEnvironmentVariables `
    -RuntimeHome $runtimeHome `
    -DataRoot $dataRoot `
    -UserRoot $userRoot `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

# ------------------------------------------------------------------
# Copie des répertoires du Runtime
# ------------------------------------------------------------------

$copyDirectories = @(
    "commands",
    "modules",
    "config",
    "templates",
    "images",
    "docs"
)

foreach ($directoryName in $copyDirectories) {
    $sourcePath = Join-Path $sourceRoot $directoryName
    $destinationPath = Join-Path $runtimeHome $directoryName

    if (-not (Test-Path -LiteralPath $sourcePath)) {
        Write-CrodipWarning "Répertoire source absent : $sourcePath"
        continue
    }

    if (
        $PSCmdlet.ShouldProcess(
            $destinationPath,
            "Copier le répertoire $directoryName"
        )
    ) {
        Copy-Item `
            -LiteralPath $sourcePath `
            -Destination $runtimeHome `
            -Recurse `
            -Force
    }
}

# ------------------------------------------------------------------
# Copie des fichiers principaux
# ------------------------------------------------------------------

$rootFiles = @(
    "bootstrap-runtime.ps1",
    "VERSION",
    "STATUS",
    "README.md",
    "CHANGELOG.md"
)

foreach ($fileName in $rootFiles) {
    $sourceFile = Join-Path $sourceRoot $fileName
    $destinationFile = Join-Path $runtimeHome $fileName

    if (-not (Test-Path -LiteralPath $sourceFile)) {
        Write-CrodipWarning "Fichier source absent : $sourceFile"
        continue
    }

    if (
        $PSCmdlet.ShouldProcess(
            $destinationFile,
            "Copier le fichier $fileName"
        )
    ) {
        Copy-Item `
            -LiteralPath $sourceFile `
            -Destination $destinationFile `
            -Force
    }
}

# ------------------------------------------------------------------
# Création du fichier .env
# ------------------------------------------------------------------

$envExample = Join-Path $runtimeHome "templates\.env.example"
$envFile = Join-Path $runtimeHome ".env"

if (-not (Test-Path -LiteralPath $envExample)) {
    Write-CrodipWarning "Template .env absent : $envExample"
}
elseif (-not (Test-Path -LiteralPath $envFile)) {
    if (
        $PSCmdlet.ShouldProcess(
            $envFile,
            "Créer le fichier .env"
        )
    ) {
        Copy-Item `
            -LiteralPath $envExample `
            -Destination $envFile `
            -Force
    }
}

else {
    Write-CrodipSuccess "Configuration .env existante conservée."
}

# Les images Docker sont toujours réalignées sur la source de vérité
# config\runtime.json -> docker.imageTag / docker.imageRepositories.
$imageEnvironment = Set-CrodipRuntimeImageEnvironment `
    -EnvFile $envFile `
    -Target "local" `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

if (-not $WhatIfPreference) {
    Write-CrodipSuccess "Application : $($imageEnvironment.ApplicationVersion)"
    Write-CrodipSuccess "Mode images : $($imageEnvironment.ReferenceMode)"
    Write-CrodipSuccess "Backend : $($imageEnvironment.BackendImage)"
    Write-CrodipSuccess "Frontend : $($imageEnvironment.FrontendImage)"
}

# ------------------------------------------------------------------
# Création du fichier compose.yaml
# ------------------------------------------------------------------

$composeTemplate = Join-Path $runtimeHome "templates\compose.yaml"
$composeFile = Join-Path $runtimeHome "compose.yaml"

if (-not (Test-Path -LiteralPath $composeTemplate)) {
    Write-CrodipWarning "Template compose.yaml absent : $composeTemplate"
}
elseif (-not (Test-Path -LiteralPath $composeFile)) {
    if (
        $PSCmdlet.ShouldProcess(
            $composeFile,
            "Créer compose.yaml"
        )
    ) {
        Copy-Item `
            -LiteralPath $composeTemplate `
            -Destination $composeFile `
            -Force
    }
}
else {
    Write-CrodipSuccess "Configuration compose.yaml existante conservée."
}

# ------------------------------------------------------------------
# Création des raccourcis
# ------------------------------------------------------------------

$desktopShortcut = Join-Path `
    ([Environment]::GetFolderPath("Desktop")) `
    "CRODIP Runtime Manager.lnk"

$startMenuShortcut = Join-Path `
    $env:APPDATA `
    "Microsoft\Windows\Start Menu\Programs\CRODIP Runtime Manager.lnk"

New-CrodipShortcut `
    -ShortcutPath $desktopShortcut `
    -RuntimeHome $runtimeHome `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

New-CrodipShortcut `
    -ShortcutPath $startMenuShortcut `
    -RuntimeHome $runtimeHome `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false

# ------------------------------------------------------------------
# Fin de simulation
# ------------------------------------------------------------------

if ($WhatIfPreference) {
    Write-CrodipWarning `
        "Installation simulée : aucune modification effectuée."
    return
}

# ------------------------------------------------------------------
# Journalisation
# ------------------------------------------------------------------

Write-CrodipRuntimeLog `
    -Message "Runtime installé dans $runtimeHome" `
    -LogName "install" |
    Out-Null

# ------------------------------------------------------------------
# Résumé
# ------------------------------------------------------------------

Write-Host ""
Write-CrodipSuccess "Installation terminée."
Write-CrodipSuccess "Application : $runtimeHome"
Write-CrodipSuccess "Données     : $dataRoot"
Write-CrodipSuccess "Utilisateur : $userRoot"
Write-CrodipSuccess "Compose     : $composeFile"

# ------------------------------------------------------------------
# Pré-requis Docker Desktop : WSL2
# ------------------------------------------------------------------

# Préflight bloquant avant WSL2 / Docker Linux
try {
    $null = Assert-CrodipHardwareWindowsPreflight
}
catch {
    Write-CrodipError $_.Exception.Message
    return
}

if ((Get-CrodipDockerProvider) -eq "desktop") {
    $wslState = Ensure-CrodipWsl2Prerequisite `
        -Distribution (Get-CrodipWslDistribution) `
        -InstallIfMissing

    if (-not $wslState.Ready) {
        if ($wslState.InstalledNow) {
            Write-CrodipSuccess "Installation automatique de WSL2 lancée."
        }

        if ($wslState.RebootRequired) {
            Write-CrodipWarning "Redémarrage Windows requis."
            Write-CrodipWarning "Après redémarrage, relancer le Runtime Manager puis Installation."
        }

        return
    }
}


# ------------------------------------------------------------------
# Docker Desktop — installation automatique si absent
# ------------------------------------------------------------------

if ((Get-CrodipDockerProvider) -eq "desktop") {
    if (-not (Test-CrodipDockerDesktopInstalled)) {
        Write-CrodipStep "Composant technique absent : Docker Desktop"
        Write-CrodipStep "Installation automatique via Winget"

        try {
            $runtimeConfigPath = Join-Path $PSScriptRoot "..\config\runtime.json"
            $runtimeConfig = Get-Content -LiteralPath $runtimeConfigPath -Raw | ConvertFrom-Json
            $wingetInactivityTimeout = 900
            $wingetProgressInterval = 15
            $wingetMaximumDuration = 0
            if ($runtimeConfig.technicalComponents.dockerDesktop.PSObject.Properties.Name -contains "wingetInactivityTimeoutSeconds") {
                $wingetInactivityTimeout = [int]$runtimeConfig.technicalComponents.dockerDesktop.wingetInactivityTimeoutSeconds
            }
            if ($runtimeConfig.technicalComponents.dockerDesktop.PSObject.Properties.Name -contains "wingetProgressIntervalSeconds") {
                $wingetProgressInterval = [int]$runtimeConfig.technicalComponents.dockerDesktop.wingetProgressIntervalSeconds
            }
            if ($runtimeConfig.technicalComponents.dockerDesktop.PSObject.Properties.Name -contains "wingetMaximumDurationSeconds") {
                $wingetMaximumDuration = [int]$runtimeConfig.technicalComponents.dockerDesktop.wingetMaximumDurationSeconds
            }
            $dockerInstalled = Install-CrodipDockerDesktop `
                -InactivityTimeoutSeconds $wingetInactivityTimeout `
                -ProgressIntervalSeconds $wingetProgressInterval `
                -MaximumDurationSeconds $wingetMaximumDuration `
                -Confirm:$false
        }
        catch {
            Write-CrodipError "Installation Docker Desktop : $($_.Exception.Message)"
            Write-CrodipWarning "Corriger le prérequis puis relancer Installation."
            return
        }

        if (-not $dockerInstalled) {
            Write-CrodipError "Docker Desktop n'a pas pu être installé."
            return
        }

        # Rafraîchir le PATH de la session après Winget.
        $env:Path = "$([Environment]::GetEnvironmentVariable('Path','Machine'));$([Environment]::GetEnvironmentVariable('Path','User'))"
        Write-CrodipSuccess "Docker Desktop installé."
    }
    else {
        Write-CrodipSuccess "Docker Desktop déjà installé."
    }

    # Un Docker Desktop installé avec moteur arrêté ne doit pas être
    # réinstallé. On démarre l'application et on attend le moteur.
    $dockerState = Test-CrodipDockerDesktopReadiness

    if (-not $dockerState.EngineReady) {
        $dockerDesktopExe = Join-Path $env:ProgramFiles "Docker\Docker\Docker Desktop.exe"

        if (Test-Path -LiteralPath $dockerDesktopExe -PathType Leaf) {
            Write-CrodipStep "Démarrage de Docker Desktop"
            Start-Process -FilePath $dockerDesktopExe | Out-Null
        }

        Write-CrodipStep "Attente du moteur Docker"
        $deadline = (Get-Date).AddSeconds(120)
        do {
            Start-Sleep -Seconds 3
            $dockerState = Test-CrodipDockerDesktopReadiness
        } while ((-not $dockerState.EngineReady) -and ((Get-Date) -lt $deadline))
    }

    if (-not $dockerState.EngineReady) {
        Write-CrodipWarning "Docker Desktop est installé mais le moteur Docker n'est pas encore opérationnel."
        Write-CrodipWarning "Si Windows ou Docker demande un redémarrage, redémarrer le poste puis relancer Installation."
        return
    }

    Write-CrodipSuccess "Docker Engine opérationnel."

    # Qualification minimale du socle Docker.
    $dockerVersion = Invoke-CrodipDockerCli -Arguments @("--version")
    if ($dockerVersion.ExitCode -ne 0) {
        Write-CrodipError "docker --version a échoué."
        return
    }

    $composeVersion = Invoke-CrodipDockerCli -Arguments @("compose","version")
    if ($composeVersion.ExitCode -ne 0) {
        Write-CrodipError "docker compose version a échoué."
        return
    }

    $dockerInfo = Invoke-CrodipDockerCli -Arguments @("info","--format","{{.ServerVersion}}")
    if ($dockerInfo.ExitCode -ne 0) {
        Write-CrodipError "docker info a échoué."
        return
    }

    Write-CrodipSuccess "Docker CLI / Compose / Engine qualifiés."
}

# Normalisation systématique du Compose Runtime installé
$normalizeCompose = Join-Path $PSScriptRoot "01-normalize-compose.ps1"
if(Test-Path -LiteralPath $normalizeCompose){
    try{
        & $normalizeCompose -NonInteractive
    }
    catch{
        Write-CrodipWarning "Normalisation Compose : $($_.Exception.Message)"
    }
}

Write-CrodipSuccess "Configuration : $envFile"