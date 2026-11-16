#Requires -Version 7.4
$ErrorActionPreference='Stop';$root=Split-Path -Parent $PSScriptRoot
$checks=@(
 @{p='modules\Crodip.Runtime.ReleaseRollback.psm1';rx='Invoke-CrodipReleaseChangePreflight'},
 @{p='modules\Crodip.Runtime.ReleaseRollback.psm1';rx='Get-CrodipReleaseChangeDirection'},
 @{p='modules\Crodip.Runtime.ReleaseRollback.psm1';rx='DOWNGRADE BLOQUÉ'},
 @{p='modules\Crodip.Runtime.ReleaseRollback.psm1';rx='Get-CrodipImageAlembicHead'},
 @{p='commands\17-historical-test-run.ps1';rx='Invoke-CrodipReleaseChangePreflight'},
 @{p='commands\17-historical-test-run.ps1';rx='DOWNGRADE qualifié mais restauration DB non encore activée'},
 @{p='config\runtime.json';rx='DOWN_PREFLIGHT'}
)
foreach($c in $checks){$f=Join-Path $root $c.p;if(-not(Test-Path $f)){throw "Absent: $($c.p)"};if((Get-Content $f -Raw)-notmatch $c.rx){throw "Contrat absent: $($c.p) / $($c.rx)"}}
Import-Module (Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1') -Force -DisableNameChecking
if((Get-CrodipReleaseChangeDirection -CurrentRun 15 -TargetRun 14) -ne 'DOWNGRADE'){throw 'Direction DOWNGRADE invalide.'}
if((Get-CrodipReleaseChangeDirection -CurrentRun 15 -TargetRun 16) -ne 'UPGRADE'){throw 'Direction UPGRADE invalide.'}
if((Get-CrodipReleaseChangeDirection -CurrentRun 15 -TargetRun 15) -ne 'SAME'){throw 'Direction SAME invalide.'}
Write-Host '[OK] RC41 étape 2 - transaction release + précontrôle DOWN intégrés.' -ForegroundColor Green
