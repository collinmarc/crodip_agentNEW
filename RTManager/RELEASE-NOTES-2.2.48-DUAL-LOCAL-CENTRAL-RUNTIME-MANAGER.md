# CRODIP Runtime Manager v2.2.48 Stable

## Dual LOCAL / CENTRAL Runtime Manager

Le Runtime Manager gère désormais deux cibles distinctes.

### LOCAL — comportement par défaut

Le fonctionnement existant est conservé :

- projet Docker : `crodip-runtime-local`
- frontend : `http://localhost:9000`
- backend : `http://localhost:8000`
- base locale : SQLite
- installation par défaut via le menu Installation.

### CENTRAL — simulation optionnelle

Une nouvelle entrée du menu principal permet d'installer un environnement CENTRAL sur le même poste :

- projet Docker : `crodip-runtime-central`
- frontend : `http://localhost:9200`
- backend : `http://localhost:8200`
- base : PostgreSQL 17
- installation uniquement à la demande
- images :
  - `crodip-central-backend:<docker.imageTag>`
  - `crodip-central-frontend:<docker.imageTag>`

Le tag reste centralisé dans :

`config/runtime.json -> docker.imageTag`.

### Menu CENTRAL

Le sous-menu permet :

1. Installer le Runtime CENTRAL
2. Démarrer
3. Arrêter
4. État
5. Mettre à jour
6. Journaux
7. Désinstaller
8. Retour

La désinstallation CENTRAL conserve volontairement le volume PostgreSQL afin d'éviter une perte accidentelle de données.
