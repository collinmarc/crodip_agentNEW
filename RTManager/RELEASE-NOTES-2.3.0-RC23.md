# CRODIP Runtime Manager 2.3.0-RC23

## Objet
Isolation explicite des environnements Compose LOCAL et CENTRAL.

- LOCAL utilise `C:\Program Files\CRODIP\.env`.
- CENTRAL utilise `C:\Program Files\CRODIP\templates\central\.env`.
- Les deux fichiers sont créés automatiquement depuis leur `.env.example` s'ils sont absents.
- Ils sont resynchronisés depuis `config/runtime.json` avant le démarrage.
- TEST/LOCAL : backend 8110, frontend 9110.
- TEST/CENTRAL : backend 8120, frontend 9120.
- Le pin officiel reste le build #11, application 2.3.0-dev.2, commit `43d080b1b39c23dced5be6183840a5c944bccae3`.
- Le volume PostgreSQL CENTRAL est conservé.

## Correctif principal
Le démarrage CENTRAL ne dépend plus d'un `.env` manquant : il matérialise puis synchronise le fichier CENTRAL avant l'appel à Docker Compose.
