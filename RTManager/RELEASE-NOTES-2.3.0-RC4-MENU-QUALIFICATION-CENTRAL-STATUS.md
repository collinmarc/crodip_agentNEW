# Release Notes — Runtime Manager 2.3.0-RC4

## Évolutions

### Menu principal

Ajout de :

```text
13. Qualification technique Runtime
14. Quitter
```

L'entrée 13 exécute directement `commands\13-qualify-runtime.ps1`.

### Runtime CENTRAL — page État

L'ancienne sortie brute `docker compose ps` est remplacée par une page de
synthèse affichant :

- Runtime / application / cycle ;
- Run CI et commit ;
- PostgreSQL 17 et son état de santé ;
- backend et frontend ;
- ports exposés ;
- images réellement configurées via `docker inspect .Config.Image` ;
- comparaison aux digests officiels ;
- contrôles HTTP `/`, `/health`, `/docs` ;
- conclusion d'exploitation.

Aucune image, aucun digest officiel et aucun port n'ont changé.
