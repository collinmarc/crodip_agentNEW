###############################################################
# CRODIP Runtime Manager
# Module   : Crodip.Runtime.DockerProvider.psm1
# Version  : 2.3.0-RC17
# Statut   : Stable - Lot 5 Docker Provider
###############################################################

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"


function Get-CrodipProviderRuntimeHome {
    [CmdletBinding()]
    param()

    $value = [Environment]::GetEnvironmentVariable("CRODIP_HOME", "Process")
    if ([string]::IsNullOrWhiteSpace($value)) {
        $value = [Environment]::GetEnvironmentVariable("CRODIP_HOME", "User")
    }
    if ([string]::IsNullOrWhiteSpace($value)) {
        $value = [Environment]::GetEnvironmentVariable("CRODIP_HOME", "Machine")
    }
    if ([string]::IsNullOrWhiteSpace($value)) {
        $value = "C:\Program Files\CRODIP"
    }
    return $value
}

function Get-CrodipProviderEnvFile {
    [CmdletBinding()]
    param()
    return (Join-Path (Get-CrodipProviderRuntimeHome) ".env")
}


function Get-CrodipDockerProvider {
    [CmdletBinding()]
    param()

    $value = [Environment]::GetEnvironmentVariable("CRODIP_DOCKER_PROVIDER", "Process")
    if ([string]::IsNullOrWhiteSpace($value)) {
        $value = [Environment]::GetEnvironmentVariable("CRODIP_DOCKER_PROVIDER", "User")
    }
    if ([string]::IsNullOrWhiteSpace($value)) {
        $envFile = Get-CrodipProviderEnvFile
        if (Test-Path -LiteralPath $envFile) {
            $line = Get-Content -LiteralPath $envFile |
                Where-Object { $_ -match '^\s*CRODIP_DOCKER_PROVIDER\s*=' } |
                Select-Object -Last 1
            if ($line) { $value = (($line -split '=',2)[1]).Trim().Trim('"').Trim("'") }
        }
    }
    if ([string]::IsNullOrWhiteSpace($value)) { return "desktop" }

    $value = $value.ToLowerInvariant()
    if ($value -notin @("desktop","ubuntu")) {
        throw "Provider Docker invalide : $value. Valeurs : desktop, ubuntu."
    }
    return $value
}

function Get-CrodipWslDistribution {
    [CmdletBinding()]
    param()

    $value = [Environment]::GetEnvironmentVariable("CRODIP_WSL_DISTRO", "Process")
    if ([string]::IsNullOrWhiteSpace($value)) {
        $value = [Environment]::GetEnvironmentVariable("CRODIP_WSL_DISTRO", "User")
    }
    if ([string]::IsNullOrWhiteSpace($value)) {
        $envFile = Get-CrodipProviderEnvFile
        if (Test-Path -LiteralPath $envFile) {
            $line = Get-Content -LiteralPath $envFile |
                Where-Object { $_ -match '^\s*CRODIP_WSL_DISTRO\s*=' } |
                Select-Object -Last 1
            if ($line) { $value = (($line -split '=',2)[1]).Trim().Trim('"').Trim("'") }
        }
    }
    if ([string]::IsNullOrWhiteSpace($value)) { return "Ubuntu" }
    return $value
}

function Set-CrodipDockerProvider {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [ValidateSet("desktop","ubuntu")]
        [string]$Provider,

        [string]$WslDistribution = "Ubuntu"
    )

    $envFile = Get-CrodipProviderEnvFile
    $envDirectory = Split-Path -Parent $envFile

    if (-not (Test-Path -LiteralPath $envDirectory -PathType Container)) {
        New-Item `
            -ItemType Directory `
            -Path $envDirectory `
            -Force |
            Out-Null
    }

    $lines = if (Test-Path -LiteralPath $envFile -PathType Leaf) {
        @(Get-Content -LiteralPath $envFile)
    }
    else {
        @()
    }

    # Supprime les anciennes valeurs gérées par le Runtime Manager.
    $managedNames = @(
        "CRODIP_DOCKER_PROVIDER",
        "CRODIP_WSL_DISTRO"
    )

    $lines = @(
        $lines |
            Where-Object {
                $line = [string]$_

                -not (
                    $managedNames |
                        Where-Object {
                            $line -match "^\s*$([regex]::Escape($_))\s*="
                        }
                )
            }
    )

    # Réécrit une configuration canonique.
    $lines += "CRODIP_DOCKER_PROVIDER=$Provider"

    if ($Provider -eq "ubuntu") {
        if ([string]::IsNullOrWhiteSpace($WslDistribution)) {
            $WslDistribution = "Ubuntu"
        }

        $lines += "CRODIP_WSL_DISTRO=$WslDistribution"
    }

    Set-Content `
        -LiteralPath $envFile `
        -Value $lines `
        -Encoding utf8

    # Met à jour immédiatement la session courante.
    $env:CRODIP_DOCKER_PROVIDER = $Provider

    if ($Provider -eq "ubuntu") {
        $env:CRODIP_WSL_DISTRO = $WslDistribution
    }
    else {
        Remove-Item Env:CRODIP_WSL_DISTRO -ErrorAction SilentlyContinue
    }

    return Get-CrodipDockerProviderInfo
}

