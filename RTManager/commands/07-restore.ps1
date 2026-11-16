#Requires -Version 7.4
[CmdletBinding()] param([string]$ArchivePath,[switch]$Force,[switch]$SkipPostRestoreVerification,[switch]$DeferBackendStart)
$ErrorActionPreference='Stop'
Import-Module (Join-Path $PSScriptRoot '..\modules\Crodip.Runtime.Common.psm1') -Force -DisableNameChecking
Import-Module (Join-Path $PSScriptRoot '..\modules\Crodip.Runtime.Windows.psm1') -Force -DisableNameChecking
Write-CrodipRuntimeHeader '07-restore.ps1'

function Get-ComposeContainerId([string]$Project,[string]$Service){$x=@(& docker ps --filter "label=com.docker.compose.project=$Project" --filter "label=com.docker.compose.service=$Service" --format '{{.ID}}' 2>$null);if($x.Count){return ([string]$x[0]).Trim()};return $null}
function Get-ContainerEnv([string]$Id,[string]$Name){$x=@(& docker inspect $Id --format '{{range .Config.Env}}{{println .}}{{end}}' 2>$null|Where-Object{$_ -like "$Name=*"}|Select-Object -First 1);if($x.Count){return ([string]$x[0]).Substring($Name.Length+1)};return $null}
function Format-BackupSize([long]$Bytes){if($Bytes-ge 1MB){return ('{0:N1} Mo'-f($Bytes/1MB))};return ('{0:N0} Ko'-f([math]::Max(1,$Bytes/1KB)))}
function Select-CrodipBackupArchive {
 $backupRoot=Join-Path (Get-CrodipDataRoot) 'backups'
 $items=@()
 if(Test-Path -LiteralPath $backupRoot){$items=@(Get-ChildItem -LiteralPath $backupRoot -Filter 'crodip-runtime-*.zip' -File|Sort-Object LastWriteTime -Descending)}
 Write-Host '';Write-Host '========================================' -ForegroundColor Cyan;Write-Host ' Restauration CRODIP' -ForegroundColor Cyan;Write-Host '========================================' -ForegroundColor Cyan;Write-Host ''
 if($items.Count){
   Write-Host 'Sauvegardes disponibles :' -ForegroundColor Cyan;Write-Host ''
   for($i=0;$i-lt $items.Count;$i++){$f=$items[$i];$type=if($f.Name -match '-full-'){'FULL'}elseif($f.Name -match '-quick-'){'QUICK'}else{'ZIP'};Write-Host ('[{0}] {1,-5} {2}  {3,9}  {4}' -f ($i+1),$type,$f.LastWriteTime.ToString('dd/MM/yyyy HH:mm'),(Format-BackupSize $f.Length),$f.Name)}
 }else{Write-CrodipWarning "Aucune sauvegarde CRODIP trouvée dans $backupRoot"}
 Write-Host '';Write-Host 'M. Sélectionner une archive manuellement';Write-Host 'R. Retour';Write-Host ''
 $choice=(Read-Host 'Votre choix').Trim()
 if($choice -match '^[Rr]$'){return $null}
 if($choice -match '^[Mm]$'){$manual=(Read-Host 'Chemin complet de l archive ZIP').Trim().Trim('"');return $manual}
 $n=0;if([int]::TryParse($choice,[ref]$n)-and$n-ge 1-and$n-le $items.Count){return $items[$n-1].FullName}
 Write-CrodipWarning 'Choix invalide.';return $null
}

