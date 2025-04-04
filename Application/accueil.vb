Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports Ionic.Zip
Imports CRODIPWS

Public Class accueil
    Inherits frmCRODIP
    Implements IObservateur

    Public GLOB_BLUE_CROPDIP As Color = Color.FromArgb(2, 129, 198)

    ' Filtre les clients qui ont des alertes ou non
    Private m_Exploitation_isShowAll As Boolean = False
    'Liste Sortable conteant les pulv�
    Private m_BindingListOfPulve As SortableBindingList(Of Pulverisateur)


    Friend WithEvents btn_InitLog As System.Windows.Forms.Label
    Friend WithEvents laNomStructure2 As System.Windows.Forms.Label
    Friend WithEvents laNomAgent2 As System.Windows.Forms.Label
    Friend WithEvents cbxAnneeReference As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents lla_Rappeltol�rance As System.Windows.Forms.LinkLabel
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
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnRechercher As Button
    Friend WithEvents dtpDeb As DateTimePicker
    Friend WithEvents tbNomClient As TextBox
    Friend WithEvents rbNomClient As RadioButton
    Friend WithEvents tbNumFact As TextBox
    Friend WithEvents rbNumFact As RadioButton
    Friend WithEvents dtpFin As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents rbDatesFacture As RadioButton
    Friend WithEvents btnAjoutFacture As Button
    Friend WithEvents dgvFactures As DataGridView
    Friend WithEvents m_bsFacture As BindingSource
    Friend WithEvents btnExportFacture As Button
    Friend WithEvents IdFactureDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateFactureDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClientColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdDiagDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalHTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalTTCDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IsRegleeDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents PDFColumn As DataGridViewImageColumn
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox25 As TextBox
    Friend WithEvents TextBox27 As TextBox
    Friend WithEvents TextBox28 As TextBox
    Friend WithEvents TextBox29 As TextBox
    Friend WithEvents TextBox30 As TextBox
    Friend WithEvents TextBox31 As TextBox
    Friend WithEvents TextBox32 As TextBox
    Friend WithEvents TextBox33 As TextBox
    Friend WithEvents TextBox34 As TextBox
    Friend WithEvents TextBox35 As TextBox
    Friend WithEvents TextBox36 As TextBox
    Friend WithEvents TextBox37 As TextBox
    Friend WithEvents TextBox38 As TextBox
    Friend WithEvents TextBox39 As TextBox
    Friend WithEvents TextBox40 As TextBox
    Friend WithEvents TextBox41 As TextBox
    Friend WithEvents TextBox42 As TextBox
    Friend WithEvents TextBox43 As TextBox
    Friend WithEvents TextBox44 As TextBox
    Friend WithEvents TextBox45 As TextBox
    Friend WithEvents TextBox46 As TextBox
    Friend WithEvents TextBox47 As TextBox
    Friend WithEvents TextBox48 As TextBox
    Friend WithEvents TextBox49 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents laAjoutPulveAdditionnel As Label
    Friend WithEvents IconPulveCol As DataGridViewImageColumn
    Friend WithEvents NumeroNationalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents MarqueDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModeleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombreBusesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CapaciteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AttelageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AnneeAchatDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateProchainControleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IconPulveColumn As DataGridViewTextBoxColumn
    Friend WithEvents PulvePrincipalNumNatDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FichePulve As DataGridViewImageColumn
    Friend WithEvents btnMAJPulveFromDiag As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents typeLibelle As DataGridViewTextBoxColumn
    Friend WithEvents idMateriel As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents OK As DataGridViewCheckBoxColumn
    Friend WithEvents NOK As DataGridViewCheckBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdStructureDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UidstructureSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UidstructureDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NumAgentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AidagentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UidagentSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UidagentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TypeLibelleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdMaterielDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UidmaterielDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UidmaterielSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateControleSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateControleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EtatDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IsOKDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents IsNOKDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents IsNonEffectueDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents TracaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NumeroNationalDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents UidDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AidDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModificationAgentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModificationAgentSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModificationCrodipDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModificationCrodipSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents lblPool As Label
    Friend WithEvents Label13 As Label


