# Release Notes — Runtime Manager 2.2.42 Stable

## Pull Docker service par service

La mise à jour Docker ne dépend plus d'un `docker compose pull` global.

Chaque service est traité indépendamment :

```text
frontend
backend
postgres
```

Pour chaque service :

- pull réussi -> image mise à jour ;
- pull impossible + mode AUTO -> conservation de l'image locale si disponible ;
- sinon tentative du fallback offline ;
- blocage uniquement si aucune image utilisable n'existe pour ce service.

Ainsi, l'absence de `crodip-backend:2.2.1` sur GHCR n'empêche plus le frontend
de se mettre à jour.
