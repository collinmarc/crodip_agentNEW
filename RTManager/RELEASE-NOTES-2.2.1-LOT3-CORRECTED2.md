# Release Notes — Lot 3 Corrected2

Correction de l'affichage des recommandations dans le Runtime Dashboard.

## Comportement corrigé

Une recommandation `Correction : ...` n'est maintenant produite et affichée
que lorsque le statut du contrôle est différent de `OK`.

Le correctif s'applique :

- aux objets retournés par le module Health ;
- à l'affichage console du Dashboard ;
- au rapport TXT ;
- au rapport Markdown.

## Test

```powershell
.\tests\Test-Lot3-CorrectionDisplay.ps1
```
