# Release Notes — Runtime Manager 2.2.42 Stable

## Performance Instrumentation

Instrumentation locale de la vérification et du démarrage afin de comparer objectivement les performances de différents postes.

Rapports :
- `C:\ProgramData\CRODIP\logs\reports\check-performance.txt`
- `C:\ProgramData\CRODIP\logs\reports\check-performance.json`
- `C:\ProgramData\CRODIP\logs\reports\startup-performance.txt`
- `C:\ProgramData\CRODIP\logs\reports\startup-performance.json`

Seuils : `OK < 5 s`, `SLOW >= 5 s`, `VERY_SLOW >= 15 s`.

Ces indicateurs de performance ne modifient pas le statut fonctionnel du Runtime.
