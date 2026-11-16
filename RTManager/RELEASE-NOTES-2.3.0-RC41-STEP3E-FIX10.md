# RC41 STEP3E FIX10 — CENTRAL Update / Alembic / Port Reconciliation

- `CENTRAL > Mettre à jour` réconcilie désormais les bindings Docker avant `compose up`, sous le contexte CENTRAL 8120/9120.
- Les bindings effectifs sont contrôlés après `compose up` et avant Alembic.
- La lecture de `alembic current` normalise les lignes avec `Trim()` avant extraction de la révision.
- Le rapport d’échec de migration accepte explicitement `Current` vide afin de produire un diagnostic au lieu d’une erreur de binding PowerShell.
- Aucune suppression de volume ni restauration automatique de base n’est ajoutée.
