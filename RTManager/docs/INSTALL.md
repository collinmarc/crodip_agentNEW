# Installation — Runtime Manager 2.3.0-RC40

## Référence

- Application : `2.3.0-dev.4`
- Cycle : TEST
- Build officiel : `#15` / Run ID `36452467983`
- Commit : `53928c1f30a8a90cc6a1cf467d5c332f10494a80`
- Connectivité par défaut : `AUTO`

## Installation

1. Extraire le kit dans un répertoire de travail.
2. Ouvrir PowerShell 7 en administrateur.
3. Débloquer les scripts : `Get-ChildItem -Recurse | Unblock-File`.
4. Lancer `./bootstrap-runtime.ps1`.
5. Installer/vérifier le Runtime LOCAL puis, si nécessaire, le Runtime CENTRAL.
6. Vérifier les ports TEST : LOCAL backend `8110`, frontend `9110`; CENTRAL backend `8120`, frontend `9120`.
7. Conserver `AUTO` comme politique nominale sauf test ou exploitation explicitement ONLINE/OFFLINE.
8. Lancer la qualification technique Runtime après démarrage des deux cibles.

## Persistance

Les données Runtime résident sous `C:\ProgramData\CRODIP`. Le volume PostgreSQL CENTRAL `crodip-runtime-central-postgres` doit être conservé lors des mises à jour normales. La politique de connectivité est mémorisée dans le `.env` installé par `CRODIP_DEPLOYMENT_MODE`.

## Migrations

RC40 valide le head Alembic déclaré par la release, le head embarqué dans l'image et la révision courante de la base. LOCAL attend `ecd67252fd57`; CENTRAL attend `7544a84c3691`. Toute migration CENTRAL modifiant la base exige une sauvegarde PRE-MIGRATION réussie.
