$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$docker = Get-Content (Join-Path $root 'modules\Crodip.Runtime.Docker.psm1') -Raw
$central = Get-Content (Join-Path $root 'commands\12-central-runtime.ps1') -Raw
$bootstrap = Get-Content (Join-Path $root 'bootstrap-runtime.ps1') -Raw
$composeCentral = Get-Content (Join-Path $root 'templates\central\compose.yaml') -Raw

foreach($token in @('Get-CrodipDeploymentMode','Start-CrodipRuntimeAuto','Assert-CrodipRequiredImagesLocal','Mode effectif')) {
    if($docker -notmatch [regex]::Escape($token)){ throw "RC40 connectivité : token absent du moteur Docker : $token" }
}
if($central -notmatch 'Start-CrodipRuntimeAuto\s+-ComposeFile'){ throw 'RC40 connectivité : CENTRAL ne passe pas par Start-CrodipRuntimeAuto.' }
if($composeCentral -notmatch 'postgres:17'){ throw 'RC40 connectivité : image PostgreSQL 17 absente du Compose CENTRAL.' }
if($bootstrap -notmatch 'Connectivité:'){ throw 'RC40 connectivité : mode non affiché dans le menu principal.' }
if($docker -notmatch 'PullPolicy\s+"never"'){ throw 'RC40 connectivité : --pull never absent du mode offline.' }
Write-Host '[OK] RC40 - AUTO/ONLINE/OFFLINE partagé LOCAL/CENTRAL, contrôle images offline inclus.' -ForegroundColor Green
