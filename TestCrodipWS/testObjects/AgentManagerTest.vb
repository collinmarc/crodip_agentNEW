
Imports System.Data.Common
Imports CRODIPWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting


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

    <TestMethod()>
    Public Sub CRUDTest()
        Dim oAgent1 As New Agent
        Dim oAgent2 As Agent
        oAgent1 = New Agent(99, "CRUDTest01", "CRUDTEST", m_oStructure.id)
        AgentManager.save(oAgent1)
        oAgent1.prenom = "test"
        oAgent1.idStructure = m_oStructure.id
        Assert.IsFalse(oAgent1.isSignElecActive)
        oAgent1.isSignElecActive = True
        Assert.IsTrue(oAgent1.isSignElecActive)
        AgentManager.save(oAgent1)

        oAgent2 = AgentManager.getAgentById(oAgent1.id)

        Assert.AreEqual(oAgent1, oAgent2)

        Assert.IsTrue(oAgent2.isSignElecActive)
        oAgent2.isSignElecActive = False

        AgentManager.save(oAgent2)

        oAgent1 = AgentManager.getAgentById(oAgent2.id)
        Assert.IsFalse(oAgent2.isSignElecActive)
        Assert.IsNull(oAgent2.oPool)

        Dim oPool As New Pool()
        oPool.uid = 99
        oPool.idPool = "TEST"
        oPool.libelle = "POOLTEST"
        oAgent2.oPool = oPool
        PoolManager.Save(oPool)

        Assert.IsTrue(AgentManager.save(oAgent2))
        oAgent1 = AgentManager.getAgentById(oAgent2.id)

        Assert.IsNotNull(oAgent1.oPool)
        Assert.AreEqual(99, oAgent1.oPool.uid)
        Assert.AreEqual("POOLTEST", oAgent1.oPool.libelle)
        Assert.AreEqual("TEST", oAgent1.oPool.idPool)


    End Sub

    '''<summary>
    '''Test pour sendWSAgent
    '''</summary>
    ''' 
    <TestMethod(), Ignore()>
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
        agent.idStructure = m_oStructure.id
        agent.isActif = True
        agent.motDePasse = "mdp"
        agent.statut = "STATUT"
        agent.telephonePortable = "0680667189"
        agent.versionLogiciel = "VERSION"
        agent.DroitsPulves = "Rampes|Voute"
        agent.isGestionnaire = True
        agent.isSignElecActive = True

        actual = AgentManager.WSSend(agent, updatedObject)

        agentLu = AgentManager.WSgetByNumeroNational(agent.numeroNational)
        'Assert.AreEqual(agent.id, agentLu.id)
        'TODO : Controle de l'objet lu a reactiver !!!
        Assert.AreEqual(agent.numeroNational, agentLu.numeroNational)
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
        Assert.AreEqual(True, agentLu.isSignElecActive)

    End Sub

    '''<summary>
    '''Test pour sendWSAgent
    '''</summary>
    <TestMethod()> _
    Public Sub createAgentTest()
        Dim oDB As CSDb
        oDB = New CSDb(True)

        Dim oCommand As DbCommand

        oCommand = oDB.getConnection().CreateCommand()
        oCommand.CommandText = "DELETE FROM AGENT"
        oCommand.ExecuteNonQuery()

        Dim oAgent As Agent
        oAgent = New Agent(1, "123456", "AgentTest", m_oStructure.id)
        AgentManager.save(oAgent)
        oAgent = AgentManager.getAgentByNumeroNational("123456")

        Assert.IsNotNull(oAgent)
        Assert.AreEqual("AgentTest", oAgent.nom)
        Assert.AreEqual(New Date(1971, 1, 1), CSDate.FromCrodipString(oAgent.dateDerniereSynchro))

    End Sub

    '''<summary>
    '''Test pour la methode Get Agent List
    '''</summary>
    <TestMethod()> _
    Public Sub GetAgentListTest()
        Dim oAgent As Agent
        Dim oStructure As [Structure]
        oStructure = New [Structure]()
        oStructure.id = StructureManager.getNewId()
        oStructure.nom = "MaStructure"
        StructureManager.save(oStructure)
        Assert.AreNotEqual(0, oStructure.id)
        oAgent = AgentManager.getAgentByNumeroNational("9999")
        If oAgent.numeroNational = "9999" Then
            AgentManager.delete(oAgent.id)
        End If
        oAgent = New Agent(9999, "9999", "AgentTest", m_oStructure.id)
        oAgent.prenom = "Moi"
        oAgent.idStructure = oStructure.id
        AgentManager.save(oAgent)

        Dim oList As AgentList = AgentManager.getAgentList(oStructure.id)
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
    <TestMethod()>
    Public Sub CreateAgentBaseVideTest()
        Dim oAgent As Agent
        Dim oStructure As [Structure]
        oStructure = New [Structure]()
        oStructure.id = StructureManager.getNewId()
        oStructure.nom = "MaStructure"
        StructureManager.save(oStructure)
        Assert.AreNotEqual(0, oStructure.id)

        Dim oCSDB As CSDb = New CSDb(True)
        oCSDB.Execute("DELETE FROM AGENT")

        oAgent = New Agent(999, "9999", "AgentTest", oStructure.id)
        oAgent.prenom = "Moi"
        oAgent.idStructure = oStructure.id
        AgentManager.save(oAgent)

        Dim oList As AgentList = AgentManager.getAgentList(oStructure.id)
        For Each oAgent2 In oList.items
            If oAgent2.id = oAgent.id Then
                Assert.AreEqual(oStructure.nom, oAgent2.NomStructure)
                Assert.AreEqual(New Date(1971, 1, 1), CSDate.FromCrodipString(oAgent.dateDerniereSynchro))
            End If
        Next
        '        AgentManager.delete(oAgent.id)
        '       StructureManager.delete(oStructure.id)
    End Sub
    <TestMethod()>
    Public Sub CreateNouvelAgentDateSynchro()
        Dim oAgent As Agent

        Dim oCSDB As CSDb = New CSDb(True)
        oCSDB.Execute("DELETE FROM AGENT")
        oCSDB.free()

        oAgent = New Agent(999, "9999", "AgentTest", m_oStructure.id)
        oAgent.prenom = "Moi"
        oAgent.idStructure = m_oStructure.id
        oAgent.isActif = True
        AgentManager.save(oAgent)

        Dim oList As AgentList = AgentManager.getAgentList(m_oStructure.id)
        Assert.AreEqual(1, oList.items.Count())
        Dim oAgent2 As Agent = oList.items(0)
        Assert.AreEqual(m_oStructure.nom, oAgent2.NomStructure)
        Assert.AreEqual(New Date(1971, 1, 1), CSDate.FromCrodipString(oAgent2.dateDerniereSynchro))

        'Modification de la date de dernière synhcro
        oAgent2.dateDerniereSynchro = "2021-11-16 00:00:00"
        AgentManager.save(oAgent2)
        'Creation d'un nouvel agent
        oAgent = New Agent(888, "NN888", "Second Agent", m_oStructure.id)
        oAgent.prenom = "Moi"
        oAgent.idStructure = m_oStructure.id
        AgentManager.save(oAgent)

        oList = AgentManager.getAgentList(m_oStructure.id)
        Assert.AreEqual(2, oList.items.Count())
        oAgent = oList.items.Where(Function(a) a.id = 888)(0)
        'Sa date de dernière synhcro est la plus petite date de la base
        Assert.AreEqual(oAgent.dateDerniereSynchro, oAgent2.dateDerniereSynchro)

        AgentManager.delete(oAgent.id)
        AgentManager.delete(oAgent2.id)
    End Sub


    <TestMethod()> _
    Public Sub SupprimeDernierAgentTest()

        'Au début il y a un Agent dans la base
        Assert.AreEqual(1, AgentManager.getAgentList(m_oStructure.id).items.Count)

        'Materiel
        createMateriel(m_oAgent)

        'Pulvérisateur
        createPulve(m_oAgent)

        'Création d'un DiagnosticComplet
        Dim idDiag As String
        idDiag = CreateDiag(m_oAgent)




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
        Dim idAgent As Integer = 777
        oAgent = New Agent(idAgent, "TST1", "Agent de test", m_oStructure.id)
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
        Assert.AreEqual(1, AgentManager.getAgentList(m_oStructure.id).items.Count)

        Dim oCSDB As New CSDb(True)
        Dim n As Integer
        'Vérification Que la base n'est pas vide
        n = CType(oCSDB.getValue("Select count(*) FROM  Agent"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  AgentBuseEtalon"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  AgentManoControle"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  AgentManoEtalon"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  BancMesure"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Controle_Regulier"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  ControleBancMesure"), Integer)
        '        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  ControleManoMesure"), Integer)
        '        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Diagnostic"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticBuses"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticBusesDetail"), Integer)
        Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  DiagnosticFacture")
        'Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  DiagnosticFactureItem")
        'Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticItem"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticMano542"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticTroncons833"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Exploitation"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  ExploitationToPulverisateur"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  FicheVieBancMesure"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  FicheVieManometreControle"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  FicheVieManometreEtalon"), Integer)
        Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  Logs")
        'Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  PrestationCategorie")
        'Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  PrestationTarif")
        'Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Pulverisateur"), Integer)
        Assert.AreNotEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Structure"), Integer)
        Assert.AreNotEqual(0, n)
        'n = oCSDB.getValue("Select count(*) FROM  Synchronisation")
        'Assert.AreNotEqual(0, n)

        'Suppression de l'Agent initial
        AgentManager.delete(m_oAgent.id)
        Assert.AreEqual(0, AgentManager.getAgentList(m_oStructure.id).items.Count)

        'Vérification du Vidage complet de la base
        n = CType(oCSDB.getValue("Select count(*) FROM  Agent"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  AgentBuseEtalon"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  AgentManoControle"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  AgentManoEtalon"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  BancMesure"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Controle_Regulier"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  ControleBancMesure"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  ControleManoMesure"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Diagnostic"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticBuses"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticBusesDetail"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticFacture"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticFactureItem"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticItem"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticMano542"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  DiagnosticTroncons833"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Exploitation"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  ExploitationToPulverisateur"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  FicheVieBancMesure"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  FicheVieManometreControle"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  FicheVieManometreEtalon"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  PrestationCategorie"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  PrestationTarif"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Pulverisateur"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Structure"), Integer)
        Assert.AreEqual(0, n)
        n = CType(oCSDB.getValue("Select count(*) FROM  Synchronisation"), Integer)
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
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "1.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "1.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "2.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "2.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "3.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "4.6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "2"
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
        Return oDiag.id



    End Function

    Private Overloads Function createPulve(ByVal pAgent As Agent) As String
        Dim oPulve As New Pulverisateur()
        Dim oExploitation As New Exploitation()

        oExploitation.raisonSociale = "MONEXPLOITATION"
        oExploitation.codeApe = "12345"
        oExploitation.idStructure = pAgent.idStructure
        ExploitationManager.save(oExploitation, pAgent)


        oPulve.idStructure = pAgent.idStructure

        oPulve.marque = "MAMARQUE"
        oPulve.modele = "MONMODELE"
        oPulve.type = Pulverisateur.TYPEPULVE_ARBRES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_JETDIRIGE
        oPulve.setLargeurNbreRangs("15.5")
        oPulve.emplacementIdentification = "DERRIERE"
        'Assert.AreEqual("15.5", oPulve.getLargeurNbreRangs)

        PulverisateurManager.save(oPulve, oExploitation, m_oAgent)

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
        oBuseEtalon.uidstructure = pAgent.idStructure
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
        oMano.uidstructure = pAgent.idStructure
        oMano.marque = "JAUNE"

        ManometreControleManager.save(oMano)
        Return ""

    End Function
    Private Function createManoEtalon(ByVal pAgent As Agent) As String
        Dim oMano As New ManometreEtalon()
        Dim numnat As String
        numnat = ManometreEtalonManager.FTO_getNewId(pAgent)
        oMano.numeroNational = numnat
        oMano.idCrodip = "idCrodip"
        oMano.uidstructure = pAgent.idStructure
        oMano.marque = "JAUNE"

        ManometreEtalonManager.save(oMano)
        Return ""

    End Function
    Private Function createBancMesure(ByVal pAgent As Agent) As String
        Dim oBanc As New Banc()
        Dim numnat As String
        numnat = BancManager.FTO_getNewId(pAgent)
        oBanc.id = numnat
        oBanc.uidstructure = pAgent.idStructure
        oBanc.marque = "JAUNE"
        oBanc.JamaisServi = False
        oBanc.etat = True
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
        Dim lstBanc As New List(Of Banc)
        lstBanc = BancManager.getBancByAgent(pAgent)
        For Each oBanc In lstBanc
            Dim oFV As New FVBanc()
            oFV.idAgentControleur = m_oAgent.id
            oFV.idBancMesure = oBanc.id

            FVBancManager.save(oFV)
        Next
    End Sub
    Private Sub createFVManoControle(ByVal pAgent As Agent)
        Dim idMano As String

        Dim Lst As List(Of ManometreControle) = ManometreControleManager.getlstByAgent(pAgent, True)
        For Each oMano As ManometreControle In Lst
            idMano = FVManometreControleManager.getNewId(pAgent)
            Dim oFV As New FVManometreControle()
            oFV.id = idMano
            oFV.idManometre = oMano.numeroNational

            FVManometreControleManager.save(pAgent, oFV)

        Next
    End Sub
    Private Sub createFVManoEtalon(ByVal pAgent As Agent)
        Dim idMano As String

        Dim Lst As List(Of ManometreEtalon) = ManometreEtalonManager.getlstByAgent(pAgent, True)
        For Each oMano As ManometreEtalon In Lst
            idMano = FVManometreEtalonManager.getNewId(pAgent)
            Dim oFV As New FVManometreEtalon()
            oFV.id = idMano
            oFV.idManometre = oMano.numeroNational

            FVManometreEtalonManager.save(oFV)

        Next
    End Sub
    Private Sub createAutotests(ByVal pAgent As Agent)
        Dim oCol As List(Of AutoTest)

        oCol = AutoTestManager.CreateControlesReguliers(pAgent, Date.Now)
        For Each oTest As AutoTest In oCol
            AutoTestManager.save(oTest)
        Next
    End Sub
End Class
