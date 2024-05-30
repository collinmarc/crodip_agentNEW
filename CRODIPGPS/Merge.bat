@echo off
setlocal

rem Path to ILMerge executable
set ILMERGE="C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe"

rem Output directory
set OUTDIR="C:\Path\To\Your\Project\bin\Release"

rem Target application and output file names
set TARGET="MyApplication.exe"
set OUTPUT="MyMergedApplication.exe"

rem Run ILMerge
%ILMERGE% /out:%OUTDIR%\%OUTPUT% %OUTDIR%\%TARGET% %OUTDIR%\Dependency1.dll %OUTDIR%\Dependency2.dll

endlocal
pause
