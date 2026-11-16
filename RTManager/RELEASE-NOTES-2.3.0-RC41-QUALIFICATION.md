# Runtime Manager 2.3.0-RC41 — Qualification finale

## Objet
Qualification intégrée du changement transactionnel de release et du rollback RC41.

## Invariants qualifiés
- Un snapshot historique authentique `release-snapshot.json` reste le seul type éligible à la restauration automatique STEP3B.
- Un snapshot reconstruit STEP3D est explicitement `backupMode=reconstructed`, `dataState=EMPTY` et `RECONSTRUCTED_READY_NOT_AUTO_RESTORABLE`.
- L'absence de snapshot historique authentique bloque un DOWNGRADE avant l'invite d'activation.
- Un snapshot de sécurité de la release courante est créé avant changement de release et sert au rollback DB en cas d'échec d'activation.
- STEP3D FIX2 utilise `DockerArgs` et ne réintroduit pas la variable automatique PowerShell `$args` comme paramètre.
- Les bases actives ne sont jamais utilisées comme cible de reconstruction STEP3D.

## Qualification réelle déjà obtenue — run #14
- Release : `2.3.0-dev.3`
- Run ID : `35976894313`
- SQLite LOCAL reconstruite : head `d24d83ea9494`
- PostgreSQL CENTRAL reconstruite : head `3452c4fc44ba`
- Snapshot : qualifié, `EMPTY`, non éligible au DOWNGRADE automatique STEP3B
- Bases actives modifiées : NON

## Test final
```powershell
pwsh.exe -NoProfile -ExecutionPolicy Bypass `
  -File .\tests\Test-RC41-Final-Qualification.ps1
```

La validation de ce test clôt la qualification structurelle intégrée RC41. Les essais réels de restauration d'un snapshot authentique restent conditionnés à la disponibilité d'un tel snapshot historique.
