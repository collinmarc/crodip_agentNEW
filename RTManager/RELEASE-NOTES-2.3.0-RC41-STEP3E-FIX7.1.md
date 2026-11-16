# RC41 STEP3E FIX7.1 — cohérence qualification finale

FIX7.1 ne modifie pas le mécanisme transactionnel FIX7.

Le test final RC41 cherchait encore les signatures textuelles de l'ancien rollback :
`rollback transactionnel vers le snapshot de sécurité` et l'appel direct
`Invoke-CrodipReleaseSnapshotRestore ... SafetySnapshot`.

FIX7 a remplacé ce chemin, après modification DB, par un rollback atomique stagé :
`Restore-SnapshotStaged` sur `SafetySnapshot.archive`, restauration de l'état source,
redéploiement des images source et qualification obligatoire.

La qualification finale contrôle désormais explicitement ce mécanisme FIX7 tout en
conservant le contrôle de la restauration authentique STEP3B.
