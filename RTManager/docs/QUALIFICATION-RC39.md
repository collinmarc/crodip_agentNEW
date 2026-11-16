# Qualification E2E — Runtime Manager 2.3.0-RC39

**Date de qualification :** 2026-09-28  
**Version Runtime :** `2.3.0-RC39`  
**Application :** `2.3.0-dev.3`  
**Build officiel :** `#14`  
**Run ID :** `35976894313`  
**Source :** `OFFICIAL`

## Objet

Qualifier de bout en bout les évolutions RC39 : sélection interactive des sauvegardes, restauration d'une sauvegarde RC38, conservation de la traçabilité Alembic et durcissement des ACL SQLite.

## Résultats

| Contrôle | Résultat |
|---|---|
| Test automatisé `Test-RC39-Interactive-Backup-Selection.ps1` | PASS |
| Liste interactive des sauvegardes | PASS |
| Sélection numérotée | PASS |
| Lecture de `BACKUP-MANIFEST.json` | PASS |
| Compatibilité sauvegarde RC38 vers Runtime RC39 | PASS |
| Restauration SQLite LOCAL | PASS |
| Restauration PostgreSQL CENTRAL | PASS |
| Vérification DB LOCAL | PASS |
| Vérification DB CENTRAL | PASS |
| Vérification DB GLOBAL | PASS |
| ACL SQLite après restauration | PASS |
| Écriture SQLite depuis le backend après restauration | PASS |
| Rollback du test d'écriture | PASS |

## Preuve de restauration des données

La sauvegarde de référence `crodip-runtime-full-20260928-111223.zip`, créée sous RC38, contenait le marqueur `BEFORE_BACKUP`. Après sauvegarde, les deux bases avaient été modifiées en `AFTER_BACKUP`. Après restauration sous RC39 :

- SQLite LOCAL : `rc38_restore_test = BEFORE_BACKUP` ;
- PostgreSQL CENTRAL : `rc38_restore_test = BEFORE_BACKUP`.

Cela démontre la restauration effective du contenu, et pas uniquement la disponibilité technique des moteurs.

## Révisions Alembic restaurées et contrôlées

- LOCAL / SQLite : `d24d83ea9494` ;
- CENTRAL / PostgreSQL : `3452c4fc44ba`.

Les révisions restaurées correspondent aux heads attendus par les images backend actives du Build officiel #14.

## Vérification post-restauration

Le script `19-verify-databases.ps1` a produit :

```text
LOCAL   : PASS
CENTRAL : PASS
GLOBAL  : PASS (périmètre des topologies déployées)
```

Les endpoints `/health/db` LOCAL et CENTRAL ont répondu HTTP 200.

## ACL SQLite

Après restauration :

```text
C:\ProgramData\CRODIP\sqlite
BUILTIN\Utilisateurs Allow Modify, Synchronize

C:\ProgramData\CRODIP\sqlite\crodip.db
BUILTIN\Utilisateurs Allow Modify, Synchronize
```

Un `INSERT` SQLite exécuté depuis le conteneur backend a réussi, suivi d'un `ROLLBACK` réussi. Aucune donnée de test n'a été conservée.

## Verdict

**RC39 QUALIFIÉE E2E sur le périmètre sauvegarde/restauration et ACL SQLite.**

Cette qualification ne constitue pas une qualification fonctionnelle métier générale de l'application. Elle qualifie le périmètre technique décrit ci-dessus.
