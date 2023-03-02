Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading
Imports CRODIPAcquisition
Imports CRODIP_ControlLibrary

''' <summary>
''' Fenêtre de controle des manomètres
''' </summary>
''' <remarks></remarks>
Public Class frmControleManometresNew

    Inherits frmCRODIP

    Private m_oAgent As Agent
    Friend WithEvents m_bsControle As System.Windows.Forms.BindingSource
    Friend WithEvents dtpDateControle As DateTimePicker
    Friend WithEvents Label39 As Label
    Private arrPressions() As String
    Friend WithEvents tbTemperature As TextBox
    Friend WithEvents Label9 As Label
    Private dateVerif As Date
    Friend WithEvents lbMano As ListBox
    Friend WithEvents tlpGlobal As TableLayoutPanel
    Friend WithEvents tlpEntete As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_controleManos_acquiring As PictureBox
    Friend WithEvents tlpRepetition As TableLayoutPanel
    Friend WithEvents tlpPressionDecroissante As TableLayoutPanel
    Friend WithEvents tlpPressionCroissant As TableLayoutPanel
    Friend WithEvents Label46 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label26 As Label
    Private IsOK As Boolean = False


    Public Sub New(pAgent As Agent)
        Me.New()
        m_oAgent = pAgent
    End Sub

