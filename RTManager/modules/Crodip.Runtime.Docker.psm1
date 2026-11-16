###############################################################
# CRODIP Runtime Manager
# Module   : Crodip.Runtime.Docker.psm1
# Version  : 2.3.0-RC22
# Statut   : Stable - Lot 4
###############################################################

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

# RC41 STEP3A-FIX2: module Docker autonome ; résolution locale des chemins
# Runtime et Data afin de ne dépendre d’aucun helper exporté par un autre module.
function Get-CrodipDockerRuntimeHome {
    if (-not [string]::IsNullOrWhiteSpace($env:CRODIP_HOME)) { return $env:CRODIP_HOME }
    return (Join-Path $env:ProgramFiles "CRODIP")
}
function Get-CrodipDockerDataRoot {
    if (-not [string]::IsNullOrWhiteSpace($env:CRODIP_DATA_ROOT)) { return $env:CRODIP_DATA_ROOT }
    return (Join-Path $env:ProgramData "CRODIP")
}

if (-not (Get-Command Invoke-CrodipDockerCli -ErrorAction SilentlyContinue)) {
    Import-Module `
        (Join-Path $PSScriptRoot "Crodip.Runtime.DockerProvider.psm1") `
        -Global `
        -DisableNameChecking `
        -ErrorAction Stop
}


function Get-CrodipDockerDesktopExecutable {
    [CmdletBinding()]
    param()

    foreach ($path in @(
        "$env:ProgramFiles\Docker\Docker\Docker Desktop.exe",
        "$env:LOCALAPPDATA\Docker\Docker Desktop.exe"
    )) {
        if (Test-Path -LiteralPath $path) { return $path }
    }

    return $null
}

function Test-CrodipDockerDesktopInstalled {
    [CmdletBinding()]
    param()

    return -not [string]::IsNullOrWhiteSpace(
        (Get-CrodipDockerDesktopExecutable)
    )
}

function Test-CrodipDockerEngine {
    [CmdletBinding()]
    param()
    return Test-CrodipSelectedDockerEngine
}

function Start-CrodipDockerDesktop {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [ValidateRange(10, 600)]
        [int]$TimeoutSeconds = 120
    )

    if (Test-CrodipDockerEngine) { return $true }

    $executable = Get-CrodipDockerDesktopExecutable
    if ([string]::IsNullOrWhiteSpace($executable)) { return $false }

    if ($PSCmdlet.ShouldProcess($executable, "Démarrer Docker Desktop")) {
        Start-Process -FilePath $executable -WindowStyle Minimized | Out-Null
    }
    elseif ($WhatIfPreference) {
        return $true
    }

    $deadline = (Get-Date).AddSeconds($TimeoutSeconds)

    do {
        Start-Sleep -Seconds 3
        if (Test-CrodipDockerEngine) { return $true }
    }
    while ((Get-Date) -lt $deadline)

    return $false
}

function Get-CrodipDockerVersionInfo {
    [CmdletBinding()]
    param()

    $client = ""
    $server = ""
    $compose = ""

    if (Get-Command docker -ErrorAction SilentlyContinue) {
        $client = [string]((Invoke-CrodipDockerCli -Arguments @("version","--format","{{.Client.Version}}")).Output)
        $server = [string]((Invoke-CrodipDockerCli -Arguments @("version","--format","{{.Server.Version}}")).Output)
        $compose = [string](((Invoke-CrodipDockerCli -Arguments @("compose","version")).Output) -join " ")
    }

    [pscustomobject]@{
        Client = $client
        Server = $server
        Compose = $compose
    }
}

function Get-CrodipFixedContainerStatus {
    [CmdletBinding()]
    param()

    $definitions = @(
        @{ DisplayName = "API Backend"; ContainerName = "crodip-runtime-local-backend-1" },
        @{ DisplayName = "Frontend"; ContainerName = "crodip-runtime-local-frontend-1" }
    )

    foreach ($definition in $definitions) {
        $exists = $false
        $state = "Absent"
        $health = ""
        $image = ""
        $ports = ""

        if (Test-CrodipDockerEngine) {
            $id = [string]((Invoke-CrodipDockerCli -Arguments @("ps","-a","--filter","name=^/$($definition.ContainerName)$","--format","{{.ID}}")).Output)
            if (-not [string]::IsNullOrWhiteSpace($id)) {
                $exists = $true
                $state = [string]((Invoke-CrodipDockerCli -Arguments @("inspect","--format","{{.State.Status}}",$definition.ContainerName)).Output)
                $health = [string]((Invoke-CrodipDockerCli -Arguments @("inspect","--format","{{if .State.Health}}{{.State.Health.Status}}{{end}}",$definition.ContainerName)).Output)
                $image = [string]((Invoke-CrodipDockerCli -Arguments @("inspect","--format","{{.Config.Image}}",$definition.ContainerName)).Output)
                $ports = [string]((Invoke-CrodipDockerCli -Arguments @("port",$definition.ContainerName)).Output)
            }
        }

        [pscustomobject]@{
            DisplayName = $definition.DisplayName
            ContainerName = $definition.ContainerName
            Exists = $exists
            State = $state
            Health = $health
            Image = $image
            Ports = $ports
        }
    }
}

function Get-CrodipDockerInventory {
    [CmdletBinding()]
    param()

    if (-not (Test-CrodipDockerEngine)) {
        return [pscustomobject]@{
            Images = 0
            Containers = 0
            RunningContainers = 0
            Volumes = 0
            Networks = 0
        }
    }

    [pscustomobject]@{
        Images = @((Invoke-CrodipDockerCli -Arguments @("images","-q")).Output | Sort-Object -Unique).Count
        Containers = @((Invoke-CrodipDockerCli -Arguments @("ps","-aq")).Output).Count
        RunningContainers = @((Invoke-CrodipDockerCli -Arguments @("ps","-q")).Output).Count
        Volumes = @((Invoke-CrodipDockerCli -Arguments @("volume","ls","-q")).Output).Count
        Networks = @((Invoke-CrodipDockerCli -Arguments @("network","ls","-q")).Output).Count
    }
}

