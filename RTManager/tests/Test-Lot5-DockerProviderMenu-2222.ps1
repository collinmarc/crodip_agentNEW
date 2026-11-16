#Requires -Version 7.4
$ErrorActionPreference="Stop"
$Root=Split-Path -Parent $PSScriptRoot
$p=Join-Path $Root "commands\11-docker-admin.ps1"
$c=Get-Content -LiteralPath $p -Raw

foreach($x in @(
 "1. Installer Docker Desktop",
 "2. Utiliser Docker Desktop",
 "3. Installer / préparer WSL2 + Ubuntu",
 "4. Installer Docker Engine dans Ubuntu / WSL2",
 "5. Utiliser Docker Engine Ubuntu / WSL2",
 "6. État du provider Docker"
)){
 if($c -notmatch [regex]::Escape($x)){throw "Menu absent : $x"}
}

$tokens=$null;$errors=$null
[System.Management.Automation.Language.Parser]::ParseFile($p,[ref]$tokens,[ref]$errors)|Out-Null
if($errors.Count){throw ($errors.Message -join " | ")}
Write-Host "[OK] Menu providers Docker 2.2.42 validé." -ForegroundColor Green
