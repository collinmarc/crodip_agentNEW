Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour DiagnosticHelp831Test, 
'''</summary>
<TestClass()> _
Public Class DiagnosticHelp831test
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
        Dim oDiagHelp831 As DiagnosticHelp831
        Dim oDiag As Diagnostic
        Dim iD As String
        Dim oCSDB As New CSDb(True)

        oDiag = createAndSaveDiagnostic()

        oDiagHelp831 = New DiagnosticHelp831(DiagnosticHelp831.ModeHelp831.Mode8312)

        oDiagHelp831.idDiag = oDiag.id
        oDiagHelp831.Ecart_reference = "1.5"
        oDiagHelp831.Ecart_Mini = "1.6"
        oDiagHelp831.Ecart_Maxi = "1.7"
        oDiagHelp831.Ecart_pct = "1.8"


        Debug.WriteLine("Création")
        Assert.IsTrue(String.IsNullOrEmpty(oDiagHelp831.id))
        Assert.IsTrue(oDiagHelp831.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDB))
        iD = oDiagHelp831.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp831.id))

        Debug.WriteLine("Lecture")
        oDiagHelp831 = New DiagnosticHelp831(DiagnosticHelp831.ModeHelp831.Mode8312)
        oDiagHelp831.id = iD
        oDiagHelp831.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp831.Load())

        Assert.AreEqual(oDiagHelp831.Ecart_reference, "1.5")
        Assert.AreEqual(oDiagHelp831.Ecart_Mini, "1.6")
        Assert.AreEqual(oDiagHelp831.Ecart_Maxi, "1.7")
        Assert.AreEqual(oDiagHelp831.Ecart_pct, "1.8")


        'Maj de l'objet
        oDiagHelp831.Ecart_reference = "2.5"
        oDiagHelp831.Ecart_Mini = "2.6"
        oDiagHelp831.Ecart_Maxi = "2.7"
        oDiagHelp831.Ecart_pct = "2.8"

        Debug.WriteLine("Update")
        Assert.IsTrue(oDiagHelp831.Save(oDiag.organismePresId.ToString, oDiag.inspecteurId.ToString, oCSDB))

        Debug.WriteLine("Lecture")
        oDiagHelp831 = New DiagnosticHelp831(DiagnosticHelp831.ModeHelp831.Mode8312)
        oDiagHelp831.id = iD
        oDiagHelp831.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp831.Load())

        Assert.AreEqual(oDiagHelp831.Ecart_reference, "2.5")
        Assert.AreEqual(oDiagHelp831.Ecart_Mini, "2.6")
        Assert.AreEqual(oDiagHelp831.Ecart_Maxi, "2.7")
        Assert.AreEqual(oDiagHelp831.Ecart_pct, "2.8")

        oCSDB.free()
    End Sub
    <TestMethod()>
    Public Sub SaveDiagTest()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim idDiag As String

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
        oDiag.organismeOrigineInspAgrement = "AgrementOrigine"
        oDiag.organismeOrigineInspNom = "NomOrigine"
        oDiag.organismeOriginePresId = 98
        oDiag.organismeOriginePresNom = "PresNomOrigine"
        oDiag.organismeOriginePresNumero = "PresNumeroOrigine"
        oDiag.inspecteurOrigineId = 99
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
        'Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiag.diagnosticItemsLst.Clear()
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR
        oDiagItem.cause = "1"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Ajout des mesures help831
        '=========================

        oDiag.diagnosticHelp8312.Ecart_reference = "1.5"
        oDiag.diagnosticHelp8312.Ecart_Mini = "1.6"
        oDiag.diagnosticHelp8312.Ecart_Maxi = "1.7"
        oDiag.diagnosticHelp8312.Ecart_pct = "1.8"

        oDiag.diagnosticHelp8314.Ecart_reference = "2.5"
        oDiag.diagnosticHelp8314.Ecart_Mini = "2.6"
        oDiag.diagnosticHelp8314.Ecart_Maxi = "2.7"
        oDiag.diagnosticHelp8314.Ecart_pct = "2.8"

        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag)




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
        Assert.AreEqual(oDiag.controleDateFinS, oDiag2.controleDateFin)
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

        'Vérification des mesures help831

        Assert.AreEqual(oDiag2.diagnosticHelp8312.Ecart_reference, "1.5")
        Assert.AreEqual(oDiag2.diagnosticHelp8312.Ecart_Mini, "1.6")
        Assert.AreEqual(oDiag2.diagnosticHelp8312.Ecart_Maxi, "1.7")
        Assert.AreEqual(oDiag2.diagnosticHelp8312.Ecart_pct, "1.8")

        Assert.AreEqual(oDiag2.diagnosticHelp8314.Ecart_reference, "2.5")
        Assert.AreEqual(oDiag2.diagnosticHelp8314.Ecart_Mini, "2.6")
        Assert.AreEqual(oDiag2.diagnosticHelp8314.Ecart_Maxi, "2.7")
        Assert.AreEqual(oDiag2.diagnosticHelp8314.Ecart_pct, "2.8")



        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

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
        oDiag.organismeOrigineInspAgrement = "AgrementOrigine"
        oDiag.organismeOrigineInspNom = "NomOrigine"
        oDiag.organismeOriginePresId = 98
        oDiag.organismeOriginePresNom = "PresNomOrigine"
        oDiag.organismeOriginePresNumero = "PresNumeroOrigine"
        oDiag.inspecteurOrigineId = 99
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
        'Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiag.diagnosticItemsLst.Clear()
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR
        oDiagItem.cause = "1"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Ajout des mesures help831
        '=========================

        oDiag.diagnosticHelp8312.Ecart_reference = "1.5"
        oDiag.diagnosticHelp8312.Ecart_Mini = "1.6"
        oDiag.diagnosticHelp8312.Ecart_Maxi = "1.7"
        oDiag.diagnosticHelp8312.Ecart_pct = "1.8"

        oDiag.diagnosticHelp8314.Ecart_reference = "2.5"
        oDiag.diagnosticHelp8314.Ecart_Mini = "2.6"
        oDiag.diagnosticHelp8314.Ecart_Maxi = "2.7"
        oDiag.diagnosticHelp8314.Ecart_pct = "2.8"

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
        AgentManager.save(m_oAgent)
        'Suppression du diag par sécurité 
        DiagnosticManager.delete(oDiag.id)
        Dim oLstSynchro As List(Of SynchronisationElmt)
        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        Assert.AreNotEqual(0, oLstSynchro.Count)

        For Each oSynchroElmt In oLstSynchro
            Console.WriteLine(oSynchroElmt.type & "(" & oSynchroElmt.identifiantChaine & "," & oSynchroElmt.identifiantEntier & ")")
            oSynchroElmt.synchroDesc(m_oAgent)
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

        'Vérification des mesures help831

        Assert.AreEqual(oDiag2.diagnosticHelp8312.Ecart_reference, "1.5")
        Assert.AreEqual(oDiag2.diagnosticHelp8312.Ecart_Mini, "1.6")
        Assert.AreEqual(oDiag2.diagnosticHelp8312.Ecart_Maxi, "1.7")
        Assert.AreEqual(oDiag2.diagnosticHelp8312.Ecart_pct, "1.8")

        Assert.AreEqual(oDiag2.diagnosticHelp8314.Ecart_reference, "2.5")
        Assert.AreEqual(oDiag2.diagnosticHelp8314.Ecart_Mini, "2.6")
        Assert.AreEqual(oDiag2.diagnosticHelp8314.Ecart_Maxi, "2.7")
        Assert.AreEqual(oDiag2.diagnosticHelp8314.Ecart_pct, "2.8")

        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub


End Class
