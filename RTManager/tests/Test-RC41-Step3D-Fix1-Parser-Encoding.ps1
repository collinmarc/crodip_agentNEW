$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$target = Join-Path $root 'commands\21-reconstruct-historical-release-snapshot.ps1'
if (-not (Test-Path $target)) { throw '[ECHEC] Script STEP3D introuvable.' }
$tokens = $null
$errors = $null
[void][System.Management.Automation.Language.Parser]::ParseFile($target, [ref]$tokens, [ref]$errors)
if ($errors.Count -gt 0) {
    $details = ($errors | ForEach-Object { "ligne $($_.Extent.StartLineNumber): $($_.Message)" }) -join '; '
    throw "[ECHEC] Parser STEP3D : $details"
}
$text = Get-Content -LiteralPath $target -Raw
if ($text -notmatch 'NON ELIGIBLE au DOWNGRADE automatique STEP3B') { throw '[ECHEC] Garde-fou FIX1 absent.' }
Write-Host '[OK] RC41 STEP3D FIX1 - parser PowerShell valide ; garde-fou ASCII robuste et non-éligibilité STEP3B conservée.' -ForegroundColor Green
