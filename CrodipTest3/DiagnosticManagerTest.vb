'Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour Diagnostic et DiagnosticManager
'''</summary>
<TestClass()> _
Public Class DiagnosticManagerTest
    Inherits CRODIPTest



#Region "Attributs de tests supplémentaires"
    '
    'Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
    '
    'Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
    '<ClassInitialize()> _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    '    Globals.Init()
    'End Sub
    ''
    'Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
    '<TestInitialize()> _
    'Public Sub MyTestInitialize()
    '    Globals.Init()
    'End Sub

    '    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    '    <TestCleanup()> _
    '    Public Sub MyTestCleanup()
    '    End Sub
#End Region


    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Object()
        Dim oDiag As Diagnostic
        oDiag = New Diagnostic()
        Assert.AreEqual(False, oDiag.controleIsPulveRepare)
        Assert.AreEqual(False, oDiag.controleIsPreControleProfessionel)
        Assert.AreEqual(False, oDiag.controleIsAutoControle)
        Assert.IsTrue(String.IsNullOrEmpty(oDiag.proprietaireRepresentant))
        Assert.AreEqual(0, oDiag.diagnosticItemsLst.Count)
        Assert.AreEqual("", oDiag.controleInitialId)

        oDiag.controleIsPulveRepare = True
        Assert.AreEqual(True, oDiag.controleIsPulveRepare)
        oDiag.controleIsPreControleProfessionel = True
        Assert.AreEqual(True, oDiag.controleIsPreControleProfessionel)
        oDiag.controleIsAutoControle = True
        Assert.AreEqual(True, oDiag.controleIsAutoControle)
        oDiag.proprietaireRepresentant = "MonRepresentant"
        Assert.AreEqual(oDiag.proprietaireRepresentant, "MonRepresentant")
        oDiag.controleInitialId = "004563"
        Assert.AreEqual("004563", oDiag.controleInitialId)
    End Sub

    '''<summary>
    '''Test pour D'init de l'objet à partir des données Client
    '''</summary>
    <TestMethod()> _
    Public Sub TST_SetProprietaire()
        Dim oDiag As Diagnostic
        Dim pClient As New Exploitation
        oDiag = New Diagnostic
        pClient.id = "99"
        pClient.numeroSiren = "NUMRIREN"
        pClient.codeApe = "CODEAPE"
        pClient.raisonSociale = "RS"
        pClient.nomExploitant = "NOM"
        pClient.prenomExploitant = "PRENOM"
        pClient.adresse = "ADRESSE"
        pClient.codePostal = "CP"
        pClient.commune = "COMMUNE"
        pClient.telephoneFixe = "TelFixe"
        pClient.telephonePortable = "TelPortable"
        pClient.eMail = "Email"
        pClient.isProdGrandeCulture = True
        pClient.isProdElevage = False
        pClient.isProdArboriculture = True
        pClient.isProdLegume = False
        pClient.isProdViticulture = True
        pClient.isProdAutre = False
        pClient.surfaceAgricoleUtile = 1500
        oDiag.SetProprietaire(pClient)
        Assert.AreEqual(oDiag.proprietaireId, pClient.id)
        Assert.AreEqual(oDiag.proprietaireNumeroSiren, pClient.numeroSiren)
        Assert.AreEqual(oDiag.proprietaireCodeApe, pClient.codeApe)
        Assert.AreEqual(oDiag.proprietaireRaisonSociale, pClient.raisonSociale)
        Assert.AreEqual(oDiag.proprietaireNom, pClient.nomExploitant)
        Assert.AreEqual(oDiag.proprietairePrenom, pClient.prenomExploitant)
        Assert.AreEqual(oDiag.proprietaireAdresse, pClient.adresse)
        Assert.AreEqual(oDiag.proprietaireCodePostal, pClient.codePostal)
        Assert.AreEqual(oDiag.proprietaireCommune, pClient.commune)
        Assert.AreEqual(oDiag.proprietaireTelephoneFixe, pClient.telephoneFixe)
        Assert.AreEqual(oDiag.proprietaireTelephonePortable, pClient.telephonePortable)
        Assert.AreEqual(oDiag.proprietaireEmail, pClient.eMail)

        Assert.AreEqual(oDiag.exploitationTypeCultureIsGrandeCulture, pClient.isProdGrandeCulture)
        Assert.AreEqual(oDiag.exploitationTypeCultureIsElevage, pClient.isProdElevage)
        Assert.AreEqual(oDiag.exploitationTypeCultureIsArboriculture, pClient.isProdArboriculture)
        Assert.AreEqual(oDiag.exploitationTypeCultureIsLegume, pClient.isProdLegume)
        Assert.AreEqual(oDiag.exploitationTypeCultureIsViticulture, pClient.isProdViticulture)
        Assert.AreEqual(oDiag.exploitationTypeCultureIsAutres, pClient.isProdAutre)
        Assert.AreEqual(oDiag.exploitationSau, pClient.surfaceAgricoleUtile)


    End Sub
    '''<summary>
    '''Test pour D'init de l'objet à partir des données Client
    '''</summary>
    <TestMethod()> _
    Public Sub TST_SetPulverisateur()
        Dim oDiag As Diagnostic
        Dim poPulve As New Pulverisateur
        oDiag = New Diagnostic
        poPulve.id = "E001-1"
        poPulve.ancienIdentifiant = "ANCID"
        poPulve.marque = "MARQUEPULVE"
        poPulve.modele = "MODELEPULVE"
        poPulve.type = "TYPEPULVE"
        poPulve.capacite = 100
        poPulve.largeur = "3.5"
        poPulve.nombreRangs = "15"
        poPulve.largeurPlantation = "15"
        poPulve.isVentilateur = True
        poPulve.isDebrayage = True
        poPulve.anneeAchat = 1970
        poPulve.surfaceParAn = 10
        poPulve.nombreUtilisateurs = 2
        poPulve.isCuveRincage = True
        poPulve.capaciteCuveRincage = 20
        poPulve.isRotobuse = True
        poPulve.isRinceBidon = True
        poPulve.isBidonLaveMain = True
        poPulve.isLanceLavage = True
        poPulve.isCuveIncorporation = True
        poPulve.categorie = "Rampe"
        poPulve.attelage = Pulverisateur.ATTELAGE_PORTE
        'poPulve.isPressionConstante = True
        'poPulve.isDPM = True
        'poPulve.isDPA = True
        'poPulve.isDPAE = True
        'poPulve.isDPAEPression = True
        'poPulve.isDPAEDebit = True
        poPulve.regulation = "DPM"
        poPulve.regulationOptions = "Pression"
        poPulve.pulverisation = "Jet projeté"
        poPulve.emplacementIdentification = "Emplacement"

        poPulve.buseMarque = "BUSEMARQUE"
        poPulve.buseModele = "BUSEModele"
        poPulve.buseAge = 5
        poPulve.nombreBuses = 10
        poPulve.buseType = "A FENTE"
        poPulve.buseAngle = "90"
        poPulve.buseFonctionnement = "A pastille/chambre"
        poPulve.buseIsIso = True
        poPulve.manometreMarque = "MANOMARQUE"
        poPulve.manometreDiametre = "50"
        poPulve.manometreType = "MANOTYPE"
        poPulve.manometreFondEchelle = "50"
        poPulve.manometrePressionTravail = "2"
        poPulve.modeUtilisation = "CUMA"
        poPulve.nombreExploitants = "10"

        poPulve.isCoupureAutoTroncons = False
        poPulve.isCoupureAutoTroncons = False
        poPulve.isRincagecircuit = False

        oDiag.buseCouleur = "Rouge"
        oDiag.buseDebit = "2"
        oDiag.buseGenre = "A"
        oDiag.buseCalibre = "B"
        oDiag.buseDebit2bars = "2"
        oDiag.buseDebit3bars = "3"

        oDiag.setPulverisateur(poPulve)


        Assert.AreEqual(oDiag.pulverisateurId, poPulve.id)
        Assert.AreEqual(oDiag.pulverisateurAncienId, "Ancien identifiant :" & poPulve.ancienIdentifiant)
        Assert.AreEqual(oDiag.pulverisateurMarque, poPulve.marque)
        Assert.AreEqual(oDiag.pulverisateurModele, poPulve.modele)
        Assert.AreEqual(oDiag.pulverisateurType, poPulve.type)
        Assert.AreEqual(oDiag.pulverisateurCapacite, poPulve.capacite.ToString())
        Assert.AreEqual(oDiag.pulverisateurLargeur, poPulve.largeur)
        Assert.AreEqual(oDiag.pulverisateurNbRangs, poPulve.nombreRangs)
        Assert.AreEqual(oDiag.pulverisateurLargeurPlantation, poPulve.largeurPlantation)
        Assert.AreEqual(oDiag.pulverisateurIsVentilateur, poPulve.isVentilateur)
        Assert.AreEqual(oDiag.pulverisateurIsDebrayage, poPulve.isDebrayage)
        Assert.AreEqual(oDiag.pulverisateurAnneeAchat, poPulve.anneeAchat)
        Assert.AreEqual(oDiag.pulverisateurSurface, poPulve.surfaceParAn)
        Assert.AreEqual(oDiag.pulverisateurNbUtilisateurs, poPulve.nombreUtilisateurs)
        Assert.AreEqual(oDiag.pulverisateurIsCuveRincage, poPulve.isCuveRincage)
        Assert.AreEqual(oDiag.pulverisateurCapaciteCuveRincage, poPulve.capaciteCuveRincage)
        Assert.AreEqual(oDiag.pulverisateurIsRotobuse, poPulve.isRotobuse)
        Assert.AreEqual(oDiag.pulverisateurIsRinceBidon, poPulve.isRinceBidon)
        Assert.AreEqual(oDiag.pulverisateurIsBidonLaveMain, poPulve.isBidonLaveMain)
        Assert.AreEqual(oDiag.pulverisateurIsLanceLavageExterieur, poPulve.isLanceLavage)
        Assert.AreEqual(oDiag.pulverisateurIsCuveIncorporation, poPulve.isCuveIncorporation)
        Assert.AreEqual(oDiag.pulverisateurCategorie, poPulve.categorie)
        Assert.AreEqual(oDiag.pulverisateurAttelage, poPulve.attelage)
        Assert.AreEqual(oDiag.pulverisateurRegulation, poPulve.regulation)
        Assert.AreEqual(oDiag.pulverisateurRegulationOptions, poPulve.regulationOptions)
        Assert.AreEqual(oDiag.pulverisateurPulverisation, poPulve.pulverisation)
        Assert.AreEqual(oDiag.pulverisateurAutresAccessoires, "")
        Assert.AreEqual(oDiag.pulverisateurEmplacementIdentification, poPulve.emplacementIdentification)

        Assert.AreEqual(oDiag.buseMarque, poPulve.buseMarque)
        Assert.AreEqual(oDiag.buseModele, poPulve.buseModele)
        Assert.AreEqual(oDiag.buseCouleur, "")
        Assert.AreEqual(oDiag.buseGenre, "A")
        Assert.AreEqual(oDiag.buseCalibre, "B")
        Assert.AreEqual(oDiag.buseDebit, "2")
        Assert.AreEqual(oDiag.buseDebit2bars, "2")
        Assert.AreEqual(oDiag.buseDebit3bars, "3")
        Assert.AreEqual(oDiag.buseAge, poPulve.buseAge.ToString())
        Assert.AreEqual(oDiag.buseNbBuses, poPulve.nombreBuses.ToString())
        Assert.AreEqual(oDiag.buseType, poPulve.buseType)
        Assert.AreEqual(oDiag.buseAngle, poPulve.buseAngle)
        '        Assert.AreEqual(oDiag.buseFonctionnementIsStandard, False)
        '       Assert.AreEqual(oDiag.buseFonctionnementIsPastilleChambre, True)
        '      Assert.AreEqual(oDiag.buseFonctionnementIsInjectionAirLibre, False)
        '     Assert.AreEqual(oDiag.buseFonctionnementIsInjectionAirForce, False)
        Assert.AreEqual(oDiag.buseIsISO, poPulve.buseIsIso)
        Assert.AreEqual(oDiag.manometreMarque, poPulve.manometreMarque)
        Assert.AreEqual(oDiag.manometreDiametre, poPulve.manometreDiametre)
        Assert.AreEqual(oDiag.manometreType, poPulve.manometreType)
        Assert.AreEqual(oDiag.manometreFondEchelle, poPulve.manometreFondEchelle)
        Assert.AreEqual(oDiag.manometrePressionTravail, "3")
        Assert.AreEqual(oDiag.pulverisateurModeUtilisation, poPulve.modeUtilisation)
        Assert.AreEqual(oDiag.pulverisateurNbreExploitants, poPulve.nombreExploitants)
        Assert.AreEqual("NON", oDiag.pulverisateurRincagecircuit)

        poPulve.isRincagecircuit = True
        oDiag.setPulverisateur(poPulve)
        Assert.AreEqual("OUI", oDiag.pulverisateurRincagecircuit)

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet à partir des données Pulveristeur
    ''' CoupureAutotroncon et ReglageHauteur
    '''</summary>
    <TestMethod()> _
    Public Sub TST_SetPulverisateurV4L4()
        Dim oDiag As Diagnostic
        Dim poPulve As New Pulverisateur
        oDiag = New Diagnostic
        poPulve.id = "E001-1"
        poPulve.ancienIdentifiant = "ANCID"
        poPulve.marque = "MARQUEPULVE"
        poPulve.modele = "MODELEPULVE"
        poPulve.type = "TYPEPULVE"
        poPulve.capacite = 100
        poPulve.largeur = "3.5"
        poPulve.nombreRangs = "15"
        poPulve.categorie = "Rampe"
        poPulve.attelage = Pulverisateur.ATTELAGE_PORTE

        poPulve.isCoupureAutoTroncons = False
        poPulve.isCoupureAutoTroncons = False
        poPulve.isRincagecircuit = False


        oDiag.setPulverisateur(poPulve)


        Assert.AreEqual("NON", oDiag.pulverisateurCoupureAutoTroncons)
        Assert.AreEqual("NON", oDiag.pulverisateurReglageAutoHauteur)
        Assert.AreEqual("NON", oDiag.pulverisateurRincagecircuit)

        poPulve.isCoupureAutoTroncons = True
        poPulve.isReglageAutoHauteur = False
        poPulve.isRincagecircuit = False
        oDiag.setPulverisateur(poPulve)

        Assert.AreEqual("OUI", oDiag.pulverisateurCoupureAutoTroncons)
        Assert.AreEqual("NON", oDiag.pulverisateurReglageAutoHauteur)
        Assert.AreEqual("NON", oDiag.pulverisateurRincagecircuit)
        poPulve.isCoupureAutoTroncons = False
        poPulve.isReglageAutoHauteur = True
        poPulve.isRincagecircuit = False
        oDiag.setPulverisateur(poPulve)
        Assert.AreEqual("NON", oDiag.pulverisateurCoupureAutoTroncons)
        Assert.AreEqual("OUI", oDiag.pulverisateurReglageAutoHauteur)
        Assert.AreEqual("NON", oDiag.pulverisateurRincagecircuit)

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet à partir des données Client
    '''</summary>
    <TestMethod()> _
    Public Sub TST_SetPulverisateurDateDernierControle()
        Dim oDiag As Diagnostic
        Dim poPulve As Pulverisateur
        Dim pExploit As Exploitation
        '====
        ' Arrange
        '=====
        pExploit = New Exploitation
        poPulve = createPulve(pExploit)

        oDiag = createDiagnostic(pExploit, poPulve)

        Assert.IsTrue(oDiag.controleIsPremierControle)
        Assert.AreEqual("", oDiag.controleDateDernierControle)
        oDiag.controleDateFin = CSDate.ToCRODIPString(#12/5/2016#)

        DiagnosticManager.save(oDiag)

        '====
        ' Act
        '=====

        oDiag = createDiagnostic(pExploit, poPulve, False)
        'Inutile, mais je préfére le forcer
        oDiag.controleIsPremierControle = False
        oDiag.controleDateDernierControle = ""
        oDiag.setPulverisateur(poPulve)

        '=====
        'Assert
        '=====
        Assert.IsFalse(oDiag.controleIsPremierControle)
        Assert.AreEqual(CSDate.ToCRODIPString(#12/5/2016#), oDiag.controleDateDernierControle)


    End Sub

    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Create_Save_Update()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String

        oDiag = New Diagnostic()
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.id = id
        oDiag.controleNomSite = "MonSite"
        Assert.AreEqual(False, oDiag.controleIsPulveRepare)
        Assert.AreEqual(False, oDiag.controleIsPreControleProfessionel)
        Assert.AreEqual(False, oDiag.controleIsAutoControle)
        Assert.AreEqual(0, oDiag.controleNbreNiveaux)
        Assert.AreEqual(0, oDiag.controleNbreTroncons)
        Assert.AreEqual(False, oDiag.controleUseCalibrateur)
        Assert.AreEqual("", oDiag.controleManoControleNumNational)

        oDiag.controleIsPulveRepare = True
        Assert.AreEqual(True, oDiag.controleIsPulveRepare)
        oDiag.controleIsPreControleProfessionel = True
        Assert.AreEqual(True, oDiag.controleIsPreControleProfessionel)
        oDiag.controleIsAutoControle = True
        Assert.AreEqual(True, oDiag.controleIsAutoControle)
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.pulverisateurEmplacementIdentification = "TEST"

        'V2.5.3
        oDiag.controleNbreNiveaux = 1
        Assert.AreEqual(1, oDiag.controleNbreNiveaux)
        oDiag.controleNbreTroncons = 4
        Assert.AreEqual(4, oDiag.controleNbreTroncons)
        oDiag.controleUseCalibrateur = True
        Assert.AreEqual(True, oDiag.controleUseCalibrateur)
        oDiag.controleManoControleNumNational = "TEST"
        Assert.AreEqual("TEST", oDiag.controleManoControleNumNational)

        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual(True, oDiag2.controleIsPulveRepare)
        Assert.AreEqual(True, oDiag2.controleIsPreControleProfessionel)
        Assert.AreEqual(True, oDiag2.controleIsAutoControle)
        Assert.AreEqual(oDiag2.proprietaireRepresentant, "REP1")
        Assert.AreEqual(oDiag2.pulverisateurEmplacementIdentification, "TEST")

        Assert.AreEqual(1, oDiag2.controleNbreNiveaux)
        Assert.AreEqual(4, oDiag2.controleNbreTroncons)
        Assert.AreEqual(True, oDiag2.controleUseCalibrateur)
        Assert.AreEqual("TEST", oDiag2.controleManoControleNumNational)

        oDiag2.controleNomSite = "Mon Site updated"
        oDiag2.controleIsAutoControle = False
        oDiag2.proprietaireRepresentant = "REP2"
        oDiag2.pulverisateurEmplacementIdentification = "TEST2"

        'V2.5.3
        oDiag2.controleNbreNiveaux = 2
        oDiag2.controleNbreTroncons = 5
        oDiag2.controleUseCalibrateur = False
        oDiag2.controleManoControleNumNational = "TEST2"

        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)

        Assert.AreEqual(False, oDiag.controleIsAutoControle)
        Assert.AreEqual("Mon Site updated", oDiag.controleNomSite)
        Assert.AreEqual(oDiag.proprietaireRepresentant, "REP2")
        Assert.AreEqual(oDiag.pulverisateurEmplacementIdentification, "TEST2")

        Assert.AreEqual(2, oDiag.controleNbreNiveaux)
        Assert.AreEqual(5, oDiag.controleNbreTroncons)
        Assert.AreEqual(False, oDiag.controleUseCalibrateur)
        Assert.AreEqual("TEST2", oDiag.controleManoControleNumNational)

        oDiag2.controleNomSite = "Mon Site updated2"
        oDiag2.controleIsPreControleProfessionel = False
        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(False, oDiag.controleIsPreControleProfessionel)
        Assert.AreEqual("Mon Site updated2", oDiag.controleNomSite)

        oDiag2.controleNomSite = "Mon Site updated3"
        oDiag2.controleIsPulveRepare = False
        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(False, oDiag.controleIsPulveRepare)
        Assert.AreEqual("Mon Site updated3", oDiag.controleNomSite)

        bReturn = DiagnosticManager.delete(id)
        Assert.IsTrue(bReturn)
        oDiag = DiagnosticManager.getDiagnosticById(id)
        'Assert.IsNull(oDiag.id)



    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetByID()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String

        oDiag = New Diagnostic()
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id
        oDiag.controleNomSite = "MonSite"
        oDiag.proprietaireRepresentant = "REP1"
        Assert.AreEqual(False, oDiag.controleIsPulveRepare)
        Assert.AreEqual(False, oDiag.controleIsPreControleProfessionel)
        Assert.AreEqual(False, oDiag.controleIsAutoControle)

        oDiag.controleIsPulveRepare = True
        Assert.AreEqual(True, oDiag.controleIsPulveRepare)
        oDiag.controleIsPreControleProfessionel = True
        Assert.AreEqual(True, oDiag.controleIsPreControleProfessionel)
        oDiag.controleIsAutoControle = True
        Assert.AreEqual(True, oDiag.controleIsAutoControle)
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual(True, oDiag2.controleIsPulveRepare)
        Assert.AreEqual(True, oDiag2.controleIsPreControleProfessionel)
        Assert.AreEqual(True, oDiag2.controleIsAutoControle)

        oDiag2.controleNomSite = "Mon Site updated"
        oDiag2.controleIsAutoControle = False
        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(False, oDiag.controleIsAutoControle)
        Assert.AreEqual("Mon Site updated", oDiag.controleNomSite)
        Assert.AreEqual("REP1", oDiag.proprietaireRepresentant)

        oDiag2.controleNomSite = "Mon Site updated2"
        oDiag2.proprietaireRepresentant = "REP2"
        oDiag2.controleIsPreControleProfessionel = False
        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(False, oDiag.controleIsPreControleProfessionel)
        Assert.AreEqual("Mon Site updated2", oDiag.controleNomSite)
        Assert.AreEqual("REP2", oDiag.proprietaireRepresentant)

        oDiag2.controleNomSite = "Mon Site updated3"
        oDiag2.proprietaireRepresentant = "REP3"
        oDiag2.controleIsPulveRepare = False
        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(False, oDiag.controleIsPulveRepare)
        Assert.AreEqual("Mon Site updated3", oDiag.controleNomSite)
        Assert.AreEqual("REP3", oDiag.proprietaireRepresentant)

        bReturn = DiagnosticManager.delete(id)
        Assert.IsTrue(bReturn)
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual("", oDiag.id)

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetUpdates()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String
        Dim oResult As Diagnostic()


        oDiag = New Diagnostic()
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationAgent = CDate("06/02/1964")

        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oResult = DiagnosticManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oResult.Length)
        oDiag2 = oResult(0)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual(True, oDiag2.controleIsPulveRepare)
        Assert.AreEqual(True, oDiag2.controleIsPreControleProfessionel)
        Assert.AreEqual(True, oDiag2.controleIsAutoControle)
        Assert.AreEqual("REP1", oDiag2.proprietaireRepresentant)


        bReturn = DiagnosticManager.delete(id)
        Assert.IsTrue(bReturn)
        oDiag = DiagnosticManager.getDiagnosticById(id)
        '        Assert.IsNull(oDiag.id)


    End Sub
    '''<summary>
    '''Test du chargemet des diagnostique pour une contre visite
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetDiagPourcontreVisite()
        Dim oDiag As Diagnostic
        Dim bReturn As Boolean
        Dim id As String
        Dim oDiagItem As DiagnosticItem
        Dim oCsDb As CSDb
        Dim nbre As Integer
        Dim oExploit As Exploitation = createExploitation()
        ExploitationManager.save(oExploit, m_oAgent)
        Dim oPulve As Pulverisateur = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        'Creation d'un Diagnostic
        oDiag = createDiagnostic(oExploit, oPulve)
        id = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationAgent = CDate("06/02/1964")
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oCsDb = New CSDb(True)

        'Creation d'un DiagItem
        oDiagItem = New DiagnosticItem()
        oDiagItem.id = DiagnosticItemManager.getNewId(m_oAgent.idStructure, m_oAgent.id)
        oDiagItem.idDiagnostic = oDiag.id
        oDiagItem.idItem = 522
        oDiagItem.itemValue = 4
        oDiagItem.itemCodeEtat = "B"
        bReturn = DiagnosticItemManager.save(oCsDb, oDiagItem)
        Assert.IsTrue(bReturn)

        'Creation d'un DiagItem
        oDiagItem = New DiagnosticItem()
        oDiagItem.id = DiagnosticItemManager.getNewId(m_oAgent.idStructure, m_oAgent.id)
        oDiagItem.idDiagnostic = oDiag.id
        oDiagItem.idItem = 542
        oDiagItem.itemValue = 4
        oDiagItem.cause = "2"
        oDiagItem.itemCodeEtat = "B"
        bReturn = DiagnosticItemManager.save(oCsDb, oDiagItem)
        Assert.IsTrue(bReturn)

        'Vérification de la création du diagItem
        nbre = CType(oCsDb.getValue("SELECT count(*) from diagnosticItem where IdDiagnostic = '" & id & "'"), Integer)
        'Il ya 6 diagItem de créé par défaut (help)
        Assert.AreEqual(6 + 2, nbre)

        '=============
        Dim colDiags As List(Of Diagnostic)
        colDiags = DiagnosticManager.getDiagnosticPourContreVisite("PULVETEST", m_oAgent.idStructure)
        Assert.AreEqual(1, colDiags.Count)

        colDiags = DiagnosticManager.getDiagnosticPourContreVisite("PULVETEST", m_oAgent.idStructure, oDiag.id)
        Assert.AreEqual(1, colDiags.Count)

        colDiags = DiagnosticManager.getDiagnosticPourContreVisite("PULVETEST", m_oAgent.idStructure, "RIEN")
        Assert.AreEqual(0, colDiags.Count)
        'Suppression des diagnosticItems 

        'Pas de contre visite pour les diag < 4 mois
        oDiag.controleDateFin = DateAdd(DateInterval.Month, -5, Date.Today)
        DiagnosticManager.save(oDiag)
        colDiags = DiagnosticManager.getDiagnosticPourContreVisite("PULVETEST", m_oAgent.idStructure)
        Assert.AreEqual(0, colDiags.Count)

        oDiag.controleDateFin = DateAdd(DateInterval.Month, -3, Date.Today)
        DiagnosticManager.save(oDiag)
        colDiags = DiagnosticManager.getDiagnosticPourContreVisite("PULVETEST", m_oAgent.idStructure)
        Assert.AreEqual(1, colDiags.Count)

        bReturn = DiagnosticItemManager.deleteByDiagnosticID(id)
        'Sans diagItem => Pas de Diagnostic pour Contre visite
        'Modif du 15/09/2013 : On accepte Les Diag sans DiagItems pendant 4 mois après la 2.5.3
        colDiags = DiagnosticManager.getDiagnosticPourContreVisite("PULVETEST", m_oAgent.idStructure)
        Assert.AreEqual(1, colDiags.Count)
        '=======

        bReturn = DiagnosticItemManager.deleteByDiagnosticID(id)
        Assert.IsTrue(bReturn)

        'controle de la supppression ds diagnosticItem
        nbre = CType(oCsDb.getValue("SELECT count(*) from diagnosticItem where IdDiagnostic = '" & id & "'"), Integer)
        Assert.AreEqual(0, nbre)
        nbre = CType(oCsDb.getValue("SELECT count(*) from diagnostic where Id = '" & id & "'"), Integer)
        Assert.AreEqual(1, nbre)
        bReturn = DiagnosticManager.delete(id)
        Assert.IsTrue(bReturn)

        'controle de la supppression ds diagnosticItem
        nbre = CType(oCsDb.getValue("SELECT count(*) from diagnostic where Id = '" & id & "'"), Integer)
        Assert.AreEqual(0, nbre)
        oCsDb.free()

    End Sub
    '''<summary>
    '''Test du Du controle des 4 mois pour les Diag en contre visite
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetDiagPourcontreVisite4mois()
        Dim oDiag As Diagnostic
        Dim bReturn As Boolean
        Dim id1 As String
        Dim id2 As String
        Dim id3 As String


        Dim DateLimite As DateTime = DateAdd(DateInterval.Month, -4, Date.Today)
        Dim DateLimitePlus1j As DateTime = DateAdd(DateInterval.DayOfYear, +1, DateLimite)
        Dim DateLimiteMoins1j As DateTime = DateAdd(DateInterval.DayOfYear, -1, DateLimite)

        'Creation d'un Diagnostic à la date limite
        oDiag = New Diagnostic()
        id1 = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id1
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.inspecteurId = m_oAgent.id
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = DateLimite
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        'Creation d'un Diagnostic à la date limite plus 1 jour
        oDiag = New Diagnostic()
        id2 = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id2
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.inspecteurId = m_oAgent.id
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = DateLimitePlus1j
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        'Creation d'un Diagnostic à la date limite moins 1 jour
        oDiag = New Diagnostic()
        id3 = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id3
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.inspecteurId = m_oAgent.id
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = DateLimiteMoins1j
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        '=============
        Dim colDiags As List(Of Diagnostic)
        colDiags = DiagnosticManager.getDiagnosticPourContreVisite("PULVETEST", m_oAgent.idStructure)
        Assert.AreEqual(2, colDiags.Count)

        '=================
        'Suppression des diagnostic
        Dim arrDiag As List(Of Diagnostic) = DiagnosticManager.getlstDiagnosticByPulveId("PULVETEST")

        For Each oDiag In arrDiag
            DiagnosticManager.delete(oDiag.id)
        Next



    End Sub

    '''<summary>
    '''Test du getUpdate pour Diagnostic > 4 mois
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetDiagUpdates()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String
        Dim oDiagItem As DiagnosticItem
        Dim oCsDb As CSDb

        'Mise à jour du Flag de synchro 
        oCsDb = New CSDb(True)
        oCsDb.getResults("UPDATE DIAGNOSTIC SET dateModificationCrodip = dateModificationAgent")
        oCsDb.getResults("UPDATE DIAGNOSTIC SET dateSynchro = dateModificationAgent")


        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        id = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationAgent = CDate("06/02/1964")
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today

        '        Dim DiagItemLst As New List(Of DiagnosticItem)
        'Creation d'un DiagItem
        oDiagItem = New DiagnosticItem()
        oDiagItem.id = DiagnosticItemManager.getNewId(m_oAgent.idStructure, m_oAgent.id)
        oDiagItem.idDiagnostic = oDiag.id
        oDiagItem.idItem = 522
        oDiagItem.itemValue = 4
        oDiagItem.cause = "2"
        oDiagItem.itemCodeEtat = "B"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        'bReturn = DiagnosticItemManager.save(oDiagItem)
        'Assert.IsTrue(bReturn)

        'Creation d'un DiagItem
        oDiagItem = New DiagnosticItem()
        oDiagItem.id = DiagnosticItemManager.getNewId(m_oAgent.idStructure, m_oAgent.id)
        oDiagItem.idDiagnostic = oDiag.id
        oDiagItem.idItem = 542
        oDiagItem.itemValue = 4
        oDiagItem.itemCodeEtat = "B"
        'bReturn = DiagnosticItemManager.save(oDiagItem)
        'Assert.IsTrue(bReturn)
        oDiag.AdOrReplaceDiagItem(oDiagItem)


        'Creation des DiagnosticBuses
        Dim oDiagBuses As New DiagnosticBuses()
        oDiagBuses.idDiagnostic = oDiag.id
        oDiagBuses.idLot = 1
        oDiagBuses.nombre = "2"
        oDiagBuses.marque = "Hardi"
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        '        DiagnosticBusesManager.save(oDiagBuses)

        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.idDiagnostic = oDiag.id
        oDiagBuses.idLot = 2
        oDiagBuses.nombre = "2"
        oDiagBuses.marque = "TEST"
        '        DiagnosticBusesManager.save(oDiagBuses)
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)

        Dim oDiagBusesDetail As New DiagnosticBusesDetail()
        oDiagBusesDetail.idDiagnostic = oDiag.id
        oDiagBusesDetail.idLot = 1
        oDiagBusesDetail.idBuse = 1
        oDiagBusesDetail.debit = 0.51
        oDiag.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        '        DiagnosticBusesDetailManager.save(oDiagBusesDetail)

        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.idDiagnostic = oDiag.id
        oDiagBusesDetail.idLot = 1
        oDiagBusesDetail.idBuse = 2
        oDiagBusesDetail.debit = 0.52
        oDiag.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        '        DiagnosticBusesDetailManager.save(oDiagBusesDetail)

        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.idDiagnostic = oDiag.id
        oDiagBusesDetail.idLot = 2
        oDiagBusesDetail.idBuse = 1
        oDiagBusesDetail.debit = 0.53
        oDiag.diagnosticBusesList.Liste(1).diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        '        DiagnosticBusesDetailManager.save(oDiagBusesDetail)
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.idDiagnostic = oDiag.id
        oDiagBusesDetail.idLot = 2
        oDiagBusesDetail.idBuse = 2
        oDiagBusesDetail.debit = 0.54
        oDiag.diagnosticBusesList.Liste(1).diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        '        DiagnosticBusesDetailManager.save(oDiagBusesDetail)

        Dim oMano542 As DiagnosticMano542
        oMano542 = New DiagnosticMano542()
        oMano542.idDiagnostic = oDiag.id
        oMano542.pressionPulve = 1
        oMano542.pressionControle = 1.5
        oDiag.diagnosticMano542List.Liste.Add(oMano542)
        '        DiagnosticMano542Manager.save(oMano542)

        Dim oTroncons833 As DiagnosticTroncons833
        oTroncons833 = New DiagnosticTroncons833()
        oTroncons833.idDiagnostic = oDiag.id
        oTroncons833.idColumn = 1
        oTroncons833.idPression = 15
        oTroncons833.pressionSortie = 16
        oDiag.diagnosticTroncons833.Liste.Add(oTroncons833)
        '        DiagnosticTroncons833Manager.save(oTroncons833)

        Assert.IsTrue(DiagnosticManager.save(oDiag))

        '=============
        Dim colDiags As Diagnostic()
        colDiags = DiagnosticManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, colDiags.Count)

        oDiag2 = colDiags(0)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual(4, oDiag2.diagnosticItemsLst.Count)
        Assert.AreEqual(2, oDiag2.diagnosticBusesList.Liste.Count)

        Assert.AreEqual(2, oDiag2.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste.Count)
        Assert.AreEqual(2, oDiag2.diagnosticBusesList.Liste(1).diagnosticBusesDetailList.Liste.Count)

        Assert.AreEqual(1, oDiag2.diagnosticMano542List.Liste.Count)
        Assert.AreEqual(1, oDiag2.diagnosticTroncons833.Liste.Count)


        oDiag.controleDateFin = DateAdd(DateInterval.Month, -5, Date.Today)
        DiagnosticManager.save(oDiag)

        colDiags = DiagnosticManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, colDiags.Count)

        oDiag2 = colDiags(0)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual(4, oDiag2.diagnosticItemsLst.Count)
        Assert.AreEqual(2, oDiag2.diagnosticBusesList.Liste.Count)
        Assert.AreEqual(1, oDiag2.diagnosticMano542List.Liste.Count)
        Assert.AreEqual(1, oDiag2.diagnosticTroncons833.Liste.Count)




        bReturn = DiagnosticManager.delete(id)
        Assert.IsTrue(bReturn)



    End Sub
    '''<summary>
    '''Test du SetOrganisme, Organisme d'origine
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetOrganismeOrigine()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim idDiag As String

        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = idDiag
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationAgent = CDate("06/02/1964")
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today

        oDiag.setOrganisme(m_oAgent)
        Assert.AreEqual(oDiag.organismePresId, m_oAgent.idStructure)
        Dim structureCourante As Structuree
        structureCourante = StructureManager.getStructureById(m_oAgent.idStructure)
        Assert.AreEqual(oDiag.organismePresNumero, structureCourante.idCrodip)
        Assert.AreEqual(oDiag.organismePresNom, structureCourante.nom)
        Assert.AreEqual(oDiag.organismeInspNom, Globals.GLOB_DIAG_NOMAGR)
        Assert.AreEqual(oDiag.organismeInspAgrement, Globals.GLOB_DIAG_NUMAGR)
        Assert.AreEqual(oDiag.inspecteurId, m_oAgent.id)
        Assert.AreEqual(oDiag.inspecteurNom, m_oAgent.nom)
        Assert.AreEqual(oDiag.inspecteurPrenom, m_oAgent.prenom)

        Assert.AreEqual(oDiag.organismeOriginePresId, 0)
        Assert.AreEqual(oDiag.organismeOriginePresNumero, "")
        Assert.AreEqual(oDiag.organismeOriginePresNom, "")
        Assert.AreEqual(oDiag.organismeOrigineInspNom, "")
        Assert.AreEqual(oDiag.organismeOrigineInspAgrement, "")
        Assert.AreEqual(oDiag.inspecteurOrigineId, 0)
        Assert.AreEqual(oDiag.inspecteurOrigineNom, "")
        Assert.AreEqual(oDiag.inspecteurOriginePrenom, "")

        oDiag.duppliqueInfosOrganisme()

        Assert.AreEqual(oDiag.organismeOriginePresId, oDiag.organismePresId)
        Assert.AreEqual(oDiag.organismeOriginePresNumero, oDiag.organismePresNumero)
        Assert.AreEqual(oDiag.organismeOriginePresNom, oDiag.organismePresNom)
        Assert.AreEqual(oDiag.organismeOrigineInspNom, oDiag.organismeInspNom)
        Assert.AreEqual(oDiag.organismeOrigineInspAgrement, oDiag.organismeInspAgrement)
        Assert.AreEqual(oDiag.inspecteurOrigineId, oDiag.inspecteurId)
        Assert.AreEqual(oDiag.inspecteurOrigineNom, oDiag.inspecteurNom)
        Assert.AreEqual(oDiag.inspecteurOriginePrenom, oDiag.inspecteurPrenom)


        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        'Controle de l'organisme d'origine
        Assert.AreEqual(oDiag2.organismeOriginePresId, oDiag.organismeOriginePresId)
        Assert.AreEqual(oDiag2.organismeOriginePresNumero, oDiag.organismeOriginePresNumero)
        Assert.AreEqual(oDiag2.organismeOriginePresNom, oDiag.organismeOriginePresNom)
        Assert.AreEqual(oDiag2.organismeOrigineInspNom, oDiag.organismeOrigineInspNom)
        Assert.AreEqual(oDiag2.organismeOrigineInspAgrement, oDiag.organismeOrigineInspAgrement)
        Assert.AreEqual(oDiag2.inspecteurOrigineId, oDiag.inspecteurOrigineId)
        Assert.AreEqual(oDiag2.inspecteurOrigineNom, oDiag.inspecteurOrigineNom)
        Assert.AreEqual(oDiag2.inspecteurOriginePrenom, oDiag.inspecteurOriginePrenom)
        'Controle de l'organisme courant
        Assert.AreEqual(oDiag2.organismePresId, oDiag.organismePresId)
        Assert.AreEqual(oDiag2.organismePresNumero, oDiag.organismePresNumero)
        Assert.AreEqual(oDiag2.organismePresNom, oDiag.organismePresNom)
        Assert.AreEqual(oDiag2.organismeInspNom, oDiag.organismeInspNom)
        Assert.AreEqual(oDiag2.organismeInspAgrement, oDiag.organismeInspAgrement)
        Assert.AreEqual(oDiag2.inspecteurId, oDiag.inspecteurId)
        Assert.AreEqual(oDiag2.inspecteurNom, oDiag.inspecteurNom)
        Assert.AreEqual(oDiag2.inspecteurPrenom, oDiag.inspecteurPrenom)



        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub


    <TestMethod()>
    Public Sub Get_Send_WS()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim UpdateInfo As Object

        oExploit = createExploitation()
        ExploitationManager.sendWSExploitation(oExploit, UpdateInfo)
        oPulve = createPulve(oExploit)
        PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdateInfo)
        Dim oExploitToPulve As ExploitationTOPulverisateur
        oExploitToPulve = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oExploit.id, oPulve.id)
        ExploitationTOPulverisateurManager.sendWSExploitationTOPulverisateur(oExploitToPulve, UpdateInfo)

        'Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)

        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today
        oDiag.pulverisateurEmplacementIdentification = "DERRIERE"
        oDiag.controleManoControleNumNational = "TEST"
        oDiag.controleNbreNiveaux = 2
        oDiag.controleNbreTroncons = 5
        oDiag.controleUseCalibrateur = True
        oDiag.controleBancMesureId = "IDBANC"

        'Ajout des Buses et Buses Détail 
        '=================================
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "1"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "1,1"
        oDiagBuses.debitNominal = "1,2"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "DBEcartTolere1"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1,6"
        oDiagBusesDetail.ecart = "0,6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1,7"
        oDiagBusesDetail.ecart = "0,7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque2"
        oDiagBuses.nombre = "2"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "2,1"
        oDiagBuses.debitNominal = "2,2"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "DBEcartTolere2"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2,6"
        oDiagBusesDetail.ecart = "0,6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2,7"
        oDiagBusesDetail.ecart = "0,7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        'Ajout des Mano542
        '===================
        Dim oDiagMano542 As DiagnosticMano542

        'Mano1
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "1,6"
        oDiagMano542.pressionPulve = "1,7"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano2
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "2"
        oDiagMano542.pressionPulve = "2,1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano3
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "3"
        oDiagMano542.pressionPulve = "3.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)


        'Ajout des Tronçons 833
        '======================
        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "1,6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "1,7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "2,6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "2,7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "3.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "4.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "4.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Ajout des DiagItems
        '======================
        Dim oDiagItem As DiagnosticItem
        ''Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item2
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "222"
        oDiagItem.itemValue = "2"
        oDiagItem.itemCodeEtat = "P"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item3
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "333"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = "O"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item4
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "444"
        oDiagItem.itemValue = "4"
        oDiagItem.itemCodeEtat = "P"


        oDiagItem.cause = "3"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'SAuvegarde du Diag
        '====================
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id
        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        'Synchronisation Ascendante du Diag
        '========================
        Dim oSynchro As New Synchronisation(m_oAgent)
        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        'Synchronisation descendate du Diag
        '==================================
        'On simule une MAJ sur ler Server
        'oDiag.dateModificationCrodip = CSDate.GetDateForWS(Now())
        'Dim UpdateInfo As Object
        'DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag, UpdateInfo)


        'Suppression du diag par sécurité 
        DiagnosticManager.delete(oDiag.id)

        'on Simule la date de dernière synchro de l'agent à -1 munites
        '======================================
        m_oAgent.dateDerniereSynchro = CSDate.GetDateForWS(CDate(oDiag.dateModificationAgent).AddMinutes(-10))
        Dim obj As Object
        AgentManager.sendWSAgent(m_oAgent, obj)


        'Synchronisation descendate du Diag
        '==================================
        Dim oLstSynchro As List(Of SynchronisationElmt)
        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        Assert.AreNotEqual(0, oLstSynchro.Count)

        For Each oSynchroElmt In oLstSynchro
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

        Assert.AreEqual(2, oDiag2.diagnosticBusesList.Liste.Count)
        oDiagBuses = oDiag2.diagnosticBusesList.Liste(0)
        Assert.AreEqual(oDiagBuses.marque, "DBMarque1")
        Assert.AreEqual(oDiagBuses.nombre, "1")
        Assert.AreEqual(oDiagBuses.genre, "DBGenre1")
        Assert.AreEqual(oDiagBuses.calibre, "DBCalibre1")
        Assert.AreEqual(oDiagBuses.couleur, "DBCouleur1")
        Assert.AreEqual(oDiagBuses.debitMoyen, "1,1")
        Assert.AreEqual(oDiagBuses.debitNominal, "1,2")
        Assert.AreEqual(oDiagBuses.idLot, "1")
        Assert.AreEqual(oDiagBuses.ecartTolere, "DBEcartTolere1")
        'Vérification du détail des buses
        Assert.AreEqual(2, oDiagBuses.diagnosticBusesDetailList.Liste.Count)
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBusesDetail.debit, "1,6")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0,6")
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBusesDetail.debit, "1,7")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0,7")

        oDiagBuses = oDiag2.diagnosticBusesList.Liste(1)
        Assert.AreEqual(oDiagBuses.marque, "DBMarque2")
        Assert.AreEqual(oDiagBuses.nombre, "2")
        Assert.AreEqual(oDiagBuses.genre, "DBGenre2")
        Assert.AreEqual(oDiagBuses.calibre, "DBCalibre2")
        Assert.AreEqual(oDiagBuses.couleur, "DBCouleur2")
        Assert.AreEqual(oDiagBuses.debitMoyen, "2,1")
        Assert.AreEqual(oDiagBuses.debitNominal, "2,2")
        Assert.AreEqual(oDiagBuses.idLot, "2")
        Assert.AreEqual(oDiagBuses.ecartTolere, "DBEcartTolere2")
        'Vérification du détail des buses
        Assert.AreEqual(2, oDiagBuses.diagnosticBusesDetailList.Liste.Count)
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBusesDetail.debit, "2,6")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0,6")
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBusesDetail.debit, "2,7")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0,7")

        'Vérification des Mano542
        Assert.AreEqual(4, oDiag2.diagnosticMano542List.Liste.Count)
        oDiagMano542 = oDiag.diagnosticMano542List.Liste(0)
        Assert.IsTrue(oDiagMano542.pressionControle = "1,6")
        Assert.IsTrue(oDiagMano542.pressionPulve = "1,7")

        oDiagMano542 = oDiag2.diagnosticMano542List.Liste(1)
        Assert.IsTrue(oDiagMano542.pressionControle = "2")
        Assert.IsTrue(oDiagMano542.pressionPulve = "2,1")

        oDiagMano542 = oDiag2.diagnosticMano542List.Liste(2)
        Assert.IsTrue(oDiagMano542.pressionControle = "3")
        Assert.IsTrue(oDiagMano542.pressionPulve = "3.1")

        oDiagMano542 = oDiag2.diagnosticMano542List.Liste(3)
        Assert.IsTrue(oDiagMano542.pressionControle = "4")
        Assert.IsTrue(oDiagMano542.pressionPulve = "4.1")


        'Vérification des Troncons833

        Assert.AreEqual(8, oDiag2.diagnosticTroncons833.Liste.Count)
        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(0)
        Assert.IsTrue(oDiagTroncons833.idPression = 1)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1,6")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(1)
        Assert.IsTrue(oDiagTroncons833.idPression = 1)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1,7")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(2)
        Assert.IsTrue(oDiagTroncons833.idPression = 2)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2,6")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(3)
        Assert.IsTrue(oDiagTroncons833.idPression = 2)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2,7")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(4)
        Assert.IsTrue(oDiagTroncons833.idPression = 3)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.6")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(5)
        Assert.IsTrue(oDiagTroncons833.idPression = 3)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.7")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(6)
        Assert.IsTrue(oDiagTroncons833.idPression = 4)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.6")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(7)
        Assert.IsTrue(oDiagTroncons833.idPression = 4)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.7")

        'Vérification des DiagItems
        Assert.AreEqual(4, oDiag2.diagnosticItemsLst.Count)
        oDiagItem = oDiag2.diagnosticItemsLst.Values(0)
        'Item1
        Assert.IsTrue(oDiagItem.idItem = "111")
        Assert.IsTrue(oDiagItem.itemValue = "1")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "B")
        Assert.IsTrue(oDiagItem.cause = "1")


        'Item2
        oDiagItem = oDiag2.diagnosticItemsLst.Values(1)
        Assert.IsTrue(oDiagItem.idItem = "222")
        Assert.IsTrue(oDiagItem.itemValue = "2")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "P")

        Assert.IsTrue(oDiagItem.cause = "2")

        'Item3
        oDiagItem = oDiag2.diagnosticItemsLst.Values(2)
        Assert.IsTrue(oDiagItem.idItem = "333")
        Assert.IsTrue(oDiagItem.itemValue = "3")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "O")

        Assert.IsTrue(oDiagItem.cause = "2")

        'Item4
        oDiagItem = oDiag2.diagnosticItemsLst.Values(3)
        Assert.IsTrue(oDiagItem.idItem = "444")
        Assert.IsTrue(oDiagItem.itemValue = "4")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "P")


        Assert.IsTrue(oDiagItem.cause = "3")

        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub


    '''<summary>
    '''Test pour pour les propeties Lot3
    '''ControleBancMesureId ,controleUseCalibrateur ,controleNbreNiveaux ,controleNbreTroncons ,controleManoControleNumNational 
    '''</summary>
    <TestMethod()> _
    Public Sub TST_PropertiesLot3()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String

        oDiag = New Diagnostic()
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.id = id
        oDiag.controleNomSite = "MonSite"


        'V2.5.3
        oDiag.controleBancMesureId = "1001"
        Assert.AreEqual("1001", oDiag.controleBancMesureId)
        oDiag.controleNbreNiveaux = 1
        Assert.AreEqual(1, oDiag.controleNbreNiveaux)
        oDiag.controleNbreTroncons = 4
        Assert.AreEqual(4, oDiag.controleNbreTroncons)
        oDiag.controleUseCalibrateur = True
        Assert.AreEqual(True, oDiag.controleUseCalibrateur)
        oDiag.controleManoControleNumNational = "TEST"
        Assert.AreEqual("TEST", oDiag.controleManoControleNumNational)

        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(oDiag.id, oDiag2.id)

        Assert.AreEqual("1001", oDiag2.controleBancMesureId)
        Assert.AreEqual(1, oDiag2.controleNbreNiveaux)
        Assert.AreEqual(4, oDiag2.controleNbreTroncons)
        Assert.AreEqual(True, oDiag2.controleUseCalibrateur)
        Assert.AreEqual("TEST", oDiag2.controleManoControleNumNational)

        oDiag2.controleBancMesureId = "1003"
        oDiag2.controleNbreNiveaux = 2
        oDiag2.controleNbreTroncons = 5
        oDiag2.controleUseCalibrateur = False
        oDiag2.controleManoControleNumNational = "TEST2"

        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)


        Assert.AreEqual("1003", oDiag.controleBancMesureId)
        Assert.AreEqual(2, oDiag.controleNbreNiveaux)
        Assert.AreEqual(5, oDiag.controleNbreTroncons)
        Assert.AreEqual(False, oDiag.controleUseCalibrateur)
        Assert.AreEqual("TEST2", oDiag.controleManoControleNumNational)


        bReturn = DiagnosticManager.delete(id)
        Assert.IsTrue(bReturn)



    End Sub
    '''<summary>
    '''Test pour pour les properties Version4 Lot1b
    '''ControleInitialId
    ''' PulverisateurAncienId
    '''</summary>
    <TestMethod()> _
    Public Sub TST_PropertiesV4L1b()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String

        oDiag = New Diagnostic()
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.id = id
        oDiag.controleNomSite = "MonSite"


        'V2.5.3
        oDiag.controleInitialId = "1001"
        oDiag.pulverisateurAncienId = "E001-1"
        Assert.AreEqual("1001", oDiag.controleInitialId)
        Assert.AreEqual("E001-1", oDiag.pulverisateurAncienId)
        CSDebug.dispInfo("Avant le save")
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)
        CSDebug.dispInfo("Apres le save")

        oDiag2 = New Diagnostic()
        CSDebug.dispInfo("Avant le Load")
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        CSDebug.dispInfo("Apres le Load")
        Assert.AreEqual(oDiag.id, oDiag2.id)

        Assert.AreEqual("1001", oDiag2.controleInitialId)
        Assert.AreEqual("E001-1", oDiag2.pulverisateurAncienId)

        oDiag2.controleInitialId = "1002"
        oDiag2.pulverisateurAncienId = "E001-2"
        CSDebug.dispInfo("Avant le update")
        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        CSDebug.dispInfo("Apres le update")


        Assert.AreEqual("1002", oDiag.controleInitialId)
        Assert.AreEqual("E001-2", oDiag.pulverisateurAncienId)


        Dim UpdatedObject As Object
        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)
        Assert.AreEqual("1002", oDiag2.controleInitialId)
        Assert.AreEqual("E001-2", oDiag.pulverisateurAncienId)
        CSDebug.dispInfo(oDiag.dateModificationAgent)

        pause(2000)
        oDiag2.controleInitialId = "1003"
        oDiag2.pulverisateurAncienId = "E001-3"
        oDiag2.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
        DiagnosticManager.save(oDiag2)
        oDiag2 = DiagnosticManager.getDiagnosticById(oDiag2.id)
        CSDebug.dispInfo(oDiag.dateModificationAgent)

        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag2, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)
        Assert.AreEqual("1003", oDiag2.controleInitialId)
        Assert.AreEqual("E001-3", oDiag2.pulverisateurAncienId)


        CSDebug.dispInfo("Avant le Delete")

        bReturn = DiagnosticManager.delete(id)
        Assert.IsTrue(bReturn)
        CSDebug.dispInfo("apres le Delete")



    End Sub

    <TestMethod()> _
    Public Sub TST_GetWSIncrement()
        Dim oDiag As Diagnostic
        Dim curIncrement As String
        DiagnosticManager.getWSDiagnosticIncrement(m_oAgent, curIncrement)
        Assert.IsNotNull(curIncrement)

        Dim nOriginalId As Integer = m_oAgent.id
        'Test avec l'agent 1
        m_oAgent.id = 1
        DiagnosticManager.getWSDiagnosticIncrement(m_oAgent, curIncrement)
        Assert.IsNotNull(curIncrement)
        'Test avec un agent inexistant
        m_oAgent.id = 999
        DiagnosticManager.getWSDiagnosticIncrement(m_oAgent, curIncrement)
        Assert.IsNotNull(curIncrement)

        m_oAgent.id = nOriginalId


    End Sub

    <TestMethod()> _
    Public Sub TST_SaveDiagnosticBuses()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "DBNombre1"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "1,1"
        oDiagBuses.debitNominal = "1,2"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "0.1"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque2"
        oDiagBuses.nombre = "DBNombre2"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "2,1"
        oDiagBuses.debitNominal = "2,2"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "0,2"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)
        Assert.AreEqual(2, oDiag.diagnosticBusesList.Liste.Count)
        oDiagBuses = oDiag.diagnosticBusesList.Liste(0)
        Assert.AreEqual(oDiagBuses.marque, "DBMarque1")
        Assert.AreEqual(oDiagBuses.nombre, "DBNombre1")
        Assert.AreEqual(oDiagBuses.genre, "DBGenre1")
        Assert.AreEqual(oDiagBuses.calibre, "DBCalibre1")
        Assert.AreEqual(oDiagBuses.couleur, "DBCouleur1")
        Assert.AreEqual(oDiagBuses.debitMoyen, "1,1")
        Assert.AreEqual(oDiagBuses.debitNominal, "1,2")
        Assert.AreEqual(oDiagBuses.idLot, "1")
        Assert.AreEqual(oDiagBuses.ecartTolere, "0.1")
        'Vérification du détail des buses
        Assert.AreEqual(2, oDiagBuses.diagnosticBusesDetailList.Liste.Count)
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBusesDetail.debit, "1.6")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.6")
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBusesDetail.debit, "1.7")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.7")

        oDiagBuses = oDiag.diagnosticBusesList.Liste(1)
        Assert.AreEqual(oDiagBuses.marque, "DBMarque2")
        Assert.AreEqual(oDiagBuses.nombre, "DBNombre2")
        Assert.AreEqual(oDiagBuses.genre, "DBGenre2")
        Assert.AreEqual(oDiagBuses.calibre, "DBCalibre2")
        Assert.AreEqual(oDiagBuses.couleur, "DBCouleur2")
        Assert.AreEqual(oDiagBuses.debitMoyen, "2,1")
        Assert.AreEqual(oDiagBuses.debitNominal, "2,2")
        Assert.AreEqual(oDiagBuses.idLot, "2")
        Assert.AreEqual(oDiagBuses.ecartTolere, "0,2")
        'Vérification du détail des buses
        Assert.AreEqual(2, oDiagBuses.diagnosticBusesDetailList.Liste.Count)
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBusesDetail.debit, "2.6")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.6")
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBusesDetail.debit, "2.7")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.7")

        DiagnosticManager.delete(oDiag.id)
    End Sub
    <TestMethod()> _
    Public Sub TST_SaveDiagnosticMano542()
        Dim oDiag As Diagnostic
        Dim oDiagMano542 As DiagnosticMano542
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        'Mano1
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "1.6"
        oDiagMano542.pressionPulve = "1.7"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano2
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "2"
        oDiagMano542.pressionPulve = "2.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano3
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "3"
        oDiagMano542.pressionPulve = "3.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)


        DiagnosticManager.save(oDiag)

        'Rechargement du diag
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Assert.AreEqual(4, oDiag.diagnosticMano542List.Liste.Count)
        oDiagMano542 = oDiag.diagnosticMano542List.Liste(0)
        Assert.IsTrue(oDiagMano542.pressionControle = "1.6")
        Assert.IsTrue(oDiagMano542.pressionPulve = "1.7")

        oDiagMano542 = oDiag.diagnosticMano542List.Liste(1)
        Assert.IsTrue(oDiagMano542.pressionControle = "2")
        Assert.IsTrue(oDiagMano542.pressionPulve = "2.1")

        oDiagMano542 = oDiag.diagnosticMano542List.Liste(2)
        Assert.IsTrue(oDiagMano542.pressionControle = "3")
        Assert.IsTrue(oDiagMano542.pressionPulve = "3.1")

        oDiagMano542 = oDiag.diagnosticMano542List.Liste(3)
        Assert.IsTrue(oDiagMano542.pressionControle = "4")
        Assert.IsTrue(oDiagMano542.pressionPulve = "4.1")

        DiagnosticManager.delete(oDiag.id)

    End Sub
    <TestMethod()> _
    Public Sub TST_SaveDiagnosticTroncons833()
        Dim oDiag As Diagnostic
        Dim oDiagTroncons833 As DiagnosticTroncons833
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "1.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "1.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "2.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "2.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "3.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "4.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "4.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        DiagnosticManager.save(oDiag)

        'Rechargement du diag
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Assert.AreEqual(8, oDiag.diagnosticTroncons833.Liste.Count)
        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(0)
        Assert.IsTrue(oDiagTroncons833.idPression = 1)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1.6")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(1)
        Assert.IsTrue(oDiagTroncons833.idPression = 1)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1.7")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(2)
        Assert.IsTrue(oDiagTroncons833.idPression = 2)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2.6")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(3)
        Assert.IsTrue(oDiagTroncons833.idPression = 2)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2.7")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(4)
        Assert.IsTrue(oDiagTroncons833.idPression = 3)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.6")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(5)
        Assert.IsTrue(oDiagTroncons833.idPression = 3)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.7")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(6)
        Assert.IsTrue(oDiagTroncons833.idPression = 4)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.6")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(7)
        Assert.IsTrue(oDiagTroncons833.idPression = 4)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.7")
        DiagnosticManager.delete(oDiag.id)

    End Sub

    <TestMethod()> _
    Public Sub TST_SaveDiagnosticItem()
        Dim oDiag As Diagnostic
        Dim oDiagItem As DiagnosticItem
        Dim idDiag As String
        ''Dim oLst As New List(Of DiagnosticItem)
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        oDiag.setOrganisme(m_oAgent)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"

        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item2
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "222"
        oDiagItem.itemValue = "2"
        oDiagItem.itemCodeEtat = "P"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item3
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "333"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = "O"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item4
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "444"
        oDiagItem.itemValue = "4"
        oDiagItem.itemCodeEtat = "P"


        oDiag.AdOrReplaceDiagItem(oDiagItem)

        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        'Rechargement du diag
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Assert.AreEqual(4, oDiag.diagnosticItemsLst.Count)
        oDiagItem = oDiag.diagnosticItemsLst.Values(0)
        'Item1
        Assert.IsTrue(oDiagItem.idItem = "111")
        Assert.IsTrue(oDiagItem.itemValue = "1")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "B")
        Assert.IsTrue(oDiagItem.cause = "1")


        'Item2
        oDiagItem = oDiag.diagnosticItemsLst.Values(1)
        Assert.IsTrue(oDiagItem.idItem = "222")
        Assert.IsTrue(oDiagItem.itemValue = "2")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "P")

        Assert.IsTrue(oDiagItem.cause = "2")

        'Item3
        oDiagItem = oDiag.diagnosticItemsLst.Values(2)
        Assert.IsTrue(oDiagItem.idItem = "333")
        Assert.IsTrue(oDiagItem.itemValue = "3")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "O")

        Assert.IsTrue(oDiagItem.cause = "2")

        'Item4
        oDiagItem = oDiag.diagnosticItemsLst.Values(3)
        Assert.IsTrue(oDiagItem.idItem = "444")
        Assert.IsTrue(oDiagItem.itemValue = "4")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "P")




        DiagnosticManager.delete(oDiag.id)

    End Sub

    ''' <summary>
    ''' Ce test vérifie la sauvegarde de tous les SubItems du diagnostic
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub TST_SaveDiagnosticAll()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        Dim oExploit As Exploitation = createExploitation()
        ExploitationManager.save(oExploit, m_oAgent)
        Dim oPulve As Pulverisateur = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        'Creation d'un Diagnostic
        oDiag = createDiagnostic(oExploit, oPulve)
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.diagnosticBusesList.Liste.Clear()
        oDiag.diagnosticMano542List.Liste.Clear()
        oDiag.diagnosticTroncons833.Liste.Clear()
        'Lot1
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "Lot1"
        oDiagBuses.nombre = "2"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "1.1"
        oDiagBuses.debitNominal = "1.2"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "1.3"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        'Lot2
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "Lot2"
        oDiagBuses.nombre = "2"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "2.1"
        oDiagBuses.debitNominal = "2.2"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "2.3"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)


        Dim oDiagMano542 As DiagnosticMano542

        'Mano1
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "1.6"
        oDiagMano542.pressionPulve = "1.7"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano2
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "2"
        oDiagMano542.pressionPulve = "2.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano3
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "3"
        oDiagMano542.pressionPulve = "3.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)



        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "1.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "1.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "2.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "2.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "3.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "4.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "4.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)


        Dim oDiagItem As DiagnosticItem
        ''Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"

        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item2
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "222"
        oDiagItem.itemValue = "2"
        oDiagItem.itemCodeEtat = "P"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item3
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "333"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = "O"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item4
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "444"
        oDiagItem.itemValue = "4"
        oDiagItem.itemCodeEtat = "P"


        oDiag.AdOrReplaceDiagItem(oDiagItem)

        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        'Vérification des Buses

        Assert.AreEqual(2, oDiag.diagnosticBusesList.Liste.Count)
        oDiagBuses = oDiag.diagnosticBusesList.Liste(0)
        Assert.AreEqual(oDiagBuses.marque, "Lot1")
        Assert.AreEqual(oDiagBuses.nombre, "2")
        Assert.AreEqual(oDiagBuses.genre, "DBGenre1")
        Assert.AreEqual(oDiagBuses.calibre, "DBCalibre1")
        Assert.AreEqual(oDiagBuses.couleur, "DBCouleur1")
        Assert.AreEqual(oDiagBuses.debitMoyen, "1,1")
        Assert.AreEqual(oDiagBuses.debitNominal, "1,2")
        Assert.AreEqual(oDiagBuses.idLot, "1")
        Assert.AreEqual(oDiagBuses.ecartTolere, "1.3")
        'Vérification du détail des buses
        Assert.AreEqual(2, oDiagBuses.diagnosticBusesDetailList.Liste.Count)
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBusesDetail.debit, "1.6")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.6")
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBusesDetail.debit, "1.7")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.7")

        oDiagBuses = oDiag.diagnosticBusesList.Liste(1)
        Assert.AreEqual(oDiagBuses.marque, "Lot2")
        Assert.AreEqual(oDiagBuses.nombre, "2")
        Assert.AreEqual(oDiagBuses.genre, "DBGenre2")
        Assert.AreEqual(oDiagBuses.calibre, "DBCalibre2")
        Assert.AreEqual(oDiagBuses.couleur, "DBCouleur2")
        Assert.AreEqual(oDiagBuses.debitMoyen, "2,1")
        Assert.AreEqual(oDiagBuses.debitNominal, "2,2")
        Assert.AreEqual(oDiagBuses.idLot, "2")
        Assert.AreEqual(oDiagBuses.ecartTolere, "2.3")
        'Vérification du détail des buses
        Assert.AreEqual(2, oDiagBuses.diagnosticBusesDetailList.Liste.Count)
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBusesDetail.debit, "2.6")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.6")
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBusesDetail.debit, "2.7")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.7")

        'Vérification des Mano542
        Assert.AreEqual(4, oDiag.diagnosticMano542List.Liste.Count)
        oDiagMano542 = oDiag.diagnosticMano542List.Liste(0)
        Assert.IsTrue(oDiagMano542.pressionControle = "1.6")
        Assert.IsTrue(oDiagMano542.pressionPulve = "1.7")

        oDiagMano542 = oDiag.diagnosticMano542List.Liste(1)
        Assert.IsTrue(oDiagMano542.pressionControle = "2")
        Assert.IsTrue(oDiagMano542.pressionPulve = "2.1")

        oDiagMano542 = oDiag.diagnosticMano542List.Liste(2)
        Assert.IsTrue(oDiagMano542.pressionControle = "3")
        Assert.IsTrue(oDiagMano542.pressionPulve = "3.1")

        oDiagMano542 = oDiag.diagnosticMano542List.Liste(3)
        Assert.IsTrue(oDiagMano542.pressionControle = "4")
        Assert.IsTrue(oDiagMano542.pressionPulve = "4.1")


        'Vérification des Troncons833

        Assert.AreEqual(8, oDiag.diagnosticTroncons833.Liste.Count)
        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(0)
        Assert.IsTrue(oDiagTroncons833.idPression = 1)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1.6")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(1)
        Assert.IsTrue(oDiagTroncons833.idPression = 1)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1.7")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(2)
        Assert.IsTrue(oDiagTroncons833.idPression = 2)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2.6")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(3)
        Assert.IsTrue(oDiagTroncons833.idPression = 2)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2.7")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(4)
        Assert.IsTrue(oDiagTroncons833.idPression = 3)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.6")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(5)
        Assert.IsTrue(oDiagTroncons833.idPression = 3)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.7")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(6)
        Assert.IsTrue(oDiagTroncons833.idPression = 4)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.6")

        oDiagTroncons833 = oDiag.diagnosticTroncons833.Liste(7)
        Assert.IsTrue(oDiagTroncons833.idPression = 4)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.7")

        'Vérification des DiagItems
        Assert.AreEqual(4, oDiag.diagnosticItemsLst.Count)
        oDiagItem = oDiag.diagnosticItemsLst.Values(0)
        'Item1
        Assert.IsTrue(oDiagItem.idItem = "111")
        Assert.IsTrue(oDiagItem.itemValue = "1")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "B")
        Assert.IsTrue(oDiagItem.cause = "1")


        'Item2
        oDiagItem = oDiag.diagnosticItemsLst.Values(1)
        Assert.IsTrue(oDiagItem.idItem = "222")
        Assert.IsTrue(oDiagItem.itemValue = "2")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "P")

        Assert.IsTrue(oDiagItem.cause = "2")

        'Item3
        oDiagItem = oDiag.diagnosticItemsLst.Values(2)
        Assert.IsTrue(oDiagItem.idItem = "333")
        Assert.IsTrue(oDiagItem.itemValue = "3")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "O")

        Assert.IsTrue(oDiagItem.cause = "2")

        'Item4
        oDiagItem = oDiag.diagnosticItemsLst.Values(3)
        Assert.IsTrue(oDiagItem.idItem = "444")
        Assert.IsTrue(oDiagItem.itemValue = "4")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "P")



        DiagnosticManager.delete(oDiag.id)

    End Sub
    <TestMethod()> _
    Public Sub TST_SendDiagWSAll()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "DBNombre1"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "DBDebitMoyen1"
        oDiagBuses.debitNominal = "DBdebitNominal1"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "DBEcartTolere1"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque2"
        oDiagBuses.nombre = "DBNombre2"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "DBDebitMoyen2"
        oDiagBuses.debitNominal = "DBdebitNominal2"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "DBEcartTolere2"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)


        Dim oDiagMano542 As DiagnosticMano542

        'Mano1
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "1.6"
        oDiagMano542.pressionPulve = "1.7"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano2
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "2"
        oDiagMano542.pressionPulve = "2.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano3
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "3"
        oDiagMano542.pressionPulve = "3.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)



        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "1.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "1.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "2.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "2.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "3.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "4.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "4.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)


        Dim oDiagItem As DiagnosticItem
        ''Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"

        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item2
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "222"
        oDiagItem.itemValue = "2"
        oDiagItem.itemCodeEtat = "P"
        oDiagItem.cause = "1"
        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item3
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "333"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = "O"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item4
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "444"
        oDiagItem.itemValue = "4"
        oDiagItem.itemCodeEtat = "P"


        oDiag.AdOrReplaceDiagItem(oDiagItem)

        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Dim oSynchro As New Synchronisation(m_oAgent)

        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        DiagnosticManager.delete(oDiag.id)

    End Sub

    <TestMethod()> _
    Public Sub TST_SendDiagWSBuses()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "DBNombre1"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "DBDebitMoyen1"
        oDiagBuses.debitNominal = "DBdebitNominal1"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "DBEcartTolere1"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque2"
        oDiagBuses.nombre = "DBNombre2"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "DBDebitMoyen2"
        oDiagBuses.debitNominal = "DBdebitNominal2"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "DBEcartTolere2"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Dim oSynchro As New Synchronisation(m_oAgent)

        Dim nItems As Integer = oDiag.diagnosticBusesList.Liste.Count

        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))
        'Vérification que le nombre de buses est correct après synchroi car elle sont été supprimées avant la synchro
        Assert.AreEqual(nItems, oDiag.diagnosticBusesList.Liste.Count)
        DiagnosticManager.delete(oDiag.id)

    End Sub
    <TestMethod()> _
    Public Sub TST_SendDiagWSMano542()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)


        Dim oDiagMano542 As DiagnosticMano542

        'Mano1
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "1.6"
        oDiagMano542.pressionPulve = "1.7"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano2
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "2"
        oDiagMano542.pressionPulve = "2.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano3
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "3"
        oDiagMano542.pressionPulve = "3.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)




        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Dim oSynchro As New Synchronisation(m_oAgent)

        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        DiagnosticManager.delete(oDiag.id)

    End Sub
    <TestMethod()> _
    Public Sub TST_SendDiagWSTroncons833()
        Dim oDiag As Diagnostic
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)


        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "1.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "1.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "2.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "2.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "3.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "4.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "4.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)



        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Dim oSynchro As New Synchronisation(m_oAgent)

        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        DiagnosticManager.delete(oDiag.id)

    End Sub
    <TestMethod()> _
    Public Sub TST_SendDiagWSDiagItems()
        Dim oDiag As Diagnostic
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)


        Dim oDiagItem As DiagnosticItem
        ''Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"

        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item2
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "222"
        oDiagItem.itemValue = "2"
        oDiagItem.itemCodeEtat = "P"
        oDiagItem.cause = "1"
        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item3
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "333"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = "O"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item4
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "444"
        oDiagItem.itemValue = "4"
        oDiagItem.itemCodeEtat = "P"


        oDiag.AdOrReplaceDiagItem(oDiagItem)

        DiagnosticManager.save(oDiag)
        Dim nItems As Integer = oDiag.diagnosticItemsLst.Count

        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Dim oSynchro As New Synchronisation(m_oAgent)

        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        'Vérification qu'après la synchro le liste des diagItem soit toujours là
        'elle a été annulée pendant la synchro...

        Assert.IsNotNull(oDiag.diagnosticItemsLst)
        Assert.AreEqual(nItems, oDiag.diagnosticItemsLst.Count)
        DiagnosticManager.delete(oDiag.id)

    End Sub
    <TestMethod()> _
    Public Sub TST_SendDiagWS1DiagItem()
        Dim oDiag As Diagnostic
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)


        Dim oDiagItem As DiagnosticItem
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"

        oDiag.AdOrReplaceDiagItem(oDiagItem)


        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Dim oSynchro As New Synchronisation(m_oAgent)

        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        DiagnosticManager.delete(oDiag.id)

    End Sub

    <TestMethod()> _
    Public Sub TST_AddDiagItem()

        Dim oDiag As New Diagnostic()
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        Dim oDiagItem As DiagnosticItem

        '''
        'Assert.AreEqual(1, oDiag.diagnosticItemsLst.Count)
        Assert.AreEqual(0, oDiag.diagnosticItemsLst.Count)

        oDiagItem = New DiagnosticItem(oDiag.id, "252", "3", "2", "B")
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        '        Assert.AreEqual(2, oDiag.diagnosticItemsLst.Count)
        Assert.AreEqual(1, oDiag.diagnosticItemsLst.Count)

        oDiagItem = oDiag.diagnosticItemsLst.Values(0)
        Assert.AreEqual(oDiag.id, oDiagItem.idDiagnostic)
        Assert.AreEqual("252", oDiagItem.idItem)
        Assert.AreEqual("3", oDiagItem.itemValue)
        Assert.AreEqual("2", oDiagItem.cause)
        Assert.AreEqual("B", oDiagItem.itemCodeEtat)

        oDiagItem = New DiagnosticItem(oDiag.id, "252", "4")
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        '        Assert.AreEqual(3, oDiag.diagnosticItemsLst.Count)
        Assert.AreEqual(2, oDiag.diagnosticItemsLst.Count)

        oDiagItem = oDiag.diagnosticItemsLst.Values(1)
        Assert.AreEqual(oDiag.id, oDiagItem.idDiagnostic)
        Assert.AreEqual("252", oDiagItem.idItem)
        Assert.AreEqual("4", oDiagItem.itemValue)
        Assert.AreEqual("", oDiagItem.cause)
        Assert.AreEqual("", oDiagItem.itemCodeEtat)

        oDiagItem = New DiagnosticItem(oDiag.id, "252", "4", "2", "P")
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        '        Assert.AreEqual(4, oDiag.diagnosticItemsLst.Count)
        Assert.AreEqual(2, oDiag.diagnosticItemsLst.Count)

        oDiagItem = oDiag.diagnosticItemsLst.Values(1)
        Assert.AreEqual(oDiag.id, oDiagItem.idDiagnostic)
        Assert.AreEqual("252", oDiagItem.idItem)
        Assert.AreEqual("4", oDiagItem.itemValue)
        Assert.AreEqual("2", oDiagItem.cause)
        Assert.AreEqual("P", oDiagItem.itemCodeEtat)
    End Sub

    '<TestMethod()> _
    'Public Sub TST_CreateDiagItem()
    '    Dim oDiag As Diagnostic
    '    Dim oDiagItem As DiagnosticItem

    '    oDiag = New Diagnostic()
    '    oDiag.pulverisateurAttelage = Pulverisateur.ATTELAGE_PORTE
    '    oDiag.pulverisateurIsVentilateur = True
    '    oDiag.pulverisateurIsCuveIncorporation = True
    '    oDiag.pulverisateurRegulationIsPressionConstante = False
    '    oDiag.pulverisateurRegulationIsDpm = False
    '    oDiag.pulverisateurRegulationIsDpa = False
    '    oDiag.pulverisateurRegulationIsDpae = False
    '    oDiag.CreateDiagnosticItems()
    '    Assert.AreEqual(2, oDiag.diagnosticItemsLst.Count)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(0)
    '    Assert.AreEqual("251", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(1)
    '    Assert.AreEqual("252", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)

    '    'Presence de ventilateur
    '    oDiag = New Diagnostic()
    '    oDiag.pulverisateurAttelage = Pulverisateur.ATTELAGE_TRAINE
    '    oDiag.pulverisateurIsVentilateur = False
    '    oDiag.pulverisateurIsCuveIncorporation = True
    '    oDiag.pulverisateurRegulationIsPressionConstante = False
    '    oDiag.pulverisateurRegulationIsDpm = False
    '    oDiag.pulverisateurRegulationIsDpa = False
    '    oDiag.pulverisateurRegulationIsDpae = False
    '    oDiag.CreateDiagnosticItems()
    '    Assert.AreEqual(4, oDiag.diagnosticItemsLst.Count)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(0)
    '    Assert.AreEqual("1011", oDiagItem.idItem)
    '    Assert.AreEqual("8", oDiagItem.itemValue)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(1)
    '    Assert.AreEqual("1012", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(2)
    '    Assert.AreEqual("1021", oDiagItem.idItem)
    '    Assert.AreEqual("4", oDiagItem.itemValue)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(3)
    '    Assert.AreEqual("1022", oDiagItem.idItem)
    '    Assert.AreEqual("4", oDiagItem.itemValue)

    '    'Cuve d'incorporation non coché
    '    oDiag = New Diagnostic()
    '    oDiag.pulverisateurAttelage = Pulverisateur.ATTELAGE_TRAINE
    '    oDiag.pulverisateurIsVentilateur = True
    '    oDiag.pulverisateurIsCuveIncorporation = False
    '    oDiag.pulverisateurRegulationIsPressionConstante = False
    '    oDiag.pulverisateurRegulationIsDpm = False
    '    oDiag.pulverisateurRegulationIsDpa = False
    '    oDiag.pulverisateurRegulationIsDpae = False
    '    oDiag.CreateDiagnosticItems()
    '    Assert.AreEqual(1, oDiag.diagnosticItemsLst.Count)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(0)
    '    Assert.AreEqual("431", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)

    '    'Presence de Regulation PC
    '    oDiag = New Diagnostic()
    '    oDiag.pulverisateurAttelage = Pulverisateur.ATTELAGE_TRAINE
    '    oDiag.pulverisateurIsVentilateur = True
    '    oDiag.pulverisateurIsCuveIncorporation = True
    '    oDiag.pulverisateurRegulationIsPressionConstante = True
    '    oDiag.pulverisateurRegulationIsDpm = False
    '    oDiag.pulverisateurRegulationIsDpa = False
    '    oDiag.pulverisateurRegulationIsDpae = False
    '    oDiag.CreateDiagnosticItems()
    '    Assert.AreEqual(2, oDiag.diagnosticItemsLst.Count)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(0)
    '    Assert.AreEqual("551", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(1)
    '    Assert.AreEqual("552", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)

    '    'Presence de Regulation DPM
    '    oDiag = New Diagnostic()
    '    oDiag.pulverisateurAttelage = Pulverisateur.ATTELAGE_TRAINE
    '    oDiag.pulverisateurIsVentilateur = True
    '    oDiag.pulverisateurIsCuveIncorporation = True
    '    oDiag.pulverisateurRegulationIsPressionConstante = False
    '    oDiag.pulverisateurRegulationIsDpm = True
    '    oDiag.pulverisateurRegulationIsDpa = False
    '    oDiag.pulverisateurRegulationIsDpae = False
    '    oDiag.CreateDiagnosticItems()
    '    Assert.AreEqual(2, oDiag.diagnosticItemsLst.Count)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(0)
    '    Assert.AreEqual("551", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(1)
    '    Assert.AreEqual("552", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)

    '    'Presence de Regulation DPAM
    '    oDiag = New Diagnostic()
    '    oDiag.pulverisateurAttelage = Pulverisateur.ATTELAGE_TRAINE
    '    oDiag.pulverisateurIsVentilateur = True
    '    oDiag.pulverisateurIsCuveIncorporation = True
    '    oDiag.pulverisateurRegulationIsPressionConstante = False
    '    oDiag.pulverisateurRegulationIsDpm = False
    '    oDiag.pulverisateurRegulationIsDpa = True
    '    oDiag.pulverisateurRegulationIsDpae = False
    '    oDiag.CreateDiagnosticItems()
    '    Assert.AreEqual(2, oDiag.diagnosticItemsLst.Count)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(0)
    '    Assert.AreEqual("551", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(1)
    '    Assert.AreEqual("552", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)

    '    'Presence de Regulation DPAE
    '    oDiag = New Diagnostic()
    '    oDiag.pulverisateurAttelage = Pulverisateur.ATTELAGE_TRAINE
    '    oDiag.pulverisateurIsVentilateur = True
    '    oDiag.pulverisateurIsCuveIncorporation = True
    '    oDiag.pulverisateurRegulationIsPressionConstante = False
    '    oDiag.pulverisateurRegulationIsDpm = False
    '    oDiag.pulverisateurRegulationIsDpa = False
    '    oDiag.pulverisateurRegulationIsDpae = True
    '    oDiag.CreateDiagnosticItems()
    '    Assert.AreEqual(1, oDiag.diagnosticItemsLst.Count)
    '    oDiagItem = oDiag.diagnosticItemsLst.Values(0)
    '    Assert.AreEqual("562", oDiagItem.idItem)
    '    Assert.AreEqual("3", oDiagItem.itemValue)

    'End Sub
    'Test la fonctionnalité de génération de l'état de synthèse
    'Première phase : Génération de du dataset
    <TestMethod()> _
    Public Sub TST_CreateEtatsynthes_Buse()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        'I - Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)
        oDiag.controleDateDebut = Date.Now()
        oDiag.controleDateFin = DateAdd(DateInterval.Hour, +1, Date.Now())
        oDiag.manometrePressionTravail = "3"
        'I.1   2 Lots de buses 
        '-----------------------
        'Lot1
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "2"
        oDiagBuses.nombrebusesusees = "1"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "13,5"
        oDiagBuses.debitNominal = "10,2"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "10"
        oDiagBuses.debitMin = "15,5"
        oDiagBuses.debitMax = "15,5"
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)

        'Ajout des Détails des buses du lot1
        'Detail 1 du lot1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.idBuse = 1
        oDiagBusesDetail.idLot = 1
        oDiagBusesDetail.debit = "1,6"
        oDiagBusesDetail.ecart = "0,6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail 2 du lot1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.idBuse = 2
        oDiagBusesDetail.idLot = 1
        oDiagBusesDetail.debit = "1,7"
        oDiagBusesDetail.ecart = "0,7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        'Lot2
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque2"
        oDiagBuses.nombre = "2"
        oDiagBuses.nombrebusesusees = "1"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "23,5"
        oDiagBuses.debitNominal = "20,2"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "15"
        oDiagBuses.debitMin = "25,5"
        oDiagBuses.debitMax = "25,5"
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)

        'Ajout des Détails des buses du lot2
        'Detail 1 du lot2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.idBuse = 1
        oDiagBusesDetail.idLot = 2
        oDiagBusesDetail.debit = "2,6"
        oDiagBusesDetail.ecart = "0,2"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail 2 du lot2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.idBuse = 2
        oDiagBusesDetail.idLot = 2
        oDiagBusesDetail.debit = "5,7"
        oDiagBusesDetail.ecart = "2,7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        'Les DiagItems ne sont pas utilisés dans le rapport de synthese

        'II - génération du dataset
        '===========================
        Dim ods As ds_Etat_SM
        Dim oEtat As New EtatSyntheseMesures(oDiag)
        oEtat.GenereEtat()
        ods = DirectCast(oEtat.getDs(), ds_Etat_SM)

        'III- Vérification du dataset généré
        '====================================

        Assert.AreEqual(ods.debitBuses_infos.Rows.Count, 2) '2 Lots
        Dim oRowDBI As ds_Etat_SM.debitBuses_infosRow
        'oDiagBuses.marque = "DBMarque1"
        'oDiagBuses.nombre = "2"
        'oDiagBuses.nombrebusesusees = "1"
        'oDiagBuses.genre = "DBGenre1"
        'oDiagBuses.calibre = "DBCalibre1"
        'oDiagBuses.couleur = "DBCouleur1"
        'oDiagBuses.debitMoyen = "13,5"
        'oDiagBuses.debitNominal = "10,2"
        'oDiagBuses.idLot = "1"
        'oDiagBuses.ecartTolere = "10"
        'oDiagBuses.debitMin = "15,5"
        'oDiagBuses.debitMax = "15,5"

        oRowDBI = ods.debitBuses_infos.Rows(0)
        Assert.AreEqual(oRowDBI.IdLot, 1)
        Assert.AreEqual(oRowDBI.debitNominal, "10,2")
        Assert.AreEqual(oRowDBI.pressionControle, "3")
        Assert.AreEqual(oRowDBI.debitMoyen, "13,5")
        Assert.AreEqual(oRowDBI.DebitMin, "15,5")
        Assert.AreEqual(oRowDBI.DebitMax, "15,5")
        Assert.AreEqual(oRowDBI.ecartTolere, "10")
        Assert.AreEqual(oRowDBI.nombreBuses, "2")
        Assert.AreEqual(oRowDBI.nombreBusesUsees, "1")
        Assert.AreEqual(oRowDBI.marque, "DBMarque1")
        'Assert.AreEqual(oRowDBI.type, "DBGenre1")

        'oDiagBuses.marque = "DBMarque2"
        'oDiagBuses.nombre = "2"
        'oDiagBuses.nombrebusesusees = "1"
        'oDiagBuses.genre = "DBGenre1"
        'oDiagBuses.calibre = "DBCalibre2"
        'oDiagBuses.couleur = "DBCouleur2"
        'oDiagBuses.debitMoyen = "23,5"
        'oDiagBuses.debitNominal = "20,2"
        'oDiagBuses.idLot = "2"
        'oDiagBuses.ecartTolere = "15"
        'oDiagBuses.debitMin = "25,5"
        'oDiagBuses.debitMax = "25,5"
        'oDiag.manometrePressionTravail = "99,1" => Pression de controle ?

        oRowDBI = ods.debitBuses_infos.Rows(1)
        Assert.AreEqual(oRowDBI.IdLot, 2)
        Assert.AreEqual(oRowDBI.debitNominal, "20,2")
        Assert.AreEqual(oRowDBI.pressionControle, "3")
        Assert.AreEqual(oRowDBI.debitMoyen, "23,5")
        Assert.AreEqual(oRowDBI.DebitMin, "25,5")
        Assert.AreEqual(oRowDBI.DebitMax, "25,5")
        Assert.AreEqual(oRowDBI.ecartTolere, "15")
        Assert.AreEqual(oRowDBI.nombreBuses, "2")
        Assert.AreEqual(oRowDBI.nombreBusesUsees, "1")
        Assert.AreEqual(oRowDBI.marque, "DBMarque2")
        'Assert.AreEqual(oRowDBI.type, "DBGenre2")

        Assert.AreEqual(ods.debitBuses.Rows.Count, 4) '4 Mesures (2 par lots)
        Dim oRow As ds_Etat_SM.debitBusesRow
        oRow = ods.debitBuses.Rows(0)
        Assert.AreEqual(oRow.IdLot, 1)
        Assert.AreEqual(oRow.numBuse, 2)
        Assert.AreEqual(oRow.debit, 1.6D)
        Assert.AreEqual(oRow.ecartPourcentage, 0.6D)
        oRow = ods.debitBuses.Rows(1)
        Assert.AreEqual(oRow.IdLot, 1)
        Assert.AreEqual(oRow.numBuse, 3)
        Assert.AreEqual(oRow.debit, 1.7D)
        Assert.AreEqual(oRow.ecartPourcentage, 0.7D)

        oRow = ods.debitBuses.Rows(2)
        Assert.AreEqual(oRow.IdLot, 2)
        Assert.AreEqual(oRow.numBuse, 2)
        Assert.AreEqual(oRow.debit, 2.6D)
        Assert.AreEqual(oRow.ecartPourcentage, 0.2D)
        oRow = ods.debitBuses.Rows(3)
        Assert.AreEqual(oRow.IdLot, 2)
        Assert.AreEqual(oRow.numBuse, 3)
        Assert.AreEqual(oRow.debit, 5.7D)
        Assert.AreEqual(oRow.ecartPourcentage, 2.7D)
    End Sub

    'Test la fonctionnalité de génération de l'état de synthèse
    'Première phase : Génération de du dataset
    <TestMethod()> _
    Public Sub TST_CreateEtatsynthes_542()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        'I - Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)
        oDiag.controleDateDebut = Date.Now()
        oDiag.controleDateFin = DateAdd(DateInterval.Hour, +1, Date.Now())

        'I.2   Mesures Manomètre 542 
        '---------------------------

        Dim oDiagMano542 As DiagnosticMano542

        'Mano1
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "1,6"
        oDiagMano542.pressionPulve = "1,7"
        oDiagMano542.Ecart = "0,1"
        oDiagMano542.Erreur = DiagnosticMano542.ERR542.FAIBLE
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano2
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "2"
        oDiagMano542.pressionPulve = "2,1"
        oDiagMano542.Ecart = "0,2"
        oDiagMano542.Erreur = DiagnosticMano542.ERR542.FORTE
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano3
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "3"
        oDiagMano542.pressionPulve = "3,1"
        oDiagMano542.Ecart = "0,3"
        oDiagMano542.Erreur = DiagnosticMano542.ERR542.FORTE
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4,1"
        oDiagMano542.Ecart = "0,4"
        oDiagMano542.Erreur = DiagnosticMano542.ERR542.OK
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)

        oDiag.controleUseCalibrateur = True
        oDiag.syntheseErreurMaxiMano = "0,4"
        oDiag.syntheseErreurMoyenneMano = "0,5"



        'Les DiagItems ne sont pas utilisés dans le rapport de synthese

        'II - génération du dataset
        '===========================
        Dim ods As ds_Etat_SM
        Dim oEtat As New EtatSyntheseMesures(oDiag)
        oEtat.GenereEtat()
        ods = DirectCast(oEtat.getDs(), ds_Etat_SM)

        'III- Vérification du dataset généré
        '====================================

        'I.2   Mesures Manomètre 542 
        '---------------------------


        ''Mano1
        'oDiagMano542 = New DiagnosticMano542()
        'oDiagMano542.pressionControle = "1,6"
        'oDiagMano542.pressionPulve = "1,7"
        'oDiagMano542.Ecart = "0,1"
        'oDiagMano542.Erreur = DiagnosticMano542.ERR542.FAIBLE
        'oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        ''Mano2
        'oDiagMano542 = New DiagnosticMano542()
        'oDiagMano542.pressionControle = "2"
        'oDiagMano542.pressionPulve = "2,1"
        'oDiagMano542.Ecart = "0,2"
        'oDiagMano542.Erreur = DiagnosticMano542.ERR542.FORTE
        'oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        ''Mano3
        'oDiagMano542 = New DiagnosticMano542()
        'oDiagMano542.pressionControle = "3"
        'oDiagMano542.pressionPulve = "3,1"
        'oDiagMano542.Ecart = "0,3"
        'oDiagMano542.Erreur = DiagnosticMano542.ERR542.FORTE
        'oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        ''Mano4
        'oDiagMano542 = New DiagnosticMano542()
        'oDiagMano542.pressionControle = "4"
        'oDiagMano542.pressionPulve = "4,1"
        'oDiagMano542.Ecart = "0,4"
        'oDiagMano542.Erreur = DiagnosticMano542.ERR542.OK
        'oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)

        'oDiag.controleUseCalibrateur = True
        'oDiag.syntheseErreurMaxiMano = "0,4"
        'oDiag.syntheseErreurMoyenneMano = "0,5"

        Assert.AreEqual(1, ods.Mano542.Count)
        Dim oRow542 As ds_Etat_SM.Mano542Row
        oRow542 = ods.Mano542.Rows(0)
        Assert.AreEqual(oRow542.EcartMaxi, 0.4D)
        Assert.AreEqual(oRow542.EcartMoyen, 0.5D)

        Assert.AreEqual(4, ods.Mano542Detail.Count)
        Dim oRow542D As ds_Etat_SM.Mano542DetailRow
        oRow542D = ods.Mano542Detail.Rows(0)
        Assert.AreEqual(oRow542D.pressionControle, 1.6D)
        Assert.AreEqual(oRow542D.PressionPulve, 1.7D)
        Assert.AreEqual(oRow542D.Ecart, 0.1D)
        Assert.AreEqual(oRow542D.Imprecision, DiagnosticMano542.ERR542.FAIBLE.ToString())


        oRow542D = ods.Mano542Detail.Rows(1)
        Assert.AreEqual(oRow542D.pressionControle, 2D)
        Assert.AreEqual(oRow542D.PressionPulve, 2.1D)
        Assert.AreEqual(oRow542D.Ecart, 0.2D)
        Assert.AreEqual(oRow542D.Imprecision, DiagnosticMano542.ERR542.FORTE.ToString())

        oRow542D = ods.Mano542Detail.Rows(2)
        Assert.AreEqual(oRow542D.pressionControle, 3D)
        Assert.AreEqual(oRow542D.PressionPulve, 3.1D)
        Assert.AreEqual(oRow542D.Ecart, 0.3D)
        Assert.AreEqual(oRow542D.Imprecision, DiagnosticMano542.ERR542.FORTE.ToString())

        oRow542D = ods.Mano542Detail.Rows(3)
        Assert.AreEqual(oRow542D.pressionControle, 4D)
        Assert.AreEqual(oRow542D.PressionPulve, 4.1D)
        Assert.AreEqual(oRow542D.Ecart, 0.4D)
        Assert.AreEqual(oRow542D.Imprecision, DiagnosticMano542.ERR542.OK.ToString())

    End Sub

    'Test la fonctionnalité de génération de l'état de synthèse
    'Première phase : Génération de du dataset
    <TestMethod()> _
    Public Sub TST_CreateEtatsynthes_833()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        Dim oParam833 As CRODIP_ControlLibrary.ParamDiagCalc833
        oParam833 = CRODIP_ControlLibrary.ParamDiag.readXML()(0).ParamDiagCalc833
        'I - Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)
        oDiag.controleDateDebut = Date.Now()
        oDiag.controleDateFin = DateAdd(DateInterval.Hour, +1, Date.Now())


        'I.3   Mesures Pression 833
        '---------------------------
        oDiag.controleNbreNiveaux = 1
        oDiag.controleNbreTroncons = 2
        oDiag.relevePression833_1 = New RelevePression833(1, 2, 5.1, oParam833)
        oDiag.relevePression833_2 = New RelevePression833(1, 2, 10.1, oParam833)
        oDiag.relevePression833_3 = New RelevePression833(1, 2, 15.1, oParam833)
        oDiag.relevePression833_4 = New RelevePression833(1, 2, 20.1, oParam833)

        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1 Mesure 1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "1,6"
        oDiagTroncons833.EcartBar = 0.1
        oDiagTroncons833.Ecartpct = 0.11
        oDiagTroncons833.MoyenneAutrePression = 0.111
        oDiagTroncons833.HeterogeneiteBar = 1.1
        oDiagTroncons833.HeterogeneitePct = 0.1
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1 Mesure 2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "1,7"
        oDiagTroncons833.EcartBar = 0.2
        oDiagTroncons833.Ecartpct = 0.22
        oDiagTroncons833.MoyenneAutrePression = 0.222
        oDiagTroncons833.HeterogeneiteBar = 2.2
        oDiagTroncons833.HeterogeneitePct = 0.2
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab2 Mesure 1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "2,6"
        oDiagTroncons833.EcartBar = 0.1
        oDiagTroncons833.Ecartpct = 0.11
        oDiagTroncons833.MoyenneAutrePression = 0.111
        oDiagTroncons833.HeterogeneiteBar = 1.1
        oDiagTroncons833.HeterogeneitePct = 0.1
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2 Mesure 2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "2,7"
        oDiagTroncons833.EcartBar = 0.2
        oDiagTroncons833.Ecartpct = 0.22
        oDiagTroncons833.MoyenneAutrePression = 0.222
        oDiagTroncons833.HeterogeneiteBar = 2.2
        oDiagTroncons833.HeterogeneitePct = 0.2
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3 Mesure 1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "3,6"
        oDiagTroncons833.EcartBar = 0.1
        oDiagTroncons833.Ecartpct = 0.11
        oDiagTroncons833.MoyenneAutrePression = 0.111
        oDiagTroncons833.HeterogeneiteBar = 1.1
        oDiagTroncons833.HeterogeneitePct = 0.1
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3 Mesure 2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "3,7"
        oDiagTroncons833.EcartBar = 0.2
        oDiagTroncons833.Ecartpct = 0.22
        oDiagTroncons833.MoyenneAutrePression = 0.222
        oDiagTroncons833.HeterogeneiteBar = 2.2
        oDiagTroncons833.HeterogeneitePct = 0.2
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4 Mesure 1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "4,6"
        oDiagTroncons833.EcartBar = 0.1
        oDiagTroncons833.Ecartpct = 0.11
        oDiagTroncons833.MoyenneAutrePression = 0.111
        oDiagTroncons833.HeterogeneiteBar = 1.1
        oDiagTroncons833.HeterogeneitePct = 0.1
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4 Mesure 2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "4,7"
        oDiagTroncons833.EcartBar = 0.2
        oDiagTroncons833.Ecartpct = 0.22
        oDiagTroncons833.MoyenneAutrePression = 0.222
        oDiagTroncons833.HeterogeneiteBar = 2.2
        oDiagTroncons833.HeterogeneitePct = 0.2
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Les DiagItems ne sont pas utilisés dans le rapport de synthese

        'II - génération du dataset
        '===========================
        Dim ods As ds_Etat_SM
        Dim oEtat As New EtatSyntheseMesures(oDiag)
        Assert.IsTrue(oEtat.GenereEtat())
        ods = DirectCast(oEtat.getDs(), ds_Etat_SM)
        oEtat.Open()
        Assert.IsNotNull(ods)
        'III- Vérification du dataset généré
        '====================================

        Assert.AreEqual(1, ods.Synthese833.Rows.Count)
        Dim oRow833 As ds_Etat_SM.Synthese833Row
        oRow833 = ods.Synthese833.Rows(0)
        Assert.AreEqual(oRow833.NbreNiveaux, 1)
        Assert.AreEqual(oRow833.NbreTroncons, 2)

        Assert.AreEqual(4, ods.synthese833Pression.Rows.Count)
        Dim oRow833P As ds_Etat_SM.synthese833PressionRow
        oRow833P = ods.synthese833Pression.Rows(0)
        Assert.AreEqual(oRow833P.PressionMesure, 5.1D)
        Assert.AreEqual(oRow833P.MoyennePression, 0D)
        Assert.AreEqual(oRow833P.EcartBars, 5.1D)

        oRow833P = ods.synthese833Pression.Rows(1)
        Assert.AreEqual(oRow833P.PressionMesure, 10.1D)
        Assert.AreEqual(oRow833P.MoyennePression, 0D)
        Assert.AreEqual(oRow833P.EcartBars, 10.1D)

        oRow833P = ods.synthese833Pression.Rows(2)
        Assert.AreEqual(oRow833P.PressionMesure, 15.1D)
        Assert.AreEqual(oRow833P.MoyennePression, 0D)
        Assert.AreEqual(oRow833P.EcartBars, 15.1D)

        oRow833P = ods.synthese833Pression.Rows(3)
        Assert.AreEqual(oRow833P.PressionMesure, 20.1D)
        Assert.AreEqual(oRow833P.MoyennePression, 0D)
        Assert.AreEqual(oRow833P.EcartBars, 20.1D)

        Assert.AreEqual(8, ods.synthese833Detail.Rows.Count)
        Dim oRow833D As ds_Etat_SM.synthese833DetailRow

        oRow833D = ods.synthese833Detail.Rows(0)
        Assert.AreEqual(oRow833D.nPression, 1)

        'oDiagTroncons833.idPression = 1
        'oDiagTroncons833.idColumn = 1
        'oDiagTroncons833.pressionSortie = "1,6"
        'oDiagTroncons833.EcartBar = 0.1
        'oDiagTroncons833.Ecartpct = 0.11
        'oDiagTroncons833.MoyenneAutrePression = 0.111
        'oDiagTroncons833.HeterogeneiteBar = 1.1
        'oDiagTroncons833.HeterogeneitePct = 0.1
        Assert.AreEqual(oRow833D.nPression, 1)
        Assert.AreEqual(oRow833D.nDetail, 1)
        Assert.AreEqual(oRow833D.PressionLue, 1.6D)
        Assert.AreEqual(oRow833D.EcartBar, 0.1D)
        Assert.AreEqual(oRow833D.EcartPct, 0.11D)
        Assert.AreEqual(oRow833D.MoyenneAutrePression, 0.111D)
        Assert.AreEqual(oRow833D.HeterogeneiteBar, 1.1D)
        Assert.AreEqual(oRow833D.HeterogeneitePct, 0.1D)

        'oDiagTroncons833.idColumn = 2
        'oDiagTroncons833.pressionSortie = "1,7"
        'oDiagTroncons833.EcartBar = 0.2
        'oDiagTroncons833.Ecartpct = 0.22
        'oDiagTroncons833.MoyenneAutrePression = 0.222
        'oDiagTroncons833.HeterogeneiteBar = 2.2
        'oDiagTroncons833.HeterogeneitePct = 0.2
        'oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        oRow833D = ods.synthese833Detail.Rows(1)
        Assert.AreEqual(oRow833D.nPression, 1)
        Assert.AreEqual(oRow833D.nDetail, 2)
        Assert.AreEqual(oRow833D.PressionLue, 1.7D)
        Assert.AreEqual(oRow833D.EcartBar, 0.2D)
        Assert.AreEqual(oRow833D.EcartPct, 0.22D)
        Assert.AreEqual(oRow833D.MoyenneAutrePression, 0.222D)
        Assert.AreEqual(oRow833D.HeterogeneiteBar, 2.2D)
        Assert.AreEqual(oRow833D.HeterogeneitePct, 0.2D)

        'oDiagTroncons833.idPression = 2
        'oDiagTroncons833.idColumn = 1
        'oDiagTroncons833.pressionSortie = "2,6"
        'oDiagTroncons833.EcartBar = 0.1
        'oDiagTroncons833.Ecartpct = 0.11
        'oDiagTroncons833.MoyenneAutrePression = 0.111
        'oDiagTroncons833.HeterogeneiteBar = 1.1
        'oDiagTroncons833.HeterogeneitePct = 0.1
        oRow833D = ods.synthese833Detail.Rows(2)
        Assert.AreEqual(oRow833D.nPression, 2)
        Assert.AreEqual(oRow833D.nDetail, 1)
        Assert.AreEqual(oRow833D.PressionLue, 2.6D)
        Assert.AreEqual(oRow833D.EcartBar, 0.1D)
        Assert.AreEqual(oRow833D.EcartPct, 0.11D)
        Assert.AreEqual(oRow833D.MoyenneAutrePression, 0.111D)
        Assert.AreEqual(oRow833D.HeterogeneiteBar, 1.1D)
        Assert.AreEqual(oRow833D.HeterogeneitePct, 0.1D)

        'oDiagTroncons833.idPression = 2
        'oDiagTroncons833.idColumn = 2
        'oDiagTroncons833.pressionSortie = "2,7"
        'oDiagTroncons833.EcartBar = 0.2
        'oDiagTroncons833.Ecartpct = 0.22
        'oDiagTroncons833.MoyenneAutrePression = 0.222
        'oDiagTroncons833.HeterogeneiteBar = 2.2
        'oDiagTroncons833.HeterogeneitePct = 0.2
        oRow833D = ods.synthese833Detail.Rows(3)
        Assert.AreEqual(oRow833D.nPression, 2)
        Assert.AreEqual(oRow833D.nDetail, 2)
        Assert.AreEqual(oRow833D.PressionLue, 2.7D)
        Assert.AreEqual(oRow833D.EcartBar, 0.2D)
        Assert.AreEqual(oRow833D.EcartPct, 0.22D)
        Assert.AreEqual(oRow833D.MoyenneAutrePression, 0.222D)
        Assert.AreEqual(oRow833D.HeterogeneiteBar, 2.2D)
        Assert.AreEqual(oRow833D.HeterogeneitePct, 0.2D)

        'oDiagTroncons833.idPression = 3
        'oDiagTroncons833.idColumn = 1
        'oDiagTroncons833.pressionSortie = "3,6"
        'oDiagTroncons833.EcartBar = 0.2
        'oDiagTroncons833.Ecartpct = 0.22
        'oDiagTroncons833.MoyenneAutrePression = 0.222
        'oDiagTroncons833.HeterogeneiteBar = 2.2
        'oDiagTroncons833.HeterogeneitePct = 0.2
        oRow833D = ods.synthese833Detail.Rows(4)
        Assert.AreEqual(oRow833D.nPression, 3)
        Assert.AreEqual(oRow833D.nDetail, 1)
        Assert.AreEqual(oRow833D.PressionLue, 3.6D)
        Assert.AreEqual(oRow833D.EcartBar, 0.1D)
        Assert.AreEqual(oRow833D.EcartPct, 0.11D)
        Assert.AreEqual(oRow833D.MoyenneAutrePression, 0.111D)
        Assert.AreEqual(oRow833D.HeterogeneiteBar, 1.1D)
        Assert.AreEqual(oRow833D.HeterogeneitePct, 0.1D)

        'oDiagTroncons833.idPression = 3
        'oDiagTroncons833.idColumn = 2
        'oDiagTroncons833.pressionSortie = "3,7"
        'oDiagTroncons833.EcartBar = 0.2
        'oDiagTroncons833.Ecartpct = 0.22
        'oDiagTroncons833.MoyenneAutrePression = 0.222
        'oDiagTroncons833.HeterogeneiteBar = 2.2
        'oDiagTroncons833.HeterogeneitePct = 0.2
        oRow833D = ods.synthese833Detail.Rows(5)
        Assert.AreEqual(oRow833D.nPression, 3)
        Assert.AreEqual(oRow833D.nDetail, 2)
        Assert.AreEqual(oRow833D.PressionLue, 3.7D)
        Assert.AreEqual(oRow833D.EcartBar, 0.2D)
        Assert.AreEqual(oRow833D.EcartPct, 0.22D)
        Assert.AreEqual(oRow833D.MoyenneAutrePression, 0.222D)
        Assert.AreEqual(oRow833D.HeterogeneiteBar, 2.2D)
        Assert.AreEqual(oRow833D.HeterogeneitePct, 0.2D)

        'oDiagTroncons833.idPression = 4
        'oDiagTroncons833.idColumn = 1
        'oDiagTroncons833.pressionSortie = "4,6"
        'oDiagTroncons833.EcartBar = 0.1
        'oDiagTroncons833.Ecartpct = 0.11
        'oDiagTroncons833.MoyenneAutrePression = 0.111
        'oDiagTroncons833.HeterogeneiteBar = 1.1
        'oDiagTroncons833.HeterogeneitePct = 0.1

        oRow833D = ods.synthese833Detail.Rows(6)
        Assert.AreEqual(oRow833D.nPression, 4)
        Assert.AreEqual(oRow833D.nDetail, 1)
        Assert.AreEqual(oRow833D.PressionLue, 4.6D)
        Assert.AreEqual(oRow833D.EcartBar, 0.1D)
        Assert.AreEqual(oRow833D.EcartPct, 0.11D)
        Assert.AreEqual(oRow833D.MoyenneAutrePression, 0.111D)
        Assert.AreEqual(oRow833D.HeterogeneiteBar, 1.1D)
        Assert.AreEqual(oRow833D.HeterogeneitePct, 0.1D)

        'oDiagTroncons833.idColumn = 2
        'oDiagTroncons833.pressionSortie = "4,7"
        'oDiagTroncons833.EcartBar = 0.2
        'oDiagTroncons833.Ecartpct = 0.22
        'oDiagTroncons833.MoyenneAutrePression = 0.222
        'oDiagTroncons833.HeterogeneiteBar = 2.2
        'oDiagTroncons833.HeterogeneitePct = 0.2
        oRow833D = ods.synthese833Detail.Rows(7)
        Assert.AreEqual(oRow833D.nPression, 4)
        Assert.AreEqual(oRow833D.nDetail, 2)
        Assert.AreEqual(oRow833D.PressionLue, 4.7D)
        Assert.AreEqual(oRow833D.EcartBar, 0.2D)
        Assert.AreEqual(oRow833D.EcartPct, 0.22D)
        Assert.AreEqual(oRow833D.MoyenneAutrePression, 0.222D)
        Assert.AreEqual(oRow833D.HeterogeneiteBar, 2.2D)
        Assert.AreEqual(oRow833D.HeterogeneitePct, 0.2D)

    End Sub

    'Test la fonctionnalité de génération de l'état de synthèse
    'Première phase : Génération de du dataset
    <TestMethod()> _
    Public Sub TST_CreateEtatsynthes551()
        Dim oDiag As Diagnostic
        Dim idDiag As String
        'I - Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)
        oDiag.controleDateDebut = Date.Now()
        oDiag.controleDateFin = DateAdd(DateInterval.Hour, +1, Date.Now())


        oDiag.diagnosticHelp551.Distance1 = 10.5
        oDiag.diagnosticHelp551.Temps1 = 10.6
        oDiag.diagnosticHelp551.VitesseReelle1 = 10.7
        oDiag.diagnosticHelp551.VitesseLue1 = 10.8
        oDiag.diagnosticHelp551.Ecart1 = 10.9

        oDiag.diagnosticHelp551.Distance2 = 20.5
        oDiag.diagnosticHelp551.Temps2 = 20.6
        oDiag.diagnosticHelp551.VitesseReelle2 = 20.7
        oDiag.diagnosticHelp551.VitesseLue2 = 20.8
        oDiag.diagnosticHelp551.Ecart2 = 20.9

        oDiag.diagnosticHelp551.ErreurMoyenneSigned = 30.5

        oDiag.diagnosticHelp5621.Distance1 = 30.5
        oDiag.diagnosticHelp5621.Temps1 = 30.6
        oDiag.diagnosticHelp5621.VitesseReelle1 = 30.7
        oDiag.diagnosticHelp5621.VitesseLue1 = 30.8
        oDiag.diagnosticHelp5621.Ecart1 = 30.9

        oDiag.diagnosticHelp5621.Distance2 = 40.5
        oDiag.diagnosticHelp5621.Temps2 = 40.6
        oDiag.diagnosticHelp5621.VitesseReelle2 = 40.7
        oDiag.diagnosticHelp5621.VitesseLue2 = 40.8
        oDiag.diagnosticHelp5621.Ecart2 = 40.9

        oDiag.diagnosticHelp5621.ErreurMoyenneSigned = 50.5

        'Les DiagItems ne sont pas utilisés dans le rapport de synthese

        'II - génération du dataset
        '===========================
        Dim ods As ds_Etat_SM
        Dim oEtat As New EtatSyntheseMesures(oDiag)
        oEtat.GenereEtat()
        ods = DirectCast(oEtat.getDs(), ds_Etat_SM)

        'III- Vérification du dataset généré
        '====================================

        Assert.AreEqual(2, ods.SyntheseCapteurVitesse.Rows.Count)
        Dim oRowCV As ds_Etat_SM.SyntheseCapteurVitesseRow
        oRowCV = ods.SyntheseCapteurVitesse.Rows(0)
        Assert.AreEqual(oRowCV.type, "help551")
        Assert.AreEqual(oRowCV.Distance1, 10.5D)
        Assert.AreEqual(oRowCV.Temps1, 10.6D)
        Assert.AreEqual(oRowCV.VitesseReelle1, 10.7D)
        Assert.AreEqual(oRowCV.VitesseLue1, 10.8D)
        Assert.AreEqual(oRowCV.ErreurMoyenne, 30.5D)

        Assert.AreEqual(oRowCV.Distance2, 20.5D)
        Assert.AreEqual(oRowCV.Temps2, 20.6D)
        Assert.AreEqual(oRowCV.VitesseReelle2, 20.7D)
        Assert.AreEqual(oRowCV.VitesseLue2, 20.8D)


        oRowCV = ods.SyntheseCapteurVitesse.Rows(1)
        Assert.AreEqual(oRowCV.type, "help5621")
        Assert.AreEqual(oRowCV.Distance1, 30.5D)
        Assert.AreEqual(oRowCV.Temps1, 30.6D)
        Assert.AreEqual(oRowCV.VitesseReelle1, 30.7D)
        Assert.AreEqual(oRowCV.VitesseLue1, 30.8D)
        Assert.AreEqual(oRowCV.ErreurMoyenne, 50.5D)

        Assert.AreEqual(oRowCV.Distance2, 40.5D)
        Assert.AreEqual(oRowCV.Temps2, 40.6D)
        Assert.AreEqual(oRowCV.VitesseReelle2, 40.7D)
        Assert.AreEqual(oRowCV.VitesseLue2, 40.8D)


    End Sub

    'Test la fonctionnalité de génération de l'état de synthèse
    'Première phase : Génération de du dataset
    <TestMethod()> _
    Public Sub TST_CreateEtatsynthes552()
        Dim oDiag As Diagnostic
        Dim idDiag As String
        'I - Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(m_oAgent)
        oDiag.controleDateDebut = Date.Now()
        oDiag.controleDateFin = DateAdd(DateInterval.Hour, +1, Date.Now())


        oDiag.diagnosticHelp552.NbBuses_m1 = 10
        oDiag.diagnosticHelp552.Pression_m1 = 10.1
        oDiag.diagnosticHelp552.DebitEtalon_m1 = 10.2
        oDiag.diagnosticHelp552.DebitAfficheur_m1 = 10.3
        oDiag.diagnosticHelp552.EcartPct_m1 = 10.4

        oDiag.diagnosticHelp552.NbBuses_m2 = 20
        oDiag.diagnosticHelp552.Pression_m2 = 20.1
        oDiag.diagnosticHelp552.DebitEtalon_m2 = 20.2
        oDiag.diagnosticHelp552.DebitAfficheur_m2 = 20.3
        oDiag.diagnosticHelp552.EcartPct_m2 = 20.4

        oDiag.diagnosticHelp552.NbBuses_m3 = 30
        oDiag.diagnosticHelp552.Pression_m3 = 30.1
        oDiag.diagnosticHelp552.DebitEtalon_m3 = 30.2
        oDiag.diagnosticHelp552.DebitAfficheur_m3 = 30.3
        oDiag.diagnosticHelp552.EcartPct_m3 = 30.4

        oDiag.diagnosticHelp552.ErreurDebitMetre = 40.5

        oDiag.diagnosticHelp5622.NbBuses_m1 = 40
        oDiag.diagnosticHelp5622.Pression_m1 = 40.1
        oDiag.diagnosticHelp5622.DebitEtalon_m1 = 40.2
        oDiag.diagnosticHelp5622.DebitAfficheur_m1 = 40.3
        oDiag.diagnosticHelp5622.EcartPct_m1 = 40.4

        oDiag.diagnosticHelp5622.NbBuses_m2 = 50
        oDiag.diagnosticHelp5622.Pression_m2 = 50.1
        oDiag.diagnosticHelp5622.DebitEtalon_m2 = 50.2
        oDiag.diagnosticHelp5622.DebitAfficheur_m2 = 50.3
        oDiag.diagnosticHelp5622.EcartPct_m2 = 50.4

        oDiag.diagnosticHelp5622.NbBuses_m3 = 60
        oDiag.diagnosticHelp5622.Pression_m3 = 60.1
        oDiag.diagnosticHelp5622.DebitEtalon_m3 = 60.2
        oDiag.diagnosticHelp5622.DebitAfficheur_m3 = 60.3
        oDiag.diagnosticHelp5622.EcartPct_m3 = 60.4

        oDiag.diagnosticHelp5622.ErreurDebitMetre = 70.5

        'Les DiagItems ne sont pas utilisés dans le rapport de synthese

        'II - génération du dataset
        '===========================
        Dim ods As ds_Etat_SM
        Dim oEtat As New EtatSyntheseMesures(oDiag)
        oEtat.GenereEtat()
        ods = DirectCast(oEtat.getDs(), ds_Etat_SM)

        'III- Vérification du dataset généré
        '====================================

        Assert.AreEqual(2, ods.SyntheseDebitmetre.Rows.Count)
        Dim oRowDM As ds_Etat_SM.SyntheseDebitmetreRow
        oRowDM = ods.SyntheseDebitmetre.Rows(0)
        Assert.AreEqual(oRowDM.type, "help552")
        Assert.AreEqual(oRowDM.ErreurDebitMetre, 40.5D)

        oRowDM = ods.SyntheseDebitmetre.Rows(1)
        Assert.AreEqual(oRowDM.type, "help5622")
        Assert.AreEqual(oRowDM.ErreurDebitMetre, 70.5D)

        'Assert.AreEqual(6, ods.SyntheseDebitmetreDetail.Rows.Count)
        'Dim oRowDMD As ds_etat_SM.SyntheseDebitmetreDetailRow
        'oRowDMD = ods.SyntheseDebitmetreDetail.Rows(0)
        'Assert.AreEqual(oRowDMD.type, "help552")
        'Assert.AreEqual(oRowDMD.NbreBuses, 10)
        'Assert.AreEqual(oRowDMD.Pressionbar, 10.1D)
        'Assert.AreEqual(oRowDMD.debitEtalon, 10.2D)
        'Assert.AreEqual(oRowDMD.DebitAfficheur, 10.3D)
        'Assert.AreEqual(oRowDMD.Ecartpct, 10.4D)

        'oRowDMD = ods.SyntheseDebitmetreDetail.Rows(1)
        'Assert.AreEqual(oRowDMD.type, "help552")
        'Assert.AreEqual(oRowDMD.NbreBuses, 20)
        'Assert.AreEqual(oRowDMD.Pressionbar, 20.1D)
        'Assert.AreEqual(oRowDMD.debitEtalon, 20.2D)
        'Assert.AreEqual(oRowDMD.DebitAfficheur, 20.3D)
        'Assert.AreEqual(oRowDMD.Ecartpct, 20.4D)

        'oRowDMD = ods.SyntheseDebitmetreDetail.Rows(2)
        'Assert.AreEqual(oRowDMD.type, "help552")
        'Assert.AreEqual(oRowDMD.NbreBuses, 30)
        'Assert.AreEqual(oRowDMD.Pressionbar, 30.1D)
        'Assert.AreEqual(oRowDMD.debitEtalon, 30.2D)
        'Assert.AreEqual(oRowDMD.DebitAfficheur, 30.3D)
        'Assert.AreEqual(oRowDMD.Ecartpct, 30.4D)

        'oRowDMD = ods.SyntheseDebitmetreDetail.Rows(3)
        'Assert.AreEqual(oRowDMD.type, "help5622")
        'Assert.AreEqual(oRowDMD.NbreBuses, 40)
        'Assert.AreEqual(oRowDMD.Pressionbar, 40.1D)
        'Assert.AreEqual(oRowDMD.debitEtalon, 40.2D)
        'Assert.AreEqual(oRowDMD.DebitAfficheur, 40.3D)
        'Assert.AreEqual(oRowDMD.Ecartpct, 40.4D)

        'oRowDMD = ods.SyntheseDebitmetreDetail.Rows(4)
        'Assert.AreEqual(oRowDMD.type, "help5622")
        'Assert.AreEqual(oRowDMD.NbreBuses, 50)
        'Assert.AreEqual(oRowDMD.Pressionbar, 50.1D)
        'Assert.AreEqual(oRowDMD.debitEtalon, 50.2D)
        'Assert.AreEqual(oRowDMD.DebitAfficheur, 50.3D)
        'Assert.AreEqual(oRowDMD.Ecartpct, 50.4D)

        'oRowDMD = ods.SyntheseDebitmetreDetail.Rows(5)
        'Assert.AreEqual(oRowDMD.type, "help5622")
        'Assert.AreEqual(oRowDMD.NbreBuses, 60)
        'Assert.AreEqual(oRowDMD.Pressionbar, 60.1D)
        'Assert.AreEqual(oRowDMD.debitEtalon, 60.2D)
        'Assert.AreEqual(oRowDMD.DebitAfficheur, 60.3D)
        'Assert.AreEqual(oRowDMD.Ecartpct, 60.4D)

    End Sub
    'Test de la fonction de récupération d'un nouveau Numéro de diag
    <TestMethod()> _
    Public Sub TST_GetNewId()
        Dim odiag As Diagnostic
        Dim strId As String
        Dim tabStr() As String
        Dim nId As Integer
        odiag = New Diagnostic
        odiag.setOrganisme(m_oAgent)

        'Récupération d'un ID
        strId = DiagnosticManager.getNewId(m_oAgent)

        odiag.id = strId
        tabStr = strId.Split("-")
        'On mémorise son numéro 
        nId = CInt(tabStr(2))

        'Sauevagrde du diag
        Assert.IsTrue(DiagnosticManager.save(odiag))

        'Maj du diag Id pour simler le Bug de GreenControl
        Dim oCsdb As New CSDb(True)
        oCsdb.getResults("UPDATE DIAGNOSTIC set id = '45-99-33' WHERE id = " & strId)

        'Récupération d'un nouvel Id
        strId = DiagnosticManager.getNewId(m_oAgent)
        tabStr = strId.Split("-")
        'Le nouvel Id doit être égal à l'ancien +1
        Assert.AreEqual(nId + 1, CInt(tabStr(2)))

    End Sub

    <TestMethod()> _
    Public Sub TST_Clone()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String

        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        oDiag.setOrganisme(m_oAgent)
        'SetPulverisateur
        Dim oPulve As New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_JETDIRIGE
        oPulve.setLargeurNbreRangs("15.5")
        oPulve.emplacementIdentification = "DERRIERE"
        oDiag.setPulverisateur(oPulve)
        Assert.AreEqual(oDiag.pulverisateurNbRangs, "15.5")


        'SetPropriétaire
        Dim pClient As New Exploitation
        pClient.id = "99"
        pClient.numeroSiren = "NUMRIREN"
        pClient.codeApe = "CODEAPE"
        pClient.raisonSociale = "RS"
        pClient.nomExploitant = "NOM"
        pClient.prenomExploitant = "PRENOM"
        pClient.adresse = "ADRESSE"
        pClient.codePostal = "CP"
        pClient.commune = "COMMUNE"
        pClient.telephoneFixe = "TelFixe"
        pClient.telephonePortable = "TelPortable"
        pClient.eMail = "Email"
        pClient.isProdGrandeCulture = True
        pClient.isProdElevage = False
        pClient.isProdArboriculture = True
        pClient.isProdLegume = False
        pClient.isProdViticulture = True
        pClient.isProdAutre = False
        pClient.surfaceAgricoleUtile = 1500
        oDiag.SetProprietaire(pClient)

        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "DBNombre1"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "1,1"
        oDiagBuses.debitNominal = "1,2"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "1,3"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque2"
        oDiagBuses.nombre = "DBNombre2"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "2,1"
        oDiagBuses.debitNominal = "2,2"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "2,3"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)


        Dim oDiagMano542 As DiagnosticMano542

        'Mano1
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "1.6"
        oDiagMano542.pressionPulve = "1.7"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano2
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "2"
        oDiagMano542.pressionPulve = "2.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano3
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "3"
        oDiagMano542.pressionPulve = "3.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)



        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "1.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "1.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "2.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "2.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "3.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "4.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "4.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)


        Dim oDiagItem As DiagnosticItem
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"

        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item2
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "222"
        oDiagItem.itemValue = "2"
        oDiagItem.itemCodeEtat = "P"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item3
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "333"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = "O"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item4
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "444"
        oDiagItem.itemValue = "4"
        oDiagItem.itemCodeEtat = "P"


        oDiag.AdOrReplaceDiagItem(oDiagItem)

        Dim oDiag2 As Diagnostic
        '===========================================================
        oDiag2 = oDiag.Clone()
        Assert.IsNotNull(oDiag2)

        Assert.AreEqual(idDiag, oDiag2.id)

        'Vérification des Buses

        Assert.AreEqual(2, oDiag2.diagnosticBusesList.Liste.Count)
        oDiagBuses = oDiag2.diagnosticBusesList.Liste(0)
        Assert.AreEqual(oDiagBuses.marque, "DBMarque1")
        Assert.AreEqual(oDiagBuses.nombre, "DBNombre1")
        Assert.AreEqual(oDiagBuses.genre, "DBGenre1")
        Assert.AreEqual(oDiagBuses.calibre, "DBCalibre1")
        Assert.AreEqual(oDiagBuses.couleur, "DBCouleur1")
        Assert.AreEqual(oDiagBuses.debitMoyen, "1,1")
        Assert.AreEqual(oDiagBuses.debitNominal, "1,2")
        Assert.AreEqual(oDiagBuses.idLot, "1")
        Assert.AreEqual(oDiagBuses.ecartTolere, "1,3")
        'Vérification du détail des buses
        Assert.AreEqual(2, oDiagBuses.diagnosticBusesDetailList.Liste.Count)
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBusesDetail.debit, "1.6")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.6")
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBusesDetail.debit, "1.7")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.7")

        oDiagBuses = oDiag2.diagnosticBusesList.Liste(1)
        Assert.AreEqual(oDiagBuses.marque, "DBMarque2")
        Assert.AreEqual(oDiagBuses.nombre, "DBNombre2")
        Assert.AreEqual(oDiagBuses.genre, "DBGenre2")
        Assert.AreEqual(oDiagBuses.calibre, "DBCalibre2")
        Assert.AreEqual(oDiagBuses.couleur, "DBCouleur2")
        Assert.AreEqual(oDiagBuses.debitMoyen, "2,1")
        Assert.AreEqual(oDiagBuses.debitNominal, "2,2")
        Assert.AreEqual(oDiagBuses.idLot, "2")
        Assert.AreEqual(oDiagBuses.ecartTolere, "2,3")
        'Vérification du détail des buses
        Assert.AreEqual(2, oDiagBuses.diagnosticBusesDetailList.Liste.Count)
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBusesDetail.debit, "2.6")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.6")
        oDiagBusesDetail = oDiagBuses.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBusesDetail.debit, "2.7")
        Assert.IsTrue(oDiagBusesDetail.ecart = "0.7")

        'Vérification des Mano542
        Assert.AreEqual(4, oDiag2.diagnosticMano542List.Liste.Count)
        oDiagMano542 = oDiag2.diagnosticMano542List.Liste(0)
        Assert.IsTrue(oDiagMano542.pressionControle = "1.6")
        Assert.IsTrue(oDiagMano542.pressionPulve = "1.7")

        oDiagMano542 = oDiag2.diagnosticMano542List.Liste(1)
        Assert.IsTrue(oDiagMano542.pressionControle = "2")
        Assert.IsTrue(oDiagMano542.pressionPulve = "2.1")

        oDiagMano542 = oDiag2.diagnosticMano542List.Liste(2)
        Assert.IsTrue(oDiagMano542.pressionControle = "3")
        Assert.IsTrue(oDiagMano542.pressionPulve = "3.1")

        oDiagMano542 = oDiag2.diagnosticMano542List.Liste(3)
        Assert.IsTrue(oDiagMano542.pressionControle = "4")
        Assert.IsTrue(oDiagMano542.pressionPulve = "4.1")


        'Vérification des Troncons833

        Assert.AreEqual(8, oDiag2.diagnosticTroncons833.Liste.Count)
        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(0)
        Assert.IsTrue(oDiagTroncons833.idPression = 1)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1.6")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(1)
        Assert.IsTrue(oDiagTroncons833.idPression = 1)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1.7")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(2)
        Assert.IsTrue(oDiagTroncons833.idPression = 2)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2.6")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(3)
        Assert.IsTrue(oDiagTroncons833.idPression = 2)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2.7")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(4)
        Assert.IsTrue(oDiagTroncons833.idPression = 3)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.6")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(5)
        Assert.IsTrue(oDiagTroncons833.idPression = 3)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.7")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(6)
        Assert.IsTrue(oDiagTroncons833.idPression = 4)
        Assert.IsTrue(oDiagTroncons833.idColumn = 1)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.6")

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(7)
        Assert.IsTrue(oDiagTroncons833.idPression = 4)
        Assert.IsTrue(oDiagTroncons833.idColumn = 2)
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.7")
        DiagnosticManager.delete(oDiag2.id)

        'Vérification des DiagItems
        Assert.AreEqual(4, oDiag2.diagnosticItemsLst.Count)
        oDiagItem = oDiag2.diagnosticItemsLst.Values(0)
        'Item1
        Assert.IsTrue(oDiagItem.idItem = "111")
        Assert.IsTrue(oDiagItem.itemValue = "1")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "B")
        Assert.IsTrue(oDiagItem.cause = "1")


        'Item2
        oDiagItem = oDiag2.diagnosticItemsLst.Values(1)
        Assert.IsTrue(oDiagItem.idItem = "222")
        Assert.IsTrue(oDiagItem.itemValue = "2")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "P")

        Assert.IsTrue(oDiagItem.cause = "2")

        'Item3
        oDiagItem = oDiag2.diagnosticItemsLst.Values(2)
        Assert.IsTrue(oDiagItem.idItem = "333")
        Assert.IsTrue(oDiagItem.itemValue = "3")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "O")

        Assert.IsTrue(oDiagItem.cause = "2")

        'Item4
        oDiagItem = oDiag2.diagnosticItemsLst.Values(3)
        Assert.IsTrue(oDiagItem.idItem = "444")
        Assert.IsTrue(oDiagItem.itemValue = "4")
        Assert.IsTrue(oDiagItem.itemCodeEtat = "P")


        'Test Clone Propriétaire
        Assert.AreEqual(oDiag2.proprietaireNumeroSiren, "NUMRIREN")
        Assert.AreEqual(oDiag2.proprietaireCodeApe, "CODEAPE")
        Assert.AreEqual(oDiag2.proprietaireRaisonSociale, "RS")
        Assert.AreEqual(oDiag2.proprietaireNom, "NOM")
        Assert.AreEqual(oDiag2.proprietairePrenom, "PRENOM")
        Assert.AreEqual(oDiag2.proprietaireAdresse, "ADRESSE")
        Assert.AreEqual(oDiag2.proprietaireCodePostal, "CP")
        Assert.AreEqual(oDiag2.proprietaireCommune, "COMMUNE")
        Assert.AreEqual(oDiag2.proprietaireTelephoneFixe, "TelFixe")
        Assert.AreEqual(oDiag2.proprietaireTelephonePortable, "TelPortable")
        Assert.AreEqual(oDiag2.proprietaireEmail, "Email")
        Assert.AreEqual(oDiag2.exploitationTypeCultureIsGrandeCulture, True)
        Assert.AreEqual(oDiag2.exploitationTypeCultureIsElevage, False)
        Assert.AreEqual(oDiag2.exploitationTypeCultureIsArboriculture, True)
        Assert.AreEqual(oDiag2.exploitationTypeCultureIsLegume, False)
        Assert.AreEqual(oDiag2.exploitationTypeCultureIsViticulture, True)
        Assert.AreEqual(oDiag2.exploitationTypeCultureIsAutres, False)
        Assert.AreEqual(oDiag2.exploitationSau, "1500")


        Assert.AreEqual(oDiag2.pulverisateurMarque, "MAMARQUE")
        Assert.AreEqual(oDiag2.pulverisateurModele, "MONMODELE")
        Assert.AreEqual(oDiag2.pulverisateurType, Pulverisateur.TYPEPULVE_ARBRES)
        Assert.AreEqual(Pulverisateur.CATEGORIEPULVE_JETDIRIGE, oDiag2.pulverisateurCategorie)
        Assert.AreEqual(oDiag2.pulverisateurNbRangs, "15.5")
        Assert.AreEqual(oDiag2.pulverisateurEmplacementIdentification, "DERRIERE")

    End Sub

    <TestMethod()> _
    Public Sub TST_SetContreVisite()
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        oDiag.setOrganisme(m_oAgent)
        oDiag.inspecteurNom = "Nom Inspecteur Origine"
        oDiag.inspecteurPrenom = "Prénom Inspecteur d'Origine"
        'SetPulverisateur
        Dim oPulve As New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_JETDIRIGE
        oPulve.setLargeurNbreRangs("15.5")
        oPulve.emplacementIdentification = "DERRIERE"
        oDiag.setPulverisateur(oPulve)

        'SetPropriétaire
        Dim pClient As New Exploitation
        pClient.id = "99"
        pClient.numeroSiren = "NUMRIREN"
        pClient.codeApe = "CODEAPE"
        pClient.raisonSociale = "RS"
        pClient.nomExploitant = "NOM"
        pClient.prenomExploitant = "PRENOM"
        pClient.adresse = "ADRESSE"
        pClient.codePostal = "CP"
        pClient.commune = "COMMUNE"
        pClient.telephoneFixe = "TelFixe"
        pClient.telephonePortable = "TelPortable"
        pClient.eMail = "Email"
        pClient.isProdGrandeCulture = True
        pClient.isProdElevage = False
        pClient.isProdArboriculture = True
        pClient.isProdLegume = False
        pClient.isProdViticulture = True
        pClient.isProdAutre = False
        pClient.surfaceAgricoleUtile = 1500
        oDiag.SetProprietaire(pClient)

        idDiag = DiagnosticManager.getNewId(m_oAgent)
        oDiag.id = idDiag
        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "DBNombre1"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "DBDebitMoyen1"
        oDiagBuses.debitNominal = "DBdebitNominal1"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "DBEcartTolere1"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque2"
        oDiagBuses.nombre = "DBNombre2"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "DBDebitMoyen2"
        oDiagBuses.debitNominal = "DBdebitNominal2"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "DBEcartTolere2"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)


        Dim oDiagMano542 As DiagnosticMano542

        'Mano1
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "1.6"
        oDiagMano542.pressionPulve = "1.7"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano2
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "2"
        oDiagMano542.pressionPulve = "2.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano3
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "3"
        oDiagMano542.pressionPulve = "3.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4.1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)



        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "1.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 1
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "1.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "2.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 2
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "2.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "3.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 3
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 1
        oDiagTroncons833.pressionSortie = "4.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = 4
        oDiagTroncons833.idColumn = 2
        oDiagTroncons833.pressionSortie = "4.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)


        Dim oDiagItem As DiagnosticItem
        ''Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"

        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item2
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "222"
        oDiagItem.itemValue = "2"
        oDiagItem.itemCodeEtat = "P"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item3
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "333"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = "O"

        oDiagItem.cause = "2"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Item4
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "444"
        oDiagItem.itemValue = "4"
        oDiagItem.itemCodeEtat = "P"


        oDiag.AdOrReplaceDiagItem(oDiagItem)

        Dim oDiag2 As Diagnostic

        oDiag2 = oDiag.Clone()
        Assert.AreEqual("", oDiag2.organismeOrigineInspNom)
        Assert.AreEqual("", oDiag2.organismeOriginePresNom)

        'Modification de m'm_oAgent
        m_oAgent.nom = "TEST2"
        Dim sDateFin As String = oDiag.controleDateFin
        oDiag2.SetAsContreVisite(m_oAgent)
        Assert.AreEqual("TEST2", oDiag2.inspecteurNom)
        Assert.AreEqual(Globals.GLOB_DIAG_NOMAGR, oDiag2.organismeOrigineInspNom)
        Assert.IsTrue(oDiag2.organismeOriginePresNom = Globals.GLOB_DIAG_NOMAGR)
        Assert.IsTrue(oDiag2.controleDateDernierControle = sDateFin)
        Assert.IsTrue(oDiag2.controleIsComplet = False)
        Assert.IsTrue(oDiag2.isATGIP = False)
        Assert.IsTrue(oDiag2.isTGIP = False)
        Assert.IsTrue(oDiag2.isFacture = False)
        Assert.IsTrue(oDiag2.isSynchro = False)
        Assert.AreEqual("Nom Inspecteur Origine", oDiag2.inspecteurOrigineNom)
        Assert.AreEqual("Prénom Inspecteur d'Origine", oDiag2.inspecteurOriginePrenom)





    End Sub
    <TestMethod()> _
    Public Sub TST_SetPulverisateurModeleBuse()
        Dim oDiag As Diagnostic
        Dim poPulve As New Pulverisateur
        oDiag = New Diagnostic
        poPulve.id = "E001-1"
        poPulve.ancienIdentifiant = "ANCID"
        poPulve.marque = "MARQUEPULVE"
        poPulve.modele = "MODELEPULVE"
        poPulve.type = "TYPEPULVE"
        poPulve.capacite = 100
        poPulve.largeur = "3.5"
        poPulve.nombreRangs = "15"
        poPulve.largeurPlantation = "15"
        poPulve.isVentilateur = True
        poPulve.isDebrayage = True
        poPulve.anneeAchat = 1970
        poPulve.surfaceParAn = 10
        poPulve.nombreUtilisateurs = 2
        poPulve.isCuveRincage = True
        poPulve.capaciteCuveRincage = 20
        poPulve.isRotobuse = True
        poPulve.isRinceBidon = True
        poPulve.isBidonLaveMain = True
        poPulve.isLanceLavage = True
        poPulve.isCuveIncorporation = True
        poPulve.categorie = "Rampe"
        poPulve.attelage = Pulverisateur.ATTELAGE_PORTE
        poPulve.regulation = "DPM"
        poPulve.pulverisation = "Jet projeté"
        poPulve.emplacementIdentification = "Emplacement"

        poPulve.buseMarque = "BUSEMARQUE"
        poPulve.buseModele = "BUSEModele"
        poPulve.buseAge = 5
        poPulve.nombreBuses = 10
        poPulve.buseType = "A FENTE"
        poPulve.buseAngle = "90"
        poPulve.buseFonctionnement = "A pastille/chambre"
        poPulve.buseIsIso = True
        poPulve.manometreMarque = "MANOMARQUE"
        poPulve.manometreDiametre = "50"
        poPulve.manometreType = "MANOTYPE"
        poPulve.manometreFondEchelle = "50"
        poPulve.manometrePressionTravail = "3"

        oDiag.setPulverisateur(poPulve)

        Assert.AreEqual(oDiag.pulverisateurId, poPulve.id)

        Assert.AreEqual(oDiag.buseMarque, poPulve.buseMarque)
        Assert.AreEqual(oDiag.buseModele, poPulve.buseModele)
        Assert.AreEqual(oDiag.buseCouleur, "")
        Assert.AreEqual(oDiag.buseGenre, "")
        Assert.AreEqual(oDiag.buseCalibre, "")
        Assert.AreEqual(oDiag.buseDebit, "")
        Assert.AreEqual(oDiag.buseDebit2bars, "")
        Assert.AreEqual(oDiag.buseDebit3bars, "")
        Assert.AreEqual(oDiag.buseAge, poPulve.buseAge.ToString())
        Assert.AreEqual(oDiag.buseNbBuses, poPulve.nombreBuses.ToString())
        Assert.AreEqual(oDiag.buseType, poPulve.buseType)
        Assert.AreEqual(oDiag.buseAngle, poPulve.buseAngle)
        '        Assert.AreEqual(oDiag.buseFonctionnementIsStandard, False)
        '       Assert.AreEqual(oDiag.buseFonctionnementIsPastilleChambre, True)
        '      Assert.AreEqual(oDiag.buseFonctionnementIsInjectionAirLibre, False)
        '     Assert.AreEqual(oDiag.buseFonctionnementIsInjectionAirForce, False)
        Assert.AreEqual(oDiag.buseIsISO, poPulve.buseIsIso)
        Assert.AreEqual(oDiag.pulverisateurRegulation, poPulve.regulation)


        Dim bReturn As Boolean
        Dim oDiag2 As Diagnostic
        Dim id As String
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.id = id
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual(oDiag.buseModele, oDiag2.buseModele)

        oDiag2.buseModele = "MODELE2"

        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)

        Assert.AreEqual(oDiag.buseModele, oDiag2.buseModele)

        bReturn = DiagnosticManager.delete(id)

    End Sub

    <TestMethod()>
    Public Sub Get_Send_WSBuseModele()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim idDiag As String
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        oExploit = createExploitation()
        oPulve = createPulve(oExploit)

        'Creation d'un Diagnostic
        '============================

        oDiag = createDiagnostic(oExploit, oPulve)
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
        oDiag.buseMarque = "BUSEMARQUE"
        oDiag.buseModele = "BUSEMODELE"
        oDiag.buseType = "BUSETYPE"



        'SAuvegarde du Diag
        '====================
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        'Synchronisation Ascendante du Diag
        '========================
        Dim oSynchro As New Synchronisation(m_oAgent)
        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        'Synchronisation descendate du Diag
        '==================================
        'On simule une MAJ sur ler Server
        pause(1000)
        oDiag.dateModificationCrodip = CSDate.GetDateForWS(Now())
        Dim UpdateInfo As Object
        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag, UpdateInfo)


        'Suppression du diag par sécurité 
        DiagnosticManager.delete(oDiag.id)
        '======================================
        'on Simule la date de dernière synchro de l'agent à -1 munites
        '======================================
        m_oAgent.dateDerniereSynchro = CSDate.GetDateForWS(CDate(oDiag.dateModificationAgent).AddMinutes(-1))
        Dim obj As Object
        AgentManager.sendWSAgent(m_oAgent, obj)

        Dim oLstSynchro As List(Of SynchronisationElmt)
        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        Assert.AreNotEqual(0, oLstSynchro.Count)

        For Each oSynchroElmt In oLstSynchro
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
        Assert.AreEqual("BUSEMARQUE", oDiag2.buseMarque)
        Assert.AreEqual("BUSETYPE", oDiag.buseType)
        Assert.AreEqual("BUSEMODELE", oDiag2.buseModele)





        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub
    '''<summary>
    '''Test pour pour les properties Version4 Lot3
    ''' BuseModele
    ''' RIFileName
    ''' SMFileName
    '''</summary>
    <TestMethod()> _
    Public Sub TST_PropertiesV4L3()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String

        oDiag = New Diagnostic()
        oDiag.setOrganisme(m_oAgent)
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.id = id


        'V2.5.3
        oDiag.buseModele = "MONMODELE"
        oDiag.RIFileName = "RI.PDF"
        oDiag.SMFileName = "SM.PDF"
        oDiag.pulverisateurRegulation = "DPM"
        oDiag.pulverisateurRegulationOptions = "Débit"
        oDiag.pulverisateurModeUtilisation = "CUMA"
        oDiag.pulverisateurNbreExploitants = "5"
        oDiag.buseFonctionnement = "standard"
        oDiag.pulverisateurCategorie = "Rampe"
        oDiag.pulverisateurPulverisation = "Jet dirigé"

        Assert.AreEqual("MONMODELE", oDiag.buseModele)
        Assert.AreEqual("RI.PDF", oDiag.RIFileName)
        Assert.AreEqual("SM.PDF", oDiag.SMFileName)
        Assert.AreEqual("DPM", oDiag.pulverisateurRegulation)
        Assert.AreEqual("Débit", oDiag.pulverisateurRegulationOptions)
        Assert.AreEqual("CUMA", oDiag.pulverisateurModeUtilisation)
        Assert.AreEqual("standard", oDiag.buseFonctionnement)
        Assert.AreEqual("Rampe", oDiag.pulverisateurCategorie)
        Assert.AreEqual("Jet dirigé", oDiag.pulverisateurPulverisation)

        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual("MONMODELE", oDiag2.buseModele)
        Assert.AreEqual("RI.PDF", oDiag2.RIFileName)
        Assert.AreEqual("SM.PDF", oDiag2.SMFileName)
        Assert.AreEqual("DPM", oDiag2.pulverisateurRegulation)
        Assert.AreEqual("Débit", oDiag2.pulverisateurRegulationOptions)
        Assert.AreEqual("CUMA", oDiag2.pulverisateurModeUtilisation)
        Assert.AreEqual("5", oDiag2.pulverisateurNbreExploitants)
        Assert.AreEqual("standard", oDiag2.buseFonctionnement)
        Assert.AreEqual("Rampe", oDiag2.pulverisateurCategorie)
        Assert.AreEqual("Jet dirigé", oDiag2.pulverisateurPulverisation)

        oDiag2.buseModele = "MODELE2"
        oDiag2.RIFileName = "RI2.PDF"
        oDiag2.SMFileName = "SM2.PDF"
        oDiag2.pulverisateurRegulation = "DPA"
        oDiag2.pulverisateurRegulationOptions = "Pression"
        oDiag2.pulverisateurModeUtilisation = "GAEC"
        oDiag2.pulverisateurNbreExploitants = "2"
        oDiag2.buseFonctionnement = "INJECTION"
        oDiag2.pulverisateurCategorie = "Axial"
        oDiag2.pulverisateurPulverisation = "Jet projeté"

        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual("MODELE2", oDiag.buseModele)
        Assert.AreEqual("RI2.PDF", oDiag.RIFileName)
        Assert.AreEqual("SM2.PDF", oDiag.SMFileName)
        Assert.AreEqual("DPA", oDiag.pulverisateurRegulation)
        Assert.AreEqual("Pression", oDiag.pulverisateurRegulationOptions)
        Assert.AreEqual("GAEC", oDiag.pulverisateurModeUtilisation)
        Assert.AreEqual("2", oDiag.pulverisateurNbreExploitants)
        Assert.AreEqual("INJECTION", oDiag.buseFonctionnement)
        Assert.AreEqual("Axial", oDiag.pulverisateurCategorie)
        Assert.AreEqual("Jet projeté", oDiag.pulverisateurPulverisation)


        Dim UpdatedObject As Object
        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)
        Assert.AreEqual("MODELE2", oDiag2.buseModele)
        Assert.AreEqual("RI2.PDF", oDiag2.RIFileName)
        Assert.AreEqual("SM2.PDF", oDiag2.SMFileName)
        Assert.AreEqual("DPA", oDiag2.pulverisateurRegulation)
        Assert.AreEqual("Pression", oDiag2.pulverisateurRegulationOptions)
        Assert.AreEqual("GAEC", oDiag2.pulverisateurModeUtilisation)
        Assert.AreEqual("2", oDiag2.pulverisateurNbreExploitants)
        Assert.AreEqual("INJECTION", oDiag2.buseFonctionnement)
        Assert.AreEqual("Axial", oDiag2.pulverisateurCategorie)
        Assert.AreEqual("Jet projeté", oDiag2.pulverisateurPulverisation)

        pause(2000)

        oDiag2.buseModele = "MODELE3"
        oDiag2.RIFileName = "RI3.PDF"
        oDiag2.SMFileName = "SM3.PDF"
        oDiag2.pulverisateurRegulation = "Pression constante"
        oDiag2.pulverisateurRegulationOptions = "Débit|Pression"
        oDiag2.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
        oDiag2.pulverisateurModeUtilisation = "Indiv."
        oDiag2.pulverisateurNbreExploitants = ""
        oDiag2.buseFonctionnement = "PASTILLE"
        oDiag2.pulverisateurCategorie = "Canon"
        oDiag2.pulverisateurPulverisation = "Pneumatique"
        DiagnosticManager.save(oDiag2)
        oDiag2 = DiagnosticManager.getDiagnosticById(oDiag2.id)

        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag2, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)

        Assert.AreEqual("MODELE3", oDiag2.buseModele)
        Assert.AreEqual("RI3.PDF", oDiag2.RIFileName)
        Assert.AreEqual("SM3.PDF", oDiag2.SMFileName)
        Assert.AreEqual("Pression constante", oDiag2.pulverisateurRegulation)
        Assert.AreEqual("Débit|Pression", oDiag2.pulverisateurRegulationOptions)
        Assert.AreEqual("Indiv.", oDiag2.pulverisateurModeUtilisation)
        Assert.AreEqual("", oDiag2.pulverisateurNbreExploitants)
        Assert.AreEqual("PASTILLE", oDiag2.buseFonctionnement)
        Assert.AreEqual("Canon", oDiag2.pulverisateurCategorie)
        Assert.AreEqual("Pneumatique", oDiag2.pulverisateurPulverisation)


        bReturn = DiagnosticManager.delete(id)

    End Sub
    ''' <summary>
    ''' Test du calcul de la date de prochain controle
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub TST_DateProchainControle()
        Dim oDiag As Diagnostic
        Dim poPulve As Pulverisateur

        'Etat Pulvé = nouveau
        '======================
        poPulve = New Pulverisateur()
        poPulve.id = "E001-1"
        poPulve.controleEtat = ""
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("15/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result OK => + 5 ans
        oDiag.controleEtat = Diagnostic.controleEtatOK
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2020-12-15 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CV => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.id = "E001-1"
        poPulve.controleEtat = ""
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("15/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CV => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2016-04-15 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CC => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.id = "E001-1"
        poPulve.controleEtat = ""
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("15/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CC => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2016-04-15 00:00:00", oDiag.pulverisateurDateProchainControle)


        'Etat Pulvé = OK
        '======================
        poPulve = New Pulverisateur()
        poPulve.id = "E001-1"
        poPulve.controleEtat = Pulverisateur.controleEtatOK
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("16/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result OK => + 5 ans
        oDiag.controleEtat = Diagnostic.controleEtatOK
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2020-12-16 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CV => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        poPulve.id = "E001-1"
        poPulve.controleEtat = "1"
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("16/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CV => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2016-04-16 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CC => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        poPulve.id = "E001-1"
        poPulve.controleEtat = Pulverisateur.controleEtatOK
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("16/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CC => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2016-04-16 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Etat Pulvé = En attente de CComplet -1
        '======================
        poPulve = New Pulverisateur()
        poPulve.id = "E001-1"
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCC
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("17/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result OK => + 5 ans
        oDiag.controleEtat = Diagnostic.controleEtatOK
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2020-12-17 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CV => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        poPulve.id = "E001-1"
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCC
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("17/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CV => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2015-12-20 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CC => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCC
        poPulve.id = "E001-1"
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("16/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CC => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2015-12-20 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Etat Pulvé = En attente de CV 0
        '======================
        poPulve = New Pulverisateur()
        poPulve.id = "E001-1"
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCV
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("17/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result OK => + 5 ans
        oDiag.controleEtat = Diagnostic.controleEtatOK
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2020-12-17 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CV => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        poPulve.id = "E001-1"
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCV
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("17/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CV => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2015-12-20 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CC => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.dateProchainControle = CSDate.ToCRODIPString("20/12/2015")
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCV
        poPulve.id = "E001-1"
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("16/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CC => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2015-12-20 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Etat Pulvé = En attente de CV ou CC mais Controle complet car dépassement de la date limite
        '======================
        poPulve = New Pulverisateur()
        poPulve.id = "E001-1"
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCV
        poPulve.dateProchainControle = CSDate.ToCRODIPString("1/12/2015")
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("17/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result OK => + 5 ans
        oDiag.controleEtat = Diagnostic.controleEtatOK
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2020-12-17 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CV => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.dateProchainControle = CSDate.ToCRODIPString("01/12/2015")
        poPulve.id = "E001-1"
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCV
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("17/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CV => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2016-04-17 00:00:00", oDiag.pulverisateurDateProchainControle)

        'Result CC => + 4 mois
        poPulve = New Pulverisateur()
        poPulve.dateProchainControle = CSDate.ToCRODIPString("01/12/2015")
        poPulve.controleEtat = Pulverisateur.controleEtatNOKCV
        poPulve.id = "E001-1"
        oDiag = New Diagnostic()
        oDiag.setPulverisateur(poPulve)
        oDiag.controleDateDebut = CSDate.ToCRODIPString("17/12/2015")
        'Controle Complet
        oDiag.controleIsComplet = True
        'Result CC => + 4 mois
        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        oDiag.CalculDateProchainControle()
        Assert.AreEqual("2016-04-17 00:00:00", oDiag.pulverisateurDateProchainControle)
    End Sub
    <TestMethod()> _
    Public Sub TST_BuseFonctionnement()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String

        oDiag = New Diagnostic()
        oDiag.setOrganisme(m_oAgent)
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.id = id


        'V2.5.3
        oDiag.buseFonctionnement = "A INJECTION D'AIR"
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual("A INJECTION D'AIR", oDiag2.buseFonctionnement)

        oDiag2.buseFonctionnement = "A PASTILLE"
        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        Assert.AreEqual("A PASTILLE", oDiag2.buseFonctionnement)


        Dim UpdatedObject As Object
        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag2, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)
        Assert.AreEqual("A PASTILLE", oDiag2.buseFonctionnement)

        pause(2000)
        DiagnosticManager.save(oDiag2)
        oDiag2 = DiagnosticManager.getDiagnosticById(oDiag2.id)

        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag2, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)

        Assert.AreEqual("A PASTILLE", oDiag2.buseFonctionnement)


        bReturn = DiagnosticManager.delete(id)

    End Sub

    <TestMethod()> _
    Public Sub TST_BuseFonctionnementEncodage()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String
        Dim lstFonctionnement As List(Of String)
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim UpdatedObject As Object

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)


        Dim oRef As New ReferentielBusesCSV()
        oRef.load()
        lstFonctionnement = oRef.getFonctionnementsBuse("BUSES A FENTE")
        Assert.AreEqual(4, lstFonctionnement.Count)
        For Each strFonctionnement As String In lstFonctionnement
            oPulve.buseFonctionnement = strFonctionnement
            oDiag = New Diagnostic()
            oDiag.setOrganisme(m_oAgent)
            id = "TST" & Now.Hour & Now.Minute & Now.Second
            oDiag.id = id
            oDiag.SetProprietaire(oExploit)
            oDiag.setPulverisateur(oPulve)

            bReturn = DiagnosticManager.save(oDiag)

            DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag, UpdatedObject)
            pause(2000)
            oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)

            Assert.AreEqual(strFonctionnement, oDiag2.buseFonctionnement)


        Next

    End Sub

    '''<summary>
    '''Test du de la liste des Diag par Pulve_id
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetLstDiagByPulveId()
        Dim bReturn As Boolean
        Dim id As String
        Dim oDiag As Diagnostic

        '=====
        ' Arrange
        '======
        'suppression des Diag Existant si necessaire
        Dim oLst As List(Of Diagnostic)
        oLst = DiagnosticManager.getlstDiagnosticByPulveId("PULVETEST")
        For Each oDiag In oLst
            DiagnosticManager.delete(oDiag.id)
        Next

        oLst = DiagnosticManager.getlstDiagnosticByPulveId("PULVETEST2")
        For Each oDiag In oLst
            DiagnosticManager.delete(oDiag.id)
        Next


        '==========
        ' Act
        '==========
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        id = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationAgent = CDate("06/02/1964")
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag = New Diagnostic()
        id = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationAgent = CDate("06/02/1964")
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag = New Diagnostic()
        id = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST2"
        oDiag.id = id
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationAgent = CDate("06/02/1964")
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)


        '=========
        'Assert
        '=========
        oLst = DiagnosticManager.getlstDiagnosticByPulveId("PULVETEST")
        Assert.AreEqual(2, oLst.Count)
        For Each oDiag In oLst
            Assert.AreEqual("PULVETEST", oDiag.pulverisateurId)
        Next


        '==========
        'Clean
        '==========
        oLst = DiagnosticManager.getlstDiagnosticByPulveId("PULVETEST")
        For Each oDiag In oLst
            DiagnosticManager.delete(oDiag.id)
        Next

        oLst = DiagnosticManager.getlstDiagnosticByPulveId("PULVETEST2")
        For Each oDiag In oLst
            DiagnosticManager.delete(oDiag.id)
        Next


    End Sub
    ''' <summary>
    ''' Test l'utilisation du Banc de mesures et du manodeControle Utilise
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> _
    Public Sub TestUtilisationBancEtMano()

        Dim id As String
        Dim oDiag As Diagnostic
        Dim oBanc As Banc
        Dim oManoC As ManometreControle

        '=====
        ' Arrange
        '======
        'Creation d'un banc de mesures
        oBanc = New Banc()
        oBanc.id = BancManager.FTO_getNewId(m_oAgent)
        oBanc.numeroNational = oBanc.id
        oBanc.marque = "Banc de test"
        BancManager.save(oBanc)

        'Création un mano de controle
        oManoC = New ManometreControle()
        oManoC.idCrodip = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oManoC.numeroNational = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oManoC.idStructure = m_oAgent.idStructure
        oManoC.marque = "Manoc de test"
        ManometreControleManager.save(oManoC)

        '==========
        ' Act
        '==========
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        id = DiagnosticManager.getNewId(m_oAgent)
        oDiag.pulverisateurId = "PULVETEST"
        oDiag.id = id
        oDiag.organismePresId = m_oAgent.idStructure
        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.inspecteurId = m_oAgent.id
        oDiag.dateModificationAgent = CDate("06/02/1964")
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today

        oDiag.controleManoControleNumNational = oManoC.numeroNational
        oDiag.controleBancMesureId = oBanc.numeroNational

        '        bReturn = DiagnosticManager.save(oDiag)
        '        Assert.IsTrue(bReturn)



        '=========
        'Assert
        '=========
        Assert.IsTrue(oDiag.setUtiliseBancEtMano(m_oAgent))

        oBanc = BancManager.getBancById(oDiag.controleBancMesureId)
        Assert.IsNotNull(oBanc)
        Assert.IsTrue(oBanc.isUtilise)
        Assert.AreEqual(1, oBanc.nbControles)
        Assert.AreEqual(1, oBanc.nbControlesTotal)

        oManoC = ManometreControleManager.getManometreControleByNumeroNational(oDiag.controleManoControleNumNational)
        Assert.IsNotNull(oManoC)
        Assert.IsTrue(oManoC.isUtilise)
        Assert.AreEqual(1, oManoC.nbControles)
        Assert.AreEqual(1, oManoC.nbControlesTotal)

        oDiag.setUtiliseBancEtMano(m_oAgent)

        oBanc = BancManager.getBancById(oDiag.controleBancMesureId)
        Assert.IsNotNull(oBanc)
        Assert.IsTrue(oBanc.isUtilise)
        Assert.AreEqual(2, oBanc.nbControles)
        Assert.AreEqual(2, oBanc.nbControlesTotal)

        oManoC = ManometreControleManager.getManometreControleByNumeroNational(oDiag.controleManoControleNumNational)
        Assert.IsNotNull(oManoC)
        Assert.IsTrue(oManoC.isUtilise)
        Assert.AreEqual(2, oManoC.nbControles)
        Assert.AreEqual(2, oManoC.nbControlesTotal)


        '==========
        'Clean
        '==========
        BancManager.delete(oBanc.numeroNational)
        ManometreControleManager.delete(oManoC.numeroNational)

    End Sub
    '''<summary>
    '''Test pour les properties du ticket 17700 (Nvx Equipements
    ''' ccFileName, CoupureAutoTroncons, ReglageAutoHauteur
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Properties17700()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String

        oDiag = New Diagnostic()
        oDiag.setOrganisme(m_oAgent)
        id = "DIAG" & Now.Hour & Now.Minute & Now.Second
        oDiag.id = id


        'V2.5.3
        oDiag.buseModele = "MONMODELE"
        oDiag.RIFileName = "RI.PDF"
        oDiag.SMFileName = "SM.PDF"
        oDiag.CCFileName = "CC.PDF"
        oDiag.pulverisateurRegulation = "DPM"
        oDiag.pulverisateurRegulationOptions = "Débit"
        oDiag.pulverisateurModeUtilisation = "CUMA"
        oDiag.pulverisateurNbreExploitants = "5"
        oDiag.buseFonctionnement = "standard"
        oDiag.pulverisateurCategorie = "Rampe"
        oDiag.pulverisateurPulverisation = "Jet dirigé"
        oDiag.pulverisateurCoupureAutoTroncons = "OUI"
        oDiag.pulverisateurReglageAutoHauteur = "OUI"
        oDiag.pulverisateurRincagecircuit = "OUI"

        Assert.AreEqual("CC.PDF", oDiag.CCFileName)
        Assert.AreEqual("OUI", oDiag.pulverisateurCoupureAutoTroncons)
        Assert.AreEqual("OUI", oDiag.pulverisateurReglageAutoHauteur)
        Assert.AreEqual("OUI", oDiag.pulverisateurRincagecircuit)

        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual("CC.PDF", oDiag2.CCFileName)
        Assert.AreEqual("OUI", oDiag2.pulverisateurCoupureAutoTroncons)
        Assert.AreEqual("OUI", oDiag2.pulverisateurReglageAutoHauteur)
        Assert.AreEqual("OUI", oDiag2.pulverisateurRincagecircuit)

        oDiag2.CCFileName = "CC2.PDF"
        oDiag2.pulverisateurCoupureAutoTroncons = "NON"
        oDiag2.pulverisateurReglageAutoHauteur = "NON"
        oDiag2.pulverisateurRincagecircuit = "NON"

        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual("CC2.PDF", oDiag.CCFileName)
        Assert.AreEqual("NON", oDiag.pulverisateurCoupureAutoTroncons)
        Assert.AreEqual("NON", oDiag.pulverisateurReglageAutoHauteur)
        Assert.AreEqual("NON", oDiag.pulverisateurRincagecircuit)


        Dim UpdatedObject As Object
        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)
        Assert.AreEqual("CC2.PDF", oDiag2.CCFileName)
        Assert.AreEqual("NON", oDiag2.pulverisateurCoupureAutoTroncons)
        Assert.AreEqual("NON", oDiag2.pulverisateurReglageAutoHauteur)
        Assert.AreEqual("NON", oDiag2.pulverisateurRincagecircuit)

        pause(2000)

        oDiag2.CCFileName = "CC3.PDF"
        oDiag2.pulverisateurCoupureAutoTroncons = "OUI"
        oDiag2.pulverisateurReglageAutoHauteur = "OUI"
        oDiag2.pulverisateurRincagecircuit = "OUI"
        DiagnosticManager.save(oDiag2)
        oDiag2 = DiagnosticManager.getDiagnosticById(oDiag2.id)

        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag2, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, oDiag2.id)

        Assert.AreEqual("CC3.PDF", oDiag2.CCFileName)
        Assert.AreEqual("OUI", oDiag2.pulverisateurCoupureAutoTroncons)
        Assert.AreEqual("OUI", oDiag2.pulverisateurReglageAutoHauteur)
        Assert.AreEqual("OUI", oDiag2.pulverisateurRincagecircuit)


        bReturn = DiagnosticManager.delete(id)

    End Sub
    '''<summary>
    '''Test pour les properties typeEquiement etCodeInsee
    '''</summary>
    <TestMethod()> _
    Public Sub TST_typeDiagnosticetCodeInsee()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur


        oExploit = createExploitation()
        oExploit.codePostal = "35250"
        oExploit.commune = "CHASNE SUR ILLET"
        ExploitationManager.save(oExploit, m_oAgent)
        oPulve = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)


        oDiag = New Diagnostic()
        Assert.AreEqual("pulverisateur", oDiag.typeDiagnostic)
        oDiag.setOrganisme(m_oAgent)
        oDiag.setPulverisateur(oPulve)
        oDiag.SetProprietaire(oExploit)
        Assert.AreEqual("pulverisateur", oDiag.typeDiagnostic)
        Assert.AreEqual("35067", oDiag.codeInsee)

        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        id = oDiag.id
        bReturn = DiagnosticManager.save(oDiag)
        Assert.IsTrue(bReturn)

        oDiag2 = New Diagnostic()
        oDiag2 = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual("pulverisateur", oDiag2.typeDiagnostic)
        Assert.AreEqual("35067", oDiag2.codeInsee)

        oDiag2.typeDiagnostic = "equipement"
        oDiag2.codeInsee = "35068"

        Assert.IsTrue(DiagnosticManager.save(oDiag2))
        oDiag = DiagnosticManager.getDiagnosticById(id)
        Assert.AreEqual("equipement", oDiag.typeDiagnostic)
        Assert.AreEqual("35068", oDiag.codeInsee)




        Dim UpdatedObject As Object
        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag, UpdatedObject)

        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, id)
        Assert.AreEqual("equipement", oDiag2.typeDiagnostic)
        Assert.AreEqual("35068", oDiag2.codeInsee)

        pause(2000)

        oDiag2.typeDiagnostic = "pulverisateur"
        oDiag2.codeInsee = "35067"
        DiagnosticManager.save(oDiag2)
        oDiag2 = DiagnosticManager.getDiagnosticById(oDiag2.id)
        DiagnosticManager.sendWSDiagnostic(m_oAgent, oDiag2, UpdatedObject)
        oDiag2 = DiagnosticManager.getWSDiagnosticById(m_oAgent.id, oDiag2.id)

        Assert.AreEqual("pulverisateur", oDiag2.typeDiagnostic)
        Assert.AreEqual("35067", oDiag2.codeInsee)


        bReturn = DiagnosticManager.delete(id)

        oPulve.isPulveAdditionnel = True
        oDiag.setPulverisateur(oPulve)
        Assert.AreEqual("equipement", oDiag.typeDiagnostic)
        oPulve.isPulveAdditionnel = False
        oDiag.setPulverisateur(oPulve)
        Assert.AreEqual("pulverisateur", oDiag.typeDiagnostic)

        oExploit.codePostal = "35250"
        oExploit.commune = "CHASNE SUR ILLET"
        oDiag.SetProprietaire(oExploit)
        Assert.AreEqual("35067", oDiag.codeInsee)
        oExploit.codePostal = "35220"
        oExploit.commune = "CHATEAUBOURG"
        oDiag.SetProprietaire(oExploit)
        Assert.AreEqual("35068", oDiag.codeInsee)

    End Sub
    '''<summary>
    '''Test des date de prochain controle
    '''</summary>
    <TestMethod()> _
    Public Sub TST_getDiagPourCV()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim bReturn As Boolean
        Dim id As String
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur
        Dim oList As List(Of Diagnostic)

        oExploit = createExploitation()
        oExploit.codePostal = "35250"
        oExploit.commune = "CHASNE SUR ILLET"
        ExploitationManager.save(oExploit, m_oAgent)
        oPulve = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic()
        Assert.AreEqual("pulverisateur", oDiag.typeDiagnostic)
        oDiag.setOrganisme(m_oAgent)
        oDiag.setPulverisateur(oPulve)
        oDiag.SetProprietaire(oExploit)
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = CSDate.ToCRODIPString(CDate("2016/09/26 18:07:30"))
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        id = oDiag.id
        DiagnosticManager.save(oDiag)

        oList = DiagnosticManager.getDiagnosticPourContreVisite(oPulve.id, m_oAgent.idStructure, "", CDate("2017/01/26 18:08"))
        Assert.AreEqual(1, oList.Count)

        oDiag = DiagnosticManager.getWSDiagnosticById(1123, "27-1123-580")

    End Sub
    <TestMethod()>
    <Ignore()>
    Public Sub TST_Diag499_1121_269Prod()
        Dim oDiag As Diagnostic

        agentCourant.id = 1121
        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
        objWSCrodip.Url = "http://admin.crodip.fr/server"
        oDiag = DiagnosticManager.getWSDiagnosticById(1127, "499-1121-269")
        DiagnosticManager.save(oDiag)
        DiagnosticItemManager.getWSDiagnosticItemsByDiagnosticId(agentCourant, oDiag.id)
        DiagnosticManager.save(oDiag)
        Dim oDiagBusesList As DiagnosticBusesList
        oDiagBusesList = DiagnosticBusesManager.getWSDiagnosticBusesById(oDiag.id)
        For Each oDiagBuses As DiagnosticBuses In oDiagBusesList.Liste
            DiagnosticBusesManager.save(oDiagBuses)
        Next
        Dim oDiagBusesDetailList As DiagnosticBusesDetailList
        oDiagBusesDetailList = DiagnosticBusesDetailManager.getWSDiagnosticBusesDetailById(oDiag.id)
        For Each oDiagBusesDetail As DiagnosticBusesDetail In oDiagBusesDetailList.Liste
            DiagnosticBusesDetailManager.save(oDiagBusesDetail)
        Next


        oDiag = DiagnosticManager.getDiagnosticById(oDiag.id)

        Dim oEtat As New EtatSyntheseMesures(oDiag)
        oEtat.GenereEtat()
        oEtat.Open()


    End Sub
End Class
