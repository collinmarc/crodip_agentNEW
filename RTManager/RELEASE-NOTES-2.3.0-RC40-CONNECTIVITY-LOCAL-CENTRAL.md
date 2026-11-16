# RC40 - Connectivité AUTO / ONLINE / OFFLINE LOCAL + CENTRAL

La politique historique de connectivité est conservée avec `AUTO` comme mode par défaut et est désormais appliquée aux deux runtimes.

- LOCAL et CENTRAL utilisent le même moteur `Start-CrodipRuntimeAuto`.
- `AUTO` tente le registre puis bascule sur les images locales/offline en cas d'indisponibilité.
- `ONLINE` exige l'accès au registre.
- `OFFLINE` n'effectue aucun pull et démarre avec `pull=never`.
- Avant un démarrage OFFLINE, toutes les images du Compose sont contrôlées localement.
- Pour CENTRAL, ce contrôle inclut explicitement `postgres:17` en plus du backend et du frontend.
- Le menu principal affiche le mode configuré.
- Le démarrage affiche le mode configuré et le mode effectif.

Le moteur de migration Alembic RC40 n'est pas modifié par cette évolution.
