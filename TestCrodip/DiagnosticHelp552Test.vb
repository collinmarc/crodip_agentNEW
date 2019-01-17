Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour DiagnosticHelp552Test, 
'''</summary>
<TestClass()> _
Public Class DiagnosticHelp552test
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
        Dim oDiagHelp552 As DiagnosticHelp552
        Dim oDiag As Diagnostic
        Dim iD As String

        oDiag = New Diagnostic()
        oDiag.id = "497-1114"
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.inspecteurId = m_oAgent.id

        oDiagHelp552 = New DiagnosticHelp552

        oDiagHelp552.idDiag = oDiag.id

        oDiagHelp552.NbBuses_m1 = 10.1
        oDiagHelp552.Pression_m1 = 11.1
        oDiagHelp552.DebitEtalon_m1 = 12.1
        oDiagHelp552.DebitAfficheur_m1 = 13.1

        oDiagHelp552.NbBuses_m2 = 10.2
        oDiagHelp552.Pression_m2 = 11.2
        oDiagHelp552.DebitEtalon_m2 = 12.2
        oDiagHelp552.DebitAfficheur_m2 = 13.2

        oDiagHelp552.NbBuses_m3 = 10.3
        oDiagHelp552.Pression_m3 = 11.3
        oDiagHelp552.DebitEtalon_m3 = 12.3
        oDiagHelp552.DebitAfficheur_m3 = 13.3

        Debug.WriteLine("Création")
        Assert.IsTrue(String.IsNullOrEmpty(oDiagHelp552.id))
        Assert.IsTrue(oDiagHelp552.Save(oDiag.organismePresId, oDiag.inspecteurId))
        iD = oDiagHelp552.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagHelp552.id))

        Debug.WriteLine("Lecture")
        oDiagHelp552 = New DiagnosticHelp552()
        oDiagHelp552.id = iD
        oDiagHelp552.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp552.Load())

        Assert.AreEqual(oDiagHelp552.NbBuses_m1, 10.1D)
        Assert.AreEqual(oDiagHelp552.Pression_m1, 11.1D)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m1, 12.1D)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m1, 13.1D)

        Assert.AreEqual(oDiagHelp552.NbBuses_m2, 10.2D)
        Assert.AreEqual(oDiagHelp552.Pression_m2, 11.2D)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m2, 12.2D)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m2, 13.2D)

        Assert.AreEqual(oDiagHelp552.NbBuses_m3, 10.3D)
        Assert.AreEqual(oDiagHelp552.Pression_m3, 11.3D)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m3, 12.3D)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m3, 13.3D)

        'Maj de l'objet
        oDiagHelp552.NbBuses_m1 = 110.1
        oDiagHelp552.Pression_m1 = 111.1
        oDiagHelp552.DebitEtalon_m1 = 112.1
        oDiagHelp552.DebitAfficheur_m1 = 113.1

        oDiagHelp552.NbBuses_m2 = 110.2
        oDiagHelp552.Pression_m2 = 111.2
        oDiagHelp552.DebitEtalon_m2 = 112.2
        oDiagHelp552.DebitAfficheur_m2 = 113.2

        oDiagHelp552.NbBuses_m3 = 110.3
        oDiagHelp552.Pression_m3 = 111.3
        oDiagHelp552.DebitEtalon_m3 = 112.3
        oDiagHelp552.DebitAfficheur_m3 = 113.3


        Debug.WriteLine("Update")
        Assert.IsTrue(oDiagHelp552.Save(oDiag.organismePresId, oDiag.inspecteurId))

        Debug.WriteLine("Lecture")
        oDiagHelp552 = New DiagnosticHelp552()
        oDiagHelp552.id = iD
        oDiagHelp552.idDiag = oDiag.id
        Assert.IsTrue(oDiagHelp552.Load())

        Assert.AreEqual(oDiagHelp552.NbBuses_m1, 110.1D)
        Assert.AreEqual(oDiagHelp552.Pression_m1, 111.1D)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m1, 112.1D)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m1, 113.1D)

        Assert.AreEqual(oDiagHelp552.NbBuses_m2, 110.2D)
        Assert.AreEqual(oDiagHelp552.Pression_m2, 111.2D)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m2, 112.2D)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m2, 113.2D)

        Assert.AreEqual(oDiagHelp552.NbBuses_m3, 110.3D)
        Assert.AreEqual(oDiagHelp552.Pression_m3, 111.3D)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m3, 112.3D)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m3, 113.3D)

        Debug.WriteLine("Suppression")
        oDiagHelp552.Delete()

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
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag

        oDiag.setOrganisme(m_oAgent)
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.dateModificationCrodip = CDate("06/02/1964")
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today
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
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Ajout des mesures help552
        '=========================

        oDiag.diagnosticHelp552.NbBuses_m1 = 110.1
        oDiag.diagnosticHelp552.Pression_m1 = 111.1
        oDiag.diagnosticHelp552.DebitEtalon_m1 = 112.1
        oDiag.diagnosticHelp552.DebitAfficheur_m1 = 113.1

        oDiag.diagnosticHelp552.NbBuses_m2 = 110.2
        oDiag.diagnosticHelp552.Pression_m2 = 111.2
        oDiag.diagnosticHelp552.DebitEtalon_m2 = 112.2
        oDiag.diagnosticHelp552.DebitAfficheur_m2 = 113.2

        oDiag.diagnosticHelp552.NbBuses_m3 = 110.3
        oDiag.diagnosticHelp552.Pression_m3 = 111.3
        oDiag.diagnosticHelp552.DebitEtalon_m3 = 112.3
        oDiag.diagnosticHelp552.DebitAfficheur_m3 = 113.3


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
        m_oAgent.dateDerniereSynchro = CDate(oDiag.dateModificationAgent).AddMinutes(-1)

        'Suppression du diag par sécurité 
        DiagnosticManager.delete(oDiag.id)
        Dim oLstSynchro As List(Of SynchronisationElmt)
        '        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC()
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
        oDiagItem = oDiag2.diagnosticItemsLst.Values(0)
        'Item1
        Assert.IsTrue(oDiagItem.idItem = "111")
        Assert.IsTrue(oDiagItem.itemValue = "1")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "B")
        Assert.IsTrue(oDiagItem.cause = "1")

        'Vérification des mesures help552

        Assert.AreEqual(oDiag2.diagnosticHelp552.NbBuses_m1, 110.1D)
        Assert.IsTrue(oDiag2.diagnosticHelp552.Pression_m1 = 111.1)
        Assert.IsTrue(oDiag2.diagnosticHelp552.DebitEtalon_m1 = 112.1)
        Assert.IsTrue(oDiag2.diagnosticHelp552.DebitAfficheur_m1 = 113.1)

        Assert.IsTrue(oDiag2.diagnosticHelp552.NbBuses_m2, 110.2D)
        Assert.IsTrue(oDiag2.diagnosticHelp552.Pression_m2 = 111.2)
        Assert.IsTrue(oDiag2.diagnosticHelp552.DebitEtalon_m2 = 112.2)
        Assert.IsTrue(oDiag2.diagnosticHelp552.DebitAfficheur_m2 = 113.2)

        Assert.IsTrue(oDiag2.diagnosticHelp552.NbBuses_m3, 110.3D)
        Assert.IsTrue(oDiag2.diagnosticHelp552.Pression_m3 = 111.3)
        Assert.IsTrue(oDiag2.diagnosticHelp552.DebitEtalon_m3 = 112.3)
        Assert.IsTrue(oDiag2.diagnosticHelp552.DebitAfficheur_m3 = 113.3)

        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub
    <TestMethod()>
    Public Sub testClone()
        Dim oDiagHelp552 As New DiagnosticHelp552()
        Dim oDiagHelp552Clone As DiagnosticHelp552

        oDiagHelp552.id = 562
        oDiagHelp552.idDiag = "00-000-000"


        oDiagHelp552.NbBuses_m1 = 10.1
        oDiagHelp552.Pression_m1 = 11.1
        oDiagHelp552.DebitEtalon_m1 = 12.1
        oDiagHelp552.DebitAfficheur_m1 = 13.1

        oDiagHelp552.NbBuses_m2 = 10.2
        oDiagHelp552.Pression_m2 = 11.2
        oDiagHelp552.DebitEtalon_m2 = 12.2
        oDiagHelp552.DebitAfficheur_m2 = 13.2

        oDiagHelp552.NbBuses_m3 = 10.3
        oDiagHelp552.Pression_m3 = 11.3
        oDiagHelp552.DebitEtalon_m3 = 12.3
        oDiagHelp552.DebitAfficheur_m3 = 13.3

        oDiagHelp552.calc()


        oDiagHelp552Clone = oDiagHelp552.Clone()
        Assert.AreEqual(oDiagHelp552.NbBuses_m1, oDiagHelp552Clone.NbBuses_m1)
        Assert.AreEqual(oDiagHelp552.Pression_m1, oDiagHelp552Clone.Pression_m1)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m1, oDiagHelp552Clone.DebitEtalon_m1)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m1, oDiagHelp552Clone.DebitAfficheur_m1)
        Assert.AreEqual(oDiagHelp552.NbBuses_m2, oDiagHelp552Clone.NbBuses_m2)
        Assert.AreEqual(oDiagHelp552.Pression_m2, oDiagHelp552Clone.Pression_m2)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m2, oDiagHelp552Clone.DebitEtalon_m2)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m2, oDiagHelp552Clone.DebitAfficheur_m2)
        Assert.AreEqual(oDiagHelp552.NbBuses_m3, oDiagHelp552Clone.NbBuses_m3)
        Assert.AreEqual(oDiagHelp552.Pression_m3, oDiagHelp552Clone.Pression_m3)
        Assert.AreEqual(oDiagHelp552.DebitEtalon_m3, oDiagHelp552Clone.DebitEtalon_m3)
        Assert.AreEqual(oDiagHelp552.DebitAfficheur_m3, oDiagHelp552Clone.DebitAfficheur_m3)

        Assert.AreEqual(oDiagHelp552.EcartPct_m1, oDiagHelp552Clone.EcartPct_m1)
        Assert.AreEqual(oDiagHelp552.EcartPct_m2, oDiagHelp552Clone.EcartPct_m2)
        Assert.AreEqual(oDiagHelp552.EcartPct_m3, oDiagHelp552Clone.EcartPct_m3)
        Assert.AreEqual(oDiagHelp552.ErreurDebitMetre, oDiagHelp552Clone.ErreurDebitMetre)
        Assert.AreEqual(oDiagHelp552.PressionMesure, oDiagHelp552Clone.PressionMesure)
        Assert.AreEqual(oDiagHelp552.Resultat, oDiagHelp552Clone.Resultat)


        Assert.AreEqual(oDiagHelp552.id, oDiagHelp552Clone.id)
        Assert.AreEqual(oDiagHelp552.idDiag, oDiagHelp552Clone.idDiag)
        Assert.AreEqual(oDiagHelp552.iditem, oDiagHelp552Clone.iditem)

        oDiagHelp552.id = 123
        Assert.AreNotEqual(oDiagHelp552.id, oDiagHelp552Clone.id)

    End Sub

    <TestMethod()> _
    Public Sub TST_Calc()
        Dim oDiagHelp552 As New DiagnosticHelp552()
        oDiagHelp552.NbBuses_m1 = 3
        oDiagHelp552.NbBuses_m2 = 3
        oDiagHelp552.NbBuses_m3 = 3

        oDiagHelp552.Pression_m1 = 1
        oDiagHelp552.Pression_m2 = 2
        oDiagHelp552.Pression_m3 = 3

        oDiagHelp552.DebitAfficheur_m1 = 1.5
        oDiagHelp552.DebitAfficheur_m2 = 2.5
        oDiagHelp552.DebitAfficheur_m3 = 3.5

        oDiagHelp552.PressionMesure = 3
        oDiagHelp552.DebitMoyen0Bar = 1
        Assert.IsTrue(oDiagHelp552.calc())
        Assert.AreEqual(CDec(-13.397), oDiagHelp552.EcartPct_m1)
        Assert.AreEqual(CDec(2.062), oDiagHelp552.EcartPct_m2)
        Assert.AreEqual(CDec(16.667), oDiagHelp552.EcartPct_m3)

        oDiagHelp552.NbBuses_m1 = 10
        oDiagHelp552.NbBuses_m2 = 10
        oDiagHelp552.NbBuses_m3 = 10

        oDiagHelp552.Pression_m1 = 1.45
        oDiagHelp552.Pression_m2 = 2.975
        oDiagHelp552.Pression_m3 = 3.875

        oDiagHelp552.DebitAfficheur_m1 = 7
        oDiagHelp552.DebitAfficheur_m2 = 9.5
        oDiagHelp552.DebitAfficheur_m3 = 11.5

        oDiagHelp552.PressionMesure = 3
        oDiagHelp552.DebitMoyen0Bar = 0.99

        Assert.IsTrue(oDiagHelp552.calc())
        Assert.AreEqual(CDec(1.704), oDiagHelp552.EcartPct_m1)
        Assert.AreEqual(CDec(-3.638), oDiagHelp552.EcartPct_m2)
        Assert.AreEqual(CDec(2.209), oDiagHelp552.EcartPct_m3)
        Assert.AreEqual("OK", oDiagHelp552.Resultat)
        Assert.AreEqual(CDec(2.517), oDiagHelp552.ErreurDebitMetre)

        oDiagHelp552.NbBuses_m1 = 10
        oDiagHelp552.NbBuses_m2 = 10
        oDiagHelp552.NbBuses_m3 = 10

        oDiagHelp552.Pression_m1 = 1.45
        oDiagHelp552.Pression_m2 = 2.975
        oDiagHelp552.Pression_m3 = 3.5 ' Valeur Modifiée

        oDiagHelp552.DebitAfficheur_m1 = 7
        oDiagHelp552.DebitAfficheur_m2 = 9.5
        oDiagHelp552.DebitAfficheur_m3 = 11.5

        oDiagHelp552.PressionMesure = 3
        oDiagHelp552.DebitMoyen0Bar = 0.99

        Assert.IsTrue(oDiagHelp552.calc())
        Assert.AreEqual(CDec(1.704), oDiagHelp552.EcartPct_m1)
        Assert.AreEqual(CDec(-3.638), oDiagHelp552.EcartPct_m2)
        Assert.AreEqual(CDec(7.545), oDiagHelp552.EcartPct_m3)
        Assert.AreEqual(CDec(4.296), oDiagHelp552.ErreurDebitMetre)
        'Le Résultat reste OK car l'erreur débitmètre est <5
        Assert.AreEqual("OK", oDiagHelp552.Resultat)

        oDiagHelp552.NbBuses_m1 = 10
        oDiagHelp552.NbBuses_m2 = 10
        oDiagHelp552.NbBuses_m3 = 10

        oDiagHelp552.Pression_m1 = 1.45
        oDiagHelp552.Pression_m2 = 2.4 ' Valeur Modifée
        oDiagHelp552.Pression_m3 = 3.5

        oDiagHelp552.DebitAfficheur_m1 = 7
        oDiagHelp552.DebitAfficheur_m2 = 9.5
        oDiagHelp552.DebitAfficheur_m3 = 11.5

        oDiagHelp552.PressionMesure = 3
        oDiagHelp552.DebitMoyen0Bar = 0.99

        Assert.IsTrue(oDiagHelp552.calc())
        Assert.AreEqual(CDec(1.704), oDiagHelp552.EcartPct_m1)
        Assert.AreEqual(CDec(7.286), oDiagHelp552.EcartPct_m2)
        Assert.AreEqual(CDec(7.545), oDiagHelp552.EcartPct_m3)
        Assert.AreEqual(CDec(5.512), oDiagHelp552.ErreurDebitMetre)
        'Le Résultat Passe à NOK  car l'erreur débitmètre est <5 ET l'ecart M3 est > 5
        Assert.AreEqual("IMPRECISION", oDiagHelp552.Resultat)

    End Sub

    ''' <summary>
    ''' Test avec les valeurs du diag 2-1-172 (MAR)
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub TST_CalcMAR()
        Dim oDiagHelp552 As New DiagnosticHelp552()
        oDiagHelp552.PressionMesure = 3
        oDiagHelp552.DebitMoyen0Bar = 0.992

        oDiagHelp552.NbBuses_m1 = 10
        oDiagHelp552.NbBuses_m2 = 10
        oDiagHelp552.NbBuses_m3 = 10

        oDiagHelp552.Pression_m1 = 1.45
        oDiagHelp552.Pression_m2 = 2.975
        oDiagHelp552.Pression_m3 = 3.875

        oDiagHelp552.DebitAfficheur_m1 = 7
        oDiagHelp552.DebitAfficheur_m2 = 9.5
        oDiagHelp552.DebitAfficheur_m3 = 11.5

        Assert.IsTrue(oDiagHelp552.calc())

        Assert.AreEqual(CDec(1.499), oDiagHelp552.EcartPct_m1)
        Assert.AreEqual(CDec(-3.832), oDiagHelp552.EcartPct_m2)
        Assert.AreEqual(CDec(2.003), oDiagHelp552.EcartPct_m3)
        Assert.AreEqual(CDec(2.445), oDiagHelp552.ErreurDebitMetre)

    End Sub
    <TestMethod()> _
    Public Sub TST_CalcSigned()
        Dim oDiagHelp552 As New DiagnosticHelp552()


        oDiagHelp552.EcartPct_m1 = -5
        oDiagHelp552.EcartPct_m2 = +5
        oDiagHelp552.EcartPct_m3 = -6


        oDiagHelp552.CalcErreurDebitMetre()

        Assert.AreEqual(Math.Round(CDec(16 / 3), 3), oDiagHelp552.ErreurDebitMetre)
        Assert.AreEqual(-2D, oDiagHelp552.ErreurDebitMetreSigned)


    End Sub
    <TestMethod()> _
    Public Sub TST_CalcValeurNégatives()
        Dim oDiagHelp552 As New DiagnosticHelp552()

        oDiagHelp552.PressionMesure = 3
        oDiagHelp552.DebitMoyen0Bar = 1.202

        oDiagHelp552.NbBuses_m1 = 48
        oDiagHelp552.NbBuses_m2 = 48
        oDiagHelp552.NbBuses_m3 = 48

        oDiagHelp552.Pression_m1 = 2.9
        oDiagHelp552.Pression_m2 = 2.9
        oDiagHelp552.Pression_m3 = 2.9

        oDiagHelp552.DebitAfficheur_m1 = 54.3
        oDiagHelp552.DebitAfficheur_m2 = 54.3
        oDiagHelp552.DebitAfficheur_m3 = 54.3

        oDiagHelp552.calc()
        Assert.AreEqual(-4.277D, oDiagHelp552.EcartPct_m1)
        Assert.AreEqual(-4.277D, oDiagHelp552.EcartPct_m2)
        Assert.AreEqual(-4.277D, oDiagHelp552.EcartPct_m3)

        Assert.AreEqual(4.277D, oDiagHelp552.ErreurDebitMetre)
        Assert.AreEqual(-4.277D, oDiagHelp552.ErreurDebitMetreSigned)



    End Sub
End Class
