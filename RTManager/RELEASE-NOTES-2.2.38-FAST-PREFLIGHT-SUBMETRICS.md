# Release Notes — Runtime Manager 2.2.42 Stable

## Fast Preflight + Submetrics

Le préflight de démarrage n'utilise plus les appels coûteux de qualification
générale qui peuvent prendre plusieurs minutes sur certains postes.

La détection s'appuie sur CIM :
- Win32_OperatingSystem
- Win32_ComputerSystem
- Win32_Processor
- Win32_DeviceGuard
- Win32_LogicalDisk

Les états détaillés VMP / WSL sont différés au Health Check complet.

Chaque sous-étape est chronométrée et ajoutée au rapport
`startup-performance.txt/json`.
