# Release Notes — 2.2.42 Stable — Lot 5 Docker Menu Fix

## Correction principale

Le choix `10. Administration Docker` utilise maintenant directement :

```powershell
.\commands\11-docker-admin.ps1
```

Le script `11-docker-admin.ps1` importe directement :

```powershell
Crodip.Runtime.DockerProvider.psm1
```

avec `-Global`, sans passer par `DockerProvider.Loader`.

## Pourquoi

Les versions précédentes cumulaient des problèmes de scope PowerShell entre :

```text
bootstrap-runtime.ps1
        ↓
DockerProvider.Loader.psm1
        ↓
DockerProvider.psm1
```

La 2.2.42 simplifie la chaîne :

```text
bootstrap-runtime.ps1
        ↓
commands\11-docker-admin.ps1
        ↓
Crodip.Runtime.DockerProvider.psm1
```

## Test

```powershell
.\tests\Test-Lot5-DockerMenu-228.ps1
```

Résultat attendu :

```text
[OK] Choix 10 et import direct Docker Provider validés.
```
