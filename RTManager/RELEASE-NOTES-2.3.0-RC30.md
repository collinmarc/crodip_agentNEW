# CRODIP Runtime Manager 2.3.0-RC30

## Persistent TEST Override + Docker Runtime Truth

- Persistance de l’override TEST dans `C:\ProgramData\CRODIP\state\test-override.json`.
- La relance du kit ne réinitialise plus l’override au pin officiel.
- `Get-CrodipEffectiveRelease` privilégie l’override persistant actif.
- Le retour à la release officielle supprime explicitement cet état persistant.
- Le menu 19 distingue release officielle, override persistant et conteneurs réellement exécutés.
- Le run réel est déterminé depuis les labels OCI des conteneurs Docker et rapproché du commit officiel/override.
- Détection d’un runtime mixte ou indéterminé.
