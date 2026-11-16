#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$reserved = @('HOME','Host','PID','PSVersionTable','PSScriptRoot','PSCommandPath','MyInvocation','Error','Args','Input','Matches','LastExitCode','PWD','ShellId')
$violations = @()
Get-ChildItem -LiteralPath $root -Recurse -File -Include *.ps1,*.psm1 | ForEach-Object {
    $path = $_.FullName
    $content = Get-Content -LiteralPath $path -Raw
    foreach($name in $reserved){
        if($content -match ('(?im)^\s*\${0}\s*=' -f [regex]::Escape($name))){
            $violations += "${path}: affectation interdite à `$$name"
        }
    }
}
if($violations.Count -gt 0){ $violations | ForEach-Object { Write-Host $_ -ForegroundColor Red }; throw 'Collision avec variable automatique/réservée PowerShell.' }
Write-Host '[OK] Aucune affectation directe aux variables automatiques/réservées contrôlées.' -ForegroundColor Green