if(-not $ArchivePath){$ArchivePath=Select-CrodipBackupArchive;if(-not $ArchivePath){return}}
$ArchivePath=$ArchivePath.Trim().Trim('"')
if(-not(Test-Path -LiteralPath $ArchivePath -PathType Leaf)){Write-CrodipError "Archive introuvable : $ArchivePath";return}
$tmp=Join-Path $env:TEMP ('crodip-restore-'+[guid]::NewGuid().ToString('N'))
try{
 Expand-Archive -LiteralPath $ArchivePath -DestinationPath $tmp -Force
 $mf=Join-Path $tmp 'BACKUP-MANIFEST.json';if(-not(Test-Path $mf)){throw 'BACKUP-MANIFEST.json absent : restauration refusée.'}
 $m=Get-Content $mf -Raw|ConvertFrom-Json
 $type=if((Split-Path $ArchivePath -Leaf)-match '-full-'){'FULL'}elseif((Split-Path $ArchivePath -Leaf)-match '-quick-'){'QUICK'}else{'ZIP'}
 Write-Host '';Write-Host 'Sauvegarde sélectionnée :' -ForegroundColor Cyan
 Write-Host " Archive          : $(Split-Path $ArchivePath -Leaf)";Write-Host " Runtime          : $($m.runtimeVersion)";Write-Host " Créée            : $($m.createdAt)";Write-Host " Type             : $type"
 Write-Host '';Write-Host ' LOCAL' -ForegroundColor Cyan;Write-Host "  Moteur          : $($m.database.local.engine)";Write-Host "  Déployé         : $($m.database.local.deployed)";Write-Host "  Alembic         : $($m.database.local.alembicRevision)"
 Write-Host '';Write-Host ' CENTRAL' -ForegroundColor Cyan;Write-Host "  Moteur          : $($m.database.central.engine)";Write-Host "  Déployé         : $($m.database.central.deployed)";Write-Host "  Alembic         : $($m.database.central.alembicRevision)";Write-Host "  Dump PostgreSQL : $($m.database.central.dumpIncluded)"
 if(-not $Force -and (Read-Host 'Restaurer cette sauvegarde ? O/N')-notmatch '^[OoYy]$'){return}
 $dataRoot=Get-CrodipDataRoot
 $localBackend=Get-ComposeContainerId 'crodip-runtime-local' 'backend';$centralBackend=Get-ComposeContainerId 'crodip-runtime-central' 'backend';$pg=Get-ComposeContainerId 'crodip-runtime-central' 'postgres'
 if($localBackend){& docker stop $localBackend|Out-Null};if($centralBackend){& docker stop $centralBackend|Out-Null}
 foreach($name in @('sqlite','documents','pdf','photos','signatures','exports','imports','config')){$src=Join-Path $tmp $name;if(Test-Path $src){$dst=Join-Path $dataRoot $name;New-CrodipDirectory -Path $dst|Out-Null;Copy-Item (Join-Path $src '*') $dst -Recurse -Force -ErrorAction SilentlyContinue}}
 # RC39 : les fichiers extraits par Windows doivent rester modifiables via le bind mount Docker.
 Set-CrodipSqliteWriteAcl -SqlitePath (Join-Path $dataRoot 'sqlite') -Confirm:$false
 $dump=Join-Path $tmp 'databases\central-postgresql.dump'
 if($m.database.central.dumpIncluded -and (Test-Path $dump)){
   if(-not $pg){throw 'Dump PostgreSQL présent mais conteneur CENTRAL PostgreSQL non déployé.'}
   $u=Get-ContainerEnv $pg 'POSTGRES_USER';$d=Get-ContainerEnv $pg 'POSTGRES_DB';if(-not$u){$u='postgres'};if(-not$d){$d=$u}
   & docker cp $dump "${pg}:/tmp/crodip-runtime-restore.dump"|Out-Null;if($LASTEXITCODE -ne 0){throw 'docker cp du dump PostgreSQL a échoué.'}
   & docker exec $pg sh -c "pg_restore -U '$u' -d '$d' --clean --if-exists --no-owner --no-privileges /tmp/crodip-runtime-restore.dump"|Out-Null
   if($LASTEXITCODE -ne 0){throw 'pg_restore CENTRAL a échoué.'}; & docker exec $pg rm -f /tmp/crodip-runtime-restore.dump|Out-Null
 }
 if(-not $DeferBackendStart){
   if($localBackend){& docker start $localBackend|Out-Null};if($centralBackend){& docker start $centralBackend|Out-Null}
   Start-Sleep -Seconds 2
 }
 if(-not $SkipPostRestoreVerification){
   if($DeferBackendStart){throw 'DeferBackendStart exige SkipPostRestoreVerification.'}
   $verify=Join-Path $PSScriptRoot '19-verify-databases.ps1';if(Test-Path $verify){& $verify;if($LASTEXITCODE -ne 0){throw 'Vérification DB après restauration en échec.'}}
   Write-CrodipSuccess 'Restauration terminée et contrôlée.'
 } else {
   Write-CrodipWarning 'Restauration STAGEE : vérification différée jusqu au redéploiement des images compatibles.'
 }
}catch{Write-CrodipError "Échec de la restauration : $($_.Exception.Message)";throw}
finally{if(Test-Path $tmp){Remove-Item $tmp -Recurse -Force -ErrorAction SilentlyContinue}}
