

<#Transfert des bases de données #>
<#=========================#>
function transfertDatabases() {

    # Vérification de l'existence de la base MDB
    if (-not (Test-Path -LiteralPath (Join-Path $PSScriptRoot "bdd/crodip_agent.mdb") -PathType Leaf)) {
        Write-Host "Base de données MDB absente : pas de transferts de bases." -ForegroundColor Yellow
        return
    }

#Lecture de la clé de registre pour avoir le Numero de PC
	$CRODIP_PC = "Unknown"
	if (Test-Path "HKCU:\CRODIP") {
		$regKey = Get-ItemProperty -Path "HKCU:\CRODIP"

		if ($null -ne $regKey.PSObject.Properties["PC"]) {
			$CRODIP_PC = $regKey.PC
		}
	}

$baseDB3Path=Join-Path $PSScriptRoot "bdd/crodip_agent.db3"
$baseDB3FinalPath=Join-Path $PSScriptRoot "bdd/${CRODIP_PC}_crodip_agent.db3"
$baseMDBPath=Join-Path $PSScriptRoot "bdd/crodip_agent.mdb"
$baseMDBFinalPath=Join-Path $PSScriptRoot "bdd/${CRODIP_PC}_crodip_agent.mdb"
$baseLOGPath=Join-Path $PSScriptRoot "tmp/crodipAgentMigration.log"
$baseLOGFinalPath=Join-Path $PSScriptRoot "tmp/${CRODIP_PC}_crodipAgentMigration.log"

  Write-Host "baseDB3Path = "${baseDB3Path} -ForegroundColor Yellow
  Write-Host "baseDB3FinalPath = "${baseDB3FinalPath} -ForegroundColor Yellow
  Write-Host "baseMDBPath = "${baseMDBPath} -ForegroundColor Yellow
  Write-Host "baseMDBFinalPath = "${baseMDBFinalPath} -ForegroundColor Yellow

Copy-Item -Path $baseDB3Path -Destination $baseDB3FinalPath
Copy-Item -Path $baseMDBPath -Destination $baseMDBFinalPath
$files = @(
    $baseDB3FinalPath,
    $baseMDBFinalPath
)

 if ((Test-Path -LiteralPath $baseLOGPath -PathType Leaf)) {
        Copy-Item -Path $baseLOGPath -Destination $baseLOGFinalPath
        $files += $baseLOGFinalPath
    }


TransfertFTP -Files $files
    Write-Host "Transfert  Base de données terminé" -ForegroundColor Green


}
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

TransfertFTP -Files $files
    Write-Host "Transfert  Config terminé" -ForegroundColor Green


}#transfertSysInfoFiles


function TransfertFTP {
    param(
        [Parameter(Mandatory = $true)]
        [string[]] $Files
    )

    $ftpServer = "ftp://admin-pp.crodip.net:21777"
    $remotePath = "/SYSINFOS/"
    $username = "marc_collin"
    $password = "mcollin"

    # Pour chaque fichier
    foreach ($file in $Files) {

        if (-not (Test-Path -LiteralPath $file -PathType Leaf)) {
            Write-Warning "Fichier introuvable : $file"
            continue
        }

        $fileName = Split-Path -Path $file -Leaf
        $remoteUri = "$ftpServer$remotePath$fileName"

        try {
            $request = [System.Net.FtpWebRequest]::Create($remoteUri)
            $request.Method = [System.Net.WebRequestMethods+Ftp]::UploadFile
            $request.Credentials = [System.Net.NetworkCredential]::new(
                $username,
                $password
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
                Write-Host "Transfert réussi : $fileName" -ForegroundColor Green
            }
            finally {
                $response.Close()
            }
        }
        catch {
            Write-Error "Échec du transfert de $fileName : $($_.Exception.Message)"
        }
    }

}#TransfertFTP
#execution du script du portail
& (Join-Path $PSScriptRoot "RTManager/Commands/12-system-info.ps1")

#transfert des fichiers par FTP
transfertSysInfoFiles -fichier "C:\ProgramData\CRODIP\logs\reports\system-info.json"
transfertDatabases 
