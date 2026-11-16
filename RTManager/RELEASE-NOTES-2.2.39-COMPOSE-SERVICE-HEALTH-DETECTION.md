# Release Notes — Runtime Manager 2.2.42 Stable

## Compose Service Health Detection

Depuis l'isolation Compose, les conteneurs Runtime sont nommés automatiquement :

```text
crodip-runtime-local-backend-1
crodip-runtime-local-frontend-1
```

Le Runtime ne recherche plus les anciens noms fixes `crodip-backend` et
`crodip-frontend`.

La détection s'appuie sur :

```text
docker compose ps --all --format json
```

et raisonne par service Compose :

```text
backend
frontend
```

États reconnus :

- RUNNING
- RESTARTING
- UNHEALTHY
- EXITED
- DEAD
- UNKNOWN

En cas de backend `RESTARTING`, le Runtime affiche automatiquement les 30
dernières lignes du journal du conteneur.

Le message final distingue désormais :

```text
[OK] Runtime démarré et services opérationnels.
```

de :

```text
[ATTENTION] Runtime démarré avec services non opérationnels.
```
