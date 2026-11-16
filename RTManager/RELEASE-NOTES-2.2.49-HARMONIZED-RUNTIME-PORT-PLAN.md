# CRODIP Runtime Manager v2.2.49 Stable

## Harmonized Runtime Port Plan

Cette version aligne le Runtime Manager sur le plan de ports canonique du Kit DEV 6.2.105.

### Runtime LOCAL

- projet Compose : `crodip-runtime-local`
- backend : `8110`
- frontend : `9110`
- base : SQLite
- installé par défaut

### Runtime CENTRAL

- projet Compose : `crodip-runtime-central`
- backend : `8120`
- frontend : `9120`
- base : PostgreSQL 17
- simulation optionnelle

### Changements

Les anciens ports Runtime :

- LOCAL `8000/9000`
- CENTRAL `8200/9200`

sont remplacés par :

- LOCAL `8110/9110`
- CENTRAL `8120/9120`

Sont alignés :

- `config/runtime.json`
- URLs de démarrage et Health
- `.env.example` LOCAL
- Compose LOCAL
- `.env.example` CENTRAL
- Compose CENTRAL
- affichages du gestionnaire CENTRAL
- contrôle d'installation
- README
- nomenclature LOCAL/CENTRAL
- tests de régression

Le tag commun des quatre images Docker reste `2.2.1`.

### Compatibilité

La base LOCAL reste SQLite.  
La base CENTRAL reste PostgreSQL 17.  
Le volume PostgreSQL CENTRAL est conservé lors d'une désinstallation du Runtime CENTRAL.
