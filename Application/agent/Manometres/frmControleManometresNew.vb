Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading
Imports CRODIPAcquisition
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
    Friend WithEvents TextBox39 As TextBox
    Friend WithEvents TextBox40 As TextBox
    Friend WithEvents TextBox41 As TextBox
    Friend WithEvents TextBox42 As TextBox
    Friend WithEvents TextBox43 As TextBox
    Friend WithEvents TextBox44 As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents TextBox55 As TextBox
    Friend WithEvents TextBox56 As TextBox
    Friend WithEvents TextBox61 As TextBox
    Friend WithEvents TextBox62 As TextBox
    Friend WithEvents tlpPressionDecroissante As TableLayoutPanel
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents tbDownMR5 As TextBox
    Friend WithEvents tbDownMR6 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents TextBox18 As TextBox
    Friend WithEvents tbDownMR4 As TextBox
    Friend WithEvents tbDownMR3 As TextBox
    Friend WithEvents TextBox25 As TextBox
    Friend WithEvents TextBox26 As TextBox
    Friend WithEvents TextBox27 As TextBox
    Friend WithEvents TextBox28 As TextBox
    Friend WithEvents TextBox31 As TextBox
    Friend WithEvents TextBox32 As TextBox
    Friend WithEvents TextBox33 As TextBox
    Friend WithEvents TextBox34 As TextBox
    Friend WithEvents tlpPressionCroissant As TableLayoutPanel
    Friend WithEvents tbFondPC6 As TextBox
    Friend WithEvents tbErrAbsPC6 As TextBox
    Friend WithEvents tbFondPC5 As TextBox
    Friend WithEvents tbErrAbsPC5 As TextBox
    Friend WithEvents tbFondPC4 As TextBox
    Friend WithEvents tbErrAbsPC4 As TextBox
    Friend WithEvents tbFondPC3 As TextBox
    Friend WithEvents tbErrAbsPC3 As TextBox
    Friend WithEvents tbFondPC2 As TextBox
    Friend WithEvents tbErrAbsPC2 As TextBox
    Friend WithEvents tbFondPC1 As TextBox
    Friend WithEvents tbErrAbsPC1 As TextBox
    Friend WithEvents tbUpMR2 As TextBox
    Friend WithEvents tbUpMR1 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents tbPCMC1 As TextBox
    Friend WithEvents tbPCMC2 As TextBox
    Friend WithEvents tbPCMC3 As TextBox
    Friend WithEvents tbPCMC4 As TextBox
    Friend WithEvents tbPCMC5 As TextBox
    Friend WithEvents tbPCMC6 As TextBox
    Friend WithEvents tbUpMR3 As TextBox
    Friend WithEvents tbUpMR4 As TextBox
    Friend WithEvents tbUpMR5 As TextBox
    Friend WithEvents tbUpMR6 As TextBox
    Friend WithEvents tbIncertPC1 As TextBox
    Friend WithEvents tbIncertPC2 As TextBox
    Friend WithEvents tbIncertPC3 As TextBox
    Friend WithEvents tbIncertPC4 As TextBox
    Friend WithEvents tbIncertPC5 As TextBox
    Friend WithEvents tbIncertPC6 As TextBox
    Friend WithEvents tbEMTPC1 As TextBox
    Friend WithEvents tbEMTPC2 As TextBox
    Friend WithEvents tbEMTPC3 As TextBox
    Friend WithEvents tbEMTPC4 As TextBox
    Friend WithEvents tbEMTPC5 As TextBox
    Friend WithEvents tbEMTPC6 As TextBox
    Friend WithEvents tbRepeCtrl2 As TextBox
    Friend WithEvents tbRepeCtrl1 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents udRepe1 As NumericUpDown
    Friend WithEvents udRepe2 As NumericUpDown
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
        Me.tbFondPC6 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC6 = New System.Windows.Forms.TextBox()
        Me.tbFondPC5 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC5 = New System.Windows.Forms.TextBox()
        Me.tbFondPC4 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC4 = New System.Windows.Forms.TextBox()
        Me.tbFondPC3 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC3 = New System.Windows.Forms.TextBox()
        Me.tbFondPC2 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC2 = New System.Windows.Forms.TextBox()
        Me.tbFondPC1 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC1 = New System.Windows.Forms.TextBox()
        Me.tbUpMR2 = New System.Windows.Forms.TextBox()
        Me.tbUpMR1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbPCMC1 = New System.Windows.Forms.TextBox()
        Me.tbPCMC2 = New System.Windows.Forms.TextBox()
        Me.tbPCMC3 = New System.Windows.Forms.TextBox()
        Me.tbPCMC4 = New System.Windows.Forms.TextBox()
        Me.tbPCMC5 = New System.Windows.Forms.TextBox()
        Me.tbPCMC6 = New System.Windows.Forms.TextBox()
        Me.tbUpMR3 = New System.Windows.Forms.TextBox()
        Me.tbUpMR4 = New System.Windows.Forms.TextBox()
        Me.tbUpMR5 = New System.Windows.Forms.TextBox()
        Me.tbUpMR6 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC1 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC2 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC3 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC4 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC5 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC6 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC1 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC2 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC3 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC4 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC5 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC6 = New System.Windows.Forms.TextBox()
        Me.tlpPressionDecroissante = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.tbDownMR5 = New System.Windows.Forms.TextBox()
        Me.tbDownMR6 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.tbDownMR4 = New System.Windows.Forms.TextBox()
        Me.tbDownMR3 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.TextBox34 = New System.Windows.Forms.TextBox()
        Me.tlpRepetition = New System.Windows.Forms.TableLayoutPanel()
        Me.tbRepeCtrl2 = New System.Windows.Forms.TextBox()
        Me.tbRepeCtrl1 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox39 = New System.Windows.Forms.TextBox()
        Me.TextBox40 = New System.Windows.Forms.TextBox()
        Me.TextBox41 = New System.Windows.Forms.TextBox()
        Me.TextBox42 = New System.Windows.Forms.TextBox()
        Me.TextBox43 = New System.Windows.Forms.TextBox()
        Me.TextBox44 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TextBox55 = New System.Windows.Forms.TextBox()
        Me.TextBox56 = New System.Windows.Forms.TextBox()
        Me.TextBox61 = New System.Windows.Forms.TextBox()
        Me.TextBox62 = New System.Windows.Forms.TextBox()
        Me.udRepe1 = New System.Windows.Forms.NumericUpDown()
        Me.udRepe2 = New System.Windows.Forms.NumericUpDown()
        Me.Panel_loading = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btn_controleBanc_annuler = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbTemperature = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ImageList_onglets = New System.Windows.Forms.ImageList(Me.components)
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
        CType(Me.udRepe1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udRepe2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btn_controleManos_valider.Enabled = True
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
        Me.lblResultat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "resultat", True))
        Me.lblResultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultat.ForeColor = System.Drawing.Color.Green
        Me.lblResultat.Location = New System.Drawing.Point(761, 263)
        Me.lblResultat.Name = "lblResultat"
        Me.lblResultat.Size = New System.Drawing.Size(224, 111)
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
        Me.labelInfoEtalon_classe.Location = New System.Drawing.Point(864, 202)
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
        Me.labelInfoEtalon_fondEchelle.Location = New System.Drawing.Point(864, 215)
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
        Me.labelInfoEtalon_marque.Location = New System.Drawing.Point(864, 182)
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
        Me.labelInfoEtalon_reference.Location = New System.Drawing.Point(864, 166)
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
        Me.Label38.Location = New System.Drawing.Point(761, 250)
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
        Me.Label32.Location = New System.Drawing.Point(761, 217)
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
        Me.Label33.Location = New System.Drawing.Point(761, 201)
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
        Me.Label34.Location = New System.Drawing.Point(761, 184)
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
        Me.Label35.Location = New System.Drawing.Point(761, 167)
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
        Me.Label37.Location = New System.Drawing.Point(761, 149)
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
        Me.SplitContainer1.SplitterDistance = 33
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
        Me.lbMano.Size = New System.Drawing.Size(33, 562)
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
        Me.tlpGlobal.Size = New System.Drawing.Size(684, 554)
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
        Me.tlpEntete.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203.0!))
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
        Me.tlpEntete.Size = New System.Drawing.Size(678, 60)
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
        Me.Label7.Size = New System.Drawing.Size(258, 28)
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
        Me.Label11.Size = New System.Drawing.Size(197, 29)
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
        Me.tlpPressionCroissant.ColumnCount = 9
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpPressionCroissant.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPressionCroissant.Controls.Add(Me.tbFondPC6, 8, 5)
        Me.tlpPressionCroissant.Controls.Add(Me.tbErrAbsPC6, 7, 5)
        Me.tlpPressionCroissant.Controls.Add(Me.tbFondPC5, 8, 4)
        Me.tlpPressionCroissant.Controls.Add(Me.tbErrAbsPC5, 7, 4)
        Me.tlpPressionCroissant.Controls.Add(Me.tbFondPC4, 8, 3)
        Me.tlpPressionCroissant.Controls.Add(Me.tbErrAbsPC4, 7, 3)
        Me.tlpPressionCroissant.Controls.Add(Me.tbFondPC3, 8, 2)
        Me.tlpPressionCroissant.Controls.Add(Me.tbErrAbsPC3, 7, 2)
        Me.tlpPressionCroissant.Controls.Add(Me.tbFondPC2, 8, 1)
        Me.tlpPressionCroissant.Controls.Add(Me.tbErrAbsPC2, 7, 1)
        Me.tlpPressionCroissant.Controls.Add(Me.tbFondPC1, 8, 0)
        Me.tlpPressionCroissant.Controls.Add(Me.tbErrAbsPC1, 7, 0)
        Me.tlpPressionCroissant.Controls.Add(Me.tbUpMR2, 4, 1)
        Me.tlpPressionCroissant.Controls.Add(Me.tbUpMR1, 4, 0)
        Me.tlpPressionCroissant.Controls.Add(Me.Label19, 0, 0)
        Me.tlpPressionCroissant.Controls.Add(Me.Label12, 1, 0)
        Me.tlpPressionCroissant.Controls.Add(Me.Label13, 1, 1)
        Me.tlpPressionCroissant.Controls.Add(Me.Label14, 1, 2)
        Me.tlpPressionCroissant.Controls.Add(Me.Label16, 1, 3)
        Me.tlpPressionCroissant.Controls.Add(Me.Label17, 1, 4)
        Me.tlpPressionCroissant.Controls.Add(Me.Label18, 1, 5)
        Me.tlpPressionCroissant.Controls.Add(Me.tbPCMC1, 3, 0)
        Me.tlpPressionCroissant.Controls.Add(Me.tbPCMC2, 3, 1)
        Me.tlpPressionCroissant.Controls.Add(Me.tbPCMC3, 3, 2)
        Me.tlpPressionCroissant.Controls.Add(Me.tbPCMC4, 3, 3)
        Me.tlpPressionCroissant.Controls.Add(Me.tbPCMC5, 3, 4)
        Me.tlpPressionCroissant.Controls.Add(Me.tbPCMC6, 3, 5)
        Me.tlpPressionCroissant.Controls.Add(Me.tbUpMR3, 4, 2)
        Me.tlpPressionCroissant.Controls.Add(Me.tbUpMR4, 4, 3)
        Me.tlpPressionCroissant.Controls.Add(Me.tbUpMR5, 4, 4)
        Me.tlpPressionCroissant.Controls.Add(Me.tbUpMR6, 4, 5)
        Me.tlpPressionCroissant.Controls.Add(Me.tbIncertPC1, 5, 0)
        Me.tlpPressionCroissant.Controls.Add(Me.tbIncertPC2, 5, 1)
        Me.tlpPressionCroissant.Controls.Add(Me.tbIncertPC3, 5, 2)
        Me.tlpPressionCroissant.Controls.Add(Me.tbIncertPC4, 5, 3)
        Me.tlpPressionCroissant.Controls.Add(Me.tbIncertPC5, 5, 4)
        Me.tlpPressionCroissant.Controls.Add(Me.tbIncertPC6, 5, 5)
        Me.tlpPressionCroissant.Controls.Add(Me.tbEMTPC1, 6, 0)
        Me.tlpPressionCroissant.Controls.Add(Me.tbEMTPC2, 6, 1)
        Me.tlpPressionCroissant.Controls.Add(Me.tbEMTPC3, 6, 2)
        Me.tlpPressionCroissant.Controls.Add(Me.tbEMTPC4, 6, 3)
        Me.tlpPressionCroissant.Controls.Add(Me.tbEMTPC5, 6, 4)
        Me.tlpPressionCroissant.Controls.Add(Me.tbEMTPC6, 6, 5)
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
        Me.tlpPressionCroissant.Size = New System.Drawing.Size(678, 221)
        Me.tlpPressionCroissant.TabIndex = 15
        '
        'tbFondPC6
        '
        Me.tbFondPC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt6_err_fondEchelle", True))
        Me.tbFondPC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC6.Location = New System.Drawing.Point(568, 184)
        Me.tbFondPC6.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.tbFondPC6.Name = "tbFondPC6"
        Me.tbFondPC6.ReadOnly = True
        Me.tbFondPC6.Size = New System.Drawing.Size(104, 20)
        Me.tbFondPC6.TabIndex = 60
        Me.tbFondPC6.TabStop = False
        '
        'tbErrAbsPC6
        '
        Me.tbErrAbsPC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt6_err_abs", True))
        Me.tbErrAbsPC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC6.Location = New System.Drawing.Point(507, 184)
        Me.tbErrAbsPC6.Name = "tbErrAbsPC6"
        Me.tbErrAbsPC6.ReadOnly = True
        Me.tbErrAbsPC6.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC6.TabIndex = 59
        Me.tbErrAbsPC6.TabStop = False
        '
        'tbFondPC5
        '
        Me.tbFondPC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt5_err_fondEchelle", True))
        Me.tbFondPC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC5.Location = New System.Drawing.Point(568, 148)
        Me.tbFondPC5.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.tbFondPC5.Name = "tbFondPC5"
        Me.tbFondPC5.ReadOnly = True
        Me.tbFondPC5.Size = New System.Drawing.Size(104, 20)
        Me.tbFondPC5.TabIndex = 58
        Me.tbFondPC5.TabStop = False
        '
        'tbErrAbsPC5
        '
        Me.tbErrAbsPC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt5_err_abs", True))
        Me.tbErrAbsPC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC5.Location = New System.Drawing.Point(507, 148)
        Me.tbErrAbsPC5.Name = "tbErrAbsPC5"
        Me.tbErrAbsPC5.ReadOnly = True
        Me.tbErrAbsPC5.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC5.TabIndex = 57
        Me.tbErrAbsPC5.TabStop = False
        '
        'tbFondPC4
        '
        Me.tbFondPC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt4_err_fondEchelle", True))
        Me.tbFondPC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC4.Location = New System.Drawing.Point(568, 112)
        Me.tbFondPC4.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.tbFondPC4.Name = "tbFondPC4"
        Me.tbFondPC4.ReadOnly = True
        Me.tbFondPC4.Size = New System.Drawing.Size(104, 20)
        Me.tbFondPC4.TabIndex = 56
        Me.tbFondPC4.TabStop = False
        '
        'tbErrAbsPC4
        '
        Me.tbErrAbsPC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt4_err_abs", True))
        Me.tbErrAbsPC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC4.Location = New System.Drawing.Point(507, 112)
        Me.tbErrAbsPC4.Name = "tbErrAbsPC4"
        Me.tbErrAbsPC4.ReadOnly = True
        Me.tbErrAbsPC4.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC4.TabIndex = 55
        Me.tbErrAbsPC4.TabStop = False
        '
        'tbFondPC3
        '
        Me.tbFondPC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt3_err_fondEchelle", True))
        Me.tbFondPC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC3.Location = New System.Drawing.Point(568, 76)
        Me.tbFondPC3.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.tbFondPC3.Name = "tbFondPC3"
        Me.tbFondPC3.ReadOnly = True
        Me.tbFondPC3.Size = New System.Drawing.Size(104, 20)
        Me.tbFondPC3.TabIndex = 54
        Me.tbFondPC3.TabStop = False
        '
        'tbErrAbsPC3
        '
        Me.tbErrAbsPC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt3_err_abs", True))
        Me.tbErrAbsPC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC3.Location = New System.Drawing.Point(507, 76)
        Me.tbErrAbsPC3.Name = "tbErrAbsPC3"
        Me.tbErrAbsPC3.ReadOnly = True
        Me.tbErrAbsPC3.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC3.TabIndex = 53
        Me.tbErrAbsPC3.TabStop = False
        '
        'tbFondPC2
        '
        Me.tbFondPC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt2_err_fondEchelle", True))
        Me.tbFondPC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC2.Location = New System.Drawing.Point(568, 40)
        Me.tbFondPC2.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.tbFondPC2.Name = "tbFondPC2"
        Me.tbFondPC2.ReadOnly = True
        Me.tbFondPC2.Size = New System.Drawing.Size(104, 20)
        Me.tbFondPC2.TabIndex = 52
        Me.tbFondPC2.TabStop = False
        '
        'tbErrAbsPC2
        '
        Me.tbErrAbsPC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt2_err_abs", True))
        Me.tbErrAbsPC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC2.Location = New System.Drawing.Point(507, 40)
        Me.tbErrAbsPC2.Name = "tbErrAbsPC2"
        Me.tbErrAbsPC2.ReadOnly = True
        Me.tbErrAbsPC2.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC2.TabIndex = 51
        Me.tbErrAbsPC2.TabStop = False
        '
        'tbFondPC1
        '
        Me.tbFondPC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt1_err_fondEchelle", True))
        Me.tbFondPC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC1.Location = New System.Drawing.Point(568, 4)
        Me.tbFondPC1.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.tbFondPC1.Name = "tbFondPC1"
        Me.tbFondPC1.ReadOnly = True
        Me.tbFondPC1.Size = New System.Drawing.Size(104, 20)
        Me.tbFondPC1.TabIndex = 50
        Me.tbFondPC1.TabStop = False
        '
        'tbErrAbsPC1
        '
        Me.tbErrAbsPC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt1_err_abs", True))
        Me.tbErrAbsPC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC1.Location = New System.Drawing.Point(507, 4)
        Me.tbErrAbsPC1.Name = "tbErrAbsPC1"
        Me.tbErrAbsPC1.ReadOnly = True
        Me.tbErrAbsPC1.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC1.TabIndex = 49
        Me.tbErrAbsPC1.TabStop = False
        '
        'tbUpMR2
        '
        Me.tbUpMR2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt2_pres_manoEtalon", True))
        Me.tbUpMR2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbUpMR2.Location = New System.Drawing.Point(311, 40)
        Me.tbUpMR2.Name = "tbUpMR2"
        Me.tbUpMR2.Size = New System.Drawing.Size(69, 20)
        Me.tbUpMR2.TabIndex = 32
        '
        'tbUpMR1
        '
        Me.tbUpMR1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt1_pres_manoEtalon", True))
        Me.tbUpMR1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbUpMR1.Location = New System.Drawing.Point(311, 4)
        Me.tbUpMR1.Name = "tbUpMR1"
        Me.tbUpMR1.Size = New System.Drawing.Size(69, 20)
        Me.tbUpMR1.TabIndex = 31
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
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(89, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 27)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "1"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(89, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 27)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "2"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(89, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 27)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "3"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(89, 109)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 27)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "4"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(89, 145)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 27)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "5"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(89, 181)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 24)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "6"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbPCMC1
        '
        Me.tbPCMC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt1_pres_manoCtrl", True))
        Me.tbPCMC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC1.Location = New System.Drawing.Point(230, 4)
        Me.tbPCMC1.Name = "tbPCMC1"
        Me.tbPCMC1.ReadOnly = True
        Me.tbPCMC1.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC1.TabIndex = 0
        Me.tbPCMC1.TabStop = False
        '
        'tbPCMC2
        '
        Me.tbPCMC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt2_pres_manoCtrl", True))
        Me.tbPCMC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC2.Location = New System.Drawing.Point(230, 40)
        Me.tbPCMC2.Name = "tbPCMC2"
        Me.tbPCMC2.ReadOnly = True
        Me.tbPCMC2.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC2.TabIndex = 1
        Me.tbPCMC2.TabStop = False
        '
        'tbPCMC3
        '
        Me.tbPCMC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt3_pres_manoCtrl", True))
        Me.tbPCMC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC3.Location = New System.Drawing.Point(230, 76)
        Me.tbPCMC3.Name = "tbPCMC3"
        Me.tbPCMC3.ReadOnly = True
        Me.tbPCMC3.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC3.TabIndex = 2
        Me.tbPCMC3.TabStop = False
        '
        'tbPCMC4
        '
        Me.tbPCMC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt4_pres_manoCtrl", True))
        Me.tbPCMC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC4.Location = New System.Drawing.Point(230, 112)
        Me.tbPCMC4.Name = "tbPCMC4"
        Me.tbPCMC4.ReadOnly = True
        Me.tbPCMC4.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC4.TabIndex = 3
        Me.tbPCMC4.TabStop = False
        '
        'tbPCMC5
        '
        Me.tbPCMC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt5_pres_manoCtrl", True))
        Me.tbPCMC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC5.Location = New System.Drawing.Point(230, 148)
        Me.tbPCMC5.Name = "tbPCMC5"
        Me.tbPCMC5.ReadOnly = True
        Me.tbPCMC5.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC5.TabIndex = 4
        Me.tbPCMC5.TabStop = False
        '
        'tbPCMC6
        '
        Me.tbPCMC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt6_pres_manoCtrl", True))
        Me.tbPCMC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC6.Location = New System.Drawing.Point(230, 184)
        Me.tbPCMC6.Name = "tbPCMC6"
        Me.tbPCMC6.ReadOnly = True
        Me.tbPCMC6.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC6.TabIndex = 5
        Me.tbPCMC6.TabStop = False
        '
        'tbUpMR3
        '
        Me.tbUpMR3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt3_pres_manoEtalon", True))
        Me.tbUpMR3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbUpMR3.Location = New System.Drawing.Point(311, 76)
        Me.tbUpMR3.Name = "tbUpMR3"
        Me.tbUpMR3.Size = New System.Drawing.Size(69, 20)
        Me.tbUpMR3.TabIndex = 33
        '
        'tbUpMR4
        '
        Me.tbUpMR4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt4_pres_manoEtalon", True))
        Me.tbUpMR4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbUpMR4.Location = New System.Drawing.Point(311, 112)
        Me.tbUpMR4.Name = "tbUpMR4"
        Me.tbUpMR4.Size = New System.Drawing.Size(69, 20)
        Me.tbUpMR4.TabIndex = 34
        '
        'tbUpMR5
        '
        Me.tbUpMR5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt5_pres_manoEtalon", True))
        Me.tbUpMR5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbUpMR5.Location = New System.Drawing.Point(311, 148)
        Me.tbUpMR5.Name = "tbUpMR5"
        Me.tbUpMR5.Size = New System.Drawing.Size(69, 20)
        Me.tbUpMR5.TabIndex = 35
        '
        'tbUpMR6
        '
        Me.tbUpMR6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt6_pres_manoEtalon", True))
        Me.tbUpMR6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbUpMR6.Location = New System.Drawing.Point(311, 184)
        Me.tbUpMR6.Name = "tbUpMR6"
        Me.tbUpMR6.Size = New System.Drawing.Size(69, 20)
        Me.tbUpMR6.TabIndex = 36
        '
        'tbIncertPC1
        '
        Me.tbIncertPC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt1_incertitude", True))
        Me.tbIncertPC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC1.Location = New System.Drawing.Point(387, 4)
        Me.tbIncertPC1.Name = "tbIncertPC1"
        Me.tbIncertPC1.ReadOnly = True
        Me.tbIncertPC1.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC1.TabIndex = 37
        Me.tbIncertPC1.TabStop = False
        '
        'tbIncertPC2
        '
        Me.tbIncertPC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt2_incertitude", True))
        Me.tbIncertPC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC2.Location = New System.Drawing.Point(387, 40)
        Me.tbIncertPC2.Name = "tbIncertPC2"
        Me.tbIncertPC2.ReadOnly = True
        Me.tbIncertPC2.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC2.TabIndex = 38
        Me.tbIncertPC2.TabStop = False
        '
        'tbIncertPC3
        '
        Me.tbIncertPC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt3_incertitude", True))
        Me.tbIncertPC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC3.Location = New System.Drawing.Point(387, 76)
        Me.tbIncertPC3.Name = "tbIncertPC3"
        Me.tbIncertPC3.ReadOnly = True
        Me.tbIncertPC3.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC3.TabIndex = 39
        Me.tbIncertPC3.TabStop = False
        '
        'tbIncertPC4
        '
        Me.tbIncertPC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt4_incertitude", True))
        Me.tbIncertPC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC4.Location = New System.Drawing.Point(387, 112)
        Me.tbIncertPC4.Name = "tbIncertPC4"
        Me.tbIncertPC4.ReadOnly = True
        Me.tbIncertPC4.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC4.TabIndex = 40
        Me.tbIncertPC4.TabStop = False
        '
        'tbIncertPC5
        '
        Me.tbIncertPC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt5_incertitude", True))
        Me.tbIncertPC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC5.Location = New System.Drawing.Point(387, 148)
        Me.tbIncertPC5.Name = "tbIncertPC5"
        Me.tbIncertPC5.ReadOnly = True
        Me.tbIncertPC5.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC5.TabIndex = 41
        Me.tbIncertPC5.TabStop = False
        '
        'tbIncertPC6
        '
        Me.tbIncertPC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt6_incertitude", True))
        Me.tbIncertPC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC6.Location = New System.Drawing.Point(387, 184)
        Me.tbIncertPC6.Name = "tbIncertPC6"
        Me.tbIncertPC6.ReadOnly = True
        Me.tbIncertPC6.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC6.TabIndex = 42
        Me.tbIncertPC6.TabStop = False
        '
        'tbEMTPC1
        '
        Me.tbEMTPC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt1_EMT", True))
        Me.tbEMTPC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC1.Location = New System.Drawing.Point(464, 4)
        Me.tbEMTPC1.Name = "tbEMTPC1"
        Me.tbEMTPC1.ReadOnly = True
        Me.tbEMTPC1.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC1.TabIndex = 43
        Me.tbEMTPC1.TabStop = False
        '
        'tbEMTPC2
        '
        Me.tbEMTPC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt2_EMT", True))
        Me.tbEMTPC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC2.Location = New System.Drawing.Point(464, 40)
        Me.tbEMTPC2.Name = "tbEMTPC2"
        Me.tbEMTPC2.ReadOnly = True
        Me.tbEMTPC2.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC2.TabIndex = 44
        Me.tbEMTPC2.TabStop = False
        '
        'tbEMTPC3
        '
        Me.tbEMTPC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt3_EMT", True))
        Me.tbEMTPC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC3.Location = New System.Drawing.Point(464, 76)
        Me.tbEMTPC3.Name = "tbEMTPC3"
        Me.tbEMTPC3.ReadOnly = True
        Me.tbEMTPC3.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC3.TabIndex = 45
        Me.tbEMTPC3.TabStop = False
        '
        'tbEMTPC4
        '
        Me.tbEMTPC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt4_EMT", True))
        Me.tbEMTPC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC4.Location = New System.Drawing.Point(464, 112)
        Me.tbEMTPC4.Name = "tbEMTPC4"
        Me.tbEMTPC4.ReadOnly = True
        Me.tbEMTPC4.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC4.TabIndex = 46
        Me.tbEMTPC4.TabStop = False
        '
        'tbEMTPC5
        '
        Me.tbEMTPC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt5_EMT", True))
        Me.tbEMTPC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC5.Location = New System.Drawing.Point(464, 148)
        Me.tbEMTPC5.Name = "tbEMTPC5"
        Me.tbEMTPC5.ReadOnly = True
        Me.tbEMTPC5.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC5.TabIndex = 47
        Me.tbEMTPC5.TabStop = False
        '
        'tbEMTPC6
        '
        Me.tbEMTPC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "up_pt6_EMT", True))
        Me.tbEMTPC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC6.Location = New System.Drawing.Point(464, 184)
        Me.tbEMTPC6.Name = "tbEMTPC6"
        Me.tbEMTPC6.ReadOnly = True
        Me.tbEMTPC6.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC6.TabIndex = 48
        Me.tbEMTPC6.TabStop = False
        '
        'tlpPressionDecroissante
        '
        Me.tlpPressionDecroissante.BackColor = System.Drawing.SystemColors.Control
        Me.tlpPressionDecroissante.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpPressionDecroissante.ColumnCount = 9
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpPressionDecroissante.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox5, 8, 3)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox6, 7, 3)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox7, 8, 2)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox8, 7, 2)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox9, 8, 1)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox10, 7, 1)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox11, 8, 0)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox12, 7, 0)
        Me.tlpPressionDecroissante.Controls.Add(Me.tbDownMR5, 4, 1)
        Me.tlpPressionDecroissante.Controls.Add(Me.tbDownMR6, 4, 0)
        Me.tlpPressionDecroissante.Controls.Add(Me.Label20, 0, 0)
        Me.tlpPressionDecroissante.Controls.Add(Me.Label21, 1, 0)
        Me.tlpPressionDecroissante.Controls.Add(Me.Label22, 1, 1)
        Me.tlpPressionDecroissante.Controls.Add(Me.Label23, 1, 2)
        Me.tlpPressionDecroissante.Controls.Add(Me.Label24, 1, 3)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox15, 3, 0)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox16, 3, 1)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox17, 3, 2)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox18, 3, 3)
        Me.tlpPressionDecroissante.Controls.Add(Me.tbDownMR4, 4, 2)
        Me.tlpPressionDecroissante.Controls.Add(Me.tbDownMR3, 4, 3)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox25, 5, 0)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox26, 5, 1)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox27, 5, 2)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox28, 5, 3)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox31, 6, 0)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox32, 6, 1)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox33, 6, 2)
        Me.tlpPressionDecroissante.Controls.Add(Me.TextBox34, 6, 3)
        Me.tlpPressionDecroissante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPressionDecroissante.Location = New System.Drawing.Point(3, 290)
        Me.tlpPressionDecroissante.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpPressionDecroissante.Name = "tlpPressionDecroissante"
        Me.tlpPressionDecroissante.RowCount = 4
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPressionDecroissante.Size = New System.Drawing.Size(678, 184)
        Me.tlpPressionDecroissante.TabIndex = 16
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt3_err_fondEchelle", True))
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Location = New System.Drawing.Point(568, 139)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(104, 20)
        Me.TextBox5.TabIndex = 56
        Me.TextBox5.TabStop = False
        '
        'TextBox6
        '
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt3_err_abs", True))
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Location = New System.Drawing.Point(507, 139)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(54, 20)
        Me.TextBox6.TabIndex = 55
        Me.TextBox6.TabStop = False
        '
        'TextBox7
        '
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt4_err_fondEchelle", True))
        Me.TextBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox7.Location = New System.Drawing.Point(568, 94)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(104, 20)
        Me.TextBox7.TabIndex = 54
        Me.TextBox7.TabStop = False
        '
        'TextBox8
        '
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt4_err_abs", True))
        Me.TextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox8.Location = New System.Drawing.Point(507, 94)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(54, 20)
        Me.TextBox8.TabIndex = 53
        Me.TextBox8.TabStop = False
        '
        'TextBox9
        '
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_err_fondEchelle", True))
        Me.TextBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox9.Location = New System.Drawing.Point(568, 49)
        Me.TextBox9.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(104, 20)
        Me.TextBox9.TabIndex = 52
        Me.TextBox9.TabStop = False
        '
        'TextBox10
        '
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_err_abs", True))
        Me.TextBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox10.Location = New System.Drawing.Point(507, 49)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(54, 20)
        Me.TextBox10.TabIndex = 51
        Me.TextBox10.TabStop = False
        '
        'TextBox11
        '
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_err_fondEchelle", True))
        Me.TextBox11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox11.Location = New System.Drawing.Point(568, 4)
        Me.TextBox11.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(104, 20)
        Me.TextBox11.TabIndex = 50
        Me.TextBox11.TabStop = False
        '
        'TextBox12
        '
        Me.TextBox12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_err_abs", True))
        Me.TextBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox12.Location = New System.Drawing.Point(507, 4)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(54, 20)
        Me.TextBox12.TabIndex = 49
        Me.TextBox12.TabStop = False
        '
        'tbDownMR5
        '
        Me.tbDownMR5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_pres_manoEtalon", True))
        Me.tbDownMR5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbDownMR5.Location = New System.Drawing.Point(311, 49)
        Me.tbDownMR5.Name = "tbDownMR5"
        Me.tbDownMR5.Size = New System.Drawing.Size(69, 20)
        Me.tbDownMR5.TabIndex = 32
        '
        'tbDownMR6
        '
        Me.tbDownMR6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_pres_manoEtalon", True))
        Me.tbDownMR6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbDownMR6.Location = New System.Drawing.Point(311, 4)
        Me.tbDownMR6.Name = "tbDownMR6"
        Me.tbDownMR6.Size = New System.Drawing.Size(69, 20)
        Me.tbDownMR6.TabIndex = 31
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
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(89, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 27)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "6"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(89, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 27)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "5"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(89, 91)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 27)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "4"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(89, 136)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 27)
        Me.Label24.TabIndex = 3
        Me.Label24.Text = "3"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox15
        '
        Me.TextBox15.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_pres_manoCtrl", True))
        Me.TextBox15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox15.Location = New System.Drawing.Point(230, 4)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(74, 20)
        Me.TextBox15.TabIndex = 0
        Me.TextBox15.TabStop = False
        '
        'TextBox16
        '
        Me.TextBox16.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_pres_manoCtrl", True))
        Me.TextBox16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox16.Location = New System.Drawing.Point(230, 49)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(74, 20)
        Me.TextBox16.TabIndex = 1
        Me.TextBox16.TabStop = False
        '
        'TextBox17
        '
        Me.TextBox17.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt4_pres_manoCtrl", True))
        Me.TextBox17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox17.Location = New System.Drawing.Point(230, 94)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.Size = New System.Drawing.Size(74, 20)
        Me.TextBox17.TabIndex = 2
        Me.TextBox17.TabStop = False
        '
        'TextBox18
        '
        Me.TextBox18.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt3_pres_manoCtrl", True))
        Me.TextBox18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox18.Location = New System.Drawing.Point(230, 139)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.ReadOnly = True
        Me.TextBox18.Size = New System.Drawing.Size(74, 20)
        Me.TextBox18.TabIndex = 3
        Me.TextBox18.TabStop = False
        '
        'tbDownMR4
        '
        Me.tbDownMR4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt4_pres_manoEtalon", True))
        Me.tbDownMR4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbDownMR4.Location = New System.Drawing.Point(311, 94)
        Me.tbDownMR4.Name = "tbDownMR4"
        Me.tbDownMR4.Size = New System.Drawing.Size(69, 20)
        Me.tbDownMR4.TabIndex = 33
        '
        'tbDownMR3
        '
        Me.tbDownMR3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt3_pres_manoEtalon", True))
        Me.tbDownMR3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbDownMR3.Location = New System.Drawing.Point(311, 139)
        Me.tbDownMR3.Name = "tbDownMR3"
        Me.tbDownMR3.Size = New System.Drawing.Size(69, 20)
        Me.tbDownMR3.TabIndex = 34
        '
        'TextBox25
        '
        Me.TextBox25.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_incertitude", True))
        Me.TextBox25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox25.Location = New System.Drawing.Point(387, 4)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.ReadOnly = True
        Me.TextBox25.Size = New System.Drawing.Size(70, 20)
        Me.TextBox25.TabIndex = 37
        Me.TextBox25.TabStop = False
        '
        'TextBox26
        '
        Me.TextBox26.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_incertitude", True))
        Me.TextBox26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox26.Location = New System.Drawing.Point(387, 49)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.ReadOnly = True
        Me.TextBox26.Size = New System.Drawing.Size(70, 20)
        Me.TextBox26.TabIndex = 38
        Me.TextBox26.TabStop = False
        '
        'TextBox27
        '
        Me.TextBox27.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt4_incertitude", True))
        Me.TextBox27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox27.Location = New System.Drawing.Point(387, 94)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.ReadOnly = True
        Me.TextBox27.Size = New System.Drawing.Size(70, 20)
        Me.TextBox27.TabIndex = 39
        Me.TextBox27.TabStop = False
        '
        'TextBox28
        '
        Me.TextBox28.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt3_incertitude", True))
        Me.TextBox28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox28.Location = New System.Drawing.Point(387, 139)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.ReadOnly = True
        Me.TextBox28.Size = New System.Drawing.Size(70, 20)
        Me.TextBox28.TabIndex = 40
        Me.TextBox28.TabStop = False
        '
        'TextBox31
        '
        Me.TextBox31.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_EMT", True))
        Me.TextBox31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox31.Location = New System.Drawing.Point(464, 4)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.ReadOnly = True
        Me.TextBox31.Size = New System.Drawing.Size(36, 20)
        Me.TextBox31.TabIndex = 43
        Me.TextBox31.TabStop = False
        '
        'TextBox32
        '
        Me.TextBox32.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_EMT", True))
        Me.TextBox32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox32.Location = New System.Drawing.Point(464, 49)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.ReadOnly = True
        Me.TextBox32.Size = New System.Drawing.Size(36, 20)
        Me.TextBox32.TabIndex = 44
        Me.TextBox32.TabStop = False
        '
        'TextBox33
        '
        Me.TextBox33.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt4_EMT", True))
        Me.TextBox33.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox33.Location = New System.Drawing.Point(464, 94)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.ReadOnly = True
        Me.TextBox33.Size = New System.Drawing.Size(36, 20)
        Me.TextBox33.TabIndex = 45
        Me.TextBox33.TabStop = False
        '
        'TextBox34
        '
        Me.TextBox34.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt3_EMT", True))
        Me.TextBox34.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox34.Location = New System.Drawing.Point(464, 139)
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.ReadOnly = True
        Me.TextBox34.Size = New System.Drawing.Size(36, 20)
        Me.TextBox34.TabIndex = 46
        Me.TextBox34.TabStop = False
        '
        'tlpRepetition
        '
        Me.tlpRepetition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRepetition.BackColor = System.Drawing.SystemColors.Control
        Me.tlpRepetition.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpRepetition.ColumnCount = 9
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpRepetition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRepetition.Controls.Add(Me.tbRepeCtrl2, 3, 1)
        Me.tlpRepetition.Controls.Add(Me.tbRepeCtrl1, 3, 0)
        Me.tlpRepetition.Controls.Add(Me.Label26, 0, 0)
        Me.tlpRepetition.Controls.Add(Me.TextBox39, 8, 1)
        Me.tlpRepetition.Controls.Add(Me.TextBox40, 7, 1)
        Me.tlpRepetition.Controls.Add(Me.TextBox41, 8, 0)
        Me.tlpRepetition.Controls.Add(Me.TextBox42, 7, 0)
        Me.tlpRepetition.Controls.Add(Me.TextBox43, 4, 1)
        Me.tlpRepetition.Controls.Add(Me.TextBox44, 4, 0)
        Me.tlpRepetition.Controls.Add(Me.Label41, 1, 0)
        Me.tlpRepetition.Controls.Add(Me.Label42, 1, 1)
        Me.tlpRepetition.Controls.Add(Me.TextBox55, 5, 0)
        Me.tlpRepetition.Controls.Add(Me.TextBox56, 5, 1)
        Me.tlpRepetition.Controls.Add(Me.TextBox61, 6, 0)
        Me.tlpRepetition.Controls.Add(Me.TextBox62, 6, 1)
        Me.tlpRepetition.Controls.Add(Me.udRepe1, 2, 0)
        Me.tlpRepetition.Controls.Add(Me.udRepe2, 2, 1)
        Me.tlpRepetition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRepetition.Location = New System.Drawing.Point(3, 477)
        Me.tlpRepetition.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpRepetition.Name = "tlpRepetition"
        Me.tlpRepetition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRepetition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRepetition.Size = New System.Drawing.Size(678, 74)
        Me.tlpRepetition.TabIndex = 17
        '
        'tbRepeCtrl2
        '
        Me.tbRepeCtrl2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt2_pres_manoCtrl", True))
        Me.tbRepeCtrl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbRepeCtrl2.Location = New System.Drawing.Point(230, 32)
        Me.tbRepeCtrl2.Name = "tbRepeCtrl2"
        Me.tbRepeCtrl2.ReadOnly = True
        Me.tbRepeCtrl2.Size = New System.Drawing.Size(74, 20)
        Me.tbRepeCtrl2.TabIndex = 57
        Me.tbRepeCtrl2.TabStop = False
        '
        'tbRepeCtrl1
        '
        Me.tbRepeCtrl1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt2_pres_manoCtrl", True))
        Me.tbRepeCtrl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbRepeCtrl1.Location = New System.Drawing.Point(230, 4)
        Me.tbRepeCtrl1.Name = "tbRepeCtrl1"
        Me.tbRepeCtrl1.ReadOnly = True
        Me.tbRepeCtrl1.Size = New System.Drawing.Size(74, 20)
        Me.tbRepeCtrl1.TabIndex = 56
        Me.tbRepeCtrl1.TabStop = False
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
        'TextBox39
        '
        Me.TextBox39.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_err_fondEchelle", True))
        Me.TextBox39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox39.Location = New System.Drawing.Point(568, 32)
        Me.TextBox39.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.ReadOnly = True
        Me.TextBox39.Size = New System.Drawing.Size(104, 20)
        Me.TextBox39.TabIndex = 52
        Me.TextBox39.TabStop = False
        '
        'TextBox40
        '
        Me.TextBox40.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_err_abs", True))
        Me.TextBox40.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox40.Location = New System.Drawing.Point(507, 32)
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.ReadOnly = True
        Me.TextBox40.Size = New System.Drawing.Size(54, 20)
        Me.TextBox40.TabIndex = 51
        Me.TextBox40.TabStop = False
        '
        'TextBox41
        '
        Me.TextBox41.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_err_fondEchelle", True))
        Me.TextBox41.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox41.Location = New System.Drawing.Point(568, 4)
        Me.TextBox41.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.ReadOnly = True
        Me.TextBox41.Size = New System.Drawing.Size(104, 20)
        Me.TextBox41.TabIndex = 50
        Me.TextBox41.TabStop = False
        '
        'TextBox42
        '
        Me.TextBox42.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_err_abs", True))
        Me.TextBox42.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox42.Location = New System.Drawing.Point(507, 4)
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.ReadOnly = True
        Me.TextBox42.Size = New System.Drawing.Size(54, 20)
        Me.TextBox42.TabIndex = 49
        Me.TextBox42.TabStop = False
        '
        'TextBox43
        '
        Me.TextBox43.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_pres_manoEtalon", True))
        Me.TextBox43.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox43.Location = New System.Drawing.Point(311, 32)
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.Size = New System.Drawing.Size(69, 20)
        Me.TextBox43.TabIndex = 32
        '
        'TextBox44
        '
        Me.TextBox44.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_pres_manoEtalon", True))
        Me.TextBox44.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox44.Location = New System.Drawing.Point(311, 4)
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Size = New System.Drawing.Size(69, 20)
        Me.TextBox44.TabIndex = 31
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(89, 1)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(52, 27)
        Me.Label41.TabIndex = 0
        Me.Label41.Text = "6"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(89, 29)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(52, 27)
        Me.Label42.TabIndex = 1
        Me.Label42.Text = "5"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox55
        '
        Me.TextBox55.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_incertitude", True))
        Me.TextBox55.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox55.Location = New System.Drawing.Point(387, 4)
        Me.TextBox55.Name = "TextBox55"
        Me.TextBox55.ReadOnly = True
        Me.TextBox55.Size = New System.Drawing.Size(70, 20)
        Me.TextBox55.TabIndex = 37
        Me.TextBox55.TabStop = False
        '
        'TextBox56
        '
        Me.TextBox56.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_incertitude", True))
        Me.TextBox56.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox56.Location = New System.Drawing.Point(387, 32)
        Me.TextBox56.Name = "TextBox56"
        Me.TextBox56.ReadOnly = True
        Me.TextBox56.Size = New System.Drawing.Size(70, 20)
        Me.TextBox56.TabIndex = 38
        Me.TextBox56.TabStop = False
        '
        'TextBox61
        '
        Me.TextBox61.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt6_EMT", True))
        Me.TextBox61.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox61.Location = New System.Drawing.Point(464, 4)
        Me.TextBox61.Name = "TextBox61"
        Me.TextBox61.ReadOnly = True
        Me.TextBox61.Size = New System.Drawing.Size(36, 20)
        Me.TextBox61.TabIndex = 43
        Me.TextBox61.TabStop = False
        '
        'TextBox62
        '
        Me.TextBox62.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, "down_pt5_EMT", True))
        Me.TextBox62.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox62.Location = New System.Drawing.Point(464, 32)
        Me.TextBox62.Name = "TextBox62"
        Me.TextBox62.ReadOnly = True
        Me.TextBox62.Size = New System.Drawing.Size(36, 20)
        Me.TextBox62.TabIndex = 44
        Me.TextBox62.TabStop = False
        '
        'udRepe1
        '
        Me.udRepe1.Location = New System.Drawing.Point(149, 4)
        Me.udRepe1.Name = "udRepe1"
        Me.udRepe1.Size = New System.Drawing.Size(74, 20)
        Me.udRepe1.TabIndex = 54
        '
        'udRepe2
        '
        Me.udRepe2.Location = New System.Drawing.Point(149, 32)
        Me.udRepe2.Name = "udRepe2"
        Me.udRepe2.Size = New System.Drawing.Size(74, 20)
        Me.udRepe2.TabIndex = 55
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
        Me.tlpPressionCroissant.PerformLayout()
        Me.tlpPressionDecroissante.ResumeLayout(False)
        Me.tlpPressionDecroissante.PerformLayout()
        Me.tlpRepetition.ResumeLayout(False)
        Me.tlpRepetition.PerformLayout()
        CType(Me.udRepe1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udRepe2, System.ComponentModel.ISupportInitialize).EndInit()
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


        Dim lstBanc As List(Of Banc) = BancManager.getBancByAgent(m_oAgent)



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
            oManoC.controle = New ControleMano(oManoC, m_oAgent)
            m_bsManoControle.Add(oManoC)
        Next
        'm_bsManoControle.AddNew()
        m_bsManoControle.MoveLast()

        Dim lstPressionCtrl As List(Of PressionCtrl)
        lstPressionCtrl = New List(Of PressionCtrl)
        Dim oPres As PressionCtrl
        oPres = New PressionCtrl
        oPres.Type = "CROISSANT"
        oPres.Num = 1
        oPres.Pression = 8
        oPres.Incertitude = 0.11
        oPres.EMT = 0.22
        oPres.Err = 0.33
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "CROISSANT"
        oPres.Num = 2
        oPres.Pression = 1
        oPres.Incertitude = 0.12
        oPres.EMT = 0.222
        oPres.Err = 0.332
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "CROISSANT"
        oPres.Num = 3
        oPres.Pression = 2
        oPres.Incertitude = 0.13
        oPres.EMT = 0.223
        oPres.Err = 0.333
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "CROISSANT"
        oPres.Num = 4
        oPres.Pression = 4
        oPres.Incertitude = 0.13
        oPres.EMT = 0.223
        oPres.Err = 0.333
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "CROISSANT"
        oPres.Num = 5
        oPres.Pression = 6
        oPres.Incertitude = 0.13
        oPres.EMT = 0.223
        oPres.Err = 0.333
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "CROISSANT"
        oPres.Num = 6
        oPres.Pression = 8
        oPres.Incertitude = 0.13
        oPres.EMT = 0.223
        oPres.Err = 0.333
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)


        oPres = New PressionCtrl
        oPres.Type = "DECROISSANT"
        oPres.Num = 1
        oPres.Pression = 8
        oPres.Incertitude = 0.11
        oPres.EMT = 0.22
        oPres.Err = 0.33
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "DECROISSANT"
        oPres.Num = 2
        oPres.Pression = 7
        oPres.Incertitude = 0.12
        oPres.EMT = 0.222
        oPres.Err = 0.332
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "DECROISSANT"
        oPres.Num = 3
        oPres.Pression = 6
        oPres.Incertitude = 0.13
        oPres.EMT = 0.223
        oPres.Err = 0.333
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "DECROISSANT"
        oPres.Num = 4
        oPres.Pression = 4
        oPres.Incertitude = 0.13
        oPres.EMT = 0.223
        oPres.Err = 0.333
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "DECROISSANT"
        oPres.Num = 5
        oPres.Pression = 3
        oPres.Incertitude = 0.13
        oPres.EMT = 0.223
        oPres.Err = 0.333
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        oPres = New PressionCtrl
        oPres.Type = "REGUL"
        oPres.Num = 1
        oPres.Pression = 0.1
        oPres.Incertitude = 0.11
        oPres.EMT = 0.22
        oPres.Err = 0.33
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)
        oPres = New PressionCtrl
        oPres.Type = "REGUL"
        oPres.Num = 2
        oPres.Pression = 0.12
        oPres.Incertitude = 0.12
        oPres.EMT = 0.222
        oPres.Err = 0.332
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)
        oPres = New PressionCtrl
        oPres.Type = "REGUL"
        oPres.Num = 3
        oPres.Pression = 0.13
        oPres.Incertitude = 0.13
        oPres.EMT = 0.223
        oPres.Err = 0.333
        oPres.FondEchelle = "5"
        lstPressionCtrl.Add(oPres)

        'Trt des pression croissantes
        '-----------------------------------
        Me.tlpPressionCroissant.Controls.Clear()
        Me.tlpPressionCroissant.RowCount = 0
        Me.tlpPressionCroissant.RowStyles.Clear()
        'Label Croissant
        'TODO créer le Label
        Me.tlpPressionCroissant.Controls.Add(Me.Label19, 0, 0)
        'Trt des répétitions
        Dim lst = lstPressionCtrl.Where(Function(op) As Boolean
                                            Return op.Type = "CROISSANT"
                                        End Function)
        For Each oP As PressionCtrl In lst
            AjouteLigne(tlpPressionCroissant, oP.Type)
        Next
        Me.tlpPressionCroissant.RowStyles.Clear()
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66917!))
        Me.tlpPressionCroissant.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66617!))

        Me.tlpPressionCroissant.SetRowSpan(Me.Label19, tlpPressionCroissant.RowCount)
        'Suppression de la Col textBox
        tlpPressionCroissant.ColumnStyles().Item(3).SizeType = SizeType.Absolute
        tlpPressionCroissant.ColumnStyles().Item(3).Width = 0

        'Trt des pression décoirssantes
        '-----------------------------------
        Me.tlpPressionDecroissante.Controls.Clear()
        Me.tlpPressionDecroissante.RowCount = 0
        Me.tlpPressionDecroissante.RowStyles.Clear()
        'Label Croissant
        'TODO créer le Label
        Me.tlpPressionDecroissante.Controls.Add(Me.Label20, 0, 0)
        lst = lstPressionCtrl.Where(Function(op) As Boolean
                                        Return op.Type = "DECROISSANT"
                                    End Function)
        For Each oP As PressionCtrl In lst
            AjouteLigne(tlpPressionDecroissante, oP.Type)
        Next
        Me.tlpPressionDecroissante.RowStyles.Clear()
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPressionDecroissante.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))


        Me.tlpPressionCroissant.SetRowSpan(Me.Label20, tlpPressionDecroissante.RowCount)
        'Suppression de la Col textBox
        tlpPressionDecroissante.ColumnStyles().Item(3).SizeType = SizeType.Absolute
        tlpPressionDecroissante.ColumnStyles().Item(3).Width = 0



        'Trt des répétitions
        '------------------------
        Me.tlpRepetition.Controls.Clear()
        Me.tlpRepetition.RowCount = 0
        Me.tlpRepetition.RowStyles.Clear()
        'Label Repetition
        Me.tlpRepetition.Controls.Add(Me.Label26, 0, 0)

        lst = lstPressionCtrl.Where(Function(op) As Boolean
                                        Return op.Type = "REGUL"
                                    End Function)
        For Each oP As PressionCtrl In lst
            AjouteLigne(tlpRepetition, oP.Type)
        Next
        Me.tlpRepetition.RowStyles.Clear()
        Me.tlpRepetition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tlpRepetition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tlpRepetition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33!))

        Me.tlpRepetition.SetRowSpan(Me.Label26, tlpRepetition.RowCount)

        'Suppression de la Col textBox
        tlpRepetition.ColumnStyles().Item(3).SizeType = SizeType.Absolute
        tlpRepetition.ColumnStyles().Item(3).Width = 0


    End Sub

    Private Sub AjouteLigne(pTableLayoutPanel As TableLayoutPanel, pType As String)
        Dim Prefixe As String = ""
        Select Case pType
            Case "REGUL"
                Prefixe = "down"
            Case "DECROISSANT"
                Prefixe = "down"
            Case "CROISSANT"
                Prefixe = "up"
        End Select

        Dim NumLigne As Integer
        pTableLayoutPanel.RowCount = pTableLayoutPanel.RowCount + 1
        pTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())

        NumLigne = pTableLayoutPanel.RowCount - 1 'les numereos de ligne sont 0 index 

        Dim oLbl As Label = New Label()
        oLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        oLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        oLbl.Text = NumLigne + 1
        oLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        oLbl.Dock = DockStyle.Fill
        pTableLayoutPanel.Controls.Add(oLbl, 1, NumLigne)

        Dim oNup As NumericUpDown
        oNup = New System.Windows.Forms.NumericUpDown()
        oNup.Dock = DockStyle.Fill
        oNup.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, Prefixe & "_pt" & NumLigne + 1 & "_pres_manoCtrl", True))
        pTableLayoutPanel.Controls.Add(oNup, 2, NumLigne)

        Dim otb As TextBox
        otb = New TextBox()
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        otb.ReadOnly = True
        otb.TabStop = False
        otb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, Prefixe & "_pt" & NumLigne + 1 & "_pres_manoCtrl", True))
        pTableLayoutPanel.Controls.Add(otb, 3, NumLigne)

        otb = New TextBox
        otb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, Prefixe & "_pt" & NumLigne + 1 & "_pres_manoEtalon", True))
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 4, NumLigne)
        otb = New TextBox
        otb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, Prefixe & "_pt" & NumLigne + 1 & "_incertitude", True))
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 5, NumLigne)
        otb = New TextBox
        otb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, Prefixe & "_pt" & NumLigne + 1 & "_EMT", True))
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 6, NumLigne)
        otb = New TextBox
        otb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, Prefixe & "_pt" & NumLigne + 1 & "_err_abs", True))
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 7, NumLigne)
        otb = New TextBox
        otb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControle, Prefixe & "_pt" & NumLigne + 1 & "_err_fondEchelle", True))
        otb.Dock = System.Windows.Forms.DockStyle.Fill
        pTableLayoutPanel.Controls.Add(otb, 8, NumLigne)
    End Sub


