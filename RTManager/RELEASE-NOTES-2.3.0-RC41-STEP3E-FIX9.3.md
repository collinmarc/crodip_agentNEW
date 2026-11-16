# RC41 STEP3E FIX9.3 — correction finale du test de régression FIX8

Aucun changement du runtime FIX9.

Le test FIX8/FIX9 utilisait encore `$c17` comme chemin alors que cette variable n'était
pas initialisée dans ce script. Il construit désormais explicitement le chemin
`commands\17-historical-test-run.ps1`, vérifie son existence, puis charge son contenu.

Les mécanismes STEP3E, FIX7, FIX9 et le plan de ports ne sont pas modifiés.
