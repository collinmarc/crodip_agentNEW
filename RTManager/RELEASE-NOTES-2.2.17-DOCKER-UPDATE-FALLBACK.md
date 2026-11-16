# Release Notes — Runtime Manager 2.2.42 Stable

## Docker Update Fallback

Le Runtime distingue désormais les échecs de `docker compose pull` :

- image/tag absent (`NOT_FOUND`) ;
- erreur d'authentification (`AUTH`) ;
- panne réseau ou moteur (`NETWORK`) ;
- erreur non classée.

### Mode ONLINE

Le pull reste strict : une image absente bloque la mise à jour.

### Mode AUTO

Si le pull échoue :

1. vérifier les images CRODIP déjà présentes localement ;
2. si toutes sont présentes, poursuivre avec celles-ci ;
3. sinon tenter l'import des archives offline ;
4. bloquer seulement si une image requise reste réellement absente.

### Mode OFFLINE

Le pull GHCR n'est pas requis et les archives offline sont utilisées.
