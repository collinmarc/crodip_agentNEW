# Runtime Manager 2.3.0-RC9

## GitHub
- Correction de l'interpolation PowerShell `${Path}?ref=$Ref`.
- Conservation du GET GitHub API et du schéma officiel v1.

## Composants techniques
- Nouveau menu 16 `Composants techniques`.
- Installation/réparation et désinstallation GitHub CLI.
- Installation/désinstallation Docker Desktop.
- Installation/préparation WSL2 + Ubuntu.
- Suppression explicite d'une distribution WSL.
- Désactivation des composants Windows WSL2.
- Désinstallation complète Docker + Ubuntu + WSL2.

## Sécurité
- Aucun composant partagé n'est supprimé par la désinstallation standard du Runtime.
- Les désinstallations techniques demandent une confirmation explicite.
- Les opérations destructives WSL sont clairement signalées.
