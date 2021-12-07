Imports System.Collections.Generic
Imports System.IO
Imports Ionic.Zip

Public Class accueil
    Inherits frmCRODIP
    Implements IObservateur


    ' Filtre les clients qui ont des alertes ou non
    Private m_Exploitation_isShowAll As Boolean = False
    'Liste Sortable conteant les pulvé
    Private m_BindingListOfPulve As SortableBindingList(Of Pulverisateur)


    Friend WithEvents btn_InitLog As System.Windows.Forms.Label
    Friend WithEvents laNomStructure2 As System.Windows.Forms.Label
    Friend WithEvents laNomAgent2 As System.Windows.Forms.Label
    Friend WithEvents cbxAnneeReference As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents lla_Rappeltolérance As System.Windows.Forms.LinkLabel
    Friend WithEvents btnSupprPulve As System.Windows.Forms.Button
    Friend WithEvents btnFichePulve As System.Windows.Forms.Button
    Friend WithEvents btnAjoutPulve As System.Windows.Forms.Button
    Friend WithEvents btnTransfertPulve As System.Windows.Forms.Button
    Friend WithEvents lblIdentifiantPulve As System.Windows.Forms.Label
    Friend WithEvents ImageListPulve As System.Windows.Forms.ImageList
    Friend WithEvents m_bsrcPulverisateurTMP As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents panel_clientele_LstCtrlCtriteres As System.Windows.Forms.Panel
    Friend WithEvents pnl_SearchDates As System.Windows.Forms.Panel
    Friend WithEvents dtpSearchCrit2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchCrit1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_refresh_lst_clients As System.Windows.Forms.Label
    Friend WithEvents btn_refresh_lst_clients As System.Windows.Forms.PictureBox
    Friend WithEvents btn_proprietaire_exportCsv As System.Windows.Forms.Label
    Friend WithEvents btn_proprietaire_derniersControles As System.Windows.Forms.Label
    Friend WithEvents btn_rechercher_exploitant As System.Windows.Forms.PictureBox
    Friend WithEvents pct_LogoControle As System.Windows.Forms.PictureBox
    Friend WithEvents title_alertes As System.Windows.Forms.Label
    Friend WithEvents list_search_fieldSearch As System.Windows.Forms.ComboBox
    Friend WithEvents client_search_query As System.Windows.Forms.TextBox
    Friend WithEvents btn_proprietaire_supprimer As System.Windows.Forms.Label
    Friend WithEvents btn_proprietaire_rechercher As System.Windows.Forms.Label
    Friend WithEvents btn_proprietaire_voirFiche As System.Windows.Forms.Label
    Friend WithEvents btn_proprietaire_pulveListe As System.Windows.Forms.Label
    Friend WithEvents btn_proprietaire_ajouter As System.Windows.Forms.Label
    Friend WithEvents dgvPulveExploit As System.Windows.Forms.DataGridView
    Friend WithEvents btnMAJPulverisateurs As System.Windows.Forms.Button
    Friend WithEvents IconPulveCol As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents NumeroNationalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarqueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModeleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreBusesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CapaciteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AttelageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnneeAchatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateProchainControleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IconPulveColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PulvePrincipalNumNatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnParamModeSimplifie As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnMAJsynchroAgent As Button
    Friend WithEvents grpParamSynhcro As GroupBox
    Friend WithEvents ckSynchroDESC As CheckBox
    Friend WithEvents ckSynchroASC As CheckBox
    Friend WithEvents Btn_SynhcroDiag As Label
    Friend WithEvents tbNumDiag As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lbSynhcroCourante As ListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_LieuxControle As Label
    Friend WithEvents tabControl_Facturation As TabPage
    Friend WithEvents btn_Facturation As Label


