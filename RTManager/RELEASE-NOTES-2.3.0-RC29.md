# CRODIP Runtime Manager 2.3.0-RC29

## Central Compose Context Isolation

- Corrige le redéploiement CENTRAL après sélection d’un run CI historique.
- Isole les variables `CRODIP_BACKEND_PORT` et `CRODIP_FRONTEND_PORT` pendant chaque appel Compose CENTRAL.
- Restaure le contexte de processus précédent après l’appel Compose afin d’éviter toute contamination LOCAL/CENTRAL.
- Valide le `.env` CENTRAL avant mise à jour et bloque si les ports ne correspondent pas au profil `Lifecycle/CENTRAL`.
- En TEST, CENTRAL doit utiliser backend `8120` et frontend `9120`; LOCAL reste sur `8110` / `9110`.
- Le volume PostgreSQL CENTRAL n’est jamais supprimé par ce correctif.
