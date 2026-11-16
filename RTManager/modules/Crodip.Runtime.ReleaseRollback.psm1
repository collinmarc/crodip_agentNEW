# CRODIP Runtime Manager RC41 - release-bound database snapshots
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
# RC41 STEP3E FIX3 - dépendance explicite : les fonctions de ce module
# utilisent Get-CrodipRuntimeConfig / Get-CrodipPersistentTestOverride du module Common.
$commonModule = Join-Path $PSScriptRoot 'Crodip.Runtime.Common.psm1'
if(-not (Test-Path -LiteralPath $commonModule -PathType Leaf)){throw "Module Common introuvable : $commonModule"}
# Do not reload Common with -Force here: when the menu has already imported Common,
# a forced nested reload can remove its exported commands from the caller session.
# RC41 STEP3E FIX5 - dependency established in this module scope, without forced reload.
Import-Module $commonModule -DisableNameChecking -ErrorAction Stop
function Get-CrodipReleaseSnapshotRoot { 'C:\ProgramData\CRODIP\release-snapshots' }
function Get-CrodipEffectiveReleaseIdentity {
  $cfg=Get-CrodipRuntimeConfig; $ov=Get-CrodipPersistentTestOverride
  if($ov -and $ov.active){return [pscustomobject]@{applicationVersion=[string]$ov.applicationVersion;runNumber=[int]$ov.runNumber;runId=[string]$ov.runId;commit=[string]$ov.commit;source='TEST_OVERRIDE'}}
  [pscustomobject]@{applicationVersion=[string]$cfg.application.version;runNumber=[int]$cfg.release.runNumber;runId=[string]$cfg.release.runId;commit=[string]$cfg.release.commit;source='OFFICIAL'}
}
function New-CrodipReleaseSnapshot {
 [CmdletBinding()]param([string]$Reason='pre-release-change')
 $id=Get-CrodipEffectiveReleaseIdentity; $root=Get-CrodipReleaseSnapshotRoot
 $dir=Join-Path $root ("run-{0}-{1}" -f $id.runNumber,$id.runId); New-Item -ItemType Directory -Force -Path $dir|Out-Null
 $before=@(Get-ChildItem $dir -Filter 'crodip-runtime-quick-*.zip' -File -ErrorAction SilentlyContinue)
 & (Join-Path $PSScriptRoot '..\commands\06-backup.ps1') -Mode quick -DestinationDirectory $dir -Purpose $Reason
 if($LASTEXITCODE -ne 0){throw 'Création du snapshot de release en échec.'}
 $archive=Get-ChildItem $dir -Filter 'crodip-runtime-quick-*.zip' -File|Sort-Object LastWriteTime -Descending|Select-Object -First 1
 if(-not $archive){throw 'Archive snapshot introuvable après sauvegarde.'}
 $meta=[ordered]@{schemaVersion=1;createdAt=(Get-Date).ToString('o');runtimeVersion=(Get-CrodipRuntimeVersion);reason=$Reason;release=$id;archive=$archive.FullName;status='READY'}
 $meta|ConvertTo-Json -Depth 10|Set-Content (Join-Path $dir 'release-snapshot.json') -Encoding utf8
 return [pscustomobject]$meta
}
function Find-CrodipReleaseSnapshot {
 [CmdletBinding()]param([Parameter(Mandatory)][int]$RunNumber,[string]$RunId)
 $root=Get-CrodipReleaseSnapshotRoot;if(-not(Test-Path $root)){return $null}
 $dirs=if($RunId){@(Get-ChildItem $root -Directory -Filter ("run-{0}-{1}" -f $RunNumber,$RunId) -ErrorAction SilentlyContinue)}else{@(Get-ChildItem $root -Directory -Filter ("run-{0}-*" -f $RunNumber) -ErrorAction SilentlyContinue)}
 foreach($d in ($dirs|Sort-Object LastWriteTime -Descending)){$m=Join-Path $d.FullName 'release-snapshot.json';if(Test-Path $m){return Get-Content $m -Raw|ConvertFrom-Json}}
 return $null
}
Export-ModuleMember -Function Get-CrodipReleaseSnapshotRoot,Get-CrodipEffectiveReleaseIdentity,New-CrodipReleaseSnapshot,Find-CrodipReleaseSnapshot

