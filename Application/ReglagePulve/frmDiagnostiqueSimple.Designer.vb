Imports System.Collections.Generic
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDiagnostiqueSimple
    Inherits frmCRODIP


    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiagnostiqueSimple))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ImageList_onglets = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.listImg_flags = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip_diagnostic_numRadioButtons = New System.Windows.Forms.ToolTip(Me.components)
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.CachedEtatSynthese1 = New Crodip_agent.Cachedcr_EtatSynthese()
        Me.btn_Valider = New System.Windows.Forms.Button()
        Me.btn_annuler = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_Poursuivre = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.diag_client_proprioSiren = New System.Windows.Forms.Label()
        Me.diag_client_raisonSociale = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.diag_pulve_Type = New System.Windows.Forms.Label()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.diag_pulve_marqueModele = New System.Windows.Forms.Label()
        Me.diag_pulve_numNatio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabPage_diagnostique_accessoires = New System.Windows.Forms.TabPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_12 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.GroupBox_diagnostic_1231 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_12312 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12310 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12311 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12314 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12313 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12316 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12315 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12318 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12317 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Label_diagnostic_123 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_1232 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_12322 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12320 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12321 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12324 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12323 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.ico_help12323 = New System.Windows.Forms.PictureBox()
        Me.Label_diagnostic_11 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.GroupBox_diagnostic_1221 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_12211 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12210 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12213 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12212 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Label_diagnostic_122 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_1222 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_12221 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12220 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_1241 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_12411 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12410 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12412 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Label_diagnostic_124 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.GroupBox_diagnostic_1111 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_11111 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11110 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11113 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11112 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Label_diagnostic_111 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_1112 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_11121 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11120 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11123 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11122 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_1113 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_11131 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11130 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11133 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11132 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_1114 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_11141 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11140 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_11142 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.GroupBox_diagnostic_1211 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_12111 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12110 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12113 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12112 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Label_diagnostic_121 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_1212 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_12121 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12120 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12123 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12122 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.ico_help_12123 = New System.Windows.Forms.PictureBox()
        Me.GroupBox_diagnostic_1213 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_12131 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12130 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_12132 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.tabPage_diagnostique_buses = New System.Windows.Forms.TabPage()
        Me.Panel63 = New System.Windows.Forms.Panel()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.buses_listBancs = New System.Windows.Forms.ComboBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Panel922 = New System.Windows.Forms.Panel()
        Me.Lbl_diagnostic_922 = New System.Windows.Forms.Label()
        Me.btn_diagnostic_acquisitionDonnees = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.diagBuses_resultat = New System.Windows.Forms.Label()
        Me.diagBuses_debitMoyen = New CRODIP_ControlLibrary.TBNumeric()
        Me.LaDebitMoyenBuses = New System.Windows.Forms.Label()
        Me.Label214 = New System.Windows.Forms.Label()
        Me.diagBuses_usureMoyBuses = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label213 = New System.Windows.Forms.Label()
        Me.diagBuses_nbBusesUsees = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.diagBuses_conf_nbCategories = New CRODIP_ControlLibrary.TBNumeric()
        Me.diagBuses_tab_categories = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cbxModele_Couleur = New System.Windows.Forms.ComboBox()
        Me.lblModele_Calibre = New System.Windows.Forms.Label()
        Me.lblModele_Couleur = New System.Windows.Forms.Label()
        Me.cbxModele_Modele = New System.Windows.Forms.ComboBox()
        Me.lblModele_Modele = New System.Windows.Forms.Label()
        Me.lblModele_Marque = New System.Windows.Forms.Label()
        Me.lblModele_NbBusesUsees = New System.Windows.Forms.Label()
        Me.tbModele_NbBusesUsees = New CRODIP_ControlLibrary.TBNumeric()
        Me.lblModele_DebitMoyen = New System.Windows.Forms.Label()
        Me.tbModele_DebitMoyen = New CRODIP_ControlLibrary.TBNumeric()
        Me.lblModele_UsureMoyenne = New System.Windows.Forms.Label()
        Me.tbModele_UsureMoyenne = New CRODIP_ControlLibrary.TBNumeric()
        Me.lblModele_DebitNominalPourCalcul = New System.Windows.Forms.Label()
        Me.tbModele_DebitNominalPourCalcul = New CRODIP_ControlLibrary.TBNumeric()
        Me.btnModele_validerNbBuses = New System.Windows.Forms.Label()
        Me.lblModele_DebitNominalConstructeur = New System.Windows.Forms.Label()
        Me.lblModele_EcartTolere = New System.Windows.Forms.Label()
        Me.tbModele_DebitNominalContructeur = New CRODIP_ControlLibrary.TBNumeric()
        Me.LblModele_NombreDeBuses = New System.Windows.Forms.Label()
        Me.tbModele_NombreDeBuses = New CRODIP_ControlLibrary.TBNumeric()
        Me.pblModele_tabMesuresBuses = New System.Windows.Forms.Panel()
        Me.pnlModele_tabMesureSecondaire = New System.Windows.Forms.Panel()
        Me.Panel120 = New System.Windows.Forms.Panel()
        Me.TextBox47 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel119 = New System.Windows.Forms.Panel()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Panel118 = New System.Windows.Forms.Panel()
        Me.TextBox46 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel117 = New System.Windows.Forms.Panel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Panel116 = New System.Windows.Forms.Panel()
        Me.TextBox45 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel115 = New System.Windows.Forms.Panel()
        Me.TextBox44 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel114 = New System.Windows.Forms.Panel()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Panel113 = New System.Windows.Forms.Panel()
        Me.TextBox42 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel112 = New System.Windows.Forms.Panel()
        Me.TextBox41 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel111 = New System.Windows.Forms.Panel()
        Me.TextBox40 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel110 = New System.Windows.Forms.Panel()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Panel109 = New System.Windows.Forms.Panel()
        Me.TextBox39 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel108 = New System.Windows.Forms.Panel()
        Me.TextBox38 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel107 = New System.Windows.Forms.Panel()
        Me.Textbox37 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel106 = New System.Windows.Forms.Panel()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Panel105 = New System.Windows.Forms.Panel()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Panel104 = New System.Windows.Forms.Panel()
        Me.Textbox36 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel103 = New System.Windows.Forms.Panel()
        Me.Textbox35 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel102 = New System.Windows.Forms.Panel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Panel101 = New System.Windows.Forms.Panel()
        Me.Textbox34 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel100 = New System.Windows.Forms.Panel()
        Me.Textbox33 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel99 = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Panel98 = New System.Windows.Forms.Panel()
        Me.Textbox32 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel97 = New System.Windows.Forms.Panel()
        Me.Textbox31 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel67 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel66 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel49 = New System.Windows.Forms.Panel()
        Me.Textbox6 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel38 = New System.Windows.Forms.Panel()
        Me.TextBox5 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel71 = New System.Windows.Forms.Panel()
        Me.diagBuses_mesureDebit_1_debit = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel69 = New System.Windows.Forms.Panel()
        Me.diagBuses_mesureDebit_2_debit = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Panel70 = New System.Windows.Forms.Panel()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Panel68 = New System.Windows.Forms.Panel()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.cbxModele_Marque = New System.Windows.Forms.ComboBox()
        Me.cbxModele_EcartTolere = New System.Windows.Forms.ComboBox()
        Me.TbModele_Calibre = New CRODIP_ControlLibrary.TBNumeric()
        Me.lblModele_DebitMini = New System.Windows.Forms.Label()
        Me.tbModele_DebitMini = New CRODIP_ControlLibrary.TBNumeric()
        Me.lblModele_DebitMaxi = New System.Windows.Forms.Label()
        Me.tbModele_DebitMaxi = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbPressionMesure = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.diagBuses_conf_validNbCategories = New System.Windows.Forms.Label()
        Me.diagBuses_conf_ajouterNiveau = New System.Windows.Forms.Label()
        Me.LaDebitMoyen3bars = New System.Windows.Forms.Label()
        Me.tbDebitMoyen3bars = New CRODIP_ControlLibrary.TBNumeric()
        Me.tabPage_diagnostique_manoTroncon = New System.Windows.Forms.TabPage()
        Me.pnl542 = New System.Windows.Forms.Panel()
        Me.manopulveIsSaisieManuelle = New System.Windows.Forms.RadioButton()
        Me.manopulveIsFortePression = New System.Windows.Forms.RadioButton()
        Me.manoTroncon_listManoControle = New System.Windows.Forms.ComboBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Panel48 = New System.Windows.Forms.Panel()
        Me.Panel292 = New System.Windows.Forms.Panel()
        Me.manopulvePressionImprecision_4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionImprecision_3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionImprecision_2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionImprecision_1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel46 = New System.Windows.Forms.Panel()
        Me.Label224 = New System.Windows.Forms.Label()
        Me.manopulvePression_panel_manoAgent = New System.Windows.Forms.Panel()
        Me.manopulvePressionLue_5 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionControle_1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionLue_7 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionLue_8 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionLue_6 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionControle_4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionControle_3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionControle_2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePression_panel_manoPulve = New System.Windows.Forms.Panel()
        Me.manopulvePressionPulve_1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionPulve_2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionPulve_4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionPulve_3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePression_panel_erreur = New System.Windows.Forms.Panel()
        Me.manopulvePressionEcart_4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionEcart_3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionEcart_2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.manopulvePressionEcart_1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel52 = New System.Windows.Forms.Panel()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Panel53 = New System.Windows.Forms.Panel()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Panel54 = New System.Windows.Forms.Panel()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Lbl_diagnostic_542 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label226 = New System.Windows.Forms.Label()
        Me.manopulveResultat = New System.Windows.Forms.Label()
        Me.manoPulveEcartMoyen = New CRODIP_ControlLibrary.TBNumeric()
        Me.manoPulveEcartMax = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.manopulveIsFaiblePression = New System.Windows.Forms.RadioButton()
        Me.manopulveIsUseCalibrateur = New System.Windows.Forms.CheckBox()
        Me.btnRecalculer = New System.Windows.Forms.Label()
        Me.pnl_833 = New System.Windows.Forms.Panel()
        Me.tab_833 = New System.Windows.Forms.TabControl()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.pressionTronc_20_pressionManoPulve = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbMoyenne4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.pressionTronc_heterogeniteAlimentation4 = New System.Windows.Forms.Label()
        Me.gdvPressions4 = New System.Windows.Forms.DataGridView()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.pressionTronc_DefautEcart4 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.tbMoyEcartPct4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.tbMoyEcartbar4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.pressionTronc_15_pressionManoPulve = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbMoyenne3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.pressionTronc_heterogeniteAlimentation3 = New System.Windows.Forms.Label()
        Me.gdvPressions3 = New System.Windows.Forms.DataGridView()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.pressionTronc_DefautEcart3 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.tbMoyEcartPct3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.tbMoyEcartbar3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pressionTronc_10_pressionManoPulve = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbMoyenne2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.pressionTronc_heterogeniteAlimentation2 = New System.Windows.Forms.Label()
        Me.gdvPressions2 = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pressionTronc_DefautEcart2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.tbMoyEcartPct2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbMoyEcartbar2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pressionTronc_heterogeniteAlimentation1 = New System.Windows.Forms.Label()
        Me.gdvPressions1 = New System.Windows.Forms.DataGridView()
        Me.pressionTronc_5_pressionManoPulve = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pressionTronc_DefautEcart1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbMoyenne1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.tbMoyEcartPct1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.tbMoyEcartbar1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label221 = New System.Windows.Forms.Label()
        Me.Lbl_diagnostic_833 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.nup_niveaux = New System.Windows.Forms.NumericUpDown()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.nupTroncons = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblP833DefautHeterogeneite = New System.Windows.Forms.Label()
        Me.lblp833DefautEcart = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.rbPression1 = New System.Windows.Forms.RadioButton()
        Me.rbPression2 = New System.Windows.Forms.RadioButton()
        Me.rbPression3 = New System.Windows.Forms.RadioButton()
        Me.rbPression4 = New System.Windows.Forms.RadioButton()
        Me.tabPage_diagnostique_rampes = New System.Windows.Forms.TabPage()
        Me.Panel34 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_81 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_815 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8151 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8150 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8152 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_814 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8141 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8140 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8142 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_811 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8112 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8111 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8110 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8113 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8114 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.ico_help_811 = New System.Windows.Forms.PictureBox()
        Me.GroupBox_diagnostic_812 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8121 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8120 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8122 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8123 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8124 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Panel35 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_82 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_821 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8211 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8210 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_822 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8221 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8220 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8222 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_823 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8231 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8230 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8232 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8233 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8234 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_816 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8161 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8160 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8162 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_813 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8131 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8132 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8130 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_817 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8171 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8170 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8172 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Panel36 = New System.Windows.Forms.Panel()
        Me.popup_help_811 = New System.Windows.Forms.Panel()
        Me.Panel123 = New System.Windows.Forms.Panel()
        Me.help811_close = New System.Windows.Forms.Label()
        Me.help811_largeur = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.help811_fleche = New CRODIP_ControlLibrary.TBNumeric()
        Me.help811_result = New System.Windows.Forms.Label()
        Me.Label_diagnostic_83 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_831 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8312 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8311 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8310 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8313 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.ico_help_8312 = New System.Windows.Forms.PictureBox()
        Me.RadioButton_diagnostic_8314 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.ico_help_8314 = New System.Windows.Forms.PictureBox()
        Me.GroupBox_diagnostic_832 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8321 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8320 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8322 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8323 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_833 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_8331 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8330 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8332 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8333 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_8334 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.popup_help_831 = New System.Windows.Forms.Panel()
        Me.Panel125 = New System.Windows.Forms.Panel()
        Me.Label211 = New System.Windows.Forms.Label()
        Me.help831_ecart = New CRODIP_ControlLibrary.TBNumeric()
        Me.help831_close = New System.Windows.Forms.Label()
        Me.help831_result = New System.Windows.Forms.Label()
        Me.help831_ecartementMin = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblPopup831 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.help831_ecartementReference = New CRODIP_ControlLibrary.TBNumeric()
        Me.help831_ecartementMax = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel128 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_8 = New System.Windows.Forms.Label()
        Me.tabPage_diagnostique_mesureCommandesRegulation = New System.Windows.Forms.TabPage()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_55 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_551 = New System.Windows.Forms.GroupBox()
        Me.ico_help_551 = New System.Windows.Forms.PictureBox()
        Me.RadioButton_diagnostic_5511 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5510 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5512 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_552 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5521 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5520 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5522 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.ico_help_552 = New System.Windows.Forms.PictureBox()
        Me.Pctb_calc = New System.Windows.Forms.PictureBox()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_52 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_521 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5211 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5212 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5210 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_522 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5221 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5222 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5220 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5223 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_53 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_531 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5311 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5312 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5310 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_532 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5321 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5322 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5320 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5323 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_51 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_511 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5111 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5112 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5110 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_54 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_541 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5411 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5412 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5410 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5413 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5414 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_542 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5422 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5421 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5420 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5423 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_56 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_561 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5611 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5610 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5612 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_562 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5621 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5620 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5622 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.ico_help_5621 = New System.Windows.Forms.PictureBox()
        Me.ico_help_5622 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox_diagnostic_571 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_5711 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5710 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_5712 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.ico_help_571 = New System.Windows.Forms.PictureBox()
        Me.ico_oeil571 = New System.Windows.Forms.PictureBox()
        Me.Label_diagnostic_57 = New System.Windows.Forms.Label()
        Me.Panel127 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_5 = New System.Windows.Forms.Label()
        Me.tab_diagnostique = New System.Windows.Forms.TabControl()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tabPage_diagnostique_accessoires.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.GroupBox_diagnostic_1231.SuspendLayout()
        Me.GroupBox_diagnostic_1232.SuspendLayout()
        CType(Me.ico_help12323, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        Me.GroupBox_diagnostic_1221.SuspendLayout()
        Me.GroupBox_diagnostic_1222.SuspendLayout()
        Me.GroupBox_diagnostic_1241.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.GroupBox_diagnostic_1111.SuspendLayout()
        Me.GroupBox_diagnostic_1112.SuspendLayout()
        Me.GroupBox_diagnostic_1113.SuspendLayout()
        Me.GroupBox_diagnostic_1114.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.GroupBox_diagnostic_1211.SuspendLayout()
        Me.GroupBox_diagnostic_1212.SuspendLayout()
        CType(Me.ico_help_12123, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_diagnostic_1213.SuspendLayout()
        Me.tabPage_diagnostique_buses.SuspendLayout()
        Me.Panel63.SuspendLayout()
        Me.Panel922.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.diagBuses_tab_categories.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.pblModele_tabMesuresBuses.SuspendLayout()
        Me.pnlModele_tabMesureSecondaire.SuspendLayout()
        Me.Panel120.SuspendLayout()
        Me.Panel119.SuspendLayout()
        Me.Panel118.SuspendLayout()
        Me.Panel117.SuspendLayout()
        Me.Panel116.SuspendLayout()
        Me.Panel115.SuspendLayout()
        Me.Panel114.SuspendLayout()
        Me.Panel113.SuspendLayout()
        Me.Panel112.SuspendLayout()
        Me.Panel111.SuspendLayout()
        Me.Panel110.SuspendLayout()
        Me.Panel109.SuspendLayout()
        Me.Panel108.SuspendLayout()
        Me.Panel107.SuspendLayout()
        Me.Panel106.SuspendLayout()
        Me.Panel105.SuspendLayout()
        Me.Panel104.SuspendLayout()
        Me.Panel103.SuspendLayout()
        Me.Panel102.SuspendLayout()
        Me.Panel101.SuspendLayout()
        Me.Panel100.SuspendLayout()
        Me.Panel99.SuspendLayout()
        Me.Panel98.SuspendLayout()
        Me.Panel97.SuspendLayout()
        Me.Panel67.SuspendLayout()
        Me.Panel66.SuspendLayout()
        Me.Panel49.SuspendLayout()
        Me.Panel38.SuspendLayout()
        Me.Panel71.SuspendLayout()
        Me.Panel69.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel70.SuspendLayout()
        Me.Panel68.SuspendLayout()
        Me.tabPage_diagnostique_manoTroncon.SuspendLayout()
        Me.pnl542.SuspendLayout()
        Me.Panel48.SuspendLayout()
        Me.Panel292.SuspendLayout()
        Me.Panel46.SuspendLayout()
        Me.manopulvePression_panel_manoAgent.SuspendLayout()
        Me.manopulvePression_panel_manoPulve.SuspendLayout()
        Me.manopulvePression_panel_erreur.SuspendLayout()
        Me.Panel52.SuspendLayout()
        Me.Panel53.SuspendLayout()
        Me.Panel54.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pnl_833.SuspendLayout()
        Me.tab_833.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        CType(Me.gdvPressions4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        CType(Me.gdvPressions3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.gdvPressions2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gdvPressions1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.nup_niveaux, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupTroncons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage_diagnostique_rampes.SuspendLayout()
        Me.Panel34.SuspendLayout()
        Me.GroupBox_diagnostic_815.SuspendLayout()
        Me.GroupBox_diagnostic_814.SuspendLayout()
        Me.GroupBox_diagnostic_811.SuspendLayout()
        CType(Me.ico_help_811, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_diagnostic_812.SuspendLayout()
        Me.Panel35.SuspendLayout()
        Me.GroupBox_diagnostic_821.SuspendLayout()
        Me.GroupBox_diagnostic_822.SuspendLayout()
        Me.GroupBox_diagnostic_823.SuspendLayout()
        Me.GroupBox_diagnostic_816.SuspendLayout()
        Me.GroupBox_diagnostic_813.SuspendLayout()
        Me.GroupBox_diagnostic_817.SuspendLayout()
        Me.Panel36.SuspendLayout()
        Me.popup_help_811.SuspendLayout()
        Me.Panel123.SuspendLayout()
        Me.GroupBox_diagnostic_831.SuspendLayout()
        CType(Me.ico_help_8312, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ico_help_8314, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_diagnostic_832.SuspendLayout()
        Me.GroupBox_diagnostic_833.SuspendLayout()
        Me.popup_help_831.SuspendLayout()
        Me.Panel125.SuspendLayout()
        Me.Panel128.SuspendLayout()
        Me.tabPage_diagnostique_mesureCommandesRegulation.SuspendLayout()
        Me.Panel25.SuspendLayout()
        Me.GroupBox_diagnostic_551.SuspendLayout()
        CType(Me.ico_help_551, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_diagnostic_552.SuspendLayout()
        CType(Me.ico_help_552, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pctb_calc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel22.SuspendLayout()
        Me.GroupBox_diagnostic_521.SuspendLayout()
        Me.GroupBox_diagnostic_522.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.GroupBox_diagnostic_531.SuspendLayout()
        Me.GroupBox_diagnostic_532.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.GroupBox_diagnostic_511.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.GroupBox_diagnostic_541.SuspendLayout()
        Me.GroupBox_diagnostic_542.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.GroupBox_diagnostic_561.SuspendLayout()
        Me.GroupBox_diagnostic_562.SuspendLayout()
        CType(Me.ico_help_5621, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ico_help_5622, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_diagnostic_571.SuspendLayout()
        CType(Me.ico_help_571, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ico_oeil571, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel127.SuspendLayout()
        Me.tab_diagnostique.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList_onglets
        '
        Me.ImageList_onglets.ImageStream = CType(resources.GetObject("ImageList_onglets.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_onglets.TransparentColor = System.Drawing.Color.White
        Me.ImageList_onglets.Images.SetKeyName(0, "")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem1.ShowShortcutKeys = False
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(60, 22)
        '
        'listImg_flags
        '
        Me.listImg_flags.ImageStream = CType(resources.GetObject("listImg_flags.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.listImg_flags.TransparentColor = System.Drawing.Color.Transparent
        Me.listImg_flags.Images.SetKeyName(0, "")
        Me.listImg_flags.Images.SetKeyName(1, "")
        Me.listImg_flags.Images.SetKeyName(2, "")
        Me.listImg_flags.Images.SetKeyName(3, "")
        '
        'ToolTip_diagnostic_numRadioButtons
        '
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(32, 33)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton1.TabIndex = 193
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'btn_Valider
        '
        Me.btn_Valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Valider.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_Valider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Valider.ForeColor = System.Drawing.Color.White
        Me.btn_Valider.Image = Global.Crodip_agent.Resources.btn_valider
        Me.btn_Valider.Location = New System.Drawing.Point(729, 40)
        Me.btn_Valider.Name = "btn_Valider"
        Me.btn_Valider.Size = New System.Drawing.Size(139, 32)
        Me.btn_Valider.TabIndex = 28
        Me.btn_Valider.TabStop = False
        Me.btn_Valider.Text = "Valider"
        Me.btn_Valider.UseVisualStyleBackColor = True
        '
        'btn_annuler
        '
        Me.btn_annuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_annuler.Image = Global.Crodip_agent.Resources.btn_annuler
        Me.btn_annuler.Location = New System.Drawing.Point(729, 74)
        Me.btn_annuler.Name = "btn_annuler"
        Me.btn_annuler.Size = New System.Drawing.Size(139, 32)
        Me.btn_annuler.TabIndex = 29
        Me.btn_annuler.Text = "Annuler"
        Me.btn_annuler.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btn_annuler)
        Me.Panel2.Controls.Add(Me.btn_Valider)
        Me.Panel2.Controls.Add(Me.btn_Poursuivre)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Location = New System.Drawing.Point(4, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1008, 113)
        Me.Panel2.TabIndex = 1
        '
        'btn_Poursuivre
        '
        Me.btn_Poursuivre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Poursuivre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Poursuivre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Poursuivre.ForeColor = System.Drawing.Color.White
        Me.btn_Poursuivre.Image = Global.Crodip_agent.Resources.btn_suivant
        Me.btn_Poursuivre.Location = New System.Drawing.Point(729, 6)
        Me.btn_Poursuivre.Name = "btn_Poursuivre"
        Me.btn_Poursuivre.Size = New System.Drawing.Size(139, 32)
        Me.btn_Poursuivre.TabIndex = 27
        Me.btn_Poursuivre.Text = "Poursuivre"
        Me.btn_Poursuivre.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(912, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 84)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.diag_client_proprioSiren)
        Me.GroupBox1.Controls.Add(Me.diag_client_raisonSociale)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Client"
        '
        'diag_client_proprioSiren
        '
        Me.diag_client_proprioSiren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diag_client_proprioSiren.Location = New System.Drawing.Point(8, 40)
        Me.diag_client_proprioSiren.Name = "diag_client_proprioSiren"
        Me.diag_client_proprioSiren.Size = New System.Drawing.Size(296, 24)
        Me.diag_client_proprioSiren.TabIndex = 1
        Me.diag_client_proprioSiren.Text = "M. Nom Prenom - N° SIREN : 17756237125"
        '
        'diag_client_raisonSociale
        '
        Me.diag_client_raisonSociale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diag_client_raisonSociale.Location = New System.Drawing.Point(8, 16)
        Me.diag_client_raisonSociale.Name = "diag_client_raisonSociale"
        Me.diag_client_raisonSociale.Size = New System.Drawing.Size(296, 16)
        Me.diag_client_raisonSociale.TabIndex = 0
        Me.diag_client_raisonSociale.Text = "Raison sociale Exploitation"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.diag_pulve_Type)
        Me.GroupBox2.Controls.Add(Me.Label117)
        Me.GroupBox2.Controls.Add(Me.diag_pulve_marqueModele)
        Me.GroupBox2.Controls.Add(Me.diag_pulve_numNatio)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(368, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 69)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pulvérisateur"
        '
        'diag_pulve_Type
        '
        Me.diag_pulve_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diag_pulve_Type.Location = New System.Drawing.Point(129, 46)
        Me.diag_pulve_Type.Name = "diag_pulve_Type"
        Me.diag_pulve_Type.Size = New System.Drawing.Size(176, 16)
        Me.diag_pulve_Type.TabIndex = 7
        Me.diag_pulve_Type.Text = "Type Pulvé"
        '
        'Label117
        '
        Me.Label117.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label117.Location = New System.Drawing.Point(20, 48)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(104, 16)
        Me.Label117.TabIndex = 6
        Me.Label117.Text = "Type Pulvé : "
        '
        'diag_pulve_marqueModele
        '
        Me.diag_pulve_marqueModele.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diag_pulve_marqueModele.Location = New System.Drawing.Point(128, 30)
        Me.diag_pulve_marqueModele.Name = "diag_pulve_marqueModele"
        Me.diag_pulve_marqueModele.Size = New System.Drawing.Size(176, 16)
        Me.diag_pulve_marqueModele.TabIndex = 5
        Me.diag_pulve_marqueModele.Text = "Marque-Modèle Pulvé"
        '
        'diag_pulve_numNatio
        '
        Me.diag_pulve_numNatio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diag_pulve_numNatio.Location = New System.Drawing.Point(130, 14)
        Me.diag_pulve_numNatio.Name = "diag_pulve_numNatio"
        Me.diag_pulve_numNatio.Size = New System.Drawing.Size(176, 16)
        Me.diag_pulve_numNatio.TabIndex = 4
        Me.diag_pulve_numNatio.Text = "Num pulvé"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Marque modèle : "
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Num. National : "
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel1.Controls.Add(Me.tab_diagnostique)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1016, 680)
        Me.Panel1.TabIndex = 1
        '
        'tabPage_diagnostique_accessoires
        '
        Me.tabPage_diagnostique_accessoires.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabPage_diagnostique_accessoires.Controls.Add(Me.Panel8)
        Me.tabPage_diagnostique_accessoires.ImageIndex = 3
        Me.tabPage_diagnostique_accessoires.Location = New System.Drawing.Point(4, 23)
        Me.tabPage_diagnostique_accessoires.Name = "tabPage_diagnostique_accessoires"
        Me.tabPage_diagnostique_accessoires.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage_diagnostique_accessoires.Size = New System.Drawing.Size(1008, 653)
        Me.tabPage_diagnostique_accessoires.TabIndex = 8
        Me.tabPage_diagnostique_accessoires.Text = "Accessoires"
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Controls.Add(Me.Panel14)
        Me.Panel8.Controls.Add(Me.Panel16)
        Me.Panel8.Controls.Add(Me.Label_diagnostic_11)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.Label_diagnostic_12)
        Me.Panel8.Location = New System.Drawing.Point(0, 115)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1008, 539)
        Me.Panel8.TabIndex = 22
        '
        'Label_diagnostic_12
        '
        Me.Label_diagnostic_12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_12.Image = CType(resources.GetObject("Label_diagnostic_12.Image"), System.Drawing.Image)
        Me.Label_diagnostic_12.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_12.Location = New System.Drawing.Point(6, 167)
        Me.Label_diagnostic_12.Name = "Label_diagnostic_12"
        Me.Label_diagnostic_12.Size = New System.Drawing.Size(996, 24)
        Me.Label_diagnostic_12.TabIndex = 20
        Me.Label_diagnostic_12.Text = "     12. Accessoires"
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel10.Controls.Add(Me.GroupBox_diagnostic_1232)
        Me.Panel10.Controls.Add(Me.Label_diagnostic_123)
        Me.Panel10.Controls.Add(Me.GroupBox_diagnostic_1231)
        Me.Panel10.Location = New System.Drawing.Point(632, 186)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(368, 343)
        Me.Panel10.TabIndex = 22
        '
        'GroupBox_diagnostic_1231
        '
        Me.GroupBox_diagnostic_1231.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12317)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12318)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12315)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12316)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12313)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12314)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12311)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12310)
        Me.GroupBox_diagnostic_1231.Controls.Add(Me.RadioButton_diagnostic_12312)
        Me.GroupBox_diagnostic_1231.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1231.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1231.Location = New System.Drawing.Point(3, 26)
        Me.GroupBox_diagnostic_1231.Name = "GroupBox_diagnostic_1231"
        Me.GroupBox_diagnostic_1231.Size = New System.Drawing.Size(344, 186)
        Me.GroupBox_diagnostic_1231.TabIndex = 0
        Me.GroupBox_diagnostic_1231.TabStop = False
        Me.GroupBox_diagnostic_1231.Text = "12.3.1 - Etat"
        '
        'RadioButton_diagnostic_12312
        '
        Me.RadioButton_diagnostic_12312.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12312.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12312.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12312.cause1 = False
        Me.RadioButton_diagnostic_12312.cause2 = False
        Me.RadioButton_diagnostic_12312.cause3 = False
        Me.RadioButton_diagnostic_12312.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12312.Checked = False
        Me.RadioButton_diagnostic_12312.Code = Nothing
        Me.RadioButton_diagnostic_12312.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12312.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12312.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12312.Libelle = "12.3.1.2 - Déformation majeure"
        Me.RadioButton_diagnostic_12312.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12312.Location = New System.Drawing.Point(10, 28)
        Me.RadioButton_diagnostic_12312.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12312.Name = "RadioButton_diagnostic_12312"
        Me.RadioButton_diagnostic_12312.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12312.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12312.TabIndex = 1
        '
        'RadioButton_diagnostic_12310
        '
        Me.RadioButton_diagnostic_12310.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12310.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12310.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12310.cause1 = False
        Me.RadioButton_diagnostic_12310.cause2 = False
        Me.RadioButton_diagnostic_12310.cause3 = False
        Me.RadioButton_diagnostic_12310.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12310.Checked = False
        Me.RadioButton_diagnostic_12310.Code = Nothing
        Me.RadioButton_diagnostic_12310.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12310.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12310.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12310.Libelle = "OK"
        Me.RadioButton_diagnostic_12310.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12310.Location = New System.Drawing.Point(10, 167)
        Me.RadioButton_diagnostic_12310.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12310.Name = "RadioButton_diagnostic_12310"
        Me.RadioButton_diagnostic_12310.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12310.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12310.TabIndex = 8
        '
        'RadioButton_diagnostic_12311
        '
        Me.RadioButton_diagnostic_12311.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12311.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12311.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12311.cause1 = False
        Me.RadioButton_diagnostic_12311.cause2 = False
        Me.RadioButton_diagnostic_12311.cause3 = False
        Me.RadioButton_diagnostic_12311.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12311.Checked = False
        Me.RadioButton_diagnostic_12311.Code = Nothing
        Me.RadioButton_diagnostic_12311.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12311.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12311.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12311.Libelle = "12.3.1.1 - Déformation mineure"
        Me.RadioButton_diagnostic_12311.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12311.Location = New System.Drawing.Point(10, 12)
        Me.RadioButton_diagnostic_12311.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12311.Name = "RadioButton_diagnostic_12311"
        Me.RadioButton_diagnostic_12311.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12311.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12311.TabIndex = 0
        '
        'RadioButton_diagnostic_12314
        '
        Me.RadioButton_diagnostic_12314.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12314.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12314.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12314.cause1 = False
        Me.RadioButton_diagnostic_12314.cause2 = False
        Me.RadioButton_diagnostic_12314.cause3 = False
        Me.RadioButton_diagnostic_12314.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12314.Checked = False
        Me.RadioButton_diagnostic_12314.Code = Nothing
        Me.RadioButton_diagnostic_12314.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12314.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12314.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12314.Libelle = "12.3.1.4 - Lésion majeure"
        Me.RadioButton_diagnostic_12314.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12314.Location = New System.Drawing.Point(10, 60)
        Me.RadioButton_diagnostic_12314.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12314.Name = "RadioButton_diagnostic_12314"
        Me.RadioButton_diagnostic_12314.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12314.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12314.TabIndex = 3
        '
        'RadioButton_diagnostic_12313
        '
        Me.RadioButton_diagnostic_12313.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12313.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12313.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12313.cause1 = False
        Me.RadioButton_diagnostic_12313.cause2 = False
        Me.RadioButton_diagnostic_12313.cause3 = False
        Me.RadioButton_diagnostic_12313.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12313.Checked = False
        Me.RadioButton_diagnostic_12313.Code = Nothing
        Me.RadioButton_diagnostic_12313.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12313.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12313.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12313.Libelle = "12.3.1.3 - Lésion mineure"
        Me.RadioButton_diagnostic_12313.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12313.Location = New System.Drawing.Point(10, 44)
        Me.RadioButton_diagnostic_12313.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12313.Name = "RadioButton_diagnostic_12313"
        Me.RadioButton_diagnostic_12313.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12313.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12313.TabIndex = 2
        '
        'RadioButton_diagnostic_12316
        '
        Me.RadioButton_diagnostic_12316.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12316.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12316.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12316.cause1 = False
        Me.RadioButton_diagnostic_12316.cause2 = False
        Me.RadioButton_diagnostic_12316.cause3 = False
        Me.RadioButton_diagnostic_12316.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12316.Checked = False
        Me.RadioButton_diagnostic_12316.Code = Nothing
        Me.RadioButton_diagnostic_12316.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12316.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12316.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12316.Libelle = "12.3.1.6 - Lésion aux soudures majeure"
        Me.RadioButton_diagnostic_12316.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12316.Location = New System.Drawing.Point(10, 92)
        Me.RadioButton_diagnostic_12316.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12316.Name = "RadioButton_diagnostic_12316"
        Me.RadioButton_diagnostic_12316.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12316.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12316.TabIndex = 5
        '
        'RadioButton_diagnostic_12315
        '
        Me.RadioButton_diagnostic_12315.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12315.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12315.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12315.cause1 = False
        Me.RadioButton_diagnostic_12315.cause2 = False
        Me.RadioButton_diagnostic_12315.cause3 = False
        Me.RadioButton_diagnostic_12315.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12315.Checked = False
        Me.RadioButton_diagnostic_12315.Code = Nothing
        Me.RadioButton_diagnostic_12315.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12315.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12315.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12315.Libelle = "12.3.1.5 - Lésion aux soudures mineure"
        Me.RadioButton_diagnostic_12315.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12315.Location = New System.Drawing.Point(10, 76)
        Me.RadioButton_diagnostic_12315.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12315.Name = "RadioButton_diagnostic_12315"
        Me.RadioButton_diagnostic_12315.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12315.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12315.TabIndex = 4
        '
        'RadioButton_diagnostic_12318
        '
        Me.RadioButton_diagnostic_12318.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12318.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12318.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12318.cause1 = False
        Me.RadioButton_diagnostic_12318.cause2 = False
        Me.RadioButton_diagnostic_12318.cause3 = False
        Me.RadioButton_diagnostic_12318.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12318.Checked = False
        Me.RadioButton_diagnostic_12318.Code = Nothing
        Me.RadioButton_diagnostic_12318.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12318.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12318.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12318.Libelle = "12.3.1.8 - Corosion majeure"
        Me.RadioButton_diagnostic_12318.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12318.Location = New System.Drawing.Point(10, 124)
        Me.RadioButton_diagnostic_12318.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12318.Name = "RadioButton_diagnostic_12318"
        Me.RadioButton_diagnostic_12318.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12318.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12318.TabIndex = 7
        '
        'RadioButton_diagnostic_12317
        '
        Me.RadioButton_diagnostic_12317.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12317.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12317.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12317.cause1 = False
        Me.RadioButton_diagnostic_12317.cause2 = False
        Me.RadioButton_diagnostic_12317.cause3 = False
        Me.RadioButton_diagnostic_12317.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12317.Checked = False
        Me.RadioButton_diagnostic_12317.Code = Nothing
        Me.RadioButton_diagnostic_12317.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12317.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12317.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12317.Libelle = "12.3.1.7 - Corosion mineure"
        Me.RadioButton_diagnostic_12317.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12317.Location = New System.Drawing.Point(10, 108)
        Me.RadioButton_diagnostic_12317.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12317.Name = "RadioButton_diagnostic_12317"
        Me.RadioButton_diagnostic_12317.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12317.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12317.TabIndex = 6
        '
        'Label_diagnostic_123
        '
        Me.Label_diagnostic_123.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_123.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_123.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_123.Image = CType(resources.GetObject("Label_diagnostic_123.Image"), System.Drawing.Image)
        Me.Label_diagnostic_123.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_123.Location = New System.Drawing.Point(5, 2)
        Me.Label_diagnostic_123.Name = "Label_diagnostic_123"
        Me.Label_diagnostic_123.Size = New System.Drawing.Size(343, 16)
        Me.Label_diagnostic_123.TabIndex = 14
        Me.Label_diagnostic_123.Text = "     Chariot de pulvérisation"
        '
        'GroupBox_diagnostic_1232
        '
        Me.GroupBox_diagnostic_1232.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_1232.Controls.Add(Me.ico_help12323)
        Me.GroupBox_diagnostic_1232.Controls.Add(Me.RadioButton_diagnostic_12323)
        Me.GroupBox_diagnostic_1232.Controls.Add(Me.RadioButton_diagnostic_12324)
        Me.GroupBox_diagnostic_1232.Controls.Add(Me.RadioButton_diagnostic_12321)
        Me.GroupBox_diagnostic_1232.Controls.Add(Me.RadioButton_diagnostic_12320)
        Me.GroupBox_diagnostic_1232.Controls.Add(Me.RadioButton_diagnostic_12322)
        Me.GroupBox_diagnostic_1232.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1232.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1232.Location = New System.Drawing.Point(4, 221)
        Me.GroupBox_diagnostic_1232.Name = "GroupBox_diagnostic_1232"
        Me.GroupBox_diagnostic_1232.Size = New System.Drawing.Size(344, 115)
        Me.GroupBox_diagnostic_1232.TabIndex = 1
        Me.GroupBox_diagnostic_1232.TabStop = False
        Me.GroupBox_diagnostic_1232.Text = "12.3.2 - Fonctionnement"
        '
        'RadioButton_diagnostic_12322
        '
        Me.RadioButton_diagnostic_12322.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12322.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12322.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12322.cause1 = False
        Me.RadioButton_diagnostic_12322.cause2 = False
        Me.RadioButton_diagnostic_12322.cause3 = False
        Me.RadioButton_diagnostic_12322.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12322.Checked = False
        Me.RadioButton_diagnostic_12322.Code = Nothing
        Me.RadioButton_diagnostic_12322.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12322.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12322.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12322.Libelle = "12.3.2.2 - Dispositif d'entrainement détérioré"
        Me.RadioButton_diagnostic_12322.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12322.Location = New System.Drawing.Point(10, 32)
        Me.RadioButton_diagnostic_12322.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12322.Name = "RadioButton_diagnostic_12322"
        Me.RadioButton_diagnostic_12322.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12322.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12322.TabIndex = 1
        '
        'RadioButton_diagnostic_12320
        '
        Me.RadioButton_diagnostic_12320.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12320.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12320.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12320.cause1 = False
        Me.RadioButton_diagnostic_12320.cause2 = False
        Me.RadioButton_diagnostic_12320.cause3 = False
        Me.RadioButton_diagnostic_12320.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12320.Checked = False
        Me.RadioButton_diagnostic_12320.Code = Nothing
        Me.RadioButton_diagnostic_12320.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12320.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12320.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12320.Libelle = "OK"
        Me.RadioButton_diagnostic_12320.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12320.Location = New System.Drawing.Point(10, 96)
        Me.RadioButton_diagnostic_12320.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12320.Name = "RadioButton_diagnostic_12320"
        Me.RadioButton_diagnostic_12320.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12320.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12320.TabIndex = 4
        '
        'RadioButton_diagnostic_12321
        '
        Me.RadioButton_diagnostic_12321.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12321.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12321.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12321.cause1 = False
        Me.RadioButton_diagnostic_12321.cause2 = False
        Me.RadioButton_diagnostic_12321.cause3 = False
        Me.RadioButton_diagnostic_12321.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12321.Checked = False
        Me.RadioButton_diagnostic_12321.Code = Nothing
        Me.RadioButton_diagnostic_12321.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12321.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12321.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12321.Libelle = "12.3.2.1 - Dispositif de déplacement détérioré"
        Me.RadioButton_diagnostic_12321.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12321.Location = New System.Drawing.Point(10, 16)
        Me.RadioButton_diagnostic_12321.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12321.Name = "RadioButton_diagnostic_12321"
        Me.RadioButton_diagnostic_12321.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12321.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12321.TabIndex = 0
        '
        'RadioButton_diagnostic_12324
        '
        Me.RadioButton_diagnostic_12324.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12324.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12324.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12324.cause1 = False
        Me.RadioButton_diagnostic_12324.cause2 = False
        Me.RadioButton_diagnostic_12324.cause3 = False
        Me.RadioButton_diagnostic_12324.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12324.Checked = False
        Me.RadioButton_diagnostic_12324.Code = Nothing
        Me.RadioButton_diagnostic_12324.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12324.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12324.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12324.Libelle = "12.3.2.4 - Dispositif d'ouveture / fermeture de la pulvérisation détérioré"
        Me.RadioButton_diagnostic_12324.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12324.Location = New System.Drawing.Point(10, 70)
        Me.RadioButton_diagnostic_12324.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12324.Name = "RadioButton_diagnostic_12324"
        Me.RadioButton_diagnostic_12324.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12324.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12324.TabIndex = 3
        '
        'RadioButton_diagnostic_12323
        '
        Me.RadioButton_diagnostic_12323.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12323.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12323.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12323.cause1 = False
        Me.RadioButton_diagnostic_12323.cause2 = False
        Me.RadioButton_diagnostic_12323.cause3 = False
        Me.RadioButton_diagnostic_12323.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12323.Checked = False
        Me.RadioButton_diagnostic_12323.Code = Nothing
        Me.RadioButton_diagnostic_12323.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12323.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12323.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12323.Libelle = "12.3.2.3 - Disposisitif de la programmation de la vitesse détérioré"
        Me.RadioButton_diagnostic_12323.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12323.Location = New System.Drawing.Point(10, 51)
        Me.RadioButton_diagnostic_12323.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12323.Name = "RadioButton_diagnostic_12323"
        Me.RadioButton_diagnostic_12323.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12323.Size = New System.Drawing.Size(326, 16)
        Me.RadioButton_diagnostic_12323.TabIndex = 2
        '
        'ico_help12323
        '
        Me.ico_help12323.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ico_help12323.BackColor = System.Drawing.Color.Transparent
        Me.ico_help12323.Image = CType(resources.GetObject("ico_help12323.Image"), System.Drawing.Image)
        Me.ico_help12323.Location = New System.Drawing.Point(295, 47)
        Me.ico_help12323.Name = "ico_help12323"
        Me.ico_help12323.Size = New System.Drawing.Size(20, 20)
        Me.ico_help12323.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ico_help12323.TabIndex = 11
        Me.ico_help12323.TabStop = False
        '
        'Label_diagnostic_11
        '
        Me.Label_diagnostic_11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_11.Image = CType(resources.GetObject("Label_diagnostic_11.Image"), System.Drawing.Image)
        Me.Label_diagnostic_11.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_11.Location = New System.Drawing.Point(6, 16)
        Me.Label_diagnostic_11.Name = "Label_diagnostic_11"
        Me.Label_diagnostic_11.Size = New System.Drawing.Size(994, 24)
        Me.Label_diagnostic_11.TabIndex = 23
        Me.Label_diagnostic_11.Text = "     11. Sécurité routière"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel16.Controls.Add(Me.Label_diagnostic_124)
        Me.Panel16.Controls.Add(Me.GroupBox_diagnostic_1241)
        Me.Panel16.Controls.Add(Me.GroupBox_diagnostic_1222)
        Me.Panel16.Controls.Add(Me.Label_diagnostic_122)
        Me.Panel16.Controls.Add(Me.GroupBox_diagnostic_1221)
        Me.Panel16.Location = New System.Drawing.Point(308, 192)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(318, 337)
        Me.Panel16.TabIndex = 22
        '
        'GroupBox_diagnostic_1221
        '
        Me.GroupBox_diagnostic_1221.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_1221.Controls.Add(Me.RadioButton_diagnostic_12212)
        Me.GroupBox_diagnostic_1221.Controls.Add(Me.RadioButton_diagnostic_12213)
        Me.GroupBox_diagnostic_1221.Controls.Add(Me.RadioButton_diagnostic_12210)
        Me.GroupBox_diagnostic_1221.Controls.Add(Me.RadioButton_diagnostic_12211)
        Me.GroupBox_diagnostic_1221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1221.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1221.Location = New System.Drawing.Point(4, 28)
        Me.GroupBox_diagnostic_1221.Name = "GroupBox_diagnostic_1221"
        Me.GroupBox_diagnostic_1221.Size = New System.Drawing.Size(311, 85)
        Me.GroupBox_diagnostic_1221.TabIndex = 0
        Me.GroupBox_diagnostic_1221.TabStop = False
        Me.GroupBox_diagnostic_1221.Text = "12.2.1 - Etat"
        '
        'RadioButton_diagnostic_12211
        '
        Me.RadioButton_diagnostic_12211.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12211.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12211.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12211.cause1 = False
        Me.RadioButton_diagnostic_12211.cause2 = False
        Me.RadioButton_diagnostic_12211.cause3 = False
        Me.RadioButton_diagnostic_12211.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12211.Checked = False
        Me.RadioButton_diagnostic_12211.Code = Nothing
        Me.RadioButton_diagnostic_12211.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12211.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12211.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12211.Libelle = "12.2.1.1 - Dispositif d'arrêt et ouverture détérioré"
        Me.RadioButton_diagnostic_12211.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12211.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_12211.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12211.Name = "RadioButton_diagnostic_12211"
        Me.RadioButton_diagnostic_12211.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12211.Size = New System.Drawing.Size(293, 16)
        Me.RadioButton_diagnostic_12211.TabIndex = 0
        '
        'RadioButton_diagnostic_12210
        '
        Me.RadioButton_diagnostic_12210.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12210.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12210.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12210.cause1 = False
        Me.RadioButton_diagnostic_12210.cause2 = False
        Me.RadioButton_diagnostic_12210.cause3 = False
        Me.RadioButton_diagnostic_12210.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12210.Checked = False
        Me.RadioButton_diagnostic_12210.Code = Nothing
        Me.RadioButton_diagnostic_12210.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12210.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12210.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12210.Libelle = "OK"
        Me.RadioButton_diagnostic_12210.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12210.Location = New System.Drawing.Point(10, 66)
        Me.RadioButton_diagnostic_12210.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12210.Name = "RadioButton_diagnostic_12210"
        Me.RadioButton_diagnostic_12210.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12210.Size = New System.Drawing.Size(293, 16)
        Me.RadioButton_diagnostic_12210.TabIndex = 3
        '
        'RadioButton_diagnostic_12213
        '
        Me.RadioButton_diagnostic_12213.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12213.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12213.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12213.cause1 = False
        Me.RadioButton_diagnostic_12213.cause2 = False
        Me.RadioButton_diagnostic_12213.cause3 = False
        Me.RadioButton_diagnostic_12213.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12213.Checked = False
        Me.RadioButton_diagnostic_12213.Code = Nothing
        Me.RadioButton_diagnostic_12213.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12213.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12213.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12213.Libelle = "12.2.1.3 - Vérrouillage défectueux"
        Me.RadioButton_diagnostic_12213.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12213.Location = New System.Drawing.Point(10, 46)
        Me.RadioButton_diagnostic_12213.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12213.Name = "RadioButton_diagnostic_12213"
        Me.RadioButton_diagnostic_12213.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12213.Size = New System.Drawing.Size(293, 16)
        Me.RadioButton_diagnostic_12213.TabIndex = 2
        '
        'RadioButton_diagnostic_12212
        '
        Me.RadioButton_diagnostic_12212.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12212.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12212.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12212.cause1 = False
        Me.RadioButton_diagnostic_12212.cause2 = False
        Me.RadioButton_diagnostic_12212.cause3 = False
        Me.RadioButton_diagnostic_12212.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12212.Checked = False
        Me.RadioButton_diagnostic_12212.Code = Nothing
        Me.RadioButton_diagnostic_12212.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12212.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12212.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12212.Libelle = "12.2.1.2 - Gâchette défectueuse"
        Me.RadioButton_diagnostic_12212.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12212.Location = New System.Drawing.Point(10, 30)
        Me.RadioButton_diagnostic_12212.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12212.Name = "RadioButton_diagnostic_12212"
        Me.RadioButton_diagnostic_12212.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12212.Size = New System.Drawing.Size(293, 16)
        Me.RadioButton_diagnostic_12212.TabIndex = 1
        '
        'Label_diagnostic_122
        '
        Me.Label_diagnostic_122.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_122.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_122.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_122.Image = CType(resources.GetObject("Label_diagnostic_122.Image"), System.Drawing.Image)
        Me.Label_diagnostic_122.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_122.Location = New System.Drawing.Point(4, 8)
        Me.Label_diagnostic_122.Name = "Label_diagnostic_122"
        Me.Label_diagnostic_122.Size = New System.Drawing.Size(311, 16)
        Me.Label_diagnostic_122.TabIndex = 15
        Me.Label_diagnostic_122.Text = "     Pistolet ou lance"
        '
        'GroupBox_diagnostic_1222
        '
        Me.GroupBox_diagnostic_1222.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_1222.Controls.Add(Me.RadioButton_diagnostic_12220)
        Me.GroupBox_diagnostic_1222.Controls.Add(Me.RadioButton_diagnostic_12221)
        Me.GroupBox_diagnostic_1222.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1222.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1222.Location = New System.Drawing.Point(4, 129)
        Me.GroupBox_diagnostic_1222.Name = "GroupBox_diagnostic_1222"
        Me.GroupBox_diagnostic_1222.Size = New System.Drawing.Size(311, 57)
        Me.GroupBox_diagnostic_1222.TabIndex = 1
        Me.GroupBox_diagnostic_1222.TabStop = False
        Me.GroupBox_diagnostic_1222.Text = "12.2.2 - Fonctionnement"
        '
        'RadioButton_diagnostic_12221
        '
        Me.RadioButton_diagnostic_12221.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12221.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12221.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12221.cause1 = False
        Me.RadioButton_diagnostic_12221.cause2 = False
        Me.RadioButton_diagnostic_12221.cause3 = False
        Me.RadioButton_diagnostic_12221.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12221.Checked = False
        Me.RadioButton_diagnostic_12221.Code = Nothing
        Me.RadioButton_diagnostic_12221.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12221.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12221.Libelle = "12.2.2.1 - Réglage du débit non fonctionnel"
        Me.RadioButton_diagnostic_12221.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12221.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_12221.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12221.Name = "RadioButton_diagnostic_12221"
        Me.RadioButton_diagnostic_12221.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12221.Size = New System.Drawing.Size(293, 22)
        Me.RadioButton_diagnostic_12221.TabIndex = 0
        '
        'RadioButton_diagnostic_12220
        '
        Me.RadioButton_diagnostic_12220.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12220.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12220.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12220.cause1 = False
        Me.RadioButton_diagnostic_12220.cause2 = False
        Me.RadioButton_diagnostic_12220.cause3 = False
        Me.RadioButton_diagnostic_12220.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12220.Checked = False
        Me.RadioButton_diagnostic_12220.Code = Nothing
        Me.RadioButton_diagnostic_12220.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12220.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12220.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12220.Libelle = "OK"
        Me.RadioButton_diagnostic_12220.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12220.Location = New System.Drawing.Point(10, 38)
        Me.RadioButton_diagnostic_12220.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12220.Name = "RadioButton_diagnostic_12220"
        Me.RadioButton_diagnostic_12220.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12220.Size = New System.Drawing.Size(293, 16)
        Me.RadioButton_diagnostic_12220.TabIndex = 1
        '
        'GroupBox_diagnostic_1241
        '
        Me.GroupBox_diagnostic_1241.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_1241.Controls.Add(Me.RadioButton_diagnostic_12412)
        Me.GroupBox_diagnostic_1241.Controls.Add(Me.RadioButton_diagnostic_12410)
        Me.GroupBox_diagnostic_1241.Controls.Add(Me.RadioButton_diagnostic_12411)
        Me.GroupBox_diagnostic_1241.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1241.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1241.Location = New System.Drawing.Point(4, 247)
        Me.GroupBox_diagnostic_1241.Name = "GroupBox_diagnostic_1241"
        Me.GroupBox_diagnostic_1241.Size = New System.Drawing.Size(311, 86)
        Me.GroupBox_diagnostic_1241.TabIndex = 16
        Me.GroupBox_diagnostic_1241.TabStop = False
        Me.GroupBox_diagnostic_1241.Text = "12.4.1 - Cuve lave-mains"
        '
        'RadioButton_diagnostic_12411
        '
        Me.RadioButton_diagnostic_12411.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12411.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12411.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12411.cause1 = False
        Me.RadioButton_diagnostic_12411.cause2 = False
        Me.RadioButton_diagnostic_12411.cause3 = False
        Me.RadioButton_diagnostic_12411.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12411.Checked = False
        Me.RadioButton_diagnostic_12411.Code = Nothing
        Me.RadioButton_diagnostic_12411.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12411.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12411.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12411.Libelle = "12.4.1.1 - Absence"
        Me.RadioButton_diagnostic_12411.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12411.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_12411.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12411.Name = "RadioButton_diagnostic_12411"
        Me.RadioButton_diagnostic_12411.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12411.Size = New System.Drawing.Size(293, 22)
        Me.RadioButton_diagnostic_12411.TabIndex = 0
        '
        'RadioButton_diagnostic_12410
        '
        Me.RadioButton_diagnostic_12410.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12410.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12410.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12410.cause1 = False
        Me.RadioButton_diagnostic_12410.cause2 = False
        Me.RadioButton_diagnostic_12410.cause3 = False
        Me.RadioButton_diagnostic_12410.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12410.Checked = False
        Me.RadioButton_diagnostic_12410.Code = Nothing
        Me.RadioButton_diagnostic_12410.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12410.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12410.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12410.Libelle = "OK"
        Me.RadioButton_diagnostic_12410.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12410.Location = New System.Drawing.Point(10, 67)
        Me.RadioButton_diagnostic_12410.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12410.Name = "RadioButton_diagnostic_12410"
        Me.RadioButton_diagnostic_12410.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12410.Size = New System.Drawing.Size(293, 16)
        Me.RadioButton_diagnostic_12410.TabIndex = 1
        '
        'RadioButton_diagnostic_12412
        '
        Me.RadioButton_diagnostic_12412.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12412.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12412.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12412.cause1 = False
        Me.RadioButton_diagnostic_12412.cause2 = False
        Me.RadioButton_diagnostic_12412.cause3 = False
        Me.RadioButton_diagnostic_12412.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12412.Checked = False
        Me.RadioButton_diagnostic_12412.Code = Nothing
        Me.RadioButton_diagnostic_12412.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12412.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12412.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12412.Libelle = "12.4.1.2 - Capacité insuffisante (inf à 15l)"
        Me.RadioButton_diagnostic_12412.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12412.Location = New System.Drawing.Point(9, 32)
        Me.RadioButton_diagnostic_12412.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12412.Name = "RadioButton_diagnostic_12412"
        Me.RadioButton_diagnostic_12412.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12412.Size = New System.Drawing.Size(293, 22)
        Me.RadioButton_diagnostic_12412.TabIndex = 2
        '
        'Label_diagnostic_124
        '
        Me.Label_diagnostic_124.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_124.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_124.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_124.Image = CType(resources.GetObject("Label_diagnostic_124.Image"), System.Drawing.Image)
        Me.Label_diagnostic_124.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_124.Location = New System.Drawing.Point(4, 228)
        Me.Label_diagnostic_124.Name = "Label_diagnostic_124"
        Me.Label_diagnostic_124.Size = New System.Drawing.Size(311, 16)
        Me.Label_diagnostic_124.TabIndex = 17
        Me.Label_diagnostic_124.Text = "     Accessoires de sécurité"
        '
        'Panel14
        '
        Me.Panel14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel14.Controls.Add(Me.GroupBox_diagnostic_1114)
        Me.Panel14.Controls.Add(Me.GroupBox_diagnostic_1113)
        Me.Panel14.Controls.Add(Me.GroupBox_diagnostic_1112)
        Me.Panel14.Controls.Add(Me.Label_diagnostic_111)
        Me.Panel14.Controls.Add(Me.GroupBox_diagnostic_1111)
        Me.Panel14.Location = New System.Drawing.Point(3, 46)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(997, 118)
        Me.Panel14.TabIndex = 24
        '
        'GroupBox_diagnostic_1111
        '
        Me.GroupBox_diagnostic_1111.Controls.Add(Me.RadioButton_diagnostic_11112)
        Me.GroupBox_diagnostic_1111.Controls.Add(Me.RadioButton_diagnostic_11113)
        Me.GroupBox_diagnostic_1111.Controls.Add(Me.RadioButton_diagnostic_11110)
        Me.GroupBox_diagnostic_1111.Controls.Add(Me.RadioButton_diagnostic_11111)
        Me.GroupBox_diagnostic_1111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1111.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1111.Location = New System.Drawing.Point(8, 27)
        Me.GroupBox_diagnostic_1111.Name = "GroupBox_diagnostic_1111"
        Me.GroupBox_diagnostic_1111.Size = New System.Drawing.Size(222, 85)
        Me.GroupBox_diagnostic_1111.TabIndex = 2
        Me.GroupBox_diagnostic_1111.TabStop = False
        Me.GroupBox_diagnostic_1111.Text = "11.1.1 - Feux de position arrière"
        '
        'RadioButton_diagnostic_11111
        '
        Me.RadioButton_diagnostic_11111.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11111.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11111.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11111.cause1 = False
        Me.RadioButton_diagnostic_11111.cause2 = False
        Me.RadioButton_diagnostic_11111.cause3 = False
        Me.RadioButton_diagnostic_11111.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11111.Checked = False
        Me.RadioButton_diagnostic_11111.Code = Nothing
        Me.RadioButton_diagnostic_11111.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11111.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11111.Libelle = "11.1.1.1 - Absents"
        Me.RadioButton_diagnostic_11111.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11111.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_11111.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11111.Name = "RadioButton_diagnostic_11111"
        Me.RadioButton_diagnostic_11111.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11111.Size = New System.Drawing.Size(204, 16)
        Me.RadioButton_diagnostic_11111.TabIndex = 0
        '
        'RadioButton_diagnostic_11110
        '
        Me.RadioButton_diagnostic_11110.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11110.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_11110.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11110.cause1 = False
        Me.RadioButton_diagnostic_11110.cause2 = False
        Me.RadioButton_diagnostic_11110.cause3 = False
        Me.RadioButton_diagnostic_11110.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11110.Checked = False
        Me.RadioButton_diagnostic_11110.Code = Nothing
        Me.RadioButton_diagnostic_11110.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_11110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11110.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11110.Libelle = "OK"
        Me.RadioButton_diagnostic_11110.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11110.Location = New System.Drawing.Point(10, 66)
        Me.RadioButton_diagnostic_11110.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11110.Name = "RadioButton_diagnostic_11110"
        Me.RadioButton_diagnostic_11110.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11110.Size = New System.Drawing.Size(204, 16)
        Me.RadioButton_diagnostic_11110.TabIndex = 3
        '
        'RadioButton_diagnostic_11113
        '
        Me.RadioButton_diagnostic_11113.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11113.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11113.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11113.cause1 = False
        Me.RadioButton_diagnostic_11113.cause2 = False
        Me.RadioButton_diagnostic_11113.cause3 = False
        Me.RadioButton_diagnostic_11113.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11113.Checked = False
        Me.RadioButton_diagnostic_11113.Code = Nothing
        Me.RadioButton_diagnostic_11113.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11113.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11113.Libelle = "11.1.1.3 - Endommagés"
        Me.RadioButton_diagnostic_11113.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11113.Location = New System.Drawing.Point(10, 46)
        Me.RadioButton_diagnostic_11113.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11113.Name = "RadioButton_diagnostic_11113"
        Me.RadioButton_diagnostic_11113.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11113.Size = New System.Drawing.Size(204, 16)
        Me.RadioButton_diagnostic_11113.TabIndex = 2
        '
        'RadioButton_diagnostic_11112
        '
        Me.RadioButton_diagnostic_11112.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11112.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11112.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11112.cause1 = False
        Me.RadioButton_diagnostic_11112.cause2 = False
        Me.RadioButton_diagnostic_11112.cause3 = False
        Me.RadioButton_diagnostic_11112.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11112.Checked = False
        Me.RadioButton_diagnostic_11112.Code = Nothing
        Me.RadioButton_diagnostic_11112.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11112.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11112.Libelle = "11.1.1.2 - Eclairage défectueux"
        Me.RadioButton_diagnostic_11112.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11112.Location = New System.Drawing.Point(10, 30)
        Me.RadioButton_diagnostic_11112.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11112.Name = "RadioButton_diagnostic_11112"
        Me.RadioButton_diagnostic_11112.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11112.Size = New System.Drawing.Size(204, 16)
        Me.RadioButton_diagnostic_11112.TabIndex = 1
        '
        'Label_diagnostic_111
        '
        Me.Label_diagnostic_111.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_111.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_111.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_111.Image = CType(resources.GetObject("Label_diagnostic_111.Image"), System.Drawing.Image)
        Me.Label_diagnostic_111.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_111.Location = New System.Drawing.Point(5, 8)
        Me.Label_diagnostic_111.Name = "Label_diagnostic_111"
        Me.Label_diagnostic_111.Size = New System.Drawing.Size(981, 16)
        Me.Label_diagnostic_111.TabIndex = 14
        Me.Label_diagnostic_111.Text = "     Eclairage"
        '
        'GroupBox_diagnostic_1112
        '
        Me.GroupBox_diagnostic_1112.Controls.Add(Me.RadioButton_diagnostic_11122)
        Me.GroupBox_diagnostic_1112.Controls.Add(Me.RadioButton_diagnostic_11123)
        Me.GroupBox_diagnostic_1112.Controls.Add(Me.RadioButton_diagnostic_11120)
        Me.GroupBox_diagnostic_1112.Controls.Add(Me.RadioButton_diagnostic_11121)
        Me.GroupBox_diagnostic_1112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1112.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1112.Location = New System.Drawing.Point(236, 30)
        Me.GroupBox_diagnostic_1112.Name = "GroupBox_diagnostic_1112"
        Me.GroupBox_diagnostic_1112.Size = New System.Drawing.Size(266, 85)
        Me.GroupBox_diagnostic_1112.TabIndex = 3
        Me.GroupBox_diagnostic_1112.TabStop = False
        Me.GroupBox_diagnostic_1112.Text = "11.1.2 - Feux de croisement (avant)"
        '
        'RadioButton_diagnostic_11121
        '
        Me.RadioButton_diagnostic_11121.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11121.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11121.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11121.cause1 = False
        Me.RadioButton_diagnostic_11121.cause2 = False
        Me.RadioButton_diagnostic_11121.cause3 = False
        Me.RadioButton_diagnostic_11121.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11121.Checked = False
        Me.RadioButton_diagnostic_11121.Code = Nothing
        Me.RadioButton_diagnostic_11121.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11121.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11121.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11121.Libelle = "11.1.2.1 - Absents"
        Me.RadioButton_diagnostic_11121.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11121.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_11121.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11121.Name = "RadioButton_diagnostic_11121"
        Me.RadioButton_diagnostic_11121.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11121.Size = New System.Drawing.Size(248, 16)
        Me.RadioButton_diagnostic_11121.TabIndex = 0
        '
        'RadioButton_diagnostic_11120
        '
        Me.RadioButton_diagnostic_11120.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11120.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_11120.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11120.cause1 = False
        Me.RadioButton_diagnostic_11120.cause2 = False
        Me.RadioButton_diagnostic_11120.cause3 = False
        Me.RadioButton_diagnostic_11120.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11120.Checked = False
        Me.RadioButton_diagnostic_11120.Code = Nothing
        Me.RadioButton_diagnostic_11120.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_11120.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11120.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11120.Libelle = "OK"
        Me.RadioButton_diagnostic_11120.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11120.Location = New System.Drawing.Point(10, 66)
        Me.RadioButton_diagnostic_11120.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11120.Name = "RadioButton_diagnostic_11120"
        Me.RadioButton_diagnostic_11120.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11120.Size = New System.Drawing.Size(248, 16)
        Me.RadioButton_diagnostic_11120.TabIndex = 3
        '
        'RadioButton_diagnostic_11123
        '
        Me.RadioButton_diagnostic_11123.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11123.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11123.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11123.cause1 = False
        Me.RadioButton_diagnostic_11123.cause2 = False
        Me.RadioButton_diagnostic_11123.cause3 = False
        Me.RadioButton_diagnostic_11123.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11123.Checked = False
        Me.RadioButton_diagnostic_11123.Code = Nothing
        Me.RadioButton_diagnostic_11123.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11123.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11123.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11123.Libelle = "11.1.2.3 - Endommagés"
        Me.RadioButton_diagnostic_11123.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11123.Location = New System.Drawing.Point(10, 46)
        Me.RadioButton_diagnostic_11123.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11123.Name = "RadioButton_diagnostic_11123"
        Me.RadioButton_diagnostic_11123.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11123.Size = New System.Drawing.Size(248, 16)
        Me.RadioButton_diagnostic_11123.TabIndex = 2
        '
        'RadioButton_diagnostic_11122
        '
        Me.RadioButton_diagnostic_11122.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11122.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11122.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11122.cause1 = False
        Me.RadioButton_diagnostic_11122.cause2 = False
        Me.RadioButton_diagnostic_11122.cause3 = False
        Me.RadioButton_diagnostic_11122.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11122.Checked = False
        Me.RadioButton_diagnostic_11122.Code = Nothing
        Me.RadioButton_diagnostic_11122.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11122.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11122.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11122.Libelle = "11.1.2.2 - Eclairage défectueux"
        Me.RadioButton_diagnostic_11122.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11122.Location = New System.Drawing.Point(10, 30)
        Me.RadioButton_diagnostic_11122.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11122.Name = "RadioButton_diagnostic_11122"
        Me.RadioButton_diagnostic_11122.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11122.Size = New System.Drawing.Size(248, 16)
        Me.RadioButton_diagnostic_11122.TabIndex = 1
        '
        'GroupBox_diagnostic_1113
        '
        Me.GroupBox_diagnostic_1113.Controls.Add(Me.RadioButton_diagnostic_11132)
        Me.GroupBox_diagnostic_1113.Controls.Add(Me.RadioButton_diagnostic_11133)
        Me.GroupBox_diagnostic_1113.Controls.Add(Me.RadioButton_diagnostic_11130)
        Me.GroupBox_diagnostic_1113.Controls.Add(Me.RadioButton_diagnostic_11131)
        Me.GroupBox_diagnostic_1113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1113.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1113.Location = New System.Drawing.Point(514, 30)
        Me.GroupBox_diagnostic_1113.Name = "GroupBox_diagnostic_1113"
        Me.GroupBox_diagnostic_1113.Size = New System.Drawing.Size(233, 85)
        Me.GroupBox_diagnostic_1113.TabIndex = 4
        Me.GroupBox_diagnostic_1113.TabStop = False
        Me.GroupBox_diagnostic_1113.Text = "11.1.3 - Indicateurs de direction"
        '
        'RadioButton_diagnostic_11131
        '
        Me.RadioButton_diagnostic_11131.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11131.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11131.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11131.cause1 = False
        Me.RadioButton_diagnostic_11131.cause2 = False
        Me.RadioButton_diagnostic_11131.cause3 = False
        Me.RadioButton_diagnostic_11131.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11131.Checked = False
        Me.RadioButton_diagnostic_11131.Code = Nothing
        Me.RadioButton_diagnostic_11131.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11131.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11131.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11131.Libelle = "11.1.3.1 - Absents"
        Me.RadioButton_diagnostic_11131.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11131.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_11131.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11131.Name = "RadioButton_diagnostic_11131"
        Me.RadioButton_diagnostic_11131.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11131.Size = New System.Drawing.Size(215, 16)
        Me.RadioButton_diagnostic_11131.TabIndex = 0
        '
        'RadioButton_diagnostic_11130
        '
        Me.RadioButton_diagnostic_11130.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11130.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_11130.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11130.cause1 = False
        Me.RadioButton_diagnostic_11130.cause2 = False
        Me.RadioButton_diagnostic_11130.cause3 = False
        Me.RadioButton_diagnostic_11130.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11130.Checked = False
        Me.RadioButton_diagnostic_11130.Code = Nothing
        Me.RadioButton_diagnostic_11130.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_11130.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11130.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11130.Libelle = "OK"
        Me.RadioButton_diagnostic_11130.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11130.Location = New System.Drawing.Point(10, 66)
        Me.RadioButton_diagnostic_11130.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11130.Name = "RadioButton_diagnostic_11130"
        Me.RadioButton_diagnostic_11130.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11130.Size = New System.Drawing.Size(215, 16)
        Me.RadioButton_diagnostic_11130.TabIndex = 3
        '
        'RadioButton_diagnostic_11133
        '
        Me.RadioButton_diagnostic_11133.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11133.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11133.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11133.cause1 = False
        Me.RadioButton_diagnostic_11133.cause2 = False
        Me.RadioButton_diagnostic_11133.cause3 = False
        Me.RadioButton_diagnostic_11133.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11133.Checked = False
        Me.RadioButton_diagnostic_11133.Code = Nothing
        Me.RadioButton_diagnostic_11133.ContextMenuStrip = Me.ContextMenuStrip1
        Me.RadioButton_diagnostic_11133.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11133.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11133.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11133.Libelle = "11.1.3.3 - Endommagés"
        Me.RadioButton_diagnostic_11133.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11133.Location = New System.Drawing.Point(10, 46)
        Me.RadioButton_diagnostic_11133.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11133.Name = "RadioButton_diagnostic_11133"
        Me.RadioButton_diagnostic_11133.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11133.Size = New System.Drawing.Size(215, 16)
        Me.RadioButton_diagnostic_11133.TabIndex = 2
        '
        'RadioButton_diagnostic_11132
        '
        Me.RadioButton_diagnostic_11132.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11132.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11132.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11132.cause1 = False
        Me.RadioButton_diagnostic_11132.cause2 = False
        Me.RadioButton_diagnostic_11132.cause3 = False
        Me.RadioButton_diagnostic_11132.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11132.Checked = False
        Me.RadioButton_diagnostic_11132.Code = Nothing
        Me.RadioButton_diagnostic_11132.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11132.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11132.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11132.Libelle = "11.1.3.2 - Eclairage défectueux"
        Me.RadioButton_diagnostic_11132.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11132.Location = New System.Drawing.Point(10, 30)
        Me.RadioButton_diagnostic_11132.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11132.Name = "RadioButton_diagnostic_11132"
        Me.RadioButton_diagnostic_11132.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11132.Size = New System.Drawing.Size(215, 16)
        Me.RadioButton_diagnostic_11132.TabIndex = 1
        '
        'GroupBox_diagnostic_1114
        '
        Me.GroupBox_diagnostic_1114.Controls.Add(Me.RadioButton_diagnostic_11142)
        Me.GroupBox_diagnostic_1114.Controls.Add(Me.RadioButton_diagnostic_11140)
        Me.GroupBox_diagnostic_1114.Controls.Add(Me.RadioButton_diagnostic_11141)
        Me.GroupBox_diagnostic_1114.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1114.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1114.Location = New System.Drawing.Point(753, 30)
        Me.GroupBox_diagnostic_1114.Name = "GroupBox_diagnostic_1114"
        Me.GroupBox_diagnostic_1114.Size = New System.Drawing.Size(233, 85)
        Me.GroupBox_diagnostic_1114.TabIndex = 5
        Me.GroupBox_diagnostic_1114.TabStop = False
        Me.GroupBox_diagnostic_1114.Text = "11.1.4 - Dispositif de feux tournants"
        '
        'RadioButton_diagnostic_11141
        '
        Me.RadioButton_diagnostic_11141.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11141.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11141.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11141.cause1 = False
        Me.RadioButton_diagnostic_11141.cause2 = False
        Me.RadioButton_diagnostic_11141.cause3 = False
        Me.RadioButton_diagnostic_11141.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11141.Checked = False
        Me.RadioButton_diagnostic_11141.Code = Nothing
        Me.RadioButton_diagnostic_11141.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11141.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11141.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11141.Libelle = "11.1.4.1 - Absents"
        Me.RadioButton_diagnostic_11141.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11141.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_11141.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11141.Name = "RadioButton_diagnostic_11141"
        Me.RadioButton_diagnostic_11141.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11141.Size = New System.Drawing.Size(215, 16)
        Me.RadioButton_diagnostic_11141.TabIndex = 0
        '
        'RadioButton_diagnostic_11140
        '
        Me.RadioButton_diagnostic_11140.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11140.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_11140.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11140.cause1 = False
        Me.RadioButton_diagnostic_11140.cause2 = False
        Me.RadioButton_diagnostic_11140.cause3 = False
        Me.RadioButton_diagnostic_11140.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11140.Checked = False
        Me.RadioButton_diagnostic_11140.Code = Nothing
        Me.RadioButton_diagnostic_11140.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_11140.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11140.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11140.Libelle = "OK"
        Me.RadioButton_diagnostic_11140.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11140.Location = New System.Drawing.Point(10, 66)
        Me.RadioButton_diagnostic_11140.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11140.Name = "RadioButton_diagnostic_11140"
        Me.RadioButton_diagnostic_11140.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11140.Size = New System.Drawing.Size(215, 16)
        Me.RadioButton_diagnostic_11140.TabIndex = 2
        '
        'RadioButton_diagnostic_11142
        '
        Me.RadioButton_diagnostic_11142.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_11142.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11142.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_11142.cause1 = False
        Me.RadioButton_diagnostic_11142.cause2 = False
        Me.RadioButton_diagnostic_11142.cause3 = False
        Me.RadioButton_diagnostic_11142.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11142.Checked = False
        Me.RadioButton_diagnostic_11142.Code = Nothing
        Me.RadioButton_diagnostic_11142.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_11142.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_11142.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_11142.Libelle = "11.1.4.2 - Eclairage défectueux"
        Me.RadioButton_diagnostic_11142.LibelleLong = Nothing
        Me.RadioButton_diagnostic_11142.Location = New System.Drawing.Point(10, 30)
        Me.RadioButton_diagnostic_11142.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_11142.Name = "RadioButton_diagnostic_11142"
        Me.RadioButton_diagnostic_11142.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_11142.Size = New System.Drawing.Size(215, 16)
        Me.RadioButton_diagnostic_11142.TabIndex = 1
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel9.Controls.Add(Me.GroupBox_diagnostic_1213)
        Me.Panel9.Controls.Add(Me.GroupBox_diagnostic_1212)
        Me.Panel9.Controls.Add(Me.Label_diagnostic_121)
        Me.Panel9.Controls.Add(Me.GroupBox_diagnostic_1211)
        Me.Panel9.Location = New System.Drawing.Point(6, 193)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(300, 336)
        Me.Panel9.TabIndex = 0
        '
        'GroupBox_diagnostic_1211
        '
        Me.GroupBox_diagnostic_1211.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_1211.Controls.Add(Me.RadioButton_diagnostic_12112)
        Me.GroupBox_diagnostic_1211.Controls.Add(Me.RadioButton_diagnostic_12113)
        Me.GroupBox_diagnostic_1211.Controls.Add(Me.RadioButton_diagnostic_12110)
        Me.GroupBox_diagnostic_1211.Controls.Add(Me.RadioButton_diagnostic_12111)
        Me.GroupBox_diagnostic_1211.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1211.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1211.Location = New System.Drawing.Point(1, 32)
        Me.GroupBox_diagnostic_1211.Name = "GroupBox_diagnostic_1211"
        Me.GroupBox_diagnostic_1211.Size = New System.Drawing.Size(290, 85)
        Me.GroupBox_diagnostic_1211.TabIndex = 5
        Me.GroupBox_diagnostic_1211.TabStop = False
        Me.GroupBox_diagnostic_1211.Text = "12.1.1 - Cuve de produit"
        '
        'RadioButton_diagnostic_12111
        '
        Me.RadioButton_diagnostic_12111.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12111.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12111.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12111.cause1 = False
        Me.RadioButton_diagnostic_12111.cause2 = False
        Me.RadioButton_diagnostic_12111.cause3 = False
        Me.RadioButton_diagnostic_12111.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12111.Checked = False
        Me.RadioButton_diagnostic_12111.Code = Nothing
        Me.RadioButton_diagnostic_12111.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12111.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12111.Libelle = "12.1.1.1 - Fuite"
        Me.RadioButton_diagnostic_12111.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12111.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_12111.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12111.Name = "RadioButton_diagnostic_12111"
        Me.RadioButton_diagnostic_12111.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12111.Size = New System.Drawing.Size(272, 16)
        Me.RadioButton_diagnostic_12111.TabIndex = 0
        '
        'RadioButton_diagnostic_12110
        '
        Me.RadioButton_diagnostic_12110.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12110.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12110.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12110.cause1 = False
        Me.RadioButton_diagnostic_12110.cause2 = False
        Me.RadioButton_diagnostic_12110.cause3 = False
        Me.RadioButton_diagnostic_12110.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12110.Checked = False
        Me.RadioButton_diagnostic_12110.Code = Nothing
        Me.RadioButton_diagnostic_12110.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12110.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12110.Libelle = "OK"
        Me.RadioButton_diagnostic_12110.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12110.Location = New System.Drawing.Point(10, 66)
        Me.RadioButton_diagnostic_12110.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12110.Name = "RadioButton_diagnostic_12110"
        Me.RadioButton_diagnostic_12110.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12110.Size = New System.Drawing.Size(272, 16)
        Me.RadioButton_diagnostic_12110.TabIndex = 3
        '
        'RadioButton_diagnostic_12113
        '
        Me.RadioButton_diagnostic_12113.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12113.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12113.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12113.cause1 = False
        Me.RadioButton_diagnostic_12113.cause2 = False
        Me.RadioButton_diagnostic_12113.cause3 = False
        Me.RadioButton_diagnostic_12113.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12113.Checked = False
        Me.RadioButton_diagnostic_12113.Code = Nothing
        Me.RadioButton_diagnostic_12113.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12113.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12113.Libelle = "12.1.1.3 - Fixation hasardeuse"
        Me.RadioButton_diagnostic_12113.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12113.Location = New System.Drawing.Point(10, 46)
        Me.RadioButton_diagnostic_12113.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12113.Name = "RadioButton_diagnostic_12113"
        Me.RadioButton_diagnostic_12113.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12113.Size = New System.Drawing.Size(272, 16)
        Me.RadioButton_diagnostic_12113.TabIndex = 2
        '
        'RadioButton_diagnostic_12112
        '
        Me.RadioButton_diagnostic_12112.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12112.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12112.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12112.cause1 = False
        Me.RadioButton_diagnostic_12112.cause2 = False
        Me.RadioButton_diagnostic_12112.cause3 = False
        Me.RadioButton_diagnostic_12112.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12112.Checked = False
        Me.RadioButton_diagnostic_12112.Code = Nothing
        Me.RadioButton_diagnostic_12112.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12112.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12112.Libelle = "12.1.1.2 - Fermeture non étanche"
        Me.RadioButton_diagnostic_12112.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12112.Location = New System.Drawing.Point(10, 30)
        Me.RadioButton_diagnostic_12112.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12112.Name = "RadioButton_diagnostic_12112"
        Me.RadioButton_diagnostic_12112.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12112.Size = New System.Drawing.Size(272, 16)
        Me.RadioButton_diagnostic_12112.TabIndex = 1
        '
        'Label_diagnostic_121
        '
        Me.Label_diagnostic_121.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_121.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_121.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_121.Image = CType(resources.GetObject("Label_diagnostic_121.Image"), System.Drawing.Image)
        Me.Label_diagnostic_121.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_121.Location = New System.Drawing.Point(1, 8)
        Me.Label_diagnostic_121.Name = "Label_diagnostic_121"
        Me.Label_diagnostic_121.Size = New System.Drawing.Size(290, 16)
        Me.Label_diagnostic_121.TabIndex = 11
        Me.Label_diagnostic_121.Text = "     Injection directe"
        '
        'GroupBox_diagnostic_1212
        '
        Me.GroupBox_diagnostic_1212.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_1212.Controls.Add(Me.ico_help_12123)
        Me.GroupBox_diagnostic_1212.Controls.Add(Me.RadioButton_diagnostic_12122)
        Me.GroupBox_diagnostic_1212.Controls.Add(Me.RadioButton_diagnostic_12123)
        Me.GroupBox_diagnostic_1212.Controls.Add(Me.RadioButton_diagnostic_12120)
        Me.GroupBox_diagnostic_1212.Controls.Add(Me.RadioButton_diagnostic_12121)
        Me.GroupBox_diagnostic_1212.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1212.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1212.Location = New System.Drawing.Point(3, 123)
        Me.GroupBox_diagnostic_1212.Name = "GroupBox_diagnostic_1212"
        Me.GroupBox_diagnostic_1212.Size = New System.Drawing.Size(288, 85)
        Me.GroupBox_diagnostic_1212.TabIndex = 12
        Me.GroupBox_diagnostic_1212.TabStop = False
        Me.GroupBox_diagnostic_1212.Text = "12.1.2 - Dispositif de dosage"
        '
        'RadioButton_diagnostic_12121
        '
        Me.RadioButton_diagnostic_12121.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12121.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12121.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12121.cause1 = False
        Me.RadioButton_diagnostic_12121.cause2 = False
        Me.RadioButton_diagnostic_12121.cause3 = False
        Me.RadioButton_diagnostic_12121.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12121.Checked = False
        Me.RadioButton_diagnostic_12121.Code = Nothing
        Me.RadioButton_diagnostic_12121.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12121.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12121.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12121.Libelle = "12.1.2.1 - Fuite"
        Me.RadioButton_diagnostic_12121.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12121.Location = New System.Drawing.Point(10, 14)
        Me.RadioButton_diagnostic_12121.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12121.Name = "RadioButton_diagnostic_12121"
        Me.RadioButton_diagnostic_12121.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12121.Size = New System.Drawing.Size(270, 16)
        Me.RadioButton_diagnostic_12121.TabIndex = 0
        '
        'RadioButton_diagnostic_12120
        '
        Me.RadioButton_diagnostic_12120.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12120.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12120.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12120.cause1 = False
        Me.RadioButton_diagnostic_12120.cause2 = False
        Me.RadioButton_diagnostic_12120.cause3 = False
        Me.RadioButton_diagnostic_12120.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12120.Checked = False
        Me.RadioButton_diagnostic_12120.Code = Nothing
        Me.RadioButton_diagnostic_12120.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12120.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12120.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12120.Libelle = "OK"
        Me.RadioButton_diagnostic_12120.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12120.Location = New System.Drawing.Point(10, 66)
        Me.RadioButton_diagnostic_12120.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12120.Name = "RadioButton_diagnostic_12120"
        Me.RadioButton_diagnostic_12120.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12120.Size = New System.Drawing.Size(270, 16)
        Me.RadioButton_diagnostic_12120.TabIndex = 3
        '
        'RadioButton_diagnostic_12123
        '
        Me.RadioButton_diagnostic_12123.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12123.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12123.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12123.cause1 = False
        Me.RadioButton_diagnostic_12123.cause2 = False
        Me.RadioButton_diagnostic_12123.cause3 = False
        Me.RadioButton_diagnostic_12123.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12123.Checked = False
        Me.RadioButton_diagnostic_12123.Code = Nothing
        Me.RadioButton_diagnostic_12123.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12123.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12123.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12123.Libelle = "12.1.2.3 - Débit"
        Me.RadioButton_diagnostic_12123.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12123.Location = New System.Drawing.Point(10, 46)
        Me.RadioButton_diagnostic_12123.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12123.Name = "RadioButton_diagnostic_12123"
        Me.RadioButton_diagnostic_12123.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12123.Size = New System.Drawing.Size(270, 16)
        Me.RadioButton_diagnostic_12123.TabIndex = 2
        '
        'RadioButton_diagnostic_12122
        '
        Me.RadioButton_diagnostic_12122.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12122.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_12122.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12122.cause1 = False
        Me.RadioButton_diagnostic_12122.cause2 = False
        Me.RadioButton_diagnostic_12122.cause3 = False
        Me.RadioButton_diagnostic_12122.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12122.Checked = False
        Me.RadioButton_diagnostic_12122.Code = Nothing
        Me.RadioButton_diagnostic_12122.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12122.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12122.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12122.Libelle = "12.1.2.2 - Fixation hasardeuse"
        Me.RadioButton_diagnostic_12122.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12122.Location = New System.Drawing.Point(10, 30)
        Me.RadioButton_diagnostic_12122.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12122.Name = "RadioButton_diagnostic_12122"
        Me.RadioButton_diagnostic_12122.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12122.Size = New System.Drawing.Size(270, 16)
        Me.RadioButton_diagnostic_12122.TabIndex = 1
        '
        'ico_help_12123
        '
        Me.ico_help_12123.BackColor = System.Drawing.Color.Transparent
        Me.ico_help_12123.Image = CType(resources.GetObject("ico_help_12123.Image"), System.Drawing.Image)
        Me.ico_help_12123.Location = New System.Drawing.Point(240, 43)
        Me.ico_help_12123.Name = "ico_help_12123"
        Me.ico_help_12123.Size = New System.Drawing.Size(20, 20)
        Me.ico_help_12123.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ico_help_12123.TabIndex = 10
        Me.ico_help_12123.TabStop = False
        '
        'GroupBox_diagnostic_1213
        '
        Me.GroupBox_diagnostic_1213.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_1213.Controls.Add(Me.RadioButton_diagnostic_12132)
        Me.GroupBox_diagnostic_1213.Controls.Add(Me.RadioButton_diagnostic_12130)
        Me.GroupBox_diagnostic_1213.Controls.Add(Me.RadioButton_diagnostic_12131)
        Me.GroupBox_diagnostic_1213.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_1213.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_1213.Location = New System.Drawing.Point(4, 214)
        Me.GroupBox_diagnostic_1213.Name = "GroupBox_diagnostic_1213"
        Me.GroupBox_diagnostic_1213.Size = New System.Drawing.Size(287, 82)
        Me.GroupBox_diagnostic_1213.TabIndex = 0
        Me.GroupBox_diagnostic_1213.TabStop = False
        Me.GroupBox_diagnostic_1213.Text = "12.1.3 - Dispositif de rincage spécifique"
        '
        'RadioButton_diagnostic_12131
        '
        Me.RadioButton_diagnostic_12131.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12131.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12131.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12131.cause1 = False
        Me.RadioButton_diagnostic_12131.cause2 = False
        Me.RadioButton_diagnostic_12131.cause3 = False
        Me.RadioButton_diagnostic_12131.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12131.Checked = False
        Me.RadioButton_diagnostic_12131.Code = Nothing
        Me.RadioButton_diagnostic_12131.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12131.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12131.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12131.Libelle = "12.1.3.1 - Absence"
        Me.RadioButton_diagnostic_12131.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12131.Location = New System.Drawing.Point(10, 28)
        Me.RadioButton_diagnostic_12131.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12131.Name = "RadioButton_diagnostic_12131"
        Me.RadioButton_diagnostic_12131.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12131.Size = New System.Drawing.Size(269, 16)
        Me.RadioButton_diagnostic_12131.TabIndex = 0
        '
        'RadioButton_diagnostic_12130
        '
        Me.RadioButton_diagnostic_12130.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12130.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12130.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12130.cause1 = False
        Me.RadioButton_diagnostic_12130.cause2 = False
        Me.RadioButton_diagnostic_12130.cause3 = False
        Me.RadioButton_diagnostic_12130.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12130.Checked = False
        Me.RadioButton_diagnostic_12130.Code = Nothing
        Me.RadioButton_diagnostic_12130.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_12130.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12130.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12130.Libelle = "OK"
        Me.RadioButton_diagnostic_12130.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12130.Location = New System.Drawing.Point(10, 63)
        Me.RadioButton_diagnostic_12130.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12130.Name = "RadioButton_diagnostic_12130"
        Me.RadioButton_diagnostic_12130.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12130.Size = New System.Drawing.Size(269, 16)
        Me.RadioButton_diagnostic_12130.TabIndex = 7
        '
        'RadioButton_diagnostic_12132
        '
        Me.RadioButton_diagnostic_12132.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_12132.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12132.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_12132.cause1 = False
        Me.RadioButton_diagnostic_12132.cause2 = False
        Me.RadioButton_diagnostic_12132.cause3 = False
        Me.RadioButton_diagnostic_12132.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12132.Checked = False
        Me.RadioButton_diagnostic_12132.Code = Nothing
        Me.RadioButton_diagnostic_12132.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_12132.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_12132.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_12132.Libelle = "12.1.3.2 - Non fonctionnel"
        Me.RadioButton_diagnostic_12132.LibelleLong = Nothing
        Me.RadioButton_diagnostic_12132.Location = New System.Drawing.Point(10, 47)
        Me.RadioButton_diagnostic_12132.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_12132.Name = "RadioButton_diagnostic_12132"
        Me.RadioButton_diagnostic_12132.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_12132.Size = New System.Drawing.Size(269, 16)
        Me.RadioButton_diagnostic_12132.TabIndex = 1
        '
        'tabPage_diagnostique_buses
        '
        Me.tabPage_diagnostique_buses.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabPage_diagnostique_buses.Controls.Add(Me.Panel922)
        Me.tabPage_diagnostique_buses.Controls.Add(Me.Panel63)
        Me.tabPage_diagnostique_buses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPage_diagnostique_buses.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabPage_diagnostique_buses.ImageIndex = 3
        Me.tabPage_diagnostique_buses.Location = New System.Drawing.Point(4, 23)
        Me.tabPage_diagnostique_buses.Name = "tabPage_diagnostique_buses"
        Me.tabPage_diagnostique_buses.Size = New System.Drawing.Size(1008, 653)
        Me.tabPage_diagnostique_buses.TabIndex = 7
        Me.tabPage_diagnostique_buses.Tag = "8"
        Me.tabPage_diagnostique_buses.Text = "Buses"
        '
        'Panel63
        '
        Me.Panel63.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel63.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel63.Controls.Add(Me.Label76)
        Me.Panel63.Controls.Add(Me.buses_listBancs)
        Me.Panel63.Controls.Add(Me.Label77)
        Me.Panel63.Location = New System.Drawing.Point(0, 114)
        Me.Panel63.Name = "Panel63"
        Me.Panel63.Size = New System.Drawing.Size(1008, 47)
        Me.Panel63.TabIndex = 16
        '
        'Label77
        '
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label77.Image = CType(resources.GetObject("Label77.Image"), System.Drawing.Image)
        Me.Label77.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label77.Location = New System.Drawing.Point(8, 8)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(336, 25)
        Me.Label77.TabIndex = 4
        Me.Label77.Text = "     Choix du banc de contrôle"
        '
        'buses_listBancs
        '
        Me.buses_listBancs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.buses_listBancs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buses_listBancs.Location = New System.Drawing.Point(520, 16)
        Me.buses_listBancs.Name = "buses_listBancs"
        Me.buses_listBancs.Size = New System.Drawing.Size(232, 21)
        Me.buses_listBancs.TabIndex = 5
        '
        'Label76
        '
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label76.Location = New System.Drawing.Point(360, 16)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(152, 16)
        Me.Label76.TabIndex = 6
        Me.Label76.Text = "Sélection du banc : "
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Panel922
        '
        Me.Panel922.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel922.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel922.Controls.Add(Me.Panel11)
        Me.Panel922.Controls.Add(Me.btn_diagnostic_acquisitionDonnees)
        Me.Panel922.Controls.Add(Me.Lbl_diagnostic_922)
        Me.Panel922.Location = New System.Drawing.Point(0, 162)
        Me.Panel922.Name = "Panel922"
        Me.Panel922.Size = New System.Drawing.Size(1008, 491)
        Me.Panel922.TabIndex = 18
        '
        'Lbl_diagnostic_922
        '
        Me.Lbl_diagnostic_922.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_diagnostic_922.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Lbl_diagnostic_922.Image = CType(resources.GetObject("Lbl_diagnostic_922.Image"), System.Drawing.Image)
        Me.Lbl_diagnostic_922.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lbl_diagnostic_922.Location = New System.Drawing.Point(8, 8)
        Me.Lbl_diagnostic_922.Name = "Lbl_diagnostic_922"
        Me.Lbl_diagnostic_922.Size = New System.Drawing.Size(392, 25)
        Me.Lbl_diagnostic_922.TabIndex = 4
        Me.Lbl_diagnostic_922.Text = "     Mesure du débit (9.2.2)"
        '
        'btn_diagnostic_acquisitionDonnees
        '
        Me.btn_diagnostic_acquisitionDonnees.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_diagnostic_acquisitionDonnees.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_diagnostic_acquisitionDonnees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_diagnostic_acquisitionDonnees.ForeColor = System.Drawing.Color.White
        Me.btn_diagnostic_acquisitionDonnees.Image = CType(resources.GetObject("btn_diagnostic_acquisitionDonnees.Image"), System.Drawing.Image)
        Me.btn_diagnostic_acquisitionDonnees.Location = New System.Drawing.Point(808, 16)
        Me.btn_diagnostic_acquisitionDonnees.Name = "btn_diagnostic_acquisitionDonnees"
        Me.btn_diagnostic_acquisitionDonnees.Size = New System.Drawing.Size(180, 24)
        Me.btn_diagnostic_acquisitionDonnees.TabIndex = 27
        Me.btn_diagnostic_acquisitionDonnees.Text = "       Acquisition de données"
        Me.btn_diagnostic_acquisitionDonnees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.Controls.Add(Me.tbDebitMoyen3bars)
        Me.Panel11.Controls.Add(Me.LaDebitMoyen3bars)
        Me.Panel11.Controls.Add(Me.diagBuses_conf_ajouterNiveau)
        Me.Panel11.Controls.Add(Me.diagBuses_conf_validNbCategories)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Controls.Add(Me.tbPressionMesure)
        Me.Panel11.Controls.Add(Me.diagBuses_tab_categories)
        Me.Panel11.Controls.Add(Me.diagBuses_conf_nbCategories)
        Me.Panel11.Controls.Add(Me.Label23)
        Me.Panel11.Controls.Add(Me.Label52)
        Me.Panel11.Controls.Add(Me.diagBuses_nbBusesUsees)
        Me.Panel11.Controls.Add(Me.Label213)
        Me.Panel11.Controls.Add(Me.diagBuses_usureMoyBuses)
        Me.Panel11.Controls.Add(Me.Label214)
        Me.Panel11.Controls.Add(Me.LaDebitMoyenBuses)
        Me.Panel11.Controls.Add(Me.diagBuses_debitMoyen)
        Me.Panel11.Controls.Add(Me.diagBuses_resultat)
        Me.Panel11.Location = New System.Drawing.Point(0, 56)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1008, 435)
        Me.Panel11.TabIndex = 28
        '
        'diagBuses_resultat
        '
        Me.diagBuses_resultat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.diagBuses_resultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_resultat.ForeColor = System.Drawing.Color.Red
        Me.diagBuses_resultat.Location = New System.Drawing.Point(832, 395)
        Me.diagBuses_resultat.Name = "diagBuses_resultat"
        Me.diagBuses_resultat.Size = New System.Drawing.Size(168, 16)
        Me.diagBuses_resultat.TabIndex = 27
        Me.diagBuses_resultat.Text = "USURE GLOBALE"
        Me.diagBuses_resultat.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'diagBuses_debitMoyen
        '
        Me.diagBuses_debitMoyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.diagBuses_debitMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_debitMoyen.ForceBindingOnTextChanged = False
        Me.diagBuses_debitMoyen.Location = New System.Drawing.Point(166, 390)
        Me.diagBuses_debitMoyen.Name = "diagBuses_debitMoyen"
        Me.diagBuses_debitMoyen.ReadOnly = True
        Me.diagBuses_debitMoyen.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_debitMoyen.TabIndex = 20
        '
        'LaDebitMoyenBuses
        '
        Me.LaDebitMoyenBuses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LaDebitMoyenBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaDebitMoyenBuses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LaDebitMoyenBuses.Location = New System.Drawing.Point(20, 395)
        Me.LaDebitMoyenBuses.Name = "LaDebitMoyenBuses"
        Me.LaDebitMoyenBuses.Size = New System.Drawing.Size(144, 16)
        Me.LaDebitMoyenBuses.TabIndex = 17
        Me.LaDebitMoyenBuses.Text = "Débit moyen à     bars :"
        Me.LaDebitMoyenBuses.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label214
        '
        Me.Label214.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label214.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label214.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label214.Location = New System.Drawing.Point(406, 395)
        Me.Label214.Name = "Label214"
        Me.Label214.Size = New System.Drawing.Size(162, 16)
        Me.Label214.TabIndex = 17
        Me.Label214.Text = "Usure moyenne des buses :"
        Me.Label214.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_usureMoyBuses
        '
        Me.diagBuses_usureMoyBuses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.diagBuses_usureMoyBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_usureMoyBuses.ForceBindingOnTextChanged = False
        Me.diagBuses_usureMoyBuses.Location = New System.Drawing.Point(576, 390)
        Me.diagBuses_usureMoyBuses.Name = "diagBuses_usureMoyBuses"
        Me.diagBuses_usureMoyBuses.ReadOnly = True
        Me.diagBuses_usureMoyBuses.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_usureMoyBuses.TabIndex = 20
        '
        'Label213
        '
        Me.Label213.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label213.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label213.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label213.Location = New System.Drawing.Point(240, 395)
        Me.Label213.Name = "Label213"
        Me.Label213.Size = New System.Drawing.Size(96, 16)
        Me.Label213.TabIndex = 17
        Me.Label213.Text = "Nb buses usées :"
        Me.Label213.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_nbBusesUsees
        '
        Me.diagBuses_nbBusesUsees.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.diagBuses_nbBusesUsees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_nbBusesUsees.ForceBindingOnTextChanged = False
        Me.diagBuses_nbBusesUsees.Location = New System.Drawing.Point(344, 390)
        Me.diagBuses_nbBusesUsees.Name = "diagBuses_nbBusesUsees"
        Me.diagBuses_nbBusesUsees.ReadOnly = True
        Me.diagBuses_nbBusesUsees.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_nbBusesUsees.TabIndex = 20
        '
        'Label52
        '
        Me.Label52.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label52.Location = New System.Drawing.Point(638, 395)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(186, 16)
        Me.Label52.TabIndex = 17
        Me.Label52.Text = "Résultat du jeu de buse : "
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(16, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(184, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Nombre de niveaux de buses :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_conf_nbCategories
        '
        Me.diagBuses_conf_nbCategories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_conf_nbCategories.ForceBindingOnTextChanged = False
        Me.diagBuses_conf_nbCategories.Location = New System.Drawing.Point(200, 8)
        Me.diagBuses_conf_nbCategories.Name = "diagBuses_conf_nbCategories"
        Me.diagBuses_conf_nbCategories.Size = New System.Drawing.Size(100, 20)
        Me.diagBuses_conf_nbCategories.TabIndex = 1
        '
        'diagBuses_tab_categories
        '
        Me.diagBuses_tab_categories.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.diagBuses_tab_categories.Controls.Add(Me.TabPage3)
        Me.diagBuses_tab_categories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_tab_categories.ImageList = Me.ImageList_onglets
        Me.diagBuses_tab_categories.Location = New System.Drawing.Point(8, 40)
        Me.diagBuses_tab_categories.Name = "diagBuses_tab_categories"
        Me.diagBuses_tab_categories.SelectedIndex = 0
        Me.diagBuses_tab_categories.Size = New System.Drawing.Size(992, 349)
        Me.diagBuses_tab_categories.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tbModele_DebitMaxi)
        Me.TabPage3.Controls.Add(Me.lblModele_DebitMaxi)
        Me.TabPage3.Controls.Add(Me.tbModele_DebitMini)
        Me.TabPage3.Controls.Add(Me.lblModele_DebitMini)
        Me.TabPage3.Controls.Add(Me.TbModele_Calibre)
        Me.TabPage3.Controls.Add(Me.cbxModele_EcartTolere)
        Me.TabPage3.Controls.Add(Me.cbxModele_Marque)
        Me.TabPage3.Controls.Add(Me.pblModele_tabMesuresBuses)
        Me.TabPage3.Controls.Add(Me.tbModele_NombreDeBuses)
        Me.TabPage3.Controls.Add(Me.LblModele_NombreDeBuses)
        Me.TabPage3.Controls.Add(Me.tbModele_DebitNominalContructeur)
        Me.TabPage3.Controls.Add(Me.lblModele_EcartTolere)
        Me.TabPage3.Controls.Add(Me.lblModele_DebitNominalConstructeur)
        Me.TabPage3.Controls.Add(Me.btnModele_validerNbBuses)
        Me.TabPage3.Controls.Add(Me.tbModele_DebitNominalPourCalcul)
        Me.TabPage3.Controls.Add(Me.lblModele_DebitNominalPourCalcul)
        Me.TabPage3.Controls.Add(Me.tbModele_UsureMoyenne)
        Me.TabPage3.Controls.Add(Me.lblModele_UsureMoyenne)
        Me.TabPage3.Controls.Add(Me.tbModele_DebitMoyen)
        Me.TabPage3.Controls.Add(Me.lblModele_DebitMoyen)
        Me.TabPage3.Controls.Add(Me.tbModele_NbBusesUsees)
        Me.TabPage3.Controls.Add(Me.lblModele_NbBusesUsees)
        Me.TabPage3.Controls.Add(Me.lblModele_Marque)
        Me.TabPage3.Controls.Add(Me.lblModele_Modele)
        Me.TabPage3.Controls.Add(Me.cbxModele_Modele)
        Me.TabPage3.Controls.Add(Me.lblModele_Couleur)
        Me.TabPage3.Controls.Add(Me.lblModele_Calibre)
        Me.TabPage3.Controls.Add(Me.cbxModele_Couleur)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(984, 322)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Niveau 1"
        '
        'cbxModele_Couleur
        '
        Me.cbxModele_Couleur.Location = New System.Drawing.Point(880, 7)
        Me.cbxModele_Couleur.Name = "cbxModele_Couleur"
        Me.cbxModele_Couleur.Size = New System.Drawing.Size(96, 21)
        Me.cbxModele_Couleur.TabIndex = 28
        '
        'lblModele_Calibre
        '
        Me.lblModele_Calibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_Calibre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_Calibre.Location = New System.Drawing.Point(824, 40)
        Me.lblModele_Calibre.Name = "lblModele_Calibre"
        Me.lblModele_Calibre.Size = New System.Drawing.Size(56, 16)
        Me.lblModele_Calibre.TabIndex = 16
        Me.lblModele_Calibre.Text = "Calibre :"
        Me.lblModele_Calibre.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblModele_Couleur
        '
        Me.lblModele_Couleur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_Couleur.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_Couleur.Location = New System.Drawing.Point(808, 8)
        Me.lblModele_Couleur.Name = "lblModele_Couleur"
        Me.lblModele_Couleur.Size = New System.Drawing.Size(72, 16)
        Me.lblModele_Couleur.TabIndex = 16
        Me.lblModele_Couleur.Text = "Couleur :"
        Me.lblModele_Couleur.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cbxModele_Modele
        '
        Me.cbxModele_Modele.Location = New System.Drawing.Point(712, 40)
        Me.cbxModele_Modele.Name = "cbxModele_Modele"
        Me.cbxModele_Modele.Size = New System.Drawing.Size(96, 21)
        Me.cbxModele_Modele.TabIndex = 28
        '
        'lblModele_Modele
        '
        Me.lblModele_Modele.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_Modele.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_Modele.Location = New System.Drawing.Point(656, 40)
        Me.lblModele_Modele.Name = "lblModele_Modele"
        Me.lblModele_Modele.Size = New System.Drawing.Size(56, 16)
        Me.lblModele_Modele.TabIndex = 16
        Me.lblModele_Modele.Text = "Modèle :"
        Me.lblModele_Modele.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblModele_Marque
        '
        Me.lblModele_Marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_Marque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_Marque.Location = New System.Drawing.Point(649, 8)
        Me.lblModele_Marque.Name = "lblModele_Marque"
        Me.lblModele_Marque.Size = New System.Drawing.Size(63, 16)
        Me.lblModele_Marque.TabIndex = 16
        Me.lblModele_Marque.Text = "Marque :"
        Me.lblModele_Marque.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblModele_NbBusesUsees
        '
        Me.lblModele_NbBusesUsees.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModele_NbBusesUsees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_NbBusesUsees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_NbBusesUsees.Location = New System.Drawing.Point(544, 267)
        Me.lblModele_NbBusesUsees.Name = "lblModele_NbBusesUsees"
        Me.lblModele_NbBusesUsees.Size = New System.Drawing.Size(128, 16)
        Me.lblModele_NbBusesUsees.TabIndex = 17
        Me.lblModele_NbBusesUsees.Text = "Nb buses usées :"
        Me.lblModele_NbBusesUsees.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbModele_NbBusesUsees
        '
        Me.tbModele_NbBusesUsees.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbModele_NbBusesUsees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModele_NbBusesUsees.ForceBindingOnTextChanged = False
        Me.tbModele_NbBusesUsees.Location = New System.Drawing.Point(680, 266)
        Me.tbModele_NbBusesUsees.Name = "tbModele_NbBusesUsees"
        Me.tbModele_NbBusesUsees.ReadOnly = True
        Me.tbModele_NbBusesUsees.Size = New System.Drawing.Size(56, 20)
        Me.tbModele_NbBusesUsees.TabIndex = 20
        '
        'lblModele_DebitMoyen
        '
        Me.lblModele_DebitMoyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblModele_DebitMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_DebitMoyen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_DebitMoyen.Location = New System.Drawing.Point(18, 267)
        Me.lblModele_DebitMoyen.Name = "lblModele_DebitMoyen"
        Me.lblModele_DebitMoyen.Size = New System.Drawing.Size(80, 16)
        Me.lblModele_DebitMoyen.TabIndex = 17
        Me.lblModele_DebitMoyen.Text = "Débit moyen :"
        Me.lblModele_DebitMoyen.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbModele_DebitMoyen
        '
        Me.tbModele_DebitMoyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbModele_DebitMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModele_DebitMoyen.ForceBindingOnTextChanged = False
        Me.tbModele_DebitMoyen.Location = New System.Drawing.Point(104, 266)
        Me.tbModele_DebitMoyen.Name = "tbModele_DebitMoyen"
        Me.tbModele_DebitMoyen.ReadOnly = True
        Me.tbModele_DebitMoyen.Size = New System.Drawing.Size(56, 20)
        Me.tbModele_DebitMoyen.TabIndex = 20
        '
        'lblModele_UsureMoyenne
        '
        Me.lblModele_UsureMoyenne.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModele_UsureMoyenne.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_UsureMoyenne.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_UsureMoyenne.Location = New System.Drawing.Point(737, 267)
        Me.lblModele_UsureMoyenne.Name = "lblModele_UsureMoyenne"
        Me.lblModele_UsureMoyenne.Size = New System.Drawing.Size(167, 16)
        Me.lblModele_UsureMoyenne.TabIndex = 17
        Me.lblModele_UsureMoyenne.Text = "Usure moyenne des buses :"
        Me.lblModele_UsureMoyenne.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbModele_UsureMoyenne
        '
        Me.tbModele_UsureMoyenne.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbModele_UsureMoyenne.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModele_UsureMoyenne.ForceBindingOnTextChanged = False
        Me.tbModele_UsureMoyenne.Location = New System.Drawing.Point(912, 266)
        Me.tbModele_UsureMoyenne.Name = "tbModele_UsureMoyenne"
        Me.tbModele_UsureMoyenne.ReadOnly = True
        Me.tbModele_UsureMoyenne.Size = New System.Drawing.Size(56, 20)
        Me.tbModele_UsureMoyenne.TabIndex = 20
        '
        'lblModele_DebitNominalPourCalcul
        '
        Me.lblModele_DebitNominalPourCalcul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_DebitNominalPourCalcul.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_DebitNominalPourCalcul.Location = New System.Drawing.Point(192, 40)
        Me.lblModele_DebitNominalPourCalcul.Name = "lblModele_DebitNominalPourCalcul"
        Me.lblModele_DebitNominalPourCalcul.Size = New System.Drawing.Size(170, 16)
        Me.lblModele_DebitNominalPourCalcul.TabIndex = 17
        Me.lblModele_DebitNominalPourCalcul.Text = "Débit nominal pour calcul * :"
        Me.lblModele_DebitNominalPourCalcul.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbModele_DebitNominalPourCalcul
        '
        Me.tbModele_DebitNominalPourCalcul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModele_DebitNominalPourCalcul.ForceBindingOnTextChanged = False
        Me.tbModele_DebitNominalPourCalcul.Location = New System.Drawing.Point(368, 40)
        Me.tbModele_DebitNominalPourCalcul.Name = "tbModele_DebitNominalPourCalcul"
        Me.tbModele_DebitNominalPourCalcul.ReadOnly = True
        Me.tbModele_DebitNominalPourCalcul.Size = New System.Drawing.Size(56, 20)
        Me.tbModele_DebitNominalPourCalcul.TabIndex = 20
        '
        'btnModele_validerNbBuses
        '
        Me.btnModele_validerNbBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModele_validerNbBuses.ForeColor = System.Drawing.Color.White
        Me.btnModele_validerNbBuses.Image = CType(resources.GetObject("btnModele_validerNbBuses.Image"), System.Drawing.Image)
        Me.btnModele_validerNbBuses.Location = New System.Drawing.Point(40, 32)
        Me.btnModele_validerNbBuses.Name = "btnModele_validerNbBuses"
        Me.btnModele_validerNbBuses.Size = New System.Drawing.Size(128, 24)
        Me.btnModele_validerNbBuses.TabIndex = 26
        Me.btnModele_validerNbBuses.Text = "    Valider"
        Me.btnModele_validerNbBuses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblModele_DebitNominalConstructeur
        '
        Me.lblModele_DebitNominalConstructeur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_DebitNominalConstructeur.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_DebitNominalConstructeur.Location = New System.Drawing.Point(192, 8)
        Me.lblModele_DebitNominalConstructeur.Name = "lblModele_DebitNominalConstructeur"
        Me.lblModele_DebitNominalConstructeur.Size = New System.Drawing.Size(168, 16)
        Me.lblModele_DebitNominalConstructeur.TabIndex = 17
        Me.lblModele_DebitNominalConstructeur.Text = "Débit nominal constructeur :"
        Me.lblModele_DebitNominalConstructeur.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblModele_EcartTolere
        '
        Me.lblModele_EcartTolere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_EcartTolere.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_EcartTolere.Location = New System.Drawing.Point(419, 8)
        Me.lblModele_EcartTolere.Name = "lblModele_EcartTolere"
        Me.lblModele_EcartTolere.Size = New System.Drawing.Size(165, 16)
        Me.lblModele_EcartTolere.TabIndex = 16
        Me.lblModele_EcartTolere.Text = "Ecart toléré (10 ou 15 %) :"
        Me.lblModele_EcartTolere.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbModele_DebitNominalContructeur
        '
        Me.tbModele_DebitNominalContructeur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModele_DebitNominalContructeur.ForceBindingOnTextChanged = False
        Me.tbModele_DebitNominalContructeur.Location = New System.Drawing.Point(368, 8)
        Me.tbModele_DebitNominalContructeur.Name = "tbModele_DebitNominalContructeur"
        Me.tbModele_DebitNominalContructeur.Size = New System.Drawing.Size(56, 20)
        Me.tbModele_DebitNominalContructeur.TabIndex = 20
        '
        'LblModele_NombreDeBuses
        '
        Me.LblModele_NombreDeBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModele_NombreDeBuses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblModele_NombreDeBuses.Location = New System.Drawing.Point(8, 8)
        Me.LblModele_NombreDeBuses.Name = "LblModele_NombreDeBuses"
        Me.LblModele_NombreDeBuses.Size = New System.Drawing.Size(120, 16)
        Me.LblModele_NombreDeBuses.TabIndex = 15
        Me.LblModele_NombreDeBuses.Text = "Nombre de buses : "
        Me.LblModele_NombreDeBuses.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbModele_NombreDeBuses
        '
        Me.tbModele_NombreDeBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModele_NombreDeBuses.ForceBindingOnTextChanged = False
        Me.tbModele_NombreDeBuses.Location = New System.Drawing.Point(136, 8)
        Me.tbModele_NombreDeBuses.Name = "tbModele_NombreDeBuses"
        Me.tbModele_NombreDeBuses.Size = New System.Drawing.Size(56, 20)
        Me.tbModele_NombreDeBuses.TabIndex = 21
        '
        'pblModele_tabMesuresBuses
        '
        Me.pblModele_tabMesuresBuses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pblModele_tabMesuresBuses.AutoScroll = True
        Me.pblModele_tabMesuresBuses.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.pblModele_tabMesuresBuses.Controls.Add(Me.Panel68)
        Me.pblModele_tabMesuresBuses.Controls.Add(Me.Panel70)
        Me.pblModele_tabMesuresBuses.Controls.Add(Me.Panel12)
        Me.pblModele_tabMesuresBuses.Controls.Add(Me.pnlModele_tabMesureSecondaire)
        Me.pblModele_tabMesuresBuses.Location = New System.Drawing.Point(16, 72)
        Me.pblModele_tabMesuresBuses.Name = "pblModele_tabMesuresBuses"
        Me.pblModele_tabMesuresBuses.Size = New System.Drawing.Size(952, 184)
        Me.pblModele_tabMesuresBuses.TabIndex = 24
        '
        'pnlModele_tabMesureSecondaire
        '
        Me.pnlModele_tabMesureSecondaire.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlModele_tabMesureSecondaire.AutoScroll = True
        Me.pnlModele_tabMesureSecondaire.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel69)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel71)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel38)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel49)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel66)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel67)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel97)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel98)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel99)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel100)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel101)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel102)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel103)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel104)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel105)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel106)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel107)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel108)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel109)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel110)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel111)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel112)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel113)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel114)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel115)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel116)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel117)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel118)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel119)
        Me.pnlModele_tabMesureSecondaire.Controls.Add(Me.Panel120)
        Me.pnlModele_tabMesureSecondaire.Location = New System.Drawing.Point(72, 0)
        Me.pnlModele_tabMesureSecondaire.Name = "pnlModele_tabMesureSecondaire"
        Me.pnlModele_tabMesureSecondaire.Size = New System.Drawing.Size(880, 184)
        Me.pnlModele_tabMesureSecondaire.TabIndex = 25
        '
        'Panel120
        '
        Me.Panel120.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel120.Controls.Add(Me.TextBox47)
        Me.Panel120.Location = New System.Drawing.Point(793, 41)
        Me.Panel120.Name = "Panel120"
        Me.Panel120.Size = New System.Drawing.Size(87, 71)
        Me.Panel120.TabIndex = 18
        '
        'TextBox47
        '
        Me.TextBox47.ForceBindingOnTextChanged = False
        Me.TextBox47.Location = New System.Drawing.Point(15, 25)
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New System.Drawing.Size(56, 20)
        Me.TextBox47.TabIndex = 15
        '
        'Panel119
        '
        Me.Panel119.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel119.Controls.Add(Me.Label47)
        Me.Panel119.Location = New System.Drawing.Point(793, 0)
        Me.Panel119.Name = "Panel119"
        Me.Panel119.Size = New System.Drawing.Size(87, 40)
        Me.Panel119.TabIndex = 21
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label47.Location = New System.Drawing.Point(29, 12)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(28, 16)
        Me.Label47.TabIndex = 13
        Me.Label47.Text = "2"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel118
        '
        Me.Panel118.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel118.Controls.Add(Me.TextBox46)
        Me.Panel118.Location = New System.Drawing.Point(793, 113)
        Me.Panel118.Name = "Panel118"
        Me.Panel118.Size = New System.Drawing.Size(87, 71)
        Me.Panel118.TabIndex = 18
        '
        'TextBox46
        '
        Me.TextBox46.ForceBindingOnTextChanged = False
        Me.TextBox46.Location = New System.Drawing.Point(15, 25)
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.ReadOnly = True
        Me.TextBox46.Size = New System.Drawing.Size(56, 20)
        Me.TextBox46.TabIndex = 15
        '
        'Panel117
        '
        Me.Panel117.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel117.Controls.Add(Me.Label46)
        Me.Panel117.Location = New System.Drawing.Point(705, 0)
        Me.Panel117.Name = "Panel117"
        Me.Panel117.Size = New System.Drawing.Size(87, 40)
        Me.Panel117.TabIndex = 21
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(29, 12)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(28, 16)
        Me.Label46.TabIndex = 13
        Me.Label46.Text = "2"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel116
        '
        Me.Panel116.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel116.Controls.Add(Me.TextBox45)
        Me.Panel116.Location = New System.Drawing.Point(705, 41)
        Me.Panel116.Name = "Panel116"
        Me.Panel116.Size = New System.Drawing.Size(87, 71)
        Me.Panel116.TabIndex = 18
        '
        'TextBox45
        '
        Me.TextBox45.ForceBindingOnTextChanged = False
        Me.TextBox45.Location = New System.Drawing.Point(15, 25)
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Size = New System.Drawing.Size(56, 20)
        Me.TextBox45.TabIndex = 15
        '
        'Panel115
        '
        Me.Panel115.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel115.Controls.Add(Me.TextBox44)
        Me.Panel115.Location = New System.Drawing.Point(705, 113)
        Me.Panel115.Name = "Panel115"
        Me.Panel115.Size = New System.Drawing.Size(87, 71)
        Me.Panel115.TabIndex = 18
        '
        'TextBox44
        '
        Me.TextBox44.ForceBindingOnTextChanged = False
        Me.TextBox44.Location = New System.Drawing.Point(15, 25)
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.ReadOnly = True
        Me.TextBox44.Size = New System.Drawing.Size(56, 20)
        Me.TextBox44.TabIndex = 15
        '
        'Panel114
        '
        Me.Panel114.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel114.Controls.Add(Me.Label45)
        Me.Panel114.Location = New System.Drawing.Point(617, 0)
        Me.Panel114.Name = "Panel114"
        Me.Panel114.Size = New System.Drawing.Size(87, 40)
        Me.Panel114.TabIndex = 21
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(29, 12)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(28, 16)
        Me.Label45.TabIndex = 13
        Me.Label45.Text = "2"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel113
        '
        Me.Panel113.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel113.Controls.Add(Me.TextBox42)
        Me.Panel113.Location = New System.Drawing.Point(617, 41)
        Me.Panel113.Name = "Panel113"
        Me.Panel113.Size = New System.Drawing.Size(87, 71)
        Me.Panel113.TabIndex = 18
        '
        'TextBox42
        '
        Me.TextBox42.ForceBindingOnTextChanged = False
        Me.TextBox42.Location = New System.Drawing.Point(15, 25)
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New System.Drawing.Size(56, 20)
        Me.TextBox42.TabIndex = 15
        '
        'Panel112
        '
        Me.Panel112.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel112.Controls.Add(Me.TextBox41)
        Me.Panel112.Location = New System.Drawing.Point(617, 113)
        Me.Panel112.Name = "Panel112"
        Me.Panel112.Size = New System.Drawing.Size(87, 71)
        Me.Panel112.TabIndex = 18
        '
        'TextBox41
        '
        Me.TextBox41.ForceBindingOnTextChanged = False
        Me.TextBox41.Location = New System.Drawing.Point(15, 25)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.ReadOnly = True
        Me.TextBox41.Size = New System.Drawing.Size(56, 20)
        Me.TextBox41.TabIndex = 15
        '
        'Panel111
        '
        Me.Panel111.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel111.Controls.Add(Me.TextBox40)
        Me.Panel111.Location = New System.Drawing.Point(529, 41)
        Me.Panel111.Name = "Panel111"
        Me.Panel111.Size = New System.Drawing.Size(87, 71)
        Me.Panel111.TabIndex = 18
        '
        'TextBox40
        '
        Me.TextBox40.ForceBindingOnTextChanged = False
        Me.TextBox40.Location = New System.Drawing.Point(15, 25)
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New System.Drawing.Size(56, 20)
        Me.TextBox40.TabIndex = 15
        '
        'Panel110
        '
        Me.Panel110.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel110.Controls.Add(Me.Label44)
        Me.Panel110.Location = New System.Drawing.Point(529, 0)
        Me.Panel110.Name = "Panel110"
        Me.Panel110.Size = New System.Drawing.Size(87, 40)
        Me.Panel110.TabIndex = 21
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(29, 12)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(28, 16)
        Me.Label44.TabIndex = 13
        Me.Label44.Text = "2"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel109
        '
        Me.Panel109.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel109.Controls.Add(Me.TextBox39)
        Me.Panel109.Location = New System.Drawing.Point(529, 113)
        Me.Panel109.Name = "Panel109"
        Me.Panel109.Size = New System.Drawing.Size(87, 71)
        Me.Panel109.TabIndex = 18
        '
        'TextBox39
        '
        Me.TextBox39.ForceBindingOnTextChanged = False
        Me.TextBox39.Location = New System.Drawing.Point(15, 25)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.ReadOnly = True
        Me.TextBox39.Size = New System.Drawing.Size(56, 20)
        Me.TextBox39.TabIndex = 15
        '
        'Panel108
        '
        Me.Panel108.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel108.Controls.Add(Me.TextBox38)
        Me.Panel108.Location = New System.Drawing.Point(441, 41)
        Me.Panel108.Name = "Panel108"
        Me.Panel108.Size = New System.Drawing.Size(87, 71)
        Me.Panel108.TabIndex = 18
        '
        'TextBox38
        '
        Me.TextBox38.ForceBindingOnTextChanged = False
        Me.TextBox38.Location = New System.Drawing.Point(15, 25)
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New System.Drawing.Size(56, 20)
        Me.TextBox38.TabIndex = 15
        '
        'Panel107
        '
        Me.Panel107.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel107.Controls.Add(Me.Textbox37)
        Me.Panel107.Location = New System.Drawing.Point(441, 113)
        Me.Panel107.Name = "Panel107"
        Me.Panel107.Size = New System.Drawing.Size(87, 71)
        Me.Panel107.TabIndex = 18
        '
        'Textbox37
        '
        Me.Textbox37.ForceBindingOnTextChanged = False
        Me.Textbox37.Location = New System.Drawing.Point(15, 25)
        Me.Textbox37.Name = "Textbox37"
        Me.Textbox37.ReadOnly = True
        Me.Textbox37.Size = New System.Drawing.Size(56, 20)
        Me.Textbox37.TabIndex = 15
        '
        'Panel106
        '
        Me.Panel106.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel106.Controls.Add(Me.Label43)
        Me.Panel106.Location = New System.Drawing.Point(441, 0)
        Me.Panel106.Name = "Panel106"
        Me.Panel106.Size = New System.Drawing.Size(87, 40)
        Me.Panel106.TabIndex = 21
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label43.Location = New System.Drawing.Point(29, 12)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(28, 16)
        Me.Label43.TabIndex = 13
        Me.Label43.Text = "2"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel105
        '
        Me.Panel105.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel105.Controls.Add(Me.Label42)
        Me.Panel105.Location = New System.Drawing.Point(353, 0)
        Me.Panel105.Name = "Panel105"
        Me.Panel105.Size = New System.Drawing.Size(87, 40)
        Me.Panel105.TabIndex = 21
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(29, 12)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(28, 16)
        Me.Label42.TabIndex = 13
        Me.Label42.Text = "2"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel104
        '
        Me.Panel104.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel104.Controls.Add(Me.Textbox36)
        Me.Panel104.Location = New System.Drawing.Point(353, 41)
        Me.Panel104.Name = "Panel104"
        Me.Panel104.Size = New System.Drawing.Size(87, 71)
        Me.Panel104.TabIndex = 18
        '
        'Textbox36
        '
        Me.Textbox36.ForceBindingOnTextChanged = False
        Me.Textbox36.Location = New System.Drawing.Point(15, 25)
        Me.Textbox36.Name = "Textbox36"
        Me.Textbox36.Size = New System.Drawing.Size(56, 20)
        Me.Textbox36.TabIndex = 15
        '
        'Panel103
        '
        Me.Panel103.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel103.Controls.Add(Me.Textbox35)
        Me.Panel103.Location = New System.Drawing.Point(353, 113)
        Me.Panel103.Name = "Panel103"
        Me.Panel103.Size = New System.Drawing.Size(87, 71)
        Me.Panel103.TabIndex = 18
        '
        'Textbox35
        '
        Me.Textbox35.ForceBindingOnTextChanged = False
        Me.Textbox35.Location = New System.Drawing.Point(15, 25)
        Me.Textbox35.Name = "Textbox35"
        Me.Textbox35.ReadOnly = True
        Me.Textbox35.Size = New System.Drawing.Size(56, 20)
        Me.Textbox35.TabIndex = 15
        '
        'Panel102
        '
        Me.Panel102.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel102.Controls.Add(Me.Label41)
        Me.Panel102.Location = New System.Drawing.Point(265, 0)
        Me.Panel102.Name = "Panel102"
        Me.Panel102.Size = New System.Drawing.Size(87, 40)
        Me.Panel102.TabIndex = 21
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(29, 12)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(28, 16)
        Me.Label41.TabIndex = 13
        Me.Label41.Text = "2"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel101
        '
        Me.Panel101.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel101.Controls.Add(Me.Textbox34)
        Me.Panel101.Location = New System.Drawing.Point(265, 41)
        Me.Panel101.Name = "Panel101"
        Me.Panel101.Size = New System.Drawing.Size(87, 71)
        Me.Panel101.TabIndex = 18
        '
        'Textbox34
        '
        Me.Textbox34.ForceBindingOnTextChanged = False
        Me.Textbox34.Location = New System.Drawing.Point(15, 25)
        Me.Textbox34.Name = "Textbox34"
        Me.Textbox34.Size = New System.Drawing.Size(56, 20)
        Me.Textbox34.TabIndex = 15
        '
        'Panel100
        '
        Me.Panel100.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel100.Controls.Add(Me.Textbox33)
        Me.Panel100.Location = New System.Drawing.Point(265, 113)
        Me.Panel100.Name = "Panel100"
        Me.Panel100.Size = New System.Drawing.Size(87, 71)
        Me.Panel100.TabIndex = 18
        '
        'Textbox33
        '
        Me.Textbox33.ForceBindingOnTextChanged = False
        Me.Textbox33.Location = New System.Drawing.Point(15, 25)
        Me.Textbox33.Name = "Textbox33"
        Me.Textbox33.ReadOnly = True
        Me.Textbox33.Size = New System.Drawing.Size(56, 20)
        Me.Textbox33.TabIndex = 15
        '
        'Panel99
        '
        Me.Panel99.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel99.Controls.Add(Me.Label40)
        Me.Panel99.Location = New System.Drawing.Point(177, 0)
        Me.Panel99.Name = "Panel99"
        Me.Panel99.Size = New System.Drawing.Size(87, 40)
        Me.Panel99.TabIndex = 21
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(29, 12)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(28, 16)
        Me.Label40.TabIndex = 13
        Me.Label40.Text = "2"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel98
        '
        Me.Panel98.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel98.Controls.Add(Me.Textbox32)
        Me.Panel98.Location = New System.Drawing.Point(177, 41)
        Me.Panel98.Name = "Panel98"
        Me.Panel98.Size = New System.Drawing.Size(87, 71)
        Me.Panel98.TabIndex = 18
        '
        'Textbox32
        '
        Me.Textbox32.ForceBindingOnTextChanged = False
        Me.Textbox32.Location = New System.Drawing.Point(15, 25)
        Me.Textbox32.Name = "Textbox32"
        Me.Textbox32.Size = New System.Drawing.Size(56, 20)
        Me.Textbox32.TabIndex = 15
        '
        'Panel97
        '
        Me.Panel97.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel97.Controls.Add(Me.Textbox31)
        Me.Panel97.Location = New System.Drawing.Point(177, 113)
        Me.Panel97.Name = "Panel97"
        Me.Panel97.Size = New System.Drawing.Size(87, 71)
        Me.Panel97.TabIndex = 18
        '
        'Textbox31
        '
        Me.Textbox31.ForceBindingOnTextChanged = False
        Me.Textbox31.Location = New System.Drawing.Point(15, 25)
        Me.Textbox31.Name = "Textbox31"
        Me.Textbox31.ReadOnly = True
        Me.Textbox31.Size = New System.Drawing.Size(56, 20)
        Me.Textbox31.TabIndex = 15
        '
        'Panel67
        '
        Me.Panel67.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel67.Controls.Add(Me.Label18)
        Me.Panel67.Location = New System.Drawing.Point(1, 0)
        Me.Panel67.Name = "Panel67"
        Me.Panel67.Size = New System.Drawing.Size(87, 40)
        Me.Panel67.TabIndex = 20
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(29, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(28, 16)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "1"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel66
        '
        Me.Panel66.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel66.Controls.Add(Me.Label17)
        Me.Panel66.Location = New System.Drawing.Point(89, 0)
        Me.Panel66.Name = "Panel66"
        Me.Panel66.Size = New System.Drawing.Size(87, 40)
        Me.Panel66.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(29, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 16)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "2"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel49
        '
        Me.Panel49.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel49.Controls.Add(Me.Textbox6)
        Me.Panel49.Location = New System.Drawing.Point(89, 113)
        Me.Panel49.Name = "Panel49"
        Me.Panel49.Size = New System.Drawing.Size(87, 71)
        Me.Panel49.TabIndex = 18
        '
        'Textbox6
        '
        Me.Textbox6.ForceBindingOnTextChanged = False
        Me.Textbox6.Location = New System.Drawing.Point(15, 25)
        Me.Textbox6.Name = "Textbox6"
        Me.Textbox6.ReadOnly = True
        Me.Textbox6.Size = New System.Drawing.Size(56, 20)
        Me.Textbox6.TabIndex = 15
        '
        'Panel38
        '
        Me.Panel38.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel38.Controls.Add(Me.TextBox5)
        Me.Panel38.Location = New System.Drawing.Point(1, 113)
        Me.Panel38.Name = "Panel38"
        Me.Panel38.Size = New System.Drawing.Size(87, 71)
        Me.Panel38.TabIndex = 17
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.ForceBindingOnTextChanged = False
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox5.Location = New System.Drawing.Point(15, 25)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(56, 20)
        Me.TextBox5.TabIndex = 14
        '
        'Panel71
        '
        Me.Panel71.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel71.Controls.Add(Me.diagBuses_mesureDebit_1_debit)
        Me.Panel71.Location = New System.Drawing.Point(1, 41)
        Me.Panel71.Name = "Panel71"
        Me.Panel71.Size = New System.Drawing.Size(87, 71)
        Me.Panel71.TabIndex = 17
        '
        'diagBuses_mesureDebit_1_debit
        '
        Me.diagBuses_mesureDebit_1_debit.ForceBindingOnTextChanged = False
        Me.diagBuses_mesureDebit_1_debit.Location = New System.Drawing.Point(15, 25)
        Me.diagBuses_mesureDebit_1_debit.Name = "diagBuses_mesureDebit_1_debit"
        Me.diagBuses_mesureDebit_1_debit.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_mesureDebit_1_debit.TabIndex = 14
        '
        'Panel69
        '
        Me.Panel69.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel69.Controls.Add(Me.diagBuses_mesureDebit_2_debit)
        Me.Panel69.Location = New System.Drawing.Point(89, 41)
        Me.Panel69.Name = "Panel69"
        Me.Panel69.Size = New System.Drawing.Size(87, 71)
        Me.Panel69.TabIndex = 18
        '
        'diagBuses_mesureDebit_2_debit
        '
        Me.diagBuses_mesureDebit_2_debit.ForceBindingOnTextChanged = False
        Me.diagBuses_mesureDebit_2_debit.Location = New System.Drawing.Point(15, 25)
        Me.diagBuses_mesureDebit_2_debit.Name = "diagBuses_mesureDebit_2_debit"
        Me.diagBuses_mesureDebit_2_debit.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_mesureDebit_2_debit.TabIndex = 15
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel12.Controls.Add(Me.Label79)
        Me.Panel12.Location = New System.Drawing.Point(0, 113)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(72, 71)
        Me.Panel12.TabIndex = 16
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label79.Location = New System.Drawing.Point(4, 27)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(64, 16)
        Me.Label79.TabIndex = 9
        Me.Label79.Text = "Usure (%)"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel70
        '
        Me.Panel70.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel70.Controls.Add(Me.Label80)
        Me.Panel70.Location = New System.Drawing.Point(0, 41)
        Me.Panel70.Name = "Panel70"
        Me.Panel70.Size = New System.Drawing.Size(72, 71)
        Me.Panel70.TabIndex = 16
        '
        'Label80
        '
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label80.Location = New System.Drawing.Point(8, 27)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(56, 16)
        Me.Label80.TabIndex = 8
        Me.Label80.Text = "Débit"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel68
        '
        Me.Panel68.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel68.Controls.Add(Me.Label81)
        Me.Panel68.Location = New System.Drawing.Point(0, 0)
        Me.Panel68.Name = "Panel68"
        Me.Panel68.Size = New System.Drawing.Size(72, 40)
        Me.Panel68.TabIndex = 19
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label81.Location = New System.Drawing.Point(16, 12)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(40, 16)
        Me.Label81.TabIndex = 6
        Me.Label81.Text = "N°"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbxModele_Marque
        '
        Me.cbxModele_Marque.Location = New System.Drawing.Point(712, 7)
        Me.cbxModele_Marque.Name = "cbxModele_Marque"
        Me.cbxModele_Marque.Size = New System.Drawing.Size(96, 21)
        Me.cbxModele_Marque.TabIndex = 28
        '
        'cbxModele_EcartTolere
        '
        Me.cbxModele_EcartTolere.Items.AddRange(New Object() {"10", "15"})
        Me.cbxModele_EcartTolere.Location = New System.Drawing.Point(592, 7)
        Me.cbxModele_EcartTolere.Name = "cbxModele_EcartTolere"
        Me.cbxModele_EcartTolere.Size = New System.Drawing.Size(56, 21)
        Me.cbxModele_EcartTolere.TabIndex = 29
        '
        'TbModele_Calibre
        '
        Me.TbModele_Calibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbModele_Calibre.ForceBindingOnTextChanged = False
        Me.TbModele_Calibre.Location = New System.Drawing.Point(880, 41)
        Me.TbModele_Calibre.Name = "TbModele_Calibre"
        Me.TbModele_Calibre.Size = New System.Drawing.Size(96, 20)
        Me.TbModele_Calibre.TabIndex = 30
        '
        'lblModele_DebitMini
        '
        Me.lblModele_DebitMini.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblModele_DebitMini.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_DebitMini.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_DebitMini.Location = New System.Drawing.Point(174, 267)
        Me.lblModele_DebitMini.Name = "lblModele_DebitMini"
        Me.lblModele_DebitMini.Size = New System.Drawing.Size(80, 16)
        Me.lblModele_DebitMini.TabIndex = 31
        Me.lblModele_DebitMini.Text = "Débit mini :"
        Me.lblModele_DebitMini.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbModele_DebitMini
        '
        Me.tbModele_DebitMini.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbModele_DebitMini.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModele_DebitMini.ForceBindingOnTextChanged = False
        Me.tbModele_DebitMini.Location = New System.Drawing.Point(280, 266)
        Me.tbModele_DebitMini.Name = "tbModele_DebitMini"
        Me.tbModele_DebitMini.ReadOnly = True
        Me.tbModele_DebitMini.Size = New System.Drawing.Size(56, 20)
        Me.tbModele_DebitMini.TabIndex = 32
        '
        'lblModele_DebitMaxi
        '
        Me.lblModele_DebitMaxi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblModele_DebitMaxi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModele_DebitMaxi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblModele_DebitMaxi.Location = New System.Drawing.Point(365, 267)
        Me.lblModele_DebitMaxi.Name = "lblModele_DebitMaxi"
        Me.lblModele_DebitMaxi.Size = New System.Drawing.Size(80, 16)
        Me.lblModele_DebitMaxi.TabIndex = 33
        Me.lblModele_DebitMaxi.Text = "Débit maxi :"
        Me.lblModele_DebitMaxi.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbModele_DebitMaxi
        '
        Me.tbModele_DebitMaxi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbModele_DebitMaxi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbModele_DebitMaxi.ForceBindingOnTextChanged = False
        Me.tbModele_DebitMaxi.Location = New System.Drawing.Point(456, 266)
        Me.tbModele_DebitMaxi.Name = "tbModele_DebitMaxi"
        Me.tbModele_DebitMaxi.ReadOnly = True
        Me.tbModele_DebitMaxi.Size = New System.Drawing.Size(56, 20)
        Me.tbModele_DebitMaxi.TabIndex = 34
        '
        'tbPressionMesure
        '
        Me.tbPressionMesure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPressionMesure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPressionMesure.ForceBindingOnTextChanged = False
        Me.tbPressionMesure.Location = New System.Drawing.Point(872, 8)
        Me.tbPressionMesure.Name = "tbPressionMesure"
        Me.tbPressionMesure.Size = New System.Drawing.Size(56, 20)
        Me.tbPressionMesure.TabIndex = 29
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(712, 8)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(152, 16)
        Me.Label33.TabIndex = 28
        Me.Label33.Text = "Pression de mesure (bar) :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_conf_validNbCategories
        '
        Me.diagBuses_conf_validNbCategories.Cursor = System.Windows.Forms.Cursors.Hand
        Me.diagBuses_conf_validNbCategories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_conf_validNbCategories.ForeColor = System.Drawing.Color.White
        Me.diagBuses_conf_validNbCategories.Image = CType(resources.GetObject("diagBuses_conf_validNbCategories.Image"), System.Drawing.Image)
        Me.diagBuses_conf_validNbCategories.Location = New System.Drawing.Point(304, 8)
        Me.diagBuses_conf_validNbCategories.Name = "diagBuses_conf_validNbCategories"
        Me.diagBuses_conf_validNbCategories.Size = New System.Drawing.Size(128, 24)
        Me.diagBuses_conf_validNbCategories.TabIndex = 26
        Me.diagBuses_conf_validNbCategories.Text = "    Valider"
        Me.diagBuses_conf_validNbCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diagBuses_conf_ajouterNiveau
        '
        Me.diagBuses_conf_ajouterNiveau.Cursor = System.Windows.Forms.Cursors.Hand
        Me.diagBuses_conf_ajouterNiveau.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_conf_ajouterNiveau.ForeColor = System.Drawing.Color.White
        Me.diagBuses_conf_ajouterNiveau.Image = CType(resources.GetObject("diagBuses_conf_ajouterNiveau.Image"), System.Drawing.Image)
        Me.diagBuses_conf_ajouterNiveau.Location = New System.Drawing.Point(440, 8)
        Me.diagBuses_conf_ajouterNiveau.Name = "diagBuses_conf_ajouterNiveau"
        Me.diagBuses_conf_ajouterNiveau.Size = New System.Drawing.Size(128, 24)
        Me.diagBuses_conf_ajouterNiveau.TabIndex = 35
        Me.diagBuses_conf_ajouterNiveau.Text = "        Ajouter un niveau"
        Me.diagBuses_conf_ajouterNiveau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LaDebitMoyen3bars
        '
        Me.LaDebitMoyen3bars.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LaDebitMoyen3bars.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaDebitMoyen3bars.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LaDebitMoyen3bars.Location = New System.Drawing.Point(20, 413)
        Me.LaDebitMoyen3bars.Name = "LaDebitMoyen3bars"
        Me.LaDebitMoyen3bars.Size = New System.Drawing.Size(144, 16)
        Me.LaDebitMoyen3bars.TabIndex = 36
        Me.LaDebitMoyen3bars.Text = "Débit moyen à 3  bars :"
        Me.LaDebitMoyen3bars.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbDebitMoyen3bars
        '
        Me.tbDebitMoyen3bars.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbDebitMoyen3bars.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDebitMoyen3bars.ForceBindingOnTextChanged = False
        Me.tbDebitMoyen3bars.Location = New System.Drawing.Point(166, 412)
        Me.tbDebitMoyen3bars.Name = "tbDebitMoyen3bars"
        Me.tbDebitMoyen3bars.ReadOnly = True
        Me.tbDebitMoyen3bars.Size = New System.Drawing.Size(56, 20)
        Me.tbDebitMoyen3bars.TabIndex = 37
        '
        'tabPage_diagnostique_manoTroncon
        '
        Me.tabPage_diagnostique_manoTroncon.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabPage_diagnostique_manoTroncon.Controls.Add(Me.pnl_833)
        Me.tabPage_diagnostique_manoTroncon.Controls.Add(Me.pnl542)
        Me.tabPage_diagnostique_manoTroncon.ImageIndex = 3
        Me.tabPage_diagnostique_manoTroncon.Location = New System.Drawing.Point(4, 23)
        Me.tabPage_diagnostique_manoTroncon.Name = "tabPage_diagnostique_manoTroncon"
        Me.tabPage_diagnostique_manoTroncon.Size = New System.Drawing.Size(1008, 653)
        Me.tabPage_diagnostique_manoTroncon.TabIndex = 6
        Me.tabPage_diagnostique_manoTroncon.Tag = "7"
        Me.tabPage_diagnostique_manoTroncon.Text = "Mano/Tronçon"
        '
        'pnl542
        '
        Me.pnl542.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl542.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.pnl542.Controls.Add(Me.btnRecalculer)
        Me.pnl542.Controls.Add(Me.manopulveIsUseCalibrateur)
        Me.pnl542.Controls.Add(Me.manopulveIsFaiblePression)
        Me.pnl542.Controls.Add(Me.GroupBox3)
        Me.pnl542.Controls.Add(Me.Lbl_diagnostic_542)
        Me.pnl542.Controls.Add(Me.Panel48)
        Me.pnl542.Controls.Add(Me.Label65)
        Me.pnl542.Controls.Add(Me.manoTroncon_listManoControle)
        Me.pnl542.Controls.Add(Me.manopulveIsFortePression)
        Me.pnl542.Controls.Add(Me.manopulveIsSaisieManuelle)
        Me.pnl542.Location = New System.Drawing.Point(0, 114)
        Me.pnl542.Name = "pnl542"
        Me.pnl542.Size = New System.Drawing.Size(1004, 230)
        Me.pnl542.TabIndex = 1
        '
        'manopulveIsSaisieManuelle
        '
        Me.manopulveIsSaisieManuelle.Checked = True
        Me.manopulveIsSaisieManuelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.manopulveIsSaisieManuelle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.manopulveIsSaisieManuelle.Location = New System.Drawing.Point(321, 50)
        Me.manopulveIsSaisieManuelle.Name = "manopulveIsSaisieManuelle"
        Me.manopulveIsSaisieManuelle.Size = New System.Drawing.Size(184, 16)
        Me.manopulveIsSaisieManuelle.TabIndex = 4
        Me.manopulveIsSaisieManuelle.TabStop = True
        Me.manopulveIsSaisieManuelle.Text = "Saisie manuelle pression"
        '
        'manopulveIsFortePression
        '
        Me.manopulveIsFortePression.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.manopulveIsFortePression.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.manopulveIsFortePression.Location = New System.Drawing.Point(193, 50)
        Me.manopulveIsFortePression.Name = "manopulveIsFortePression"
        Me.manopulveIsFortePression.Size = New System.Drawing.Size(122, 16)
        Me.manopulveIsFortePression.TabIndex = 3
        Me.manopulveIsFortePression.Text = "Forte pression"
        '
        'manoTroncon_listManoControle
        '
        Me.manoTroncon_listManoControle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.manoTroncon_listManoControle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.manoTroncon_listManoControle.Enabled = False
        Me.manoTroncon_listManoControle.Location = New System.Drawing.Point(680, 40)
        Me.manoTroncon_listManoControle.Name = "manoTroncon_listManoControle"
        Me.manoTroncon_listManoControle.Size = New System.Drawing.Size(288, 21)
        Me.manoTroncon_listManoControle.TabIndex = 1
        '
        'Label65
        '
        Me.Label65.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label65.Enabled = False
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label65.Location = New System.Drawing.Point(520, 40)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(152, 16)
        Me.Label65.TabIndex = 6
        Me.Label65.Text = "Sélection du manomètre :"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Panel48
        '
        Me.Panel48.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel48.Controls.Add(Me.Panel54)
        Me.Panel48.Controls.Add(Me.Panel53)
        Me.Panel48.Controls.Add(Me.Panel52)
        Me.Panel48.Controls.Add(Me.manopulvePression_panel_erreur)
        Me.Panel48.Controls.Add(Me.manopulvePression_panel_manoPulve)
        Me.Panel48.Controls.Add(Me.manopulvePression_panel_manoAgent)
        Me.Panel48.Controls.Add(Me.Panel46)
        Me.Panel48.Controls.Add(Me.Panel292)
        Me.Panel48.Location = New System.Drawing.Point(32, 72)
        Me.Panel48.Name = "Panel48"
        Me.Panel48.Size = New System.Drawing.Size(582, 152)
        Me.Panel48.TabIndex = 10
        '
        'Panel292
        '
        Me.Panel292.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel292.Controls.Add(Me.manopulvePressionImprecision_1)
        Me.Panel292.Controls.Add(Me.manopulvePressionImprecision_2)
        Me.Panel292.Controls.Add(Me.manopulvePressionImprecision_3)
        Me.Panel292.Controls.Add(Me.manopulvePressionImprecision_4)
        Me.Panel292.Location = New System.Drawing.Point(436, 41)
        Me.Panel292.Name = "Panel292"
        Me.Panel292.Size = New System.Drawing.Size(146, 111)
        Me.Panel292.TabIndex = 18
        '
        'manopulvePressionImprecision_4
        '
        Me.manopulvePressionImprecision_4.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionImprecision_4.ForceBindingOnTextChanged = False
        Me.manopulvePressionImprecision_4.Location = New System.Drawing.Point(16, 80)
        Me.manopulvePressionImprecision_4.Name = "manopulvePressionImprecision_4"
        Me.manopulvePressionImprecision_4.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionImprecision_4.TabIndex = 3
        Me.manopulvePressionImprecision_4.TabStop = False
        '
        'manopulvePressionImprecision_3
        '
        Me.manopulvePressionImprecision_3.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionImprecision_3.ForceBindingOnTextChanged = False
        Me.manopulvePressionImprecision_3.Location = New System.Drawing.Point(16, 56)
        Me.manopulvePressionImprecision_3.Name = "manopulvePressionImprecision_3"
        Me.manopulvePressionImprecision_3.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionImprecision_3.TabIndex = 2
        Me.manopulvePressionImprecision_3.TabStop = False
        '
        'manopulvePressionImprecision_2
        '
        Me.manopulvePressionImprecision_2.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionImprecision_2.ForceBindingOnTextChanged = False
        Me.manopulvePressionImprecision_2.Location = New System.Drawing.Point(16, 32)
        Me.manopulvePressionImprecision_2.Name = "manopulvePressionImprecision_2"
        Me.manopulvePressionImprecision_2.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionImprecision_2.TabIndex = 1
        Me.manopulvePressionImprecision_2.TabStop = False
        '
        'manopulvePressionImprecision_1
        '
        Me.manopulvePressionImprecision_1.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionImprecision_1.ForceBindingOnTextChanged = False
        Me.manopulvePressionImprecision_1.Location = New System.Drawing.Point(16, 9)
        Me.manopulvePressionImprecision_1.Name = "manopulvePressionImprecision_1"
        Me.manopulvePressionImprecision_1.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionImprecision_1.TabIndex = 0
        Me.manopulvePressionImprecision_1.TabStop = False
        '
        'Panel46
        '
        Me.Panel46.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel46.Controls.Add(Me.Label224)
        Me.Panel46.Location = New System.Drawing.Point(436, 0)
        Me.Panel46.Name = "Panel46"
        Me.Panel46.Size = New System.Drawing.Size(146, 40)
        Me.Panel46.TabIndex = 21
        '
        'Label224
        '
        Me.Label224.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label224.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label224.Location = New System.Drawing.Point(8, 16)
        Me.Label224.Name = "Label224"
        Me.Label224.Size = New System.Drawing.Size(128, 16)
        Me.Label224.TabIndex = 9
        Me.Label224.Text = "Imprécision"
        Me.Label224.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'manopulvePression_panel_manoAgent
        '
        Me.manopulvePression_panel_manoAgent.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.manopulvePression_panel_manoAgent.Controls.Add(Me.manopulvePressionControle_2)
        Me.manopulvePression_panel_manoAgent.Controls.Add(Me.manopulvePressionControle_3)
        Me.manopulvePression_panel_manoAgent.Controls.Add(Me.manopulvePressionControle_4)
        Me.manopulvePression_panel_manoAgent.Controls.Add(Me.manopulvePressionLue_6)
        Me.manopulvePression_panel_manoAgent.Controls.Add(Me.manopulvePressionLue_8)
        Me.manopulvePression_panel_manoAgent.Controls.Add(Me.manopulvePressionLue_7)
        Me.manopulvePression_panel_manoAgent.Controls.Add(Me.manopulvePressionControle_1)
        Me.manopulvePression_panel_manoAgent.Controls.Add(Me.manopulvePressionLue_5)
        Me.manopulvePression_panel_manoAgent.Location = New System.Drawing.Point(145, 41)
        Me.manopulvePression_panel_manoAgent.Name = "manopulvePression_panel_manoAgent"
        Me.manopulvePression_panel_manoAgent.Size = New System.Drawing.Size(143, 111)
        Me.manopulvePression_panel_manoAgent.TabIndex = 1
        '
        'manopulvePressionLue_5
        '
        Me.manopulvePressionLue_5.ForceBindingOnTextChanged = False
        Me.manopulvePressionLue_5.Location = New System.Drawing.Point(16, 8)
        Me.manopulvePressionLue_5.Name = "manopulvePressionLue_5"
        Me.manopulvePressionLue_5.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionLue_5.TabIndex = 11
        Me.manopulvePressionLue_5.Visible = False
        '
        'manopulvePressionControle_1
        '
        Me.manopulvePressionControle_1.ForceBindingOnTextChanged = False
        Me.manopulvePressionControle_1.Location = New System.Drawing.Point(16, 8)
        Me.manopulvePressionControle_1.Name = "manopulvePressionControle_1"
        Me.manopulvePressionControle_1.ReadOnly = True
        Me.manopulvePressionControle_1.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionControle_1.TabIndex = 0
        '
        'manopulvePressionLue_7
        '
        Me.manopulvePressionLue_7.ForceBindingOnTextChanged = False
        Me.manopulvePressionLue_7.Location = New System.Drawing.Point(16, 56)
        Me.manopulvePressionLue_7.Name = "manopulvePressionLue_7"
        Me.manopulvePressionLue_7.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionLue_7.TabIndex = 9
        Me.manopulvePressionLue_7.Visible = False
        '
        'manopulvePressionLue_8
        '
        Me.manopulvePressionLue_8.ForceBindingOnTextChanged = False
        Me.manopulvePressionLue_8.Location = New System.Drawing.Point(16, 80)
        Me.manopulvePressionLue_8.Name = "manopulvePressionLue_8"
        Me.manopulvePressionLue_8.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionLue_8.TabIndex = 10
        Me.manopulvePressionLue_8.Visible = False
        '
        'manopulvePressionLue_6
        '
        Me.manopulvePressionLue_6.ForceBindingOnTextChanged = False
        Me.manopulvePressionLue_6.Location = New System.Drawing.Point(16, 32)
        Me.manopulvePressionLue_6.Name = "manopulvePressionLue_6"
        Me.manopulvePressionLue_6.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionLue_6.TabIndex = 12
        Me.manopulvePressionLue_6.Visible = False
        '
        'manopulvePressionControle_4
        '
        Me.manopulvePressionControle_4.ForceBindingOnTextChanged = False
        Me.manopulvePressionControle_4.Location = New System.Drawing.Point(16, 80)
        Me.manopulvePressionControle_4.Name = "manopulvePressionControle_4"
        Me.manopulvePressionControle_4.ReadOnly = True
        Me.manopulvePressionControle_4.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionControle_4.TabIndex = 4
        '
        'manopulvePressionControle_3
        '
        Me.manopulvePressionControle_3.ForceBindingOnTextChanged = False
        Me.manopulvePressionControle_3.Location = New System.Drawing.Point(16, 56)
        Me.manopulvePressionControle_3.Name = "manopulvePressionControle_3"
        Me.manopulvePressionControle_3.ReadOnly = True
        Me.manopulvePressionControle_3.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionControle_3.TabIndex = 3
        '
        'manopulvePressionControle_2
        '
        Me.manopulvePressionControle_2.ForceBindingOnTextChanged = False
        Me.manopulvePressionControle_2.Location = New System.Drawing.Point(16, 32)
        Me.manopulvePressionControle_2.Name = "manopulvePressionControle_2"
        Me.manopulvePressionControle_2.ReadOnly = True
        Me.manopulvePressionControle_2.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionControle_2.TabIndex = 1
        '
        'manopulvePression_panel_manoPulve
        '
        Me.manopulvePression_panel_manoPulve.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.manopulvePression_panel_manoPulve.Controls.Add(Me.manopulvePressionPulve_3)
        Me.manopulvePression_panel_manoPulve.Controls.Add(Me.manopulvePressionPulve_4)
        Me.manopulvePression_panel_manoPulve.Controls.Add(Me.manopulvePressionPulve_2)
        Me.manopulvePression_panel_manoPulve.Controls.Add(Me.manopulvePressionPulve_1)
        Me.manopulvePression_panel_manoPulve.Location = New System.Drawing.Point(0, 41)
        Me.manopulvePression_panel_manoPulve.Name = "manopulvePression_panel_manoPulve"
        Me.manopulvePression_panel_manoPulve.Size = New System.Drawing.Size(144, 111)
        Me.manopulvePression_panel_manoPulve.TabIndex = 0
        '
        'manopulvePressionPulve_1
        '
        Me.manopulvePressionPulve_1.ForceBindingOnTextChanged = False
        Me.manopulvePressionPulve_1.Location = New System.Drawing.Point(16, 8)
        Me.manopulvePressionPulve_1.Name = "manopulvePressionPulve_1"
        Me.manopulvePressionPulve_1.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionPulve_1.TabIndex = 0
        '
        'manopulvePressionPulve_2
        '
        Me.manopulvePressionPulve_2.ForceBindingOnTextChanged = False
        Me.manopulvePressionPulve_2.Location = New System.Drawing.Point(16, 32)
        Me.manopulvePressionPulve_2.Name = "manopulvePressionPulve_2"
        Me.manopulvePressionPulve_2.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionPulve_2.TabIndex = 1
        '
        'manopulvePressionPulve_4
        '
        Me.manopulvePressionPulve_4.ForceBindingOnTextChanged = False
        Me.manopulvePressionPulve_4.Location = New System.Drawing.Point(16, 80)
        Me.manopulvePressionPulve_4.Name = "manopulvePressionPulve_4"
        Me.manopulvePressionPulve_4.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionPulve_4.TabIndex = 3
        '
        'manopulvePressionPulve_3
        '
        Me.manopulvePressionPulve_3.ForceBindingOnTextChanged = False
        Me.manopulvePressionPulve_3.Location = New System.Drawing.Point(16, 56)
        Me.manopulvePressionPulve_3.Name = "manopulvePressionPulve_3"
        Me.manopulvePressionPulve_3.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionPulve_3.TabIndex = 2
        '
        'manopulvePression_panel_erreur
        '
        Me.manopulvePression_panel_erreur.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.manopulvePression_panel_erreur.Controls.Add(Me.manopulvePressionEcart_1)
        Me.manopulvePression_panel_erreur.Controls.Add(Me.manopulvePressionEcart_2)
        Me.manopulvePression_panel_erreur.Controls.Add(Me.manopulvePressionEcart_3)
        Me.manopulvePression_panel_erreur.Controls.Add(Me.manopulvePressionEcart_4)
        Me.manopulvePression_panel_erreur.Location = New System.Drawing.Point(289, 41)
        Me.manopulvePression_panel_erreur.Name = "manopulvePression_panel_erreur"
        Me.manopulvePression_panel_erreur.Size = New System.Drawing.Size(146, 111)
        Me.manopulvePression_panel_erreur.TabIndex = 18
        '
        'manopulvePressionEcart_4
        '
        Me.manopulvePressionEcart_4.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionEcart_4.ForceBindingOnTextChanged = False
        Me.manopulvePressionEcart_4.Location = New System.Drawing.Point(16, 80)
        Me.manopulvePressionEcart_4.Name = "manopulvePressionEcart_4"
        Me.manopulvePressionEcart_4.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionEcart_4.TabIndex = 3
        Me.manopulvePressionEcart_4.TabStop = False
        '
        'manopulvePressionEcart_3
        '
        Me.manopulvePressionEcart_3.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionEcart_3.ForceBindingOnTextChanged = False
        Me.manopulvePressionEcart_3.Location = New System.Drawing.Point(16, 56)
        Me.manopulvePressionEcart_3.Name = "manopulvePressionEcart_3"
        Me.manopulvePressionEcart_3.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionEcart_3.TabIndex = 2
        Me.manopulvePressionEcart_3.TabStop = False
        '
        'manopulvePressionEcart_2
        '
        Me.manopulvePressionEcart_2.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionEcart_2.ForceBindingOnTextChanged = False
        Me.manopulvePressionEcart_2.Location = New System.Drawing.Point(16, 32)
        Me.manopulvePressionEcart_2.Name = "manopulvePressionEcart_2"
        Me.manopulvePressionEcart_2.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionEcart_2.TabIndex = 1
        Me.manopulvePressionEcart_2.TabStop = False
        '
        'manopulvePressionEcart_1
        '
        Me.manopulvePressionEcart_1.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionEcart_1.ForceBindingOnTextChanged = False
        Me.manopulvePressionEcart_1.Location = New System.Drawing.Point(16, 8)
        Me.manopulvePressionEcart_1.Name = "manopulvePressionEcart_1"
        Me.manopulvePressionEcart_1.Size = New System.Drawing.Size(112, 20)
        Me.manopulvePressionEcart_1.TabIndex = 0
        Me.manopulvePressionEcart_1.TabStop = False
        '
        'Panel52
        '
        Me.Panel52.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel52.Controls.Add(Me.Label66)
        Me.Panel52.Location = New System.Drawing.Point(0, 0)
        Me.Panel52.Name = "Panel52"
        Me.Panel52.Size = New System.Drawing.Size(144, 40)
        Me.Panel52.TabIndex = 19
        '
        'Label66
        '
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label66.Location = New System.Drawing.Point(8, 16)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(128, 16)
        Me.Label66.TabIndex = 6
        Me.Label66.Text = "Mano pulvé (bar)"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel53
        '
        Me.Panel53.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel53.Controls.Add(Me.Label69)
        Me.Panel53.Location = New System.Drawing.Point(145, 0)
        Me.Panel53.Name = "Panel53"
        Me.Panel53.Size = New System.Drawing.Size(143, 40)
        Me.Panel53.TabIndex = 20
        '
        'Label69
        '
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label69.Location = New System.Drawing.Point(8, 16)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(128, 16)
        Me.Label69.TabIndex = 8
        Me.Label69.Text = "Mano contrôle (bar)"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel54
        '
        Me.Panel54.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel54.Controls.Add(Me.Label70)
        Me.Panel54.Location = New System.Drawing.Point(289, 0)
        Me.Panel54.Name = "Panel54"
        Me.Panel54.Size = New System.Drawing.Size(146, 40)
        Me.Panel54.TabIndex = 21
        '
        'Label70
        '
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label70.Location = New System.Drawing.Point(8, 16)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(128, 16)
        Me.Label70.TabIndex = 9
        Me.Label70.Text = "Ecart"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_diagnostic_542
        '
        Me.Lbl_diagnostic_542.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_diagnostic_542.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Lbl_diagnostic_542.Image = CType(resources.GetObject("Lbl_diagnostic_542.Image"), System.Drawing.Image)
        Me.Lbl_diagnostic_542.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lbl_diagnostic_542.Location = New System.Drawing.Point(8, 8)
        Me.Lbl_diagnostic_542.Name = "Lbl_diagnostic_542"
        Me.Lbl_diagnostic_542.Size = New System.Drawing.Size(472, 25)
        Me.Lbl_diagnostic_542.TabIndex = 4
        Me.Lbl_diagnostic_542.Text = "     Contrôle du manomètre pulvérisateur (5.4.2)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.manoPulveEcartMax)
        Me.GroupBox3.Controls.Add(Me.manoPulveEcartMoyen)
        Me.GroupBox3.Controls.Add(Me.manopulveResultat)
        Me.GroupBox3.Controls.Add(Me.Label226)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(664, 72)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(304, 128)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Résultats"
        '
        'Label226
        '
        Me.Label226.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label226.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label226.Location = New System.Drawing.Point(32, 87)
        Me.Label226.Name = "Label226"
        Me.Label226.Size = New System.Drawing.Size(85, 16)
        Me.Label226.TabIndex = 6
        Me.Label226.Text = "Résultat :"
        Me.Label226.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'manopulveResultat
        '
        Me.manopulveResultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.manopulveResultat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.manopulveResultat.Location = New System.Drawing.Point(125, 88)
        Me.manopulveResultat.Name = "manopulveResultat"
        Me.manopulveResultat.Size = New System.Drawing.Size(144, 16)
        Me.manopulveResultat.TabIndex = 29
        Me.manopulveResultat.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'manoPulveEcartMoyen
        '
        Me.manoPulveEcartMoyen.ForceBindingOnTextChanged = False
        Me.manoPulveEcartMoyen.Location = New System.Drawing.Point(128, 24)
        Me.manoPulveEcartMoyen.Name = "manoPulveEcartMoyen"
        Me.manoPulveEcartMoyen.ReadOnly = True
        Me.manoPulveEcartMoyen.Size = New System.Drawing.Size(88, 20)
        Me.manoPulveEcartMoyen.TabIndex = 1
        '
        'manoPulveEcartMax
        '
        Me.manoPulveEcartMax.ForceBindingOnTextChanged = False
        Me.manoPulveEcartMax.Location = New System.Drawing.Point(128, 56)
        Me.manoPulveEcartMax.Name = "manoPulveEcartMax"
        Me.manoPulveEcartMax.ReadOnly = True
        Me.manoPulveEcartMax.Size = New System.Drawing.Size(88, 20)
        Me.manoPulveEcartMax.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(29, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Ecart maxi :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(29, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ecart moyen :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'manopulveIsFaiblePression
        '
        Me.manopulveIsFaiblePression.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.manopulveIsFaiblePression.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.manopulveIsFaiblePression.Location = New System.Drawing.Point(40, 48)
        Me.manopulveIsFaiblePression.Name = "manopulveIsFaiblePression"
        Me.manopulveIsFaiblePression.Size = New System.Drawing.Size(120, 16)
        Me.manopulveIsFaiblePression.TabIndex = 2
        Me.manopulveIsFaiblePression.Text = "Faible pression"
        '
        'manopulveIsUseCalibrateur
        '
        Me.manopulveIsUseCalibrateur.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.manopulveIsUseCalibrateur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.manopulveIsUseCalibrateur.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.manopulveIsUseCalibrateur.Location = New System.Drawing.Point(520, 16)
        Me.manopulveIsUseCalibrateur.Name = "manopulveIsUseCalibrateur"
        Me.manopulveIsUseCalibrateur.Size = New System.Drawing.Size(184, 17)
        Me.manopulveIsUseCalibrateur.TabIndex = 0
        Me.manopulveIsUseCalibrateur.Text = "Utilisation du calibrateur"
        '
        'btnRecalculer
        '
        Me.btnRecalculer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecalculer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecalculer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecalculer.ForeColor = System.Drawing.Color.White
        Me.btnRecalculer.Image = CType(resources.GetObject("btnRecalculer.Image"), System.Drawing.Image)
        Me.btnRecalculer.Location = New System.Drawing.Point(773, 203)
        Me.btnRecalculer.Name = "btnRecalculer"
        Me.btnRecalculer.Size = New System.Drawing.Size(128, 24)
        Me.btnRecalculer.TabIndex = 33
        Me.btnRecalculer.Text = "    ReCalculer"
        Me.btnRecalculer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnl_833
        '
        Me.pnl_833.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_833.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.pnl_833.Controls.Add(Me.rbPression4)
        Me.pnl_833.Controls.Add(Me.rbPression3)
        Me.pnl_833.Controls.Add(Me.rbPression2)
        Me.pnl_833.Controls.Add(Me.rbPression1)
        Me.pnl_833.Controls.Add(Me.Label111)
        Me.pnl_833.Controls.Add(Me.lblp833DefautEcart)
        Me.pnl_833.Controls.Add(Me.lblP833DefautHeterogeneite)
        Me.pnl_833.Controls.Add(Me.Label6)
        Me.pnl_833.Controls.Add(Me.nupTroncons)
        Me.pnl_833.Controls.Add(Me.Label54)
        Me.pnl_833.Controls.Add(Me.nup_niveaux)
        Me.pnl_833.Controls.Add(Me.Label53)
        Me.pnl_833.Controls.Add(Me.Lbl_diagnostic_833)
        Me.pnl_833.Controls.Add(Me.Label221)
        Me.pnl_833.Controls.Add(Me.tab_833)
        Me.pnl_833.Location = New System.Drawing.Point(0, 345)
        Me.pnl_833.Name = "pnl_833"
        Me.pnl_833.Size = New System.Drawing.Size(1004, 308)
        Me.pnl_833.TabIndex = 0
        '
        'tab_833
        '
        Me.tab_833.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_833.Controls.Add(Me.TabPage1)
        Me.tab_833.Controls.Add(Me.TabPage2)
        Me.tab_833.Controls.Add(Me.TabPage8)
        Me.tab_833.Controls.Add(Me.TabPage9)
        Me.tab_833.ImageList = Me.ImageList_onglets
        Me.tab_833.Location = New System.Drawing.Point(8, 50)
        Me.tab_833.Name = "tab_833"
        Me.tab_833.SelectedIndex = 0
        Me.tab_833.Size = New System.Drawing.Size(984, 247)
        Me.tab_833.TabIndex = 2
        '
        'TabPage9
        '
        Me.TabPage9.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage9.Controls.Add(Me.GroupBox9)
        Me.TabPage9.Controls.Add(Me.Label113)
        Me.TabPage9.Controls.Add(Me.Label90)
        Me.TabPage9.Controls.Add(Me.Label103)
        Me.TabPage9.Controls.Add(Me.pressionTronc_DefautEcart4)
        Me.TabPage9.Controls.Add(Me.Label106)
        Me.TabPage9.Controls.Add(Me.gdvPressions4)
        Me.TabPage9.Controls.Add(Me.pressionTronc_heterogeniteAlimentation4)
        Me.TabPage9.Controls.Add(Me.tbMoyenne4)
        Me.TabPage9.Controls.Add(Me.pressionTronc_20_pressionManoPulve)
        Me.TabPage9.Location = New System.Drawing.Point(4, 23)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(976, 220)
        Me.TabPage9.TabIndex = 5
        Me.TabPage9.Text = "20 bar"
        '
        'pressionTronc_20_pressionManoPulve
        '
        Me.pressionTronc_20_pressionManoPulve.Enabled = False
        Me.pressionTronc_20_pressionManoPulve.ForceBindingOnTextChanged = False
        Me.pressionTronc_20_pressionManoPulve.Location = New System.Drawing.Point(143, 6)
        Me.pressionTronc_20_pressionManoPulve.Name = "pressionTronc_20_pressionManoPulve"
        Me.pressionTronc_20_pressionManoPulve.Size = New System.Drawing.Size(48, 20)
        Me.pressionTronc_20_pressionManoPulve.TabIndex = 34
        Me.pressionTronc_20_pressionManoPulve.TabStop = False
        Me.pressionTronc_20_pressionManoPulve.Text = "20"
        '
        'tbMoyenne4
        '
        Me.tbMoyenne4.Enabled = False
        Me.tbMoyenne4.ForceBindingOnTextChanged = False
        Me.tbMoyenne4.Location = New System.Drawing.Point(274, 6)
        Me.tbMoyenne4.Name = "tbMoyenne4"
        Me.tbMoyenne4.Size = New System.Drawing.Size(59, 20)
        Me.tbMoyenne4.TabIndex = 45
        Me.tbMoyenne4.TabStop = False
        '
        'pressionTronc_heterogeniteAlimentation4
        '
        Me.pressionTronc_heterogeniteAlimentation4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pressionTronc_heterogeniteAlimentation4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pressionTronc_heterogeniteAlimentation4.Location = New System.Drawing.Point(874, 8)
        Me.pressionTronc_heterogeniteAlimentation4.Name = "pressionTronc_heterogeniteAlimentation4"
        Me.pressionTronc_heterogeniteAlimentation4.Size = New System.Drawing.Size(82, 16)
        Me.pressionTronc_heterogeniteAlimentation4.TabIndex = 36
        Me.pressionTronc_heterogeniteAlimentation4.Text = "OK"
        Me.pressionTronc_heterogeniteAlimentation4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'gdvPressions4
        '
        Me.gdvPressions4.AllowUserToAddRows = False
        Me.gdvPressions4.AllowUserToDeleteRows = False
        Me.gdvPressions4.AllowUserToResizeRows = False
        Me.gdvPressions4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gdvPressions4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gdvPressions4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvPressions4.ColumnHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvPressions4.DefaultCellStyle = DataGridViewCellStyle4
        Me.gdvPressions4.Location = New System.Drawing.Point(4, 37)
        Me.gdvPressions4.Name = "gdvPressions4"
        Me.gdvPressions4.RowHeadersVisible = False
        Me.gdvPressions4.Size = New System.Drawing.Size(967, 168)
        Me.gdvPressions4.TabIndex = 0
        '
        'Label106
        '
        Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label106.Location = New System.Drawing.Point(7, 8)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(128, 16)
        Me.Label106.TabIndex = 33
        Me.Label106.Text = "Pression Mano Pulvé :"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pressionTronc_DefautEcart4
        '
        Me.pressionTronc_DefautEcart4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pressionTronc_DefautEcart4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pressionTronc_DefautEcart4.Location = New System.Drawing.Point(687, 8)
        Me.pressionTronc_DefautEcart4.Name = "pressionTronc_DefautEcart4"
        Me.pressionTronc_DefautEcart4.Size = New System.Drawing.Size(82, 16)
        Me.pressionTronc_DefautEcart4.TabIndex = 37
        Me.pressionTronc_DefautEcart4.Text = "OK"
        Me.pressionTronc_DefautEcart4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label103
        '
        Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label103.Location = New System.Drawing.Point(758, 9)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(120, 16)
        Me.Label103.TabIndex = 38
        Me.Label103.Text = "Hétérogénité  :"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label90
        '
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label90.Location = New System.Drawing.Point(571, 7)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(120, 19)
        Me.Label90.TabIndex = 39
        Me.Label90.Text = "Ecart de pression  :"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label113
        '
        Me.Label113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label113.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label113.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label113.Location = New System.Drawing.Point(197, 8)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(71, 16)
        Me.Label113.TabIndex = 46
        Me.Label113.Text = "Moyenne :"
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.tbMoyEcartbar4)
        Me.GroupBox9.Controls.Add(Me.Label108)
        Me.GroupBox9.Controls.Add(Me.tbMoyEcartPct4)
        Me.GroupBox9.Controls.Add(Me.Label110)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox9.Location = New System.Drawing.Point(339, 0)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(223, 35)
        Me.GroupBox9.TabIndex = 48
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Ecart"
        '
        'Label110
        '
        Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label110.Location = New System.Drawing.Point(194, 10)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(11, 16)
        Me.Label110.TabIndex = 36
        Me.Label110.Text = "%"
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbMoyEcartPct4
        '
        Me.tbMoyEcartPct4.BackColor = System.Drawing.SystemColors.Window
        Me.tbMoyEcartPct4.ForceBindingOnTextChanged = False
        Me.tbMoyEcartPct4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbMoyEcartPct4.Location = New System.Drawing.Point(139, 8)
        Me.tbMoyEcartPct4.Name = "tbMoyEcartPct4"
        Me.tbMoyEcartPct4.ReadOnly = True
        Me.tbMoyEcartPct4.Size = New System.Drawing.Size(49, 20)
        Me.tbMoyEcartPct4.TabIndex = 35
        Me.tbMoyEcartPct4.TabStop = False
        Me.tbMoyEcartPct4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label108
        '
        Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label108.Location = New System.Drawing.Point(102, 12)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(31, 14)
        Me.Label108.TabIndex = 37
        Me.Label108.Text = "bars"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbMoyEcartbar4
        '
        Me.tbMoyEcartbar4.Enabled = False
        Me.tbMoyEcartbar4.ForceBindingOnTextChanged = False
        Me.tbMoyEcartbar4.Location = New System.Drawing.Point(47, 8)
        Me.tbMoyEcartbar4.Name = "tbMoyEcartbar4"
        Me.tbMoyEcartbar4.Size = New System.Drawing.Size(49, 20)
        Me.tbMoyEcartbar4.TabIndex = 32
        Me.tbMoyEcartbar4.TabStop = False
        Me.tbMoyEcartbar4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage8.Controls.Add(Me.GroupBox8)
        Me.TabPage8.Controls.Add(Me.Label109)
        Me.TabPage8.Controls.Add(Me.Label71)
        Me.TabPage8.Controls.Add(Me.Label73)
        Me.TabPage8.Controls.Add(Me.pressionTronc_DefautEcart3)
        Me.TabPage8.Controls.Add(Me.Label88)
        Me.TabPage8.Controls.Add(Me.gdvPressions3)
        Me.TabPage8.Controls.Add(Me.pressionTronc_heterogeniteAlimentation3)
        Me.TabPage8.Controls.Add(Me.tbMoyenne3)
        Me.TabPage8.Controls.Add(Me.pressionTronc_15_pressionManoPulve)
        Me.TabPage8.Location = New System.Drawing.Point(4, 23)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(976, 220)
        Me.TabPage8.TabIndex = 4
        Me.TabPage8.Text = "15 bar"
        '
        'pressionTronc_15_pressionManoPulve
        '
        Me.pressionTronc_15_pressionManoPulve.Enabled = False
        Me.pressionTronc_15_pressionManoPulve.ForceBindingOnTextChanged = False
        Me.pressionTronc_15_pressionManoPulve.Location = New System.Drawing.Point(143, 6)
        Me.pressionTronc_15_pressionManoPulve.Name = "pressionTronc_15_pressionManoPulve"
        Me.pressionTronc_15_pressionManoPulve.Size = New System.Drawing.Size(48, 20)
        Me.pressionTronc_15_pressionManoPulve.TabIndex = 34
        Me.pressionTronc_15_pressionManoPulve.TabStop = False
        Me.pressionTronc_15_pressionManoPulve.Text = "15"
        '
        'tbMoyenne3
        '
        Me.tbMoyenne3.Enabled = False
        Me.tbMoyenne3.ForceBindingOnTextChanged = False
        Me.tbMoyenne3.Location = New System.Drawing.Point(261, 6)
        Me.tbMoyenne3.Name = "tbMoyenne3"
        Me.tbMoyenne3.Size = New System.Drawing.Size(72, 20)
        Me.tbMoyenne3.TabIndex = 45
        Me.tbMoyenne3.TabStop = False
        '
        'pressionTronc_heterogeniteAlimentation3
        '
        Me.pressionTronc_heterogeniteAlimentation3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pressionTronc_heterogeniteAlimentation3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pressionTronc_heterogeniteAlimentation3.Location = New System.Drawing.Point(874, 8)
        Me.pressionTronc_heterogeniteAlimentation3.Name = "pressionTronc_heterogeniteAlimentation3"
        Me.pressionTronc_heterogeniteAlimentation3.Size = New System.Drawing.Size(82, 16)
        Me.pressionTronc_heterogeniteAlimentation3.TabIndex = 36
        Me.pressionTronc_heterogeniteAlimentation3.Text = "OK"
        Me.pressionTronc_heterogeniteAlimentation3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'gdvPressions3
        '
        Me.gdvPressions3.AllowUserToAddRows = False
        Me.gdvPressions3.AllowUserToDeleteRows = False
        Me.gdvPressions3.AllowUserToResizeRows = False
        Me.gdvPressions3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gdvPressions3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gdvPressions3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvPressions3.ColumnHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvPressions3.DefaultCellStyle = DataGridViewCellStyle3
        Me.gdvPressions3.Location = New System.Drawing.Point(4, 37)
        Me.gdvPressions3.Name = "gdvPressions3"
        Me.gdvPressions3.RowHeadersVisible = False
        Me.gdvPressions3.Size = New System.Drawing.Size(967, 168)
        Me.gdvPressions3.TabIndex = 0
        '
        'Label88
        '
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label88.Location = New System.Drawing.Point(7, 8)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(128, 16)
        Me.Label88.TabIndex = 33
        Me.Label88.Text = "Pression Mano Pulvé :"
        Me.Label88.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pressionTronc_DefautEcart3
        '
        Me.pressionTronc_DefautEcart3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pressionTronc_DefautEcart3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pressionTronc_DefautEcart3.Location = New System.Drawing.Point(687, 8)
        Me.pressionTronc_DefautEcart3.Name = "pressionTronc_DefautEcart3"
        Me.pressionTronc_DefautEcart3.Size = New System.Drawing.Size(82, 16)
        Me.pressionTronc_DefautEcart3.TabIndex = 37
        Me.pressionTronc_DefautEcart3.Text = "OK"
        Me.pressionTronc_DefautEcart3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label73
        '
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label73.Location = New System.Drawing.Point(758, 9)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(120, 16)
        Me.Label73.TabIndex = 38
        Me.Label73.Text = "Hétérogénité  :"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label71.Location = New System.Drawing.Point(571, 7)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(120, 19)
        Me.Label71.TabIndex = 39
        Me.Label71.Text = "Ecart de pression  :"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label109
        '
        Me.Label109.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label109.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label109.Location = New System.Drawing.Point(197, 8)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(63, 16)
        Me.Label109.TabIndex = 46
        Me.Label109.Text = "Moyenne :"
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.tbMoyEcartbar3)
        Me.GroupBox8.Controls.Add(Me.Label105)
        Me.GroupBox8.Controls.Add(Me.tbMoyEcartPct3)
        Me.GroupBox8.Controls.Add(Me.Label107)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox8.Location = New System.Drawing.Point(339, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(223, 35)
        Me.GroupBox8.TabIndex = 47
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Ecart"
        '
        'Label107
        '
        Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label107.Location = New System.Drawing.Point(194, 10)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(11, 16)
        Me.Label107.TabIndex = 36
        Me.Label107.Text = "%"
        Me.Label107.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbMoyEcartPct3
        '
        Me.tbMoyEcartPct3.BackColor = System.Drawing.SystemColors.Window
        Me.tbMoyEcartPct3.ForceBindingOnTextChanged = False
        Me.tbMoyEcartPct3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbMoyEcartPct3.Location = New System.Drawing.Point(139, 8)
        Me.tbMoyEcartPct3.Name = "tbMoyEcartPct3"
        Me.tbMoyEcartPct3.ReadOnly = True
        Me.tbMoyEcartPct3.Size = New System.Drawing.Size(49, 20)
        Me.tbMoyEcartPct3.TabIndex = 35
        Me.tbMoyEcartPct3.TabStop = False
        Me.tbMoyEcartPct3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label105
        '
        Me.Label105.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label105.Location = New System.Drawing.Point(102, 12)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(31, 14)
        Me.Label105.TabIndex = 37
        Me.Label105.Text = "bars"
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbMoyEcartbar3
        '
        Me.tbMoyEcartbar3.Enabled = False
        Me.tbMoyEcartbar3.ForceBindingOnTextChanged = False
        Me.tbMoyEcartbar3.Location = New System.Drawing.Point(47, 8)
        Me.tbMoyEcartbar3.Name = "tbMoyEcartbar3"
        Me.tbMoyEcartbar3.Size = New System.Drawing.Size(49, 20)
        Me.tbMoyEcartbar3.TabIndex = 32
        Me.tbMoyEcartbar3.TabStop = False
        Me.tbMoyEcartbar3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox7)
        Me.TabPage2.Controls.Add(Me.Label104)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.pressionTronc_DefautEcart2)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.gdvPressions2)
        Me.TabPage2.Controls.Add(Me.pressionTronc_heterogeniteAlimentation2)
        Me.TabPage2.Controls.Add(Me.tbMoyenne2)
        Me.TabPage2.Controls.Add(Me.pressionTronc_10_pressionManoPulve)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(976, 220)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "10 bar"
        '
        'pressionTronc_10_pressionManoPulve
        '
        Me.pressionTronc_10_pressionManoPulve.Enabled = False
        Me.pressionTronc_10_pressionManoPulve.ForceBindingOnTextChanged = False
        Me.pressionTronc_10_pressionManoPulve.Location = New System.Drawing.Point(143, 6)
        Me.pressionTronc_10_pressionManoPulve.Name = "pressionTronc_10_pressionManoPulve"
        Me.pressionTronc_10_pressionManoPulve.Size = New System.Drawing.Size(48, 20)
        Me.pressionTronc_10_pressionManoPulve.TabIndex = 34
        Me.pressionTronc_10_pressionManoPulve.TabStop = False
        Me.pressionTronc_10_pressionManoPulve.Text = "10"
        '
        'tbMoyenne2
        '
        Me.tbMoyenne2.Enabled = False
        Me.tbMoyenne2.ForceBindingOnTextChanged = False
        Me.tbMoyenne2.Location = New System.Drawing.Point(274, 6)
        Me.tbMoyenne2.Name = "tbMoyenne2"
        Me.tbMoyenne2.Size = New System.Drawing.Size(59, 20)
        Me.tbMoyenne2.TabIndex = 45
        Me.tbMoyenne2.TabStop = False
        '
        'pressionTronc_heterogeniteAlimentation2
        '
        Me.pressionTronc_heterogeniteAlimentation2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pressionTronc_heterogeniteAlimentation2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pressionTronc_heterogeniteAlimentation2.Location = New System.Drawing.Point(874, 8)
        Me.pressionTronc_heterogeniteAlimentation2.Name = "pressionTronc_heterogeniteAlimentation2"
        Me.pressionTronc_heterogeniteAlimentation2.Size = New System.Drawing.Size(82, 16)
        Me.pressionTronc_heterogeniteAlimentation2.TabIndex = 36
        Me.pressionTronc_heterogeniteAlimentation2.Text = "OK"
        Me.pressionTronc_heterogeniteAlimentation2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'gdvPressions2
        '
        Me.gdvPressions2.AllowUserToAddRows = False
        Me.gdvPressions2.AllowUserToDeleteRows = False
        Me.gdvPressions2.AllowUserToResizeRows = False
        Me.gdvPressions2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gdvPressions2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gdvPressions2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvPressions2.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvPressions2.DefaultCellStyle = DataGridViewCellStyle2
        Me.gdvPressions2.Location = New System.Drawing.Point(4, 37)
        Me.gdvPressions2.Name = "gdvPressions2"
        Me.gdvPressions2.RowHeadersVisible = False
        Me.gdvPressions2.Size = New System.Drawing.Size(967, 168)
        Me.gdvPressions2.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(7, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 16)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Pression Mano Pulvé :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pressionTronc_DefautEcart2
        '
        Me.pressionTronc_DefautEcart2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pressionTronc_DefautEcart2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pressionTronc_DefautEcart2.Location = New System.Drawing.Point(687, 8)
        Me.pressionTronc_DefautEcart2.Name = "pressionTronc_DefautEcart2"
        Me.pressionTronc_DefautEcart2.Size = New System.Drawing.Size(82, 16)
        Me.pressionTronc_DefautEcart2.TabIndex = 37
        Me.pressionTronc_DefautEcart2.Text = "OK"
        Me.pressionTronc_DefautEcart2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(758, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Hétérogénité  :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(571, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 19)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Ecart de pression  :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label104
        '
        Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label104.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label104.Location = New System.Drawing.Point(197, 8)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(71, 16)
        Me.Label104.TabIndex = 46
        Me.Label104.Text = "Moyenne :"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.tbMoyEcartbar2)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.tbMoyEcartPct2)
        Me.GroupBox7.Controls.Add(Me.Label118)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox7.Location = New System.Drawing.Point(339, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(223, 35)
        Me.GroupBox7.TabIndex = 47
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Ecart"
        '
        'Label118
        '
        Me.Label118.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label118.Location = New System.Drawing.Point(194, 10)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(11, 16)
        Me.Label118.TabIndex = 36
        Me.Label118.Text = "%"
        Me.Label118.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbMoyEcartPct2
        '
        Me.tbMoyEcartPct2.BackColor = System.Drawing.SystemColors.Window
        Me.tbMoyEcartPct2.ForceBindingOnTextChanged = False
        Me.tbMoyEcartPct2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbMoyEcartPct2.Location = New System.Drawing.Point(139, 8)
        Me.tbMoyEcartPct2.Name = "tbMoyEcartPct2"
        Me.tbMoyEcartPct2.ReadOnly = True
        Me.tbMoyEcartPct2.Size = New System.Drawing.Size(49, 20)
        Me.tbMoyEcartPct2.TabIndex = 35
        Me.tbMoyEcartPct2.TabStop = False
        Me.tbMoyEcartPct2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(102, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 14)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "bars"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbMoyEcartbar2
        '
        Me.tbMoyEcartbar2.Enabled = False
        Me.tbMoyEcartbar2.ForceBindingOnTextChanged = False
        Me.tbMoyEcartbar2.Location = New System.Drawing.Point(47, 8)
        Me.tbMoyEcartbar2.Name = "tbMoyEcartbar2"
        Me.tbMoyEcartbar2.Size = New System.Drawing.Size(49, 20)
        Me.tbMoyEcartbar2.TabIndex = 32
        Me.tbMoyEcartbar2.TabStop = False
        Me.tbMoyEcartbar2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.Label75)
        Me.TabPage1.Controls.Add(Me.tbMoyenne1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.pressionTronc_DefautEcart1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.pressionTronc_5_pressionManoPulve)
        Me.TabPage1.Controls.Add(Me.gdvPressions1)
        Me.TabPage1.Controls.Add(Me.pressionTronc_heterogeniteAlimentation1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(976, 220)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "5 bar"
        '
        'pressionTronc_heterogeniteAlimentation1
        '
        Me.pressionTronc_heterogeniteAlimentation1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pressionTronc_heterogeniteAlimentation1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pressionTronc_heterogeniteAlimentation1.Location = New System.Drawing.Point(874, 8)
        Me.pressionTronc_heterogeniteAlimentation1.Name = "pressionTronc_heterogeniteAlimentation1"
        Me.pressionTronc_heterogeniteAlimentation1.Size = New System.Drawing.Size(82, 16)
        Me.pressionTronc_heterogeniteAlimentation1.TabIndex = 29
        Me.pressionTronc_heterogeniteAlimentation1.Text = "OK"
        Me.pressionTronc_heterogeniteAlimentation1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'gdvPressions1
        '
        Me.gdvPressions1.AllowUserToAddRows = False
        Me.gdvPressions1.AllowUserToDeleteRows = False
        Me.gdvPressions1.AllowUserToResizeRows = False
        Me.gdvPressions1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gdvPressions1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gdvPressions1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gdvPressions1.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdvPressions1.DefaultCellStyle = DataGridViewCellStyle1
        Me.gdvPressions1.Location = New System.Drawing.Point(4, 38)
        Me.gdvPressions1.Name = "gdvPressions1"
        Me.gdvPressions1.RowHeadersVisible = False
        Me.gdvPressions1.Size = New System.Drawing.Size(967, 182)
        Me.gdvPressions1.TabIndex = 0
        '
        'pressionTronc_5_pressionManoPulve
        '
        Me.pressionTronc_5_pressionManoPulve.Enabled = False
        Me.pressionTronc_5_pressionManoPulve.ForceBindingOnTextChanged = False
        Me.pressionTronc_5_pressionManoPulve.Location = New System.Drawing.Point(143, 6)
        Me.pressionTronc_5_pressionManoPulve.Name = "pressionTronc_5_pressionManoPulve"
        Me.pressionTronc_5_pressionManoPulve.Size = New System.Drawing.Size(48, 20)
        Me.pressionTronc_5_pressionManoPulve.TabIndex = 10
        Me.pressionTronc_5_pressionManoPulve.TabStop = False
        Me.pressionTronc_5_pressionManoPulve.Text = "5"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(7, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Pression Mano Pulvé :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(758, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Hétérogénité  :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pressionTronc_DefautEcart1
        '
        Me.pressionTronc_DefautEcart1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pressionTronc_DefautEcart1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pressionTronc_DefautEcart1.Location = New System.Drawing.Point(687, 8)
        Me.pressionTronc_DefautEcart1.Name = "pressionTronc_DefautEcart1"
        Me.pressionTronc_DefautEcart1.Size = New System.Drawing.Size(82, 16)
        Me.pressionTronc_DefautEcart1.TabIndex = 30
        Me.pressionTronc_DefautEcart1.Text = "OK"
        Me.pressionTronc_DefautEcart1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(571, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 19)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Ecart de pression  :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbMoyenne1
        '
        Me.tbMoyenne1.Enabled = False
        Me.tbMoyenne1.ForceBindingOnTextChanged = False
        Me.tbMoyenne1.Location = New System.Drawing.Point(274, 6)
        Me.tbMoyenne1.Name = "tbMoyenne1"
        Me.tbMoyenne1.Size = New System.Drawing.Size(59, 20)
        Me.tbMoyenne1.TabIndex = 38
        Me.tbMoyenne1.TabStop = False
        '
        'Label75
        '
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label75.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label75.Location = New System.Drawing.Point(197, 8)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(71, 16)
        Me.Label75.TabIndex = 39
        Me.Label75.Text = "Moyenne :"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.tbMoyEcartbar1)
        Me.GroupBox6.Controls.Add(Me.Label72)
        Me.GroupBox6.Controls.Add(Me.tbMoyEcartPct1)
        Me.GroupBox6.Controls.Add(Me.Label55)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(339, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(223, 35)
        Me.GroupBox6.TabIndex = 40
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Ecart"
        '
        'Label55
        '
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label55.Location = New System.Drawing.Point(194, 10)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(11, 16)
        Me.Label55.TabIndex = 36
        Me.Label55.Text = "%"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbMoyEcartPct1
        '
        Me.tbMoyEcartPct1.BackColor = System.Drawing.SystemColors.Window
        Me.tbMoyEcartPct1.ForceBindingOnTextChanged = False
        Me.tbMoyEcartPct1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbMoyEcartPct1.Location = New System.Drawing.Point(139, 8)
        Me.tbMoyEcartPct1.Name = "tbMoyEcartPct1"
        Me.tbMoyEcartPct1.ReadOnly = True
        Me.tbMoyEcartPct1.Size = New System.Drawing.Size(49, 20)
        Me.tbMoyEcartPct1.TabIndex = 35
        Me.tbMoyEcartPct1.TabStop = False
        Me.tbMoyEcartPct1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label72.Location = New System.Drawing.Point(102, 12)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(31, 14)
        Me.Label72.TabIndex = 37
        Me.Label72.Text = "bars"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbMoyEcartbar1
        '
        Me.tbMoyEcartbar1.Enabled = False
        Me.tbMoyEcartbar1.ForceBindingOnTextChanged = False
        Me.tbMoyEcartbar1.Location = New System.Drawing.Point(47, 8)
        Me.tbMoyEcartbar1.Name = "tbMoyEcartbar1"
        Me.tbMoyEcartbar1.Size = New System.Drawing.Size(49, 20)
        Me.tbMoyEcartbar1.TabIndex = 32
        Me.tbMoyEcartbar1.TabStop = False
        Me.tbMoyEcartbar1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label221
        '
        Me.Label221.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label221.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label221.Location = New System.Drawing.Point(732, 32)
        Me.Label221.Name = "Label221"
        Me.Label221.Size = New System.Drawing.Size(176, 16)
        Me.Label221.TabIndex = 6
        Me.Label221.Text = "Hétérogénité d'alimentation :"
        Me.Label221.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Lbl_diagnostic_833
        '
        Me.Lbl_diagnostic_833.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_diagnostic_833.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Lbl_diagnostic_833.Image = CType(resources.GetObject("Lbl_diagnostic_833.Image"), System.Drawing.Image)
        Me.Lbl_diagnostic_833.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lbl_diagnostic_833.Location = New System.Drawing.Point(8, 8)
        Me.Lbl_diagnostic_833.Name = "Lbl_diagnostic_833"
        Me.Lbl_diagnostic_833.Size = New System.Drawing.Size(409, 25)
        Me.Lbl_diagnostic_833.TabIndex = 4
        Me.Lbl_diagnostic_833.Text = "     Pression aux sorties des tronçons (8.3.3)"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label53.Location = New System.Drawing.Point(407, 14)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(99, 13)
        Me.Label53.TabIndex = 179
        Me.Label53.Text = "Nombre de niveaux"
        '
        'nup_niveaux
        '
        Me.nup_niveaux.Location = New System.Drawing.Point(512, 12)
        Me.nup_niveaux.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nup_niveaux.Name = "nup_niveaux"
        Me.nup_niveaux.Size = New System.Drawing.Size(44, 20)
        Me.nup_niveaux.TabIndex = 0
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label54.Location = New System.Drawing.Point(564, 14)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(109, 13)
        Me.Label54.TabIndex = 181
        Me.Label54.Text = "Nombre de tronçons :"
        '
        'nupTroncons
        '
        Me.nupTroncons.Location = New System.Drawing.Point(680, 12)
        Me.nupTroncons.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.nupTroncons.Name = "nupTroncons"
        Me.nupTroncons.Size = New System.Drawing.Size(46, 20)
        Me.nupTroncons.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(733, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 16)
        Me.Label6.TabIndex = 189
        Me.Label6.Text = "Ecart de pression  :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblP833DefautHeterogeneite
        '
        Me.lblP833DefautHeterogeneite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblP833DefautHeterogeneite.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblP833DefautHeterogeneite.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblP833DefautHeterogeneite.Location = New System.Drawing.Point(909, 33)
        Me.lblP833DefautHeterogeneite.Name = "lblP833DefautHeterogeneite"
        Me.lblP833DefautHeterogeneite.Size = New System.Drawing.Size(82, 16)
        Me.lblP833DefautHeterogeneite.TabIndex = 190
        Me.lblP833DefautHeterogeneite.Text = "OK"
        Me.lblP833DefautHeterogeneite.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblp833DefautEcart
        '
        Me.lblp833DefautEcart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblp833DefautEcart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblp833DefautEcart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblp833DefautEcart.Location = New System.Drawing.Point(910, 17)
        Me.lblp833DefautEcart.Name = "lblp833DefautEcart"
        Me.lblp833DefautEcart.Size = New System.Drawing.Size(82, 16)
        Me.lblp833DefautEcart.TabIndex = 191
        Me.lblp833DefautEcart.Text = "OK"
        Me.lblp833DefautEcart.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label111.Location = New System.Drawing.Point(190, 34)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(98, 13)
        Me.Label111.TabIndex = 192
        Me.Label111.Text = "Pression par défaut"
        '
        'rbPression1
        '
        Me.rbPression1.AutoSize = True
        Me.rbPression1.Location = New System.Drawing.Point(40, 34)
        Me.rbPression1.Name = "rbPression1"
        Me.rbPression1.Size = New System.Drawing.Size(14, 13)
        Me.rbPression1.TabIndex = 193
        Me.rbPression1.TabStop = True
        Me.rbPression1.UseVisualStyleBackColor = True
        '
        'rbPression2
        '
        Me.rbPression2.AutoSize = True
        Me.rbPression2.Location = New System.Drawing.Point(91, 34)
        Me.rbPression2.Name = "rbPression2"
        Me.rbPression2.Size = New System.Drawing.Size(14, 13)
        Me.rbPression2.TabIndex = 194
        Me.rbPression2.TabStop = True
        Me.rbPression2.UseVisualStyleBackColor = True
        '
        'rbPression3
        '
        Me.rbPression3.AutoSize = True
        Me.rbPression3.Location = New System.Drawing.Point(133, 34)
        Me.rbPression3.Name = "rbPression3"
        Me.rbPression3.Size = New System.Drawing.Size(14, 13)
        Me.rbPression3.TabIndex = 195
        Me.rbPression3.TabStop = True
        Me.rbPression3.UseVisualStyleBackColor = True
        '
        'rbPression4
        '
        Me.rbPression4.AutoSize = True
        Me.rbPression4.Location = New System.Drawing.Point(177, 35)
        Me.rbPression4.Name = "rbPression4"
        Me.rbPression4.Size = New System.Drawing.Size(14, 13)
        Me.rbPression4.TabIndex = 196
        Me.rbPression4.TabStop = True
        Me.rbPression4.UseVisualStyleBackColor = True
        '
        'tabPage_diagnostique_rampes
        '
        Me.tabPage_diagnostique_rampes.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabPage_diagnostique_rampes.Controls.Add(Me.Panel128)
        Me.tabPage_diagnostique_rampes.Controls.Add(Me.Panel36)
        Me.tabPage_diagnostique_rampes.Controls.Add(Me.Panel34)
        Me.tabPage_diagnostique_rampes.ImageIndex = 3
        Me.tabPage_diagnostique_rampes.Location = New System.Drawing.Point(4, 23)
        Me.tabPage_diagnostique_rampes.Name = "tabPage_diagnostique_rampes"
        Me.tabPage_diagnostique_rampes.Size = New System.Drawing.Size(1008, 653)
        Me.tabPage_diagnostique_rampes.TabIndex = 4
        Me.tabPage_diagnostique_rampes.Tag = "6"
        Me.tabPage_diagnostique_rampes.Text = "Rampes"
        '
        'Panel34
        '
        Me.Panel34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel34.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel34.Controls.Add(Me.GroupBox_diagnostic_817)
        Me.Panel34.Controls.Add(Me.GroupBox_diagnostic_813)
        Me.Panel34.Controls.Add(Me.GroupBox_diagnostic_816)
        Me.Panel34.Controls.Add(Me.Panel35)
        Me.Panel34.Controls.Add(Me.GroupBox_diagnostic_812)
        Me.Panel34.Controls.Add(Me.GroupBox_diagnostic_811)
        Me.Panel34.Controls.Add(Me.GroupBox_diagnostic_814)
        Me.Panel34.Controls.Add(Me.GroupBox_diagnostic_815)
        Me.Panel34.Controls.Add(Me.Label_diagnostic_81)
        Me.Panel34.Location = New System.Drawing.Point(0, 143)
        Me.Panel34.Name = "Panel34"
        Me.Panel34.Size = New System.Drawing.Size(664, 510)
        Me.Panel34.TabIndex = 9
        '
        'Label_diagnostic_81
        '
        Me.Label_diagnostic_81.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_81.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_81.Image = CType(resources.GetObject("Label_diagnostic_81.Image"), System.Drawing.Image)
        Me.Label_diagnostic_81.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_81.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_81.Name = "Label_diagnostic_81"
        Me.Label_diagnostic_81.Size = New System.Drawing.Size(639, 16)
        Me.Label_diagnostic_81.TabIndex = 13
        Me.Label_diagnostic_81.Text = "     Structure de rampe"
        '
        'GroupBox_diagnostic_815
        '
        Me.GroupBox_diagnostic_815.Controls.Add(Me.RadioButton_diagnostic_8152)
        Me.GroupBox_diagnostic_815.Controls.Add(Me.RadioButton_diagnostic_8150)
        Me.GroupBox_diagnostic_815.Controls.Add(Me.RadioButton_diagnostic_8151)
        Me.GroupBox_diagnostic_815.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_815.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_815.Location = New System.Drawing.Point(11, 416)
        Me.GroupBox_diagnostic_815.Name = "GroupBox_diagnostic_815"
        Me.GroupBox_diagnostic_815.Size = New System.Drawing.Size(309, 80)
        Me.GroupBox_diagnostic_815.TabIndex = 7
        Me.GroupBox_diagnostic_815.TabStop = False
        Me.GroupBox_diagnostic_815.Text = "8.1.5 - Lésions aux soudures"
        '
        'RadioButton_diagnostic_8151
        '
        Me.RadioButton_diagnostic_8151.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8151.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8151.cause1 = False
        Me.RadioButton_diagnostic_8151.cause2 = False
        Me.RadioButton_diagnostic_8151.cause3 = False
        Me.RadioButton_diagnostic_8151.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8151.Checked = False
        Me.RadioButton_diagnostic_8151.Code = Nothing
        Me.RadioButton_diagnostic_8151.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8151.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8151.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8151.Libelle = "8.1.5.1 - Lésion mineure"
        Me.RadioButton_diagnostic_8151.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8151.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_8151.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8151.Name = "RadioButton_diagnostic_8151"
        Me.RadioButton_diagnostic_8151.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8151.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8151.TabIndex = 4
        '
        'RadioButton_diagnostic_8150
        '
        Me.RadioButton_diagnostic_8150.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8150.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8150.cause1 = False
        Me.RadioButton_diagnostic_8150.cause2 = False
        Me.RadioButton_diagnostic_8150.cause3 = False
        Me.RadioButton_diagnostic_8150.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8150.Checked = False
        Me.RadioButton_diagnostic_8150.Code = Nothing
        Me.RadioButton_diagnostic_8150.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8150.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8150.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8150.Libelle = "OK"
        Me.RadioButton_diagnostic_8150.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8150.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_8150.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8150.Name = "RadioButton_diagnostic_8150"
        Me.RadioButton_diagnostic_8150.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8150.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8150.TabIndex = 7
        '
        'RadioButton_diagnostic_8152
        '
        Me.RadioButton_diagnostic_8152.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8152.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8152.cause1 = False
        Me.RadioButton_diagnostic_8152.cause2 = False
        Me.RadioButton_diagnostic_8152.cause3 = False
        Me.RadioButton_diagnostic_8152.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8152.Checked = False
        Me.RadioButton_diagnostic_8152.Code = Nothing
        Me.RadioButton_diagnostic_8152.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8152.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8152.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8152.Libelle = "8.1.5.2 - Lésion majeure"
        Me.RadioButton_diagnostic_8152.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8152.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_8152.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8152.Name = "RadioButton_diagnostic_8152"
        Me.RadioButton_diagnostic_8152.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8152.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8152.TabIndex = 8
        '
        'GroupBox_diagnostic_814
        '
        Me.GroupBox_diagnostic_814.Controls.Add(Me.RadioButton_diagnostic_8142)
        Me.GroupBox_diagnostic_814.Controls.Add(Me.RadioButton_diagnostic_8140)
        Me.GroupBox_diagnostic_814.Controls.Add(Me.RadioButton_diagnostic_8141)
        Me.GroupBox_diagnostic_814.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_814.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_814.Location = New System.Drawing.Point(11, 329)
        Me.GroupBox_diagnostic_814.Name = "GroupBox_diagnostic_814"
        Me.GroupBox_diagnostic_814.Size = New System.Drawing.Size(309, 80)
        Me.GroupBox_diagnostic_814.TabIndex = 7
        Me.GroupBox_diagnostic_814.TabStop = False
        Me.GroupBox_diagnostic_814.Text = "8.1.4 - Déformations"
        '
        'RadioButton_diagnostic_8141
        '
        Me.RadioButton_diagnostic_8141.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8141.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8141.cause1 = False
        Me.RadioButton_diagnostic_8141.cause2 = False
        Me.RadioButton_diagnostic_8141.cause3 = False
        Me.RadioButton_diagnostic_8141.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8141.Checked = False
        Me.RadioButton_diagnostic_8141.Code = Nothing
        Me.RadioButton_diagnostic_8141.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8141.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8141.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8141.Libelle = "8.1.4.1 - Déformation faible"
        Me.RadioButton_diagnostic_8141.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8141.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_8141.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8141.Name = "RadioButton_diagnostic_8141"
        Me.RadioButton_diagnostic_8141.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8141.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8141.TabIndex = 4
        '
        'RadioButton_diagnostic_8140
        '
        Me.RadioButton_diagnostic_8140.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8140.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8140.cause1 = False
        Me.RadioButton_diagnostic_8140.cause2 = False
        Me.RadioButton_diagnostic_8140.cause3 = False
        Me.RadioButton_diagnostic_8140.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8140.Checked = False
        Me.RadioButton_diagnostic_8140.Code = Nothing
        Me.RadioButton_diagnostic_8140.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8140.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8140.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8140.Libelle = "OK"
        Me.RadioButton_diagnostic_8140.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8140.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_8140.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8140.Name = "RadioButton_diagnostic_8140"
        Me.RadioButton_diagnostic_8140.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8140.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8140.TabIndex = 7
        '
        'RadioButton_diagnostic_8142
        '
        Me.RadioButton_diagnostic_8142.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8142.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8142.cause1 = False
        Me.RadioButton_diagnostic_8142.cause2 = False
        Me.RadioButton_diagnostic_8142.cause3 = False
        Me.RadioButton_diagnostic_8142.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8142.Checked = False
        Me.RadioButton_diagnostic_8142.Code = Nothing
        Me.RadioButton_diagnostic_8142.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8142.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8142.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8142.Libelle = "8.1.4.2 - Déformation importante"
        Me.RadioButton_diagnostic_8142.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8142.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_8142.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8142.Name = "RadioButton_diagnostic_8142"
        Me.RadioButton_diagnostic_8142.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8142.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8142.TabIndex = 8
        '
        'GroupBox_diagnostic_811
        '
        Me.GroupBox_diagnostic_811.Controls.Add(Me.ico_help_811)
        Me.GroupBox_diagnostic_811.Controls.Add(Me.RadioButton_diagnostic_8114)
        Me.GroupBox_diagnostic_811.Controls.Add(Me.RadioButton_diagnostic_8113)
        Me.GroupBox_diagnostic_811.Controls.Add(Me.RadioButton_diagnostic_8110)
        Me.GroupBox_diagnostic_811.Controls.Add(Me.RadioButton_diagnostic_8111)
        Me.GroupBox_diagnostic_811.Controls.Add(Me.RadioButton_diagnostic_8112)
        Me.GroupBox_diagnostic_811.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_811.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_811.Location = New System.Drawing.Point(11, 32)
        Me.GroupBox_diagnostic_811.Name = "GroupBox_diagnostic_811"
        Me.GroupBox_diagnostic_811.Size = New System.Drawing.Size(309, 100)
        Me.GroupBox_diagnostic_811.TabIndex = 5
        Me.GroupBox_diagnostic_811.TabStop = False
        Me.GroupBox_diagnostic_811.Text = "8.1.1 - Déformation sur un plan vertical"
        '
        'RadioButton_diagnostic_8112
        '
        Me.RadioButton_diagnostic_8112.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8112.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8112.cause1 = False
        Me.RadioButton_diagnostic_8112.cause2 = False
        Me.RadioButton_diagnostic_8112.cause3 = False
        Me.RadioButton_diagnostic_8112.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8112.Checked = False
        Me.RadioButton_diagnostic_8112.Code = Nothing
        Me.RadioButton_diagnostic_8112.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8112.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8112.Libelle = "8.1.1.2 - Courbure importante"
        Me.RadioButton_diagnostic_8112.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8112.Location = New System.Drawing.Point(10, 32)
        Me.RadioButton_diagnostic_8112.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8112.Name = "RadioButton_diagnostic_8112"
        Me.RadioButton_diagnostic_8112.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8112.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8112.TabIndex = 4
        '
        'RadioButton_diagnostic_8111
        '
        Me.RadioButton_diagnostic_8111.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8111.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8111.cause1 = False
        Me.RadioButton_diagnostic_8111.cause2 = False
        Me.RadioButton_diagnostic_8111.cause3 = False
        Me.RadioButton_diagnostic_8111.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8111.Checked = False
        Me.RadioButton_diagnostic_8111.Code = Nothing
        Me.RadioButton_diagnostic_8111.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8111.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8111.Libelle = "8.1.1.1 - Courbure faible"
        Me.RadioButton_diagnostic_8111.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8111.Location = New System.Drawing.Point(10, 16)
        Me.RadioButton_diagnostic_8111.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8111.Name = "RadioButton_diagnostic_8111"
        Me.RadioButton_diagnostic_8111.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8111.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8111.TabIndex = 5
        '
        'RadioButton_diagnostic_8110
        '
        Me.RadioButton_diagnostic_8110.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8110.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8110.cause1 = False
        Me.RadioButton_diagnostic_8110.cause2 = False
        Me.RadioButton_diagnostic_8110.cause3 = False
        Me.RadioButton_diagnostic_8110.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8110.Checked = False
        Me.RadioButton_diagnostic_8110.Code = Nothing
        Me.RadioButton_diagnostic_8110.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8110.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8110.Libelle = "OK"
        Me.RadioButton_diagnostic_8110.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8110.Location = New System.Drawing.Point(10, 80)
        Me.RadioButton_diagnostic_8110.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8110.Name = "RadioButton_diagnostic_8110"
        Me.RadioButton_diagnostic_8110.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8110.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8110.TabIndex = 7
        '
        'RadioButton_diagnostic_8113
        '
        Me.RadioButton_diagnostic_8113.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8113.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8113.cause1 = False
        Me.RadioButton_diagnostic_8113.cause2 = False
        Me.RadioButton_diagnostic_8113.cause3 = False
        Me.RadioButton_diagnostic_8113.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8113.Checked = False
        Me.RadioButton_diagnostic_8113.Code = Nothing
        Me.RadioButton_diagnostic_8113.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8113.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8113.Libelle = "8.1.1.3 - Défaut de parallelisme faible (>=12m)"
        Me.RadioButton_diagnostic_8113.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8113.Location = New System.Drawing.Point(10, 48)
        Me.RadioButton_diagnostic_8113.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8113.Name = "RadioButton_diagnostic_8113"
        Me.RadioButton_diagnostic_8113.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8113.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8113.TabIndex = 8
        '
        'RadioButton_diagnostic_8114
        '
        Me.RadioButton_diagnostic_8114.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8114.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8114.cause1 = False
        Me.RadioButton_diagnostic_8114.cause2 = False
        Me.RadioButton_diagnostic_8114.cause3 = False
        Me.RadioButton_diagnostic_8114.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8114.Checked = False
        Me.RadioButton_diagnostic_8114.Code = Nothing
        Me.RadioButton_diagnostic_8114.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8114.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8114.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8114.Libelle = "8.1.1.4 - Défaut de parallelisme important (>=12m)"
        Me.RadioButton_diagnostic_8114.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8114.Location = New System.Drawing.Point(10, 64)
        Me.RadioButton_diagnostic_8114.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8114.Name = "RadioButton_diagnostic_8114"
        Me.RadioButton_diagnostic_8114.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8114.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8114.TabIndex = 9
        '
        'ico_help_811
        '
        Me.ico_help_811.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ico_help_811.Image = CType(resources.GetObject("ico_help_811.Image"), System.Drawing.Image)
        Me.ico_help_811.Location = New System.Drawing.Point(258, 16)
        Me.ico_help_811.Name = "ico_help_811"
        Me.ico_help_811.Size = New System.Drawing.Size(20, 20)
        Me.ico_help_811.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ico_help_811.TabIndex = 19
        Me.ico_help_811.TabStop = False
        '
        'GroupBox_diagnostic_812
        '
        Me.GroupBox_diagnostic_812.Controls.Add(Me.RadioButton_diagnostic_8124)
        Me.GroupBox_diagnostic_812.Controls.Add(Me.RadioButton_diagnostic_8123)
        Me.GroupBox_diagnostic_812.Controls.Add(Me.RadioButton_diagnostic_8122)
        Me.GroupBox_diagnostic_812.Controls.Add(Me.RadioButton_diagnostic_8120)
        Me.GroupBox_diagnostic_812.Controls.Add(Me.RadioButton_diagnostic_8121)
        Me.GroupBox_diagnostic_812.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_812.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_812.Location = New System.Drawing.Point(11, 131)
        Me.GroupBox_diagnostic_812.Name = "GroupBox_diagnostic_812"
        Me.GroupBox_diagnostic_812.Size = New System.Drawing.Size(309, 109)
        Me.GroupBox_diagnostic_812.TabIndex = 6
        Me.GroupBox_diagnostic_812.TabStop = False
        Me.GroupBox_diagnostic_812.Text = "8.1.2 - Déformation sur un plan horizontal"
        '
        'RadioButton_diagnostic_8121
        '
        Me.RadioButton_diagnostic_8121.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8121.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8121.cause1 = False
        Me.RadioButton_diagnostic_8121.cause2 = False
        Me.RadioButton_diagnostic_8121.cause3 = False
        Me.RadioButton_diagnostic_8121.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8121.Checked = False
        Me.RadioButton_diagnostic_8121.Code = Nothing
        Me.RadioButton_diagnostic_8121.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8121.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8121.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8121.Libelle = "8.1.2.1 - Ecart de position faible"
        Me.RadioButton_diagnostic_8121.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8121.Location = New System.Drawing.Point(8, 16)
        Me.RadioButton_diagnostic_8121.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8121.Name = "RadioButton_diagnostic_8121"
        Me.RadioButton_diagnostic_8121.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8121.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8121.TabIndex = 4
        '
        'RadioButton_diagnostic_8120
        '
        Me.RadioButton_diagnostic_8120.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8120.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8120.cause1 = False
        Me.RadioButton_diagnostic_8120.cause2 = False
        Me.RadioButton_diagnostic_8120.cause3 = False
        Me.RadioButton_diagnostic_8120.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8120.Checked = False
        Me.RadioButton_diagnostic_8120.Code = Nothing
        Me.RadioButton_diagnostic_8120.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8120.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8120.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8120.Libelle = "OK"
        Me.RadioButton_diagnostic_8120.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8120.Location = New System.Drawing.Point(8, 85)
        Me.RadioButton_diagnostic_8120.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8120.Name = "RadioButton_diagnostic_8120"
        Me.RadioButton_diagnostic_8120.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8120.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8120.TabIndex = 7
        '
        'RadioButton_diagnostic_8122
        '
        Me.RadioButton_diagnostic_8122.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8122.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8122.cause1 = False
        Me.RadioButton_diagnostic_8122.cause2 = False
        Me.RadioButton_diagnostic_8122.cause3 = False
        Me.RadioButton_diagnostic_8122.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8122.Checked = False
        Me.RadioButton_diagnostic_8122.Code = Nothing
        Me.RadioButton_diagnostic_8122.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8122.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8122.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8122.Libelle = "8.1.2.2 - Ecart de position important"
        Me.RadioButton_diagnostic_8122.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8122.Location = New System.Drawing.Point(8, 32)
        Me.RadioButton_diagnostic_8122.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8122.Name = "RadioButton_diagnostic_8122"
        Me.RadioButton_diagnostic_8122.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8122.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8122.TabIndex = 8
        '
        'RadioButton_diagnostic_8123
        '
        Me.RadioButton_diagnostic_8123.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8123.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8123.cause1 = False
        Me.RadioButton_diagnostic_8123.cause2 = False
        Me.RadioButton_diagnostic_8123.cause3 = False
        Me.RadioButton_diagnostic_8123.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8123.Checked = False
        Me.RadioButton_diagnostic_8123.Code = Nothing
        Me.RadioButton_diagnostic_8123.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8123.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8123.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8123.Libelle = "8.1.2.3 - Courbure faible"
        Me.RadioButton_diagnostic_8123.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8123.Location = New System.Drawing.Point(8, 46)
        Me.RadioButton_diagnostic_8123.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8123.Name = "RadioButton_diagnostic_8123"
        Me.RadioButton_diagnostic_8123.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8123.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8123.TabIndex = 9
        '
        'RadioButton_diagnostic_8124
        '
        Me.RadioButton_diagnostic_8124.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8124.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8124.cause1 = False
        Me.RadioButton_diagnostic_8124.cause2 = False
        Me.RadioButton_diagnostic_8124.cause3 = False
        Me.RadioButton_diagnostic_8124.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8124.Checked = False
        Me.RadioButton_diagnostic_8124.Code = Nothing
        Me.RadioButton_diagnostic_8124.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8124.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8124.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8124.Libelle = "8.1.2.4 - Courbure importante"
        Me.RadioButton_diagnostic_8124.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8124.Location = New System.Drawing.Point(8, 62)
        Me.RadioButton_diagnostic_8124.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8124.Name = "RadioButton_diagnostic_8124"
        Me.RadioButton_diagnostic_8124.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8124.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8124.TabIndex = 10
        '
        'Panel35
        '
        Me.Panel35.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel35.Controls.Add(Me.GroupBox_diagnostic_823)
        Me.Panel35.Controls.Add(Me.GroupBox_diagnostic_822)
        Me.Panel35.Controls.Add(Me.GroupBox_diagnostic_821)
        Me.Panel35.Controls.Add(Me.Label_diagnostic_82)
        Me.Panel35.Location = New System.Drawing.Point(324, 188)
        Me.Panel35.Name = "Panel35"
        Me.Panel35.Size = New System.Drawing.Size(335, 306)
        Me.Panel35.TabIndex = 10
        '
        'Label_diagnostic_82
        '
        Me.Label_diagnostic_82.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_82.Image = CType(resources.GetObject("Label_diagnostic_82.Image"), System.Drawing.Image)
        Me.Label_diagnostic_82.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_82.Location = New System.Drawing.Point(3, 7)
        Me.Label_diagnostic_82.Name = "Label_diagnostic_82"
        Me.Label_diagnostic_82.Size = New System.Drawing.Size(320, 16)
        Me.Label_diagnostic_82.TabIndex = 13
        Me.Label_diagnostic_82.Text = "     Comportement de la rampe"
        '
        'GroupBox_diagnostic_821
        '
        Me.GroupBox_diagnostic_821.Controls.Add(Me.RadioButton_diagnostic_8210)
        Me.GroupBox_diagnostic_821.Controls.Add(Me.RadioButton_diagnostic_8211)
        Me.GroupBox_diagnostic_821.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_821.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_821.Location = New System.Drawing.Point(9, 31)
        Me.GroupBox_diagnostic_821.Name = "GroupBox_diagnostic_821"
        Me.GroupBox_diagnostic_821.Size = New System.Drawing.Size(317, 58)
        Me.GroupBox_diagnostic_821.TabIndex = 5
        Me.GroupBox_diagnostic_821.TabStop = False
        Me.GroupBox_diagnostic_821.Text = "8.2.1 - Jeux aux articulations"
        '
        'RadioButton_diagnostic_8211
        '
        Me.RadioButton_diagnostic_8211.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8211.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8211.cause1 = False
        Me.RadioButton_diagnostic_8211.cause2 = False
        Me.RadioButton_diagnostic_8211.cause3 = False
        Me.RadioButton_diagnostic_8211.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8211.Checked = False
        Me.RadioButton_diagnostic_8211.Code = Nothing
        Me.RadioButton_diagnostic_8211.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8211.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8211.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8211.Libelle = "8.2.1.1 - Jeux importants"
        Me.RadioButton_diagnostic_8211.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8211.Location = New System.Drawing.Point(10, 18)
        Me.RadioButton_diagnostic_8211.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8211.Name = "RadioButton_diagnostic_8211"
        Me.RadioButton_diagnostic_8211.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8211.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8211.TabIndex = 5
        '
        'RadioButton_diagnostic_8210
        '
        Me.RadioButton_diagnostic_8210.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8210.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8210.cause1 = False
        Me.RadioButton_diagnostic_8210.cause2 = False
        Me.RadioButton_diagnostic_8210.cause3 = False
        Me.RadioButton_diagnostic_8210.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8210.Checked = False
        Me.RadioButton_diagnostic_8210.Code = Nothing
        Me.RadioButton_diagnostic_8210.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8210.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8210.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8210.Libelle = "OK"
        Me.RadioButton_diagnostic_8210.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8210.Location = New System.Drawing.Point(10, 34)
        Me.RadioButton_diagnostic_8210.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8210.Name = "RadioButton_diagnostic_8210"
        Me.RadioButton_diagnostic_8210.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8210.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8210.TabIndex = 7
        '
        'GroupBox_diagnostic_822
        '
        Me.GroupBox_diagnostic_822.Controls.Add(Me.RadioButton_diagnostic_8222)
        Me.GroupBox_diagnostic_822.Controls.Add(Me.RadioButton_diagnostic_8220)
        Me.GroupBox_diagnostic_822.Controls.Add(Me.RadioButton_diagnostic_8221)
        Me.GroupBox_diagnostic_822.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_822.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_822.Location = New System.Drawing.Point(9, 95)
        Me.GroupBox_diagnostic_822.Name = "GroupBox_diagnostic_822"
        Me.GroupBox_diagnostic_822.Size = New System.Drawing.Size(317, 72)
        Me.GroupBox_diagnostic_822.TabIndex = 6
        Me.GroupBox_diagnostic_822.TabStop = False
        Me.GroupBox_diagnostic_822.Text = "8.2.2 - Stabilité"
        '
        'RadioButton_diagnostic_8221
        '
        Me.RadioButton_diagnostic_8221.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8221.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8221.cause1 = False
        Me.RadioButton_diagnostic_8221.cause2 = False
        Me.RadioButton_diagnostic_8221.cause3 = False
        Me.RadioButton_diagnostic_8221.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8221.Checked = False
        Me.RadioButton_diagnostic_8221.Code = Nothing
        Me.RadioButton_diagnostic_8221.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8221.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8221.Libelle = "8.2.2.1 - Dispositif de stabilisation non fonctionnel"
        Me.RadioButton_diagnostic_8221.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8221.Location = New System.Drawing.Point(8, 18)
        Me.RadioButton_diagnostic_8221.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8221.Name = "RadioButton_diagnostic_8221"
        Me.RadioButton_diagnostic_8221.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8221.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8221.TabIndex = 4
        '
        'RadioButton_diagnostic_8220
        '
        Me.RadioButton_diagnostic_8220.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8220.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8220.cause1 = False
        Me.RadioButton_diagnostic_8220.cause2 = False
        Me.RadioButton_diagnostic_8220.cause3 = False
        Me.RadioButton_diagnostic_8220.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8220.Checked = False
        Me.RadioButton_diagnostic_8220.Code = Nothing
        Me.RadioButton_diagnostic_8220.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8220.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8220.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8220.Libelle = "OK"
        Me.RadioButton_diagnostic_8220.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8220.Location = New System.Drawing.Point(8, 50)
        Me.RadioButton_diagnostic_8220.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8220.Name = "RadioButton_diagnostic_8220"
        Me.RadioButton_diagnostic_8220.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8220.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8220.TabIndex = 7
        '
        'RadioButton_diagnostic_8222
        '
        Me.RadioButton_diagnostic_8222.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8222.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8222.cause1 = False
        Me.RadioButton_diagnostic_8222.cause2 = False
        Me.RadioButton_diagnostic_8222.cause3 = False
        Me.RadioButton_diagnostic_8222.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8222.Checked = False
        Me.RadioButton_diagnostic_8222.Code = Nothing
        Me.RadioButton_diagnostic_8222.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8222.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8222.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8222.Libelle = "8.2.2.2 - Mauvais fonctionnement"
        Me.RadioButton_diagnostic_8222.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8222.Location = New System.Drawing.Point(8, 34)
        Me.RadioButton_diagnostic_8222.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8222.Name = "RadioButton_diagnostic_8222"
        Me.RadioButton_diagnostic_8222.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8222.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8222.TabIndex = 8
        '
        'GroupBox_diagnostic_823
        '
        Me.GroupBox_diagnostic_823.Controls.Add(Me.RadioButton_diagnostic_8234)
        Me.GroupBox_diagnostic_823.Controls.Add(Me.RadioButton_diagnostic_8233)
        Me.GroupBox_diagnostic_823.Controls.Add(Me.RadioButton_diagnostic_8232)
        Me.GroupBox_diagnostic_823.Controls.Add(Me.RadioButton_diagnostic_8230)
        Me.GroupBox_diagnostic_823.Controls.Add(Me.RadioButton_diagnostic_8231)
        Me.GroupBox_diagnostic_823.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_823.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_823.Location = New System.Drawing.Point(9, 181)
        Me.GroupBox_diagnostic_823.Name = "GroupBox_diagnostic_823"
        Me.GroupBox_diagnostic_823.Size = New System.Drawing.Size(317, 102)
        Me.GroupBox_diagnostic_823.TabIndex = 7
        Me.GroupBox_diagnostic_823.TabStop = False
        Me.GroupBox_diagnostic_823.Text = "8.2.3 - Réglage en hauteur"
        '
        'RadioButton_diagnostic_8231
        '
        Me.RadioButton_diagnostic_8231.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8231.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8231.cause1 = False
        Me.RadioButton_diagnostic_8231.cause2 = False
        Me.RadioButton_diagnostic_8231.cause3 = False
        Me.RadioButton_diagnostic_8231.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8231.Checked = False
        Me.RadioButton_diagnostic_8231.Code = Nothing
        Me.RadioButton_diagnostic_8231.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8231.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8231.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8231.Libelle = "8.2.3.1 - Impossible"
        Me.RadioButton_diagnostic_8231.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8231.Location = New System.Drawing.Point(8, 18)
        Me.RadioButton_diagnostic_8231.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8231.Name = "RadioButton_diagnostic_8231"
        Me.RadioButton_diagnostic_8231.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8231.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8231.TabIndex = 4
        '
        'RadioButton_diagnostic_8230
        '
        Me.RadioButton_diagnostic_8230.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8230.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8230.cause1 = False
        Me.RadioButton_diagnostic_8230.cause2 = False
        Me.RadioButton_diagnostic_8230.cause3 = False
        Me.RadioButton_diagnostic_8230.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8230.Checked = False
        Me.RadioButton_diagnostic_8230.Code = Nothing
        Me.RadioButton_diagnostic_8230.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8230.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8230.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8230.Libelle = "OK"
        Me.RadioButton_diagnostic_8230.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8230.Location = New System.Drawing.Point(8, 82)
        Me.RadioButton_diagnostic_8230.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8230.Name = "RadioButton_diagnostic_8230"
        Me.RadioButton_diagnostic_8230.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8230.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8230.TabIndex = 7
        '
        'RadioButton_diagnostic_8232
        '
        Me.RadioButton_diagnostic_8232.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8232.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8232.cause1 = False
        Me.RadioButton_diagnostic_8232.cause2 = False
        Me.RadioButton_diagnostic_8232.cause3 = False
        Me.RadioButton_diagnostic_8232.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8232.Checked = False
        Me.RadioButton_diagnostic_8232.Code = Nothing
        Me.RadioButton_diagnostic_8232.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8232.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8232.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8232.Libelle = "8.2.3.2 - Mauvais état"
        Me.RadioButton_diagnostic_8232.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8232.Location = New System.Drawing.Point(8, 34)
        Me.RadioButton_diagnostic_8232.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8232.Name = "RadioButton_diagnostic_8232"
        Me.RadioButton_diagnostic_8232.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8232.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8232.TabIndex = 8
        '
        'RadioButton_diagnostic_8233
        '
        Me.RadioButton_diagnostic_8233.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8233.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8233.cause1 = False
        Me.RadioButton_diagnostic_8233.cause2 = False
        Me.RadioButton_diagnostic_8233.cause3 = False
        Me.RadioButton_diagnostic_8233.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8233.Checked = False
        Me.RadioButton_diagnostic_8233.Code = Nothing
        Me.RadioButton_diagnostic_8233.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8233.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8233.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8233.Libelle = "8.2.3.3 - Mauvais fonctionnement"
        Me.RadioButton_diagnostic_8233.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8233.Location = New System.Drawing.Point(8, 50)
        Me.RadioButton_diagnostic_8233.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8233.Name = "RadioButton_diagnostic_8233"
        Me.RadioButton_diagnostic_8233.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8233.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8233.TabIndex = 9
        '
        'RadioButton_diagnostic_8234
        '
        Me.RadioButton_diagnostic_8234.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8234.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8234.cause1 = False
        Me.RadioButton_diagnostic_8234.cause2 = False
        Me.RadioButton_diagnostic_8234.cause3 = False
        Me.RadioButton_diagnostic_8234.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8234.Checked = False
        Me.RadioButton_diagnostic_8234.Code = Nothing
        Me.RadioButton_diagnostic_8234.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8234.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8234.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8234.Libelle = "8.2.3.4 - Inadapté"
        Me.RadioButton_diagnostic_8234.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8234.Location = New System.Drawing.Point(8, 66)
        Me.RadioButton_diagnostic_8234.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8234.Name = "RadioButton_diagnostic_8234"
        Me.RadioButton_diagnostic_8234.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8234.Size = New System.Drawing.Size(304, 16)
        Me.RadioButton_diagnostic_8234.TabIndex = 10
        '
        'GroupBox_diagnostic_816
        '
        Me.GroupBox_diagnostic_816.Controls.Add(Me.RadioButton_diagnostic_8162)
        Me.GroupBox_diagnostic_816.Controls.Add(Me.RadioButton_diagnostic_8160)
        Me.GroupBox_diagnostic_816.Controls.Add(Me.RadioButton_diagnostic_8161)
        Me.GroupBox_diagnostic_816.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_816.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_816.Location = New System.Drawing.Point(338, 32)
        Me.GroupBox_diagnostic_816.Name = "GroupBox_diagnostic_816"
        Me.GroupBox_diagnostic_816.Size = New System.Drawing.Size(309, 74)
        Me.GroupBox_diagnostic_816.TabIndex = 15
        Me.GroupBox_diagnostic_816.TabStop = False
        Me.GroupBox_diagnostic_816.Text = "8.1.6 - Corrosion de la rampe"
        '
        'RadioButton_diagnostic_8161
        '
        Me.RadioButton_diagnostic_8161.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8161.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8161.cause1 = False
        Me.RadioButton_diagnostic_8161.cause2 = False
        Me.RadioButton_diagnostic_8161.cause3 = False
        Me.RadioButton_diagnostic_8161.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8161.Checked = False
        Me.RadioButton_diagnostic_8161.Code = Nothing
        Me.RadioButton_diagnostic_8161.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8161.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8161.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8161.Libelle = "8.1.6.1 - Corrosion mineure"
        Me.RadioButton_diagnostic_8161.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8161.Location = New System.Drawing.Point(8, 16)
        Me.RadioButton_diagnostic_8161.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8161.Name = "RadioButton_diagnostic_8161"
        Me.RadioButton_diagnostic_8161.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8161.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8161.TabIndex = 4
        '
        'RadioButton_diagnostic_8160
        '
        Me.RadioButton_diagnostic_8160.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8160.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8160.cause1 = False
        Me.RadioButton_diagnostic_8160.cause2 = False
        Me.RadioButton_diagnostic_8160.cause3 = False
        Me.RadioButton_diagnostic_8160.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8160.Checked = False
        Me.RadioButton_diagnostic_8160.Code = Nothing
        Me.RadioButton_diagnostic_8160.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8160.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8160.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8160.Libelle = "OK"
        Me.RadioButton_diagnostic_8160.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8160.Location = New System.Drawing.Point(8, 48)
        Me.RadioButton_diagnostic_8160.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8160.Name = "RadioButton_diagnostic_8160"
        Me.RadioButton_diagnostic_8160.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8160.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8160.TabIndex = 7
        '
        'RadioButton_diagnostic_8162
        '
        Me.RadioButton_diagnostic_8162.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8162.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8162.cause1 = False
        Me.RadioButton_diagnostic_8162.cause2 = False
        Me.RadioButton_diagnostic_8162.cause3 = False
        Me.RadioButton_diagnostic_8162.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8162.Checked = False
        Me.RadioButton_diagnostic_8162.Code = Nothing
        Me.RadioButton_diagnostic_8162.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8162.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8162.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8162.Libelle = "8.1.6.2 - Corrosion majeure"
        Me.RadioButton_diagnostic_8162.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8162.Location = New System.Drawing.Point(8, 32)
        Me.RadioButton_diagnostic_8162.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8162.Name = "RadioButton_diagnostic_8162"
        Me.RadioButton_diagnostic_8162.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8162.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8162.TabIndex = 8
        '
        'GroupBox_diagnostic_813
        '
        Me.GroupBox_diagnostic_813.Controls.Add(Me.RadioButton_diagnostic_8130)
        Me.GroupBox_diagnostic_813.Controls.Add(Me.RadioButton_diagnostic_8132)
        Me.GroupBox_diagnostic_813.Controls.Add(Me.RadioButton_diagnostic_8131)
        Me.GroupBox_diagnostic_813.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_813.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_813.Location = New System.Drawing.Point(11, 248)
        Me.GroupBox_diagnostic_813.Name = "GroupBox_diagnostic_813"
        Me.GroupBox_diagnostic_813.Size = New System.Drawing.Size(309, 80)
        Me.GroupBox_diagnostic_813.TabIndex = 7
        Me.GroupBox_diagnostic_813.TabStop = False
        Me.GroupBox_diagnostic_813.Text = "8.1.3 - Protection des buses extrémités"
        '
        'RadioButton_diagnostic_8131
        '
        Me.RadioButton_diagnostic_8131.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8131.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8131.cause1 = False
        Me.RadioButton_diagnostic_8131.cause2 = False
        Me.RadioButton_diagnostic_8131.cause3 = False
        Me.RadioButton_diagnostic_8131.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8131.Checked = False
        Me.RadioButton_diagnostic_8131.Code = Nothing
        Me.RadioButton_diagnostic_8131.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8131.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8131.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8131.Libelle = "8.1.3.1 - Tronçons escamotables défectueux (>=12m)"
        Me.RadioButton_diagnostic_8131.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8131.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_8131.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8131.Name = "RadioButton_diagnostic_8131"
        Me.RadioButton_diagnostic_8131.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8131.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8131.TabIndex = 4
        '
        'RadioButton_diagnostic_8132
        '
        Me.RadioButton_diagnostic_8132.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8132.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8132.cause1 = False
        Me.RadioButton_diagnostic_8132.cause2 = False
        Me.RadioButton_diagnostic_8132.cause3 = False
        Me.RadioButton_diagnostic_8132.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8132.Checked = False
        Me.RadioButton_diagnostic_8132.Code = Nothing
        Me.RadioButton_diagnostic_8132.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8132.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8132.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8132.Libelle = "8.1.3.2 - Contact avec le sol non protégé (>=12m)"
        Me.RadioButton_diagnostic_8132.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8132.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_8132.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8132.Name = "RadioButton_diagnostic_8132"
        Me.RadioButton_diagnostic_8132.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8132.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8132.TabIndex = 8
        '
        'RadioButton_diagnostic_8130
        '
        Me.RadioButton_diagnostic_8130.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8130.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8130.cause1 = False
        Me.RadioButton_diagnostic_8130.cause2 = False
        Me.RadioButton_diagnostic_8130.cause3 = False
        Me.RadioButton_diagnostic_8130.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8130.Checked = False
        Me.RadioButton_diagnostic_8130.Code = Nothing
        Me.RadioButton_diagnostic_8130.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8130.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8130.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8130.Libelle = "OK"
        Me.RadioButton_diagnostic_8130.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8130.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_8130.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8130.Name = "RadioButton_diagnostic_8130"
        Me.RadioButton_diagnostic_8130.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8130.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8130.TabIndex = 7
        '
        'GroupBox_diagnostic_817
        '
        Me.GroupBox_diagnostic_817.Controls.Add(Me.RadioButton_diagnostic_8172)
        Me.GroupBox_diagnostic_817.Controls.Add(Me.RadioButton_diagnostic_8170)
        Me.GroupBox_diagnostic_817.Controls.Add(Me.RadioButton_diagnostic_8171)
        Me.GroupBox_diagnostic_817.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_817.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_817.Location = New System.Drawing.Point(339, 112)
        Me.GroupBox_diagnostic_817.Name = "GroupBox_diagnostic_817"
        Me.GroupBox_diagnostic_817.Size = New System.Drawing.Size(309, 70)
        Me.GroupBox_diagnostic_817.TabIndex = 16
        Me.GroupBox_diagnostic_817.TabStop = False
        Me.GroupBox_diagnostic_817.Text = "8.1.7 - Lésion sur pièces métalliques"
        '
        'RadioButton_diagnostic_8171
        '
        Me.RadioButton_diagnostic_8171.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8171.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8171.cause1 = False
        Me.RadioButton_diagnostic_8171.cause2 = False
        Me.RadioButton_diagnostic_8171.cause3 = False
        Me.RadioButton_diagnostic_8171.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8171.Checked = False
        Me.RadioButton_diagnostic_8171.Code = Nothing
        Me.RadioButton_diagnostic_8171.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8171.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8171.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8171.Libelle = "8.1.7.1 - Lésion mineure"
        Me.RadioButton_diagnostic_8171.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8171.Location = New System.Drawing.Point(8, 16)
        Me.RadioButton_diagnostic_8171.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8171.Name = "RadioButton_diagnostic_8171"
        Me.RadioButton_diagnostic_8171.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8171.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8171.TabIndex = 4
        '
        'RadioButton_diagnostic_8170
        '
        Me.RadioButton_diagnostic_8170.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8170.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8170.cause1 = False
        Me.RadioButton_diagnostic_8170.cause2 = False
        Me.RadioButton_diagnostic_8170.cause3 = False
        Me.RadioButton_diagnostic_8170.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8170.Checked = False
        Me.RadioButton_diagnostic_8170.Code = Nothing
        Me.RadioButton_diagnostic_8170.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8170.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8170.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8170.Libelle = "OK"
        Me.RadioButton_diagnostic_8170.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8170.Location = New System.Drawing.Point(8, 48)
        Me.RadioButton_diagnostic_8170.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8170.Name = "RadioButton_diagnostic_8170"
        Me.RadioButton_diagnostic_8170.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8170.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8170.TabIndex = 7
        '
        'RadioButton_diagnostic_8172
        '
        Me.RadioButton_diagnostic_8172.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8172.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8172.cause1 = False
        Me.RadioButton_diagnostic_8172.cause2 = False
        Me.RadioButton_diagnostic_8172.cause3 = False
        Me.RadioButton_diagnostic_8172.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8172.Checked = False
        Me.RadioButton_diagnostic_8172.Code = Nothing
        Me.RadioButton_diagnostic_8172.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8172.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8172.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8172.Libelle = "8.1.7.2 - Lésion majeure"
        Me.RadioButton_diagnostic_8172.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8172.Location = New System.Drawing.Point(8, 32)
        Me.RadioButton_diagnostic_8172.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8172.Name = "RadioButton_diagnostic_8172"
        Me.RadioButton_diagnostic_8172.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8172.Size = New System.Drawing.Size(296, 16)
        Me.RadioButton_diagnostic_8172.TabIndex = 8
        '
        'Panel36
        '
        Me.Panel36.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel36.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel36.Controls.Add(Me.popup_help_831)
        Me.Panel36.Controls.Add(Me.GroupBox_diagnostic_833)
        Me.Panel36.Controls.Add(Me.GroupBox_diagnostic_832)
        Me.Panel36.Controls.Add(Me.GroupBox_diagnostic_831)
        Me.Panel36.Controls.Add(Me.Label_diagnostic_83)
        Me.Panel36.Controls.Add(Me.popup_help_811)
        Me.Panel36.Location = New System.Drawing.Point(665, 143)
        Me.Panel36.Name = "Panel36"
        Me.Panel36.Size = New System.Drawing.Size(343, 510)
        Me.Panel36.TabIndex = 11
        '
        'popup_help_811
        '
        Me.popup_help_811.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.popup_help_811.Controls.Add(Me.Panel123)
        Me.popup_help_811.Location = New System.Drawing.Point(5, 467)
        Me.popup_help_811.Name = "popup_help_811"
        Me.popup_help_811.Size = New System.Drawing.Size(334, 152)
        Me.popup_help_811.TabIndex = 18
        Me.popup_help_811.Visible = False
        '
        'Panel123
        '
        Me.Panel123.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel123.Controls.Add(Me.help811_result)
        Me.Panel123.Controls.Add(Me.help811_fleche)
        Me.Panel123.Controls.Add(Me.Label15)
        Me.Panel123.Controls.Add(Me.Label13)
        Me.Panel123.Controls.Add(Me.Label14)
        Me.Panel123.Controls.Add(Me.help811_largeur)
        Me.Panel123.Controls.Add(Me.help811_close)
        Me.Panel123.Location = New System.Drawing.Point(3, 3)
        Me.Panel123.Name = "Panel123"
        Me.Panel123.Size = New System.Drawing.Size(328, 146)
        Me.Panel123.TabIndex = 0
        '
        'help811_close
        '
        Me.help811_close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help811_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help811_close.ForeColor = System.Drawing.Color.White
        Me.help811_close.Image = CType(resources.GetObject("help811_close.Image"), System.Drawing.Image)
        Me.help811_close.Location = New System.Drawing.Point(192, 112)
        Me.help811_close.Name = "help811_close"
        Me.help811_close.Size = New System.Drawing.Size(128, 24)
        Me.help811_close.TabIndex = 2
        Me.help811_close.Text = "     Valider le tableau"
        Me.help811_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'help811_largeur
        '
        Me.help811_largeur.ForceBindingOnTextChanged = False
        Me.help811_largeur.Location = New System.Drawing.Point(160, 32)
        Me.help811_largeur.Name = "help811_largeur"
        Me.help811_largeur.Size = New System.Drawing.Size(100, 20)
        Me.help811_largeur.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(32, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Largeur rampe (m) ="
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(8, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 16)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Courbure (mesures) :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(32, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 16)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Flèche (cm) ="
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help811_fleche
        '
        Me.help811_fleche.ForceBindingOnTextChanged = False
        Me.help811_fleche.Location = New System.Drawing.Point(160, 56)
        Me.help811_fleche.Name = "help811_fleche"
        Me.help811_fleche.Size = New System.Drawing.Size(100, 20)
        Me.help811_fleche.TabIndex = 1
        '
        'help811_result
        '
        Me.help811_result.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help811_result.ForeColor = System.Drawing.Color.Red
        Me.help811_result.Location = New System.Drawing.Point(152, 88)
        Me.help811_result.Name = "help811_result"
        Me.help811_result.Size = New System.Drawing.Size(168, 16)
        Me.help811_result.TabIndex = 30
        Me.help811_result.Text = "IMPORTANTE"
        Me.help811_result.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label_diagnostic_83
        '
        Me.Label_diagnostic_83.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_83.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_83.Image = CType(resources.GetObject("Label_diagnostic_83.Image"), System.Drawing.Image)
        Me.Label_diagnostic_83.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_83.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_83.Name = "Label_diagnostic_83"
        Me.Label_diagnostic_83.Size = New System.Drawing.Size(331, 16)
        Me.Label_diagnostic_83.TabIndex = 13
        Me.Label_diagnostic_83.Text = "     Porte-jets / Diffuseurs"
        '
        'GroupBox_diagnostic_831
        '
        Me.GroupBox_diagnostic_831.Controls.Add(Me.ico_help_8314)
        Me.GroupBox_diagnostic_831.Controls.Add(Me.RadioButton_diagnostic_8314)
        Me.GroupBox_diagnostic_831.Controls.Add(Me.ico_help_8312)
        Me.GroupBox_diagnostic_831.Controls.Add(Me.RadioButton_diagnostic_8313)
        Me.GroupBox_diagnostic_831.Controls.Add(Me.RadioButton_diagnostic_8310)
        Me.GroupBox_diagnostic_831.Controls.Add(Me.RadioButton_diagnostic_8311)
        Me.GroupBox_diagnostic_831.Controls.Add(Me.RadioButton_diagnostic_8312)
        Me.GroupBox_diagnostic_831.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_831.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_831.Location = New System.Drawing.Point(11, 32)
        Me.GroupBox_diagnostic_831.Name = "GroupBox_diagnostic_831"
        Me.GroupBox_diagnostic_831.Size = New System.Drawing.Size(325, 112)
        Me.GroupBox_diagnostic_831.TabIndex = 5
        Me.GroupBox_diagnostic_831.TabStop = False
        Me.GroupBox_diagnostic_831.Text = "8.3.1 - Disposition"
        '
        'RadioButton_diagnostic_8312
        '
        Me.RadioButton_diagnostic_8312.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_8312.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8312.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8312.cause1 = False
        Me.RadioButton_diagnostic_8312.cause2 = False
        Me.RadioButton_diagnostic_8312.cause3 = False
        Me.RadioButton_diagnostic_8312.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8312.Checked = False
        Me.RadioButton_diagnostic_8312.Code = Nothing
        Me.RadioButton_diagnostic_8312.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8312.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8312.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8312.Libelle = "8.3.1.2 - Irrégularité des espacements (rampe)"
        Me.RadioButton_diagnostic_8312.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8312.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_8312.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8312.Name = "RadioButton_diagnostic_8312"
        Me.RadioButton_diagnostic_8312.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8312.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8312.TabIndex = 4
        '
        'RadioButton_diagnostic_8311
        '
        Me.RadioButton_diagnostic_8311.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_8311.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8311.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8311.cause1 = False
        Me.RadioButton_diagnostic_8311.cause2 = False
        Me.RadioButton_diagnostic_8311.cause3 = False
        Me.RadioButton_diagnostic_8311.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8311.Checked = False
        Me.RadioButton_diagnostic_8311.Code = Nothing
        Me.RadioButton_diagnostic_8311.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8311.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8311.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8311.Libelle = "8.3.1.1 - Dissymétrie de montage"
        Me.RadioButton_diagnostic_8311.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8311.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_8311.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8311.Name = "RadioButton_diagnostic_8311"
        Me.RadioButton_diagnostic_8311.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8311.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8311.TabIndex = 5
        '
        'RadioButton_diagnostic_8310
        '
        Me.RadioButton_diagnostic_8310.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_8310.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8310.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8310.cause1 = False
        Me.RadioButton_diagnostic_8310.cause2 = False
        Me.RadioButton_diagnostic_8310.cause3 = False
        Me.RadioButton_diagnostic_8310.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8310.Checked = False
        Me.RadioButton_diagnostic_8310.Code = Nothing
        Me.RadioButton_diagnostic_8310.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8310.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8310.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8310.Libelle = "OK"
        Me.RadioButton_diagnostic_8310.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8310.Location = New System.Drawing.Point(8, 93)
        Me.RadioButton_diagnostic_8310.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8310.Name = "RadioButton_diagnostic_8310"
        Me.RadioButton_diagnostic_8310.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8310.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8310.TabIndex = 7
        '
        'RadioButton_diagnostic_8313
        '
        Me.RadioButton_diagnostic_8313.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_8313.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8313.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8313.cause1 = False
        Me.RadioButton_diagnostic_8313.cause2 = False
        Me.RadioButton_diagnostic_8313.cause3 = False
        Me.RadioButton_diagnostic_8313.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8313.Checked = False
        Me.RadioButton_diagnostic_8313.Code = Nothing
        Me.RadioButton_diagnostic_8313.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8313.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8313.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8313.Libelle = "8.3.1.3 - Mauvais aplomb (rampe)"
        Me.RadioButton_diagnostic_8313.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8313.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_8313.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8313.Name = "RadioButton_diagnostic_8313"
        Me.RadioButton_diagnostic_8313.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8313.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8313.TabIndex = 8
        '
        'ico_help_8312
        '
        Me.ico_help_8312.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ico_help_8312.Image = CType(resources.GetObject("ico_help_8312.Image"), System.Drawing.Image)
        Me.ico_help_8312.Location = New System.Drawing.Point(272, 36)
        Me.ico_help_8312.Name = "ico_help_8312"
        Me.ico_help_8312.Size = New System.Drawing.Size(20, 20)
        Me.ico_help_8312.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ico_help_8312.TabIndex = 20
        Me.ico_help_8312.TabStop = False
        '
        'RadioButton_diagnostic_8314
        '
        Me.RadioButton_diagnostic_8314.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_8314.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8314.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8314.cause1 = False
        Me.RadioButton_diagnostic_8314.cause2 = False
        Me.RadioButton_diagnostic_8314.cause3 = False
        Me.RadioButton_diagnostic_8314.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8314.Checked = False
        Me.RadioButton_diagnostic_8314.Code = Nothing
        Me.RadioButton_diagnostic_8314.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8314.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8314.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8314.Libelle = "8.3.1.4 - Irrégularité groupe de buses"
        Me.RadioButton_diagnostic_8314.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8314.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_8314.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8314.Name = "RadioButton_diagnostic_8314"
        Me.RadioButton_diagnostic_8314.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8314.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8314.TabIndex = 21
        '
        'ico_help_8314
        '
        Me.ico_help_8314.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ico_help_8314.Image = CType(resources.GetObject("ico_help_8314.Image"), System.Drawing.Image)
        Me.ico_help_8314.Location = New System.Drawing.Point(272, 68)
        Me.ico_help_8314.Name = "ico_help_8314"
        Me.ico_help_8314.Size = New System.Drawing.Size(20, 20)
        Me.ico_help_8314.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ico_help_8314.TabIndex = 22
        Me.ico_help_8314.TabStop = False
        '
        'GroupBox_diagnostic_832
        '
        Me.GroupBox_diagnostic_832.Controls.Add(Me.RadioButton_diagnostic_8323)
        Me.GroupBox_diagnostic_832.Controls.Add(Me.RadioButton_diagnostic_8322)
        Me.GroupBox_diagnostic_832.Controls.Add(Me.RadioButton_diagnostic_8320)
        Me.GroupBox_diagnostic_832.Controls.Add(Me.RadioButton_diagnostic_8321)
        Me.GroupBox_diagnostic_832.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_832.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_832.Location = New System.Drawing.Point(11, 160)
        Me.GroupBox_diagnostic_832.Name = "GroupBox_diagnostic_832"
        Me.GroupBox_diagnostic_832.Size = New System.Drawing.Size(325, 104)
        Me.GroupBox_diagnostic_832.TabIndex = 6
        Me.GroupBox_diagnostic_832.TabStop = False
        Me.GroupBox_diagnostic_832.Text = "8.3.2 - Etat"
        '
        'RadioButton_diagnostic_8321
        '
        Me.RadioButton_diagnostic_8321.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8321.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8321.cause1 = False
        Me.RadioButton_diagnostic_8321.cause2 = False
        Me.RadioButton_diagnostic_8321.cause3 = False
        Me.RadioButton_diagnostic_8321.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8321.Checked = False
        Me.RadioButton_diagnostic_8321.Code = Nothing
        Me.RadioButton_diagnostic_8321.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8321.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8321.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8321.Libelle = "8.3.2.1 - Félure"
        Me.RadioButton_diagnostic_8321.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8321.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_8321.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8321.Name = "RadioButton_diagnostic_8321"
        Me.RadioButton_diagnostic_8321.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8321.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8321.TabIndex = 4
        '
        'RadioButton_diagnostic_8320
        '
        Me.RadioButton_diagnostic_8320.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8320.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8320.cause1 = False
        Me.RadioButton_diagnostic_8320.cause2 = False
        Me.RadioButton_diagnostic_8320.cause3 = False
        Me.RadioButton_diagnostic_8320.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8320.Checked = False
        Me.RadioButton_diagnostic_8320.Code = Nothing
        Me.RadioButton_diagnostic_8320.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8320.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8320.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8320.Libelle = "OK"
        Me.RadioButton_diagnostic_8320.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8320.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_8320.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8320.Name = "RadioButton_diagnostic_8320"
        Me.RadioButton_diagnostic_8320.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8320.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8320.TabIndex = 7
        '
        'RadioButton_diagnostic_8322
        '
        Me.RadioButton_diagnostic_8322.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8322.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8322.cause1 = False
        Me.RadioButton_diagnostic_8322.cause2 = False
        Me.RadioButton_diagnostic_8322.cause3 = False
        Me.RadioButton_diagnostic_8322.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8322.Checked = False
        Me.RadioButton_diagnostic_8322.Code = Nothing
        Me.RadioButton_diagnostic_8322.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8322.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8322.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8322.Libelle = "8.3.2.2 - Casse"
        Me.RadioButton_diagnostic_8322.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8322.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_8322.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8322.Name = "RadioButton_diagnostic_8322"
        Me.RadioButton_diagnostic_8322.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8322.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8322.TabIndex = 8
        '
        'RadioButton_diagnostic_8323
        '
        Me.RadioButton_diagnostic_8323.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8323.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8323.cause1 = False
        Me.RadioButton_diagnostic_8323.cause2 = False
        Me.RadioButton_diagnostic_8323.cause3 = False
        Me.RadioButton_diagnostic_8323.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8323.Checked = False
        Me.RadioButton_diagnostic_8323.Code = Nothing
        Me.RadioButton_diagnostic_8323.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8323.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8323.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8323.Libelle = "8.3.2.3 - Usure"
        Me.RadioButton_diagnostic_8323.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8323.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_8323.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8323.Name = "RadioButton_diagnostic_8323"
        Me.RadioButton_diagnostic_8323.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8323.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8323.TabIndex = 9
        '
        'GroupBox_diagnostic_833
        '
        Me.GroupBox_diagnostic_833.Controls.Add(Me.RadioButton_diagnostic_8334)
        Me.GroupBox_diagnostic_833.Controls.Add(Me.RadioButton_diagnostic_8333)
        Me.GroupBox_diagnostic_833.Controls.Add(Me.RadioButton_diagnostic_8332)
        Me.GroupBox_diagnostic_833.Controls.Add(Me.RadioButton_diagnostic_8330)
        Me.GroupBox_diagnostic_833.Controls.Add(Me.RadioButton_diagnostic_8331)
        Me.GroupBox_diagnostic_833.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_833.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_833.Location = New System.Drawing.Point(11, 280)
        Me.GroupBox_diagnostic_833.Name = "GroupBox_diagnostic_833"
        Me.GroupBox_diagnostic_833.Size = New System.Drawing.Size(325, 134)
        Me.GroupBox_diagnostic_833.TabIndex = 7
        Me.GroupBox_diagnostic_833.TabStop = False
        Me.GroupBox_diagnostic_833.Text = "8.3.3 - Fonctionnement"
        '
        'RadioButton_diagnostic_8331
        '
        Me.RadioButton_diagnostic_8331.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8331.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8331.cause1 = False
        Me.RadioButton_diagnostic_8331.cause2 = False
        Me.RadioButton_diagnostic_8331.cause3 = False
        Me.RadioButton_diagnostic_8331.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8331.Checked = False
        Me.RadioButton_diagnostic_8331.Code = Nothing
        Me.RadioButton_diagnostic_8331.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_8331.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8331.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8331.Libelle = "8.3.3.1 - Antigoutte défectueux"
        Me.RadioButton_diagnostic_8331.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8331.Location = New System.Drawing.Point(10, 25)
        Me.RadioButton_diagnostic_8331.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8331.Name = "RadioButton_diagnostic_8331"
        Me.RadioButton_diagnostic_8331.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8331.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8331.TabIndex = 4
        '
        'RadioButton_diagnostic_8330
        '
        Me.RadioButton_diagnostic_8330.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8330.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8330.cause1 = False
        Me.RadioButton_diagnostic_8330.cause2 = False
        Me.RadioButton_diagnostic_8330.cause3 = False
        Me.RadioButton_diagnostic_8330.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8330.Checked = False
        Me.RadioButton_diagnostic_8330.Code = Nothing
        Me.RadioButton_diagnostic_8330.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_8330.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8330.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8330.Libelle = "OK"
        Me.RadioButton_diagnostic_8330.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8330.Location = New System.Drawing.Point(10, 90)
        Me.RadioButton_diagnostic_8330.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8330.Name = "RadioButton_diagnostic_8330"
        Me.RadioButton_diagnostic_8330.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8330.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8330.TabIndex = 7
        '
        'RadioButton_diagnostic_8332
        '
        Me.RadioButton_diagnostic_8332.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8332.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8332.cause1 = False
        Me.RadioButton_diagnostic_8332.cause2 = False
        Me.RadioButton_diagnostic_8332.cause3 = False
        Me.RadioButton_diagnostic_8332.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8332.Checked = False
        Me.RadioButton_diagnostic_8332.Code = Nothing
        Me.RadioButton_diagnostic_8332.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8332.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8332.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8332.Libelle = "8.3.3.2 - Hétérogénéité d'alimentation"
        Me.RadioButton_diagnostic_8332.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8332.Location = New System.Drawing.Point(10, 41)
        Me.RadioButton_diagnostic_8332.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8332.Name = "RadioButton_diagnostic_8332"
        Me.RadioButton_diagnostic_8332.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8332.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8332.TabIndex = 8
        '
        'RadioButton_diagnostic_8333
        '
        Me.RadioButton_diagnostic_8333.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8333.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8333.cause1 = False
        Me.RadioButton_diagnostic_8333.cause2 = False
        Me.RadioButton_diagnostic_8333.cause3 = False
        Me.RadioButton_diagnostic_8333.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8333.Checked = False
        Me.RadioButton_diagnostic_8333.Code = Nothing
        Me.RadioButton_diagnostic_8333.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8333.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8333.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8333.Libelle = "8.3.3.3 - Ecart de pression"
        Me.RadioButton_diagnostic_8333.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8333.Location = New System.Drawing.Point(10, 57)
        Me.RadioButton_diagnostic_8333.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8333.Name = "RadioButton_diagnostic_8333"
        Me.RadioButton_diagnostic_8333.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8333.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8333.TabIndex = 19
        '
        'RadioButton_diagnostic_8334
        '
        Me.RadioButton_diagnostic_8334.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8334.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_8334.cause1 = False
        Me.RadioButton_diagnostic_8334.cause2 = False
        Me.RadioButton_diagnostic_8334.cause3 = False
        Me.RadioButton_diagnostic_8334.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8334.Checked = False
        Me.RadioButton_diagnostic_8334.Code = Nothing
        Me.RadioButton_diagnostic_8334.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_8334.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_8334.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_8334.Libelle = "8.3.3.4 - Antigoutte absent"
        Me.RadioButton_diagnostic_8334.LibelleLong = Nothing
        Me.RadioButton_diagnostic_8334.Location = New System.Drawing.Point(10, 73)
        Me.RadioButton_diagnostic_8334.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_8334.Name = "RadioButton_diagnostic_8334"
        Me.RadioButton_diagnostic_8334.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_8334.Size = New System.Drawing.Size(312, 16)
        Me.RadioButton_diagnostic_8334.TabIndex = 20
        '
        'popup_help_831
        '
        Me.popup_help_831.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.popup_help_831.Controls.Add(Me.Panel125)
        Me.popup_help_831.Location = New System.Drawing.Point(188, 440)
        Me.popup_help_831.Name = "popup_help_831"
        Me.popup_help_831.Size = New System.Drawing.Size(334, 192)
        Me.popup_help_831.TabIndex = 19
        Me.popup_help_831.Visible = False
        '
        'Panel125
        '
        Me.Panel125.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel125.Controls.Add(Me.help831_ecartementMax)
        Me.Panel125.Controls.Add(Me.help831_ecartementReference)
        Me.Panel125.Controls.Add(Me.Label16)
        Me.Panel125.Controls.Add(Me.Label24)
        Me.Panel125.Controls.Add(Me.lblPopup831)
        Me.Panel125.Controls.Add(Me.Label26)
        Me.Panel125.Controls.Add(Me.help831_ecartementMin)
        Me.Panel125.Controls.Add(Me.help831_result)
        Me.Panel125.Controls.Add(Me.help831_close)
        Me.Panel125.Controls.Add(Me.help831_ecart)
        Me.Panel125.Controls.Add(Me.Label211)
        Me.Panel125.Location = New System.Drawing.Point(3, 3)
        Me.Panel125.Name = "Panel125"
        Me.Panel125.Size = New System.Drawing.Size(328, 186)
        Me.Panel125.TabIndex = 1
        '
        'Label211
        '
        Me.Label211.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label211.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label211.Location = New System.Drawing.Point(32, 104)
        Me.Label211.Name = "Label211"
        Me.Label211.Size = New System.Drawing.Size(176, 16)
        Me.Label211.TabIndex = 8
        Me.Label211.Text = "Ecart (%) ="
        Me.Label211.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help831_ecart
        '
        Me.help831_ecart.ForceBindingOnTextChanged = False
        Me.help831_ecart.Location = New System.Drawing.Point(224, 104)
        Me.help831_ecart.Name = "help831_ecart"
        Me.help831_ecart.ReadOnly = True
        Me.help831_ecart.Size = New System.Drawing.Size(80, 20)
        Me.help831_ecart.TabIndex = 3
        '
        'help831_close
        '
        Me.help831_close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help831_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help831_close.ForeColor = System.Drawing.Color.White
        Me.help831_close.Image = CType(resources.GetObject("help831_close.Image"), System.Drawing.Image)
        Me.help831_close.Location = New System.Drawing.Point(192, 152)
        Me.help831_close.Name = "help831_close"
        Me.help831_close.Size = New System.Drawing.Size(128, 24)
        Me.help831_close.TabIndex = 5
        Me.help831_close.Text = "     Valider le tableau"
        Me.help831_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'help831_result
        '
        Me.help831_result.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help831_result.ForeColor = System.Drawing.Color.Red
        Me.help831_result.Location = New System.Drawing.Point(152, 130)
        Me.help831_result.Name = "help831_result"
        Me.help831_result.Size = New System.Drawing.Size(168, 16)
        Me.help831_result.TabIndex = 4
        Me.help831_result.Text = "IRRÉGULARITÉ"
        Me.help831_result.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'help831_ecartementMin
        '
        Me.help831_ecartementMin.ForceBindingOnTextChanged = False
        Me.help831_ecartementMin.Location = New System.Drawing.Point(224, 80)
        Me.help831_ecartementMin.Name = "help831_ecartementMin"
        Me.help831_ecartementMin.Size = New System.Drawing.Size(80, 20)
        Me.help831_ecartementMin.TabIndex = 2
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(32, 80)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(176, 16)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Écartement minimum (cm) ="
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblPopup831
        '
        Me.lblPopup831.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopup831.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPopup831.Location = New System.Drawing.Point(8, 8)
        Me.lblPopup831.Name = "lblPopup831"
        Me.lblPopup831.Size = New System.Drawing.Size(316, 16)
        Me.lblPopup831.TabIndex = 8
        Me.lblPopup831.Text = "Irrégularité des espacements :"
        Me.lblPopup831.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(32, 32)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(176, 16)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "Écartement de reférence (cm) ="
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(32, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(176, 16)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Écartement maximum (cm) ="
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help831_ecartementReference
        '
        Me.help831_ecartementReference.ForceBindingOnTextChanged = False
        Me.help831_ecartementReference.Location = New System.Drawing.Point(224, 32)
        Me.help831_ecartementReference.Name = "help831_ecartementReference"
        Me.help831_ecartementReference.Size = New System.Drawing.Size(80, 20)
        Me.help831_ecartementReference.TabIndex = 0
        '
        'help831_ecartementMax
        '
        Me.help831_ecartementMax.ForceBindingOnTextChanged = False
        Me.help831_ecartementMax.Location = New System.Drawing.Point(224, 56)
        Me.help831_ecartementMax.Name = "help831_ecartementMax"
        Me.help831_ecartementMax.Size = New System.Drawing.Size(80, 20)
        Me.help831_ecartementMax.TabIndex = 1
        '
        'Panel128
        '
        Me.Panel128.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel128.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel128.Controls.Add(Me.Label_diagnostic_8)
        Me.Panel128.Location = New System.Drawing.Point(0, 112)
        Me.Panel128.Name = "Panel128"
        Me.Panel128.Size = New System.Drawing.Size(1008, 30)
        Me.Panel128.TabIndex = 21
        '
        'Label_diagnostic_8
        '
        Me.Label_diagnostic_8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_8.Image = CType(resources.GetObject("Label_diagnostic_8.Image"), System.Drawing.Image)
        Me.Label_diagnostic_8.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_8.Location = New System.Drawing.Point(8, 3)
        Me.Label_diagnostic_8.Name = "Label_diagnostic_8"
        Me.Label_diagnostic_8.Size = New System.Drawing.Size(994, 24)
        Me.Label_diagnostic_8.TabIndex = 20
        Me.Label_diagnostic_8.Text = "     8. Rampes de pulvérisation"
        '
        'tabPage_diagnostique_mesureCommandesRegulation
        '
        Me.tabPage_diagnostique_mesureCommandesRegulation.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.Panel127)
        Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.Panel26)
        Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.Panel24)
        Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.Panel21)
        Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.Panel23)
        Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.Panel22)
        Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.Panel25)
        Me.tabPage_diagnostique_mesureCommandesRegulation.ImageIndex = 3
        Me.tabPage_diagnostique_mesureCommandesRegulation.Location = New System.Drawing.Point(4, 23)
        Me.tabPage_diagnostique_mesureCommandesRegulation.Name = "tabPage_diagnostique_mesureCommandesRegulation"
        Me.tabPage_diagnostique_mesureCommandesRegulation.Size = New System.Drawing.Size(1008, 653)
        Me.tabPage_diagnostique_mesureCommandesRegulation.TabIndex = 2
        Me.tabPage_diagnostique_mesureCommandesRegulation.Tag = "5"
        Me.tabPage_diagnostique_mesureCommandesRegulation.Text = "Mesure/Commandes/Régulation"
        '
        'Panel25
        '
        Me.Panel25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel25.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel25.Controls.Add(Me.GroupBox_diagnostic_552)
        Me.Panel25.Controls.Add(Me.GroupBox_diagnostic_551)
        Me.Panel25.Controls.Add(Me.Label_diagnostic_55)
        Me.Panel25.Location = New System.Drawing.Point(377, 320)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(325, 333)
        Me.Panel25.TabIndex = 9
        '
        'Label_diagnostic_55
        '
        Me.Label_diagnostic_55.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_55.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_55.Image = CType(resources.GetObject("Label_diagnostic_55.Image"), System.Drawing.Image)
        Me.Label_diagnostic_55.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_55.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_55.Name = "Label_diagnostic_55"
        Me.Label_diagnostic_55.Size = New System.Drawing.Size(314, 34)
        Me.Label_diagnostic_55.TabIndex = 12
        Me.Label_diagnostic_55.Text = "     Indicateurs utilisés pour la régulation"
        '
        'GroupBox_diagnostic_551
        '
        Me.GroupBox_diagnostic_551.Controls.Add(Me.RadioButton_diagnostic_5512)
        Me.GroupBox_diagnostic_551.Controls.Add(Me.RadioButton_diagnostic_5510)
        Me.GroupBox_diagnostic_551.Controls.Add(Me.RadioButton_diagnostic_5511)
        Me.GroupBox_diagnostic_551.Controls.Add(Me.ico_help_551)
        Me.GroupBox_diagnostic_551.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_551.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_551.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox_diagnostic_551.Name = "GroupBox_diagnostic_551"
        Me.GroupBox_diagnostic_551.Size = New System.Drawing.Size(311, 112)
        Me.GroupBox_diagnostic_551.TabIndex = 9
        Me.GroupBox_diagnostic_551.TabStop = False
        Me.GroupBox_diagnostic_551.Text = "5.5.1 - Vitesse d'avancement"
        '
        'ico_help_551
        '
        Me.ico_help_551.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ico_help_551.BackColor = System.Drawing.Color.Transparent
        Me.ico_help_551.Image = CType(resources.GetObject("ico_help_551.Image"), System.Drawing.Image)
        Me.ico_help_551.Location = New System.Drawing.Point(279, 8)
        Me.ico_help_551.Name = "ico_help_551"
        Me.ico_help_551.Size = New System.Drawing.Size(29, 29)
        Me.ico_help_551.TabIndex = 6
        Me.ico_help_551.TabStop = False
        '
        'RadioButton_diagnostic_5511
        '
        Me.RadioButton_diagnostic_5511.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5511.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5511.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5511.cause1 = False
        Me.RadioButton_diagnostic_5511.cause2 = False
        Me.RadioButton_diagnostic_5511.cause3 = False
        Me.RadioButton_diagnostic_5511.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5511.Checked = False
        Me.RadioButton_diagnostic_5511.Code = Nothing
        Me.RadioButton_diagnostic_5511.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5511.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5511.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5511.Libelle = "5.5.1.1 - Non fonctionnel"
        Me.RadioButton_diagnostic_5511.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5511.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_5511.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5511.Name = "RadioButton_diagnostic_5511"
        Me.RadioButton_diagnostic_5511.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5511.Size = New System.Drawing.Size(295, 16)
        Me.RadioButton_diagnostic_5511.TabIndex = 5
        '
        'RadioButton_diagnostic_5510
        '
        Me.RadioButton_diagnostic_5510.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5510.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5510.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5510.cause1 = False
        Me.RadioButton_diagnostic_5510.cause2 = False
        Me.RadioButton_diagnostic_5510.cause3 = False
        Me.RadioButton_diagnostic_5510.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5510.Checked = False
        Me.RadioButton_diagnostic_5510.Code = Nothing
        Me.RadioButton_diagnostic_5510.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5510.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5510.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5510.Libelle = "OK"
        Me.RadioButton_diagnostic_5510.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5510.Location = New System.Drawing.Point(8, 88)
        Me.RadioButton_diagnostic_5510.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5510.Name = "RadioButton_diagnostic_5510"
        Me.RadioButton_diagnostic_5510.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5510.Size = New System.Drawing.Size(295, 16)
        Me.RadioButton_diagnostic_5510.TabIndex = 7
        '
        'RadioButton_diagnostic_5512
        '
        Me.RadioButton_diagnostic_5512.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5512.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5512.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5512.cause1 = False
        Me.RadioButton_diagnostic_5512.cause2 = False
        Me.RadioButton_diagnostic_5512.cause3 = False
        Me.RadioButton_diagnostic_5512.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5512.Checked = False
        Me.RadioButton_diagnostic_5512.Code = Nothing
        Me.RadioButton_diagnostic_5512.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5512.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5512.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5512.Libelle = "5.5.1.2 - Imprécision"
        Me.RadioButton_diagnostic_5512.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5512.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5512.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5512.Name = "RadioButton_diagnostic_5512"
        Me.RadioButton_diagnostic_5512.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5512.Size = New System.Drawing.Size(295, 16)
        Me.RadioButton_diagnostic_5512.TabIndex = 8
        '
        'GroupBox_diagnostic_552
        '
        Me.GroupBox_diagnostic_552.Controls.Add(Me.Pctb_calc)
        Me.GroupBox_diagnostic_552.Controls.Add(Me.ico_help_552)
        Me.GroupBox_diagnostic_552.Controls.Add(Me.RadioButton_diagnostic_5522)
        Me.GroupBox_diagnostic_552.Controls.Add(Me.RadioButton_diagnostic_5520)
        Me.GroupBox_diagnostic_552.Controls.Add(Me.RadioButton_diagnostic_5521)
        Me.GroupBox_diagnostic_552.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_552.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_552.Location = New System.Drawing.Point(8, 168)
        Me.GroupBox_diagnostic_552.Name = "GroupBox_diagnostic_552"
        Me.GroupBox_diagnostic_552.Size = New System.Drawing.Size(311, 112)
        Me.GroupBox_diagnostic_552.TabIndex = 6
        Me.GroupBox_diagnostic_552.TabStop = False
        Me.GroupBox_diagnostic_552.Text = "5.5.2 - Débit"
        '
        'RadioButton_diagnostic_5521
        '
        Me.RadioButton_diagnostic_5521.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5521.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5521.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5521.cause1 = False
        Me.RadioButton_diagnostic_5521.cause2 = False
        Me.RadioButton_diagnostic_5521.cause3 = False
        Me.RadioButton_diagnostic_5521.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5521.Checked = False
        Me.RadioButton_diagnostic_5521.Code = Nothing
        Me.RadioButton_diagnostic_5521.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5521.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5521.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5521.Libelle = "5.5.2.1 - Non fonctionnel"
        Me.RadioButton_diagnostic_5521.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5521.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_5521.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5521.Name = "RadioButton_diagnostic_5521"
        Me.RadioButton_diagnostic_5521.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5521.Size = New System.Drawing.Size(295, 16)
        Me.RadioButton_diagnostic_5521.TabIndex = 5
        '
        'RadioButton_diagnostic_5520
        '
        Me.RadioButton_diagnostic_5520.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5520.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5520.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5520.cause1 = False
        Me.RadioButton_diagnostic_5520.cause2 = False
        Me.RadioButton_diagnostic_5520.cause3 = False
        Me.RadioButton_diagnostic_5520.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5520.Checked = False
        Me.RadioButton_diagnostic_5520.Code = Nothing
        Me.RadioButton_diagnostic_5520.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5520.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5520.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5520.Libelle = "OK"
        Me.RadioButton_diagnostic_5520.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5520.Location = New System.Drawing.Point(8, 88)
        Me.RadioButton_diagnostic_5520.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5520.Name = "RadioButton_diagnostic_5520"
        Me.RadioButton_diagnostic_5520.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5520.Size = New System.Drawing.Size(295, 16)
        Me.RadioButton_diagnostic_5520.TabIndex = 7
        '
        'RadioButton_diagnostic_5522
        '
        Me.RadioButton_diagnostic_5522.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5522.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5522.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5522.cause1 = False
        Me.RadioButton_diagnostic_5522.cause2 = False
        Me.RadioButton_diagnostic_5522.cause3 = False
        Me.RadioButton_diagnostic_5522.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5522.Checked = False
        Me.RadioButton_diagnostic_5522.Code = Nothing
        Me.RadioButton_diagnostic_5522.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5522.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5522.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5522.Libelle = "5.5.2.2 - Imprécision"
        Me.RadioButton_diagnostic_5522.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5522.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5522.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5522.Name = "RadioButton_diagnostic_5522"
        Me.RadioButton_diagnostic_5522.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5522.Size = New System.Drawing.Size(295, 16)
        Me.RadioButton_diagnostic_5522.TabIndex = 8
        '
        'ico_help_552
        '
        Me.ico_help_552.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ico_help_552.BackColor = System.Drawing.Color.Transparent
        Me.ico_help_552.Image = CType(resources.GetObject("ico_help_552.Image"), System.Drawing.Image)
        Me.ico_help_552.Location = New System.Drawing.Point(279, 8)
        Me.ico_help_552.Name = "ico_help_552"
        Me.ico_help_552.Size = New System.Drawing.Size(29, 29)
        Me.ico_help_552.TabIndex = 6
        Me.ico_help_552.TabStop = False
        '
        'Pctb_calc
        '
        Me.Pctb_calc.Image = CType(resources.GetObject("Pctb_calc.Image"), System.Drawing.Image)
        Me.Pctb_calc.Location = New System.Drawing.Point(8, 16)
        Me.Pctb_calc.Name = "Pctb_calc"
        Me.Pctb_calc.Size = New System.Drawing.Size(24, 24)
        Me.Pctb_calc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pctb_calc.TabIndex = 9
        Me.Pctb_calc.TabStop = False
        Me.ToolTip_diagnostic_numRadioButtons.SetToolTip(Me.Pctb_calc, "Outil de conversion des l/ha")
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel22.Controls.Add(Me.GroupBox_diagnostic_522)
        Me.Panel22.Controls.Add(Me.GroupBox_diagnostic_521)
        Me.Panel22.Controls.Add(Me.Label_diagnostic_52)
        Me.Panel22.Location = New System.Drawing.Point(233, 152)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(399, 167)
        Me.Panel22.TabIndex = 6
        '
        'Label_diagnostic_52
        '
        Me.Label_diagnostic_52.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_52.Image = CType(resources.GetObject("Label_diagnostic_52.Image"), System.Drawing.Image)
        Me.Label_diagnostic_52.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_52.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_52.Name = "Label_diagnostic_52"
        Me.Label_diagnostic_52.Size = New System.Drawing.Size(384, 44)
        Me.Label_diagnostic_52.TabIndex = 12
        Me.Label_diagnostic_52.Text = "     Fermeture partielle de la pulvérisation au niveau des sections"
        '
        'GroupBox_diagnostic_521
        '
        Me.GroupBox_diagnostic_521.Controls.Add(Me.RadioButton_diagnostic_5210)
        Me.GroupBox_diagnostic_521.Controls.Add(Me.RadioButton_diagnostic_5212)
        Me.GroupBox_diagnostic_521.Controls.Add(Me.RadioButton_diagnostic_5211)
        Me.GroupBox_diagnostic_521.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_521.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_521.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox_diagnostic_521.Name = "GroupBox_diagnostic_521"
        Me.GroupBox_diagnostic_521.Size = New System.Drawing.Size(160, 96)
        Me.GroupBox_diagnostic_521.TabIndex = 5
        Me.GroupBox_diagnostic_521.TabStop = False
        Me.GroupBox_diagnostic_521.Text = "5.2.1 - Etat"
        '
        'RadioButton_diagnostic_5211
        '
        Me.RadioButton_diagnostic_5211.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5211.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5211.cause1 = False
        Me.RadioButton_diagnostic_5211.cause2 = False
        Me.RadioButton_diagnostic_5211.cause3 = False
        Me.RadioButton_diagnostic_5211.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5211.Checked = False
        Me.RadioButton_diagnostic_5211.Code = Nothing
        Me.RadioButton_diagnostic_5211.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5211.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5211.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5211.Libelle = "5.2.1.1 - Absence"
        Me.RadioButton_diagnostic_5211.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5211.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_5211.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5211.Name = "RadioButton_diagnostic_5211"
        Me.RadioButton_diagnostic_5211.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5211.Size = New System.Drawing.Size(144, 16)
        Me.RadioButton_diagnostic_5211.TabIndex = 4
        '
        'RadioButton_diagnostic_5212
        '
        Me.RadioButton_diagnostic_5212.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5212.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5212.cause1 = False
        Me.RadioButton_diagnostic_5212.cause2 = False
        Me.RadioButton_diagnostic_5212.cause3 = False
        Me.RadioButton_diagnostic_5212.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5212.Checked = False
        Me.RadioButton_diagnostic_5212.Code = Nothing
        Me.RadioButton_diagnostic_5212.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5212.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5212.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5212.Libelle = "5.2.1.2 - Non foncti."
        Me.RadioButton_diagnostic_5212.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5212.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_5212.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5212.Name = "RadioButton_diagnostic_5212"
        Me.RadioButton_diagnostic_5212.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5212.Size = New System.Drawing.Size(144, 16)
        Me.RadioButton_diagnostic_5212.TabIndex = 5
        '
        'RadioButton_diagnostic_5210
        '
        Me.RadioButton_diagnostic_5210.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5210.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5210.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5210.cause1 = False
        Me.RadioButton_diagnostic_5210.cause2 = False
        Me.RadioButton_diagnostic_5210.cause3 = False
        Me.RadioButton_diagnostic_5210.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5210.Checked = False
        Me.RadioButton_diagnostic_5210.Code = Nothing
        Me.RadioButton_diagnostic_5210.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5210.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5210.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5210.Libelle = "OK"
        Me.RadioButton_diagnostic_5210.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5210.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5210.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5210.Name = "RadioButton_diagnostic_5210"
        Me.RadioButton_diagnostic_5210.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5210.Size = New System.Drawing.Size(144, 16)
        Me.RadioButton_diagnostic_5210.TabIndex = 7
        '
        'GroupBox_diagnostic_522
        '
        Me.GroupBox_diagnostic_522.Controls.Add(Me.RadioButton_diagnostic_5223)
        Me.GroupBox_diagnostic_522.Controls.Add(Me.RadioButton_diagnostic_5220)
        Me.GroupBox_diagnostic_522.Controls.Add(Me.RadioButton_diagnostic_5222)
        Me.GroupBox_diagnostic_522.Controls.Add(Me.RadioButton_diagnostic_5221)
        Me.GroupBox_diagnostic_522.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_522.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_522.Location = New System.Drawing.Point(184, 48)
        Me.GroupBox_diagnostic_522.Name = "GroupBox_diagnostic_522"
        Me.GroupBox_diagnostic_522.Size = New System.Drawing.Size(200, 96)
        Me.GroupBox_diagnostic_522.TabIndex = 6
        Me.GroupBox_diagnostic_522.TabStop = False
        Me.GroupBox_diagnostic_522.Text = "5.2.2 - Retours compensatoires"
        '
        'RadioButton_diagnostic_5221
        '
        Me.RadioButton_diagnostic_5221.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5221.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5221.cause1 = False
        Me.RadioButton_diagnostic_5221.cause2 = False
        Me.RadioButton_diagnostic_5221.cause3 = False
        Me.RadioButton_diagnostic_5221.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5221.Checked = False
        Me.RadioButton_diagnostic_5221.Code = Nothing
        Me.RadioButton_diagnostic_5221.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5221.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5221.Libelle = "5.2.2.1 - Absence"
        Me.RadioButton_diagnostic_5221.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5221.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_5221.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5221.Name = "RadioButton_diagnostic_5221"
        Me.RadioButton_diagnostic_5221.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5221.Size = New System.Drawing.Size(184, 16)
        Me.RadioButton_diagnostic_5221.TabIndex = 4
        '
        'RadioButton_diagnostic_5222
        '
        Me.RadioButton_diagnostic_5222.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5222.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5222.cause1 = False
        Me.RadioButton_diagnostic_5222.cause2 = False
        Me.RadioButton_diagnostic_5222.cause3 = False
        Me.RadioButton_diagnostic_5222.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5222.Checked = False
        Me.RadioButton_diagnostic_5222.Code = Nothing
        Me.RadioButton_diagnostic_5222.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5222.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5222.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5222.Libelle = "5.2.2.2 - Non fonctionnel"
        Me.RadioButton_diagnostic_5222.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5222.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_5222.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5222.Name = "RadioButton_diagnostic_5222"
        Me.RadioButton_diagnostic_5222.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5222.Size = New System.Drawing.Size(184, 16)
        Me.RadioButton_diagnostic_5222.TabIndex = 5
        '
        'RadioButton_diagnostic_5220
        '
        Me.RadioButton_diagnostic_5220.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5220.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5220.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5220.cause1 = False
        Me.RadioButton_diagnostic_5220.cause2 = False
        Me.RadioButton_diagnostic_5220.cause3 = False
        Me.RadioButton_diagnostic_5220.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5220.Checked = False
        Me.RadioButton_diagnostic_5220.Code = Nothing
        Me.RadioButton_diagnostic_5220.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5220.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5220.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5220.Libelle = "OK"
        Me.RadioButton_diagnostic_5220.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5220.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5220.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5220.Name = "RadioButton_diagnostic_5220"
        Me.RadioButton_diagnostic_5220.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5220.Size = New System.Drawing.Size(184, 16)
        Me.RadioButton_diagnostic_5220.TabIndex = 7
        '
        'RadioButton_diagnostic_5223
        '
        Me.RadioButton_diagnostic_5223.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5223.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5223.cause1 = False
        Me.RadioButton_diagnostic_5223.cause2 = False
        Me.RadioButton_diagnostic_5223.cause3 = False
        Me.RadioButton_diagnostic_5223.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5223.Checked = False
        Me.RadioButton_diagnostic_5223.Code = Nothing
        Me.RadioButton_diagnostic_5223.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5223.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5223.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5223.Libelle = "5.2.2.3 - Mauvais équilibre"
        Me.RadioButton_diagnostic_5223.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5223.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_5223.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5223.Name = "RadioButton_diagnostic_5223"
        Me.RadioButton_diagnostic_5223.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5223.Size = New System.Drawing.Size(184, 16)
        Me.RadioButton_diagnostic_5223.TabIndex = 8
        '
        'Panel23
        '
        Me.Panel23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel23.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel23.Controls.Add(Me.GroupBox_diagnostic_532)
        Me.Panel23.Controls.Add(Me.GroupBox_diagnostic_531)
        Me.Panel23.Controls.Add(Me.Label_diagnostic_53)
        Me.Panel23.Location = New System.Drawing.Point(633, 152)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(379, 167)
        Me.Panel23.TabIndex = 7
        '
        'Label_diagnostic_53
        '
        Me.Label_diagnostic_53.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_53.Image = CType(resources.GetObject("Label_diagnostic_53.Image"), System.Drawing.Image)
        Me.Label_diagnostic_53.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_53.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_53.Name = "Label_diagnostic_53"
        Me.Label_diagnostic_53.Size = New System.Drawing.Size(360, 37)
        Me.Label_diagnostic_53.TabIndex = 12
        Me.Label_diagnostic_53.Text = "     Dispositif(s) de régulation de la pression"
        '
        'GroupBox_diagnostic_531
        '
        Me.GroupBox_diagnostic_531.Controls.Add(Me.RadioButton_diagnostic_5310)
        Me.GroupBox_diagnostic_531.Controls.Add(Me.RadioButton_diagnostic_5312)
        Me.GroupBox_diagnostic_531.Controls.Add(Me.RadioButton_diagnostic_5311)
        Me.GroupBox_diagnostic_531.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_531.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_531.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox_diagnostic_531.Name = "GroupBox_diagnostic_531"
        Me.GroupBox_diagnostic_531.Size = New System.Drawing.Size(144, 96)
        Me.GroupBox_diagnostic_531.TabIndex = 5
        Me.GroupBox_diagnostic_531.TabStop = False
        Me.GroupBox_diagnostic_531.Text = "5.3.1 - Etat"
        '
        'RadioButton_diagnostic_5311
        '
        Me.RadioButton_diagnostic_5311.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5311.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5311.cause1 = False
        Me.RadioButton_diagnostic_5311.cause2 = False
        Me.RadioButton_diagnostic_5311.cause3 = False
        Me.RadioButton_diagnostic_5311.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5311.Checked = False
        Me.RadioButton_diagnostic_5311.Code = Nothing
        Me.RadioButton_diagnostic_5311.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5311.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5311.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5311.Libelle = "5.3.1.1 - Absence"
        Me.RadioButton_diagnostic_5311.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5311.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_5311.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5311.Name = "RadioButton_diagnostic_5311"
        Me.RadioButton_diagnostic_5311.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5311.Size = New System.Drawing.Size(128, 16)
        Me.RadioButton_diagnostic_5311.TabIndex = 4
        '
        'RadioButton_diagnostic_5312
        '
        Me.RadioButton_diagnostic_5312.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5312.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5312.cause1 = False
        Me.RadioButton_diagnostic_5312.cause2 = False
        Me.RadioButton_diagnostic_5312.cause3 = False
        Me.RadioButton_diagnostic_5312.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5312.Checked = False
        Me.RadioButton_diagnostic_5312.Code = Nothing
        Me.RadioButton_diagnostic_5312.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5312.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5312.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5312.Libelle = "5.3.1.2 - Non foncti."
        Me.RadioButton_diagnostic_5312.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5312.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_5312.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5312.Name = "RadioButton_diagnostic_5312"
        Me.RadioButton_diagnostic_5312.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5312.Size = New System.Drawing.Size(128, 16)
        Me.RadioButton_diagnostic_5312.TabIndex = 5
        '
        'RadioButton_diagnostic_5310
        '
        Me.RadioButton_diagnostic_5310.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5310.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5310.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5310.cause1 = False
        Me.RadioButton_diagnostic_5310.cause2 = False
        Me.RadioButton_diagnostic_5310.cause3 = False
        Me.RadioButton_diagnostic_5310.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5310.Checked = False
        Me.RadioButton_diagnostic_5310.Code = Nothing
        Me.RadioButton_diagnostic_5310.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5310.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5310.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5310.Libelle = "OK"
        Me.RadioButton_diagnostic_5310.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5310.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5310.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5310.Name = "RadioButton_diagnostic_5310"
        Me.RadioButton_diagnostic_5310.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5310.Size = New System.Drawing.Size(128, 16)
        Me.RadioButton_diagnostic_5310.TabIndex = 7
        '
        'GroupBox_diagnostic_532
        '
        Me.GroupBox_diagnostic_532.Controls.Add(Me.RadioButton_diagnostic_5323)
        Me.GroupBox_diagnostic_532.Controls.Add(Me.RadioButton_diagnostic_5320)
        Me.GroupBox_diagnostic_532.Controls.Add(Me.RadioButton_diagnostic_5322)
        Me.GroupBox_diagnostic_532.Controls.Add(Me.RadioButton_diagnostic_5321)
        Me.GroupBox_diagnostic_532.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_532.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_532.Location = New System.Drawing.Point(160, 48)
        Me.GroupBox_diagnostic_532.Name = "GroupBox_diagnostic_532"
        Me.GroupBox_diagnostic_532.Size = New System.Drawing.Size(208, 96)
        Me.GroupBox_diagnostic_532.TabIndex = 6
        Me.GroupBox_diagnostic_532.TabStop = False
        Me.GroupBox_diagnostic_532.Text = "5.3.2 - Fonctionnement"
        '
        'RadioButton_diagnostic_5321
        '
        Me.RadioButton_diagnostic_5321.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5321.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5321.cause1 = False
        Me.RadioButton_diagnostic_5321.cause2 = False
        Me.RadioButton_diagnostic_5321.cause3 = False
        Me.RadioButton_diagnostic_5321.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5321.Checked = False
        Me.RadioButton_diagnostic_5321.Code = Nothing
        Me.RadioButton_diagnostic_5321.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5321.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5321.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5321.Libelle = "5.3.2.1 - Faible instab. pression"
        Me.RadioButton_diagnostic_5321.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5321.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_5321.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5321.Name = "RadioButton_diagnostic_5321"
        Me.RadioButton_diagnostic_5321.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5321.Size = New System.Drawing.Size(192, 16)
        Me.RadioButton_diagnostic_5321.TabIndex = 4
        '
        'RadioButton_diagnostic_5322
        '
        Me.RadioButton_diagnostic_5322.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5322.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5322.cause1 = False
        Me.RadioButton_diagnostic_5322.cause2 = False
        Me.RadioButton_diagnostic_5322.cause3 = False
        Me.RadioButton_diagnostic_5322.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5322.Checked = False
        Me.RadioButton_diagnostic_5322.Code = Nothing
        Me.RadioButton_diagnostic_5322.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5322.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5322.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5322.Libelle = "5.3.2.2 - Forte instab. pression"
        Me.RadioButton_diagnostic_5322.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5322.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_5322.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5322.Name = "RadioButton_diagnostic_5322"
        Me.RadioButton_diagnostic_5322.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5322.Size = New System.Drawing.Size(192, 16)
        Me.RadioButton_diagnostic_5322.TabIndex = 5
        '
        'RadioButton_diagnostic_5320
        '
        Me.RadioButton_diagnostic_5320.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5320.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5320.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5320.cause1 = False
        Me.RadioButton_diagnostic_5320.cause2 = False
        Me.RadioButton_diagnostic_5320.cause3 = False
        Me.RadioButton_diagnostic_5320.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5320.Checked = False
        Me.RadioButton_diagnostic_5320.Code = Nothing
        Me.RadioButton_diagnostic_5320.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5320.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5320.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5320.Libelle = "OK"
        Me.RadioButton_diagnostic_5320.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5320.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5320.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5320.Name = "RadioButton_diagnostic_5320"
        Me.RadioButton_diagnostic_5320.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5320.Size = New System.Drawing.Size(192, 16)
        Me.RadioButton_diagnostic_5320.TabIndex = 7
        '
        'RadioButton_diagnostic_5323
        '
        Me.RadioButton_diagnostic_5323.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5323.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5323.cause1 = False
        Me.RadioButton_diagnostic_5323.cause2 = False
        Me.RadioButton_diagnostic_5323.cause3 = False
        Me.RadioButton_diagnostic_5323.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5323.Checked = False
        Me.RadioButton_diagnostic_5323.Code = Nothing
        Me.RadioButton_diagnostic_5323.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5323.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5323.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5323.Libelle = "5.3.2.3 - Non retour à la P initiale"
        Me.RadioButton_diagnostic_5323.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5323.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_5323.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5323.Name = "RadioButton_diagnostic_5323"
        Me.RadioButton_diagnostic_5323.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5323.Size = New System.Drawing.Size(192, 16)
        Me.RadioButton_diagnostic_5323.TabIndex = 8
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel21.Controls.Add(Me.GroupBox_diagnostic_511)
        Me.Panel21.Controls.Add(Me.Label_diagnostic_51)
        Me.Panel21.Location = New System.Drawing.Point(0, 152)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(232, 167)
        Me.Panel21.TabIndex = 5
        '
        'Label_diagnostic_51
        '
        Me.Label_diagnostic_51.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_51.Image = CType(resources.GetObject("Label_diagnostic_51.Image"), System.Drawing.Image)
        Me.Label_diagnostic_51.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_51.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_51.Name = "Label_diagnostic_51"
        Me.Label_diagnostic_51.Size = New System.Drawing.Size(216, 39)
        Me.Label_diagnostic_51.TabIndex = 12
        Me.Label_diagnostic_51.Text = "     Fermeture générale de la pulvérisation"
        '
        'GroupBox_diagnostic_511
        '
        Me.GroupBox_diagnostic_511.Controls.Add(Me.RadioButton_diagnostic_5110)
        Me.GroupBox_diagnostic_511.Controls.Add(Me.RadioButton_diagnostic_5112)
        Me.GroupBox_diagnostic_511.Controls.Add(Me.RadioButton_diagnostic_5111)
        Me.GroupBox_diagnostic_511.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_511.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_511.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox_diagnostic_511.Name = "GroupBox_diagnostic_511"
        Me.GroupBox_diagnostic_511.Size = New System.Drawing.Size(208, 96)
        Me.GroupBox_diagnostic_511.TabIndex = 5
        Me.GroupBox_diagnostic_511.TabStop = False
        Me.GroupBox_diagnostic_511.Text = "5.1.1 - Etat"
        '
        'RadioButton_diagnostic_5111
        '
        Me.RadioButton_diagnostic_5111.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5111.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5111.cause1 = False
        Me.RadioButton_diagnostic_5111.cause2 = False
        Me.RadioButton_diagnostic_5111.cause3 = False
        Me.RadioButton_diagnostic_5111.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5111.Checked = False
        Me.RadioButton_diagnostic_5111.Code = Nothing
        Me.RadioButton_diagnostic_5111.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5111.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5111.Libelle = "5.1.1.1 - Absence"
        Me.RadioButton_diagnostic_5111.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5111.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_5111.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5111.Name = "RadioButton_diagnostic_5111"
        Me.RadioButton_diagnostic_5111.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5111.Size = New System.Drawing.Size(192, 16)
        Me.RadioButton_diagnostic_5111.TabIndex = 4
        '
        'RadioButton_diagnostic_5112
        '
        Me.RadioButton_diagnostic_5112.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5112.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5112.cause1 = False
        Me.RadioButton_diagnostic_5112.cause2 = False
        Me.RadioButton_diagnostic_5112.cause3 = False
        Me.RadioButton_diagnostic_5112.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5112.Checked = False
        Me.RadioButton_diagnostic_5112.Code = Nothing
        Me.RadioButton_diagnostic_5112.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5112.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5112.Libelle = "5.1.1.2 - Non fonctionnel"
        Me.RadioButton_diagnostic_5112.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5112.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_5112.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5112.Name = "RadioButton_diagnostic_5112"
        Me.RadioButton_diagnostic_5112.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5112.Size = New System.Drawing.Size(192, 16)
        Me.RadioButton_diagnostic_5112.TabIndex = 5
        '
        'RadioButton_diagnostic_5110
        '
        Me.RadioButton_diagnostic_5110.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5110.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5110.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5110.cause1 = False
        Me.RadioButton_diagnostic_5110.cause2 = False
        Me.RadioButton_diagnostic_5110.cause3 = False
        Me.RadioButton_diagnostic_5110.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5110.Checked = False
        Me.RadioButton_diagnostic_5110.Code = Nothing
        Me.RadioButton_diagnostic_5110.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5110.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5110.Libelle = "OK"
        Me.RadioButton_diagnostic_5110.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5110.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5110.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5110.Name = "RadioButton_diagnostic_5110"
        Me.RadioButton_diagnostic_5110.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5110.Size = New System.Drawing.Size(192, 16)
        Me.RadioButton_diagnostic_5110.TabIndex = 7
        '
        'Panel24
        '
        Me.Panel24.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel24.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel24.Controls.Add(Me.GroupBox_diagnostic_542)
        Me.Panel24.Controls.Add(Me.GroupBox_diagnostic_541)
        Me.Panel24.Controls.Add(Me.Label_diagnostic_54)
        Me.Panel24.Location = New System.Drawing.Point(0, 320)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(376, 333)
        Me.Panel24.TabIndex = 8
        '
        'Label_diagnostic_54
        '
        Me.Label_diagnostic_54.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_54.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_54.Image = CType(resources.GetObject("Label_diagnostic_54.Image"), System.Drawing.Image)
        Me.Label_diagnostic_54.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_54.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_54.Name = "Label_diagnostic_54"
        Me.Label_diagnostic_54.Size = New System.Drawing.Size(360, 16)
        Me.Label_diagnostic_54.TabIndex = 12
        Me.Label_diagnostic_54.Text = "     Indicateur de pression"
        '
        'GroupBox_diagnostic_541
        '
        Me.GroupBox_diagnostic_541.Controls.Add(Me.RadioButton_diagnostic_5414)
        Me.GroupBox_diagnostic_541.Controls.Add(Me.RadioButton_diagnostic_5413)
        Me.GroupBox_diagnostic_541.Controls.Add(Me.RadioButton_diagnostic_5410)
        Me.GroupBox_diagnostic_541.Controls.Add(Me.RadioButton_diagnostic_5412)
        Me.GroupBox_diagnostic_541.Controls.Add(Me.RadioButton_diagnostic_5411)
        Me.GroupBox_diagnostic_541.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_541.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_541.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox_diagnostic_541.Name = "GroupBox_diagnostic_541"
        Me.GroupBox_diagnostic_541.Size = New System.Drawing.Size(360, 120)
        Me.GroupBox_diagnostic_541.TabIndex = 5
        Me.GroupBox_diagnostic_541.TabStop = False
        Me.GroupBox_diagnostic_541.Text = "5.4.1 - Etat"
        '
        'RadioButton_diagnostic_5411
        '
        Me.RadioButton_diagnostic_5411.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5411.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5411.cause1 = False
        Me.RadioButton_diagnostic_5411.cause2 = False
        Me.RadioButton_diagnostic_5411.cause3 = False
        Me.RadioButton_diagnostic_5411.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5411.Checked = False
        Me.RadioButton_diagnostic_5411.Code = Nothing
        Me.RadioButton_diagnostic_5411.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5411.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5411.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5411.Libelle = "5.4.1.1 - Absence"
        Me.RadioButton_diagnostic_5411.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5411.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_5411.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5411.Name = "RadioButton_diagnostic_5411"
        Me.RadioButton_diagnostic_5411.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5411.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5411.TabIndex = 4
        '
        'RadioButton_diagnostic_5412
        '
        Me.RadioButton_diagnostic_5412.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5412.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5412.cause1 = False
        Me.RadioButton_diagnostic_5412.cause2 = False
        Me.RadioButton_diagnostic_5412.cause3 = False
        Me.RadioButton_diagnostic_5412.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5412.Checked = False
        Me.RadioButton_diagnostic_5412.Code = Nothing
        Me.RadioButton_diagnostic_5412.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5412.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5412.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5412.Libelle = "5.4.1.2 - Mauvaise lisibilité"
        Me.RadioButton_diagnostic_5412.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5412.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_5412.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5412.Name = "RadioButton_diagnostic_5412"
        Me.RadioButton_diagnostic_5412.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5412.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5412.TabIndex = 5
        '
        'RadioButton_diagnostic_5410
        '
        Me.RadioButton_diagnostic_5410.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5410.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5410.cause1 = False
        Me.RadioButton_diagnostic_5410.cause2 = False
        Me.RadioButton_diagnostic_5410.cause3 = False
        Me.RadioButton_diagnostic_5410.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5410.Checked = False
        Me.RadioButton_diagnostic_5410.Code = Nothing
        Me.RadioButton_diagnostic_5410.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5410.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5410.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5410.Libelle = "OK"
        Me.RadioButton_diagnostic_5410.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5410.Location = New System.Drawing.Point(8, 88)
        Me.RadioButton_diagnostic_5410.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5410.Name = "RadioButton_diagnostic_5410"
        Me.RadioButton_diagnostic_5410.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5410.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5410.TabIndex = 7
        '
        'RadioButton_diagnostic_5413
        '
        Me.RadioButton_diagnostic_5413.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5413.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5413.cause1 = False
        Me.RadioButton_diagnostic_5413.cause2 = False
        Me.RadioButton_diagnostic_5413.cause3 = False
        Me.RadioButton_diagnostic_5413.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5413.Checked = False
        Me.RadioButton_diagnostic_5413.Code = Nothing
        Me.RadioButton_diagnostic_5413.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5413.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5413.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5413.Libelle = "5.4.1.3 - Plage mesure inadaptée"
        Me.RadioButton_diagnostic_5413.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5413.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_5413.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5413.Name = "RadioButton_diagnostic_5413"
        Me.RadioButton_diagnostic_5413.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5413.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5413.TabIndex = 8
        '
        'RadioButton_diagnostic_5414
        '
        Me.RadioButton_diagnostic_5414.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5414.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5414.cause1 = False
        Me.RadioButton_diagnostic_5414.cause2 = False
        Me.RadioButton_diagnostic_5414.cause3 = False
        Me.RadioButton_diagnostic_5414.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5414.Checked = False
        Me.RadioButton_diagnostic_5414.Code = Nothing
        Me.RadioButton_diagnostic_5414.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5414.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5414.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5414.Libelle = "5.4.1.4 - Graduation inadaptées"
        Me.RadioButton_diagnostic_5414.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5414.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5414.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5414.Name = "RadioButton_diagnostic_5414"
        Me.RadioButton_diagnostic_5414.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5414.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5414.TabIndex = 9
        '
        'GroupBox_diagnostic_542
        '
        Me.GroupBox_diagnostic_542.Controls.Add(Me.RadioButton_diagnostic_5423)
        Me.GroupBox_diagnostic_542.Controls.Add(Me.RadioButton_diagnostic_5420)
        Me.GroupBox_diagnostic_542.Controls.Add(Me.RadioButton_diagnostic_5421)
        Me.GroupBox_diagnostic_542.Controls.Add(Me.RadioButton_diagnostic_5422)
        Me.GroupBox_diagnostic_542.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_542.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_542.Location = New System.Drawing.Point(8, 168)
        Me.GroupBox_diagnostic_542.Name = "GroupBox_diagnostic_542"
        Me.GroupBox_diagnostic_542.Size = New System.Drawing.Size(360, 96)
        Me.GroupBox_diagnostic_542.TabIndex = 6
        Me.GroupBox_diagnostic_542.TabStop = False
        Me.GroupBox_diagnostic_542.Text = "5.4.2 - Fonctionnement"
        '
        'RadioButton_diagnostic_5422
        '
        Me.RadioButton_diagnostic_5422.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5422.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5422.cause1 = False
        Me.RadioButton_diagnostic_5422.cause2 = False
        Me.RadioButton_diagnostic_5422.cause3 = False
        Me.RadioButton_diagnostic_5422.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5422.Checked = False
        Me.RadioButton_diagnostic_5422.Code = Nothing
        Me.RadioButton_diagnostic_5422.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5422.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5422.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5422.Libelle = "5.4.2.2 - Imprécision faible"
        Me.RadioButton_diagnostic_5422.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5422.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton_diagnostic_5422.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5422.Name = "RadioButton_diagnostic_5422"
        Me.RadioButton_diagnostic_5422.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5422.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5422.TabIndex = 4
        '
        'RadioButton_diagnostic_5421
        '
        Me.RadioButton_diagnostic_5421.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5421.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5421.cause1 = False
        Me.RadioButton_diagnostic_5421.cause2 = False
        Me.RadioButton_diagnostic_5421.cause3 = False
        Me.RadioButton_diagnostic_5421.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5421.Checked = False
        Me.RadioButton_diagnostic_5421.Code = Nothing
        Me.RadioButton_diagnostic_5421.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5421.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5421.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5421.Libelle = "5.4.2.1 - Non fonctionnel"
        Me.RadioButton_diagnostic_5421.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5421.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton_diagnostic_5421.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5421.Name = "RadioButton_diagnostic_5421"
        Me.RadioButton_diagnostic_5421.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5421.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5421.TabIndex = 5
        '
        'RadioButton_diagnostic_5420
        '
        Me.RadioButton_diagnostic_5420.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5420.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5420.cause1 = False
        Me.RadioButton_diagnostic_5420.cause2 = False
        Me.RadioButton_diagnostic_5420.cause3 = False
        Me.RadioButton_diagnostic_5420.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5420.Checked = False
        Me.RadioButton_diagnostic_5420.Code = Nothing
        Me.RadioButton_diagnostic_5420.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5420.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5420.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5420.Libelle = "OK"
        Me.RadioButton_diagnostic_5420.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5420.Location = New System.Drawing.Point(8, 72)
        Me.RadioButton_diagnostic_5420.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5420.Name = "RadioButton_diagnostic_5420"
        Me.RadioButton_diagnostic_5420.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5420.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5420.TabIndex = 7
        '
        'RadioButton_diagnostic_5423
        '
        Me.RadioButton_diagnostic_5423.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5423.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5423.cause1 = False
        Me.RadioButton_diagnostic_5423.cause2 = False
        Me.RadioButton_diagnostic_5423.cause3 = False
        Me.RadioButton_diagnostic_5423.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5423.Checked = False
        Me.RadioButton_diagnostic_5423.Code = Nothing
        Me.RadioButton_diagnostic_5423.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
        Me.RadioButton_diagnostic_5423.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5423.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5423.Libelle = "5.4.2.3 - Imprécision importante"
        Me.RadioButton_diagnostic_5423.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5423.Location = New System.Drawing.Point(8, 56)
        Me.RadioButton_diagnostic_5423.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5423.Name = "RadioButton_diagnostic_5423"
        Me.RadioButton_diagnostic_5423.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5423.Size = New System.Drawing.Size(344, 16)
        Me.RadioButton_diagnostic_5423.TabIndex = 8
        '
        'Panel26
        '
        Me.Panel26.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel26.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel26.Controls.Add(Me.Label_diagnostic_57)
        Me.Panel26.Controls.Add(Me.GroupBox_diagnostic_571)
        Me.Panel26.Controls.Add(Me.GroupBox_diagnostic_562)
        Me.Panel26.Controls.Add(Me.GroupBox_diagnostic_561)
        Me.Panel26.Controls.Add(Me.Label_diagnostic_56)
        Me.Panel26.Location = New System.Drawing.Point(702, 320)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(306, 333)
        Me.Panel26.TabIndex = 10
        '
        'Label_diagnostic_56
        '
        Me.Label_diagnostic_56.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_56.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_56.Image = CType(resources.GetObject("Label_diagnostic_56.Image"), System.Drawing.Image)
        Me.Label_diagnostic_56.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_56.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_56.Name = "Label_diagnostic_56"
        Me.Label_diagnostic_56.Size = New System.Drawing.Size(196, 16)
        Me.Label_diagnostic_56.TabIndex = 12
        Me.Label_diagnostic_56.Text = "     Autres indicateurs"
        '
        'GroupBox_diagnostic_561
        '
        Me.GroupBox_diagnostic_561.Controls.Add(Me.RadioButton_diagnostic_5612)
        Me.GroupBox_diagnostic_561.Controls.Add(Me.RadioButton_diagnostic_5610)
        Me.GroupBox_diagnostic_561.Controls.Add(Me.RadioButton_diagnostic_5611)
        Me.GroupBox_diagnostic_561.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_561.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_561.Location = New System.Drawing.Point(8, 27)
        Me.GroupBox_diagnostic_561.Name = "GroupBox_diagnostic_561"
        Me.GroupBox_diagnostic_561.Size = New System.Drawing.Size(291, 67)
        Me.GroupBox_diagnostic_561.TabIndex = 5
        Me.GroupBox_diagnostic_561.TabStop = False
        Me.GroupBox_diagnostic_561.Text = "5.6.1 - Etat"
        '
        'RadioButton_diagnostic_5611
        '
        Me.RadioButton_diagnostic_5611.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5611.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5611.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5611.cause1 = False
        Me.RadioButton_diagnostic_5611.cause2 = False
        Me.RadioButton_diagnostic_5611.cause3 = False
        Me.RadioButton_diagnostic_5611.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5611.Checked = False
        Me.RadioButton_diagnostic_5611.Code = Nothing
        Me.RadioButton_diagnostic_5611.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5611.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5611.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5611.Libelle = "5.6.1.1 - Non fonctionnel"
        Me.RadioButton_diagnostic_5611.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5611.Location = New System.Drawing.Point(8, 15)
        Me.RadioButton_diagnostic_5611.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5611.Name = "RadioButton_diagnostic_5611"
        Me.RadioButton_diagnostic_5611.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5611.Size = New System.Drawing.Size(275, 16)
        Me.RadioButton_diagnostic_5611.TabIndex = 5
        '
        'RadioButton_diagnostic_5610
        '
        Me.RadioButton_diagnostic_5610.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5610.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5610.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5610.cause1 = False
        Me.RadioButton_diagnostic_5610.cause2 = False
        Me.RadioButton_diagnostic_5610.cause3 = False
        Me.RadioButton_diagnostic_5610.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5610.Checked = False
        Me.RadioButton_diagnostic_5610.Code = Nothing
        Me.RadioButton_diagnostic_5610.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5610.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5610.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5610.Libelle = "OK"
        Me.RadioButton_diagnostic_5610.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5610.Location = New System.Drawing.Point(8, 47)
        Me.RadioButton_diagnostic_5610.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5610.Name = "RadioButton_diagnostic_5610"
        Me.RadioButton_diagnostic_5610.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5610.Size = New System.Drawing.Size(275, 16)
        Me.RadioButton_diagnostic_5610.TabIndex = 7
        '
        'RadioButton_diagnostic_5612
        '
        Me.RadioButton_diagnostic_5612.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5612.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5612.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5612.cause1 = False
        Me.RadioButton_diagnostic_5612.cause2 = False
        Me.RadioButton_diagnostic_5612.cause3 = False
        Me.RadioButton_diagnostic_5612.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5612.Checked = False
        Me.RadioButton_diagnostic_5612.Code = Nothing
        Me.RadioButton_diagnostic_5612.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5612.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5612.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5612.Libelle = "5.6.1.2 - Mauvaise lisibilité"
        Me.RadioButton_diagnostic_5612.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5612.Location = New System.Drawing.Point(8, 31)
        Me.RadioButton_diagnostic_5612.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5612.Name = "RadioButton_diagnostic_5612"
        Me.RadioButton_diagnostic_5612.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5612.Size = New System.Drawing.Size(275, 16)
        Me.RadioButton_diagnostic_5612.TabIndex = 8
        '
        'GroupBox_diagnostic_562
        '
        Me.GroupBox_diagnostic_562.Controls.Add(Me.PictureBox2)
        Me.GroupBox_diagnostic_562.Controls.Add(Me.ico_help_5622)
        Me.GroupBox_diagnostic_562.Controls.Add(Me.ico_help_5621)
        Me.GroupBox_diagnostic_562.Controls.Add(Me.RadioButton_diagnostic_5622)
        Me.GroupBox_diagnostic_562.Controls.Add(Me.RadioButton_diagnostic_5620)
        Me.GroupBox_diagnostic_562.Controls.Add(Me.RadioButton_diagnostic_5621)
        Me.GroupBox_diagnostic_562.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_562.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_562.Location = New System.Drawing.Point(11, 99)
        Me.GroupBox_diagnostic_562.Name = "GroupBox_diagnostic_562"
        Me.GroupBox_diagnostic_562.Size = New System.Drawing.Size(287, 112)
        Me.GroupBox_diagnostic_562.TabIndex = 13
        Me.GroupBox_diagnostic_562.TabStop = False
        Me.GroupBox_diagnostic_562.Text = "5.6.2 - Fonctionnement"
        '
        'RadioButton_diagnostic_5621
        '
        Me.RadioButton_diagnostic_5621.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5621.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5621.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5621.cause1 = False
        Me.RadioButton_diagnostic_5621.cause2 = False
        Me.RadioButton_diagnostic_5621.cause3 = False
        Me.RadioButton_diagnostic_5621.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5621.Checked = False
        Me.RadioButton_diagnostic_5621.Code = Nothing
        Me.RadioButton_diagnostic_5621.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5621.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5621.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5621.Libelle = "5.6.2.1 - Imprecision vitesse"
        Me.RadioButton_diagnostic_5621.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5621.Location = New System.Drawing.Point(29, 42)
        Me.RadioButton_diagnostic_5621.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5621.Name = "RadioButton_diagnostic_5621"
        Me.RadioButton_diagnostic_5621.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5621.Size = New System.Drawing.Size(250, 16)
        Me.RadioButton_diagnostic_5621.TabIndex = 5
        '
        'RadioButton_diagnostic_5620
        '
        Me.RadioButton_diagnostic_5620.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5620.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5620.cause1 = False
        Me.RadioButton_diagnostic_5620.cause2 = False
        Me.RadioButton_diagnostic_5620.cause3 = False
        Me.RadioButton_diagnostic_5620.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5620.Checked = False
        Me.RadioButton_diagnostic_5620.Code = Nothing
        Me.RadioButton_diagnostic_5620.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5620.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5620.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5620.Libelle = "OK"
        Me.RadioButton_diagnostic_5620.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5620.Location = New System.Drawing.Point(32, 87)
        Me.RadioButton_diagnostic_5620.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5620.Name = "RadioButton_diagnostic_5620"
        Me.RadioButton_diagnostic_5620.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5620.Size = New System.Drawing.Size(247, 19)
        Me.RadioButton_diagnostic_5620.TabIndex = 7
        '
        'RadioButton_diagnostic_5622
        '
        Me.RadioButton_diagnostic_5622.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5622.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5622.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5622.cause1 = False
        Me.RadioButton_diagnostic_5622.cause2 = False
        Me.RadioButton_diagnostic_5622.cause3 = False
        Me.RadioButton_diagnostic_5622.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5622.Checked = False
        Me.RadioButton_diagnostic_5622.Code = Nothing
        Me.RadioButton_diagnostic_5622.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5622.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5622.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5622.Libelle = "5.6.2.2 - Imprecision débit"
        Me.RadioButton_diagnostic_5622.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5622.Location = New System.Drawing.Point(29, 64)
        Me.RadioButton_diagnostic_5622.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5622.Name = "RadioButton_diagnostic_5622"
        Me.RadioButton_diagnostic_5622.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5622.Size = New System.Drawing.Size(250, 16)
        Me.RadioButton_diagnostic_5622.TabIndex = 8
        '
        'ico_help_5621
        '
        Me.ico_help_5621.BackColor = System.Drawing.Color.Transparent
        Me.ico_help_5621.Image = CType(resources.GetObject("ico_help_5621.Image"), System.Drawing.Image)
        Me.ico_help_5621.Location = New System.Drawing.Point(3, 38)
        Me.ico_help_5621.Name = "ico_help_5621"
        Me.ico_help_5621.Size = New System.Drawing.Size(20, 20)
        Me.ico_help_5621.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ico_help_5621.TabIndex = 9
        Me.ico_help_5621.TabStop = False
        '
        'ico_help_5622
        '
        Me.ico_help_5622.BackColor = System.Drawing.Color.Transparent
        Me.ico_help_5622.Image = CType(resources.GetObject("ico_help_5622.Image"), System.Drawing.Image)
        Me.ico_help_5622.Location = New System.Drawing.Point(3, 62)
        Me.ico_help_5622.Name = "ico_help_5622"
        Me.ico_help_5622.Size = New System.Drawing.Size(20, 20)
        Me.ico_help_5622.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ico_help_5622.TabIndex = 10
        Me.ico_help_5622.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(254, 13)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        Me.ToolTip_diagnostic_numRadioButtons.SetToolTip(Me.PictureBox2, "Outil de conversion des l/ha")
        '
        'GroupBox_diagnostic_571
        '
        Me.GroupBox_diagnostic_571.Controls.Add(Me.ico_oeil571)
        Me.GroupBox_diagnostic_571.Controls.Add(Me.ico_help_571)
        Me.GroupBox_diagnostic_571.Controls.Add(Me.RadioButton_diagnostic_5712)
        Me.GroupBox_diagnostic_571.Controls.Add(Me.RadioButton_diagnostic_5710)
        Me.GroupBox_diagnostic_571.Controls.Add(Me.RadioButton_diagnostic_5711)
        Me.GroupBox_diagnostic_571.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_571.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_571.Location = New System.Drawing.Point(11, 239)
        Me.GroupBox_diagnostic_571.Name = "GroupBox_diagnostic_571"
        Me.GroupBox_diagnostic_571.Size = New System.Drawing.Size(288, 85)
        Me.GroupBox_diagnostic_571.TabIndex = 14
        Me.GroupBox_diagnostic_571.TabStop = False
        Me.GroupBox_diagnostic_571.Text = "5.7.1 - Intégration des erreurs individuelles"
        '
        'RadioButton_diagnostic_5711
        '
        Me.RadioButton_diagnostic_5711.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5711.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5711.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5711.cause1 = False
        Me.RadioButton_diagnostic_5711.cause2 = False
        Me.RadioButton_diagnostic_5711.cause3 = False
        Me.RadioButton_diagnostic_5711.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5711.Checked = False
        Me.RadioButton_diagnostic_5711.Code = Nothing
        Me.RadioButton_diagnostic_5711.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5711.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5711.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5711.Libelle = "5.7.1.1 - Imprécision faible"
        Me.RadioButton_diagnostic_5711.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5711.Location = New System.Drawing.Point(11, 34)
        Me.RadioButton_diagnostic_5711.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5711.Name = "RadioButton_diagnostic_5711"
        Me.RadioButton_diagnostic_5711.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5711.Size = New System.Drawing.Size(272, 16)
        Me.RadioButton_diagnostic_5711.TabIndex = 5
        '
        'RadioButton_diagnostic_5710
        '
        Me.RadioButton_diagnostic_5710.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5710.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5710.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5710.cause1 = False
        Me.RadioButton_diagnostic_5710.cause2 = False
        Me.RadioButton_diagnostic_5710.cause3 = False
        Me.RadioButton_diagnostic_5710.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5710.Checked = False
        Me.RadioButton_diagnostic_5710.Code = Nothing
        Me.RadioButton_diagnostic_5710.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_5710.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5710.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5710.Libelle = "OK"
        Me.RadioButton_diagnostic_5710.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5710.Location = New System.Drawing.Point(13, 66)
        Me.RadioButton_diagnostic_5710.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5710.Name = "RadioButton_diagnostic_5710"
        Me.RadioButton_diagnostic_5710.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5710.Size = New System.Drawing.Size(270, 16)
        Me.RadioButton_diagnostic_5710.TabIndex = 7
        '
        'RadioButton_diagnostic_5712
        '
        Me.RadioButton_diagnostic_5712.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_5712.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5712.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_5712.cause1 = False
        Me.RadioButton_diagnostic_5712.cause2 = False
        Me.RadioButton_diagnostic_5712.cause3 = False
        Me.RadioButton_diagnostic_5712.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5712.Checked = False
        Me.RadioButton_diagnostic_5712.Code = Nothing
        Me.RadioButton_diagnostic_5712.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_5712.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_5712.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_5712.Libelle = "5.7.1.2 - Imprécision importante"
        Me.RadioButton_diagnostic_5712.LibelleLong = Nothing
        Me.RadioButton_diagnostic_5712.Location = New System.Drawing.Point(11, 50)
        Me.RadioButton_diagnostic_5712.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_5712.Name = "RadioButton_diagnostic_5712"
        Me.RadioButton_diagnostic_5712.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_5712.Size = New System.Drawing.Size(272, 16)
        Me.RadioButton_diagnostic_5712.TabIndex = 8
        '
        'ico_help_571
        '
        Me.ico_help_571.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ico_help_571.BackColor = System.Drawing.Color.Transparent
        Me.ico_help_571.Image = CType(resources.GetObject("ico_help_571.Image"), System.Drawing.Image)
        Me.ico_help_571.Location = New System.Drawing.Point(199, 12)
        Me.ico_help_571.Name = "ico_help_571"
        Me.ico_help_571.Size = New System.Drawing.Size(29, 29)
        Me.ico_help_571.TabIndex = 9
        Me.ico_help_571.TabStop = False
        '
        'ico_oeil571
        '
        Me.ico_oeil571.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ico_oeil571.BackColor = System.Drawing.Color.Transparent
        Me.ico_oeil571.Image = CType(resources.GetObject("ico_oeil571.Image"), System.Drawing.Image)
        Me.ico_oeil571.Location = New System.Drawing.Point(234, 12)
        Me.ico_oeil571.Name = "ico_oeil571"
        Me.ico_oeil571.Size = New System.Drawing.Size(29, 29)
        Me.ico_oeil571.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ico_oeil571.TabIndex = 10
        Me.ico_oeil571.TabStop = False
        '
        'Label_diagnostic_57
        '
        Me.Label_diagnostic_57.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_57.Image = CType(resources.GetObject("Label_diagnostic_57.Image"), System.Drawing.Image)
        Me.Label_diagnostic_57.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_57.Location = New System.Drawing.Point(13, 217)
        Me.Label_diagnostic_57.Name = "Label_diagnostic_57"
        Me.Label_diagnostic_57.Size = New System.Drawing.Size(281, 23)
        Me.Label_diagnostic_57.TabIndex = 15
        Me.Label_diagnostic_57.Text = "   Réglage du volume par hectare"
        '
        'Panel127
        '
        Me.Panel127.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel127.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel127.Controls.Add(Me.Label_diagnostic_5)
        Me.Panel127.Location = New System.Drawing.Point(0, 112)
        Me.Panel127.Name = "Panel127"
        Me.Panel127.Size = New System.Drawing.Size(1008, 39)
        Me.Panel127.TabIndex = 20
        '
        'Label_diagnostic_5
        '
        Me.Label_diagnostic_5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_5.Image = CType(resources.GetObject("Label_diagnostic_5.Image"), System.Drawing.Image)
        Me.Label_diagnostic_5.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_5.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_5.Name = "Label_diagnostic_5"
        Me.Label_diagnostic_5.Size = New System.Drawing.Size(993, 24)
        Me.Label_diagnostic_5.TabIndex = 20
        Me.Label_diagnostic_5.Text = "     5. Appareillage de mesure, commande et systèmes de régulation"
        '
        'tab_diagnostique
        '
        Me.tab_diagnostique.Controls.Add(Me.tabPage_diagnostique_mesureCommandesRegulation)
        Me.tab_diagnostique.Controls.Add(Me.tabPage_diagnostique_rampes)
        Me.tab_diagnostique.Controls.Add(Me.tabPage_diagnostique_manoTroncon)
        Me.tab_diagnostique.Controls.Add(Me.tabPage_diagnostique_buses)
        Me.tab_diagnostique.Controls.Add(Me.tabPage_diagnostique_accessoires)
        Me.tab_diagnostique.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_diagnostique.ImageList = Me.listImg_flags
        Me.tab_diagnostique.Location = New System.Drawing.Point(0, 0)
        Me.tab_diagnostique.Name = "tab_diagnostique"
        Me.tab_diagnostique.SelectedIndex = 0
        Me.tab_diagnostique.Size = New System.Drawing.Size(1016, 680)
        Me.tab_diagnostique.TabIndex = 0
        '
        'frmDiagnostiqueSimple
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btn_annuler
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiagnostiqueSimple"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Diagnostique"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.tabPage_diagnostique_accessoires.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.GroupBox_diagnostic_1231.ResumeLayout(False)
        Me.GroupBox_diagnostic_1232.ResumeLayout(False)
        CType(Me.ico_help12323, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        Me.GroupBox_diagnostic_1221.ResumeLayout(False)
        Me.GroupBox_diagnostic_1222.ResumeLayout(False)
        Me.GroupBox_diagnostic_1241.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.GroupBox_diagnostic_1111.ResumeLayout(False)
        Me.GroupBox_diagnostic_1112.ResumeLayout(False)
        Me.GroupBox_diagnostic_1113.ResumeLayout(False)
        Me.GroupBox_diagnostic_1114.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.GroupBox_diagnostic_1211.ResumeLayout(False)
        Me.GroupBox_diagnostic_1212.ResumeLayout(False)
        CType(Me.ico_help_12123, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_diagnostic_1213.ResumeLayout(False)
        Me.tabPage_diagnostique_buses.ResumeLayout(False)
        Me.Panel63.ResumeLayout(False)
        Me.Panel922.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.diagBuses_tab_categories.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.pblModele_tabMesuresBuses.ResumeLayout(False)
        Me.pnlModele_tabMesureSecondaire.ResumeLayout(False)
        Me.Panel120.ResumeLayout(False)
        Me.Panel120.PerformLayout()
        Me.Panel119.ResumeLayout(False)
        Me.Panel118.ResumeLayout(False)
        Me.Panel118.PerformLayout()
        Me.Panel117.ResumeLayout(False)
        Me.Panel116.ResumeLayout(False)
        Me.Panel116.PerformLayout()
        Me.Panel115.ResumeLayout(False)
        Me.Panel115.PerformLayout()
        Me.Panel114.ResumeLayout(False)
        Me.Panel113.ResumeLayout(False)
        Me.Panel113.PerformLayout()
        Me.Panel112.ResumeLayout(False)
        Me.Panel112.PerformLayout()
        Me.Panel111.ResumeLayout(False)
        Me.Panel111.PerformLayout()
        Me.Panel110.ResumeLayout(False)
        Me.Panel109.ResumeLayout(False)
        Me.Panel109.PerformLayout()
        Me.Panel108.ResumeLayout(False)
        Me.Panel108.PerformLayout()
        Me.Panel107.ResumeLayout(False)
        Me.Panel107.PerformLayout()
        Me.Panel106.ResumeLayout(False)
        Me.Panel105.ResumeLayout(False)
        Me.Panel104.ResumeLayout(False)
        Me.Panel104.PerformLayout()
        Me.Panel103.ResumeLayout(False)
        Me.Panel103.PerformLayout()
        Me.Panel102.ResumeLayout(False)
        Me.Panel101.ResumeLayout(False)
        Me.Panel101.PerformLayout()
        Me.Panel100.ResumeLayout(False)
        Me.Panel100.PerformLayout()
        Me.Panel99.ResumeLayout(False)
        Me.Panel98.ResumeLayout(False)
        Me.Panel98.PerformLayout()
        Me.Panel97.ResumeLayout(False)
        Me.Panel97.PerformLayout()
        Me.Panel67.ResumeLayout(False)
        Me.Panel66.ResumeLayout(False)
        Me.Panel49.ResumeLayout(False)
        Me.Panel49.PerformLayout()
        Me.Panel38.ResumeLayout(False)
        Me.Panel38.PerformLayout()
        Me.Panel71.ResumeLayout(False)
        Me.Panel71.PerformLayout()
        Me.Panel69.ResumeLayout(False)
        Me.Panel69.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel70.ResumeLayout(False)
        Me.Panel68.ResumeLayout(False)
        Me.tabPage_diagnostique_manoTroncon.ResumeLayout(False)
        Me.pnl542.ResumeLayout(False)
        Me.Panel48.ResumeLayout(False)
        Me.Panel292.ResumeLayout(False)
        Me.Panel292.PerformLayout()
        Me.Panel46.ResumeLayout(False)
        Me.manopulvePression_panel_manoAgent.ResumeLayout(False)
        Me.manopulvePression_panel_manoAgent.PerformLayout()
        Me.manopulvePression_panel_manoPulve.ResumeLayout(False)
        Me.manopulvePression_panel_manoPulve.PerformLayout()
        Me.manopulvePression_panel_erreur.ResumeLayout(False)
        Me.manopulvePression_panel_erreur.PerformLayout()
        Me.Panel52.ResumeLayout(False)
        Me.Panel53.ResumeLayout(False)
        Me.Panel54.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.pnl_833.ResumeLayout(False)
        Me.pnl_833.PerformLayout()
        Me.tab_833.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        CType(Me.gdvPressions4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        CType(Me.gdvPressions3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.gdvPressions2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.gdvPressions1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.nup_niveaux, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupTroncons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage_diagnostique_rampes.ResumeLayout(False)
        Me.Panel34.ResumeLayout(False)
        Me.GroupBox_diagnostic_815.ResumeLayout(False)
        Me.GroupBox_diagnostic_814.ResumeLayout(False)
        Me.GroupBox_diagnostic_811.ResumeLayout(False)
        CType(Me.ico_help_811, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_diagnostic_812.ResumeLayout(False)
        Me.Panel35.ResumeLayout(False)
        Me.GroupBox_diagnostic_821.ResumeLayout(False)
        Me.GroupBox_diagnostic_822.ResumeLayout(False)
        Me.GroupBox_diagnostic_823.ResumeLayout(False)
        Me.GroupBox_diagnostic_816.ResumeLayout(False)
        Me.GroupBox_diagnostic_813.ResumeLayout(False)
        Me.GroupBox_diagnostic_817.ResumeLayout(False)
        Me.Panel36.ResumeLayout(False)
        Me.popup_help_811.ResumeLayout(False)
        Me.Panel123.ResumeLayout(False)
        Me.Panel123.PerformLayout()
        Me.GroupBox_diagnostic_831.ResumeLayout(False)
        CType(Me.ico_help_8312, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ico_help_8314, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_diagnostic_832.ResumeLayout(False)
        Me.GroupBox_diagnostic_833.ResumeLayout(False)
        Me.popup_help_831.ResumeLayout(False)
        Me.Panel125.ResumeLayout(False)
        Me.Panel125.PerformLayout()
        Me.Panel128.ResumeLayout(False)
        Me.tabPage_diagnostique_mesureCommandesRegulation.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        Me.GroupBox_diagnostic_551.ResumeLayout(False)
        CType(Me.ico_help_551, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_diagnostic_552.ResumeLayout(False)
        CType(Me.ico_help_552, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pctb_calc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel22.ResumeLayout(False)
        Me.GroupBox_diagnostic_521.ResumeLayout(False)
        Me.GroupBox_diagnostic_522.ResumeLayout(False)
        Me.Panel23.ResumeLayout(False)
        Me.GroupBox_diagnostic_531.ResumeLayout(False)
        Me.GroupBox_diagnostic_532.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.GroupBox_diagnostic_511.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.GroupBox_diagnostic_541.ResumeLayout(False)
        Me.GroupBox_diagnostic_542.ResumeLayout(False)
        Me.Panel26.ResumeLayout(False)
        Me.GroupBox_diagnostic_561.ResumeLayout(False)
        Me.GroupBox_diagnostic_562.ResumeLayout(False)
        CType(Me.ico_help_5621, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ico_help_5622, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_diagnostic_571.ResumeLayout(False)
        CType(Me.ico_help_571, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ico_oeil571, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel127.ResumeLayout(False)
        Me.tab_diagnostique.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#Region " Init vars "
    Friend WithEvents diag_pulve_Type As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents FichierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CachedEtatSynthese1 As Crodip_agent.Cachedcr_EtatSynthese
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents listImg_flags As System.Windows.Forms.ImageList
    Friend WithEvents diag_client_raisonSociale As System.Windows.Forms.Label
    Friend WithEvents diag_client_proprioSiren As System.Windows.Forms.Label
    Friend WithEvents diag_pulve_numNatio As System.Windows.Forms.Label
    Friend WithEvents diag_pulve_marqueModele As System.Windows.Forms.Label
    Friend WithEvents ToolTip_diagnostic_numRadioButtons As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList_onglets As System.Windows.Forms.ImageList
    Friend WithEvents btn_Poursuivre As System.Windows.Forms.Button
    Friend WithEvents btn_annuler As System.Windows.Forms.Button
    Friend WithEvents btn_Valider As System.Windows.Forms.Button



#End Region

    Private Sub tbDebitMoyen3bars_AcceptsTabChanged(sender As Object, e As EventArgs) Handles tbDebitMoyen3bars.AcceptsTabChanged

    End Sub

    Friend WithEvents tab_diagnostique As TabControl
    Friend WithEvents tabPage_diagnostique_mesureCommandesRegulation As TabPage
    Friend WithEvents Panel127 As Panel
    Friend WithEvents Label_diagnostic_5 As Label
    Friend WithEvents Panel26 As Panel
    Friend WithEvents Label_diagnostic_57 As Label
    Friend WithEvents GroupBox_diagnostic_571 As GroupBox
    Friend WithEvents ico_oeil571 As PictureBox
    Friend WithEvents ico_help_571 As PictureBox
    Friend WithEvents RadioButton_diagnostic_5712 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5710 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5711 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_562 As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ico_help_5622 As PictureBox
    Friend WithEvents ico_help_5621 As PictureBox
    Friend WithEvents RadioButton_diagnostic_5622 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5620 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5621 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_561 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5612 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5610 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5611 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_56 As Label
    Friend WithEvents Panel24 As Panel
    Friend WithEvents GroupBox_diagnostic_542 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5423 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5420 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5421 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5422 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_541 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5414 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5413 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5410 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5412 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5411 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_54 As Label
    Friend WithEvents Panel21 As Panel
    Friend WithEvents GroupBox_diagnostic_511 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5110 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5112 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5111 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_51 As Label
    Friend WithEvents Panel23 As Panel
    Friend WithEvents GroupBox_diagnostic_532 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5323 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5320 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5322 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5321 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_531 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5310 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5312 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5311 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_53 As Label
    Friend WithEvents Panel22 As Panel
    Friend WithEvents GroupBox_diagnostic_522 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5223 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5220 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5222 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5221 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_521 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5210 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5212 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5211 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_52 As Label
    Friend WithEvents Panel25 As Panel
    Friend WithEvents GroupBox_diagnostic_552 As GroupBox
    Friend WithEvents Pctb_calc As PictureBox
    Friend WithEvents ico_help_552 As PictureBox
    Friend WithEvents RadioButton_diagnostic_5522 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5520 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5521 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_551 As GroupBox
    Friend WithEvents RadioButton_diagnostic_5512 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5510 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_5511 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents ico_help_551 As PictureBox
    Friend WithEvents Label_diagnostic_55 As Label
    Friend WithEvents tabPage_diagnostique_rampes As TabPage
    Friend WithEvents Panel128 As Panel
    Friend WithEvents Label_diagnostic_8 As Label
    Friend WithEvents Panel36 As Panel
    Friend WithEvents popup_help_831 As Panel
    Friend WithEvents Panel125 As Panel
    Friend WithEvents help831_ecartementMax As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help831_ecartementReference As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label16 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblPopup831 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents help831_ecartementMin As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help831_result As Label
    Friend WithEvents help831_close As Label
    Friend WithEvents help831_ecart As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label211 As Label
    Friend WithEvents GroupBox_diagnostic_833 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8334 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8333 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8332 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8330 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8331 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_832 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8323 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8322 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8320 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8321 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_831 As GroupBox
    Friend WithEvents ico_help_8314 As PictureBox
    Friend WithEvents RadioButton_diagnostic_8314 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents ico_help_8312 As PictureBox
    Friend WithEvents RadioButton_diagnostic_8313 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8310 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8311 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8312 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_83 As Label
    Friend WithEvents popup_help_811 As Panel
    Friend WithEvents Panel123 As Panel
    Friend WithEvents help811_result As Label
    Friend WithEvents help811_fleche As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents help811_largeur As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help811_close As Label
    Friend WithEvents Panel34 As Panel
    Friend WithEvents GroupBox_diagnostic_817 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8172 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8170 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8171 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_813 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8130 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8132 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8131 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_816 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8162 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8160 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8161 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Panel35 As Panel
    Friend WithEvents GroupBox_diagnostic_823 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8234 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8233 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8232 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8230 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8231 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_822 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8222 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8220 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8221 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_821 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8210 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8211 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_82 As Label
    Friend WithEvents GroupBox_diagnostic_812 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8124 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8123 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8122 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8120 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8121 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_811 As GroupBox
    Friend WithEvents ico_help_811 As PictureBox
    Friend WithEvents RadioButton_diagnostic_8114 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8113 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8110 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8111 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8112 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_814 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8142 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8140 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8141 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_815 As GroupBox
    Friend WithEvents RadioButton_diagnostic_8152 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8150 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_8151 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_81 As Label
    Friend WithEvents tabPage_diagnostique_manoTroncon As TabPage
    Friend WithEvents pnl_833 As Panel
    Friend WithEvents rbPression4 As RadioButton
    Friend WithEvents rbPression3 As RadioButton
    Friend WithEvents rbPression2 As RadioButton
    Friend WithEvents rbPression1 As RadioButton
    Friend WithEvents Label111 As Label
    Friend WithEvents lblp833DefautEcart As Label
    Friend WithEvents lblP833DefautHeterogeneite As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents nupTroncons As NumericUpDown
    Friend WithEvents Label54 As Label
    Friend WithEvents nup_niveaux As NumericUpDown
    Friend WithEvents Label53 As Label
    Friend WithEvents Lbl_diagnostic_833 As Label
    Friend WithEvents Label221 As Label
    Friend WithEvents tab_833 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents tbMoyEcartbar1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label72 As Label
    Friend WithEvents tbMoyEcartPct1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label55 As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents tbMoyenne1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label2 As Label
    Friend WithEvents pressionTronc_DefautEcart1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents pressionTronc_5_pressionManoPulve As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents gdvPressions1 As DataGridView
    Friend WithEvents pressionTronc_heterogeniteAlimentation1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents tbMoyEcartbar2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label8 As Label
    Friend WithEvents tbMoyEcartPct2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label118 As Label
    Friend WithEvents Label104 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents pressionTronc_DefautEcart2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents gdvPressions2 As DataGridView
    Friend WithEvents pressionTronc_heterogeniteAlimentation2 As Label
    Friend WithEvents tbMoyenne2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents pressionTronc_10_pressionManoPulve As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents tbMoyEcartbar3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label105 As Label
    Friend WithEvents tbMoyEcartPct3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label107 As Label
    Friend WithEvents Label109 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents pressionTronc_DefautEcart3 As Label
    Friend WithEvents Label88 As Label
    Friend WithEvents gdvPressions3 As DataGridView
    Friend WithEvents pressionTronc_heterogeniteAlimentation3 As Label
    Friend WithEvents tbMoyenne3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents pressionTronc_15_pressionManoPulve As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents tbMoyEcartbar4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label108 As Label
    Friend WithEvents tbMoyEcartPct4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label110 As Label
    Friend WithEvents Label113 As Label
    Friend WithEvents Label90 As Label
    Friend WithEvents Label103 As Label
    Friend WithEvents pressionTronc_DefautEcart4 As Label
    Friend WithEvents Label106 As Label
    Friend WithEvents gdvPressions4 As DataGridView
    Friend WithEvents pressionTronc_heterogeniteAlimentation4 As Label
    Friend WithEvents tbMoyenne4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents pressionTronc_20_pressionManoPulve As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents pnl542 As Panel
    Friend WithEvents btnRecalculer As Label
    Friend WithEvents manopulveIsUseCalibrateur As CheckBox
    Friend WithEvents manopulveIsFaiblePression As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents manoPulveEcartMax As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manoPulveEcartMoyen As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulveResultat As Label
    Friend WithEvents Label226 As Label
    Friend WithEvents Lbl_diagnostic_542 As Label
    Friend WithEvents Panel48 As Panel
    Friend WithEvents Panel54 As Panel
    Friend WithEvents Label70 As Label
    Friend WithEvents Panel53 As Panel
    Friend WithEvents Label69 As Label
    Friend WithEvents Panel52 As Panel
    Friend WithEvents Label66 As Label
    Friend WithEvents manopulvePression_panel_erreur As Panel
    Friend WithEvents manopulvePressionEcart_1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionEcart_2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionEcart_3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionEcart_4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePression_panel_manoPulve As Panel
    Friend WithEvents manopulvePressionPulve_3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionPulve_4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionPulve_2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionPulve_1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePression_panel_manoAgent As Panel
    Friend WithEvents manopulvePressionControle_2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionControle_3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionControle_4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionLue_6 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionLue_8 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionLue_7 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionControle_1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionLue_5 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel46 As Panel
    Friend WithEvents Label224 As Label
    Friend WithEvents Panel292 As Panel
    Friend WithEvents manopulvePressionImprecision_1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionImprecision_2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionImprecision_3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents manopulvePressionImprecision_4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label65 As Label
    Friend WithEvents manoTroncon_listManoControle As ComboBox
    Friend WithEvents manopulveIsFortePression As RadioButton
    Friend WithEvents manopulveIsSaisieManuelle As RadioButton
    Friend WithEvents tabPage_diagnostique_buses As TabPage
    Friend WithEvents Panel922 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents tbDebitMoyen3bars As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents LaDebitMoyen3bars As Label
    Friend WithEvents diagBuses_conf_ajouterNiveau As Label
    Friend WithEvents diagBuses_conf_validNbCategories As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents tbPressionMesure As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents diagBuses_tab_categories As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents tbModele_DebitMaxi As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents lblModele_DebitMaxi As Label
    Friend WithEvents tbModele_DebitMini As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents lblModele_DebitMini As Label
    Friend WithEvents TbModele_Calibre As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents cbxModele_EcartTolere As ComboBox
    Friend WithEvents cbxModele_Marque As ComboBox
    Friend WithEvents pblModele_tabMesuresBuses As Panel
    Friend WithEvents Panel68 As Panel
    Friend WithEvents Label81 As Label
    Friend WithEvents Panel70 As Panel
    Friend WithEvents Label80 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label79 As Label
    Friend WithEvents pnlModele_tabMesureSecondaire As Panel
    Friend WithEvents Panel69 As Panel
    Friend WithEvents diagBuses_mesureDebit_2_debit As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel71 As Panel
    Friend WithEvents diagBuses_mesureDebit_1_debit As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel38 As Panel
    Friend WithEvents TextBox5 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel49 As Panel
    Friend WithEvents Textbox6 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel66 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel67 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel97 As Panel
    Friend WithEvents Textbox31 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel98 As Panel
    Friend WithEvents Textbox32 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel99 As Panel
    Friend WithEvents Label40 As Label
    Friend WithEvents Panel100 As Panel
    Friend WithEvents Textbox33 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel101 As Panel
    Friend WithEvents Textbox34 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel102 As Panel
    Friend WithEvents Label41 As Label
    Friend WithEvents Panel103 As Panel
    Friend WithEvents Textbox35 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel104 As Panel
    Friend WithEvents Textbox36 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel105 As Panel
    Friend WithEvents Label42 As Label
    Friend WithEvents Panel106 As Panel
    Friend WithEvents Label43 As Label
    Friend WithEvents Panel107 As Panel
    Friend WithEvents Textbox37 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel108 As Panel
    Friend WithEvents TextBox38 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel109 As Panel
    Friend WithEvents TextBox39 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel110 As Panel
    Friend WithEvents Label44 As Label
    Friend WithEvents Panel111 As Panel
    Friend WithEvents TextBox40 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel112 As Panel
    Friend WithEvents TextBox41 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel113 As Panel
    Friend WithEvents TextBox42 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel114 As Panel
    Friend WithEvents Label45 As Label
    Friend WithEvents Panel115 As Panel
    Friend WithEvents TextBox44 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel116 As Panel
    Friend WithEvents TextBox45 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel117 As Panel
    Friend WithEvents Label46 As Label
    Friend WithEvents Panel118 As Panel
    Friend WithEvents TextBox46 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel119 As Panel
    Friend WithEvents Label47 As Label
    Friend WithEvents Panel120 As Panel
    Friend WithEvents TextBox47 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbModele_NombreDeBuses As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents LblModele_NombreDeBuses As Label
    Friend WithEvents tbModele_DebitNominalContructeur As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents lblModele_EcartTolere As Label
    Friend WithEvents lblModele_DebitNominalConstructeur As Label
    Friend WithEvents btnModele_validerNbBuses As Label
    Friend WithEvents tbModele_DebitNominalPourCalcul As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents lblModele_DebitNominalPourCalcul As Label
    Friend WithEvents tbModele_UsureMoyenne As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents lblModele_UsureMoyenne As Label
    Friend WithEvents tbModele_DebitMoyen As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents lblModele_DebitMoyen As Label
    Friend WithEvents tbModele_NbBusesUsees As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents lblModele_NbBusesUsees As Label
    Friend WithEvents lblModele_Marque As Label
    Friend WithEvents lblModele_Modele As Label
    Friend WithEvents cbxModele_Modele As ComboBox
    Friend WithEvents lblModele_Couleur As Label
    Friend WithEvents lblModele_Calibre As Label
    Friend WithEvents cbxModele_Couleur As ComboBox
    Friend WithEvents diagBuses_conf_nbCategories As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label23 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents diagBuses_nbBusesUsees As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label213 As Label
    Friend WithEvents diagBuses_usureMoyBuses As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label214 As Label
    Friend WithEvents LaDebitMoyenBuses As Label
    Friend WithEvents diagBuses_debitMoyen As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents diagBuses_resultat As Label
    Friend WithEvents btn_diagnostic_acquisitionDonnees As Label
    Friend WithEvents Lbl_diagnostic_922 As Label
    Friend WithEvents Panel63 As Panel
    Friend WithEvents Label76 As Label
    Friend WithEvents buses_listBancs As ComboBox
    Friend WithEvents Label77 As Label
    Friend WithEvents tabPage_diagnostique_accessoires As TabPage
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents GroupBox_diagnostic_1213 As GroupBox
    Friend WithEvents RadioButton_diagnostic_12132 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12130 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12131 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_1212 As GroupBox
    Friend WithEvents ico_help_12123 As PictureBox
    Friend WithEvents RadioButton_diagnostic_12122 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12123 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12120 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12121 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_121 As Label
    Friend WithEvents GroupBox_diagnostic_1211 As GroupBox
    Friend WithEvents RadioButton_diagnostic_12112 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12113 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12110 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12111 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Panel14 As Panel
    Friend WithEvents GroupBox_diagnostic_1114 As GroupBox
    Friend WithEvents RadioButton_diagnostic_11142 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11140 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11141 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_1113 As GroupBox
    Friend WithEvents RadioButton_diagnostic_11132 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11133 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11130 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11131 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_1112 As GroupBox
    Friend WithEvents RadioButton_diagnostic_11122 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11123 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11120 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11121 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_111 As Label
    Friend WithEvents GroupBox_diagnostic_1111 As GroupBox
    Friend WithEvents RadioButton_diagnostic_11112 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11113 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11110 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_11111 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Label_diagnostic_124 As Label
    Friend WithEvents GroupBox_diagnostic_1241 As GroupBox
    Friend WithEvents RadioButton_diagnostic_12412 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12410 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12411 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents GroupBox_diagnostic_1222 As GroupBox
    Friend WithEvents RadioButton_diagnostic_12220 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12221 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_122 As Label
    Friend WithEvents GroupBox_diagnostic_1221 As GroupBox
    Friend WithEvents RadioButton_diagnostic_12212 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12213 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12210 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12211 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_11 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents GroupBox_diagnostic_1232 As GroupBox
    Friend WithEvents ico_help12323 As PictureBox
    Friend WithEvents RadioButton_diagnostic_12323 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12324 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12321 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12320 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12322 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_123 As Label
    Friend WithEvents GroupBox_diagnostic_1231 As GroupBox
    Friend WithEvents RadioButton_diagnostic_12317 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12318 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12315 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12316 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12313 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12314 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12311 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12310 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_12312 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents Label_diagnostic_12 As Label
End Class
