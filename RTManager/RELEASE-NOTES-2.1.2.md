# Release Notes — 2.2.1 Stable

Cette version corrige l'erreur :

```text
-DisableNameChecking: The term '-DisableNameChecking' is not recognized
```

Le commutateur est désormais placé sur la même ligne que chaque commande
`Import-Module`.

Les erreurs `CRODIP_HOME`, `compose.yaml` et `.env` restent normales tant que
le choix **1. Installer le Runtime** n'a pas été exécuté en administrateur.
