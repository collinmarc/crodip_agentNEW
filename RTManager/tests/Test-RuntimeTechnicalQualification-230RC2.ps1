#Requires -Version 7.4
$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$config = Get-Content (Join-Path $root "config\runtime.json") -Raw | ConvertFrom-Json
$script = Join-Path $root "commands\13-qualify-runtime.ps1"

if ($config.version -ne "2.3.0-RC2") { throw "Version RC2 attendue." }
if (-not $config.qualification.enabled) { throw "Qualification non activée." }
if ($config.qualification.statusOnSuccess -ne "RUNTIME TEST TECHNICALLY QUALIFIED") { throw "Statut qualification incorrect." }
if (-not (Test-Path $script)) { throw "Script qualification absent." }

$content = Get-Content $script -Raw
foreach ($needle in @(
    "http://localhost:9110/",
    "http://localhost:8110/health",
    "http://localhost:8110/docs",
    "http://localhost:9120/",
    "http://localhost:8120/health",
    "http://localhost:8120/docs",
    "runtime-qualification.json"
)) {
    if ($content -notmatch [regex]::Escape($needle)) { throw "Contrôle absent : $needle" }
}
Write-Host "[OK] RC2 : qualification technique statiquement conforme."
