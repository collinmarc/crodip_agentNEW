$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$version = (Get-Content -LiteralPath (Join-Path $root "VERSION") -Raw).Trim()
$status  = (Get-Content -LiteralPath (Join-Path $root "STATUS") -Raw).Trim()
$config  = Get-Content -LiteralPath (Join-Path $root "config\runtime.json") -Raw | ConvertFrom-Json
$images  = Get-Content -LiteralPath (Join-Path $root "images\images-manifest.json") -Raw | ConvertFrom-Json
$update  = Get-Content -LiteralPath (Join-Path $root "commands\08-update.ps1") -Raw
if($version -ne "2.2.45"){ throw "VERSION incohérente : $version" }
if($status -ne "Stable - DEV Runtime Coherence Fix"){ throw "STATUS incohérent : $status" }
if($config.version -ne "2.2.45"){ throw "runtime.json incohérent." }
if($images.version -ne "2.2.45"){ throw "images-manifest.json incohérent." }
if($config.docker.projectName -ne "crodip-runtime-local"){ throw "Projet Compose Runtime LOCAL incohérent." }
if($config.docker.topology.local.composeProject -ne "crodip-runtime-local"){ throw "Topologie LOCAL incohérente." }
if($config.docker.topology.central.composeProject -ne "crodip-central"){ throw "Topologie CENTRAL incohérente." }
$pullCalls=[regex]::Matches($update,'-Action\s+"pull"').Count
if($pullCalls -ne 1){ throw "08-update.ps1 doit contenir un seul site de pull Compose service par service. Trouvé : $pullCalls" }
if($update -match 'requiredImages\s*=\s*@\('){ throw "Bloc requiredImages codé en dur encore présent." }
if($update -match 'ghcr\.io/idwebconcept/crodip-local-backend:2\.2\.1' -or $update -match 'ghcr\.io/idwebconcept/crodip-local-frontend:2\.2\.1'){ throw "Images codées en dur encore présentes dans le workflow d'update." }
$compose=Get-Content -LiteralPath (Join-Path $root "templates\compose.yaml") -Raw
if($compose -notmatch 'DATABASE_URL:\s+sqlite:////app/runtime/sqlite/crodip\.db'){ throw "Runtime LOCAL SQLite non conservé." }
Write-Host "[OK] Cohérence DEV / Runtime v2.2.45 validée."
