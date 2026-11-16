# CRODIP Runtime Manager 2.3.0-RC25

## Correctifs

- correction du parseur PowerShell du menu de sélection d’un run CI historique ;
- réécriture explicite du contrôle « run antérieur » pour éviter l’erreur d’accolade sous PowerShell 7 ;
- conservation du mécanisme d’override TEST de RC24.

## Nouveau menu

- **19. Informations sur le run actif** : affiche la release officielle, le run/Run ID, le commit, les quatre références d’images et, lorsqu’il existe, l’override TEST actif ;
- **20. Quitter**.

L’écran distingue explicitement **OFFICIAL**, **TEST OVERRIDE** et **RUN EFFECTIF TEST**.
