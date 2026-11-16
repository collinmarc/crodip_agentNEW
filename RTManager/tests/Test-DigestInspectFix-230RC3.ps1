#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$script = Join-Path $root "commands\13-qualify-runtime.ps1"
$content = Get-Content -LiteralPath $script -Raw

if ($content -notmatch [regex]::Escape('docker inspect --format "{{.Config.Image}}"')) {
    throw "Le contrôle digest n'utilise pas docker inspect .Config.Image."
}

if ($content -match [regex]::Escape('($row.Image -eq $ExpectedImage)')) {
    throw "Ancienne comparaison incorrecte docker ps .Image encore présente."
}

Write-Host "[OK] RC3 : contrôle digest basé sur docker inspect .Config.Image."
