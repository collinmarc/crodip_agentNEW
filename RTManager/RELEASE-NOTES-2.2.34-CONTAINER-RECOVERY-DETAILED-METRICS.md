# Release Notes — Runtime Manager 2.2.42 Stable

## Container Conflict Recovery

Avant `docker compose up`, le Runtime détecte les noms de conteneurs attendus
par Compose et recherche les conteneurs déjà existants.

Pour chaque conflit, il affiche :

- nom ;
- ID court ;
- état ;
- image ;
- projet Compose ;
- service Compose ;
- working directory ;
- fichier Compose d'origine ;
- identification CRODIP.

Si le conteneur est clairement identifié comme un ancien conteneur CRODIP, le
Runtime propose sa suppression.

Les conteneurs inconnus ne sont jamais supprimés automatiquement.

## Detailed Metrics

La vérification et le démarrage produisent des métriques plus détaillées.

La vérification inclut désormais les durées par HealthCheck lorsque
`DurationMs` est disponible.

Le démarrage distingue notamment :

- qualification Windows ;
- résolution provider Docker ;
- Docker Desktop readiness ;
- images / GHCR / Compose ;
- attente de stabilisation des conteneurs ;
- lecture de l'état des conteneurs.

Rapports :

```text
C:\ProgramData\CRODIP\logs\reports\check-performance.txt
C:\ProgramData\CRODIP\logs\reports\check-performance.json
C:\ProgramData\CRODIP\logs\reports\startup-performance.txt
C:\ProgramData\CRODIP\logs\reports\startup-performance.json
```

Seuils :
- OK < 5 s
- SLOW >= 5 s
- VERY_SLOW >= 15 s
