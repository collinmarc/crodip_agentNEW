# Release Notes — Runtime Manager 2.2.42 Stable

## Optional container_name Fix

Depuis l'isolation Compose, le Runtime utilise :

```yaml
name: crodip-runtime-local
```

sans `container_name` fixe.

La 2.2.36 conservait cependant un contrôle qui supposait encore que la propriété
`container_name` existait dans chaque service Compose.

La 2.2.42 traite cette propriété comme optionnelle.

Lorsque le Compose n'utilise aucun nom fixe, le Runtime affiche :

```text
[OK] Aucun container_name fixe : isolation Compose active.
```

et poursuit normalement vers `docker compose up`.

Le contrôle des anciens conflits de noms reste disponible uniquement pour les
anciens Compose qui déclarent réellement des `container_name`.
