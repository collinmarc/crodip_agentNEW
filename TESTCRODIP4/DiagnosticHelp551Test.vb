Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour DiagnosticHelp551Test, 
'''</summary>
<TestClass()> _
Public Class DiagnosticHelp551test
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
        Dim oDiagHelp551 As DiagnosticHelp551
        Dim oDiag As Diagnostic
        Dim iD As String

        oDiag = createAndSaveDiagnostic()

        oDiagHelp551 = New DiagnosticHelp551(DiagnosticHelp551.Help551Mode.Mode551)

        oDiagHelp551.idDiag = oDiag.id
        oDiagHelp551.Distance1 = 10.1D
        oDiagHelp551.Distance2 = 10.2D
        oDiagHelp551.Temps1 = 20.1D
        oDiagHelp551.Temps2 = 20.2D
        oDiagHelp551.VitesseLue1 = 30.1D
        oDiagHelp551.VitesseLue2 = 30.2D

        Debug.WriteLine("Création")
        Assert.IsTrue(String.IsNullOrEmpty(oDiagHelp551.id))
        Dim oCSDb As New CSDb(True)
        Assert.IsTrue(oDiagHelp551.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDb))
        oCSDb.free()
        iD = oDiagHelp551.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp551.id))

        Debug.WriteLine("Lecture")
        oDiagHelp551 = New DiagnosticHelp551(DiagnosticHelp551.Help551Mode.Mode551)
        oDiagHelp551.id = iD
        oDiagHelp551.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp551.Load())

        Assert.AreEqual(oDiagHelp551.Distance1, 10.1D)
        Assert.AreEqual(oDiagHelp551.Distance2, 10.2D)
        Assert.AreEqual(oDiagHelp551.Temps1, 20.1D)
        Assert.AreEqual(oDiagHelp551.Temps2, 20.2D)
        Assert.AreEqual(oDiagHelp551.VitesseLue1, 30.1D)
        Assert.AreEqual(oDiagHelp551.VitesseLue2, 30.2D)


        'Maj de l'objet
        oDiagHelp551.Distance1 = 100.1D
        oDiagHelp551.Distance2 = 100.2D
        oDiagHelp551.Temps1 = 200.1D
        oDiagHelp551.Temps2 = 200.2D
        oDiagHelp551.VitesseLue1 = 300.1D
        oDiagHelp551.VitesseLue2 = 300.2D

        Debug.WriteLine("Update")
        oCSDb.getInstance()
        Assert.IsTrue(oDiagHelp551.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDb))
        oCSDb.free()


        Debug.WriteLine("Lecture")
        oDiagHelp551 = New DiagnosticHelp551(DiagnosticHelp551.Help551Mode.Mode551)
        oDiagHelp551.id = iD
        oDiagHelp551.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp551.Load())

        Assert.AreEqual(oDiagHelp551.Distance1, 100.1D)
        Assert.AreEqual(oDiagHelp551.Distance2, 100.2D)
        Assert.AreEqual(oDiagHelp551.Temps1, 200.1D)
        Assert.AreEqual(oDiagHelp551.Temps2, 200.2D)
        Assert.AreEqual(oDiagHelp551.VitesseLue1, 300.1D)
        Assert.AreEqual(oDiagHelp551.VitesseLue2, 300.2D)

        Debug.WriteLine("Suppression")
        oDiagHelp551.Delete()

    End Sub
    <TestMethod()>
    Public Sub Get_Send_WS()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim idDiag As String

        'Annullation dela synchro de tous les anciens Diags
        Dim oCSDB As New CSDb(True)
        oCSDB.Execute("UPDATE DIAGNOSTIC SET dateModificationAgent = dateModificationCrodip")
        'Creation d'un Diagnostic
        '============================
        oDiag = createAndSaveDiagnostic()
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        oDiag.setOrganisme(m_oAgent)
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationCrodip = CDate("06/02/1964").ToShortDateString()
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today.ToShortDateString()
        oDiag.organismeOrigineInspAgrement = "AgrementOrigine"
        oDiag.organismeOrigineInspNom = "NomOrigine"
        oDiag.organismeOriginePresId = m_oAgent.idStructure
        oDiag.organismeOriginePresNom = "PresNomOrigine"
        oDiag.organismeOriginePresNumero = "PresNumeroOrigine"
        oDiag.inspecteurOrigineId = m_oAgent.id
        oDiag.inspecteurOrigineNom = "inspecteurNomOrigine"
        oDiag.inspecteurOriginePrenom = "inspecteurNomOrigine"
        oDiag.pulverisateurEmplacementIdentification = "DERRIERE"
        oDiag.controleManoControleNumNational = "TEST"
        oDiag.controleNbreNiveaux = 2
        oDiag.controleNbreTroncons = 5
        oDiag.controleUseCalibrateur = True
        oDiag.controleBancMesureId = "IDBANC"


        'Ajout des DiagItems
        '======================
        Dim oDiagItem As DiagnosticItem
        oDiag.diagnosticItemsLst.Clear()
        'Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR
        oDiagItem.cause = "1"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Ajout des mesures help551
        '=========================

        oDiag.diagnosticHelp551.Distance1 = 10.1D
        oDiag.diagnosticHelp551.Distance2 = 10.2D
        oDiag.diagnosticHelp551.Temps1 = 20.1D
        oDiag.diagnosticHelp551.Temps2 = 20.2D
        oDiag.diagnosticHelp551.VitesseLue1 = 30.1D
        oDiag.diagnosticHelp551.VitesseLue2 = 30.2D

        oDiag.diagnosticHelp12323.Distance1 = 11.1D
        oDiag.diagnosticHelp12323.Distance2 = 11.2D
        oDiag.diagnosticHelp12323.Temps1 = 21.1D
        oDiag.diagnosticHelp12323.Temps2 = 21.2D
        oDiag.diagnosticHelp12323.VitesseLue1 = 31.1D
        oDiag.diagnosticHelp12323.VitesseLue2 = 31.2D

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag)

        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        'Synchronisation Ascendante du Diag
        '========================
        Dim oDiags As Diagnostic() = DiagnosticManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oDiags.Length)
        Dim oSynchro As New Synchronisation(m_oAgent)
        For Each oDiag In oDiags
            Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))
        Next



        'on Simule la date de dernière synchro de l'agent à -1 munites
        '======================================
        m_oAgent.dateDerniereSynchro = CDate(oDiag.dateModificationAgent).AddMinutes(-1).ToShortDateString()

        'Suppression du diag par sécurité 
        DiagnosticManager.delete(oDiag.id)
        Dim oLstSynchro As List(Of SynchronisationElmt)
        'oLstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        Assert.AreNotEqual(0, oLstSynchro.Count)

        For Each oSynchroElmt As SynchronisationElmt In oLstSynchro
            If oSynchroElmt.type.StartsWith("GetDiagnostic") Then
                Console.WriteLine(oSynchroElmt.type & "(" & oSynchroElmt.identifiantChaine & "," & oSynchroElmt.identifiantEntier & ")")
                oSynchroElmt.SynchroDesc(m_oAgent)
            End If
        Next oSynchroElmt

        'Vérification des Objets
        oDiag2 = DiagnosticManager.getDiagnosticById(idDiag)

        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual(oDiag.controleNomSite, oDiag2.controleNomSite)
        Assert.AreEqual(oDiag.controleIsPulveRepare, oDiag2.controleIsPulveRepare)
        Assert.AreEqual(oDiag.controleIsPreControleProfessionel, oDiag2.controleIsPreControleProfessionel)
        Assert.AreEqual(oDiag.controleIsAutoControle, oDiag2.controleIsAutoControle)
        Assert.AreEqual(oDiag.proprietaireRepresentant, oDiag2.proprietaireRepresentant)
        Assert.AreEqual(oDiag.inspecteurId, oDiag2.inspecteurId)
        Assert.AreEqual(oDiag.controleEtat, oDiag2.controleEtat)
        Assert.AreEqual(oDiag.controleDateFin, oDiag2.controleDateFin)
        Assert.AreEqual(oDiag.organismeOrigineInspAgrement, oDiag2.organismeOrigineInspAgrement)
        Assert.AreEqual(oDiag.organismeOrigineInspNom, oDiag2.organismeOrigineInspNom)
        Assert.AreEqual(oDiag.organismeOriginePresId, oDiag2.organismeOriginePresId)
        Assert.AreEqual(oDiag.organismeOriginePresNom, oDiag2.organismeOriginePresNom)
        Assert.AreEqual(oDiag.organismeOriginePresNumero, oDiag2.organismeOriginePresNumero)
        Assert.AreEqual(oDiag.inspecteurOrigineId, oDiag2.inspecteurOrigineId)
        Assert.AreEqual(oDiag.inspecteurOrigineNom, oDiag2.inspecteurOrigineNom)
        Assert.AreEqual(oDiag.inspecteurOriginePrenom, oDiag2.inspecteurOriginePrenom)
        Assert.AreEqual(oDiag.pulverisateurEmplacementIdentification, oDiag2.pulverisateurEmplacementIdentification)
        Assert.AreEqual(oDiag.controleManoControleNumNational, oDiag2.controleManoControleNumNational)
        Assert.AreEqual(oDiag.controleNbreNiveaux, oDiag2.controleNbreNiveaux)
        Assert.AreEqual(oDiag.controleNbreTroncons, oDiag2.controleNbreTroncons)
        Assert.AreEqual(oDiag.controleUseCalibrateur, oDiag2.controleUseCalibrateur)
        Assert.AreEqual(oDiag.controleBancMesureId, oDiag2.controleBancMesureId)


        'Vérification des DiagItems
        Assert.AreEqual(1, oDiag2.diagnosticItemsLst.Count)
        oDiagItem = oDiag2.diagnosticItemsLst.Values(0)
        'Item1
        Assert.IsTrue(oDiagItem.idItem = "111")
        Assert.IsTrue(oDiagItem.itemValue = "1")
        Assert.IsTrue(oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR)
        Assert.IsTrue(oDiagItem.cause = "1")

        'Vérification des mesures help551

        Assert.AreEqual(oDiag2.diagnosticHelp551.Distance1, 10.1D)
        Assert.IsTrue(oDiag2.diagnosticHelp551.Distance2 = 10.2D)
        Assert.IsTrue(oDiag2.diagnosticHelp551.Temps1 = 20.1D)
        Assert.IsTrue(oDiag2.diagnosticHelp551.Temps2 = 20.2D)
        Assert.IsTrue(oDiag2.diagnosticHelp551.VitesseLue1 = 30.1D)
        Assert.IsTrue(oDiag2.diagnosticHelp551.VitesseLue2 = 30.2D)

        Assert.IsTrue(oDiag2.diagnosticHelp12323.Distance1 = 11.1D)
        Assert.IsTrue(oDiag2.diagnosticHelp12323.Distance2 = 11.2D)
        Assert.IsTrue(oDiag2.diagnosticHelp12323.Temps1 = 21.1D)
        Assert.IsTrue(oDiag2.diagnosticHelp12323.Temps2 = 21.2D)
        Assert.IsTrue(oDiag2.diagnosticHelp12323.VitesseLue1 = 31.1D)
        Assert.IsTrue(oDiag2.diagnosticHelp12323.VitesseLue2 = 31.2D)


        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub

    <TestMethod()>
    Public Sub testCalc()
        Dim oHelp551 As New DiagnosticHelp551(DiagnosticHelp551.Help551Mode.Mode551)

        oHelp551.Distance1 = 100
        oHelp551.Temps1 = 45
        oHelp551.calc(5)
        Assert.AreEqual(8D, oHelp551.VitesseReelle1)
        oHelp551.VitesseLue1 = 8
        oHelp551.calc(5)
        Assert.AreEqual(0D, oHelp551.Ecart1)

        oHelp551.Distance2 = 100
        oHelp551.Temps2 = 50
        oHelp551.calc(5)
        Assert.AreEqual(7.2D, oHelp551.VitesseReelle2)
        oHelp551.VitesseLue2 = 7
        oHelp551.calc(5)
        Assert.AreEqual(2.78D, oHelp551.Ecart2)

        Assert.AreEqual(1.32D, oHelp551.ErreurMoyenne)
    End Sub

    <TestMethod()>
    Public Sub testCalcResultat()
        Dim oHelp551 As New DiagnosticHelp551(DiagnosticHelp551.Help551Mode.Mode551)

        oHelp551.Distance1 = 100
        oHelp551.Temps1 = 45
        oHelp551.VitesseLue1 = 8

        oHelp551.Distance2 = 100
        oHelp551.Temps2 = 50
        oHelp551.VitesseLue2 = 7
        oHelp551.calc(5)

        Assert.AreEqual(0D, oHelp551.Ecart1)
        Assert.AreEqual(2.78D, oHelp551.Ecart2)

        Assert.AreEqual(1.32D, oHelp551.ErreurMoyenne)
        Assert.AreEqual("OK", oHelp551.Resultat)

        oHelp551.Distance1 = 100
        oHelp551.Temps1 = 35
        oHelp551.VitesseLue1 = 10.5D

        oHelp551.Distance2 = 100
        oHelp551.Temps2 = 35
        oHelp551.VitesseLue2 = 11.1D
        oHelp551.calc(5)

        Assert.AreEqual(2.04D, oHelp551.Ecart1)
        Assert.AreEqual(7.87D, oHelp551.Ecart2)
        Assert.AreEqual(4.96D, oHelp551.ErreurMoyenne)
        Assert.AreEqual("OK", oHelp551.Resultat1)
        Assert.AreEqual("IMPRECISION", oHelp551.Resultat2)
        Assert.AreEqual("OK", oHelp551.Resultat)

        oHelp551.Distance1 = 100
        oHelp551.Temps1 = 35
        oHelp551.VitesseLue1 = 10.5D

        oHelp551.Distance2 = 100
        oHelp551.Temps2 = 35
        oHelp551.VitesseLue2 = 11.2D
        oHelp551.calc(5)

        Assert.AreEqual(2.04D, oHelp551.Ecart1)
        Assert.AreEqual(8.84D, oHelp551.Ecart2)
        Assert.AreEqual(5.44D, oHelp551.ErreurMoyenne)
        Assert.AreEqual("OK", oHelp551.Resultat1)
        Assert.AreEqual("IMPRECISION", oHelp551.Resultat2)
        Assert.AreEqual("IMPRECISION", oHelp551.Resultat)

    End Sub

    <TestMethod()>
    Public Sub testClone()
        Dim oHelp551 As New DiagnosticHelp551(DiagnosticHelp551.Help551Mode.Mode551)
        Dim oHelp551Clone As DiagnosticHelp551

        oHelp551.id = "562"
        oHelp551.idDiag = "00-000-000"


        oHelp551.Distance1 = 100
        oHelp551.Temps1 = 45
        oHelp551.VitesseLue1 = 8

        oHelp551.Distance2 = 100
        oHelp551.Temps2 = 50
        oHelp551.VitesseLue2 = 7
        oHelp551.calc(5)

        Assert.AreEqual(0D, oHelp551.Ecart1)
        Assert.AreEqual(2.78D, oHelp551.Ecart2)

        Assert.AreEqual(1.32D, oHelp551.ErreurMoyenne)
        Assert.AreEqual("OK", oHelp551.Resultat)

        oHelp551Clone = CType(oHelp551.Clone(), DiagnosticHelp551)
        Assert.AreEqual(oHelp551.Distance1, oHelp551Clone.Distance1)
        Assert.AreEqual(oHelp551.Temps1, oHelp551Clone.Temps1)
        Assert.AreEqual(oHelp551.VitesseLue1, oHelp551Clone.VitesseLue1)
        Assert.AreEqual(oHelp551.VitesseReelle1, oHelp551Clone.VitesseReelle1)
        Assert.AreEqual(oHelp551.Ecart1, oHelp551Clone.Ecart1)
        Assert.AreEqual(oHelp551.Resultat1, oHelp551Clone.Resultat1)

        Assert.AreEqual(oHelp551.Distance2, oHelp551Clone.Distance2)
        Assert.AreEqual(oHelp551.Temps2, oHelp551Clone.Temps2)
        Assert.AreEqual(oHelp551.VitesseLue2, oHelp551Clone.VitesseLue2)
        Assert.AreEqual(oHelp551.VitesseReelle2, oHelp551Clone.VitesseReelle2)
        Assert.AreEqual(oHelp551.Ecart2, oHelp551Clone.Ecart2)
        Assert.AreEqual(oHelp551.Resultat2, oHelp551Clone.Resultat2)

        Assert.AreEqual(oHelp551.ErreurMoyenne, oHelp551Clone.ErreurMoyenne)
        Assert.AreEqual(oHelp551.Resultat, oHelp551Clone.Resultat)

        Assert.AreEqual(oHelp551.id, oHelp551Clone.id)
        Assert.AreEqual(oHelp551.idDiag, oHelp551Clone.idDiag)
        Assert.AreEqual(oHelp551.iditem, oHelp551Clone.iditem)

        oHelp551.id = "123"
        Assert.AreNotEqual(oHelp551.id, oHelp551Clone.id)

    End Sub
End Class