#Region " Code g�n�r� par le Concepteur Windows Form "
    Private m_bDuringLoad As Boolean
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()


        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()
        'Je ne sais pourquoi mais le style des ent�te change souvent tout seul
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

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
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

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'�diteur de code.
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
    Friend WithEvents lbl_mesInfos_dateDerni�reConnexion As System.Windows.Forms.Label
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
    Friend WithEvents btn_controleQuotdien_Valider As System.Windows.Forms.Button
    Friend WithEvents dgv_ControleRegulier As System.Windows.Forms.DataGridView
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.lla_Rappeltol�rance = New System.Windows.Forms.LinkLabel()
        Me.dtp_ControleRegulier = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btn_controleQuotdien_Valider = New System.Windows.Forms.Button()
        Me.dgv_ControleRegulier = New System.Windows.Forms.DataGridView()
        Me.typeLibelle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idMateriel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NOK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsControleQuotidien = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.picsRefresh = New System.Windows.Forms.PictureBox()
        Me.accueil_panelAlertes = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.title_mesAlertes = New System.Windows.Forms.Label()
        Me.tabAccueil_mesinfos = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_infosAgent_dateDernCnx = New System.Windows.Forms.Label()
        Me.lbl_infosAgent_IdCrodip = New System.Windows.Forms.Label()
        Me.pctLogo = New System.Windows.Forms.PictureBox()
        Me.lbl_mesInfos_dateDerni�reConnexion = New System.Windows.Forms.Label()
        Me.lbl_mesInfos_dateDerniereUtilisation = New System.Windows.Forms.Label()
        Me.lbl_mesInfos_prenom = New System.Windows.Forms.Label()
        Me.lbl_mesInfos_nom = New System.Windows.Forms.Label()
        Me.lbl_mesInfos_idCrodip = New System.Windows.Forms.Label()
        Me.title_mesInfos = New System.Windows.Forms.Label()
        Me.lbl_infosAgent_Nom = New System.Windows.Forms.Label()
        Me.lbl_infosAgent_Prenom = New System.Windows.Forms.Label()
        Me.lbl_infosAgent_dateDernSynchro = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.tabControl_clientele = New System.Windows.Forms.TabPage()
        Me.panel_clientele_ficheClient = New System.Windows.Forms.Panel()
        Me.grp_ficheClient_ListePulve = New System.Windows.Forms.GroupBox()
        Me.laAjoutPulveAdditionnel = New System.Windows.Forms.Label()
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
        Me.FichePulve = New System.Windows.Forms.DataGridViewImageColumn()
        Me.m_bsrcPulverisateurTMP = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnTransfertPulve = New System.Windows.Forms.Button()
        Me.btnAjoutPulve = New System.Windows.Forms.Button()
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
        Me.btnMAJPulveFromDiag = New System.Windows.Forms.Button()
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.TextBox34 = New System.Windows.Forms.TextBox()
        Me.TextBox35 = New System.Windows.Forms.TextBox()
        Me.TextBox36 = New System.Windows.Forms.TextBox()
        Me.TextBox37 = New System.Windows.Forms.TextBox()
        Me.TextBox38 = New System.Windows.Forms.TextBox()
        Me.TextBox39 = New System.Windows.Forms.TextBox()
        Me.TextBox40 = New System.Windows.Forms.TextBox()
        Me.TextBox41 = New System.Windows.Forms.TextBox()
        Me.TextBox42 = New System.Windows.Forms.TextBox()
        Me.TextBox43 = New System.Windows.Forms.TextBox()
        Me.TextBox44 = New System.Windows.Forms.TextBox()
        Me.TextBox45 = New System.Windows.Forms.TextBox()
        Me.TextBox46 = New System.Windows.Forms.TextBox()
        Me.TextBox47 = New System.Windows.Forms.TextBox()
        Me.TextBox48 = New System.Windows.Forms.TextBox()
        Me.TextBox49 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.pctLogoStat = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tabControl_Facturation = New System.Windows.Forms.TabPage()
        Me.btnExportFacture = New System.Windows.Forms.Button()
        Me.btnAjoutFacture = New System.Windows.Forms.Button()
        Me.dgvFactures = New System.Windows.Forms.DataGridView()
        Me.IdFactureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateFactureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDiagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalTTCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsRegleeDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PDFColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.m_bsFacture = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnRechercher = New System.Windows.Forms.Button()
        Me.dtpDeb = New System.Windows.Forms.DateTimePicker()
        Me.tbNomClient = New System.Windows.Forms.TextBox()
        Me.rbNomClient = New System.Windows.Forms.RadioButton()
        Me.tbNumFact = New System.Windows.Forms.TextBox()
        Me.rbNumFact = New System.Windows.Forms.RadioButton()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbDatesFacture = New System.Windows.Forms.RadioButton()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdStructureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UidstructureSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UidstructureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumAgentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AidagentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UidagentSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UidagentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeLibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdMaterielDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UidmaterielDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UidmaterielSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateControleSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateControleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EtatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsOKDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsNOKDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsNonEffectueDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TracaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroNationalDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationAgentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationAgentSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationCrodipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationCrodipSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblPool = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl.SuspendLayout()
        Me.tabControl_accueil.SuspendLayout()
        Me.accueil_panelAlertesContener.SuspendLayout()
        CType(Me.dgv_ControleRegulier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsControleQuotidien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picsRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.accueil_panelAlertes.SuspendLayout()
        Me.tabAccueil_mesinfos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.dgvFactures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsFacture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
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
        Me.ColumnHeader1.Text = "N� SIREN"
        Me.ColumnHeader1.Width = 117
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Raison sociale"
        Me.ColumnHeader2.Width = 317
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Pr�nom"
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
        Me.ColumnHeader6.Text = "Prochain contr�le"
        Me.ColumnHeader6.Width = 138
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "N� SIREN"
        Me.ColumnHeader8.Width = 117
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Raison sociale"
        Me.ColumnHeader9.Width = 190
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Nom de l�exploitation"
        Me.ColumnHeader10.Width = 156
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Pr�nom"
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
        Me.ColumnHeader14.Text = "Prochain contr�le"
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
        Me.m_SaveFileDialog.Title = "R�pertoire d'export"
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
        Me.tabControl.Size = New System.Drawing.Size(1017, 679)
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
        Me.tabControl_accueil.Size = New System.Drawing.Size(1009, 653)
        Me.tabControl_accueil.TabIndex = 0
        Me.tabControl_accueil.Text = "Accueil"
        '
        'accueil_panelAlertesContener
        '
        Me.accueil_panelAlertesContener.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.accueil_panelAlertesContener.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.accueil_panelAlertesContener.Controls.Add(Me.lla_Rappeltol�rance)
        Me.accueil_panelAlertesContener.Controls.Add(Me.dtp_ControleRegulier)
        Me.accueil_panelAlertesContener.Controls.Add(Me.Label20)
        Me.accueil_panelAlertesContener.Controls.Add(Me.btn_controleQuotdien_Valider)
        Me.accueil_panelAlertesContener.Controls.Add(Me.dgv_ControleRegulier)
        Me.accueil_panelAlertesContener.Controls.Add(Me.Label15)
        Me.accueil_panelAlertesContener.Controls.Add(Me.picsRefresh)
        Me.accueil_panelAlertesContener.Controls.Add(Me.accueil_panelAlertes)
        Me.accueil_panelAlertesContener.Controls.Add(Me.title_mesAlertes)
        Me.accueil_panelAlertesContener.Location = New System.Drawing.Point(0, 144)
        Me.accueil_panelAlertesContener.Name = "accueil_panelAlertesContener"
        Me.accueil_panelAlertesContener.Size = New System.Drawing.Size(1009, 512)
        Me.accueil_panelAlertesContener.TabIndex = 1
        '
        'lla_Rappeltol�rance
        '
        Me.lla_Rappeltol�rance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lla_Rappeltol�rance.AutoSize = True
        Me.lla_Rappeltol�rance.Location = New System.Drawing.Point(459, 374)
        Me.lla_Rappeltol�rance.Name = "lla_Rappeltol�rance"
        Me.lla_Rappeltol�rance.Size = New System.Drawing.Size(164, 13)
        Me.lla_Rappeltol�rance.TabIndex = 15
        Me.lla_Rappeltol�rance.TabStop = True
        Me.lla_Rappeltol�rance.Text = "Rappel des tol�rances des buses"
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
        Me.Label20.Text = "Contr�le r�gulier du : "
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ControleRegulier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ControleRegulier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ControleRegulier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.typeLibelle, Me.idMateriel, Me.Type, Me.OK, Me.NOK, Me.IdDataGridViewTextBoxColumn, Me.IdStructureDataGridViewTextBoxColumn, Me.UidstructureSDataGridViewTextBoxColumn, Me.UidstructureDataGridViewTextBoxColumn, Me.NumAgentDataGridViewTextBoxColumn, Me.AidagentDataGridViewTextBoxColumn, Me.UidagentSDataGridViewTextBoxColumn, Me.UidagentDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn, Me.TypeLibelleDataGridViewTextBoxColumn, Me.IdMaterielDataGridViewTextBoxColumn, Me.UidmaterielDataGridViewTextBoxColumn, Me.UidmaterielSDataGridViewTextBoxColumn, Me.DateControleSDataGridViewTextBoxColumn, Me.DateControleDataGridViewTextBoxColumn, Me.EtatDataGridViewTextBoxColumn, Me.IsOKDataGridViewCheckBoxColumn, Me.IsNOKDataGridViewCheckBoxColumn, Me.IsNonEffectueDataGridViewCheckBoxColumn, Me.TracaDataGridViewTextBoxColumn, Me.NumeroNationalDataGridViewTextBoxColumn1, Me.UidDataGridViewTextBoxColumn, Me.AidDataGridViewTextBoxColumn, Me.DateModificationAgentDataGridViewTextBoxColumn, Me.DateModificationAgentSDataGridViewTextBoxColumn, Me.DateModificationCrodipDataGridViewTextBoxColumn, Me.DateModificationCrodipSDataGridViewTextBoxColumn})
        Me.dgv_ControleRegulier.DataSource = Me.bsControleQuotidien
        Me.dgv_ControleRegulier.Location = New System.Drawing.Point(6, 251)
        Me.dgv_ControleRegulier.Name = "dgv_ControleRegulier"
        Me.dgv_ControleRegulier.RowHeadersWidth = 10
        Me.dgv_ControleRegulier.Size = New System.Drawing.Size(429, 252)
        Me.dgv_ControleRegulier.TabIndex = 10
        '
        'typeLibelle
        '
        Me.typeLibelle.DataPropertyName = "typeLibelle"
        Me.typeLibelle.FillWeight = 30.0!
        Me.typeLibelle.HeaderText = "Type"
        Me.typeLibelle.Name = "typeLibelle"
        Me.typeLibelle.ReadOnly = True
        '
        'idMateriel
        '
        Me.idMateriel.DataPropertyName = "numeroNational"
        Me.idMateriel.FillWeight = 20.0!
        Me.idMateriel.HeaderText = "Identifiant"
        Me.idMateriel.Name = "idMateriel"
        '
        'Type
        '
        Me.Type.DataPropertyName = "Traca"
        Me.Type.FillWeight = 20.0!
        Me.Type.HeaderText = "Traca"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        '
        'OK
        '
        Me.OK.DataPropertyName = "isOK"
        Me.OK.FillWeight = 10.0!
        Me.OK.HeaderText = "OK"
        Me.OK.Name = "OK"
        '
        'NOK
        '
        Me.NOK.DataPropertyName = "isNOK"
        Me.NOK.FillWeight = 10.0!
        Me.NOK.HeaderText = "NOK"
        Me.NOK.Name = "NOK"
        '
        'bsControleQuotidien
        '
        Me.bsControleQuotidien.DataSource = GetType(CRODIPWS.AutoTest)
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(834, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(158, 16)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Rafra�chir les alertes"
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
        Me.accueil_panelAlertes.Size = New System.Drawing.Size(1009, 165)
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
        Me.Label8.Text = "       Vous avez 2 manom�tre(s) � contr�ler prochainement"
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
        Me.Label10.Text = "       Vous avez 4 exploitant(s) dont la date de prochain contr�le approche"
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
        Me.Label9.Text = "       Vous avez 1 manom�tre(s) hors norme"
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
        Me.tabAccueil_mesinfos.Controls.Add(Me.lblPool)
        Me.tabAccueil_mesinfos.Controls.Add(Me.Label13)
        Me.tabAccueil_mesinfos.Controls.Add(Me.PictureBox1)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_dateDernCnx)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_IdCrodip)
        Me.tabAccueil_mesinfos.Controls.Add(Me.pctLogo)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_dateDerni�reConnexion)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_dateDerniereUtilisation)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_prenom)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_nom)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_mesInfos_idCrodip)
        Me.tabAccueil_mesinfos.Controls.Add(Me.title_mesInfos)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_Nom)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_Prenom)
        Me.tabAccueil_mesinfos.Controls.Add(Me.lbl_infosAgent_dateDernSynchro)
        Me.tabAccueil_mesinfos.Controls.Add(Me.LinkLabel1)
        Me.tabAccueil_mesinfos.Location = New System.Drawing.Point(0, 0)
        Me.tabAccueil_mesinfos.Name = "tabAccueil_mesinfos"
        Me.tabAccueil_mesinfos.Size = New System.Drawing.Size(1009, 136)
        Me.tabAccueil_mesinfos.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.Crodip_agent.Resources.e_pulve_logo_blanc_bleu_1
        Me.PictureBox1.Location = New System.Drawing.Point(733, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(114, 84)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'lbl_infosAgent_dateDernCnx
        '
        Me.lbl_infosAgent_dateDernCnx.Location = New System.Drawing.Point(576, 56)
        Me.lbl_infosAgent_dateDernCnx.Name = "lbl_infosAgent_dateDernCnx"
        Me.lbl_infosAgent_dateDernCnx.Size = New System.Drawing.Size(140, 16)
        Me.lbl_infosAgent_dateDernCnx.TabIndex = 8
        Me.lbl_infosAgent_dateDernCnx.Text = "01/01/1900"
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
        'lbl_mesInfos_dateDerni�reConnexion
        '
        Me.lbl_mesInfos_dateDerni�reConnexion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesInfos_dateDerni�reConnexion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_mesInfos_dateDerni�reConnexion.Location = New System.Drawing.Point(360, 80)
        Me.lbl_mesInfos_dateDerni�reConnexion.Name = "lbl_mesInfos_dateDerni�reConnexion"
        Me.lbl_mesInfos_dateDerni�reConnexion.Size = New System.Drawing.Size(216, 16)
        Me.lbl_mesInfos_dateDerni�reConnexion.TabIndex = 5
        Me.lbl_mesInfos_dateDerni�reConnexion.Text = "Date de derni�re synchronisation :"
        '
        'lbl_mesInfos_dateDerniereUtilisation
        '
        Me.lbl_mesInfos_dateDerniereUtilisation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesInfos_dateDerniereUtilisation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_mesInfos_dateDerniereUtilisation.Location = New System.Drawing.Point(360, 56)
        Me.lbl_mesInfos_dateDerniereUtilisation.Name = "lbl_mesInfos_dateDerniereUtilisation"
        Me.lbl_mesInfos_dateDerniereUtilisation.Size = New System.Drawing.Size(216, 16)
        Me.lbl_mesInfos_dateDerniereUtilisation.TabIndex = 4
        Me.lbl_mesInfos_dateDerniereUtilisation.Text = "Date de derni�re utilisation :"
        '
        'lbl_mesInfos_prenom
        '
        Me.lbl_mesInfos_prenom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesInfos_prenom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_mesInfos_prenom.Location = New System.Drawing.Point(48, 104)
        Me.lbl_mesInfos_prenom.Name = "lbl_mesInfos_prenom"
        Me.lbl_mesInfos_prenom.Size = New System.Drawing.Size(120, 16)
        Me.lbl_mesInfos_prenom.TabIndex = 3
        Me.lbl_mesInfos_prenom.Text = "Pr�nom :"
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
        Me.lbl_infosAgent_dateDernSynchro.Size = New System.Drawing.Size(151, 16)
        Me.lbl_infosAgent_dateDernSynchro.TabIndex = 8
        Me.lbl_infosAgent_dateDernSynchro.Text = "01/01/1900"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(733, 111)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(114, 25)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Acc�s � e-pulve"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tabControl_clientele
        '
        Me.tabControl_clientele.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_clientele.Controls.Add(Me.panel_clientele_ficheClient)
        Me.tabControl_clientele.Controls.Add(Me.panel_ListeDesControles)
        Me.tabControl_clientele.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabControl_clientele.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_clientele.Name = "tabControl_clientele"
        Me.tabControl_clientele.Size = New System.Drawing.Size(1009, 653)
        Me.tabControl_clientele.TabIndex = 1
        Me.tabControl_clientele.Text = "Contr�le"
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
        Me.panel_clientele_ficheClient.Size = New System.Drawing.Size(1001, 443)
        Me.panel_clientele_ficheClient.TabIndex = 8
        Me.panel_clientele_ficheClient.Visible = False
        '
        'grp_ficheClient_ListePulve
        '
        Me.grp_ficheClient_ListePulve.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.laAjoutPulveAdditionnel)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.dgvPulveExploit)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btnTransfertPulve)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btnAjoutPulve)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btn_ficheClient_diagnostic_nouveau)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btn_ficheClient_diagnostic_nouvelleCV)
        Me.grp_ficheClient_ListePulve.Controls.Add(Me.btn_ficheClient_diagnostic_voir)
        Me.grp_ficheClient_ListePulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_ficheClient_ListePulve.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.grp_ficheClient_ListePulve.Location = New System.Drawing.Point(8, 147)
        Me.grp_ficheClient_ListePulve.Name = "grp_ficheClient_ListePulve"
        Me.grp_ficheClient_ListePulve.Size = New System.Drawing.Size(981, 275)
        Me.grp_ficheClient_ListePulve.TabIndex = 10
        Me.grp_ficheClient_ListePulve.TabStop = False
        Me.grp_ficheClient_ListePulve.Text = "Liste des pulv�risateurs"
        '
        'laAjoutPulveAdditionnel
        '
        Me.laAjoutPulveAdditionnel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laAjoutPulveAdditionnel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laAjoutPulveAdditionnel.ForeColor = System.Drawing.Color.White
        Me.laAjoutPulveAdditionnel.Image = Global.Crodip_agent.Resources.btn_divers_add
        Me.laAjoutPulveAdditionnel.Location = New System.Drawing.Point(796, 24)
        Me.laAjoutPulveAdditionnel.Name = "laAjoutPulveAdditionnel"
        Me.laAjoutPulveAdditionnel.Size = New System.Drawing.Size(179, 24)
        Me.laAjoutPulveAdditionnel.TabIndex = 34
        Me.laAjoutPulveAdditionnel.Text = "       Equipement additionnel"
        Me.laAjoutPulveAdditionnel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPulveExploit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPulveExploit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPulveExploit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IconPulveCol, Me.NumeroNationalDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn1, Me.MarqueDataGridViewTextBoxColumn, Me.ModeleDataGridViewTextBoxColumn, Me.NombreBusesDataGridViewTextBoxColumn, Me.CapaciteDataGridViewTextBoxColumn, Me.AttelageDataGridViewTextBoxColumn, Me.AnneeAchatDataGridViewTextBoxColumn, Me.DateProchainControleDataGridViewTextBoxColumn, Me.IconPulveColumn, Me.PulvePrincipalNumNatDataGridViewTextBoxColumn, Me.FichePulve})
        Me.dgvPulveExploit.DataSource = Me.m_bsrcPulverisateurTMP
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPulveExploit.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPulveExploit.GridColor = System.Drawing.Color.Black
        Me.dgvPulveExploit.Location = New System.Drawing.Point(11, 62)
        Me.dgvPulveExploit.MultiSelect = False
        Me.dgvPulveExploit.Name = "dgvPulveExploit"
        Me.dgvPulveExploit.ReadOnly = True
        Me.dgvPulveExploit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvPulveExploit.RowHeadersWidth = 20
        Me.dgvPulveExploit.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPulveExploit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPulveExploit.Size = New System.Drawing.Size(964, 207)
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
        Me.NumeroNationalDataGridViewTextBoxColumn.HeaderText = "Identifiant pulv�"
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
        Me.ModeleDataGridViewTextBoxColumn.HeaderText = "Mod�le"
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
        Me.CapaciteDataGridViewTextBoxColumn.HeaderText = "Capacit�"
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
        Me.AnneeAchatDataGridViewTextBoxColumn.HeaderText = "Ann�e Construct."
        Me.AnneeAchatDataGridViewTextBoxColumn.Name = "AnneeAchatDataGridViewTextBoxColumn"
        Me.AnneeAchatDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateProchainControleDataGridViewTextBoxColumn
        '
        Me.DateProchainControleDataGridViewTextBoxColumn.DataPropertyName = "dateProchainControleAsDate"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DateProchainControleDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DateProchainControleDataGridViewTextBoxColumn.FillWeight = 9.0!
        Me.DateProchainControleDataGridViewTextBoxColumn.HeaderText = "Prochain contr�le"
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
        'FichePulve
        '
        Me.FichePulve.FillWeight = 3.0!
        Me.FichePulve.HeaderText = "Voir"
        Me.FichePulve.Image = Global.Crodip_agent.Resources.oeil16x16
        Me.FichePulve.Name = "FichePulve"
        Me.FichePulve.ReadOnly = True
        '
        'm_bsrcPulverisateurTMP
        '
        Me.m_bsrcPulverisateurTMP.DataSource = GetType(CRODIPWS.Pulverisateur)
        '
        'btnTransfertPulve
        '
        Me.btnTransfertPulve.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnTransfertPulve.BackgroundImage = Global.Crodip_agent.Resources.btn_empty
        Me.btnTransfertPulve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTransfertPulve.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnTransfertPulve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnTransfertPulve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransfertPulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfertPulve.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnTransfertPulve.Location = New System.Drawing.Point(507, 24)
        Me.btnTransfertPulve.Name = "btnTransfertPulve"
        Me.btnTransfertPulve.Size = New System.Drawing.Size(112, 24)
        Me.btnTransfertPulve.TabIndex = 31
        Me.btnTransfertPulve.Text = "Transfert"
        Me.btnTransfertPulve.UseVisualStyleBackColor = False
        '
        'btnAjoutPulve
        '
        Me.btnAjoutPulve.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAjoutPulve.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnAjoutPulve.BackgroundImage = CType(resources.GetObject("btnAjoutPulve.BackgroundImage"), System.Drawing.Image)
        Me.btnAjoutPulve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAjoutPulve.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnAjoutPulve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnAjoutPulve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjoutPulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAjoutPulve.ForeColor = System.Drawing.Color.White
        Me.btnAjoutPulve.Location = New System.Drawing.Point(625, 24)
        Me.btnAjoutPulve.Name = "btnAjoutPulve"
        Me.btnAjoutPulve.Size = New System.Drawing.Size(165, 24)
        Me.btnAjoutPulve.TabIndex = 30
        Me.btnAjoutPulve.Text = "Ajouter un pulv� principal"
        Me.btnAjoutPulve.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAjoutPulve.UseVisualStyleBackColor = False
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
        Me.btn_ficheClient_diagnostic_nouveau.Text = "       R�aliser un contr�le complet"
        Me.btn_ficheClient_diagnostic_nouveau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheClient_diagnostic_nouvelleCV
        '
        Me.btn_ficheClient_diagnostic_nouvelleCV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheClient_diagnostic_nouvelleCV.ForeColor = System.Drawing.Color.White
        Me.btn_ficheClient_diagnostic_nouvelleCV.Image = CType(resources.GetObject("btn_ficheClient_diagnostic_nouvelleCV.Image"), System.Drawing.Image)
        Me.btn_ficheClient_diagnostic_nouvelleCV.Location = New System.Drawing.Point(190, 24)
        Me.btn_ficheClient_diagnostic_nouvelleCV.Name = "btn_ficheClient_diagnostic_nouvelleCV"
        Me.btn_ficheClient_diagnostic_nouvelleCV.Size = New System.Drawing.Size(181, 24)
        Me.btn_ficheClient_diagnostic_nouvelleCV.TabIndex = 26
        Me.btn_ficheClient_diagnostic_nouvelleCV.Text = "       R�aliser une contre visite"
        Me.btn_ficheClient_diagnostic_nouvelleCV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheClient_diagnostic_voir
        '
        Me.btn_ficheClient_diagnostic_voir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheClient_diagnostic_voir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btn_ficheClient_diagnostic_voir.Image = CType(resources.GetObject("btn_ficheClient_diagnostic_voir.Image"), System.Drawing.Image)
        Me.btn_ficheClient_diagnostic_voir.Location = New System.Drawing.Point(372, 24)
        Me.btn_ficheClient_diagnostic_voir.Name = "btn_ficheClient_diagnostic_voir"
        Me.btn_ficheClient_diagnostic_voir.Size = New System.Drawing.Size(129, 24)
        Me.btn_ficheClient_diagnostic_voir.TabIndex = 26
        Me.btn_ficheClient_diagnostic_voir.Text = "       Les contr�les"
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
        Me.panel_ListeDesControles.Size = New System.Drawing.Size(1013, 653)
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
        Me.list_clients.Size = New System.Drawing.Size(1010, 541)
        Me.list_clients.TabIndex = 8
        Me.list_clients.UseCompatibleStateImageBehavior = False
        Me.list_clients.View = System.Windows.Forms.View.Details
        '
        'listClients_col_siren
        '
        Me.listClients_col_siren.Text = "N� SIREN"
        Me.listClients_col_siren.Width = 86
        '
        'listClients_col_rs
        '
        Me.listClients_col_rs.Text = "Raison sociale"
        Me.listClients_col_rs.Width = 139
        '
        'listClients_col_prenom
        '
        Me.listClients_col_prenom.Text = "Pr�nom"
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
        Me.listClients_col_ProchainControle.Text = "Prochain contr�le"
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
        Me.panel_clientele_LstCtrlCtriteres.Size = New System.Drawing.Size(1012, 104)
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
        Me.lbl_refresh_lst_clients.Text = "Rafra�chir la liste"
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
        Me.title_alertes.Text = "     Liste des contr�les"
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
        Me.btn_proprietaire_pulveListe.Text = "    Liste pulv�"
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
        Me.btn_proprietaire_ajouter.Text = "      Ajouter un propri�taire"
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
        Me.btn_proprietaire_derniersControles.Text = "       Voir les prochains contr�les"
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
        Me.tabControl_pulverisateurs.Size = New System.Drawing.Size(1009, 653)
        Me.tabControl_pulverisateurs.TabIndex = 2
        Me.tabControl_pulverisateurs.Text = "Pulv�risateurs"
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
        Me.listPulve_lbl_refreshList.Text = "Rafra�chir la liste"
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
        Me.listPulverisateurs.Size = New System.Drawing.Size(993, 599)
        Me.listPulverisateurs.TabIndex = 10
        Me.listPulverisateurs.UseCompatibleStateImageBehavior = False
        Me.listPulverisateurs.View = System.Windows.Forms.View.Details
        '
        'col_idPulve
        '
        Me.col_idPulve.Text = "Identifiant pulv�"
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
        Me.col_prenom.Text = "Pr�nom"
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
        Me.col_dateDernierControle.Text = "D proch contr�le"
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
        Me.Label19.Text = "     Liste des pulv�risateurs"
        '
        'tabControl_synchro
        '
        Me.tabControl_synchro.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_synchro.Controls.Add(Me.Panel4)
        Me.tabControl_synchro.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_synchro.Name = "tabControl_synchro"
        Me.tabControl_synchro.Size = New System.Drawing.Size(1009, 653)
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
        Me.Panel4.Size = New System.Drawing.Size(1009, 656)
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
        Me.Btn_SynhcroDiag.Text = "      Synchronisation d'un contr�le"
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
        Me.Label3.Text = "Num�ro d'un contr�le :"
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
        Me.btn_InitLog.Text = "      R�initialiser  fichier de log"
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
        Me.tabControl_outilscomp.Size = New System.Drawing.Size(1009, 653)
        Me.tabControl_outilscomp.TabIndex = 4
        Me.tabControl_outilscomp.Text = "Outils compl�mentaires"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnMAJPulveFromDiag)
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
        Me.Panel2.Size = New System.Drawing.Size(1009, 656)
        Me.Panel2.TabIndex = 3
        '
        'btnMAJPulveFromDiag
        '
        Me.btnMAJPulveFromDiag.BackgroundImage = CType(resources.GetObject("btnMAJPulveFromDiag.BackgroundImage"), System.Drawing.Image)
        Me.btnMAJPulveFromDiag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMAJPulveFromDiag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnMAJPulveFromDiag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnMAJPulveFromDiag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMAJPulveFromDiag.Location = New System.Drawing.Point(474, 89)
        Me.btnMAJPulveFromDiag.Name = "btnMAJPulveFromDiag"
        Me.btnMAJPulveFromDiag.Size = New System.Drawing.Size(206, 36)
        Me.btnMAJPulveFromDiag.TabIndex = 40
        Me.btnMAJPulveFromDiag.Text = "MAJ pulv� <- DIAG"
        Me.btnMAJPulveFromDiag.UseVisualStyleBackColor = True
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
        Me.btnParamModeSimplifie.Text = "  Param�trage Mode Simplifi�"
        Me.btnParamModeSimplifie.UseVisualStyleBackColor = True
        '
        'btnMAJPulverisateurs
        '
        Me.btnMAJPulverisateurs.BackgroundImage = CType(resources.GetObject("btnMAJPulverisateurs.BackgroundImage"), System.Drawing.Image)
        Me.btnMAJPulverisateurs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMAJPulverisateurs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnMAJPulverisateurs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnMAJPulverisateurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMAJPulverisateurs.Location = New System.Drawing.Point(474, 56)
        Me.btnMAJPulverisateurs.Name = "btnMAJPulverisateurs"
        Me.btnMAJPulverisateurs.Size = New System.Drawing.Size(206, 36)
        Me.btnMAJPulverisateurs.TabIndex = 36
        Me.btnMAJPulverisateurs.Text = "MAJ des Etats de pulv�s"
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
        Me.btn_outilsComplementaires_calcVolumeHectare.Text = "        Calcul du � volume-hectare �"
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
        Me.btn_outilsComplementaires_calcDebitBuses.Text = "        Contr�le jeu de buses suppl�mentaire"
        Me.btn_outilsComplementaires_calcDebitBuses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabControl_parametrage
        '
        Me.tabControl_parametrage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabControl_parametrage.Controls.Add(Me.Panel5)
        Me.tabControl_parametrage.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_parametrage.Name = "tabControl_parametrage"
        Me.tabControl_parametrage.Size = New System.Drawing.Size(1009, 653)
        Me.tabControl_parametrage.TabIndex = 5
        Me.tabControl_parametrage.Text = "Param�trage"
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
        Me.Panel5.Size = New System.Drawing.Size(1009, 656)
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
        Me.btn_LieuxControle.Text = "    Lieux de contr�le"
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
        Me.lblIdentifiantPulve.Text = "    Identifiants pulv�risateur"
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
        Me.lblMaterielsSupprimes.Text = "       Materiels Supprim�s"
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
        Me.lblParametresOrganisme.Text = "       Param�tres de l�organisme"
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
        Me.title_parametrage.Text = "     Param�trage"
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
        Me.lblParametrageAppareilsMesures.Text = "        Param�trage des appareils de mesure"
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
        Me.Label18.Text = "       V�rification des appareils de mesure"
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
        Me.btn_parametrage_tarifs.Text = "     Tarifs appliqu�s"
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
        Me.btn_parametrage_coordonneesOrganisme.Text = "       Coordonn�es Organisme"
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
        Me.btn_parametrage_coordonneesInspecteur.Text = "       Coordonn�es Inspecteur"
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
        Me.btn_parametrage_parametrageManometre.Text = "    Manom�tres"
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
        Me.btn_parametrage_parametrageBuses.Text = "    Buses �talons"
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
        Me.btn_parametrage_verificationManometres.Text = "    Manom�tres"
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
        Me.tabControl_Statistiques.Size = New System.Drawing.Size(1009, 653)
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
        Me.Panel1.Size = New System.Drawing.Size(1009, 656)
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(488, 28)
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
        Me.cbxAnneeReference.Size = New System.Drawing.Size(185, 21)
        Me.cbxAnneeReference.TabIndex = 41
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(207, 4)
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
        Me.TextBox26.Location = New System.Drawing.Point(246, 4)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(238, 13)
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
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.laNomAgent, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.laNomStructure, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label22, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label24, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label26, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox2, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox4, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox5, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox6, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox7, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox8, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox9, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox10, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox11, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox12, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox13, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox14, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox15, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox16, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox17, 2, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox18, 3, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox19, 4, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox20, 5, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox21, 2, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox22, 3, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox23, 4, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox24, 5, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.laNomStructure2, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.laNomAgent2, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox25, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox27, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox28, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox29, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox30, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox31, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox32, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox33, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox34, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox35, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox36, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox37, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox38, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox39, 3, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox40, 4, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox41, 5, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox42, 2, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox43, 3, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox44, 4, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox45, 5, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox46, 2, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox47, 3, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox48, 4, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox49, 5, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.Label23, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label25, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label27, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label28, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label31, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label32, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label33, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label34, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label35, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label36, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.Label37, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label38, 1, 12)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(19, 145)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 13
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(962, 448)
        Me.TableLayoutPanel1.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.Location = New System.Drawing.Point(1, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label4, 2)
        Me.Label4.Size = New System.Drawing.Size(462, 53)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "       Nombre de contr�les r�alis�s  :"
        '
        'laNomAgent
        '
        Me.laNomAgent.BackColor = System.Drawing.Color.Transparent
        Me.laNomAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laNomAgent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laNomAgent.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.laNomAgent.Location = New System.Drawing.Point(615, 1)
        Me.laNomAgent.Name = "laNomAgent"
        Me.laNomAgent.Size = New System.Drawing.Size(108, 16)
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
        Me.laNomStructure.Location = New System.Drawing.Point(499, 1)
        Me.laNomStructure.Name = "laNomStructure"
        Me.laNomStructure.Size = New System.Drawing.Size(108, 16)
        Me.laNomStructure.TabIndex = 38
        Me.laNomStructure.Text = "structure"
        Me.laNomStructure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlCCStructureAnnee", True))
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Location = New System.Drawing.Point(499, 21)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(109, 20)
        Me.TextBox3.TabIndex = 40
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bsStatistiques
        '
        Me.bsStatistiques.DataSource = GetType(Crodip_agent.StatsCrodip)
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label22.Image = CType(resources.GetObject("Label22.Image"), System.Drawing.Image)
        Me.Label22.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label22.Location = New System.Drawing.Point(1, 72)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0)
        Me.Label22.Name = "Label22"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label22, 2)
        Me.Label22.Size = New System.Drawing.Size(462, 53)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "       Pourcentage de conclusion ""Bon �tat""   :"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label24.Image = CType(resources.GetObject("Label24.Image"), System.Drawing.Image)
        Me.Label24.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label24.Location = New System.Drawing.Point(1, 126)
        Me.Label24.Margin = New System.Windows.Forms.Padding(0)
        Me.Label24.Name = "Label24"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label24, 2)
        Me.Label24.Size = New System.Drawing.Size(462, 53)
        Me.Label24.TabIndex = 46
        Me.Label24.Text = "       Pourcentage de conclusion ""CP"" :"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label26.Image = CType(resources.GetObject("Label26.Image"), System.Drawing.Image)
        Me.Label26.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label26.Location = New System.Drawing.Point(1, 180)
        Me.Label26.Margin = New System.Windows.Forms.Padding(0)
        Me.Label26.Name = "Label26"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label26, 2)
        Me.Label26.Size = New System.Drawing.Size(462, 53)
        Me.Label26.TabIndex = 48
        Me.Label26.Text = "       Pourcentage de pulv�risateurs ""R�paration avant"" :"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlCCInspecteurAnnee", True))
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(615, 21)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(109, 20)
        Me.TextBox1.TabIndex = 50
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlCCStructureTotal", True))
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox2.Location = New System.Drawing.Point(731, 21)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(109, 20)
        Me.TextBox2.TabIndex = 51
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlCCInspecteurTotal", True))
        Me.TextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox4.Location = New System.Drawing.Point(847, 21)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(111, 20)
        Me.TextBox4.TabIndex = 52
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_OK_StructureAnnee", True))
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Location = New System.Drawing.Point(499, 75)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(109, 20)
        Me.TextBox5.TabIndex = 53
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_OK_InspecteurAnnee", True))
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Location = New System.Drawing.Point(615, 75)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(109, 20)
        Me.TextBox6.TabIndex = 54
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox7
        '
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_OK_StructureTotal", True))
        Me.TextBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox7.Location = New System.Drawing.Point(731, 75)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(109, 20)
        Me.TextBox7.TabIndex = 55
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox8
        '
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_OK_InspecteurTotal", True))
        Me.TextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox8.Location = New System.Drawing.Point(847, 75)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(111, 20)
        Me.TextBox8.TabIndex = 56
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox9
        '
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_CP_StructureAnnee", True))
        Me.TextBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox9.Location = New System.Drawing.Point(499, 129)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(109, 20)
        Me.TextBox9.TabIndex = 57
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox10
        '
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_CP_InspecteurAnnee", True))
        Me.TextBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox10.Location = New System.Drawing.Point(615, 129)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(109, 20)
        Me.TextBox10.TabIndex = 58
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox11
        '
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_CP_StructureTotal", True))
        Me.TextBox11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox11.Location = New System.Drawing.Point(731, 129)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(109, 20)
        Me.TextBox11.TabIndex = 59
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox12
        '
        Me.TextBox12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_CP_InspecteurTotal", True))
        Me.TextBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox12.Location = New System.Drawing.Point(847, 129)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(111, 20)
        Me.TextBox12.TabIndex = 60
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox13
        '
        Me.TextBox13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_ReparAvant_StructureAnnee", True))
        Me.TextBox13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox13.Location = New System.Drawing.Point(499, 183)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(109, 20)
        Me.TextBox13.TabIndex = 61
        Me.TextBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox14
        '
        Me.TextBox14.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_ReparAvant_InspecteurAnnee", True))
        Me.TextBox14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox14.Location = New System.Drawing.Point(615, 183)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(109, 20)
        Me.TextBox14.TabIndex = 62
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox15
        '
        Me.TextBox15.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_ReparAvant_InspecteurTotal", True))
        Me.TextBox15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox15.Location = New System.Drawing.Point(847, 183)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(111, 20)
        Me.TextBox15.TabIndex = 63
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label6.Location = New System.Drawing.Point(1, 234)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label6, 2)
        Me.Label6.Size = New System.Drawing.Size(462, 53)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "       Pourcentage de pulv�risateurs ""Auto Contr�le"":"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label12.Location = New System.Drawing.Point(1, 288)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label12, 2)
        Me.Label12.Size = New System.Drawing.Size(462, 159)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "       Pourcentage de pulv�risateurs ""Pre Contr�le"" :"
        '
        'TextBox16
        '
        Me.TextBox16.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_ReparAvant_StructureTotal", True))
        Me.TextBox16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox16.Location = New System.Drawing.Point(731, 183)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(109, 20)
        Me.TextBox16.TabIndex = 69
        Me.TextBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox17
        '
        Me.TextBox17.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_AutoControle_StructureAnnee", True))
        Me.TextBox17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox17.Location = New System.Drawing.Point(499, 237)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.Size = New System.Drawing.Size(109, 20)
        Me.TextBox17.TabIndex = 70
        Me.TextBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox18
        '
        Me.TextBox18.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_AutoControle_InspecteurAnnee", True))
        Me.TextBox18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox18.Location = New System.Drawing.Point(615, 237)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.ReadOnly = True
        Me.TextBox18.Size = New System.Drawing.Size(109, 20)
        Me.TextBox18.TabIndex = 71
        Me.TextBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox19
        '
        Me.TextBox19.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_AutoControle_StructureTotal", True))
        Me.TextBox19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox19.Location = New System.Drawing.Point(731, 237)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.ReadOnly = True
        Me.TextBox19.Size = New System.Drawing.Size(109, 20)
        Me.TextBox19.TabIndex = 72
        Me.TextBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox20
        '
        Me.TextBox20.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_AutoControle_InspecteurTotal", True))
        Me.TextBox20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox20.Location = New System.Drawing.Point(847, 237)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.ReadOnly = True
        Me.TextBox20.Size = New System.Drawing.Size(111, 20)
        Me.TextBox20.TabIndex = 73
        Me.TextBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox21
        '
        Me.TextBox21.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_PreControle_StructureAnnee", True))
        Me.TextBox21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox21.Location = New System.Drawing.Point(499, 291)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.ReadOnly = True
        Me.TextBox21.Size = New System.Drawing.Size(109, 20)
        Me.TextBox21.TabIndex = 74
        Me.TextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox22
        '
        Me.TextBox22.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_PreControle_InspecteurAnnee", True))
        Me.TextBox22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox22.Location = New System.Drawing.Point(615, 291)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.ReadOnly = True
        Me.TextBox22.Size = New System.Drawing.Size(109, 20)
        Me.TextBox22.TabIndex = 75
        Me.TextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox23
        '
        Me.TextBox23.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_PreControle_StructureTotal", True))
        Me.TextBox23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox23.Location = New System.Drawing.Point(731, 291)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.ReadOnly = True
        Me.TextBox23.Size = New System.Drawing.Size(109, 20)
        Me.TextBox23.TabIndex = 76
        Me.TextBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox24
        '
        Me.TextBox24.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCC_PreControle_InspecteurTotal", True))
        Me.TextBox24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox24.Location = New System.Drawing.Point(847, 291)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.ReadOnly = True
        Me.TextBox24.Size = New System.Drawing.Size(111, 20)
        Me.TextBox24.TabIndex = 77
        Me.TextBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'laNomStructure2
        '
        Me.laNomStructure2.BackColor = System.Drawing.Color.Transparent
        Me.laNomStructure2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laNomStructure2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laNomStructure2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.laNomStructure2.Location = New System.Drawing.Point(731, 1)
        Me.laNomStructure2.Name = "laNomStructure2"
        Me.laNomStructure2.Size = New System.Drawing.Size(108, 16)
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
        Me.laNomAgent2.Location = New System.Drawing.Point(847, 1)
        Me.laNomAgent2.Name = "laNomAgent2"
        Me.laNomAgent2.Size = New System.Drawing.Size(110, 16)
        Me.laNomAgent2.TabIndex = 79
        Me.laNomAgent2.Text = "inspecteur"
        Me.laNomAgent2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = " "
        '
        'TextBox25
        '
        Me.TextBox25.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox25.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlCVStructureAnnee", True))
        Me.TextBox25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox25.Location = New System.Drawing.Point(499, 48)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.ReadOnly = True
        Me.TextBox25.Size = New System.Drawing.Size(109, 20)
        Me.TextBox25.TabIndex = 86
        Me.TextBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox27
        '
        Me.TextBox27.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox27.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlCVInspecteurAnnee", True))
        Me.TextBox27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox27.Location = New System.Drawing.Point(615, 48)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.ReadOnly = True
        Me.TextBox27.Size = New System.Drawing.Size(109, 20)
        Me.TextBox27.TabIndex = 87
        Me.TextBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox28
        '
        Me.TextBox28.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox28.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlCVStructureTotal", True))
        Me.TextBox28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox28.Location = New System.Drawing.Point(731, 48)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.ReadOnly = True
        Me.TextBox28.Size = New System.Drawing.Size(109, 20)
        Me.TextBox28.TabIndex = 88
        Me.TextBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox29
        '
        Me.TextBox29.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox29.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "NCtrlCVInspecteurTotal", True))
        Me.TextBox29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox29.Location = New System.Drawing.Point(847, 48)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.ReadOnly = True
        Me.TextBox29.Size = New System.Drawing.Size(111, 20)
        Me.TextBox29.TabIndex = 89
        Me.TextBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox30
        '
        Me.TextBox30.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox30.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_OK_StructureAnnee", True))
        Me.TextBox30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox30.Location = New System.Drawing.Point(499, 102)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.ReadOnly = True
        Me.TextBox30.Size = New System.Drawing.Size(109, 20)
        Me.TextBox30.TabIndex = 90
        Me.TextBox30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox31
        '
        Me.TextBox31.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox31.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_OK_InspecteurAnnee", True))
        Me.TextBox31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox31.Location = New System.Drawing.Point(615, 102)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.ReadOnly = True
        Me.TextBox31.Size = New System.Drawing.Size(109, 20)
        Me.TextBox31.TabIndex = 91
        Me.TextBox31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox32
        '
        Me.TextBox32.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox32.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_OK_StructureTotal", True))
        Me.TextBox32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox32.Location = New System.Drawing.Point(731, 102)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.ReadOnly = True
        Me.TextBox32.Size = New System.Drawing.Size(109, 20)
        Me.TextBox32.TabIndex = 92
        Me.TextBox32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox33
        '
        Me.TextBox33.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox33.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_OK_InspecteurTotal", True))
        Me.TextBox33.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox33.Location = New System.Drawing.Point(847, 102)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.ReadOnly = True
        Me.TextBox33.Size = New System.Drawing.Size(111, 20)
        Me.TextBox33.TabIndex = 93
        Me.TextBox33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox34
        '
        Me.TextBox34.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox34.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_CP_StructureAnnee", True))
        Me.TextBox34.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox34.Location = New System.Drawing.Point(499, 156)
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.ReadOnly = True
        Me.TextBox34.Size = New System.Drawing.Size(109, 20)
        Me.TextBox34.TabIndex = 94
        Me.TextBox34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox35
        '
        Me.TextBox35.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox35.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_CP_InspecteurAnnee", True))
        Me.TextBox35.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox35.Location = New System.Drawing.Point(615, 156)
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.ReadOnly = True
        Me.TextBox35.Size = New System.Drawing.Size(109, 20)
        Me.TextBox35.TabIndex = 95
        Me.TextBox35.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox36
        '
        Me.TextBox36.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox36.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_CP_StructureTotal", True))
        Me.TextBox36.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox36.Location = New System.Drawing.Point(731, 156)
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.ReadOnly = True
        Me.TextBox36.Size = New System.Drawing.Size(109, 20)
        Me.TextBox36.TabIndex = 96
        Me.TextBox36.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox37
        '
        Me.TextBox37.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox37.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_CP_InspecteurTotal", True))
        Me.TextBox37.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox37.Location = New System.Drawing.Point(847, 156)
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.ReadOnly = True
        Me.TextBox37.Size = New System.Drawing.Size(111, 20)
        Me.TextBox37.TabIndex = 97
        Me.TextBox37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox38
        '
        Me.TextBox38.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox38.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_ReparAvant_StructureAnnee", True))
        Me.TextBox38.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox38.Location = New System.Drawing.Point(499, 210)
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.ReadOnly = True
        Me.TextBox38.Size = New System.Drawing.Size(109, 20)
        Me.TextBox38.TabIndex = 98
        Me.TextBox38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox39
        '
        Me.TextBox39.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox39.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_ReparAvant_InspecteurAnnee", True))
        Me.TextBox39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox39.Location = New System.Drawing.Point(615, 210)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.ReadOnly = True
        Me.TextBox39.Size = New System.Drawing.Size(109, 20)
        Me.TextBox39.TabIndex = 99
        Me.TextBox39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox40
        '
        Me.TextBox40.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox40.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_ReparAvant_StructureTotal", True))
        Me.TextBox40.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox40.Location = New System.Drawing.Point(731, 210)
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.ReadOnly = True
        Me.TextBox40.Size = New System.Drawing.Size(109, 20)
        Me.TextBox40.TabIndex = 100
        Me.TextBox40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox41
        '
        Me.TextBox41.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox41.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_ReparAvant_InspecteurTotal", True))
        Me.TextBox41.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox41.Location = New System.Drawing.Point(847, 210)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.ReadOnly = True
        Me.TextBox41.Size = New System.Drawing.Size(111, 20)
        Me.TextBox41.TabIndex = 101
        Me.TextBox41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox42
        '
        Me.TextBox42.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox42.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_AutoControle_StructureAnnee", True))
        Me.TextBox42.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox42.Location = New System.Drawing.Point(499, 264)
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.ReadOnly = True
        Me.TextBox42.Size = New System.Drawing.Size(109, 20)
        Me.TextBox42.TabIndex = 102
        Me.TextBox42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox43
        '
        Me.TextBox43.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox43.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_AutoControle_InspecteurAnnee", True))
        Me.TextBox43.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox43.Location = New System.Drawing.Point(615, 264)
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.ReadOnly = True
        Me.TextBox43.Size = New System.Drawing.Size(109, 20)
        Me.TextBox43.TabIndex = 103
        Me.TextBox43.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox44
        '
        Me.TextBox44.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox44.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_AutoControle_StructureTotal", True))
        Me.TextBox44.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox44.Location = New System.Drawing.Point(731, 264)
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.ReadOnly = True
        Me.TextBox44.Size = New System.Drawing.Size(109, 20)
        Me.TextBox44.TabIndex = 104
        Me.TextBox44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox45
        '
        Me.TextBox45.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox45.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_AutoControle_InspecteurTotal", True))
        Me.TextBox45.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox45.Location = New System.Drawing.Point(847, 264)
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.ReadOnly = True
        Me.TextBox45.Size = New System.Drawing.Size(111, 20)
        Me.TextBox45.TabIndex = 105
        Me.TextBox45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox46
        '
        Me.TextBox46.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox46.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_PreControle_StructureAnnee", True))
        Me.TextBox46.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox46.Location = New System.Drawing.Point(499, 318)
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.ReadOnly = True
        Me.TextBox46.Size = New System.Drawing.Size(109, 20)
        Me.TextBox46.TabIndex = 106
        Me.TextBox46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox47
        '
        Me.TextBox47.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox47.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_PreControle_InspecteurAnnee", True))
        Me.TextBox47.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox47.Location = New System.Drawing.Point(615, 318)
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.ReadOnly = True
        Me.TextBox47.Size = New System.Drawing.Size(109, 20)
        Me.TextBox47.TabIndex = 107
        Me.TextBox47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox48
        '
        Me.TextBox48.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox48.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_PreControle_StructureTotal", True))
        Me.TextBox48.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox48.Location = New System.Drawing.Point(731, 318)
        Me.TextBox48.Name = "TextBox48"
        Me.TextBox48.ReadOnly = True
        Me.TextBox48.Size = New System.Drawing.Size(109, 20)
        Me.TextBox48.TabIndex = 108
        Me.TextBox48.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox49
        '
        Me.TextBox49.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox49.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsStatistiques, "PctCtrlCV_PreControle_InspecteurTotal", True))
        Me.TextBox49.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox49.Location = New System.Drawing.Point(847, 318)
        Me.TextBox49.Name = "TextBox49"
        Me.TextBox49.ReadOnly = True
        Me.TextBox49.Size = New System.Drawing.Size(111, 20)
        Me.TextBox49.TabIndex = 109
        Me.TextBox49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(467, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(25, 15)
        Me.Label23.TabIndex = 110
        Me.Label23.Text = "CC"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(467, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(24, 15)
        Me.Label25.TabIndex = 111
        Me.Label25.Text = "CV"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(467, 72)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(25, 15)
        Me.Label27.TabIndex = 112
        Me.Label27.Text = "CC"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(467, 99)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(24, 15)
        Me.Label28.TabIndex = 113
        Me.Label28.Text = "CV"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(467, 126)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(25, 15)
        Me.Label31.TabIndex = 114
        Me.Label31.Text = "CC"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(467, 153)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(24, 15)
        Me.Label32.TabIndex = 115
        Me.Label32.Text = "CV"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(467, 180)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(25, 15)
        Me.Label33.TabIndex = 116
        Me.Label33.Text = "CC"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(467, 207)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(24, 15)
        Me.Label34.TabIndex = 117
        Me.Label34.Text = "CV"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(467, 234)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(25, 15)
        Me.Label35.TabIndex = 118
        Me.Label35.Text = "CC"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(467, 261)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(24, 15)
        Me.Label36.TabIndex = 119
        Me.Label36.Text = "CV"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(467, 288)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(25, 15)
        Me.Label37.TabIndex = 120
        Me.Label37.Text = "CC"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(467, 315)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(24, 15)
        Me.Label38.TabIndex = 121
        Me.Label38.Text = "CV"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.tabControl_Facturation.Controls.Add(Me.btnExportFacture)
        Me.tabControl_Facturation.Controls.Add(Me.btnAjoutFacture)
        Me.tabControl_Facturation.Controls.Add(Me.dgvFactures)
        Me.tabControl_Facturation.Controls.Add(Me.Panel3)
        Me.tabControl_Facturation.Location = New System.Drawing.Point(4, 22)
        Me.tabControl_Facturation.Name = "tabControl_Facturation"
        Me.tabControl_Facturation.Padding = New System.Windows.Forms.Padding(3)
        Me.tabControl_Facturation.Size = New System.Drawing.Size(1009, 653)
        Me.tabControl_Facturation.TabIndex = 7
        Me.tabControl_Facturation.Text = "Facturation"
        '
        'btnExportFacture
        '
        Me.btnExportFacture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportFacture.BackgroundImage = Global.Crodip_agent.Resources.btn_empty_big
        Me.btnExportFacture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExportFacture.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnExportFacture.FlatAppearance.BorderSize = 0
        Me.btnExportFacture.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnExportFacture.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnExportFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportFacture.ForeColor = System.Drawing.Color.White
        Me.btnExportFacture.Location = New System.Drawing.Point(599, 596)
        Me.btnExportFacture.Name = "btnExportFacture"
        Me.btnExportFacture.Size = New System.Drawing.Size(193, 40)
        Me.btnExportFacture.TabIndex = 36
        Me.btnExportFacture.Text = "Export CSV"
        Me.btnExportFacture.UseVisualStyleBackColor = True
        '
        'btnAjoutFacture
        '
        Me.btnAjoutFacture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAjoutFacture.BackgroundImage = Global.Crodip_agent.Resources.btn_divers_add
        Me.btnAjoutFacture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAjoutFacture.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAjoutFacture.FlatAppearance.BorderSize = 0
        Me.btnAjoutFacture.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAjoutFacture.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAjoutFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjoutFacture.ForeColor = System.Drawing.Color.White
        Me.btnAjoutFacture.Location = New System.Drawing.Point(808, 596)
        Me.btnAjoutFacture.Name = "btnAjoutFacture"
        Me.btnAjoutFacture.Size = New System.Drawing.Size(193, 40)
        Me.btnAjoutFacture.TabIndex = 35
        Me.btnAjoutFacture.Text = "Ajout Facture"
        Me.btnAjoutFacture.UseVisualStyleBackColor = True
        '
        'dgvFactures
        '
        Me.dgvFactures.AllowUserToAddRows = False
        Me.dgvFactures.AllowUserToDeleteRows = False
        Me.dgvFactures.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFactures.AutoGenerateColumns = False
        Me.dgvFactures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFactures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFactures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdFactureDataGridViewTextBoxColumn, Me.DateFactureDataGridViewTextBoxColumn, Me.ClientColumn, Me.IdDiagDataGridViewTextBoxColumn, Me.TotalHTDataGridViewTextBoxColumn, Me.TotalTTCDataGridViewTextBoxColumn, Me.IsRegleeDataGridViewCheckBoxColumn, Me.PDFColumn})
        Me.dgvFactures.DataSource = Me.m_bsFacture
        Me.dgvFactures.Location = New System.Drawing.Point(15, 78)
        Me.dgvFactures.Name = "dgvFactures"
        Me.dgvFactures.ReadOnly = True
        Me.dgvFactures.Size = New System.Drawing.Size(986, 512)
        Me.dgvFactures.TabIndex = 34
        '
        'IdFactureDataGridViewTextBoxColumn
        '
        Me.IdFactureDataGridViewTextBoxColumn.DataPropertyName = "idFacture"
        Me.IdFactureDataGridViewTextBoxColumn.FillWeight = 83.18756!
        Me.IdFactureDataGridViewTextBoxColumn.HeaderText = "Facture"
        Me.IdFactureDataGridViewTextBoxColumn.Name = "IdFactureDataGridViewTextBoxColumn"
        Me.IdFactureDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateFactureDataGridViewTextBoxColumn
        '
        Me.DateFactureDataGridViewTextBoxColumn.DataPropertyName = "dateFacture"
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DateFactureDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.DateFactureDataGridViewTextBoxColumn.FillWeight = 83.18756!
        Me.DateFactureDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateFactureDataGridViewTextBoxColumn.Name = "DateFactureDataGridViewTextBoxColumn"
        Me.DateFactureDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ClientColumn
        '
        Me.ClientColumn.DataPropertyName = "RaisonSocialeExploitant"
        Me.ClientColumn.FillWeight = 83.18756!
        Me.ClientColumn.HeaderText = "Client"
        Me.ClientColumn.Name = "ClientColumn"
        Me.ClientColumn.ReadOnly = True
        '
        'IdDiagDataGridViewTextBoxColumn
        '
        Me.IdDiagDataGridViewTextBoxColumn.DataPropertyName = "idDiag"
        Me.IdDiagDataGridViewTextBoxColumn.FillWeight = 83.18756!
        Me.IdDiagDataGridViewTextBoxColumn.HeaderText = "Controle"
        Me.IdDiagDataGridViewTextBoxColumn.Name = "IdDiagDataGridViewTextBoxColumn"
        Me.IdDiagDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TotalHTDataGridViewTextBoxColumn
        '
        Me.TotalHTDataGridViewTextBoxColumn.DataPropertyName = "TotalHT"
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.TotalHTDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.TotalHTDataGridViewTextBoxColumn.FillWeight = 83.18756!
        Me.TotalHTDataGridViewTextBoxColumn.HeaderText = "Total HT"
        Me.TotalHTDataGridViewTextBoxColumn.Name = "TotalHTDataGridViewTextBoxColumn"
        Me.TotalHTDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TotalTTCDataGridViewTextBoxColumn
        '
        Me.TotalTTCDataGridViewTextBoxColumn.DataPropertyName = "TotalTTC"
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TotalTTCDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.TotalTTCDataGridViewTextBoxColumn.FillWeight = 83.18756!
        Me.TotalTTCDataGridViewTextBoxColumn.HeaderText = "Total TTC"
        Me.TotalTTCDataGridViewTextBoxColumn.Name = "TotalTTCDataGridViewTextBoxColumn"
        Me.TotalTTCDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IsRegleeDataGridViewCheckBoxColumn
        '
        Me.IsRegleeDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IsRegleeDataGridViewCheckBoxColumn.DataPropertyName = "isReglee"
        Me.IsRegleeDataGridViewCheckBoxColumn.HeaderText = "Regl�e"
        Me.IsRegleeDataGridViewCheckBoxColumn.Name = "IsRegleeDataGridViewCheckBoxColumn"
        Me.IsRegleeDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsRegleeDataGridViewCheckBoxColumn.Width = 50
        '
        'PDFColumn
        '
        Me.PDFColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PDFColumn.FillWeight = 217.6871!
        Me.PDFColumn.HeaderText = "PDF"
        Me.PDFColumn.Image = Global.Crodip_agent.Resources.PDF
        Me.PDFColumn.Name = "PDFColumn"
        Me.PDFColumn.ReadOnly = True
        Me.PDFColumn.Width = 40
        '
        'm_bsFacture
        '
        Me.m_bsFacture.DataSource = GetType(CRODIPWS.Facture)
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.btnRechercher)
        Me.Panel3.Controls.Add(Me.dtpDeb)
        Me.Panel3.Controls.Add(Me.tbNomClient)
        Me.Panel3.Controls.Add(Me.rbNomClient)
        Me.Panel3.Controls.Add(Me.tbNumFact)
        Me.Panel3.Controls.Add(Me.rbNumFact)
        Me.Panel3.Controls.Add(Me.dtpFin)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.rbDatesFacture)
        Me.Panel3.Location = New System.Drawing.Point(15, 11)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(986, 60)
        Me.Panel3.TabIndex = 33
        '
        'btnRechercher
        '
        Me.btnRechercher.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRechercher.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnRechercher.BackgroundImage = Global.Crodip_agent.Resources.btn_search
        Me.btnRechercher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRechercher.FlatAppearance.BorderSize = 0
        Me.btnRechercher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRechercher.ForeColor = System.Drawing.Color.White
        Me.btnRechercher.Location = New System.Drawing.Point(825, 4)
        Me.btnRechercher.Name = "btnRechercher"
        Me.btnRechercher.Size = New System.Drawing.Size(138, 34)
        Me.btnRechercher.TabIndex = 9
        Me.btnRechercher.Text = "Rechercher"
        Me.btnRechercher.UseVisualStyleBackColor = False
        '
        'dtpDeb
        '
        Me.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeb.Location = New System.Drawing.Point(424, 3)
        Me.dtpDeb.Name = "dtpDeb"
        Me.dtpDeb.Size = New System.Drawing.Size(96, 20)
        Me.dtpDeb.TabIndex = 8
        '
        'tbNomClient
        '
        Me.tbNomClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNomClient.Location = New System.Drawing.Point(668, 6)
        Me.tbNomClient.Name = "tbNomClient"
        Me.tbNomClient.Size = New System.Drawing.Size(109, 20)
        Me.tbNomClient.TabIndex = 7
        '
        'rbNomClient
        '
        Me.rbNomClient.AutoSize = True
        Me.rbNomClient.Location = New System.Drawing.Point(557, 7)
        Me.rbNomClient.Name = "rbNomClient"
        Me.rbNomClient.Size = New System.Drawing.Size(96, 17)
        Me.rbNomClient.TabIndex = 6
        Me.rbNomClient.Text = "Nom du client :"
        Me.rbNomClient.UseVisualStyleBackColor = True
        '
        'tbNumFact
        '
        Me.tbNumFact.Location = New System.Drawing.Point(134, 5)
        Me.tbNumFact.Name = "tbNumFact"
        Me.tbNumFact.Size = New System.Drawing.Size(100, 20)
        Me.tbNumFact.TabIndex = 5
        '
        'rbNumFact
        '
        Me.rbNumFact.AutoSize = True
        Me.rbNumFact.Checked = True
        Me.rbNumFact.Location = New System.Drawing.Point(8, 5)
        Me.rbNumFact.Name = "rbNumFact"
        Me.rbNumFact.Size = New System.Drawing.Size(119, 17)
        Me.rbNumFact.TabIndex = 4
        Me.rbNumFact.TabStop = True
        Me.rbNumFact.Text = "Num�ro de facture :"
        Me.rbNumFact.UseVisualStyleBackColor = True
        '
        'dtpFin
        '
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(424, 29)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(96, 20)
        Me.dtpFin.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(376, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "et le "
        '
        'rbDatesFacture
        '
        Me.rbDatesFacture.AutoSize = True
        Me.rbDatesFacture.Location = New System.Drawing.Point(271, 5)
        Me.rbDatesFacture.Name = "rbDatesFacture"
        Me.rbDatesFacture.Size = New System.Drawing.Size(147, 17)
        Me.rbDatesFacture.TabIndex = 0
        Me.rbDatesFacture.Text = "Date de facture : Entre le "
        Me.rbDatesFacture.UseVisualStyleBackColor = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        '
        'IdStructureDataGridViewTextBoxColumn
        '
        Me.IdStructureDataGridViewTextBoxColumn.DataPropertyName = "idStructure"
        Me.IdStructureDataGridViewTextBoxColumn.HeaderText = "idStructure"
        Me.IdStructureDataGridViewTextBoxColumn.Name = "IdStructureDataGridViewTextBoxColumn"
        '
        'UidstructureSDataGridViewTextBoxColumn
        '
        Me.UidstructureSDataGridViewTextBoxColumn.DataPropertyName = "uidstructureS"
        Me.UidstructureSDataGridViewTextBoxColumn.HeaderText = "uidstructureS"
        Me.UidstructureSDataGridViewTextBoxColumn.Name = "UidstructureSDataGridViewTextBoxColumn"
        '
        'UidstructureDataGridViewTextBoxColumn
        '
        Me.UidstructureDataGridViewTextBoxColumn.DataPropertyName = "uidstructure"
        Me.UidstructureDataGridViewTextBoxColumn.HeaderText = "uidstructure"
        Me.UidstructureDataGridViewTextBoxColumn.Name = "UidstructureDataGridViewTextBoxColumn"
        '
        'NumAgentDataGridViewTextBoxColumn
        '
        Me.NumAgentDataGridViewTextBoxColumn.DataPropertyName = "numAgent"
        Me.NumAgentDataGridViewTextBoxColumn.HeaderText = "numAgent"
        Me.NumAgentDataGridViewTextBoxColumn.Name = "NumAgentDataGridViewTextBoxColumn"
        '
        'AidagentDataGridViewTextBoxColumn
        '
        Me.AidagentDataGridViewTextBoxColumn.DataPropertyName = "aidagent"
        Me.AidagentDataGridViewTextBoxColumn.HeaderText = "aidagent"
        Me.AidagentDataGridViewTextBoxColumn.Name = "AidagentDataGridViewTextBoxColumn"
        '
        'UidagentSDataGridViewTextBoxColumn
        '
        Me.UidagentSDataGridViewTextBoxColumn.DataPropertyName = "uidagentS"
        Me.UidagentSDataGridViewTextBoxColumn.HeaderText = "uidagentS"
        Me.UidagentSDataGridViewTextBoxColumn.Name = "UidagentSDataGridViewTextBoxColumn"
        '
        'UidagentDataGridViewTextBoxColumn
        '
        Me.UidagentDataGridViewTextBoxColumn.DataPropertyName = "uidagent"
        Me.UidagentDataGridViewTextBoxColumn.HeaderText = "uidagent"
        Me.UidagentDataGridViewTextBoxColumn.Name = "UidagentDataGridViewTextBoxColumn"
        '
        'TypeDataGridViewTextBoxColumn
        '
        Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "type"
        Me.TypeDataGridViewTextBoxColumn.HeaderText = "type"
        Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
        '
        'TypeLibelleDataGridViewTextBoxColumn
        '
        Me.TypeLibelleDataGridViewTextBoxColumn.DataPropertyName = "typeLibelle"
        Me.TypeLibelleDataGridViewTextBoxColumn.HeaderText = "typeLibelle"
        Me.TypeLibelleDataGridViewTextBoxColumn.Name = "TypeLibelleDataGridViewTextBoxColumn"
        Me.TypeLibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdMaterielDataGridViewTextBoxColumn
        '
        Me.IdMaterielDataGridViewTextBoxColumn.DataPropertyName = "idMateriel"
        Me.IdMaterielDataGridViewTextBoxColumn.HeaderText = "idMateriel"
        Me.IdMaterielDataGridViewTextBoxColumn.Name = "IdMaterielDataGridViewTextBoxColumn"
        '
        'UidmaterielDataGridViewTextBoxColumn
        '
        Me.UidmaterielDataGridViewTextBoxColumn.DataPropertyName = "uidmateriel"
        Me.UidmaterielDataGridViewTextBoxColumn.HeaderText = "uidmateriel"
        Me.UidmaterielDataGridViewTextBoxColumn.Name = "UidmaterielDataGridViewTextBoxColumn"
        '
        'UidmaterielSDataGridViewTextBoxColumn
        '
        Me.UidmaterielSDataGridViewTextBoxColumn.DataPropertyName = "uidmaterielS"
        Me.UidmaterielSDataGridViewTextBoxColumn.HeaderText = "uidmaterielS"
        Me.UidmaterielSDataGridViewTextBoxColumn.Name = "UidmaterielSDataGridViewTextBoxColumn"
        '
        'DateControleSDataGridViewTextBoxColumn
        '
        Me.DateControleSDataGridViewTextBoxColumn.DataPropertyName = "dateControleS"
        Me.DateControleSDataGridViewTextBoxColumn.HeaderText = "dateControleS"
        Me.DateControleSDataGridViewTextBoxColumn.Name = "DateControleSDataGridViewTextBoxColumn"
        '
        'DateControleDataGridViewTextBoxColumn
        '
        Me.DateControleDataGridViewTextBoxColumn.DataPropertyName = "dateControle"
        Me.DateControleDataGridViewTextBoxColumn.HeaderText = "dateControle"
        Me.DateControleDataGridViewTextBoxColumn.Name = "DateControleDataGridViewTextBoxColumn"
        '
        'EtatDataGridViewTextBoxColumn
        '
        Me.EtatDataGridViewTextBoxColumn.DataPropertyName = "etat"
        Me.EtatDataGridViewTextBoxColumn.HeaderText = "etat"
        Me.EtatDataGridViewTextBoxColumn.Name = "EtatDataGridViewTextBoxColumn"
        '
        'IsOKDataGridViewCheckBoxColumn
        '
        Me.IsOKDataGridViewCheckBoxColumn.DataPropertyName = "isOK"
        Me.IsOKDataGridViewCheckBoxColumn.HeaderText = "isOK"
        Me.IsOKDataGridViewCheckBoxColumn.Name = "IsOKDataGridViewCheckBoxColumn"
        '
        'IsNOKDataGridViewCheckBoxColumn
        '
        Me.IsNOKDataGridViewCheckBoxColumn.DataPropertyName = "isNOK"
        Me.IsNOKDataGridViewCheckBoxColumn.HeaderText = "isNOK"
        Me.IsNOKDataGridViewCheckBoxColumn.Name = "IsNOKDataGridViewCheckBoxColumn"
        '
        'IsNonEffectueDataGridViewCheckBoxColumn
        '
        Me.IsNonEffectueDataGridViewCheckBoxColumn.DataPropertyName = "isNonEffectue"
        Me.IsNonEffectueDataGridViewCheckBoxColumn.HeaderText = "isNonEffectue"
        Me.IsNonEffectueDataGridViewCheckBoxColumn.Name = "IsNonEffectueDataGridViewCheckBoxColumn"
        '
        'TracaDataGridViewTextBoxColumn
        '
        Me.TracaDataGridViewTextBoxColumn.DataPropertyName = "traca"
        Me.TracaDataGridViewTextBoxColumn.HeaderText = "traca"
        Me.TracaDataGridViewTextBoxColumn.Name = "TracaDataGridViewTextBoxColumn"
        '
        'NumeroNationalDataGridViewTextBoxColumn1
        '
        Me.NumeroNationalDataGridViewTextBoxColumn1.DataPropertyName = "numeroNational"
        Me.NumeroNationalDataGridViewTextBoxColumn1.HeaderText = "numeroNational"
        Me.NumeroNationalDataGridViewTextBoxColumn1.Name = "NumeroNationalDataGridViewTextBoxColumn1"
        '
        'UidDataGridViewTextBoxColumn
        '
        Me.UidDataGridViewTextBoxColumn.DataPropertyName = "uid"
        Me.UidDataGridViewTextBoxColumn.HeaderText = "uid"
        Me.UidDataGridViewTextBoxColumn.Name = "UidDataGridViewTextBoxColumn"
        '
        'AidDataGridViewTextBoxColumn
        '
        Me.AidDataGridViewTextBoxColumn.DataPropertyName = "aid"
        Me.AidDataGridViewTextBoxColumn.HeaderText = "aid"
        Me.AidDataGridViewTextBoxColumn.Name = "AidDataGridViewTextBoxColumn"
        '
        'DateModificationAgentDataGridViewTextBoxColumn
        '
        Me.DateModificationAgentDataGridViewTextBoxColumn.DataPropertyName = "dateModificationAgent"
        Me.DateModificationAgentDataGridViewTextBoxColumn.HeaderText = "dateModificationAgent"
        Me.DateModificationAgentDataGridViewTextBoxColumn.Name = "DateModificationAgentDataGridViewTextBoxColumn"
        '
        'DateModificationAgentSDataGridViewTextBoxColumn
        '
        Me.DateModificationAgentSDataGridViewTextBoxColumn.DataPropertyName = "dateModificationAgentS"
        Me.DateModificationAgentSDataGridViewTextBoxColumn.HeaderText = "dateModificationAgentS"
        Me.DateModificationAgentSDataGridViewTextBoxColumn.Name = "DateModificationAgentSDataGridViewTextBoxColumn"
        '
        'DateModificationCrodipDataGridViewTextBoxColumn
        '
        Me.DateModificationCrodipDataGridViewTextBoxColumn.DataPropertyName = "dateModificationCrodip"
        Me.DateModificationCrodipDataGridViewTextBoxColumn.HeaderText = "dateModificationCrodip"
        Me.DateModificationCrodipDataGridViewTextBoxColumn.Name = "DateModificationCrodipDataGridViewTextBoxColumn"
        '
        'DateModificationCrodipSDataGridViewTextBoxColumn
        '
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.DataPropertyName = "dateModificationCrodipS"
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.HeaderText = "dateModificationCrodipS"
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.Name = "DateModificationCrodipSDataGridViewTextBoxColumn"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(363, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(197, 16)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Pool utilis� :"
        '
        'lblPool
        '
        Me.lblPool.Location = New System.Drawing.Point(576, 104)
        Me.lblPool.Name = "lblPool"
        Me.lblPool.Size = New System.Drawing.Size(151, 16)
        Me.lblPool.TabIndex = 12
        Me.lblPool.Text = "Pool_libell�"
        '
        'accueil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(1017, 679)
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.dgvFactures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsFacture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
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
    'Public Sub SetContexte(pidAgent As Integer)
    '    IDAgent = pidAgent
    '    CSDebug.dispInfo("Accueil.SetContexte IdAgent = " & IDAgent)
    '    agentCourant = AgentManager.getAgentById(IDAgent)
    'End Sub
    ' Chargement form
    Private Sub accueil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

            If Not Directory.Exists(GlobalsCRODIP.CONST_STOCK_PDFS) Then
                Dim oDI As New DirectoryInfo(GlobalsCRODIP.CONST_STOCK_PDFS)
                oDI.Create()
                oDI.Attributes = FileAttributes.Hidden

                oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE)
                oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE)
                oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)

                'Transfert des fichiers depuis le publicExport dans le dossier Cach�
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
        Catch ex As Exception

        End Try




        ' Informations sur l'agent courant
        m_bDuringLoad = True
        lbl_infosAgent_IdCrodip.Text = agentCourant.numeroNational
        lbl_infosAgent_Nom.Text = agentCourant.nom
        lbl_infosAgent_Prenom.Text = agentCourant.prenom
        lbl_infosAgent_dateDernCnx.Text = CSDate.ToCRODIPString(agentCourant.dateDerniereConnexion)
        Dim dateDernSynhcro As String = CSDate.ToCRODIPString(agentCourant.dateDerniereSynchro)
        If CSDate.FromCrodipString(dateDernSynhcro) = CSDate.FromCrodipString("01/01/1970 00:00:00") Or dateDernSynhcro = "" Or dateDernSynhcro = "00/00/0000 00:00:00" Then
            lbl_infosAgent_dateDernSynchro.Text = "--/--/-- --:--:--"
        Else
            lbl_infosAgent_dateDernSynchro.Text = dateDernSynhcro
        End If
        If agentCourant.oPool IsNot Nothing Then
            lblPool.Text = agentCourant.oPool.libelle
        End If
        'Affichage de la Liste des clients avec les alertes
        m_Exploitation_isShowAll = False
        btn_proprietaire_derniersControles_setLabel()

        'Param�trage de la synhchro (Affichage uniquement en mode debug)
        grpParamSynhcro.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG

        ' Affichage des crit�res de tri
        pnl_SearchDates.Top = client_search_query.Top
        pnl_SearchDates.Left = client_search_query.Left
        list_search_fieldSearch.Items.Clear()
        Dim objComboItem_Tous As New objComboItem("0", "Tous")
        Dim objComboItem_SIREN As New objComboItem("1", "N� SIREN")
        Dim objComboItem_RS As New objComboItem("2", "Raison Sociale")
        Dim objComboItem_Prenom As New objComboItem("3", "Pr�nom")
        Dim objComboItem_Nom As New objComboItem("4", "Nom")
        Dim objComboItem_DateC As New objComboItem("5", "Date de controle")
        Dim objComboItem_Pulve As New objComboItem("6", "Numero Pulverisateur")
        Dim objComboItem_ID As New objComboItem("7", "Num�ro Controle")
        Dim objComboItem_Commune As New objComboItem("8", "Commune")
        Dim objComboItem_CodePostal As New objComboItem("9", "Code postal")

        If Not agentCourant.isGestionnaire Then
            'Les donn�es ont d�j� �t� Charg�e par la page de login
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
            list_search_fieldSearch.Items.Add(objComboItem_Commune)
            list_search_fieldSearch.Items.Add(objComboItem_CodePostal)


            btnParamModeSimplifie.Visible = False
            btnMAJsynchroAgent.Visible = False

            panel_clientele_ficheClient.Visible = False
            panel_ListeDesControles.Visible = True
            panel_ListeDesControles.Dock = DockStyle.Fill

        Else
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
            tabControl.TabPages.RemoveByKey(tabControl_Facturation.Name)
        End If

        'Gestion du Mode Simplifi�
        'Module Documentaire
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
            'on ne peut rendre invisible ou inactive une page, il faut la supprimer de la tabPages
            tabControl.TabPages.RemoveByKey(tabControl_outilscomp.Name)
            tabControl.TabPages.RemoveByKey(tabControl_Facturation.Name)
        End If
        If GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            'on ne peut rendre invisible ou inactive une page, il faut la supprimer de la tabPages
            tabControl.TabPages.RemoveByKey(tabControl_accueil.Name)
            tabControl.TabPages.RemoveByKey(tabControl_pulverisateurs.Name)
            tabControl.TabPages.RemoveByKey(tabControl_synchro.Name)
            tabControl.TabPages.RemoveByKey(tabControl_parametrage.Name)
            tabControl.TabPages.RemoveByKey(tabControl_Statistiques.Name)
            tabControl.TabPages.RemoveByKey(tabControl_Facturation.Name)
        End If
        Dim oStructure As [Structure]
        oStructure = StructureManager.getStructureById(agentCourant.idStructure)
        If Not oStructure.isFacturationActive Then
            tabControl.TabPages.RemoveByKey(tabControl_Facturation.Name)
            tabControl.TabPages.RemoveByKey(tabControl_Facturation.Name)
        End If
        '        tabControl_outilscomp.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        pctbx_Docs_refresh.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        lblModuledocumentaire.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        SplitContainer_ModuleDocumentaire.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        btn_imprimerDoc.Visible = Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE
        'Param�trage
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

        If Not GlobalsCRODIP.GLOB_NETWORKAVAILABLE Then
            btn_parametrage_verificationManometres.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Iniitalization de la la f�n�tre
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Init(pIdAgent As Integer)
        IDAgent = pIdAgent
        agentCourant = AgentManager.getAgentById(pIdAgent)
        ' Affichage des alertes
        Me.Text = agentCourant.nom & " " & agentCourant.prenom & " / " & agentCourant.NomStructure
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
            Me.Text = Me.Text & " - Mode Simplifi� - "
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
        ' R�cup�ration de la liste des clients
        '**************************
        Dim oCol As List(Of Exploitation)
        'r�cup�ration de la liste des clients
        oCol = ExploitationManager.getListeExploitation(agentCourant, DateTime.Now)

        AfficheListeExploitation(pisAlerte, oCol)

        Statusbar.display(statusbarOldMessage, False)
    End Sub

    Private Sub AfficheListeExploitation(ByVal pisAlerte As Boolean, ByVal pColExploit As List(Of Exploitation))
        ' On r�cup�re la liste des profils locaux
        Dim intCount As Decimal = 0
        Dim oExploit As Exploitation
        'M�morisation des elements S�lectionn�
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
            '   Qui ont un pulv� en alerte (date de prochain controle < aujourd'hui)


            If (pisAlerte And (oExploit.nPulvesAlerte = 0 And oExploit.dateDernierControle <> "")) Then
                'On n'affiche pas ces exploitations
            Else
                If Not oExploit.isSupprime Then
                    Dim oItem As ListViewItem
                    oItem = list_clients.Items.Add("")

                    InitLVItem(oItem, oExploit)

                    'S�lection des Items Pr�c�dement Selectionn�s
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
            oItem.SubItems.Add(oExploit.prenomExploitant) ' Pr�nom
            oItem.SubItems.Add(oExploit.nomExploitant) ' Nom
            oItem.SubItems.Add(oExploit.adresse) ' Adresse
            oItem.SubItems.Add(oExploit.codePostal) ' Code postal
            oItem.SubItems.Add(oExploit.commune) ' Commune
            If oExploit.dateProchainControle <> "" And oExploit.dateProchainControle <> "2001-01-01 00:00:00" And oExploit.dateProchainControle <> "1899-12-30 00:00:00" Then
                Dim tmpDateNextDiag As Date = oExploit.dateProchainControle
                oItem.SubItems.Add(tmpDateNextDiag.ToShortDateString)  ' Prochain controle
            Else
                oItem.SubItems.Add("")  ' Pas de prochain  contr�le
            End If
            ' D�tection des alertes
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
    ''' Chargement de la liste des pulv� d'un client en fonction des droits de l'agent
    ''' </summary>
    ''' <param name="isAlerte"></param>
    ''' <remarks></remarks>
    Public Sub loadListPulveExploitation(ByVal isAlerte As Boolean)
        ' On r�cup�re le client s�lectionn�

        panel_clientele_LstCtrlCtriteres.Visible = False
        panel_ListeDesControles.Visible = False
        panel_clientele_ficheClient.Visible = True
        panel_clientele_ficheClient.Dock = DockStyle.Fill

        ' On v�rifie qu'il y a bien une ligne de s�lectionn�e
        If list_clients.SelectedItems().Count > 0 Then
            ' Mise � jour de la barre de status
            Statusbar.display("Chargement des pulv�risateurs du  client n�" & list_clients.SelectedItems().Item(0).SubItems.Item(0).Text)

            ' R�cup�ration des donn�es client
            clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)

            ' Affichage des pulv�risateurs du client 
            AfficheListePulvesExploitation(clientCourant)

            ' Mise � jour de la barre de status
            Statusbar.display("Client n�" & list_clients.SelectedItems().Item(0).SubItems.Item(0).Text)
        Else
            ' Mise � jour de la barre de status
            Statusbar.display("Client inconnu.")
        End If
    End Sub
    Public Sub RefreshLVIExploitation(pIdExploit As String)
        Debug.Assert(Not String.IsNullOrEmpty(pIdExploit), "IdExploit doit �tre renseign�")
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
        Debug.Assert(Not String.IsNullOrEmpty(pIdExploit), "IdExploi doit �tre renseign�")
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
            lstPulves_client_proprioSiren.Text = "M. " & pExploit.nomExploitant & " " & pExploit.prenomExploitant & " - N� SIREN : " & pExploit.numeroSiren
            btn_ficheClient_diagnostic_nouveau.Enabled = False
            btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
            btn_ficheClient_diagnostic_voir.Enabled = False

            laAjoutPulveAdditionnel.Enabled = False


            'list_ficheClient_puverisateur.Items.Clear()
            Dim lstPulverisateurs As New List(Of Pulverisateur)
            lstPulverisateurs.AddRange(PulverisateurManager.getPulverisateurByClientId(pExploit.id, ""))
            'JE Recr�� la liste sotable des pulv�s (je ne sais pas pourquoi je dois la recrer)
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
            Statusbar.display("Chargement de la liste des pulv�risateurs...", True)

            ' On r�cup�re la liste des pulv�s
            Dim arrPulverisateurs As List(Of Pulverisateur) = PulverisateurManager.getPulverisateurList(agentCourant, "")
            '
            Dim tmpPulverisateur As Pulverisateur
            listPulverisateurs.Items.Clear()
            For Each tmpPulverisateur In arrPulverisateurs
                Try
                    Dim olvItem As ListViewItem = New ListViewItem  ' num natio
                    affichePulvedansListePulve(olvItem, tmpPulverisateur)
                    listPulverisateurs.Items.Add(olvItem)
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
    ''' Affiche d'un pulv� dans la liste des pulv�
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
        pLvItem.SubItems.Add(Trim(pPulverisateur.PrenomExploitant.ToString)) ' Pr�nom
        pLvItem.SubItems.Add(Trim(pPulverisateur.NomExploitant.ToString)) ' Nom
        pLvItem.SubItems.Add(Trim(pPulverisateur.codePostal.ToString)) ' Code postal
        pLvItem.SubItems.Add(Trim(pPulverisateur.Commune.ToString)) ' Commune
        If String.IsNullOrEmpty(pPulverisateur.dateProchainControle) Then
            pLvItem.SubItems.Add("") ' prochain contr�le
        Else
            If pPulverisateur.dateProchainControle.ToString <> "" And
                pPulverisateur.dateProchainControle.ToString <> "00:00:00" And
                pPulverisateur.dateProchainControle.ToString <> "1899-12-30 00:00:00" Then
                Dim tmpDateNextDiag As Date = CSDate.FromCrodipString(pPulverisateur.dateProchainControle)
                pLvItem.SubItems.Add(tmpDateNextDiag.ToShortDateString) 'prochain contr�le
            Else
                pLvItem.SubItems.Add("") ' prochain contr�le
            End If
        End If

        ' Conclusion du dernier Diag sur le pulv�
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
            Case Else
                pLvItem.SubItems.Add("")
        End Select

    End Sub
    ' Fonction permettant de r�cup�rer la liste des alertes sur les pulv�s du client s�lectionn�
    'Function getClientPulveAlerts(ByVal idClient As String)

    '    ' R�cup�ration des pulv�risateur du client 
    '    Dim arrPulverisateurs() As Pulverisateur
    '    Try
    '        Dim tmpPulverisateur As Pulverisateur
    '        Dim intCount As Decimal = 0
    '        list_ficheClient_puverisateur.Items.Clear()
    '        Dim arrPulve As Pulverisateur()
    '        arrPulve = PulverisateurManager.getPulverisateurByClientId(idClient, "")
    '        For Each tmpPulverisateur In arrPulve
    '            ' D�tection des alertes
    '            If tmpPulverisateur.isAlerte Then
    '                list_ficheClient_puverisateur.Items(CInt(intCount)).BackColor = System.Drawing.Color.LightBlue
    '                list_ficheClient_puverisateur.Items(CInt(intCount)).ForeColor = System.Drawing.Color.Black
    '                intCount = intCount + 1
    '            End If
    '        Next
    '    Catch ex As Exception
    '        CSDebug.dispError("Client - liste alertes pulv� : " & ex.Message.ToString)
    '    End Try

    'End Function
    Private Sub loadAccueilAlertsManoEtalon(ByRef positionTopAlertes As Integer)
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_MANOETALON_LOAD, True)
        'Chargement de tous les manos
        Dim lstMano As List(Of ManometreEtalon) = ManometreEtalonManager.getlstByAgent(agentCourant, True) _
                                                                    .Where(Function(M)
                                                                               Try
                                                                                   Return M.fondEchelle >= 6 And M.fondEchelle <= 10
                                                                               Catch ex As Exception
                                                                                   Return False
                                                                               End Try
                                                                           End Function).ToList()
        loadAccueilAlertsManoEtalon(lstMano, "[6-10] bar", positionTopAlertes)

        lstMano = ManometreEtalonManager.getlstByAgent(agentCourant, True).Where(Function(M)
                                                                                     Try
                                                                                         Return M.fondEchelle >= 20 And M.fondEchelle <= 25
                                                                                     Catch ex As Exception
                                                                                         Return False
                                                                                     End Try
                                                                                 End Function).ToList()
        loadAccueilAlertsManoEtalon(lstMano, "[20-25] bar", positionTopAlertes)

        lstMano = ManometreEtalonManager.getlstByAgent(agentCourant, True).Where(Function(M)
                                                                                     Try
                                                                                         Return Not ((M.fondEchelle >= 6 And M.fondEchelle <= 10) Or (M.fondEchelle >= 20 And M.fondEchelle <= 25))
                                                                                     Catch ex As Exception
                                                                                         Return True
                                                                                     End Try
                                                                                 End Function).ToList()
        loadAccueilAlertsManoEtalon(lstMano, "diverses", positionTopAlertes)


    End Sub

    Private Sub loadAccueilAlertsManoEtalon(pLstMano As List(Of ManometreEtalon), pClasse As String, ByRef positionTopAlertes As Integer)

        ' V�rification des alertes sur les manom�tre de contr�le
        Dim nbAlertes_Manometre_Orange As Integer = 0
        Dim nbAlertes_Manometre_Rouge As Integer = 0
        Dim nbAlertes_Manometre_Noire As Integer = 0
        Dim nbAlertes_Controle As Integer = 0



        'Chargement de tous les manos
        Dim njours As Integer
        Dim nbManoOrange(3000) As Integer 'Nombre de manom�tres devant �tre controler njours avant la Date Limite
        'Parcours de manos
        Dim AlerteMano As GlobalsCRODIP.ALERTE
        For Each tmpManoControle As ManometreEtalon In pLstMano
            AlerteMano = tmpManoControle.getAlerte()

            If AlerteMano = GlobalsCRODIP.ALERTE.CONTROLE Then ' Defaillant
                nbAlertes_Controle = nbAlertes_Controle + 1
            End If

            If AlerteMano = GlobalsCRODIP.ALERTE.NOIRE Then ' 1mois7jrs
                nbAlertes_Manometre_Noire = nbAlertes_Manometre_Noire + 1
                If tmpManoControle.etat = True Then
                    If My.Settings.DesacMat Then
                        '                        tmpManoControle.Desactiver(agentCourant)
                    End If
                End If
            End If

            If AlerteMano = GlobalsCRODIP.ALERTE.ROUGE Then ' 1mois
                nbAlertes_Manometre_Rouge = nbAlertes_Manometre_Rouge + 1
            End If
            If AlerteMano = GlobalsCRODIP.ALERTE.ORANGE Then '15 jours
                nbAlertes_Manometre_Orange = nbAlertes_Manometre_Orange + 1
                njours = tmpManoControle.getNbJoursAvantAlerteRouge()
                If njours < nbManoOrange.Length Then
                    nbManoOrange(Math.Abs(njours)) = nbManoOrange(Math.Abs(njours)) + 1
                End If
            End If
        Next

        'Affichage des alertes 
        Dim sName As String
        Dim sTexte As String
        If nbAlertes_Manometre_Orange > 0 Then
            For n As Integer = nbManoOrange.Length To 1 Step -1
                sName = "alerteManoEtalon_" & n & "jr"
                If nbManoOrange(n - 1) > 0 Then
                    'Si on a des Manos � controler avant n jours
                    If nbManoOrange(n - 1) > 1 Then
                        sTexte = "Attention, vous avez " & nbManoOrange(n - 1) & " manom�tres �talons de classe " & pClasse & " devant �tre v�rifi�s dans " & (n - 1) & " jours !"
                    Else
                        sTexte = "Attention, vous avez 1 manom�tre Etalon de classe " & pClasse & "devant �tre v�rifi� dans " & n - 1 & " jours !"
                    End If
                    AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, sName, sTexte, positionTopAlertes)
                End If
            Next n
        End If

        If nbAlertes_Manometre_Rouge > 0 Then
            sName = "alerteManoEtalon_1mois"
            If nbAlertes_Manometre_Rouge > 1 Then
                sTexte = "Attention, vous venez de d�passer la date autoris�e pour " & nbAlertes_Manometre_Rouge & " manom�tres Etalons de classe " & pClasse & ". Veuillez effectuer vos contr�les imm�diatement !"
            Else
                sTexte = "Attention, vous venez de d�passer la date autoris�e pour 1 manom�tre Etalon de classe " & pClasse & ". Veuillez effectuer votre contr�le imm�diatement !"
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ROUGE, sName, sTexte, positionTopAlertes)
        End If

        If nbAlertes_Manometre_Noire > 0 Then
            sName = "alerteManoEtalon_1mois7jr"
            If nbAlertes_Manometre_Noire > 1 Then
                sTexte = "Vous avez trop attendu pour v�rifier " & nbAlertes_Manometre_Noire & " manom�tres �talons de classe " & pClasse & ". A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
            Else
                sTexte = "Vous avez trop attendu pour v�rifier 1 manom�tre �talon de classe " & pClasse & ". A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, sName, sTexte, positionTopAlertes)
        End If

        If nbAlertes_Controle > 0 Then
            sName = "alerteManoEtalon_defaillant"
            If nbAlertes_Controle > 1 Then
                sTexte = "Vous avez " & nbAlertes_Controle & " manom�tres �talons de classe " & pClasse & " d�fectueux. Contactez le CRODIP."
            Else
                sTexte = "Vous avez 1 manom�tre �talon d�fectueux. Contactez le CRODIP."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.CONTROLE, sName, sTexte, positionTopAlertes)
        End If
    End Sub
    Private Sub loadAccueilAlertsNumeroration(ByRef positionTopAlertes As Integer)

        Dim olst As New List(Of String)
        'olst = BDDTransfert.ComparerNumDiag()
        'If olst.Count > 0 Then
        '    MsgBox(olst(0), MsgBoxStyle.Critical, "ERREUR DE MIGRATION")
        '    Application.Exit()
        'Else
        '    File.Delete("./TransfertBDD")
        'End If
        'For Each strAlert As String In olst
        '    AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, "Migration", strAlert, positionTopAlertes)
        'Next


    End Sub
    Private Sub loadAccueilAlertsMAJ(ByRef positionTopAlertes As Integer)

        Dim olst As New List(Of String)
        Dim nPulve As Integer = PulverisateurManager.MAJPulveDepuisdiagnostic()
        If nPulve > 0 Then
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, "MAJ Pulv�risateurs", nPulve & " Pulverisateurs mis � jour, ils seront transf�r�s au crodip lors de la prochaine synchronisation", positionTopAlertes)
        End If


    End Sub

    Private Sub loadAccueilAlertsManoControle(ByRef positionTopAlertes As Integer)
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_MANOCONTROLE_LOAD, True)
        'Chargement de tous les manos
        Dim lstMano As List(Of ManometreControle) = ManometreControleManager.getlstByAgent(agentCourant, True) _
                                                                    .Where(Function(M)
                                                                               Try
                                                                                   Return M.IsTypeTracaB
                                                                               Catch ex As Exception
                                                                                   Return False
                                                                               End Try
                                                                           End Function).ToList()
        loadAccueilAlertsManoControle(lstMano, "[6-10] bar", positionTopAlertes)

        lstMano = ManometreControleManager.getlstByAgent(agentCourant, True).Where(Function(M)
                                                                                       Try
                                                                                           Return M.IsTypeTracaH
                                                                                       Catch ex As Exception
                                                                                           Return False
                                                                                       End Try
                                                                                   End Function).ToList()
        loadAccueilAlertsManoControle(lstMano, "[20-25] bar", positionTopAlertes)

        lstMano = ManometreControleManager.getlstByAgent(agentCourant, True).Where(Function(M)
                                                                                       Try
                                                                                           Return Not (M.IsTypeTracaB Or M.IsTypeTracaH)
                                                                                       Catch ex As Exception
                                                                                           Return True
                                                                                       End Try
                                                                                   End Function).ToList()
        loadAccueilAlertsManoControle(lstMano, "", positionTopAlertes)


    End Sub

    Private Sub loadAccueilAlertsManoControle(pLstMano As List(Of ManometreControle), pClasse As String, ByRef positionTopAlertes As Integer)

        ' V�rification des alertes sur les manom�tre de contr�le
        Dim nbAlertes_ManometreControle_Orange As Integer = 0
        Dim nbAlertes_ManometreControle_Rouge As Integer = 0
        Dim nbAlertes_ManometreControle_Noire As Integer = 0
        Dim nbAlertes_Controle As Integer = 0

        Try



            'Chargement de tous les manos
            'Dim arrManoControle As List(Of ManometreControle) = ManometreControleManager.getManoControleByAgent(agentCourant, True)
            Dim njours As Integer
            Dim nbManoOrange(3000) As Integer 'Nombre de manom�tres devant �tre controler njours avant la Date Limite
            'Parcours de manos
            Dim AlerteMano As GlobalsCRODIP.ALERTE
            For Each tmpManoControle As ManometreControle In pLstMano
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
                        nbManoOrange(njours) = nbManoOrange(njours) + 1
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
                        'Si on a des Manos � controler avant n jours
                        If nbManoOrange(n - 1) > 1 Then
                            sTexte = "Attention, vous avez " & nbManoOrange(n - 1) & " manom�tres de contr�le " & pClasse & " devant �tre v�rifi�s dans " & (n - 1) & " jours !"
                        Else
                            sTexte = "Attention, vous avez 1 manom�tre de contr�le " & pClasse & " devant �tre v�rifi� dans " & n - 1 & " jours !"
                        End If
                        AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, sName, sTexte, positionTopAlertes)
                    End If
                Next n
            End If

            If nbAlertes_ManometreControle_Rouge > 0 Then
                sName = "alerteManoControle_1mois"
                If nbAlertes_ManometreControle_Rouge > 1 Then
                    sTexte = "Attention, vous venez de d�passer la date autoris�e pour " & nbAlertes_ManometreControle_Rouge & " manom�tres de contr�le " & pClasse & ". Veuillez effectuer vos contr�les imm�diatement !"
                Else
                    sTexte = "Attention, vous venez de d�passer la date autoris�e pour 1 manom�tre de contr�le " & pClasse & ". Veuillez effectuer votre contr�le imm�diatement !"
                End If
                AjouteUneAlerte(GlobalsCRODIP.ALERTE.ROUGE, sName, sTexte, positionTopAlertes)
            End If

            If nbAlertes_ManometreControle_Noire > 0 Then
                sName = "alerteManoControle_1mois7jr"
                If nbAlertes_ManometreControle_Noire > 1 Then
                    sTexte = "Vous avez trop attendu pour v�rifier " & nbAlertes_ManometreControle_Noire & " manom�tres de contr�le " & pClasse & ". A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
                Else
                    sTexte = "Vous avez trop attendu pour v�rifier 1 manom�tre de contr�le " & pClasse & ". A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
                End If
                AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, sName, sTexte, positionTopAlertes)
            End If

            If nbAlertes_Controle > 0 Then
                sName = "alerteManoControle_defaillant"
                If nbAlertes_Controle > 1 Then
                    sTexte = "Vous avez " & nbAlertes_Controle & " manom�tres de contr�le " & pClasse & " d�fectueux. Contactez le CRODIP."
                Else
                    sTexte = "Vous avez 1 manom�tre de contr�le " & pClasse & " d�fectueux. Contactez le CRODIP."
                End If
                AjouteUneAlerte(GlobalsCRODIP.ALERTE.CONTROLE, sName, sTexte, positionTopAlertes)
            End If

        Catch ex As Exception
            CSDebug.dispError("Acceil.loadAccueilAlertsMAnoControle", ex)
        End Try
    End Sub
    'Chargement des alertes
    Private Sub loadAccueilAlertsIdentifiantsPulv�risateurs(ByRef positionTopAlertes As Integer)

        'charegement de la liste des identifiants Inutilis�s
        'Si le nbre est inf�rieure au nombre mini/4
        'Alerte noire
        'Si le nbre est inf�rieure au nombre mini/2
        'Alerte Rouge
        'Si le nbre est inf�rieure au nombre mini
        'Alerte Orange
        Dim AlerteIdent As GlobalsCRODIP.ALERTE
        Dim olst As List(Of IdentifiantPulverisateur) = IdentifiantPulverisateurManager.getListeInutilise(agentCourant)
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
                stext = "Attention, il ne vous reste plus que " & olst.Count & " identifiants pulv�risateurs disponibles, contactez le CRODIP."
            End If
            If olst.Count = 1 Then
                stext = "Attention, il ne vous reste plus qu'UN SEUL identifiant pulv�risateur disponible, contactez le CRODIP."
            End If
            If olst.Count = 0 Then
                stext = "Attention, il ne vous reste plus AUCUN identifiant pulv�risateur disponible, contactez le CRODIP."
            End If
            AjouteUneAlerte(AlerteIdent, "Identifiant Pulv�risateur", stext, positionTopAlertes)
        End If

    End Sub
    ''' <summary>
    ''' Verification de la date de synhcro de l'agent courant
    ''' alerte ORANGE si plus de 10 jours sans connexion
    ''' </summary>
    ''' <param name="positionTopAlertes"></param>
    Private Sub loadAccueilAlertsSynchro(ByRef positionTopAlertes As Integer)

        ' V�rification de la date de derni�re synchro
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
            sText = "Vous devez connecter le logiciel � Internet pour effectuer une synchronisation des donn�es."
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, "alerte synhcro", sText, positionTopAlertes)

        End If

    End Sub
    Private Sub AjouteUneAlerte(ByVal TypeAlerte As GlobalsCRODIP.ALERTE, ByVal pName As String, ByVal ptext As String, ByRef positionTopAlertes As Integer)
        Dim tmpAlerte As New Label
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(accueil))
        '        tmpAlerte.Name = pName
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

        CSDebug.dispInfo("Alertes : " & ptext)

    End Sub


    Private Sub loadAccueilAlertsBuseEtalon(ByRef positionTopAlertes As Integer)
        ' V�rification des alertes sur les buses �talons
        Dim nbAlertes_Buse_alerte As Integer = 0
        Dim nbAlertes_Buse_out As Integer = 0
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(accueil))
        Dim alerte As GlobalsCRODIP.ALERTE = GlobalsCRODIP.ALERTE.NONE

        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_BUSESETALON_LOAD, True)
        Dim arrBusesEtalon As List(Of Buse) = BuseManager.getlstByAgent(agentCourant, True)
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
                stext = "Il faut commander de nouvelles buses �talons car " & nbAlertes_Buse_alerte & " ne seront plus reconnues dans 3 mois."
            Else
                stext = "Il faut commander de nouvelles buses �talons car " & nbAlertes_Buse_alerte & " ne sera plus reconnue dans 3 mois."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, "alerteBuseEtalon_alerte", stext, positionTopAlertes)
        End If
        If nbAlertes_Buse_out > 0 Then
            Dim sText As String
            If nbAlertes_Buse_out > 1 Then
                sText = "Il faut commander de nouvelles buses �talons car " & nbAlertes_Buse_out & " buses ne sont plus reconnues."
            Else
                sText = "Il faut commander de nouvelles buses �talons car " & nbAlertes_Buse_out & " buse n'est plus reconnue."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, "alerteBuseEtalon_out", sText, positionTopAlertes)
        End If

    End Sub

    ''' <summary>
    ''' V�rification du nbre de controle depuis le dernier controle Regulier
    ''' </summary>
    ''' <param name="positionTopAlertes"></param>
    ''' <remarks></remarks>
    Private Sub loadAccueilAlertsNbControle(ByRef positionTopAlertes As Integer)

        Dim bAlerte As Boolean = False
        bAlerte = My.Settings.nbControlesAvantAlerte > My.Settings.nbControlesAvantAlerteMax
        'Affichage des alertes 
        Dim sName As String = ""
        Dim sTexte As String = ""
        If bAlerte Then
            sTexte = "Attention, vous avez effectu� " & My.Settings.nbControlesAvantAlerte & " diagnostics sans effectuer de contr�les r�guliers des instruments, veuillez v�rifier vos instruments de mesures"
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, sName, sTexte, positionTopAlertes)
        End If


    End Sub

    Private Sub LoadAccueilAlertsBancsMesures(ByRef positionTopAlertes As Integer)
        ' V�rification des alertes sur les banc de mesure
        Dim nbAlertes_Banc_Orange As Integer = 0
        Dim nbAlertes_Banc_1mois As Integer = 0
        Dim nbAlertes_Banc_1mois7jr As Integer = 0
        Dim nbAlertes_Banc_defaillant As Integer = 0
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(accueil))

        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ALERTES_BANC_LOAD, True)
        Dim arrBanc As List(Of Banc)
        arrBanc = BancManager.getBancByAgent(agentCourant)

        'BancCourant = arrBanc(0)

        Dim njours As Integer
        Dim nbBancAvantDL(3000) As Integer 'Nombre de banc devant �tre controler njours avant la Date Limite
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
                    'Si on a des Manos � controler avant n jours
                    If nbBancAvantDL(n - 1) > 1 Then
                        sTexte = "Attention, vous avez " & nbBancAvantDL(n - 1) & " bancs de mesure devant �tre v�rifi�s dans " & n - 1 & " jours !"
                    Else
                        sTexte = "Attention, vous avez 1 banc de mesure devant �tre v�rifi� dans " & n - 1 & " jours !"
                    End If
                    AjouteUneAlerte(GlobalsCRODIP.ALERTE.ORANGE, sName, sTexte, positionTopAlertes)
                End If
            Next n
        End If

        If nbAlertes_Banc_1mois > 0 Then
            sName = "alerteManoControle_1mois"
            If nbAlertes_Banc_1mois > 1 Then
                sTexte = "Attention, vous venez de d�passer la date autoris�e pour " & nbAlertes_Banc_1mois & " bancs de mesure. Veuillez effectuer vos contr�les imm�diatement !"
            Else
                sTexte = "Attention, vous venez de d�passer la date autoris�e pour 1 banc de mesure. Veuillez effectuer votre contr�le imm�diatement !"
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.ROUGE, sName, sTexte, positionTopAlertes)
        End If

        If nbAlertes_Banc_1mois7jr > 0 Then
            sName = "alerteManoControle_1mois7jr"
            If nbAlertes_Banc_1mois7jr > 1 Then
                sTexte = "Vous avez trop attendu pour v�rifier " & nbAlertes_Banc_1mois7jr & " bancs de mesure. A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
            Else
                sTexte = "Vous avez trop attendu pour v�rifier 1 banc de mesure. A partir de maintenant, le CRODIP ne prendra plus en compte vos diagnostics."
            End If
            AjouteUneAlerte(GlobalsCRODIP.ALERTE.NOIRE, sName, sTexte, positionTopAlertes)
        End If

        If nbAlertes_Banc_defaillant > 0 Then
            sName = "alerteManoControle_defaillant"
            If nbAlertes_Banc_defaillant > 1 Then
                sTexte = "Vous avez " & nbAlertes_Banc_defaillant & " bancs de mesure d�fectueux. Contactez le CRODIP."
            Else
                sTexte = "Vous avez 1 banc de mesure d�fectueux. Contactez le CRODIP."
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

            If File.Exists("./TransfertBDD") Then
                loadAccueilAlertsNumeroration(positionTopAlertes)
            End If
            If File.Exists("./MAJPULVEDEPUISDIAG") Then
                loadAccueilAlertsMAJ(positionTopAlertes)
                File.Delete("./MAJPULVEDEPUISDIAG")
            End If
            loadAccueilAlertsManoControle(positionTopAlertes)
            'loadAccueilAlertsManoEtalon(positionTopAlertes)
            loadAccueilAlertsBuseEtalon(positionTopAlertes)
            LoadAccueilAlertsBancsMesures(positionTopAlertes)
            If Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
                loadAccueilAlertsIdentifiantsPulv�risateurs(positionTopAlertes)
                loadAccueilAlertsSynchro(positionTopAlertes)
            End If

            'V�rification du nombre de controles effectu�es depuis le dernier controle Regulier
            loadAccueilAlertsNbControle(positionTopAlertes)

            ' Si aucune alerte � afficher, alors on affiche un message
            If positionTopAlertes = 8 Then
                Dim tmpAlerte As New Label
                tmpAlerte.Name = "noAlerte"
                tmpAlerte.Text = "       Aucune alerte � afficher."
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

    ' S�lection client dans la liste
    Private Sub list_clients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list_clients.SelectedIndexChanged
        'MsgBox(list_clients.SelectedItems().Count)
    End Sub

    ' Liste des pulv�risateurs d'un client
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
        'Attention : le libell� est invers� !!!
        If m_Exploitation_isShowAll = True Then
            btn_proprietaire_derniersControles.Text = "       Voir les prochains contr�les"
        Else
            btn_proprietaire_derniersControles.Text = "       Voir tous les contr�les"
        End If

    End Sub


    ' Voir la fiche d'un client
    Private Sub btn_proprietaire_voirFiche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_voirFiche.Click
        ' On r�cup�re le formulaire contener

        ' On r�cup�re le client s�lectionn�
        Dim clientSelected_NumSIREN As String = "0"
        Try
            clientSelected_NumSIREN = list_clients.SelectedItems.Item(0).Text
        Catch ex As Exception
            clientSelected_NumSIREN = "0"
        End Try
        ' On v�rifie qu'il y a bien une ligne de s�lectionn�e
        If list_clients.SelectedItems().Count > 0 And clientSelected_NumSIREN <> "0" Then
            voirFicheExploitant()
        End If
    End Sub

    ' Ajouter un client
    Private Sub btn_proprietaire_ajouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_ajouter.Click
        ' Ouverture fiche client
        clientCourant = New Exploitation()
        Dim formFiche_exploitant As New fiche_exploitant()
        formFiche_exploitant.setContexte(False, clientCourant, agentCourant, Nothing)
        '        formFiche_exploitant.MdiParent = Me.MdiParent
        formFiche_exploitant.ShowDialog(Me)
    End Sub

    ' Suppression client
    Private Sub btn_proprietaire_supprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proprietaire_supprimer.Click
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETECLIENT_ENCOURS)

        ' On r�cup�re le client s�lectionn�
        Dim clientSelected_NumSIREN As String = "0"
        Try
            clientSelected_NumSIREN = list_clients.SelectedItems.Item(0).Text
        Catch ex As Exception
            clientSelected_NumSIREN = "0"
        End Try

        ' On v�rifie qu'il y a bien une ligne de s�lectionn�e
        If list_clients.SelectedItems().Count > 0 And clientSelected_NumSIREN <> "0" Then
            ' On informe l'utilisateur et on lui demande confirmation
            If MsgBox("Attention, vous allez supprimer un exploitant, toute suppression est d�finitive. Etes-vous s�r ?", MsgBoxStyle.YesNo, "Suppression d'un exploitant") = MsgBoxResult.Yes Then
                ' On r�cup�re l'object client
                clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)
                ' Si tout est ok, on le supprime
                If ExploitationManager.SupprimerExploitation(clientCourant) Then
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETECLIENT_OK)
                    System.Threading.Thread.Sleep(1000)
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
                oDiag = DiagnosticManager.WSgetById(agentCourant.uid, -1, searchCriteria)
                If Not oDiag Is Nothing Then
                    diagnosticCourant = oDiag
                    Dim oExploit As Exploitation
                    oExploit = ExploitationManager.WSgetExploitationPulverisateurByDiagnosticId(agentCourant, -1, searchCriteria)
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
                oExploit.ExportCSV(agentCourant, SFile, bEntete)
                bEntete = False
            Next

            If MsgBox("Fichier correctement enregistr� dans : " & vbNewLine & SFile & vbNewLine & "Voulez-vous ouvrir ce fichier ?", MsgBoxStyle.YesNo, "Export CSV") = MsgBoxResult.Yes Then
                CSFile.open(SFile)
            End If
        Catch ex As Exception
            MsgBox("Une erreur est survenue pendant l'export CSV." & vbNewLine & "Peut-�tre avez-vous d�j� ouvert le fichier ?")
            CSDebug.dispError("ExportToCSV ERR : " & ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub ExportToCSVPulve()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim SFile As String = GlobalsCRODIP.CONST_PATH_EXP & "Export_pulve_" & Date.Now.ToString("yyyyMMdd") & ".csv"
            PulverisateurManager.exportToCSV(SFile)

            If MsgBox("Fichier correctement enregistr� dans : " & vbNewLine & SFile & vbNewLine & "Voulez-vous ouvrir ce fichier ?", MsgBoxStyle.YesNo, "Export CSV") = MsgBoxResult.Yes Then
                CSFile.open(SFile)
            End If
        Catch ex As Exception
            MsgBox("Une erreur est survenue pendant l'export CSV." & vbNewLine & "Peut-�tre avez-vous d�j� ouvert le fichier ?")
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
        formFiche_exploitant.setContexte(False, clientCourant, agentCourant, Nothing)
        formFiche_exploitant.ShowDialog()
    End Sub


    ' Edition d'une fiche pulv� � partir de la liste des pulv�
    Private Sub VoirFichePulve()

        ' On v�rifie qu'il y a bien une ligne de s�lectionn�e
        If dgvPulveExploit.SelectedRows.Count > 0 Then
            Try
                Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
                pulverisateurCourant = m_BindingListOfPulve(oRowIndex)

                ' Mise � jour de la barre de status
                Statusbar.display("Chargement du pulv�risateur n�" & pulverisateurCourant.id)

                ' Affichage de la fiche du pulv�risateur
                Dim formEdition_fiche_pulve As New ajout_pulve2()
                formEdition_fiche_pulve.setContexte(ajout_pulve2.MODE.MODIF, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
                'formEdition_fiche_pulve.MdiParent = Me.MdiParent
                formEdition_fiche_pulve.ShowDialog()
                'Rafraichissement de la liste
                '                affichePulvedansListeExploitation(pulverisateurCourant)
                m_BindingListOfPulve.ResetItem(oRowIndex)
                ' Mise � jour de la barre de status
                Statusbar.display("Pulv�risateur n�" & pulverisateurCourant.id)
            Catch ex As Exception
                CSDebug.dispError("Accueil.VoirFichePulve : " & ex.Message.ToString)
            End Try
        End If
    End Sub
    Public Sub voirFicheExploitant()
        ' Mise � jour de la barre de status
        Statusbar.display("Chargement du client n�" & list_clients.SelectedItems().Item(0).Tag)

        ' On r�cup�re l'objet du client
        clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)
        ' Ouverture fiche client
        Dim formFiche_exploitant As New fiche_exploitant
        formFiche_exploitant.setContexte(False, clientCourant, agentCourant, Nothing)
        formFiche_exploitant.ShowDialog()
    End Sub

    ' Ajout d'une fiche pulv�
    Private Sub btn_ficheClient_pulve_ajouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AjouterUnPulve()
    End Sub
    Private Sub AjouterUnPulve()
        Dim formAddPulve As New ajout_pulve2()
        ' On r�cup�re l'objet du client
        If (list_clients.SelectedItems().Count > 0) Then

            clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)
            pulverisateurCourant = New Pulverisateur()
            formAddPulve.setContexte(ajout_pulve2.MODE.AJOUT, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
            '        formAddPulve.MdiParent = Me.MdiParent
            formAddPulve.ShowDialog(Me)
        End If
    End Sub
    Private Sub AjouterUnPulveAdditionnel()
        Dim formAddPulve As New ajout_pulve2()
        ' On r�cup�re l'objet du client
        If (list_clients.SelectedItems().Count > 0) Then
            clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)

            pulverisateurCourant = New Pulverisateur()
            formAddPulve.setContexte(ajout_pulve2.MODE.AJOUT, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
            '        formAddPulve.MdiParent = Me.MdiParent
            formAddPulve.ShowDialog(Me)
        End If
    End Sub

    ' Cr�ation d'un nouveau diagnostic
    Private Sub btn_ficheClient_diagnostic_nouveau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheClient_diagnostic_nouveau.Click
        btn_ficheClient_diagnostic_nouveau.Enabled = False
        NouveauDiagnostic(GlobalsCRODIP.DiagMode.CTRL_COMPLET)
        btn_ficheClient_diagnostic_nouveau.Enabled = Not agentCourant.isGestionnaire
    End Sub

    Private Sub NouveauDiagnostic(pDiagMode As GlobalsCRODIP.DiagMode)

        ' On r�cup�re le formulaire contener
        ' Dim myFormParentContener As Form = Me.MdiParent

        ' On v�rifie qu'il y a bien une ligne de s�lectionn�e
        'If list_ficheClient_puverisateur.SelectedItems().Count > 0 Then
        Dim bBancOK As Boolean = True
        If dgvPulveExploit.SelectedRows.Count() > 0 Then
            Try
                If BancManager.getBancByAgent(agentCourant).Count = 0 Then
                    MessageBox.Show("Vous n'avez pas de banc de mesure actif affect� � votre compte, merci de faire un controle ou contactez le CRODIP", "Controle Pulverisateur")
                    bBancOK = False
                End If

                If bBancOK Then

                    Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
                    pulverisateurCourant = m_BindingListOfPulve(oRowIndex)
                    ' On r�cup�re le pulv� selectionn�
                    '                pulverisateurCourant = PulverisateurManager.getPulverisateurById(list_ficheClient_puverisateur.SelectedItems().Item(0).Tag)
                    ' Mise � jour de la barre de status
                    If pDiagMode = GlobalsCRODIP.DiagMode.CTRL_CV Then
                        Statusbar.display("Nouvelle contre-visite")
                    Else
                        Statusbar.display("Nouveau Controle")
                    End If

                    'V�rification du ficher de Param
                    'Lecture du param�trage associ� au pulv�risateur
                    If Not pulverisateurCourant.CheckParam(pulverisateurCourant) Then
                        Exit Sub
                    End If
                    ' Cr�ation d'une nouveau diagnostic
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
                End If
            Catch ex As Exception
                Statusbar.clear()
                CSDebug.dispFatal("Accueil.nouveauDiagnostique ERR : " & ex.Message)
            End Try
        End If


    End Sub

    Public Sub NouveauDiagnosticPhase1(pDiagMode As GlobalsCRODIP.DiagMode)
        Dim oParent As parentContener = TryCast(Me.MdiParent, parentContener)
        If oParent IsNot Nothing Then
            oParent.oEtatFDiag = New EtatFDiagDepart(pDiagMode, diagnosticCourant, pulverisateurCourant, clientCourant, agentCourant)
            oParent.Action(New ActionFDiagNext())
        End If



        ''V�rification des clients et Pulv�s au pr�alable
        'Dim ofrmExpl As New fiche_exploitant()
        'ofrmExpl.DialogResult = DialogResult.OK
        'ofrmExpl.setContexte(False, clientCourant, agentCourant)
        ''                ofrm.MdiParent = Me.MdiParent
        'If diagnosticCourant.bTrtExploitation Then
        '    ofrmExpl.ShowDialog()
        'End If
        'If ofrmExpl.DialogResult = Windows.Forms.DialogResult.OK Then
        '    'Affectation de exploitation au Diagnostic
        '    If Not diagnosticCourant Is Nothing Then
        '        diagnosticCourant.SetProprietaire(clientCourant)
        '        diagnosticCourant.proprietaireRepresentant = ofrmExpl.tbNomPrenomRepresentant.Text
        '    End If
        '    'End If
        '    'V�rification du Pulv�risateur
        '    'Si c'est un pulv� Additionnel => Affichage du pulv� principal puis du pulv� Additionnel
        '    Dim ofrmEditPulve As ajout_pulve2
        '    ofrmEditPulve = New ajout_pulve2()
        '    'If pulverisateurCourant.isPulveAdditionnel Then
        '    '    Dim oPulvePrincipal As Pulverisateur
        '    '    Dim oPulveAdditionnel As Pulverisateur
        '    '    oPulveAdditionnel = pulverisateurCourant
        '    '    oPulvePrincipal = PulverisateurManager.getPulverisateurByNumNat(pulverisateurCourant.pulvePrincipalNumNat)
        '    '    If oPulvePrincipal.id <> "" Then
        '    '        ofrmEditPulve.setContexte(ajout_pulve2.MODE.CONSULT, agentCourant, oPulvePrincipal, diagnosticCourant)
        '    '        ofrmEditPulve.ShowDialog()
        '    '    End If
        '    '    pulverisateurCourant = oPulveAdditionnel
        '    'End If
        '    ofrmEditPulve.setContexte(ajout_pulve2.MODE.VERIF, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
        '    ofrmEditPulve.DialogResult = DialogResult.OK
        '    If diagnosticCourant.bTrtPulverisateur Then
        '        ofrmEditPulve.ShowDialog()
        '    End If
        '    If ofrmEditPulve.DialogResult = Windows.Forms.DialogResult.OK Then
        '        diagnosticCourant.setPulverisateur(pulverisateurCourant)
        '        NouveauDiagnosticPhase2(pDiagMode, diagnosticCourant)
        '    End If
        'End If

    End Sub
    ''' <summary>
    ''' R�alisation d"un nouveau controle Phase 2
    '''  Affichage du contexte
    '''  Si on ne fait pas une contrevisite gratuite 
    '''        Affichage de la page de facturation
    ''' Affichage de la page de Preliminaires
    ''' </summary>
    ''' <param name="bisContreVisite"></param>
    ''' <remarks></remarks>
    Public Sub NouveauDiagnosticPhase2a(pDiagMode As GlobalsCRODIP.DiagMode, pDiag As Diagnostic)
        Statusbar.clear()
        diagnosticCourant = pDiag ''Par S�curit�
        Dim bOK As Boolean = True
        If Not GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            Me.Cursor = Cursors.WaitCursor
            Dim formDiagnostic_Contexte As New diagnostic_contexte(pDiagMode, pDiag, pulverisateurCourant, clientCourant, False)
            formDiagnostic_Contexte.DialogResult = DialogResult.OK
            If diagnosticCourant.bTrtContexte Then
                formDiagnostic_Contexte.ShowDialog()
                formDiagnostic_Contexte.Close()
            End If
            Me.Cursor = Cursors.Default
            bOK = (formDiagnostic_Contexte.DialogResult = Windows.Forms.DialogResult.OK)
            If bOK Then
                Dim isContreVisiteGratuite As Boolean
                isContreVisiteGratuite = System.IO.File.Exists("ContreVisiteGratuite")
                If (diagnosticCourant.isContrevisiteImmediate And isContreVisiteGratuite) Or GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
                    'Mise � jour du tarif du Diagnostique
                    diagnosticCourant.isGratuit = True
                    diagnosticCourant.controleTarif = 0
                    diagnosticCourant.TotalHT = 0
                    diagnosticCourant.TotalTVA = 0
                    diagnosticCourant.TotalTTC = 0
                Else
                    'Nous ne sommes pas une contrevisite imm�diate ou cette CV n'est pas gratuite
                    Statusbar.clear()
                    If diagnosticCourant.bTrtContrat Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim frmFact As diagnostic_ContratCommercial = New diagnostic_ContratCommercial()
                        frmFact.setContexte(pDiag, clientCourant, agentCourant)
                        frmFact.ShowDialog()
                        Me.Cursor = Cursors.Default
                        bOK = (frmFact.DialogResult = Windows.Forms.DialogResult.OK)
                    End If
                End If
                Statusbar.clear()
            End If
        End If
        If bOK Then
            TryCast(MdiParent, parentContener).Action(New ActionFDiagNext())
            Statusbar.clear()
        End If


    End Sub

    Public Sub NouveauDiagnosticPhase2(pDiagMode As GlobalsCRODIP.DiagMode, pDiag As Diagnostic)
        Statusbar.clear()
        diagnosticCourant = pDiag ''Par S�curit�
        Dim bOK As Boolean = True
        If Not GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            Me.Cursor = Cursors.WaitCursor
            Dim formDiagnostic_Contexte As New diagnostic_contexte(pDiagMode, pDiag, pulverisateurCourant, clientCourant, False)
            formDiagnostic_Contexte.DialogResult = DialogResult.OK
            If diagnosticCourant.bTrtContexte Then
                formDiagnostic_Contexte.ShowDialog()
                formDiagnostic_Contexte.Close()
            End If
            Me.Cursor = Cursors.Default
            bOK = (formDiagnostic_Contexte.DialogResult = Windows.Forms.DialogResult.OK)
            If bOK Then
                Dim isContreVisiteGratuite As Boolean
                isContreVisiteGratuite = System.IO.File.Exists("ContreVisiteGratuite")
                If (diagnosticCourant.isContrevisiteImmediate And isContreVisiteGratuite) Or GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
                    'Mise � jour du tarif du Diagnostique
                    diagnosticCourant.isGratuit = True
                    diagnosticCourant.controleTarif = 0
                    diagnosticCourant.TotalHT = 0
                    diagnosticCourant.TotalTVA = 0
                    diagnosticCourant.TotalTTC = 0
                Else
                    'Nous ne sommes pas une contrevisite imm�diate ou cette CV n'est pas gratuite
                    Statusbar.clear()
                    If diagnosticCourant.bTrtContrat Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim frmFact As diagnostic_ContratCommercial = New diagnostic_ContratCommercial()
                        frmFact.setContexte(pDiag, clientCourant, agentCourant)
                        frmFact.ShowDialog()
                        Me.Cursor = Cursors.Default
                        bOK = (frmFact.DialogResult = Windows.Forms.DialogResult.OK)
                    End If
                End If
                Statusbar.clear()
            End If
        End If
        If bOK Then
            If diagnosticCourant.bTrtDefauts Then
                Dim oParent As parentContener = TryCast(Me.MdiParent, parentContener)
                If oParent IsNot Nothing Then
                    'oParent.oEtatFDiag = New EtatFDiagPreliminaire(pDiagMode, pDiag, pulverisateurCourant, clientCourant, agentCourant)
                    oParent.DisplayFormDiag()
                End If
            End If
        End If


    End Sub

    Private Sub VoirDiagnostique()
        If diagnosticCourant IsNot Nothing Then
            NouveauDiagnosticPhase1(GlobalsCRODIP.DiagMode.CTRL_VISU)
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
        ' On r�cup�re le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent

        ' On v�rifie qu'il y a bien une ligne de s�lectionn�e
        If dgvPulveExploit.SelectedRows.Count > 0 Then
            ' Mise � jour de la barre de status
            Try
                Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
                pulverisateurCourant = m_BindingListOfPulve(oRowIndex)
                Statusbar.display("Visualisation d�un contr�le pour le pulv�risateur " & pulverisateurCourant.id)

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
        ' On r�cup�re le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent

        ' Mise � jour de la barre de status
        Statusbar.display("Liste des clients")

        ' Affichage de la liste des clients
        panel_clientele_LstCtrlCtriteres.Visible = True
        panel_ListeDesControles.Visible = True
        panel_ListeDesControles.Dock = DockStyle.Fill
        panel_clientele_ficheClient.Visible = False
    End Sub

    ' Filtre les pulv�s qui ont des alertes
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

    ' Supprimer un pulv�risateur
    Private Sub btn_ficheClient_pulve_supprimer_Click2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        supprimerUnPulverisateur()
    End Sub
    Private Sub supprimerUnPulverisateur()
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETEPULVE_ENCOURS)
        ' On v�rifie qu'il y a bien une ligne de s�lectionn�e
        If dgvPulveExploit.SelectedRows.Count > 0 Then
            ' On informe l'utilisateur et on lui demande confirmation
            If MsgBox("Attention, vous allez supprimer un pulv�risateur, toute suppression est d�finitive. Etes-vous s�r ?", MsgBoxStyle.YesNo, "Suppression d'un pulv�risateur") = MsgBoxResult.Yes Then
                ' On r�cup�re l'object pulv�
                Dim oRowIndex As Integer = dgvPulveExploit.SelectedRows(0).Index
                pulverisateurCourant = m_BindingListOfPulve(oRowIndex)
                ' Si tout est ok, on le supprime
                If PulverisateurManager.deletePulverisateur(pulverisateurCourant) Then
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DELETEPULVE_OK)
                    System.Threading.Thread.Sleep(1000)
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

    ' Trier les pulv�s
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

