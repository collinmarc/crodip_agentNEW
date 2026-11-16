$ErrorActionPreference = "Stop"

$testRoot = Join-Path $env:TEMP "crodip-runtime-backup-test"
$testData = Join-Path $testRoot "data"
$testBackups = Join-Path $testRoot "backups"

if (Test-Path $testRoot) {
    Remove-Item $testRoot -Recurse -Force
}

foreach ($directory in @(
    "sqlite","documents","pdf","photos","signatures",
    "exports","imports","config"
)) {
    New-Item -ItemType Directory -Path (Join-Path $testData $directory) -Force | Out-Null
}

Set-Content -LiteralPath (Join-Path $testData "sqlite\test.db") -Value "test"

$oldDataRoot = $env:CRODIP_DATA_ROOT

try {
    $env:CRODIP_DATA_ROOT = $testData

    & (Join-Path $PSScriptRoot "..\commands\06-backup.ps1") `
        -Mode quick `
        -DestinationDirectory $testBackups

    $archive = Get-ChildItem $testBackups -Filter *.zip | Select-Object -First 1
    if (-not $archive) {
        throw "Archive absente."
    }

    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $zip = [System.IO.Compression.ZipFile]::OpenRead($archive.FullName)

    try {
        $names = @($zip.Entries | ForEach-Object FullName)

        foreach ($required in @(
            "sqlite/","documents/","pdf/","photos/",
            "signatures/","exports/","imports/","config/",
            "BACKUP-MANIFEST.json"
        )) {
            if ($required -notin $names) {
                throw "Entrée absente : $required"
            }
        }
    }
    finally {
        $zip.Dispose()
    }

    Write-Host "[OK] Sauvegarde et répertoires vides validés." -ForegroundColor Green
}
finally {
    $env:CRODIP_DATA_ROOT = $oldDataRoot
    if (Test-Path $testRoot) {
        Remove-Item $testRoot -Recurse -Force
    }
}
