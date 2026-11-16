###############################################################
# CRODIP Runtime Manager
# Script   : commands\12-central-runtime.ps1
# Version  : 2.3.0-RC40
# Statut   : Release Candidate - Safe Database Migration & Release Compatibility
###############################################################

#Requires -Version 7.4

[CmdletBinding()]
param(
    [ValidateSet("menu","install","start","stop","status","update","logs","uninstall")]
    [string]$Action = "menu"
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$moduleRoot = Join-Path $PSScriptRoot "..\modules"

foreach($moduleName in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1",
    "Crodip.Runtime.DockerProvider.psm1",
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Compose.psm1",
    "Crodip.Runtime.DatabaseMigration.psm1"
)){
    Import-Module `
        (Join-Path $moduleRoot $moduleName) `
        -Force `
        -DisableNameChecking `
        -ErrorAction Stop
}

function Get-CrodipCentralRuntimeHome {
    return (Join-Path (Get-CrodipHome) "templates\central")
}

function Get-CrodipCentralComposeFile {
    return (Join-Path (Get-CrodipCentralRuntimeHome) "compose.yaml")
}

function Get-CrodipCentralEnvFile {
    return (Join-Path (Get-CrodipCentralRuntimeHome) ".env")
}

function Test-CrodipCentralRuntimeInstalled {
    return (
        (Test-Path -LiteralPath (Get-CrodipCentralComposeFile) -PathType Leaf) -and
        (Test-Path -LiteralPath (Get-CrodipCentralEnvFile) -PathType Leaf)
    )
}

function Initialize-CrodipCentralRuntime {
    Write-CrodipStep "Initialisation / synchronisation du Runtime CENTRAL"

    $centralHome = Get-CrodipCentralRuntimeHome
    $composeFile = Get-CrodipCentralComposeFile
    $envFile = Get-CrodipCentralEnvFile
    $envTemplate = Join-Path $centralHome ".env.example"

    if(-not(Test-Path -LiteralPath $centralHome -PathType Container)){
        throw "Répertoire CENTRAL absent : $centralHome"
    }
    if(-not(Test-Path -LiteralPath $composeFile -PathType Leaf)){
        throw "Compose CENTRAL absent : $composeFile"
    }
    if(-not(Test-Path -LiteralPath $envTemplate -PathType Leaf)){
        throw "Template .env CENTRAL absent : $envTemplate"
    }

    if(-not(Test-Path -LiteralPath $envFile -PathType Leaf)){
        Copy-Item -LiteralPath $envTemplate -Destination $envFile -Force
        Write-CrodipSuccess "Fichier .env CENTRAL créé : $envFile"
    }

    $imageEnvironment = Set-CrodipRuntimeImageEnvironment -EnvFile $envFile -Target "central" -Confirm:$false

    Write-CrodipSuccess "Runtime CENTRAL synchronisé."
    Write-CrodipSuccess "Projet Docker : crodip-runtime-central"
    Write-CrodipSuccess "Frontend : http://localhost:9120"
    Write-CrodipSuccess "Backend  : http://localhost:8120"
    Write-CrodipSuccess "Application : $($imageEnvironment.ApplicationVersion)"
    Write-CrodipSuccess "Mode images : $($imageEnvironment.ReferenceMode)"
    Write-CrodipWarning "Simulation CENTRAL : changer le mot de passe PostgreSQL par défaut si cet environnement devient persistant."
}

function Assert-CrodipCentralRuntimeInstalled {
    if(-not(Test-CrodipCentralRuntimeInstalled)){
        throw "Runtime CENTRAL non installé. Utiliser d'abord : Installer le Runtime CENTRAL."
    }
}

