###############################################################
# CRODIP Runtime Manager - RC34
# Changer la release Runtime TEST vers un run CI buildé / restaurer officiel
###############################################################
#Requires -Version 7.4
[CmdletBinding()]
param([ValidateSet('select','restore')][string]$Action='select')
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$runtimeRoot=Split-Path -Parent $PSScriptRoot
$moduleRoot=Join-Path $runtimeRoot 'modules'
foreach($m in @('Crodip.Runtime.Common.psm1','Crodip.Runtime.Windows.psm1','Crodip.Runtime.Logging.psm1','Crodip.Runtime.DockerProvider.psm1','Crodip.Runtime.Docker.psm1','Crodip.Runtime.Compose.psm1','Crodip.Runtime.GitHub.psm1','Crodip.Runtime.ReleaseRollback.psm1')){ Import-Module (Join-Path $moduleRoot $m) -Force -DisableNameChecking -ErrorAction Stop }
$configPath=Join-Path $runtimeRoot 'config\runtime.json'
$overrideStatePath = Get-CrodipTestOverrideStatePath
$resolvedCrodipHome = Get-CrodipHome
function Save-Config($o){ $o|ConvertTo-Json -Depth 30|Set-Content -LiteralPath $configPath -Encoding utf8 }
function Save-OverrideState($o){ $dir=Split-Path -Parent $overrideStatePath; New-Item -ItemType Directory -Force -Path $dir|Out-Null; $o|ConvertTo-Json -Depth 30|Set-Content -LiteralPath $overrideStatePath -Encoding utf8 }
function Clear-OverrideState(){ if(Test-Path -LiteralPath $overrideStatePath){Remove-Item -LiteralPath $overrideStatePath -Force} }
function Restore-SnapshotStaged([string]$Archive){ if([string]::IsNullOrWhiteSpace($Archive)){throw 'Archive de rollback absente.'}; & (Join-Path $PSScriptRoot '07-restore.ps1') -ArchivePath $Archive -Force -SkipPostRestoreVerification -DeferBackendStart; if($LASTEXITCODE-ne 0){throw 'Restauration stagee du snapshot de securite en echec.'} }
function Assert-DatabaseCoherence { $v=Join-Path $PSScriptRoot '19-verify-databases.ps1'; & $v; if($LASTEXITCODE-ne 0){throw 'Qualification DB transactionnelle en echec.'} }
function Ref($img){ "$([string]$img.repository)@$([string]$img.digest)".ToLowerInvariant() }
function Images-FromManifest($manifest){
  $expected=@{'local-backend'='local/backend';'local-frontend'='local/frontend';'central-backend'='central/backend';'central-frontend'='central/frontend'}
  $out=[ordered]@{local=[ordered]@{};central=[ordered]@{}}
  foreach($k in $expected.Keys){
    $a=@($manifest.images|Where-Object{[string]$_.key -eq $k}); if($a.Count-ne 1){throw "Manifest : image '$k' absente/non unique."}
    if([string]$a[0].digest -notmatch '^sha256:[0-9a-fA-F]{64}$'){throw "Digest invalide pour $k"}
    $parts=$expected[$k].Split('/'); $out[$parts[0]][$parts[1]]=[ordered]@{repository=[string]$a[0].repository;digest=([string]$a[0].digest).ToLowerInvariant();reference=(Ref $a[0])}
  }; return $out
}
function Sync-And-Redeploy {
  # FIX9: ne plus dépendre de Get-CrodipHome après les réimports -Force des scripts imbriqués.
  $runtimeHome=$script:resolvedCrodipHome
  if([string]::IsNullOrWhiteSpace([string]$runtimeHome)){throw 'CRODIP_HOME résolu absent pour redéploiement transactionnel.'}

  $cfgPorts=Get-CrodipRuntimeConfig
  $lifecycle=[string]$cfgPorts.docker.activeLifecycle
  $lifeNode=$cfgPorts.docker.lifecyclePorts.PSObject.Properties[$lifecycle]
  if($null -eq $lifeNode){throw "Profil de ports absent pour '$lifecycle'."}
  $localNode=$lifeNode.Value.PSObject.Properties['local']
  $centralNode=$lifeNode.Value.PSObject.Properties['central']
  if($null -eq $localNode -or $null -eq $centralNode){throw "Topologies LOCAL/CENTRAL absentes pour '$lifecycle'."}

  $localBackend=[int]$localNode.Value.backend; $localFrontend=[int]$localNode.Value.frontend
  $centralBackend=[int]$centralNode.Value.backend; $centralFrontend=[int]$centralNode.Value.frontend
  if($localBackend -eq $centralBackend -or $localFrontend -eq $centralFrontend){
    throw "Plan de ports non isolé pour '$lifecycle' : LOCAL=$localBackend/$localFrontend CENTRAL=$centralBackend/$centralFrontend."
  }
  Write-CrodipStep ("FIX9 - garde-fou ports {0}: LOCAL BE/FE={1}/{2} ; CENTRAL BE/FE={3}/{4}" -f $lifecycle,$localBackend,$localFrontend,$centralBackend,$centralFrontend)

  $previousBackendPort=[Environment]::GetEnvironmentVariable('CRODIP_BACKEND_PORT','Process')
  $previousFrontendPort=[Environment]::GetEnvironmentVariable('CRODIP_FRONTEND_PORT','Process')
  try {
    # Docker Compose donne priorité aux variables Process sur .env.
    # On impose donc explicitement LOCAL pendant tout le redéploiement LOCAL.
    [Environment]::SetEnvironmentVariable('CRODIP_BACKEND_PORT',[string]$localBackend,'Process')
    [Environment]::SetEnvironmentVariable('CRODIP_FRONTEND_PORT',[string]$localFrontend,'Process')
    $localEnv=Join-Path $runtimeHome '.env'
    if(Test-Path $localEnv){
      Set-CrodipRuntimeImageEnvironment -EnvFile $localEnv -Target local -Confirm:$false|Out-Null
      & (Join-Path $PSScriptRoot '08-update.ps1')
      if($LASTEXITCODE-ne 0){throw 'Redéploiement LOCAL en échec.'}
    }

    # CENTRAL possède déjà son isolation interne RC29 ; on synchronise son .env
    # puis son script impose temporairement les ports CENTRAL.
    $cent=Join-Path $runtimeHome 'templates\central'; $centEnv=Join-Path $cent '.env'; $centCompose=Join-Path $cent 'compose.yaml'
    if(Test-Path $centCompose){
      if(-not(Test-Path $centEnv)){ Copy-Item (Join-Path $cent '.env.example') $centEnv -Force }
      Set-CrodipRuntimeImageEnvironment -EnvFile $centEnv -Target central -Confirm:$false|Out-Null
      & (Join-Path $PSScriptRoot '12-central-runtime.ps1') -Action update
      if($LASTEXITCODE-ne 0){throw 'Redéploiement CENTRAL en échec.'}
    }
  }
  finally {
    [Environment]::SetEnvironmentVariable('CRODIP_BACKEND_PORT',$previousBackendPort,'Process')
    [Environment]::SetEnvironmentVariable('CRODIP_FRONTEND_PORT',$previousFrontendPort,'Process')
  }
}
if($Action -eq 'restore'){
  $cfg=Get-CrodipRuntimeConfig
  $persistent=Get-CrodipPersistentTestOverride
  $prop=$cfg.PSObject.Properties['testOverride']
  $configOverride=$null
  if($null -ne $prop){ $configOverride=$prop.Value }
  $effectiveOverride=if($null -ne $persistent){$persistent}else{$configOverride}
  $isActive=$false
  if($null -ne $effectiveOverride){
    $activeProp=$effectiveOverride.PSObject.Properties['active']
    if($null -ne $activeProp){$isActive=[bool]$activeProp.Value}
  }
  if(-not $isActive){ Write-CrodipSuccess 'Aucun override TEST actif.'; return }

  $overrideRun='INCONNU'; $overrideVersion='INCONNUE'
  $runProp=$effectiveOverride.PSObject.Properties['runNumber']; if($null -ne $runProp){$overrideRun=[string]$runProp.Value}
  $verProp=$effectiveOverride.PSObject.Properties['applicationVersion']; if($null -ne $verProp){$overrideVersion=[string]$verProp.Value}
  Write-CrodipWarning ("Override actif : run #{0}, application {1}" -f $overrideRun,$overrideVersion)
  Write-Host ("Release officielle cible : run #{0}, application {1}" -f $cfg.release.runNumber,$cfg.application.version) -ForegroundColor Cyan
  $c=Read-Host 'Saisir RESTORE-OFFICIAL pour revenir à la release officielle'
  if($c -cne 'RESTORE-OFFICIAL'){Write-CrodipWarning 'Opération annulée.';return}

  # RC32 : l'override n'est supprimé définitivement qu'après un redéploiement réussi.
  # On sauvegarde les deux représentations afin de pouvoir les restaurer en cas d'échec.
  $savedPersistent=$persistent
  $savedConfigOverride=$configOverride
  $restoreEmptySource=$false
  $sourceSafetyArchive=$null
  $modeProp=$effectiveOverride.PSObject.Properties['databaseMode']
  if($null -ne $modeProp -and [string]$modeProp.Value -eq 'RECONSTRUCTED_EMPTY'){
    $restoreEmptySource=$true
    $saProp=$effectiveOverride.PSObject.Properties['sourceSafetyArchive']
    if($null -eq $saProp -or [string]::IsNullOrWhiteSpace([string]$saProp.Value)){throw 'Retour officiel BLOQUE : snapshot source STEP3E absent de l override.'}
    $sourceSafetyArchive=[string]$saProp.Value
    if(-not(Test-Path -LiteralPath $sourceSafetyArchive -PathType Leaf)){throw "Retour officiel BLOQUE : archive source STEP3E introuvable : $sourceSafetyArchive"}
    $taProp=$effectiveOverride.PSObject.Properties['targetDatabaseArchive']
    if($null -eq $taProp -or [string]::IsNullOrWhiteSpace([string]$taProp.Value)){throw 'Retour officiel BLOQUE : archive EMPTY cible absente de l override.'}
    $targetDatabaseArchive=[string]$taProp.Value
    if(-not(Test-Path -LiteralPath $targetDatabaseArchive -PathType Leaf)){throw "Retour officiel BLOQUE : archive EMPTY cible introuvable : $targetDatabaseArchive"}
    Write-CrodipWarning 'Override RECONSTRUCTED_EMPTY : les bases source seront restaurees avant le redeploiement officiel.'
  }
  try {
    if($restoreEmptySource){
      Write-CrodipStep 'STEP3E - retour officiel : restauration STAGEE du snapshot source avant images officielles'
      Restore-SnapshotStaged -Archive $sourceSafetyArchive
    }
    if($null -ne $configOverride){
      $activeProp=$configOverride.PSObject.Properties['active']
      if($null -ne $activeProp){$configOverride.active=$false}else{$configOverride|Add-Member -NotePropertyName active -NotePropertyValue $false}
      $restoredProp=$configOverride.PSObject.Properties['restoredAt']
      $restoredAt=(Get-Date).ToString('o')
      if($null -ne $restoredProp){$configOverride.restoredAt=$restoredAt}else{$configOverride|Add-Member -NotePropertyName restoredAt -NotePropertyValue $restoredAt}
      $cfg.testOverride=$configOverride
      Save-Config $cfg
    }
    Clear-OverrideState

    Write-CrodipStep 'Restauration des 4 images de la release officielle'
    foreach($t in @('local','central')){
      foreach($svc in @('backend','frontend')){
        $r=[string]$cfg.docker.officialImages.$t.$svc.reference
        if([string]::IsNullOrWhiteSpace($r)){throw "Référence officielle absente : $t/$svc"}
        & docker pull $r
        if($LASTEXITCODE-ne 0){throw "Pull impossible : $r"}
      }
    }
    Sync-And-Redeploy
    if($restoreEmptySource){Assert-DatabaseCoherence}
    Clear-OverrideState
    Write-CrodipSuccess ("Release officielle restaurée : #{0} / {1}" -f $cfg.release.runNumber,$cfg.application.version)
    return
  }
  catch {
    $restoreOfficialError=$_.Exception.Message
    Write-CrodipWarning 'Restauration officielle incomplète : rollback vers l override TEST précédent.'
    try {
      if($restoreEmptySource){Restore-SnapshotStaged -Archive $targetDatabaseArchive}
      $cfg=Get-CrodipRuntimeConfig
      if($null -ne $savedConfigOverride){
        if($cfg.PSObject.Properties.Name -contains 'testOverride'){$cfg.testOverride=$savedConfigOverride}else{$cfg|Add-Member -NotePropertyName testOverride -NotePropertyValue $savedConfigOverride}
        Save-Config $cfg
      }
      if($null -ne $savedPersistent){Save-OverrideState $savedPersistent}
      if($restoreEmptySource){Sync-And-Redeploy;Assert-DatabaseCoherence}
    } catch { throw ("ECHEC CRITIQUE rollback vers TEST après échec retour officiel [{0}] : {1}" -f $restoreOfficialError,$_.Exception.Message) }
    throw $restoreOfficialError
  }
}
if(-not(Test-CrodipGitHubCli)){throw 'GitHub CLI absent. Utiliser le menu GitHub CLI.'}
if(-not(Test-CrodipGitHubAuthentication)){ if(-not(Connect-CrodipGitHub)){throw 'Authentification GitHub requise.'} }
$cfg=Get-CrodipRuntimeConfig; $repo=[string]$cfg.releaseUpdate.githubRepository; $gh=Get-CrodipGitHubCliExecutable
Write-CrodipStep 'Releases buildées disponibles - CRODIP Official Build réussis'
$raw=& $gh run list --repo $repo --workflow 'CRODIP Official Build' --status success --limit 30 --json 'databaseId,number,headSha,createdAt,displayTitle,conclusion' 2>$null
if($LASTEXITCODE-ne 0){throw 'Impossible de lister les runs GitHub Actions.'}
$runs=@($raw|ConvertFrom-Json); if($runs.Count-eq 0){throw 'Aucun run réussi trouvé.'}
$runs|Sort-Object number -Descending|ForEach-Object{Write-Host ("#{0,-5} ID={1,-12} {2}  {3}" -f $_.number,$_.databaseId,([string]$_.headSha).Substring(0,7),$_.createdAt)}
Write-Host ''; Write-Host ("Release officielle actuelle : #{0} / {1}" -f $cfg.release.runNumber,$cfg.application.version) -ForegroundColor Cyan
$sel=Read-Host 'Numéro de run buildé à activer pour TEST (antérieur ou postérieur)'
if($sel -notmatch '^\d+$'){throw 'Numéro de run invalide.'}
$matches=@($runs|Where-Object{[int]$_.number -eq [int]$sel}); if($matches.Count-ne 1){throw "Run #$sel absent de la liste des runs réussis."}; $run=$matches[0]
$relation='IDENTIQUE'
if([int]$run.number -lt [int]$cfg.release.runNumber){$relation='ANTERIEUR'}
if([int]$run.number -gt [int]$cfg.release.runNumber){$relation='POSTERIEUR'}
Write-Host ("Relation    : {0} au Build officiel #{1}" -f $relation,$cfg.release.runNumber) -ForegroundColor Cyan
if($relation -eq 'IDENTIQUE'){
    Write-CrodipWarning "Le run choisi correspond à la release officielle. L'option de restauration officielle est préférable."
}

