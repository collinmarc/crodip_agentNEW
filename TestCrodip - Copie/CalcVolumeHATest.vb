Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class CalVumeHATest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestCalDebit1()
        Dim oCalc As New CalcVolumeHa()
        oCalc.PressionDeMesure = 3.5
        oCalc.DebitMoyenPM = 2.8
        oCalc.Pression1 = 3

        Assert.AreEqual(CDec(2.592), Math.Round(oCalc.Debit1, 3))

    End Sub
    <TestMethod()> Public Sub TestCalPression1()
        Dim oCalc As New CalcVolumeHa()
        oCalc.PressionDeMesure = 3.5
        oCalc.DebitMoyenPM = 2.8
        oCalc.Debit1 = 2.592

        Assert.AreEqual(CDec(3.0), Math.Round(oCalc.Pression1, 3))

    End Sub
End Class