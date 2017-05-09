Public Class DBVersionManagerManager


#Region "Methodes acces Local"

    Public Shared Function checkVersion(ByVal pNumVersion As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oDBVersion As DBVersion
            oDBVersion = getDBVersion()
            If oDBVersion.NUM.ToUpper().Trim() = pNumVersion.ToUpper.Trim() Then
                bReturn = True
            Else
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispError("DBVersion.CheckVersion Error : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Methode OK
    ''' <summary>
    ''' renvoie un La version de la base de données
    ''' </summary>
    ''' <returns> une instance de dbVersion</returns>
    ''' <remarks></remarks>
    Public Shared Function getDBVersion() As DBVersion
        Dim oCsDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim oDBVersion As New DBVersion()

        oCsDb = New CSDb(True)

        bddCommande = oCsDb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM VERSION ORDER BY VERSION_DATE DESC"
        Try
            ' On récupère les résultats
            Dim oDBReader As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            If oDBReader.HasRows() Then
                oDBReader.Read()
                Dim tmpcolID As Integer = 0
                While tmpColId < oDBReader.FieldCount()
                    If Not oDBReader.IsDBNull(tmpColId) Then
                        oDBVersion.Fill(oDBReader.GetName(tmpColId), oDBReader.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
            End If
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispFatal("DBVersionManager - GetDBVersion() Erreur : " & ex.Message)
        End Try
        If Not oCsDb Is Nothing Then
            oCsDb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return oDBVersion

    End Function 'getDBversion


    ' Methode OK
    Public Function save(ByVal pDBVersion As DBVersion) As Boolean
        Debug.Assert(Not pDBVersion Is Nothing, "La version doit être renseignée")
        Debug.Assert(Not String.IsNullOrEmpty(pDBVersion.NUM), "La version doit être renseignée")

        Dim oCSDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim bReturn As Boolean
        Dim nResult As Integer

        Try
            bReturn = False

            oCSDb = New CSDb(True)

            bddCommande = oCSDb.getConnection.CreateCommand()

            Dim paramsQuery As String
            paramsQuery = "VERSION_NUM='" & pDBVersion.NUM & "'"
            paramsQuery = paramsQuery & " , " & "VERSION_DATE='" & CSDate.mysql2access(pDBVersion.DateVersion) & "'"
            paramsQuery = paramsQuery & " , " & "VERSION_COMM='" & pDBVersion.Commentaire & "'"

            bddCommande.CommandText = "UPDATE `VERSION` SET " & paramsQuery
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "AgentManager.save: Erreur en update 0 ou  plus d'une ligne concernée")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DBVersionManager.save ERREUR : " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCSDb Is Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function


#End Region


End Class