function Get-CrodipSnapshotBackupManifest {
 [CmdletBinding()]param([Parameter(Mandatory)]$Snapshot)
 $archive=[string]$Snapshot.archive
 if([string]::IsNullOrWhiteSpace($archive) -or -not(Test-Path -LiteralPath $archive)){return $null}
 Add-Type -AssemblyName System.IO.Compression.FileSystem
 $zip=[IO.Compression.ZipFile]::OpenRead($archive)
 try {
   $entry=@($zip.Entries|Where-Object{$_.FullName -match '(^|/)BACKUP-MANIFEST\.json$'}|Select-Object -First 1)
   if(-not $entry){return $null}
   $sr=[IO.StreamReader]::new($entry.Open())
   try { return ($sr.ReadToEnd()|ConvertFrom-Json) } finally {$sr.Dispose()}
 } finally {$zip.Dispose()}
}
function Get-CrodipImageAlembicHead {
 [CmdletBinding()]param([Parameter(Mandatory)][string]$Image,[Parameter(Mandatory)][ValidateSet('local','central')][string]$Target)
 $cmd="cd /app/$Target && PYTHONPATH=/app /app/.venv/bin/alembic -c /app/$Target/alembic.ini heads"
 $out=@(& docker run --rm --entrypoint sh $Image -c $cmd 2>$null)
 if($LASTEXITCODE -ne 0){throw "Impossible de lire le head Alembic de l'image $Target : $Image"}
 $line=@($out|Where-Object{[string]$_ -match '^([0-9a-f]+) \(head\)$'}|Select-Object -First 1)
 if(-not $line){throw "Head Alembic introuvable dans l'image $Target."}
 return ([regex]::Match([string]$line,'^([0-9a-f]+)').Groups[1].Value)
}
function Get-CrodipReleaseChangeDirection {
 [CmdletBinding()]param([Parameter(Mandatory)][int]$CurrentRun,[Parameter(Mandatory)][int]$TargetRun)
 if($TargetRun -lt $CurrentRun){return 'DOWNGRADE'}
 if($TargetRun -gt $CurrentRun){return 'UPGRADE'}
 return 'SAME'
}
function Invoke-CrodipReleaseChangePreflight {
 [CmdletBinding()]param(
   [Parameter(Mandatory)][int]$TargetRunNumber,
   [Parameter(Mandatory)][string]$TargetRunId,
   [Parameter(Mandatory)][string]$TargetApplicationVersion,
   [Parameter(Mandatory)]$TargetImages
 )
 $current=Get-CrodipEffectiveReleaseIdentity
 $direction=Get-CrodipReleaseChangeDirection -CurrentRun ([int]$current.runNumber) -TargetRun $TargetRunNumber
 Write-Host '';Write-Host 'TRANSACTION DE CHANGEMENT DE RELEASE' -ForegroundColor Cyan
 Write-Host ("Release actuelle : #{0} / {1}" -f $current.runNumber,$current.applicationVersion)
 Write-Host ("Release cible    : #{0} / {1}" -f $TargetRunNumber,$TargetApplicationVersion)
 Write-Host ("Direction        : {0}" -f $direction)
 if($direction -eq 'SAME'){return [pscustomobject]@{Direction=$direction;Current=$current;TargetSnapshot=$null;Ready=$true}}
 Write-Host '';Write-Host '==> Snapshot de sécurité de la release actuelle' -ForegroundColor Cyan
 $safety=New-CrodipReleaseSnapshot -Reason 'pre-release-change'
 Write-Host ("[OK] Snapshot courant : {0}" -f $safety.archive) -ForegroundColor Green
 if($direction -eq 'UPGRADE'){return [pscustomobject]@{Direction=$direction;Current=$current;SafetySnapshot=$safety;TargetSnapshot=$null;Ready=$true}}
 Write-Host '';Write-Host '==> Précontrôle rollback DOWN' -ForegroundColor Cyan
 $target=Find-CrodipReleaseSnapshot -RunNumber $TargetRunNumber -RunId $TargetRunId
 if(-not $target){throw "DOWNGRADE BLOQUÉ : aucun snapshot compatible trouvé pour le run #$TargetRunNumber / $TargetRunId. Aucune release ni base n'a été modifiée."}
 $bm=Get-CrodipSnapshotBackupManifest -Snapshot $target
 if(-not $bm){throw 'DOWNGRADE BLOQUÉ : BACKUP-MANIFEST.json absent ou illisible dans le snapshot cible.'}
 $localHead=Get-CrodipImageAlembicHead -Image ([string]$TargetImages.local.backend.reference) -Target local
 $centralHead=Get-CrodipImageAlembicHead -Image ([string]$TargetImages.central.backend.reference) -Target central
 $snapLocal=[string]$bm.database.local.alembicRevision;$snapCentral=[string]$bm.database.central.alembicRevision
 $localOk=(-not [string]::IsNullOrWhiteSpace($snapLocal) -and $snapLocal -eq $localHead)
 $centralOk=(-not [string]::IsNullOrWhiteSpace($snapCentral) -and $snapCentral -eq $centralHead)
 Write-Host ("LOCAL   snapshot Alembic : {0}" -f $(if($snapLocal){$snapLocal}else{'ABSENT'}))
 Write-Host ("LOCAL   image head       : {0} [{1}]" -f $localHead,$(if($localOk){'OK'}else{'ECHEC'}))
 Write-Host ("CENTRAL snapshot Alembic : {0}" -f $(if($snapCentral){$snapCentral}else{'ABSENT'}))
 Write-Host ("CENTRAL image head       : {0} [{1}]" -f $centralHead,$(if($centralOk){'OK'}else{'ECHEC'}))
 if(-not($localOk -and $centralOk)){throw 'DOWNGRADE BLOQUÉ : le snapshot cible ne correspond pas aux heads Alembic des images cibles.'}
 Write-Host '[OK] Rollback base de données disponible. Étape 2 : aucune restauration automatique effectuée.' -ForegroundColor Green
 return [pscustomobject]@{Direction=$direction;Current=$current;SafetySnapshot=$safety;TargetSnapshot=$target;BackupManifest=$bm;LocalExpectedHead=$localHead;CentralExpectedHead=$centralHead;Ready=$true}
}
Export-ModuleMember -Function Get-CrodipSnapshotBackupManifest,Get-CrodipImageAlembicHead,Get-CrodipReleaseChangeDirection,Invoke-CrodipReleaseChangePreflight


