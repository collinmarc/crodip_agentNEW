###############################################################
# CRODIP Runtime Manager - RC31
# Docker truth + historical manifest reconciliation
###############################################################
#Requires -Version 7.4
[CmdletBinding()]
param()
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$runtimeRoot = Split-Path -Parent $PSScriptRoot
Import-Module (Join-Path $runtimeRoot 'modules\Crodip.Runtime.Common.psm1') -Force -DisableNameChecking

function Get-PropValue {
    param($Object,[string]$Name,$Default='?')
    if ($null -eq $Object) { return $Default }
    $property = $Object.PSObject.Properties[$Name]
    if ($null -eq $property -or $null -eq $property.Value) { return $Default }
    return $property.Value
}
function Short-Value { param([string]$Value) if ([string]::IsNullOrWhiteSpace($Value)) { return '?' }; if ($Value.Length -gt 12) { return $Value.Substring(0,12) }; return $Value }
function Normalize-Commit { param([string]$Value) if ([string]::IsNullOrWhiteSpace($Value) -or $Value -eq '<no value>') { return '' }; return $Value.Trim().ToLowerInvariant() }
function Commits-Match { param([string]$A,[string]$B) $a1=Normalize-Commit $A; $b1=Normalize-Commit $B; if (-not $a1 -or -not $b1) { return $false }; return ($a1.StartsWith($b1) -or $b1.StartsWith($a1)) }

$cfg = Get-CrodipRuntimeConfig
$persistentOverride = Get-CrodipPersistentTestOverride
$officialCommit = [string](Get-PropValue $cfg.release 'commit' (Get-PropValue $cfg.release 'gitCommit'))
$historyRoot = [string](Get-PropValue $cfg.releaseUpdate 'historyRoot' 'C:\ProgramData\CRODIP\release-history')

function Find-HistoricalReleaseByCommit {
    param([string]$Commit)
    if ([string]::IsNullOrWhiteSpace($Commit) -or -not (Test-Path -LiteralPath $historyRoot)) { return $null }
    $manifestFiles = @(Get-ChildItem -LiteralPath $historyRoot -Recurse -File -Filter 'manifest.json' -ErrorAction SilentlyContinue)
    foreach ($file in $manifestFiles) {
        try {
            $manifest = Get-Content -LiteralPath $file.FullName -Raw | ConvertFrom-Json
            $manifestCommit = [string](Get-PropValue $manifest 'gitCommit' '')
            if (-not (Commits-Match $Commit $manifestCommit)) { continue }
            $runNumber = $null; $runId = $null
            if ($file.FullName -match 'test-override-run-(\d+)-(\d+)') { $runNumber=[int]$Matches[1]; $runId=[string]$Matches[2] }
            $rn = Get-PropValue $manifest 'runNumber' $null; if ($null -ne $rn -and "$rn" -match '^\d+$') { $runNumber=[int]$rn }
            $ri = Get-PropValue $manifest 'runId' $null; if ($null -ne $ri -and -not [string]::IsNullOrWhiteSpace([string]$ri)) { $runId=[string]$ri }
            if ($null -eq $runNumber) { continue }
            return [pscustomobject]@{ RunNumber=$runNumber; RunId=$runId; Version=[string](Get-PropValue $manifest 'applicationVersion' '?'); Commit=$manifestCommit; ManifestPath=$file.FullName; Manifest=$manifest }
        } catch { }
    }
    return $null
}

function Resolve-ReleaseByCommit {
    param([string]$Commit)
    if (Commits-Match $Commit $officialCommit) { return [pscustomobject]@{RunNumber=[int]$cfg.release.runNumber;RunId=[string]$cfg.release.runId;Version=[string]$cfg.application.version;Commit=$officialCommit;Source='OFFICIAL';ManifestPath=$null;Manifest=$null} }
    if ($null -ne $persistentOverride -and (Commits-Match $Commit ([string](Get-PropValue $persistentOverride 'commit' '')))) { return [pscustomobject]@{RunNumber=[int](Get-PropValue $persistentOverride 'runNumber' 0);RunId=[string](Get-PropValue $persistentOverride 'runId' '');Version=[string](Get-PropValue $persistentOverride 'applicationVersion' '?');Commit=[string](Get-PropValue $persistentOverride 'commit' '');Source='PERSISTENT_OVERRIDE';ManifestPath=[string](Get-PropValue $persistentOverride 'manifestPath' '');Manifest=$null} }
    $historical = Find-HistoricalReleaseByCommit $Commit
    if ($null -ne $historical) { $historical | Add-Member -NotePropertyName Source -NotePropertyValue 'RELEASE_HISTORY'; return $historical }
    return $null
}

function Inspect-Service {
    param([string]$Target,[string]$Service)
    $containerName = "crodip-runtime-$Target-$Service-1"
    & docker inspect $containerName *> $null
    if ($LASTEXITCODE -ne 0) { return [pscustomobject]@{Target=$Target;Service=$Service;Container=$containerName;State='ABSENT';Version='?';Commit='?';Image='?';Run='INCONNU';Release=$null} }
    $version = (& docker inspect $containerName --format '{{ index .Config.Labels "org.opencontainers.image.version" }}' 2>$null).Trim()
    $commit = (& docker inspect $containerName --format '{{ index .Config.Labels "org.opencontainers.image.revision" }}' 2>$null).Trim()
    $image = (& docker inspect $containerName --format '{{ .Image }}' 2>$null).Trim()
    $state = (& docker inspect $containerName --format '{{ .State.Status }}' 2>$null).Trim()
    $release = Resolve-ReleaseByCommit $commit
    $run = if ($null -ne $release) { "#$($release.RunNumber)" } else { 'INCONNU' }
    return [pscustomobject]@{Target=$Target;Service=$Service;Container=$containerName;State=$state;Version=$version;Commit=$commit;Image=$image;Run=$run;Release=$release}
}