function Test-CrodipWslDistribution {
    [CmdletBinding()]
    param([string]$Distribution = (Get-CrodipWslDistribution))

    if (-not (Get-Command wsl.exe -ErrorAction SilentlyContinue)) { return $false }
    $names = @(& wsl.exe -l -q 2>$null) | ForEach-Object { ([string]$_).Trim("`0"," ") }
    return $names -contains $Distribution
}

function Convert-CrodipPathToWsl {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Path,
        [string]$Distribution = (Get-CrodipWslDistribution)
    )
    $converted = & wsl.exe -d $Distribution -- wslpath -a $Path 2>$null
    if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace([string]$converted)) {
        throw "Conversion WSL impossible : $Path"
    }
    return ([string]$converted).Trim()
}

function Invoke-CrodipDockerCli {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string[]]$Arguments,
        [string]$WorkingDirectory
    )

    $provider = Get-CrodipDockerProvider

    if ($provider -eq "desktop") {
        $dockerExe = Get-CrodipDockerCliExecutable
        if (-not $dockerExe) {
            return [pscustomobject]@{ ExitCode=127; Output=@("docker.exe introuvable."); Provider=$provider }
        }
        [void](Update-CrodipDockerCliPath)
        if ($WorkingDirectory) { Push-Location $WorkingDirectory }
        try {
            $output = & $dockerExe @Arguments 2>&1
            $code = $LASTEXITCODE
        }
        finally { if ($WorkingDirectory) { Pop-Location } }
        return [pscustomobject]@{ ExitCode=$code; Output=@($output); Provider=$provider }
    }

    $distro = Get-CrodipWslDistribution
    if (-not (Test-CrodipWslDistribution -Distribution $distro)) {
        return [pscustomobject]@{ ExitCode=127; Output=@("Distribution WSL absente : $distro"); Provider=$provider }
    }

    $wslArgs = @("-d",$distro)
    if ($WorkingDirectory) {
        $wslPath = Convert-CrodipPathToWsl -Path $WorkingDirectory -Distribution $distro
        $wslArgs += @("--cd",$wslPath)
    }
    $wslArgs += @("--","docker")
    $wslArgs += $Arguments

    $output = & wsl.exe @wslArgs 2>&1
    $code = $LASTEXITCODE
    return [pscustomobject]@{ ExitCode=$code; Output=@($output); Provider=$provider }
}

function Test-CrodipSelectedDockerEngine {
    [CmdletBinding()]
    param()
    $r = Invoke-CrodipDockerCli -Arguments @("info","--format","{{.ServerVersion}}")
    return ($r.ExitCode -eq 0)
}

function Start-CrodipUbuntuDockerEngine {
    [CmdletBinding()]
    param([ValidateRange(10,300)][int]$TimeoutSeconds=60)

    $distro = Get-CrodipWslDistribution
    if (-not (Test-CrodipWslDistribution -Distribution $distro)) { return $false }

    & wsl.exe -d $distro -- sh -lc "docker info >/dev/null 2>&1 || (sudo -n service docker start >/dev/null 2>&1 || sudo -n systemctl start docker >/dev/null 2>&1)" *> $null

    $deadline=(Get-Date).AddSeconds($TimeoutSeconds)
    do {
        if (Test-CrodipSelectedDockerEngine) { return $true }
        Start-Sleep -Seconds 2
    } while((Get-Date)-lt $deadline)

    return $false
}

