Imports System.Threading
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports System.IO
Imports System.Collections.Generic
''' <summary>
''' Fenêtre de controle des manomètres
''' </summary>
''' <remarks></remarks>
Public Class frmControleManometres
    Inherits frmCRODIP

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
    Friend WithEvents TextBox41 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Panel64 As System.Windows.Forms.Panel
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ongletsManos As System.Windows.Forms.TabControl
    Friend WithEvents panelArrayglob_spacer As System.Windows.Forms.Panel
    Friend WithEvents control_erreurMoy_00253 As System.Windows.Forms.TextBox
    Friend WithEvents labelArrayglob_titleErreurMoy As System.Windows.Forms.Label
    Friend WithEvents btn_controleManos_valider As System.Windows.Forms.Label
    Friend WithEvents btn_controleManos_suivant As System.Windows.Forms.Label
    Friend WithEvents list_manometresEtalon As System.Windows.Forms.ComboBox
    Friend WithEvents panelArrayglob_00253 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents panelArrayglob_titlePressionApp As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents labelArrayglob_titlePressionApp As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents panelArrayglob_titlePressionCroissante As System.Windows.Forms.Panel
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ImageList_onglets As System.Windows.Forms.ImageList
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents labelInfo_reference As System.Windows.Forms.Label
    Friend WithEvents labelInfo_marque As System.Windows.Forms.Label
    Friend WithEvents labelInfo_classe As System.Windows.Forms.Label
    Friend WithEvents labelInfo_fondEchelle As System.Windows.Forms.Label
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents labelInfoEtalon_classe As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents labelInfoEtalon_fondEchelle As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents labelInfoEtalon_marque As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents labelInfoEtalon_reference As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents btn_controleBanc_annuler As System.Windows.Forms.Label
    Friend WithEvents btn_controleManos_acquiring As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel_loading As System.Windows.Forms.Panel
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControleManometres))
        Me.TextBox41 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.list_manometresEtalon = New System.Windows.Forms.ComboBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Panel64 = New System.Windows.Forms.Panel()
        Me.btn_controleManos_acquiring = New System.Windows.Forms.PictureBox()
        Me.Panel_loading = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btn_controleBanc_annuler = New System.Windows.Forms.Label()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.labelInfoEtalon_classe = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.labelInfoEtalon_fondEchelle = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.labelInfoEtalon_marque = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.labelInfoEtalon_reference = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btn_controleManos_suivant = New System.Windows.Forms.Label()
        Me.ongletsManos = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.panelArrayglob_00253 = New System.Windows.Forms.Panel()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.panelArrayglob_titlePressionApp = New System.Windows.Forms.Panel()
        Me.panelArrayglob_titlePressionCroissante = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.labelArrayglob_titlePressionApp = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.control_erreurMoy_00253 = New System.Windows.Forms.TextBox()
        Me.labelArrayglob_titleErreurMoy = New System.Windows.Forms.Label()
        Me.panelArrayglob_spacer = New System.Windows.Forms.Panel()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.labelInfo_reference = New System.Windows.Forms.Label()
        Me.labelInfo_marque = New System.Windows.Forms.Label()
        Me.labelInfo_classe = New System.Windows.Forms.Label()
        Me.labelInfo_fondEchelle = New System.Windows.Forms.Label()
        Me.btn_controleManos_valider = New System.Windows.Forms.Label()
        Me.ImageList_onglets = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel64.SuspendLayout()
        CType(Me.btn_controleManos_acquiring, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_loading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel19.SuspendLayout()
        Me.ongletsManos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.panelArrayglob_00253.SuspendLayout()
        Me.Panel25.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.panelArrayglob_titlePressionCroissante.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox41
        '
        Me.TextBox41.Location = New System.Drawing.Point(926, 14)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New System.Drawing.Size(74, 20)
        Me.TextBox41.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(785, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Température de l'air"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(464, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(151, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Manomètre de référence"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'list_manometresEtalon
        '
        Me.list_manometresEtalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.list_manometresEtalon.ItemHeight = 13
        Me.list_manometresEtalon.Location = New System.Drawing.Point(621, 14)
        Me.list_manometresEtalon.Name = "list_manometresEtalon"
        Me.list_manometresEtalon.Size = New System.Drawing.Size(144, 21)
        Me.list_manometresEtalon.TabIndex = 1
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label82.Image = CType(resources.GetObject("Label82.Image"), System.Drawing.Image)
        Me.Label82.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label82.Location = New System.Drawing.Point(8, 8)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(312, 25)
        Me.Label82.TabIndex = 4
        Me.Label82.Text = "     Vérifications des manomètres"
        '
        'Panel64
        '
        Me.Panel64.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel64.Controls.Add(Me.btn_controleManos_acquiring)
        Me.Panel64.Controls.Add(Me.Panel_loading)
        Me.Panel64.Controls.Add(Me.btn_controleBanc_annuler)
        Me.Panel64.Controls.Add(Me.Panel19)
        Me.Panel64.Controls.Add(Me.Label36)
        Me.Panel64.Controls.Add(Me.btn_controleManos_suivant)
        Me.Panel64.Controls.Add(Me.ongletsManos)
        Me.Panel64.Controls.Add(Me.TextBox41)
        Me.Panel64.Controls.Add(Me.Label9)
        Me.Panel64.Controls.Add(Me.Label8)
        Me.Panel64.Controls.Add(Me.list_manometresEtalon)
        Me.Panel64.Controls.Add(Me.Label82)
        Me.Panel64.Location = New System.Drawing.Point(0, 0)
        Me.Panel64.Name = "Panel64"
        Me.Panel64.Size = New System.Drawing.Size(1008, 679)
        Me.Panel64.TabIndex = 20
        '
        'btn_controleManos_acquiring
        '
        Me.btn_controleManos_acquiring.Image = CType(resources.GetObject("btn_controleManos_acquiring.Image"), System.Drawing.Image)
        Me.btn_controleManos_acquiring.Location = New System.Drawing.Point(40, 87)
        Me.btn_controleManos_acquiring.Name = "btn_controleManos_acquiring"
        Me.btn_controleManos_acquiring.Size = New System.Drawing.Size(48, 48)
        Me.btn_controleManos_acquiring.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.btn_controleManos_acquiring.TabIndex = 0
        Me.btn_controleManos_acquiring.TabStop = False
        '
        'Panel_loading
        '
        Me.Panel_loading.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel_loading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_loading.Controls.Add(Me.Label15)
        Me.Panel_loading.Controls.Add(Me.PictureBox2)
        Me.Panel_loading.Location = New System.Drawing.Point(360, 299)
        Me.Panel_loading.Name = "Panel_loading"
        Me.Panel_loading.Size = New System.Drawing.Size(288, 80)
        Me.Panel_loading.TabIndex = 30
        Me.Panel_loading.Visible = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(8, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(272, 23)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Chargement des mesures..."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.PictureBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(34, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(220, 19)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'btn_controleBanc_annuler
        '
        Me.btn_controleBanc_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleBanc_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleBanc_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_controleBanc_annuler.Image = CType(resources.GetObject("btn_controleBanc_annuler.Image"), System.Drawing.Image)
        Me.btn_controleBanc_annuler.Location = New System.Drawing.Point(328, 8)
        Me.btn_controleBanc_annuler.Name = "btn_controleBanc_annuler"
        Me.btn_controleBanc_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleBanc_annuler.TabIndex = 29
        Me.btn_controleBanc_annuler.Text = "    Quitter l'outil"
        Me.btn_controleBanc_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.labelInfoEtalon_classe)
        Me.Panel19.Controls.Add(Me.Label43)
        Me.Panel19.Controls.Add(Me.labelInfoEtalon_fondEchelle)
        Me.Panel19.Controls.Add(Me.Label45)
        Me.Panel19.Controls.Add(Me.labelInfoEtalon_marque)
        Me.Panel19.Controls.Add(Me.Label47)
        Me.Panel19.Controls.Add(Me.Label48)
        Me.Panel19.Controls.Add(Me.Label49)
        Me.Panel19.Controls.Add(Me.labelInfoEtalon_reference)
        Me.Panel19.Location = New System.Drawing.Point(748, 160)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(232, 104)
        Me.Panel19.TabIndex = 28
        '
        'labelInfoEtalon_classe
        '
        Me.labelInfoEtalon_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfoEtalon_classe.ForeColor = System.Drawing.Color.Black
        Me.labelInfoEtalon_classe.Location = New System.Drawing.Point(128, 64)
        Me.labelInfoEtalon_classe.Name = "labelInfoEtalon_classe"
        Me.labelInfoEtalon_classe.Size = New System.Drawing.Size(96, 16)
        Me.labelInfoEtalon_classe.TabIndex = 10
        Me.labelInfoEtalon_classe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label43.Location = New System.Drawing.Point(16, 64)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(104, 16)
        Me.Label43.TabIndex = 10
        Me.Label43.Text = "Classe :"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelInfoEtalon_fondEchelle
        '
        Me.labelInfoEtalon_fondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfoEtalon_fondEchelle.ForeColor = System.Drawing.Color.Black
        Me.labelInfoEtalon_fondEchelle.Location = New System.Drawing.Point(128, 80)
        Me.labelInfoEtalon_fondEchelle.Name = "labelInfoEtalon_fondEchelle"
        Me.labelInfoEtalon_fondEchelle.Size = New System.Drawing.Size(96, 16)
        Me.labelInfoEtalon_fondEchelle.TabIndex = 10
        Me.labelInfoEtalon_fondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label45.Image = CType(resources.GetObject("Label45.Image"), System.Drawing.Image)
        Me.Label45.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label45.Location = New System.Drawing.Point(9, 8)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(215, 16)
        Me.Label45.TabIndex = 26
        Me.Label45.Text = "     Mano de réference"
        '
        'labelInfoEtalon_marque
        '
        Me.labelInfoEtalon_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfoEtalon_marque.ForeColor = System.Drawing.Color.Black
        Me.labelInfoEtalon_marque.Location = New System.Drawing.Point(128, 48)
        Me.labelInfoEtalon_marque.Name = "labelInfoEtalon_marque"
        Me.labelInfoEtalon_marque.Size = New System.Drawing.Size(96, 16)
        Me.labelInfoEtalon_marque.TabIndex = 10
        Me.labelInfoEtalon_marque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label47.Location = New System.Drawing.Point(16, 80)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(104, 16)
        Me.Label47.TabIndex = 10
        Me.Label47.Text = "Fond d'échelle :"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label48
        '
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label48.Location = New System.Drawing.Point(16, 48)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(104, 16)
        Me.Label48.TabIndex = 10
        Me.Label48.Text = "Marque :"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label49.Location = New System.Drawing.Point(16, 32)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(104, 16)
        Me.Label49.TabIndex = 10
        Me.Label49.Text = "N° identifiant :"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelInfoEtalon_reference
        '
        Me.labelInfoEtalon_reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfoEtalon_reference.ForeColor = System.Drawing.Color.Black
        Me.labelInfoEtalon_reference.Location = New System.Drawing.Point(128, 32)
        Me.labelInfoEtalon_reference.Name = "labelInfoEtalon_reference"
        Me.labelInfoEtalon_reference.Size = New System.Drawing.Size(96, 16)
        Me.labelInfoEtalon_reference.TabIndex = 10
        Me.labelInfoEtalon_reference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(744, 374)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(248, 218)
        Me.Label36.TabIndex = 10
        Me.Label36.Text = resources.GetString("Label36.Text")
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_controleManos_suivant
        '
        Me.btn_controleManos_suivant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleManos_suivant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleManos_suivant.ForeColor = System.Drawing.Color.White
        Me.btn_controleManos_suivant.Image = CType(resources.GetObject("btn_controleManos_suivant.Image"), System.Drawing.Image)
        Me.btn_controleManos_suivant.Location = New System.Drawing.Point(864, 600)
        Me.btn_controleManos_suivant.Name = "btn_controleManos_suivant"
        Me.btn_controleManos_suivant.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleManos_suivant.TabIndex = 27
        Me.btn_controleManos_suivant.Text = "    Mano suivant"
        Me.btn_controleManos_suivant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ongletsManos
        '
        Me.ongletsManos.Controls.Add(Me.TabPage1)
        Me.ongletsManos.Enabled = False
        Me.ongletsManos.ImageList = Me.ImageList_onglets
        Me.ongletsManos.Location = New System.Drawing.Point(8, 40)
        Me.ongletsManos.Name = "ongletsManos"
        Me.ongletsManos.SelectedIndex = 0
        Me.ongletsManos.Size = New System.Drawing.Size(992, 624)
        Me.ongletsManos.TabIndex = 18
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label35)
        Me.TabPage1.Controls.Add(Me.Label34)
        Me.TabPage1.Controls.Add(Me.panelArrayglob_00253)
        Me.TabPage1.Controls.Add(Me.control_erreurMoy_00253)
        Me.TabPage1.Controls.Add(Me.labelArrayglob_titleErreurMoy)
        Me.TabPage1.Controls.Add(Me.panelArrayglob_spacer)
        Me.TabPage1.Controls.Add(Me.Label37)
        Me.TabPage1.Controls.Add(Me.Label38)
        Me.TabPage1.Controls.Add(Me.Label39)
        Me.TabPage1.Controls.Add(Me.Label40)
        Me.TabPage1.Controls.Add(Me.Label41)
        Me.TabPage1.Controls.Add(Me.labelInfo_reference)
        Me.TabPage1.Controls.Add(Me.labelInfo_marque)
        Me.TabPage1.Controls.Add(Me.labelInfo_classe)
        Me.TabPage1.Controls.Add(Me.labelInfo_fondEchelle)
        Me.TabPage1.Controls.Add(Me.btn_controleManos_valider)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(984, 597)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Mano 00253"
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Green
        Me.Label35.Location = New System.Drawing.Point(736, 224)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(224, 87)
        Me.Label35.TabIndex = 10
        Me.Label35.Text = "Votre manomètre est fiable : il répond à sa classe de précision."
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label34.Image = CType(resources.GetObject("Label34.Image"), System.Drawing.Image)
        Me.Label34.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label34.Location = New System.Drawing.Point(744, 208)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(175, 16)
        Me.Label34.TabIndex = 26
        Me.Label34.Text = "       Résultat de l'essai"
        '
        'panelArrayglob_00253
        '
        Me.panelArrayglob_00253.AutoScroll = True
        Me.panelArrayglob_00253.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.panelArrayglob_00253.Controls.Add(Me.Panel25)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel24)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel23)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel22)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel21)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel20)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel8)
        Me.panelArrayglob_00253.Controls.Add(Me.panelArrayglob_titlePressionApp)
        Me.panelArrayglob_00253.Controls.Add(Me.panelArrayglob_titlePressionCroissante)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel1)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel2)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel3)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel4)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel5)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel6)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel7)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel9)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel10)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel11)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel12)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel13)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel14)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel15)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel16)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel17)
        Me.panelArrayglob_00253.Controls.Add(Me.Panel18)
        Me.panelArrayglob_00253.Location = New System.Drawing.Point(8, 8)
        Me.panelArrayglob_00253.Name = "panelArrayglob_00253"
        Me.panelArrayglob_00253.Size = New System.Drawing.Size(722, 593)
        Me.panelArrayglob_00253.TabIndex = 25
        Me.panelArrayglob_00253.Visible = False
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel25.Controls.Add(Me.Label17)
        Me.Panel25.Location = New System.Drawing.Point(450, 0)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(90, 80)
        Me.Panel25.TabIndex = 28
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(8, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 56)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "EMT"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel24.Controls.Add(Me.Label16)
        Me.Panel24.Location = New System.Drawing.Point(360, 0)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(90, 80)
        Me.Panel24.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(8, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 56)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Incertitude"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel23.Location = New System.Drawing.Point(450, 335)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(90, 245)
        Me.Panel23.TabIndex = 26
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel22.Location = New System.Drawing.Point(360, 335)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(90, 245)
        Me.Panel22.TabIndex = 25
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel21.Location = New System.Drawing.Point(450, 80)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(90, 256)
        Me.Panel21.TabIndex = 24
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel20.Location = New System.Drawing.Point(360, 80)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(90, 256)
        Me.Panel20.TabIndex = 23
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Controls.Add(Me.Label12)
        Me.Panel8.Controls.Add(Me.Label13)
        Me.Panel8.Controls.Add(Me.Label14)
        Me.Panel8.Location = New System.Drawing.Point(90, 80)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(90, 256)
        Me.Panel8.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(8, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "2"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(8, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "3"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(8, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "4"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(8, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "5"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(8, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "6"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'panelArrayglob_titlePressionApp
        '
        Me.panelArrayglob_titlePressionApp.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.panelArrayglob_titlePressionApp.Location = New System.Drawing.Point(0, 0)
        Me.panelArrayglob_titlePressionApp.Name = "panelArrayglob_titlePressionApp"
        Me.panelArrayglob_titlePressionApp.Size = New System.Drawing.Size(90, 80)
        Me.panelArrayglob_titlePressionApp.TabIndex = 21
        '
        'panelArrayglob_titlePressionCroissante
        '
        Me.panelArrayglob_titlePressionCroissante.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.panelArrayglob_titlePressionCroissante.Controls.Add(Me.Label7)
        Me.panelArrayglob_titlePressionCroissante.Location = New System.Drawing.Point(0, 80)
        Me.panelArrayglob_titlePressionCroissante.Name = "panelArrayglob_titlePressionCroissante"
        Me.panelArrayglob_titlePressionCroissante.Size = New System.Drawing.Size(90, 256)
        Me.panelArrayglob_titlePressionCroissante.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 256)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Pression croissante"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel1.Controls.Add(Me.labelArrayglob_titlePressionApp)
        Me.Panel1.Location = New System.Drawing.Point(90, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(90, 80)
        Me.Panel1.TabIndex = 21
        '
        'labelArrayglob_titlePressionApp
        '
        Me.labelArrayglob_titlePressionApp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelArrayglob_titlePressionApp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelArrayglob_titlePressionApp.Location = New System.Drawing.Point(8, 8)
        Me.labelArrayglob_titlePressionApp.Name = "labelArrayglob_titlePressionApp"
        Me.labelArrayglob_titlePressionApp.Size = New System.Drawing.Size(73, 64)
        Me.labelArrayglob_titlePressionApp.TabIndex = 10
        Me.labelArrayglob_titlePressionApp.Text = "Points d'essai"
        Me.labelArrayglob_titlePressionApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(180, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(90, 40)
        Me.Panel2.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 24)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Capteur testé"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(270, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 40)
        Me.Panel3.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Instrument de référence"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Location = New System.Drawing.Point(540, 40)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 40)
        Me.Panel4.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 24)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Absolue (bar)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Location = New System.Drawing.Point(630, 40)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(90, 40)
        Me.Panel5.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 24)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Fond d'echelle (%)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Location = New System.Drawing.Point(180, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(180, 40)
        Me.Panel6.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 24)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Pression (bar)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel7.Controls.Add(Me.Label20)
        Me.Panel7.Location = New System.Drawing.Point(540, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(180, 40)
        Me.Panel7.TabIndex = 21
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(16, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(136, 24)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Erreur"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel9.Controls.Add(Me.TextBox1)
        Me.Panel9.Controls.Add(Me.TextBox2)
        Me.Panel9.Controls.Add(Me.TextBox3)
        Me.Panel9.Controls.Add(Me.TextBox4)
        Me.Panel9.Controls.Add(Me.TextBox5)
        Me.Panel9.Controls.Add(Me.TextBox7)
        Me.Panel9.Location = New System.Drawing.Point(180, 80)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(90, 256)
        Me.Panel9.TabIndex = 22
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(72, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Tag = "1-1"
        Me.TextBox1.Text = "TextBox1"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(8, 32)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(72, 20)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.Text = "TextBox1"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(8, 56)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(72, 20)
        Me.TextBox3.TabIndex = 0
        Me.TextBox3.Text = "TextBox1"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(8, 80)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(72, 20)
        Me.TextBox4.TabIndex = 0
        Me.TextBox4.Text = "TextBox1"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(8, 128)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(72, 20)
        Me.TextBox5.TabIndex = 0
        Me.TextBox5.Text = "TextBox1"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(8, 104)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(72, 20)
        Me.TextBox7.TabIndex = 0
        Me.TextBox7.Text = "TextBox1"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel10.Location = New System.Drawing.Point(270, 80)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(90, 256)
        Me.Panel10.TabIndex = 22
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel11.Location = New System.Drawing.Point(540, 80)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(90, 256)
        Me.Panel11.TabIndex = 22
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel12.Location = New System.Drawing.Point(630, 80)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(90, 256)
        Me.Panel12.TabIndex = 22
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel13.Controls.Add(Me.Label21)
        Me.Panel13.Controls.Add(Me.Label22)
        Me.Panel13.Controls.Add(Me.Label23)
        Me.Panel13.Controls.Add(Me.Label24)
        Me.Panel13.Controls.Add(Me.Label25)
        Me.Panel13.Controls.Add(Me.Label26)
        Me.Panel13.Location = New System.Drawing.Point(90, 332)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(90, 256)
        Me.Panel13.TabIndex = 22
        '
        'Label21
        '
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(0, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 256)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "1"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(8, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 16)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "2"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(8, 56)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 16)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "3"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(8, 80)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 16)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "4"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(8, 104)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 16)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "5"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(8, 128)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 16)
        Me.Label26.TabIndex = 10
        Me.Label26.Text = "6"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel14.Location = New System.Drawing.Point(180, 332)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(90, 248)
        Me.Panel14.TabIndex = 22
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel15.Location = New System.Drawing.Point(270, 332)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(90, 248)
        Me.Panel15.TabIndex = 22
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel16.Location = New System.Drawing.Point(630, 332)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(90, 248)
        Me.Panel16.TabIndex = 22
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel17.Controls.Add(Me.Label32)
        Me.Panel17.Location = New System.Drawing.Point(0, 332)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(90, 248)
        Me.Panel17.TabIndex = 18
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(8, 16)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(72, 224)
        Me.Label32.TabIndex = 10
        Me.Label32.Text = "Pression décroissante"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel18.Location = New System.Drawing.Point(540, 332)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(90, 248)
        Me.Panel18.TabIndex = 22
        '
        'control_erreurMoy_00253
        '
        Me.control_erreurMoy_00253.Location = New System.Drawing.Point(512, 392)
        Me.control_erreurMoy_00253.Name = "control_erreurMoy_00253"
        Me.control_erreurMoy_00253.Size = New System.Drawing.Size(91, 20)
        Me.control_erreurMoy_00253.TabIndex = 24
        Me.control_erreurMoy_00253.Visible = False
        '
        'labelArrayglob_titleErreurMoy
        '
        Me.labelArrayglob_titleErreurMoy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelArrayglob_titleErreurMoy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelArrayglob_titleErreurMoy.Location = New System.Drawing.Point(392, 392)
        Me.labelArrayglob_titleErreurMoy.Name = "labelArrayglob_titleErreurMoy"
        Me.labelArrayglob_titleErreurMoy.Size = New System.Drawing.Size(96, 16)
        Me.labelArrayglob_titleErreurMoy.TabIndex = 20
        Me.labelArrayglob_titleErreurMoy.Text = "Erreur moyenne"
        Me.labelArrayglob_titleErreurMoy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.labelArrayglob_titleErreurMoy.Visible = False
        '
        'panelArrayglob_spacer
        '
        Me.panelArrayglob_spacer.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.panelArrayglob_spacer.Location = New System.Drawing.Point(360, 384)
        Me.panelArrayglob_spacer.Name = "panelArrayglob_spacer"
        Me.panelArrayglob_spacer.Size = New System.Drawing.Size(256, 3)
        Me.panelArrayglob_spacer.TabIndex = 19
        Me.panelArrayglob_spacer.Visible = False
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label37.Image = CType(resources.GetObject("Label37.Image"), System.Drawing.Image)
        Me.Label37.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label37.Location = New System.Drawing.Point(744, 8)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(232, 16)
        Me.Label37.TabIndex = 26
        Me.Label37.Text = "       Infos Manomètre"
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(736, 48)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(120, 16)
        Me.Label38.TabIndex = 10
        Me.Label38.Text = "Marque :"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(736, 64)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(120, 16)
        Me.Label39.TabIndex = 10
        Me.Label39.Text = "Classe d'exactitude :"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(736, 80)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(120, 16)
        Me.Label40.TabIndex = 10
        Me.Label40.Text = "Fond d'échelle :"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(736, 32)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(120, 16)
        Me.Label41.TabIndex = 10
        Me.Label41.Text = "Référence :"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelInfo_reference
        '
        Me.labelInfo_reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo_reference.ForeColor = System.Drawing.Color.Black
        Me.labelInfo_reference.Location = New System.Drawing.Point(856, 32)
        Me.labelInfo_reference.Name = "labelInfo_reference"
        Me.labelInfo_reference.Size = New System.Drawing.Size(104, 16)
        Me.labelInfo_reference.TabIndex = 10
        Me.labelInfo_reference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfo_marque
        '
        Me.labelInfo_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo_marque.ForeColor = System.Drawing.Color.Black
        Me.labelInfo_marque.Location = New System.Drawing.Point(856, 48)
        Me.labelInfo_marque.Name = "labelInfo_marque"
        Me.labelInfo_marque.Size = New System.Drawing.Size(104, 16)
        Me.labelInfo_marque.TabIndex = 10
        Me.labelInfo_marque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfo_classe
        '
        Me.labelInfo_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo_classe.ForeColor = System.Drawing.Color.Black
        Me.labelInfo_classe.Location = New System.Drawing.Point(856, 64)
        Me.labelInfo_classe.Name = "labelInfo_classe"
        Me.labelInfo_classe.Size = New System.Drawing.Size(104, 16)
        Me.labelInfo_classe.TabIndex = 10
        Me.labelInfo_classe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfo_fondEchelle
        '
        Me.labelInfo_fondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo_fondEchelle.ForeColor = System.Drawing.Color.Black
        Me.labelInfo_fondEchelle.Location = New System.Drawing.Point(856, 80)
        Me.labelInfo_fondEchelle.Name = "labelInfo_fondEchelle"
        Me.labelInfo_fondEchelle.Size = New System.Drawing.Size(104, 16)
        Me.labelInfo_fondEchelle.TabIndex = 10
        Me.labelInfo_fondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_controleManos_valider
        '
        Me.btn_controleManos_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleManos_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleManos_valider.ForeColor = System.Drawing.Color.White
        Me.btn_controleManos_valider.Image = CType(resources.GetObject("btn_controleManos_valider.Image"), System.Drawing.Image)
        Me.btn_controleManos_valider.Location = New System.Drawing.Point(852, 568)
        Me.btn_controleManos_valider.Name = "btn_controleManos_valider"
        Me.btn_controleManos_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleManos_valider.TabIndex = 27
        Me.btn_controleManos_valider.Text = "    Valider / Quitter"
        Me.btn_controleManos_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList_onglets
        '
        Me.ImageList_onglets.ImageStream = CType(resources.GetObject("ImageList_onglets.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_onglets.TransparentColor = System.Drawing.Color.White
        Me.ImageList_onglets.Images.SetKeyName(0, "")
        '
        'controle_manometres
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel64)
        Me.Name = "controle_manometres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Contrôle des manomètres de l'agent"
        Me.Panel64.ResumeLayout(False)
        Me.Panel64.PerformLayout()
        CType(Me.btn_controleManos_acquiring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_loading.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel19.ResumeLayout(False)
        Me.ongletsManos.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.panelArrayglob_00253.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.panelArrayglob_titlePressionCroissante.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Init Glob Vars "

    Private nbMesures As Integer = 6
    Private curManoEtalon As ManometreEtalon
    Private curManoControle As ManometreControle
    Private prevSelectedManoOnglet As Integer = -1

#End Region

    ' Chargement des mano / construction des onglets & forms
    Private Sub controle_manometres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '''TODO : Réduire cette fonction 

        '####################################################
        '######### Chargement des manomètres étalon #########
        '####################################################
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmControleManometres))

        ' On récupère les mano étalons de l'agent
        Dim arrManoEtalon As List(Of ManometreEtalon) = ManometreEtalonManager.getManometreEtalonByStructureId(agentCourant.idStructure)
        For Each tmpManoEtalon As ManometreEtalon In arrManoEtalon
            Dim objComboItem As New objComboItem(tmpManoEtalon.numeroNational, tmpManoEtalon.idCrodip)
            list_manometresEtalon.Items.Add(objComboItem)
        Next

        '####################################################
        '###### Chargement des manomètres de controle #######
        '####################################################
        ' On clear les onglets
        ongletsManos.TabPages.Clear()

        ' On récupère la liste des manos de la structure de l'agent
        Dim arrManoControle As List(Of ManometreControle) = ManometreControleManager.getManoControleByStructureId(agentCourant.idStructure, True)
        ' Création des contrôles a la volée
        Dim positionTop As Integer = 0
        Dim nTabIndex As Integer
        For Each tmpManoControle As ManometreControle In arrManoControle

            nTabIndex = 1

            ' Création d'une nouvelle page dans le controltab
            Dim tmpTab As New TabPage
            tmpTab.Name = "tabPage_mano_" & tmpManoControle.numeroNational
            tmpTab.Text = "Mano " & tmpManoControle.idCrodip
            ongletsManos.TabPages.Add(tmpTab)
            tmpTab.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))


            '##########################
            '   Array global
            '##########################
            '
            'panelArrayglob
            '
            Dim tmpPanelArrayglob As New Panel
            tmpPanelArrayglob.Name = "panelArrayglob_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob)
            tmpPanelArrayglob.AutoScroll = True
            tmpPanelArrayglob.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(123, Byte), CType(191, Byte))
            tmpPanelArrayglob.Location = New System.Drawing.Point(8, 8)
            tmpPanelArrayglob.Size = New System.Drawing.Size(720, 584)
            tmpPanelArrayglob.Parent = tmpTab

            '
            'panelArrayglob_blocEmpty
            '
            Dim tmpPanelArrayglob_blocEmpty As New Panel
            tmpPanelArrayglob_blocEmpty.Name = "panelArrayglob_blocEmpty_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_blocEmpty)
            tmpPanelArrayglob_blocEmpty.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_blocEmpty.Location = New System.Drawing.Point(0, 0)
            tmpPanelArrayglob_blocEmpty.Size = New System.Drawing.Size(87, 79)
            tmpPanelArrayglob_blocEmpty.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePressionCroissante
            '
            Dim tmpPanelArrayglob_titlePressionCroissante As New Panel
            tmpPanelArrayglob_titlePressionCroissante.Name = "panelArrayglob_titlePressionCroissante_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePressionCroissante)
            tmpPanelArrayglob_titlePressionCroissante.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePressionCroissante.Location = New System.Drawing.Point(0, 80)
            tmpPanelArrayglob_titlePressionCroissante.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_titlePressionCroissante.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePressionDecroissante
            '
            Dim tmpPanelArrayglob_titlePressionDecroissante As New Panel
            tmpPanelArrayglob_titlePressionDecroissante.Name = "panelArrayglob_titlePressionDecroissante_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePressionDecroissante)
            tmpPanelArrayglob_titlePressionDecroissante.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePressionDecroissante.Parent = tmpPanelArrayglob
            tmpPanelArrayglob_titlePressionDecroissante.Location = New System.Drawing.Point(0, 336)
            tmpPanelArrayglob_titlePressionDecroissante.Size = New System.Drawing.Size(87, 255)

            '
            'panelArrayglob_titlePointEssai
            '
            Dim tmpPanelArrayglob_titlePointEssai As New Panel
            tmpPanelArrayglob_titlePointEssai.Name = "panelArrayglob_titlePointEssai_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePointEssai)
            tmpPanelArrayglob_titlePointEssai.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePointEssai.Location = New System.Drawing.Point(88, 0)
            tmpPanelArrayglob_titlePointEssai.Size = New System.Drawing.Size(87, 79)
            tmpPanelArrayglob_titlePointEssai.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePression
            '
            Dim tmpPanelArrayglob_titlePression As New Panel
            tmpPanelArrayglob_titlePression.Name = "panelArrayglob_titlePression_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePression)
            tmpPanelArrayglob_titlePression.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePression.Location = New System.Drawing.Point(176, 0)
            tmpPanelArrayglob_titlePression.Size = New System.Drawing.Size(175, 39)
            tmpPanelArrayglob_titlePression.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePressionCapteurTeste
            '
            Dim tmpPanelArrayglob_titlePressionCapteurTeste As New Panel
            tmpPanelArrayglob_titlePressionCapteurTeste.Name = "panelArrayglob_titlePressionCapteurTeste_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePressionCapteurTeste)
            tmpPanelArrayglob_titlePressionCapteurTeste.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePressionCapteurTeste.Location = New System.Drawing.Point(176, 40)
            tmpPanelArrayglob_titlePressionCapteurTeste.Size = New System.Drawing.Size(87, 39)
            tmpPanelArrayglob_titlePressionCapteurTeste.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePressionInstrument
            '
            Dim tmpPanelArrayglob_titlePressionInstrument As New Panel
            tmpPanelArrayglob_titlePressionInstrument.Name = "panelArrayglob_titlePressionInstrument_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePressionInstrument)
            tmpPanelArrayglob_titlePressionInstrument.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePressionInstrument.Location = New System.Drawing.Point(264, 40)
            tmpPanelArrayglob_titlePressionInstrument.Size = New System.Drawing.Size(87, 39)
            tmpPanelArrayglob_titlePressionInstrument.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleIncertitude
            '
            Dim tmpPanelArrayglob_titleIncertitude As New Panel
            tmpPanelArrayglob_titleIncertitude.Name = "panelArrayglob_titleIncertitude_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleIncertitude)
            tmpPanelArrayglob_titleIncertitude.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleIncertitude.Location = New System.Drawing.Point(352, 0)
            tmpPanelArrayglob_titleIncertitude.Size = New System.Drawing.Size(87, 79)
            tmpPanelArrayglob_titleIncertitude.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleEMT
            '
            Dim tmpPanelArrayglob_titleEMT As New Panel
            tmpPanelArrayglob_titleEMT.Name = "panelArrayglob_titleEMT_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleEMT)
            tmpPanelArrayglob_titleEMT.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleEMT.Location = New System.Drawing.Point(440, 0)
            tmpPanelArrayglob_titleEMT.Size = New System.Drawing.Size(87, 79)
            tmpPanelArrayglob_titleEMT.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleErreur
            '
            Dim tmpPanelArrayglob_titleErreur As New Panel
            tmpPanelArrayglob_titleErreur.Name = "panelArrayglob_titleErreur_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleErreur)
            tmpPanelArrayglob_titleErreur.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleErreur.Location = New System.Drawing.Point(528, 0)
            tmpPanelArrayglob_titleErreur.Size = New System.Drawing.Size(175, 39)
            tmpPanelArrayglob_titleErreur.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleErreurAbsolue
            '
            Dim tmpPanelArrayglob_titleErreurAbsolue As New Panel
            tmpPanelArrayglob_titleErreurAbsolue.Name = "panelArrayglob_titleErreurAbsolue_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleErreurAbsolue)
            tmpPanelArrayglob_titleErreurAbsolue.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleErreurAbsolue.Location = New System.Drawing.Point(528, 40)
            tmpPanelArrayglob_titleErreurAbsolue.Size = New System.Drawing.Size(87, 39)
            tmpPanelArrayglob_titleErreurAbsolue.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleErreurFondEchelle
            '
            Dim tmpPanelArrayglob_titleErreurFondEchelle As New Panel
            tmpPanelArrayglob_titleErreurFondEchelle.Name = "panelArrayglob_titleErreurFondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleErreurFondEchelle)
            tmpPanelArrayglob_titleErreurFondEchelle.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleErreurFondEchelle.Location = New System.Drawing.Point(616, 40)
            tmpPanelArrayglob_titleErreurFondEchelle.Size = New System.Drawing.Size(87, 39)
            tmpPanelArrayglob_titleErreurFondEchelle.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_pointEssai
            '
            Dim tmpPanelArrayglob_croissant_pointEssai As New Panel
            tmpPanelArrayglob_croissant_pointEssai.Name = "panelArrayglob_croissant_pointEssai_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_pointEssai)
            tmpPanelArrayglob_croissant_pointEssai.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_pointEssai.Location = New System.Drawing.Point(88, 80)
            tmpPanelArrayglob_croissant_pointEssai.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_pointEssai.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_capteurTeste
            '
            Dim tmpPanelArrayglob_croissant_capteurTeste As New Panel
            tmpPanelArrayglob_croissant_capteurTeste.Name = "panelArrayglob_croissant_capteurTeste_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_capteurTeste)
            tmpPanelArrayglob_croissant_capteurTeste.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_capteurTeste.Location = New System.Drawing.Point(176, 80)
            tmpPanelArrayglob_croissant_capteurTeste.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_capteurTeste.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_instrumentReference
            '
            Dim tmpPanelArrayglob_croissant_instrumentReference As New Panel
            tmpPanelArrayglob_croissant_instrumentReference.Name = "panelArrayglob_croissant_instrumentReference_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_instrumentReference)
            tmpPanelArrayglob_croissant_instrumentReference.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_instrumentReference.Location = New System.Drawing.Point(264, 80)
            tmpPanelArrayglob_croissant_instrumentReference.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_instrumentReference.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_incertitude
            '
            Dim tmpPanelArrayglob_croissant_incertitude As New Panel
            tmpPanelArrayglob_croissant_incertitude.Name = "panelArrayglob_croissant_incertitude_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_incertitude)
            tmpPanelArrayglob_croissant_incertitude.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_incertitude.Location = New System.Drawing.Point(352, 80)
            tmpPanelArrayglob_croissant_incertitude.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_incertitude.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_EMT
            '
            Dim tmpPanelArrayglob_croissant_EMT As New Panel
            tmpPanelArrayglob_croissant_EMT.Name = "panelArrayglob_croissant_EMT_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_EMT)
            tmpPanelArrayglob_croissant_EMT.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_EMT.Location = New System.Drawing.Point(440, 80)
            tmpPanelArrayglob_croissant_EMT.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_EMT.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_erreurAbsolue
            '
            Dim tmpPanelArrayglob_croissant_erreurAbsolue As New Panel
            tmpPanelArrayglob_croissant_erreurAbsolue.Name = "panelArrayglob_croissant_erreurAbsolue_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_erreurAbsolue)
            tmpPanelArrayglob_croissant_erreurAbsolue.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_erreurAbsolue.Location = New System.Drawing.Point(528, 80)
            tmpPanelArrayglob_croissant_erreurAbsolue.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_erreurAbsolue.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_erreurFondEchelle
            '
            Dim tmpPanelArrayglob_croissant_erreurFondEchelle As New Panel
            tmpPanelArrayglob_croissant_erreurFondEchelle.Name = "panelArrayglob_croissant_erreurFondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_erreurFondEchelle)
            tmpPanelArrayglob_croissant_erreurFondEchelle.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_erreurFondEchelle.Location = New System.Drawing.Point(616, 80)
            tmpPanelArrayglob_croissant_erreurFondEchelle.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_erreurFondEchelle.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_pointEssai
            '
            Dim tmpPanelArrayglob_decroissant_pointEssai As New Panel
            tmpPanelArrayglob_decroissant_pointEssai.Name = "panelArrayglob_decroissant_pointEssai_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_pointEssai)
            tmpPanelArrayglob_decroissant_pointEssai.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_pointEssai.Location = New System.Drawing.Point(88, 336)
            tmpPanelArrayglob_decroissant_pointEssai.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_pointEssai.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_capteurTeste
            '
            Dim tmpPanelArrayglob_decroissant_capteurTeste As New Panel
            tmpPanelArrayglob_decroissant_capteurTeste.Name = "panelArrayglob_decroissant_capteurTeste_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_capteurTeste)
            tmpPanelArrayglob_decroissant_capteurTeste.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_capteurTeste.Location = New System.Drawing.Point(176, 336)
            tmpPanelArrayglob_decroissant_capteurTeste.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_capteurTeste.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_instrumentReference
            '
            Dim tmpPanelArrayglob_decroissant_instrumentReference As New Panel
            tmpPanelArrayglob_decroissant_instrumentReference.Name = "panelArrayglob_decroissant_instrumentReference_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_instrumentReference)
            tmpPanelArrayglob_decroissant_instrumentReference.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_instrumentReference.Location = New System.Drawing.Point(264, 336)
            tmpPanelArrayglob_decroissant_instrumentReference.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_instrumentReference.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_incertitude
            '
            Dim tmpPanelArrayglob_decroissant_incertitude As New Panel
            tmpPanelArrayglob_decroissant_incertitude.Name = "panelArrayglob_decroissant_incertitude_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_incertitude)
            tmpPanelArrayglob_decroissant_incertitude.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_incertitude.Location = New System.Drawing.Point(352, 336)
            tmpPanelArrayglob_decroissant_incertitude.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_incertitude.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_EMT
            '
            Dim tmpPanelArrayglob_decroissant_EMT As New Panel
            tmpPanelArrayglob_decroissant_EMT.Name = "panelArrayglob_decroissant_instrumentEMT_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_EMT)
            tmpPanelArrayglob_decroissant_EMT.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_EMT.Location = New System.Drawing.Point(440, 336)
            tmpPanelArrayglob_decroissant_EMT.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_EMT.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_erreurAbsolue
            '
            Dim tmpPanelArrayglob_decroissant_erreurAbsolue As New Panel
            tmpPanelArrayglob_decroissant_erreurAbsolue.Name = "panelArrayglob_decroissant_erreurAbsolue_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_erreurAbsolue)
            tmpPanelArrayglob_decroissant_erreurAbsolue.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_erreurAbsolue.Location = New System.Drawing.Point(528, 336)
            tmpPanelArrayglob_decroissant_erreurAbsolue.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_erreurAbsolue.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_erreurFondEchelle
            '
            Dim tmpPanelArrayglob_decroissant_erreurFondEchelle As New Panel
            tmpPanelArrayglob_decroissant_erreurFondEchelle.Name = "panelArrayglob_decroissant_erreurFondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_erreurFondEchelle)
            tmpPanelArrayglob_decroissant_erreurFondEchelle.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_erreurFondEchelle.Location = New System.Drawing.Point(616, 336)
            tmpPanelArrayglob_decroissant_erreurFondEchelle.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_erreurFondEchelle.Parent = tmpPanelArrayglob

            '##########################
            '   Libellés
            '##########################
            '
            'Title pression
            '
            Dim tmpLib_pressionCroissant As New Label
            tmpLib_pressionCroissant.Name = "tmpLib_pressionDecroissant_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pressionCroissant)
            tmpLib_pressionCroissant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pressionCroissant.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pressionCroissant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pressionCroissant.Location = New System.Drawing.Point(8, 16)
            'tmpLib_pressionCroissant.Size = New System.Drawing.Size(104, 232)
            tmpLib_pressionCroissant.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pressionCroissant.Text = "Pression croissante"
            tmpLib_pressionCroissant.Parent = tmpPanelArrayglob_titlePressionCroissante
            Dim tmpLib_pressionDecroissant As New Label
            tmpLib_pressionDecroissant.Name = "tmpLib_pressionDecroissant_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pressionDecroissant)
            tmpLib_pressionDecroissant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pressionDecroissant.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pressionDecroissant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pressionDecroissant.Location = New System.Drawing.Point(8, 16)
            'tmpLib_pressionDecroissant.Size = New System.Drawing.Size(104, 232)
            tmpLib_pressionDecroissant.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pressionDecroissant.Text = "Pression décroissante"
            tmpLib_pressionDecroissant.Parent = tmpPanelArrayglob_titlePressionDecroissante
            '
            'Title point essaie
            '
            Dim tmpLib_pointsEssaie As New Label
            tmpLib_pointsEssaie.Name = "tmpLib_pointsEssaie_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pointsEssaie)
            tmpLib_pointsEssaie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pointsEssaie.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pointsEssaie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pointsEssaie.Location = New System.Drawing.Point(7, 8)
            'tmpLib_pointsEssaie.Size = New System.Drawing.Size(104, 56)
            tmpLib_pointsEssaie.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pointsEssaie.Text = "Points d'essai"
            tmpLib_pointsEssaie.Parent = tmpPanelArrayglob_titlePointEssai
            '
            'Title pression
            '
            Dim tmpLib_pression As New Label
            tmpLib_pression.Name = "tmpLib_pression_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pression)
            tmpLib_pression.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pression.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pression.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pression.Location = New System.Drawing.Point(8, 8)
            'tmpLib_pression.Size = New System.Drawing.Size(224, 16)
            tmpLib_pression.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pression.Text = "Pression (bar)"
            tmpLib_pression.Parent = tmpPanelArrayglob_titlePression
            '
            'Title pression capteur
            '
            Dim tmpLib_pressionCapteur As New Label
            tmpLib_pressionCapteur.Name = "tmpLib_pressionCapteur_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pressionCapteur)
            tmpLib_pressionCapteur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pressionCapteur.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pressionCapteur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pressionCapteur.Location = New System.Drawing.Point(7, 8)
            'tmpLib_pressionCapteur.Size = New System.Drawing.Size(104, 24)
            tmpLib_pressionCapteur.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pressionCapteur.Text = "Manomètre à contrôler"
            tmpLib_pressionCapteur.Parent = tmpPanelArrayglob_titlePressionCapteurTeste
            '
            'Title pression instrument
            '
            Dim tmpLib_pressionInstrument As New Label
            tmpLib_pressionInstrument.Name = "tmpLib_pressionInstrument_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pressionInstrument)
            tmpLib_pressionInstrument.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pressionInstrument.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pressionInstrument.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmpLib_pressionInstrument.Parent = tmpPanelArrayglob_titlePressionInstrument
            'tmpLib_pressionInstrument.Location = New System.Drawing.Point(7, 8)
            'tmpLib_pressionInstrument.Size = New System.Drawing.Size(104, 24)
            tmpLib_pressionInstrument.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pressionInstrument.Text = "Manomètre Référence"
            '
            'Title point incertitude
            '
            Dim tmpLib_incertitude As New Label
            tmpLib_incertitude.Name = "tmpLib_incertitude_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_incertitude)
            tmpLib_incertitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_incertitude.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_incertitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_incertitude.Location = New System.Drawing.Point(7, 8)
            'tmpLib_incertitude.Size = New System.Drawing.Size(104, 56)
            tmpLib_incertitude.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_incertitude.Text = "Incertitude"
            tmpLib_incertitude.Parent = tmpPanelArrayglob_titleIncertitude
            '
            'Title point EMT
            '
            Dim tmpLib_EMT As New Label
            tmpLib_EMT.Name = "tmpLib_EMT_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_EMT)
            tmpLib_EMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_EMT.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_EMT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_EMT.Location = New System.Drawing.Point(7, 8)
            'tmpLib_EMT.Size = New System.Drawing.Size(104, 56)
            tmpLib_EMT.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_EMT.Text = "EMT"
            tmpLib_EMT.Parent = tmpPanelArrayglob_titleEMT
            '
            'Title Erreur
            '
            Dim tmpLib_erreur As New Label
            tmpLib_erreur.Name = "tmpLib_erreur_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_erreur)
            tmpLib_erreur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_erreur.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_erreur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmpLib_erreur.Parent = tmpPanelArrayglob_titleErreur
            'tmpLib_erreur.Location = New System.Drawing.Point(8, 8)
            'tmpLib_erreur.Size = New System.Drawing.Size(224, 16)
            tmpLib_erreur.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_erreur.Text = "Erreur"
            '
            'Title Erreur Absolue
            '
            Dim tmpLib_erreurAbsolue As New Label
            tmpLib_erreurAbsolue.Name = "tmpLib_erreurAbsolue_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_erreurAbsolue)
            tmpLib_erreurAbsolue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_erreurAbsolue.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_erreurAbsolue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmpLib_erreurAbsolue.Parent = tmpPanelArrayglob_titleErreurAbsolue
            'tmpLib_erreurAbsolue.Location = New System.Drawing.Point(7, 8)
            'tmpLib_erreurAbsolue.Size = New System.Drawing.Size(104, 24)
            tmpLib_erreurAbsolue.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_erreurAbsolue.Text = "Absolue (bar)"
            '
            'Title Erreur Fond D'Echelle
            '
            Dim tmpLib_erreurFondEchelle As New Label
            tmpLib_erreurFondEchelle.Name = "tmpLib_erreurFondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_erreurFondEchelle)
            tmpLib_erreurFondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_erreurFondEchelle.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_erreurFondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmpLib_erreurFondEchelle.Parent = tmpPanelArrayglob_titleErreurFondEchelle
            'tmpLib_erreurFondEchelle.Location = New System.Drawing.Point(7, 8)
            'tmpLib_erreurFondEchelle.Size = New System.Drawing.Size(104, 24)
            tmpLib_erreurFondEchelle.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_erreurFondEchelle.Text = "Fond d'echelle (%)"

            '##########################
            '   Datas
            '##########################
            '
            'Labels points essais croissants / décroissants
            '

            Dim arrPressions_6bar() As String = {0, 1.2, 2.4, 3.6, 4.8, 6}
            Dim arrPressions_10bar() As String = {0, 2, 4, 6, 8, 10}
            Dim arrPressions_20bar() As String = {0, 4, 8, 12, 16, 20}
            Dim arrPressions_25bar() As String = {0, 5, 10, 15, 20, 25}
            Dim arrPressions_default() As String = {0, 2, 4, 6, 8, 10}

            Dim vPos As Integer = 8
            nTabIndex = 0
            For i As Integer = 1 To nbMesures
                nTabIndex = nTabIndex + 1
                Try

                    Dim tmpPressionsTest() As String
                    Select Case tmpManoControle.fondEchelle
                        Case "6"
                            tmpPressionsTest = arrPressions_6bar
                        Case "10"
                            tmpPressionsTest = arrPressions_10bar
                        Case "20"
                            tmpPressionsTest = arrPressions_20bar
                        Case "25"
                            tmpPressionsTest = arrPressions_25bar
                        Case Else
                            tmpPressionsTest = arrPressions_default
                    End Select

                    ' CROISSANT
                    Dim tmp_croissant_label_pointsEssai As New Label
                    tmp_croissant_label_pointsEssai.Name = "croissant_pointsEssai_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_label_pointsEssai)
                    tmp_croissant_label_pointsEssai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    tmp_croissant_label_pointsEssai.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                    tmp_croissant_label_pointsEssai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    tmp_croissant_label_pointsEssai.Location = New System.Drawing.Point(0, vPos)
                    tmp_croissant_label_pointsEssai.Size = New System.Drawing.Size(89, 16)
                    tmp_croissant_label_pointsEssai.Text = i
                    tmp_croissant_label_pointsEssai.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_label_pointsEssai.Parent = tmpPanelArrayglob_croissant_pointEssai
                    '
                    'Pression : capteur testé
                    '
                    Dim tmp_croissant_pression_capteurTeste As New TextBox
                    tmp_croissant_pression_capteurTeste.Name = "croissant_pression_capteurTeste_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_pression_capteurTeste)
                    tmp_croissant_pression_capteurTeste.Parent = tmpPanelArrayglob_croissant_capteurTeste
                    tmp_croissant_pression_capteurTeste.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_pression_capteurTeste.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_pression_capteurTeste.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    'tmp_croissant_pression_capteurTeste.TabStop = True
                    'tmp_croissant_pression_capteurTeste.TabIndex = nTabIndex + nbMesures
                    'tmp_croissant_pression_capteurTeste.Text = tmpPressionsTest((i - 1))
                    'AddHandler tmp_croissant_pression_capteurTeste.Validated, AddressOf updateResults
                    'AddHandler tmp_croissant_pression_capteurTeste.KeyPress, AddressOf checkKeyPress
                    tmp_croissant_pression_capteurTeste.TabStop = False
                    tmp_croissant_pression_capteurTeste.ReadOnly = True
                    tmp_croissant_pression_capteurTeste.Text = tmpPressionsTest((i - 1))
                    '
                    'Pression : capteur instrument de référence
                    '
                    Dim tmp_croissant_pression_instrumentReference As New TextBox
                    tmp_croissant_pression_instrumentReference.Name = "croissant_pression_instrumentReference_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_pression_instrumentReference)
                    tmp_croissant_pression_instrumentReference.Parent = tmpPanelArrayglob_croissant_instrumentReference
                    tmp_croissant_pression_instrumentReference.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_pression_instrumentReference.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_pression_instrumentReference.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_pression_instrumentReference.TabStop = True
                    tmp_croissant_pression_instrumentReference.TabIndex = nTabIndex
                    AddHandler tmp_croissant_pression_instrumentReference.Validated, AddressOf updateResults
                    AddHandler tmp_croissant_pression_instrumentReference.KeyPress, AddressOf checkKeyPress
                    '
                    'Incertitude
                    '
                    Dim tmp_croissant_incertitude As New TextBox
                    tmp_croissant_incertitude.Name = "croissant_incertitude_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_incertitude)
                    tmp_croissant_incertitude.Parent = tmpPanelArrayglob_croissant_incertitude
                    tmp_croissant_incertitude.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_incertitude.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_incertitude.ReadOnly = True
                    tmp_croissant_incertitude.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_incertitude.TabStop = False
                    '                    AddHandler tmp_croissant_incertitude.Validated, AddressOf updateResults
                    '                   AddHandler tmp_croissant_incertitude.KeyPress, AddressOf checkKeyPress
                    '
                    'EMT
                    '
                    Dim tmp_croissant_EMT As New TextBox
                    tmp_croissant_EMT.Name = "croissant_EMT_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_EMT)
                    tmp_croissant_EMT.Parent = tmpPanelArrayglob_croissant_EMT
                    tmp_croissant_EMT.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_EMT.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_EMT.ReadOnly = True
                    tmp_croissant_EMT.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_EMT.TabStop = False
                    '                  AddHandler tmp_croissant_EMT.TextChanged, AddressOf updateResults
                    '                 AddHandler tmp_croissant_EMT.KeyPress, AddressOf checkKeyPress
                    '
                    'Erreur : Absolue
                    '
                    Dim tmp_croissant_erreur_absolue As New TextBox
                    tmp_croissant_erreur_absolue.Name = "croissant_erreur_absolue_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_erreur_absolue)
                    tmp_croissant_erreur_absolue.Parent = tmpPanelArrayglob_croissant_erreurAbsolue
                    tmp_croissant_erreur_absolue.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_erreur_absolue.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_erreur_absolue.ReadOnly = True
                    tmp_croissant_erreur_absolue.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_erreur_absolue.TabStop = False
                    '
                    'Erreur : Fond Echelle
                    '
                    Dim tmp_croissant_erreur_fondEchelle As New TextBox
                    tmp_croissant_erreur_fondEchelle.Name = "croissant_erreur_fondEchelle_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_erreur_fondEchelle)
                    tmp_croissant_erreur_fondEchelle.Parent = tmpPanelArrayglob_croissant_erreurFondEchelle
                    tmp_croissant_erreur_fondEchelle.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_erreur_fondEchelle.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_erreur_fondEchelle.ReadOnly = True
                    tmp_croissant_erreur_fondEchelle.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_erreur_fondEchelle.TabStop = False

                    ' DECROISSANT
                    Dim tmp_decroissant_label_pointsEssai As New Label
                    tmp_decroissant_label_pointsEssai.Name = "decroissant_pointsEssai_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_label_pointsEssai)
                    tmp_decroissant_label_pointsEssai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    tmp_decroissant_label_pointsEssai.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                    tmp_decroissant_label_pointsEssai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    tmp_decroissant_label_pointsEssai.Location = New System.Drawing.Point(0, vPos)
                    tmp_decroissant_label_pointsEssai.Size = New System.Drawing.Size(89, 16)
                    tmp_decroissant_label_pointsEssai.Text = i
                    tmp_decroissant_label_pointsEssai.Parent = tmpPanelArrayglob_decroissant_pointEssai
                    tmp_decroissant_label_pointsEssai.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    '
                    'Pression : capteur testé
                    '
                    Dim tmp_decroissant_pression_capteurTeste As New TextBox
                    tmp_decroissant_pression_capteurTeste.Name = "decroissant_pression_capteurTeste_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_pression_capteurTeste)
                    tmp_decroissant_pression_capteurTeste.Parent = tmpPanelArrayglob_decroissant_capteurTeste
                    tmp_decroissant_pression_capteurTeste.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_pression_capteurTeste.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_pression_capteurTeste.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    'tmp_decroissant_pression_capteurTeste.Text = (nbMesures - i) * 2
                    tmp_decroissant_pression_capteurTeste.Text = tmpPressionsTest((nbMesures - i))
                    tmp_decroissant_pression_capteurTeste.TabStop = False
                    tmp_decroissant_pression_capteurTeste.ReadOnly = True
                    '
                    'Pression : capteur instrument de référence
                    '
                    Dim tmp_decroissant_pression_instrumentReference As New TextBox
                    tmp_decroissant_pression_instrumentReference.Name = "decroissant_pression_instrumentReference_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_pression_instrumentReference)
                    tmp_decroissant_pression_instrumentReference.Parent = tmpPanelArrayglob_decroissant_instrumentReference
                    tmp_decroissant_pression_instrumentReference.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_pression_instrumentReference.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_pression_instrumentReference.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    AddHandler tmp_decroissant_pression_instrumentReference.Validated, AddressOf updateResults
                    AddHandler tmp_decroissant_pression_instrumentReference.KeyPress, AddressOf checkKeyPress
                    '
                    'Incertitude
                    '
                    Dim tmp_decroissant_incertitude As New TextBox
                    tmp_decroissant_incertitude.Name = "decroissant_incertitude_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_incertitude)
                    tmp_decroissant_incertitude.Parent = tmpPanelArrayglob_decroissant_incertitude
                    tmp_decroissant_incertitude.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_incertitude.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_incertitude.ReadOnly = True
                    tmp_decroissant_incertitude.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_decroissant_incertitude.TabStop = False

                    '                    AddHandler tmp_decroissant_incertitude.TextChanged, AddressOf updateResults
                    '                   AddHandler tmp_decroissant_incertitude.KeyPress, AddressOf checkKeyPress
                    '
                    'EMT
                    '
                    Dim tmp_decroissant_EMT As New TextBox
                    tmp_decroissant_EMT.Name = "decroissant_EMT_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_EMT)
                    tmp_decroissant_EMT.Parent = tmpPanelArrayglob_decroissant_EMT
                    tmp_decroissant_EMT.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_EMT.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_EMT.ReadOnly = True
                    tmp_decroissant_EMT.TabStop = False
                    tmp_decroissant_EMT.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    '                  AddHandler tmp_decroissant_EMT.TextChanged, AddressOf updateResults
                    '                 AddHandler tmp_decroissant_EMT.KeyPress, AddressOf checkKeyPress
                    '
                    'Erreur : Absolue
                    '
                    Dim tmp_decroissant_erreur_absolue As New TextBox
                    tmp_decroissant_erreur_absolue.Name = "decroissant_erreur_absolue_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_erreur_absolue)
                    tmp_decroissant_erreur_absolue.Parent = tmpPanelArrayglob_decroissant_erreurAbsolue
                    tmp_decroissant_erreur_absolue.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_erreur_absolue.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_erreur_absolue.ReadOnly = True
                    tmp_decroissant_erreur_absolue.TabStop = False
                    tmp_decroissant_erreur_absolue.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    '
                    'Erreur : Absolue
                    '
                    Dim tmp_decroissant_erreur_fondEchelle As New TextBox
                    tmp_decroissant_erreur_fondEchelle.Name = "decroissant_erreur_fondEchelle_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_erreur_fondEchelle)
                    tmp_decroissant_erreur_fondEchelle.Parent = tmpPanelArrayglob_decroissant_erreurFondEchelle
                    tmp_decroissant_erreur_fondEchelle.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_erreur_fondEchelle.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_erreur_fondEchelle.ReadOnly = True
                    tmp_decroissant_erreur_fondEchelle.TabStop = False
                    tmp_decroissant_erreur_fondEchelle.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                Catch ex As Exception
                    CSDebug.dispError("Controle Mano - Chargement onglets : " & ex.Message.ToString)
                End Try

                vPos = vPos + 24
            Next i
            '
            'Titre Infos Mano
            '
            Dim tmp_titleInfosMano As New Label
            tmp_titleInfosMano.Name = "label_titleResultat_" & tmpManoControle.numeroNational
            Controls.Add(tmp_titleInfosMano)
            tmp_titleInfosMano.BackColor = System.Drawing.Color.Transparent
            tmp_titleInfosMano.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_titleInfosMano.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
            tmp_titleInfosMano.Image = CType(resources.GetObject("Label37.Image"), System.Drawing.Image)
            tmp_titleInfosMano.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            tmp_titleInfosMano.Location = New System.Drawing.Point(744, 8)
            tmp_titleInfosMano.Size = New System.Drawing.Size(230, 16)
            tmp_titleInfosMano.Text = "      Mano à contrôler"
            tmp_titleInfosMano.Parent = tmpTab
            '
            'Info mano marque
            '
            Dim tmp_libelleInfosMano_marque As New Label
            tmp_libelleInfosMano_marque.Name = "label_libelleInfosMano_marque_" & tmpManoControle.numeroNational
            Controls.Add(tmp_libelleInfosMano_marque)
            tmp_libelleInfosMano_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_libelleInfosMano_marque.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmp_libelleInfosMano_marque.Location = New System.Drawing.Point(736, 48)
            tmp_libelleInfosMano_marque.Size = New System.Drawing.Size(120, 16)
            tmp_libelleInfosMano_marque.TabIndex = 10
            tmp_libelleInfosMano_marque.Text = "Marque :"
            tmp_libelleInfosMano_marque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            tmp_libelleInfosMano_marque.Parent = tmpTab
            '
            'Info mano classe
            '
            Dim tmp_libelleInfosMano_classe As New Label
            tmp_libelleInfosMano_classe.Name = "label_libelleInfosMano_classe_" & tmpManoControle.numeroNational
            Controls.Add(tmp_libelleInfosMano_classe)
            tmp_libelleInfosMano_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_libelleInfosMano_classe.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmp_libelleInfosMano_classe.Location = New System.Drawing.Point(736, 64)
            tmp_libelleInfosMano_classe.Size = New System.Drawing.Size(120, 16)
            tmp_libelleInfosMano_classe.TabIndex = 10
            tmp_libelleInfosMano_classe.Text = "Classe :"
            tmp_libelleInfosMano_classe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            tmp_libelleInfosMano_classe.Parent = tmpTab
            '
            'Info mano fond echelle
            '
            Dim tmp_libelleInfosMano_fondEchelle As New Label
            tmp_libelleInfosMano_fondEchelle.Name = "label_libelleInfosMano_fondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmp_libelleInfosMano_fondEchelle)
            tmp_libelleInfosMano_fondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_libelleInfosMano_fondEchelle.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmp_libelleInfosMano_fondEchelle.Location = New System.Drawing.Point(736, 80)
            tmp_libelleInfosMano_fondEchelle.Size = New System.Drawing.Size(120, 16)
            tmp_libelleInfosMano_fondEchelle.TabIndex = 10
            tmp_libelleInfosMano_fondEchelle.Text = "Fond d'échelle :"
            tmp_libelleInfosMano_fondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            tmp_libelleInfosMano_fondEchelle.Parent = tmpTab
            '
            'Info mano reference
            '
            Dim tmp_libelleInfosMano_reference As New Label
            tmp_libelleInfosMano_reference.Name = "label_libelleInfosMano_reference_" & tmpManoControle.numeroNational
            Controls.Add(tmp_libelleInfosMano_reference)
            tmp_libelleInfosMano_reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_libelleInfosMano_reference.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmp_libelleInfosMano_reference.Location = New System.Drawing.Point(736, 32)
            tmp_libelleInfosMano_reference.Size = New System.Drawing.Size(120, 16)
            tmp_libelleInfosMano_reference.TabIndex = 10
            tmp_libelleInfosMano_reference.Text = "N° identifiant :"
            tmp_libelleInfosMano_reference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            tmp_libelleInfosMano_reference.Parent = tmpTab
            '
            'labelInfo_reference
            '
            Dim tmp_valueInfosMano_reference As New Label
            tmp_valueInfosMano_reference.Name = "label_valueInfosMano_reference_" & tmpManoControle.numeroNational
            Controls.Add(tmp_valueInfosMano_reference)
            tmp_valueInfosMano_reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_valueInfosMano_reference.ForeColor = System.Drawing.Color.Black
            tmp_valueInfosMano_reference.Location = New System.Drawing.Point(856, 32)
            tmp_valueInfosMano_reference.Name = "labelInfo_reference"
            tmp_valueInfosMano_reference.Size = New System.Drawing.Size(104, 16)
            tmp_valueInfosMano_reference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            tmp_valueInfosMano_reference.Parent = tmpTab
            tmp_valueInfosMano_reference.Text = tmpManoControle.idCrodip
            '
            'labelInfo_marque
            '
            Dim tmp_valueInfosMano_marque As New Label
            tmp_valueInfosMano_marque.Name = "label_valueInfosMano_marque_" & tmpManoControle.numeroNational
            Controls.Add(tmp_valueInfosMano_marque)
            tmp_valueInfosMano_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_valueInfosMano_marque.ForeColor = System.Drawing.Color.Black
            tmp_valueInfosMano_marque.Location = New System.Drawing.Point(856, 48)
            tmp_valueInfosMano_marque.Name = "labelInfo_marque"
            tmp_valueInfosMano_marque.Size = New System.Drawing.Size(104, 16)
            tmp_valueInfosMano_marque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            tmp_valueInfosMano_marque.Parent = tmpTab
            tmp_valueInfosMano_marque.Text = tmpManoControle.marque
            '
            'labelInfo_classe
            '
            Dim tmp_valueInfosMano_classe As New Label
            tmp_valueInfosMano_classe.Name = "label_valueInfosMano_classe_" & tmpManoControle.numeroNational
            Controls.Add(tmp_valueInfosMano_classe)
            tmp_valueInfosMano_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_valueInfosMano_classe.ForeColor = System.Drawing.Color.Black
            tmp_valueInfosMano_classe.Location = New System.Drawing.Point(856, 64)
            tmp_valueInfosMano_classe.Name = "labelInfo_classe"
            tmp_valueInfosMano_classe.Size = New System.Drawing.Size(104, 16)
            tmp_valueInfosMano_classe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            tmp_valueInfosMano_classe.Parent = tmpTab
            tmp_valueInfosMano_classe.Text = tmpManoControle.classe
            '
            'labelInfo_fondEchelle
            '
            Dim tmp_valueInfosMano_fondEchelle As New Label
            tmp_valueInfosMano_fondEchelle.Name = "label_valueInfosMano_fondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmp_valueInfosMano_fondEchelle)
            tmp_valueInfosMano_fondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_valueInfosMano_fondEchelle.ForeColor = System.Drawing.Color.Black
            tmp_valueInfosMano_fondEchelle.Location = New System.Drawing.Point(856, 80)
            tmp_valueInfosMano_fondEchelle.Name = "labelInfo_fondEchelle"
            tmp_valueInfosMano_fondEchelle.Size = New System.Drawing.Size(104, 16)
            tmp_valueInfosMano_fondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            tmp_valueInfosMano_fondEchelle.Parent = tmpTab
            tmp_valueInfosMano_fondEchelle.Text = tmpManoControle.fondEchelle
            '
            'Titre Résultat
            '
            Dim tmp_titleResultat As New Label
            tmp_titleResultat.Name = "label_titleResultat_" & tmpManoControle.numeroNational
            Controls.Add(tmp_titleResultat)
            tmp_titleResultat.BackColor = System.Drawing.Color.Transparent
            tmp_titleResultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_titleResultat.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
            tmp_titleResultat.Image = CType(resources.GetObject("Label34.Image"), System.Drawing.Image)
            tmp_titleResultat.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            tmp_titleResultat.Location = New System.Drawing.Point(744, 208)
            tmp_titleResultat.Size = New System.Drawing.Size(160, 16)
            tmp_titleResultat.Text = "     Résultat de l'essai"
            tmp_titleResultat.Parent = tmpTab
            '
            'Résultat
            '
            Dim tmp_resultat As New Label
            tmp_resultat.Name = "label_resultat_" & tmpManoControle.numeroNational
            Controls.Add(tmp_resultat)
            tmp_resultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_resultat.ForeColor = System.Drawing.Color.Green
            tmp_resultat.Location = New System.Drawing.Point(736, 224)
            tmp_resultat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmp_resultat.Size = New System.Drawing.Size(224, 87)
            tmp_resultat.Text = ""
            tmp_resultat.Parent = tmpTab
            '
            'btn_controleManos_valider
            '
            Dim tmp_btnValider As New Label
            tmp_btnValider.Name = "btn_valider_" & tmpManoControle.numeroNational
            Controls.Add(tmp_btnValider)
            tmp_btnValider.Parent = tmpTab
            tmp_btnValider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_btnValider.ForeColor = System.Drawing.Color.White
            tmp_btnValider.Image = CType(resources.GetObject("btn_controleManos_valider.Image"), System.Drawing.Image)
            tmp_btnValider.Location = New System.Drawing.Point(852, 568)
            tmp_btnValider.Size = New System.Drawing.Size(128, 24)
            tmp_btnValider.Text = "    Valider / Quitter"
            tmp_btnValider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmp_btnValider.Enabled = True

            AddHandler tmp_btnValider.Click, AddressOf btn_controleManos_valider_Click
            tmp_btnValider.Enabled = False
            btn_controleManos_suivant.Enabled = False
        Next

        ' Placer la puce sur onglet courant
        prevSelectedManoOnglet = ongletsManos.SelectedTab.TabIndex
        SelectMano()

    End Sub

#Region " Récupération des données du controle "
    Public Function createControleMano(ByVal pMano As ManometreControle, pidManoEtalon As String) As ControleMano

        Dim oCtrlMano As ControleMano = New ControleMano
        '        newObject.id = ControleManoManager.create(pagent)
        '########################################################

        oCtrlMano.idStructure = pMano.idStructure
        oCtrlMano.idMano = pMano.numeroNational
        oCtrlMano.manoEtalon = pidManoEtalon
        oCtrlMano.tempAir = TextBox41.Text
        oCtrlMano.resultat = pMano.etat
        oCtrlMano.DateVerif = CSDate.ToCRODIPString(Date.Now).ToString
        '# Mesures Croissantes
        ' Mesure n°1
        Dim input_up_pt1_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_pres_manoCtrl = input_up_pt1_pres_manoCtrl.Text
        Dim input_up_pt1_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_pres_manoEtalon = input_up_pt1_pres_manoEtalon.Text
        Dim input_up_pt1_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_incertitude = input_up_pt1_incertitude.Text
        Dim input_up_pt1_EMT As TextBox = CSForm.getControlByName("croissant_EMT_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_EMT = input_up_pt1_EMT.Text
        Dim input_up_pt1_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_err_abs = input_up_pt1_err_abs.Text
        Dim input_up_pt1_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_err_fondEchelle = input_up_pt1_err_fondEchelle.Text
        oCtrlMano.up_pt1_conformite = "1"
        If input_up_pt1_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt1_conformite = "0"
        End If
        ' Mesure n°2
        Dim input_up_pt2_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_pres_manoCtrl = input_up_pt2_pres_manoCtrl.Text
        Dim input_up_pt2_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_pres_manoEtalon = input_up_pt2_pres_manoEtalon.Text
        Dim input_up_pt2_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_incertitude = input_up_pt2_incertitude.Text
        Dim input_up_pt2_EMT As TextBox = CSForm.getControlByName("croissant_EMT_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_EMT = input_up_pt2_EMT.Text
        Dim input_up_pt2_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_err_abs = input_up_pt2_err_abs.Text
        Dim input_up_pt2_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_err_fondEchelle = input_up_pt2_err_fondEchelle.Text
        oCtrlMano.up_pt2_conformite = "1"
        If input_up_pt2_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt2_conformite = "0"
        End If
        ' Mesure n°3
        Dim input_up_pt3_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_pres_manoCtrl = input_up_pt3_pres_manoCtrl.Text
        Dim input_up_pt3_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_pres_manoEtalon = input_up_pt3_pres_manoEtalon.Text
        Dim input_up_pt3_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_incertitude = input_up_pt3_incertitude.Text
        Dim input_up_pt3_EMT As TextBox = CSForm.getControlByName("croissant_EMT_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_EMT = input_up_pt3_EMT.Text
        Dim input_up_pt3_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_err_abs = input_up_pt3_err_abs.Text
        Dim input_up_pt3_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_err_fondEchelle = input_up_pt3_err_fondEchelle.Text
        oCtrlMano.up_pt3_conformite = "1"
        If input_up_pt3_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt3_conformite = "0"
        End If
        ' Mesure n°4
        Dim input_up_pt4_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_pres_manoCtrl = input_up_pt4_pres_manoCtrl.Text
        Dim input_up_pt4_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_pres_manoEtalon = input_up_pt4_pres_manoEtalon.Text
        Dim input_up_pt4_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_incertitude = input_up_pt4_incertitude.Text
        Dim input_up_pt4_EMT As TextBox = CSForm.getControlByName("croissant_EMT_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_EMT = input_up_pt4_EMT.Text
        Dim input_up_pt4_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_err_abs = input_up_pt4_err_abs.Text
        Dim input_up_pt4_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_err_fondEchelle = input_up_pt4_err_fondEchelle.Text
        oCtrlMano.up_pt4_conformite = "1"
        If input_up_pt4_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt4_conformite = "0"
        End If
        ' Mesure n°5
        Dim input_up_pt5_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_pres_manoCtrl = input_up_pt5_pres_manoCtrl.Text
        Dim input_up_pt5_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_pres_manoEtalon = input_up_pt5_pres_manoEtalon.Text
        Dim input_up_pt5_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_incertitude = input_up_pt5_incertitude.Text
        Dim input_up_pt5_EMT As TextBox = CSForm.getControlByName("croissant_EMT_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_EMT = input_up_pt5_EMT.Text
        Dim input_up_pt5_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_err_abs = input_up_pt5_err_abs.Text
        Dim input_up_pt5_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_err_fondEchelle = input_up_pt5_err_fondEchelle.Text
        oCtrlMano.up_pt5_conformite = "1"
        If input_up_pt5_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt5_conformite = "0"
        End If
        ' Mesure n°6
        Dim input_up_pt6_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_pres_manoCtrl = input_up_pt6_pres_manoCtrl.Text
        Dim input_up_pt6_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_pres_manoEtalon = input_up_pt6_pres_manoEtalon.Text
        Dim input_up_pt6_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_incertitude = input_up_pt6_incertitude.Text
        Dim input_up_pt6_EMT As TextBox = CSForm.getControlByName("croissant_EMT_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_EMT = input_up_pt6_EMT.Text
        Dim input_up_pt6_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_err_abs = input_up_pt6_err_abs.Text
        Dim input_up_pt6_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_err_fondEchelle = input_up_pt6_err_fondEchelle.Text
        oCtrlMano.up_pt6_conformite = "1"
        If input_up_pt6_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt6_conformite = "0"
        End If

        '# Mesures Décroissantes
        ' Mesure n°1
        Dim input_down_pt1_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_pres_manoCtrl = input_down_pt1_pres_manoCtrl.Text
        Dim input_down_pt1_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_pres_manoEtalon = input_down_pt1_pres_manoEtalon.Text
        Dim input_down_pt1_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_incertitude = input_down_pt1_incertitude.Text
        Dim input_down_pt1_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_EMT = input_down_pt1_EMT.Text
        Dim input_down_pt1_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_err_abs = input_down_pt1_err_abs.Text
        Dim input_down_pt1_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_err_fondEchelle = input_down_pt1_err_fondEchelle.Text
        oCtrlMano.down_pt1_conformite = "1"
        If input_down_pt1_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt1_conformite = "0"
        End If
        ' Mesure n°2
        Dim input_down_pt2_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_pres_manoCtrl = input_down_pt2_pres_manoCtrl.Text
        Dim input_down_pt2_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_pres_manoEtalon = input_down_pt2_pres_manoEtalon.Text
        Dim input_down_pt2_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_incertitude = input_down_pt2_incertitude.Text
        Dim input_down_pt2_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_EMT = input_down_pt2_EMT.Text
        Dim input_down_pt2_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_err_abs = input_down_pt2_err_abs.Text
        Dim input_down_pt2_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_err_fondEchelle = input_down_pt2_err_fondEchelle.Text
        oCtrlMano.down_pt2_conformite = "1"
        If input_down_pt2_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt2_conformite = "0"
        End If
        ' Mesure n°3
        Dim input_down_pt3_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_pres_manoCtrl = input_down_pt3_pres_manoCtrl.Text
        Dim input_down_pt3_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_pres_manoEtalon = input_down_pt3_pres_manoEtalon.Text
        Dim input_down_pt3_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_incertitude = input_down_pt3_incertitude.Text
        Dim input_down_pt3_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_EMT = input_down_pt3_EMT.Text
        Dim input_down_pt3_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_err_abs = input_down_pt3_err_abs.Text
        Dim input_down_pt3_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_err_fondEchelle = input_down_pt3_err_fondEchelle.Text
        oCtrlMano.down_pt3_conformite = "1"
        If input_down_pt3_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt3_conformite = "0"
        End If
        ' Mesure n°4
        Dim input_down_pt4_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_pres_manoCtrl = input_down_pt4_pres_manoCtrl.Text
        Dim input_down_pt4_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_pres_manoEtalon = input_down_pt4_pres_manoEtalon.Text
        Dim input_down_pt4_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_incertitude = input_down_pt4_incertitude.Text
        Dim input_down_pt4_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_EMT = input_down_pt4_EMT.Text
        Dim input_down_pt4_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_err_abs = input_down_pt4_err_abs.Text
        Dim input_down_pt4_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_err_fondEchelle = input_down_pt4_err_fondEchelle.Text
        oCtrlMano.down_pt4_conformite = "1"
        If input_down_pt4_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt4_conformite = "0"
        End If
        ' Mesure n°5
        Dim input_down_pt5_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_pres_manoCtrl = input_down_pt5_pres_manoCtrl.Text
        Dim input_down_pt5_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_pres_manoEtalon = input_down_pt5_pres_manoEtalon.Text
        Dim input_down_pt5_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_incertitude = input_down_pt5_incertitude.Text
        Dim input_down_pt5_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_EMT = input_down_pt5_EMT.Text
        Dim input_down_pt5_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_err_abs = input_down_pt5_err_abs.Text
        Dim input_down_pt5_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_err_fondEchelle = input_down_pt5_err_fondEchelle.Text
        oCtrlMano.down_pt5_conformite = "1"
        If input_down_pt5_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt5_conformite = "0"
        End If
        ' Mesure n°6
        Dim input_down_pt6_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_pres_manoCtrl = input_down_pt6_pres_manoCtrl.Text
        Dim input_down_pt6_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_pres_manoEtalon = input_down_pt6_pres_manoEtalon.Text
        Dim input_down_pt6_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_incertitude = input_down_pt6_incertitude.Text
        Dim input_down_pt6_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_EMT = input_down_pt6_EMT.Text
        Dim input_down_pt6_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_err_abs = input_down_pt6_err_abs.Text
        Dim input_down_pt6_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_err_fondEchelle = input_down_pt6_err_fondEchelle.Text
        oCtrlMano.down_pt6_conformite = "1"
        If input_down_pt6_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt6_conformite = "0"
        End If

        '########################################################
        Dim tmpTab As TabPage = CSForm.getControlByName("tabPage_mano_" & curManoControle.numeroNational, ongletsManos)
        For i As Integer = 1 To nbMesures
            ' On récupère les controles
            Dim tmp_pression_capteurTeste As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_" & i & "_" & curManoControle.numeroNational, tmpTab)
            Dim tmp_pression_instrumentReference As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curManoControle.numeroNational, tmpTab)
            oCtrlMano.PressionControle = oCtrlMano.PressionControle & "|" & tmp_pression_instrumentReference.Text
            oCtrlMano.ValeursMesurees = oCtrlMano.ValeursMesurees & "|" & tmp_pression_capteurTeste.Text
        Next

        Return oCtrlMano

    End Function
#End Region

#Region " Calculs "

    ' Test si le mano est fiable
    Public Function checkMano(ByVal curMano As ManometreControle) As Boolean
        ' Init
        Dim nbMesures = 6
        Dim maxEcart As Double = 0

        ' 
        Dim isFiable As Boolean = True
        Dim isSaisieComplete As Boolean = True

        ' On récupère la classe de précision du mano courant
        'Dim tmpClassePrecision As Double
        'tmpClassePrecision = StringToDouble(curMano.classe)

        ' On récupère l'écart maximum
        For i As Integer = 1 To nbMesures
            Try
                Dim tmpInputCroissantIntrumentReference As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputDecroissantIntrumentReference As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputCroissant As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputDecroissant As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputErreurAbsolueCroissant As TextBox = CSForm.getControlByName("croissant_erreur_absolue_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputErreurAbsolueDecroissant As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputIncetitudeCroissant As TextBox = CSForm.getControlByName("croissant_incertitude_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputIncetitudeDecroissant As TextBox = CSForm.getControlByName("decroissant_incertitude_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputEmtCroissant As TextBox = CSForm.getControlByName("croissant_EMT_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputEmtDecroissant As TextBox = CSForm.getControlByName("decroissant_EMT_" & i & "_" & curMano.numeroNational, Me)

                Dim tmpValueCroissant As Double = 0.0
                Dim tmpValueDecroissant As Double = 0.0
                Dim tmpValueIncetitudeCroissant As Double = 0.0
                Dim tmpValueIncetitudeDecroissant As Double = 0.0
                Dim tmpValueEmtCroissant As Double = 0.0
                Dim tmpValueEmtDecroissant As Double = 0.0
                tmpValueCroissant = StringToDouble(tmpInputCroissant.Text)
                tmpValueDecroissant = StringToDouble(tmpInputDecroissant.Text)
                tmpValueIncetitudeCroissant = StringToDouble(tmpInputIncetitudeCroissant.Text)
                tmpValueIncetitudeDecroissant = StringToDouble(tmpInputIncetitudeDecroissant.Text)
                tmpValueEmtCroissant = StringToDouble(tmpInputEmtCroissant.Text)
                tmpValueEmtDecroissant = StringToDouble(tmpInputEmtDecroissant.Text)

                '##############################################################################################
                'If tmpValueCroissant > maxEcart Then
                '    maxEcart = tmpValueCroissant
                '    If tmpValueCroissant <= tmpClassePrecision Then
                '        tmpInputCroissant.ForeColor = System.Drawing.Color.Green
                '        tmpInputErreurAbsolueCroissant.ForeColor = System.Drawing.Color.Green
                '    Else
                '        tmpInputCroissant.ForeColor = System.Drawing.Color.Red
                '        tmpInputErreurAbsolueCroissant.ForeColor = System.Drawing.Color.Red
                '    End If
                'End If

                'If tmpValueDecroissant > maxEcart Then
                '    maxEcart = tmpValueDecroissant
                '    If tmpValueDecroissant <= tmpClassePrecision Then
                '        tmpInputDecroissant.ForeColor = System.Drawing.Color.Green
                '        tmpInputErreurAbsolueDecroissant.ForeColor = System.Drawing.Color.Green
                '    Else
                '        tmpInputDecroissant.ForeColor = System.Drawing.Color.Red
                '        tmpInputErreurAbsolueDecroissant.ForeColor = System.Drawing.Color.Red
                '    End If
                'End If
                '##############################################################################################

                '28/08/12 MCO Changement de mode de cacul
                'on compare l'ecart absolu avec l'EMT (Ecart Maximum toléré) sans prendre en compte l'incertitude
                ' Croissant
                If Not String.IsNullOrEmpty(tmpInputErreurAbsolueCroissant.Text) Then
                    If Math.Abs(StringToDouble(tmpInputErreurAbsolueCroissant.Text)) <= tmpValueEmtCroissant Then
                        tmpInputCroissant.ForeColor = System.Drawing.Color.Green
                        tmpInputErreurAbsolueCroissant.ForeColor = System.Drawing.Color.Green
                        tmpInputCroissantIntrumentReference.ForeColor = System.Drawing.Color.Green
                    Else
                        isFiable = False
                        tmpInputCroissant.ForeColor = System.Drawing.Color.Red
                        tmpInputErreurAbsolueCroissant.ForeColor = System.Drawing.Color.Red
                        tmpInputCroissantIntrumentReference.ForeColor = System.Drawing.Color.Red
                    End If
                Else
                    isSaisieComplete = False
                End If

                ' Decroissant
                If Not String.IsNullOrEmpty(tmpInputErreurAbsolueDecroissant.Text) Then
                    If Math.Abs(StringToDouble(tmpInputErreurAbsolueDecroissant.Text)) <= tmpValueEmtDecroissant Then
                        tmpInputDecroissant.ForeColor = System.Drawing.Color.Green
                        tmpInputErreurAbsolueDecroissant.ForeColor = System.Drawing.Color.Green
                        tmpInputDecroissantIntrumentReference.ForeColor = System.Drawing.Color.Green
                    Else
                        isFiable = False
                        tmpInputDecroissant.ForeColor = System.Drawing.Color.Red
                        tmpInputErreurAbsolueDecroissant.ForeColor = System.Drawing.Color.Red
                        tmpInputDecroissantIntrumentReference.ForeColor = System.Drawing.Color.Red
                    End If
                Else
                    isSaisieComplete = False

                End If

                '##############################################################################################

            Catch ex As Exception
                CSDebug.dispError("controle_manomtres::checkMano(" & curMano.numeroNational & ") : " & ex.Message.ToString)
                Return False
            End Try
        Next

        '

        ' NEW
        Return isFiable

        ' On vérifie la fiabilité
        'If maxEcart <= tmpClassePrecision Then
        ' Return True
        ' Else
        'Return False
        'End If

    End Function

    Public Function isSaisieComplete(ByVal curMano As ManometreControle) As Boolean
        ' Init
        Dim nbMesures = 6
        Dim bisSaisieComplete As Boolean = True


        ' On récupère l'écart maximum
        For i As Integer = 1 To nbMesures
            Try
                Dim tmpInputCroissant As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputDecroissant As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)

                ' Croissant
                If String.IsNullOrEmpty(tmpInputCroissant.Text) Then
                    bisSaisieComplete = False
                End If

                ' Decroissant
                If String.IsNullOrEmpty(tmpInputDecroissant.Text) Then
                    bisSaisieComplete = False
                End If

                '##############################################################################################

            Catch ex As Exception
                CSDebug.dispError("controle_manomtres::isSaisieComplete() : " & ex.Message.ToString)
                Return False
            End Try
        Next

        '

        ' NEW
        Return bisSaisieComplete

    End Function
    Public Function isSaisieCommencee(ByVal curMano As ManometreControle) As Boolean
        ' Init
        Dim nbMesures = 6
        Dim bisSaisieCommence As Boolean = True
        Dim bbSaisie As Integer = 0

        ' On récupère l'écart maximum
        For i As Integer = 1 To nbMesures
            Try
                Dim tmpInputCroissant As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputDecroissant As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)

                ' Croissant
                If Not String.IsNullOrEmpty(tmpInputCroissant.Text) Then
                    bbSaisie = bbSaisie + 1
                End If

                ' Decroissant
                If Not String.IsNullOrEmpty(tmpInputDecroissant.Text) Then
                    bbSaisie = bbSaisie + 1
                End If

                bisSaisieCommence = bbSaisie > 0
                '##############################################################################################

            Catch ex As Exception
                CSDebug.dispError("controle_manomtres::isSaisieCommence() : " & ex.Message.ToString)
                bisSaisieCommence = True
            End Try
        Next

        Return bisSaisieCommence

    End Function
#End Region


#Region " Boutons "

    ' Fonction de validation du contrôle
    Private Function validControl() As Boolean
        Dim bReturn As Boolean
        Try

            'On met a jour le mano
            curManoControle.etat = checkMano(curManoControle)
            curManoControle.dateDernierControle = CSDate.ToCRODIPString(Date.Now).ToString
            curManoControle.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            ManometreControleManager.save(curManoControle)


            ' On enregistre les mesures
            Dim oControleMano As ControleMano
            oControleMano = Me.createControleMano(curManoControle, list_manometresEtalon.SelectedItem.id)

            ' On construit notre nouvelle fiche de vie
            curManoControle.creerfFicheVieControle(agentCourant, oControleMano)





            ' Message de confirmation
            Dim tmpMessageConfirm As String
            If curManoControle.etat Then
                tmpMessageConfirm = "Votre manomètre est fiable : il répond à sa classe de précision."
            Else
                tmpMessageConfirm = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
            End If

            ' On flag le mano etalon comme etant utilise
            ' On récupère le mano
            Dim tmpManometreEtalon As ManometreEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational(list_manometresEtalon.SelectedItem.Id)
            ' On le flag
            ManometreEtalonManager.setUtilise(agentCourant, tmpManometreEtalon)


            MsgBox(tmpMessageConfirm)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("controle_manometres::validControl : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Bouton "Suivant"
    Private Sub btn_controleManos_suivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleManos_suivant.Click
        If TextBox41.Text <> "" Then
            validControl()
            ongletsManos.SelectedIndex = ongletsManos.SelectedIndex() + 1
        Else
            MsgBox("Veuillez remplir le champ température pour continuer", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
        End If
    End Sub

    ' Bouton "Valider"
    Private Sub btn_controleManos_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleManos_valider.Click
        If TextBox41.Text <> "" Then
            validControl()
            TryCast(MdiParent, parentContener).ReturnToAccueil()
        Else
            MsgBox("Veuillez remplir le champ température pour continuer", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
        End If
    End Sub

    ' Bouton "Annuler"
    Private Sub btn_controleBanc_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleBanc_annuler.Click
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

#End Region

#Region " Events "

    ' Selection du manometre étalon
    Private Sub list_manometresEtalon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list_manometresEtalon.SelectedIndexChanged
        Try
            ' On commence par récupérer le mano sélectionné
            Dim manoEtalon As New ManometreEtalon
            manoEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational(sender.SelectedItem.Id)
            Me.curManoEtalon = manoEtalon

            labelInfoEtalon_reference.Text = manoEtalon.idCrodip
            labelInfoEtalon_marque.Text = manoEtalon.marque
            labelInfoEtalon_classe.Text = manoEtalon.classe
            labelInfoEtalon_fondEchelle.Text = manoEtalon.fondEchelle
            ongletsManos.Enabled = True
        Catch ex As Exception
            CSDebug.dispError("Select Mano Etalon : " & ex.Message.ToString)
        End Try
    End Sub

    ' Calcul au chagement de contenu
    Private Sub updateResults(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim thisMano As ManometreControle
        Try
            ' Init
            Dim thisInput As TextBox = sender
            Dim tmpTagsValues As String() = thisInput.Tag.ToString.Split("|")
            Dim thisType As String = CType(tmpTagsValues(0), String)
            Dim thisNum As Integer = CType(tmpTagsValues(1), Integer)
            Dim thisManoNum As String = CType(tmpTagsValues(2), String)

            thisMano = ManometreControleManager.getManometreControleByNumeroNational(thisManoNum)

            ' On récupère les inputs
            Dim inputCapteurTeste As TextBox = CSForm.getControlByName(thisType & "_pression_capteurTeste_" & thisNum & "_" & thisManoNum, Me)
            Dim inputInstrumentReference As TextBox = CSForm.getControlByName(thisType & "_pression_instrumentReference_" & thisNum & "_" & thisManoNum, Me)
            Dim inputIncertitude As TextBox = CSForm.getControlByName(thisType & "_incertitude_" & thisNum & "_" & thisManoNum, Me)
            Dim inputEMT As TextBox = CSForm.getControlByName(thisType & "_EMT_" & thisNum & "_" & thisManoNum, Me)
            Dim inputErrAbsolue As TextBox = CSForm.getControlByName(thisType & "_erreur_absolue_" & thisNum & "_" & thisManoNum, Me)
            Dim inputErrFondEchelle As TextBox = CSForm.getControlByName(thisType & "_erreur_fondEchelle_" & thisNum & "_" & thisManoNum, Me)
            Dim BtnValider As Label = CSForm.getControlByName("btn_valider_" & thisMano.numeroNational, Me)

            Dim valueCapteurTeste As Double
            Dim valueInstrumentReference As Double
            Dim valueManoEtalon_fondEchelle As Double
            Dim valueMano_fondEchelle As Double
            Dim valueIncertitude As Double
            '            Dim valueEmt As Double
            Dim bCalc As Boolean
            Dim bCheck As Boolean
            Dim btnName


            If String.IsNullOrEmpty(inputCapteurTeste.Text) Or String.IsNullOrEmpty(inputInstrumentReference.Text) Then
                bCalc = False
            Else
                bCalc = True
            End If
            If bCalc Then

                ' On récupère les valeurs
                valueCapteurTeste = StringToDouble(inputCapteurTeste.Text)
                valueInstrumentReference = StringToDouble(inputInstrumentReference.Text)
                valueManoEtalon_fondEchelle = StringToDouble(labelInfoEtalon_fondEchelle.Text)
                valueMano_fondEchelle = StringToDouble(thisMano.fondEchelle)


                ' Incertitude
                valueIncertitude = 0
                If thisMano.resolution <> "" And curManoEtalon.incertitudeEtalon <> "" Then
                    valueIncertitude = calcIncertitude(thisMano.resolution_d, curManoEtalon.incertitudeEtalon_d)
                End If
                inputIncertitude.Text = valueIncertitude.ToString()

                ' EMT
                inputEMT.Text = calcEMT(thisMano)

                ' Calcul err absolue
                inputErrAbsolue.Text = Math.Round(Math.Abs(valueCapteurTeste - valueInstrumentReference), 3)
                inputErrFondEchelle.Text = Math.Round(Math.Abs(Math.Abs(valueCapteurTeste - valueInstrumentReference)) * 100 / valueMano_fondEchelle, 3)
            End If


            Dim tmpLabelResult As Label = CSForm.getControlByName("label_resultat_" & thisMano.numeroNational, Me)

            bCheck = checkMano(thisMano)
            If (isSaisieComplete(thisMano)) Then
                If bCheck Then
                    tmpLabelResult.Text = "Votre manomètre est fiable : il répond à sa classe de précision."
                    tmpLabelResult.ForeColor = System.Drawing.Color.Green
                Else
                    tmpLabelResult.Text = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
                    tmpLabelResult.ForeColor = System.Drawing.Color.Red
                End If
                btn_controleManos_suivant.Enabled = True
                BtnValider.Enabled = True
            Else
                tmpLabelResult.Text = ""
                btn_controleManos_suivant.Enabled = False
                BtnValider.Enabled = False
            End If
        Catch ex As Exception
            CSDebug.dispError("Controle Manomètre :: updateResults(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Function calcIncertitude(pResolution As Double, pIncertitudeEtalon As Double) As Double
        Dim dReturn As Double
        Try

            dReturn = CDbl(Math.Round(2 * Math.Sqrt((pResolution / (2 * Math.Sqrt(3))) ^ 2 + (pIncertitudeEtalon / 2) ^ 2), 2))
        Catch ex As Exception
            dReturn = 0
        End Try

        Return dReturn
    End Function
    Private Function calcEMT(pMano As ManometreControle) As Double
        '''TODO : Mettre cette méthode dans la classe ManomètreControle
        Dim dReturn As Double
        Select Case pMano.fondEchelle
            Case "6"
                dReturn = 0.1
            Case "10"
                dReturn = 0.1
            Case "20"
                dReturn = 0.2
            Case "25"
                dReturn = 0.25
            Case Else
                dReturn = CDbl(Math.Round((StringToDouble(pMano.classe) * StringToDouble(pMano.fondEchelle) / 100), 2))
        End Select

        Return dReturn

    End Function
    Private Sub checkKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub

    ' Changement d'onglet
    Private Sub ongletsManos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ongletsManos.SelectedIndexChanged
        ' Placer la puce sur onglet courant
        Dim sMano As String
        Dim oMano As ManometreControle
        Try
            'Si on avait pas de précédent
            If prevSelectedManoOnglet <> -1 Then
                If ongletsManos.SelectedIndex = prevSelectedManoOnglet Then
                    'L'actuel est égal au précédent (Surement un refus de chabgement car pas complet)
                    'on ne fait rien
                Else
                    'on teste si le mano précédent était complet
                    'If isSaisieComplete(curManoControle) Or Not isSaisieCommencee(curManoControle) Then
                    'On change d'onglet
                    ongletsManos.TabPages(prevSelectedManoOnglet).ImageIndex = -1
                    prevSelectedManoOnglet = ongletsManos.SelectedTab.TabIndex
                    btn_controleManos_suivant.Enabled = False
                    'Else
                    'on revient sur le précédent
                    'ongletsManos.SelectedIndex = prevSelectedManoOnglet

                    'End If
                End If

                SelectMano()
            End If


        Catch ex As Exception
            CSDebug.dispError("Puce onglet : " & ex.Message.ToString & " prevSelectedManoOnglet: " & prevSelectedManoOnglet)
        End Try
    End Sub
    Private Sub SelectMano()
        'On Positionne la puce
        ongletsManos.SelectedTab.ImageIndex = 0
        'On Met en mano come courant
        curManoControle = ManometreControleManager.getManometreControleByNumeroNational(ongletsManos.SelectedTab.Name.Replace("tabPage_mano_", ""))

    End Sub

#End Region

#Region " Acquisition des données "
    ' Bouton acquisitin des données
    Private Sub btn_controleManos_acquiring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleManos_acquiring.Click
        Panel_loading.Visible = True
        doAcqiring()
    End Sub

    Private _thread_doAcqiring As Thread
    Private Sub thr_doAcqiring()

        Dim curMano As ManometreControle
        curMano = ManometreControleManager.getManometreControleByNumeroNational(ongletsManos.SelectedTab.Name.Replace("tabPage_mano_", ""))
        Dim nbBusesAcquis As Integer = AcquiringManager.getNbBuses(2)
        Dim isok As Boolean = (Me.nbMesures = nbBusesAcquis)
        If isok Then
            ' On récupère les buses de la table d'échange
            Dim arrBuses() As Acquiring = AcquiringManager.GetAcquiring()
            Dim prevIdNiveau As Integer = 0
            Dim curIdBuse As Integer = 0
            For Each tmpResponse As Acquiring In arrBuses
                Try
                    If tmpResponse.idBuse <> 0 Then
                        ' On injecte les valeurs
                        Try

                            Dim x As Control

                            If tmpResponse.idNiveau = 1 Then ' Croissante
                                x = CSForm.getControlByName("croissant_pression_instrumentReference_" & tmpResponse.idBuse & "_" & curMano.numeroNational, ongletsManos)
                            Else ' Decroissante
                                Dim tmpId As Integer = tmpResponse.idBuse - Me.nbMesures
                                x = CSForm.getControlByName("decroissant_pression_instrumentReference_" & tmpId & "_" & curMano.numeroNational, ongletsManos)
                            End If

                            x.Text = tmpResponse.debit.ToString

                        Catch ex As Exception
                            CSDebug.dispError("[x0C0004] : " & ex.Message)
                        End Try
                    End If
                Catch ex As Exception
                    CSDebug.dispError("[x0C0003] : " & ex.Message.ToString)
                End Try
            Next
            ' On vide la table d'échange
            'AcquiringManager.clearResults()
        Else
            MsgBox("Le nombre de buses acquises est différent du nombre de mesures nécéssaires. Veuillez vérifiez.")
        End If

        Panel_loading.Visible = False
    End Sub

    Public Function doAcqiring()
        _thread_doAcqiring = New Thread(AddressOf thr_doAcqiring) 'ThrFunc est la fonction exécutée par le thread.
        _thread_doAcqiring.Name = "thr_doAcqiring" 'Il est parfois pratique de nommer les threads surtout si on en créé plusieurs.
        _thread_doAcqiring.Start() ' Démarrage du thread.
    End Function

#End Region

    Private Sub ongletsManos_Click(sender As System.Object, e As System.EventArgs) Handles ongletsManos.Click
        Console.WriteLine("OngletMano.click")
    End Sub
End Class
