# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — VMP Script Header Fix

Correction d'une erreur de structure PowerShell introduite en 2.2.26.

La fonction `Resolve-CrodipVirtualMachinePlatformStatus` avait été placée avant :

```powershell
[CmdletBinding()]
param(...)
```

Dans un script PowerShell avancé, `[CmdletBinding()]` et `param(...)` doivent rester
dans l'en-tête du script. La fonction est désormais déclarée après le bloc `param`.

La logique de détection Virtual Machine Platform de la 2.2.26 est conservée.
