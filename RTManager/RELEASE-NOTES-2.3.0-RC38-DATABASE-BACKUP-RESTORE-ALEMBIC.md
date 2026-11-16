# Runtime Manager 2.3.0-RC38 — Database Backup/Restore + Alembic Traceability

RC38 complète RC37 avec une sauvegarde cohérente des Data Foundations.

- SQLite LOCAL reste inclus dans l’archive.
- PostgreSQL CENTRAL est exporté par `pg_dump -Fc` lorsque la topologie est déployée.
- `BACKUP-MANIFEST.json` enregistre les révisions Alembic LOCAL et CENTRAL.
- `databases/ALEMBIC-DATABASE-METADATA.json` fournit la même traçabilité au niveau base.
- La restauration PostgreSQL utilise `pg_restore --clean --if-exists` avec arrêt temporaire du backend CENTRAL.
- La restauration est refusée sans manifeste et demande une confirmation explicite.
- Après restauration, le contrôle DB Runtime est exécuté pour vérifier notamment la cohérence Alembic.

Référence Build officiel #14 : LOCAL `d24d83ea9494`, CENTRAL `3452c4fc44ba`. Ces valeurs sont des références de qualification ; la sauvegarde enregistre la révision réellement présente au moment du backup.
