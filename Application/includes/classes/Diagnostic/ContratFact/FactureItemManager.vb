Imports System.Collections.Generic

Public Class FactureItemManager

    Public Shared Function Exists(pFactureID As String, pNumero As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As OleDb.OleDbCommand
            oCmd = oCSDB.getConnection.CreateCommand
            oCmd.CommandText = "SELECT Count(*) from factureItem where idFacture = ? and nFactureItem = ?"
            oCmd.Parameters.AddWithValue("?_1", pFactureID)
            oCmd.Parameters.AddWithValue("?_2", pNumero)

            Dim n As Integer
            n = oCmd.ExecuteScalar()
            bReturn = (n > 0)
            oCSDB.free()

        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.exists ERR ", ex)
            bReturn = False
        End Try
        Return bReturn

    End Function
    Public Shared Function save(pFactureItem As FactureItem, Optional bSyncro As Boolean = False) As Boolean
        Debug.Assert(pFactureItem IsNot Nothing)

        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)

        If Not bSyncro Then
            pFactureItem.dateModificationAgent = DateTime.Now
        End If
        Try
            If Exists(pFactureItem.idFacture, pFactureItem.nFactureItem) Then
                bReturn = update(pFactureItem, bSyncro)
            Else
                bReturn = insert(pFactureItem, bSyncro)
            End If
        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.save ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Shared Function update(pfactureItem As FactureItem, bsynchro As Boolean) As Boolean
        Dim breturn As Boolean

        Try
            Dim oCSDB As New CSDb(True)

            Dim oCmd As OleDb.OleDbCommand
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "Update FACTUREITEM SET " &
                "categorie = ? , " &'1
                "prestation = ? , " &'2
                "quantite = ?, " &'3'
                "pu = ?, " &'4
                "totalhtitem = ?, " &'5'
                "totaltvaItem = ?, " &'6
                "totalTTCItem = ?, " &'7
                "txTVAItem = ?, " &'8
                "dateModificationAgent = ?, " &'9
                "dateModificationCrodip = ?" &'10
                "WHERE " &
                "idFacture = ? And " &'11
                "nFactureitem = ? " '12


            oCmd.Parameters.AddWithValue("?_1", pfactureItem.categorie)
            oCmd.Parameters.AddWithValue("?_2", pfactureItem.prestation)
            oCmd.Parameters.AddWithValue("?_3", pfactureItem.quantite)
            oCmd.Parameters.AddWithValue("?_4", pfactureItem.pu)
            oCmd.Parameters.AddWithValue("?_5", pfactureItem.totalHT)
            oCmd.Parameters.AddWithValue("?_6", pfactureItem.totalTVA)
            oCmd.Parameters.AddWithValue("?_7", pfactureItem.totalTTC)
            oCmd.Parameters.AddWithValue("?_8", pfactureItem.txTVA)
            oCmd.Parameters.AddWithValue("?_9", CSDate.mysql2access(pfactureItem.dateModificationAgent))
            oCmd.Parameters.AddWithValue("?_10", CSDate.mysql2access(pfactureItem.dateModificationCrodip))
            oCmd.Parameters.AddWithValue("?_11", pfactureItem.idFacture)
            oCmd.Parameters.AddWithValue("?_12", pfactureItem.nFactureItem)

            oCmd.ExecuteNonQuery()

            oCSDB.free()
            breturn = True
        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.updateFacture ERR", ex)
            breturn = False
        End Try
        Return breturn
    End Function
    Private Shared Function insert(pfactureItem As FactureItem, bsynchro As Boolean) As Boolean
        Dim breturn As Boolean

        Try
            Dim oCSDB As New CSDb(True)

            Dim oCmd As OleDb.OleDbCommand
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "insert into FACTUREITEM (" &
                "categorie , " &'1
                "prestation , " &'2
                "quantite , " &'3'
                "pu , " &'4
                "totalhtitem , " &'5'
                "totaltvaItem , " &'6
                "totalTTCItem , " &'7
                "txTVAItem, " &'8
                "dateModificationAgent , " &'9
                "dateModificationCrodip, " &'10
                "idFacture ," &'11
                "nFactureitem  " &  '12
                " ) VALUES ( " &
                    "? , " &'1
                "? , " &'2
                "?, " &'3'
                "?, " &'4
                "?, " &'5'
                "?, " &'6
                "?, " &'7
                "?, " &'8
                "?, " &'9
                "?," &'10
                "?," &'11
                "? " & '12
                ")"


            oCmd.Parameters.AddWithValue("?_1", pfactureItem.categorie)
            oCmd.Parameters.AddWithValue("?_2", pfactureItem.prestation)
            oCmd.Parameters.Add("?_3", OleDb.OleDbType.Currency).Value = pfactureItem.quantite
            oCmd.Parameters.Add("?_4", OleDb.OleDbType.Currency).Value = pfactureItem.pu
            oCmd.Parameters.Add("?_5", OleDb.OleDbType.Currency).Value = pfactureItem.totalHT
            oCmd.Parameters.Add("?_6", OleDb.OleDbType.Currency).Value = pfactureItem.totalTVA
            oCmd.Parameters.Add("?_7", OleDb.OleDbType.Currency).Value = pfactureItem.totalTTC
            oCmd.Parameters.Add("?_8", OleDb.OleDbType.Currency).Value = pfactureItem.txTVA
            oCmd.Parameters.AddWithValue("?_9", CSDate.mysql2access(pfactureItem.dateModificationAgent))
            oCmd.Parameters.AddWithValue("?_10", CSDate.mysql2access(pfactureItem.dateModificationCrodip))
            oCmd.Parameters.AddWithValue("?_11", pfactureItem.idFacture)
            oCmd.Parameters.AddWithValue("?_12", pfactureItem.nFactureItem)


            oCmd.ExecuteNonQuery()

            oCSDB.free()
            breturn = True
        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.insert ERR", ex)


            breturn = False
        End Try
        Return breturn
    End Function
    Public Shared Function getFactureById(pFactureId As String) As List(Of FactureItem)
        Debug.Assert(Not String.IsNullOrEmpty(pFactureId), "PFactureId must be set")

        Dim oReturn As New List(Of FactureItem)
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As OleDb.OleDbCommand
            Dim oDR As OleDb.OleDbDataReader
            Dim n As Integer = 1
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "SELECT * FROM FactureItem where idFacture = ? ORDER BY nfactureitem asc"
            oCmd.Parameters.AddWithValue("?", pFactureId)
            oDR = oCmd.ExecuteReader()

            While oDR.Read()
                Dim olg As New FactureItem()
                Dim nChamp As Integer
                For nChamp = 0 To oDR.FieldCount() - 1
                    If Not oDR.IsDBNull(nChamp) Then
                        Fill(olg, oDR.GetName(nChamp), oDR.GetValue(nChamp))
                    End If
                Next
                olg.idFacture = pFactureId
                oReturn.Add(olg)
                '                olg.nFactureItem = n
                n = n + 1
            End While


        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.getFactureById ERR", ex)
            oReturn = New List(Of FactureItem)()
        End Try
        Return oReturn
    End Function

    Public Shared Sub Fill(pLg As FactureItem, pNomchamp As String, pValue As Object)
        Try

            Select Case Trim(pNomchamp).ToUpper()
                Case Trim("categorie").ToUpper()
                    pLg.categorie = pValue.ToString()
                Case Trim("prestation").ToUpper()
                    pLg.prestation = pValue
                Case Trim("quantite").ToUpper()
                    pLg.quantite = pValue
                Case Trim("pu").ToUpper()
                    pLg.pu = pValue
                Case Trim("totalhtitem").ToUpper()
                    pLg.totalHT = pValue
                Case Trim("totaltvaItem").ToUpper()
                    pLg.totalTVA = pValue
                Case Trim("totalTTCItem").ToUpper()
                    pLg.totalTTC = pValue
                Case Trim("txTVAItem").ToUpper()
                    pLg.txTVA = pValue
                Case Trim("idFacture").ToUpper()
                    pLg.idFacture = pValue
                Case Trim("nFactureItem").ToUpper()
                    pLg.nFactureItem = pValue
                Case Trim("dateModificationAgent").ToUpper()
                    pLg.dateModificationAgent = pValue
                Case Trim("dateModificationCrodip").ToUpper()
                    pLg.dateModificationCrodip = pValue
            End Select
        Catch ex As Exception
            CSDebug.dispError("Facture.Fill(" & pNomchamp & "," & pValue & ")", ex)
        End Try

    End Sub


    Private Sub adel()

        'Dim oCmd As OleDb.OleDbCommand
        'oCmd = oCSDB.getConnection.CreateCommand
        'oCmd.CommandText = "SELECT Count(*) from facture where idFacture 

        '    ' On test si le Diagnostic existe ou non
        '    Dim existsDiagnostic As Object
        '    existsDiagnostic = getFactureById(pFacture.idFacture)
        '    If existsDiagnostic.id = "" Then
        '        ' Si il n'existe pas, on le crée
        '        createDiagnosticFacture(curObject.id)
        '    End If

        '    Dim bddCommande As New OleDb.OleDbCommand
        '    ' On test si la connexion est déjà ouverte ou non
        '    bddCommande.Connection = oCSDB.getConnection()

        '    ' Initialisation de la requete
        '    Dim paramsQuery As String = "`DiagnosticFacture`.`id`='" & curObject.id & "'"

        '    ' Mise a jour de la date de derniere modification
        '    If Not bSyncro Then
        '    curObject.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
        'End If

        'If Not curObject.factureReference Is Nothing Then
        '    paramsQuery = paramsQuery & " , `factureReference`='" & CSDb.secureString(curObject.factureReference) & "'"
        'End If
        'If Not curObject.factureDate Is Nothing Then
        '    paramsQuery = paramsQuery & " , `factureDate`='" & CSDb.secureString(curObject.factureDate) & "'"
        'End If
        'If Not curObject.factureTotal Is Nothing Then
        '    paramsQuery = paramsQuery & " , `factureTotal`='" & CSDb.secureString(curObject.factureTotal) & "'"
        'End If
        'If Not curObject.emetteurOrganisme Is Nothing Then
        '    paramsQuery = paramsQuery & " , `emetteurOrganisme`='" & CSDb.secureString(curObject.emetteurOrganisme) & "'"
        'End If
        'If Not curObject.emetteurOrganismeAdresse Is Nothing Then
        '    paramsQuery = paramsQuery & " , `emetteurOrganismeAdresse`='" & CSDb.secureString(curObject.emetteurOrganismeAdresse) & "'"
        'End If
        'If Not curObject.emetteurOrganismeCpVille Is Nothing Then
        '    paramsQuery = paramsQuery & " , `emetteurOrganismeCpVille`='" & CSDb.secureString(curObject.emetteurOrganismeCpVille) & "'"
        'End If
        'If Not curObject.emetteurOrganismeTelFax Is Nothing Then
        '    paramsQuery = paramsQuery & " , `emetteurOrganismeTelFax`='" & CSDb.secureString(curObject.emetteurOrganismeTelFax) & "'"
        'End If
        'If Not curObject.emetteurOrganismeSiren Is Nothing Then
        '    paramsQuery = paramsQuery & " , `emetteurOrganismeSiren`='" & CSDb.secureString(curObject.emetteurOrganismeSiren) & "'"
        'End If
        'If Not curObject.emetteurOrganismeTva Is Nothing Then
        '    paramsQuery = paramsQuery & " , `emetteurOrganismeTva`='" & CSDb.secureString(curObject.emetteurOrganismeTva) & "'"
        'End If
        'If Not curObject.emetteurOrganismeRcs Is Nothing Then
        '    paramsQuery = paramsQuery & " , `emetteurOrganismeRcs`='" & CSDb.secureString(curObject.emetteurOrganismeRcs) & "'"
        'End If
        'If Not curObject.recepteurRaisonSociale Is Nothing Then
        '    paramsQuery = paramsQuery & " , `recepteurRaisonSociale`='" & CSDb.secureString(curObject.recepteurRaisonSociale) & "'"
        'End If
        'If Not curObject.recepteurProprio Is Nothing Then
        '    paramsQuery = paramsQuery & " , `recepteurProprio`='" & CSDb.secureString(curObject.recepteurProprio) & "'"
        'End If
        'If Not curObject.recepteurCpVille Is Nothing Then
        '    paramsQuery = paramsQuery & " , `recepteurCpVille`='" & CSDb.secureString(curObject.recepteurCpVille) & "'"
        'End If
        'If Not curObject.dateModificationAgent Is Nothing Then
        '    paramsQuery = paramsQuery & " , `dateModificationAgent`='" & CSDb.secureString(curObject.dateModificationAgent) & "'"
        'End If
        'If Not curObject.dateModificationCrodip Is Nothing Then
        '    paramsQuery = paramsQuery & " , `dateModificationCrodip`='" & CSDb.secureString(curObject.dateModificationCrodip) & "'"
        'End If

        '' On finalise la requete et en l'execute
        'bddCommande.CommandText = "UPDATE `DiagnosticFacture` SET " & paramsQuery & " WHERE `DiagnosticFacture`.`id`='" & curObject.id & "'"
        'CSDebug.dispInfo("DiagnosticFactureManager::save (query) : " & bddCommande.CommandText)
        'bddCommande.ExecuteNonQuery()

        '' On enregistre les items de la facture
        'If Not curObject.diagnosticFactureItems Is Nothing Then
        '    Dim i As Integer = 0
        '    For Each tmpItemCheck As DiagnosticFactureItem In curObject.diagnosticFactureItems
        '        If Not tmpItemCheck Is Nothing Then
        '            'Dim tmpNewDiagItemId As String = DiagnosticFactureItemManager.getNewId(agentCourant.idStructure)
        '            'tmpItemCheck.id = tmpNewDiagItemId
        '            'tmpItemCheck.idFacture = curObject.id
        '            'DiagnosticFactureItemManager.save2(tmpItemCheck)
        '        End If
        '        i = i + 1
        '    Next
        'End If

        'Catch ex As Exception
        'CSDebug.dispFatal("DiagnosticFactureManager(" & curObject.id & ")::save : " & ex.Message.ToString)
        'End Try

        'If Not oCSDB Is Nothing Then
        '    oCSDB.free()
        'End If

        'End Function
    End Sub


End Class
