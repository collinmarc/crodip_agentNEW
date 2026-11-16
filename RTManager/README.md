# CRODIP SaaS Runtime Manager 2.3.0-RC41

**Statut :** Release Candidate qualifiée — Transactional Release Rollback & Database Snapshots  
**Date de qualification :** 2026-09-30  
**Application officielle :** `2.3.0-dev.4`  
**Cycle :** `TEST`  
**Release officielle :** Build `#15` / Run ID `36452467983`  
**Commit :** `53928c1f30a8a90cc6a1cf467d5c332f10494a80`  
**Politique :** `build-once-promote-same-digest`

## État de référence RC41

RC41 ajoute au socle RC40 le changement transactionnel de release TEST avec snapshots de bases liés aux releases. Un downgrade Alembic automatique reste interdit. Pour une release historique sans snapshot métier authentique, un snapshot `RECONSTRUCTED/EMPTY` qualifié peut être activé uniquement en TEST, après double confirmation explicite.

Le scénario réel qualifié le 30/09/2026 est : **#15 OFFICIAL → #14 TEST RECONSTRUCTED/EMPTY → #15 OFFICIAL**, avec restauration stagée des bases compatibles, redéploiement des quatre images par digest et qualification finale des deux topologies.

| État | LOCAL Alembic | CENTRAL Alembic | Résultat |
|---|---|---|---|
| #15 / `2.3.0-dev.4` OFFICIAL | `ecd67252fd57` | `7544a84c3691` | PASS |
| #14 / `2.3.0-dev.3` TEST EMPTY | `d24d83ea9494` | `3452c4fc44ba` | PASS |
| Retour #15 OFFICIAL | `ecd67252fd57` | `7544a84c3691` | GLOBAL PASS |

Ports TEST canoniques : LOCAL `9110/8110`, CENTRAL `9120/8120`. Le retour final qualifié présente un override TEST **INACTIF**, quatre services Docker #15 `running`, un état release **COHERENT** et un état services **OPERATIONNEL**.

## Garde-fous RC41

- snapshot de sécurité obligatoire avant changement de release ;
- séparation stricte des snapshots historiques authentiques et `RECONSTRUCTED/EMPTY` ;
- restauration STAGÉE avant redéploiement d'images compatibles ;
- invariant `release = image = database` ;
- contexte Alembic cible limité au scope `Process` ;
- rollback source obligatoire en cas d'échec après modification DB ;
- isolation des ports LOCAL/CENTRAL ;
- conservation du volume PostgreSQL CENTRAL ;
- pin officiel jamais modifié par un override TEST.

Voir `docs/QUALIFICATION-RC41.md`, `docs/BACKUP-RESTORE-DATABASES.md` et `RELEASE-NOTES-2.3.0-RC41-STEP3E-FIX11.md`.

> Les sections RC40 et antérieures conservées plus bas sont historiques. En cas de divergence, cette section RC41 et `config/runtime.json` décrivent l'état courant.

---

# CRODIP SaaS Runtime Manager 2.3.0-RC40

**Statut :** Release Candidate — Safe Database Migration & Release Compatibility  
**Application :** `2.3.0-dev.4`  
**Cycle :** `TEST`  
**Release officielle :** Build `#15` / Run ID `36452467983`  
**Commit :** `53928c1f30a8a90cc6a1cf467d5c332f10494a80`  
**Politique :** `build-once-promote-same-digest`

## État courant RC40

Le Runtime Manager gère deux runtimes de premier niveau : **LOCAL** (SQLite) et **CENTRAL** (PostgreSQL 17). Les images applicatives sont consommées par digest officiel, sans rebuild Runtime.

| Cible | Frontend | Backend | Base | Alembic attendu |
|---|---:|---:|---|---|
| LOCAL | 9110 | 8110 | SQLite | `ecd67252fd57` |
| CENTRAL | 9120 | 8120 | PostgreSQL 17 | `7544a84c3691` |

