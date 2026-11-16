$ErrorActionPreference='Stop'
$root=Split-Path $PSScriptRoot -Parent
$m=Join-Path $root 'modules\Crodip.Runtime.ReleaseRollback.psm1'
$errors=@()
if(-not(Test-Path $m)){$errors+='module ReleaseRollback absent'} else {
 $txt=Get-Content $m -Raw
 foreach($needle in @(
   "PSObject.Properties['releaseIdentity']",
   "PSObject.Properties['runNumber']",
   "PSObject.Properties['runId']",
   "PSObject.Properties['database']",
   "PSObject.Properties['local']",
   "PSObject.Properties['central']",
   "PSObject.Properties['deployed']",
   "PSObject.Properties['dumpIncluded']",
   "PSObject.Properties['alembicRevision']"
 )){if($txt -notmatch [regex]::Escape($needle)){$errors+="garde legacy absent: $needle"}}
 # Le scanner ne doit plus déréférencer directement releaseIdentity sur un manifest potentiellement legacy.
 $start=$txt.IndexOf('function Find-CrodipHistoricalBackupCandidate')
 $end=$txt.IndexOf('function Register-CrodipHistoricalReleaseSnapshot',$start)
 if($start -lt 0 -or $end -lt 0){$errors+='scanner historique introuvable'} else {
   $scanner=$txt.Substring($start,$end-$start)
   if($scanner -match '\$bm\.releaseIdentity'){$errors+='accès direct bm.releaseIdentity encore présent dans le scanner'}
   if($scanner -notmatch 'if\(-not \$riProp -or \$null -eq \$riProp\.Value\)\{continue\}'){$errors+='backup legacy sans releaseIdentity non ignoré explicitement'}
 }
}
if($errors.Count){$errors|ForEach-Object{Write-Host "[ECHEC] $_" -ForegroundColor Red};exit 1}
Write-Host '[OK] RC41 STEP3C FIX2 - manifests legacy sans releaseIdentity/database ignorés sans exception ; identité exacte toujours obligatoire.' -ForegroundColor Green
