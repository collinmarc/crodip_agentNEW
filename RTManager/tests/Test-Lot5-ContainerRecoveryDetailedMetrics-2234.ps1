#Requires -Version 7.4
$ErrorActionPreference="Stop"
$Root=Split-Path -Parent $PSScriptRoot
$Docker=Join-Path $Root "modules\Crodip.Runtime.Docker.psm1"
$Perf=Join-Path $Root "modules\Crodip.Runtime.Performance.psm1"
$Check=Join-Path $Root "commands\02-check.ps1"
$Start=Join-Path $Root "commands\03-start.ps1"

foreach($file in @($Docker,$Perf,$Check,$Start)){
 if(-not(Test-Path $file)){throw "Fichier absent : $file"}
}

$d=Get-Content $Docker -Raw
foreach($expected in @(
 "Get-CrodipContainerConflictInfo",
 "Get-CrodipExpectedContainerNames",
 "Resolve-CrodipContainerConflicts",
 "Supprimer les anciens conteneurs CRODIP et poursuivre ? [O/n]",
 "Identifié CRODIP",
 "Ils ne seront pas supprimés automatiquement"
)){
 if($d -notmatch [regex]::Escape($expected)){throw "Recovery absent : $expected"}
}

$c=Get-Content $Check -Raw
if($c -notmatch "HealthCheck"){throw "Métriques HealthCheck absentes."}

$s=Get-Content $Start -Raw
foreach($expected in @(
 "Docker Desktop readiness",
 "Attente stabilisation conteneurs",
 "Lecture état conteneurs"
)){
 if($s -notmatch [regex]::Escape($expected)){throw "Métrique démarrage absente : $expected"}
}

foreach($file in @($Docker,$Perf,$Check,$Start)){
 $tokens=$null;$errors=$null
 [System.Management.Automation.Language.Parser]::ParseFile($file,[ref]$tokens,[ref]$errors)|Out-Null
 if($errors.Count){throw "Parsing $file : $($errors.Message -join ' | ')"}
}

Write-Host "[OK] Container Recovery + Detailed Metrics 2.2.42 validé." -ForegroundColor Green
