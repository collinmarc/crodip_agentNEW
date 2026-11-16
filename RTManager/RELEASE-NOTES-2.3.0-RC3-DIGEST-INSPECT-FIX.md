# Release Notes — Runtime Manager 2.3.0-RC3

## Correctif

RC2 produisait quatre faux négatifs lors du contrôle des digests :

```text
backend digest  [ERREUR] 52111a6951ea
...
```

La cause était l'utilisation du champ `Image` de `docker ps`, susceptible de
retourner un identifiant abrégé.

RC3 contrôle la référence réellement configurée dans le conteneur avec :

```powershell
docker inspect --format "{{.Config.Image}}" <container>
```

Cette référence est ensuite comparée exactement à la valeur
`repo@sha256:digest` du pin officiel.

Aucun digest officiel, aucun port et aucune image applicative n'ont été modifiés.
