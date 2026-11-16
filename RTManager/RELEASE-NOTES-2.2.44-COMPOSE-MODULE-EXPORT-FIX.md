# Runtime Manager 2.2.44 — Compose Module Export Fix

## Défaut corrigé

Pendant l'installation 2.2.43, la normalisation pouvait afficher :

`Get-CrodipComposeFile is not recognized`

La fonction était bien définie dans `Crodip.Runtime.Compose.psm1`, mais elle n'était pas exportée
par le module.

## Correction

Le module exporte maintenant explicitement :

- `Get-CrodipComposeFile`
- `Invoke-CrodipCompose`
- `Repair-CrodipRuntimeComposeIsolation`
- `Test-CrodipRuntimePortAvailability`
- `Get-CrodipComposeServiceRuntimeStatus`
- `Get-CrodipComposeServiceStatusByName`

La commande `01-normalize-compose.ps1` peut ainsi résoudre le Compose installé après import du module.

La nomenclature introduite en 2.2.43 reste inchangée :
- Runtime LOCAL : `crodip-runtime-local`
- images : `crodip-local-backend` / `crodip-local-frontend`
- CENTRAL : `crodip-central`
