Imports System.Reflection
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TestCrodip
Imports CRODIPAcquisition
Imports Crodip_agent


<TestClass()>
Public Class AcquisitionTest
    Inherits CRODIPTest

    Private testContextInstance As TestContext


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

        Assert.IsNotNull(oAcq)

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

        oModule2 = oModule.Instance

        Assert.IsNotNull(oModule2)

        oModuleAcq = ModuleAcq.GetModule("ITEQ")
        Assert.AreEqual("ITEQ", oModuleAcq.Nom)

        oModule2 = oModule.Instance

        Assert.IsNotNull(oModule2)
    End Sub
    <TestMethod()>
    Public Sub TestMD2()

        fillMD2Database()

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
    Public Sub TestITEQTest3bCRODIP()



        Dim oModuleAcq As ModuleAcq
        oModuleAcq = ModuleAcq.GetModule("ITEQ")
        Assert.AreEqual("ITEQ", oModuleAcq.Nom)
        oModuleAcq.Instance.setFichier("TestFiles\test 3 b crodip.csv")

        Dim oLstResult As List(Of AcquisitionValue) = oModuleAcq.getValues()

        Assert.AreEqual(36, oLstResult.Count)

        Assert.AreEqual(1, oLstResult(0).NumBuse)
        Assert.AreEqual(2, oLstResult(1).NumBuse)
        Assert.AreEqual(17, oLstResult(16).NumBuse)
        Assert.AreEqual(18, oLstResult(17).NumBuse)
        Assert.AreEqual(1, oLstResult(18).NumBuse)
        Assert.AreEqual(2, oLstResult(19).NumBuse)
        Assert.AreEqual(17, oLstResult(34).NumBuse)
        Assert.AreEqual(18, oLstResult(35).NumBuse)

        Assert.AreEqual(1, oLstResult(0).Niveau)
        Assert.AreEqual(1, oLstResult(1).Niveau)
        Assert.AreEqual(1, oLstResult(16).Niveau)
        Assert.AreEqual(1, oLstResult(17).Niveau)
        Assert.AreEqual(2, oLstResult(18).Niveau)
        Assert.AreEqual(2, oLstResult(19).Niveau)
        Assert.AreEqual(2, oLstResult(34).Niveau)
        Assert.AreEqual(2, oLstResult(35).Niveau)

        Assert.AreEqual(0.332D, oLstResult(0).Debit)
        Assert.AreEqual(0.332D, oLstResult(1).Debit)
        Assert.AreEqual(4.062D, oLstResult(16).Debit)
        Assert.AreEqual(4.062D, oLstResult(17).Debit)
        Assert.AreEqual(0.403D, oLstResult(18).Debit)
        Assert.AreEqual(0.404D, oLstResult(19).Debit)
        Assert.AreEqual(4.057D, oLstResult(34).Debit)
        Assert.AreEqual(4.057D, oLstResult(35).Debit)

        Assert.AreEqual(1.989D, oLstResult(0).Pression)
        Assert.AreEqual(1.998D, oLstResult(1).Pression)
        Assert.AreEqual(2.002D, oLstResult(16).Pression)
        Assert.AreEqual(2.002D, oLstResult(17).Pression)
        Assert.AreEqual(2.993D, oLstResult(18).Pression)
        Assert.AreEqual(2.999D, oLstResult(19).Pression)
        Assert.AreEqual(3.01D, oLstResult(34).Pression)
        Assert.AreEqual(3.011D, oLstResult(35).Pression)

    End Sub

    <TestMethod()>
    Public Sub TestITEQEvrardnozay()



        Dim oModuleAcq As ModuleAcq
        oModuleAcq = ModuleAcq.GetModule("ITEQ")
        Assert.AreEqual("ITEQ", oModuleAcq.Nom)
        oModuleAcq.Instance.setFichier("TestFiles\evrard nozay alex 26 buses.csv")

        Dim oLstResult As List(Of AcquisitionValue) = oModuleAcq.getValues()

        Assert.AreEqual(26, oLstResult.Count)

        Assert.AreEqual(1, oLstResult(0).NumBuse)
        Assert.AreEqual(2, oLstResult(1).NumBuse)
        Assert.AreEqual(17, oLstResult(16).NumBuse)
        Assert.AreEqual(18, oLstResult(17).NumBuse)
        Assert.AreEqual(19, oLstResult(18).NumBuse)
        Assert.AreEqual(20, oLstResult(19).NumBuse)
        Assert.AreEqual(26, oLstResult(25).NumBuse)

        Assert.AreEqual(1, oLstResult(0).Niveau)
        Assert.AreEqual(1, oLstResult(1).Niveau)
        Assert.AreEqual(1, oLstResult(16).Niveau)
        Assert.AreEqual(1, oLstResult(17).Niveau)
        Assert.AreEqual(1, oLstResult(18).Niveau)
        Assert.AreEqual(1, oLstResult(19).Niveau)
        Assert.AreEqual(1, oLstResult(25).Niveau)

        Assert.AreEqual(1.197D, oLstResult(0).Debit)
        Assert.AreEqual(1.179D, oLstResult(1).Debit)
        Assert.AreEqual(1.189D, oLstResult(16).Debit)
        Assert.AreEqual(1.202D, oLstResult(17).Debit)
        Assert.AreEqual(1.191D, oLstResult(18).Debit)
        Assert.AreEqual(1.188D, oLstResult(19).Debit)
        Assert.AreEqual(1.2D, oLstResult(25).Debit)

        Assert.AreEqual(0D, oLstResult(0).Pression)
        Assert.AreEqual(0D, oLstResult(1).Pression)
        Assert.AreEqual(0D, oLstResult(16).Pression)
        Assert.AreEqual(0D, oLstResult(17).Pression)
        Assert.AreEqual(0D, oLstResult(18).Pression)
        Assert.AreEqual(0D, oLstResult(19).Pression)
        Assert.AreEqual(0D, oLstResult(25).Pression)

    End Sub
    <TestMethod()>
    Public Sub TestITEQTestNiv()



        Dim oModuleAcq As ModuleAcq
        oModuleAcq = ModuleAcq.GetModule("ITEQ")
        Assert.AreEqual("ITEQ", oModuleAcq.Nom)
        oModuleAcq.Instance.setFichier("TestFiles\test niv.csv")

        Dim oLstResult As List(Of AcquisitionValue) = oModuleAcq.getValues()

        Assert.AreEqual(20, oLstResult.Count)
        Assert.AreEqual(2, oModuleAcq.getNbNiveaux())
        Assert.AreEqual(10, oModuleAcq.getNbBuses(1))

        Assert.AreEqual(1, oLstResult(0).NumBuse)
        Assert.AreEqual(2, oLstResult(1).NumBuse)
        Assert.AreEqual(7, oLstResult(16).NumBuse)
        Assert.AreEqual(8, oLstResult(17).NumBuse)
        Assert.AreEqual(9, oLstResult(18).NumBuse)

        Assert.AreEqual(1, oLstResult(0).Niveau)
        Assert.AreEqual(1, oLstResult(1).Niveau)
        Assert.AreEqual(2, oLstResult(16).Niveau)
        Assert.AreEqual(2, oLstResult(17).Niveau)
        Assert.AreEqual(2, oLstResult(18).Niveau)

        Assert.AreEqual(0.995D, oLstResult(0).Debit)
        Assert.AreEqual(0.998D, oLstResult(1).Debit)
        Assert.AreEqual(1.2D, oLstResult(16).Debit)
        Assert.AreEqual(1.2D, oLstResult(17).Debit)
        Assert.AreEqual(1.2D, oLstResult(18).Debit)

        Assert.AreEqual(0D, oLstResult(0).Pression)
        Assert.AreEqual(0D, oLstResult(1).Pression)
        Assert.AreEqual(2D, oLstResult(16).Pression)
        Assert.AreEqual(2D, oLstResult(17).Pression)
        Assert.AreEqual(2D, oLstResult(18).Pression)

    End Sub


    Private Sub fillMD2Database()
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

    End Sub

End Class
