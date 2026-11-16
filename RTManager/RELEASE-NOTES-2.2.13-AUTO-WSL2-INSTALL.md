# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — Auto WSL2 Install

Le Runtime teste désormais automatiquement WSL2 lorsque Docker Desktop est le
provider sélectionné.

Si WSL2 est absent et que le Runtime est exécuté en administrateur, il lance :

```powershell
wsl --install -d Ubuntu
wsl --set-default-version 2
```

Puis il arrête proprement le flux et demande un redémarrage Windows si
nécessaire.

Cette vérification est intégrée à :

- Installation ;
- Démarrer.

Le Runtime ne tente plus de joindre GHCR avant que le moteur Docker Linux soit
réellement qualifiable.
