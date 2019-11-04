Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour RelevePression833, RelevePression833Niveau , RelevePression833Troncon
''' destinée à contenir tous les tests unitaires 
'''</summary>
<TestClass()> _
Public Class RelevePression833Test
    Inherits CRODIPTest

    Private testContextInstance As TestContext

    '''<summary>
    '''Obtient ou définit le contexte de test qui fournit
    '''des informations sur la série de tests active ainsi que ses fonctionnalités.
    '''</summary>

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
#End Region


    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Object()
        Dim oReleve As RelevePression833
        Dim oNiveau As RelevePression833Niveau
        Dim oTroncon As RelevePression833Troncon
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833

        oReleve = New RelevePression833(2, 4, 4, oParam833)
        Assert.AreEqual(2, oReleve.colNiveaux.Count)
        For Each oNiveau In oReleve.colNiveaux
            Assert.AreEqual(4, oNiveau.colTroncons.Count)
        Next

        oReleve.SetPressionMano(3.5D)
        Assert.AreEqual(3.5D, oReleve.PressionMano)
        For Each oNiveau In oReleve.colNiveaux
            Assert.AreEqual(3.5D, oNiveau.PressionMano)
            For Each oTroncon In oNiveau.colTroncons
                Assert.AreEqual(3.5D, oTroncon.PressionMano)
            Next
        Next

    End Sub


    <TestMethod()> _
    Public Sub TST_SetPressionLue()
        Dim oReleve As RelevePression833
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833

        oReleve = New RelevePression833(2, 4, 3, oParam833)
        oReleve.SetPressionLue(1, 1, 2.6D)
        oReleve.SetPressionLue(1, 2, 2.7D)
        oReleve.SetPressionLue(1, 3, 2.8D)
        oReleve.SetPressionLue(1, 4, 2.7D)

        Assert.AreEqual(2.6D, oReleve.colNiveaux(0).colTroncons(0).PressionLue)
        Assert.AreEqual(2.7D, oReleve.colNiveaux(0).colTroncons(1).PressionLue)
        Assert.AreEqual(2.8D, oReleve.colNiveaux(0).colTroncons(2).PressionLue)
        Assert.AreEqual(2.7D, oReleve.colNiveaux(0).colTroncons(3).PressionLue)
    End Sub

    <TestMethod()> _
    Public Sub TST_EcartPression()
        Dim oReleve As RelevePression833
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833

        oReleve = New RelevePression833(2, 4, 3, oParam833)
        oReleve.SetPressionLue(1, 1, 2.6D)
        oReleve.SetPressionLue(1, 2, 2.7D)
        oReleve.SetPressionLue(1, 3, 2.8D)
        oReleve.SetPressionLue(1, 4, 2.7D)

        Assert.AreEqual(0.4D, oReleve.colNiveaux(0).colTroncons(0).EcartPression)
        Assert.AreEqual(0.3D, oReleve.colNiveaux(0).colTroncons(1).EcartPression)
        Assert.AreEqual(0.2D, oReleve.colNiveaux(0).colTroncons(2).EcartPression)
        Assert.AreEqual(0.3D, oReleve.colNiveaux(0).colTroncons(3).EcartPression)

        Assert.AreEqual(15.38D, oReleve.colNiveaux(0).colTroncons(0).EcartPressionpct)
        Assert.AreEqual(11.11D, oReleve.colNiveaux(0).colTroncons(1).EcartPressionpct)
        Assert.AreEqual(7.14D, oReleve.colNiveaux(0).colTroncons(2).EcartPressionpct)
        Assert.AreEqual(11.11D, oReleve.colNiveaux(0).colTroncons(3).EcartPressionpct)

        Assert.AreEqual(2.7D, oReleve.colNiveaux(0).MoyenneTousTroncons)

        Assert.AreEqual(0.3D, oReleve.colNiveaux(0).EcartMoyenneTousTroncons)

        Assert.AreEqual(11.11D, oReleve.colNiveaux(0).EcartMoyenneTousTroncons_pct)

        Assert.AreEqual(15.38D, oReleve.colNiveaux(0).EcartMax_pct)
        Assert.AreEqual(0.4D, oReleve.colNiveaux(0).EcartMax)

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_CalculDefaut()

        Dim oPression As RelevePression833
        Dim olst As List(Of CRODIP_ControlLibrary.ParamDiag)
        olst = CRODIP_ControlLibrary.ParamDiag.readXML()
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = olst(0).ParamDiagCalc833 ' Culture basse

        '1 Niveau , 4 Tronçons, 3.0 de pression
        oPression = New RelevePression833(1, 4, 3D, oParam833)

        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(2.6D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(2.6D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(2.6D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(2.6D)
        oPression.calcDefauts()

        Assert.IsTrue(oPression.Result_isDefautEcart)
        Assert.IsFalse(oPression.Result_isDefautHeterogeneite)


        '1 Niveau , 4 Tronçons, 5.0 de pression
        oPression = New RelevePression833(1, 5, 5D, oParam833)
        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(4D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(4.75D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(4.8D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(4.15D)
        oPression.colNiveaux(0).colTroncons(4).SetPressionLue(4.2D)
        oPression.calcDefauts()

        Assert.AreEqual(CDec(0.62), oPression.colNiveaux(0).EcartMoyenneTousTroncons)
        Assert.AreEqual(CDec(14.16), oPression.colNiveaux(0).EcartMoyenneTousTroncons_pct)
        Assert.AreEqual(CDec(4.38), oPression.colNiveaux(0).MoyenneTousTroncons)

        Assert.IsTrue(oPression.Result_isDefautEcart)
        Assert.IsTrue(oPression.Result_isDefautHeterogeneite)

        '1 Niveau , 4 Tronçons, 5.0 de pression
        oPression = New RelevePression833(1, 5, 5D, oParam833)
        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(4D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(4.75D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(4.8D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(4.2D)
        oPression.colNiveaux(0).colTroncons(4).SetPressionLue(4.2D)
        oPression.calcDefauts()

        Assert.AreEqual(CDec(0.61), oPression.colNiveaux(0).EcartMoyenneTousTroncons)
        Assert.AreEqual(CDec(13.9), oPression.colNiveaux(0).EcartMoyenneTousTroncons_pct)
        Assert.AreEqual(CDec(4.39), oPression.colNiveaux(0).MoyenneTousTroncons)

        Assert.IsTrue(oPression.Result_isDefautEcart)
        Assert.IsTrue(oPression.Result_isDefautHeterogeneite)

    End Sub

    <TestMethod()> _
    Public Sub TST_CalculEcartMax()
        Dim oPression As RelevePression833
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833

        '1 Niveau , 4 Tronçons, 3.0 de pression
        oPression = New RelevePression833(1, 4, 3D, oParam833)
        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(2.6D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(3.2D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(3D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(3D)
        oPression.calcDefauts()

        Assert.AreEqual(0.4D, oPression.colNiveaux(0).EcartMax)
        Assert.AreEqual(15.38D, oPression.colNiveaux(0).EcartMax_pct)

        '1 Niveau , 4 Tronçons, 3.0 de pression
        oPression = New RelevePression833(1, 4, 3D, oParam833)
        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(2.8D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(3.4D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(3D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(3D)
        oPression.calcDefauts()

        Assert.AreEqual(-0.4D, oPression.colNiveaux(0).EcartMax)
        Assert.AreEqual(-11.76D, oPression.colNiveaux(0).EcartMax_pct)
    End Sub
    <TestMethod()> _
    Public Sub TST_CalculITEQ()
        Dim oPression As RelevePression833
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833

        '1 Niveau , 4 Tronçons, 3.0 de pression
        oPression = New RelevePression833(1, 4, 4, oParam833)
        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(3.7D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(3.75D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(3.8D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(3.7D)
        oPression.calcDefauts()

        Assert.AreEqual(0.3D, oPression.colNiveaux(0).EcartMax)
        Assert.AreEqual(8.11D, oPression.colNiveaux(0).EcartMax_pct)

        Assert.AreEqual(3.74D, oPression.colNiveaux(0).MoyenneTousTroncons)
        Assert.AreEqual(0.26D, oPression.colNiveaux(0).EcartMoyenneTousTroncons)
        Assert.AreEqual(7.02D, oPression.colNiveaux(0).EcartMoyenneTousTroncons_pct)

        Assert.AreEqual(3.75D, oPression.colNiveaux(0).colTroncons(0).MoyenneAutresTroncons)
        Assert.AreEqual(3.73D, oPression.colNiveaux(0).colTroncons(1).MoyenneAutresTroncons)
        Assert.AreEqual(3.72D, oPression.colNiveaux(0).colTroncons(2).MoyenneAutresTroncons)
        Assert.AreEqual(3.75D, oPression.colNiveaux(0).colTroncons(3).MoyenneAutresTroncons)

        Assert.AreEqual(-0.05D, oPression.colNiveaux(0).colTroncons(0).EcartMoyenneAutresTroncons)
        Assert.AreEqual(0.02D, oPression.colNiveaux(0).colTroncons(1).EcartMoyenneAutresTroncons)
        Assert.AreEqual(0.08D, oPression.colNiveaux(0).colTroncons(2).EcartMoyenneAutresTroncons)
        Assert.AreEqual(-0.05D, oPression.colNiveaux(0).colTroncons(3).EcartMoyenneAutresTroncons)

        Assert.AreEqual(-1.33D, oPression.colNiveaux(0).colTroncons(0).Heterogeneite)
        Assert.AreEqual(0.45D, oPression.colNiveaux(0).colTroncons(1).Heterogeneite)
        Assert.AreEqual(2.24D, oPression.colNiveaux(0).colTroncons(2).Heterogeneite)
        Assert.AreEqual(-1.33D, oPression.colNiveaux(0).colTroncons(3).Heterogeneite)
    End Sub
    <TestMethod()> _
    Public Sub TST_Result()
        Dim oPression As RelevePression833
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833
        '1 Niveau , 4 Tronçons, 3.0 de pression
        oPression = New RelevePression833(1, 4, 4, oParam833)
        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(3.7D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(3.75D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(3.8D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(3.7D)
        oPression.calcDefauts()

        Assert.AreEqual(0.3D, oPression.colNiveaux(0).EcartMax)
        Assert.AreEqual(8.11D, oPression.Result_PerteChargeMaxi)

        Assert.AreEqual(3.74D, oPression.Result_Moyenne)
        Assert.AreEqual(0.262D, oPression.Result_EcartBars)
        Assert.AreEqual(7.02D, oPression.Result_EcartPct)


        Assert.AreEqual(oPression.colNiveaux(0).isDefaultEcart(oParam833), oPression.Result_isDefautEcart)
        Assert.AreEqual(oPression.colNiveaux(0).isDefaultHeterogeneite(oParam833), oPression.Result_isDefautHeterogeneite)

    End Sub
    <TestMethod()> _
    Public Sub TST_CalculEcartPression2Niveaux()
        Dim oPression As RelevePression833
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833

        '2 Niveau , 2 Tronçons, 15 de pression
        oPression = New RelevePression833(2, 2, 15, oParam833)
 
        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(14)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(12)
        oPression.colNiveaux(1).colTroncons(0).SetPressionLue(16)
        oPression.colNiveaux(1).colTroncons(1).SetPressionLue(14)
        oPression.calcDefauts()

        Assert.AreEqual(14D, oPression.Result_Moyenne)
        Assert.AreEqual(1D, oPression.Result_EcartBars)
        Assert.AreEqual(7.14D, oPression.Result_EcartPct)

        Assert.AreEqual(False, oPression.Result_isDefautEcart)
        Assert.AreEqual(True, oPression.Result_isDefautHeterogeneite)

        'Inversion des Niveaux => Pas de changement pour les Défauts
        oPression = New RelevePression833(2, 2, 15, oParam833)

        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(16)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(14)
        oPression.colNiveaux(1).colTroncons(0).SetPressionLue(12)
        oPression.colNiveaux(1).colTroncons(1).SetPressionLue(14)
        oPression.calcDefauts()

        Assert.AreEqual(False, oPression.Result_isDefautEcart)
        Assert.AreEqual(True, oPression.Result_isDefautHeterogeneite)

    End Sub
    <TestMethod()> _
    Public Sub TST_CalculEcartPression2NiveauxPerteDeCharge()
        Dim oPression As RelevePression833
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833


        '2 Niveau , 2 Tronçons, 100 de pression
        oPression = New RelevePression833(2, 2, 100, oParam833)

        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(80)  'PC = 20, % = 25
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(85)  'PC = 15, % = 17.64
        oPression.colNiveaux(1).colTroncons(0).SetPressionLue(70)  'PC = 30, % = 42.85
        oPression.colNiveaux(1).colTroncons(1).SetPressionLue(65)  'PC = 35, % 53.84
        oPression.calcDefauts()

        '(80+85+70+65) / 4 = 75 => PC Moyenne = 25
        Assert.AreEqual(33.33D, oPression.Result_PerteChargeMoyenne)
        Assert.AreEqual(53.85D, oPression.Result_PerteChargeMaxi)

        '2 Niveau , 2 Tronçons, 100 de pression
        oPression = New RelevePression833(2, 2, 100, oParam833)

        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(120)  'PC = -20, % = -16.67
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(115)  'PC = 15, % = -13.04
        oPression.colNiveaux(1).colTroncons(0).SetPressionLue(130)  'PC = 30, % = -23.08
        oPression.colNiveaux(1).colTroncons(1).SetPressionLue(135)  'PC = 35, % = -25.93
        oPression.calcDefauts()

        '(80+85+70+65) / 4 = 75 => PC Moyenne = 25
        Assert.AreEqual(-20D, oPression.Result_PerteChargeMoyenne)
        Assert.AreEqual(-25.93D, oPression.Result_PerteChargeMaxi)

    End Sub
    <TestMethod()> _
    Public Sub TST_Heterogeneite2Troncons()
        Dim oPression As RelevePression833
        Dim oParam As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833
        '2 Niveau , 2 Tronçons, 15 de pression
        oPression = New RelevePression833(1, 2, 15, oParam)

        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(18)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(15)
        oPression.calcDefauts()
        Assert.AreEqual(20D, oPression.colNiveaux(0).colTroncons(0).Heterogeneite)
        Assert.AreEqual(0D, oPression.colNiveaux(0).colTroncons(1).Heterogeneite)
        Assert.IsTrue(oPression.Result_isDefautHeterogeneite())

        'La Pression Max est remise à la pression Min
        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(15)
        oPression.calcDefauts()
        'du coup l'hétérogénéité passe à 0
        Assert.AreEqual(0D, oPression.colNiveaux(0).colTroncons(0).Heterogeneite)
        Assert.AreEqual(0D, oPression.colNiveaux(0).colTroncons(1).Heterogeneite)
        'Et il n'y a plus d'hétérogénéité
        Assert.IsFalse(oPression.Result_isDefautHeterogeneite())


    End Sub
    <TestMethod()> _
    Public Sub TST_CalculEcartPressionNegatif()
        Dim oPression As RelevePression833
        Dim oParam As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833
        '1 Niveau , 2 Tronçons, 100 de pression
        oPression = New RelevePression833(1, 2, 100, oParam)



        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(120)  'PC = -20, % = -16.67
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(115)  'PC = 15, % = -13.04
        oPression.calcDefauts()

        '(80+85+70+65) / 4 = 75 => PC Moyenne = 25
        Assert.AreEqual(-14.89D, oPression.Result_PerteChargeMoyenne)
        Assert.AreEqual(-16.67D, oPression.Result_PerteChargeMaxi)

        Assert.AreEqual(117.5D, oPression.Result_Moyenne)
        Assert.AreEqual(-17.5D, oPression.Result_EcartBars)
        Assert.AreEqual(-14.89D, oPression.Result_EcartPct)
        Assert.AreEqual(True, oPression.Result_isDefautEcart())

        'Prise en compte des ecarts négatifs en hétérogénéité
        oPression = New RelevePression833(1, 4, 3, oParam)

        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(3.42D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(2.8D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(3.42D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(3.41D)
        oPression.calcDefauts()

        Assert.AreEqual(-18.05D, oPression.colNiveaux(0).colTroncons(1).Heterogeneite)
        Assert.AreEqual(True, oPression.colNiveaux(0).colTroncons(1).isDefaultHeterogeneite(oParam))
        Assert.AreEqual(True, oPression.colNiveaux(0).isDefaultHeterogeneite(oParam))
        Assert.AreEqual(True, oPression.Result_isDefautHeterogeneite())

    End Sub
    ''' <summary>
    ''' Test avae le paramDiag 8333 diférent du 8332
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub TST_CalculDefautEcartHeteroAvec8333diff8332()

        Dim oPression As RelevePression833
        Dim olst As List(Of CRODIP_ControlLibrary.ParamDiag)
        olst = CRODIP_ControlLibrary.ParamDiag.readXML()
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = olst(0).ParamDiagCalc833
        oParam833.limite8332 = "15" 'Limite Hétérogénéité
        oParam833.limite8333 = "10" 'Limite Ecart
        '1 Niveau , 4 Tronçons, 3.0 de pression
        oPression = New RelevePression833(1, 4, 3D, oParam833)

        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(2.71D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(2.71D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(2.71D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(2.71D)

        'Pression Moyenne = 2.71 => Ecart = (0.29/2.71)=> 10.70 %
        'Comme la limite est 10 => Défaut d'écart
        oPression.calcDefauts()

        Assert.IsTrue(oPression.Result_isDefautEcart)


        oParam833.limite8332 = "15" 'Limite Hétérogénéité
        oParam833.limite8333 = "15" 'Limite Ecart
        '1 Niveau , 4 Tronçons, 3.0 de pression
        oPression = New RelevePression833(1, 4, 3D, oParam833)

        oPression.colNiveaux(0).colTroncons(0).SetPressionLue(2.71D)
        oPression.colNiveaux(0).colTroncons(1).SetPressionLue(2.71D)
        oPression.colNiveaux(0).colTroncons(2).SetPressionLue(2.71D)
        oPression.colNiveaux(0).colTroncons(3).SetPressionLue(2.71D)

        'Pression Moyenne = 2.71 => Ecart = (0.29/2.71)=> 10.70 %
        'Comme la limite est 15 => Pas de Défaut d'écart
        oPression.calcDefauts()

        Assert.IsFalse(oPression.Result_isDefautEcart)


    End Sub
End Class