function Sync-CrodipCentralImages {
    $envFile = Get-CrodipCentralEnvFile
    return Set-CrodipRuntimeImageEnvironment `
        -EnvFile $envFile `
        -Target "central" `
        -Confirm:$false
}

function Invoke-CrodipCentralCompose {
    param(
        [Parameter(Mandatory)]
        [ValidateSet("up","stop","down","restart","pull","ps","logs","config")]
        [string]$ComposeAction,

        [switch]$Detached
    )

    Assert-CrodipCentralRuntimeInstalled

    $composeFile = Get-CrodipCentralComposeFile

    # RC29 - isolation stricte du contexte CENTRAL.
    # Les variables de processus ont priorité sur .env dans Docker Compose.
    # On impose donc les ports CENTRAL uniquement pendant l'appel Compose,
    # puis on restaure exactement le contexte précédent (LOCAL ou absent).
    $previousBackendPort = [Environment]::GetEnvironmentVariable("CRODIP_BACKEND_PORT", "Process")
    $previousFrontendPort = [Environment]::GetEnvironmentVariable("CRODIP_FRONTEND_PORT", "Process")
    try {
        $null = Set-CrodipCentralProcessEnvironment
        return Invoke-CrodipCompose `
            -Action $ComposeAction `
            -ComposeFile $composeFile `
            -Detached:$Detached `
            -Confirm:$false
    }
    finally {
        [Environment]::SetEnvironmentVariable("CRODIP_BACKEND_PORT", $previousBackendPort, "Process")
        [Environment]::SetEnvironmentVariable("CRODIP_FRONTEND_PORT", $previousFrontendPort, "Process")
    }
}


function Set-CrodipCentralProcessEnvironment {
    # RC21 - Docker Compose donne priorité aux variables du processus sur le .env.
    # Le menu LOCAL peut avoir positionné 8110/9110 : CENTRAL doit donc réimposer 8120/9120.
    $config = Get-CrodipRuntimeConfig
    $lifecycle = [string]$config.docker.activeLifecycle
    $lifecycleNode = $config.docker.lifecyclePorts.PSObject.Properties[$lifecycle]
    if($null -eq $lifecycleNode){ throw "Profil de ports absent pour le cycle '$lifecycle'." }
    $centralNode = $lifecycleNode.Value.PSObject.Properties['central']
    if($null -eq $centralNode){ throw "Profil de ports CENTRAL absent pour '$lifecycle'." }

    $env:CRODIP_BACKEND_PORT = [string][int]$centralNode.Value.backend
    $env:CRODIP_FRONTEND_PORT = [string][int]$centralNode.Value.frontend

    [pscustomobject]@{
        Lifecycle = $lifecycle
        BackendPort = [int]$centralNode.Value.backend
        FrontendPort = [int]$centralNode.Value.frontend
    }
}

function Show-CrodipCentralReleaseTraceability {
    param([Parameter(Mandatory)]$ImageEnvironment)
    $config = Get-CrodipRuntimeConfig
    $effective = Get-CrodipEffectiveRelease
    $ports = Set-CrodipCentralProcessEnvironment
    Write-CrodipStep "Traçabilité de la release CENTRAL"
    Write-Host ("Application       : {0}" -f $effective.applicationVersion)
    Write-Host ("Canal / cycle     : {0} / {1}" -f $config.application.releaseChannel,$ports.Lifecycle)
    Write-Host ("Release officielle: #{0} / Run ID {1}" -f $config.release.runNumber,$config.release.runId)
    if([bool]$effective.active){ Write-CrodipWarning ("Override TEST ACTIF : run #{0} / {1}" -f $effective.runNumber,$effective.runId) }
    Write-Host ("Run effectif      : #{0} / Run ID {1}" -f $effective.runNumber,$effective.runId)
    Write-Host ("Git commit        : {0}" -f $effective.commit)
    Write-Host ("Politique         : {0}" -f $config.release.buildPolicy)
    Write-Host ("Manifest Runtime  : config\\runtime.json (official-digest-pin)")
    Write-Host ("Backend image     : {0}" -f $ImageEnvironment.BackendImage)
    Write-Host ("Frontend image    : {0}" -f $ImageEnvironment.FrontendImage)
    Write-Host ("Ports CENTRAL     : backend={0}, frontend={1}" -f $ports.BackendPort,$ports.FrontendPort)
}

function Test-CrodipCentralPortsBeforeStart {
    $composeFile = Get-CrodipCentralComposeFile
    $ports = Set-CrodipCentralProcessEnvironment
    Write-CrodipStep "Contrôle des ports Runtime CENTRAL"
    $status = @(Test-CrodipRuntimePortAvailability -ComposeFile $composeFile)
    foreach($port in $status){
        if($port.HasConflict -and $port.State -ne 'OWNED_BY_CURRENT_RUNTIME'){
            Write-CrodipError ("Port CENTRAL {0} indisponible pour {1} ({2})." -f $port.Port,$port.Service,$port.State)
            throw "Conflit de port CENTRAL détecté."
        }
        Write-CrodipSuccess ("CENTRAL {0} : port {1} conforme/disponible." -f $port.Service,$port.Port)
    }
    return $ports
}

function Show-CrodipCentralContainerTraceability {
    $config = Get-CrodipRuntimeConfig
    Write-CrodipStep "Contrôle images / manifest des conteneurs CENTRAL"
    foreach($service in @('backend','frontend')){
        $id = (& docker ps --filter "label=com.docker.compose.project=crodip-runtime-central" --filter "label=com.docker.compose.service=$service" --format "{{.ID}}" 2>$null | Select-Object -First 1)
        if([string]::IsNullOrWhiteSpace([string]$id)){ Write-CrodipWarning "CENTRAL $service : conteneur absent."; continue }
        $image = ((& docker inspect --format '{{.Config.Image}}' $id 2>$null | Select-Object -First 1) -as [string]).Trim()
        $version = ((& docker inspect --format '{{index .Config.Labels "org.opencontainers.image.version"}}' $id 2>$null | Select-Object -First 1) -as [string]).Trim()
        $revision = ((& docker inspect --format '{{index .Config.Labels "org.opencontainers.image.revision"}}' $id 2>$null | Select-Object -First 1) -as [string]).Trim()
        $expected = [string](Get-CrodipEffectiveImageNode -Target central -Service $service).reference
        $digestOk = [string]::Equals($image,$expected,[System.StringComparison]::OrdinalIgnoreCase)
        if($digestOk){ Write-CrodipSuccess ("CENTRAL {0} : digest conforme au manifest." -f $service) }
        else { Write-CrodipError ("CENTRAL {0} : image différente du manifest. Attendu={1} Actuel={2}" -f $service,$expected,$image) }
        Write-Host ("         OCI version : {0}" -f $version)
        Write-Host ("         OCI commit  : {0}" -f $revision)
        Write-Host ("         Image       : {0}" -f $image)
        if(-not [string]::IsNullOrWhiteSpace($revision) -and $revision -ne [string](Get-CrodipEffectiveRelease).commit){
            Write-CrodipWarning ("CENTRAL {0} : label OCI commit différent du commit du manifest." -f $service)
        }
    }
}

function Start-CrodipCentralRuntime {
    if(-not(Test-CrodipCentralRuntimeInstalled)){
        Initialize-CrodipCentralRuntime
    }

    # Synchronise le .env CENTRAL puis impose explicitement le contexte CENTRAL dans le processus.
    $images = Sync-CrodipCentralImages
    $ports = Set-CrodipCentralProcessEnvironment
    Show-CrodipCentralReleaseTraceability -ImageEnvironment $images
    $null = Test-CrodipCentralPortsBeforeStart

    if(-not(Test-CrodipDockerEngine)){
        if((Get-CrodipDockerProvider) -eq "desktop"){
            $null = Start-CrodipDockerDesktop -Confirm:$false
        }
        else {
            $null = Start-CrodipUbuntuDockerEngine
        }
    }

    Write-CrodipStep "Démarrage du Runtime CENTRAL"
    # RC40 - LOCAL et CENTRAL utilisent le même moteur AUTO / ONLINE / OFFLINE.
    # Le Compose CENTRAL contient aussi postgres:17 : en OFFLINE sa présence locale
    # est contrôlée avant tout démarrage avec --pull never.
    $result = Start-CrodipRuntimeAuto -ComposeFile (Get-CrodipCentralComposeFile) -Confirm:$false
    if($result.ExitCode -ne 0){
        throw "Échec du démarrage CENTRAL : $($result.Output -join ' ')"
    }

    Write-CrodipStep "Migration / validation Alembic CENTRAL"
    $null = Invoke-CrodipRuntimeDatabaseMigration -Target central

    Write-CrodipSuccess "Runtime CENTRAL démarré."
    Write-CrodipSuccess ("Frontend : http://localhost:{0}" -f $ports.FrontendPort)
    Write-CrodipSuccess ("Backend  : http://localhost:{0}" -f $ports.BackendPort)

    Show-CrodipCentralContainerTraceability
}

function Stop-CrodipCentralRuntime {
    Assert-CrodipCentralRuntimeInstalled
    Write-CrodipStep "Arrêt du Runtime CENTRAL"
    $result = Invoke-CrodipCentralCompose -ComposeAction "stop"
    if($result.ExitCode -ne 0){
        throw "Échec de l'arrêt CENTRAL : $($result.Output -join ' ')"
    }
    Write-CrodipSuccess "Runtime CENTRAL arrêté."
}

function Show-CrodipCentralRuntimeStatus {
    if(-not(Test-CrodipCentralRuntimeInstalled)){
        Write-CrodipWarning "Runtime CENTRAL : NON INSTALLÉ"
        return
    }

    $config = Get-CrodipRuntimeConfig
    $project = "crodip-runtime-central"
    $frontendUrl = "http://localhost:9120"
    $backendUrl = "http://localhost:8120"
    $expectedBackend = [string](Get-CrodipEffectiveImageNode -Target central -Service backend).reference
    $expectedFrontend = [string](Get-CrodipEffectiveImageNode -Target central -Service frontend).reference

    function Get-CentralContainerInfo {
        param([string]$Service)

        $line = (& docker ps `
            --filter "label=com.docker.compose.project=$project" `
            --filter "label=com.docker.compose.service=$Service" `
            --format "{{json .}}" 2>$null | Select-Object -First 1)

        if($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace([string]$line)){
            return $null
        }

        $row = $line | ConvertFrom-Json
        $configuredImage = (& docker inspect --format "{{.Config.Image}}" ([string]$row.ID) 2>$null | Select-Object -First 1)

        return [pscustomobject]@{
            Id = [string]$row.ID
            Name = [string]$row.Names
            State = [string]$row.State
            Status = [string]$row.Status
            Ports = [string]$row.Ports
            Image = if($configuredImage){ ([string]$configuredImage).Trim() } else { [string]$row.Image }
        }
    }

    function Test-CentralHttp {
        param([string]$Url)
        try {
            $r = Invoke-WebRequest -Uri $Url -UseBasicParsing -TimeoutSec 5
            return [pscustomobject]@{
                Success = ($r.StatusCode -eq 200)
                Detail = "HTTP $($r.StatusCode)"
            }
        }
        catch {
            return [pscustomobject]@{
                Success = $false
                Detail = $_.Exception.Message
            }
        }
    }

    $backend = Get-CentralContainerInfo -Service "backend"
    $frontend = Get-CentralContainerInfo -Service "frontend"
    $postgres = Get-CentralContainerInfo -Service "postgres"

    $health = Test-CentralHttp "$backendUrl/health"
    $docs   = Test-CentralHttp "$backendUrl/docs"
    $front  = Test-CentralHttp "$frontendUrl/"

    Clear-Host
    Write-Host "============================================================" -ForegroundColor Cyan
    Write-Host " ÉTAT DU RUNTIME CENTRAL" -ForegroundColor Cyan
    Write-Host "============================================================" -ForegroundColor Cyan
    Write-Host ""
    Write-Host ("Runtime     : {0}" -f $config.version)
    Write-Host ("Application : {0}" -f $config.application.version)
    Write-Host ("Cycle       : {0}" -f $config.docker.activeLifecycle)
    Write-Host ("Run CI      : #{0} / {1}" -f $config.release.runNumber,$config.release.runId)
    Write-Host ("Commit      : {0}" -f $config.release.commit)
    Write-Host ("Projet      : {0}" -f $project)
    Write-Host ""

    Write-Host "SERVICES" -ForegroundColor Cyan
    Write-Host "------------------------------------------------------------"

    if($postgres){
        $pgHealthy = ($postgres.State -eq "running" -and $postgres.Status -match "healthy")
        if($pgHealthy){
            Write-Host ("[OK] PostgreSQL 17   : {0}" -f $postgres.Status) -ForegroundColor Green
        } else {
            Write-Host ("[ERREUR] PostgreSQL 17 : {0}" -f $postgres.Status) -ForegroundColor Red
        }
    } else {
        Write-Host "[ERREUR] PostgreSQL 17 : conteneur absent" -ForegroundColor Red
    }

    foreach($item in @(
        [pscustomobject]@{ Label="Backend"; Data=$backend; Expected=$expectedBackend; Url=$backendUrl },
        [pscustomobject]@{ Label="Frontend"; Data=$frontend; Expected=$expectedFrontend; Url=$frontendUrl }
    )){
        if($null -eq $item.Data){
            Write-Host ("[ERREUR] {0,-10}: conteneur absent" -f $item.Label) -ForegroundColor Red
            continue
        }

        $running = ($item.Data.State -eq "running")
        $digestOk = [string]::Equals(
            [string]$item.Data.Image,
            [string]$item.Expected,
            [System.StringComparison]::OrdinalIgnoreCase
        )

        if($running){
            Write-Host ("[OK] {0,-10}: {1}" -f $item.Label,$item.Data.Status) -ForegroundColor Green
        } else {
            Write-Host ("[ERREUR] {0,-10}: {1}" -f $item.Label,$item.Data.Status) -ForegroundColor Red
        }

        Write-Host ("     URL       : {0}" -f $item.Url)
        Write-Host ("     Ports     : {0}" -f $item.Data.Ports)

        if($digestOk){
            Write-Host ("     Digest    : [OK] {0}" -f $item.Data.Image) -ForegroundColor Green
        } else {
            Write-Host ("     Digest    : [ERREUR] {0}" -f $item.Data.Image) -ForegroundColor Red
            Write-Host ("     Attendu   : {0}" -f $item.Expected) -ForegroundColor Yellow
        }
    }

    Write-Host ""
    Write-Host "CONTRÔLES HTTP" -ForegroundColor Cyan
    Write-Host "------------------------------------------------------------"

    foreach($check in @(
        [pscustomobject]@{ Name="Frontend /";      Result=$front;  Url="$frontendUrl/" },
        [pscustomobject]@{ Name="Backend /health"; Result=$health; Url="$backendUrl/health" },
        [pscustomobject]@{ Name="Backend /docs";   Result=$docs;   Url="$backendUrl/docs" }
    )){
        if($check.Result.Success){
            Write-Host ("[OK] {0,-18} {1} - {2}" -f $check.Name,$check.Result.Detail,$check.Url) -ForegroundColor Green
        } else {
            Write-Host ("[ERREUR] {0,-14} {1} - {2}" -f $check.Name,$check.Result.Detail,$check.Url) -ForegroundColor Red
        }
    }

    $backendOk = ($backend -and $backend.State -eq "running" -and
        [string]::Equals([string]$backend.Image,$expectedBackend,[System.StringComparison]::OrdinalIgnoreCase))
    $frontendOk = ($frontend -and $frontend.State -eq "running" -and
        [string]::Equals([string]$frontend.Image,$expectedFrontend,[System.StringComparison]::OrdinalIgnoreCase))
    $postgresOk = ($postgres -and $postgres.State -eq "running" -and $postgres.Status -match "healthy")
    $httpOk = ($front.Success -and $health.Success -and $docs.Success)
    $allOk = ($backendOk -and $frontendOk -and $postgresOk -and $httpOk)

    Write-Host ""
    Write-Host "------------------------------------------------------------"
    if($allOk){
        Write-Host " RUNTIME CENTRAL TECHNICALLY OPERATIONAL" -ForegroundColor Green
    } else {
        Write-Host " RUNTIME CENTRAL : ATTENTION / CONTRÔLE REQUIS" -ForegroundColor Yellow
    }
    Write-Host "------------------------------------------------------------"
}

