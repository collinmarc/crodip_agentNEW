# Release Notes — Runtime Manager 2.3.0-RC6

## Correction majeure

RC5 dépendait à tort de :

```text
C:\Dev\crodip-saas\config\official-release-pin.json
```

Une machine Runtime ne possède pas nécessairement de workspace DEV.

RC6 supprime cette dépendance.

## Nouvelle stratégie

L'option :

```text
14. Mettre à jour la release TEST
```

cherche le pin dans cet ordre :

```text
1. HTTPS GitHub
2. C:\ProgramData\CRODIP\release\incoming\official-release-pin.json
3. C:\ProgramData\CRODIP\release\current\official-release-pin.json
```

URL par défaut :

```text
https://raw.githubusercontent.com/IDWEBCONCEPT/crodip-saas/main/config/official-release-pin.json
```

Le schéma du pin est validé explicitement :

- `runId`
- `runNumber`
- `commit`
- `applicationVersion`
- `status`
- `images.localBackend`
- `images.localFrontend`
- `images.centralBackend`
- `images.centralFrontend`

Le statut doit être :

```text
RELEASE READY FOR TEST
```

## Dépôt privé

Si l'accès anonyme est interdit, définir avant le lancement :

```powershell
$env:GITHUB_TOKEN = "<token>"
```

Ou copier manuellement le pin dans :

```text
C:\ProgramData\CRODIP\release\incoming\official-release-pin.json
```

Aucune dépendance à `C:\Dev` n'est conservée.
