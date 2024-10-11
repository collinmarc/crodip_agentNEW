Imports System.Collections.Generic
Imports System.Data.Common
Imports System.IO
Imports System.Xml.Serialization
'Imports System.Text.Json.Serialization
'Imports System.Threading.Tasks
'Imports RestSharp
'Imports RestSharp.Authenticators
Public Class RootManager
    'Protected Shared BaseUrl As String = "https://admin-pp.crodip.net"
    Protected Shared Function getWSByKey(Of T As root)(puid As Integer, paid As String) As T
        Dim oreturn As T = Nothing
        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
        Try
            Dim tXmlnodes As Xml.XmlNode()
            '' déclarations
            Dim typeT As Type = GetType(T)
            Dim nomMethode As String = "Get" & typeT.Name
            Dim methode = objWSCrodip.GetType().GetMethod(nomMethode)
            Dim codeResponse As Integer = 99 'Mehode non trouvée
            If methode IsNot Nothing Then
                Dim Params As Object() = {puid, paid, tXmlnodes}
                codeResponse = methode.Invoke(objWSCrodip, Params)
                tXmlnodes = Params(2)
            End If
            Select Case codeResponse
                Case 0 ' OK
                    Dim ser As New XmlSerializer(GetType(T))
                    Using reader As New StringReader(tXmlnodes(0).ParentNode.OuterXml)
                        oreturn = ser.Deserialize(reader)
                    End Using
                Case 1 ' NOK
                    CSDebug.dispError("getWSByKey - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("getWSByKey - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("RootManager - getWSbyKey : ", ex)
        Finally
        End Try
        Return oreturn


    End Function
    Protected Shared Function SendWS(Of T As root)(pobj As T, ByRef pobjreturn As T) As Integer
        Dim oreturn As T = Nothing
        Dim codeResponse As Integer = 99
        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
        Try
            Dim pInfo As String = ""
            Dim puid As Integer

            'Determination du Nom de la méthode : exemple SendManometreControle
            Dim typeT As Type = GetType(T)
            Dim nomMethode As String = "Send" & typeT.Name
            Dim methode = objWSCrodip.GetType().GetMethod(nomMethode)
            If methode IsNot Nothing Then
                'Invocation de la méthode
                Dim serializer As New XmlSerializer(pobj.GetType())
                Using writer As New StringWriter()
                    serializer.Serialize(writer, pobj)
                    Dim xmlOutput As String = writer.ToString()
                    ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
                    CSDebug.dispTrace("WS-" & nomMethode & " Param = [" & xmlOutput & "]")
                End Using

                Dim Params As Object() = {pobj, pInfo, puid}
                codeResponse = methode.Invoke(objWSCrodip, Params)
                pInfo = DirectCast(Params(1), String)
                puid = DirectCast(Params(2), Integer)
                CSDebug.dispTrace("WS-" & nomMethode & " Return = codeReponse=" & codeResponse & "[ info=" & pInfo & ",uid=" & puid & "]")
            End If
            Select Case codeResponse
                Case 2 ' UPDATE OK
                    pobjreturn = getWSByKey(Of T)(CType(pobj, root).uid, CType(pobj, root).aid)
                Case 4 ' CREATE OK
                    pobjreturn = getWSByKey(Of T)(puid, "")
                Case 1 ' NOK
                    CSDebug.dispError("SendWS - Code 1 : Erreur Base de données Serveur")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("SendWS - Code 9 : Mauvaise Requete")
                Case 0 ' PAS DE MAJ
            End Select
        Catch ex As Exception
            CSDebug.dispError("RootManager - sendWS : ", ex)
        Finally
        End Try
        Return codeResponse


    End Function
    Protected Shared Function getByKey(Of T As {root, New})(pSQL As String) As T
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
            CSDebug.dispError("RootManager.getByKey ERR", ex)
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

    'Protected Shared Async Function executePost(Of T)(pClient As RestClient, prequest As RestRequest) As Task(Of RestResponse(Of T))
    '    'Pourquoi mettre ConfigureAwait(False) : 
    '    'https://stackoverflow.com/questions/37129427/api-request-waitingforactivation-not-yet-computed-error
    '    'https://docs.microsoft.com/en-us/archive/msdn-magazine/2015/november/asynchronous-programming-async-from-the-start
    '    Dim r As RestResponse(Of T) = Await pClient.ExecutePostAsync(Of T)(prequest).ConfigureAwait(False)
    '    Return r
    'End Function
    'Protected Shared Async Function executeGet(Of T)(pClient As RestClient, prequest As RestRequest) As Task(Of RestResponse(Of T))
    '    Dim r As RestResponse(Of T) = Await pClient.ExecuteGetAsync(Of T)(prequest).ConfigureAwait(False)
    '    Return r
    'End Function


End Class

