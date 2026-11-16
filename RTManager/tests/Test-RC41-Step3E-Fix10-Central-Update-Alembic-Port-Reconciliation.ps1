#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$central=Get-Content -LiteralPath (Join-Path $root 'commands\12-central-runtime.ps1') -Raw
$migration=Get-Content -LiteralPath (Join-Path $root 'modules\Crodip.Runtime.DatabaseMigration.psm1') -Raw
foreach($needle in @(
  'Réconciliation des publications de ports CENTRAL',
  'Repair-CrodipRuntimePublishedPortBindings -ComposeFile (Get-CrodipCentralComposeFile)',
  'Contrôle effectif des ports publiés CENTRAL',
  'Test-CrodipRuntimePublishedPortBindings -ComposeFile (Get-CrodipCentralComposeFile)',
  'Contrôle des ports Docker CENTRAL échoué après mise à jour.'
)){if(-not $central.Contains($needle)){throw "FIX10 CENTRAL absent : $needle"}}
if(-not $migration.Contains('[AllowEmptyString()][string]$Current')){throw 'FIX10 migration : Current ne tolère pas la valeur vide pour rapport FAIL.'}
if(-not $migration.Contains("ForEach-Object { ([string]`$_).Trim() }")){throw 'FIX10 migration : normalisation Trim sortie Alembic absente.'}
Write-Host '[OK] RC41 STEP3E FIX10 - update CENTRAL reconcilie et controle 8120/9120 ; lecture Alembic robuste ; rapport FAIL accepte Current vide.' -ForegroundColor Green
