# Runtime Manager 2.3.0-RC17

## Objet

Correction de la politique de ports du Runtime TEST installé.

## Contrat

- TEST / LOCAL : backend `8110`, frontend `9110`.
- TEST / CENTRAL : backend `8120`, frontend `9120`.
- `9010` reste réservé au frontend DEV / LOCAL.

## Correctif

La synchronisation du `.env` ne se limite plus aux références d'images Docker : elle recalcule aussi les ports depuis `docker.activeLifecycle` et `docker.lifecyclePorts` de `config/runtime.json`. Ainsi, un ancien `.env` contenant `CRODIP_FRONTEND_PORT=9010` est réaligné sur `9110` lorsque le profil actif est TEST/LOCAL.
