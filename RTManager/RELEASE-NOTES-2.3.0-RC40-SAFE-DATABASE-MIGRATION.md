# CRODIP Runtime Manager 2.3.0-RC40

## Safe Database Migration & Release Compatibility

RC40 capitalise sur RC37 (migration Alembic), RC38 (backup/restore DB) et RC39 (sélection interactive des sauvegardes) pour sécuriser le passage réel N → N+1.

### Baseline cible

- Application : `2.3.0-dev.4`
- Official Build : #15 / Run `36452467983`
- Commit : `53928c1f30a8a90cc6a1cf467d5c332f10494a80`
- LOCAL / SQLite : `ecd67252fd57`
- CENTRAL / PostgreSQL : `7544a84c3691`

### Chaîne RC40

1. sauvegarde PRE-MIGRATION obligatoire ;
2. synchronisation des images officielles par digest ;
3. lecture du head attendu par la release ;
4. comparaison avec le head embarqué dans l'image backend ;
5. refus si release et image sont incompatibles ;
6. lecture de la révision DB courante ;
7. `alembic upgrade <expectedHead>` si nécessaire ;
8. contrôle post-migration `release == image == database` ;
9. écriture d'un rapport JSON de migration.

### Politique de sécurité

- upgrade-only ;
- aucun downgrade automatique ;
- aucune restauration automatique après échec ;
- la sauvegarde PRE-MIGRATION reste disponible pour une restauration explicitement demandée par l'opérateur.

### Scénario E2E à qualifier

- LOCAL : `d24d83ea9494` → `ecd67252fd57`
- CENTRAL : `3452c4fc44ba` → `7544a84c3691`
- conservation des données témoins ;
- `/health` et `/health/db` conformes après migration.

## Correctif qualification RC40 — backup au niveau du moteur

La première migration réelle LOCAL a démontré que le chemin `Start` pouvait déclencher Alembic sans passer par le backup placé initialement dans `08-update.ps1`.

RC40 impose désormais la règle au niveau du moteur de migration :

- si `database current == expectedHead` : aucun backup ni migration ;
- si une migration est nécessaire : backup `purpose=pre-migration` obligatoire avant Alembic ;
- si le backup échoue : `alembic upgrade` n'est pas exécuté ;
- la règle s'applique quel que soit le point d'entrée : Start, Update ou réconciliation ;
- le backup spécifique à `08-update.ps1` est retiré afin d'éviter un double backup.

La migration LOCAL déjà observée `d24d83ea9494 → ecd67252fd57` reste valide pour la preuve de migration de schéma, mais le contrôle du backup systématique doit être requalifié sur un scénario nécessitant réellement une nouvelle migration.
