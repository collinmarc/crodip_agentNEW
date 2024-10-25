Imports CRODIPWS
Public Class GlobalsCRODIP

    Public Enum ALERTE As Integer
        NOIRE = -1
        ROUGE = 0
        ORANGE = 1
        JAUNE = 2
        NONE = 3
        CONTROLE = 4
    End Enum
    Public Enum DiagMode As Integer
        CTRL_COMPLET = 0
        CTRL_CV = 1
        CTRL_VISU = 2
        CTRL_SIGNATURE = 3
        CTRL_VISUPDFS = 4
        CTRL_REMPLACER = 5
    End Enum
    Public Enum enumConclusionDiag
        OK
        OK_AVECMINEEUR
        NOK
        NOK_PRELIM
    End Enum


    Public Const GLOB_DIAG_NUMAGR As String = "E001"
    Public Const GLOB_DIAG_NOMAGR As String = "CRODIP/Indigo"


#Region " Environnement "

    Public Shared GLOB_NETWORKAVAILABLE As Boolean = False

    '############ Mode ############
#If DEBUG Then
    '## Dev
    Public Shared GLOB_ENV_DEBUG As Boolean = True
    Public Const GLOB_ENV_DIAGDEBUG As Boolean = True
    Public Const GLOB_ENV_DEBUGTYPE As String = "file" ' "none" ; "console" ; "msgbox" ; "file"
    'Public GLOB_ENV_WS As String = "dev" ' dev / preprod / prod
    Public Const GLOB_ENV_DEBUGLVL As Integer = 3 ' 0:none  ;  1:error  ;  2:error/warning  ;  3:error/warning/infos
#Else
    '## Prod
    Public Shared GLOB_ENV_DEBUG As Boolean = False
    Public Const GLOB_ENV_DIAGDEBUG As Boolean = False
    Public Const GLOB_ENV_DEBUGTYPE As String = "file" ' "none" ; "console" ; "msgbox" ; "file"
    Public Shared GLOB_ENV_WS As String = "prod" ' dev / preprod / prod
    Public Const GLOB_ENV_DEBUGLVL As Integer = 1 ' 0:none  ;  1:error  ;  2:error/warning  ;  3:error/warning/infos
#End If
    '############ FIN -- Mode ############

    ' Debug
    Public Const GLOB_ENV_DEBUGLOGFILE As String = "." & "\tmp\crodipAgent.log" ' Fichier contenant les logs de debug si GLOB_ENV_DEBUGTYPE = "file"
    Public Const GLOB_ENV_SYNCHROLOGFILE As String = "." & "\tmp\LogSynchro.xml"  ' Fichier contenant les logs dxml de la synchro

    ' Comportement
    Public Shared GLOB_ENV_AUTOSYNC As Boolean = My.Settings.AutoSync
    Public Shared GLOB_ENV_MODESIMPLIFIE As Boolean = (My.Settings.Mode = "SIMPLIFIE")
    Public Shared GLOB_ENV_MODEFORMATION As Boolean = (My.Settings.Mode = "FORMATION")

    ' Conf
    Public Shared GLOB_XML_CONFIG As CSXml
    Public Shared GLOB_PID_FILE As String = "." & "\crodip_agent.pid"

    ' Version
    Public Shared GLOB_APPLI_VERSION As String = My.Settings.NumVersion
    Public Shared GLOB_APPLI_BUILD As String = My.Settings.NumBuild
    Public Shared GLOB_ParamDiagRampe As String = My.Settings.ParamDiagRampe
    Public Shared GLOB_ParamDiagArboViti As String = My.Settings.ParamDiagArboviti
    Public Shared GLOB_BLUE_CROPDIP As Color = Color.FromArgb(2, 129, 198)

#End Region

