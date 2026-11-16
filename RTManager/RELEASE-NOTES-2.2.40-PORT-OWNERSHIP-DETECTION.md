# Release Notes — Runtime Manager 2.2.42 Stable

## Port Ownership Detection

Le contrôle de ports ne considère plus tout listener Windows comme un conflit.

Le Runtime distingue désormais :

```text
AVAILABLE
OWNED_BY_CURRENT_RUNTIME
CONFLICT_DOCKER
CONFLICT_WINDOWS
DOCKER_RELAY_ONLY
```

### Exemple attendu

Si `9000` est déjà publié par :

```text
crodip-runtime-local-frontend-1
```

avec un relais `wslrelay`, le résultat devient :

```text
[OK] Port 9000 déjà utilisé par le service Runtime courant frontend.
     Conteneur : crodip-runtime-local-frontend-1
     Projet    : crodip-runtime-local
     Service   : frontend
     Relais Docker/WSL : wslrelay
```

Il n'y a plus de faux conflit basé uniquement sur deux listeners IPv4/IPv6.

### Conflits réels

Un autre projet Compose, par exemple `crodip-dev-local`, utilisant le même port
est signalé comme `CONFLICT_DOCKER`.

Un processus Windows externe utilisant le port est signalé avec son PID et son
nom de processus.
