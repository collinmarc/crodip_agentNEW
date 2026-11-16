$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$script=Join-Path $root 'commands\17-historical-test-run.ps1'
$config=Join-Path $root 'config\runtime.json'

$errors=$null;$tokens=$null
[System.Management.Automation.Language.Parser]::ParseFile($script,[ref]$tokens,[ref]$errors)|Out-Null
if(@($errors).Count -gt 0){throw "Parser invalide : $($errors[0].Message)"}

$cfg=Get-Content -LiteralPath $config -Raw|ConvertFrom-Json
if($null -eq $cfg.PSObject.Properties['docker']){throw 'runtime.json : noeud docker absent.'}
if($null -eq $cfg.docker.PSObject.Properties['activeLifecycle']){throw 'runtime.json : docker.activeLifecycle absent.'}
if([string]$cfg.docker.activeLifecycle -ne 'TEST'){throw "Cycle attendu TEST, obtenu '$($cfg.docker.activeLifecycle)'."}

$content=Get-Content -LiteralPath $script -Raw
if(-not $content.Contains("`$cfgForEmpty.docker.activeLifecycle")){throw 'STEP3E ne lit pas docker.activeLifecycle.'}
if($content.Contains("`$cfgForEmpty.runtime.activeLifecycle")){throw 'Acces obsolete cfgForEmpty.runtime.activeLifecycle encore present.'}

# Reproduit dynamiquement la lecture qui a échoué sous StrictMode.
Set-StrictMode -Version Latest
$cfgForEmpty=Get-Content -LiteralPath $config -Raw|ConvertFrom-Json
$isTestLifecycle=([string]$cfgForEmpty.docker.activeLifecycle -eq 'TEST')
if(-not $isTestLifecycle){throw 'Précontrôle STEP3E ne reconnaît pas le cycle TEST.'}

Write-Host '[OK] RC41 STEP3E FIX6 - précontrôle EMPTY lit docker.activeLifecycle sous StrictMode ; cycle TEST reconnu.' -ForegroundColor Green
