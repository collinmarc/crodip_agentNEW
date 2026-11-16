$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$start=Get-Content (Join-Path $root 'commands/03-start.ps1') -Raw
$compose=Get-Content (Join-Path $root 'modules/Crodip.Runtime.Compose.psm1') -Raw
$docker=Get-Content (Join-Path $root 'modules/Crodip.Runtime.Docker.psm1') -Raw
foreach($token in @('$env:CRODIP_BACKEND_PORT','$env:CRODIP_FRONTEND_PORT','activeLifecycle','lifecyclePorts')){if($start -notmatch [regex]::Escape($token)){throw "RC18 absent: $token"}}
if($compose -notmatch 'ForceRecreate'){throw 'RC18 : ForceRecreate absent du module Compose.'}
if($compose -notmatch '\-\-force-recreate'){throw 'RC18 : --force-recreate absent.'}
if($docker -notmatch '\-ForceRecreate'){throw 'RC18 : Start-CrodipRuntimeAuto ne demande pas la recréation.'}
Write-Host '[OK] RC18 TEST port process override + container recreate.'
