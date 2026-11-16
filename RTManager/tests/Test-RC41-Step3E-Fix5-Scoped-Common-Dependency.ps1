$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$moduleRoot=Join-Path $root 'modules'
$probe=@'
$ErrorActionPreference="Stop"
$moduleRoot="__MODROOT__"
foreach($m in @("Crodip.Runtime.Common.psm1","Crodip.Runtime.Logging.psm1","Crodip.Runtime.DockerProvider.psm1","Crodip.Runtime.Docker.psm1","Crodip.Runtime.Compose.psm1","Crodip.Runtime.GitHub.psm1","Crodip.Runtime.ReleaseRollback.psm1")){
 Import-Module (Join-Path $moduleRoot $m) -Force -DisableNameChecking -ErrorAction Stop
}
foreach($fn in @("Get-CrodipRuntimeConfig","Get-CrodipTestOverrideStatePath","Get-CrodipPersistentTestOverride")){
 if(-not(Get-Command $fn -ErrorAction SilentlyContinue)){throw "Export Common perdu dans scope menu: $fn"}
}
$rr=Get-Module Crodip.Runtime.ReleaseRollback
if(-not $rr){throw "ReleaseRollback non charge"}
& $rr {
 foreach($fn in @("Get-CrodipRuntimeConfig","Get-CrodipPersistentTestOverride")){
  if(-not(Get-Command $fn -ErrorAction SilentlyContinue)){throw "Dependance Common absente scope ReleaseRollback: $fn"}
 }
}
$id=Get-CrodipEffectiveReleaseIdentity
if(-not $id -or [int]$id.runNumber -le 0){throw "Identite release non resolue"}
'@
$probe=$probe.Replace('__MODROOT__',$moduleRoot.Replace('"','`"'))
$o=& pwsh.exe -NoProfile -ExecutionPolicy Bypass -Command $probe 2>&1
if($LASTEXITCODE-ne 0){throw ("Qualification double-scope FIX5 en echec: "+($o-join ' | '))}
$t=Get-Content (Join-Path $moduleRoot 'Crodip.Runtime.ReleaseRollback.psm1') -Raw
if(-not $t.Contains('Import-Module $commonModule -DisableNameChecking -ErrorAction Stop')){throw 'Import scoped Common absent'}
if($t.Contains('Import-Module $commonModule -Force')){throw 'Reload force Common interdit'}
Write-Host '[OK] RC41 STEP3E FIX5 - Common disponible scopes menu et ReleaseRollback ; identite release resolue en execution.' -ForegroundColor Green