function Get-CrodipDockerProviderInfo {
    [CmdletBinding()]
    param()

    $provider = Get-CrodipDockerProvider
    $distro = if ($provider -eq "ubuntu") { Get-CrodipWslDistribution } else { "" }
    $engine = Test-CrodipSelectedDockerEngine
    $version = ""
    if ($engine) {
        $r=Invoke-CrodipDockerCli -Arguments @("version","--format","{{.Server.Version}}")
        if($r.ExitCode -eq 0){$version=([string]($r.Output -join "")).Trim()}
    }

    [pscustomobject]@{
        Provider = $provider
        DisplayName = if($provider -eq "desktop"){"Docker Desktop"}else{"Docker Engine Ubuntu/WSL2"}
        WslDistribution = $distro
        EngineRunning = $engine
        ServerVersion = $version
    }
}


function Test-CrodipAdministrator {
    [CmdletBinding()]
    param()

    $identity = [Security.Principal.WindowsIdentity]::GetCurrent()
    $principal = [Security.Principal.WindowsPrincipal]::new($identity)

    return $principal.IsInRole(
        [Security.Principal.WindowsBuiltInRole]::Administrator
    )
}

function Install-CrodipDockerDesktop {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [ValidateRange(60,7200)][int]$InactivityTimeoutSeconds = 900,
        [ValidateRange(5,300)][int]$ProgressIntervalSeconds = 15,
        [ValidateRange(0,86400)][int]$MaximumDurationSeconds = 0
    )
    if (-not (Test-CrodipAdministrator)) { throw "L'installation de Docker Desktop doit être lancée en mode administrateur." }
    $winget = Get-Command winget.exe -ErrorAction SilentlyContinue
    if (-not $winget) { throw "Winget est requis pour installer Docker Desktop." }
    $desktopExe = Join-Path $env:ProgramFiles "Docker\Docker\Docker Desktop.exe"
    if (Test-Path -LiteralPath $desktopExe -PathType Leaf) {
        Write-Host "[OK] Docker Desktop est déjà installé." -ForegroundColor Green
        return $true
    }
    if (-not $PSCmdlet.ShouldProcess("Docker Desktop","Installer via Winget")) { return $false }
    if (Get-Process winget -ErrorAction SilentlyContinue) {
        throw "Un autre processus Winget est déjà actif. Attendre sa fin ou le terminer avant de relancer l'installation."
    }

    $logRoot=Join-Path $env:ProgramData "CRODIP\logs"
    New-Item -ItemType Directory -Force -Path $logRoot | Out-Null
    $stamp=Get-Date -Format "yyyyMMdd-HHmmss"
    $stdoutLog=Join-Path $logRoot "winget-docker-$stamp.out.log"
    $stderrLog=Join-Path $logRoot "winget-docker-$stamp.err.log"
    $arguments=@("install","--id","Docker.DockerDesktop","--exact","--source","winget",
        "--accept-package-agreements","--accept-source-agreements","--disable-interactivity","--verbose-logs")

    Write-Host ""
    Write-Host "==> Installation Docker Desktop via Winget" -ForegroundColor Cyan
    Write-Host "    Timeout d'inactivité  : $InactivityTimeoutSeconds secondes"
    Write-Host "    Progression affichée  : toutes les $ProgressIntervalSeconds secondes"
    Write-Host "    Durée maximale        : $(if($MaximumDurationSeconds -gt 0){$MaximumDurationSeconds}else{'désactivée'})"
    Write-Host "    Journal               : $stdoutLog"
    Write-Host "    Un téléchargement lent n'est pas interrompu tant qu'une activité est détectée."
    Write-Host ""

    $process=Start-Process -FilePath $winget.Source -ArgumentList $arguments -PassThru `
        -RedirectStandardOutput $stdoutLog -RedirectStandardError $stderrLog -WindowStyle Hidden
    $started=Get-Date
    $lastActivity=$started
    $lastCpu=-1.0
    $lastOutLength=-1L
    $lastErrLength=-1L
    $nextDisplay=0

    while (-not $process.HasExited) {
        $process.Refresh()
        $now=Get-Date
        $elapsed=[int]($now-$started).TotalSeconds
        $outLength=if(Test-Path $stdoutLog){(Get-Item $stdoutLog).Length}else{0L}
        $errLength=if(Test-Path $stderrLog){(Get-Item $stderrLog).Length}else{0L}
        $cpu=try{[double]$process.TotalProcessorTime.TotalSeconds}catch{$lastCpu}

        if(($outLength -ne $lastOutLength) -or ($errLength -ne $lastErrLength) -or ($cpu -gt ($lastCpu+0.01))){
            $lastActivity=$now
            $lastOutLength=$outLength
            $lastErrLength=$errLength
            $lastCpu=$cpu
        }
        $inactive=[int]($now-$lastActivity).TotalSeconds

        if($elapsed -ge $nextDisplay){
            Write-Host ("[EN COURS] Winget / Docker Desktop : {0}s — inactivité observable : {1}s" -f $elapsed,$inactive) -ForegroundColor Yellow
            if(Test-Path $stdoutLog){
                $lastLine=Get-Content $stdoutLog -Tail 1 -ErrorAction SilentlyContinue
                if($lastLine){Write-Host "           $lastLine" -ForegroundColor DarkGray}
            }
            $nextDisplay=$elapsed+$ProgressIntervalSeconds
        }

        if($inactive -ge $InactivityTimeoutSeconds){
            Stop-Process -Id $process.Id -Force -ErrorAction SilentlyContinue
            throw "Timeout d'inactivité Winget après $InactivityTimeoutSeconds secondes sans activité observable. Durée totale : $elapsed secondes. Journaux : $stdoutLog ; $stderrLog"
        }
        if(($MaximumDurationSeconds -gt 0) -and ($elapsed -ge $MaximumDurationSeconds)){
            Stop-Process -Id $process.Id -Force -ErrorAction SilentlyContinue
            throw "Durée maximale de sécurité Winget atteinte après $MaximumDurationSeconds secondes. Journaux : $stdoutLog ; $stderrLog"
        }
        Start-Sleep -Seconds 2
    }

    $exitCode=$process.ExitCode
    Write-Host "==> Winget terminé — code retour : $exitCode" -ForegroundColor Cyan
    if($exitCode -ne 0){
        $detail=""
        if(Test-Path $stderrLog){$detail=((Get-Content $stderrLog -Tail 10 -ErrorAction SilentlyContinue)-join " ")}
        if([string]::IsNullOrWhiteSpace($detail) -and (Test-Path $stdoutLog)){
            $detail=((Get-Content $stdoutLog -Tail 10 -ErrorAction SilentlyContinue)-join " ")
        }
        throw "Échec de l'installation Docker Desktop via Winget (code $exitCode). $detail Journaux : $stdoutLog ; $stderrLog"
    }

    $deadline=(Get-Date).AddSeconds(30)
    do{
        if(Test-Path -LiteralPath $desktopExe -PathType Leaf){
            Write-Host "[OK] Docker Desktop installé." -ForegroundColor Green
            return $true
        }
        Start-Sleep 2
    }while((Get-Date)-lt $deadline)
    Write-Warning "Winget a terminé avec succès mais Docker Desktop n'est pas encore visible. Une nouvelle session ou un redémarrage Windows peut être nécessaire."
    return $true
}

function Install-CrodipWslUbuntu {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [string]$Distribution = "Ubuntu"
    )

    if (-not (Test-CrodipAdministrator)) {
        throw "L'installation de WSL/Ubuntu doit être lancée en mode administrateur."
    }

    if (-not (Get-Command wsl.exe -ErrorAction SilentlyContinue)) {
        throw "wsl.exe est introuvable sur ce poste."
    }

    if (Test-CrodipWslDistribution -Distribution $Distribution) {
        Write-Host "[OK] Distribution WSL déjà installée : $Distribution" -ForegroundColor Green
        return $true
    }

    if (-not $PSCmdlet.ShouldProcess(
        $Distribution,
        "Installer la distribution WSL2"
    )) {
        return $false
    }

    & wsl.exe --install -d $Distribution

    if ($LASTEXITCODE -ne 0) {
        throw "Échec de l'installation WSL/Ubuntu (code $LASTEXITCODE)."
    }

    Write-Host "[OK] Installation WSL/Ubuntu demandée." -ForegroundColor Green
    Write-Warning "Un redémarrage Windows peut être nécessaire avant de poursuivre."
    return $true
}

function Install-CrodipUbuntuDockerEngine {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [string]$Distribution = (Get-CrodipWslDistribution)
    )

    if (-not (Get-Command wsl.exe -ErrorAction SilentlyContinue)) {
        throw "WSL est indisponible."
    }

    if (-not (Test-CrodipWslDistribution -Distribution $Distribution)) {
        throw "Distribution WSL absente : $Distribution. Installer d'abord WSL2 + Ubuntu."
    }

    if (-not $PSCmdlet.ShouldProcess(
        "Docker Engine dans $Distribution",
        "Installer avec le dépôt officiel Docker"
    )) {
        return $false
    }

    $script = @'
set -e

if command -v docker >/dev/null 2>&1; then
  echo "[OK] Docker CLI déjà présente."
fi

sudo apt-get update
sudo apt-get install -y ca-certificates curl gnupg

sudo install -m 0755 -d /etc/apt/keyrings

if [ ! -f /etc/apt/keyrings/docker.asc ]; then
  sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg \
    -o /etc/apt/keyrings/docker.asc
  sudo chmod a+r /etc/apt/keyrings/docker.asc
fi

. /etc/os-release

echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.asc] https://download.docker.com/linux/ubuntu ${UBUNTU_CODENAME:-$VERSION_CODENAME} stable" \
  | sudo tee /etc/apt/sources.list.d/docker.list >/dev/null

sudo apt-get update

sudo apt-get install -y \
  docker-ce \
  docker-ce-cli \
  containerd.io \
  docker-buildx-plugin \
  docker-compose-plugin

sudo usermod -aG docker "$USER"

if command -v systemctl >/dev/null 2>&1; then
  sudo systemctl enable docker >/dev/null 2>&1 || true
  sudo systemctl start docker >/dev/null 2>&1 || true
fi

sudo service docker start >/dev/null 2>&1 || true

docker --version || sudo docker --version
docker compose version || sudo docker compose version

echo
echo "[OK] Docker Engine installé."
echo "[ATTENTION] Le groupe docker a été ajouté à l'utilisateur."
echo "Fermer WSL avec 'wsl --shutdown' puis rouvrir Ubuntu avant le premier usage sans sudo."
'@

    & wsl.exe -d $Distribution -- bash -lc $script

    if ($LASTEXITCODE -ne 0) {
        throw "Échec de l'installation de Docker Engine dans $Distribution."
    }

    Write-Host "[OK] Docker Engine Ubuntu installé." -ForegroundColor Green
    Write-Warning "Exécuter 'wsl --shutdown' puis rouvrir Ubuntu pour appliquer le groupe docker."

    return $true
}

function Get-CrodipDockerCliExecutable {
    [CmdletBinding()]
    param()

    # 1. Session PATH
    $command = Get-Command docker.exe -ErrorAction SilentlyContinue
    if ($command -and $command.Source -and (Test-Path -LiteralPath $command.Source -PathType Leaf)) {
        return $command.Source
    }

    # 2. Standard Docker Desktop installation paths.
    $candidates = @(
        (Join-Path $env:ProgramFiles "Docker\Docker\resources\bin\docker.exe")
    )
    if (${env:ProgramFiles(x86)}) {
        $candidates += (Join-Path ${env:ProgramFiles(x86)} "Docker\Docker\resources\bin\docker.exe")
    }

    foreach ($candidate in $candidates) {
        if ($candidate -and (Test-Path -LiteralPath $candidate -PathType Leaf)) {
            return $candidate
        }
    }

    return $null
}

function Update-CrodipDockerCliPath {
    [CmdletBinding()]
    param()

    $dockerExe = Get-CrodipDockerCliExecutable
    if (-not $dockerExe) { return $false }

    $dockerBin = Split-Path -Parent $dockerExe
    $pathEntries = @($env:Path -split ';' | Where-Object { -not [string]::IsNullOrWhiteSpace($_) })
    $present = $false
    foreach ($entry in $pathEntries) {
        if ($entry.TrimEnd('\') -ieq $dockerBin.TrimEnd('\')) {
            $present = $true
            break
        }
    }
    if (-not $present) {
        $env:Path = "$dockerBin;$env:Path"
    }
    return $true
}

function Test-CrodipDockerCli {
    [CmdletBinding()]
    param()
    return [bool](Get-CrodipDockerCliExecutable)
}

function Test-CrodipDockerDesktopInstalled {
    [CmdletBinding()]
    param()

    return Test-Path `
        -LiteralPath (Join-Path $env:ProgramFiles "Docker\Docker\Docker Desktop.exe") `
        -PathType Leaf
}

function Test-CrodipUbuntuDockerInstalled {
    [CmdletBinding()]
    param(
        [string]$Distribution = (Get-CrodipWslDistribution)
    )

    if (-not (Test-CrodipWslDistribution -Distribution $Distribution)) {
        return $false
    }

    & wsl.exe -d $Distribution -- sh -lc "command -v docker >/dev/null 2>&1"
    return ($LASTEXITCODE -eq 0)
}


function Get-CrodipWslStatus {
    [CmdletBinding()]
    param()

    $wslCommand = Get-Command wsl.exe -ErrorAction SilentlyContinue

    if (-not $wslCommand) {
        return [pscustomobject]@{
            Installed = $false
            Version = ""
            DefaultVersion = ""
            DistributionPresent = $false
            Distribution = Get-CrodipWslDistribution
            RebootRecommended = $false
        }
    }

    $versionText = ""
    try {
        $versionText = (& wsl.exe --version 2>&1) -join "`n"
    }
    catch {
        $versionText = ""
    }

    $distribution = Get-CrodipWslDistribution
    $distributionPresent = Test-CrodipWslDistribution -Distribution $distribution

    [pscustomobject]@{
        Installed = $true
        Version = $versionText
        DefaultVersion = "2"
        DistributionPresent = $distributionPresent
        Distribution = $distribution
        RebootRecommended = $false
    }
}

