###############################################################
# CRODIP Runtime Manager
# Module   : Crodip.Runtime.Compose.psm1
# Version  : 2.3.0-RC22
# Statut   : Stable - Lot 4 Auto GHCR
###############################################################
Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

if (-not (Get-Command Invoke-CrodipDockerCli -ErrorAction SilentlyContinue)) {
    Import-Module `
        (Join-Path $PSScriptRoot "Crodip.Runtime.DockerProvider.psm1") `
        -Global `
        -DisableNameChecking `
        -ErrorAction Stop
}

function Get-CrodipComposeFile {
 [CmdletBinding()]param([string]$ApplicationRoot=(Get-CrodipHome))
 foreach($name in @("compose.yaml","compose.yml","docker-compose.yml","docker-compose.yaml")){
  $path=Join-Path $ApplicationRoot $name
  if(Test-Path -LiteralPath $path){return $path}
 }
 return $null
}
function Invoke-CrodipCompose {
 [CmdletBinding(SupportsShouldProcess=$true)]
 param(
  [Parameter(Mandatory)][ValidateSet("up","stop","down","restart","pull","ps","logs","config")][string]$Action,
  [string]$ComposeFile=(Get-CrodipComposeFile),
  [switch]$Detached,[switch]$RemoveOrphans,[switch]$ForceRecreate,
  [string[]]$Services = @(),
  [ValidateSet("","always","missing","never","build")][string]$PullPolicy=""
 )
 if([string]::IsNullOrWhiteSpace($ComposeFile)){throw "Aucun fichier Compose trouvé."}
 $workingDirectory=Split-Path -Parent $ComposeFile
 $composeName=Split-Path -Leaf $ComposeFile
 $envFile=Join-Path $workingDirectory ".env"
 $arguments=@("compose","-f",$composeName)
 if(Test-Path -LiteralPath $envFile){$arguments+=@("--env-file",".env")}
 switch($Action){
  "up"{$arguments+="up";if($Detached){$arguments+="-d"};if($RemoveOrphans){$arguments+="--remove-orphans"};if($ForceRecreate){$arguments+="--force-recreate"};if($PullPolicy){$arguments+=@("--pull",$PullPolicy)}}
  "restart"{$arguments+="restart"};"stop"{$arguments+="stop"};"down"{$arguments+="down"};"pull"{$arguments+="pull";if($Services.Count -gt 0){$arguments+=$Services}}
  "ps"{$arguments+=@("ps","--format","json")};"logs"{$arguments+=@("logs","--tail","100")};"config"{$arguments+="config"}
 }
 $description="docker $($arguments -join ' ')"
 if(-not $PSCmdlet.ShouldProcess($workingDirectory,$description)){return [pscustomobject]@{ExitCode=0;Output=@();Simulated=$true}}
 $result = Invoke-CrodipDockerCli -Arguments $arguments -WorkingDirectory $workingDirectory
 [pscustomobject]@{ExitCode=$result.ExitCode;Output=@($result.Output);Simulated=$false}
}

function Repair-CrodipRuntimeComposeIsolation {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param(
        [Parameter(Mandatory)][string]$ComposeFile
    )

    if (-not (Test-Path -LiteralPath $ComposeFile -PathType Leaf)) {
        throw "compose.yaml introuvable : $ComposeFile"
    }

    $content = Get-Content -LiteralPath $ComposeFile -Raw
    $original = $content
    $changes = [System.Collections.Generic.List[string]]::new()

    if ($content -match '(?m)^name:\s*crodip-local\s*$') {
        $content = $content -replace '(?m)^name:\s*crodip-local\s*$','name: crodip-runtime-local'
        $changes.Add("Projet Compose : crodip-local -> crodip-runtime-local")
    }
    elseif ($content -notmatch '(?m)^name:\s*crodip-runtime-local\s*$') {
        if ($content -match '(?m)^name:\s*.+$') {
            $changes.Add("Nom de projet Compose non standard conservé.")
        }
        else {
            $content = "name: crodip-runtime-local`r`n`r`n" + $content
            $changes.Add("Projet Compose ajouté : crodip-runtime-local")
        }
    }

    foreach ($legacyName in @("crodip-backend","crodip-frontend")) {
        $pattern = "(?m)^\s*container_name:\s*" + [regex]::Escape($legacyName) + "\s*\r?\n"
        if ($content -match $pattern) {
            $content = [regex]::Replace($content,$pattern,"")
            $changes.Add("container_name supprimé : $legacyName")
        }
    }

    if ($content -eq $original) {
        return [pscustomobject]@{
            Changed=$false
            Backup=$null
            Changes=@()
        }
    }

    Write-CrodipWarning "Configuration Compose locale historique détectée."
    foreach ($change in $changes) {
        Write-Host " - $change"
    }

    $answer=Read-Host "Appliquer l'isolation Compose Runtime local ? [O/n]"
    if ([string]::IsNullOrWhiteSpace($answer)){$answer="O"}

    if ($answer -notmatch '^[oOyY]$') {
        Write-CrodipWarning "Migration Compose ignorée."
        return [pscustomobject]@{Changed=$false;Backup=$null;Changes=@($changes)}
    }

    $stamp=Get-Date -Format "yyyyMMdd-HHmmss"
    $backup="$ComposeFile.before-project-isolation-$stamp.bak"

    if ($PSCmdlet.ShouldProcess($ComposeFile,"Migrer le projet Compose Runtime local")) {
        Copy-Item -LiteralPath $ComposeFile -Destination $backup -Force
        Set-Content -LiteralPath $ComposeFile -Value $content -Encoding utf8
        Write-CrodipSuccess "Compose migré vers le projet crodip-runtime-local."
        Write-CrodipSuccess "Sauvegarde : $backup"
    }

    [pscustomobject]@{
        Changed=$true
        Backup=$backup
        Changes=@($changes)
    }
}

