Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO

<TestClass()>
Public Class ControleRegulierTest
    Private testContextInstance As TestContext
    Private m_oAgent As Agent

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
        'Creation d'un agent
        m_oAgent = AgentManager.createAgent("AGENT_TEST_01", "Nouveau")
        m_oAgent.idStructure = 99
        m_oAgent.nom = "Agent de test"
        m_oAgent.prenom = "Agent de test"
        AgentManager.save(m_oAgent)
        Assert.IsNotNull(m_oAgent, "erreur en création d'un agent")

    End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    <TestCleanup()> _
    Public Sub MyTestCleanup()
        Dim bReturn As Boolean
        If Not m_oAgent Is Nothing Then
            Dim arrBanc As Banc()
            arrBanc = AgentManager.getBanc(m_oAgent.idStructure)
            For Each oBanc As Banc In arrBanc
                BancManager.deleteBanc(oBanc)
            Next

            Dim arrManoc As ManometreControle()
            arrManoc = AgentManager.getManoControle(m_oAgent.idStructure)
            For Each oManoC As ManometreControle In arrManoc
                ManometreControleManager.deleteManometreControle(oManoC)
            Next
            Dim arrManoE As ManometreEtalon()
            arrManoE = AgentManager.getManoEtalon(m_oAgent.idStructure)
            For Each oManoE As ManometreEtalon In arrManoE
                ManometreEtalonManager.deleteManometreEtalon(oManoE)
            Next

            Dim col As Collection
            col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure)
            For Each oCtrl As ControleRegulier In col
                ControleRegulierManager.delete(oCtrl)
            Next


            bReturn = AgentManager.delete(m_oAgent.id)

            Assert.IsTrue(bReturn)
        End If
    End Sub
