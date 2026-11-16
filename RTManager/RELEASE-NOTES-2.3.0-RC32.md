# CRODIP Runtime Manager 2.3.0-RC32

## Official Release Restore Hardening

- Corrige le menu 18 lorsque l’override persistant existe mais que `config.runtime.json` ne contient pas `testOverride.runNumber`.
- Lecture défensive des propriétés optionnelles sous `Set-StrictMode`.
- Utilise l’override persistant comme source prioritaire pour afficher le run/version à restaurer.
- Le fichier `test-override.json` n’est supprimé définitivement qu’après réussite du redéploiement officiel.
- En cas d’échec LOCAL/CENTRAL, l’état d’override précédent est restauré.
- Les quatre références d’images officielles sont contrôlées avant pull.
- Conserve la réconciliation Docker/run introduite en RC31.