#Region " Marques / Modèles "


    ' Manometres
    Public Shared GLOB_XML_MARQUES_MANO As CSXml
    Public Shared GLOB_XML_FONDECHELLE_MANO As CSXml

    ' Pulvérisateurs
    Public Shared GLOB_XML_MARQUES_MODELES_PULVE As CSXml
    Public Shared GLOB_XML_TYPES_CATEGORIES_PULVE As CSXml
    Public Shared GLOB_XML_ATTELAGE_PULVE As CSXml
    Public Shared GLOB_XML_PULVERISATION_PULVE As CSXml
    Public Shared GLOB_XML_REGULATION_PULVE As CSXml
    Public Shared GLOB_XML_EMPLACEMENTIDENTIFICATION As CSXml
    Public Shared GLOB_XML_MODEUTILISATION As CSXml

    Public Shared GLOB_STR_REFERENTIELBUSES_FILENAME As String = My.Settings.RepertoireParametres & "\referentiel_buse.csv"
    Public Shared GLOB_STR_COMMUNES_FILENAME As String = My.Settings.RepertoireParametres & "\base_officielle_codes_postaux.csv"
    Public Shared GLOB_STR_FACTURATIONCONFIG_FILENAME As String = "./config/facturation.xml"
    ' Territoires
    'Public Shared GLOB_XML_TERRITOIRES As CSXml
    Public Shared GLOB_XML_CODESAPE As CSXml

#End Region



#Region " PATHS "

    ' Public
    Public Shared CONST_PATH_PUBLIC As String = "public/"
    ' Exports
    Public Shared CONST_PATH_EXP As String = CONST_PATH_PUBLIC & "exports/"
    Public Shared CONST_PATH_EXP_MANOCONTROLE As String = CONST_PATH_PUBLIC & "exports/MANOMETRECONTROLE/"
    Public Shared CONST_PATH_EXP_BANCMESURE As String = CONST_PATH_PUBLIC & "exports/BANCMESURE/"
    Public Shared CONST_PATH_EXP_DIAGNOSTIC As String = CONST_PATH_PUBLIC & "exports/DIAGNOSTIC/"
    Public Shared CONST_PATH_EXP_FACTURE As String = CONST_PATH_PUBLIC & "exports/FACTURE/"

    ' Images
    Public Shared CONST_PATH_IMG As String = "." & "/img/"

    ' Temp
    Public Shared CONST_PATH_TMP As String = "." & "/tmp/"

    'PdfsDiags
    Public Shared CONST_STOCK_PDFS As String = "DOSSIERCACHE" 'Nom du dossier cache contenant les PDFS
    Public Shared CONST_PDFS_DIAG_PWD As String = "crodip"

    Public Shared PATH_TO_LIEUXCONTROLE As String = "./config/Lieuxcontrole.csv"

#End Region