function Export-CrodipDockerReports {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][object[]]$Containers,
        [Parameter(Mandatory)][pscustomobject]$Versions,
        [Parameter(Mandatory)][pscustomobject]$Inventory,
        [string]$ReportsRoot
    )

    if ([string]::IsNullOrWhiteSpace($ReportsRoot)) {
        $ReportsRoot = Join-Path (Get-CrodipDockerDataRoot) "logs\reports"
    }

    $historyRoot = Join-Path $ReportsRoot "history"
    foreach ($path in @($ReportsRoot, $historyRoot)) {
        if (-not (Test-Path -LiteralPath $path)) {
            New-Item -ItemType Directory -Path $path -Force | Out-Null
        }
    }

    $timestamp = Get-Date -Format "yyyyMMdd-HHmmss"
    $payload = [ordered]@{
        generatedAt = (Get-Date).ToString("o")
        version = (Get-CrodipRuntimeVersion)
        docker = $Versions
        inventory = $Inventory
        containers = $Containers
    }

    $jsonPath = Join-Path $ReportsRoot "docker-report.json"
    $txtPath = Join-Path $ReportsRoot "docker-report.txt"
    $mdPath = Join-Path $ReportsRoot "docker-report.md"

    $payload | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath $jsonPath -Encoding utf8

    $txt = @(
        "CRODIP Docker Report",
        "Client : $($Versions.Client)",
        "Server : $($Versions.Server)",
        "Compose : $($Versions.Compose)",
        "Images : $($Inventory.Images)",
        "Conteneurs : $($Inventory.Containers)",
        "Conteneurs actifs : $($Inventory.RunningContainers)",
        "Volumes : $($Inventory.Volumes)",
        "Réseaux : $($Inventory.Networks)",
        ""
    )
    foreach ($container in $Containers) {
        $txt += "$($container.DisplayName) [$($container.ContainerName)] : $($container.State)"
    }
    $txt | Set-Content -LiteralPath $txtPath -Encoding utf8

    $md = @(
        "# CRODIP Docker Report",
        "",
        "- Client : $($Versions.Client)",
        "- Server : $($Versions.Server)",
        "- Compose : $($Versions.Compose)",
        "- Images : $($Inventory.Images)",
        "- Conteneurs actifs : $($Inventory.RunningContainers)",
        "",
        "| Service | Conteneur | État | Santé | Image | Ports |",
        "|---|---|---|---|---|---|"
    )
    foreach ($container in $Containers) {
        $safePorts = ([string]$container.Ports).Replace("|", "\|")
        $md += "| $($container.DisplayName) | $($container.ContainerName) | $($container.State) | $($container.Health) | $($container.Image) | $safePorts |"
    }
    $md | Set-Content -LiteralPath $mdPath -Encoding utf8

    Copy-Item $jsonPath (Join-Path $historyRoot "docker-$timestamp.json") -Force
    Copy-Item $txtPath (Join-Path $historyRoot "docker-$timestamp.txt") -Force
    Copy-Item $mdPath (Join-Path $historyRoot "docker-$timestamp.md") -Force

    [pscustomobject]@{ Json=$jsonPath; Text=$txtPath; Markdown=$mdPath; History=$historyRoot }
}


function Get-CrodipEnvValue {
 [CmdletBinding()]param([Parameter(Mandatory)][string]$Name,[string]$EnvFile=(Join-Path (Get-CrodipDockerRuntimeHome) ".env"))
 if(-not(Test-Path -LiteralPath $EnvFile)){return $null}
 $line=Get-Content -LiteralPath $EnvFile | Where-Object {$_ -match "^\s*$([regex]::Escape($Name))\s*="} | Select-Object -Last 1
 if(-not $line){return $null}
 return (($line -split '=',2)[1]).Trim().Trim('"').Trim("'")
}
function Set-CrodipEnvValue {
 [CmdletBinding(SupportsShouldProcess=$true)]param([Parameter(Mandatory)][string]$Name,[Parameter(Mandatory)][string]$Value,[string]$EnvFile=(Join-Path (Get-CrodipDockerRuntimeHome) ".env"))
 $lines=if(Test-Path -LiteralPath $EnvFile){@(Get-Content -LiteralPath $EnvFile)}else{@()};$found=$false
 for($i=0;$i -lt $lines.Count;$i++){if($lines[$i] -match "^\s*$([regex]::Escape($Name))\s*="){$lines[$i]="$Name=$Value";$found=$true}}
 if(-not $found){$lines+="$Name=$Value"}
 if($PSCmdlet.ShouldProcess($EnvFile,"Définir $Name")){$lines|Set-Content -LiteralPath $EnvFile -Encoding utf8}
}
function Test-CrodipRegistryAccess {
 [CmdletBinding()]param([string]$RegistryHost="ghcr.io",[int]$TimeoutSeconds=5)
 try{$client=[System.Net.Sockets.TcpClient]::new();$task=$client.ConnectAsync($RegistryHost,443);if(-not $task.Wait([TimeSpan]::FromSeconds($TimeoutSeconds))){$client.Dispose();return $false};$ok=$client.Connected;$client.Dispose();return $ok}catch{return $false}
}
function Test-CrodipDockerImage {[CmdletBinding()]param([Parameter(Mandatory)][string]$Image);$r=Invoke-CrodipDockerCli -Arguments @("image","inspect",$Image);return $r.ExitCode -eq 0}
function Get-CrodipImagesManifestPath {[CmdletBinding()]param();return (Join-Path (Get-CrodipDockerRuntimeHome) "images\images-manifest.json")}
function Import-CrodipOfflineImages {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [string]$ManifestPath=(Get-CrodipImagesManifestPath),
        [string]$ImagesRoot=(Join-Path (Get-CrodipDockerRuntimeHome) "images"),
        [switch]$SuppressExistingImageMessages
    )

    if(-not(Test-Path -LiteralPath $ManifestPath)){
        throw "Manifest des images absent : $ManifestPath"
    }

    $manifest=Get-Content -LiteralPath $ManifestPath -Raw | ConvertFrom-Json
    $tag = Get-CrodipRuntimeImageTag

    foreach($entry in $manifest.images){
        $service = [string]$entry.service
        $image = Get-CrodipRuntimeImage -Service $service -Target "local"

        if(Test-CrodipDockerImage -Image $image){
            if (-not $SuppressExistingImageMessages) {
                Write-CrodipSuccess "Image présente : $image"
            }
            continue
        }

        $archiveName = ([string]$entry.archivePattern).Replace("{tag}", $tag)
        $archive=Join-Path $ImagesRoot $archiveName

        if(-not(Test-Path -LiteralPath $archive)){
            if($entry.required){
                throw "Archive offline requise absente : $archive"
            }
            Write-CrodipWarning "Archive optionnelle absente : $archive"
            continue
        }

        if($PSCmdlet.ShouldProcess($archive,"Importer l'image $image")){
            $r=Invoke-CrodipDockerCli -Arguments @("image","load","--input",$archive)
            if($r.ExitCode -ne 0){
                throw "Échec de l'import : $archive"
            }
        }
    }
}
function Test-CrodipRegistryCredentialConfigured {
    [CmdletBinding()]
    param(
        [string]$Registry = "ghcr.io"
    )

    $configPath = Join-Path $HOME ".docker\config.json"

    if (-not (Test-Path -LiteralPath $configPath -PathType Leaf)) {
        return $false
    }

    try {
        $cfg = Get-Content -LiteralPath $configPath -Raw | ConvertFrom-Json
    }
    catch {
        return $false
    }

    if (
        $cfg.PSObject.Properties.Name -contains "auths" -and
        $null -ne $cfg.auths
    ) {
        $registryProperty = $cfg.auths.PSObject.Properties[$Registry]
        if ($null -ne $registryProperty) {
            return $true
        }
    }

    if (
        $cfg.PSObject.Properties.Name -contains "credsStore" -and
        -not [string]::IsNullOrWhiteSpace([string]$cfg.credsStore)
    ) {
        return $true
    }

    if (
        $cfg.PSObject.Properties.Name -contains "credHelpers" -and
        $null -ne $cfg.credHelpers
    ) {
        $registryHelper = $cfg.credHelpers.PSObject.Properties[$Registry]
        if ($null -ne $registryHelper) {
            return $true
        }
    }

    return $false
}

