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

Public Class frmdiagnostic_facturationCoProp2
    Inherits System.Windows.Forms.Form

    Public positionTop As Integer = 16
    Friend WithEvents m_bsExploitant As System.Windows.Forms.BindingSource
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbCommentaire As System.Windows.Forms.TextBox
    Friend WithEvents btnNouvelleFacture As Button
    Private WithEvents btn_finalisationDiag_valider As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label27 As Label
    Friend WithEvents tbRacine As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents tbNumFact As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents dtpDateEcheance As DateTimePicker
    Friend WithEvents tbModeReglement As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDateFact As DateTimePicker
    Friend WithEvents Label24 As Label
    Friend WithEvents tbRefPaiement As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents ckReglee As CheckBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents pnlListCoProp As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button1 As Button
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
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents CategorieDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrestationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuantiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PUDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalHTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents columnDelete As DataGridViewImageColumn
    Friend WithEvents listTarif_categories As ComboBox
    Friend WithEvents img_Add As PictureBox
    Friend WithEvents Label_diagnostic_61 As Label
    Friend WithEvents listTarif_prestations As ComboBox
    Friend WithEvents m_bsrcStructure As BindingSource
    Friend WithEvents dgvLignes As System.Windows.Forms.DataGridView


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
    Friend WithEvents panelFooter As System.Windows.Forms.Panel
    Friend WithEvents btn_imprimerFactCoProp As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmdiagnostic_facturationCoProp2))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelFooter = New System.Windows.Forms.Panel()
        Me.listTarif_categories = New System.Windows.Forms.ComboBox()
        Me.img_Add = New System.Windows.Forms.PictureBox()
        Me.Label_diagnostic_61 = New System.Windows.Forms.Label()
        Me.listTarif_prestations = New System.Windows.Forms.ComboBox()
        Me.tbRefPaiement = New System.Windows.Forms.TextBox()
        Me.m_bsFacture = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ckReglee = New System.Windows.Forms.CheckBox()
        Me.dtpDateEcheance = New System.Windows.Forms.DateTimePicker()
        Me.tbModeReglement = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_finalisationDiag_valider = New System.Windows.Forms.Label()
        Me.btnNouvelleFacture = New System.Windows.Forms.Button()
        Me.tbCommentaire = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.facturation_totalHT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_imprimerFactCoProp = New System.Windows.Forms.Label()
        Me.facturation_totalTVA = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.facturation_totalTTC = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_txTVA = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgvLignes = New System.Windows.Forms.DataGridView()
        Me.CategorieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrestationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.m_bsLignes = New System.Windows.Forms.BindingSource(Me.components)
        Me.LignesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpDateFact = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbRacine = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tbNumFact = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlListCoProp = New System.Windows.Forms.Panel()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlClient = New System.Windows.Forms.Panel()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.m_bsExploitant = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbTelPortable = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbTelFixe = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.m_bsDiag = New System.Windows.Forms.BindingSource(Me.components)
        Me.m_bsrcStructure = New System.Windows.Forms.BindingSource(Me.components)
        Me.panelFooter.SuspendLayout()
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsFacture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLignes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListCoProp.SuspendLayout()
        Me.pnlClient.SuspendLayout()
        CType(Me.m_bsExploitant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcStructure, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Location = New System.Drawing.Point(687, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "     Total HT"
        '
        'panelFooter
        '
        Me.panelFooter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelFooter.Controls.Add(Me.listTarif_categories)
        Me.panelFooter.Controls.Add(Me.img_Add)
        Me.panelFooter.Controls.Add(Me.Label_diagnostic_61)
        Me.panelFooter.Controls.Add(Me.listTarif_prestations)
        Me.panelFooter.Controls.Add(Me.tbRefPaiement)
        Me.panelFooter.Controls.Add(Me.Label25)
        Me.panelFooter.Controls.Add(Me.ckReglee)
        Me.panelFooter.Controls.Add(Me.dtpDateEcheance)
        Me.panelFooter.Controls.Add(Me.tbModeReglement)
        Me.panelFooter.Controls.Add(Me.Label9)
        Me.panelFooter.Controls.Add(Me.Label2)
        Me.panelFooter.Controls.Add(Me.btn_finalisationDiag_valider)
        Me.panelFooter.Controls.Add(Me.btnNouvelleFacture)
        Me.panelFooter.Controls.Add(Me.tbCommentaire)
        Me.panelFooter.Controls.Add(Me.Label18)
        Me.panelFooter.Controls.Add(Me.Label1)
        Me.panelFooter.Controls.Add(Me.facturation_totalHT)
        Me.panelFooter.Controls.Add(Me.Label5)
        Me.panelFooter.Controls.Add(Me.btn_imprimerFactCoProp)
        Me.panelFooter.Controls.Add(Me.facturation_totalTVA)
        Me.panelFooter.Controls.Add(Me.Label12)
        Me.panelFooter.Controls.Add(Me.Label13)
        Me.panelFooter.Controls.Add(Me.facturation_totalTTC)
        Me.panelFooter.Controls.Add(Me.Label14)
        Me.panelFooter.Controls.Add(Me.Label15)
        Me.panelFooter.Controls.Add(Me.Label16)
        Me.panelFooter.Controls.Add(Me.tb_txTVA)
        Me.panelFooter.Controls.Add(Me.Label17)
        Me.panelFooter.Location = New System.Drawing.Point(12, 548)
        Me.panelFooter.Name = "panelFooter"
        Me.panelFooter.Size = New System.Drawing.Size(921, 168)
        Me.panelFooter.TabIndex = 2
        '
        'listTarif_categories
        '
        Me.listTarif_categories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listTarif_categories.Location = New System.Drawing.Point(462, 3)
        Me.listTarif_categories.Name = "listTarif_categories"
        Me.listTarif_categories.Size = New System.Drawing.Size(208, 21)
        Me.listTarif_categories.TabIndex = 74
        '
        'img_Add
        '
        Me.img_Add.Cursor = System.Windows.Forms.Cursors.Hand
        Me.img_Add.Image = CType(resources.GetObject("img_Add.Image"), System.Drawing.Image)
        Me.img_Add.Location = New System.Drawing.Point(886, 4)
        Me.img_Add.Name = "img_Add"
        Me.img_Add.Size = New System.Drawing.Size(16, 16)
        Me.img_Add.TabIndex = 77
        Me.img_Add.TabStop = False
        '
        'Label_diagnostic_61
        '
        Me.Label_diagnostic_61.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_61.Image = CType(resources.GetObject("Label_diagnostic_61.Image"), System.Drawing.Image)
        Me.Label_diagnostic_61.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_61.Location = New System.Drawing.Point(241, 4)
        Me.Label_diagnostic_61.Name = "Label_diagnostic_61"
        Me.Label_diagnostic_61.Size = New System.Drawing.Size(208, 22)
        Me.Label_diagnostic_61.TabIndex = 76
        Me.Label_diagnostic_61.Text = "     Ajouter une prestation : "
        '
        'listTarif_prestations
        '
        Me.listTarif_prestations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listTarif_prestations.Location = New System.Drawing.Point(678, 3)
        Me.listTarif_prestations.Name = "listTarif_prestations"
        Me.listTarif_prestations.Size = New System.Drawing.Size(200, 21)
        Me.listTarif_prestations.TabIndex = 75
        '
        'tbRefPaiement
        '
        Me.tbRefPaiement.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "RefPaiement", True))
        Me.tbRefPaiement.Location = New System.Drawing.Point(278, 104)
        Me.tbRefPaiement.Name = "tbRefPaiement"
        Me.tbRefPaiement.Size = New System.Drawing.Size(403, 20)
        Me.tbRefPaiement.TabIndex = 73
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
        Me.Label25.Location = New System.Drawing.Point(121, 107)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(147, 13)
        Me.Label25.TabIndex = 72
        Me.Label25.Text = "Reférence de paiement :"
        '
        'ckReglee
        '
        Me.ckReglee.AutoSize = True
        Me.ckReglee.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsFacture, "Reglee", True))
        Me.ckReglee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckReglee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ckReglee.Location = New System.Drawing.Point(13, 107)
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
        Me.dtpDateEcheance.Location = New System.Drawing.Point(120, 78)
        Me.dtpDateEcheance.Name = "dtpDateEcheance"
        Me.dtpDateEcheance.Size = New System.Drawing.Size(86, 20)
        Me.dtpDateEcheance.TabIndex = 67
        '
        'tbModeReglement
        '
        Me.tbModeReglement.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "Modereglement", True))
        Me.tbModeReglement.Location = New System.Drawing.Point(335, 78)
        Me.tbModeReglement.Name = "tbModeReglement"
        Me.tbModeReglement.Size = New System.Drawing.Size(345, 20)
        Me.tbModeReglement.TabIndex = 66
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(6, 81)
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
        Me.Label2.Location = New System.Drawing.Point(207, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Mode de réglement :"
        '
        'btn_finalisationDiag_valider
        '
        Me.btn_finalisationDiag_valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_finalisationDiag_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_valider.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_valider.Image = CType(resources.GetObject("btn_finalisationDiag_valider.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_valider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_finalisationDiag_valider.Location = New System.Drawing.Point(769, 135)
        Me.btn_finalisationDiag_valider.Name = "btn_finalisationDiag_valider"
        Me.btn_finalisationDiag_valider.Size = New System.Drawing.Size(134, 24)
        Me.btn_finalisationDiag_valider.TabIndex = 2
        Me.btn_finalisationDiag_valider.Text = "    Valider"
        Me.btn_finalisationDiag_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNouvelleFacture
        '
        Me.btnNouvelleFacture.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnNouvelleFacture.ForeColor = System.Drawing.Color.White
        Me.btnNouvelleFacture.Location = New System.Drawing.Point(259, 132)
        Me.btnNouvelleFacture.Name = "btnNouvelleFacture"
        Me.btnNouvelleFacture.Size = New System.Drawing.Size(134, 31)
        Me.btnNouvelleFacture.TabIndex = 0
        Me.btnNouvelleFacture.Text = "Nouvelle facture"
        Me.btnNouvelleFacture.UseVisualStyleBackColor = False
        '
        'tbCommentaire
        '
        Me.tbCommentaire.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "Commentaire", True))
        Me.tbCommentaire.Location = New System.Drawing.Point(120, 29)
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
        Me.Label18.Location = New System.Drawing.Point(10, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 13)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "Commentaire :"
        '
        'facturation_totalHT
        '
        Me.facturation_totalHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalHT.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "TotalHT", True))
        Me.facturation_totalHT.Location = New System.Drawing.Point(863, 26)
        Me.facturation_totalHT.Name = "facturation_totalHT"
        Me.facturation_totalHT.Size = New System.Drawing.Size(43, 20)
        Me.facturation_totalHT.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(906, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(8, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "€"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_imprimerFactCoProp
        '
        Me.btn_imprimerFactCoProp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_imprimerFactCoProp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_imprimerFactCoProp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimerFactCoProp.ForeColor = System.Drawing.Color.White
        Me.btn_imprimerFactCoProp.Image = Global.Crodip_agent.Resources.btn_divers_print
        Me.btn_imprimerFactCoProp.Location = New System.Drawing.Point(504, 135)
        Me.btn_imprimerFactCoProp.Name = "btn_imprimerFactCoProp"
        Me.btn_imprimerFactCoProp.Size = New System.Drawing.Size(192, 24)
        Me.btn_imprimerFactCoProp.TabIndex = 1
        Me.btn_imprimerFactCoProp.Text = "    Imprimer"
        Me.btn_imprimerFactCoProp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'facturation_totalTVA
        '
        Me.facturation_totalTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "TotalTVA", True))
        Me.facturation_totalTVA.Location = New System.Drawing.Point(863, 76)
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
        Me.Label12.Location = New System.Drawing.Point(906, 73)
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
        Me.Label13.Location = New System.Drawing.Point(692, 106)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "     Net à payer (TTC)...."
        '
        'facturation_totalTTC
        '
        Me.facturation_totalTTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTTC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "TotalTTC", True))
        Me.facturation_totalTTC.Location = New System.Drawing.Point(863, 102)
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
        Me.Label14.Location = New System.Drawing.Point(906, 103)
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
        Me.Label15.Location = New System.Drawing.Point(710, 53)
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
        Me.Label16.Location = New System.Drawing.Point(713, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(146, 16)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "     Total TVA"
        '
        'tb_txTVA
        '
        Me.tb_txTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_txTVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsFacture, "TxTVA", True))
        Me.tb_txTVA.Location = New System.Drawing.Point(863, 52)
        Me.tb_txTVA.Name = "tb_txTVA"
        Me.tb_txTVA.Size = New System.Drawing.Size(43, 20)
        Me.tb_txTVA.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(906, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(8, 16)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "%"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvLignes
        '
        Me.dgvLignes.AllowUserToAddRows = False
        Me.dgvLignes.AllowUserToDeleteRows = False
        Me.dgvLignes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLignes.AutoGenerateColumns = False
        Me.dgvLignes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLignes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLignes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CategorieDataGridViewTextBoxColumn, Me.PrestationDataGridViewTextBoxColumn, Me.QuantiteDataGridViewTextBoxColumn, Me.PUDataGridViewTextBoxColumn, Me.TotalHTDataGridViewTextBoxColumn, Me.columnDelete})
        Me.dgvLignes.DataSource = Me.m_bsLignes
        Me.dgvLignes.Location = New System.Drawing.Point(12, 380)
        Me.dgvLignes.Name = "dgvLignes"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLignes.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLignes.Size = New System.Drawing.Size(904, 162)
        Me.dgvLignes.TabIndex = 1
        '
        'CategorieDataGridViewTextBoxColumn
        '
        Me.CategorieDataGridViewTextBoxColumn.DataPropertyName = "Categorie"
        Me.CategorieDataGridViewTextBoxColumn.HeaderText = "Categorie"
        Me.CategorieDataGridViewTextBoxColumn.Name = "CategorieDataGridViewTextBoxColumn"
        Me.CategorieDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PrestationDataGridViewTextBoxColumn
        '
        Me.PrestationDataGridViewTextBoxColumn.DataPropertyName = "Prestation"
        Me.PrestationDataGridViewTextBoxColumn.HeaderText = "Prestation"
        Me.PrestationDataGridViewTextBoxColumn.Name = "PrestationDataGridViewTextBoxColumn"
        Me.PrestationDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuantiteDataGridViewTextBoxColumn
        '
        Me.QuantiteDataGridViewTextBoxColumn.DataPropertyName = "Quantite"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.QuantiteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantiteDataGridViewTextBoxColumn.HeaderText = "Quantite"
        Me.QuantiteDataGridViewTextBoxColumn.Name = "QuantiteDataGridViewTextBoxColumn"
        '
        'PUDataGridViewTextBoxColumn
        '
        Me.PUDataGridViewTextBoxColumn.DataPropertyName = "PU"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PUDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PUDataGridViewTextBoxColumn.HeaderText = "PU"
        Me.PUDataGridViewTextBoxColumn.Name = "PUDataGridViewTextBoxColumn"
        '
        'TotalHTDataGridViewTextBoxColumn
        '
        Me.TotalHTDataGridViewTextBoxColumn.DataPropertyName = "TotalHT"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TotalHTDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalHTDataGridViewTextBoxColumn.HeaderText = "TotalHT"
        Me.TotalHTDataGridViewTextBoxColumn.Name = "TotalHTDataGridViewTextBoxColumn"
        Me.TotalHTDataGridViewTextBoxColumn.ReadOnly = True
        '
        'columnDelete
        '
        Me.columnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.columnDelete.HeaderText = "Suppr"
        Me.columnDelete.Image = Global.Crodip_agent.Resources.delete
        Me.columnDelete.Name = "columnDelete"
        Me.columnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnDelete.Width = 40
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
        Me.Panel1.Controls.Add(Me.TextBox13)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.tbNumFact)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Location = New System.Drawing.Point(13, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 120)
        Me.Panel1.TabIndex = 64
        '
        'dtpDateFact
        '
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
        'TextBox13
        '
        Me.TextBox13.Enabled = False
        Me.TextBox13.Location = New System.Drawing.Point(209, 29)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(108, 20)
        Me.TextBox13.TabIndex = 71
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
        Me.tbNumFact.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcStructure, "DernierNumFact", True))
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
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.DataGridView2.Location = New System.Drawing.Point(8, 0)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(203, 150)
        Me.DataGridView2.TabIndex = 42
        '
        'Column1
        '
        Me.Column1.HeaderText = "Nom"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Commune"
        Me.Column2.Name = "Column2"
        '
        'pnlListCoProp
        '
        Me.pnlListCoProp.Controls.Add(Me.TextBox8)
        Me.pnlListCoProp.Controls.Add(Me.Button2)
        Me.pnlListCoProp.Controls.Add(Me.Label20)
        Me.pnlListCoProp.Controls.Add(Me.Label19)
        Me.pnlListCoProp.Controls.Add(Me.TextBox7)
        Me.pnlListCoProp.Controls.Add(Me.Button4)
        Me.pnlListCoProp.Controls.Add(Me.Button1)
        Me.pnlListCoProp.Controls.Add(Me.DataGridView2)
        Me.pnlListCoProp.Location = New System.Drawing.Point(13, 164)
        Me.pnlListCoProp.Name = "pnlListCoProp"
        Me.pnlListCoProp.Size = New System.Drawing.Size(308, 210)
        Me.pnlListCoProp.TabIndex = 66
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(164, 182)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(70, 20)
        Me.TextBox8.TabIndex = 63
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(240, 152)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 26)
        Me.Button2.TabIndex = 61
        Me.Button2.Text = "Calculer"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(8, 184)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(111, 13)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = "Reste à facturer : "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(7, 159)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(174, 13)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "Pourcentage de facturation : "
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(187, 156)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(47, 20)
        Me.TextBox7.TabIndex = 60
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Aqua
        Me.Button4.Location = New System.Drawing.Point(217, 68)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 33)
        Me.Button4.TabIndex = 51
        Me.Button4.Text = "Nouveau"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Aqua
        Me.Button1.Location = New System.Drawing.Point(217, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 33)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "Sélectionner ->"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pnlClient
        '
        Me.pnlClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlClient.Controls.Add(Me.tbEmail)
        Me.pnlClient.Controls.Add(Me.Label23)
        Me.pnlClient.Controls.Add(Me.tbTelPortable)
        Me.pnlClient.Controls.Add(Me.Label22)
        Me.pnlClient.Controls.Add(Me.tbTelFixe)
        Me.pnlClient.Controls.Add(Me.Label21)
        Me.pnlClient.Controls.Add(Me.TextBox6)
        Me.pnlClient.Controls.Add(Me.Label11)
        Me.pnlClient.Controls.Add(Me.Label10)
        Me.pnlClient.Controls.Add(Me.TextBox5)
        Me.pnlClient.Controls.Add(Me.TextBox4)
        Me.pnlClient.Controls.Add(Me.TextBox3)
        Me.pnlClient.Controls.Add(Me.TextBox2)
        Me.pnlClient.Controls.Add(Me.TextBox1)
        Me.pnlClient.Controls.Add(Me.Label8)
        Me.pnlClient.Controls.Add(Me.Label7)
        Me.pnlClient.Controls.Add(Me.Label6)
        Me.pnlClient.Controls.Add(Me.Label4)
        Me.pnlClient.Location = New System.Drawing.Point(327, 164)
        Me.pnlClient.Name = "pnlClient"
        Me.pnlClient.Size = New System.Drawing.Size(594, 172)
        Me.pnlClient.TabIndex = 0
        '
        'tbEmail
        '
        Me.tbEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "eMail", True))
        Me.tbEmail.Location = New System.Drawing.Point(383, 141)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(208, 20)
        Me.tbEmail.TabIndex = 7
        '
        'm_bsExploitant
        '
        Me.m_bsExploitant.DataSource = GetType(Crodip_agent.Exploitation)
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(332, 144)
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
        Me.tbTelPortable.Size = New System.Drawing.Size(71, 20)
        Me.tbTelPortable.TabIndex = 6
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(173, 144)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 13)
        Me.Label22.TabIndex = 70
        Me.Label22.Text = "Tel portable  :"
        '
        'tbTelFixe
        '
        Me.tbTelFixe.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "telephoneFixe", True))
        Me.tbTelFixe.Location = New System.Drawing.Point(96, 141)
        Me.tbTelFixe.Name = "tbTelFixe"
        Me.tbTelFixe.Size = New System.Drawing.Size(71, 20)
        Me.tbTelFixe.TabIndex = 5
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(4, 144)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 13)
        Me.Label21.TabIndex = 68
        Me.Label21.Text = "Tel Fixe  :"
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "raisonSociale", True))
        Me.TextBox6.Location = New System.Drawing.Point(96, 11)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(495, 20)
        Me.TextBox6.TabIndex = 0
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
        'TextBox5
        '
        Me.TextBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "prenomExploitant", True))
        Me.TextBox5.Location = New System.Drawing.Point(96, 63)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(494, 20)
        Me.TextBox5.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "commune", True))
        Me.TextBox4.Location = New System.Drawing.Point(260, 115)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(331, 20)
        Me.TextBox4.TabIndex = 4
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "codePostal", True))
        Me.TextBox3.Location = New System.Drawing.Point(96, 115)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(71, 20)
        Me.TextBox3.TabIndex = 60
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "adresse", True))
        Me.TextBox2.Location = New System.Drawing.Point(96, 89)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(495, 20)
        Me.TextBox2.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "nomExploitant", True))
        Me.TextBox1.Location = New System.Drawing.Point(96, 37)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(494, 20)
        Me.TextBox1.TabIndex = 1
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
        'm_bsDiag
        '
        Me.m_bsDiag.DataSource = GetType(Crodip_agent.Diagnostic)
        '
        'm_bsrcStructure
        '
        Me.m_bsrcStructure.DataSource = GetType(Crodip_agent.Structuree)
        '
        'frmdiagnostic_facturationCoProp2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(933, 728)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvLignes)
        Me.Controls.Add(Me.pnlClient)
        Me.Controls.Add(Me.pnlListCoProp)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelFooter)
        Me.Controls.Add(Me.Label3)
        Me.Icon = Global.Crodip_agent.Resources.logoCRODIP
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmdiagnostic_facturationCoProp2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Crodip .::. Facturation"
        Me.panelFooter.ResumeLayout(False)
        Me.panelFooter.PerformLayout()
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsFacture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLignes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListCoProp.ResumeLayout(False)
        Me.pnlListCoProp.PerformLayout()
        Me.pnlClient.ResumeLayout(False)
        Me.pnlClient.PerformLayout()
        CType(Me.m_bsExploitant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsDiag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcStructure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " - Vars - "
    Private isValider As Boolean = False
    Private m_pathBl As String
    Private m_pathFacture As String
    Protected m_oDiag As Diagnostic
    Protected m_oExploit As Exploitation
    Protected m_oPulverisateur As Pulverisateur
    Protected m_oAgent As Agent
    Protected m_oFacture As Facture
    Protected m_oStructure As Structuree
#End Region
#Region " Chargement "
    Public Sub setContexte(pDiag As Diagnostic, pAgent As Agent, pStructure As Structuree)
        Debug.Assert(pDiag IsNot Nothing)
        Debug.Assert(pDiag.oContratCommercial IsNot Nothing)
        Debug.Assert(pAgent IsNot Nothing)

        m_oDiag = pDiag
        m_oExploit = ExploitationManager.getExploitationById(m_oDiag.proprietaireId)
        m_oAgent = pAgent
        m_oPulverisateur = PulverisateurManager.getPulverisateurById(m_oDiag.pulverisateurId)

        m_oFacture = New Facture(m_oDiag.oContratCommercial, pStructure)
        m_oFacture.oExploit = m_oExploit
        m_bsFacture.Add(m_oFacture)

        dgvLignes.AllowUserToAddRows = False
        dgvLignes.AllowUserToDeleteRows = False

        m_bsExploitant.Clear()
        m_bsExploitant.Add(m_oExploit)

        If m_oPulverisateur.modeUtilisation <> "Co-Propriété" Then
            pnlListCoProp.Visible = False
            pnlClient.Left = pnlListCoProp.Left
            pnlClient.Width = pnlClient.Width + pnlListCoProp.Width
            dgvLignes.Top = pnlClient.Top + pnlClient.Height + 6
            dgvLignes.Height = panelFooter.Top - 6 - dgvLignes.Top


            btnNouvelleFacture.Visible = False
        End If

        If pStructure Is Nothing Then
            m_oStructure = StructureManager.getStructureById(m_oAgent.idStructure)
        Else
            m_oStructure = pStructure
        End If
        m_bsrcStructure.Add(m_oStructure)
    End Sub

    ' Chargement de la page
    Private Sub diagnostic_finalisation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Debug.Assert(m_oDiag IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oExploit IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oAgent IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oPulverisateur IsNot Nothing, "Context must be set before")

        Me.Cursor = Cursors.WaitCursor
        ' Chargement des catégories de prestations
        Dim arrCategories() As PrestationCategorie = PrestationCategorieManager.getArrayByStructureId(m_oAgent.idStructure)
        For Each tmpCategorie As PrestationCategorie In arrCategories
            If tmpCategorie.description IsNot Nothing Then
                Dim objComboItem As New objComboItem(tmpCategorie.id.ToString, tmpCategorie.description)
                listTarif_categories.Items.Add(objComboItem)
            End If
        Next
        listTarif_categories.SelectedItem = 1

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
    Private Sub createFacture_CR()

        Try
            Dim oFacture As Facture
            oFacture = m_bsFacture.Current
            Dim oEtat As New EtatFacture2(oFacture, m_oAgent, m_oStructure)

            oEtat.genereEtat()
            m_pathFacture = oEtat.getFileNameFullPath()
        Catch ex As Exception
            CSDebug.dispError("diagnostic_FacturationCoPro2::createFacture_CR : " & ex.Message)
        End Try



    End Sub

    Private Function saveFacture(pReference As String) As DiagnosticFacture
        Dim facture As DiagnosticFacture = New DiagnosticFacture
        Try
            '####
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim oStructure As Structuree = StructureManager.getStructureById(m_oDiag.organismePresId)
            '####

            '######################################################################################

            facture.id = DiagnosticFactureManager.getNewId()
            facture.factureReference = pReference
            facture.factureDate = Format(Date.Now, "dd/MM/yyyy")
            facture.factureTotal = facturation_totalTTC.Text
            facture.emetteurOrganisme = oStructure.nom
            facture.emetteurOrganismeAdresse = oStructure.adresse
            facture.emetteurOrganismeCpVille = oStructure.codePostal & " " & oStructure.commune
            facture.emetteurOrganismeTelFax = oStructure.telephoneFixe & " / " & oStructure.telephoneFax
            facture.emetteurOrganismeSiren = FACTURATION_XML_CONFIG.getElementValue("/root/siren")
            facture.emetteurOrganismeTva = FACTURATION_XML_CONFIG.getElementValue("/root/tva")
            facture.emetteurOrganismeRcs = FACTURATION_XML_CONFIG.getElementValue("/root/rcs")
            facture.recepteurRaisonSociale = m_oExploit.raisonSociale
            facture.recepteurProprio = m_oExploit.nomExploitant & " " & m_oExploit.prenomExploitant
            facture.recepteurCpVille = m_oExploit.codePostal & " " & m_oExploit.commune
            DiagnosticFactureManager.save(facture)

        Catch ex As Exception

        End Try
        Return facture
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



    Private Sub btn_imprimerFactCoProp_Click(sender As Object, e As EventArgs) Handles btn_imprimerFactCoProp.Click

        Me.ValidateChildren()

        m_oFacture.RefFacture = m_oStructure.RacineNumFact & tbNumFact.Text
        m_oStructure.DernierNumFact = tbNumFact.Text
        createFacture_CR()

        CSFile.open(m_pathFacture)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub btn_finalisationDiag_valider_Click(sender As Object, e As EventArgs) Handles btn_finalisationDiag_valider.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvLignes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLignes.CellContentClick
        If e.ColumnIndex = columnDelete.Index Then
            'Suppresssion de la ligne courante
            m_bsLignes.RemoveCurrent()
        End If

    End Sub

    Private Sub dgvLignes_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLignes.RowValidated
        m_bsFacture.ResetCurrentItem()
    End Sub

    Private Sub dgvLignes_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvLignes.RowsRemoved
        m_bsFacture.ResetCurrentItem()
    End Sub

    Private Sub dgvLignes_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvLignes.RowsAdded
        m_bsFacture.ResetCurrentItem()

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

                Dim oLig As New lgPrestation(listTarif_categories.SelectedItem.libelle.ToString, listTarif_prestations.SelectedItem.libelle.ToString, PU, 1, m_oDiag.id)

                Dim oCC As ContratCommercial = m_bsFacture.Current
                oCC.Lignes.Add(oLig)

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
End Class
