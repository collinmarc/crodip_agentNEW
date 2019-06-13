Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour DiagnosticHelp12123Mesure, 
'''</summary>
<TestClass()> _
Public Class DiagnosticHelp12123Mesuretest
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
        Dim oHelp12123 As New DiagnosticHelp12123()
        Dim oDiagHelp12123M As DiagnosticHelp12123Mesure
        Dim idDiag As String = "99-99"
        Dim iD As String

        Dim oPompe As DiagnosticHelp12123Pompe
        oPompe = New DiagnosticHelp12123Pompe(oHelp12123, 2)
        oDiagHelp12123M = New DiagnosticHelp12123Mesure(oPompe, 1)
        oDiagHelp12123M.idDiag = idDiag
        oDiagHelp12123M.bCalcule = False 'On desactive le calcule Auto
        oPompe.DebitReel = 1.2D
        oPompe.DebitTotal = 1.3D
        oDiagHelp12123M.ReglageDispositif = 1.4D
        oDiagHelp12123M.DebitTheorique = 1.5D
        oDiagHelp12123M.TempsMesure = 1.6D
        oDiagHelp12123M.QteEauPulverisee = 1.7D
        oDiagHelp12123M.MasseInitiale = 2D
        oDiagHelp12123M.MasseAspire = 3D
        oDiagHelp12123M.QteProduitConso = 4
        oDiagHelp12123M.DosageReel = 1.11D
        oDiagHelp12123M.EcartReglage = 1.12D
        oDiagHelp12123M.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Assert.IsTrue(oDiagHelp12123M.Save(m_oAgent.idStructure, m_oAgent.id))
        iD = oDiagHelp12123M.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp12123M.id))

        Debug.WriteLine("Lecture")
        oDiagHelp12123M = New DiagnosticHelp12123Mesure()
        Assert.IsTrue(oDiagHelp12123M.Load(iD, idDiag))

        Assert.AreEqual(iD, oDiagHelp12123M.id, iD)
        Assert.AreEqual(idDiag, oDiagHelp12123M.idDiag, idDiag)
        Assert.AreEqual(1, oDiagHelp12123M.numeroPompe, 2)
        Assert.AreEqual(1, oDiagHelp12123M.numeroMesure, 1)

        '        Assert.AreEqual(oDiagHelp12123M.DebitReel, 1.2D)
        '       Assert.AreEqual(oDiagHelp12123M.DebitTotal, 1.3D)
        Assert.AreEqual(oDiagHelp12123M.ReglageDispositif, 1.4D)
        Assert.AreEqual(oDiagHelp12123M.DebitTheorique, 1.5D)
        Assert.AreEqual(oDiagHelp12123M.TempsMesure, 1.6D)
        Assert.AreEqual(oDiagHelp12123M.QteEauPulverisee, 1.7D)
        Assert.AreEqual(oDiagHelp12123M.MasseInitiale, 2D)
        Assert.AreEqual(oDiagHelp12123M.MasseAspire, 3D)
        Assert.AreEqual(oDiagHelp12123M.QteProduitConso, 4D)
        Assert.AreEqual(oDiagHelp12123M.DosageReel, 1.11D)
        Assert.AreEqual(oDiagHelp12123M.EcartReglage, 1.12D)

        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oDiagHelp12123M.Resultat)


        'Maj de l'objet
        oDiagHelp12123M.bCalcule = False
        oPompe.DebitReel = 11.2D
        oPompe.DebitTotal = 11.3D
        oDiagHelp12123M.ReglageDispositif = 11.4D
        oDiagHelp12123M.DebitTheorique = 11.5D
        oDiagHelp12123M.TempsMesure = 11.6D
        oDiagHelp12123M.QteEauPulverisee = 11.7D
        oDiagHelp12123M.MasseInitiale = 12
        oDiagHelp12123M.MasseAspire = 13
        oDiagHelp12123M.QteProduitConso = 14
        oDiagHelp12123M.DosageReel = 11.11D
        oDiagHelp12123M.EcartReglage = 11.12D
        oDiagHelp12123M.Resultat = DiagnosticItem.EtatDiagItemMINEUR

        Debug.WriteLine("Update")
        Assert.IsTrue(oDiagHelp12123M.Save(m_oAgent.idStructure, m_oAgent.id))

        Debug.WriteLine("Lecture")
        oDiagHelp12123M = New DiagnosticHelp12123Mesure()
        Assert.IsTrue(oDiagHelp12123M.Load(iD, idDiag))

        Assert.AreEqual(iD, oDiagHelp12123M.id, iD)
        Assert.AreEqual(idDiag, oDiagHelp12123M.idDiag, idDiag)
        Assert.AreEqual(1, oDiagHelp12123M.numeroPompe, 2)
        Assert.AreEqual(1, oDiagHelp12123M.numeroMesure, 1)

        '        Assert.AreEqual(oDiagHelp12123M.DebitReel, 11.2D)
        '        Assert.AreEqual(oDiagHelp12123M.DebitTotal, 11.3D)
        Assert.AreEqual(oDiagHelp12123M.ReglageDispositif, 11.4D)
        Assert.AreEqual(oDiagHelp12123M.DebitTheorique, 11.5D)
        Assert.AreEqual(oDiagHelp12123M.TempsMesure, 11.6D)
        Assert.AreEqual(oDiagHelp12123M.QteEauPulverisee, 11.7D)
        Assert.AreEqual(oDiagHelp12123M.MasseInitiale, 12D)
        Assert.AreEqual(oDiagHelp12123M.MasseAspire, 13D)
        Assert.AreEqual(oDiagHelp12123M.QteProduitConso, 14D)
        Assert.AreEqual(oDiagHelp12123M.DosageReel, 11.11D)
        Assert.AreEqual(oDiagHelp12123M.EcartReglage, 11.12D)

        Assert.AreEqual(DiagnosticItem.EtatDiagItemMINEUR, oDiagHelp12123M.Resultat)

        Debug.WriteLine("Suppression")
        oDiagHelp12123M.Delete()

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

        'Ajout des mesures help12123
        '=========================
        oDiag.diagnosticHelp12123.bCalcule = False

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        'Rechargement du Diag
        '=======================
        oDiag2 = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag2.diagnosticHelp12123.bCalcule = False
        Assert.AreEqual(idDiag, oDiag2.id)

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag2)

        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag.diagnosticHelp12123.bCalcule = False
        Assert.AreEqual(idDiag, oDiag.id)

        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub

    <TestMethod()>
    Public Sub testCalcDebitReelTotal()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As New DiagnosticHelp12123Mesure()
        Dim oPompe As New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oMesure = New DiagnosticHelp12123Mesure(oPompe, 1)
        oPompe.debitMesure = 10
        oPompe.PressionMesure = 10
        oPompe.PressionMoyenne = 15
        oPompe.NbBuses = 5

        oMesure.calcule()
        Assert.AreEqual(12.25D, oMesure.DebitReelRND)
        Assert.AreEqual(61.24D, oMesure.DebitTotalRND)

    End Sub
    <TestMethod()>
    Public Sub testCalcDebitTheorique()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As New DiagnosticHelp12123Mesure()
        Dim oPompe As New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oPompe.debitMesure = 10
        oPompe.PressionMesure = 10
        oPompe.PressionMoyenne = 15
        oPompe.NbBuses = 5

        oMesure = New DiagnosticHelp12123Mesure(oPompe, 1)
        oMesure.ReglageDispositif = 23
        oMesure.calcule()
        Assert.AreEqual(11.5D, oMesure.DebitTheoriqueRND)

    End Sub
    <TestMethod()>
    Public Sub testCalcQuantiteEau()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As New DiagnosticHelp12123Mesure()
        Dim oPompe As New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oPompe.debitMesure = 10
        oPompe.PressionMesure = 10
        oPompe.PressionMoyenne = 15
        oPompe.NbBuses = 5

        oMesure = New DiagnosticHelp12123Mesure(oPompe, 1)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.calcule()
        Assert.AreEqual(30.62D, oMesure.QteEauPulveriseeRND)

    End Sub
    <TestMethod()>
    Public Sub testCalcQteProduitConsomme()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As New DiagnosticHelp12123Mesure()
        Dim oPompe As New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oPompe.debitMesure = 10
        oPompe.PressionMesure = 10
        oPompe.PressionMoyenne = 15
        oPompe.NbBuses = 5

        oMesure = New DiagnosticHelp12123Mesure(oPompe, 1)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 3.756
        oMesure.MasseAspire = 3.492

        Assert.AreEqual(0.264D, oMesure.QteProduitConso)


    End Sub
    <TestMethod()>
    Public Sub testCalcDosageReel()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As New DiagnosticHelp12123Mesure()
        Dim oPompe As New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oPompe.debitMesure = 10
        oPompe.PressionMesure = 10
        oPompe.PressionMoyenne = 15
        oPompe.NbBuses = 5

        oMesure = New DiagnosticHelp12123Mesure(oPompe, 1)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 3.756
        oMesure.MasseAspire = 3.492
        Assert.AreEqual(0.264D, oMesure.QteProduitConso)

        Assert.AreEqual(0.862D, oMesure.DosageReelRND)


    End Sub
    <TestMethod()>
    Public Sub testCalcEcartReglage()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As New DiagnosticHelp12123Mesure()
        Dim oPompe As New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oPompe.debitMesure = 10
        oPompe.PressionMesure = 10
        oPompe.PressionMoyenne = 15
        oPompe.NbBuses = 5

        oMesure = New DiagnosticHelp12123Mesure(oPompe, 1)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 3.756
        oMesure.MasseAspire = 3.492

        Assert.AreEqual(0.862D, oMesure.DosageReelRND)

    End Sub
    <TestMethod()>
    Public Sub testCalcResultat()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As DiagnosticHelp12123Mesure
        Dim oPompe As New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oPompe.debitMesure = 10
        oPompe.PressionMesure = 10
        oPompe.PressionMoyenne = 15
        oPompe.NbBuses = 5

        oMesure = New DiagnosticHelp12123Mesure(oPompe, 1)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 10.8
        oMesure.MasseAspire = 3.492

        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oMesure.Resultat)
        oMesure.MasseInitiale = 10.9
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oMesure.Resultat)


    End Sub
End Class
