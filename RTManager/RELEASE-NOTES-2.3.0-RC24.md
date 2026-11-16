# CRODIP Runtime Manager 2.3.0-RC24

## Historical CI Run TEST Override

- Ajoute le chargement d’un run `CRODIP Official Build` antérieur et réussi pour TEST.
- Télécharge les artefacts du run via GitHub CLI et retrouve le `manifest.json` correspondant au commit du run.
- Vérifie les quatre images LOCAL/CENTRAL et leurs digests SHA-256.
- Crée un `testOverride` temporaire sans modifier la release officielle épinglée.
- Pull et redéploie les images exactes par digest.
- Ajoute le retour explicite à la release officielle.
- Préserve le volume PostgreSQL CENTRAL ; avertissement explicite avant downgrade.
- Les `.env` LOCAL et CENTRAL utilisent la release effective (officielle ou override TEST).

### Menu

- 17. Charger un run CI antérieur pour TEST
- 18. Revenir à la release officielle
- 19. Quitter
