Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Get-CrodipRuntimeRoot {
    [CmdletBinding()]
    param()
    return (Split-Path -Parent $PSScriptRoot)
}

function Get-CrodipRuntimeVersion {
    [CmdletBinding()]
    param()
    $path = Join-Path (Get-CrodipRuntimeRoot) "VERSION"
    if (-not (Test-Path -LiteralPath $path)) { return "inconnue" }
    return (Get-Content -LiteralPath $path -Raw).Trim()
}

function Get-CrodipRuntimeStatus {
    [CmdletBinding()]
    param()
    $path = Join-Path (Get-CrodipRuntimeRoot) "STATUS"
    if (-not (Test-Path -LiteralPath $path)) { return "inconnu" }
    return (Get-Content -LiteralPath $path -Raw).Trim()
}

function Get-CrodipRuntimeConfig {
    [CmdletBinding()]
    param()
    $path = Join-Path (Get-CrodipRuntimeRoot) "config\runtime.json"
    if (-not (Test-Path -LiteralPath $path)) {
        throw "Configuration Runtime introuvable : $path"
    }
    try { return Get-Content -LiteralPath $path -Raw | ConvertFrom-Json }
    catch { throw "Configuration Runtime JSON invalide : $($_.Exception.Message)" }
}




function Get-CrodipTestOverrideStatePath {
    [CmdletBinding()]
    param()
    $dataRoot = if ($env:CRODIP_DATA_ROOT) { $env:CRODIP_DATA_ROOT } else { 'C:\ProgramData\CRODIP' }
    return (Join-Path $dataRoot 'state\test-override.json')
}

function Get-CrodipPersistentTestOverride {
    [CmdletBinding()]
    param()
    $path = Get-CrodipTestOverrideStatePath
    if (-not (Test-Path -LiteralPath $path)) { return $null }
    try {
        $state = Get-Content -LiteralPath $path -Raw | ConvertFrom-Json
        $active = $state.PSObject.Properties['active']
        if ($null -ne $active -and [bool]$active.Value) { return $state }
    } catch { }
    return $null
}

function Get-CrodipEffectiveRelease {
    [CmdletBinding()]
    param()
    $config = Get-CrodipRuntimeConfig
    $persistentOverride = Get-CrodipPersistentTestOverride
    if ($null -ne $persistentOverride) { return $persistentOverride }
    $overrideProp = $config.PSObject.Properties['testOverride']
    if($null -ne $overrideProp -and $null -ne $overrideProp.Value){
        $activeProp = $overrideProp.Value.PSObject.Properties['active']
        if($null -ne $activeProp -and [bool]$activeProp.Value){ return $overrideProp.Value }
    }
    return [pscustomobject]@{
        active = $false
        applicationVersion = [string]$config.application.version
        runNumber = [int]$config.release.runNumber
        runId = [string]$config.release.runId
        commit = [string]$config.release.commit
        images = $config.docker.officialImages
        source = 'OFFICIAL'
    }
}

function Get-CrodipEffectiveImageNode {
    [CmdletBinding()]
    param([Parameter(Mandatory)][ValidateSet('local','central')][string]$Target,
          [Parameter(Mandatory)][ValidateSet('backend','frontend')][string]$Service)
    $effective = Get-CrodipEffectiveRelease
    $targetNode = $effective.images.PSObject.Properties[$Target]
    if($null -eq $targetNode){ throw "Images effectives absentes pour '$Target'." }
    $serviceNode = $targetNode.Value.PSObject.Properties[$Service]
    if($null -eq $serviceNode){ throw "Image effective absente pour '$Target/$Service'." }
    return $serviceNode.Value
}

function Get-CrodipRuntimeImageTag {
    [CmdletBinding()]
    param()

    # Conservé pour compatibilité avec les anciens scripts et les paquets offline.
    # En mode "digest", ce tag n'est PAS la référence officielle de déploiement.
    $config = Get-CrodipRuntimeConfig
    $tag = [string]$config.docker.imageTag

    if ([string]::IsNullOrWhiteSpace($tag)) {
        throw "docker.imageTag absent de config\runtime.json."
    }

    return $tag.Trim()
}

function Get-CrodipRuntimeImage {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [ValidateSet("backend","frontend")]
        [string]$Service,

        [ValidateSet("local","central")]
        [string]$Target = "local"
    )

    $config = Get-CrodipRuntimeConfig
    $mode = [string]$config.docker.imageReferenceMode

    if ($mode -eq "digest") {
        $serviceNode = Get-CrodipEffectiveImageNode -Target $Target -Service $Service
        $reference = [string]$serviceNode.reference
        if ([string]::IsNullOrWhiteSpace($reference) -or $reference -notmatch '@sha256:[0-9a-f]{64}$') {
            throw "Référence officielle invalide pour '$Target/$Service' : $reference"
        }

        return $reference.Trim()
    }

    # Compatibilité : résolution historique par tag.
    $tag = Get-CrodipRuntimeImageTag
    $repositories = $config.docker.imageRepositories
    $targetNode = $repositories.PSObject.Properties[$Target]

    if ($null -eq $targetNode) {
        throw "Référentiel d'images absent pour la cible '$Target'."
    }

    $serviceNode = $targetNode.Value.PSObject.Properties[$Service]
    if ($null -eq $serviceNode) {
        throw "Repository d'image absent pour '$Target/$Service'."
    }

    $repository = ([string]$serviceNode.Value).TrimEnd(':')
    if ([string]::IsNullOrWhiteSpace($repository)) {
        throw "Repository d'image vide pour '$Target/$Service'."
    }

    return "${repository}:$tag"
}

