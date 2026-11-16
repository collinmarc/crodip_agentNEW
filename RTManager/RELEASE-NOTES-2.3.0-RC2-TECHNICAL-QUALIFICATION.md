# Release Notes — Runtime Manager 2.3.0-RC2

## Objectif

Automatiser la qualification technique qui avait été validée manuellement avec RC1.

## Ajouts

- commande `13-qualify-runtime.ps1` ;
- contrôle LOCAL backend/frontend ;
- contrôle CENTRAL backend/frontend ;
- vérification des quatre digests officiels ;
- contrôle PostgreSQL CENTRAL `healthy` ;
- six contrôles HTTP `/`, `/health`, `/docs` ;
- génération de `C:\ProgramData\CRODIP\qualification\runtime-qualification.json` ;
- statut final `RUNTIME TEST TECHNICALLY QUALIFIED`.

Aucun build applicatif n'est effectué. La politique `build-once-promote-same-digest` reste inchangée.
