Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent



'''<summary>
'''Classe de test pour CsDb, destinée à contenir tous
'''</summary>
<TestClass()> _
Public Class CSDbTest


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
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_AlterDatabase()
        Dim oCSDb As CSDb
        Dim strQuery As String
        strQuery = "ALTER TABLE [Diagnostic] ADD MyNewField YESNO;"
        oCSDb = New CSDb(True)
        oCSDb.getResults(strQuery)
        oCSDb.free()

        oCSDb = New CSDb(True)
        strQuery = "ALTER TABLE [Diagnostic] DROP MyNewField ;"
        oCSDb.getResults(strQuery)

        oCSDb.free()

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod(), Ignore()> _
    Public Sub TST_CompacteDataBase()
        Dim oCSDb As CSDb
        oCSDb = New CSDb()
        Assert.IsTrue(oCSDb.CompacteDataBase())

    End Sub

End Class
