#Requires -Version 7.4
$root=Split-Path -Parent $PSScriptRoot
$c=Get-Content (Join-Path $root 'config\runtime.json') -Raw|ConvertFrom-Json
if($c.releaseUpdate.sourceMode -ne 'github-cli-first'){throw 'sourceMode invalide'}
if(-not(Test-Path (Join-Path $root 'modules\Crodip.Runtime.GitHub.psm1'))){throw 'module GitHub absent'}
if(-not(Test-Path (Join-Path $root 'commands\15-github-cli.ps1'))){throw 'commande GitHub absente'}
Write-Host '[OK] RC7 GitHub CLI conforme.'
