# Release Notes — Runtime Manager 2.3.0-RC5

## Nouvelle fonction : mise à jour de la release TEST

Ajout du menu principal :

```text
14. Mettre à jour la release TEST
```

La commande associée est :

```text
commands\14-update-test-release.ps1
```

### Source par défaut

```text
C:\Dev\crodip-saas\config\official-release-pin.json
```

### Sécurité du processus

1. Le pin JSON est lu et validé.
2. Les quatre références `repo@sha256:<digest>` doivent être identifiées sans ambiguïté.
3. Les quatre images sont pullées avant toute bascule.
4. `config\runtime.json` est sauvegardé avant modification.
5. Le pin source est archivé.
6. LOCAL est réaligné et recréé s'il est installé.
7. CENTRAL est réaligné et recréé s'il est installé.
8. Le volume PostgreSQL CENTRAL est conservé.
9. La qualification technique Runtime est lancée automatiquement.

### Historique

```text
C:\ProgramData\CRODIP\release-history
```

### Qualification

Le résultat attendu est :

```text
RUNTIME TEST TECHNICALLY QUALIFIED
```

Cette qualification reste technique et ne constitue pas une qualification fonctionnelle/métier.