#Region " Calculs "

    ' Test si le mano est fiable
    Public Function checkMano(oControle As ControleMano) As Boolean

        Dim isFiable As Boolean = False

        If isSaisieComplete() Then
            If oControle.up_pt1_conformite = "1" And
                oControle.up_pt2_conformite = "1" And
                oControle.up_pt3_conformite = "1" And
                oControle.up_pt4_conformite = "1" And
                oControle.up_pt5_conformite = "1" And
                oControle.up_pt6_conformite = "1" And
                oControle.down_pt1_conformite = "1" And
                oControle.down_pt2_conformite = "1" And
                oControle.down_pt3_conformite = "1" And
                oControle.down_pt4_conformite = "1" And
                oControle.down_pt5_conformite = "1" And
                oControle.down_pt6_conformite = "1" Then

                isFiable = True
            End If

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
            If oControle.up_pt1_conformite = "" Or
                oControle.up_pt2_conformite = "" Or
                oControle.up_pt3_conformite = "" Or
                oControle.up_pt4_conformite = "" Or
                oControle.up_pt5_conformite = "" Or
                oControle.up_pt6_conformite = "" Or
                 oControle.down_pt1_conformite = "" Or
                oControle.down_pt2_conformite = "" Or
                oControle.down_pt3_conformite = "" Or
                oControle.down_pt4_conformite = "" Or
                oControle.down_pt5_conformite = "" Or
                oControle.down_pt6_conformite = "" Then

                bisSaisieComplete = False
            End If

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
                oCtrlMano = curManoControle.controle
                If oCtrlMano IsNot Nothing Then
                    oCtrlMano.manoEtalon = oManoEtalon.numeroNational
                    'On met a jour le manometreControle
                    If curManoControle.isUpdated Then

                        curManoControle.dateDernierControle = oCtrlMano.DateVerif
                        curManoControle.dateModificationAgent = Date.Now
                        CSDebug.dispInfo("frmControleManager.EnregistrerLesControles : Enregistrer un Mano ")
                        ManometreControleManager.save(curManoControle)


                        ' On enregistre les mesures

                        '########################################################
                        ' On récupère les controles
                        oCtrlMano.PressionControle = oCtrlMano.up_pt1_pres_manoCtrl & "|" &
                                                        oCtrlMano.up_pt2_pres_manoCtrl & "|" &
                                                        oCtrlMano.up_pt3_pres_manoCtrl & "|" &
                                                        oCtrlMano.up_pt4_pres_manoCtrl & "|" &
                                                        oCtrlMano.up_pt5_pres_manoCtrl & "|" &
                                                        oCtrlMano.up_pt6_pres_manoCtrl & "|" &
                                                        oCtrlMano.down_pt1_pres_manoCtrl & "|" &
                                                        oCtrlMano.down_pt2_pres_manoCtrl & "|" &
                                                        oCtrlMano.down_pt3_pres_manoCtrl & "|" &
                                                        oCtrlMano.down_pt4_pres_manoCtrl & "|" &
                                                        oCtrlMano.down_pt5_pres_manoCtrl & "|" &
                                                        oCtrlMano.down_pt6_pres_manoCtrl

                        oCtrlMano.ValeursMesurees = oCtrlMano.up_pt1_pres_manoEtalon & "|" &
                                                        oCtrlMano.up_pt2_pres_manoEtalon & "|" &
                                                        oCtrlMano.up_pt3_pres_manoEtalon & "|" &
                                                        oCtrlMano.up_pt4_pres_manoEtalon & "|" &
                                                        oCtrlMano.up_pt5_pres_manoEtalon & "|" &
                                                        oCtrlMano.up_pt6_pres_manoEtalon & "|" &
                                                        oCtrlMano.down_pt1_pres_manoEtalon & "|" &
                                                        oCtrlMano.down_pt2_pres_manoEtalon & "|" &
                                                        oCtrlMano.down_pt3_pres_manoEtalon & "|" &
                                                        oCtrlMano.down_pt4_pres_manoEtalon & "|" &
                                                        oCtrlMano.down_pt5_pres_manoEtalon & "|" &
                                                        oCtrlMano.down_pt6_pres_manoEtalon
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
        Dim oCtrl As New ControleMano()
        Dim oEtat As New EtatFVManoGrpah(oCtrl)
        oEtat.genereEtat(True)
        oEtat.Open()

        'If tbTemperature.Text <> "" And cbx_manometresEtalon.Text <> "" Then
        '    If isSaisieComplete() Then
        '        Me.Cursor = Cursors.WaitCursor
        '        EnregistrerLesControles()
        '        Me.Cursor = Cursors.Default
        '        TryCast(MdiParent, parentContener).ReturnToAccueil()
        '    End If
        'Else
        '    MsgBox("Veuillez remplir le champ température pour continuer", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
        'End If
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

    Private Function calcErrAbs(pPressManoctrl As String, pPressManoEtalon As String) As String
        Dim dErr As Double
        If Not String.IsNullOrEmpty(pPressManoctrl) And Not String.IsNullOrEmpty(pPressManoEtalon) Then
            dErr = Math.Round(Math.Abs(GlobalsCRODIP.StringToDouble(pPressManoctrl) - GlobalsCRODIP.StringToDouble(pPressManoEtalon)), 3)
            Return dErr.ToString("####0.000")
        Else
            Return ""
        End If
    End Function
    Private Function calcErrFond(pPressManoctrl As String, pPressManoEtalon As String, pFond As String) As String
        Dim dErr As Double
        If Not String.IsNullOrEmpty(pPressManoctrl) And Not String.IsNullOrEmpty(pPressManoEtalon) And Not String.IsNullOrEmpty(pFond) Then
            dErr = Math.Round(Math.Abs(GlobalsCRODIP.StringToDouble(pPressManoctrl) - GlobalsCRODIP.StringToDouble(pPressManoEtalon)) * 100 / GlobalsCRODIP.StringToDouble(pFond), 3)
            Return dErr.ToString("####0.000")
        Else
            Return ""
        End If
    End Function
    Private Function calcConformite(pErrAbs As String, pEMT As String) As String
        If Not String.IsNullOrEmpty(pErrAbs) And Not String.IsNullOrEmpty(pEMT) Then
            If GlobalsCRODIP.StringToDouble(pErrAbs) > GlobalsCRODIP.StringToDouble(pEMT) Then
                Return "0" ' NOK
            Else
                Return "1" 'OK
            End If
        Else
            Return ""
        End If
    End Function
    ' Calcul au chagement de contenu
    Private Sub saisiePressionManoReferenceup1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.up_pt1_err_abs = calcErrAbs(oControle.up_pt1_pres_manoCtrl, oControle.up_pt1_pres_manoEtalon)
            oControle.up_pt1_err_fondEchelle = calcErrFond(oControle.up_pt1_pres_manoCtrl, oControle.up_pt1_pres_manoEtalon, oManoC.fondEchelle)
            oControle.up_pt1_conformite = calcConformite(oControle.up_pt1_err_abs, oControle.up_pt1_EMT)
            If oControle.up_pt1_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre2 :: saisiePressionManoReferenceup1 : " & ex.Message.ToString)
        End Try
    End Sub
    ' Calcul au chagement de contenu
    Private Sub saisiePressionManoReferenceup2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.up_pt2_err_abs = calcErrAbs(oControle.up_pt2_pres_manoCtrl, oControle.up_pt2_pres_manoEtalon)
            oControle.up_pt2_err_fondEchelle = calcErrFond(oControle.up_pt2_pres_manoCtrl, oControle.up_pt2_pres_manoEtalon, oManoC.fondEchelle)
            oControle.up_pt2_conformite = calcConformite(oControle.up_pt2_err_abs, oControle.up_pt2_EMT)
            If oControle.up_pt2_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre2 :: saisiePressionManoReferenceup1(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub saisiePressionManoReferenceup3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.up_pt3_err_abs = calcErrAbs(oControle.up_pt3_pres_manoCtrl, oControle.up_pt3_pres_manoEtalon)
            oControle.up_pt3_err_fondEchelle = calcErrFond(oControle.up_pt3_pres_manoCtrl, oControle.up_pt3_pres_manoEtalon, oManoC.fondEchelle)
            oControle.up_pt3_conformite = calcConformite(oControle.up_pt3_err_abs, oControle.up_pt3_EMT)
            If oControle.up_pt3_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre :: saisiePressionManoReferenceup3(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub saisiePressionManoReferenceup4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.up_pt4_err_abs = calcErrAbs(oControle.up_pt4_pres_manoCtrl, oControle.up_pt4_pres_manoEtalon)
            oControle.up_pt4_err_fondEchelle = calcErrFond(oControle.up_pt4_pres_manoCtrl, oControle.up_pt4_pres_manoEtalon, oManoC.fondEchelle)
            oControle.up_pt4_conformite = calcConformite(oControle.up_pt4_err_abs, oControle.up_pt4_EMT)
            If oControle.up_pt4_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre :: saisiePressionManoReferenceup4(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub saisiePressionManoReferenceup5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.up_pt5_err_abs = calcErrAbs(oControle.up_pt5_pres_manoCtrl, oControle.up_pt5_pres_manoEtalon)
            oControle.up_pt5_err_fondEchelle = calcErrFond(oControle.up_pt5_pres_manoCtrl, oControle.up_pt5_pres_manoEtalon, oManoC.fondEchelle)
            oControle.up_pt5_conformite = calcConformite(oControle.up_pt5_err_abs, oControle.up_pt5_EMT)
            If oControle.up_pt5_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre :: saisiePressionManoReferenceup5(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub saisiePressionManoReferenceup6(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.up_pt6_err_abs = calcErrAbs(oControle.up_pt6_pres_manoCtrl, oControle.up_pt6_pres_manoEtalon)
            oControle.up_pt6_err_fondEchelle = calcErrFond(oControle.up_pt6_pres_manoCtrl, oControle.up_pt6_pres_manoEtalon, oManoC.fondEchelle)
            oControle.up_pt6_conformite = calcConformite(oControle.up_pt6_err_abs, oControle.up_pt6_EMT)
            If oControle.up_pt6_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre :: saisiePressionManoReferenceup6(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub

    ' Calcul au chagement de contenu
    Private Sub saisiePressionManoReferencedown1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.down_pt1_err_abs = calcErrAbs(oControle.down_pt1_pres_manoCtrl, oControle.down_pt1_pres_manoEtalon)
            oControle.down_pt1_err_fondEchelle = calcErrFond(oControle.down_pt1_pres_manoCtrl, oControle.down_pt1_pres_manoEtalon, oManoC.fondEchelle)
            oControle.down_pt1_conformite = calcConformite(oControle.down_pt1_err_abs, oControle.down_pt1_EMT)
            If oControle.down_pt1_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre2 :: saisiePressionManoReferencedown1(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    ' Calcul au chagement de contenu
    Private Sub saisiePressionManoReferencedown2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.down_pt2_err_abs = calcErrAbs(oControle.down_pt2_pres_manoCtrl, oControle.down_pt2_pres_manoEtalon)
            oControle.down_pt2_err_fondEchelle = calcErrFond(oControle.down_pt2_pres_manoCtrl, oControle.down_pt2_pres_manoEtalon, oManoC.fondEchelle)
            oControle.down_pt2_conformite = calcConformite(oControle.down_pt2_err_abs, oControle.down_pt2_EMT)
            If oControle.down_pt2_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre2 :: saisiePressionManoReferencedown1(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub saisiePressionManoReferencedown3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.down_pt3_err_abs = calcErrAbs(oControle.down_pt3_pres_manoCtrl, oControle.down_pt3_pres_manoEtalon)
            oControle.down_pt3_err_fondEchelle = calcErrFond(oControle.down_pt3_pres_manoCtrl, oControle.down_pt3_pres_manoEtalon, oManoC.fondEchelle)
            oControle.down_pt3_conformite = calcConformite(oControle.down_pt3_err_abs, oControle.down_pt3_EMT)
            If oControle.down_pt3_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre :: saisiePressionManoReferencedown3(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub saisiePressionManoReferencedown4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.down_pt4_err_abs = calcErrAbs(oControle.down_pt4_pres_manoCtrl, oControle.down_pt4_pres_manoEtalon)
            oControle.down_pt4_err_fondEchelle = calcErrFond(oControle.down_pt4_pres_manoCtrl, oControle.down_pt4_pres_manoEtalon, oManoC.fondEchelle)
            oControle.down_pt4_conformite = calcConformite(oControle.down_pt4_err_abs, oControle.down_pt4_EMT)
            If oControle.down_pt4_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre :: saisiePressionManoReferencedown4(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub saisiePressionManoReferencedown5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.down_pt5_err_abs = calcErrAbs(oControle.down_pt5_pres_manoCtrl, oControle.down_pt5_pres_manoEtalon)
            oControle.down_pt5_err_fondEchelle = calcErrFond(oControle.down_pt5_pres_manoCtrl, oControle.down_pt5_pres_manoEtalon, oManoC.fondEchelle)
            oControle.down_pt5_conformite = calcConformite(oControle.down_pt5_err_abs, oControle.down_pt5_EMT)
            If oControle.down_pt5_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre :: saisiePressionManoReferencedown5(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub saisiePressionManoReferencedown6(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oManoC As ManometreControle
        Dim oManoE As ManometreEtalon
        Dim oControle As ControleMano
        Try
            ' Init

            oManoC = m_bsManoControle.Current
            oManoE = m_bsManoEtalon.Current
            oControle = m_bsControle.Current


            ' Calcul err absolue
            oControle.down_pt6_err_abs = calcErrAbs(oControle.down_pt6_pres_manoCtrl, oControle.down_pt6_pres_manoEtalon)
            oControle.down_pt6_err_fondEchelle = calcErrFond(oControle.down_pt6_pres_manoCtrl, oControle.down_pt6_pres_manoEtalon, oManoC.fondEchelle)
            oControle.down_pt6_conformite = calcConformite(oControle.down_pt6_err_abs, oControle.down_pt6_EMT)
            If oControle.down_pt6_conformite = "1" Then
                sender.ForeColor = System.Drawing.Color.Green
            Else
                sender.ForeColor = System.Drawing.Color.Red
            End If


            ValiderSaisie(oControle)
            m_bsControle.ResetCurrentItem()
            m_bsManoControle.ResetCurrentItem()
        Catch ex As Exception
            CSDebug.dispError("frmControleMAnometre :: saisiePressionManoReferencedown6(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub ValiderSaisie(pControle As ControleMano)
        If (isSaisieComplete()) Then
            'Calcul du resutat du contole
            pControle.resultat = ""
            If checkMano(pControle) Then
                pControle.resultat = "Votre manomètre est fiable : il répond à sa classe de précision."
                lblResultat.ForeColor = System.Drawing.Color.Green
            Else
                pControle.resultat = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
                lblResultat.ForeColor = System.Drawing.Color.Red

            End If
            btn_controleManos_suivant.Enabled = True
            btn_controleManos_valider.Enabled = True
        Else
            pControle.resultat = ""
            btn_controleManos_suivant.Enabled = False
            btn_controleManos_valider.Enabled = True
        End If
        lblResultat.Refresh()

    End Sub
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
                dReturn = CDbl(Math.Round((GlobalsCRODIP.StringToDouble(pMano.classe) * GlobalsCRODIP.StringToDouble(pMano.fondEchelle) / 100), 2))
        End Select

        Return dReturn

    End Function
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
                Select Case oVal.NumBuse
                    Case 1
                        oControle.up_pt1_pres_manoEtalon = oVal.Debit
                    Case 2
                        oControle.up_pt2_pres_manoEtalon = oVal.Debit
                    Case 3
                        oControle.up_pt3_pres_manoEtalon = oVal.Debit
                    Case 4
                        oControle.up_pt4_pres_manoEtalon = oVal.Debit
                    Case 5
                        oControle.up_pt5_pres_manoEtalon = oVal.Debit
                    Case 6
                        oControle.up_pt6_pres_manoEtalon = oVal.Debit
                End Select
            Else
                Select Case oVal.NumBuse
                    Case 1
                        oControle.down_pt1_pres_manoEtalon = oVal.Debit
                    Case 2
                        oControle.down_pt2_pres_manoEtalon = oVal.Debit
                    Case 3
                        oControle.down_pt3_pres_manoEtalon = oVal.Debit
                    Case 4
                        oControle.down_pt4_pres_manoEtalon = oVal.Debit
                    Case 5
                        oControle.down_pt5_pres_manoEtalon = oVal.Debit
                    Case 6
                        oControle.down_pt6_pres_manoEtalon = oVal.Debit
                End Select


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
        refreshLines()
    End Sub
    Private Sub refreshLines()
        saisiePressionManoReferenceup1(tbUpMR1, New EventArgs())
        saisiePressionManoReferenceup2(tbUpMR2, New EventArgs())
        saisiePressionManoReferenceup3(tbUpMR3, New EventArgs())
        saisiePressionManoReferenceup4(tbUpMR4, New EventArgs())
        saisiePressionManoReferenceup5(tbUpMR5, New EventArgs())
        saisiePressionManoReferenceup6(tbUpMR6, New EventArgs())
        'saisiePressionManoReferencedown1(tbDownMR1, New EventArgs())
        'saisiePressionManoReferencedown2(tbDownMR2, New EventArgs())
        saisiePressionManoReferencedown3(tbDownMR3, New EventArgs())
        saisiePressionManoReferencedown4(tbDownMR4, New EventArgs())
        saisiePressionManoReferencedown5(tbDownMR5, New EventArgs())
        saisiePressionManoReferencedown6(tbDownMR6, New EventArgs())

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
        'La Température, Date de vérification et le Mano de controle ne sont pas liés avec le controle
        ' car il doivent être mes même pour TOUS les controle
        oControle.tempAir = tbTemperature.Text
        oControle.DateVerif = dtpDateControle.Value
        oControle.manoEtalon = m_bsManoEtalon.Current.Numeronational
        oControle.idStructure = oMano.idStructure
        oControle.idMano = oMano.numeroNational
        oControle.resultat = oMano.etat
        oControle.DateVerif = CSDate.ToCRODIPString(dtpDateControle.Value)
        oControle.setIncertitude(oMano, m_bsManoEtalon.Current)
        ' ValiderSaisie(oControle)
        If oControle.up_pt1_conformite = "1" Then
            tbUpMR1.ForeColor = System.Drawing.Color.Green
        Else
            tbUpMR1.ForeColor = System.Drawing.Color.Red
        End If
        If oControle.up_pt2_conformite = "1" Then
            tbUpMR2.ForeColor = System.Drawing.Color.Green
        Else
            tbUpMR2.ForeColor = System.Drawing.Color.Red
        End If
        If oControle.up_pt3_conformite = "1" Then
            tbUpMR3.ForeColor = System.Drawing.Color.Green
        Else
            tbUpMR3.ForeColor = System.Drawing.Color.Red
        End If
        If oControle.up_pt4_conformite = "1" Then
            tbUpMR4.ForeColor = System.Drawing.Color.Green
        Else
            tbUpMR4.ForeColor = System.Drawing.Color.Red
        End If
        If oControle.up_pt5_conformite = "1" Then
            tbUpMR5.ForeColor = System.Drawing.Color.Green
        Else
            tbUpMR5.ForeColor = System.Drawing.Color.Red
        End If
        If oControle.up_pt6_conformite = "1" Then
            tbUpMR6.ForeColor = System.Drawing.Color.Green
        Else
            tbUpMR6.ForeColor = System.Drawing.Color.Red
        End If
        'If oControle.down_pt1_conformite = "1" Then
        'tbDownMR1.ForeColor = System.Drawing.Color.Green
        'Else
        'tbDownMR1.ForeColor = System.Drawing.Color.Red
        'End If
        'If oControle.down_pt2_conformite = "1" Then
        ' tbDownMR2.ForeColor = System.Drawing.Color.Green
        'Else
        'tbDownMR2.ForeColor = System.Drawing.Color.Red
        'End If
        If oControle.down_pt3_conformite = "1" Then
            tbDownMR3.ForeColor = System.Drawing.Color.Green
        Else
            tbDownMR3.ForeColor = System.Drawing.Color.Red
        End If
        If oControle.down_pt4_conformite = "1" Then
            tbDownMR4.ForeColor = System.Drawing.Color.Green
        Else
            tbDownMR4.ForeColor = System.Drawing.Color.Red
        End If
        If oControle.down_pt5_conformite = "1" Then
            tbDownMR5.ForeColor = System.Drawing.Color.Green
        Else
            tbDownMR5.ForeColor = System.Drawing.Color.Red
        End If
        If oControle.down_pt6_conformite = "1" Then
            tbDownMR6.ForeColor = System.Drawing.Color.Green
        Else
            tbDownMR6.ForeColor = System.Drawing.Color.Red
        End If

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

    Private Sub lbMano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbMano.SelectedIndexChanged

    End Sub

    Private Sub frmControleManometresNew_ImeModeChanged(sender As Object, e As EventArgs) Handles Me.ImeModeChanged

    End Sub
End Class
