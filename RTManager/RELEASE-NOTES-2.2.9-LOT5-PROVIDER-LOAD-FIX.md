# Release Notes — 2.2.42 Stable — Lot 5 Docker Provider Load Fix

## Cause racine

Le menu Administration Docker importait correctement le Provider.

Ensuite :

```text
Crodip.Runtime.Docker.psm1
Crodip.Runtime.Compose.psm1
```

réimportaient chacun `Crodip.Runtime.DockerProvider.psm1` avec `-Force`.

Ce rechargement supprimait/remplaçait l'instance globale du Provider et les
fonctions comme `Get-CrodipDockerProviderInfo` devenaient invisibles.

## Correction

Docker et Compose utilisent maintenant :

```powershell
if (-not (Get-Command Invoke-CrodipDockerCli -ErrorAction SilentlyContinue)) {
    Import-Module `
        (Join-Path $PSScriptRoot "Crodip.Runtime.DockerProvider.psm1") `
        -Global `
        -DisableNameChecking `
        -ErrorAction Stop
}
```

Ils ne rechargent donc plus le Provider lorsqu'il est déjà disponible.

Le menu vérifie également la présence des commandes Provider après le
chargement de Docker et Compose.

## Test

```powershell
.\tests\Test-Lot5-DockerProviderLoad-229.ps1
```

Résultat attendu :

```text
[OK] Docker Provider reste visible après Docker/Compose.
```
