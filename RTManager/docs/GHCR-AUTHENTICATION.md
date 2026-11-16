# Authentification GHCR — Runtime 2.3.0-RC40

En mode ONLINE, ou lorsque AUTO détermine que le registre est accessible, le Runtime contrôle l'accès en lecture à GHCR avant le pull des images applicatives. Les images sont référencées par digest officiel.

En OFFLINE, aucun pull GHCR n'est effectué et les images nécessaires doivent être disponibles localement. Le mode configuré est stocké via `CRODIP_DEPLOYMENT_MODE` dans le `.env` installé.
