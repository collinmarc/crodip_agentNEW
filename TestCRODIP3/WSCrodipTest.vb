'Imports System.Text
'Imports Crodip_agent
'Imports System.Xml.Serialization
'Imports System.IO

'<TestClass()>
'Public Class WSCrodipTest

'    Private testContextInstance As TestContext

'    '''<summary>
'    '''Obtient ou définit le contexte de test qui fournit
'    '''des informations sur la série de tests active ainsi que ses fonctionnalités.
'    '''</summary>
'    Public Property TestContext() As TestContext
'        Get
'            Return testContextInstance
'        End Get
'        Set(value As TestContext)
'            testContextInstance = value
'        End Set
'    End Property
'#Region "Attributs de tests supplémentaires"
'    '
'    'Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
'    '
'    'Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
'    '<ClassInitialize()>  _
'    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
'    'End Sub
'    '
'    'Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
'    '<ClassCleanup()>  _
'    'Public Shared Sub MyClassCleanup()
'    'End Sub
'    '
'    'Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
'    '<TestInitialize()>  _
'    'Public Sub MyTestInitialize()
'    'End Sub
'    '
'    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
'    '<TestCleanup()>  _
'    'Public Sub MyTestCleanup()
'    'End Sub
'    '
'#End Region

'    <TestMethod()>
'    Public Sub TestMethod1()

'        'Dim bWSCrodipProduction As Boolean = Crodip_agent.getSettings_WSCrodipProduction
'        'Dim strUrlProd As String = Crodip_agent.getSettings_WSCrodipURL
'        'Dim strUrlTest As String = Crodip_agent.getSettings_WSCrodipURLTest
'        'Dim bDebug As Boolean = GLOB_ENV_DEBUG

'        'If bDebug Then
'        '    Assert.AreEqual(WSCrodip.getWS().Url, strUrlTest)
'        'End If
'        'If Not bDebug And bWSCrodipProduction Then
'        '    Assert.AreEqual(WSCrodip.getWS().Url, strUrlProd)
'        'End If
'        'If Not bDebug And Not bWSCrodipProduction Then
'        '    Assert.AreEqual(WSCrodip.getWS().Url, strUrlTest)
'        'End If
'        'WSCrodip.Init(strUrlProd)
'        'WSCrodip.getWS()
'        'Assert.AreEqual(WSCrodip.getWS().Url, strUrlProd)
'        'WSCrodip.Init(strUrlTest)
'        'WSCrodip.getWS()
'        'Assert.AreEqual(WSCrodip.getWS().Url, strUrlTest)

'    End Sub


'    <TestMethod(), Ignore()>
'    Public Sub TestGetSoftwareUpdates()


'        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()

'        Dim wsResponse As Object = ""
'        Dim codeResponse As Integer
'        ' Appel au WS
'        Debug.Print("Appel du serveur :" & objWSCrodip.Url)
'        codeResponse = objWSCrodip.GetSoftwareUpdate("20131231235910", wsResponse)
'        Assert.AreEqual(2, codeResponse)
'        codeResponse = objWSCrodip.GetSoftwareUpdate("20100101000000", wsResponse)
'        Assert.AreEqual(2, codeResponse)

'    End Sub

'    <TestMethod()>
'    Public Sub TestEncodage()

'        Dim oRef As New ReferentielBusesCSV()
'        oRef.load()


'    End Sub
'End Class
