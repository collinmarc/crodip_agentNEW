Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.Linq

Public Class frmdiagnostic_facturationCoProp
    Inherits System.Windows.Forms.Form
    Public ReadOnly Property lstFacture() As List(Of Facture)
        Get
            Return m_olstFacture
        End Get
    End Property
    Private Enum TypeInit
        INIT_NON_INITIALISE
        INIT_FROM_DIAG
        INIT_NLLE_FACTURE
        INIT_CONSULT_FACTURE
    End Enum
    Private m_TypeInit As TypeInit = TypeInit.INIT_NON_INITIALISE
    Public positionTop As Integer = 16
    Friend WithEvents m_bsExploitant As System.Windows.Forms.BindingSource
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbCommentaire As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label27 As Label
    Friend WithEvents tbRacine As TextBox
    Friend WithEvents tbDernNumFact As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents tbNumFact As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents dtpDateEcheance As DateTimePicker
    Friend WithEvents tbModeReglement As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDateFact As DateTimePicker
    Friend WithEvents Label24 As Label
    Friend WithEvents tbRefReglement As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents ckReglee As CheckBox
    Friend WithEvents pnlListCoProp As Panel
    Friend WithEvents btnNewExploitant As Button
    Friend WithEvents m_bsLignes As BindingSource
    Friend WithEvents LignesBindingSource As BindingSource
    Friend WithEvents m_bsFacture As BindingSource
    Friend WithEvents m_bsDiag As BindingSource
    Friend WithEvents pnlClient As Panel
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents tbTelPortable As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents tbTelFixe As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents tbrsClient As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tbPrenomClient As TextBox
    Friend WithEvents tbCodePostal As TextBox
    Friend WithEvents tbAdresseClient As TextBox
    Friend WithEvents tbNomClient As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents listTarif_categories As ComboBox
    Friend WithEvents img_Add As PictureBox
    Friend WithEvents Label_diagnostic_61 As Label
    Friend WithEvents listTarif_prestations As ComboBox
    Friend WithEvents m_bsrcStructure As BindingSource
    Friend WithEvents btnSupprCoProp As Button
    Friend WithEvents btnAjoutExploitant As Button
    Friend WithEvents pnlPourcentage As Panel
    Friend WithEvents tbResteAFacturer As TextBox
    Friend WithEvents btnCalc As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents tbPourcent As TextBox
    Friend WithEvents pnlInfosDiag As Panel
    Friend WithEvents Label30 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents tbModelePulve As TextBox
    Friend WithEvents tbMarquePulve As TextBox
    Friend WithEvents tbNumPulve As TextBox
    Friend WithEvents tbNumDiag As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents m_dgvCoProp As DataGridView
    Friend WithEvents m_bsContratCommercial As BindingSource
    Friend WithEvents pnlLines As Panel
    Friend WithEvents dgvLignes As DataGridView
    Friend WithEvents pnlAddPrestatation As Panel
    Friend WithEvents cbxCommune As ComboBox
    Friend WithEvents m_bsCommunes As BindingSource
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btnImprimer As Button
    Friend WithEvents btnPoursuivre As Button
    Friend WithEvents CategorieDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrestationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuantiteColumn As DataGridViewTextBoxColumn
    Friend WithEvents PuColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalHTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RaisonSocialeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CommuneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Fact As DataGridViewTextBoxColumn
    Friend WithEvents SupprColumn As DataGridViewImageColumn


