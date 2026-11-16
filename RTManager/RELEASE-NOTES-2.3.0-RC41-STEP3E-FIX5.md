# RC41 STEP3E FIX5 — Scoped Common Dependency

`Crodip.Runtime.ReleaseRollback` importe désormais systématiquement `Crodip.Runtime.Common`
dans son propre scope, sans `-Force`. Cela conserve les exports Common du menu tout en rendant
`Get-CrodipRuntimeConfig` et `Get-CrodipPersistentTestOverride` disponibles dans ReleaseRollback.

Le nouveau test FIX5 reproduit l'ordre réel des modules du menu 8, vérifie les deux scopes et
exécute `Get-CrodipEffectiveReleaseIdentity`. Les garde-fous STEP3B/STEP3E restent inchangés.
