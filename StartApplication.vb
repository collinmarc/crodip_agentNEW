Module StartApplication
    Public Sub Main()
        ' Bancs
        GLOB_XML_MARQUES_BANC = New CSXml("." & "\config\bancs\marques.xml")
        ' Buses
        GLOB_XML_MARQUES_BUSES = New CSXml("." & "\config\buses\marques.xml")
        GLOB_XML_MODELES_BUSES = New CSXml("." & "\config\buses\modeles.xml")
        GLOB_XML_GENRES_BUSES = New CSXml("." & "\config\buses\genres.xml")
        GLOB_XML_COULEURS_BUSES = New CSXml("." & "\config\buses\couleurs.xml")
        GLOB_XML_TYPES_BUSES = New CSXml("." & "\config\buses\types.xml")
        GLOB_XML_ANGLES_BUSES = New CSXml("." & "\config\buses\angles.xml")
        GLOB_XML_REFER_BUSES = New CSXml("." & "\config\buses\buses.xml")
        GLOB_XML_FONCTIONNEMENTBUSES_BUSES = New CSXml("." & "\config\buses\fonctionnement.xml")

        ' Manometres
        GLOB_XML_MARQUES_MANO = New CSXml("." & "\config\manometres\marques.xml")
        GLOB_XML_MODELES_MANO = New CSXml("." & "\config\manometres\modeles.xml")
        GLOB_XML_CLASSES_MANO = New CSXml("." & "\config\manometres\classes.xml")
        GLOB_XML_FONDECHELLE_MANO = New CSXml("." & "\config\manometres\fondEchelle.xml")

        ' Manometres de contrôle
        GLOB_XML_MARQUES_MANOCONT = New CSXml("." & "\config\manometres-controle\marques.xml")
        GLOB_XML_MODELES_MANOCONT = New CSXml("." & "\config\manometres-controle\modeles.xml")
        GLOB_XML_CLASSES_MANOCONT = New CSXml("." & "\config\manometres-controle\classes.xml")
        GLOB_XML_FONDECHELLE_MANOCONT = New CSXml("." & "\config\manometres-controle\fondEchelle.xml")
        ' Manometres étalon
        GLOB_XML_MARQUES_MANOETA = New CSXml("." & "\config\manometres-etalon\marques.xml")
        GLOB_XML_MODELES_MANOETA = New CSXml("." & "\config\manometres-etalon\modeles.xml")
        GLOB_XML_CLASSES_MANOETA = New CSXml("." & "\config\manometres-etalon\classes.xml")
        GLOB_XML_FONDECHELLE_MANOETA = New CSXml("." & "\config\manometres-etalon\fondEchelle.xml")

        ' Pulvérisateurs
        GLOB_XML_MARQUES_MODELES_PULVE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielPulverisateurMarquesModeles.xml")
        GLOB_XML_TYPES_CATEGORIES_PULVE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielPulverisateurTypesCategories.xml")
        GLOB_XML_ATTELAGE_PULVE = New CSXml(My.Settings.RepertoireParametres & "\Attelage.xml")
        GLOB_XML_PULVERISATION_PULVE = New CSXml(My.Settings.RepertoireParametres & "\Pulverisation.xml")
        GLOB_XML_REGULATION_PULVE = New CSXml("." & "\" & My.Settings.RepertoireParametres & "\PulverisateurRegulation.xml")
        GLOB_XML_EMPLACEMENTIDENTIFICATION = New CSXml(My.Settings.RepertoireParametres & "\EmplacementIdentification.xml")
        GLOB_XML_MODEUTILISATION = New CSXml(My.Settings.RepertoireParametres & "\PulverisateurModeUtilisation.xml")


        ' Territoires
        GLOB_XML_TERRITOIRES = New CSXml("." & "\config\territoire.xml")
        GLOB_XML_CODESAPE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielCodesAPE.xml")

        Dim ofrm As Form
#If REGLAGEPULVE Then
        Dim args As String()
        args = Environment.GetCommandLineArgs()
        ofrm = New frmRPparentContener()
        If args.Length > 1 Then
            ofrm = New frmRPparentContener(args(1))
        End If
#Else
        ofrm = New parentContener()
#End If
        ofrm.ShowDialog()
    End Sub

End Module
