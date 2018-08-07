Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent



'''<summary>
'''Classe de test pour ManometreControle, destinée à contenir tous
'''</summary>
<TestClass()> _
Public Class ManometreControleTest
    Inherits CRODIPTest


    '''<summary>
    '''Test pour resolution
    '''</summary>
    <TestMethod()> _
    Public Sub resolutionTest()
        Dim target As ManometreControle = New ManometreControle()
        Dim expected As String = String.Empty ' TODO: initialisez à une valeur appropriée
        target.resolution = "15.5"
        Assert.AreEqual("15.5", target.resolution)
        Assert.AreEqual(15.5, target.resolution_d)
        target.resolution = "15,5"
        Assert.AreEqual("15,5", target.resolution)
        Assert.AreEqual(15.5, target.resolution_d)
        target.resolution = ""
        Assert.AreEqual(0.0, target.resolution_d)
        target.resolution = "ABCD"
        Assert.AreEqual(0.0, target.resolution_d)
    End Sub

    <TestMethod()> _
    Public Sub TST_ALertes()
        'Generation du fichier de paramétrage
        Dim oLst As New List(Of NiveauAlerte)
        Dim oNiveau As NiveauAlerte
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Banc
        oNiveau.Noire = 47
        oNiveau.Rouge = 20
        oNiveau.Orange = 10
        oNiveau.Jaune = 5
        oNiveau.EcartTolere = 7.5
        oLst.Add(oNiveau)
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.ManometreControle
        oNiveau.Noire = 147
        oNiveau.Rouge = 120
        oNiveau.Orange = 110
        oNiveau.Jaune = 15
        oNiveau.EcartTolere = 17.5
        oLst.Add(oNiveau)

        Assert.IsTrue(NiveauAlerte.FTO_writeXml(oLst))



        Dim oMano As ManometreControle = New ManometreControle()
        oMano.dateDernierControle = DateAdd(DateInterval.DayOfYear, -148, Now())
        Assert.AreEqual(Globals.ALERTE.NOIRE, oMano.getAlerte)
        oMano.dateDernierControle = DateAdd(DateInterval.DayOfYear, -121, Now())
        Assert.AreEqual(Globals.ALERTE.ROUGE, oMano.getAlerte)
        oMano.dateDernierControle = DateAdd(DateInterval.DayOfYear, -111, Now())
        Assert.AreEqual(Globals.ALERTE.ORANGE, oMano.getAlerte)
        oMano.dateDernierControle = DateAdd(DateInterval.DayOfYear, -16, Now())
        Assert.AreEqual(Globals.ALERTE.JAUNE, oMano.getAlerte)
        oMano.dateDernierControle = DateAdd(DateInterval.DayOfYear, -14, Now())
        Assert.AreEqual(Globals.ALERTE.NONE, oMano.getAlerte)

        Dim DL As Date = DateAdd(DateInterval.Month, -1, Now())
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, 5, DL))
        Assert.AreEqual(5 - 1, oMano.getNbJoursAvantDateLimite())
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, 15, DL))
        Assert.AreEqual(15 - 1, oMano.getNbJoursAvantDateLimite())
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, 1, DL))
        Assert.AreEqual(1 - 1, oMano.getNbJoursAvantDateLimite())

    End Sub
End Class