RC40 impose la compatibilité `releaseExpectedHead = imageHead = databaseCurrent`. CENTRAL effectue une sauvegarde PRE-MIGRATION obligatoire avant toute migration modifiant la base. Aucun downgrade ni restore automatique n'est exécuté.

## Connectivité AUTO / ONLINE / OFFLINE

La politique est persistée dans le `.env` installé via `CRODIP_DEPLOYMENT_MODE`. Valeurs : `auto`, `online`, `offline`. Si la valeur est absente, **AUTO** est utilisé.

- **AUTO (défaut)** : teste l'accès registre ; ONLINE si accessible, sinon fallback OFFLINE.
- **ONLINE** : accès registre requis et pull des images déclarées.
- **OFFLINE** : aucun pull ; toutes les images requises doivent être disponibles localement ; Compose démarre avec `--pull never`.
- LOCAL contrôle backend + frontend. CENTRAL contrôle `postgres:17` + backend + frontend.
- Le mode configuré est persistant ; le mode effectif ONLINE/OFFLINE est recalculé à chaque démarrage en AUTO.

## Qualification technique RC40

Les essais réalisés le 29/09/2026 valident AUTO→ONLINE et OFFLINE sur LOCAL et CENTRAL, les digests officiels, les endpoints techniques, SQLite/PostgreSQL et la compatibilité Alembic. Voir `docs/QUALIFICATION-RC40.md`.

> Les sections historiques conservées plus bas décrivent les RC antérieures. En cas de divergence, cette section RC40 et `config/runtime.json` font référence pour l'état courant.

---

<!-- RC39-DOC-SYNC-20260928 -->
# CRODIP SaaS Runtime Manager 2.3.0-RC40

**Statut :** Release Candidate — RC39 qualifiée E2E sur le périmètre sauvegarde/restauration et ACL SQLite  
**Date de qualification :** 2026-09-28  
**Application officielle :** `2.3.0-dev.3`  
**Build officiel :** `#14` / Run `35976894313`

## État de référence RC39

RC39 ajoute la sélection interactive des sauvegardes et le durcissement des ACL SQLite, tout en conservant le moteur de sauvegarde/restauration RC38. La qualification E2E a démontré la restauration effective d'une sauvegarde RC38 sous RC39 pour SQLite LOCAL et PostgreSQL CENTRAL.

Révisions Alembic qualifiées pour le Build officiel #14 :

- LOCAL / SQLite : `d24d83ea9494` ;
- CENTRAL / PostgreSQL : `3452c4fc44ba`.

Après restauration, `19-verify-databases.ps1` retourne `LOCAL PASS`, `CENTRAL PASS` et `GLOBAL PASS`. Le marqueur fonctionnel de qualification est revenu de `AFTER_BACKUP` à `BEFORE_BACKUP` dans les deux bases. Les ACL SQLite restent en `Modify` pour BUILTIN\Utilisateurs et un test `INSERT + ROLLBACK` depuis le backend est PASS.

Documentation de référence :

- `docs/BACKUP-RESTORE-DATABASES.md` ;
- `docs/QUALIFICATION-RC39.md` ;
- `RELEASE-NOTES-2.3.0-RC40-INTERACTIVE-BACKUP-SELECTION.md`.

> Les sections historiques conservées plus bas documentent les RC antérieures. En cas de divergence, la présente section RC39 et `config/runtime.json` décrivent l'état courant.

<!-- /RC39-DOC-SYNC-20260928 -->


### Vérification intégrée des bases

Le menu `20. Vérifier SQLite LOCAL + PostgreSQL CENTRAL` vérifie les deux
moteurs de persistance sans modification des données. Il contrôle également
`/health/db` et la version Alembic. Pour le Build officiel #14, les heads
attendus sont `d24d83ea9494` (LOCAL) et `3452c4fc44ba` (CENTRAL).


### Sauvegarde / restauration RC38

