# Release Notes — 2.2.42 Stable — Lot 5 Docker Install Parser Fix

## Correction

La 2.2.6 contenait dans `commands\03-start.ps1` une séquence littérale :

```powershell
"Crodip.Runtime.DockerProvider.Loader.psm1",`n    "Crodip.Runtime.Docker.psm1"
```

PowerShell interprétait `` `n `` comme un token inattendu dans le tableau.

La 2.2.42 remplace cela par un vrai retour à la ligne :

```powershell
"Crodip.Runtime.DockerProvider.Loader.psm1",
"Crodip.Runtime.Docker.psm1"
```

Le correctif est appliqué à tous les scripts PowerShell du kit et un test de parsing est ajouté.

## Test

```powershell
.\tests\Test-Lot5-PowerShellParser-227.ps1
```

Résultat attendu :

```text
[OK] Parsing PowerShell Lot 5 validé.
```
