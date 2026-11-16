# Release Notes — Runtime Manager 2.2.42 Stable

## Installed Compose Normalization

La 2.2.35 normalisait le template du kit mais une installation existante pouvait
conserver son ancien fichier :

```text
C:\Program Files\CRODIP\compose.yaml
```

avec :

```yaml
name: crodip-local
container_name: crodip-backend
container_name: crodip-frontend
```

La 2.2.42 normalise désormais aussi le Compose déjà installé.

Cible :

```yaml
name: crodip-runtime-local
```

sans `container_name` fixe.

La normalisation est appelée lors :
- de l'installation ;
- de la réparation ;
- de la réinstallation ;
- du démarrage.

Une sauvegarde horodatée du Compose est créée avant toute modification.
