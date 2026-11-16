# Sauvegarde, restauration et rollback de release — Runtime Manager 2.3.0-RC41

## Extension RC41

RC41 conserve le moteur FULL/QUICK de RC38-RC40 et ajoute des snapshots liés à l'identité de release sous `C:\ProgramData\CRODIP\release-snapshots`. Les manifests tracent notamment le run, la version applicative et les révisions Alembic LOCAL/CENTRAL.

Avant tout changement de release, un snapshot de sécurité de la source est créé. En DOWNGRADE, RC41 n'exécute jamais `alembic downgrade`. La cible doit disposer soit d'un snapshot historique authentique compatible, soit — uniquement pour TEST — d'un snapshot `RECONSTRUCTED/EMPTY` qualifié. Ce dernier ne contient pas les données métier historiques de la release cible.

La restauration transactionnelle est STAGÉE : les bases sont restaurées avant les images compatibles, la vérification est différée, puis l'invariant `release = image = database` et les endpoints `/health/db` sont contrôlés. En cas d'échec après modification des bases, le rollback vers le snapshot source est obligatoire.

Qualification réelle du 30/09/2026 : #15 (`ecd67252fd57` / `7544a84c3691`) → #14 EMPTY (`d24d83ea9494` / `3452c4fc44ba`) → #15, avec `GLOBAL PASS` au retour officiel.

---

# Sauvegarde et restauration des bases — Runtime Manager 2.3.0-RC40

## Objet

RC40 conserve le moteur de sauvegarde/restauration qualifié en RC38/RC39 et ajoute son usage obligatoire PRE-MIGRATION pour CENTRAL avant toute migration modifiant la base. La sélection interactive et le durcissement des ACL SQLite introduits en RC39 sont conservés.

## Périmètre sauvegardé

Une sauvegarde complète inclut :

- la base SQLite LOCAL (`sqlite/crodip.db`) ;
- les données persistantes du Runtime prévues par le script de sauvegarde ;
- lorsque CENTRAL est déployé, un dump PostgreSQL au format custom (`databases/central-postgresql.dump`) ;
- `BACKUP-MANIFEST.json`, qui trace notamment les moteurs et les révisions Alembic réellement sauvegardées.

Pour le Build officiel #14 / application `2.3.0-dev.3`, les révisions qualifiées sont :

- LOCAL / SQLite : `d24d83ea9494` ;
- CENTRAL / PostgreSQL : `3452c4fc44ba`.

## Sélection interactive RC39

Le menu `7. Restaurer` recherche les archives `crodip-runtime-*.zip` sous le répertoire `backups` du `CRODIP_DATA_ROOT`, les trie de la plus récente à la plus ancienne et propose :

- un choix numéroté ;
- `M` pour saisir manuellement le chemin d'une archive ;
- `R` pour revenir au menu.

Avant toute restauration, le manifest est affiché : version Runtime d'origine, date, type de sauvegarde, moteur LOCAL/CENTRAL, état de déploiement, révisions Alembic et présence du dump PostgreSQL.

## Séquence de restauration

1. lecture et validation de `BACKUP-MANIFEST.json` ;
2. confirmation explicite de l'opérateur ;
3. arrêt contrôlé des backends déployés ;
4. restauration des données persistantes, dont SQLite ;
5. restauration PostgreSQL par `pg_restore` si un dump CENTRAL est présent ;
6. normalisation des ACL SQLite ;
7. redémarrage des backends ;
8. exécution de `19-verify-databases.ps1`.

Une restauration n'est déclarée terminée que si les contrôles des topologies déployées passent.

## Durcissement ACL SQLite

L'incident identifié pendant la qualification RC38 provenait d'un fichier SQLite lisible depuis Docker mais non modifiable : Windows accordait seulement `ReadAndExecute` au groupe BUILTIN\\Utilisateurs sur le fichier existant.

RC39 normalise les droits avec le SID Windows `S-1-5-32-545` et le droit `Modify`, récursivement sur le répertoire SQLite. Cette normalisation est appliquée lors de l'installation/réparation et après restauration.

Le comportement qualifié après restauration est :

- `BUILTIN\\Utilisateurs : Modify` sur le répertoire SQLite ;
- `BUILTIN\\Utilisateurs : Modify` sur `crodip.db` ;
- écriture SQLite depuis le conteneur backend : PASS ;
- rollback du test d'écriture : PASS.

## Politique de retour arrière

Une restauration de sauvegarde constitue le mécanisme de retour à un état de données connu. Les migrations Alembic automatiques ne réalisent pas de downgrade automatique.