function Test-CrodipRegistryReadAccess {
    [CmdletBinding()]
    param(
        [string]$Image = ""
    )

    if ([string]::IsNullOrWhiteSpace($Image)) {
        $Image = Get-CrodipRuntimeImage -Service "backend" -Target "local"
    }

    try {
        $r = Invoke-CrodipDockerCli `
            -Arguments @(
                "manifest",
                "inspect",
                $Image
            )

        return ($r.ExitCode -eq 0)
    }
    catch {
        return $false
    }
}

function Connect-CrodipRegistry {
    [CmdletBinding()]
    param(
        [string]$Registry = "ghcr.io",
        [string]$UserName = "IDWEBCONCEPT"
    )

    Write-Host ""
    Write-Host "==> Connexion GitHub Container Registry (GHCR)" -ForegroundColor Cyan
    Write-Host "Utilisateur GitHub : $UserName"
    Write-Host "Le Personal Access Token ne sera ni affiché ni journalisé."
    Write-Host "Runtime : scope minimal recommandé = read:packages."
    Write-Host ""

    $secureToken = Read-Host `
        "Personal Access Token GitHub" `
        -AsSecureString

    $ptr = [IntPtr]::Zero
    $token = $null
    $oldOutputEncoding = $OutputEncoding

    try {
        $ptr = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($secureToken)
        $token = [Runtime.InteropServices.Marshal]::PtrToStringBSTR($ptr)

        if ([string]::IsNullOrWhiteSpace($token)) {
            throw "Aucun token fourni."
        }

        # Docker login --password-stdin : envoyer le PAT en UTF-8 sans BOM.
        $OutputEncoding = [System.Text.UTF8Encoding]::new($false)

        $loginArgs = @(
            "login",
            $Registry,
            "-u",
            $UserName,
            "--password-stdin"
        )

        if ((Get-CrodipDockerProvider) -eq "desktop") {
            $token | & docker @loginArgs
            $code = $LASTEXITCODE
        }
        else {
            $distribution = Get-CrodipWslDistribution
            $token | & wsl.exe -d $distribution -- docker @loginArgs
            $code = $LASTEXITCODE
        }

        if ($code -ne 0) {
            throw @"
Authentification GHCR refusée (code $code).
Vérifier :
- PAT GitHub valide ;
- scope read:packages ;
- autorisation SSO éventuelle ;
- droits du compte sur les packages CRODIP.
"@
        }

        Write-CrodipSuccess "Connexion Docker au registre $Registry réussie."
        return $true
    }
    finally {
        $OutputEncoding = $oldOutputEncoding

        if ($ptr -ne [IntPtr]::Zero) {
            [Runtime.InteropServices.Marshal]::ZeroFreeBSTR($ptr)
        }

        $token = $null
        $secureToken = $null

        Remove-Variable token -ErrorAction SilentlyContinue
        Remove-Variable secureToken -ErrorAction SilentlyContinue
        Remove-Variable ptr -ErrorAction SilentlyContinue
    }
}

function Disconnect-CrodipRegistry {
    [CmdletBinding()]
    param(
        [string]$Registry = "ghcr.io"
    )

    $r = Invoke-CrodipDockerCli `
        -Arguments @(
            "logout",
            $Registry
        )

    if ($r.ExitCode -ne 0) {
        throw "Échec de la déconnexion de $Registry."
    }

    Write-CrodipSuccess "Déconnexion de $Registry réussie."
}

function Get-CrodipRegistryStatus {
    [CmdletBinding()]
    param(
        [string]$Registry = "ghcr.io",
        [string]$TestImage = ""
    )

    if ([string]::IsNullOrWhiteSpace($TestImage)) {
        $TestImage = Get-CrodipRuntimeImage -Service "backend" -Target "local"
    }

    $network = Test-CrodipRegistryAccess -RegistryHost $Registry
    $credentialConfigured = Test-CrodipRegistryCredentialConfigured -Registry $Registry

    $readAccess = $false
    if ($network) {
        $readAccess = Test-CrodipRegistryReadAccess -Image $TestImage
    }

    [pscustomobject]@{
        Registry = $Registry
        NetworkAvailable = $network
        CredentialsConfigured = $credentialConfigured
        ReadAccess = $readAccess
        TestImage = $TestImage
        DockerConfig = (Join-Path $HOME ".docker\config.json")
    }
}

function Get-CrodipDeploymentMode {[CmdletBinding()]param();$mode=Get-CrodipEnvValue -Name "CRODIP_DEPLOYMENT_MODE";if([string]::IsNullOrWhiteSpace($mode)){return "auto"};return $mode.ToLowerInvariant()}

function Get-CrodipPackagedImagesManifest {
    [CmdletBinding()]
    param()

    $path = Join-Path (Get-CrodipRuntimeRoot) "images\images-manifest.json"

    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) {
        return $null
    }

    try {
        return (Get-Content -LiteralPath $path -Raw | ConvertFrom-Json)
    }
    catch {
        return $null
    }
}

