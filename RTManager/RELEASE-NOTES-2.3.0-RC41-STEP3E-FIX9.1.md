# RC41 STEP3E FIX9.1 — qualification tests

FIX9.1 corrige uniquement les tests de qualification devenus incompatibles avec le hardening FIX9.

- Le test FIX9 utilisait des chaînes PowerShell en guillemets doubles contenant `$localBackend`,
  `$localFrontend` et les variables de restauration. Sous StrictMode, ces motifs étaient évalués
  comme des variables du test au lieu d'être comparés comme du texte.
- Le test de régression FIX8 exigeait encore l'ancien appel dynamique
  `$runtimeHome=Get-CrodipHome` dans `Sync-And-Redeploy`. FIX9 supprime volontairement cet appel
  et utilise `$script:resolvedCrodipHome`, résolu avant les scripts imbriqués. Le test accepte
  désormais les deux formes afin de préserver la régression FIX8 et qualifier le hardening FIX9.

Le code runtime FIX9, les ports, STEP3E et le rollback atomique FIX7 ne sont pas modifiés.
