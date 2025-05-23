Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CRODIPWS

Public Class diagnostic_ContratCommercial
    Inherits System.Windows.Forms.Form

    Public positionTop As Integer = 16
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents tbCommentaire As System.Windows.Forms.TextBox
    Friend WithEvents lblCommentaire As System.Windows.Forms.Label
    Friend WithEvents m_bsContratCommercial As BindingSource
    Friend WithEvents PUDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents columnDelete As DataGridViewImageColumn
    Friend WithEvents IdFactureDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategorieDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrestationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuantiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents m_bsLignes As BindingSource
    Friend WithEvents LignesBindingSource As BindingSource
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btnImprimerBL As Button
    Friend WithEvents btnImprimerContrat As Button
    Friend WithEvents btnSigner As Button
    Friend WithEvents btnSuivant As Button
    Friend WithEvents CategorieDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PrestationDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents QuantiteDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents TotalHTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SupprColumn As DataGridViewImageColumn
    Public prestaIncrement As Integer = 0

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label_diagnostic_61 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents listTarif_prestations As System.Windows.Forms.ComboBox
    Friend WithEvents img_Add As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents panelFooter As System.Windows.Forms.Panel
    Friend WithEvents listTarif_categories As System.Windows.Forms.ComboBox
    Friend WithEvents facturation_totalHT As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_ContratCommercial))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_diagnostic_61 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.listTarif_prestations = New System.Windows.Forms.ComboBox()
        Me.img_Add = New System.Windows.Forms.PictureBox()
        Me.panelFooter = New System.Windows.Forms.Panel()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnImprimerBL = New System.Windows.Forms.Button()
        Me.btnImprimerContrat = New System.Windows.Forms.Button()
        Me.btnSigner = New System.Windows.Forms.Button()
        Me.btnSuivant = New System.Windows.Forms.Button()
        Me.tbCommentaire = New System.Windows.Forms.TextBox()
        Me.lblCommentaire = New System.Windows.Forms.Label()
        Me.facturation_totalHT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SupprColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.m_bsLignes = New System.Windows.Forms.BindingSource(Me.components)
        Me.LignesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.columnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IdFactureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrestationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorieDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrestationDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantiteDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_bsContratCommercial = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelFooter.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsContratCommercial, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label3.Size = New System.Drawing.Size(322, 24)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "     Contrat Commercial"
        '
        'Label_diagnostic_61
        '
        Me.Label_diagnostic_61.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_61.Image = CType(resources.GetObject("Label_diagnostic_61.Image"), System.Drawing.Image)
        Me.Label_diagnostic_61.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_61.Location = New System.Drawing.Point(16, 32)
        Me.Label_diagnostic_61.Name = "Label_diagnostic_61"
        Me.Label_diagnostic_61.Size = New System.Drawing.Size(208, 29)
        Me.Label_diagnostic_61.TabIndex = 22
        Me.Label_diagnostic_61.Text = "     Ajouter une prestation : "
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(607, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "     Total HT..........................."
        '
        'listTarif_prestations
        '
        Me.listTarif_prestations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listTarif_prestations.Location = New System.Drawing.Point(453, 31)
        Me.listTarif_prestations.Name = "listTarif_prestations"
        Me.listTarif_prestations.Size = New System.Drawing.Size(200, 21)
        Me.listTarif_prestations.TabIndex = 1
        '
        'img_Add
        '
        Me.img_Add.Cursor = System.Windows.Forms.Cursors.Hand
        Me.img_Add.Image = CType(resources.GetObject("img_Add.Image"), System.Drawing.Image)
        Me.img_Add.Location = New System.Drawing.Point(661, 32)
        Me.img_Add.Name = "img_Add"
        Me.img_Add.Size = New System.Drawing.Size(16, 16)
        Me.img_Add.TabIndex = 29
        Me.img_Add.TabStop = False
        '
        'panelFooter
        '
        Me.panelFooter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelFooter.Controls.Add(Me.btnAnnuler)
        Me.panelFooter.Controls.Add(Me.btnImprimerBL)
        Me.panelFooter.Controls.Add(Me.btnImprimerContrat)
        Me.panelFooter.Controls.Add(Me.btnSigner)
        Me.panelFooter.Controls.Add(Me.btnSuivant)
        Me.panelFooter.Controls.Add(Me.tbCommentaire)
        Me.panelFooter.Controls.Add(Me.lblCommentaire)
        Me.panelFooter.Controls.Add(Me.Label1)
        Me.panelFooter.Controls.Add(Me.facturation_totalHT)
        Me.panelFooter.Controls.Add(Me.Label5)
        Me.panelFooter.Controls.Add(Me.Label9)
        Me.panelFooter.Controls.Add(Me.facturation_totalTVA)
        Me.panelFooter.Controls.Add(Me.Label12)
        Me.panelFooter.Controls.Add(Me.Label13)
        Me.panelFooter.Controls.Add(Me.facturation_totalTTC)
        Me.panelFooter.Controls.Add(Me.Label14)
        Me.panelFooter.Controls.Add(Me.Label15)
        Me.panelFooter.Controls.Add(Me.Label16)
        Me.panelFooter.Controls.Add(Me.tb_txTVA)
        Me.panelFooter.Controls.Add(Me.Label17)
        Me.panelFooter.Location = New System.Drawing.Point(15, 361)
        Me.panelFooter.Name = "panelFooter"
        Me.panelFooter.Size = New System.Drawing.Size(823, 208)
        Me.panelFooter.TabIndex = 2
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.BackgroundImage = Global.Crodip_agent.Resources.btn_retours
        Me.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAnnuler.FlatAppearance.BorderSize = 0
        Me.btnAnnuler.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Location = New System.Drawing.Point(6, 178)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(132, 27)
        Me.btnAnnuler.TabIndex = 87
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'btnImprimerBL
        '
        Me.btnImprimerBL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimerBL.BackgroundImage = Global.Crodip_agent.Resources.btn_divers_print
        Me.btnImprimerBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImprimerBL.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnImprimerBL.FlatAppearance.BorderSize = 0
        Me.btnImprimerBL.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimerBL.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimerBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimerBL.ForeColor = System.Drawing.Color.White
        Me.btnImprimerBL.Location = New System.Drawing.Point(154, 135)
        Me.btnImprimerBL.Name = "btnImprimerBL"
        Me.btnImprimerBL.Size = New System.Drawing.Size(188, 24)
        Me.btnImprimerBL.TabIndex = 86
        Me.btnImprimerBL.Text = "Imprimer le BL"
        Me.btnImprimerBL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimerBL.UseVisualStyleBackColor = False
        '
        'btnImprimerContrat
        '
        Me.btnImprimerContrat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimerContrat.BackgroundImage = Global.Crodip_agent.Resources.btn_divers_print
        Me.btnImprimerContrat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImprimerContrat.FlatAppearance.BorderSize = 0
        Me.btnImprimerContrat.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimerContrat.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnImprimerContrat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimerContrat.ForeColor = System.Drawing.Color.White
        Me.btnImprimerContrat.Location = New System.Drawing.Point(154, 178)
        Me.btnImprimerContrat.Name = "btnImprimerContrat"
        Me.btnImprimerContrat.Size = New System.Drawing.Size(188, 27)
        Me.btnImprimerContrat.TabIndex = 85
        Me.btnImprimerContrat.Text = "Imprimer le contrat"
        Me.btnImprimerContrat.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimerContrat.UseVisualStyleBackColor = True
        '
        'btnSigner
        '
        Me.btnSigner.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSigner.BackgroundImage = Global.Crodip_agent.Resources.btn_Signture
        Me.btnSigner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSigner.FlatAppearance.BorderSize = 0
        Me.btnSigner.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSigner.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSigner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSigner.ForeColor = System.Drawing.Color.White
        Me.btnSigner.Location = New System.Drawing.Point(527, 178)
        Me.btnSigner.Name = "btnSigner"
        Me.btnSigner.Size = New System.Drawing.Size(146, 27)
        Me.btnSigner.TabIndex = 84
        Me.btnSigner.Text = "Signer"
        Me.btnSigner.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSigner.UseVisualStyleBackColor = True
        '
        'btnSuivant
        '
        Me.btnSuivant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSuivant.BackgroundImage = Global.Crodip_agent.Resources.btn_valider
        Me.btnSuivant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSuivant.FlatAppearance.BorderSize = 0
        Me.btnSuivant.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnSuivant.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuivant.ForeColor = System.Drawing.Color.White
        Me.btnSuivant.Location = New System.Drawing.Point(679, 178)
        Me.btnSuivant.Name = "btnSuivant"
        Me.btnSuivant.Size = New System.Drawing.Size(136, 27)
        Me.btnSuivant.TabIndex = 83
        Me.btnSuivant.Text = "Valider"
        Me.btnSuivant.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSuivant.UseVisualStyleBackColor = True
        '
        'tbCommentaire
        '
        Me.tbCommentaire.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCommentaire.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsContratCommercial, "Commentaire", True))
        Me.tbCommentaire.Location = New System.Drawing.Point(110, 20)
        Me.tbCommentaire.Multiline = True
        Me.tbCommentaire.Name = "tbCommentaire"
        Me.tbCommentaire.Size = New System.Drawing.Size(470, 52)
        Me.tbCommentaire.TabIndex = 0
        Me.tbCommentaire.Visible = False
        '
        'lblCommentaire
        '
        Me.lblCommentaire.AutoSize = True
        Me.lblCommentaire.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommentaire.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.lblCommentaire.Location = New System.Drawing.Point(3, 20)
        Me.lblCommentaire.Name = "lblCommentaire"
        Me.lblCommentaire.Size = New System.Drawing.Size(87, 13)
        Me.lblCommentaire.TabIndex = 44
        Me.lblCommentaire.Text = "Commentaire :"
        Me.lblCommentaire.Visible = False
        '
        'facturation_totalHT
        '
        Me.facturation_totalHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalHT.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsContratCommercial, "TotalHT", True))
        Me.facturation_totalHT.Location = New System.Drawing.Point(760, 15)
        Me.facturation_totalHT.Name = "facturation_totalHT"
        Me.facturation_totalHT.Size = New System.Drawing.Size(43, 20)
        Me.facturation_totalHT.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(807, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(8, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "�"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label9.Location = New System.Drawing.Point(607, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(211, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "     TVA.........................."
        '
        'facturation_totalTVA
        '
        Me.facturation_totalTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsContratCommercial, "TotalTVA", True))
        Me.facturation_totalTVA.Location = New System.Drawing.Point(760, 89)
        Me.facturation_totalTVA.Name = "facturation_totalTVA"
        Me.facturation_totalTVA.ReadOnly = True
        Me.facturation_totalTVA.Size = New System.Drawing.Size(43, 20)
        Me.facturation_totalTVA.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(807, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(8, 16)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "�"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label13.Image = CType(resources.GetObject("Label13.Image"), System.Drawing.Image)
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label13.Location = New System.Drawing.Point(607, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "     Net � payer (TTC)...."
        '
        'facturation_totalTTC
        '
        Me.facturation_totalTTC.AcceptsReturn = True
        Me.facturation_totalTTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTTC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsContratCommercial, "TotalTTCStr", True))
        Me.facturation_totalTTC.Location = New System.Drawing.Point(760, 113)
        Me.facturation_totalTTC.Name = "facturation_totalTTC"
        Me.facturation_totalTTC.Size = New System.Drawing.Size(43, 20)
        Me.facturation_totalTTC.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(807, 111)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(8, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "�"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label15.Image = CType(resources.GetObject("Label15.Image"), System.Drawing.Image)
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label15.Location = New System.Drawing.Point(671, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "     Taux (%)"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label16.Location = New System.Drawing.Point(671, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 16)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "     Total"
        '
        'tb_txTVA
        '
        Me.tb_txTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_txTVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsContratCommercial, "TxTVA", True))
        Me.tb_txTVA.Location = New System.Drawing.Point(760, 65)
        Me.tb_txTVA.Name = "tb_txTVA"
        Me.tb_txTVA.Size = New System.Drawing.Size(43, 20)
        Me.tb_txTVA.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(807, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(8, 16)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "%"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'listTarif_categories
        '
        Me.listTarif_categories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listTarif_categories.Location = New System.Drawing.Point(237, 31)
        Me.listTarif_categories.Name = "listTarif_categories"
        Me.listTarif_categories.Size = New System.Drawing.Size(208, 21)
        Me.listTarif_categories.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CategorieDataGridViewTextBoxColumn1, Me.PrestationDataGridViewTextBoxColumn1, Me.QuantiteDataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.TotalHTDataGridViewTextBoxColumn, Me.SupprColumn})
        Me.DataGridView1.DataSource = Me.m_bsLignes
        Me.DataGridView1.Location = New System.Drawing.Point(12, 65)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.Size = New System.Drawing.Size(826, 290)
        Me.DataGridView1.TabIndex = 2
        '
        'SupprColumn
        '
        Me.SupprColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SupprColumn.HeaderText = "Suppr"
        Me.SupprColumn.Image = Global.Crodip_agent.Resources.delete
        Me.SupprColumn.Name = "SupprColumn"
        Me.SupprColumn.Width = 40
        '
        'm_bsLignes
        '
        Me.m_bsLignes.DataSource = Me.LignesBindingSource
        '
        'LignesBindingSource
        '
        Me.LignesBindingSource.DataMember = "Lignes"
        Me.LignesBindingSource.DataSource = Me.m_bsContratCommercial
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
        'IdFactureDataGridViewTextBoxColumn
        '
        Me.IdFactureDataGridViewTextBoxColumn.DataPropertyName = "idFacture"
        Me.IdFactureDataGridViewTextBoxColumn.HeaderText = "idFacture"
        Me.IdFactureDataGridViewTextBoxColumn.Name = "IdFactureDataGridViewTextBoxColumn"
        Me.IdFactureDataGridViewTextBoxColumn.Width = 55
        '
        'CategorieDataGridViewTextBoxColumn
        '
        Me.CategorieDataGridViewTextBoxColumn.DataPropertyName = "categorie"
        Me.CategorieDataGridViewTextBoxColumn.HeaderText = "categorie"
        Me.CategorieDataGridViewTextBoxColumn.Name = "CategorieDataGridViewTextBoxColumn"
        Me.CategorieDataGridViewTextBoxColumn.Width = 55
        '
        'PrestationDataGridViewTextBoxColumn
        '
        Me.PrestationDataGridViewTextBoxColumn.DataPropertyName = "prestation"
        Me.PrestationDataGridViewTextBoxColumn.HeaderText = "prestation"
        Me.PrestationDataGridViewTextBoxColumn.Name = "PrestationDataGridViewTextBoxColumn"
        Me.PrestationDataGridViewTextBoxColumn.Width = 55
        '
        'QuantiteDataGridViewTextBoxColumn
        '
        Me.QuantiteDataGridViewTextBoxColumn.DataPropertyName = "quantite"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.QuantiteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.QuantiteDataGridViewTextBoxColumn.HeaderText = "quantite"
        Me.QuantiteDataGridViewTextBoxColumn.Name = "QuantiteDataGridViewTextBoxColumn"
        Me.QuantiteDataGridViewTextBoxColumn.Width = 55
        '
        'CategorieDataGridViewTextBoxColumn1
        '
        Me.CategorieDataGridViewTextBoxColumn1.DataPropertyName = "categorie"
        Me.CategorieDataGridViewTextBoxColumn1.HeaderText = "Cat�gorie"
        Me.CategorieDataGridViewTextBoxColumn1.Name = "CategorieDataGridViewTextBoxColumn1"
        Me.CategorieDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'PrestationDataGridViewTextBoxColumn1
        '
        Me.PrestationDataGridViewTextBoxColumn1.DataPropertyName = "prestation"
        Me.PrestationDataGridViewTextBoxColumn1.HeaderText = "Prestation"
        Me.PrestationDataGridViewTextBoxColumn1.Name = "PrestationDataGridViewTextBoxColumn1"
        Me.PrestationDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'QuantiteDataGridViewTextBoxColumn1
        '
        Me.QuantiteDataGridViewTextBoxColumn1.DataPropertyName = "quantiteStr"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.QuantiteDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantiteDataGridViewTextBoxColumn1.HeaderText = "Quantit�"
        Me.QuantiteDataGridViewTextBoxColumn1.Name = "QuantiteDataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "pustr"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tarif"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'TotalHTDataGridViewTextBoxColumn
        '
        Me.TotalHTDataGridViewTextBoxColumn.DataPropertyName = "totalHT"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TotalHTDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalHTDataGridViewTextBoxColumn.HeaderText = "Total HT"
        Me.TotalHTDataGridViewTextBoxColumn.Name = "TotalHTDataGridViewTextBoxColumn"
        Me.TotalHTDataGridViewTextBoxColumn.ReadOnly = True
        '
        'm_bsContratCommercial
        '
        Me.m_bsContratCommercial.DataSource = GetType(ContratCommercial)
        '
        'diagnostic_ContratCommercial
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(856, 581)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.listTarif_categories)
        Me.Controls.Add(Me.panelFooter)
        Me.Controls.Add(Me.img_Add)
        Me.Controls.Add(Me.Label_diagnostic_61)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.listTarif_prestations)
        Me.Icon = Global.Crodip_agent.Resources.logoCRODIP
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diagnostic_ContratCommercial"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Crodip .::. Contrat Commercial"
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelFooter.ResumeLayout(False)
        Me.panelFooter.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsContratCommercial, System.ComponentModel.ISupportInitialize).EndInit()
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
#End Region
#Region " Chargement "
    Public Sub setContexte(pDiag As Diagnostic, pExploit As Exploitation, pAgent As Agent)
        Debug.Assert(pDiag IsNot Nothing)
        Debug.Assert(pExploit IsNot Nothing)
        Debug.Assert(pAgent IsNot Nothing)

        m_oDiag = pDiag
        m_oExploit = pExploit
        m_oAgent = pAgent
        m_oPulverisateur = PulverisateurManager.getPulverisateurById(m_oDiag.pulverisateurId)

        Dim oStructure As [Structure]
        oStructure = StructureManager.getStructureById(pAgent.idStructure)

        Dim oCC As New ContratCommercial
        oCC = m_oDiag.oContratCommercial
        If String.IsNullOrEmpty(oStructure.txTVA) Then
            oCC.TxTVA = My.Settings.TxTVADefaut
        Else
            oCC.TxTVA = oStructure.txTVA
        End If
        m_bsContratCommercial.Add(oCC)
    End Sub

    ' Chargement de la page
    Private Sub diagnostic_facturation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Debug.Assert(m_oDiag IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oExploit IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oAgent IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oPulverisateur IsNot Nothing, "Context must be set before")

        Me.WindowState = FormWindowState.Maximized
        Me.ControlBox = False

        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DIAG_TARIFS, False)
        Me.Cursor = Cursors.WaitCursor
        ' Chargement des cat�gories de prestations
        Dim arrCategories() As PrestationCategorie = PrestationCategorieManager.getArrayByStructureId(m_oAgent.idStructure)
        For Each tmpCategorie As PrestationCategorie In arrCategories
            If tmpCategorie.description IsNot Nothing Then
                Dim objComboItem As New objComboItem(tmpCategorie.id.ToString, tmpCategorie.description)
                listTarif_categories.Items.Add(objComboItem)
            End If
        Next
        listTarif_categories.SelectedItem = 1


        ' Dans le cas d'une contre-visite
        'isContreVisite = False
        'If isContreVisite Then
        '    facturation_totalTTC.Text = diagnosticCourant.controleTarif
        '    ' Changement d'�tat du bouton
        '    btn_facturation_suivant.Text = "Poursuivre"
        '    btn_facturation_imprimerContrat.Enabled = True
        '    btn_facturation_imprimerBL.Enabled = True
        '    isValider = True
        '    listTarif_categories.Enabled = False
        '    listTarif_prestations.Enabled = False
        'End If

        '======================
        ' Boutons de Signatures
        '=======================
        btnSigner.Visible = m_oAgent.isSignElecActive
        btnSigner.Enabled = False

        btnImprimerBL.Enabled = False
        btnImprimerContrat.Enabled = False

        Me.Cursor = Cursors.Default
        btnSuivant.Enabled = False

        btnSuivant.FlatAppearance.MouseOverBackColor = Me.BackColor
    End Sub