Write-Host ''
Write-Host '=== INFORMATIONS RELEASE / RUNTIME ===' -ForegroundColor Cyan
Write-Host ''
Write-Host 'RELEASE OFFICIELLE' -ForegroundColor Cyan
Write-Host ("Run         : #{0} / {1}" -f $cfg.release.runNumber,$cfg.release.runId)
Write-Host ("Version     : {0}" -f $cfg.application.version)
Write-Host ("Commit      : {0}" -f $officialCommit)
Write-Host ''
if ($null -ne $persistentOverride) {
    Write-Host 'OVERRIDE TEST PERSISTANT : ACTIF' -ForegroundColor Yellow
    Write-Host ("Run         : #{0} / {1}" -f (Get-PropValue $persistentOverride 'runNumber'),(Get-PropValue $persistentOverride 'runId'))
    Write-Host ("Version     : {0}" -f (Get-PropValue $persistentOverride 'applicationVersion'))
    Write-Host ("Commit      : {0}" -f (Get-PropValue $persistentOverride 'commit'))
} else {
    Write-Host 'OVERRIDE TEST PERSISTANT : INACTIF' -ForegroundColor Yellow
}

Write-Host ''
Write-Host 'RUNTIME REEL - DOCKER' -ForegroundColor Cyan
$rows = @()
foreach ($target in @('local','central')) { foreach ($service in @('backend','frontend')) { $rows += Inspect-Service $target $service } }
foreach ($row in $rows) { Write-Host ("{0,-7} {1,-8}: run={2,-8} version={3,-14} commit={4,-12} etat={5}" -f $row.Target.ToUpperInvariant(),$row.Service,$row.Run,$row.Version,(Short-Value $row.Commit),$row.State) }

$present = @($rows | Where-Object { $_.State -ne 'ABSENT' })
$knownRuns = @($present | Where-Object { $_.Run -ne 'INCONNU' } | ForEach-Object { $_.Run } | Sort-Object -Unique)
$unknownCount = @($present | Where-Object { $_.Run -eq 'INCONNU' }).Count
$runningCount = @($present | Where-Object { $_.State -eq 'running' }).Count
Write-Host ''
if ($present.Count -eq 0) {
    Write-Host 'RUN ACTIF TEST : AUCUN CONTENEUR DETECTE' -ForegroundColor Yellow
} elseif ($knownRuns.Count -eq 1 -and $unknownCount -eq 0) {
    $activeRun = $knownRuns[0]
    $activeRelease = ($present | Select-Object -First 1).Release
    Write-Host ("RUN ACTIF TEST : {0} (vérité Docker)" -f $activeRun) -ForegroundColor Green
    Write-Host ("Version         : {0}" -f $activeRelease.Version)
    Write-Host ("Commit          : {0}" -f $activeRelease.Commit)
    Write-Host 'Etat release    : COHERENT' -ForegroundColor Green
    if ($runningCount -eq $present.Count) { Write-Host 'Etat services   : OPERATIONNEL' -ForegroundColor Green } else { Write-Host ("Etat services   : DEGRADE ({0}/{1} running)" -f $runningCount,$present.Count) -ForegroundColor Yellow }

    if ($null -eq $persistentOverride -and $activeRelease.Source -eq 'RELEASE_HISTORY' -and $activeRelease.RunNumber -ne [int]$cfg.release.runNumber) {
        Write-Host ''
        Write-Host ("[INFO] Docker correspond au run historique #{0}, mais aucun override persistant n'était enregistré." -f $activeRelease.RunNumber) -ForegroundColor Yellow
        try {
            $statePath = Get-CrodipTestOverrideStatePath
            $stateDir = Split-Path -Parent $statePath
            New-Item -ItemType Directory -Force -Path $stateDir | Out-Null
            $state = [ordered]@{active=$true;source='RECOVERED_FROM_DOCKER_AND_RELEASE_HISTORY';recoveredAt=(Get-Date).ToString('o');applicationVersion=$activeRelease.Version;runNumber=[int]$activeRelease.RunNumber;runId=[string]$activeRelease.RunId;commit=[string]$activeRelease.Commit;manifestPath=[string]$activeRelease.ManifestPath;officialRunNumber=[int]$cfg.release.runNumber;officialApplicationVersion=[string]$cfg.application.version}
            $state | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $statePath -Encoding utf8
            Write-Host ("[OK] Override TEST persistant reconstruit : {0}" -f $statePath) -ForegroundColor Green
        } catch { Write-Host ("[ATTENTION] Impossible de reconstruire l'override persistant : {0}" -f $_.Exception.Message) -ForegroundColor Yellow }
    }
} else {
    Write-Host 'RUN ACTIF TEST : INCOHERENT / INDETERMINE' -ForegroundColor Red
    Write-Host '[ATTENTION] Les conteneurs ne correspondent pas tous à une même release connue.' -ForegroundColor Yellow
}
