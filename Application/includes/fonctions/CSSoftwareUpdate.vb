Imports System.IO
Imports System.Threading

Module CSSoftwareUpdate


    Public Sub runUpdater()
        CSSoftwareUpdate.runUpdater(False)
    End Sub
    Public Sub runUpdater(ByVal withThread As Boolean)
        If withThread Then
            CSSoftwareUpdate.thr_majSoftware()
        Else
            CSSoftwareUpdate.majSoftware()
        End If
        Globals.Init()
    End Sub

    Private _thread_majSoftware As Thread
    Private Sub majSoftware()

        'Lancement du programme de mise a jour
        Dim Processus As New System.Diagnostics.Process
        Processus.StartInfo.FileName = "Crodip_updater.exe"
        Processus.Start()
        Processus.WaitForExit()
        'retourne un booléen confirmant le démarage du process

    End Sub
    Sub thr_majSoftware()
        _thread_majSoftware = New Thread(AddressOf CSSoftwareUpdate.thr_majSoftware) 'ThrFunc est la fonction exécutée par le thread.
        _thread_majSoftware.Name = "CSSoftwareUpdate_majSoftware" 'Il est parfois pratique de nommer les threads surtout si on en créé plusieurs.
        _thread_majSoftware.Start() ' Démarrage du thread.
    End Sub

    Public Function checkMAJ() As Boolean
        Dim bReturn As Boolean = False
        Try
            If Globals.GLOB_NETWORKAVAILABLE Then
                Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()

                Dim wsResponse As Object
                ' Appel au WS
                Dim codeResponse As Integer = objWSCrodip.GetSoftwareUpdate(Globals.GLOB_APPLI_BUILD, wsResponse)

                If codeResponse = 2 Then
                    bReturn = True
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("CSSoftwareUpdate.checkMAJ() : " & ex.Message)
            bReturn = False
        End Try

        Return bReturn

    End Function


End Module
