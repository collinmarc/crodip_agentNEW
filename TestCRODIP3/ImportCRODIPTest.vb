Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent
Imports System.IO
Imports CsvHelper

'''<summary>
'''Classe de test pour PulverisateurManagerTest, destinée à contenir tous
'''les tests unitaires PulverisateurManagerTest
'''</summary>
<TestClass()>
Public Class ImportCRODIPTest
    Inherits CRODIPTest

    Public Class importCRODIPcolsinversée
        'Les Cols CodeAPE et numéroSIREN sont inversées
        'Les cols ControleEtat et dateProchaincontrole aussi
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property id As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property codeApe As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property numeroSiren As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property RAISONSOCIALE As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property nomexploitant As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property prenomExploitant As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property adresse As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property codePostal As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property commune As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property codeInsee As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property telephonePortable As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property telephoneFax As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.EXPLOITATION)>
        Public Property eMail As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property numeroNational As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property type As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property marque As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property modele As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property anneeAchat As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property attelage As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property capacite As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property largeur As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property nombrerangs As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property largeurPlantation As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property surfaceParAn As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property nombreUtilisateurs As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isVentilateur As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isDebrayage As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isCuveRincage As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property capaciteCuveRincage As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isRotobuse As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isCuveIncorporation As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isRinceBidon As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isBidonLaveMain As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isLanceLavage As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property nombreBuses As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseIsIso As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseMarque As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseType As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseFonctionnement As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseAge As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseAngle As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property manometreMarque As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property manometreType As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property manometreFondEchelle As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property manometreDiametre As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property manometrePressionTravail As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property emplacementIdentification As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property controleEtat As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property dateProchainControle As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property ancienIdentifiant As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isEclairageRampe As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isBarreGuidage As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isCoupureAutoTroncons As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isRincageAutoAssiste As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseModele As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseNbniveaux As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property manometreNbniveaux As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property manometreNbtroncons As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property buseCouleur As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property regulation As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property regulationOptions As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property modeUtilisation As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property nombreExploitants As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property categorie As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property pulverisation As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isAspirationExt As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isDispoAntiRetour As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isReglageAutoHauteur As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isFiltrationAspiration As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isFiltrationRefoulement As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isFiltrationTroncons As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isFiltrationBuses As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isPulveAdditionnel As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property pulvePrincipalNumNat As String

        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR)>
        Public Property isRincagecircuit As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR, "IsPompesDoseuses")>
        Public Property isPompesDoseuses As String
        <importCrodipAtt(importCrodipAtt.enumCRODIPClass.PULVERISATEUR, "nbPompesDoseuses")>
        Public Property nbPompesDoseuses As String
    End Class

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
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    '<TestCleanup()> _
    'Public Sub MyTestCleanup()
    'End Sub
