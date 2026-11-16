$ErrorActionPreference='Stop'
$module=Join-Path $PSScriptRoot '..\modules\Crodip.Runtime.Compose.psm1'
Import-Module $module -Force -DisableNameChecking -ErrorAction Stop
foreach($name in @('Repair-CrodipRuntimePublishedPortBindings','Test-CrodipRuntimePublishedPortBindings')){
  $cmd=Get-Command $name -CommandType Function -ErrorAction SilentlyContinue
  if($null -eq $cmd){throw "Fonction non exportée : $name"}
}
Write-Host '[OK] RC20 : fonctions de réconciliation/contrôle des ports exportées et chargeables.'
