#Requires -Version 7.4
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$cmd=Join-Path $root 'commands\17-historical-test-run.ps1'
$rr=Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1'
$errors=@()
$c=Get-Content $cmd -Raw
$r=Get-Content $rr -Raw
foreach($needle in @('SWITCH-RUNTIME-ROLLBACK','Invoke-CrodipReleaseSnapshotRestore -Snapshot $releasePreflight.TargetSnapshot','rollback transactionnel vers le snapshot de sécurité','Test-CrodipReleaseSnapshot -Snapshot $releasePreflight.TargetSnapshot')){if($c -notlike "*$needle*"){$errors+="commande STEP3B absente : $needle"}}
if($c -like '*RC41 étape 2 : DOWNGRADE qualifié mais restauration DB non encore activée*'){$errors+='ancien garde-fou STEP2 encore actif'}
foreach($needle in @('function Test-CrodipReleaseSnapshot','function Invoke-CrodipReleaseSnapshotRestore')){if($r -notlike "*$needle*"){$errors+="moteur STEP3A absent : $needle"}}
if($errors.Count){$errors|ForEach-Object{Write-Host "[ECHEC] $_" -ForegroundColor Red};exit 1}
Write-Host '[OK] RC41 STEP3B - transaction DOWN raccordée : validation snapshot, restauration DB cible, activation release et rollback DB de secours.' -ForegroundColor Green
