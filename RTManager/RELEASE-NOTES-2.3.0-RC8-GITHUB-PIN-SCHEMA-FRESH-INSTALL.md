# Runtime Manager 2.3.0-RC8

## Corrections

1. Requête GitHub API corrigée :
   `repos/IDWEBCONCEPT/crodip-saas/contents/config/official-release-pin.json?ref=main`
2. Suppression de `-f ref=main`.
3. Parser aligné strictement sur le schéma réel `schemaVersion: 1`.
4. Lecture de `officialRunId`, `officialRunNumber`, `gitCommit`.
5. Lecture stricte du tableau `images[]` par `key`.
6. Validation des quatre repositories et digests SHA-256.
7. GitHub CLI installé automatiquement pendant une installation fraîche du Runtime.
8. Authentification GitHub différée à la première utilisation, afin de ne pas bloquer l'installation technique.
