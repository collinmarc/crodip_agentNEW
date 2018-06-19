Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



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

        oDiag = New Diagnostic()
        oDiag.id = "99-99"
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.inspecteurId = m_oAgent.id

        oDiagHelp12123 = New DiagnosticHelp12123
        oDiagHelp12123.bCalcule = False

        oDiagHelp12123.idDiag = oDiag.id
        oDiagHelp12123.debitMesure = 1.2D
        oDiagHelp12123.PressionMesure = 1.21D
        oDiagHelp12123.PressionMoyenne = 1.3D
        oDiagHelp12123.NbBuses = 1.4D

        oDiagHelp12123.Debitreel = 1.6D
        oDiagHelp12123.DebitTotal = 1.5D
        oDiagHelp12123.ReglageDispositif = 1.8D
        oDiagHelp12123.DebitTheorique = 1.9D
        oDiagHelp12123.TempsMesure = 1.91D
        oDiagHelp12123.QteEauPulverisee = 1.7D
        oDiagHelp12123.MasseApresAspi = 2
        oDiagHelp12123.MasseApresComplement = 3
        oDiagHelp12123.QteProduitConso = 4
        oDiagHelp12123.DosageReel = 1.95D
        oDiagHelp12123.EcartReglage = 1.96D
        oDiagHelp12123.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Debug.WriteLine("Création")
        Assert.IsTrue(String.IsNullOrEmpty(oDiagHelp12123.id))
        Assert.IsTrue(oDiagHelp12123.Save(oDiag.organismePresId, oDiag.inspecteurId))
        iD = oDiagHelp12123.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp12123.id))

        Debug.WriteLine("Lecture")
        oDiagHelp12123 = New DiagnosticHelp12123()
        oDiagHelp12123.id = iD
        oDiagHelp12123.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp12123.Load())

        Assert.AreEqual(oDiagHelp12123.debitMesure, 1.2D)
        Assert.AreEqual(oDiagHelp12123.PressionMesure, 1.21D)
        Assert.AreEqual(oDiagHelp12123.PressionMoyenne, 1.3D)
        Assert.AreEqual(oDiagHelp12123.NbBuses, 1.4D)
        Assert.AreEqual(oDiagHelp12123.DebitTotal, 1.5D)
        Assert.AreEqual(oDiagHelp12123.Debitreel, 1.6D)
        Assert.AreEqual(oDiagHelp12123.QteEauPulverisee, 1.7D)
        Assert.AreEqual(oDiagHelp12123.ReglageDispositif, 1.8D)
        Assert.AreEqual(oDiagHelp12123.DebitTheorique, 1.9D)
        Assert.AreEqual(oDiagHelp12123.TempsMesure, 1.91D)
        Assert.AreEqual(oDiagHelp12123.MasseApresAspi, 2)
        Assert.AreEqual(oDiagHelp12123.MasseApresComplement, 3)
        Assert.AreEqual(oDiagHelp12123.QteProduitConso, 4)
        Assert.AreEqual(oDiagHelp12123.DosageReel, 1.95D)
        Assert.AreEqual(oDiagHelp12123.EcartReglage, 1.96D)
        Assert.AreEqual(oDiagHelp12123.Resultat, DiagnosticItem.EtatDiagItemMAJEUR)


        'Maj de l'objet
        oDiagHelp12123.bCalcule = False
        oDiagHelp12123.debitMesure = 1.2D * 10
        oDiagHelp12123.PressionMesure = 1.21D * 10
        oDiagHelp12123.PressionMoyenne = 1.3D * 10
        oDiagHelp12123.NbBuses = 1.4D * 10

        oDiagHelp12123.Debitreel = 1.6D * 10
        oDiagHelp12123.DebitTotal = 1.5D * 10
        oDiagHelp12123.ReglageDispositif = 1.8D * 10
        oDiagHelp12123.DebitTheorique = 1.9D * 10

        oDiagHelp12123.TempsMesure = 1.91D * 10
        oDiagHelp12123.QteEauPulverisee = 1.7D * 10
        oDiagHelp12123.MasseApresAspi = 2 * 10
        oDiagHelp12123.MasseApresComplement = 3 * 10
        oDiagHelp12123.QteProduitConso = 4 * 10
        oDiagHelp12123.DosageReel = 1.95D * 10
        oDiagHelp12123.EcartReglage = 1.96D * 10
        oDiagHelp12123.Resultat = DiagnosticItem.EtatDiagItemMINEUR

        Debug.WriteLine("Update")
        Assert.IsTrue(oDiagHelp12123.Save(oDiag.organismePresId, oDiag.inspecteurId))

        Debug.WriteLine("Lecture")
        oDiagHelp12123 = New DiagnosticHelp12123()
        oDiagHelp12123.id = iD
        oDiagHelp12123.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp12123.Load())

        Assert.AreEqual(oDiagHelp12123.debitMesure, 1.2D * 10)
        Assert.AreEqual(oDiagHelp12123.PressionMesure, 1.21D * 10)
        Assert.AreEqual(oDiagHelp12123.PressionMoyenne, 1.3D * 10)
        Assert.AreEqual(oDiagHelp12123.NbBuses, 1.4D * 10)
        Assert.AreEqual(oDiagHelp12123.DebitTotal, 1.5D * 10)
        Assert.AreEqual(oDiagHelp12123.Debitreel, 1.6D * 10)
        Assert.AreEqual(oDiagHelp12123.QteEauPulverisee, 1.7D * 10)
        Assert.AreEqual(oDiagHelp12123.ReglageDispositif, 1.8D * 10)
        Assert.AreEqual(oDiagHelp12123.DebitTheorique, 1.9D * 10)
        Assert.AreEqual(oDiagHelp12123.TempsMesure, 1.91D * 10)
        Assert.AreEqual(oDiagHelp12123.MasseApresAspi, 2 * 10)
        Assert.AreEqual(oDiagHelp12123.MasseApresComplement, 3 * 10)
        Assert.AreEqual(oDiagHelp12123.QteProduitConso, 4 * 10)
        Assert.AreEqual(oDiagHelp12123.DosageReel, 1.95D * 10)
        Assert.AreEqual(oDiagHelp12123.EcartReglage, 1.96D * 10)
        Assert.AreEqual(oDiagHelp12123.Resultat, DiagnosticItem.EtatDiagItemMINEUR)

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
        oDiag.AddDiagItem(oDiagItem)

        'Ajout des mesures help12123
        '=========================
        oDiag.diagnosticHelp12123.bCalcule = False
        oDiag.diagnosticHelp12123.debitMesure = 10.1
        oDiag.diagnosticHelp12123.PressionMesure = 10.21
        oDiag.diagnosticHelp12123.PressionMoyenne = 10.2
        oDiag.diagnosticHelp12123.NbBuses = 10.3
        'Attention on affectre les valeur saisie avant les valeurs calculées , sinon le calcul se redécclenche
        oDiag.diagnosticHelp12123.Debitreel = 20.2
        oDiag.diagnosticHelp12123.DebitTotal = 20.1
        oDiag.diagnosticHelp12123.ReglageDispositif = 20.4
        oDiag.diagnosticHelp12123.DebitTheorique = 20.5
        oDiag.diagnosticHelp12123.TempsMesure = 20.6
        oDiag.diagnosticHelp12123.QteEauPulverisee = 20.3
        oDiag.diagnosticHelp12123.MasseApresAspi = 20
        oDiag.diagnosticHelp12123.MasseApresComplement = 21
        oDiag.diagnosticHelp12123.QteProduitConso = 22
        oDiag.diagnosticHelp12123.DosageReel = 20.81
        oDiag.diagnosticHelp12123.EcartReglage = 20.82

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        'Rechargement du Diag
        '=======================
        oDiag2 = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag2.diagnosticHelp12123.bCalcule = False
        Assert.AreEqual(idDiag, oDiag2.id)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.debitMesure, 10.1D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.PressionMesure, 10.21D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.PressionMoyenne, 10.2D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.NbBuses, 10.3D)

        Assert.AreEqual(oDiag2.diagnosticHelp12123.Debitreel, 20.2D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.DebitTotal, 20.1D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.ReglageDispositif, 20.4D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.TempsMesure, 20.6D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.QteEauPulverisee, 20.3D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.DebitTheorique, 20.5D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.MasseApresAspi, 20)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.MasseApresComplement, 21)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.QteProduitConso, 22)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.DosageReel, 20.81D)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.EcartReglage, 20.82D)

        oDiag2.diagnosticHelp12123.debitMesure = 10.1 * 10
        oDiag2.diagnosticHelp12123.PressionMesure = 10.21 * 10
        oDiag2.diagnosticHelp12123.PressionMoyenne = 10.2 * 10
        oDiag2.diagnosticHelp12123.NbBuses = 10.3 * 10

        oDiag2.diagnosticHelp12123.Debitreel = 20.2 * 10
        oDiag2.diagnosticHelp12123.DebitTotal = 20.1 * 10
        oDiag2.diagnosticHelp12123.ReglageDispositif = 20.4 * 10
        oDiag2.diagnosticHelp12123.DebitTheorique = 20.5 * 10
        oDiag2.diagnosticHelp12123.TempsMesure = 20.6 * 10
        oDiag2.diagnosticHelp12123.QteEauPulverisee = 20.3 * 10
        oDiag2.diagnosticHelp12123.MasseApresAspi = 21 * 10
        oDiag2.diagnosticHelp12123.MasseApresComplement = 22 * 10
        oDiag2.diagnosticHelp12123.QteProduitConso = 23 * 10
        oDiag2.diagnosticHelp12123.DosageReel = 20.81 * 10
        oDiag2.diagnosticHelp12123.EcartReglage = 20.82 * 10

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag2)

        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag.diagnosticHelp12123.bCalcule = False
        Assert.AreEqual(idDiag, oDiag.id)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.debitMesure, 10.1D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.PressionMesure, 10.21D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.PressionMoyenne, 10.2D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.NbBuses, 10.3D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.DebitTotal, 20.1D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.Debitreel, 20.2D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.QteEauPulverisee, 20.3D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.ReglageDispositif, 20.4D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.DebitTheorique, 20.5D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.TempsMesure, 20.6D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.MasseApresAspi, 21 * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.MasseApresComplement, 22 * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.QteProduitConso, 23 * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.DosageReel, 20.81D * 10)
        Assert.AreEqual(oDiag2.diagnosticHelp12123.EcartReglage, 20.82D * 10)

        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub

    <TestMethod()>
    Public Sub testCalcDebitReelTotal()

        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.debitMesure = 1.006
        oDiag12123.PressionMesure = 2
        oDiag12123.PressionMoyenne = 2.2
        oDiag12123.NbBuses = 8

        Assert.AreEqual(1.06D, oDiag12123.DebitReelRND)
        Assert.AreEqual(8.44D, oDiag12123.DebitTotalRND)

    End Sub
    <TestMethod()>
    Public Sub testCalcDebitTheorique()

        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.debitMesure = 1.006
        oDiag12123.PressionMesure = 2
        oDiag12123.PressionMoyenne = 2.2
        oDiag12123.NbBuses = 8

        oDiag12123.ReglageDispositif = 2

        Assert.AreEqual(0.161D, oDiag12123.DebitTheoriqueRND)


    End Sub
    <TestMethod()>
    Public Sub testCalcQteEauPulverisee()

        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.debitMesure = 1.006
        oDiag12123.PressionMesure = 2
        oDiag12123.PressionMoyenne = 2.2
        oDiag12123.NbBuses = 8
        oDiag12123.ReglageDispositif = 2
        oDiag12123.TempsMesure = 90

        Assert.AreEqual(12.66122D, oDiag12123.QteEauPulveriseeRND)


    End Sub
    <TestMethod()>
    Public Sub testCalcQteProduitConsomme()

        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.MasseApresAspi = 3756
        oDiag12123.MasseApresComplement = 3492

        Assert.AreEqual(-264, oDiag12123.QteProduitConso)


    End Sub
    <TestMethod()>
    Public Sub testCalcDosageReel()

        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.debitMesure = 1.006
        oDiag12123.PressionMesure = 2
        oDiag12123.PressionMoyenne = 2.2
        oDiag12123.NbBuses = 8
        oDiag12123.ReglageDispositif = 2
        oDiag12123.TempsMesure = 90

        oDiag12123.MasseApresAspi = 3756
        oDiag12123.MasseApresComplement = 3492

        Assert.AreEqual(-2.0851071D, oDiag12123.DosageReelRND)


    End Sub
    <TestMethod()>
    Public Sub testCalcEcartReglage()

        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.debitMesure = 1.006
        oDiag12123.PressionMesure = 2
        oDiag12123.PressionMoyenne = 2.2
        oDiag12123.NbBuses = 8
        oDiag12123.ReglageDispositif = 2
        oDiag12123.TempsMesure = 90

        oDiag12123.MasseApresAspi = 3756
        oDiag12123.MasseApresComplement = 3492

        Assert.AreEqual(-195.9183365D, oDiag12123.EcartReglageRND)


    End Sub
    <TestMethod()>
    Public Sub testCalcResultat()

        Dim oDiag12123 As New DiagnosticHelp12123()

        'Assert.AreEqual("", oDiag12123.Resultat)
        ''On force la calcul car EcartReglage est une Prop calculée
        'oDiag12123.debitMesure = 1.006
        'oDiag12123.PressionMesure = 2
        'oDiag12123.PressionMoyenne = 1.25
        'oDiag12123.NbBuses = 8
        'oDiag12123.ReglageDispositif = 1.786
        'oDiag12123.TempsMesure = 90
        'oDiag12123.MasseApresAspi = 3.756
        'oDiag12123.MasseApresComplement = 3.492
        'oDiag12123.calcule()
        'Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oDiag12123.Resultat)
        'oDiag12123.EcartReglage = 5
        'oDiag12123.calcule()
        'Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oDiag12123.Resultat)
        'oDiag12123.EcartReglage = 5.1
        'oDiag12123.calcule()
        'Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oDiag12123.Resultat)


    End Sub
End Class
