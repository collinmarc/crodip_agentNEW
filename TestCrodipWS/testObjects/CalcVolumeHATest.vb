Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class CalVumeHATest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestCalDebit1()
        Dim oCalc As New CalcVolumeHa()
        oCalc.PressionDeMesure = 3.5D
        oCalc.DebitMoyenPM = 2.8D
        oCalc.Pression1 = 3D

        Assert.AreEqual(CDec(2.592), Math.Round(oCalc.Debit1, 3))

    End Sub
End Class