Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatDocCoPropTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereDocCoPro()
        Dim oEtat As EtatDocumentCoPropriete
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        m_oStructure.nom = "MA STRUCTURE"
        StructureManager.save(m_oStructure)
        m_oAgent.nom = "AGENT_NOM"
        m_oAgent.nom = "AGENT_PRENOM"
        AgentManager.save(m_oAgent)
        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.nomExploitant = "Nom Exploitant"
        oExploit.prenomExploitant = "Prénom Exploitant"
        oExploit.numeroSiren = "123456"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"
        ExploitationManager.save(oExploit, m_oAgent)

        oPulve.marque = "MARQUE PULVE"
        oPulve.modele = "MODELE PULVE"
        oPulve.numeroNational = "E001456789"
        oPulve.capacite = 300
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV ' Défaut sur le pulvé
        'PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "Bouessay"
        oDiag.controleCodePostal = "35250"
        oDiag.controleCommune = "Chasné sur illet"

        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé



        oEtat = New EtatDocumentCoPropriete(oDiag)
        oEtat.AddCoProprietaire("EARL DES BOIS : Marc Collin")
        oEtat.AddCoProprietaire("GAEC DE FOURNAN : Marc-Antoine Rault")
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
End Class