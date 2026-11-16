# Qualification technique — Runtime Manager 2.3.0-RC40

**Date :** 29/09/2026  
**Application :** `2.3.0-dev.4`  
**Build officiel :** `#15` / Run ID `36452467983`  
**Commit :** `53928c1f30a8a90cc6a1cf467d5c332f10494a80`

## Résultats observés

| Contrôle | Résultat |
|---|---|
| LOCAL AUTO → ONLINE | PASS |
| CENTRAL AUTO → ONLINE | PASS |
| LOCAL OFFLINE sans pull | PASS |
| CENTRAL OFFLINE sans pull | PASS |
| CENTRAL `postgres:17` disponible en OFFLINE | PASS |
| LOCAL Alembic release=image=database `ecd67252fd57` | PASS |
| CENTRAL Alembic release=image=database `7544a84c3691` | PASS |
| CENTRAL sauvegarde PRE-MIGRATION avant migration | PASS |
| Digests officiels LOCAL/CENTRAL | PASS |
| Persistance du mode configuré | PASS |

La qualification technique Runtime produit `C:\ProgramData\CRODIP\qualification\runtime-qualification.json`, incluant le moteur de base, `releaseExpectedHead`, `imageHead`, `databaseCurrent` et le booléen de compatibilité pour LOCAL et CENTRAL.

La qualification reste technique ; AUTH/RBAC/métier/offline applicatif/synchronisation ne sont pas déclarés fonctionnellement qualifiés par cet artefact.
