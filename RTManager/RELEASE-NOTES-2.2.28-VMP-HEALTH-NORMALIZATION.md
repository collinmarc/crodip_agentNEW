# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — VMP Health Normalization

La 2.2.27 affichait encore `Virtual Machine Platform = Unknown` car la
normalisation était exécutée après `Get-CrodipRuntimeHealth`, après le calcul
du score et après la génération des rapports.

La 2.2.42 déplace la logique dans `Crodip.Runtime.Health.psm1`, au moment où
le résultat VMP est créé.

### Règle

- état Windows `Enabled` : `OK` ;
- état `Unknown` + `HypervisorPresent=True` + WSL2 opérationnel +
  Docker Engine opérationnel : `OK` par preuve d'exécution ;
- sinon : `WARNING`.

Ainsi le dashboard, le score et les rapports TXT/Markdown/JSON utilisent tous
la même qualification.

### Cas attendu sur le poste qualifié

```text
[OK] Virtual Machine Platform
     OperationalByEvidence ; HyperVisorPresent=True ; WSL2 opérationnel ; Docker Engine opérationnel

Score              : 100%
Erreurs critiques  : 0
Erreurs majeures   : 0
Avertissements     : 0

[OK] READY
```