function Get-CrodipDockerPublishedPortOwners {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][int]$Port
    )

    $r = Invoke-CrodipDockerCli -Arguments @(
        "ps",
        "--format",
        "{{json .}}"
    )

    if ($r.ExitCode -ne 0) {
        return @()
    }

    $owners = @()

    foreach ($line in $r.Output) {
        if ([string]::IsNullOrWhiteSpace([string]$line)) {
            continue
        }

        try {
            $item = [string]$line | ConvertFrom-Json -Depth 100
        }
        catch {
            continue
        }

        $portsText = [string]$item.Ports

        if ($portsText -notmatch "(^|[, ])(?:0\.0\.0\.0:|\[::\]:|127\.0\.0\.1:|localhost:)?$Port->") {
            continue
        }

        $containerName = [string]$item.Names
        $containerId = [string]$item.ID

        $project = ""
        $service = ""

        try {
            $inspect = Invoke-CrodipDockerCli -Arguments @(
                "inspect",
                $containerName
            )

            if ($inspect.ExitCode -eq 0) {
                $obj = ($inspect.Output -join "`n") | ConvertFrom-Json -Depth 100
                if ($obj -is [array]) {
                    $obj = $obj | Select-Object -First 1
                }

                $labels = $obj.Config.Labels

                if ($null -ne $labels) {
                    if ($labels.PSObject.Properties.Name -contains "com.docker.compose.project") {
                        $project = [string]$labels."com.docker.compose.project"
                    }

                    if ($labels.PSObject.Properties.Name -contains "com.docker.compose.service") {
                        $service = [string]$labels."com.docker.compose.service"
                    }
                }
            }
        }
        catch {}

        $owners += [pscustomobject]@{
            ContainerName = $containerName
            ContainerId = $containerId
            ComposeProject = $project
            ComposeService = $service
            Ports = $portsText
        }
    }

    return @($owners)
}

