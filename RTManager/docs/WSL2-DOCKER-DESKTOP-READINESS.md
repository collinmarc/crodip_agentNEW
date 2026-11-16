# WSL2 et Docker Desktop — qualification avant démarrage

## Principe

Le Runtime Manager 2.2.42 ne considère plus Docker Desktop comme prêt
simplement parce que l'application est installée ou lancée.

Il vérifie désormais :

```text
Docker Desktop installé ?
        ↓
WSL2 installé ?
        ↓
Moteur Linux Docker répond ?
        ↓
READY
```

Si WSL2 est absent, le Runtime affiche explicitement :

```text
[ERREUR] WSL2 n'est pas installé.
[ATTENTION] Administration Docker > Installer / préparer WSL2 + Ubuntu.
```

## Installation WSL2

Depuis Administration Docker :

```text
2. Installer / préparer WSL2 + Ubuntu
```

Le Runtime exécute :

```powershell
wsl --install -d Ubuntu
wsl --set-default-version 2
```

Un redémarrage Windows peut être requis.

## Diagnostics

```powershell
wsl --version
wsl --status
wsl -l -v
docker info
docker version
```

Une erreur de type :

```text
dockerDesktopLinuxEngine/_ping
500 Internal Server Error
```

est traitée comme une indisponibilité du moteur local, pas comme une erreur GHCR.
