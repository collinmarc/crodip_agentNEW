Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.Collections.Generic

<TestClass()> Public Class AlertesTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub ToXml()
        Dim oLst As New List(Of NiveauAlerte)
        Dim oNiveau As NiveauAlerte
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Banc
        oNiveau.Noire = 47
        oNiveau.Rouge = 20
        oNiveau.Orange = 10
        oNiveau.Jaune = 5
        oNiveau.EcartTolere = 7.5D
        oLst.Add(oNiveau)

        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.ManometreControle
        oNiveau.Noire = 147
        oNiveau.Rouge = 120
        oNiveau.Orange = 110
        oNiveau.Jaune = 15
        oNiveau.EcartTolere = 17.5D
        oLst.Add(oNiveau)

        Assert.IsTrue(NiveauAlerte.FTO_writeXml(oLst, "Test.xml"))
        CSFile.open(MySettings.Default.RepertoireParametres & "/" & "Test.xml")
    End Sub

    <TestMethod()> Public Sub LoadFromXml()
        Dim oLst As New List(Of NiveauAlerte)
        Dim oNiveau As NiveauAlerte
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Banc
        oNiveau.Noire = 47
        oNiveau.Rouge = 20
        oNiveau.Orange = 10
        oNiveau.Jaune = 5
        oNiveau.EcartTolere = 7.5D
        oLst.Add(oNiveau)
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.ManometreControle
        oNiveau.Noire = 147
        oNiveau.Rouge = 120
        oNiveau.Orange = 110
        oNiveau.Jaune = 15
        oNiveau.EcartTolere = 17.5D
        oLst.Add(oNiveau)

        Assert.IsTrue(NiveauAlerte.FTO_writeXml(oLst, "Test.xml"))


        Dim olst2 As List(Of NiveauAlerte)

        olst2 = NiveauAlerte.readXML("Test.xml")
        Assert.AreEqual(2, olst2.Count)
        oNiveau = olst2(0)
        Assert.AreEqual(NiveauAlerte.Enum_typeMateriel.Banc, oNiveau.materiel)
        Assert.AreEqual(47, oNiveau.Noire)
        Assert.AreEqual(20, oNiveau.Rouge)
        Assert.AreEqual(10, oNiveau.Orange)
        Assert.AreEqual(5, oNiveau.Jaune)
        Assert.AreEqual(7.5D, oNiveau.EcartTolere)
        oNiveau = olst2(1)
        Assert.AreEqual(NiveauAlerte.Enum_typeMateriel.ManometreControle, oNiveau.materiel)
        Assert.AreEqual(147, oNiveau.Noire)
        Assert.AreEqual(120, oNiveau.Rouge)
        Assert.AreEqual(110, oNiveau.Orange)
        Assert.AreEqual(15, oNiveau.Jaune)
        Assert.AreEqual(17.5D, oNiveau.EcartTolere)

    End Sub
End Class