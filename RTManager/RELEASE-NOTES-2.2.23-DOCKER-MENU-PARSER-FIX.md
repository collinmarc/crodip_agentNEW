# Release Notes — Runtime Manager 2.2.42 Stable

## Docker Menu Parser Fix

La 2.2.22 contenait un switch PowerShell mal réassemblé dans
`commands\11-docker-admin.ps1`, provoquant des erreurs de parsing sur les
choix 3, 4, 5, etc.

La 2.2.42 reconstruit entièrement le script Administration Docker avec un
switch propre de 1 à 19.

Un test de parsing PowerShell est inclus :

```powershell
.\tests\Test-Lot5-DockerMenuParser-2223.ps1
```
