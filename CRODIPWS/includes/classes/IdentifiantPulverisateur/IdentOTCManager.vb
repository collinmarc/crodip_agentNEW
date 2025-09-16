Imports System.Data.Common

Public Class IdentOTCManager
    Public Shared Function exists(ByVal pIdentOTC As String) As Boolean
        Dim bReturn As Boolean

        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            Dim nIdent As Integer = dbLink.getValue("SELECT Count(*) From IdentOTC where IdentOTC.IdentOTC = '" & pIdentOTC & "'")
            '## Execution de la requete
            dbLink.free()
            bReturn = nIdent > 0
        Catch ex As Exception
            CSDebug.dispFatal("IdentOTCManager::exists() : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
