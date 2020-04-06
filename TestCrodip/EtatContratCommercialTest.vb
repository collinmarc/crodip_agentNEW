Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatContratCommercialTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereContratCommercial()
        Dim oEtat As EtatContratCommercial
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        oPulve.type = "Arbres"
        oDiag = createDiagnostic(oExploit, oPulve)
        oDiag.controleIsComplet = False
        oDiag.inspecteurNom = "Collin"
        oDiag.inspecteurPrenom = "Marc"
        oDiag.proprietaireRepresentant = "Rault Marc Antoine"
        oDiag.TotalHT = 165.2D
        oDiag.TotalTVA = oDiag.TotalHT * 0.2D
        oDiag.TotalTTC = oDiag.TotalHT + oDiag.TotalTVA



        oEtat = New EtatContratCommercial(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())


    End Sub
    ''' <summary>
    ''' Ce test verifie la Synchro FTP du Rapport d'inspection et de l'état Synthèse des mesures
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestSynhcroFTP()
        Dim oEtat As EtatContratCommercial
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        m_oStructure.nom = "MA STRUCTURE"
        StructureManager.save(m_oStructure)
        m_oAgent.nom = "AGENT NOM"
        AgentManager.save(m_oAgent)
        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"
        ExploitationManager.save(oExploit, m_oAgent)
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
        '        oPulve.isDPAEDebit = True
        oPulve.buseType = "TYPEBUSE"
        oPulve.buseFonctionnement = "FCTBUSE"
        oPulve.buseMarque = "MarqueBuse"
        oPulve.buseModele = "ModeleBuse"
        oPulve.emplacementIdentification = "SUR LA FLECHE"
        oPulve.isCuveRincage = False
        oPulve.isLanceLavage = True
        oPulve.isRotobuse = True
        oPulve.isCuveIncorporation = False
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        'PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = "2,5"

        oDiag.syntheseErreurMoyenneManoD = 0.35D
        oDiag.syntheseErreurMoyenneCinemometreD = 0.36D
        oDiag.synthesePerteChargeMoyenneD = 0.37D
        oDiag.syntheseErreurMaxiManoD = 1.35D
        oDiag.syntheseUsureMoyenneBusesD = 1.36D
        oDiag.synthesePerteChargeMaxiD = 1.37D
        oDiag.syntheseErreurDebitmetreD = 0.38D
        oDiag.syntheseNbBusesUseesD = 1.38D

        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        DiagnosticManager.save(oDiag)
        oEtat = New EtatContratCommercial(oDiag)
        oEtat.GenereEtat()
        oDiag.CCFileName = oEtat.getFileName()
        'CSFile.open(CONST_PATH_EXP & oEtat.getFileName())
        Assert.IsTrue(File.Exists(Globals.CONST_PATH_EXP & "/" & oDiag.CCFileName))

        ''Synchronisation des etats
        Assert.IsTrue(DiagnosticManager.SendEtats(oDiag))

        'Suppression des etats générés en local
        File.Delete(Globals.CONST_PATH_EXP & "/" & oDiag.CCFileName)
        Assert.IsFalse(File.Exists(Globals.CONST_PATH_EXP & "/" & oDiag.CCFileName))

        'Récupération des fichiers par FTP
        Assert.IsTrue(DiagnosticManager.getFTPEtats(oDiag))
        Assert.IsTrue(File.Exists(Globals.CONST_PATH_EXP & "/" & oDiag.CCFileName))

    End Sub

End Class