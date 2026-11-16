# Runtime Manager 2.3.0-RC41 — STEP3E FIX7

## Atomic EMPTY Switch & Automatic Source Rollback

FIX7 corrige le défaut observé lors du test réel #15 → #14 EMPTY : `07-restore.ps1` qualifiait les bases #14 contre les images #15 avant que les images #14 soient activées.

### Séquencement STEP3E

1. snapshot de sécurité authentique de la source ;
2. validation du snapshot RECONSTRUCTED/EMPTY cible ;
3. pull des images cibles ;
4. restauration **stagée** des bases cibles, avec backends laissés arrêtés ;
5. écriture de l'override TEST ;
6. redéploiement des images cibles ;
7. qualification DB stricte contre les images cibles ;
8. commit fonctionnel de l'activation.

`07-restore.ps1` conserve son comportement normal par défaut. Les switches `SkipPostRestoreVerification` et `DeferBackendStart` sont réservés à la transaction de changement de release.

### Rollback automatique

Dès que STEP3E entre dans la phase susceptible de modifier les bases, toute exception déclenche : restauration stagée du snapshot source, restauration de la configuration/override précédent, redéploiement des images source puis qualification DB obligatoire. Un échec du rollback est remonté comme erreur critique.

### Retour #14 EMPTY → release officielle #15

L'override STEP3E mémorise `sourceSafetyArchive`, `sourceRunNumber`, `sourceRunId` et `targetDatabaseArchive`. Le retour officiel restaure d'abord les bases source puis les images officielles et qualifie l'ensemble. En cas d'échec, le Runtime Manager tente de reconstituer l'état TEST EMPTY précédent.

### Qualification

Nouveau test : `tests/Test-RC41-Step3E-Fix7-Atomic-Empty-Switch.ps1`.
