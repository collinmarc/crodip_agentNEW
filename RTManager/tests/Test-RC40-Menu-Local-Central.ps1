$ErrorActionPreference = "Stop"
$root = Split-Path $PSScriptRoot -Parent
$bootstrap = Get-Content (Join-Path $root "bootstrap-runtime.ps1") -Raw
$required = @(
    "1. Runtime LOCAL",
    "2. Runtime CENTRAL",
    "3. Sauvegarder",
    "4. Restaurer",
    "5. Vérifier les bases de données",
    "6. Qualification technique Runtime",
    "17. Quitter",
    "function Show-CrodipLocalRuntimeMenu",
    'commands\12-central-runtime.ps1'
)
foreach($item in $required){
    if($bootstrap -notmatch [regex]::Escape($item)){ throw "Élément menu RC40 absent : $item" }
}
if($bootstrap -match 'Runtime CENTRAL \(simulation\)'){ throw "Libellé CENTRAL simulation encore présent." }
Write-Host "[OK] RC40 - menu principal LOCAL/CENTRAL restructuré." -ForegroundColor Green
