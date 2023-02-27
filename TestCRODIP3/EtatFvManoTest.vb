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
        oManoRef.fondEchelle = "25"
        oManoRef.incertitudeEtalon = "0.004"
        ManometreEtalonManager.save(oManoRef)

        Dim oManoCtrl As ManometreControle
        oManoCtrl = New ManometreControle()
        oManoCtrl.idStructure = m_oAgent.idStructure
        oManoCtrl.idCrodip = "888"
        oManoCtrl.numeroNational = "10003"
        oManoCtrl.marque = "BAUMER-BOURDON"
        oManoCtrl.classe = "1"
        oManoCtrl.type = "Numérique"
        oManoCtrl.fondEchelle = "10"
        oManoCtrl.resolution = ""
        ManometreControleManager.save(oManoCtrl)

        oCtrl = New ControleMano(oManoCtrl, m_oAgent)
        oCtrl.idStructure = m_oAgent.idStructure.ToString
        oCtrl.manoEtalon = oManoRef.numeroNational
        oCtrl.idMano = oManoCtrl.numeroNational
        oCtrl.DateVerif = CSDate.GetDateForWS("2015/10/19 15:57:45")
        '       oCtrl.AgentVerif = "Rault Marc-Antoine"
        oCtrl.Proprietaire = "Crodip_agent"
        oCtrl.tempAir = "18"
        oCtrl.resultat = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
        oCtrl.lstControleManoDetail_pres_manoCtrl("UP1") = "0"
        oCtrl.lstControleManoDetail_pres_manoEtalon("UP1") = "0,000"
        oCtrl.lstControleManoDetail_err_abs("UP1") = "0,00"
        oCtrl.lstControleManoDetail_err_FondEchelle("UP1") = "0,0"
        oCtrl.lstControleManoDetail_incertitude("UP1") = "0,00"
        oCtrl.lstControleManoDetail_EMT("UP1") = "0,1"
        oCtrl.lstControleManoDetail_conformite("UP1") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("UP2") = "1,2"
        oCtrl.lstControleManoDetail_pres_manoEtalon("UP2") = "2,120"
        oCtrl.lstControleManoDetail_err_abs("UP2") = "0,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("UP2") = "1,2"
        oCtrl.lstControleManoDetail_incertitude("UP2") = "0,004"
        oCtrl.lstControleManoDetail_EMT("UP2") = "0,1"
        oCtrl.lstControleManoDetail_conformite("UP2") = "0"

        oCtrl.lstControleManoDetail_pres_manoCtrl("UP3") = "2,4"
        oCtrl.lstControleManoDetail_pres_manoEtalon("UP3") = "11,652"
        oCtrl.lstControleManoDetail_err_abs("UP3") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("UP3") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("UP3") = "14"
        oCtrl.lstControleManoDetail_EMT("UP3") = "15"
        oCtrl.lstControleManoDetail_conformite("UP3") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("UP4") = "3,6"
        oCtrl.lstControleManoDetail_pres_manoEtalon("UP4") = "11,652"
        oCtrl.lstControleManoDetail_err_abs("UP4") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("UP4") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("UP4") = "14"
        oCtrl.lstControleManoDetail_EMT("UP4") = "15"
        oCtrl.lstControleManoDetail_conformite("UP4") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("UP5") = "4,8"
        oCtrl.lstControleManoDetail_pres_manoEtalon("UP5") = "11,652"
        oCtrl.lstControleManoDetail_err_abs("UP5") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("UP5") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("UP5") = "14"
        oCtrl.lstControleManoDetail_EMT("UP5") = "15"
        oCtrl.lstControleManoDetail_conformite("UP5") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("UP6") = "6,0"
        oCtrl.lstControleManoDetail_pres_manoEtalon("UP6") = "11,652"
        oCtrl.lstControleManoDetail_err_abs("UP6") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("UP6") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("UP6") = "14"
        oCtrl.lstControleManoDetail_EMT("UP6") = "15"
        oCtrl.lstControleManoDetail_conformite("UP6") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("DOWN6") = "6,0"
        oCtrl.lstControleManoDetail_pres_manoEtalon("DOWN6") = "11,652"
        oCtrl.lstControleManoDetail_err_abs("DOWN6") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("DOWN6") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("DOWN6") = "14"
        oCtrl.lstControleManoDetail_EMT("DOWN6") = "15"
        oCtrl.lstControleManoDetail_conformite("DOWN6") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("DOWN5") = "4,8"
        oCtrl.lstControleManoDetail_pres_manoEtalon("DOWN5") = "11.652"
        oCtrl.lstControleManoDetail_err_abs("DOWN5") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("DOWN5") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("DOWN5") = "14"
        oCtrl.lstControleManoDetail_EMT("DOWN5") = "15"
        oCtrl.lstControleManoDetail_conformite("DOWN5") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("DOWN4") = "3,6"
        oCtrl.lstControleManoDetail_pres_manoEtalon("DOWN4") = "11,652"
        oCtrl.lstControleManoDetail_err_abs("DOWN4") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("DOWN4") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("DOWN4") = "14"
        oCtrl.lstControleManoDetail_EMT("DOWN4") = "15"
        oCtrl.lstControleManoDetail_conformite("DOWN4") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("DOWN3") = "2,4"
        oCtrl.lstControleManoDetail_pres_manoEtalon("DOWN3") = "11,652"
        oCtrl.lstControleManoDetail_err_abs("DOWN3") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("DOWN3") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("DOWN3") = "14"
        oCtrl.lstControleManoDetail_EMT("DOWN3") = "15"
        oCtrl.lstControleManoDetail_conformite("DOWN3") = "1"


        oCtrl.lstControleManoDetail_pres_manoCtrl("DOWN2") = "1,2"
        oCtrl.lstControleManoDetail_pres_manoEtalon("DOWN2") = "11,652"
        oCtrl.lstControleManoDetail_err_abs("DOWN2") = "12,12"
        oCtrl.lstControleManoDetail_err_FondEchelle("DOWN2") = "13,1"
        oCtrl.lstControleManoDetail_incertitude("DOWN2") = "14"
        oCtrl.lstControleManoDetail_EMT("DOWN2") = "15"
        oCtrl.lstControleManoDetail_conformite("DOWN2") = "1"

        oCtrl.lstControleManoDetail_pres_manoCtrl("DOWN1") = "0,0"
        oCtrl.lstControleManoDetail_pres_manoEtalon("DOWN1") = "11.652"
        oCtrl.lstControleManoDetail_err_abs("DOWN1") = "12.12"
        oCtrl.lstControleManoDetail_err_FondEchelle("DOWN1") = "13.1"
        oCtrl.lstControleManoDetail_incertitude("DOWN1") = "14"
        oCtrl.lstControleManoDetail_EMT("DOWN1") = "15"
        oCtrl.lstControleManoDetail_conformite("DOWN1") = "1"



        Dim oEtat As New EtatFVMano(oCtrl)
        Assert.IsTrue(oEtat.GenereEtat())
        oEtat.Open()
    End Sub

End Class