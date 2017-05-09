Module LogsManager

#Region "Methodes Web Service"

    Public Function sendWSLogs(ByVal logs As Logs)
        'Try
        '    ' Appel au Web Service
        '    Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()

        '    logs.dateLog = CSDate.access2mysql(CType(logs.dateLog, String))

        '    Return objWSCrodip.SendLogs(logs)
        'Catch ex As Exception
        '    CSDebug.dispFatal("LogsManager - sendWSLogs : " & ex.Message)
        '    Return -1
        'End Try
    End Function

#End Region

#Region "Methodes Locales"

    Public Function deleteLogs(ByVal log As Logs)

        Try

            Dim bdd As New CSDb(True)
            bdd.getResults("DELETE FROM `Logs` WHERE `Logs`.`id`=" & log.id & "")
            bdd.free()

        Catch ex As Exception
            CSDebug.dispFatal("LogsManager - deletLogs : " & ex.Message)
        End Try

    End Function

    Public Function getUpdates()

        '' Déclarations
        'Dim arrItems(0) As Logs
        'Dim bddCommande As New OleDb.OleDbCommand
        '' On test si la connexion est déjà ouverte ou non
        'If bddConnection.State() = 0 Then
        '    ' Si non, on la configure et on l'ouvre
        '    bddConnection.ConnectionString = bddConnectString
        '    bddConnection.Open()
        'End If
        'bddCommande.Connection = bddConnection
        'bddCommande.CommandText = "SELECT * FROM `Logs`"

        'Try

        '    ' On récupère les résultats
        '    Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
        '    Dim i As Integer = 0
        '    ' Puis on les parcours
        '    While tmpListProfils.Read()

        '        ' On rempli notre tableau
        '        Dim tmpLogs As New Logs
        '        Dim tmpColId As Integer = 0
        '        While tmpColId < tmpListProfils.FieldCount()
        '            Select Case tmpListProfils.GetName(tmpColId)
        '                Case "id"
        '                    tmpLogs.id = tmpListProfils.Item(tmpColId).ToString()
        '                Case "type"
        '                    tmpLogs.type = tmpListProfils.Item(tmpColId).ToString()
        '                Case "idInspecteur"
        '                    tmpLogs.idInspecteur = tmpListProfils.Item(tmpColId).ToString()
        '                Case "date"
        '                    tmpLogs.dateLog = tmpListProfils.Item(tmpColId).ToString()
        '                Case "message"
        '                    tmpLogs.message = tmpListProfils.Item(tmpColId).ToString()
        '            End Select
        '            tmpColId = tmpColId + 1
        '        End While
        '        arrItems(i) = tmpLogs
        '        i = i + 1
        '        ReDim Preserve arrItems(i)
        '    End While
        '    ReDim Preserve arrItems(i - 1)

        'Catch ex As Exception
        '    CSDebug.dispFatal("LogsManager - getUpdates : " & ex.Message)
        'End Try

        '' Test pour fermeture de connection BDD
        'If bddConnection.State() <> 0 Then
        '    ' On ferme la connexion
        '    bddConnection.Close()
        'End If

        'Return arrItems

    End Function

#End Region

End Module