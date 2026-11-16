# Release Notes — Runtime Manager 2.2.42 Stable

## Clarification Docker Desktop / WSL2

Le menu Administration Docker distingue désormais clairement deux parcours.

### Docker Desktop

```text
1. Installer Docker Desktop
2. Utiliser Docker Desktop
```

L'installation de Docker Desktop ne nécessite pas l'installation de la
distribution Ubuntu CRODIP. Docker Desktop utilise son propre environnement
WSL2 lorsque le backend WSL2 est sélectionné.

### Docker Engine sous WSL2

```text
3. Installer / préparer WSL2 + Ubuntu
4. Installer Docker Engine dans Ubuntu / WSL2
5. Utiliser Docker Engine Ubuntu / WSL2
```

Ubuntu est donc installé uniquement pour le parcours Docker Engine sous WSL2.

Les fonctions de registre, déploiement ONLINE/AUTO/OFFLINE et désinstallation
restent disponibles.
