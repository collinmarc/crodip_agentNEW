Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CrodipWS

<TestClass()> Public Class ReferentielCommunesCSVTest
    'Inherits CRODIPTest

    <TestMethod()> Public Sub TestLoad()
        Dim oReferentiel As New ReferentielCommunesCSV()
        Assert.IsTrue(oReferentiel.load())
        Assert.AreNotEqual(oReferentiel.ods.Communes.Count, 0)
        Assert.AreEqual(oReferentiel.ods.Communes.Select(oReferentiel.ods.Communes.NomCommuneColumn.ColumnName & "=''").Count(), 0)
        Assert.AreEqual(oReferentiel.ods.Communes.Select(oReferentiel.ods.Communes.CodePostalColumn.ColumnName & "=''").Count(), 0)
    End Sub

    <TestMethod()> Public Sub TestCommunes()
        Dim oReferentiel As New ReferentielCommunesCSV()
        Assert.IsTrue(oReferentiel.load())

        Assert.AreEqual(9, oReferentiel.getCommunes("35250").Count())
        Assert.AreEqual("35067", oReferentiel.getCodeINSEE("35250", "CHASNE SUR ILLET"))
    End Sub
    <TestMethod()> Public Sub TestoDS()
        Dim oReferentiel As New ReferentielCommunesCSV()
        Assert.IsTrue(oReferentiel.load())

        Dim odv As DataView
        Assert.AreNotEqual(0, oReferentiel.ods.Communes.Rows.Count)
        Dim odt As DataTable
        odv = New DataView(oReferentiel.ods.Communes)
        odv.RowFilter = " CodePostal = '35250'"
        Assert.AreNotEqual(0, odv.Count)
        odt = odv.ToTable()
        Assert.AreNotEqual(0, odt.Rows.Count)
    End Sub
End Class