Public Module config_vars

    Public GLOB_DIAG_NUMAGR As String = "E001"
    Public GLOB_DIAG_NOMAGR As String = "CRODIP/Indigo"


#Region " Environnement "

    '############ Mode ############
#If DEBUG Then
    '## Dev
    Public GLOB_ENV_DEBUG As Boolean = True
    Public GLOB_ENV_DIAGDEBUG As Boolean = True
    Public GLOB_ENV_DEBUGTYPE As String = "file" ' "none" ; "console" ; "msgbox" ; "file"
    'Public GLOB_ENV_WS As String = "dev" ' dev / preprod / prod
    Public GLOB_ENV_DEBUGLVL As Integer = 3 ' 0:none  ;  1:error  ;  2:error/warning  ;  3:error/warning/infos
#Else
    '## Prod
    Public GLOB_ENV_DEBUG As Boolean = False
    Public GLOB_ENV_DIAGDEBUG As Boolean = False
    Public GLOB_ENV_DEBUGTYPE As String = "file" ' "none" ; "console" ; "msgbox" ; "file"
    Public GLOB_ENV_WS As String = "prod" ' dev / preprod / prod
    Public GLOB_ENV_DEBUGLVL As Integer = 1 ' 0:none  ;  1:error  ;  2:error/warning  ;  3:error/warning/infos
#End If
    '############ FIN -- Mode ############

    ' Debug
    Public GLOB_ENV_DEBUGLOGFILE As String = "." & "\tmp\crodipAgent.log" ' Fichier contenant les logs de debug si GLOB_ENV_DEBUGTYPE = "file"
    Public GLOB_ENV_SYNCHROLOGFILE As String = "." & "\tmp\LogSynchro.xml"  ' Fichier contenant les logs dxml de la synchro

    ' Comportement
    Public GLOB_ENV_AUTOSYNC As Boolean = My.Settings.AutoSync
    Public GLOB_ENV_SHOWSPLASH As Boolean = True

    ' Conf
    Public GLOB_XML_CONFIG As CSXml = New CSXml("config\config.xml")
    Public GLOB_PID_FILE As String = "." & "\crodip_agent.pid"

    ' Version
    Public GLOB_APPLI_VERSION As String = My.Settings.NumVersion
    Public GLOB_APPLI_BUILD As String = My.Settings.NumBuild
    Public GLOB_ParamDiagRampe As String = My.Settings.ParamDiagRampe
    Public GLOB_ParamDiagArboViti As String = My.Settings.ParamDiagArboviti
    Public GLOB_BLUE_CROPDIP As Color = Color.FromArgb(2, 129, 198)

#End Region