# RC41 STEP3E - activation TEST explicite d'un snapshot reconstruit EMPTY.
# Ce chemin est volontairement distinct de STEP3B : Find-CrodipReleaseSnapshot
# continue d'ignorer release-snapshot-reconstructed.json.
function Find-CrodipReconstructedEmptySnapshot {
 [CmdletBinding()]param([Parameter(Mandatory)][int]$RunNumber,[Parameter(Mandatory)][string]$RunId)
 $dir=Join-Path (Get-CrodipReleaseSnapshotRoot) ("run-{0}-{1}" -f $RunNumber,$RunId)
 $meta=Join-Path $dir 'release-snapshot-reconstructed.json'
 if(-not(Test-Path -LiteralPath $meta -PathType Leaf)){return $null}
 try{return (Get-Content -LiteralPath $meta -Raw|ConvertFrom-Json)}catch{return $null}
}
function Test-CrodipReconstructedEmptySnapshot {
 [CmdletBinding()]param([Parameter(Mandatory)]$Snapshot,[Parameter(Mandatory)][int]$ExpectedRunNumber,[Parameter(Mandatory)][string]$ExpectedRunId,[Parameter(Mandatory)]$TargetImages)
 $errors=[System.Collections.Generic.List[string]]::new()
 if(-not $Snapshot){$errors.Add('Snapshot reconstruit absent.');return [pscustomobject]@{Valid=$false;Errors=@($errors);BackupManifest=$null}}
 if([string]$Snapshot.status -ne 'RECONSTRUCTED_READY_NOT_AUTO_RESTORABLE'){$errors.Add('Statut reconstructed non autorisé.')}
 if([string]$Snapshot.origin -ne 'reconstructed'){$errors.Add('Origin reconstructed absent.')}
 if([string]$Snapshot.dataState -ne 'EMPTY'){$errors.Add('Le snapshot reconstructed n est pas EMPTY.')}
 if([int]$Snapshot.release.runNumber -ne $ExpectedRunNumber){$errors.Add('Run reconstructed incorrect.')}
 if([string]$Snapshot.release.runId -ne $ExpectedRunId){$errors.Add('Run ID reconstructed incorrect.')}
 $base=Test-CrodipReleaseSnapshot -Snapshot $Snapshot -ExpectedRunNumber $ExpectedRunNumber -ExpectedRunId $ExpectedRunId -TargetImages $TargetImages
 foreach($e in @($base.Errors)){$errors.Add([string]$e)}
 $bm=$base.BackupManifest
 if($bm){
  if([string]$bm.backupMode -ne 'reconstructed'){$errors.Add('BACKUP-MANIFEST backupMode doit être reconstructed.')}
  if([string]$bm.dataState -ne 'EMPTY'){$errors.Add('BACKUP-MANIFEST dataState doit être EMPTY.')}
  if(-not [bool]$bm.qualified){$errors.Add('Snapshot reconstructed non qualifié.')}
  if([bool]$bm.qualification.historicalBusinessData){$errors.Add('Un snapshot EMPTY ne doit pas déclarer de données métier historiques.')}
  if(-not [bool]$bm.qualification.liveDatabasesModified){ } else {$errors.Add('La reconstruction STEP3D a déclaré une modification des bases actives.')}
 }
 [pscustomobject]@{Valid=($errors.Count -eq 0);Errors=@($errors);BackupManifest=$bm;Archive=[string]$Snapshot.archive}
}
function Invoke-CrodipReconstructedEmptySnapshotRestore {
 [CmdletBinding()]param([Parameter(Mandatory)]$Snapshot,[Parameter(Mandatory)][int]$ExpectedRunNumber,[Parameter(Mandatory)][string]$ExpectedRunId,[Parameter(Mandatory)]$TargetImages,[Parameter(Mandatory)][switch]$ExplicitTestEmpty)
 if(-not $ExplicitTestEmpty){throw 'RESTAURATION EMPTY REFUSÉE : consentement explicite absent.'}
 $check=Test-CrodipReconstructedEmptySnapshot -Snapshot $Snapshot -ExpectedRunNumber $ExpectedRunNumber -ExpectedRunId $ExpectedRunId -TargetImages $TargetImages
 if(-not $check.Valid){throw ('RESTAURATION EMPTY BLOQUÉE : '+(($check.Errors)-join ' | '))}
 Write-Host '';Write-Host '==> STEP3E - restauration explicite des bases RECONSTRUCTED / EMPTY' -ForegroundColor Yellow
 Write-Host '[ATTENTION] Les données métier historiques de la release cible seront ABSENTES.' -ForegroundColor Yellow
 & (Join-Path $PSScriptRoot '..\commands\07-restore.ps1') -ArchivePath $check.Archive -Force -SkipPostRestoreVerification -DeferBackendStart
 if($LASTEXITCODE -ne 0){throw 'Restauration stagee RECONSTRUCTED/EMPTY en échec.'}
 [pscustomobject]@{Success=$true;Archive=$check.Archive;BackupManifest=$check.BackupManifest;Mode='RECONSTRUCTED_EMPTY'}
}
Export-ModuleMember -Function Find-CrodipReconstructedEmptySnapshot,Test-CrodipReconstructedEmptySnapshot,Invoke-CrodipReconstructedEmptySnapshotRestore

