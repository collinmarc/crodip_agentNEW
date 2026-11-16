#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'

$previousTargetLocal = [Environment]::GetEnvironmentVariable('CRODIP_TARGET_ALEMBIC_LOCAL','Process')
$previousTargetCentral = [Environment]::GetEnvironmentVariable('CRODIP_TARGET_ALEMBIC_CENTRAL','Process')

$root=Split-Path -Parent $PSScriptRoot
$m=Get-Content -LiteralPath (Join-Path $root 'modules\Crodip.Runtime.DatabaseMigration.psm1') -Raw
$c=Get-Content -LiteralPath (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
foreach($needle in @('CRODIP_TARGET_ALEMBIC_LOCAL','CRODIP_TARGET_ALEMBIC_CENTRAL','targetBackupManifest','FIX11 - contexte Alembic release cible')){if(-not $c.Contains($needle)){throw "FIX11 absent de command 17 : $needle"}}
if(-not $m.Contains('GetEnvironmentVariable($overrideName,''Process'')')){throw 'FIX11 : DatabaseMigration ne lit pas le contexte Alembic transactionnel Process.'}
if(-not $m.Contains('expectedOfficialAlembicHead')){throw 'FIX11 : fallback officiel supprimé.'}
if(-not $c.Contains('SetEnvironmentVariable(''CRODIP_TARGET_ALEMBIC_LOCAL'',$previousTargetLocal,''Process'')')){throw 'FIX11 : restauration scope LOCAL absente.'}
if(-not $c.Contains('SetEnvironmentVariable(''CRODIP_TARGET_ALEMBIC_CENTRAL'',$previousTargetCentral,''Process'')')){throw 'FIX11 : restauration scope CENTRAL absente.'}
if(-not $c.Contains("Write-CrodipWarning 'STEP3E/STEP3B : échec après modification DB - rollback atomique obligatoire vers la source.'")){throw 'FIX11 : rollback atomique source absent.'}
Write-Host '[OK] RC41 STEP3E FIX11 - contexte Alembic lie au snapshot cible qualifie pendant le redeploiement ; garde-fou release=image=database et rollback source conserves.' -ForegroundColor Green