#Region " Nom des documents "

    ' Logo module facturation
    Public Const CR_LOGO_DEFAULT_NAME As String = "nologo.jpg"
    Public Const CR_LOGO_DEFAULT_TN_NAME As String = "nologo_tn.jpg"
    Public Const CR_LOGO_NAME As String = "CR_logo.jpg"
    Public Const CR_LOGO_TN_NAME As String = "CR_logo_tn.jpg"
    Public Const CR_LOGO_TN2_NAME As String = "CR_logo_tn2.jpg"

    ' Template Facture
    Public CONST_DOC_FACTURE As String = "facture"
    ' Template BL
    Public Const CONST_DOC_BL As String = "bl"
    ' Template Contrat Commercial
    Public Const CONST_DOC_CONTCOM As String = "contrat_commercial"
    ' Rapports d'inspection
    'Public GlobalsCRODIP.CONST_DOC_RAPINSP As String = "rapport_inspection"
    Public Const CONST_DOC_RAPINSP_COMPLET As String = "rapport_inspection_complet"
    Public Const CONST_DOC_RAPINSP_COMPLET_2P As String = "rapport_inspection_complet_2p"
    Public Const CONST_DOC_RAPINSP_CONTREVISITE As String = "rapport_inspection_ContreVisite"
    Public Const CONST_DOC_RAPINSP_CONTREVISITE_2P As String = "rapport_inspection_ContreVisite_2p"
    ' Rapport d'inspection 2 pages
    'Public GlobalsCRODIP.CONST_DOC_RAPINSP2 As String = "rapport_inspection_2p"
    ' Feuille pédagogique
    Public Const CONST_DOC_FPEDA As String = "feuille_pedagogique"
    ' Enquete satisfaction
    Public Const CONST_DOC_ENQSAT As String = "enquete_satisfaction"
    ' Template Fiche Terrain Rampe
    Public Const CONST_DOC_FICHETERRAIN_RAMPE As String = "fiche_terrain_rampe.pdf"
    ' Template Fiche Terrain Arbo/viti
    Public Const CONST_DOC_FICHETERRAIN_ARBOVITI As String = "fiche_terrain_arbo-viti.pdf"
    ' Template Fiche de vie mano controle
    Public Const CONST_DOC_FV_MANOCTRL As String = "ficheVie_mano"
    ' Template Fiche de vie banc
    Public Const CONST_DOC_FV_BANC As String = "ficheVie_banc"
    ''' <summary>
    ''' Symbole decimal utilisé par l'application
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared CONST_DECIMAL_SYMBOL As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

#End Region


#Region " constantes (Messages d'info.) "

#Region " Messages d'information "

    '###########################################
    '#####     Messages d'information      #####
    '###########################################
    ' Contrôle d'un banc de mesure
    '###########################################
    Public Const CONST_INFO_CTRLBANC_ERR_NOTEMP As String = "        Vous devez renseigner les températures de l'air et de l'eau."
    Public Const CONST_INFO_CTRLBANC_ERR_5BUSES As String = "        Vous devez sélectionner 5 buses minimum."
    Public Const CONST_INFO_CTRLBANC_ERR_MESURES As String = "        Vous devez saisir les mesures pour toutes les buses."
    Public Const CONST_INFO_CTRLBANC_ERR_NOVERIFNUM As String = "        Vous devez renseigner un numéro de vérification."
    Public Const CONST_INFO_CTRLBANC_ERR_NOBANCNUM As String = "        Vous devez renseigner un numéro de banc à contrôler."
    Public Const CONST_INFO_CTRLBANC_MSG_CONTROLOK As String = "        Contrôle OK"
    Public Const CONST_INFO_CTRLBANC_MSG_CONTROLNOK As String = "        Contrôle NOK"

#End Region

