# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — Health Preflight Fix

### Cause corrigée

Les versions 2.2.12 à 2.2.14 ajoutaient les contrôles WSL2 / matériel dans
`02-check.ps1` après la génération du rapport.

Ils utilisaient également une variable `$checks` qui n'appartient pas au
moteur Health du Runtime Manager, provoquant :

```text
Method invocation failed because [System.Management.Automation.PSObject]
does not contain a method named 'op_Addition'.
```

### Architecture corrigée

Tous les contrôles sont maintenant intégrés dans :

```text
Get-CrodipRuntimeHealth
```

via la collection native :

```powershell
$results = [System.Collections.Generic.List[object]]::new()
$results.Add((New-CrodipHealthResult ...))
```

Les contrôles suivants participent désormais réellement au dashboard :

- Architecture 64 bits ;
- Virtualisation BIOS/UEFI ;
- Virtual Machine Platform ;
- WSL2 ;
- contrôles Runtime/Docker existants.

Ils sont inclus dans :

- le score ;
- le statut READY / NOT READY ;
- le rapport TXT ;
- le rapport Markdown ;
- le rapport JSON.
