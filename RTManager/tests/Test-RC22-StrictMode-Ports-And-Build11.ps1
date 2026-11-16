$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$config = Get-Content (Join-Path $root 'config/runtime.json') -Raw | ConvertFrom-Json
if($config.application.version -ne '2.3.0-dev.2'){ throw 'Version application incorrecte.' }
if([int]$config.release.runNumber -ne 11){ throw 'Build officiel incorrect.' }
if($config.release.commit -ne '43d080b1b39c23dced5be6183840a5c944bccae3'){ throw 'Commit officiel incorrect.' }
if([int]$config.docker.lifecyclePorts.TEST.local.backend -ne 8110 -or [int]$config.docker.lifecyclePorts.TEST.local.frontend -ne 9110){ throw 'Ports TEST LOCAL incorrects.' }
if([int]$config.docker.lifecyclePorts.TEST.central.backend -ne 8120 -or [int]$config.docker.lifecyclePorts.TEST.central.frontend -ne 9120){ throw 'Ports TEST CENTRAL incorrects.' }
$module = Get-Content (Join-Path $root 'modules/Crodip.Runtime.Compose.psm1') -Raw
if($module -match '\$svc\.ports' -or $module -match '\$prop\.Value\.ports'){ throw 'Accès StrictMode non protégé à .ports encore présent.' }
Write-Host '[OK] RC22 StrictMode ports + Build #11.'
