# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — Dashboard WSL Fix

Le dashboard 2.2.11 pouvait afficher son rapport puis échouer avec :

```text
The term 'Add-CrodipCheckResult' is not recognized
```

Le contrôle WSL2 utilise maintenant directement la collection native `$checks`
du dashboard avec des objets `PSCustomObject`.

Le dashboard peut ainsi afficher WSL2, calculer son score et terminer sans
exception secondaire.

## Test

```powershell
.\tests\Test-Lot5-DashboardWsl-2212.ps1
```
