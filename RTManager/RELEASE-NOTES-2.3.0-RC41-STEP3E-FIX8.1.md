# RC41 STEP3E FIX8.1 — Test variable HOME collision

FIX8.1 corrige uniquement le test
`Test-RC41-Step3E-Fix8-GetCrodipHome-Scope-State-Rollback.ps1`.

PowerShell est insensible à la casse pour les noms de variables : `$home` entre donc
en collision avec la variable automatique `$HOME`, qui est en lecture seule.
La variable locale du test est renommée `$crodipHome`.

Le code runtime FIX8, le séquencement STEP3E et le rollback atomique FIX7 ne sont pas modifiés.
