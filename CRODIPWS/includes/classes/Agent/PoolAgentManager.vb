Imports System.Data.Common
Imports System.IO
Imports System.Linq
Imports System.Xml.Serialization

Public Class PoolAgentManager
    Inherits RootManager
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
                CSDebug.dispError("SendWS - Code 1 : Erreur Base de données Serveur")
            Case 9 ' BADREQUEST
                CSDebug.dispError("SendWS - Code 9 : Mauvaise Requete")
            Case 0 ' PAS DE MAJ
        End Select
        Return codeResponse
    End Function
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
            paramsQuery = paramsQuery & " ,aidagent='" & pObj.uidagent & "'"
            paramsQuery = paramsQuery & " ,uidstructure=" & pObj.uidstructure
            paramsQuery = paramsQuery & " ,dateAssociation='" & CSDate.ToCRODIPString(pObj.dateAssociation) & "'"

            bReturn = Update("PoolAgent", pObj, paramsQuery)
        Catch ex As Exception
            CSDebug.dispFatal("PoolAgentManager.save ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
