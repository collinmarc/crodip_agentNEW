# CRODIP Runtime Manager 2.3.0-RC19

## Correctif publications de ports Runtime

RC19 corrige la persistance d’un ancien `PortBindings` Docker après migration du cycle de vie DEV vers TEST.

- comparaison des ports du `docker compose config` avec `.HostConfig.PortBindings` des conteneurs existants ;
- arrêt et suppression ciblés uniquement des services dont la publication est obsolète ;
- recréation par le démarrage Compose normal ;
- contrôle post-démarrage des ports réellement publiés ;
- TEST/LOCAL attendu : backend `8110 -> 8000`, frontend `9110 -> 80` ;
- échec explicite si le port Docker effectif ne correspond pas au port Compose attendu.

Le traitement est idempotent : un conteneur déjà conforme n’est pas supprimé.