function Set-CrodipRuntimeImageEnvironment {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory)]
        [string]$EnvFile,

        [ValidateSet("local","central")]
        [string]$Target = "local"
    )

    $config = Get-CrodipRuntimeConfig
    $tag = Get-CrodipRuntimeImageTag
    $backendImage = Get-CrodipRuntimeImage -Service "backend" -Target $Target
    $frontendImage = Get-CrodipRuntimeImage -Service "frontend" -Target $Target
    $referenceMode = [string]$config.docker.imageReferenceMode
    $applicationVersion = [string](Get-CrodipEffectiveRelease).applicationVersion

    # RC17: les ports publies sont synchronises avec le profil de cycle de vie actif.
    # Pour TEST/LOCAL, la convention CRODIP est backend 8110 / frontend 9110.
    $lifecycle = [string]$config.docker.activeLifecycle
    $lifecycleNode = $config.docker.lifecyclePorts.PSObject.Properties[$lifecycle]
    if ($null -eq $lifecycleNode) { throw "Profil de ports absent pour le cycle de vie '$lifecycle'." }
    $targetNode = $lifecycleNode.Value.PSObject.Properties[$Target]
    if ($null -eq $targetNode) { throw "Profil de ports absent pour '$lifecycle/$Target'." }
    $backendPort = [int]$targetNode.Value.backend
    $frontendPort = [int]$targetNode.Value.frontend

    $lines = if (Test-Path -LiteralPath $EnvFile -PathType Leaf) {
        @(Get-Content -LiteralPath $EnvFile)
    }
    else {
        @()
    }

    $values = [ordered]@{
        "CRODIP_APPLICATION_VERSION"   = $applicationVersion
        "CRODIP_IMAGE_REFERENCE_MODE" = $referenceMode
        "CRODIP_IMAGE_TAG"             = $tag
        "CRODIP_BACKEND_IMAGE"         = $backendImage
        "CRODIP_FRONTEND_IMAGE"        = $frontendImage
        "CRODIP_BACKEND_PORT"          = $backendPort
        "CRODIP_FRONTEND_PORT"         = $frontendPort
    }

    foreach ($name in $values.Keys) {
        $replacement = "$name=$($values[$name])"
        $found = $false

        for ($i = 0; $i -lt $lines.Count; $i++) {
            if ($lines[$i] -match ("^\s*" + [regex]::Escape($name) + "=")) {
                $lines[$i] = $replacement
                $found = $true
            }
        }

        if (-not $found) {
            $lines += $replacement
        }
    }

    if ($PSCmdlet.ShouldProcess($EnvFile, "Synchroniser les images Docker depuis le pin officiel du Runtime")) {
        Set-Content -LiteralPath $EnvFile -Value $lines -Encoding utf8
    }

    [pscustomobject]@{
        Tag = $tag
        ReferenceMode = $referenceMode
        ApplicationVersion = $applicationVersion
        BackendImage = $backendImage
        FrontendImage = $frontendImage
        EnvFile = $EnvFile
        Target = $Target
    }
}

function New-CrodipDirectory {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param([Parameter(Mandatory)][ValidateNotNullOrEmpty()][string]$Path)
    if (-not (Test-Path -LiteralPath $Path)) {
        if ($PSCmdlet.ShouldProcess($Path, "Créer le répertoire")) {
            New-Item -ItemType Directory -Path $Path -Force | Out-Null
        }
    }
    return $Path
}

function Write-CrodipStep {
    [CmdletBinding()] param([Parameter(Mandatory)][string]$Message)
    Write-Host ""; Write-Host "==> $Message" -ForegroundColor Cyan
}
function Write-CrodipSuccess {
    [CmdletBinding()] param([Parameter(Mandatory)][string]$Message)
    Write-Host "[OK] $Message" -ForegroundColor Green
}
function Write-CrodipWarning {
    [CmdletBinding()] param([Parameter(Mandatory)][string]$Message)
    Write-Host "[ATTENTION] $Message" -ForegroundColor Yellow
}
function Write-CrodipError {
    [CmdletBinding()] param([Parameter(Mandatory)][string]$Message)
    Write-Host "[ERREUR] $Message" -ForegroundColor Red
}
function Write-CrodipRuntimeHeader {
    [CmdletBinding()] param([Parameter(Mandatory)][string]$ScriptName)
    Write-Host "CRODIP SaaS Runtime Manager"
    Write-Host "Script  : $ScriptName"
    Write-Host "Version : $(Get-CrodipRuntimeVersion)"
    Write-Host "Statut  : $(Get-CrodipRuntimeStatus)"
    Write-Host ""
}
function Wait-CrodipUser {
    [CmdletBinding()] param([string]$Message = "Appuyez sur Entrée pour continuer")
    [void](Read-Host $Message)
}

Export-ModuleMember -Function @(
    'Get-CrodipRuntimeRoot','Get-CrodipRuntimeVersion','Get-CrodipRuntimeStatus',
    'Get-CrodipRuntimeConfig','Get-CrodipEffectiveRelease','Get-CrodipEffectiveImageNode','Get-CrodipRuntimeImageTag','Get-CrodipRuntimeImage',
    'Set-CrodipRuntimeImageEnvironment','New-CrodipDirectory','Write-CrodipStep',
    'Write-CrodipSuccess','Write-CrodipWarning','Write-CrodipError',
    'Write-CrodipRuntimeHeader','Wait-CrodipUser'
)

Export-ModuleMember -Function Get-CrodipTestOverrideStatePath, Get-CrodipPersistentTestOverride
