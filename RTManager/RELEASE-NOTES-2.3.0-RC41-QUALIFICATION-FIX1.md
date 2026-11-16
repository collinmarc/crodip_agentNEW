# Runtime Manager 2.3.0-RC41 — Qualification FIX1

## Objet

Correction du test de qualification finale RC41 uniquement. Le moteur STEP3D FIX2 validé en exécution réelle n'est pas modifié.

## Correction

Les helpers `Assert-Text` et `Assert-NotText` utilisaient les opérateurs PowerShell `-like` / `-notlike`. Les chaînes recherchées étaient donc interprétées comme des motifs wildcard. Le contrôle littéral `[string[]]$DockerArgs` pouvait ainsi échouer alors que le paramètre était bien présent.

FIX1 utilise désormais `String.Contains(..., StringComparison.Ordinal)` pour effectuer des recherches littérales déterministes.

## Périmètre

- `commands/21-reconstruct-historical-release-snapshot.ps1` : inchangé.
- `tests/Test-RC41-Step3D-Fix2-Reserved-Args.ps1` : inchangé.
- `tests/Test-RC41-Final-Qualification.ps1` : correction des assertions textuelles.

La qualification finale doit être rejouée après extraction du kit.
