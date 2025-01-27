Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CRODIPWS
Imports Crodip_agent

'''<summary>
'''Classe de test pour FVManometreControle,
''' </summary>
<TestClass()>
Public Class FVManometreControleManagerTest

    Inherits CRODIPTest




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
    <TestInitialize()>
    Public Overloads Sub MyTestInitialize()
        MyBase.MyTestInitialize()
    End Sub

    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    <TestCleanup()>
    Public Overloads Sub MyTestCleanup()
        MyBase.MyTestCleanup()
    End Sub
    '
#End Region


    '''<summary>
    '''Test pour save
    '''</summary>
    <TestMethod()>
    Public Sub saveTest()
        Dim objFVManometreControle As FVManometreControle = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objFVManometreControle2 As FVManometreControle
        objFVManometreControle = New FVManometreControle(m_oAgent)
        objFVManometreControle.idManometre = "9-99-99"
        objFVManometreControle.idAgentControleur = m_oAgent.id

        Assert.IsTrue(FVManometreControleManager.save(m_oAgent, objFVManometreControle))
        Dim FVId = objFVManometreControle.id

        objFVManometreControle2 = FVManometreControleManager.getFVManometreControleById(FVId)
        Assert.AreEqual(FVId, objFVManometreControle2.id)

        objFVManometreControle2.caracteristiques = "TEST"
        Assert.IsTrue(FVManometreControleManager.save(m_oAgent, objFVManometreControle2))
        objFVManometreControle = FVManometreControleManager.getFVManometreControleById(FVId)
        Assert.AreEqual("TEST", objFVManometreControle2.caracteristiques)

        objFVManometreControle = FVManometreControleManager.getFVManometreControleById(FVId)
        FVManometreControleManager.delete(objFVManometreControle.id)
        objFVManometreControle2 = FVManometreControleManager.getFVManometreControleById(FVId)
        Assert.AreNotEqual(FVId, objFVManometreControle2.id)

    End Sub
    '''<summary>
    '''Test des fiches de vies Bancs
    '''</summary>
    <TestMethod()>
    Public Sub CreationDesFichesDeViesBancTest()
        Dim oMano As ManometreControle
        Dim oFVManometreControle As FVManometreControle
        Dim olstFV As New List(Of FVManometreControle)
        'Création du mano de controle
        oMano = New ManometreControle()
        oMano.uidstructure = m_oAgent.idStructure
        oMano.numeroNational = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oMano.idCrodip = oMano.numeroNational
        oMano.jamaisServi = True
        oMano.isUtilise = False
        ManometreControleManager.save(oMano)
        'Récupération du uid
        ManometreControleManager.WSSend(oMano, oMano)
        ManometreControleManager.save(oMano)

        olstFV = FVManometreControleManager.getLstFVManometreControleByuid(oMano.uid)
        Assert.AreEqual(0, olstFV.Count) 'Pas de fiche de vie

        oMano.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        ManometreControleManager.save(oMano)
        oMano = ManometreControleManager.getManometreControleByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.jamaisServi)
        Assert.AreEqual(CDate("01/06/2014"), oMano.DateActivation)

        olstFV = FVManometreControleManager.getLstFVManometreControleByuid(oMano.uid)
        Assert.AreEqual(1, olstFV.Count) 'une fiche de vie Activation
        oFVManometreControle = olstFV(0)
        Assert.AreEqual(oFVManometreControle.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreControle.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("MISEENSERVICE", oFVManometreControle.type)




        Threading.Thread.Sleep(2000)
        'Désactivation du Mano
        Assert.IsTrue(oMano.etat)
        oMano.Desactiver(m_oAgent)
        oMano = ManometreControleManager.getManometreControleByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.etat)

        olstFV = FVManometreControleManager.getLstFVManometreControleByuid(oMano.uid)
        'Test de création d'une fiche de vie
        Assert.AreEqual(2, olstFV.Count) 'une fiche de vie "DESACTIVATION"
        oFVManometreControle = olstFV(1)
        Assert.AreEqual(oFVManometreControle.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreControle.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("DESACTIVATION", oFVManometreControle.type)



        'Suppression du Manometre
        Threading.Thread.Sleep(1000)
        Assert.IsFalse(oMano.isSupprime)
        oMano.DeleteMateriel(m_oAgent, "TEST")
        Assert.IsTrue(oMano.isSupprime)


        olstFV = FVManometreControleManager.getLstFVManometreControleByuid(oMano.uid)
        'création d'une Troisième fiche de vie SUPRESSION
        Assert.AreEqual(3, olstFV.Count) 'une fiche de vie SUPPRESSION
        oFVManometreControle = olstFV(2)
        Assert.AreEqual(oFVManometreControle.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreControle.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("SUPPRESSION", oFVManometreControle.type)

    End Sub

    '''<summary>
    '''Test des WS Fiches de vies de Manos de controles
    '''</summary>
    <TestMethod()>
    Public Sub SynchroDesFichesDeViesBancTest()
        Dim oMano As ManometreControle
        Dim olstFV As New List(Of FVManometreControle)
        oMano = New ManometreControle()
        oMano.uidstructure = m_oAgent.idStructure
        oMano.numeroNational = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oMano.idCrodip = oMano.numeroNational
        oMano.jamaisServi = True
        oMano.isUtilise = False
        ManometreControleManager.save(oMano)
        'Récupération du uid
        ManometreControleManager.WSSend(oMano, oMano)
        ManometreControleManager.save(oMano)

        olstFV = FVManometreControleManager.getLstFVManometreControleByuid(oMano.uid)
        oMano.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        ManometreControleManager.save(oMano)
        oMano = ManometreControleManager.getManometreControleByNumeroNational(oMano.idCrodip)


        'Désactivation du Mano
        Assert.IsTrue(oMano.etat)
        oMano.Desactiver(m_oAgent)
        oMano = ManometreControleManager.getManometreControleByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.etat)

        'Controle du Manoètre
        System.Threading.Thread.Sleep(1000)
        Dim oCtrl As ControleMano = New ControleMano(oMano, m_oAgent)
        Dim oManoE As ManometreEtalon
        oManoE = New ManometreEtalon()
        oManoE.uidstructure = m_oAgent.idStructure
        oManoE.idCrodip = ManometreEtalonManager.FTO_getNewId(m_oAgent)
        oManoE.numeroNational = oMano.idCrodip
        oManoE.jamaisServi = True
        oManoE.isUtilise = False
        ManometreEtalonManager.save(oManoE)

        oCtrl.DateVerif = Date.Now.ToShortDateString()
        oCtrl.manoEtalon = oManoE.idCrodip
        oCtrl.idMano = oMano.idCrodip

        Dim oEtat As New EtatFVMano(oCtrl)
        Dim sFileName As String = oEtat.buildPDF(oMano, m_oAgent)
        oMano.creerfFicheVieControle(m_oAgent, oCtrl, sFileName)

        Dim oLst As New List(Of FVManometreControle)
        oLst = FVManometreControleManager.getLstFVManometreControleByuid(oMano.uid)
        'La FV de controle est la dernière créee
        Dim oFV As FVManometreControle = oLst(oLst.Count - 1)
        Dim strFVFileName As String = oFV.FVFileName

        Assert.AreEqual(3, FVManometreControleManager.getUpdates(m_oAgent).Length)
        Dim oSynchro As New Synchronisation(m_oAgent)
        oSynchro.runascSynchroFVManoControle()

        'Por Véfifier que le Fichier est bien sur le FTP
        'On le télécharge et on vérifie qu'il existe
        'System.IO.Directory.CreateDirectory("tmp/FV/MC")
        'Dim oFTP As New CSFTP()
        'oFTP.DownLoad("FV/MC/" & strFVFileName, "tmp/")
        'Assert.IsTrue(System.IO.File.Exists("tmp/FV/MC/" & strFVFileName))


        Assert.AreEqual(0, FVManometreControleManager.getUpdates(m_oAgent).Length)

        'Suppression du Manometre
        Assert.IsFalse(oMano.isSupprime)
        oMano.DeleteMateriel(m_oAgent, "TEST")
        Assert.IsTrue(oMano.isSupprime)

    End Sub
End Class
