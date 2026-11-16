# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — Start Pull Diagnostics

Le démarrage n'utilise plus un `docker compose pull` global avec un message
d'erreur générique.

Le Runtime :

1. découvre les services réellement déclarés dans Compose ;
2. affiche les images associées ;
3. vérifie l'accès réseau à GHCR ;
4. vérifie les credentials Docker GHCR ;
5. teste l'accès en lecture à une image GHCR ;
6. effectue le pull service par service ;
7. classe les erreurs :
   - `AUTH`
   - `NOT_FOUND`
   - `NETWORK`
   - `UNKNOWN`
8. vérifie si une image locale peut être utilisée ;
9. produit un résumé avant démarrage ;
10. applique les règles ONLINE / AUTO / OFFLINE.

En mode ONLINE, l'erreur indique désormais précisément pourquoi le démarrage
est bloqué.

En mode AUTO, les images locales/offline sont utilisées lorsqu'elles sont
disponibles.
