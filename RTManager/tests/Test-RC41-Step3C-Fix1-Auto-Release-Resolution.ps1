$ErrorActionPreference='Stop'
$root=Split-Path $PSScriptRoot -Parent
$c=Join-Path $root 'commands\20-bootstrap-historical-release-snapshot.ps1'
$errors=@()
if(-not(Test-Path $c)){$errors+='commande STEP3C absente'} else {
 $txt=Get-Content $c -Raw
 if($txt -notmatch '\[Parameter\(Mandatory\)\]\[int\]\$RunNumber'){$errors+='RunNumber obligatoire absent'}
 foreach($p in @('RunId','ApplicationVersion','Commit','LocalBackendImage','CentralBackendImage')){if($txt -match ("\[Parameter\(Mandatory\)\]\[string\]\$"+$p)){$errors+="$p est encore obligatoire"}}
 foreach($needle in @('Resolve-CrodipHistoricalRelease','CRODIP Official Build','gh run list','gh run download','Get-ImagesFromManifest','Paramètre {0} incohérent')){if($txt -notmatch [regex]::Escape($needle)){$errors+="résolution automatique absente: $needle"}}
 if($txt -match 'docker compose down|docker volume rm|07-restore\.ps1'){$errors+='mutation DB interdite détectée'}
}
if($errors.Count){$errors|ForEach-Object{Write-Host "[ECHEC] $_" -ForegroundColor Red};exit 1}
Write-Host '[OK] RC41 STEP3C FIX1 - RunNumber seul ; RunId/version/commit/images résolus automatiquement depuis le manifest officiel.' -ForegroundColor Green
