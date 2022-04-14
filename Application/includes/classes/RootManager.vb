Imports System.Collections.Generic
Imports System.Data.Common
Imports System.Text.Json.Serialization
Imports System.Threading.Tasks
Imports RestSharp
Imports RestSharp.Authenticators
Public Class LoginUserResponse
    Public Property auth As Boolean
    Public Property token As String
    Public Property message As String

End Class
Public Class setResponse
    Public Property message As String
End Class

Public Class auth
    Public Property login As String
    Public Property password As String
    Public Sub New(pLogin As String, pPassword As String)
        login = pLogin
        password = pPassword
    End Sub

End Class

Public Class getListResponse(Of T)
    ' Public Property totalItems As Long
    <JsonPropertyName("users")>
    Public Property list As List(Of T)
    '  Public Property totalPages As Long
    '   Public Property currentPage As Long
    '    Public Property numberByPage As Long

    Public Sub New()
        list = New List(Of T)()
    End Sub
End Class
Public Class RootManager
    Protected Shared _user As auth
    Protected Shared _client As RestClient
    Protected Shared BaseUrl As String = "https://api-pp.crodip.fr"
    Protected Shared _token As String
    Protected Shared _bConnecte As Boolean
    Protected Shared Function getById(Of T As {root, New})(pSQL As String) As T
        Dim oReturn As T = Nothing
        Try

            Dim oCSDB As New CSDb(True)
            Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand
            bddCommande.CommandText = pSQL
            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande.ExecuteReader
            If oDR.Read() Then
                oReturn = New T
                oReturn.FillDR(oDR)
            End If
            oDR.Close()

            If Not oCSDB Is Nothing Then
                oCSDB.free()
            End If
            'on retourne le client ou un objet vide en cas d'erreur


        Catch ex As Exception
            CSDebug.dispError("RootManager.getById ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Protected Shared Function getListe(Of T As {root, New})(pSQL As String) As List(Of T)
        Dim oList As New List(Of T)
        Try

            Dim oCSDB As New CSDb(True)
            Dim oCmd As DbCommand = oCSDB.getConnection().CreateCommand()
            oCmd.CommandText = pSQL
            Dim oDR As DbDataReader
            oDR = oCmd.ExecuteReader()
            While oDR.Read()
                Dim obj As New T()
                obj.FillDR(oDR)
                oList.Add(obj)
            End While

        Catch ex As Exception
            CSDebug.dispError("RootManager.GetListe ERR", ex)
            oList = New List(Of T)()
        End Try
        Return oList

    End Function

    Protected Shared Async Function executePost(Of T)(pClient As RestClient, prequest As RestRequest) As Task(Of RestResponse(Of T))
        'Pourquoi mettre ConfigureAwait(False) : 
        'https://stackoverflow.com/questions/37129427/api-request-waitingforactivation-not-yet-computed-error
        'https://docs.microsoft.com/en-us/archive/msdn-magazine/2015/november/asynchronous-programming-async-from-the-start
        Dim r As RestResponse(Of T) = Await pClient.ExecutePostAsync(Of T)(prequest).ConfigureAwait(False)
        Return r
    End Function
    Protected Shared Async Function executeGet(Of T)(pClient As RestClient, prequest As RestRequest) As Task(Of RestResponse(Of T))
        Dim r As RestResponse(Of T) = Await pClient.ExecuteGetAsync(Of T)(prequest).ConfigureAwait(False)
        Return r
    End Function
    Protected Shared Function RESTConnect(pAgent As Agent) As Boolean
        Return RESTconnect(pAgent.numeroNational, pAgent.motDePasse)
    End Function

    Protected Shared Function RESTconnect(puser As String, pPassword As String) As Boolean
        Dim bReturn As Boolean
        Try
            If Not _bConnecte Then
                _user = New auth(puser, pPassword)
                _client = New RestClient(BaseUrl)
                Dim request As RestRequest = New RestRequest("loginUser", DataFormat.Json)
                request.AddJsonBody(_user)
                Dim oT As Task(Of RestResponse(Of LoginUserResponse))

                oT = executePost(Of LoginUserResponse)(_client, request)
                oT.Wait()

                Dim oResponse As RestResponse(Of LoginUserResponse) = oT.Result
                _bConnecte = False
                If oResponse.ResponseStatus = ResponseStatus.Completed Then
                    bReturn = oResponse.Data.auth
                    If oResponse.Data.auth Then
                        _bConnecte = True
                        _token = oResponse.Data.auth
                    Else
                        _bConnecte = False
                    End If
                End If
            End If

        Catch ex As Exception
            CSDebug.dispError("RootManager.login ERR  : ", ex)
            bReturn = False
        End Try

        Return bReturn

    End Function

    Protected Shared Function RESTset(Of T As root)(pAPIREST As String, pAgent As Agent, pPool As T) As Boolean
        Dim oReturn As Boolean
        Dim request As RestRequest
        Try

            If RESTConnect(pAgent) Then
                request = New RestRequest("pAPIREST", DataFormat.Json)
                _client.Authenticator = New JwtAuthenticator(_token)
                request.AddJsonBody(pPool)

                Dim oT As Task(Of RestResponse(Of setResponse)) = executePost(Of setResponse)(_client, request)
                oT.Wait()

                Dim oResponse2 As RestResponse(Of setResponse) = oT.Result
                oReturn = oResponse2.Data.message = "CREATED"
            End If
        Catch ex As Exception
            CSDebug.dispError("PoolManager.RESTsetPool ERR", ex)
        End Try
        Return oReturn
    End Function
    Protected Shared Function RESTgetList(Of T)(pAPIRest As String, pAgent As Agent) As List(Of T)
        Dim oReturn As New List(Of T)
        Dim request As RestRequest
        Try

            If RESTConnect(pAgent) Then
                request = New RestRequest(pAPIRest, DataFormat.Json)
                _client.Authenticator = New JwtAuthenticator(_token)

                Dim oT2 As Task(Of RestResponse(Of getListResponse(Of T))) = executeGet(Of getListResponse(Of T))(_client, request)
                oT2.Wait()

                Dim oResponse2 As RestResponse(Of getListResponse(Of T)) = oT2.Result
                oReturn = oResponse2.Data.list
            End If
        Catch ex As Exception
            CSDebug.dispError("RootManager.RESTgetList ERR", ex)
        End Try
        Return oReturn
    End Function

    Protected Shared Function RESTgetByID(Of T)(pAPIRest As String, pAgent As Agent, pid As String) As T
        Dim oReturn As T = Nothing
        Dim request As RestRequest
        Try

            If RESTConnect(pAgent) Then
                request = New RestRequest(pAPIRest & "/" & pid, DataFormat.Json)
                request.Timeout = 10
                _client.Authenticator = New JwtAuthenticator(_token)

                Dim oT2 As Task(Of RestResponse(Of T)) = executeGet(Of T)(_client, request)
                oT2.Wait()

                Dim oResponse2 As RestResponse(Of T) = oT2.Result
                oReturn = oResponse2.Data
            End If
        Catch ex As Exception
            CSDebug.dispError("RootManager.RESTgetByid ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function


End Class