Les sauvegardes incluent SQLite LOCAL et, si CENTRAL est déployé, un dump PostgreSQL au format custom. Le manifeste de sauvegarde trace la révision Alembic réellement sauvegardée pour chaque topologie. La restauration contrôle les bases après réinjection.

## Runtime Manager 2.3.0-RC40

Le Runtime Manager RC39 est aligné sur le **Kit DEV 6.3.2** et sur la release
technique qualifiée **Build #14 / application 2.3.0-dev.3**.

Le menu **17 - Changer la release Runtime TEST** permet désormais de sélectionner
un run réussi du workflow `CRODIP Official Build`, qu'il soit **antérieur ou
postérieur** au Build officiel courant. Le manifest du run est récupéré, les
quatre images sont résolues par **digest**, puis le Runtime TEST est redéployé
sans modifier le pin officiel.

Le menu **18** restaure à tout moment la release officielle Build #14.

La sélection d'une autre release est un **override TEST persistant**. Le volume
PostgreSQL CENTRAL est conservé. Un changement de version, dans un sens comme
dans l'autre, exige donc que le schéma de données reste compatible avec la
release sélectionnée.

Référentiel courant :

- Kit DEV : `6.3.2`
- Révision qualifiée : `RC6.5.13.88`
- Application officielle : `2.3.0-dev.3`
- Build officiel : `#14`
- Run ID : `35976894313`
- Commit : `8bb3014438c21d00b1239839b465fe86a7e27130`
- Politique : `Build Once / Promote Same Digest`


# CRODIP SaaS Runtime Manager

**Version :** 2.3.0-RC33  
**Statut :** Release Candidate - Embedded Documentation Sync  
**Date :** 2026-09-18  
**Application officiellement épinglée :** `2.3.0-dev.2`

## Objet

Le Runtime Manager installe et administre les runtimes CRODIP sur Windows. Cette RC aligne le Runtime sur la gouvernance actuelle du Kit DEV 951-11 et sur la release officielle CI #11 : topologies LOCAL/CENTRAL, cycle DEV/TEST/PREPROD/PROD, build officiel CI et promotion par digest.

## Point essentiel : le Runtime ne rebuild pas l'application

Les images consommées sont celles du build officiel GitHub Actions. Le Runtime utilise des références `repo@sha256:digest` et respecte la règle **build once / promote same digest**.

Build officiel actuellement épinglé :

- application : `2.3.0-dev.2`
- Run : `#11` / `35279460805`
- commit : `43d080b1b39c23dced5be6183840a5c944bccae3`
- statut amont : `RELEASE READY FOR TEST`

Comme cette application n'est actuellement qualifiée que techniquement pour TEST, cette RC du Runtime reste elle-même un **Release Candidate** et n'autorise pas une promotion PREPROD/PROD.

## État courant — RC33

La source de vérité de la release officielle est `config/runtime.json`. La release officielle reste le build CI **#11 / 35279460805**, application **2.3.0-dev.2**, commit `43d080b1b39c23dced5be6183840a5c944bccae3`.

Le Runtime distingue désormais trois états : la **release officielle**, l’**override TEST persistant** sous `C:\ProgramData\CRODIP\state\test-override.json`, et la **vérité Docker** déterminée depuis les conteneurs réellement présents. Le menu **17** charge un run CI historique pour TEST, le menu **18** restaure la release officielle et le menu **19** réconcilie le run actif avec Docker et l’historique local.

Un runtime peut être **cohérent** sur une même release tout en étant **dégradé** si certains conteneurs ne sont pas `running`. Le volume PostgreSQL CENTRAL `crodip-runtime-central-postgres` est persistant et ne doit pas être supprimé automatiquement lors d’un changement de release.

## Topologies et cycle de vie

LOCAL/CENTRAL décrivent la topologie. DEV/TEST/PREPROD/PROD décrivent le cycle de vie.

