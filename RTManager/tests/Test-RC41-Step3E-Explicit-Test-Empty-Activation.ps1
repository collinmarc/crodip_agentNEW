# RC41 STEP3E - qualification statique du mode TEST EMPTY explicite
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$rr=Get-Content (Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1') -Raw
$h=Get-Content (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
$errors=[System.Collections.Generic.List[string]]::new()
function Need([string]$Text,[string]$Needle,[string]$Message){if(-not $Text.Contains($Needle,[StringComparison]::Ordinal)){$errors.Add($Message)}}
function Forbid([string]$Text,[string]$Needle,[string]$Message){if($Text.Contains($Needle,[StringComparison]::Ordinal)){$errors.Add($Message)}}
Need $rr 'Find-CrodipReconstructedEmptySnapshot' 'Résolveur reconstructed absent.'
Need $rr "RECONSTRUCTED_READY_NOT_AUTO_RESTORABLE" 'Statut reconstructed non contrôlé.'
Need $rr "dataState -ne 'EMPTY'" 'Garde-fou EMPTY absent.'
Need $rr "backupMode -ne 'reconstructed'" 'Garde-fou backupMode reconstructed absent.'
Need $rr 'ExplicitTestEmpty' 'Consentement explicite côté moteur absent.'
Need $h "activeLifecycle -eq 'TEST'" 'Restriction lifecycle TEST absente.'
Need $h 'ACTIVER EMPTY' 'Confirmation humaine ACTIVER EMPTY absente.'
Need $h 'SWITCH-RUNTIME-EMPTY' 'Deuxième confirmation SWITCH-RUNTIME-EMPTY absente.'
Need $h 'Invoke-CrodipReconstructedEmptySnapshotRestore' 'Restauration STEP3E absente.'
Need $h 'databaseMode=' 'Traçabilité databaseMode absente.'
Need $h 'RECONSTRUCTED_EMPTY' 'Traçabilité RECONSTRUCTED_EMPTY absente.'
# Le chemin automatique STEP3B doit continuer à rechercher uniquement release-snapshot.json.
Need $rr 'release-snapshot.json' 'Résolveur snapshot authentique STEP3B altéré.'
# STEP3E doit être déclenché uniquement après le blocage normal sans snapshot authentique.
Need $h "DOWNGRADE BLOQUÉ : aucun snapshot compatible trouvé*" 'Déclencheur après blocage STEP3B absent.'
if($errors.Count){$errors|ForEach-Object{Write-Host "[ECHEC] $_" -ForegroundColor Red};exit 1}
Write-Host '[OK] RC41 STEP3E - activation TEST EMPTY explicite, double confirmation, snapshot source et garde-fou STEP3B conserves.' -ForegroundColor Green
exit 0