#Region " Messages barre de statut "

    '###########################################
    '#####    Messages barre de statut     #####
    '###########################################
    ' Alertes en page d'accueil
    '###########################################
    Public Const CONST_STATUTMSG_ALERTES_MANOETALON_LOAD As String = "        Vérification des alertes sur les manomètres étalons..."
    Public Const CONST_STATUTMSG_ALERTES_MANOCONTROLE_LOAD As String = "        Vérification des alertes sur les manomètres de contrôle..."
    Public Const CONST_STATUTMSG_ALERTES_BUSESETALON_LOAD As String = "        Vérification des alertes sur les buses étalons..."
    Public Const CONST_STATUTMSG_ALERTES_BANC_LOAD As String = "        Vérification des alertes sur les bancs de mesure..."
    Public Const CONST_STATUTMSG_ALERTES_CLIENTS_LOAD As String = "        Vérification des alertes sur les clients..."
    Public Const CONST_STATUTMSG_ALERTES_SYNCHRO_LOAD As String = "        Vérification des alertes sur la synchronisation..."
    '###########################################

    '###########################################
    ' Login
    '###########################################
    Public Const CONST_STATUTMSG_LOGIN_ENCOURS As String = "        Connexion en cours..."
    Public Const CONST_STATUTMSG_LOGIN_OK As String = "        Connexion réussie."
    Public Const CONST_STATUTMSG_LOGIN_FAILED As String = "        [Erreur] - Echec de la connexion à votre profil."
    '###########################################

    '###########################################
    ' Ajout d'un Agent
    '###########################################
    Public Const CONST_STATUTMSG_ADDAGENT_ENCOURS As String = "        Ajout d'un nouveau profil en cours..."
    Public Const CONST_STATUTMSG_ADDAGENT_LINK_ENCOURS As String = "        Connexion au serveur en cours..."
    Public Const CONST_STATUTMSG_ADDAGENT_LOAD_ENCOURS As String = "        Chargement du profil en cours..."
    Public Const CONST_STATUTMSG_ADDAGENT_VERIF_ENCOURS As String = "        Vérifications en cours..."
    Public Const CONST_STATUTMSG_ADDAGENT_ERROR_EXISTS As String = "        [Erreur] - Echec de récupération du profil : Cet inspecteur est déjà présent en base."
    Public Const CONST_STATUTMSG_ADDAGENT_ERROR_PASSNOTMATCH As String = "        [Erreur] - Echec de récupération du profil : Les mots de passe ne correspondent pas."
    Public Const CONST_STATUTMSG_ADDAGENT_ERROR_NOPROFIL As String = "        [Erreur] - Echec de récupération du profil : Ce profil n'existe pas."
    Public Const CONST_STATUTMSG_ADDAGENT_ERROR_NOTCONNECT As String = "        [Erreur] - Echec de récupération du profil : Connection introuvable."
    Public Const CONST_STATUTMSG_ADDAGENT_OK As String = "        Sauvegarde réussie."
    '###########################################

    '###########################################
    ' Parametrage Agent
    '###########################################
    Public Const CONST_STATUTMSG_FICHEAGENT_ENCOURS As String = "        Sauvegarde de vos données en cours..."
    Public Const CONST_STATUTMSG_FICHEAGENT_OK As String = "        Sauvegarde réussie."
    Public Const CONST_STATUTMSG_FICHEAGENT_FAILED As String = "        [Erreur] - Echec de la sauvegarde de vos données."
    '###########################################

    '###########################################
    ' Listing clients
    '###########################################
    Public Const CONST_STATUTMSG_LISTCLIENT_ENCOURS As String = "        Chargement des clients en cours..."
    Public Const CONST_STATUTMSG_LISTCLIENT_OK As String = " clients correctement chargés."
    '###########################################

    '###########################################
    ' Parametrage Client
    '###########################################
    Public Const CONST_STATUTMSG_FICHECLIENT_ENCOURS As String = "        Sauvegarde de vos données client en cours..."
    Public Const CONST_STATUTMSG_FICHECLIENT_OK As String = "        Sauvegarde du client réussie."
    Public Const CONST_STATUTMSG_FICHECLIENT_FAILED As String = "        [Erreur] - Echec de la sauvegarde de vos données client."
    '###########################################

    '###########################################
    ' Supression Client
    '###########################################
    Public Const CONST_STATUTMSG_DELETECLIENT_ENCOURS As String = "        Suppression du client en cours..."
    Public Const CONST_STATUTMSG_DELETECLIENT_OK As String = "        Suppression du client réussie."
    Public Const CONST_STATUTMSG_DELETECLIENT_FAILED As String = "        [Erreur] - Echec de la suppression du client."
    Public Const CONST_STATUTMSG_DELETECLIENT_CANCEL As String = "        Suppression du client annulée par l'utilisateur."
    Public Const CONST_STATUTMSG_DELETECLIENT_NOSELECTED As String = "        Vous devez d'abord sélectionner un client dans la liste."
    '###########################################

    '###########################################
    ' Listing pulvérisateurs
    '###########################################
    Public Const CONST_STATUTMSG_LISTPULVE_ENCOURS As String = "        Chargement des pulvérisateurs en cours..."
    Public Const CONST_STATUTMSG_LISTPULVE_OK As String = " pulvérisateurs correctement chargés."
    '###########################################

    '###########################################
    ' Parametrage pulvérisateur
    '###########################################
    Public Const CONST_STATUTMSG_EDITPULVE_ENCOURS As String = "        Sauvegarde du pulvérisateur en cours..."
    Public Const CONST_STATUTMSG_EDITPULVE_OK As String = "        Sauvegarde du pulvérisateur réussie."
    Public Const CONST_STATUTMSG_EDITPULVE_FAILED As String = "        [Erreur] - Echec de la sauvegarde du pulvérisateur."
    '###########################################

    '###########################################
    ' Supression pulvérisateur
    '###########################################
    Public Const CONST_STATUTMSG_DELETEPULVE_ENCOURS As String = "        Suppression du pulvérisateur en cours..."
    Public Const CONST_STATUTMSG_DELETEPULVE_OK As String = "        Suppression du pulvérisateur réussie."
    Public Const CONST_STATUTMSG_DELETEPULVE_FAILED As String = "        [Erreur] - Suppression du pulvérisateur impossible, présence de contrôles."
    Public Const CONST_STATUTMSG_DELETEPULVE_CANCEL As String = "        Suppression du pulvérisateur annulée par l'utilisateur."
    Public Const CONST_STATUTMSG_DELETEPULVE_NOSELECTED As String = "        Vous devez d'abord sélectionner un pulvérisateur dans la liste."
    '###########################################

    '###########################################
    ' Parametrage Structure
    '###########################################
    Public Const CONST_STATUTMSG_FICHESTRUCTURE_ENCOURS As String = "        Sauvegarde de vos données en cours..."
    Public Const CONST_STATUTMSG_FICHESTRUCTURE_OK As String = "        Sauvegarde réussie."
    Public Const CONST_STATUTMSG_FICHESTRUCTURE_FAILED As String = "        [Erreur] - Echec de la Sauvegarde de vos données."
    '###########################################

    '###########################################
    ' Synchronisation
    '###########################################
    Public Const CONST_STATUTMSG_SYNCHRO_ENCOURS As String = "        Synchronisation avec le Crodip en cours..."
    Public Const CONST_STATUTMSG_SYNCHRO_OK As String = " éléments ont été synchronisés."
    Public Const CONST_STATUTMSG_SYNCHRO_EMPTY As String = "        Aucun élément à synchroniser."
    Public Const CONST_STATUTMSG_SYNCHRO_FAILED As String = "        [Erreur] - Echec de la synchronisation avec le Crodip."
    Public Const CONST_STATUTMSG_SYNCHRO_UNAVAILABLE As String = "        Synchronisation impossible, serveur Crodip momentanément indisponible."
    '###########################################

    '###########################################
    ' Contrôle
    '###########################################
    Public Const CONST_STATUTMSG_DIAG_VERIFCLI As String = "Vérification des informations du client."
    Public Const CONST_STATUTMSG_DIAG_TARIFS As String = "Saisie des tarifs."
    Public Const CONST_STATUTMSG_DIAG_CONTROLEPRE As String = "Contrôle préliminaire."
    Public Const CONST_STATUTMSG_DIAG_ENCOURS As String = "Contrôle pulvé en cours..."
    Public Const CONST_STATUTMSG_DIAG_SAVING As String = "Enregistrement en cours..."
    Public Const CONST_STATUTMSG_DIAG_SAVED As String = "Contrôle correctement enregistré."
    '###########################################

