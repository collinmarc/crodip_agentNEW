###############################################################
# CRODIP Runtime Manager
# Module   : Crodip.Runtime.DockerProvider.Loader.psm1
# Version  : 2.3.0-RC17
###############################################################

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Import-CrodipDockerProvider {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$ModuleRoot
    )

    $providerPath = Join-Path $ModuleRoot "Crodip.Runtime.DockerProvider.psm1"

    if (-not (Test-Path -LiteralPath $providerPath -PathType Leaf)) {
        throw "Module Docker Provider absent : $providerPath"
    }

    Get-Module Crodip.Runtime.DockerProvider -All |
        Remove-Module -Force -ErrorAction SilentlyContinue

    # IMPORTANT:
    # Ce loader s'exécute lui-même dans un scope de module.
    # Sans -Global, les commandes du provider restent visibles uniquement
    # dans le scope du Loader et sont invisibles pour 11-docker-admin.ps1.
    $module = Import-Module `
        -Name $providerPath `
        -Force `
        -PassThru `
        -Global `
        -DisableNameChecking `
        -ErrorAction Stop

    $required = @(
        "Get-CrodipDockerProviderInfo",
        "Get-CrodipDockerProvider",
        "Set-CrodipDockerProvider",
        "Install-CrodipDockerDesktop",
        "Install-CrodipWslUbuntu",
        "Install-CrodipUbuntuDockerEngine"
    )

    $exported = @($module.ExportedCommands.Keys)

    foreach ($name in $required) {
        if ($exported -notcontains $name) {
            throw "Fonction Docker Provider non exportée : $name"
        }
    }

    return $module
}

Export-ModuleMember -Function "Import-CrodipDockerProvider"
