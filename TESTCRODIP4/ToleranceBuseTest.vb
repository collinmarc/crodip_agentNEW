Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class ToleranceBuseTest
    Inherits CRODIPTest
    Private testContextInstance As TestContext

    'Public Property TestContext() As TestContext
    '    Get
    '        Return testContextInstance
    '    End Get
    '    Set(ByVal value As TestContext)
    '        testContextInstance = value
    '    End Set
    'End Property

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
    '<TestInitialize()> _
    'Public Sub MyTestInitialize()
    '    'Creation d'un agent
    '    m_oAgent = AgentManager.createAgent(1, "AGENT_TEST_01", "Nouveau")
    '    m_oAgent.idStructure = 99
    '    m_oAgent.nom = "Agent de test"
    '    m_oAgent.prenom = "Agent de test"
    '    AgentManager.save(m_oAgent)
    '    Assert.IsNotNull(m_oAgent, "erreur en création d'un agent")

    'End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    '<TestCleanup()> _
    'Public Sub MyTestCleanup()
    '    Dim bReturn As Boolean
    '    If Not m_oAgent Is Nothing Then
    '        Dim arrBanc As List(Of Banc)
    '        arrBanc = BancManager.getBancByStructureId(m_oAgent.idStructure)
    '        For Each oBanc As Banc In arrBanc
    '            BancManager.delete(oBanc.id)
    '        Next

    '        Dim arrManoc As List(Of ManometreControle)
    '        arrManoc = ManometreControleManager.getManoControleByStructureId(m_oAgent.idStructure)
    '        For Each oManoC As ManometreControle In arrManoc
    '            ManometreControleManager.delete(oManoC.numeroNational)
    '        Next
    '        Dim arrManoE As List(Of ManometreEtalon)
    '        arrManoE = ManometreEtalonManager.getManometreEtalonByStructureId(m_oAgent.idStructure)
    '        For Each oManoE As ManometreEtalon In arrManoE
    '            ManometreEtalonManager.delete(oManoE.numeroNational)
    '        Next

    '        Dim col As Collection
    '        col = AutoTestManager.getcolControlesReguliers(m_oAgent)
    '        For Each oCtrl As AutoTest In col
    '            AutoTestManager.delete(oCtrl)
    '        Next


    '        bReturn = AgentManager.delete(m_oAgent.id)

    '        Assert.IsTrue(bReturn)
    '    End If
    'End Sub
#End Region



    <TestMethod()>
    Public Sub TestObject()
        Dim oTolerance As New ToleranceBuse()
        Assert.AreEqual(0.01875D, oTolerance.pctTolerance)
        oTolerance.pctTolerance = 10
        Assert.AreEqual(0.1D, oTolerance.pctTolerance)
        oTolerance.pctTolerance = 0.2D
        Assert.AreEqual(0.2D, oTolerance.pctTolerance)

        oTolerance.Couleur = "Jaune"
        Assert.AreEqual("Jaune", oTolerance.Couleur)
        oTolerance.debitMesure = 100
        Assert.AreEqual(100D, oTolerance.debitMesure)
        Assert.AreEqual(80D, oTolerance.ToleranceMini)
        Assert.AreEqual(120D, oTolerance.ToleranceMaxi)
    End Sub
    <TestMethod()>
    Public Sub TestSeralisation()

        If System.IO.File.Exists("./toleranceBuse.xml") Then
            System.IO.File.Delete("./toleranceBuse.xml")
        End If

        Dim oSer As New System.Xml.Serialization.XmlSerializer(GetType(ToleranceBuse))
        Dim oWr As New System.IO.StreamWriter("./toleranceBuse.xml")
        Dim oTol As New ToleranceBuse()
        oTol.Couleur = "jaune"
        oTol.pctTolerance = 10
        oTol.debitMesure = 10

        oSer.Serialize(oWr, oTol)

        oWr.Close()

        Assert.IsTrue(System.IO.File.Exists("./toleranceBuse.xml"))

    End Sub
    <TestMethod()>
    Public Sub TestDeSeralisation()

        If System.IO.File.Exists("./toleranceBuse.xml") Then
            System.IO.File.Delete("./toleranceBuse.xml")
        End If

        Dim oSer As New System.Xml.Serialization.XmlSerializer(GetType(ToleranceBuse))
        Dim oWr As New System.IO.StreamWriter("./toleranceBuse.xml")
        Dim oTol As New ToleranceBuse()
        oTol.Couleur = "jaune"
        oTol.pctTolerance = 10
        oTol.debitMesure = 10

        oSer.Serialize(oWr, oTol)

        oWr.Close()

        oTol = Nothing

        Dim oRd As New System.IO.StreamReader("./toleranceBuse.xml")
        oTol = CType(oSer.Deserialize(oRd), ToleranceBuse)
        Assert.AreEqual(oTol.Couleur, "jaune")
        Assert.AreEqual(oTol.pctTolerance, 0.1D)
        Assert.AreEqual(oTol.debitMesure, 10D)
        oRd.Close()


    End Sub
    <TestMethod()>
    Public Sub TestSeralisationList()

        If System.IO.File.Exists("./toleranceBuses.xml") Then
            System.IO.File.Delete("./toleranceBuses.xml")
        End If

        Dim olst As New lstToleranceBuse()
        Dim oTol As New ToleranceBuse()
        oTol.Couleur = "jaune"
        oTol.pctTolerance = 10
        oTol.debitMesure = 10

        olst.Add(oTol)
        oTol = New ToleranceBuse()
        oTol.Couleur = "Rouge"
        oTol.pctTolerance = 20
        oTol.debitMesure = 20

        olst.Add(oTol)

        olst.Serialize()

        oTol = Nothing
        olst.Clear()

        '        Dim oSer As New System.Xml.Serialization.XmlSerializer(GetType(lstToleranceBuse))
        '        Dim oRd As New System.IO.StreamReader("./toleranceBuses.xml")
        olst.Deserialize()
        Assert.AreEqual(2, olst.Count)
        oTol = olst(0)
        Assert.AreEqual(oTol.Couleur, "jaune")
        Assert.AreEqual(oTol.pctTolerance, 0.1D)
        Assert.AreEqual(oTol.debitMesure, 10D)
        oTol = olst(1)
        Assert.AreEqual(oTol.Couleur, "Rouge")
        Assert.AreEqual(oTol.pctTolerance, 0.2D)
        Assert.AreEqual(oTol.debitMesure, 20D)


    End Sub
End Class
