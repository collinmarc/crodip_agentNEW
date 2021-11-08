Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class ContatCommercialTest

    <TestMethod()> Public Sub TestTotaux()
        Dim oCC As New ContratCommercial()
        oCC.Lignes.Add(New lgPrestation("", "", 10, 15, ""))

        oCC.TxTVA = 20
        Assert.AreEqual(150D, oCC.TotalHT)
        Assert.AreEqual(150D * 0.2D, oCC.TotalTVA)
        Assert.AreEqual(150D * 1.2D, oCC.TotalTTC)

    End Sub

End Class