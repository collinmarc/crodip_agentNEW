Imports System.Data.Common
Imports System.Collections.Generic
Imports RestSharp
Imports RestSharp.Authenticators
Imports System.Threading.Tasks
Imports System.Text.Json.Serialization

Public Class PoolManager
    Inherits RootManager

    Public Shared Function getPoolById(pId As Integer) As Pool
        Debug.Assert(pId <> 0, "ID doit être initialisé")
        Dim oReturn As Pool = Nothing
        Try

            oReturn = getById(Of Pool)("SELECT * FROM Pool WHERE id=" & pId & "")


        Catch ex As Exception
            CSDebug.dispError("PoolManager.getPoolById ERR", ex)
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
            bddCommande.CommandText = "insert into Pool (idCrodip) VALUES('" & pPool.idCrodip & "')"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "SELECT last_insert_rowid()"
            pPool.id = CInt(bddCommande.ExecuteScalar())
        Catch ex As Exception
            CSDebug.dispError("PoolManager.createPool ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function Save(pPool As Pool, Optional pSynhcro As Boolean = False) As Boolean
        Debug.Assert(pPool IsNot Nothing, "pPool doit être initialisé")
        Dim bReturn As Boolean = True
        Dim oParam As DbParameter
        Try

            Dim oCSDB As New CSDb(True)
            If pPool.id = 0 Then
                createPool(oCSDB, pPool)
            End If
            Dim oCmd As DbCommand = oCSDB.getConnection().CreateCommand
            oCmd.CommandText =
"UPDATE POOL
   SET 
       idCRODIP = @idCRODIP,
       libelle = @libelle,
       nbPastillesVertes = @nbPastillesVertes,
idStructure =@idStructure,
idBanc = @idBanc,
idPC = @idPC,
       dateModificationAgent = @dateModificationAgent,
       dateModificationCrodip = @dateModificationCrodip
 WHERE id = @id
"
            If pSynhcro Then
                pPool.dateModificationAgent = pPool.dateModificationCrodip
            Else
                pPool.dateModificationAgent = Now()
            End If

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@idCRODIP"
                .DbType = DbType.String
                .Value = pPool.idCrodip
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@libelle"
                .DbType = DbType.String
                .Value = pPool.libelle
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@nbPastillesVertes"
                .DbType = DbType.Int32
                .Value = pPool.nbPastillesVertes
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@idStructure"
                .DbType = DbType.Int32
                If pPool.idStructure > 0 Then
                    .Value = pPool.idStructure
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)

            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@idBanc"
                .DbType = DbType.String
                If Not String.IsNullOrEmpty(pPool.idBanc) Then
                    .Value = pPool.idBanc
                Else
                    .Value = DBNull.Value
                End If
            End With
            oCmd.Parameters.Add(oParam)


            oParam = oCmd.CreateParameter()
            With oParam
                .ParameterName = "@idPC"
                .DbType = DbType.Int32
                If pPool.idPC > 0 Then
                    .Value = pPool.idPC
                Else
                    .Value = DBNull.Value
                End If
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
                .ParameterName = "@id"
                .DbType = DbType.Int32
                .Value = pPool.id
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

    Public Shared Function RESTgetPoolByIDCrodip(pAgent As Agent, pidCrodip As String) As Pool
        Dim oReturn As Pool = Nothing
        Try
            oReturn = RESTgetByID(Of Pool)("getPool", pAgent, pidCrodip)
        Catch ex As Exception
            CSDebug.dispError("PoolManager.RESTgetPoolByidCrodip ERR", ex)
        End Try
        Return oReturn
    End Function

    Public Shared Function RESTgetPools(pAgent As Agent) As List(Of Pool)
        Dim oReturn As New List(Of Pool)
        Try

            oReturn = RESTgetList(Of Pool)("getPools", pAgent)
        Catch ex As Exception
            CSDebug.dispError("PoolManager.RESTgetPools ERR", ex)
        End Try
        Return oReturn
    End Function

    Public Shared Function RESTsetPool(pAgent As Agent, pPool As Pool) As Boolean
        Dim oReturn As Boolean
        Try
            oReturn = RESTset(Of Pool)("setPool", pAgent, pPool)

        Catch ex As Exception
            CSDebug.dispError("PoolManager.RESTsetPool ERR", ex)
        End Try
        Return oReturn
    End Function
End Class


