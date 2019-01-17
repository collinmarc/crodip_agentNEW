Module CSLocali


    Public Function getVilleByCp(ByVal codePostal As String) As String(,)
        ' Init Vars
        Dim arrResults(1, 0) As String

        Try
            ' On récupère le code postal
            Dim idCodePostal As Integer = getIdByLabel(codePostal, 6)

            ' Query
            Dim query As String = "SELECT distinct CSL_EntityIso.isoCode, CSL_EntityLabel.label FROM CSL_EntityRelation,CSL_Entity ,CSL_EntityLabel  ,CSL_EntityIso WHERE CSL_Entity.type = 4 AND CSL_Entity.id=CSL_EntityLabel.id AND CSL_Entity.id=CSL_EntityIso.id AND CSL_EntityIso.isoName = 'insee' AND CSL_EntityRelation.idOut=" & idCodePostal & " AND CSL_EntityRelation.idIn=CSL_Entity.id ORDER BY CSL_EntityLabel.label"
            'CSDebug.dispInfo(query)

            ' On récupère les résultats
            Dim bdd As New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s(query)
            Dim i As Integer = 0
            While dataResults.Read()
                arrResults(0, i) = dataResults.Item(0)
                arrResults(1, i) = dataResults.Item(1)
                ReDim Preserve arrResults(1, arrResults.GetLength(1))
                i += 1
            End While
            ReDim Preserve arrResults(1, arrResults.GetLength(1) - 2)
            bdd.free()
            bdd = Nothing
        Catch ex As Exception
            CSDebug.dispError("CSLocali::getVilleByCp() : " & ex.Message)
        End Try

        Return arrResults
    End Function

    Public Function getIdByLabel(ByVal label As String, ByVal type As Integer) As Integer
        Dim result As Integer = -1

        Try
            Dim query As String = "SELECT CSL_EntityLabel.id FROM CSL_EntityLabel LEFT JOIN CSL_Entity ON CSL_Entity.id=CSL_EntityLabel.id WHERE CSL_EntityLabel.label LIKE '" & label & "' AND CSL_Entity.type=" & type

            Dim bdd As New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s(query)
            While dataResults.Read()
                result = dataResults.Item(0)
            End While
            bdd.free()
            bdd = Nothing
        Catch ex As Exception
            CSDebug.dispError("CSLocali::getVilleByCp() : " & ex.Message)
        End Try
        Return result
    End Function

End Module