function Get-CrodipWindowsPortListeners {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][int]$Port
    )

    $listeners = @(
        Get-NetTCPConnection `
            -State Listen `
            -LocalPort $Port `
            -ErrorAction SilentlyContinue
    )

    $results = @()

    foreach ($listener in $listeners) {
        $processName = ""
        $processExists = $false

        try {
            $proc = Get-Process -Id $listener.OwningProcess -ErrorAction Stop
            $processName = [string]$proc.ProcessName
            $processExists = $true
        }
        catch {}

        $isDockerRelay = (
            $processName -match '^(?i:wslrelay|com\.docker\.backend|docker-proxy|vpnkit)$'
        )

        $results += [pscustomobject]@{
            LocalAddress = [string]$listener.LocalAddress
            LocalPort = [int]$listener.LocalPort
            OwningProcess = [int]$listener.OwningProcess
            ProcessName = $processName
            ProcessExists = $processExists
            IsDockerRelay = $isDockerRelay
        }
    }

    return @($results)
}

function Test-CrodipRuntimePortAvailability {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$ComposeFile
    )

    $wd=Split-Path -Parent $ComposeFile
    $file=Split-Path -Leaf $ComposeFile
    $r=Invoke-CrodipDockerCli `
        -Arguments @("compose","-f",$file,"config","--format","json") `
        -WorkingDirectory $wd

    if($r.ExitCode -ne 0){
        return @()
    }

    try{
        $cfg=($r.Output -join "`n")|ConvertFrom-Json -Depth 100
    }
    catch{
        return @()
    }

    $currentProject = ""
    if ($cfg.PSObject.Properties.Name -contains "name") {
        $currentProject = [string]$cfg.name
    }

    if ([string]::IsNullOrWhiteSpace($currentProject)) {
        $currentProject = "crodip-runtime-local"
    }

    $results=@()

    foreach($prop in $cfg.services.PSObject.Properties){
        $serviceName=$prop.Name
        $svc=$prop.Value

        $portsProperty = $svc.PSObject.Properties['ports']
        if($null -eq $portsProperty){ continue }
        foreach($port in @($portsProperty.Value)){
            if($null -eq $port){continue}

            $published=[string]$port.published
            if([string]::IsNullOrWhiteSpace($published)){continue}

            $portNumber=[int]$published
            $dockerOwners=@(Get-CrodipDockerPublishedPortOwners -Port $portNumber)
            $windowsListeners=@(Get-CrodipWindowsPortListeners -Port $portNumber)

            $currentRuntimeOwners=@(
                $dockerOwners |
                    Where-Object {
                        $_.ComposeProject -eq $currentProject -and
                        $_.ComposeService -eq $serviceName
                    }
            )

            $otherDockerOwners=@(
                $dockerOwners |
                    Where-Object {
                        -not (
                            $_.ComposeProject -eq $currentProject -and
                            $_.ComposeService -eq $serviceName
                        )
                    }
            )

            $relayListeners=@(
                $windowsListeners |
                    Where-Object { $_.IsDockerRelay }
            )

            $externalWindowsListeners=@(
                $windowsListeners |
                    Where-Object {
                        -not $_.IsDockerRelay -and
                        $_.ProcessExists
                    }
            )

            $state = "AVAILABLE"
            $message = "Port disponible."

            if ($currentRuntimeOwners.Count -gt 0) {
                $state = "OWNED_BY_CURRENT_RUNTIME"
                $message = "Port déjà publié par le service Runtime courant."
            }
            elseif ($otherDockerOwners.Count -gt 0) {
                $state = "CONFLICT_DOCKER"
                $message = "Port publié par un autre conteneur Docker."
            }
            elseif ($externalWindowsListeners.Count -gt 0) {
                $state = "CONFLICT_WINDOWS"
                $message = "Port utilisé par un processus Windows externe."
            }
            elseif ($relayListeners.Count -gt 0) {
                # Un relais Docker/WSL sans owner Docker visible n'est pas considéré
                # automatiquement comme conflit dur, mais signalé distinctement.
                $state = "DOCKER_RELAY_ONLY"
                $message = "Relais Docker/WSL détecté sans conteneur propriétaire identifié."
            }

            $results += [pscustomobject]@{
                Service = $serviceName
                Port = $portNumber
                State = $state
                Message = $message
                CurrentProject = $currentProject
                DockerOwners = $dockerOwners
                CurrentRuntimeOwners = $currentRuntimeOwners
                OtherDockerOwners = $otherDockerOwners
                WindowsListeners = $windowsListeners
                RelayListeners = $relayListeners
                ExternalWindowsListeners = $externalWindowsListeners
                InUse = ($state -ne "AVAILABLE")
                HasConflict = ($state -in @("CONFLICT_DOCKER","CONFLICT_WINDOWS"))
            }
        }
    }

    return @($results)
}

