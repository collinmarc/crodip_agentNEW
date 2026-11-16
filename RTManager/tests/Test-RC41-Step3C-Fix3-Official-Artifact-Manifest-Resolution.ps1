$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$p=Join-Path $root 'commands\20-bootstrap-historical-release-snapshot.ps1'
if(-not(Test-Path $p)){throw '[ECHEC] commande STEP3C absente'}
$s=Get-Content $p -Raw

# FIX3.2 : contrôles structurels par regex, sans dépendre de la mise en forme exacte du code.
$checks=@(
 @('purge workspace', '(?s)if\s*\(\s*Test-Path\s+\$dest\s*\)\s*\{\s*Remove-Item\s+\$dest\s+-Recurse\s+-Force'),
 @('inventaire artifacts API', 'actions/runs/\{1\}/artifacts\?per_page=100'),
 @('filtre dockerbuild', '(?i)dockerbuild'),
 @('priorite official release', "(?is)Sort-Object.*official\|release.*\{1\}"),
 @('recherche recursive manifest', '(?i)Get-ChildItem\s+\$ad\s+-Recurse\s+-File\s+-Filter\s+manifest\.json'),
 @('identite commit', '(?i)gitCommit.*run\.headSha'),
 @('validation images', '(?i)Get-ImagesFromManifest\s+\$m'),
 @('diagnostic artefacts', 'Artefacts examinés')
)
foreach($c in $checks){
 if($s -notmatch $c[1]){throw ("[ECHEC] FIX3 absent : {0}" -f $c[0])}
}
Write-Host '[OK] RC41 STEP3C FIX3.2 - résolution robuste du manifest officiel vérifiée structurellement : workspace propre, artefacts sûrs, priorité official release, recherche récursive et validation commit/images.' -ForegroundColor Green
