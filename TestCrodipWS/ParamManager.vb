Imports CRODIPWS

Public Class ConfigManager

    Public Shared Sub initGlobalsCrodip()
        My.Settings.Reload()
        Dim test As String = My.Settings.DBVersionExpected
        If My.Settings.BDDType = "ACCESS" Then
            CSDb._DBTYPE = CSDb.EnumDBTYPE.MSACCESS
        End If
        If My.Settings.BDDType = "SQLITE" Then
            CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        End If
        GlobalsCRODIP.GLOB_ENV_AUTOSYNC = My.Settings.AutoSync
        GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE = (My.Settings.Mode = "SIMPLIFIE")
        GlobalsCRODIP.GLOB_ENV_MODEFORMATION = (My.Settings.Mode = "FORMATION")
        If GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE = True
        End If
        GlobalsCRODIP.GLOB_APPLI_VERSION = My.Settings.NumVersion
        GlobalsCRODIP.GLOB_APPLI_DBVERSION = My.Settings.DBVersionExpected
        GlobalsCRODIP.GLOB_APPLI_BUILD = My.Settings.NumBuild

        GlobalsCRODIP.GLOB_NETWORKAVAILABLE = CSEnvironnement.checkNetwork()
        CSDebug.dispInfo("GlobalsCRODIP.Init App My.Settings.DBVersion:" & GlobalsCRODIP.GLOB_APPLI_VERSION)
        CSDebug.dispInfo("GlobalsCRODIP.Init App My.Settings.NumBuild:" & GlobalsCRODIP.GLOB_APPLI_BUILD)
        CSDebug.dispInfo("GlobalsCRODIP.Init App My.Settings.DB:" & My.Settings.DB)
        CSDebug.dispInfo("GlobalsCRODIP.Init App My.Settings.DBVersion:" & GlobalsCRODIP.GLOB_APPLI_VERSION)
        CSDebug.dispInfo("GlobalsCRODIP.Init App NETWORK:" & GlobalsCRODIP.GLOB_NETWORKAVAILABLE)

        ' Manometres
        GlobalsCRODIP.GLOB_XML_MARQUES_MANO = New CSXml("." & "\config\marques.xml")
        GlobalsCRODIP.GLOB_XML_FONDECHELLE_MANO = New CSXml("." & "\config\fondEchelle.xml")

        ' Manometres de contrôle
        'GlobalsCRODIP.GLOB_XML_MARQUES_MANOCONT = New CSXml("." & "\config\manometres-controle\marques.xml")
        'GlobalsCRODIP.GLOB_XML_MODELES_MANOCONT = New CSXml("." & "\config\manometres-controle\modeles.xml")
        'GlobalsCRODIP.GLOB_XML_CLASSES_MANOCONT = New CSXml("." & "\config\manometres-controle\classes.xml")
        'GlobalsCRODIP.GLOB_XML_FONDECHELLE_MANOCONT = New CSXml("." & "\config\manometres-controle\fondEchelle.xml")
        ' Manometres étalon
        'GlobalsCRODIP.GLOB_XML_MARQUES_MANOETA = New CSXml("." & "\config\manometres-etalon\marques.xml")
        'GlobalsCRODIP.GLOB_XML_MODELES_MANOETA = New CSXml("." & "\config\manometres-etalon\modeles.xml")
        'GlobalsCRODIP.GLOB_XML_CLASSES_MANOETA = New CSXml("." & "\config\manometres-etalon\classes.xml")
        'GlobalsCRODIP.GLOB_XML_FONDECHELLE_MANOETA = New CSXml("." & "\config\manometres-etalon\fondEchelle.xml")

        ' Pulvérisateurs
        GlobalsCRODIP.GLOB_XML_MARQUES_MODELES_PULVE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielPulverisateurMarquesModeles.xml")
        GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielPulverisateurTypesCategories.xml")
        GlobalsCRODIP.GLOB_XML_ATTELAGE_PULVE = New CSXml(My.Settings.RepertoireParametres & "\Attelage.xml")
        GlobalsCRODIP.GLOB_XML_PULVERISATION_PULVE = New CSXml(My.Settings.RepertoireParametres & "\Pulverisation.xml")
        GlobalsCRODIP.GLOB_XML_REGULATION_PULVE = New CSXml("." & "\" & My.Settings.RepertoireParametres & "\PulverisateurRegulation.xml")
        GlobalsCRODIP.GLOB_XML_EMPLACEMENTIDENTIFICATION = New CSXml(My.Settings.RepertoireParametres & "\EmplacementIdentification.xml")
        GlobalsCRODIP.GLOB_XML_MODEUTILISATION = New CSXml(My.Settings.RepertoireParametres & "\PulverisateurModeUtilisation.xml")

        GlobalsCRODIP.GLOB_STR_REFERENTIELBUSES_FILENAME = My.Settings.RepertoireParametres & "\referentiel_buse.csv"
        GlobalsCRODIP.GLOB_STR_COMMUNES_FILENAME = My.Settings.RepertoireParametres & "\base_officielle_codes_postaux.csv"
        GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME = "./config/facturation.xml"

        ' Territoires
        'GlobalsCRODIP.GLOB_XML_TERRITOIRES = New CSXml("." & "\config\territoire.xml")
        GlobalsCRODIP.GLOB_XML_CODESAPE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielCodesAPE.xml")
        GlobalsCRODIP.GLOB_XML_CONFIG = New CSXml("config\config.xml")

        GlobalsCRODIP.CONST_STOCK_PDFS = My.Settings.StockPDF
        Pulverisateur.initConstantes()
        GlobalsCRODIP.GLOB_PARAM_aqw = My.Settings.aqw
        GlobalsCRODIP.GLOB_PARAM_RepertoireParametres = My.Settings.RepertoireParametres
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatDiagUrl = My.Settings.SynchroEtatDiagUrl
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatDiagUser = My.Settings.SynchroEtatDiagUser
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatDiagPwd = My.Settings.SynhcroEtatDiagPwd
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatFVBancUrl = My.Settings.SynchroEtatFVBancUrl
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatFVBancUser = My.Settings.SynchroEtatFVBancUser
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatFVBancPwd = My.Settings.SynchroEtatFVBancpwd
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatFVManoUrl = My.Settings.SynchroEtatFVManoUrl
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatFVManoUser = My.Settings.SynchroEtatFVBancUser
        GlobalsCRODIP.GLOB_PARAM_SynchroEtatFVManoPwd = My.Settings.SynchroEtatFVBancpwd

        GlobalsCRODIP.GLOB_PARAM_WSCrodipProduction = My.Settings.WSCrodipProduction
        GlobalsCRODIP.GLOB_PARAM_FTPuser = My.Settings.FTPuser
        GlobalsCRODIP.GLOB_PARAM_FTPPassword = My.Settings.FTPPassword
        GlobalsCRODIP.GLOB_PARAM_FTPhost = My.Settings.FTPHost
        GlobalsCRODIP.GLOB_PARAM_FTPuserTest = My.Settings.FTPUserTest
        GlobalsCRODIP.GLOB_PARAM_FTPPasswordTest = My.Settings.FTPPasswordTest
        GlobalsCRODIP.GLOB_PARAM_FTPhostTest = My.Settings.FTPHostTest
        GlobalsCRODIP.GLOB_PARAM_ModuleDocumentaire = My.Settings.ModuleDocumentaire

        GlobalsCRODIP.GLOB_PARAM_WSCrodipURL = My.Settings.WSCrodipURL
        GlobalsCRODIP.GLOB_PARAM_WSCrodipURLTEST = My.Settings.WSCrodipURLTEST

        GlobalsCRODIP.GLOB_PARAM_DB = My.Settings.DB
        GlobalsCRODIP.GLOB_PARAM_DBExtension = My.Settings.DBExtension

        GlobalsCRODIP.GLOB_PARAM_Expect100Continue = My.Settings.Expect100Continue
        GlobalsCRODIP.GLOB_PARAM_SecurityProtocol = My.Settings.SecurityProtocol
        GlobalsCRODIP.GLOB_PARAM_checkNetwork = My.Settings.checkNetwork




    End Sub

End Class