Imports System.Collections.Generic

''' <summary>
''' 
''' 
''' </summary>
''' <remarks></remarks>
Public Class AcquiringManager

    Public Shared Sub clearResults()
        ' Initialisation de la DB
        'If Not GLOB_ENV_DEBUG Then
        'On ne Vide pas la table en Debug pour test
        Dim bdd As New CSDb(True, DBTYPE.DAISY)
        Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResults("DELETE FROM tmpDataAcquiring")
        bdd.free()
    End Sub
    Public Shared Function Save(arrAcquiring As List(Of Acquiring)) As Boolean
        Dim bReturn As Boolean
        Dim oCSDB As CSDb
        Try
            AcquiringManager.clearResults()

            oCSDB = New CSDb(True, DBTYPE.DAISY)
            Dim strSQL As String
            For Each oAcquiring As Acquiring In arrAcquiring
                strSQL = "INSERT INTO tmpDataAcquiring (idBuse,IdNiveau,debit,pression) VALUES (" & oAcquiring.idBuse & "," & oAcquiring.idNiveau & "," & oAcquiring.debit & "," & oAcquiring.pression & ")"
                oCSDB.Execute(strSQL)
            Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("AcquiringManager.save ERR" & ex.Message)
            bReturn = False
        End Try
        If oCSDB IsNot Nothing Then
            oCSDB.free()
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Rend un tableau des valeurs Aquises
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAcquiring() As Acquiring()
        ' Tableau de retour
        Dim arrBuses(0) As Acquiring

        ' Initialisation de la DB
        Dim bdd As New CSDb(True, DBTYPE.DAISY)
        Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT * FROM tmpDataAcquiring")

        ' Parcourt des résultats
        Dim i As Integer = 0
        While dataResults.Read()

            Dim tmpResponse As New Acquiring()
            ' On rempli notre tableau
            Dim tmpColId As Integer = 0
            While tmpColId < dataResults.FieldCount()
                If Not dataResults.IsDBNull(tmpColId) Then
                    tmpResponse.Fill(dataResults.GetName(tmpColId), dataResults.Item(tmpColId))
                End If
                tmpColId = tmpColId + 1
            End While
            arrBuses(i) = tmpResponse

            i += 1
            ReDim Preserve arrBuses(i)
        End While
        ReDim Preserve arrBuses(i - 1)
        dataResults.Close()
        bdd.free()
        Return arrBuses
    End Function
    ''' <summary>
    ''' Rend le nombre de niveaux acquis
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getNbNiveaux() As Integer
        Dim nbNiveaux As Integer = 0
        Try
            Dim bdd As New CSDb(True, DBTYPE.DAISY)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT Distinct idNiveau FROM tmpDataAcquiring")

            nbNiveaux = 0
            If dataResults.HasRows() Then
                While dataResults.Read()
                    nbNiveaux = nbNiveaux + 1
                End While
            End If
            dataResults.Close()
            bdd.free()
        Catch ex As Exception
            CSDebug.dispError("AcquiringManager.checkNbNiveau() : " & ex.Message)
            nbNiveaux = 0
        End Try
        Return nbNiveaux
    End Function
    ''' <summary>
    ''' Rend le nombre de buses par niveau
    ''' </summary>
    ''' <param name="pnNiveau"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getNbBuses(ByVal pnNiveau As Integer) As Integer
        Dim isOk As Boolean = True
        Dim nbBusesLu As Integer = -1
        Try
            Dim bdd As New CSDb(True, DBTYPE.DAISY)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT Count(*) AS nbBuses FROM tmpDataAcquiring WHERE idNiveau = " & pnNiveau & "")
            Dim nbNiveaux As Integer = 0

            isOk = True
            If dataResults.HasRows() Then
                dataResults.Read()
                nbBusesLu = dataResults.GetInt32(0)
            End If
            dataResults.Close()
            bdd.free()
        Catch ex As Exception
            CSDebug.dispError("AcquiringManager.getNbBuses() : " & ex.Message)
            nbBusesLu = -1
        End Try
        Return nbBusesLu
    End Function

    Public Shared Function checkNbBusesTool() As Boolean
        Dim isOk As Boolean = True
        Try
            Dim bdd As New CSDb(True, DBTYPE.DAISY)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT idNiveau,Count(*) AS nbBuses FROM tmpDataAcquiring GROUP BY idNiveau")
            Dim nbNiveaux As Integer = 0
            Dim nbNiveauxDec As Integer = 0

            '' On test le nombre de buses par niveaux
            While dataResults.Read()
                Dim idNiveauLu As Integer = dataResults.GetInt32(0)
                Dim nbBusesLu As Integer = dataResults.GetInt32(1)
                Dim nbBusesDeclare As Integer = 0 'Nbre de buses déclarée dans le prog appellant

                'Recherche dans le proga appellant le nombre de buses déclarées dans le niveau isNiveauLu
                Dim x As Control
                x = CSForm.getControlByName("TextBox_nbBuses_" & idNiveauLu, globFormToolBuses)
                Try
                    nbBusesDeclare = CInt(x.Text)
                Catch ex As Exception
                End Try

                If nbBusesDeclare <> nbBusesLu Then
                    isOk = False
                End If
                nbNiveaux += 1
            End While
            '            bdd = Nothing

            '' On test le nombre de niveaux
            Try
                nbNiveauxDec = CInt(globFormToolBuses.diagBuses_conf_nbCategories.Text)
            Catch ex As Exception
            End Try
            If nbNiveaux <> nbNiveauxDec Then
                isOk = False
            End If
            bdd.free()
        Catch ex As Exception
            CSDebug.dispError("AcquiringManager.checkNbBusesTool() : " & ex.Message)
            isOk = False
        End Try
        Return isOk
    End Function

End Class
