## 2.3.0-RC41 FINAL QUALIFICATION — 2026-09-30
- Qualification E2E réelle #15 OFFICIAL → #14 TEST RECONSTRUCTED/EMPTY → #15 OFFICIAL.
- Restauration STAGÉE des bases et redéploiement des images compatibles.
- Retour final : override TEST inactif, Docker 4/4 #15 running, LOCAL/CENTRAL/GLOBAL PASS.
- FIX7 à FIX11 + qualification finale : 6/6 OK.
- Documentation embarquée synchronisée RC41.

## 2.3.0-RC41 STEP3E — Explicit TEST EMPTY Release Activation
- Ajout d'un chemin TEST explicite pour activer une release historique avec snapshot STEP3D RECONSTRUCTED/EMPTY qualifié.
- Double confirmation humaine et maintien de l'inéligibilité automatique STEP3B.
- Snapshot de sécurité de la release source et rollback transactionnel conservés.

# RC41 STEP2 GUARD FIX2

- Sécurise le dispatcher `Invoke-CrodipMenuCommand` lorsque `Write-CrodipError` n’est pas visible dans le scope courant.
- Le chemin DOWNGRADE bloqué utilise un fallback `[ERREUR]` natif et conserve la journalisation.
- Aucun changement de release, image ou base n’est effectué lorsque le snapshot cible est absent.

# 2.3.0-RC41 — Transactional Release Rollback & Database Snapshots

- Fondation des snapshots DB liés aux releases pour rollback DOWN sécurisé.
- SQLite LOCAL + PostgreSQL CENTRAL, identité run/commit/version, sans downgrade Alembic automatique.
- Première itération non destructive : branchement transactionnel après validation de la fondation.

# 2.3.0-RC40 — 2026-09-29

- Menu restructuré autour des runtimes LOCAL et CENTRAL.
- Politique de connectivité commune `AUTO / ONLINE / OFFLINE`, AUTO par défaut et persistée via `CRODIP_DEPLOYMENT_MODE`.
- OFFLINE : contrôle générique des images du Compose et démarrage `--pull never`; CENTRAL contrôle aussi `postgres:17`.
- Nettoyage de l'affichage OFFLINE LOCAL : suppression du double message de présence des images, tout en conservant l'import d'archives packagées LOCAL si nécessaire.
- Documentation embarquée synchronisée RC40 et qualification technique RC40 ajoutée.

- Correctif qualification : backup PRE-MIGRATION déplacé dans le moteur de migration afin de couvrir Start/Update/réconciliation et de bloquer Alembic si le backup échoue.

- Safe Database Migration & Release Compatibility.
- Baseline applicative 2.3.0-dev.4 / Official Build #15.
- Backup PRE-MIGRATION obligatoire avant update.
- Validation du head Alembic déclaré par la release contre le head embarqué dans l'image.
- Migration upgrade-only vers le head attendu et contrôle post-migration.
- Rapports JSON de migration.
- Aucun downgrade ni restore automatique en cas d'échec.
- Heads qualifiés : LOCAL ecd67252fd57 / CENTRAL 7544a84c3691.

## 2.3.0-RC39
- Sélection interactive des sauvegardes disponibles.
- Affichage du manifeste avant restauration.
- Chemin manuel conservé pour les archives externes.
- Durcissement des ACL SQLite Windows (`BUILTIN\Users:Modify`).

## 2.3.0-RC38
- Sauvegarde PostgreSQL CENTRAL par pg_dump custom.
- Restauration PostgreSQL contrôlée par pg_restore.
- Traçabilité des révisions Alembic LOCAL/CENTRAL dans chaque backup.
- Vérification DB automatique après restauration.

# CHANGELOG — CRODIP Runtime Manager

## 2.3.0-RC33 — Embedded Documentation Sync
- Documentation courante alignée sur build officiel #11 / application 2.3.0-dev.2.
- Documentation des overrides TEST persistants et de la vérité Docker.
- Documentation des menus 17/18/19 et de l’isolation LOCAL/CENTRAL.
- Aucun changement fonctionnel par rapport à RC32.

## 2.3.0-RC32

- Durcissement du retour à la release officielle (menu 18).
- Rollback de l’état override si le redéploiement officiel échoue.
- Accès StrictMode-safe aux propriétés optionnelles de l’override.

