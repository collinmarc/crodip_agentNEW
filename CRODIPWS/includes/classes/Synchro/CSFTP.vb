Imports System.Net
Imports System.IO
Public Class CSFTP

    Private m_user As String
    Private m_password As String
    Private m_host As String

    Public Sub New()
        If Not GlobalsCRODIP.GLOB_ENV_DEBUG And My.Settings.WSCrodipProduction Then
            m_user = My.Settings.FTPuser
            m_password = My.Settings.FTPPassword
            m_host = My.Settings.FTPHost
        Else
            m_user = My.Settings.FTPUserTest ' Utilisateur de test
            m_password = My.Settings.FTPPasswordTest 'Mot de passe de test
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


            Dim oClient As WebClient = New WebClient()
            oClient.Credentials = New NetworkCredential(m_user, m_password)
            oClient.UploadFile(ftpURI, pFilePath)

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
            Dim ftpURI As New Uri("ftp://" & m_host & "/" & pSourceFileName)
            Dim oClient As WebClient = New WebClient()
            oClient.Credentials = New NetworkCredential(m_user, m_password)
            oClient.DownloadFile(ftpURI, pTargetFilePath & pSourceFileName)

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("CSFTP.Download (" & pSourceFileName & ") ERR[" & nStep & "]:" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function FileExists(pTargetfileName As String) As Boolean
        Dim bReturn As Boolean = False
        Dim oRQ As System.Net.FtpWebRequest
        oRQ = CType(WebRequest.Create("ftp://" & m_host & "/" & pTargetfileName), FtpWebRequest)
        oRQ.Credentials = New NetworkCredential(m_user, m_password)
        oRQ.Method = WebRequestMethods.Ftp.GetFileSize
        Try
            Dim oRep As FtpWebResponse = CType(oRQ.GetResponse(), FtpWebResponse)
            oRep.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("CSFTP:FileExist ERR : " & ex.Message)
        End Try
        Return bReturn
    End Function
End Class
