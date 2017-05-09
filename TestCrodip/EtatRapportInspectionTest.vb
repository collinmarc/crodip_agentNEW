Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatRapportInspectionTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereEtatCV1P()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV ' Défaut sur le pulvé
        'PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé
        'Assert.AreEqual(CSDate.ToCRODIPString("06/02/1964"), oDiag.CalculDateProchainControle)
        Assert.AreEqual(CSDate.ToCRODIPString(Date.Now().AddMonths(4)), oDiag.CalculDateProchainControle)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libellé est sur plusieurs lignes et tout doit apparaoitre même ces dernièrs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "3", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "4", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "5", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "6", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "7", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "8", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "9", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "257", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub

    <TestMethod()> Public Sub TestGenereEtatComplet1P()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        'PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = True 'Controle Complet
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"

        For i As Integer = 0 To 20
            oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
            oDiagItem.LibelleCourt = "LIBCourt2561"
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561"
            oDiag.AddDiagItem(oDiagItem)

        Next
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "3", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "4", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "5", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "6", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "7", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "8", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "9", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)

        oDiagItem = New DiagnosticItem(oDiag.id, "257", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub

    <TestMethod()> Public Sub TestGenereEtat2P()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.marque = "MA MARQUE"
        oPulve.modele = "MON MODELE"
        oPulve.numeroNational = "E001456789"
        oPulve.capacite = 300
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
        oPulve.attelage = "3 POINTS"
        oPulve.anneeAchat = "1974"
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV ' Défaut sur le pulvé
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5

        For i As Integer = 0 To 25
            oDiagItem = New DiagnosticItem(oDiag.id, "257", i, "2", "O")
            oDiagItem.LibelleCourt = "LIBCourt257" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 257" & i
            oDiag.AddDiagItem(oDiagItem)

        Next
        For i As Integer = 0 To 25
            oDiagItem = New DiagnosticItem(oDiag.id, "256", i, "2", "P")
            oDiagItem.LibelleCourt = "LIBCourt256" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 256" & i
            oDiag.AddDiagItem(oDiagItem)

        Next
        oDiag.syntheseErreurMoyenneManoD = 0.35
        oDiag.syntheseErreurMoyenneCinemometreD = 0.36
        oDiag.synthesePerteChargeMoyenneD = 0.37
        oDiag.syntheseErreurMaxiManoD = 1.35
        oDiag.syntheseUsureMoyenneBusesD = 1.36
        oDiag.synthesePerteChargeMaxiD = 1.37
        oDiag.syntheseErreurDebitmetreD = 0.38
        oDiag.syntheseNbBusesUseesD = 1.38

        oDiag.controleEtat = Diagnostic.controleEtatNOKCV

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
    <TestMethod()> Public Sub TestGenereEtat3P()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.marque = "MA MARQUE"
        oPulve.modele = "MON MODELE"
        oPulve.numeroNational = "E001456789"
        oPulve.capacite = 300
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
        oPulve.attelage = "3 POINTS"
        oPulve.anneeAchat = "1974"
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV ' Défaut sur le pulvé
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5

        For i As Integer = 0 To 60
            oDiagItem = New DiagnosticItem(oDiag.id, "257", i, "2", "O")
            oDiagItem.LibelleCourt = "LIBCourt257" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 257" & i
            oDiag.AddDiagItem(oDiagItem)

        Next
        For i As Integer = 0 To 60
            oDiagItem = New DiagnosticItem(oDiag.id, "256", i, "2", "P")
            oDiagItem.LibelleCourt = "LIBCourt256" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 256" & i
            oDiag.AddDiagItem(oDiagItem)

        Next
        oDiag.syntheseErreurMoyenneManoD = 0.35
        oDiag.syntheseErreurMoyenneCinemometreD = 0.36
        oDiag.synthesePerteChargeMoyenneD = 0.37
        oDiag.syntheseErreurMaxiManoD = 1.35
        oDiag.syntheseUsureMoyenneBusesD = 1.36
        oDiag.synthesePerteChargeMaxiD = 1.37
        oDiag.syntheseErreurDebitmetreD = 0.38
        oDiag.syntheseNbBusesUseesD = 1.38

        oDiag.controleEtat = Diagnostic.controleEtatNOKCV

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
    <TestMethod()> Public Sub TestGenereEtatSansDiagItem()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        'PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5

        oDiag.syntheseErreurMoyenneManoD = 0.35
        oDiag.syntheseErreurMoyenneCinemometreD = 0.36
        oDiag.synthesePerteChargeMoyenneD = 0.37
        oDiag.syntheseErreurMaxiManoD = 1.35
        oDiag.syntheseUsureMoyenneBusesD = 1.36
        oDiag.synthesePerteChargeMaxiD = 1.37
        oDiag.syntheseErreurDebitmetreD = 0.38
        oDiag.syntheseNbBusesUseesD = 1.38

        oDiag.controleEtat = Diagnostic.controleEtatNOKCC

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
    <TestMethod()> Public Sub TestBG2Pages()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        'PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"

        For i As Integer = 0 To 21
            oDiagItem = New DiagnosticItem(oDiag.id, "256", i, "2", "O")
            oDiagItem.LibelleCourt = "LIBCourt2561"
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561"
            oDiag.AddDiagItem(oDiagItem)

        Next

        oEtat = New EtatRapportInspection(oDiag)
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
        Dim oEtat As EtatRapportInspection
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
        oDiag.buseDebitD = 2.5

        oDiag.syntheseErreurMoyenneManoD = 0.35
        oDiag.syntheseErreurMoyenneCinemometreD = 0.36
        oDiag.synthesePerteChargeMoyenneD = 0.37
        oDiag.syntheseErreurMaxiManoD = 1.35
        oDiag.syntheseUsureMoyenneBusesD = 1.36
        oDiag.synthesePerteChargeMaxiD = 1.37
        oDiag.syntheseErreurDebitmetreD = 0.38
        oDiag.syntheseNbBusesUseesD = 1.38

        oDiag.controleEtat = Diagnostic.controleEtatNOKCC
        DiagnosticManager.save(oDiag)
        oEtat = New EtatRapportInspection(oDiag)
        oEtat.GenereEtat()
        oDiag.RIFileName = oEtat.getFileName()
        'CSFile.open(CONST_PATH_EXP & oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & "/" & oDiag.RIFileName))

        Dim oEtatSM As New EtatSyntheseMesures(oDiag)
        oEtatSM.GenereEtat()
        oDiag.SMFileName = oEtat.getFileName()
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & "/" & oDiag.SMFileName))

        oDiag.SMFileName = oEtatSM.getFileName()
        DiagnosticManager.save(oDiag)

        ''Synchronisation des etats
        Assert.IsTrue(DiagnosticManager.SendFTPEtats(oDiag))

        'Suppression des etats générés en local
        File.delete(CONST_PATH_EXP & "/" & oDiag.RIFileName)
        File.Delete(CONST_PATH_EXP & "/" & oDiag.SMFileName)
        Assert.IsFalse(File.Exists(CONST_PATH_EXP & "/" & oDiag.RIFileName))
        Assert.IsFalse(File.Exists(CONST_PATH_EXP & "/" & oDiag.SMFileName))

        'Récupération des fichiers par FTP
        Assert.IsTrue(DiagnosticManager.getFTPEtats(oDiag))
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & "/" & oDiag.RIFileName))
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & "/" & oDiag.SMFileName))

    End Sub
    <TestMethod()> Public Sub TestOrdredesDiagItems()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        'PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = True 'Controle Complet
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"

        oDiagItem = New DiagnosticItem(oDiag.id, "1012", "1", "", "O")
        oDiagItem.LibelleCourt = "LIBCourt10121"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 10121"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "911", "1", "", "O")
        oDiagItem.LibelleCourt = "LIBCourt9111"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 9111"
        oDiag.AddDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
    <TestMethod()> Public Sub TestGenereEtatRSExploitantavecSimplequote()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        m_oStructure.nom = "MA STRUCTURE"
        StructureManager.save(m_oStructure)
        m_oAgent.nom = "AGENT NOM"
        AgentManager.save(m_oAgent)
        oExploit.raisonSociale = "RS 'EXPL/OIT\ANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM 'EXPL/OIT\ANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"
        ExploitationManager.save(oExploit, m_oAgent)

        oPulve.marque = "MA MARQUE"
        oPulve.modele = "MON MODELE"
        oPulve.numeroNational = "E001456789"
        oPulve.capacite = 300
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV ' Défaut sur le pulvé
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.idStructure = m_oAgent.idStructure

        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé
        'Assert.AreEqual(CSDate.ToCRODIPString("06/02/1964"), oDiag.CalculDateProchainControle)
        Assert.AreEqual(CSDate.ToCRODIPString(Date.Now().AddMonths(4)), oDiag.CalculDateProchainControle)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libellé est sur plusieurs lignes et tout doit apparaoitre même ces dernièrs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "3", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "4", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "5", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "6", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "7", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "8", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "9", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "257", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsFalse(oEtat.getFileName().Contains("'"))
        Assert.IsFalse(oEtat.getFileName().Contains("/"))
        Assert.IsFalse(oEtat.getFileName().Contains("\"))
        Assert.IsTrue(oEtat.getFileName().Contains("RS_EXPLOITANT"))
    End Sub

    <TestMethod()> Public Sub TestGenereEtatPulveAdditionel()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oPulvePrinc As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem


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

        oPulvePrinc = New Pulverisateur()
        oPulvePrinc.isPulveAdditionnel = False
        oPulvePrinc.numeroNational = "E999999999"
        oPulvePrinc.id = PulverisateurManager.getNewId(m_oAgent)
        oPulvePrinc.idStructure = m_oAgent.idStructure
        oPulvePrinc.attelage = "PORTE"
        oPulvePrinc.type = "Cultures basses"
        oPulvePrinc.categorie = "Rampe"
        oPulvePrinc.capacite = "350"
        oPulvePrinc.marque = "vicon"
        oPulvePrinc.modele = "VRT520"
        oPulvePrinc.emplacementIdentification = "ARRIERE"
        PulverisateurManager.save(oPulvePrinc, oExploit.id, m_oAgent)

        oPulve = New Pulverisateur()
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.isPulveAdditionnel = True
        oPulve.pulvePrincipalNumNat = oPulvePrinc.numeroNational

        oPulve.marque = "MA MARQUE"
        oPulve.modele = "MON MODELE"
        oPulve.numeroNational = "E001456789"
        oPulve.capacite = 300
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV ' Défaut sur le pulvé
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.idStructure = m_oAgent.idStructure

        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé
        'Assert.AreEqual(CSDate.ToCRODIPString("06/02/1964"), oDiag.CalculDateProchainControle)
        Assert.AreEqual(CSDate.ToCRODIPString(Date.Now().AddMonths(4)), oDiag.CalculDateProchainControle)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libellé est sur plusieurs lignes et tout doit apparaoitre même ces dernièrs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "3", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "4", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "5", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)


        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
    <TestMethod()> Public Sub TestGenereEtatDefautAbsence()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV ' Défaut sur le pulvé
        'PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé
        'Assert.AreEqual(CSDate.ToCRODIPString("06/02/1964"), oDiag.CalculDateProchainControle)
        Assert.AreEqual(CSDate.ToCRODIPString(Date.Now().AddMonths(4)), oDiag.CalculDateProchainControle)

        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libellé est sur plusieurs lignes et tout doit apparaoitre même ces dernièrs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "3", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "4", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "5", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "6", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "7", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "8", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        'Les Diag Item sont de type Absence il ne doivent pas apparaitre sur l'etat
        oDiagItem = New DiagnosticItem(oDiag.id, "811", "9", "1", DiagnosticItem.EtatDiagItemABSENCE)
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est un Defaut d'absence"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "8112", "2", "1", DiagnosticItem.EtatDiagItemABSENCE)
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est un Defaut d'absence"
        oDiag.AddDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
    ''' <summary>
    ''' Rest du rapport d'inspection en remlissant tous les accessoires
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestGenereEtatComplet1PAccesoires()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)

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
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        oPulve.isEclairageRampe = True
        oPulve.isBarreGuidage = True
        oPulve.isCoupureAutoTroncons = True
        oPulve.isRincageAutoAssiste = True
        oPulve.isAspirationExt = True
        oPulve.isDispoAntiRetour = True
        oPulve.isReglageAutoHauteur = True
        oPulve.isFiltrationAspiration = True
        oPulve.isFiltrationRefoulement = True
        oPulve.isFiltrationTroncons = True
        oPulve.isFiltrationBuses = True
        oPulve.isRincagecircuit = True

        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = True 'Controle Complet
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"

        For i As Integer = 0 To 20
            oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
            oDiagItem.LibelleCourt = "LIBCourt2561"
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561"
            oDiag.AddDiagItem(oDiagItem)

        Next
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "3", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "4", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "5", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "6", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "7", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "8", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "9", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)

        oDiagItem = New DiagnosticItem(oDiag.id, "257", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
    <TestMethod()> Public Sub TestGenereRIFin()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

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
        oPulve.id = PulverisateurManager.getNewId(m_oAgent)
        oPulve.idStructure = m_oAgent.idStructure
        oPulve.marque = "MA MARQUE"
        oPulve.modele = "MON MODELE"
        oPulve.numeroNational = "E001456789"
        oPulve.capacite = 300
        oPulve.setLargeurNbreRangs("5.5")
        oPulve.largeurPlantation = "12"
        oPulve.attelage = "3 POINTS"
        oPulve.anneeAchat = "1974"
        oPulve.type = Pulverisateur.TYPEPULVE_CULTURESBASSES
        oPulve.categorie = Pulverisateur.CATEGORIEPULVE_RAMPE
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
        oPulve.regulation = "DPM"
        oPulve.regulationOptions = "Opt1|Opt2"
        oPulve.dateProchainControle = CSDate.ToCRODIPString("06/02/1964")
        oPulve.controleEtat = Pulverisateur.controleEtatNOKCV ' Défaut sur le pulvé
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libellé est sur plusieurs lignes et tout doit apparaoitre même ces dernièrs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "3", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "4", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "5", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "6", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "7", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "8", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "9", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "257", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562"
        oDiag.AddDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat())
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub

End Class