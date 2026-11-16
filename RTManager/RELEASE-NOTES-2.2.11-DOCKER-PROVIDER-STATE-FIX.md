# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — Docker Provider State Fix

### Cause corrigée

Le choix :

```text
4. Utiliser Docker Desktop
```

pouvait produire :

```text
The variable '$script:lines' cannot be retrieved because it has not been set.
```

La cause était dans `Set-CrodipDockerProvider` :

- `$lines` était une variable locale ;
- la fonction imbriquée tentait de modifier `$script:lines`.

### Correction

`Set-CrodipDockerProvider` reconstruit désormais directement le contenu du
`.env` sans variable de scope script.

Le choix du provider est persisté sous :

```text
C:\Program Files\CRODIP\.env
```

avec :

```dotenv
CRODIP_DOCKER_PROVIDER=desktop
```

ou :

```dotenv
CRODIP_DOCKER_PROVIDER=ubuntu
CRODIP_WSL_DISTRO=Ubuntu
```

### Test

```powershell
.\tests\Test-Lot5-DockerProvider-State-2211.ps1
```

Résultat attendu :

```text
[OK] État du provider Docker - correctif 2.2.42 validé.
```
