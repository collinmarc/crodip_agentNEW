Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CrodipWS



'''<summary>
'''Classe de test pour DiagnosticHelp12123Test, 
'''</summary>
<TestClass()> _
Public Class DiagnosticHelp12123test
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
        Dim oDiagHelp12123 As DiagnosticHelp12123
        Dim oDiag As Diagnostic
        Dim iD As String

        oDiag = createAndSaveDiagnostic()

        oDiagHelp12123 = New DiagnosticHelp12123
        oDiagHelp12123.bCalcule = False

        oDiagHelp12123.idDiag = oDiag.id
        oDiagHelp12123.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Debug.WriteLine("Création")
        Assert.IsTrue(String.IsNullOrEmpty(oDiagHelp12123.id))
        Dim oCSDB As New CSDb(True)
        Assert.IsTrue(oDiagHelp12123.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDB))
        oCSDB.free()
        iD = oDiagHelp12123.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp12123.id))

        Debug.WriteLine("Lecture")
        oDiagHelp12123 = New DiagnosticHelp12123()
        oDiagHelp12123.id = iD
        oDiagHelp12123.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp12123.Load())


        'Maj de l'objet
        oDiagHelp12123.bCalcule = False

        Debug.WriteLine("Update")
        oCSDB.getInstance()
        Assert.IsTrue(oDiagHelp12123.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDB))
        oCSDB.free()

        Debug.WriteLine("Lecture")
        oDiagHelp12123 = New DiagnosticHelp12123()
        oDiagHelp12123.id = iD
        oDiagHelp12123.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp12123.Load())


        Debug.WriteLine("Suppression")
        oDiagHelp12123.Delete()

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

    '<TestMethod()>
    'Public Sub testCalcDebitReelTotal()

    '    Dim oDiag12123 As New DiagnosticHelp12123()
    '    oDiag12123.debitMesure = 1.006
    '    oDiag12123.PressionMesure = 2
    '    oDiag12123.PressionMoyenne = 2.2
    '    oDiag12123.NbBuses = 8

    '    Assert.AreEqual(1.06D, oDiag12123.DebitReelRND)
    '    Assert.AreEqual(8.44D, oDiag12123.DebitTotalRND)

    'End Sub
    '<TestMethod()>
    'Public Sub testCalcDebitTheorique()

    '    Dim oDiag12123 As New DiagnosticHelp12123()
    '    oDiag12123.debitMesure = 1.006
    '    oDiag12123.PressionMesure = 2
    '    oDiag12123.PressionMoyenne = 2.2
    '    oDiag12123.NbBuses = 8

    '    oDiag12123.ReglageDispositif = 2

    '    Assert.AreEqual(0.161D, oDiag12123.DebitTheoriqueRND)


    'End Sub
    '<TestMethod()>
    'Public Sub testCalcQteEauPulverisee()

    '    Dim oDiag12123 As New DiagnosticHelp12123()
    '    oDiag12123.debitMesure = 1.006
    '    oDiag12123.PressionMesure = 2
    '    oDiag12123.PressionMoyenne = 2.2
    '    oDiag12123.NbBuses = 8
    '    oDiag12123.ReglageDispositif = 2
    '    oDiag12123.TempsMesure = 90

    '    Assert.AreEqual(12.66122D, oDiag12123.QteEauPulveriseeRND)


    'End Sub
    '<TestMethod()>
    'Public Sub testCalcQteProduitConsomme()

    '    Dim oDiag12123 As New DiagnosticHelp12123()
    '    oDiag12123.MasseApresAspi = 3756
    '    oDiag12123.MasseApresComplement = 3492

    '    Assert.AreEqual(-264, oDiag12123.QteProduitConso)


    'End Sub
    '<TestMethod()>
    'Public Sub testCalcDosageReel()

    '    Dim oDiag12123 As New DiagnosticHelp12123()
    '    oDiag12123.debitMesure = 1.006
    '    oDiag12123.PressionMesure = 2
    '    oDiag12123.PressionMoyenne = 2.2
    '    oDiag12123.NbBuses = 8
    '    oDiag12123.ReglageDispositif = 2
    '    oDiag12123.TempsMesure = 90

    '    oDiag12123.MasseApresAspi = 3756
    '    oDiag12123.MasseApresComplement = 3492

    '    Assert.AreEqual(-2.0851071D, oDiag12123.DosageReelRND)


    'End Sub
    '<TestMethod()>
    'Public Sub testCalcEcartReglage()

    '    Dim oDiag12123 As New DiagnosticHelp12123()
    '    oDiag12123.debitMesure = 1.006
    '    oDiag12123.PressionMesure = 2
    '    oDiag12123.PressionMoyenne = 2.2
    '    oDiag12123.NbBuses = 8
    '    oDiag12123.ReglageDispositif = 2
    '    oDiag12123.TempsMesure = 90

    '    oDiag12123.MasseApresAspi = 3756
    '    oDiag12123.MasseApresComplement = 3492

    '    Assert.AreEqual(-195.9183365D, oDiag12123.EcartReglageRND)


    'End Sub
    '<TestMethod()>
    'Public Sub testCalcResultat()

    '    Dim oDiag12123 As New DiagnosticHelp12123()

    '    'Assert.AreEqual("", oDiag12123.Resultat)
    '    ''On force la calcul car EcartReglage est une Prop calculée
    '    'oDiag12123.debitMesure = 1.006
    '    'oDiag12123.PressionMesure = 2
    '    'oDiag12123.PressionMoyenne = 1.25
    '    'oDiag12123.NbBuses = 8
    '    'oDiag12123.ReglageDispositif = 1.786
    '    'oDiag12123.TempsMesure = 90
    '    'oDiag12123.MasseApresAspi = 3.756
    '    'oDiag12123.MasseApresComplement = 3.492
    '    'oDiag12123.calcule()
    '    'Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oDiag12123.Resultat)
    '    'oDiag12123.EcartReglage = 5
    '    'oDiag12123.calcule()
    '    'Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oDiag12123.Resultat)
    '    'oDiag12123.EcartReglage = 5.1
    '    'oDiag12123.calcule()
    '    'Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oDiag12123.Resultat)


    'End Sub
End Class
