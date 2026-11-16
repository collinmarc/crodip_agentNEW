# RC41 STEP3D-FIX1

Correction du ParserError de `21-reconstruct-historical-release-snapshot.ps1` sur le message de garde-fou final. La ligne sensible est normalisee en ASCII et le fichier est ecrit en UTF-8 avec BOM. Ajout d'un test parser PowerShell reel. Aucun changement de politique : les bases actives restent intactes et un snapshot `reconstructed/EMPTY` reste non eligible automatiquement a STEP3B.
