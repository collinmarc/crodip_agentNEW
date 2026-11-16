#Requires -Version 7.4
[CmdletBinding()] param()
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$cfg=Get-Content (Join-Path $root 'config\runtime.json') -Raw|ConvertFrom-Json
$db=Get-Content (Join-Path $root 'commands\19-verify-databases.ps1') -Raw
$menu=Get-Content (Join-Path $root 'bootstrap-runtime.ps1') -Raw
$q=Get-Content (Join-Path $root 'commands\13-qualify-runtime.ps1') -Raw
if($cfg.version -ne '2.3.0-RC35'){throw 'Version RC35 absente.'}
if($cfg.databaseVerification.local.expectedOfficialAlembicHead -ne 'ecd67252fd57'){throw 'Head LOCAL incorrect.'}
if($cfg.databaseVerification.central.expectedOfficialAlembicHead -ne '7544a84c3691'){throw 'Head CENTRAL incorrect.'}
foreach($x in @('sqlite3.connect','SELECT 1','pg_isready','alembic_version','/health/db')){if($db -notmatch [regex]::Escape($x)){throw "Contrôle DB absent: $x"}}
if($menu -notmatch 'Vérifier SQLite LOCAL \+ PostgreSQL CENTRAL'){throw 'Menu DB absent.'}
if(($q|Select-String -Pattern '/health/db' -AllMatches).Matches.Count -lt 2){throw 'Qualification /health/db incomplète.'}
Write-Host '[OK] RC35 - vérification SQLite/PostgreSQL intégrée.' -ForegroundColor Green
