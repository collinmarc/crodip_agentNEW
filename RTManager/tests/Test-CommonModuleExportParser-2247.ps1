#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$module = Join-Path $root "modules\Crodip.Runtime.Common.psm1"
$content = Get-Content -LiteralPath $module -Raw

if($content -match ",`n\s*'Set-CrodipRuntimeImageEnvironment'"){
    throw "Séquence littérale backtick-n détectée dans Export-ModuleMember."
}

$tokens = $null
$errors = $null
[System.Management.Automation.Language.Parser]::ParseFile(
    $module,
    [ref]$tokens,
    [ref]$errors
) | Out-Null

if($errors.Count -gt 0){
    throw "Erreur de parsing Common.psm1 : $($errors.Message -join ' | ')"
}

foreach($fn in @(
    "Get-CrodipRuntimeConfig",
    "Get-CrodipRuntimeImageTag",
    "Get-CrodipRuntimeImage",
    "Set-CrodipRuntimeImageEnvironment"
)){
    if($content -notmatch ("'" + [regex]::Escape($fn) + "'")){
        throw "Export absent : $fn"
    }
}

Write-Host "[OK] Crodip.Runtime.Common.psm1 parse correctement et exporte les helpers images."
