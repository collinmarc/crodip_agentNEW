#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$HealthModule = Join-Path $Root "modules\Crodip.Runtime.Health.psm1"
$CheckScript = Join-Path $Root "commands\02-check.ps1"

$health = Get-Content -LiteralPath $HealthModule -Raw
$check = Get-Content -LiteralPath $CheckScript -Raw

foreach ($expected in @(
    "vmpOperationalByEvidence",
    "HyperVisorPresent=True",
    "WSL2 opérationnel",
    "Docker Engine opérationnel",
    "Virtual Machine Platform opérationnel par preuve d'exécution"
)) {
    if ($health -notmatch [regex]::Escape($expected)) {
        throw "Normalisation VMP absente du module Health : $expected"
    }
}

if ($check -match "Resolve-CrodipVirtualMachinePlatformStatus") {
    throw "Ancienne normalisation tardive encore présente dans 02-check.ps1."
}

if ($check -match "Normalisation Virtual Machine Platform") {
    throw "Bloc de normalisation tardive encore présent dans 02-check.ps1."
}

foreach ($path in @($HealthModule,$CheckScript)) {
    $tokens=$null
    $errors=$null
    [System.Management.Automation.Language.Parser]::ParseFile(
        $path,[ref]$tokens,[ref]$errors
    ) | Out-Null

    if ($errors.Count -gt 0) {
        throw "Erreur parsing $path : $($errors.Message -join ' | ')"
    }
}

Write-Host "[OK] VMP Health Normalization 2.2.42 validée." -ForegroundColor Green
