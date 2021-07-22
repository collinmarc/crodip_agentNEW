Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatFvBancTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereEtat()
        Dim oCtrl As New ControleBanc()
        oCtrl.DateVerif = Date.Now().ToShortDateString()
        oCtrl.AgentVerif = m_oAgent.nom
        oCtrl.Proprietaire = m_oStructure.nom
        oCtrl.idBanc = "123-564-852"
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
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE & oEtat.getFileName())

    End Sub

    <TestMethod()>
    Public Sub TestCalcul()
        Dim oControle As New ControleBanc()
        oControle.b1_couleur = "Orange"
        oControle.b1_debitEtal = "0,523"
        oControle.b1_pressionEtal = "3"
        oControle.b1_3bar_m1 = "0,56"
        oControle.b1_3bar_m2 = "0,65"
        oControle.b1_3bar_m3 = "0,5"
        oControle.calc1()
        Assert.AreEqual("0,570", oControle.b1_3bar_moy)
        'Assert.AreEqual("0.025", oControle.b1_3bar_ecart)
        Assert.AreEqual("8,99%", oControle.b1_pctEcart3bar)

        oControle.b1_couleur = "Jaune"
        oControle.b1_debitEtal = "1,523"
        oControle.b1_pressionEtal = "3"
        oControle.b1_3bar_m1 = "1,56"
        oControle.b1_3bar_m2 = "1,65"
        oControle.b1_3bar_m3 = "1,5"
        oControle.calc1()
        Assert.AreEqual("1,570", oControle.b1_3bar_moy)
        'Assert.AreEqual("0.025", oControle.b1_3bar_ecart)
        Assert.AreEqual("3,09%", oControle.b1_pctEcart3bar)

        oControle.b1_couleur = "Rouge"
        oControle.b1_debitEtal = "2,523"
        oControle.b1_pressionEtal = "3"
        oControle.b1_3bar_m1 = "2,56"
        oControle.b1_3bar_m2 = "2,65"
        oControle.b1_3bar_m3 = "2,5"
        oControle.calc1()
        Assert.AreEqual("2,570", oControle.b1_3bar_moy)
        'Assert.AreEqual("0.025", oControle.b1_3bar_ecart)
        Assert.AreEqual("1,86%", oControle.b1_pctEcart3bar)

        oControle.b1_couleur = "Grise"
        oControle.b1_debitEtal = "3,523"
        oControle.b1_pressionEtal = "3"
        oControle.b1_3bar_m1 = "3,56"
        oControle.b1_3bar_m2 = "3,65"
        oControle.b1_3bar_m3 = "3,5"
        oControle.calc1()
        Assert.AreEqual("3,570", oControle.b1_3bar_moy)
        'Assert.AreEqual("0.025", oControle.b1_3bar_ecart)
        Assert.AreEqual("1,33%", oControle.b1_pctEcart3bar)


    End Sub
End Class