# Runtime Manager 2.3.0-RC40 — Refonte menu LOCAL / CENTRAL

Le menu principal est restructuré pour placer les runtimes LOCAL et CENTRAL au même niveau fonctionnel.

## Organisation

- Runtime LOCAL : installation, démarrage, arrêt, état, mise à jour, journaux et désinstallation.
- Runtime CENTRAL : installation, démarrage, arrêt, état, mise à jour, journaux et désinstallation.
- Données : sauvegarde, restauration et vérification des bases.
- Release / TEST : qualification, changement de release et informations de release.
- Système : environnement, Docker, journaux LOCAL, informations système, composants et GitHub CLI.

Le libellé `Runtime CENTRAL (simulation)` est supprimé : CENTRAL est désormais un runtime géré et qualifié.

Aucun changement n'est apporté au moteur de migration Alembic RC40.
