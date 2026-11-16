# Release Notes — Lot 4 Corrected

Correction du choix **8. Mettre à jour**.

## Comportement

La mise à jour effectue volontairement une sauvegarde rapide de sécurité avant
les opérations Docker.

## Corrections

- chargement explicite de `Crodip.Runtime.Compose.psm1` ;
- remplacement de `Find-CrodipComposeFile` par `Get-CrodipComposeFile` ;
- en-tête `08-update.ps1` affiché avant la sauvegarde ;
- messages explicites pour la sauvegarde, le pull et le redémarrage ;
- prise en charge de `-WhatIf` ;
- contrôle des codes de sortie Compose.