#End Region

#End Region

    Public Shared Sub Init()
        My.Settings.Reload()
        If My.Settings.BDDType = "ACCESS" Then
            CSDb._DBTYPE = CSDb.EnumDBTYPE.MSACCESS
        End If
        If My.Settings.BDDType = "SQLITE" Then
            CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        End If
        GLOB_ENV_AUTOSYNC = My.Settings.AutoSync
        GLOB_ENV_MODESIMPLIFIE = (My.Settings.Mode = "SIMPLIFIE")
        GLOB_ENV_MODEFORMATION = (My.Settings.Mode = "FORMATION")
        If GLOB_ENV_MODEFORMATION Then
            GLOB_ENV_MODESIMPLIFIE = True
        End If
        GLOB_APPLI_VERSION = My.Settings.NumVersion
        GLOB_APPLI_BUILD = My.Settings.NumBuild

        GLOB_NETWORKAVAILABLE = CSEnvironnement.checkNetwork()
        CSDebug.dispInfo("GlobalsCRODIP.Init user LocalUserAppDataPath :" & Application.LocalUserAppDataPath)
        CSDebug.dispInfo("GlobalsCRODIP.Init App My.Settings.NumVersion:" & My.Settings.NumVersion)
        CSDebug.dispInfo("GlobalsCRODIP.Init App My.Settings.NumBuild:" & My.Settings.NumBuild)
        CSDebug.dispInfo("GlobalsCRODIP.Init App My.Settings.DB:" & My.Settings.DB)
        CSDebug.dispInfo("GlobalsCRODIP.Init App NETWORK:" & GLOB_NETWORKAVAILABLE)

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


        ' Territoires
        'GlobalsCRODIP.GLOB_XML_TERRITOIRES = New CSXml("." & "\config\territoire.xml")
        GlobalsCRODIP.GLOB_XML_CODESAPE = New CSXml(My.Settings.RepertoireParametres & "\ReferentielCodesAPE.xml")
        GlobalsCRODIP.GLOB_XML_CONFIG = New CSXml("config\config.xml")

        GlobalsCRODIP.CONST_STOCK_PDFS = My.Settings.StockPDF
    End Sub
    Public Shared Function StringToDouble(pInputString As String) As Double
        Dim dReturn As Double
        Dim ciClone As System.Globalization.CultureInfo = CType(System.Globalization.CultureInfo.InvariantCulture.Clone(), System.Globalization.CultureInfo)
        ciClone.NumberFormat.NumberDecimalSeparator = ","
        If String.IsNullOrEmpty(pInputString) Then
            Return 0.0
        End If
        pInputString = pInputString.Replace("€", "")

        Try
            'on convertit en remplaçant le . par la virgule
            dReturn = Convert.ToDouble(pInputString.Replace(".", ","), ciClone)
        Catch ex As Exception
            CSDebug.dispInfo("StringToDouble: Erreur Conversion 1 :" & pInputString)
            ex = Nothing
            Try
                'si ça ne fonctionne pas on convertit sans remplacement
                dReturn = Convert.ToDouble(pInputString, ciClone)
            Catch ex2 As Exception
                CSDebug.dispInfo("StringToDouble: Erreur Conversion 2 :" & pInputString)
                ex2 = Nothing
                Try
                    'si ça ne fonctionne pas on convertit sans prendre en compte la culture
                    dReturn = Convert.ToDouble(pInputString)
                Catch ex3 As Exception
                    CSDebug.dispError("StringToDouble: Erreur Conversion 3 :" & pInputString)
                    ex3 = Nothing
                    dReturn = 0
                End Try
            End Try
        End Try
        Return dReturn

    End Function

    Public Function FormatStringDecimal(pInputString As String, pndec As Decimal) As String
        Dim dValue As Double
        Dim sReturn As String
        Dim strFormat As String
        sReturn = ""
        Try

            dValue = GlobalsCRODIP.StringToDouble(pInputString)
            strFormat = "#####0."
            For i As Integer = 1 To pndec
                strFormat = strFormat & "0"
            Next
            sReturn = dValue.ToString(strFormat)

        Catch ex As Exception
            CSDebug.dispWarn("FormatStringDecimal ERR : " & ex.Message)
            sReturn = ""
        End Try
        Return sReturn
    End Function
End Class