function Get-CrodipExpectedImageForService {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Service
    )

    try {
        return (Get-CrodipRuntimeImage -Service $Service -Target "local")
    }
    catch {
        return $null
    }
}

function Test-CrodipLegacyImageReference {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Image
    )

    return (
        $Image -match '^(?i:idwebconcept/crodip-(backend|frontend):)' -or
        $Image -match '^(?i:docker\.io/idwebconcept/crodip-(backend|frontend):)'
    )
}

function Repair-CrodipLegacyImageConfiguration {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [Parameter(Mandatory)][string]$ComposeFile,
        [Parameter(Mandatory)][object[]]$ServiceDefinitions
    )

    $legacy = @(
        $ServiceDefinitions |
            Where-Object {
                $_.Image -ne "<build/local>" -and
                (Test-CrodipLegacyImageReference -Image $_.Image)
            }
    )

    if ($legacy.Count -eq 0) {
        return $false
    }

    Write-CrodipWarning "Anciennes références d'images CRODIP détectées."
    Write-Host ""

    foreach ($service in $legacy) {
        $expected = Get-CrodipExpectedImageForService -Service $service.Name
        if ([string]::IsNullOrWhiteSpace($expected)) {
            $expected = "ghcr.io/$($service.Image -replace '^docker\.io/','')"
        }

        Write-Host (" - {0,-12} actuel : {1}" -f $service.Name,$service.Image)
        Write-Host ("   {0,-12} cible  : {1}" -f "",$expected)
    }

    Write-Host ""
    Write-CrodipWarning "Ces références utilisent Docker Hub et empêchent le précontrôle GHCR."

    $answer = Read-Host "Migrer maintenant la configuration des images vers GHCR ? [O/n]"
    if ([string]::IsNullOrWhiteSpace($answer)) { $answer = "O" }

    if ($answer -notmatch '^[oOyY]$') {
        Write-CrodipWarning "Migration des images ignorée."
        return $false
    }

    $envFile = Join-Path (Split-Path -Parent $ComposeFile) ".env"

    if (Test-Path -LiteralPath $envFile -PathType Leaf) {
        $stamp = Get-Date -Format "yyyyMMdd-HHmmss"
        $backup = "$envFile.before-ghcr-$stamp.bak"

        if ($PSCmdlet.ShouldProcess($envFile,"Sauvegarder la configuration avant migration GHCR")) {
            Copy-Item -LiteralPath $envFile -Destination $backup -Force
            Write-CrodipSuccess "Sauvegarde .env créée : $backup"
        }
    }

    $changed = $false

    foreach ($service in $legacy) {
        $expected = Get-CrodipExpectedImageForService -Service $service.Name
        if ([string]::IsNullOrWhiteSpace($expected)) {
            $expected = "ghcr.io/$($service.Image -replace '^docker\.io/','')"
        }

        $variableName = switch ($service.Name.ToLowerInvariant()) {
            "backend"  { "CRODIP_BACKEND_IMAGE" }
            "frontend" { "CRODIP_FRONTEND_IMAGE" }
            default    { $null }
        }

        if (-not [string]::IsNullOrWhiteSpace($variableName)) {
            Set-CrodipEnvValue `
                -Name $variableName `
                -Value $expected `
                -EnvFile $envFile `
                -Confirm:$false

            Write-CrodipSuccess "$variableName=$expected"
            $changed = $true
            continue
        }

        Write-CrodipWarning "Service $($service.Name) : variable d'image non reconnue, aucune modification automatique."
    }

    return $changed
}