function Assert-CrodipCentralEnvironmentIsolation {
    $config = Get-CrodipRuntimeConfig
    $lifecycle = [string]$config.docker.activeLifecycle
    $node = $config.docker.lifecyclePorts.PSObject.Properties[$lifecycle]
    if($null -eq $node){ throw "Profil de ports absent pour '$lifecycle'." }
    $central = $node.Value.PSObject.Properties['central']
    $local = $node.Value.PSObject.Properties['local']
    if($null -eq $central){ throw "Profil CENTRAL absent pour '$lifecycle'." }

    $expectedBackend = [int]$central.Value.backend
    $expectedFrontend = [int]$central.Value.frontend
    $envFile = Get-CrodipCentralEnvFile
    $envValues = @{}
    foreach($line in @(Get-Content -LiteralPath $envFile -ErrorAction Stop)){
        if($line -match '^\s*([^#][^=]*)=(.*)$'){$envValues[$matches[1].Trim()]=$matches[2].Trim()}
    }
    $actualBackend = [int]$envValues['CRODIP_BACKEND_PORT']
    $actualFrontend = [int]$envValues['CRODIP_FRONTEND_PORT']

    Write-CrodipStep "Validation environnement CENTRAL"
    Write-Host ("Backend attendu  : {0}" -f $expectedBackend)
    Write-Host ("Frontend attendu : {0}" -f $expectedFrontend)
    Write-Host (".env CENTRAL     : backend={0}, frontend={1}" -f $actualBackend,$actualFrontend)
    if($actualBackend -ne $expectedBackend -or $actualFrontend -ne $expectedFrontend){
        throw "Le .env CENTRAL ne correspond pas au profil $lifecycle/CENTRAL."
    }
    if($null -ne $local -and ($actualBackend -eq [int]$local.Value.backend -or $actualFrontend -eq [int]$local.Value.frontend)){
        throw "Isolation refusée : un port LOCAL est détecté dans le contexte CENTRAL."
    }
    Write-CrodipSuccess "Contexte CENTRAL isolé du contexte LOCAL."
}

