Imports System.Net
Imports System.IO
Public Class CSFTP

    Private m_user As String
    Private m_password As String
    Private m_host As String

    Public Sub New()
        If Not Globals.GLOB_ENV_DEBUG And My.Settings.WSCrodipProduction Then
            m_user = My.Settings.FTPuser
            m_password = My.Settings.FTPPassword
            m_host = My.Settings.FTPHost
        Else
            m_user = My.Settings.FTPUserTest
            m_password = My.Settings.FTPPasswordTest
            m_host = My.Settings.FTPHostTest
        End If


    End Sub
    Public Sub New(pUser As String, pPassword As String, pHost As String)
        m_user = pUser
        m_password = pPassword
        m_host = pHost

    End Sub
    Public Function Upload(ByVal pFilePath As String, Optional pTargetPath As String = "") As Boolean
        Dim bReturn As Boolean
        Dim nStep As Integer
        Try
            Dim oFileInfo As FileInfo

            nStep = 0
            oFileInfo = New FileInfo(pFilePath)
            Dim ftpURI As Uri
            If String.IsNullOrEmpty(pTargetPath) Then
                ftpURI = New Uri("ftp://" & m_host & "/" & oFileInfo.Name)
            Else
                ftpURI = New Uri("ftp://" & m_host & "/" & pTargetPath & "/" & oFileInfo.Name)
            End If

            nStep = nStep + 1
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(ftpURI), FtpWebRequest)
            'On désactive proxy 
            request.Proxy = GlobalProxySelection.GetEmptyWebProxy()

            nStep = nStep + 1
            request.Method = WebRequestMethods.Ftp.UploadFile
            request.Credentials = New NetworkCredential(m_user, m_password)
            request.UseBinary = True
            request.KeepAlive = False
            request.UsePassive = My.Settings.FTPUsePassiveMode
            Dim buffer As Byte() = File.ReadAllBytes(pFilePath)
            nStep = nStep + 1
            Dim RQstream As Stream = request.GetRequestStream()
            nStep = nStep + 1

            '            Dim fs As FileStream = File.OpenRead(oFileInfo.FullName)
            '           Dim block As Integer
            '          While ((block = fs.Read(buffer, 0, buffer.Length)) > 0)
            'RQstream.Write(buffer, 0, block)
            'End While
            RQstream.Write(buffer, 0, buffer.Length)
            nStep = nStep + 1
            RQstream.Close()
            nStep = nStep + 1
            RQstream.Dispose()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("CSFTP.Upload (" & pFilePath & ") ERR[" & nStep & "]:" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function DownLoad(pSourceFileName As String, ByVal pTargetFilePath As String) As Boolean
        Dim bReturn As Boolean
        Dim nStep As Integer
        Try
            Dim oFileInfo As FileInfo
            nStep = 0
            Dim ftpURI As New Uri("ftp://" & m_host & "/" & pSourceFileName)
            Dim request As FtpWebRequest = DirectCast(FtpWebRequest.Create(ftpURI), FtpWebRequest)
            nStep = 1
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Credentials = New NetworkCredential(m_user, m_password)
            request.KeepAlive = False
            Dim response As FtpWebResponse
            response = DirectCast(request.GetResponse(), FtpWebResponse)
            nStep = 2
            Dim responseStream As Stream
            responseStream = response.GetResponseStream()
            nStep = 3
            Dim reader As StreamReader = New StreamReader(responseStream)
            File.WriteAllText(pTargetFilePath & pSourceFileName, reader.ReadToEnd())
            nStep = 4

            reader.Close()
            response.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("CSFTP.Download (" & pSourceFileName & ") ERR[" & nStep & "]:" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class
