Imports System.Text
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting


<TestClass()>
Public Class AutoTestTest
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

        Dim obj As AutoTest

        obj = New AutoTest(m_oAgent)
        Assert.IsTrue(obj.id = -1)
        Assert.IsTrue(obj.Etat = -1)
        Assert.IsTrue(obj.isNonEffectue)
        Assert.IsTrue(Not obj.isOK)
        Assert.IsTrue(Not obj.isNOK)
        Assert.AreEqual(m_oAgent.idStructure, obj.idStructure)
        Assert.AreEqual(m_oAgent.id.ToString(), obj.numAgent)
        Dim str As String

        obj.setId(15)
        Assert.IsTrue(obj.id = 15)
        obj.dateControle = CDate("06/02/1964")
        Assert.AreEqual(obj.dateControle, CDate("06/02/1964"))
        obj.Type = "MANO"
        Assert.AreEqual(obj.Type, "MANO")
        obj.idMateriel = "TEST"
        Assert.AreEqual(obj.idMateriel, "TEST")
        obj.Etat = 0
        Assert.AreEqual(obj.Etat, 0)
        Assert.IsTrue(obj.isOK = True)
        Assert.IsTrue(obj.isNOK = False)
        Assert.IsTrue(obj.isNonEffectue = False)
        obj.Etat = 1
        Assert.IsTrue(obj.Etat = 1)
        Assert.IsTrue(obj.isOK = False)
        Assert.IsTrue(obj.isNOK = True)
        Assert.IsTrue(obj.isNonEffectue = False)
        obj.isNonEffectue = True
        Assert.IsTrue(obj.Etat = -1)
        obj.isOK = True
        Assert.IsTrue(obj.Etat = 0)
        obj.isNOK = True
        Assert.IsTrue(obj.Etat = 1)

    End Sub

    <TestMethod()>
    Public Sub TestDB()
        Dim obj As AutoTest
        obj = New AutoTest(m_oAgent)


        obj.dateControle = CDate("06/02/1964")
        obj.Type = "Mano"
        obj.idMateriel = "Mano001"
        obj.isNOK = True

        Assert.IsTrue(AutoTestManager.save(obj), "SAVE")
        Assert.IsTrue(obj.id <> -1, "ID renseigné après le save")

        Dim obj2 As AutoTest
        obj2 = AutoTestManager.getById(m_oAgent, obj.id)
        Assert.IsNotNull(obj2)
        Assert.AreEqual(obj2.numAgent, obj.numAgent)
        Assert.AreEqual(obj2.Type, obj.Type)
        Assert.AreEqual(obj2.idMateriel, obj.idMateriel)
        Assert.AreEqual(obj2.dateControle, obj.dateControle)

        Assert.IsTrue(AutoTestManager.delete(obj2.id))
        obj2 = AutoTestManager.getById(m_oAgent, obj.id)
        Assert.IsNull(obj2)

    End Sub

    ''' <summary>
    ''' test de la création de controle Regulier avec des matériels
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestCreateCtrlMateriel()
        Dim objBanc As Banc
        Dim objB1 As AutoTest
        Dim objMC1 As AutoTest
        Dim objME1 As AutoTest

        objBanc = New Banc()
        objBanc.id = "MonBanc"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = True
        objBanc.AgentSuppression = m_oAgent.nom
        objBanc.RaisonSuppression = "MaRaison"
        objBanc.DateSuppression = "06/02/1964"
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15
        BancManager.save(objBanc)

        Dim objManometreControle As ManometreControle = Nothing
        Dim expected As Object = Nothing
        objManometreControle = New ManometreControle()
        objManometreControle.idCrodip = "MonManometreControle"
        objManometreControle.numeroNational = "MonNumeroNational"
        objManometreControle.classe = "MaClasse"
        objManometreControle.type = "MonType"
        objManometreControle.fondEchelle = "MonFonEchelle"
        objManometreControle.idStructure = m_oAgent.idStructure
        objManometreControle.isSupprime = True
        objManometreControle.AgentSuppression = m_oAgent.nom
        objManometreControle.RaisonSuppression = "MaRaison"
        objManometreControle.DateSuppression = "06/02/1964"
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15
        ManometreControleManager.save(objManometreControle)

        Dim objManometreEtalon As ManometreEtalon = Nothing ' TODO: initialisez à une valeur appropriée
        objManometreEtalon = New ManometreEtalon()
        objManometreEtalon.idCrodip = "MonManometreEtalon"
        objManometreEtalon.numeroNational = "MonNumeroNational"
        objManometreEtalon.classe = "MaClasse"
        objManometreEtalon.type = "MonType"
        objManometreEtalon.fondEchelle = "MonFonEchelle"
        objManometreEtalon.incertitudeEtalon = "0.562"
        objManometreEtalon.idStructure = m_oAgent.idStructure
        objManometreEtalon.isSupprime = True
        objManometreEtalon.AgentSuppression = m_oAgent.nom
        objManometreEtalon.RaisonSuppression = "MaRaison"
        objManometreEtalon.DateSuppression = "06/02/1964"
        objManometreEtalon.nbControles = 5
        objManometreEtalon.nbControlesTotal = 15
        ManometreEtalonManager.save(objManometreEtalon)

        objB1 = New AutoTest(m_oAgent, objBanc)
        Assert.AreEqual(objB1.idMateriel, objBanc.id)
        Assert.AreEqual(objB1.Type, "BANC")

        objMC1 = New AutoTest(m_oAgent, objManometreControle)
        Assert.AreEqual(objMC1.idMateriel, objManometreControle.idCrodip)
        Assert.AreEqual(objMC1.Type, "MANOC")

        objME1 = New AutoTest(m_oAgent, objManometreEtalon)
        Assert.AreEqual(objME1.idMateriel, objManometreEtalon.idCrodip)
        Assert.AreEqual(objME1.Type, "MANOE")


        BancManager.delete(objBanc.id)
        ManometreControleManager.delete(objManometreControle.numeroNational)
        ManometreEtalonManager.delete(objManometreEtalon.numeroNational)

    End Sub

    ''' <summary>
    ''' test du chargement des controle Régulier depuis la base
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestgetColControle()
        Dim objBanc As Banc
        Dim objB1 As AutoTest
        Dim objMC1 As AutoTest
        Dim objME1 As AutoTest
        Dim col As List(Of AutoTest)

        objBanc = New Banc()
        objBanc.id = "MonBanc"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = True
        objBanc.AgentSuppression = m_oAgent.nom
        objBanc.RaisonSuppression = "MaRaison"
        objBanc.DateSuppression = "06/02/1964"
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15
        BancManager.save(objBanc)

        Dim objManometreControle As ManometreControle = Nothing
        Dim expected As Object = Nothing
        objManometreControle = New ManometreControle()
        objManometreControle.idCrodip = "MonManometreControle"
        objManometreControle.numeroNational = "MonNumeroNational"
        objManometreControle.classe = "MaClasse"
        objManometreControle.type = "MonType"
        objManometreControle.fondEchelle = "MonFonEchelle"
        objManometreControle.idStructure = m_oAgent.idStructure
        objManometreControle.isSupprime = True
        objManometreControle.AgentSuppression = m_oAgent.nom
        objManometreControle.RaisonSuppression = "MaRaison"
        objManometreControle.DateSuppression = "06/02/1964"
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15
        ManometreControleManager.save(objManometreControle)

        Dim objManometreEtalon As ManometreEtalon = Nothing ' TODO: initialisez à une valeur appropriée
        objManometreEtalon = New ManometreEtalon()
        objManometreEtalon.idCrodip = "MonManometreEtalon"
        objManometreEtalon.numeroNational = "MonNumeroNational"
        objManometreEtalon.classe = "MaClasse"
        objManometreEtalon.type = "MonType"
        objManometreEtalon.fondEchelle = "MonFonEchelle"
        objManometreEtalon.incertitudeEtalon = "0.562"
        objManometreEtalon.idStructure = m_oAgent.idStructure
        objManometreEtalon.isSupprime = True
        objManometreEtalon.AgentSuppression = m_oAgent.nom
        objManometreEtalon.RaisonSuppression = "MaRaison"
        objManometreEtalon.DateSuppression = "06/02/1964"
        objManometreEtalon.nbControles = 5
        objManometreEtalon.nbControlesTotal = 15
        ManometreEtalonManager.save(objManometreEtalon)

        col = AutoTestManager.getcolControlesReguliers(m_oAgent)
        For Each oCtrl As AutoTest In col
            AutoTestManager.delete(oCtrl)
        Next
        col = AutoTestManager.getcolControlesReguliers(m_oAgent)
        Assert.AreEqual(0, col.Count)

        'Création des controles Reguliers
        objB1 = New AutoTest(m_oAgent, objBanc)
        AutoTestManager.save(objB1)
        objB1 = New AutoTest(m_oAgent, objBanc)
        AutoTestManager.save(objB1)
        objB1 = New AutoTest(m_oAgent, objBanc)
        AutoTestManager.save(objB1)

        'Charegement de tous les controles
        col = AutoTestManager.getcolControlesReguliers(m_oAgent)
        Assert.AreEqual(col.Count, 3)

        ' Test de chaque controle
        For Each oCtrl As AutoTest In col
            Assert.AreEqual(oCtrl.Type, "BANC")
            Assert.AreEqual(oCtrl.idMateriel, objBanc.id)
        Next

        col = AutoTestManager.getcolControlesReguliers(m_oAgent, "RIEN")
        Assert.AreEqual(col.Count, 0)

        col = AutoTestManager.getcolControlesReguliers(m_oAgent, "BANC")
        Assert.AreEqual(col.Count, 3)

        'Création des controle Reguliers
        objMC1 = New AutoTest(m_oAgent, objManometreControle)
        AutoTestManager.save(objMC1)
        objMC1 = New AutoTest(m_oAgent, objManometreControle)
        AutoTestManager.save(objMC1)
        objMC1 = New AutoTest(m_oAgent, objManometreControle)
        AutoTestManager.save(objMC1)
        objMC1 = New AutoTest(m_oAgent, objManometreControle)
        AutoTestManager.save(objMC1)

        'Chargement de tous les controle
        col = AutoTestManager.getcolControlesReguliers(m_oAgent)
        Assert.AreEqual(4 + 3, col.Count)

        'Chargement des controle de type Mano de controle
        col = AutoTestManager.getcolControlesReguliers(m_oAgent, "MANOC")
        Assert.AreEqual(col.Count, 4)

        'Controle de chaque Mano
        For Each oCtrl As AutoTest In col
            Assert.AreEqual(oCtrl.idMateriel, objManometreControle.idCrodip)
            Assert.AreEqual(oCtrl.Type, "MANOC")
            Assert.AreEqual(objMC1.idMateriel, objManometreControle.idCrodip)
            Assert.AreEqual(objMC1.idStructure, m_oAgent.idStructure)
        Next

        objME1 = New AutoTest(m_oAgent, objManometreEtalon)
        AutoTestManager.save(objME1)
        objME1 = New AutoTest(m_oAgent, objManometreControle)
        AutoTestManager.save(objME1)
        objME1 = New AutoTest(m_oAgent, objManometreControle)
        AutoTestManager.save(objME1)
        objME1 = New AutoTest(m_oAgent, objManometreControle)
        AutoTestManager.save(objME1)
        objME1 = New AutoTest(m_oAgent, objManometreControle)
        AutoTestManager.save(objME1)

        'Suppression de tous les AutoTest
        col = AutoTestManager.getcolControlesReguliers(m_oAgent)
        For Each oCtrl As AutoTest In col
            AutoTestManager.delete(oCtrl)
        Next

        'Suppression des matériels
        BancManager.delete(objBanc.id)
        ManometreControleManager.delete(objManometreControle.numeroNational)
        ManometreEtalonManager.delete(objManometreEtalon.numeroNational)

    End Sub
    ''' <summary>
    ''' test de la création des controles Reguliers
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestCreateControlesReguliers()
        Dim objBanc As Banc
        Dim objManometreControle As ManometreControle = Nothing

        'Création de 3 bancs (2 OK + 1 Supprimé)
        objBanc = New Banc()
        objBanc.id = "MonBanc1"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = False
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15
        objBanc.JamaisServi = False
        objBanc.etat = True
        BancManager.save(objBanc)

        objBanc = New Banc()
        objBanc.id = "MonBanc2"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = False
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15
        objBanc.JamaisServi = False
        objBanc.etat = True
        BancManager.save(objBanc)

        objBanc = New Banc()
        objBanc.id = "MonBanc3"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = True
        objBanc.AgentSuppression = m_oAgent.nom
        objBanc.RaisonSuppression = "MaRaison"
        objBanc.DateSuppression = "06/02/1964"
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15
        objBanc.jamaisServi = False
        objBanc.etat = True
        BancManager.save(objBanc)

        'Creation de 4 Manomètres de controle (3OK et 1 Supprimé)
        objManometreControle = New ManometreControle()
        objManometreControle.idCrodip = "MonManometreControle1"
        objManometreControle.numeroNational = "MANO1"
        objManometreControle.classe = "MaClasse"
        objManometreControle.type = "MonType"
        objManometreControle.fondEchelle = "MonFonEchelle"
        objManometreControle.idStructure = m_oAgent.idStructure
        objManometreControle.isSupprime = False
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15
        objManometreControle.etat = True
        ManometreControleManager.save(objManometreControle)

        objManometreControle = New ManometreControle()
        objManometreControle.idCrodip = "MonManometreControle2"
        objManometreControle.numeroNational = "MANO2"
        objManometreControle.classe = "MaClasse"
        objManometreControle.type = "MonType"
        objManometreControle.fondEchelle = "MonFonEchelle"
        objManometreControle.idStructure = m_oAgent.idStructure
        objManometreControle.isSupprime = False
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15
        objManometreControle.etat = True
        ManometreControleManager.save(objManometreControle)

        objManometreControle = New ManometreControle()
        objManometreControle.numeroNational = "MANO3"
        objManometreControle.idCrodip = "MonManometreControle3"
        objManometreControle.classe = "MaClasse"
        objManometreControle.type = "MonType"
        objManometreControle.fondEchelle = "MonFonEchelle"
        objManometreControle.idStructure = m_oAgent.idStructure
        objManometreControle.isSupprime = False
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15
        objManometreControle.etat = True
        ManometreControleManager.save(objManometreControle)

        objManometreControle = New ManometreControle()
        objManometreControle.numeroNational = "MANO4"
        objManometreControle.idCrodip = "MonManometreControle4"
        objManometreControle.classe = "MaClasse"
        objManometreControle.type = "MonType"
        objManometreControle.fondEchelle = "MonFonEchelle"
        objManometreControle.idStructure = m_oAgent.idStructure
        objManometreControle.isSupprime = True
        objManometreControle.AgentSuppression = m_oAgent.nom
        objManometreControle.RaisonSuppression = "MaRaison"
        objManometreControle.DateSuppression = "06/02/1964"
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15
        objManometreControle.etat = True
        ManometreControleManager.save(objManometreControle)

        Dim oColCtrl As List(Of AutoTest)
        Dim octrl As AutoTest

        'Creation des controles Regulier des bancs
        oColCtrl = AutoTestManager.CreateControlesReguliers(m_oAgent, Now(), "BANC")
        Assert.AreEqual(2, oColCtrl.Count)
        octrl = CType(oColCtrl(0), AutoTest)
        Assert.AreEqual("MonBanc1", octrl.idMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.idStructure)
        octrl = CType(oColCtrl(1), AutoTest)
        Assert.AreEqual("MonBanc2", octrl.idMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.idStructure)

        'Creation des controles Regulier des Manos
        oColCtrl = AutoTestManager.CreateControlesReguliers(m_oAgent, Now(), "MANOC")
        Assert.AreEqual(oColCtrl.Count, 3)
        octrl = CType(oColCtrl(0), AutoTest)
        Assert.AreEqual("MonManometreControle1", octrl.idMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.idStructure)
        octrl = CType(oColCtrl(1), AutoTest)
        Assert.AreEqual("MonManometreControle2", octrl.idMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.idStructure)
        octrl = CType(oColCtrl(2), AutoTest)
        Assert.AreEqual("MonManometreControle3", octrl.idMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.idStructure)

        'Creation des controles Regulier de tous les matériels
        oColCtrl = AutoTestManager.CreateControlesReguliers(m_oAgent, Now(), "TOUS")
        Assert.AreEqual(oColCtrl.Count, 2 + 3)
        oColCtrl = AutoTestManager.CreateControlesReguliers(m_oAgent, CDate("01/01/2012"))
        Assert.AreEqual(oColCtrl.Count, 2 + 3)



    End Sub
    ''' <summary>
    ''' Test chargement par date
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestChargementParDate()
        Dim obj As AutoTest
        Dim nId As Integer

        obj = New AutoTest(m_oAgent)
        obj.dateControle = CDate("25/02/1964")
        obj.Type = "MANOC"
        obj.idMateriel = "Mano001"
        obj.idStructure = m_oAgent.idStructure
        obj.isNOK = True

        Assert.IsTrue(AutoTestManager.save(obj))

        nId = obj.id

        Dim col As List(Of AutoTest)
        col = AutoTestManager.getcolControlesReguliers(m_oAgent)
        Assert.AreEqual(1, col.Count)

        col = AutoTestManager.getcolControlesReguliers(m_oAgent, "MANOC")
        Assert.AreEqual(1, col.Count)

        col = AutoTestManager.getcolControlesReguliers(m_oAgent, "TOUS", "1/2/1964", "28/02/1964")
        Assert.AreEqual(1, col.Count)

        col = AutoTestManager.getcolControlesReguliers(m_oAgent, "TOUS", "1/2/1964")
        Assert.AreEqual(1, col.Count)

        col = AutoTestManager.getcolControlesReguliers(m_oAgent, , , "28/02/1964")
        Assert.AreEqual(1, col.Count)

        col = AutoTestManager.getcolControlesReguliers(m_oAgent, , "1/3/1964", "28/03/1964")
        Assert.AreEqual(0, col.Count)

        col = AutoTestManager.getcolControlesReguliers(m_oAgent, , "1/3/1964")
        Assert.AreEqual(0, col.Count)
    End Sub
    ''' <summary>
    ''' Test de l'envoi par WS
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestSerialize()
        Dim serializer As New XmlSerializer(GetType(AutoTest))
        Dim writer As New StreamWriter("testSer.xml")
        Dim obj As AutoTest

        obj = New AutoTest(m_oAgent)
        obj.dateControle = CDate("25/02/1964")
        obj.Type = "MANOC"
        obj.idMateriel = "Mano001"
        obj.idStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(AutoTestManager.save(obj))

        serializer.Serialize(writer, obj)
        writer.Close()


    End Sub
    ''' <summary>
    ''' Test de l'envoi par WS
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestSendWS()
        Dim obj As AutoTest

        obj = New AutoTest(m_oAgent)
        obj.dateControle = CDate("25/02/1964")
        obj.Type = "MANOC"
        obj.idMateriel = "Mano001"
        obj.idStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(AutoTestManager.save(obj))

        obj = New AutoTest(m_oAgent)
        obj.dateControle = CDate("25/03/1964")
        obj.Type = "MANOC"
        obj.idMateriel = "Mano001"
        obj.idStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(AutoTestManager.save(obj))

        obj = New AutoTest(m_oAgent)
        obj.dateControle = CDate("25/04/1964")
        obj.Type = "MANOC"
        obj.idMateriel = "Mano001"
        obj.idStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(AutoTestManager.save(obj))

        'On vérifie que les autoTest sont bien dans la collection des a synchronisé
        Dim oCol As List(Of AutoTest)
        oCol = AutoTestManager.getcolControlesReguliers(m_oAgent, , , , True)
        Assert.AreEqual(3, oCol.Count)

        Assert.AreEqual(0, AutoTestManager.WSSendList(m_oAgent))
        '        Assert.IsTrue(AutoTestManager.sendWS2ControlesReguliers(m_oAgent))

        'On vérifie que les autoTest ne sont plus dans la collection des autotests as synchroniser
        oCol = AutoTestManager.getcolControlesReguliers(m_oAgent, , , , True)
        Assert.AreEqual(0, oCol.Count)


    End Sub
    ''' <summary>
    ''' Test de L'export CSV
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestExportCSV()
        Dim obj As AutoTest

        obj = New AutoTest(m_oAgent)
        obj.dateControle = CDate("25/02/1964")
        obj.Type = "MANOC"
        obj.idMateriel = "Mano001"
        obj.idStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(AutoTestManager.save(obj))

        obj = New AutoTest(m_oAgent)
        obj.dateControle = CDate("25/03/1964")
        obj.Type = "MANOC"
        obj.idMateriel = "Mano001"
        obj.idStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(AutoTestManager.save(obj))

        obj = New AutoTest(m_oAgent)
        obj.dateControle = CDate("25/04/1964")
        obj.Type = "MANOC"
        obj.idMateriel = "Mano001"
        obj.idStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(AutoTestManager.save(obj))

        Dim bReturn As Boolean
        bReturn = AutoTestManager.ExportAsCSV("01/01/1964", "31/12/1964", m_oAgent, "C:\TEMP\text3L.txt")
        Assert.IsTrue(bReturn)
        bReturn = AutoTestManager.ExportAsCSV("01/01/1964", "31/12/1964", m_oAgent, "C:\TEMP\textVide.txt", "BANC")
        Assert.IsTrue(bReturn)
        bReturn = AutoTestManager.ExportAsCSV("01/02/1964", "31/03/1964", m_oAgent, "C:\TEMP\text2L.txt")
        Assert.IsTrue(bReturn)
        bReturn = AutoTestManager.ExportAsCSV("01/03/1964", "31/03/1964", m_oAgent, "C:\TEMP\text1L.txt")
        Assert.IsTrue(bReturn)
        bReturn = AutoTestManager.ExportAsCSV("01/01/2012", "31/12/2012", m_oAgent, "C:\TEMP\text0L.txt")
        Assert.IsTrue(bReturn)

    End Sub
End Class
