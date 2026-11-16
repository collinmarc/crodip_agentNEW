# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — Legacy Image Migration

Correction du cas où un poste possède encore des références d'images historiques :

```text
idwebconcept/crodip-backend:2.1.0
idwebconcept/crodip-frontend:2.1.0
```

Ces références sont interprétées par Docker comme des images Docker Hub et ne
déclenchent donc pas le précontrôle GHCR.

Le Runtime détecte désormais ce cas avant tout pull et propose :

```text
Migrer maintenant la configuration des images vers GHCR ? [O/n]
```

Si l'utilisateur accepte :

1. `.env` est sauvegardé avec un suffixe horodaté ;
2. les variables `CRODIP_BACKEND_IMAGE` et `CRODIP_FRONTEND_IMAGE` sont mises
   à jour à partir du `images-manifest.json` fourni avec le Runtime ;
3. Compose est relu ;
4. les nouvelles images `ghcr.io/idwebconcept/...` sont affichées ;
5. le contrôle GHCR s'exécute ;
6. si nécessaire, la connexion GHCR est proposée automatiquement ;
7. le démarrage reprend après validation.

Aucune migration silencieuse n'est réalisée.
