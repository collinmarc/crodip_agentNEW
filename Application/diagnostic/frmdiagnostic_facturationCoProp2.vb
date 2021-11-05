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
    Friend WithEvents m_bsLignes As System.Windows.Forms.BindingSource
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents m_bsExploitant As System.Windows.Forms.BindingSource
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbCommentaire As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TextBox11 As TextBox
    Private WithEvents btn_finalisationDiag_valider As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label27 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents dtpDateEcheance As DateTimePicker
    Friend WithEvents tbModeReglement As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDateFact As DateTimePicker
    Friend WithEvents Label24 As Label
    Friend WithEvents catégorie As DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrixUnitaireDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrixTotalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents columnDelete As DataGridViewImageColumn
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents pblPourcentage As Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView


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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelFooter = New System.Windows.Forms.Panel()
        Me.btn_finalisationDiag_valider = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.m_bsLignes = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.m_bsExploitant = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtpDateFact = New System.Windows.Forms.DateTimePicker()
        Me.tbModeReglement = New System.Windows.Forms.TextBox()
        Me.dtpDateEcheance = New System.Windows.Forms.DateTimePicker()
        Me.catégorie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrixUnitaireDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrixTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.pblPourcentage = New System.Windows.Forms.Panel()
        Me.panelFooter.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsExploitant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pblPourcentage.SuspendLayout()
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
        Me.Label1.Location = New System.Drawing.Point(685, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "     Total HT"
        '
        'panelFooter
        '
        Me.panelFooter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelFooter.Controls.Add(Me.TextBox15)
        Me.panelFooter.Controls.Add(Me.Label25)
        Me.panelFooter.Controls.Add(Me.CheckBox1)
        Me.panelFooter.Controls.Add(Me.dtpDateEcheance)
        Me.panelFooter.Controls.Add(Me.tbModeReglement)
        Me.panelFooter.Controls.Add(Me.Label9)
        Me.panelFooter.Controls.Add(Me.Label2)
        Me.panelFooter.Controls.Add(Me.btn_finalisationDiag_valider)
        Me.panelFooter.Controls.Add(Me.Button3)
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
        Me.panelFooter.Location = New System.Drawing.Point(12, 484)
        Me.panelFooter.Name = "panelFooter"
        Me.panelFooter.Size = New System.Drawing.Size(921, 168)
        Me.panelFooter.TabIndex = 2
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
        Me.btn_finalisationDiag_valider.TabIndex = 63
        Me.btn_finalisationDiag_valider.Text = "    Valider"
        Me.btn_finalisationDiag_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(259, 132)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(134, 31)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "Nouvelle facture"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'tbCommentaire
        '
        Me.tbCommentaire.Location = New System.Drawing.Point(118, 16)
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
        Me.Label18.Location = New System.Drawing.Point(8, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 13)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "Commentaire :"
        '
        'facturation_totalHT
        '
        Me.facturation_totalHT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalHT.Location = New System.Drawing.Point(861, 13)
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
        Me.btn_imprimerFactCoProp.TabIndex = 0
        Me.btn_imprimerFactCoProp.Text = "    Imprimer"
        Me.btn_imprimerFactCoProp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'facturation_totalTVA
        '
        Me.facturation_totalTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTVA.Location = New System.Drawing.Point(861, 63)
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
        Me.Label12.Location = New System.Drawing.Point(905, 63)
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
        Me.Label13.Location = New System.Drawing.Point(690, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "     Net à payer (TTC)...."
        '
        'facturation_totalTTC
        '
        Me.facturation_totalTTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facturation_totalTTC.Location = New System.Drawing.Point(861, 89)
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
        Me.Label14.Location = New System.Drawing.Point(905, 93)
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
        Me.Label15.Location = New System.Drawing.Point(708, 40)
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
        Me.Label16.Location = New System.Drawing.Point(711, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(146, 16)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "     Total TVA"
        '
        'tb_txTVA
        '
        Me.tb_txTVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_txTVA.Location = New System.Drawing.Point(861, 39)
        Me.tb_txTVA.Name = "tb_txTVA"
        Me.tb_txTVA.Size = New System.Drawing.Size(43, 20)
        Me.tb_txTVA.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(905, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(8, 16)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "%"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.catégorie, Me.LibelleDataGridViewTextBoxColumn, Me.PrixUnitaireDataGridViewTextBoxColumn, Me.QteDataGridViewTextBoxColumn, Me.PrixTotalDataGridViewTextBoxColumn, Me.columnDelete})
        Me.DataGridView1.DataSource = Me.m_bsLignes
        Me.DataGridView1.Location = New System.Drawing.Point(12, 322)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Size = New System.Drawing.Size(904, 127)
        Me.DataGridView1.TabIndex = 6
        '
        'm_bsLignes
        '
        Me.m_bsLignes.DataSource = GetType(Crodip_agent.DiagnosticFactureItem)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(318, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Nom  :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(317, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Adresse :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(318, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Code Postal  :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(505, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Commune :"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "nomExploitant", True))
        Me.TextBox1.Location = New System.Drawing.Point(428, 64)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(488, 20)
        Me.TextBox1.TabIndex = 1
        '
        'm_bsExploitant
        '
        Me.m_bsExploitant.DataSource = GetType(Crodip_agent.Exploitation)
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "adresse", True))
        Me.TextBox2.Location = New System.Drawing.Point(427, 116)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(488, 20)
        Me.TextBox2.TabIndex = 3
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "codePostal", True))
        Me.TextBox3.Location = New System.Drawing.Point(428, 142)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(61, 20)
        Me.TextBox3.TabIndex = 4
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "commune", True))
        Me.TextBox4.Location = New System.Drawing.Point(580, 142)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(336, 20)
        Me.TextBox4.TabIndex = 5
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "prenomExploitant", True))
        Me.TextBox5.Location = New System.Drawing.Point(428, 90)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(488, 20)
        Me.TextBox5.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(318, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Prénom :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(317, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Raison Sociale  :"
        '
        'TextBox6
        '
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "raisonSociale", True))
        Me.TextBox6.Location = New System.Drawing.Point(427, 38)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(488, 20)
        Me.TextBox6.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.DataGridView2.Location = New System.Drawing.Point(15, 38)
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
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Aqua
        Me.Button1.Location = New System.Drawing.Point(224, 87)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 33)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "Sélectionner ->"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Aqua
        Me.Button4.Location = New System.Drawing.Point(224, 132)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 33)
        Me.Button4.TabIndex = 49
        Me.Button4.Text = "Nouveau"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(318, 171)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 13)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "Tel Fixe  :"
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "codePostal", True))
        Me.TextBox9.Location = New System.Drawing.Point(428, 168)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(61, 20)
        Me.TextBox9.TabIndex = 51
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(495, 171)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 13)
        Me.Label22.TabIndex = 52
        Me.Label22.Text = "Tel portable  :"
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "codePostal", True))
        Me.TextBox10.Location = New System.Drawing.Point(579, 168)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(61, 20)
        Me.TextBox10.TabIndex = 53
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(646, 171)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 13)
        Me.Label23.TabIndex = 54
        Me.Label23.Text = "Email :"
        '
        'TextBox11
        '
        Me.TextBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsExploitant, "codePostal", True))
        Me.TextBox11.Location = New System.Drawing.Point(697, 168)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(219, 20)
        Me.TextBox11.TabIndex = 55
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel1.Controls.Add(Me.dtpDateFact)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.TextBox12)
        Me.Panel1.Controls.Add(Me.TextBox13)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.TextBox14)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Location = New System.Drawing.Point(12, 194)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 120)
        Me.Panel1.TabIndex = 64
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
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(209, 3)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(108, 20)
        Me.TextBox12.TabIndex = 72
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
        'TextBox14
        '
        Me.TextBox14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.TextBox14.Location = New System.Drawing.Point(209, 55)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(108, 20)
        Me.TextBox14.TabIndex = 69
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(205, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Mode de réglement :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(4, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Date échéance :"
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
        'dtpDateFact
        '
        Me.dtpDateFact.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFact.Location = New System.Drawing.Point(209, 94)
        Me.dtpDateFact.Name = "dtpDateFact"
        Me.dtpDateFact.Size = New System.Drawing.Size(108, 20)
        Me.dtpDateFact.TabIndex = 75
        '
        'tbModeReglement
        '
        Me.tbModeReglement.Location = New System.Drawing.Point(334, 65)
        Me.tbModeReglement.Name = "tbModeReglement"
        Me.tbModeReglement.Size = New System.Drawing.Size(345, 20)
        Me.tbModeReglement.TabIndex = 66
        '
        'dtpDateEcheance
        '
        Me.dtpDateEcheance.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateEcheance.Location = New System.Drawing.Point(118, 65)
        Me.dtpDateEcheance.Name = "dtpDateEcheance"
        Me.dtpDateEcheance.Size = New System.Drawing.Size(86, 20)
        Me.dtpDateEcheance.TabIndex = 67
        '
        'catégorie
        '
        Me.catégorie.DataPropertyName = "id"
        Me.catégorie.HeaderText = "Catégorie"
        Me.catégorie.Name = "catégorie"
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "libelle"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.LibelleDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
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
        'PrixTotalDataGridViewTextBoxColumn
        '
        Me.PrixTotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PrixTotalDataGridViewTextBoxColumn.DataPropertyName = "prixTotal"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.PrixTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.PrixTotalDataGridViewTextBoxColumn.HeaderText = "Total HT"
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
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(276, 91)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(403, 20)
        Me.TextBox15.TabIndex = 73
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(119, 94)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(151, 13)
        Me.Label25.TabIndex = 72
        Me.Label25.Text = "Reférence de réglement :"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(11, 94)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(66, 17)
        Me.CheckBox1.TabIndex = 71
        Me.CheckBox1.Text = "Réglée"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(9, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(174, 13)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "Pourcentage de facturation : "
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(189, 14)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(73, 20)
        Me.TextBox7.TabIndex = 50
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(270, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 26)
        Me.Button2.TabIndex = 51
        Me.Button2.Text = "Calculer"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(9, 42)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(111, 13)
        Me.Label20.TabIndex = 52
        Me.Label20.Text = "Reste à facturer : "
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(191, 43)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(70, 20)
        Me.TextBox8.TabIndex = 53
        '
        'pblPourcentage
        '
        Me.pblPourcentage.Controls.Add(Me.TextBox8)
        Me.pblPourcentage.Controls.Add(Me.Label20)
        Me.pblPourcentage.Controls.Add(Me.Button2)
        Me.pblPourcentage.Controls.Add(Me.TextBox7)
        Me.pblPourcentage.Controls.Add(Me.Label19)
        Me.pblPourcentage.Location = New System.Drawing.Point(554, 226)
        Me.pblPourcentage.Name = "pblPourcentage"
        Me.pblPourcentage.Size = New System.Drawing.Size(360, 84)
        Me.pblPourcentage.TabIndex = 65
        '
        'frmdiagnostic_facturationCoProp2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(933, 664)
        Me.ControlBox = False
        Me.Controls.Add(Me.pblPourcentage)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox11)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.panelFooter)
        Me.Controls.Add(Me.Label3)
        Me.Icon = Global.Crodip_agent.Resources.logoCRODIP
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmdiagnostic_facturationCoProp2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Crodip .::. Facturation indépendante"
        Me.panelFooter.ResumeLayout(False)
        Me.panelFooter.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsLignes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsExploitant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pblPourcentage.ResumeLayout(False)
        Me.pblPourcentage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Public Sub setContexte(pDiag As Diagnostic, pExploit As Exploitation, pAgent As Agent, plstLignes As List(Of DiagnosticFactureItem))
        Debug.Assert(pDiag IsNot Nothing)
        Debug.Assert(pExploit IsNot Nothing)
        Debug.Assert(pAgent IsNot Nothing)

        m_oDiag = pDiag
        m_oExploit = New Exploitation()
        m_oExploit.raisonSociale = pExploit.raisonSociale
        m_oExploit.nomExploitant = pExploit.nomExploitant
        m_oExploit.prenomExploitant = pExploit.prenomExploitant
        m_oExploit.adresse = pExploit.adresse
        m_oExploit.codePostal = pExploit.codePostal
        m_oExploit.commune = pExploit.commune
        m_oAgent = pAgent
        m_oPulverisateur = PulverisateurManager.getPulverisateurById(m_oDiag.pulverisateurId)
        m_bsLignes.Clear()
        For Each oLg As DiagnosticFactureItem In plstLignes
            m_bsLignes.Add(oLg)
        Next
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False

        m_bsExploitant.Clear()
        m_bsExploitant.Add(m_oExploit)
    End Sub

    ' Chargement de la page
    Private Sub diagnostic_finalisation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Debug.Assert(m_oDiag IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oExploit IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oAgent IsNot Nothing, "Context must be set before")
        Debug.Assert(m_oPulverisateur IsNot Nothing, "Context must be set before")


        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region " Boutons "


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
            Dim oFrm As New frmSaisieNumFact(m_oAgent)
            If oFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim factureObj As DiagnosticFacture
                factureObj = Me.saveFacture(oFrm.NUMFACT)


                Dim oEtat As New EtatFacture(m_oDiag, factureObj.factureReference, tbCommentaire.Text, m_oExploit)

                ' On rempli la liste des prestations
                For Each oLig As DiagnosticFactureItem In m_bsLignes
                    oEtat.AddPresta(oLig.libelle, oLig.prixUnitaire, oLig.qte, oLig.tva, oLig.prixTotal, oLig.prixTotal * (1 + oLig.tva))

                Next
                oEtat.genereEtat()
                m_pathFacture = oEtat.getFileNameFullPath()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::createFacture_CR : " & ex.Message)
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




    Private Sub m_bsLignes_CurrentItemChanged(sender As Object, e As EventArgs) Handles m_bsLignes.CurrentItemChanged
        calcTotal()
    End Sub



    Private Sub btn_imprimerFactCoProp_Click(sender As Object, e As EventArgs) Handles btn_imprimerFactCoProp.Click
        Me.ValidateChildren()
        'Les totaux ne sont pas binder !!!!!
        Dim totalHT As Decimal = m_oDiag.TotalHT
        Dim totalTVA As Decimal = m_oDiag.TotalTVA
        Dim totalTTC As Decimal = m_oDiag.TotalTTC
        If IsNumeric(Me.facturation_totalHT.Text) Then
            m_oDiag.TotalHT = Convert.ToDecimal(Me.facturation_totalHT.Text)
            m_oDiag.TotalTVA = Convert.ToDecimal(Me.facturation_totalTVA.Text)
            m_oDiag.TotalTTC = Convert.ToDecimal(Me.facturation_totalTTC.Text)
        End If
        createFacture_CR()

        m_oDiag.TotalHT = totalHT
        m_oDiag.TotalTVA = totalTVA
        m_oDiag.TotalTTC = totalTTC

        CSFile.open(m_pathFacture)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs)

    End Sub
End Class