| Cycle | LOCAL Front | LOCAL Back | CENTRAL Front | CENTRAL Back |
|---|---:|---:|---:|---:|
| DEV | 9010 | 8010 | 9020 | 8020 |
| TEST | 9110 | 8110 | 9120 | 8120 |
| PREPROD | 9210 | 8210 | 9220 | 8220 |
| PROD | 9310 | 8310 | 9320 | 8320 |

**Profil actif de cette RC : TEST.** Les ports 9110/8110 et 9120/8120 sont donc conservés volontairement pour l'application `2.3.0-dev.2`.

## Images officielles épinglées

LOCAL backend  
`ghcr.io/idwebconcept/crodip-local-backend@sha256:0452417452ce9b22ba85de3246ee77a499a84111d023b88a42dbe8795faafba7`

LOCAL frontend  
`ghcr.io/idwebconcept/crodip-local-frontend@sha256:d9b3109bcb733b375a1ef4d6b81e74e8e295e6c4076be86a6be928dc9c7156fd`

CENTRAL backend  
`ghcr.io/idwebconcept/crodip-central-backend@sha256:dbc40e88e5d1d96191004dc02e01862db68fdb3795297bb313c9a33f4787b07b`

CENTRAL frontend  
`ghcr.io/idwebconcept/crodip-central-frontend@sha256:80540eac9e989385c91754038e4d46aac67d5e93fef73f33df5731bea50e9c20`

La source de vérité est `config/runtime.json` (`docker.officialImages`). `docker.imageTag` est conservé seulement pour compatibilité/offline ; il n'est plus la référence officielle lorsque `imageReferenceMode=digest`.

## Runtime LOCAL

- projet Compose : `crodip-runtime-local`
- frontend TEST : `http://localhost:9110`
- backend TEST : `http://localhost:8110`
- base : SQLite persistée sous `C:\ProgramData\CRODIP`

## Runtime CENTRAL

- projet Compose : `crodip-runtime-central`
- frontend TEST : `http://localhost:9120`
- backend TEST : `http://localhost:8120`
- PostgreSQL 17
- simulation optionnelle

## Démarrage

```powershell
Get-ChildItem -Recurse | Unblock-File
.\bootstrap-runtime.ps1
```

## Qualification

Les contrôles techniques de référence comprennent Docker, état des conteneurs, image exacte par digest, ports et endpoints HTTP (`/`, `/health`, `/docs`).

`TEST TECHNICALLY QUALIFIED` ne signifie pas `TEST FUNCTIONALLY QUALIFIED`. Pour `2.3.0-dev.2`, AUTH, RBAC, fonctions métier, Offline First et synchronisation restent hors périmètre fonctionnel qualifié.

## Répertoires Windows

- `C:\Program Files\CRODIP` : application et configuration installée ;
- `C:\ProgramData\CRODIP` : données, SQLite, documents, logs et sauvegardes ;
- `%LOCALAPPDATA%\CRODIP` : préférences et cache utilisateur.


## Qualification technique automatisée — RC2

RC2 ajoute une qualification technique globale LOCAL + CENTRAL :

```powershell
.\commands\13-qualify-runtime.ps1
```

Elle contrôle automatiquement :

- conteneurs backend/frontend LOCAL et CENTRAL ;
- références exactes `repo@sha256:digest` ;
- PostgreSQL CENTRAL `healthy` ;
- HTTP 200 sur LOCAL `/`, `/health`, `/docs` ;
- HTTP 200 sur CENTRAL `/`, `/health`, `/docs` ;
- cohérence du Run CI et du commit portée dans l'artefact.

En cas de réussite :

```text
RUNTIME TEST TECHNICALLY QUALIFIED
```

L'artefact est enregistré dans :

```text
C:\ProgramData\CRODIP\qualification\runtime-qualification.json
```

Cette qualification reste technique. Pour `2.3.0-dev.2`, la qualification fonctionnelle demeure `NOT_APPLICABLE`.


## Correctif RC3 — contrôle des digests

