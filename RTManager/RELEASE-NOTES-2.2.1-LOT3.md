# Release Notes — v2.2.1 Stable Lot 3

Le Lot 3 introduit le Runtime Dashboard et le Health Check modulaire.

## Nouveautés

- module `Crodip.Runtime.Health.psm1` ;
- contrat de résultat commun pour tous les contrôles ;
- score global ;
- gravités CRITICAL, MAJOR, IMPORTANT, MINOR et INFO ;
- statuts READY, READY WITH WARNINGS et NOT READY ;
- rapports TXT, Markdown et JSON ;
- historique automatique des rapports ;
- mode silencieux `-Quiet`.

## Test

```powershell
.\tests\Test-Lot3-Health.ps1
```