function Get-CrodipContainerConflictInfo {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$ContainerName
    )

    try {
        $r = Invoke-CrodipDockerCli -Arguments @(
            "inspect",
            $ContainerName
        )

        if ($r.ExitCode -ne 0) {
            return $null
        }

        $obj = ($r.Output -join "`n") | ConvertFrom-Json -Depth 100
        if ($obj -is [array]) {
            $obj = $obj | Select-Object -First 1
        }

        $labels = $obj.Config.Labels

        $composeProject = ""
        $composeService = ""
        $composeWorkingDir = ""
        $composeConfigFiles = ""

        if ($null -ne $labels) {
            if ($labels.PSObject.Properties.Name -contains "com.docker.compose.project") {
                $composeProject = [string]$labels."com.docker.compose.project"
            }
            if ($labels.PSObject.Properties.Name -contains "com.docker.compose.service") {
                $composeService = [string]$labels."com.docker.compose.service"
            }
            if ($labels.PSObject.Properties.Name -contains "com.docker.compose.project.working_dir") {
                $composeWorkingDir = [string]$labels."com.docker.compose.project.working_dir"
            }
            if ($labels.PSObject.Properties.Name -contains "com.docker.compose.project.config_files") {
                $composeConfigFiles = [string]$labels."com.docker.compose.project.config_files"
            }
        }

        [pscustomobject]@{
            Name = ([string]$obj.Name).TrimStart("/")
            Id = [string]$obj.Id
            Image = [string]$obj.Config.Image
            State = [string]$obj.State.Status
            Running = [bool]$obj.State.Running
            Created = [string]$obj.Created
            ComposeProject = $composeProject
            ComposeService = $composeService
            ComposeWorkingDir = $composeWorkingDir
            ComposeConfigFiles = $composeConfigFiles
            IsCrodip = (
                ([string]$obj.Name -match '(?i)crodip') -or
                ($composeProject -match '(?i)crodip') -or
                ($composeService -match '(?i)(backend|frontend)' -and [string]$obj.Config.Image -match '(?i)crodip')
            )
        }
    }
    catch {
        return $null
    }
}

function Get-CrodipExpectedContainerNames {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$ComposeFile
    )

    $wd = Split-Path -Parent $ComposeFile
    $file = Split-Path -Leaf $ComposeFile

    $r = Invoke-CrodipDockerCli `
        -Arguments @("compose","-f",$file,"config","--format","json") `
        -WorkingDirectory $wd

    if ($r.ExitCode -ne 0) {
        return @()
    }

    try {
        $cfg = ($r.Output -join "`n") | ConvertFrom-Json -Depth 100
    }
    catch {
        return @()
    }

    $names = @()

    foreach ($prop in $cfg.services.PSObject.Properties) {
        $svc = $prop.Value

        if (
            $null -ne $svc -and
            $svc.PSObject.Properties.Name -contains "container_name"
        ) {
            $containerName = [string]$svc.container_name

            if (-not [string]::IsNullOrWhiteSpace($containerName)) {
                $names += $containerName
            }
        }
    }

    return @($names | Select-Object -Unique)
}

function Resolve-CrodipContainerConflicts {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [Parameter(Mandatory)][string]$ComposeFile
    )

    $expected = @(Get-CrodipExpectedContainerNames -ComposeFile $ComposeFile)

    if ($expected.Count -eq 0) {
        Write-CrodipSuccess "Aucun container_name fixe : isolation Compose active."

        return [pscustomobject]@{
            Found = $false
            Removed = 0
            Blocking = 0
            Details = @()
        }
    }

    $conflicts = @()

    foreach ($name in $expected) {
        $info = Get-CrodipContainerConflictInfo -ContainerName $name
        if ($null -ne $info) {
            $conflicts += $info
        }
    }

    if ($conflicts.Count -eq 0) {
        Write-CrodipSuccess "Aucun conflit de nom de conteneur CRODIP détecté."

        return [pscustomobject]@{
            Found = $false
            Removed = 0
            Blocking = 0
            Details = @()
        }
    }

    Write-CrodipWarning "Conteneurs existants utilisant des noms attendus par CRODIP :"
    Write-Host ""

    foreach ($c in $conflicts) {
        Write-Host "Conteneur : $($c.Name)"
        Write-Host "  ID court          : $($c.Id.Substring(0,[Math]::Min(12,$c.Id.Length)))"
        Write-Host "  État              : $($c.State)"
        Write-Host "  Image             : $($c.Image)"
        Write-Host "  Projet Compose    : $($c.ComposeProject)"
        Write-Host "  Service Compose   : $($c.ComposeService)"
        Write-Host "  Working dir       : $($c.ComposeWorkingDir)"
        Write-Host "  Config Compose    : $($c.ComposeConfigFiles)"
        Write-Host "  Identifié CRODIP  : $($c.IsCrodip)"
        Write-Host ""
    }

    $crodipConflicts = @($conflicts | Where-Object { $_.IsCrodip })
    $unknownConflicts = @($conflicts | Where-Object { -not $_.IsCrodip })

    $removed = 0

    if ($crodipConflicts.Count -gt 0) {
        $answer = Read-Host "Supprimer les anciens conteneurs CRODIP et poursuivre ? [O/n]"
        if ([string]::IsNullOrWhiteSpace($answer)) { $answer = "O" }

        if ($answer -match '^[oOyY]$') {
            foreach ($c in $crodipConflicts) {
                if ($PSCmdlet.ShouldProcess($c.Name,"Supprimer le conteneur en conflit")) {
                    $r = Invoke-CrodipDockerCli -Arguments @("rm","-f",$c.Name)

                    if ($r.ExitCode -eq 0) {
                        Write-CrodipSuccess "Conteneur supprimé : $($c.Name)"
                        $removed++
                    }
                    else {
                        Write-CrodipWarning "Échec suppression : $($c.Name)"
                        $r.Output | ForEach-Object { Write-Host " $_" }
                    }
                }
            }
        }
        else {
            Write-CrodipWarning "Suppression des anciens conteneurs CRODIP ignorée."
        }
    }

    if ($unknownConflicts.Count -gt 0) {
        Write-CrodipError "Un ou plusieurs conteneurs inconnus utilisent un nom réservé CRODIP."
        Write-CrodipWarning "Ils ne seront pas supprimés automatiquement."
    }

    $remaining = 0
    foreach ($name in $expected) {
        if ($null -ne (Get-CrodipContainerConflictInfo -ContainerName $name)) {
            $remaining++
        }
    }

    [pscustomobject]@{
        Found = $true
        Removed = $removed
        Blocking = $remaining
        Details = $conflicts
    }
}


