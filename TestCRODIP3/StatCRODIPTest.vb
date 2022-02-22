Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour Diagnostic et DiagnosticManager
'''</summary>
<TestClass()> _
Public Class StatsCrodipTest
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


    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Load()
        Dim ostat As StatsCrodip
        ostat = New StatsCrodip()

        Assert.IsTrue(ostat.Fill(m_oAgent, Date.Now.Year))

    End Sub

    <TestMethod()> _
    Public Sub TST_LoadNbrectrl()
        Dim ostat As StatsCrodip
        ostat = New StatsCrodip()

        Assert.IsTrue(ostat.Fill(m_oAgent, Date.Now.Year))
        Dim nCtrlS As Integer = ostat.NCtrlStructureTotal
        Dim nCtrlSA As Integer = ostat.NCtrlStructureAnnee
        Dim nCtrlI As Integer = ostat.NCtrlInspecteurTotal
        Dim nCtrlIA As Integer = ostat.NCtrlInspecteurAnnee

        Dim nCtrlOKS As Integer = ostat.NCtrl_OK_StructureTotal
        Dim nCtrlOKSA As Integer = ostat.NCtrl_OK_StructureAnnee
        Dim nCtrlOKI As Integer = ostat.NCtrl_OK_InspecteurTotal
        Dim nCtrlOKIA As Integer = ostat.NCtrl_OK_InspecteurAnnee

        Dim oDiag As Diagnostic = createAndSaveDiagnostic()
        oDiag.controleDateDebut = CSDate.FromCrodipString(Date.Now).ToShortDateString()
        oDiag.controleEtat = Diagnostic.controleEtatNOKCC 'Controle NOK
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Assert.AreEqual(ostat.NCtrlStructureTotal, nCtrlS + 1)
        Assert.AreEqual(ostat.NCtrlStructureAnnee, nCtrlSA + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurTotal, nCtrlI + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurAnnee, nCtrlIA + 1)

        'Modification du numéro d'inspecteur
        oDiag.inspecteurId = m_oAgent.id + 1
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Assert.AreEqual(ostat.NCtrlStructureTotal, nCtrlS + 1)
        Assert.AreEqual(ostat.NCtrlStructureAnnee, nCtrlSA + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurTotal, nCtrlI)
        Assert.AreEqual(ostat.NCtrlInspecteurAnnee, nCtrlIA)

        'Modification du numéro d'inspecteur
        oDiag.inspecteurId = m_oAgent.id + 1
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Assert.AreEqual(ostat.NCtrlStructureTotal, nCtrlS + 1)
        Assert.AreEqual(ostat.NCtrlStructureAnnee, nCtrlSA + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurTotal, nCtrlI)
        Assert.AreEqual(ostat.NCtrlInspecteurAnnee, nCtrlIA)

        'Modification de la date de controle (1 an plus tot)
        oDiag.inspecteurId = m_oAgent.id
        oDiag.controleDateDebut = CSDate.FromCrodipString(DateAdd(DateInterval.Year, -1, Date.Now)).ToShortDateString()
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Assert.AreEqual(ostat.NCtrlStructureTotal, nCtrlS + 1)
        Assert.AreEqual(ostat.NCtrlStructureAnnee, nCtrlSA)
        Assert.AreEqual(ostat.NCtrlInspecteurTotal, nCtrlI + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurAnnee, nCtrlIA)

        'Controle OK
        oDiag.inspecteurId = m_oAgent.id
        oDiag.controleDateDebut = CSDate.FromCrodipString(Date.Now).ToShortDateString()
        oDiag.controleEtat = Diagnostic.controleEtatOK 'Controle OK
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        nCtrlOKI = ostat.NCtrl_OK_InspecteurTotal
        nCtrlOKIA = ostat.NCtrl_OK_InspecteurAnnee
        nCtrlOKS = ostat.NCtrl_OK_StructureTotal
        nCtrlOKSA = ostat.NCtrl_OK_StructureAnnee

        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Controle NOK
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Assert.AreEqual(ostat.NCtrl_OK_InspecteurTotal, nCtrlOKI - 1)
        Assert.AreEqual(ostat.NCtrl_OK_InspecteurAnnee, nCtrlOKIA - 1)
        Assert.AreEqual(ostat.NCtrl_OK_StructureTotal, nCtrlOKS - 1)
        Assert.AreEqual(ostat.NCtrl_OK_StructureAnnee, nCtrlOKSA - 1)

        Dim nCtrlNOKI As Integer = ostat.NCtrl_CP_InspecteurTotal
        Dim nCtrlNOKIA As Integer = ostat.NCtrl_CP_InspecteurAnnee
        Dim nCtrlNOKS As Integer = ostat.NCtrl_CP_StructureTotal
        Dim nCtrlNOKSA As Integer = ostat.NCtrl_CP_StructureAnnee

        oDiag.controleEtat = Diagnostic.controleEtatOK 'Controle OK
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Assert.AreEqual(ostat.NCtrl_CP_InspecteurTotal, nCtrlNOKI - 1)
        Assert.AreEqual(ostat.NCtrl_CP_InspecteurAnnee, nCtrlNOKIA - 1)
        Assert.AreEqual(ostat.NCtrl_CP_StructureTotal, nCtrlNOKS - 1)
        Assert.AreEqual(ostat.NCtrl_CP_StructureAnnee, nCtrlNOKSA - 1)

        'Reparé avant
        oDiag.controleIsPulveRepare = True
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Dim nCtrl_REP_I As Integer = ostat.NCtrl_ReparAvant_InspecteurTotal
        Dim nCtrl_REP_IA As Integer = ostat.NCtrl_ReparAvant_InspecteurAnnee
        Dim nCtrl_REP_S As Integer = ostat.NCtrl_ReparAvant_StructureTotal
        Dim nCtrl_REP_SA As Integer = ostat.NCtrl_ReparAvant_StructureAnnee

        oDiag.controleIsPulveRepare = False
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)

        Assert.AreEqual(ostat.NCtrl_ReparAvant_InspecteurTotal, nCtrl_REP_I - 1)
        Assert.AreEqual(ostat.NCtrl_ReparAvant_InspecteurAnnee, nCtrl_REP_IA - 1)
        Assert.AreEqual(ostat.NCtrl_ReparAvant_StructureTotal, nCtrl_REP_S - 1)
        Assert.AreEqual(ostat.NCtrl_ReparAvant_StructureAnnee, nCtrl_REP_SA - 1)


        'AutoControle
        oDiag.controleIsAutoControle = False
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Dim nCtrl_AC_I As Integer = ostat.NCtrl_AutoControle_InspecteurTotal
        Dim nCtrl_AC_IA As Integer = ostat.NCtrl_AutoControle_InspecteurAnnee
        Dim nCtrl_AC_S As Integer = ostat.NCtrl_AutoControle_StructureTotal
        Dim nCtrl_AC_SA As Integer = ostat.NCtrl_AutoControle_StructureAnnee

        oDiag.controleIsAutoControle = True
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)

        Assert.AreEqual(ostat.NCtrl_AutoControle_InspecteurTotal, nCtrl_AC_I + 1)
        Assert.AreEqual(ostat.NCtrl_AutoControle_InspecteurAnnee, nCtrl_AC_IA + 1)
        Assert.AreEqual(ostat.NCtrl_AutoControle_StructureTotal, nCtrl_AC_S + 1)
        Assert.AreEqual(ostat.NCtrl_AutoControle_StructureAnnee, nCtrl_AC_SA + 1)

        'Precontrole
        oDiag.controleIsPreControleProfessionel = False
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Dim nCtrl_PC_I As Integer = ostat.NCtrl_PreControle_InspecteurTotal
        Dim nCtrl_PC_IA As Integer = ostat.NCtrl_PreControle_InspecteurAnnee
        Dim nCtrl_PC_S As Integer = ostat.NCtrl_PreControle_StructureTotal
        Dim nCtrl_PC_SA As Integer = ostat.NCtrl_PreControle_StructureAnnee

        oDiag.controleIsPreControleProfessionel = True
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)

        Assert.AreEqual(ostat.NCtrl_PreControle_InspecteurTotal, nCtrl_PC_I + 1)
        Assert.AreEqual(ostat.NCtrl_PreControle_InspecteurAnnee, nCtrl_PC_IA + 1)
        Assert.AreEqual(ostat.NCtrl_PreControle_StructureTotal, nCtrl_PC_S + 1)
        Assert.AreEqual(ostat.NCtrl_PreControle_StructureAnnee, nCtrl_PC_SA + 1)
    End Sub
    <TestMethod()> _
    Public Sub TST_AnneeReference()
        Dim ostat As StatsCrodip
        ostat = New StatsCrodip()

        Assert.IsTrue(ostat.Fill(m_oAgent, Date.Now.Year))
        Dim nCtrlS As Integer = ostat.NCtrlStructureTotal
        Dim nCtrlSA As Integer = ostat.NCtrlStructureAnnee
        Dim nCtrlI As Integer = ostat.NCtrlInspecteurTotal
        Dim nCtrlIA As Integer = ostat.NCtrlInspecteurAnnee

        Dim nCtrlOKS As Integer = ostat.NCtrl_OK_StructureTotal
        Dim nCtrlOKSA As Integer = ostat.NCtrl_OK_StructureAnnee
        Dim nCtrlOKI As Integer = ostat.NCtrl_OK_InspecteurTotal
        Dim nCtrlOKIA As Integer = ostat.NCtrl_OK_InspecteurAnnee

        Dim oDiag As New Diagnostic()
        oDiag.setOrganisme(m_oAgent)
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        oDiag.controleDateDebut = CSDate.FromCrodipString(Date.Now).ToShortDateString()
        oDiag.controleEtat = Diagnostic.controleEtatNOKCC 'Controle NOK
        Assert.IsTrue(DiagnosticManager.save(oDiag))
        ostat.Fill(m_oAgent, Date.Now.Year)
        Assert.AreEqual(ostat.NCtrlStructureTotal, nCtrlS + 1)
        Assert.AreEqual(ostat.NCtrlStructureAnnee, nCtrlSA + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurTotal, nCtrlI + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurAnnee, nCtrlIA + 1)

        ostat.Fill(m_oAgent, 2013)
        Assert.AreEqual(ostat.NCtrlStructureTotal, nCtrlS + 1)
        Assert.AreEqual(ostat.NCtrlStructureAnnee, nCtrlSA)
        Assert.AreEqual(ostat.NCtrlInspecteurTotal, nCtrlI + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurAnnee, nCtrlIA)

        'changment d'année d Diag
        oDiag.controleDateDebut = "21/01/2013 08:00:00"

        DiagnosticManager.save(oDiag)
        ostat.Fill(m_oAgent, 2013)
        Assert.AreEqual(ostat.NCtrlStructureTotal, nCtrlS + 1)
        Assert.AreEqual(ostat.NCtrlStructureAnnee, nCtrlSA + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurTotal, nCtrlI + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurAnnee, nCtrlIA + 1)
        ostat.Fill(m_oAgent, Date.Now.Year)
        Assert.AreEqual(ostat.NCtrlStructureTotal, nCtrlS + 1)
        Assert.AreEqual(ostat.NCtrlStructureAnnee, nCtrlSA)
        Assert.AreEqual(ostat.NCtrlInspecteurTotal, nCtrlI + 1)
        Assert.AreEqual(ostat.NCtrlInspecteurAnnee, nCtrlIA)


    End Sub
End Class
