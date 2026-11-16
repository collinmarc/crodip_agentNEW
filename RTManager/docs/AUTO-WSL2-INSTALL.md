# Installation automatique de WSL2 — Runtime 2.2.42

## Comportement

Lorsque le provider sélectionné est Docker Desktop, le Runtime Manager vérifie
WSL2 avant de poursuivre.

```text
Docker Desktop sélectionné
        ↓
WSL2 installé ?
   ├─ OUI → continuer
   └─ NON
        ↓
Runtime administrateur ?
   ├─ NON → demander relance administrateur
   └─ OUI
        ↓
wsl --install -d Ubuntu
        ↓
wsl --set-default-version 2
        ↓
demander redémarrage Windows
```

L'installation automatique est déclenchée depuis :

- `1. Installation` ;
- `3. Démarrer`.

Le Runtime ne tente pas Docker/GHCR tant que WSL2 n'est pas prêt.

## Après installation

Si Windows demande un redémarrage :

```text
1. Redémarrer Windows
2. Relancer le Runtime Manager en administrateur
3. Relancer Installation ou Démarrer
```
