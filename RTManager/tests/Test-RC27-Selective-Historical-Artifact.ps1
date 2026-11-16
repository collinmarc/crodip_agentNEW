$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$p=Join-Path $root 'commands\17-historical-test-run.ps1'
$s=Get-Content -LiteralPath $p -Raw
if($s -match 'run download \(\[string\]\$run\.databaseId\) --repo \$repo --dir \$dest'){ throw 'Téléchargement global des artefacts encore présent.' }
foreach($needle in @('actions/runs/{1}/artifacts?per_page=100','\.dockerbuild$','--name $artifactName','manifest.json')){ if($s -notmatch [regex]::Escape($needle) -and $needle -ne '\.dockerbuild$'){ throw "Marqueur RC27 absent: $needle" } }
if($s -notmatch "dockerbuild"){ throw 'Filtrage dockerbuild absent.' }
Write-Host '[OK] RC27 téléchargement sélectif des artefacts.' -ForegroundColor Green
