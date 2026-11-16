$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$selectPath=Join-Path $root 'commands\17-historical-test-run.ps1'
$select=Get-Content -LiteralPath $selectPath -Raw
$tokens=$null;$errors=$null
[void][System.Management.Automation.Language.Parser]::ParseFile($selectPath,[ref]$tokens,[ref]$errors)
if($errors.Count){throw ('Erreur parser command 17 : '+(($errors|ForEach-Object Message)-join ' | '))}

# FIX8 : command 17 doit posseder sa dependance Windows dans son propre scope.
if(-not $select.Contains("'Crodip.Runtime.Windows.psm1'")){throw 'FIX8 : module Windows absent du scope command 17.'}
$command17Path=Join-Path $root 'commands\17-historical-test-run.ps1'
if(-not(Test-Path -LiteralPath $command17Path)){throw 'FIX8/FIX9 : command 17 introuvable.'}
$command17Text=Get-Content -LiteralPath $command17Path -Raw
if((-not $command17Text.Contains('$runtimeHome=Get-CrodipHome')) -and (-not $command17Text.Contains('$runtimeHome=$script:resolvedCrodipHome'))){throw 'FIX8/FIX9 : chemin CRODIP_HOME transactionnel introuvable.'}

# Le rollback doit restaurer les deux representations de l override AVANT redeploiement source.
$catchMarker="Write-CrodipWarning 'STEP3E/STEP3B : échec après modification DB - rollback atomique obligatoire vers la source.'"
$start=$select.IndexOf($catchMarker)
if($start -lt 0){throw 'FIX8 : rollback atomique introuvable.'}
$restoreCfg=$select.IndexOf('Set-Content -LiteralPath $configPath -Value $originalConfigJson',$start)
$restoreState=$select.IndexOf('$originalOverrideJson){Set-Content -LiteralPath $overrideStatePath',$start)
$redeploy=$select.IndexOf('Sync-And-Redeploy',$restoreCfg)
if($restoreCfg -lt 0 -or $restoreState -lt 0 -or $redeploy -lt 0 -or $restoreCfg -gt $redeploy -or $restoreState -gt $redeploy){
 throw 'FIX8 : restauration config/test-override non garantie avant redeploiement rollback.'
}

# Test reel de scope : importer exactement les dependances de command 17 puis verifier le helper.
$moduleRoot=Join-Path $root 'modules'
foreach($m in @('Crodip.Runtime.Common.psm1','Crodip.Runtime.Windows.psm1','Crodip.Runtime.Logging.psm1','Crodip.Runtime.DockerProvider.psm1','Crodip.Runtime.Docker.psm1','Crodip.Runtime.Compose.psm1','Crodip.Runtime.GitHub.psm1','Crodip.Runtime.ReleaseRollback.psm1')){
 Import-Module (Join-Path $moduleRoot $m) -Force -DisableNameChecking -ErrorAction Stop
}
$cmd=Get-Command Get-CrodipHome -ErrorAction Stop
if($cmd.CommandType -ne 'Function'){throw 'FIX8 : Get-CrodipHome non resolu comme fonction apres imports.'}
$crodipHome=Get-CrodipHome
if([string]::IsNullOrWhiteSpace([string]$crodipHome)){throw 'FIX8 : Get-CrodipHome retourne une valeur vide.'}
Write-Host '[OK] RC41 STEP3E FIX8 - Get-CrodipHome possede par command 17 ; rollback restaure config et test-override avant redeploiement source.' -ForegroundColor Green
