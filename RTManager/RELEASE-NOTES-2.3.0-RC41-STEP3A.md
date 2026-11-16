# RC41 STEP3A — Release Snapshot Restore Engine

Cette étape ajoute le moteur de restauration d'un snapshot lié à une release sans encore activer automatiquement le changement de release dans le menu 8.

- validation stricte de l'identité run/runId du snapshot ;
- présence obligatoire de SQLite LOCAL et de sa révision Alembic ;
- présence obligatoire du dump PostgreSQL CENTRAL et de sa révision Alembic ;
- comparaison optionnelle des révisions Alembic avec les heads des images cibles ;
- restauration non interactive contrôlée via `07-restore.ps1 -Force` ;
- conservation du garde-fou STEP2 : aucun downgrade automatique n'est encore déclenché.

STEP3B raccordera ce moteur à la transaction de changement de release avec rollback de secours vers le snapshot de la release source en cas d'échec.
