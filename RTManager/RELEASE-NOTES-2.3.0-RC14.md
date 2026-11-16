# Runtime Manager 2.3.0-RC14

## Winget / Docker Desktop
- Processus Winget supervisé.
- Progression Runtime toutes les 15 secondes.
- Timeout configurable, 900 secondes par défaut.
- Journaux stdout/stderr sous `C:\ProgramData\CRODIP\logs`.
- `--disable-interactivity` et `--verbose-logs`.
- Code retour Winget affiché et contrôlé.
- Arrêt du processus en cas de timeout.
- Détection d'un autre processus Winget avant lancement.
- Conservation du bootstrap WSL2/Docker/GitHub RC13.

## Régressions conservées
RC9 API GitHub, RC10 désinstallation, RC11 StrictMode, RC12 exports GitHub, RC13 Fresh Install.
