

<#Transfert des 3 fichiers SYSINFOS
#>
function transfertSysInfoFiles() {
	
param(
[Parameter (mandatory=$true)]
[string] $fichier
)
#Création des 3 paths
$jsonPath = $fichier.replace(".txt",".json").replace(".md",".json")
$txtPath = $jsonPath.replace(".json",".txt")
$mdPath = $jsonPath.replace(".json",".md")
$filename = Split-Path -Path $fichier -Leaf
$filename = $filename.replace(".json","").replace(".txt","").replace(".md", "")
$Repertoire = Split-Path -Path $fichier -Parent

#extraction du NumeroCRODIP du PC
$data = Get-Content -Path $jsonPath -Raw | ConvertFrom-Json
$crodipPC = $data.Computer.CRODIP_PC

#Copie des 3 fichiers avec le Numero du PC
$jsonfinalfile = join-Path $Repertoire $crodipPC"-"$filename".json"
$txtfinalfile = join-Path $Repertoire $crodipPC"-"$filename".txt"
$mdfinalfile = join-Path $Repertoire $crodipPC"-"$filename".md"

<# Write-Host "JSON : $jsonpath"
Write-Host "TXT : $txtpath"
Write-Host "MD : $mdpath"
Write-Host "CRODIP_PC : $crodipPC"
Write-Host "filename : $filename"
Write-Host "repertoire : $repertoire"
Write-Host "JsonFinalfile : $jsonfinalfile"
Write-Host "txtFinalfile : $txtfinalfile"
Write-Host "mdFinalfile : $mdfinalfile"
#>

Copy-Item -Path $jsonPath -Destination $jsonfinalfile
Copy-Item -Path $txtPath -Destination $txtfinalfile
Copy-Item -Path $mdPath -Destination $mdfinalfile

# Liste des Fichiers à transférer
$files = @(
    $jsonFinalFile,
    $txtFinalFile,
    $mdFinalFile
)


$ftpServer = "ftp://admin-pp.crodip.net:21777"
$remotePath = "/SYSINFOS/"
$username = "marc_collin"
$password = "mcollin"

#Pour chaque fichier
foreach ($file in $files) {

    if (-not (Test-Path -LiteralPath $file -PathType Leaf)) {
        Write-Warning "Fichier introuvable : $file"
        continue
    }

    $fileName = Split-Path -Path $file -Leaf
    $remoteUri = "$ftpServer$RemotePath$fileName"

    try {
        $request = [System.Net.FtpWebRequest]::Create($remoteUri)
        $request.Method = [System.Net.WebRequestMethods+Ftp]::UploadFile
        $request.Credentials = [System.Net.NetworkCredential]::new(
            $Username,
            $Password
        )
        $request.UseBinary = $true
        $request.UsePassive = $true
        $request.KeepAlive = $false

        # Envoi du fichier
        $fileStream = [System.IO.File]::OpenRead($file)
        $request.ContentLength = $fileStream.Length

        try {
            $requestStream = $request.GetRequestStream()
            try {
                $fileStream.CopyTo($requestStream)
            }
            finally {
                $requestStream.Dispose()
            }
        }
        finally {
            $fileStream.Dispose()
        }

        try {
        $response = $request.GetResponse()
#            Write-Host "Transfert réussi : $fileName" -ForegroundColor Green
#            Write-Host $response.StatusDescription
        }
        finally {
            $response.Close()
       }
    }#Try
    catch {
        Write-Error "Échec du transfert de $fileName : $($_.Exception.Message)"
    }
}#foreach
Write-Host "Transfert terminé" -ForegroundColor Green
}#transfertSysInfoFiles

#execution du script du portail
& (Join-Path $PSScriptRoot "RTManager/Commands/12-system-info.ps1")

#transfert des fichiers par FTP
transfertSysInfoFiles -fichier "C:\ProgramData\CRODIP\logs\reports\system-info.json"
