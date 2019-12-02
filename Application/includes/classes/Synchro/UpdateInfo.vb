Imports System.IO
Imports System.Net

Public Class UpdateInfo

    Private _returnCode As Integer = 1
    Private _version As String = ""
    Private _message As String = ""
    Private _baseUrl As String = ""
    Private _files() As String
    Private _hasSql As Boolean = False

    '###########################################
    '## CONSTRUCTEUR

    Public Sub New(ByVal wsResponse As Object)

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
    Private _Contenu As String
    Public Property Contenu() As String
        Get
            Return _Contenu
        End Get
        Set(ByVal value As String)
            _Contenu = value
        End Set
    End Property

    Public Function DoDownload(pfileUrl As String) As Boolean
        Dim bReturn As Boolean
        Try
            ' Récupération du fichier sous forme de tableau de bytes
            Dim returnArray() As Byte
            bReturn = False
            For nEssai As Integer = 1 To 100
                returnArray = GetURLDataBin(pfileUrl)
                If returnArray.Length > 0 Then
                    'Traduction en String  
                    Contenu = System.Text.Encoding.UTF8.GetString(returnArray)
                    bReturn = True
                    nEssai = 100 + 1
                Else
                    CSDebug.dispWarn("UpdateInfo.doDownLoad ERR: 0 Bytes download for " & pfileUrl & " Retry " & nEssai)
                End If
            Next nEssai
            If Not bReturn Then
                CSDebug.dispError("UpdateInfo.doDownLoad ERR: Impossible de télécharger " & pfileUrl)
            End If
        Catch ex As Exception
            CSDebug.dispError("UpdateInfo.DoDownLoad Err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function GetURLDataBin(ByVal URL As String) As Byte()
        Dim Req As HttpWebRequest
        Dim SourceStream As System.IO.Stream = Nothing
        Dim Response As HttpWebResponse = Nothing
        Dim tabReturn As Byte()

        Try
            ' Création de la requete HTTP
            Req = HttpWebRequest.Create(URL)

            '###########################################################

            '' Set username and password if required
            'If Len(UserName) > 0 Then
            '    Req.Credentials = New NetworkCredential("root", "mmanasek")
            'End If

            ' Récupération de la réponse
            Response = Req.GetResponse()

            'Source stream with requested document
            SourceStream = Response.GetResponseStream()

            'SourceStream has no ReadAll, so we must read data block-by-block
            'Temporary Buffer and block size
            Dim Buffer(4096) As Byte, BlockSize As Integer

            'Memory stream to store data
            Using TempStream As New MemoryStream
                Do
                    BlockSize = SourceStream.Read(Buffer, 0, 4096)
                    If BlockSize > 0 Then
                        TempStream.Write(Buffer, 0, BlockSize)
                    End If
                Loop While BlockSize > 0
                tabReturn = TempStream.ToArray()
            End Using
        Catch ex As Exception
            CSDebug.dispError("UpdateInfo.GetUrlDataBin : Une erreur est survenue [" & ex.Message & "] durant le téléchargement du fichier suivant :" & URL)
            Dim errStream As New MemoryStream
            tabReturn = errStream.ToArray()
        Finally
            Try
                If SourceStream IsNot Nothing Then
                    SourceStream.Close()
                End If
            Catch ex As Exception
            End Try
            Try
                Response.Close()
            Catch ex As Exception
            End Try
        End Try

        Return tabReturn
    End Function


End Class
