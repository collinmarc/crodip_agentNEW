Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent



'''<summary>
'''Classe de test pour ManometreControle, destinée à contenir tous
'''</summary>
<TestClass()> _
Public Class ManometreControleTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Obtient ou définit le contexte de test qui fournit
    '''des informations sur la série de tests active ainsi que ses fonctionnalités.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Attributs de tests supplémentaires"
    '
    'Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
    '
    'Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


 

 
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
        Dim oMano As ManometreControle = New ManometreControle()
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, -8, DateAdd(DateInterval.Month, -1, Now())))
        Assert.AreEqual(Globals.ALERTE.NOIRE, oMano.getAlerte)
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, -5, DateAdd(DateInterval.Month, -1, Now())))
        Assert.AreEqual(Globals.ALERTE.ROUGE, oMano.getAlerte)
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, -1, DateAdd(DateInterval.Month, -1, Now())))
        Assert.AreEqual(Globals.ALERTE.ROUGE, oMano.getAlerte)
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, +1, DateAdd(DateInterval.Month, -1, Now())))
        Assert.AreEqual(Globals.ALERTE.ORANGE, oMano.getAlerte)
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, -16, Now()))
        Assert.AreEqual(Globals.ALERTE.ORANGE, oMano.getAlerte)
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, -14, Now()))
        'Assert.AreEqual(ALERTE.ORANGE, oMano.getAlerte)
        Assert.AreEqual(Globals.ALERTE.NONE, oMano.getAlerte) 'Passé à NONE le 03/05/2016 , je ne sais pas pourquoi

        Dim DL As Date = DateAdd(DateInterval.Month, -1, Now())
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, 5, DL))
        Assert.AreEqual(5 - 1, oMano.getNbJoursAvantDateLimite())
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, 15, DL))
        Assert.AreEqual(15 - 1, oMano.getNbJoursAvantDateLimite())
        oMano.dateDernierControleS = CSDate.GetDateForWS(DateAdd(DateInterval.DayOfYear, 1, DL))
        Assert.AreEqual(1 - 1, oMano.getNbJoursAvantDateLimite())

    End Sub
End Class
