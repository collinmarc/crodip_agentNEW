Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class diagnostic_facturation
    Inherits System.Windows.Forms.Form

    Public positionTop As Integer = 16
    Friend WithEvents btn_ImprimerFacture As System.Windows.Forms.Label
    Friend WithEvents m_bsLignes As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixUnitaireDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TvaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrixTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnDelete As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_imprimerFactureCoProp As System.Windows.Forms.Label
    Friend WithEvents tbCommentaire As System.Windows.Forms.TextBox
    Friend WithEvents lblCommentaire As System.Windows.Forms.Label

    Public prestaIncrement As Integer = 0

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
    Friend WithEvents Label_diagnostic_61 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents listTarif_prestations As System.Windows.Forms.ComboBox
    Friend WithEvents img_Add As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents panelFooter As System.Windows.Forms.Panel
    Friend WithEvents listTarif_categories As System.Windows.Forms.ComboBox
    Friend WithEvents btn_facturation_suivant As System.Windows.Forms.Label
    Friend WithEvents btn_facturation_imprimerContrat As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents btn_facturation_imprimerBL As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_facturation))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_diagnostic_61 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.listTarif_prestations = New System.Windows.Forms.ComboBox()
        Me.img_Add = New System.Windows.Forms.PictureBox()
        Me.panelFooter = New System.Windows.Forms.Panel()
        Me.tbCommentaire = New System.Windows.Forms.TextBox()
        Me.lblCommentaire = New System.Windows.Forms.Label()
        Me.btn_imprimerFactureCoProp = New System.Windows.Forms.Label()
        Me.btn_ImprimerFacture = New System.Windows.Forms.Label()
        Me.btn_facturation_imprimerContrat = New System.Windows.Forms.Label()
        Me.facturation_totalHT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_facturation_suivant = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_facturation_imprimerBL = New System.Windows.Forms.Label()
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
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrixUnitaireDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TvaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrixTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.m_bsLignes = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelFooter.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label3.Size = New System.Drawing.Size(216, 24)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "     Facturation"
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
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(705, 16)
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
        Me.panelFooter.Controls.Add(Me.tbCommentaire)
        Me.panelFooter.Controls.Add(Me.lblCommentaire)
        Me.panelFooter.Controls.Add(Me.btn_imprimerFactureCoProp)
        Me.panelFooter.Controls.Add(Me.btn_ImprimerFacture)
        Me.panelFooter.Controls.Add(Me.btn_facturation_imprimerContrat)
        Me.panelFooter.Controls.Add(Me.Label1)
        Me.panelFooter.Controls.Add(Me.facturation_totalHT)
        Me.panelFooter.Controls.Add(Me.Label5)
        Me.panelFooter.Controls.Add(Me.btn_facturation_suivant)
        Me.panelFooter.Controls.Add(Me.Label2)
        Me.panelFooter.Controls.Add(Me.btn_facturation_imprimerBL)
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
        Me.panelFooter.Location = New System.Drawing.Point(15, 402)
        Me.panelFooter.Name = "panelFooter"
        Me.panelFooter.Size = New System.Drawing.Size(921, 206)
        Me.panelFooter.TabIndex = 2
        '
        'tbCommentaire
        '
        Me.tbCommentaire.Location = New System.Drawing.Point(110, 20)
        Me.tbCommentaire.Multiline = True
        Me.tbCommentaire.Name = "tbCommentaire"
        Me.tbCommentaire.Size = New System.Drawing.Size(552, 52)
        Me.tbCommentaire.TabIndex = 45
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
        'btn_imprimerFactureCoProp
        '
        Me.btn_imprimerFactureCoProp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_imprimerFactureCoProp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_imprimerFactureCoProp.Enabled = False
        Me.btn_imprimerFactureCoProp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimerFactureCoProp.ForeColor = System.Drawing.Color.White
        Me.btn_imprimerFactureCoProp.Image = CType(resources.GetObject("btn_imprimerFactureCoProp.Image"), System.Drawing.Image)
        Me.btn_imprimerFactureCoProp.Location = New System.Drawing.Point(151, 132)
        Me.btn_imprimerFactureCoProp.Name = "btn_imprimerFactureCoProp"
        Me.btn_imprimerFactureCoProp.Size = New System.Drawing.Size(180, 24)
        Me.btn_imprimerFactureCoProp.TabIndex = 34
        Me.btn_imprimerFactureCoProp.Text = "      Factures co-propriétaires"
        Me.btn_imprimerFactureCoProp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_imprimerFactureCoProp.Visible = False
        '
        'btn_ImprimerFacture
        '
        Me.btn_ImprimerFacture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ImprimerFacture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ImprimerFacture.Enabled = False
        Me.btn_ImprimerFacture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ImprimerFacture.ForeColor = System.Drawing.Color.White
        Me.btn_ImprimerFacture.Image = CType(resources.GetObject("btn_ImprimerFacture.Image"), System.Drawing.Image)
        Me.btn_ImprimerFacture.Location = New System.Drawing.Point(151, 168)
        Me.btn_ImprimerFacture.Name = "btn_ImprimerFacture"
        Me.btn_ImprimerFacture.Size = New System.Drawing.Size(180, 24)
        Me.btn_ImprimerFacture.TabIndex = 33
        Me.btn_ImprimerFacture.Text = "      Facture client"
        Me.btn_ImprimerFacture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_ImprimerFacture.Visible = False
        '
        'btn_facturation_imprimerContrat
        '
        Me.btn_facturation_imprimerContrat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_facturation_imprimerContrat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_facturation_imprimerContrat.Enabled = False
        Me.btn_facturation_imprimerContrat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_facturation_imprimerContrat.ForeColor = System.Drawing.Color.White
        Me.btn_facturation_imprimerContrat.Image = CType(resources.GetObject("btn_facturation_imprimerContrat.Image"), System.Drawing.Image)
        Me.btn_facturation_imprimerContrat.Location = New System.Drawing.Point(536, 168)
        Me.btn_facturation_imprimerContrat.Name = "btn_facturation_imprimerContrat"
        Me.btn_facturation_imprimerContrat.Size = New System.Drawing.Size(180, 24)
        Me.btn_facturation_imprimerContrat.TabIndex = 5
        Me.btn_facturation_imprimerContrat.Text = "      Imprimer le contrat"
        Me.btn_facturation_imprimerContrat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'facturation_totalHT
        '
        Me.facturation_totalHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalHT.Location = New System.Drawing.Point(858, 13)
        Me.facturation_totalHT.Name = "facturation_totalHT"
        Me.facturation_totalHT.Size = New System.Drawing.Size(43, 20)
        Me.facturation_totalHT.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(905, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(8, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "€"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_facturation_suivant
        '
        Me.btn_facturation_suivant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_facturation_suivant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_facturation_suivant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_facturation_suivant.ForeColor = System.Drawing.Color.White
        Me.btn_facturation_suivant.Image = CType(resources.GetObject("btn_facturation_suivant.Image"), System.Drawing.Image)
        Me.btn_facturation_suivant.Location = New System.Drawing.Point(788, 168)
        Me.btn_facturation_suivant.Name = "btn_facturation_suivant"
        Me.btn_facturation_suivant.Size = New System.Drawing.Size(128, 24)
        Me.btn_facturation_suivant.TabIndex = 4
        Me.btn_facturation_suivant.Text = "    Valider"
        Me.btn_facturation_suivant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.Location = New System.Drawing.Point(8, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "    Annuler"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_facturation_imprimerBL
        '
        Me.btn_facturation_imprimerBL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_facturation_imprimerBL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_facturation_imprimerBL.Enabled = False
        Me.btn_facturation_imprimerBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_facturation_imprimerBL.ForeColor = System.Drawing.Color.White
        Me.btn_facturation_imprimerBL.Image = CType(resources.GetObject("btn_facturation_imprimerBL.Image"), System.Drawing.Image)
        Me.btn_facturation_imprimerBL.Location = New System.Drawing.Point(350, 168)
        Me.btn_facturation_imprimerBL.Name = "btn_facturation_imprimerBL"
        Me.btn_facturation_imprimerBL.Size = New System.Drawing.Size(180, 24)
        Me.btn_facturation_imprimerBL.TabIndex = 6
        Me.btn_facturation_imprimerBL.Text = "      Imprimer le BL"
        Me.btn_facturation_imprimerBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label9.Location = New System.Drawing.Point(705, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(211, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "     TVA.........................."
        '
        'facturation_totalTVA
        '
        Me.facturation_totalTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTVA.Location = New System.Drawing.Point(858, 87)
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
        Me.Label12.Location = New System.Drawing.Point(905, 87)
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
        Me.Label13.Location = New System.Drawing.Point(705, 112)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "     Net à payer (TTC)...."
        '
        'facturation_totalTTC
        '
        Me.facturation_totalTTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTTC.Location = New System.Drawing.Point(858, 111)
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
        Me.Label14.Location = New System.Drawing.Point(905, 111)
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
        Me.Label15.Location = New System.Drawing.Point(769, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "     Taux (%)"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label16.Location = New System.Drawing.Point(769, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 16)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "     Total"
        '
        'tb_txTVA
        '
        Me.tb_txTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_txTVA.Location = New System.Drawing.Point(858, 63)
        Me.tb_txTVA.Name = "tb_txTVA"
        Me.tb_txTVA.Size = New System.Drawing.Size(43, 20)
        Me.tb_txTVA.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(905, 63)
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
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LibelleDataGridViewTextBoxColumn, Me.PrixUnitaireDataGridViewTextBoxColumn, Me.QteDataGridViewTextBoxColumn, Me.TvaDataGridViewTextBoxColumn, Me.PrixTotalDataGridViewTextBoxColumn, Me.columnDelete})
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
        Me.DataGridView1.Size = New System.Drawing.Size(903, 331)
        Me.DataGridView1.TabIndex = 30
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "libelle"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.LibelleDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Prestation"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PrixUnitaireDataGridViewTextBoxColumn
        '
        Me.PrixUnitaireDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PrixUnitaireDataGridViewTextBoxColumn.DataPropertyName = "prixUnitaire"
        Me.PrixUnitaireDataGridViewTextBoxColumn.HeaderText = "Prix U H.T."
        Me.PrixUnitaireDataGridViewTextBoxColumn.Name = "PrixUnitaireDataGridViewTextBoxColumn"
        Me.PrixUnitaireDataGridViewTextBoxColumn.Width = 114
        '
        'QteDataGridViewTextBoxColumn
        '
        Me.QteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.QteDataGridViewTextBoxColumn.DataPropertyName = "qte"
        Me.QteDataGridViewTextBoxColumn.HeaderText = "Quant"
        Me.QteDataGridViewTextBoxColumn.Name = "QteDataGridViewTextBoxColumn"
        Me.QteDataGridViewTextBoxColumn.Width = 72
        '
        'TvaDataGridViewTextBoxColumn
        '
        Me.TvaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TvaDataGridViewTextBoxColumn.DataPropertyName = "tva"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.TvaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TvaDataGridViewTextBoxColumn.HeaderText = "% TVA"
        Me.TvaDataGridViewTextBoxColumn.Name = "TvaDataGridViewTextBoxColumn"
        Me.TvaDataGridViewTextBoxColumn.ReadOnly = True
        Me.TvaDataGridViewTextBoxColumn.Width = 66
        '
        'PrixTotalDataGridViewTextBoxColumn
        '
        Me.PrixTotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PrixTotalDataGridViewTextBoxColumn.DataPropertyName = "prixTotal"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.PrixTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrixTotalDataGridViewTextBoxColumn.HeaderText = "Total TTC"
        Me.PrixTotalDataGridViewTextBoxColumn.Name = "PrixTotalDataGridViewTextBoxColumn"
        Me.PrixTotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.PrixTotalDataGridViewTextBoxColumn.Width = 143
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
        Me.m_bsLignes.DataSource = GetType(Crodip_agent.DiagnosticFactureItem)
        '
        'diagnostic_facturation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(933, 607)
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
        Me.Name = "diagnostic_facturation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Crodip .::. Facturation"
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelFooter.ResumeLayout(False)
        Me.panelFooter.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).EndInit()
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
    End Sub

    ' Chargement de la page
    Private Sub diagnostic_facturation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Debug.Assert(m_oDiag IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oExploit IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oAgent IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oPulverisateur IsNot Nothing, "Context must be set before")

        Statusbar.display(Globals.CONST_STATUTMSG_DIAG_TARIFS, False)
        Me.Cursor = Cursors.WaitCursor
        tb_txTVA.Text = My.Settings.TxTVADefaut
        ' Chargement des catégories de prestations
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
        '    ' Changement d'état du bouton
        '    btn_facturation_suivant.Text = "Poursuivre"
        '    btn_facturation_imprimerContrat.Enabled = True
        '    btn_facturation_imprimerBL.Enabled = True
        '    isValider = True
        '    listTarif_categories.Enabled = False
        '    listTarif_prestations.Enabled = False
        'End If

        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region " Boutons "

    ' Ajout d'une ligne a la facture
    Private Sub img_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles img_Add.Click
        If Not listTarif_categories.SelectedItem Is Nothing And Not listTarif_prestations.SelectedItem Is Nothing Then
            If listTarif_categories.SelectedItem.libelle.ToString <> "" And listTarif_prestations.SelectedItem.libelle.ToString <> "" Then


                ' On récupère la presta sélectionnée
                Dim curPrestation As New PrestationTarif
                Try
                    curPrestation = PrestationTarifManager.getById(CType(listTarif_prestations.SelectedItem.id, Integer), agentCourant.idStructure)
                Catch ex As Exception
                    CSDebug.dispError("Récupération tarif : " & ex.Message.ToString)
                End Try


                Dim oLig As New DiagnosticFactureItem()
                oLig.libelle = listTarif_categories.SelectedItem.libelle.ToString & " : " & listTarif_prestations.SelectedItem.libelle.ToString
                oLig.qte = 1
                oLig.prixUnitaire = curPrestation.tarifHT
                oLig.tva = curPrestation.tva

                m_bsLignes.Add(oLig)

                ' On passe le total en readonly
                facturation_totalHT.ReadOnly = True
                tb_txTVA.ReadOnly = True
                tb_txTVA.Text = ""
                facturation_totalTVA.ReadOnly = True
                facturation_totalTTC.ReadOnly = True
                calcTotal()

            End If
        End If
    End Sub

    ' Validation des tarifs
    Private Sub suivant(sender As System.Object)
        sender.Enabled = False

        If isValider = True Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.Cursor = Cursors.WaitCursor
            If facturation_totalTTC.Text <> "" Then
                ' Enregistrement des tarifs
                'diagnosticCourantTarif = CType(facturation_totalTTC.Text, Double)
                m_oDiag.controleTarif = CType(facturation_totalTTC.Text, Double)
                m_oDiag.TotalHT = CDec(facturation_totalHT.Text)
                m_oDiag.TotalTVA = CDec(facturation_totalTVA.Text)
                m_oDiag.TotalTTC = CDec(facturation_totalTTC.Text)


                listTarif_categories.Enabled = False
                listTarif_prestations.Enabled = False
                DataGridView1.Enabled = False
                img_Add.Enabled = False
                createContrat()
                createBl_CR()
                ' Changement d'état du bouton
                btn_facturation_suivant.Text = "Poursuivre"
                btn_facturation_imprimerContrat.Enabled = True
                btn_facturation_imprimerBL.Enabled = True
                isValider = True

                'Facture
                Try
                    btn_ImprimerFacture.Visible = False
                    btn_imprimerFactureCoProp.Visible = False
                    Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(Application.StartupPath & "\config\facturation.xml")
                    If CType(FACTURATION_XML_CONFIG.getElementValue("/root/isActive"), Boolean) Then
                        If Trim(m_oDiag.pulverisateurNbreExploitants) <> "" Then
                            If m_oDiag.pulverisateurNbreExploitants > 1 Then
                                btn_imprimerFactureCoProp.Visible = True
                                btn_ImprimerFacture.Visible = False
                                btn_imprimerFactureCoProp.Location = btn_ImprimerFacture.Location
                            Else
                                btn_ImprimerFacture.Visible = True
                                btn_imprimerFactureCoProp.Visible = False
                            End If
                        Else
                            btn_ImprimerFacture.Visible = True
                            btn_imprimerFactureCoProp.Visible = False
                        End If
                        btn_ImprimerFacture.Enabled = btn_ImprimerFacture.Visible
                        btn_imprimerFactureCoProp.Enabled = btn_imprimerFactureCoProp.Visible
                        tbCommentaire.Visible = btn_ImprimerFacture.Visible
                        tbCommentaire.Enabled = btn_ImprimerFacture.Visible
                        lblCommentaire.Visible = btn_ImprimerFacture.Visible
                        lblCommentaire.Enabled = btn_ImprimerFacture.Visible

                    Else
                        btn_ImprimerFacture.Visible = False
                        lblCommentaire.Visible = False
                        tbCommentaire.Visible = False
                    End If
                Catch ex As Exception

                End Try
                'Facture
                Me.Cursor = Me.DefaultCursor

                MsgBox("Vous devez maintenant imprimer le contrat commercial pour commencer le contrôle.", MsgBoxStyle.Information)
            Else
                MsgBox("Vous devez renseigner un tarif pour pouvoir poursuivre.", MsgBoxStyle.Exclamation)
            End If

            sender.Enabled = True
        End If

    End Sub
    ' Retour au contexte
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        'Dim formContexte As New diagnostic_contexte(True)
        'formContexte.MdiParent = Me.MdiParent
        'Statusbar.clear()
        'formContexte.Show()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region " Calculs "

    ' Calcul du total
    Public Sub calcTotal()

        Dim prixTotalHT As Double = 0
        Dim prixTotalTTC As Double = 0
        For Each olig As DiagnosticFactureItem In m_bsLignes
            prixTotalHT = prixTotalHT + (olig.prixUnitaire * olig.qte)
            prixTotalTTC = prixTotalTTC + olig.prixTotal
        Next

        facturation_totalHT.Text = Math.Round(prixTotalHT, 2)
        facturation_totalTTC.Text = Math.Round(prixTotalTTC, 2)
        facturation_totalTVA.Text = Math.Round(prixTotalTTC - prixTotalHT, 2)

    End Sub

#End Region

#Region " Impressions "

    ' Impression facture
    Private Sub createFacture_CR()

        Try
            'Saisie du Numero de facture
            Dim oFrm As New frmSaisieNumFact(m_oAgent)
            If oFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim factureObj As DiagnosticFacture
                factureObj = Me.saveFacture(oFrm.NUMFACT)

                Dim oEtat As New EtatFacture(m_oDiag, factureObj.factureReference, tbCommentaire.Text)

                ' On rempli la liste des prestations
                For Each oLig As DiagnosticFactureItem In m_bsLignes
                    oEtat.AddPresta(oLig.libelle, oLig.prixUnitaire, oLig.qte, oLig.tva, oLig.prixTotal, oLig.prixTotal * (1 + oLig.tva))

                Next
                oEtat.GenereEtat()
                m_pathFacture = oEtat.getFileName()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::createFacture_CR : " & ex.Message)
        End Try



    End Sub

    Private Function saveFacture(pReference As String) As DiagnosticFacture
        Dim facture As DiagnosticFacture = New DiagnosticFacture
        Try
            '####
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(Application.StartupPath & "\config\facturation.xml")
            Dim organismePCourant As Structuree = StructureManager.getStructureById(m_oDiag.organismePresId)
            '####
            Dim champTotalTtc As Double = 0
            If prestaIncrement > 0 Then
                For i As Integer = 1 To prestaIncrement
                    Try
                        ' Calcul total facture
                        Dim tmpPrixInput As TextBox = CSForm.getControlByName("controlePrixTTC_" & i, Me)
                        champTotalTtc += CType(tmpPrixInput.Text, Double)
                    Catch ex As Exception
                        Console.Write("Erreur de calcul du prix total" & vbNewLine)
                    End Try
                Next
            End If

            '######################################################################################
            facture.id = DiagnosticFactureManager.getNewId()
            facture.factureReference = pReference
            facture.factureDate = Format(Date.Now, "dd/MM/yyyy")
            facture.factureTotal = champTotalTtc
            facture.emetteurOrganisme = organismePCourant.nom
            facture.emetteurOrganismeAdresse = organismePCourant.adresse
            facture.emetteurOrganismeCpVille = organismePCourant.codePostal & " " & organismePCourant.commune
            facture.emetteurOrganismeTelFax = organismePCourant.telephoneFixe & " / " & organismePCourant.telephoneFax
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

    ' Impression contrat commercial
    Dim pathContrat As String
    'Private Function createContratPDF() As Boolean
    '    Dim pdfReader As PdfReader
    '    Dim pdfStamper As PdfStamper
    '    Dim pdfFormFields As AcroFields
    '    Dim bReturn As Boolean
    '    Try

    '        ' Init
    '        Dim pdfTemplate As String = Globals.CONST_PATH_DOCS & Globals.CONST_DOC_CONTCOM & ".pdf"
    '        'pathContrat = Globals.CONST_PATH_EXP & Globals.CONST_DOC_CONTCOM & "_" & CSDate.getDateId(Date.Now) & ".pdf"
    '        pathContrat = Globals.CONST_PATH_EXP & CSDiagPdf.makeFilename(pulverisateurCourant.id, CSDiagPdf.TYPE_CONTRAT_COMMERCIAL) & ".pdf"
    '        Dim newFile As String = pathContrat
    '        ' Ouverture des pdf
    '        pdfReader = New PdfReader(pdfTemplate)
    '        pdfStamper = New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create))
    '        pdfFormFields = pdfStamper.AcroFields

    '        ' Et on rempli les champs
    '        Dim dDate As Date
    '        If String.IsNullOrEmpty(diagnosticCourant.controleDateFin) Then
    '            dDate = Now
    '        Else
    '            dDate = CDate(diagnosticCourant.controleDateFin)
    '        End If

    '        pdfFormFields.SetField("controleDate", dDate.ToString("d"))

    '        pdfFormFields.SetField("controleInspecteur_nomPrenom", diagnosticCourant.inspecteurNom & " " & diagnosticCourant.inspecteurPrenom)
    '        pdfFormFields.SetField("controleInspecteur_id", agentCourant.numeroNational)
    '        pdfFormFields.SetField("controleOrganismeP_id", diagnosticCourant.organismePresNumero)

    '        pdfFormFields.SetField("controleProprietaire_raisonSociale", clientCourant.raisonSociale)
    '        pdfFormFields.SetField("controleProprietaire_nomPrenom", clientCourant.nomExploitant & " " & clientCourant.prenomExploitant)
    '        pdfFormFields.SetField("controleProprietaire_adresse", clientCourant.adresse)
    '        pdfFormFields.SetField("controleProprietaire_codePostal", clientCourant.codePostal)
    '        pdfFormFields.SetField("controleProprietaire_ville", clientCourant.commune)
    '        pdfFormFields.SetField("controleProprietaire_nomPrenomRepresentant", diagnosticCourant.proprietaireRepresentant)

    '        pdfFormFields.SetField("controlePulve_marque", pulverisateurCourant.marque)
    '        pdfFormFields.SetField("controlePulve_id", pulverisateurCourant.numeroNational)

    '        pdfFormFields.SetField("controleFacturation_prixHT", facturation_totalHT.Text)

    '        pdfFormFields.SetField("date", dDate.ToString("d"))


    '        ' On affiche le PDF rempli
    '        'CSFile.open(newFile)
    '        bReturn = True
    '    Catch ex As Exception
    '        CSDebug.dispError("Génération contrat commercial : " & ex.Message)
    '        bReturn = False
    '    End Try
    '    ' On referme le PDF
    '    pdfStamper.FormFlattening = True
    '    pdfStamper.Close()
    '    pdfReader.Close()
    '    Return bReturn
    'End Function
    Private Function createContrat() As Boolean
        Dim bReturn As Boolean
        Try

            Dim oEtat As New EtatContratCommercial(m_oDiag)
            If oEtat.GenereEtat() Then
                pathContrat = Globals.CONST_PATH_EXP & oEtat.getFileName()
                m_oDiag.CCFileName = oEtat.getFileName()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostic_facturation.createContrat ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Sub btn_facturation_imprimerContrat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturation_imprimerContrat.Click
        Try

            ' On affiche le PDF rempli
            CSFile.open(pathContrat)

        Catch ex As Exception
            CSDebug.dispError("Génération contrat commercial : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Création du Bon de Livraison avec CrystalReport
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createBl_CR()


        Try
            'Dim factureObj As DiagnosticFacture
            'factureObj = Me.saveFacture()

            Dim oEtat As New EtatBL(m_oDiag)

            ' On rempli la liste des prestations
            For Each oLig As DiagnosticFactureItem In m_bsLignes
                oEtat.AddPresta(oLig.libelle, oLig.prixUnitaire, oLig.qte, oLig.tva, oLig.prixTotal, oLig.prixTotal * (1 + oLig.tva))
            Next

            oEtat.GenereEtat()
            m_pathBl = oEtat.getFileName()
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::createBL_CR : " & ex.Message)
        End Try


    End Sub

    'Private Function getDsForBL() As ds_EtatBL
    '    Dim oReturn As ds_EtatBL
    '    Try
    '        oReturn = diagnosticCourant.generateDataSetForBL()

    '        ' On rempli la liste des prestations
    '        Dim PrestaLibelle As String = ""
    '        Dim PrestaHT As String = ""
    '        Dim PrestaTVA As String = ""
    '        Dim PrestaTTC As String = ""
    '        If prestaIncrement > 0 Then
    '            For i As Integer = 1 To prestaIncrement

    '                ' Libellé
    '                Dim tmpPrestaLib As Label = CSForm.getControlByName("controlePrestaLib_" & i, Me)
    '                PrestaLibelle = tmpPrestaLib.Text

    '                ' Prix HT
    '                Dim tmpPrixHTInput As TextBox = CSForm.getControlByName("controlePrixHT_" & i, Me)
    '                PrestaHT = tmpPrixHTInput.Text

    '                ' TVA
    '                Dim tmpPrixTVAInput As TextBox = CSForm.getControlByName("controlePrixTVA_" & i, Me)
    '                PrestaTVA = tmpPrixTVAInput.Text

    '                ' Prix TTC
    '                Dim tmpPrixInput As TextBox = CSForm.getControlByName("controlePrixTTC_" & i, Me)
    '                PrestaTTC = tmpPrixInput.Text

    '                oReturn.Prestation.AddPrestationRow(PrestaLibelle, PrestaHT, PrestaTVA, PrestaTTC, 1, PrestaHT)


    '            Next
    '        End If

    '    Catch ex As Exception
    '        CSDebug.dispError("diagnostic_finalisation ERR:" & ex.Message)
    '        oReturn = New ds_EtatBL
    '    End Try
    '    Return oReturn
    'End Function

    'Private Function getDSForFact() As ds_EtatBL
    '    Dim factureObj As DiagnosticFacture
    '    Dim ods As ds_EtatBL
    '    Try
    '        factureObj = Me.saveFacture()

    '        Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(Application.StartupPath & "\config\facturation.xml")
    '        Dim oStruct As Structuree
    '        oStruct = StructureManager.getStructureById(agentCourant.idStructure)


    '        'Génération du DataSet par le DiagNostic (Idem BL)
    '        ods = getDsForBL()

    '        'Remplissage du DS avec les Champs spécifique à la facture
    '        ods.Facture(0).refacture = factureObj.factureReference
    '        ' On ajoute le logo
    '        'Dim logoFilename As String = FACTURATION_XML_CONFIG.getElementValue("/root/logo_tn")
    '        Dim logoFilename As String = FACTURATION_XML_CONFIG.getElementValue("/root/logo")
    '        If Not File.Exists(logoFilename) Then
    '            logoFilename = Globals.CONST_PATH_IMG & CR_LOGO_DEFAULT_TN_NAME
    '        End If
    '        ods.Facture(0).LogoFileName = logoFilename
    '        Dim newImage As System.Drawing.Image = System.Drawing.Image.FromFile(logoFilename)
    '        Dim ms As New MemoryStream
    '        newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

    '        ods.Facture(0).LogoFileName = logoFilename
    '        ods.Organisme(0).TelFax = oStruct.telephoneFixe & " / " & oStruct.telephoneFax
    '        ods.Organisme(0).SIREN = FACTURATION_XML_CONFIG.getElementValue("/root/siren")
    '        ods.Organisme(0).TVA = FACTURATION_XML_CONFIG.getElementValue("/root/tva")
    '        ods.Organisme(0).RCS = FACTURATION_XML_CONFIG.getElementValue("/root/rcs")
    '        ods.Facture(0).Logo = ms.ToArray()

    '        ' CLIENT

    '        ' FOOTER
    '        ods.Facture(0).Footer = FACTURATION_XML_CONFIG.getElementValue("/root/footer")

    '    Catch ex As Exception
    '        CSDebug.dispError("Diagnostic_finalisation ERR : " & ex.Message)
    '        ods = New ds_EtatBL()
    '    End Try


    '    Return ods

    'End Function
    Private Sub btn_facturation_imprimerBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturation_imprimerBL.Click

        ' On génère le PDF rempli
        Try
            If String.IsNullOrEmpty(m_pathBl) Then
                createBl_CR()
            End If
            CSFile.open(m_pathBl)
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::btn_facturation_imprimerBL_Click( Affichage BL ) : " & ex.Message)
        End Try

    End Sub

#End Region

#Region " Events "

    ' Mise a jour des listes déroulantes
    Private Sub listTarif_categories_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listTarif_categories.SelectedIndexChanged
        ' Chargement des prestations de la catégorie
        If listTarif_categories.SelectedItem.Id <> "" Then
            listTarif_prestations.Items.Clear()
            Dim arrPrestations() As PrestationTarif = PrestationTarifManager.getArrayByCategorieId(listTarif_categories.SelectedItem.Id)
            For Each tmpPrestation As PrestationTarif In arrPrestations
                Try
                    Dim objComboItem As New objComboItem(tmpPrestation.id.ToString, tmpPrestation.description)
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


    Private Sub btn_facturation_suivant_MouseClick(sender As Object, e As MouseEventArgs) Handles btn_facturation_suivant.MouseClick
        Me.ValidateChildren()
        If e.Button = Windows.Forms.MouseButtons.Right Then
            facturation_totalHT.Text = "0"
            isValider = True
        End If
        suivant(sender)
    End Sub

    Private Sub btn_ImprimerFacture_Click(sender As Object, e As EventArgs) Handles btn_ImprimerFacture.Click
        ' On affiche le PDF rempli
        Try
            ' Génération de la facture

            createFacture_CR()
            CSFile.open(m_pathFacture)
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::btn_facturation_imprimerFact_Click( Affichage Facture ) : " & ex.Message)
        End Try


    End Sub

    Private Sub m_bsLignes_CurrentItemChanged(sender As Object, e As EventArgs) Handles m_bsLignes.CurrentItemChanged
        calcTotal()
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = columnDelete.Index Then
            'Suppresssion de la ligne courante
            m_bsLignes.RemoveCurrent()
        End If
    End Sub

    Private Sub btn_imprimerFactureCoProp_Click(sender As Object, e As EventArgs) Handles btn_imprimerFactureCoProp.Click
        Dim ofrm As New frmdiagnostic_facturationCoProp()
        Dim olst As New List(Of DiagnosticFactureItem)
        olst.AddRange(m_bsLignes.List)
        ofrm.setContexte(m_oDiag, m_oExploit, m_oAgent, olst)
        ofrm.ShowDialog()
    End Sub

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
            prixTxTVA = IIf(Not String.IsNullOrEmpty(tb_txTVA.Text), CDec(tb_txTVA.Text), My.Settings.TxTVADefaut)
            'Il n'y a pas de TTC alors qu'il y a un HT
            '=> Calcul TVA et TTC
            prixTotalTTC = prixTotalHT * (1 + (prixTxTVA / 100))
            facturation_totalHT.Text = Math.Round(prixTotalHT, 2)
            facturation_totalTTC.Text = Math.Round(prixTotalTTC, 2)
            facturation_totalTVA.Text = Math.Round(prixTotalTTC - prixTotalHT, 2)

        End If


    End Sub


 End Class
