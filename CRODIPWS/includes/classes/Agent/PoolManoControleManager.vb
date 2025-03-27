Imports System.Data.Common
Imports System.IO
Imports System.Linq
Imports System.Xml.Serialization

Public Class PoolManoControleManager
    Inherits RootManager
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As PoolManoControle
        Dim oreturn As PoolManoControle
        oreturn = RootWSGetById(Of PoolManoControle)(p_uid, paid)
        Return oreturn
    End Function


    Public Shared Function WSSend(ByVal pAgentIn As PoolManoControle, ByRef pReturn As PoolManoControle) As Integer
        Dim codeResponse As Integer = 99
        codeResponse = RootWSSend(Of PoolManoControle)(pAgentIn, pReturn)
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
    Public Shared Function GetByuid(puid As Integer) As PoolManoControle
        Dim oReturn As PoolManoControle

        oReturn = getByKey(Of PoolManoControle)("Select * from PoolManoControle where uid = " & puid)
        Return oReturn
    End Function
    Public Shared Function Save(ByVal pObj As PoolManoControle, Optional bSynchro As Boolean = False) As Boolean

        Dim bReturn As Boolean

        Try
            bReturn = False
            create("PoolManoControle", pObj.uid)


            Dim paramsQuery As String
            paramsQuery = ""

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pObj.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            paramsQuery = paramsQuery & " uidpool=" & pObj.uidpool
            paramsQuery = paramsQuery & " ,namepool='" & pObj.namepool & "'"
            paramsQuery = paramsQuery & " ,uidmanoc=" & pObj.uidmanoc
            paramsQuery = paramsQuery & " ,idManometre='" & pObj.idManometre & "'"
            paramsQuery = paramsQuery & " ,uidstructure=" & pObj.uidstructure
            paramsQuery = paramsQuery & " ,dateAssociation='" & CSDate.ToCRODIPString(pObj.dateAssociation) & "'"
            paramsQuery = paramsQuery & " , isSupprime=" & pObj.isSupprime & ""

            bReturn = Update("PoolManoControle", pObj, paramsQuery)
        Catch ex As Exception
            CSDebug.dispFatal("PoolManoControleManager.save ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
