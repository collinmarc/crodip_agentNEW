# CRODIP Runtime Manager 2.3.0-RC28

## PowerShell Reserved Variable Hardening

- Corrige le menu 17 après le téléchargement des quatre images d'un run historique.
- Remplace la variable locale `$home` par `$runtimeHome` dans `Sync-And-Redeploy` afin d'éviter la collision avec la variable automatique PowerShell `$HOME`, en lecture seule.
- Conserve le téléchargement sélectif des artefacts introduit en RC27.
- Ajoute `tests/Test-RC28-Reserved-Automatic-Variables.ps1` pour détecter les affectations directes à un ensemble de variables automatiques/réservées PowerShell.
- Le pin officiel reste inchangé pendant un override TEST et les volumes Docker, notamment PostgreSQL CENTRAL, ne sont pas supprimés.
