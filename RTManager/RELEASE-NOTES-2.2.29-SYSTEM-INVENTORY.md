# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — System Inventory

Ajout d'un inventaire système complet accessible depuis le menu principal :

```text
11. Informations système
12. Quitter
```

Informations collectées :

- nom, fabricant et modèle du poste ;
- système d'exploitation, version, build et architecture ;
- date d'installation Windows et dernier démarrage ;
- BIOS / UEFI, Secure Boot, carte mère ;
- CPU, nombre de cœurs et processeurs logiques ;
- RAM totale, utilisée, disponible et modules mémoire ;
- disques physiques et volumes logiques ;
- capacité, espace utilisé et espace libre ;
- hyperviseur, WSL, Docker Client, Engine et Compose ;
- interfaces réseau IP actives ;
- version PowerShell.

Les rapports sont générés dans :

```text
C:\ProgramData\CRODIP\logs\reports\system-info.txt
C:\ProgramData\CRODIP\logs\reports\system-info.md
C:\ProgramData\CRODIP\logs\reports\system-info.json
```