#Region " Code généré par le Concepteur Windows Form "

    Private Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        dateVerif = Date.Now
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Panel64 As System.Windows.Forms.Panel
    Friend WithEvents cbx_manometresEtalon As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ImageList_onglets As System.Windows.Forms.ImageList
    Friend WithEvents btn_controleBanc_annuler As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel_loading As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents m_bsManoEtalon As System.Windows.Forms.BindingSource
    Friend WithEvents labelInfo_reference As System.Windows.Forms.Label
    Friend WithEvents labelInfo_marque As System.Windows.Forms.Label
    Friend WithEvents labelInfo_classe As System.Windows.Forms.Label
    Friend WithEvents labelInfo_fondEchelle As System.Windows.Forms.Label
    Friend WithEvents labelInfoEtalon_classe As System.Windows.Forms.Label
    Friend WithEvents labelInfoEtalon_fondEchelle As System.Windows.Forms.Label
    Friend WithEvents labelInfoEtalon_marque As System.Windows.Forms.Label
    Friend WithEvents labelInfoEtalon_reference As System.Windows.Forms.Label
    Friend WithEvents lblResultat As System.Windows.Forms.Label
    Friend WithEvents btn_controleManos_valider As System.Windows.Forms.Label
    Friend WithEvents btn_controleManos_suivant As System.Windows.Forms.Label
    Friend WithEvents m_bsManoControle As System.Windows.Forms.BindingSource
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControleManometresNew))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbx_manometresEtalon = New System.Windows.Forms.ComboBox()
        Me.m_bsManoEtalon = New System.Windows.Forms.BindingSource(Me.components)
        Me.m_bsControle = New System.Windows.Forms.BindingSource(Me.components)
        Me.m_bsManoControle = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Panel64 = New System.Windows.Forms.Panel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dtpDateControle = New System.Windows.Forms.DateTimePicker()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.btn_controleManos_valider = New System.Windows.Forms.Label()
        Me.btn_controleManos_suivant = New System.Windows.Forms.Label()
        Me.lblResultat = New System.Windows.Forms.Label()
        Me.labelInfoEtalon_classe = New System.Windows.Forms.Label()
        Me.labelInfoEtalon_fondEchelle = New System.Windows.Forms.Label()
        Me.labelInfoEtalon_marque = New System.Windows.Forms.Label()
        Me.labelInfoEtalon_reference = New System.Windows.Forms.Label()
        Me.labelInfo_reference = New System.Windows.Forms.Label()
        Me.labelInfo_marque = New System.Windows.Forms.Label()
        Me.labelInfo_classe = New System.Windows.Forms.Label()
        Me.labelInfo_fondEchelle = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lbMano = New System.Windows.Forms.ListBox()
        Me.tlpGlobal = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpEntete = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_controleManos_acquiring = New System.Windows.Forms.PictureBox()
        Me.tlpPressionCroissant = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpPressionDecroissante = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpRepetition = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel_loading = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btn_controleBanc_annuler = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbTemperature = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ImageList_onglets = New System.Windows.Forms.ImageList(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        CType(Me.m_bsManoEtalon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsControle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsManoControle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel64.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tlpGlobal.SuspendLayout()
        Me.tlpEntete.SuspendLayout()
        CType(Me.btn_controleManos_acquiring, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpPressionCroissant.SuspendLayout()
        Me.tlpPressionDecroissante.SuspendLayout()
        Me.tlpRepetition.SuspendLayout()
        Me.Panel_loading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(475, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Manomètre de référence :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cbx_manometresEtalon
        '
        Me.cbx_manometresEtalon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbx_manometresEtalon.DataSource = Me.m_bsManoEtalon
        Me.cbx_manometresEtalon.DisplayMember = "idCrodip"
        Me.cbx_manometresEtalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_manometresEtalon.ItemHeight = 13
        Me.cbx_manometresEtalon.Location = New System.Drawing.Point(641, 4)
        Me.cbx_manometresEtalon.Name = "cbx_manometresEtalon"
        Me.cbx_manometresEtalon.Size = New System.Drawing.Size(144, 21)
        Me.cbx_manometresEtalon.TabIndex = 1
        Me.cbx_manometresEtalon.ValueMember = "idCrodip"
        '
        'm_bsManoEtalon
        '
        Me.m_bsManoEtalon.DataSource = GetType(Crodip_agent.ManometreEtalon)
        '
        'm_bsControle
        '
        Me.m_bsControle.DataMember = "controle"
        Me.m_bsControle.DataSource = Me.m_bsManoControle
        '
        'm_bsManoControle
        '
        Me.m_bsManoControle.DataSource = GetType(Crodip_agent.ManometreControle)
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
        Me.Panel64.Controls.Add(Me.Label46)
        Me.Panel64.Controls.Add(Me.Label45)
        Me.Panel64.Controls.Add(Me.Label44)
        Me.Panel64.Controls.Add(Me.Label43)
        Me.Panel64.Controls.Add(Me.Label40)
        Me.Panel64.Controls.Add(Me.Label25)
        Me.Panel64.Controls.Add(Me.dtpDateControle)
        Me.Panel64.Controls.Add(Me.Label39)
        Me.Panel64.Controls.Add(Me.btn_controleManos_valider)
        Me.Panel64.Controls.Add(Me.btn_controleManos_suivant)
        Me.Panel64.Controls.Add(Me.lblResultat)
        Me.Panel64.Controls.Add(Me.labelInfoEtalon_classe)
        Me.Panel64.Controls.Add(Me.labelInfoEtalon_fondEchelle)
        Me.Panel64.Controls.Add(Me.labelInfoEtalon_marque)
        Me.Panel64.Controls.Add(Me.labelInfoEtalon_reference)
        Me.Panel64.Controls.Add(Me.labelInfo_reference)
        Me.Panel64.Controls.Add(Me.labelInfo_marque)
        Me.Panel64.Controls.Add(Me.labelInfo_classe)
        Me.Panel64.Controls.Add(Me.labelInfo_fondEchelle)
        Me.Panel64.Controls.Add(Me.Label38)
        Me.Panel64.Controls.Add(Me.Label32)
        Me.Panel64.Controls.Add(Me.Label33)
        Me.Panel64.Controls.Add(Me.Label34)
        Me.Panel64.Controls.Add(Me.Label35)
        Me.Panel64.Controls.Add(Me.Label37)
        Me.Panel64.Controls.Add(Me.Label31)
        Me.Panel64.Controls.Add(Me.Label30)
        Me.Panel64.Controls.Add(Me.Label29)
        Me.Panel64.Controls.Add(Me.Label28)
        Me.Panel64.Controls.Add(Me.Label27)
        Me.Panel64.Controls.Add(Me.SplitContainer1)
        Me.Panel64.Controls.Add(Me.Panel_loading)
        Me.Panel64.Controls.Add(Me.btn_controleBanc_annuler)
        Me.Panel64.Controls.Add(Me.Label36)
        Me.Panel64.Controls.Add(Me.tbTemperature)
        Me.Panel64.Controls.Add(Me.Label9)
        Me.Panel64.Controls.Add(Me.Label8)
        Me.Panel64.Controls.Add(Me.cbx_manometresEtalon)
        Me.Panel64.Controls.Add(Me.Label82)
        Me.Panel64.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel64.Location = New System.Drawing.Point(0, 0)
        Me.Panel64.Name = "Panel64"
        Me.Panel64.Size = New System.Drawing.Size(1008, 679)
        Me.Panel64.TabIndex = 20
        '
        'Label46
        '
        Me.Label46.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label46.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoControle, "bAjusteur", True))
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(870, 169)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(104, 16)
        Me.Label46.TabIndex = 61
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(761, 171)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(103, 13)
        Me.Label45.TabIndex = 60
        Me.Label45.Text = "Ajusteur :"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label44
        '
        Me.Label44.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label44.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoControle, "resolutionLecture", True))
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(870, 151)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(104, 16)
        Me.Label44.TabIndex = 59
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoControle, "resolution", True))
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(870, 135)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(104, 16)
        Me.Label43.TabIndex = 58
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(761, 153)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(103, 13)
        Me.Label40.TabIndex = 57
        Me.Label40.Text = "Résolution lect. :"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(761, 135)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 13)
        Me.Label25.TabIndex = 56
        Me.Label25.Text = "Résolution :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpDateControle
        '
        Me.dtpDateControle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDateControle.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateControle.Location = New System.Drawing.Point(641, 31)
        Me.dtpDateControle.Name = "dtpDateControle"
        Me.dtpDateControle.Size = New System.Drawing.Size(143, 20)
        Me.dtpDateControle.TabIndex = 2
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(478, 32)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(151, 16)
        Me.Label39.TabIndex = 55
        Me.Label39.Text = "Date de contrôle :"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btn_controleManos_valider
        '
        Me.btn_controleManos_valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_controleManos_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleManos_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleManos_valider.ForeColor = System.Drawing.Color.White
        Me.btn_controleManos_valider.Image = CType(resources.GetObject("btn_controleManos_valider.Image"), System.Drawing.Image)
        Me.btn_controleManos_valider.Location = New System.Drawing.Point(864, 646)
        Me.btn_controleManos_valider.Name = "btn_controleManos_valider"
        Me.btn_controleManos_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleManos_valider.TabIndex = 53
        Me.btn_controleManos_valider.Text = "    Valider / Quitter"
        Me.btn_controleManos_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_controleManos_suivant
        '
        Me.btn_controleManos_suivant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_controleManos_suivant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleManos_suivant.Enabled = False
        Me.btn_controleManos_suivant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleManos_suivant.ForeColor = System.Drawing.Color.White
        Me.btn_controleManos_suivant.Image = CType(resources.GetObject("btn_controleManos_suivant.Image"), System.Drawing.Image)
        Me.btn_controleManos_suivant.Location = New System.Drawing.Point(864, 609)
        Me.btn_controleManos_suivant.Name = "btn_controleManos_suivant"
        Me.btn_controleManos_suivant.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleManos_suivant.TabIndex = 54
        Me.btn_controleManos_suivant.Text = "    Mano suivant"
        Me.btn_controleManos_suivant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblResultat
        '
        Me.lblResultat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResultat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "resultat", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblResultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultat.ForeColor = System.Drawing.Color.Green
        Me.lblResultat.Location = New System.Drawing.Point(761, 334)
        Me.lblResultat.Name = "lblResultat"
        Me.lblResultat.Size = New System.Drawing.Size(224, 76)
        Me.lblResultat.TabIndex = 52
        Me.lblResultat.Text = "Votre manomètre est fiable : il répond à sa classe de précision."
        Me.lblResultat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelInfoEtalon_classe
        '
        Me.labelInfoEtalon_classe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfoEtalon_classe.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoEtalon, "classe", True))
        Me.labelInfoEtalon_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfoEtalon_classe.ForeColor = System.Drawing.Color.Black
        Me.labelInfoEtalon_classe.Location = New System.Drawing.Point(870, 252)
        Me.labelInfoEtalon_classe.Name = "labelInfoEtalon_classe"
        Me.labelInfoEtalon_classe.Size = New System.Drawing.Size(96, 16)
        Me.labelInfoEtalon_classe.TabIndex = 48
        Me.labelInfoEtalon_classe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfoEtalon_fondEchelle
        '
        Me.labelInfoEtalon_fondEchelle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfoEtalon_fondEchelle.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoEtalon, "fondEchelle", True))
        Me.labelInfoEtalon_fondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfoEtalon_fondEchelle.ForeColor = System.Drawing.Color.Black
        Me.labelInfoEtalon_fondEchelle.Location = New System.Drawing.Point(864, 268)
        Me.labelInfoEtalon_fondEchelle.Name = "labelInfoEtalon_fondEchelle"
        Me.labelInfoEtalon_fondEchelle.Size = New System.Drawing.Size(96, 16)
        Me.labelInfoEtalon_fondEchelle.TabIndex = 49
        Me.labelInfoEtalon_fondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfoEtalon_marque
        '
        Me.labelInfoEtalon_marque.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfoEtalon_marque.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoEtalon, "marque", True))
        Me.labelInfoEtalon_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfoEtalon_marque.ForeColor = System.Drawing.Color.Black
        Me.labelInfoEtalon_marque.Location = New System.Drawing.Point(870, 237)
        Me.labelInfoEtalon_marque.Name = "labelInfoEtalon_marque"
        Me.labelInfoEtalon_marque.Size = New System.Drawing.Size(96, 16)
        Me.labelInfoEtalon_marque.TabIndex = 50
        Me.labelInfoEtalon_marque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfoEtalon_reference
        '
        Me.labelInfoEtalon_reference.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfoEtalon_reference.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoEtalon, "idCrodip", True))
        Me.labelInfoEtalon_reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfoEtalon_reference.ForeColor = System.Drawing.Color.Black
        Me.labelInfoEtalon_reference.Location = New System.Drawing.Point(870, 221)
        Me.labelInfoEtalon_reference.Name = "labelInfoEtalon_reference"
        Me.labelInfoEtalon_reference.Size = New System.Drawing.Size(96, 16)
        Me.labelInfoEtalon_reference.TabIndex = 51
        Me.labelInfoEtalon_reference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfo_reference
        '
        Me.labelInfo_reference.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfo_reference.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoControle, "idCrodip", True))
        Me.labelInfo_reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo_reference.ForeColor = System.Drawing.Color.Black
        Me.labelInfo_reference.Location = New System.Drawing.Point(870, 58)
        Me.labelInfo_reference.Name = "labelInfo_reference"
        Me.labelInfo_reference.Size = New System.Drawing.Size(104, 16)
        Me.labelInfo_reference.TabIndex = 44
        Me.labelInfo_reference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfo_marque
        '
        Me.labelInfo_marque.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfo_marque.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoControle, "marque", True))
        Me.labelInfo_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo_marque.ForeColor = System.Drawing.Color.Black
        Me.labelInfo_marque.Location = New System.Drawing.Point(870, 78)
        Me.labelInfo_marque.Name = "labelInfo_marque"
        Me.labelInfo_marque.Size = New System.Drawing.Size(104, 16)
        Me.labelInfo_marque.TabIndex = 45
        Me.labelInfo_marque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfo_classe
        '
        Me.labelInfo_classe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfo_classe.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoControle, "classe", True))
        Me.labelInfo_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo_classe.ForeColor = System.Drawing.Color.Black
        Me.labelInfo_classe.Location = New System.Drawing.Point(870, 97)
        Me.labelInfo_classe.Name = "labelInfo_classe"
        Me.labelInfo_classe.Size = New System.Drawing.Size(104, 16)
        Me.labelInfo_classe.TabIndex = 46
        Me.labelInfo_classe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfo_fondEchelle
        '
        Me.labelInfo_fondEchelle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfo_fondEchelle.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsManoControle, "fondEchelle", True))
        Me.labelInfo_fondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo_fondEchelle.ForeColor = System.Drawing.Color.Black
        Me.labelInfo_fondEchelle.Location = New System.Drawing.Point(870, 116)
        Me.labelInfo_fondEchelle.Name = "labelInfo_fondEchelle"
        Me.labelInfo_fondEchelle.Size = New System.Drawing.Size(104, 16)
        Me.labelInfo_fondEchelle.TabIndex = 47
        Me.labelInfo_fondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label38.Image = CType(resources.GetObject("Label38.Image"), System.Drawing.Image)
        Me.Label38.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label38.Location = New System.Drawing.Point(761, 299)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(135, 13)
        Me.Label38.TabIndex = 43
        Me.Label38.Text = "      Résultat de l'essai"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(761, 270)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(103, 13)
        Me.Label32.TabIndex = 42
        Me.Label32.Text = "Fond d'échelle :"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(761, 254)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(103, 13)
        Me.Label33.TabIndex = 41
        Me.Label33.Text = "Classe :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(761, 237)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(103, 13)
        Me.Label34.TabIndex = 40
        Me.Label34.Text = "Marque :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label35
        '
        Me.Label35.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(761, 220)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(103, 13)
        Me.Label35.TabIndex = 39
        Me.Label35.Text = "N° Identifiant :"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label37.Image = CType(resources.GetObject("Label37.Image"), System.Drawing.Image)
        Me.Label37.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label37.Location = New System.Drawing.Point(761, 202)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(150, 13)
        Me.Label37.TabIndex = 38
        Me.Label37.Text = "       Mano de référence :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(761, 118)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(103, 13)
        Me.Label31.TabIndex = 37
        Me.Label31.Text = "Fond d'échelle :"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(761, 99)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(103, 13)
        Me.Label30.TabIndex = 36
        Me.Label30.Text = "Classe :"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(761, 80)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 13)
        Me.Label29.TabIndex = 35
        Me.Label29.Text = "Marque :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(761, 63)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(103, 13)
        Me.Label28.TabIndex = 34
        Me.Label28.Text = "N° Identifiant :"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label27.Image = CType(resources.GetObject("Label27.Image"), System.Drawing.Image)
        Me.Label27.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label27.Location = New System.Drawing.Point(784, 45)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(127, 13)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "      Mano à contrôler"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(13, 63)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbMano)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.tlpGlobal)
        Me.SplitContainer1.Size = New System.Drawing.Size(726, 562)
        Me.SplitContainer1.SplitterDistance = 94
        Me.SplitContainer1.TabIndex = 32
        '
        'lbMano
        '
        Me.lbMano.DataSource = Me.m_bsManoControle
        Me.lbMano.DisplayMember = "Libelle"
        Me.lbMano.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbMano.FormattingEnabled = True
        Me.lbMano.Location = New System.Drawing.Point(0, 0)
        Me.lbMano.Name = "lbMano"
        Me.lbMano.Size = New System.Drawing.Size(94, 562)
        Me.lbMano.TabIndex = 0
        '
        'tlpGlobal
        '
        Me.tlpGlobal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpGlobal.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.tlpGlobal.ColumnCount = 1
        Me.tlpGlobal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGlobal.Controls.Add(Me.tlpEntete, 0, 0)
        Me.tlpGlobal.Controls.Add(Me.tlpPressionCroissant, 0, 1)
        Me.tlpGlobal.Controls.Add(Me.tlpPressionDecroissante, 0, 2)
        Me.tlpGlobal.Controls.Add(Me.tlpRepetition, 0, 3)
        Me.tlpGlobal.Location = New System.Drawing.Point(2, 5)
        Me.tlpGlobal.Name = "tlpGlobal"
        Me.tlpGlobal.RowCount = 4
        Me.tlpGlobal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpGlobal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.15!))
        Me.tlpGlobal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.46!))
        Me.tlpGlobal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.39!))
        Me.tlpGlobal.Size = New System.Drawing.Size(623, 554)
        Me.tlpGlobal.TabIndex = 17
        '
        'tlpEntete
        '
        Me.tlpEntete.BackColor = System.Drawing.SystemColors.Control
        Me.tlpEntete.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpEntete.ColumnCount = 8
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpEntete.Controls.Add(Me.Label5, 4, 0)
        Me.tlpEntete.Controls.Add(Me.Label6, 5, 0)
        Me.tlpEntete.Controls.Add(Me.Label7, 6, 0)
        Me.tlpEntete.Controls.Add(Me.Label11, 7, 1)
        Me.tlpEntete.Controls.Add(Me.Label10, 6, 1)
        Me.tlpEntete.Controls.Add(Me.Label4, 3, 1)
        Me.tlpEntete.Controls.Add(Me.Label3, 2, 1)
        Me.tlpEntete.Controls.Add(Me.Label2, 2, 0)
        Me.tlpEntete.Controls.Add(Me.Label1, 1, 0)
        Me.tlpEntete.Controls.Add(Me.btn_controleManos_acquiring, 0, 0)
        Me.tlpEntete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpEntete.Location = New System.Drawing.Point(3, 3)
        Me.tlpEntete.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpEntete.Name = "tlpEntete"
        Me.tlpEntete.RowCount = 2
        Me.tlpEntete.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpEntete.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpEntete.Size = New System.Drawing.Size(617, 60)
        Me.tlpEntete.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(302, 1)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.tlpEntete.SetRowSpan(Me.Label5, 2)
        Me.Label5.Size = New System.Drawing.Size(76, 58)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Incertitude"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(379, 1)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.tlpEntete.SetRowSpan(Me.Label6, 2)
        Me.Label6.Size = New System.Drawing.Size(42, 58)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "EMT"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.tlpEntete.SetColumnSpan(Me.Label7, 2)
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(425, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(188, 28)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Erreur"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(486, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 29)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Fond d'échelle (%)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(425, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(1)
        Me.Label10.Size = New System.Drawing.Size(54, 29)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Absolue (bar)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(229, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 29)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Manomètre Référence"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(148, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 29)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Manomètre à contrôler"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.tlpEntete.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(148, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 28)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Pression (bar)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(85, 1)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.tlpEntete.SetRowSpan(Me.Label1, 2)
        Me.Label1.Size = New System.Drawing.Size(59, 58)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Points d'essai"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_controleManos_acquiring
        '
        Me.btn_controleManos_acquiring.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleManos_acquiring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_controleManos_acquiring.Image = CType(resources.GetObject("btn_controleManos_acquiring.Image"), System.Drawing.Image)
        Me.btn_controleManos_acquiring.Location = New System.Drawing.Point(4, 4)
        Me.btn_controleManos_acquiring.Name = "btn_controleManos_acquiring"
        Me.tlpEntete.SetRowSpan(Me.btn_controleManos_acquiring, 2)
        Me.btn_controleManos_acquiring.Size = New System.Drawing.Size(77, 52)
        Me.btn_controleManos_acquiring.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.btn_controleManos_acquiring.TabIndex = 26
        Me.btn_controleManos_acquiring.TabStop = False
        '
        'tlpPressionCroissant
        '
        Me.tlpPressionCroissant.BackColor = System.Drawing.SystemColors.Control
        Me.tlpPressionCroissant.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpPressionCroissant.ColumnCount = 8
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPressionCroissant.Controls.Add(Me.Label19, 0, 0)
        Me.tlpPressionCroissant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPressionCroissant.Location = New System.Drawing.Point(3, 66)
        Me.tlpPressionCroissant.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpPressionCroissant.Name = "tlpPressionCroissant"
        Me.tlpPressionCroissant.RowCount = 6
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66917!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.Size = New System.Drawing.Size(617, 221)
        Me.tlpPressionCroissant.TabIndex = 15
        '
        'tlpPressionDecroissante
        '
        Me.tlpPressionDecroissante.BackColor = System.Drawing.SystemColors.Control
        Me.tlpPressionDecroissante.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpPressionDecroissante.ColumnCount = 8
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPressionDecroissante.Controls.Add(Me.Label20, 0, 0)
        Me.tlpPressionDecroissante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPressionDecroissante.Location = New System.Drawing.Point(3, 290)
        Me.tlpPressionDecroissante.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpPressionDecroissante.Name = "tlpPressionDecroissante"
        Me.tlpPressionDecroissante.RowCount = 4
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPressionDecroissante.Size = New System.Drawing.Size(617, 184)
        Me.tlpPressionDecroissante.TabIndex = 16
        '
        'tlpRepetition
        '
        Me.tlpRepetition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRepetition.BackColor = System.Drawing.SystemColors.Control
        Me.tlpRepetition.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpRepetition.ColumnCount = 8
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRepetition.Controls.Add(Me.Label26, 0, 0)
        Me.tlpRepetition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRepetition.Location = New System.Drawing.Point(3, 477)
        Me.tlpRepetition.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpRepetition.Name = "tlpRepetition"
        Me.tlpRepetition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRepetition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRepetition.Size = New System.Drawing.Size(617, 74)
        Me.tlpRepetition.TabIndex = 17
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
        Me.btn_controleBanc_annuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_controleBanc_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleBanc_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleBanc_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_controleBanc_annuler.Image = CType(resources.GetObject("btn_controleBanc_annuler.Image"), System.Drawing.Image)
        Me.btn_controleBanc_annuler.Location = New System.Drawing.Point(730, 646)
        Me.btn_controleBanc_annuler.Name = "btn_controleBanc_annuler"
        Me.btn_controleBanc_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleBanc_annuler.TabIndex = 29
        Me.btn_controleBanc_annuler.Text = "    Quitter l'outil"
        Me.btn_controleBanc_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(744, 423)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(248, 169)
        Me.Label36.TabIndex = 10
        Me.Label36.Text = resources.GetString("Label36.Text")
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbTemperature
        '
        Me.tbTemperature.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTemperature.Location = New System.Drawing.Point(417, 5)
        Me.tbTemperature.Name = "tbTemperature"
        Me.tbTemperature.Size = New System.Drawing.Size(48, 20)
        Me.tbTemperature.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(312, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Température air"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ImageList_onglets
        '
        Me.ImageList_onglets.ImageStream = CType(resources.GetObject("ImageList_onglets.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_onglets.TransparentColor = System.Drawing.Color.White
        Me.ImageList_onglets.Images.SetKeyName(0, "")
        '
        'Label19
        '
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(1, 1)
        Me.Label19.Margin = New System.Windows.Forms.Padding(0)
        Me.Label19.Name = "Label19"
        Me.tlpPressionCroissant.SetRowSpan(Me.Label19, 6)
        Me.Label19.Size = New System.Drawing.Size(84, 219)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "Pression croissante"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(1, 1)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0)
        Me.Label20.Name = "Label20"
        Me.tlpPressionDecroissante.SetRowSpan(Me.Label20, 4)
        Me.Label20.Size = New System.Drawing.Size(84, 182)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Pression décroissante"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(1, 1)
        Me.Label26.Margin = New System.Windows.Forms.Padding(0)
        Me.Label26.Name = "Label26"
        Me.tlpRepetition.SetRowSpan(Me.Label26, 2)
        Me.Label26.Size = New System.Drawing.Size(84, 72)
        Me.Label26.TabIndex = 53
        Me.Label26.Text = "Répétition"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmControleManometresNew
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel64)
        Me.MinimizeBox = False
        Me.Name = "frmControleManometresNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Contrôle des manomètres de l'agent"
        CType(Me.m_bsManoEtalon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsControle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsManoControle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel64.ResumeLayout(False)
        Me.Panel64.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tlpGlobal.ResumeLayout(False)
        Me.tlpEntete.ResumeLayout(False)
        CType(Me.btn_controleManos_acquiring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpPressionCroissant.ResumeLayout(False)
        Me.tlpPressionDecroissante.ResumeLayout(False)
        Me.tlpRepetition.ResumeLayout(False)
        Me.Panel_loading.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
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


        'Dim lstBanc As List(Of Banc) = BancManager.getBancByAgent(m_oAgent)



        '####################################################
        '######### Chargement des manomètres étalon #########
        '####################################################

        ' On récupère les mano étalons de l'agent
        Dim arrManoEtalon As List(Of ManometreEtalon) = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        m_bsManoEtalon.Clear()
        For Each oManoE As ManometreEtalon In arrManoEtalon
            m_bsManoEtalon.Add(oManoE)
        Next
        m_bsManoEtalon.AddNew()
        m_bsManoEtalon.MoveLast()
        '####################################################
        '###### Chargement des manomètres de controle #######
        '####################################################
        ' On clear les onglets
        m_bsManoControle.Clear()

        ' On récupère la liste des manos de la structure de l'agent
        Dim arrManoControle As List(Of ManometreControle) = ManometreControleManager.getManoControleByAgent(m_oAgent, True)
        For Each oManoC As ManometreControle In arrManoControle
            oManoC.creerControle(m_oAgent)
            m_bsManoControle.Add(oManoC)
        Next
        m_bsManoControle.MoveLast()

        If GlobalsCRODIP.GLOB_ENV_DEBUG Then
            tbTemperature.Text = "15"
            m_bsManoEtalon.MoveFirst()
            m_bsManoControle.MoveFirst()
            m_bsManoControle.MoveNext()

            Dim oCtrl As ControleMano
            oCtrl = m_bsControle.Current
            For Each oDetail As ControleManoDetail In oCtrl.lstControleManoDetail.Values
                oDetail.pres_manoEtalon = oDetail.pres_manoCtrl
            Next

        End If
    End Sub
    ''' <summary>
    ''' Affichage du détail du controle de Mano
    ''' </summary>
    ''' <param name="pControleMano">le controle à afficher</param>
    ''' <param name="pAjusteur">Affichage de l'ajusteur ou pas</param>
    Private Sub AfficheControleMano(pControleMano As ControleMano)

        Me.tlpGlobal.Visible = False
        Me.tlpGlobal.SuspendLayout()
        'ajustement des TablePanels
        Dim nUp As Integer = pControleMano.lstControleManoDetail.Values.Where(Function(D)
                                                                                  Return D.type = "UP"
                                                                              End Function).Count()
        Dim nDown As Integer = pControleMano.lstControleManoDetail.Values.Where(Function(D)
                                                                                    Return D.type = "DOWN"
                                                                                End Function).Count()
        Dim nRepe As Integer = pControleMano.lstControleManoDetail.Values.Where(Function(D)
                                                                                    Return D.type = "REPE"
                                                                                End Function).Count()
        Dim nLignestot As Integer = nUp + nDown + nRepe
        tlpGlobal.RowStyles(1) = New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, nUp / nLignestot * 100)
        tlpGlobal.RowStyles(2) = New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, nDown / nLignestot * 100)
        tlpGlobal.RowStyles(3) = New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, nRepe / nLignestot * 100)


        Dim lstCtrlManoDetail As List(Of ControleManoDetail)
        'Trt des pression croissantes
        '-----------------------------------
        lstCtrlManoDetail = pControleMano.lstControleManoDetail.Values.Where(Function(D)
                                                                                 Return D.type = "UP"
                                                                             End Function).ToList()
        Me.tlpPressionCroissant.Controls.Clear()
        'Label Croissant
        Dim lblPressionCroissante As Label
        lblPressionCroissante = New Label()
        lblPressionCroissante.Dock = System.Windows.Forms.DockStyle.Fill
        lblPressionCroissante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPressionCroissante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        lblPressionCroissante.Location = New System.Drawing.Point(1, 1)
        lblPressionCroissante.Margin = New System.Windows.Forms.Padding(0)
        lblPressionCroissante.Size = New System.Drawing.Size(84, 219)
        lblPressionCroissante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        lblPressionCroissante.Text = "Pressions croissantes"
        If lstCtrlManoDetail.Count > 0 Then
            Me.tlpPressionCroissant.Controls.Add(lblPressionCroissante, 0, 0)
        End If

        Dim nLigne As Integer
        nLigne = 1
        For Each oLigneDetail As ControleManoDetail In lstCtrlManoDetail
            AfficheLgCtrlManoDetail(tlpPressionCroissant, oLigneDetail, nLigne)
            nLigne = nLigne + 1
        Next

        Me.tlpPressionCroissant.RowStyles.Clear()
        'Me.tlpPressionCroissant.RowCount = lstCtrlManoDetail.Count
        For Each oLigneDetail As ControleManoDetail In lstCtrlManoDetail
            Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / lstCtrlManoDetail.Count))
        Next

        If lstCtrlManoDetail.Count > 1 Then
            Me.tlpPressionCroissant.SetRowSpan(lblPressionCroissante, lstCtrlManoDetail.Count)
        End If



        'Trt des pression décroissantes
        '-----------------------------------
        lstCtrlManoDetail = pControleMano.lstControleManoDetail.Values.Where(Function(D)
                                                                                 Return D.type = "DOWN"
                                                                             End Function).ToList()

        Me.tlpPressionDecroissante.Controls.Clear()
        Me.tlpPressionDecroissante.RowStyles.Clear()
        'Me.tlpPressionDecroissante.RowCount = lstCtrlManoDetail.Count
        For Each oLigneDetail As ControleManoDetail In lstCtrlManoDetail
            Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / lstCtrlManoDetail.Count))
        Next
        'Label Décroissant
        'TODO créer le Label
        Dim lblPressionDeCroissante As Label
        lblPressionDeCroissante = New Label()
        lblPressionDeCroissante.Dock = System.Windows.Forms.DockStyle.Fill
        lblPressionDeCroissante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPressionDeCroissante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        lblPressionDeCroissante.Location = New System.Drawing.Point(1, 1)
        lblPressionDeCroissante.Margin = New System.Windows.Forms.Padding(0)
        lblPressionDeCroissante.Size = New System.Drawing.Size(84, 219)
        lblPressionDeCroissante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        lblPressionDeCroissante.Text = "Pressions décroissantes"
        If lstCtrlManoDetail.Count > 0 Then
            Me.tlpPressionDecroissante.Controls.Add(lblPressionDeCroissante, 0, 0)
        End If

        nLigne = 1
        For Each oLigneDetail As ControleManoDetail In lstCtrlManoDetail
            AfficheLgCtrlManoDetail(tlpPressionDecroissante, oLigneDetail, nLigne)
            nLigne = nLigne + 1
        Next
        If lstCtrlManoDetail.Count > 1 Then
            Me.tlpPressionDecroissante.SetRowSpan(lblPressionDeCroissante, lstCtrlManoDetail.Count)
        End If


        'Trt des répétitions
        '------------------------
        lstCtrlManoDetail = pControleMano.lstControleManoDetail.Values.Where(Function(D)
                                                                                 Return D.type = "REPE"
                                                                             End Function).ToList()

        Me.tlpRepetition.Controls.Clear()
        Me.tlpRepetition.RowStyles.Clear()
        'Me.tlpRepetition.RowCount = lstCtrlManoDetail.Count

        For Each oLigneDetail As ControleManoDetail In lstCtrlManoDetail
            Me.tlpRepetition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / lstCtrlManoDetail.Count))
        Next
        'Label Repetition
        Dim lblRepetition As Label
        lblRepetition = New Label()
        lblRepetition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRepetition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        lblRepetition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        lblRepetition.Text = "Répétitions"
        If lstCtrlManoDetail.Count > 0 Then
            Me.tlpRepetition.Controls.Add(lblRepetition, 0, 0)
        End If

        nLigne = 1
        For Each oLigneDetail As ControleManoDetail In lstCtrlManoDetail
            AfficheLgCtrlManoDetail(tlpRepetition, oLigneDetail, nLigne)
            nLigne = nLigne + 1
        Next
        If lstCtrlManoDetail.Count > 1 Then
            Me.tlpRepetition.SetRowSpan(lblRepetition, lstCtrlManoDetail.Count)
        End If

        'ajustement des TablePanels
        'Dim nLignestot As Integer = tlpPressionCroissant.RowStyles.Count + tlpPressionDecroissante.RowStyles.Count + tlpRepetition.RowStyles.Count
        'tlpGlobal.RowStyles(1) = New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, tlpPressionCroissant.RowStyles.Count / nLignestot * 100)
        'tlpGlobal.RowStyles(2) = New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, tlpPressionDecroissante.RowStyles.Count / nLignestot * 100)
        'tlpGlobal.RowStyles(3) = New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, tlpRepetition.RowStyles.Count / nLignestot * 100)

        Me.tlpGlobal.Visible = True
        Me.tlpGlobal.ResumeLayout(True)

    End Sub

    Private Sub AfficheLgCtrlManoDetail(pTableLayoutPanel As TableLayoutPanel,
                                        pLgCtrlManoDetail As ControleManoDetail,
                                        pNumLigne As Integer)

        Dim Prefixe As String = pLgCtrlManoDetail.type
        Dim oControle As ControleMano
        oControle = m_bsControle.Current


        Dim oLbl As Label = New Label()
        oLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        oLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        oLbl.Text = pLgCtrlManoDetail.point
        oLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        oLbl.Dock = DockStyle.Fill
        pTableLayoutPanel.Controls.Add(oLbl, 1, pNumLigne - 1)


        Dim otb As TextBox
        Dim b As Binding
        Dim oNup As NumericUpDown2

        'on utilise une classe intermédiare (BindindMap) pour pourvoir utiliser les propriété indexees
        '=============================================================================================
        '        If pLgCtrlManoDetail.bAjusteur Then
        If pLgCtrlManoDetail.bAjusteur Then
            oNup = New NumericUpDown2()
            oNup.tb.Enabled = False
            oNup.upDown.Visible = True
            oNup.TabStop = False
            oNup.Tag = Prefixe & pLgCtrlManoDetail.point
            oNup.Increment = pLgCtrlManoDetail.resolution
            oNup.DecimalPlaces = 3
            oNup.Dock = System.Windows.Forms.DockStyle.Fill
            b = New Binding("Text", New BindingMap(Me.m_bsControle.Current, "lstControleManoDetail_pres_manoCtrl", Prefixe & pLgCtrlManoDetail.point), "MapValue")
            oNup.DataBindings.Add(b)
            pTableLayoutPanel.Controls.Add(oNup, 2, pNumLigne - 1)
        Else
            otb = New TextBox
            otb.Tag = Prefixe & pLgCtrlManoDetail.point
            otb.TabStop = False
            otb.Dock = System.Windows.Forms.DockStyle.Fill
            b = New Binding("Text", New BindingMap(Me.m_bsControle.Current, "lstControleManoDetail_pres_manoCtrl", Prefixe & pLgCtrlManoDetail.point), "MapValue")
            otb.DataBindings.Add(b)
            otb.ReadOnly = True
            pTableLayoutPanel.Controls.Add(otb, 2, pNumLigne - 1)

        End If


        otb = New TextBox()
        otb.Tag = Prefixe & pLgCtrlManoDetail.point
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        b = New Binding("Text", New BindingMap(Me.m_bsControle.Current, "lstControleManoDetail_pres_manoEtalon", Prefixe & pLgCtrlManoDetail.point), "MapValue")
        otb.DataBindings.Add(b)
        AddHandler otb.Validated, AddressOf validerSaisiePressionEtalon
        AddHandler otb.KeyPress, AddressOf checkKeyPress
        pTableLayoutPanel.Controls.Add(otb, 3, pNumLigne - 1)
        If oControle.lstControleManoDetail_conformite(Prefixe & pLgCtrlManoDetail.point) = "1" Then
            otb.ForeColor = System.Drawing.Color.Green
        End If
        If oControle.lstControleManoDetail_conformite(Prefixe & pLgCtrlManoDetail.point) = "0" Then
            otb.ForeColor = System.Drawing.Color.Red
        End If




        otb = New TextBox
        otb.Tag = Prefixe & pLgCtrlManoDetail.point
        otb.TabStop = False
        otb.ReadOnly = True
        b = New Binding("Text", New BindingMap(Me.m_bsControle.Current, "lstControleManoDetail_incertitude", Prefixe & pLgCtrlManoDetail.point), "MapValue")
        otb.DataBindings.Add(b)
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 4, pNumLigne - 1)

        otb = New TextBox
        otb.Tag = Prefixe & pNumLigne
        otb.TabStop = False
        otb.ReadOnly = True
        b = New Binding("Text", New BindingMap(Me.m_bsControle.Current, "lstControleManoDetail_EMT", Prefixe & pLgCtrlManoDetail.point), "MapValue")
        otb.DataBindings.Add(b)
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 5, pNumLigne - 1)

        otb = New TextBox
        otb.Tag = Prefixe & pLgCtrlManoDetail.point
        otb.TabStop = False
        otb.ReadOnly = True
        b = New Binding("Text", New BindingMap(Me.m_bsControle.Current, "lstControleManoDetail_err_abs", Prefixe & pLgCtrlManoDetail.point), "MapValue")
        otb.DataBindings.Add(b)
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 6, pNumLigne - 1)

        otb = New TextBox
        otb.Tag = Prefixe & pLgCtrlManoDetail.point
        otb.TabStop = False
        otb.ReadOnly = True
        b = New Binding("Text", New BindingMap(Me.m_bsControle.Current, "lstControleManoDetail_err_FondEchelle", Prefixe & pLgCtrlManoDetail.point), "MapValue")
        otb.DataBindings.Add(b)
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 7, pNumLigne - 1)

    End Sub


#Region " Calculs "

    ' Test si le mano est fiable
    Public Function checkMano(oControle As ControleMano) As Boolean

        Dim isFiable As Boolean = False

        If isSaisieComplete() Then
            isFiable = True
            For Each oDetail As ControleManoDetail In oControle.lstControleManoDetail.Values
                isFiable = isFiable And (oDetail.conformite = "1")
            Next
        End If



        'MAJ de l'état du mano
        Dim oMano As ManometreControle
        oMano = m_bsManoControle.Current
        oMano.etat = isFiable
        oMano.SetUpdated()

        ' NEW
        Return isFiable


    End Function

    Public Function isSaisieComplete() As Boolean
        ' Init
        Dim bisSaisieComplete As Boolean = True
        Dim oMAno As ManometreControle
        oMAno = m_bsManoControle.Current

        Dim oControle As ControleMano
        oControle = oMAno.controle
        If oControle IsNot Nothing Then
            For Each oDetail As ControleManoDetail In oControle.lstControleManoDetail.Values
                bisSaisieComplete = bisSaisieComplete And (oDetail.conformite <> "")
            Next


        End If
        Return bisSaisieComplete

    End Function
#End Region


#Region " Boutons "

    ' Fonction de validation des contrôles
    Private Function EnregistrerLesControles() As Boolean
        Dim bReturn As Boolean
        Try
            CSDebug.dispInfo("frmControleManager.EnregistrerLesControles Debut")
            Dim oManoEtalon As ManometreEtalon
            oManoEtalon = m_bsManoEtalon.Current
            Dim curManoControle As ManometreControle
            Dim oCtrlMano As ControleMano
            For Each curManoControle In m_bsManoControle
                'On met a jour le manometreControle
                If curManoControle.isUpdated Then
                    oCtrlMano = curManoControle.controle
                    If oCtrlMano IsNot Nothing Then
                        oCtrlMano.manoEtalon = oManoEtalon.numeroNational
                        curManoControle.dateDernierControle = oCtrlMano.DateVerif
                        curManoControle.dateModificationAgent = Date.Now
                        CSDebug.dispInfo("frmControleManager.EnregistrerLesControles : Enregistrer un Mano ")
                        ManometreControleManager.save(curManoControle)

                        ' On enregistre les mesures

                        '########################################################
                        ' On récupère les controles
                        oCtrlMano.PressionControle = ""
                        oCtrlMano.ValeursMesurees = ""
                        For Each oDetail As ControleManoDetail In oCtrlMano.lstControleManoDetail.Values
                            oCtrlMano.PressionControle = oCtrlMano.PressionControle & oDetail.pres_manoCtrl & "|"
                            oCtrlMano.ValeursMesurees = oCtrlMano.ValeursMesurees & oDetail.pres_manoEtalon & "|"
                        Next

                        oCtrlMano.DateVerif = dtpDateControle.Value
                        curManoControle.dateDernierControle = dtpDateControle.Value
                        ' On construit notre nouvelle fiche de vie
                        CSDebug.dispInfo("frmControleManager.EnregistrerLesControles : Construct FV Controle ")
                        curManoControle.creerfFicheVieControle(m_oAgent, oCtrlMano)

                        ' On flag le mano etalon comme etant utilise
                        ' On récupère le mano
                        Dim tmpManometreEtalon As ManometreEtalon = m_bsManoEtalon.Current
                        ' On le flag
                        CSDebug.dispInfo("frmControleManager.EnregistrerLesControles : Set ManoEtalon utilisé ")
                        ManometreEtalonManager.setUtilise(m_oAgent, tmpManometreEtalon)
                    End If
                End If
            Next
            CSDebug.dispInfo("frmControleManager.EnregistrerLesControles Fin")

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("controle_manometres::validControl : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Bouton "Suivant"
    Private Sub btn_controleManos_suivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleManos_suivant.Click
        If tbTemperature.Text <> "" Then
            If isSaisieComplete() Then
                Dim oMano As ManometreControle
                oMano = m_bsManoControle.Current
                If (lbMano.SelectedIndex < lbMano.Items.Count - 1) Then
                    dateVerif = oMano.controle.DateVerif
                    lbMano.SelectedIndex = lbMano.SelectedIndex + 1
                    btn_controleManos_suivant.Enabled = False
                    btn_controleManos_valider.Enabled = True
                Else
                    btn_controleManos_suivant.Enabled = False
                    btn_controleManos_valider.Enabled = True
                End If
            End If
        Else
            MsgBox("Veuillez remplir le champ température pour continuer", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
        End If
    End Sub

    ' Bouton "Valider"
    Private Sub btn_controleManos_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleManos_valider.Click


        If tbTemperature.Text <> "" And cbx_manometresEtalon.Text <> "" Then
            If isSaisieComplete() Then
                Me.Cursor = Cursors.WaitCursor
                EnregistrerLesControles()
                Me.Cursor = Cursors.Default
                TryCast(MdiParent, parentContener).ReturnToAccueil()
            End If
        Else
            MsgBox("Veuillez remplir le champ température pour continuer", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
        End If
    End Sub

    ' Bouton "Annuler"
    Private Sub btn_controleBanc_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleBanc_annuler.Click
        If MsgBox("Vos contrôles ne seront pas enregistrés, voulez-vous quitter l'outil de vérification?", MsgBoxStyle.YesNo, "Outil de vérification des manomètres") = MsgBoxResult.Yes Then
            TryCast(MdiParent, parentContener).ReturnToAccueil()
        End If
    End Sub

#End Region

#Region " Events "

    ' Selection du manometre étalon
    Private Sub list_manometresEtalon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_manometresEtalon.SelectedIndexChanged
        ActiveListMano()
    End Sub

    Private Sub tbTemperature_ValidatedChanged(sender As Object, e As EventArgs) Handles tbTemperature.Validated
        ActiveListMano()
    End Sub

    Private Sub ActiveListMano()
        If Not IsOK Then
            If cbx_manometresEtalon.Text <> "" And tbTemperature.Text <> "" Then
                IsOK = True
                m_bsManoControle.MoveFirst()
                If m_bsManoControle.Count = 1 Then
                    SelectionManoControle()
                End If
                SplitContainer1.Enabled = True
            Else
                IsOK = False
                SplitContainer1.Enabled = False
            End If
        End If
    End Sub


    ' Calcul au chagement de contenu
    Private Sub validerSaisiePressionEtalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current
            'On Réalise le databinding à la main 
            '===================================
            Dim oCtrl As Control
            For Each oCtrl In tlpPressionCroissant.Controls
                If oCtrl.DataBindings.Count > 0 Then
                    oCtrl.DataBindings(0).ReadValue()
                End If
            Next
            For Each oCtrl In tlpPressionDecroissante.Controls
                If oCtrl.DataBindings.Count > 0 Then
                    oCtrl.DataBindings(0).ReadValue()
                End If
            Next
            For Each oCtrl In tlpRepetition.Controls
                If oCtrl.DataBindings.Count > 0 Then
                    oCtrl.DataBindings(0).ReadValue()
                End If
            Next

            'Récu^ération de la conformité en fonction du code la ligne
            oCtrl = TryCast(sender, TextBox)
            If oCtrl Is Nothing Then
                oCtrl = TryCast(sender, NumericUpDown)
            End If
            If oCtrl IsNot Nothing Then
                Dim key As String
                key = oCtrl.Tag
                ' Calcul err absolue
                If oControle.lstControleManoDetail_conformite(key) = "1" Then
                    sender.ForeColor = System.Drawing.Color.Green
                Else
                    sender.ForeColor = System.Drawing.Color.Red
                End If
            End If


            ValiderSaisie(oControle)
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre2 :: saisiePressionManoReferenceup1 : " & ex.Message.ToString)
        End Try
    End Sub
    ' Calcul au chagement de contenu

    Private Sub ValiderSaisie(pControle As ControleMano)
        If (isSaisieComplete()) Then
            'Calcul du resutat du contole
            If checkMano(pControle) Then
                lblResultat.Text = "Votre manomètre est fiable : il répond à sa classe de précision."
                lblResultat.ForeColor = System.Drawing.Color.Green
            Else
                lblResultat.Text = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
                lblResultat.ForeColor = System.Drawing.Color.Red
            End If

            btn_controleManos_suivant.Enabled = True
            btn_controleManos_valider.Enabled = True
        Else
            pControle.resultat = ""
            btn_controleManos_suivant.Enabled = False
            btn_controleManos_valider.Enabled = True
        End If
        'Refresh the Item 
        Dim old As String
        old = lbMano.DisplayMember
        lbMano.DisplayMember = ""
        lbMano.DisplayMember = old
    End Sub

    Private Sub checkKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub


#End Region

#Region " Acquisition des données "
    ' Bouton acquisitin des données
    Private Sub btn_controleManos_acquiring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Panel_loading.Visible = True
        'doAcquiring()
    End Sub

    Private _thread_doAcqiring As Thread
    Private Sub thr_doAcquiring()
        Dim oModuleAcq As New CRODIPAcquisition.ModuleAcq()
        Dim olstValues As List(Of AcquisitionValue)
        Dim oControle As ControleMano


        '        oModuleAcq = ModuleAcq.GetModule(cbxModules.Text)
        olstValues = oModuleAcq.getValues()
        oControle = m_bsControle.Current
        For Each oVal As AcquisitionValue In olstValues
            If oVal.Niveau = 1 Then
                oControle.lstControleManoDetail_pres_manoEtalon("UP" & oVal.NumBuse) = oVal.Debit
            Else
                oControle.lstControleManoDetail_pres_manoEtalon("DOWN" & oVal.NumBuse) = oVal.Debit

            End If
        Next

        oModuleAcq.clearResults()
        m_bsControle.ResetBindings(False)

        'Dim oControle As ControleMano
        'oControle = m_bsControle.Current
        ''Dim nbBusesAcquis As Integer = AcquiringManager.getNbBuses(2)
        'Dim isok As Boolean = (Me.nbMesures = nbBusesAcquis)
        'If isok Then
        '    ' On récupère les buses de la table d'échange
        '    Dim arrBuses() As Acquiring = AcquiringManager.GetAcquiring()
        '    Dim prevIdNiveau As Integer = 0
        '    Dim curIdBuse As Integer = 0
        '    For Each tmpResponse As Acquiring In arrBuses
        '        Try
        '            If tmpResponse.idBuse <> 0 Then
        '                ' On injecte les valeurs
        '                Try


        '                    If tmpResponse.idNiveau = 1 Then ' Croissante
        '                        Select Case tmpResponse.idBuse
        '                            Case 1
        '                                oControle.up_pt1_pres_manoEtalon = tmpResponse.debit
        '                            Case 2
        '                                oControle.up_pt2_pres_manoEtalon = tmpResponse.debit
        '                            Case 3
        '                                oControle.up_pt3_pres_manoEtalon = tmpResponse.debit
        '                            Case 4
        '                                oControle.up_pt4_pres_manoEtalon = tmpResponse.debit
        '                            Case 5
        '                                oControle.up_pt5_pres_manoEtalon = tmpResponse.debit
        '                            Case 6
        '                                oControle.up_pt6_pres_manoEtalon = tmpResponse.debit
        '                        End Select
        '                    Else ' Decroissante
        '                        Dim tmpId As Integer = tmpResponse.idBuse - Me.nbMesures
        '                        Select Case tmpId
        '                            Case 1
        '                                oControle.down_pt1_pres_manoEtalon = tmpResponse.debit
        '                            Case 2
        '                                oControle.down_pt2_pres_manoEtalon = tmpResponse.debit
        '                            Case 3
        '                                oControle.down_pt3_pres_manoEtalon = tmpResponse.debit
        '                            Case 4
        '                                oControle.down_pt4_pres_manoEtalon = tmpResponse.debit
        '                            Case 5
        '                                oControle.down_pt5_pres_manoEtalon = tmpResponse.debit
        '                            Case 6
        '                                oControle.down_pt6_pres_manoEtalon = tmpResponse.debit
        '                        End Select
        '                    End If

        '                Catch ex As Exception
        '                    CSDebug.dispError("[x0C0004] : " & ex.Message)
        '                End Try
        '            End If
        '        Catch ex As Exception
        '            CSDebug.dispError("[x0C0003] : " & ex.Message.ToString)
        '        End Try
        '    Next
        '    ' On vide la table d'échange
        '    m_bsControle.ResetBindings(False)
        '    'AcquiringManager.clearResults()
        'Else
        '    MsgBox("Le nombre de buses acquises est différent du nombre de mesures nécéssaires. Veuillez vérifiez.")
        'End If

    End Sub

    Public Sub doAcquiring()
        _thread_doAcqiring = New Thread(AddressOf thr_doAcquiring) 'ThrFunc est la fonction exécutée par le thread.
        _thread_doAcqiring.Name = "thr_doAcqiring" 'Il est parfois pratique de nommer les threads surtout si on en créé plusieurs.
        _thread_doAcqiring.Start() ' Démarrage du thread.
        _thread_doAcqiring.Join() ' Démarrage du thread.
        m_bsControle.ResetCurrentItem()
    End Sub

#End Region

    Private Sub m_bsManoControle_CurrentItemChanged(sender As Object, e As EventArgs) Handles m_bsManoControle.CurrentItemChanged
        SelectionManoControle()
    End Sub


    Private Sub SelectionManoControle()
        If Not IsOK Then
            Exit Sub
        End If
        Dim oMano As ManometreControle
        oMano = m_bsManoControle.Current

        Dim oManoEtalon As ManometreEtalon
        oManoEtalon = m_bsManoEtalon.Current
        Dim oControle As ControleMano

        oControle = oMano.controle
        m_bsControle.Clear()
        m_bsControle.Add(oControle)
        'La Température, Date de vérification et le Mano de controle ne sont pas liés avec le controle
        ' car il doivent être mes même pour TOUS les controle
        oControle.tempAir = tbTemperature.Text
        oControle.DateVerif = dtpDateControle.Value
        oControle.manoEtalon = m_bsManoEtalon.Current.Numeronational
        oControle.idStructure = oMano.idStructure
        oControle.idMano = oMano.numeroNational
        '        oControle.resultat = oMano.etat
        oControle.DateVerif = CSDate.ToCRODIPString(dtpDateControle.Value)
        oControle.setIncertitude(oMano, m_bsManoEtalon.Current)
        ' ValiderSaisie(oControle)
        AfficheControleMano(oControle)

        ValiderSaisie(oControle)


    End Sub

    Private Sub dtpDateControle_Validated(sender As Object, e As EventArgs) Handles dtpDateControle.Validated
        Dim oMano As ManometreControle
        oMano = m_bsManoControle.Current
        If oMano IsNot Nothing Then
            If oMano.controle IsNot Nothing Then
                oMano.controle.DateVerif = CSDate.ToCRODIPString(dtpDateControle.Value)
            End If
        End If
    End Sub


End Class
