# Release Notes — Runtime Manager 2.2.42 Stable

## Docker Menu Command Fix

Le choix `1. Installer Docker Desktop` appelait une fonction inexistante :

```powershell
Write-CrodipInfo
```

Elle est remplacée par la fonction existante :

```powershell
Write-CrodipStep
```

Un test vérifie désormais :

- l'absence de `Write-CrodipInfo` ;
- la disponibilité des helpers `Write-CrodipStep`, `Write-CrodipSuccess`,
  `Write-CrodipWarning` et `Write-CrodipError` ;
- le parsing complet de `11-docker-admin.ps1`.
