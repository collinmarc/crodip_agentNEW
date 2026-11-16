Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Add-CrodipPreflightMetric {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]$Metrics,
        [Parameter(Mandatory)][string]$Name,
        [Parameter(Mandatory)][double]$Seconds,
        [string]$Details=""
    )

    $status = if ($Seconds -ge 15) { "VERY_SLOW" }
              elseif ($Seconds -ge 5) { "SLOW" }
              else { "OK" }

    $Metrics.Add([pscustomobject]@{
        Name = $Name
        Seconds = [math]::Round($Seconds,3)
        Status = $status
        Details = $Details
    })
}

function Invoke-CrodipTimedPreflightStep {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]$Metrics,
        [Parameter(Mandatory)][string]$Name,
        [Parameter(Mandatory)][scriptblock]$ScriptBlock
    )

    $sw=[Diagnostics.Stopwatch]::StartNew()
    try {
        return (& $ScriptBlock)
    }
    finally {
        $sw.Stop()
        Add-CrodipPreflightMetric -Metrics $Metrics -Name $Name -Seconds $sw.Elapsed.TotalSeconds
    }
}

function Get-CrodipHardwareWindowsPreflight {
    [CmdletBinding()]
    param()

    $metrics=[Collections.Generic.List[object]]::new()
    $total=[Diagnostics.Stopwatch]::StartNew()

    $os=Invoke-CrodipTimedPreflightStep -Metrics $metrics -Name "CIM Win32_OperatingSystem" -ScriptBlock {
        Get-CimInstance Win32_OperatingSystem -ErrorAction Stop
    }

    $cs=Invoke-CrodipTimedPreflightStep -Metrics $metrics -Name "CIM Win32_ComputerSystem" -ScriptBlock {
        Get-CimInstance Win32_ComputerSystem -ErrorAction Stop
    }

    $cpu=Invoke-CrodipTimedPreflightStep -Metrics $metrics -Name "CIM Win32_Processor" -ScriptBlock {
        Get-CimInstance Win32_Processor -ErrorAction Stop | Select-Object -First 1
    }

    $archOk=[Environment]::Is64BitOperatingSystem

    $hypervisorPresent=$false
    if($cs.PSObject.Properties.Name -contains "HypervisorPresent"){
        $hypervisorPresent=[bool]$cs.HypervisorPresent
    }

    $vbsRunning=$false
    $vbsState="Indéterminé"
    try {
        $vbs=Invoke-CrodipTimedPreflightStep -Metrics $metrics -Name "CIM DeviceGuard / VBS" -ScriptBlock {
            Get-CimInstance -Namespace "root\Microsoft\Windows\DeviceGuard" -ClassName Win32_DeviceGuard -ErrorAction Stop
        }

        if($vbs){
            $vbsRunning=([int]$vbs.VirtualizationBasedSecurityStatus -eq 2)
            $vbsState=[string]$vbs.VirtualizationBasedSecurityStatus
        }
    }
    catch {}

    $firmwareVirtualizationRaw=$null
    $vmMonitorRaw=$null
    $secondLevelRaw=$null

    if($cpu.PSObject.Properties.Name -contains "VirtualizationFirmwareEnabled"){
        $firmwareVirtualizationRaw=$cpu.VirtualizationFirmwareEnabled
    }
    if($cpu.PSObject.Properties.Name -contains "VMMonitorModeExtensions"){
        $vmMonitorRaw=$cpu.VMMonitorModeExtensions
    }
    if($cpu.PSObject.Properties.Name -contains "SecondLevelAddressTranslationExtensions"){
        $secondLevelRaw=$cpu.SecondLevelAddressTranslationExtensions
    }

    $virtualizationState="UNKNOWN"
    $virtualizationSource="Aucune source concluante"
    $virtualizationEnabled=$false

    if($hypervisorPresent){
        $virtualizationState="ENABLED"
        $virtualizationSource="Win32_ComputerSystem.HypervisorPresent=True"
        $virtualizationEnabled=$true
    }
    elseif($vbsRunning){
        $virtualizationState="ENABLED"
        $virtualizationSource="Virtualization Based Security active"
        $virtualizationEnabled=$true
    }
    elseif($null -ne $firmwareVirtualizationRaw){
        if([bool]$firmwareVirtualizationRaw){
            $virtualizationState="ENABLED"
            $virtualizationSource="Win32_Processor.VirtualizationFirmwareEnabled=True"
            $virtualizationEnabled=$true
        }
        else{
            $virtualizationState="DISABLED"
            $virtualizationSource="Win32_Processor.VirtualizationFirmwareEnabled=False"
        }
    }

    # Les fonctionnalités Windows détaillées sont différées au Health Check.
    $vmpState=if($hypervisorPresent){"Deferred / Operational evidence available"}else{"Deferred"}
    $wslState="Deferred to Runtime Health"

    $secureBoot="Non vérifiable"
    try {
        $secureBoot=Invoke-CrodipTimedPreflightStep -Metrics $metrics -Name "Secure Boot UEFI" -ScriptBlock {
            [string](Confirm-SecureBootUEFI -ErrorAction Stop)
        }
    }
    catch {}

    $systemDrive=$null
    try {
        $systemDrive=Invoke-CrodipTimedPreflightStep -Metrics $metrics -Name "CIM Disque système" -ScriptBlock {
            Get-CimInstance Win32_LogicalDisk -Filter "DeviceID='$($env:SystemDrive)'" -ErrorAction Stop
        }
    }
    catch {}

    $freeGb=if($systemDrive){[math]::Round($systemDrive.FreeSpace/1GB,1)}else{0}
    $ramGb=[math]::Round($cs.TotalPhysicalMemory/1GB,1)

    $total.Stop()

    [pscustomobject]@{
        Architecture64Bit=$archOk
        Architecture=$os.OSArchitecture
        HypervisorPresent=$hypervisorPresent
        VirtualizationBasedSecurityRunning=$vbsRunning
        VirtualizationBasedSecurityStatus=$vbsState
        FirmwareVirtualizationEnabled=$virtualizationEnabled
        FirmwareVirtualizationRaw=$firmwareVirtualizationRaw
        VirtualizationState=$virtualizationState
        VirtualizationSource=$virtualizationSource
        VMMonitorModeExtensions=$vmMonitorRaw
        SecondLevelAddressTranslation=$secondLevelRaw
        DataExecutionPrevention=$null
        VirtualMachinePlatformState=$vmpState
        WslWindowsFeatureState=$wslState
        SecureBoot=$secureBoot
        RamGB=$ramGb
        FreeSystemDriveGB=$freeGb
        Cpu=$cpu.Name
        Manufacturer=$cs.Manufacturer
        Model=$cs.Model
        PreflightDurationSeconds=[math]::Round($total.Elapsed.TotalSeconds,3)
        PreflightMetrics=@($metrics)
        Blocking=((-not $archOk) -or ($virtualizationState -eq "DISABLED"))
    }
}