#End Region

#Region " Boutons "

    ' Ajout d'une ligne a la facture
    Private Sub img_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles img_Add.Click
        If Not listTarif_categories.SelectedItem Is Nothing And Not listTarif_prestations.SelectedItem Is Nothing Then
            If listTarif_categories.SelectedItem.libelle.ToString <> "" And listTarif_prestations.SelectedItem.libelle.ToString <> "" Then


                ' On r�cup�re la presta s�lectionn�e
                Dim curPrestation As New PrestationTarif
                Try
                    curPrestation = PrestationTarifManager.getByuId(CType(listTarif_prestations.SelectedItem.id, Integer), m_oAgent.idStructure)
                Catch ex As Exception
                    CSDebug.dispError("R�cup�ration tarif : " & ex.Message.ToString)
                End Try

                Dim PU As Decimal
                Dim oCC As ContratCommercial = m_bsContratCommercial.Current
                PU = curPrestation.tarifHT
                'Si le TX DE TVA est a 0 ET que c'est la premi�re ligne => on prend le Tx de la preta
                If oCC.TxTVA = 0 And oCC.Lignes.Count = 0 Then
                    oCC.TxTVA = curPrestation.tva
                End If

                Dim oLig As New FactureItem(listTarif_categories.SelectedItem.libelle.ToString, listTarif_prestations.SelectedItem.libelle.ToString, PU, 1, oCC.TxTVA, m_oDiag.id)

                oCC.Lignes.Add(oLig)
                oCC.CalculTotaux()


                ' On passe le total en readonly
                facturation_totalHT.ReadOnly = True
                tb_txTVA.ReadOnly = True
                facturation_totalTVA.ReadOnly = True
                facturation_totalTTC.ReadOnly = True
                m_bsContratCommercial.ResetCurrentItem()
                btnSigner.Enabled = True

            End If
        End If
    End Sub

    ' Validation des tarifs
    Private Sub suivant(sender As System.Object)
        sender.Enabled = False

        If isValider = True Then
            m_oDiag.oContratCommercial = m_bsContratCommercial.Current
            If MdiParent Is Nothing Then
                TryCast(Owner, parentContener).Action(New ActionFDiagNext())
            Else
                TryCast(MdiParent, parentContener).Action(New ActionFDiagNext())
            End If

        Else
            Dim oResult As MsgBoxResult = MsgBoxResult.Yes
            If m_oAgent.isSignElecActive Then
                If Not m_oDiag.isSignCCClient Or Not m_oDiag.isSignCCAgent Then
                    oResult = MsgBox("Attention, le contrat commercial n'est pas sign�, vous ne pourrez plus revenir en arri�re. Etes-vous s�r ?", MsgBoxStyle.YesNo, "Validation du contr�le")
                End If
            End If
            If oResult = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If facturation_totalTTC.Text <> "" Then
                    ' Enregistrement des tarifs
                    majDiag()
                    desactiveModifications()
                    createContrat()
                    createBl_CR()
                    ' Changement d'�tat du bouton
                    btnSuivant.Text = "Poursuivre"
                    btnImprimerContrat.Enabled = True
                    btnImprimerBL.Enabled = True
                    isValider = True
                    btnSigner.Enabled = False

                    Me.Cursor = Me.DefaultCursor

                    MsgBox("Vous devez maintenant imprimer le contrat commercial pour commencer le contr�le.", MsgBoxStyle.Information)
                Else
                    MsgBox("Vous devez renseigner un tarif pour pouvoir poursuivre.", MsgBoxStyle.Exclamation)
                End If
            End If
            sender.Enabled = True
        End If

    End Sub

    Private Sub majDiag()
        m_oDiag.oContratCommercial = m_bsContratCommercial.Current
    End Sub