function Install-CrodipWsl2Prerequisite {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [string]$Distribution = "Ubuntu"
    )

    if (-not (Test-CrodipAdministrator)) {
        throw "L'installation de WSL2 doit être lancée en mode administrateur."
    }

    if (-not $PSCmdlet.ShouldProcess(
        "WSL2 + $Distribution",
        "Installer le prérequis Docker Desktop"
    )) {
        return [pscustomobject]@{
            Success = $false
            RebootRequired = $false
            Distribution = $Distribution
        }
    }

    $wsl = Get-Command wsl.exe -ErrorAction SilentlyContinue

    if (-not $wsl) {
        throw "wsl.exe est introuvable. Windows doit être mis à jour avant l'installation WSL."
    }

    & wsl.exe --install -d $Distribution
    $code = $LASTEXITCODE

    if ($code -ne 0) {
        throw "Échec de l'installation WSL2 / $Distribution (code $code)."
    }

    try {
        & wsl.exe --set-default-version 2 *> $null
    }
    catch {
    }

    return [pscustomobject]@{
        Success = $true
        RebootRequired = $true
        Distribution = $Distribution
    }
}

function Test-CrodipDockerDesktopReadiness {
    [CmdletBinding()]
    param()

    $desktopInstalled = Test-CrodipDockerDesktopInstalled
    $wsl = Get-CrodipWslStatus

    $engine = $false
    $engineError = ""

    if ($desktopInstalled -and $wsl.Installed) {
        try {
            $r = Invoke-CrodipDockerCli -Arguments @("info","--format","{{.ServerVersion}}")
            $engine = ($r.ExitCode -eq 0)
            if (-not $engine) {
                $engineError = ($r.Output -join " ")
            }
        }
        catch {
            $engineError = $_.Exception.Message
        }
    }

    [pscustomobject]@{
        DockerDesktopInstalled = $desktopInstalled
        WslInstalled = $wsl.Installed
        WslDistributionPresent = $wsl.DistributionPresent
        WslDistribution = $wsl.Distribution
        EngineReady = $engine
        EngineError = $engineError
        Ready = ($desktopInstalled -and $wsl.Installed -and $engine)
    }
}

