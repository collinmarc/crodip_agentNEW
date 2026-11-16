# RC41 STEP3E FIX8 — Get-CrodipHome Scope & Transaction State Hardening

Le test réel FIX7.1 a démontré le rollback atomique : après une erreur post-restauration EMPTY, le snapshot source #15, les images #15 et les heads Alembic #15 ont été restaurés puis qualifiés GLOBAL PASS.

L'erreur déclenchante était `Get-CrodipHome` indisponible dans `commands/17-historical-test-run.ps1` après les réimports de modules effectués par les scripts enfants. Le script utilisait ce helper dans `Sync-And-Redeploy` sans importer explicitement `Crodip.Runtime.Windows.psm1` dans son propre scope.

FIX8 ajoute cette dépendance explicite. Il ne modifie ni le séquencement atomique FIX7, ni les règles STEP3B/STEP3E.

Le nouveau test `Test-RC41-Step3E-Fix8-GetCrodipHome-Scope-State-Rollback.ps1` vérifie : parsing, import Windows explicite, résolution réelle de `Get-CrodipHome`, et restauration de `runtime.json` / `test-override.json` avant le redéploiement source en cas de rollback.
