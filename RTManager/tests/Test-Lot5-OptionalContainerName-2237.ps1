#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$Module=Join-Path $Root "modules\Crodip.Runtime.Docker.psm1"
$Compose=Join-Path $Root "templates\compose.yaml"

$m=Get-Content -LiteralPath $Module -Raw

if($m -notmatch 'PSObject\.Properties\.Name -contains "container_name"'){
    throw "container_name n'est pas traité comme optionnel."
}

if($m -notmatch 'Aucun container_name fixe : isolation Compose active'){
    throw "Message d'isolation Compose absent."
}

$c=Get-Content -LiteralPath $Compose -Raw

if($c -match '(?m)^\s*container_name:'){
    throw "Le template Runtime contient encore un container_name fixe."
}

$tokens=$null
$errors=$null

[System.Management.Automation.Language.Parser]::ParseFile(
    $Module,
    [ref]$tokens,
    [ref]$errors
) | Out-Null

if($errors.Count){
    throw "Parsing : $($errors.Message -join ' | ')"
}

Write-Host "[OK] Optional container_name Fix 2.2.42 validé." -ForegroundColor Green
