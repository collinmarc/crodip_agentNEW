Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CrodipWS



'''<summary>
'''Classe de test pour CSEnvironnement
'''</summary>
<TestClass()> _
Public Class CSEnvironnementTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Obtient ou définit le contexte de test qui fournit
    '''des informations sur la série de tests active ainsi que ses fonctionnalités.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
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
    '''Test pour RenameFiles
    '''</summary>
    <TestMethod()> _
    Public Sub RenameFilesTest()
        Dim sw As System.IO.StreamWriter
        If System.IO.File.Exists(Environment.CurrentDirectory & "\crodip_updater.exe") Then
            System.IO.File.Delete(Environment.CurrentDirectory & "\crodip_updater.exe")
        End If
        sw = System.IO.File.CreateText(Environment.CurrentDirectory & "\crodip_updater.exe.arenommer")
        sw.Close()
        sw = System.IO.File.CreateText(Environment.CurrentDirectory & "\crodip_updater.exe")
        sw.Close()
        System.Threading.Thread.Sleep(100)
        CSEnvironnement.Renamefiles()
        System.Threading.Thread.Sleep(100)
        Assert.IsTrue(System.IO.File.Exists(Environment.CurrentDirectory & "\crodip_updater.exe"))

        If System.IO.File.Exists(Environment.CurrentDirectory & "\crodip_updater.exe.config") Then
            System.IO.File.Delete(Environment.CurrentDirectory & "\crodip_updater.exe.config")
        End If
        sw = System.IO.File.CreateText(Environment.CurrentDirectory & "\crodip_updater.exe.config.arenommer")
        sw.Close()
        sw = System.IO.File.CreateText(Environment.CurrentDirectory & "\crodip_updater.exe.config")
        sw.Close()
        System.Threading.Thread.Sleep(100)
        CSEnvironnement.Renamefiles()
        System.Threading.Thread.Sleep(100)
        Assert.IsTrue(System.IO.File.Exists(Environment.CurrentDirectory & "\crodip_updater.exe.config"))
    End Sub


End Class
