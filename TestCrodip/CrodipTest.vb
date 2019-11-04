Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de de base pour les tests CRODIP
'''</summary>
<TestClass()> _
Public Class CRODIPTest

    'Private m_IdAgent As Integer = 1053
    'Private m_idStructure As Integer = 99

    Private m_IdAgent As Integer = 1119
    Private m_idStructure As Integer = 498

    Private testContextInstance As TestContext
    Protected m_oAgent As Agent
    Protected m_oStructure As Structuree

    Protected m_oExploitation As Exploitation
    Protected m_oPulve As Pulverisateur
    Protected m_oDiag As Diagnostic

    Protected m_oBanc As Banc

    '''<summary>
    '''Obtient ou définit le contexte de test qui fournit
    '''des informations sur la série de tests active ainsi que ses fonctionnalités.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = value
        End Set
    End Property
    '<AssemblyInitialize()> _
    'Public Shared Sub AssemblyInit(ByVal context As TestContext)
    '    Globals.Init()
    '    'System.Environment.CurrentDirectory = "C:\Newco\CRODIP\Crodip-Agent\TestCrodip\bin\x86\Debug"
    'End Sub 'AssemblyInit
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
    <TestInitialize()> _
    Public Sub MyTestInitialize()
        Globals.Init()
        Dim oCSDB As New CSDb(True)
        oCSDB.RAZ_BASE_DONNEES()
        oCSDB.free()

        'Création de la Structure
        m_oStructure = New Structuree()
        m_oStructure.id = m_idStructure
        m_oStructure.idCrodip = m_idStructure.ToString()
        m_oStructure.nom = "Structure TestsUnitaires"
        StructureManager.save(m_oStructure)

        'Creation d'un agent
        m_oAgent = AgentManager.createAgent(m_IdAgent, "TESTUNIT", "TEST", m_oStructure.id)
        m_oAgent.idStructure = m_idStructure
        m_oAgent.nom = "Agent de test unitaires"
        m_oAgent.prenom = "Agent de test unitaires"
        m_oAgent.telephonePortable = "0606060606"
        m_oAgent.eMail = "a@a.com"
        m_oAgent.isActif = True
        AgentManager.save(m_oAgent)
        Assert.IsNotNull(m_oAgent, "erreur en création d'un agent")
        '        AgentManager.getWSUpdates(m_oAgent.id,

        'Récupération du banc de la structure
        m_oBanc = BancManager.getBancById(m_idStructure & "-" & m_IdAgent & "-1")
        If m_oBanc.id = "" Then
            'Si il n'existe pas on le récupère du WS
            m_oBanc = BancManager.getWSBancById(m_oAgent, m_idStructure & "-" & m_IdAgent & "-1")
            'Si il n'existe pas sur le WS , je je créé en base (Normalement impossible)
            If m_oBanc.id = "" Then
                CSDebug.dispError("Le banc n'existe pas je le recree, (Normalement impossible)")
                m_oBanc = New Banc()
                m_oBanc.id = BancManager.FTO_getNewId(m_oAgent)
                m_oBanc.idStructure = m_oAgent.idStructure
            End If
            m_oBanc.idStructure = m_idStructure
            BancManager.save(m_oBanc)
        End If

        Dim oSynchro As New Synchronisation(m_oAgent)

        oSynchro.MAJDateDerniereSynchro()

    End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    <TestCleanup()> _
    Public Sub MyTestCleanup()

    End Sub
    '
#End Region
    Protected Function createExploitation() As Exploitation
        Dim pClient As New Exploitation
        '
        pClient.numeroSiren = "NUMRIREN"
        pClient.codeApe = "12345"
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
        pClient.surfaceAgricoleUtile = "1500"
        ExploitationManager.save(pClient, m_oAgent)

        Return pClient
    End Function

    Protected Function createPulve(pExploit As Exploitation) As Pulverisateur
        Dim poPulve As New Pulverisateur
        poPulve.id = PulverisateurManager.getNewId(m_oAgent)
        poPulve.numeroNational = "E001123456"
        poPulve.idStructure = m_oAgent.idStructure
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
        poPulve.anneeAchat = "1970"
        poPulve.surfaceParAn = "10"
        poPulve.nombreUtilisateurs = "2"
        poPulve.isCuveRincage = True
        poPulve.capaciteCuveRincage = "20"
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
        poPulve.buseAge = "5"
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
        poPulve.modeUtilisation = "CUMA"
        poPulve.nombreExploitants = "10"

        PulverisateurManager.save(poPulve, pExploit.id, m_oAgent)
        Return poPulve
    End Function

    Protected Function createDiagnostic(pExploit As Exploitation, pPulve As Pulverisateur, Optional pbSave As Boolean = True) As Diagnostic
        Dim oDiag = New Diagnostic(m_oAgent, pPulve, pExploit)
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        oDiag.setOrganisme(m_oAgent)
        Dim oDiagBuses As New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "5"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "3,1"
        oDiagBuses.debitNominal = "3,1"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "7"
        oDiagBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now())
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        Dim oDiagBusesDetail As New DiagnosticBusesDetail()
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
        oDiagBuses.nombre = "5"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "3,2"
        oDiagBuses.debitNominal = "3,3"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "3,4"
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
        oDiagMano542.pressionPulve = "3,1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
        'Mano4
        oDiagMano542 = New DiagnosticMano542()
        oDiagMano542.pressionControle = "4"
        oDiagMano542.pressionPulve = "4,1"
        oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)



        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "1,6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "1,7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "2,6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "2,7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "3,6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "3,7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "4,6"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "4,7"
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

        If (pbSave) Then
            DiagnosticManager.save(oDiag)
        End If

        Return oDiag
    End Function

    Protected Function createIdentPulve(pNumNat As String) As IdentifiantPulverisateur
        Dim obj As IdentifiantPulverisateur
        'Création de 3 Identifiant Pulvé
        obj = New IdentifiantPulverisateur
        obj.id = IdentifiantPulverisateurManager.getNextId()
        obj.idStructure = m_oAgent.idStructure
        obj.numeroNational = Globals.GLOB_DIAG_NUMAGR & pNumNat
        obj.SetEtatINUTILISE()
        obj.dateUtilisation = ""
        obj.libelle = ""
        IdentifiantPulverisateurManager.Save(obj, True)
        Return obj
    End Function


End Class
