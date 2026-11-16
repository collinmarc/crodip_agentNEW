# CRODIP Runtime Manager v2.2.46 Stable

## Centralized Docker Image Tag Fix

`config/runtime.json` devient la source de vérité unique pour la version des images Docker.

```json
"docker": {
  "imageTag": "2.2.1"
}
```

Les repositories sont définis séparément dans `docker.imageRepositories`, sans tag.

Les images effectives sont construites automatiquement :

- LOCAL backend : `ghcr.io/idwebconcept/crodip-local-backend:<imageTag>`
- LOCAL frontend : `ghcr.io/idwebconcept/crodip-local-frontend:<imageTag>`
- CENTRAL backend : `ghcr.io/idwebconcept/crodip-central-backend:<imageTag>`
- CENTRAL frontend : `ghcr.io/idwebconcept/crodip-central-frontend:<imageTag>`

### Changements

- suppression des images versionnées de `docker.topology` ;
- suppression des images versionnées de `templates/.env.example` ;
- `images/images-manifest.json` référence désormais `config/runtime.json#docker.imageTag` ;
- ajout de `Get-CrodipRuntimeImageTag` ;
- ajout de `Get-CrodipRuntimeImage` ;
- ajout de `Set-CrodipRuntimeImageEnvironment` ;
- installation et update réalignent automatiquement `.env` ;
- le manifest offline utilise `{tag}` pour les noms d'archives ;
- les contrôles d'installation vérifient l'alignement du `.env` avec `runtime.json` ;
- suppression des defaults d'image versionnés dans le module Docker.

Pour changer de version d'image, il suffit désormais de modifier :

`config/runtime.json -> docker.imageTag`.
