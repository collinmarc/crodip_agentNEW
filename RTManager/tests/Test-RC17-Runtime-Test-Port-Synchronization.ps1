#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$config=Get-Content (Join-Path $root 'config/runtime.json') -Raw | ConvertFrom-Json
if($config.docker.activeLifecycle -ne 'TEST'){throw 'RC17 : activeLifecycle doit etre TEST.'}
if($config.docker.lifecyclePorts.TEST.local.backend -ne 8110){throw 'RC17 : backend TEST/LOCAL != 8110.'}
if($config.docker.lifecyclePorts.TEST.local.frontend -ne 9110){throw 'RC17 : frontend TEST/LOCAL != 9110.'}
$common=Get-Content (Join-Path $root 'modules/Crodip.Runtime.Common.psm1') -Raw
foreach($token in @('CRODIP_BACKEND_PORT','CRODIP_FRONTEND_PORT','activeLifecycle','lifecyclePorts')){
 if($common -notmatch [regex]::Escape($token)){throw "RC17 : contrat absent : $token"}
}
$template=Get-Content (Join-Path $root 'templates/.env.example') -Raw
if($template -notmatch 'CRODIP_BACKEND_PORT=8110'){throw 'RC17 : template backend incorrect.'}
if($template -notmatch 'CRODIP_FRONTEND_PORT=9110'){throw 'RC17 : template frontend incorrect.'}
Write-Host '[OK] RC17 Runtime TEST port synchronization contract.'