function Show-CrodipHardwareWindowsPreflight {
    [CmdletBinding()]
    param([Parameter(Mandatory)]$Result)

    Write-Host ""
    Write-Host "==> Qualification matérielle / Windows" -ForegroundColor Cyan
    Write-Host "    Architecture       : $($Result.Architecture)"
    Write-Host "    CPU                : $($Result.Cpu)"
    Write-Host "    Virtualisation      : $($Result.VirtualizationState)"
    Write-Host "    Source détection    : $($Result.VirtualizationSource)"
    Write-Host "    Hyperviseur actif   : $($Result.HypervisorPresent)"
    Write-Host "    VBS active          : $($Result.VirtualizationBasedSecurityRunning)"
    Write-Host "    RAM                : $($Result.RamGB) Go"
    Write-Host "    Disque libre       : $($Result.FreeSystemDriveGB) Go"
    Write-Host "    VirtualMachinePlatform : $($Result.VirtualMachinePlatformState)"
    Write-Host "    Fonction WSL Windows   : $($Result.WslWindowsFeatureState)"
    Write-Host "    Secure Boot            : $($Result.SecureBoot)"
    Write-Host "    Durée préflight        : $($Result.PreflightDurationSeconds) s"
    Write-Host ""
    Write-Host "    Métriques préflight :" -ForegroundColor Cyan

    foreach($metric in $Result.PreflightMetrics){
        $color=switch($metric.Status){
            "VERY_SLOW"{"Red"}
            "SLOW"{"Yellow"}
            default{"Green"}
        }
        Write-Host ("      {0,-32} {1,8:N3} s  {2}" -f $metric.Name,$metric.Seconds,$metric.Status) -ForegroundColor $color
    }
}

function Assert-CrodipHardwareWindowsPreflight {
    [CmdletBinding()]
    param()

    $result=Get-CrodipHardwareWindowsPreflight
    Show-CrodipHardwareWindowsPreflight -Result $result

    if(-not $result.Architecture64Bit){
        throw "Architecture Windows 64 bits requise pour le Runtime CRODIP."
    }

    if($result.VirtualizationState -eq "DISABLED"){
        throw "Virtualisation matérielle désactivée dans le BIOS/UEFI."
    }

    if($result.VirtualizationState -eq "UNKNOWN"){
        Write-Warning "État de la virtualisation indéterminé. Le Runtime poursuit la qualification WSL2/Docker."
    }

    return $result
}

Export-ModuleMember -Function @(
    "Get-CrodipHardwareWindowsPreflight",
    "Show-CrodipHardwareWindowsPreflight",
    "Assert-CrodipHardwareWindowsPreflight"
)
