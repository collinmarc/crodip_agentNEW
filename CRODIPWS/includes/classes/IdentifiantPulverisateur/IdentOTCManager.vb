Imports System.Data.Common

Public Class IdentifiantOTCManager
    Public Shared Function exists(ByVal pIdentOTC As String) As Boolean
        Dim bReturn As Boolean

        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            Dim nIdent As Integer = dbLink.getValue("SELECT Count(*) From IdentifiantOTC where IdentifiantOTC.IdentOTC = '" & pIdentOTC & "'")
            '## Execution de la requete
            dbLink.free()
            bReturn = nIdent > 0
        Catch ex As Exception
            CSDebug.dispError("IdentOTCManager::exists() : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function SaveList(pList As List(Of IdentifiantOTC)) As Boolean
        Dim bReturn As Boolean

        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            Using otransaction As DbTransaction = dbLink.getConnection().BeginTransaction()

                Dim strSQL As String = "INSERT INTO IdentifiantOTC VALUES($value) "
                Dim oCmd As DbCommand
                oCmd = dbLink.getConnection().CreateCommand()
                oCmd.CommandText = strSQL
                Dim oParam As DbParameter = oCmd.CreateParameter()
                oParam.ParameterName = "$value"
                oCmd.Parameters.Add(oParam)



                For Each oIdentOC As IdentifiantOTC In pList
                    oParam.Value = oIdentOC.IdentOTC
                    oCmd.ExecuteNonQuery()
                Next

                otransaction.Commit()
            End Using
            dbLink.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("IdentOTCManager::SaveList() : ", ex)
            bReturn = False
        End Try
        Return bReturn

    End Function

End Class
