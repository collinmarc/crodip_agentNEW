Imports System.IO
Imports System.Threading

Public Class CSSoftwareUpdate


    Public Shared Sub runUpdater()
        CSSoftwareUpdate.runUpdater(False)
    End Sub
    Public Shared Sub runUpdater(ByVal withThread As Boolean)
        If withThread Then
            CSSoftwareUpdate.thr_majSoftware()
        Else
            CSSoftwareUpdate.majSoftware()
        End If
        'GlobalsCRODIP.Init()
    End Sub

    Private Shared _thread_majSoftware As Thread
    Private Shared Sub majSoftware()

        'Lancement du programme de mise a jour
        Dim Processus As New System.Diagnostics.Process
        Processus.StartInfo.FileName = "Crodip_updater.exe"
        Processus.Start()
        Processus.WaitForExit()
        'retourne un booléen confirmant le démarage du process

    End Sub
    Private Shared Sub thr_majSoftware()
        _thread_majSoftware = New Thread(AddressOf CSSoftwareUpdate.thr_majSoftware) 'ThrFunc est la fonction exécutée par le thread.
        _thread_majSoftware.Name = "CSSoftwareUpdate_majSoftware" 'Il est parfois pratique de nommer les threads surtout si on en créé plusieurs.
        _thread_majSoftware.Start() ' Démarrage du thread.
    End Sub
    Public Shared Function checkMAJ() As Boolean
        Dim bReturn As Boolean = False
        'En mode simplifié pas de Mise à jour
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
            Return False
        End If
        Try
            If GlobalsCRODIP.GLOB_NETWORKAVAILABLE And Not isXPorBefore() Then
                Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()

                Dim wsResponse As New Object
                Dim infos As String = ""
                ' Appel au WS
                Dim codeResponse As Integer = objWSCrodip.GetSoftwareUpdate(GlobalsCRODIP.GLOB_APPLI_BUILD, infos, wsResponse)
                If codeResponse = 2 Then
                    Dim oUpdateInfo As UpdateInfo
                    oUpdateInfo = New UpdateInfo(wsResponse)

                    For Each sFile As String In oUpdateInfo.files
                        If sFile.ToUpper().EndsWith("VERSION.HTML") Or sFile.ToUpper().EndsWith("VERSION.HTM") Then
                            oUpdateInfo.DoDownload(sFile)
                            MyUpdateInfo = oUpdateInfo
                        End If

                    Next
                    bReturn = True
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("CSSoftwareUpdate.checkMAJ() : " & ex.Message)
            bReturn = False
        End Try

        Return bReturn

    End Function
    Private Shared _UpdateInfo As UpdateInfo
    Public Shared Property MyUpdateInfo() As UpdateInfo
        Get
            Return _UpdateInfo
        End Get
        Set(ByVal value As UpdateInfo)
            _UpdateInfo = value
        End Set
    End Property

    Public Shared Function isXPorBefore() As Boolean
        Dim nMajor As Integer
        nMajor = System.Environment.OSVersion.Version.Major
        Return (nMajor <= 5)
    End Function

End Class
