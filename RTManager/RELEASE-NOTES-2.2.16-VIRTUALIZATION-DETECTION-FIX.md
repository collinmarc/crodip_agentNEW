# Release Notes — Runtime Manager 2.2.42 Stable

## Virtualization Detection Fix

Correction des faux négatifs observés lorsque Windows affiche :

```text
Un hyperviseur a été détecté.
```

ou lorsque la sécurité basée sur la virtualisation est en cours d'exécution.

La priorité est désormais donnée à `HyperVisorPresent` et à VBS avant les
propriétés CIM `VirtualizationFirmwareEnabled`.

Ainsi un poste avec hyperviseur actif est classé :

```text
[OK] Virtualisation BIOS/UEFI
     HyperVisorPresent=True
```

même si `Win32_Processor.VirtualizationFirmwareEnabled` retourne `False`.
