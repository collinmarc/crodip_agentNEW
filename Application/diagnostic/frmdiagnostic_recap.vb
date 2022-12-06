'Imports iTextSharp
'Imports iTextSharp.text
'Imports iTextSharp.text.pdf
'Imports iTextSharp.text.xml
Imports System.IO
Imports System.Globalization
Imports System.ComponentModel

Public Class frmdiagnostic_recap
    Inherits frmCRODIP
#Region " Variables "
    Private bTest As Boolean = False
    Private m_DiagMode As GlobalsCRODIP.DiagMode
    Private m_diagnostic As Diagnostic
    Private m_Exploit As Exploitation
    Private m_Pulverisateur As Pulverisateur
    Private m_oAgent As Agent
    Private m_frmdiagnostic As Form
    Private m_oStructure As Structuree

    Dim isValider As Boolean = False
    Dim conclusionDiagnostique As GlobalsCRODIP.enumConclusionDiag
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents grpOrganisme As System.Windows.Forms.GroupBox
    Friend WithEvents diagnosticRecap_organisme_dateControle As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_organisme_heureDebut As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_organisme_heureFin As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents grpProprio As System.Windows.Forms.GroupBox
    Friend WithEvents btn_voirFicheExploitant As System.Windows.Forms.Label
    Friend WithEvents grpMateriel As System.Windows.Forms.GroupBox
    Friend WithEvents cbx_diagnosticRecap_materiel_EmplacementIdentification As System.Windows.Forms.ComboBox
    Friend WithEvents btn_voirFiche_Pulve As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents rtbCommentaire As System.Windows.Forms.RichTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAppercu As System.Windows.Forms.Label
    Friend WithEvents rbEtatSM As System.Windows.Forms.RadioButton
    Friend WithEvents rbEtatRI As System.Windows.Forms.RadioButton
    Friend WithEvents m_bsDiag As System.Windows.Forms.BindingSource
    Friend WithEvents label_pulveBonEtat As Label
    Friend WithEvents conclusion_pictoEtat As PictureBox
    Private WithEvents btnSignClient As Label
    Private WithEvents btnSignAgent As Label
    Friend WithEvents rbEtatCC As RadioButton
    Friend WithEvents btn_ContratCommercial As Label
    Friend WithEvents btn_Annuler As Label
    Friend WithEvents btn_finalisationDiag_imprimerSynthese As System.Windows.Forms.Label
    'Private objInfos(15) As Object

#End Region