#End Region


    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()>
    Public Sub TST_Object()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.nomExploitant = "TEST2"
        obj.numeroSiren = "789456123"
        obj.numeroNational = "E001002"
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)


        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(2, oResult.nClientimport)
        Assert.AreEqual(2, oResult.nPulveimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitapres, nExploitAvant + 2)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveApres, nPulveAvant + 2)

    End Sub

    <TestMethod()>
    Public Sub TST_ImportPulveSansNumNat()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.nomExploitant = "TEST2"
        obj.numeroSiren = "789456123"
        'obj.numeroNational = "E001002" 'Pas de numéro national pour le second Pulvé
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)


        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(2, oResult.nClientimport)
        Assert.AreEqual(1, oResult.nPulveimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitapres, nExploitAvant + 2)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveApres, nPulveAvant + 1)

    End Sub

    <TestMethod()>
    Public Sub TST_Import2Pulve1Client()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001002"
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)


        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(1, oResult.nClientimport)
        Assert.AreEqual(2, oResult.nPulveimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitapres, nExploitAvant + 1)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveApres, nPulveAvant + 2)

    End Sub

    <TestMethod()>
    Public Sub TST_OrdreCols()

        Dim obj As importCRODIPcolsinversée
        Dim olstin = New List(Of importCRODIPcolsinversée)

        obj = New importCRODIPcolsinversée()
        obj.NomExploitant = "TEST1"
        obj.codeApe = "AQWZS"
        obj.numeroSiren = "1235467"
        'Raisonsociale commence par une majuscule
        obj.RaisonSociale = "RS001"
        obj.numeroNational = "E001001"
        olstin.Add(obj)
        obj = New importCRODIPcolsinversée()
        obj.nomExploitant = "TEST2"
        obj.codeApe = "POIUY"
        obj.numeroSiren = "789456123"
        obj.numeroNational = "E001002"
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TESTcolInvers.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)


        End Using

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TESTcolInvers.CSV", m_oAgent)
        Assert.AreEqual(2, oResult.nClientimport)
        Dim olstExpl As List(Of Exploitation)
        olstExpl = ExploitationManager.searchExploitation(m_oAgent, 4, "TEST1")
        Dim oExploit As Exploitation
        oExploit = olstExpl(0)
        Assert.AreEqual("AQWZS", oExploit.codeApe)
        Assert.AreEqual("1235467", oExploit.numeroSiren)
        Assert.AreEqual("RS001", oExploit.raisonSociale)


    End Sub
    <TestMethod()>
    Public Sub TST_ImportDiag()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.raisonSociale = "TEST1"
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        obj.OrigineDiag = "GIP"
        obj.isATGIP = "VRAI"
        obj.isFacture = "VRAI"
        obj.controleIsComplet = "FAUX"
        obj.typeDiagnostic = "EQUIPEMENT"
        obj.telephoneFixe = "0201020304"
        obj.numChassis = "11111"
        obj.controleEtat = "0"
        obj.dateControle = "01/01/2020"
        'obj.dateProchainControle = "01/01/2025"
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.raisonSociale = "TEST2"
        obj.nomExploitant = "TEST2"
        obj.numeroSiren = "789456123"
        obj.numeroNational = "E001002"
        obj.OrigineDiag = "TST"
        obj.isATGIP = "FAUX"
        obj.isFacture = "FAUX"
        obj.controleIsComplet = "VRAI"
        obj.typeDiagnostic = "TEST"
        obj.telephoneFixe = "0301020304"
        obj.numchassis = "22222"
        obj.controleEtat = "1"
        obj.dateControle = "01/01/2021"
        'obj.dateProchainControle = "01/01/2026"
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)
        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Dim nDiagAvant As Integer = DiagnosticManager.getCount(m_oAgent)

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(2, oResult.nClientimport)
        Assert.AreEqual(2, oResult.nPulveimport)
        Assert.AreEqual(2, oResult.nDiagimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitAvant + 2, nExploitapres)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveAvant + 2, nPulveApres)

        Dim nDiagAPres As Integer = DiagnosticManager.getCount(m_oAgent)
        Assert.AreEqual(nDiagAvant + 2, nDiagAPres)
        Dim lstImport As List(Of Exploitation) = oResult.lstExploitationimport
        Dim nId As String
        Dim odiag As Diagnostic
        Dim oPulve As Pulverisateur

        nId = lstImport(0).lstDiagImport(0).id
        odiag = DiagnosticManager.getDiagnosticById(nId)
        Assert.AreEqual("TEST1", odiag.proprietaireNom)
        Assert.AreNotEqual("", odiag.proprietaireId)
        Assert.AreNotEqual("", odiag.pulverisateurId)
        Assert.AreEqual("E001001", odiag.pulverisateurNumNational)
        Assert.AreEqual(True, odiag.isATGIP)
        Assert.AreEqual(True, odiag.isFacture)
        Assert.AreEqual(False, odiag.controleIsComplet)
        Assert.AreEqual("EQUIPEMENT", odiag.typeDiagnostic)
        Assert.AreEqual("0201020304", odiag.proprietaireTelephoneFixe)
        Assert.AreEqual("GIP", odiag.origineDiag)
        Assert.AreEqual("0", odiag.controleEtat)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateDebut)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateDebutS)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateFin)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateFinS)

        nId = lstImport(0).lstPulveImport(0).id
        oPulve = PulverisateurManager.getPulverisateurById(nId)
        Assert.AreEqual("E001001", oPulve.numeroNational)
        Assert.AreEqual("11111", oPulve.numChassis)
        Assert.AreEqual("01/05/2020", oPulve.dateProchainControleAsDate.Value.ToShortDateString())

        nId = lstImport(1).lstDiagImport(0).id
        odiag = DiagnosticManager.getDiagnosticById(nId)
        Assert.AreNotEqual("", odiag.proprietaireId)
        Assert.AreNotEqual("", odiag.pulverisateurId)
        Assert.AreEqual("TEST2", odiag.proprietaireNom)
        Assert.AreEqual("E001002", odiag.pulverisateurNumNational)
        Assert.AreEqual(False, odiag.isATGIP)
        Assert.AreEqual(True, odiag.isFacture)
        Assert.AreEqual(True, odiag.controleIsComplet)
        Assert.AreEqual("TEST", odiag.typeDiagnostic)
        Assert.AreEqual("0301020304", odiag.proprietaireTelephoneFixe)
        Assert.AreEqual("TST", odiag.origineDiag)
        Assert.AreEqual("1", odiag.controleEtat)
        Assert.AreEqual("2021-01-01 00:00:00", odiag.controleDateDebut)
        Assert.AreEqual("2021-01-01 00:00:00", odiag.controleDateDebutS)
        Assert.AreEqual("2021-01-01 00:00:00", odiag.controleDateFin)
        Assert.AreEqual("2021-01-01 00:00:00", odiag.controleDateFinS)

        nId = lstImport(1).lstPulveImport(0).id
        oPulve = PulverisateurManager.getPulverisateurById(nId)
        Assert.AreEqual("E001002", oPulve.numeroNational)
        Assert.AreEqual("22222", oPulve.numChassis)
        Assert.AreEqual("2024-01-01 00:00:00", oPulve.dateProchainControle)


    End Sub


    <TestMethod()>
    Public Sub TST_ImportDiagCalcDateProchaincontrole()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.raisonSociale = "TEST1"
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        obj.OrigineDiag = "GIP"
        obj.isATGIP = "VRAI"
        obj.isFacture = "VRAI"
        obj.controleIsComplet = "FAUX"
        obj.typeDiagnostic = "EQUIPEMENT"
        obj.telephoneFixe = "0201020304"
        obj.numChassis = "11111"
        obj.controleEtat = "0" ' PULVE EN ATTENTE DE CV
        obj.dateControle = "01/01/2020" ' => Date prochain controle = Ajourjourdhui 
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.raisonSociale = "TEST2"
        obj.nomExploitant = "TEST2"
        obj.numeroSiren = "789456123"
        obj.numeroNational = "E001002"
        obj.OrigineDiag = "TST"
        obj.isATGIP = "FAUX"
        obj.isFacture = "FAUX"
        obj.controleIsComplet = "VRAI"
        obj.typeDiagnostic = "TEST"
        obj.telephoneFixe = "0301020304"
        obj.numChassis = "22222"
        obj.controleEtat = "1"   ' CONTROLE OK
        obj.dateControle = "01/01/2020" '=> Date de Prochain controle = 01/01/2025
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)
        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Dim nDiagAvant As Integer = DiagnosticManager.getCount(m_oAgent)

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(2, oResult.nClientimport)
        Assert.AreEqual(2, oResult.nPulveimport)
        Assert.AreEqual(2, oResult.nDiagimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitAvant + 2, nExploitapres)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveAvant + 2, nPulveApres)

        Dim nDiagAPres As Integer = DiagnosticManager.getCount(m_oAgent)
        Assert.AreEqual(nDiagAvant + 2, nDiagAPres)
        Dim lstImport As List(Of Exploitation) = oResult.lstExploitationimport
        Dim nId As String
        Dim odiag As Diagnostic
        Dim oPulve As Pulverisateur

        nId = lstImport(0).lstDiagImport(0).id
        odiag = DiagnosticManager.getDiagnosticById(nId)
        Assert.AreEqual("TEST1", odiag.proprietaireNom)
        Assert.AreNotEqual("", odiag.proprietaireId)
        Assert.AreNotEqual("", odiag.pulverisateurId)
        Assert.AreEqual("E001001", odiag.pulverisateurNumNational)
        Assert.AreEqual(True, odiag.isATGIP)
        Assert.AreEqual(True, odiag.isFacture)
        Assert.AreEqual(False, odiag.controleIsComplet)
        Assert.AreEqual("EQUIPEMENT", odiag.typeDiagnostic)
        Assert.AreEqual("0201020304", odiag.proprietaireTelephoneFixe)
        Assert.AreEqual("GIP", odiag.origineDiag)
        Assert.AreEqual("0", odiag.controleEtat)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateDebut)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateDebutS)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateFin)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateFinS)

        nId = lstImport(0).lstPulveImport(0).id
        oPulve = PulverisateurManager.getPulverisateurById(nId)
        Assert.AreEqual("E001001", oPulve.numeroNational)
        Assert.AreEqual("11111", oPulve.numChassis)
        Assert.AreEqual("01/05/2020", oPulve.dateProchainControleAsDate.Value.ToShortDateString())

        nId = lstImport(1).lstDiagImport(0).id
        odiag = DiagnosticManager.getDiagnosticById(nId)
        Assert.AreNotEqual("", odiag.proprietaireId)
        Assert.AreNotEqual("", odiag.pulverisateurId)
        Assert.AreEqual("TEST2", odiag.proprietaireNom)
        Assert.AreEqual("E001002", odiag.pulverisateurNumNational)
        Assert.AreEqual(False, odiag.isATGIP)
        Assert.AreEqual(True, odiag.isFacture) ' Les controle Sont marqué automatiquement à Facturé
        Assert.AreEqual(True, odiag.controleIsComplet)
        Assert.AreEqual("TEST", odiag.typeDiagnostic)
        Assert.AreEqual("0301020304", odiag.proprietaireTelephoneFixe)
        Assert.AreEqual("TST", odiag.origineDiag)
        Assert.AreEqual("1", odiag.controleEtat)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateDebut)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateDebutS)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateFin)
        Assert.AreEqual("2020-01-01 00:00:00", odiag.controleDateFinS)

        nId = lstImport(1).lstPulveImport(0).id
        oPulve = PulverisateurManager.getPulverisateurById(nId)
        Assert.AreEqual("E001002", oPulve.numeroNational)
        Assert.AreEqual("22222", oPulve.numChassis)
        Assert.AreEqual("2023-01-01 00:00:00", oPulve.dateProchainControle)


    End Sub
    <TestMethod()>
    Public Sub TST_ImportPulveNbreRang()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        obj.type = "Vigne"
        obj.categorie = "Voute"
        obj.nombrerangs = "3"
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.nomExploitant = "TEST2"
        obj.numeroSiren = "789456123"
        obj.numeroNational = "E001002"
        obj.type = "Arbres"
        obj.categorie = "Jet dirigé"
        obj.nombrerangs = "4"
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV", False, System.Text.Encoding.UTF8)
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)
        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(2, oResult.nClientimport)
        Assert.AreEqual(2, oResult.nPulveimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitapres, nExploitAvant + 2)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveApres, nPulveAvant + 2)
        Dim lstImport As List(Of Exploitation) = oResult.lstExploitationimport
        Dim nId As String
        Dim oPulve As Pulverisateur
        nId = lstImport(0).lstPulveImport(0).id
        oPulve = PulverisateurManager.getPulverisateurById(nId)
        Assert.AreEqual("E001001", oPulve.numeroNational)
        Assert.AreEqual("3", oPulve.nombreRangs)

        nId = lstImport(1).lstPulveImport(0).id
        oPulve = PulverisateurManager.getPulverisateurById(nId)
        Assert.AreEqual("E001002", oPulve.numeroNational)
        Assert.AreEqual("Arbres", oPulve.type)
        Assert.AreEqual("Jet dirigé", oPulve.categorie)
        Assert.AreEqual("4", oPulve.nombreRangs)

    End Sub
End Class
