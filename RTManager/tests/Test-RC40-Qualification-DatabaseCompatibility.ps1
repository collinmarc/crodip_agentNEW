#Requires -Version 7.4
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$root = Split-Path -Parent $PSScriptRoot
$file = Join-Path $root 'commands\13-qualify-runtime.ps1'
if (-not (Test-Path -LiteralPath $file)) { throw "Script qualification absent : $file" }
$text = Get-Content -LiteralPath $file -Raw -Encoding UTF8

$required = @(
    'Crodip.Runtime.DatabaseMigration.psm1',
    'Alembic database revision',
    'Alembic image head',
    'Alembic release expected',
    'Alembic compatibility',
    'databaseCompatibility',
    'releaseExpectedHead',
    'databaseCurrent',
    'compatible'
)
foreach ($token in $required) {
    if ($text -notmatch [regex]::Escape($token)) { throw "RC40 qualification DB compatibility : élément absent : $token" }
}
Write-Host '[OK] RC40 - qualification Runtime enrichie avec compatibilité DB/Alembic.' -ForegroundColor Green
