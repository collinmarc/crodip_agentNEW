Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour DiagnosticHelp571Test, 
'''</summary>
<TestClass()> _
Public Class DiagnosticHelp571test
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
        Dim oDiagHelp571 As DiagnosticHelp571
        Dim oDiag As Diagnostic
        Dim iD As String
        Dim oCSDB As New CSDb(True)

        oDiag = createAndSaveDiagnostic()

        oDiagHelp571 = New DiagnosticHelp571
        oDiagHelp571.bCalcule = False

        oDiagHelp571.idDiag = oDiag.id
        oDiagHelp571.erreurVitesseDEB = 1.2D
        oDiagHelp571.erreurDebitDEB = 1.3D
        oDiagHelp571.erreurGlobaleDEB = 1.4D

        oDiagHelp571.DebitMesurePRS = 1.6D
        oDiagHelp571.PressionMesurePRS = 1.5D
        oDiagHelp571.PressionMoyennePRS = 1.8D
        oDiagHelp571.DebitBuseProgrammePRS = 1.9D
        oDiagHelp571.ErreurVitessePRS = 1.91D
        oDiagHelp571.DebitReelPRS = 1.7D
        oDiagHelp571.ErreurDebitPRS = 1.92D
        oDiagHelp571.ErreurGlobalePRS = 1.93D
        oDiagHelp571.Regulation = "DPAE"
        oDiagHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR
        oDiagHelp571.IsDPAE = True
        oDiagHelp571.IsDPAEDebit = False
        oDiagHelp571.IsDPAEPression = True

        Debug.WriteLine("Création")
        Assert.IsTrue(String.IsNullOrEmpty(oDiagHelp571.id))
        Assert.IsTrue(oDiagHelp571.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDB))
        iD = oDiagHelp571.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp571.id))

        Debug.WriteLine("Lecture")
        oDiagHelp571 = New DiagnosticHelp571()
        oDiagHelp571.id = iD
        oDiagHelp571.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp571.Load())

        Assert.AreEqual(oDiagHelp571.erreurVitesseDEB, 1.2D)
        Assert.AreEqual(oDiagHelp571.erreurDebitDEB, 1.3D)
        Assert.AreEqual(oDiagHelp571.erreurGlobaleDEB, 1.4D)
        Assert.AreEqual(oDiagHelp571.PressionMesurePRS, 1.5D)
        Assert.AreEqual(oDiagHelp571.DebitMesurePRS, 1.6D)
        Assert.AreEqual(oDiagHelp571.DebitReelPRS, 1.7D)
        Assert.AreEqual(oDiagHelp571.PressionMoyennePRS, 1.8D)
        Assert.AreEqual(oDiagHelp571.DebitBuseProgrammePRS, 1.9D)
        Assert.AreEqual(oDiagHelp571.ErreurVitessePRS, 1.91D)
        Assert.AreEqual(oDiagHelp571.ErreurDebitPRS, 1.92D)
        Assert.AreEqual(oDiagHelp571.ErreurGlobalePRS, 1.93D)
        Assert.AreEqual(oDiagHelp571.ResultPRS, DiagnosticItem.EtatDiagItemMAJEUR)
        Assert.AreEqual(True, oDiagHelp571.IsDPAE)
        Assert.AreEqual(False, oDiagHelp571.IsDPAEDebit)
        Assert.AreEqual(True, oDiagHelp571.IsDPAEPression)


        'Maj de l'objet
        oDiagHelp571.bCalcule = False
        oDiagHelp571.erreurVitesseDEB = 1.2D * 10
        oDiagHelp571.erreurDebitDEB = 1.3D * 10
        oDiagHelp571.erreurGlobaleDEB = 1.4D * 10

        oDiagHelp571.DebitMesurePRS = 1.6D * 10
        oDiagHelp571.PressionMesurePRS = 1.5D * 10
        oDiagHelp571.PressionMoyennePRS = 1.8D * 10
        oDiagHelp571.DebitBuseProgrammePRS = 1.9D * 10

        oDiagHelp571.ErreurVitessePRS = 1.91D * 10
        oDiagHelp571.DebitReelPRS = 1.7D * 10
        oDiagHelp571.ErreurDebitPRS = 1.92D * 10
        oDiagHelp571.ErreurGlobalePRS = 1.93D * 10
        oDiagHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMINEUR
        oDiagHelp571.IsDPAE = False
        oDiagHelp571.IsDPAEDebit = True
        oDiagHelp571.IsDPAEPression = False

        Debug.WriteLine("Update")
        Assert.IsTrue(oDiagHelp571.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDB))

        Debug.WriteLine("Lecture")
        oDiagHelp571 = New DiagnosticHelp571()
        oDiagHelp571.id = iD
        oDiagHelp571.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp571.Load())

        Assert.AreEqual(oDiagHelp571.erreurVitesseDEB, 1.2D * 10)
        Assert.AreEqual(oDiagHelp571.erreurDebitDEB, 1.3D * 10)
        Assert.AreEqual(oDiagHelp571.erreurGlobaleDEB, 1.4D * 10)
        Assert.AreEqual(oDiagHelp571.PressionMesurePRS, 1.5D * 10)
        Assert.AreEqual(oDiagHelp571.DebitMesurePRS, 1.6D * 10)
        Assert.AreEqual(oDiagHelp571.DebitReelPRS, 1.7D * 10)
        Assert.AreEqual(oDiagHelp571.PressionMoyennePRS, 1.8D * 10)
        Assert.AreEqual(oDiagHelp571.DebitBuseProgrammePRS, 1.9D * 10)
        Assert.AreEqual(oDiagHelp571.ErreurVitessePRS, 1.91D * 10)
        Assert.AreEqual(oDiagHelp571.ErreurDebitPRS, 1.92D * 10)
        Assert.AreEqual(oDiagHelp571.ErreurGlobalePRS, 1.93D * 10)
        Assert.AreEqual(oDiagHelp571.ResultPRS, DiagnosticItem.EtatDiagItemMINEUR)
        Assert.AreEqual(False, oDiagHelp571.IsDPAE)
        Assert.AreEqual(True, oDiagHelp571.IsDPAEDebit)
        Assert.AreEqual(False, oDiagHelp571.IsDPAEPression)

        oCSDB.free()

    End Sub
    <TestMethod()>
    Public Sub testSaveDiag()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim idDiag As String


        'Creation d'un Diagnostic
        '============================
        Dim oExploit As Exploitation = createExploitation()
        Dim oPulve As Pulverisateur = createPulve(oExploit)
        oDiag = createDiagnostic(oExploit, oPulve)


        'Ajout des DiagItems
        '======================
        Dim oDiagItem As DiagnosticItem
        'Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Ajout des mesures help571
        '=========================
        oDiag.diagnosticHelp571.bCalcule = False
        oDiag.diagnosticHelp571.erreurVitesseDEB = 10.1D
        oDiag.diagnosticHelp571.erreurDebitDEB = 10.2D
        oDiag.diagnosticHelp571.erreurGlobaleDEB = 10.3D
        'Attention on affectre les valeur saisie avant les valeurs calculées , sinon le calcul se redécclenche
        oDiag.diagnosticHelp571.DebitMesurePRS = 20.2D
        oDiag.diagnosticHelp571.PressionMesurePRS = 20.1D
        oDiag.diagnosticHelp571.PressionMoyennePRS = 20.4D
        oDiag.diagnosticHelp571.DebitBuseProgrammePRS = 20.5D
        oDiag.diagnosticHelp571.ErreurVitessePRS = 20.6D
        oDiag.diagnosticHelp571.DebitReelPRS = 20.3D
        oDiag.diagnosticHelp571.ErreurDebitPRS = 20.7D
        oDiag.diagnosticHelp571.ErreurGlobalePRS = 20.7D

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        'Rechargement du Diag
        '=======================
        oDiag2 = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag2.diagnosticHelp571.bCalcule = False
        Assert.AreEqual(idDiag, oDiag2.id)
        Assert.AreEqual(oDiag2.diagnosticHelp571.erreurVitesseDEB, 10.1D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.erreurDebitDEB, 10.2D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.erreurGlobaleDEB, 10.3D)

        Assert.AreEqual(oDiag2.diagnosticHelp571.DebitMesurePRS, 20.2D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.PressionMesurePRS, 20.1D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.PressionMoyennePRS, 20.4D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.ErreurVitessePRS, 20.6D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.DebitReelPRS, 20.3D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.DebitBuseProgrammePRS, 20.5D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.ErreurDebitPRS, 20.7D)
        Assert.AreEqual(oDiag2.diagnosticHelp571.ErreurGlobalePRS, 20.7D)

        oDiag2.diagnosticHelp571.erreurVitesseDEB = 10.1D * 10D
        oDiag2.diagnosticHelp571.erreurDebitDEB = 10.2D * 10D
        oDiag2.diagnosticHelp571.erreurGlobaleDEB = 10.3D * 10D

        oDiag2.diagnosticHelp571.DebitMesurePRS = 20.2D * 10D
        oDiag2.diagnosticHelp571.PressionMesurePRS = 20.1D * 10D
        oDiag2.diagnosticHelp571.PressionMoyennePRS = 20.4D * 10D
        oDiag2.diagnosticHelp571.DebitBuseProgrammePRS = 20.5D * 10D
        oDiag2.diagnosticHelp571.ErreurVitessePRS = 20.6D * 10D
        oDiag2.diagnosticHelp571.DebitReelPRS = 20.3D * 10D
        oDiag2.diagnosticHelp571.ErreurDebitPRS = 20.7D * 10D
        oDiag2.diagnosticHelp571.ErreurGlobalePRS = 20.7D * 10D

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag2)

        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag.diagnosticHelp571.bCalcule = False
        Assert.AreEqual(idDiag, oDiag.id)
        Assert.AreEqual(oDiag2.diagnosticHelp571.erreurVitesseDEB, 10.1D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.erreurDebitDEB, 10.2D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.erreurGlobaleDEB, 10.3D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.PressionMesurePRS, 20.1D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.DebitMesurePRS, 20.2D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.DebitReelPRS, 20.3D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.PressionMoyennePRS, 20.4D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.DebitBuseProgrammePRS, 20.5D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.ErreurVitessePRS, 20.6D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.ErreurDebitPRS, 20.7D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp571.ErreurGlobalePRS, 20.7D * 10)

        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub

    <TestMethod()>
    Public Sub testCalcVTS()
        Dim oHelp571 As New DiagnosticHelp571()

        oHelp571.PressionMesurePRS = 3
        oHelp571.DebitMesurePRS = 1.202D
        oHelp571.PressionMoyennePRS = 2.725D
        oHelp571.DebitBuseProgrammePRS = 1.16D
        Assert.AreEqual(1.146D, oHelp571.DebitReelPRSRND)
        Assert.AreEqual(1.22D, oHelp571.ErreurDebitPRSRND)
        oHelp571.ErreurVitessePRS = 1.89D
        Assert.AreEqual(0.668D, oHelp571.ErreurGlobalePRSRND)
    End Sub
    ''' <summary>
    ''' Test la prise en compte de l'erreur de vitesse négative (#1136)
    ''' </summary>
    <TestMethod()>
    Public Sub testCalcVTSNégatif()
        Dim oHelp571 As New DiagnosticHelp571()

        oHelp571.PressionMesurePRS = 3
        oHelp571.DebitMesurePRS = 1.202D
        oHelp571.PressionMoyennePRS = 2.725D
        oHelp571.DebitBuseProgrammePRS = 1.16D
        Assert.AreEqual(1.146D, oHelp571.DebitReelPRSRND)
        Assert.AreEqual(1.22D, oHelp571.ErreurDebitPRSRND)
        oHelp571.ErreurVitessePRS = -1.89D
        Assert.AreEqual(-3.112D, oHelp571.ErreurGlobalePRSRND)
    End Sub

    <TestMethod()>
    Public Sub testCalcDEBIT()
        Dim oHelp571 As New DiagnosticHelp571()
        Assert.IsNull(oHelp571.erreurGlobaleDEB)

        oHelp571.erreurDebitDEB = 3.574D
        Assert.IsNull(oHelp571.erreurGlobaleDEB)
        oHelp571.erreurVitesseDEB = 1.202D
        Assert.AreEqual(1.202D - 3.574D, oHelp571.erreurGlobaleDEB)
    End Sub
    ''' <summary>
    ''' Prise en compte des nombres négatif dans le calcul debit
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub testCalcDEBITNegatif()
        Dim oHelp571 As New DiagnosticHelp571()
        Assert.IsNull(oHelp571.erreurGlobaleDEB)

        oHelp571.erreurVitesseDEB = 1.39D
        Assert.IsNull(oHelp571.erreurGlobaleDEB)
        oHelp571.erreurDebitDEB = -4.28D
        Assert.AreEqual(5.67D, oHelp571.erreurGlobaleDEB)
    End Sub

    <TestMethod()>
    Public Sub testCalcP2()
        Dim oHelp571 As New DiagnosticHelp571()
        oHelp571.Regulation = "DPAE"
        oHelp571.IsDPAE = True
        oHelp571.PressionMesurePRS = 3
        oHelp571.DebitMesurePRS = 1.202D
        oHelp571.PressionMoyennePRS = 2.725D
        oHelp571.DebitBuseProgrammePRS = 1.16D

        oHelp571.ErreurDebitPRS = 1.25D
        oHelp571.ErreurVitessePRS = oHelp571.ErreurDebitPRS + 6.3D
        Assert.AreEqual(6.328D, oHelp571.ErreurGlobalePRSRND)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMINEUR, oHelp571.ResultPRS)
        oHelp571.ErreurVitessePRS = oHelp571.ErreurDebitPRS + 11.5D
        Assert.AreEqual(11.5D, oHelp571.ErreurGlobalePRSRND)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oHelp571.ResultPRS)
        oHelp571.ErreurVitessePRS = oHelp571.ErreurDebitPRS + 4D
        Assert.AreEqual(4D, oHelp571.ErreurGlobalePRSRND)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oHelp571.ResultPRS)

        oHelp571.Regulation = "DPM"
        oHelp571.IsDPAE = False
        oHelp571.ErreurDebitPRS = 1.25D
        oHelp571.ErreurVitessePRS = oHelp571.ErreurDebitPRS + 6.3D
        Assert.AreEqual(6.328D, oHelp571.ErreurGlobalePRSRND)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oHelp571.ResultPRS)
        oHelp571.ErreurVitessePRS = oHelp571.ErreurDebitPRS + 11.5D
        Assert.AreEqual(11.5D, oHelp571.ErreurGlobalePRSRND)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oHelp571.ResultPRS)
        oHelp571.ErreurVitessePRS = oHelp571.ErreurDebitPRS + 4D
        Assert.AreEqual(4D, oHelp571.ErreurGlobalePRSRND)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oHelp571.ResultPRS)
    End Sub
    <TestMethod()>
    Public Sub testCalcGetResult()
        Dim oHelp571 As New DiagnosticHelp571()
        oHelp571.IsDPAE = True
        oHelp571.IsDPAEDebit = False
        oHelp571.IsDPAEPression = False
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemOK
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemOK
        Assert.AreEqual("", oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMINEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMINEUR
        Assert.AreEqual("", oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMAJEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR
        Assert.AreEqual("", oHelp571.getResult())
        oHelp571.IsDPAEDebit = True
        oHelp571.IsDPAEPression = False
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemOK
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemOK
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMINEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMINEUR
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMINEUR, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMAJEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oHelp571.getResult())
        oHelp571.IsDPAEDebit = False
        oHelp571.IsDPAEPression = True
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemOK
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemOK
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMINEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMINEUR
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMINEUR, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMAJEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oHelp571.getResult())

        oHelp571.IsDPAEDebit = True
        oHelp571.IsDPAEPression = True
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemOK
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemOK
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMINEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMINEUR
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMINEUR, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMAJEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemOK
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMINEUR
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMINEUR, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMINEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemOK
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMINEUR, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemOK
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oHelp571.getResult())
        oHelp571.ResultDEB = DiagnosticItem.EtatDiagItemMAJEUR
        oHelp571.ResultPRS = DiagnosticItem.EtatDiagItemOK
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oHelp571.getResult())

    End Sub
    '<TestMethod()>
    'Public Sub testClone()
    '    Dim oHelp571 As New DiagnosticHelp571()
    '    Dim oHelp571Clone As DiagnosticHelp571

    '    oHelp571.id = 562
    '    oHelp571.idDiag = "00-000-000"


    '    oHelp571.Distance1 = 100
    '    oHelp571.Temps1 = 45
    '    oHelp571.VitesseLue1 = 8

    '    oHelp571.Distance2 = 100
    '    oHelp571.Temps2 = 50
    '    oHelp571.VitesseLue2 = 7
    '    oHelp571.calc(5)

    '    Assert.AreEqual(0D, oHelp571.Ecart1)
    '    Assert.AreEqual(2.78D, oHelp571.Ecart2)

    '    Assert.AreEqual(1.32D, oHelp571.ErreurMoyenne)
    '    Assert.AreEqual("OK", oHelp571.Resultat)

    '    oHelp571Clone = oHelp571.Clone()
    '    Assert.AreEqual(oHelp571.Distance1, oHelp571Clone.Distance1)
    '    Assert.AreEqual(oHelp571.Temps1, oHelp571Clone.Temps1)
    '    Assert.AreEqual(oHelp571.VitesseLue1, oHelp571Clone.VitesseLue1)
    '    Assert.AreEqual(oHelp571.VitesseReelle1, oHelp571Clone.VitesseReelle1)
    '    Assert.AreEqual(oHelp571.Ecart1, oHelp571Clone.Ecart1)
    '    Assert.AreEqual(oHelp571.Resultat1, oHelp571Clone.Resultat1)

    '    Assert.AreEqual(oHelp571.Distance2, oHelp571Clone.Distance2)
    '    Assert.AreEqual(oHelp571.Temps2, oHelp571Clone.Temps2)
    '    Assert.AreEqual(oHelp571.VitesseLue2, oHelp571Clone.VitesseLue2)
    '    Assert.AreEqual(oHelp571.VitesseReelle2, oHelp571Clone.VitesseReelle2)
    '    Assert.AreEqual(oHelp571.Ecart2, oHelp571Clone.Ecart2)
    '    Assert.AreEqual(oHelp571.Resultat2, oHelp571Clone.Resultat2)

    '    Assert.AreEqual(oHelp571.ErreurMoyenne, oHelp571Clone.ErreurMoyenne)
    '    Assert.AreEqual(oHelp571.Resultat, oHelp571Clone.Resultat)

    '    Assert.AreEqual(oHelp571.id, oHelp571Clone.id)
    '    Assert.AreEqual(oHelp571.idDiag, oHelp571Clone.idDiag)
    '    Assert.AreEqual(oHelp571.iditem, oHelp571Clone.iditem)

    '    oHelp571.id = 123
    '    Assert.AreNotEqual(oHelp571.id, oHelp571Clone.id)

    'End Sub
End Class
