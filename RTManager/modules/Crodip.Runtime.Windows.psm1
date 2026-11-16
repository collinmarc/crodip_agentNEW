###############################################################
# CRODIP Runtime Manager
# Module   : Crodip.Runtime.Windows.psm1
# Version  : 2.2.1
# Statut   : Stable - Lot 2 Clean
###############################################################

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Get-CrodipHome {
    [CmdletBinding()]
    param()

    if (-not [string]::IsNullOrWhiteSpace($env:CRODIP_HOME)) {
        return $env:CRODIP_HOME
    }

    return (Join-Path $env:ProgramFiles "CRODIP")
}

function Get-CrodipDataRoot {
    [CmdletBinding()]
    param()

    if (-not [string]::IsNullOrWhiteSpace($env:CRODIP_DATA_ROOT)) {
        return $env:CRODIP_DATA_ROOT
    }

    return (Join-Path $env:ProgramData "CRODIP")
}

function Get-CrodipUserRoot {
    [CmdletBinding()]
    param()

    if (-not [string]::IsNullOrWhiteSpace($env:CRODIP_USER_ROOT)) {
        return $env:CRODIP_USER_ROOT
    }

    return (Join-Path $env:LOCALAPPDATA "CRODIP")
}

function Test-CrodipAdministrator {
    [CmdletBinding()]
    param()

    $identity = [Security.Principal.WindowsIdentity]::GetCurrent()
    $principal = [Security.Principal.WindowsPrincipal]::new($identity)

    return $principal.IsInRole(
        [Security.Principal.WindowsBuiltInRole]::Administrator
    )
}

function Initialize-CrodipDirectories {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param()

    $runtimeHome = Get-CrodipHome
    $dataRoot = Get-CrodipDataRoot
    $userRoot = Get-CrodipUserRoot

    $directories = @(
        $runtimeHome,
        $dataRoot,
        $userRoot
    )

    $directories += @(
        "scripts",
        "modules",
        "config",
        "runtime",
        "templates"
    ) | ForEach-Object {
        Join-Path $runtimeHome $_
    }

    $directories += @(
        "sqlite",
        "documents",
        "pdf",
        "photos",
        "signatures",
        "exports",
        "imports",
        "logs",
        "backups",
        "cache",
        "config"
    ) | ForEach-Object {
        Join-Path $dataRoot $_
    }

    $directories += @(
        "cache",
        "ui",
        "temporary"
    ) | ForEach-Object {
        Join-Path $userRoot $_
    }

    foreach ($directoryPath in $directories) {
        if (
            -not (Test-Path -LiteralPath $directoryPath) -and
            $PSCmdlet.ShouldProcess(
                $directoryPath,
                "Créer le répertoire"
            )
        ) {
            New-Item `
                -ItemType Directory `
                -Path $directoryPath `
                -Force |
                Out-Null
        }
    }

    return [pscustomobject]@{
        Home = $runtimeHome
        Data = $dataRoot
        User = $userRoot
    }
}

function Set-CrodipEnvironmentVariables {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory)]
        [string]$RuntimeHome,

        [Parameter(Mandatory)]
        [string]$DataRoot,

        [Parameter(Mandatory)]
        [string]$UserRoot
    )

    $variables = @(
        @{
            Name = "CRODIP_HOME"
            Value = $RuntimeHome
            Target = "Machine"
        },
        @{
            Name = "CRODIP_DATA_ROOT"
            Value = $DataRoot
            Target = "Machine"
        },
        @{
            Name = "CRODIP_USER_ROOT"
            Value = $UserRoot
            Target = "User"
        }
    )

    foreach ($variable in $variables) {
        $label = "{0}:{1}" -f $variable.Target, $variable.Name

        if (
            $PSCmdlet.ShouldProcess(
                $label,
                "Définir la variable d'environnement"
            )
        ) {
            [Environment]::SetEnvironmentVariable(
                $variable.Name,
                $variable.Value,
                $variable.Target
            )
        }
    }

    $env:CRODIP_HOME = $RuntimeHome
    $env:CRODIP_DATA_ROOT = $DataRoot
    $env:CRODIP_USER_ROOT = $UserRoot
}

function Remove-CrodipEnvironmentVariables {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param()

    foreach ($variable in @(
        @{ Name = "CRODIP_HOME"; Target = "Machine" },
        @{ Name = "CRODIP_DATA_ROOT"; Target = "Machine" },
        @{ Name = "CRODIP_USER_ROOT"; Target = "User" }
    )) {
        $label = "{0}:{1}" -f $variable.Target, $variable.Name

        if (
            $PSCmdlet.ShouldProcess(
                $label,
                "Supprimer la variable d'environnement"
            )
        ) {
            [Environment]::SetEnvironmentVariable(
                $variable.Name,
                $null,
                $variable.Target
            )
        }
    }
}

function New-CrodipShortcut {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory)]
        [string]$ShortcutPath,

        [Parameter(Mandatory)]
        [string]$RuntimeHome
    )

    $targetPath = Join-Path $PSHOME "pwsh.exe"
    $bootstrapPath = Join-Path $RuntimeHome "bootstrap-runtime.ps1"

    if (
        $PSCmdlet.ShouldProcess(
            $ShortcutPath,
            "Créer le raccourci CRODIP"
        )
    ) {
        $shortcutDirectory = Split-Path -Parent $ShortcutPath

        if (-not (Test-Path -LiteralPath $shortcutDirectory)) {
            New-Item `
                -ItemType Directory `
                -Path $shortcutDirectory `
                -Force |
                Out-Null
        }

        $shell = New-Object -ComObject WScript.Shell
        $shortcut = $shell.CreateShortcut($ShortcutPath)
        $shortcut.TargetPath = $targetPath
        $shortcut.Arguments = (
            '-NoProfile -ExecutionPolicy Bypass -File "{0}"' -f
            $bootstrapPath
        )
        $shortcut.WorkingDirectory = $RuntimeHome
        $shortcut.Description = "CRODIP SaaS Runtime Manager"
        $shortcut.Save()
    }
}


function Set-CrodipSqliteWriteAcl {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param([string]$SqlitePath = (Join-Path (Get-CrodipDataRoot) "sqlite"))

    if (-not (Test-Path -LiteralPath $SqlitePath)) {
        New-Item -ItemType Directory -Path $SqlitePath -Force | Out-Null
    }

    if (-not $IsWindows) {
        return
    }

    if ($PSCmdlet.ShouldProcess($SqlitePath, "Accorder Modify à BUILTIN\\Utilisateurs pour SQLite")) {
        # SID S-1-5-32-545 = groupe BUILTIN\\Users, indépendant de la langue Windows.
        & icacls.exe $SqlitePath /grant '*S-1-5-32-545:(OI)(CI)(M)' /T /C | Out-Null
        if ($LASTEXITCODE -ne 0) {
            throw "Impossible de normaliser les ACL SQLite : $SqlitePath"
        }
    }
}

Export-ModuleMember -Function @(
    "Get-CrodipHome",
    "Get-CrodipDataRoot",
    "Get-CrodipUserRoot",
    "Test-CrodipAdministrator",
    "Initialize-CrodipDirectories",
    "Set-CrodipSqliteWriteAcl",
    "Set-CrodipEnvironmentVariables",
    "Remove-CrodipEnvironmentVariables",
    "New-CrodipShortcut"
)
