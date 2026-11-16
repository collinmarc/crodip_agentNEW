# Désinstallation Docker Desktop / WSL2 — Runtime 2.2.42

## Menu

```text
15. Désinstaller Docker Desktop
16. Supprimer Ubuntu / distribution WSL
17. Désactiver les composants Windows WSL2
18. Désinstallation complète Docker + Ubuntu + WSL2
19. Retour
```

Les opérations destructives demandent une confirmation textuelle explicite.

`wsl --unregister Ubuntu` supprime définitivement les données de la distribution Ubuntu.

La désactivation WSL2 agit sur :

```text
Microsoft-Windows-Subsystem-Linux
VirtualMachinePlatform
```

Les répertoires Windows CRODIP ne sont pas supprimés automatiquement :

```text
C:\Program Files\CRODIP
C:\ProgramData\CRODIP
%LOCALAPPDATA%\CRODIP
```

En revanche, la désinstallation Docker Desktop ou la suppression d'Ubuntu peut supprimer
des images, conteneurs, volumes ou données Linux propres à ces environnements.