$dest=Join-Path ([string]$cfg.releaseUpdate.historyRoot) ("test-override-run-{0}-{1}" -f $run.number,$run.databaseId); if(Test-Path $dest){Remove-Item $dest -Recurse -Force}; New-Item -ItemType Directory -Force -Path $dest|Out-Null
Write-CrodipStep ("Inventaire des artefacts du run #{0}" -f $run.number)
$artifactRaw = & $gh api ("repos/{0}/actions/runs/{1}/artifacts?per_page=100" -f $repo,$run.databaseId) 2>$null
if($LASTEXITCODE -ne 0){ throw 'Impossible de lister les artefacts du run GitHub Actions.' }
$artifactPages = @($artifactRaw | ConvertFrom-Json)
$artifacts = @()
foreach($page in $artifactPages){
    if($null -ne $page -and $page.PSObject.Properties.Name -contains 'artifacts'){
        $artifacts += @($page.artifacts)
    }
}
if($artifacts.Count -eq 0){ throw ("Aucun artefact disponible pour le run #{0}." -f $run.number) }

# Les artefacts *.dockerbuild produits par BuildKit ne contiennent pas le manifest
# de release et peuvent faire échouer `gh run download` lors de l'extraction.
$safeArtifacts = @($artifacts | Where-Object {
    (-not ($_.PSObject.Properties.Name -contains 'expired') -or -not [bool]$_.expired) -and
    [string]$_.name -notmatch '(?i)\.dockerbuild$' -and
    [string]$_.name -notmatch '(?i)dockerbuild'
})
if($safeArtifacts.Count -eq 0){ throw 'Aucun artefact de release exploitable : seuls des artefacts Docker BuildKit sont disponibles.' }

