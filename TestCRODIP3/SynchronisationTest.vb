Imports System.Text
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()>
Public Class SynchronisationTest
    Inherits CRODIPTest
    <TestMethod()>
    Public Sub testObject()
        Dim oSyncho = New Synchronisation(m_oAgent)
        oSyncho.sens = "desc"

        Assert.AreEqual("desc", oSyncho.sens)


    End Sub

    <TestMethod()>
    Public Sub testGetLstSynchro()
        Dim oSynchro As New Synchronisation(m_oAgent)
        Dim lstSynchro As List(Of SynchronisationElmt)
        lstSynchro = oSynchro.getListeElementsASynchroniserDESC(m_oAgent.oPCCourant, m_oAgent)
        For Each oSynchoElmt As SynchronisationElmt In lstSynchro
            If oSynchoElmt.Type = "GetDocument" Then
                Assert.IsFalse(String.IsNullOrEmpty(oSynchoElmt.ValeurAuxiliaire))
                Debug.Print(oSynchoElmt.ValeurAuxiliaire)
                oSynchoElmt.SynchroDesc(m_oAgent)
                If (Not oSynchoElmt.ValeurAuxiliaire.ToUpper().Contains(".DLT")) Then
                    Assert.IsTrue(System.IO.File.Exists(My.Settings.ModuleDocumentaire & "/" & oSynchoElmt.IdentifiantChaine))
                End If
            Else
                Assert.IsTrue(String.IsNullOrEmpty(oSynchoElmt.ValeurAuxiliaire))
            End If
        Next



    End Sub

    <TestMethod()>
    Public Sub testConfDiag()
        Dim lstSynchro As List(Of SynchronisationElmt)
        Dim oSynchro As New Synchronisation(m_oAgent)
        lstSynchro = oSynchro.getListeElementsASynchroniserDESC(m_oAgent.oPCCourant, m_oAgent)
        For Each oSynchoElmt As SynchronisationElmt In lstSynchro
            If oSynchoElmt.Type = "GetDocument" Then
                Assert.IsFalse(String.IsNullOrEmpty(oSynchoElmt.ValeurAuxiliaire))
                Assert.IsTrue(oSynchoElmt.SynchroDesc(m_oAgent))
                Debug.Print("ID = " & oSynchoElmt.IdentifiantChaine)
                Debug.Print("VA = " & oSynchoElmt.ValeurAuxiliaire)
                Debug.Print("MD5 = " & oSynchoElmt.ChecksumMD5)
                Debug.Print("CHKCalc = " & oSynchoElmt.ChecksumCalc)
                If (Not oSynchoElmt.ValeurAuxiliaire.ToUpper().Contains(".DLT")) Then
                    Assert.IsTrue(System.IO.File.Exists(My.Settings.ModuleDocumentaire & "/" & oSynchoElmt.IdentifiantChaine))
                End If
            Else
                Assert.IsTrue(String.IsNullOrEmpty(oSynchoElmt.ValeurAuxiliaire))
            End If
        Next



    End Sub


    <TestMethod()>
    Public Sub testSynhcronisationExploitationToPulverisateur()
        Dim oExploit As Exploitation = createExploitation()
        ExploitationManager.save(oExploit, m_oAgent)
        Dim oPulve As Pulverisateur = createPulverisateur(oExploit)
        PulverisateurManager.save(oPulve, oExploit, m_oAgent)
        Dim UpdatedObject As Object = Nothing
        Dim oExploitToPulve As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oExploit.id, oPulve.id)
        Dim response As Integer

        response = ExploitationManager.WSSend(oExploit, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2, "Synhcro Ascendante Exploit NOK=>" & response)

        Dim oReturn As Pulverisateur
        response = PulverisateurManager.WSSend(oPulve, oReturn)
        Assert.IsTrue(response = 0 Or response = 2, "Synhcro Ascendante Pulve NOK=>" & response)

        response = ExploitationTOPulverisateurManager.WSSend(oExploitToPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2, "Synhcro Ascendante NOK=>" & response)

        Dim oExploitToPulve2 As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.WSgetById(oExploitToPulve.uid, oExploitToPulve.aid)

        Assert.IsTrue(ExploitationTOPulverisateurManager.save(oExploitToPulve2, m_oAgent, True))

    End Sub

    <TestMethod()>
    Public Sub testSynchroElemntModuleDocumentaire()
        Dim oSynchro As New Synchronisation(m_oAgent)
        Dim oElmt As New SynchronisationElmtDocument(oSynchro.m_SynchroBoolean)
        Assert.AreEqual("GetDocument", oElmt.Type)
        oElmt.IdentifiantChaine = "/_parametres/cr_RapportInspection.rpt"
        oElmt.IdentifiantEntier = 0
        oElmt.ValeurAuxiliaire = "http://admin-pp.crodip.fr/depots/_parametres/cr_RapportInspection.rpt"
        If File.Exists("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt") Then
            File.Delete("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt")
        End If
        Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt"))
        Dim oFileInfo As New FileInfo("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt")
        Assert.IsTrue(oFileInfo.Length > 1000)

        oElmt = New SynchronisationElmtDocument("/_parametres/REFERENTIEL_BUSE.csv", "http://admin-pp.crodip.fr/depots/_parametres/REFERENTIEL_BUSE.csv", oSynchro.m_SynchroBoolean)
        Assert.AreEqual("GetDocument", oElmt.Type)
        If File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv") Then
            File.Delete("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        End If
        Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv"))
        oFileInfo = New FileInfo("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        Assert.IsTrue(oFileInfo.Length > 1000)


    End Sub
    <TestMethod()>
    Public Sub testSynchroElemntModuleDocumentaire_DLT()
        Dim oSynchro As New Synchronisation(m_oAgent)
        Dim oElmt As New SynchronisationElmtDocument(oSynchro.m_SynchroBoolean)
        Assert.AreEqual("GetDocument", oElmt.Type)
        oElmt.IdentifiantChaine = "/_parametres/cr_RapportInspection.rpt"
        oElmt.IdentifiantEntier = 0
        oElmt.ValeurAuxiliaire = "http://admin-pp.crodip.fr/depots/_parametres/cr_RapportInspection.rpt"
        If File.Exists("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt") Then
            File.Delete("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt")
        End If
        Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt"))
        Dim oFileInfo As New FileInfo("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt")
        Assert.IsTrue(oFileInfo.Length > 1000)

        oElmt = New SynchronisationElmtDocument("/_parametres/REFERENTIEL_BUSE.csv", "http://admin-pp.crodip.fr/depots/_parametres/REFERENTIEL_BUSE.csv", oSynchro.m_SynchroBoolean)
        Assert.AreEqual("GetDocument", oElmt.Type)
        If File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv") Then
            File.Delete("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        End If
        Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv"))
        oFileInfo = New FileInfo("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        Assert.IsTrue(oFileInfo.Length > 1000)

        oElmt = New SynchronisationElmtDocument("/_parametres/REFERENTIEL_BUSE.csv.DLT", "http://admin-pp.crodip.fr/depots/_parametres/REFERENTIEL_BUSE.csv.DLT", oSynchro.m_SynchroBoolean)
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv"))
        oElmt.SynchroDesc(m_oAgent)
        Assert.IsFalse(File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv"))

        'Création d'un répertoire dans paramètres
        My.Computer.FileSystem.CreateDirectory("ModuleDocumentaire/_parametres/_reptemp")
        Dim oSW As StreamWriter = System.IO.File.CreateText("ModuleDocumentaire/_parametres/_reptemp/FileToTest.txt")
        oSW.WriteLine("test")
        oSW.Close()
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/_reptemp/FileToTest.txt"))

        oElmt = New SynchronisationElmtDocument("/_parametres/_reptemp.DLT/FileToTest.txt", "http://admin-pp.crodip.fr/depots/_parametres/_reptemp.DLT/FileToTest.txt", oSynchro.m_SynchroBoolean)
        Assert.IsTrue(Directory.Exists("ModuleDocumentaire/_parametres/_reptemp"))
        oElmt.SynchroDesc(m_oAgent)
        Assert.IsFalse(Directory.Exists("ModuleDocumentaire/_parametres/_reptemp"))

    End Sub
    <TestMethod()>
    Public Sub TestValeurAuxiliaire()
        'Suppression du fichier REFERENTIEL_BUSE.csv
        'If File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv") Then
        ' File.Delete("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        ' End If

        m_oAgent.dateDerniereSynchro = CSDate.GetDateForWS("1970/01/01")
        Dim oSynchro As New Synchronisation(m_oAgent)
        Dim lstSynchro As List(Of SynchronisationElmt)
        lstSynchro = oSynchro.getListeElementsASynchroniserDESC(m_oAgent.oPCCourant, m_oAgent)
        For Each oSynchoElmt As SynchronisationElmt In lstSynchro
            If oSynchoElmt.Type = "GetDocument" Then
                Assert.IsFalse(String.IsNullOrEmpty(oSynchoElmt.ValeurAuxiliaire))
                Assert.AreEqual("https://admin-pp", oSynchoElmt.ValeurAuxiliaire.Substring(0, 16))
                CSDebug.dispInfo(oSynchoElmt.ValeurAuxiliaire)
            End If
        Next
    End Sub
    Private Function createExploitant() As Exploitation
        Dim oExploit As Exploitation

        oExploit = New Exploitation()
        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

        ExploitationManager.save(oExploit, m_oAgent)
        Return oExploit
    End Function
    Private Function createPulverisateur(pExploit As Exploitation) As Pulverisateur
        Dim oPulve As Pulverisateur

        oPulve = New Pulverisateur()
        oPulve.uidStructure = m_oAgent.uidStructure
        oPulve.marque = "MA MARQUE"
        oPulve.modele = "MON MODELE"
        oPulve.numeroNational = "E001456789"
        oPulve.capacite = 300
        oPulve.largeur = "12"
        oPulve.attelage = "3 POINTS"
        oPulve.anneeAchat = "1974"
        oPulve.type = "TYPE PULVE"
        oPulve.categorie = "Canon"
        oPulve.pulverisation = "Jet projeté"
        oPulve.buseType = "TYPEBUSE"
        oPulve.buseFonctionnement = "FCTBUSE"
        oPulve.buseMarque = "MarqueBuse"
        oPulve.buseModele = "ModeleBuse"
        oPulve.emplacementIdentification = "SUR LA FLECHE"
        oPulve.isCuveRincage = False
        oPulve.isLanceLavage = True
        oPulve.isRotobuse = True
        oPulve.isCuveIncorporation = False
        PulverisateurManager.save(oPulve, pExploit, m_oAgent)
        Return oPulve
    End Function
    Private Function createDiag(pExploit As Exploitation, pPulve As Pulverisateur) As Diagnostic
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oDiagItem As DiagnosticItem

        oDiag = New Diagnostic(m_oAgent, pPulve, pExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = "2,5"

        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.genereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        CSFile.open(oEtat.getFileName())
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        DiagnosticManager.save(oDiag)
        Return oDiag

    End Function
    ''' <summary>
    ''' Test de la récuperation des elmts à synchroniser entre 2 Agents
    ''' </summary>

    <TestMethod()>
    Public Sub getUpdatesOrganismeTest()
        'Creation d'un agent
        Dim oAgent2 As Agent
        oAgent2 = New Agent(1125, "TESTUNITAgent2", "TEST", m_oStructure.id)
        oAgent2.nom = "Agent2 de test unitaires"
        oAgent2.prenom = "Agent2 de test unitaires"
        oAgent2.telephonePortable = "0606060606"
        oAgent2.eMail = "a@a.com"
        oAgent2.isActif = True
        AgentManager.save(oAgent2)

        Dim oAgent1 As Agent
        oAgent1 = m_oAgent

        'on crée une exploit, un pulve , un diag avec l'agent2
        m_oAgent = oAgent2

        Dim oExploit As Exploitation = createExploitant()
        ExploitationManager.save(oExploit, m_oAgent)
        Dim oPulve As Pulverisateur = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit, m_oAgent)
        Dim odiag As Diagnostic = createDiagnostic(oExploit, oPulve)
        DiagnosticManager.save(odiag)


        m_oAgent = oAgent1
        Dim oLstExploit As Exploitation()
        Dim oLstPulve As Pulverisateur()
        Dim oLstDiag As Diagnostic()
        oLstExploit = ExploitationManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oLstExploit.Count())

        oLstPulve = PulverisateurManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oLstPulve.Count())

        oLstDiag = DiagnosticManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oLstDiag.Count())


        m_oAgent = oAgent2

        oLstExploit = ExploitationManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oLstExploit.Count())

        oLstPulve = PulverisateurManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oLstPulve.Count())

        oLstDiag = DiagnosticManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oLstDiag.Count())


    End Sub
    ''' <summary>
    ''' Test de la synchronisation Asendante de 2 Agents
    ''' </summary>
    <TestMethod()>
    Public Sub SynchronisationAsc2AgentsTest()
        'Creation d'un agent
        Dim oAgent2 As Agent
        oAgent2 = New Agent(1125, "TESTUNITAgent2", "TEST", m_oStructure.id)
        oAgent2.nom = "Agent2 de test unitaires"
        oAgent2.prenom = "Agent2 de test unitaires"
        oAgent2.telephonePortable = "0606060606"
        oAgent2.eMail = "a@a.com"
        oAgent2.isActif = True
        AgentManager.save(oAgent2)

        Dim oAgent1 As Agent
        oAgent1 = m_oAgent

        'on crée une exploit, un pulve , un diag avec l'agent2
        m_oAgent = oAgent2

        Dim oExploit As Exploitation = createExploitant()
        ExploitationManager.save(oExploit, m_oAgent)
        Dim oPulve As Pulverisateur = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit, m_oAgent)
        Dim odiag As Diagnostic = createDiagnostic(oExploit, oPulve)
        DiagnosticManager.save(odiag)


        m_oAgent = oAgent1
        Dim osync As New Synchronisation(m_oAgent)
        osync.runAscSynchro()



        m_oAgent = oAgent2
        Dim oLstExploit As Exploitation()
        Dim oLstPulve As Pulverisateur()
        Dim oLstDiag As Diagnostic()

        oLstExploit = ExploitationManager.getUpdates(m_oAgent)
        Assert.AreEqual(0, oLstExploit.Count())

        oLstPulve = PulverisateurManager.getUpdates(m_oAgent)
        Assert.AreEqual(0, oLstPulve.Count())

        oLstDiag = DiagnosticManager.getUpdates(m_oAgent)
        Assert.AreEqual(0, oLstDiag.Count())


    End Sub
    ''' <summary>
    ''' Test de synchronisation descendante de 2 agents
    ''' </summary>
    <TestMethod()>
    Public Sub SynchronisationDesc2AgentsTest()
        'Creation d'un agent
        Dim oAgent2 As Agent
        oAgent2 = New Agent(1125, "498002", "AGENT2 Test", m_oStructure.id)
        oAgent2.prenom = "AGENT2 Test"
        oAgent2.telephonePortable = "0606060606"
        oAgent2.eMail = "a@a.com"
        oAgent2.isActif = True
        AgentManager.save(oAgent2)

        Dim oAgent1 As Agent
        oAgent1 = m_oAgent
        Dim osync As Synchronisation

        ' on déclare les 2 agents comme synchronisé
        'Pour éviter de recevoir trop d'information
        osync = New Synchronisation(oAgent2)
        osync.MAJDateDerniereSynchro()
        oAgent1 = AgentManager.getAgentById(oAgent1.id)
        oAgent2 = AgentManager.getAgentById(oAgent2.id)


        'on crée une exploit, un pulve , un diag avec l'agent2
        m_oAgent = oAgent2

        Dim oExploit As Exploitation = createExploitant()
        ExploitationManager.save(oExploit, m_oAgent)
        Dim oPulve As Pulverisateur = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit, m_oAgent)
        Dim odiag As Diagnostic = createDiagnostic(oExploit, oPulve)
        DiagnosticManager.save(odiag)


        Dim oList As List(Of SynchronisationElmt)

        'L'agent 1 se synchronise en Ascendant => Il envoie tous les elements créés par l'Agent2
        osync = New Synchronisation(oAgent1)

        osync.runAscSynchro()
        'Et descendant
        'on regarde combien on a d'éelements à synchroniser
        oList = osync.getListeElementsASynchroniserDESC(m_oAgent.oPCCourant, m_oAgent)
        Console.WriteLine("===Agent1 = ELEMT à SynchroniserDESC (" & oList.Count & ")")
        For Each oElmt As SynchronisationElmt In oList
            Console.WriteLine(oElmt.Type & ":" & oElmt.IdentifiantChaine)
        Next
        osync.runDescSynchro()

        'Lorsque l'agent2 demande s'il y a des choses à synchroniser
        'Il n'y a Rien

        osync = New Synchronisation(oAgent2)
        oList = osync.getListeElementsASynchroniserDESC(m_oAgent.oPCCourant, m_oAgent)

        Console.WriteLine("===Agent2 = ELEMT à SynchroniserDESC (" & oList.Count & ")")
        For Each oElmt As SynchronisationElmt In oList
            Console.WriteLine(oElmt.Type & ":" & oElmt.IdentifiantChaine)
        Next

        Assert.AreEqual(0, oList.Count)

        m_oAgent = oAgent2


    End Sub

    <TestMethod()>
    Public Sub SynchronisationDescNouvelAgent()

        Dim oAgent1 As Agent
        oAgent1 = m_oAgent
        Dim osync As Synchronisation
        Dim oList As List(Of SynchronisationElmt)

        ' on déclare les agents crées comme étant déjà synchronisé
        osync = New Synchronisation(oAgent1)
        osync.MAJDateDerniereSynchro()
        'on regarde combien on a d'éelements à synchroniser
        oList = osync.getListeElementsASynchroniserDESC(m_oAgent.oPCCourant, m_oAgent)
        Assert.AreEqual(0, oList.Count, "La Liste devrait être à ZEro")


        'Creation d'un agent
        Dim oAgent2 As Agent
        oAgent2 = New Agent(1125, "498002", "AGENT2 Test", m_oStructure.id)
        oAgent2.prenom = "AGENT2 Test"
        oAgent2.telephonePortable = "0606060606"
        oAgent2.eMail = "a@a.com"
        oAgent2.isActif = True
        AgentManager.save(oAgent2)

        osync = New Synchronisation(oAgent2)
        oList = osync.getListeElementsASynchroniserDESC(m_oAgent.oPCCourant, m_oAgent)
        Assert.AreEqual(0, oList.Count, "La Liste devrait être à ZEro, même avec le nouvel agent")




    End Sub
    <TestMethod, Ignore()>
    Public Sub GetDateDernSynchro()

        Dim oSynchro As New Synchronisation(m_oAgent)

        oSynchro.Synchro(True, True)

        m_oAgent = AgentManager.getAgentById(m_oAgent.id)

        Assert.AreEqual(DateTime.Now, m_oAgent.dateDerniereSynchro)

    End Sub
    <TestMethod()> Public Sub TestGetHTTPEtat()
        Dim oEtat As EtatCrodip
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)


        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = "2,5"

        oDiag.syntheseErreurMoyenneManoD = 0.35D
        oDiag.syntheseErreurMoyenneCinemometreD = 0.36D
        oDiag.synthesePerteChargeMoyenneD = 0.37D
        oDiag.syntheseErreurMaxiManoD = 1.35D
        oDiag.syntheseUsureMoyenneBusesD = 1.36D
        oDiag.synthesePerteChargeMaxiD = 1.37D
        oDiag.syntheseErreurDebitmetreD = 0.38D
        oDiag.syntheseNbBusesUseesD = 1.38D

        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        DiagnosticManager.save(oDiag)
        oEtat = New EtatRapportInspection(oDiag)
        oEtat.genereEtat()
        oDiag.RIFileName = oEtat.getFileName()
        'CSFile.open(CONST_PATH_EXP & oEtat.getFileName())
        Assert.IsTrue(File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName))
        Dim oFi1 As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
        Dim nOriginalLength As Long
        nOriginalLength = oFi1.Length

        oEtat = New EtatSyntheseMesures(oDiag)
        oEtat.genereEtat()
        oDiag.SMFileName = oEtat.getFileName()

        oEtat = New EtatContratCommercial(oDiag)
        oEtat.genereEtat()
        oDiag.CCFileName = oEtat.getFileName()


        DiagnosticManager.save(oDiag)

        ''Synchronisation des etats
        Assert.IsTrue(DiagnosticManager.SendEtats(oDiag))

        'Suppression des etats générés en local
        File.Delete(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
        Assert.IsFalse(File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName))

        'Récupération des fichiers par HTTP
        Dim Credential As New System.Net.NetworkCredential("crodip", "crodip35")
        Dim filePath As String
        filePath = CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName
        If System.IO.File.Exists(filePath) Then
            System.IO.File.Delete(filePath)
        End If
        Dim uri As Uri
        Dim bResult As Boolean = False
        Dim Methode As String = ""
        If (Not bResult) Then
            Try
                Methode = "Methode1 (getView sans identification)"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/admin/diagnostic/get-pdf-view?id=" & oDiag.id)
                My.Computer.Network.DownloadFile(uri, filePath)
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try
        End If

        If (Not bResult) Then
            Try
                Methode = "Methode2 (getView avec identification en ligne)"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/admin/diagnostic/get-pdf-view?id=" & oDiag.id)
                My.Computer.Network.DownloadFile(uri, filePath, "crodip", "crodip35")
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try

        End If

        If (Not bResult) Then
            Try
                Methode = "Methode3 (getView avec identification Credential)"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/admin/diagnostic/get-pdf-view?id=" & oDiag.id)
                My.Computer.Network.DownloadFile(uri, filePath, Credential, False, 100000, True)
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try

        End If
        If (Not bResult) Then
            Try
                Methode = "Methode4 (pdf sans identification)"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/pdf/" & oDiag.RIFileName)
                My.Computer.Network.DownloadFile(uri, filePath)
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try
        End If

        If (Not bResult) Then
            Try
                Methode = "Methode5 (pdf avec identification en ligne)"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/pdf/" & oDiag.RIFileName)
                My.Computer.Network.DownloadFile(uri, filePath, "crodip", "crodip35")
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try

        End If

        If (Not bResult) Then
            Try
                Methode = "Methode6 (getView avec identification Credential)"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/pdf/" & oDiag.RIFileName)
                My.Computer.Network.DownloadFile(uri, filePath, Credential, False, 100000, True)
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try

        End If

        If (Not bResult) Then
            Try
                Methode = "Methode7 WebClient (pdf avec identification Credential)"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/pdf/" & oDiag.RIFileName)
                Dim MyWebClient As New System.Net.WebClient()
                MyWebClient.Credentials = Credential
                MyWebClient.DownloadFile(uri, filePath)
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try

        End If
        If (Not bResult) Then
            Try
                Methode = "Methode8 WebClient (pdf Sans identification )"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/pdf/" & oDiag.RIFileName)
                Dim MyWebClient As New System.Net.WebClient()
                'MyWebClient.Credentials = Credential
                MyWebClient.DownloadFile(uri, filePath)
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try

        End If
        If (Not bResult) Then
            Try
                Methode = "Methode9 WebClient (getView Sans identification )"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/admin/diagnostic/get-pdf-view?id=" & oDiag.id)
                Dim MyWebClient As New System.Net.WebClient()
                'MyWebClient.Credentials = Credential
                MyWebClient.DownloadFile(uri, filePath)
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try

        End If

        If (Not bResult) Then
            Try
                Methode = "Methode10 WebClient (getView avec identification Credential)"
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                uri = New Uri("http://admin-pp.crodip.fr/admin/diagnostic/get-pdf-view?id=" & oDiag.id)
                Dim MyWebClient As New System.Net.WebClient()
                MyWebClient.Credentials = Credential
                MyWebClient.DownloadFile(uri, filePath)
                If File.Exists(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName) Then
                    Dim oFi As New FileInfo(CrodipWS.GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & oDiag.RIFileName)
                    If (oFi.Length <> nOriginalLength) Then
                        Trace.WriteLine(Methode & " : download file OK, mais fichier à " & oFi.Length.ToString())
                    Else
                        Trace.WriteLine(Methode & " : download file OK, FILE OK !!!!!!")
                        bResult = True
                    End If

                End If
            Catch ex As Exception
                Trace.WriteLine(Methode & " : download ERR " & ex.Message)

            End Try

        End If

        Assert.IsTrue(bResult, "Aucun transfert n'a fonctionné, =>>regarder la trace")
    End Sub
End Class
