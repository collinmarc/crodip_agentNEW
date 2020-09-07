Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

'''<summary>
'''Classe de test pour DiagnosticMano542, destinée à contenir tous
'''les tests unitaires PulverisateurManagerTest
'''</summary>
<TestClass()> _
Public Class DiagnosticMano542Test
    Inherits CRODIPTest



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
    '<TestCleanup()> _
    'Public Sub MyTestCleanup()
    'End Sub
#End Region


    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Object()
    End Sub

    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Create_Save_Update()
        Dim oDiagMAno542 As DiagnosticMano542
        Dim iD As Integer
        oDiagMAno542 = New DiagnosticMano542

        oDiagMAno542.idDiagnostic = "99-99"
        oDiagMAno542.pressionControle = "1.6"
        oDiagMAno542.pressionPulve = "1.7"

        DiagnosticMano542Manager.save(oDiagMAno542)
        iD = oDiagMAno542.id
        oDiagMAno542 = DiagnosticMano542Manager.getDiagnosticMano542ById(oDiagMAno542.id.ToString, oDiagMAno542.idDiagnostic)

        Assert.AreEqual(oDiagMAno542.id, iD)
        Assert.AreEqual(oDiagMAno542.idDiagnostic, "99-99")
        Assert.AreEqual(oDiagMAno542.pressionControle, "1.6")
        Assert.AreEqual(oDiagMAno542.pressionPulve, "1.7")

        'Maj de l'objet
        oDiagMAno542.pressionControle = "1.61"
        oDiagMAno542.pressionPulve = "1.71"
        DiagnosticMano542Manager.save(oDiagMAno542)
        oDiagMAno542 = DiagnosticMano542Manager.getDiagnosticMano542ById(oDiagMAno542.id.ToString, oDiagMAno542.idDiagnostic)

        Assert.AreEqual(oDiagMAno542.pressionControle, "1.61")
        Assert.AreEqual(oDiagMAno542.pressionPulve, "1.71")

        DiagnosticMano542Manager.delete(oDiagMAno542.id.ToString, oDiagMAno542.idDiagnostic)


    End Sub
    '''<summary>
    '''Test de charegement déchargement depuis le Diag
    '''</summary>
    <TestMethod()> _
    Public Sub TST_LOAD_SAVE_DIAG()
        Dim odiag As Diagnostic

        Dim oDiagMAno542 As DiagnosticMano542

        odiag = New Diagnostic()
        odiag.id = "99-99"
        oDiagMAno542 = New DiagnosticMano542

        oDiagMAno542.idDiagnostic = odiag.id
        oDiagMAno542.pressionControle = "1.6"
        oDiagMAno542.pressionPulve = "1.7"
        odiag.diagnosticMano542List.Liste.Add(oDiagMAno542)
        DiagnosticMano542Manager.save(oDiagMAno542)

        oDiagMAno542 = New DiagnosticMano542
        oDiagMAno542.idDiagnostic = odiag.id
        oDiagMAno542.pressionControle = "2"
        oDiagMAno542.pressionPulve = "2.1"
        odiag.diagnosticMano542List.Liste.Add(oDiagMAno542)
        DiagnosticMano542Manager.save(oDiagMAno542)

        'Rechargement par le diagnostic
        DiagnosticMano542Manager.getDiagnosticMano542ByDiagnostic(odiag)
        'Vérification que les Mano542 sopnt bien lus
        Assert.AreEqual(2, odiag.diagnosticMano542List.Liste.Count)

        oDiagMAno542 = odiag.diagnosticMano542List.Liste(0)
        Assert.AreEqual(oDiagMAno542.idDiagnostic, odiag.id)
        Assert.AreEqual(oDiagMAno542.pressionControle, "1.6")
        Assert.AreEqual(oDiagMAno542.pressionPulve, "1.7")

        oDiagMAno542 = odiag.diagnosticMano542List.Liste(1)
        Assert.AreEqual(oDiagMAno542.idDiagnostic, odiag.id)
        Assert.AreEqual(oDiagMAno542.pressionControle, "2")
        Assert.AreEqual(oDiagMAno542.pressionPulve, "2.1")

        'Maj de la Pression 2
        oDiagMAno542.pressionControle = "2,5"
        oDiagMAno542.pressionPulve = "2,6"

        DiagnosticMano542Manager.save(oDiagMAno542)

        'Relecture des items
        DiagnosticMano542Manager.getDiagnosticMano542ByDiagnostic(odiag)

        Assert.AreEqual(2, odiag.diagnosticMano542List.Liste.Count)
        oDiagMAno542 = odiag.diagnosticMano542List.Liste(1)
        Assert.AreEqual(oDiagMAno542.pressionControle, "2,5")
        Assert.AreEqual(oDiagMAno542.pressionPulve, "2,6")

        DiagnosticMano542Manager.deleteByDiagnosticID(oDiagMAno542.idDiagnostic)


    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetByID()

    End Sub
    '<TestMethod()> _
    'Public Sub TST_CalcImprecision1Mano()

    '    Dim oCalc542 As DiagnosticMano542
    '    'Pression <=2
    '    '0<Ecart <= 0.1 => OK
    '    '0.1<Ecart <= 0.2 => FAIBLE
    '    '0.2<Ecart  => FORTE

    '    oCalc542 = New DiagnosticMano542("1,6", "1,5")
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(CDec(0.1), oCalc542.Ecart)
    '    Assert.AreEqual(DiagnosticMano542.ERR542.OK, oCalc542.Erreur)

    '    oCalc542 = New DiagnosticMano542("1,6", "1,4")
    '    Assert.AreEqual(CDec(0.2), oCalc542.Ecart)
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oCalc542.Erreur)

    '    oCalc542 = New DiagnosticMano542("1,6", "1,3")
    '    Assert.AreEqual(CDec(0.3), oCalc542.Ecart)
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oCalc542.Erreur)

    '    oCalc542 = New DiagnosticMano542("2", "1.9")
    '    Assert.AreEqual(CDec(0.1), oCalc542.Ecart)
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(DiagnosticMano542.ERR542.OK, oCalc542.Erreur)

    '    oCalc542 = New DiagnosticMano542("2", "1.8")
    '    Assert.AreEqual(CDec(0.2), oCalc542.Ecart)
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oCalc542.Erreur)

    '    oCalc542 = New DiagnosticMano542("2", "1.6")
    '    Assert.AreEqual(CDec(0.4), oCalc542.Ecart)
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oCalc542.Erreur)



    '    'Pression >2
    '    'Ecart <= PressionPulve*5% => OK
    '    '(PressionPulve*5%)<Ecart <= PressionPulve*10% => FAIBLE
    '    '(PressionPulve*10%)<Ecart  => FORTE
    '    'Pression = 3 => 3*5% = 0.15 3*10% = 0.3
    '    oCalc542 = New DiagnosticMano542("3", "2.9")
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(DiagnosticMano542.ERR542.OK, oCalc542.Erreur)

    '    oCalc542 = New DiagnosticMano542("3", "2.8")
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oCalc542.Erreur)

    '    oCalc542 = New DiagnosticMano542("3", "2.69")
    '    oCalc542.calcimprecision()
    '    Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oCalc542.Erreur)

    'End Sub
    '''<summary>
    '''Test le calcul de l'imprecision sur les 4 Manos
    '''</summary>
    <TestMethod()> _
    Public Sub TST_CalcImprecision4Mano()

        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_2 As DiagnosticMano542
        Dim oMano542_3 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542
        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        oParamCalc542 = lst(0).ParamDiagCalc542

        Dim oColMano542 As New DiagnosticMano542List()

        'Tout est OK => Resulat OK
        oMano542_1 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oColMano542.Result)

        '+1 FORTE => FORTE
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1,6", "1,1")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("1,6", "1,2")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oColMano542.Result)

        '+0 FORTE , +1 FAIBLE => FAIBLE
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1,6", "1,4")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("1,6", "1,4")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oColMano542.Result)

        '1 FORTE, Hors Critère
        'If (Math.Abs(EcartMax - EcartMin) <= 0.0201) Or EcartMax < 0.0501 Then

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("1,6", "1,5")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("1,6", "1,1")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(CDec(0.5), oColMano542.EcartMax)
        Assert.AreEqual(CDec(0.1), oColMano542.EcartMin)
        Assert.AreEqual(CDec(0.4), oColMano542.EcartMax - oColMano542.EcartMin)
        Assert.IsTrue((oColMano542.EcartMax - oColMano542.EcartMin) > CDec(0.0201))
        Assert.IsTrue((oColMano542.EcartMax) > CDec(0.0501))

        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oColMano542.Result)

        '1 FORTE, Dans Critère 1 oColMano542.EcartMax - oColMano542.EcartMin) < CDec(0.0201)
        'If (Math.Abs(EcartMax - EcartMin) <= 0.0201) Or EcartMax < 0.0501 Then

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1,6", "1,4")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("1,6", "1,4")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("1,6", "1,4")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("1,6", "1,38")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(CDec(0.22), oColMano542.EcartMax)
        Assert.AreEqual(CDec(0.2), oColMano542.EcartMin)
        Assert.AreEqual(CDec(0.02), oColMano542.EcartMax - oColMano542.EcartMin)
        Assert.IsTrue((oColMano542.EcartMax - oColMano542.EcartMin) < CDec(0.0201))
        Assert.IsTrue((oColMano542.EcartMax) > CDec(0.0501))
        '#16687 : Annulation de la regle 1 forte
        'Assert.AreEqual(Crodip_agent.DiagnosticMano542.ERR542.FAIBLE, oColMano542.Result)
        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oColMano542.Result)

        '1 FORTE, Dans Critère 2 Assert.IsTrue((oColMano542.EcartMax) < CDec(0.0501))
        'If (Math.Abs(EcartMax - EcartMin) <= 0.0201) Or EcartMax < 0.0501 Then

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("0.5", "0,5501") '=> -0.0501
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("0.5", "0,55")   '=> -0.0500
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("0.5", "0,54")   '=> -0.0400
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("0.5", "0,485")   '=> 0.015
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(oColMano542.EcartMax, CDec(-0.0501))
        '        Assert.AreEqual(Crodip_agent.DiagnosticMano542.ERR542.FAIBLE, oColMano542.Result)


        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "1.6")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "1.85")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "2,8")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("4", "4.1")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual((oColMano542.EcartMax), CDec(0.2))


        'test ecart Max (-0.3 est Supérieur à 0.2)
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "1.6")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "2.2")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "2,7")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("4", "4.1")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual((oColMano542.EcartMax), CDec(0.3))
    End Sub
    '''<summary>
    '''Test le calcul de l'imprecision sur les 4 Manos
    '''</summary>
    <TestMethod()> _
    Public Sub TST_CalcImprecision4Mano_2()
        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_2 As DiagnosticMano542
        Dim oMano542_3 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542
        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        oParamCalc542 = lst(0).ParamDiagCalc542

        Dim oColMano542 As New DiagnosticMano542List()
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "1.4")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "2")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "3")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("4", "4")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual((oColMano542.EcartMax), CDec(0.2))
        'Ecart Variable, Pression <2 , EcartValeur <=0,2 => FAIBLE
        Assert.AreEqual((oMano542_1.Erreur), DiagnosticMano542.ERR542.FAIBLE)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "1.6")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "2")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "2.8")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("4", "4")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual((oColMano542.EcartMax), CDec(0.2))
        'Ecart Variable, Pression >2 , Ecart% > 5%  => FAIBLE
        Assert.AreEqual((oMano542_3.Erreur), DiagnosticMano542.ERR542.FAIBLE)


    End Sub
    '''<summary>
    '''Prise en compte de la règle de l'écart constant
    '''</summary>
    <TestMethod()> _
    Public Sub TST_CalcImprecision4Mano_3()
        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_2 As DiagnosticMano542
        Dim oMano542_3 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542
        Dim oMano542 As DiagnosticMano542

        Dim oColMano542 As New DiagnosticMano542List()

        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        oParamCalc542 = lst(0).ParamDiagCalc542

        'Pression inférieure à 10 bars Ecart Constant < 0.5
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "2")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "2.4")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "3.4")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("9.9", "10.3")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        For Each oMano542 In oColMano542.diagnosticMano542
            Assert.AreEqual(oMano542.Erreur, DiagnosticMano542.ERR542.FAIBLE)
        Next

        'Pression inférieure à 10 bars Ecart Constant = 0.5
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "2.1")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "2.5")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "3.5")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("9.9", "10.4")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        For Each oMano542 In oColMano542.diagnosticMano542
            Assert.AreEqual(oMano542.Erreur, DiagnosticMano542.ERR542.FAIBLE)
        Next

        'Pression inférieure à 10 bars Ecart Constant > 0.5
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "2.11")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "2.51")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "3.51")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("9.9", "10.41")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        For Each oMano542 In oColMano542.diagnosticMano542
            Assert.AreEqual(oMano542.Erreur, DiagnosticMano542.ERR542.FORTE)
        Next

        'Pression >= 10 bars Ecart Constant < 1
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("10.1", "10.9")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("11", "11.9")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("12", "12.9")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("13", "13.9")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        For Each oMano542 In oColMano542.diagnosticMano542
            Assert.AreEqual(oMano542.Erreur, DiagnosticMano542.ERR542.FAIBLE)
        Next

        'Pression >= 10 bars Ecart Constant = 1
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("10.1", "11")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("11", "12")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("12", "13")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("13", "14")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        For Each oMano542 In oColMano542.diagnosticMano542
            Assert.AreEqual(oMano542.Erreur, DiagnosticMano542.ERR542.FAIBLE)
        Next

        'Pression >= 10 bars Ecart Constant > 1
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("10.1", "11.2")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("11", "12.1")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("12", "13.1")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("13", "14.1")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        For Each oMano542 In oColMano542.diagnosticMano542
            Assert.AreEqual(oMano542.Erreur, DiagnosticMano542.ERR542.FORTE)
        Next

        'Test avec une valeur > 10
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "2.5")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "2.9")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "3.9")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("10.1", "11")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        Assert.AreEqual(oMano542_1.Erreur, DiagnosticMano542.ERR542.FORTE)
        Assert.AreEqual(oMano542_2.Erreur, DiagnosticMano542.ERR542.FORTE)
        Assert.AreEqual(oMano542_3.Erreur, DiagnosticMano542.ERR542.FORTE)
        Assert.AreEqual(oMano542_4.Erreur, DiagnosticMano542.ERR542.FAIBLE)

        'Test des valeurs limites 
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "2.6")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "3")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "4")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("10.1", "11.1")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        Assert.AreEqual(oMano542_1.Erreur, DiagnosticMano542.ERR542.FORTE)
        Assert.AreEqual(oMano542_2.Erreur, DiagnosticMano542.ERR542.FORTE)
        Assert.AreEqual(oMano542_3.Erreur, DiagnosticMano542.ERR542.FORTE)
        Assert.AreEqual(oMano542_4.Erreur, DiagnosticMano542.ERR542.FAIBLE)

        'Pas d'écart => OK 
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "1.6")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "2")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "3")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("10", "10")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        Assert.AreEqual(oMano542_1.Erreur, DiagnosticMano542.ERR542.OK)
        Assert.AreEqual(oMano542_2.Erreur, DiagnosticMano542.ERR542.OK)
        Assert.AreEqual(oMano542_3.Erreur, DiagnosticMano542.ERR542.OK)
        Assert.AreEqual(oMano542_4.Erreur, DiagnosticMano542.ERR542.OK)
        Assert.AreEqual(oColMano542.Result, DiagnosticMano542.ERR542.OK)


    End Sub

    '''<summary>
    '''Prise en compte de la règle de l'écart constant
    '''</summary>
    <TestMethod()> _
    Public Sub TST_CalcImprecision4Mano_ValeurAbsolue()
        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_2 As DiagnosticMano542
        Dim oMano542_3 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542

        Dim oColMano542 As New DiagnosticMano542List()
        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)

        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        oParamCalc542 = lst(0).ParamDiagCalc542


       
        'Ecart Non Constant
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "1.8")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "1.8")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "3.2")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("4", "3.8")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        '        Assert.AreNotEqual(oColMano542.EcartMax, oColMano542.EcartMin)
        Assert.AreNotEqual(oMano542_1.Ecart, 0.2D)
        Assert.AreNotEqual(oMano542_2.Ecart, -0.2D)
        Assert.AreNotEqual(oMano542_3.Ecart, 0.2D)
        Assert.AreNotEqual(oMano542_4.Ecart, -0.2D)

        Assert.AreEqual(0.2D, oColMano542.EcartMoy)
        Assert.AreEqual(0.2D, Math.Abs(oColMano542.EcartMax))

        'Le Calcul sur Ecart Constant 
        'Pression inférieure à 10 bars Ecart Constant < 0.5
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "2")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "1.6")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "3.4")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("9.9", "9.5")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        'Mano 1 , Ecart = +0.4 Pression <=10  => FAIBLE
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)
        'Mano 2 , Ecart = +0.4 Pression <=10  => OK
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_2.Erreur)
        'Mano 3 , Ecart = +0.4 Pression <=10  => OK
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_3.Erreur)
        'Mano 4 , Ecart = +0.4 Pression <=10  => OK
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_4.Erreur)

        oMano542_3.pressionPulve = "3"
        oMano542_3.pressionControle = "2,6"
        oColMano542.CalcImprecisionNew(oParamCalc542)
        'Mano 3 , Ecart = -0.4 Pression <=3 & VA(Ecart) > 10%Pression(0.3) => FORTE
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_3.Erreur)

    End Sub
    <TestMethod()> _
    Public Sub TST_CalcImprecision4Mano_ValueITEQNewParam()
        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_2 As DiagnosticMano542
        Dim oMano542_3 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542

        Dim oColMano542 As New DiagnosticMano542List()
        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)

        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        oParamCalc542 = lst(0).ParamDiagCalc542

        'Ecart Non Constant
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "1.48")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "1.88")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "2.84")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("4", "3.74")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        'ITEQ trouve 0.17 => pblm d'arrondi 0.165 Arrondi = 0.17 en VB.NET 0.16 en Excel
        Assert.AreEqual(0.16D, oColMano542.EcartMoy)
        Assert.AreEqual(0.26D, Math.Abs(oColMano542.EcartMax))

    End Sub


    <TestMethod()> _
    Public Sub TST_CalcImprecision4Mano_Value()
        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_2 As DiagnosticMano542
        Dim oMano542_3 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542

        Dim oColMano542 As New DiagnosticMano542List()
        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)

        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        oParamCalc542 = lst(0).ParamDiagCalc542

        'Ecart Non Constant
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1.6", "1.48")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("2", "1.88")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("3", "2.84")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("4", "3.74")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)

        'ITEQ trouve 0.17 => pblm d'arrondi 0.165 Arrondi = 0.17 en VB.NET 0.16 en Excel
        Assert.AreEqual(0.16D, oColMano542.EcartMoy)
        Assert.AreEqual(0.26D, Math.Abs(oColMano542.EcartMax))

    End Sub

    <TestMethod()> _
    Public Sub TST_CalcImprecisionMano_ValeursLimitesEcartConstant()
        Dim oMano542_1 As DiagnosticMano542

        Dim oColMano542 As New DiagnosticMano542List()
        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)

        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        oParamCalc542 = lst(0).ParamDiagCalc542

        'Ecart Constant
        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2", "2")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.OK, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2", "1.98")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2", "1.5")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2", "1.4")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("9.5", "9")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("9.5", "8.9")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oMano542_1.Erreur)


        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("10", "10.001")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)


        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("10", "10")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.OK, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("10", "8.9")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oMano542_1.Erreur)


        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("12", "11")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)


        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("12", "10.8")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oMano542_1.Erreur)
    End Sub
    <TestMethod()> _
    Public Sub TST_CalcImprecisionMano_ValeursLimitesEcartVariable()
        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542

        Dim oColMano542 As New DiagnosticMano542List()
        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)

        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        oParamCalc542 = lst(0).ParamDiagCalc542

        'Ecart Variable
        oColMano542.Liste.Clear()
        'Le mano4 est là juste pour s'assuer d'un ecart variable
        oMano542_4 = New DiagnosticMano542("5", "3.5")

        oMano542_1 = New DiagnosticMano542("1", "0.956")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.OK, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1", "0.9")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1", "0.8")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("1", "0.79")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2", "1.9")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2", "1.8")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2", "1.79")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2.5", "2.4")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.OK, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2.5", "2.3")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2.5", "2.375")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2.5", "2.7777")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        oColMano542.Liste.Clear()
        oMano542_1 = New DiagnosticMano542("2.5", "2.8")
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_1)
        oColMano542.Liste.Add(oMano542_4)
        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FORTE, oMano542_1.Erreur)
    End Sub
    <TestMethod()> _
    Public Sub TST_CalcImprecision4ManoArbo()

        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_2 As DiagnosticMano542
        Dim oMano542_3 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542
        Dim oParamCalc542 As New CRODIP_ControlLibrary.ParamDiagCalc542
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        For Each oParam As CRODIP_ControlLibrary.ParamDiag In lst
            If oParam.libelle = "Arbres" Then
                oParamCalc542 = oParam.ParamDiagCalc542
            End If
        Next


        Dim oColMano542 As New DiagnosticMano542List()

        'Tout est OK => Resulat OK
        oMano542_1 = New DiagnosticMano542("5", "4,5")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("10", "9,5")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("15", "14,5")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("20", "19,5")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oMano542_1.Erreur)

        Assert.AreEqual(DiagnosticMano542.ERR542.FAIBLE, oColMano542.Result)

    End Sub

    <TestMethod()> _
    Public Sub TST_CalcImprecision4ManoArboOK()

        Dim oMano542_1 As DiagnosticMano542
        Dim oMano542_2 As DiagnosticMano542
        Dim oMano542_3 As DiagnosticMano542
        Dim oMano542_4 As DiagnosticMano542
        Dim oParamCalc542 As CRODIP_ControlLibrary.ParamDiagCalc542 = Nothing
        Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = New List(Of CRODIP_ControlLibrary.ParamDiag)
        lst = CRODIP_ControlLibrary.ParamDiag.readXML()
        For Each oParam As CRODIP_ControlLibrary.ParamDiag In lst
            If oParam.libelle = "Arbres" Then
                oParamCalc542 = oParam.ParamDiagCalc542
            End If
        Next


        Dim oColMano542 As New DiagnosticMano542List()

        'Tout est OK => Resulat OK
        oMano542_1 = New DiagnosticMano542("5", "5")
        oColMano542.Liste.Add(oMano542_1)
        oMano542_2 = New DiagnosticMano542("10", "10")
        oColMano542.Liste.Add(oMano542_2)
        oMano542_3 = New DiagnosticMano542("15", "15")
        oColMano542.Liste.Add(oMano542_3)
        oMano542_4 = New DiagnosticMano542("20", "20")
        oColMano542.Liste.Add(oMano542_4)

        oColMano542.CalcImprecisionNew(oParamCalc542)
        Assert.AreEqual(DiagnosticMano542.ERR542.OK, oMano542_1.Erreur)

        Assert.AreEqual(DiagnosticMano542.ERR542.OK, oColMano542.Result)

    End Sub
End Class
