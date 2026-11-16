# Release Notes — v2.2.1 Stable Lot 2 Clean

Ce lot repart du Lot 1 validé et remplace entièrement les correctifs successifs
du Lot 2.

## Sous-menu Installation

- Installer
- Réparer
- Vérifier l'installation
- Réinstaller
- Désinstaller
- Retour

## Sécurité

- données métier conservées par défaut lors de la désinstallation ;
- prise en charge de `-WhatIf` ;
- variables locales sans conflit avec `$HOME` ;
- conditions `Test-Path` parenthésées ;
- variables d'environnement gérées par le module Windows ;
- raccourcis Bureau et menu Démarrer.

## Test

```powershell
.\tests\Test-Lot2-Clean.ps1
```
