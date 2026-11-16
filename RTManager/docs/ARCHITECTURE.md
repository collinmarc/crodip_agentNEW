# Architecture Runtime Manager 2.3.0-RC41

RC41 orchestre les topologies TEST LOCAL et CENTRAL et ajoute un moteur transactionnel de changement de release lié à l'état des bases. La release officielle courante reste `2.3.0-dev.4`, Build #15 / Run `36452467983`, commit `53928c1f30a8a90cc6a1cf467d5c332f10494a80`.

## Topologies TEST

- **LOCAL** : frontend `9110`, backend `8110`, SQLite.
- **CENTRAL** : frontend `9120`, backend `8120`, PostgreSQL 17 persistant.

## Transaction de release RC41

Avant un changement, RC41 crée un snapshot de sécurité de la source. En DOWNGRADE, un snapshot cible authentique et compatible est privilégié. À défaut, un snapshot `RECONSTRUCTED/EMPTY` qualifié peut être utilisé uniquement en TEST avec confirmation explicite. Les bases sont restaurées en mode STAGÉ, puis les images cibles sont déployées avant qualification. Le contexte Alembic cible est injecté au scope `Process`; après transaction ou rollback, la configuration officielle redevient la source de vérité.

L'invariant de qualification est `releaseExpectedHead = imageHead = databaseCurrent`. Aucun `alembic downgrade` automatique n'est exécuté. En cas d'échec après modification DB, le snapshot source et l'état de release doivent être restaurés avant redéploiement source.

## Qualification RC41

Le 30/09/2026, le cycle réel #15 → #14 RECONSTRUCTED/EMPTY → #15 a été validé avec `GLOBAL PASS`, puis la batterie FIX7 à FIX11 et la qualification finale ont retourné 6/6 `[OK]`. Voir `QUALIFICATION-RC41.md`.

---

# Architecture Runtime Manager 2.3.0-RC40

Le Runtime Manager orchestre deux topologies applicatives TEST sans rebuild :

- **LOCAL** : frontend `9110`, backend `8110`, SQLite, images LOCAL par digest.
- **CENTRAL** : frontend `9120`, backend `8120`, PostgreSQL 17 persistant, images CENTRAL par digest.

La source de vérité applicative courante est la release `2.3.0-dev.4`, Build officiel `#15` / Run ID `36452467983`, commit `53928c1f30a8a90cc6a1cf467d5c332f10494a80`, politique `build-once-promote-same-digest`.

## Connectivité

`CRODIP_DEPLOYMENT_MODE` accepte `auto`, `online`, `offline`; `auto` est le défaut. AUTO sélectionne ONLINE si le registre est accessible, sinon OFFLINE. OFFLINE interdit les pulls et exige la présence locale de toutes les images du Compose ; CENTRAL inclut `postgres:17`.

## Compatibilité base/release

RC40 impose `releaseExpectedHead = imageHead = databaseCurrent`. Heads qualifiés : LOCAL `ecd67252fd57`, CENTRAL `7544a84c3691`. CENTRAL réalise une sauvegarde PRE-MIGRATION obligatoire avant modification. Aucun downgrade ou restore automatique n'est autorisé.

## Qualification

La qualification technique couvre conteneurs, digests, ports, endpoints, moteurs DB et compatibilité Alembic des deux topologies. L'artefact est écrit sous `C:\ProgramData\CRODIP\qualification\runtime-qualification.json`.
