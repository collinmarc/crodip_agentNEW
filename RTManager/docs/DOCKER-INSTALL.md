# Installation des moteurs Docker — Runtime Manager 2.2.42

## Menu Administration Docker

Le Runtime Manager distingue maintenant clairement :

### Installation

```text
1. Installer Docker Desktop
2. Installer / préparer WSL2 + Ubuntu
3. Installer Docker Engine dans Ubuntu / WSL2
```

### Sélection du moteur

```text
4. Utiliser Docker Desktop
5. Utiliser Docker Engine Ubuntu / WSL2
6. État du provider Docker
```

## Docker Desktop

L'installation utilise Winget :

```powershell
winget install `
    --id Docker.DockerDesktop `
    --exact `
    --source winget
```

Le Runtime Manager doit être exécuté en mode administrateur pour cette opération.

## WSL2 + Ubuntu

Si Ubuntu n'est pas présent :

```powershell
wsl --install -d Ubuntu
```

Un redémarrage Windows peut être nécessaire.

## Docker Engine Ubuntu / WSL2

L'installation utilise le dépôt officiel Docker dans Ubuntu et installe :

- `docker-ce`
- `docker-ce-cli`
- `containerd.io`
- `docker-buildx-plugin`
- `docker-compose-plugin`

L'utilisateur Ubuntu est ajouté au groupe `docker`.

Après l'installation :

```powershell
wsl --shutdown
```

puis rouvrir Ubuntu.

## Important

Installer un moteur et sélectionner un moteur sont deux opérations distinctes.

Exemple :

```text
Installer Docker Engine Ubuntu
        ↓
wsl --shutdown
        ↓
Administration Docker
        ↓
Utiliser Docker Engine Ubuntu / WSL2
```