function Get-CrodipComposeServiceRuntimeStatus {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$ComposeFile
    )

    $wd = Split-Path -Parent $ComposeFile
    $file = Split-Path -Leaf $ComposeFile

    $r = Invoke-CrodipDockerCli `
        -Arguments @(
            "compose",
            "-f",
            $file,
            "ps",
            "--all",
            "--format",
            "json"
        ) `
        -WorkingDirectory $wd

    if ($r.ExitCode -ne 0) {
        return @()
    }

    $raw = ($r.Output -join "`n").Trim()

    if ([string]::IsNullOrWhiteSpace($raw)) {
        return @()
    }

    $items = @()

    try {
        # Docker Compose may return either a JSON array or one JSON object per line.
        $parsed = $raw | ConvertFrom-Json -Depth 100

        if ($parsed -is [array]) {
            $items = @($parsed)
        }
        else {
            $items = @($parsed)
        }
    }
    catch {
        $items = @()

        foreach ($line in $r.Output) {
            if ([string]::IsNullOrWhiteSpace([string]$line)) {
                continue
            }

            try {
                $items += ([string]$line | ConvertFrom-Json -Depth 100)
            }
            catch {}
        }
    }

    $results = @()

    foreach ($item in $items) {
        $service = ""
        $name = ""
        $state = ""
        $status = ""
        $health = ""
        $image = ""
        $exitCode = $null

        foreach ($pair in @(
            @{ P="Service"; V=[ref]$service },
            @{ P="Name"; V=[ref]$name },
            @{ P="State"; V=[ref]$state },
            @{ P="Status"; V=[ref]$status },
            @{ P="Health"; V=[ref]$health },
            @{ P="Image"; V=[ref]$image }
        )) {
            if ($item.PSObject.Properties.Name -contains $pair.P) {
                $pair.V.Value = [string]$item.($pair.P)
            }
        }

        if ($item.PSObject.Properties.Name -contains "ExitCode") {
            $exitCode = $item.ExitCode
        }

        $normalized = switch -Regex ($state) {
            '^(?i:running)$'    { "RUNNING"; break }
            '^(?i:restarting)$' { "RESTARTING"; break }
            '^(?i:exited)$'     { "EXITED"; break }
            '^(?i:dead)$'       { "DEAD"; break }
            default {
                if ($status -match '(?i)restart') { "RESTARTING" }
                elseif ($status -match '(?i)up') { "RUNNING" }
                elseif ($status -match '(?i)exit') { "EXITED" }
                else { "UNKNOWN" }
            }
        }

        if (-not [string]::IsNullOrWhiteSpace($health)) {
            if ($health -match '(?i)unhealthy') {
                $normalized = "UNHEALTHY"
            }
        }

        $results += [pscustomobject]@{
            Service = $service
            ContainerName = $name
            State = $state
            Status = $status
            Health = $health
            Image = $image
            ExitCode = $exitCode
            NormalizedState = $normalized
        }
    }

    return @($results)
}

function Get-CrodipComposeServiceStatusByName {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$ComposeFile,
        [Parameter(Mandatory)][string]$Service
    )

    return @(
        Get-CrodipComposeServiceRuntimeStatus -ComposeFile $ComposeFile |
            Where-Object { $_.Service -eq $Service }
    ) | Select-Object -First 1
}

# RC19 - Compare les publications de ports du Compose résolu avec les conteneurs existants.
# Si un conteneur du projet courant conserve une ancienne publication (ex. 9010 au lieu de 9110),
# le service est explicitement arrêté et supprimé afin que le prochain compose up le recrée correctement.
function Repair-CrodipRuntimePublishedPortBindings {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param([Parameter(Mandatory)][string]$ComposeFile)

    $wd=Split-Path -Parent $ComposeFile
    $file=Split-Path -Leaf $ComposeFile
    $cfgResult=Invoke-CrodipDockerCli -Arguments @("compose","-f",$file,"config","--format","json") -WorkingDirectory $wd
    if($cfgResult.ExitCode -ne 0){ throw "Impossible de résoudre les ports Docker Compose." }
    $cfg=($cfgResult.Output -join "`n") | ConvertFrom-Json -Depth 100
    $changes=@()

    foreach($prop in $cfg.services.PSObject.Properties){
        $service=$prop.Name; $svc=$prop.Value
        $expected=@{}
        $portsProperty = $svc.PSObject.Properties['ports']
        if($null -eq $portsProperty){ continue }
        foreach($port in @($portsProperty.Value)){
            if($null -eq $port -or [string]::IsNullOrWhiteSpace([string]$port.published)){continue}
            $expected[[string]$port.target]=[string]$port.published
        }
        if($expected.Count -eq 0){continue}

        $qid=Invoke-CrodipDockerCli -Arguments @("compose","-f",$file,"ps","-q",$service) -WorkingDirectory $wd
        if($qid.ExitCode -ne 0){continue}
        $containerId=(@($qid.Output)|Where-Object{-not [string]::IsNullOrWhiteSpace($_)}|Select-Object -First 1)
        if([string]::IsNullOrWhiteSpace($containerId)){continue}

        $inspect=Invoke-CrodipDockerCli -Arguments @("inspect",$containerId,"--format","{{json .HostConfig.PortBindings}}") -WorkingDirectory $wd
        if($inspect.ExitCode -ne 0){continue}
        try{$bindings=(($inspect.Output -join "`n")|ConvertFrom-Json -Depth 20)}catch{continue}
        $mismatch=$false; $actualText=@()
        foreach($target in $expected.Keys){
            $key="$target/tcp"; $actual=""
            $bp=$bindings.PSObject.Properties[$key]
            if($null -ne $bp -and @($bp.Value).Count -gt 0){$actual=[string]@($bp.Value)[0].HostPort}
            $actualText += "$target->$actual"
            if($actual -ne [string]$expected[$target]){$mismatch=$true}
        }
        if($mismatch){
            Write-CrodipWarning ("Publication de port obsolète pour {0} : conteneur [{1}] / Compose [{2}]" -f $service,($actualText -join ', '),(($expected.GetEnumerator()|ForEach-Object{"$($_.Key)->$($_.Value)"}) -join ', '))
            if($PSCmdlet.ShouldProcess($service,"Arrêter et supprimer le conteneur pour appliquer les ports Compose")){
                $stop=Invoke-CrodipDockerCli -Arguments @("compose","-f",$file,"stop",$service) -WorkingDirectory $wd
                if($stop.ExitCode -ne 0){throw "Échec arrêt du service $service pendant la migration des ports."}
                $rm=Invoke-CrodipDockerCli -Arguments @("compose","-f",$file,"rm","-f",$service) -WorkingDirectory $wd
                if($rm.ExitCode -ne 0){throw "Échec suppression du service $service pendant la migration des ports."}
                $changes += $service
                Write-CrodipSuccess "Conteneur $service supprimé : il sera recréé avec les ports attendus."
            }
        }
    }
    [pscustomobject]@{Changed=($changes.Count -gt 0); Services=@($changes)}
}

