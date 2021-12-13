Imports System.Collections.Generic
Public Class FactureManager

    Public Shared Function Exists(pFactureID As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As OleDb.OleDbCommand
            oCmd = oCSDB.getConnection.CreateCommand
            oCmd.CommandText = "SELECT Count(*) from facture where idFacture = @idFacture"
            oCmd.Parameters.AddWithValue("@idFacture", pFactureID)

            Dim n As Integer
            n = oCmd.ExecuteScalar()
            bReturn = (n > 0)
            oCSDB.free()

        Catch ex As Exception
            CSDebug.dispError("FactureManager.exists ERR ", ex)
            bReturn = False
        End Try
        Return bReturn

    End Function
    Public Shared Function save(pFacture As Facture, Optional bSyncro As Boolean = False) As Boolean
        Debug.Assert(pFacture IsNot Nothing)

        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)

        If Not bSyncro Then
            pFacture.dateModificationAgent = DateTime.Now
        End If
        Try
            If Exists(pFacture.idFacture) Then
                bReturn = update(pFacture, bSyncro)
            Else
                bReturn = insert(pFacture, bSyncro)
            End If

            Dim nLigne As Integer = 1
            For Each oLg As FactureItem In pFacture.Lignes
                oLg.idFacture = pFacture.idFacture
                oLg.nFactureItem = nLigne
                FactureItemManager.save(oLg)
                nLigne = nLigne + 1

            Next



        Catch ex As Exception
            CSDebug.dispError("FactureManager.save ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Shared Function update(pfacture As Facture, bsynchro As Boolean) As Boolean
        Dim breturn As Boolean

        Try
            Dim oCSDB As New CSDb(True)

            Dim oCmd As OleDb.OleDbCommand
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "Update FACTURE SET " &
                "idStructure = ? , " &'1
                "datefacture = ? , " &'2
                "dateecheance = ?, " &'3'
                "commentaire = ?, " &'4
                "modeReglement = ?, " &'5'
                "isreglee = ?, " &'6
                "refreglement = ?, " &'7
                "totalHt = ?, " &'8
                "totalTVA = ?, " &'9
                "totalTTC = ? , " &'10
                "txTVA = ? , " &'11'
                "idDiag = ? , " &'12
                "idExploit = ?, " &'13
                "rsClient = ? , " &'14
                "nomclient = ? , " &'15
                "prenomclient = ? , " &'16
                "adresseClient = ? , " &'17
                "cpClient = ? , " &'18
                "communeClient = ? , " &'19
                "telFixeClient = ? , " &'20
                "telportClient = ? , " &'21
                "emailClient = ? , " &'22
                "pathPDF = ? , " &'23
                "dateModificationAgent = ?, " &'24
                "dateModificationCrodip = ?" &'25
                "WHERE idFacture = ?" '26


            oCmd.Parameters.AddWithValue("?_1", pfacture.idStructure)
            oCmd.Parameters.AddWithValue("?_2", pfacture.dateFacture)
            oCmd.Parameters.AddWithValue("?_3", pfacture.dateEcheance)
            oCmd.Parameters.AddWithValue("?_4", pfacture.Commentaire)
            oCmd.Parameters.AddWithValue("?_5", pfacture.modeReglement)
            oCmd.Parameters.AddWithValue("?_6", pfacture.isReglee)
            oCmd.Parameters.AddWithValue("?_7", pfacture.refReglement)
            oCmd.Parameters.Add("?_8", OleDb.OleDbType.Currency).Value = pfacture.TotalHT
            oCmd.Parameters.Add("?_9", OleDb.OleDbType.Currency).Value = pfacture.TotalTVA
            oCmd.Parameters.Add("?_10", OleDb.OleDbType.Currency).Value = pfacture.TotalTTC
            oCmd.Parameters.Add("?_11", OleDb.OleDbType.Currency).Value = pfacture.TxTVA
            oCmd.Parameters.AddWithValue("?_12", pfacture.idDiag)
            oCmd.Parameters.AddWithValue("?_13", pfacture.oExploit.id)
            oCmd.Parameters.AddWithValue("?_14", pfacture.oExploit.raisonSociale)
            oCmd.Parameters.AddWithValue("?_15", pfacture.oExploit.nomExploitant)
            oCmd.Parameters.AddWithValue("?_16", pfacture.oExploit.prenomExploitant)
            oCmd.Parameters.AddWithValue("?_17", pfacture.oExploit.adresse)
            oCmd.Parameters.AddWithValue("?_18", pfacture.oExploit.codePostal)
            oCmd.Parameters.AddWithValue("?_19", pfacture.oExploit.commune)
            oCmd.Parameters.AddWithValue("?_20", pfacture.oExploit.telephoneFixe)
            oCmd.Parameters.AddWithValue("?_21", pfacture.oExploit.telephonePortable)
            oCmd.Parameters.AddWithValue("?_22", pfacture.oExploit.eMail)
            oCmd.Parameters.AddWithValue("?_23", pfacture.pathPDF)
            oCmd.Parameters.AddWithValue("?_24", CSDate.mysql2access(pfacture.dateModificationAgent))
            oCmd.Parameters.AddWithValue("?_25", CSDate.mysql2access(pfacture.dateModificationCrodip))
            oCmd.Parameters.AddWithValue("?_26", pfacture.idFacture)

            oCmd.ExecuteNonQuery()

            oCSDB.free()
            breturn = True
        Catch ex As Exception
            CSDebug.dispError("FactureManager.updateFacture ERR", ex)
            breturn = False
        End Try
        Return breturn
    End Function
    Private Shared Function insert(pfacture As Facture, bsynchro As Boolean) As Boolean
        Dim breturn As Boolean

        Try
            Dim oCSDB As New CSDb(True)

            Dim oCmd As OleDb.OleDbCommand
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "insert into FACTURE (" &
                "idStructure," &
                "datefacture," &
                "dateecheance," &
                "commentaire," &
                "modeReglement," &
                "isreglee," &
                "refreglement," &
                "totalHt," &
                "totalTVA," &
                "totalTTC," &
                "txTVA," &
                "idDiag," &
                "idExploit," &
                "rsClient," &
                "nomclient," &
                "prenomclient," &
                "adresseClient," &
                "cpClient," &
                "communeClient," &
                "telFixeClient," &
                "telportClient," &
                "emailClient," &
                "pathPDF," &
                "dateModificationAgent, " &
                "dateModificationCrodip," &
                "idFacture " &
                ") VALUES ( " &
                "?," & ' 1
                "?," &'2
                "?," &'3
                "?," &'4'
                "?," &'5'
                "?," &'6
                "?," &'7'
                "?," &'8
                "?," &'9
                "?," &'10
                "?," &'11
                "?," &'12
                "?," &'13
                "?," &'14
                "?," &'15
                "?," &'16
                "?," &'17
                "?," &'18
                "?," &'19
                "?," &'20
                "?," &'21
                "?," &'22'
                "?," &'23
                "?," &'24
                "?," &'25
                "?" & '26
                ");"


            oCmd.Parameters.AddWithValue("?_1", pfacture.idStructure)
            oCmd.Parameters.AddWithValue("?_2", CSDate.mysql2access(pfacture.dateFacture))
            oCmd.Parameters.AddWithValue("?_3", CSDate.mysql2access(pfacture.dateEcheance))
            oCmd.Parameters.AddWithValue("?_4", pfacture.Commentaire)
            oCmd.Parameters.AddWithValue("?_5", pfacture.modeReglement)
            oCmd.Parameters.AddWithValue("?_6", pfacture.isReglee)
            oCmd.Parameters.AddWithValue("?_7", pfacture.refReglement)
            oCmd.Parameters.Add("?_8", OleDb.OleDbType.Currency).Value = pfacture.TotalHT
            oCmd.Parameters.Add("?_9", OleDb.OleDbType.Currency).Value = pfacture.TotalTVA
            oCmd.Parameters.Add("?_10", OleDb.OleDbType.Currency).Value = pfacture.TotalTTC
            oCmd.Parameters.Add("?_11", OleDb.OleDbType.Currency).Value = pfacture.TxTVA
            oCmd.Parameters.AddWithValue("?_12", pfacture.oDiagnostic.id)
            oCmd.Parameters.AddWithValue("?_13", pfacture.oExploit.id)
            oCmd.Parameters.AddWithValue("?_14", pfacture.oExploit.raisonSociale)
            oCmd.Parameters.AddWithValue("?_15", pfacture.oExploit.nomExploitant)
            oCmd.Parameters.AddWithValue("?_16", pfacture.oExploit.prenomExploitant)
            oCmd.Parameters.AddWithValue("?_17", pfacture.oExploit.adresse)
            oCmd.Parameters.AddWithValue("?_18", pfacture.oExploit.codePostal)
            oCmd.Parameters.AddWithValue("?_19", pfacture.oExploit.commune)
            oCmd.Parameters.AddWithValue("?_20", pfacture.oExploit.telephoneFixe)
            oCmd.Parameters.AddWithValue("?_21", pfacture.oExploit.telephonePortable)
            oCmd.Parameters.AddWithValue("?_22", pfacture.oExploit.eMail)
            oCmd.Parameters.AddWithValue("?_23", pfacture.pathPDF)
            oCmd.Parameters.AddWithValue("?_24", CSDate.mysql2access(pfacture.dateModificationAgent))
            oCmd.Parameters.AddWithValue("?_25", CSDate.mysql2access(pfacture.dateModificationCrodip))
            oCmd.Parameters.AddWithValue("?_26", pfacture.idFacture)

            oCmd.ExecuteNonQuery()

            oCSDB.free()
            breturn = True
        Catch ex As Exception
            CSDebug.dispError("FactureManager.insert ERR", ex)


            breturn = False
        End Try
        Return breturn
    End Function
    Public Shared Function getFactureById(pFactureId As String) As Facture
        Debug.Assert(Not String.IsNullOrEmpty(pFactureId), "PFactureId must be set")

        Dim oReturn As New Facture
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As OleDb.OleDbCommand
            Dim oDR As OleDb.OleDbDataReader
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "SELECT * FROM Facture where idFacture = ?"
            oCmd.Parameters.AddWithValue("?", pFactureId)
            oDR = oCmd.ExecuteReader()
            While oDR.Read()
                Dim nChamp As Integer
                For nChamp = 0 To oDR.FieldCount() - 1
                    If Not oDR.IsDBNull(nChamp) Then
                        Fill(oReturn, oDR.GetName(nChamp), oDR.GetValue(nChamp))
                    End If
                Next

            End While
            oDR.Close()
            oReturn.Lignes.AddRange(FactureItemManager.getFactureById(oReturn.idFacture))
            oCSDB.free()

        Catch ex As Exception
            CSDebug.dispError("FactureManager.getFactureById ERR", ex)
            oReturn = New Facture()
        End Try
        Return oReturn
    End Function

    Public Shared Function getFacturesByDiagId(pDiagId As String) As List(Of Facture)
        Debug.Assert(Not String.IsNullOrEmpty(pDiagId), "PDiagId must be set")

        Dim oReturn As New List(Of Facture)
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As OleDb.OleDbCommand
            Dim oDR As OleDb.OleDbDataReader
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "SELECT * FROM Facture where idDiag = ?"
            oCmd.Parameters.AddWithValue("?", pDiagId)
            oDR = oCmd.ExecuteReader()
            While oDR.Read()
                Dim oFacture As New Facture()
                Dim nChamp As Integer
                For nChamp = 0 To oDR.FieldCount() - 1
                    If Not oDR.IsDBNull(nChamp) Then
                        Fill(oFacture, oDR.GetName(nChamp), oDR.GetValue(nChamp))
                    End If
                Next
                oFacture.Lignes.AddRange(FactureItemManager.getFactureById(oFacture.idFacture))
                oReturn.Add(oFacture)

            End While
            oDR.Close()
            oCSDB.free()


        Catch ex As Exception
            CSDebug.dispError("FactureManager.getFactureById ERR", ex)
            oReturn = New List(Of Facture)()
        End Try
        Return oReturn
    End Function
    Public Shared Sub Fill(pFact As Facture, pNomchamp As String, pValue As Object)
        Try

            Select Case Trim(pNomchamp).ToUpper()
                Case Trim("idStructure").ToUpper()
                    pFact.idStructure = pValue.ToString()
                Case Trim("datefacture").ToUpper()
                    pFact.dateFacture = CDate(pValue)
                Case Trim("dateecheance").ToUpper()
                    pFact.dateEcheance = CDate(pValue)
                Case Trim("commentaire").ToUpper()
                    pFact.Commentaire = pValue
                Case Trim("modeReglement").ToUpper()
                    pFact.modeReglement = pValue
                Case Trim("isreglee").ToUpper()
                    pFact.isReglee = pValue
                Case Trim("refreglement").ToUpper()
                    pFact.refReglement = pValue
                Case Trim("totalHt").ToUpper()
                    pFact.TotalHT = pValue
                Case Trim("totalTVA").ToUpper()
                    pFact.TotalTVA = pValue
                Case Trim("totalTTC").ToUpper()
                    pFact.TotalTTC = pValue
                Case Trim("txTVA").ToUpper()
                    pFact.TxTVA = pValue
                Case Trim("idDiag").ToUpper()
                    pFact.idDiag = pValue
                Case Trim("idExploit").ToUpper()
                    pFact.oExploit.id = pValue
                Case Trim("rsClient").ToUpper()
                    pFact.oExploit.raisonSociale = pValue
                Case Trim("nomclient").ToUpper()
                    pFact.oExploit.nomExploitant = pValue
                Case Trim("prenomclient").ToUpper()
                    pFact.oExploit.prenomExploitant = pValue
                Case Trim("adresseClient").ToUpper()
                    pFact.oExploit.adresse = pValue
                Case Trim("cpClient").ToUpper()
                    pFact.oExploit.codePostal = pValue
                Case Trim("communeClient").ToUpper()
                    pFact.oExploit.commune = pValue
                Case Trim("telFixeClient").ToUpper()
                    pFact.oExploit.telephoneFixe = pValue
                Case Trim("telportClient").ToUpper()
                    pFact.oExploit.telephonePortable = pValue
                Case Trim("emailClient").ToUpper()
                    pFact.oExploit.eMail = pValue
                Case Trim("PATHPDF").ToUpper()
                    pFact.pathPDF = pValue
                Case Trim("dateModificationAgent").ToUpper()
                    pFact.dateModificationAgent = pValue
                Case Trim("dateModificationCrodip").ToUpper()
                    pFact.dateModificationCrodip = pValue
                Case Trim("idFacture").ToUpper()
                    pFact.idFacture = pValue
            End Select
        Catch ex As Exception
            CSDebug.dispError("Facture.Fill(" & pNomchamp & "," & pValue & ")", ex)
        End Try

    End Sub


End Class
