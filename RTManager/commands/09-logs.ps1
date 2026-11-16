###############################################################
# CRODIP Runtime Manager
# Script   : commands\09-logs.ps1
# Version  : 2.3.0-RC17
# Statut   : Stable
###############################################################

Import-Module (Join-Path $PSScriptRoot '..\modules\Crodip.Runtime.Common.psm1') -Force -DisableNameChecking
Import-Module (Join-Path $PSScriptRoot '..\modules\Crodip.Runtime.Windows.psm1') -Force -DisableNameChecking
Import-Module (Join-Path $PSScriptRoot '..\modules\Crodip.Runtime.Docker.psm1') -Force -DisableNameChecking
Write-CrodipRuntimeHeader '09-logs.ps1';$f=Get-CrodipComposeFile (Get-CrodipHome);if(-not$f){Write-CrodipError 'compose.yaml absent';return};Push-Location (Split-Path $f -Parent);try{docker compose -f (Split-Path $f -Leaf) logs --tail 200}finally{Pop-Location}
$moduleRoot = Join-Path $PSScriptRoot "..\modules"
Import-Module (Join-Path $moduleRoot "Crodip.Runtime.Compose.psm1") -Force -DisableNameChecking -ErrorAction Stop