function Test-CrodipRuntimePublishedPortBindings {
    [CmdletBinding()]
    param([Parameter(Mandatory)][string]$ComposeFile)
    $wd=Split-Path -Parent $ComposeFile; $file=Split-Path -Leaf $ComposeFile
    $cfgResult=Invoke-CrodipDockerCli -Arguments @("compose","-f",$file,"config","--format","json") -WorkingDirectory $wd
    if($cfgResult.ExitCode -ne 0){return @()}
    $cfg=($cfgResult.Output -join "`n")|ConvertFrom-Json -Depth 100; $out=@()
    foreach($prop in $cfg.services.PSObject.Properties){
        $service=$prop.Name
        $qid=Invoke-CrodipDockerCli -Arguments @("compose","-f",$file,"ps","-q",$service) -WorkingDirectory $wd
        $cid=(@($qid.Output)|Where-Object{-not [string]::IsNullOrWhiteSpace($_)}|Select-Object -First 1)
        $portsProperty = $prop.Value.PSObject.Properties['ports']
        if($null -eq $portsProperty){ continue }
        foreach($port in @($portsProperty.Value)){
            if($null -eq $port -or [string]::IsNullOrWhiteSpace([string]$port.published)){continue}
            $expected=[string]$port.published; $target=[string]$port.target; $actual=""
            if(-not [string]::IsNullOrWhiteSpace($cid)){
                $ins=Invoke-CrodipDockerCli -Arguments @("inspect",$cid,"--format","{{json .HostConfig.PortBindings}}") -WorkingDirectory $wd
                if($ins.ExitCode -eq 0){try{$b=(($ins.Output -join "`n")|ConvertFrom-Json -Depth 20);$bp=$b.PSObject.Properties["$target/tcp"];if($null-ne $bp -and @($bp.Value).Count-gt 0){$actual=[string]@($bp.Value)[0].HostPort}}catch{}}
            }
            $out += [pscustomobject]@{Service=$service;Target=[int]$target;Expected=[int]$expected;Actual=if($actual){[int]$actual}else{$null};Valid=($actual -eq $expected)}
        }
    }
    return @($out)
}


# RC20 - Export final après définition de toutes les fonctions du module.
Export-ModuleMember -Function @(
    'Get-CrodipComposeFile',
    'Invoke-CrodipCompose',
    'Repair-CrodipRuntimeComposeIsolation',
    'Test-CrodipRuntimePortAvailability',
    'Get-CrodipComposeServiceRuntimeStatus',
    'Get-CrodipComposeServiceStatusByName',
    'Repair-CrodipRuntimePublishedPortBindings',
    'Test-CrodipRuntimePublishedPortBindings'
)
