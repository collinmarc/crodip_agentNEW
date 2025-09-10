Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CrodipWS



'''<summary>
'''Classe de test pour Pulverisateur, 
'''</summary>
<TestClass()> _
Public Class Pulverisateurtest
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

    ''' <summary>
    ''' un Diag antérieur ne modifie pas l'état du pulvé et la date prochain controle
    ''' </summary>
    <TestMethod()>
    Public Sub TestEtatPulveDiagAnterieur()
        Dim bOK As Boolean
        m_oExploitation = createExploitation()
        ExploitationManager.save(m_oExploitation, m_oAgent)

        m_oPulve = createPulve(m_oExploitation)
        PulverisateurManager.save(m_oPulve, m_oExploitation, m_oAgent)

        m_oDiag = createDiagnostic(m_oExploitation, m_oPulve, False)
        m_oDiag.controleDateDebut = "19/05/2024"
        m_oDiag.controleDateFin = "19/05/2024"
        m_oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        m_oDiag.CalculDateProchainControle()
        m_oPulve.SetControleEtat(m_oDiag)
        m_oPulve.dateProchainControle = m_oDiag.pulverisateurDateProchainControle

        Assert.AreEqual(Pulverisateur.controleEtatNOKCV, m_oPulve.controleEtat)
        Assert.AreEqual("", m_oPulve.getDateDernierControle())

        bOK = PulverisateurManager.save(m_oPulve, m_oExploitation, m_oAgent)
        Assert.IsTrue(bOK, "Erreur en SV de Pulve")
        bOK = DiagnosticManager.save(m_oDiag)
        Assert.IsTrue(bOK, "Erreur en SV de Diag")

        Assert.AreEqual(m_oDiag.controleDateFinS, m_oPulve.getDateDernierControle())

        Dim dateProchainControleAvant As String
        dateProchainControleAvant = m_oPulve.dateProchainControle

        'Création d'un second diag antérieur au Premier
        m_oDiag = createDiagnostic(m_oExploitation, m_oPulve, False)
        m_oDiag.controleDateDebut = "27/02/2024"
        m_oDiag.controleDateFin = "27/02/2024"
        m_oDiag.controleEtat = Diagnostic.controleEtatOK
        m_oDiag.CalculDateProchainControle()
        m_oPulve.SetControleEtat(MyBase.m_oDiag)
        m_oPulve.dateProchainControle = m_oDiag.pulverisateurDateProchainControle
        'Le Controle etant antérieur , il ne doit pas influencé l'état du pulvé , ni la date de prochain contrôle
        Assert.AreEqual(Pulverisateur.controleEtatNOKCV, m_oPulve.controleEtat) 'Comme Avant
        Assert.AreEqual(dateProchainControleAvant, m_oPulve.dateProchainControle) 'comme avant




    End Sub
    ''' <summary>
    ''' Après un diag OK , on réalise un Diag par anticipation CV => l'état du pulvé doit changer
    ''' </summary>
    <TestMethod()>
    Public Sub TestEtatPulveDiagAPriori()
        Dim bOK As Boolean
        m_oExploitation = createExploitation()
        ExploitationManager.save(m_oExploitation, m_oAgent)

        m_oPulve = createPulve(m_oExploitation)
        PulverisateurManager.save(m_oPulve, m_oExploitation, m_oAgent)

        m_oDiag = createDiagnostic(m_oExploitation, m_oPulve, False)
        m_oDiag.controleDateDebut = "06/02/2024"
        m_oDiag.controleDateFin = "06/02/2024"
        m_oDiag.controleEtat = Diagnostic.controleEtatOK
        m_oDiag.CalculDateProchainControle()
        m_oPulve.SetControleEtat(m_oDiag)
        m_oPulve.dateProchainControle = m_oDiag.pulverisateurDateProchainControle

        Assert.AreEqual(Pulverisateur.controleEtatOK, m_oPulve.controleEtat)
        Assert.AreEqual("", m_oPulve.getDateDernierControle())

        bOK = PulverisateurManager.save(m_oPulve, m_oExploitation, m_oAgent)
        Assert.IsTrue(bOK, "Erreur en SV de Pulve")
        bOK = DiagnosticManager.save(m_oDiag)
        Assert.IsTrue(bOK, "Erreur en SV de Diag")

        Assert.AreEqual(m_oDiag.controleDateFinS, m_oPulve.getDateDernierControle())
        Dim dateProchainControleAvant As String
        dateProchainControleAvant = m_oPulve.dateProchainControle

        'Création d'un second diag  avant la date d'expiration
        m_oDiag = createDiagnostic(m_oExploitation, m_oPulve, False)
        m_oDiag.controleDateDebut = "27/02/2024"
        m_oDiag.controleDateFin = "27/02/2024"
        m_oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        m_oDiag.CalculDateProchainControle()
        m_oPulve.SetControleEtat(m_oDiag)
        m_oPulve.dateProchainControle = m_oDiag.pulverisateurDateProchainControle

        Assert.AreEqual(Pulverisateur.controleEtatNOKCV, m_oPulve.controleEtat) 'Comme Avant
        Assert.AreNotEqual(dateProchainControleAvant, m_oPulve.dateProchainControle) 'comme avant

    End Sub
    <TestMethod()>
    Public Sub TestTRTSPE()

        m_oPulve = createPulve(createExploitation())
        m_oPulve.type = "Pulvérisateurs fixes ou semi mobiles"
        m_oPulve.categorie = "Traitement des semences"
        Assert.IsTrue(m_oPulve.isTraitementdesSemences12123)

        m_oPulve.categorie = "Traitement post-récolte"
        Assert.IsFalse(m_oPulve.isTraitementdesSemences12123)
        Assert.IsTrue(m_oPulve.isTypeFixeouSemisMobile)


    End Sub
    <TestMethod()>
    Public Sub TestGetNiveauPulverisateur()
        Dim oAlertes As New Alertes
        Dim oNiveau As NiveauAlerte

        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Pulverisateur
        oNiveau.Rouge = 4
        oNiveau.Jaune = 60
        oNiveau.DateEffet = #1/1/2020#
        oAlertes.NiveauxAlertes.Add(oNiveau)

        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Pulverisateur
        oNiveau.Rouge = 4
        oNiveau.Jaune = 36
        oNiveau.DateEffet = #1/1/2021#
        oAlertes.NiveauxAlertes.Add(oNiveau)

        If System.IO.File.Exists("ModuleDocumentaire/_parametres/Alertes_ORI.xml") Then
            System.IO.File.Delete("ModuleDocumentaire/_parametres/Alertes_ORI.xml")

        End If
            System.IO.File.Copy("ModuleDocumentaire/_parametres/Alertes.xml", "ModuleDocumentaire/_parametres/Alertes_ORI.xml")
        Assert.IsTrue(Alertes.FTO_writeXml(oAlertes))
        oNiveau = Pulverisateur.getNiveauAlerte(CDate("01/09/2020"))

        Assert.AreEqual(60, oNiveau.Jaune)
        oNiveau = Pulverisateur.getNiveauAlerte(CDate("01/09/2021"))
        Assert.AreEqual(36, oNiveau.Jaune)

        oNiveau = Pulverisateur.getNiveauAlerte()
        If Date.Now > #01/01/2021# Then
            Assert.AreEqual(36, oNiveau.Jaune)
        Else
            Assert.AreEqual(60, oNiveau.Jaune)
        End If
        System.IO.File.Delete("ModuleDocumentaire/_parametres/Alertes.xml")
        System.IO.File.Copy("ModuleDocumentaire/_parametres/Alertes_ORI.xml", "ModuleDocumentaire/_parametres/Alertes.xml")



    End Sub

    <TestMethod()>
    Public Sub TestTransfertPulve()
        m_oExploitation = createExploitation()
        m_oPulve = createPulve(m_oExploitation)
        Dim oExploit2 As New Exploitation()
        oExploit2.nomExploitant = "TEST TransfertPulve"
        ExploitationManager.save(oExploit2, m_oAgent)

        Dim oRelation As ExploitationTOPulverisateur

        m_oPulve.TransfertPulve(m_oExploitation, oExploit2, m_oAgent)

        oRelation = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(m_oExploitation.id, m_oPulve.id)
        'La relation a bien été supprimée
        Assert.IsTrue(String.IsNullOrEmpty(oRelation.id))
        'et Ajoutée à la seconde exploit
        oRelation = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oExploit2.id, m_oPulve.id)
        Assert.IsFalse(String.IsNullOrEmpty(oRelation.id))

    End Sub
    '<TestMethod()>
    'Public Sub testGetNewId()
    '    Dim oExploit As Exploitation
    '    Dim oPulve As Pulverisateur

    '    oExploit = createExploitation()
    '    ExploitationManager.save(oExploit, m_oAgent)
    '    oPulve = createPulve(oExploit)
    '    PulverisateurManager.save(oPulve, oExploit, m_oAgent)
    '    oPulve = createPulve(oExploit)
    '    PulverisateurManager.save(oPulve, oExploit, m_oAgent)

    '    m_oAgent.oPool = New Pool()
    '    m_oAgent.oPool.idCRODIPPC = "12345"

    '    Dim str As String
    '    str = PulverisateurManager.getNewId(m_oAgent)
    '    Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.numeroNational & "-12345-1", str)
    '    str = ExploitationTOPulverisateurManager.getNewId(m_oAgent)
    '    Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.numeroNational & "-12345-1", str)



    '    m_oAgent.oPool.idCRODIPPC = "1119"
    '    str = PulverisateurManager.getNewId(m_oAgent)
    '    Assert.AreEqual("8888-9999-1119-1", str)
    '    str = ExploitationTOPulverisateurManager.getNewId(m_oAgent)
    '    Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.numeroNational & "-1119-1", str)

    '    m_oAgent.oPool = Nothing
    '    str = PulverisateurManager.getNewId(m_oAgent)
    '    Assert.AreEqual(m_oStructure.id & "-" & m_oAgent.id & "-3", str)
    '    str = ExploitationTOPulverisateurManager.getNewId(m_oAgent)
    '    Assert.AreEqual(m_oAgent.uidStructure & "-" & m_oAgent.id & "-3", str)


    'End Sub
    <TestMethod()>
    Public Sub TST_GET_SEND_WS_Pulverisateur()
        Dim oExploitation As Exploitation
        Dim oPUlve As Pulverisateur
        Dim oPUlve2 As Pulverisateur
        Dim strId As String

        oExploitation = createExploitation()
        Dim oResponse As Object = Nothing
        ExploitationManager.WSSend( oExploitation, oResponse)

        oPUlve = createPulve(oExploitation)
        strId = oPUlve.id
        oPUlve.numeroChassis = "132456"
        oPUlve.isPulveAdditionnel = True
        oPUlve.pulvePrincipalNumNat = "123"
        oPUlve.isPompesDoseuses = False
        oPUlve.nbPompesDoseuses = 0
        oPUlve.isCoupureAutoTroncons = False
        oPUlve.isRincagecircuit = False
        oPUlve.isReglageAutoHauteur = False
        oPUlve.immatCertificat = "123AQW123"
        oPUlve.immatPlaque = "456ZSX456"
        oPUlve.isConfirmeIdentifiant = True
        oPUlve.isConfirmeMarque = True
        oPUlve.isConfirmeModele = True
        oPUlve.isConfirmeAnneeConstruction = True
        oPUlve.isConfirmeVolume = True
        oPUlve.isConfirmeLargeur = True
        oPUlve.isConfirmeCategorie = True
        oPUlve.isConfirmeType = True
        oPUlve.isConfirmeFonctionnement = True
        oPUlve.isConfirmeRegulation = True
        oPUlve.isConfirmeAttelage = True

        oPUlve.isAnomalies = True
        oPUlve.niveauAnomalies = 1
        oPUlve.nombreAnomalies = 2
        oPUlve.nombreMineures = 3
        oPUlve.dateModificationAnomalies = New DateTime(2025, 8, 20)
        oPUlve.isPulveRecordedInOTC = True
        oPUlve.isPulveDownloadByExportOTC = True
        oPUlve.isPulveDownloadByCheckKeyOTC = True


        PulverisateurManager.save(oPUlve, oExploitation, m_oAgent)
        Dim oReturn As Pulverisateur
        PulverisateurManager.WSSend(oPUlve, oReturn)

        oPUlve2 = PulverisateurManager.WSgetById(-1, strId)
        Assert.AreEqual(strId, oPUlve2.id)
        Assert.IsTrue(oPUlve2.isPulveAdditionnel)
        Assert.AreEqual("123", oPUlve2.pulvePrincipalNumNat)
        Assert.AreEqual("132456", oPUlve2.numeroChassis)
        Assert.AreEqual(False, oPUlve2.isPompesDoseuses)
        Assert.AreEqual(0, oPUlve2.nbPompesDoseuses)
        Assert.IsFalse(oPUlve2.isCoupureAutoTroncons)
        Assert.IsFalse(oPUlve2.isRincagecircuit)
        Assert.IsFalse(oPUlve2.isReglageAutoHauteur)
        Assert.AreEqual("123AQW123", oPUlve2.immatCertificat)
        Assert.AreEqual("456ZSX456", oPUlve2.immatPlaque)
        Assert.IsTrue(oPUlve.isConfirmeIdentifiant)
        Assert.IsTrue(oPUlve.isConfirmeMarque)
        Assert.IsTrue(oPUlve.isConfirmeModele)
        Assert.IsTrue(oPUlve.isConfirmeAnneeConstruction)
        Assert.IsTrue(oPUlve.isConfirmeVolume)
        Assert.IsTrue(oPUlve.isConfirmeLargeur)
        Assert.IsTrue(oPUlve.isConfirmeCategorie)
        Assert.IsTrue(oPUlve.isConfirmeType)
        Assert.IsTrue(oPUlve.isConfirmeFonctionnement)
        Assert.IsTrue(oPUlve.isConfirmeRegulation)
        Assert.IsTrue(oPUlve.isConfirmeAttelage)
        Assert.IsTrue(oPUlve.isAnomalies)
        Assert.IsTrue(oPUlve.niveauAnomalies = 1)
        Assert.IsTrue(oPUlve.nombreAnomalies = 2)
        Assert.IsTrue(oPUlve.nombreMineures = 3)
        Assert.IsTrue(oPUlve.dateModificationAnomalies = New DateTime(2025, 8, 20))
        Assert.IsTrue(oPUlve.isPulveRecordedInOTC)
        Assert.IsTrue(oPUlve.isPulveDownloadByExportOTC)
        Assert.IsTrue(oPUlve.isPulveDownloadByCheckKeyOTC)


        System.Threading.Thread.Sleep(1000)
        oPUlve2.numeroChassis = "132456"
        oPUlve2.isPulveAdditionnel = True
        oPUlve2.pulvePrincipalNumNat = "123"
        oPUlve2.isPompesDoseuses = True
        oPUlve2.nbPompesDoseuses = 12
        oPUlve2.isCoupureAutoTroncons = True
        oPUlve2.isRincagecircuit = True
        oPUlve2.isReglageAutoHauteur = True
        oPUlve2.immatCertificat = "321AQW321"
        oPUlve2.immatPlaque = "654ZSX654"
        oPUlve2.isConfirmeIdentifiant = False
        oPUlve2.isConfirmeMarque = False
        oPUlve2.isConfirmeModele = False
        oPUlve2.isConfirmeAnneeConstruction = False
        oPUlve2.isConfirmeVolume = False
        oPUlve2.isConfirmeLargeur = False
        oPUlve2.isConfirmeCategorie = False
        oPUlve2.isConfirmeType = False
        oPUlve2.isConfirmeFonctionnement = False
        oPUlve2.isConfirmeRegulation = False
        oPUlve2.isConfirmeAttelage = False
        oPUlve2.isAnomalies = False
        oPUlve2.niveauAnomalies = 10
        oPUlve2.nombreAnomalies = 20
        oPUlve2.nombreMineures = 30
        oPUlve2.dateModificationAnomalies = New DateTime(2025, 8, 21)
        oPUlve2.isPulveRecordedInOTC = False
        oPUlve2.isPulveDownloadByExportOTC = False
        oPUlve2.isPulveDownloadByCheckKeyOTC = False

        PulverisateurManager.save(oPUlve2, oExploitation, m_oAgent)
        PulverisateurManager.WSSend(oPUlve2, oReturn)

        oPUlve = PulverisateurManager.WSgetById(-1, strId)
        Assert.AreEqual(strId, oPUlve.id)
        Assert.IsTrue(oPUlve.isPulveAdditionnel)
        Assert.AreEqual("123", oPUlve.pulvePrincipalNumNat)
        Assert.AreEqual("132456", oPUlve.numeroChassis)
        Assert.AreEqual(True, oPUlve.isPompesDoseuses)
        Assert.AreEqual(12, oPUlve.nbPompesDoseuses)
        Assert.IsTrue(oPUlve.isCoupureAutoTroncons)
        Assert.IsTrue(oPUlve.isRincagecircuit)
        Assert.IsTrue(oPUlve.isReglageAutoHauteur)
        Assert.AreEqual("321AQW321", oPUlve.immatCertificat)
        Assert.AreEqual("654ZSX654", oPUlve.immatPlaque)
        Assert.IsFalse(oPUlve.isConfirmeIdentifiant)
        Assert.IsFalse(oPUlve.isConfirmeMarque)
        Assert.IsFalse(oPUlve.isConfirmeModele)
        Assert.IsFalse(oPUlve.isConfirmeAnneeConstruction)
        Assert.IsFalse(oPUlve.isConfirmeVolume)
        Assert.IsFalse(oPUlve.isConfirmeLargeur)
        Assert.IsFalse(oPUlve.isConfirmeCategorie)
        Assert.IsFalse(oPUlve.isConfirmeType)
        Assert.IsFalse(oPUlve.isConfirmeFonctionnement)
        Assert.IsFalse(oPUlve.isConfirmeRegulation)
        Assert.IsFalse(oPUlve.isConfirmeAttelage)
        Assert.IsFalse(oPUlve.isAnomalies)
        Assert.AreEqual(10, oPUlve.niveauAnomalies)
        Assert.AreEqual(20, oPUlve.nombreAnomalies)
        Assert.AreEqual(30, oPUlve.nombreMineures)
        Assert.AreEqual(New DateTime(2025, 8, 21), oPUlve.dateModificationAnomalies)
        Assert.IsFalse(oPUlve.isPulveRecordedInOTC)
        Assert.IsFalse(oPUlve.isPulveDownloadByExportOTC)
        Assert.IsFalse(oPUlve.isPulveDownloadByCheckKeyOTC)




    End Sub
    <TestMethod()>
    Public Sub TST_CRUD_Pulverisateur()
        Dim oExploitation As Exploitation
        Dim oPUlve As Pulverisateur
        Dim oPUlve2 As Pulverisateur
        Dim strId As String

        oExploitation = createExploitation()
        Dim oResponse As Object = Nothing
        ExploitationManager.WSSend( oExploitation, oResponse)

        oPUlve = createPulve(oExploitation)
        strId = oPUlve.id
        oPUlve.numeroChassis = "132456"
        oPUlve.isPulveAdditionnel = True
        oPUlve.pulvePrincipalNumNat = "123"
        oPUlve.isPompesDoseuses = False
        oPUlve.nbPompesDoseuses = 0
        oPUlve.isCoupureAutoTroncons = False
        oPUlve.isRincagecircuit = False
        oPUlve.isReglageAutoHauteur = False
        oPUlve.immatCertificat = "123AQW123"
        oPUlve.immatPlaque = "456ZSX456"
        oPUlve.isConfirmeIdentifiant = True
        oPUlve.isConfirmeMarque = True
        oPUlve.isConfirmeModele = True
        oPUlve.isConfirmeAnneeConstruction = True
        oPUlve.isConfirmeVolume = True
        oPUlve.isConfirmeLargeur = True
        oPUlve.isConfirmeCategorie = True
        oPUlve.isConfirmeType = True
        oPUlve.isConfirmeFonctionnement = True
        oPUlve.isConfirmeRegulation = True
        oPUlve.isConfirmeAttelage = True

        oPUlve.isAnomalies = True
        oPUlve.niveauAnomalies = 1
        oPUlve.nombreAnomalies = 2
        oPUlve.nombreMineures = 3
        oPUlve.dateModificationAnomalies = New DateTime(2025, 8, 20)
        oPUlve.isPulveRecordedInOTC = True
        oPUlve.isPulveDownloadByExportOTC = True
        oPUlve.isPulveDownloadByCheckKeyOTC = True

        Assert.IsTrue(PulverisateurManager.save(oPUlve, oExploitation, m_oAgent))

        oPUlve2 = PulverisateurManager.getPulverisateurById(strId)
        Assert.AreEqual(strId, oPUlve2.id)
        Assert.IsTrue(oPUlve2.isPulveAdditionnel)
        Assert.AreEqual("123", oPUlve2.pulvePrincipalNumNat)
        Assert.AreEqual("132456", oPUlve2.numeroChassis)
        Assert.AreEqual(False, oPUlve2.isPompesDoseuses)
        Assert.AreEqual(0, oPUlve2.nbPompesDoseuses)
        Assert.IsFalse(oPUlve2.isCoupureAutoTroncons)
        Assert.IsFalse(oPUlve2.isRincagecircuit)
        Assert.IsFalse(oPUlve2.isReglageAutoHauteur)
        Assert.AreEqual("123AQW123", oPUlve2.immatCertificat)
        Assert.AreEqual("456ZSX456", oPUlve2.immatPlaque)
        Assert.IsTrue(oPUlve.isConfirmeIdentifiant)
        Assert.IsTrue(oPUlve.isConfirmeMarque)
        Assert.IsTrue(oPUlve.isConfirmeModele)
        Assert.IsTrue(oPUlve.isConfirmeAnneeConstruction)
        Assert.IsTrue(oPUlve.isConfirmeVolume)
        Assert.IsTrue(oPUlve.isConfirmeLargeur)
        Assert.IsTrue(oPUlve.isConfirmeCategorie)
        Assert.IsTrue(oPUlve.isConfirmeType)
        Assert.IsTrue(oPUlve.isConfirmeFonctionnement)
        Assert.IsTrue(oPUlve.isConfirmeRegulation)
        Assert.IsTrue(oPUlve.isConfirmeAttelage)
        Assert.IsTrue(oPUlve.isAnomalies)
        Assert.IsTrue(oPUlve.niveauAnomalies = 1)
        Assert.IsTrue(oPUlve.nombreAnomalies = 2)
        Assert.IsTrue(oPUlve.nombreMineures = 3)
        Assert.IsTrue(oPUlve.dateModificationAnomalies = New DateTime(2025, 8, 20))
        Assert.IsTrue(oPUlve.isPulveRecordedInOTC)
        Assert.IsTrue(oPUlve.isPulveDownloadByExportOTC)
        Assert.IsTrue(oPUlve.isPulveDownloadByCheckKeyOTC)


        System.Threading.Thread.Sleep(1000)
        oPUlve2.numeroChassis = "132456"
        oPUlve2.isPulveAdditionnel = True
        oPUlve2.pulvePrincipalNumNat = "123"
        oPUlve2.isPompesDoseuses = True
        oPUlve2.nbPompesDoseuses = 12
        oPUlve2.isCoupureAutoTroncons = True
        oPUlve2.isRincagecircuit = True
        oPUlve2.isReglageAutoHauteur = True
        oPUlve2.immatCertificat = "321AQW321"
        oPUlve2.immatPlaque = "654ZSX654"
        oPUlve2.isConfirmeIdentifiant = False
        oPUlve2.isConfirmeMarque = False
        oPUlve2.isConfirmeModele = False
        oPUlve2.isConfirmeAnneeConstruction = False
        oPUlve2.isConfirmeVolume = False
        oPUlve2.isConfirmeLargeur = False
        oPUlve2.isConfirmeCategorie = False
        oPUlve2.isConfirmeType = False
        oPUlve2.isConfirmeFonctionnement = False
        oPUlve2.isConfirmeRegulation = False
        oPUlve2.isConfirmeAttelage = False
        oPUlve2.isAnomalies = False
        oPUlve2.niveauAnomalies = 10
        oPUlve2.nombreAnomalies = 20
        oPUlve2.nombreMineures = 30
        oPUlve2.dateModificationAnomalies = New DateTime(2025, 8, 21)
        oPUlve2.isPulveRecordedInOTC = False
        oPUlve2.isPulveDownloadByExportOTC = False
        oPUlve2.isPulveDownloadByCheckKeyOTC = False

        PulverisateurManager.save(oPUlve2, oExploitation, m_oAgent)

        oPUlve = PulverisateurManager.getPulverisateurById(strId)
        Assert.AreEqual(strId, oPUlve.id)
        Assert.IsTrue(oPUlve.isPulveAdditionnel)
        Assert.AreEqual("123", oPUlve.pulvePrincipalNumNat)
        Assert.AreEqual("132456", oPUlve.numeroChassis)
        Assert.AreEqual(True, oPUlve.isPompesDoseuses)
        Assert.AreEqual(12, oPUlve.nbPompesDoseuses)
        Assert.IsTrue(oPUlve.isCoupureAutoTroncons)
        Assert.IsTrue(oPUlve.isRincagecircuit)
        Assert.IsTrue(oPUlve.isReglageAutoHauteur)
        Assert.AreEqual("321AQW321", oPUlve.immatCertificat)
        Assert.AreEqual("654ZSX654", oPUlve.immatPlaque)
        Assert.IsFalse(oPUlve.isConfirmeIdentifiant)
        Assert.IsFalse(oPUlve.isConfirmeMarque)
        Assert.IsFalse(oPUlve.isConfirmeModele)
        Assert.IsFalse(oPUlve.isConfirmeAnneeConstruction)
        Assert.IsFalse(oPUlve.isConfirmeVolume)
        Assert.IsFalse(oPUlve.isConfirmeLargeur)
        Assert.IsFalse(oPUlve.isConfirmeCategorie)
        Assert.IsFalse(oPUlve.isConfirmeType)
        Assert.IsFalse(oPUlve.isConfirmeFonctionnement)
        Assert.IsFalse(oPUlve.isConfirmeRegulation)
        Assert.IsFalse(oPUlve.isConfirmeAttelage)
        Assert.IsFalse(oPUlve.isAnomalies)
        Assert.AreEqual(10, oPUlve.niveauAnomalies)
        Assert.AreEqual(20, oPUlve.nombreAnomalies)
        Assert.AreEqual(30, oPUlve.nombreMineures)
        Assert.AreEqual(oPUlve.dateModificationAnomalies, New DateTime(2025, 8, 21))
        Assert.IsFalse(oPUlve.isPulveRecordedInOTC)
        Assert.IsFalse(oPUlve.isPulveDownloadByExportOTC)
        Assert.IsFalse(oPUlve.isPulveDownloadByCheckKeyOTC)


        PulverisateurManager.deletePulverisateurID(strId)


    End Sub
    <TestMethod()>
    Public Sub TST_MajNumNatPulvePrinc()
        Dim oExploitation As Exploitation
        Dim oPUlve As Pulverisateur
        Dim oPUlve2 As Pulverisateur
        Dim strDateModif1 As String


        oExploitation = createExploitation()
        oPUlve = createPulve(oExploitation)

        oPUlve.numeroNational = "E001123456"

        ExploitationManager.save(pExploit:=oExploitation, pAgent:=m_oAgent)
        PulverisateurManager.save(pPulve:=oPUlve, pExploit:=oExploitation, pAgent:=m_oAgent)

        'Création d'un Pulve Additionnel

        oPUlve2 = createPulve(oExploitation)
        oPUlve2.SetPulverisateurAdditionnel(oPUlve)
        Assert.AreEqual(oPUlve.numeroNational, oPUlve2.pulvePrincipalNumNat)
        Assert.IsTrue(oPUlve2.isPulveAdditionnel)

        PulverisateurManager.save(pPulve:=oPUlve2, pExploit:=oExploitation, pAgent:=m_oAgent)
        strDateModif1 = oPUlve2.dateModificationAgentS
        'Rechargement du Pulve Principal
        oPUlve = PulverisateurManager.getPulverisateurById(oPUlve.id)
        Assert.AreEqual(oPUlve.numeroNational, oPUlve.numeroNationalBis)

        System.Threading.Thread.Sleep(1000)
        'Changement du numéro nationnal
        oPUlve.numeroNational = "E001456789"
        'Sauvegarde
        PulverisateurManager.save(pPulve:=oPUlve, pExploit:=oExploitation, pAgent:=m_oAgent)

        'Rechargement du Pulve additionnel
        oPUlve2 = PulverisateurManager.getPulverisateurById(oPUlve2.id)
        'Vérificatino du numero du pulve principal
        Assert.AreEqual(oPUlve.numeroNational, oPUlve2.pulvePrincipalNumNat)
        Assert.AreNotEqual(strDateModif1, oPUlve2.dateModificationAgentS)


    End Sub
    <TestMethod()> Public Sub WSGetIdentifiantOTC()
        Dim oReturn As PulverisateurOTC
        oReturn = PulverisateurManager.WSgetPulverisateurOTC("Q003000006", 1187)
        Assert.IsNotNull(oReturn)
        oReturn = PulverisateurManager.WSgetPulverisateurOTC("ZZZZZZZZZZ", 1187)
        Assert.IsNull(oReturn)
    End Sub
    <TestMethod()> Public Sub CompareOTC()
        Dim oPulve As New Pulverisateur
        Dim oreturn As PulverisateurOTC
        Dim bresult As Boolean
        oreturn = PulverisateurManager.WSgetPulverisateurOTC("Q003000006", m_oAgent.uid)

        oPulve.numeroNational = "Q003000006"
        oPulve.anneeAchat = oreturn.Année
        oPulve.attelage = oreturn.Attelage
        oPulve.categorie = oreturn.Catégorie
        oPulve.pulverisation = oreturn.Fonctionnement
        oPulve.largeur = oreturn.Largeur
        oPulve.marque = oreturn.Marque
        oPulve.type = oreturn.Type
        oPulve.capacite = oreturn.Volume

        bresult = oPulve.CompareOTC(m_oAgent.uid)
        Assert.IsTrue(bresult)
        Assert.AreEqual(0, oPulve.lstAnomalie.Count)

        oPulve.anneeAchat = "2025"
        bresult = oPulve.CompareOTC(m_oAgent.uid)
        Assert.IsFalse(bresult)
        Assert.AreEqual(1, oPulve.lstAnomalie.Count)
        Assert.AreEqual("Année", oPulve.lstAnomalie(0).critere)
        Assert.AreEqual(oPulve.anneeAchat, oPulve.lstAnomalie(0).valeurAgent)
        Assert.AreEqual(oreturn.Année, oPulve.lstAnomalie(0).valeurOTC)

        oPulve.attelage = "Rien"
        bresult = oPulve.CompareOTC(m_oAgent.uid)
        Assert.IsFalse(bresult)
        Assert.AreEqual(2, oPulve.lstAnomalie.Count)
        Assert.AreEqual("Attelage", oPulve.lstAnomalie.Last.critere)
        Assert.AreEqual(oPulve.attelage, oPulve.lstAnomalie.Last.valeurAgent)
        Assert.AreEqual(oreturn.Attelage, oPulve.lstAnomalie.Last.valeurOTC)

    End Sub
    <TestMethod()> Public Sub creerParamBuse12123()
        Dim olst As New List(Of ParamBuse12123)

        Dim oParambuse = New ParamBuse12123()
        oParambuse.Type = "AUTRES"
        oParambuse.Fonctionnement = "CUILLERES"
        oParambuse.ModeFonctionnement = "CUILLERE"
        olst.Add(oParambuse)

        Dim oSer As New System.Xml.Serialization.XmlSerializer(GetType(List(Of ParamBuse12123)))
        Dim oWr As New System.IO.StreamWriter("./ParamBuse12123.xml")

        oSer.Serialize(oWr, olst)

        oWr.Close()

        Assert.IsTrue(System.IO.File.Exists("./ParamBuse12123.xml"))


    End Sub

    <TestMethod()> Public Sub PulveParam12123()
        Dim olst As New List(Of ParamBuse12123)
        Crodip_agent.ParamManager.initGlobalsCrodip()
        'Creer le fichier Param12123
        Dim oParambuse = New ParamBuse12123()
        oParambuse.Type = "AUTRES"
        oParambuse.Fonctionnement = "CUILLERES"
        oParambuse.ModeFonctionnement = "CUILLERE"
        olst.Add(oParambuse)
        oParambuse = New ParamBuse12123()
        oParambuse.Type = "AUTRES"
        oParambuse.Fonctionnement = "INJECTEURS"
        oParambuse.ModeFonctionnement = "INJECTEUR"
        olst.Add(oParambuse)
        oParambuse = New ParamBuse12123()
        oParambuse.Type = "AUTRES"
        oParambuse.Fonctionnement = "DOSEURS"
        oParambuse.ModeFonctionnement = "CUILLERE"
        olst.Add(oParambuse)
        oParambuse = New ParamBuse12123()
        oParambuse.Type = "POMPE DOSEUSE"
        oParambuse.Fonctionnement = "AUGET BASCULANT"
        oParambuse.ModeFonctionnement = "CUILLERE"
        olst.Add(oParambuse)
        oParambuse = New ParamBuse12123()
        oParambuse.Type = "POMPE DOSEUSE"
        oParambuse.Fonctionnement = "PERISTALTIQUE"
        oParambuse.ModeFonctionnement = "INJECTEUR"
        olst.Add(oParambuse)
        Dim oSer As New System.Xml.Serialization.XmlSerializer(GetType(List(Of ParamBuse12123)))
        Dim oWr As New System.IO.StreamWriter(GlobalsCRODIP.GLOB_XML_PARAM12123.Nomfichier)
        oSer.Serialize(oWr, olst)
        oWr.Close()

        'Crer le Pulve
        Dim oPulve As New Pulverisateur

        oPulve.buseType = "AUTRES"
        oPulve.buseFonctionnement = "DOSEURS"
        Assert.IsTrue(oPulve.isTraitementdesSemences12123)
        oParambuse = oPulve.getParamBuses12123()
        Assert.IsNotNull(oParambuse)
        Assert.AreEqual(oParambuse.ModeFonctionnement, "CUILLERE")

        oPulve.buseType = "AUTRES"
        oPulve.buseFonctionnement = "ZZDOSEURS"
        Assert.IsFalse(oPulve.isTraitementdesSemences12123)
        oParambuse = oPulve.getParamBuses12123()
        Assert.IsNull(oParambuse)

        oPulve.buseType = "ZZAUTRES"
        oPulve.buseFonctionnement = "DOSEURS"
        Assert.IsFalse(oPulve.isTraitementdesSemences12123)
        oParambuse = oPulve.getParamBuses12123()
        Assert.IsNull(oParambuse)

        oPulve.buseType = "ZZAUTRES"
        oPulve.buseFonctionnement = "ZZDOSEURS"
        Assert.IsFalse(oPulve.isTraitementdesSemences12123)
        oParambuse = oPulve.getParamBuses12123()
        Assert.IsNull(oParambuse)



    End Sub


End Class