function Assert-CrodipRequiredImagesLocal {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [array]$ServiceDefinitions,
        [string]$Context = "OFFLINE"
    )

    $missing = @(
        $ServiceDefinitions | Where-Object {
            $_.Image -eq "<build/local>" -or
            -not (Test-CrodipDockerImageLocal -Image $_.Image)
        }
    )

    if ($missing.Count -gt 0) {
        Write-CrodipError ("Images requises absentes en mode {0} :" -f $Context)
        foreach ($item in $missing) {
            Write-Host (" - {0} : {1}" -f $item.Name,$item.Image)
        }
        throw "Démarrage impossible : au moins une image requise est absente localement."
    }

    foreach ($item in $ServiceDefinitions) {
        Write-CrodipSuccess ("Image locale disponible : {0} -> {1}" -f $item.Name,$item.Image)
    }

    return $true
}

function Start-CrodipRuntimeAuto {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [Parameter(Mandatory)]
        [string]$ComposeFile
    )

    $mode = Get-CrodipDeploymentMode

    if ($mode -notin @("auto","online","offline")) {
        throw "Mode invalide : $mode"
    }

    Write-CrodipStep "Politique de connectivité"
    Write-Host ("Mode configuré : {0}" -f $mode.ToUpperInvariant())

    $services = @(Get-CrodipComposeServices -ComposeFile $ComposeFile)

    if ($services.Count -eq 0) {
        throw "Aucun service détecté dans compose.yaml."
    }

    $serviceDefinitions = @(
        foreach ($serviceName in $services) {
            $image = Get-CrodipComposeServiceImage `
                -ComposeFile $ComposeFile `
                -Service $serviceName

            if ([string]::IsNullOrWhiteSpace($image)) {
                $image = "<build/local>"
            }

            [pscustomobject]@{
                Name  = $serviceName
                Image = $image
            }
        }
    )

    Write-CrodipStep "Services détectés dans Compose"
    foreach ($service in $serviceDefinitions) {
        Write-Host (" - {0,-15} {1}" -f $service.Name,$service.Image)
    }

    $legacyDetected = @(
        $serviceDefinitions |
            Where-Object {
                $_.Image -ne "<build/local>" -and
                (Test-CrodipLegacyImageReference -Image $_.Image)
            }
    )

    if ($legacyDetected.Count -gt 0) {
        $repaired = Repair-CrodipLegacyImageConfiguration `
            -ComposeFile $ComposeFile `
            -ServiceDefinitions $serviceDefinitions `
            -Confirm:$false

        if ($repaired) {
            Write-CrodipStep "Relecture de la configuration Compose après migration GHCR"

            $services = @(Get-CrodipComposeServices -ComposeFile $ComposeFile)
            $serviceDefinitions = @(
                foreach ($serviceName in $services) {
                    $image = Get-CrodipComposeServiceImage `
                        -ComposeFile $ComposeFile `
                        -Service $serviceName

                    if ([string]::IsNullOrWhiteSpace($image)) {
                        $image = "<build/local>"
                    }

                    [pscustomobject]@{
                        Name  = $serviceName
                        Image = $image
                    }
                }
            )

            foreach ($service in $serviceDefinitions) {
                Write-Host (" - {0,-15} {1}" -f $service.Name,$service.Image)
            }
        }
    }

    # OFFLINE : aucun accès registre requis.
    if ($mode -eq "offline") {
        Write-CrodipWarning "Mode OFFLINE : aucun pull GHCR ne sera effectué."

        # L'import d'archives packagées historique concerne uniquement le Runtime LOCAL.
        # CENTRAL s'appuie sur les images déclarées dans son Compose (postgres/backend/frontend)
        # et leur présence est contrôlée juste après par Assert-CrodipRequiredImagesLocal.
        $isLocalRuntime = @($serviceDefinitions | Where-Object { $_.Image -match 'crodip-local-(backend|frontend)' }).Count -gt 0
        if ($isLocalRuntime) {
            try {
                Import-CrodipOfflineImages `
                    -SuppressExistingImageMessages `
                    -WhatIf:$WhatIfPreference `
                    -Confirm:$false
            }
            catch {
                Write-CrodipWarning "Import offline impossible : $($_.Exception.Message)"
            }
        }

        Write-Host "Mode effectif   : OFFLINE"
        $null = Assert-CrodipRequiredImagesLocal -ServiceDefinitions $serviceDefinitions -Context "OFFLINE"

        return Invoke-CrodipCompose `
            -Action "up" `
            -ComposeFile $ComposeFile `
            -Detached `
            -RemoveOrphans `
            -ForceRecreate `
            -PullPolicy "never" `
            -WhatIf:$WhatIfPreference `
            -Confirm:$false
    }

    # AUTO / ONLINE : vérifier d'abord la disponibilité réseau du registre.
    $registryReachable = Test-CrodipRegistryAccess

    if (-not $registryReachable) {
        if ($mode -eq "online") {
            throw @"
GHCR inaccessible en mode ONLINE.
Vérifier :
- connexion Internet ;
- résolution DNS de ghcr.io ;
- pare-feu / proxy ;
- disponibilité de Docker Engine.
"@
        }

        Write-CrodipWarning "GHCR inaccessible : bascule vers les images locales/offline."
        # Les archives offline packagées historiques sont LOCAL uniquement.
        $isLocalRuntime = @($serviceDefinitions | Where-Object { $_.Image -match 'crodip-local-(backend|frontend)' }).Count -gt 0
        if ($isLocalRuntime) {
            try {
                Import-CrodipOfflineImages `
                    -SuppressExistingImageMessages `
                    -WhatIf:$WhatIfPreference `
                    -Confirm:$false
            }
            catch {
                Write-CrodipWarning "Import offline impossible : $($_.Exception.Message)"
            }
        }

        Write-Host "Mode effectif   : OFFLINE (fallback AUTO)"
        $null = Assert-CrodipRequiredImagesLocal -ServiceDefinitions $serviceDefinitions -Context "AUTO/OFFLINE"

        return Invoke-CrodipCompose `
            -Action "up" `
            -ComposeFile $ComposeFile `
            -Detached `
            -RemoveOrphans `
            -ForceRecreate `
            -PullPolicy "never" `
            -WhatIf:$WhatIfPreference `
            -Confirm:$false
    }

    Write-Host "Mode effectif   : ONLINE (registre accessible)"

    # Contrôle d'authentification GHCR uniquement si des images GHCR sont utilisées.
    $ghcrServices = @(
        $serviceDefinitions |
            Where-Object {
                $_.Image -match '^ghcr\.io/'
            }
    )

    if ($ghcrServices.Count -gt 0) {
        Write-CrodipStep "Vérification de l'accès GHCR"

        $credentialConfigured = Test-CrodipRegistryCredentialConfigured `
            -Registry "ghcr.io"

        if ($credentialConfigured) {
            Write-CrodipSuccess "Identifiants Docker GHCR configurés."
        }
        else {
            Write-CrodipWarning "Aucun identifiant GHCR détecté dans la configuration Docker."
        }

        $testImage = $ghcrServices[0].Image
        $readAccess = Test-CrodipRegistryReadAccess -Image $testImage

        if ($readAccess) {
            Write-CrodipSuccess "Accès en lecture GHCR validé."
        }
        else {
            Write-CrodipWarning "Accès en lecture GHCR non validé pour $testImage."
            Write-Host ""

            $loginAnswer = Read-Host "Se connecter à GHCR maintenant ? [O/n]"
            if ([string]::IsNullOrWhiteSpace($loginAnswer)) {
                $loginAnswer = "O"
            }

            if ($loginAnswer -match '^[oOyY]$') {
                Write-CrodipStep "Connexion GitHub Container Registry (GHCR)"

                try {
                    $loginOk = Connect-CrodipRegistry `
                        -Registry "ghcr.io"

                    if ($loginOk) {
                        Write-CrodipStep "Nouveau test d'accès GHCR"

                        $readAccess = Test-CrodipRegistryReadAccess `
                            -Image $testImage

                        if ($readAccess) {
                            Write-CrodipSuccess "Authentification GHCR validée."
                        }
                        else {
                            Write-CrodipWarning "Connexion effectuée mais accès en lecture toujours refusé."
                        }
                    }
                }
                catch {
                    Write-CrodipWarning "Connexion GHCR impossible : $($_.Exception.Message)"
                    $readAccess = $false
                }
            }
            else {
                Write-CrodipWarning "Connexion GHCR ignorée par l'utilisateur."
            }

            if (-not $readAccess) {
                if ($mode -eq "online") {
                    throw @"
Authentification ou autorisation GHCR insuffisante en mode ONLINE.
Le démarrage ne peut pas poursuivre sans accès en lecture aux images CRODIP.
Vous pouvez aussi utiliser :
Administration Docker > Connexion GHCR
puis relancer le démarrage.
"@
                }

                Write-CrodipWarning "Mode AUTO : tentative de poursuite avec les images locales."
            }
        }
    }

    Write-CrodipStep "Téléchargement des images depuis GHCR"

    $pullResults = @()

    foreach ($service in $serviceDefinitions) {
        if ($service.Image -eq "<build/local>") {
            Write-CrodipWarning "Service $($service.Name) : aucune image distante déclarée."
            $pullResults += [pscustomobject]@{
                Service = $service.Name
                Image   = $service.Image
                Result  = "LOCAL_BUILD"
                Kind    = ""
            }
            continue
        }

        Write-CrodipStep "Pull du service $($service.Name)"

        $pull = Invoke-CrodipCompose `
            -Action "pull" `
            -ComposeFile $ComposeFile `
            -Services @($service.Name) `
            -WhatIf:$WhatIfPreference `
            -Confirm:$false

        if ($pull.ExitCode -eq 0) {
            Write-CrodipSuccess "Image disponible : $($service.Name)"

            $pullResults += [pscustomobject]@{
                Service = $service.Name
                Image   = $service.Image
                Result  = "PULLED"
                Kind    = ""
            }

            continue
        }

        $kind = Get-CrodipDockerPullFailureKind `
            -Output $pull.Output

        Write-CrodipWarning "Pull impossible pour $($service.Name) [$kind]."

        foreach ($line in $pull.Output) {
            Write-Host " $line"
        }

        $localAvailable = (
            $service.Image -ne "<build/local>" -and
            (Test-CrodipDockerImageLocal -Image $service.Image)
        )

        if ($localAvailable) {
            Write-CrodipWarning "Image locale disponible pour $($service.Name)."

            $pullResults += [pscustomobject]@{
                Service = $service.Name
                Image   = $service.Image
                Result  = "LOCAL"
                Kind    = $kind
            }

            continue
        }

        $pullResults += [pscustomobject]@{
            Service = $service.Name
            Image   = $service.Image
            Result  = "FAILED"
            Kind    = $kind
        }
    }

    Write-Host ""
    Write-Host "Résumé téléchargement Docker" -ForegroundColor Cyan
    Write-Host "------------------------------"

    foreach ($r in $pullResults) {
        Write-Host (
            "{0,-12} {1,-12} {2,-10} {3}" -f `
                $r.Service,$r.Result,$r.Kind,$r.Image
        )
    }

    $failed = @(
        $pullResults |
            Where-Object { $_.Result -eq "FAILED" }
    )

    if ($failed.Count -gt 0) {
        if ($mode -eq "online") {
            $authFailures = @($failed | Where-Object { $_.Kind -eq "AUTH" })
            $notFoundFailures = @($failed | Where-Object { $_.Kind -eq "NOT_FOUND" })
            $networkFailures = @($failed | Where-Object { $_.Kind -eq "NETWORK" })

            if ($authFailures.Count -gt 0) {
                throw "Démarrage bloqué : authentification/autorisation GHCR insuffisante."
            }

            if ($notFoundFailures.Count -gt 0) {
                throw "Démarrage bloqué : une ou plusieurs images/tags sont absents du registre."
            }

            if ($networkFailures.Count -gt 0) {
                throw "Démarrage bloqué : erreur réseau ou Docker Engine pendant le pull."
            }

            throw "Démarrage bloqué : certaines images sont indisponibles en mode ONLINE."
        }

        Write-CrodipWarning "Mode AUTO : recherche d'images offline pour les services manquants."

        try {
            Import-CrodipOfflineImages `
                -SuppressExistingImageMessages `
                -WhatIf:$WhatIfPreference `
                -Confirm:$false
        }
        catch {
            Write-CrodipWarning "Import offline impossible : $($_.Exception.Message)"
        }

        $stillMissing = @()

        foreach ($failure in $failed) {
            if (
                $failure.Image -eq "<build/local>" -or
                -not (Test-CrodipDockerImageLocal -Image $failure.Image)
            ) {
                $stillMissing += $failure
            }
        }

        if ($stillMissing.Count -gt 0) {
            Write-CrodipError "Images encore absentes après fallback AUTO :"
            foreach ($item in $stillMissing) {
                Write-Host " - $($item.Service) : $($item.Image)"
            }

            throw "Démarrage impossible : au moins une image requise est indisponible."
        }
    }

    Write-CrodipStep "Contrôle des conflits de conteneurs"

    $conflictResult = Resolve-CrodipContainerConflicts `
        -ComposeFile $ComposeFile `
        -Confirm:$false

    if ($conflictResult.Blocking -gt 0) {
        throw "Démarrage impossible : conflit de nom de conteneur non résolu."
    }

    Write-CrodipStep "Démarrage des services CRODIP"

    return Invoke-CrodipCompose `
        -Action "up" `
        -ComposeFile $ComposeFile `
        -Detached `
        -RemoveOrphans `
        -ForceRecreate `
        -PullPolicy "never" `
        -WhatIf:$WhatIfPreference `
        -Confirm:$false
}

