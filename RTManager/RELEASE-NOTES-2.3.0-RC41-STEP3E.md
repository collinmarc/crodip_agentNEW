# Runtime Manager 2.3.0-RC41 — STEP3E

## Explicit TEST EMPTY Release Activation

STEP3E ajoute un chemin volontaire et séparé du rollback STEP3B permettant, **uniquement en cycle TEST**, d’activer une release historique lorsqu’aucun snapshot métier authentique n’existe mais qu’un snapshot STEP3D `RECONSTRUCTED / EMPTY` qualifié est disponible.

Garde-fous :
- STEP3B reste inchangé et n’utilise jamais automatiquement `release-snapshot-reconstructed.json` ;
- snapshot de sécurité authentique de la release source créé avant toute bascule ;
- validation run/runId, archive, SQLite, PostgreSQL, heads Alembic, `backupMode=reconstructed`, `dataState=EMPTY`, qualification STEP3D ;
- cycle `TEST` obligatoire ;
- choix explicite du mode EMPTY puis saisie `ACTIVER EMPTY` ;
- confirmation finale `SWITCH-RUNTIME-EMPTY` ;
- traçabilité de l’override avec `databaseMode=RECONSTRUCTED_EMPTY` ;
- rollback de sécurité vers le snapshot de la release source en cas d’échec d’activation.

Ce mode sert aux tests fonctionnels d’une ancienne release. Il ne recrée aucune donnée métier historique.
