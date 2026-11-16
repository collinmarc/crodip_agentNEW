$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$p=Join-Path $root 'commands\21-reconstruct-historical-release-snapshot.ps1'
if(-not(Test-Path $p)){throw '[ECHEC] commande STEP3D absente'}
$s=Get-Content $p -Raw
$checks=@(
 @('RunNumber interface','[Parameter(Mandatory)][int]$RunNumber'),
 @('réutilisation STEP3C','20-bootstrap-historical-release-snapshot.ps1'),
 @('SQLite isolée','DATABASE_URL=sqlite:////app/runtime/sqlite/crodip.db'),
 @('PostgreSQL temporaire','postgres:17'),
 @('réseau isolé','network','create'),
 @('Alembic LOCAL','/app/local/alembic.ini upgrade head'),
 @('Alembic CENTRAL','/app/central/alembic.ini upgrade head'),
 @('dump CENTRAL','pg_dump'),
 @('origine reconstructed',"origin='reconstructed'"),
 @('état EMPTY',"dataState='EMPTY'"),
 @('pas auto-restorable','RECONSTRUCTED_READY_NOT_AUTO_RESTORABLE'),
 @('nettoyage conteneur','docker rm -f'),
 @('nettoyage réseau','docker network rm')
)
foreach($c in $checks){if($s -notmatch [regex]::Escape([string]$c[1])){throw ("[ECHEC] STEP3D absent : {0}" -f $c[0])}}
$step3b=Get-Content (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
if($step3b -match 'release-snapshot-reconstructed\.json'){throw '[ECHEC] STEP3B consomme déjà automatiquement les snapshots reconstruits.'}
Write-Host '[OK] RC41 STEP3D - reconstruction isolée structurée : SQLite/PostgreSQL temporaires, Alembic cible, snapshot EMPTY qualifié, aucune activation automatique DOWN.' -ForegroundColor Green
