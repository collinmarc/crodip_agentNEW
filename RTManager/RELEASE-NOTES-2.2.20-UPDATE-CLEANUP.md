# Release Notes — Runtime Manager 2.2.42 Stable

## Update Cleanup

La 2.2.19 effectuait correctement le pull service par service, mais conservait
à la fin un ancien bloc de pull global issu des versions précédentes.

Ce bloc appelait ensuite une variable `$pullResult` qui n'était plus définie,
provoquant :

```text
The variable '$pullResult' cannot be retrieved because it has not been set.
```

La 2.2.42 supprime définitivement ce reliquat.

Le flux de mise à jour devient :

```text
sauvegarde
→ découverte des services Compose
→ pull service par service
→ résumé
→ docker compose up -d
→ journalisation
→ fin
```
