#Requires -Version 7.4
$ErrorActionPreference = "Stop"

$Root = Split-Path -Parent $PSScriptRoot

$bad = @()

Get-ChildItem `
    -Path $Root `
    -Recurse `
    -File |
    Where-Object {
        $_.Extension -in @(".ps1", ".psm1")
    } |
    ForEach-Object {
        $content = Get-Content -LiteralPath $_.FullName -Raw

        if ($content.Contains('`n')) {
            # Literal backtick-n in source is suspicious here.
            # Restrict to the malformed module-array pattern.
            if (
                $content -match
                '"Crodip\.Runtime\.[^"]+",`n\s+"Crodip\.Runtime\.'
            ) {
                $bad += $_.FullName
            }
        }
    }

if ($bad.Count -gt 0) {
    throw "Séquences littérales `n invalides détectées : $($bad -join ', ')"
}

$startPath = Join-Path $Root "commands\03-start.ps1"
$tokens = $null
$errors = $null

[System.Management.Automation.Language.Parser]::ParseFile(
    $startPath,
    [ref]$tokens,
    [ref]$errors
) | Out-Null

if ($errors.Count -gt 0) {
    throw "03-start.ps1 contient encore des erreurs de parsing : $($errors.Message -join ' | ')"
}

Write-Host "[OK] Parsing PowerShell Lot 5 validé." -ForegroundColor Green