function Test-CrodipDockerImageLocal {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$Image
    )

    $r = Invoke-CrodipDockerCli -Arguments @(
        "image",
        "inspect",
        $Image
    )

    return ($r.ExitCode -eq 0)
}

function Get-CrodipDockerPullFailureKind {
    [CmdletBinding()]
    param(
        [string[]]$Output
    )

    $text = ($Output -join "`n").ToLowerInvariant()

    if (
        $text -match "not found" -or
        $text -match "manifest unknown"
    ) {
        return "NOT_FOUND"
    }

    if (
        $text -match "unauthorized" -or
        $text -match "denied" -or
        $text -match "permission_denied"
    ) {
        return "AUTH"
    }

    if (
        $text -match "timeout" -or
        $text -match "broken pipe" -or
        $text -match "connection" -or
        $text -match "500 internal server error"
    ) {
        return "NETWORK"
    }

    return "UNKNOWN"
}


function Get-CrodipComposeServiceImages {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$ComposeFile
    )

    $workingDirectory = Split-Path -Parent $ComposeFile
    $composeName = Split-Path -Leaf $ComposeFile

    $args = @(
        "compose",
        "-f",
        $composeName,
        "config",
        "--images"
    )

    $r = Invoke-CrodipDockerCli `
        -Arguments $args `
        -WorkingDirectory $workingDirectory

    if ($r.ExitCode -ne 0) {
        throw "Impossible de lire les images définies dans Compose."
    }

    $images = @(
        $r.Output |
            ForEach-Object { ([string]$_).Trim() } |
            Where-Object { -not [string]::IsNullOrWhiteSpace($_) }
    )

    return $images
}


