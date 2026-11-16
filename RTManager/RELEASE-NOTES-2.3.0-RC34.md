# CRODIP Runtime Manager 2.3.0-RC34

## Objet

Cette version généralise la sélection de release du Runtime TEST.

Le mécanisme RC33 permettait déjà de charger un run CI historique. RC34 rend
explicitement la sélection **bidirectionnelle** : un run réussi peut être
antérieur ou postérieur à la release officielle courante, sous réserve qu'un
manifest de release exploitable soit disponible.

## Référentiel officiel

- Kit DEV : `6.3.2`
- Qualification Kit DEV : `RC6.5.13.88` — 13/13 PASS
- Application : `2.3.0-dev.3`
- Build officiel : `#14`
- Run ID : `35976894313`
- Commit : `8bb3014438c21d00b1239839b465fe86a7e27130`
- Références d'images : digests immuables
- Politique : **Build Once / Promote Same Digest**

## Sélection d'une release Runtime

Le menu 17 :

1. liste les runs réussis du workflow `CRODIP Official Build` ;
2. accepte un run antérieur ou postérieur au Build officiel ;
3. télécharge sélectivement les artefacts exploitables ;
4. exige un `manifest.json` cohérent avec le commit du run ;
5. extrait les quatre images LOCAL/CENTRAL par digest ;
6. demande la confirmation `SWITCH-RUNTIME` ;
7. tire les quatre images ;
8. enregistre un override TEST persistant ;
9. redéploie LOCAL et CENTRAL lorsque ces topologies sont installées.

Le pin officiel n'est jamais remplacé par cette opération.

## Retour arrière / retour officiel

Le menu 18 restaure le Build officiel #14 et supprime l'override uniquement
après redéploiement réussi. En cas d'échec, l'état d'override précédent est
restauré.

## Données

Le volume PostgreSQL CENTRAL n'est jamais supprimé automatiquement. Une
transition vers une release plus ancienne ou plus récente peut être
incompatible avec l'état courant du schéma. La qualification après déploiement
reste requise.
