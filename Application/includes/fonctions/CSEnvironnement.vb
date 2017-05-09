#Region " Options "

Option Strict Off
Option Explicit On 

#End Region
#Region " Imports "

Imports System.Data
Imports System.Net

#End Region
Public Class CSEnvironnement

#Region " Version "

    Public Shared versionMessage As String = ""
    Public Shared versionUrl As String = ""

    ' Fonction permettant de tester si la version de l'application est en accord avec la version mini. du crodip
    Public Shared Function checkVersion()
        ' Init Vars
        Dim curVersion() As String = GLOB_APPLI_VERSION.Split(".")
        Dim csVersionResult() As String = CSVersion.getWSVersion()
        CSEnvironnement.versionMessage = csVersionResult(1)
        CSEnvironnement.versionUrl = csVersionResult(2)
        Dim minVersion() As String = csVersionResult(0).Split(".")
        Dim nbLevels As Integer = 0

        ' Nombre de niveau de versionning
        If minVersion.Length() > curVersion.Length() Then
            nbLevels = curVersion.Length
        Else
            nbLevels = minVersion.Length
        End If

        ' On compare chaque niveau en partant du plus haut
        For i As Integer = 0 To nbLevels - 1
            ' Si la version courante est supperieure, retourne TRUE
            If curVersion(i) > minVersion(i) Then
                Return True
                ' Si la version courante est inferieure, retourne FALSE
            ElseIf curVersion(i) < minVersion(i) Then
                Return False
            End If
        Next

        ' Si les deux versions sont égales, retourne TRUE
        Return True
    End Function

#End Region

#Region " Gestion PID "

    Public Shared Function setPid()
        Try
            CSFile.create(GLOB_PID_FILE, Date.UtcNow.ToLongDateString)
        Catch ex As Exception
            CSDebug.dispFatal("CSEnvironnement::setPid : " & ex.Message)
        End Try
    End Function
    Public Shared Function delPid()
        Try
            CSFile.delete(GLOB_PID_FILE)
        Catch ex As Exception
            CSDebug.dispFatal("CSEnvironnement::delPid : " & ex.Message)
        End Try
    End Function
    Public Shared Function existsPid()
        Try
            Return CSFile.exists(GLOB_PID_FILE)
        Catch ex As Exception
            CSDebug.dispFatal("CSEnvironnement::existsPid : " & ex.Message)
        End Try
    End Function
    Public Shared Function forcePid()
        CSEnvironnement.delPid()
        CSEnvironnement.setPid()
    End Function

#End Region

#Region " Connectivité "

    ' Fonction permettant de tester si on a une connexion internet
    Public Shared Function checkNetwork()

        '--- Déclaration des variables de la fonction
        Dim requete As HttpWebRequest = Nothing
        Dim reponse As HttpWebResponse = Nothing

        '--- Suivi des erreurs rencontrées
        Try
            requete = CType(WebRequest.Create("http://www.google.com"), HttpWebRequest)
            reponse = CType(requete.GetResponse, HttpWebResponse)
            requete.Abort() '--- Déconnexion
            If reponse.StatusCode = HttpStatusCode.OK Then
                globConnectFlagNok.Visible = False
                globConnectFlagOk.Visible = True
                Return True
            Else
                globConnectFlagNok.Visible = True
                globConnectFlagOk.Visible = False
                Return False
            End If
        Catch generatedExceptionVariable0 As WebException
            globConnectFlagNok.Visible = True
            globConnectFlagOk.Visible = False
            Return False
        Catch generatedExceptionVariable1 As Exception
            globConnectFlagNok.Visible = True
            globConnectFlagOk.Visible = False
            Return False
        End Try

    End Function

    ' Fonction permettant de tester si le webservice est en ligne
    Public Shared Function checkWebService()

        '--- Déclaration des variables de la fonction
        Dim requete As HttpWebRequest = Nothing
        Dim reponse As HttpWebResponse = Nothing
        Dim webserviceUrl As String
        Dim webservice As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
        webserviceUrl = webservice.Url
        '--- Suivi des erreurs rencontrées
        Try
            requete = CType(WebRequest.Create(webserviceUrl), HttpWebRequest)
            reponse = CType(requete.GetResponse, HttpWebResponse)
            requete.Abort() '--- Déconnexion
            If reponse.StatusCode = HttpStatusCode.OK Then
                Return True
            Else
                Return False
            End If
        Catch generatedExceptionVariable0 As WebException
            'CSDebug.dispError(generatedExceptionVariable0.Message.ToString)
            Return False
        Catch generatedExceptionVariable1 As Exception
            'CSDebug.dispError(generatedExceptionVariable1.Message.ToString)
            Return False
        End Try

    End Function

#End Region

#Region "renommage des fichiers"
    ''' Renomage des fichiers .arenommer (Crodip Updater.exe )
    Public Shared Function Renamefiles() As Boolean
        Dim bReturn As Boolean
        Try
            'Renommer crodipudater si besoin
            If System.IO.File.Exists(Environment.CurrentDirectory & "\Crodip_updater.exe.arenommer") Then
                If System.IO.File.Exists(Environment.CurrentDirectory & "\Crodip_updater.exe") Then
                    System.IO.File.Replace(Environment.CurrentDirectory & "\Crodip_updater.exe.arenommer", Environment.CurrentDirectory & "\Crodip_updater.exe", Environment.CurrentDirectory & "\Crodip_updater.exe.old")
                Else
                    System.IO.File.Replace(Environment.CurrentDirectory & "\Crodip_updater.exe.arenommer", Environment.CurrentDirectory & "\Crodip_updater.exe", Nothing)
                End If


                pause(1000)
            End If
            If System.IO.File.Exists(Environment.CurrentDirectory & "\Crodip_updater.exe.config.arenommer") Then
                If System.IO.File.Exists(Environment.CurrentDirectory & "\Crodip_updater.exe.config") Then
                    System.IO.File.Replace(Environment.CurrentDirectory & "\Crodip_updater.exe.config.arenommer", Environment.CurrentDirectory & "\Crodip_updater.exe.config", Environment.CurrentDirectory & "\Crodip_updater.exe.old")
                Else
                    System.IO.File.Replace(Environment.CurrentDirectory & "\Crodip_updater.exe.config.arenommer", Environment.CurrentDirectory & "\Crodip_updater.exe.config", Nothing)
                End If

                pause(1000)
            End If

                bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("CSEnvironnement.Renamefiles ERR : " & ex.Message.ToString())
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function createFolders() As Boolean
        If Not System.IO.Directory.Exists(Environment.CurrentDirectory & "\tmp") Then
            System.IO.Directory.CreateDirectory(Environment.CurrentDirectory & "\tmp")
        End If
        If Not System.IO.Directory.Exists(Environment.CurrentDirectory & "\public\exports") Then
            System.IO.Directory.CreateDirectory(Environment.CurrentDirectory & "\public\exports")
        End If
    End Function
#End Region
End Class
