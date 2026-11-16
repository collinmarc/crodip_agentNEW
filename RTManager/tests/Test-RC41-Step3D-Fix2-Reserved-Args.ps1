$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$target = Join-Path $root 'commands\21-reconstruct-historical-release-snapshot.ps1'
if (-not (Test-Path $target)) { throw '[ECHEC] Script STEP3D introuvable.' }
$tokens = $null
$errors = $null
[void][System.Management.Automation.Language.Parser]::ParseFile($target, [ref]$tokens, [ref]$errors)
if ($errors.Count -gt 0) {
 $details = ($errors | ForEach-Object { "ligne $($_.Extent.StartLineNumber): $($_.Message)" }) -join '; '
 throw "[ECHEC] Parser STEP3D FIX2 : $details"
}
$text = Get-Content -LiteralPath $target -Raw
if ($text -match '(?i)\$args\b') { throw '[ECHEC] Variable automatique reservee $args encore presente dans STEP3D.' }
if ($text -notmatch '\bDockerArgs\b') { throw '[ECHEC] Parametre DockerArgs FIX2 absent.' }
if ($text -notmatch '&\s+docker\s+@DockerArgs') { throw '[ECHEC] Splatting DockerArgs FIX2 absent.' }
if ($text -notmatch 'NON ELIGIBLE au DOWNGRADE automatique STEP3B') { throw '[ECHEC] Garde-fou STEP3B absent.' }
Write-Host '[OK] RC41 STEP3D FIX2 - collision $args supprimee ; splatting DockerArgs valide ; garde-fou STEP3B conserve.' -ForegroundColor Green
