# Qualification — CRODIP SaaS Runtime Manager 2.3.0-RC41

**Date :** 30/09/2026  
**Cycle :** TEST  
**Objet :** Transactional Release Rollback & Database Snapshots

## Baseline officielle

- Application : `2.3.0-dev.4`
- Build : `#15` / Run ID `36452467983`
- Commit : `53928c1f30a8a90cc6a1cf467d5c332f10494a80`
- LOCAL Alembic : `ecd67252fd57`
- CENTRAL Alembic : `7544a84c3691`
- Ports TEST LOCAL : backend `8110`, frontend `9110`
- Ports TEST CENTRAL : backend `8120`, frontend `9120`

## Scénario E2E qualifié

1. État initial #15 OFFICIAL cohérent.
2. Snapshot de sécurité de #15 avec SQLite LOCAL et `pg_dump` CENTRAL.
3. Sélection du Build #14 / `2.3.0-dev.3`.
4. Activation explicite TEST d'un snapshot `RECONSTRUCTED/EMPTY`, après double confirmation.
5. Déploiement des images #14 et qualification des heads cible : LOCAL `d24d83ea9494`, CENTRAL `3452c4fc44ba`.
6. Contrôle Docker : quatre services applicatifs #14 `running`, override TEST actif, release cohérente et services opérationnels.
7. Retour explicite à la release officielle.
8. Restauration STAGÉE du snapshot source #15 puis redéploiement des quatre images officielles.
9. Contrôle final : override TEST inactif, quatre services #15 `running`, release cohérente, services opérationnels.
10. Vérification indépendante des bases : `LOCAL PASS`, `CENTRAL PASS`, `GLOBAL PASS`.

## Résultats bases au retour #15

- SQLite LOCAL : lecture OK, Alembic `ecd67252fd57`, `/health/db` HTTP 200.
- PostgreSQL CENTRAL : `pg_isready` OK, `SELECT 1` OK, Alembic `7544a84c3691`, `/health/db` HTTP 200.
- Résultat global : **PASS**.

## Batterie de non-régression finale

Les tests suivants ont retourné `[OK]` :

- `Test-RC41-Step3E-Fix7-Atomic-Empty-Switch.ps1` ;
- `Test-RC41-Step3E-Fix8-GetCrodipHome-Scope-State-Rollback.ps1` ;
- `Test-RC41-Step3E-Fix9-Topology-Port-Scope-Hardening.ps1` ;
- `Test-RC41-Step3E-Fix10-Central-Update-Alembic-Port-Reconciliation.ps1` ;
- `Test-RC41-Step3E-Fix11-Target-Release-Alembic-Context.ps1` ;
- `Test-RC41-Final-Qualification.ps1`.

Résultat : **6/6 OK**.

## Conclusion de qualification

Le scénario TEST `#15 OFFICIAL → #14 RECONSTRUCTED/EMPTY → #15 OFFICIAL` est qualifié sur le périmètre Runtime Manager RC41 : snapshots source, activation EMPTY explicite, isolation topologique, contexte Alembic cible, rollback/retour officiel, réconciliation des ports et vérification finale des bases.

Cette qualification ne transforme pas un snapshot `RECONSTRUCTED/EMPTY` en sauvegarde métier historique : les données métier historiques de la release cible y restent volontairement absentes.
