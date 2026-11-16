# Release Notes — 2.2.1 Stable

Cette version corrige l'absence d'archive après l'utilisation du menu
**Sauvegarder**.

La nouvelle procédure :

1. prépare les données dans un dossier temporaire ;
2. copie les répertoires métier ;
3. ajoute un manifeste de sauvegarde ;
4. crée l'archive ZIP ;
5. vérifie immédiatement son existence et son contenu ;
6. affiche son chemin, sa taille et son nombre d'entrées.

Emplacement par défaut :

```text
C:\ProgramData\CRODIP\backups
```

Test manuel :

```powershell
.\tests\Test-Backup.ps1
```
