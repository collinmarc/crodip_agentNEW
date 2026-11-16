# Release Notes — Lot 3 Corrected

Correction de l'erreur :

```text
Error formatting a string: Index (zero based) must be greater than
or equal to zero and less than the size of the argument list.
```

Les opérateurs `-f` utilisés directement dans les appels `.Add()` ont été
remplacés par des expressions formatées dans des variables intermédiaires.

Fichiers concernés :

- `modules/Crodip.Runtime.Health.psm1`
- `tests/Test-Lot3-Formatting.ps1`
