Imports System.Reflection
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TestCrodip
Imports CRODIPAcquisition


<TestClass()>
Public Class AcquisitionTest

    Private testContextInstance As TestContext

    '''<summary>
    '''Obtient ou définit le contexte de test qui fournit
    '''des informations sur la série de tests active, ainsi que ses fonctionnalités.
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
    ' Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
    '
    ' Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

    <TestMethod()>
    Public Sub AcqTestLoad()
        Dim oAss As Assembly = Assembly.LoadFrom("AcquisitionMD2.dll")
        Dim oT As Type = oAss.GetType("AcquisitionMD2.Main")

        Dim oMainAcq As Object = Activator.CreateInstance(oT)
        Dim mainMethod As MethodInfo = oT.GetMethod("CreateInstance")

        Dim oAcq As ICRODIPAcquisition = CType(mainMethod.Invoke(oMainAcq, Nothing), ICRODIPAcquisition)

        Dim oLstValues As List(Of AcquisitionValue)
        oLstValues = oAcq.GetValues()

        Assert.AreEqual(2, oLstValues.Count)

        Dim oValue As AcquisitionValue
        oValue = oLstValues(0)
        Assert.AreEqual(1, oValue.Niveau)
        Assert.AreEqual(1, oValue.NumBuse)
        Assert.AreEqual(1.5D, oValue.Debit)

        oValue = oLstValues(1)
        Assert.AreEqual(2, oValue.Niveau)
        Assert.AreEqual(1, oValue.NumBuse)
        Assert.AreEqual(2.5D, oValue.Debit)

    End Sub
    <TestMethod()>
    Public Sub CreateListModulesXML()
        Dim oModule As ModuleAcq

        If System.IO.File.Exists(ModuleAcq.XMLFILE) Then
            System.IO.File.Delete(ModuleAcq.XMLFILE)
        End If

        Dim oLst As New List(Of ModuleAcq)

        oModule = New ModuleAcq()
        oModule.Nom = "MD2"
        oModule.Assembly = "AcquisitionMD2.dll"
        oModule.Main = "AcquisitionMD2.Main"

        oLst.Add(oModule)
        oModule = New ModuleAcq()
        oModule.Nom = "ITEQ"
        oModule.Assembly = "AcquisitionITEQ.dll"
        oModule.Main = "AcquisitionITEQ.Main"

        oLst.Add(oModule)

        ModuleAcq.WriteXML(oLst)

        Assert.IsTrue(System.IO.File.Exists(ModuleAcq.XMLFILE))

        oLst = ModuleAcq.ReadXML()
        Assert.IsNotNull(oLst)
        Assert.AreEqual(2, oLst.Count)
        Assert.AreEqual("MD2", oLst(0).Nom)
        Assert.AreEqual("AcquisitionMD2.dll", oLst(0).Assembly)
        Assert.AreEqual("AcquisitionMD2.Main", oLst(0).Main)

        Assert.AreEqual("ITEQ", oLst(1).Nom)
        Assert.AreEqual("AcquisitionITEQ.dll", oLst(1).Assembly)
        Assert.AreEqual("AcquisitionITEQ.Main", oLst(1).Main)

    End Sub

    <TestMethod()>
    Public Sub TestLoadModule()
        Dim oModule As ModuleAcq

        If System.IO.File.Exists(ModuleAcq.XMLFILE) Then
            System.IO.File.Delete(ModuleAcq.XMLFILE)
        End If

        Dim oLst As New List(Of ModuleAcq)

        oModule = New ModuleAcq()
        oModule.Nom = "MD2"
        oModule.Assembly = "AcquisitionMD2.dll"
        oModule.Main = "AcquisitionMD2.Main"

        oLst.Add(oModule)
        oModule = New ModuleAcq()
        oModule.Nom = "ITEQ"
        oModule.Assembly = "AcquisitionITEQ.dll"
        oModule.Main = "AcquisitionITEQ.Main"

        oLst.Add(oModule)

        ModuleAcq.WriteXML(oLst)

        Dim oModuleAcq As ModuleAcq
        Dim oModule2 As ICRODIPAcquisition
        oModuleAcq = ModuleAcq.GetModule("MD2")
        Assert.AreEqual("MD2", oModuleAcq.Nom)

        oModule2 = oModule.createModuleAcquisition()

        Assert.IsNotNull(oModule2)

        oModuleAcq = ModuleAcq.GetModule("ITEQ")
        Assert.AreEqual("ITEQ", oModuleAcq.Nom)

        oModule2 = oModule.createModuleAcquisition()

        Assert.IsNotNull(oModule2)
    End Sub
    <TestMethod()>
    Public Sub TestMD2()


        Dim builder As New OleDb.OleDbConnectionStringBuilder()
        builder.Add("Data Source", ".\bdd\crodip_dasylab.mdb")
        builder.Add("Provider", "Microsoft.Jet.Oledb.4.0")

        Dim oConn As New OleDb.OleDbConnection(builder.ConnectionString)
        oConn.Open()
        Assert.IsTrue(oConn.State = ConnectionState.Open)

        Dim oCmd As OleDb.OleDbCommand = oConn.CreateCommand()

        oCmd.CommandText = "DELETE  FROM tmpDataAcquiring "
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(1,1,3.1,1.5)"
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(2,1,3.1,2.5)"
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(3,2,3.1,3.5)"
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(4,2,3.1,4.5)"
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(5,2,3.1,5.5)"
        oCmd.ExecuteNonQuery()
        oConn.Close()

        Dim oModuleAcq As ModuleAcq
        oModuleAcq = ModuleAcq.GetModule("MD2")
        Assert.AreEqual("MD2", oModuleAcq.Nom)

        Dim oLstResult As List(Of AcquisitionValue) = oModuleAcq.getValues()

        Assert.AreEqual(5, oLstResult.Count)

        Assert.AreEqual(1, oLstResult(0).Niveau)
        Assert.AreEqual(1, oLstResult(1).Niveau)
        Assert.AreEqual(2, oLstResult(2).Niveau)
        Assert.AreEqual(2, oLstResult(3).Niveau)
        Assert.AreEqual(2, oLstResult(4).Niveau)

        Assert.AreEqual(1, oLstResult(0).NumBuse)
        Assert.AreEqual(2, oLstResult(1).NumBuse)
        Assert.AreEqual(1, oLstResult(2).NumBuse)
        Assert.AreEqual(2, oLstResult(3).NumBuse)
        Assert.AreEqual(3, oLstResult(4).NumBuse)

        Assert.AreEqual(3.1D, oLstResult(0).Debit)
        Assert.AreEqual(3.1D, oLstResult(1).Debit)
        Assert.AreEqual(3.1D, oLstResult(2).Debit)
        Assert.AreEqual(3.1D, oLstResult(3).Debit)
        Assert.AreEqual(3.1D, oLstResult(4).Debit)

        Assert.AreEqual(1.5D, oLstResult(0).Pression)
        Assert.AreEqual(2.5D, oLstResult(1).Pression)
        Assert.AreEqual(3.5D, oLstResult(2).Pression)
        Assert.AreEqual(4.5D, oLstResult(3).Pression)
        Assert.AreEqual(5.5D, oLstResult(4).Pression)


        Assert.AreEqual(2, oModuleAcq.getNbNiveaux())
        Assert.AreEqual(2, oModuleAcq.getNbBuses(1))
        Assert.AreEqual(3, oModuleAcq.getNbBuses(2))
    End Sub

    <TestMethod()>
    Public Sub TestITEQ()


        'Dim builder As New OleDb.OleDbConnectionStringBuilder()
        'builder.Add("Data Source", ".\bdd\crodip_dasylab.mdb")
        'builder.Add("Provider", "Microsoft.Jet.Oledb.4.0")

        'Dim oConn As New OleDb.OleDbConnection(builder.ConnectionString)
        'oConn.Open()
        'Assert.IsTrue(oConn.State = ConnectionState.Open)

        'Dim oCmd As OleDb.OleDbCommand = oConn.CreateCommand()

        'oCmd.CommandText = "DELETE  FROM tmpDataAcquiring "
        'oCmd.ExecuteNonQuery()
        'oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(1,1,3.1,1.5)"
        'oCmd.ExecuteNonQuery()
        'oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(2,1,3.1,2.5)"
        'oCmd.ExecuteNonQuery()
        'oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(3,2,3.1,3.5)"
        'oCmd.ExecuteNonQuery()
        'oCmd.CommandText = "INSERT INTO tmpDataAcquiring ( idbuse, idNiveau,debit,pression) VALUES(4,2,3.1,4.5)"
        'oCmd.ExecuteNonQuery()
        'oConn.Close()

        Dim oModuleAcq As ModuleAcq
        oModuleAcq = ModuleAcq.GetModule("ITEQ")
        Assert.AreEqual("ITEQ", oModuleAcq.Nom)

        Dim oLstResult As List(Of AcquisitionValue) = oModuleAcq.getValues()

        Assert.AreEqual(10, oLstResult.Count)

        Assert.AreEqual(1, oLstResult(0).NumBuse)
        Assert.AreEqual(1, oLstResult(1).NumBuse)
        Assert.AreEqual(1, oLstResult(2).NumBuse)
        Assert.AreEqual(1, oLstResult(3).NumBuse)

        Assert.AreEqual(1.614D, oLstResult(0).Debit)
        Assert.AreEqual(1.622D, oLstResult(1).Debit)
        Assert.AreEqual(1.628D, oLstResult(2).Debit)
        Assert.AreEqual(1.627D, oLstResult(3).Debit)

        Assert.AreEqual(2.845D, oLstResult(0).Pression)
        Assert.AreEqual(2.838D, oLstResult(1).Pression)
        Assert.AreEqual(2.832D, oLstResult(2).Pression)
        Assert.AreEqual(2.832D, oLstResult(3).Pression)

    End Sub
End Class
