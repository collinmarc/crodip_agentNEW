# CRODIP Runtime Manager 2.3.0-RC41 — STEP3E FIX11

## Target Release Alembic Context

FIX11 corrige le changement transactionnel TEST vers une release antérieure avec snapshot historique ou RECONSTRUCTED/EMPTY.

- le head Alembic attendu pendant le redéploiement cible provient du `BACKUP-MANIFEST.json` du snapshot cible déjà qualifié ;
- ce contexte est injecté uniquement au scope `Process` via `CRODIP_TARGET_ALEMBIC_LOCAL` / `CRODIP_TARGET_ALEMBIC_CENTRAL` ;
- le moteur conserve strictement l'invariant `release = image = database` ;
- hors transaction, la configuration officielle reste la source de vérité ;
- les variables transactionnelles sont restaurées avant tout rollback, afin que le retour source utilise les heads officiels ;
- aucun assouplissement des contrôles de migration ou des protections de rollback n'est introduit.
