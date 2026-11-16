#Requires -Version 7.4
[CmdletBinding()] param()
Set-StrictMode -Version Latest;$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$cfg=Get-Content (Join-Path $root 'config\runtime.json') -Raw|ConvertFrom-Json
if($cfg.version -ne '2.3.0-RC39'){throw 'Version RC39 absente.'}
$r=Get-Content (Join-Path $root 'commands\07-restore.ps1') -Raw
$w=Get-Content (Join-Path $root 'modules\Crodip.Runtime.Windows.psm1') -Raw
$i=Get-Content (Join-Path $root 'commands\01-install.ps1') -Raw
foreach($x in @('Sauvegardes disponibles','crodip-runtime-*.zip','Sélectionner une archive manuellement','BACKUP-MANIFEST.json','pg_restore','19-verify-databases.ps1','Set-CrodipSqliteWriteAcl')){if($r -notmatch [regex]::Escape($x)){throw "Restore RC39 absent: $x"}}
foreach($x in @('Set-CrodipSqliteWriteAcl','S-1-5-32-545','(OI)(CI)(M)','icacls.exe')){if($w -notmatch [regex]::Escape($x)){throw "ACL RC39 absente: $x"}}
if($i -notmatch 'Set-CrodipSqliteWriteAcl'){throw 'ACL SQLite non appliquée à installation/réparation.'}
Write-Host '[OK] RC39 - sélection interactive backup + durcissement ACL SQLite intégrés.' -ForegroundColor Green
