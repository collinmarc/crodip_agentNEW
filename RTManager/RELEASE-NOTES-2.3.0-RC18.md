# CRODIP Runtime Manager 2.3.0-RC18

## Correctif Runtime TEST / publication des ports

RC18 corrige le cas où une variable d'environnement PowerShell héritée du DEV (par exemple `CRODIP_FRONTEND_PORT=9010`) prenait priorité sur le `.env` Runtime TEST (`9110`).

Au démarrage LOCAL, le manager impose désormais dans le processus courant les ports du cycle de vie actif issus de `config/runtime.json`. Pour TEST : backend `8110`, frontend `9110`.

Le `docker compose up` du Runtime est également exécuté avec `--force-recreate` afin qu'un conteneur frontend existant créé sans publication de port soit recréé avec le mapping attendu (`9110:80`).

Contrôle attendu après démarrage :

- backend : `0.0.0.0:8110->8000/tcp`
- frontend : `0.0.0.0:9110->80/tcp`
