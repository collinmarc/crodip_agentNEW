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


    End Sub


End Class
