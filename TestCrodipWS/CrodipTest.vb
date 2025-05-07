Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CRODIPWS
Imports Microsoft.Win32

'''<summary>
'''Classe de de base pour les tests CRODIP
'''</summary>
<TestClass()>
Public Class CRODIPTest


    'Admin-test.crodip.net
    Protected m_IdAgent As Integer = 1293
    Protected m_numNatAgent As String = "MCOTU"
    Protected m_idStructure As Integer = 562
    Protected m_aidBanc As String = "BCTU"
    Protected m_uidBanc As Integer = 96
    Protected m_idPC As String = "MCOTU2"



    Private testContextInstance As TestContext
    Protected m_oAgent As Agent
    Public agentCourant As Agent
    Protected m_oStructure As [Structure]
    Protected m_oPc As AgentPc

    Protected m_oExploitation As Exploitation
    Protected m_oPulve As Pulverisateur
    Protected m_oDiag As Diagnostic

    Protected m_oBanc As CRODIPWS.Banc
    Protected m_RegistryPC As String
    Protected m_RegistryCLE As String

    Public Sub New()

    End Sub

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
    '    GlobalsCRODIP.Init()
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
    <TestInitialize()>
    Public Sub MyTestInitialize()
        ConfigManager.initGlobalsCrodip()
        CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        Dim oCSDB As New CSDb(True)
        oCSDB.RAZ_BASE_DONNEES()
        oCSDB.free()

        'Création de la Structure
        m_oStructure = StructureManager.WSgetById(m_idStructure, m_idStructure)
        Assert.IsNotNull(m_oStructure, "erreur en Récupération de la structure")
        StructureManager.save(m_oStructure)
        m_idStructure = m_oStructure.id

        'Creation d'un agent
        m_oAgent = AgentManager.WSgetByNumeroNational(m_numNatAgent, True)
        m_IdAgent = m_oAgent.id

        'Création du PC
        Dim oAgentPC As New AgentPc
        oAgentPC.idPc = "999999"
        oAgentPC.uidstructure = m_oStructure.uid
        AgentPcManager.Save(oAgentPC)

        'Récupération du banc de la structure
        'Si il n'existe pas on le récupère du WS
        m_oBanc = BancManager.WSgetById(m_uidBanc, m_aidBanc)
        Assert.IsNotNull(m_oBanc, "erreur en Récupération du banc")

        Dim oSynchro As New Synchronisation(m_oAgent)

        oSynchro.MAJDateDerniereSynchro()

        Const RegistryPath As String = "HKEY_CURRENT_USER\CRODIP"
        Const subkey1 As String = "CRODIP"
        Const subkey2 As String = "PC"
        m_RegistryPC = Registry.GetValue(RegistryPath, subkey2, "VIDE")
        m_RegistryCLE = Registry.GetValue(RegistryPath, subkey1, "VIDE")

        m_oPc = AgentPcManager.GetAgentPCFromRegistry()
        If m_oPc Is Nothing Then
            m_oPc = AgentPcManager.WSgetById(0, m_idPC)
        End If

    End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    <TestCleanup()>
    Public Sub MyTestCleanup()
        Const RegistryPath As String = "HKEY_CURRENT_USER\CRODIP"
        Const subkey1 As String = "CRODIP"
        Const subkey2 As String = "PC"
        Registry.SetValue(RegistryPath, subkey2, m_RegistryPC)
        Registry.SetValue(RegistryPath, subkey1, m_RegistryCLE)

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
        pClient.telephoneFixe = "0202020202"
        pClient.telephonePortable = "0606060606"
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
        poPulve.numeroNational = "E001123456"
        poPulve.uidstructure = m_oAgent.uidstructure
        poPulve.ancienIdentifiant = "ANCID"
        poPulve.marque = "MARQUEPULVE"
        poPulve.modele = "MODELEPULVE"
        poPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
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
        poPulve.pulverisation = Pulverisateur.CATEGORIEPULVE_FACEPARFACE
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

        PulverisateurManager.save(poPulve, pExploit, m_oAgent)
        Return poPulve
    End Function
    Protected Function createAndSaveDiagnostic() As Diagnostic
        m_oExploitation = createExploitation()
        m_oPulve = createPulve(m_oExploitation)
        m_oDiag = createDiagnostic(m_oExploitation, m_oPulve, True)
        Return m_oDiag

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
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "1"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "1,7"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "2"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "3"
        oDiagTroncons833.pressionSortie = "1,8"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "3"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "4"
        oDiagTroncons833.pressionSortie = "1,9"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "4"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "2,6"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "1"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "2,7"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "2"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "3"
        oDiagTroncons833.pressionSortie = "2,8"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "3"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "4"
        oDiagTroncons833.pressionSortie = "2,9"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "4"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "3,6"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "1"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "3,7"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "2"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "3"
        oDiagTroncons833.pressionSortie = "3,8"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "3"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "4"
        oDiagTroncons833.pressionSortie = "3,9"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "4"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "4,6"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "1"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "4,7"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "2"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "3"
        oDiagTroncons833.pressionSortie = "4,8"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "3"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "4"
        oDiagTroncons833.pressionSortie = "4,9"
        oDiagTroncons833.nNiveau = "1"
        oDiagTroncons833.nTroncon = "4"
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
        obj.idStructure = m_oAgent.uidstructure
        obj.numeroNational = GlobalsCRODIP.GLOB_DIAG_NUMAGR & pNumNat
        obj.SetEtatINUTILISE()
        obj.dateUtilisation = ""
        obj.libelle = ""
        IdentifiantPulverisateurManager.Save(obj, True)
        Return obj
    End Function


End Class
