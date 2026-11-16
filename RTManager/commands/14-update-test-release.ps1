###############################################################
# CRODIP Runtime Manager
# Script   : commands\14-update-test-release.ps1
# Version  : 2.3.0-RC17
# Statut   : Release Candidate - Remote Official Pin
###############################################################

#Requires -Version 7.4

[CmdletBinding()]
param(
    [ValidateSet("auto","github","file","cache")]
    [string]$Source = "auto",

    [string]$ReleasePinPath,

    [switch]$NonInteractive
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$runtimeRoot = Split-Path -Parent $PSScriptRoot
$moduleRoot = Join-Path $runtimeRoot "modules"

foreach($moduleName in @(
    "Crodip.Runtime.Common.psm1",
    "Crodip.Runtime.Windows.psm1",
    "Crodip.Runtime.Logging.psm1",
    "Crodip.Runtime.DockerProvider.psm1",
    "Crodip.Runtime.Docker.psm1",
    "Crodip.Runtime.Compose.psm1",
    "Crodip.Runtime.GitHub.psm1"
)){
    Import-Module (Join-Path $moduleRoot $moduleName) `
        -Force -DisableNameChecking -ErrorAction Stop
}

function Save-JsonUtf8 {
    param(
        [Parameter(Mandatory)]$Object,
        [Parameter(Mandatory)][string]$Path
    )
    $parent = Split-Path -Parent $Path
    if($parent){ New-Item -ItemType Directory -Force -Path $parent | Out-Null }
    $Object | ConvertTo-Json -Depth 20 |
        Set-Content -LiteralPath $Path -Encoding utf8
}

function Resolve-OfficialPinSource {
    param([string]$Mode,[string]$Path)
    $incoming=[string]$script:Config.releaseUpdate.incomingPinPath
    $cached=[string]$script:Config.releaseUpdate.cachedPinPath
    $repo=[string]$script:Config.releaseUpdate.githubRepository
    $branch=[string]$script:Config.releaseUpdate.githubBranch
    $pinPath=[string]$script:Config.releaseUpdate.githubPinPath

    if($Mode -in @("auto","github")){
        if(-not(Test-CrodipGitHubCli)){
            Write-CrodipWarning "GitHub CLI absent."
            if(-not $NonInteractive){
                $answer=Read-Host "Installer GitHub CLI avec winget ? (O/N)"
                if($answer -match '^(O|o|Y|y)$'){ $null=Install-CrodipGitHubCli }
            }
        }
        if(Test-CrodipGitHubCli){
            if(-not(Test-CrodipGitHubAuthentication) -and -not $NonInteractive){ $null=Connect-CrodipGitHub }
            if(Test-CrodipGitHubAuthentication){
                try { return Get-CrodipGitHubFile -Repository $repo -Path $pinPath -Ref $branch -Destination $incoming }
                catch { Write-CrodipWarning $_.Exception.Message; if($Mode -eq "github"){ throw } }
            }
        }
    }
    if($Mode -eq "file"){
        if([string]::IsNullOrWhiteSpace($Path)){ $Path=$incoming }
        if(-not(Test-Path $Path)){ throw "Pin introuvable : $Path" }
        return $Path
    }
    if($Mode -eq "cache"){
        if(-not(Test-Path $cached)){ throw "Aucun pin en cache : $cached" }
        return $cached
    }
    if(Test-Path $incoming){ return $incoming }
    if(Test-Path $cached){ Write-CrodipWarning "Utilisation du pin en cache."; return $cached }
    throw "Aucun pin officiel disponible. Installer/authentifier GitHub CLI ou déposer le pin dans $incoming"
}

function Assert-OfficialPinSchema {
    param([Parameter(Mandatory)]$Pin)

    foreach($field in @(
        "schemaVersion","applicationVersion","officialRunId",
        "officialRunNumber","gitCommit","status","buildPolicy",
        "repository","images","pinPolicy"
    )){
        if($Pin.PSObject.Properties.Name -notcontains $field){
            throw "Pin officiel invalide : champ '$field' absent."
        }
    }

    if([int]$Pin.schemaVersion -ne 1){
        throw "Version de schéma non supportée : $($Pin.schemaVersion)"
    }
    if([string]$Pin.repository -ne "IDWEBCONCEPT/crodip-saas"){
        throw "Repository du pin inattendu : $($Pin.repository)"
    }
    if([string]$Pin.status -ne "RELEASE READY FOR TEST"){
        throw "Statut non admissible pour TEST : $($Pin.status)"
    }
    if([string]$Pin.buildPolicy -ne "build-once-promote-same-digest"){
        throw "Build policy inattendue : $($Pin.buildPolicy)"
    }
    if([string]$Pin.pinPolicy -ne "explicit-official-run-only"){
        throw "Pin policy inattendue : $($Pin.pinPolicy)"
    }
    if([string]$Pin.applicationVersion -notmatch '^\d+\.\d+\.\d+-(dev|rc)\.\d+$'){
        throw "Version applicative invalide : $($Pin.applicationVersion)"
    }
    if([string]$Pin.gitCommit -notmatch '^[0-9a-fA-F]{40}$'){
        throw "Commit officiel invalide : $($Pin.gitCommit)"
    }

    $expected = @{
        "local-backend"    = "ghcr.io/idwebconcept/crodip-local-backend"
        "local-frontend"   = "ghcr.io/idwebconcept/crodip-local-frontend"
        "central-backend"  = "ghcr.io/idwebconcept/crodip-central-backend"
        "central-frontend" = "ghcr.io/idwebconcept/crodip-central-frontend"
    }

    if(@($Pin.images).Count -ne 4){
        throw "Le pin officiel doit contenir exactement 4 images. Trouvées : $(@($Pin.images).Count)"
    }

    foreach($key in $expected.Keys){
        $matches=@($Pin.images | Where-Object { [string]$_.key -eq $key })
        if($matches.Count -ne 1){
            throw "Image '$key' : exactement une entrée attendue, trouvées : $($matches.Count)"
        }
        $img=$matches[0]
        if([string]$img.repository -ne $expected[$key]){
            throw "Repository invalide pour '$key' : $($img.repository)"
        }
        if([string]$img.digest -notmatch '^sha256:[0-9a-fA-F]{64}$'){
            throw "Digest invalide pour '$key' : $($img.digest)"
        }
    }
}

function Get-OfficialImageReference {
    param([Parameter(Mandatory)]$Pin,[Parameter(Mandatory)][string]$Key)
    $img=@($Pin.images | Where-Object { [string]$_.key -eq $Key })
    if($img.Count -ne 1){ throw "Image officielle '$Key' non unique." }
    return "$([string]$img[0].repository)@$([string]$img[0].digest)"
}

function Get-DigestFromReference {
    param([Parameter(Mandatory)][string]$Reference)
    if($Reference -notmatch '@(sha256:[0-9a-fA-F]{64})$'){
        throw "Digest invalide : $Reference"
    }
    return ([string]$Matches[1]).ToLowerInvariant()
}

function Invoke-DockerPullExact {
    param([Parameter(Mandatory)][string]$Reference)
    Write-CrodipStep "Pull : $Reference"
    $output = @(& docker pull $Reference 2>&1)
    if($LASTEXITCODE -ne 0){
        $output | ForEach-Object { Write-Host $_ }
        throw "Échec du pull : $Reference"
    }
    Write-CrodipSuccess "Image disponible."
}

$script:Config = Get-CrodipRuntimeConfig
$configPath = Join-Path $runtimeRoot "config\runtime.json"

Clear-Host
Write-Host "============================================================" -ForegroundColor Cyan
Write-Host " MISE À JOUR DE LA RELEASE TEST" -ForegroundColor Cyan
Write-Host "============================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Runtime actuel      : $($Config.version)"
Write-Host "Application actuelle: $($Config.application.version)"
Write-Host "Run CI actuel       : #$($Config.release.runNumber) / $($Config.release.runId)"
Write-Host "Commit actuel       : $($Config.release.commit)"
Write-Host ""
Write-Host "Source              : $Source"
Write-Host "Dépôt GitHub        : $($Config.releaseUpdate.githubRepository)"
Write-Host "Branche             : $($Config.releaseUpdate.githubBranch)"
Write-Host "Pin GitHub          : $($Config.releaseUpdate.githubPinPath)"
Write-Host "Incoming Runtime    : $($Config.releaseUpdate.incomingPinPath)"
Write-Host "Cache Runtime       : $($Config.releaseUpdate.cachedPinPath)"
Write-Host ""

$resolvedPinPath = Resolve-OfficialPinSource `
    -Mode $Source `
    -Path $ReleasePinPath

Write-CrodipStep "Pin retenu : $resolvedPinPath"

try {
    $pin = Get-Content -LiteralPath $resolvedPinPath -Raw | ConvertFrom-Json
}
catch {
    throw "Pin officiel JSON invalide : $($_.Exception.Message)"
}

Assert-OfficialPinSchema -Pin $pin

$appVersion = [string]$pin.applicationVersion
$commit = [string]$pin.gitCommit
$runNumber = [int]$pin.officialRunNumber
$runId = [string]$pin.officialRunId
$officialStatus = [string]$pin.status

$images = @{
    localBackend    = (Get-OfficialImageReference -Pin $pin -Key "local-backend").ToLowerInvariant()
    localFrontend   = (Get-OfficialImageReference -Pin $pin -Key "local-frontend").ToLowerInvariant()
    centralBackend  = (Get-OfficialImageReference -Pin $pin -Key "central-backend").ToLowerInvariant()
    centralFrontend = (Get-OfficialImageReference -Pin $pin -Key "central-frontend").ToLowerInvariant()
}

Write-Host ""
Write-Host "RELEASE OFFICIELLE DÉTECTÉE" -ForegroundColor Cyan
Write-Host "------------------------------------------------------------"
Write-Host "Application : $appVersion"
Write-Host "Run CI      : #$runNumber / $runId"
Write-Host "Commit      : $commit"
Write-Host "Statut      : $officialStatus"
Write-Host ""
Write-Host "LOCAL backend    : $($images.localBackend)"
Write-Host "LOCAL frontend   : $($images.localFrontend)"
Write-Host "CENTRAL backend  : $($images.centralBackend)"
Write-Host "CENTRAL frontend : $($images.centralFrontend)"
Write-Host ""

$sameRelease = (
    [string]$Config.application.version -eq $appVersion -and
    [string]$Config.release.commit -eq $commit -and
    [string]$Config.docker.officialImages.local.backend.reference -eq $images.localBackend -and
    [string]$Config.docker.officialImages.local.frontend.reference -eq $images.localFrontend -and
    [string]$Config.docker.officialImages.central.backend.reference -eq $images.centralBackend -and
    [string]$Config.docker.officialImages.central.frontend.reference -eq $images.centralFrontend
)

if($sameRelease){
    Write-CrodipSuccess "Le Runtime utilise déjà cette release officielle."
    return
}

if(-not $NonInteractive){
    Write-CrodipWarning "Le Runtime va passer de $($Config.application.version) à $appVersion."
    Write-CrodipWarning "Les conteneurs applicatifs seront recréés."
    Write-CrodipWarning "Le volume PostgreSQL CENTRAL est conservé."
    $confirm = Read-Host "Saisir UPDATE-TEST pour continuer"
    if($confirm -cne "UPDATE-TEST"){
        Write-CrodipWarning "Mise à jour annulée."
        return
    }
}

if(-not(Test-CrodipDockerEngine)){
    if((Get-CrodipDockerProvider) -eq "desktop"){
        Write-CrodipStep "Démarrage de Docker Desktop"
        if(-not(Start-CrodipDockerDesktop -Confirm:$false)){
            throw "Docker Engine indisponible."
        }
    } else {
        if(-not(Start-CrodipUbuntuDockerEngine)){
            throw "Docker Engine indisponible."
        }
    }
}

Write-Host ""
Write-Host "PHASE 1/4 — PULL DES 4 IMAGES OFFICIELLES" -ForegroundColor Cyan

foreach($reference in @(
    $images.localBackend,
    $images.localFrontend,
    $images.centralBackend,
    $images.centralFrontend
)){
    Invoke-DockerPullExact -Reference $reference
}

Write-Host ""
Write-Host "PHASE 2/4 — SAUVEGARDE / PIN RUNTIME" -ForegroundColor Cyan

$historyRoot = [string]$Config.releaseUpdate.historyRoot
$cachedPinPath = [string]$Config.releaseUpdate.cachedPinPath
New-Item -ItemType Directory -Force -Path $historyRoot | Out-Null
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $cachedPinPath) | Out-Null

$stamp = Get-Date -Format "yyyyMMdd-HHmmss"
$configBackup = Join-Path $historyRoot "runtime-before-release-$stamp.json"
$pinBackup = Join-Path $historyRoot "official-release-pin-$stamp.json"

Copy-Item -LiteralPath $configPath -Destination $configBackup -Force
Copy-Item -LiteralPath $resolvedPinPath -Destination $pinBackup -Force
Copy-Item -LiteralPath $resolvedPinPath -Destination $cachedPinPath -Force

$updated = Get-CrodipRuntimeConfig
$updated.application.version = $appVersion
$updated.application.releaseChannel = "TEST"
$updated.release.runNumber = $runNumber
$updated.release.runId = $runId
$updated.release.commit = $commit
$updated.release.officialStatus = $officialStatus
$updated.release.mode = "official-digest-pin"
$updated.release.buildPolicy = "build-once-promote-same-digest"
$updated.docker.imageTag = $appVersion
$updated.docker.imageReferenceMode = "digest"
$updated.docker.activeLifecycle = "TEST"

$updated.docker.officialImages.local.backend.reference = $images.localBackend
$updated.docker.officialImages.local.backend.digest = Get-DigestFromReference $images.localBackend
$updated.docker.officialImages.local.frontend.reference = $images.localFrontend
$updated.docker.officialImages.local.frontend.digest = Get-DigestFromReference $images.localFrontend
$updated.docker.officialImages.central.backend.reference = $images.centralBackend
$updated.docker.officialImages.central.backend.digest = Get-DigestFromReference $images.centralBackend
$updated.docker.officialImages.central.frontend.reference = $images.centralFrontend
$updated.docker.officialImages.central.frontend.digest = Get-DigestFromReference $images.centralFrontend

Save-JsonUtf8 -Object $updated -Path $configPath

Write-CrodipSuccess "runtime.json mis à jour."
Write-CrodipSuccess "Pin actif en cache : $cachedPinPath"
Write-CrodipSuccess "Historique : $pinBackup"

Write-Host ""
Write-Host "PHASE 3/4 — REDÉPLOIEMENT" -ForegroundColor Cyan

$runtimeHome = Get-CrodipHome
$localEnv = Join-Path $runtimeHome ".env"

if(Test-Path -LiteralPath $localEnv -PathType Leaf){
    $null = Set-CrodipRuntimeImageEnvironment `
        -EnvFile $localEnv `
        -Target "local" `
        -Confirm:$false

    Write-CrodipStep "Recréation Runtime LOCAL"
    & (Join-Path $PSScriptRoot "08-update.ps1")
    if($LASTEXITCODE -ne 0){ throw "Mise à jour LOCAL en échec." }
}
else {
    Write-CrodipWarning "Runtime LOCAL non installé : redéploiement ignoré."
}

$centralHome = Join-Path $runtimeHome "templates\central"
$centralEnv = Join-Path $centralHome ".env"
$centralCompose = Join-Path $centralHome "compose.yaml"

if((Test-Path -LiteralPath $centralEnv -PathType Leaf) -and
   (Test-Path -LiteralPath $centralCompose -PathType Leaf)){

    $null = Set-CrodipRuntimeImageEnvironment `
        -EnvFile $centralEnv `
        -Target "central" `
        -Confirm:$false

    Write-CrodipStep "Recréation Runtime CENTRAL"
    Write-CrodipWarning "Le volume PostgreSQL CENTRAL est conservé."
    & (Join-Path $PSScriptRoot "12-central-runtime.ps1") -Action update
    if($LASTEXITCODE -ne 0){ throw "Mise à jour CENTRAL en échec." }
}
else {
    Write-CrodipWarning "Runtime CENTRAL non installé : redéploiement ignoré."
}

Write-Host ""
Write-Host "PHASE 4/4 — QUALIFICATION TECHNIQUE" -ForegroundColor Cyan

$qualifyScript = Join-Path $PSScriptRoot "13-qualify-runtime.ps1"
& pwsh -NoProfile -ExecutionPolicy Bypass -File $qualifyScript
$qualificationExit = $LASTEXITCODE

Write-Host ""
Write-Host "============================================================"
if($qualificationExit -eq 0){
    Write-CrodipSuccess "MISE À JOUR RELEASE TEST TERMINÉE"
    Write-CrodipSuccess "Application : $appVersion"
    Write-CrodipSuccess "Run CI      : #$runNumber / $runId"
    Write-CrodipSuccess "Commit      : $commit"
    Write-CrodipSuccess "RUNTIME TEST TECHNICALLY QUALIFIED"
}
else {
    Write-CrodipWarning "Release déployée, mais qualification technique en échec."
    Write-CrodipWarning "Rapport : C:\ProgramData\CRODIP\qualification\runtime-qualification.json"
    exit 1
}
Write-Host "============================================================"
