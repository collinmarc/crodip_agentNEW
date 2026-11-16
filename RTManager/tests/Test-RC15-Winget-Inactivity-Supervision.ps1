#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"
$root=Split-Path -Parent $PSScriptRoot
$module=Join-Path $root "modules\Crodip.Runtime.DockerProvider.psm1"
$text=Get-Content $module -Raw
$required=@("InactivityTimeoutSeconds = 900","ProgressIntervalSeconds = 15",
"MaximumDurationSeconds = 0","inactivité observable","TotalProcessorTime.TotalSeconds",
"lastOutLength","lastErrLength","Timeout d'inactivité Winget",
"Un téléchargement lent n'est pas interrompu","--verbose-logs")
foreach($token in $required){
 if($text -notmatch [regex]::Escape($token)){throw "RC15 : contrat absent : $token"}
 Write-Host "[OK] $token"
}
Import-Module $module -Force -DisableNameChecking -ErrorAction Stop
$cmd=Get-Command Install-CrodipDockerDesktop -ErrorAction Stop
foreach($param in "InactivityTimeoutSeconds","ProgressIntervalSeconds","MaximumDurationSeconds","Confirm"){
 if(-not $cmd.Parameters.ContainsKey($param)){throw "RC15 : paramètre absent : $param"}
}
Write-Host "[OK] Contrat RC15."
