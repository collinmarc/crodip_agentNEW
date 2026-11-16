# Runtime Manager 2.2.43 — Local/Central Nomenclature Alignment

Cette version aligne le Runtime Manager sur la nomenclature Docker stabilisée du projet CRODIP.

## Changements

- image runtime backend : `crodip-local-backend:2.2.1`;
- image runtime frontend : `crodip-local-frontend:2.2.1`;
- projet Compose runtime : `crodip-runtime-local`;
- référence centrale : projet `crodip-central`, images `crodip-central-*`;
- manifeste offline renommé vers `crodip-local-*`;
- contrôle GHCR effectué sur l'image LOCAL backend;
- mise à jour runtime et fallback AUTO utilisent les nouvelles images;
- normalisation d'un `.env` installé utilisant les anciens noms;
- sauvegarde automatique du `.env` avant migration.

Le Runtime Windows reste un Runtime LOCAL. La topologie CENTRAL est référencée pour
cohérence mais n'est pas pilotée par ce kit.
