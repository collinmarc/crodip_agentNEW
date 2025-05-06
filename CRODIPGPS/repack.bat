@echo off
setlocal

rem Path to ILRepack executable
set ILREPACK="./ILRepack.exe"

rem Output directory
set OUTDIR=""

rem Target application and output file names
set TARGET="CRODIPGPS.exe"
set OUTPUT="CRODIPGPSFULL.exe"

rem Run ILRepack
%ILREPACK% /out:%OUTPUT% %TARGET% MaterialSkin.dll System.Diagnostics.DiagnosticSource.dll System.IO.Compression.dll System.Net.Http.dll

endlocal
pause
