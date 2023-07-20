Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour DiagnosticHelp551Test, 
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


    <TestMethod()>
    Public Sub TestTRTSPE()

        m_oPulve = createPulve(createExploitation())
        m_oPulve.type = "Pulvérisateurs fixes ou semi mobiles"
        m_oPulve.categorie = "Traitement des semences"
        Assert.IsTrue(m_oPulve.isTraitementdesSemences)

        m_oPulve.categorie = "Traitement post-récolte"
        Assert.IsFalse(m_oPulve.isTraitementdesSemences)
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

        m_oPulve.TransfertPulve(m_oExploitation.id, oExploit2.id, m_oAgent)

        oRelation = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(m_oExploitation.id, m_oPulve.id)
        'La relation a bien été supprimée
        Assert.IsTrue(String.IsNullOrEmpty(oRelation.id))
        'et Ajoutée à la seconde exploit
        oRelation = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oExploit2.id, m_oPulve.id)
        Assert.IsFalse(String.IsNullOrEmpty(oRelation.id))

    End Sub
    <TestMethod()>
    Public Sub testGetNewId()
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur

        oExploit = createExploitation()
        ExploitationManager.save(oExploit, m_oAgent)
        oPulve = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        oPulve = createPulve(oExploit)
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        m_oAgent.oPool = New Pool()
        m_oAgent.oPool.idCRODIPPC = "12345"

        Dim str As String
        str = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.numeroNational & "-12345-1", str)
        str = ExploitationTOPulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.numeroNational & "-12345-1", str)



        m_oAgent.oPool.idCRODIPPC = "1119"
        str = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual("8888-9999-1119-1", str)
        str = ExploitationTOPulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual(m_oStructure.idCrodip & "-" & m_oAgent.numeroNational & "-1119-1", str)

        m_oAgent.oPool = Nothing
        str = PulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual("498-1119-3", str)
        str = ExploitationTOPulverisateurManager.getNewId(m_oAgent)
        Assert.AreEqual(m_oAgent.idStructure & "-1119-3", str)


    End Sub

End Class
