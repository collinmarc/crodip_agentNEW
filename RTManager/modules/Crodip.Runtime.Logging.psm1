Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Get-CrodipLogRoot {
    [CmdletBinding()] param()
    $data = if (-not [string]::IsNullOrWhiteSpace($env:CRODIP_DATA_ROOT)) { $env:CRODIP_DATA_ROOT } else { Join-Path $env:ProgramData "CRODIP" }
    return (Join-Path $data "logs")
}
function Write-CrodipRuntimeLog {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Message,
        [ValidateSet('DEBUG','INFO','WARN','ERROR')][string]$Level='INFO',
        [ValidatePattern('^[A-Za-z0-9._-]+$')][string]$LogName='runtime'
    )
    $root=Get-CrodipLogRoot
    if(-not(Test-Path -LiteralPath $root)){New-Item -ItemType Directory -Path $root -Force | Out-Null}
    $path=Join-Path $root "$LogName.log"
    if((Test-Path -LiteralPath $path) -and (Get-Item -LiteralPath $path).Length -gt 5MB){
        $archive=Join-Path $root ("{0}-{1}.log" -f $LogName,(Get-Date -Format 'yyyyMMdd-HHmmss'))
        Move-Item -LiteralPath $path -Destination $archive -Force
    }
    $line='{0:yyyy-MM-dd HH:mm:ss} [{1}] {2}' -f (Get-Date),$Level,$Message
    Add-Content -LiteralPath $path -Value $line -Encoding utf8
    return $path
}
Export-ModuleMember -Function @('Get-CrodipLogRoot','Write-CrodipRuntimeLog')
