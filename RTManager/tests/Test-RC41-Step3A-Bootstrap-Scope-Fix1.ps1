#Requires -Version 7.4
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$dockerModule = Join-Path $root 'modules\Crodip.Runtime.Docker.psm1'
$text = Get-Content -LiteralPath $dockerModule -Raw
$errors = @()

# Interdit toute référence aux helpers de chemins du module Windows dans Docker.
$forbiddenHome = 'Get-Crodip' + 'Home'
$forbiddenData = 'Get-Crodip' + 'DataRoot'
if ($text.Contains($forbiddenHome)) { $errors += 'référence interdite au helper Home encore présente dans module Docker' }
if ($text.Contains($forbiddenData)) { $errors += 'référence interdite au helper DataRoot encore présente dans module Docker' }

# Le module Docker doit fonctionner dans une session où Windows.psm1 n'est PAS importé.
Remove-Module Crodip.Runtime.Docker -Force -ErrorAction SilentlyContinue
Remove-Module Crodip.Runtime.Windows -Force -ErrorAction SilentlyContinue
Import-Module $dockerModule -Force -DisableNameChecking -ErrorAction Stop
try {
    $mode = Get-CrodipDeploymentMode
    if ([string]::IsNullOrWhiteSpace($mode)) { $errors += 'Get-CrodipDeploymentMode retourne une valeur vide' }
    if ($mode -notin @('auto','online','offline')) { $errors += "mode de déploiement inattendu : $mode" }
} catch {
    $errors += "Get-CrodipDeploymentMode échoue en import Docker seul : $($_.Exception.Message)"
}

# Vérifie que les résolveurs internes existent réellement dans le module source.
if ($text -notmatch 'function\s+Get-CrodipDockerRuntimeHome') { $errors += 'résolveur RuntimeHome Docker absent' }
if ($text -notmatch 'function\s+Get-CrodipDockerDataRoot') { $errors += 'résolveur DataRoot Docker absent' }

if ($errors.Count) {
    $errors | ForEach-Object { Write-Host "[ECHEC] $_" -ForegroundColor Red }
    exit 1
}
Write-Host '[OK] RC41 STEP3A FIX1/FIX2 compatible - module Docker autonome vérifié en session isolée ; politique de connectivité résolue sans module Windows.' -ForegroundColor Green
