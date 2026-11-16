$ErrorActionPreference='Stop'
$root=Split-Path $PSScriptRoot -Parent
$mod=Get-Content (Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1') -Raw
$restore=Get-Content (Join-Path $root 'commands\07-restore.ps1') -Raw
$fail=@()
foreach($x in @('function Test-CrodipReleaseSnapshot','function Invoke-CrodipReleaseSnapshotRestore','Dump PostgreSQL CENTRAL absent','Alembic LOCAL incompatible','Alembic CENTRAL incompatible')){if($mod -notmatch [regex]::Escape($x)){$fail+="module:$x"}}
if($restore -notmatch '\[switch\]\$Force'){$fail+='restore:-Force'}
if($restore -notmatch '-not \$Force -and'){$fail+='restore:confirmation-bypass'}
if($mod -notmatch "07-restore\.ps1'.*-ArchivePath.*-Force"){$fail+='module:forced-restore-call'}
if($fail.Count){Write-Host ('[ECHEC] RC41 STEP3A : '+($fail -join ', ')) -ForegroundColor Red;exit 1}
Write-Host '[OK] RC41 STEP3A - moteur de validation/restauration snapshot release intégré (SQLite + PostgreSQL + Alembic).' -ForegroundColor Green
exit 0

# RC41 STEP3A-FIX1 regression guard: le module Docker ne doit pas appeler
# Get-CrodipHome/Get-CrodipDataRoot depuis son scope interne.
$dockerModulePath = Join-Path (Split-Path $PSScriptRoot -Parent) 'modules\Crodip.Runtime.Docker.psm1'
$dockerModuleText = Get-Content -LiteralPath $dockerModulePath -Raw
if ($dockerModuleText -match '(?<!Docker)Get-CrodipHome' -or $dockerModuleText -match '(?<!Docker)Get-CrodipDataRoot') {
    Write-Host '[ECHEC] STEP3A-FIX1 - dépendance inter-module de scope encore présente dans Crodip.Runtime.Docker.psm1.' -ForegroundColor Red
    exit 1
}
