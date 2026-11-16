#Requires -Version 7.4
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$update=Get-Content (Join-Path $root "commands\14-update-test-release.ps1") -Raw
$github=Get-Content (Join-Path $root "modules\Crodip.Runtime.GitHub.psm1") -Raw
$install=Get-Content (Join-Path $root "commands\01-install.ps1") -Raw

foreach($needle in @(
 "schemaVersion","officialRunId","officialRunNumber","gitCommit",
 "local-backend","local-frontend","central-backend","central-frontend",
 "explicit-official-run-only","RELEASE READY FOR TEST"
)){
 if($update -notmatch [regex]::Escape($needle)){throw "Schéma officiel RC8 incomplet : $needle"}
}

if($github -match '-f "ref=\$Ref"'){throw "Ancienne requête gh API encore présente."}
if($github -notmatch [regex]::Escape('?ref=$Ref')){throw "Requête GET ?ref= absente."}
if($install -notmatch 'Install-CrodipGitHubCli'){throw "Installation fraîche ne gère pas GitHub CLI."}
if($install -notmatch 'Composants techniques — GitHub CLI'){throw "Section fresh install GitHub CLI absente."}

Write-Host "[OK] RC8 : schéma pin v1 + GET GitHub API + GitHub CLI fresh install."