Write-Host 'Artefacts exploitables :' -ForegroundColor DarkCyan
$safeArtifacts | ForEach-Object { Write-Host ("  - {0}" -f $_.name) }

# Priorité aux artefacts dont le nom évoque explicitement le manifest/release.
$orderedArtifacts = @(
    $safeArtifacts | Sort-Object @{Expression={
        $n=[string]$_.name
        if($n -match '(?i)manifest'){0}
        elseif($n -match '(?i)official|release'){1}
        elseif($n -match '(?i)metadata|trace'){2}
        else{3}
    }}, @{Expression={[string]$_.name}}
)

$manifest=$null
$manifestPath=$null
$downloadErrors=@()
foreach($artifact in $orderedArtifacts){
    $artifactName=[string]$artifact.name
    $artifactDest=Join-Path $dest ([IO.Path]::GetFileName($artifactName))
    New-Item -ItemType Directory -Force -Path $artifactDest | Out-Null
    Write-CrodipStep ("Téléchargement sélectif : {0}" -f $artifactName)
    & $gh run download ([string]$run.databaseId) --repo $repo --name $artifactName --dir $artifactDest
    if($LASTEXITCODE -ne 0){
        $downloadErrors += $artifactName
        Write-CrodipWarning ("Artefact ignoré après échec de téléchargement : {0}" -f $artifactName)
        continue
    }
    $candidateFiles=@(Get-ChildItem $artifactDest -Recurse -File -Filter manifest.json -ErrorAction SilentlyContinue)
    foreach($f in $candidateFiles){
        try{
            $m=Get-Content $f.FullName -Raw|ConvertFrom-Json
            if($m.PSObject.Properties.Name -contains 'images' -and
               $m.PSObject.Properties.Name -contains 'applicationVersion' -and
               $m.PSObject.Properties.Name -contains 'gitCommit' -and
               [string]$m.gitCommit -eq [string]$run.headSha){
                $manifest=$m
                $manifestPath=$f.FullName
                break
            }
        }catch{}
    }
    if($null -ne $manifest){ break }
}
if($null -eq $manifest){
    $available=($safeArtifacts | ForEach-Object {[string]$_.name}) -join ', '
    throw ("Manifest officiel correspondant au run introuvable. Artefacts examinés : {0}" -f $available)
}
$manifests=@($manifestPath)
$images=Images-FromManifest $manifest
Write-Host ''; Write-Host 'CANDIDAT RELEASE RUNTIME TEST' -ForegroundColor Cyan
Write-Host ("Application : {0}" -f $manifest.applicationVersion); Write-Host ("Run         : #{0} / {1}" -f $run.number,$run.databaseId); Write-Host ("Commit      : {0}" -f $run.headSha); Write-Host ("Manifest    : {0}" -f $manifestPath)
foreach($t in @('local','central')){foreach($svc in @('backend','frontend')){Write-Host ("{0,-7} {1,-8}: {2}" -f $t.ToUpperInvariant(),$svc,$images[$t][$svc].reference)}}
Write-CrodipWarning "SELECTION RUNTIME TEST : le pin officiel n’est PAS modifié."
Write-CrodipWarning "Un changement vers une version antérieure OU postérieure peut nécessiter un schéma PostgreSQL compatible. Le volume CENTRAL est conservé et n’est jamais supprimé automatiquement."

