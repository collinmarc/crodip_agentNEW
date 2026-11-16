# Docker Provider — Docker Desktop ou Docker Engine Ubuntu/WSL2

## Objectif

Le Runtime Manager 2.2.42 permet de choisir explicitement le moteur Docker utilisé par CRODIP :

- `desktop` : Docker Desktop sous Windows ;
- `ubuntu` : Docker Engine installé directement dans une distribution Ubuntu WSL2.

Le choix est persistant dans `.env` :

```dotenv
CRODIP_DOCKER_PROVIDER=desktop
CRODIP_WSL_DISTRO=Ubuntu
```

## Choix depuis le Runtime Manager

```text
Administration Docker
9. Utiliser Docker Desktop
10. Utiliser Docker Engine Ubuntu / WSL2
11. État du provider Docker
```

## Docker Desktop

Prérequis :

- Docker Desktop installé ;
- backend WSL2 activé ;
- Docker Engine démarré.

Le Runtime Manager peut démarrer automatiquement Docker Desktop.

## Docker Engine Ubuntu / WSL2

Prérequis dans Ubuntu :

```bash
docker --version
docker compose version
docker info
```

Si le service n'est pas démarré :

```bash
sudo service docker start
```

ou, si systemd est actif :

```bash
sudo systemctl start docker
```

Pour permettre à l'utilisateur Ubuntu d'utiliser Docker sans `sudo` :

```bash
sudo usermod -aG docker $USER
```

Puis fermer complètement la session WSL :

```powershell
wsl --shutdown
```

et rouvrir Ubuntu.

## Fonctionnement

En mode `ubuntu`, le Runtime Manager n'utilise pas le moteur Docker Desktop. Les commandes sont exécutées via :

```text
wsl.exe -d Ubuntu -- docker ...
```

Pour Docker Compose, le chemin Windows du runtime est automatiquement converti en chemin WSL (`C:\...` vers `/mnt/c/...`).

## Recommandation

- Poste utilisateur/runtime standard : **Docker Desktop**, plus simple à administrer.
- Poste maîtrisé ou environnement sans Docker Desktop : **Docker Engine Ubuntu/WSL2**.
- Ne pas faire fonctionner les deux moteurs pour la même stack au même moment : leurs images, conteneurs et volumes sont distincts.

## Correctif 2.2.42 — Scope PowerShell

Le module `DockerProvider` est chargé via un module Loader.

PowerShell importe normalement les modules dans le scope du module appelant.
La version 2.2.42 utilise donc explicitement :

```powershell
Import-Module `
    -Name $providerPath `
    -Global
```

afin que les commandes telles que :

```powershell
Get-CrodipDockerProviderInfo
Install-CrodipDockerDesktop
Install-CrodipUbuntuDockerEngine
```

soient visibles dans les scripts `commands\*.ps1`.

## Correctif 2.2.42 — persistance du choix du provider

La fonction `Set-CrodipDockerProvider` n'utilise plus une variable
`$script:lines`.

La configuration est maintenant reconstruite localement puis écrite dans :

```text
C:\Program Files\CRODIP\.env
```

Exemple Docker Desktop :

```dotenv
CRODIP_DOCKER_PROVIDER=desktop
```

Exemple Ubuntu / WSL2 :

```dotenv
CRODIP_DOCKER_PROVIDER=ubuntu
CRODIP_WSL_DISTRO=Ubuntu
```

Le choix est également appliqué immédiatement à la session PowerShell
courante.
