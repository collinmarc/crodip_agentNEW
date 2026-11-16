# Détection de la virtualisation — Runtime 2.2.42

La détection ne dépend plus uniquement de `VirtualizationFirmwareEnabled`.

## Priorité

```text
1. HyperVisorPresent = True
      -> ENABLED

2. Virtualization Based Security active
      -> ENABLED

3. VirtualizationFirmwareEnabled disponible
      -> True  = ENABLED
      -> False = DISABLED

4. aucune source concluante
      -> UNKNOWN / WARNING
```

Un hyperviseur actif prouve que la virtualisation matérielle est utilisable,
même si certaines propriétés CIM/Hyper-V sont vides ou retournent False.

Le statut `UNKNOWN` n'est pas bloquant pour le BIOS : le Runtime poursuit les
tests WSL2 et Docker.
