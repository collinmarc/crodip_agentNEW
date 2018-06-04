Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

#If REGLAGEPULVE Then
<TestClass()> Public Class EtatReglagePulveTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestEntete()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)
        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.bSectionEntete = True
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        '        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)
        Assert.AreEqual(ods.Proprietaire.Rows.Count, 1)
        Assert.AreEqual(ods.Materiel.Rows.Count, 1)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())

        'Sans l'entete
        pause(1000)
        oDiag.bSectionEntete = False
        oEtat.GenereEtat()
        oEtat.Open()


    End Sub

    <TestMethod()> Public Sub TestDefault()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)


        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.bSectionEntete = True
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"
        oDiag.bSectionDefauts = True

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)
        '       Assert.AreEqual(ods.Diagitem.Rows.Count, 12)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & oEtat.getFileName()), "Fichier Inexistant")

        oEtat.Open()

        'Suppression de la Section
        pause(1000)

        oDiag.bSectionDefauts = False
        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        oEtat.Open()



    End Sub

    <TestMethod()> Public Sub TestSyntheseMesures()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As RPDiagItem

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)

        For i As Integer = 0 To 5
            oDiagItem = New RPDiagItem(oDiag.id, "257", i, "2", "O")
            oDiagItem.LibelleCourt = "LIBCourt257" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 257" & i
            oDiag.AddDiagItem(oDiagItem)

        Next
        For i As Integer = 0 To 5
            oDiagItem = New RPDiagItem(oDiag.id, "256", i, "2", "P")
            oDiagItem.LibelleCourt = "LIBCourt256" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 256" & i
            oDiag.AddDiagItem(oDiagItem)

        Next


        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.bSectionEntete = True
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"
        oDiag.bSectionDefauts = True
        oDiag.bSectionSyntheseMesures = True

        FillSyntheseMesures(oDiag)

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)
        '       Assert.AreEqual(ods.Diagitem.Rows.Count, 12)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & oEtat.getFileName()), "Fichier Inexistant")

        oEtat.Open()

        'Suppression de la Section
        pause(1000)

        oDiag.bSectionSyntheseMesures = False
        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        oEtat.Open()
    End Sub

    ''' <summary>
    ''' Test de l'affichage des ligne du rapport (Min et Max en fonction de l'écart Tolere
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestSynthesedesBusesEcartTolere1015()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As RPDiagItem

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)

        For i As Integer = 0 To 5
            oDiagItem = New RPDiagItem(oDiag.id, "257", i, "2", "O")
            oDiagItem.LibelleCourt = "LIBCourt257" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 257" & i
            oDiag.AddDiagItem(oDiagItem)

        Next
        For i As Integer = 0 To 5
            oDiagItem = New RPDiagItem(oDiag.id, "256", i, "2", "P")
            oDiagItem.LibelleCourt = "LIBCourt256" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 256" & i
            oDiag.AddDiagItem(oDiagItem)

        Next


        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.bSectionEntete = True
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"
        oDiag.bSectionDefauts = True
        oDiag.bSectionSyntheseMesures = True

        FillBuses(oDiag)
        oDiag.diagnosticBusesList.Liste(0).ecartTolere = 10
        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)
        Assert.AreEqual(ods.debitBuses.Rows.Count, 4)
        Assert.AreEqual(ods.debitBuses_infos.Rows.Count, 1)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & oEtat.getFileName()), "Fichier Inexistant")

        'Vérifier que la Ligne Max et Min soit bien sur le 10 
        oEtat.Open()

        pause(2000)

        oDiag.diagnosticBusesList.Liste(0).ecartTolere = 15
        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        'Vérifier que la Ligne Max et Min soit bien sur le 15 
        oEtat.Open()
    End Sub

    ''' <summary>
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestSynthese833()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As RPDiagItem

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)



        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"

        Fill833(oDiag)

        oDiag.bSectionEntete = False
        oDiag.bSectionDefauts = False
        oDiag.bSectionSyntheseMesures = False
        oDiag.bSectionSyntheseMesures = False
        oDiag.bSectionSyntheseBuses = False

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)

        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & oEtat.getFileName()), "Fichier Inexistant")

        oEtat.Open()

        pause(2000)

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        'Vérifier que la Ligne Max et Min soit bien sur le 15 
        oEtat.Open()
    End Sub
    <TestMethod()> Public Sub TestSynthese542()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As RPDiagItem

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)



        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"

        Fill542(oDiag)

        oDiag.bSectionEntete = False
        oDiag.bSectionDefauts = False
        oDiag.bSectionSyntheseMesures = False
        oDiag.bSectionSyntheseBuses = False
        oDiag.bSectionSynthese833 = False

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)

        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & oEtat.getFileName()), "Fichier Inexistant")

        oEtat.Open()

    End Sub
    <TestMethod()> Public Sub TestSyntheseCapteurVitesse()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As RPDiagItem

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)



        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"

        FillCapteurVitesse(oDiag)

        oDiag.bSectionEntete = False
        oDiag.bSectionDefauts = False
        oDiag.bSectionSyntheseMesures = False
        oDiag.bSectionSyntheseBuses = False
        oDiag.bSectionSynthese833 = False
        oDiag.bSectionSyntheseCapteurVitesse = True

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)

        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & oEtat.getFileName()), "Fichier Inexistant")

        oEtat.Open()

        'Test de suppression de la section
        oDiag.bSectionSyntheseCapteurVitesse = False
        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        oEtat.Open()

    End Sub
    <TestMethod()> Public Sub TestSyntheseCapteurDebit()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As RPDiagItem

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)



        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"

        fillCapteurDebitmetre(oDiag)


        oDiag.bSectionEntete = False
        oDiag.bSectionDefauts = False
        oDiag.bSectionSyntheseMesures = False
        oDiag.bSectionSyntheseBuses = False
        oDiag.bSectionSynthese833 = False
        oDiag.bSectionSyntheseCapteurVitesse = False
        oDiag.bSectionSyntheseCapteurDebit = True

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)

        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & oEtat.getFileName()), "Fichier Inexistant")

        oEtat.Open()

        'Test de suppression de la section
        oDiag.bSectionSyntheseCapteurDebit = False
        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        oEtat.Open()

    End Sub
    <TestMethod()> Public Sub TestComplet()
        Dim oEtat As EtatReglagePulve
        Dim oDiag As RPDiagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As RPDiagItem

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()

        oExploit.raisonSociale = "RS EXPLOITANT"
        oExploit.numeroSiren = "123456"
        oExploit.nomExploitant = "NOM EXPLOITANT"
        oExploit.adresse = "23, la mettrie"
        oExploit.codePostal = "35250"
        oExploit.commune = "Chasné sur illet"
        oExploit.codeApe = "987"

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
        oPulve.controleEtat = "0" ' Défaut sur le pulvé

        oDiag = New RPDiagnostic()
        oDiag.id = "1-1-1"
        oDiag.SetProprietaire(oExploit)
        oDiag.setPulverisateur(oPulve)



        oDiag.Commentaires = "Ceci est le commentaire de l'état Pulvé"
        oDiag.Reference = "Marc Collin" & vbCrLf & "23 la mettrie" & vbCrLf & "Chasné sur illet"
        oDiag.imagePath = "ImageDeFond.jpg"

        FillDiagItems(oDiag)
        FillSyntheseMesures(oDiag)
        FillBuses(oDiag)
        Fill833(oDiag)
        Fill542(oDiag)
        fillCapteurDebitmetre(oDiag)
        FillCapteurVitesse(oDiag)


        oDiag.bSectionEntete = True
        oDiag.bSectionDefauts = True
        oDiag.bSectionSyntheseMesures = True
        oDiag.bSectionSyntheseBuses = True
        oDiag.bSectionSynthese833 = True
        oDiag.bSectionSyntheseCapteurVitesse = True
        oDiag.bSectionSyntheseCapteurDebit = True

        oEtat = New EtatReglagePulve(oDiag)
        oEtat.GenereEtat()
        Dim ods As ds_Etat_ReglagePulve
        ods = DirectCast(oEtat.getDs(), ds_Etat_ReglagePulve)
        Assert.IsNotNull(ods)
        Assert.AreEqual(ods.EtatReglagePulve.Rows.Count, 1)
        Assert.AreEqual(ods.Diagnostic.Rows.Count, 1)

        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(CONST_PATH_EXP & oEtat.getFileName()), "Fichier Inexistant")

        oEtat.Open()


    End Sub

    Private Sub FillCapteurVitesse(oDiag As RPDiagnostic)
        'Capteur de vitesse 551
        oDiag.diagnosticHelp551 = New DiagnosticHelp551()
        oDiag.diagnosticHelp551.Distance1 = 100
        oDiag.diagnosticHelp551.VitesseLue1 = 110
        oDiag.diagnosticHelp551.Temps1 = 120
        oDiag.diagnosticHelp551.Ecart1 = 130
        oDiag.diagnosticHelp551.VitesseReelle1 = 140
        oDiag.diagnosticHelp551.Distance2 = 200
        oDiag.diagnosticHelp551.VitesseLue2 = 210
        oDiag.diagnosticHelp551.Temps2 = 220
        oDiag.diagnosticHelp551.Ecart2 = 230
        oDiag.diagnosticHelp551.VitesseReelle2 = 240
        'oDiag.diagnosticHelp551.ErreurMoyenne = 250
        oDiag.diagnosticHelp551.Resultat = "IMPRECISION"

        'Capteur de vitesse 5621
        oDiag.diagnosticHelp5621 = New DiagnosticHelp5621()
        oDiag.diagnosticHelp5621.Distance1 = 1000
        oDiag.diagnosticHelp5621.VitesseLue1 = 1100
        oDiag.diagnosticHelp5621.Temps1 = 1200
        oDiag.diagnosticHelp5621.Ecart1 = 1300
        oDiag.diagnosticHelp5621.VitesseReelle1 = 1400
        oDiag.diagnosticHelp5621.Distance2 = 2000
        oDiag.diagnosticHelp5621.VitesseLue2 = 2100
        oDiag.diagnosticHelp5621.Temps2 = 2200
        oDiag.diagnosticHelp5621.Ecart2 = 2300
        oDiag.diagnosticHelp5621.VitesseReelle2 = 2400
        'oDiag.diagnosticHelp5621.ErreurMoyenne = 2500
        oDiag.diagnosticHelp5621.Resultat = "OK"

    End Sub

    Private Sub fillCapteurDebitmetre(oDiag As RPDiagnostic)
        'Controle du DébitMetre (552
        oDiag.diagnosticHelp552.NbBuses_m1 = 1
        oDiag.diagnosticHelp552.NbBuses_m2 = 2
        oDiag.diagnosticHelp552.NbBuses_m3 = 3
        oDiag.diagnosticHelp552.Pression_m1 = 10
        oDiag.diagnosticHelp552.Pression_m2 = 20
        oDiag.diagnosticHelp552.Pression_m3 = 30
        oDiag.diagnosticHelp552.DebitEtalon_m1 = 40
        oDiag.diagnosticHelp552.DebitEtalon_m2 = 50
        oDiag.diagnosticHelp552.DebitEtalon_m3 = 60
        oDiag.diagnosticHelp552.DebitAfficheur_m1 = 70
        oDiag.diagnosticHelp552.DebitAfficheur_m2 = 80
        oDiag.diagnosticHelp552.DebitAfficheur_m3 = 90
        oDiag.diagnosticHelp552.EcartPct_m1 = 5.5
        oDiag.diagnosticHelp552.EcartPct_m2 = 6.5
        oDiag.diagnosticHelp552.EcartPct_m3 = 7.5
        oDiag.diagnosticHelp552.ErreurDebitMetre = 10.5
        oDiag.diagnosticHelp552.Resultat = "OK"

        oDiag.diagnosticHelp5622.NbBuses_m1 = 10
        oDiag.diagnosticHelp5622.NbBuses_m2 = 20
        oDiag.diagnosticHelp5622.NbBuses_m3 = 30
        oDiag.diagnosticHelp5622.Pression_m1 = 100
        oDiag.diagnosticHelp5622.Pression_m2 = 200
        oDiag.diagnosticHelp5622.Pression_m3 = 300
        oDiag.diagnosticHelp5622.DebitEtalon_m1 = 400
        oDiag.diagnosticHelp5622.DebitEtalon_m2 = 500
        oDiag.diagnosticHelp5622.DebitEtalon_m3 = 600
        oDiag.diagnosticHelp5622.DebitAfficheur_m1 = 700
        oDiag.diagnosticHelp5622.DebitAfficheur_m2 = 800
        oDiag.diagnosticHelp5622.DebitAfficheur_m3 = 900
        oDiag.diagnosticHelp5622.EcartPct_m1 = 15.5
        oDiag.diagnosticHelp5622.EcartPct_m2 = 16.5
        oDiag.diagnosticHelp5622.EcartPct_m3 = 17.5
        oDiag.diagnosticHelp5622.ErreurDebitMetre = 20.5
        oDiag.diagnosticHelp5622.Resultat = "IMPRECISION"

    End Sub

    Private Sub Fill542(oDiag As Diagnostic)
        'Ajout des infos Manomètres (542)
        'Controle du Manometre 542
        oDiag.controleUseCalibrateur = True
        oDiag.syntheseErreurMaxiManoD = 1.8
        oDiag.syntheseErreurMoyenneManoD = 2.0
        oDiag.syntheseImprecision542 = "IMPRECISION"

        Dim oMesure542 As DiagnosticMano542
        For i As Integer = 1 To 4
            oMesure542 = New DiagnosticMano542(i, i * 2)
            oMesure542.Ecart = 1 * 3
            oMesure542.Erreur = DiagnosticMano542.ERR542.FAIBLE
            oDiag.diagnosticMano542List.Liste.Add(oMesure542)
        Next i

    End Sub
    Private Sub Fill833(oDiag As RPDiagnostic)
        oDiag.controleNbreNiveaux = 1
        oDiag.controleNbreTroncons = 4
        oDiag.relevePression833_1 = New RelevePression833(oDiag.controleNbreNiveaux, oDiag.controleNbreTroncons, 1.6, Nothing)
        oDiag.relevePression833_2 = New RelevePression833(oDiag.controleNbreNiveaux, oDiag.controleNbreTroncons, 2.0, Nothing)
        oDiag.relevePression833_3 = New RelevePression833(oDiag.controleNbreNiveaux, oDiag.controleNbreTroncons, 3.0, Nothing)
        oDiag.relevePression833_4 = New RelevePression833(oDiag.controleNbreNiveaux, oDiag.controleNbreTroncons, 4.5, Nothing)

        oDiag.relevePression833_1.SetPressionLue(1, 1, 1.6)
        oDiag.relevePression833_1.SetPressionLue(1, 2, 2.0)
        oDiag.relevePression833_1.SetPressionLue(1, 3, 3.1)
        oDiag.relevePression833_1.SetPressionLue(1, 4, 4.5)

        oDiag.relevePression833_2.SetPressionLue(1, 1, 2.0)
        oDiag.relevePression833_2.SetPressionLue(1, 2, 2.0)
        oDiag.relevePression833_2.SetPressionLue(1, 3, 2.0)
        oDiag.relevePression833_2.SetPressionLue(1, 4, 2.0)

        oDiag.relevePression833_2.SetPressionLue(1, 1, 3.1)
        oDiag.relevePression833_2.SetPressionLue(1, 2, 3.5)
        oDiag.relevePression833_2.SetPressionLue(1, 3, 3.6)
        oDiag.relevePression833_2.SetPressionLue(1, 4, 2.8)

        oDiag.relevePression833_4.SetPressionLue(1, 1, 4.0)
        oDiag.relevePression833_4.SetPressionLue(1, 2, 4.0)
        oDiag.relevePression833_4.SetPressionLue(1, 3, 4.0)
        oDiag.relevePression833_4.SetPressionLue(1, 4, 4.5)
        Dim oMesure833 As DiagnosticTroncons833
        For nPression As Integer = 1 To 4
            oMesure833 = New DiagnosticTroncons833()
            oMesure833.idPression = nPression
            oMesure833.idColumn = 1
            oMesure833.pressionSortie = 1.6
            oMesure833.EcartBar = 0.33
            oMesure833.Ecartpct = 10
            oMesure833.MoyenneAutrePression = 11
            oMesure833.HeterogeneiteBar = 12
            oMesure833.HeterogeneitePct = 13
            oMesure833.nNiveau = 1
            oMesure833.nTroncon = 1
            oDiag.diagnosticTroncons833.Liste.Add(oMesure833)
            oMesure833 = New DiagnosticTroncons833()
            oMesure833.idPression = nPression
            oMesure833.idColumn = 2
            oMesure833.pressionSortie = 1.6
            oMesure833.EcartBar = 0.33
            oMesure833.Ecartpct = 10
            oMesure833.MoyenneAutrePression = 11
            oMesure833.HeterogeneiteBar = 12
            oMesure833.HeterogeneitePct = 13
            oMesure833.nNiveau = 1
            oMesure833.nTroncon = 2
            oDiag.diagnosticTroncons833.Liste.Add(oMesure833)
            oMesure833 = New DiagnosticTroncons833()
            oMesure833.idPression = nPression
            oMesure833.idColumn = 3
            oMesure833.pressionSortie = 1.6
            oMesure833.EcartBar = 0.33
            oMesure833.Ecartpct = 10
            oMesure833.MoyenneAutrePression = 11
            oMesure833.HeterogeneiteBar = 12
            oMesure833.HeterogeneitePct = 13
            oMesure833.nNiveau = 1
            oMesure833.nTroncon = 3
            oDiag.diagnosticTroncons833.Liste.Add(oMesure833)
            oMesure833 = New DiagnosticTroncons833()
            oMesure833.idPression = nPression
            oMesure833.idColumn = 4
            oMesure833.pressionSortie = 1.6
            oMesure833.EcartBar = 0.33
            oMesure833.Ecartpct = 10
            oMesure833.MoyenneAutrePression = 11
            oMesure833.HeterogeneiteBar = 12
            oMesure833.HeterogeneitePct = 13
            oMesure833.nNiveau = 1
            oMesure833.nTroncon = 4
            oDiag.diagnosticTroncons833.Liste.Add(oMesure833)
        Next

    End Sub

    Private Sub FillBuses(odiag As RPDiagnostic)
        odiag.syntheseErreurMoyenneMano = 10
        odiag.syntheseErreurMaxiMano = 20
        odiag.syntheseErreurDebitmetre = 30
        odiag.syntheseErreurMoyenneCinemometre = 40
        odiag.syntheseUsureMoyenneBuses = 50
        odiag.syntheseNbBusesUsees = 60
        odiag.synthesePerteChargeMoyenne = 70
        odiag.synthesePerteChargeMaxi = 80

        'Buses

        Dim oDiagBuses As New DiagnosticBuses()
        oDiagBuses.idDiagnostic = odiag.id
        oDiagBuses.idLot = 1
        oDiagBuses.marque = "Lot1Marque"
        oDiagBuses.genre = "Lot1Type"
        oDiagBuses.couleur = "Lot1Couleur"
        oDiagBuses.nombre = 100
        'usureMoyenne
        'PressionControle
        'Modele
        'Fonctionnement
        oDiagBuses.debitNominal = 10
        oDiagBuses.debitMoyen = 20
        oDiagBuses.debitMin = 30
        oDiagBuses.calibre = 50
        oDiagBuses.ecartTolere = 10
        oDiagBuses.debitMax = 70
        oDiagBuses.nombrebusesusees = 80
        oDiagBuses.Resultat = "USURE"

        Dim nBuse As Integer = 0
        Dim oMesure As DiagnosticBusesDetail
        oMesure = New DiagnosticBusesDetail()
        oMesure.idDiagnostic = odiag.id
        oMesure.idLot = oDiagBuses.idLot
        nBuse = nBuse + 1
        oMesure.idBuse = nBuse
        oMesure.ecart = 10
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oMesure)

        oMesure = New DiagnosticBusesDetail()
        oMesure.idDiagnostic = odiag.id
        oMesure.idLot = oDiagBuses.idLot
        nBuse = nBuse + 1
        oMesure.idBuse = nBuse
        oMesure.ecart = -4
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oMesure)

        oMesure = New DiagnosticBusesDetail()
        oMesure.idDiagnostic = odiag.id
        oMesure.idLot = oDiagBuses.idLot
        nBuse = nBuse + 1
        oMesure.idBuse = nBuse
        oMesure.ecart = 0
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oMesure)

        oMesure = New DiagnosticBusesDetail()
        oMesure.idDiagnostic = odiag.id
        oMesure.idLot = oDiagBuses.idLot
        nBuse = nBuse + 1
        oMesure.idBuse = nBuse
        oMesure.ecart = 5
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oMesure)

        odiag.diagnosticBusesList.Liste.Add(oDiagBuses)

    End Sub

    Private Sub FillSyntheseMesures(oDiag As RPDiagnostic)
        oDiag.syntheseErreurMoyenneMano = 10
        oDiag.syntheseErreurMaxiMano = 20
        oDiag.syntheseErreurDebitmetre = 30
        oDiag.syntheseErreurMoyenneCinemometre = 40
        oDiag.syntheseUsureMoyenneBuses = 50
        oDiag.syntheseNbBusesUsees = 60
        oDiag.synthesePerteChargeMoyenne = 70
        oDiag.synthesePerteChargeMaxi = 80

    End Sub
    Private Sub FillDiagItems(oDiag As Diagnostic)
        Dim oDiagItem As RPDiagItem
        For i As Integer = 0 To 5
            oDiagItem = New RPDiagItem(oDiag.id, "257", i, "2", "O")
            oDiagItem.LibelleCourt = "LIBCourt257" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 257" & i
            oDiag.AddDiagItem(oDiagItem)

        Next
        For i As Integer = 0 To 5
            oDiagItem = New RPDiagItem(oDiag.id, "256", i, "2", "P")
            oDiagItem.LibelleCourt = "LIBCourt256" & i
            oDiagItem.LibelleLong = "Ceci est le libelle Long de 256" & i
            oDiag.AddDiagItem(oDiagItem)

        Next


    End Sub
End Class
#End If