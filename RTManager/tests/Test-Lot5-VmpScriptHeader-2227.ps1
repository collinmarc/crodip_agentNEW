#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot
$CheckScript = Join-Path $Root "commands\02-check.ps1"

$content = Get-Content -LiteralPath $CheckScript -Raw

$cmdletPos = $content.IndexOf("[CmdletBinding()]")
$paramPos = $content.IndexOf("param(")
$functionPos = $content.IndexOf("function Resolve-CrodipVirtualMachinePlatformStatus")

if ($cmdletPos -lt 0 -or $paramPos -lt 0 -or $functionPos -lt 0) {
    throw "Éléments d'en-tête attendus absents."
}

if ($functionPos -lt $paramPos) {
    throw "La fonction VMP est encore placée avant param(...)."
}

$tokens = $null
$errors = $null
[System.Management.Automation.Language.Parser]::ParseFile(
    $CheckScript,
    [ref]$tokens,
    [ref]$errors
) | Out-Null

if ($errors.Count -gt 0) {
    throw "Erreur de parsing 02-check.ps1 : $($errors.Message -join ' | ')"
}

Write-Host "[OK] Header PowerShell 02-check.ps1 2.2.42 validé." -ForegroundColor Green
