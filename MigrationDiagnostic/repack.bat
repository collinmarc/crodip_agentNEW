@echo off
setlocal

rem Path to ILRepack executable
set ILREPACK="./ILRepack.exe"

rem Output directory
set OUTDIR=""

rem Target application and output file names
set TARGET="MigrationDiagnostic.exe"
set OUTPUT="MIGR.exe"

rem Run ILRepack
%ILREPACK% /out:%OUTPUT% %TARGET% e_sqlite3.dll Microsoft.data.sqlite.dll SQLitePCLRaw.batteries_v2.dll SQLitePCLRaw.provider.dynamic_cdecl.dll SQLitePCLRaw.core.dll NLog.config NLog.dll System.Data.Common.dll System.Diagnostics.StackTrace.dll System.Diagnostics.Tracing.dll System.Globalization.Extensions.dll System.IO.Compression.dll System.Net.Http.dll System.Net.Sockets.dll System.Runtime.Serialization.Primitives.dll System.Security.Cryptography.Algorithms.dll System.Security.SecureString.dll System.Threading.Overlapped.dll System.Xml.XPath.XDocument.dll System.Memory.dll System.Runtime.CompilerServices.Unsafe.dll System.ValueTuple.dll System.Numerics.Vectors.dll System.Buffers.dll

endlocal
pause