function Assert-CrodipDockerDesktopReady {
    [CmdletBinding()]
    param()

    $status = Test-CrodipDockerDesktopReadiness

    if (-not $status.DockerDesktopInstalled) {
        throw "Docker Desktop n'est pas installé."
    }

    if (-not $status.WslInstalled) {
        throw "WSL2 n'est pas installé. Utiliser Administration Docker > Installer / préparer WSL2 + Ubuntu."
    }

    if (-not $status.EngineReady) {
        $message = "Docker Desktop est installé mais le moteur Linux ne répond pas."
        if ($status.EngineError) {
            $message += " Détail : $($status.EngineError)"
        }
        throw $message
    }

    return $status
}


function Ensure-CrodipWsl2Prerequisite {
    [CmdletBinding()]
    param(
        [string]$Distribution = "Ubuntu",
        [switch]$InstallIfMissing
    )

    $status = Get-CrodipWslStatus

    if ($status.Installed) {
        return [pscustomobject]@{
            Ready = $true
            InstalledNow = $false
            RebootRequired = $false
            Distribution = $Distribution
            Message = "WSL2 déjà installé."
        }
    }

    if (-not $InstallIfMissing) {
        return [pscustomobject]@{
            Ready = $false
            InstalledNow = $false
            RebootRequired = $false
            Distribution = $Distribution
            Message = "WSL2 non installé."
        }
    }

    if (-not (Test-CrodipAdministrator)) {
        throw "WSL2 est absent. Relancer le Runtime Manager en mode administrateur pour lancer automatiquement l'installation."
    }

    Write-Host ""
    Write-Host "==> WSL2 absent - installation automatique" -ForegroundColor Cyan
    Write-Host "    Distribution : $Distribution"

    $result = Install-CrodipWsl2Prerequisite `
        -Distribution $Distribution `
        -Confirm:$false

    return [pscustomobject]@{
        Ready = $false
        InstalledNow = [bool]$result.Success
        RebootRequired = [bool]$result.RebootRequired
        Distribution = $Distribution
        Message = if ($result.Success) {
            "Installation WSL2 lancée. Redémarrage Windows requis avant de poursuivre."
        }
        else {
            "Installation WSL2 non terminée."
        }
    }
}


