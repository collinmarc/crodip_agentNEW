#Requires -Version 7.4
[CmdletBinding()] param()
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$cfg=Get-Content (Join-Path $root 'config\runtime.json') -Raw|ConvertFrom-Json
if($cfg.version -notin @('2.3.0-RC37','2.3.0-RC38')){throw 'Version RC37+ absente.'}
if(-not $cfg.databaseMigration.enabled){throw 'Migration DB RC37 désactivée.'}
if($cfg.databaseMigration.automaticDowngrade){throw 'Downgrade automatique interdit.'}
$module=Get-Content (Join-Path $root 'modules\Crodip.Runtime.DatabaseMigration.psm1') -Raw
foreach($x in @('upgrade head','PYTHONPATH=/app','/app/.venv/bin/alembic','Aucun downgrade automatique','pg_isready')){if($module -notmatch [regex]::Escape($x)){throw "RC37 absent: $x"}}
foreach($file in @('commands\03-start.ps1','commands\08-update.ps1','commands\12-central-runtime.ps1')){if((Get-Content (Join-Path $root $file)-Raw) -notmatch 'Invoke-CrodipRuntimeDatabaseMigration'){throw "Migration non branchée: $file"}}
$db=Get-Content (Join-Path $root 'commands\19-verify-databases.ps1') -Raw
if($db -notmatch 'Get-ImageAlembicHead'){throw 'Menu 20 non dynamique.'}
Write-Host '[OK] RC37 - migrations automatiques et politique upgrade-only intégrées.' -ForegroundColor Green
