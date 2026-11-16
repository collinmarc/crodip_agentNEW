# Release Notes — 2.2.42 Stable — Lot 5 Docker Provider

## Ajouts

- choix persistant `desktop` ou `ubuntu` ;
- support Docker Engine installé directement dans Ubuntu WSL2 ;
- exécution des commandes Docker Ubuntu via `wsl.exe`;
- conversion automatique des chemins Windows pour Docker Compose ;
- menu Administration Docker enrichi ;
- démarrage provider-aware ;
- variables `CRODIP_DOCKER_PROVIDER` et `CRODIP_WSL_DISTRO`;
- documentation `docs/DOCKER-PROVIDER.md`.

## Compatibilité

Le provider par défaut reste `desktop`, afin de préserver le comportement du Runtime Manager 2.2.1.
