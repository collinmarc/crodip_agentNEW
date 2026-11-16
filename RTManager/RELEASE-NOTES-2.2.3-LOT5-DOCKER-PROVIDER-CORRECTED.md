# Release Notes — 2.2.42 Stable — Lot 5 Docker Provider Corrected

## Correction

La version 2.2.2 pouvait appeler `Get-CrodipDockerProviderInfo` avant le chargement
du module `Crodip.Runtime.DockerProvider.psm1`.

La 2.2.42 corrige :

- l'import explicite du module DockerProvider dans `03-start.ps1` ;
- l'import dans les scripts qui utilisent les fonctions provider ;
- les dépendances des modules Docker et Compose ;
- un test de non-régression dédié.

## Test

```powershell
.\tests\Test-Lot5-DockerProvider-Imports.ps1
```

Résultat attendu :

```text
[OK] Import DockerProvider validé dans le Runtime.
```