#Region " Code généré par le Concepteur Windows Form "
    Private m_bDuringLoad As Boolean
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()


        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        'Je ne sais pourquoi mais le style des entête change souvent tout seul
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPulveExploit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabControl_accueil As System.Windows.Forms.TabPage
    Friend WithEvents tabControl_clientele As System.Windows.Forms.TabPage
    Friend WithEvents tabControl_pulverisateurs As System.Windows.Forms.TabPage
    Friend WithEvents tabControl_synchro As System.Windows.Forms.TabPage
    Friend WithEvents tabControl_outilscomp As System.Windows.Forms.TabPage
    Friend WithEvents tabControl_parametrage As System.Windows.Forms.TabPage
    Friend WithEvents tabAccueil_mesinfos As System.Windows.Forms.Panel
    Friend WithEvents pctLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents listClients_col_siren As System.Windows.Forms.ColumnHeader
    Friend WithEvents listClients_col_rs As System.Windows.Forms.ColumnHeader
    Friend WithEvents listClients_col_prenom As System.Windows.Forms.ColumnHeader
    Friend WithEvents listClients_col_nom As System.Windows.Forms.ColumnHeader
    Friend WithEvents listClients_col_ProchainControle As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents pctLogoParametrage As System.Windows.Forms.PictureBox
    Friend WithEvents pctLogoSynchro As System.Windows.Forms.PictureBox
    Friend WithEvents title_mesInfos As System.Windows.Forms.Label
    Friend WithEvents title_mesAlertes As System.Windows.Forms.Label
    Friend WithEvents title_listSynchro As System.Windows.Forms.Label
    Friend WithEvents title_parametrage As System.Windows.Forms.Label
    Friend WithEvents lbl_mesInfos_idCrodip As System.Windows.Forms.Label
    Friend WithEvents lbl_mesInfos_nom As System.Windows.Forms.Label
    Friend WithEvents lbl_mesInfos_prenom As System.Windows.Forms.Label
    Friend WithEvents lbl_mesInfos_dateDerniereUtilisation As System.Windows.Forms.Label
    Friend WithEvents lbl_mesInfos_dateDernièreConnexion As System.Windows.Forms.Label
    Friend WithEvents list_clients As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents panel_ListeDesControles As System.Windows.Forms.Panel
    Friend WithEvents panel_clientele_ficheClient As System.Windows.Forms.Panel
    Friend WithEvents grp_ficheClient_ListePulve As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_infosAgent_IdCrodip As System.Windows.Forms.Label
    Friend WithEvents lbl_infosAgent_Nom As System.Windows.Forms.Label
    Friend WithEvents lbl_infosAgent_Prenom As System.Windows.Forms.Label
    Friend WithEvents lstPulves_client_proprioSiren As System.Windows.Forms.Label
    Friend WithEvents lstPulves_client_raisonSociale As System.Windows.Forms.Label
    Friend WithEvents lbl_infosAgent_dateDernCnx As System.Windows.Forms.Label
    Friend WithEvents lbl_infosAgent_dateDernSynchro As System.Windows.Forms.Label
    Friend WithEvents listClients_col_commune As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pctLogoOutilComp As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblModuledocumentaire As System.Windows.Forms.Label
    Friend WithEvents ImageList_synchro As System.Windows.Forms.ImageList
    Friend WithEvents accueil_panelAlertesContener As System.Windows.Forms.Panel
    Friend WithEvents accueil_panelAlertes As System.Windows.Forms.Panel
    Friend WithEvents btn_synchro_run As System.Windows.Forms.Label
    Friend WithEvents btn_parametrage_coordonneesOrganisme As System.Windows.Forms.Label
    Friend WithEvents btn_parametrage_coordonneesInspecteur As System.Windows.Forms.Label
    Friend WithEvents btn_parametrage_tarifs As System.Windows.Forms.Label
    Friend WithEvents btn_parametrage_parametrageManometre As System.Windows.Forms.Label
    Friend WithEvents btn_parametrage_verificationManometres As System.Windows.Forms.Label
    Friend WithEvents btn_parametrage_verificationBancs As System.Windows.Forms.Label
    Friend WithEvents btn_parametrage_parametrageBuses As System.Windows.Forms.Label
    Friend WithEvents btn_parametrage_parametrageBancs As System.Windows.Forms.Label
    Friend WithEvents lblParametresOrganisme As System.Windows.Forms.Label
    Friend WithEvents lblParametrageAppareilsMesures As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_outilsComplementaires_calcVolumeHectare As System.Windows.Forms.Label
    Friend WithEvents btn_outilsComplementaires_calcDebitBuses As System.Windows.Forms.Label
    Friend WithEvents btn_ficheClient_voirFiche As System.Windows.Forms.Label
    Friend WithEvents btn_ficheClient_retour As System.Windows.Forms.Label
    Friend WithEvents btn_ficheClient_diagnostic_nouveau As System.Windows.Forms.Label
    Friend WithEvents btn_ficheClient_diagnostic_nouvelleCV As System.Windows.Forms.Label
    Friend WithEvents btn_ficheClient_diagnostic_voir As System.Windows.Forms.Label
    Friend WithEvents ImageList_onglets As System.Windows.Forms.ImageList
    Friend WithEvents listClients_col_adresse As System.Windows.Forms.ColumnHeader
    Friend WithEvents listClients_col_codePostal As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList_refresh As System.Windows.Forms.ImageList
    Friend WithEvents picsRefresh As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents listPulverisateurs As System.Windows.Forms.ListView
    Friend WithEvents col_idPulve As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_typePulve As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_marquePulve As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_raisonSociale As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_prenom As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_nom As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_codePostal As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_commune As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_dateDernierControle As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_conclusion As System.Windows.Forms.ColumnHeader
    Friend WithEvents listPulve_lbl_refreshList As System.Windows.Forms.Label
    Friend WithEvents listPulve_btn_refreshList As System.Windows.Forms.PictureBox
    Friend WithEvents listPulve_btn_exportCsv As System.Windows.Forms.Label
    Friend WithEvents btn_lstPulve_voirFiche As System.Windows.Forms.Label
    Friend WithEvents bsControleQuotidien As System.Windows.Forms.BindingSource
    Friend WithEvents OKDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NOKDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblMaterielsSupprimes As System.Windows.Forms.Label
    Friend WithEvents m_SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dtp_ControleRegulier As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btn_controleQuotdien_Exporter As System.Windows.Forms.Button
    Friend WithEvents btn_controleQuotdien_Valider As System.Windows.Forms.Button
    Friend WithEvents dgv_ControleRegulier As System.Windows.Forms.DataGridView
    Friend WithEvents TypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isOK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents isNOK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents isNonEffectue As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btn_imprimerDoc As System.Windows.Forms.Label
    Friend WithEvents SplitContainer_ModuleDocumentaire As System.Windows.Forms.SplitContainer
    Friend WithEvents tv_Docs As System.Windows.Forms.TreeView
    Friend WithEvents ImageList_Docs As System.Windows.Forms.ImageList
    Friend WithEvents lv_Docs As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pctbx_Docs_refresh As System.Windows.Forms.PictureBox
    Friend WithEvents tabControl_Statistiques As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pctLogoStat As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bsStatistiques As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents laNomAgent As System.Windows.Forms.Label
    Friend WithEvents laNomStructure As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents btn_parametrage_facturation As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(accueil))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ImageList_synchro = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList_Docs = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList_onglets = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageListPulve = New System.Windows.Forms.ImageList(Me.components)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList_refresh = New System.Windows.Forms.ImageList(Me.components)
        Me.m_SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabControl_accueil = New System.Windows.Forms.TabPage()
        Me.accueil_panelAlertesContener = New System.Windows.Forms.Panel()
        Me.lla_Rappeltolérance = New System.Windows.Forms.LinkLabel()
        Me.dtp_ControleRegulier = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btn_controleQuotdien_Exporter = New System.Windows.Forms.Button()
        Me.btn_controleQuotdien_Valider = New System.Windows.Forms.Button()
        Me.dgv_ControleRegulier = New System.Windows.Forms.DataGridView()
        Me.TypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isOK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.isNOK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.isNonEffectue = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsControleQuotidien = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.picsRefresh = New System.Windows.Forms.PictureBox()
        Me.accueil_panelAlertes = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.title_mesAlertes = New System.Windows.Forms.Label()
        Me.tabAccueil_mesinfos = New System.Windows.Forms.Panel()
        Me.lbl_infosAgent_dateDernCnx = New System.Windows.Forms.Label()
        Me.lbl_infosAgent_IdCrodip = New System.Windows.Forms.Label()
        Me.pctLogo = New System.Windows.Forms.PictureBox()
        Me.lbl_mesInfos_dateDernièreConnexion = New System.Windows.Forms.Label()
        Me.lbl_mesInfos_dateDerniereUtilisation = New System.Windows.Forms.Label()
        Me.lbl_mesInfos_prenom = New System.Windows.Forms.Label()
        Me.lbl_mesInfos_nom = New System.Windows.Forms.Label()
        Me.lbl_mesInfos_idCrodip = New System.Windows.Forms.Label()
        Me.title_mesInfos = New System.Windows.Forms.Label()
        Me.lbl_infosAgent_Nom = New System.Windows.Forms.Label()
        Me.lbl_infosAgent_Prenom = New System.Windows.Forms.Label()
        Me.lbl_infosAgent_dateDernSynchro = New System.Windows.Forms.Label()
        Me.tabControl_clientele = New System.Windows.Forms.TabPage()
        Me.panel_clientele_ficheClient = New System.Windows.Forms.Panel()
        Me.grp_ficheClient_ListePulve = New System.Windows.Forms.GroupBox()
        Me.dgvPulveExploit = New System.Windows.Forms.DataGridView()
        Me.IconPulveCol = New System.Windows.Forms.DataGridViewImageColumn()
        Me.NumeroNationalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModeleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreBusesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CapaciteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AttelageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnneeAchatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateProchainControleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IconPulveColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulvePrincipalNumNatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_bsrcPulverisateurTMP = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnTransfertPulve = New System.Windows.Forms.Button()
        Me.btnAjoutPulve = New System.Windows.Forms.Button()
        Me.btnFichePulve = New System.Windows.Forms.Button()
        Me.btnSupprPulve = New System.Windows.Forms.Button()
        Me.btn_ficheClient_diagnostic_nouveau = New System.Windows.Forms.Label()
        Me.btn_ficheClient_diagnostic_nouvelleCV = New System.Windows.Forms.Label()
        Me.btn_ficheClient_diagnostic_voir = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstPulves_client_proprioSiren = New System.Windows.Forms.Label()
        Me.lstPulves_client_raisonSociale = New System.Windows.Forms.Label()
        Me.btn_ficheClient_voirFiche = New System.Windows.Forms.Label()
        Me.btn_ficheClient_retour = New System.Windows.Forms.Label()
        Me.panel_ListeDesControles = New System.Windows.Forms.Panel()
        Me.list_clients = New System.Windows.Forms.ListView()
        Me.listClients_col_siren = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listClients_col_rs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listClients_col_prenom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listClients_col_nom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listClients_col_adresse = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listClients_col_codePostal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listClients_col_commune = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listClients_col_ProchainControle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panel_clientele_LstCtrlCtriteres = New System.Windows.Forms.Panel()
        Me.pnl_SearchDates = New System.Windows.Forms.Panel()
        Me.dtpSearchCrit2 = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.dtpSearchCrit1 = New System.Windows.Forms.DateTimePicker()
        Me.lbl_refresh_lst_clients = New System.Windows.Forms.Label()
        Me.btn_refresh_lst_clients = New System.Windows.Forms.PictureBox()
        Me.btn_proprietaire_exportCsv = New System.Windows.Forms.Label()
        Me.btn_rechercher_exploitant = New System.Windows.Forms.PictureBox()
        Me.pct_LogoControle = New System.Windows.Forms.PictureBox()
        Me.title_alertes = New System.Windows.Forms.Label()
        Me.list_search_fieldSearch = New System.Windows.Forms.ComboBox()
        Me.client_search_query = New System.Windows.Forms.TextBox()
        Me.btn_proprietaire_supprimer = New System.Windows.Forms.Label()
        Me.btn_proprietaire_rechercher = New System.Windows.Forms.Label()
        Me.btn_proprietaire_voirFiche = New System.Windows.Forms.Label()
        Me.btn_proprietaire_pulveListe = New System.Windows.Forms.Label()
        Me.btn_proprietaire_ajouter = New System.Windows.Forms.Label()
        Me.btn_proprietaire_derniersControles = New System.Windows.Forms.Label()
        Me.tabControl_pulverisateurs = New System.Windows.Forms.TabPage()
        Me.btn_lstPulve_voirFiche = New System.Windows.Forms.Label()
        Me.listPulve_btn_exportCsv = New System.Windows.Forms.Label()
        Me.listPulve_lbl_refreshList = New System.Windows.Forms.Label()
        Me.listPulve_btn_refreshList = New System.Windows.Forms.PictureBox()
        Me.listPulverisateurs = New System.Windows.Forms.ListView()
        Me.col_idPulve = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_typePulve = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_marquePulve = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_raisonSociale = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_prenom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_nom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_codePostal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_commune = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_dateDernierControle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_conclusion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tabControl_synchro = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Btn_SynhcroDiag = New System.Windows.Forms.Label()
        Me.tbNumDiag = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbSynhcroCourante = New System.Windows.Forms.ListBox()
        Me.grpParamSynhcro = New System.Windows.Forms.GroupBox()
        Me.ckSynchroDESC = New System.Windows.Forms.CheckBox()
        Me.ckSynchroASC = New System.Windows.Forms.CheckBox()
        Me.btn_InitLog = New System.Windows.Forms.Label()
        Me.btn_synchro_run = New System.Windows.Forms.Label()
        Me.pctLogoSynchro = New System.Windows.Forms.PictureBox()
        Me.title_listSynchro = New System.Windows.Forms.Label()
        Me.tabControl_outilscomp = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnMAJsynchroAgent = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnParamModeSimplifie = New System.Windows.Forms.Button()
        Me.btnMAJPulverisateurs = New System.Windows.Forms.Button()
        Me.pctbx_Docs_refresh = New System.Windows.Forms.PictureBox()
        Me.SplitContainer_ModuleDocumentaire = New System.Windows.Forms.SplitContainer()
        Me.tv_Docs = New System.Windows.Forms.TreeView()
        Me.lv_Docs = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_imprimerDoc = New System.Windows.Forms.Label()
        Me.btn_outilsComplementaires_calcVolumeHectare = New System.Windows.Forms.Label()
        Me.pctLogoOutilComp = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblModuledocumentaire = New System.Windows.Forms.Label()
        Me.btn_outilsComplementaires_calcDebitBuses = New System.Windows.Forms.Label()
        Me.tabControl_parametrage = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btn_LieuxControle = New System.Windows.Forms.Label()
        Me.lblIdentifiantPulve = New System.Windows.Forms.Label()
        Me.lblMaterielsSupprimes = New System.Windows.Forms.Label()
        Me.btn_parametrage_facturation = New System.Windows.Forms.Label()
        Me.lblParametresOrganisme = New System.Windows.Forms.Label()
        Me.pctLogoParametrage = New System.Windows.Forms.PictureBox()
        Me.title_parametrage = New System.Windows.Forms.Label()
        Me.lblParametrageAppareilsMesures = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btn_parametrage_tarifs = New System.Windows.Forms.Label()
        Me.btn_parametrage_coordonneesOrganisme = New System.Windows.Forms.Label()
        Me.btn_parametrage_coordonneesInspecteur = New System.Windows.Forms.Label()
        Me.btn_parametrage_parametrageManometre = New System.Windows.Forms.Label()
        Me.btn_parametrage_parametrageBuses = New System.Windows.Forms.Label()
        Me.btn_parametrage_parametrageBancs = New System.Windows.Forms.Label()
        Me.btn_parametrage_verificationManometres = New System.Windows.Forms.Label()
        Me.btn_parametrage_verificationBancs = New System.Windows.Forms.Label()
        Me.tabControl_Statistiques = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbxAnneeReference = New System.Windows.Forms.ComboBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.laNomAgent = New System.Windows.Forms.Label()
        Me.laNomStructure = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.bsStatistiques = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.laNomStructure2 = New System.Windows.Forms.Label()
        Me.laNomAgent2 = New System.Windows.Forms.Label()
        Me.pctLogoStat = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tabControl_Facturation = New System.Windows.Forms.TabPage()
        Me.btn_Facturation = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl.SuspendLayout()
        Me.tabControl_accueil.SuspendLayout()
        Me.accueil_panelAlertesContener.SuspendLayout()
        CType(Me.dgv_ControleRegulier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsControleQuotidien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picsRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.accueil_panelAlertes.SuspendLayout()
        Me.tabAccueil_mesinfos.SuspendLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl_clientele.SuspendLayout()
        Me.panel_clientele_ficheClient.SuspendLayout()
        Me.grp_ficheClient_ListePulve.SuspendLayout()
        CType(Me.dgvPulveExploit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcPulverisateurTMP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.panel_ListeDesControles.SuspendLayout()
        Me.panel_clientele_LstCtrlCtriteres.SuspendLayout()
        Me.pnl_SearchDates.SuspendLayout()
        CType(Me.btn_refresh_lst_clients, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_rechercher_exploitant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pct_LogoControle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl_pulverisateurs.SuspendLayout()
        CType(Me.listPulve_btn_refreshList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl_synchro.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.grpParamSynhcro.SuspendLayout()
        CType(Me.pctLogoSynchro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl_outilscomp.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pctbx_Docs_refresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer_ModuleDocumentaire, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_ModuleDocumentaire.Panel1.SuspendLayout()
        Me.SplitContainer_ModuleDocumentaire.Panel2.SuspendLayout()
        Me.SplitContainer_ModuleDocumentaire.SuspendLayout()
        CType(Me.pctLogoOutilComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl_parametrage.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.pctLogoParametrage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl_Statistiques.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.bsStatistiques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctLogoStat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl_Facturation.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList_synchro
        '
        Me.ImageList_synchro.ImageStream = CType(resources.GetObject("ImageList_synchro.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_synchro.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_synchro.Images.SetKeyName(0, "")
        Me.ImageList_synchro.Images.SetKeyName(1, "")
        '
        'ImageList_Docs
        '
        Me.ImageList_Docs.ImageStream = CType(resources.GetObject("ImageList_Docs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Docs.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Docs.Images.SetKeyName(0, "folder_closed_16x16.ico")
        Me.ImageList_Docs.Images.SetKeyName(1, "favicon-pdf.ico")
        Me.ImageList_Docs.Images.SetKeyName(2, "folder_open.ico")
        '
        'ImageList_onglets
        '
        Me.ImageList_onglets.ImageStream = CType(resources.GetObject("ImageList_onglets.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_onglets.TransparentColor = System.Drawing.Color.White
        Me.ImageList_onglets.Images.SetKeyName(0, "puce_h1.jpg")
        '
        'ImageListPulve
        '
        Me.ImageListPulve.ImageStream = CType(resources.GetObject("ImageListPulve.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListPulve.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListPulve.Images.SetKeyName(0, "PulvePrinc.PNG")
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "N° SIREN"
        Me.ColumnHeader1.Width = 117
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Raison sociale"
        Me.ColumnHeader2.Width = 317
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Prénom"
        Me.ColumnHeader3.Width = 161
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Nom"
        Me.ColumnHeader4.Width = 152
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "[...]"
        Me.ColumnHeader5.Width = 77
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Prochain contrôle"
        Me.ColumnHeader6.Width = 138
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "N° SIREN"
        Me.ColumnHeader8.Width = 117
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Raison sociale"
        Me.ColumnHeader9.Width = 190
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Nom de l’exploitation"
        Me.ColumnHeader10.Width = 156
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Prénom"
        Me.ColumnHeader11.Width = 117
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Nom"
        Me.ColumnHeader12.Width = 126
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Commune"
        Me.ColumnHeader13.Width = 137
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Prochain contrôle"
        Me.ColumnHeader14.Width = 138
        '
        'ImageList_refresh
        '
        Me.ImageList_refresh.ImageStream = CType(resources.GetObject("ImageList_refresh.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_refresh.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_refresh.Images.SetKeyName(0, "")
        Me.ImageList_refresh.Images.SetKeyName(1, "")
        '
        'm_SaveFileDialog
        '
        Me.m_SaveFileDialog.DefaultExt = "csv"
        Me.m_SaveFileDialog.Filter = "Fichiers CSV|*.csv"
        Me.m_SaveFileDialog.Title = "Répertoire d'export"
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabControl_accueil)
        Me.tabControl.Controls.Add(Me.tabControl_clientele)
        Me.tabControl.Controls.Add(Me.tabControl_pulverisateurs)
        Me.tabControl.Controls.Add(Me.tabControl_synchro)
        Me.tabControl.Controls.Add(Me.tabControl_outilscomp)
        Me.tabControl.Controls.Add(Me.tabControl_parametrage)
        Me.tabControl.Controls.Add(Me.tabControl_Statistiques)
        Me.tabControl.Controls.Add(Me.tabControl_Facturation)
        Me.tabControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabControl.HotTrack = True
        Me.tabControl.ImageList = Me.ImageList_onglets
        Me.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tabControl.ItemSize = New System.Drawing.Size(47, 18)
        Me.tabControl.Location = New System.Drawing.Point(0, 0)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(1008, 679)
        Me.tabControl.TabIndex = 0
        '
        'tabControl_accueil
        '
        Me.tabControl_accueil.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_accueil.Controls.Add(Me.accueil_panelAlertesContener)
        Me.tabControl_accueil.Controls.Add(Me.tabAccueil_mesinfos)
        Me.tabControl_accueil.ImageIndex = 0
        Me.tabControl_accueil.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_accueil.Name = "tabControl_accueil"
        Me.tabControl_accueil.Size = New System.Drawing.Size(1000, 653)
        Me.tabControl_accueil.TabIndex = 0
        Me.tabControl_accueil.Text = "Accueil"
        '
        'accueil_panelAlertesContener
        '
        Me.accueil_panelAlertesContener.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.accueil_panelAlertesContener.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.accueil_panelAlertesContener.Controls.Add(Me.lla_Rappeltolérance)
        Me.accueil_panelAlertesContener.Controls.Add(Me.dtp_ControleRegulier)
        Me.accueil_panelAlertesContener.Controls.Add(Me.Label20)
        Me.accueil_panelAlertesContener.Controls.Add(Me.btn_controleQuotdien_Exporter)
        Me.accueil_panelAlertesContener.Controls.Add(Me.btn_controleQuotdien_Valider)
        Me.accueil_panelAlertesContener.Controls.Add(Me.dgv_ControleRegulier)
        Me.accueil_panelAlertesContener.Controls.Add(Me.Label15)
        Me.accueil_panelAlertesContener.Controls.Add(Me.picsRefresh)
        Me.accueil_panelAlertesContener.Controls.Add(Me.accueil_panelAlertes)
        Me.accueil_panelAlertesContener.Controls.Add(Me.title_mesAlertes)
        Me.accueil_panelAlertesContener.Location = New System.Drawing.Point(0, 144)
        Me.accueil_panelAlertesContener.Name = "accueil_panelAlertesContener"
        Me.accueil_panelAlertesContener.Size = New System.Drawing.Size(1000, 512)
        Me.accueil_panelAlertesContener.TabIndex = 1
        '
        'lla_Rappeltolérance
        '
        Me.lla_Rappeltolérance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lla_Rappeltolérance.AutoSize = True
        Me.lla_Rappeltolérance.Location = New System.Drawing.Point(459, 374)
        Me.lla_Rappeltolérance.Name = "lla_Rappeltolérance"
        Me.lla_Rappeltolérance.Size = New System.Drawing.Size(164, 13)
        Me.lla_Rappeltolérance.TabIndex = 15
        Me.lla_Rappeltolérance.TabStop = True
        Me.lla_Rappeltolérance.Text = "Rappel des tolérances des buses"
        '
        'dtp_ControleRegulier
        '
        Me.dtp_ControleRegulier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtp_ControleRegulier.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_ControleRegulier.Location = New System.Drawing.Point(118, 225)
        Me.dtp_ControleRegulier.Name = "dtp_ControleRegulier"
        Me.dtp_ControleRegulier.Size = New System.Drawing.Size(87, 20)
        Me.dtp_ControleRegulier.TabIndex = 14
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(6, 229)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(107, 13)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Contrôle régulier du : "
        '
        'btn_controleQuotdien_Exporter
        '
        Me.btn_controleQuotdien_Exporter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_controleQuotdien_Exporter.Location = New System.Drawing.Point(459, 446)
        Me.btn_controleQuotdien_Exporter.Name = "btn_controleQuotdien_Exporter"
        Me.btn_controleQuotdien_Exporter.Size = New System.Drawing.Size(120, 27)
        Me.btn_controleQuotdien_Exporter.TabIndex = 12
        Me.btn_controleQuotdien_Exporter.Text = "Exporter"
        Me.btn_controleQuotdien_Exporter.UseVisualStyleBackColor = True
        '
        'btn_controleQuotdien_Valider
        '
        Me.btn_controleQuotdien_Valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_controleQuotdien_Valider.Location = New System.Drawing.Point(459, 414)
        Me.btn_controleQuotdien_Valider.Name = "btn_controleQuotdien_Valider"
        Me.btn_controleQuotdien_Valider.Size = New System.Drawing.Size(120, 26)
        Me.btn_controleQuotdien_Valider.TabIndex = 11
        Me.btn_controleQuotdien_Valider.Text = "Valider"
        Me.btn_controleQuotdien_Valider.UseVisualStyleBackColor = True
        '
        'dgv_ControleRegulier
        '
        Me.dgv_ControleRegulier.AllowUserToAddRows = False
        Me.dgv_ControleRegulier.AllowUserToDeleteRows = False
        Me.dgv_ControleRegulier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv_ControleRegulier.AutoGenerateColumns = False
        Me.dgv_ControleRegulier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_ControleRegulier.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_ControleRegulier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_ControleRegulier.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ControleRegulier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_ControleRegulier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ControleRegulier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TypeDataGridViewTextBoxColumn, Me.IdDataGridViewTextBoxColumn, Me.isOK, Me.isNOK, Me.isNonEffectue})
        Me.dgv_ControleRegulier.DataSource = Me.bsControleQuotidien
        Me.dgv_ControleRegulier.Location = New System.Drawing.Point(6, 251)
        Me.dgv_ControleRegulier.Name = "dgv_ControleRegulier"
        Me.dgv_ControleRegulier.RowHeadersWidth = 10
        Me.dgv_ControleRegulier.Size = New System.Drawing.Size(419, 252)
        Me.dgv_ControleRegulier.TabIndex = 10
        '
        'TypeDataGridViewTextBoxColumn
        '
        Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "TypeLibelle"
        Me.TypeDataGridViewTextBoxColumn.FillWeight = 50.0!
        Me.TypeDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
        Me.TypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "IdMateriel"
        Me.IdDataGridViewTextBoxColumn.FillWeight = 30.0!
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'isOK
        '
        Me.isOK.DataPropertyName = "isOK"
        Me.isOK.FillWeight = 10.0!
        Me.isOK.HeaderText = "OK"
        Me.isOK.Name = "isOK"
        '
        'isNOK
        '
        Me.isNOK.DataPropertyName = "isNOK"
        Me.isNOK.FillWeight = 10.0!
        Me.isNOK.HeaderText = "NOK"
        Me.isNOK.Name = "isNOK"
        '
        'isNonEffectue
        '
        Me.isNonEffectue.DataPropertyName = "isNonEffectue"
        Me.isNonEffectue.FillWeight = 10.0!
        Me.isNonEffectue.HeaderText = "NON"
        Me.isNonEffectue.Name = "isNonEffectue"
        '
        'bsControleQuotidien
        '
        Me.bsControleQuotidien.DataSource = GetType(Crodip_agent.AutoTest)
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(834, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(158, 16)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Rafraîchir les alertes"
        '
        'picsRefresh
        '
        Me.picsRefresh.Image = CType(resources.GetObject("picsRefresh.Image"), System.Drawing.Image)
        Me.picsRefresh.Location = New System.Drawing.Point(812, 13)
        Me.picsRefresh.Name = "picsRefresh"
        Me.picsRefresh.Size = New System.Drawing.Size(16, 16)
        Me.picsRefresh.TabIndex = 6
        Me.picsRefresh.TabStop = False
        '
        'accueil_panelAlertes
        '
        Me.accueil_panelAlertes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.accueil_panelAlertes.AutoScroll = True
        Me.accueil_panelAlertes.Controls.Add(Me.Label8)
        Me.accueil_panelAlertes.Controls.Add(Me.Label10)
        Me.accueil_panelAlertes.Controls.Add(Me.Label9)
        Me.accueil_panelAlertes.Location = New System.Drawing.Point(0, 40)
        Me.accueil_panelAlertes.Name = "accueil_panelAlertes"
        Me.accueil_panelAlertes.Size = New System.Drawing.Size(1000, 165)
        Me.accueil_panelAlertes.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Label8.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(968, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "       Vous avez 2 manomètre(s) à contrôler prochainement"
        Me.Label8.Visible = False
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Label10.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(8, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(968, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "       Vous avez 4 exploitant(s) dont la date de prochain contrôle approche"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(8, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(968, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "       Vous avez 1 manomètre(s) hors norme"
        Me.Label9.Visible = False
        '
        'title_mesAlertes
        '
        Me.title_mesAlertes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_mesAlertes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.title_mesAlertes.Image = CType(resources.GetObject("title_mesAlertes.Image"), System.Drawing.Image)
        Me.title_mesAlertes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.title_mesAlertes.Location = New System.Drawing.Point(16, 8)
        Me.title_mesAlertes.Name = "title_mesAlertes"
        Me.title_mesAlertes.Size = New System.Drawing.Size(144, 24)
        Me.title_mesAlertes.TabIndex = 1
        Me.title_mesAlertes.Text = "     Mes Alertes"
        '
        'tabAccueil_mesinfos
        '
        Me.tabAccueil_mesinfos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabAccueil_mesinfos.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_dateDernCnx)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_IdCrodip)
        Me.tabAccueil_mesinfos.Controls.Add(Me.pctLogo)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_dateDernièreConnexion)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_dateDerniereUtilisation)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_prenom)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_nom)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_idCrodip)
        Me.tabAccueil_mesinfos.Controls.Add(Me.title_mesInfos)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_Nom)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_Prenom)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_dateDernSynchro)
        Me.tabAccueil_mesinfos.Location = New System.Drawing.Point(0, 0)
        Me.tabAccueil_mesinfos.Name = "tabAccueil_mesinfos"
        Me.tabAccueil_mesinfos.Size = New System.Drawing.Size(1000, 136)
        Me.tabAccueil_mesinfos.TabIndex = 0
        '
        'lbl_infosAgent_dateDernCnx
        '
        Me.lbl_infosAgent_dateDernCnx.Location = New System.Drawing.Point(576, 56)
        Me.lbl_infosAgent_dateDernCnx.Name = "lbl_infosAgent_dateDernCnx"
        Me.lbl_infosAgent_dateDernCnx.Size = New System.Drawing.Size(176, 16)
        Me.lbl_infosAgent_dateDernCnx.TabIndex = 8
        '
        'lbl_infosAgent_IdCrodip
        '
        Me.lbl_infosAgent_IdCrodip.Location = New System.Drawing.Point(168, 56)
        Me.lbl_infosAgent_IdCrodip.Name = "lbl_infosAgent_IdCrodip"
        Me.lbl_infosAgent_IdCrodip.Size = New System.Drawing.Size(176, 16)
        Me.lbl_infosAgent_IdCrodip.TabIndex = 7
        '
        'pctLogo
        '
        Me.pctLogo.Image = CType(resources.GetObject("pctLogo.Image"), System.Drawing.Image)
        Me.pctLogo.Location = New System.Drawing.Point(896, 24)
        Me.pctLogo.Name = "pctLogo"
        Me.pctLogo.Size = New System.Drawing.Size(76, 84)
        Me.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogo.TabIndex = 6
        Me.pctLogo.TabStop = False
        '
        'lbl_mesInfos_dateDernièreConnexion
        '
        Me.lbl_mesInfos_dateDernièreConnexion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesInfos_dateDernièreConnexion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_mesInfos_dateDernièreConnexion.Location = New System.Drawing.Point(360, 80)
        Me.lbl_mesInfos_dateDernièreConnexion.Name = "lbl_mesInfos_dateDernièreConnexion"
        Me.lbl_mesInfos_dateDernièreConnexion.Size = New System.Drawing.Size(216, 16)
        Me.lbl_mesInfos_dateDernièreConnexion.TabIndex = 5
        Me.lbl_mesInfos_dateDernièreConnexion.Text = "Date de dernière synchronisation :"
        '
        'lbl_mesInfos_dateDerniereUtilisation
        '
        Me.lbl_mesInfos_dateDerniereUtilisation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesInfos_dateDerniereUtilisation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_mesInfos_dateDerniereUtilisation.Location = New System.Drawing.Point(360, 56)
        Me.lbl_mesInfos_dateDerniereUtilisation.Name = "lbl_mesInfos_dateDerniereUtilisation"
        Me.lbl_mesInfos_dateDerniereUtilisation.Size = New System.Drawing.Size(216, 16)
        Me.lbl_mesInfos_dateDerniereUtilisation.TabIndex = 4
        Me.lbl_mesInfos_dateDerniereUtilisation.Text = "Date de dernière utilisation :"
        '
        'lbl_mesInfos_prenom
        '
        Me.lbl_mesInfos_prenom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesInfos_prenom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_mesInfos_prenom.Location = New System.Drawing.Point(48, 104)
        Me.lbl_mesInfos_prenom.Name = "lbl_mesInfos_prenom"
        Me.lbl_mesInfos_prenom.Size = New System.Drawing.Size(120, 16)
        Me.lbl_mesInfos_prenom.TabIndex = 3
        Me.lbl_mesInfos_prenom.Text = "Prénom :"
        '
        'lbl_mesInfos_nom
        '
        Me.lbl_mesInfos_nom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesInfos_nom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_mesInfos_nom.Location = New System.Drawing.Point(48, 80)
        Me.lbl_mesInfos_nom.Name = "lbl_mesInfos_nom"
        Me.lbl_mesInfos_nom.Size = New System.Drawing.Size(120, 16)
        Me.lbl_mesInfos_nom.TabIndex = 2
        Me.lbl_mesInfos_nom.Text = "Nom :"
        '
        'lbl_mesInfos_idCrodip
        '
        Me.lbl_mesInfos_idCrodip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesInfos_idCrodip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_mesInfos_idCrodip.Location = New System.Drawing.Point(48, 56)
        Me.lbl_mesInfos_idCrodip.Name = "lbl_mesInfos_idCrodip"
        Me.lbl_mesInfos_idCrodip.Size = New System.Drawing.Size(120, 16)
        Me.lbl_mesInfos_idCrodip.TabIndex = 1
        Me.lbl_mesInfos_idCrodip.Text = "Identifiant CRODIP :"
        '
        'title_mesInfos
        '
        Me.title_mesInfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_mesInfos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.title_mesInfos.Image = CType(resources.GetObject("title_mesInfos.Image"), System.Drawing.Image)
        Me.title_mesInfos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.title_mesInfos.Location = New System.Drawing.Point(16, 16)
        Me.title_mesInfos.Name = "title_mesInfos"
        Me.title_mesInfos.Size = New System.Drawing.Size(128, 24)
        Me.title_mesInfos.TabIndex = 0
        Me.title_mesInfos.Text = "     Mes infos"
        '
        'lbl_infosAgent_Nom
        '
        Me.lbl_infosAgent_Nom.Location = New System.Drawing.Point(168, 80)
        Me.lbl_infosAgent_Nom.Name = "lbl_infosAgent_Nom"
        Me.lbl_infosAgent_Nom.Size = New System.Drawing.Size(176, 16)
        Me.lbl_infosAgent_Nom.TabIndex = 7
        '
        'lbl_infosAgent_Prenom
        '
        Me.lbl_infosAgent_Prenom.Location = New System.Drawing.Point(168, 104)
        Me.lbl_infosAgent_Prenom.Name = "lbl_infosAgent_Prenom"
        Me.lbl_infosAgent_Prenom.Size = New System.Drawing.Size(176, 16)
        Me.lbl_infosAgent_Prenom.TabIndex = 7
        '
        'lbl_infosAgent_dateDernSynchro
        '
        Me.lbl_infosAgent_dateDernSynchro.Location = New System.Drawing.Point(576, 80)
        Me.lbl_infosAgent_dateDernSynchro.Name = "lbl_infosAgent_dateDernSynchro"
        Me.lbl_infosAgent_dateDernSynchro.Size = New System.Drawing.Size(176, 16)
        Me.lbl_infosAgent_dateDernSynchro.TabIndex = 8
        '
        'tabControl_clientele
        '
        Me.tabControl_clientele.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_clientele.Controls.Add(Me.panel_clientele_ficheClient)
        Me.tabControl_clientele.Controls.Add(Me.panel_ListeDesControles)
        Me.tabControl_clientele.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabControl_clientele.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_clientele.Name = "tabControl_clientele"
        Me.tabControl_clientele.Size = New System.Drawing.Size(1000, 653)
        Me.tabControl_clientele.TabIndex = 1
        Me.tabControl_clientele.Text = "Contrôle"
        '
        'panel_clientele_ficheClient
        '
        Me.panel_clientele_ficheClient.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.panel_clientele_ficheClient.Controls.Add(Me.grp_ficheClient_ListePulve)
        Me.panel_clientele_ficheClient.Controls.Add(Me.Label1)
        Me.panel_clientele_ficheClient.Controls.Add(Me.GroupBox2)
        Me.panel_clientele_ficheClient.Controls.Add(Me.btn_ficheClient_retour)
        Me.panel_clientele_ficheClient.Location = New System.Drawing.Point(0, 210)
        Me.panel_clientele_ficheClient.Name = "panel_clientele_ficheClient"
        Me.panel_clientele_ficheClient.Size = New System.Drawing.Size(1000, 443)
        Me.panel_clientele_ficheClient.TabIndex = 8
        Me.panel_clientele_ficheClient.Visible = False
        '
        'grp_ficheClient_ListePulve
        '
        Me.grp_ficheClient_ListePulve.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.dgvPulveExploit)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btnTransfertPulve)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btnAjoutPulve)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btnFichePulve)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btnSupprPulve)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btn_ficheClient_diagnostic_nouveau)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btn_ficheClient_diagnostic_nouvelleCV)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btn_ficheClient_diagnostic_voir)
        Me.grp_ficheClient_ListePulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_ficheClient_ListePulve.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.grp_ficheClient_ListePulve.Location = New System.Drawing.Point(8, 147)
        Me.grp_ficheClient_ListePulve.Name = "grp_ficheClient_ListePulve"
        Me.grp_ficheClient_ListePulve.Size = New System.Drawing.Size(980, 275)
        Me.grp_ficheClient_ListePulve.TabIndex = 10
        Me.grp_ficheClient_ListePulve.TabStop = False
        Me.grp_ficheClient_ListePulve.Text = "Liste des pulvérisateurs"
        '
        'dgvPulveExploit
        '
        Me.dgvPulveExploit.AllowUserToAddRows = False
        Me.dgvPulveExploit.AllowUserToDeleteRows = False
        Me.dgvPulveExploit.AllowUserToResizeRows = False
        Me.dgvPulveExploit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPulveExploit.AutoGenerateColumns = False
        Me.dgvPulveExploit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPulveExploit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPulveExploit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPulveExploit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPulveExploit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPulveExploit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IconPulveCol, Me.NumeroNationalDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn1, Me.MarqueDataGridViewTextBoxColumn, Me.ModeleDataGridViewTextBoxColumn, Me.NombreBusesDataGridViewTextBoxColumn, Me.CapaciteDataGridViewTextBoxColumn, Me.AttelageDataGridViewTextBoxColumn, Me.AnneeAchatDataGridViewTextBoxColumn, Me.DateProchainControleDataGridViewTextBoxColumn, Me.IconPulveColumn, Me.PulvePrincipalNumNatDataGridViewTextBoxColumn})
        Me.dgvPulveExploit.DataSource = Me.m_bsrcPulverisateurTMP
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPulveExploit.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPulveExploit.GridColor = System.Drawing.Color.Black
        Me.dgvPulveExploit.Location = New System.Drawing.Point(11, 62)
        Me.dgvPulveExploit.MultiSelect = False
        Me.dgvPulveExploit.Name = "dgvPulveExploit"
        Me.dgvPulveExploit.ReadOnly = True
        Me.dgvPulveExploit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvPulveExploit.RowHeadersWidth = 20
        Me.dgvPulveExploit.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPulveExploit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPulveExploit.Size = New System.Drawing.Size(961, 207)
        Me.dgvPulveExploit.TabIndex = 32
        Me.dgvPulveExploit.VirtualMode = True
        '
        'IconPulveCol
        '
        Me.IconPulveCol.FillWeight = 3.0!
        Me.IconPulveCol.HeaderText = "Etat"
        Me.IconPulveCol.Name = "IconPulveCol"
        Me.IconPulveCol.ReadOnly = True
        '
        'NumeroNationalDataGridViewTextBoxColumn
        '
        Me.NumeroNationalDataGridViewTextBoxColumn.DataPropertyName = "numeroNational"
        Me.NumeroNationalDataGridViewTextBoxColumn.FillWeight = 10.0!
        Me.NumeroNationalDataGridViewTextBoxColumn.HeaderText = "Identifiant pulvé"
        Me.NumeroNationalDataGridViewTextBoxColumn.Name = "NumeroNationalDataGridViewTextBoxColumn"
        Me.NumeroNationalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TypeDataGridViewTextBoxColumn1
        '
        Me.TypeDataGridViewTextBoxColumn1.DataPropertyName = "type"
        Me.TypeDataGridViewTextBoxColumn1.FillWeight = 16.0!
        Me.TypeDataGridViewTextBoxColumn1.HeaderText = "Type"
        Me.TypeDataGridViewTextBoxColumn1.Name = "TypeDataGridViewTextBoxColumn1"
        Me.TypeDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'MarqueDataGridViewTextBoxColumn
        '
        Me.MarqueDataGridViewTextBoxColumn.DataPropertyName = "marque"
        Me.MarqueDataGridViewTextBoxColumn.FillWeight = 9.0!
        Me.MarqueDataGridViewTextBoxColumn.HeaderText = "Marque"
        Me.MarqueDataGridViewTextBoxColumn.Name = "MarqueDataGridViewTextBoxColumn"
        Me.MarqueDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ModeleDataGridViewTextBoxColumn
        '
        Me.ModeleDataGridViewTextBoxColumn.DataPropertyName = "modele"
        Me.ModeleDataGridViewTextBoxColumn.FillWeight = 12.0!
        Me.ModeleDataGridViewTextBoxColumn.HeaderText = "Modèle"
        Me.ModeleDataGridViewTextBoxColumn.Name = "ModeleDataGridViewTextBoxColumn"
        Me.ModeleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NombreBusesDataGridViewTextBoxColumn
        '
        Me.NombreBusesDataGridViewTextBoxColumn.DataPropertyName = "LargeurNombreRangs"
        Me.NombreBusesDataGridViewTextBoxColumn.FillWeight = 5.0!
        Me.NombreBusesDataGridViewTextBoxColumn.HeaderText = "Largeur"
        Me.NombreBusesDataGridViewTextBoxColumn.Name = "NombreBusesDataGridViewTextBoxColumn"
        Me.NombreBusesDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CapaciteDataGridViewTextBoxColumn
        '
        Me.CapaciteDataGridViewTextBoxColumn.DataPropertyName = "capacite"
        Me.CapaciteDataGridViewTextBoxColumn.FillWeight = 7.0!
        Me.CapaciteDataGridViewTextBoxColumn.HeaderText = "Capacité"
        Me.CapaciteDataGridViewTextBoxColumn.Name = "CapaciteDataGridViewTextBoxColumn"
        Me.CapaciteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AttelageDataGridViewTextBoxColumn
        '
        Me.AttelageDataGridViewTextBoxColumn.DataPropertyName = "attelage"
        Me.AttelageDataGridViewTextBoxColumn.FillWeight = 11.0!
        Me.AttelageDataGridViewTextBoxColumn.HeaderText = "Attelage"
        Me.AttelageDataGridViewTextBoxColumn.Name = "AttelageDataGridViewTextBoxColumn"
        Me.AttelageDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AnneeAchatDataGridViewTextBoxColumn
        '
        Me.AnneeAchatDataGridViewTextBoxColumn.DataPropertyName = "anneeAchat"
        Me.AnneeAchatDataGridViewTextBoxColumn.FillWeight = 6.0!
        Me.AnneeAchatDataGridViewTextBoxColumn.HeaderText = "Année Construct."
        Me.AnneeAchatDataGridViewTextBoxColumn.Name = "AnneeAchatDataGridViewTextBoxColumn"
        Me.AnneeAchatDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateProchainControleDataGridViewTextBoxColumn
        '
        Me.DateProchainControleDataGridViewTextBoxColumn.DataPropertyName = "dateProchainControleAsDate"
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DateProchainControleDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.DateProchainControleDataGridViewTextBoxColumn.FillWeight = 9.0!
        Me.DateProchainControleDataGridViewTextBoxColumn.HeaderText = "Prochain contrôle"
        Me.DateProchainControleDataGridViewTextBoxColumn.Name = "DateProchainControleDataGridViewTextBoxColumn"
        Me.DateProchainControleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IconPulveColumn
        '
        Me.IconPulveColumn.DataPropertyName = "PulvePrincipalAdditionel"
        Me.IconPulveColumn.FillWeight = 5.0!
        Me.IconPulveColumn.HeaderText = "Statut"
        Me.IconPulveColumn.Name = "IconPulveColumn"
        Me.IconPulveColumn.ReadOnly = True
        Me.IconPulveColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'PulvePrincipalNumNatDataGridViewTextBoxColumn
        '
        Me.PulvePrincipalNumNatDataGridViewTextBoxColumn.DataPropertyName = "pulvePrincipalNumNat"
        Me.PulvePrincipalNumNatDataGridViewTextBoxColumn.FillWeight = 8.0!
        Me.PulvePrincipalNumNatDataGridViewTextBoxColumn.HeaderText = "ID Principal"
        Me.PulvePrincipalNumNatDataGridViewTextBoxColumn.Name = "PulvePrincipalNumNatDataGridViewTextBoxColumn"
        Me.PulvePrincipalNumNatDataGridViewTextBoxColumn.ReadOnly = True
        '
        'm_bsrcPulverisateurTMP
        '
        Me.m_bsrcPulverisateurTMP.DataSource = GetType(Crodip_agent.Pulverisateur)
        '
        'btnTransfertPulve
        '
        Me.btnTransfertPulve.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnTransfertPulve.BackgroundImage = CType(resources.GetObject("btnTransfertPulve.BackgroundImage"), System.Drawing.Image)
        Me.btnTransfertPulve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTransfertPulve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransfertPulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfertPulve.ForeColor = System.Drawing.Color.White
        Me.btnTransfertPulve.Location = New System.Drawing.Point(541, 24)
        Me.btnTransfertPulve.Name = "btnTransfertPulve"
        Me.btnTransfertPulve.Size = New System.Drawing.Size(112, 24)
        Me.btnTransfertPulve.TabIndex = 31
        Me.btnTransfertPulve.Text = "Transfert pulve"
        Me.btnTransfertPulve.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTransfertPulve.UseVisualStyleBackColor = False
        '
        'btnAjoutPulve
        '
        Me.btnAjoutPulve.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnAjoutPulve.BackgroundImage = CType(resources.GetObject("btnAjoutPulve.BackgroundImage"), System.Drawing.Image)
        Me.btnAjoutPulve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAjoutPulve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjoutPulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAjoutPulve.ForeColor = System.Drawing.Color.White
        Me.btnAjoutPulve.Location = New System.Drawing.Point(659, 24)
        Me.btnAjoutPulve.Name = "btnAjoutPulve"
        Me.btnAjoutPulve.Size = New System.Drawing.Size(115, 24)
        Me.btnAjoutPulve.TabIndex = 30
        Me.btnAjoutPulve.Text = "Ajouter un pulve"
        Me.btnAjoutPulve.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAjoutPulve.UseVisualStyleBackColor = False
        '
        'btnFichePulve
        '
        Me.btnFichePulve.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnFichePulve.BackgroundImage = CType(resources.GetObject("btnFichePulve.BackgroundImage"), System.Drawing.Image)
        Me.btnFichePulve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFichePulve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFichePulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFichePulve.ForeColor = System.Drawing.Color.White
        Me.btnFichePulve.Location = New System.Drawing.Point(780, 24)
        Me.btnFichePulve.Name = "btnFichePulve"
        Me.btnFichePulve.Size = New System.Drawing.Size(101, 24)
        Me.btnFichePulve.TabIndex = 29
        Me.btnFichePulve.Text = "Voir la fiche"
        Me.btnFichePulve.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFichePulve.UseVisualStyleBackColor = False
        '
        'btnSupprPulve
        '
        Me.btnSupprPulve.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnSupprPulve.BackgroundImage = CType(resources.GetObject("btnSupprPulve.BackgroundImage"), System.Drawing.Image)
        Me.btnSupprPulve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSupprPulve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupprPulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupprPulve.ForeColor = System.Drawing.Color.White
        Me.btnSupprPulve.Location = New System.Drawing.Point(887, 24)
        Me.btnSupprPulve.Name = "btnSupprPulve"
        Me.btnSupprPulve.Size = New System.Drawing.Size(89, 24)
        Me.btnSupprPulve.TabIndex = 28
        Me.btnSupprPulve.Text = "Supprimer"
        Me.btnSupprPulve.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSupprPulve.UseVisualStyleBackColor = False
        '
        'btn_ficheClient_diagnostic_nouveau
        '
        Me.btn_ficheClient_diagnostic_nouveau.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheClient_diagnostic_nouveau.ForeColor = System.Drawing.Color.White
        Me.btn_ficheClient_diagnostic_nouveau.Image = CType(resources.GetObject("btn_ficheClient_diagnostic_nouveau.Image"), System.Drawing.Image)
        Me.btn_ficheClient_diagnostic_nouveau.Location = New System.Drawing.Point(8, 24)
        Me.btn_ficheClient_diagnostic_nouveau.Name = "btn_ficheClient_diagnostic_nouveau"
        Me.btn_ficheClient_diagnostic_nouveau.Size = New System.Drawing.Size(176, 24)
        Me.btn_ficheClient_diagnostic_nouveau.TabIndex = 26
        Me.btn_ficheClient_diagnostic_nouveau.Text = "       Réaliser un contrôle complet"
        Me.btn_ficheClient_diagnostic_nouveau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheClient_diagnostic_nouvelleCV
        '
        Me.btn_ficheClient_diagnostic_nouvelleCV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheClient_diagnostic_nouvelleCV.ForeColor = System.Drawing.Color.White
        Me.btn_ficheClient_diagnostic_nouvelleCV.Image = CType(resources.GetObject("btn_ficheClient_diagnostic_nouvelleCV.Image"), System.Drawing.Image)
        Me.btn_ficheClient_diagnostic_nouvelleCV.Location = New System.Drawing.Point(190, 24)
        Me.btn_ficheClient_diagnostic_nouvelleCV.Name = "btn_ficheClient_diagnostic_nouvelleCV"
        Me.btn_ficheClient_diagnostic_nouvelleCV.Size = New System.Drawing.Size(180, 24)
        Me.btn_ficheClient_diagnostic_nouvelleCV.TabIndex = 26
        Me.btn_ficheClient_diagnostic_nouvelleCV.Text = "       Réaliser une contre visite"
        Me.btn_ficheClient_diagnostic_nouvelleCV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheClient_diagnostic_voir
        '
        Me.btn_ficheClient_diagnostic_voir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheClient_diagnostic_voir.ForeColor = System.Drawing.Color.White
        Me.btn_ficheClient_diagnostic_voir.Image = CType(resources.GetObject("btn_ficheClient_diagnostic_voir.Image"), System.Drawing.Image)
        Me.btn_ficheClient_diagnostic_voir.Location = New System.Drawing.Point(372, 24)
        Me.btn_ficheClient_diagnostic_voir.Name = "btn_ficheClient_diagnostic_voir"
        Me.btn_ficheClient_diagnostic_voir.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheClient_diagnostic_voir.TabIndex = 26
        Me.btn_ficheClient_diagnostic_voir.Text = "       Les contrôles"
        Me.btn_ficheClient_diagnostic_voir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "     Fiche client"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstPulves_client_proprioSiren)
        Me.GroupBox2.Controls.Add(Me.lstPulves_client_raisonSociale)
        Me.GroupBox2.Controls.Add(Me.btn_ficheClient_voirFiche)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(560, 104)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Client"
        '
        'lstPulves_client_proprioSiren
        '
        Me.lstPulves_client_proprioSiren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPulves_client_proprioSiren.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.lstPulves_client_proprioSiren.Location = New System.Drawing.Point(8, 40)
        Me.lstPulves_client_proprioSiren.Name = "lstPulves_client_proprioSiren"
        Me.lstPulves_client_proprioSiren.Size = New System.Drawing.Size(544, 16)
        Me.lstPulves_client_proprioSiren.TabIndex = 3
        '
        'lstPulves_client_raisonSociale
        '
        Me.lstPulves_client_raisonSociale.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPulves_client_raisonSociale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.lstPulves_client_raisonSociale.Location = New System.Drawing.Point(8, 16)
        Me.lstPulves_client_raisonSociale.Name = "lstPulves_client_raisonSociale"
        Me.lstPulves_client_raisonSociale.Size = New System.Drawing.Size(544, 24)
        Me.lstPulves_client_raisonSociale.TabIndex = 2
        '
        'btn_ficheClient_voirFiche
        '
        Me.btn_ficheClient_voirFiche.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheClient_voirFiche.ForeColor = System.Drawing.Color.White
        Me.btn_ficheClient_voirFiche.Image = CType(resources.GetObject("btn_ficheClient_voirFiche.Image"), System.Drawing.Image)
        Me.btn_ficheClient_voirFiche.Location = New System.Drawing.Point(8, 72)
        Me.btn_ficheClient_voirFiche.Name = "btn_ficheClient_voirFiche"
        Me.btn_ficheClient_voirFiche.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheClient_voirFiche.TabIndex = 25
        Me.btn_ficheClient_voirFiche.Text = "    Voir la fiche"
        Me.btn_ficheClient_voirFiche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheClient_retour
        '
        Me.btn_ficheClient_retour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheClient_retour.ForeColor = System.Drawing.Color.White
        Me.btn_ficheClient_retour.Image = CType(resources.GetObject("btn_ficheClient_retour.Image"), System.Drawing.Image)
        Me.btn_ficheClient_retour.Location = New System.Drawing.Point(864, 120)
        Me.btn_ficheClient_retour.Name = "btn_ficheClient_retour"
        Me.btn_ficheClient_retour.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheClient_retour.TabIndex = 25
        Me.btn_ficheClient_retour.Text = "    Retour"
        Me.btn_ficheClient_retour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel_ListeDesControles
        '
        Me.panel_ListeDesControles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_ListeDesControles.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.panel_ListeDesControles.Controls.Add(Me.list_clients)
        Me.panel_ListeDesControles.Controls.Add(Me.panel_clientele_LstCtrlCtriteres)
        Me.panel_ListeDesControles.Location = New System.Drawing.Point(0, 0)
        Me.panel_ListeDesControles.Name = "panel_ListeDesControles"
        Me.panel_ListeDesControles.Size = New System.Drawing.Size(1004, 653)
        Me.panel_ListeDesControles.TabIndex = 7
        '
        'list_clients
        '
        Me.list_clients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.list_clients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.list_clients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.listClients_col_siren, Me.listClients_col_rs, Me.listClients_col_prenom, Me.listClients_col_nom, Me.listClients_col_adresse, Me.listClients_col_codePostal, Me.listClients_col_commune, Me.listClients_col_ProchainControle})
        Me.list_clients.FullRowSelect = True
        Me.list_clients.GridLines = True
        Me.list_clients.HideSelection = False
        Me.list_clients.Location = New System.Drawing.Point(1, 112)
        Me.list_clients.MultiSelect = False
        Me.list_clients.Name = "list_clients"
        Me.list_clients.Size = New System.Drawing.Size(1001, 541)
        Me.list_clients.TabIndex = 8
        Me.list_clients.UseCompatibleStateImageBehavior = False
        Me.list_clients.View = System.Windows.Forms.View.Details
        '
        'listClients_col_siren
        '
        Me.listClients_col_siren.Text = "N° SIREN"
        Me.listClients_col_siren.Width = 86
        '
        'listClients_col_rs
        '
        Me.listClients_col_rs.Text = "Raison sociale"
        Me.listClients_col_rs.Width = 139
        '
        'listClients_col_prenom
        '
        Me.listClients_col_prenom.Text = "Prénom"
        Me.listClients_col_prenom.Width = 98
        '
        'listClients_col_nom
        '
        Me.listClients_col_nom.Text = "Nom"
        Me.listClients_col_nom.Width = 100
        '
        'listClients_col_adresse
        '
        Me.listClients_col_adresse.Text = "Adresse"
        Me.listClients_col_adresse.Width = 293
        '
        'listClients_col_codePostal
        '
        Me.listClients_col_codePostal.Text = "Code Postal"
        Me.listClients_col_codePostal.Width = 78
        '
        'listClients_col_commune
        '
        Me.listClients_col_commune.Text = "Commune"
        Me.listClients_col_commune.Width = 84
        '
        'listClients_col_ProchainControle
        '
        Me.listClients_col_ProchainControle.Text = "Prochain contrôle"
        Me.listClients_col_ProchainControle.Width = 95
        '
        'panel_clientele_LstCtrlCtriteres
        '
        Me.panel_clientele_LstCtrlCtriteres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_clientele_LstCtrlCtriteres.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.pnl_SearchDates)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.lbl_refresh_lst_clients)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_refresh_lst_clients)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_proprietaire_exportCsv)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_rechercher_exploitant)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.pct_LogoControle)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.title_alertes)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.list_search_fieldSearch)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.client_search_query)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_proprietaire_supprimer)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_proprietaire_rechercher)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_proprietaire_voirFiche)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_proprietaire_pulveListe)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_proprietaire_ajouter)
        Me.panel_clientele_LstCtrlCtriteres.Controls.Add(Me.btn_proprietaire_derniersControles)
        Me.panel_clientele_LstCtrlCtriteres.Location = New System.Drawing.Point(1, 3)
        Me.panel_clientele_LstCtrlCtriteres.Name = "panel_clientele_LstCtrlCtriteres"
        Me.panel_clientele_LstCtrlCtriteres.Size = New System.Drawing.Size(1003, 104)
        Me.panel_clientele_LstCtrlCtriteres.TabIndex = 10
        '
        'pnl_SearchDates
        '
        Me.pnl_SearchDates.Controls.Add(Me.dtpSearchCrit2)
        Me.pnl_SearchDates.Controls.Add(Me.Label30)
        Me.pnl_SearchDates.Controls.Add(Me.Label29)
        Me.pnl_SearchDates.Controls.Add(Me.dtpSearchCrit1)
        Me.pnl_SearchDates.Location = New System.Drawing.Point(327, 47)
        Me.pnl_SearchDates.Name = "pnl_SearchDates"
        Me.pnl_SearchDates.Size = New System.Drawing.Size(299, 20)
        Me.pnl_SearchDates.TabIndex = 29
        Me.pnl_SearchDates.Visible = False
        '
        'dtpSearchCrit2
        '
        Me.dtpSearchCrit2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSearchCrit2.Location = New System.Drawing.Point(194, 1)
        Me.dtpSearchCrit2.Name = "dtpSearchCrit2"
        Me.dtpSearchCrit2.Size = New System.Drawing.Size(102, 20)
        Me.dtpSearchCrit2.TabIndex = 28
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(162, 3)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(34, 13)
        Me.Label30.TabIndex = 30
        Me.Label30.Text = "Et le :"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(2, 3)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 13)
        Me.Label29.TabIndex = 29
        Me.Label29.Text = "Entre le :"
        '
        'dtpSearchCrit1
        '
        Me.dtpSearchCrit1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSearchCrit1.Location = New System.Drawing.Point(54, 1)
        Me.dtpSearchCrit1.Name = "dtpSearchCrit1"
        Me.dtpSearchCrit1.Size = New System.Drawing.Size(102, 20)
        Me.dtpSearchCrit1.TabIndex = 27
        '
        'lbl_refresh_lst_clients
        '
        Me.lbl_refresh_lst_clients.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_refresh_lst_clients.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_refresh_lst_clients.Location = New System.Drawing.Point(40, 49)
        Me.lbl_refresh_lst_clients.Name = "lbl_refresh_lst_clients"
        Me.lbl_refresh_lst_clients.Size = New System.Drawing.Size(120, 15)
        Me.lbl_refresh_lst_clients.TabIndex = 26
        Me.lbl_refresh_lst_clients.Text = "Rafraîchir la liste"
        '
        'btn_refresh_lst_clients
        '
        Me.btn_refresh_lst_clients.Image = CType(resources.GetObject("btn_refresh_lst_clients.Image"), System.Drawing.Image)
        Me.btn_refresh_lst_clients.Location = New System.Drawing.Point(24, 48)
        Me.btn_refresh_lst_clients.Name = "btn_refresh_lst_clients"
        Me.btn_refresh_lst_clients.Size = New System.Drawing.Size(16, 16)
        Me.btn_refresh_lst_clients.TabIndex = 25
        Me.btn_refresh_lst_clients.TabStop = False
        '
        'btn_proprietaire_exportCsv
        '
        Me.btn_proprietaire_exportCsv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_proprietaire_exportCsv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proprietaire_exportCsv.ForeColor = System.Drawing.Color.White
        Me.btn_proprietaire_exportCsv.Image = CType(resources.GetObject("btn_proprietaire_exportCsv.Image"), System.Drawing.Image)
        Me.btn_proprietaire_exportCsv.Location = New System.Drawing.Point(192, 72)
        Me.btn_proprietaire_exportCsv.Name = "btn_proprietaire_exportCsv"
        Me.btn_proprietaire_exportCsv.Size = New System.Drawing.Size(128, 24)
        Me.btn_proprietaire_exportCsv.TabIndex = 24
        Me.btn_proprietaire_exportCsv.Text = "        Exporter en CSV"
        Me.btn_proprietaire_exportCsv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_rechercher_exploitant
        '
        Me.btn_rechercher_exploitant.Image = CType(resources.GetObject("btn_rechercher_exploitant.Image"), System.Drawing.Image)
        Me.btn_rechercher_exploitant.Location = New System.Drawing.Point(304, 25)
        Me.btn_rechercher_exploitant.Name = "btn_rechercher_exploitant"
        Me.btn_rechercher_exploitant.Size = New System.Drawing.Size(16, 16)
        Me.btn_rechercher_exploitant.TabIndex = 21
        Me.btn_rechercher_exploitant.TabStop = False
        '
        'pct_LogoControle
        '
        Me.pct_LogoControle.Image = CType(resources.GetObject("pct_LogoControle.Image"), System.Drawing.Image)
        Me.pct_LogoControle.Location = New System.Drawing.Point(912, 8)
        Me.pct_LogoControle.Name = "pct_LogoControle"
        Me.pct_LogoControle.Size = New System.Drawing.Size(76, 84)
        Me.pct_LogoControle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pct_LogoControle.TabIndex = 6
        Me.pct_LogoControle.TabStop = False
        Me.pct_LogoControle.Visible = False
        '
        'title_alertes
        '
        Me.title_alertes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_alertes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.title_alertes.Image = CType(resources.GetObject("title_alertes.Image"), System.Drawing.Image)
        Me.title_alertes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.title_alertes.Location = New System.Drawing.Point(16, 16)
        Me.title_alertes.Name = "title_alertes"
        Me.title_alertes.Size = New System.Drawing.Size(224, 24)
        Me.title_alertes.TabIndex = 0
        Me.title_alertes.Text = "     Liste des contrôles"
        '
        'list_search_fieldSearch
        '
        Me.list_search_fieldSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.list_search_fieldSearch.Location = New System.Drawing.Point(632, 24)
        Me.list_search_fieldSearch.Name = "list_search_fieldSearch"
        Me.list_search_fieldSearch.Size = New System.Drawing.Size(121, 21)
        Me.list_search_fieldSearch.TabIndex = 15
        '
        'client_search_query
        '
        Me.client_search_query.Location = New System.Drawing.Point(328, 24)
        Me.client_search_query.Name = "client_search_query"
        Me.client_search_query.Size = New System.Drawing.Size(298, 20)
        Me.client_search_query.TabIndex = 14
        '
        'btn_proprietaire_supprimer
        '
        Me.btn_proprietaire_supprimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_proprietaire_supprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proprietaire_supprimer.ForeColor = System.Drawing.Color.White
        Me.btn_proprietaire_supprimer.Image = CType(resources.GetObject("btn_proprietaire_supprimer.Image"), System.Drawing.Image)
        Me.btn_proprietaire_supprimer.Location = New System.Drawing.Point(772, 72)
        Me.btn_proprietaire_supprimer.Name = "btn_proprietaire_supprimer"
        Me.btn_proprietaire_supprimer.Size = New System.Drawing.Size(128, 24)
        Me.btn_proprietaire_supprimer.TabIndex = 22
        Me.btn_proprietaire_supprimer.Text = "    Supprimer"
        Me.btn_proprietaire_supprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_proprietaire_rechercher
        '
        Me.btn_proprietaire_rechercher.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_proprietaire_rechercher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proprietaire_rechercher.ForeColor = System.Drawing.Color.White
        Me.btn_proprietaire_rechercher.Image = CType(resources.GetObject("btn_proprietaire_rechercher.Image"), System.Drawing.Image)
        Me.btn_proprietaire_rechercher.Location = New System.Drawing.Point(760, 21)
        Me.btn_proprietaire_rechercher.Name = "btn_proprietaire_rechercher"
        Me.btn_proprietaire_rechercher.Size = New System.Drawing.Size(128, 24)
        Me.btn_proprietaire_rechercher.TabIndex = 22
        Me.btn_proprietaire_rechercher.Text = "     Rechercher"
        Me.btn_proprietaire_rechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_proprietaire_voirFiche
        '
        Me.btn_proprietaire_voirFiche.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_proprietaire_voirFiche.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proprietaire_voirFiche.ForeColor = System.Drawing.Color.White
        Me.btn_proprietaire_voirFiche.Image = CType(resources.GetObject("btn_proprietaire_voirFiche.Image"), System.Drawing.Image)
        Me.btn_proprietaire_voirFiche.Location = New System.Drawing.Point(640, 72)
        Me.btn_proprietaire_voirFiche.Name = "btn_proprietaire_voirFiche"
        Me.btn_proprietaire_voirFiche.Size = New System.Drawing.Size(128, 24)
        Me.btn_proprietaire_voirFiche.TabIndex = 22
        Me.btn_proprietaire_voirFiche.Text = "    Voir la fiche"
        Me.btn_proprietaire_voirFiche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_proprietaire_pulveListe
        '
        Me.btn_proprietaire_pulveListe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_proprietaire_pulveListe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proprietaire_pulveListe.ForeColor = System.Drawing.Color.White
        Me.btn_proprietaire_pulveListe.Image = CType(resources.GetObject("btn_proprietaire_pulveListe.Image"), System.Drawing.Image)
        Me.btn_proprietaire_pulveListe.Location = New System.Drawing.Point(508, 72)
        Me.btn_proprietaire_pulveListe.Name = "btn_proprietaire_pulveListe"
        Me.btn_proprietaire_pulveListe.Size = New System.Drawing.Size(128, 24)
        Me.btn_proprietaire_pulveListe.TabIndex = 22
        Me.btn_proprietaire_pulveListe.Text = "    Liste pulvé"
        Me.btn_proprietaire_pulveListe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_proprietaire_ajouter
        '
        Me.btn_proprietaire_ajouter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_proprietaire_ajouter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proprietaire_ajouter.ForeColor = System.Drawing.Color.White
        Me.btn_proprietaire_ajouter.Image = CType(resources.GetObject("btn_proprietaire_ajouter.Image"), System.Drawing.Image)
        Me.btn_proprietaire_ajouter.Location = New System.Drawing.Point(8, 72)
        Me.btn_proprietaire_ajouter.Name = "btn_proprietaire_ajouter"
        Me.btn_proprietaire_ajouter.Size = New System.Drawing.Size(180, 24)
        Me.btn_proprietaire_ajouter.TabIndex = 22
        Me.btn_proprietaire_ajouter.Text = "      Ajouter un propriétaire"
        Me.btn_proprietaire_ajouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_proprietaire_derniersControles
        '
        Me.btn_proprietaire_derniersControles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_proprietaire_derniersControles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proprietaire_derniersControles.ForeColor = System.Drawing.Color.White
        Me.btn_proprietaire_derniersControles.Image = CType(resources.GetObject("btn_proprietaire_derniersControles.Image"), System.Drawing.Image)
        Me.btn_proprietaire_derniersControles.Location = New System.Drawing.Point(329, 72)
        Me.btn_proprietaire_derniersControles.Name = "btn_proprietaire_derniersControles"
        Me.btn_proprietaire_derniersControles.Size = New System.Drawing.Size(180, 24)
        Me.btn_proprietaire_derniersControles.TabIndex = 22
        Me.btn_proprietaire_derniersControles.Text = "       Voir les prochains contrôles"
        Me.btn_proprietaire_derniersControles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabControl_pulverisateurs
        '
        Me.tabControl_pulverisateurs.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.tabControl_pulverisateurs.Controls.Add(Me.btn_lstPulve_voirFiche)
        Me.tabControl_pulverisateurs.Controls.Add(Me.listPulve_btn_exportCsv)
        Me.tabControl_pulverisateurs.Controls.Add(Me.listPulve_lbl_refreshList)
        Me.tabControl_pulverisateurs.Controls.Add(Me.listPulve_btn_refreshList)
        Me.tabControl_pulverisateurs.Controls.Add(Me.listPulverisateurs)
        Me.tabControl_pulverisateurs.Controls.Add(Me.Label19)
        Me.tabControl_pulverisateurs.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_pulverisateurs.Name = "tabControl_pulverisateurs"
        Me.tabControl_pulverisateurs.Size = New System.Drawing.Size(1000, 653)
        Me.tabControl_pulverisateurs.TabIndex = 2
        Me.tabControl_pulverisateurs.Text = "Pulvérisateurs"
        '
        'btn_lstPulve_voirFiche
        '
        Me.btn_lstPulve_voirFiche.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_lstPulve_voirFiche.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_lstPulve_voirFiche.ForeColor = System.Drawing.Color.White
        Me.btn_lstPulve_voirFiche.Image = CType(resources.GetObject("btn_lstPulve_voirFiche.Image"), System.Drawing.Image)
        Me.btn_lstPulve_voirFiche.Location = New System.Drawing.Point(649, 11)
        Me.btn_lstPulve_voirFiche.Name = "btn_lstPulve_voirFiche"
        Me.btn_lstPulve_voirFiche.Size = New System.Drawing.Size(128, 24)
        Me.btn_lstPulve_voirFiche.TabIndex = 26
        Me.btn_lstPulve_voirFiche.Text = "    Voir la fiche"
        Me.btn_lstPulve_voirFiche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'listPulve_btn_exportCsv
        '
        Me.listPulve_btn_exportCsv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.listPulve_btn_exportCsv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listPulve_btn_exportCsv.ForeColor = System.Drawing.Color.White
        Me.listPulve_btn_exportCsv.Image = CType(resources.GetObject("listPulve_btn_exportCsv.Image"), System.Drawing.Image)
        Me.listPulve_btn_exportCsv.Location = New System.Drawing.Point(312, 8)
        Me.listPulve_btn_exportCsv.Name = "listPulve_btn_exportCsv"
        Me.listPulve_btn_exportCsv.Size = New System.Drawing.Size(128, 24)
        Me.listPulve_btn_exportCsv.TabIndex = 25
        Me.listPulve_btn_exportCsv.Text = "        Exporter en CSV"
        Me.listPulve_btn_exportCsv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'listPulve_lbl_refreshList
        '
        Me.listPulve_lbl_refreshList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listPulve_lbl_refreshList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.listPulve_lbl_refreshList.Location = New System.Drawing.Point(841, 17)
        Me.listPulve_lbl_refreshList.Name = "listPulve_lbl_refreshList"
        Me.listPulve_lbl_refreshList.Size = New System.Drawing.Size(151, 13)
        Me.listPulve_lbl_refreshList.TabIndex = 12
        Me.listPulve_lbl_refreshList.Text = "Rafraîchir la liste"
        '
        'listPulve_btn_refreshList
        '
        Me.listPulve_btn_refreshList.Image = CType(resources.GetObject("listPulve_btn_refreshList.Image"), System.Drawing.Image)
        Me.listPulve_btn_refreshList.Location = New System.Drawing.Point(819, 16)
        Me.listPulve_btn_refreshList.Name = "listPulve_btn_refreshList"
        Me.listPulve_btn_refreshList.Size = New System.Drawing.Size(16, 16)
        Me.listPulve_btn_refreshList.TabIndex = 11
        Me.listPulve_btn_refreshList.TabStop = False
        '
        'listPulverisateurs
        '
        Me.listPulverisateurs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listPulverisateurs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listPulverisateurs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_idPulve, Me.col_typePulve, Me.col_marquePulve, Me.col_raisonSociale, Me.col_prenom, Me.col_nom, Me.col_codePostal, Me.col_commune, Me.col_dateDernierControle, Me.col_conclusion})
        Me.listPulverisateurs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listPulverisateurs.FullRowSelect = True
        Me.listPulverisateurs.GridLines = True
        Me.listPulverisateurs.HideSelection = False
        Me.listPulverisateurs.Location = New System.Drawing.Point(8, 40)
        Me.listPulverisateurs.MultiSelect = False
        Me.listPulverisateurs.Name = "listPulverisateurs"
        Me.listPulverisateurs.Size = New System.Drawing.Size(984, 599)
        Me.listPulverisateurs.TabIndex = 10
        Me.listPulverisateurs.UseCompatibleStateImageBehavior = False
        Me.listPulverisateurs.View = System.Windows.Forms.View.Details
        '
        'col_idPulve
        '
        Me.col_idPulve.Text = "Identifiant pulvé"
        Me.col_idPulve.Width = 96
        '
        'col_typePulve
        '
        Me.col_typePulve.Text = "Type"
        Me.col_typePulve.Width = 93
        '
        'col_marquePulve
        '
        Me.col_marquePulve.Text = "Marque"
        Me.col_marquePulve.Width = 120
        '
        'col_raisonSociale
        '
        Me.col_raisonSociale.Text = "Raison sociale"
        Me.col_raisonSociale.Width = 153
        '
        'col_prenom
        '
        Me.col_prenom.Text = "Prénom"
        Me.col_prenom.Width = 63
        '
        'col_nom
        '
        Me.col_nom.Text = "Nom"
        Me.col_nom.Width = 73
        '
        'col_codePostal
        '
        Me.col_codePostal.Text = "CP"
        Me.col_codePostal.Width = 47
        '
        'col_commune
        '
        Me.col_commune.Text = "Commune"
        Me.col_commune.Width = 171
        '
        'col_dateDernierControle
        '
        Me.col_dateDernierControle.Text = "D proch contrôle"
        Me.col_dateDernierControle.Width = 100
        '
        'col_conclusion
        '
        Me.col_conclusion.Text = "Concl."
        Me.col_conclusion.Width = 50
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label19.Image = CType(resources.GetObject("Label19.Image"), System.Drawing.Image)
        Me.Label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label19.Location = New System.Drawing.Point(8, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(256, 24)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "     Liste des pulvérisateurs"
        '
        'tabControl_synchro
        '
        Me.tabControl_synchro.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_synchro.Controls.Add(Me.Panel4)
        Me.tabControl_synchro.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_synchro.Name = "tabControl_synchro"
        Me.tabControl_synchro.Size = New System.Drawing.Size(1000, 653)
        Me.tabControl_synchro.TabIndex = 3
        Me.tabControl_synchro.Text = "Synchro"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Btn_SynhcroDiag)
        Me.Panel4.Controls.Add(Me.tbNumDiag)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.lbSynhcroCourante)
        Me.Panel4.Controls.Add(Me.grpParamSynhcro)
        Me.Panel4.Controls.Add(Me.btn_synchro_run)
        Me.Panel4.Controls.Add(Me.pctLogoSynchro)
        Me.Panel4.Controls.Add(Me.title_listSynchro)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1000, 656)
        Me.Panel4.TabIndex = 8
        '
        'Btn_SynhcroDiag
        '
        Me.Btn_SynhcroDiag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_SynhcroDiag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_SynhcroDiag.ForeColor = System.Drawing.Color.White
        Me.Btn_SynhcroDiag.Image = Global.Crodip_agent.Resources.btn_suivantGrd
        Me.Btn_SynhcroDiag.Location = New System.Drawing.Point(233, 624)
        Me.Btn_SynhcroDiag.Name = "Btn_SynhcroDiag"
        Me.Btn_SynhcroDiag.Size = New System.Drawing.Size(246, 24)
        Me.Btn_SynhcroDiag.TabIndex = 35
        Me.Btn_SynhcroDiag.Text = "      Synchronisation d'un contrôle"
        Me.Btn_SynhcroDiag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbNumDiag
        '
        Me.tbNumDiag.Location = New System.Drawing.Point(127, 627)
        Me.tbNumDiag.Name = "tbNumDiag"
        Me.tbNumDiag.Size = New System.Drawing.Size(100, 20)
        Me.tbNumDiag.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 630)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Numéro d'un contrôle :"
        '
        'lbSynhcroCourante
        '
        Me.lbSynhcroCourante.FormattingEnabled = True
        Me.lbSynhcroCourante.HorizontalScrollbar = True
        Me.lbSynhcroCourante.Location = New System.Drawing.Point(8, 112)
        Me.lbSynhcroCourante.Name = "lbSynhcroCourante"
        Me.lbSynhcroCourante.Size = New System.Drawing.Size(980, 498)
        Me.lbSynhcroCourante.TabIndex = 32
        '
        'grpParamSynhcro
        '
        Me.grpParamSynhcro.Controls.Add(Me.ckSynchroDESC)
        Me.grpParamSynhcro.Controls.Add(Me.ckSynchroASC)
        Me.grpParamSynhcro.Controls.Add(Me.btn_InitLog)
        Me.grpParamSynhcro.Location = New System.Drawing.Point(500, 48)
        Me.grpParamSynhcro.Name = "grpParamSynhcro"
        Me.grpParamSynhcro.Size = New System.Drawing.Size(406, 44)
        Me.grpParamSynhcro.TabIndex = 28
        Me.grpParamSynhcro.TabStop = False
        Me.grpParamSynhcro.Text = "Debug"
        '
        'ckSynchroDESC
        '
        Me.ckSynchroDESC.AutoSize = True
        Me.ckSynchroDESC.Checked = True
        Me.ckSynchroDESC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckSynchroDESC.Location = New System.Drawing.Point(111, 19)
        Me.ckSynchroDESC.Name = "ckSynchroDESC"
        Me.ckSynchroDESC.Size = New System.Drawing.Size(97, 17)
        Me.ckSynchroDESC.TabIndex = 1
        Me.ckSynchroDESC.Text = "Synchro DESC"
        Me.ckSynchroDESC.UseVisualStyleBackColor = True
        '
        'ckSynchroASC
        '
        Me.ckSynchroASC.AutoSize = True
        Me.ckSynchroASC.Checked = True
        Me.ckSynchroASC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckSynchroASC.Location = New System.Drawing.Point(6, 19)
        Me.ckSynchroASC.Name = "ckSynchroASC"
        Me.ckSynchroASC.Size = New System.Drawing.Size(89, 17)
        Me.ckSynchroASC.TabIndex = 0
        Me.ckSynchroASC.Text = "Synchro ASC"
        Me.ckSynchroASC.UseVisualStyleBackColor = True
        '
        'btn_InitLog
        '
        Me.btn_InitLog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_InitLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_InitLog.ForeColor = System.Drawing.Color.White
        Me.btn_InitLog.Image = CType(resources.GetObject("btn_InitLog.Image"), System.Drawing.Image)
        Me.btn_InitLog.Location = New System.Drawing.Point(216, 14)
        Me.btn_InitLog.Name = "btn_InitLog"
        Me.btn_InitLog.Size = New System.Drawing.Size(184, 24)
        Me.btn_InitLog.TabIndex = 24
        Me.btn_InitLog.Text = "      Réinitialiser  fichier de log"
        Me.btn_InitLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_synchro_run
        '
        Me.btn_synchro_run.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_synchro_run.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_synchro_run.ForeColor = System.Drawing.Color.White
        Me.btn_synchro_run.Image = CType(resources.GetObject("btn_synchro_run.Image"), System.Drawing.Image)
        Me.btn_synchro_run.Location = New System.Drawing.Point(10, 48)
        Me.btn_synchro_run.Name = "btn_synchro_run"
        Me.btn_synchro_run.Size = New System.Drawing.Size(182, 36)
        Me.btn_synchro_run.TabIndex = 23
        Me.btn_synchro_run.Text = "      Lancer une synchronisation"
        Me.btn_synchro_run.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctLogoSynchro
        '
        Me.pctLogoSynchro.Image = CType(resources.GetObject("pctLogoSynchro.Image"), System.Drawing.Image)
        Me.pctLogoSynchro.Location = New System.Drawing.Point(912, 8)
        Me.pctLogoSynchro.Name = "pctLogoSynchro"
        Me.pctLogoSynchro.Size = New System.Drawing.Size(76, 84)
        Me.pctLogoSynchro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogoSynchro.TabIndex = 10
        Me.pctLogoSynchro.TabStop = False
        '
        'title_listSynchro
        '
        Me.title_listSynchro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_listSynchro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.title_listSynchro.Image = CType(resources.GetObject("title_listSynchro.Image"), System.Drawing.Image)
        Me.title_listSynchro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.title_listSynchro.Location = New System.Drawing.Point(8, 8)
        Me.title_listSynchro.Name = "title_listSynchro"
        Me.title_listSynchro.Size = New System.Drawing.Size(552, 24)
        Me.title_listSynchro.TabIndex = 9
        Me.title_listSynchro.Text = "     Synchronisation avec le CRODIP"
        '
        'tabControl_outilscomp
        '
        Me.tabControl_outilscomp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_outilscomp.Controls.Add(Me.Panel2)
        Me.tabControl_outilscomp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabControl_outilscomp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tabControl_outilscomp.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_outilscomp.Name = "tabControl_outilscomp"
        Me.tabControl_outilscomp.Size = New System.Drawing.Size(1000, 653)
        Me.tabControl_outilscomp.TabIndex = 4
        Me.tabControl_outilscomp.Text = "Outils complémentaires"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnMAJsynchroAgent)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnParamModeSimplifie)
        Me.Panel2.Controls.Add(Me.btnMAJPulverisateurs)
        Me.Panel2.Controls.Add(Me.pctbx_Docs_refresh)
        Me.Panel2.Controls.Add(Me.SplitContainer_ModuleDocumentaire)
        Me.Panel2.Controls.Add(Me.btn_imprimerDoc)
        Me.Panel2.Controls.Add(Me.btn_outilsComplementaires_calcVolumeHectare)
        Me.Panel2.Controls.Add(Me.pctLogoOutilComp)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lblModuledocumentaire)
        Me.Panel2.Controls.Add(Me.btn_outilsComplementaires_calcDebitBuses)
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1000, 656)
        Me.Panel2.TabIndex = 3
        '
        'btnMAJsynchroAgent
        '
        Me.btnMAJsynchroAgent.BackgroundImage = CType(resources.GetObject("btnMAJsynchroAgent.BackgroundImage"), System.Drawing.Image)
        Me.btnMAJsynchroAgent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMAJsynchroAgent.FlatAppearance.BorderSize = 0
        Me.btnMAJsynchroAgent.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnMAJsynchroAgent.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnMAJsynchroAgent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMAJsynchroAgent.Location = New System.Drawing.Point(686, 140)
        Me.btnMAJsynchroAgent.Name = "btnMAJsynchroAgent"
        Me.btnMAJsynchroAgent.Size = New System.Drawing.Size(194, 36)
        Me.btnMAJsynchroAgent.TabIndex = 39
        Me.btnMAJsynchroAgent.Text = "  MAJ date synchro Agent"
        Me.btnMAJsynchroAgent.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(686, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 36)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Import CSV"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnParamModeSimplifie
        '
        Me.btnParamModeSimplifie.BackgroundImage = CType(resources.GetObject("btnParamModeSimplifie.BackgroundImage"), System.Drawing.Image)
        Me.btnParamModeSimplifie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnParamModeSimplifie.FlatAppearance.BorderSize = 0
        Me.btnParamModeSimplifie.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnParamModeSimplifie.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnParamModeSimplifie.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnParamModeSimplifie.Location = New System.Drawing.Point(686, 98)
        Me.btnParamModeSimplifie.Name = "btnParamModeSimplifie"
        Me.btnParamModeSimplifie.Size = New System.Drawing.Size(194, 36)
        Me.btnParamModeSimplifie.TabIndex = 37
        Me.btnParamModeSimplifie.Text = "  Paramétrage Mode Simplifié"
        Me.btnParamModeSimplifie.UseVisualStyleBackColor = True
        '
        'btnMAJPulverisateurs
        '
        Me.btnMAJPulverisateurs.BackgroundImage = CType(resources.GetObject("btnMAJPulverisateurs.BackgroundImage"), System.Drawing.Image)
        Me.btnMAJPulverisateurs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMAJPulverisateurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMAJPulverisateurs.Location = New System.Drawing.Point(474, 56)
        Me.btnMAJPulverisateurs.Name = "btnMAJPulverisateurs"
        Me.btnMAJPulverisateurs.Size = New System.Drawing.Size(206, 36)
        Me.btnMAJPulverisateurs.TabIndex = 36
        Me.btnMAJPulverisateurs.Text = "MAJ des pulvérisateurs"
        Me.btnMAJPulverisateurs.UseVisualStyleBackColor = True
        '
        'pctbx_Docs_refresh
        '
        Me.pctbx_Docs_refresh.Image = CType(resources.GetObject("pctbx_Docs_refresh.Image"), System.Drawing.Image)
        Me.pctbx_Docs_refresh.Location = New System.Drawing.Point(244, 120)
        Me.pctbx_Docs_refresh.Name = "pctbx_Docs_refresh"
        Me.pctbx_Docs_refresh.Size = New System.Drawing.Size(45, 32)
        Me.pctbx_Docs_refresh.TabIndex = 35
        Me.pctbx_Docs_refresh.TabStop = False
        '
        'SplitContainer_ModuleDocumentaire
        '
        Me.SplitContainer_ModuleDocumentaire.Location = New System.Drawing.Point(26, 166)
        Me.SplitContainer_ModuleDocumentaire.Name = "SplitContainer_ModuleDocumentaire"
        '
        'SplitContainer_ModuleDocumentaire.Panel1
        '
        Me.SplitContainer_ModuleDocumentaire.Panel1.Controls.Add(Me.tv_Docs)
        '
        'SplitContainer_ModuleDocumentaire.Panel2
        '
        Me.SplitContainer_ModuleDocumentaire.Panel2.Controls.Add(Me.lv_Docs)
        Me.SplitContainer_ModuleDocumentaire.Size = New System.Drawing.Size(597, 479)
        Me.SplitContainer_ModuleDocumentaire.SplitterDistance = 199
        Me.SplitContainer_ModuleDocumentaire.TabIndex = 34
        '
        'tv_Docs
        '
        Me.tv_Docs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tv_Docs.ImageIndex = 0
        Me.tv_Docs.ImageList = Me.ImageList_Docs
        Me.tv_Docs.Location = New System.Drawing.Point(0, 0)
        Me.tv_Docs.Name = "tv_Docs"
        Me.tv_Docs.SelectedImageIndex = 2
        Me.tv_Docs.Size = New System.Drawing.Size(199, 479)
        Me.tv_Docs.TabIndex = 0
        '
        'lv_Docs
        '
        Me.lv_Docs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lv_Docs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7})
        Me.lv_Docs.HideSelection = False
        Me.lv_Docs.LargeImageList = Me.ImageList_Docs
        Me.lv_Docs.Location = New System.Drawing.Point(0, 0)
        Me.lv_Docs.Name = "lv_Docs"
        Me.lv_Docs.Size = New System.Drawing.Size(394, 479)
        Me.lv_Docs.SmallImageList = Me.ImageList_Docs
        Me.lv_Docs.TabIndex = 0
        Me.lv_Docs.UseCompatibleStateImageBehavior = False
        Me.lv_Docs.View = System.Windows.Forms.View.List
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 400
        '
        'btn_imprimerDoc
        '
        Me.btn_imprimerDoc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_imprimerDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimerDoc.ForeColor = System.Drawing.Color.White
        Me.btn_imprimerDoc.Image = CType(resources.GetObject("btn_imprimerDoc.Image"), System.Drawing.Image)
        Me.btn_imprimerDoc.Location = New System.Drawing.Point(683, 384)
        Me.btn_imprimerDoc.Name = "btn_imprimerDoc"
        Me.btn_imprimerDoc.Size = New System.Drawing.Size(184, 24)
        Me.btn_imprimerDoc.TabIndex = 33
        Me.btn_imprimerDoc.Text = "      Imprimer le document"
        Me.btn_imprimerDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_outilsComplementaires_calcVolumeHectare
        '
        Me.btn_outilsComplementaires_calcVolumeHectare.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_outilsComplementaires_calcVolumeHectare.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_outilsComplementaires_calcVolumeHectare.ForeColor = System.Drawing.Color.White
        Me.btn_outilsComplementaires_calcVolumeHectare.Image = CType(resources.GetObject("btn_outilsComplementaires_calcVolumeHectare.Image"), System.Drawing.Image)
        Me.btn_outilsComplementaires_calcVolumeHectare.Location = New System.Drawing.Point(56, 56)
        Me.btn_outilsComplementaires_calcVolumeHectare.Name = "btn_outilsComplementaires_calcVolumeHectare"
        Me.btn_outilsComplementaires_calcVolumeHectare.Size = New System.Drawing.Size(180, 36)
        Me.btn_outilsComplementaires_calcVolumeHectare.TabIndex = 31
        Me.btn_outilsComplementaires_calcVolumeHectare.Text = "        Calcul du « volume-hectare »"
        Me.btn_outilsComplementaires_calcVolumeHectare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctLogoOutilComp
        '
        Me.pctLogoOutilComp.Image = CType(resources.GetObject("pctLogoOutilComp.Image"), System.Drawing.Image)
        Me.pctLogoOutilComp.Location = New System.Drawing.Point(896, 24)
        Me.pctLogoOutilComp.Name = "pctLogoOutilComp"
        Me.pctLogoOutilComp.Size = New System.Drawing.Size(76, 84)
        Me.pctLogoOutilComp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogoOutilComp.TabIndex = 6
        Me.pctLogoOutilComp.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "     Outils de calcul"
        '
        'lblModuledocumentaire
        '
        Me.lblModuledocumentaire.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModuledocumentaire.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.lblModuledocumentaire.Image = CType(resources.GetObject("lblModuledocumentaire.Image"), System.Drawing.Image)
        Me.lblModuledocumentaire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblModuledocumentaire.Location = New System.Drawing.Point(16, 120)
        Me.lblModuledocumentaire.Name = "lblModuledocumentaire"
        Me.lblModuledocumentaire.Size = New System.Drawing.Size(352, 24)
        Me.lblModuledocumentaire.TabIndex = 0
        Me.lblModuledocumentaire.Text = "     Module documentaire"
        '
        'btn_outilsComplementaires_calcDebitBuses
        '
        Me.btn_outilsComplementaires_calcDebitBuses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_outilsComplementaires_calcDebitBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_outilsComplementaires_calcDebitBuses.ForeColor = System.Drawing.Color.White
        Me.btn_outilsComplementaires_calcDebitBuses.Image = CType(resources.GetObject("btn_outilsComplementaires_calcDebitBuses.Image"), System.Drawing.Image)
        Me.btn_outilsComplementaires_calcDebitBuses.Location = New System.Drawing.Point(272, 56)
        Me.btn_outilsComplementaires_calcDebitBuses.Name = "btn_outilsComplementaires_calcDebitBuses"
        Me.btn_outilsComplementaires_calcDebitBuses.Size = New System.Drawing.Size(180, 36)
        Me.btn_outilsComplementaires_calcDebitBuses.TabIndex = 31
        Me.btn_outilsComplementaires_calcDebitBuses.Text = "        Contrôle jeu de buses supplémentaire"
        Me.btn_outilsComplementaires_calcDebitBuses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabControl_parametrage
        '
        Me.tabControl_parametrage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_parametrage.Controls.Add(Me.Panel5)
        Me.tabControl_parametrage.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_parametrage.Name = "tabControl_parametrage"
        Me.tabControl_parametrage.Size = New System.Drawing.Size(1000, 653)
        Me.tabControl_parametrage.TabIndex = 5
        Me.tabControl_parametrage.Text = "Paramétrage"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel5.Controls.Add(Me.btn_LieuxControle)
        Me.Panel5.Controls.Add(Me.lblIdentifiantPulve)
        Me.Panel5.Controls.Add(Me.lblMaterielsSupprimes)
        Me.Panel5.Controls.Add(Me.btn_parametrage_facturation)
        Me.Panel5.Controls.Add(Me.lblParametresOrganisme)
        Me.Panel5.Controls.Add(Me.pctLogoParametrage)
        Me.Panel5.Controls.Add(Me.title_parametrage)
        Me.Panel5.Controls.Add(Me.lblParametrageAppareilsMesures)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.btn_parametrage_tarifs)
        Me.Panel5.Controls.Add(Me.btn_parametrage_coordonneesOrganisme)
        Me.Panel5.Controls.Add(Me.btn_parametrage_coordonneesInspecteur)
        Me.Panel5.Controls.Add(Me.btn_parametrage_parametrageManometre)
        Me.Panel5.Controls.Add(Me.btn_parametrage_parametrageBuses)
        Me.Panel5.Controls.Add(Me.btn_parametrage_parametrageBancs)
        Me.Panel5.Controls.Add(Me.btn_parametrage_verificationManometres)
        Me.Panel5.Controls.Add(Me.btn_parametrage_verificationBancs)
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1000, 656)
        Me.Panel5.TabIndex = 2
        '
        'btn_LieuxControle
        '
        Me.btn_LieuxControle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_LieuxControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_LieuxControle.ForeColor = System.Drawing.Color.White
        Me.btn_LieuxControle.Image = CType(resources.GetObject("btn_LieuxControle.Image"), System.Drawing.Image)
        Me.btn_LieuxControle.Location = New System.Drawing.Point(48, 321)
        Me.btn_LieuxControle.Name = "btn_LieuxControle"
        Me.btn_LieuxControle.Size = New System.Drawing.Size(180, 24)
        Me.btn_LieuxControle.TabIndex = 27
        Me.btn_LieuxControle.Text = "    Lieux de contrôle"
        Me.btn_LieuxControle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIdentifiantPulve
        '
        Me.lblIdentifiantPulve.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblIdentifiantPulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdentifiantPulve.ForeColor = System.Drawing.Color.White
        Me.lblIdentifiantPulve.Image = CType(resources.GetObject("lblIdentifiantPulve.Image"), System.Drawing.Image)
        Me.lblIdentifiantPulve.Location = New System.Drawing.Point(48, 276)
        Me.lblIdentifiantPulve.Name = "lblIdentifiantPulve"
        Me.lblIdentifiantPulve.Size = New System.Drawing.Size(180, 24)
        Me.lblIdentifiantPulve.TabIndex = 26
        Me.lblIdentifiantPulve.Text = "    Identifiants pulvérisateur"
        Me.lblIdentifiantPulve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMaterielsSupprimes
        '
        Me.lblMaterielsSupprimes.BackColor = System.Drawing.Color.Azure
        Me.lblMaterielsSupprimes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMaterielsSupprimes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterielsSupprimes.ForeColor = System.Drawing.Color.White
        Me.lblMaterielsSupprimes.Image = CType(resources.GetObject("lblMaterielsSupprimes.Image"), System.Drawing.Image)
        Me.lblMaterielsSupprimes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMaterielsSupprimes.Location = New System.Drawing.Point(344, 235)
        Me.lblMaterielsSupprimes.Name = "lblMaterielsSupprimes"
        Me.lblMaterielsSupprimes.Size = New System.Drawing.Size(135, 24)
        Me.lblMaterielsSupprimes.TabIndex = 25
        Me.lblMaterielsSupprimes.Text = "       Materiels Supprimés"
        Me.lblMaterielsSupprimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_parametrage_facturation
        '
        Me.btn_parametrage_facturation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_facturation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_facturation.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_facturation.Image = CType(resources.GetObject("btn_parametrage_facturation.Image"), System.Drawing.Image)
        Me.btn_parametrage_facturation.Location = New System.Drawing.Point(48, 200)
        Me.btn_parametrage_facturation.Name = "btn_parametrage_facturation"
        Me.btn_parametrage_facturation.Size = New System.Drawing.Size(180, 24)
        Me.btn_parametrage_facturation.TabIndex = 24
        Me.btn_parametrage_facturation.Text = "     Facture"
        Me.btn_parametrage_facturation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParametresOrganisme
        '
        Me.lblParametresOrganisme.BackColor = System.Drawing.Color.Transparent
        Me.lblParametresOrganisme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParametresOrganisme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.lblParametresOrganisme.Image = CType(resources.GetObject("lblParametresOrganisme.Image"), System.Drawing.Image)
        Me.lblParametresOrganisme.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblParametresOrganisme.Location = New System.Drawing.Point(16, 56)
        Me.lblParametresOrganisme.Name = "lblParametresOrganisme"
        Me.lblParametresOrganisme.Size = New System.Drawing.Size(256, 16)
        Me.lblParametresOrganisme.TabIndex = 10
        Me.lblParametresOrganisme.Text = "       Paramètres de l’organisme"
        '
        'pctLogoParametrage
        '
        Me.pctLogoParametrage.Image = CType(resources.GetObject("pctLogoParametrage.Image"), System.Drawing.Image)
        Me.pctLogoParametrage.Location = New System.Drawing.Point(896, 24)
        Me.pctLogoParametrage.Name = "pctLogoParametrage"
        Me.pctLogoParametrage.Size = New System.Drawing.Size(76, 84)
        Me.pctLogoParametrage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogoParametrage.TabIndex = 6
        Me.pctLogoParametrage.TabStop = False
        '
        'title_parametrage
        '
        Me.title_parametrage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_parametrage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.title_parametrage.Image = CType(resources.GetObject("title_parametrage.Image"), System.Drawing.Image)
        Me.title_parametrage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.title_parametrage.Location = New System.Drawing.Point(16, 16)
        Me.title_parametrage.Name = "title_parametrage"
        Me.title_parametrage.Size = New System.Drawing.Size(168, 24)
        Me.title_parametrage.TabIndex = 0
        Me.title_parametrage.Text = "     Paramétrage"
        '
        'lblParametrageAppareilsMesures
        '
        Me.lblParametrageAppareilsMesures.BackColor = System.Drawing.Color.Transparent
        Me.lblParametrageAppareilsMesures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParametrageAppareilsMesures.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.lblParametrageAppareilsMesures.Image = CType(resources.GetObject("lblParametrageAppareilsMesures.Image"), System.Drawing.Image)
        Me.lblParametrageAppareilsMesures.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblParametrageAppareilsMesures.Location = New System.Drawing.Point(312, 56)
        Me.lblParametrageAppareilsMesures.Name = "lblParametrageAppareilsMesures"
        Me.lblParametrageAppareilsMesures.Size = New System.Drawing.Size(290, 16)
        Me.lblParametrageAppareilsMesures.TabIndex = 10
        Me.lblParametrageAppareilsMesures.Text = "        Paramétrage des appareils de mesure"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label18.Image = CType(resources.GetObject("Label18.Image"), System.Drawing.Image)
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label18.Location = New System.Drawing.Point(608, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(282, 16)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "       Vérification des appareils de mesure"
        '
        'btn_parametrage_tarifs
        '
        Me.btn_parametrage_tarifs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_tarifs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_tarifs.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_tarifs.Image = CType(resources.GetObject("btn_parametrage_tarifs.Image"), System.Drawing.Image)
        Me.btn_parametrage_tarifs.Location = New System.Drawing.Point(48, 160)
        Me.btn_parametrage_tarifs.Name = "btn_parametrage_tarifs"
        Me.btn_parametrage_tarifs.Size = New System.Drawing.Size(180, 24)
        Me.btn_parametrage_tarifs.TabIndex = 23
        Me.btn_parametrage_tarifs.Text = "     Tarifs appliqués"
        Me.btn_parametrage_tarifs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_parametrage_coordonneesOrganisme
        '
        Me.btn_parametrage_coordonneesOrganisme.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_coordonneesOrganisme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_coordonneesOrganisme.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_coordonneesOrganisme.Image = CType(resources.GetObject("btn_parametrage_coordonneesOrganisme.Image"), System.Drawing.Image)
        Me.btn_parametrage_coordonneesOrganisme.Location = New System.Drawing.Point(48, 80)
        Me.btn_parametrage_coordonneesOrganisme.Name = "btn_parametrage_coordonneesOrganisme"
        Me.btn_parametrage_coordonneesOrganisme.Size = New System.Drawing.Size(180, 24)
        Me.btn_parametrage_coordonneesOrganisme.TabIndex = 23
        Me.btn_parametrage_coordonneesOrganisme.Text = "       Coordonnées Organisme"
        Me.btn_parametrage_coordonneesOrganisme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_parametrage_coordonneesInspecteur
        '
        Me.btn_parametrage_coordonneesInspecteur.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_coordonneesInspecteur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_coordonneesInspecteur.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_coordonneesInspecteur.Image = CType(resources.GetObject("btn_parametrage_coordonneesInspecteur.Image"), System.Drawing.Image)
        Me.btn_parametrage_coordonneesInspecteur.Location = New System.Drawing.Point(48, 120)
        Me.btn_parametrage_coordonneesInspecteur.Name = "btn_parametrage_coordonneesInspecteur"
        Me.btn_parametrage_coordonneesInspecteur.Size = New System.Drawing.Size(180, 24)
        Me.btn_parametrage_coordonneesInspecteur.TabIndex = 23
        Me.btn_parametrage_coordonneesInspecteur.Text = "       Coordonnées Inspecteur"
        Me.btn_parametrage_coordonneesInspecteur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_parametrage_parametrageManometre
        '
        Me.btn_parametrage_parametrageManometre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_parametrageManometre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_parametrageManometre.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_parametrageManometre.Image = CType(resources.GetObject("btn_parametrage_parametrageManometre.Image"), System.Drawing.Image)
        Me.btn_parametrage_parametrageManometre.Location = New System.Drawing.Point(344, 80)
        Me.btn_parametrage_parametrageManometre.Name = "btn_parametrage_parametrageManometre"
        Me.btn_parametrage_parametrageManometre.Size = New System.Drawing.Size(128, 24)
        Me.btn_parametrage_parametrageManometre.TabIndex = 23
        Me.btn_parametrage_parametrageManometre.Text = "    Manomètres"
        Me.btn_parametrage_parametrageManometre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_parametrage_parametrageBuses
        '
        Me.btn_parametrage_parametrageBuses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_parametrageBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_parametrageBuses.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_parametrageBuses.Image = CType(resources.GetObject("btn_parametrage_parametrageBuses.Image"), System.Drawing.Image)
        Me.btn_parametrage_parametrageBuses.Location = New System.Drawing.Point(344, 120)
        Me.btn_parametrage_parametrageBuses.Name = "btn_parametrage_parametrageBuses"
        Me.btn_parametrage_parametrageBuses.Size = New System.Drawing.Size(128, 24)
        Me.btn_parametrage_parametrageBuses.TabIndex = 23
        Me.btn_parametrage_parametrageBuses.Text = "    Buses étalons"
        Me.btn_parametrage_parametrageBuses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_parametrage_parametrageBancs
        '
        Me.btn_parametrage_parametrageBancs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_parametrageBancs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_parametrageBancs.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_parametrageBancs.Image = CType(resources.GetObject("btn_parametrage_parametrageBancs.Image"), System.Drawing.Image)
        Me.btn_parametrage_parametrageBancs.Location = New System.Drawing.Point(344, 160)
        Me.btn_parametrage_parametrageBancs.Name = "btn_parametrage_parametrageBancs"
        Me.btn_parametrage_parametrageBancs.Size = New System.Drawing.Size(128, 24)
        Me.btn_parametrage_parametrageBancs.TabIndex = 23
        Me.btn_parametrage_parametrageBancs.Text = "    Bancs"
        Me.btn_parametrage_parametrageBancs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_parametrage_verificationManometres
        '
        Me.btn_parametrage_verificationManometres.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_verificationManometres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_verificationManometres.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_verificationManometres.Image = CType(resources.GetObject("btn_parametrage_verificationManometres.Image"), System.Drawing.Image)
        Me.btn_parametrage_verificationManometres.Location = New System.Drawing.Point(640, 80)
        Me.btn_parametrage_verificationManometres.Name = "btn_parametrage_verificationManometres"
        Me.btn_parametrage_verificationManometres.Size = New System.Drawing.Size(128, 24)
        Me.btn_parametrage_verificationManometres.TabIndex = 23
        Me.btn_parametrage_verificationManometres.Text = "    Manomètres"
        Me.btn_parametrage_verificationManometres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_parametrage_verificationBancs
        '
        Me.btn_parametrage_verificationBancs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_parametrage_verificationBancs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_parametrage_verificationBancs.ForeColor = System.Drawing.Color.White
        Me.btn_parametrage_verificationBancs.Image = CType(resources.GetObject("btn_parametrage_verificationBancs.Image"), System.Drawing.Image)
        Me.btn_parametrage_verificationBancs.Location = New System.Drawing.Point(640, 120)
        Me.btn_parametrage_verificationBancs.Name = "btn_parametrage_verificationBancs"
        Me.btn_parametrage_verificationBancs.Size = New System.Drawing.Size(128, 24)
        Me.btn_parametrage_verificationBancs.TabIndex = 23
        Me.btn_parametrage_verificationBancs.Text = "    Bancs"
        Me.btn_parametrage_verificationBancs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabControl_Statistiques
        '
        Me.tabControl_Statistiques.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_Statistiques.Controls.Add(Me.Panel1)
        Me.tabControl_Statistiques.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_Statistiques.Name = "tabControl_Statistiques"
        Me.tabControl_Statistiques.Size = New System.Drawing.Size(1000, 653)
        Me.tabControl_Statistiques.TabIndex = 6
        Me.tabControl_Statistiques.Text = "Statistiques"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.pctLogoStat)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 656)
        Me.Panel1.TabIndex = 3
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.11086!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.88914!))
        Me.TableLayoutPanel2.Controls.Add(Me.cbxAnneeReference, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox9, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox26, 2, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(493, 118)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(479, 28)
        Me.TableLayoutPanel2.TabIndex = 43
        '
        'cbxAnneeReference
        '
        Me.cbxAnneeReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxAnneeReference.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.cbxAnneeReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAnneeReference.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.cbxAnneeReference.FormattingEnabled = True
        Me.cbxAnneeReference.Location = New System.Drawing.Point(4, 4)
        Me.cbxAnneeReference.Name = "cbxAnneeReference"
        Me.cbxAnneeReference.Size = New System.Drawing.Size(181, 21)
        Me.cbxAnneeReference.TabIndex = 41
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(203, 4)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(32, 20)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 36
        Me.PictureBox9.TabStop = False
        '
        'TextBox26
        '
        Me.TextBox26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox26.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.TextBox26.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.TextBox26.Location = New System.Drawing.Point(242, 4)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(233, 13)
        Me.TextBox26.TabIndex = 42
        Me.TextBox26.TabStop = False
        Me.TextBox26.Text = "depuis l'activation CRODIP"
        Me.TextBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.laNomAgent, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.laNomStructure, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label22, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label24, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label26, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox4, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox5, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox6, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox7, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox8, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox9, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox10, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox11, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox12, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox13, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox14, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox15, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox16, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox17, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox18, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox19, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox20, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox21, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox22, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox23, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox24, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.laNomStructure2, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.laNomAgent2, 4, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(19, 145)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(953, 448)
        Me.TableLayoutPanel1.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.Location = New System.Drawing.Point(4, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(467, 35)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "       Nombre de contrôles réalisés  :"
        '
        'laNomAgent
        '
        Me.laNomAgent.BackColor = System.Drawing.Color.Transparent
        Me.laNomAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laNomAgent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laNomAgent.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.laNomAgent.Location = New System.Drawing.Point(597, 1)
        Me.laNomAgent.Name = "laNomAgent"
        Me.laNomAgent.Size = New System.Drawing.Size(112, 16)
        Me.laNomAgent.TabIndex = 39
        Me.laNomAgent.Text = "inspecteur"
        Me.laNomAgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'laNomStructure
        '
        Me.laNomStructure.BackColor = System.Drawing.Color.Transparent
        Me.laNomStructure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laNomStructure.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laNomStructure.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.laNomStructure.Location = New System.Drawing.Point(478, 1)
        Me.laNomStructure.Name = "laNomStructure"
        Me.laNomStructure.Size = New System.Drawing.Size(112, 16)
        Me.laNomStructure.TabIndex = 38
        Me.laNomStructure.Text = "structure"
        Me.laNomStructure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlStructureAnnee", True))
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Location = New System.Drawing.Point(478, 21)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(112, 20)
        Me.TextBox3.TabIndex = 40
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bsStatistiques
        '
        Me.bsStatistiques.DataSource = GetType(Crodip_agent.StatsCrodip)
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label22.Image = CType(resources.GetObject("Label22.Image"), System.Drawing.Image)
        Me.Label22.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label22.Location = New System.Drawing.Point(4, 89)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(467, 40)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "       Pourcentage de conclusion ""Bon état""   :"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label24.Image = CType(resources.GetObject("Label24.Image"), System.Drawing.Image)
        Me.Label24.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label24.Location = New System.Drawing.Point(4, 160)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(467, 32)
        Me.Label24.TabIndex = 46
        Me.Label24.Text = "       Pourcentage de conclusion ""CP"" :"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label26.Image = CType(resources.GetObject("Label26.Image"), System.Drawing.Image)
        Me.Label26.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label26.Location = New System.Drawing.Point(4, 231)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(467, 32)
        Me.Label26.TabIndex = 48
        Me.Label26.Text = "       Pourcentage de pulvérisateurs ""Réparation avant"" :"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlInspecteurAnnee", True))
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(597, 21)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(112, 20)
        Me.TextBox1.TabIndex = 50
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlStructureTotal", True))
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox2.Location = New System.Drawing.Point(716, 21)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(112, 20)
        Me.TextBox2.TabIndex = 51
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlInspecteurTotal", True))
        Me.TextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox4.Location = New System.Drawing.Point(835, 21)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(114, 20)
        Me.TextBox4.TabIndex = 52
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_OK_StructureAnnee", True))
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Location = New System.Drawing.Point(478, 92)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(112, 20)
        Me.TextBox5.TabIndex = 53
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_OK_InspecteurAnnee", True))
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Location = New System.Drawing.Point(597, 92)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(112, 20)
        Me.TextBox6.TabIndex = 54
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox7
        '
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_OK_StructureTotal", True))
        Me.TextBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox7.Location = New System.Drawing.Point(716, 92)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(112, 20)
        Me.TextBox7.TabIndex = 55
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox8
        '
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_OK_InspecteurTotal", True))
        Me.TextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox8.Location = New System.Drawing.Point(835, 92)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(114, 20)
        Me.TextBox8.TabIndex = 56
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox9
        '
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_CP_StructureAnnee", True))
        Me.TextBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox9.Location = New System.Drawing.Point(478, 163)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(112, 20)
        Me.TextBox9.TabIndex = 57
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox10
        '
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_CP_InspecteurAnnee", True))
        Me.TextBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox10.Location = New System.Drawing.Point(597, 163)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(112, 20)
        Me.TextBox10.TabIndex = 58
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox11
        '
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_CP_StructureTotal", True))
        Me.TextBox11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox11.Location = New System.Drawing.Point(716, 163)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(112, 20)
        Me.TextBox11.TabIndex = 59
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox12
        '
        Me.TextBox12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_CP_InspecteurTotal", True))
        Me.TextBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox12.Location = New System.Drawing.Point(835, 163)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(114, 20)
        Me.TextBox12.TabIndex = 60
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox13
        '
        Me.TextBox13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_ReparAvant_StructureAnnee", True))
        Me.TextBox13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox13.Location = New System.Drawing.Point(478, 234)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(112, 20)
        Me.TextBox13.TabIndex = 61
        Me.TextBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox14
        '
        Me.TextBox14.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_ReparAvant_InspecteurAnnee", True))
        Me.TextBox14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox14.Location = New System.Drawing.Point(597, 234)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(112, 20)
        Me.TextBox14.TabIndex = 62
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox15
        '
        Me.TextBox15.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_ReparAvant_InspecteurTotal", True))
        Me.TextBox15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox15.Location = New System.Drawing.Point(835, 234)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(114, 20)
        Me.TextBox15.TabIndex = 63
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label6.Location = New System.Drawing.Point(4, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(467, 30)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "       Pourcentage de pulvérisateurs ""Auto Contrôle"":"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label12.Location = New System.Drawing.Point(4, 373)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(467, 35)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "       Pourcentage de pulvérisateurs ""Pre Contrôle"" :"
        '
        'TextBox16
        '
        Me.TextBox16.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_ReparAvant_StructureTotal", True))
        Me.TextBox16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox16.Location = New System.Drawing.Point(716, 234)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(112, 20)
        Me.TextBox16.TabIndex = 69
        Me.TextBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox17
        '
        Me.TextBox17.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_AutoControle_StructureAnnee", True))
        Me.TextBox17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox17.Location = New System.Drawing.Point(478, 305)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.Size = New System.Drawing.Size(112, 20)
        Me.TextBox17.TabIndex = 70
        Me.TextBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox18
        '
        Me.TextBox18.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_AutoControle_InspecteurAnnee", True))
        Me.TextBox18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox18.Location = New System.Drawing.Point(597, 305)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.ReadOnly = True
        Me.TextBox18.Size = New System.Drawing.Size(112, 20)
        Me.TextBox18.TabIndex = 71
        Me.TextBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox19
        '
        Me.TextBox19.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_AutoControle_StructureTotal", True))
        Me.TextBox19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox19.Location = New System.Drawing.Point(716, 305)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.ReadOnly = True
        Me.TextBox19.Size = New System.Drawing.Size(112, 20)
        Me.TextBox19.TabIndex = 72
        Me.TextBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox20
        '
        Me.TextBox20.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_AutoControle_InspecteurTotal", True))
        Me.TextBox20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox20.Location = New System.Drawing.Point(835, 305)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.ReadOnly = True
        Me.TextBox20.Size = New System.Drawing.Size(114, 20)
        Me.TextBox20.TabIndex = 73
        Me.TextBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox21
        '
        Me.TextBox21.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_PreControle_StructureAnnee", True))
        Me.TextBox21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox21.Location = New System.Drawing.Point(478, 376)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.ReadOnly = True
        Me.TextBox21.Size = New System.Drawing.Size(112, 20)
        Me.TextBox21.TabIndex = 74
        Me.TextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox22
        '
        Me.TextBox22.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_PreControle_InspecteurAnnee", True))
        Me.TextBox22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox22.Location = New System.Drawing.Point(597, 376)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.ReadOnly = True
        Me.TextBox22.Size = New System.Drawing.Size(112, 20)
        Me.TextBox22.TabIndex = 75
        Me.TextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox23
        '
        Me.TextBox23.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_PreControle_StructureTotal", True))
        Me.TextBox23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox23.Location = New System.Drawing.Point(716, 376)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.ReadOnly = True
        Me.TextBox23.Size = New System.Drawing.Size(112, 20)
        Me.TextBox23.TabIndex = 76
        Me.TextBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox24
        '
        Me.TextBox24.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrl_PreControle_InspecteurTotal", True))
        Me.TextBox24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox24.Location = New System.Drawing.Point(835, 376)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.ReadOnly = True
        Me.TextBox24.Size = New System.Drawing.Size(114, 20)
        Me.TextBox24.TabIndex = 77
        Me.TextBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'laNomStructure2
        '
        Me.laNomStructure2.BackColor = System.Drawing.Color.Transparent
        Me.laNomStructure2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laNomStructure2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laNomStructure2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.laNomStructure2.Location = New System.Drawing.Point(716, 1)
        Me.laNomStructure2.Name = "laNomStructure2"
        Me.laNomStructure2.Size = New System.Drawing.Size(112, 16)
        Me.laNomStructure2.TabIndex = 78
        Me.laNomStructure2.Text = "structure"
        Me.laNomStructure2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'laNomAgent2
        '
        Me.laNomAgent2.BackColor = System.Drawing.Color.Transparent
        Me.laNomAgent2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laNomAgent2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laNomAgent2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.laNomAgent2.Location = New System.Drawing.Point(835, 1)
        Me.laNomAgent2.Name = "laNomAgent2"
        Me.laNomAgent2.Size = New System.Drawing.Size(112, 16)
        Me.laNomAgent2.TabIndex = 79
        Me.laNomAgent2.Text = "inspecteur"
        Me.laNomAgent2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctLogoStat
        '
        Me.pctLogoStat.Image = CType(resources.GetObject("pctLogoStat.Image"), System.Drawing.Image)
        Me.pctLogoStat.Location = New System.Drawing.Point(896, 24)
        Me.pctLogoStat.Name = "pctLogoStat"
        Me.pctLogoStat.Size = New System.Drawing.Size(76, 84)
        Me.pctLogoStat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogoStat.TabIndex = 6
        Me.pctLogoStat.TabStop = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(16, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 24)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "     Statistiques"
        '
        'tabControl_Facturation
        '
        Me.tabControl_Facturation.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.tabControl_Facturation.Controls.Add(Me.btn_Facturation)
        Me.tabControl_Facturation.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_Facturation.Name = "tabControl_Facturation"
        Me.tabControl_Facturation.Padding = New System.Windows.Forms.Padding(3)
        Me.tabControl_Facturation.Size = New System.Drawing.Size(1000, 653)
        Me.tabControl_Facturation.TabIndex = 7
        Me.tabControl_Facturation.Text = "Facturation"
        '
        'btn_Facturation
        '
        Me.btn_Facturation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Facturation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Facturation.ForeColor = System.Drawing.Color.White
        Me.btn_Facturation.Image = CType(resources.GetObject("btn_Facturation.Image"), System.Drawing.Image)
        Me.btn_Facturation.Location = New System.Drawing.Point(23, 26)
        Me.btn_Facturation.Name = "btn_Facturation"
        Me.btn_Facturation.Size = New System.Drawing.Size(180, 36)
        Me.btn_Facturation.TabIndex = 32
        Me.btn_Facturation.Text = "        Facturation"
        Me.btn_Facturation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'accueil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabControl)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "accueil"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Crodip"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl.ResumeLayout(False)
        Me.tabControl_accueil.ResumeLayout(False)
        Me.accueil_panelAlertesContener.ResumeLayout(False)
        Me.accueil_panelAlertesContener.PerformLayout()
        CType(Me.dgv_ControleRegulier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsControleQuotidien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picsRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accueil_panelAlertes.ResumeLayout(False)
        Me.tabAccueil_mesinfos.ResumeLayout(False)
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl_clientele.ResumeLayout(False)
        Me.panel_clientele_ficheClient.ResumeLayout(False)
        Me.grp_ficheClient_ListePulve.ResumeLayout(False)
        CType(Me.dgvPulveExploit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcPulverisateurTMP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.panel_ListeDesControles.ResumeLayout(False)
        Me.panel_clientele_LstCtrlCtriteres.ResumeLayout(False)
        Me.panel_clientele_LstCtrlCtriteres.PerformLayout()
        Me.pnl_SearchDates.ResumeLayout(False)
        Me.pnl_SearchDates.PerformLayout()
        CType(Me.btn_refresh_lst_clients, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_rechercher_exploitant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pct_LogoControle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl_pulverisateurs.ResumeLayout(False)
        CType(Me.listPulve_btn_refreshList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl_synchro.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.grpParamSynhcro.ResumeLayout(False)
        Me.grpParamSynhcro.PerformLayout()
        CType(Me.pctLogoSynchro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl_outilscomp.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.pctbx_Docs_refresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_ModuleDocumentaire.Panel1.ResumeLayout(False)
        Me.SplitContainer_ModuleDocumentaire.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_ModuleDocumentaire, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_ModuleDocumentaire.ResumeLayout(False)
        CType(Me.pctLogoOutilComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl_parametrage.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.pctLogoParametrage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl_Statistiques.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.bsStatistiques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctLogoStat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl_Facturation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " *** Loaders *** "
    Private _idAgent As Integer
    Public Property IDAgent() As Integer
        Get
            Return _idAgent
        End Get
        Set(ByVal value As Integer)
            _idAgent = value
        End Set
    End Property
    Public Sub SetContexte(pidAgent As Integer)
        IDAgent = pidAgent
        CSDebug.dispInfo("Accueil.SetContexte IdAgent = " & IDAgent)
        agentCourant = AgentManager.getAgentById(IDAgent)
    End Sub
    ' Chargement form
    Private Sub accueil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CSEnvironnement.checkDateTimePicker(dtpSearchCrit1)
        CSEnvironnement.checkDateTimePicker(dtpSearchCrit2)
        CSEnvironnement.checkDateTimePicker(dtp_ControleRegulier)

        If Not Directory.Exists(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE) Then
            Directory.CreateDirectory(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE)
        End If
        If Not Directory.Exists(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC) Then
            Directory.CreateDirectory(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)
        End If
        If Not Directory.Exists(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE) Then
            Directory.CreateDirectory(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE)
        End If
        If Not Directory.Exists(GlobalsCRODIP.CONST_PATH_EXP_FACTURE) Then
            Directory.CreateDirectory(GlobalsCRODIP.CONST_PATH_EXP_FACTURE)
        End If

        Try

            'Création du Fichier ZIP des PDFs
            If My.Settings.TypeStockPDF = "ZIP" Then
                If Not File.Exists(GlobalsCRODIP.CONST_STOCK_PDFS) Then
                    Using z As New ZipFile()
                        z.Password = GlobalsCRODIP.CONST_PDFS_DIAG_PWD
                        Dim l As String() = System.IO.Directory.GetFiles(GlobalsCRODIP.CONST_PATH_EXP, "*.pdf")
                        For Each f As String In l
                            If f.Contains("MANOMETRECONTROLE") Then
                                z.AddFile(f, GlobalsCRODIP.CONST_PATH_EXP & "MANOMETRECONTROLE/")
                            Else
                                If f.Contains("BANCMESURE") Then
                                    z.AddFile(f, GlobalsCRODIP.CONST_PATH_EXP & "BANCMESURE/")
                                Else
                                    z.AddFile(f, GlobalsCRODIP.CONST_PATH_EXP & "DIAGNOSTIC/")
                                End If

                            End If
                        Next
                        z.Save(GlobalsCRODIP.CONST_STOCK_PDFS)
                    End Using
                End If
            End If
            If My.Settings.TypeStockPDF = "DIR" Then
                If Not Directory.Exists(GlobalsCRODIP.CONST_STOCK_PDFS) Then
                    Dim oDI As New DirectoryInfo(GlobalsCRODIP.CONST_STOCK_PDFS)
                    oDI.Create()
                    oDI.Attributes = FileAttributes.Hidden

                    oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE)
                    oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE)
                    oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)

                    'Transfert des fichiers depuis le publicExport dans le dossier Caché
                    Dim l As String()
                    l = System.IO.Directory.GetFiles(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE, "*.pdf")
                    For Each f As String In l
                        Try
                            System.IO.File.Copy(f, My.Settings.StockPDF & "/" & f)
                        Catch ex As Exception

                        End Try
                    Next
                    l = System.IO.Directory.GetFiles(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE, "*.pdf")
                    For Each f As String In l
                        Try
                            System.IO.File.Copy(f, My.Settings.StockPDF & "/" & f)
                        Catch ex As Exception

                        End Try
                    Next
                    l = System.IO.Directory.GetFiles(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC, "*.pdf")
                    For Each f As String In l
                        Try
                            System.IO.File.Copy(f, My.Settings.StockPDF & "/" & f)
                        Catch ex As Exception

                        End Try
                    Next
                End If
            End If
        Catch ex As Exception

        End Try




        ' Informations sur l'agent courant
        m_bDuringLoad = True
        lbl_infosAgent_IdCrodip.Text = agentCourant.numeroNational
        lbl_infosAgent_Nom.Text = agentCourant.nom
        lbl_infosAgent_Prenom.Text = agentCourant.prenom
        lbl_infosAgent_dateDernCnx.Text = CSDate.mysql2access(agentCourant.dateDerniereConnexion)
        Dim dateDernSynhcro As String = CSDate.mysql2access(agentCourant.dateDerniereSynchro)
        If dateDernSynhcro = "01/01/1970 00:00:00" Or dateDernSynhcro = "" Or dateDernSynhcro = "00/00/0000 00:00:00" Then
            lbl_infosAgent_dateDernSynchro.Text = "--/--/-- --:--:--"
        Else
            lbl_infosAgent_dateDernSynchro.Text = dateDernSynhcro
        End If
        'Affichage de la Liste des clients avec les alertes
        m_Exploitation_isShowAll = False
        btn_proprietaire_derniersControles_setLabel()

        'Paramétrage de la synhchro (Affichage uniquement en mode debug)
        grpParamSynhcro.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG

        ' Affichage des critères de tri
        pnl_SearchDates.Top = client_search_query.Top
        pnl_SearchDates.Left = client_search_query.Left
        list_search_fieldSearch.Items.Clear()
        Dim objComboItem_Tous As New objComboItem("0", "Tous")
        Dim objComboItem_SIREN As New objComboItem("1", "N° SIREN")
        Dim objComboItem_RS As New objComboItem("2", "Raison Sociale")
        Dim objComboItem_Prenom As New objComboItem("3", "Prénom")
        Dim objComboItem_Nom As New objComboItem("4", "Nom")
        Dim objComboItem_DateC As New objComboItem("5", "Date de controle")
        Dim objComboItem_Pulve As New objComboItem("6", "Numero Pulverisateur")
        Dim objComboItem_ID As New objComboItem("6", "Numéro Controle")

        If Not agentCourant.isGestionnaire Then
            'Les données ont déjà été Chargée par la page de login
            ' Init()
            'Controle Regulier
            Me.m_SaveFileDialog.FileName = My.Settings.AutoTestDefaultFileName
            'Ecran des Stats
            'Affichage du nom de l'agent et de la Structure
            laNomAgent.Text = agentCourant.nom
            laNomStructure.Text = agentCourant.NomStructure
            laNomAgent2.Text = agentCourant.nom
            laNomStructure2.Text = agentCourant.NomStructure
            cbxAnneeReference.Items.Clear()
            For annee As Integer = Date.Now.Year To 2000 Step -1
                cbxAnneeReference.Items.Add(annee.ToString())
            Next
            cbxAnneeReference.SelectedIndex = 0

            list_search_fieldSearch.Items.Add(objComboItem_Tous)
            list_search_fieldSearch.Items.Add(objComboItem_SIREN)
            list_search_fieldSearch.Items.Add(objComboItem_RS)
            list_search_fieldSearch.Items.Add(objComboItem_Prenom)
            list_search_fieldSearch.Items.Add(objComboItem_Nom)
            list_search_fieldSearch.Items.Add(objComboItem_DateC)
            list_search_fieldSearch.Items.Add(objComboItem_Pulve)


            btnParamModeSimplifie.Visible = False
            btnMAJsynchroAgent.Visible = False

            panel_clientele_ficheClient.Visible = False
            panel_ListeDesControles.Visible = True
            panel_ListeDesControles.Dock = DockStyle.Fill

        Else
            btn_controleQuotdien_Exporter.Enabled = False
            btn_controleQuotdien_Valider.Enabled = False
            btn_ficheClient_diagnostic_nouveau.Enabled = False
            btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
            btn_ficheClient_diagnostic_voir.Enabled = False
            btn_outilsComplementaires_calcDebitBuses.Enabled = False
            btn_outilsComplementaires_calcVolumeHectare.Enabled = False
            btn_parametrage_coordonneesInspecteur.Enabled = False
            btn_parametrage_coordonneesOrganisme.Enabled = False
            btn_parametrage_facturation.Enabled = False
            btn_parametrage_parametrageBancs.Enabled = False
            btn_parametrage_parametrageBuses.Enabled = False
            btn_parametrage_parametrageManometre.Enabled = False
            btn_parametrage_tarifs.Enabled = False
            btn_parametrage_verificationBancs.Enabled = False
            btn_parametrage_verificationManometres.Enabled = False
            btn_proprietaire_ajouter.Enabled = False
            btn_proprietaire_derniersControles.Enabled = False
            btn_proprietaire_exportCsv.Enabled = False
            btn_proprietaire_supprimer.Enabled = False
            btnAjoutPulve.Enabled = False
            btnSupprPulve.Enabled = False
            btn_controleQuotdien_Exporter.Visible = False
            btn_controleQuotdien_Valider.Visible = False
            btn_ficheClient_diagnostic_nouveau.Visible = False
            btn_ficheClient_diagnostic_nouvelleCV.Visible = False
            btn_ficheClient_diagnostic_voir.Visible = False
            btn_outilsComplementaires_calcDebitBuses.Visible = False
            btn_outilsComplementaires_calcVolumeHectare.Visible = False
            btn_parametrage_coordonneesInspecteur.Visible = False
            btn_parametrage_coordonneesOrganisme.Visible = False
            btn_parametrage_facturation.Visible = False
            btn_parametrage_parametrageBancs.Visible = False
            btn_parametrage_parametrageBuses.Visible = False
            btn_parametrage_parametrageManometre.Visible = False
            btn_parametrage_tarifs.Visible = False
            btn_parametrage_verificationBancs.Visible = False
            btn_parametrage_verificationManometres.Visible = False
            btn_proprietaire_ajouter.Visible = False
            btn_proprietaire_derniersControles.Visible = False
            btn_proprietaire_exportCsv.Visible = False
            btn_proprietaire_supprimer.Visible = False
            btnAjoutPulve.Visible = False
            btnSupprPulve.Visible = False
            lbl_refresh_lst_clients.Enabled = False
            accueil_panelAlertesContener.Visible = False

            list_search_fieldSearch.Items.Add(objComboItem_ID)

            btnParamModeSimplifie.Visible = True

        End If
        list_search_fieldSearch.SelectedIndex = 0

        'REDIECTION DE LA DATA SOURCE du dataGRIDView !!!!!!
        dgvPulveExploit.DataSource = m_BindingListOfPulve

        If agentCourant.isGestionnaire Then
            tabControl.TabPages.RemoveByKey(tabControl_pulverisateurs.Name)
            tabControl.TabPages.RemoveByKey(tabControl_synchro.Name)
            tabControl.TabPages.RemoveByKey(tabControl_parametrage.Name)
            tabControl.TabPages.RemoveByKey(tabControl_Statistiques.Name)
        End If

        'Gestion du Mode Simplifié
        'Module Documentaire
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
            'on ne peut rendre invisible ou inactive une page, il faut la supprimer de la tabPages
            tabControl.TabPages.RemoveByKey(tabControl_outilscomp.Name)
        End If
        If GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            'on ne peut rendre invisible ou inactive une page, il faut la supprimer de la tabPages
            tabControl.TabPages.RemoveByKey(tabControl_accueil.Name)
            tabControl.TabPages.RemoveByKey(tabControl_pulverisateurs.Name)
            tabControl.TabPages.RemoveByKey(tabControl_synchro.Name)
            tabControl.TabPages.RemoveByKey(tabControl_parametrage.Name)
            tabControl.TabPages.RemoveByKey(tabControl_Statistiques.Name)
        End If
        '        tabControl_outilscomp.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        pctbx_Docs_refresh.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        lblModuledocumentaire.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        SplitContainer_ModuleDocumentaire.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        btn_imprimerDoc.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        'Paramétrage
        btn_parametrage_coordonneesOrganisme.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        btn_parametrage_coordonneesInspecteur.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        btn_parametrage_tarifs.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        btn_parametrage_facturation.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        lblParametresOrganisme.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        lblIdentifiantPulve.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        '        lblParametrageAppareilsMesures.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        'btn_parametrage_parametrageManometre.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        'btn_parametrage_parametrageBuses.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        'btn_parametrage_parametrageBancs.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        'lblMaterielsSupprimes.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
            pctLogo.Image = Crodip_agent.Resources.logoCRODIPIMG
            pct_LogoControle.Image = Crodip_agent.Resources.logoCRODIPIMG
            pctLogoOutilComp.Image = Crodip_agent.Resources.logoCRODIPIMG
            pctLogoParametrage.Image = Crodip_agent.Resources.logoCRODIPIMG
            pctLogoStat.Image = Crodip_agent.Resources.logoCRODIPIMG
            pctLogoSynchro.Image = Crodip_agent.Resources.logoCRODIPIMG

        Else
            pctLogo.Image = Crodip_agent.Resources.logo_crodipIndigo
            pct_LogoControle.Image = Crodip_agent.Resources.logo_crodipIndigo
            pctLogoOutilComp.Image = Crodip_agent.Resources.logo_crodipIndigo
            pctLogoParametrage.Image = Crodip_agent.Resources.logo_crodipIndigo
            pctLogoStat.Image = Crodip_agent.Resources.logo_crodipIndigo
            pctLogoSynchro.Image = Crodip_agent.Resources.logo_crodipIndigo
        End If

        m_bDuringLoad = False
        If Not GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            pct_LogoControle.Visible = True
            Statusbar.display("Bienvenu(e) sur le logiciel Crodip Agent v" & GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD, False)
        End If
    End Sub

    ''' <summary>
    ''' Iniitalization de la la fênêtre
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Init(pIdAgent As Integer)
        IDAgent = pIdAgent
        agentCourant = AgentManager.getAgentById(pIdAgent)
        ' Affichage des alertes
        Me.Text = agentCourant.nom & " " & agentCourant.prenom & " / " & agentCourant.NomStructure
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
            Me.Text = Me.Text & " - Mode Simplifié - "
        End If
        If GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            Me.Text = agentCourant.nom & " " & agentCourant.prenom & " / " & agentCourant.NomStructure & " - Mode Formation - "
        End If
        loadAccueilAlerts()

        LoadListeExploitation()


        LoadListControleRegulier()

    End Sub
    ' Changement d'onglet
    Private Sub tabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControl.SelectedIndexChanged
        For Each oTab As TabPage In Me.tabControl.TabPages
            oTab.ImageIndex = -1
        Next

        tabControl.SelectedTab.ImageIndex = 0


    End Sub

#End Region

#Region " Fonctions de chargement "


    ''' <summary>
    ''' Chargement de la liste des exploitations
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub LoadListeExploitation()
        Dim statusbarOldMessage As String = Statusbar.getLibelle

        Dim pisAlerte As Boolean = Not m_Exploitation_isShowAll

        Statusbar.display("Chargement de la liste des exploitations ...", True)


        '**************************
        ' Récupération de la liste des clients
        '**************************
        Dim oCol As List(Of Exploitation)
        'récupération de la liste des clients
        oCol = ExploitationManager.getListeExploitation(agentCourant, DateTime.Now)

        AfficheListeExploitation(pisAlerte, oCol)

        Statusbar.display(statusbarOldMessage, False)
    End Sub

    Private Sub AfficheListeExploitation(ByVal pisAlerte As Boolean, ByVal pColExploit As List(Of Exploitation))
        ' On récupère la liste des profils locaux
        Dim intCount As Decimal = 0
        Dim oExploit As Exploitation
        'Mémorisation des elements Sélectionné
        Dim lstStringSelected As New List(Of String)
        If list_clients.SelectedItems.Count > 0 Then
            For Each obj As ListViewItem In list_clients.SelectedItems
                lstStringSelected.Add(obj.Tag)
            Next
        End If

        list_clients.Items.Clear()
        For Each oExploit In pColExploit
            'si l'affichage est en mode alerte
            '   on n'affiche que les exploitations
            '   Qui n'ont pas de date de dernier controle
            '       ou
            '   Qui ont un pulvé en alerte (date de prochain controle < aujourd'hui)


            If (pisAlerte And (oExploit.nPulvesAlerte = 0 And oExploit.dateDernierControle <> "")) Then
                'On n'affiche pas ces exploitations
            Else
                If Not oExploit.isSupprime Then
                    Dim oItem As ListViewItem
                    oItem = list_clients.Items.Add("")

                    InitLVItem(oItem, oExploit)

                    'Sélection des Items Précédement Selectionnés
                    If lstStringSelected.Contains(oExploit.id) Then
                        oItem.Selected = True
                    End If


                    intCount = intCount + 1
                End If
            End If

        Next oExploit
        list_clients_ColumnClick(list_clients, New ColumnClickEventArgs(7))
        '        list_clients.ListViewItemSorter = New CSListViewItemComparer(7, 1, "date")
        '       list_clients.Sort()
    End Sub
    Private Function InitLVItem(oItem As ListViewItem, oExploit As Exploitation) As Boolean
        Dim breturn As Boolean
        Try

            oItem.SubItems.Clear()
            oItem.Name = oExploit.id
            oItem.Tag = oExploit.id
            oItem.Text = oExploit.numeroSiren
            oItem.SubItems.Add(oExploit.raisonSociale) 'RS
            oItem.SubItems.Add(oExploit.prenomExploitant) ' Prénom
            oItem.SubItems.Add(oExploit.nomExploitant) ' Nom
            oItem.SubItems.Add(oExploit.adresse) ' Adresse
            oItem.SubItems.Add(oExploit.codePostal) ' Code postal
            oItem.SubItems.Add(oExploit.commune) ' Commune
            Console.WriteLine(oExploit.dateProchainControle)
            If oExploit.dateProchainControle <> "" And oExploit.dateProchainControle <> "2001-01-01 00:00:00" And oExploit.dateProchainControle <> "1899-12-30 00:00:00" Then
                Dim tmpDateNextDiag As Date = oExploit.dateProchainControle
                oItem.SubItems.Add(tmpDateNextDiag.ToShortDateString)  ' Prochain controle
            Else
                oItem.SubItems.Add("")  ' Pas de prochain  contrôle
            End If
            ' Détection des alertes
            If oExploit.nPulvesAlerte > 0 Then
                oItem.BackColor = System.Drawing.Color.LightBlue
                oItem.ForeColor = System.Drawing.Color.Black
            End If
            breturn = True
        Catch ex As Exception
            CSDebug.dispWarn("Accueil:InitLVItem ERR: ", ex)
            breturn = False
        End Try
        Return breturn
    End Function
    ''' <summary>
    ''' Chargement de la liste des pulvé d'un client en fonction des droits de l'agent
    ''' </summary>
    ''' <param name="isAlerte"></param>
    ''' <remarks></remarks>
    Public Sub loadListPulveExploitation(ByVal isAlerte As Boolean)
        ' On récupère le client sélectionné

        panel_clientele_LstCtrlCtriteres.Visible = False
        panel_ListeDesControles.Visible = False
        panel_clientele_ficheClient.Visible = True
        panel_clientele_ficheClient.Dock = DockStyle.Fill

        ' On vérifie qu'il y a bien une ligne de sélectionnée
        If list_clients.SelectedItems().Count > 0 Then
            ' Mise à jour de la barre de status
            Statusbar.display("Chargement des pulvérisateurs du  client n°" & list_clients.SelectedItems().Item(0).SubItems.Item(0).Text)

            ' Récupération des données client
            clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)

            ' Affichage des pulvérisateurs du client 
            AfficheListePulvesExploitation(clientCourant)

            ' Mise à jour de la barre de status
            Statusbar.display("Client n°" & list_clients.SelectedItems().Item(0).SubItems.Item(0).Text)
        Else
            ' Mise à jour de la barre de status
            Statusbar.display("Client inconnu.")
        End If
    End Sub
    Public Sub RefreshLVIExploitation(pIdExploit As String)
        Debug.Assert(Not String.IsNullOrEmpty(pIdExploit), "IdExploit doit être renseigné")
        Dim tabItem As ListViewItem()
        Dim oItem As ListViewItem
        Dim oExploit As Exploitation
        tabItem = list_clients.Items.Find(pIdExploit, False)
        oExploit = ExploitationManager.getExploitationById(pIdExploit)
        If tabItem.Length > 0 Then
            oItem = tabItem(0)
            InitLVItem(oItem, oExploit)
            list_clients.Refresh()
        Else
            oItem = New ListViewItem()
            InitLVItem(oItem, oExploit)
            list_clients.Items.Insert(0, oItem)
        End If
    End Sub
    Public Sub RemoveLVIExploitation(pIdExploit As String)
        Debug.Assert(Not String.IsNullOrEmpty(pIdExploit), "IdExploi doit être renseigné")
        Dim tabItem As ListViewItem()
        Dim oItem As ListViewItem
        tabItem = list_clients.Items.Find(pIdExploit, False)
        If tabItem.Length > 0 Then
            oItem = tabItem(0)
            oItem.Remove()
            list_clients.Refresh()
        End If
    End Sub

    Public Sub AfficheListePulvesExploitation(pExploit As Exploitation)
        Try
            lstPulves_client_raisonSociale.Text = pExploit.raisonSociale
            lstPulves_client_proprioSiren.Text = "M. " & pExploit.nomExploitant & " " & pExploit.prenomExploitant & " - N° SIREN : " & pExploit.numeroSiren
            btn_ficheClient_diagnostic_nouveau.Enabled = False
            btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
            btn_ficheClient_diagnostic_voir.Enabled = False

            'list_ficheClient_puverisateur.Items.Clear()
            Dim lstPulverisateurs As New List(Of Pulverisateur)
            lstPulverisateurs.AddRange(PulverisateurManager.getPulverisateurByClientId(pExploit.id, ""))
            'JE Recréé la liste sotable des pulvés (je ne sais pas pourquoi je dois la recrer)
            m_BindingListOfPulve = New SortableBindingList(Of Pulverisateur)(lstPulverisateurs)
            'Et donc j'affecte cette liste du DataGridView
            'dgvPulveExploit.DataSource = Nothing
            dgvPulveExploit.Rows.Clear()
            dgvPulveExploit.ClearSelection()
            dgvPulveExploit.DataSource = m_BindingListOfPulve
            dgvPulveExploit.ClearSelection()
            dgvPulveExploit.Refresh()


        Catch ex As Exception
            CSDebug.dispWarn("Accueil:AfficheListePulvesExploitation ERR: " & ex.Message.ToString)
        End Try

    End Sub
    Public Function loadListPulve() As Boolean

        Dim bReturn As Boolean
        Try

            Dim statusbarOldMessage As String = Statusbar.getLibelle
            Statusbar.display("Chargement de la liste des pulvérisateurs...", True)

            ' On récupère la liste des pulvés
            Dim arrPulverisateurs As List(Of Pulverisateur) = PulverisateurManager.getPulverisateurList(agentCourant, "")
            '
            Dim tmpPulverisateur As Pulverisateur
            listPulverisateurs.Items.Clear()
            For Each tmpPulverisateur In arrPulverisateurs
                Try
                    Dim olvItem As ListViewItem = listPulverisateurs.Items.Add("")  ' num natio
                    affichePulvedansListePulve(olvItem, tmpPulverisateur)

                Catch ex As Exception
                    CSDebug.dispError("Accueil.loadListPulve 1 Err: " & ex.Message.ToString)
                End Try
            Next

            Statusbar.display(statusbarOldMessage, False)
            bReturn = True
            CSDebug.dispInfo("loadListPulve2, End")
        Catch ex As Exception
            CSDebug.dispError("Accueil.loadListPulve 2 : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Affiche d'un pulvé dans la liste des pulvé
    ''' </summary>
    ''' <param name="pLvItem"></param>
    ''' <param name="pPulverisateur"></param>
    ''' <remarks></remarks>
    Private Sub affichePulvedansListePulve(pLvItem As ListViewItem, pPulverisateur As Pulverisateur)
        pLvItem.Tag = pPulverisateur.id
        pLvItem.SubItems.Clear()
        pLvItem.Text = Trim(pPulverisateur.numeroNational)
        pLvItem.SubItems.Add(Trim(pPulverisateur.type.ToString))  ' Type
        pLvItem.SubItems.Add(Trim(pPulverisateur.marque.ToString)) ' Marque
        pLvItem.SubItems.Add(Trim(pPulverisateur.RaisonSocialeExploitant))  ' Raison Sociale
        pLvItem.SubItems.Add(Trim(pPulverisateur.PrenomExploitant.ToString)) ' Prénom
        pLvItem.SubItems.Add(Trim(pPulverisateur.NomExploitant.ToString)) ' Nom
        pLvItem.SubItems.Add(Trim(pPulverisateur.codePostal.ToString)) ' Code postal
        pLvItem.SubItems.Add(Trim(pPulverisateur.Commune.ToString)) ' Commune
        If pPulverisateur.dateProchainControle.ToString <> "" And pPulverisateur.dateProchainControle.ToString <> "00:00:00" And pPulverisateur.dateProchainControle.ToString <> "1899-12-30 00:00:00" Then
            Dim tmpDateNextDiag As Date = CSDate.FromCrodipString(pPulverisateur.dateProchainControle)
            pLvItem.SubItems.Add(tmpDateNextDiag.ToShortDateString) ' Dernier contrôle
        Else
            pLvItem.SubItems.Add("") ' Dernier contrôle
        End If

        ' Conclusion du dernier Diag sur le pulvé
        Select Case pPulverisateur.controleEtat
            Case Pulverisateur.controleEtatNOKCC 'Attente de Controle complet
                pLvItem.SubItems.Add(Trim("->CC"))
                pLvItem.BackColor = System.Drawing.Color.Tomato
            Case Pulverisateur.controleEtatNOKCV 'Attente de Contre visite
                pLvItem.SubItems.Add(Trim("->CV"))
                pLvItem.BackColor = System.Drawing.Color.Orange
            Case Pulverisateur.controleEtatOK 'Controle OK
                pLvItem.SubItems.Add(Trim("Ok"))
                pLvItem.BackColor = System.Drawing.Color.LightBlue
        End Select

    End Sub
    ' Fonction permettant de récupérer la liste des alertes sur les pulvés du client sélectionné
    'Function getClientPulveAlerts(ByVal idClient As String)

    '    ' Récupération des pulvérisateur du client 
    '    Dim arrPulverisateurs() As Pulverisateur
    '    Try
    '        Dim tmpPulverisateur As Pulverisateur
    '        Dim intCount As Decimal = 0
    '        list_ficheClient_puverisateur.Items.Clear()
    '        Dim arrPulve As Pulverisateur()
    '        arrPulve = PulverisateurManager.getPulverisateurByClientId(idClient, "")
    '        For Each tmpPulverisateur In arrPulve
    '            ' Détection des alertes
    '            If tmpPulverisateur.isAlerte Then
    '                list_ficheClient_puverisateur.Items(CInt(intCount)).BackColor = System.Drawing.Color.LightBlue
    '                list_ficheClient_puverisateur.Items(CInt(intCount)).ForeColor = System.Drawing.Color.Black
    '                intCount = intCount + 1
    '            End If
    '        Next
    '    Catch ex As Exception
    '        CSDebug.dispError("Client - liste alertes pulvé : " & ex.Message.ToString)
    '    End Try

    'End Function

    Private Sub loadAccueilAlertsManoEtalon(ByRef positionTopAlertes As Integer)
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(accueil))

        Dim nbAlertes_ManometreEtalon_20jr As Integer = 0
        Dim nbAlertes_ManometreEtalon_1mois As Integer = 0
        Dim nbAlertes_ManometreEtalon_1mois7jr As Integer = 0
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_MANOETALON_LOAD, True)
        Dim arrManoEtalon As List(Of ManometreEtalon) = ManometreEtalonManager.getManometreEtalonByStructureId(agentCourant.idStructure, True)
        For Each tmpManoEtalon As ManometreEtalon In arrManoEtalon
            Dim tmpDateLCManoControle As Date = CSDate.FromCrodipString(tmpManoEtalon.dateDernierControleS)
            Dim tmpCompareManoControleAlerte20jr As Integer = tmpDateLCManoControle.CompareTo(DateAdd(DateInterval.DayOfYear, -20, Now))
            Dim tmpCompareManoControleAlerte1mois As Integer = tmpDateLCManoControle.CompareTo(DateAdd(DateInterval.Month, -1, Now))
            Dim tmpCompareManoControleAlerte1mois7jr As Integer = tmpDateLCManoControle.CompareTo(DateAdd(DateInterval.DayOfYear, -7, DateAdd(DateInterval.Month, -1, Now)))
            If tmpCompareManoControleAlerte1mois7jr < 1 Then ' 1mois7jrs
                nbAlertes_ManometreEtalon_1mois7jr = nbAlertes_ManometreEtalon_1mois7jr + 1
                ' On ajoute le blocage a la fiche de vie
                If tmpManoEtalon.etat = True Then
                    Try
                        Dim newFicheVieManoEtalon As New FVManometreEtalon(agentCourant)
                        newFicheVieManoEtalon.idManometre = tmpManoEtalon.idCrodip
                        newFicheVieManoEtalon.type = "DESACTIVATION"
                        newFicheVieManoEtalon.auteur = "AGENT"
                        newFicheVieManoEtalon.idAgentControleur = agentCourant.id
                        newFicheVieManoEtalon.caracteristiques =
                        tmpManoEtalon.idCrodip & "|" &
                        tmpManoEtalon.marque & "|" &
                        tmpManoEtalon.classe & "|" &
                        tmpManoEtalon.type & "|" &
                        tmpManoEtalon.fondEchelle & "|" &
                        tmpManoEtalon.idStructure & "|" &
                        tmpManoEtalon.isSynchro & "|" &
                        tmpManoEtalon.dateDernierControleS & "|" &
                        tmpManoEtalon.dateModificationAgent & "|" &
                        tmpManoEtalon.dateModificationCrodip
                        newFicheVieManoEtalon.dateModif = CSDate.ToCRODIPString(Date.Now).ToString
                        newFicheVieManoEtalon.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                        FVManometreEtalonManager.save(newFicheVieManoEtalon)
                        ' On bloque le mano
                        tmpManoEtalon.etat = False
                        ManometreEtalonManager.save(tmpManoEtalon)
                    Catch ex As Exception
                        CSDebug.dispError("Accueil::loadAccueilAlerts : " & ex.Message)
                    End Try
                End If
            ElseIf tmpCompareManoControleAlerte1mois < 1 Then ' 1mois
                nbAlertes_ManometreEtalon_1mois = nbAlertes_ManometreEtalon_1mois + 1
            ElseIf tmpCompareManoControleAlerte20jr < 1 Then ' 20jrs
                nbAlertes_ManometreEtalon_20jr = nbAlertes_ManometreEtalon_20jr + 1
            End If
        Next

        If nbAlertes_ManometreEtalon_20jr > 0 Then
            Dim tmpAlerte As New Label
            tmpAlerte.Name = "alerteManoEtalon_20jr"
            If nbAlertes_ManometreEtalon_20jr > 1 Then
                tmpAlerte.Text = "       Attention, vous avez " & nbAlertes_ManometreEtalon_20jr & " manomètres étalons devant être vérifiés dans 10 jours !"
            Else
                tmpAlerte.Text = "       Attention, vous avez " & nbAlertes_ManometreEtalon_20jr & " manomètre étalon devant être vérifié dans 10 jours !"
            End If
            Controls.Add(tmpAlerte)
            ' Position
            tmpAlerte.Parent = accueil_panelAlertes
            tmpAlerte.Left = 16
            tmpAlerte.Top = positionTopAlertes
            tmpAlerte.TextAlign = ContentAlignment.TopLeft
            ' Taille
            tmpAlerte.Width = 960
            tmpAlerte.Height = 16
            ' Couleur
            tmpAlerte.ForeColor = System.Drawing.Color.FromArgb(CType(242, Byte), CType(84, Byte), CType(23, Byte))
            tmpAlerte.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
            tmpAlerte.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            ' Apparence texte
            Dim tmpFontLabelCategorie As New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpAlerte.Font = tmpFontLabelCategorie
            positionTopAlertes = positionTopAlertes + 24
        End If
        If nbAlertes_ManometreEtalon_1mois > 0 Then
            Dim tmpAlerte As New Label
            tmpAlerte.Name = "alerteManoEtalon_1mois"
            If nbAlertes_ManometreEtalon_1mois > 1 Then
                tmpAlerte.Text = "       Attention, vous venez de dépasser la date autorisé pour " & nbAlertes_ManometreEtalon_1mois & " manomètres étalons. Veuillez effectuer vos contrôles immédiatement !"
            Else
                tmpAlerte.Text = "       Attention, vous venez de dépasser la date autorisé pour " & nbAlertes_ManometreEtalon_1mois & " manomètre étalon. Veuillez effectuer votre contrôle immédiatement !"
            End If
            Controls.Add(tmpAlerte)
            ' Position
            tmpAlerte.Parent = accueil_panelAlertes
            tmpAlerte.Left = 16
            tmpAlerte.Top = positionTopAlertes
            tmpAlerte.TextAlign = ContentAlignment.TopLeft
            ' Taille
            tmpAlerte.Width = 960
            tmpAlerte.Height = 16
            ' Couleur
            tmpAlerte.ForeColor = System.Drawing.Color.FromArgb(CType(242, Byte), CType(84, Byte), CType(23, Byte))
            tmpAlerte.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
            tmpAlerte.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            ' Apparence texte
            Dim tmpFontLabelCategorie As New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpAlerte.Font = tmpFontLabelCategorie
            positionTopAlertes = positionTopAlertes + 24
        End If
        If nbAlertes_ManometreEtalon_1mois7jr > 0 Then
            Dim tmpAlerte As New Label
            tmpAlerte.Name = "alerteManoEtalon_1mois7jr"
            If nbAlertes_ManometreEtalon_1mois7jr > 1 Then
                tmpAlerte.Text = "       Vous avez trop attendu pour vérifier " & nbAlertes_ManometreEtalon_1mois7jr & " manomètres étalons. A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics et vous vous exposez à des sanctions de sa part."
            Else
                tmpAlerte.Text = "       Vous avez trop attendu pour vérifier " & nbAlertes_ManometreEtalon_1mois7jr & " manomètre étalon. A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics et vous vous exposez à des sanctions de sa part."
            End If
            Controls.Add(tmpAlerte)
            ' Position
            tmpAlerte.Parent = accueil_panelAlertes
            tmpAlerte.Left = 16
            tmpAlerte.Top = positionTopAlertes
            tmpAlerte.TextAlign = ContentAlignment.TopLeft
            ' Taille
            tmpAlerte.Width = 960
            tmpAlerte.Height = 32
            ' Couleur
            tmpAlerte.ForeColor = System.Drawing.Color.FromArgb(CType(203, Byte), CType(19, Byte), CType(31, Byte))
            tmpAlerte.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
            tmpAlerte.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            ' Apparence texte
            tmpAlerte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            positionTopAlertes = positionTopAlertes + 40
        End If

    End Sub

    Private Sub loadAccueilAlertsManoControle(ByRef positionTopAlertes As Integer)
        CSDebug.dispInfo("LoadAccueilAlertsManoControle : Debut")

        ' Vérification des alertes sur les manomètre de contrôle
        Dim nbAlertes_ManometreControle_Orange As Integer = 0
        Dim nbAlertes_ManometreControle_Rouge As Integer = 0
        Dim nbAlertes_ManometreControle_Noire As Integer = 0
        Dim nbAlertes_Controle As Integer = 0


        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_MANOCONTROLE_LOAD, True)

        'Chargement de tous les manos
        Dim arrManoControle As List(Of ManometreControle) = ManometreControleManager.getManoControleByStructureId(agentCourant.idStructure, True)
        Dim njours As Integer
        Dim nbManoOrange(3000) As Integer 'Nombre de manomètres devant être controler njours avant la Date Limite
        'Parcours de manos
        Dim AlerteMano As GlobalsCRODIP.ALERTE
        For Each tmpManoControle As ManometreControle In arrManoControle
            AlerteMano = tmpManoControle.getAlerte()

            If AlerteMano = GlobalsCRODIP.ALERTE.CONTROLE Then ' Defaillant
                nbAlertes_Controle = nbAlertes_Controle + 1
            End If

            If AlerteMano = GlobalsCRODIP.ALERTE.NOIRE Then ' 1mois7jrs
                nbAlertes_ManometreControle_Noire = nbAlertes_ManometreControle_Noire + 1
                If tmpManoControle.etat = True Then
                    If My.Settings.DesacMat Then
                        tmpManoControle.Desactiver(agentCourant)
                    End If
                End If
            End If

            If AlerteMano = GlobalsCRODIP.ALERTE.ROUGE Then ' 1mois
                nbAlertes_ManometreControle_Rouge = nbAlertes_ManometreControle_Rouge + 1
            End If
            If AlerteMano = GlobalsCRODIP.ALERTE.ORANGE Then '15 jours
                nbAlertes_ManometreControle_Orange = nbAlertes_ManometreControle_Orange + 1
                njours = tmpManoControle.getNbJoursAvantAlerteRouge()
                If njours < nbManoOrange.Length Then
                    nbManoOrange(Math.Abs(njours)) = nbManoOrange(Math.Abs(njours)) + 1
                End If
            End If
        Next

        'Affichage des alertes 
        Dim sName As String
        Dim sTexte As String
        If nbAlertes_ManometreControle_Orange > 0 Then
            For n As Integer = nbManoOrange.Length To 1 Step -1
                sName = "alerteManoControle_" & n & "jr"
                If nbManoOrange(n - 1) > 0 Then
                    'Si on a des Manos à controler avant n jours
                    If nbManoOrange(n - 1) > 1 Then
                        sTexte = "Attention, vous avez " & nbManoOrange(n - 1) & " manomètres de contrôle devant être vérifiés dans " & (n - 1) & " jours !"
                    Else
                        sTexte = "Attention, vous avez 1 manomètre de contrôle devant être vérifié dans " & n - 1 & " jours !"
                    End If
                    AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, sName, sTexte, positionTopAlertes)
                End If
            Next n
        End If

        If nbAlertes_ManometreControle_Rouge > 0 Then
            sName = "alerteManoControle_1mois"
            If nbAlertes_ManometreControle_Rouge > 1 Then
                sTexte = "Attention, vous venez de dépasser la date autorisée pour " & nbAlertes_ManometreControle_Rouge & " manomètres de contrôle. Veuillez effectuer vos contrôles immédiatement !"
            Else
                sTexte = "Attention, vous venez de dépasser la date autorisée pour 1 manomètre de contrôle. Veuillez effectuer votre contrôle immédiatement !"
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ROUGE, sName, sTexte, positionTopAlertes)
        End If

        If nbAlertes_ManometreControle_Noire > 0 Then
            sName = "alerteManoControle_1mois7jr"
            If nbAlertes_ManometreControle_Noire > 1 Then
                sTexte = "Vous avez trop attendu pour vérifier " & nbAlertes_ManometreControle_Noire & " manomètres de contrôle. A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
            Else
                sTexte = "Vous avez trop attendu pour vérifier 1 manomètre de contrôle. A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, sName, sTexte, positionTopAlertes)
        End If

        If nbAlertes_Controle > 0 Then
            sName = "alerteManoControle_defaillant"
            If nbAlertes_Controle > 1 Then
                sTexte = "Vous avez " & nbAlertes_Controle & " manomètres de contrôle défectueux. Contactez le CRODIP."
            Else
                sTexte = "Vous avez 1 manomètre de contrôle défectueux. Contactez le CRODIP."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.CONTROLE, sName, sTexte, positionTopAlertes)
        End If
    End Sub
    'Chargement des alertes
    Private Sub loadAccueilAlertsIdentifiantsPulvérisateurs(ByRef positionTopAlertes As Integer)
        CSDebug.dispInfo("loadAccueilAlertsIdentifiantPulve : Debut")

        'charegement de la liste des identifiants Inutilisés
        'Si le nbre est inférieure au nombre mini/4
        'Alerte noire
        'Si le nbre est inférieure au nombre mini/2
        'Alerte Rouge
        'Si le nbre est inférieure au nombre mini
        'Alerte Orange
        Dim AlerteIdent As GlobalsCRODIP.ALERTE
        Dim olst As List(Of IdentifiantPulverisateur) = IdentifiantPulverisateurManager.getListeInutilise(agentCourant.idStructure)
        If olst.Count < My.Settings.NbIdentifiantPulveMini Then
            If olst.Count < (My.Settings.NbIdentifiantPulveMini / 4) Then
                AlerteIdent = GlobalsCRODIP.ALERTE.NOIRE
            Else
                If olst.Count < (My.Settings.NbIdentifiantPulveMini / 2) Then
                    AlerteIdent = GlobalsCRODIP.ALERTE.ROUGE
                Else
                    AlerteIdent = GlobalsCRODIP.ALERTE.JAUNE
                End If
            End If
            Dim stext As String = ""
            If olst.Count > 1 Then
                stext = "Attention, il ne vous reste plus que " & olst.Count & " identifiants pulvérisateurs disponibles, contactez le CRODIP."
            End If
            If olst.Count = 1 Then
                stext = "Attention, il ne vous reste plus qu'UN SEUL identifiant pulvérisateur disponible, contactez le CRODIP."
            End If
            If olst.Count = 0 Then
                stext = "Attention, il ne vous reste plus AUCUN identifiant pulvérisateur disponible, contactez le CRODIP."
            End If
            AjouteUneAlerte(AlerteIdent, "Identifiant Pulvérisateur", stext, positionTopAlertes)
        End If

    End Sub
    ''' <summary>
    ''' Verification de la date de synhcro de l'agent courant
    ''' alerte ORANGE si plus de 10 jours sans connexion
    ''' </summary>
    ''' <param name="positionTopAlertes"></param>
    Private Sub loadAccueilAlertsSynchro(ByRef positionTopAlertes As Integer)
        CSDebug.dispInfo("loadAccueilAlertsSynchro : Debut")

        ' Vérification de la date de dernière synchro
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_SYNCHRO_LOAD, True)
        Dim tmpDateLastSynchro As Date
        Try
            tmpDateLastSynchro = CSDate.FromCrodipString(agentCourant.dateDerniereSynchro)
        Catch ex As Exception
            tmpDateLastSynchro = CSDate.FromCrodipString(agentCourant.dateDerniereSynchro)
        End Try
        Dim tmpCompareResponse As Integer = tmpDateLastSynchro.CompareTo(DateAdd(DateInterval.DayOfYear, -10, Now))
        If tmpCompareResponse < 1 Then
            Dim sText As String
            sText = "Vous devez connecter le logiciel à Internet pour effectuer une synchronisation des données."
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, "alerte synhcro", sText, positionTopAlertes)

        End If

    End Sub
    Private Sub AjouteUneAlerte(ByVal TypeAlerte As GlobalsCRODIP.ALERTE, ByVal pName As String, ByVal ptext As String, ByRef positionTopAlertes As Integer)
        Dim tmpAlerte As New Label
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(accueil))
        tmpAlerte.Name = pName
        tmpAlerte.Text = "       " & ptext
        accueil_panelAlertes.Controls.Add(tmpAlerte)
        Controls.Add(tmpAlerte)
        ' Position
        tmpAlerte.Parent = accueil_panelAlertes
        tmpAlerte.Left = 16
        tmpAlerte.Top = positionTopAlertes
        tmpAlerte.TextAlign = ContentAlignment.TopLeft
        tmpAlerte.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        ' Taille
        tmpAlerte.Width = 960
        tmpAlerte.Height = 16
        ' Couleur
        Select Case TypeAlerte
            Case GlobalsCRODIP.ALERTE.ORANGE
                tmpAlerte.ForeColor = System.Drawing.Color.FromArgb(CType(242, Byte), CType(84, Byte), CType(23, Byte)) '=> Orange
                tmpAlerte.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
                positionTopAlertes = positionTopAlertes + 24
            Case GlobalsCRODIP.ALERTE.ROUGE
                tmpAlerte.ForeColor = System.Drawing.Color.FromArgb(CType(242, Byte), CType(84, Byte), CType(23, Byte)) '=> Orange
                tmpAlerte.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
                positionTopAlertes = positionTopAlertes + 24
            Case GlobalsCRODIP.ALERTE.NOIRE
                tmpAlerte.ForeColor = System.Drawing.Color.FromArgb(CType(203, Byte), CType(19, Byte), CType(31, Byte)) ' => Rouge
                tmpAlerte.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
                positionTopAlertes = positionTopAlertes + 24
            Case GlobalsCRODIP.ALERTE.CONTROLE
                tmpAlerte.ForeColor = System.Drawing.Color.FromArgb(CType(203, Byte), CType(19, Byte), CType(31, Byte)) ' => Rouge
                tmpAlerte.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
                positionTopAlertes = positionTopAlertes + 24
        End Select
        ' Apparence texte
        Dim tmpFontLabelCategorie As New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        tmpAlerte.Font = tmpFontLabelCategorie

    End Sub


    Private Sub loadAccueilAlertsBuseEtalon(ByRef positionTopAlertes As Integer)
        CSDebug.dispInfo("loadAccueilAlertsBuseEtalon : Debut")
        ' Vérification des alertes sur les buses étalons
        Dim nbAlertes_Buse_alerte As Integer = 0
        Dim nbAlertes_Buse_out As Integer = 0
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(accueil))
        Dim alerte As GlobalsCRODIP.ALERTE = GlobalsCRODIP.ALERTE.NONE

        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_BUSESETALON_LOAD, True)
        Dim arrBusesEtalon As List(Of Buse) = BuseManager.getBusesEtalonByStructureId(agentCourant.idStructure, True)
        For Each tmpBuseEtalon As Buse In arrBusesEtalon
            If Not String.IsNullOrEmpty(tmpBuseEtalon.dateAchat) Then
                alerte = tmpBuseEtalon.getAlerte()
                If alerte = GlobalsCRODIP.ALERTE.NOIRE Then ' Plus valable
                    nbAlertes_Buse_out = nbAlertes_Buse_out + 1
                    ' On bloque la buse
                    If tmpBuseEtalon.etat = True Then
                        If My.Settings.DesacMat Then
                            tmpBuseEtalon.Desactiver()
                        End If
                    End If
                ElseIf alerte = GlobalsCRODIP.ALERTE.ROUGE Then ' Alerte
                    nbAlertes_Buse_alerte = nbAlertes_Buse_alerte + 1
                End If
            End If
        Next
        If nbAlertes_Buse_alerte > 0 Then
            '            Dim tmpAlerte As New Label
            Dim stext As String
            If nbAlertes_Buse_alerte > 1 Then
                stext = "Il faut commander de nouvelles buses étalons car " & nbAlertes_Buse_alerte & " ne seront plus reconnues dans 3 mois."
            Else
                stext = "Il faut commander de nouvelles buses étalons car " & nbAlertes_Buse_alerte & " ne sera plus reconnue dans 3 mois."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, "alerteBuseEtalon_alerte", stext, positionTopAlertes)
        End If
        If nbAlertes_Buse_out > 0 Then
            Dim sText As String
            If nbAlertes_Buse_out > 1 Then
                sText = "Il faut commander de nouvelles buses étalons car " & nbAlertes_Buse_out & " buses ne sont plus reconnues."
            Else
                sText = "Il faut commander de nouvelles buses étalons car " & nbAlertes_Buse_out & " buse n'est plus reconnue."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, "alerteBuseEtalon_out", sText, positionTopAlertes)
        End If

    End Sub

    ''' <summary>
    ''' Vérification du nbre de controle depuis le dernier controle Regulier
    ''' </summary>
    ''' <param name="positionTopAlertes"></param>
    ''' <remarks></remarks>
    Private Sub loadAccueilAlertsNbControle(ByRef positionTopAlertes As Integer)
        CSDebug.dispInfo("loadAccueilAlertsNbControle : Debut")

        Dim bAlerte As Boolean = False
        bAlerte = My.Settings.nbControlesAvantAlerte > My.Settings.nbControlesAvantAlerteMax
        'Affichage des alertes 
        Dim sName As String = ""
        Dim sTexte As String = ""
        If bAlerte Then
            sTexte = "Attention, vous avez effectué " & My.Settings.nbControlesAvantAlerte & " diagnostics sans effectuer de contrôles réguliers des instruments, veuillez vérifier vos instruments de mesures"
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, sName, sTexte, positionTopAlertes)
        End If


    End Sub

    Private Sub LoadAccueilAlertsBancsMesures(ByRef positionTopAlertes As Integer)
        CSDebug.dispInfo("loadAccueilAlertsBancsMesures : Debut")
        ' Vérification des alertes sur les banc de mesure
        Dim nbAlertes_Banc_Orange As Integer = 0
        Dim nbAlertes_Banc_1mois As Integer = 0
        Dim nbAlertes_Banc_1mois7jr As Integer = 0
        Dim nbAlertes_Banc_defaillant As Integer = 0
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(accueil))

        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_BANC_LOAD, True)
        Dim arrBanc As List(Of Banc) = BancManager.getBancByStructureId(agentCourant.idStructure, True)
        Dim njours As Integer
        Dim nbBancAvantDL(3000) As Integer 'Nombre de banc devant être controler njours avant la Date Limite
        Dim AlerteBanc As GlobalsCRODIP.ALERTE

        For Each tmpBanc As Banc In arrBanc
            AlerteBanc = tmpBanc.getAlerte()

            If AlerteBanc = GlobalsCRODIP.ALERTE.NOIRE Then ' 1mois7jrs
                nbAlertes_Banc_1mois7jr = nbAlertes_Banc_1mois7jr + 1
                If tmpBanc.etat = True Then
                    If My.Settings.DesacMat Then
                        tmpBanc.Desactiver(agentCourant)
                    End If
                End If
            End If

            If AlerteBanc = GlobalsCRODIP.ALERTE.ROUGE Then ' 1mois
                nbAlertes_Banc_1mois = nbAlertes_Banc_1mois + 1
            End If
            If AlerteBanc = GlobalsCRODIP.ALERTE.ORANGE Then '15 jours
                nbAlertes_Banc_Orange = nbAlertes_Banc_Orange + 1
                njours = tmpBanc.getNbJoursAvantAlerteRouge()
                If njours < nbBancAvantDL.Length Then
                    nbBancAvantDL(Math.Abs(njours)) = nbBancAvantDL(Math.Abs(njours)) + 1
                End If
            End If
            If AlerteBanc = GlobalsCRODIP.ALERTE.CONTROLE Then 'Etat defaillant
                nbAlertes_Banc_defaillant = nbAlertes_Banc_defaillant + 1
            End If
        Next
        'Affichage des alertes 
        Dim sName As String
        Dim sTexte As String
        If nbAlertes_Banc_Orange > 0 Then
            For n As Integer = nbBancAvantDL.Length To 1 Step -1
                sName = "alerteManoControle_" & n & "jr"
                If nbBancAvantDL(n - 1) > 0 Then
                    'Si on a des Manos à controler avant n jours
                    If nbBancAvantDL(n - 1) > 1 Then
                        sTexte = "Attention, vous avez " & nbBancAvantDL(n - 1) & " bancs de mesure devant être vérifiés dans " & n - 1 & " jours !"
                    Else
                        sTexte = "Attention, vous avez 1 banc de mesure devant être vérifié dans " & n - 1 & " jours !"
                    End If
                    AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, sName, sTexte, positionTopAlertes)
                End If
            Next n
        End If

        If nbAlertes_Banc_1mois > 0 Then
            sName = "alerteManoControle_1mois"
            If nbAlertes_Banc_1mois > 1 Then
                sTexte = "Attention, vous venez de dépasser la date autorisée pour " & nbAlertes_Banc_1mois & " bancs de mesure. Veuillez effectuer vos contrôles immédiatement !"
            Else
                sTexte = "Attention, vous venez de dépasser la date autorisée pour 1 banc de mesure. Veuillez effectuer votre contrôle immédiatement !"
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ROUGE, sName, sTexte, positionTopAlertes)
        End If

        If nbAlertes_Banc_1mois7jr > 0 Then
            sName = "alerteManoControle_1mois7jr"
            If nbAlertes_Banc_1mois7jr > 1 Then
                sTexte = "Vous avez trop attendu pour vérifier " & nbAlertes_Banc_1mois7jr & " bancs de mesure. A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
            Else
                sTexte = "Vous avez trop attendu pour vérifier 1 banc de mesure. A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, sName, sTexte, positionTopAlertes)
        End If

        If nbAlertes_Banc_defaillant > 0 Then
            sName = "alerteManoControle_defaillant"
            If nbAlertes_Banc_defaillant > 1 Then
                sTexte = "Vous avez " & nbAlertes_Banc_defaillant & " bancs de mesure défectueux. Contactez le CRODIP."
            Else
                sTexte = "Vous avez 1 banc de mesure défectueux. Contactez le CRODIP."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.CONTROLE, sName, sTexte, positionTopAlertes)
        End If

    End Sub

    ' Chargement des alertes de la page d'accueil
    Public Sub loadAccueilAlerts()

        If Not GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(accueil))
            Dim positionTopAlertes As Integer = 8
            accueil_panelAlertes.Controls.Clear()

            ' Vérification des alertes sur les manomètre étalon
            'Dim isVerifManoEtalon As Boolean = False
            'If isVerifManoEtalon Then
            '    loadAccueilAlertsManoEtalon(positionTopAlertes)
            'End If
            CSDebug.dispInfo("LoadAccueilAlerts : Debut")
            loadAccueilAlertsManoControle(positionTopAlertes)
            loadAccueilAlertsBuseEtalon(positionTopAlertes)
            LoadAccueilAlertsBancsMesures(positionTopAlertes)
            If Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
                loadAccueilAlertsIdentifiantsPulvérisateurs(positionTopAlertes)
                loadAccueilAlertsSynchro(positionTopAlertes)
            End If

            'Vérification du nombre de controles effectuées depuis le dernier controle Regulier
            loadAccueilAlertsNbControle(positionTopAlertes)
            CSDebug.dispInfo("LoadAccueilAlerts : Fin")

            ' Si aucune alerte à afficher, alors on affiche un message
            If positionTopAlertes = 8 Then
                Dim tmpAlerte As New Label
                tmpAlerte.Name = "noAlerte"
                tmpAlerte.Text = "       Aucune alerte à afficher."
                Controls.Add(tmpAlerte)
                ' Position
                tmpAlerte.Parent = accueil_panelAlertes
                tmpAlerte.Left = 16
                tmpAlerte.Top = positionTopAlertes
                tmpAlerte.TextAlign = ContentAlignment.TopLeft
                ' Taille
                tmpAlerte.Width = 960
                tmpAlerte.Height = 16
                ' Couleur
                tmpAlerte.ForeColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(135, Byte), CType(15, Byte))
                tmpAlerte.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
                tmpAlerte.ImageAlign = System.Drawing.ContentAlignment.TopLeft
                ' Apparence texte
                Dim tmpFontLabelCategorie As New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                tmpAlerte.Font = tmpFontLabelCategorie
            End If

            ' Loader OFF
            Statusbar.display(" ", True)
            Statusbar.hideLoader()
        End If
    End Sub

    ' Chargement de l'historique des synchro
    'Public Sub loadListSynchro()
    '    Dim oCSDB As New CSDb(True)

    '    Dim bddCommande As OleDb.OleDbCommand
    '    bddCommande = oCSDB.getConnection.CreateCommand()
    '    ' On test si la connexion est déjà ouverte ou non
    '    bddCommande.CommandText = "SELECT * FROM `Synchronisation` WHERE `idAgent`=" & agentCourant.idStructure & " ORDER By id desc"
    '    Try
    '        ' On récupère les résultats
    '        Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
    '        Dim i As Integer = 0
    '        ' Puis on les parcours
    '        While tmpListProfils.Read()

    '            ' On récupère nos logs de synchro
    '            Dim tmpSens As String = ""
    '            Dim tmpDate As String = ""
    '            Dim tmpLog As String = ""
    '            Dim tmpColId As Integer = 0
    '            While tmpColId < tmpListProfils.FieldCount()
    '                Select Case tmpListProfils.GetName(tmpColId)
    '                    Case "sensSynchronisation"
    '                        tmpSens = tmpListProfils.Item(tmpColId).ToString()
    '                    Case "dateSynchronisation"
    '                        tmpDate = CSDate.mysql2access(tmpListProfils.Item(tmpColId).ToString())
    '                    Case "logSynchronisation"
    '                        tmpLog = tmpListProfils.Item(tmpColId).ToString()
    '                End Select
    '                tmpColId = tmpColId + 1
    '            End While

    '            ' On alimente la liste
    '            list_dernieresSynchro.Items.Add("")
    '            If tmpSens = "asc" Then
    '                list_dernieresSynchro.Items(CInt(i)).StateImageIndex = 1
    '            Else
    '                list_dernieresSynchro.Items(CInt(i)).StateImageIndex = 0
    '            End If
    '            list_dernieresSynchro.Items(CInt(i)).SubItems.Add(tmpDate)
    '            list_dernieresSynchro.Items(CInt(i)).SubItems.Add(tmpLog)

    '            i = i + 1
    '        End While
    '    Catch ex As Exception ' On intercepte l'erreur
    '        CSDebug.dispFatal("SynchronisationManager : " & ex.Message)
    '    End Try
    '    ' Test pour fermeture de connection BDD
    '    If oCSDB IsNot Nothing Then
    '        oCSDB.free()
    '    End If

    'End Sub

    ' Chargement de l'historique des synchro
    Public Sub afficheSynchroCourante(pMsg As String)
        lbSynhcroCourante.Items.Add(pMsg)
        lbSynhcroCourante.Refresh()
        lbSynhcroCourante.TopIndex = lbSynhcroCourante.Items.Count - 1
    End Sub
#End Region

#Region " Accueil "

#Region " - Btn Refresh - "

    Private Sub picsRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picsRefresh.Click, btn_refresh_lst_clients.Click
        loadAccueilAlerts()
        LoadListControleRegulier()
    End Sub
    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        loadAccueilAlerts()
        LoadListControleRegulier()
    End Sub

#End Region

#End Region

#Region " Clients "

    '######################################################
    '################### Liste des clients ################
    '######################################################
    Private Sub refresh_lst_clients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_refresh_lst_clients.Click
        client_search_query.Text = ""
        list_search_fieldSearch.SelectedIndex = 0
        LoadListeExploitation()
        'list_clients.ListViewItemSorter = New CSListViewItemComparer(7, System.Windows.Forms.SortOrder.Descending, "Date")
    End Sub

    ' Trier les clients
    Private Sub list_clients_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles list_clients.ColumnClick

        Static OrdreDeTri As System.Windows.Forms.SortOrder
        OrdreDeTri = 1 - OrdreDeTri
        If e.Column <> 7 Then
            sender.ListViewItemSorter = New CSListViewItemComparer(e.Column, OrdreDeTri)
        Else
            sender.ListViewItemSorter = New CSListViewItemComparer(e.Column, OrdreDeTri, "Date")
        End If


    End Sub

    ' Sélection client dans la liste
    Private Sub list_clients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list_clients.SelectedIndexChanged
        'MsgBox(list_clients.SelectedItems().Count)
    End Sub

    ' Liste des pulvérisateurs d'un client
    Private Sub btn_proprietaire_pulveListe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_pulveListe.Click
        loadListPulveExploitation(False)
    End Sub
    Private Sub list_clients_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles list_clients.DoubleClick
        loadListPulveExploitation(False)
    End Sub

    Private Sub btn_proprietaire_derniersControles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_derniersControles.Click
        m_Exploitation_isShowAll = Not m_Exploitation_isShowAll
        btn_proprietaire_derniersControles_setLabel()
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_LISTCLIENT_ENCOURS)
        LoadListeExploitation()
        Statusbar.display(list_clients.Items.Count & "" & GlobalsCRODIP.CONST_STATUTMSG_LISTCLIENT_OK)
    End Sub
    Private Sub btn_proprietaire_derniersControles_setLabel()
        'Attention : le libellé est inversé !!!
        If m_Exploitation_isShowAll = True Then
            btn_proprietaire_derniersControles.Text = "       Voir les prochains contrôles"
        Else
            btn_proprietaire_derniersControles.Text = "       Voir tous les contrôles"
        End If

    End Sub


    ' Voir la fiche d'un client
    Private Sub btn_proprietaire_voirFiche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_voirFiche.Click
        ' On récupère le formulaire contener

        ' On récupère le client sélectionné
        Dim clientSelected_NumSIREN As String = "0"
        Try
            clientSelected_NumSIREN = list_clients.SelectedItems.Item(0).Text
        Catch ex As Exception
            clientSelected_NumSIREN = "0"
        End Try
        ' On vérifie qu'il y a bien une ligne de sélectionnée
        If list_clients.SelectedItems().Count > 0 And clientSelected_NumSIREN <> "0" Then
            voirFicheExploitant()
        End If
    End Sub

    ' Ajouter un client
    Private Sub btn_proprietaire_ajouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_ajouter.Click
        ' Ouverture fiche client
        clientCourant = New Exploitation()
        Dim formFiche_exploitant As New fiche_exploitant()
        formFiche_exploitant.setContexte(False, clientCourant, agentCourant)
        '        formFiche_exploitant.MdiParent = Me.MdiParent
        formFiche_exploitant.ShowDialog()
    End Sub

    ' Suppression client
    Private Sub btn_proprietaire_supprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_supprimer.Click
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETECLIENT_ENCOURS)

        ' On récupère le client sélectionné
        Dim clientSelected_NumSIREN As String = "0"
        Try
            clientSelected_NumSIREN = list_clients.SelectedItems.Item(0).Text
        Catch ex As Exception
            clientSelected_NumSIREN = "0"
        End Try

        ' On vérifie qu'il y a bien une ligne de sélectionnée
        If list_clients.SelectedItems().Count > 0 And clientSelected_NumSIREN <> "0" Then
            ' On informe l'utilisateur et on lui demande confirmation
            If MsgBox("Attention, vous allez supprimer un exploitant, toute suppression est définitive. Etes-vous sûr ?", MsgBoxStyle.YesNo, "Suppression d'un exploitant") = MsgBoxResult.Yes Then
                ' On récupère l'object client
                clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)
                ' Si tout est ok, on le supprime
                If ExploitationManager.SupprimerExploitation(clientCourant) Then
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETECLIENT_OK)
                    CSTime.pause(1000)
                    LoadListeExploitation()
                Else
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETECLIENT_FAILED)
                End If
            Else
                Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETECLIENT_CANCEL)
            End If
        Else
            Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETECLIENT_NOSELECTED)
        End If
    End Sub

    Private Sub list_search_fieldSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list_search_fieldSearch.SelectedIndexChanged
        If Not list_search_fieldSearch.SelectedItem Is Nothing Then
            If list_search_fieldSearch.SelectedItem.Id = 5 Then
                pnl_SearchDates.Visible = True
                client_search_query.Visible = False
            Else
                pnl_SearchDates.Visible = False
                client_search_query.Visible = True
            End If


        End If
    End Sub
    Private Sub client_search_query_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If client_search_query.Text.Length = 0 Then
        '    btn_proprietaire_rechercher.Enabled = False
        'Else
        'End If
        'searchExploitant()
    End Sub
    Private Sub btn_proprietaire_rechercher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_rechercher.Click
        searchExploitant()
    End Sub
    Private Sub searchExploitant()
        Dim searchId As Integer
        Dim searchCriteria As String
        Dim ocol As New List(Of Exploitation)

        If list_search_fieldSearch.SelectedItem IsNot Nothing Then
            searchId = list_search_fieldSearch.SelectedItem.id
            searchCriteria = client_search_query.Text
            If searchId = 5 Then
                searchCriteria = dtpSearchCrit1.Value.ToString("d") & "|" & dtpSearchCrit2.Value.ToString("d")
            End If
            If agentCourant.isGestionnaire Then
                Dim oDiag As Diagnostic
                oDiag = DiagnosticManager.getWSDiagnosticById(agentCourant.id, searchCriteria)
                If Not oDiag Is Nothing Then
                    diagnosticCourant = oDiag
                    Dim oExploit As Exploitation
                    oExploit = ExploitationManager.getWSClientByDiagnosticId(agentCourant, searchCriteria)
                    ocol = New List(Of Exploitation)
                    ocol.Add(oExploit)
                End If
            Else
                ocol = ExploitationManager.searchExploitation(agentCourant, searchId, searchCriteria)
            End If
        End If

        AfficheListeExploitation(False, ocol)
    End Sub

    ' Exporter la liste des clients en CSV
    Private Sub btn_proprietaire_exportCsv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_exportCsv.Click
        ExportToCSV()
    End Sub
    Private Sub ExportToCSV()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim SFile As String = GlobalsCRODIP.CONST_PATH_EXP & "Export_clients_" & Date.Now.ToString("yyyyMMdd") & ".csv"
            Dim searchId As Integer
            Dim searchCriteria As String
            Dim ocol As List(Of Exploitation)

            If list_search_fieldSearch.SelectedItem IsNot Nothing Then
                searchId = list_search_fieldSearch.SelectedItem.id
                searchCriteria = client_search_query.Text
                If searchId = 5 Then
                    searchCriteria = dtpSearchCrit1.Value.ToString("d") & "|" & dtpSearchCrit2.Value.ToString("d")
                End If
                ocol = ExploitationManager.searchExploitation(agentCourant, searchId, searchCriteria)
            Else
                ocol = ExploitationManager.getListeExploitation(agentCourant, DateTime.Now)
            End If

            Dim bEntete As Boolean = True
            For Each oExploit As Exploitation In ocol
                oExploit.ExportCSV(SFile, bEntete)
                bEntete = False
            Next

            If MsgBox("Fichier correctement enregistré dans : " & vbNewLine & SFile & vbNewLine & "Voulez-vous ouvrir ce fichier ?", MsgBoxStyle.YesNo, "Export CSV") = MsgBoxResult.Yes Then
                CSFile.open(SFile)
            End If
        Catch ex As Exception
            MsgBox("Une erreur est survenue pendant l'export CSV." & vbNewLine & "Peut-être avez-vous déjà ouvert le fichier ?")
            CSDebug.dispError("ExportToCSV ERR : " & ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub ExportToCSVPulve()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim SFile As String = GlobalsCRODIP.CONST_PATH_EXP & "Export_pulve_" & Date.Now.ToString("yyyyMMdd") & ".csv"
            PulverisateurManager.exportToCSV(SFile)

            If MsgBox("Fichier correctement enregistré dans : " & vbNewLine & SFile & vbNewLine & "Voulez-vous ouvrir ce fichier ?", MsgBoxStyle.YesNo, "Export CSV") = MsgBoxResult.Yes Then
                CSFile.open(SFile)
            End If
        Catch ex As Exception
            MsgBox("Une erreur est survenue pendant l'export CSV." & vbNewLine & "Peut-être avez-vous déjà ouvert le fichier ?")
            CSDebug.dispError("ExportToCSVPulve ERR : " & ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    '######################################################
    '################## Fiche d'un client #################
    '######################################################
    ' Edition fiche client
    Private Sub btn_ficheClient_voirFiche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheClient_voirFiche.Click
        ' Ouverture fiche client
        Dim formFiche_exploitant As New fiche_exploitant
        formFiche_exploitant.setContexte(False, clientCourant, agentCourant)
        formFiche_exploitant.ShowDialog()
    End Sub


    ' Edition d'une fiche pulvé à partir de la liste des pulvé
    Private Sub VoirFichePulve()

        ' On vérifie qu'il y a bien une ligne de sélectionnée
        If dgvPulveExploit.SelectedRows.Count > 0 Then
            Try
                Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
                pulverisateurCourant = m_BindingListOfPulve(oRowIndex)

                ' Mise à jour de la barre de status
                Statusbar.display("Chargement du pulvérisateur n°" & pulverisateurCourant.id)

                ' Affichage de la fiche du pulvérisateur
                Dim formEdition_fiche_pulve As New ajout_pulve2()
                formEdition_fiche_pulve.setContexte(ajout_pulve2.MODE.MODIF, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
                'formEdition_fiche_pulve.MdiParent = Me.MdiParent
                formEdition_fiche_pulve.ShowDialog()
                'Rafraichissement de la liste
                '                affichePulvedansListeExploitation(pulverisateurCourant)

                ' Mise à jour de la barre de status
                Statusbar.display("Pulvérisateur n°" & pulverisateurCourant.id)
            Catch ex As Exception
                CSDebug.dispError("Accueil.VoirFichePulve : " & ex.Message.ToString)
            End Try
        End If
    End Sub
    Public Sub voirFicheExploitant()
        ' Mise à jour de la barre de status
        Statusbar.display("Chargement du client n°" & list_clients.SelectedItems().Item(0).Tag)

        ' On récupère l'objet du client
        clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)
        ' Ouverture fiche client
        Dim formFiche_exploitant As New fiche_exploitant
        formFiche_exploitant.setContexte(False, clientCourant, agentCourant)
        formFiche_exploitant.ShowDialog()
    End Sub

    ' Ajout d'une fiche pulvé
    Private Sub btn_ficheClient_pulve_ajouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AjouterUnPulve()
    End Sub
    Private Sub AjouterUnPulve()
        Dim formAddPulve As New ajout_pulve2()
        ' On récupère l'objet du client
        If (list_clients.SelectedItems().Count > 0) Then

            clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)
            pulverisateurCourant = New Pulverisateur()
            formAddPulve.setContexte(ajout_pulve2.MODE.AJOUT, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
            '        formAddPulve.MdiParent = Me.MdiParent
            formAddPulve.ShowDialog()
        End If
    End Sub

    ' Création d'un nouveau diagnostic
    Private Sub btn_ficheClient_diagnostic_nouveau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheClient_diagnostic_nouveau.Click
        btn_ficheClient_diagnostic_nouveau.Enabled = False
        NouveauDiagnostic(GlobalsCRODIP.DiagMode.CTRL_COMPLET)
        btn_ficheClient_diagnostic_nouveau.Enabled = Not agentCourant.isGestionnaire
    End Sub

    Private Sub NouveauDiagnostic(pDiagMode As GlobalsCRODIP.DiagMode)

        ' On récupère le formulaire contener
        ' Dim myFormParentContener As Form = Me.MdiParent

        ' On vérifie qu'il y a bien une ligne de sélectionnée
        'If list_ficheClient_puverisateur.SelectedItems().Count > 0 Then
        If dgvPulveExploit.SelectedRows.Count() > 0 Then
            Try
                Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
                pulverisateurCourant = m_BindingListOfPulve(oRowIndex)
                ' On récupère le pulvé selectionné
                '                pulverisateurCourant = PulverisateurManager.getPulverisateurById(list_ficheClient_puverisateur.SelectedItems().Item(0).Tag)
                ' Mise à jour de la barre de status
                If pDiagMode = GlobalsCRODIP.DiagMode.CTRL_CV Then
                    Statusbar.display("Nouvelle contre-visite")
                Else
                    Statusbar.display("Nouveau Controle")
                End If

                'Vérification du ficher de Param
                'Lecture du paramétrage associé au pulvérisateur
                If Not pulverisateurCourant.CheckParam() Then
                    Exit Sub
                End If
                ' Création d'une nouveau diagnostic
                diagnosticCourant = New Diagnostic(agentCourant, pulverisateurCourant, clientCourant)

                Dim bContinue As Boolean = True
                If pDiagMode = GlobalsCRODIP.DiagMode.CTRL_CV Then
                    ' Rechercge du diagnostique initial
                    Dim frmLstDiag As New liste_diagnosticPulve2()
                    frmLstDiag.setcontexte(GlobalsCRODIP.DiagMode.CTRL_CV, pulverisateurCourant, clientCourant, agentCourant)
                    frmLstDiag.ShowDialog()
                    bContinue = (frmLstDiag.DialogResult = Windows.Forms.DialogResult.OK)
                End If
                If bContinue Then
                    NouveauDiagnosticPhase1(pDiagMode)
                End If
            Catch ex As Exception
                Statusbar.clear()
                CSDebug.dispFatal("Accueil.nouveauDiagnostique ERR : " & ex.Message)
            End Try
        End If


    End Sub

    Public Sub NouveauDiagnosticPhase1(pDiagMode As GlobalsCRODIP.DiagMode)
        'Vérification des clients et Pulvés au préalable
        Dim ofrmExpl As New fiche_exploitant()
        ofrmExpl.setContexte(False, clientCourant, agentCourant)
        '                ofrm.MdiParent = Me.MdiParent
        ofrmExpl.ShowDialog()
        If ofrmExpl.DialogResult = Windows.Forms.DialogResult.OK Then
            'Affectation de exploitation au Diagnostic
            If Not diagnosticCourant Is Nothing Then
                diagnosticCourant.SetProprietaire(clientCourant)
                diagnosticCourant.proprietaireRepresentant = ofrmExpl.tbNomPrenomRepresentant.Text
            End If
            'End If
            'Vérification du Pulvérisateur
            'Si c'est un pulvé Additionnel => Affichage du pulvé principal puis du pulvé Additionnel
            Dim ofrmEditPulve As ajout_pulve2
            ofrmEditPulve = New ajout_pulve2()
            'If pulverisateurCourant.isPulveAdditionnel Then
            '    Dim oPulvePrincipal As Pulverisateur
            '    Dim oPulveAdditionnel As Pulverisateur
            '    oPulveAdditionnel = pulverisateurCourant
            '    oPulvePrincipal = PulverisateurManager.getPulverisateurByNumNat(pulverisateurCourant.pulvePrincipalNumNat)
            '    If oPulvePrincipal.id <> "" Then
            '        ofrmEditPulve.setContexte(ajout_pulve2.MODE.CONSULT, agentCourant, oPulvePrincipal, diagnosticCourant)
            '        ofrmEditPulve.ShowDialog()
            '    End If
            '    pulverisateurCourant = oPulveAdditionnel
            'End If
            ofrmEditPulve.setContexte(ajout_pulve2.MODE.VERIF, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
            ofrmEditPulve.ShowDialog()
            If ofrmEditPulve.DialogResult = Windows.Forms.DialogResult.OK Then
                diagnosticCourant.setPulverisateur(pulverisateurCourant)
                NouveauDiagnosticPhase2(pDiagMode, diagnosticCourant)
            End If
        End If

    End Sub
    ''' <summary>
    ''' Réalisation d"un nouveau controle Pahse 2
    '''  Affichage du contexte
    '''  Si on ne fait pas une contrevisite gratuite 
    '''        Affichage de la page de facturation
    ''' Affichage de la page de Preliminaires
    ''' </summary>
    ''' <param name="bisContreVisite"></param>
    ''' <remarks></remarks>
    Public Sub NouveauDiagnosticPhase2(pDiagMode As GlobalsCRODIP.DiagMode, pDiag As Diagnostic)
        Statusbar.clear()
        diagnosticCourant = pDiag ''Par Sécurité
        Dim bOK As Boolean = True
        If Not GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            Me.Cursor = Cursors.WaitCursor
            Dim formDiagnostic_Contexte As New diagnostic_contexte(pDiagMode, pDiag, pulverisateurCourant, clientCourant, False)
            formDiagnostic_Contexte.ShowDialog()
            Me.Cursor = Cursors.Default
            bOK = (formDiagnostic_Contexte.DialogResult = Windows.Forms.DialogResult.OK)
            If bOK Then
                formDiagnostic_Contexte.Close()
                Dim isContreVisiteGratuite As Boolean
                isContreVisiteGratuite = System.IO.File.Exists("ContreVisiteGratuite")
                If (diagnosticCourant.isContrevisiteImmediate And isContreVisiteGratuite) Or GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
                    'Mise à jour du tarif du Diagnostique
                    diagnosticCourant.isGratuit = True
                    diagnosticCourant.controleTarif = 0
                    diagnosticCourant.TotalHT = 0
                    diagnosticCourant.TotalTVA = 0
                    diagnosticCourant.TotalTTC = 0
                Else
                    'Nous ne sommes pas une contrevisite immédiate ou cette CV n'est pas gratuite
                    Statusbar.clear()
                    Me.Cursor = Cursors.WaitCursor
                    Dim frmFact As diagnostic_ContratCommercial = New diagnostic_ContratCommercial()
                    frmFact.setContexte(pDiag, clientCourant, agentCourant)
                    frmFact.ShowDialog()
                    Me.Cursor = Cursors.Default
                    bOK = (frmFact.DialogResult = Windows.Forms.DialogResult.OK)
                End If
                Statusbar.clear()
            End If
        End If
        If bOK Then
            Dim frmDiagPreliminaires As New controle_preliminaire(pDiagMode, pDiag, pulverisateurCourant, clientCourant)
            globFormControlePreliminaire = frmDiagPreliminaires
            Me.Cursor = Cursors.WaitCursor
            TryCast(Me.MdiParent, parentContener).DisplayForm(frmDiagPreliminaires)
            Me.Cursor = Cursors.Default
        End If


    End Sub

    Private Sub VoirDiagnostique()
        If diagnosticCourant IsNot Nothing Then
            Dim frmDiagPreliminaires As New controle_preliminaire(GlobalsCRODIP.DiagMode.CTRL_VISU, diagnosticCourant, pulverisateurCourant, clientCourant)
            globFormControlePreliminaire = frmDiagPreliminaires
            TryCast(Me.MdiParent, parentContener).DisplayForm(frmDiagPreliminaires)
        End If

    End Sub
    Private Sub SignerDiagnostique()
        If diagnosticCourant IsNot Nothing Then
            Dim frmDiagRecap As New frmdiagnostic_recap(GlobalsCRODIP.DiagMode.CTRL_SIGNATURE, diagnosticCourant, pulverisateurCourant, clientCourant, agentCourant, Nothing)
            TryCast(Me.MdiParent, parentContener).DisplayForm(frmDiagRecap)
        End If

    End Sub
    Private Sub VisuPDFSDiagnostique()
        If diagnosticCourant IsNot Nothing Then
            Dim frmDiagRecap As New frmdiagnostic_recap(GlobalsCRODIP.DiagMode.CTRL_VISUPDFS, diagnosticCourant, pulverisateurCourant, clientCourant, agentCourant, Nothing)
            TryCast(Me.MdiParent, parentContener).DisplayForm(frmDiagRecap)
        End If

    End Sub
    ' Faire une contre visite
    Private Sub btn_ficheClient_diagnostic_nouvelleCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheClient_diagnostic_nouvelleCV.Click

        btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
        NouveauDiagnostic(GlobalsCRODIP.DiagMode.CTRL_CV)
        btn_ficheClient_diagnostic_nouvelleCV.Enabled = Not agentCourant.isGestionnaire

    End Sub
    ' Voir un diagnostic
    Private Sub btn_ficheClient_diagnostic_voir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheClient_diagnostic_voir.Click
        ' On récupère le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent

        ' On vérifie qu'il y a bien une ligne de sélectionnée
        If dgvPulveExploit.SelectedRows.Count > 0 Then
            ' Mise à jour de la barre de status
            Try
                Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
                pulverisateurCourant = m_BindingListOfPulve(oRowIndex)
                Statusbar.display("Visualisation d’un contrôle pour le pulvérisateur " & pulverisateurCourant.id)

                Dim formListDiagnostique As New liste_diagnosticPulve2()
                formListDiagnostique.setcontexte(GlobalsCRODIP.DiagMode.CTRL_VISU, pulverisateurCourant, clientCourant, agentCourant)
                formListDiagnostique.StartPosition = FormStartPosition.CenterParent
                formListDiagnostique.ShowDialog(myFormParentContener)
                If (formListDiagnostique.DialogResult = Windows.Forms.DialogResult.OK) Then
                    diagnosticCourant = formListDiagnostique.getDiagnostic()
                    Select Case formListDiagnostique.DiagMode
                        Case GlobalsCRODIP.DiagMode.CTRL_VISUPDFS
                            VisuPDFSDiagnostique()
                        Case GlobalsCRODIP.DiagMode.CTRL_SIGNATURE
                            SignerDiagnostique()
                        Case GlobalsCRODIP.DiagMode.CTRL_VISU
                            VoirDiagnostique()
                        Case GlobalsCRODIP.DiagMode.CTRL_CV, GlobalsCRODIP.DiagMode.CTRL_COMPLET
                            diagnosticCourant = formListDiagnostique.getDiagnostic()
                            NouveauDiagnosticPhase1(formListDiagnostique.DiagMode)
                    End Select
                End If
            Catch ex As Exception
                Statusbar.clear()
                MsgBox("Erreur - Visualisation Diagnostic - getPulverisateurById" & ex.Message.ToString)
            End Try
        End If

        ' Ouverture form diagnostic
        'Dim formDiagnostique As New diagnostique
        'formDiagnostique.MdiParent = Me.MdiParent
        'formDiagnostique.Show()
        'Me.Hide()
    End Sub

    ' Affichage liste clients (Retour)
    Private Sub btn_ficheClient_retour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheClient_retour.Click
        ' On récupère le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent

        ' Mise à jour de la barre de status
        Statusbar.display("Liste des clients")

        ' Affichage de la liste des clients
        panel_clientele_LstCtrlCtriteres.Visible = True
        panel_ListeDesControles.Visible = True
        panel_ListeDesControles.Dock = DockStyle.Fill
        panel_clientele_ficheClient.Visible = False
    End Sub

    ' Filtre les pulvés qui ont des alertes
    'Dim pulverisateurs_isShowAll As Boolean = True
    'Private Sub btn_ficheClient_pulve_voirProchainsControles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If pulverisateurs_isShowAll = True Then
    '        pulverisateurs_isShowAll = False
    '        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_LISTPULVE_ENCOURS)
    '        btn_proprietaire_derniersControles.Text = "       Voir les prochains controles"
    '        loadListPulveExploitation(False)
    '        Statusbar.display(dgvPulveExploit.Rows.Count & "" & GlobalsCRODIP.CONST_STATUTMSG_LISTPULVE_OK)
    '    Else
    '        pulverisateurs_isShowAll = True
    '        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_LISTPULVE_ENCOURS)
    '        btn_proprietaire_derniersControles.Text = "       Voir tous les controles"
    '        loadListPulveExploitation(True)
    '        Statusbar.display(dgvPulveExploit.Rows.Count & "" & GlobalsCRODIP.CONST_STATUTMSG_LISTPULVE_OK)
    '    End If
    'End Sub

    ' Supprimer un pulvérisateur
    Private Sub btn_ficheClient_pulve_supprimer_Click2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        supprimerUnPulverisateur()
    End Sub
    Private Sub supprimerUnPulverisateur()
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETEPULVE_ENCOURS)
        ' On vérifie qu'il y a bien une ligne de sélectionnée
        If dgvPulveExploit.SelectedRows.Count > 0 Then
            ' On informe l'utilisateur et on lui demande confirmation
            If MsgBox("Attention, vous allez supprimer un pulvérisateur, toute suppression est définitive. Etes-vous sûr ?", MsgBoxStyle.YesNo, "Suppression d'un pulvérisateur") = MsgBoxResult.Yes Then
                ' On récupère l'object pulvé
                Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
                pulverisateurCourant = m_BindingListOfPulve(oRowIndex)
                ' Si tout est ok, on le supprime
                If PulverisateurManager.deletePulverisateur(pulverisateurCourant) Then
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETEPULVE_OK)
                    CSTime.pause(1000)
                    loadListPulveExploitation(False)
                Else
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETEPULVE_FAILED)
                End If
            Else
                Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETEPULVE_CANCEL)
            End If
        Else
            Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETEPULVE_NOSELECTED)
        End If
    End Sub

    ' Trier les pulvés
    Private Sub list_ficheClient_puverisateur_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        Static OrdreDeTri As System.Windows.Forms.SortOrder
        OrdreDeTri = 1 - OrdreDeTri
        If e.Column <> 8 Then
            sender.ListViewItemSorter = New CSListViewItemComparer(e.Column, OrdreDeTri)
        Else
            sender.ListViewItemSorter = New CSListViewItemComparer(e.Column, OrdreDeTri, "Date")
        End If
    End Sub