RC2 comparait le champ `Image` de `docker ps` à la référence complète
`repository@sha256:digest`. Selon Docker Desktop/Compose, ce champ peut être
rendu sous forme d'identifiant d'image abrégé.

RC3 utilise désormais :

```powershell
docker inspect --format "{{.Config.Image}}" <container>
```

La valeur `.Config.Image` est comparée à la référence officielle complète
épinglée dans `config/runtime.json`.


## Ergonomie RC4

Le menu principal ajoute désormais :

```text
13. Qualification technique Runtime
14. Quitter
```

L'option 13 lance directement `commands\13-qualify-runtime.ps1`.

La page `Runtime CENTRAL → 4. État` n'affiche plus le JSON brut de
`docker compose ps`. Elle présente maintenant une synthèse lisible :

- version Runtime et application ;
- cycle TEST, Run CI et commit ;
- état PostgreSQL 17 ;
- état backend/frontend ;
- ports ;
- référence complète des images par digest ;
- conformité du digest ;
- HTTP `/`, `/health` et `/docs` ;
- conclusion `RUNTIME CENTRAL TECHNICALLY OPERATIONAL`.


## Mise à jour d'une release TEST — RC5

Le menu principal propose désormais :

```text
13. Qualification technique Runtime
14. Mettre à jour la release TEST
15. Quitter
```

L'option 14 utilise par défaut :

```text
C:\Dev\crodip-saas\config\official-release-pin.json
```

Workflow :

```text
Lire le pin officiel TEST
        ↓
Comparer version / Run / commit / 4 digests
        ↓
Pull préalable des 4 images exactes
        ↓
Sauvegarder runtime.json
        ↓
Mettre à jour config\runtime.json
        ↓
Synchroniser les .env LOCAL / CENTRAL
        ↓
Recréer LOCAL
        ↓
Recréer CENTRAL
        ↓
Conserver le volume PostgreSQL
        ↓
Qualification technique automatique
```

Les sauvegardes de pin sont conservées sous :

```text
C:\ProgramData\CRODIP\release-history
```


## RC6 — Runtime autonome : récupération du pin officiel

Le Runtime ne dépend plus du workspace DEV.

Le chemin suivant est supprimé du workflow Runtime :

```text
C:\Dev\crodip-saas\config\official-release-pin.json
```

L'option 14 fonctionne désormais en mode `remote-first`.

### Source distante par défaut

```text
https://raw.githubusercontent.com/IDWEBCONCEPT/crodip-saas/main/config/official-release-pin.json
```

### Répertoire Runtime pour import manuel

```text
C:\ProgramData\CRODIP\release\incoming\official-release-pin.json
```

### Pin actif en cache

```text
C:\ProgramData\CRODIP\release\current\official-release-pin.json
```

### Priorité automatique

```text
HTTPS GitHub
    ↓ si indisponible
incoming local
    ↓ si absent
cache Runtime
```

Si le dépôt GitHub est privé, le Runtime peut utiliser la variable :

```powershell
$env:GITHUB_TOKEN = "<token>"
```

Le token n'est jamais écrit dans `runtime.json`.


## RC7 — GitHub CLI intégré au Runtime

Menu principal :
```text
14. Mettre à jour la release TEST
15. GitHub CLI / Authentification
16. Quitter
```
Le Runtime installe `GitHub.cli` via Winget, authentifie l'utilisateur avec `gh auth login --web`, puis lit `config/official-release-pin.json` du dépôt privé `IDWEBCONCEPT/crodip-saas` via l'API GitHub. Aucun `C:\Dev` n'est requis.


## RC8 — Schéma officiel v1 et installation fraîche de GitHub CLI

RC8 utilise le schéma réel de `config/official-release-pin.json` :

```text
schemaVersion
applicationVersion
officialRunId
officialRunNumber
gitCommit
status
buildPolicy
repository
images[]
pinPolicy
```

`images[]` doit contenir exactement les quatre clés :

