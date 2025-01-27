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

            oReturn = getByKey(Of Pool)("SELECT * FROM Pool WHERE uid= " & puid & "")


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

            oReturn = getByKey(Of Pool)("SELECT * FROM Pool WHERE idPool= '" & pIdPool & "'")

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
            bddCommande.CommandText = "insert into Pool (uid, idPool) VALUES(" & pPool.uid & ",'" & pPool.aid & "' )"
            bddCommande.ExecuteNonQuery()
        Catch ex As Exception
            CSDebug.dispError("PoolManager.createPool ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function Save(pPool As Pool, Optional pSynhcro As Boolean = False) As Boolean
        Debug.Assert(pPool IsNot Nothing, "pPool doit être initialisé")
        Debug.Assert(Not String.IsNullOrEmpty(pPool.idCrodip), "idCrodip doit être initialisé")
        Dim bReturn As Boolean = True
        Dim oParam As DbParameter
        Try

            Dim oCSDB As New CSDb(True)
            Dim n As Integer = oCSDB.getValue("SELECT Count(*) from POOL Where uid = " & pPool.uid & "")
            If n = 0 Then
                createPool(oCSDB, pPool)
            End If
            Dim oCmd As DbCommand = oCSDB.getConnection().CreateCommand
            oCmd.CommandText =
"UPDATE POOL
   SET 
       uidstructure =@uidstructure,
       uidbanc = @uidbanc,
       aidbanc = @aidbanc,
       libelle = @libelle,
       etat = @etat,
       agentSuppression = @agentSuppression,
       raisonSuppression = @raisonSuppression,
       dateSuppression = @dateSuppression,
       isSupprime = @isSupprime,
       dateModificationAgent = @dateModificationAgent,
       dateModificationCrodip = @dateModificationCrodip,
       nbPastillesVertes = @nbPastillesVertes

 WHERE uid = @uid
"
            If pSynhcro Then
                pPool.dateModificationAgent = pPool.dateModificationCrodip
            Else
                pPool.dateModificationAgent = Now()
            End If

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@uid"
                .DbType = DbType.String
                .Value = pPool.uid
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@uidstructure"
                .DbType = DbType.Int32
                If pPool.uidStructure > 0 Then
                    .Value = pPool.uidStructure
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@uidbanc"
                .DbType = DbType.String
                If pPool.uidbanc > 0 Then
                    .Value = pPool.uidbanc
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@aidbanc"
                .DbType = DbType.String
                If Not String.IsNullOrEmpty(pPool.aidbanc) Then
                    .Value = pPool.aidbanc
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@libelle"
                .DbType = DbType.String
                If Not String.IsNullOrEmpty(pPool.libelle) Then
                    .Value = pPool.libelle
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@etat"
                .DbType = DbType.Boolean
                .Value = pPool.etat
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@agentSuppression"
                .DbType = DbType.String
                If Not String.IsNullOrEmpty(pPool.agentSuppression) Then
                    .Value = pPool.agentSuppression
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@raisonSuppression"
                .DbType = DbType.String
                If Not String.IsNullOrEmpty(pPool.agentSuppression) Then
                    .Value = pPool.raisonSuppression
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@dateSuppression"
                .DbType = DbType.DateTime
                If Not String.IsNullOrEmpty(pPool.dateSuppression) Then
                    .Value = CSDate.ToCRODIPString(pPool.dateSuppression)
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@isSupprime"
                .DbType = DbType.Boolean
                .Value = pPool.isSupprime()
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@dateModificationAgent"
                .DbType = DbType.DateTime
                .Value = pPool.dateModificationAgent
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@dateModificationCrodip"
                .DbType = DbType.DateTime
                .Value = pPool.dateModificationCrodip
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@dateActivation"
                .DbType = DbType.DateTime
                .Value = pPool.dateActivation
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@nbPastillesVertes"
                .DbType = DbType.Int32
                .Value = pPool.nbPastillesVertes
            End With
            oCmd.Parameters.Add(oParam)

            oCmd.ExecuteNonQuery()
            oCSDB.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("PoolManager.Save ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Overloads Shared Function GetListe(pidStructure As Integer) As List(Of Pool)
        Debug.Assert(pidStructure > 0, "IdStructure doit être initialisé")
        Dim oList As New List(Of Pool)
        Try
            oList = getListe(Of Pool)("SELECT* FROM POOL WHERE idStructure = " & pidStructure)

        Catch ex As Exception
            CSDebug.dispError("PoolManager.GetListe ERR", ex)
            oList = New List(Of Pool)()
        End Try
        Return oList

    End Function


End Class


