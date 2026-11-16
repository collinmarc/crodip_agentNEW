# RC41 STEP2 — garde-fou DOWN avant activation

Correction issue du test dynamique #15 vers #14.

- `Invoke-CrodipReleaseChangePreflight` est exécuté après résolution complète du candidat et avant toute invite `SWITCH-RUNTIME`.
- Un DOWNGRADE sans snapshot cible compatible est bloqué avant activation de la release cible.
- Un DOWNGRADE compatible reste volontairement non exécuté en STEP2 : la restauration DB sera activée en STEP3.
- Les UPGRADE conservent l’invite explicite `SWITCH-RUNTIME` après précontrôle et snapshot de sécurité.
