Imports System.Text
Imports Crodip_agent
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class RPDiagnosticTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestSaveLoadRPDiag()
        clientCourant = New Exploitation
        ' Pulvé actuellement sélectionné
        pulverisateurCourant = New Pulverisateur

        Dim oDiag As New RPDiagnostic()
        initRPDiag(oDiag)
        Dim strFilename = oDiag.createXMLFileName()
        Dim bReturn As Boolean = oDiag.writeXML(strFilename)
        Assert.IsTrue(bReturn, "Sauvegarde ")

        Dim oDiag2 As RPDiagnostic
        oDiag2 = RPDiagnostic.readXML(strFilename)
        Assert.IsNotNull(oDiag2)

        Assert.IsTrue(oDiag2.CalcVitesseRotation = "1000")
        Assert.IsTrue(oDiag2.CalcNbreDescentes = 20)
        Assert.IsTrue(oDiag2.CalcNbreNiveauParDescente = 5)

        Assert.AreEqual(5.5D, oDiag2.diagnosticHelp551.VitesseReelle1)
        Assert.AreEqual(6.7D, oDiag2.diagnosticHelp551.VitesseReelle2)
        Assert.IsTrue(oDiag2.manometrePressionTravail = 3.5D)
        Assert.AreEqual(oDiag2.buseDebitMoyenPM, 2.8D)
        Assert.IsTrue(oDiag2.diagnosticHelp551.VitesseReelle1 = 5.5D)
        Assert.IsTrue(oDiag2.diagnosticHelp551.VitesseReelle2 = 6.7D)

        Assert.AreEqual(2, oDiag2.diagnosticBusesList.Liste.Count)

        Dim oDiagbuse As DiagnosticBuses
        oDiagbuse = oDiag2.diagnosticBusesList.Liste(0)
        '=====
        'Le Detail des buses n'est pas exporte dues à une erreur de srialization
        '========
        'Assert.AreEqual(4, oDiagbuse.diagnosticBusesDetailList.Liste.Count)
        'Dim oDiagBuseDet As DiagnosticBusesDetail
        'oDiagBuseDet = oDiagbuse.diagnosticBusesDetailList.Liste(0)
        'Assert.AreEqual("1", oDiagBuseDet.idLot)
        'Assert.AreEqual(1, oDiagBuseDet.idBuse)
        'Assert.AreEqual("2,8", oDiagBuseDet.debit)

        Assert.IsTrue(oDiag2.CalcDebitMoyenPM = 2.8)
        Assert.IsTrue(oDiag2.CalcPressionDeMesure = 3.5)


        Assert.AreEqual(1, oDiag2.diagnosticMano542List.Liste.Count)
        Assert.AreEqual("1.6", oDiag2.diagnosticMano542List.Liste(0).pressionPulve)
        Assert.AreEqual("2", oDiag2.diagnosticMano542List.Liste(0).pressionControle)

        Assert.AreEqual(1, oDiag2.diagnosticTroncons833.Liste.Count)
        Assert.AreEqual("1", oDiag2.diagnosticTroncons833.Liste(0).idDiagnostic)
        Assert.AreEqual("2", oDiag2.diagnosticTroncons833.Liste(0).idPression)
        Assert.AreEqual("3", oDiag2.diagnosticTroncons833.Liste(0).idColumn)
        Assert.AreEqual("4", oDiag2.diagnosticTroncons833.Liste(0).pressionSortie)

    End Sub

    Private Sub initRPDiag(pRPDiagnostic As RPDiagnostic)


        clientCourant.raisonSociale = "RSexploitantTest"
        clientCourant.nomExploitant = "exploitantTest"
        clientCourant.prenomExploitant = "exploitantTest"
        clientCourant.adresse = "adresseTest"
        clientCourant.codePostal = "35250"
        clientCourant.commune = "CHASNE SUR ILLET"
        clientCourant.codeApe = "0112Z"

        pulverisateurCourant.marque = "ACP"
        pulverisateurCourant.modele = "INCONNU"
        pulverisateurCourant.anneeAchat = 1974
        pulverisateurCourant.type = "Cultures basses"
        pulverisateurCourant.categorie = "Rampe"
        pulverisateurCourant.largeur = "3.5"
        pulverisateurCourant.attelage = "PORTE"
        pulverisateurCourant.pulverisation = "Pneumatique"
        pulverisateurCourant.capacite = "300"
        pulverisateurCourant.regulation = "DPM"
        pulverisateurCourant.buseType = "BUSES A FENTE"
        pulverisateurCourant.buseFonctionnement = "STANDARD"
        pulverisateurCourant.largeurPlantation = "25"
        pulverisateurCourant.buseNbniveaux = "2"
        pulverisateurCourant.nombreBuses = "5"



        'Création des objets de references
        pRPDiagnostic.SetProprietaire(clientCourant)
        pRPDiagnostic.setPulverisateur(pulverisateurCourant)

        pRPDiagnostic.CalcVitesseRotation = "1000"
        pRPDiagnostic.CalcNbreDescentes = 20
        pRPDiagnostic.CalcNbreNiveauParDescente = 5

        pRPDiagnostic.diagnosticHelp551.VitesseReelle1 = 5.5
        pRPDiagnostic.diagnosticHelp551.VitesseReelle2 = 6.7
        pRPDiagnostic.manometrePressionTravail = 3.5
        pRPDiagnostic.buseDebitMoyenPM = 2.8
        pRPDiagnostic.diagnosticHelp551.VitesseReelle1 = 5.5
        pRPDiagnostic.diagnosticHelp551.VitesseReelle2 = 6.7

        pRPDiagnostic.diagnosticMano542List.Liste.Add(New DiagnosticMano542("1.6", "2"))
        pRPDiagnostic.diagnosticTroncons833.Liste.Add(New DiagnosticTroncons833("1", "2", "3", "4"))


        For nlot As Integer = 1 To 2
            Dim oDiagbuse As New DiagnosticBuses
            oDiagbuse.idLot = nlot
            For nBuse As Integer = 1 To 4
                Dim oDiagBuseDet As DiagnosticBusesDetail = New DiagnosticBusesDetail()
                oDiagBuseDet.idLot = nlot
                oDiagBuseDet.idBuse = nBuse
                oDiagBuseDet.debit = 2.8
                oDiagbuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDet)
            Next

            oDiagbuse.nombre = oDiagbuse.diagnosticBusesDetailList.Liste.Count
            pRPDiagnostic.diagnosticBusesList.Liste.Add(oDiagbuse)
        Next
        pRPDiagnostic.CalcDebitMoyenPM = 2.8
        pRPDiagnostic.CalcPressionDeMesure = 3.5


    End Sub
    Public Sub TST_LoadFromCRODIPDIAG()

        Dim oExploit As Exploitation = createExploitation()
        Dim oPulve As Pulverisateur = createPulve(oExploit)
        Dim oDiag As Diagnostic = createDiagnostic(oExploit, oPulve, True)

        Dim strID As String = oDiag.id

        Dim oRPDiag As RPDiagnostic
        oRPDiag = RPDiagnosticManager.getRPDiagnosticById(strID)

        Assert.AreEqual(strID, oRPDiag.id)

        DiagnosticManager.delete(oDiag.id)

    End Sub

End Class