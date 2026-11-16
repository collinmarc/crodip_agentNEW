# Runtime Manager 2.3.0-RC10

## Correctifs
- Suppression de `-Confirm:$false` sur les quatre fonctions Docker/WSL qui ne supportent pas ce paramètre.
- Utilisation des confirmations destructives natives du module DockerProvider.
- Suppression de la double confirmation du menu 16.
- Détection GitHub CLI par PATH puis chemin d'installation standard.
- Invocation de `gh.exe` via le chemin réellement détecté.
- Conservation du correctif GitHub API `${Path}?ref=$Ref`.

## Qualification attendue
Tester séparément les options 4, 6, 7 et 8 du menu 16 uniquement sur un poste où la destruction correspondante est souhaitée. L'option 4 doit demander la confirmation native `DESINSTALLER DOCKER`.
