$ErrorActionPreference='Stop'
$root=Split-Path $PSScriptRoot -Parent
$bootstrap=Get-Content (Join-Path $root 'bootstrap-runtime.ps1') -Raw
$historical=Get-Content (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
$rollback=Get-Content (Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1') -Raw
$errors=@()
if($bootstrap -notmatch 'Get-Command Write-CrodipError -ErrorAction SilentlyContinue'){$errors+='fallback Write-CrodipError absent du dispatcher'}
if($bootstrap -notmatch 'Write-Host "\[ERREUR\] \$errorMessage"'){$errors+='fallback Write-Host absent du catch'}
$pre=$historical.IndexOf('Invoke-CrodipReleaseChangePreflight');$switch=$historical.IndexOf("Read-Host 'Saisir SWITCH-RUNTIME")
if($pre -lt 0 -or $switch -lt 0 -or $pre -gt $switch){$errors+='préflight DOWN non positionné avant SWITCH-RUNTIME'}
if($rollback -notmatch 'DOWNGRADE BLOQUÉ : aucun snapshot compatible'){$errors+='garde-fou snapshot absent introuvable'}
if($errors.Count){$errors|ForEach-Object{Write-Host "[ECHEC] $_" -ForegroundColor Red};exit 1}
Write-Host '[OK] RC41 STEP2 GUARD FIX2 - chemin négatif DOWN robuste sans dépendance Write-CrodipError.' -ForegroundColor Green
