#Requires -Version 7.4
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$errors=[System.Collections.Generic.List[string]]::new()
function Assert-Text([string]$Text,[string]$Needle,[string]$Message){if(-not $Text.Contains($Needle,[System.StringComparison]::Ordinal)){$errors.Add($Message)}}
function Assert-NotText([string]$Text,[string]$Needle,[string]$Message){if($Text.Contains($Needle,[System.StringComparison]::Ordinal)){$errors.Add($Message)}}

$rrPath=Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1'
$cmd17Path=Join-Path $root 'commands\17-historical-test-run.ps1'
$cmd20Path=Join-Path $root 'commands\20-bootstrap-historical-release-snapshot.ps1'
$cmd21Path=Join-Path $root 'commands\21-reconstruct-historical-release-snapshot.ps1'
foreach($p in @($rrPath,$cmd17Path,$cmd20Path,$cmd21Path)){if(-not(Test-Path -LiteralPath $p)){$errors.Add("Fichier RC41 absent : $p")}}
if($errors.Count -eq 0){
 $rr=Get-Content $rrPath -Raw
 $c17=Get-Content $cmd17Path -Raw
 $c20=Get-Content $cmd20Path -Raw
 $c21=Get-Content $cmd21Path -Raw

 # 1. Snapshot historique authentique : seul release-snapshot.json est eligible a STEP3B.
 Assert-Text $rr "'release-snapshot.json'" 'Find-CrodipReleaseSnapshot ne cible plus release-snapshot.json.'
 Assert-Text $rr "`$m=Join-Path `$d.FullName 'release-snapshot.json'" 'Find-CrodipReleaseSnapshot ne cible plus exclusivement le metadata authentique release-snapshot.json.'
 Assert-Text $rr "`$meta=Join-Path `$dir 'release-snapshot-reconstructed.json'" 'STEP3E : metadata reconstructed séparé absent.'
 Assert-Text $rr 'Find-CrodipReconstructedEmptySnapshot' 'STEP3E explicite absent pour les snapshots reconstruits.'
 Assert-Text $c17 'Test-CrodipReleaseSnapshot -Snapshot $releasePreflight.TargetSnapshot' 'Validation du snapshot cible absente avant DOWNGRADE.'
 Assert-Text $c17 'Invoke-CrodipReleaseSnapshotRestore -Snapshot $releasePreflight.TargetSnapshot' 'Restauration du snapshot cible absente de STEP3B.'

 # 2. Snapshot RECONSTRUCTED/EMPTY : qualifie techniquement, jamais auto-restaurable.
 Assert-Text $c21 "backupMode='reconstructed'" 'Marquage backupMode=reconstructed absent.'
 Assert-Text $c21 "dataState='EMPTY'" 'Marquage dataState=EMPTY absent.'
 Assert-Text $c21 "status='RECONSTRUCTED_READY_NOT_AUTO_RESTORABLE'" 'Statut NON AUTO RESTORABLE absent.'
 Assert-Text $c21 'historicalBusinessData=$false' 'Garde-fou historicalBusinessData=false absent.'
 Assert-Text $c21 'NON ELIGIBLE au DOWNGRADE automatique STEP3B' 'Message de garde-fou STEP3B absent.'

 # 3. Absence de snapshot authentique : DOWNGRADE bloque avant activation.
 Assert-Text $rr 'DOWNGRADE BLOQUÉ : aucun snapshot compatible trouvé' 'Blocage sans snapshot compatible absent.'
 $preflightPos=$c17.IndexOf('Invoke-CrodipReleaseChangePreflight')
 $confirmPos=$c17.IndexOf("'SWITCH-RUNTIME-ROLLBACK'")
 if($preflightPos -lt 0 -or $confirmPos -lt 0 -or $preflightPos -gt $confirmPos){$errors.Add('Le preflight DOWNGRADE ne precede pas la confirmation SWITCH-RUNTIME-ROLLBACK.')}

 # 4. Transaction : snapshot de securite + rollback DB si activation echoue.
 Assert-Text $rr "New-CrodipReleaseSnapshot -Reason 'pre-release-change'" 'Snapshot de securite pre-release absent.'
 # STEP3B conserve sa restauration authentique ; STEP3E FIX7 utilise une restauration stagee
 # du meme SafetySnapshot afin de pouvoir reinstaller les images source avant qualification.
 Assert-Text $c17 'Invoke-CrodipReleaseSnapshotRestore -Snapshot $releasePreflight.TargetSnapshot' 'Restauration authentique STEP3B absente.'
 Assert-Text $c17 'STEP3E/STEP3B : échec après modification DB - rollback atomique obligatoire vers la source.' 'Rollback transactionnel atomique FIX7 absent.'
 Assert-Text $c17 'Restore-SnapshotStaged -Archive ([string]$releasePreflight.SafetySnapshot.archive)' 'Restauration stagee du snapshot de securite FIX7 absente.'
 Assert-Text $c17 'Rollback atomique source terminé et qualifié.' 'Qualification finale du rollback source FIX7 absente.'

 # 5. STEP3D FIX2 : aucune collision avec la variable automatique $args.
 Assert-Text $c21 '[string[]]$DockerArgs' 'STEP3D FIX2 : parametre DockerArgs absent.'
 Assert-Text $c21 '& docker @DockerArgs' 'STEP3D FIX2 : splatting DockerArgs absent.'
 if($c21 -match '(?i)\[string\[\]\]\s*\$args\b'){$errors.Add('STEP3D FIX2 : collision $args reapparue.')}

 # 6. Tous les scripts PowerShell RC41 doivent parser.
 $parseTargets=@($rrPath,$cmd17Path,$cmd20Path,$cmd21Path)
 foreach($p in $parseTargets){
   $tokens=$null;$parseErrors=$null
   [System.Management.Automation.Language.Parser]::ParseFile($p,[ref]$tokens,[ref]$parseErrors)|Out-Null
   foreach($pe in @($parseErrors)){$errors.Add("Parser PowerShell : $p : $($pe.Message)")}
 }
}

if($errors.Count){$errors|ForEach-Object{Write-Host "[ECHEC] $_" -ForegroundColor Red};exit 1}
Write-Host '[OK] RC41 QUALIFICATION FINALE - snapshots authentiques STEP3B separes des RECONSTRUCTED/EMPTY STEP3E, rollback de securite, STEP3D FIX2 et activation TEST EMPTY qualifies.' -ForegroundColor Green
