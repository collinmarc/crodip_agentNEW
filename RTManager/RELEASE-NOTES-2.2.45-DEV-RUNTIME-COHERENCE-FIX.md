# CRODIP Runtime Manager v2.2.45 Stable

## DEV / Runtime Coherence Fix

Cette release consolide la cohérence du Runtime Manager avec le Kit DEV 951-11 v6.2.96 sans modifier l'architecture fonctionnelle du Runtime LOCAL.

### Corrections

- `VERSION` alignée sur `2.2.45`.
- `STATUS` aligné sur `Stable - DEV Runtime Coherence Fix`.
- `config/runtime.json` aligné sur `2.2.45`.
- `images/images-manifest.json` aligné sur `2.2.45`.
- `RELEASE-MANIFEST.json` aligné sur `2.2.45`.
- suppression du second `docker compose pull` global dans `commands/08-update.ps1`.
- suppression du défaut où `$pull` pouvait encore contenir le résultat du dernier pull individuel.
- le workflow de mise à jour s'appuie uniquement sur les services et images réellement détectés dans `compose.yaml`.
- suppression des références d'images codées en dur du bloc de fallback obsolète du script d'update.
- conservation de la nomenclature `crodip-local-*` / `crodip-central-*`.
- conservation du projet Runtime LOCAL `crodip-runtime-local`.
- conservation de SQLite pour le Runtime LOCAL.

### Compatibilité Kit DEV

Cette release reste compatible avec le Kit DEV 951-11 v6.2.96 :
- DEV LOCAL : `crodip-dev-local` ;
- DEV CENTRAL : `crodip-dev-central` ;
- Runtime LOCAL : `crodip-runtime-local` ;
- CENTRAL : `crodip-central`.

Les noms de projets et plages de ports restent isolés.
