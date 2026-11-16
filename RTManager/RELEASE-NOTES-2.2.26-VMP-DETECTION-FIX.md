# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — Virtual Machine Platform Detection Fix

Cette version corrige le faux avertissement `Virtual Machine Platform = Unknown`
lorsque l'environnement démontre déjà que la chaîne de virtualisation est opérationnelle.

### Règle de qualification

Si l'état Windows de `VirtualMachinePlatform` est lisible, cet état reste prioritaire.

Si cet état est `Unknown`, le Runtime utilise des preuves opérationnelles :

- `HyperVisorPresent=True` ;
- WSL2 répond correctement ;
- Docker Engine répond correctement.

Lorsque ces preuves sont réunies, `Virtual Machine Platform` est classé `OK`
et ne dégrade plus le score du Runtime.

Le Runtime ne tente pas de réinstaller ou réactiver la fonctionnalité Windows
lorsque WSL2 et Docker sont déjà opérationnels.

### Résultat attendu

```text
[OK] Virtual Machine Platform
     Fonctionnalité opérationnelle via WSL2 ; HyperVisorPresent=True ; Docker Engine opérationnel

[OK] WSL2
[OK] Docker Engine

Score              : 100%
Erreurs critiques  : 0
Erreurs majeures   : 0
Avertissements     : 0

[OK] READY
```