## 2.3.0-RC27
- Menu 17 : téléchargement sélectif des artefacts GitHub Actions.
- Exclusion des artefacts BuildKit `*.dockerbuild`.
- Recherche et validation du manifest par commit avant activation de l’override TEST.

# 2.3.0-RC26

- Correction du parseur PowerShell du menu 17 : chaînes contenant des apostrophes typographiques sécurisées avec des guillemets doubles.
- Conservation de la sélection d’un run CI historique pour TEST et du retour à la release officielle.
- Conservation du menu 19 d’informations sur le run actif.
- Ajout d’un test de qualification syntaxique PowerShell de tous les fichiers `.ps1` et `.psm1`.

# 2.3.0-RC25

- Correctif syntaxique menu run historique.
- Ajout du menu Informations sur le run actif.
- Quitter déplacé en entrée 20.

## 2.3.0-RC24 - Historical CI Run TEST Override

## Historical CI Run TEST Override

- Ajoute le chargement d’un run `CRODIP Official Build` antérieur et réussi pour TEST.
- Télécharge les artefacts du run via GitHub CLI et retrouve le `manifest.json` correspondant au commit du run.
- Vérifie les quatre images LOCAL/CENTRAL et leurs digests SHA-256.
- Crée un `testOverride` temporaire sans modifier la release officielle épinglée.
- Pull et redéploie les images exactes par digest.
- Ajoute le retour explicite à la release officielle.
- Préserve le volume PostgreSQL CENTRAL ; avertissement explicite avant downgrade.
- Les `.env` LOCAL et CENTRAL utilisent la release effective (officielle ou override TEST).

### Menu

- 17. Charger un run CI antérieur pour TEST
- 18. Revenir à la release officielle
- 19. Quitter

## 2.3.0-RC22 — StrictMode Port Control & Official Build #11 Traceability

- Corrige le contrôle des services Compose sans propriété `ports`.
- Aligne le pin Runtime sur l’application 2.3.0-dev.2 / build officiel #11.
- Conserve l’isolation TEST LOCAL 8110/9110 et CENTRAL 8120/9120.
- Renforce la traçabilité manifest → images → conteneurs.

## 2.3.0-RC22 — CENTRAL Port Isolation & Release Traceability

- Isolation stricte des ports LOCAL/CENTRAL.
- Contrôle des ports CENTRAL avant démarrage.
- Traçabilité application / run / commit / manifest / digests / labels OCI.

# 2.3.0-RC22

- Correction de l’export des fonctions RC19 de réconciliation et contrôle des ports Docker.
- Ajout d’une garde de chargement et d’un test de non-régression.

# 2.3.0-RC22

- Réconciliation automatique des PortBindings Docker avec Compose.
- Suppression ciblée des conteneurs dont les ports sont obsolètes.
- Contrôle post-démarrage des ports réellement publiés.

# 2.3.0-RC22
- Imposition des ports du lifecycle actif dans le processus Docker Compose.
- Recréation forcée des conteneurs pour appliquer les mappings de ports TEST.

## 2.3.0-RC17 — 2026-09-18

- Corrige la synchronisation des ports du Runtime installé avec le cycle de vie actif.
- TEST/LOCAL : backend `8110`, frontend `9110`.
- TEST/CENTRAL : backend `8120`, frontend `9120`.
- `Set-CrodipRuntimeImageEnvironment` synchronise désormais également `CRODIP_BACKEND_PORT` et `CRODIP_FRONTEND_PORT`.
- Empêche la conservation accidentelle du port DEV `9010` dans un `.env` Runtime TEST historique.

# Changelog

## 2.3.0-RC16 — 2026-09-15
- Correction détection Docker CLI après installation Docker Desktop.
- Résolveur canonique PATH + chemin Program Files.
- Menu technique et exécution Docker alignés.


## 2.3.0-RC15 — 2026-09-15
- Timeout global Winget remplacé par timeout d'inactivité observable.
- Support des téléchargements Docker Desktop lents.


## 2.3.0-RC14 — 2026-09-15
- Supervision de l'installation Docker Desktop via Winget.
- Progression 15 s, logs stdout/stderr, timeout 900 s, code retour et protection concurrence Winget.