#End Region

#Region " Calculs "

    ' Calcul du total
    Public Sub calcultotaux()

        Dim oContrat As ContratCommercial
        If m_bsContratCommercial.Current IsNot Nothing Then
            oContrat = m_bsContratCommercial.Current
            oContrat.CalculTotaux()
            m_bsContratCommercial.ResetCurrentItem()
        End If

    End Sub

#End Region

#Region " Impressions "


    ' Impression contrat commercial
    Dim pathContrat As String
    Private Function createContrat() As Boolean
        Dim bReturn As Boolean
        Try

            Dim oEtat As New EtatContratCommercial(m_oDiag)
            If oEtat.genereEtat(True) Then
                pathContrat = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & oEtat.getFileName()
                m_oDiag.CCFileName = oEtat.getFileName()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostic_facturation.createContrat ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ''' <summary>
    ''' Cr�ation du Bon de Livraison avec CrystalReport
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createBl_CR()


        Try
            'Dim factureObj As DiagnosticFacture
            'factureObj = Me.saveFacture()

            Dim oEtat As New EtatBL(m_oDiag)

            ' On rempli la liste des prestations
            For Each oLig As FactureItem In m_bsLignes
                oEtat.AddPresta(pLib:=oLig.categorie & " " & oLig.prestation, pPU:=oLig.pu, pQte:=oLig.quantite, pTxTVA:=oLig.txTVA, pTotalHT:=oLig.totalHT, pTotalTTC:=oLig.totalTTC)
            Next

            oEtat.genereEtat()
            m_pathBl = oEtat.getFileNameFullPath()
            m_oDiag.BLFileName = oEtat.getFileName()
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::createBL_CR : " & ex.Message)
        End Try


    End Sub


