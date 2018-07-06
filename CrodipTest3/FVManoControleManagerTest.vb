Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour FVManometreControle,
''' </summary>
<TestClass()> _
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
    <TestInitialize()> _
    Public Overloads Sub MyTestInitialize()
        MyBase.MyTestInitialize()
    End Sub

    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    <TestCleanup()> _
    Public Overloads Sub MyTestCleanup()
        MyBase.MyTestCleanup()
    End Sub
    '
#End Region


    '''<summary>
    '''Test pour save
    '''</summary>
    <TestMethod()> _
    Public Sub saveTest()
        Dim objFVManometreControle As FVManometreControle = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objFVManometreControle2 As FVManometreControle
        objFVManometreControle = New FVManometreControle(m_oAgent)
        objFVManometreControle.id = "9-99-99"
        objFVManometreControle.idManometre = "9-99-99"
        objFVManometreControle.idAgentControleur = m_oAgent.id

        Assert.IsTrue(FVManometreControleManager.save(objFVManometreControle))

        objFVManometreControle2 = FVManometreControleManager.getFVManometreControleById("9-99-99")
        Assert.AreEqual("9-99-99", objFVManometreControle2.id)

        objFVManometreControle2.caracteristiques = "TEST"
        Assert.IsTrue(FVManometreControleManager.save(objFVManometreControle2))
        objFVManometreControle = FVManometreControleManager.getFVManometreControleById("9-99-99")
        Assert.AreEqual("TEST", objFVManometreControle2.caracteristiques)

        objFVManometreControle = FVManometreControleManager.getFVManometreControleById("9-99-99")
        FVManometreControleManager.delete(objFVManometreControle.id)
        objFVManometreControle2 = FVManometreControleManager.getFVManometreControleById("9-99-99")
        Assert.AreNotEqual("9-99-99", objFVManometreControle2.id)

    End Sub
    '''<summary>
    '''Test des fiches de vies Bancs
    '''</summary>
    <TestMethod()> _
    Public Sub CreationDesFichesDeViesBancTest()
        Dim oMano As ManometreControle
        Dim oFVManometreControle As FVManometreControle
        Dim olstFV As New List(Of FVManometreControle)
        'Création du mano de controle
        oMano = New ManometreControle()
        oMano.idStructure = m_oAgent.idStructure
        oMano.numeroNational = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oMano.idCrodip = oMano.numeroNational
        oMano.JamaisServi = True
        oMano.isUtilise = False
        ManometreControleManager.save(oMano)

        olstFV = FVManometreControleManager.getLstFVManometreControle(oMano.idCrodip)
        Assert.AreEqual(0, olstFV.Count) 'Pas de fiche de vie

        oMano.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        ManometreControleManager.save(oMano)
        oMano = ManometreControleManager.getManometreControleByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.JamaisServi)
        Assert.AreEqual(CDate("01/06/2014"), oMano.DateActivation)

        olstFV = FVManometreControleManager.getLstFVManometreControle(oMano.idCrodip)
        Assert.AreEqual(1, olstFV.Count) 'une fiche de vie Activation
        oFVManometreControle = olstFV(0)
        Assert.AreEqual(oFVManometreControle.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreControle.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("MISEENSERVICE", oFVManometreControle.type)





        'Désactivation du Mano
        Assert.IsTrue(oMano.etat)
        oMano.DesactiverMano(m_oAgent)
        oMano = ManometreControleManager.getManometreControleByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.etat)

        olstFV = FVManometreControleManager.getLstFVManometreControle(oMano.idCrodip)
        'Test de création d'une fiche de vie
        Assert.AreEqual(2, olstFV.Count) 'une fiche de vie "DESACTIVATION"
        oFVManometreControle = olstFV(1)
        Assert.AreEqual(oFVManometreControle.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreControle.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("DESACTIVATION", oFVManometreControle.type)



        'Suppression du Manometre
        Assert.IsFalse(oMano.isSupprime)
        oMano.DeleteMateriel(m_oAgent, "TEST")
        Assert.IsTrue(oMano.isSupprime)


        olstFV = FVManometreControleManager.getLstFVManometreControle(oMano.idCrodip)
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
    <TestMethod()> _
    Public Sub SynchroDesFichesDeViesBancTest()
        Dim oMano As ManometreControle
        Dim olstFV As New List(Of FVManometreControle)
        oMano = New ManometreControle()
        oMano.idStructure = m_oAgent.idStructure
        oMano.numeroNational = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oMano.idCrodip = oMano.numeroNational
        oMano.JamaisServi = True
        oMano.isUtilise = False
        ManometreControleManager.save(oMano)

        olstFV = FVManometreControleManager.getLstFVManometreControle(oMano.idCrodip)
        oMano.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        ManometreControleManager.save(oMano)
        oMano = ManometreControleManager.getManometreControleByNumeroNational(oMano.idCrodip)


        'Désactivation du Mano
        Assert.IsTrue(oMano.etat)
        oMano.DesactiverMano(m_oAgent)
        oMano = ManometreControleManager.getManometreControleByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.etat)

        'Controle du Manoètre
        pause(1000)
        Dim oCtrl As ControleMano = New ControleMano(m_oAgent)
        Dim oManoE As ManometreEtalon
        oManoE = New ManometreEtalon()
        oManoE.idStructure = m_oAgent.idStructure
        oManoE.numeroNational = ManometreEtalonManager.getNewNumeroNationalForTestOnly(m_oAgent)
        oManoE.idCrodip = oMano.numeroNational
        oManoE.JamaisServi = True
        oManoE.isUtilise = False
        ManometreEtalonManager.save(oManoE)

        oCtrl.DateVerif = Date.Now
        oCtrl.manoEtalon = oManoE.idCrodip
        oCtrl.idMano = oMano.idCrodip

        oMano.creerfFicheVieControle(m_oAgent, oCtrl)

        Dim oLst As New List(Of FVManometreControle)
        oLst = FVManometreControleManager.getLstFVManometreControle(oMano.idCrodip)
        'La FV de controle est la dernière créee
        Dim oFV As FVManometreControle = oLst(oLst.Count - 1)
        Dim strFVFileName As String = oFV.FVFileName

        Assert.AreEqual(3, FVManometreControleManager.getUpdates(m_oAgent).Length)
        Dim oSynchro As New Synchronisation(m_oAgent)
        oSynchro.runascSynchroFVManoControle()

        'Por Véfifier que le Fichier est bien sur le FTP
        'On le télécharge et on vérifie qu'il existe
        System.IO.Directory.CreateDirectory("tmp/FV/MC")
        Dim oFTP As New CSFTP()
        oFTP.DownLoad("FV/MC/" & strFVFileName, "tmp/")
        Assert.IsTrue(System.IO.File.Exists("tmp/FV/MC/" & strFVFileName))


        Assert.AreEqual(0, FVManometreControleManager.getUpdates(m_oAgent).Length)

        'Suppression du Manometre
        Assert.IsFalse(oMano.isSupprime)
        oMano.DeleteMateriel(m_oAgent, "TEST")
        Assert.IsTrue(oMano.isSupprime)

    End Sub
End Class
