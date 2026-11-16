# Runtime Manager 2.3.0-RC41 — STEP3E FIX2

## Objet

Correction de la qualification finale RC41 sans modification du moteur STEP3B/STEP3E.

## Correction

Les assertions de `Test-RC41-Final-Qualification.ps1` utilisaient des chaînes PowerShell interpolées contenant `$m`, `$d`, `$meta` et `$dir`. Ces variables étaient donc évaluées par le test au lieu d’être recherchées littéralement dans le module.

FIX2 échappe ces variables afin de vérifier le code réellement présent :

- STEP3B continue de cibler exclusivement `release-snapshot.json` via `Find-CrodipReleaseSnapshot`;
- STEP3E détecte séparément `release-snapshot-reconstructed.json` via `Find-CrodipReconstructedEmptySnapshot`;
- aucun changement du moteur de restauration ou des garde-fous.