function Confirm-CrodipDestructiveAction {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Message,
        [Parameter(Mandatory)][string]$ExpectedText
    )

    Write-Host ""
    Write-Warning $Message
    Write-Host ""
    $answer = Read-Host "Pour confirmer, saisir exactement : $ExpectedText"
    return ($answer -ceq $ExpectedText)
}

function Stop-CrodipDockerDesktop {
    [CmdletBinding()]
    param()

    Get-Process `
        -Name "Docker Desktop","com.docker.backend","com.docker.build" `
        -ErrorAction SilentlyContinue |
        Stop-Process -Force -ErrorAction SilentlyContinue
}

function Uninstall-CrodipDockerDesktop {
    [CmdletBinding()]
    param()

    if (-not (Test-CrodipAdministrator)) {
        throw "La désinstallation de Docker Desktop doit être lancée en mode administrateur."
    }

    if (-not (Test-CrodipDockerDesktopInstalled)) {
        Write-Host "[OK] Docker Desktop n'est pas installé." -ForegroundColor Green
        return $true
    }

    Write-Warning "Docker Desktop peut contenir des images, conteneurs et volumes locaux."
    Write-Host "Les répertoires CRODIP Windows ne sont pas supprimés par cette action."

    if (-not (Confirm-CrodipDestructiveAction `
        -Message "Confirmer la désinstallation de Docker Desktop." `
        -ExpectedText "DESINSTALLER DOCKER")) {
        Write-Warning "Désinstallation annulée."
        return $false
    }

    Stop-CrodipDockerDesktop

    if (Get-Command winget.exe -ErrorAction SilentlyContinue) {
        & winget.exe uninstall `
            --id Docker.DockerDesktop `
            --exact `
            --source winget `
            --accept-source-agreements

        if ($LASTEXITCODE -eq 0) {
            Write-Host "[OK] Docker Desktop désinstallé." -ForegroundColor Green
            return $true
        }
    }

    $uninstaller = Join-Path $env:ProgramFiles "Docker\Docker\Docker Desktop Installer.exe"

    if (Test-Path -LiteralPath $uninstaller -PathType Leaf) {
        & $uninstaller uninstall
        if ($LASTEXITCODE -eq 0) {
            Write-Host "[OK] Docker Desktop désinstallé." -ForegroundColor Green
            return $true
        }
    }

    throw "Impossible de désinstaller Docker Desktop automatiquement."
}

