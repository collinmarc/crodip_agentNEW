# RC41 STEP3E FIX6 — EMPTY Preflight Lifecycle

## Cause

Le chemin STEP3E lisait `cfgForEmpty.runtime.activeLifecycle`. Or `config/runtime.json` stocke le cycle actif sous `docker.activeLifecycle`. Sous StrictMode, l’accès au nœud inexistant `runtime` provoquait l’arrêt du précontrôle.

## Correction

`commands/17-historical-test-run.ps1` utilise désormais `cfgForEmpty.docker.activeLifecycle`.

## Qualification

Ajout de `Test-RC41-Step3E-Fix6-Empty-Preflight-Lifecycle.ps1`, qui vérifie la structure réelle de `runtime.json`, le parseur PowerShell et reproduit la lecture sous StrictMode. Aucun garde-fou STEP3B/STEP3E n’est assoupli.
