###############################################################
# CRODIP Runtime Manager
# Script   : commands\03-start.ps1
# Version  : 2.3.0-RC23
# Statut   : Stable - Lot 5 Compose Project Isolation
###############################################################

[CmdletBinding(SupportsShouldProcess = $true)]
param([switch]$NoBrowser)

#Requires -Version 7.4

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$preflightModule = Join-Path (Join-Path $PSScriptRoot "..\modules") "Crodip.Runtime.Preflight.psm1"
Import-Module $preflightModule -Force -DisableNameChecking -ErrorAction Stop


$moduleRoot = Join-Path $PSScriptRoot "..\modules"
foreach ($moduleName in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1",
            "Crodip.Runtime.DockerProvider.psm1",
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Compose.psm1",
    "Crodip.Runtime.DatabaseMigration.psm1",
    "Crodip.Runtime.Performance.psm1"
)) {
    Import-Module (Join-Path $moduleRoot $moduleName) -Force -DisableNameChecking -ErrorAction Stop
}

# RC20 - garde de chargement : la réconciliation ne doit jamais démarrer si l'API du module Compose n'est pas exportée.
foreach ($requiredCommand in @(
    "Repair-CrodipRuntimePublishedPortBindings",
    "Test-CrodipRuntimePublishedPortBindings"
)) {
    if ($null -eq (Get-Command $requiredCommand -CommandType Function -ErrorAction SilentlyContinue)) {
        throw "Fonction Runtime Compose requise non chargée/exportée : $requiredCommand"
    }
}

Write-CrodipRuntimeHeader "03-start.ps1"

$performanceSession=New-CrodipPerformanceSession -Name "Démarrage Runtime" -Type "startup"

$config = Get-CrodipRuntimeConfig
$composeFile = Get-CrodipComposeFile

# RC23 - le Runtime LOCAL possède son propre .env, créé et synchronisé avant Compose.
$runtimeHome = Get-CrodipHome
$localEnvFile = Join-Path $runtimeHome ".env"
$localEnvTemplate = Join-Path $runtimeHome "templates\.env.example"
if(-not(Test-Path -LiteralPath $localEnvFile -PathType Leaf)){
    if(-not(Test-Path -LiteralPath $localEnvTemplate -PathType Leaf)){ throw "Template .env LOCAL absent : $localEnvTemplate" }
    Copy-Item -LiteralPath $localEnvTemplate -Destination $localEnvFile -Force
    Write-CrodipSuccess "Fichier .env LOCAL créé : $localEnvFile"
}
$null = Set-CrodipRuntimeImageEnvironment -EnvFile $localEnvFile -Target "local" -Confirm:$false

# RC18: imposer dans le processus courant les ports du cycle de vie actif.
# Une variable d'environnement héritée (ex. DEV=9010) a priorité sur .env dans Docker Compose.
$lifecycle = [string]$config.docker.activeLifecycle
$lifecycleNode = $config.docker.lifecyclePorts.PSObject.Properties[$lifecycle]
if ($null -eq $lifecycleNode) { throw "Profil de ports absent pour le cycle de vie '$lifecycle'." }
$localPorts = $lifecycleNode.Value.PSObject.Properties['local']
if ($null -eq $localPorts) { throw "Profil de ports LOCAL absent pour le cycle de vie '$lifecycle'." }
$env:CRODIP_BACKEND_PORT = [string][int]$localPorts.Value.backend
$env:CRODIP_FRONTEND_PORT = [string][int]$localPorts.Value.frontend
Write-CrodipStep ("Ports actifs {0}/LOCAL : backend={1}, frontend={2}" -f $lifecycle,$env:CRODIP_BACKEND_PORT,$env:CRODIP_FRONTEND_PORT)
if ([string]::IsNullOrWhiteSpace($composeFile)) {
    Write-CrodipError "compose.yaml absent."
    return
}

