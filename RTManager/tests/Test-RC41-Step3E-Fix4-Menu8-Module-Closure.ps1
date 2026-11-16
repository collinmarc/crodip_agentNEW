$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$moduleRoot=Join-Path $root 'modules'
$mods=@(
 'Crodip.Runtime.Common.psm1',
 'Crodip.Runtime.Logging.psm1',
 'Crodip.Runtime.DockerProvider.psm1',
 'Crodip.Runtime.Docker.psm1',
 'Crodip.Runtime.Compose.psm1',
 'Crodip.Runtime.GitHub.psm1',
 'Crodip.Runtime.ReleaseRollback.psm1'
)
$probe=@'
$ErrorActionPreference="Stop"
$moduleRoot="__MODROOT__"
foreach($m in @("__MODS__")){
 Import-Module (Join-Path $moduleRoot $m) -Force -DisableNameChecking -ErrorAction Stop
}
foreach($fn in @(
 "Get-CrodipRuntimeConfig",
 "Get-CrodipTestOverrideStatePath",
 "Get-CrodipPersistentTestOverride",
 "Find-CrodipReleaseSnapshot",
 "Find-CrodipReconstructedEmptySnapshot"
)){
 if(-not (Get-Command $fn -ErrorAction SilentlyContinue)){throw "Commande menu 8 non resolue apres chargement complet : $fn"}
}
$p=Get-CrodipTestOverrideStatePath
if([string]::IsNullOrWhiteSpace([string]$p)){throw "Chemin override TEST vide."}
'@
$probe=$probe.Replace('__MODROOT__',$moduleRoot.Replace('"','`"'))
$probe=$probe.Replace('__MODS__',($mods -join '","'))
$out=& pwsh.exe -NoProfile -ExecutionPolicy Bypass -Command $probe 2>&1
if($LASTEXITCODE -ne 0){throw ("Fermeture dependances menu 8 invalide : "+($out -join ' | '))}

$rr=Get-Content -LiteralPath (Join-Path $moduleRoot 'Crodip.Runtime.ReleaseRollback.psm1') -Raw
if($rr.Contains('Import-Module $commonModule -Force')){
 throw 'ReleaseRollback recharge encore Common avec -Force.'
}
Write-Host '[OK] RC41 STEP3E FIX4 - ordre reel des modules menu 8 qualifie ; exports Common preserves apres chargement ReleaseRollback.' -ForegroundColor Green
