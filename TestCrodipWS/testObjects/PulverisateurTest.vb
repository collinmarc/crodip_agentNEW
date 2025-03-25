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
    <TestMethod()>
    Public Sub testGetNewId()
        Dim oAgentPC As AgentPC
        Dim breturn As Boolean

        oAgentPC = New AgentPC()
        oAgentPC.idCrodip = "12345"
        oAgentPC.uidstructure = m_oAgent.uidstructure
        breturn = AgentPCManager.save(oAgentPC)
        Assert.IsTrue(breturn)

        Dim str As String
        str = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.numeroNational & "-12345-1", str)

        oAgentPC.idCrodip = "1119"
        oAgentPC.uidstructure = m_oAgent.uidstructure
        breturn = AgentPCManager.save(oAgentPC)
        Assert.IsTrue(breturn)
        str = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.numeroNational & "-12345-1", str)

        CSDb.ExecuteSQL("DELETE FROM AgentPC")
        str = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.id & "-1", str)

    End Sub
    <TestMethod()>
    Public Sub TST_GET_SEND_WS_Pulverisateur()
        Dim oExploitation As Exploitation
        Dim oPUlve As Pulverisateur
        Dim oPUlve2 As Pulverisateur
        Dim strId As String

        oExploitation = createExploitation()
        Dim oResponse As Object = Nothing
        ExploitationManager.WSSend(oExploitation, oResponse)

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

    End Sub
    <TestMethod()>
    Public Sub TST_Synchro_Pulverisateur()
        Dim oExploitation As Exploitation
        Dim oPUlve As Pulverisateur
        Dim oPUlve2 As Pulverisateur
        Dim strId As String

        Dim oSynchro As New Synchronisation(m_oAgent)
        oSynchro.runAscSynchro()
        oSynchro.runDescSynchro()
        Threading.Thread.Sleep(1000)

        oExploitation = createExploitation()
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
        PulverisateurManager.save(oPUlve, oExploitation, m_oAgent)
        oSynchro.runAscSynchro()

        oPUlve = PulverisateurManager.getPulverisateurById(oPUlve.id)

        Dim lstE2P As List(Of ExploitationTOPulverisateur)
        lstE2P = ExploitationTOPulverisateurManager.getlstExploitationTOPulverisateurByPulverisateurId(oPUlve.id)
        Assert.AreEqual(1, lstE2P.Count)
        Assert.AreEqual(lstE2P(0).uidpulverisateur, oPUlve.uid)


    End Sub
    <TestMethod()>
    Public Sub TST_CRUD_Pulverisateur()
        Dim oExploitation As Exploitation
        Dim oPUlve As Pulverisateur
        Dim oPUlve2 As Pulverisateur
        Dim strId As String

        oExploitation = createExploitation()
        Dim oResponse As Object = Nothing
        ExploitationManager.WSSend(oExploitation, oResponse)

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


End Class
