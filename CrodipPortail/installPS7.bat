@echo off
setlocal

echo Verification de PowerShell 7...

REM Recherche dans le PATH
where pwsh >nul 2>&1
if not errorlevel 1 (
    echo PowerShell 7 est deja installe.
    pwsh --version
    exit /b 0
)

REM Recherche dans le repertoire standard
if exist "%ProgramFiles%\PowerShell\7\pwsh.exe" (
    echo PowerShell 7 est deja installe.
    "%ProgramFiles%\PowerShell\7\pwsh.exe" --version
    exit /b 0
)

echo PowerShell 7 absent. Installation en cours...

winget install --id Microsoft.PowerShell --source winget --accept-source-agreements --accept-package-agreements

set "RC=%ERRORLEVEL%"
echo Code retour winget : %RC%

REM Verification apres installation
if exist "%ProgramFiles%\PowerShell\7\pwsh.exe" (
    echo Installation reussie.
    "%ProgramFiles%\PowerShell\7\pwsh.exe" --version
    exit /b 0
)

where pwsh >nul 2>&1
if not errorlevel 1 (
    echo Installation reussie.
    pwsh --version
    exit /b 0
)

echo ERREUR : installation non detectee.
echo Verifiez le chemin d'installation de PowerShell 7.
exit /b 1
```