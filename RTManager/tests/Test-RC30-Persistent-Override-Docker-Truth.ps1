#Requires -Version 7.4
Set-StrictMode -Version Latest
$root=Split-Path -Parent $PSScriptRoot
$common=Get-Content (Join-Path $root 'modules\Crodip.Runtime.Common.psm1') -Raw
$hist=Get-Content (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
$info=Get-Content (Join-Path $root 'commands\18-active-run-info.ps1') -Raw
foreach($x in @('Get-CrodipTestOverrideStatePath','Get-CrodipPersistentTestOverride')){if(-not $common.Contains($x)){throw "Helper absent: $x"}}
if(-not $hist.Contains('Save-OverrideState')){throw 'Persistance override absente'}
if(-not $hist.Contains('Clear-OverrideState')){throw 'Suppression override absente'}
foreach($x in @('RUNTIME REEL - DOCKER','docker inspect','RUN ACTIF TEST')){if(-not $info.Contains($x)){throw "Docker truth absent: $x"}}
Write-Host '[OK] RC30 persistent override + Docker truth.'
