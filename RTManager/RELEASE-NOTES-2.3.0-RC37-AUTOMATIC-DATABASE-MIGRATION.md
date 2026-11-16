# CRODIP Runtime Manager 2.3.0-RC37 — Automatic Database Migration

## Objectif

RC37 corrige le défaut confirmé de RC36 : les conteneurs et les moteurs de base pouvaient être opérationnels alors que le schéma Alembic n’avait jamais été initialisé.

## Évolutions

- migration automatique `upgrade head` après démarrage/mise à jour LOCAL ;
- migration automatique `upgrade head` après disponibilité PostgreSQL lors du démarrage/mise à jour CENTRAL ;
- `PYTHONPATH=/app` et Alembic de la venv embarquée (`/app/.venv/bin/alembic`) ;
- head déterminé dynamiquement depuis l’image backend active ;
- contrôle final `current == head` ;
- aucun `downgrade` automatique ; une image historique incompatible provoque un arrêt contrôlé ;
- le menu 20 compare désormais la révision en base au head embarqué dans l’image active au lieu de piloter la compatibilité avec des révisions codées en dur.

## Régression validée à l’origine du correctif

- LOCAL SQLite vierge : moteur accessible mais `alembic_version` absente avant migration ; migration vers `d24d83ea9494` validée sur le Build #14.
- CENTRAL PostgreSQL vierge : PostgreSQL healthy mais aucune relation avant migration ; migration vers `3452c4fc44ba` validée sur le Build #14.
- après migration manuelle : menu 20 = LOCAL PASS / CENTRAL PASS / GLOBAL PASS.

## Politique historique

Le Runtime Manager n’exécute jamais de downgrade Alembic automatique. Lors d’un changement vers un build antérieur, une révision non comprise par l’image cible entraîne un refus explicite afin de préserver les données.
