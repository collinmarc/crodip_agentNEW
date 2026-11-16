$ftpServer = "ftp://admin-pp.crodip.net:21777"
$remotePath = "/SYSINFOS"
$localFile = "sysinfos.txt"

$username = "marc_collin"
$password = "mcollin"

$ftpUri = "$ftpServer$remotePath"

$request = [System.Net.FtpWebRequest]::Create($ftpUri)
$request.Method = [System.Net.WebRequestMethods+Ftp]::UploadFile
$request.Credentials = New-Object System.Net.NetworkCredential(
    $username,
    $password
)
$request.UseBinary = $true
$request.UsePassive = $true
$request.KeepAlive = $false

$fileContent = [System.IO.File]::ReadAllBytes($localFile)
$request.ContentLength = $fileContent.Length

$requestStream = $request.GetRequestStream()
$requestStream.Write($fileContent, 0, $fileContent.Length)
$requestStream.Close()

$response = $request.GetResponse()
Write-Host "Upload terminé : $($response.StatusDescription)"

$response.Close()