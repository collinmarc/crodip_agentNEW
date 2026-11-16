# RC41 STEP3C FIX2 — Legacy Backup Manifest Compatibility

- Rend `Find-CrodipHistoricalBackupCandidate` tolérant aux anciens `BACKUP-MANIFEST.json` sans `releaseIdentity` ou structure `database` complète.
- Les backups non authentifiables sont ignorés et ne deviennent jamais des snapshots de rollback.
- L’identité exacte `runNumber + runId` reste obligatoire.
- Durcit aussi l’enregistrement final contre une `releaseIdentity` absente ou incomplète.
- Ajoute `Test-RC41-Step3C-Fix2-Legacy-Backup-Manifest-Compatibility.ps1`.
