Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Convert-CrodipBytesToGB {
    [CmdletBinding()]
    param([AllowNull()][object]$Bytes)

    if ($null -eq $Bytes) { return $null }
    try { return [math]::Round(([double]$Bytes / 1GB), 2) }
    catch { return $null }
}

function Get-CrodipSystemInventory {
    [CmdletBinding()]
    param()

    $now = Get-Date
    $os = Get-CimInstance Win32_OperatingSystem -ErrorAction Stop
    $cs = Get-CimInstance Win32_ComputerSystem -ErrorAction Stop
    $cpu = @(Get-CimInstance Win32_Processor -ErrorAction Stop)
    $bios = Get-CimInstance Win32_BIOS -ErrorAction SilentlyContinue
    $baseBoard = Get-CimInstance Win32_BaseBoard -ErrorAction SilentlyContinue
	
	# Nom de l'utilisateur courant
	$username = [System.Security.Principal.WindowsIdentity]::GetCurrent().Name
	# Vérification des droits administrateur de la session actuelle
	$principal = New-Object Security.Principal.WindowsPrincipal(
		[System.Security.Principal.WindowsIdentity]::GetCurrent()
	)
	$isAdmin = $principal.IsInRole(
		[System.Security.Principal.WindowsBuiltInRole]::Administrator
	)
	if (-not $isAdmin) {
		$isAdmin = $principal.IsInRole(
			[System.Security.Principal.WindowsBuiltInRole]::Administrateurs
		)
	}
	#Lecture de la clé de registre pour avoir le Numero de PC
	$CRODIP_PC = "Unknown"
	if (Test-Path "HKCU:\CRODIP") {
		$regKey = Get-ItemProperty -Path "HKCU:\CRODIP"

		if ($null -ne $regKey.PSObject.Properties["PC"]) {
			$CRODIP_PC = $regKey.PC
		}
	}


    $firmwareType = "Unknown"
    try {
        $firmwareTypeValue = Get-ItemPropertyValue `
            -Path "HKLM:\SYSTEM\CurrentControlSet\Control" `
            -Name "PEFirmwareType" `
            -ErrorAction Stop

        $firmwareType = switch ([int]$firmwareTypeValue) {
            1 { "BIOS" }
            2 { "UEFI" }
            default { "Unknown" }
        }
    }
    catch {}

    $secureBoot = "Non vérifiable"
    try {
        $secureBoot = if (Confirm-SecureBootUEFI -ErrorAction Stop) {
            "Activé"
        }
        else {
            "Désactivé"
        }
    }
    catch {}

    $memoryModules = @()
    try {
        $memoryModules = @(
            Get-CimInstance Win32_PhysicalMemory -ErrorAction Stop |
            ForEach-Object {
                [pscustomobject]@{
                    BankLabel = [string]$_.BankLabel
                    Manufacturer = [string]$_.Manufacturer
                    PartNumber = ([string]$_.PartNumber).Trim()
                    CapacityGB = Convert-CrodipBytesToGB $_.Capacity
                    SpeedMHz = [int]$_.Speed
                }
            }
        )
    }
    catch {}

    $logicalDisks = @()
    try {
        $logicalDisks = @(
            Get-CimInstance Win32_LogicalDisk -Filter "DriveType=3" -ErrorAction Stop |
            ForEach-Object {
                $sizeGB = Convert-CrodipBytesToGB $_.Size
                $freeGB = Convert-CrodipBytesToGB $_.FreeSpace
                $usedGB = if ($null -ne $sizeGB -and $null -ne $freeGB) {
                    [math]::Round(($sizeGB - $freeGB),2)
                } else { $null }
                $freePct = if ([double]$_.Size -gt 0) {
                    [math]::Round(([double]$_.FreeSpace / [double]$_.Size * 100),1)
                } else { 0 }

                [pscustomobject]@{
                    DeviceID = [string]$_.DeviceID
                    VolumeName = [string]$_.VolumeName
                    FileSystem = [string]$_.FileSystem
                    SizeGB = $sizeGB
                    UsedGB = $usedGB
                    FreeGB = $freeGB
                    FreePercent = $freePct
                }
            }
        )
    }
    catch {}

    $physicalDisks = @()
    try {
        $physicalDisks = @(
            Get-CimInstance Win32_DiskDrive -ErrorAction Stop |
            ForEach-Object {
                [pscustomobject]@{
                    Model = [string]$_.Model
                    InterfaceType = [string]$_.InterfaceType
                    MediaType = [string]$_.MediaType
                    SizeGB = Convert-CrodipBytesToGB $_.Size
                    SerialNumber = ([string]$_.SerialNumber).Trim()
                }
            }
        )
    }
    catch {}

    $network = @()
    try {
        $network = @(
            Get-CimInstance Win32_NetworkAdapterConfiguration `
                -Filter "IPEnabled=True" `
                -ErrorAction Stop |
            ForEach-Object {
                [pscustomobject]@{
                    Description = [string]$_.Description
                    MACAddress = [string]$_.MACAddress
                    DHCPEnabled = [bool]$_.DHCPEnabled
                    IPAddress = @($_.IPAddress)
                    DefaultGateway = @($_.DefaultIPGateway)
                    DNSServers = @($_.DNSServerSearchOrder)
                }
            }
        )
    }
    catch {}

    $hypervisorPresent = $false
    try { $hypervisorPresent = [bool]$cs.HypervisorPresent } catch {}

    $wslVersion = ""
    try {
        $wslLines = @(& wsl.exe --version 2>&1)
        if ($LASTEXITCODE -eq 0) {
            $wslVersion = ($wslLines -join " ; ")
        }
    }
    catch {}

    $dockerClient = ""
    $dockerServer = ""
    $dockerCompose = ""
    try {
        $dockerClient = [string](& docker version --format "{{.Client.Version}}" 2>$null)
        $dockerServer = [string](& docker version --format "{{.Server.Version}}" 2>$null)
        $dockerCompose = [string]((& docker compose version 2>$null) -join " ")
    }
    catch {}

    $totalRamGB = Convert-CrodipBytesToGB $cs.TotalPhysicalMemory
    $freeRamGB = [math]::Round(([double]$os.FreePhysicalMemory / 1MB),2)
    $usedRamGB = if ($null -ne $totalRamGB) {
        [math]::Round(($totalRamGB - $freeRamGB),2)
    } else { $null }

    [pscustomobject]@{
        GeneratedAt = $now.ToString("yyyy-MM-dd HH:mm:ss")
        Computer = [pscustomobject]@{
            ComputerName = $env:COMPUTERNAME
            Manufacturer = [string]$cs.Manufacturer
            Model = [string]$cs.Model
            SystemType = [string]$cs.SystemType
            Domain = [string]$cs.Domain
			Utilisateur = $username
			Administrateur = $isAdmin
			CRODIP_PC = $CRODIP_PC
        }
        OperatingSystem = [pscustomobject]@{
            Caption = [string]$os.Caption
            Version = [string]$os.Version
            BuildNumber = [string]$os.BuildNumber
            Architecture = [string]$os.OSArchitecture
            InstallDate = $os.InstallDate
            LastBootUpTime = $os.LastBootUpTime
            WindowsDirectory = [string]$os.WindowsDirectory
            SystemDrive = [string]$os.SystemDrive
        }
        Firmware = [pscustomobject]@{
            Type = $firmwareType
            SecureBoot = $secureBoot
            BIOSManufacturer = [string]$bios.Manufacturer
            BIOSVersion = [string]$bios.SMBIOSBIOSVersion
            BIOSReleaseDate = $bios.ReleaseDate
            BaseBoardManufacturer = [string]$baseBoard.Manufacturer
            BaseBoardProduct = [string]$baseBoard.Product
        }
        Processor = @(
            $cpu | ForEach-Object {
                [pscustomobject]@{
                    Name = [string]$_.Name
                    Manufacturer = [string]$_.Manufacturer
                    Cores = [int]$_.NumberOfCores
                    LogicalProcessors = [int]$_.NumberOfLogicalProcessors
                    MaxClockMHz = [int]$_.MaxClockSpeed
                    VirtualizationFirmwareEnabled = $_.VirtualizationFirmwareEnabled
                    VMMonitorModeExtensions = $_.VMMonitorModeExtensions
                    SecondLevelAddressTranslationExtensions = $_.SecondLevelAddressTranslationExtensions
                }
            }
        )
        Memory = [pscustomobject]@{
            TotalGB = $totalRamGB
            UsedGB = $usedRamGB
            FreeGB = $freeRamGB
            Modules = $memoryModules
        }
        Disks = [pscustomobject]@{
            Physical = $physicalDisks
            Logical = $logicalDisks
        }
        Virtualization = [pscustomobject]@{
            HypervisorPresent = $hypervisorPresent
            WSLVersion = $wslVersion
            DockerClient = $dockerClient
            DockerServer = $dockerServer
            DockerCompose = $dockerCompose
        }
        Network = $network
        PowerShell = [pscustomobject]@{
            Version = $PSVersionTable.PSVersion.ToString()
            Edition = $PSVersionTable.PSEdition
        }
    }
}

function Export-CrodipSystemInventory {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        $Inventory
    )

    $dataRoot = if (-not [string]::IsNullOrWhiteSpace($env:CRODIP_DATA_ROOT)) {
        $env:CRODIP_DATA_ROOT
    }
    else {
        "C:\ProgramData\CRODIP"
    }

    $reportDir = Join-Path $dataRoot "logs\reports"
    New-Item -ItemType Directory -Path $reportDir -Force | Out-Null

    $txtPath = Join-Path $reportDir "system-info.txt"
    $mdPath = Join-Path $reportDir "system-info.md"
    $jsonPath = Join-Path $reportDir "system-info.json"

    $cpuText = ($Inventory.Processor | ForEach-Object {
        "$($_.Name) ; Coeurs=$($_.Cores) ; Logiques=$($_.LogicalProcessors)"
    }) -join "`r`n"

    $diskText = ($Inventory.Disks.Logical | ForEach-Object {
        "$($_.DeviceID) $($_.VolumeName) ; $($_.FileSystem) ; Taille=$($_.SizeGB) Go ; Libre=$($_.FreeGB) Go ($($_.FreePercent)%)"
    }) -join "`r`n"

    $txt = @"
CRODIP SaaS Runtime - Informations système
===========================================
Généré le : $($Inventory.GeneratedAt)

Ordinateur
----------
Nom          : $($Inventory.Computer.ComputerName)
Fabricant    : $($Inventory.Computer.Manufacturer)
Modèle       : $($Inventory.Computer.Model)
Type système : $($Inventory.Computer.SystemType)
Domaine      : $($Inventory.Computer.Domain)
Utilisateur  : $($Inventory.Computer.Utilisateur)
Admin        : $($Inventory.Computer.Administrateur)
CRODIP_PC    : $($Inventory.Computer.CRODIP_PC)

Système d'exploitation
----------------------
OS           : $($Inventory.OperatingSystem.Caption)
Version      : $($Inventory.OperatingSystem.Version)
Build        : $($Inventory.OperatingSystem.BuildNumber)
Architecture : $($Inventory.OperatingSystem.Architecture)
Installation : $($Inventory.OperatingSystem.InstallDate)
Démarrage    : $($Inventory.OperatingSystem.LastBootUpTime)

Firmware
--------
Type         : $($Inventory.Firmware.Type)
Secure Boot  : $($Inventory.Firmware.SecureBoot)
BIOS         : $($Inventory.Firmware.BIOSManufacturer) $($Inventory.Firmware.BIOSVersion)
Carte mère   : $($Inventory.Firmware.BaseBoardManufacturer) $($Inventory.Firmware.BaseBoardProduct)

Processeur
----------
$cpuText

Mémoire
-------
Total        : $($Inventory.Memory.TotalGB) Go
Utilisée     : $($Inventory.Memory.UsedGB) Go
Disponible   : $($Inventory.Memory.FreeGB) Go

Disques logiques
----------------
$diskText

Virtualisation / Docker
-----------------------
Hyperviseur  : $($Inventory.Virtualization.HypervisorPresent)
WSL          : $($Inventory.Virtualization.WSLVersion)
Docker CLI   : $($Inventory.Virtualization.DockerClient)
Docker Engine: $($Inventory.Virtualization.DockerServer)
Compose      : $($Inventory.Virtualization.DockerCompose)

PowerShell
----------
Version      : $($Inventory.PowerShell.Version)
Edition      : $($Inventory.PowerShell.Edition)
"@

    Set-Content -LiteralPath $txtPath -Value $txt -Encoding utf8

    $md = @()
    $md += "# CRODIP Runtime — Informations système"
    $md += ""
    $md += "**Généré le :** $($Inventory.GeneratedAt)"
    $md += ""
    $md += "## Ordinateur"
    $md += ""
    $md += "| Propriété | Valeur |"
    $md += "|---|---|"
    $md += "| Nom | $($Inventory.Computer.ComputerName) |"
    $md += "| Fabricant | $($Inventory.Computer.Manufacturer) |"
    $md += "| Modèle | $($Inventory.Computer.Model) |"
    $md += "| Type système | $($Inventory.Computer.SystemType) |"
    $md += "| Domaine | $($Inventory.Computer.Domain) |"
    $md += "| Utilisateur | $($Inventory.Computer.Utilisateur) |"
    $md += "| Administateur | $($Inventory.Computer.Administrateur) |"
    $md += "| CRODIP_PC | $($Inventory.Computer.CRODIP_PC) |"
    $md += ""
    $md += "## Système d'exploitation"
    $md += ""
    $md += "| Propriété | Valeur |"
    $md += "|---|---|"
    $md += "| OS | $($Inventory.OperatingSystem.Caption) |"
    $md += "| Version | $($Inventory.OperatingSystem.Version) |"
    $md += "| Build | $($Inventory.OperatingSystem.BuildNumber) |"
    $md += "| Architecture | $($Inventory.OperatingSystem.Architecture) |"
    $md += "| Installation | $($Inventory.OperatingSystem.InstallDate) |"
    $md += "| Dernier démarrage | $($Inventory.OperatingSystem.LastBootUpTime) |"
    $md += ""
    $md += "## Firmware"
    $md += ""
    $md += "| Propriété | Valeur |"
    $md += "|---|---|"
    $md += "| Type | $($Inventory.Firmware.Type) |"
    $md += "| Secure Boot | $($Inventory.Firmware.SecureBoot) |"
    $md += "| BIOS | $($Inventory.Firmware.BIOSManufacturer) $($Inventory.Firmware.BIOSVersion) |"
    $md += "| Carte mère | $($Inventory.Firmware.BaseBoardManufacturer) $($Inventory.Firmware.BaseBoardProduct) |"
    $md += ""
    $md += "## Processeur"
    $md += ""
    $md += "| Modèle | Cœurs | Logiques | Fréquence max MHz |"
    $md += "|---|---:|---:|---:|"
    foreach ($p in $Inventory.Processor) {
        $md += "| $($p.Name) | $($p.Cores) | $($p.LogicalProcessors) | $($p.MaxClockMHz) |"
    }
    $md += ""
    $md += "## Mémoire"
    $md += ""
    $md += "| Total Go | Utilisée Go | Disponible Go |"
    $md += "|---:|---:|---:|"
    $md += "| $($Inventory.Memory.TotalGB) | $($Inventory.Memory.UsedGB) | $($Inventory.Memory.FreeGB) |"
    $md += ""
    $md += "## Disques"
    $md += ""
    $md += "| Volume | Nom | FS | Taille Go | Libre Go | Libre % |"
    $md += "|---|---|---|---:|---:|---:|"
    foreach ($d in $Inventory.Disks.Logical) {
        $md += "| $($d.DeviceID) | $($d.VolumeName) | $($d.FileSystem) | $($d.SizeGB) | $($d.FreeGB) | $($d.FreePercent) |"
    }
    $md += ""
    $md += "## Virtualisation / Docker"
    $md += ""
    $md += "| Propriété | Valeur |"
    $md += "|---|---|"
    $md += "| Hyperviseur | $($Inventory.Virtualization.HypervisorPresent) |"
    $md += "| WSL | $($Inventory.Virtualization.WSLVersion) |"
    $md += "| Docker CLI | $($Inventory.Virtualization.DockerClient) |"
    $md += "| Docker Engine | $($Inventory.Virtualization.DockerServer) |"
    $md += "| Compose | $($Inventory.Virtualization.DockerCompose) |"

    Set-Content -LiteralPath $mdPath -Value ($md -join "`r`n") -Encoding utf8

    $Inventory |
        ConvertTo-Json -Depth 10 |
        Set-Content -LiteralPath $jsonPath -Encoding utf8

    [pscustomobject]@{
        Text = $txtPath
        Markdown = $mdPath
        Json = $jsonPath
    }
}

Export-ModuleMember -Function @(
    "Get-CrodipSystemInventory",
    "Export-CrodipSystemInventory"
)
