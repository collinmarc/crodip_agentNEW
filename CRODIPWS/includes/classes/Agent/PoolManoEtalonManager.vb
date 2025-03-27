Imports System.Data.Common
Imports System.IO
Imports System.Linq
Imports System.Xml.Serialization

Public Class PoolManoEtalonManager
    Inherits RootManager
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As PoolManoEtalon
        Dim oreturn As PoolManoEtalon
        oreturn = RootWSGetById(Of PoolManoEtalon)(p_uid, paid)
        Return oreturn
    End Function


    Public Shared Function WSSend(ByVal pAgentIn As PoolManoEtalon, ByRef pReturn As PoolManoEtalon) As Integer
        Dim codeResponse As Integer = 99
        codeResponse = RootWSSend(Of PoolManoEtalon)(pAgentIn, pReturn)
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
    Public Shared Function GetByuid(puid As Integer) As PoolManoEtalon
        Dim oReturn As PoolManoEtalon

        oReturn = getByKey(Of PoolManoEtalon)("Select * from PoolManoEtalon where uid = " & puid)
        Return oReturn
    End Function
    Public Shared Function Save(ByVal pObj As PoolManoEtalon, Optional bSynchro As Boolean = False) As Boolean

        Dim bReturn As Boolean

        Try
            bReturn = False
            create("PoolManoEtalon", pObj.uid)


            Dim paramsQuery As String
            paramsQuery = ""

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pObj.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            paramsQuery = paramsQuery & " uidpool=" & pObj.uidpool
            paramsQuery = paramsQuery & " ,namepool='" & pObj.namepool & "'"
            paramsQuery = paramsQuery & " ,uidmanoe=" & pObj.uidmanoe
            paramsQuery = paramsQuery & " ,idManometre='" & pObj.idManometre & "'"
            paramsQuery = paramsQuery & " ,uidstructure=" & pObj.uidstructure
            paramsQuery = paramsQuery & " ,dateAssociation='" & CSDate.ToCRODIPString(pObj.dateAssociation) & "'"
            paramsQuery = paramsQuery & " , isSupprime=" & pObj.isSupprime & ""

            bReturn = Update("PoolManoEtalon", pObj, paramsQuery)
        Catch ex As Exception
            CSDebug.dispFatal("PoolManoEtalonManager.save ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
