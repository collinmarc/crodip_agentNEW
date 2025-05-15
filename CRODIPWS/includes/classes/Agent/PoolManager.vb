Imports System.Data.Common
Imports System.Collections.Generic
'Imports RestSharp
'Imports RestSharp.Authenticators
Imports System.Threading.Tasks
'Imports System.Text.Json.Serialization

Public Class PoolManager
    Inherits RootManager
#Region "WebServices"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As Pool
        Dim oreturn As Pool
        oreturn = RootWSGetById(Of Pool)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pObjIn As Pool, ByRef pobjOut As Pool) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of Pool)(pObjIn, pobjOut)

        Catch ex As Exception
            CSDebug.dispFatal("PoolManager.WSSend : ", ex)
            nreturn = -1
        End Try
        Return nreturn
    End Function

#End Region
    Public Shared Function getPoolByuid(puid As Integer) As Pool
        Debug.Assert(puid > 0, "puid doit être initialisé")
        Dim oReturn As Pool = Nothing
        Try

            oReturn = getBySQL(Of Pool)("SELECT * FROM Pool WHERE uid= " & puid & "")


        Catch ex As Exception
            CSDebug.dispError("PoolManager.getPoolByuid ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
    Public Shared Function getPoolByIdPool(pIdPool As String) As Pool
        Debug.Assert(Not String.IsNullOrEmpty(pIdPool), "idPool doit être initialisé")
        Dim oReturn As Pool = Nothing
        Try

            oReturn = getBySQL(Of Pool)("SELECT * FROM Pool WHERE idPool= '" & pIdPool & "'")

        Catch ex As Exception
            CSDebug.dispError("PoolManager.getPoolByIdPool ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
    Private Shared Function createPool(pCSDB As CSDb, pPool As Pool) As Boolean
        Debug.Assert(pPool IsNot Nothing, "pPool doit être initialisé")
        Debug.Assert(pCSDB IsNot Nothing, "pCSDB doit être initialisé")
        Debug.Assert(pCSDB.isOpen(), "pCSDB doit être ouverte")
        Dim bReturn As Boolean = True

        Try
            Dim bddCommande As DbCommand = pCSDB.getConnection().CreateCommand
            bddCommande.CommandText = "insert into Pool (uid, idPool) VALUES(" & pPool.uid & ",'" & pPool.idPool & "' )"
            bddCommande.ExecuteNonQuery()
        Catch ex As Exception
            CSDebug.dispError("PoolManager.createPool ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function Save(pObj As Pool, Optional pSynchro As Boolean = False) As Boolean
        Dim bReturn As Boolean

        Try
            bReturn = False
            create("Pool", pObj.uid)


            Dim paramsQuery As String
            paramsQuery = ""

            ' Mise a jour de la date de derniere modification
            If Not pSynchro Then
                pObj.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            paramsQuery = paramsQuery & " idpool='" & pObj.idPool & "'"
            paramsQuery = paramsQuery & " ,uidstructure=" & pObj.uidstructure & ""
            paramsQuery = paramsQuery & " ,uidbanc=" & pObj.uidbanc
            paramsQuery = paramsQuery & " ,aidBanc='" & pObj.aidbanc & "'"
            paramsQuery = paramsQuery & " ,libelle='" & pObj.libelle & "'"
            paramsQuery = paramsQuery & " ,etat=" & pObj.etat & ""
            paramsQuery = paramsQuery & " ,agentSuppression='" & pObj.agentSuppression & "'"
            paramsQuery = paramsQuery & " ,raisonSuppression='" & pObj.raisonSuppression & "'"
            paramsQuery = paramsQuery & " ,dateSuppression='" & CSDate.ToCRODIPString(pObj.dateSuppression) & "'"
            paramsQuery = paramsQuery & " , isSupprime=" & pObj.isSupprime & ""

            bReturn = Update("Pool", pObj, paramsQuery)

        Catch ex As Exception
            CSDebug.dispFatal("PoolManager.save ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Overloads Shared Function GetListe(pidStructure As Integer) As List(Of Pool)
        Debug.Assert(pidStructure > 0, "IdStructure doit être initialisé")
        Dim oList As New List(Of Pool)
        Try
            oList = getListe(Of Pool)("SELECT* FROM POOL WHERE uidStructure = " & pidStructure)

        Catch ex As Exception
            CSDebug.dispError("PoolManager.GetListe ERR", ex)
            oList = New List(Of Pool)()
        End Try
        Return oList

    End Function


End Class