#Region " Pulv�risateurs "

    ' Rafraichissement de la liste
    Private Sub listPulve_lbl_refreshList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listPulve_lbl_refreshList.Click
        listPulverisateurs.ListViewItemSorter = Nothing
        loadListPulve()
    End Sub

    ' G�re le tri au clic sur les colones
    Private Sub listPulverisateurs_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles listPulverisateurs.ColumnClick
        Static OrdreDeTri As System.Windows.Forms.SortOrder
        OrdreDeTri = 1 - OrdreDeTri
        If e.Column <> 8 Then
            sender.ListViewItemSorter = New CSListViewItemComparer(e.Column, OrdreDeTri)
        Else
            sender.ListViewItemSorter = New CSListViewItemComparer(e.Column, OrdreDeTri, "Date")
        End If
    End Sub

    ' Export CSV de la liste des pulv�s
    Private Sub listPulve_btn_exportCsv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listPulve_btn_exportCsv.Click
        ExportToCSVPulve()
    End Sub

    ' Ouverture de la fiche d'un pulv�
    Private Sub btn_lstPulve_voirFiche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lstPulve_voirFiche.Click
        displayPulveEdit()
    End Sub
    Private Sub listPulverisateurs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listPulverisateurs.DoubleClick
        displayPulveEdit()
    End Sub
    Private Sub displayPulveEdit()
        ' On r�cup�re le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent

        ' On v�rifie qu'il y a bien une ligne de s�lectionn�e
        If listPulverisateurs.SelectedItems().Count > 0 Then
            Dim olvItem As ListViewItem
            olvItem = listPulverisateurs.SelectedItems().Item(0)
            ' On r�cup�re le pulv� selectionn�
            pulverisateurCourant = PulverisateurManager.getPulverisateurById(olvItem.Tag)
            clientCourant = ExploitationManager.GetExploitationByPulverisateurId(pulverisateurCourant.id)
            diagnosticCourant = Nothing
            ' Mise � jour de la barre de status
            Statusbar.display("Chargement du pulv�risateur n�" & olvItem.SubItems.Item(0).Text)

            ' Affichage de la fiche du pulv�risateur
            Dim formEdition_fiche_pulve As New ajout_pulve2()
            formEdition_fiche_pulve.setContexte(ajout_pulve2.MODE.MODIF, agentCourant, pulverisateurCourant, clientCourant, Nothing)
            '            formEdition_fiche_pulve.MdiParent = Me.MdiParent
            formEdition_fiche_pulve.ShowDialog(Me.MdiParent)
            If formEdition_fiche_pulve.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                SurroundingClass.BeginControlUpdate(listPulverisateurs)
                loadListPulve()
                SurroundingClass.EndControlUpdate(listPulverisateurs)
                Me.Cursor = Cursors.Default
            End If

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
            MsgBox("Une Mise � jour est disponible, vous devez l'installer avant de vous synchroniser")
            Application.Exit()
        End If

        If CSEnvironnement.checkNetwork() = True Then
            GlobalsCRODIP.GLOB_NETWORKAVAILABLE = True
            If CSEnvironnement.checkWebService() = True Then
                ' On v�rifie les mises � jour
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

                    ' On affiche l'�cran de connexion
                    Dim loginMDIChild As New login
                    If Me.MdiParent IsNot Nothing Then
                        TryCast(Me.MdiParent, parentContener).DisplayForm(loginMDIChild)
                    End If

                End If

            Else
                Statusbar.display("Synchronisation impossible, serveur Crodip momentan�ment indisponible.", False)
                MsgBox("Synchronisation impossible, serveur Crodip momentan�ment indisponible.", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Synchronisation impossible, vous devez �tre connect� � internet !", MsgBoxStyle.Exclamation)
        End If

        Statusbar.hideLoader()
    End Sub

#End Region

#Region " Outils compl�mentaires "

    ' Documents � imprimer
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
        Dim oFrm As New facturation2
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
    '###### V�rification des appareils de l'inspecteur #######
    '#########################################################
    'Manometres
    Private Sub btn_parametrage_verificationManometres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parametrage_verificationManometres.Click
        Dim ofrm As New frmControleManometresNew(agentCourant)
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
        ' Enregistrement param�tres SMTP
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
            Dim oCol As List(Of AutoTest)
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

#End Region







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

    ''' G�n�ration du treeView du module documentaire
    Private Sub ModDoc_PopulateTreeView()
        Dim rootNode As TreeNode
        'Nettoyage
        tv_Docs.Nodes.Clear()
        lv_Docs.Items.Clear()

        Dim info As New DirectoryInfo(My.Settings.ModuleDocumentaire)
        If info.Exists Then
            rootNode = New TreeNode(info.Name)
            rootNode.Tag = info 'Les DirectoryInfo sont plac�es dans le tag
            'Chargement des sous r�pertoires
            ModDoc_GetDirectories(info.GetDirectories(), rootNode)
            tv_Docs.Nodes.Add(rootNode)
        End If

    End Sub

    ''' Ajout des Sous R�pertoire dans un noeud du Tv (R�cursif)
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
                    aNode.StateImageIndex = 0 'Folder Ferm�
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
        'R�cup�ration du directory info dans le TreeView
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
    'Si c'est un r�pertoire => Ouvrir le R�pertoire
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

                        'Recherch du node correspondant � l'�lement selectionn�
                        For Each oNode As TreeNode In tv_Docs.SelectedNode.Nodes
                            If oNode.Text = item.Text Then
                                'Simulatino du click sur le Node
                                TreeView1_NodeMouseClick(tv_Docs, New TreeNodeMouseClickEventArgs(oNode, Windows.Forms.MouseButtons.Left, 2, 0, 0))
                                'D�signation du node selectionn�
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
        If MessageBox.Show("Etes-vous sur de vouloir r�initialiser le fichier de log de la synchro ?", "Fichier de Log", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'R�nitialisation du fichier e logde la synchro
            SynchronisationManager.ReinitFichierLOGSynchro()


        End If

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub lla_Rappeltol�rance_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lla_Rappeltol�rance.LinkClicked
        dlgToleranceBuses.ShowDialog()
    End Sub

    Private Sub btnSupprPulve_Click(sender As Object, e As EventArgs)
        supprimerUnPulverisateur()
    End Sub

    Private Sub btnFichePulve_Click(sender As Object, e As EventArgs)
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
            dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionBackColor = GLOB_BLUE_CROPDIP

        Else
            dgvPulveExploit.Rows(index).DefaultCellStyle.ForeColor = Color.Black
            dgvPulveExploit.Rows(index).DefaultCellStyle.BackColor = Color.White
            dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionForeColor = Color.White
            dgvPulveExploit.Rows(index).DefaultCellStyle.SelectionBackColor = GLOB_BLUE_CROPDIP
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
        MsgBox("Traitement termin�")
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
                        If opulve.dateProchainControleAsDate < Now Or opulve.dateProchainControleAsDate Is Nothing Then
                            btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
                        Else
                            btn_ficheClient_diagnostic_nouvelleCV.Enabled = Not agentCourant.isGestionnaire
                        End If
                    End If
                    btn_ficheClient_diagnostic_voir.Enabled = Not agentCourant.isGestionnaire
                    'btnSupprPulve.Enabled = Not agentCourant.isGestionnaire
                    If opulve.isPulveAdditionnel Then
                        laAjoutPulveAdditionnel.Enabled = False
                    Else
                        laAjoutPulveAdditionnel.Enabled = True
                    End If

                Else
                    btn_ficheClient_diagnostic_nouveau.Enabled = False
                    btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
                    btn_ficheClient_diagnostic_voir.Enabled = False
                End If
            Else
                btn_ficheClient_diagnostic_nouveau.Enabled = False
                btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
                btn_ficheClient_diagnostic_voir.Enabled = False
                laAjoutPulveAdditionnel.Enabled = False
            End If
        Catch

        End Try

    End Sub


    ''' <summary>
    ''' Mise � jour de la derni�re date de synhcro de l'agent
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MajDateDernSynhcroagent()
        If MsgBox("Mise � jour de la date de derni�re synhcro de l'agent � " & CSDate.ToCRODIPString(DateTime.Now()), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            agentCourant.dateDerniereSynchro = CSDate.ToCRODIPString(DateTime.Now())
            Dim oUpdate As Object = Nothing
            AgentManager.WSSend(agentCourant, oUpdate)
        End If

    End Sub
    Public Sub Notice(pMsg As String) Implements IObservateur.Notice
        afficheSynchroCourante(pMsg)
    End Sub

    Private Sub PictureBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles pctLogoSynchro.MouseClick
        MajDateDernSynhcroagent()
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
            MsgBox("Une Mise � jour est disponible, vous devez l'installer avant de vous synchroniser")
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

    Private Sub btnAjoutFacture_Click(sender As Object, e As EventArgs) Handles btnAjoutFacture.Click
        Dim ofrm As frmdiagnostic_facturationCoProp
        ofrm = New frmdiagnostic_facturationCoProp()
        ofrm.setContexte(agentCourant)
        If ofrm.ShowDialog(Me) = DialogResult.OK Then
            ofrm.lstFacture.ForEach(Sub(oFact)
                                        If Not String.IsNullOrEmpty(oFact.idFacture) Then
                                            m_bsFacture.Insert(0, oFact)
                                        End If
                                    End Sub)

            m_bsFacture.ResetBindings(False)
        End If
    End Sub
    Private Enum TypeRechercheFacture
        RECHERCHE_FACTURE_TOUTES
        RECHERCHE_FACTURE_PAR_DATE
        RECHERCHE_FACTURE_NUM
        RECHERCHE_FACTURE_CLIENT
    End Enum
    Private Sub btnRechercher_Click(sender As Object, e As EventArgs) Handles btnRechercher.Click
        Dim typerecherche As TypeRechercheFacture
        Dim Value1 As String = ""
        Dim Value2 As String = ""
        If rbDatesFacture.Checked Then
            typerecherche = TypeRechercheFacture.RECHERCHE_FACTURE_PAR_DATE
            Value1 = dtpDeb.Value.ToShortDateString()
            Value2 = dtpFin.Value.ToShortDateString() & " 23:59:59"
        End If
        If rbNumFact.Checked Then
            If tbNumFact.Text = "" Then
                typerecherche = TypeRechercheFacture.RECHERCHE_FACTURE_TOUTES
                Value1 = ""
            Else
                typerecherche = TypeRechercheFacture.RECHERCHE_FACTURE_NUM
                Value1 = tbNumFact.Text
                Value2 = ""
            End If
        End If
        If rbNomClient.Checked Then
            If tbNomClient.Text = "" Then
                typerecherche = TypeRechercheFacture.RECHERCHE_FACTURE_TOUTES
            Else
                typerecherche = TypeRechercheFacture.RECHERCHE_FACTURE_CLIENT
                Value1 = tbNomClient.Text
                Value2 = ""
            End If
        End If
        RechercherFacture(typerecherche, Value1, Value2)
    End Sub
    Private Sub RechercherFacture(pTypeRecherche As TypeRechercheFacture, pValue1 As String, pValue2 As String)
        Dim olst As New List(Of Facture)
        Select Case pTypeRecherche
            Case TypeRechercheFacture.RECHERCHE_FACTURE_NUM
                Dim obj As Facture
                obj = FactureManager.getFactureById(pValue1)
                If Not String.IsNullOrEmpty(obj.idFacture) Then
                    olst.Add(obj)
                End If
            Case TypeRechercheFacture.RECHERCHE_FACTURE_CLIENT
                olst.AddRange(FactureManager.getFacturesByNomClient(pValue1))
            Case TypeRechercheFacture.RECHERCHE_FACTURE_PAR_DATE
                olst.AddRange(FactureManager.getFacturesByDate(pValue1, pValue2))
            Case TypeRechercheFacture.RECHERCHE_FACTURE_TOUTES
                olst.AddRange(FactureManager.getFactures())
        End Select

        m_bsFacture.Clear()
        olst.ForEach(Sub(oFact)
                         m_bsFacture.Add(oFact)
                     End Sub)
    End Sub

    Private Sub dgvFactures_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFactures.CellContentDoubleClick
        Dim ofrm As frmdiagnostic_facturationCoProp
        Dim oFact As Facture
        ofrm = New frmdiagnostic_facturationCoProp()
        oFact = m_bsFacture.Current
        ofrm.setContexte(oFact)
        ofrm.ShowDialog()
    End Sub

    Private Sub dgvFactures_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFactures.CellContentClick
        If e.ColumnIndex = PDFColumn.Index Then
            AffichePDF()
        End If
    End Sub

    Private Sub AffichePDF()
        Dim oFact As Facture = m_bsFacture.Current
        If Not String.IsNullOrEmpty(oFact.pathPDF) Then
            CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_FACTURE & oFact.pathPDF)
        End If
    End Sub

    Private Sub btnExportFacture_Click(sender As Object, e As EventArgs) Handles btnExportFacture.Click
        ExporterFactures()
    End Sub

    Private Sub ExporterFactures()

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim olst As New List(Of Facture)
            Dim SFile As String = GlobalsCRODIP.CONST_PATH_EXP & "Export_Facture_" & Date.Now.ToString("yyyyMMdd") & ".csv"

            For Each oFact As Facture In m_bsFacture.List
                olst.Add(oFact)
            Next
            FactureExportCSV.ExportCSV(SFile, olst)

            If MsgBox("Fichier correctement enregistr� dans : " & vbNewLine & SFile & vbNewLine & "Voulez-vous ouvrir ce fichier ?", MsgBoxStyle.YesNo, "Export Facture") = MsgBoxResult.Yes Then
                CSFile.open(SFile)
            End If
        Catch ex As Exception
            MsgBox("Une erreur est survenue pendant l'export CSV." & vbNewLine & "Peut-�tre avez-vous d�j� ouvert le fichier ?")
            CSDebug.dispError("ExporterFactures ERR : " & ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvPulveExploit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPulveExploit.CellContentClick
        If e.ColumnIndex = FichePulve.Index Then
            VoirFichePulve()
        End If

    End Sub

    Private Sub dgvPulveExploit_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPulveExploit.CellMouseEnter
        If e.ColumnIndex = FichePulve.Index Then
            dgvPulveExploit.Cursor = Cursors.Hand
        Else
            dgvPulveExploit.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub dgvPulveExploit_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPulveExploit.CellMouseLeave
        dgvPulveExploit.Cursor = Cursors.Default

    End Sub

    Private Sub btnAjoutPulveAdditionnel_Click(sender As Object, e As EventArgs) Handles laAjoutPulveAdditionnel.Click
        If dgvPulveExploit.SelectedRows.Count > 0 Then
            Dim index As Integer = dgvPulveExploit.SelectedRows(0).Index
            Dim opulve As Pulverisateur = m_BindingListOfPulve(index)
            Dim formAddPulve As New ajout_pulve2()
            ' On r�cup�re l'objet du client
            If (list_clients.SelectedItems().Count > 0) Then

                clientCourant = ExploitationManager.getExploitationById(list_clients.SelectedItems().Item(0).Tag)
                pulverisateurCourant = opulve.Clone()
                pulverisateurCourant.id = ""
                pulverisateurCourant.uid = 0
                pulverisateurCourant.SetPulverisateurAdditionnel(opulve)
                formAddPulve.setContexte(ajout_pulve2.MODE.AJOUT, agentCourant, pulverisateurCourant, clientCourant, diagnosticCourant)
                '        formAddPulve.MdiParent = Me.MdiParent
                formAddPulve.ShowDialog(Me)
            End If


        Else
            btn_ficheClient_diagnostic_nouveau.Enabled = False
            btn_ficheClient_diagnostic_nouvelleCV.Enabled = False
            btn_ficheClient_diagnostic_voir.Enabled = False
        End If
    End Sub

    Private Sub accueil_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.initWindowsProperties()
    End Sub

    Private Sub btnMAJPulveFromDiag_Click(sender As Object, e As EventArgs) Handles btnMAJPulveFromDiag.Click
        Me.Cursor = Cursors.WaitCursor
        Dim nPulvesMAJ As Integer
        nPulvesMAJ = PulverisateurManager.MAJPulveDepuisdiagnostic()
        If nPulvesMAJ >= 1 Then
            MsgBox(nPulvesMAJ & " pulverisateurs mis � jour, ils seront transf�r�s au crodip lors de la prochaine synchronisation", MsgBoxStyle.OkOnly, "Mise � jour des pulv�risateurs depuis les contr�les")
        End If
        If nPulvesMAJ = 1 Then
            MsgBox(nPulvesMAJ & " pulverisateur mis � jour, il sera transf�r� au crodip lors de la prochaine synchronisation", MsgBoxStyle.OkOnly, "Mise � jour des pulv�risateurs depuis les contr�les")
        End If
        If nPulvesMAJ = 0 Then
            MsgBox("Aucun pulverisateur mis � jour, rien ne sera transf�r� au crodip lors de la prochaine synchronisation", MsgBoxStyle.OkOnly, "Mise � jour des pulv�risateurs depuis les contr�les")
        End If
        If nPulvesMAJ < 0 Then
            MsgBox("ATTENTION ERREUR LORS DE LA MISE A JOUR DES PULVERISATEURS, CONTACTEZ LE CRODIP", MsgBoxStyle.OkOnly, "Mise � jour des pulv�risateurs depuis les contr�les")
        End If

        Me.Cursor = Cursors.Default
        MsgBox("Traitement termin�")

    End Sub

    Private Sub dgv_ControleRegulier_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ControleRegulier.CellValueChanged
        ' V�rifiez si la colonne modifi�e est "OK"
        Try
            If e.RowIndex > 0 Then

                If e.ColumnIndex = 3 Then
                    ' R�cup�rez la ligne o� la valeur a chang�
                    Dim row As DataGridViewRow = dgv_ControleRegulier.Rows(e.RowIndex)

                    ' Si la case "OK" est coch�e, d�cochez la case "NOK"
                    If Convert.ToBoolean(row.Cells(3).Value) Then
                        row.Cells(4).Value = False ' D�coche la case "NOK"
                    End If
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("dgv_ControleRegulier_CellValueChanged ERR", ex)
        End Try
    End Sub

    Private Sub dgv_ControleRegulier_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgv_ControleRegulier.CurrentCellDirtyStateChanged
        If dgv_ControleRegulier.IsCurrentCellDirty Then
            dgv_ControleRegulier.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start(My.Settings.epulve)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(My.Settings.epulve)
    End Sub
End Class
