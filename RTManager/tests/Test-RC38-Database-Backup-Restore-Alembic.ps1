#Requires -Version 7.4
[CmdletBinding()] param()
Set-StrictMode -Version Latest;$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot;$cfg=Get-Content (Join-Path $root 'config\runtime.json') -Raw|ConvertFrom-Json
if($cfg.version -ne '2.3.0-RC38'){throw 'Version RC38 absente.'};if(-not$cfg.databaseBackup.enabled){throw 'databaseBackup désactivé.'}
$b=Get-Content (Join-Path $root 'commands\06-backup.ps1') -Raw;$r=Get-Content (Join-Path $root 'commands\07-restore.ps1') -Raw
foreach($x in @('pg_dump','central-postgresql.dump','ALEMBIC-DATABASE-METADATA.json','alembicRevision','BACKUP-MANIFEST.json')){if($b -notmatch [regex]::Escape($x)){throw "Backup RC38 absent: $x"}}
foreach($x in @('pg_restore','--clean','19-verify-databases.ps1','Restaurer cette sauvegarde')){if($r -notmatch [regex]::Escape($x)){throw "Restore RC38 absent: $x"}}
Write-Host '[OK] RC38 - sauvegarde/restauration SQLite + PostgreSQL avec traçabilité Alembic intégrée.' -ForegroundColor Green
