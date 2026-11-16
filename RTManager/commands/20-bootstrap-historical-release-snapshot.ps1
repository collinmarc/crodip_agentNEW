[CmdletBinding()]
param(
 [Parameter(Mandatory)][int]$RunNumber,
 [string]$RunId,
 [string]$ApplicationVersion,
 [string]$Commit,
 [string]$LocalBackendImage,
 [string]$CentralBackendImage,
 [string]$ArchivePath
)
$ErrorActionPreference='Stop'
$runtimeRoot=Split-Path -Parent $PSScriptRoot
Import-Module (Join-Path $runtimeRoot 'modules\Crodip.Runtime.Common.psm1') -Force -DisableNameChecking
Import-Module (Join-Path $runtimeRoot 'modules\Crodip.Runtime.GitHub.psm1') -Force -DisableNameChecking
Import-Module (Join-Path $runtimeRoot 'modules\Crodip.Runtime.ReleaseRollback.psm1') -Force -DisableNameChecking

function Get-ImageReference([object]$img){ return ("{0}@{1}" -f [string]$img.repository,[string]$img.digest).ToLowerInvariant() }
function Get-ImagesFromManifest([object]$manifest){
 $map=@{'local-backend'=@('local','backend');'local-frontend'=@('local','frontend');'central-backend'=@('central','backend');'central-frontend'=@('central','frontend')}
 $out=[ordered]@{local=[ordered]@{};central=[ordered]@{}}
 foreach($key in $map.Keys){
   $a=@($manifest.images|Where-Object{[string]$_.key -eq $key})
   if($a.Count -ne 1){throw "Manifest : image '$key' absente/non unique."}
   if([string]$a[0].digest -notmatch '^sha256:[0-9a-fA-F]{64}$'){throw "Digest invalide pour $key"}
   $p=$map[$key]; $out[$p[0]][$p[1]]=[ordered]@{repository=[string]$a[0].repository;digest=([string]$a[0].digest).ToLowerInvariant();reference=(Get-ImageReference $a[0])}
 }
 return $out
}
function Resolve-CrodipHistoricalRelease([int]$Number){
 if(-not(Test-CrodipGitHubCli)){throw 'GitHub CLI absent. Utiliser le menu GitHub CLI / Authentification.'}
 if(-not(Test-CrodipGitHubAuthentication)){throw 'GitHub CLI non authentifié. Utiliser le menu GitHub CLI / Authentification.'}
 $cfg=Get-CrodipRuntimeConfig; $repo=[string]$cfg.releaseUpdate.githubRepository; $gh=Get-CrodipGitHubCliExecutable
 Write-Host ("==> Résolution automatique du Build #{0}" -f $Number) -ForegroundColor Cyan
 $raw=& $gh run list --repo $repo --workflow 'CRODIP Official Build' --status success --limit 100 --json 'databaseId,number,headSha,createdAt' 2>$null
 if($LASTEXITCODE-ne 0){throw 'Impossible de lister les runs GitHub Actions.'}
 $matches=@(($raw|ConvertFrom-Json)|Where-Object{[int]$_.number -eq $Number})
 if($matches.Count-ne 1){throw "Build #$Number absent ou non unique parmi les CRODIP Official Build réussis."}
 $run=$matches[0]

 # FIX3 : workspace jetable. Un téléchargement STEP3C incomplet d'un essai précédent
 # ne doit jamais influencer la résolution suivante.
 $dest=Join-Path ([string]$cfg.releaseUpdate.historyRoot) ("snapshot-bootstrap-run-{0}-{1}" -f $run.number,$run.databaseId)
 if(Test-Path $dest){Remove-Item $dest -Recurse -Force}
 New-Item -ItemType Directory -Force -Path $dest|Out-Null

 $artifactRaw=& $gh api ("repos/{0}/actions/runs/{1}/artifacts?per_page=100" -f $repo,$run.databaseId) 2>$null
 if($LASTEXITCODE-ne 0){throw 'Impossible de lister les artefacts du run.'}
 $artifactPages=@($artifactRaw|ConvertFrom-Json)
 $arts=@()
 foreach($page in $artifactPages){
   if($null-ne $page -and $page.PSObject.Properties.Name -contains 'artifacts'){$arts+=@($page.artifacts)}
 }
 if($arts.Count-eq 0){throw ("Aucun artefact disponible pour le Build #{0}." -f $Number)}
 $safe=@($arts|Where-Object{
   (-not ($_.PSObject.Properties.Name -contains 'expired') -or -not [bool]$_.expired) -and
   [string]$_.name -notmatch '(?i)\.dockerbuild$' -and
   [string]$_.name -notmatch '(?i)dockerbuild'
 })
 if($safe.Count-eq 0){throw 'Aucun artefact de release exploitable : seuls des artefacts Docker BuildKit sont disponibles.'}
 Write-Host 'Artefacts exploitables :' -ForegroundColor DarkCyan
 $safe|ForEach-Object{Write-Host ("  - {0}" -f $_.name)}
 $ordered=@($safe|Sort-Object @{Expression={
   $n=[string]$_.name
   if($n-match'(?i)manifest'){0}elseif($n-match'(?i)official|release'){1}elseif($n-match'(?i)metadata|trace'){2}else{3}
 }},@{Expression={[string]$_.name}})

 $manifest=$null;$manifestPath=$null;$downloadErrors=@()
 foreach($a in $ordered){
   $name=[string]$a.name
   $ad=Join-Path $dest ([IO.Path]::GetFileName($name))
   if(Test-Path $ad){Remove-Item $ad -Recurse -Force}
   New-Item -ItemType Directory -Force -Path $ad|Out-Null
   Write-Host ("==> Téléchargement sélectif : {0}" -f $name) -ForegroundColor Cyan
   & $gh run download ([string]$run.databaseId) --repo $repo --name $name --dir $ad *> $null
   if($LASTEXITCODE-ne 0){$downloadErrors+=$name;Write-Host ("[ATTENTION] Artefact ignoré après échec de téléchargement : {0}" -f $name) -ForegroundColor Yellow;continue}
   foreach($f in @(Get-ChildItem $ad -Recurse -File -Filter manifest.json -ErrorAction SilentlyContinue)){
     try{$m=Get-Content $f.FullName -Raw|ConvertFrom-Json}catch{continue}
     $props=@($m.PSObject.Properties.Name)
     if($props -contains 'images' -and $props -contains 'applicationVersion' -and $props -contains 'gitCommit' -and [string]$m.gitCommit -eq [string]$run.headSha){
       try{$null=Get-ImagesFromManifest $m}catch{continue}
       $manifest=$m;$manifestPath=$f.FullName;break
     }
   }
   if($null-ne $manifest){break}
 }
 if($null-eq $manifest){
   $available=($safe|ForEach-Object{[string]$_.name})-join ', '
   $failed=if($downloadErrors.Count){' Téléchargements en échec : '+($downloadErrors-join ', ')+'.'}else{''}
   throw ("Manifest officiel correspondant au Build #$Number introuvable. Artefacts examinés : $available.$failed")
 }
 $images=Get-ImagesFromManifest $manifest
 return [pscustomobject]@{RunNumber=[int]$run.number;RunId=[string]$run.databaseId;ApplicationVersion=[string]$manifest.applicationVersion;Commit=[string]$run.headSha;ManifestPath=$manifestPath;Images=$images}
}
# FIX1 : RunNumber est l'interface opérateur normale. Les autres paramètres restent
# acceptés uniquement pour compatibilité/diagnostic et doivent être cohérents avec le manifest.
$resolved=Resolve-CrodipHistoricalRelease -Number $RunNumber
foreach($pair in @(@('RunId',$RunId,$resolved.RunId),@('ApplicationVersion',$ApplicationVersion,$resolved.ApplicationVersion),@('Commit',$Commit,$resolved.Commit),@('LocalBackendImage',$LocalBackendImage,$resolved.Images.local.backend.reference),@('CentralBackendImage',$CentralBackendImage,$resolved.Images.central.backend.reference))){
 if(-not [string]::IsNullOrWhiteSpace([string]$pair[1]) -and [string]$pair[1] -ne [string]$pair[2]){throw ("Paramètre {0} incohérent avec le manifest du Build #{1}." -f $pair[0],$RunNumber)}
}
$RunId=$resolved.RunId;$ApplicationVersion=$resolved.ApplicationVersion;$Commit=$resolved.Commit
$LocalBackendImage=$resolved.Images.local.backend.reference;$CentralBackendImage=$resolved.Images.central.backend.reference
$images=$resolved.Images
Write-Host '============================================================' -ForegroundColor Cyan
Write-Host ' RC41 STEP3C FIX3 - HISTORICAL RELEASE SNAPSHOT BOOTSTRAP' -ForegroundColor Cyan
Write-Host '============================================================' -ForegroundColor Cyan
Write-Host ("Release cible : #{0} / {1}" -f $RunNumber,$ApplicationVersion)
Write-Host ("Run ID        : {0}" -f $RunId)
Write-Host ("Commit        : {0}" -f $Commit)
Write-Host ("Manifest      : {0}" -f $resolved.ManifestPath)
Write-Host ("LOCAL backend : {0}" -f $images.local.backend.reference)
Write-Host ("CENTRAL backend: {0}" -f $images.central.backend.reference)
Write-Host '[INFO] Cette opération ne modifie ni SQLite LOCAL ni PostgreSQL CENTRAL actifs.' -ForegroundColor Yellow
if(-not $ArchivePath){
 Write-Host '';Write-Host '==> Recherche de sauvegardes historiques authentiques' -ForegroundColor Cyan
 $found=@(Find-CrodipHistoricalBackupCandidate -RunNumber $RunNumber -RunId $RunId -TargetImages $images)
 $valid=@($found|Where-Object Valid)
 if($valid.Count -eq 0){
   Write-Host ("[ERREUR] Aucun backup historique qualifiable trouvé pour le run #{0} / {1}." -f $RunNumber,$RunId) -ForegroundColor Red
   Write-Host '[INFO] STEP3C refuse de fabriquer un snapshot à partir des bases de la release courante.' -ForegroundColor Yellow
   exit 2
 }
 $ArchivePath=[string]$valid[0].Archive
 Write-Host ("[OK] Backup historique candidat : {0}" -f $ArchivePath) -ForegroundColor Green
}
Write-Host '';Write-Host '==> Qualification et enregistrement du snapshot historique' -ForegroundColor Cyan
$s=Register-CrodipHistoricalReleaseSnapshot -ArchivePath $ArchivePath -RunNumber $RunNumber -RunId $RunId -ApplicationVersion $ApplicationVersion -Commit $Commit -TargetImages $images
Write-Host '[OK] Snapshot historique qualifié et enregistré.' -ForegroundColor Green
Write-Host ("Archive : {0}" -f $s.archive)
Write-Host ("LOCAL Alembic   : {0}" -f $s.qualification.localAlembic)
Write-Host ("CENTRAL Alembic : {0}" -f $s.qualification.centralAlembic)
Write-Host 'Bases actives modifiées : NON'
