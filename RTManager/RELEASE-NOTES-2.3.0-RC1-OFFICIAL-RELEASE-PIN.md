# Release Notes — Runtime Manager 2.3.0-RC1

## Objectif

Aligner le Runtime Manager 2.2.49 avec le Kit DEV 6.3.0-RC6.5.13.58 et le workflow officiel de release.

## Évolutions

- application active : `2.3.0-dev.1` ;
- build officiel : Run #10 / `34317428903` ;
- commit : `338d9f21170b4e5cbb9218975f9b20db074245f4` ;
- quatre images LOCAL/CENTRAL épinglées par digest ;
- `imageReferenceMode=digest` ;
- `docker.imageTag` conservé comme compatibilité, plus comme source officielle ;
- ajout du plan complet DEV/TEST/PREPROD/PROD ;
- profil actif maintenu sur TEST car la release amont n'est pas qualifiée PREPROD/PROD ;
- blocage documentaire explicite de toute promotion automatique PREPROD/PROD ;
- clarification `TEST TECHNICALLY QUALIFIED` vs qualification fonctionnelle.

## Compatibilité

Les ports TEST 9110/8110 et 9120/8120 sont volontairement conservés dans cette RC. Les ports PROD 9310/8310 et 9320/8320 sont documentés mais non activés tant qu'une promotion officielle n'a pas eu lieu.

## Politique

`build once / promote same digest`
