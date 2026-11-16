# RC41 STEP3E FIX9 — Topology Port Resolution & Runtime Scope Hardening

Constat du test réel :
- TEST/LOCAL a été recréé avec les ports CENTRAL (backend 8120, frontend 9120).
- Le frontend CENTRAL occupait légitimement 9120, provoquant l'échec du frontend LOCAL.
- `Get-CrodipHome` redevenait indisponible dans la phase transactionnelle après des réimports de modules `-Force`.

Correctifs :
1. `Get-CrodipHome` est résolu une seule fois au démarrage de `17-historical-test-run.ps1`.
2. `Sync-And-Redeploy` utilise cette valeur figée et n'appelle plus dynamiquement `Get-CrodipHome`.
3. Avant redéploiement, les ports sont relus depuis `docker.lifecyclePorts` selon `activeLifecycle`.
4. Le redéploiement LOCAL impose ses ports au scope Process, car Docker Compose donne priorité aux variables Process sur `.env`.
5. Les variables Process antérieures sont restaurées en `finally`.
6. Un garde-fou bloque toute topologie dont les ports LOCAL et CENTRAL ne sont pas isolés.

Pour TEST, le plan canonique qualifié est :
- LOCAL backend 8110 / frontend 9110
- CENTRAL backend 8120 / frontend 9120

Le mécanisme de rollback atomique FIX7 n'est pas supprimé.
