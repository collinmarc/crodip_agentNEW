#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$c17Path=Join-Path $root 'commands\17-historical-test-run.ps1'
$c17=Get-Content -LiteralPath $c17Path -Raw
$cfg=Get-Content -LiteralPath (Join-Path $root 'config\runtime.json') -Raw | ConvertFrom-Json

if([int]$cfg.docker.lifecyclePorts.TEST.local.backend -ne 8110){throw 'TEST LOCAL backend != 8110'}
if([int]$cfg.docker.lifecyclePorts.TEST.local.frontend -ne 9110){throw 'TEST LOCAL frontend != 9110'}
if([int]$cfg.docker.lifecyclePorts.TEST.central.backend -ne 8120){throw 'TEST CENTRAL backend != 8120'}
if([int]$cfg.docker.lifecyclePorts.TEST.central.frontend -ne 9120){throw 'TEST CENTRAL frontend != 9120'}

foreach($required in @(
  '$resolvedCrodipHome = Get-CrodipHome',
  '$runtimeHome=$script:resolvedCrodipHome',
  "[Environment]::SetEnvironmentVariable('CRODIP_BACKEND_PORT',[string]`$localBackend,'Process')",
  "[Environment]::SetEnvironmentVariable('CRODIP_FRONTEND_PORT',[string]`$localFrontend,'Process')",
  'Set-CrodipRuntimeImageEnvironment -EnvFile $localEnv -Target local',
  'Set-CrodipRuntimeImageEnvironment -EnvFile $centEnv -Target central',
  'Plan de ports non isolé',
  "[Environment]::SetEnvironmentVariable('CRODIP_BACKEND_PORT',`$previousBackendPort,'Process')",
  "[Environment]::SetEnvironmentVariable('CRODIP_FRONTEND_PORT',`$previousFrontendPort,'Process')"
)){
  if(-not $c17.Contains($required)){throw "FIX9 absent : $required"}
}

$tokens=$null; $errors=$null
$ast=[System.Management.Automation.Language.Parser]::ParseFile($c17Path,[ref]$tokens,[ref]$errors)
if($errors.Count -gt 0){throw "Parser errors command 17 : $($errors[0].Message)"}
$func=$ast.Find({
  param($node)
  $node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and
  $node.Name -eq 'Sync-And-Redeploy'
},$true)
if($null -eq $func){throw 'Sync-And-Redeploy introuvable dans AST.'}

$dynamicCalls=$func.Body.FindAll({
  param($node)
  $node -is [System.Management.Automation.Language.CommandAst] -and
  $node.GetCommandName() -eq 'Get-CrodipHome'
},$true)
if($dynamicCalls.Count -ne 0){throw 'Get-CrodipHome reste appelé dynamiquement dans le corps exécutable de Sync-And-Redeploy.'}

Write-Host '[OK] RC41 STEP3E FIX9 - CRODIP_HOME fige avant scripts imbriques ; ports LOCAL/CENTRAL isoles au scope Process ; garde-fou topologique TEST 8110/9110 vs 8120/9120 present.' -ForegroundColor Green