# Préflight bloquant avant WSL2 / Docker Linux
try {
    $perfTimer=[Diagnostics.Stopwatch]::StartNew()
    $preflightResult = Assert-CrodipHardwareWindowsPreflight
    $perfTimer.Stop()
    Add-CrodipPerformanceMeasurement -Session $performanceSession -Name "Qualification matérielle / Windows" -Seconds $perfTimer.Elapsed.TotalSeconds -Category "Preflight"

    foreach($subMetric in @($preflightResult.PreflightMetrics)){
        Add-CrodipPerformanceMeasurement `
            -Session $performanceSession `
            -Name $subMetric.Name `
            -Seconds $subMetric.Seconds `
            -Category "Preflight.Substep" `
            -Details $subMetric.Details
    }
}
catch {
    Write-CrodipError $_.Exception.Message
    return
}

$perfTimer=[Diagnostics.Stopwatch]::StartNew()

Write-CrodipStep "Vérification / migration du Compose Runtime installé"
$perfTimer=[Diagnostics.Stopwatch]::StartNew()
$isolation=Repair-CrodipRuntimeComposeIsolation -ComposeFile $composeFile -Confirm:$false
$perfTimer.Stop()
Add-CrodipPerformanceMeasurement -Session $performanceSession -Name "Isolation projet Compose" -Seconds $perfTimer.Elapsed.TotalSeconds -Category "Compose" -Details ("Changed={0}" -f $isolation.Changed)

Write-CrodipStep "Contrôle des ports Runtime"
$perfTimer=[Diagnostics.Stopwatch]::StartNew()
$portStatus=@(Test-CrodipRuntimePortAvailability -ComposeFile $composeFile)
$perfTimer.Stop()
$conflictingPorts=@($portStatus|Where-Object HasConflict)
Add-CrodipPerformanceMeasurement -Session $performanceSession -Name "Contrôle ports publiés" -Seconds $perfTimer.Elapsed.TotalSeconds -Category "Network" -Details ("Ports={0}; Conflicts={1}" -f $portStatus.Count,$conflictingPorts.Count)

foreach($port in $portStatus){
    switch($port.State){
        "AVAILABLE" {
            Write-CrodipSuccess ("Port {0} disponible pour {1}." -f $port.Port,$port.Service)
        }

        "OWNED_BY_CURRENT_RUNTIME" {
            Write-CrodipSuccess ("Port {0} déjà utilisé par le service Runtime courant {1}." -f $port.Port,$port.Service)

            foreach($owner in $port.CurrentRuntimeOwners){
                Write-Host "         Conteneur : $($owner.ContainerName)"
                Write-Host "         Projet    : $($owner.ComposeProject)"
                Write-Host "         Service   : $($owner.ComposeService)"
                Write-Host "         Publication : $($owner.Ports)"
            }

            foreach($listener in $port.RelayListeners){
                Write-Host "         Relais Docker/WSL : $($listener.ProcessName) PID=$($listener.OwningProcess)"
            }
        }

        "CONFLICT_DOCKER" {
            Write-CrodipWarning ("Conflit Docker sur le port {0} demandé par {1}." -f $port.Port,$port.Service)

            foreach($owner in $port.OtherDockerOwners){
                Write-Host "         Conteneur : $($owner.ContainerName)"
                Write-Host "         Projet    : $($owner.ComposeProject)"
                Write-Host "         Service   : $($owner.ComposeService)"
                Write-Host "         Publication : $($owner.Ports)"
            }
        }

        "CONFLICT_WINDOWS" {
            Write-CrodipWarning ("Conflit Windows sur le port {0} demandé par {1}." -f $port.Port,$port.Service)

            foreach($listener in $port.ExternalWindowsListeners){
                Write-Host ("         {0}:{1} PID={2} Process={3}" -f `
                    $listener.LocalAddress,$listener.LocalPort,$listener.OwningProcess,$listener.ProcessName)
            }
        }

        "DOCKER_RELAY_ONLY" {
            Write-CrodipWarning ("Port {0} occupé par un relais Docker/WSL, propriétaire conteneur non identifié." -f $port.Port)

            foreach($listener in $port.RelayListeners){
                Write-Host "         Relais : $($listener.ProcessName) PID=$($listener.OwningProcess)"
            }
        }

        default {
            Write-CrodipWarning ("État du port {0} indéterminé : {1}" -f $port.Port,$port.State)
        }
    }
}

Write-CrodipStep "Réconciliation des publications de ports des conteneurs existants"
try {
    $portRepair = Repair-CrodipRuntimePublishedPortBindings -ComposeFile $composeFile -Confirm:$false
    if (-not $portRepair.Changed) { Write-CrodipSuccess "Publications de ports existantes cohérentes avec le Compose." }
}
catch { Write-CrodipError $_.Exception.Message; return }