#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents facturation_totalHT As System.Windows.Forms.TextBox
    Friend WithEvents facturation_totalTVA As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents facturation_totalTTC As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_txTVA As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmdiagnostic_facturationCoProp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.tbRefReglement = New System.Windows.Forms.TextBox()
        Me.m_bsFacture = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ckReglee = New System.Windows.Forms.CheckBox()
        Me.dtpDateEcheance = New System.Windows.Forms.DateTimePicker()
        Me.tbModeReglement = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCommentaire = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.facturation_totalHT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.facturation_totalTVA = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.facturation_totalTTC = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_txTVA = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.listTarif_categories = New System.Windows.Forms.ComboBox()
        Me.img_Add = New System.Windows.Forms.PictureBox()
        Me.Label_diagnostic_61 = New System.Windows.Forms.Label()
        Me.listTarif_prestations = New System.Windows.Forms.ComboBox()
        Me.m_bsLignes = New System.Windows.Forms.BindingSource(Me.components)
        Me.LignesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpDateFact = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbRacine = New System.Windows.Forms.TextBox()
        Me.m_bsrcStructure = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbDernNumFact = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tbNumFact = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.pnlListCoProp = New System.Windows.Forms.Panel()
        Me.btnAjoutExploitant = New System.Windows.Forms.Button()
        Me.btnSupprCoProp = New System.Windows.Forms.Button()
        Me.btnNewExploitant = New System.Windows.Forms.Button()
        Me.m_dgvCoProp = New System.Windows.Forms.DataGridView()
        Me.RaisonSocialeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommuneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_bsExploitant = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlClient = New System.Windows.Forms.Panel()
        Me.cbxCommune = New System.Windows.Forms.ComboBox()
        Me.m_bsCommunes = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlPourcentage = New System.Windows.Forms.Panel()
        Me.tbResteAFacturer = New System.Windows.Forms.TextBox()
        Me.m_bsContratCommercial = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbPourcent = New System.Windows.Forms.TextBox()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbTelPortable = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbTelFixe = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbrsClient = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbPrenomClient = New System.Windows.Forms.TextBox()
        Me.tbCodePostal = New System.Windows.Forms.TextBox()
        Me.tbAdresseClient = New System.Windows.Forms.TextBox()
        Me.tbNomClient = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlInfosDiag = New System.Windows.Forms.Panel()
        Me.tbModelePulve = New System.Windows.Forms.TextBox()
        Me.m_bsDiag = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbMarquePulve = New System.Windows.Forms.TextBox()
        Me.tbNumPulve = New System.Windows.Forms.TextBox()
        Me.tbNumDiag = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.pnlLines = New System.Windows.Forms.Panel()
        Me.pnlAddPrestatation = New System.Windows.Forms.Panel()
        Me.dgvLignes = New System.Windows.Forms.DataGridView()
        Me.CategorieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrestationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantiteColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PuColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupprColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnImprimer = New System.Windows.Forms.Button()
        Me.btnPoursuivre = New System.Windows.Forms.Button()
        Me.pnlFooter.SuspendLayout()
        CType(Me.m_bsFacture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.m_bsrcStructure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListCoProp.SuspendLayout()
        CType(Me.m_dgvCoProp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsExploitant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlClient.SuspendLayout()
        CType(Me.m_bsCommunes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPourcentage.SuspendLayout()
        CType(Me.m_bsContratCommercial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInfosDiag.SuspendLayout()
        CType(Me.m_bsDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLines.SuspendLayout()
        Me.pnlAddPrestatation.SuspendLayout()
        CType(Me.dgvLignes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(280, 24)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "     Facturation"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(684, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "     Total HT"
        '
        'pnlFooter
        '
        Me.pnlFooter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFooter.Controls.Add(Me.tbRefReglement)
        Me.pnlFooter.Controls.Add(Me.Label25)
        Me.pnlFooter.Controls.Add(Me.ckReglee)
        Me.pnlFooter.Controls.Add(Me.dtpDateEcheance)
        Me.pnlFooter.Controls.Add(Me.tbModeReglement)
        Me.pnlFooter.Controls.Add(Me.Label9)
        Me.pnlFooter.Controls.Add(Me.Label2)
        Me.pnlFooter.Controls.Add(Me.tbCommentaire)
        Me.pnlFooter.Controls.Add(Me.Label18)
        Me.pnlFooter.Controls.Add(Me.Label1)
        Me.pnlFooter.Controls.Add(Me.facturation_totalHT)
        Me.pnlFooter.Controls.Add(Me.Label5)
        Me.pnlFooter.Controls.Add(Me.facturation_totalTVA)
        Me.pnlFooter.Controls.Add(Me.Label12)
        Me.pnlFooter.Controls.Add(Me.Label13)
        Me.pnlFooter.Controls.Add(Me.facturation_totalTTC)
        Me.pnlFooter.Controls.Add(Me.Label14)
        Me.pnlFooter.Controls.Add(Me.Label15)
        Me.pnlFooter.Controls.Add(Me.Label16)
        Me.pnlFooter.Controls.Add(Me.tb_txTVA)
        Me.pnlFooter.Controls.Add(Me.Label17)
        Me.pnlFooter.Location = New System.Drawing.Point(12, 561)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(921, 112)
        Me.pnlFooter.TabIndex = 2
        '
        'tbRefReglement
        '
        Me.tbRefReglement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRefReglement.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "refReglement", True))
        Me.tbRefReglement.Location = New System.Drawing.Point(278, 84)
        Me.tbRefReglement.Name = "tbRefReglement"
        Me.tbRefReglement.Size = New System.Drawing.Size(403, 20)
        Me.tbRefReglement.TabIndex = 73
        '
        'm_bsFacture
        '
        Me.m_bsFacture.DataSource = GetType(Crodip_agent.Facture)
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(121, 87)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(147, 13)
        Me.Label25.TabIndex = 72
        Me.Label25.Text = "Reférence de paiement :"
        '
        'ckReglee
        '
        Me.ckReglee.AutoSize = True
        Me.ckReglee.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsFacture, "isReglee", True))
        Me.ckReglee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckReglee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ckReglee.Location = New System.Drawing.Point(13, 87)
        Me.ckReglee.Name = "ckReglee"
        Me.ckReglee.Size = New System.Drawing.Size(66, 17)
        Me.ckReglee.TabIndex = 71
        Me.ckReglee.Text = "Réglée"
        Me.ckReglee.UseVisualStyleBackColor = True
        '
        'dtpDateEcheance
        '
        Me.dtpDateEcheance.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.m_bsFacture, "DateEcheance", True))
        Me.dtpDateEcheance.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateEcheance.Location = New System.Drawing.Point(121, 56)
        Me.dtpDateEcheance.Name = "dtpDateEcheance"
        Me.dtpDateEcheance.Size = New System.Drawing.Size(86, 20)
        Me.dtpDateEcheance.TabIndex = 67
        '
        'tbModeReglement
        '
        Me.tbModeReglement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbModeReglement.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "Modereglement", True))
        Me.tbModeReglement.Location = New System.Drawing.Point(336, 56)
        Me.tbModeReglement.Name = "tbModeReglement"
        Me.tbModeReglement.Size = New System.Drawing.Size(345, 20)
        Me.tbModeReglement.TabIndex = 66
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(7, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Date échéance :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(208, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Mode de réglement :"
        '
        'tbCommentaire
        '
        Me.tbCommentaire.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCommentaire.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "Commentaire", True))
        Me.tbCommentaire.Location = New System.Drawing.Point(117, 7)
        Me.tbCommentaire.Multiline = True
        Me.tbCommentaire.Name = "tbCommentaire"
        Me.tbCommentaire.Size = New System.Drawing.Size(561, 43)
        Me.tbCommentaire.TabIndex = 43
        Me.tbCommentaire.Text = "Commentaire de facturation"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(3, 4)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 13)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "Commentaire :"
        '
        'facturation_totalHT
        '
        Me.facturation_totalHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalHT.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "TotalHT", True))
        Me.facturation_totalHT.Location = New System.Drawing.Point(860, 4)
        Me.facturation_totalHT.Name = "facturation_totalHT"
        Me.facturation_totalHT.ReadOnly = True
        Me.facturation_totalHT.Size = New System.Drawing.Size(43, 20)
        Me.facturation_totalHT.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(907, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(8, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "€"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'facturation_totalTVA
        '
        Me.facturation_totalTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "TotalTVA", True))
        Me.facturation_totalTVA.Location = New System.Drawing.Point(860, 54)
        Me.facturation_totalTVA.Name = "facturation_totalTVA"
        Me.facturation_totalTVA.ReadOnly = True
        Me.facturation_totalTVA.Size = New System.Drawing.Size(43, 20)
        Me.facturation_totalTVA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(907, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(8, 16)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "€"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label13.Image = CType(resources.GetObject("Label13.Image"), System.Drawing.Image)
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label13.Location = New System.Drawing.Point(689, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "     Net à payer (TTC)...."
        '
        'facturation_totalTTC
        '
        Me.facturation_totalTTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTTC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "TotalTTC", True))
        Me.facturation_totalTTC.Location = New System.Drawing.Point(860, 80)
        Me.facturation_totalTTC.Name = "facturation_totalTTC"
        Me.facturation_totalTTC.ReadOnly = True
        Me.facturation_totalTTC.Size = New System.Drawing.Size(43, 20)
        Me.facturation_totalTTC.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(907, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(8, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "€"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label15.Image = CType(resources.GetObject("Label15.Image"), System.Drawing.Image)
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label15.Location = New System.Drawing.Point(707, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 16)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "     Taux TVA (%)"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label16.Location = New System.Drawing.Point(710, 55)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(146, 16)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "     Total TVA"
        '
        'tb_txTVA
        '
        Me.tb_txTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_txTVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "TxTVA", True))
        Me.tb_txTVA.Location = New System.Drawing.Point(860, 30)
        Me.tb_txTVA.Name = "tb_txTVA"
        Me.tb_txTVA.Size = New System.Drawing.Size(43, 20)
        Me.tb_txTVA.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(907, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(8, 16)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "%"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'listTarif_categories
        '
        Me.listTarif_categories.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listTarif_categories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listTarif_categories.Location = New System.Drawing.Point(243, 1)
        Me.listTarif_categories.Name = "listTarif_categories"
        Me.listTarif_categories.Size = New System.Drawing.Size(208, 21)
        Me.listTarif_categories.TabIndex = 74
        '
        'img_Add
        '
        Me.img_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_Add.Cursor = System.Windows.Forms.Cursors.Hand
        Me.img_Add.Image = CType(resources.GetObject("img_Add.Image"), System.Drawing.Image)
        Me.img_Add.Location = New System.Drawing.Point(675, 3)
        Me.img_Add.Name = "img_Add"
        Me.img_Add.Size = New System.Drawing.Size(16, 16)
        Me.img_Add.TabIndex = 77
        Me.img_Add.TabStop = False
        '
        'Label_diagnostic_61
        '
        Me.Label_diagnostic_61.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_diagnostic_61.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_61.Image = CType(resources.GetObject("Label_diagnostic_61.Image"), System.Drawing.Image)
        Me.Label_diagnostic_61.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_61.Location = New System.Drawing.Point(30, 2)
        Me.Label_diagnostic_61.Name = "Label_diagnostic_61"
        Me.Label_diagnostic_61.Size = New System.Drawing.Size(208, 22)
        Me.Label_diagnostic_61.TabIndex = 76
        Me.Label_diagnostic_61.Text = "     Ajouter une prestation : "
        '
        'listTarif_prestations
        '
        Me.listTarif_prestations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listTarif_prestations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listTarif_prestations.Location = New System.Drawing.Point(457, 0)
        Me.listTarif_prestations.Name = "listTarif_prestations"
        Me.listTarif_prestations.Size = New System.Drawing.Size(200, 21)
        Me.listTarif_prestations.TabIndex = 75
        '
        'm_bsLignes
        '
        Me.m_bsLignes.DataSource = Me.LignesBindingSource
        '
        'LignesBindingSource
        '
        Me.LignesBindingSource.DataMember = "Lignes"
        Me.LignesBindingSource.DataSource = Me.m_bsFacture
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel1.Controls.Add(Me.dtpDateFact)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.tbRacine)
        Me.Panel1.Controls.Add(Me.tbDernNumFact)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.tbNumFact)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Location = New System.Drawing.Point(13, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 124)
        Me.Panel1.TabIndex = 64
        '
        'dtpDateFact
        '
        Me.dtpDateFact.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "DateFacture", True))
        Me.dtpDateFact.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.m_bsFacture, "DateFacture", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "d"))
        Me.dtpDateFact.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFact.Location = New System.Drawing.Point(209, 94)
        Me.dtpDateFact.Name = "dtpDateFact"
        Me.dtpDateFact.Size = New System.Drawing.Size(108, 20)
        Me.dtpDateFact.TabIndex = 2
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 98)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 13)
        Me.Label24.TabIndex = 74
        Me.Label24.Text = "Date de facture :"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(8, 6)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(180, 13)
        Me.Label27.TabIndex = 73
        Me.Label27.Text = "Racine du numéro de facture :"
        '
        'tbRacine
        '
        Me.tbRacine.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcStructure, "RacineNumFact", True))
        Me.tbRacine.Location = New System.Drawing.Point(209, 3)
        Me.tbRacine.Name = "tbRacine"
        Me.tbRacine.Size = New System.Drawing.Size(108, 20)
        Me.tbRacine.TabIndex = 0
        '
        'm_bsrcStructure
        '
        Me.m_bsrcStructure.DataSource = GetType(Crodip_agent.Structuree)
        '
        'tbDernNumFact
        '
        Me.tbDernNumFact.Enabled = False
        Me.tbDernNumFact.Location = New System.Drawing.Point(209, 29)
        Me.tbDernNumFact.Name = "tbDernNumFact"
        Me.tbDernNumFact.ReadOnly = True
        Me.tbDernNumFact.Size = New System.Drawing.Size(108, 20)
        Me.tbDernNumFact.TabIndex = 71
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(6, 32)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(200, 13)
        Me.Label28.TabIndex = 70
        Me.Label28.Text = "Dernier numéro de facture utilisé :"
        '
        'tbNumFact
        '
        Me.tbNumFact.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "idFacture", True))
        Me.tbNumFact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.tbNumFact.Location = New System.Drawing.Point(209, 55)
        Me.tbNumFact.Name = "tbNumFact"
        Me.tbNumFact.Size = New System.Drawing.Size(108, 20)
        Me.tbNumFact.TabIndex = 1
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(6, 59)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(120, 13)
        Me.Label29.TabIndex = 68
        Me.Label29.Text = "Numéro de facture :"
        '
        'pnlListCoProp
        '
        Me.pnlListCoProp.Controls.Add(Me.btnAjoutExploitant)
        Me.pnlListCoProp.Controls.Add(Me.btnSupprCoProp)
        Me.pnlListCoProp.Controls.Add(Me.btnNewExploitant)
        Me.pnlListCoProp.Controls.Add(Me.m_dgvCoProp)
        Me.pnlListCoProp.Location = New System.Drawing.Point(13, 164)
        Me.pnlListCoProp.Name = "pnlListCoProp"
        Me.pnlListCoProp.Size = New System.Drawing.Size(329, 210)
        Me.pnlListCoProp.TabIndex = 66
        '
        'btnAjoutExploitant
        '
        Me.btnAjoutExploitant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAjoutExploitant.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnAjoutExploitant.ForeColor = System.Drawing.Color.White
        Me.btnAjoutExploitant.Location = New System.Drawing.Point(119, 173)
        Me.btnAjoutExploitant.Name = "btnAjoutExploitant"
        Me.btnAjoutExploitant.Size = New System.Drawing.Size(108, 29)
        Me.btnAjoutExploitant.TabIndex = 65
        Me.btnAjoutExploitant.Text = "Ajouter existant"
        Me.btnAjoutExploitant.UseVisualStyleBackColor = False
        '
        'btnSupprCoProp
        '
        Me.btnSupprCoProp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSupprCoProp.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnSupprCoProp.ForeColor = System.Drawing.Color.White
        Me.btnSupprCoProp.Location = New System.Drawing.Point(241, 172)
        Me.btnSupprCoProp.Name = "btnSupprCoProp"
        Me.btnSupprCoProp.Size = New System.Drawing.Size(85, 29)
        Me.btnSupprCoProp.TabIndex = 64
        Me.btnSupprCoProp.Text = "Supprimer"
        Me.btnSupprCoProp.UseVisualStyleBackColor = False
        '
        'btnNewExploitant
        '
        Me.btnNewExploitant.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnNewExploitant.ForeColor = System.Drawing.Color.White
        Me.btnNewExploitant.Location = New System.Drawing.Point(8, 173)
        Me.btnNewExploitant.Name = "btnNewExploitant"
        Me.btnNewExploitant.Size = New System.Drawing.Size(87, 29)
        Me.btnNewExploitant.TabIndex = 51
        Me.btnNewExploitant.Text = "Nouveau"
        Me.btnNewExploitant.UseVisualStyleBackColor = False
        '
        'm_dgvCoProp
        '
        Me.m_dgvCoProp.AllowUserToAddRows = False
        Me.m_dgvCoProp.AllowUserToDeleteRows = False
        Me.m_dgvCoProp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_dgvCoProp.AutoGenerateColumns = False
        Me.m_dgvCoProp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.m_dgvCoProp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.m_dgvCoProp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RaisonSocialeDataGridViewTextBoxColumn, Me.CommuneDataGridViewTextBoxColumn, Me.Fact})
        Me.m_dgvCoProp.DataSource = Me.m_bsExploitant
        Me.m_dgvCoProp.Location = New System.Drawing.Point(8, 0)
        Me.m_dgvCoProp.MultiSelect = False
        Me.m_dgvCoProp.Name = "m_dgvCoProp"
        Me.m_dgvCoProp.ReadOnly = True
        Me.m_dgvCoProp.RowHeadersVisible = False
        Me.m_dgvCoProp.Size = New System.Drawing.Size(319, 167)
        Me.m_dgvCoProp.TabIndex = 42
        '
        'RaisonSocialeDataGridViewTextBoxColumn
        '
        Me.RaisonSocialeDataGridViewTextBoxColumn.DataPropertyName = "raisonSociale"
        Me.RaisonSocialeDataGridViewTextBoxColumn.HeaderText = "Raison sociale"
        Me.RaisonSocialeDataGridViewTextBoxColumn.Name = "RaisonSocialeDataGridViewTextBoxColumn"
        Me.RaisonSocialeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CommuneDataGridViewTextBoxColumn
        '
        Me.CommuneDataGridViewTextBoxColumn.DataPropertyName = "commune"
        Me.CommuneDataGridViewTextBoxColumn.HeaderText = "Commune"
        Me.CommuneDataGridViewTextBoxColumn.Name = "CommuneDataGridViewTextBoxColumn"
        Me.CommuneDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Fact
        '
        Me.Fact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Fact.DataPropertyName = "Fact"
        Me.Fact.HeaderText = ""
        Me.Fact.Name = "Fact"
        Me.Fact.ReadOnly = True
        Me.Fact.ToolTipText = "indique si une facture a été créé pour cet exploitant"
        Me.Fact.Width = 20
        '
        'm_bsExploitant
        '
        Me.m_bsExploitant.DataSource = GetType(Crodip_agent.Exploitation)
        Me.m_bsExploitant.Filter = "not isSuppressionCoprop"
        '
        'pnlClient
        '
        Me.pnlClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlClient.Controls.Add(Me.cbxCommune)
        Me.pnlClient.Controls.Add(Me.pnlPourcentage)
        Me.pnlClient.Controls.Add(Me.tbEmail)
        Me.pnlClient.Controls.Add(Me.Label23)
        Me.pnlClient.Controls.Add(Me.tbTelPortable)
        Me.pnlClient.Controls.Add(Me.Label22)
        Me.pnlClient.Controls.Add(Me.tbTelFixe)
        Me.pnlClient.Controls.Add(Me.Label21)
        Me.pnlClient.Controls.Add(Me.tbrsClient)
        Me.pnlClient.Controls.Add(Me.Label11)
        Me.pnlClient.Controls.Add(Me.Label10)
        Me.pnlClient.Controls.Add(Me.tbPrenomClient)
        Me.pnlClient.Controls.Add(Me.tbCodePostal)
        Me.pnlClient.Controls.Add(Me.tbAdresseClient)
        Me.pnlClient.Controls.Add(Me.tbNomClient)
        Me.pnlClient.Controls.Add(Me.Label8)
        Me.pnlClient.Controls.Add(Me.Label7)
        Me.pnlClient.Controls.Add(Me.Label6)
        Me.pnlClient.Controls.Add(Me.Label4)
        Me.pnlClient.Location = New System.Drawing.Point(347, 164)
        Me.pnlClient.Name = "pnlClient"
        Me.pnlClient.Size = New System.Drawing.Size(574, 210)
        Me.pnlClient.TabIndex = 0
        '
        'cbxCommune
        '
        Me.cbxCommune.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxCommune.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxCommune.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCommune.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "commune", True))
        Me.cbxCommune.DataSource = Me.m_bsCommunes
        Me.cbxCommune.DisplayMember = "Nom"
        Me.cbxCommune.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCommune.Location = New System.Drawing.Point(266, 114)
        Me.cbxCommune.Name = "cbxCommune"
        Me.cbxCommune.Size = New System.Drawing.Size(305, 21)
        Me.cbxCommune.TabIndex = 74
        '
        'm_bsCommunes
        '
        Me.m_bsCommunes.DataSource = GetType(Crodip_agent.Commune)
        '
        'pnlPourcentage
        '
        Me.pnlPourcentage.Controls.Add(Me.tbResteAFacturer)
        Me.pnlPourcentage.Controls.Add(Me.btnCalc)
        Me.pnlPourcentage.Controls.Add(Me.Label20)
        Me.pnlPourcentage.Controls.Add(Me.Label19)
        Me.pnlPourcentage.Controls.Add(Me.tbPourcent)
        Me.pnlPourcentage.Location = New System.Drawing.Point(7, 167)
        Me.pnlPourcentage.Name = "pnlPourcentage"
        Me.pnlPourcentage.Size = New System.Drawing.Size(582, 40)
        Me.pnlPourcentage.TabIndex = 73
        '
        'tbResteAFacturer
        '
        Me.tbResteAFacturer.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsContratCommercial, "ResteAFacturer", True))
        Me.tbResteAFacturer.Location = New System.Drawing.Point(491, 10)
        Me.tbResteAFacturer.Name = "tbResteAFacturer"
        Me.tbResteAFacturer.ReadOnly = True
        Me.tbResteAFacturer.Size = New System.Drawing.Size(70, 20)
        Me.tbResteAFacturer.TabIndex = 68
        '
        'm_bsContratCommercial
        '
        Me.m_bsContratCommercial.DataSource = GetType(Crodip_agent.ContratCommercial)
        '
        'btnCalc
        '
        Me.btnCalc.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnCalc.ForeColor = System.Drawing.Color.White
        Me.btnCalc.Location = New System.Drawing.Point(253, 6)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(64, 26)
        Me.btnCalc.TabIndex = 66
        Me.btnCalc.Text = "Calculer"
        Me.btnCalc.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(325, 13)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(111, 13)
        Me.Label20.TabIndex = 67
        Me.Label20.Text = "Reste à facturer : "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(3, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(174, 13)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "Pourcentage de facturation : "
        '
        'tbPourcent
        '
        Me.tbPourcent.Location = New System.Drawing.Point(183, 10)
        Me.tbPourcent.Name = "tbPourcent"
        Me.tbPourcent.Size = New System.Drawing.Size(47, 20)
        Me.tbPourcent.TabIndex = 65
        '
        'tbEmail
        '
        Me.tbEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "eMail", True))
        Me.tbEmail.Location = New System.Drawing.Point(388, 141)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(183, 20)
        Me.tbEmail.TabIndex = 7
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(341, 144)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 13)
        Me.Label23.TabIndex = 72
        Me.Label23.Text = "Email :"
        '
        'tbTelPortable
        '
        Me.tbTelPortable.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "telephonePortable", True))
        Me.tbTelPortable.Location = New System.Drawing.Point(260, 141)
        Me.tbTelPortable.Name = "tbTelPortable"
        Me.tbTelPortable.Size = New System.Drawing.Size(75, 20)
        Me.tbTelPortable.TabIndex = 6
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(190, 144)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 70
        Me.Label22.Text = "Tel port.  :"
        '
        'tbTelFixe
        '
        Me.tbTelFixe.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "telephoneFixe", True))
        Me.tbTelFixe.Location = New System.Drawing.Point(107, 141)
        Me.tbTelFixe.Name = "tbTelFixe"
        Me.tbTelFixe.Size = New System.Drawing.Size(77, 20)
        Me.tbTelFixe.TabIndex = 5
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(4, 144)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 68
        Me.Label21.Text = "Tel fixe  :"
        '
        'tbrsClient
        '
        Me.tbrsClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbrsClient.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "raisonSociale", True))
        Me.tbrsClient.Location = New System.Drawing.Point(107, 11)
        Me.tbrsClient.Name = "tbrsClient"
        Me.tbrsClient.Size = New System.Drawing.Size(464, 20)
        Me.tbrsClient.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(3, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Raison sociale :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(4, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Prénom :"
        '
        'tbPrenomClient
        '
        Me.tbPrenomClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPrenomClient.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "prenomExploitant", True))
        Me.tbPrenomClient.Location = New System.Drawing.Point(107, 63)
        Me.tbPrenomClient.Name = "tbPrenomClient"
        Me.tbPrenomClient.Size = New System.Drawing.Size(463, 20)
        Me.tbPrenomClient.TabIndex = 2
        '
        'tbCodePostal
        '
        Me.tbCodePostal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCodePostal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "codePostal", True))
        Me.tbCodePostal.Location = New System.Drawing.Point(107, 115)
        Me.tbCodePostal.Name = "tbCodePostal"
        Me.tbCodePostal.Size = New System.Drawing.Size(51, 20)
        Me.tbCodePostal.TabIndex = 60
        '
        'tbAdresseClient
        '
        Me.tbAdresseClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAdresseClient.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "adresse", True))
        Me.tbAdresseClient.Location = New System.Drawing.Point(107, 89)
        Me.tbAdresseClient.Name = "tbAdresseClient"
        Me.tbAdresseClient.Size = New System.Drawing.Size(464, 20)
        Me.tbAdresseClient.TabIndex = 3
        '
        'tbNomClient
        '
        Me.tbNomClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNomClient.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "nomExploitant", True))
        Me.tbNomClient.Location = New System.Drawing.Point(107, 37)
        Me.tbNomClient.Name = "tbNomClient"
        Me.tbNomClient.Size = New System.Drawing.Size(463, 20)
        Me.tbNomClient.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(191, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Commune :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(4, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Code Postal  :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Adresse :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(4, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Nom  :"
        '
        'pnlInfosDiag
        '
        Me.pnlInfosDiag.Controls.Add(Me.tbModelePulve)
        Me.pnlInfosDiag.Controls.Add(Me.tbMarquePulve)
        Me.pnlInfosDiag.Controls.Add(Me.tbNumPulve)
        Me.pnlInfosDiag.Controls.Add(Me.tbNumDiag)
        Me.pnlInfosDiag.Controls.Add(Me.Label32)
        Me.pnlInfosDiag.Controls.Add(Me.Label31)
        Me.pnlInfosDiag.Controls.Add(Me.Label30)
        Me.pnlInfosDiag.Controls.Add(Me.Label26)
        Me.pnlInfosDiag.Location = New System.Drawing.Point(350, 37)
        Me.pnlInfosDiag.Name = "pnlInfosDiag"
        Me.pnlInfosDiag.Size = New System.Drawing.Size(571, 120)
        Me.pnlInfosDiag.TabIndex = 67
        '
        'tbModelePulve
        '
        Me.tbModelePulve.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsDiag, "pulverisateurModele", True))
        Me.tbModelePulve.Location = New System.Drawing.Point(169, 82)
        Me.tbModelePulve.Name = "tbModelePulve"
        Me.tbModelePulve.ReadOnly = True
        Me.tbModelePulve.Size = New System.Drawing.Size(100, 20)
        Me.tbModelePulve.TabIndex = 75
        '
        'm_bsDiag
        '
        Me.m_bsDiag.DataSource = GetType(Crodip_agent.Diagnostic)
        '
        'tbMarquePulve
        '
        Me.tbMarquePulve.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsDiag, "pulverisateurMarque", True))
        Me.tbMarquePulve.Location = New System.Drawing.Point(169, 56)
        Me.tbMarquePulve.Name = "tbMarquePulve"
        Me.tbMarquePulve.ReadOnly = True
        Me.tbMarquePulve.Size = New System.Drawing.Size(100, 20)
        Me.tbMarquePulve.TabIndex = 74
        '
        'tbNumPulve
        '
        Me.tbNumPulve.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsDiag, "pulverisateurNumNational", True))
        Me.tbNumPulve.Location = New System.Drawing.Point(169, 30)
        Me.tbNumPulve.Name = "tbNumPulve"
        Me.tbNumPulve.ReadOnly = True
        Me.tbNumPulve.Size = New System.Drawing.Size(100, 20)
        Me.tbNumPulve.TabIndex = 73
        '
        'tbNumDiag
        '
        Me.tbNumDiag.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsDiag, "id", True))
        Me.tbNumDiag.Location = New System.Drawing.Point(169, 4)
        Me.tbNumDiag.Name = "tbNumDiag"
        Me.tbNumDiag.ReadOnly = True
        Me.tbNumDiag.Size = New System.Drawing.Size(100, 20)
        Me.tbNumDiag.TabIndex = 72
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(8, 85)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(56, 13)
        Me.Label32.TabIndex = 71
        Me.Label32.Text = "Modèle :"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(7, 63)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(57, 13)
        Me.Label31.TabIndex = 70
        Me.Label31.Text = "Marque :"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(7, 33)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(157, 13)
        Me.Label30.TabIndex = 69
        Me.Label30.Text = "Numéro du pulvérisateur : "
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(3, 7)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(130, 13)
        Me.Label26.TabIndex = 68
        Me.Label26.Text = "Numéro du contrôle : "
        '
        'pnlLines
        '
        Me.pnlLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLines.Controls.Add(Me.pnlAddPrestatation)
        Me.pnlLines.Controls.Add(Me.dgvLignes)
        Me.pnlLines.Location = New System.Drawing.Point(12, 380)
        Me.pnlLines.Name = "pnlLines"
        Me.pnlLines.Size = New System.Drawing.Size(921, 179)
        Me.pnlLines.TabIndex = 79
        '
        'pnlAddPrestatation
        '
        Me.pnlAddPrestatation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAddPrestatation.Controls.Add(Me.Label_diagnostic_61)
        Me.pnlAddPrestatation.Controls.Add(Me.listTarif_categories)
        Me.pnlAddPrestatation.Controls.Add(Me.img_Add)
        Me.pnlAddPrestatation.Controls.Add(Me.listTarif_prestations)
        Me.pnlAddPrestatation.Location = New System.Drawing.Point(218, 151)
        Me.pnlAddPrestatation.Name = "pnlAddPrestatation"
        Me.pnlAddPrestatation.Size = New System.Drawing.Size(700, 24)
        Me.pnlAddPrestatation.TabIndex = 79
        '
        'dgvLignes
        '
        Me.dgvLignes.AllowUserToAddRows = False
        Me.dgvLignes.AllowUserToDeleteRows = False
        Me.dgvLignes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLignes.AutoGenerateColumns = False
        Me.dgvLignes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLignes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLignes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CategorieDataGridViewTextBoxColumn, Me.PrestationDataGridViewTextBoxColumn, Me.QuantiteColumn, Me.PuColumn, Me.TotalHTDataGridViewTextBoxColumn, Me.SupprColumn})
        Me.dgvLignes.DataSource = Me.m_bsLignes
        Me.dgvLignes.Location = New System.Drawing.Point(3, 3)
        Me.dgvLignes.Name = "dgvLignes"
        Me.dgvLignes.Size = New System.Drawing.Size(915, 145)
        Me.dgvLignes.TabIndex = 78
        '
        'CategorieDataGridViewTextBoxColumn
        '
        Me.CategorieDataGridViewTextBoxColumn.DataPropertyName = "categorie"
        Me.CategorieDataGridViewTextBoxColumn.HeaderText = "categorie"
        Me.CategorieDataGridViewTextBoxColumn.Name = "CategorieDataGridViewTextBoxColumn"
        '
        'PrestationDataGridViewTextBoxColumn
        '
        Me.PrestationDataGridViewTextBoxColumn.DataPropertyName = "prestation"
        Me.PrestationDataGridViewTextBoxColumn.HeaderText = "prestation"
        Me.PrestationDataGridViewTextBoxColumn.Name = "PrestationDataGridViewTextBoxColumn"
        '
        'QuantiteColumn
        '
        Me.QuantiteColumn.DataPropertyName = "quantiteStr"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.QuantiteColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantiteColumn.HeaderText = "quantite"
        Me.QuantiteColumn.Name = "QuantiteColumn"
        '
        'PuColumn
        '
        Me.PuColumn.DataPropertyName = "pustr"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PuColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PuColumn.HeaderText = "pu"
        Me.PuColumn.Name = "PuColumn"
        '
        'TotalHTDataGridViewTextBoxColumn
        '
        Me.TotalHTDataGridViewTextBoxColumn.DataPropertyName = "totalHT"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TotalHTDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalHTDataGridViewTextBoxColumn.HeaderText = "totalHT"
        Me.TotalHTDataGridViewTextBoxColumn.Name = "TotalHTDataGridViewTextBoxColumn"
        Me.TotalHTDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SupprColumn
        '
        Me.SupprColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SupprColumn.HeaderText = "Suppr"
        Me.SupprColumn.Image = Global.Crodip_agent.Resources.delete
        Me.SupprColumn.Name = "SupprColumn"
        Me.SupprColumn.Width = 40
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.BackgroundImage = Global.Crodip_agent.Resources.btn_annuler
        Me.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAnnuler.FlatAppearance.BorderSize = 0
        Me.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Location = New System.Drawing.Point(12, 695)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(127, 27)
        Me.btnAnnuler.TabIndex = 80
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'btnImprimer
        '
        Me.btnImprimer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimer.BackgroundImage = Global.Crodip_agent.Resources.btn_divers_print
        Me.btnImprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImprimer.FlatAppearance.BorderSize = 0
        Me.btnImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimer.ForeColor = System.Drawing.Color.White
        Me.btnImprimer.Location = New System.Drawing.Point(329, 695)
        Me.btnImprimer.Name = "btnImprimer"
        Me.btnImprimer.Size = New System.Drawing.Size(185, 27)
        Me.btnImprimer.TabIndex = 81
        Me.btnImprimer.Text = "Valider / Imprimer"
        Me.btnImprimer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimer.UseVisualStyleBackColor = True
        '
        'btnPoursuivre
        '
        Me.btnPoursuivre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPoursuivre.BackgroundImage = Global.Crodip_agent.Resources.btn_valider
        Me.btnPoursuivre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPoursuivre.FlatAppearance.BorderSize = 0
        Me.btnPoursuivre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPoursuivre.ForeColor = System.Drawing.Color.White
        Me.btnPoursuivre.Location = New System.Drawing.Point(797, 696)
        Me.btnPoursuivre.Name = "btnPoursuivre"
        Me.btnPoursuivre.Size = New System.Drawing.Size(136, 27)
        Me.btnPoursuivre.TabIndex = 82
        Me.btnPoursuivre.Text = "Poursuivre"
        Me.btnPoursuivre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPoursuivre.UseVisualStyleBackColor = True
        '
        'frmdiagnostic_facturationCoProp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(933, 728)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPoursuivre)
        Me.Controls.Add(Me.btnImprimer)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.pnlLines)
        Me.Controls.Add(Me.pnlInfosDiag)
        Me.Controls.Add(Me.pnlClient)
        Me.Controls.Add(Me.pnlListCoProp)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.Label3)
        Me.Icon = Global.Crodip_agent.Resources.logoCRODIP
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmdiagnostic_facturationCoProp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Crodip .::. Facturation"
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        CType(Me.m_bsFacture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.m_bsrcStructure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListCoProp.ResumeLayout(False)
        CType(Me.m_dgvCoProp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsExploitant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlClient.ResumeLayout(False)
        Me.pnlClient.PerformLayout()
        CType(Me.m_bsCommunes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPourcentage.ResumeLayout(False)
        Me.pnlPourcentage.PerformLayout()
        CType(Me.m_bsContratCommercial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInfosDiag.ResumeLayout(False)
        Me.pnlInfosDiag.PerformLayout()
        CType(Me.m_bsDiag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLines.ResumeLayout(False)
        Me.pnlAddPrestatation.ResumeLayout(False)
        CType(Me.dgvLignes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " - Vars - "
    Private isValider As Boolean = False
    'Private m_pathBl As String
    'Private m_pathFacture As String
    Protected m_oDiag As Diagnostic
    Protected m_oPulverisateur As Pulverisateur
    Protected m_oAgent As Agent
    Protected m_oStructure As Structuree
    Protected m_dernnumfact As String
    Protected m_olstExploit As List(Of Exploitation)
    Protected m_olstFacture As List(Of Facture)
    Protected m_bModeCoProp As Boolean = False
#End Region
#Region " Chargement "
    Public Sub setContexte(pDiag As Diagnostic, pAgent As Agent)
        Debug.Assert(pDiag IsNot Nothing)
        Debug.Assert(pDiag.oContratCommercial IsNot Nothing)
        Debug.Assert(pAgent IsNot Nothing)
        Dim oExploit As Exploitation = Nothing

        m_TypeInit = TypeInit.INIT_FROM_DIAG

        'Pas d'ajout de ligne après un controle
        pnlAddPrestatation.Visible = False
        m_oStructure = StructureManager.getStructureById(pAgent.idStructure)
        m_dernnumfact = m_oStructure.DernierNumFact
        m_oAgent = pAgent


        If pDiag IsNot Nothing Then
            m_oDiag = pDiag
            oExploit = ExploitationManager.getExploitationById(m_oDiag.proprietaireId)
            m_oAgent = pAgent
            m_oPulverisateur = PulverisateurManager.getPulverisateurById(m_oDiag.pulverisateurId)
        End If
        m_olstFacture = New List(Of Facture)()



        dgvLignes.AllowUserToAddRows = False
        dgvLignes.AllowUserToDeleteRows = False


        'Les informations du client sont non-modifiables 
        EnableClient(False)
        If Not m_oPulverisateur.isCoPropriete Then
            pnlListCoProp.Visible = False
            pnlClient.Left = pnlListCoProp.Left
            pnlClient.Width = pnlClient.Width + pnlListCoProp.Width
            pnlPourcentage.Visible = False
            pnlLines.Top = pnlClient.Top + pnlClient.Height + 6
            pnlLines.Height = pnlFooter.Top - 6 - pnlLines.Top
            m_olstExploit = New List(Of Exploitation)()
            m_olstExploit.Add(oExploit)
            m_bModeCoProp = False

        Else
            m_olstExploit = ExploitationManager.GetListExploitationByPulverisateurId(m_oPulverisateur.id)
            pnlListCoProp.Visible = True
            m_bModeCoProp = True
        End If



    End Sub
    Public Sub setContexte(pFact As Facture)
        Dim oExploit As Exploitation = Nothing
        m_TypeInit = TypeInit.INIT_CONSULT_FACTURE
        m_bModeCoProp = False

        'Pas d'ajout de ligne En Visu de Facture
        pnlAddPrestatation.Visible = False
        m_oStructure = StructureManager.getStructureById(pFact.idStructure)
        m_dernnumfact = m_oStructure.DernierNumFact
        m_oAgent = Nothing
        m_oDiag = Nothing
        oExploit = ExploitationManager.getExploitationById(pFact.oExploit.id)
        m_oPulverisateur = Nothing

        m_olstFacture = New List(Of Facture)()

        dgvLignes.AllowUserToAddRows = False
        dgvLignes.AllowUserToDeleteRows = False


        pnlListCoProp.Visible = False
        pnlClient.Left = pnlListCoProp.Left
        pnlClient.Width = pnlClient.Width + pnlListCoProp.Width
        pnlPourcentage.Visible = False
        pnlLines.Top = pnlClient.Top + pnlClient.Height + 6
        pnlLines.Height = pnlFooter.Top - 6 - pnlLines.Top

        m_olstExploit = New List(Of Exploitation)()
        m_olstExploit.Add(oExploit)

        m_olstFacture.Add(pFact)
        If Not String.IsNullOrEmpty(pFact.idDiag) Then
            m_oDiag = DiagnosticManager.getDiagnosticById(pFact.idDiag)
        End If

    End Sub
    ''' <summary>
    ''' Initiliation de la fenêtre en mode 'Nouvelle Facture'
    ''' </summary>
    ''' <param name="pAgent"></param>
    Public Sub setContexte(pAgent As Agent)
        Debug.Assert(pAgent IsNot Nothing)
        m_TypeInit = TypeInit.INIT_NLLE_FACTURE
        m_bModeCoProp = False
        Dim oExploit As Exploitation = Nothing

        m_oStructure = StructureManager.getStructureById(pAgent.idStructure)
        m_dernnumfact = m_oStructure.DernierNumFact

        m_oAgent = pAgent

        m_olstExploit = New List(Of Exploitation)()

        m_olstFacture = New List(Of Facture)()

        dgvLignes.AllowUserToAddRows = False
        dgvLignes.AllowUserToDeleteRows = False

        pnlListCoProp.Visible = False
        pnlClient.Left = pnlListCoProp.Left
        pnlClient.Width = pnlClient.Width + pnlListCoProp.Width
        pnlLines.Top = pnlClient.Top + pnlClient.Height + 6
        pnlLines.Height = pnlFooter.Top - 6 - pnlLines.Top
        m_olstExploit = New List(Of Exploitation)()
        pnlInfosDiag.Visible = False
        For Each octrl As Control In pnlPourcentage.Controls
            octrl.Visible = False
        Next
        pnlPourcentage.Controls.Add(btnNewExploitant)
        btnNewExploitant.Top = 0
        btnNewExploitant.Left = 0
        pnlPourcentage.Controls.Add(btnAjoutExploitant)
        btnAjoutExploitant.Top = 0
        btnAjoutExploitant.Left = btnNewExploitant.Width + 10
        'Par Défaut on désactive le Client
        EnableClient(False)
        Me.ControlBox = True

    End Sub

    ' Chargement de la page
    Private Sub diagnostic_finalisation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        ' Chargement des catégories de prestations
        Dim arrCategories() As PrestationCategorie = PrestationCategorieManager.getArrayByStructureId(m_oStructure.id)
        For Each tmpCategorie As PrestationCategorie In arrCategories
            If tmpCategorie.description IsNot Nothing Then
                Dim objComboItem As New objComboItem(tmpCategorie.id.ToString, tmpCategorie.description)
                listTarif_categories.Items.Add(objComboItem)
            End If
        Next
        listTarif_categories.SelectedItem = 1


        m_bsrcStructure.Add(m_oStructure)
        tbDernNumFact.Text = m_dernnumfact
        If m_TypeInit = TypeInit.INIT_FROM_DIAG Then
            m_bsDiag.Add(m_oDiag)
            m_bsContratCommercial.Add(m_oDiag.oContratCommercial)

            m_bsFacture.Clear()
            m_bsExploitant.Clear()
            'nb : il faut charge les factures avant les expoitants
            m_olstFacture.ForEach(Function(oFact) m_bsFacture.Add(oFact))
            m_bsExploitant.SuspendBinding()
            m_olstExploit.ForEach(Function(oExploit) m_bsExploitant.Add(oExploit))
            m_bsExploitant.MoveFirst()
            m_bsExploitant.ResumeBinding()
            SupprColumn.Visible = False
        End If
        If m_TypeInit = TypeInit.INIT_CONSULT_FACTURE Then
            m_bsFacture.Add(m_olstFacture(0))
            m_bsExploitant.Add(m_olstExploit(0))
            m_bsDiag.Add(m_oDiag)
            SupprColumn.Visible = False
        End If
        ActivationFacture()
        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region " Boutons "


#End Region

#Region " Calculs "

    ' Calcul du total

#End Region

#Region " Impressions "

    ' Impression facture
    Private Function createFacture_CR(pFacture As Facture) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oEtat As New EtatFacture2(pFacture, m_oAgent, m_oStructure)

            oEtat.genereEtat()
            pFacture.pathPDF = oEtat.getFileName()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("diagnostic_FacturationCoPro2::createFacture_CR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function



#End Region

#Region " Events "

    ' Mise a jour des listes déroulantes

#End Region


#Region " Controles saisie "

    Private Sub facturation_txTVA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_txTVA.KeyPress
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub
    Private Sub facturation_totalHT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles facturation_totalHT.KeyPress
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub
    Private Sub prix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub

#End Region




    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub


    Private Sub SauvegarderExploitants()
        'Sauvegarde des Exploitants
        m_olstExploit.ForEach(Sub(oExploit)
                                  ExploitationManager.save(oExploit, m_oAgent)
                                  If m_oPulverisateur IsNot Nothing Then
                                      ExploitationTOPulverisateurManager.save(m_oPulverisateur.id, oExploit.id, oExploit.isSuppressionCoprop, m_oAgent)
                                  End If
                              End Sub)
    End Sub
    Private Sub SauvegarderFactures()
        For Each oFacture As Facture In m_bsFacture
            If Not String.IsNullOrEmpty(oFacture.idFacture) Then
                createFacture_CR(oFacture)
                If m_oDiag IsNot Nothing Then
                    oFacture.idDiag = m_oDiag.id
                End If

                FactureManager.save(oFacture)
            End If
        Next
    End Sub


    Private Sub dgvLignes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLignes.CellContentClick
        If e.ColumnIndex = SupprColumn.Index Then
            'Suppresssion de la ligne courante
            m_bsLignes.RemoveCurrent()
            CalculTotaux()
        End If

    End Sub

    Private Sub dgvLignes_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLignes.RowValidated
        m_bsFacture.ResetCurrentItem()
    End Sub

    Private Sub dgvLignes_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs)
        m_bsFacture.ResetCurrentItem()
    End Sub

    Private Sub dgvLignes_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs)
        'm_bsFacture.ResetCurrentItem()

    End Sub

    Private Sub img_Add_Click(sender As Object, e As EventArgs) Handles img_Add.Click
        If Not listTarif_categories.SelectedItem Is Nothing And Not listTarif_prestations.SelectedItem Is Nothing Then
            If listTarif_categories.SelectedItem.libelle.ToString <> "" And listTarif_prestations.SelectedItem.libelle.ToString <> "" Then


                ' On récupère la presta sélectionnée
                Dim curPrestation As New PrestationTarif
                Try
                    curPrestation = PrestationTarifManager.getById(CType(listTarif_prestations.SelectedItem.id, Integer), m_oAgent.idStructure)
                Catch ex As Exception
                    CSDebug.dispError("Récupération tarif : " & ex.Message.ToString)
                End Try

                Dim PU As Decimal
                PU = curPrestation.tarifHT

                Dim oFact As Facture = m_bsFacture.Current
                Dim oLig As FactureItem = Nothing
                If m_oDiag IsNot Nothing Then
                    oLig = New FactureItem(listTarif_categories.SelectedItem.libelle.ToString, listTarif_prestations.SelectedItem.libelle.ToString, PU, 1, oFact.TxTVA, m_oDiag.id)
                Else
                    oLig = New FactureItem(listTarif_categories.SelectedItem.libelle.ToString, listTarif_prestations.SelectedItem.libelle.ToString, PU, 1, oFact.TxTVA, "")
                End If

                oFact.Lignes.Add(oLig)
                oFact.CalculTotaux()
                m_bsFacture.ResetCurrentItem()

            End If
        End If

    End Sub

    Private Sub listTarif_categories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listTarif_categories.SelectedIndexChanged
        setListeTarif()
    End Sub

    Private Sub setListeTarif()
        ' Chargement des prestations de la catégorie
        If listTarif_categories.SelectedItem.Id <> "" Then
            listTarif_prestations.Items.Clear()
            Dim arrPrestations() As PrestationTarif = PrestationTarifManager.getArrayByCategorieId(listTarif_categories.SelectedItem.Id)
            For Each tmpPrestation As PrestationTarif In arrPrestations
                Try
                    Dim objComboItem As New objComboItem(tmpPrestation.id.ToString, tmpPrestation.description)
                    listTarif_prestations.Items.Add(objComboItem)
                Catch ex As Exception
                    CSDebug.dispError("frmDiagnostic_facturation.setlistTarif : " & ex.Message.ToString)
                End Try
            Next
        End If
    End Sub

    Private Sub btnNewExploitant_Click(sender As Object, e As EventArgs) Handles btnNewExploitant.Click
        CreerExploitant()
    End Sub

    Private Sub CreerExploitant()
        Dim frm As New fiche_exploitant()
        Dim oExploit As New Exploitation()
        oExploit.raisonSociale = "Nouveau."
        frm.setContexte(False, oExploit, m_oAgent)
        If frm.ShowDialog() = DialogResult.OK Then
            If m_bModeCoProp Or m_olstExploit.Count() = 0 Then
                m_olstExploit.Add(oExploit)
                m_bsExploitant.Add(oExploit)
            Else
                m_olstExploit(0) = oExploit
                m_bsExploitant(0) = oExploit
            End If
            m_bsExploitant.MoveLast()
            EnableClient(True)
        End If
        frm.Close()
    End Sub

    Private Sub btnSupprCoProp_Click(sender As Object, e As EventArgs) Handles btnSupprCoProp.Click
        SuppressionCoProp()
    End Sub

    Private Sub SuppressionCoProp()
        Dim m_oExploit As Exploitation
        If m_bsExploitant.Current IsNot Nothing Then
            m_oExploit = m_bsExploitant.Current
            m_oExploit.isSuppressionCoprop = True
            If m_dgvCoProp.CurrentRow IsNot Nothing Then
                m_dgvCoProp.Rows.Remove(m_dgvCoProp.CurrentRow)
            End If
        End If
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub dgvLignes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvLignes.DataError
        CSDebug.dispInfo("fromDiagniostic_facturationcoProp.DataError", e.Exception)
    End Sub

    Private Sub btnAjoutExploitant_Click(sender As Object, e As EventArgs) Handles btnAjoutExploitant.Click
        Dim ofrm As New dlgListExploitant()
        ofrm.SetContexte(m_oAgent)
        If ofrm.ShowDialog() = DialogResult.OK Then
            If m_olstExploit.Where(Function(oExploit)
                                       Return oExploit.id = ofrm.oExploit.id
                                   End Function).Count() = 0 Then
                m_bsExploitant.SuspendBinding()
                If m_bModeCoProp Or m_olstExploit.Count() = 0 Then
                    m_olstExploit.Add(ofrm.oExploit)
                    m_bsExploitant.Add(ofrm.oExploit)
                Else
                    m_olstExploit(0) = ofrm.oExploit
                    m_bsExploitant(0) = ofrm.oExploit
                End If
                m_bsExploitant.MoveLast()
                m_bsExploitant.ResumeBinding()


            End If
            End If
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Try
            Dim pourcentage As Decimal = CDec(tbPourcent.Text)
            CalculerPourcentage(pourcentage)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CalculerPourcentage(pPourcentage As Decimal)
        Dim oFact As Facture
        oFact = m_bsFacture.Current
        For Each oLgC As FactureItem In m_oDiag.oContratCommercial.Lignes
            For Each oLgF As FactureItem In oFact.Lignes
                If oLgF.categorie = oLgC.categorie And oLgF.prestation = oLgF.prestation Then
                    oLgF.quantite = oLgC.quantite * (pPourcentage / 100)
                End If
            Next
        Next
        oFact.CalculTotaux()
        CalculRestAFacturer()
        m_bsFacture.ResetCurrentItem()
    End Sub

    Private Sub CalculRestAFacturer()
        If m_TypeInit = TypeInit.INIT_FROM_DIAG Then
            Dim TotalContat As Decimal = m_oDiag.TotalHT
            Dim TotalFacture As Decimal = 0
            'Pour Chaque facture
            For Each oFact As Facture In m_bsFacture.List
                If Not String.IsNullOrEmpty(oFact.idFacture) Then
                    'Pour Chaque liggne de facture
                    For Each oLgF As FactureItem In oFact.Lignes
                        'Si elle correspond as une ligne du contrat commercial
                        For Each oLgC As FactureItem In m_oDiag.oContratCommercial.Lignes
                            If oLgF.categorie = oLgC.categorie And oLgF.prestation = oLgF.prestation Then
                                'On Totalise son totalHT
                                TotalFacture = TotalFacture + oLgF.totalHT
                            End If
                        Next
                    Next oLgF
                End If
            Next oFact

            m_oDiag.oContratCommercial.ResteAFacturer = TotalContat - TotalFacture
            m_bsContratCommercial.ResetCurrentItem()
        End If
    End Sub

    Private Sub CalculTotaux()
        Dim oFact As Facture
        If m_bsFacture.Current IsNot Nothing Then
            oFact = m_bsFacture.Current
            oFact.CalculTotaux()
            m_bsFacture.ResetCurrentItem()
        End If
    End Sub
    Private Sub m_bsExploitant_CurrentChanged(sender As Object, e As EventArgs) Handles m_bsExploitant.CurrentChanged
        changementExploitant()
    End Sub
    Protected Overridable Function LoadCommunes(pCodePostal As String, Optional pCommune As String = "") As String
        Debug.Assert(Not String.IsNullOrEmpty(pCodePostal))
        Dim oReferentiel As ReferentielCommunesCSV
        Dim lstCommunes As List(Of Commune)
        oReferentiel = New ReferentielCommunesCSV()
        oReferentiel.load()
        m_bsCommunes.Clear()
        lstCommunes = oReferentiel.getCommunes(pCodePostal)

        lstCommunes.ForEach(Sub(c) m_bsCommunes.Add(c))
        If pCommune <> "" Then
            Dim index As Integer =
             lstCommunes.FindIndex(Function(oC)
                                       Return (oC.Nom = pCommune)

                                   End Function)
            m_bsCommunes.Position = index
        Else
            m_bsCommunes.Position = 0
        End If
        Return CType(m_bsCommunes.Current, Commune).CodePostal

    End Function

    Private Sub changementExploitant()
        Dim oExploit As Exploitation
        oExploit = m_bsExploitant.Current
        Dim nPos As Integer = 0
        Dim bTrouve As Boolean = False
        Dim oFact As Facture = Nothing

        Dim strCommune As String = oExploit.commune
        LoadCommunes(oExploit.codePostal, oExploit.commune)
        oExploit.commune = strCommune

        If oExploit.id = "" Then
            EnableClient(True)
        Else
            EnableClient(False)
        End If



        For Each oFact In m_bsFacture.List
            If oFact.oExploit.id = oExploit.id Then
                m_bsFacture.Position = nPos
                m_bsFacture.ResetCurrentItem()
                bTrouve = True
            End If
            nPos = nPos + 1
        Next

        If Not bTrouve Then
            If m_oDiag IsNot Nothing Then
                oFact = New Facture(m_oDiag, m_oStructure)
            Else
                oFact = New Facture(m_oStructure)
            End If
            oFact.oExploit = oExploit
            oFact.dateFacture = DateTime.Now
            If m_olstFacture.Count = 0 Or m_bModeCoProp Then
                m_olstFacture.Add(oFact)
                m_bsFacture.Add(oFact)
            Else
                m_olstFacture(0) = oFact
                m_bsFacture(0) = oFact
            End If
            m_bsFacture.MoveLast()

            End If

            CalculRestAFacturer()

    End Sub

    Private Sub tbResteAFacturer_TextChanged(sender As Object, e As EventArgs) Handles tbResteAFacturer.TextChanged
        Dim RAF As Decimal
        RAF = tbResteAFacturer.Text
        If RAF <> 0 Then
            tbResteAFacturer.BackColor = Color.Red
        Else
            tbResteAFacturer.BackColor = Color.Green
        End If
    End Sub

    Private Sub dgvLignes_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLignes.CellValueChanged

        If e.ColumnIndex = QuantiteColumn.Index Or e.ColumnIndex = PuColumn.Index Then
            CalculRestAFacturer()
            CalculTotaux()
        End If

    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        If m_TypeInit <> TypeInit.INIT_CONSULT_FACTURE Then
            If MsgBox("Cette action entraine la non-facturation des prestations décrites dans le contrat commercial, Voulez-annuler annuler la facturation ?", MsgBoxStyle.YesNo, "Facturation") = MsgBoxResult.Yes Then
                For Each oFact As Facture In m_bsFacture
                    If Not String.IsNullOrEmpty(oFact.pathPDF) Then
                        CSFile.delete(GlobalsCRODIP.CONST_PATH_EXP_FACTURE & "/" & oFact.pathPDF)
                    End If
                Next
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub m_bsFacture_CurrentChanged(sender As Object, e As EventArgs) Handles m_bsFacture.CurrentChanged
        ActivationFacture()

    End Sub

    Private Sub ActivationFacture()
        Dim bFactureOK As Boolean = m_bsFacture.Current IsNot Nothing

        pnlLines.Enabled = bFactureOK
        '        dgvLignes.Enabled = bFactureOK

        pnlFooter.Enabled = bFactureOK
        btnAnnuler.Enabled = True
        btnImprimer.Enabled = bFactureOK
        btnPoursuivre.Enabled = bFactureOK
    End Sub

    Private Sub tbCodePostal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodePostal.KeyPress
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 5)
        End If

    End Sub

    Private Sub tbCodePostal_Validated(sender As Object, e As EventArgs) Handles tbCodePostal.Validated
        Try
            If sender.text <> "" Then
                sender.text = LoadCommunes(sender.text)
            End If
        Catch ex As Exception
            CSDebug.dispError("frmDiagnostic_facturationCoProp.tbCodePostal_Validated : " & ex.Message)
        End Try

    End Sub

    Private Sub cbxCommune_Validated(sender As Object, e As EventArgs) Handles cbxCommune.Validated
        Dim oCommune As Commune
        oCommune = DirectCast(m_bsCommunes.Current, Commune)
        If oCommune IsNot Nothing Then
            Dim oExploit As Exploitation = m_bsExploitant.Current
            oExploit.codePostal = oCommune.CodePostal
            oExploit.commune = oCommune.Nom ' je n'arrive pas à la faire avec le databinding !!!
            oExploit.codeInsee = oCommune.CodeInsee
            m_bsExploitant.ResetCurrentItem()
        End If

    End Sub

    Private Sub tbRefReglement_Validated(sender As Object, e As EventArgs) Handles tbRefReglement.Validated

    End Sub

    Private Sub btnImprimer_Click(sender As Object, e As EventArgs) Handles btnImprimer.Click
        Me.Cursor = Cursors.WaitCursor

        Dim oFacture As Facture
        Dim oExploit As Exploitation
        oFacture = m_bsFacture.Current
        oExploit = m_bsExploitant.Current
        If String.IsNullOrEmpty(oFacture.idFacture) Then
            oFacture.setNumeroFacture(m_oStructure)
        End If
        Me.Cursor = Cursors.Default
        If createFacture_CR(oFacture) Then
            CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_FACTURE & "/" & oFacture.pathPDF)
            oExploit.Fact = "F"
            CalculRestAFacturer()
            m_bsExploitant.ResetCurrentItem()
            m_bsFacture.ResetCurrentItem()
            btnAnnuler.Visible = False
            If Not m_bModeCoProp Then
                btnNewExploitant.Enabled = False
                btnAjoutExploitant.Enabled = False
            End If

        End If


    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As EventArgs) Handles btnPoursuivre.Click
        Dim bOk As Boolean = True
        If m_TypeInit = TypeInit.INIT_FROM_DIAG Then
            If m_oDiag.oContratCommercial.ResteAFacturer <> 0 Then
                If MsgBox("Il reste des prestations à facturer : " & String.Format(m_oDiag.oContratCommercial.ResteAFacturer, "C") & vbCrLf &
                        "Voulez-vous continuer ?", MsgBoxStyle.YesNo, "Sauvegarde de facture") = MsgBoxResult.No Then
                    bOk = False
                End If
            End If
        End If
        If bOk Then
            Me.Cursor = Cursors.WaitCursor
            SauvegarderExploitants()
            SauvegarderFactures()
            m_oStructure.SauverDernierNumFact()
            Me.Cursor = Cursors.Default
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If

    End Sub
    Private Sub EnableClient(pEnable As Boolean)
        tbrsClient.Enabled = pEnable
        tbNomClient.Enabled = pEnable
        tbPrenomClient.Enabled = pEnable
        tbAdresseClient.Enabled = pEnable
        tbCodePostal.Enabled = pEnable
        cbxCommune.Enabled = pEnable
        tbTelFixe.Enabled = pEnable
        tbTelPortable.Enabled = pEnable
        tbEmail.Enabled = pEnable

        'on peut modifier le client
        'Si on est en nouvelle facture
        'Si no est en Diag en mode co-Prop

        btnAjoutExploitant.Enabled = m_TypeInit = TypeInit.INIT_NLLE_FACTURE
        btnNewExploitant.Enabled = m_TypeInit = TypeInit.INIT_NLLE_FACTURE
        If m_TypeInit = TypeInit.INIT_FROM_DIAG Then
            If m_oPulverisateur.isCoPropriete Then
                btnAjoutExploitant.Enabled = True
                btnNewExploitant.Enabled = True
            End If

        End If
    End Sub

    Private Sub dgvLignes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLignes.CellMouseDoubleClick

    End Sub
End Class
