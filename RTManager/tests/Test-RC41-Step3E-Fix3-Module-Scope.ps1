$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$common=Join-Path $root 'modules\Crodip.Runtime.Common.psm1'
$rollback=Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1'

foreach($p in @($common,$rollback)){
 $errors=$null;$tokens=$null
 [System.Management.Automation.Language.Parser]::ParseFile($p,[ref]$tokens,[ref]$errors)|Out-Null
 if(@($errors).Count -gt 0){throw "Parser PowerShell invalide : $p :: $($errors[0].Message)"}
}

# Reproduit le contexte problématique : ReleaseRollback chargé seul dans un pwsh propre.
$probe=@'
$ErrorActionPreference="Stop"
Import-Module "__ROLLBACK__" -Force -DisableNameChecking
$m=Get-Module Crodip.Runtime.ReleaseRollback
if(-not $m){throw "Module ReleaseRollback non charge."}
$resolved=& $m {
 @(
  "Get-CrodipRuntimeConfig",
  "Get-CrodipPersistentTestOverride"
 ) | ForEach-Object {
  if(-not (Get-Command $_ -ErrorAction SilentlyContinue)){throw "Dependance module introuvable dans le scope ReleaseRollback : $_"}
 }
 $true
}
if(-not $resolved){throw "Resolution des dependances Common en echec."}
'@
$probe=$probe.Replace('__ROLLBACK__',$rollback.Replace("'","''"))
$out=& pwsh.exe -NoProfile -ExecutionPolicy Bypass -Command $probe 2>&1
if($LASTEXITCODE -ne 0){throw ("Scope module STEP3E invalide : "+($out -join ' | '))}

$rollbackText=Get-Content -LiteralPath $rollback -Raw
if(-not $rollbackText.Contains("Import-Module `$commonModule -DisableNameChecking -ErrorAction Stop")){
 throw 'Import conditionnel du module Common absent de ReleaseRollback.'
}
if($rollbackText.Contains("Import-Module `$commonModule -Force")){
 throw 'ReleaseRollback ne doit pas recharger Common avec -Force.'
}
if(-not $rollbackText.Contains("release-snapshot-reconstructed.json")){
 throw 'Metadata reconstructed STEP3E absent.'
}
if(-not $rollbackText.Contains("release-snapshot.json")){
 throw 'Metadata authentique STEP3B absent.'
}

Write-Host '[OK] RC41 STEP3E FIX3 - dependances Common resolues dans le scope ReleaseRollback ; chemins STEP3B/STEP3E conserves.' -ForegroundColor Green
