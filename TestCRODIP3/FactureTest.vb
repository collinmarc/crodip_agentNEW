Imports System.Text
Imports Crodip_agent
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class FactureTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()

        Dim oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT1"
        oFacture.DateFacture = CDate("06/02/1964")
        oFacture.PathPDF = "public/exports/FACTURE/20211206055027_MCII11_TEST20191014-3_FACT.pdf"
        Assert.IsTrue(FactureManager.save(oFacture))

        oFacture = FactureManager.getFactureById("FACT1")
        Assert.IsNotNull(oFacture)
        Assert.AreEqual("FACT1", oFacture.idFacture)
        Assert.AreEqual(CDate("06/02/1964"), oFacture.DateFacture)
        Assert.AreEqual(Year(DateTime.Now), Year(oFacture.dateModificationAgent))
        Assert.AreEqual("public/exports/FACTURE/20211206055027_MCII11_TEST20191014-3_FACT.pdf", oFacture.PathPDF)

        oFacture.DateEcheance = CDate("03/12/2021")
        oFacture.PathPDF = "FACTURE/TEST1.PDF"
        Assert.IsTrue(FactureManager.save(oFacture))

        oFacture = FactureManager.getFactureById("FACT1")
        Assert.IsNotNull(oFacture)
        Assert.AreEqual(CDate("03/12/2021"), oFacture.DateEcheance)
        Assert.AreEqual("FACTURE/TEST1.PDF", oFacture.PathPDF)

        oFacture.dateModificationAgent = CDate("01/01/1964")
        FactureManager.save(oFacture, True)
        oFacture = FactureManager.getFactureById("FACT1")
        Assert.IsNotNull(oFacture)
        Assert.AreEqual(CDate("01/01/1964"), oFacture.dateModificationAgent)


    End Sub

    <TestMethod()> Public Sub CRUDItem()

        Dim oFacture = New Facture(m_oStructure)
        oFacture.idFacture = "FACT1"
        oFacture.DateFacture = CDate("06/02/1964")
        Assert.IsTrue(FactureManager.save(oFacture))


        Dim olg As lgPrestation
        olg = New lgPrestation("MaCat", "MaPres", 50, 1, oFacture.TxTVA, "")
        oFacture.Lignes.Add(olg)
        olg = New lgPrestation("MaCat2", "MaPres2", 60, 2, oFacture.TxTVA, "")
        oFacture.Lignes.Add(olg)

        Assert.IsTrue(FactureManager.save(oFacture))

        oFacture = FactureManager.getFactureById("FACT1")
        Assert.AreEqual(2, oFacture.Lignes.Count)

        olg = oFacture.Lignes(0)
        Assert.AreEqual("MaCat", olg.Categorie)
        Assert.AreEqual("MaPres", olg.Prestation)
        Assert.AreEqual(50D, olg.PU)
        Assert.AreEqual(1D, olg.Quantite)
        Assert.AreEqual(oFacture.TxTVA, olg.txTVA)
        Assert.AreEqual(oFacture.idFacture, olg.idFacture)
        Assert.AreEqual(1, olg.nFactureItem)

        olg = oFacture.Lignes(1)
        Assert.AreEqual("MaCat2", olg.Categorie)
        Assert.AreEqual("MaPres2", olg.Prestation)
        Assert.AreEqual(60D, olg.PU)
        Assert.AreEqual(2D, olg.Quantite)
        Assert.AreEqual(oFacture.TxTVA, olg.txTVA)
        Assert.AreEqual(oFacture.idFacture, olg.idFacture)
        Assert.AreEqual(2, olg.nFactureItem)


        oFacture.Lignes(0).Quantite = 10
        oFacture.Lignes(1).Quantite = 20

        Assert.IsTrue(FactureManager.save(oFacture))
        oFacture = FactureManager.getFactureById("FACT1")
        Assert.AreEqual(2, oFacture.Lignes.Count)
        olg = oFacture.Lignes(0)
        Assert.AreEqual(10D, olg.Quantite)

        olg = oFacture.Lignes(1)
        Assert.AreEqual(20D, olg.Quantite)


    End Sub
End Class