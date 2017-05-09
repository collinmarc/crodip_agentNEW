'Imports Microsoft.VisualStudio.TestTools.UnitTesting

'Imports Crodip_updater
'Imports dbUpdate


' '''<summary>
' '''Classe de test pour UpdateInfoTest, destinée à contenir tous
' '''les tests unitaires UpdateInfoTest
' '''</summary>
'<TestClass(), Ignore()> _
'Public Class UpdateInfoTest


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


'    '''<summary>
'    '''Test pour majDatabase
'    '''</summary>
'    <TestMethod()> _
'    Public Sub majDatabaseTest()
'        Dim wsResponse As System.Xml.XmlDocument = New System.Xml.XmlDocument()
'        Dim target As DBUpdate.UpdateInfo = New DBUpdate.UpdateInfo(wsResponse) ' TODO: initialisez à une valeur appropriée
'        Dim pSqlFileName As String = String.Empty ' TODO: initialisez à une valeur appropriée
'        Dim expected As Boolean = False ' TODO: initialisez à une valeur appropriée
'        Dim actual As Boolean

'        'System.IO.File.CreateText("R:\Projets\TestCrodip\bin\Debug\updates.sql")
'        'System.IO.File.AppendAllText("R:\Projets\TestCrodip\bin\Debug\updates.sql", "ALTER TABLE [AgentBuseEtalon] ADD dateSuppression date;")

'        'actual = target.majDatabase("C:\Newco\CRODIP\Projets\updates.sql")
'        Assert.AreEqual(True, actual)
'        'System.IO.File.Delete("R:\Projets\TestCrodip\bin\Debug\updates.sql")
'    End Sub
'    '''<summary>
'    '''Test pour majDatabase (ADD COLUMN IF NOT EXIST)
'    '''</summary>
'    <TestMethod()> _
'    Public Sub ADDColumnIFNOTEXISTSTest()
'        Dim wsResponse As System.Xml.XmlDocument = New System.Xml.XmlDocument()
'        Dim target As DBUpdate.UpdateInfo = New DBUpdate.UpdateInfo(wsResponse) ' TODO: initialisez à une valeur appropriée
'        Dim pSqlFileName As String = String.Empty ' TODO: initialisez à une valeur appropriée
'        Dim expected As Boolean = False ' TODO: initialisez à une valeur appropriée
'        Dim actual As Boolean
'        Dim oCSDB As DBUpdate.CSDb
'        Dim oReader As OleDb.OleDbDataReader

'        '--<TEST1> ALTER TABLE [Diagnostic] ADD controleIsPreControleProfessionel YESNO;
'        'Suppression de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "ALTER TABLE [Diagnostic] DROP COLUMN controleIsPreControleProfessionel ;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)

'        'Vérification de la Suppression  de la Colonne
'        oCSDB = New DBUpdate.CSDb(True)
'        oReader = oCSDB.getResults("SELECT controleIsPreControleProfessionel from Diagnostic")
'        Assert.IsTrue(oReader Is Nothing)
'        oCSDB.free()
'        'création de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "--<TEST1> ALTER TABLE [Diagnostic] ADD controleIsPreControleProfessionel YESNO;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)

'        'Vérification de la Création de la Colonne
'        oCSDB = New DBUpdate.CSDb(True)
'        oReader = oCSDB.getResults("SELECT controleIsPreControleProfessionel from Diagnostic")
'        Assert.IsTrue(Not oReader Is Nothing)
'        oCSDB.free()

'        'Tentative de recreation de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "--<TEST1> ALTER TABLE [Diagnostic] ADD controleIsPreControleProfessionel YESNO;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)

'        '--<TEST2> ALTER TABLE [Diagnostic] Add controleIsAutoControle YESNO;
'        'Suppression de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "ALTER TABLE [Diagnostic] DROP COLUMN controleIsAutoControle ;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)

'        'Vérification de la Suppression  de la Colonne
'        oCSDB = New DBUpdate.CSDb(True)
'        oReader = oCSDB.getResults("SELECT controleIsAutoControle from Diagnostic")
'        Assert.IsTrue(oReader Is Nothing)
'        oCSDB.free()

'        'création de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "--<TEST2> ALTER TABLE [Diagnostic] ADD controleIsAutoControle YESNO;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)

'        'Vérification de la Création de la Colonne
'        oCSDB = New DBUpdate.CSDb(True)
'        oReader = oCSDB.getResults("SELECT controleIsAutoControle from Diagnostic")
'        Assert.IsTrue(Not oReader Is Nothing)
'        oCSDB.free()

'        'Tentative de recreation de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "--<TEST2> ALTER TABLE [Diagnostic] ADD controleIsPreControleProfessionel YESNO;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)


'        '--<TEST3> ALTER TABLE [Diagnostic] ADD ProprietaireRepresentant Text;
'        'Suppression de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "ALTER TABLE [Diagnostic] DROP COLUMN ProprietaireRepresentant ;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)

'        'Vérification de la Suppression  de la Colonne
'        oCSDB = New DBUpdate.CSDb(True)
'        oReader = oCSDB.getResults("SELECT ProprietaireRepresentant from Diagnostic")
'        Assert.IsTrue(oReader Is Nothing)
'        oCSDB.free()
'        'création de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "--<TEST3> ALTER TABLE [Diagnostic] ADD ProprietaireRepresentant TEXT;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)

'        'Vérification de la Création de la Colonne
'        oCSDB = New DBUpdate.CSDb(True)
'        oReader = oCSDB.getResults("SELECT ProprietaireRepresentant from Diagnostic")
'        Assert.IsTrue(Not oReader Is Nothing)
'        oCSDB.free()

'        'Tentative de recreation de la Colonne
'        System.IO.File.WriteAllText("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql", "--<TEST3> ALTER TABLE [Diagnostic] ADD ProprietaireRepresentant YESNO;")
'        actual = target.majDatabase("R:\Projets\TestCrodip\bin\Debug\TestFiles\updates.sql")
'        Assert.AreEqual(True, actual)

'    End Sub
'End Class
