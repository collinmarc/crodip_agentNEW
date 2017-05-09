Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour AgentManagerTest, destinée à contenir tous
'''les tests unitaires AgentManagerTest
'''</summary>
<TestClass()> _
Public Class AgentManagerTest
    Inherits CRODIPTest


    Private testContextInstance As TestContext


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
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''Test pour sendWSAgent
    '''</summary>
    ''' 
    <TestMethod()> _
    Public Sub sendWSAgentTest()
        Dim agent As Agent = Nothing
        Dim agentLu As Agent = Nothing
        Dim updatedObject As Object = Nothing
        Dim updatedObjectExpected As Object = Nothing
        Dim expected As Object = Nothing
        Dim actual As Object

        'WSCrodip.Init(WSCrodip.URL)
        agent = m_oAgent
        agent.numeroNational = "NUMTEST"
        agent.nom = "NOM"
        agent.prenom = "PRENOM"
        agent.cleActivation = "cle"
        agent.commentaire = "commentaire5"
        agent.dateCreation = "2012-09-01 12:00:00"
        agent.dateDerniereConnexion = "2012-09-01 12:00:00"
        agent.dateDerniereSynchro = "2012-09-02 12:00:00"
        agent.dateModificationAgent = "2012-11-01 12:00:02"
        agent.dateModificationCrodip = "2012-09-04 12:00:00"
        agent.eMail = "email"
        agent.idStructure = 497
        agent.isActif = True
        agent.motDePasse = "mdp"
        agent.statut = "STATUT"
        agent.telephonePortable = "0680667189"
        agent.versionLogiciel = "VERSION"
        agent.DroitsPulves = "Rampes|Voute"
        agent.isGestionnaire = True

        actual = AgentManager.sendWSAgent(agent, updatedObject)

        agentLu = AgentManager.getWSAgentById(agent.numeroNational)
        'Assert.AreEqual(agent.id, agentLu.id)
        'TODO : Controle de l'objet lu a reactiver !!!
        Assert.AreEqual(agentLu.numeroNational, agent.numeroNational)
        '        Assert.AreEqual(agentLu.nom, agent.nom)
        'Assert.AreEqual(agentLu.prenom, agent.prenom)
        'Assert.AreEqual(agentLu.cleActivation, "cle")
        'Assert.AreEqual(agentLu.commentaire, agent.commentaire)
        'Assert.AreEqual(agentLu.dateCreation, "2012-09-01 12:00:00")
        'Assert.AreEqual(agentLu.dateDerniereConnexion, "2012-09-01 12:00:00")
        'Assert.AreEqual(agentLu.dateDerniereSynchro, "2012-09-02 12:00:00")
        'Assert.AreEqual(agentLu.dateModificationAgent, "2012-09-03 12:00:00")
        'Assert.AreEqual(agentLu.dateModificationCrodip, "2012-09-04 12:00:00")
        'Assert.AreEqual(agentLu.eMail, "email")
        'Assert.AreEqual(agentLu.idStructure, 497)
        'Assert.AreEqual(agentLu.isActif, True)
        ' Assert.AreEqual(agentLu.motDePasse, "mdp")
        'Assert.AreEqual(agentLu.statut, "STATUT")
        'Assert.AreEqual(agentLu.telephonePortable, "0680667189")
        'Assert.AreEqual(agentLu.versionLogiciel, "VERSION")
        'Assert.AreEqual(agentLu.DroitsPulves, "Rampes|Voute")
    End Sub


    '''<summary>
    '''Test pour sendWSAgent
    '''</summary>
    <TestMethod()> _
    Public Sub createAgentTest()
        Dim oDB As CSDb
        oDB = New CSDb(True)

        Dim oCommand As OleDb.OleDbCommand

        oCommand = oDB.getConnection().CreateCommand()
        oCommand.CommandText = "DELETE FROM AGENT"
        oCommand.ExecuteNonQuery()

        Dim oAgent As Agent
        AgentManager.createAgent(1, "123456", "AgentTest")
        oAgent = AgentManager.getAgentByNumeroNational("123456")

        Assert.IsNotNull(oAgent)
        Assert.AreEqual("AgentTest", oAgent.nom)

    End Sub

    '''<summary>
    '''Test pour la methode Get Agent List
    '''</summary>
    <TestMethod()> _
    Public Sub GetAgentListTest()
        Dim oAgent As Agent
        Dim oStructure As Structuree
        oStructure = New Structuree()
        oStructure.id = StructureManager.getNewId()
        oStructure.nom = "MaStructure"
        StructureManager.save(oStructure)
        Assert.AreNotEqual(0, oStructure.id)
        oAgent = AgentManager.getAgentByNumeroNational("9999")
        If oAgent.numeroNational = "9999" Then
            AgentManager.delete(oAgent.id)
        End If
        oAgent = AgentManager.createAgent(9999, "9999", "AgentTest")
        oAgent.prenom = "Moi"
        oAgent.idStructure = oStructure.id
        AgentManager.save(oAgent)

        Dim oList As AgentList = AgentManager.getAgentList()
        For Each oAgent2 In oList.items
            If oAgent2.id = oAgent.id Then
                Assert.AreEqual(oStructure.nom, oAgent2.NomStructure)
            End If
        Next
        AgentManager.delete(oAgent.id)
        StructureManager.delete(oStructure.id)
    End Sub

    '''<summary>
    '''Test de création d'un agent sur une base vide
    '''</summary>
    <TestMethod()> _
    Public Sub CreateAgentBaseVideTest()
        Dim oAgent As Agent
        Dim oStructure As Structuree
        oStructure = New Structuree()
        oStructure.id = StructureManager.getNewId()
        oStructure.nom = "MaStructure"
        StructureManager.save(oStructure)
        Assert.AreNotEqual(0, oStructure.id)

        Dim oCSDB As CSDb = New CSDb(True)
        oCSDB.getResults("DELETE FROM AGENT")

        oAgent = AgentManager.createAgent(999, "9999", "AgentTest")
        oAgent.prenom = "Moi"
        oAgent.idStructure = oStructure.id
        AgentManager.save(oAgent)

        Dim oList As AgentList = AgentManager.getAgentList()
        For Each oAgent2 In oList.items
            If oAgent2.id = oAgent.id Then
                Assert.AreEqual(oStructure.nom, oAgent2.NomStructure)
            End If
        Next
        '        AgentManager.delete(oAgent.id)
        '       StructureManager.delete(oStructure.id)
    End Sub


    <TestMethod()> _
    Public Sub SupprimeDernierAgentTest()

        'Au début il y a un Agent dans la base
        Assert.AreEqual(1, AgentManager.getAgentList().items.Count)

        'Ajout d'un second Agent

        'Création d'un DiagnosticComplet
        Dim idDiag As String
        idDiag = CreateDiag(m_oAgent)

        'Pulvérisateur
        createPulve(m_oAgent)

        'Materiel
        createMateriel(m_oAgent)


        'CreateAutoTest
        createAutotests(m_oAgent)

        'Prestation
        Dim oPCategorie As PrestationCategorie = New PrestationCategorie()
        oPCategorie.id = 987
        oPCategorie.idStructure = m_oAgent.idStructure
        oPCategorie.libelle = "TEST"
        PrestationCategorieManager.save(oPCategorie, m_oAgent)

        Dim oPTarif As PrestationTarif = New PrestationTarif()
        oPTarif.id = 9870
        oPTarif.idCategorie = oPCategorie.id
        oPTarif.idStructure = m_oAgent.idStructure
        oPTarif.description = "Test"
        PrestationTarifManager.save(oPTarif, m_oAgent)


        'Création d'un second Agent
        Dim oAgent As Agent
        Dim idAgent = "777"
        oAgent = AgentManager.createAgent(idAgent, "TST1", "Agent de test")
        oAgent.prenom = "Pr"
        oAgent.idStructure = m_oAgent.idStructure
        AgentManager.save(oAgent)

        oAgent = AgentManager.getAgentById(idAgent)
        Assert.IsNotNull(oAgent)

        'Création d'un DiagnosticComplet
        CreateDiag(oAgent)

        'Pulvérisateur
        createPulve(oAgent)

        'Materiel
        createMateriel(oAgent)

        'CreateAutoTest
        createAutotests(oAgent)

        'Suppression de l'Agent Créé
        AgentManager.delete(oAgent.id)
        Assert.AreEqual(1, AgentManager.getAgentList().items.Count)

        Dim oCSDB As New CSDb(True)
        Dim n As Integer
        'Vérification Que la base n'est pas vide
        n = oCSDB.getValue("Select count(*) FROM  Agent")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  AgentBuseEtalon")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  AgentManoControle")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  AgentManoEtalon")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  BancMesure")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Controle_Regulier")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  ControleBancMesure")
        '        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  ControleManoMesure")
        '        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Diagnostic")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticBuses")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticBusesDetail")
        Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  DiagnosticFacture")
        'Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  DiagnosticFactureItem")
        'Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticItem")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticMano542")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticTroncons833")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Exploitation")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  ExploitationToPulverisateur")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  FicheVieBancMesure")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  FicheVieManometreControle")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  FicheVieManometreEtalon")
        Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  Logs")
        'Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  PrestationCategorie")
        'Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  PrestationTarif")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Pulverisateur")
        Assert.AreNotEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Structure")
        Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  Synchronisation")
        'Assert.AreNotEqual(0, n)

        'Suppression de l'Agent initial
        AgentManager.delete(m_oAgent.id)
        Assert.AreEqual(0, AgentManager.getAgentList().items.Count)

        'Vérification du Vidage complet de la base
        n = oCSDB.getValue("Select count(*) FROM  Agent")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  AgentBuseEtalon")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  AgentManoControle")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  AgentManoEtalon")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  BancMesure")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Controle_Regulier")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  ControleBancMesure")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  ControleManoMesure")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Diagnostic")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticBuses")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticBusesDetail")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticFacture")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticFactureItem")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticItem")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticMano542")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  DiagnosticTroncons833")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Exploitation")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  ExploitationToPulverisateur")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  FicheVieBancMesure")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  FicheVieManometreControle")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  FicheVieManometreEtalon")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Logs")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  PrestationCategorie")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  PrestationTarif")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Pulverisateur")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Structure")
        Assert.AreEqual(0, n)
        n = oCSDB.getValue("Select count(*) FROM  Synchronisation")
        Assert.AreEqual(0, n)

        oCSDB.free()

    End Sub


    Private Function CreateDiag(ByVal pAgent As Agent) As String
        'Création d'un diagnostic
        Dim oDiag As Diagnostic
        Dim oDiagBuses As DiagnosticBuses
        Dim oDiagBusesDetail As DiagnosticBusesDetail
        Dim idDiag As String
        'Creation d'un Diagnostic
        oDiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(pAgent)
        oDiag.id = idDiag
        oDiag.setOrganisme(pAgent)

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
        oDiagBuses.diagnosticBusesDetail.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetail.Liste.Add(oDiagBusesDetail)

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
        oDiagBuses.diagnosticBusesDetail.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetail.Liste.Add(oDiagBusesDetail)


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
        'Dim oLst As New List(Of DiagnosticItem)
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "B"
        oDiagItem.cause = "1"

        oDiag.AddDiagItem(oDiagItem)

        'Item2
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "222"
        oDiagItem.itemValue = "2"
        oDiagItem.itemCodeEtat = "P"

        oDiagItem.cause = "2"
        oDiag.AddDiagItem(oDiagItem)

        'Item3
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "333"
        oDiagItem.itemValue = "3"
        oDiagItem.itemCodeEtat = "O"

        oDiagItem.cause = "2"
        oDiag.AddDiagItem(oDiagItem)

        'Item4
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "444"
        oDiagItem.itemValue = "4"
        oDiagItem.itemCodeEtat = "P"


        oDiag.AddDiagItem(oDiagItem)



        DiagnosticManager.save(oDiag)
        Return oDiag.id



    End Function

    Private Function createPulve(ByVal pAgent As Agent) As String
        Dim oPulve As New Pulverisateur()
        Dim oExploitation As New Exploitation()

        oExploitation.raisonSociale = "MONEXPLOITATION"
        oExploitation.codeApe = "12345"
        oExploitation.idStructure = pAgent.idStructure
        ExploitationManager.save(oExploitation, pAgent)


        oPulve.idStructure = pAgent.idStructure
        oPulve.id = PulverisateurManager.getNewId(pAgent)
        Assert.AreNotEqual("", oPulve.id)

        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_JETDIRIGE
        oPulve.setLargeurNbreRangs("15.5")
        oPulve.emplacementIdentification = "DERRIERE"
        'Assert.AreEqual("15.5", oPulve.getLargeurNbreRangs)

        PulverisateurManager.save(oPulve, oExploitation.id, m_oAgent)

        Return oPulve.id

    End Function
    Private Sub createMateriel(ByVal pAgent As Agent)
        createBuse(pAgent)
        createBuse(pAgent)
        createManoControle(pAgent)
        createManoControle(pAgent)
        createManoEtalon(pAgent)
        createManoEtalon(pAgent)
        createBancMesure(pAgent)
        createBancMesure(pAgent)

        'createControleMano(pAgent)
        ' createControleBanc(pAgent)

        createFVBanc(pAgent)
        createFVManoControle(pAgent)
        createFVManoEtalon(pAgent)
    End Sub

    Private Function createBuse(ByVal pAgent As Agent) As String
        Dim oBuseEtalon As New Buse()
        Dim idBuse As String
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(pAgent)
        oBuseEtalon.numeroNational = idBuse
        oBuseEtalon.idCrodip = "idCrodip"
        oBuseEtalon.idStructure = pAgent.idStructure
        oBuseEtalon.couleur = "JAUNE"

        BuseManager.save(oBuseEtalon)
        Return ""

    End Function
    Private Function createManoControle(ByVal pAgent As Agent) As String
        Dim oMano As New ManometreControle()
        Dim numnat As String
        numnat = ManometreControleManager.FTO_getNewNumeroNational(pAgent)
        oMano.numeroNational = numnat
        oMano.idCrodip = "idCrodip"
        oMano.idStructure = pAgent.idStructure
        oMano.marque = "JAUNE"

        ManometreControleManager.save(oMano)
        Return ""

    End Function
    Private Function createManoEtalon(ByVal pAgent As Agent) As String
        Dim oMano As New ManometreEtalon()
        Dim numnat As String
        numnat = ManometreEtalonManager.getNewNumeroNationalForTestOnly(pAgent)
        oMano.numeroNational = numnat
        oMano.idCrodip = "idCrodip"
        oMano.idStructure = pAgent.idStructure
        oMano.marque = "JAUNE"

        ManometreEtalonManager.save(oMano)
        Return ""

    End Function
    Private Function createBancMesure(ByVal pAgent As Agent) As String
        Dim oBanc As New Banc()
        Dim numnat As String
        numnat = BancManager.FTO_getNewId(pAgent)
        oBanc.id = numnat
        oBanc.idStructure = pAgent.idStructure
        oBanc.marque = "JAUNE"
        BancManager.save(oBanc)
        Return numnat

    End Function
    'Private Sub createControleMano(ByVal pAgent As Agent)
    '    Dim oMano As New ControleMano()
    '    Dim id As String
    '    Dim oCSdb As New CSDb(True)
    '    Dim cmd As OleDb.OleDbCommand = oCSdb.getConnection().CreateCommand
    '    Dim oDR As OleDb.OleDbDataReader
    '    cmd.CommandText = "SELECT numeronational from AgentManoControle where numeronational LIKE" & ControlChars.Quote & "%-" & pAgent.id & "-%" & ControlChars.Quote
    '    oDR = cmd.ExecuteReader()
    '    While oDR.Read()
    '        Dim cmd2 As OleDb.OleDbCommand = oCSdb.getConnection().CreateCommand
    '        Dim oDR2 As OleDb.OleDbDataReader
    '        cmd2.CommandText = "SELECT numeronational from AgentManoEtalon where numeronational LIKE" & ControlChars.Quote & "%-" & pAgent.id & "-%" & ControlChars.Quote
    '        oDR2 = cmd2.ExecuteReader()
    '        While oDR2.Read()

    '            id = ControleManoManager.getNewId(pAgent)
    '            Dim oCtrl As New ControleMano()
    '            oCtrl.id = id
    '            oCtrl.idStructure = pAgent.idStructure
    '            oCtrl.idMano = oDR.GetString(0)
    '            oCtrl.manoEtalon = oDR2.GetString(0)

    '            ControleManoManager.save(oCtrl, pAgent)
    '        End While
    '        oDR2.Close()
    '    End While
    '    oDR.Close()

    'End Sub
    ''Private Sub createControleBanc(ByVal pAgent As Agent)
    '    Dim oMano As New ControleMano()
    '    Dim id As String
    '    Dim oCSdb As New CSDb(True)
    '    Dim cmd As OleDb.OleDbCommand = oCSdb.getConnection().CreateCommand
    '    Dim oDR As OleDb.OleDbDataReader
    '    cmd.CommandText = "SELECT id from BancMesure where id LIKE" & ControlChars.Quote & "%-" & pAgent.id & "-%" & ControlChars.Quote
    '    oDR = cmd.ExecuteReader()
    '    While oDR.Read()

    '        id = ControleBancManager.getNewId(pAgent)
    '        Dim oCtrl As New ControleBanc()
    '        oCtrl.id = id
    '        oCtrl.idStructure = pAgent.idStructure
    '        oCtrl.idBanc = oDR.GetString(0)

    '        ControleBancManager.save(oCtrl, pAgent)
    '    End While
    '    oDR.Close()

    'End Sub

    Private Sub createFVBanc(ByVal pAgent As Agent)
        Dim id As String
        Dim oCSdb As New CSDb(True)
        Dim cmd As OleDb.OleDbCommand = oCSdb.getConnection().CreateCommand
        Dim oDR As OleDb.OleDbDataReader
        cmd.CommandText = "SELECT id from BancMesure where id LIKE" & ControlChars.Quote & "%-" & pAgent.id & "-%" & ControlChars.Quote
        oDR = cmd.ExecuteReader()
        While oDR.Read()

            id = FVBancManager.getNewId(pAgent)
            Dim oFV As New FVBanc()
            oFV.id = id
            oFV.idBancMesure = oDR.GetString(0)

            FVBancManager.save(oFV)
        End While
        oDR.Close()

    End Sub
    Private Sub createFVManoControle(ByVal pAgent As Agent)
        Dim idMano As String

        Dim Lst As List(Of ManometreControle) = ManometreControleManager.getManoControleByStructureId(pAgent.idStructure, True)
        For Each oMano As ManometreControle In Lst
            idMano = FVManometreControleManager.getNewId(pAgent)
            Dim oFV As New FVManometreControle()
            oFV.id = idMano
            oFV.idManometre = oMano.numeroNational

            FVManometreControleManager.save(oFV)

        Next
    End Sub
    Private Sub createFVManoEtalon(ByVal pAgent As Agent)
        Dim idMano As String

        Dim Lst As List(Of ManometreEtalon) = ManometreEtalonManager.getManometreEtalonByStructureId(pAgent.idStructure, True)
        For Each oMano As ManometreEtalon In Lst
            idMano = FVManometreEtalonManager.getNewId(pAgent)
            Dim oFV As New FVManometreEtalon()
            oFV.id = idMano
            oFV.idManometre = oMano.numeroNational

            FVManometreEtalonManager.save(oFV)

        Next
    End Sub
    Private Sub createAutotests(ByVal pAgent As Agent)
        Dim oCol As Collection

        oCol = AutoTestManager.CreateControlesReguliers(pAgent, Date.Now)
        For Each oTest As AutoTest In oCol
            AutoTestManager.save(oTest)
        Next
    End Sub
End Class
