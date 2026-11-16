# Release Notes — 2.2.42 Stable — Lot 5 Docker Install

## Correction fonctionnelle

La 2.2.3 permettait de choisir le provider Docker mais pas de l'installer.

La 2.2.42 ajoute dans Administration Docker :

1. Installer Docker Desktop
2. Installer / préparer WSL2 + Ubuntu
3. Installer Docker Engine dans Ubuntu / WSL2
4. Utiliser Docker Desktop
5. Utiliser Docker Engine Ubuntu / WSL2
6. État du provider Docker

Les fonctions d'installation sont intégrées au module
`Crodip.Runtime.DockerProvider.psm1`.
