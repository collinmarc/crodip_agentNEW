# CRODIP Runtime Manager 2.3.0-RC20

## Correctif

RC20 corrige le défaut RC19 où `Repair-CrodipRuntimePublishedPortBindings` était définie après `Export-ModuleMember` et n’était donc pas exportée par `Crodip.Runtime.Compose.psm1`.

- export final déplacé après toutes les définitions ;
- export explicite de `Repair-CrodipRuntimePublishedPortBindings` et `Test-CrodipRuntimePublishedPortBindings` ;
- garde `Get-Command` au démarrage ;
- conservation du contrôle TEST/LOCAL 8110/9110 ;
- conservation de la réconciliation automatique des anciens PortBindings Docker ;
- test de non-régression dédié.
