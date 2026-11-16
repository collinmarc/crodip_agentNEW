# Release Notes — 2.2.42 Stable — Lot 5 Docker Install Scope Fix

## Cause racine

Le module `Crodip.Runtime.DockerProvider.psm1` était importé depuis
`Crodip.Runtime.DockerProvider.Loader.psm1`.

Sans `-Global`, PowerShell place les commandes importées dans le scope
du module Loader. Elles ne sont donc pas visibles depuis
`commands\11-docker-admin.ps1`.

## Correction

Le Loader utilise maintenant :

```powershell
Import-Module `
    -Name $providerPath `
    -Force `
    -PassThru `
    -Global `
    -DisableNameChecking `
    -ErrorAction Stop
```

Le menu Administration Docker effectue également une validation immédiate
de `Get-CrodipDockerProviderInfo`.

## Test recommandé

```powershell
Get-ChildItem -Recurse -File | Unblock-File

.\tests\Test-Lot5-DockerProvider-Scope-226.ps1

.\bootstrap-runtime.ps1
```

Puis choisir :

```text
10. Administration Docker
```
