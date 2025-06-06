﻿Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CrodipWS



'''<summary>
'''Classe de test pour DiagnosticHelp5621Test, 
'''</summary>
<TestClass()> _
Public Class DiagnosticHelp5621test
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
        Dim oDiagHelp5621 As DiagnosticHelp5621
        Dim oDiag As Diagnostic
        Dim iD As String
        Dim oCSDB As New CSDb(True)

        oDiag = createAndSaveDiagnostic()
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.inspecteurId = m_oAgent.id

        oDiagHelp5621 = New DiagnosticHelp5621

        oDiagHelp5621.idDiag = oDiag.id
        oDiagHelp5621.Distance1 = 10.1D
        oDiagHelp5621.Distance2 = 10.2D
        oDiagHelp5621.Temps1 = 20.1D
        oDiagHelp5621.Temps2 = 20.2D
        oDiagHelp5621.VitesseLue1 = 30.1D
        oDiagHelp5621.VitesseLue2 = 30.2D

        Debug.WriteLine("Création")
        Assert.IsTrue(String.IsNullOrEmpty(oDiagHelp5621.id))
        Assert.IsTrue(oDiagHelp5621.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDB))
        iD = oDiagHelp5621.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp5621.id))

        Debug.WriteLine("Lecture")
        oDiagHelp5621 = New DiagnosticHelp5621()
        oDiagHelp5621.id = iD
        oDiagHelp5621.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp5621.Load())

        Assert.AreEqual(oDiagHelp5621.Distance1, 10.1D)
        Assert.AreEqual(oDiagHelp5621.Distance2, 10.2D)
        Assert.AreEqual(oDiagHelp5621.Temps1, 20.1D)
        Assert.AreEqual(oDiagHelp5621.Temps2, 20.2D)
        Assert.AreEqual(oDiagHelp5621.VitesseLue1, 30.1D)
        Assert.AreEqual(oDiagHelp5621.VitesseLue2, 30.2D)


        'Maj de l'objet
        oDiagHelp5621.Distance1 = 100.1D
        oDiagHelp5621.Distance2 = 100.2D
        oDiagHelp5621.Temps1 = 200.1D
        oDiagHelp5621.Temps2 = 200.2D
        oDiagHelp5621.VitesseLue1 = 300.1D
        oDiagHelp5621.VitesseLue2 = 300.2D

        Debug.WriteLine("Update")
        Assert.IsTrue(oDiagHelp5621.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDB))

        Debug.WriteLine("Lecture")
        oDiagHelp5621 = New DiagnosticHelp5621()
        oDiagHelp5621.id = iD
        oDiagHelp5621.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp5621.Load())

        Assert.AreEqual(oDiagHelp5621.Distance1, 100.1D)
        Assert.AreEqual(oDiagHelp5621.Distance2, 100.2D)
        Assert.AreEqual(oDiagHelp5621.Temps1, 200.1D)
        Assert.AreEqual(oDiagHelp5621.Temps2, 200.2D)
        Assert.AreEqual(oDiagHelp5621.VitesseLue1, 300.1D)
        Assert.AreEqual(oDiagHelp5621.VitesseLue2, 300.2D)

        oCSDB.free()

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

        'Ajout des mesures help5621
        '=========================

        oDiag.diagnosticHelp5621.Distance1 = 10.1D
        oDiag.diagnosticHelp5621.Distance2 = 10.2D
        oDiag.diagnosticHelp5621.Temps1 = 20.1D
        oDiag.diagnosticHelp5621.Temps2 = 20.2D
        oDiag.diagnosticHelp5621.VitesseLue1 = 30.1D
        oDiag.diagnosticHelp5621.VitesseLue2 = 30.2D

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
        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC(m_oPc, m_oAgent)
        Assert.AreNotEqual(0, oLstSynchro.Count)

        For Each oSynchroElmt As SynchronisationElmt In oLstSynchro
            Console.WriteLine(oSynchroElmt.type & "(" & oSynchroElmt.identifiantChaine & "," & oSynchroElmt.identifiantEntier & ")")
            oSynchroElmt.SynchroDesc(m_oAgent)
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
        oDiagItem = oDiag2.diagnosticItemsLst.Liste(0)
        'Item1
        Assert.IsTrue(oDiagItem.idItem = "111")
        Assert.IsTrue(oDiagItem.itemValue = "1")
        Assert.IsTrue(oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR)
        Assert.IsTrue(oDiagItem.cause = "1")

        'Vérification des mesures help5621

        Assert.IsTrue(oDiag2.diagnosticHelp5621.Distance1 = 10.1)
        Assert.IsTrue(oDiag2.diagnosticHelp5621.Distance2 = 10.2)
        Assert.IsTrue(oDiag2.diagnosticHelp5621.Temps1 = 20.1)
        Assert.IsTrue(oDiag2.diagnosticHelp5621.Temps2 = 20.2)
        Assert.IsTrue(oDiag2.diagnosticHelp5621.VitesseLue1 = 30.1)
        Assert.IsTrue(oDiag2.diagnosticHelp5621.VitesseLue2 = 30.2)


        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub


End Class