#End Region

#Region " Pulvérisateurs "

    ' Rafraichissement de la liste
    Private Sub listPulve_lbl_refreshList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listPulve_lbl_refreshList.Click
        listPulverisateurs.ListViewItemSorter = Nothing
        loadListPulve()
    End Sub

    ' Gère le tri au clic sur les colones
    Private Sub listPulverisateurs_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles listPulverisateurs.ColumnClick
        Static OrdreDeTri As System.Windows.Forms.SortOrder
        OrdreDeTri = 1 - OrdreDeTri
        If e.Column <> 8 Then
            sender.ListViewItemSorter = New CSListViewItemComparer(e.Column, OrdreDeTri)
        Else
            sender.ListViewItemSorter = New CSListViewItemComparer(e.Column, OrdreDeTri, "Date")
        End If
    End Sub

    ' Export CSV de la liste des pulvés
    Private Sub listPulve_btn_exportCsv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listPulve_btn_exportCsv.Click
        ExportToCSVPulve()
    End Sub

    ' Ouverture de la fiche d'un pulvé
    Private Sub btn_lstPulve_voirFiche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lstPulve_voirFiche.Click
        displayPulveEdit()
    End Sub
    Private Sub listPulverisateurs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listPulverisateurs.DoubleClick
        displayPulveEdit()
    End Sub
    Private Sub displayPulveEdit()
        ' On récupère le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent

        ' On vérifie qu'il y a bien une ligne de sélectionnée
        If listPulverisateurs.SelectedItems().Count > 0 Then
            Dim olvItem As ListViewItem
            olvItem = listPulverisateurs.SelectedItems().Item(0)
            ' On récupère le pulvé selectionné
            pulverisateurCourant = PulverisateurManager.getPulverisateurById(olvItem.Tag)

            ' Mise à jour de la barre de status
            Statusbar.display("Chargement du pulvérisateur n°" & olvItem.SubItems.Item(0).Text)

            ' Affichage de la fiche du pulvérisateur
            Dim formEdition_fiche_pulve As New ajout_pulve2()
            formEdition_fiche_pulve.setContexte(ajout_pulve2.MODE.MODIF, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
            '            formEdition_fiche_pulve.MdiParent = Me.MdiParent
            formEdition_fiche_pulve.ShowDialog(Me.MdiParent)
            If formEdition_fiche_pulve.DialogResult = Windows.Forms.DialogResult.OK Then
                PulverisateurManager.getExploitationPulverisateurByPulve(pulverisateurCourant)
                affichePulvedansListePulve(olvItem, pulverisateurCourant)
            End If

            ' Mise à jour de la barre de status
            Statusbar.display("Pulvérisateur n°" & listPulverisateurs.SelectedItems().Item(0).SubItems.Item(0).Text)
        End If
    End Sub

#End Region

#Region " Synchro "

    ' Synchro manuelle
    Private Sub btn_synchro_run_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_synchro_run.Click
        ExecSynchro()
    End Sub

    Private Sub ExecSynchro()
        If CSSoftwareUpdate.checkMAJ() Then
            MsgBox("Une Mise à jour est disponible, vous devez l'installer avant de vous synchroniser")
            Application.Exit()
        End If

        If CSEnvironnement.checkNetwork() = True Then
            GlobalsCRODIP.GLOB_NETWORKAVAILABLE = True
            If CSEnvironnement.checkWebService() = True Then
                ' On vérifie les mises à jour
                Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_SYNCHRO_ENCOURS, True)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    Dim oSynchro As New Synchronisation(agentCourant)
                    oSynchro.ajouteObservateur(TryCast(MdiParent, parentContener))
                    oSynchro.ajouteObservateur(Me)

                    Dim bSynchroAsc As Boolean = ckSynchroASC.Checked
                    Dim bSynchroDESC As Boolean = ckSynchroDESC.Checked
                    oSynchro.Synchro(bSynchroAsc, bSynchroDESC)
                    Me.Cursor = Cursors.Default

                Catch ex As Exception
                    CSDebug.dispError("Accueil.btnsynchri_run Erreur synchroUp : " & ex.Message.ToString)
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_SYNCHRO_FAILED, False)
                End Try
                Statusbar.hideLoader()

                'On recharge la liste
                'list_dernieresSynchro.Items.Clear()
                'loadListSynchro()
                MsgBox("Fin de la Synchronisation !", MsgBoxStyle.Information)
                Statusbar.display("", False)

                ' Close session si inactif ou si agentCourant.id = ""
                Dim bCloseSession As Boolean = False
                If agentCourant.numeroNational = "" Then
                    bCloseSession = True
                Else
                    'Rechargement de l'agent courant
                    agentCourant = AgentManager.getAgentById(agentCourant.id)
                    If agentCourant.numeroNational = "" Or Not agentCourant.isActif Or agentCourant.isSupprime Then
                        bCloseSession = True
                    End If
                End If

                If bCloseSession Then
                    agentCourant = Nothing
                    ' On ferme toutes les fenetres ouvertes
                    Dim form As Form
                    For Each form In globFormParent.MdiChildren
                        form.Close()
                    Next

                    ' On affiche l'écran de connexion
                    Dim loginMDIChild As New login
                    TryCast(Me.MdiParent, parentContener).DisplayForm(loginMDIChild)

                End If

            Else
                Statusbar.display("Synchronisation impossible, serveur Crodip momentanément indisponible.", False)
                MsgBox("Synchronisation impossible, serveur Crodip momentanément indisponible.", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Synchronisation impossible, vous devez être connecté à internet !", MsgBoxStyle.Exclamation)
        End If

        Statusbar.hideLoader()
    End Sub

#End Region

#Region " Outils complémentaires "

    ' Documents à imprimer
    ' Outils de calcul
    Private Sub btn_outilsComplementaires_calcVolumeHectare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_outilsComplementaires_calcVolumeHectare.Click
        Dim formCalcVolHa As New tool_calcVolHa
        TryCast(Me.MdiParent, parentContener).DisplayForm(formCalcVolHa)
    End Sub
    Private Sub btn_outilsComplementaires_calcDebitBuses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_outilsComplementaires_calcDebitBuses.Click
        Dim formDiagBuses As New tool_diagBuses
        TryCast(Me.MdiParent, parentContener).DisplayForm(formDiagBuses)
    End Sub
    Private Sub btn_outilsComplementaires_diagBlanc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

#End Region

#Region " Parametrage "

    '#########################################################
    '############# Parametrage de l'inspecteur ###############
    '#########################################################
    'Organisme
    Private Sub btn_parametrage_coordonneesOrganisme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_coordonneesOrganisme.Click
        Dim formGestion_structures As New gestion_structures
        TryCast(Me.MdiParent, parentContener).DisplayForm(formGestion_structures)

    End Sub
    'Inspecteur
    Private Sub btn_parametrage_coordonneesInspecteur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_coordonneesInspecteur.Click
        Dim formGestion_agent As New gestion_agent
        TryCast(Me.MdiParent, parentContener).DisplayForm(formGestion_agent)

    End Sub
    'Tarifs
    Private Sub btn_parametrage_tarifs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_tarifs.Click
        Dim formGestion_tarifs As New gestion_tarifs
        formGestion_tarifs.setContexte(agentCourant)
        TryCast(Me.MdiParent, parentContener).DisplayForm(formGestion_tarifs)
    End Sub

    Private Sub btn_parametrage_facturation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_facturation.Click
        Dim oFrm As New facturation
        TryCast(Me.MdiParent, parentContener).DisplayForm(oFrm)
    End Sub

    '#########################################################
    '###### Parametrage des appareils de l'inspecteur ########
    '#########################################################
    'Manometres
    Private Sub btn_parametrage_parametrageManometre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_parametrageManometre.Click
        Dim ofrm As New gestion_manometres
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
    End Sub
    'Buses
    Private Sub btn_parametrage_parametrageBuses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_parametrageBuses.Click
        Dim ofrm As New gestion_busesEtalons
        'globFormGestionBusesEtalons = formGestion_busesEtalons
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
    End Sub
    'Bancs
    Private Sub btn_parametrage_parametrageBancs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_parametrageBancs.Click
        Dim ofrm As New gestion_bancs
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
    End Sub

    '#########################################################
    '###### Vérification des appareils de l'inspecteur #######
    '#########################################################
    'Manometres
    Private Sub btn_parametrage_verificationManometres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_verificationManometres.Click
        Dim ofrm As New frmControleManometres2(agentCourant)
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
    End Sub
    'Bancs
    Private Sub btn_parametrage_verificationBancs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_verificationBancs.Click
        Dim ofrm As New frmcontrole_bancs
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
    End Sub

    Private Sub lblMaterielsSupprimes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMaterielsSupprimes.Click
        Dim oFrm As New materiels_supprimes

        TryCast(Me.MdiParent, parentContener).DisplayForm(oFrm)

    End Sub
    Private Sub lblIdentifiantPulve_Click(sender As Object, e As EventArgs) Handles lblIdentifiantPulve.Click
        Dim oFrm As New frmGestIdentifiantsPulve

        TryCast(Me.MdiParent, parentContener).DisplayForm(oFrm)

    End Sub

#End Region

#Region " Test "
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Enregistrement paramètres SMTP
        'globalConfig.createRoot("root")
        'globalConfig.addElement("/root", "smtp", 0)
        'globalConfig.addElement("/root/smtp", "smtpHost", "smtp.sparr0w.net")
        'globalConfig.addElement("/root/smtp", "smtpPort", "25")
        'globalConfig.addElement("/root/smtp", "smtpUser", "azriel")
        'globalConfig.addElement("/root/smtp", "smtpPass", "UmtU8Scb")
    End Sub

    ' Lecture d'un fichier de config XML (SMTP)
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Lecture d'un fichier de config XML
        'MsgBox(GlobalsCRODIP.GLOBalConfig.getElementValue("/root/smtp/smtpHost"))
    End Sub
#End Region

#Region "controle Regulier"
    Private Function LoadListControleRegulier() As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCol As Collection
            oCol = AutoTestManager.getcolControlesReguliers(agentCourant, , dtp_ControleRegulier.Value, dtp_ControleRegulier.Value)
            If oCol Is Nothing Or oCol.Count = 0 Then
                oCol = AutoTestManager.CreateControlesReguliers(agentCourant, dtp_ControleRegulier.Value)
            End If
            bsControleQuotidien.Clear()
            For Each obj As AutoTest In oCol
                bsControleQuotidien.Add(obj)
            Next
        Catch ex As Exception
            CSDebug.dispError("Accueil.LoadListeControleRegulier : ERR " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Sub dgv_ControleRegulier_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Trace.WriteLine("dgv_ControleRegulier_CurrentCellDirtyStateChanged")
        If dgv_ControleRegulier.CurrentCell.ColumnIndex > 1 And dgv_ControleRegulier.IsCurrentCellDirty Then
            dgv_ControleRegulier.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub



#End Region





    Private Sub btn_controleQuotdien_Exporter_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleQuotdien_Exporter.Click
        Dim oDlg As New dlgExportAutoTest()

        If oDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Sauvegarde des Autotests en cours
            For Each obj As AutoTest In bsControleQuotidien
                AutoTestManager.save(obj)
            Next
            AutoTestManager.ExportAsCSV(oDlg.getDateDeb(), oDlg.getDateFin(), agentCourant, oDlg.getFileName())

        End If

    End Sub

    Private Sub btn_controleQuotdien_Valider_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleQuotdien_Valider.Click
        For Each obj As AutoTest In bsControleQuotidien
            AutoTestManager.save(obj)
        Next
        My.Settings.nbControlesAvantAlerte = 0
        My.Settings.Save()
    End Sub

    Private Sub dtp_ControleRegulier_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_ControleRegulier.ValueChanged
        LoadListControleRegulier()
    End Sub

    '================================================================================================
    '    MODULE DOCUMENTAIRE
    '================================================================================================
    'Click sur le bouton Refresh
    Private Sub pctbx_Docs_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctbx_Docs_refresh.Click
        ModDoc_PopulateTreeView()
    End Sub
    ''' Click sur un noeud du Tv
    Private Sub TreeView1_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tv_Docs.NodeMouseClick
        ModDoc_NodeClick(e.Node)
    End Sub
    'Selection d'un element dans le LV du module documentaire
    Private Sub lv_Docs_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv_Docs.ItemActivate
        ModDoc_SelectItem()
    End Sub
    Private Sub btn_imprimerDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimerDoc.Click
        ModDoc_ouvrirUndocument()
    End Sub

    ''' Génération du treeView du module documentaire
    Private Sub ModDoc_PopulateTreeView()
        Dim rootNode As TreeNode
        'Nettoyage
        tv_Docs.Nodes.Clear()
        lv_Docs.Items.Clear()

        Dim info As New DirectoryInfo(My.Settings.ModuleDocumentaire)
        If info.Exists Then
            rootNode = New TreeNode(info.Name)
            rootNode.Tag = info 'Les DirectoryInfo sont placées dans le tag
            'Chargement des sous répertoires
            ModDoc_GetDirectories(info.GetDirectories(), rootNode)
            tv_Docs.Nodes.Add(rootNode)
        End If

    End Sub

    ''' Ajout des Sous Répertoire dans un noeud du Tv (Récursif)
    Private Sub ModDoc_GetDirectories(ByVal subDirs() As DirectoryInfo,
        ByVal nodeToAddTo As TreeNode)

        Dim aNode As TreeNode
        Dim subSubDirs() As DirectoryInfo
        Dim subDir As DirectoryInfo
        For Each subDir In subDirs
            If Not subDir.Name.StartsWith("_") Then
                If subDir.Name.ToUpper().Trim() = "COMMUN" Then
                    subSubDirs = subDir.GetDirectories()
                    If subSubDirs.Length <> 0 Then
                        ModDoc_GetDirectories(subSubDirs, nodeToAddTo)
                    End If
                Else
                    aNode = New TreeNode(subDir.Name, 0, 0)
                    aNode.Tag = subDir
                    aNode.StateImageIndex = 0 'Folder Fermé
                    aNode.SelectedImageIndex = 2 'Folder Ouvert
                    subSubDirs = subDir.GetDirectories()
                    If subSubDirs.Length <> 0 Then
                        ModDoc_GetDirectories(subSubDirs, aNode)
                    End If
                    nodeToAddTo.Nodes.Add(aNode)
                End If
            End If
        Next subDir

    End Sub
    'Selection d'un noeud dans le treeView
    Private Sub ModDoc_NodeClick(ByVal pNode As TreeNode)
        Dim newSelected As TreeNode = pNode
        lv_Docs.Items.Clear()
        'Récupération du directory info dans le TreeView
        Dim nodeDirInfo As DirectoryInfo = CType(newSelected.Tag, DirectoryInfo)

        ModDoc_AfficheListView(nodeDirInfo)

    End Sub
    'Affiche des Items dans le ListView
    Private Sub ModDoc_AfficheListView(ByVal pDir As DirectoryInfo)
        'Ajout des items "Directory"
        Dim dir As DirectoryInfo
        Dim item As ListViewItem = Nothing
        Dim subItems() As ListViewItem.ListViewSubItem

        For Each dir In pDir.GetDirectories()
            If dir.Name.ToUpper.Trim() = "COMMUN" Then
                ModDoc_AfficheListView(dir)
            Else
                If dir.Name.ToUpper.Trim() <> "_parametres".ToUpper().Trim() Then
                    item = New ListViewItem(dir.Name, 0)
                    subItems = New ListViewItem.ListViewSubItem() _
                        {New ListViewItem.ListViewSubItem(item, "Directory"),
                        New ListViewItem.ListViewSubItem(item,
                        dir.LastAccessTime.ToShortDateString())}

                    item.SubItems.AddRange(subItems)
                    lv_Docs.Items.Add(item)
                End If
            End If
        Next dir
        'Ajout des items "File"
        Dim file As FileInfo
        For Each file In pDir.GetFiles()
            If file.Name <> "cmd.txt" And Not file.Name.EndsWith(".old") Then
                item = New ListViewItem(file.Name, 1)
                item.Tag = file.FullName
                subItems = New ListViewItem.ListViewSubItem() _
                    {New ListViewItem.ListViewSubItem(item, "File"),
                    New ListViewItem.ListViewSubItem(item,
                    file.LastAccessTime.ToShortDateString())}

                item.SubItems.AddRange(subItems)
                lv_Docs.Items.Add(item)
            End If
        Next file

    End Sub

    'Selection d'un Item dans le ListView
    'Si c'est un Doc => ouvrir le Document
    'Si c'est un répertoire => Ouvrir le Répertoire
    Private Sub ModDoc_SelectItem()
        Try

            Dim item As ListViewItem = Nothing
            item = lv_Docs.SelectedItems(0)
            If item IsNot Nothing Then
                If item.SubItems(1).Text = "File" Then
                    ModDoc_ouvrirUndocument()
                End If
                If item.SubItems(1).Text = "Directory" Then
                    Try

                        'Recherch du node correspondant à l'élement selectionné
                        For Each oNode As TreeNode In tv_Docs.SelectedNode.Nodes
                            If oNode.Text = item.Text Then
                                'Simulatino du click sur le Node
                                TreeView1_NodeMouseClick(tv_Docs, New TreeNodeMouseClickEventArgs(oNode, Windows.Forms.MouseButtons.Left, 2, 0, 0))
                                'Désignation du node selectionné
                                tv_Docs.SelectedNode = oNode
                            End If
                        Next
                    Catch ex As Exception
                        CSDebug.dispError("Accueil.ModDoc_SelectItem [" & item.Text & "] ERR " & ex.Message)
                    End Try

                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("Accueil.ModDoc_SelectItem ERR " & ex.Message)
        End Try

    End Sub
    ''' Ouvre un document du module Documentaire
    Private Function ModDoc_ouvrirUndocument() As Boolean
        Dim bReturn As Boolean
        Try

            Dim item As ListViewItem = Nothing
            item = lv_Docs.SelectedItems(0)
            If item IsNot Nothing Then
                If item.SubItems(1).Text = "File" Then
                    CSFile.open(item.Tag)
                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Accueil.ouvrirUndocument ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        Dim oStat As StatsCrodip
        oStat = New StatsCrodip()
        Me.Cursor = Cursors.WaitCursor
        oStat.Fill(agentCourant, cbxAnneeReference.Text)

        bsStatistiques.Clear()
        bsStatistiques.Add(oStat)
        bsStatistiques.ResetBindings(False)

        Me.Cursor = Me.DefaultCursor
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub


    Private Sub btn_InitLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_InitLog.Click
        If MessageBox.Show("Etes-vous sur de vouloir réinitialiser le fichier de log de la synchro ?", "Fichier de Log", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'Rénitialisation du fichier e logde la synchro
            SynchronisationManager.ReinitFichierLOGSynchro()


        End If

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub lla_Rappeltolérance_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lla_Rappeltolérance.LinkClicked
        dlgToleranceBuses.ShowDialog()
    End Sub

    Private Sub btnSupprPulve_Click(sender As Object, e As EventArgs) Handles btnSupprPulve.Click
        supprimerUnPulverisateur()
    End Sub

    Private Sub btnFichePulve_Click(sender As Object, e As EventArgs) Handles btnFichePulve.Click
        VoirFichePulve()
    End Sub

    Private Sub btnAjoutPulve_Click(sender As Object, e As EventArgs) Handles btnAjoutPulve.Click
        AjouterUnPulve()
    End Sub

    Private Sub btnTransfertPulve_Click(sender As Object, e As EventArgs) Handles btnTransfertPulve.Click
        'For Each ocol As DataGridViewColumn In dgvPulveExploit.Columns
        '    CSDebug.dispError(ocol.HeaderText & " ->" & ocol.Width)
        'Next
        transfererUnPulve()
    End Sub
    Private Sub transfererUnPulve()
        If dgvPulveExploit.SelectedRows.Count = 1 Then
            Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
            pulverisateurCourant = m_BindingListOfPulve(oRowIndex)
            Dim formtrfPulve As New transfert_pulve(clientCourant, pulverisateurCourant, agentCourant)
            formtrfPulve.ShowDialog()
            loadListPulveExploitation(False)
        End If
    End Sub

    'Private Sub list_ficheClient_puverisateur_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If dgvPulveExploit.SelectedRows.Count >= 1 Then
    '        Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
    '        pulverisateurCourant = m_BindingListOfPulve(oRowIndex)
    '        If Not pulverisateurCourant Is Nothing Then
    '            If Not agentCourant.AleDroit(pulverisateurCourant) Then
    '                btn_ficheClient_diagnostic_nouveau.Enabled = False
    '                btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
    '                btn_ficheClient_diagnostic_voir.Enabled = False
    '                btnSupprPulve.Enabled = False
    '            Else
    '                btn_ficheClient_diagnostic_nouveau.Enabled = Not agentCourant.isGestionnaire
    '                btn_ficheClient_diagnostic_nouvelleCV.Enabled = Not agentCourant.isGestionnaire
    '                btn_ficheClient_diagnostic_voir.Enabled = Not agentCourant.isGestionnaire
    '                btnSupprPulve.Enabled = Not agentCourant.isGestionnaire
    '            End If
    '        End If
    '    End If
    'End Sub


    'Private Sub LaChrgmtSynhcro_Click(sender As Object, e As EventArgs)
    '    ' Historique des synchro
    '    'loadListSynchro()

    'End Sub

    Private Sub dgvPulveExploit_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvPulveExploit.RowPrePaint
        Dim index As Integer = e.RowIndex
        Dim opulve As Pulverisateur = m_BindingListOfPulve(index)
        If opulve.dateProchainControleAsDate < Date.Now Or opulve.controleEtat = Pulverisateur.controleEtatNOKCC Or opulve.controleEtat = Pulverisateur.controleEtatNOKCV Then
            '            dgvPulveExploit.Rows(index).DefaultCellStyle.ForeColor = Color.Black
            dgvPulveExploit.Rows(index).DefaultCellStyle.ForeColor = Color.OrangeRed
            dgvPulveExploit.Rows(index).DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dgvPulveExploit.Rows(index).DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue
            dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Black
            dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionBackColor = GlobalsCRODIP.GLOB_BLUE_CROPDIP

        Else
            dgvPulveExploit.Rows(index).DefaultCellStyle.ForeColor = Color.Black
            dgvPulveExploit.Rows(index).DefaultCellStyle.BackColor = Color.White
            dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionForeColor = Color.White
            dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionBackColor = GlobalsCRODIP.GLOB_BLUE_CROPDIP
        End If
        'If opulve.dateProchainControleAsDate.HasValue And opulve.dateProchainControleAsDate < Date.Now Then
        '    dgvPulveExploit.Rows(index).DefaultCellStyle.ForeColor = Color.Red
        '    dgvPulveExploit.Rows(index).DefaultCellStyle.BackColor = Color.White
        '    dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Red
        '    dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionBackColor = Color.FromArgb(2, 129, 198)
        'End If
    End Sub
    Private Sub dgvPulveExploit_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgvPulveExploit.CellValueNeeded
        If e.RowIndex >= 0 And e.ColumnIndex = IconPulveCol.Index Then
            Dim index As Integer = e.RowIndex
            Dim opulve As Pulverisateur = m_BindingListOfPulve(index)
            e.Value = Crodip_agent.Resources.PuceGriseT
            If opulve.controleEtat = Pulverisateur.controleEtatOK Then
                e.Value = Crodip_agent.Resources.PuceVerteT
            End If
            If opulve.controleEtat = Pulverisateur.controleEtatNOKCV Then
                e.Value = Crodip_agent.Resources.PuceJauneT
            End If
            If opulve.controleEtat = Pulverisateur.controleEtatNOKCC Then
                e.Value = Crodip_agent.Resources.PuceRougeT
            End If


        End If
    End Sub

    Private Sub dgvPulveExploit_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvPulveExploit.MouseDoubleClick
#If DEBUG Then
        NouveauDiagnostic(GlobalsCRODIP.DiagMode.CTRL_COMPLET)
#End If
    End Sub


    Private Sub btnMAJPulverisateurs_Click(sender As Object, e As EventArgs) Handles btnMAJPulverisateurs.Click
        Me.Cursor = Cursors.WaitCursor
        PulverisateurManager.MAJetatPulverisateurs(agentCourant)
        Me.Cursor = Cursors.Default
        MsgBox("Traitement terminé")
    End Sub

    Private Sub dgvPulveExploit_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPulveExploit.SelectionChanged
        Try
            If dgvPulveExploit.SelectedRows.Count > 0 Then
                Dim index As Integer = dgvPulveExploit.SelectedRows(0).Index
                Dim opulve As Pulverisateur = m_BindingListOfPulve(index)
                If agentCourant.AleDroit(opulve) Then
                    btn_ficheClient_diagnostic_nouveau.Enabled = Not agentCourant.isGestionnaire
                    If opulve.controleEtat <> "0" Then
                        btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
                    Else
                        btn_ficheClient_diagnostic_nouvelleCV.Enabled = Not agentCourant.isGestionnaire
                    End If
                    btn_ficheClient_diagnostic_voir.Enabled = Not agentCourant.isGestionnaire
                    btnSupprPulve.Enabled = Not agentCourant.isGestionnaire
                Else
                    btn_ficheClient_diagnostic_nouveau.Enabled = False
                    btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
                    btn_ficheClient_diagnostic_voir.Enabled = False
                End If
            Else
                btn_ficheClient_diagnostic_nouveau.Enabled = False
                btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
                btn_ficheClient_diagnostic_voir.Enabled = False

            End If
        Catch

        End Try

    End Sub


    ''' <summary>
    ''' Mise à jour de la dernière date de synhcro de l'agent
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MajDateDernSynhcroagent()
        If MsgBox("Mise à jour de la date de dernière synhcro de l'agent à " & CSDate.ToCRODIPString(DateTime.Now()), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            agentCourant.dateDerniereSynchro = CSDate.ToCRODIPString(DateTime.Now())
            Dim oUpdate As Object = Nothing
            AgentManager.sendWSAgent(agentCourant, oUpdate)
        End If

    End Sub
    Public Sub Notice(pMsg As String) Implements IObservateur.Notice
        afficheSynchroCourante(pMsg)
    End Sub

    Private Sub PictureBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles pctLogoSynchro.MouseClick
        MajDateDernSynhcroagent()
    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs)
        Dim ofrm As New frmControleManometres2(agentCourant)
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)

    End Sub

    Private Sub client_search_query_KeyPress(sender As Object, e As KeyPressEventArgs) Handles client_search_query.KeyPress
        If e.KeyChar = Chr(13) Then
            searchExploitant()
        End If
    End Sub

    Private Sub btnParamModeSimplifie_Click(sender As Object, e As EventArgs) Handles btnParamModeSimplifie.Click
        Dim frm As New tool_ParamModeSimplifie
        frm.ShowDialog()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New tool_importData
        frm.setcontexte(agentCourant)
        frm.ShowDialog()

    End Sub

    Private Sub btnMAJsynchroAgent_Click(sender As Object, e As EventArgs) Handles btnMAJsynchroAgent.Click
        Dim frm As New frmMAJsynchroAgent
        frm.ShowDialog()

    End Sub

    Private Sub Btn_SynhcroDiag_Click(sender As Object, e As EventArgs) Handles Btn_SynhcroDiag.Click
        Dim oDiag As Diagnostic
        Dim bReturn As Boolean

        If CSSoftwareUpdate.checkMAJ() Then
            MsgBox("Une Mise à jour est disponible, vous devez l'installer avant de vous synchroniser")
            Application.Exit()
            Exit Sub
        End If

        If tbNumDiag.Text <> "" Then
            oDiag = DiagnosticManager.getDiagnosticById(tbNumDiag.Text)
            If oDiag.id = tbNumDiag.Text Then
                Me.Cursor = Cursors.WaitCursor
                Dim oSynchro As New Synchronisation(agentCourant)
                oSynchro.ajouteObservateur(TryCast(MdiParent, parentContener))
                oSynchro.ajouteObservateur(Me)
                Dim oExploit As Exploitation
                oExploit = ExploitationManager.getExploitationById(oDiag.proprietaireId)
                If oExploit.id = oDiag.proprietaireId Then
                    oSynchro.RunASCSynchroExploit(oExploit)
                End If
                Dim oPulve As Pulverisateur
                oPulve = PulverisateurManager.getPulverisateurById(oDiag.pulverisateurId)
                If oPulve.id = oDiag.pulverisateurId Then
                    oSynchro.RunAscSynchroPulve(oPulve)
                End If
                Dim oExploitToPulve As ExploitationTOPulverisateur
                oExploitToPulve = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(oDiag.proprietaireId, oDiag.pulverisateurId)
                If oExploitToPulve.idPulverisateur = oDiag.pulverisateurId Then
                    oSynchro.RunAscSynchroExploit2Pulve(oExploitToPulve)
                End If

                bReturn = oSynchro.runascSynchroDiag(agentCourant, oDiag)
                Me.Cursor = Cursors.Default
                If Not bReturn Then
                    oSynchro.Notice("Synchronisation de diagnostic [" & oDiag.id & "] ERREUR")
                Else
                    oSynchro.Notice("Synchronisation de diagnostic [" & oDiag.id & "] OK")
                    tbNumDiag.Text = ""
                End If

            End If
        End If
    End Sub

    Private Sub btn_LieuxControle_Click(sender As Object, e As EventArgs) Handles btn_LieuxControle.Click
        Dim odlg As New frmGestLieuxControle()
        odlg.ShowDialog()
    End Sub

    Private Sub client_search_query_TextChanged(sender As Object, e As EventArgs) Handles client_search_query.TextChanged

    End Sub

    Private Sub btn_rechercher_exploitant_Click(sender As Object, e As EventArgs) Handles btn_rechercher_exploitant.Click

    End Sub

    Private Sub btn_Facturation_Click(sender As Object, e As EventArgs) Handles btn_Facturation.Click
        Dim ofrm As frmdiagnostic_facturationCoProp
        ofrm = New frmdiagnostic_facturationCoProp()
        ofrm.setContexte(agentCourant)
        ofrm.ShowDialog(Me)

    End Sub
End Class