#Region " Marques / Modèles "

    ' Bancs
    Public GLOB_XML_MARQUES_BANC As CSXml = New CSXml("." & "\config\bancs\marques.xml")
    ' Buses
    Public GLOB_XML_MARQUES_BUSES As CSXml = New CSXml("." & "\config\buses\marques.xml")
    Public GLOB_XML_MODELES_BUSES As CSXml = New CSXml("." & "\config\buses\modeles.xml")
    Public GLOB_XML_GENRES_BUSES As CSXml = New CSXml("." & "\config\buses\genres.xml")
    Public GLOB_XML_COULEURS_BUSES As CSXml = New CSXml("." & "\config\buses\couleurs.xml")
    Public GLOB_XML_TYPES_BUSES As CSXml = New CSXml("." & "\config\buses\types.xml")
    Public GLOB_XML_ANGLES_BUSES As CSXml = New CSXml("." & "\config\buses\angles.xml")
    Public GLOB_XML_REFER_BUSES As CSXml = New CSXml("." & "\config\buses\buses.xml")
    Public GLOB_XML_FONCTIONNEMENTBUSES_BUSES As CSXml = New CSXml("." & "\config\buses\fonctionnement.xml")
    Public GLOB_ARR_MARQUES_BUSES() As String
    Public GLOB_ARR_MODELES_BUSES() As String
    Public GLOB_ARR_TYPES_BUSES() As String

    ' Manometres
    Public GLOB_XML_MARQUES_MANO As CSXml = New CSXml("." & "\config\manometres\marques.xml")
    Public GLOB_XML_MODELES_MANO As CSXml = New CSXml("." & "\config\manometres\modeles.xml")
    Public GLOB_XML_CLASSES_MANO As CSXml = New CSXml("." & "\config\manometres\classes.xml")
    Public GLOB_XML_FONDECHELLE_MANO As CSXml = New CSXml("." & "\config\manometres\fondEchelle.xml")
    Public GLOB_ARR_MARQUES_MANO() As String
    Public GLOB_ARR_MODELES_MANO() As String

    ' Manometres de contrôle
    Public GLOB_XML_MARQUES_MANOCONT As CSXml = New CSXml("." & "\config\manometres-controle\marques.xml")
    Public GLOB_XML_MODELES_MANOCONT As CSXml = New CSXml("." & "\config\manometres-controle\modeles.xml")
    Public GLOB_XML_CLASSES_MANOCONT As CSXml = New CSXml("." & "\config\manometres-controle\classes.xml")
    Public GLOB_XML_FONDECHELLE_MANOCONT As CSXml = New CSXml("." & "\config\manometres-controle\fondEchelle.xml")
    Public GLOB_ARR_MARQUES_MANOCONT() As String
    Public GLOB_ARR_MODELES_MANOCONT() As String
    ' Manometres étalon
    Public GLOB_XML_MARQUES_MANOETA As CSXml = New CSXml("." & "\config\manometres-etalon\marques.xml")
    Public GLOB_XML_MODELES_MANOETA As CSXml = New CSXml("." & "\config\manometres-etalon\modeles.xml")
    Public GLOB_XML_CLASSES_MANOETA As CSXml = New CSXml("." & "\config\manometres-etalon\classes.xml")
    Public GLOB_XML_FONDECHELLE_MANOETA As CSXml = New CSXml("." & "\config\manometres-etalon\fondEchelle.xml")
    Public GLOB_ARR_MARQUES_MANOETA() As String
    Public GLOB_ARR_MODELES_MANOETA() As String

    ' Pulvérisateurs
    Public GLOB_XML_MARQUES_MODELES_PULVE As CSXml = New CSXml(My.Settings.RepertoireParametres & "\ReferentielPulverisateurMarquesModeles.xml")
    Public GLOB_XML_TYPES_CATEGORIES_PULVE As CSXml = New CSXml(My.Settings.RepertoireParametres & "\ReferentielPulverisateurTypesCategories.xml")
    Public GLOB_XML_ATTELAGE_PULVE As CSXml = New CSXml(My.Settings.RepertoireParametres & "\Attelage.xml")
    Public GLOB_XML_PULVERISATION_PULVE As CSXml = New CSXml(My.Settings.RepertoireParametres & "\Pulverisation.xml")
    Public GLOB_XML_REGULATION_PULVE As CSXml = New CSXml("." & "\" & My.Settings.RepertoireParametres & "\PulverisateurRegulation.xml")
    Public GLOB_XML_EMPLACEMENTIDENTIFICATION As CSXml = New CSXml(My.Settings.RepertoireParametres & "\EmplacementIdentification.xml")
    Public GLOB_XML_MODEUTILISATION As CSXml = New CSXml(My.Settings.RepertoireParametres & "\PulverisateurModeUtilisation.xml")

    Public GLOB_ARR_MARQUES_PULVE() As String
    Public GLOB_ARR_MODELES_PULVE() As String
    Public GLOB_ARR_TYPES_PULVE() As String
    Public GLOB_ARR_CLASSES_PULVE() As String
    Public GLOB_STR_REFERENTIELBUSES_FILENAME As String = My.Settings.RepertoireParametres & "\referentiel_buse.csv"
    Public GLOB_STR_COMMUNES_FILENAME As String = My.Settings.RepertoireParametres & "\base_officielle_codes_postaux.csv"

    ' Territoires
    Public GLOB_XML_TERRITOIRES As CSXml = New CSXml("." & "\config\territoire.xml")
    Public GLOB_XML_CODESAPE As CSXml = New CSXml(My.Settings.RepertoireParametres & "\ReferentielCodesAPE.xml")

#End Region



#Region " PATHS "

    ' Public
    Public CONST_PATH_PUBLIC As String = "." & "\public\"
    ' Documents
    Public CONST_PATH_DOCS As String = CONST_PATH_PUBLIC & "docs\"
    ' Exports
    Public CONST_PATH_EXP As String = CONST_PATH_PUBLIC & "exports\"

    ' Images
    Public CONST_PATH_IMG As String = "." & "\img\"

    ' Temp
    Public CONST_PATH_TMP As String = "." & "\tmp\"


#End Region

#Region " Nom des documents "

    ' Logo module facturation
    Public CR_LOGO_DEFAULT_NAME As String = "nologo.jpg"
    Public CR_LOGO_DEFAULT_TN_NAME As String = "nologo_tn.jpg"
    Public CR_LOGO_NAME As String = "CR_logo.jpg"
    Public CR_LOGO_TN_NAME As String = "CR_logo_tn.jpg"
    Public CR_LOGO_TN2_NAME As String = "CR_logo_tn2.jpg"

    ' Template Facture
    Public CONST_DOC_FACTURE As String = "facture"
    ' Template BL
    Public CONST_DOC_BL As String = "bl"
    ' Template Contrat Commercial
    Public CONST_DOC_CONTCOM As String = "contrat_commercial"
    ' Rapports d'inspection
    'Public CONST_DOC_RAPINSP As String = "rapport_inspection"
    Public CONST_DOC_RAPINSP_COMPLET As String = "rapport_inspection_complet"
    Public CONST_DOC_RAPINSP_COMPLET_2P As String = "rapport_inspection_complet_2p"
    Public CONST_DOC_RAPINSP_CONTREVISITE As String = "rapport_inspection_ContreVisite"
    Public CONST_DOC_RAPINSP_CONTREVISITE_2P As String = "rapport_inspection_ContreVisite_2p"
    ' Rapport d'inspection 2 pages
    'Public CONST_DOC_RAPINSP2 As String = "rapport_inspection_2p"
    ' Feuille pédagogique
    Public CONST_DOC_FPEDA As String = "feuille_pedagogique"
    ' Enquete satisfaction
    Public CONST_DOC_ENQSAT As String = "enquete_satisfaction"
    ' Template Fiche Terrain Rampe
    Public CONST_DOC_FICHETERRAIN_RAMPE As String = "fiche_terrain_rampe.pdf"
    ' Template Fiche Terrain Arbo/viti
    Public CONST_DOC_FICHETERRAIN_ARBOVITI As String = "fiche_terrain_arbo-viti.pdf"
    ' Template Fiche de vie mano controle
    Public CONST_DOC_FV_MANOCTRL As String = "ficheVie_mano"
    ' Template Fiche de vie banc
    Public CONST_DOC_FV_BANC As String = "ficheVie_banc"
    ''' <summary>
    ''' Symbole decimal utilisé par l'application
    ''' </summary>
    ''' <remarks></remarks>
    Public CONST_DECIMAL_SYMBOL = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

#End Region


#Region " Constantes (Messages d'info.) "

#Region " Messages d'information "

    '###########################################
    '#####     Messages d'information      #####
    '###########################################
    ' Contrôle d'un banc de mesure
    '###########################################
    Public Const CONST_INFO_CTRLBANC_ERR_NOTEMP = "        Vous devez renseigner les températures de l'air et de l'eau."
    Public Const CONST_INFO_CTRLBANC_ERR_5BUSES = "        Vous devez sélectionner 5 buses minimum."
    Public Const CONST_INFO_CTRLBANC_ERR_NOVERIFNUM = "        Vous devez renseigner un numéro de vérification."
    Public Const CONST_INFO_CTRLBANC_ERR_NOBANCNUM = "        Vous devez renseigner un numéro de banc à contrôler."
    Public Const CONST_INFO_CTRLBANC_MSG_CONTROLOK = "        Contrôle OK"
    Public Const CONST_INFO_CTRLBANC_MSG_CONTROLNOK = "        Contrôle NOK"

#End Region

#Region " Messages barre de statut "

    '###########################################
    '#####    Messages barre de statut     #####
    '###########################################
    ' Alertes en page d'accueil
    '###########################################
    Public Const CONST_STATUTMSG_ALERTES_MANOETALON_LOAD = "        Vérification des alertes sur les manomètres étalons..."
    Public Const CONST_STATUTMSG_ALERTES_MANOCONTROLE_LOAD = "        Vérification des alertes sur les manomètres de contrôle..."
    Public Const CONST_STATUTMSG_ALERTES_BUSESETALON_LOAD = "        Vérification des alertes sur les buses étalons..."
    Public Const CONST_STATUTMSG_ALERTES_BANC_LOAD = "        Vérification des alertes sur les bancs de mesure..."
    Public Const CONST_STATUTMSG_ALERTES_CLIENTS_LOAD = "        Vérification des alertes sur les clients..."
    Public Const CONST_STATUTMSG_ALERTES_SYNCHRO_LOAD = "        Vérification des alertes sur la synchronisation..."
    '###########################################

    '###########################################
    ' Login
    '###########################################
    Public Const CONST_STATUTMSG_LOGIN_ENCOURS = "        Connexion en cours..."
    Public Const CONST_STATUTMSG_LOGIN_OK = "        Connexion réussie."
    Public Const CONST_STATUTMSG_LOGIN_FAILED = "        [Erreur] - Echec de la connexion à votre profil."
    '###########################################

    '###########################################
    ' Ajout d'un Agent
    '###########################################
    Public Const CONST_STATUTMSG_ADDAGENT_ENCOURS = "        Ajout d'un nouveau profil en cours..."
    Public Const CONST_STATUTMSG_ADDAGENT_LINK_ENCOURS = "        Connexion au serveur en cours..."
    Public Const CONST_STATUTMSG_ADDAGENT_LOAD_ENCOURS = "        Chargement du profil en cours..."
    Public Const CONST_STATUTMSG_ADDAGENT_VERIF_ENCOURS = "        Vérifications en cours..."
    Public Const CONST_STATUTMSG_ADDAGENT_ERROR_EXISTS = "        [Erreur] - Echec de récupération du profil : Cet inspecteur est déjà présent en base."
    Public Const CONST_STATUTMSG_ADDAGENT_ERROR_PASSNOTMATCH = "        [Erreur] - Echec de récupération du profil : Les mots de passe ne correspondent pas."
    Public Const CONST_STATUTMSG_ADDAGENT_ERROR_NOPROFIL = "        [Erreur] - Echec de récupération du profil : Ce profil n'existe pas."
    Public Const CONST_STATUTMSG_ADDAGENT_ERROR_NOTCONNECT = "        [Erreur] - Echec de récupération du profil : Connection introuvable."
    Public Const CONST_STATUTMSG_ADDAGENT_OK = "        Sauvegarde réussie."
    '###########################################

    '###########################################
    ' Parametrage Agent
    '###########################################
    Public Const CONST_STATUTMSG_FICHEAGENT_ENCOURS = "        Sauvegarde de vos données en cours..."
    Public Const CONST_STATUTMSG_FICHEAGENT_OK = "        Sauvegarde réussie."
    Public Const CONST_STATUTMSG_FICHEAGENT_FAILED = "        [Erreur] - Echec de la sauvegarde de vos données."
    '###########################################

    '###########################################
    ' Listing clients
    '###########################################
    Public Const CONST_STATUTMSG_LISTCLIENT_ENCOURS = "        Chargement des clients en cours..."
    Public Const CONST_STATUTMSG_LISTCLIENT_OK = " clients correctement chargés."
    '###########################################

    '###########################################
    ' Parametrage Client
    '###########################################
    Public Const CONST_STATUTMSG_FICHECLIENT_ENCOURS = "        Sauvegarde de vos données client en cours..."
    Public Const CONST_STATUTMSG_FICHECLIENT_OK = "        Sauvegarde du client réussie."
    Public Const CONST_STATUTMSG_FICHECLIENT_FAILED = "        [Erreur] - Echec de la sauvegarde de vos données client."
    '###########################################

    '###########################################
    ' Supression Client
    '###########################################
    Public Const CONST_STATUTMSG_DELETECLIENT_ENCOURS = "        Suppression du client en cours..."
    Public Const CONST_STATUTMSG_DELETECLIENT_OK = "        Suppression du client réussie."
    Public Const CONST_STATUTMSG_DELETECLIENT_FAILED = "        [Erreur] - Echec de la suppression du client."
    Public Const CONST_STATUTMSG_DELETECLIENT_CANCEL = "        Suppression du client annulée par l'utilisateur."
    Public Const CONST_STATUTMSG_DELETECLIENT_NOSELECTED = "        Vous devez d'abord sélectionner un client dans la liste."
    '###########################################

    '###########################################
    ' Listing pulvérisateurs
    '###########################################
    Public Const CONST_STATUTMSG_LISTPULVE_ENCOURS = "        Chargement des pulvérisateurs en cours..."
    Public Const CONST_STATUTMSG_LISTPULVE_OK = " pulvérisateurs correctement chargés."
    '###########################################

    '###########################################
    ' Parametrage pulvérisateur
    '###########################################
    Public Const CONST_STATUTMSG_EDITPULVE_ENCOURS = "        Sauvegarde du pulvérisateur en cours..."
    Public Const CONST_STATUTMSG_EDITPULVE_OK = "        Sauvegarde du pulvérisateur réussie."
    Public Const CONST_STATUTMSG_EDITPULVE_FAILED = "        [Erreur] - Echec de la sauvegarde du pulvérisateur."
    '###########################################

    '###########################################
    ' Supression pulvérisateur
    '###########################################
    Public Const CONST_STATUTMSG_DELETEPULVE_ENCOURS = "        Suppression du pulvérisateur en cours..."
    Public Const CONST_STATUTMSG_DELETEPULVE_OK = "        Suppression du pulvérisateur réussie."
    Public Const CONST_STATUTMSG_DELETEPULVE_FAILED = "        [Erreur] - Suppression du pulvérisateur impossible, présence de contrôles."
    Public Const CONST_STATUTMSG_DELETEPULVE_CANCEL = "        Suppression du pulvérisateur annulée par l'utilisateur."
    Public Const CONST_STATUTMSG_DELETEPULVE_NOSELECTED = "        Vous devez d'abord sélectionner un pulvérisateur dans la liste."
    '###########################################

    '###########################################
    ' Parametrage Structure
    '###########################################
    Public Const CONST_STATUTMSG_FICHESTRUCTURE_ENCOURS = "        Sauvegarde de vos données en cours..."
    Public Const CONST_STATUTMSG_FICHESTRUCTURE_OK = "        Sauvegarde réussie."
    Public Const CONST_STATUTMSG_FICHESTRUCTURE_FAILED = "        [Erreur] - Echec de la Sauvegarde de vos données."
    '###########################################

    '###########################################
    ' Synchronisation
    '###########################################
    Public Const CONST_STATUTMSG_SYNCHRO_ENCOURS = "        Synchronisation avec le Crodip en cours..."
    Public Const CONST_STATUTMSG_SYNCHRO_OK = " éléments ont été synchronisés."
    Public Const CONST_STATUTMSG_SYNCHRO_EMPTY = "        Aucun élément à synchroniser."
    Public Const CONST_STATUTMSG_SYNCHRO_FAILED = "        [Erreur] - Echec de la synchronisation avec le Crodip."
    Public Const CONST_STATUTMSG_SYNCHRO_UNAVAILABLE = "        Synchronisation impossible, serveur Crodip momentanément indisponible."
    '###########################################

    '###########################################
    ' Contrôle
    '###########################################
    Public Const CONST_STATUTMSG_DIAG_VERIFCLI = "Vérification des informations du client."
    Public Const CONST_STATUTMSG_DIAG_TARIFS = "Saisie des tarifs."
    Public Const CONST_STATUTMSG_DIAG_CONTROLEPRE = "Contrôle préliminaire."
    Public Const CONST_STATUTMSG_DIAG_ENCOURS = "Contrôle pulvé en cours..."
    Public Const CONST_STATUTMSG_DIAG_SAVING = "Enregistrement en cours..."
    Public Const CONST_STATUTMSG_DIAG_SAVED = "Contrôle correctement enregistré."
    '###########################################

#End Region

#End Region

    Public Sub Init()
        My.Settings.Reload()
        GLOB_ENV_AUTOSYNC = My.Settings.AutoSync
        GLOB_APPLI_VERSION = My.Settings.NumVersion
        GLOB_APPLI_BUILD = My.Settings.NumBuild

    End Sub
    Public Function StringToDouble(pInputString As String) As Double
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

            dValue = StringToDouble(pInputString)
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
End Module