## 2.3.0-RC13 — 2026-09-15
- Installation automatique Docker Desktop sur Fresh Install si absent.
- WSL2/Ubuntu + GitHub CLI intégrés au bootstrap technique.
- Démarrage/attente du moteur et qualification Docker CLI/Compose/info.


## 2.3.0-RC12 — 2026-09-15
- Export de Get-CrodipGitHubCliExecutable.
- Ajout d'un test de contrat avec import réel du module GitHub et Get-Command.


## 2.3.0-RC11 — 2026-09-15
- Détection GitHub CLI compatible StrictMode, sans dépendance à Count.
- Recherche PATH et chemins Program Files.


## 2.3.0-RC10 — 2026-09-15
- Alignement menu 16 sur signatures réelles des fonctions Docker/WSL.
- Suppression des paramètres `-Confirm` invalides et des doubles confirmations.
- Détection GitHub CLI renforcée hors PATH.


## 2.3.0-RC9 — 2026-09-15
- Correction interpolation `${Path}?ref=$Ref` pour GitHub API.
- Nouveau menu de cycle de vie des composants techniques.
- Désinstallation explicite GitHub CLI, Docker Desktop, Ubuntu/WSL2 et pile complète.
- Conservation par défaut des composants partagés lors de la désinstallation Runtime.


## 2.3.0-RC8 — 2026-09-15
- Correction GET GitHub API avec `?ref=main`.
- Alignement strict sur le schéma réel `official-release-pin.json` v1.
- GitHub CLI ajouté aux composants techniques de l'installation fraîche.
- Authentification GitHub différée à la première utilisation.


## 2.3.0-RC7 — 2026-09-15
- GitHub CLI intégré et installable via Winget.
- Authentification `gh auth login --web`.
- Pin officiel récupéré via GitHub API authentifiée.


## 2.3.0-RC6 — 2026-09-14

- Suppression de la dépendance Runtime à `C:\Dev\crodip-saas`.
- Téléchargement HTTPS du pin officiel en priorité.
- Support optionnel de `GITHUB_TOKEN` pour dépôt privé.
- Import manuel via `C:\ProgramData\CRODIP\release\incoming`.
- Cache du pin actif sous `C:\ProgramData\CRODIP\release\current`.
- Validation stricte du schéma `official-release-pin.json`.


## 2.3.0-RC5 — 2026-09-14

- Ajout de l'option 14 `Mettre à jour la release TEST`.
- Import du pin officiel depuis le workspace CRODIP.
- Validation et pull préalable des quatre images par digest.
- Sauvegarde de `runtime.json` avant bascule.
- Redéploiement LOCAL/CENTRAL sans suppression du volume PostgreSQL.
- Qualification technique automatique après mise à jour.


## 2.3.0-RC4 — 2026-09-14

- Ajout de l'option 13 de qualification technique au menu principal.
- Quitter déplacé en option 14.
- Refonte de la page État du Runtime CENTRAL.
- Ajout des contrôles lisibles PostgreSQL, digests et HTTP CENTRAL.


## 2.3.0-RC3 — 2026-09-14

- Correctif des faux négatifs sur les 4 contrôles de digest.
- Utilisation de `docker inspect .Config.Image` au lieu de `docker ps .Image`.
- Aucun changement des images officielles ni des ports.


## 2.3.0-RC2 — 2026-09-14

- Qualification technique Runtime automatisée LOCAL + CENTRAL.
- Contrôles HTTP et digests officiels.
- PostgreSQL CENTRAL healthy.
- Génération runtime-qualification.json.


## 2.3.0-RC1 — 2026-09-14

- Alignement Kit DEV 6.3.0-RC6.5.13.58.
- Pin officiel application 2.3.0-dev.1, Run #10.
- Images applicatives référencées par digest.
- Plan DEV/TEST/PREPROD/PROD documenté.
- Profil actif TEST et promotion PREPROD/PROD non autorisée à ce jalon.

## 2.2.49 - Harmonized Runtime Port Plan
- Runtime LOCAL : backend 8110, frontend 9110.
- Runtime CENTRAL : backend 8120, frontend 9120.
- Alignement sur le Kit DEV 6.2.105.
- SQLite LOCAL et PostgreSQL CENTRAL conservés.
- README, nomenclature, templates Compose/.env et tests actualisés.

