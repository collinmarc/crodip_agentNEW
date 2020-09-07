Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour DiagnosticHelp12123Test, 
'''</summary>
<TestClass()> _
Public Class DiagnosticHelp12123Pompetest
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

        Dim oDiagHelp12123P As DiagnosticHelp12123Pompe
        Dim idDiag As String = m_oStructure.id & "-" & m_oAgent.id & "-99"
        Dim iD As String


        oDiagHelp12123P = New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oDiagHelp12123P.idDiag = idDiag

        oDiagHelp12123P.debitMesure = 1.2D
        oDiagHelp12123P.PressionMesure = 1.21D
        oDiagHelp12123P.PressionMoyenne = 1.3D
        oDiagHelp12123P.NbBuses = 1.4D
        oDiagHelp12123P.DebitTotal = 1.5D
        oDiagHelp12123P.DebitReel = 1.6D
        oDiagHelp12123P.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Assert.IsTrue(oDiagHelp12123P.Save(m_oAgent.idStructure.ToString, m_oAgent.id.ToString))
        iD = oDiagHelp12123P.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp12123P.id))

        Debug.WriteLine("Lecture")
        oDiagHelp12123P = New DiagnosticHelp12123Pompe(iD, idDiag)
        Assert.IsTrue(oDiagHelp12123P.Load())

        Assert.AreEqual(iD, oDiagHelp12123P.id, iD)
        Assert.AreEqual(idDiag, oDiagHelp12123P.idDiag, idDiag)
        Assert.AreEqual(1, oDiagHelp12123P.numero, 1)

        Assert.AreEqual(1.2D, oDiagHelp12123P.debitMesure)
        Assert.AreEqual(1.21D, oDiagHelp12123P.PressionMesure)
        Assert.AreEqual(1.3D, oDiagHelp12123P.PressionMoyenne)
        Assert.AreEqual(1.4D, oDiagHelp12123P.NbBuses)
        Assert.AreEqual(1.5D, oDiagHelp12123P.DebitTotal)
        Assert.AreEqual(1.6D, oDiagHelp12123P.DebitReel)

        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oDiagHelp12123P.Resultat)


        'Maj de l'objet
        oDiagHelp12123P.bCalcule = False
        oDiagHelp12123P.debitMesure = 1.2D * 10
        oDiagHelp12123P.PressionMesure = 1.21D * 10
        oDiagHelp12123P.PressionMoyenne = 1.3D * 10
        oDiagHelp12123P.NbBuses = 1.4D * 10

        oDiagHelp12123P.DebitReel = 1.6D * 10
        oDiagHelp12123P.DebitTotal = 1.5D * 10
        oDiagHelp12123P.Resultat = DiagnosticItem.EtatDiagItemMINEUR

        Debug.WriteLine("Update")
        Assert.IsTrue(oDiagHelp12123P.Save(m_oAgent.idStructure.ToString, m_oAgent.id.ToString))

        Debug.WriteLine("Lecture")
        oDiagHelp12123P = New DiagnosticHelp12123Pompe(iD, idDiag)
        Assert.IsTrue(oDiagHelp12123P.Load())

        Assert.AreEqual(oDiagHelp12123P.debitMesure, 1.2D * 10)
        Assert.AreEqual(oDiagHelp12123P.PressionMesure, 1.21D * 10)
        Assert.AreEqual(oDiagHelp12123P.PressionMoyenne, 1.3D * 10)
        Assert.AreEqual(oDiagHelp12123P.NbBuses, 1.4D * 10)
        Assert.AreEqual(oDiagHelp12123P.DebitTotal, 1.5D * 10)
        Assert.AreEqual(oDiagHelp12123P.DebitReel, 1.6D * 10)

        Debug.WriteLine("Suppression")
        oDiagHelp12123P.Delete()

    End Sub
    '''<summary>
    '''Test de la sauvegarde de la colleciton des mesures
    '''</summary>
    <TestMethod()> _
    Public Sub TST_SaveColMesures()
        Dim oHelp12123 As New DiagnosticHelp12123()
        Dim oPompe As DiagnosticHelp12123Pompe
        Dim idDiag As String = m_oStructure.id & "-" & m_oAgent.id & "-99"
        Dim iD As String

        'Suppressino des Mesures
        CSDb.ExecuteSQL("DELETE FROM DiagnosticItem WHERE idDiagnostic= '" + idDiag + "'")

        oPompe = New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oPompe.idDiag = idDiag

        oPompe.debitMesure = 1.2D
        oPompe.PressionMesure = 1.21D
        oPompe.PressionMoyenne = 1.3D
        oPompe.NbBuses = 5
        'oPompe.DebitTotal = 1.5D
        'oPompe.DebitReel = 1.6D
        oPompe.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Dim oMesure As DiagnosticHelp12123Mesure
        'Mesure 1
        oMesure = oPompe.lstMesures(0)
        oMesure.idDiag = oPompe.idDiag
        oMesure.ReglageDispositif = 1.1D
        'Mesure 2
        oMesure = oPompe.lstMesures(1)
        oMesure.idDiag = oPompe.idDiag
        oMesure.ReglageDispositif = 1.2D
        'Mesure 3
        oMesure = oPompe.lstMesures(2)
        oMesure.idDiag = oPompe.idDiag
        oMesure.ReglageDispositif = 1.3D

        Assert.IsTrue(oPompe.Save(m_oAgent.idStructure.ToString, m_oAgent.id.ToString))
        iD = oPompe.id
        Assert.IsFalse(String.IsNullOrEmpty(oPompe.id))

        Debug.WriteLine("Lecture")
        oPompe = New DiagnosticHelp12123Pompe(iD, idDiag)
        Assert.IsTrue(oPompe.Load())

        Assert.AreEqual(3, oPompe.getNbMesures())
        oMesure = oPompe.getMesure(0)
        Assert.AreEqual(oPompe.idDiag, idDiag)
        Assert.AreEqual(oPompe.numero, oMesure.numeroPompe)
        Assert.AreEqual(1, oMesure.numeroMesure)
        Assert.AreEqual(1.1D, oMesure.ReglageDispositif)

        oMesure = oPompe.getMesure(1)
        Assert.AreEqual(oPompe.idDiag, idDiag)
        Assert.AreEqual(oPompe.numero, oMesure.numeroPompe)
        Assert.AreEqual(2, oMesure.numeroMesure)
        Assert.AreEqual(1.2D, oMesure.ReglageDispositif)

        oMesure = oPompe.getMesure(2)
        Assert.AreEqual(oPompe.idDiag, idDiag)
        Assert.AreEqual(oPompe.numero, oMesure.numeroPompe)
        Assert.AreEqual(3, oMesure.numeroMesure)
        Assert.AreEqual(1.3D, oMesure.ReglageDispositif)


        'Maj des mesures
        oMesure = oPompe.getMesure(0)
        oMesure.ReglageDispositif = 2.1D

        oMesure = oPompe.getMesure(1)
        oMesure.ReglageDispositif = 2.2D

        oMesure = oPompe.getMesure(2)
        oMesure.ReglageDispositif = 2.3D

        Assert.IsTrue(oPompe.Save(m_oAgent.idStructure.ToString, m_oAgent.id.ToString.ToString))
        Debug.WriteLine("Lecture")
        oPompe = New DiagnosticHelp12123Pompe(iD, idDiag)
        Assert.IsTrue(oPompe.Load())

        Assert.AreEqual(3, oPompe.getNbMesures())
        oMesure = oPompe.getMesure(0)
        Assert.AreEqual(2.1D, oMesure.ReglageDispositif)

        oMesure = oPompe.getMesure(1)
        Assert.AreEqual(2.2D, oMesure.ReglageDispositif)

        oMesure = oPompe.getMesure(2)
        Assert.AreEqual(2.3D, oMesure.ReglageDispositif)



    End Sub
    <TestMethod()>
    Public Sub testLoadByNumPompe()
        Dim oHelp12123 As New DiagnosticHelp12123()
        Dim oDiagHelp12123P As DiagnosticHelp12123Pompe
        Dim idDiag As String = m_oStructure.id & "-" & m_oAgent.id & "-99"
        Dim iD As String

        'Arrange
        oDiagHelp12123P = New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oDiagHelp12123P.idDiag = idDiag

        oDiagHelp12123P.debitMesure = 1.2D
        oDiagHelp12123P.PressionMesure = 1.21D
        oDiagHelp12123P.PressionMoyenne = 1.3D
        oDiagHelp12123P.NbBuses = 1.4D
        oDiagHelp12123P.DebitTotal = 1.5D
        oDiagHelp12123P.DebitReel = 1.6D
        oDiagHelp12123P.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Assert.IsTrue(oDiagHelp12123P.Save(m_oStructure.id.ToString, m_oAgent.id.ToString))
        iD = oDiagHelp12123P.id

        'Act
        oDiagHelp12123P = New DiagnosticHelp12123Pompe("", "")
        oDiagHelp12123P.Load(idDiag, 1)

        'Assert
        Assert.AreEqual(iD, oDiagHelp12123P.id)
        Assert.AreEqual(idDiag, oDiagHelp12123P.idDiag)
        Assert.AreEqual(1, oDiagHelp12123P.numero, 1)

        Assert.AreEqual(1.2D, oDiagHelp12123P.debitMesure)
        Assert.AreEqual(1.21D, oDiagHelp12123P.PressionMesure)
        Assert.AreEqual(1.3D, oDiagHelp12123P.PressionMoyenne)
        Assert.AreEqual(1.4D, oDiagHelp12123P.NbBuses)
        Assert.AreEqual(1.5D, oDiagHelp12123P.DebitTotal)
        Assert.AreEqual(1.6D, oDiagHelp12123P.DebitReel)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oDiagHelp12123P.Resultat)

    End Sub

    <TestMethod()>
    Public Sub testSaveDiag()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim idDiag As String
        Dim oHelp12123 As New DiagnosticHelp12123()


        CSDb.ExecuteSQL("DELETE FROM diagnosticItem")

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

        'Ajout de 2 pompes
        Dim oPompe As DiagnosticHelp12123Pompe
        oPompe = New DiagnosticHelp12123Pompe(oHelp12123, 1)
        oPompe.debitMesure = 10.1D
        'Ajout de 3 Mesures
        Dim oMesure As DiagnosticHelp12123Mesure
        oMesure = oPompe.lstMesures(0)
        oMesure.ReglageDispositif = 1.1D
        oMesure = oPompe.lstMesures(1)
        oMesure.ReglageDispositif = 1.2D
        oMesure = oPompe.lstMesures(2)
        oMesure.ReglageDispositif = 1.3D

        oDiag.diagnosticHelp12123.lstPompes.Add(oPompe)

        oPompe = New DiagnosticHelp12123Pompe(oHelp12123, 2)
        oPompe.debitMesure = 20.1D
        'Ajout de 3 Mesures
        oMesure = oPompe.lstMesures(0)
        oMesure.ReglageDispositif = 2.1D
        oMesure = oPompe.lstMesures(1)
        oMesure.ReglageDispositif = 2.2D
        oMesure = oPompe.lstMesures(2)
        oMesure.ReglageDispositif = 2.3D
        oDiag.diagnosticHelp12123.lstPompes.Add(oPompe)

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        'Rechargement du Diag
        '=======================
        oDiag2 = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag2.diagnosticHelp12123.bCalcule = False
        Assert.AreEqual(idDiag, oDiag2.id)

        'Vérification du nombre de Pompe
        Assert.AreEqual(2, oDiag2.diagnosticHelp12123.lstPompes.Count)
        'Verif Pompe1
        oPompe = oDiag2.diagnosticHelp12123.lstPompes(0)
        Assert.AreEqual(1, oPompe.numero)
        Assert.AreEqual(10.1D, oPompe.debitMesure)
        Assert.AreEqual(3, oPompe.getNbMesures())
        Assert.AreEqual(1.1D, oPompe.getMesure(0).ReglageDispositif)
        Assert.AreEqual(1.2D, oPompe.getMesure(1).ReglageDispositif)
        Assert.AreEqual(1.3D, oPompe.getMesure(2).ReglageDispositif)

        'Verif Pompe2
        oPompe = oDiag2.diagnosticHelp12123.lstPompes(1)
        Assert.AreEqual(2, oPompe.numero)
        Assert.AreEqual(20.1D, oPompe.debitMesure)
        Assert.AreEqual(3, oPompe.getNbMesures())
        Assert.AreEqual(2.1D, oPompe.getMesure(0).ReglageDispositif)
        Assert.AreEqual(2.2D, oPompe.getMesure(1).ReglageDispositif)
        Assert.AreEqual(2.3D, oPompe.getMesure(2).ReglageDispositif)

        'Ajout pompe3
        oPompe = oDiag2.diagnosticHelp12123.AjoutePompe()
        oPompe.debitMesure = 30.1D
        'Ajout de 3 Mesures
        oMesure = oPompe.lstMesures(0)
        oMesure.ReglageDispositif = 3.1D
        oMesure = oPompe.lstMesures(1)
        oMesure.ReglageDispositif = 3.2D
        oMesure = oPompe.lstMesures(2)
        oMesure.ReglageDispositif = 3.3D

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag2)

        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag.diagnosticHelp12123.bCalcule = False
        Assert.AreEqual(idDiag, oDiag.id)
        Assert.AreEqual(3, oDiag.diagnosticHelp12123.lstPompes.Count)
        'Varif de la pompe3

        oPompe = oDiag.diagnosticHelp12123.lstPompes(2)
        Assert.AreEqual(3, oPompe.numero)
        Assert.AreEqual(30.1D, oPompe.debitMesure)
        Assert.AreEqual(3, oPompe.getNbMesures())
        Assert.AreEqual(3.1D, oPompe.getMesure(0).ReglageDispositif)
        Assert.AreEqual(3.2D, oPompe.getMesure(1).ReglageDispositif)
        Assert.AreEqual(3.3D, oPompe.getMesure(2).ReglageDispositif)
        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

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

        oMesure = oPompe.lstMesures(0)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 10.8D
        oMesure.MasseAspire = 3.492D

        oMesure = oPompe.lstMesures(1)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 10.8D
        oMesure.MasseAspire = 3.492D

        oMesure = oPompe.lstMesures(2)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 10.8D
        oMesure.MasseAspire = 3.492D

        Assert.AreEqual(3.77D, oPompe.EcartReglageMoyen)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oPompe.Resultat)

        oMesure.MasseInitiale = 11D
        Assert.AreEqual(4.72D, oPompe.EcartReglageMoyen)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oPompe.Resultat)

        oMesure.MasseInitiale = 11.1D
        Assert.AreEqual(5.19D, oPompe.EcartReglageMoyen)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oPompe.Resultat)
    End Sub
End Class
