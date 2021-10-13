#Region " Options "

Option Strict Off
Option Explicit On 

#End Region
#Region " Imports "

Imports System.Data
Imports System.Net

#End Region
Public Class CSEnvironnement
    Private Enum Protocol
        http
        https
    End Enum
#Region " Version "

    Public Shared versionMessage As String = ""
    Public Shared versionUrl As String = ""

    ' Fonction permettant de tester si la version de l'application est en accord avec la version mini. du crodip
    Public Shared Function checkVersion() As Boolean
        ' Init Vars
        Dim curVersion() As String = GlobalsCRODIP.GLOB_APPLI_VERSION.Split(".")
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

    Public Shared Sub setPid()
        Try
            CSFile.create(GlobalsCRODIP.GLOB_PID_FILE, Date.UtcNow.ToLongDateString)
        Catch ex As Exception
            CSDebug.dispFatal("CSEnvironnement::setPid : " & ex.Message)
        End Try
    End Sub
    Public Shared Sub delPid()
        Try
            If System.IO.File.Exists(GlobalsCRODIP.GLOB_PID_FILE) Then
                CSFile.delete(GlobalsCRODIP.GLOB_PID_FILE)
            End If
        Catch ex As Exception
            CSDebug.dispFatal("CSEnvironnement::delPid : " & ex.Message)
        End Try
    End Sub
    Public Shared Function existsPid() As Boolean
        Try
            Return System.IO.File.Exists(GlobalsCRODIP.GLOB_PID_FILE)
        Catch ex As Exception
            CSDebug.dispFatal("CSEnvironnement::existsPid : " & ex.Message)
            Return False
        End Try
    End Function
    Public Shared Sub forcePid()
        CSEnvironnement.delPid()
        CSEnvironnement.setPid()
    End Sub

#End Region

#Region " Connectivité "

    ' Fonction permettant de tester si on a une connexion internet
    Public Shared Function checkNetwork() As Boolean
        'Par Défaut
        'System.Net.ServicePointManager.Expect100Continue = True
        'ServicePointManager.DefaultConnectionLimit = 2
        'ServicePointManager.SecurityProtocol = 0
        System.Net.ServicePointManager.Expect100Continue = My.Settings.Expect100Continue
        'ServicePointManager.DefaultConnectionLimit = My.Settings.DefaultConnectionLimit
        '''        SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3 = 4080
        If My.Settings.SecurityProtocol <> 0 Then
            ServicePointManager.SecurityProtocol = My.Settings.SecurityProtocol
        End If
        Dim bReturn As Boolean = False
        If My.Settings.checkNetwork Then
            If checkNetwork(Protocol.https) Then
                bReturn = True
            Else
                bReturn = checkNetwork(Protocol.http)
            End If
        End If
        Return bReturn

    End Function
    Private Shared Function ChangeProtocol(pProtocol As Protocol, purl As String) As String
        Dim urlReturn As String
        ' Supresssion des procole existant
        urlReturn = purl.Replace("https://", "")
        urlReturn = urlReturn.Replace("http://", "")
        'Ajout du protocole demandé
        If pProtocol = Protocol.http Then
            urlReturn = "http://" & urlReturn
        End If
        If pProtocol = Protocol.https Then
            urlReturn = "https://" & urlReturn
        End If
        Return urlReturn
    End Function

    Private Shared Function checkNetwork(pProtocol As Protocol) As Boolean

        '--- Déclaration des variables de la fonction
        Dim requete As HttpWebRequest = Nothing
        Dim reponse As HttpWebResponse = Nothing
        Dim url As String

        url = ChangeProtocol(pProtocol, WSCrodip.URL)

        '--- Suivi des erreurs rencontrées
        Try
            requete = CType(WebRequest.Create(url), HttpWebRequest)
            reponse = CType(requete.GetResponse, HttpWebResponse)
            reponse.Close() '--- Déconnexion
            If reponse.StatusCode = HttpStatusCode.OK Then
                GlobalsCRODIP.GLOB_NETWORKAVAILABLE = True
                Return True
            Else
                If requete IsNot Nothing Then
                    requete.Abort()
                End If
                Return False
            End If
        Catch generatedExceptionVariable0 As WebException
            If requete IsNot Nothing Then
                requete.Abort()
            End If
            CSDebug.dispError(String.Format("CSEnvironnement.CheckNetwork ({0}) ERR1 : ({1})", url, generatedExceptionVariable0.Message))
            Return False
        Catch ex As Exception
            If requete IsNot Nothing Then
                requete.Abort()
            End If
            CSDebug.dispError(String.Format("CSEnvironnement.CheckNetwork2 ({0}) ERR1 : ({1})", url, ex.Message))
            Return False
        End Try

    End Function
    ' Fonction permettant de tester si le webservice est en ligne
    Public Shared Function checkWebService() As Boolean
        Dim bReturn As Boolean = False
        If checkWebService(Protocol.https) Then
            bReturn = True
        Else
            bReturn = checkWebService(Protocol.http)
        End If


        Return bReturn
    End Function
    Private Shared Function checkWebService(pProtocol As Protocol) As Boolean

        '--- Déclaration des variables de la fonction
        Dim requete As HttpWebRequest = Nothing
        Dim reponse As HttpWebResponse = Nothing
        Dim webserviceUrl As String
        Dim bReturn As Boolean = False
        Dim webservice As WSCrodip_prod.CrodipServer

        GlobalsCRODIP.GLOB_NETWORKAVAILABLE = checkNetwork()
        If GlobalsCRODIP.GLOB_NETWORKAVAILABLE Then
            webservice = WSCrodip.getWS()
            webserviceUrl = webservice.Url
            webserviceUrl = ChangeProtocol(pProtocol, webserviceUrl)
            '--- Suivi des erreurs rencontrées
            Try
                requete = CType(WebRequest.Create(webserviceUrl), HttpWebRequest)
                reponse = CType(requete.GetResponse, HttpWebResponse)
                requete.Abort() '--- Déconnexion
                If reponse.StatusCode = HttpStatusCode.OK Then
                    webservice.Url = webserviceUrl
                    bReturn = True
                Else
                    bReturn = False
                End If
            Catch generatedExceptionVariable0 As WebException
                CSDebug.dispError(String.Format("CSEnvironnement.checckWebServices({0}) ERR1 : {1}  ", webserviceUrl, generatedExceptionVariable0.Message))
                bReturn = False
            Catch ex As Exception
                CSDebug.dispError(String.Format("CSEnvironnement.checckWebServices({0}) ERR2 : {1}  ", webserviceUrl, ex.Message))
                bReturn = False
            End Try
        End If

        Return bReturn
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
    ''' <summary>
    ''' du a un bug sur W10 , les DataTimePicker doivent être reformaté 
    ''' </summary>
    ''' <param name="pDt"></param>
    Public Shared Sub checkDateTimePicker(pDt As DateTimePicker)

        If Environment.OSVersion.Version.Major = 10 Then
            If Environment.OSVersion.Version.Build < 16299 Then
                pDt.ShowUpDown = True
            End If
        End If
    End Sub

End Class
