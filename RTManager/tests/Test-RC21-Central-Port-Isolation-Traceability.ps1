$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$config=Get-Content (Join-Path $root 'config/runtime.json') -Raw | ConvertFrom-Json
if($config.docker.activeLifecycle -ne 'TEST'){ throw 'Lifecycle attendu TEST.' }
if([int]$config.docker.lifecyclePorts.TEST.local.backend -ne 8110){ throw 'LOCAL backend != 8110' }
if([int]$config.docker.lifecyclePorts.TEST.local.frontend -ne 9110){ throw 'LOCAL frontend != 9110' }
if([int]$config.docker.lifecyclePorts.TEST.central.backend -ne 8120){ throw 'CENTRAL backend != 8120' }
if([int]$config.docker.lifecyclePorts.TEST.central.frontend -ne 9120){ throw 'CENTRAL frontend != 9120' }
$script=Get-Content (Join-Path $root 'commands/12-central-runtime.ps1') -Raw
foreach($token in @('Set-CrodipCentralProcessEnvironment','Test-CrodipCentralPortsBeforeStart','Show-CrodipCentralReleaseTraceability','Show-CrodipCentralContainerTraceability','officialImages.central')){ if($script -notmatch [regex]::Escape($token)){ throw "Token absent: $token" } }
Write-Host '[OK] RC21 CENTRAL port isolation / traceability static test.' -ForegroundColor Green
