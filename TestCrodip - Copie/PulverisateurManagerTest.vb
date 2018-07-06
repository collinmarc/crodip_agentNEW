Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour PulverisateurManagerTest, destinée à contenir tous
'''les tests unitaires PulverisateurManagerTest
'''</summary>
<TestClass()> _
Public Class PulverisateurManagerTest
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
    '<TestInitialize()> _
    'Public Sub MyTestInitialize()
    '    'Creation d'un agent
    '    m_oAgent = AgentManager.createAgent("AGENT_TEST_01", "Nouveau")
    '    m_oAgent.idStructure = 99
    '    m_oAgent.nom = "Agent de test"
    '    m_oAgent.prenom = "Agent de test"
    '    AgentManager.save(m_oAgent)
    '    Assert.IsNotNull(m_oAgent, "erreur en création d'un agent")

    'End Sub
    ''
    ''Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    '<TestCleanup()> _
    'Public Sub MyTestCleanup()
    '    Dim bReturn As Boolean
    '    If Not m_oAgent Is Nothing Then
    '        bReturn = AgentManager.delete(m_oAgent.id)

    '        Assert.IsTrue(bReturn)
    '    End If

    'End Sub
    '
#End Region



    <TestMethod()>
    Public Sub Get_Send_WS_TestPRD()
        PulverisateurManager.getWSPulverisateurById(m_oAgent, "4-23-15")
    End Sub

    <TestMethod()>
    Public Sub Get_Send_WS_Test()


        Dim oPulve As New Pulverisateur()
        Dim oPulve2 As Pulverisateur
        Dim bReturn As Boolean
        Dim UpdatedObject As Object
        Dim response As Integer

        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreNotEqual("", oPulve.id)

        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"
        oPulve.buseNbniveaux = 2
        oPulve.nombreBuses = 10
        oPulve.manometreNbniveaux = 1
        oPulve.manometreNbtroncons = 5
        'oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        'oPulve.categorie =Pulverisateur.CATEGORIEPULVE_JETDIRIGE)
        'oPulve.setLargeurNbreRangs("16")
        'Assert.AreEqual("16", oPulve.LargeurNombreRangs)

        'bReturn = PulverisateurManager.save(oPulve, 88)
        'Assert.IsTrue(bReturn)

        'response = PulverisateurManager.sendWSPulverisateur(m_oAgent,oPulve, UpdatedObject)
        'Assert.IsTrue(response = 0 Or response = 2)

        'oPulve2 = PulverisateurManager.getWSPulverisateurById(oPulve.id)


        'Assert.AreEqual(oPulve.id, oPulve2.id)
        'Assert.AreEqual(oPulve.marque, oPulve2.marque)
        'Assert.AreEqual(oPulve.modele, oPulve2.modele)
        'Assert.AreEqual(oPulve.type, oPulve2.type)
        'Assert.AreEqual(oPulve.categorie, oPulve2.categorie)
        'Assert.AreEqual(oPulve.LargeurNombreRangs, oPulve2.LargeurNombreRangs)
        ''        Assert.AreEqual(oPulve.largeur, oPulve2.largeur)
        'Assert.AreEqual(oPulve.nombreRangs, oPulve2.nombreRangs)

        'Transformation du type de pulvé
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
        oPulve.setLargeurNbreRangs("15.50")
        Assert.AreEqual(oPulve.largeur, "15.5")
        oPulve.emplacementIdentification = "TESTIDENT"
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        Assert.IsTrue(bReturn)

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)


        Assert.AreEqual(oPulve.id, oPulve2.id)
        Assert.AreEqual(oPulve.marque, oPulve2.marque)
        Assert.AreEqual(oPulve.modele, oPulve2.modele)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)
        '        Assert.AreEqual(oPulve.LargeurNombreRangs, oPulve2.LargeurNombreRangs)
        '       Assert.AreEqual(oPulve.largeur, oPulve2.largeur)
        Assert.AreEqual(oPulve.dateModificationAgent, oPulve2.dateModificationAgent)
        Assert.AreEqual(oPulve.emplacementIdentification, oPulve2.emplacementIdentification)
        Assert.AreEqual(2, oPulve.buseNbniveaux)
        Assert.AreEqual(10, oPulve.nombreBuses)
        Assert.AreEqual(1, oPulve.manometreNbniveaux)
        Assert.AreEqual(5, oPulve.manometreNbtroncons)

        'Assert.AreEqual(oPulve.nombreRangs, oPulve2.nombreRangs)


        'Suppression du pulverisateur 
        If Not oPulve Is Nothing Then
            PulverisateurManager.deletePulverisateur(oPulve)
        End If

    End Sub

    <TestMethod()>
    Public Sub TestTypeCategoriePulverisateur()


        Dim oPulve As New Pulverisateur()
        Dim oPulve2 As Pulverisateur
        Dim bReturn As Boolean

        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)

        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = (Pulverisateur.CATEGORIEPULVE_JETDIRIGE)
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)

        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = (Pulverisateur.CATEGORIEPULVE_AXIAL)
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)

        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)

        oPulve.type = Pulverisateur.TYPEPULVE_VIGNE
        oPulve.categorie = (Pulverisateur.CATEGORIEPULVE_CANON)
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)

        oPulve.type = Pulverisateur.TYPEPULVE_VIGNE
        oPulve.categorie = (Pulverisateur.CATEGORIEPULVE_VOUTE)
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)
        oPulve.type = Pulverisateur.TYPEPULVE_VIGNE
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_FACEPARFACE

        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)

        oPulve.type = Pulverisateur.TYPEPULVE_VIGNE
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_AXIAL
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)

        'Suppression du pulverisateur 
        If Not oPulve Is Nothing Then
            PulverisateurManager.deletePulverisateur(oPulve)
        End If

    End Sub

    <TestMethod()>
    Public Sub TestLargeurNbRangsPulverisateur()


        Dim oPulve As New Pulverisateur()
        Dim oPulve2 As Pulverisateur
        Dim bReturn As Boolean

        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)

        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_JETDIRIGE
        oPulve.setLargeurNbreRangs("1")
        Assert.AreEqual("1", oPulve.nombreRangs)
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)

        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)
        Assert.AreEqual(oPulve.LargeurNombreRangs, oPulve2.LargeurNombreRangs)
        Assert.AreEqual(oPulve.largeur, oPulve2.largeur)
        Assert.AreEqual(oPulve.nombreRangs, oPulve2.nombreRangs)

        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
        oPulve.setLargeurNbreRangs("12.5")
        Assert.AreEqual("12.5", oPulve.largeur.ToString())
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)
        Assert.AreEqual(oPulve.LargeurNombreRangs, oPulve2.LargeurNombreRangs())
        Assert.AreEqual(oPulve.largeur, oPulve2.largeur)
        Assert.AreEqual(oPulve.nombreRangs, oPulve2.nombreRangs)

        'Transformation de la largeur en nombre de rangs
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_JETDIRIGE
        Assert.AreEqual("", oPulve.LargeurNombreRangs)
        Assert.AreEqual("", oPulve.nombreRangs)
        Assert.AreEqual("12.5", oPulve.largeur)

        'Transformation de nombre de rangs en largeur
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
        Assert.AreEqual("12.5", oPulve.LargeurNombreRangs)
        Assert.AreEqual("", oPulve.nombreRangs)
        Assert.AreEqual("12.5", oPulve.largeur)






        'Suppression du pulverisateur 
        If Not oPulve Is Nothing Then
            PulverisateurManager.deletePulverisateur(oPulve)
        End If

    End Sub
    <TestMethod()>
    Public Sub TestPulverisateur()


        Dim oPulve As New Pulverisateur()
        Dim oPulve2 As Pulverisateur
        Dim bReturn As Boolean

        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreNotEqual("", oPulve.id)

        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_JETDIRIGE
        oPulve.setLargeurNbreRangs("15.5")
        oPulve.emplacementIdentification = "DERRIERE"
        Assert.AreEqual("15.5", oPulve.LargeurNombreRangs)

        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)

        Assert.IsTrue(bReturn)

        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)

        Assert.AreEqual(oPulve.id, oPulve2.id)
        Assert.AreEqual(oPulve.marque, oPulve2.marque)
        Assert.AreEqual(oPulve.modele, oPulve2.modele)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)
        Assert.AreEqual("15.5", oPulve2.LargeurNombreRangs)
        Assert.AreEqual(oPulve.largeur, oPulve2.largeur)
        Assert.AreEqual(oPulve.nombreRangs, oPulve2.nombreRangs)
        Assert.AreEqual(oPulve.emplacementIdentification, oPulve2.emplacementIdentification)

        'Suppression du pulverisateur 
        If Not oPulve Is Nothing Then
            PulverisateurManager.deletePulverisateur(oPulve)
        End If

    End Sub
    <TestMethod()>
    Public Sub Get_Send_WS_AncienIdentifiant()


        Dim oPulve As New Pulverisateur()
        Dim oPulve2 As Pulverisateur
        Dim bReturn As Boolean
        Dim UpdatedObject As Object
        Dim response As Integer

        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreNotEqual("", oPulve.id)

        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"
        oPulve.ancienIdentifiant = "ANCID"
        pause(1000)
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        Assert.IsTrue(bReturn)

        oPulve = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.ancienIdentifiant, oPulve.ancienIdentifiant)
        pause(1000)
        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)


        Assert.AreEqual(oPulve.id, oPulve2.id)
        Assert.AreEqual(oPulve.marque, oPulve2.marque)
        Assert.AreEqual(oPulve.modele, oPulve2.modele)
        Assert.AreEqual(oPulve.ancienIdentifiant, oPulve2.ancienIdentifiant)

        'Transformation du type de pulvé
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
        oPulve.setLargeurNbreRangs("15.50")
        Assert.AreEqual(oPulve.largeur, "15.5")
        oPulve.emplacementIdentification = "TESTIDENT"
        pause(1000)
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        Assert.IsTrue(bReturn)

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)


        Assert.AreEqual(oPulve.id, oPulve2.id)
        Assert.AreEqual(oPulve.marque, oPulve2.marque)
        Assert.AreEqual(oPulve.modele, oPulve2.modele)
        Assert.AreEqual(oPulve.type, oPulve2.type)
        Assert.AreEqual(oPulve.categorie, oPulve2.categorie)
        Assert.AreEqual(oPulve.dateModificationAgent, oPulve2.dateModificationAgent)
        Assert.AreEqual(oPulve.emplacementIdentification, oPulve2.emplacementIdentification)



        'Suppression du pulverisateur 
        If Not oPulve Is Nothing Then
            PulverisateurManager.deletePulverisateur(oPulve)
        End If

    End Sub
    <TestMethod()>
    Public Sub Get_Send_WS_DateProchainControle()


        Dim oPulve As New Pulverisateur()
        Dim oPulve2 As Pulverisateur
        Dim bReturn As Boolean
        Dim UpdatedObject As Object
        Dim response As Integer

        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreNotEqual("", oPulve.id)

        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"
        oPulve.ancienIdentifiant = "ANCID"
        oPulve.dateProchainControle = CSDate.GetDateForWS(CDate("2015-02-23"))
        Assert.AreEqual("2015-02-23 00:00:00", oPulve.dateProchainControle)


        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        Assert.IsTrue(bReturn)

        oPulve = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual("ANCID", oPulve.ancienIdentifiant)
        Assert.AreEqual("2015-02-23 00:00:00", oPulve.dateProchainControle)

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)


        Assert.AreEqual(oPulve.id, oPulve2.id)
        Assert.AreEqual(oPulve.marque, oPulve2.marque)
        Assert.AreEqual(oPulve.modele, oPulve2.modele)
        Assert.AreEqual(oPulve.ancienIdentifiant, oPulve2.ancienIdentifiant)
        Assert.AreEqual(oPulve.dateProchainControle, oPulve2.dateProchainControle)

        'Modification de la date de prochain controle
        oPulve.dateProchainControle = CSDate.GetDateForWS(CDate("2020-02-23"))
        Assert.AreEqual("2020-02-23 00:00:00", oPulve.dateProchainControle)
        bReturn = PulverisateurManager.save(oPulve, 88, m_oAgent)
        Assert.IsTrue(bReturn)

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)


        Assert.AreEqual(oPulve.id, oPulve2.id)
        Assert.AreEqual(oPulve.marque, oPulve2.marque)
        Assert.AreEqual(oPulve.modele, oPulve2.modele)
        Assert.AreEqual(oPulve.dateProchainControle, oPulve2.dateProchainControle)



        'Suppression du pulverisateur 
        If Not oPulve Is Nothing Then
            PulverisateurManager.deletePulverisateur(oPulve)
        End If

    End Sub
    <TestMethod()>
    Public Sub LargeurTEST()

        Dim oPulve As New Pulverisateur()

        oPulve.attelage = Pulverisateur.ATTELAGE_TRAINE
        Assert.AreEqual(Pulverisateur.ATTELAGE_TRAINE, oPulve.attelage)



        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
        oPulve.setLargeurNbreRangs("18")
        Assert.AreEqual("18", oPulve.LargeurNombreRangs())
        oPulve.setLargeurNbreRangs("18.00")
        Assert.AreEqual("18", oPulve.LargeurNombreRangs())

    End Sub

    <TestMethod()>
    Public Sub TestNvPointAccessoires()

        Dim oPulve As Pulverisateur

        oPulve = New Pulverisateur()

        'Test des propriétés
        Assert.IsFalse(oPulve.isEclairageRampe)
        Assert.IsFalse(oPulve.isBarreGuidage)
        Assert.IsFalse(oPulve.isCoupureAutoTroncons)
        Assert.IsFalse(oPulve.isRincageAutoAssiste)

        oPulve.isEclairageRampe = True
        oPulve.isBarreGuidage = True
        oPulve.isCoupureAutoTroncons = True
        oPulve.isRincageAutoAssiste = True

        Assert.IsTrue(oPulve.isEclairageRampe)
        Assert.IsTrue(oPulve.isBarreGuidage)
        Assert.IsTrue(oPulve.isCoupureAutoTroncons)
        Assert.IsTrue(oPulve.isRincageAutoAssiste)


        'Test INSERT
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreNotEqual("", oPulve.id)

        Assert.IsTrue(PulverisateurManager.save(oPulve, "2-81-4", m_oAgent))

        oPulve = PulverisateurManager.getPulverisateurById(oPulve.id)

        Assert.IsNotNull(oPulve)

        Assert.IsTrue(oPulve.isEclairageRampe)
        Assert.IsTrue(oPulve.isBarreGuidage)
        Assert.IsTrue(oPulve.isCoupureAutoTroncons)
        Assert.IsTrue(oPulve.isRincageAutoAssiste)

        'Test Update
        'Modif des Propriétés
        oPulve.isEclairageRampe = False
        oPulve.isBarreGuidage = False
        oPulve.isCoupureAutoTroncons = False
        oPulve.isRincageAutoAssiste = False
        'Sauvegarde
        Assert.IsTrue(PulverisateurManager.save(oPulve, "clientId", m_oAgent))
        'Lecture
        oPulve = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.IsNotNull(oPulve)
        'Test des modifs
        Assert.IsFalse(oPulve.isEclairageRampe)
        Assert.IsFalse(oPulve.isBarreGuidage)
        Assert.IsFalse(oPulve.isCoupureAutoTroncons)
        Assert.IsFalse(oPulve.isRincageAutoAssiste)

        'Test WS
        Dim UpdatedObject As Object
        Dim response As Integer
        Dim oPulve2 As Pulverisateur
        Dim oExploitToPulve As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByPulverisateurId(oPulve.id)
        ExploitationTOPulverisateurManager.sendWSExploitationTOPulverisateur(oExploitToPulve, UpdatedObject)
        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)
        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)
        Assert.IsFalse(oPulve2.isEclairageRampe)
        Assert.IsFalse(oPulve2.isBarreGuidage)
        Assert.IsFalse(oPulve2.isCoupureAutoTroncons)
        Assert.IsFalse(oPulve2.isRincageAutoAssiste)

        oPulve.isEclairageRampe = True
        oPulve.isBarreGuidage = True
        oPulve.isCoupureAutoTroncons = True
        oPulve.isRincageAutoAssiste = True
        pause(2000)
        oPulve.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)
        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)

        Assert.IsTrue(oPulve2.isEclairageRampe)
        Assert.IsTrue(oPulve2.isBarreGuidage)
        Assert.IsTrue(oPulve2.isCoupureAutoTroncons)
        Assert.IsTrue(oPulve2.isRincageAutoAssiste)


        PulverisateurManager.deletePulverisateur(oPulve)
    End Sub
    <TestMethod()>
    Public Sub TestParamDiag()
        Dim oPulve As Pulverisateur
        Dim oParamDiag As CRODIP_ControlLibrary.ParamDiag

        oPulve = New Pulverisateur()
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
        oParamDiag = oPulve.getParamDiag()
        Assert.IsNotNull(oParamDiag)
        Assert.AreEqual(oPulve.type, oParamDiag.libelle)

        oPulve = New Pulverisateur()
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_ARBOVITI2
        oParamDiag = oPulve.getParamDiag()
        Assert.IsNotNull(oParamDiag)
        Assert.AreEqual(oPulve.type, oParamDiag.libelle)

        oPulve = New Pulverisateur()
        oPulve.type = Pulverisateur.TYPEPULVE_VIGNE
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_VOUTE
        oParamDiag = oPulve.getParamDiag()
        Assert.IsNotNull(oParamDiag)
        Assert.AreEqual(oPulve.type, oParamDiag.libelle)
    End Sub

    <TestMethod()>
    Public Sub TestTransfertPulve()

        Dim oExploitOrigine = New Exploitation()
        oExploitOrigine.idStructure = m_oAgent.idStructure
        oExploitOrigine.raisonSociale = "ORIGINE"
        ExploitationManager.save(oExploitOrigine, m_oAgent)

        Dim oExploitCIBLE = New Exploitation()
        oExploitCIBLE.idStructure = m_oAgent.idStructure
        oExploitCIBLE.raisonSociale = "CIBLE"
        ExploitationManager.save(oExploitCIBLE, m_oAgent)


        Dim oPulve As New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)

        PulverisateurManager.save(oPulve, oExploitOrigine.id, m_oAgent)

        'Vérification sur le Pulve appartient bien à l'exploit d'origine
        Dim arrPulv As Pulverisateur()
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitOrigine.id, "")
        Assert.AreEqual(1, arrPulv.Length)
        Assert.AreEqual(oPulve.id, arrPulv(0).id)

        'Vérification sur le Pulve n'appartient pas à l'exploit CIBLE
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitCIBLE.id, "")
        Assert.AreEqual(0, arrPulv.Length)

        'Transfert Du pulve de l'exploit d'origine ve l'exploit Cible
        Assert.IsTrue(oPulve.TransfertPulve(oExploitOrigine.id, oExploitCIBLE.id, m_oAgent))

        'Vérification sur le Pulve n'appartient plus à l'exploit d'origine
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitOrigine.id, "")
        Assert.AreEqual(0, arrPulv.Length)

        'Vérification sur le Pulve appartient  à l'exploit CIBLE
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitCIBLE.id, "")
        Assert.AreEqual(1, arrPulv.Length)
        Assert.AreEqual(oPulve.id, arrPulv(0).id)

        PulverisateurManager.deletePulverisateurID(oPulve.id)
        ExploitationManager.delete(oExploitCIBLE.id)
        ExploitationManager.delete(oExploitOrigine.id)

    End Sub
    ''' <summary>
    ''' Test du transfert de Pulve avec le WS
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestTransfertPulveWS()

        Dim oExploitOrigine = New Exploitation()
        oExploitOrigine.idStructure = m_oAgent.idStructure
        oExploitOrigine.raisonSociale = "ORIGINE"
        ExploitationManager.save(oExploitOrigine, m_oAgent)

        Dim oExploitCIBLE = New Exploitation()
        oExploitCIBLE.idStructure = m_oAgent.idStructure
        oExploitCIBLE.raisonSociale = "CIBLE"
        ExploitationManager.save(oExploitCIBLE, m_oAgent)


        Dim oPulve As New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)

        PulverisateurManager.save(oPulve, oExploitOrigine.id, m_oAgent)

        'Vérification sur le Pulve appartient bien à l'exploit d'origine
        Dim arrPulv As Pulverisateur()
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitOrigine.id, "")
        Assert.AreEqual(1, arrPulv.Length)
        Assert.AreEqual(oPulve.id, arrPulv(0).id)

        'Vérification sur le Pulve n'appartient pas à l'exploit CIBLE
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitCIBLE.id, "")
        Assert.AreEqual(0, arrPulv.Length)

        'Transmission au Serveur des infos
        'Date dernière synchro est dans -1 Minutes
        m_oAgent.dateDerniereSynchro = CDate(oPulve.dateModificationAgent).AddMinutes(-1)

        Dim oSynchro As New Synchronisation(m_oAgent)
        oSynchro.setAllsynchroFalse()
        oSynchro.m_SynchroBoolean.m_bSynchAscExploitation = True
        oSynchro.m_SynchroBoolean.m_bSynchDescExploitation = True
        oSynchro.m_SynchroBoolean.m_bSynchAscPulve = True
        oSynchro.m_SynchroBoolean.m_bSynchDescPulve = True
        Dim listSynchro As String = ""

        oSynchro.runAscSynchro()

        'Transfert Du pulve de l'exploit d'origine ve l'exploit Cible
        Assert.IsTrue(oPulve.TransfertPulve(oExploitOrigine.id, oExploitCIBLE.id, m_oAgent))

        'Vérification sur le Pulve n'appartient plus à l'exploit d'origine
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitOrigine.id, "")
        Assert.AreEqual(0, arrPulv.Length)

        'Vérification sur le Pulve appartient  à l'exploit CIBLE
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitCIBLE.id, "")
        Assert.AreEqual(1, arrPulv.Length)
        Assert.AreEqual(oPulve.id, arrPulv(0).id)

        'Transmission pas WS des infos
        oSynchro.runAscSynchro()

        'Récupération des infos du WS
        oSynchro.runDescSynchro()
        'Vérification sur le Pulve n'appartient plus à l'exploit d'origine
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitOrigine.id, "")
        Assert.AreEqual(0, arrPulv.Length)

        'Vérification sur le Pulve appartient  à l'exploit CIBLE
        arrPulv = PulverisateurManager.getPulverisateurByClientId(oExploitCIBLE.id, "")
        Assert.AreEqual(1, arrPulv.Length)
        Assert.AreEqual(oPulve.id, arrPulv(0).id)


        PulverisateurManager.deletePulverisateurID(oPulve.id)
        ExploitationManager.delete(oExploitCIBLE.id)
        ExploitationManager.delete(oExploitOrigine.id)

    End Sub
    <TestMethod()>
    Public Sub TestDroitsPulves()
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        oExploit = New Exploitation()
        oExploit.idStructure = m_oStructure.id
        oExploit.nomExploitant = "EXPLOITTEST"
        ExploitationManager.save(oExploit, m_oAgent)

        'Création de 4 Pulvé pour la même exlpoitation

        oPulve = New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.type = Pulverisateur.TYPEPULVE_VIGNE
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_FACEPARFACE
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oPulve = New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_FACEPARFACE
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oPulve = New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_AXIAL
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oPulve = New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_VOUTE
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        'Chargement avec une liste de droits Vide
        Dim olist As List(Of Pulverisateur)
        olist = PulverisateurManager.getPulverisateurList(m_oAgent, "")
        Assert.AreEqual(4, olist.Count)

        'Chargement avec une liste de droits sur Type
        olist = PulverisateurManager.getPulverisateurList(m_oAgent, Pulverisateur.TYPEPULVE_VIGNE)
        Assert.AreEqual(1, olist.Count)
        For Each oPulve In olist
            Assert.AreEqual(Pulverisateur.TYPEPULVE_VIGNE, oPulve.type)
        Next
        olist = PulverisateurManager.getPulverisateurList(m_oAgent, Pulverisateur.TYPEPULVE_ARBRES)
        Assert.AreEqual(3, olist.Count)
        For Each oPulve In olist
            Assert.AreEqual(Pulverisateur.TYPEPULVE_ARBRES, oPulve.type)
        Next

        'Charegement avec une liste de droits sur catégories
        olist = PulverisateurManager.getPulverisateurList(m_oAgent, Pulverisateur.CATEGORIEPULVE_FACEPARFACE)
        Assert.AreEqual(2, olist.Count)
        For Each oPulve In olist
            Assert.IsTrue(oPulve.categorie.ToUpper() = "Face par Face".ToUpper())
        Next

        'Suppression des pulvés
        olist = PulverisateurManager.getPulverisateurList(m_oAgent, "")
        Assert.AreEqual(4, olist.Count)
        For Each oPulveADEL As Pulverisateur In olist
            PulverisateurManager.deletePulverisateurID(oPulveADEL.id)
        Next
        ExploitationManager.delete(oExploit.id)

    End Sub

    <TestMethod()>
    Public Sub TestSynhcroPulves()
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        oExploit = New Exploitation()
        oExploit.idStructure = m_oStructure.id
        oExploit.nomExploitant = "EXPLOITTEST"
        ExploitationManager.save(oExploit, m_oAgent)

        'Création de 1 Pulvé pour la même exlpoitation

        oPulve = New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.type = Pulverisateur.TYPEPULVE_VIGNE
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_FACEPARFACE
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.dateProchainControle = CSDate.GetDateForWS("2015-03-23")
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        Dim updatedObject
        PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, updatedObject)

        Dim oSynchro As New Synchronisation(m_oAgent)

        Dim oElmt As SynchronisationElmt = SynchronisationElmt.createSynchronisationElmt("GetPulverisateur", oSynchro.m_SynchroBoolean)
        oElmt.identifiantChaine = oPulve.id

        oElmt.SynchroDesc(m_oAgent)

        oPulve = PulverisateurManager.getPulverisateurById(oPulve.id)

        System.Threading.Thread.Sleep(5000) 'Attente de 5 secondes
        'Mise à jour de la date de prochain controle
        oPulve.dateProchainControle = CSDate.GetDateForWS("2015-03-24")
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        'Synchro Montante
        PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, updatedObject)
        'Synhcro descendante
        oElmt.type = "GetPulverisateur"
        oElmt.identifiantChaine = oPulve.id
        oElmt.SynchroDesc(m_oAgent)

        oPulve = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual("2015-03-24 00:00:00", oPulve.dateProchainControle)

    End Sub

    <TestMethod()>
    Public Sub TestProprieteV4Lot3()
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        oExploit = New Exploitation()
        oExploit.idStructure = m_oStructure.id
        oExploit.nomExploitant = "EXPLOITTEST"

        ExploitationManager.save(oExploit, m_oAgent)

        'Création de 1 Pulvé pour la même exlpoitation
        Dim id As String

        oPulve = New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.type = Pulverisateur.TYPEPULVE_VIGNE
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_FACEPARFACE
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.dateProchainControle = CSDate.GetDateForWS("2015-03-23")
        oPulve.buseNbniveaux = 2
        oPulve.nombreBuses = 10
        oPulve.manometreNbniveaux = 3
        oPulve.manometreNbtroncons = 5
        oPulve.regulation = "Pression Constante"
        oPulve.regulationOptions = "Debit|Pression"
        oPulve.modeUtilisation = "CUMA"
        oPulve.nombreExploitants = "10"
        oPulve.buseModele = "MONMODELE"
        oPulve.buseMarque = "MAMARQUE"
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV
        oPulve.categorie = "AXIAL"
        oPulve.pulverisation = "Jet dirigé"

        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        id = oPulve.id

        Dim oPulve2 As Pulverisateur

        oPulve2 = PulverisateurManager.getPulverisateurById(id)

        Assert.AreEqual(2, oPulve2.buseNbniveaux)
        Assert.AreEqual(10, oPulve2.nombreBuses)
        Assert.AreEqual(3, oPulve2.manometreNbniveaux)
        Assert.AreEqual(5, oPulve2.manometreNbtroncons)
        Assert.AreEqual("Pression Constante", oPulve2.regulation)
        Assert.AreEqual("Debit|Pression", oPulve2.regulationOptions)
        Assert.AreEqual("CUMA", oPulve2.modeUtilisation)
        Assert.AreEqual("10", oPulve2.nombreExploitants)
        Assert.AreEqual("MONMODELE", oPulve2.buseModele)
        Assert.AreEqual("MAMARQUE", oPulve2.buseMarque)
        Assert.AreEqual(Pulverisateur.controleEtatNOKCV, oPulve2.controleEtat)
        Assert.AreEqual("AXIAL", oPulve2.categorie)
        Assert.AreEqual("Jet dirigé", oPulve2.pulverisation)

        oPulve2.buseNbniveaux = 3
        oPulve2.nombreBuses = 11
        oPulve2.manometreNbniveaux = 4
        oPulve2.manometreNbtroncons = 6
        oPulve2.regulation = "DPM"
        oPulve2.regulationOptions = "Débit"
        oPulve2.modeUtilisation = "Indiv"
        oPulve2.nombreExploitants = ""
        oPulve2.buseModele = "MONMODELE2"
        oPulve2.buseMarque = "MAMARQUE2"
        oPulve2.controleEtat = Pulverisateur.controleEtatOK
        oPulve2.categorie = "Rampe"
        oPulve2.pulverisation = "Jet projeté"

        PulverisateurManager.save(oPulve2, oExploit.id, m_oAgent)

        oPulve = PulverisateurManager.getPulverisateurById(id)
        Assert.AreEqual(3, oPulve.buseNbniveaux)
        Assert.AreEqual(11, oPulve.nombreBuses)
        Assert.AreEqual(4, oPulve.manometreNbniveaux)
        Assert.AreEqual(6, oPulve.manometreNbtroncons)
        Assert.AreEqual("DPM", oPulve.regulation)
        Assert.AreEqual("Débit", oPulve.regulationOptions)
        Assert.AreEqual("Indiv", oPulve.modeUtilisation)
        Assert.AreEqual("", oPulve.nombreExploitants)
        Assert.AreEqual("MONMODELE2", oPulve.buseModele)
        Assert.AreEqual("MAMARQUE2", oPulve.buseMarque)
        Assert.AreEqual(Pulverisateur.controleEtatOK, oPulve.controleEtat)
        Assert.AreEqual("Rampe", oPulve.categorie)
        Assert.AreEqual("Jet projeté", oPulve.pulverisation)

        'Modif avant l'échange avec le Serveur
        oPulve.buseNbniveaux = 4
        oPulve.nombreBuses = 12
        oPulve.manometreNbniveaux = 5
        oPulve.manometreNbtroncons = 7
        oPulve.regulation = "DPAE"
        oPulve.regulationOptions = "Pression"
        oPulve.modeUtilisation = "Entreprise"
        oPulve.nombreExploitants = "1"
        oPulve.buseModele = "MONMODELE3"
        oPulve.buseMarque = "MAMARQUE3"
        oPulve.controleEtat = Pulverisateur.controleEtatOK
        oPulve.categorie = "Voute"
        oPulve.pulverisation = "Pneumatique"
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        Dim UpdatedObject As Object
        PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)

        'Récupérationdu pulvé
        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)
        Assert.AreEqual(4, oPulve2.buseNbniveaux)
        Assert.AreEqual(12, oPulve2.nombreBuses)
        Assert.AreEqual(5, oPulve2.manometreNbniveaux)
        Assert.AreEqual(7, oPulve2.manometreNbtroncons)
        Assert.AreEqual("DPAE", oPulve2.regulation)
        Assert.AreEqual("Pression", oPulve2.regulationOptions)
        Assert.AreEqual("Entreprise", oPulve2.modeUtilisation)
        Assert.AreEqual("1", oPulve2.nombreExploitants)
        Assert.AreEqual("MONMODELE3", oPulve2.buseModele)
        Assert.AreEqual("MAMARQUE3", oPulve2.buseMarque)
        Assert.AreEqual(Pulverisateur.controleEtatOK, oPulve2.controleEtat)
        Assert.AreEqual("Voute", oPulve2.categorie)
        Assert.AreEqual("Pneumatique", oPulve2.pulverisation)

    End Sub
    <TestMethod()>
    Public Sub TestcouleurBuse()


        Dim oExploit As Exploitation = createExploitation()
        ExploitationManager.save(oExploit, m_oAgent)

        Dim oPulve As New Pulverisateur()
        Dim oPulve2 As Pulverisateur
        Dim bReturn As Boolean
        Dim response As Integer
        Dim UpdatedObject As Object


        ' Test de la sauvegarde en Base
        '===============================
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.id = "497-1114-99"
        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"

        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_JETDIRIGE
        oPulve.buseCouleur = "ORANGE"
        pause(1000)
        bReturn = PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.buseCouleur, oPulve2.buseCouleur)

        oPulve.buseCouleur = "BLEUE"
        bReturn = PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        oPulve2 = PulverisateurManager.getPulverisateurById(oPulve.id)
        Assert.AreEqual(oPulve.buseCouleur, oPulve2.buseCouleur)


        'Test du transfert par WS
        '=========================
        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)


        Assert.AreEqual(oPulve.id, oPulve2.id)
        Assert.AreEqual(oPulve.buseCouleur, oPulve2.buseCouleur)


        'Transformation de la couleur
        pause(1000)
        oPulve.buseCouleur = "TESTCOULEUR"
        bReturn = PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        Assert.IsTrue(bReturn)

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)
        pause(1000)
        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, oPulve.id)


        Assert.AreEqual(oPulve.id, oPulve2.id)
        Assert.AreEqual(oPulve.buseCouleur, oPulve2.buseCouleur)


    End Sub

    <TestMethod()>
    Public Sub TestGetDateDernierControle()
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur
        Dim oDiag As Diagnostic

        '========
        ' Arrange
        '========
        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        oDiag = createDiagnostic(oExploit, oPulve)

        oDiag.controleDateFin = CSDate.ToCRODIPString("15/01/2015")
        DiagnosticManager.save(oDiag)

        oDiag = createDiagnostic(oExploit, oPulve)
        oDiag.controleDateFin = CSDate.ToCRODIPString("16/01/2015")
        DiagnosticManager.save(oDiag)

        oDiag = createDiagnostic(oExploit, oPulve)
        oDiag.controleDateFin = CSDate.ToCRODIPString("14/01/2015")
        DiagnosticManager.save(oDiag)

        '=========
        'Act
        '========
        Dim oDate As String
        oDate = oPulve.getDateDernierControle()

        '======
        'Assert
        '=======
        Assert.AreEqual(CSDate.ToCRODIPString("16/01/2015"), oDate)



    End Sub

    <TestMethod()>
    Public Sub TestGetDateDernierControleVide()
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur
        Dim oDiag As Diagnostic

        '========
        ' Arrange
        '========
        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        '=========
        'Act
        '========
        Dim oDate As String
        oDate = oPulve.getDateDernierControle()

        '======
        'Assert
        '=======
        Assert.AreEqual("", oDate)



    End Sub
    <TestMethod()>
    Public Sub TestCheckNumeroNational()
        Dim oPulve As New Pulverisateur
        Dim oPulve2 As Pulverisateur
        Dim oResult As Pulverisateur.CheckResult

        oResult = oPulve.CheckNumeroNational(GLOB_DIAG_NUMAGR & "12345", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.NUMEROFORMATINCORRECT, oResult)
        oResult = oPulve.CheckNumeroNational(GLOB_DIAG_NUMAGR & "1234567", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.NUMEROFORMATINCORRECT, oResult)
        oResult = oPulve.CheckNumeroNational(GLOB_DIAG_NUMAGR & "A23456", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.NUMEROFORMATINCORRECT, oResult)
        m_oExploitation = createExploitation()
        oPulve2 = createPulve(m_oExploitation)
        oPulve2.numeroNational = GLOB_DIAG_NUMAGR & "112233"
        PulverisateurManager.save(oPulve2, m_oExploitation.id, m_oAgent)
        oResult = oPulve.CheckNumeroNational(GLOB_DIAG_NUMAGR & "112233", m_oAgent, True)
        Assert.AreEqual(Pulverisateur.CheckResult.NUMEROEXISTANT, oResult)
        oResult = oPulve.CheckNumeroNational(GLOB_DIAG_NUMAGR & "112233", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.OK, oResult)

        createIdentPulve("112233")
        createIdentPulve("123456")
        createIdentPulve("654321")
        createIdentPulve("147258")

        oResult = oPulve.CheckNumeroNational(GLOB_DIAG_NUMAGR & "111111", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.NUMEROPASDANSLALISTE, oResult)
        oResult = oPulve.CheckNumeroNational(GLOB_DIAG_NUMAGR & "123456", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.NUMEROPASLEPREMIER, oResult)
        oResult = oPulve.CheckNumeroNational(GLOB_DIAG_NUMAGR & "112233", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.OK, oResult)
        oResult = oPulve.CheckNumeroNational("E002" & "123456", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.OK, oResult)
        oResult = oPulve.CheckNumeroNational("E002" & "111111", m_oAgent, False)
        Assert.AreEqual(Pulverisateur.CheckResult.OK, oResult)


    End Sub
    ''' <summary>
    ''' Teszt des nouveaux points d'accessoires (Nvs Equipements)
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestNvPointAccessoires2()

        m_oExploitation = createExploitation()
        m_oPulve = createPulve(m_oExploitation)

        'Test des propriétés
        Assert.IsFalse(m_oPulve.isAspirationExt)
        Assert.IsFalse(m_oPulve.isDispoAntiRetour)
        Assert.IsFalse(m_oPulve.isReglageAutoHauteur)
        Assert.IsFalse(m_oPulve.isFiltrationAspiration)
        Assert.IsFalse(m_oPulve.isFiltrationRefoulement)
        Assert.IsFalse(m_oPulve.isFiltrationTroncons)
        Assert.IsFalse(m_oPulve.isFiltrationBuses)
        Assert.IsFalse(m_oPulve.isRincagecircuit)

        m_oPulve.isAspirationExt = True
        m_oPulve.isDispoAntiRetour = True
        m_oPulve.isReglageAutoHauteur = True
        m_oPulve.isFiltrationAspiration = True
        m_oPulve.isFiltrationRefoulement = True
        m_oPulve.isFiltrationTroncons = True
        m_oPulve.isFiltrationBuses = True
        m_oPulve.isRincagecircuit = True

        Assert.IsTrue(m_oPulve.isAspirationExt)
        Assert.IsTrue(m_oPulve.isDispoAntiRetour)
        Assert.IsTrue(m_oPulve.isReglageAutoHauteur)
        Assert.IsTrue(m_oPulve.isFiltrationAspiration)
        Assert.IsTrue(m_oPulve.isFiltrationRefoulement)
        Assert.IsTrue(m_oPulve.isFiltrationTroncons)
        Assert.IsTrue(m_oPulve.isFiltrationBuses)
        Assert.IsTrue(m_oPulve.isRincagecircuit)


        'Test INSERT
        m_oPulve.idStructure = m_oAgent.idStructure
        m_oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreNotEqual("", m_oPulve.id)
        Assert.IsTrue(PulverisateurManager.save(m_oPulve, m_oExploitation.id, m_oAgent))

        m_oPulve = PulverisateurManager.getPulverisateurById(m_oPulve.id)

        Assert.IsNotNull(m_oPulve)

        Assert.IsTrue(m_oPulve.isAspirationExt)
        Assert.IsTrue(m_oPulve.isDispoAntiRetour)
        Assert.IsTrue(m_oPulve.isReglageAutoHauteur)
        Assert.IsTrue(m_oPulve.isFiltrationAspiration)
        Assert.IsTrue(m_oPulve.isFiltrationRefoulement)
        Assert.IsTrue(m_oPulve.isFiltrationTroncons)
        Assert.IsTrue(m_oPulve.isFiltrationBuses)
        Assert.IsTrue(m_oPulve.isRincagecircuit)

        'Test Update
        'Modif des Propriétés
        m_oPulve.isAspirationExt = False
        m_oPulve.isDispoAntiRetour = False
        m_oPulve.isReglageAutoHauteur = False
        m_oPulve.isFiltrationAspiration = False
        m_oPulve.isFiltrationRefoulement = False
        m_oPulve.isFiltrationTroncons = False
        m_oPulve.isFiltrationBuses = False
        m_oPulve.isRincagecircuit = False
        'Sauvegarde
        Assert.IsTrue(PulverisateurManager.save(m_oPulve, m_oExploitation.id, m_oAgent))
        'Lecture
        m_oPulve = PulverisateurManager.getPulverisateurById(m_oPulve.id)
        Assert.IsNotNull(m_oPulve)
        'Test des modifs
        Assert.IsFalse(m_oPulve.isAspirationExt)
        Assert.IsFalse(m_oPulve.isDispoAntiRetour)
        Assert.IsFalse(m_oPulve.isReglageAutoHauteur)
        Assert.IsFalse(m_oPulve.isFiltrationAspiration)
        Assert.IsFalse(m_oPulve.isFiltrationRefoulement)
        Assert.IsFalse(m_oPulve.isFiltrationTroncons)
        Assert.IsFalse(m_oPulve.isFiltrationBuses)
        Assert.IsFalse(m_oPulve.isRincagecircuit)
        PulverisateurManager.save(m_oPulve, m_oExploitation.id, m_oAgent)

        'Test WS
        Dim UpdatedObject As Object
        Dim response As Integer
        Dim oPulve2 As Pulverisateur
        Dim oExploitToPulve As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByPulverisateurId(m_oPulve.id)
        ExploitationTOPulverisateurManager.sendWSExploitationTOPulverisateur(oExploitToPulve, UpdatedObject)
        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, m_oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)
        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, m_oPulve.id)
        Assert.IsFalse(m_oPulve.isAspirationExt)
        Assert.IsFalse(m_oPulve.isDispoAntiRetour)
        Assert.IsFalse(m_oPulve.isReglageAutoHauteur)
        Assert.IsFalse(m_oPulve.isFiltrationAspiration)
        Assert.IsFalse(m_oPulve.isFiltrationRefoulement)
        Assert.IsFalse(m_oPulve.isFiltrationTroncons)
        Assert.IsFalse(m_oPulve.isFiltrationBuses)
        Assert.IsFalse(m_oPulve.isRincagecircuit)

        m_oPulve.isAspirationExt = True
        m_oPulve.isDispoAntiRetour = True
        m_oPulve.isReglageAutoHauteur = True
        m_oPulve.isFiltrationAspiration = True
        m_oPulve.isFiltrationRefoulement = True
        m_oPulve.isFiltrationTroncons = True
        m_oPulve.isFiltrationBuses = True
        m_oPulve.isRincagecircuit = True
        pause(2000)
        m_oPulve.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, m_oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)
        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, m_oPulve.id)

        Assert.IsTrue(oPulve2.isAspirationExt)
        Assert.IsTrue(oPulve2.isDispoAntiRetour)
        Assert.IsTrue(oPulve2.isReglageAutoHauteur)
        Assert.IsTrue(oPulve2.isFiltrationAspiration)
        Assert.IsTrue(oPulve2.isFiltrationRefoulement)
        Assert.IsTrue(oPulve2.isFiltrationTroncons)
        Assert.IsTrue(oPulve2.isFiltrationBuses)
        Assert.IsTrue(oPulve2.isRincagecircuit)


        PulverisateurManager.deletePulverisateur(m_oPulve)
    End Sub
    ''' <summary>
    ''' Tests des Propriétés de rattachements
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestPulveRatacheProperties()

        m_oExploitation = createExploitation()
        m_oPulve = createPulve(m_oExploitation)

        'Test des propriétés
        Assert.IsFalse(m_oPulve.isPulveAdditionnel)
        Assert.AreEqual("", m_oPulve.pulvePrincipalNumNat)

        m_oPulve.isPulveAdditionnel = True
        m_oPulve.pulvePrincipalNumNat = "E001123456"

        'Test INSERT
        m_oPulve.idStructure = m_oAgent.idStructure
        m_oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        Assert.IsTrue(PulverisateurManager.save(m_oPulve, m_oExploitation.id, m_oAgent))

        m_oPulve = PulverisateurManager.getPulverisateurById(m_oPulve.id)

        Assert.IsNotNull(m_oPulve)

        Assert.IsTrue(m_oPulve.isPulveAdditionnel)
        Assert.AreEqual("E001123456", m_oPulve.pulvePrincipalNumNat)

        'Test Update
        'Modif des Propriétés
        m_oPulve.isPulveAdditionnel = False
        m_oPulve.pulvePrincipalNumNat = ""
        'Sauvegarde
        Assert.IsTrue(PulverisateurManager.save(m_oPulve, m_oExploitation.id, m_oAgent))
        'Lecture
        m_oPulve = PulverisateurManager.getPulverisateurById(m_oPulve.id)
        Assert.IsNotNull(m_oPulve)
        'Test des modifs
        Assert.IsFalse(m_oPulve.isPulveAdditionnel)
        Assert.AreEqual("", m_oPulve.pulvePrincipalNumNat)

        PulverisateurManager.save(m_oPulve, m_oExploitation.id, m_oAgent)

        'Test WS
        Dim UpdatedObject As Object
        Dim response As Integer
        Dim oPulve2 As Pulverisateur
        Dim oExploitToPulve As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByPulverisateurId(m_oPulve.id)
        ExploitationTOPulverisateurManager.sendWSExploitationTOPulverisateur(oExploitToPulve, UpdatedObject)


        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, m_oPulve, UpdatedObject)
        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, m_oPulve.id)
        Assert.IsFalse(m_oPulve.isPulveAdditionnel)
        Assert.AreEqual("", m_oPulve.pulvePrincipalNumNat)

        m_oPulve.isPulveAdditionnel = True
        m_oPulve.pulvePrincipalNumNat = "E001741852"

        pause(2000)

        m_oPulve.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
        PulverisateurManager.save(m_oPulve, m_oExploitation.id, m_oAgent)

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, m_oPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)
        oPulve2 = PulverisateurManager.getWSPulverisateurById(m_oAgent, m_oPulve.id)

        'Assert.IsTrue(oPulve2.isPulveAdditionnel)
        Assert.AreEqual("E001741852", oPulve2.pulvePrincipalNumNat)


        PulverisateurManager.deletePulverisateur(m_oPulve)
    End Sub

    <TestMethod()>
    Public Sub testEncodageAuto()
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur
        Dim oLst As List(Of DiagnosticItem)
        Dim strCode As String

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE

        'Test Defaut Attelage
        '========================
        'Regle du vrai
        oPulve.attelage = Pulverisateur.ATTELAGE_PORTE
        oLst = oPulve.EncodageAutomatiqueDefauts()
        Dim bTrouve As Boolean
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "2510" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Attelage 2510 non trouvé")

        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "2520" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Attelage 2520 non trouvé")

        'Regle du Faux
        oPulve.attelage = Pulverisateur.ATTELAGE_AUTOMOTEUR
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "2510" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsFalse(bTrouve, "Défaut Attelage 2510 trouvé")
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "2520" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsFalse(bTrouve, "Défaut Attelage 2520 trouvé")


        'Test Defaut CultureBasses
        '========================
        'Regle du vrai
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.isVentilateur = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "10110" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut CultureBasses 10110 non trouvé")

        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "10120" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut CultureBasses 10120 non trouvé")
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "10210" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut CultureBasses 10210 non trouvé")
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "10220" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut CultureBasses 10220 non trouvé")
        'Regle du false
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.isVentilateur = True
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "10110" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsFalse(bTrouve, "Défaut CultureBasses 10110 trouvé")

        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "10120" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsFalse(bTrouve, "Défaut CultureBasses 10120 trouvé")
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "10210" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsFalse(bTrouve, "Défaut CultureBasses 10210 trouvé")
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "10220" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsFalse(bTrouve, "Défaut CultureBasses 10220 trouvé")

        'Test Defaut CuveIncorporation
        '=============================
        'Regle du vrai
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.isCuveIncorporation = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "4313" Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut cuveIncorporation 4310 non trouvé")
        'Regle du faux
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.isCuveIncorporation = True
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "4310" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsFalse(bTrouve, "Défaut cuveIncorporation 4310 non trouvé")

        'defaut Pression Constante
        oPulve.regulation = "Pression constante"
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "5510" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Regulation 5510 non trouvé")
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "5520" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Regulation 5520 non trouvé")

        'defaut Pression DPM
        oPulve.regulation = "DPM"
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "5510" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Regulation 5510 non trouvé")
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "5520" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Regulation 5520 non trouvé")

        'defaut Pression DPA
        oPulve.regulation = "DPA"
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "5510" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Regulation 5510 non trouvé")
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "5520" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Regulation 5520 non trouvé")

        'defaut Pression DPAE
        oPulve.regulation = "DPAE*"
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "5620" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemOK Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Regulation 5620 non trouvé")

        'Defaut D'abscence
        oPulve.isCuveRincage = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "4611" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 4611 non trouvé")

        oPulve.isRotobuse = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "4621" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 4621 non trouvé")

        oPulve.isRinceBidon = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "4321" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 4321 non trouvé")

        oPulve.isLanceLavage = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "4631" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 4631 non trouvé")

        oPulve.isBidonLaveMain = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "12411" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 12411 non trouvé")

        oPulve.isFiltrationAspiration = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "7111" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 7111 non trouvé")

        oPulve.isFiltrationRefoulement = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "7211" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 7211 non trouvé")

        oPulve.isFiltrationTroncons = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "7311" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 7311 non trouvé")

        oPulve.isFiltrationBuses = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "7411" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 7411 non trouvé")

        oPulve.isRincagecircuit = False
        oLst = oPulve.EncodageAutomatiqueDefauts()
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Inactif Then
                Continue For
            End If
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = "4641" Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut Absence 4641 non trouvé")
    End Sub
    <TestMethod()>
    <DataRow("PORTE", "2510", DiagnosticItem.EtatDiagItemOK, DiagnosticItemAuto.EtatDiagItemAuto.Inactif)>
    Public Sub testEncodageAutoBis(pAttelage As String, pItemCode As String, pCodeEtat As String, pEtatDiagItem As DiagnosticItemAuto.EtatDiagItemAuto)
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur
        Dim oLst As List(Of DiagnosticItem)
        Dim strCode As String

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE

        'Test Defaut Attelage
        '========================
        'Regle du vrai
        oPulve.attelage = pAttelage
        oLst = oPulve.EncodageAutomatiqueDefauts()
        Dim bTrouve As Boolean
        bTrouve = False
        For Each oDiagItem As DiagnosticItemAuto In oLst
            strCode = oDiagItem.getItemCode()
            If Trim(strCode) = pItemCode And oDiagItem.itemCodeEtat = pCodeEtat And oDiagItem.Etat = pEtatDiagItem Then
                bTrouve = True
            End If
        Next
        Assert.IsTrue(bTrouve, "Défaut " & pItemCode & "Non Trouvé dans l'état" & pEtatDiagItem)

    End Sub

    ''' <summary>
    ''' Vérificatio du décodage des defauts
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub testDecodageAuto()
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur
        Dim oLst As New List(Of DiagnosticItem)
        Dim oDiagItem As DiagnosticItem

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE


        oDiagItem = New DiagnosticItem("", "711", "1", , DiagnosticItem.EtatDiagItemABSENCE)
        oLst.Add(oDiagItem)

        'Test isCuveIcorporation
        '========================
        oPulve.isCuveIncorporation = True
        oDiagItem.idItem = "431"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isCuveIncorporation)

        'Test isCuveRincage
        '========================
        oPulve.isCuveRincage = True
        oDiagItem.idItem = "461"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isCuveRincage)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isCuveRincage)

        'Test isRotobuse
        '========================
        oPulve.isRotobuse = True
        oDiagItem.idItem = "462"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isRotobuse)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isRotobuse)

        'Test isRinceBidon
        '========================
        oPulve.isRinceBidon = True
        oDiagItem.idItem = "432"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isRinceBidon)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isRinceBidon)

        'Test isLanceLavage
        '========================
        oPulve.isLanceLavage = True
        oDiagItem.idItem = "463"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isLanceLavage)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isLanceLavage)

        'Test isBidonLaveMain
        '========================
        oPulve.isLanceLavage = True
        oDiagItem.idItem = "1241"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isBidonLaveMain)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isBidonLaveMain)

        'Test isFiltrationAspiration
        '========================
        oPulve.isLanceLavage = True
        oDiagItem.idItem = "711"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isFiltrationAspiration)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isFiltrationAspiration)

        'Test isFiltrationRefoulement
        '========================
        oPulve.isLanceLavage = True
        oDiagItem.idItem = "721"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isFiltrationRefoulement)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isFiltrationRefoulement)

        'Test isFiltrationTroncons
        '========================
        oPulve.isFiltrationTroncons = True
        oDiagItem.idItem = "731"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isFiltrationTroncons)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isFiltrationTroncons)

        'Test isFiltrationBuses
        '========================
        oPulve.isFiltrationBuses = True
        oDiagItem.idItem = "741"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isFiltrationBuses)
        oDiagItem.itemCodeEtat = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsTrue(oPulve.isFiltrationBuses)

        'Test isRincagecircuit
        '========================
        oPulve.isRincagecircuit = True
        oDiagItem.idItem = "464"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE
        Assert.IsTrue(oPulve.DecodageAutomatiqueDefauts(oLst))
        Assert.IsFalse(oPulve.isRincagecircuit)
    End Sub


    <TestMethod()>
    Public Sub TestSetControleEtat()

        Dim oExploit As Exploitation = createExploitation()
        Dim opulve As Pulverisateur = createPulve(oExploit)
        Dim oDiag As Diagnostic = createDiagnostic(oExploit, opulve)

        oDiag.controleEtat = Diagnostic.controleEtatOK
        opulve.SetControleEtat(oDiag)
        Assert.AreEqual(Pulverisateur.controleEtatOK, opulve.controleEtat)

        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        opulve.SetControleEtat(oDiag)
        Assert.AreEqual(Pulverisateur.controleEtatNOKCV, opulve.controleEtat)

        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        opulve.SetControleEtat(oDiag)
        Assert.AreEqual(Pulverisateur.controleEtatNOKCC, opulve.controleEtat)

    End Sub

    <TestMethod()>
    Public Sub testgetPulverisateurbyNumNat()
        Dim oExploit1 As Exploitation
        Dim oExploit2 As Exploitation
        Dim oPulvePrinc1 As Pulverisateur
        Dim idPulvePrinc1 As String
        Dim oPulvePrinc2 As Pulverisateur
        Dim idPulvePrinc2 As String
        Dim oPulve As Pulverisateur

        oExploit1 = createExploitation()
        oExploit2 = createExploitation()
        oPulvePrinc1 = createPulve(oExploit1)
        oPulvePrinc1.isPulveAdditionnel = False
        oPulvePrinc1.numeroNational = "E001123456"
        PulverisateurManager.save(oPulvePrinc1, oExploit1.id, m_oAgent)
        idPulvePrinc1 = oPulvePrinc1.id
        '' création d'un second pulve sur la seconde exploitation
        oPulvePrinc2 = createPulve(oExploit2)
        oPulvePrinc2.isPulveAdditionnel = False
        oPulvePrinc2.numeroNational = "E001123456" ' Même numnat
        PulverisateurManager.save(oPulvePrinc2, oExploit2.id, m_oAgent)
        idPulvePrinc2 = oPulvePrinc2.id

        Assert.AreEqual(2, PulverisateurManager.getNbrePulverisateursParNumeroNational("E001123456"))

        oPulve = PulverisateurManager.getPulverisateurByNumNat("E001123456", oExploit1.id)
        Assert.AreEqual(idPulvePrinc1, oPulve.id)

        oPulve = PulverisateurManager.getPulverisateurByNumNat("E001123456", oExploit2.id)
        Assert.AreEqual(idPulvePrinc2, oPulve.id)
    End Sub
End Class