#End Region



    <TestMethod()>
    Public Sub TestObject()

        Dim obj As ControleRegulier

        obj = New ControleRegulier
        Assert.IsTrue(obj.Id = -1)
        Assert.IsTrue(obj.Etat = -1)
        Assert.IsTrue(obj.isNonEffectue)
        Assert.IsTrue(Not obj.isOK)
        Assert.IsTrue(Not obj.isNOK)
        Dim str As String
        str = obj.dateModificationAgent
        Assert.AreNotEqual(obj.dateModificationAgent, CDate("01/01/1970"))
        Assert.AreEqual(obj.dateModificationCrodip, CDate("01/01/1970"))

        obj.setId(15)
        Assert.IsTrue(obj.Id = 15)
        obj.DateControle = CDate("06/02/1964")
        Assert.AreEqual(obj.DateControle, CDate("06/02/1964"))
        obj.Type = "MANO"
        Assert.AreEqual(obj.Type, "MANO")
        obj.IdMateriel = "TEST"
        Assert.AreEqual(obj.IdMateriel, "TEST")
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
        Dim obj As ControleRegulier
        obj = New ControleRegulier()

        obj.DateControle = CDate("06/02/1964")
        obj.Type = "Mano"
        obj.IdMateriel = "Mano001"
        obj.IdStructure = 99
        obj.isNOK = True

        Assert.IsTrue(ControleRegulierManager.save(obj), "SAVE")
        Assert.IsTrue(obj.Id <> -1, "ID renseigné après le save")

        Dim obj2 As ControleRegulier
        obj2 = ControleRegulierManager.getById(obj.Id)
        Assert.IsNotNull(obj2)

        Assert.IsTrue(ControleRegulierManager.delete(obj2.Id))
        obj2 = ControleRegulierManager.getById(obj.Id)
        Assert.IsNull(obj2)

    End Sub

    ''' <summary>
    ''' test de la création de controle Regulier avec des matériels
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestCreateCtrlMateriel()
        Dim objBanc As Banc
        Dim objB1 As ControleRegulier
        Dim objMC1 As ControleRegulier
        Dim objME1 As ControleRegulier

        objBanc = New Banc()
        objBanc.id = "MonBanc"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = True
        objBanc.AgentSuppression = m_oAgent.nom
        objBanc.RaisonSuppression = "MaRaison"
        objBanc.dateSuppression = CDate("06/02/1964")
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
        objManometreControle.dateSuppression = CDate("06/02/1964")
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
        objManometreEtalon.dateSuppression = CDate("06/02/1964")
        objManometreEtalon.nbControles = 5
        objManometreEtalon.nbControlesTotal = 15
        ManometreEtalonManager.save(objManometreEtalon)

        objB1 = New ControleRegulier(objBanc)
        Assert.AreEqual(objB1.IdMateriel, objBanc.id)
        Assert.AreEqual(objB1.Type, "BANC")

        objMC1 = New ControleRegulier(objManometreControle)
        Assert.AreEqual(objMC1.IdMateriel, objManometreControle.idCrodip)
        Assert.AreEqual(objMC1.Type, "MANOC")

        objME1 = New ControleRegulier(objManometreEtalon)
        Assert.AreEqual(objME1.IdMateriel, objManometreEtalon.idCrodip)
        Assert.AreEqual(objME1.Type, "MANOE")


        BancManager.deleteBanc(objBanc)
        ManometreControleManager.deleteManometreControle(objManometreControle)
        ManometreEtalonManager.delete(objManometreEtalon.numeroNational)

    End Sub

    ''' <summary>
    ''' test du chargement des controle Régulier depuis la base
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestgetColControle()
        Dim objBanc As Banc
        Dim objB1 As ControleRegulier
        Dim objMC1 As ControleRegulier
        Dim objME1 As ControleRegulier
        Dim col As Collection

        objBanc = New Banc()
        objBanc.id = "MonBanc"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = True
        objBanc.AgentSuppression = m_oAgent.nom
        objBanc.RaisonSuppression = "MaRaison"
        objBanc.dateSuppression = CDate("06/02/1964")
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
        objManometreControle.dateSuppression = CDate("06/02/1964")
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
        objManometreEtalon.dateSuppression = CDate("06/02/1964")
        objManometreEtalon.nbControles = 5
        objManometreEtalon.nbControlesTotal = 15
        ManometreEtalonManager.save(objManometreEtalon)

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure)
        For Each oCtrl As ControleRegulier In col
            ControleRegulierManager.delete(oCtrl)
        Next
        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure)
        Assert.AreEqual(0, col.Count)

        'Création des controles Reguliers
        objB1 = New ControleRegulier(objBanc)
        ControleRegulierManager.save(objB1)
        objB1 = New ControleRegulier(objBanc)
        ControleRegulierManager.save(objB1)
        objB1 = New ControleRegulier(objBanc)
        ControleRegulierManager.save(objB1)

        'Charegement de tous les controles
        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure)
        Assert.AreEqual(col.Count, 3)

        ' Test de chaque controle
        For Each oCtrl As ControleRegulier In col
            Assert.AreEqual(oCtrl.Type, "BANC")
            Assert.AreEqual(oCtrl.IdMateriel, objBanc.id)
        Next

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, "RIEN")
        Assert.AreEqual(col.Count, 0)

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, "BANC")
        Assert.AreEqual(col.Count, 3)

        'Création des controle Reguliers
        objMC1 = New ControleRegulier(objManometreControle)
        ControleRegulierManager.save(objMC1)
        objMC1 = New ControleRegulier(objManometreControle)
        ControleRegulierManager.save(objMC1)
        objMC1 = New ControleRegulier(objManometreControle)
        ControleRegulierManager.save(objMC1)
        objMC1 = New ControleRegulier(objManometreControle)
        ControleRegulierManager.save(objMC1)

        'Chargement de tous les controle
        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure)
        Assert.AreEqual(col.Count, 4 + 3)

        'Chargement des controle de type Mano de controle
        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, "MANOC")
        Assert.AreEqual(col.Count, 4)

        'Controle de chaque Mano
        For Each oCtrl As ControleRegulier In col
            Assert.AreEqual(oCtrl.IdMateriel, objManometreControle.idCrodip)
            Assert.AreEqual(oCtrl.Type, "MANOC")
            Assert.AreEqual(objMC1.IdMateriel, objManometreControle.idCrodip)
            Assert.AreEqual(objMC1.IdStructure, m_oAgent.idStructure)
        Next

        objME1 = New ControleRegulier(objManometreEtalon)
        ControleRegulierManager.save(objME1)
        objME1 = New ControleRegulier(objManometreControle)
        ControleRegulierManager.save(objME1)
        objME1 = New ControleRegulier(objManometreControle)
        ControleRegulierManager.save(objME1)
        objME1 = New ControleRegulier(objManometreControle)
        ControleRegulierManager.save(objME1)
        objME1 = New ControleRegulier(objManometreControle)
        ControleRegulierManager.save(objME1)

        'Suppression de tous les controleRegulier
        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure)
        For Each oCtrl As ControleRegulier In col
            ControleRegulierManager.delete(oCtrl)
        Next

        'Suppression des matériels
        BancManager.deleteBanc(objBanc)
        ManometreControleManager.deleteManometreControle(objManometreControle)
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
        BancManager.save(objBanc)

        objBanc = New Banc()
        objBanc.id = "MonBanc2"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = False
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15
        BancManager.save(objBanc)

        objBanc = New Banc()
        objBanc.id = "MonBanc3"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = True
        objBanc.AgentSuppression = m_oAgent.nom
        objBanc.RaisonSuppression = "MaRaison"
        objBanc.dateSuppression = CDate("06/02/1964")
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15
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
        objManometreControle.dateSuppression = CDate("06/02/1964")
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15
        ManometreControleManager.save(objManometreControle)

        Dim oColCtrl As Collection
        Dim octrl As ControleRegulier

        'Creation des controles Regulier des bancs
        oColCtrl = ControleRegulierManager.CreateControlesReguliers(m_oAgent.idStructure, "BANC")
        Assert.AreEqual(oColCtrl.Count, 2)
        octrl = oColCtrl(1)
        Assert.AreEqual("MonBanc1", octrl.IdMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.IdStructure)
        octrl = oColCtrl(2)
        Assert.AreEqual("MonBanc2", octrl.IdMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.IdStructure)

        'Creation des controles Regulier des Manos
        oColCtrl = ControleRegulierManager.CreateControlesReguliers(m_oAgent.idStructure, "MANOC")
        Assert.AreEqual(oColCtrl.Count, 3)
        octrl = oColCtrl(1)
        Assert.AreEqual("MonManometreControle1", octrl.IdMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.IdStructure)
        octrl = oColCtrl(2)
        Assert.AreEqual("MonManometreControle2", octrl.IdMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.IdStructure)
        octrl = oColCtrl(3)
        Assert.AreEqual("MonManometreControle3", octrl.IdMateriel)
        Assert.AreEqual(m_oAgent.idStructure, octrl.IdStructure)

        'Creation des controles Regulier de tous les matériels
        oColCtrl = ControleRegulierManager.CreateControlesReguliers(m_oAgent.idStructure, "TOUS")
        Assert.AreEqual(oColCtrl.Count, 2 + 3)
        oColCtrl = ControleRegulierManager.CreateControlesReguliers(m_oAgent.idStructure)
        Assert.AreEqual(oColCtrl.Count, 2 + 3)
 


    End Sub
    ''' <summary>
    ''' Test chargement par date
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestChargementParDate()
        Dim obj As ControleRegulier
        Dim nId As Integer

        obj = New ControleRegulier()
        obj.DateControle = CDate("25/02/1964")
        obj.Type = "MANOC"
        obj.IdMateriel = "Mano001"
        obj.IdStructure = m_oAgent.idStructure
        obj.isNOK = True

        Assert.IsTrue(ControleRegulierManager.save(obj))

        nId = obj.Id

        Dim col As Collection
        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure)
        Assert.AreEqual(1, col.Count)

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, "MANOC")
        Assert.AreEqual(1, col.Count)

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, "TOUS", CDate("1/2/1964"), CDate("28/02/1964"))
        Assert.AreEqual(1, col.Count)

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, "TOUS", CDate("1/2/1964"))
        Assert.AreEqual(1, col.Count)

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, , , CDate("28/02/1964"))
        Assert.AreEqual(1, col.Count)

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, , CDate("1/3/1964"), CDate("28/03/1964"))
        Assert.AreEqual(0, col.Count)

        col = ControleRegulierManager.getcolControlesReguliers(m_oAgent.idStructure, , CDate("1/3/1964"))
        Assert.AreEqual(0, col.Count)
    End Sub
    ''' <summary>
    ''' Test de L'export CSV
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub TestExportCSV()
        Dim obj As ControleRegulier
        Dim nId As Integer

        obj = New ControleRegulier()
        obj.DateControle = CDate("25/02/1964")
        obj.Type = "MANOC"
        obj.IdMateriel = "Mano001"
        obj.IdStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(ControleRegulierManager.save(obj))

        obj = New ControleRegulier()
        obj.DateControle = CDate("25/03/1964")
        obj.Type = "MANOC"
        obj.IdMateriel = "Mano001"
        obj.IdStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(ControleRegulierManager.save(obj))

        obj = New ControleRegulier()
        obj.DateControle = CDate("25/04/1964")
        obj.Type = "MANOC"
        obj.IdMateriel = "Mano001"
        obj.IdStructure = m_oAgent.idStructure
        obj.isNOK = True
        Assert.IsTrue(ControleRegulierManager.save(obj))

        Dim bReturn As Boolean
        bReturn = ControleRegulierManager.ExportAsCSV("01/01/1964", "31/12/1964", m_oAgent.idStructure, "C:\TEMP\text3L.txt")
        Assert.IsTrue(bReturn)
        bReturn = ControleRegulierManager.ExportAsCSV("01/01/1964", "31/12/1964", m_oAgent.idStructure, "C:\TEMP\textVide.txt", "BANC")
        Assert.IsTrue(bReturn)
        bReturn = ControleRegulierManager.ExportAsCSV("01/02/1964", "31/03/1964", m_oAgent.idStructure, "C:\TEMP\text2L.txt")
        Assert.IsTrue(bReturn)
        bReturn = ControleRegulierManager.ExportAsCSV("01/03/1964", "31/03/1964", m_oAgent.idStructure, "C:\TEMP\text1L.txt")
        Assert.IsTrue(bReturn)
        bReturn = ControleRegulierManager.ExportAsCSV("01/01/2012", "31/12/2012", m_oAgent.idStructure, "C:\TEMP\text0L.txt")
        Assert.IsTrue(bReturn)

    End Sub
End Class
