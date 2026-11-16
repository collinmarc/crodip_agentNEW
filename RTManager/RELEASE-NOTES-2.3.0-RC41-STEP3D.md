# CRODIP SaaS Runtime Manager 2.3.0-RC41 — STEP3D

## Isolated Historical Release Reconstruction

STEP3D complète STEP3C lorsqu'aucune sauvegarde historique authentifiable n'existe pour une release cible.

- résolution de la release officielle via le moteur STEP3C/FIX3 ;
- reconstruction **isolée** d'une SQLite LOCAL vide au head Alembic de l'image historique ;
- reconstruction **isolée** d'un PostgreSQL 17 CENTRAL temporaire au head Alembic de l'image historique ;
- génération d'un dump PostgreSQL et d'une archive compatible avec la structure des snapshots RC41 ;
- identité explicite `origin=reconstructed`, `dataState=EMPTY`, `historicalBusinessData=false` ;
- aucune lecture/écriture/restauration des bases LOCAL/CENTRAL actives ;
- nettoyage systématique du conteneur PostgreSQL, du réseau Docker et du workspace temporaire ;
- le snapshot reconstruit reste `RECONSTRUCTED_READY_NOT_AUTO_RESTORABLE` : STEP3B ne l'utilise pas automatiquement pour un DOWNGRADE.

### Test

```powershell
pwsh.exe -NoProfile -ExecutionPolicy Bypass `
  -File .\tests\Test-RC41-Step3D-Isolated-Historical-Release-Reconstruction.ps1
```

### Reconstruction du Build #14

```powershell
pwsh.exe -NoProfile -ExecutionPolicy Bypass `
  -File .\commands\21-reconstruct-historical-release-snapshot.ps1 `
  -RunNumber 14
```