```text
central-backend
central-frontend
local-backend
local-frontend
```

La requête GitHub API utilise un GET explicite avec `?ref=main`.

Lors d'une installation fraîche du Runtime, `01-install.ps1` vérifie GitHub CLI et l'installe automatiquement via Winget s'il est absent. L'authentification GitHub n'est pas forcée pendant l'installation : elle est demandée à la première utilisation des menus 14 ou 15.


## RC9 — Correctif GitHub + cycle de vie des composants techniques

Correctif PowerShell :

```powershell
$endpoint = "repos/$Repository/contents/${Path}?ref=$Ref"
```

Le menu principal comporte désormais :

```text
16. Composants techniques
17. Quitter
```

Le menu 16 permet d'installer ou désinstaller explicitement GitHub CLI, Docker Desktop, Ubuntu/WSL et la pile Docker/WSL complète.

### Règle de sécurité

La désinstallation standard du Runtime **ne supprime jamais automatiquement** Docker, WSL2 ou GitHub CLI, car ces composants peuvent être partagés avec d'autres logiciels. Leur suppression nécessite une action explicite et une confirmation `OUI`.

La suppression complète Docker + Ubuntu + WSL2 est signalée comme destructive. Les données métier CRODIP situées hors WSL ne sont pas supprimées par ce menu.


## RC10 — Désinstallation des composants techniques

RC10 aligne le menu 16 sur les signatures réelles de `Crodip.Runtime.DockerProvider.psm1`.

Les fonctions de désinstallation Docker/WSL possèdent déjà leur propre confirmation destructive. Le menu ne leur transmet donc plus de paramètre `-Confirm` non supporté et ne duplique plus les confirmations.

Les confirmations natives restent obligatoires :

```text
DESINSTALLER DOCKER
SUPPRIMER <distribution>
DESACTIVER WSL2
DESINSTALLATION COMPLETE
```

RC10 améliore aussi la détection de GitHub CLI : `gh` est recherché dans le PATH puis dans le chemin standard `Program Files\GitHub CLI\gh.exe`. Cela évite d'afficher `ABSENT` lorsque GitHub CLI est installé mais que le processus PowerShell courant n'a pas encore rafraîchi son PATH.


## RC11 — GitHub CLI / StrictMode

La détection de `gh.exe` ne dépend plus d'une propriété `Count`. Elle recherche successivement le PATH, Program Files et Program Files (x86), puis retourne `ABSENT` sans erreur sous `Set-StrictMode -Version Latest`. Les correctifs GitHub API RC9 et désinstallation RC10 sont conservés.


## RC12 — Contrat d'export du module GitHub

`Get-CrodipGitHubCliExecutable` est désormais explicitement exportée par `Crodip.Runtime.GitHub.psm1`.

Le test RC12 ne se limite plus à rechercher du texte dans les scripts. Il importe réellement le module PowerShell puis vérifie avec `Get-Command -ErrorAction Stop` les six fonctions publiques utilisées par le Runtime :

```text
Get-CrodipGitHubCliExecutable
Test-CrodipGitHubCli
Install-CrodipGitHubCli
Test-CrodipGitHubAuthentication
Connect-CrodipGitHub
Get-CrodipGitHubFile
```

Le détecteur `gh.exe` est ensuite réellement invoqué sous StrictMode.


## RC13 — Fresh Install des composants techniques

L'installation complète du Runtime gère désormais automatiquement le socle nécessaire sur un poste neuf.

```text
Préflight matériel/Windows
→ WSL2 + Ubuntu si nécessaire
→ Docker Desktop si absent
→ démarrage Docker Desktop si installé mais moteur arrêté
→ attente Docker Engine (120 s)
→ docker --version
→ docker compose version
→ docker info
→ GitHub CLI si absent
→ installation/configuration CRODIP Runtime
```

L'installation est idempotente : Docker Desktop et GitHub CLI déjà installés sont conservés. Un moteur Docker arrêté entraîne un démarrage de Docker Desktop, jamais une réinstallation.

