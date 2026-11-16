$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$menu=Get-Content (Join-Path $root 'bootstrap-runtime.ps1') -Raw
foreach($x in @('17. Charger un run CI antérieur pour TEST','18. Revenir à la release officielle','19. Quitter')){if(-not $menu.Contains($x)){throw "Menu absent: $x"}}
$cmd=Get-Content (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
foreach($x in @('OVERRIDE-TEST','RESTORE-OFFICIAL','gh run download','testOverride','HISTORICAL_CI_RUN','preserv')){if($cmd -notmatch [regex]::Escape($x)){throw "Contrat RC24 absent: $x"}}
$common=Get-Content (Join-Path $root 'modules\Crodip.Runtime.Common.psm1') -Raw
foreach($x in @('Get-CrodipEffectiveRelease','Get-CrodipEffectiveImageNode')){if($common -notmatch $x){throw "Résolution effective absente: $x"}}
$config=Get-Content (Join-Path $root 'config\runtime.json') -Raw|ConvertFrom-Json
if($config.version -ne '2.3.0-RC24'){throw 'Version incorrecte'}
if([bool]$config.testOverride.active){throw 'Override doit être inactif par défaut'}
Write-Host '[OK] RC24 historical TEST override contract.' -ForegroundColor Green
