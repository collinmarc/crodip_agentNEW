# Runtime Manager 2.3.0-RC41 — STEP3E FIX3

## Objet

Corrige l'échec d'intégration observé depuis le menu lors du précontrôle DOWNGRADE STEP3E :

`Get-CrodipRuntimeConfig n'est pas reconnu`

## Correction

`Crodip.Runtime.ReleaseRollback.psm1` déclare désormais explicitement sa dépendance vers
`Crodip.Runtime.Common.psm1`. Les commandes `Get-CrodipRuntimeConfig` et
`Get-CrodipPersistentTestOverride` sont ainsi résolues dans le scope du module ReleaseRollback,
y compris lorsque celui-ci est chargé depuis un contexte PowerShell propre.

Aucun assouplissement n'est apporté aux garde-fous :
- STEP3B reste limité aux snapshots authentiques ;
- STEP3E reste limité aux snapshots `RECONSTRUCTED / EMPTY` qualifiés ;
- l'activation EMPTY reste explicite et réservée au chemin TEST.

## Qualification

Nouveau test : `tests/Test-RC41-Step3E-Fix3-Module-Scope.ps1`.
Il charge `ReleaseRollback` seul dans un nouveau processus PowerShell et vérifie la résolution
effective de ses dépendances Common.
