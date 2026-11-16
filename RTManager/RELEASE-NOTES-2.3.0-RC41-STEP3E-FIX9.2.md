# RC41 STEP3E FIX9.2 — robustesse des tests

Aucun changement du runtime FIX9.

- Le test FIX9 n'utilise plus une regex fragile pour extraire `Sync-And-Redeploy`.
  Il analyse l'AST PowerShell et recherche uniquement un véritable appel exécutable
  à `Get-CrodipHome` dans la fonction. Les commentaires FIX9 ne créent donc plus de faux positif.
- Le test de compatibilité FIX8 sépare explicitement le chemin de command 17 de son contenu
  avant d'effectuer les assertions `.Contains()`, supprimant le cas `$null` observé.

Le plan canonique TEST reste :
LOCAL 8110/9110 ; CENTRAL 8120/9120.
