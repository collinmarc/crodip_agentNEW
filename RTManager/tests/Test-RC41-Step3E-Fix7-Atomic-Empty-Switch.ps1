$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$restore=Get-Content -LiteralPath (Join-Path $root 'commands\07-restore.ps1') -Raw
$select=Get-Content -LiteralPath (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
$rollback=Get-Content -LiteralPath (Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1') -Raw
foreach($f in @((Join-Path $root 'commands\07-restore.ps1'),(Join-Path $root 'commands\17-historical-test-run.ps1'),(Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1'))){
 $tokens=$null;$errors=$null
 [void][System.Management.Automation.Language.Parser]::ParseFile($f,[ref]$tokens,[ref]$errors)
 if($errors.Count){throw ("Erreur parser {0}: {1}" -f $f,(($errors|ForEach-Object Message)-join ' | '))}
}
foreach($needle in @('[switch]$SkipPostRestoreVerification','[switch]$DeferBackendStart','if(-not $SkipPostRestoreVerification)','if(-not $DeferBackendStart)')){if(-not $restore.Contains($needle)){throw "07-restore : garde FIX7 absente : $needle"}}
if(-not $rollback.Contains('-SkipPostRestoreVerification -DeferBackendStart')){throw 'ReleaseRollback : restauration EMPTY non stagee.'}
foreach($needle in @('sourceSafetyArchive=','targetDatabaseArchive=','$databasesTouched=$true','Restore-SnapshotStaged','Assert-DatabaseCoherence','Rollback atomique source terminé et qualifié.','Override RECONSTRUCTED_EMPTY : les bases source seront restaurees')){if(-not $select.Contains($needle)){throw "Transaction FIX7 incomplete : $needle"}}
$posTouched=$select.IndexOf('$databasesTouched=$true');$posEmpty=$select.IndexOf('Invoke-CrodipReconstructedEmptySnapshotRestore',$posTouched)
if($posTouched -lt 0 -or $posEmpty -lt 0 -or $posTouched -gt $posEmpty){throw 'Le marqueur DB touched doit preceder la restauration EMPTY.'}
Write-Host '[OK] RC41 STEP3E FIX7 - switch EMPTY stage, qualification apres images cibles, rollback source obligatoire et retour officiel avec restauration DB source qualifies structurellement.' -ForegroundColor Green
