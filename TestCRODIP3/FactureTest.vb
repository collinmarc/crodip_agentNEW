Imports System.Text
Imports Crodip_agent
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class FactureTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()

        Dim oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT1"
        oFacture.dateFacture = CDate("06/02/1964")
        oFacture.TotalHT = 125.5
        oFacture.pathPDF = "public/exports/FACTURE/20211206055027_MCII11_TEST20191014-3_FACT.pdf"
        Assert.IsTrue(FactureManager.save(oFacture))

        oFacture = FactureManager.getFactureById("FACT1")
        Assert.IsNotNull(oFacture)
        Assert.AreEqual("FACT1", oFacture.idFacture)
        Assert.AreEqual(CDate("06/02/1964"), oFacture.dateFacture)
        Assert.AreEqual(Year(DateTime.Now), Year(oFacture.dateModificationAgent))
        Assert.AreEqual(125.5D, oFacture.TotalHT)
        Assert.AreEqual("public/exports/FACTURE/20211206055027_MCII11_TEST20191014-3_FACT.pdf", oFacture.pathPDF)

        oFacture.dateEcheance = CDate("03/12/2021")
        oFacture.pathPDF = "FACTURE/TEST1.PDF"
        Assert.IsTrue(FactureManager.save(oFacture))

        oFacture = FactureManager.getFactureById("FACT1")
        Assert.IsNotNull(oFacture)
        Assert.AreEqual(CDate("03/12/2021"), oFacture.dateEcheance)
        Assert.AreEqual("FACTURE/TEST1.PDF", oFacture.pathPDF)

        oFacture.dateModificationAgent = CDate("01/01/1964")
        FactureManager.save(oFacture, True)
        oFacture = FactureManager.getFactureById("FACT1")
        Assert.IsNotNull(oFacture)
        Assert.AreEqual(CDate("01/01/1964"), oFacture.dateModificationAgent)


    End Sub

    <TestMethod()> Public Sub CRUDItem()

        Dim oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT1"
        oFacture.dateFacture = CDate("06/02/1964")
        Assert.IsTrue(FactureManager.save(oFacture))


        Dim olg As FactureItem
        olg = New FactureItem("MaCat", "MaPres", 50, 0.5, oFacture.TxTVA, "")
        oFacture.Lignes.Add(olg)
        olg = New FactureItem("MaCat2", "MaPres2", 60, 2, oFacture.TxTVA, "")
        oFacture.Lignes.Add(olg)

        Assert.IsTrue(FactureManager.save(oFacture))

        oFacture = FactureManager.getFactureById("FACT1")
        Assert.AreEqual(2, oFacture.Lignes.Count)

        olg = oFacture.Lignes(0)
        Assert.AreEqual("MaCat", olg.categorie)
        Assert.AreEqual("MaPres", olg.prestation)
        Assert.AreEqual(50D, olg.pu)
        Assert.AreEqual(0.5D, olg.quantite)
        Assert.AreEqual(oFacture.TxTVA, olg.txTVA)
        Assert.AreEqual(oFacture.idFacture, olg.idFacture)
        Assert.AreEqual(1, olg.nFactureItem)

        olg = oFacture.Lignes(1)
        Assert.AreEqual("MaCat2", olg.categorie)
        Assert.AreEqual("MaPres2", olg.prestation)
        Assert.AreEqual(60D, olg.pu)
        Assert.AreEqual(2D, olg.quantite)
        Assert.AreEqual(oFacture.TxTVA, olg.txTVA)
        Assert.AreEqual(oFacture.idFacture, olg.idFacture)
        Assert.AreEqual(2, olg.nFactureItem)


        oFacture.Lignes(0).quantite = 10
        oFacture.Lignes(1).quantite = 20

        Assert.IsTrue(FactureManager.save(oFacture))
        oFacture = FactureManager.getFactureById("FACT1")
        Assert.AreEqual(2, oFacture.Lignes.Count)
        olg = oFacture.Lignes(0)
        Assert.AreEqual(10D, olg.quantite)

        olg = oFacture.Lignes(1)
        Assert.AreEqual(20D, olg.quantite)


    End Sub


    <TestMethod()> Public Sub RechercheParNomClient()

        Dim oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT1"
        oFacture.dateFacture = CDate("06/02/1964")
        oFacture.oExploit.nomExploitant = "RIEN"
        Assert.IsTrue(FactureManager.save(oFacture))

        oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT2"
        oFacture.dateFacture = CDate("06/02/1964")
        oFacture.oExploit.nomExploitant = "TEST"
        Assert.IsTrue(FactureManager.save(oFacture))

        'Premeire Recherche
        Dim oResult As List(Of Facture)
        oResult = FactureManager.getFacturesByNomClient("TES")
        Assert.AreEqual(1, oResult.Count)
        Assert.AreEqual("TEST", oResult(0).oExploit.nomExploitant)

        'Ajout d'une Nouvelle Facture
        oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT3"
        oFacture.dateFacture = CDate("06/02/1964")
        oFacture.oExploit.prenomExploitant = "TEST"
        Assert.IsTrue(FactureManager.save(oFacture))

        'Seconde Recherche
        oResult = FactureManager.getFacturesByNomClient("TES")
        Assert.AreEqual(2, oResult.Count)
        Assert.AreEqual("TEST", oResult(1).oExploit.prenomExploitant)

        'Ajout d'une Nouvelle Facture
        oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT4"
        oFacture.dateFacture = CDate("06/02/1964")
        oFacture.oExploit.raisonSociale = "TEST"
        Assert.IsTrue(FactureManager.save(oFacture))

        'Troisième Recherche
        oResult = FactureManager.getFacturesByNomClient("TES")
        Assert.AreEqual(3, oResult.Count)
        Assert.AreEqual("TEST", oResult(2).oExploit.raisonSociale)
    End Sub
    <TestMethod()> Public Sub RechercheParDate()

        Dim oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT1"
        oFacture.dateFacture = CDate("06/02/1964")
        oFacture.oExploit.nomExploitant = "RIEN"
        Assert.IsTrue(FactureManager.save(oFacture))

        oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT2"
        oFacture.dateFacture = CDate("15/12/2021")
        oFacture.oExploit.nomExploitant = "TEST"
        Assert.IsTrue(FactureManager.save(oFacture))

        'Premeire Recherche
        Dim oResult As List(Of Facture)
        oResult = FactureManager.getFacturesByDate("01/01/2021", "31/12/2021")
        Assert.AreEqual(1, oResult.Count)
        Assert.AreEqual(CDate("15/12/2021"), oResult(0).dateFacture)

        'Ajout d'une Nouvelle Facture
        oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT3"
        oFacture.dateFacture = CDate("20/12/2021")
        oFacture.oExploit.prenomExploitant = "TEST"
        Assert.IsTrue(FactureManager.save(oFacture))

        'Seconde Recherche
        oResult = FactureManager.getFacturesByDate("01/01/2021", "31/12/2021")
        Assert.AreEqual(2, oResult.Count)
        Assert.AreEqual(CDate("20/12/2021"), oResult(1).dateFacture)

        'Ajout d'une Nouvelle Facture
        oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT4"
        oFacture.dateFacture = CDate("15/01/2022")
        oFacture.oExploit.raisonSociale = "TEST"
        Assert.IsTrue(FactureManager.save(oFacture))

        'Troisième Recherche
        oResult = FactureManager.getFacturesByNomClient("TES")
        oResult = FactureManager.getFacturesByDate("01/01/2021", "31/12/2021")
        Assert.AreEqual(2, oResult.Count)

    End Sub
End Class