$providerInfo = Get-CrodipDockerProviderInfo
$perfTimer.Stop()
Add-CrodipPerformanceMeasurement -Session $performanceSession -Name "Résolution provider Docker" -Seconds $perfTimer.Elapsed.TotalSeconds
Write-CrodipStep "Provider Docker : $($providerInfo.DisplayName)"

if ((Get-CrodipDockerProvider) -eq "desktop") {
    $perfTimer=[Diagnostics.Stopwatch]::StartNew()
    $readiness = Test-CrodipDockerDesktopReadiness
    $perfTimer.Stop()
    Add-CrodipPerformanceMeasurement `
        -Session $performanceSession `
        -Name "Docker Desktop readiness" `
        -Seconds $perfTimer.Elapsed.TotalSeconds `
        -Category "Docker" `
        -Details ("Installed={0}; WSL={1}; EngineReady={2}" -f $readiness.DockerDesktopInstalled,$readiness.WslInstalled,$readiness.EngineReady)

    if (-not $readiness.DockerDesktopInstalled) {
        Write-CrodipError "Docker Desktop n'est pas installé."
        Write-CrodipWarning "Administration Docker > Installer Docker Desktop."
        return
    }

    if (-not $readiness.WslInstalled) {
        Write-CrodipWarning "WSL2 n'est pas installé."

        try {
            $wslInstall = Ensure-CrodipWsl2Prerequisite `
                -Distribution (Get-CrodipWslDistribution) `
                -InstallIfMissing
        }
        catch {
            Write-CrodipError $_.Exception.Message
            Write-CrodipWarning "L'installation automatique de WSL2 nécessite le mode administrateur."
            return
        }

        if ($wslInstall.InstalledNow) {
            Write-CrodipSuccess "Installation WSL2 lancée."
        }

        if ($wslInstall.RebootRequired) {
            Write-CrodipWarning "Redémarrage Windows requis avant de relancer CRODIP."
        }

        return
    }

    if (-not $readiness.EngineReady) {
        Write-CrodipStep "Démarrage de Docker Desktop"

        $started = Start-CrodipDockerDesktop `
            -TimeoutSeconds $config.startup.dockerStartupTimeoutSeconds `
            -WhatIf:$WhatIfPreference `
            -Confirm:$false

        if (-not $started) {
            Write-CrodipError "Docker Desktop est installé, mais le moteur Linux ne répond pas."
            Write-CrodipWarning "Vérifier WSL2 puis redémarrer Docker Desktop."
            Write-CrodipWarning "Commande de diagnostic : wsl --status ; docker info"
            return
        }
    }

    try {
        $null = Assert-CrodipDockerDesktopReady
    }
    catch {
        Write-CrodipError $_.Exception.Message
        return
    }
}
else {
    if (-not (Test-CrodipDockerEngine)) {
        Write-CrodipStep "Démarrage de Docker Engine dans $(Get-CrodipWslDistribution)"

        $started = Start-CrodipUbuntuDockerEngine `
            -TimeoutSeconds $config.startup.dockerStartupTimeoutSeconds

        if (-not $started) {
            Write-CrodipError "Docker Engine Ubuntu indisponible."
            Write-CrodipWarning "Vérifier dans Ubuntu : sudo service docker start"
            return
        }
    }
}

$perfTimer=[Diagnostics.Stopwatch]::StartNew()
$result = Start-CrodipRuntimeAuto `
    -ComposeFile $composeFile `
    -WhatIf:$WhatIfPreference `
    -Confirm:$false
$perfTimer.Stop()
Add-CrodipPerformanceMeasurement -Session $performanceSession -Name "Images / GHCR / Compose up" -Seconds $perfTimer.Elapsed.TotalSeconds

if ($result.ExitCode -ne 0) {
    Write-CrodipError "Échec de Docker Compose."
    $result.Output | ForEach-Object { Write-Host $_ }
    return
}

if ($WhatIfPreference) {
    Write-CrodipWarning "Démarrage simulé."
    return
}

$perfTimer=[Diagnostics.Stopwatch]::StartNew()
Start-Sleep -Seconds 3
$perfTimer.Stop()
Add-CrodipPerformanceMeasurement -Session $performanceSession -Name "Attente stabilisation conteneurs" -Seconds $perfTimer.Elapsed.TotalSeconds -Category "Startup"

Write-CrodipStep "Migration / validation Alembic LOCAL"
try { $null = Invoke-CrodipRuntimeDatabaseMigration -Target local } catch { Write-CrodipError $_.Exception.Message; return }

Write-CrodipStep "Contrôle effectif des ports publiés après démarrage"
$bindingStatus=@(Test-CrodipRuntimePublishedPortBindings -ComposeFile $composeFile)
$bindingErrors=@($bindingStatus|Where-Object{-not $_.Valid})
foreach($binding in $bindingStatus){
    if($binding.Valid){ Write-CrodipSuccess ("{0} : port hôte {1} -> conteneur {2} conforme." -f $binding.Service,$binding.Actual,$binding.Target) }
    else { Write-CrodipError ("{0} : port attendu {1}, port Docker effectif {2}." -f $binding.Service,$binding.Expected,$binding.Actual) }
}
if($bindingErrors.Count -gt 0){ Write-CrodipError "Contrôle des ports Docker échoué après démarrage."; return }

$perfTimer=[Diagnostics.Stopwatch]::StartNew()
$servicesRuntime = @(Get-CrodipComposeServiceRuntimeStatus -ComposeFile $composeFile)
$perfTimer.Stop()

Add-CrodipPerformanceMeasurement `
    -Session $performanceSession `
    -Name "Lecture état services Compose" `
    -Seconds $perfTimer.Elapsed.TotalSeconds `
    -Category "Docker" `
    -Details ("Services={0}" -f $servicesRuntime.Count)

$serviceLabels = @{
    "backend"  = "API Backend"
    "frontend" = "Frontend"
}

$runtimeHealthy = $true

foreach ($serviceName in @("backend","frontend")) {
    $service = @(
        $servicesRuntime |
            Where-Object { $_.Service -eq $serviceName }
    ) | Select-Object -First 1

    $displayName = if ($serviceLabels.ContainsKey($serviceName)) {
        $serviceLabels[$serviceName]
    }
    else {
        $serviceName
    }

    if ($null -eq $service) {
        Write-CrodipWarning "$displayName : Absent du projet Compose."
        $runtimeHealthy = $false
        continue
    }

    switch ($service.NormalizedState) {
        "RUNNING" {
            Write-CrodipSuccess "$displayName : Running"
            Write-Host "         Conteneur : $($service.ContainerName)"
            Write-Host "         Image     : $($service.Image)"
        }

        "RESTARTING" {
            Write-CrodipError "$displayName : Restarting"
            Write-Host "         Conteneur : $($service.ContainerName)"
            Write-Host "         Image     : $($service.Image)"
            Write-Host "         ExitCode  : $($service.ExitCode)"
            Write-CrodipWarning "Le service redémarre en boucle."

            if ($serviceName -eq "backend") {
                Write-CrodipStep "Dernières lignes du journal Backend"

                try {
                    $logs = Invoke-CrodipDockerCli `
                        -Arguments @(
                            "logs",
                            "--tail",
                            "30",
                            $service.ContainerName
                        )

                    foreach ($line in $logs.Output) {
                        Write-Host " $line"
                    }
                }
                catch {
                    Write-CrodipWarning "Impossible de lire les logs backend."
                }
            }

            $runtimeHealthy = $false
        }

        "UNHEALTHY" {
            Write-CrodipError "$displayName : Unhealthy"
            Write-Host "         Conteneur : $($service.ContainerName)"
            Write-Host "         Image     : $($service.Image)"
            $runtimeHealthy = $false
        }

        "EXITED" {
            Write-CrodipError "$displayName : Exited"
            Write-Host "         Conteneur : $($service.ContainerName)"
            Write-Host "         ExitCode  : $($service.ExitCode)"
            $runtimeHealthy = $false
        }

        default {
            Write-CrodipWarning "$displayName : $($service.NormalizedState)"
            Write-Host "         Conteneur : $($service.ContainerName)"
            Write-Host "         Status    : $($service.Status)"
            $runtimeHealthy = $false
        }
    }
}

$performanceReport=Export-CrodipPerformanceReport -Session $performanceSession
Show-CrodipPerformanceSummary -Report $performanceReport -Label "démarrage"

if($runtimeHealthy){
    Write-CrodipSuccess "Runtime démarré et services opérationnels."
}
else{
    Write-CrodipWarning "Runtime démarré avec services non opérationnels."
}

if (-not $NoBrowser -and $config.startup.openBrowserAutomatically) {
    Start-Process $config.startup.frontendUrl | Out-Null
}
