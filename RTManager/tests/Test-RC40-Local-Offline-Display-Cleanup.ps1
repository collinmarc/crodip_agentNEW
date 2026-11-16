$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$module = Join-Path $root 'modules\Crodip.Runtime.Docker.psm1'
$text = Get-Content -LiteralPath $module -Raw
if ($text -notmatch '\[switch\]\$SuppressExistingImageMessages') { throw 'Switch de suppression des messages existants absent.' }
if ($text -notmatch 'Import-CrodipOfflineImages\s+`\s*\r?\n\s*-SuppressExistingImageMessages') { throw 'Le chemin OFFLINE LOCAL ne masque pas le contrôle redondant.' }
if ($text -notmatch 'Assert-CrodipRequiredImagesLocal') { throw 'Contrôle générique des images requis absent.' }
Write-Host '[OK] RC40 - affichage OFFLINE LOCAL nettoyé, contrôle générique conservé.' -ForegroundColor Green
