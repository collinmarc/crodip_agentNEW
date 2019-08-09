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
        Console.WriteLine(oAss.GetTypes()(0).Name
                          )
        Dim oT As Type = oAss.GetType("AcquisitionMD2.Main")

        Dim oMainAcq As Object = Activator.CreateInstance(oT)
        Dim mainMethod As MethodInfo = oT.GetMethod("CreateInstance")

        Dim oAcq As ICRODIPAcquisition = CType(mainMethod.Invoke(oMainAcq, Nothing), ICRODIPAcquisition)

        Dim oLstValues As List(Of IAcquisitionValue)
        oLstValues = oAcq.GetValues()

        Assert.AreEqual(2, oLstValues.Count)

        Dim oValue As AcquisitionValue
        oValue = CType(oLstValues(0), AcquisitionValue)
        Assert.AreEqual(1, oValue.Niveau)
        Assert.AreEqual(1, oValue.nBuse)
        Assert.AreEqual(1.5D, oValue.Value)

        oValue = CType(oLstValues(1), AcquisitionValue)
        Assert.AreEqual(1, oValue.Niveau)
        Assert.AreEqual(2, oValue.nBuse)
        Assert.AreEqual(2.5D, oValue.Value)

    End Sub

End Class