function Uninstall-CrodipWslDistribution {
    [CmdletBinding()]
    param(
        [string]$Distribution = (Get-CrodipWslDistribution)
    )

    if (-not (Get-Command wsl.exe -ErrorAction SilentlyContinue)) {
        Write-Host "[OK] WSL n'est pas disponible." -ForegroundColor Green
        return $true
    }

    if (-not (Test-CrodipWslDistribution -Distribution $Distribution)) {
        Write-Host "[OK] Distribution WSL absente : $Distribution" -ForegroundColor Green
        return $true
    }

    Write-Warning "ATTENTION : wsl --unregister supprime définitivement la distribution et toutes ses données Linux."

    if (-not (Confirm-CrodipDestructiveAction `
        -Message "Confirmer la suppression définitive de $Distribution." `
        -ExpectedText "SUPPRIMER $Distribution")) {
        Write-Warning "Suppression annulée."
        return $false
    }

    & wsl.exe --terminate $Distribution 2>$null
    & wsl.exe --unregister $Distribution

    if ($LASTEXITCODE -ne 0) {
        throw "Échec de la suppression de la distribution WSL : $Distribution"
    }

    Write-Host "[OK] Distribution supprimée : $Distribution" -ForegroundColor Green
    return $true
}

function Disable-CrodipWslWindowsFeatures {
    [CmdletBinding()]
    param()

    if (-not (Test-CrodipAdministrator)) {
        throw "La désactivation de WSL2 doit être lancée en mode administrateur."
    }

    Write-Warning "Cette opération désactive WSL et Virtual Machine Platform pour Windows."

    if (-not (Confirm-CrodipDestructiveAction `
        -Message "Confirmer la désactivation des composants WSL2." `
        -ExpectedText "DESACTIVER WSL2")) {
        Write-Warning "Désactivation annulée."
        return $false
    }

    foreach ($featureName in @(
        "Microsoft-Windows-Subsystem-Linux",
        "VirtualMachinePlatform"
    )) {
        try {
            $state = Get-WindowsOptionalFeature -Online -FeatureName $featureName -ErrorAction Stop
            if ($state.State -eq "Enabled") {
                Disable-WindowsOptionalFeature `
                    -Online `
                    -FeatureName $featureName `
                    -NoRestart `
                    -ErrorAction Stop | Out-Null

                Write-Host "[OK] Désactivé : $featureName" -ForegroundColor Green
            }
            else {
                Write-Host "[OK] Déjà désactivé : $featureName" -ForegroundColor Green
            }
        }
        catch {
            Write-Warning "Impossible de modifier $featureName : $($_.Exception.Message)"
        }
    }

    Write-Warning "Redémarrage Windows recommandé."
    return $true
}

