#Requires -Version 7.4
$ErrorActionPreference='Stop';$root=Split-Path -Parent $PSScriptRoot
$checks=@(
 @{p='VERSION';rx='2\.3\.0-RC41'},
 @{p='STATUS';rx='Transactional Release Rollback'},
 @{p='modules\Crodip.Runtime.ReleaseRollback.psm1';rx='New-CrodipReleaseSnapshot'},
 @{p='modules\Crodip.Runtime.ReleaseRollback.psm1';rx='Find-CrodipReleaseSnapshot'},
 @{p='commands\06-backup.ps1';rx='pre-release-change'},
 @{p='config\runtime.json';rx='snapshot-restore-on-down'},
 @{p='config\runtime.json';rx='automaticAlembicDowngrade.*false'}
)
foreach($c in $checks){$f=Join-Path $root $c.p;if(-not(Test-Path $f)){throw "Absent: $($c.p)"};if((Get-Content $f -Raw)-notmatch $c.rx){throw "Contrat absent: $($c.p) / $($c.rx)"}}
Write-Host '[OK] RC41 - fondation rollback release + snapshots DB intégrée.' -ForegroundColor Green
