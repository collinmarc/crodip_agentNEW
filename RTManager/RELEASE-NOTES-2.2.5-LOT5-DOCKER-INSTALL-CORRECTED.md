# Release Notes — 2.2.42 Stable — Lot 5 Docker Install Corrected

## Correction

Le Runtime pouvait importer le fichier `Crodip.Runtime.DockerProvider.psm1`
sans rendre ses fonctions visibles dans la session appelante.

La version 2.2.42 ajoute :

- un loader explicite `Crodip.Runtime.DockerProvider.Loader.psm1` ;
- suppression des modules provider déjà chargés avant réimport ;
- import avec `-PassThru` ;
- vérification des commandes réellement exportées ;
- module provider rendu autonome pour la résolution de `CRODIP_HOME`;
- contrôle immédiat avant affichage du menu Administration Docker.

Ainsi, le menu ne peut plus continuer silencieusement si
`Get-CrodipDockerProviderInfo` n'est pas disponible.