#Region " Code généré par le Concepteur Windows Form "

    Private Sub New()
        MyBase.New()

        'objInfos = _objInfos

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        CrystalReportViewer1.Zoom(1) 'Page Width

    End Sub

    Public Sub New(pDiagMode As GlobalsCRODIP.DiagMode, pDiag As Diagnostic, pPulve As Pulverisateur, pExploit As Exploitation, pAgent As Agent, pfrmDiagnostic As Form)
        MyBase.New()
        m_DiagMode = pDiagMode

        m_diagnostic = pDiag
        m_Pulverisateur = pPulve
        m_Exploit = pExploit
        m_oAgent = pAgent
        m_frmdiagnostic = pfrmDiagnostic
        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

        m_bsDiag.Add(m_diagnostic)
        m_oStructure = StructureManager.getStructureById(m_oAgent.idStructure)
    End Sub
    Public Sub setbTest(Optional pTest As Boolean = True)
        bTest = pTest
    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            If CrystalReportViewer1.ReportSource IsNot Nothing Then
                CrystalReportViewer1.ReportSource.dispose()
                CrystalReportViewer1.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents laTitre As System.Windows.Forms.Label
    Friend WithEvents ImageList_Etat As System.Windows.Forms.ImageList
    Private WithEvents btn_finalisationDiag_valider As System.Windows.Forms.Label
    Friend WithEvents btn_finalisationDiag_imprimerRapport As System.Windows.Forms.Label
    Friend WithEvents btn_finalisationDiag_modifierDiag As System.Windows.Forms.Label
    '    Friend WithEvents cr_debitBuses As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmdiagnostic_recap))
        Me.laTitre = New System.Windows.Forms.Label()
        Me.ImageList_Etat = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_finalisationDiag_valider = New System.Windows.Forms.Label()
        Me.btn_finalisationDiag_imprimerRapport = New System.Windows.Forms.Label()
        Me.btn_finalisationDiag_modifierDiag = New System.Windows.Forms.Label()
        Me.btn_finalisationDiag_imprimerSynthese = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.rbEtatCC = New System.Windows.Forms.RadioButton()
        Me.rbEtatSM = New System.Windows.Forms.RadioButton()
        Me.rbEtatRI = New System.Windows.Forms.RadioButton()
        Me.btnAppercu = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rtbCommentaire = New System.Windows.Forms.RichTextBox()
        Me.m_bsDiag = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpMateriel = New System.Windows.Forms.GroupBox()
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification = New System.Windows.Forms.ComboBox()
        Me.btn_voirFiche_Pulve = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.grpProprio = New System.Windows.Forms.GroupBox()
        Me.btn_voirFicheExploitant = New System.Windows.Forms.Label()
        Me.grpOrganisme = New System.Windows.Forms.GroupBox()
        Me.diagnosticRecap_organisme_dateControle = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_organisme_heureDebut = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_organisme_heureFin = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.label_pulveBonEtat = New System.Windows.Forms.Label()
        Me.conclusion_pictoEtat = New System.Windows.Forms.PictureBox()
        Me.btnSignClient = New System.Windows.Forms.Label()
        Me.btnSignAgent = New System.Windows.Forms.Label()
        Me.btn_ContratCommercial = New System.Windows.Forms.Label()
        Me.btn_Annuler = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.m_bsDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMateriel.SuspendLayout()
        Me.grpProprio.SuspendLayout()
        Me.grpOrganisme.SuspendLayout()
        CType(Me.conclusion_pictoEtat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'laTitre
        '
        Me.laTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laTitre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laTitre.Image = CType(resources.GetObject("laTitre.Image"), System.Drawing.Image)
        Me.laTitre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.laTitre.Location = New System.Drawing.Point(8, 8)
        Me.laTitre.Name = "laTitre"
        Me.laTitre.Size = New System.Drawing.Size(344, 24)
        Me.laTitre.TabIndex = 3
        Me.laTitre.Text = "     Visualisation du contrôle"
        '
        'ImageList_Etat
        '
        Me.ImageList_Etat.ImageStream = CType(resources.GetObject("ImageList_Etat.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Etat.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Etat.Images.SetKeyName(0, "")
        Me.ImageList_Etat.Images.SetKeyName(1, "")
        '
        'btn_finalisationDiag_valider
        '
        Me.btn_finalisationDiag_valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_finalisationDiag_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_valider.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_valider.Image = CType(resources.GetObject("btn_finalisationDiag_valider.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_valider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_finalisationDiag_valider.Location = New System.Drawing.Point(862, 619)
        Me.btn_finalisationDiag_valider.Name = "btn_finalisationDiag_valider"
        Me.btn_finalisationDiag_valider.Size = New System.Drawing.Size(134, 24)
        Me.btn_finalisationDiag_valider.TabIndex = 9
        Me.btn_finalisationDiag_valider.Text = "    Valider"
        Me.btn_finalisationDiag_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_finalisationDiag_imprimerRapport
        '
        Me.btn_finalisationDiag_imprimerRapport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_finalisationDiag_imprimerRapport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_imprimerRapport.Enabled = False
        Me.btn_finalisationDiag_imprimerRapport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_imprimerRapport.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_imprimerRapport.Image = CType(resources.GetObject("btn_finalisationDiag_imprimerRapport.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_imprimerRapport.Location = New System.Drawing.Point(384, 619)
        Me.btn_finalisationDiag_imprimerRapport.Name = "btn_finalisationDiag_imprimerRapport"
        Me.btn_finalisationDiag_imprimerRapport.Size = New System.Drawing.Size(184, 24)
        Me.btn_finalisationDiag_imprimerRapport.TabIndex = 7
        Me.btn_finalisationDiag_imprimerRapport.Text = "      Imprimer le rapport"
        Me.btn_finalisationDiag_imprimerRapport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_finalisationDiag_modifierDiag
        '
        Me.btn_finalisationDiag_modifierDiag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_finalisationDiag_modifierDiag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_modifierDiag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_modifierDiag.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_modifierDiag.Image = CType(resources.GetObject("btn_finalisationDiag_modifierDiag.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_modifierDiag.Location = New System.Drawing.Point(12, 619)
        Me.btn_finalisationDiag_modifierDiag.Name = "btn_finalisationDiag_modifierDiag"
        Me.btn_finalisationDiag_modifierDiag.Size = New System.Drawing.Size(136, 24)
        Me.btn_finalisationDiag_modifierDiag.TabIndex = 6
        Me.btn_finalisationDiag_modifierDiag.Text = "       Modifier le contrôle"
        Me.btn_finalisationDiag_modifierDiag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_finalisationDiag_imprimerSynthese
        '
        Me.btn_finalisationDiag_imprimerSynthese.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_finalisationDiag_imprimerSynthese.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_imprimerSynthese.Enabled = False
        Me.btn_finalisationDiag_imprimerSynthese.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_imprimerSynthese.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_imprimerSynthese.Image = CType(resources.GetObject("btn_finalisationDiag_imprimerSynthese.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_imprimerSynthese.Location = New System.Drawing.Point(194, 653)
        Me.btn_finalisationDiag_imprimerSynthese.Name = "btn_finalisationDiag_imprimerSynthese"
        Me.btn_finalisationDiag_imprimerSynthese.Size = New System.Drawing.Size(184, 24)
        Me.btn_finalisationDiag_imprimerSynthese.TabIndex = 8
        Me.btn_finalisationDiag_imprimerSynthese.Text = "      Synthèse des mesures"
        Me.btn_finalisationDiag_imprimerSynthese.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(10, 45)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbEtatCC)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbEtatSM)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbEtatRI)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAppercu)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CrystalReportViewer1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtbCommentaire)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpMateriel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpProprio)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpOrganisme)
        Me.SplitContainer1.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SplitContainer1.Size = New System.Drawing.Size(986, 571)
        Me.SplitContainer1.SplitterDistance = 626
        Me.SplitContainer1.TabIndex = 14
        '
        'rbEtatCC
        '
        Me.rbEtatCC.AutoSize = True
        Me.rbEtatCC.Location = New System.Drawing.Point(289, 12)
        Me.rbEtatCC.Name = "rbEtatCC"
        Me.rbEtatCC.Size = New System.Drawing.Size(115, 17)
        Me.rbEtatCC.TabIndex = 6
        Me.rbEtatCC.TabStop = True
        Me.rbEtatCC.Text = "Contrat commercial"
        Me.rbEtatCC.UseVisualStyleBackColor = True
        '
        'rbEtatSM
        '
        Me.rbEtatSM.AutoSize = True
        Me.rbEtatSM.Location = New System.Drawing.Point(152, 12)
        Me.rbEtatSM.Name = "rbEtatSM"
        Me.rbEtatSM.Size = New System.Drawing.Size(131, 17)
        Me.rbEtatSM.TabIndex = 2
        Me.rbEtatSM.Text = "Synthèse des mesures"
        Me.rbEtatSM.UseVisualStyleBackColor = True
        '
        'rbEtatRI
        '
        Me.rbEtatRI.AutoSize = True
        Me.rbEtatRI.Checked = True
        Me.rbEtatRI.Location = New System.Drawing.Point(24, 12)
        Me.rbEtatRI.Name = "rbEtatRI"
        Me.rbEtatRI.Size = New System.Drawing.Size(122, 17)
        Me.rbEtatRI.TabIndex = 1
        Me.rbEtatRI.TabStop = True
        Me.rbEtatRI.Text = "Rapport d'inspection"
        Me.rbEtatRI.UseVisualStyleBackColor = True
        '
        'btnAppercu
        '
        Me.btnAppercu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAppercu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAppercu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAppercu.ForeColor = System.Drawing.Color.White
        Me.btnAppercu.Image = Global.Crodip_agent.Resources.btn_refresh
        Me.btnAppercu.Location = New System.Drawing.Point(419, 8)
        Me.btnAppercu.Name = "btnAppercu"
        Me.btnAppercu.Size = New System.Drawing.Size(200, 24)
        Me.btnAppercu.TabIndex = 5
        Me.btnAppercu.Text = "    Aperçu"
        Me.btnAppercu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 42)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowExportButton = False
        Me.CrystalReportViewer1.ShowGotoPageButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.ShowTextSearchButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(622, 525)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'rtbCommentaire
        '
        Me.rtbCommentaire.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbCommentaire.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsDiag, "Commentaire", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.rtbCommentaire.Location = New System.Drawing.Point(6, 307)
        Me.rtbCommentaire.MaxLength = 255
        Me.rtbCommentaire.Name = "rtbCommentaire"
        Me.rtbCommentaire.Size = New System.Drawing.Size(337, 117)
        Me.rtbCommentaire.TabIndex = 63
        Me.rtbCommentaire.Text = ""
        '
        'm_bsDiag
        '
        Me.m_bsDiag.DataSource = GetType(Crodip_agent.Diagnostic)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 279)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Commentaire :"
        '
        'grpMateriel
        '
        Me.grpMateriel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMateriel.Controls.Add(Me.cbx_diagnosticRecap_materiel_EmplacementIdentification)
        Me.grpMateriel.Controls.Add(Me.btn_voirFiche_Pulve)
        Me.grpMateriel.Controls.Add(Me.Label38)
        Me.grpMateriel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMateriel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpMateriel.Location = New System.Drawing.Point(6, 156)
        Me.grpMateriel.Name = "grpMateriel"
        Me.grpMateriel.Size = New System.Drawing.Size(343, 106)
        Me.grpMateriel.TabIndex = 4
        Me.grpMateriel.TabStop = False
        Me.grpMateriel.Text = "Matériel"
        '
        'cbx_diagnosticRecap_materiel_EmplacementIdentification
        '
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.FormattingEnabled = True
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.Location = New System.Drawing.Point(6, 40)
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.Name = "cbx_diagnosticRecap_materiel_EmplacementIdentification"
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.Size = New System.Drawing.Size(331, 21)
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.TabIndex = 68
        '
        'btn_voirFiche_Pulve
        '
        Me.btn_voirFiche_Pulve.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_voirFiche_Pulve.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_voirFiche_Pulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_voirFiche_Pulve.ForeColor = System.Drawing.Color.White
        Me.btn_voirFiche_Pulve.Image = CType(resources.GetObject("btn_voirFiche_Pulve.Image"), System.Drawing.Image)
        Me.btn_voirFiche_Pulve.Location = New System.Drawing.Point(207, 79)
        Me.btn_voirFiche_Pulve.Name = "btn_voirFiche_Pulve"
        Me.btn_voirFiche_Pulve.Size = New System.Drawing.Size(128, 24)
        Me.btn_voirFiche_Pulve.TabIndex = 1
        Me.btn_voirFiche_Pulve.Text = "    Voir la fiche"
        Me.btn_voirFiche_Pulve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(8, 24)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(195, 13)
        Me.Label38.TabIndex = 60
        Me.Label38.Text = "Emplacement de l'identification : "
        '
        'grpProprio
        '
        Me.grpProprio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProprio.Controls.Add(Me.btn_voirFicheExploitant)
        Me.grpProprio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpProprio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpProprio.Location = New System.Drawing.Point(6, 100)
        Me.grpProprio.Name = "grpProprio"
        Me.grpProprio.Size = New System.Drawing.Size(341, 50)
        Me.grpProprio.TabIndex = 3
        Me.grpProprio.TabStop = False
        Me.grpProprio.Text = "Propriétaire du matériel"
        '
        'btn_voirFicheExploitant
        '
        Me.btn_voirFicheExploitant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_voirFicheExploitant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_voirFicheExploitant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_voirFicheExploitant.ForeColor = System.Drawing.Color.White
        Me.btn_voirFicheExploitant.Image = CType(resources.GetObject("btn_voirFicheExploitant.Image"), System.Drawing.Image)
        Me.btn_voirFicheExploitant.Location = New System.Drawing.Point(207, 16)
        Me.btn_voirFicheExploitant.Name = "btn_voirFicheExploitant"
        Me.btn_voirFicheExploitant.Size = New System.Drawing.Size(128, 24)
        Me.btn_voirFicheExploitant.TabIndex = 0
        Me.btn_voirFicheExploitant.Text = "    Voir la fiche"
        Me.btn_voirFicheExploitant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpOrganisme
        '
        Me.grpOrganisme.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_dateControle)
        Me.grpOrganisme.Controls.Add(Me.Label16)
        Me.grpOrganisme.Controls.Add(Me.Label17)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_heureDebut)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_heureFin)
        Me.grpOrganisme.Controls.Add(Me.Label19)
        Me.grpOrganisme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpOrganisme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpOrganisme.Location = New System.Drawing.Point(2, 19)
        Me.grpOrganisme.Name = "grpOrganisme"
        Me.grpOrganisme.Size = New System.Drawing.Size(341, 75)
        Me.grpOrganisme.TabIndex = 2
        Me.grpOrganisme.TabStop = False
        Me.grpOrganisme.Text = "Organisme d'inspection"
        '
        'diagnosticRecap_organisme_dateControle
        '
        Me.diagnosticRecap_organisme_dateControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagnosticRecap_organisme_dateControle.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.diagnosticRecap_organisme_dateControle.Location = New System.Drawing.Point(139, 23)
        Me.diagnosticRecap_organisme_dateControle.Name = "diagnosticRecap_organisme_dateControle"
        Me.diagnosticRecap_organisme_dateControle.Size = New System.Drawing.Size(129, 20)
        Me.diagnosticRecap_organisme_dateControle.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(11, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 16)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Date du contrôle : "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(1, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(130, 16)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Heure début / fin : "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_organisme_heureDebut
        '
        Me.diagnosticRecap_organisme_heureDebut.Location = New System.Drawing.Point(139, 49)
        Me.diagnosticRecap_organisme_heureDebut.Name = "diagnosticRecap_organisme_heureDebut"
        Me.diagnosticRecap_organisme_heureDebut.Size = New System.Drawing.Size(56, 20)
        Me.diagnosticRecap_organisme_heureDebut.TabIndex = 1
        '
        'diagnosticRecap_organisme_heureFin
        '
        Me.diagnosticRecap_organisme_heureFin.Location = New System.Drawing.Point(211, 49)
        Me.diagnosticRecap_organisme_heureFin.Name = "diagnosticRecap_organisme_heureFin"
        Me.diagnosticRecap_organisme_heureFin.Size = New System.Drawing.Size(56, 20)
        Me.diagnosticRecap_organisme_heureFin.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(196, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(14, 16)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "/"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'label_pulveBonEtat
        '
        Me.label_pulveBonEtat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label_pulveBonEtat.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_pulveBonEtat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_pulveBonEtat.Location = New System.Drawing.Point(688, 12)
        Me.label_pulveBonEtat.Name = "label_pulveBonEtat"
        Me.label_pulveBonEtat.Size = New System.Drawing.Size(311, 24)
        Me.label_pulveBonEtat.TabIndex = 15
        Me.label_pulveBonEtat.Text = "Pulvérisateur en bon état"
        Me.label_pulveBonEtat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'conclusion_pictoEtat
        '
        Me.conclusion_pictoEtat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conclusion_pictoEtat.Image = CType(resources.GetObject("conclusion_pictoEtat.Image"), System.Drawing.Image)
        Me.conclusion_pictoEtat.Location = New System.Drawing.Point(666, 12)
        Me.conclusion_pictoEtat.Name = "conclusion_pictoEtat"
        Me.conclusion_pictoEtat.Size = New System.Drawing.Size(16, 16)
        Me.conclusion_pictoEtat.TabIndex = 16
        Me.conclusion_pictoEtat.TabStop = False
        '
        'btnSignClient
        '
        Me.btnSignClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSignClient.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignClient.ForeColor = System.Drawing.Color.White
        Me.btnSignClient.Image = Global.Crodip_agent.Resources.btn_Signture
        Me.btnSignClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSignClient.Location = New System.Drawing.Point(716, 653)
        Me.btnSignClient.Name = "btnSignClient"
        Me.btnSignClient.Size = New System.Drawing.Size(148, 24)
        Me.btnSignClient.TabIndex = 17
        Me.btnSignClient.Text = "    Signature client"
        Me.btnSignClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSignAgent
        '
        Me.btnSignAgent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSignAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignAgent.ForeColor = System.Drawing.Color.White
        Me.btnSignAgent.Image = CType(resources.GetObject("btnSignAgent.Image"), System.Drawing.Image)
        Me.btnSignAgent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSignAgent.Location = New System.Drawing.Point(716, 619)
        Me.btnSignAgent.Name = "btnSignAgent"
        Me.btnSignAgent.Size = New System.Drawing.Size(141, 24)
        Me.btnSignAgent.TabIndex = 18
        Me.btnSignAgent.Text = "        Signature inspecteur"
        Me.btnSignAgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ContratCommercial
        '
        Me.btn_ContratCommercial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ContratCommercial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ContratCommercial.Enabled = False
        Me.btn_ContratCommercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ContratCommercial.ForeColor = System.Drawing.Color.White
        Me.btn_ContratCommercial.Image = CType(resources.GetObject("btn_ContratCommercial.Image"), System.Drawing.Image)
        Me.btn_ContratCommercial.Location = New System.Drawing.Point(194, 619)
        Me.btn_ContratCommercial.Name = "btn_ContratCommercial"
        Me.btn_ContratCommercial.Size = New System.Drawing.Size(184, 24)
        Me.btn_ContratCommercial.TabIndex = 19
        Me.btn_ContratCommercial.Text = "      Contrat commercial"
        Me.btn_ContratCommercial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Annuler
        '
        Me.btn_Annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Annuler.ForeColor = System.Drawing.Color.White
        Me.btn_Annuler.Image = CType(resources.GetObject("btn_Annuler.Image"), System.Drawing.Image)
        Me.btn_Annuler.Location = New System.Drawing.Point(865, 653)
        Me.btn_Annuler.Name = "btn_Annuler"
        Me.btn_Annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_Annuler.TabIndex = 51
        Me.btn_Annuler.Text = "    Annuler"
        Me.btn_Annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmdiagnostic_recap
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Annuler)
        Me.Controls.Add(Me.btn_ContratCommercial)
        Me.Controls.Add(Me.btnSignAgent)
        Me.Controls.Add(Me.btnSignClient)
        Me.Controls.Add(Me.label_pulveBonEtat)
        Me.Controls.Add(Me.conclusion_pictoEtat)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btn_finalisationDiag_valider)
        Me.Controls.Add(Me.btn_finalisationDiag_imprimerSynthese)
        Me.Controls.Add(Me.btn_finalisationDiag_modifierDiag)
        Me.Controls.Add(Me.btn_finalisationDiag_imprimerRapport)
        Me.Controls.Add(Me.laTitre)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmdiagnostic_recap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "diagnostic_recap"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.m_bsDiag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMateriel.ResumeLayout(False)
        Me.grpMateriel.PerformLayout()
        Me.grpProprio.ResumeLayout(False)
        Me.grpOrganisme.ResumeLayout(False)
        Me.grpOrganisme.PerformLayout()
        CType(Me.conclusion_pictoEtat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub diagnostic_recap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.ControlBox = False
        CSEnvironnement.checkDateTimePicker(diagnosticRecap_organisme_dateControle)
        If m_DiagMode <> GlobalsCRODIP.DiagMode.CTRL_SIGNATURE Then
            'Propriété a mettre obligatoirement par programme
            Me.laTitre.Text = "     Visualisation du contrôle"
            Me.btn_Annuler.Visible = False
        Else
            Me.laTitre.Text = "     Signature du contrôle"
            Me.btn_Annuler.Visible = True
        End If
        '###########################################################################
        '########               Chargement Organisme d'inspection           ########
        '###########################################################################
        Try
            diagnosticRecap_organisme_dateControle.Text = CDate(m_diagnostic.controleDateDebut).ToShortDateString()
            diagnosticRecap_organisme_heureDebut.Text = CDate(m_diagnostic.controleDateDebut).ToShortTimeString
            If (m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_COMPLET Or m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_CV) And
                m_diagnostic.diagRemplacementId = "" Then
                'Remplacement de la date de fin si on n'est pas en remplacement
                m_diagnostic.controleDateFin = CSDate.ToCRODIPString(Date.Now)
            End If
            diagnosticRecap_organisme_heureFin.Text = CDate(m_diagnostic.controleDateFin).ToShortTimeString
        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap - Chargement Organisme d'inspection : " & ex.Message.ToString)
        End Try

        '###########################################################################
        '########             Chargement Propriétaire du materiel           ########
        '###########################################################################
        AfficheProprietaire()
        '###########################################################################
        '########                   Chargement contexte controle            ########
        '###########################################################################

        '###########################################################################
        '########                     Chargement Materiel                   ########
        '###########################################################################
        AffichePulverisateur()

        For Each tmpDiagnosticItem As DiagnosticItem In m_diagnostic.diagnosticItemsLst.items
            If Not tmpDiagnosticItem Is Nothing Then
                If Not tmpDiagnosticItem.itemCodeEtat Is Nothing Then
                    ' Si on a un code état différent de OK, on l'affiche dans le bilan
                    If tmpDiagnosticItem.itemCodeEtat <> DiagnosticItem.EtatDiagItemOK Then

                        If tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMINEUR Then
                            'Mineur
                            If conclusionDiagnostique = GlobalsCRODIP.enumConclusionDiag.OK Then
                                conclusionDiagnostique = GlobalsCRODIP.enumConclusionDiag.OK_AVECMINEEUR
                            End If
                        End If
                        If tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR Then
                            'Majeur
                            conclusionDiagnostique = GlobalsCRODIP.enumConclusionDiag.NOK
                        End If
                        If tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJPRELIM Then
                            'Majeur Prelim
                            conclusionDiagnostique = GlobalsCRODIP.enumConclusionDiag.NOK_PRELIM
                        End If
                    End If

                End If
            End If
        Next


        ' Conclusion sur l'etat du controle
        Select Case conclusionDiagnostique
            Case GlobalsCRODIP.enumConclusionDiag.OK
                m_diagnostic.controleEtat = Diagnostic.controleEtatOK
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(1)
                label_pulveBonEtat.Text = "Pulvérisateur en bon état"
            Case GlobalsCRODIP.enumConclusionDiag.OK_AVECMINEEUR
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(1)
                m_diagnostic.controleEtat = Diagnostic.controleEtatOK
                label_pulveBonEtat.Text = "Pulvérisateur en bon état"
            Case GlobalsCRODIP.enumConclusionDiag.NOK
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(0)
                m_diagnostic.controleEtat = Diagnostic.controleEtatNOKCV
                label_pulveBonEtat.Text = "Défaut(s) sur le pulvérisateur"
            Case GlobalsCRODIP.enumConclusionDiag.NOK_PRELIM
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(0)
                m_diagnostic.controleEtat = Diagnostic.controleEtatNOKCC
                label_pulveBonEtat.Text = "Défaut(s) sur le pulvérisateur"
            Case Else
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(0)
                m_diagnostic.controleEtat = Diagnostic.controleEtatNOKCV
                label_pulveBonEtat.Text = "Défaut(s) sur le pulvérisateur"

        End Select
        'Me.SelectNextControl(diagnosticRecap_organisme_lieuControle, True, True, True, True)
        btn_finalisationDiag_modifierDiag.Focus()
        btn_finalisationDiag_modifierDiag.Select()
        If m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_VISU Then
            grpOrganisme.Enabled = False
            grpProprio.Enabled = False
            grpMateriel.Enabled = False
            btn_finalisationDiag_modifierDiag.Enabled = False
            btn_finalisationDiag_valider.Text = "Retour"
        End If
        btn_finalisationDiag_modifierDiag.Enabled = m_DiagMode <> GlobalsCRODIP.DiagMode.CTRL_VISU

        '##################
        'Generation de l'apperçu du rapport
        '###################
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Or m_diagnostic.CCFileName = "" Then
            rbEtatCC.Visible = False
            btn_ContratCommercial.Visible = False
            btn_finalisationDiag_imprimerRapport.Top = btn_ContratCommercial.Top
            btn_finalisationDiag_imprimerRapport.Left = btn_ContratCommercial.Left
        End If
        createEtatRapportInspection(False)

        '======================
        ' Boutons de Signatures
        '=======================
        btnSignClient.Visible = m_oAgent.isSignElecActive
        btnSignAgent.Visible = m_oAgent.isSignElecActive

        ActiveDesactiveBtnsignature()

        If (m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_SIGNATURE Or m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_VISUPDFS) Then
            btn_finalisationDiag_modifierDiag.Visible = False
            desactiveModifications()
        End If

        If GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            Me.Text = "Récapitulatif du diagnostique "
            Me.btn_ContratCommercial.Visible = False
            Me.btn_finalisationDiag_imprimerSynthese.Visible = False
            rbEtatCC.Visible = False
            rbEtatSM.Visible = False
            btnAppercu.Visible = False
        Else
            If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
                Me.Text = "Récapitulatif du diagnostique " & " - Mode Simplifié - "
            Else
                Me.Text = "Crodip .::. Récapitulatif du diagnostique "

            End If

        End If


    End Sub

    Private Sub AffichePulverisateur()
        Try
            MarquesManager.populateCombobox(GlobalsCRODIP.GLOB_XML_EMPLACEMENTIDENTIFICATION, cbx_diagnosticRecap_materiel_EmplacementIdentification, "/root", True)
            'diagnosticRecap_materiel_identifiant.Text = m_Pulverisateur.numeroNational
            'diagnosticRecap_materiel_marque.Text = m_diagnostic.pulverisateurMarque
            'diagnosticRecap_materiel_modele.Text = m_diagnostic.pulverisateurModele
            'Categorie
            'diagnosticRecap_materiel_type.Text = m_diagnostic.pulverisateurType
            'diagnosticRecap_materiel_categorie.Text = m_diagnostic.pulverisateurCategorie
            'Emplacement Identification
            cbx_diagnosticRecap_materiel_EmplacementIdentification.Text = m_diagnostic.pulverisateurEmplacementIdentification



        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap.AffichePulveristeur ERR : " & ex.Message.ToString)
        End Try


    End Sub
    ' Modifier le diag
    Private Sub btn_finalisationDiag_modifierDiag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_modifierDiag.Click
        If MdiParent Is Nothing Then
            'En cas de tests
            Close()
            Exit Sub
        End If
        'Récupération des infos de la fenêtre
        GetInfos()
        Dim ofrmDiag As Form = Nothing
        'Si on a une fenêtre Précédente on prend celle_là , sinon on recherche la bonne
        If m_frmdiagnostic IsNot Nothing Then
            ofrmDiag = m_frmdiagnostic
        Else
            If m_diagnostic.controleEtat <> Diagnostic.controleEtatNOKCC Then
                'Activation de la fenêtre
                For Each oForm As Form In MdiParent.MdiChildren
                    If TypeOf oForm Is FrmDiagnostique Then
                        ofrmDiag = oForm
                        Exit For
                    End If
                Next
            End If
            For Each oForm As Form In MdiParent.MdiChildren
                If TypeOf oForm Is controle_preliminaire Then
                    ofrmDiag = oForm
                    Exit For
                End If
            Next
        End If
        If ofrmDiag IsNot Nothing Then
            'ofrmDiag.WindowState = FormWindowState.Maximized
            ActivateMdiChild(ofrmDiag)
            'ofrmDiag.Activate()
            Me.Close()
        End If
    End Sub

    ' Validation
    Private Sub btn_finalisationDiag_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_valider.Click
        sender.Enabled = False
        If m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_VISU Then
            CloseDiagnostic()
            Exit Sub
        End If
        If isValider Then
            If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
                CloseDiagnostic()
                Exit Sub
            End If
            If m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_COMPLET Or m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_CV Then
                If m_oStructure.isFacturationActive Then
                    Dim ofrmFact As New frmdiagnostic_facturationCoProp()
                    ofrmFact.setContexte(m_diagnostic, m_oAgent)
                    ofrmFact.ShowDialog()
                End If
                'On ouvre la fenetre de l'enquete
                Dim ofrm As New diagnostic_satisfaction()
                ofrm.Setcontext(m_diagnostic, m_oAgent)
                TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
                Statusbar.clear()
            Else
                CloseDiagnostic()
            End If

        Else
            If checkForm() Then
                If (m_oAgent.isSignElecActive) Then
                    Dim bsign As Boolean = False
                    Dim bSignRI As Boolean = True
                    Dim bSignCC As Boolean = True
                    Dim Message As String = ""
                    If Not (m_diagnostic.isSignRIAgent And m_diagnostic.isSignRIClient) Then
                        Message = "Attention, le rapport d'inspection n'est pas signé"
                        bSignRI = False
                    End If
                    If Not GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE And m_diagnostic.CCFileName <> "" Then
                        'PAs en mode simplifié et j'ai un contrat
                        If Not (m_diagnostic.isSignCCAgent And m_diagnostic.isSignCCClient) Then
                            Message = "Attention, le contrat commercial n'est pas signé"
                            bSignCC = False
                        End If
                    Else
                        'En mode simplifié, pas de contrat commercial
                        bSignCC = True
                    End If
                    bsign = (bSignRI And bSignCC)

                    If Not bsign Then
                        If Not bSignRI And Not bSignCC Then
                            Message = "Attention, vos documents ne sont pas signés"
                        End If
                        SendKeys.Send("{TAB}")
                        If MsgBox(Message + ",voulez-vous continuer ?", MsgBoxStyle.YesNo, "Validation du contrôle") = MsgBoxResult.No Then
                            sender.Enabled = True
                            Exit Sub
                        End If
                    End If
                End If
                Dim oResult As MsgBoxResult = MsgBoxResult.Yes
                If m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_COMPLET Or m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_CV Then
                    oResult = MsgBox("Attention, la validation du contrôle est définitive, vous ne pourrez plus revenir en arrière. Etes-vous sûr ?", MsgBoxStyle.YesNo, "Validation du contrôle")
                End If
                If oResult = MsgBoxResult.Yes Then
                    desactiveModifications()
                    btnSignAgent.Enabled = False
                    btnSignClient.Enabled = False
                    SauvegarderDiagnostic()
                    btn_Annuler.Enabled = False
                    MsgBox("Vous pouvez maintenant imprimer vos documents.", MsgBoxStyle.Information)
                End If
            End If


            sender.Enabled = True
        End If
    End Sub

    Private Sub desactiveModifications()
        diagnosticRecap_organisme_heureDebut.Enabled = False
        diagnosticRecap_organisme_heureFin.Enabled = False
        cbx_diagnosticRecap_materiel_EmplacementIdentification.Enabled = False
        diagnosticRecap_organisme_dateControle.Enabled = False
        btn_voirFicheExploitant.Enabled = False
        btn_voirFiche_Pulve.Enabled = False
    End Sub

    Private Function SauvegarderDiagnostic() As Boolean
        Dim bReturn As Boolean
        Try
            Try
                CSDebug.dispInfo("frmDiagnosticRecap.sauvegarderDiagnostic Debut")
                Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DIAG_SAVING, True)
                If m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_COMPLET Or m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_CV Then
                    'Lecture de la fenêtre
                    GetInfos()
                    '
                    'Calcul de la date de prochain controle
                    m_diagnostic.CalculDateProchainControle()

                    Statusbar.display("Mise à jour de l'exploitant", True)
                    m_Exploit.numeroSiren = m_diagnostic.proprietaireNumeroSiren
                    m_Exploit.dateDernierControle = m_diagnostic.controleDateDebut
                    ExploitationManager.save(m_Exploit, m_oAgent)
                    globFormAccueil.RefreshLVIExploitation(m_Exploit.id)

                    Statusbar.display("Mise à jour du pulvérisateur", True)
                    'Calcul de la date de prochain controle
                    m_Pulverisateur.dateProchainControle = m_diagnostic.pulverisateurDateProchainControle
                    m_Pulverisateur.emplacementIdentification = m_diagnostic.pulverisateurEmplacementIdentification
                    m_Pulverisateur.modeUtilisation = m_diagnostic.pulverisateurModeUtilisation
                    m_Pulverisateur.nombreExploitants = m_diagnostic.pulverisateurNbreExploitants

                    m_Pulverisateur.SetControleEtat(m_diagnostic)
                    m_Pulverisateur.DecodageAutomatiqueDefauts(m_diagnostic.diagnosticItemsLst.Values)
                    PulverisateurManager.save(m_Pulverisateur, m_Exploit.id, m_oAgent)


                    ' Enregistrement du diag
                    Statusbar.display("Récupération d'un nouvel ID", True)
                    Dim tmpNewDiagId As String
                    'tmpNewDiagId = InputBox("DiagID", "Entrez le numéro du diag", m_oagent.idStructure & "-" & m_oagent.id & "-")
                    tmpNewDiagId = DiagnosticManager.getNewId(m_oAgent)
                    m_diagnostic.id = tmpNewDiagId
                    CSDebug.dispInfo("frmDiagnosticRecap.sauvegarderDiagnostic GetID = " & tmpNewDiagId)


                    Statusbar.display("Mise à jour du manomètre et banc de mesures", True)
                    m_diagnostic.setUtiliseBancEtMano(m_oAgent)

                    'Incrément du nombre de diag réalisé
                    My.Settings.nbControlesAvantAlerte = My.Settings.nbControlesAvantAlerte + 1
                    My.Settings.Save()

                    'on remet les Id à "" pour forcer la création d'un nouvel ID
                    m_diagnostic.diagnosticHelp551.id = ""
                    m_diagnostic.diagnosticHelp5621.id = ""
                    m_diagnostic.diagnosticHelp552.id = ""
                    m_diagnostic.diagnosticHelp5622.id = ""
                    m_diagnostic.diagnosticHelp811.id = ""
                    m_diagnostic.diagnosticHelp8312.id = ""
                    m_diagnostic.diagnosticInfosComplementaires.id = ""

                End If

                If m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_COMPLET Or m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_CV Or m_DiagMode = GlobalsCRODIP.DiagMode.CTRL_SIGNATURE Then

                    Statusbar.display("Génération du rapport d'inspection", True)
                    If createEtatRapportInspection(True) Then
                        Statusbar.display("Génération du rapport de synthèse des mesures", True)
                        If Not createEtatSyntheseDesMesures(True) Then
                            CSDebug.dispError("Erreur en génération de l'état de synthèse des mesures")
                        End If
                        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Or
                            GlobalsCRODIP.GLOB_ENV_MODEFORMATION Or
                            (m_diagnostic.isContrevisiteImmediate And m_diagnostic.isGratuit) Then
                            'Pas de génération du contrat commercial
                        Else
                            Statusbar.display("Génération du Contrat Commercial", True)
                            If Not createEtatContratCommercial(True) Then
                                CSDebug.dispError("Erreur en génération du Contrat Commercial")
                            End If
                        End If

                        'diagnosticCourant.controleTarif = diagnosticCourantTarif.ToString
                        m_diagnostic.dateModificationAgent = CSDate.ToCRODIPString(Date.Now)
                        Statusbar.display("Sauvegarde du diagnostic" & m_diagnostic.id, True)
                        CSDebug.dispInfo("frmDiagnosticRecap.sauvegarderDiagnostic [" & m_diagnostic.id & "]")
                        CSDebug.dispInfo("frmDiagnosticRecap.sauvegarderDiagnostic [" & m_diagnostic.id & "] PulverisateurID = " & m_diagnostic.pulverisateurId)
                        CSDebug.dispInfo("frmDiagnosticRecap.sauvegarderDiagnostic [" & m_diagnostic.id & "] m_Pulverisateur.ID = " & m_Pulverisateur.id)
                        CSDebug.dispInfo("frmDiagnosticRecap.sauvegarderDiagnostic [" & m_diagnostic.id & "] proprietaireId = " & m_diagnostic.proprietaireId)
                        CSDebug.dispInfo("frmDiagnosticRecap.sauvegarderDiagnostic [" & m_diagnostic.id & "] m_Exploitation.ID = " & m_Exploit.id)
                        Dim bSave As Boolean
                        bSave = DiagnosticManager.save(m_diagnostic)
                        If Not bSave Then
                            CSDebug.dispFatal("Diagnostic-recap.btn_finalisationDiag_valider_Click ERR : ERREUR EN SAUVEGARDE DE DIAGNOSTIQUE=> FERMERTURE DE l'APPLICATION, CONTACTER LE CRODIP")
                            MsgBox("ERREUR EN SAUVEGARDE DE DIAGNOSTIQUE => FERMERTURE DE l'APPLICATION, CONTACTER LE CRODIP")
                            Application.Exit()
                        End If

                        'Si le Controle remplace un ancien Diag
                        If Not String.IsNullOrEmpty(m_diagnostic.diagRemplacementId) Then
                            Dim oDiagRemplace As Diagnostic
                            oDiagRemplace = DiagnosticManager.getDiagnosticById(m_diagnostic.diagRemplacementId)
                            Debug.Assert(oDiagRemplace.id <> "")
                            If oDiagRemplace.id <> "" Then
                                oDiagRemplace.isSupprime = True
                                oDiagRemplace.diagRemplacementId = m_diagnostic.id 'Diag de remplacement
                                DiagnosticManager.save(oDiagRemplace)
                            End If
                        End If



                        ' On met en place les boutons
                        btn_finalisationDiag_valider.Text = "Poursuivre"
                        btn_finalisationDiag_imprimerRapport.Enabled = True
                        btn_finalisationDiag_modifierDiag.Enabled = False
                        btn_finalisationDiag_imprimerSynthese.Enabled = True
                        btn_ContratCommercial.Enabled = True

                        'Désactivation de l'apperçu
                        btnAppercu.Enabled = False
                        rbEtatRI.Enabled = False
                        rbEtatSM.Enabled = False
                        rbEtatCC.Enabled = False
                        CrystalReportViewer1.Enabled = False
                        isValider = True
                        Statusbar.display("", False)
                        bReturn = True
                    Else
                        CSDebug.dispFatal("Erreur en génération de rapport, recommencez. En cas de récidive, prevenez le CRODIP")
                    End If
                End If
            Catch ex As Exception
                CSDebug.dispFatal("frmDiagnostic_Recap:SauvegarderDiagnostic : Erreur lors de l'enregistrement du diag : " & ex.Message.ToString)
                Statusbar.display("frmDiagnostic_Recap:SauvegarderDiagnostic Erreur lors de l'enregistrement du contrôle.", False)
                bReturn = False
            End Try

        Catch ex As Exception
            CSDebug.dispFatal("Diagnostic_recap.SauvegarderDiagnostic ERR : " & ex.Message.ToString)
            bReturn = False

        End Try
    End Function
    Private Function GetInfos() As Boolean
        Dim bReturn As Boolean
        Try
            'Dates de Controles
            m_diagnostic.controleDateDebut = CDate(diagnosticRecap_organisme_dateControle.Text).ToShortDateString()
            m_diagnostic.controleDateFin = CDate(diagnosticRecap_organisme_dateControle.Text).ToShortDateString()
            If m_diagnostic.controleEtat = "" Then
                m_diagnostic.controleEtat = Diagnostic.controleEtatNOKCV
            End If
            Dim szH As String = diagnosticRecap_organisme_heureDebut.Text
            If Not String.IsNullOrEmpty(szH) Then
                Dim dDiag, dH As Date
                dH = CDate(szH)
                dDiag = CDate(m_diagnostic.controleDateDebut)
                m_diagnostic.controleDateDebut = dDiag.ToShortDateString() & " " & dH.ToShortTimeString()
            End If
            szH = diagnosticRecap_organisme_heureFin.Text
            If Not String.IsNullOrEmpty(szH) Then
                Dim dDiag, dH As Date
                dH = CDate(szH)
                dDiag = CDate(m_diagnostic.controleDateFin)
                m_diagnostic.controleDateFin = dDiag.ToShortDateString() & " " & dH.ToShortTimeString()
            End If
            'Emplacemement identification
            m_diagnostic.pulverisateurEmplacementIdentification = CSDb.secureString(cbx_diagnosticRecap_materiel_EmplacementIdentification.Text)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_recap.GetInfos ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' génération du rapport de synthèses des mesures
    ''' </summary>
    ''' <remarks></remarks>
    Private Function createEtatSyntheseDesMesures(pExportPDF As Boolean) As Boolean
        Dim _PathToSynthesePDF As String
        Dim bReturn As Boolean = False
        Try
            Dim oEtat As New EtatSyntheseMesures(m_diagnostic)
            oEtat.genereEtat(pExportPDF)
            If pExportPDF Then
                _PathToSynthesePDF = oEtat.getFileName()
                m_diagnostic.SMFileName = _PathToSynthesePDF
            Else
                CrystalReportViewer1.ReportSource = oEtat.getReportdocument
                CrystalReportViewer1.Zoom(1) 'Page Width
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("createEtatSyntheseDesMesures ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ' rapport D'inspection
    Private Function createEtatRapportInspection(pExportDPF As Boolean) As Boolean
        Dim bReturn As Boolean
        Dim pathRapport As String
        Try
            Dim oEtat As New EtatRapportInspection(m_diagnostic)
            oEtat.genereEtat(pExportDPF)
            If pExportDPF Then
                pathRapport = oEtat.getFileName()
                m_diagnostic.RIFileName = pathRapport
                bReturn = File.Exists(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & pathRapport)
            Else
                CrystalReportViewer1.ReportSource = oEtat.getReportdocument
                CrystalReportViewer1.Zoom(1) 'Page Width
            End If
        Catch ex As Exception
            CSDebug.dispError("createEtatRapportInspection ERR : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function 'createEtatRapportInspection
    ''' <summary>
    ''' Affichage du contrat Commercial
    ''' </summary>
    ''' <param name="pExportDPF"></param>
    ''' <returns></returns>
    Private Function createEtatContratCommercial(pExportDPF As Boolean) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oEtat As New EtatContratCommercial(m_diagnostic)
            oEtat.genereEtat(pExportDPF)
            If pExportDPF Then
                If File.Exists(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & m_diagnostic.CCFileName) Then
                    File.Delete(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & m_diagnostic.CCFileName)
                End If
                m_diagnostic.CCFileName = oEtat.getFileName()
                bReturn = File.Exists(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & oEtat.getFileName())
            Else
                CrystalReportViewer1.ReportSource = oEtat.getReportdocument
                CrystalReportViewer1.Zoom(1) 'Page Width
            End If
        Catch ex As Exception
            CSDebug.dispError("createEtatContratCommercial ERR : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function 'createContratCommercial

    Private Sub btn_finalisationDiag_imprimerRapport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_imprimerRapport.Click
        Try
            ' On affiche le PDF rempli
            CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & m_diagnostic.RIFileName)
        Catch ex As Exception
            CSDebug.dispError("[Erreur] - Génération Rapport d'Inspection : " & ex.Message.ToString & vbNewLine)
        End Try
    End Sub


    Private Sub btn_finalisationDiag_imprimerSynthese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_imprimerSynthese.Click


        Try
            Statusbar.display("Affichage du rapport de synthèse", True)
            ' On affiche le PDF rempli
            CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & m_diagnostic.SMFileName)
            Statusbar.display("", True)
        Catch ex As Exception
            CSDebug.dispError("Erreur lors de la génération de l'état des Debit de buses : " & ex.Message.ToString)
        End Try

    End Sub
    Private Function checkForm() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        If cbx_diagnosticRecap_materiel_EmplacementIdentification.Text = "" Then
            MsgBox("Vous devez renseigner l'emplacement de l'identification")
            cbx_diagnosticRecap_materiel_EmplacementIdentification.Focus()
            bReturn = False
        End If
        If m_diagnostic.proprietaireNumeroSiren = "" Then
            MsgBox("Vous devez renseigner le numéro de SIREN du propriétaire")
            bReturn = False
        End If
        'Vérification des heures de controle
        If Not CSDate.CheckHours(diagnosticRecap_organisme_heureDebut.Text) Then

            MsgBox("Format heure début incorrect : HH:MM")
            bReturn = False
        End If
        If Not CSDate.CheckHours(diagnosticRecap_organisme_heureFin.Text) Then

            MsgBox("Format heure fin incorrect : HH:MM")
            bReturn = False
        End If
        If bReturn Then
            If DateDiff(DateInterval.Minute, CDate(diagnosticRecap_organisme_heureDebut.Text), CDate(diagnosticRecap_organisme_heureFin.Text)) < 0 Then
                MsgBox("L'heure de fin doit être supérieure à l'heure de début")
                bReturn = False

            End If
        End If

        Return bReturn
    End Function

    Private Sub diagnosticRecap_proprietaire_numSiren_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 9)
        End If

    End Sub

    Private Sub diagnosticRecap_materiel_EmplacementIdentification_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "Alphanumerique")
    End Sub

    Private Sub btn_FichePulve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub fichePulve_isPneumatique_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub fichePulve_isJetPorte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub fichePulve_isJetProjete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_voirFiche_Pulve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        displayFichePulve()
    End Sub
    Private Sub displayFichePulve()
        ' Mise à jour de la barre de status
        Statusbar.display("Chargement du pulvérisateur n°" & m_diagnostic.pulverisateurId)

        'Recupération de l'emplacement de l'identification 
        m_Pulverisateur.emplacementIdentification = cbx_diagnosticRecap_materiel_EmplacementIdentification.Text
        ' Affichage de la fiche du pulvérisateur

        Dim formEdition_fiche_pulve As New ajout_pulve2()
        formEdition_fiche_pulve.setContexte(ajout_pulve2.MODE.VERIF, m_oAgent, m_Pulverisateur, m_Exploit, m_diagnostic)
        formEdition_fiche_pulve.ShowDialog(Me.MdiParent)
        m_diagnostic.setPulverisateur(m_Pulverisateur)
        'AffichePulverisateur()
    End Sub



    Private Sub btn_voirFicheExploitant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Mise à jour de la barre de status
        Statusbar.display("Chargement de l'exploitant n°" & m_diagnostic.proprietaireId)

        ' Affichage de la fiche du pulvérisateur
        'Récupératino du numéri de SIREN
        'm_Exploit.numeroSiren = diagnosticRecap_proprietaire_numSiren.Text
        Dim formEdition_fiche_pulve As New fiche_exploitant()
        formEdition_fiche_pulve.setContexte(True, m_Exploit, m_oAgent)
        formEdition_fiche_pulve.DisplayNomEtPrenomduRepresentant(True)
        '        formEdition_fiche_pulve.SetFormRecapDiag(True)
        formEdition_fiche_pulve.ShowDialog(Me.MdiParent)
        m_diagnostic.SetProprietaire(m_Exploit)
        'AfficheProprietaire()

    End Sub

    Private Sub AfficheProprietaire()
        Try
            'diagnosticRecap_proprietaire_raisonSociale.Text = m_diagnostic.proprietaireRaisonSociale
            'diagnosticRecap_proprietaire_nom.Text = m_diagnostic.proprietaireNom & " " & m_diagnostic.proprietairePrenom
            'diagnosticRecap_proprietaire_numSiren.Text = m_diagnostic.proprietaireNumeroSiren
            If String.IsNullOrEmpty(m_diagnostic.proprietaireNumeroSiren) Then
                '   diagnosticRecap_proprietaire_numSiren.Enabled = True
                '  diagnosticRecap_proprietaire_numSiren.ReadOnly = False
            End If
            'diagnosticRecap_proprietaire_ville.Text = m_diagnostic.proprietaireCommune
        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap - Chargement Propriétaire du materiel : " & ex.Message.ToString)
        End Try

    End Sub
    Private Sub CloseDiagnostic()
        ' On vide les infos de session
        m_diagnostic = Nothing
        m_Pulverisateur = Nothing
        'Fermeture de fenpetres Filles de diag
        Dim ofrm As Form
        Dim ofrmAccueil As accueil
        For Each ofrm In MdiParent.MdiChildren
            If Not TypeOf ofrm Is accueil Then
                ofrm.Close()
            Else
                ofrmAccueil = ofrm
                ofrmAccueil.RefreshLVIExploitation(m_Exploit.id)
                ofrmAccueil.loadListPulveExploitation(False)
                ofrmAccueil.WindowState = FormWindowState.Maximized
            End If
        Next

        ' On ferme le contrôle
        Statusbar.clear()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub btnAppercu_Click(sender As Object, e As EventArgs) Handles btnAppercu.Click
        AppercuDocument()
    End Sub

    Private Sub AppercuDocument()
        If rbEtatRI.Checked Then
            createEtatRapportInspection(False)
        End If
        If rbEtatSM.Checked Then
            createEtatSyntheseDesMesures(False)
        End If
        If rbEtatCC.Checked Then
            createEtatContratCommercial(False)
        End If
    End Sub

    Private Sub btn_voirFicheExploitant_Click_1(sender As Object, e As EventArgs) Handles btn_voirFicheExploitant.Click
        Dim formEdition_fiche_pulve As New fiche_exploitant()
        formEdition_fiche_pulve.setContexte(True, m_Exploit, m_oAgent)
        formEdition_fiche_pulve.DisplayNomEtPrenomduRepresentant(True)
        '        formEdition_fiche_pulve.SetFormRecapDiag(True)
        formEdition_fiche_pulve.ShowDialog(Me.MdiParent)
        m_diagnostic.SetProprietaire(m_Exploit)

    End Sub

    Private Sub btn_voirFiche_Pulve_Click_1(sender As Object, e As EventArgs) Handles btn_voirFiche_Pulve.Click
        displayFichePulve()

    End Sub

    Private Sub btnSignClient_Click(sender As Object, e As EventArgs) Handles btnSignClient.Click
        If checkForm() Then
            Signatureclient()
        End If
    End Sub

    Private Sub btnSignAgent_Click(sender As Object, e As EventArgs) Handles btnSignAgent.Click
        If checkForm() Then

            SignatureAgent()
        End If
    End Sub

    Public Sub Signatureclient()
        Dim ofrm As frmSignClient = Nothing
        If rbEtatRI.Checked Then
            ofrm = frmSignClient.getfrmSignature(m_diagnostic, SignMode.RICLIENT, m_oAgent)
        End If
        If rbEtatCC.Checked Then
            ofrm = frmSignClient.getfrmSignature(m_diagnostic, SignMode.CCCLIENT, m_oAgent)
        End If
        If ofrm IsNot Nothing Then
            ofrm.ShowDialog()
            If m_diagnostic.SignRIAgent IsNot Nothing Or m_diagnostic.SignRIClient IsNot Nothing Then
                desactiveModifications()
            End If
        End If

        ActiveDesactiveBtnsignature()

    End Sub
    Private Sub ActiveDesactiveBtnsignature()
        If rbEtatRI.Checked Then
            btnSignAgent.Enabled = Not m_diagnostic.isSignRIAgent
            btnSignClient.Enabled = Not m_diagnostic.isSignRIClient
        End If
        If rbEtatCC.Checked Then
            btnSignAgent.Enabled = Not m_diagnostic.isSignCCAgent
            btnSignClient.Enabled = Not m_diagnostic.isSignCCClient
        End If

    End Sub

    Public Sub SignatureAgent()
        Dim ofrm As frmSignClient = Nothing
        If rbEtatRI.Checked Then
            ofrm = frmSignClient.getfrmSignature(m_diagnostic, SignMode.RIAGENT, m_oAgent)
        End If
        If rbEtatCC.Checked Then
            ofrm = frmSignClient.getfrmSignature(m_diagnostic, SignMode.CCAGENT, m_oAgent)
        End If
        If ofrm IsNot Nothing Then
            ofrm.ShowDialog()
            If m_diagnostic.SignRIAgent IsNot Nothing Or m_diagnostic.SignRIClient IsNot Nothing Then
                desactiveModifications()
            End If

            ActiveDesactiveBtnsignature()

        End If
    End Sub

    Private Sub rbEtatRISMCC_CheckedChanged(sender As Object, e As EventArgs) Handles rbEtatRI.CheckedChanged, rbEtatSM.CheckedChanged, rbEtatCC.CheckedChanged
        Dim oRB As RadioButton = CType(sender, RadioButton)
        If oRB.IsHandleCreated Then

            If m_oAgent.isSignElecActive Then
                If rbEtatRI.Checked Then
                    btnSignAgent.Visible = True
                    btnSignClient.Visible = True
                End If
                If rbEtatSM.Checked Then
                    btnSignAgent.Visible = False
                    btnSignClient.Visible = False

                End If
                If rbEtatCC.Checked Then
                    btnSignAgent.Visible = True
                    btnSignClient.Visible = True

                End If

                ActiveDesactiveBtnsignature()

            End If
            '' ne déclenccher l'apperçu que sur le checked
            If oRB.Checked Then
                AppercuDocument()
            End If

        End If

    End Sub

    Private Sub btn_ContratCommercial_Click(sender As Object, e As EventArgs) Handles btn_ContratCommercial.Click
        Try
            Statusbar.display("Affichage du contrat commercial", True)
            ' On affiche le PDF rempli
            CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & m_diagnostic.CCFileName)
            Statusbar.display("", True)
        Catch ex As Exception
            CSDebug.dispError("Erreur lors de l'affichage du contrat commercial " & ex.Message)
        End Try

    End Sub

    Private Sub btn_Annuler_Click(sender As Object, e As EventArgs) Handles btn_Annuler.Click
        CloseDiagnostic()

    End Sub
End Class
