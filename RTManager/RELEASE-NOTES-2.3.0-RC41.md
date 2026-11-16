# CRODIP SaaS Runtime Manager 2.3.0-RC41

## Transactional Release Rollback & Database Snapshots

RC41 démarre à partir de la RC40 techniquement qualifiée et introduit la fondation du rollback de release lié à l'état des bases.

### Politique retenue
- UPGRADE : sauvegarde préalable puis migration Alembic vers le head de la release cible.
- DOWNGRADE : aucun `alembic downgrade` automatique ; la cible doit disposer d'un snapshot de base identifié et compatible.
- LOCAL : snapshot SQLite avec révision Alembic.
- CENTRAL : `pg_dump` PostgreSQL custom avec révision Alembic.
- Avant tout rollback, l'état courant devra lui-même être sauvegardé afin de permettre un retour arrière.

### Fondation livrée dans cette première itération RC41
- identité de release ajoutée au manifeste des sauvegardes ;
- nouveaux usages `pre-release-change` et `rollback-safety` ;
- racine `C:\ProgramData\CRODIP\release-snapshots` ;
- module `Crodip.Runtime.ReleaseRollback.psm1` ;
- création et recherche d'un snapshot lié à `runNumber/runId` ;
- politique `releaseRollback` dans `config/runtime.json` ;
- interdiction explicite du downgrade Alembic automatique.

La restauration transactionnelle DOWN n'est volontairement pas activée dans cette première itération : la fondation est d'abord testée avant branchement sur le changement de release, afin de ne pas introduire une opération destructive non qualifiée.

## Étape 2 - Release Change Transaction & DOWN Preflight
- Détermination UPGRADE / DOWNGRADE / SAME depuis la release effectivement active.
- Snapshot obligatoire de la release quittée avant changement.
- En DOWNGRADE : recherche stricte du snapshot du run cible (runNumber + runId).
- Lecture du BACKUP-MANIFEST et comparaison des révisions Alembic SQLite/PostgreSQL avec les heads des images backend cibles.
- DOWN bloqué si snapshot absent/incomplet/incompatible.
- La restauration automatique SQLite/PostgreSQL reste volontairement désactivée à cette étape ; un DOWN qualifié s'arrête avant toute modification.

## Qualification finale — 30/09/2026

RC41 a été qualifiée en scénario réel TEST #15 → #14 RECONSTRUCTED/EMPTY → #15. Le retour officiel restaure les heads `ecd67252fd57` (LOCAL) et `7544a84c3691` (CENTRAL), avec `GLOBAL PASS`, override TEST inactif et quatre services officiels opérationnels. La batterie finale FIX7 à FIX11 + qualification finale retourne 6/6 `[OK]`. Voir `docs/QUALIFICATION-RC41.md`.
