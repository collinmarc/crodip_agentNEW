Public Class CSDb
    Public Shared Function query(ByVal queryString As String)

        Dim bddCommande As New OleDb.OleDbCommand
        ' On test si la connexion est déjà ouverte ou non
        If bddConnection.State() = 0 Then
            ' Si non, on la configure et on l'ouvre
            bddConnection.ConnectionString = bddConnectString
            bddConnection.Open()
        End If
        bddCommande.Connection = bddConnection

        ' Execution du query
        bddCommande.CommandText = queryString

        ' On récupère les résultats
        Dim dataResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader

        ' Test pour fermeture de connection BDD
        If bddConnection.State() <> 0 Then
            ' On ferme la connexion
            bddConnection.Close()
        End If

        Return dataResults

    End Function
End Class
