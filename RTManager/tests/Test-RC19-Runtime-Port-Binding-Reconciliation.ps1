$ErrorActionPreference = 'Stop'

$root = Split-Path -Parent $PSScriptRoot

$compose = Get-Content `
    (Join-Path $root 'modules/Crodip.Runtime.Compose.psm1') `
    -Raw

$start = Get-Content `
    (Join-Path $root 'commands/03-start.ps1') `
    -Raw

foreach ($token in @(
    'Repair-CrodipRuntimePublishedPortBindings',
    'Test-CrodipRuntimePublishedPortBindings',
    'HostConfig.PortBindings',
    'compose","-f",$file,"rm","-f'
)) {
    if ($compose -notmatch [regex]::Escape($token)) {
        throw "Token absent: $token"
    }
}

foreach ($token in @(
    'Réconciliation des publications de ports',
    'Contrôle effectif des ports publiés après démarrage'
)) {
    if ($start -notmatch [regex]::Escape($token)) {
        throw "Token absent: $token"
    }
}

$config = Get-Content `
    (Join-Path $root 'config/runtime.json') `
    -Raw |
    ConvertFrom-Json

if ($config.docker.lifecyclePorts.TEST.local.backend -ne 8110) {
    throw 'Backend TEST != 8110'
}

if ($config.docker.lifecyclePorts.TEST.local.frontend -ne 9110) {
    throw 'Frontend TEST != 9110'
}

Write-Host '[OK] RC19 port binding reconciliation/control.'
