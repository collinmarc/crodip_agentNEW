# Release Notes — 2.2.42 Stable — Lot 5 WSL Docker Readiness

## Correction majeure

Le Runtime distinguait mal :

- Docker Desktop installé ;
- Docker Desktop lancé ;
- moteur Docker Linux réellement disponible.

La 2.2.42 ajoute une qualification explicite de WSL2 avant tout accès GHCR.

## Nouveau flux

```text
Provider = Docker Desktop
        ↓
Docker Desktop installé ?
        ↓
WSL2 installé ?
        ↓
Engine Docker Linux répond ?
        ↓
docker compose pull
```

Si WSL2 est absent, le Runtime ne tente plus le `pull` et indique l'action correcte.

## Administration Docker

L'option :

```text
2. Installer / préparer WSL2 + Ubuntu
```

utilise désormais le prérequis WSL2 dédié et signale lorsqu'un redémarrage est recommandé.

## Test

```powershell
.\tests\Test-Lot5-WslDockerReadiness-2210.ps1
```
