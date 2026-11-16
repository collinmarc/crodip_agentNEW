#Requires -Version 7.4
$ErrorActionPreference='Stop'
$root=Split-Path $PSScriptRoot -Parent
$cfg=Get-Content (Join-Path $root 'config\runtime.json') -Raw | ConvertFrom-Json
if($cfg.application.version -ne '2.3.0-dev.4'){throw 'Application RC40 non alignée sur 2.3.0-dev.4.'}
if($cfg.release.runNumber -ne 15){throw 'Official Build #15 attendu.'}
if($cfg.databaseVerification.local.expectedOfficialAlembicHead -ne 'ecd67252fd57'){throw 'Head LOCAL RC40 incorrect.'}
if($cfg.databaseVerification.central.expectedOfficialAlembicHead -ne '7544a84c3691'){throw 'Head CENTRAL RC40 incorrect.'}
if(-not $cfg.databaseMigration.mandatoryPreMigrationBackup){throw 'Backup PRE-MIGRATION obligatoire absent.'}
if($cfg.databaseMigration.restoreOnFailure -ne 'explicit-operator-action-only'){throw 'Politique de restauration RC40 incorrecte.'}
$m=Get-Content (Join-Path $root 'modules\Crodip.Runtime.DatabaseMigration.psm1') -Raw
foreach($s in @('Get-CrodipExpectedAlembicHead','release=image=database','Aucun downgrade ni restauration automatique','migration-history','Sauvegarde PRE-MIGRATION obligatoire','-Purpose ''pre-migration''','Alembic upgrade NON exécuté')){
  if($m -notmatch [regex]::Escape($s)){throw "Contrat RC40 absent : $s"}
}
Write-Host '[OK] RC40 - Safe Database Migration & Release Compatibility intégrée.' -ForegroundColor Green