# RC41 : le précontrôle transactionnel doit impérativement précéder toute
# proposition d'activation. Un DOWNGRADE non restaurable ne doit jamais
# atteindre l'invite SWITCH-RUNTIME.
$releasePreflight=$null
$emptyTestMode=$false
try {
    $releasePreflight=Invoke-CrodipReleaseChangePreflight -TargetRunNumber ([int]$run.number) -TargetRunId ([string]$run.databaseId) -TargetApplicationVersion ([string]$manifest.applicationVersion) -TargetImages $images
} catch {
    $preflightError=$_.Exception.Message
    $current=Get-CrodipEffectiveReleaseIdentity
    $direction=Get-CrodipReleaseChangeDirection -CurrentRun ([int]$current.runNumber) -TargetRun ([int]$run.number)
    $cfgForEmpty=Get-CrodipRuntimeConfig
    $isTestLifecycle=([string]$cfgForEmpty.docker.activeLifecycle -eq 'TEST')
    if($direction -eq 'DOWNGRADE' -and $isTestLifecycle -and $preflightError -like 'DOWNGRADE BLOQUÉ : aucun snapshot compatible trouvé*'){
        $reconstructed=Find-CrodipReconstructedEmptySnapshot -RunNumber ([int]$run.number) -RunId ([string]$run.databaseId)
        if($reconstructed){
            $emptyCheck=Test-CrodipReconstructedEmptySnapshot -Snapshot $reconstructed -ExpectedRunNumber ([int]$run.number) -ExpectedRunId ([string]$run.databaseId) -TargetImages $images
            if($emptyCheck.Valid){
                Write-Host '';Write-Host 'MODE TEST EMPTY DISPONIBLE' -ForegroundColor Yellow
                Write-CrodipWarning 'Aucun snapshot métier historique authentique n existe pour cette release.'
                Write-CrodipWarning 'Un snapshot STEP3D RECONSTRUCTED / EMPTY qualifié est disponible.'
                Write-Host '  1. Annuler (comportement sûr par défaut)'
                Write-Host ("  2. Activer #{0} avec bases EMPTY reconstruites [TEST UNIQUEMENT]" -f $run.number)
                $emptyChoice=(Read-Host 'Votre choix').Trim()
                if($emptyChoice -ne '2'){throw $preflightError}
                Write-Host '';Write-CrodipWarning 'Cette opération remplace temporairement les bases actives par des bases EMPTY compatibles avec la release cible.'
                Write-CrodipWarning 'Les données métier historiques de la release cible NE SERONT PAS présentes.'
                $emptyConfirm=Read-Host 'Saisir exactement ACTIVER EMPTY pour continuer'
                if($emptyConfirm -cne 'ACTIVER EMPTY'){Write-CrodipWarning 'Activation EMPTY annulée.';return}
                # Le préflight normal a déjà créé le snapshot de sécurité de la release source avant de constater l absence de snapshot cible.
                $safety=Find-CrodipReleaseSnapshot -RunNumber ([int]$current.runNumber) -RunId ([string]$current.runId)
                if(-not $safety){throw 'STEP3E BLOQUÉ : snapshot de sécurité de la release source introuvable.'}
                $releasePreflight=[pscustomobject]@{Direction='DOWNGRADE';Current=$current;SafetySnapshot=$safety;TargetSnapshot=$reconstructed;BackupManifest=$emptyCheck.BackupManifest;Ready=$true}
                $emptyTestMode=$true
            } else {
                throw ('DOWNGRADE BLOQUÉ : snapshot RECONSTRUCTED/EMPTY invalide : '+(($emptyCheck.Errors)-join ' | '))
            }
        } else { throw $preflightError }
    } else { throw }
}
if(-not $releasePreflight.Ready){throw 'Précontrôle transactionnel du changement de release en échec.'}
$isDowngrade=($releasePreflight.Direction -eq 'DOWNGRADE')
$targetBackupManifest=$null
if($isDowngrade){
    if($emptyTestMode){
        $snapshotCheck=Test-CrodipReconstructedEmptySnapshot -Snapshot $releasePreflight.TargetSnapshot -ExpectedRunNumber ([int]$run.number) -ExpectedRunId ([string]$run.databaseId) -TargetImages $images
        if(-not $snapshotCheck.Valid){throw ('DOWNGRADE BLOQUÉ : snapshot RECONSTRUCTED/EMPTY cible invalide : '+(($snapshotCheck.Errors)-join ' | '))}
        $targetBackupManifest=$snapshotCheck.BackupManifest
    } else {
        $snapshotCheck=Test-CrodipReleaseSnapshot -Snapshot $releasePreflight.TargetSnapshot -ExpectedRunNumber ([int]$run.number) -ExpectedRunId ([string]$run.databaseId) -TargetImages $images
        if(-not $snapshotCheck.Valid){throw ('DOWNGRADE BLOQUÉ : snapshot cible invalide : '+(($snapshotCheck.Errors)-join ' | '))}
        $targetBackupManifest=$snapshotCheck.BackupManifest
        Write-CrodipSuccess 'Snapshot cible qualifié pour restauration SQLite + PostgreSQL.'
    }
}
if($emptyTestMode){Write-CrodipWarning 'STEP3E actif : activation volontaire avec bases RECONSTRUCTED/EMPTY.'}

