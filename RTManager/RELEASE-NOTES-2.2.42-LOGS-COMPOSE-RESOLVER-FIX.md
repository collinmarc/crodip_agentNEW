# Release Notes — Runtime Manager 2.2.42 Stable

## Logs Compose Resolver Fix

Le menu `9. Journaux` utilisait encore l'ancienne fonction :

```powershell
Find-CrodipComposeFile
```

qui n'existe plus dans le Runtime actuel.

La 2.2.42 utilise désormais :

```powershell
Get-CrodipComposeFile
```

et reste compatible avec le projet Compose isolé :

```text
crodip-runtime-local
```

Le menu Journaux ne dépend plus des anciens noms fixes :

```text
crodip-backend
crodip-frontend
```

Les journaux sont résolus par service Compose `backend` / `frontend`.
