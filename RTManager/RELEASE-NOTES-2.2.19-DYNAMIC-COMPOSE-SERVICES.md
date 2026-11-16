# Release Notes — Runtime Manager 2.2.42 Stable

## Services Compose dynamiques

Le Runtime ne suppose plus la présence de PostgreSQL.

Il découvre les services réellement déclarés avec :

```powershell
docker compose -f compose.yaml config --services
```

Sur un poste local CRODIP utilisant SQLite, si le Compose contient uniquement
`frontend` et `backend`, seuls ces deux services sont téléchargés et mis à jour.

SQLite ne nécessite aucune image Docker. PostgreSQL reste optionnel et ne sera
pris en compte que s'il est réellement déclaré dans `compose.yaml`.

Cette logique s'appliquera également à de futurs services optionnels comme MinIO.
