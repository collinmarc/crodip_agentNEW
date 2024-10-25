Imports System.Text
Imports CrodipWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class SynchroVTTest
    Inherits CRODIPTest
    <TestMethod()>
    Public Sub WS_ManoControle()
        Dim oManometreControle As ManometreControle
        Dim oManometreControle2 As ManometreControle
        Dim bReturn As Boolean
        Dim idManometreControle As String
        Dim UpdatedObject As New Object

        'Creation d'un ManometreControle
        oManometreControle = New ManometreControle()
        idManometreControle = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oManometreControle.idCrodip = idManometreControle
        oManometreControle.numeroNational = idManometreControle
        oManometreControle.idStructure = m_oAgent.idStructure
        oManometreControle.isSupprime = False
        oManometreControle.marque = "MaMarque"
        oManometreControle.etat = True
        oManometreControle.type = "MonType"
        oManometreControle.fondEchelle = "MonFond"
        oManometreControle.resolution = "MaResolution"
        oManometreControle.dateDernierControleS = CSDate.ToCRODIPString(CDate("07/02/1964"))
        oManometreControle.AgentSuppression = m_oAgent.nom
        oManometreControle.RaisonSuppression = "MaRaison"
        oManometreControle.DateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oManometreControle.nbControles = 5
        oManometreControle.nbControlesTotal = 15
        oManometreControle.bAjusteur = True
        oManometreControle.resolutionLecture = "0.01"
        oManometreControle.typeTraca = "B"
        oManometreControle.numTraca = 6
        oManometreControle.typeRaccord = "RA"
        Assert.IsTrue(ManometreControleManager.save(oManometreControle))

        Dim response As Integer = ManometreControleManager.WSSend( oManometreControle, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oManometreControle2 = ManometreControleManager.WSGetById("", oManometreControle.numeroNational)
        Assert.AreEqual(oManometreControle.numeroNational, oManometreControle2.numeroNational)
        Assert.AreEqual(oManometreControle.idCrodip, oManometreControle2.idCrodip)
        Assert.AreEqual(oManometreControle2.isSupprimeWS, False)
        Assert.AreEqual(oManometreControle.etat, oManometreControle2.etat)

        '        Assert.AreEqual(oManometreControle.AgentSuppression, oManometreControle2.AgentSuppression)
        ' Assert.AreEqual(oManometreControle.RaisonSuppression, oManometreControle2.RaisonSuppression)
        'Assert.AreEqual(oManometreControle.DateSuppression, oManometreControle2.DateSuppression)
        Assert.AreEqual(oManometreControle.type, oManometreControle2.type)
        Assert.AreEqual(oManometreControle.fondEchelle, oManometreControle2.fondEchelle)
        Assert.AreEqual(oManometreControle.resolution, oManometreControle2.resolution)
        Assert.AreEqual(oManometreControle.dateDernierControleS, oManometreControle2.dateDernierControleS)
        Assert.AreEqual(oManometreControle2.nbControles, 5)
        Assert.AreEqual(oManometreControle2.nbControlesTotal, 15)
        Assert.AreEqual(oManometreControle2.bAjusteur, True)
        Assert.AreEqual(oManometreControle2.resolutionLecture, "0.01")
        Assert.AreEqual(oManometreControle2.typeTraca, "B")
        Assert.AreEqual(oManometreControle2.numTraca, 6)
        Assert.AreEqual(oManometreControle2.typeRaccord, "RA")

        oManometreControle2.nbControles = 10
        oManometreControle2.nbControlesTotal = 20
        oManometreControle2.bAjusteur = False
        oManometreControle2.resolutionLecture = "0.02"
        oManometreControle2.typeTraca = "H"
        oManometreControle2.numTraca = 2
        oManometreControle2.typeRaccord = "RH"
        System.Threading.Thread.Sleep(1000)
        Assert.IsTrue(ManometreControleManager.save(oManometreControle2))

        response = ManometreControleManager.WSSend( oManometreControle2, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oManometreControle2 = ManometreControleManager.WSGetById("", oManometreControle2.numeroNational)
        Assert.AreEqual(oManometreControle2.nbControles, 10)
        Assert.AreEqual(oManometreControle2.nbControlesTotal, 20)
        Assert.AreEqual(oManometreControle2.bAjusteur, False)
        Assert.AreEqual(oManometreControle2.resolutionLecture, "0.02")
        Assert.AreEqual(oManometreControle2.typeTraca, "H")
        Assert.AreEqual(oManometreControle2.numTraca, 2)
        Assert.AreEqual(oManometreControle2.typeRaccord, "RH")


        bReturn = ManometreControleManager.delete(idManometreControle)
        Assert.IsTrue(bReturn)

    End Sub
    <TestMethod()>
    Public Sub sendWSAgentTest()
        Dim agent As Agent = Nothing
        Dim agentLu As Agent = Nothing
        Dim updatedObject As Object = Nothing
        Dim updatedObjectExpected As Object = Nothing
        Dim expected As Object = Nothing
        Dim actual As Object

        'WSCrodip.Init(WSCrodip.URL)
        agent = New Agent()
        agent.id = "6666"
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
        agent.idCRODIPPool = "123"
        AgentManager.save(agent)

        actual = AgentManager.WSSend(agent, updatedObject)

        agentLu = AgentManager.WSgetById(agent.numeroNational)
        'Assert.AreEqual(agent.id, agentLu.id)
        'TODO : Controle de l'objet lu a reactiver !!!
        Assert.AreEqual(agent.numeroNational, agentLu.numeroNational)
        'Assert.AreEqual(agentLu.nom, agent.nom)
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
        'Assert.AreEqual(agentLu.motDePasse, "mdp")
        'Assert.AreEqual(agentLu.statut, "STATUT")
        'Assert.AreEqual(agentLu.telephonePortable, "0680667189")
        'Assert.AreEqual(agentLu.versionLogiciel, "VERSION")
        'Assert.AreEqual(agentLu.DroitsPulves, "Rampes|Voute")
        'Assert.AreEqual(True, agentLu.isSignElecActive)
        Assert.AreEqual(agent.idCRODIPPool, "123")

    End Sub
    <TestMethod()>
    Public Sub Get_Send_WS_Diagnostic()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim idDiag As String
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim UpdateInfo As New Object

        oExploit = createExploitation()
        ExploitationManager.WSSend( oExploit, UpdateInfo)
        oPulve = createPulve(oExploit)

        PulverisateurManager.WSSend(oPulve, UpdateInfo)
        Dim oExploitToPulve As ExploitationTOPulverisateur
        oExploitToPulve = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oExploit.id, oPulve.id)
        ExploitationTOPulverisateurManager.WSSend(oExploitToPulve, UpdateInfo)

        'Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)

        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPremierControle = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today.ToShortDateString()
        oDiag.pulverisateurEmplacementIdentification = "DERRIERE"
        oDiag.controleManoControleNumNational = "TEST"
        oDiag.controleNbreNiveaux = 2
        oDiag.controleNbreTroncons = 5
        oDiag.controleUseCalibrateur = True
        oDiag.controleBancMesureId = "IDBANC"
        oDiag.isSupprime = True
        oDiag.diagRemplacementId = "1234"
        oDiag.isSignCCAgent = True
        oDiag.isSignCCClient = True
        oDiag.isSignRIAgent = True
        oDiag.isSignRIClient = True
        oDiag.dateSignCCAgent = CDate("02-10-2023")
        oDiag.dateSignCCClient = CDate("03-10-2023")
        oDiag.dateSignRIAgent = CDate("02-10-2023")
        oDiag.dateSignRIClient = CDate("03-10-2023")
        oDiag.isContrevisiteImmediate = True
        oDiag.isGratuit = True
        oDiag.BLFileName = "BLFileNAme.pdf"
        oDiag.CCFileName = "CCFileNAme.pdf"
        oDiag.RIFileName = "RIFileNAme.pdf"
        oDiag.SMFileName = "SMFileNAme.pdf"
        oDiag.ESFileName = "ESFileNAme.pdf"
        oDiag.FACTFileNames = "FactFileNAme.pdf"
        oDiag.COPROFileName = "COPROFileNAme.pdf"
        oDiag.TotalHT = 100
        oDiag.TotalTTC = 120



        'SAuvegarde du Diag
        '====================
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id
        'Rechargement du Diag
        '=======================
        oDiag = DiagnosticManager.getDiagnosticById(idDiag)
        Assert.AreEqual(idDiag, oDiag.id)

        Dim response As Object = Nothing
        DiagnosticManager.WSSend( oDiag, response)



        'Suppression du diag par sécurité 
        DiagnosticManager.delete(oDiag.id)

        'Synchronisation descendate du Diag
        '==================================
        oDiag2 = DiagnosticManager.WSgetById(m_oAgent.id, oDiag.id)


        Assert.AreEqual(oDiag.id, oDiag2.id)
        Assert.AreEqual(oDiag.controleNomSite, oDiag2.controleNomSite)
        Assert.AreEqual(oDiag.controleIsPulveRepare, oDiag2.controleIsPulveRepare)
        Assert.AreEqual(True, oDiag2.controleIsPremierControle)
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
        Assert.IsTrue(oDiag2.isSupprime)
        Assert.AreEqual("1234", oDiag2.diagRemplacementId)
        Assert.AreEqual(oDiag2.isSignCCAgent, True)
        Assert.AreEqual(oDiag2.isSignCCClient, True)
        Assert.AreEqual(oDiag2.isSignRIAgent, True)
        Assert.AreEqual(oDiag2.isSignRIClient, True)
        Assert.AreEqual(oDiag2.dateSignCCAgent, CDate("02-10-2023"))
        Assert.AreEqual(oDiag2.dateSignCCClient, CDate("03-10-2023"))
        Assert.AreEqual(oDiag2.dateSignRIAgent, CDate("02-10-2023"))
        Assert.AreEqual(oDiag2.dateSignRIClient, CDate("03-10-2023"))
        Assert.AreEqual(oDiag2.isContrevisiteImmediate, True)
        Assert.AreEqual(oDiag2.isGratuit, True)
        Assert.AreEqual(oDiag.BLFileName, "BLFileNAme.pdf")
        Assert.AreEqual(oDiag2.CCFileName, "CCFileNAme.pdf")
        Assert.AreEqual(oDiag2.RIFileName, "RIFileNAme.pdf")
        Assert.AreEqual(oDiag2.SMFileName, "SMFileNAme.pdf")
        Assert.AreEqual(oDiag2.ESFileName, "ESFileNAme.pdf")
        Assert.AreEqual(oDiag2.FACTFileNames, "FactFileNAme.pdf")
        Assert.AreEqual(oDiag2.COPROFileName, "COPROFileNAme.pdf")
        Assert.AreEqual(oDiag.TotalHT, 100)
        Assert.AreEqual(oDiag.TotalTTC, 120)





    End Sub
    <TestMethod()>
    Public Sub Get_Send_WS_Diagnostic_833()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim idDiag As String
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim UpdateInfo As New Object

        oExploit = createExploitation()
        ExploitationManager.WSSend( oExploit, UpdateInfo)
        oPulve = createPulve(oExploit)
        PulverisateurManager.WSSend(oPulve, UpdateInfo)
        Dim oExploitToPulve As ExploitationTOPulverisateur
        oExploitToPulve = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oExploit.id, oPulve.id)
        ExploitationTOPulverisateurManager.WSSend(oExploitToPulve, UpdateInfo)

        'Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)

        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today.ToShortDateString()
        oDiag.pulverisateurEmplacementIdentification = "DERRIERE"
        oDiag.controleManoControleNumNational = "TEST"
        oDiag.controleNbreNiveaux = 2
        oDiag.controleNbreTroncons = 5
        oDiag.controleUseCalibrateur = True
        oDiag.controleBancMesureId = "IDBANC"
        oDiag.isSupprime = True
        oDiag.diagRemplacementId = "1234"

        'Ajout des Tronçons 833
        '======================
        Dim oDiagTroncons833 As DiagnosticTroncons833
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "1,6"
        oDiagTroncons833.ManocId = "0001"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab1
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "1,7"
        oDiagTroncons833.ManocId = "0002"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "2,6"
        oDiagTroncons833.ManocId = "0003"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab2
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "2,7"
        oDiagTroncons833.ManocId = "0004"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "3.6"
        oDiagTroncons833.ManocId = "0005"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab3
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.ManocId = "0006"
        oDiagTroncons833.pressionSortie = "3.7"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "4.6"
        oDiagTroncons833.ManocId = "0007"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)
        'Pression Tab4
        oDiagTroncons833 = New DiagnosticTroncons833()
        oDiagTroncons833.idPression = "4"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "4.7"
        oDiagTroncons833.ManocId = "0008"
        oDiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)


        'SAuvegarde du Diag
        '====================
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        Dim response As Object = Nothing
        DiagnosticManager.WSSend( oDiag, response)
        Dim responseDiag833 As Object = DiagnosticTroncons833Manager.WSSend(oDiag)

        'Suppression du diag par sécurité 
        DiagnosticManager.delete(oDiag.id)

        'Synchronisation descendate du Diag
        '==================================
        oDiag2 = DiagnosticManager.WSgetById(m_oAgent.id, oDiag.id)
        DiagnosticManager.save(oDiag2)

        Dim oManoTroncon833 As New DiagnosticTroncons833
        Dim oListManotroncon833 As New DiagnosticTroncons833List
        Dim oCSDB As New CSDb(True)
        oListManotroncon833 = DiagnosticTroncons833Manager.WSGetList(oDiag2.uid, oDiag2.id)
        For Each oManoTroncon833 In oListManotroncon833.Liste
                DiagnosticTroncons833Manager.save(oManoTroncon833, oCSDB, True)
            Next
        DiagnosticTroncons833Manager.getDiagnosticTroncons833ByDiagnostic(oCSDB, oDiag2)
        oCSDB.free()


        'Vérification des Troncons833

        Assert.AreEqual(8, oDiag2.diagnosticTroncons833.Liste.Count)
        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(0)
        Assert.IsTrue(oDiagTroncons833.idPression = "1")
        Assert.IsTrue(oDiagTroncons833.idColumn = "1")
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1,6")
        Assert.AreEqual("0001", oDiagTroncons833.ManocId)

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(1)
        Assert.IsTrue(oDiagTroncons833.idPression = "1")
        Assert.IsTrue(oDiagTroncons833.idColumn = "2")
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "1,7")
        Assert.AreEqual("0002", oDiagTroncons833.ManocId)

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(2)
        Assert.IsTrue(oDiagTroncons833.idPression = "2")
        Assert.IsTrue(oDiagTroncons833.idColumn = "1")
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2,6")
        Assert.AreEqual("0003", oDiagTroncons833.ManocId)

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(3)
        Assert.IsTrue(oDiagTroncons833.idPression = "2")
        Assert.IsTrue(oDiagTroncons833.idColumn = "2")
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "2,7")
        Assert.AreEqual("0004", oDiagTroncons833.ManocId)

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(4)
        Assert.IsTrue(oDiagTroncons833.idPression = "3")
        Assert.IsTrue(oDiagTroncons833.idColumn = "1")
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.6")
        Assert.AreEqual("0005", oDiagTroncons833.ManocId)

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(5)
        Assert.IsTrue(oDiagTroncons833.idPression = "3")
        Assert.IsTrue(oDiagTroncons833.idColumn = "2")
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "3.7")
        Assert.AreEqual("0006", oDiagTroncons833.ManocId)

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(6)
        Assert.IsTrue(oDiagTroncons833.idPression = "4")
        Assert.IsTrue(oDiagTroncons833.idColumn = "1")
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.6")
        Assert.AreEqual("0007", oDiagTroncons833.ManocId)

        oDiagTroncons833 = oDiag2.diagnosticTroncons833.Liste(7)
        Assert.IsTrue(oDiagTroncons833.idPression = "4")
        Assert.IsTrue(oDiagTroncons833.idColumn = "2")
        Assert.IsTrue(oDiagTroncons833.pressionSortie = "4.7")
        Assert.AreEqual("0008", oDiagTroncons833.ManocId)

        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub
    <TestMethod()>
    Public Sub Get_Send_WS_Diagnostic_Buses()
        Dim oDiag As Diagnostic
        Dim oDiag2 As Diagnostic
        Dim idDiag As String
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim UpdateInfo As New Object

        oExploit = createExploitation()
        ExploitationManager.WSSend( oExploit, UpdateInfo)
        oPulve = createPulve(oExploit)
        PulverisateurManager.WSSend(oPulve, UpdateInfo)
        Dim oExploitToPulve As ExploitationTOPulverisateur
        oExploitToPulve = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oExploit.id, oPulve.id)
        ExploitationTOPulverisateurManager.WSSend(oExploitToPulve, UpdateInfo)

        'Creation d'un Diagnostic
        '============================
        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)

        oDiag.controleNomSite = "MonSite"
        oDiag.controleIsPulveRepare = True
        oDiag.controleIsPreControleProfessionel = True
        oDiag.controleIsAutoControle = True
        oDiag.proprietaireRepresentant = "REP1"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateFin = Date.Today.ToShortDateString()
        oDiag.pulverisateurEmplacementIdentification = "DERRIERE"
        oDiag.controleManoControleNumNational = "TEST"
        oDiag.controleNbreNiveaux = 2
        oDiag.controleNbreTroncons = 5
        oDiag.controleUseCalibrateur = True
        oDiag.controleBancMesureId = "IDBANC"
        oDiag.isSupprime = True
        oDiag.diagRemplacementId = "1234"

        Dim oDiagBuse As DiagnosticBuses
        Dim oDiagBuseDetail As DiagnosticBusesDetail
        oDiagBuse = New DiagnosticBuses()
        oDiagBuse.idLot = 1
        oDiagBuse.nombre = 5
        oDiagBuse.genre = "AIXR/AI/AIC"
        oDiagBuse.calibre = "025"
        oDiagBuse.couleur = "Lilas"
        oDiagBuse.debitMoyen = "0,992"
        oDiagBuse.debitNominal = "0,99"
        oDiagBuse.ecartTolere = "10"
        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.idBuse = 1
        oDiagBuseDetail.debit = "0.8"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)
        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.idBuse = 2
        oDiagBuseDetail.debit = "0.9"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)
        oDiagBuse = New DiagnosticBuses()
        oDiagBuse.idLot = 2
        oDiagBuse.nombre = 20
        oDiagBuse.genre = "2AIXR/AI/AIC"
        oDiagBuse.calibre = "2025"
        oDiagBuse.couleur = "2Lilas"
        oDiagBuse.debitMoyen = "20,992"
        oDiagBuse.debitNominal = "20,99"
        oDiagBuse.ecartTolere = "210"
        oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)
        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.idBuse = 1
        oDiagBuseDetail.debit = "1.8"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)
        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.idBuse = 2
        oDiagBuseDetail.debit = "1.9"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        'SAuvegarde du Diag
        '====================
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        DiagnosticManager.save(oDiag)
        idDiag = oDiag.id

        'Synchronisation Montante du Diag
        '==================================
        Dim response As Object = Nothing
        DiagnosticManager.WSSend( oDiag, response)
        response = DiagnosticBusesManager.WSSend(oDiag)
        response = DiagnosticBusesDetailManager.WSSend(oDiag)

        'Suppression du diag par sécurité 
        DiagnosticManager.delete(oDiag.id)

        'Synchronisation Descendante du Diag + Sauvegarde
        '==================================================
        oDiag2 = DiagnosticManager.WSgetById(m_oAgent.id, oDiag.id)
        DiagnosticManager.save(oDiag2)

        Dim oDiagBuseList As DiagnosticBusesList
        Dim tmpObject As DiagnosticBuses
        oDiagBuseList = DiagnosticBusesManager.WSGetList(oDiag.uid, oDiag.id)
        Dim oCSDB As New CSDb(True)
        For Each tmpObject In oDiagBuseList.Liste
            DiagnosticBusesManager.save(tmpObject, oCSDB, True)
        Next
        oCSDB.free()
        Dim oDiagBusesDetailList As New DiagnosticBusesDetailList
        Dim oDiagBusesDetail As New DiagnosticBusesDetail
        oDiagBusesDetailList = DiagnosticBusesDetailManager.WSGetList(oDiag.uid, oDiag.id)
        For Each oDiagBusesDetail In oDiagBusesDetailList.Liste
                DiagnosticBusesDetailManager.save(oDiagBusesDetail, True)
            Next

        'Vérification des Buses
        oDiag2 = DiagnosticManager.getDiagnosticById(oDiag.id)

        Assert.AreEqual(2, oDiag2.diagnosticBusesList.Liste.Count)
        oDiagBuse = oDiag2.diagnosticBusesList.Liste(0)
        Assert.AreEqual(oDiagBuse.idLot, "1")
        Assert.AreEqual(oDiagBuse.nombre, "5")
        Assert.AreEqual(oDiagBuse.genre, "AIXR/AI/AIC")
        Assert.AreEqual(oDiagBuse.calibre, "025")
        Assert.AreEqual(oDiagBuse.couleur, "Lilas")
        Assert.AreEqual(oDiagBuse.debitMoyen, "0,992")
        Assert.AreEqual(oDiagBuse.debitNominal, "0,99")
        Assert.AreEqual(oDiagBuse.ecartTolere, "10")
        Assert.AreEqual(oDiagBuse.diagnosticBusesDetailList.Liste.Count, 2)
        oDiagBuseDetail = oDiagBuse.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBuseDetail.idLot, "1")
        Assert.AreEqual(oDiagBuseDetail.idBuse, 1)
        Assert.AreEqual(oDiagBuseDetail.debit, "0.8")
        oDiagBuseDetail = oDiagBuse.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBuseDetail.idLot, "1")
        Assert.AreEqual(oDiagBuseDetail.idBuse, 2)
        Assert.AreEqual(oDiagBuseDetail.debit, "0.9")

        oDiagBuse = oDiag2.diagnosticBusesList.Liste(1)
        Assert.AreEqual(oDiagBuse.idLot, "2")
        Assert.AreEqual(oDiagBuse.nombre, "20")
        Assert.AreEqual(oDiagBuse.genre, "2AIXR/AI/AIC")
        Assert.AreEqual(oDiagBuse.calibre, "2025")
        Assert.AreEqual(oDiagBuse.couleur, "2Lilas")
        Assert.AreEqual(oDiagBuse.debitMoyen, "20,992")
        Assert.AreEqual(oDiagBuse.debitNominal, "20,99")
        Assert.AreEqual(oDiagBuse.ecartTolere, "210")
        Assert.AreEqual(oDiagBuse.diagnosticBusesDetailList.Liste.Count, 2)
        oDiagBuseDetail = oDiagBuse.diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBuseDetail.idLot, "2")
        Assert.AreEqual(oDiagBuseDetail.idBuse, 1)
        Assert.AreEqual(oDiagBuseDetail.debit, "1.8")
        oDiagBuseDetail = oDiagBuse.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBuseDetail.idLot, "2")
        Assert.AreEqual(oDiagBuseDetail.idBuse, 2)
        Assert.AreEqual(oDiagBuseDetail.debit, "1.9")


        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)

    End Sub

    <TestMethod()>
    Public Sub TST_GET_SEND_WS_Exploitation()
        Dim oExploitation As Exploitation
        Dim strId As String

        oExploitation = New Exploitation()
        oExploitation.raisonSociale = "Test Avec accents éèçàù êëï"
        oExploitation.codeApe = "12345"
        oExploitation.codeInsee = "74185"
        oExploitation.surfaceAgricoleUtile = "30"
        oExploitation.idStructure = m_oAgent.idStructure
        ExploitationManager.save(oExploitation, m_oAgent)
        strId = oExploitation.id
        oExploitation = ExploitationManager.getExploitationById(strId)
        Dim oResponse As Object = Nothing
        ExploitationManager.WSSend( oExploitation, oResponse)

        oExploitation = ExploitationManager.WSgetById(-1, strId)
        Assert.AreEqual(strId, oExploitation.id)
        Assert.AreEqual(m_oAgent.idStructure, oExploitation.idStructure)
        Assert.AreEqual("Test Avec accents éèçàù êëï", oExploitation.raisonSociale)
        Assert.AreEqual("12345", oExploitation.codeApe)
        Assert.AreEqual("74185", oExploitation.codeInsee, "ID=" & oExploitation.id)
        Assert.AreEqual("30", oExploitation.surfaceAgricoleUtile)

        ExploitationManager.delete(oExploitation.id)




    End Sub
    <TestMethod(), Ignore()>
    Public Sub TST_GET_SEND_WS_Exploitation2()
        Dim oExploitation As Exploitation

        oExploitation = ExploitationManager.WSgetById(-1, "498-1119-1")
        Assert.AreEqual("498-1119-1", oExploitation.id)
        Assert.AreEqual("Test Avec accents éèçàù êëï", oExploitation.raisonSociale)
        Assert.AreEqual("12345", oExploitation.codeApe)
        Assert.AreEqual("74185", oExploitation.codeInsee, "ID=" & oExploitation.id)
        Assert.AreEqual("30", oExploitation.surfaceAgricoleUtile)

        ExploitationManager.save(oExploitation, m_oAgent)





    End Sub
    <TestMethod()>
    Public Sub TST_GET_SEND_WS_ExploitationToPulverisateur()
        Dim oExploitation As Exploitation
        Dim oExploitation2 As Exploitation
        Dim oPUlve As Pulverisateur
        Dim strId As String
        Dim updateInfo As ExploitationTOPulverisateur
        'Création de l'exploitation 1
        oExploitation = createExploitation()
        Dim oResponse As Object = Nothing
        ExploitationManager.WSSend( oExploitation, oResponse)

        'Création de l'exploitation 2
        oExploitation2 = createExploitation()
        oExploitation2.raisonSociale = "Exploitation2"
        ExploitationManager.save(oExploitation2, m_oAgent)

        ExploitationManager.WSSend( oExploitation2, oResponse)

        oPUlve = createPulve(oExploitation)
        strId = oPUlve.id
        oPUlve.numeroChassis = "132456"
        oPUlve.isPulveAdditionnel = True
        oPUlve.pulvePrincipalNumNat = "123"
        PulverisateurManager.save(oPUlve, oExploitation.id, m_oAgent)
        Dim oReturnP As Pulverisateur
        PulverisateurManager.WSSend(oPUlve, oReturnP)
        ExploitationTOPulverisateurManager.save(oPUlve.id, oExploitation2.id, False, m_oAgent)

        Dim olst As List(Of ExploitationTOPulverisateur) = ExploitationTOPulverisateurManager.getlstExploitationTOPulverisateurByPulverisateurId(oPUlve.id)
        Assert.AreEqual(2, olst.Count)
        Assert.AreEqual(False, olst(0).isSupprimeCoProp)
        Assert.AreEqual(False, olst(1).isSupprimeCoProp)
        ExploitationTOPulverisateurManager.WSSend(olst(0), oResponse)
        ExploitationTOPulverisateurManager.WSSend(olst(1), oResponse)

        Dim oExploitToPulve As ExploitationTOPulverisateur
        oExploitToPulve = ExploitationTOPulverisateurManager.WSgetById(olst(0).uid, olst(0).id)
        Assert.IsFalse(oExploitToPulve.isSupprimeCoProp)
        oExploitToPulve = ExploitationTOPulverisateurManager.WSgetById(olst(1).uid, olst(1).id)
        Assert.IsFalse(oExploitToPulve.isSupprimeCoProp)
        System.Threading.Thread.Sleep(1000)
        'Suppression du 2nd Propriétaire
        ExploitationTOPulverisateurManager.save(oPUlve.id, oExploitation2.id, True, m_oAgent)
        olst = ExploitationTOPulverisateurManager.getlstExploitationTOPulverisateurByPulverisateurId(oPUlve.id, True)
        Assert.AreEqual(2, olst.Count)
        Assert.AreEqual(False, olst(0).isSupprimeCoProp)
        Assert.AreEqual(True, olst(1).isSupprimeCoProp)

        'Envoi de l'element supprimé
        ExploitationTOPulverisateurManager.WSSend(olst(1), oResponse)
        'Récupération de l'élement supprimé
        oExploitToPulve = ExploitationTOPulverisateurManager.WSgetById(olst(1).uid, olst(1).id)
        Assert.IsTrue(oExploitToPulve.isSupprimeCoProp)


        PulverisateurManager.deletePulverisateurID(strId)
        ExploitationManager.delete(oExploitation.id)
        ExploitationManager.delete(oExploitation2.id)


    End Sub
    <TestMethod()>
    Public Sub TST_GET_SEND_WS_Pulverisateur()
        Dim oExploitation As Exploitation
        Dim oPUlve As Pulverisateur
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
        PulverisateurManager.save(oPUlve, oExploitation.id, m_oAgent)
        PulverisateurManager.WSSend(oPUlve, oResponse)

        oPUlve = PulverisateurManager.WSgetById(-1, strId)
        Assert.AreEqual(strId, oPUlve.id)
        Assert.IsTrue(oPUlve.isPulveAdditionnel)
        Assert.AreEqual("123", oPUlve.pulvePrincipalNumNat)
        Assert.AreEqual("132456", oPUlve.numeroChassis)
        Assert.AreEqual(False, oPUlve.isPompesDoseuses)
        Assert.AreEqual(0, oPUlve.nbPompesDoseuses)
        Assert.IsFalse(oPUlve.isCoupureAutoTroncons)
        Assert.IsFalse(oPUlve.isRincagecircuit)
        Assert.IsFalse(oPUlve.isReglageAutoHauteur)

        System.Threading.Thread.Sleep(1000)
        oPUlve.numeroChassis = "132456"
        oPUlve.isPulveAdditionnel = True
        oPUlve.pulvePrincipalNumNat = "123"
        oPUlve.isPompesDoseuses = True
        oPUlve.nbPompesDoseuses = 12
        oPUlve.isCoupureAutoTroncons = True
        oPUlve.isRincagecircuit = True
        oPUlve.isReglageAutoHauteur = True

        PulverisateurManager.save(oPUlve, oExploitation.id, m_oAgent)
        PulverisateurManager.WSSend(oPUlve, oResponse)

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

        PulverisateurManager.deletePulverisateurID(strId)


    End Sub


    <TestMethod(), Ignore()> Public Sub IdentifiantPulveristeurTestWS()
        Dim oIdent As IdentifiantPulverisateur
        Dim oIdent2 As IdentifiantPulverisateur
        Dim nId As Long

        nId = 144
        ''Récupération des Idnentifiant Pulves
        'Dim oSynchro As New Synchronisation(m_oAgent)
        'Dim oLst As New List(Of SynchronisationElmt)()
        'oLst = oSynchro.getListeElementsASynchroniserDESC(m_oAgent)
        'For Each oelmt As SynchronisationElmt In oLst
        '    If TypeOf oelmt Is SynchronisationElmtIdentifiantPulverisateur Then
        '        oIdent = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(m_oAgent, oelmt.IdentifiantEntier)
        '        IdentifiantPulverisateurManager.Save(oIdent)
        '        'on mémorise le dernier Indetifiant
        '        nId = oIdent.id
        '    End If
        'Next

        'Rechargement du dernier Identifiant
        oIdent2 = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(m_oAgent, nId.ToString())
        oIdent2.libelle = "TEST"
        oIdent2.SetEtatINUTILISABLE()
        IdentifiantPulverisateurManager.Save(oIdent2)
        IdentifiantPulverisateurManager.sendWSIdentifiantPulverisateur(m_oAgent, oIdent2)

        oIdent = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(m_oAgent, oIdent2.id.ToString)
        Assert.AreEqual(oIdent2.id, oIdent.id)
        Assert.AreEqual(oIdent2.libelle, oIdent.libelle)
        Assert.AreEqual(oIdent2.numeroNational, oIdent.numeroNational)
        Assert.AreEqual(oIdent2.etat, oIdent.etat)
        Assert.AreEqual(oIdent2.dateUtilisation, oIdent.dateUtilisation)
        oIdent.libelle = "TEST2"
        oIdent.SetEtatUTILISE()
        oIdent.dateUtilisation = DateTime.Today.ToShortDateString()

        IdentifiantPulverisateurManager.Save(oIdent)
        IdentifiantPulverisateurManager.sendWSIdentifiantPulverisateur(m_oAgent, oIdent)
        oIdent2 = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(m_oAgent, oIdent2.id.ToString)

        Assert.AreEqual(oIdent.id, oIdent2.id)
        Assert.AreEqual(oIdent.libelle, oIdent2.libelle)
        Assert.AreEqual(oIdent.numeroNational, oIdent2.numeroNational)
        Assert.AreEqual(oIdent.etat, oIdent2.etat)
        Assert.AreEqual(oIdent.dateUtilisation, oIdent2.dateUtilisation)

    End Sub
    <TestMethod()>
    Public Sub Get_Send_WS_Banc()
        Dim oBanc As Banc
        Dim oBanc2 As Banc

        'Creation d'un Banc
        oBanc = m_oBanc

        oBanc.isSupprime = False
        oBanc.marque = "MaMarque"
        oBanc.modele = "Modele"
        oBanc.etat = True
        oBanc.dateAchat = CSDate.ToCRODIPString(CDate("02/06/1965"))
        oBanc.AgentSuppression = m_oAgent.nom
        oBanc.RaisonSuppression = "MaRaison"
        oBanc.DateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oBanc.dateDernierControle = CDate("06/02/1964")
        oBanc.JamaisServi = True
        oBanc.DateActivation = CDate("06-02-1966")
        oBanc.nbControles = 7
        oBanc.nbControlesTotal = 17
        oBanc.ModuleAcquisition = "MD2"
        BancManager.save(oBanc)

        Dim oReturn As Banc
        Dim response As Integer = BancManager.WSSend(oBanc, oReturn)
        Assert.IsTrue(response = 0 Or response = 2)
        oBanc2 = BancManager.WSgetById(oBanc.uid, oBanc.id)
        Assert.AreEqual(oBanc.id, oBanc2.id)
        Assert.AreEqual(oBanc2.isSupprimeWS, False)
        Assert.AreEqual(oBanc2.etat, oBanc.etat)

        Assert.AreEqual(oBanc2.dateAchat, oBanc.dateAchat)
        Assert.AreEqual(oBanc2.marque, oBanc.marque)
        Assert.AreEqual(oBanc2.modele, oBanc.modele)
        Assert.AreEqual(oBanc2.RaisonSuppression, oBanc.RaisonSuppression)
        Assert.AreEqual(oBanc2.DateSuppression, oBanc.DateSuppression)
        Assert.AreEqual(oBanc2.JamaisServi, oBanc.JamaisServi)
        Assert.AreEqual(oBanc2.dateDernierControle, oBanc.dateDernierControle)
        Assert.AreEqual(oBanc2.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(oBanc2.ModuleAcquisition, oBanc.ModuleAcquisition)
        Assert.AreEqual(oBanc2.nbControles, oBanc.nbControles)
        Assert.AreEqual(oBanc2.nbControlesTotal, oBanc.nbControlesTotal)
        Assert.AreEqual(oBanc2.DateActivation, oBanc.DateActivation)

    End Sub

End Class