#End Region

#Region " Events "

    ' Mise a jour des listes d�roulantes
    Private Sub listTarif_categories_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listTarif_categories.SelectedIndexChanged
        ' Chargement des prestations de la cat�gorie
        If listTarif_categories.SelectedItem.Id <> "" Then
            listTarif_prestations.Items.Clear()
            Dim arrPrestations() As PrestationTarif = PrestationTarifManager.getArrayByCategorieId(listTarif_categories.SelectedItem.Id)
            For Each tmpPrestation As PrestationTarif In arrPrestations
                Try
                    Dim objComboItem As New objComboItem(tmpPrestation.uid.ToString, tmpPrestation.description)
                    listTarif_prestations.Items.Add(objComboItem)
                Catch ex As Exception
                    CSDebug.dispError("Diagnostic.listTarif : " & ex.Message.ToString)
                End Try
            Next
        End If
    End Sub


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





    Private Sub facturation_totalHT_TextChanged(sender As Object, e As EventArgs) Handles facturation_totalHT.Validated
        Dim prixTotalHT As Decimal = -1
        Dim prixTotalTTC As Decimal = 0
        Dim prixTxTVA As Decimal = 0

        If Not String.IsNullOrEmpty(facturation_totalHT.Text) Then
            prixTotalHT = CDec(facturation_totalHT.Text)
        End If
        'prixTotalTTC = IIf(Not String.IsNullOrEmpty(facturation_totalTTC.Text), CDec(facturation_totalTTC.Text), 0)
        If Not String.IsNullOrEmpty(facturation_totalTTC.Text) Then
            prixTotalTTC = CDec(facturation_totalTTC.Text)
        End If
        If prixTotalTTC = 0 And prixTotalHT <> -1 Then
            If Not String.IsNullOrEmpty(tb_txTVA.Text) Then
                prixTxTVA = CDec(tb_txTVA.Text)
            Else
                prixTxTVA = My.Settings.TxTVADefaut
            End If
            'Il n'y a pas de TTC alors qu'il y a un HT
            '=> Calcul TVA et TTC
            prixTotalTTC = prixTotalHT * (1 + (prixTxTVA / 100))
            facturation_totalHT.Text = Math.Round(prixTotalHT, 2)
            facturation_totalTTC.Text = Math.Round(prixTotalTTC, 2)
            facturation_totalTVA.Text = Math.Round(prixTotalTTC - prixTotalHT, 2)

        End If


    End Sub


    Private Sub desactiverModificationSisigne()
        If m_oDiag.SignCCAgent IsNot Nothing Or m_oDiag.SignCCClient IsNot Nothing Then
            desactiveModifications()
        End If
    End Sub

    Private Sub desactiveModifications()
        img_Add.Enabled = False
        facturation_totalHT.Enabled = False
        tb_txTVA.Enabled = False
        tbCommentaire.Enabled = False
        DataGridView1.Enabled = False
        listTarif_categories.Enabled = False
        listTarif_prestations.Enabled = False
    End Sub



    Private Sub DataGridView1_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowValidated
        calcultotaux()
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        calcultotaux()
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = SupprColumn.Index Then
            m_bsLignes.RemoveCurrent()
            calcultotaux()
        End If
    End Sub

    Private Sub m_bsContratCommercial_CurrentItemChanged(sender As Object, e As EventArgs) Handles m_bsContratCommercial.CurrentItemChanged
        Dim oCC As ContratCommercial
        oCC = m_bsContratCommercial.Current
        If oCC.TotalTTC <> 0 Or oCC.Lignes.Count() > 0 Then
            btnSuivant.Enabled = True
        Else
            btnSuivant.Enabled = False

        End If
    End Sub

    Private Sub Label3_MouseClick(sender As Object, e As MouseEventArgs) Handles Label3.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            facturation_totalHT.Text = "0"
            isValider = True
        End If
        suivant(sender)

    End Sub

    Private Sub facturation_totalTTC_Validated(sender As Object, e As EventArgs) Handles facturation_totalTTC.Validated
        btnSuivant.Enabled = True
    End Sub

    Private Sub img_Add_Move(sender As Object, e As EventArgs) Handles img_Add.Move

    End Sub

    Private Sub facturation_totalTTC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles facturation_totalTTC.KeyPress
        If e.KeyChar = vbCr Then
            btnSuivant.Enabled = True
            btnSuivant.Select()
        End If
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnImprimerBL_Click(sender As Object, e As EventArgs) Handles btnImprimerBL.Click
        ' On g�n�re le PDF rempli
        Try
            If String.IsNullOrEmpty(m_pathBl) Then
                createBl_CR()
            End If
            CSFile.open(m_pathBl)
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::btn_facturation_imprimerBL_Click( Affichage BL ) : " & ex.Message)
        End Try

    End Sub

    Private Sub btnImprimerContrat_Click(sender As Object, e As EventArgs) Handles btnImprimerContrat.Click
        Try
            If Not String.IsNullOrEmpty(m_oDiag.CCFileName) Then
                CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & m_oDiag.CCFileName)                ' On r�cup�re le Diagnostic selectionn�
            End If
        Catch ex As Exception
            CSDebug.dispError("btn_facturation_imprimerContrat_Click : " & ex.Message)
        End Try

    End Sub

    Private Sub btnSigner_Click(sender As Object, e As EventArgs) Handles btnSigner.Click
        Dim oFrm As New frmContratCommercial()
        majDiag()
        oFrm.setcontexte(m_oAgent, m_oDiag)
        oFrm.ShowDialog(Me)
        If oFrm.DialogResult = DialogResult.OK Then
            suivant(Me.btnSuivant)
        End If


    End Sub


    Private Sub btnSuivant_MouseClick(sender As Object, e As MouseEventArgs) Handles btnSuivant.MouseClick
        Me.ValidateChildren()
        suivant(sender)

    End Sub

    Private Sub diagnostic_ContratCommercial_DockChanged(sender As Object, e As EventArgs) Handles Me.DockChanged

    End Sub
End Class
