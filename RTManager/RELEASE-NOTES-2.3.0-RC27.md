# CRODIP Runtime Manager 2.3.0-RC27

## Correctif principal

RC27 corrige le téléchargement du menu **17 - Charger un run CI antérieur pour TEST**.

Le Runtime Manager ne lance plus `gh run download` sans filtre sur l'ensemble des artefacts du run. Cette stratégie pouvait tenter d'extraire un artefact BuildKit `*.dockerbuild` et provoquer `zip: not a valid zip file`.

## Nouvelle stratégie

- inventaire des artefacts du run via GitHub CLI/API ;
- exclusion explicite des artefacts Docker BuildKit / `*.dockerbuild` ;
- priorité aux artefacts `manifest`, `official`, `release`, `metadata` ou `trace` ;
- téléchargement **unitaire** avec `gh run download --name <artifact>` ;
- arrêt dès qu'un `manifest.json` valide correspondant exactement au commit du run est trouvé ;
- message explicite si aucun manifest exploitable n'est disponible.

Les menus 18 (retour officiel) et 19 (informations run actif) sont conservés. Le pin officiel n'est pas modifié par un override TEST.
