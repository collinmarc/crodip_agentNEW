Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour FVManometreEtalon,
''' </summary>
<TestClass()> _
Public Class FVManoEtalonManagerTest

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
        Dim objFVManometreEtalon As FVManometreEtalon = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objFVManometreEtalon2 As FVManometreEtalon
        objFVManometreEtalon = New FVManometreEtalon(m_oAgent)
        objFVManometreEtalon.id = "9-99-99"
        objFVManometreEtalon.idManometre = "9-99-99"
        objFVManometreEtalon.idAgentControleur = m_oAgent.id

        Assert.IsTrue(FVManometreEtalonManager.save(objFVManometreEtalon))

        objFVManometreEtalon2 = FVManometreEtalonManager.getFVManometreEtalonById("9-99-99")
        Assert.AreEqual("9-99-99", objFVManometreEtalon2.id)

        'Il n'y a pas de MAJ des fiches de vie
        objFVManometreEtalon2.caracteristiques = "TEST"
        Assert.IsFalse(FVManometreEtalonManager.save(objFVManometreEtalon2))

        objFVManometreEtalon = FVManometreEtalonManager.getFVManometreEtalonById("9-99-99")
        FVManometreEtalonManager.delete(objFVManometreEtalon.id)
        objFVManometreEtalon2 = FVManometreEtalonManager.getFVManometreEtalonById("9-99-99")
        Assert.AreNotEqual("9-99-99", objFVManometreEtalon2.id)

    End Sub
    '''<summary>
    '''Test des fiches de vies Bancs
    '''</summary>
    <TestMethod()> _
    Public Sub CreationDesFichesDeViesBancTest()
        Dim oMano As ManometreEtalon
        Dim oFVManometreEtalon As FVManometreEtalon
        Dim olstFV As New List(Of FVManometreEtalon)
        oMano = New ManometreEtalon()
        oMano.idStructure = m_oAgent.idStructure
        oMano.numeroNational = ManometreEtalonManager.getNewNumeroNationalForTestOnly(m_oAgent)
        oMano.idCrodip = oMano.numeroNational
        oMano.JamaisServi = True
        oMano.isUtilise = False
        ManometreEtalonManager.save(oMano)

        olstFV = FVManometreEtalonManager.getArrFVManometreEtalon(oMano.idCrodip)
        Assert.AreEqual(0, olstFV.Count) 'Pas de fiche de vie

        oMano.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        ManometreEtalonManager.save(oMano)
        oMano = ManometreEtalonManager.getManometreEtalonByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.JamaisServi)
        Assert.AreEqual(CDate("01/06/2014"), oMano.DateActivation)

        olstFV = FVManometreEtalonManager.getArrFVManometreEtalon(oMano.idCrodip)
        Assert.AreEqual(1, olstFV.Count) 'une fiche de vie Activation
        oFVManometreEtalon = olstFV(0)
        Assert.AreEqual(oFVManometreEtalon.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreEtalon.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("MISEENSERVICE", oFVManometreEtalon.type)

        'Utilisation du manoEtalon

        ManometreEtalonManager.setUtilise(m_oAgent, oMano)
        oMano = ManometreEtalonManager.getManometreEtalonByNumeroNational(oMano.idCrodip)
        Assert.IsTrue(oMano.isUtilise)
        olstFV = FVManometreEtalonManager.getArrFVManometreEtalon(oMano.idCrodip)
        Assert.AreEqual(2, olstFV.Count) 'une fiche de vie Activation
        oFVManometreEtalon = olstFV(1)
        Assert.AreEqual(oFVManometreEtalon.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreEtalon.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("PREMIERE-UTILISATION", oFVManometreEtalon.type)


        'Désactivation du banc
        Assert.IsTrue(oMano.etat)
        oMano.DesactiverMano(m_oAgent)
        oMano = ManometreEtalonManager.getManometreEtalonByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.etat)

        olstFV = FVManometreEtalonManager.getArrFVManometreEtalon(oMano.idCrodip)
        'Test de création d'une fiche de vie
        Assert.AreEqual(3, olstFV.Count) 'une fiche de vie "DESACTIVATION"
        oFVManometreEtalon = olstFV(2)
        Assert.AreEqual(oFVManometreEtalon.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreEtalon.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("DESACTIVATION", oFVManometreEtalon.type)



        'Suppression du Manometre
        Assert.IsFalse(oMano.isSupprime)
        oMano.DeleteMateriel(m_oAgent, "TEST")
        Assert.IsTrue(oMano.isSupprime)


        olstFV = FVManometreEtalonManager.getArrFVManometreEtalon(oMano.idCrodip)
        'création d'une Troisième fiche de vie SUPRESSION
        Assert.AreEqual(4, olstFV.Count) 'une fiche de vie SUPPRESSION
        oFVManometreEtalon = olstFV(3)
        Assert.AreEqual(oFVManometreEtalon.idManometre, oMano.idCrodip)
        Assert.AreEqual(oFVManometreEtalon.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("SUPPRESSION", oFVManometreEtalon.type)



    End Sub

    '''<summary>
    '''Test des WS Fiches de vies de Manos de Etalons
    '''</summary>
    <TestMethod()> _
    Public Sub SynhcroDesFichesDeViesBancTest()
        Dim oMano As ManometreEtalon
        Dim oFVManometreEtalon As FVManometreEtalon
        Dim olstFV As New List(Of FVManometreEtalon)
        oMano = New ManometreEtalon()
        oMano.idStructure = m_oAgent.idStructure
        oMano.numeroNational = ManometreEtalonManager.getNewNumeroNationalForTestOnly(m_oAgent)
        oMano.idCrodip = oMano.numeroNational
        oMano.JamaisServi = True
        oMano.isUtilise = False
        ManometreEtalonManager.save(oMano)

        olstFV = FVManometreEtalonManager.getArrFVManometreEtalon(oMano.idCrodip)
        oMano.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        ManometreEtalonManager.save(oMano)
        oMano = ManometreEtalonManager.getManometreEtalonByNumeroNational(oMano.idCrodip)

        ManometreEtalonManager.setUtilise(m_oAgent, oMano)

        'Désactivation du Mano
        Assert.IsTrue(oMano.etat)
        oMano.DesactiverMano(m_oAgent)
        oMano = ManometreEtalonManager.getManometreEtalonByNumeroNational(oMano.idCrodip)
        Assert.IsFalse(oMano.etat)

        'Suppression du Manometre
        Assert.IsFalse(oMano.isSupprime)
        oMano.DeleteMateriel(m_oAgent, "TEST")
        Assert.IsTrue(oMano.isSupprime)


        Assert.AreEqual(4, FVManometreEtalonManager.getUpdates(m_oAgent).Length)
        Dim oSynchro As New Synchronisation(m_oAgent)
        oSynchro.runascSynchroFVManoEtalon()
        Assert.AreEqual(0, FVManometreEtalonManager.getUpdates(m_oAgent).Length)

    End Sub
End Class
