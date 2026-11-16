#Requires -Version 7.4
Set-StrictMode -Version Latest
$root=Split-Path -Parent $PSScriptRoot
$script=Get-Content (Join-Path $root 'commands\18-active-run-info.ps1') -Raw
foreach($needle in @('Find-HistoricalReleaseByCommit','RELEASE_HISTORY','RECOVERED_FROM_DOCKER_AND_RELEASE_HISTORY','Etat release','Etat services')){if(-not $script.Contains($needle)){throw "RC31 attendu absent: $needle"}}
Write-Host '[OK] RC31 Docker run reconciliation présent.' -ForegroundColor Green
