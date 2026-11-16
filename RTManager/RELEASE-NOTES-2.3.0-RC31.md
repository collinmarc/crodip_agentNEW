# CRODIP Runtime Manager 2.3.0-RC31

## Docker Run Reconciliation + Historical Manifest Recovery

- Le menu 19 considère Docker comme vérité du runtime réellement déployé.
- Résolution du numéro de run par commit OCI selon : release officielle, override persistant, historique local des manifests.
- Un runtime homogène #10 est reconnu comme #10 même si l'override RC30 n'existait pas encore.
- Distinction entre cohérence de release et état opérationnel des services (`running`, `created`, etc.).
- Reconstruction automatique de `C:\ProgramData\CRODIP\state\test-override.json` lorsqu'un run historique homogène est identifié sans ambiguïté depuis Docker + release-history.
- Aucun volume Docker/PostgreSQL n'est supprimé.
