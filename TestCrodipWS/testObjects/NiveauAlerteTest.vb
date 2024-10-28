Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CrodipWS
Imports System.Collections.Generic

<TestClass()>
Public Class Alertes2Test
    Inherits CRODIPTest

    <TestMethod()>
    Public Sub ToXml()
        Dim oAlertes As New Alertes()


        Dim oNiveau As NiveauAlerte
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Banc
        oNiveau.Noire = 47
        oNiveau.Rouge = 20
        oNiveau.Orange = 10
        oNiveau.Jaune = 5
        oNiveau.EcartTolere = 7.5D
        oAlertes.NiveauxAlertes.Add(oNiveau)

        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.ManometreControle
        oNiveau.Noire = 147
        oNiveau.Rouge = 120
        oNiveau.Orange = 110
        oNiveau.Jaune = 15
        oNiveau.EcartTolere = 17.5D
        oAlertes.NiveauxAlertes.Add(oNiveau)

        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Pulverisateur
        oNiveau.Rouge = 4
        oNiveau.Jaune = 36

        oAlertes.NiveauxAlertes.Add(oNiveau)
        Assert.IsTrue(Alertes.FTO_writeXml(oAlertes, "Test.xml"))
        CSFile.open(My.Settings.RepertoireParametres & "/" & "Test.xml")
    End Sub

    <TestMethod()> Public Sub LoadFromXml()
        Dim oAlertes As New Alertes
        Dim oNiveau As NiveauAlerte
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Banc
        oNiveau.Noire = 47
        oNiveau.Rouge = 20
        oNiveau.Orange = 10
        oNiveau.Jaune = 5
        oNiveau.EcartTolere = 7.5D
        oAlertes.NiveauxAlertes.Add(oNiveau)
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.ManometreControle
        oNiveau.Noire = 147
        oNiveau.Rouge = 120
        oNiveau.Orange = 110
        oNiveau.Jaune = 15
        oNiveau.EcartTolere = 17.5D
        oAlertes.NiveauxAlertes.Add(oNiveau)

        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Pulverisateur
        oNiveau.Rouge = 4
        oNiveau.Jaune = 60
        oNiveau.DateEffet = #1/1/2020#
        oAlertes.NiveauxAlertes.Add(oNiveau)

        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Pulverisateur
        oNiveau.Rouge = 4
        oNiveau.Jaune = 36
        oNiveau.DateEffet = #1/1/2021#
        oAlertes.NiveauxAlertes.Add(oNiveau)

        Assert.IsTrue(Alertes.FTO_writeXml(oAlertes, "Test.xml"))


        Dim oAlertes2 As Alertes

        oAlertes2 = Alertes.readXML("Test.xml")
        Assert.AreEqual(4, oAlertes2.NiveauxAlertes.Count)
        oNiveau = oAlertes2.NiveauxAlertes(0)
        Assert.AreEqual(NiveauAlerte.Enum_typeMateriel.Banc, oNiveau.Materiel)
        Assert.AreEqual(47, oNiveau.Noire)
        Assert.AreEqual(20, oNiveau.Rouge)
        Assert.AreEqual(10, oNiveau.Orange)
        Assert.AreEqual(5, oNiveau.Jaune)
        Assert.AreEqual(7.5D, oNiveau.EcartTolere)
        oNiveau = oAlertes2.NiveauxAlertes(1)
        Assert.AreEqual(NiveauAlerte.Enum_typeMateriel.ManometreControle, oNiveau.Materiel)
        Assert.AreEqual(147, oNiveau.Noire)
        Assert.AreEqual(120, oNiveau.Rouge)
        Assert.AreEqual(110, oNiveau.Orange)
        Assert.AreEqual(15, oNiveau.Jaune)
        Assert.AreEqual(17.5D, oNiveau.EcartTolere)

        oNiveau = oAlertes2.NiveauxAlertes(2)
        Assert.AreEqual(NiveauAlerte.Enum_typeMateriel.Pulverisateur, oNiveau.Materiel)
        Assert.AreEqual(4, oNiveau.Rouge)
        Assert.AreEqual(60, oNiveau.Jaune)
        Assert.AreEqual(#01/01/2020#, oNiveau.DateEffet)
        oNiveau = oAlertes2.NiveauxAlertes(3)
        Assert.AreEqual(NiveauAlerte.Enum_typeMateriel.Pulverisateur, oNiveau.Materiel)
        Assert.AreEqual(4, oNiveau.Rouge)
        Assert.AreEqual(36, oNiveau.Jaune)
        Assert.AreEqual(#01/01/2021#, oNiveau.DateEffet)

    End Sub
End Class