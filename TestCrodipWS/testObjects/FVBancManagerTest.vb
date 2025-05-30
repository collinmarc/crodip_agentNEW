﻿Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CRODIPWS
Imports Crodip_agent

'''<summary>
'''Classe de test pour FVBancManagerTest, destinée à contenir tous
'''les tests unitaires FVBancManagerTest
'''</summary>
<TestClass()>
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
        Dim objFVBanc As FVBanc = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objFVBanc2 As FVBanc
        objFVBanc = New FVBanc(m_oAgent)
        objFVBanc.id = m_oBanc.id
        objFVBanc.idBancMesure = m_oBanc.id

        Assert.IsTrue(FVBancManager.save(objFVBanc))

        objFVBanc2 = FVBancManager.getFVBancById(m_oBanc.id)
        Assert.AreEqual(m_oBanc.id, objFVBanc2.idBancMesure)

        objFVBanc2.caracteristiques = "TEST"
        Assert.IsTrue(FVBancManager.save(objFVBanc2))

        objFVBanc = FVBancManager.getFVBancById(m_oBanc.id)
        Assert.AreEqual(objFVBanc.caracteristiques, objFVBanc2.caracteristiques)

        FVBancManager.delete(objFVBanc.id)
        objFVBanc2 = FVBancManager.getFVBancById(m_oBanc.id)
        Assert.AreNotEqual(m_oBanc.id, objFVBanc2.id)

    End Sub
    '''<summary>
    '''Test des fiches de vies Bancs
    '''</summary>
    <TestMethod()>
    Public Sub CreationDesFichesDeViesBancTest()
        Dim obanc As Banc
        Dim oFVBanc As FVBanc
        Dim olstFV As New List(Of FVBanc)
        obanc = m_oBanc
        obanc.jamaisServi = True
        obanc.isUtilise = False
        BancManager.save(obanc)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(0, olstFV.Count) 'Pas de fiche de vie

        obanc.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        BancManager.save(obanc)
        obanc = BancManager.getBancById(obanc.id)
        Assert.IsFalse(obanc.jamaisServi)
        Assert.AreEqual(CDate("01/06/2014"), obanc.DateActivation)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(1, olstFV.Count) 'une fiche de vie Activation
        oFVBanc = olstFV(0)
        Assert.AreEqual(oFVBanc.idBancMesure, obanc.id)
        Assert.AreEqual(oFVBanc.idAgentControleur, m_oAgent.id)
        Assert.AreEqual("MISEENSERVICE", oFVBanc.type)
        System.Threading.Thread.Sleep(1000)
        'Utilisation du banc 
        Assert.IsFalse(obanc.isUtilise)
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        obanc = BancManager.getBancById(obanc.id)
        Assert.IsTrue(obanc.isUtilise)
        System.Threading.Thread.Sleep(1000)

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
        System.Threading.Thread.Sleep(1000)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        'Pas de création d'une seconde fiche de vie
        Assert.AreEqual(2, olstFV.Count) 'une fiche de vie PREMIERE UTILISATION

        'Désactivation du banc
        Assert.IsTrue(obanc.etat)
        obanc.Desactiver(m_oAgent)
        obanc = BancManager.getBancById(obanc.id)
        Assert.IsFalse(obanc.etat)
        System.Threading.Thread.Sleep(1000)

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


    <TestMethod()>
    Public Sub TestCreationFVBanc()
        Dim obanc As Banc
        Dim oFVBanc As FVBanc
        Dim olstFV As New List(Of FVBanc)

        'Création du banc Fictif (normalement créé par le CRODIP)
        obanc = m_oBanc
        obanc.jamaisServi = True
        obanc.isUtilise = False
        BancManager.save(obanc)

        obanc.ActiverMateriel(CDate("01/06/2014"), m_oAgent)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)

        Assert.AreEqual(1, olstFV.Count)
        oFVBanc = olstFV(0)
        Assert.AreEqual(FVBanc.FVTYPE_MISENSERVICE, oFVBanc.type)
        System.Threading.Thread.Sleep(1000)

        'Première utilisation du banc
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(2, olstFV.Count)
        oFVBanc = olstFV(0)
        Assert.AreEqual(FVBanc.FVTYPE_MISENSERVICE, oFVBanc.type)
        oFVBanc = olstFV(1)
        Assert.AreEqual(FVBanc.FVTYPE_PREMIEREUTILISATION, oFVBanc.type)
        System.Threading.Thread.Sleep(1000)

        'Seconde utilisation du banc => Pas de création de Fiche de vie
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(2, olstFV.Count)
        System.Threading.Thread.Sleep(1000)

        'Désactivation du banc
        obanc.Desactiver(m_oAgent)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(3, olstFV.Count)
        oFVBanc = olstFV(2)
        Assert.AreEqual(FVBanc.FVTYPE_DESACTIVATION, oFVBanc.type)
        System.Threading.Thread.Sleep(1000)

        'Réactivation  du banc
        obanc.ActiverMateriel(Date.Now, m_oAgent)
        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(4, olstFV.Count)
        oFVBanc = olstFV(3)
        Assert.AreEqual(FVBanc.FVTYPE_MISENSERVICE, oFVBanc.type)
        System.Threading.Thread.Sleep(1000)

        'controle du banc
        Dim oCtrl As New ControleBanc()
        oCtrl.DateVerif = Date.Now().ToShortDateString()
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
        Dim oEtat As New EtatFVBanc(oCtrl)
        Dim sFileName As String = oEtat.buildPDF(obanc, m_oAgent)

        obanc.creerfFicheVieControle(m_oAgent, oCtrl, sFileName)

        olstFV = FVBancManager.getlstFVBancByBancId(obanc.id)
        Assert.AreEqual(5, olstFV.Count)
        oFVBanc = olstFV(4)
        Assert.AreEqual(FVBanc.FVTYPE_CONTROLE, oFVBanc.type)
        Assert.IsFalse(String.IsNullOrEmpty(oFVBanc.FVFileName))

    End Sub
End Class
