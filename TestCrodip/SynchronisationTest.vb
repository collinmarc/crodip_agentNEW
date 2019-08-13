Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO

<TestClass()>
Public Class SynchronisationTest
    Inherits CRODIPTest
    <TestMethod()>
    Public Sub testObject()
        Dim oSyncho = New Synchronisation(m_oAgent)
        oSyncho.sens = "desc"

        Assert.AreEqual("desc", oSyncho.sens)


    End Sub

    <TestMethod()>
    Public Sub testGetLstSynchro()
        Dim oSynchro As New Synchronisation(m_oAgent)
        Dim lstSynchro As List(Of SynchronisationElmt)
        lstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        For Each oSynchoElmt As SynchronisationElmt In lstSynchro
            If oSynchoElmt.type = "GetDocument" Then
                Assert.IsFalse(String.IsNullOrEmpty(oSynchoElmt.valeurAuxiliaire))
                Debug.Print(oSynchoElmt.valeurAuxiliaire)
                oSynchoElmt.SynchroDesc(m_oAgent)
                If (Not oSynchoElmt.valeurAuxiliaire.ToUpper().Contains(".DLT")) Then
                    Assert.IsTrue(System.IO.File.Exists(MySettings.Default.ModuleDocumentaire & "/" & oSynchoElmt.identifiantChaine))
                End If
            Else
                Assert.IsTrue(String.IsNullOrEmpty(oSynchoElmt.valeurAuxiliaire))
            End If
        Next



    End Sub

    <TestMethod()>
    Public Sub testConfDiag()
        Dim lstSynchro As List(Of SynchronisationElmt)
        Dim oSynchro As New Synchronisation(m_oAgent)
        lstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        For Each oSynchoElmt As SynchronisationElmt In lstSynchro
            If oSynchoElmt.type = "GetDocument" Then
                Assert.IsFalse(String.IsNullOrEmpty(oSynchoElmt.valeurAuxiliaire))
                Assert.IsTrue(oSynchoElmt.SynchroDesc(m_oAgent))
                Debug.Print("ID = " & oSynchoElmt.identifiantChaine)
                Debug.Print("VA = " & oSynchoElmt.valeurAuxiliaire)
                Debug.Print("MD5 = " & oSynchoElmt.checksumMD5)
                Debug.Print("CHKCalc = " & oSynchoElmt.checksumCalc)
                If (Not oSynchoElmt.valeurAuxiliaire.ToUpper().Contains(".DLT")) Then
                    Assert.IsTrue(System.IO.File.Exists(MySettings.Default.ModuleDocumentaire & "/" & oSynchoElmt.identifiantChaine))
                End If
            Else
                Assert.IsTrue(String.IsNullOrEmpty(oSynchoElmt.valeurAuxiliaire))
            End If
        Next



    End Sub


    <TestMethod()>
    Public Sub testSynhcronisationExploitationToPulverisateur()
        Dim oExploit As Exploitation = createExploitation()
        Dim oPulve As Pulverisateur = createPulverisateur(oExploit)
        Dim UpdatedObject As Object = Nothing
        Dim oExploitToPulve As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oExploit.id, oPulve.id)
        Dim response As Integer

        response = ExploitationManager.sendWSExploitation(oExploit, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2, "Synhcro Ascendante Exploit NOK=>" & response)

        response = PulverisateurManager.sendWSPulverisateur(m_oAgent, oPulve)
        Assert.IsTrue(response = 0 Or response = 2, "Synhcro Ascendante Pulve NOK=>" & response)

        response = ExploitationTOPulverisateurManager.sendWSExploitationTOPulverisateur(oExploitToPulve, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2, "Synhcro Ascendante NOK=>" & response)

        Dim oExploitToPulve2 As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.getWSExploitationTOPulverisateurById(oExploitToPulve.id)

        Assert.IsTrue(ExploitationTOPulverisateurManager.save(oExploitToPulve2, m_oAgent, True))

    End Sub

    <TestMethod()>
    Public Sub testSynchroElemntModuleDocumentaire()
        Dim oSynchro As New Synchronisation(m_oAgent)
        Dim oElmt As New SynchroElementDocument(oSynchro.m_SynchroBoolean)
        Assert.AreEqual("GetDocument", oElmt.type)
        oElmt.identifiantChaine = "/_parametres/cr_RapportInspection.rpt"
        oElmt.identifiantEntier = 0
        oElmt.valeurAuxiliaire = "http://admin-pp.crodip.fr/depots/_parametres/cr_RapportInspection.rpt"
        If File.Exists("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt") Then
            File.Delete("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt")
        End If
        Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt"))
        Dim oFileInfo As New FileInfo("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt")
        Assert.IsTrue(oFileInfo.Length > 1000)

        oElmt = New SynchroElementDocument("/_parametres/REFERENTIEL_BUSE.csv", "http://admin-pp.crodip.fr/depots/_parametres/REFERENTIEL_BUSE.csv", oSynchro.m_SynchroBoolean)
        Assert.AreEqual("GetDocument", oElmt.type)
        If File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv") Then
            File.Delete("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        End If
        Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv"))
        oFileInfo = New FileInfo("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        Assert.IsTrue(oFileInfo.Length > 1000)


    End Sub
    <TestMethod()>
    Public Sub testSynchroElemntModuleDocumentaire_DLT()
        Dim oSynchro As New Synchronisation(m_oAgent)
        Dim oElmt As New SynchroElementDocument(oSynchro.m_SynchroBoolean)
        Assert.AreEqual("GetDocument", oElmt.type)
        oElmt.identifiantChaine = "/_parametres/cr_RapportInspection.rpt"
        oElmt.identifiantEntier = 0
        oElmt.valeurAuxiliaire = "http://admin-pp.crodip.fr/depots/_parametres/cr_RapportInspection.rpt"
        If File.Exists("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt") Then
            File.Delete("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt")
        End If
        Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt"))
        Dim oFileInfo As New FileInfo("ModuleDocumentaire/_parametres/cr_RapportInspection.rpt")
        Assert.IsTrue(oFileInfo.Length > 1000)

        oElmt = New SynchroElementDocument("/_parametres/REFERENTIEL_BUSE.csv", "http://admin-pp.crodip.fr/depots/_parametres/REFERENTIEL_BUSE.csv", oSynchro.m_SynchroBoolean)
        Assert.AreEqual("GetDocument", oElmt.type)
        If File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv") Then
            File.Delete("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        End If
        Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv"))
        oFileInfo = New FileInfo("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        Assert.IsTrue(oFileInfo.Length > 1000)

        oElmt = New SynchroElementDocument("/_parametres/REFERENTIEL_BUSE.csv.DLT", "http://admin-pp.crodip.fr/depots/_parametres/REFERENTIEL_BUSE.csv.DLT", oSynchro.m_SynchroBoolean)
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv"))
        oElmt.SynchroDesc(m_oAgent)
        Assert.IsFalse(File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv"))

        'Création d'un répertoire dans paramètres
        My.Computer.FileSystem.CreateDirectory("ModuleDocumentaire/_parametres/_reptemp")
        Dim oSW As StreamWriter = System.IO.File.CreateText("ModuleDocumentaire/_parametres/_reptemp/FileToTest.txt")
        oSW.WriteLine("test")
        oSW.Close()
        Assert.IsTrue(File.Exists("ModuleDocumentaire/_parametres/_reptemp/FileToTest.txt"))

        oElmt = New SynchroElementDocument("/_parametres/_reptemp.DLT/FileToTest.txt", "http://admin-pp.crodip.fr/depots/_parametres/_reptemp.DLT/FileToTest.txt", oSynchro.m_SynchroBoolean)
        Assert.IsTrue(Directory.Exists("ModuleDocumentaire/_parametres/_reptemp"))
        oElmt.SynchroDesc(m_oAgent)
        Assert.IsFalse(Directory.Exists("ModuleDocumentaire/_parametres/_reptemp"))

    End Sub
    <TestMethod()>
    Public Sub TestValeurAuxiliaire()
        'Suppression du fichier REFERENTIEL_BUSE.csv
        'If File.Exists("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv") Then
        ' File.Delete("ModuleDocumentaire/_parametres/REFERENTIEL_BUSE.csv")
        ' End If

        m_oAgent.dateDerniereSynchro = CSDate.GetDateForWS("1970/01/01")
        Dim oSynchro As New Synchronisation(m_oAgent)
        Dim lstSynchro As List(Of SynchronisationElmt)
        lstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        For Each oSynchoElmt As SynchronisationElmt In lstSynchro
            If oSynchoElmt.type = "GetDocument" Then
                Assert.IsFalse(String.IsNullOrEmpty(oSynchoElmt.valeurAuxiliaire))
                Assert.AreEqual("http://admin-pp", oSynchoElmt.valeurAuxiliaire.Substring(0, 15))
                CSDebug.dispInfo(oSynchoElmt.valeurAuxiliaire)
            End If
        Next
    End Sub
    Private Function createExploitant() As Exploitation
        Dim oExploit As Exploitation

        oExploit = New Exploitation()
        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

        ExploitationManager.save(oExploit, m_oAgent)
        Return oExploit
    End Function
    Private Function createPulverisateur(pExploit As Exploitation) As Pulverisateur
        Dim oPulve As Pulverisateur

        oPulve = New Pulverisateur()
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.marque = "MA MARQUE"
        oPulve.modele = "MON MODELE"
        oPulve.numeroNational = "E001456789"
        oPulve.capacite = 300
        oPulve.largeur = "12"
        oPulve.attelage = "3 POINTS"
        oPulve.anneeAchat = "1974"
        oPulve.type = "TYPE PULVE"
        oPulve.categorie = "Canon"
        oPulve.pulverisation = "Jet projeté"
        oPulve.buseType = "TYPEBUSE"
        oPulve.buseFonctionnement = "FCTBUSE"
        oPulve.buseMarque = "MarqueBuse"
        oPulve.buseModele = "ModeleBuse"
        oPulve.emplacementIdentification = "SUR LA FLECHE"
        oPulve.isCuveRincage = False
        oPulve.isLanceLavage = True
        oPulve.isRotobuse = True
        oPulve.isCuveIncorporation = False
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        PulverisateurManager.save(oPulve, pExploit.id, m_oAgent)
        Return oPulve
    End Function
    Private Function createDiag(pExploit As Exploitation, pPulve As Pulverisateur) As Diagnostic
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oDiagItem As DiagnosticItem

        oDiag = New Diagnostic(m_oAgent, pPulve, pExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = "2,5"

        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        CSFile.open(oEtat.getFileName())
        oDiag.id = DiagnosticManager.getNewId(m_oAgent)
        DiagnosticManager.save(oDiag)
        Return oDiag

    End Function
End Class
