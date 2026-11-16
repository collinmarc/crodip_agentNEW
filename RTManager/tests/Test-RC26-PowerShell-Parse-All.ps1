#Requires -Version 7.4
[CmdletBinding()]
param()
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$runtimeRoot = Split-Path -Parent $PSScriptRoot
$files = @(Get-ChildItem -LiteralPath $runtimeRoot -Recurse -File | Where-Object { $_.Extension -in @('.ps1', '.psm1') })
$allErrors = [System.Collections.Generic.List[string]]::new()

foreach ($file in $files) {
    $tokens = $null
    $parseErrors = $null
    [System.Management.Automation.Language.Parser]::ParseFile(
        $file.FullName,
        [ref]$tokens,
        [ref]$parseErrors
    ) | Out-Null

    foreach ($parseError in @($parseErrors)) {
        $allErrors.Add(('{0}:{1}:{2} - {3}' -f $file.FullName, $parseError.Extent.StartLineNumber, $parseError.Extent.StartColumnNumber, $parseError.Message))
    }
}

if ($allErrors.Count -gt 0) {
    $allErrors | ForEach-Object { Write-Error $_ }
    throw ("Qualification syntaxique PowerShell en échec : {0} erreur(s)." -f $allErrors.Count)
}

Write-Host ("[OK] Qualification syntaxique : {0} fichier(s) PowerShell analysé(s), aucune ParserError." -f $files.Count) -ForegroundColor Green
