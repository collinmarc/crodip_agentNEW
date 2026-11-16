# Runtime Manager 2.3.0-RC41 — STEP3E FIX4

## Cause réelle

Le FIX3 rendait `ReleaseRollback` autonome en important `Crodip.Runtime.Common.psm1`, mais utilisait
`Import-Module ... -Force`. Dans le chemin réel de l'option 8, `Common` était déjà chargé au niveau
appelant. Le rechargement forcé depuis le module imbriqué pouvait retirer/remplacer les commandes
exportées dans le scope appelant. La première commande touchée était
`Get-CrodipTestOverrideStatePath`.

## Correction

`Crodip.Runtime.ReleaseRollback.psm1` :
- réutilise le module `Crodip.Runtime.Common` déjà chargé ;
- n'importe Common que s'il est absent ;
- ne force plus son rechargement imbriqué.

## Qualification

`Test-RC41-Step3E-Fix4-Menu8-Module-Closure.ps1` démarre un nouveau PowerShell, importe les modules
dans le même ordre que `commands/17-historical-test-run.ps1`, puis vérifie que les commandes Common,
STEP3B et STEP3E restent toutes résolues.

Les garde-fous STEP3B/STEP3E ne sont pas modifiés.
