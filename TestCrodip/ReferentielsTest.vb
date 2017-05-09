Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO

<TestClass()>
Public Class ReferentielsTest
    Private testContextInstance As TestContext

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
    End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    <TestCleanup()> _
    Public Sub MyTestCleanup()
        Dim oCSDB As New CSDb(True)
        oCSDB.getResults("DELETE FROM DiagnosticTroncons833 WHERE IDDiagnostic like '99-%'")
        oCSDB.getResults("DELETE FROM DiagnosticMano542 WHERE IDDiagnostic like '99-%'")
        oCSDB.getResults("DELETE FROM DIAGNOSTICBusesDetail WHERE IDDiagnostic like '99-%'")
        oCSDB.getResults("DELETE FROM DIAGNOSTICBuses WHERE IDDiagnostic like '99-%'")
        oCSDB.getResults("DELETE FROM DIAGNOSTICItem WHERE ID like '99-%'")
        oCSDB.getResults("DELETE FROM DIAGNOSTIC WHERE ID like '99-%'")
        oCSDB.getResults("DELETE FROM Agent WHERE IDStructure = 99")
    End Sub
#End Region

    <TestMethod(), Ignore()>
    Public Sub TestWS()


        System.IO.File.Delete("./config/pulverisateurs/types-categories.xml")
        Assert.AreNotEqual(Referentiel.RETOURSYNCHRO.ERREUR, ReferentielPulverisateurTypesCategories.SynchroDesc())
        Assert.IsTrue(File.Exists("./config/pulverisateurs/types-categories.xml"))
        Assert.IsTrue(File.ReadAllText("./config/pulverisateurs/types-categories.xml").Length > 1)

        System.IO.File.Delete("./config/pulverisateurs/Marques-Modeles.xml")
        Assert.AreNotEqual(Referentiel.RETOURSYNCHRO.ERREUR, ReferentielPulverisateurMarquesModeles.SynchroDesc())
        Assert.IsTrue(File.Exists("./config/pulverisateurs/Marques-Modeles.xml"))
        Assert.IsTrue(File.ReadAllText("./config/pulverisateurs/Marques-Modeles.xml").Length > 1)

    End Sub

    <TestMethod()>
    Public Sub TestcodeAPE()

        Dim olst As New ListOfCodeAPE()
        Dim GLOB_XML_CODESAPE As CSXml = New CSXml(Environment.CurrentDirectory & "\config\codesAPE.xml")
        olst.lst.Clear()
        olst.readOldFile(GLOB_XML_CODESAPE)
        For Each oCodeAPE As CodeAPE In olst.lst
            CSDebug.dispInfo(oCodeAPE.LibelleComplet)
        Next
    End Sub
End Class
