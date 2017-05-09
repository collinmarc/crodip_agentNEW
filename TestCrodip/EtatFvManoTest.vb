Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatFvManoTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereEtatMano()
        Dim oCtrl As ControleMano
        Dim oManoRef As ManometreEtalon
        oManoRef = New ManometreEtalon
        oManoRef.idStructure = m_oAgent.idStructure
        oManoRef.idCrodip = "999"
        oManoRef.numeroNational = "00447"
        oManoRef.marque = "BD SENSOR"
        oManoRef.classe = "0.1"
        oManoRef.type = "Capteur / Transmetteeur de pression"
        oManoRef.fondEchelle = 25
        oManoRef.incertitudeEtalon = 0.004
        ManometreEtalonManager.save(oManoRef)

        Dim oManoCtrl As ManometreControle
        oManoCtrl = New ManometreControle()
        oManoCtrl.idStructure = m_oAgent.idStructure
        oManoCtrl.idCrodip = "888"
        oManoCtrl.numeroNational = "10003"
        oManoCtrl.marque = "BAUMER-BOURDON"
        oManoCtrl.classe = "1"
        oManoCtrl.type = "Numérique"
        oManoCtrl.fondEchelle = 10
        oManoCtrl.resolution = ""
        ManometreControleManager.save(oManoCtrl)

        oCtrl = New ControleMano()
        oCtrl.idStructure = m_oAgent.idStructure
        oCtrl.manoEtalon = oManoRef.numeroNational
        oCtrl.idMano = oManoCtrl.numeroNational
        oCtrl.DateVerif = CSDate.GetDateForWS("2015/10/19 15:57:45")
        oCtrl.AgentVerif = "Rault Marc-Antoine"
        oCtrl.Proprietaire = "Crodip_agent"
        oCtrl.tempAir = "18"
        oCtrl.resultat = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
        oCtrl.up_pt1_pres_manoCtrl = "0"
        oCtrl.up_pt1_pres_manoEtalon = "0,000"
        oCtrl.up_pt1_err_abs = "0,00"
        oCtrl.up_pt1_err_fondEchelle = "0,0"
        oCtrl.up_pt1_incertitude = "0,00"
        oCtrl.up_pt1_EMT = "0,1"
        oCtrl.up_pt1_conformite = 1

        oCtrl.up_pt2_pres_manoCtrl = "2"
        oCtrl.up_pt2_pres_manoEtalon = "2,120"
        oCtrl.up_pt2_err_abs = "0,12"
        oCtrl.up_pt2_err_fondEchelle = "1,2"
        oCtrl.up_pt2_incertitude = "0,004"
        oCtrl.up_pt2_EMT = "0,1"
        oCtrl.up_pt2_conformite = 0

        oCtrl.up_pt3_pres_manoCtrl = 10
        oCtrl.up_pt3_pres_manoEtalon = 11.652
        oCtrl.up_pt3_err_abs = 12.12
        oCtrl.up_pt3_err_fondEchelle = 13.1
        oCtrl.up_pt3_incertitude = 14
        oCtrl.up_pt3_EMT = 15
        oCtrl.up_pt3_conformite = 1

        oCtrl.up_pt4_pres_manoCtrl = 10
        oCtrl.up_pt4_pres_manoEtalon = 11.652
        oCtrl.up_pt4_err_abs = 12.12
        oCtrl.up_pt4_err_fondEchelle = 13.1
        oCtrl.up_pt4_incertitude = 14
        oCtrl.up_pt4_EMT = 15
        oCtrl.up_pt4_conformite = 1

        oCtrl.up_pt5_pres_manoCtrl = 10
        oCtrl.up_pt5_pres_manoEtalon = 11.652
        oCtrl.up_pt5_err_abs = 12.12
        oCtrl.up_pt5_err_fondEchelle = 13.1
        oCtrl.up_pt5_incertitude = 14
        oCtrl.up_pt5_EMT = 15
        oCtrl.up_pt5_conformite = 1

        oCtrl.up_pt6_pres_manoCtrl = 10
        oCtrl.up_pt6_pres_manoEtalon = 11.652
        oCtrl.up_pt6_err_abs = 12.12
        oCtrl.up_pt6_err_fondEchelle = 13.1
        oCtrl.up_pt6_incertitude = 14
        oCtrl.up_pt6_EMT = 15
        oCtrl.up_pt6_conformite = 1

        oCtrl.down_pt1_pres_manoCtrl = 10
        oCtrl.down_pt1_pres_manoEtalon = 11.652
        oCtrl.down_pt1_err_abs = 12.12
        oCtrl.down_pt1_err_fondEchelle = 13.1
        oCtrl.down_pt1_incertitude = 14
        oCtrl.down_pt1_EMT = 15
        oCtrl.down_pt1_conformite = 1

        oCtrl.down_pt2_pres_manoCtrl = 10
        oCtrl.down_pt2_pres_manoEtalon = 11.652
        oCtrl.down_pt2_err_abs = 12.12
        oCtrl.down_pt2_err_fondEchelle = 13.1
        oCtrl.down_pt2_incertitude = 14
        oCtrl.down_pt2_EMT = 15
        oCtrl.down_pt2_conformite = 1

        oCtrl.down_pt3_pres_manoCtrl = 10
        oCtrl.down_pt3_pres_manoEtalon = 11.652
        oCtrl.down_pt3_err_abs = 12.12
        oCtrl.down_pt3_err_fondEchelle = 13.1
        oCtrl.down_pt3_incertitude = 14
        oCtrl.down_pt3_EMT = 15
        oCtrl.down_pt3_conformite = 1

        oCtrl.down_pt4_pres_manoCtrl = 10
        oCtrl.down_pt4_pres_manoEtalon = 11.652
        oCtrl.down_pt4_err_abs = 12.12
        oCtrl.down_pt4_err_fondEchelle = 13.1
        oCtrl.down_pt4_incertitude = 14
        oCtrl.down_pt4_EMT = 15
        oCtrl.down_pt4_conformite = 1

        oCtrl.down_pt5_pres_manoCtrl = 10
        oCtrl.down_pt5_pres_manoEtalon = 11.652
        oCtrl.down_pt5_err_abs = 12.12
        oCtrl.down_pt5_err_fondEchelle = 13.1
        oCtrl.down_pt5_incertitude = 14
        oCtrl.down_pt5_EMT = 15
        oCtrl.down_pt5_conformite = 1

        oCtrl.down_pt6_pres_manoCtrl = 10
        oCtrl.down_pt6_pres_manoEtalon = 11.652
        oCtrl.down_pt6_err_abs = 12.12
        oCtrl.down_pt6_err_fondEchelle = 13.1
        oCtrl.down_pt6_incertitude = 14
        oCtrl.down_pt6_EMT = 15
        oCtrl.down_pt6_conformite = 1


        Dim oEtat As New EtatFVMano(oCtrl)
        Assert.IsTrue(oEtat.GenereEtat())
        oEtat.Open()
    End Sub

End Class