$confirmation=if($emptyTestMode){'SWITCH-RUNTIME-EMPTY'}elseif($isDowngrade){'SWITCH-RUNTIME-ROLLBACK'}else{'SWITCH-RUNTIME'}
$c=Read-Host ("Saisir {0} pour activer ce run en TEST" -f $confirmation)
if($c -cne $confirmation){Write-CrodipWarning 'Opération annulée.';return}
foreach($t in @('local','central')){foreach($svc in @('backend','frontend')){$r=$images[$t][$svc].reference; Write-CrodipStep "Pull $r"; & docker pull $r; if($LASTEXITCODE-ne 0){throw "Pull impossible : $r"}}}
$cfg=Get-CrodipRuntimeConfig
$override=[ordered]@{active=$true;source='SELECTED_SUCCESSFUL_CI_RUN';selectedAt=(Get-Date).ToString('o');applicationVersion=[string]$manifest.applicationVersion;runNumber=[int]$run.number;runId=[string]$run.databaseId;commit=[string]$run.headSha;manifestPath=[string]$manifestPath;images=$images;officialRunNumber=[int]$cfg.release.runNumber;officialApplicationVersion=[string]$cfg.application.version;databaseMode=$(if($emptyTestMode){'RECONSTRUCTED_EMPTY'}else{'HISTORICAL_OR_CURRENT'});sourceSafetyArchive=$(if($releasePreflight.SafetySnapshot){[string]$releasePreflight.SafetySnapshot.archive}else{$null});sourceRunNumber=$(if($releasePreflight.Current){[int]$releasePreflight.Current.runNumber}else{0});sourceRunId=$(if($releasePreflight.Current){[string]$releasePreflight.Current.runId}else{$null});targetDatabaseArchive=$(if($emptyTestMode -and $releasePreflight.TargetSnapshot){[string]$releasePreflight.TargetSnapshot.archive}else{$null})}

