Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports CRODIPWS

<TestClass()> Public Class PcTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPc As New Pc()
        Dim oPc2 As Pc
        oPc.uid = 12345
        oPc.idPC = "ID12345"
        oPc.cleUtilisation = "CLE12345"
        Dim g As New Guid()
        g = Guid.NewGuid()
        oPc.idRegistre = g.ToString()
        oPc.uidstructure = m_oAgent.idStructure

        Assert.IsTrue(PcManager.Save(oPc))

        oPc2 = PcManager.GetByuid(12345)
        Assert.IsNotNull(oPc2)
        Assert.AreEqual(oPc.uid, oPc2.uid)
        Assert.AreEqual(oPc.aid, oPc2.aid)
        Assert.AreEqual(oPc.idPC, oPc2.idPC)
        Assert.AreEqual(oPc.idRegistre, oPc2.idRegistre)
        Assert.AreEqual(oPc.cleUtilisation, oPc2.cleUtilisation)
        Assert.AreEqual(oPc.uidstructure, oPc2.uidstructure)

        oPc.idRegistre = Guid.NewGuid().ToString()
        oPc.cleUtilisation = "CLE12345-2"
        PcManager.Save(oPc)
        oPc2 = PcManager.GetByuid(12345)
        Assert.IsNotNull(oPc2)
        Assert.AreEqual(oPc.idRegistre, oPc2.idRegistre)
        Assert.AreEqual(oPc.cleUtilisation, oPc2.cleUtilisation)

    End Sub
    <TestMethod()> Public Sub WSCRUD()
        Dim oPc As Pc
        Dim oPC2 As Pc = Nothing
        Dim nReturn As Integer

        oPc = PcManager.WSgetById(1, "")

        Assert.AreEqual(1, oPc.uid)

        oPc.cleUtilisation = "CLE12345"
        Dim g As New Guid()
        g = Guid.NewGuid()
        oPc.idRegistre = g.ToString()

        oPc.libelle = "testLibelle"
        oPc.etat = True
        oPc.agentSuppression = "AgentSuppression"
        oPc.raisonSuppression = "RaisonSuppression"
        oPc.dateSuppression = New Date(2025, 3, 26)
        oPc.isSupprime = False
        '        oPc.uidstructure
        '       oPc.idRegistre & "'"
        '      oPc.cleUtilisation & "'"
        oPc.marque = "MARQUE"
        oPc.modele = "MODELE"
        oPc.systeme = "SYSTEME"
        oPc.memoire = "MEMOIRE"
        oPc.disque = "DISQUE"
        oPc.memo = "MEMO"
        oPc.owc_etat = "0"
        oPc.owc_folder = "owc_folder"
        oPc.owc_commun = "1"
        oPc.owc_parametres = "0"
        oPc.owc_organismes = "0"
        oPc.owc_user = "owc_user"
        oPc.owc_password = "owc_password"
        oPc.owc_version = "owc_version"
        oPc.isSecours = "1"
        oPc.SignatureElect = "0"
        oPc.isSignElecActive = "1"
        oPc.modeSignature = "WACOM"
        oPc.versionLogiciel = "V4"
        oPc.isReinitialisationMode = "0"
        oPc.isMasterMode = "0"
        oPc.isDownloadMetrologieMode = "0"
        oPc.isDownloadTarificationMode = "0"
        oPc.isDownloadPulveExploitationMode = "0"
        oPc.isDownloadIdentifiantPulve = "0"

        '        oPc.uidstructure = m_oAgent.idStructure

        nReturn = PcManager.WSSend(oPc, oPC2)
        Assert.AreEqual(2, nReturn, "Code Retour = 2")

        oPC2 = PcManager.WSgetById(oPC2.uid, oPC2.aid)

        Assert.AreEqual(oPc.cleUtilisation, oPC2.cleUtilisation)
        Assert.AreEqual(oPc.idRegistre, oPC2.idRegistre)
        Assert.AreEqual(oPc.libelle, oPC2.libelle)
        Assert.AreEqual(oPC2.etat, True)
        Assert.AreEqual(oPc.agentSuppression, oPC2.agentSuppression, "AgentSuppression")
        Assert.AreEqual(oPc.raisonSuppression, oPC2.raisonSuppression, "RaisonSuppression")
        Assert.AreEqual(oPc.dateSuppression, oPC2.dateSuppression)
        Assert.AreEqual(oPc.isSupprime, oPC2.isSupprime)
        '        oPc2.uidstructure
        '       oPc2.idRegistre & "'"
        '      oPc2.cleUtilisation & "'"
        Assert.AreEqual(oPc.marque, oPC2.marque, "MARQUE")
        Assert.AreEqual(oPc.modele, oPC2.modele, "MODELE")
        Assert.AreEqual(oPc.systeme, oPC2.systeme, "SYSTEME")
        Assert.AreEqual(oPc.memoire, oPC2.memoire, "MEMOIRE")
        Assert.AreEqual(oPc.disque, oPC2.disque, "DISQUE")
        Assert.AreEqual(oPc.memo, oPC2.memo, "MEMO")
        Assert.AreEqual(oPc.owc_etat, oPC2.owc_etat, "owc_etat")
        Assert.AreEqual(oPc.owc_folder, oPC2.owc_folder, "owc_folder")
        Assert.AreEqual(oPc.owc_commun, oPC2.owc_commun, "owc_commun")
        Assert.AreEqual(oPc.owc_parametres, oPC2.owc_parametres, "owc_parametres")
        Assert.AreEqual(oPc.owc_organismes, oPC2.owc_organismes, "owc_organismes")
        Assert.AreEqual(oPc.owc_user, oPC2.owc_user, "owc_user")
        Assert.AreEqual(oPc.owc_password, oPC2.owc_password, "owc_password")
        Assert.AreEqual(oPc.owc_version, oPC2.owc_version, "owc_version")
        'Assert.AreEqual(oPc.isSecours, oPC2.isSecours, "Secours")
        'Assert.AreEqual(oPc.SignatureElect, oPC2.SignatureElect, "0")
        'Assert.AreEqual(oPc.isSignElecActive, oPC2.isSignElecActive, "1")
        Assert.AreEqual(oPc.modeSignature, oPC2.modeSignature, "WACOM")
        Assert.AreEqual(oPc.versionLogiciel, oPC2.versionLogiciel, "V4")
        'Assert.AreEqual(oPc.isReinitialisationMode, oPC2.isReinitialisationMode, "0")
        'Assert.AreEqual(oPc.isMasterMode, oPC2.isMasterMode, "0")
        'Assert.AreEqual(oPc.isDownloadMetrologieMode, oPC2.isDownloadMetrologieMode, "0")
        'Assert.AreEqual(oPc.isDownloadTarificationMode, oPC2.isDownloadTarificationMode, "0")
        'Assert.AreEqual(oPc.isDownloadPulveExploitationMode, oPC2.isDownloadPulveExploitationMode, "0")
        'Assert.AreEqual(oPc.isDownloadIdentifiantPulve, oPC2.isDownloadIdentifiantPulve, "0")

    End Sub




End Class