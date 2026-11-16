# Runtime Manager 2.3.0-RC13

## Fresh Install
- WSL2 + Ubuntu préparés automatiquement lorsqu'ils sont absents.
- Docker Desktop installé automatiquement via Winget lorsqu'il est absent.
- Docker Desktop existant conservé.
- Moteur Docker arrêté : démarrage de Docker Desktop puis attente jusqu'à 120 secondes.
- Qualification obligatoire : `docker --version`, `docker compose version`, `docker info`.
- GitHub CLI installé automatiquement lorsqu'il est absent.
- Reprise par relance de l'installation après un éventuel redémarrage Windows.

## Régressions conservées
RC9 GitHub API, RC10 désinstallation Docker/WSL, RC11 détection GitHub CLI StrictMode, RC12 contrat d'export du module GitHub.
