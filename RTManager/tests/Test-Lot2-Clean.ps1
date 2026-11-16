###############################################################
# CRODIP Runtime Manager
# Test     : tests\Test-Lot2-Clean.ps1
# Version  : 2.2.1
###############################################################

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot

$requiredFiles = @(
    "bootstrap-runtime.ps1",
    "commands\01-install.ps1",
    "commands\01-repair.ps1",
    "commands\01-check-install.ps1",
    "commands\01-reinstall.ps1",
    "commands\10-uninstall.ps1",
    "modules\Crodip.Runtime.Windows.psm1"
)

foreach ($relativePath in $requiredFiles) {
    $path = Join-Path $root $relativePath

    if (-not (Test-Path -LiteralPath $path)) {
        throw "Fichier absent : $relativePath"
    }
}

$bootstrap = Get-Content `
    -LiteralPath (Join-Path $root "bootstrap-runtime.ps1") `
    -Raw

foreach ($label in @(
    "1. Installer",
    "2. Réparer",
    "3. Vérifier l'installation",
    "4. Réinstaller",
    "5. Désinstaller",
    "6. Retour"
)) {
    if ($bootstrap -notmatch [regex]::Escape($label)) {
        throw "Entrée de menu absente : $label"
    }
}

$windowsModule = Get-Content `
    -LiteralPath (
        Join-Path $root "modules\Crodip.Runtime.Windows.psm1"
    ) `
    -Raw

foreach ($functionName in @(
    "Initialize-CrodipDirectories",
    "Set-CrodipEnvironmentVariables",
    "Remove-CrodipEnvironmentVariables",
    "New-CrodipShortcut"
)) {
    if ($windowsModule -notmatch "function\s+$functionName\b") {
        throw "Fonction Windows absente : $functionName"
    }
}

$allPowerShell = Get-ChildItem `
    -LiteralPath $root `
    -Recurse `
    -File |
    Where-Object {
        $_.Extension -in @(".ps1", ".psm1")
    }

foreach ($file in $allPowerShell) {
    $content = Get-Content -LiteralPath $file.FullName -Raw

    if ($content -match "(?im)^\s*\$home\s*=") {
        throw "Affectation interdite à HOME : $($file.FullName)"
    }

    if ($content -match '(?m)^\s*-DisableNameChecking\s*$') {
        $previousLine = (
            $content -split "`r?`n" |
            Select-String `
                -SimpleMatch "-DisableNameChecking" `
                -Context 1, 0
        )

        foreach ($match in $previousLine) {
            if ($match.Context.PreContext -notmatch "^\s*Import-Module") {
                throw "Commutateur orphelin : $($file.FullName)"
            }
        }
    }
}

Write-Host `
    "[OK] Validation statique du Lot 2 propre réussie." `
    -ForegroundColor Green
