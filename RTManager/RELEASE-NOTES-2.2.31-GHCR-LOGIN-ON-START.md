# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — GHCR Login On Start

Le démarrage contrôle désormais automatiquement l'accès aux images GHCR.

Si l'accès en lecture n'est pas validé :

```text
[ATTENTION] Accès en lecture GHCR non validé.

Se connecter à GHCR maintenant ? [O/n]
```

Si l'utilisateur accepte :

1. le Runtime lance la fonction sécurisée de connexion GHCR ;
2. le nom d'utilisateur GitHub et le PAT sont demandés ;
3. le PAT est transmis à Docker avec `--password-stdin` ;
4. le secret n'est ni affiché ni journalisé ;
5. l'accès en lecture à l'image CRODIP est retesté ;
6. si le test réussit, le démarrage reprend automatiquement.

En mode ONLINE, un refus après cette tentative reste bloquant.

En mode AUTO, le Runtime peut poursuivre avec une image locale/offline disponible.