function Update-CrodipCentralRuntime {
    Assert-CrodipCentralRuntimeInstalled
    $images = Sync-CrodipCentralImages
    Assert-CrodipCentralEnvironmentIsolation

    Write-CrodipStep "Réconciliation des publications de ports CENTRAL"
    $previousBackendPort = [Environment]::GetEnvironmentVariable("CRODIP_BACKEND_PORT", "Process")
    $previousFrontendPort = [Environment]::GetEnvironmentVariable("CRODIP_FRONTEND_PORT", "Process")
    try {
        $null = Set-CrodipCentralProcessEnvironment
        $portRepair = Repair-CrodipRuntimePublishedPortBindings -ComposeFile (Get-CrodipCentralComposeFile) -Confirm:$false
        if(-not $portRepair.Changed){ Write-CrodipSuccess "Publications de ports CENTRAL existantes cohérentes avec le Compose." }
    }
    finally {
        [Environment]::SetEnvironmentVariable("CRODIP_BACKEND_PORT", $previousBackendPort, "Process")
        [Environment]::SetEnvironmentVariable("CRODIP_FRONTEND_PORT", $previousFrontendPort, "Process")
    }

    Write-CrodipStep "Mise à jour des images CENTRAL"
    $pull = Invoke-CrodipCentralCompose -ComposeAction "pull"
    if($pull.ExitCode -ne 0){
        throw "Échec du pull CENTRAL : $($pull.Output -join ' ')"
    }

    $up = Invoke-CrodipCentralCompose -ComposeAction "up" -Detached
    if($up.ExitCode -ne 0){
        throw "Échec de l'application de la mise à jour CENTRAL : $($up.Output -join ' ')"
    }

    Write-CrodipStep "Contrôle effectif des ports publiés CENTRAL"
    $previousBackendPort = [Environment]::GetEnvironmentVariable("CRODIP_BACKEND_PORT", "Process")
    $previousFrontendPort = [Environment]::GetEnvironmentVariable("CRODIP_FRONTEND_PORT", "Process")
    try {
        $null = Set-CrodipCentralProcessEnvironment
        $bindingStatus = @(Test-CrodipRuntimePublishedPortBindings -ComposeFile (Get-CrodipCentralComposeFile))
    }
    finally {
        [Environment]::SetEnvironmentVariable("CRODIP_BACKEND_PORT", $previousBackendPort, "Process")
        [Environment]::SetEnvironmentVariable("CRODIP_FRONTEND_PORT", $previousFrontendPort, "Process")
    }
    $bindingErrors = @($bindingStatus | Where-Object { -not $_.Valid })
    foreach($binding in $bindingStatus){
        if($binding.Valid){ Write-CrodipSuccess ("CENTRAL {0} : port hôte {1} -> conteneur {2} conforme." -f $binding.Service,$binding.Actual,$binding.Target) }
        else { Write-CrodipError ("CENTRAL {0} : port attendu {1}, port Docker effectif {2}." -f $binding.Service,$binding.Expected,$binding.Actual) }
    }
    if($bindingErrors.Count -gt 0){ throw "Contrôle des ports Docker CENTRAL échoué après mise à jour." }

    Write-CrodipStep "Migration / validation Alembic CENTRAL"
    $null = Invoke-CrodipRuntimeDatabaseMigration -Target central

    Write-CrodipSuccess "Runtime CENTRAL mis à jour avec le tag $($images.Tag)."
}

