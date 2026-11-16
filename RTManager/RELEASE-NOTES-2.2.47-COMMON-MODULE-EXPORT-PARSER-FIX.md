# CRODIP Runtime Manager v2.2.47 Stable

## Common Module Export Parser Fix

Correction d'une erreur de syntaxe introduite en v2.2.46 dans :

`modules/Crodip.Runtime.Common.psm1`

La liste `Export-ModuleMember` contenait un littéral PowerShell `` `n `` après
`Get-CrodipRuntimeImage`, provoquant :

- `Missing expression after ','`
- `Unexpected token '`n' in expression or statement`

La liste des exports est désormais syntaxiquement valide.

La centralisation du tag Docker introduite en v2.2.46 est conservée :
`config/runtime.json -> docker.imageTag`.

Test ajouté :
`tests/Test-CommonModuleExportParser-2247.ps1`.
