Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CrodipWS

<TestClass()> Public Class ContatCommercialTest

    <TestMethod()> Public Sub TestTotaux()
        Dim oCC As New ContratCommercial()
        oCC.TxTVA = 20
        oCC.Lignes.Add(New FactureItem("", "", 10, 15, oCC.TxTVA, ""))
        oCC.CalculTotaux()
        Assert.AreEqual(150D, oCC.TotalHT)
        Assert.AreEqual(150D * 0.2D, oCC.TotalTVA)
        Assert.AreEqual(150D * 1.2D, oCC.TotalTTC)

    End Sub

End Class