function Show-CrodipCentralRuntimeLogs {
    Assert-CrodipCentralRuntimeInstalled
    $result = Invoke-CrodipCentralCompose -ComposeAction "logs"
    if($result.Output){
        $result.Output | ForEach-Object { Write-Host $_ }
    }
}

function Uninstall-CrodipCentralRuntime {
    if(-not(Test-CrodipCentralRuntimeInstalled)){
        Write-CrodipWarning "Runtime CENTRAL déjà absent."
        return
    }

    Write-CrodipWarning "Cette opération supprime les conteneurs CENTRAL."
    Write-CrodipWarning "Le volume PostgreSQL 'crodip-runtime-central-postgres' est conservé."
    $confirm = Read-Host "Saisir SUPPRIMER-CENTRAL pour confirmer"

    if($confirm -cne "SUPPRIMER-CENTRAL"){
        Write-CrodipWarning "Désinstallation annulée."
        return
    }

    $down = Invoke-CrodipCentralCompose -ComposeAction "down"
    if($down.ExitCode -ne 0){
        Write-CrodipWarning "docker compose down a retourné une erreur."
    }

    Remove-Item -LiteralPath (Get-CrodipCentralRuntimeHome) -Recurse -Force
    Write-CrodipSuccess "Runtime CENTRAL désinstallé."
    Write-CrodipWarning "Volume PostgreSQL conservé pour éviter toute perte de données."
}

