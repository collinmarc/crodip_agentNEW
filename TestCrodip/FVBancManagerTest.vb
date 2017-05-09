Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour FVBancManagerTest, destinée à contenir tous
'''les tests unitaires FVBancManagerTest
'''</summary>
<TestClass()> _
Public Class FVBancManagerTest
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
        Dim objFVBanc As FVBanc = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objFVBanc2 As FVBanc
        objFVBanc = New FVBanc(m_oAgent)
        objFVBanc.id = "9-99-99"
        objFVBanc.idBancMesure = "0001"

        Assert.IsTrue(FVBancManager.save(objFVBanc))

        objFVBanc2 = FVBancManager.getFVBancById("9-99-99")
        Assert.AreEqual("9-99-99", objFVBanc2.id)

        objFVBanc2.caracteristiques = "TEST"
        Assert.IsTrue(FVBancManager.save(objFVBanc2))

        objFVBanc = FVBancManager.getFVBancById("9-99-99")
        Assert.AreEqual(objFVBanc.caracteristiques, objFVBanc2.caracteristiques)

        FVBancManager.delete(objFVBanc.id)
        objFVBanc2 = FVBancManager.getFVBancById("9-99-99")
        Assert.AreNotEqual("9-99-99", objFVBanc2.id)

    End Sub
    '''<summary>
    '''Test des fiches de vies Bancs
    '''</summary>
    <TestMethod()> _
    Public Sub CreationDesFichesDeViesBancTest()
        Dim obanc As Banc
        Dim oFVBanc As FVBanc
        Dim olstFV As New List(Of FVBanc)
        obanc = New Banc()
        obanc.idStructure = m_oAgent.idStructure
        obanc.id = BancManager.FTO_getNewId(m_oAgent)
        obanc.JamaisServi = True
        obanc.isUtilise = False
        BancManager.save(obanc)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(0, olstFV.Count) 'Pas de fiche de vie

        obanc.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        BancManager.save(obanc)
        obanc = BancManager.getBancById(obanc.id)
        Assert.IsFalse(obanc.JamaisServi)
        Assert.AreEqual(CDate("01/06/2014"), obanc.DateActivation)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(1, olstFV.Count) 'une fiche de vie Activation
        oFVBanc = olstFV(0)
        Assert.AreEqual(oFVBanc.idBancMesure, obanc.id)
        Assert.AreEqual(oFVBanc.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("MISEENSERVICE", oFVBanc.type)
        pause(1000)
        'Utilisation du banc 
        Assert.IsFalse(obanc.isUtilise)
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        obanc = BancManager.getBancById(obanc.id)
        Assert.IsTrue(obanc.isUtilise)
        pause(1000)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(2, olstFV.Count) 'une fiche de vie PREMIERE UTILISATION
        oFVBanc = olstFV(1)
        Assert.AreEqual(oFVBanc.idBancMesure, obanc.id)
        Assert.AreEqual(oFVBanc.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("PREMIERE-UTILISATION", oFVBanc.type)

        'Re Utilisation du banc 
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        obanc = BancManager.getBancById(obanc.id)
        Assert.IsTrue(obanc.isUtilise)
        pause(1000)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        'Pas de création d'une seconde fiche de vie
        Assert.AreEqual(2, olstFV.Count) 'une fiche de vie PREMIERE UTILISATION

        'Désactivation du banc
        Assert.IsTrue(obanc.etat)
        obanc.DesactiverBanc(m_oAgent)
        obanc = BancManager.getBancById(obanc.id)
        Assert.IsFalse(obanc.etat)
        pause(1000)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        'Test de création d'une Troisième fiche de vie
        Assert.AreEqual(3, olstFV.Count) 'une fiche de vie "DESACTIVATION"
        oFVBanc = olstFV(2)
        Assert.AreEqual(oFVBanc.idBancMesure, obanc.id)
        Assert.AreEqual(oFVBanc.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("DESACTIVATION", oFVBanc.type)



        'Suppression du Banc
        'on ne peut pas supprimé un banc utilisé
        Assert.IsFalse(obanc.isSupprime)
        obanc.DeleteMateriel(m_oAgent, "TEST")
        Assert.IsFalse(obanc.isSupprime)

        'Reset du nombre de controle
        obanc.isUtilise = False
        BancManager.save(obanc)
        Assert.IsFalse(obanc.isSupprime)
        obanc.DeleteMateriel(m_oAgent, "TEST")
        obanc = BancManager.getBancById(obanc.id)
        Assert.IsTrue(obanc.isSupprime)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        'création d'une Troisième fiche de vie SUPRESSION
        Assert.AreEqual(4, olstFV.Count) 'une fiche de vie PREMIERE UTILISATION
        oFVBanc = olstFV(3)
        Assert.AreEqual(oFVBanc.idBancMesure, obanc.id)
        Assert.AreEqual(oFVBanc.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("SUPPRESSION", oFVBanc.type)



    End Sub

    '''<summary>
    '''Test des fiches de vies Bancs
    '''</summary>
    <TestMethod()> _
    Public Sub SynhcroDesFichesDeViesBancTest()
        Dim obanc As Banc
        Dim oFVBanc As FVBanc
        Dim olstFV As New List(Of FVBanc)
        obanc = New Banc()
        obanc.idStructure = m_oAgent.idStructure
        obanc.id = BancManager.FTO_getNewId(m_oAgent)
        obanc.JamaisServi = True
        obanc.isUtilise = False
        BancManager.save(obanc)


        obanc.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        BancManager.save(obanc)

        'Utilisation du banc 
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)

        'Désactivation du banc
        Assert.IsTrue(obanc.etat)
        obanc.DesactiverBanc(m_oAgent)

        'controle du banc
        Dim oCtrl As New ControleBanc()
        oCtrl.DateVerif = Date.Now()
        oCtrl.Proprietaire = m_oStructure.nom
        oCtrl.tempExt = "15"
        oCtrl.tempEau = "21"

        oCtrl.b1_NumNatBuse = "111111"
        oCtrl.b1_couleur = "Blanc"
        oCtrl.b1_pressionEtal = "3"
        oCtrl.b1_debitEtal = "0.523"
        oCtrl.b1_3bar_m1 = "0.56"
        oCtrl.b1_3bar_m2 = "0.65"
        oCtrl.b1_3bar_m3 = "0.500"
        oCtrl.b1_3bar_moy = "0.551"
        oCtrl.b1_3bar_ecart = "0.050"
        oCtrl.b1_3bar_pctEcart = "0.001"
        oCtrl.b1_3bar_pctTolerance = "0.002"
        oCtrl.b1_3bar_conformite = "False"

        oCtrl.b2_NumNatBuse = "222222"
        oCtrl.b2_couleur = "Rouge"
        oCtrl.b2_pressionEtal = "3"
        oCtrl.b2_debitEtal = "1.523"
        oCtrl.b2_3bar_m1 = "1.56"
        oCtrl.b2_3bar_m2 = "1.65"
        oCtrl.b2_3bar_m3 = "1.500"
        oCtrl.b2_3bar_moy = "1.551"
        oCtrl.b2_3bar_ecart = "1.050"
        oCtrl.b2_3bar_pctEcart = "1.001"
        oCtrl.b2_3bar_pctTolerance = "1.002"
        oCtrl.b2_3bar_conformite = "True"

        oCtrl.b3_NumNatBuse = "333333"
        oCtrl.b3_couleur = "Jaune"
        oCtrl.b3_pressionEtal = "3"
        oCtrl.b3_debitEtal = "2.523"
        oCtrl.b3_3bar_m1 = "2.56"
        oCtrl.b3_3bar_m2 = "2.65"
        oCtrl.b3_3bar_m3 = "2.500"
        oCtrl.b3_3bar_moy = "2.551"
        oCtrl.b3_3bar_ecart = "2.050"
        oCtrl.b3_3bar_pctEcart = "2.001"
        oCtrl.b3_3bar_pctTolerance = "2.002"
        oCtrl.b3_3bar_conformite = "False"

        oCtrl.b4_NumNatBuse = "444444"
        oCtrl.b4_couleur = "Vert"
        oCtrl.b4_pressionEtal = "3"
        oCtrl.b4_debitEtal = "3.523"
        oCtrl.b4_3bar_m1 = "3.56"
        oCtrl.b4_3bar_m2 = "3.65"
        oCtrl.b4_3bar_m3 = "3.500"
        oCtrl.b4_3bar_moy = "3.551"
        oCtrl.b4_3bar_ecart = "3.050"
        oCtrl.b4_3bar_pctEcart = "3.001"
        oCtrl.b4_3bar_pctTolerance = "3.002"
        oCtrl.b4_3bar_conformite = "True"

        oCtrl.b5_NumNatBuse = "555555"
        oCtrl.b5_couleur = "Marron"
        oCtrl.b5_pressionEtal = "3"
        oCtrl.b5_debitEtal = "4.523"
        oCtrl.b5_3bar_m1 = "4.56"
        oCtrl.b5_3bar_m2 = "4.65"
        oCtrl.b5_3bar_m3 = "4.500"
        oCtrl.b5_3bar_moy = "4.551"
        oCtrl.b5_3bar_ecart = "4.050"
        oCtrl.b5_3bar_pctEcart = "4.001"
        oCtrl.b5_3bar_pctTolerance = "4.002"
        oCtrl.b5_3bar_conformite = "False"

        oCtrl.b6_NumNatBuse = "6666666"
        oCtrl.b6_couleur = "Bleur"
        oCtrl.b6_pressionEtal = "3"
        oCtrl.b6_debitEtal = "5.523"
        oCtrl.b6_3bar_m1 = "5.56"
        oCtrl.b6_3bar_m2 = "5.65"
        oCtrl.b6_3bar_m3 = "5.500"
        oCtrl.b6_3bar_moy = "5.551"
        oCtrl.b6_3bar_ecart = "5.050"
        oCtrl.b6_3bar_pctEcart = "5.001"
        oCtrl.b6_3bar_pctTolerance = "5.002"
        oCtrl.b6_3bar_conformite = "True"

        oCtrl.resultat = "Le résultat est négatif : vérifiez votre banc de mesure de débits"
        pause(1000)
        obanc.creerfFicheVieControle(m_oAgent, oCtrl)
        Dim oLst As New List(Of FVBanc)
        oLst = FVBancManager.getlstFVBancByBancId(obanc.id)
        'La Fiche de vie "Controle" est la dernière crée
        Dim oFV As FVBanc
        oFV = oLst(oLst.Count - 1)
        Assert.IsFalse(String.IsNullOrEmpty(oFV.FVFileName))
        Dim strFVFileName As String
        strFVFileName = oFV.FVFileName

        Assert.AreEqual(4, FVBancManager.getUpdates(m_oAgent).Length)
        Dim oSynchro As New Synchronisation(m_oAgent)
        oSynchro.runascSynchroFVBanc()

        'Por Véfifier que le Fichier est bien sur le FTP
        'On le télécharge et on vérifie qu'il existe
        System.IO.Directory.CreateDirectory("tmp/FV/BC")
        Dim oFTP As New CSFTP()
        oFTP.DownLoad("FV/BC/" & strFVFileName, "tmp/")
        Assert.IsTrue(System.IO.File.Exists("tmp/FV/BC/" & strFVFileName))

        Assert.AreEqual(0, FVBancManager.getUpdates(m_oAgent).Length)

        'Suppression du Banc
        obanc.isUtilise = False
        BancManager.save(obanc)
        obanc.DeleteMateriel(m_oAgent, "TEST")
    End Sub
    <TestMethod()> _
    Public Sub TestCreationFVBanc()
        Dim obanc As Banc
        Dim oFVBanc As FVBanc
        Dim olstFV As New List(Of FVBanc)

        'Création du banc Fictif (normalement créé par le CRODIP)
        obanc = New Banc()
        obanc.idStructure = m_oAgent.idStructure
        obanc.id = BancManager.FTO_getNewId(m_oAgent)
        obanc.JamaisServi = True
        obanc.isUtilise = False
        BancManager.save(obanc)

        obanc.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)

        Assert.AreEqual(1, olstFV.Count)
        oFVBanc = olstFV(0)
        Assert.AreEqual(FVBanc.FVTYPE_MISENSERVICE, oFVBanc.type)
        pause(1000)

        'Première utilisation du banc
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(2, olstFV.Count)
        oFVBanc = olstFV(0)
        Assert.AreEqual(FVBanc.FVTYPE_MISENSERVICE, oFVBanc.type)
        oFVBanc = olstFV(1)
        Assert.AreEqual(FVBanc.FVTYPE_PREMIEREUTILISATION, oFVBanc.type)
        pause(1000)

        'Seconde utilisation du banc => Pas de création de Fiche de vie
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(2, olstFV.Count)
        pause(1000)

        'Désactivation du banc
        obanc.DesactiverBanc(m_oAgent)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(3, olstFV.Count)
        oFVBanc = olstFV(2)
        Assert.AreEqual(FVBanc.FVTYPE_DESACTIVATION, oFVBanc.type)
        pause(1000)

        'Réactivation  du banc
        obanc.ActiverMateriel(Date.Now, m_oAgent)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(4, olstFV.Count)
        oFVBanc = olstFV(3)
        Assert.AreEqual(FVBanc.FVTYPE_MISENSERVICE, oFVBanc.type)
        pause(1000)

        'controle du banc
        Dim oCtrl As New ControleBanc()
        oCtrl.DateVerif = Date.Now()
        oCtrl.Proprietaire = m_oStructure.nom
        oCtrl.tempExt = "15"
        oCtrl.tempEau = "21"

        oCtrl.b1_NumNatBuse = "111111"
        oCtrl.b1_couleur = "Blanc"
        oCtrl.b1_pressionEtal = "3"
        oCtrl.b1_debitEtal = "0.523"
        oCtrl.b1_3bar_m1 = "0.56"
        oCtrl.b1_3bar_m2 = "0.65"
        oCtrl.b1_3bar_m3 = "0.500"
        oCtrl.b1_3bar_moy = "0.551"
        oCtrl.b1_3bar_ecart = "0.050"
        oCtrl.b1_3bar_pctEcart = "0.001"
        oCtrl.b1_3bar_pctTolerance = "0.002"
        oCtrl.b1_3bar_conformite = "False"

        oCtrl.b2_NumNatBuse = "222222"
        oCtrl.b2_couleur = "Rouge"
        oCtrl.b2_pressionEtal = "3"
        oCtrl.b2_debitEtal = "1.523"
        oCtrl.b2_3bar_m1 = "1.56"
        oCtrl.b2_3bar_m2 = "1.65"
        oCtrl.b2_3bar_m3 = "1.500"
        oCtrl.b2_3bar_moy = "1.551"
        oCtrl.b2_3bar_ecart = "1.050"
        oCtrl.b2_3bar_pctEcart = "1.001"
        oCtrl.b2_3bar_pctTolerance = "1.002"
        oCtrl.b2_3bar_conformite = "True"

        oCtrl.b3_NumNatBuse = "333333"
        oCtrl.b3_couleur = "Jaune"
        oCtrl.b3_pressionEtal = "3"
        oCtrl.b3_debitEtal = "2.523"
        oCtrl.b3_3bar_m1 = "2.56"
        oCtrl.b3_3bar_m2 = "2.65"
        oCtrl.b3_3bar_m3 = "2.500"
        oCtrl.b3_3bar_moy = "2.551"
        oCtrl.b3_3bar_ecart = "2.050"
        oCtrl.b3_3bar_pctEcart = "2.001"
        oCtrl.b3_3bar_pctTolerance = "2.002"
        oCtrl.b3_3bar_conformite = "False"

        oCtrl.b4_NumNatBuse = "444444"
        oCtrl.b4_couleur = "Vert"
        oCtrl.b4_pressionEtal = "3"
        oCtrl.b4_debitEtal = "3.523"
        oCtrl.b4_3bar_m1 = "3.56"
        oCtrl.b4_3bar_m2 = "3.65"
        oCtrl.b4_3bar_m3 = "3.500"
        oCtrl.b4_3bar_moy = "3.551"
        oCtrl.b4_3bar_ecart = "3.050"
        oCtrl.b4_3bar_pctEcart = "3.001"
        oCtrl.b4_3bar_pctTolerance = "3.002"
        oCtrl.b4_3bar_conformite = "True"

        oCtrl.b5_NumNatBuse = "555555"
        oCtrl.b5_couleur = "Marron"
        oCtrl.b5_pressionEtal = "3"
        oCtrl.b5_debitEtal = "4.523"
        oCtrl.b5_3bar_m1 = "4.56"
        oCtrl.b5_3bar_m2 = "4.65"
        oCtrl.b5_3bar_m3 = "4.500"
        oCtrl.b5_3bar_moy = "4.551"
        oCtrl.b5_3bar_ecart = "4.050"
        oCtrl.b5_3bar_pctEcart = "4.001"
        oCtrl.b5_3bar_pctTolerance = "4.002"
        oCtrl.b5_3bar_conformite = "False"

        oCtrl.b6_NumNatBuse = "6666666"
        oCtrl.b6_couleur = "Bleur"
        oCtrl.b6_pressionEtal = "3"
        oCtrl.b6_debitEtal = "5.523"
        oCtrl.b6_3bar_m1 = "5.56"
        oCtrl.b6_3bar_m2 = "5.65"
        oCtrl.b6_3bar_m3 = "5.500"
        oCtrl.b6_3bar_moy = "5.551"
        oCtrl.b6_3bar_ecart = "5.050"
        oCtrl.b6_3bar_pctEcart = "5.001"
        oCtrl.b6_3bar_pctTolerance = "5.002"
        oCtrl.b6_3bar_conformite = "True"

        oCtrl.resultat = "Le résultat est négatif : vérifiez votre banc de mesure de débits"

        obanc.creerfFicheVieControle(m_oAgent, oCtrl)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(5, olstFV.Count)
        oFVBanc = olstFV(4)
        Assert.AreEqual(FVBanc.FVTYPE_CONTROLE, oFVBanc.type)
        Assert.IsFalse(String.IsNullOrEmpty(oFVBanc.FVFileName))

    End Sub
End Class
