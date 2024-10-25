Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CrodipWS



'''<summary>
'''Classe de test pour Le traitement des semences
''' '''</summary>
<TestClass()> _
Public Class DiagnosticHelp12123TrtSemTest
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

        Dim oDiagHelp12123P As DiagnosticHelp12123PompeTrtSem
        Dim idDiag As String = createAndSaveDiagnostic().id
        Dim iD As String
        Dim oCSDB As New CSDb(True)


        oDiagHelp12123P = New DiagnosticHelp12123PompeTrtSem(oHelp12123, 1)
        oDiagHelp12123P.idDiag = idDiag

        oDiagHelp12123P.PeseeMoyenne = 1.3D
        oDiagHelp12123P.EcartReglageMoyen = 2.3D
        oDiagHelp12123P.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Assert.IsTrue(oDiagHelp12123P.Save(m_oAgent.idStructure, m_oAgent.id, oCSDB))
        iD = oDiagHelp12123P.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp12123P.id))

        Debug.WriteLine("Lecture")
        oDiagHelp12123P = New DiagnosticHelp12123PompeTrtSem(iD, idDiag)
        Assert.IsTrue(oDiagHelp12123P.Load())

        Assert.AreEqual(iD, oDiagHelp12123P.id, iD)
        Assert.AreEqual(idDiag, oDiagHelp12123P.idDiag, idDiag)
        Assert.AreEqual(1, oDiagHelp12123P.numero, 1)

        Assert.AreEqual(1.3D, oDiagHelp12123P.PeseeMoyenne)
        Assert.AreEqual(2.3D, oDiagHelp12123P.EcartReglageMoyen)

        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oDiagHelp12123P.Resultat)


        'Maj de l'objet
        oDiagHelp12123P.bCalcule = False
        oDiagHelp12123P.PeseeMoyenne = 1.3D * 10
        oDiagHelp12123P.EcartReglageMoyen = 2.3D * 10
        oDiagHelp12123P.Resultat = DiagnosticItem.EtatDiagItemMINEUR

        Debug.WriteLine("Update")
        Assert.IsTrue(oDiagHelp12123P.Save(m_oAgent.idStructure, m_oAgent.id, oCSDB))

        Debug.WriteLine("Lecture")
        oDiagHelp12123P = New DiagnosticHelp12123PompeTrtSem(iD, idDiag)
        Assert.IsTrue(oDiagHelp12123P.Load())

        Assert.AreEqual(1.3D * 10, oDiagHelp12123P.PeseeMoyenne)
        Assert.AreEqual(2.3D * 10, oDiagHelp12123P.EcartReglageMoyen)

        Debug.WriteLine("Suppression")
        oDiagHelp12123P.Delete()

    End Sub
    '''<summary>
    '''Test de la sauvegarde de la colleciton des mesures
    '''</summary>
    <TestMethod()> _
    Public Sub TST_SaveColMesures()
        Dim oHelp12123 As New DiagnosticHelp12123()
        Dim oPompe As DiagnosticHelp12123PompeTrtSem
        Dim idDiag As String = createAndSaveDiagnostic().id
        Dim iD As String
        Dim oCSDB As New CSDb(True)

        'Suppressino des Mesures
        oCSDB.Execute("DELETE FROM DiagnosticItem WHERE idDiagnostic= '" + idDiag + "'")

        oPompe = New DiagnosticHelp12123PompeTrtSem(oHelp12123, 1)
        oPompe.idDiag = idDiag

        oPompe.PeseeMoyenne = 1.2D
        oPompe.EcartReglageMoyen = 1.21D
        oPompe.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Dim oMesure As DiagnosticHelp12123MesuresTrtSem
        'Mesure 1
        oMesure = oPompe.lstMesures(0)
        oMesure.idDiag = oPompe.idDiag
        oMesure.qteGrains = 1.1D
        'Mesure 2
        oMesure = oPompe.lstMesures(1)
        oMesure.idDiag = oPompe.idDiag
        oMesure.qteGrains = 1.2D
        ''Mesure 3
        'oMesure = oPompe.lstMesures(2)
        'oMesure.idDiag = oPompe.idDiag
        'oMesure.qteGrains = 1.3D

        Assert.IsTrue(oPompe.Save(m_oAgent.idStructure, m_oAgent.id, oCSDB))
        iD = oPompe.id
        Assert.IsFalse(String.IsNullOrEmpty(oPompe.id))

        Debug.WriteLine("Lecture")
        oPompe = New DiagnosticHelp12123PompeTrtSem(iD, idDiag)
        Assert.IsTrue(oPompe.Load())
        Assert.AreEqual(2, oPompe.getNbMesures())
        oMesure = oPompe.getMesure(0)
        Assert.AreEqual(oPompe.idDiag, idDiag)
        Assert.AreEqual(oPompe.numero, oMesure.numPompe)
        Assert.AreEqual(1, oMesure.numMesure)
        Assert.AreEqual(1.1D, oMesure.qteGrains)

        oMesure = oPompe.getMesure(1)
        Assert.AreEqual(oPompe.idDiag, idDiag)
        Assert.AreEqual(oPompe.numero, oMesure.numPompe)
        Assert.AreEqual(2, oMesure.numMesure)
        Assert.AreEqual(1.2D, oMesure.qteGrains)

        'oMesure = oPompe.getMesure(2)
        'Assert.AreEqual(oPompe.idDiag, idDiag)
        'Assert.AreEqual(oPompe.numero, oMesure.numPompe)
        'Assert.AreEqual(3, oMesure.numMesure)
        'Assert.AreEqual(1.3D, oMesure.qteGrains)


        'Maj des mesures
        oMesure = oPompe.getMesure(0)
        oMesure.qteGrains = 2.1D

        oMesure = oPompe.getMesure(1)
        oMesure.qteGrains = 2.2D

        'oMesure = oPompe.getMesure(2)
        'oMesure.qteGrains = 2.3D

        Assert.IsTrue(oPompe.Save(m_oAgent.idStructure, m_oAgent.id, oCSDB))
        Debug.WriteLine("Lecture")
        oPompe = New DiagnosticHelp12123PompeTrtSem(iD, idDiag)
        Assert.IsTrue(oPompe.Load())

        Assert.AreEqual(2, oPompe.getNbMesures())
        oMesure = oPompe.getMesure(0)
        Assert.AreEqual(2.1D, oMesure.qteGrains)

        oMesure = oPompe.getMesure(1)
        Assert.AreEqual(2.2D, oMesure.qteGrains)

        'oMesure = oPompe.getMesure(2)
        'Assert.AreEqual(2.3D, oMesure.qteGrains)
        oCSDB.free()


    End Sub
    <TestMethod()>
    Public Sub testLoadByNumPompe()
        Dim oHelp12123 As New DiagnosticHelp12123()
        Dim oDiagHelp12123P As DiagnosticHelp12123PompeTrtSem
        Dim idDiag As String = createAndSaveDiagnostic().id
        Dim iD As String
        Dim oCSDB As New CSDb(True)

        'Arrange
        oDiagHelp12123P = New DiagnosticHelp12123PompeTrtSem(oHelp12123, 1)
        oDiagHelp12123P.idDiag = idDiag

        oDiagHelp12123P.PeseeMoyenne = 1.2D
        oDiagHelp12123P.EcartReglageMoyen = 1.21D
        oDiagHelp12123P.Resultat = DiagnosticItem.EtatDiagItemMAJEUR

        Assert.IsTrue(oDiagHelp12123P.Save(m_oStructure.id, m_oAgent.id, oCSDB))
        iD = oDiagHelp12123P.id

        'Act
        oDiagHelp12123P = New DiagnosticHelp12123PompeTrtSem("", "")
        oDiagHelp12123P.Load(idDiag, 1)

        'Assert
        Assert.AreEqual(iD, oDiagHelp12123P.id)
        Assert.AreEqual(idDiag, oDiagHelp12123P.idDiag)
        Assert.AreEqual(1, oDiagHelp12123P.numero, 1)

        Assert.AreEqual(1.2D, oDiagHelp12123P.PeseeMoyenne)
        Assert.AreEqual(1.21D, oDiagHelp12123P.EcartReglageMoyen)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oDiagHelp12123P.Resultat)

        oCSDB.free()
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
        Dim oPompe As DiagnosticHelp12123PompeTrtSem
        oPompe = New DiagnosticHelp12123PompeTrtSem(oHelp12123, 1)
        oPompe.PeseeMoyenne = 10.1D
        'Ajout de 3 Mesures
        Dim oMesure As DiagnosticHelp12123MesuresTrtSem
        oMesure = oPompe.lstMesures(0)
        oMesure.qteGrains = 1.1D
        oMesure = oPompe.lstMesures(1)
        oMesure.qteGrains = 1.2D
        'oMesure = oPompe.lstMesures(2)
        'oMesure.qteGrains = 1.3

        oDiag.diagnosticHelp12123.lstPompesTrtSem.Add(oPompe)

        oPompe = New DiagnosticHelp12123PompeTrtSem(oHelp12123, 2)
        oPompe.PeseeMoyenne = 20.1D
        'Ajout de 3 Mesures
        oMesure = oPompe.lstMesures(0)
        oMesure.qteGrains = 2.1D
        oMesure = oPompe.lstMesures(1)
        oMesure.qteGrains = 2.2D
        'oMesure = oPompe.lstMesures(2)
        'oMesure.qteGrains = 2.3
        oDiag.diagnosticHelp12123.lstPompesTrtSem.Add(oPompe)

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
        Assert.AreEqual(2, oDiag2.diagnosticHelp12123.lstPompesTrtSem.Count)
        'Verif Pompe1
        oPompe = oDiag2.diagnosticHelp12123.lstPompesTrtSem(0)
        Assert.AreEqual(1, oPompe.numero)
        Assert.AreEqual(10.1D, oPompe.PeseeMoyenne)
        Assert.AreEqual(2, oPompe.getNbMesures())
        Assert.AreEqual(1.1D, oPompe.getMesure(0).qteGrains)
        Assert.AreEqual(1.2D, oPompe.getMesure(1).qteGrains)
        '        Assert.AreEqual(1.3D, oPompe.getMesure(2).qteGrains)

        'Verif Pompe2
        oPompe = oDiag2.diagnosticHelp12123.lstPompesTrtSem(1)
        Assert.AreEqual(2, oPompe.numero)
        Assert.AreEqual(20.1D, oPompe.PeseeMoyenne)
        Assert.AreEqual(2, oPompe.getNbMesures())
        Assert.AreEqual(2.1D, oPompe.getMesure(0).qteGrains)
        Assert.AreEqual(2.2D, oPompe.getMesure(1).qteGrains)
        'Assert.AreEqual(2.3D, oPompe.getMesure(2).qteGrains)

        'Ajout pompe3
        oPompe = oDiag2.diagnosticHelp12123.AjoutePompeTrtSem()
        oPompe.PeseeMoyenne = 30.1D
        'Ajout de 3 Mesures
        oMesure = oPompe.lstMesures(0)
        oMesure.qteGrains = 3.1D
        oMesure = oPompe.lstMesures(1)
        oMesure.qteGrains = 3.2D
        'oMesure = oPompe.lstMesures(2)
        'oMesure.qteGrains = 3.3D

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag2)

        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        oDiag.diagnosticHelp12123.bCalcule = False
        Assert.AreEqual(idDiag, oDiag.id)
        Assert.AreEqual(3, oDiag.diagnosticHelp12123.lstPompesTrtSem.Count)
        'Varif de la pompe3

        oPompe = oDiag.diagnosticHelp12123.lstPompesTrtSem(2)
        Assert.AreEqual(3, oPompe.numero)
        Assert.AreEqual(30.1D, oPompe.PeseeMoyenne)
        Assert.AreEqual(2, oPompe.getNbMesures())
        Assert.AreEqual(3.1D, oPompe.getMesure(0).qteGrains)
        Assert.AreEqual(3.2D, oPompe.getMesure(1).qteGrains)
        ' Assert.AreEqual(3.3D, oPompe.getMesure(2).qteGrains)
        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub

    <TestMethod()>
    Public Sub testCalcResultatPompe()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As DiagnosticHelp12123MesuresTrtSem
        Dim oPompe As New DiagnosticHelp12123PompeTrtSem(oHelp12123, 1)


        oMesure = oPompe.lstMesures(0)
        oMesure.qteGrains = 5
        oMesure.DebitSouhaite = 4.8D
        oMesure.Pesee1 = 4.5D
        oMesure.Pesee2 = 4.9D
        oMesure.Pesee3 = 4.8D

        Assert.AreEqual(4.733D, oMesure.PeseeMoyenne)
        Assert.AreEqual(-6.25D, oMesure.Ecart1)
        Assert.AreEqual(2.083D, oMesure.Ecart2)
        Assert.AreEqual(0D, oMesure.Ecart3)
        Assert.AreEqual(-1.396D, oMesure.EcartMoyen)

        oMesure = oPompe.lstMesures(1)
        oMesure.qteGrains = 6
        oMesure.DebitSouhaite = 5.8D
        oMesure.Pesee1 = 5.5D
        oMesure.Pesee2 = 5.9D
        oMesure.Pesee3 = 5.8D

        Assert.AreEqual(5.733D, oMesure.PeseeMoyenne)
        Assert.AreEqual(-5.172D, oMesure.Ecart1)
        Assert.AreEqual(1.724D, oMesure.Ecart2)
        Assert.AreEqual(0D, oMesure.Ecart3)
        Assert.AreEqual(-1.155D, oMesure.EcartMoyen)

        'oMesure = oPompe.lstMesures(2)
        'oMesure.qteGrains = 7
        'oMesure.DebitSouhaite = 6.8D
        'oMesure.Pesee1 = 6.5D
        'oMesure.Pesee2 = 6.9D
        'oMesure.Pesee3 = 6.8D

        oPompe.calcule()
        Assert.AreEqual(5.233D, oPompe.PeseeMoyenne)
        Assert.AreEqual(-1.276D, oPompe.EcartReglageMoyen)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oPompe.Resultat)

        oMesure = oPompe.lstMesures(1)
        oMesure.qteGrains = 7
        oMesure.DebitSouhaite = 4D
        oMesure.Pesee1 = 6.5D
        oMesure.Pesee2 = 6.9D
        oMesure.Pesee3 = 6.8D
        oPompe.calcule()
        Assert.AreEqual(5.733D, oPompe.PeseeMoyenne)
        Assert.AreEqual(33.464D, oPompe.EcartReglageMoyen)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oPompe.Resultat)

    End Sub
    <TestMethod()>
    Public Sub testCalcResultatDiagHelp12123TrtSem()
        Dim oHelp12123 As New DiagnosticHelp12123()

        Dim oMesure As DiagnosticHelp12123MesuresTrtSem
        '====POMPE1====
        Dim oPompe As DiagnosticHelp12123PompeTrtSem = oHelp12123.AjoutePompeTrtSem()
        oMesure = oPompe.lstMesures(0)
        oMesure.qteGrains = 5
        oMesure.DebitSouhaite = 4.8D
        oMesure.Pesee1 = 4.5D
        oMesure.Pesee2 = 4.9D
        oMesure.Pesee3 = 4.8D


        oMesure = oPompe.lstMesures(1)
        oMesure.qteGrains = 6
        oMesure.DebitSouhaite = 5.8D
        oMesure.Pesee1 = 5.5D
        oMesure.Pesee2 = 5.9D
        oMesure.Pesee3 = 5.8D


        'oMesure = oPompe.lstMesures(2)
        'oMesure.qteGrains = 7
        'oMesure.DebitSouhaite = 6.8D
        'oMesure.Pesee1 = 6.5D
        'oMesure.Pesee2 = 6.9D
        'oMesure.Pesee3 = 6.8D

        '==== POMPE1
        oPompe.calcule()
        Assert.AreEqual(5.233D, oPompe.PeseeMoyenne)
        Assert.AreEqual(-1.276D, oPompe.EcartReglageMoyen)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oPompe.Resultat)

        '======= POMPE2 =====
        oPompe = oHelp12123.AjoutePompeTrtSem()


        oMesure = oPompe.lstMesures(0)
        oMesure.qteGrains = 5
        oMesure.DebitSouhaite = 4.8D
        oMesure.Pesee1 = 4.5D
        oMesure.Pesee2 = 4.9D
        oMesure.Pesee3 = 4.8D


        oMesure = oPompe.lstMesures(1)
        oMesure.qteGrains = 6
        oMesure.DebitSouhaite = 5.8D
        oMesure.Pesee1 = 5.5D
        oMesure.Pesee2 = 5.9D
        oMesure.Pesee3 = 5.8D


        'oMesure = oPompe.lstMesures(2)
        'oMesure.qteGrains = 7
        'oMesure.DebitSouhaite = 6.6D
        'oMesure.Pesee1 = 6.5D
        'oMesure.Pesee2 = 6.9D
        'oMesure.Pesee3 = 6.8D

        oPompe.calcule()
        Assert.AreEqual(5.233D, oPompe.PeseeMoyenne)
        Assert.AreEqual(-1.276D, oPompe.EcartReglageMoyen)
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oPompe.Resultat)

        'Les Deux pompes sont OK = > Pas de defaut
        Assert.AreEqual(DiagnosticItem.EtatDiagItemOK, oHelp12123.Resultat)






        'Modification de la Mompe2
        oMesure = oPompe.lstMesures(1)
        oMesure.qteGrains = 7
        oMesure.DebitSouhaite = 4D
        oMesure.Pesee1 = 6.5D
        oMesure.Pesee2 = 6.9D
        oMesure.Pesee3 = 6.8D
        oPompe.calcule()
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oPompe.Resultat)

        'L'une des pompes est en dafut => LE diag est en en degfaut
        Assert.AreEqual(DiagnosticItem.EtatDiagItemMAJEUR, oHelp12123.Resultat)


    End Sub


    <TestMethod>
    Public Sub initDiagAvecTrtSem()
        Dim oExploit As Exploitation
        oExploit = createExploitation()

        Dim oPulve As Pulverisateur
        oPulve = createPulve(oExploit)
        oPulve.type = "Pulvérisateurs fixes ou semi mobiles"

        oPulve.isPompesDoseuses = True
        oPulve.nbPompesDoseuses = 2

        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE

        Dim oDiag As New Diagnostic(m_oAgent, oPulve, oExploit)
        Assert.AreEqual(2, oDiag.diagnosticHelp12123.lstPompes.Count)
        Assert.AreEqual(0, oDiag.diagnosticHelp12123.lstPompesTrtSem.Count)

        oPulve.categorie = "Traitement des semences"
        oDiag.setPulverisateur(oPulve)
        Assert.AreEqual(0, oDiag.diagnosticHelp12123.lstPompes.Count)
        Assert.AreEqual(2, oDiag.diagnosticHelp12123.lstPompesTrtSem.Count)


    End Sub
End Class