# RC41 STEP3A - validated release snapshot restore engine
function Test-CrodipReleaseSnapshot {
 [CmdletBinding()]param(
   [Parameter(Mandatory)]$Snapshot,
   [int]$ExpectedRunNumber=0,
   [string]$ExpectedRunId,
   $TargetImages
 )
 $errors=[System.Collections.Generic.List[string]]::new()
 if(-not $Snapshot){$errors.Add('Snapshot absent.');return [pscustomobject]@{Valid=$false;Errors=@($errors);BackupManifest=$null}}
 if($ExpectedRunNumber -gt 0 -and [int]$Snapshot.release.runNumber -ne $ExpectedRunNumber){$errors.Add("Run snapshot incorrect : $($Snapshot.release.runNumber) != $ExpectedRunNumber")}
 if($ExpectedRunId -and [string]$Snapshot.release.runId -ne $ExpectedRunId){$errors.Add("Run ID snapshot incorrect : $($Snapshot.release.runId) != $ExpectedRunId")}
 $archive=[string]$Snapshot.archive
 if([string]::IsNullOrWhiteSpace($archive) -or -not(Test-Path -LiteralPath $archive -PathType Leaf)){$errors.Add('Archive snapshot absente.')}
 $bm=$null
 if($errors.Count -eq 0){$bm=Get-CrodipSnapshotBackupManifest -Snapshot $Snapshot;if(-not $bm){$errors.Add('BACKUP-MANIFEST.json absent ou illisible.')}}
 if($bm){
   if(-not [bool]$bm.database.local.deployed){$errors.Add('Base SQLite LOCAL absente du snapshot.')}
   if([string]::IsNullOrWhiteSpace([string]$bm.database.local.alembicRevision)){$errors.Add('Révision Alembic LOCAL absente.')}
   if(-not [bool]$bm.database.central.dumpIncluded){$errors.Add('Dump PostgreSQL CENTRAL absent du snapshot.')}
   if([string]::IsNullOrWhiteSpace([string]$bm.database.central.alembicRevision)){$errors.Add('Révision Alembic CENTRAL absente.')}
   if($TargetImages){
     try{$lh=Get-CrodipImageAlembicHead -Image ([string]$TargetImages.local.backend.reference) -Target local;if($lh -ne [string]$bm.database.local.alembicRevision){$errors.Add("Alembic LOCAL incompatible : snapshot=$($bm.database.local.alembicRevision), image=$lh")}}catch{$errors.Add("Contrôle image LOCAL impossible : $($_.Exception.Message)")}
     try{$ch=Get-CrodipImageAlembicHead -Image ([string]$TargetImages.central.backend.reference) -Target central;if($ch -ne [string]$bm.database.central.alembicRevision){$errors.Add("Alembic CENTRAL incompatible : snapshot=$($bm.database.central.alembicRevision), image=$ch")}}catch{$errors.Add("Contrôle image CENTRAL impossible : $($_.Exception.Message)")}
   }
 }
 [pscustomobject]@{Valid=($errors.Count -eq 0);Errors=@($errors);BackupManifest=$bm;Archive=$archive}
}
function Invoke-CrodipReleaseSnapshotRestore {
 [CmdletBinding()]param([Parameter(Mandatory)]$Snapshot,[int]$ExpectedRunNumber=0,[string]$ExpectedRunId,$TargetImages,[switch]$Staged)
 $check=Test-CrodipReleaseSnapshot -Snapshot $Snapshot -ExpectedRunNumber $ExpectedRunNumber -ExpectedRunId $ExpectedRunId -TargetImages $TargetImages
 if(-not $check.Valid){throw ('RESTAURATION RELEASE BLOQUÉE : '+(($check.Errors)-join ' | '))}
 Write-Host '';Write-Host '==> Restauration transactionnelle des bases de la release cible' -ForegroundColor Cyan
 Write-Host ("Archive : {0}" -f $check.Archive)
 if($Staged){
   & (Join-Path $PSScriptRoot '..\commands\07-restore.ps1') -ArchivePath $check.Archive -Force -SkipPostRestoreVerification -DeferBackendStart
 } else {
   & (Join-Path $PSScriptRoot '..\commands\07-restore.ps1') -ArchivePath $check.Archive -Force
 }
 if($LASTEXITCODE -ne 0){throw 'Restauration du snapshot de release en échec.'}
 return [pscustomobject]@{Success=$true;Archive=$check.Archive;BackupManifest=$check.BackupManifest}
}
Export-ModuleMember -Function Test-CrodipReleaseSnapshot,Invoke-CrodipReleaseSnapshotRestore

