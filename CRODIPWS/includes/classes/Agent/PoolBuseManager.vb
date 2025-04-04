Imports System.Data.Common
Imports System.IO
Imports System.Linq
Imports System.Xml.Serialization

Public Class PoolBuseManager
    Inherits RootManager
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As PoolBuse
        Dim oreturn As PoolBuse
        oreturn = RootWSGetById(Of PoolBuse)(p_uid, paid)
        Return oreturn
    End Function


    Public Shared Function WSSend(ByVal pAgentIn As PoolBuse, ByRef pReturn As PoolBuse) As Integer
        Dim codeResponse As Integer = 99
        codeResponse = RootWSSend(Of PoolBuse)(pAgentIn, pReturn)
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
    Public Shared Function GetByuid(puid As Integer) As PoolBuse
        Dim oReturn As PoolBuse

        oReturn = getByKey(Of PoolBuse)("Select * from PoolBuse where uid = " & puid)
        Return oReturn
    End Function
    Public Shared Function getListebyStructure(puidStructure As Integer) As List(Of PoolBuse)
        Dim lstReturn As List(Of PoolBuse)

        lstReturn = getListe(Of PoolBuse)("SELECT * FROM POOLBUSE WHERE isSupprime=0 and uidStructure=" & puidStructure)

        Return lstReturn
    End Function
    Public Shared Function Save(ByVal pObj As PoolBuse, Optional bSynchro As Boolean = False) As Boolean

        Dim bReturn As Boolean

        Try
            bReturn = False
            create("PoolBuse", pObj.uid)


            Dim paramsQuery As String
            paramsQuery = ""

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pObj.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            paramsQuery = paramsQuery & " uidpool=" & pObj.uidpool
            paramsQuery = paramsQuery & " ,namepool='" & pObj.namepool & "'"
            paramsQuery = paramsQuery & " ,uidbuse=" & pObj.uidbuse
            paramsQuery = paramsQuery & " ,idBuse='" & pObj.idBuse & "'"
            paramsQuery = paramsQuery & " ,uidstructure=" & pObj.uidstructure
            paramsQuery = paramsQuery & " ,dateAssociation='" & CSDate.ToCRODIPString(pObj.dateAssociation) & "'"
            paramsQuery = paramsQuery & " , isSupprime=" & pObj.isSupprime & ""

            bReturn = Update("PoolBuse", pObj, paramsQuery)
        Catch ex As Exception
            CSDebug.dispFatal("PoolBuseManager.save ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
