# CRODIP Runtime Manager 2.3.0-RC21

## Objet

RC21 isole strictement les ports LOCAL et CENTRAL et ajoute la traçabilité de la release associée aux images Docker.

## Correctifs

- Le démarrage CENTRAL réimpose les ports du couple `activeLifecycle/CENTRAL` dans le processus PowerShell avant tout appel Docker Compose.
- En TEST : LOCAL = backend 8110 / frontend 9110 ; CENTRAL = backend 8120 / frontend 9120.
- Une ancienne variable de processus LOCAL ne peut plus forcer CENTRAL sur 8110/9110.
- Le `.env` CENTRAL reste synchronisé par `Set-CrodipRuntimeImageEnvironment -Target central`.
- Contrôle des ports CENTRAL avant démarrage avec arrêt explicite en cas de conflit externe.

## Traçabilité release / images

Avant démarrage CENTRAL, le Runtime Manager affiche : version application, canal/cycle, numéro et ID du run officiel, commit Git, politique build-once/promote-same-digest, source du manifest, références digest backend/frontend et ports CENTRAL.

Après démarrage, les conteneurs backend/frontend sont inspectés : référence d'image effective, label OCI `org.opencontainers.image.version`, label OCI `org.opencontainers.image.revision`, comparaison du digest avec le manifest Runtime et avertissement si le commit OCI diffère du commit officiel attendu.

## Volume PostgreSQL

Le volume `crodip-runtime-central-postgres` reste conservé. Aucun correctif RC21 ne le supprime.
