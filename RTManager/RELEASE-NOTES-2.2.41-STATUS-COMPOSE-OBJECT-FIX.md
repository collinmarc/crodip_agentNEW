# Release Notes — Runtime Manager 2.2.42 Stable

## Status Compose Object Fix

Le menu `5. État` dépendait encore d'une projection intermédiaire héritée de
l'ancien modèle de conteneurs fixes. Cela pouvait produire :

```text
The property 'ContainerName' cannot be found on this object.
```

La 2.2.42 consomme désormais directement les objets retournés par
`Get-CrodipComposeServiceRuntimeStatus`.

Le menu État affiche pour backend et frontend :

- service Compose ;
- nom réel du conteneur ;
- image ;
- state ;
- status ;
- health ;
- exit code.

Il reconnaît notamment :

- RUNNING
- RESTARTING
- UNHEALTHY
- EXITED
- DEAD
- UNKNOWN