## 2.2.48 - Dual LOCAL CENTRAL Runtime Manager
- LOCAL reste le Runtime installé par défaut sur 9000/8000 avec SQLite.
- Ajout du Runtime CENTRAL optionnel de simulation sur 9200/8200.
- Projet Compose CENTRAL isolé : `crodip-runtime-central`.
- PostgreSQL 17 dédié au CENTRAL.
- Sous-menu CENTRAL : installation, start, stop, status, update, logs, uninstall.
- Conservation du tag Docker unique `config/runtime.json -> docker.imageTag`.
- Ajout du test `Test-DualRuntimeManager-2248.ps1`.

## 2.2.47 - Common Module Export Parser Fix
- Correction du littéral `` `n `` invalide dans `Export-ModuleMember`.
- Restauration du parsing de `Crodip.Runtime.Common.psm1`.
- Conservation de la source unique `config/runtime.json -> docker.imageTag`.
- Ajout du test de parsing `Test-CommonModuleExportParser-2247.ps1`.

## 2.2.46 - Centralized Docker Image Tag Fix
- `config/runtime.json -> docker.imageTag` devient la source unique du tag Docker.
- Repositories Docker séparés du tag.
- Génération automatique des images LOCAL/CENTRAL.
- `.env` synchronisé à l'installation, à la réparation et à la mise à jour.
- Manifest offline sans version d'image dupliquée.
- Qualification de l'alignement imageTag / .env.
- Ajout du test `Test-CentralizedDockerImageTag-2246.ps1`.

## 2.2.45 - DEV Runtime Coherence Fix
- Alignement VERSION / STATUS / runtime.json / images-manifest / release manifest.
- Suppression du second pull Compose global dans `08-update.ps1`.
- Suppression de la réutilisation erronée de `$pull`.
- Le flux d'update utilise uniquement les services/images réellement déclarés dans Compose.
- Conservation de SQLite pour Runtime LOCAL et de la nomenclature LOCAL/CENTRAL.
- Validation de cohérence avec le Kit DEV 951-11 v6.2.96.

# CHANGELOG

## 2.2.1 — Lot 4 AUTO GHCR

- Administration Docker et authentification GHCR.
- Déploiement auto/online/offline.
- Fallback sur images TAR locales.
- Manifest des images offline.

## 2.2.1 — Lot 4 Corrected

- Correction du choix 8 Mise à jour.
- Import explicite du module Compose.
- Utilisation de `Get-CrodipComposeFile`.
- Sauvegarde de sécurité annoncée avant mise à jour.
- Ajout du test `Test-Lot4-Update.ps1`.

## 2.2.1 — Lot 4 Docker Manager

- Ajout du module Compose.
- Réécriture des commandes 03, 04 et 05.
- Dashboard Docker avec noms fixes.
- Rapports Docker TXT, Markdown et JSON.
- Ajout du test Test-Lot4-Docker.ps1.

## 2.2.1 — Lot 3 Corrected2

- Suppression des recommandations de réparation sur les contrôles `OK`.
- Filtrage défensif dans le Dashboard.
- Filtrage identique dans les rapports TXT et Markdown.
- Ajout du test `Test-Lot3-CorrectionDisplay.ps1`.

## 2.2.1 — Lot 3 Corrected

- Correction du formatage des lignes TXT et Markdown.
- Suppression de l'ambiguïté entre l'opérateur `-f` et les arguments de `.Add()`.
- Ajout du test `Test-Lot3-Formatting.ps1`.

## 2.2.1 — Lot 3 Runtime Dashboard

- Ajout du module Health.
- Refactorisation de `02-check.ps1`.
- Ajout du score global et des niveaux de gravité.
- Génération des rapports TXT, Markdown et JSON.
- Conservation de l'historique des diagnostics.
- Ajout du mode `-Quiet`.
- Ajout du test `Test-Lot3-Health.ps1`.

## 2.2.1 — Lot 2 Clean

- Reconstruction du Lot 2 à partir du Lot 1 validé.
- Ajout du sous-menu Installation.
- Ajout des commandes Réparer, Vérifier et Réinstaller.
- Réécriture de l'installation et de la désinstallation.
- Ajout de `-WhatIf` sur les opérations système.
- Conservation des données métier par défaut.
- Correction des conflits `$HOME` et des interpolations PowerShell.
- Ajout du test `Test-Lot2-Clean.ps1`.

## 2.2.1 — Stable — Lot 1 Infrastructure

- Bootstrap réécrit et lisible.
- Sous-menu Sauvegarde appelé correctement.
- Chargement sécurisé des modules et de la configuration.
- Gestion centralisée des erreurs de commandes.
- Modules Common, Windows, Logging et Docker normalisés.
- Rotation élémentaire des journaux.
- Exports explicites et absence d’imports imbriqués.
- Configuration enrichie avec build et paramètres de qualité.
- Ajout du test statique du Lot 1.


## 2.3.0-RC23
- Isolation et création automatique des `.env` LOCAL/CENTRAL.
- Synchronisation target-aware des ports et images avant Compose.
- CENTRAL aligné sur `templates\central\.env` et 8120/9120 en TEST.
- Pin officiel build #11 / application 2.3.0-dev.2 conservé.

## 2.3.0-RC30
- Persistent TEST override in ProgramData state.
- Docker runtime truth in menu 19.

## 2.3.0-RC31
- Réconciliation du run actif à partir des labels OCI Docker et des manifests historiques.
- Reconstruction de l'override persistant pour les runs historiques déjà déployés avant RC30.
- Séparation de l'état de cohérence de release et de l'état opérationnel des conteneurs.


## 2.3.0-RC37
- Migration Alembic automatique LOCAL/CENTRAL après démarrage et mise à jour.
- Head dynamique issu de l’image backend active.
- Aucun downgrade automatique ; incompatibilité historique bloquante et explicite.
- Menu 20 aligné sur le head de l’image active.

## 2.3.0-RC38
- Sauvegarde complète avec SQLite LOCAL et dump PostgreSQL CENTRAL au format custom.
- Traçabilité des révisions Alembic dans `BACKUP-MANIFEST.json`.
- Restauration contrôlée SQLite + PostgreSQL suivie de la vérification des bases.

## 2.3.0-RC39
- Sélection interactive des sauvegardes, triées de la plus récente à la plus ancienne.
- Sélection numérotée, chemin manuel (`M`) et retour (`R`).
- Affichage du manifest avant confirmation de restauration.
- Durcissement des ACL SQLite avec `BUILTIN\\Users` / SID `S-1-5-32-545` en `Modify`.
- Normalisation ACL lors de l'installation/réparation et après restauration.
- Qualification E2E le 2026-09-28 : restauration RC38 -> RC39, données LOCAL/CENTRAL, Alembic, health DB, ACL et écriture SQLite PASS.

### RC41 STEP3B - Transactional release change
- Raccorde le moteur STEP3A au changement de release TEST pour les DOWNGRADE.
- Exige un snapshot cible qualifié SQLite + PostgreSQL + Alembic avant confirmation.
- Confirmation renforcée `SWITCH-RUNTIME-ROLLBACK` pour un DOWNGRADE.
- Restaure les bases de la release cible avant activation des images.
- En cas d'échec d'activation, tente une restauration DB depuis le snapshot de sécurité de la release source.
- Le garde-fou reste bloquant si aucun snapshot cible compatible n'existe.

## 2.3.0-RC41 - STEP3C Historical Release Snapshot Bootstrap
- Recherche les sauvegardes historiques portant réellement l'identité du run cible.
- Refuse de ré-étiqueter une sauvegarde d'une autre release.
- Qualifie SQLite LOCAL et PostgreSQL CENTRAL par comparaison des révisions Alembic avec les images backend cibles.
- Enregistre uniquement un backup historique qualifié dans `release-snapshots/run-<run>-<runId>`.
- Ne restaure et ne modifie aucune base active pendant le bootstrap historique.

## RC41 STEP3C FIX1 - Résolution automatique release historique
- `20-bootstrap-historical-release-snapshot.ps1` n'exige plus que `-RunNumber` côté opérateur.
- Run ID, version applicative, commit et références d'images sont résolus depuis le run `CRODIP Official Build` réussi et son manifest officiel.
- Les anciens paramètres restent optionnels pour diagnostic et sont rejetés s'ils contredisent le manifest.
- Aucun changement du garde-fou : STEP3C ne modifie pas les bases actives et refuse de fabriquer un snapshot historique depuis la release courante.
