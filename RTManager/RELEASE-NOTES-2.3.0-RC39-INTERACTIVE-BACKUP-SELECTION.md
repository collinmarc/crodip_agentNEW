# CRODIP Runtime Manager 2.3.0-RC39

## Interactive Backup Selection & SQLite ACL Hardening

RC39 conserve le moteur de sauvegarde/restauration qualifié en RC38 et améliore son exploitation.

- liste automatiquement les archives `crodip-runtime-*.zip` de `CRODIP_DATA_ROOT\backups` ;
- trie les sauvegardes de la plus récente à la plus ancienne ;
- affiche type, date, taille et nom ;
- sélection numérotée, chemin manuel (`M`) ou retour (`R`) ;
- affiche les métadonnées du `BACKUP-MANIFEST.json` avant confirmation ;
- conserve la restauration SQLite + PostgreSQL et la vérification DB post-restauration de RC38 ;
- normalise les ACL du répertoire SQLite avec le SID Windows `S-1-5-32-545` (BUILTIN\Users) et le droit `Modify`, récursivement ;
- applique cette normalisation à l'installation/réparation et après restauration.

## Non-régression attendue

Les révisions qualifiées du Build officiel #14 restent : LOCAL `d24d83ea9494`, CENTRAL `3452c4fc44ba`.

## Qualification E2E réalisée le 2026-09-28

RC39 a été qualifiée avec l'application officielle `2.3.0-dev.3`, Build #14 / Run `35976894313`.

Résultats :

- test automatisé RC39 : PASS ;
- sélection interactive et lecture du manifest : PASS ;
- restauration d'une sauvegarde RC38 sous RC39 : PASS ;
- SQLite LOCAL restauré avec Alembic `d24d83ea9494` : PASS ;
- PostgreSQL CENTRAL restauré avec Alembic `3452c4fc44ba` : PASS ;
- marqueur `BEFORE_BACKUP` restauré dans les deux bases : PASS ;
- `19-verify-databases.ps1` : LOCAL PASS / CENTRAL PASS / GLOBAL PASS ;
- ACL `BUILTIN\\Utilisateurs: Modify` conservée après restauration : PASS ;
- écriture SQLite depuis le backend puis rollback : PASS.

Verdict : **RC39 QUALIFIÉE E2E sur le périmètre sauvegarde/restauration et ACL SQLite.**
