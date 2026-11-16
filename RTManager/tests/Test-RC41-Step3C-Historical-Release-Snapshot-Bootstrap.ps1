$ErrorActionPreference='Stop'
$root=Split-Path $PSScriptRoot -Parent
$m=Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1'
$c=Join-Path $root 'commands\20-bootstrap-historical-release-snapshot.ps1'
$errors=@()
if(-not(Test-Path $m)){$errors+='module rollback absent'}
if(-not(Test-Path $c)){$errors+='commande STEP3C absente'}
$txt=Get-Content $m -Raw
foreach($name in @('Get-CrodipBackupManifestFromArchive','Find-CrodipHistoricalBackupCandidate','Register-CrodipHistoricalReleaseSnapshot')){if($txt -notmatch [regex]::Escape("function $name")){$errors+="fonction absente: $name"}}
if($txt -notmatch 'releaseIdentity\.runNumber'){$errors+='contrôle identité run absent'}
if($txt -notmatch 'database\.local\.alembicRevision'){$errors+='contrôle Alembic LOCAL absent'}
if($txt -notmatch 'database\.central\.alembicRevision'){$errors+='contrôle Alembic CENTRAL absent'}
if($txt -notmatch 'liveDatabasesModified=\$false'){$errors+='preuve non-mutation DB active absente'}
$ct=Get-Content $c -Raw
if($ct -notmatch 'refuse de fabriquer un snapshot'){$errors+='garde-fou anti-fabrication absent'}
if($ct -match '07-restore\.ps1|docker compose down|docker volume rm'){$errors+='commande STEP3C contient une mutation/restauration interdite'}
if($errors.Count){$errors|ForEach-Object{Write-Host "[ECHEC] $_" -ForegroundColor Red};exit 1}
Write-Host '[OK] RC41 STEP3C - bootstrap snapshot historique sûr : identité release + SQLite/PostgreSQL/Alembic, sans mutation des bases actives.' -ForegroundColor Green