function Uninstall-CrodipDockerWslStack {
    [CmdletBinding()]
    param(
        [string]$Distribution = (Get-CrodipWslDistribution)
    )

    Write-Host ""
    Write-Host "==========================================================" -ForegroundColor Cyan
    Write-Host " Désinstallation Docker / Ubuntu / WSL2" -ForegroundColor Cyan
    Write-Host "==========================================================" -ForegroundColor Cyan
    Write-Warning "La suppression de la distribution Ubuntu est destructive."

    if (-not (Confirm-CrodipDestructiveAction `
        -Message "Confirmer la procédure complète." `
        -ExpectedText "DESINSTALLATION COMPLETE")) {
        Write-Warning "Procédure annulée."
        return $false
    }

    $null = Uninstall-CrodipDockerDesktop
    $null = Uninstall-CrodipWslDistribution -Distribution $Distribution
    $null = Disable-CrodipWslWindowsFeatures

    Write-Host "[OK] Désinstallation complète terminée." -ForegroundColor Green
    Write-Warning "Redémarrer Windows avant une éventuelle réinstallation."
    return $true
}

Export-ModuleMember -Function @(
    "Get-CrodipDockerCliExecutable",
    "Update-CrodipDockerCliPath",
    "Test-CrodipDockerCli",
    "Get-CrodipDockerProvider",
    "Get-CrodipWslDistribution",
    "Set-CrodipDockerProvider",
    "Test-CrodipWslDistribution",
    "Convert-CrodipPathToWsl",
    "Invoke-CrodipDockerCli",
    "Test-CrodipSelectedDockerEngine",
    "Start-CrodipUbuntuDockerEngine",
    "Get-CrodipDockerProviderInfo",
    "Test-CrodipAdministrator",
    "Install-CrodipDockerDesktop",
    "Install-CrodipWslUbuntu",
    "Install-CrodipUbuntuDockerEngine",
    "Test-CrodipDockerDesktopInstalled",
    "Test-CrodipUbuntuDockerInstalled",
    "Get-CrodipWslStatus",
    "Install-CrodipWsl2Prerequisite",
    "Test-CrodipDockerDesktopReadiness",
    "Assert-CrodipDockerDesktopReady",
    "Ensure-CrodipWsl2Prerequisite",
    "Confirm-CrodipDestructiveAction",
    "Stop-CrodipDockerDesktop",
    "Uninstall-CrodipDockerDesktop",
    "Uninstall-CrodipWslDistribution",
    "Disable-CrodipWslWindowsFeatures",
    "Uninstall-CrodipDockerWslStack"
)
