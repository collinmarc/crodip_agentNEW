Imports System.Collections.Generic
Imports System.Data.Common

Public Class FactureManager
    Inherits CrodipManager
    Public Shared Function Exists(pFactureID As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As DbCommand
            oCmd = oCSDB.getConnection.CreateCommand
            oCmd.CommandText = "SELECT Count(*) from facture where idFacture = @idFacture"
            AddParameter(oCmd, "@idFacture", pFactureID)

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

            Dim oCmd As DbCommand
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "Update FACTURE SET " &
                "idStructure = @1 , " &'1
                "datefacture = @2 , " &'2
                "dateecheance = @3, " &'3'
                "commentaire = @4, " &'4
                "modeReglement = @5, " &'5'
                "isreglee = @6, " &'6
                "refreglement = @7, " &'7
                "totalHt = @8, " &'8
                "totalTVA = @9, " &'9
                "totalTTC = @10 , " &'10
                "txTVA = @11 , " &'11'
                "idDiag = @12 , " &'12
                "idExploit = @13, " &'13
                "rsClient = @14, " &'14
                "nomclient = @15 , " &'15
                "prenomclient = @16 , " &'16
                "adresseClient = @17 , " &'17
                "cpClient = @18 , " &'18
                "communeClient = @19 , " &'19
                "telFixeClient = @20 , " &'20
                "telportClient = @21 , " &'21
                "emailClient = @22 , " &'22
                "pathPDF = @23 , " &'23
                "dateModificationAgent = @24, " &'24
                "dateModificationCrodip = @25" &'25
                "WHERE idFacture = @26" '26


            AddParameter(oCmd, "@1", pfacture.idStructure)
            AddParameter(oCmd, "@2", CSDate.ToCRODIPString(pfacture.dateFacture))
            AddParameter(oCmd, "@3", CSDate.ToCRODIPString(pfacture.dateEcheance))
            AddParameter(oCmd, "@4", pfacture.Commentaire)
            AddParameter(oCmd, "@5", pfacture.modeReglement)
            AddParameter(oCmd, "@6", pfacture.isReglee)
            AddParameter(oCmd, "@7", pfacture.refReglement)
            AddParameter(oCmd, "@8", pfacture.TotalHT, DbType.Currency)
            AddParameter(oCmd, "@9", pfacture.TotalTVA, DbType.Currency)
            AddParameter(oCmd, "@10", pfacture.TotalTTC, DbType.Currency)
            AddParameter(oCmd, "@11", pfacture.TxTVA, DbType.Currency)
            AddParameter(oCmd, "@12", pfacture.idDiag)
            AddParameter(oCmd, "@13", pfacture.oExploit.id)
            AddParameter(oCmd, "@14", pfacture.oExploit.raisonSociale)
            AddParameter(oCmd, "@15", pfacture.oExploit.nomExploitant)
            AddParameter(oCmd, "@16", pfacture.oExploit.prenomExploitant)
            AddParameter(oCmd, "@17", pfacture.oExploit.adresse)
            AddParameter(oCmd, "@18", pfacture.oExploit.codePostal)
            AddParameter(oCmd, "@19", pfacture.oExploit.commune)
            AddParameter(oCmd, "@20", pfacture.oExploit.telephoneFixe)
            AddParameter(oCmd, "@21", pfacture.oExploit.telephonePortable)
            AddParameter(oCmd, "@22", pfacture.oExploit.eMail)
            AddParameter(oCmd, "@23", pfacture.pathPDF)
            AddParameter(oCmd, "@24", CSDate.TOCRODIPString(pfacture.dateModificationAgent))
            AddParameter(oCmd, "@25", CSDate.TOCRODIPString(pfacture.dateModificationCrodip))
            AddParameter(oCmd, "@26", pfacture.idFacture)
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

            Dim oCmd As DbCommand
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
                "@1," & ' 1
                "@2," &'2
                "@3," &'3
                "@4," &'4'
                "@5," &'5'
                "@6," &'6
                "@7," &'7'
                "@8," &'8
                "@9," &'9
                "@10," &'10
                "@11," &'11
                "@12," &'12
                "@13," &'13
                "@14," &'14
                "@15," &'15
                "@16," &'16
                "@17," &'17
                "@18," &'18
                "@19," &'19
                "@20," &'20
                "@21," &'21
                "@22," &'22'
                "@23," &'23
                "@24," &'24
                "@25," &'25
                "@26" & '26
                ");"


            AddParameter(oCmd, "@1", pfacture.idStructure)
            AddParameter(oCmd, "@2", CSDate.TOCRODIPString(pfacture.dateFacture))
            AddParameter(oCmd, "@3", CSDate.TOCRODIPString(pfacture.dateEcheance))
            AddParameter(oCmd, "@4", pfacture.Commentaire)
            AddParameter(oCmd, "@5", pfacture.modeReglement)
            AddParameter(oCmd, "@6", pfacture.isReglee)
            AddParameter(oCmd, "@7", pfacture.refReglement)
            AddParameter(oCmd, "@8", pfacture.TotalHT, DbType.Currency)
            AddParameter(oCmd, "@9", pfacture.TotalTVA, DbType.Currency)
            AddParameter(oCmd, "@10", pfacture.TotalTTC, DbType.Currency)
            AddParameter(oCmd, "@11", pfacture.TxTVA, DbType.Currency)
            AddParameter(oCmd, "@12", pfacture.idDiag)
            AddParameter(oCmd, "@13", pfacture.oExploit.id)
            AddParameter(oCmd, "@14", pfacture.oExploit.raisonSociale)
            AddParameter(oCmd, "@15", pfacture.oExploit.nomExploitant)
            AddParameter(oCmd, "@16", pfacture.oExploit.prenomExploitant)
            AddParameter(oCmd, "@17", pfacture.oExploit.adresse)
            AddParameter(oCmd, "@18", pfacture.oExploit.codePostal)
            AddParameter(oCmd, "@19", pfacture.oExploit.commune)
            AddParameter(oCmd, "@20", pfacture.oExploit.telephoneFixe)
            AddParameter(oCmd, "@21", pfacture.oExploit.telephonePortable)
            AddParameter(oCmd, "@22", pfacture.oExploit.eMail)
            AddParameter(oCmd, "@23", pfacture.pathPDF)
            AddParameter(oCmd, "@24", CSDate.TOCRODIPString(pfacture.dateModificationAgent))
            AddParameter(oCmd, "@25", CSDate.TOCRODIPString(pfacture.dateModificationCrodip))
            AddParameter(oCmd, "@26", pfacture.idFacture)

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
            Dim oCmd As DbCommand
            Dim oDR As DbDataReader
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "SELECT * FROM Facture where idFacture = @1"
            AddParameter(oCmd, "@1", pFactureId)
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
            If Not String.IsNullOrEmpty(oReturn.idFacture) Then
                oReturn.Lignes.AddRange(FactureItemManager.getFactureById(oReturn.idFacture))
            End If
            oCSDB.free()

        Catch ex As Exception
            CSDebug.dispError("FactureManager.getFactureById ERR", ex)
            oReturn = New Facture()
        End Try
        Return oReturn
    End Function
    Public Shared Function getFacturesByNomClient(pNomClient As String) As List(Of Facture)
        Debug.Assert(Not String.IsNullOrEmpty(pNomClient), "pNomClient must be set")

        Dim oReturn As New List(Of Facture)
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As DbCommand
            Dim oDR As DbDataReader
            Dim oFacture As Facture
            oCmd = oCSDB.getConnection().CreateCommand

            oCmd.CommandText = "SELECT FACTURE.* FROM Facture where nomclient Like @1 Or prenomclient like @2 Or rsclient Like @3 ORDER BY dateFacture DESC"
            AddParameter(oCmd, "@1", "%" & pNomClient & "%")
            AddParameter(oCmd, "@2", "%" & pNomClient & "%")
            AddParameter(oCmd, "@3", "%" & pNomClient & "%")
            oDR = oCmd.ExecuteReader()
            While oDR.Read()
                oFacture = New Facture()
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
            CSDebug.dispError("FactureManager.getFactureByNomClient ERR", ex)
            oReturn = New List(Of Facture)()
        End Try
        Return oReturn
    End Function
    Public Shared Function getFacturesByDate(pDateDeb As String, pDateFin As String) As List(Of Facture)
        Debug.Assert(Not String.IsNullOrEmpty(pDateDeb), "pDateDeb must be set")
        Debug.Assert(Not String.IsNullOrEmpty(pDateFin), "pDateFin must be set")

        Dim oReturn As New List(Of Facture)
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As DbCommand
            Dim oDR As DbDataReader
            Dim oFacture As Facture
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "SELECT FACTURE.* FROM Facture where dateFacture >=  @1 and dateFacture <= @2 ORDER BY dateFacture DESC"
            AddParameter(oCmd, "@1", pDateDeb & " 00:00:00")
            AddParameter(oCmd, "@2", pDateFin & " 23:59:59")
            oDR = oCmd.ExecuteReader()
            While oDR.Read()
                oFacture = New Facture()
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
    Public Shared Function getFactures() As List(Of Facture)

        Dim oReturn As New List(Of Facture)
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As DbCommand
            Dim oDR As DbDataReader
            Dim oFacture As Facture
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "SELECT FACTURE.* FROM Facture ORDER BY dateFacture DESC"
            oDR = oCmd.ExecuteReader()
            While oDR.Read()
                oFacture = New Facture()
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
            CSDebug.dispError("FactureManager.getFactures ERR", ex)
            oReturn = New List(Of Facture)()
        End Try
        Return oReturn
    End Function

    Public Shared Function getFacturesByDiagId(pDiagId As String) As List(Of Facture)
        Debug.Assert(Not String.IsNullOrEmpty(pDiagId), "PDiagId must be set")

        Dim oReturn As New List(Of Facture)
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As DbCommand
            Dim oDR As DbDataReader
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "SELECT * FROM Facture where idDiag = @1"
            AddParameter(oCmd, "@1", pDiagId)
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