function Get-CrodipComposeServices {
    [CmdletBinding()]
    param([Parameter(Mandatory)][string]$ComposeFile)

    $wd = Split-Path -Parent $ComposeFile
    $file = Split-Path -Leaf $ComposeFile
    $r = Invoke-CrodipDockerCli -Arguments @(
        "compose","-f",$file,"config","--services"
    ) -WorkingDirectory $wd

    if ($r.ExitCode -ne 0) {
        throw "Impossible de découvrir les services du fichier Compose."
    }

    return @(
        $r.Output |
        ForEach-Object { ([string]$_).Trim() } |
        Where-Object { -not [string]::IsNullOrWhiteSpace($_) }
    )
}

function Get-CrodipComposeServiceImage {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$ComposeFile,
        [Parameter(Mandatory)][string]$Service
    )

    $wd = Split-Path -Parent $ComposeFile
    $file = Split-Path -Leaf $ComposeFile
    $r = Invoke-CrodipDockerCli -Arguments @(
        "compose","-f",$file,"config","--format","json"
    ) -WorkingDirectory $wd

    if ($r.ExitCode -ne 0) { return $null }

    try {
        $cfg = ($r.Output -join "`n") | ConvertFrom-Json -Depth 100
        $svc = $cfg.services.$Service
        if ($null -ne $svc -and $svc.image) { return [string]$svc.image }
    } catch {}
    return $null
}

Export-ModuleMember -Function @(
    "Get-CrodipDockerDesktopExecutable",
    "Test-CrodipDockerDesktopInstalled",
    "Test-CrodipDockerEngine",
    "Start-CrodipDockerDesktop",
    "Get-CrodipDockerVersionInfo",
    "Get-CrodipFixedContainerStatus",
    "Get-CrodipDockerInventory",
    "Export-CrodipDockerReports",
    "Get-CrodipEnvValue",
    "Set-CrodipEnvValue",
    "Test-CrodipRegistryAccess",
    "Test-CrodipDockerImage",
    "Get-CrodipImagesManifestPath",
    "Import-CrodipOfflineImages",
    "Connect-CrodipRegistry",
    "Disconnect-CrodipRegistry",
    "Get-CrodipRegistryStatus",
    "Get-CrodipDeploymentMode",
    "Start-CrodipRuntimeAuto",
    "Test-CrodipDockerImageLocal",
    "Get-CrodipDockerPullFailureKind",
    "Get-CrodipComposeServiceImages",
    "Get-CrodipComposeServices",
    "Get-CrodipComposeServiceImage",
    "Get-CrodipContainerConflictInfo",
    "Get-CrodipExpectedContainerNames",
    "Resolve-CrodipContainerConflicts",
    "Test-CrodipRegistryCredentialConfigured",
    "Test-CrodipRegistryReadAccess"
)
