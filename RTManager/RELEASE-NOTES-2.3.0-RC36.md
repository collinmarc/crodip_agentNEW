# CRODIP Runtime Manager 2.3.0-RC36

## Correctif de vérification des bases

RC36 corrige le contrôle introduit en RC35.

### LOCAL / SQLite

Le chemin SQLite n'est plus codé en dur. Le Runtime lit `DATABASE_URL`
directement dans l'environnement du conteneur backend LOCAL, en déduit le
chemin du fichier et ouvre la base en lecture seule.

Les contrôles portent sur :
- `DATABASE_URL` ;
- le fichier SQLite réellement configuré ;
- `SELECT 1` ;
- `alembic_version` ;
- `/health/db`.

Pour le Build officiel #14, le head attendu reste `d24d83ea9494`.

### CENTRAL / PostgreSQL

La topologie CENTRAL est d'abord détectée. Si elle n'est pas déployée,
le résultat est `NON DEPLOYE` et non `ERREUR`.

Si CENTRAL est présent, le Runtime détecte `POSTGRES_USER` et `POSTGRES_DB`,
puis contrôle `pg_isready`, `SELECT 1`, `alembic_version` et `/health/db`.

Pour le Build officiel #14, le head attendu reste `3452c4fc44ba`.

### Résultat global

La qualification DB est calculée uniquement sur les topologies réellement
déployées. Une topologie absente n'entraîne donc plus un faux FAIL.
