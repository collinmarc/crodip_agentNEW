# Runtime Manager 2.3.0-RC12

## Correctif
- Export explicite de `Get-CrodipGitHubCliExecutable`.
- Conservation des cinq exports GitHub existants.
- Nouveau test de contrat PowerShell avec import réel du module.
- Vérification `Get-Command` de chaque fonction publique.
- Invocation réelle du détecteur GitHub CLI sous StrictMode.

## Correctifs conservés
- RC9 : endpoint GitHub API `${Path}?ref=$Ref`.
- RC10 : signatures réelles des désinstallations Docker/WSL.
- RC11 : détection GitHub CLI sans dépendance scalaire/tableau à `Count`.
