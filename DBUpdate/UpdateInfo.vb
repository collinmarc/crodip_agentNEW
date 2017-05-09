Imports System.IO
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
        Try
            Dim streamReader As New StreamReader(pSqlFileName)
            Dim oReader As OleDb.OleDbDataReader
            Dim ligne As String
            Dim db As CSDb = New CSDb(True)


            ligne = streamReader.ReadLine
            bReturn = True
            While Not ligne Is Nothing And bReturn

                CSDebug.dispInfo(ligne)
                If ligne.StartsWith("--<TEST1>") Then
                    oReader = db.getResults("SELECT controleIsPreControleProfessionel from Diagnostic")
                    If oReader Is Nothing Then
                        'La Colonne n'existe pas, on la crée
                        ligne = ligne.Replace("--<TEST1>", "")
                    Else
                        oReader.Close()
                    End If
                End If
                If ligne.StartsWith("--<TEST2>") Then
                    oReader = db.getResults("SELECT controleIsAutoControle from Diagnostic")
                    If oReader Is Nothing Then
                        'La Colonne n'existe pas, on la crée
                        ligne = ligne.Replace("--<TEST2>", "")
                    Else
                        oReader.Close()
                    End If
                End If
                If ligne.StartsWith("--<TEST3>") Then
                    oReader = db.getResults("SELECT ProprietaireRepresentant from Diagnostic")
                    If oReader Is Nothing Then
                        'La Colonne n'existe pas, on la crée
                        ligne = ligne.Replace("--<TEST3>", "")
                    Else
                        oReader.Close()
                    End If
                End If

                If Not ligne = "" And Not ligne.StartsWith("--") Then
                    Try
                        Dim oConn As OleDb.OleDbConnection
                        Dim oCmd As OleDb.OleDbCommand
                        oConn = db.getConnection()
                        CSDebug.dispInfo("UpdateInfo.MajDatabase  DBNAme : " & oConn.ConnectionString & " " & oConn.State)
                        CSDebug.dispInfo("UpdateInfo.MajDatabase SQL : " & ligne)
                        oCmd = oConn.CreateCommand()
                        oCmd.CommandText = ligne
                        oCmd.ExecuteNonQuery()
                        'oReader = db.getResults(ligne)
                        'If oReader Is Nothing Then
                        '    CSDebug.dispInfo("UpdateInfo.MajDatabase ERROR : oReader is nothing")
                        '    Throw New Exception("SQLError on :" & ligne)
                        'Else
                        '    CSDebug.dispInfo("UpdateInfo.MajDatabase OK : ")
                        'End If
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispError("UpdateInfo.MajDatabase  ERROR : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
                ligne = streamReader.ReadLine
            End While
            streamReader.Close()
            db.free()
        Catch ex As Exception
            CSDebug.dispFatal("UpdateInfo.MajDatabase(" & pSqlFileName & ") Erreur : " & ex.Message)
            bReturn = False

        End Try
        Return bReturn
    End Function

End Class
