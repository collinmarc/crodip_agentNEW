# Release Notes — 2.2.1 Stable

Cette version corrige définitivement l'erreur :

```text
-DisableNameChecking: The term '-DisableNameChecking' is not recognized
```

La cause était un commutateur ajouté après la fermeture d'une fonction dans
certains modules. Les modules n'utilisent désormais plus ce commutateur.

Les scripts principaux conservent `-DisableNameChecking` uniquement sur leurs
commandes `Import-Module`.
