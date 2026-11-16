Set-StrictMode -Version Latest
function Get-CrodipGitHubCliExecutable {
    $cmd = Get-Command gh -ErrorAction SilentlyContinue
    if ($null -ne $cmd) {
        if (($cmd.PSObject.Properties.Name -contains "Source") -and $cmd.Source) {
            return [string]$cmd.Source
        }
        if (($cmd.PSObject.Properties.Name -contains "Path") -and $cmd.Path) {
            return [string]$cmd.Path
        }
    }

    $candidates = [System.Collections.Generic.List[string]]::new()
    if ($env:ProgramFiles) {
        $candidates.Add((Join-Path $env:ProgramFiles "GitHub CLI\gh.exe"))
    }

    $programFilesX86 = [Environment]::GetEnvironmentVariable("ProgramFiles(x86)")
    if ($programFilesX86) {
        $candidates.Add((Join-Path $programFilesX86 "GitHub CLI\gh.exe"))
    }

    foreach ($candidate in $candidates) {
        if ($candidate -and (Test-Path -LiteralPath $candidate -PathType Leaf)) {
            return [string]$candidate
        }
    }
    return $null
}

function Test-CrodipGitHubCli {
    return $null -ne (Get-CrodipGitHubCliExecutable)
}

function Install-CrodipGitHubCli {
    if(Test-CrodipGitHubCli){ Write-Host "[OK] GitHub CLI déjà installé." -ForegroundColor Green; return $true }
    if($null -eq (Get-Command winget -ErrorAction SilentlyContinue)){
        Write-Host "[ERREUR] winget absent." -ForegroundColor Red; return $false
    }
    Write-Host "==> Installation GitHub CLI via winget" -ForegroundColor Cyan
    & winget install --id GitHub.cli --exact --source winget --accept-package-agreements --accept-source-agreements
    if($LASTEXITCODE -ne 0){ return $false }
    $env:Path="$([Environment]::GetEnvironmentVariable('Path','Machine'));$([Environment]::GetEnvironmentVariable('Path','User'))"
    $exe=Join-Path $env:ProgramFiles "GitHub CLI\gh.exe"
    if(-not(Test-CrodipGitHubCli) -and (Test-Path $exe)){ Set-Alias gh $exe -Scope Global }
    return (Test-CrodipGitHubCli)
}

function Test-CrodipGitHubAuthentication {
    if(-not(Test-CrodipGitHubCli)){ return $false }
    $gh = Get-CrodipGitHubCliExecutable
    & $gh auth status --hostname github.com *> $null
    return $LASTEXITCODE -eq 0
}

function Connect-CrodipGitHub {
    if(Test-CrodipGitHubAuthentication){ return $true }
    Write-Host "==> Authentification GitHub (navigateur)" -ForegroundColor Cyan
    $gh = Get-CrodipGitHubCliExecutable
    & $gh auth login --hostname github.com --git-protocol https --web
    if($LASTEXITCODE -ne 0){ return $false }
    return (Test-CrodipGitHubAuthentication)
}

function Get-CrodipGitHubFile {
    param([Parameter(Mandatory)][string]$Repository,[Parameter(Mandatory)][string]$Path,
          [string]$Ref="main",[Parameter(Mandatory)][string]$Destination)
    if(-not(Test-CrodipGitHubAuthentication)){ throw "GitHub CLI non authentifié." }
    New-Item -ItemType Directory -Force -Path (Split-Path -Parent $Destination)|Out-Null
    $endpoint="repos/$Repository/contents/${Path}?ref=$Ref"
    Write-Host "==> GitHub API : $Repository/$Path@$Ref" -ForegroundColor Cyan
    $gh = Get-CrodipGitHubCliExecutable
    $content=& $gh api $endpoint -H "Accept: application/vnd.github.raw+json"
    if($LASTEXITCODE -ne 0){ throw "GitHub API : récupération impossible." }
    ($content -join "`n")|Set-Content $Destination -Encoding utf8
    try { $null=Get-Content $Destination -Raw|ConvertFrom-Json }
    catch { Remove-Item $Destination -Force -ErrorAction SilentlyContinue; throw "Pin récupéré invalide." }
    Write-Host "[OK] Pin officiel récupéré." -ForegroundColor Green
    return $Destination
}
Export-ModuleMember -Function Get-CrodipGitHubCliExecutable,Test-CrodipGitHubCli,Install-CrodipGitHubCli,Test-CrodipGitHubAuthentication,Connect-CrodipGitHub,Get-CrodipGitHubFile
