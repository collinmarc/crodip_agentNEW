#Requires -Version 7.4
$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$content = Get-Content -LiteralPath (Join-Path $root "bootstrap-runtime.ps1") -Raw -Encoding UTF8
foreach ($required in @(
  "function Restore-CrodipBootstrapHelpers",
  "Crodip.Runtime.Common.psm1",
  "Crodip.Runtime.Logging.psm1",
  "finally {",
  "Restore-CrodipBootstrapHelpers"
)) { if ($content -notmatch [regex]::Escape($required)) { throw "RC41 FIX4 absent/incomplet : $required" } }
$start=$content.IndexOf("function Invoke-CrodipMenuCommand")
$end=$content.IndexOf("function Show-CrodipInstallationMenu",$start)
if($start -lt 0 -or $end -lt 0){throw "Dispatcher introuvable."}
$d=$content.Substring($start,$end-$start)
if($d -notmatch "(?s)finally\s*\{.*Restore-CrodipBootstrapHelpers.*\}"){throw "Restauration des helpers absente du finally."}
if($d -match "Wait-CrodipUser"){throw "Wait-CrodipUser ne doit pas être appelé par le dispatcher."}
Write-Host "[OK] RC41 STEP2 GUARD FIX4 - scope bootstrap restauré après commande enfant ; retour menu robuste." -ForegroundColor Green
