#Requires -Version 7.4
$ErrorActionPreference="Stop"

$Root=Split-Path -Parent $PSScriptRoot
$Logs=Join-Path $Root "commands\09-logs.ps1"

$s=Get-Content -LiteralPath $Logs -Raw

if($s -match "Find-CrodipComposeFile"){
    throw "Ancien resolver Compose encore présent."
}

if($s -notmatch "Get-CrodipComposeFile"){
    throw "Nouveau resolver Compose absent."
}

if($s -notmatch "Crodip.Runtime.Compose.psm1"){
    throw "Module Compose non importé."
}

Write-Host "[OK] Logs Compose Resolver Fix 2.2.42 validé." -ForegroundColor Green