# RC41 STEP3C - Historical Release Snapshot Bootstrap
function Get-CrodipBackupManifestFromArchive {
 [CmdletBinding()]param([Parameter(Mandatory)][string]$ArchivePath)
 if(-not(Test-Path -LiteralPath $ArchivePath -PathType Leaf)){return $null}
 Add-Type -AssemblyName System.IO.Compression.FileSystem
 $zip=[IO.Compression.ZipFile]::OpenRead($ArchivePath)
 try {
   $entry=@($zip.Entries|Where-Object{$_.FullName -match '(^|/)BACKUP-MANIFEST\.json$'}|Select-Object -First 1)
   if(-not $entry){return $null}
   $sr=[IO.StreamReader]::new($entry.Open())
   try{return ($sr.ReadToEnd()|ConvertFrom-Json)}finally{$sr.Dispose()}
 } finally {$zip.Dispose()}
}
function Find-CrodipHistoricalBackupCandidate {
 [CmdletBinding()]param(
   [Parameter(Mandatory)][int]$RunNumber,
   [Parameter(Mandatory)][string]$RunId,
   [Parameter(Mandatory)]$TargetImages,
   [string[]]$SearchRoots=@('C:\ProgramData\CRODIP\backups','C:\ProgramData\CRODIP\release-snapshots')
 )
 $lh=Get-CrodipImageAlembicHead -Image ([string]$TargetImages.local.backend.reference) -Target local
 $ch=Get-CrodipImageAlembicHead -Image ([string]$TargetImages.central.backend.reference) -Target central
 $candidates=[System.Collections.Generic.List[object]]::new()
 foreach($root in $SearchRoots){
   if(-not(Test-Path -LiteralPath $root)){continue}
   foreach($f in @(Get-ChildItem -LiteralPath $root -Filter 'crodip-runtime-*.zip' -File -Recurse -ErrorAction SilentlyContinue)){
     try{$bm=Get-CrodipBackupManifestFromArchive -ArchivePath $f.FullName}catch{continue}
     if(-not $bm){continue}
     # RC41 STEP3C FIX2: les sauvegardes legacy peuvent ne pas exposer releaseIdentity/database.
     # Une propriété absente doit rendre le backup non qualifiable, jamais faire tomber le scanner sous Set-StrictMode.
     $riProp=$bm.PSObject.Properties['releaseIdentity']
     if(-not $riProp -or $null -eq $riProp.Value){continue}
     $ri=$riProp.Value
     $rnProp=$ri.PSObject.Properties['runNumber']; $ridProp=$ri.PSObject.Properties['runId']
     if(-not $rnProp -or -not $ridProp){continue}
     if([int]$rnProp.Value -ne $RunNumber -or [string]$ridProp.Value -ne $RunId){continue}

     $dbProp=$bm.PSObject.Properties['database']
     if(-not $dbProp -or $null -eq $dbProp.Value){continue}
     $localProp=$dbProp.Value.PSObject.Properties['local']; $centralProp=$dbProp.Value.PSObject.Properties['central']
     if(-not $localProp -or -not $centralProp){continue}
     $ld=$localProp.Value; $cd=$centralProp.Value
     $ldDeployed=$ld.PSObject.Properties['deployed']; $ldRev=$ld.PSObject.Properties['alembicRevision']
     $cdDump=$cd.PSObject.Properties['dumpIncluded']; $cdRev=$cd.PSObject.Properties['alembicRevision']
     $localOk=($ldDeployed -and [bool]$ldDeployed.Value -and $ldRev -and [string]$ldRev.Value -eq $lh)
     $centralOk=($cdDump -and [bool]$cdDump.Value -and $cdRev -and [string]$cdRev.Value -eq $ch)
     $candidates.Add([pscustomobject]@{Archive=$f.FullName;Manifest=$bm;LocalExpectedHead=$lh;CentralExpectedHead=$ch;Valid=($localOk -and $centralOk);LocalCompatible=$localOk;CentralCompatible=$centralOk;LastWriteTime=$f.LastWriteTime})
   }
 }
 return @($candidates|Sort-Object LastWriteTime -Descending)
}
function Register-CrodipHistoricalReleaseSnapshot {
 [CmdletBinding()]param(
   [Parameter(Mandatory)][string]$ArchivePath,
   [Parameter(Mandatory)][int]$RunNumber,
   [Parameter(Mandatory)][string]$RunId,
   [Parameter(Mandatory)][string]$ApplicationVersion,
   [Parameter(Mandatory)][string]$Commit,
   [Parameter(Mandatory)]$TargetImages
 )
 $bm=Get-CrodipBackupManifestFromArchive -ArchivePath $ArchivePath
 if(-not $bm){throw 'Snapshot historique refusé : BACKUP-MANIFEST.json absent.'}
 $riProp=$bm.PSObject.Properties['releaseIdentity']
 if(-not $riProp -or $null -eq $riProp.Value){throw 'Snapshot historique refusé : identité de release absente du backup.'}
 $ri=$riProp.Value
 $rnProp=$ri.PSObject.Properties['runNumber']; $ridProp=$ri.PSObject.Properties['runId']
 if(-not $rnProp -or -not $ridProp){throw 'Snapshot historique refusé : identité de release incomplète dans le backup.'}
 if([int]$rnProp.Value -ne $RunNumber -or [string]$ridProp.Value -ne $RunId){throw 'Snapshot historique refusé : le backup ne provient pas de la release cible.'}
 $lh=Get-CrodipImageAlembicHead -Image ([string]$TargetImages.local.backend.reference) -Target local
 $ch=Get-CrodipImageAlembicHead -Image ([string]$TargetImages.central.backend.reference) -Target central
 if(-not [bool]$bm.database.local.deployed -or [string]$bm.database.local.alembicRevision -ne $lh){throw "Snapshot historique refusé : SQLite/Alembic LOCAL incompatible (backup=$($bm.database.local.alembicRevision), image=$lh)."}
 if(-not [bool]$bm.database.central.dumpIncluded -or [string]$bm.database.central.alembicRevision -ne $ch){throw "Snapshot historique refusé : PostgreSQL/Alembic CENTRAL incompatible (backup=$($bm.database.central.alembicRevision), image=$ch)."}
 $dir=Join-Path (Get-CrodipReleaseSnapshotRoot) ("run-{0}-{1}" -f $RunNumber,$RunId)
 New-Item -ItemType Directory -Force -Path $dir|Out-Null
 $dest=Join-Path $dir ([IO.Path]::GetFileName($ArchivePath))
 if([IO.Path]::GetFullPath($ArchivePath) -ne [IO.Path]::GetFullPath($dest)){Copy-Item -LiteralPath $ArchivePath -Destination $dest -Force}
 $meta=[ordered]@{schemaVersion=1;createdAt=(Get-Date).ToString('o');runtimeVersion=(Get-CrodipRuntimeVersion);reason='historical-release-bootstrap';release=[ordered]@{applicationVersion=$ApplicationVersion;runNumber=$RunNumber;runId=$RunId;commit=$Commit;source='HISTORICAL_QUALIFIED_BACKUP'};archive=$dest;status='READY';qualification=[ordered]@{localAlembic=$lh;centralAlembic=$ch;identityMatched=$true;databaseCompatibility=$true;liveDatabasesModified=$false}}
 $meta|ConvertTo-Json -Depth 12|Set-Content (Join-Path $dir 'release-snapshot.json') -Encoding utf8
 return [pscustomobject]$meta
}
Export-ModuleMember -Function Get-CrodipBackupManifestFromArchive,Find-CrodipHistoricalBackupCandidate,Register-CrodipHistoricalReleaseSnapshot

