Imports System.Data.Common
Imports System.IO
Imports System.Linq
Imports System.Xml.Serialization

Public Class PoolAgentManager
    Inherits RootManager
#Region "Methodes WebServices"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As PoolAgent
        Dim oreturn As PoolAgent
        oreturn = RootWSGetById(Of PoolAgent)(p_uid, paid)
        Return oreturn
    End Function


    Public Shared Function WSSend(ByVal pAgentIn As PoolAgent, ByRef pReturn As PoolAgent) As Integer
        Dim codeResponse As Integer = 99
        codeResponse = RootWSSend(Of PoolAgent)(pAgentIn, pReturn)
        Select Case codeResponse
            Case 2 ' UPDATE OK
            Case 4 ' CREATE OK
            Case 1 ' NOK
                CSDebug.dispError("SendWS - Code 1 : Erreur Base de donn�es Serveur")
            Case 9 ' BADREQUEST
                CSDebug.dispError("SendWS - Code 9 : Mauvaise Requete")
            Case 0 ' PAS DE MAJ
        End Select
        Return codeResponse
    End Function
    Public Shared Function WSgetListeByAgent(ByVal pAgent As Agent) As List(Of PoolAgent)
        Dim oreturn As List(Of PoolAgent) = New List(Of PoolAgent)
        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
        Dim strXml As String = ""
        Try
            Dim tXmlnodes As Object = Nothing
            '' d�clarations
            '            Dim typeT As Type = GetType(T)
            Dim nomMethode As String = "GetPoolAgentList"
            Dim methode = objWSCrodip.GetType().GetMethod(nomMethode)
            Dim codeResponse As Integer = 99 'Mehode non trouv�e
            If methode IsNot Nothing Then
                Dim Params As Object() = {pAgent.uid, pAgent.aid, pAgent.uidstructure, tXmlnodes}
                SynchronisationManager.LogSynchroDebut(nomMethode)
                SynchronisationManager.LogSynchrodEMANDE(Params, nomMethode)
                codeResponse = methode.Invoke(objWSCrodip, Params)
                tXmlnodes = Params(2)
                SynchronisationManager.LogSynchroREPONSE(tXmlnodes, nomMethode)
                SynchronisationManager.LogSynchroFin()
            End If
            Select Case codeResponse
                Case 0 ' OK
                    Dim ser As New XmlSerializer(GetType(PoolAgent))
                    strXml = tXmlnodes(0).ParentNode.OuterXml
                    Using reader As New StringReader(strXml)
                        oreturn = ser.Deserialize(reader)
                    End Using
                Case 1 ' NOK
                    CSDebug.dispError("RootWSgetByID - Code 1 : Non-Trouv�e")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("RootWSgetByID - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("PoolAgentManager.WSGestListByAgent ERR: ", ex)
            If Not String.IsNullOrEmpty(strXml) Then
                CSDebug.dispError("PoolAgentManager - strxml :" & strXml)
            End If
        Finally
        End Try
        Return oreturn
    End Function
#End Region

    Public Shared Function GetByuid(puid As Integer) As PoolAgent
        Dim oReturn As PoolAgent

        oReturn = getByKey(Of PoolAgent)("Select * from PoolAgent where uid = " & puid)
        Return oReturn
    End Function
    Public Shared Function Save(ByVal pObj As PoolAgent, Optional bSynchro As Boolean = False) As Boolean

        Dim bReturn As Boolean

        Try
            bReturn = False
            create("PoolAgent", pObj.uid)


            Dim paramsQuery As String
            paramsQuery = ""

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pObj.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            paramsQuery = paramsQuery & " uidpool=" & pObj.uidpool
            paramsQuery = paramsQuery & " ,namepool='" & pObj.namepool & "'"
            paramsQuery = paramsQuery & " ,uidagent=" & pObj.uidagent
            paramsQuery = paramsQuery & " ,aidagent='" & pObj.aidagent & "'"
            paramsQuery = paramsQuery & " ,uidstructure=" & pObj.uidstructure
            paramsQuery = paramsQuery & " ,dateAssociation='" & CSDate.ToCRODIPString(pObj.dateAssociation) & "'"
            paramsQuery = paramsQuery & " , isSupprime=" & pObj.isSupprime & ""

            bReturn = Update("PoolAgent", pObj, paramsQuery)
        Catch ex As Exception
            CSDebug.dispFatal("PoolAgentManager.save ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Overloads Shared Function getListe(pAgent As Agent, Optional pTous As Boolean = False) As List(Of Pool)
        Dim lstReturn As New List(Of Pool)
        Try
            Dim sql As String
            sql = "SELECT * FROM PoolAgent where uidAgent = " & pAgent.uid
            If Not pTous Then
                sql = sql & " and isSupprime=False "
            End If
            Dim lstPoolAgent As List(Of PoolAgent)
            lstPoolAgent = getListe(Of PoolAgent)(sql)
            For Each oPoolAgent As PoolAgent In lstPoolAgent
                Dim oPool As Pool
                oPool = PoolManager.getPoolByuid(oPoolAgent.uidpool)
                lstReturn.Add(oPool)
            Next
        Catch ex As Exception
            CSDebug.dispError("PoolAgentManager.GetListe ERR", ex)
            lstReturn.Clear()
        End Try
        Return lstReturn
    End Function


End Class
