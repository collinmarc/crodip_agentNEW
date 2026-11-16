# Release Notes — Runtime Manager 2.2.42 Stable

## Compose Project Isolation

La nomenclature Docker distingue désormais explicitement le Runtime local :

```yaml
name: crodip-runtime-local
```

Les `container_name` fixes `crodip-backend` et `crodip-frontend` sont supprimés.
Docker Compose génère donc des noms isolés :

```text
crodip-runtime-local-backend-1
crodip-runtime-local-frontend-1
```

Convention cible globale :

```text
crodip-dev-local
crodip-runtime-local
crodip-central
```

Cette convention permet de distinguer le backend/frontend local de
développement, le backend/frontend Runtime terrain et les services centraux.

## Migration d'une installation existante

Au démarrage, si le Runtime détecte :

```yaml
name: crodip-local
container_name: crodip-backend
container_name: crodip-frontend
```

il propose une migration vers l'isolation Runtime locale. Le `compose.yaml`
est sauvegardé avant modification.

## Ports

La suppression des noms fixes résout les collisions de noms de conteneurs.
Elle ne résout pas une collision de ports si DEV et Runtime tournent en même
temps. Le démarrage contrôle donc aussi les ports publiés et signale ceux qui
sont déjà occupés.

Les ports restent configurables via `.env`.
