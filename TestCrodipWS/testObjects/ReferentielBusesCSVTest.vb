Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CrodipWS

<TestClass()> Public Class ReferentielBusesCSVTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestLoad()
        Dim oReferentiel As New ReferentielBusesCSV()
        Assert.IsTrue(oReferentiel.load("./testFiles/referentiel_buse.csv"))
        Assert.AreNotEqual(oReferentiel.ods.ReferentieBuses.Count, 0)
        Assert.AreEqual(oReferentiel.ods.ReferentieBuses.Select(oReferentiel.ods.ReferentieBuses.TypeBuseColumn.ColumnName & "=''").Count(), 0)
        Assert.AreEqual(oReferentiel.ods.ReferentieBuses.Select(oReferentiel.ods.ReferentieBuses.TypeBuseColumn.ColumnName & "=''").Count(), 0)
    End Sub

    <TestMethod()> Public Sub TestGetMarques()
        Dim oReferentiel As New ReferentielBusesCSV()
        Assert.IsTrue(oReferentiel.load("./testFiles/referentiel_buse.csv"))
        Assert.AreEqual(oReferentiel.ods.ReferentieBuses(0).Marque, "ALBUZ")
        Assert.AreEqual(oReferentiel.getMarques().Count(), 1)
    End Sub
    <TestMethod()> Public Sub TestGetModeles()
        Dim oReferentiel As New ReferentielBusesCSV()
        Assert.IsTrue(oReferentiel.load("./testFiles/referentiel_buse.csv"))
        Assert.AreEqual(oReferentiel.getModeles("Albuz").Count(), 20)
    End Sub
    <TestMethod()> Public Sub TestGetTypesBuse()
        Dim oReferentiel As New ReferentielBusesCSV()
        Assert.IsTrue(oReferentiel.load("./testFiles/referentiel_buse.csv"))
        Assert.AreEqual(oReferentiel.getTypesBuse("Albuz", "AXI").Count(), 1)
        Assert.AreEqual(oReferentiel.getFonctionnementsBuse("Albuz", "AMT").Count(), 1)
        Assert.AreEqual(oReferentiel.getFonctionnementsBuse("Albuz", "MVI")(0), "INJECTION D'AIR LIBRE")
        Assert.AreEqual(oReferentiel.getISOsBuseByMarqueModele("Albuz", "APM").Count(), 1)
        Assert.AreEqual(oReferentiel.getAnglesBuseByMarqueModele("Albuz", "MVI").Count(), 1)
        Assert.AreEqual(oReferentiel.getFonctionnementsBuse("Albuz", "AXI")(0), "STANDARD")

    End Sub
    <TestMethod()> Public Sub TestGetCouleurBuse()
        Dim oReferentiel As New ReferentielBusesCSV()
        Assert.IsTrue(oReferentiel.load("./testFiles/referentiel_buse.csv"))
        Assert.AreEqual(oReferentiel.getCouleursBuseByMarqueModele("Albuz", "AXI").Count, 9)
        Assert.AreEqual(oReferentiel.getCouleursBuseByMarqueModele("Albuz", "AXI")(0), "ORANGE")
        Assert.AreEqual(oReferentiel.getCalibresBuse("Albuz", "AXI", "orange")(0), "10")
        Assert.AreEqual(oReferentiel.getCalibresBuse("Albuz", "AXI", "gris")(0), "6")
        Assert.AreEqual(oReferentiel.getDebit2barBuse("Albuz", "AXI", "gris")(0), "")
        Assert.AreEqual(oReferentiel.getDebit3barBuse("Albuz", "AXI", "gris")(0), "2.4")
        Assert.AreEqual(oReferentiel.getDebit5barBuse("Albuz", "AXI", "gris")(0), "")
        Assert.AreEqual(oReferentiel.getToleranceBuse("Albuz", "AXI", "gris")(0), "10")
        Assert.AreEqual(oReferentiel.getToleranceBuse("Albuz", "AXI", "orange")(0), "15")


    End Sub

    ''' <summary>
    ''' Test du chagrement du fichier avec les Angles 90-120
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestAngles()
        Dim oReferentiel As New ReferentielBusesCSV()
        Assert.IsTrue(oReferentiel.load("./testFiles/REFERENTIEL_BUSEAngles.csv"))
        Assert.AreEqual(1, oReferentiel.getAnglesBuseByMarqueModele("Albuz", "AXI").Count)
        Assert.AreEqual(2, oReferentiel.getAnglesBuseByMarqueModele("Albuz", "FASTCAP AXI").Count)
        Assert.AreEqual(3, oReferentiel.getAnglesBuseByMarqueModele("Albuz", "FASTCAP AXI2").Count)


    End Sub
End Class