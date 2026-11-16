#Requires -Version 7.4
[CmdletBinding()]
param()
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'

$root=Split-Path -Parent $PSScriptRoot
$cfg=Get-Content (Join-Path $root 'config\runtime.json') -Raw|ConvertFrom-Json
$selector=Get-Content (Join-Path $root 'commands\17-historical-test-run.ps1') -Raw
$bootstrap=Get-Content (Join-Path $root 'bootstrap-runtime.ps1') -Raw

if([string]$cfg.version -ne '2.3.0-RC34'){throw 'Version Runtime incorrecte.'}
if([string]$cfg.compatibility.devKitVersion -ne '6.3.2'){throw 'Kit DEV non aligné.'}
if([int]$cfg.release.runNumber -ne 14){throw 'Build officiel différent de #14.'}
if([string]$cfg.application.version -ne '2.3.0-dev.3'){throw 'Application officielle incorrecte.'}
if(-not [bool]$cfg.releaseSelection.allowPreviousSuccessfulBuild){throw 'Sélection antérieure désactivée.'}
if(-not [bool]$cfg.releaseSelection.allowLaterSuccessfulBuild){throw 'Sélection postérieure désactivée.'}
if($selector -notmatch 'SWITCH-RUNTIME'){throw 'Confirmation SWITCH-RUNTIME absente.'}
if($selector -notmatch "relation='ANTERIEUR'"){throw 'Détection release antérieure absente.'}
if($selector -notmatch "relation='POSTERIEUR'"){throw 'Détection release postérieure absente.'}
if($selector -match 'Numéro de run antérieur à charger'){throw 'Ancien prompt restrictif encore actif.'}
if($bootstrap -notmatch 'build antérieur/postérieur'){throw 'Menu bidirectionnel absent.'}
Write-Host '[OK] RC34 - sélection bidirectionnelle Runtime TEST qualifiée statiquement.' -ForegroundColor Green
