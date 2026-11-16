$root=Split-Path -Parent $PSScriptRoot
$menu=Get-Content (Join-Path $root 'bootstrap-runtime.ps1') -Raw
foreach($x in @('17. Charger un run CI antérieur pour TEST','18. Revenir à la release officielle','19. Informations sur le run actif','20. Quitter')){if(-not $menu.Contains($x)){throw "Menu absent: $x"}}
$hist=Get-Content (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
if($hist -notmatch 'if \(\[int\]\$run\.number -ge \[int\]\$cfg\.release\.runNumber\) \{'){throw 'Correctif parser run historique absent.'}
$info=Get-Content (Join-Path $root 'commands\18-active-run-info.ps1') -Raw
foreach($x in @('RELEASE OFFICIELLE','TEST OVERRIDE','RUN EFFECTIF TEST')){if(-not $info.Contains($x)){throw "Bloc info absent: $x"}}
Write-Host '[OK] RC25 historical run + active info static tests'
