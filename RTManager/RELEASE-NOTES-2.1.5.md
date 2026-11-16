# Release Notes — 2.2.1 Stable

Cette version corrige l'erreur :

```text
Write-CrodipSuccess is not recognized
```

La cause était un `Import-Module ... -Force` exécuté à l'intérieur de
`Initialize-CrodipDirectories`. Ce rechargement déplaçait le module commun
dans la portée du module Windows et retirait ses commandes de la session
principale.

Les modules Windows et Logging sont désormais autonomes et ne réimportent
plus d'autres modules pendant l'exécution de leurs fonctions.
