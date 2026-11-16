# Release Notes — 2.2.1 Stable

Cette version corrige l'erreur :

```text
Write-CrodipSuccess: The term 'Write-CrodipSuccess' is not recognized
```

Toutes les fonctions sont désormais exportées explicitement par leurs modules.

Un test de fumée vérifie les commandes essentielles :

```powershell
.\tests\Test-ModuleExports.ps1
```
