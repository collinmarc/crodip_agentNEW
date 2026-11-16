# CRODIP Runtime Manager 2.3.0-RC26

## Correctif principal

RC26 corrige le second défaut de parsing du menu **17 - Charger un run CI antérieur pour TEST**. Une apostrophe typographique présente dans une chaîne PowerShell délimitée par des apostrophes provoquait `La chaîne ne comporte pas le terminateur : '`.

Les messages concernés utilisent désormais des chaînes délimitées par des guillemets doubles.

## Qualification syntaxique

Le test `tests/Test-RC26-PowerShell-Parse-All.ps1` analyse récursivement tous les fichiers `.ps1` et `.psm1` avec `System.Management.Automation.Language.Parser`. La qualification échoue dès qu’une erreur de parsing PowerShell est détectée.

## Fonctions conservées

- menu 17 : sélectionner un run CI antérieur pour TEST ;
- menu 18 : restaurer la release officielle ;
- menu 19 : afficher OFFICIAL, TEST OVERRIDE et RUN EFFECTIF TEST ;
- isolation `.env` LOCAL / CENTRAL ;
- conservation des volumes, notamment PostgreSQL CENTRAL.
