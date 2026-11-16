Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"

function New-CrodipPerformanceSession {
 [CmdletBinding()] param([Parameter(Mandatory)][string]$Name,[Parameter(Mandatory)][ValidateSet("check","startup")][string]$Type)
 [pscustomobject]@{Name=$Name;Type=$Type;StartedAt=Get-Date;Stopwatch=[Diagnostics.Stopwatch]::StartNew();Measurements=[Collections.Generic.List[object]]::new()}
}
function Add-CrodipPerformanceMeasurement {
 [CmdletBinding()] param(
  [Parameter(Mandatory)]$Session,
  [Parameter(Mandatory)][string]$Name,
  [Parameter(Mandatory)][double]$Seconds,
  [string]$Category="General",
  [string]$Details=""
 )
 $status=if($Seconds-ge 15){"VERY_SLOW"}elseif($Seconds-ge 5){"SLOW"}else{"OK"}
 $Session.Measurements.Add([pscustomobject]@{
  Name=$Name
  Category=$Category
  Seconds=[math]::Round($Seconds,3)
  Status=$status
  Details=$Details
 })
}
function Export-CrodipPerformanceReport {
 [CmdletBinding()] param([Parameter(Mandatory)]$Session)
 $Session.Stopwatch.Stop();$total=[math]::Round($Session.Stopwatch.Elapsed.TotalSeconds,3)
 $slowest=$Session.Measurements|Sort-Object Seconds -Descending|Select-Object -First 1
 $root=if($env:CRODIP_DATA_ROOT){$env:CRODIP_DATA_ROOT}else{"C:\ProgramData\CRODIP"}
 $dir=Join-Path $root "logs\reports";New-Item -ItemType Directory -Path $dir -Force|Out-Null
 $prefix=if($Session.Type-eq"check"){"check-performance"}else{"startup-performance"}
 $txt=Join-Path $dir "$prefix.txt";$json=Join-Path $dir "$prefix.json"
 $lines=@("CRODIP Runtime - Performance $($Session.Name)","==============================================","Généré : $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')","Durée totale : $total s","")
 foreach($m in $Session.Measurements){$lines+=("{0,-18} {1,-38} {2,9:N3} s  {3,-10} {4}"-f $m.Category,$m.Name,$m.Seconds,$m.Status,$m.Details)}
 $lines+="";if($slowest){$lines+="Étape la plus lente : $($slowest.Name) ($($slowest.Seconds) s)"}
 $lines+="Seuils : OK < 5 s ; SLOW >= 5 s ; VERY_SLOW >= 15 s"
 Set-Content $txt $lines -Encoding utf8
 [pscustomobject]@{generatedAt=(Get-Date).ToString("o");name=$Session.Name;type=$Session.Type;totalSeconds=$total;slowest=$slowest;measurements=@($Session.Measurements)}|ConvertTo-Json -Depth 8|Set-Content $json -Encoding utf8
 [pscustomobject]@{TotalSeconds=$total;Slowest=$slowest;Text=$txt;Json=$json}
}
function Show-CrodipPerformanceSummary {
 [CmdletBinding()] param([Parameter(Mandatory)]$Report,[Parameter(Mandatory)][string]$Label)
 Write-Host "";Write-Host "----------------------------------------------------------" -ForegroundColor Cyan
 Write-Host ("Temps {0,-38} {1,8:N2} s"-f $Label,$Report.TotalSeconds)
 if($Report.Slowest){Write-Host ("Étape la plus lente : {0} ({1:N2} s)"-f $Report.Slowest.Name,$Report.Slowest.Seconds)}
 Write-Host "----------------------------------------------------------" -ForegroundColor Cyan
 Write-Host "Rapport performance TXT  : $($Report.Text)"
 Write-Host "Rapport performance JSON : $($Report.Json)"
}
Export-ModuleMember -Function New-CrodipPerformanceSession,Add-CrodipPerformanceMeasurement,Export-CrodipPerformanceReport,Show-CrodipPerformanceSummary
