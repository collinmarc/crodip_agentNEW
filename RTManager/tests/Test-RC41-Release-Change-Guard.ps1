$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$f=Join-Path $root 'commands\17-historical-test-run.ps1'
if(-not(Test-Path $f)){throw 'commands\\17-historical-test-run.ps1 absent.'}
$s=Get-Content $f -Raw
$pre=$s.IndexOf('Invoke-CrodipReleaseChangePreflight')
$prompt=$s.IndexOf("Read-Host 'Saisir SWITCH-RUNTIME")
if($pre -lt 0){throw 'Appel préflight RC41 absent.'}
if($prompt -lt 0){throw 'Invite SWITCH-RUNTIME absente.'}
if($pre -gt $prompt){throw 'Garde-fou incorrect : SWITCH-RUNTIME est proposé avant le préflight RC41.'}
$down=$s.IndexOf("if(`$releasePreflight.Direction -eq 'DOWNGRADE')")
if($down -lt $pre -or $down -gt $prompt){throw 'Le blocage DOWNGRADE doit être situé entre préflight et SWITCH-RUNTIME.'}
if($s -notmatch 'Aucune modification de release ne sera effectuée'){throw 'Message de sécurité DOWNGRADE absent.'}
Write-Host '[OK] RC41 - garde-fou DOWN exécuté avant SWITCH-RUNTIME.' -ForegroundColor Green
