# CRODIP Runtime Manager 2.3.0-RC22

## Objet

Correction du contrôle des ports CENTRAL sous PowerShell StrictMode et alignement du Runtime embarqué sur la release officielle Build #11.

## Correctifs

- Les services Compose sans propriété `ports` (notamment PostgreSQL interne) sont ignorés proprement par les contrôles et la réconciliation.
- Aucun accès direct à `.ports` n'est effectué sans vérifier l'existence de la propriété.
- Le contrôle reste limité aux ports réellement publiés sur l'hôte.
- Matrice TEST conservée : LOCAL 8110/9110 ; CENTRAL 8120/9120.

## Release officielle embarquée

- Application : `2.3.0-dev.2`
- Build officiel : `#11`
- Run ID : `35279460805`
- Commit : `43d080b1b39c23dced5be6183840a5c944bccae3`
- Politique : `build-once-promote-same-digest`
- Les quatre références GHCR sont épinglées par digest au Build #11.

## Traçabilité

Le Runtime affiche avant démarrage la version application, le build/run, le commit, le mode de manifest, les images par digest et les ports. Après démarrage, les images et labels OCI des conteneurs sont comparés au manifest Runtime.