Si l'installation WSL2 impose un redémarrage Windows, le Runtime s'arrête proprement et demande de relancer `Installation` après redémarrage.


## RC14 — Supervision de l'installation Docker via Winget

L'installation Docker Desktop n'est plus une commande Winget silencieuse. Le Runtime lance Winget dans un processus supervisé et affiche un état toutes les 15 secondes.

```text
==> Installation Docker Desktop via Winget
    Package : Docker.DockerDesktop
    Timeout : 900 secondes
    Journal : C:\ProgramData\CRODIP\logs\winget-docker-....out.log

[EN COURS] Winget / Docker Desktop : 15s
[EN COURS] Winget / Docker Desktop : 30s
...
==> Winget terminé — code retour : 0
[OK] Docker Desktop installé.
```

Deux journaux (`stdout` et `stderr`) sont conservés. Un timeout de 900 secondes empêche un blocage indéfini. Un second Winget actif empêche le lancement concurrent d'une nouvelle installation.


## RC15 — Supervision d'inactivité Winget

Le timeout global de RC14 est remplacé par un timeout **d'inactivité observable**. Un téléchargement Docker Desktop lent peut dépasser 15 minutes sans être interrompu tant que Winget présente une activité (journaux ou CPU). La durée maximale absolue est désactivée par défaut.

Configuration :
- inactivité maximale : 900 s ;
- affichage : 15 s ;
- durée maximale absolue : 0 (désactivée) ;
- logs : `C:\ProgramData\CRODIP\logs`.

Limite connue : Winget ne publie pas nécessairement un compteur d'octets dans sa sortie redirigée. RC15 mesure donc l'activité observable de Winget, pas le débit réseau réel.


## RC16 — Détection Docker CLI

RC16 corrige le faux négatif `Docker CLI : ABSENT` observé après installation réussie de Docker Desktop.

La détection est centralisée dans `Get-CrodipDockerCliExecutable` :
1. recherche via le `PATH` de la session ;
2. recherche explicite dans `C:\Program Files\Docker\Docker\resources\bin\docker.exe` ;
3. ajout du répertoire Docker au `PATH` de la session si nécessaire.

Le menu Composants techniques et `Invoke-CrodipDockerCli` utilisent désormais le même résolveur.


## RC17 — Synchronisation des ports Runtime TEST

RC17 synchronise le fichier `.env` Runtime avec le profil `activeLifecycle` de `config/runtime.json`. Pour TEST/LOCAL, le contrat est `8110` pour le backend et `9110` pour le frontend. Cela corrige un Runtime installé historique pouvant encore publier le frontend sur `9010` (port DEV).


### Restauration RC39

Le menu 7 liste automatiquement les sauvegardes disponibles, permet une sélection numérotée ou un chemin manuel, puis affiche le manifeste avant confirmation. RC39 normalise aussi les ACL SQLite Windows afin de garantir les écritures depuis le bind mount Docker.


## RC40 — Safe Database Migration & Release Compatibility

RC40 sécurise les mises à jour applicatives qui impliquent une évolution Alembic.

Principes :

- sauvegarde **PRE-MIGRATION obligatoire** avant la mise à jour ;
- head attendu issu de la release Runtime qualifiée ;
- contrôle `release expected head == image embedded head` avant migration ;
- migration `upgrade-only` vers le head attendu ;
- contrôle post-migration `release == image == database` ;
- aucun downgrade automatique ;
- aucune restauration automatique après échec ;
- rapport JSON de migration dans `C:\ProgramData\CRODIP\migration-history`.

Baseline de qualification RC40 :

- application `2.3.0-dev.4` ;
- Official Build #15 / Run `36452467983` ;
- LOCAL SQLite : `d24d83ea9494` → `ecd67252fd57` ;
- CENTRAL PostgreSQL : `3452c4fc44ba` → `7544a84c3691`.
