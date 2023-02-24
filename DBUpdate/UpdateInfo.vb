Imports System.IO
Imports Microsoft.Data.Sqlite

Public Class UpdateInfo

    Private _returnCode As Integer = 1
    Private _version As String = ""
    Private _message As String = ""
    Private _baseUrl As String = ""
    Private _files() As String
    Private _hasSql As Boolean = False

    '###########################################
    '## CONSTRUCTEUR

    Public Sub New(ByVal wsResponse)

        Dim wsResponseItem As System.Xml.XmlNode
        For Each wsResponseItem In wsResponse
            Select Case wsResponseItem.Name()
                Case "version"
                    Me._version = wsResponseItem.InnerText()
                Case "message"
                    Me._message = wsResponseItem.InnerText()
                Case "baseUrl"
                    Me._baseUrl = wsResponseItem.InnerText()
                Case "files"
                    Dim nbFiles As Integer = wsResponseItem.ChildNodes.Count
                    If nbFiles > 0 Then
                        ReDim Preserve Me._files(nbFiles - 1)
                        Dim wsFilesItem As System.Xml.XmlNode
                        Dim i As Integer = 0
                        For Each wsFilesItem In wsResponseItem.ChildNodes
                            Me._files(i) = wsFilesItem.InnerText
                            i += 1
                            If wsFilesItem.InnerText = Me._baseUrl & My.Settings.update_sql_filename Then
                                Me._hasSql = True
                            End If
                        Next
                    End If
            End Select
        Next

    End Sub

    Public Sub New()

    End Sub
    '###########################################
    '## GETTERS / SETTERS

    Public Property returnCode() As Integer
        Get
            Return _returnCode
        End Get
        Set(ByVal Value As Integer)
            _returnCode = Value
        End Set
    End Property

    Public Property version() As String
        Get
            Return _version
        End Get
        Set(ByVal Value As String)
            _version = Value
        End Set
    End Property

    Public Property message() As String
        Get
            Return _message
        End Get
        Set(ByVal Value As String)
            _message = Value
        End Set
    End Property

    Public Property baseUrl() As String
        Get
            Return _baseUrl
        End Get
        Set(ByVal Value As String)
            _baseUrl = Value
        End Set
    End Property

    Public Property files() As String()
        Get
            Return _files
        End Get
        Set(ByVal Value As String())
            _files = Value
        End Set
    End Property

    Public Property hasSql() As Boolean
        Get
            Return _hasSql
        End Get
        Set(ByVal Value As Boolean)
            _hasSql = Value
        End Set
    End Property

    '###########################################
    'Appellée par le DBUpdate.exe
    '===========================================
    Public Function majDatabase(pSqlFileName As String) As Boolean

        CSDebug.dispInfo("MajDatabase")
        Dim bReturn As Boolean
        Dim doc As New System.Xml.XmlDocument
        Dim oNode As Xml.XmlNode
        Dim MySettings1 As String = "Crodip_agent.MySettings"
        Dim MySettings2 As String = "Crodip_agent.My.MySettings"
        Dim strXPathModelMy As String = "/configuration/applicationSettings/[MYSETTINGS]"
        Dim strXPathModel As String = "/configuration/applicationSettings/[MYSETTINGS]/setting[@name='%value%']/value"
        Dim strXPathModelUser As String = "/configuration/userSettings/[MYSETTINGS]/setting[@name='%value%']/value"
        Dim strXpath As String
        Dim dbName As String
        Dim dbExtension As String
        Try
            doc.Load(Environment.CurrentDirectory & "/Logiciel Crodip Agent.exe.config")

            'Test du Nom de MySettings
            strXpath = strXPathModelMy.Replace("[MYSETTINGS]", MySettings1)
            oNode = doc.SelectSingleNode(strXpath)
            If oNode Is Nothing Then
                strXpath = strXPathModelMy.Replace("[MYSETTINGS]", MySettings2)
                oNode = doc.SelectSingleNode(strXpath)
                If oNode Is Nothing Then
                    Return False
                Else
                    'On Utilise le modèle 2
                    strXPathModel = strXPathModel.Replace("[MYSETTINGS]", MySettings2)
                    strXPathModelUser = strXPathModelUser.Replace("[MYSETTINGS]", MySettings2)

                End If
            Else
                'On Utilise le modèle 1
                strXPathModel = strXPathModel.Replace("[MYSETTINGS]", MySettings1)
                strXPathModelUser = strXPathModelUser.Replace("[MYSETTINGS]", MySettings1)
            End If

            strXpath = strXPathModel.Replace("%value%", "DB")
            oNode = doc.SelectSingleNode(strXpath)
            dbName = oNode.InnerText()

            strXpath = strXPathModel.Replace("%value%", "DBExtension")
            oNode = doc.SelectSingleNode(strXpath)
            dbExtension = oNode.InnerText()


            Dim streamReader As New StreamReader(pSqlFileName)
            Dim ligne As String


            ligne = streamReader.ReadLine
            bReturn = True
            While Not ligne Is Nothing And bReturn


                If Not ligne = "" And Not ligne.StartsWith("--") Then
                    Try
                        Dim _dbConnection As SqliteConnection
                        Dim oCmd As SqliteCommand
                        _dbConnection = New Microsoft.Data.Sqlite.SqliteConnection()
                        Dim oBuider As New Microsoft.Data.Sqlite.SqliteConnectionStringBuilder()
                        oBuider.DataSource = "bdd/" & dbName & dbExtension
                        oBuider.Pooling = True
                        _dbConnection.ConnectionString = oBuider.ConnectionString
                        CSDebug.dispInfo("UpdateInfo.MajDatabase SQL : (" & _dbConnection.ConnectionString & ")" & ligne)
                        _dbConnection.Open()
                        oCmd = _dbConnection.CreateCommand()
                        oCmd.CommandText = ligne
                        oCmd.ExecuteNonQuery()
                        'oReader = db.getResults(ligne)
                        'If oReader Is Nothing Then
                        '    CSDebug.dispInfo("UpdateInfo.MajDatabase ERROR : oReader is nothing")
                        '    Throw New Exception("SQLError on :" & ligne)
                        'Else
                        '    CSDebug.dispInfo("UpdateInfo.MajDatabase OK : ")
                        'End If
                        _dbConnection.Close()
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispError("UpdateInfo.MajDatabase  ERROR : ", ex)
                        bReturn = False
                    End Try
                End If
                ligne = streamReader.ReadLine
            End While
            streamReader.Close()
        Catch ex As Exception
            CSDebug.dispFatal("UpdateInfo.MajDatabase(" & pSqlFileName & ") Erreur : ", ex)
            bReturn = False

        End Try
        Return bReturn
    End Function

End Class
