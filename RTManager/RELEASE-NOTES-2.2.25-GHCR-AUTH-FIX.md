# Release Notes — Runtime Manager 2.2.42 Stable

## GHCR Auth Fix

Alignement de l'authentification GHCR du Runtime sur le kit DEV :

- saisie PAT sécurisée ;
- `docker login --password-stdin` ;
- UTF-8 sans BOM ;
- détection robuste `auths`, `credsStore`, `credHelpers` ;
- test réel d'accès lecture GHCR ;
- diagnostic plus explicite dans `Vérifier le registre`.
