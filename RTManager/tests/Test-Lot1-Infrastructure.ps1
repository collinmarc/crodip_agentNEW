$ErrorActionPreference = 'Stop'
$root=Split-Path -Parent $PSScriptRoot
$required=@(
 'bootstrap-runtime.ps1','config\runtime.json',
 'modules\Crodip.Runtime.Common.psm1','modules\Crodip.Runtime.Windows.psm1',
 'modules\Crodip.Runtime.Logging.psm1','modules\Crodip.Runtime.Docker.psm1'
)
foreach($item in $required){if(-not(Test-Path -LiteralPath (Join-Path $root $item))){throw "Fichier absent : $item"}}
$config=Get-Content -LiteralPath (Join-Path $root 'config\runtime.json') -Raw | ConvertFrom-Json
if($config.version -ne '2.2.1'){throw 'Version de configuration incohérente.'}
foreach($module in Get-ChildItem -LiteralPath (Join-Path $root 'modules') -Filter '*.psm1'){
 if((Get-Content -LiteralPath $module.FullName -Raw) -notmatch 'Export-ModuleMember'){throw "Exports absents : $($module.Name)"}
}
Write-Host '[OK] Validation statique du Lot 1 réussie.' -ForegroundColor Green
