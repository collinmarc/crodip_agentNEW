# Préflight matériel et Windows — Runtime 2.2.42

Le Runtime qualifie désormais les prérequis avant WSL2 et Docker Desktop.

## Bloquants

- Windows / OS 64 bits ;
- virtualisation matérielle BIOS/UEFI (Intel VT-x ou AMD SVM/AMD-V).

Si la virtualisation firmware est désactivée, le Runtime arrête l'installation
avant WSL2/Docker et demande son activation dans le BIOS/UEFI.

## Contrôles complémentaires

- Virtual Machine Platform ;
- fonctionnalité Windows WSL ;
- RAM ;
- espace libre système ;
- Secure Boot (informatif) ;
- capacités Hyper-V exposées par Windows.

## Chaîne

```text
Préflight matériel
  -> virtualisation BIOS/UEFI
  -> composants Windows
  -> WSL2
  -> Docker provider
  -> Docker Engine
  -> GHCR
  -> Compose
```
