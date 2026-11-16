#Requires -Version 7.4
[CmdletBinding()] param()
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$cfg=Get-Content (Join-Path $root 'config\runtime.json') -Raw|ConvertFrom-Json
$db=Get-Content (Join-Path $root 'commands\19-verify-databases.ps1') -Raw
if($cfg.version -ne '2.3.0-RC36'){throw 'Version RC36 absente.'}
foreach($needle in @(
 'Get-ContainerEnv','DATABASE_URL','Get-SqlitePathFromUrl',
 'mode=ro','NON DEPLOYE','POSTGRES_USER','POSTGRES_DB',
 'd24d83ea9494','3452c4fc44ba',
 'GLOBAL  : PASS (périmètre des topologies déployées)'
)){
 if($db -notmatch [regex]::Escape($needle)){throw "RC36 contrôle absent: $needle"}
}
if($db -match 'p="/app/runtime/sqlite/crodip.db"'){throw 'Ancien chemin SQLite codé en dur encore présent.'}
Write-Host '[OK] RC36 - détection DB dynamique intégrée.' -ForegroundColor Green
