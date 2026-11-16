# Release Notes — Runtime Manager 2.2.42 Stable

## Lot 5 — Hardware / Windows Preflight

Ajout d'un préflight réutilisable avant WSL2 et Docker.

La virtualisation BIOS/UEFI est maintenant un contrôle bloquant. Le Runtime
n'essaie pas d'installer WSL2 ou de démarrer Docker Linux si VT-x / AMD-V
n'est pas activé.

Le dashboard expose également l'architecture, la virtualisation firmware et
Virtual Machine Platform.
