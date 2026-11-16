# RC41 STEP3E FIX1

- Corrige la qualification finale pour distinguer la détection des snapshots `RECONSTRUCTED/EMPTY` STEP3E de leur éligibilité STEP3B.
- `Find-CrodipReleaseSnapshot` reste limité à `release-snapshot.json` (snapshot authentique).
- `Find-CrodipReconstructedEmptySnapshot` utilise `release-snapshot-reconstructed.json` dans un chemin séparé et explicite.
- Aucun changement du moteur STEP3D/STEP3E.