function Show-CrodipCentralRuntimeMenu {
    do {
        Clear-Host
        Write-Host "========================================" -ForegroundColor Cyan
        Write-Host " Runtime CENTRAL - TEST" -ForegroundColor Cyan
        Write-Host "========================================" -ForegroundColor Cyan
        Write-Host ""

        if(Test-CrodipCentralRuntimeInstalled){
            Write-Host "État installation : INSTALLÉ" -ForegroundColor Green
        }
        else {
            Write-Host "État installation : NON INSTALLÉ" -ForegroundColor Yellow
        }

        $menuConfig = Get-CrodipRuntimeConfig
        Write-Host ("Runtime     : {0}" -f $menuConfig.version)
        Write-Host ("Application : {0}" -f $menuConfig.application.version)
        Write-Host ("Cycle       : {0}" -f $menuConfig.docker.activeLifecycle)
        Write-Host "Frontend    : http://localhost:9120"
        Write-Host "Backend     : http://localhost:8120"
        Write-Host ""
        Write-Host "1. Installer le Runtime CENTRAL"
        Write-Host "2. Démarrer"
        Write-Host "3. Arrêter"
        Write-Host "4. État"
        Write-Host "5. Mettre à jour"
        Write-Host "6. Journaux"
        Write-Host "7. Désinstaller"
        Write-Host "8. Retour"
        Write-Host ""

        $choice = Read-Host "Votre choix"

        try {
            switch($choice){
                "1" { Initialize-CrodipCentralRuntime; Wait-CrodipUser }
                "2" { Start-CrodipCentralRuntime; Wait-CrodipUser }
                "3" { Stop-CrodipCentralRuntime; Wait-CrodipUser }
                "4" { Show-CrodipCentralRuntimeStatus; Wait-CrodipUser }
                "5" { Update-CrodipCentralRuntime; Wait-CrodipUser }
                "6" { Show-CrodipCentralRuntimeLogs; Wait-CrodipUser }
                "7" { Uninstall-CrodipCentralRuntime; Wait-CrodipUser }
                "8" { return }
                default {
                    Write-CrodipWarning "Choix invalide."
                    Start-Sleep -Seconds 1
                }
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

            if (Get-Command Wait-CrodipUser -ErrorAction SilentlyContinue) {
                Wait-CrodipUser
            }
            else {
                [void](Read-Host "Appuyez sur Entrée pour continuer")
            }
        }
    }
    while($true)
}

switch($Action){
    "menu"      { Show-CrodipCentralRuntimeMenu }
    "install"   { Initialize-CrodipCentralRuntime }
    "start"     { Start-CrodipCentralRuntime }
    "stop"      { Stop-CrodipCentralRuntime }
    "status"    { Show-CrodipCentralRuntimeStatus }
    "update"    { Update-CrodipCentralRuntime }
    "logs"      { Show-CrodipCentralRuntimeLogs }
    "uninstall" { Uninstall-CrodipCentralRuntime }
}
