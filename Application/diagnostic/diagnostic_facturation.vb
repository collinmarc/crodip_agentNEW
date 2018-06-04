Imports System
Imports System.Collections
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
    Friend WithEvents Panel72 As System.Windows.Forms.Panel
    Friend WithEvents Panel74 As System.Windows.Forms.Panel
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Panel75 As System.Windows.Forms.Panel
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents panelTarifs_libelle As System.Windows.Forms.Panel
    Friend WithEvents panelTarifs_prix As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents panelTarifs_tva As System.Windows.Forms.Panel
    Friend WithEvents panelTarifs_prixTTC As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_facturation))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_diagnostic_61 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.listTarif_prestations = New System.Windows.Forms.ComboBox()
        Me.img_Add = New System.Windows.Forms.PictureBox()
        Me.panelFooter = New System.Windows.Forms.Panel()
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
        Me.Panel72 = New System.Windows.Forms.Panel()
        Me.Panel74 = New System.Windows.Forms.Panel()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Panel75 = New System.Windows.Forms.Panel()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.panelTarifs_libelle = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.panelTarifs_prix = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.panelTarifs_tva = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.panelTarifs_prixTTC = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelFooter.SuspendLayout()
        Me.Panel72.SuspendLayout()
        Me.Panel74.SuspendLayout()
        Me.Panel75.SuspendLayout()
        Me.panelTarifs_libelle.SuspendLayout()
        Me.panelTarifs_prix.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panelTarifs_tva.SuspendLayout()
        Me.panelTarifs_prixTTC.SuspendLayout()
        Me.Panel4.SuspendLayout()
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
        'btn_ImprimerFacture
        '
        Me.btn_ImprimerFacture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ImprimerFacture.Enabled = False
        Me.btn_ImprimerFacture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ImprimerFacture.ForeColor = System.Drawing.Color.White
        Me.btn_ImprimerFacture.Image = CType(resources.GetObject("btn_ImprimerFacture.Image"), System.Drawing.Image)
        Me.btn_ImprimerFacture.Location = New System.Drawing.Point(151, 168)
        Me.btn_ImprimerFacture.Name = "btn_ImprimerFacture"
        Me.btn_ImprimerFacture.Size = New System.Drawing.Size(180, 24)
        Me.btn_ImprimerFacture.TabIndex = 33
        Me.btn_ImprimerFacture.Text = "      Imprimer la facture"
        Me.btn_ImprimerFacture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_ImprimerFacture.Visible = False
        '
        'btn_facturation_imprimerContrat
        '
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
        Me.btn_facturation_suivant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        'Panel72
        '
        Me.Panel72.AutoScroll = True
        Me.Panel72.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel72.Controls.Add(Me.Panel74)
        Me.Panel72.Controls.Add(Me.Panel75)
        Me.Panel72.Controls.Add(Me.panelTarifs_libelle)
        Me.Panel72.Controls.Add(Me.panelTarifs_prix)
        Me.Panel72.Controls.Add(Me.Panel1)
        Me.Panel72.Controls.Add(Me.panelTarifs_tva)
        Me.Panel72.Controls.Add(Me.panelTarifs_prixTTC)
        Me.Panel72.Controls.Add(Me.Panel4)
        Me.Panel72.Location = New System.Drawing.Point(16, 64)
        Me.Panel72.Name = "Panel72"
        Me.Panel72.Size = New System.Drawing.Size(928, 600)
        Me.Panel72.TabIndex = 32
        '
        'Panel74
        '
        Me.Panel74.BackColor = System.Drawing.SystemColors.Control
        Me.Panel74.Controls.Add(Me.Label103)
        Me.Panel74.Location = New System.Drawing.Point(662, 0)
        Me.Panel74.Name = "Panel74"
        Me.Panel74.Size = New System.Drawing.Size(88, 40)
        Me.Panel74.TabIndex = 20
        '
        'Label103
        '
        Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label103.Location = New System.Drawing.Point(8, 16)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(72, 16)
        Me.Label103.TabIndex = 8
        Me.Label103.Text = "Prix (HT)"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel75
        '
        Me.Panel75.BackColor = System.Drawing.SystemColors.Control
        Me.Panel75.Controls.Add(Me.Label104)
        Me.Panel75.Location = New System.Drawing.Point(0, 0)
        Me.Panel75.Name = "Panel75"
        Me.Panel75.Size = New System.Drawing.Size(661, 40)
        Me.Panel75.TabIndex = 19
        '
        'Label104
        '
        Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label104.Location = New System.Drawing.Point(8, 16)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(384, 16)
        Me.Label104.TabIndex = 6
        Me.Label104.Text = "Prestation"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panelTarifs_libelle
        '
        Me.panelTarifs_libelle.BackColor = System.Drawing.SystemColors.Control
        Me.panelTarifs_libelle.Controls.Add(Me.Label8)
        Me.panelTarifs_libelle.Location = New System.Drawing.Point(0, 41)
        Me.panelTarifs_libelle.Name = "panelTarifs_libelle"
        Me.panelTarifs_libelle.Size = New System.Drawing.Size(661, 559)
        Me.panelTarifs_libelle.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(8, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(640, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Prestation"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Visible = False
        '
        'panelTarifs_prix
        '
        Me.panelTarifs_prix.BackColor = System.Drawing.SystemColors.Control
        Me.panelTarifs_prix.Controls.Add(Me.TextBox1)
        Me.panelTarifs_prix.Location = New System.Drawing.Point(662, 41)
        Me.panelTarifs_prix.Name = "panelTarifs_prix"
        Me.panelTarifs_prix.Size = New System.Drawing.Size(88, 559)
        Me.panelTarifs_prix.TabIndex = 17
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(4, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(80, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(751, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(88, 40)
        Me.Panel1.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "TVA (%)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelTarifs_tva
        '
        Me.panelTarifs_tva.BackColor = System.Drawing.SystemColors.Control
        Me.panelTarifs_tva.Controls.Add(Me.Label10)
        Me.panelTarifs_tva.Location = New System.Drawing.Point(751, 41)
        Me.panelTarifs_tva.Name = "panelTarifs_tva"
        Me.panelTarifs_tva.Size = New System.Drawing.Size(88, 559)
        Me.panelTarifs_tva.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "19,6"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label10.Visible = False
        '
        'panelTarifs_prixTTC
        '
        Me.panelTarifs_prixTTC.BackColor = System.Drawing.SystemColors.Control
        Me.panelTarifs_prixTTC.Controls.Add(Me.Label11)
        Me.panelTarifs_prixTTC.Location = New System.Drawing.Point(840, 41)
        Me.panelTarifs_prixTTC.Name = "panelTarifs_prixTTC"
        Me.panelTarifs_prixTTC.Size = New System.Drawing.Size(88, 559)
        Me.panelTarifs_prixTTC.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(8, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "119,6"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label11.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(840, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(88, 40)
        Me.Panel4.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(8, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Prix (TTC)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diagnostic_facturation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(933, 607)
        Me.ControlBox = False
        Me.Controls.Add(Me.listTarif_categories)
        Me.Controls.Add(Me.panelFooter)
        Me.Controls.Add(Me.img_Add)
        Me.Controls.Add(Me.Label_diagnostic_61)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.listTarif_prestations)
        Me.Controls.Add(Me.Panel72)
        Me.Icon = Crodip_Agent.Resources.logoCRODIP
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diagnostic_facturation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Crodip .::. Facturation"
        CType(Me.img_Add, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelFooter.ResumeLayout(False)
        Me.panelFooter.PerformLayout()
        Me.Panel72.ResumeLayout(False)
        Me.Panel74.ResumeLayout(False)
        Me.Panel75.ResumeLayout(False)
        Me.panelTarifs_libelle.ResumeLayout(False)
        Me.panelTarifs_prix.ResumeLayout(False)
        Me.panelTarifs_prix.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.panelTarifs_tva.ResumeLayout(False)
        Me.panelTarifs_prixTTC.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " - Vars - "
    Private isValider As Boolean = False
    Private m_pathBl As String
    Private m_pathFacture As String
#End Region
#Region " Chargement "
    ' Chargement de la page
    Private Sub diagnostic_finalisation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Statusbar.display(Globals.CONST_STATUTMSG_DIAG_TARIFS, False)
        Me.Cursor = Cursors.WaitCursor
        tb_txTVA.Text = My.Settings.TxTVADefaut
        ' Chargement des catégories de prestations
        Dim arrCategories() As PrestationCategorie = PrestationCategorieManager.getArrayByStructureId(agentCourant.idStructure)
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
        Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(Application.StartupPath & "\config\facturation.xml")
        If CType(FACTURATION_XML_CONFIG.getElementValue("/root/isActive"), Boolean) Then
            btn_ImprimerFacture.Visible = True
        Else
            btn_ImprimerFacture.Visible = False
        End If
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region " Boutons "

    ' Ajout d'une ligne a la facture
    Private Sub img_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles img_Add.Click
        If Not listTarif_categories.SelectedItem Is Nothing And Not listTarif_prestations.SelectedItem Is Nothing Then
            If listTarif_categories.SelectedItem.libelle.ToString <> "" And listTarif_prestations.SelectedItem.libelle.ToString <> "" Then

                prestaIncrement = prestaIncrement + 1
                'panelFooter.Top = panelFooter.Top + 24

                ' On récupère la presta sélectionnée
                Dim curPrestation As New PrestationTarif
                Try
                    curPrestation = PrestationTarifManager.getById(CType(listTarif_prestations.SelectedItem.id, Integer), agentCourant.idStructure)
                    'curPrestation = TarifsManager.getPrestationById(CType(listTarif_prestations.SelectedItem.id, Integer))
                Catch ex As Exception
                    CSDebug.dispError("Récupération tarif : " & ex.Message.ToString)
                End Try

                ' Libellé de la presta
                Dim tmpLibelle As New Label
                tmpLibelle.Text = listTarif_categories.SelectedItem.libelle.ToString & " : " & listTarif_prestations.SelectedItem.libelle.ToString
                Controls.Add(tmpLibelle)
                tmpLibelle.Parent = panelTarifs_libelle
                tmpLibelle.Name = "controlePrestaLib_" & prestaIncrement
                tmpLibelle.Location = New System.Drawing.Point(8, positionTop)
                tmpLibelle.Size = New System.Drawing.Size(640, 16)
                tmpLibelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                tmpLibelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                tmpLibelle.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))


                ' Prix HT de la presta
                Dim tmpPrix As New TextBox
                tmpPrix.Name = "controlePrixHT_" & prestaIncrement
                tmpPrix.Text = curPrestation.tarifHT
                Controls.Add(tmpPrix)
                tmpPrix.Parent = panelTarifs_prix
                tmpPrix.Location = New System.Drawing.Point(4, positionTop - 3)
                tmpPrix.Size = New System.Drawing.Size(80, 20)
                AddHandler tmpPrix.TextChanged, AddressOf prix_TextChanged
                AddHandler tmpPrix.KeyPress, AddressOf prix_KeyPress

                ' Prix TVA de la presta
                Dim tmpPrixTva As New TextBox
                tmpPrixTva.Name = "controlePrixTVA_" & prestaIncrement
                tmpPrixTva.Text = curPrestation.tva
                Controls.Add(tmpPrixTva)
                tmpPrixTva.Parent = panelTarifs_tva
                tmpPrixTva.Location = New System.Drawing.Point(4, positionTop - 3)
                tmpPrixTva.Size = New System.Drawing.Size(80, 20)
                AddHandler tmpPrixTva.TextChanged, AddressOf prix_TextChanged

                ' Prix TTC de la presta
                Dim tmpPrixTtc As New TextBox
                tmpPrixTtc.Name = "controlePrixTTC_" & prestaIncrement
                tmpPrixTtc.Text = ""
                Controls.Add(tmpPrixTtc)
                tmpPrixTtc.Parent = panelTarifs_prixTTC
                tmpPrixTtc.Location = New System.Drawing.Point(4, positionTop - 3)
                tmpPrixTtc.Size = New System.Drawing.Size(80, 20)
                tmpPrixTtc.ReadOnly = True
                AddHandler tmpPrixTtc.TextChanged, AddressOf prix_TextChanged


                positionTop = positionTop + 24
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
                calcTotal()
                'diagnosticCourantTarif = CType(facturation_totalTTC.Text, Double)
                diagnosticCourant.controleTarif = CType(facturation_totalTTC.Text, Double)
                diagnosticCourant.TotalHT = CDec(facturation_totalHT.Text)
                diagnosticCourant.TotalTVA = CDec(facturation_totalTVA.Text)
                diagnosticCourant.TotalTTC = CDec(facturation_totalTTC.Text)

                ' Changement d'état du bouton
                btn_facturation_suivant.Text = "Poursuivre"
                btn_facturation_imprimerContrat.Enabled = True
                btn_facturation_imprimerBL.Enabled = True
                btn_ImprimerFacture.Enabled = True
                isValider = True

                listTarif_categories.Enabled = False
                listTarif_prestations.Enabled = False
                If prestaIncrement > 0 Then
                    For i As Integer = 1 To prestaIncrement
                        Try
                            Dim tmpPrixInput As TextBox = CSForm.getControlByName("controlePrixHT_" & i, Me)
                            tmpPrixInput.ReadOnly = True
                            Dim tmpPrixTVAInput As TextBox = CSForm.getControlByName("controlePrixTVA_" & i, Me)
                            tmpPrixTVAInput.ReadOnly = True
                            Dim tmpPrixTTCInput As TextBox = CSForm.getControlByName("controlePrixTTC_" & i, Me)
                            tmpPrixTTCInput.ReadOnly = True
                        Catch ex As Exception
                            CSDebug.dispError("Erreur de calcul du prix total")
                        End Try
                    Next
                End If
                createContrat()
                createBl_CR()

                'Facture
                Try
                    Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(Application.StartupPath & "\config\facturation.xml")
                    If CType(FACTURATION_XML_CONFIG.getElementValue("/root/isActive"), Boolean) Then
                        createFacture_CR()
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
        If prestaIncrement > 0 Then
            For i As Integer = 1 To prestaIncrement

                Dim prixCurHT As Double = 0
                Dim prixCurTVA As Double = 0
                Dim prixCurTTC As Double = 0

                Try

                    ' Prix HT
                    Dim tmpPrixHTInput As TextBox = CSForm.getControlByName("controlePrixHT_" & i, Me)
                    If tmpPrixHTInput.Text <> "" Then
                        prixCurHT = CType(tmpPrixHTInput.Text, Double)
                    Else
                        prixCurHT = 0
                    End If
                    prixTotalHT = prixTotalHT + prixCurHT

                    ' TVA
                    Dim tmpPrixTVAInput As TextBox = CSForm.getControlByName("controlePrixTVA_" & i, Me)
                    If tmpPrixTVAInput.Text <> "" Then
                        prixCurTVA = CType(tmpPrixTVAInput.Text, Double)
                    Else
                        prixCurTVA = 0
                    End If

                    ' Prix TTC
                    Dim tmpPrixInput As TextBox = CSForm.getControlByName("controlePrixTTC_" & i, Me)
                    prixCurTTC = prixCurHT + (prixCurHT * (prixCurTVA / 100))
                    prixTotalTTC = prixTotalTTC + prixCurTTC
                    tmpPrixInput.Text = Math.Round(prixCurTTC, 2)

                Catch ex As Exception
                    CSDebug.dispError("Erreur de calcul du prix total")
                End Try

            Next

            facturation_totalHT.Text = Math.Round(prixTotalHT, 2)
            facturation_totalTTC.Text = Math.Round(prixTotalTTC, 2)
            facturation_totalTVA.Text = Math.Round(prixTotalTTC - prixTotalHT, 2)
        Else
            Try
                ' tHT CType(facturation_txTVA.Text, Double)
                If facturation_totalHT.Text <> "" And tb_txTVA.Text <> "" Then
                    prixTotalHT = CType(facturation_totalHT.Text, Double)
                    facturation_totalTTC.Text = Math.Round(prixTotalHT + (prixTotalHT * (CType(tb_txTVA.Text, Double) / 100)), 2)
                    facturation_totalTVA.Text = Math.Round(CType(facturation_totalTTC.Text, Double) - prixTotalHT, 2)
                Else
                    facturation_totalTVA.Text = ""
                End If
            Catch ex As Exception
                CSDebug.dispError("Erreur de calcul du prix total")
            End Try
        End If

    End Sub

#End Region

#Region " Impressions "

    ' Impression facture
    Private Sub createFacture_CR()

        Try
            Dim factureObj As DiagnosticFacture
            factureObj = Me.saveFacture()

            Dim oEtat As New EtatFacture(diagnosticCourant, factureObj.factureReference)

            ' On rempli la liste des prestations
            Dim PrestaLibelle As String = ""
            Dim PrestaHT As String = ""
            Dim PrestaTVA As String = ""
            Dim PrestaTTC As String = ""
            If prestaIncrement > 0 Then
                For i As Integer = 1 To prestaIncrement

                    ' Libellé
                    Dim tmpPrestaLib As Label = CSForm.getControlByName("controlePrestaLib_" & i, Me)
                    PrestaLibelle = tmpPrestaLib.Text

                    ' Prix HT
                    Dim tmpPrixHTInput As TextBox = CSForm.getControlByName("controlePrixHT_" & i, Me)
                    PrestaHT = tmpPrixHTInput.Text

                    ' TVA
                    Dim tmpPrixTVAInput As TextBox = CSForm.getControlByName("controlePrixTVA_" & i, Me)
                    PrestaTVA = tmpPrixTVAInput.Text

                    ' Prix TTC
                    Dim tmpPrixInput As TextBox = CSForm.getControlByName("controlePrixTTC_" & i, Me)
                    PrestaTTC = tmpPrixInput.Text

                    oEtat.AddPresta(PrestaLibelle, PrestaHT, 1, PrestaTVA, PrestaHT, PrestaTTC)


                Next
            End If

            oEtat.GenereEtat()
            m_pathFacture = oEtat.getFileName()
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::createFacture_CR : " & ex.Message)
        End Try



    End Sub

    Private Function saveFacture() As DiagnosticFacture
        Dim facture As DiagnosticFacture = New DiagnosticFacture
        Try
            '####
            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(Application.StartupPath & "\config\facturation.xml")
            Dim organismePCourant As Structuree = StructureManager.getStructureById(diagnosticCourant.organismePresId)
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
            facture.factureReference = DiagnosticFactureManager.getNewReference(agentCourant)
            facture.factureDate = Format(Date.Now, "dd/MM/yyyy")
            facture.factureTotal = champTotalTtc
            facture.emetteurOrganisme = organismePCourant.nom
            facture.emetteurOrganismeAdresse = organismePCourant.adresse
            facture.emetteurOrganismeCpVille = organismePCourant.codePostal & " " & organismePCourant.commune
            facture.emetteurOrganismeTelFax = organismePCourant.telephoneFixe & " / " & organismePCourant.telephoneFax
            facture.emetteurOrganismeSiren = FACTURATION_XML_CONFIG.getElementValue("/root/siren")
            facture.emetteurOrganismeTva = FACTURATION_XML_CONFIG.getElementValue("/root/tva")
            facture.emetteurOrganismeRcs = FACTURATION_XML_CONFIG.getElementValue("/root/rcs")
            facture.recepteurRaisonSociale = clientCourant.raisonSociale
            facture.recepteurProprio = clientCourant.nomExploitant & " " & clientCourant.prenomExploitant
            facture.recepteurCpVille = clientCourant.codePostal & " " & clientCourant.commune
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

            Dim oEtat As New EtatContratCommercial(diagnosticCourant)
            If oEtat.GenereEtat() Then
                pathContrat = Globals.CONST_PATH_EXP & oEtat.getFileName()
                diagnosticCourant.CCFileName = oEtat.getFileName()
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

            Dim oEtat As New EtatBL(diagnosticCourant)

            ' On rempli la liste des prestations
            Dim PrestaLibelle As String = ""
            Dim PrestaHT As String = ""
            Dim PrestaTVA As String = ""
            Dim PrestaTTC As String = ""
            If prestaIncrement > 0 Then
                For i As Integer = 1 To prestaIncrement

                    ' Libellé
                    Dim tmpPrestaLib As Label = CSForm.getControlByName("controlePrestaLib_" & i, Me)
                    PrestaLibelle = tmpPrestaLib.Text

                    ' Prix HT
                    Dim tmpPrixHTInput As TextBox = CSForm.getControlByName("controlePrixHT_" & i, Me)
                    PrestaHT = tmpPrixHTInput.Text

                    ' TVA
                    Dim tmpPrixTVAInput As TextBox = CSForm.getControlByName("controlePrixTVA_" & i, Me)
                    PrestaTVA = tmpPrixTVAInput.Text

                    ' Prix TTC
                    Dim tmpPrixInput As TextBox = CSForm.getControlByName("controlePrixTTC_" & i, Me)
                    PrestaTTC = tmpPrixInput.Text

                    oEtat.AddPresta(PrestaLibelle, PrestaHT, 1, PrestaTVA, PrestaHT, PrestaTTC)


                Next
            End If

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

    ' Recalcul du total au changement du prix d'une presta
    Private Sub prix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcTotal()
    End Sub

    ' Si on rentre le total a la main
    Private Sub facturation_totalHT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles facturation_totalHT.TextChanged
        calcTotal()
    End Sub
    Private Sub facturation_txTVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_txTVA.TextChanged
        calcTotal()
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
        If e.Button = Windows.Forms.MouseButtons.Right Then
            facturation_totalHT.Text = "0"
            isValider = True
        End If
        suivant(sender)
    End Sub

    Private Sub btn_ImprimerFacture_Click(sender As Object, e As EventArgs) Handles btn_ImprimerFacture.Click
        ' On affiche le PDF rempli
        Try
            CSFile.open(m_pathFacture)
        Catch ex As Exception
            CSDebug.dispError("diagnostic_finalisation::btn_facturation_imprimerFact_Click( Affichage Facture ) : " & ex.Message)
        End Try


    End Sub

End Class