$originalConfigJson=Get-Content -LiteralPath $configPath -Raw
$originalOverrideJson=$null
if(Test-Path -LiteralPath $overrideStatePath){$originalOverrideJson=Get-Content -LiteralPath $overrideStatePath -Raw}
$databasesTouched=$false
try {
    if($isDowngrade){
        # From this point an exception may occur after partial DB mutation: rollback is mandatory.
        $databasesTouched=$true
        if($emptyTestMode){
            Write-CrodipStep 'STEP3E - restauration STAGEE des bases EMPTY; backends laissés arrêtés jusqu aux images cibles'
            Invoke-CrodipReconstructedEmptySnapshotRestore -Snapshot $releasePreflight.TargetSnapshot -ExpectedRunNumber ([int]$run.number) -ExpectedRunId ([string]$run.databaseId) -TargetImages $images -ExplicitTestEmpty | Out-Null
        } else {
            Write-CrodipStep 'STEP3B - restauration des bases de la release cible avant activation des images'
            Invoke-CrodipReleaseSnapshotRestore -Snapshot $releasePreflight.TargetSnapshot -ExpectedRunNumber ([int]$run.number) -ExpectedRunId ([string]$run.databaseId) -TargetImages $images -Staged | Out-Null
        }
    }
    if($cfg.PSObject.Properties.Name -contains 'testOverride'){$cfg.testOverride=$override}else{$cfg|Add-Member -NotePropertyName testOverride -NotePropertyValue $override}
    Save-Config $cfg
    Save-OverrideState ([pscustomobject]$override)
    Write-CrodipSuccess ("Override persistant : {0}" -f $overrideStatePath)

    # FIX11: bind Alembic release expectations to the qualified TARGET snapshot
    # only for the target redeployment. Never weaken release=image=database.
    $previousTargetLocal=[Environment]::GetEnvironmentVariable('CRODIP_TARGET_ALEMBIC_LOCAL','Process')
    $previousTargetCentral=[Environment]::GetEnvironmentVariable('CRODIP_TARGET_ALEMBIC_CENTRAL','Process')
    try {
        if($isDowngrade){
            if($null -eq $targetBackupManifest){throw 'FIX11 : BACKUP-MANIFEST cible absent pour le contexte Alembic transactionnel.'}
            $targetLocalHead=[string]$targetBackupManifest.database.local.alembicRevision
            $targetCentralHead=[string]$targetBackupManifest.database.central.alembicRevision
            if([string]::IsNullOrWhiteSpace($targetLocalHead) -or [string]::IsNullOrWhiteSpace($targetCentralHead)){throw 'FIX11 : heads Alembic cibles absents du snapshot qualifié.'}
            [Environment]::SetEnvironmentVariable('CRODIP_TARGET_ALEMBIC_LOCAL',$targetLocalHead,'Process')
            [Environment]::SetEnvironmentVariable('CRODIP_TARGET_ALEMBIC_CENTRAL',$targetCentralHead,'Process')
            Write-CrodipStep ("FIX11 - contexte Alembic release cible : LOCAL={0} ; CENTRAL={1}" -f $targetLocalHead,$targetCentralHead)
        }
        Sync-And-Redeploy
        if($emptyTestMode){ Assert-DatabaseCoherence }
    } finally {
        [Environment]::SetEnvironmentVariable('CRODIP_TARGET_ALEMBIC_LOCAL',$previousTargetLocal,'Process')
        [Environment]::SetEnvironmentVariable('CRODIP_TARGET_ALEMBIC_CENTRAL',$previousTargetCentral,'Process')
    }
    Write-CrodipSuccess ("Release Runtime TEST active : run #{0} / application {1}" -f $run.number,$manifest.applicationVersion)
    Write-CrodipSuccess ("Release officielle inchangée : run #{0} / application {1}" -f $cfg.release.runNumber,$cfg.application.version)
} catch {
    $activationError=$_.Exception.Message
    if($databasesTouched -and $releasePreflight.SafetySnapshot){
        Write-CrodipWarning 'STEP3E/STEP3B : échec après modification DB - rollback atomique obligatoire vers la source.'
        try {
            Restore-SnapshotStaged -Archive ([string]$releasePreflight.SafetySnapshot.archive)
            Set-Content -LiteralPath $configPath -Value $originalConfigJson -Encoding utf8
            if($null -ne $originalOverrideJson){Set-Content -LiteralPath $overrideStatePath -Value $originalOverrideJson -Encoding utf8}else{Clear-OverrideState}
            Sync-And-Redeploy
            Assert-DatabaseCoherence
            Write-CrodipSuccess 'Rollback atomique source terminé et qualifié.'
        } catch {
            throw ("ECHEC CRITIQUE rollback source après erreur activation [{0}] : {1}" -f $activationError,$_.Exception.Message)
        }
    } else {
        Set-Content -LiteralPath $configPath -Value $originalConfigJson -Encoding utf8
        if($null -ne $originalOverrideJson){Set-Content -LiteralPath $overrideStatePath -Value $originalOverrideJson -Encoding utf8}else{Clear-OverrideState}
    }
    throw $activationError
}

Write-Host ''
Write-Host 'Vérification SQLite/PostgreSQL après changement de release...' -ForegroundColor Cyan
$dbCheck=Join-Path $RuntimeRoot 'commands\19-verify-databases.ps1'
if(Test-Path -LiteralPath $dbCheck){
    & $dbCheck
    if($LASTEXITCODE -ne 0){
        Write-CrodipWarning 'La release est déployée mais la vérification DB a échoué. Contrôler la compatibilité du schéma.'
    }
}
