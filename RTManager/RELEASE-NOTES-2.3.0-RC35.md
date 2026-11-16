# CRODIP Runtime Manager 2.3.0-RC35

## Objet

RC35 complète RC34 avec une vérification intégrée des bases de données Runtime.

## Vérification LOCAL — SQLite

Le menu 20 contrôle :
- la présence du backend LOCAL ;
- le fichier `/app/runtime/sqlite/crodip.db` ;
- l'ouverture SQLite et un `SELECT` en lecture ;
- la présence et la valeur de `alembic_version` ;
- l'endpoint `/health/db`.

Pour le Build officiel #14, le head attendu est `d24d83ea9494`.

## Vérification CENTRAL — PostgreSQL

Le menu 20 contrôle :
- le conteneur PostgreSQL ;
- `pg_isready` ;
- un `SELECT 1` ;
- la lecture de `alembic_version` ;
- l'endpoint backend `/health/db`.

Pour le Build officiel #14, le head attendu est `3452c4fc44ba`.

## Changement de release

Après sélection d'un build antérieur ou postérieur, la vérification DB est
relancée. Pour une release différente du Build officiel #14, le head Alembic
est détecté et affiché sans imposer les heads du Build #14.

Les contrôles sont en lecture seule. Le volume PostgreSQL CENTRAL est conservé.
