
Imports System.Threading
Imports System.Collections.Generic
Imports System.IO
Imports System.Math
Imports CRODIPWS

Public Class frmcontrole_bancs
    Inherits frmCRODIP

    Private m_oControleBanc As ControleBanc

    Public CONST_COLOR_CELL_NOK As System.Drawing.Color = System.Drawing.Color.Salmon
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents controleBanc_buse1_3bar_ecartAutorise As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse2_3bar_ecartAutorise As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse4_3bar_ecartAutorise As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse3_3bar_ecartAutorise As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse5_3bar_ecartAutorise As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse6_3bar_ecartAutorise As System.Windows.Forms.TextBox
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents controleBanc_buse1_3bar_moyenne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse2_3bar_moyenne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse4_3bar_moyenne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse3_3bar_moyenne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse5_3bar_moyenne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse6_3bar_moyenne As System.Windows.Forms.TextBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents controleBanc_buse1_3bar_mesure3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse2_3bar_mesure3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse4_3bar_mesure3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse3_3bar_mesure3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse5_3bar_mesure3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse6_3bar_mesure3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse3_3bar_mesure1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse4_3bar_mesure1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse2_3bar_mesure1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse1_3bar_mesure1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse5_3bar_mesure1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse6_3bar_mesure1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents m_bsControleBanc As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsBuses1 As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsBuses2 As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsBuses3 As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsBuses4 As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsBuses5 As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsBuses6 As System.Windows.Forms.BindingSource
    Friend WithEvents controleBanc_buse1_3bar_mesure2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse2_3bar_mesure2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse4_3bar_mesure2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse3_3bar_mesure2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse5_3bar_mesure2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents controleBanc_buse6_3bar_mesure2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDateVerif As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Public CONST_COLOR_CELL_OK As Drawing.Color = System.Drawing.Color.LightGreen


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
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lbl_numBanc As System.Windows.Forms.Label
    Friend WithEvents lbl_extTemp As System.Windows.Forms.Label
    Friend WithEvents lbl_eauTemp As System.Windows.Forms.Label
    Friend WithEvents controleBanc_extTemp As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_eauTemp As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse2_pressionEtalonnage As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse1_pressionEtalonnage As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse3_pressionEtalonnage As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse4_pressionEtalonnage As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse2_debitEtalonne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse1_debitEtalonne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse3_debitEtalonne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse4_debitEtalonne As System.Windows.Forms.TextBox
    Friend WithEvents grp_infoGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents grp_temperatures As System.Windows.Forms.GroupBox
    Friend WithEvents grp_verification As System.Windows.Forms.GroupBox
    Friend WithEvents panel_Array As System.Windows.Forms.Panel
    Friend WithEvents controleBanc_resultat As System.Windows.Forms.Label
    Friend WithEvents controleBanc_numBanc As System.Windows.Forms.ComboBox
    Friend WithEvents btn_controleBanc_valider As System.Windows.Forms.Label
    Friend WithEvents btn_controleBanc_annuler As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents controleBanc_buse1 As System.Windows.Forms.ComboBox
    Friend WithEvents controleBanc_buse2 As System.Windows.Forms.ComboBox
    Friend WithEvents controleBanc_buse3 As System.Windows.Forms.ComboBox
    Friend WithEvents controleBanc_buse4 As System.Windows.Forms.ComboBox
    Friend WithEvents controleBanc_buse5 As System.Windows.Forms.ComboBox
    Friend WithEvents controleBanc_buse6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents controleBanc_buse5_pressionEtalonnage As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse6_pressionEtalonnage As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse5_debitEtalonne As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse6_debitEtalonne As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents labelVerifBuse1 As System.Windows.Forms.Label
    Friend WithEvents controleBanc_buse1_numBuse As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse2_numBuse As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse3_numBuse As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse4_numBuse As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse5_numBuse As System.Windows.Forms.TextBox
    Friend WithEvents controleBanc_buse6_numBuse As System.Windows.Forms.TextBox
    Friend WithEvents labelVerifBuse2 As System.Windows.Forms.Label
    Friend WithEvents labelVerifBuse3 As System.Windows.Forms.Label
    Friend WithEvents labelVerifBuse4 As System.Windows.Forms.Label
    Friend WithEvents labelVerifBuse5 As System.Windows.Forms.Label
    Friend WithEvents labelVerifBuse6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcontrole_bancs))
        Me.Label82 = New System.Windows.Forms.Label()
        Me.grp_infoGenerales = New System.Windows.Forms.GroupBox()
        Me.dtpDateVerif = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.controleBanc_numBanc = New System.Windows.Forms.ComboBox()
        Me.lbl_numBanc = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.controleBanc_buse1 = New System.Windows.Forms.ComboBox()
        Me.m_bsBuses1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.controleBanc_buse2 = New System.Windows.Forms.ComboBox()
        Me.m_bsBuses2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.controleBanc_buse3 = New System.Windows.Forms.ComboBox()
        Me.m_bsBuses3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.controleBanc_buse4 = New System.Windows.Forms.ComboBox()
        Me.m_bsBuses4 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label29 = New System.Windows.Forms.Label()
        Me.controleBanc_buse5 = New System.Windows.Forms.ComboBox()
        Me.m_bsBuses5 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label30 = New System.Windows.Forms.Label()
        Me.controleBanc_buse6 = New System.Windows.Forms.ComboBox()
        Me.m_bsBuses6 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label31 = New System.Windows.Forms.Label()
        Me.m_bsControleBanc = New System.Windows.Forms.BindingSource(Me.components)
        Me.grp_temperatures = New System.Windows.Forms.GroupBox()
        Me.controleBanc_extTemp = New System.Windows.Forms.TextBox()
        Me.lbl_extTemp = New System.Windows.Forms.Label()
        Me.controleBanc_eauTemp = New System.Windows.Forms.TextBox()
        Me.lbl_eauTemp = New System.Windows.Forms.Label()
        Me.grp_verification = New System.Windows.Forms.GroupBox()
        Me.panel_Array = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.controleBanc_buse1_3bar_mesure2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse2_3bar_mesure2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse4_3bar_mesure2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse3_3bar_mesure2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse5_3bar_mesure2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse6_3bar_mesure2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse1_3bar_mesure3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse2_3bar_mesure3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse4_3bar_mesure3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse3_3bar_mesure3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse5_3bar_mesure3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse6_3bar_mesure3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse3_3bar_mesure1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse4_3bar_mesure1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse2_3bar_mesure1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse1_3bar_mesure1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse5_3bar_mesure1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.controleBanc_buse6_3bar_mesure1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.labelVerifBuse1 = New System.Windows.Forms.Label()
        Me.labelVerifBuse2 = New System.Windows.Forms.Label()
        Me.labelVerifBuse3 = New System.Windows.Forms.Label()
        Me.labelVerifBuse4 = New System.Windows.Forms.Label()
        Me.labelVerifBuse5 = New System.Windows.Forms.Label()
        Me.labelVerifBuse6 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.controleBanc_buse2_debitEtalonne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse1_debitEtalonne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse3_debitEtalonne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse4_debitEtalonne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse5_debitEtalonne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse6_debitEtalonne = New System.Windows.Forms.TextBox()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.controleBanc_buse2_pressionEtalonnage = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse1_pressionEtalonnage = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse3_pressionEtalonnage = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse4_pressionEtalonnage = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse5_pressionEtalonnage = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse6_pressionEtalonnage = New System.Windows.Forms.TextBox()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.controleBanc_buse1_numBuse = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse2_numBuse = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse3_numBuse = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse4_numBuse = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse5_numBuse = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse6_numBuse = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.controleBanc_buse1_3bar_ecartAutorise = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse2_3bar_ecartAutorise = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse4_3bar_ecartAutorise = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse3_3bar_ecartAutorise = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse5_3bar_ecartAutorise = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse6_3bar_ecartAutorise = New System.Windows.Forms.TextBox()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.controleBanc_buse1_3bar_moyenne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse2_3bar_moyenne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse4_3bar_moyenne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse3_3bar_moyenne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse5_3bar_moyenne = New System.Windows.Forms.TextBox()
        Me.controleBanc_buse6_3bar_moyenne = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.controleBanc_resultat = New System.Windows.Forms.Label()
        Me.btn_controleBanc_valider = New System.Windows.Forms.Label()
        Me.btn_controleBanc_annuler = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grp_infoGenerales.SuspendLayout()
        CType(Me.m_bsBuses1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsBuses2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsBuses3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsBuses4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsBuses5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsBuses6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsControleBanc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_temperatures.SuspendLayout()
        Me.grp_verification.SuspendLayout()
        Me.panel_Array.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel22.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label82
        '
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label82.Image = CType(resources.GetObject("Label82.Image"), System.Drawing.Image)
        Me.Label82.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label82.Location = New System.Drawing.Point(8, 8)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(392, 25)
        Me.Label82.TabIndex = 5
        Me.Label82.Text = "     Vérifications des bancs de mesure"
        '
        'grp_infoGenerales
        '
        Me.grp_infoGenerales.Controls.Add(Me.dtpDateVerif)
        Me.grp_infoGenerales.Controls.Add(Me.Label3)
        Me.grp_infoGenerales.Controls.Add(Me.controleBanc_numBanc)
        Me.grp_infoGenerales.Controls.Add(Me.lbl_numBanc)
        Me.grp_infoGenerales.Controls.Add(Me.Label4)
        Me.grp_infoGenerales.Controls.Add(Me.controleBanc_buse1)
        Me.grp_infoGenerales.Controls.Add(Me.Label7)
        Me.grp_infoGenerales.Controls.Add(Me.controleBanc_buse2)
        Me.grp_infoGenerales.Controls.Add(Me.Label15)
        Me.grp_infoGenerales.Controls.Add(Me.controleBanc_buse3)
        Me.grp_infoGenerales.Controls.Add(Me.controleBanc_buse4)
        Me.grp_infoGenerales.Controls.Add(Me.Label29)
        Me.grp_infoGenerales.Controls.Add(Me.controleBanc_buse5)
        Me.grp_infoGenerales.Controls.Add(Me.Label30)
        Me.grp_infoGenerales.Controls.Add(Me.controleBanc_buse6)
        Me.grp_infoGenerales.Controls.Add(Me.Label31)
        Me.grp_infoGenerales.Location = New System.Drawing.Point(8, 48)
        Me.grp_infoGenerales.Name = "grp_infoGenerales"
        Me.grp_infoGenerales.Size = New System.Drawing.Size(992, 90)
        Me.grp_infoGenerales.TabIndex = 1
        Me.grp_infoGenerales.TabStop = False
        Me.grp_infoGenerales.Text = "Informations générales"
        '
        'dtpDateVerif
        '
        Me.dtpDateVerif.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateVerif.Location = New System.Drawing.Point(178, 24)
        Me.dtpDateVerif.Name = "dtpDateVerif"
        Me.dtpDateVerif.Size = New System.Drawing.Size(128, 20)
        Me.dtpDateVerif.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(6, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Date de vérification :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'controleBanc_numBanc
        '
        Me.controleBanc_numBanc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.controleBanc_numBanc.Location = New System.Drawing.Point(178, 56)
        Me.controleBanc_numBanc.Name = "controleBanc_numBanc"
        Me.controleBanc_numBanc.Size = New System.Drawing.Size(128, 21)
        Me.controleBanc_numBanc.TabIndex = 0
        '
        'lbl_numBanc
        '
        Me.lbl_numBanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_numBanc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_numBanc.Location = New System.Drawing.Point(58, 56)
        Me.lbl_numBanc.Name = "lbl_numBanc"
        Me.lbl_numBanc.Size = New System.Drawing.Size(112, 16)
        Me.lbl_numBanc.TabIndex = 17
        Me.lbl_numBanc.Text = "N° identifiant banc :"
        Me.lbl_numBanc.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(312, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "1ère buse :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'controleBanc_buse1
        '
        Me.controleBanc_buse1.DataSource = Me.m_bsBuses1
        Me.controleBanc_buse1.DisplayMember = "Libelle"
        Me.controleBanc_buse1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.controleBanc_buse1.Location = New System.Drawing.Point(396, 24)
        Me.controleBanc_buse1.Name = "controleBanc_buse1"
        Me.controleBanc_buse1.Size = New System.Drawing.Size(120, 21)
        Me.controleBanc_buse1.TabIndex = 1
        Me.controleBanc_buse1.ValueMember = "numeroNational"
        '
        'm_bsBuses1
        '
        Me.m_bsBuses1.DataSource = GetType(CRODIPWS.Buse)
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(312, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "2ème buse :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'controleBanc_buse2
        '
        Me.controleBanc_buse2.DataSource = Me.m_bsBuses2
        Me.controleBanc_buse2.DisplayMember = "Libelle"
        Me.controleBanc_buse2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.controleBanc_buse2.Location = New System.Drawing.Point(396, 56)
        Me.controleBanc_buse2.Name = "controleBanc_buse2"
        Me.controleBanc_buse2.Size = New System.Drawing.Size(120, 21)
        Me.controleBanc_buse2.TabIndex = 2
        Me.controleBanc_buse2.ValueMember = "numeroNational"
        '
        'm_bsBuses2
        '
        Me.m_bsBuses2.DataSource = GetType(CRODIPWS.Buse)
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(520, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "3ème buse :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'controleBanc_buse3
        '
        Me.controleBanc_buse3.DataSource = Me.m_bsBuses3
        Me.controleBanc_buse3.DisplayMember = "Libelle"
        Me.controleBanc_buse3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.controleBanc_buse3.Location = New System.Drawing.Point(604, 24)
        Me.controleBanc_buse3.Name = "controleBanc_buse3"
        Me.controleBanc_buse3.Size = New System.Drawing.Size(120, 21)
        Me.controleBanc_buse3.TabIndex = 3
        Me.controleBanc_buse3.ValueMember = "numeroNational"
        '
        'm_bsBuses3
        '
        Me.m_bsBuses3.DataSource = GetType(CRODIPWS.Buse)
        '
        'controleBanc_buse4
        '
        Me.controleBanc_buse4.DataSource = Me.m_bsBuses4
        Me.controleBanc_buse4.DisplayMember = "Libelle"
        Me.controleBanc_buse4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.controleBanc_buse4.Location = New System.Drawing.Point(604, 56)
        Me.controleBanc_buse4.Name = "controleBanc_buse4"
        Me.controleBanc_buse4.Size = New System.Drawing.Size(120, 21)
        Me.controleBanc_buse4.TabIndex = 4
        Me.controleBanc_buse4.ValueMember = "numeroNational"
        '
        'm_bsBuses4
        '
        Me.m_bsBuses4.DataSource = GetType(CRODIPWS.Buse)
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(520, 56)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 16)
        Me.Label29.TabIndex = 17
        Me.Label29.Text = "4ème buse :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'controleBanc_buse5
        '
        Me.controleBanc_buse5.DataSource = Me.m_bsBuses5
        Me.controleBanc_buse5.DisplayMember = "Libelle"
        Me.controleBanc_buse5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.controleBanc_buse5.Location = New System.Drawing.Point(812, 24)
        Me.controleBanc_buse5.Name = "controleBanc_buse5"
        Me.controleBanc_buse5.Size = New System.Drawing.Size(120, 21)
        Me.controleBanc_buse5.TabIndex = 5
        Me.controleBanc_buse5.ValueMember = "numeroNational"
        '
        'm_bsBuses5
        '
        Me.m_bsBuses5.DataSource = GetType(CRODIPWS.Buse)
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(728, 24)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(76, 16)
        Me.Label30.TabIndex = 17
        Me.Label30.Text = "5ème buse :"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'controleBanc_buse6
        '
        Me.controleBanc_buse6.DataSource = Me.m_bsBuses6
        Me.controleBanc_buse6.DisplayMember = "Libelle"
        Me.controleBanc_buse6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.controleBanc_buse6.Location = New System.Drawing.Point(812, 56)
        Me.controleBanc_buse6.Name = "controleBanc_buse6"
        Me.controleBanc_buse6.Size = New System.Drawing.Size(120, 21)
        Me.controleBanc_buse6.TabIndex = 6
        Me.controleBanc_buse6.ValueMember = "numeroNational"
        '
        'm_bsBuses6
        '
        Me.m_bsBuses6.DataSource = GetType(CRODIPWS.Buse)
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(728, 56)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(76, 16)
        Me.Label31.TabIndex = 17
        Me.Label31.Text = "6ème buse :"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'm_bsControleBanc
        '
        Me.m_bsControleBanc.DataSource = GetType(CRODIPWS.ControleBanc)
        '
        'grp_temperatures
        '
        Me.grp_temperatures.Controls.Add(Me.controleBanc_extTemp)
        Me.grp_temperatures.Controls.Add(Me.lbl_extTemp)
        Me.grp_temperatures.Controls.Add(Me.controleBanc_eauTemp)
        Me.grp_temperatures.Controls.Add(Me.lbl_eauTemp)
        Me.grp_temperatures.Location = New System.Drawing.Point(8, 144)
        Me.grp_temperatures.Name = "grp_temperatures"
        Me.grp_temperatures.Size = New System.Drawing.Size(992, 64)
        Me.grp_temperatures.TabIndex = 1
        Me.grp_temperatures.TabStop = False
        Me.grp_temperatures.Text = "Températures"
        '
        'controleBanc_extTemp
        '
        Me.controleBanc_extTemp.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "tempExt", True))
        Me.controleBanc_extTemp.Location = New System.Drawing.Point(294, 24)
        Me.controleBanc_extTemp.Name = "controleBanc_extTemp"
        Me.controleBanc_extTemp.Size = New System.Drawing.Size(144, 20)
        Me.controleBanc_extTemp.TabIndex = 0
        '
        'lbl_extTemp
        '
        Me.lbl_extTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_extTemp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_extTemp.Location = New System.Drawing.Point(120, 24)
        Me.lbl_extTemp.Name = "lbl_extTemp"
        Me.lbl_extTemp.Size = New System.Drawing.Size(158, 16)
        Me.lbl_extTemp.TabIndex = 17
        Me.lbl_extTemp.Text = "Température extérieure :"
        Me.lbl_extTemp.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'controleBanc_eauTemp
        '
        Me.controleBanc_eauTemp.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "tempEau", True))
        Me.controleBanc_eauTemp.Location = New System.Drawing.Point(706, 24)
        Me.controleBanc_eauTemp.Name = "controleBanc_eauTemp"
        Me.controleBanc_eauTemp.Size = New System.Drawing.Size(144, 20)
        Me.controleBanc_eauTemp.TabIndex = 1
        '
        'lbl_eauTemp
        '
        Me.lbl_eauTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_eauTemp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_eauTemp.Location = New System.Drawing.Point(562, 24)
        Me.lbl_eauTemp.Name = "lbl_eauTemp"
        Me.lbl_eauTemp.Size = New System.Drawing.Size(128, 16)
        Me.lbl_eauTemp.TabIndex = 17
        Me.lbl_eauTemp.Text = "Température de l'eau :"
        Me.lbl_eauTemp.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'grp_verification
        '
        Me.grp_verification.Controls.Add(Me.panel_Array)
        Me.grp_verification.Enabled = False
        Me.grp_verification.Location = New System.Drawing.Point(8, 214)
        Me.grp_verification.Name = "grp_verification"
        Me.grp_verification.Size = New System.Drawing.Size(992, 336)
        Me.grp_verification.TabIndex = 2
        Me.grp_verification.TabStop = False
        Me.grp_verification.Text = "Vérification"
        '
        'panel_Array
        '
        Me.panel_Array.AutoScroll = True
        Me.panel_Array.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.panel_Array.Controls.Add(Me.Panel8)
        Me.panel_Array.Controls.Add(Me.Panel7)
        Me.panel_Array.Controls.Add(Me.Panel6)
        Me.panel_Array.Controls.Add(Me.Panel5)
        Me.panel_Array.Controls.Add(Me.Panel10)
        Me.panel_Array.Controls.Add(Me.Panel4)
        Me.panel_Array.Controls.Add(Me.Panel9)
        Me.panel_Array.Controls.Add(Me.Panel1)
        Me.panel_Array.Controls.Add(Me.Panel2)
        Me.panel_Array.Controls.Add(Me.Panel3)
        Me.panel_Array.Controls.Add(Me.Panel16)
        Me.panel_Array.Controls.Add(Me.Panel17)
        Me.panel_Array.Controls.Add(Me.Panel18)
        Me.panel_Array.Controls.Add(Me.Panel19)
        Me.panel_Array.Controls.Add(Me.Panel20)
        Me.panel_Array.Controls.Add(Me.Panel21)
        Me.panel_Array.Controls.Add(Me.Panel22)
        Me.panel_Array.Controls.Add(Me.Panel11)
        Me.panel_Array.Controls.Add(Me.Panel12)
        Me.panel_Array.Controls.Add(Me.Panel13)
        Me.panel_Array.Controls.Add(Me.Panel14)
        Me.panel_Array.Location = New System.Drawing.Point(158, 19)
        Me.panel_Array.Name = "panel_Array"
        Me.panel_Array.Size = New System.Drawing.Size(725, 296)
        Me.panel_Array.TabIndex = 12
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Location = New System.Drawing.Point(655, 39)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(68, 39)
        Me.Panel8.TabIndex = 61
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 37)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "% Tolérance"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Location = New System.Drawing.Point(595, 39)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(59, 39)
        Me.Panel7.TabIndex = 60
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 39)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "% Ecart"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel6.Controls.Add(Me.TextBox7)
        Me.Panel6.Controls.Add(Me.TextBox8)
        Me.Panel6.Controls.Add(Me.TextBox9)
        Me.Panel6.Controls.Add(Me.TextBox10)
        Me.Panel6.Controls.Add(Me.TextBox11)
        Me.Panel6.Controls.Add(Me.TextBox12)
        Me.Panel6.Location = New System.Drawing.Point(655, 79)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(67, 217)
        Me.Panel6.TabIndex = 59
        '
        'TextBox7
        '
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_3bar_pctTolerance", True))
        Me.TextBox7.Enabled = False
        Me.TextBox7.Location = New System.Drawing.Point(5, 19)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(48, 20)
        Me.TextBox7.TabIndex = 0
        '
        'TextBox8
        '
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_3bar_pctTolerance", True))
        Me.TextBox8.Enabled = False
        Me.TextBox8.Location = New System.Drawing.Point(5, 48)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(48, 20)
        Me.TextBox8.TabIndex = 1
        '
        'TextBox9
        '
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_3bar_pctTolerance", True))
        Me.TextBox9.Enabled = False
        Me.TextBox9.Location = New System.Drawing.Point(5, 112)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(48, 20)
        Me.TextBox9.TabIndex = 3
        '
        'TextBox10
        '
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_3bar_pctTolerance", True))
        Me.TextBox10.Enabled = False
        Me.TextBox10.Location = New System.Drawing.Point(5, 80)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(48, 20)
        Me.TextBox10.TabIndex = 2
        '
        'TextBox11
        '
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_3bar_pctTolerance", True))
        Me.TextBox11.Enabled = False
        Me.TextBox11.Location = New System.Drawing.Point(5, 144)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(48, 20)
        Me.TextBox11.TabIndex = 4
        '
        'TextBox12
        '
        Me.TextBox12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_3bar_pctTolerance", True))
        Me.TextBox12.Enabled = False
        Me.TextBox12.Location = New System.Drawing.Point(5, 176)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(48, 20)
        Me.TextBox12.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.TextBox2)
        Me.Panel5.Controls.Add(Me.TextBox3)
        Me.Panel5.Controls.Add(Me.TextBox4)
        Me.Panel5.Controls.Add(Me.TextBox5)
        Me.Panel5.Controls.Add(Me.TextBox6)
        Me.Panel5.Location = New System.Drawing.Point(595, 79)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(59, 217)
        Me.Panel5.TabIndex = 13
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_3bar_pctEcart", True))
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(5, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(48, 20)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_3bar_pctEcart", True))
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(5, 48)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(48, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_3bar_pctEcart", True))
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(5, 112)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(48, 20)
        Me.TextBox3.TabIndex = 3
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_3bar_pctEcart", True))
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(5, 80)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(48, 20)
        Me.TextBox4.TabIndex = 2
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_3bar_pctEcart", True))
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(5, 144)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(48, 20)
        Me.TextBox5.TabIndex = 4
        '
        'TextBox6
        '
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_3bar_pctEcart", True))
        Me.TextBox6.Enabled = False
        Me.TextBox6.Location = New System.Drawing.Point(5, 176)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(48, 20)
        Me.TextBox6.TabIndex = 5
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel10.Controls.Add(Me.controleBanc_buse1_3bar_mesure2)
        Me.Panel10.Controls.Add(Me.controleBanc_buse2_3bar_mesure2)
        Me.Panel10.Controls.Add(Me.controleBanc_buse4_3bar_mesure2)
        Me.Panel10.Controls.Add(Me.controleBanc_buse3_3bar_mesure2)
        Me.Panel10.Controls.Add(Me.controleBanc_buse5_3bar_mesure2)
        Me.Panel10.Controls.Add(Me.controleBanc_buse6_3bar_mesure2)
        Me.Panel10.Controls.Add(Me.controleBanc_buse1_3bar_mesure3)
        Me.Panel10.Controls.Add(Me.controleBanc_buse2_3bar_mesure3)
        Me.Panel10.Controls.Add(Me.controleBanc_buse4_3bar_mesure3)
        Me.Panel10.Controls.Add(Me.controleBanc_buse3_3bar_mesure3)
        Me.Panel10.Controls.Add(Me.controleBanc_buse5_3bar_mesure3)
        Me.Panel10.Controls.Add(Me.controleBanc_buse6_3bar_mesure3)
        Me.Panel10.Controls.Add(Me.controleBanc_buse3_3bar_mesure1)
        Me.Panel10.Controls.Add(Me.controleBanc_buse4_3bar_mesure1)
        Me.Panel10.Controls.Add(Me.controleBanc_buse2_3bar_mesure1)
        Me.Panel10.Controls.Add(Me.controleBanc_buse1_3bar_mesure1)
        Me.Panel10.Controls.Add(Me.controleBanc_buse5_3bar_mesure1)
        Me.Panel10.Controls.Add(Me.controleBanc_buse6_3bar_mesure1)
        Me.Panel10.Location = New System.Drawing.Point(284, 79)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(178, 217)
        Me.Panel10.TabIndex = 58
        '
        'controleBanc_buse1_3bar_mesure2
        '
        Me.controleBanc_buse1_3bar_mesure2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_3bar_m2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse1_3bar_mesure2.Enabled = False
        Me.controleBanc_buse1_3bar_mesure2.ForceBindingOnTextChanged = True
        Me.controleBanc_buse1_3bar_mesure2.Location = New System.Drawing.Point(65, 19)
        Me.controleBanc_buse1_3bar_mesure2.Name = "controleBanc_buse1_3bar_mesure2"
        Me.controleBanc_buse1_3bar_mesure2.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse1_3bar_mesure2.TabIndex = 1
        '
        'controleBanc_buse2_3bar_mesure2
        '
        Me.controleBanc_buse2_3bar_mesure2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_3bar_m2", True))
        Me.controleBanc_buse2_3bar_mesure2.Enabled = False
        Me.controleBanc_buse2_3bar_mesure2.ForceBindingOnTextChanged = True
        Me.controleBanc_buse2_3bar_mesure2.Location = New System.Drawing.Point(65, 48)
        Me.controleBanc_buse2_3bar_mesure2.Name = "controleBanc_buse2_3bar_mesure2"
        Me.controleBanc_buse2_3bar_mesure2.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse2_3bar_mesure2.TabIndex = 4
        '
        'controleBanc_buse4_3bar_mesure2
        '
        Me.controleBanc_buse4_3bar_mesure2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_3bar_m2", True))
        Me.controleBanc_buse4_3bar_mesure2.Enabled = False
        Me.controleBanc_buse4_3bar_mesure2.ForceBindingOnTextChanged = True
        Me.controleBanc_buse4_3bar_mesure2.Location = New System.Drawing.Point(65, 112)
        Me.controleBanc_buse4_3bar_mesure2.Name = "controleBanc_buse4_3bar_mesure2"
        Me.controleBanc_buse4_3bar_mesure2.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse4_3bar_mesure2.TabIndex = 10
        '
        'controleBanc_buse3_3bar_mesure2
        '
        Me.controleBanc_buse3_3bar_mesure2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_3bar_m2", True))
        Me.controleBanc_buse3_3bar_mesure2.Enabled = False
        Me.controleBanc_buse3_3bar_mesure2.ForceBindingOnTextChanged = True
        Me.controleBanc_buse3_3bar_mesure2.Location = New System.Drawing.Point(65, 80)
        Me.controleBanc_buse3_3bar_mesure2.Name = "controleBanc_buse3_3bar_mesure2"
        Me.controleBanc_buse3_3bar_mesure2.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse3_3bar_mesure2.TabIndex = 7
        '
        'controleBanc_buse5_3bar_mesure2
        '
        Me.controleBanc_buse5_3bar_mesure2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_3bar_m2", True))
        Me.controleBanc_buse5_3bar_mesure2.Enabled = False
        Me.controleBanc_buse5_3bar_mesure2.ForceBindingOnTextChanged = True
        Me.controleBanc_buse5_3bar_mesure2.Location = New System.Drawing.Point(65, 144)
        Me.controleBanc_buse5_3bar_mesure2.Name = "controleBanc_buse5_3bar_mesure2"
        Me.controleBanc_buse5_3bar_mesure2.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse5_3bar_mesure2.TabIndex = 13
        '
        'controleBanc_buse6_3bar_mesure2
        '
        Me.controleBanc_buse6_3bar_mesure2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_3bar_m2", True))
        Me.controleBanc_buse6_3bar_mesure2.Enabled = False
        Me.controleBanc_buse6_3bar_mesure2.ForceBindingOnTextChanged = True
        Me.controleBanc_buse6_3bar_mesure2.Location = New System.Drawing.Point(65, 177)
        Me.controleBanc_buse6_3bar_mesure2.Name = "controleBanc_buse6_3bar_mesure2"
        Me.controleBanc_buse6_3bar_mesure2.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse6_3bar_mesure2.TabIndex = 16
        '
        'controleBanc_buse1_3bar_mesure3
        '
        Me.controleBanc_buse1_3bar_mesure3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_3bar_m3", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse1_3bar_mesure3.Enabled = False
        Me.controleBanc_buse1_3bar_mesure3.ForceBindingOnTextChanged = True
        Me.controleBanc_buse1_3bar_mesure3.Location = New System.Drawing.Point(123, 19)
        Me.controleBanc_buse1_3bar_mesure3.Name = "controleBanc_buse1_3bar_mesure3"
        Me.controleBanc_buse1_3bar_mesure3.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse1_3bar_mesure3.TabIndex = 2
        '
        'controleBanc_buse2_3bar_mesure3
        '
        Me.controleBanc_buse2_3bar_mesure3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_3bar_m3", True))
        Me.controleBanc_buse2_3bar_mesure3.Enabled = False
        Me.controleBanc_buse2_3bar_mesure3.ForceBindingOnTextChanged = True
        Me.controleBanc_buse2_3bar_mesure3.Location = New System.Drawing.Point(123, 48)
        Me.controleBanc_buse2_3bar_mesure3.Name = "controleBanc_buse2_3bar_mesure3"
        Me.controleBanc_buse2_3bar_mesure3.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse2_3bar_mesure3.TabIndex = 5
        '
        'controleBanc_buse4_3bar_mesure3
        '
        Me.controleBanc_buse4_3bar_mesure3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_3bar_m3", True))
        Me.controleBanc_buse4_3bar_mesure3.Enabled = False
        Me.controleBanc_buse4_3bar_mesure3.ForceBindingOnTextChanged = True
        Me.controleBanc_buse4_3bar_mesure3.Location = New System.Drawing.Point(123, 112)
        Me.controleBanc_buse4_3bar_mesure3.Name = "controleBanc_buse4_3bar_mesure3"
        Me.controleBanc_buse4_3bar_mesure3.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse4_3bar_mesure3.TabIndex = 11
        '
        'controleBanc_buse3_3bar_mesure3
        '
        Me.controleBanc_buse3_3bar_mesure3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_3bar_m3", True))
        Me.controleBanc_buse3_3bar_mesure3.Enabled = False
        Me.controleBanc_buse3_3bar_mesure3.ForceBindingOnTextChanged = True
        Me.controleBanc_buse3_3bar_mesure3.Location = New System.Drawing.Point(123, 80)
        Me.controleBanc_buse3_3bar_mesure3.Name = "controleBanc_buse3_3bar_mesure3"
        Me.controleBanc_buse3_3bar_mesure3.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse3_3bar_mesure3.TabIndex = 8
        '
        'controleBanc_buse5_3bar_mesure3
        '
        Me.controleBanc_buse5_3bar_mesure3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_3bar_m3", True))
        Me.controleBanc_buse5_3bar_mesure3.Enabled = False
        Me.controleBanc_buse5_3bar_mesure3.ForceBindingOnTextChanged = True
        Me.controleBanc_buse5_3bar_mesure3.Location = New System.Drawing.Point(123, 144)
        Me.controleBanc_buse5_3bar_mesure3.Name = "controleBanc_buse5_3bar_mesure3"
        Me.controleBanc_buse5_3bar_mesure3.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse5_3bar_mesure3.TabIndex = 14
        '
        'controleBanc_buse6_3bar_mesure3
        '
        Me.controleBanc_buse6_3bar_mesure3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_3bar_m3", True))
        Me.controleBanc_buse6_3bar_mesure3.Enabled = False
        Me.controleBanc_buse6_3bar_mesure3.ForceBindingOnTextChanged = True
        Me.controleBanc_buse6_3bar_mesure3.Location = New System.Drawing.Point(123, 176)
        Me.controleBanc_buse6_3bar_mesure3.Name = "controleBanc_buse6_3bar_mesure3"
        Me.controleBanc_buse6_3bar_mesure3.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse6_3bar_mesure3.TabIndex = 17
        '
        'controleBanc_buse3_3bar_mesure1
        '
        Me.controleBanc_buse3_3bar_mesure1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_3bar_m1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse3_3bar_mesure1.Enabled = False
        Me.controleBanc_buse3_3bar_mesure1.ForceBindingOnTextChanged = True
        Me.controleBanc_buse3_3bar_mesure1.Location = New System.Drawing.Point(5, 80)
        Me.controleBanc_buse3_3bar_mesure1.Name = "controleBanc_buse3_3bar_mesure1"
        Me.controleBanc_buse3_3bar_mesure1.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse3_3bar_mesure1.TabIndex = 6
        '
        'controleBanc_buse4_3bar_mesure1
        '
        Me.controleBanc_buse4_3bar_mesure1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_3bar_m1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse4_3bar_mesure1.Enabled = False
        Me.controleBanc_buse4_3bar_mesure1.ForceBindingOnTextChanged = True
        Me.controleBanc_buse4_3bar_mesure1.Location = New System.Drawing.Point(5, 112)
        Me.controleBanc_buse4_3bar_mesure1.Name = "controleBanc_buse4_3bar_mesure1"
        Me.controleBanc_buse4_3bar_mesure1.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse4_3bar_mesure1.TabIndex = 9
        '
        'controleBanc_buse2_3bar_mesure1
        '
        Me.controleBanc_buse2_3bar_mesure1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_3bar_m1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse2_3bar_mesure1.Enabled = False
        Me.controleBanc_buse2_3bar_mesure1.ForceBindingOnTextChanged = True
        Me.controleBanc_buse2_3bar_mesure1.Location = New System.Drawing.Point(5, 48)
        Me.controleBanc_buse2_3bar_mesure1.Name = "controleBanc_buse2_3bar_mesure1"
        Me.controleBanc_buse2_3bar_mesure1.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse2_3bar_mesure1.TabIndex = 3
        '
        'controleBanc_buse1_3bar_mesure1
        '
        Me.controleBanc_buse1_3bar_mesure1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_3bar_m1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse1_3bar_mesure1.Enabled = False
        Me.controleBanc_buse1_3bar_mesure1.ForceBindingOnTextChanged = True
        Me.controleBanc_buse1_3bar_mesure1.Location = New System.Drawing.Point(5, 19)
        Me.controleBanc_buse1_3bar_mesure1.Name = "controleBanc_buse1_3bar_mesure1"
        Me.controleBanc_buse1_3bar_mesure1.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse1_3bar_mesure1.TabIndex = 0
        '
        'controleBanc_buse5_3bar_mesure1
        '
        Me.controleBanc_buse5_3bar_mesure1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_3bar_m1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse5_3bar_mesure1.Enabled = False
        Me.controleBanc_buse5_3bar_mesure1.ForceBindingOnTextChanged = True
        Me.controleBanc_buse5_3bar_mesure1.Location = New System.Drawing.Point(5, 144)
        Me.controleBanc_buse5_3bar_mesure1.Name = "controleBanc_buse5_3bar_mesure1"
        Me.controleBanc_buse5_3bar_mesure1.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse5_3bar_mesure1.TabIndex = 12
        '
        'controleBanc_buse6_3bar_mesure1
        '
        Me.controleBanc_buse6_3bar_mesure1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_3bar_m1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse6_3bar_mesure1.Enabled = False
        Me.controleBanc_buse6_3bar_mesure1.ForceBindingOnTextChanged = True
        Me.controleBanc_buse6_3bar_mesure1.Location = New System.Drawing.Point(5, 176)
        Me.controleBanc_buse6_3bar_mesure1.Name = "controleBanc_buse6_3bar_mesure1"
        Me.controleBanc_buse6_3bar_mesure1.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse6_3bar_mesure1.TabIndex = 15
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Location = New System.Drawing.Point(283, -1)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(440, 39)
        Me.Panel4.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(164, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Mesures à 3 bars"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel9.Controls.Add(Me.Label10)
        Me.Panel9.Location = New System.Drawing.Point(283, 39)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(179, 39)
        Me.Panel9.TabIndex = 50
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(8, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(166, 24)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Mesures"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(72, 39)
        Me.Panel1.TabIndex = 48
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(0, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(72, 39)
        Me.Panel2.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 24)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Couleur"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel3.Controls.Add(Me.labelVerifBuse1)
        Me.Panel3.Controls.Add(Me.labelVerifBuse2)
        Me.Panel3.Controls.Add(Me.labelVerifBuse3)
        Me.Panel3.Controls.Add(Me.labelVerifBuse4)
        Me.Panel3.Controls.Add(Me.labelVerifBuse5)
        Me.Panel3.Controls.Add(Me.labelVerifBuse6)
        Me.Panel3.Location = New System.Drawing.Point(0, 79)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(72, 217)
        Me.Panel3.TabIndex = 46
        '
        'labelVerifBuse1
        '
        Me.labelVerifBuse1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_couleur", True))
        Me.labelVerifBuse1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelVerifBuse1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelVerifBuse1.Location = New System.Drawing.Point(7, 16)
        Me.labelVerifBuse1.Name = "labelVerifBuse1"
        Me.labelVerifBuse1.Size = New System.Drawing.Size(57, 24)
        Me.labelVerifBuse1.TabIndex = 9
        Me.labelVerifBuse1.Text = "Orange"
        Me.labelVerifBuse1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelVerifBuse2
        '
        Me.labelVerifBuse2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_couleur", True))
        Me.labelVerifBuse2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelVerifBuse2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelVerifBuse2.Location = New System.Drawing.Point(8, 48)
        Me.labelVerifBuse2.Name = "labelVerifBuse2"
        Me.labelVerifBuse2.Size = New System.Drawing.Size(56, 24)
        Me.labelVerifBuse2.TabIndex = 9
        Me.labelVerifBuse2.Text = "Jaune"
        Me.labelVerifBuse2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelVerifBuse3
        '
        Me.labelVerifBuse3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_couleur", True))
        Me.labelVerifBuse3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelVerifBuse3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelVerifBuse3.Location = New System.Drawing.Point(8, 80)
        Me.labelVerifBuse3.Name = "labelVerifBuse3"
        Me.labelVerifBuse3.Size = New System.Drawing.Size(56, 24)
        Me.labelVerifBuse3.TabIndex = 9
        Me.labelVerifBuse3.Text = "Rouge"
        Me.labelVerifBuse3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelVerifBuse4
        '
        Me.labelVerifBuse4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_couleur", True))
        Me.labelVerifBuse4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelVerifBuse4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelVerifBuse4.Location = New System.Drawing.Point(8, 112)
        Me.labelVerifBuse4.Name = "labelVerifBuse4"
        Me.labelVerifBuse4.Size = New System.Drawing.Size(56, 24)
        Me.labelVerifBuse4.TabIndex = 9
        Me.labelVerifBuse4.Text = "Grise"
        Me.labelVerifBuse4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelVerifBuse5
        '
        Me.labelVerifBuse5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_couleur", True))
        Me.labelVerifBuse5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelVerifBuse5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelVerifBuse5.Location = New System.Drawing.Point(8, 144)
        Me.labelVerifBuse5.Name = "labelVerifBuse5"
        Me.labelVerifBuse5.Size = New System.Drawing.Size(56, 24)
        Me.labelVerifBuse5.TabIndex = 9
        Me.labelVerifBuse5.Text = "Blanche ou autre"
        Me.labelVerifBuse5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelVerifBuse6
        '
        Me.labelVerifBuse6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_couleur", True))
        Me.labelVerifBuse6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelVerifBuse6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.labelVerifBuse6.Location = New System.Drawing.Point(8, 176)
        Me.labelVerifBuse6.Name = "labelVerifBuse6"
        Me.labelVerifBuse6.Size = New System.Drawing.Size(56, 24)
        Me.labelVerifBuse6.TabIndex = 9
        Me.labelVerifBuse6.Text = "Spéc. arbo"
        Me.labelVerifBuse6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel16.Controls.Add(Me.Label16)
        Me.Panel16.Location = New System.Drawing.Point(73, -1)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(209, 39)
        Me.Panel16.TabIndex = 45
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(8, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(192, 24)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Description buses étalonnées"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel17.Controls.Add(Me.Label17)
        Me.Panel17.Location = New System.Drawing.Point(210, 39)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(72, 39)
        Me.Panel17.TabIndex = 44
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(8, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 24)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Débit étalonné"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel18.Controls.Add(Me.controleBanc_buse2_debitEtalonne)
        Me.Panel18.Controls.Add(Me.controleBanc_buse1_debitEtalonne)
        Me.Panel18.Controls.Add(Me.controleBanc_buse3_debitEtalonne)
        Me.Panel18.Controls.Add(Me.controleBanc_buse4_debitEtalonne)
        Me.Panel18.Controls.Add(Me.controleBanc_buse5_debitEtalonne)
        Me.Panel18.Controls.Add(Me.controleBanc_buse6_debitEtalonne)
        Me.Panel18.Location = New System.Drawing.Point(210, 79)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(72, 217)
        Me.Panel18.TabIndex = 2
        '
        'controleBanc_buse2_debitEtalonne
        '
        Me.controleBanc_buse2_debitEtalonne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_debitEtal", True))
        Me.controleBanc_buse2_debitEtalonne.Location = New System.Drawing.Point(8, 48)
        Me.controleBanc_buse2_debitEtalonne.Name = "controleBanc_buse2_debitEtalonne"
        Me.controleBanc_buse2_debitEtalonne.ReadOnly = True
        Me.controleBanc_buse2_debitEtalonne.Size = New System.Drawing.Size(56, 20)
        Me.controleBanc_buse2_debitEtalonne.TabIndex = 1
        '
        'controleBanc_buse1_debitEtalonne
        '
        Me.controleBanc_buse1_debitEtalonne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_debitEtal", True))
        Me.controleBanc_buse1_debitEtalonne.Location = New System.Drawing.Point(8, 19)
        Me.controleBanc_buse1_debitEtalonne.Name = "controleBanc_buse1_debitEtalonne"
        Me.controleBanc_buse1_debitEtalonne.ReadOnly = True
        Me.controleBanc_buse1_debitEtalonne.Size = New System.Drawing.Size(56, 20)
        Me.controleBanc_buse1_debitEtalonne.TabIndex = 0
        '
        'controleBanc_buse3_debitEtalonne
        '
        Me.controleBanc_buse3_debitEtalonne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_debitEtal", True))
        Me.controleBanc_buse3_debitEtalonne.Location = New System.Drawing.Point(8, 80)
        Me.controleBanc_buse3_debitEtalonne.Name = "controleBanc_buse3_debitEtalonne"
        Me.controleBanc_buse3_debitEtalonne.ReadOnly = True
        Me.controleBanc_buse3_debitEtalonne.Size = New System.Drawing.Size(56, 20)
        Me.controleBanc_buse3_debitEtalonne.TabIndex = 2
        '
        'controleBanc_buse4_debitEtalonne
        '
        Me.controleBanc_buse4_debitEtalonne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_debitEtal", True))
        Me.controleBanc_buse4_debitEtalonne.Location = New System.Drawing.Point(8, 112)
        Me.controleBanc_buse4_debitEtalonne.Name = "controleBanc_buse4_debitEtalonne"
        Me.controleBanc_buse4_debitEtalonne.ReadOnly = True
        Me.controleBanc_buse4_debitEtalonne.Size = New System.Drawing.Size(56, 20)
        Me.controleBanc_buse4_debitEtalonne.TabIndex = 3
        '
        'controleBanc_buse5_debitEtalonne
        '
        Me.controleBanc_buse5_debitEtalonne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_debitEtal", True))
        Me.controleBanc_buse5_debitEtalonne.Location = New System.Drawing.Point(8, 144)
        Me.controleBanc_buse5_debitEtalonne.Name = "controleBanc_buse5_debitEtalonne"
        Me.controleBanc_buse5_debitEtalonne.ReadOnly = True
        Me.controleBanc_buse5_debitEtalonne.Size = New System.Drawing.Size(56, 20)
        Me.controleBanc_buse5_debitEtalonne.TabIndex = 4
        '
        'controleBanc_buse6_debitEtalonne
        '
        Me.controleBanc_buse6_debitEtalonne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_debitEtal", True))
        Me.controleBanc_buse6_debitEtalonne.Location = New System.Drawing.Point(8, 176)
        Me.controleBanc_buse6_debitEtalonne.Name = "controleBanc_buse6_debitEtalonne"
        Me.controleBanc_buse6_debitEtalonne.ReadOnly = True
        Me.controleBanc_buse6_debitEtalonne.Size = New System.Drawing.Size(56, 20)
        Me.controleBanc_buse6_debitEtalonne.TabIndex = 5
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel19.Controls.Add(Me.Label18)
        Me.Panel19.Location = New System.Drawing.Point(130, 39)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(79, 39)
        Me.Panel19.TabIndex = 42
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(8, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 24)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Pression étalonnage"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel20.Controls.Add(Me.controleBanc_buse2_pressionEtalonnage)
        Me.Panel20.Controls.Add(Me.controleBanc_buse1_pressionEtalonnage)
        Me.Panel20.Controls.Add(Me.controleBanc_buse3_pressionEtalonnage)
        Me.Panel20.Controls.Add(Me.controleBanc_buse4_pressionEtalonnage)
        Me.Panel20.Controls.Add(Me.controleBanc_buse5_pressionEtalonnage)
        Me.Panel20.Controls.Add(Me.controleBanc_buse6_pressionEtalonnage)
        Me.Panel20.Location = New System.Drawing.Point(130, 79)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(79, 217)
        Me.Panel20.TabIndex = 1
        '
        'controleBanc_buse2_pressionEtalonnage
        '
        Me.controleBanc_buse2_pressionEtalonnage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_pressionEtal", True))
        Me.controleBanc_buse2_pressionEtalonnage.Location = New System.Drawing.Point(8, 48)
        Me.controleBanc_buse2_pressionEtalonnage.Name = "controleBanc_buse2_pressionEtalonnage"
        Me.controleBanc_buse2_pressionEtalonnage.ReadOnly = True
        Me.controleBanc_buse2_pressionEtalonnage.Size = New System.Drawing.Size(64, 20)
        Me.controleBanc_buse2_pressionEtalonnage.TabIndex = 1
        Me.controleBanc_buse2_pressionEtalonnage.Text = "3"
        '
        'controleBanc_buse1_pressionEtalonnage
        '
        Me.controleBanc_buse1_pressionEtalonnage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_pressionEtal", True))
        Me.controleBanc_buse1_pressionEtalonnage.Location = New System.Drawing.Point(8, 19)
        Me.controleBanc_buse1_pressionEtalonnage.Name = "controleBanc_buse1_pressionEtalonnage"
        Me.controleBanc_buse1_pressionEtalonnage.ReadOnly = True
        Me.controleBanc_buse1_pressionEtalonnage.Size = New System.Drawing.Size(64, 20)
        Me.controleBanc_buse1_pressionEtalonnage.TabIndex = 0
        '
        'controleBanc_buse3_pressionEtalonnage
        '
        Me.controleBanc_buse3_pressionEtalonnage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_pressionEtal", True))
        Me.controleBanc_buse3_pressionEtalonnage.Location = New System.Drawing.Point(8, 80)
        Me.controleBanc_buse3_pressionEtalonnage.Name = "controleBanc_buse3_pressionEtalonnage"
        Me.controleBanc_buse3_pressionEtalonnage.ReadOnly = True
        Me.controleBanc_buse3_pressionEtalonnage.Size = New System.Drawing.Size(64, 20)
        Me.controleBanc_buse3_pressionEtalonnage.TabIndex = 2
        Me.controleBanc_buse3_pressionEtalonnage.Text = "3"
        '
        'controleBanc_buse4_pressionEtalonnage
        '
        Me.controleBanc_buse4_pressionEtalonnage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_pressionEtal", True))
        Me.controleBanc_buse4_pressionEtalonnage.Location = New System.Drawing.Point(8, 112)
        Me.controleBanc_buse4_pressionEtalonnage.Name = "controleBanc_buse4_pressionEtalonnage"
        Me.controleBanc_buse4_pressionEtalonnage.ReadOnly = True
        Me.controleBanc_buse4_pressionEtalonnage.Size = New System.Drawing.Size(64, 20)
        Me.controleBanc_buse4_pressionEtalonnage.TabIndex = 3
        Me.controleBanc_buse4_pressionEtalonnage.Text = "3"
        '
        'controleBanc_buse5_pressionEtalonnage
        '
        Me.controleBanc_buse5_pressionEtalonnage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_pressionEtal", True))
        Me.controleBanc_buse5_pressionEtalonnage.Location = New System.Drawing.Point(8, 144)
        Me.controleBanc_buse5_pressionEtalonnage.Name = "controleBanc_buse5_pressionEtalonnage"
        Me.controleBanc_buse5_pressionEtalonnage.ReadOnly = True
        Me.controleBanc_buse5_pressionEtalonnage.Size = New System.Drawing.Size(64, 20)
        Me.controleBanc_buse5_pressionEtalonnage.TabIndex = 4
        Me.controleBanc_buse5_pressionEtalonnage.Text = "3"
        '
        'controleBanc_buse6_pressionEtalonnage
        '
        Me.controleBanc_buse6_pressionEtalonnage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_pressionEtal", True))
        Me.controleBanc_buse6_pressionEtalonnage.Location = New System.Drawing.Point(8, 176)
        Me.controleBanc_buse6_pressionEtalonnage.Name = "controleBanc_buse6_pressionEtalonnage"
        Me.controleBanc_buse6_pressionEtalonnage.ReadOnly = True
        Me.controleBanc_buse6_pressionEtalonnage.Size = New System.Drawing.Size(64, 20)
        Me.controleBanc_buse6_pressionEtalonnage.TabIndex = 5
        Me.controleBanc_buse6_pressionEtalonnage.Text = "3"
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel21.Controls.Add(Me.Label19)
        Me.Panel21.Location = New System.Drawing.Point(73, 39)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(56, 39)
        Me.Panel21.TabIndex = 40
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(8, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 24)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "N° Buse"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel22.Controls.Add(Me.controleBanc_buse1_numBuse)
        Me.Panel22.Controls.Add(Me.controleBanc_buse2_numBuse)
        Me.Panel22.Controls.Add(Me.controleBanc_buse3_numBuse)
        Me.Panel22.Controls.Add(Me.controleBanc_buse4_numBuse)
        Me.Panel22.Controls.Add(Me.controleBanc_buse5_numBuse)
        Me.Panel22.Controls.Add(Me.controleBanc_buse6_numBuse)
        Me.Panel22.Location = New System.Drawing.Point(73, 79)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(56, 217)
        Me.Panel22.TabIndex = 0
        '
        'controleBanc_buse1_numBuse
        '
        Me.controleBanc_buse1_numBuse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_NumNatBuse", True))
        Me.controleBanc_buse1_numBuse.Location = New System.Drawing.Point(8, 19)
        Me.controleBanc_buse1_numBuse.Name = "controleBanc_buse1_numBuse"
        Me.controleBanc_buse1_numBuse.ReadOnly = True
        Me.controleBanc_buse1_numBuse.Size = New System.Drawing.Size(40, 20)
        Me.controleBanc_buse1_numBuse.TabIndex = 0
        '
        'controleBanc_buse2_numBuse
        '
        Me.controleBanc_buse2_numBuse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_NumNatBuse", True))
        Me.controleBanc_buse2_numBuse.Location = New System.Drawing.Point(8, 48)
        Me.controleBanc_buse2_numBuse.Name = "controleBanc_buse2_numBuse"
        Me.controleBanc_buse2_numBuse.ReadOnly = True
        Me.controleBanc_buse2_numBuse.Size = New System.Drawing.Size(40, 20)
        Me.controleBanc_buse2_numBuse.TabIndex = 1
        '
        'controleBanc_buse3_numBuse
        '
        Me.controleBanc_buse3_numBuse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_NumNatBuse", True))
        Me.controleBanc_buse3_numBuse.Location = New System.Drawing.Point(8, 80)
        Me.controleBanc_buse3_numBuse.Name = "controleBanc_buse3_numBuse"
        Me.controleBanc_buse3_numBuse.ReadOnly = True
        Me.controleBanc_buse3_numBuse.Size = New System.Drawing.Size(40, 20)
        Me.controleBanc_buse3_numBuse.TabIndex = 2
        '
        'controleBanc_buse4_numBuse
        '
        Me.controleBanc_buse4_numBuse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_NumNatBuse", True))
        Me.controleBanc_buse4_numBuse.Location = New System.Drawing.Point(8, 112)
        Me.controleBanc_buse4_numBuse.Name = "controleBanc_buse4_numBuse"
        Me.controleBanc_buse4_numBuse.ReadOnly = True
        Me.controleBanc_buse4_numBuse.Size = New System.Drawing.Size(40, 20)
        Me.controleBanc_buse4_numBuse.TabIndex = 3
        '
        'controleBanc_buse5_numBuse
        '
        Me.controleBanc_buse5_numBuse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_NumNatBuse", True))
        Me.controleBanc_buse5_numBuse.Location = New System.Drawing.Point(8, 144)
        Me.controleBanc_buse5_numBuse.Name = "controleBanc_buse5_numBuse"
        Me.controleBanc_buse5_numBuse.ReadOnly = True
        Me.controleBanc_buse5_numBuse.Size = New System.Drawing.Size(40, 20)
        Me.controleBanc_buse5_numBuse.TabIndex = 4
        '
        'controleBanc_buse6_numBuse
        '
        Me.controleBanc_buse6_numBuse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_NumNatBuse", True))
        Me.controleBanc_buse6_numBuse.Location = New System.Drawing.Point(8, 176)
        Me.controleBanc_buse6_numBuse.Name = "controleBanc_buse6_numBuse"
        Me.controleBanc_buse6_numBuse.ReadOnly = True
        Me.controleBanc_buse6_numBuse.Size = New System.Drawing.Size(40, 20)
        Me.controleBanc_buse6_numBuse.TabIndex = 5
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel11.Controls.Add(Me.Label11)
        Me.Panel11.Location = New System.Drawing.Point(535, 39)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(59, 39)
        Me.Panel11.TabIndex = 57
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 39)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Ecart Autorisé"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel12.Controls.Add(Me.controleBanc_buse1_3bar_ecartAutorise)
        Me.Panel12.Controls.Add(Me.controleBanc_buse2_3bar_ecartAutorise)
        Me.Panel12.Controls.Add(Me.controleBanc_buse4_3bar_ecartAutorise)
        Me.Panel12.Controls.Add(Me.controleBanc_buse3_3bar_ecartAutorise)
        Me.Panel12.Controls.Add(Me.controleBanc_buse5_3bar_ecartAutorise)
        Me.Panel12.Controls.Add(Me.controleBanc_buse6_3bar_ecartAutorise)
        Me.Panel12.Location = New System.Drawing.Point(535, 79)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(59, 217)
        Me.Panel12.TabIndex = 7
        '
        'controleBanc_buse1_3bar_ecartAutorise
        '
        Me.controleBanc_buse1_3bar_ecartAutorise.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_3bar_ecart", True))
        Me.controleBanc_buse1_3bar_ecartAutorise.Enabled = False
        Me.controleBanc_buse1_3bar_ecartAutorise.Location = New System.Drawing.Point(5, 19)
        Me.controleBanc_buse1_3bar_ecartAutorise.Name = "controleBanc_buse1_3bar_ecartAutorise"
        Me.controleBanc_buse1_3bar_ecartAutorise.ReadOnly = True
        Me.controleBanc_buse1_3bar_ecartAutorise.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse1_3bar_ecartAutorise.TabIndex = 0
        '
        'controleBanc_buse2_3bar_ecartAutorise
        '
        Me.controleBanc_buse2_3bar_ecartAutorise.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_3bar_ecart", True))
        Me.controleBanc_buse2_3bar_ecartAutorise.Enabled = False
        Me.controleBanc_buse2_3bar_ecartAutorise.Location = New System.Drawing.Point(5, 48)
        Me.controleBanc_buse2_3bar_ecartAutorise.Name = "controleBanc_buse2_3bar_ecartAutorise"
        Me.controleBanc_buse2_3bar_ecartAutorise.ReadOnly = True
        Me.controleBanc_buse2_3bar_ecartAutorise.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse2_3bar_ecartAutorise.TabIndex = 1
        '
        'controleBanc_buse4_3bar_ecartAutorise
        '
        Me.controleBanc_buse4_3bar_ecartAutorise.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_3bar_ecart", True))
        Me.controleBanc_buse4_3bar_ecartAutorise.Enabled = False
        Me.controleBanc_buse4_3bar_ecartAutorise.Location = New System.Drawing.Point(5, 112)
        Me.controleBanc_buse4_3bar_ecartAutorise.Name = "controleBanc_buse4_3bar_ecartAutorise"
        Me.controleBanc_buse4_3bar_ecartAutorise.ReadOnly = True
        Me.controleBanc_buse4_3bar_ecartAutorise.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse4_3bar_ecartAutorise.TabIndex = 3
        '
        'controleBanc_buse3_3bar_ecartAutorise
        '
        Me.controleBanc_buse3_3bar_ecartAutorise.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_3bar_ecart", True))
        Me.controleBanc_buse3_3bar_ecartAutorise.Enabled = False
        Me.controleBanc_buse3_3bar_ecartAutorise.Location = New System.Drawing.Point(5, 80)
        Me.controleBanc_buse3_3bar_ecartAutorise.Name = "controleBanc_buse3_3bar_ecartAutorise"
        Me.controleBanc_buse3_3bar_ecartAutorise.ReadOnly = True
        Me.controleBanc_buse3_3bar_ecartAutorise.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse3_3bar_ecartAutorise.TabIndex = 2
        '
        'controleBanc_buse5_3bar_ecartAutorise
        '
        Me.controleBanc_buse5_3bar_ecartAutorise.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_3bar_ecart", True))
        Me.controleBanc_buse5_3bar_ecartAutorise.Enabled = False
        Me.controleBanc_buse5_3bar_ecartAutorise.Location = New System.Drawing.Point(5, 144)
        Me.controleBanc_buse5_3bar_ecartAutorise.Name = "controleBanc_buse5_3bar_ecartAutorise"
        Me.controleBanc_buse5_3bar_ecartAutorise.ReadOnly = True
        Me.controleBanc_buse5_3bar_ecartAutorise.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse5_3bar_ecartAutorise.TabIndex = 4
        '
        'controleBanc_buse6_3bar_ecartAutorise
        '
        Me.controleBanc_buse6_3bar_ecartAutorise.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_3bar_ecart", True))
        Me.controleBanc_buse6_3bar_ecartAutorise.Enabled = False
        Me.controleBanc_buse6_3bar_ecartAutorise.Location = New System.Drawing.Point(5, 176)
        Me.controleBanc_buse6_3bar_ecartAutorise.Name = "controleBanc_buse6_3bar_ecartAutorise"
        Me.controleBanc_buse6_3bar_ecartAutorise.ReadOnly = True
        Me.controleBanc_buse6_3bar_ecartAutorise.Size = New System.Drawing.Size(48, 20)
        Me.controleBanc_buse6_3bar_ecartAutorise.TabIndex = 5
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel13.Controls.Add(Me.Label12)
        Me.Panel13.Location = New System.Drawing.Point(463, 39)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(71, 39)
        Me.Panel13.TabIndex = 57
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(6, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 24)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Moyenne"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel14.Controls.Add(Me.controleBanc_buse1_3bar_moyenne)
        Me.Panel14.Controls.Add(Me.controleBanc_buse2_3bar_moyenne)
        Me.Panel14.Controls.Add(Me.controleBanc_buse4_3bar_moyenne)
        Me.Panel14.Controls.Add(Me.controleBanc_buse3_3bar_moyenne)
        Me.Panel14.Controls.Add(Me.controleBanc_buse5_3bar_moyenne)
        Me.Panel14.Controls.Add(Me.controleBanc_buse6_3bar_moyenne)
        Me.Panel14.Location = New System.Drawing.Point(463, 79)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(71, 217)
        Me.Panel14.TabIndex = 6
        '
        'controleBanc_buse1_3bar_moyenne
        '
        Me.controleBanc_buse1_3bar_moyenne.BackColor = System.Drawing.SystemColors.Control
        Me.controleBanc_buse1_3bar_moyenne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b1_3bar_moy", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.controleBanc_buse1_3bar_moyenne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.controleBanc_buse1_3bar_moyenne.Location = New System.Drawing.Point(6, 19)
        Me.controleBanc_buse1_3bar_moyenne.Name = "controleBanc_buse1_3bar_moyenne"
        Me.controleBanc_buse1_3bar_moyenne.ReadOnly = True
        Me.controleBanc_buse1_3bar_moyenne.Size = New System.Drawing.Size(58, 20)
        Me.controleBanc_buse1_3bar_moyenne.TabIndex = 0
        '
        'controleBanc_buse2_3bar_moyenne
        '
        Me.controleBanc_buse2_3bar_moyenne.BackColor = System.Drawing.SystemColors.Control
        Me.controleBanc_buse2_3bar_moyenne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b2_3bar_moy", True))
        Me.controleBanc_buse2_3bar_moyenne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.controleBanc_buse2_3bar_moyenne.Location = New System.Drawing.Point(6, 48)
        Me.controleBanc_buse2_3bar_moyenne.Name = "controleBanc_buse2_3bar_moyenne"
        Me.controleBanc_buse2_3bar_moyenne.ReadOnly = True
        Me.controleBanc_buse2_3bar_moyenne.Size = New System.Drawing.Size(58, 20)
        Me.controleBanc_buse2_3bar_moyenne.TabIndex = 1
        '
        'controleBanc_buse4_3bar_moyenne
        '
        Me.controleBanc_buse4_3bar_moyenne.BackColor = System.Drawing.SystemColors.Control
        Me.controleBanc_buse4_3bar_moyenne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b4_3bar_moy", True))
        Me.controleBanc_buse4_3bar_moyenne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.controleBanc_buse4_3bar_moyenne.Location = New System.Drawing.Point(6, 112)
        Me.controleBanc_buse4_3bar_moyenne.Name = "controleBanc_buse4_3bar_moyenne"
        Me.controleBanc_buse4_3bar_moyenne.ReadOnly = True
        Me.controleBanc_buse4_3bar_moyenne.Size = New System.Drawing.Size(58, 20)
        Me.controleBanc_buse4_3bar_moyenne.TabIndex = 3
        '
        'controleBanc_buse3_3bar_moyenne
        '
        Me.controleBanc_buse3_3bar_moyenne.BackColor = System.Drawing.SystemColors.Control
        Me.controleBanc_buse3_3bar_moyenne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b3_3bar_moy", True))
        Me.controleBanc_buse3_3bar_moyenne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.controleBanc_buse3_3bar_moyenne.Location = New System.Drawing.Point(6, 80)
        Me.controleBanc_buse3_3bar_moyenne.Name = "controleBanc_buse3_3bar_moyenne"
        Me.controleBanc_buse3_3bar_moyenne.ReadOnly = True
        Me.controleBanc_buse3_3bar_moyenne.Size = New System.Drawing.Size(58, 20)
        Me.controleBanc_buse3_3bar_moyenne.TabIndex = 2
        '
        'controleBanc_buse5_3bar_moyenne
        '
        Me.controleBanc_buse5_3bar_moyenne.BackColor = System.Drawing.SystemColors.Control
        Me.controleBanc_buse5_3bar_moyenne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b5_3bar_moy", True))
        Me.controleBanc_buse5_3bar_moyenne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.controleBanc_buse5_3bar_moyenne.Location = New System.Drawing.Point(6, 144)
        Me.controleBanc_buse5_3bar_moyenne.Name = "controleBanc_buse5_3bar_moyenne"
        Me.controleBanc_buse5_3bar_moyenne.ReadOnly = True
        Me.controleBanc_buse5_3bar_moyenne.Size = New System.Drawing.Size(58, 20)
        Me.controleBanc_buse5_3bar_moyenne.TabIndex = 4
        '
        'controleBanc_buse6_3bar_moyenne
        '
        Me.controleBanc_buse6_3bar_moyenne.BackColor = System.Drawing.SystemColors.Control
        Me.controleBanc_buse6_3bar_moyenne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "b6_3bar_moy", True))
        Me.controleBanc_buse6_3bar_moyenne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.controleBanc_buse6_3bar_moyenne.Location = New System.Drawing.Point(6, 176)
        Me.controleBanc_buse6_3bar_moyenne.Name = "controleBanc_buse6_3bar_moyenne"
        Me.controleBanc_buse6_3bar_moyenne.ReadOnly = True
        Me.controleBanc_buse6_3bar_moyenne.Size = New System.Drawing.Size(58, 20)
        Me.controleBanc_buse6_3bar_moyenne.TabIndex = 5
        '
        'Label28
        '
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(8, 556)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(584, 96)
        Me.Label28.TabIndex = 21
        Me.Label28.Text = resources.GetString("Label28.Text")
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'controleBanc_resultat
        '
        Me.controleBanc_resultat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsControleBanc, "resultat", True))
        Me.controleBanc_resultat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.controleBanc_resultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.controleBanc_resultat.ForeColor = System.Drawing.Color.Red
        Me.controleBanc_resultat.Location = New System.Drawing.Point(3, 16)
        Me.controleBanc_resultat.Name = "controleBanc_resultat"
        Me.controleBanc_resultat.Size = New System.Drawing.Size(250, 77)
        Me.controleBanc_resultat.TabIndex = 22
        Me.controleBanc_resultat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_controleBanc_valider
        '
        Me.btn_controleBanc_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleBanc_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleBanc_valider.ForeColor = System.Drawing.Color.White
        Me.btn_controleBanc_valider.Image = CType(resources.GetObject("btn_controleBanc_valider.Image"), System.Drawing.Image)
        Me.btn_controleBanc_valider.Location = New System.Drawing.Point(862, 596)
        Me.btn_controleBanc_valider.Name = "btn_controleBanc_valider"
        Me.btn_controleBanc_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleBanc_valider.TabIndex = 3
        Me.btn_controleBanc_valider.Text = "    Valider / Quitter"
        Me.btn_controleBanc_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_controleBanc_annuler
        '
        Me.btn_controleBanc_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleBanc_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleBanc_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_controleBanc_annuler.Image = CType(resources.GetObject("btn_controleBanc_annuler.Image"), System.Drawing.Image)
        Me.btn_controleBanc_annuler.Location = New System.Drawing.Point(862, 628)
        Me.btn_controleBanc_annuler.Name = "btn_controleBanc_annuler"
        Me.btn_controleBanc_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleBanc_annuler.TabIndex = 4
        Me.btn_controleBanc_annuler.Text = "    Annuler"
        Me.btn_controleBanc_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.controleBanc_resultat)
        Me.GroupBox1.Location = New System.Drawing.Point(600, 556)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 96)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Résultat de la vérification"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(545, 656)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(451, 16)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Vous devez être connecté à internet pour valider votre controle"
        '
        'frmcontrole_bancs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_controleBanc_valider)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.grp_infoGenerales)
        Me.Controls.Add(Me.Label82)
        Me.Controls.Add(Me.grp_temperatures)
        Me.Controls.Add(Me.grp_verification)
        Me.Controls.Add(Me.btn_controleBanc_annuler)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmcontrole_bancs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Contrôle des bancs"
        Me.grp_infoGenerales.ResumeLayout(False)
        CType(Me.m_bsBuses1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsBuses2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsBuses3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsBuses4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsBuses5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsBuses6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsControleBanc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_temperatures.ResumeLayout(False)
        Me.grp_temperatures.PerformLayout()
        Me.grp_verification.ResumeLayout(False)
        Me.panel_Array.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel19.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel22.ResumeLayout(False)
        Me.Panel22.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel

#End Region

    Private Sub controle_bancs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        labelVerifBuse1.Text = ""
        labelVerifBuse2.Text = ""
        labelVerifBuse3.Text = ""
        labelVerifBuse4.Text = ""
        labelVerifBuse5.Text = ""
        labelVerifBuse6.Text = ""

        dtpDateVerif.Value = Date.Now

        '###########################################################
        '################ Chargement des buses etalon ##############
        '###########################################################
        ' On récupère les buses étalon de l'agent
        Dim arrBusesEtalon As List(Of Buse) = BuseManager.getlstByAgent(agentCourant, False)
        ' On rempli les listes
        Dim positionTop As Integer = 0
        For Each tmpBuseEtalon As Buse In arrBusesEtalon
            m_bsBuses1.Add(tmpBuseEtalon)
            m_bsBuses2.Add(tmpBuseEtalon)
            m_bsBuses3.Add(tmpBuseEtalon)
            m_bsBuses4.Add(tmpBuseEtalon)
            m_bsBuses5.Add(tmpBuseEtalon)
            m_bsBuses6.Add(tmpBuseEtalon)
            '            Dim objComboItem As New objComboItem(tmpBuseEtalon.numeroNational, tmpBuseEtalon.idCrodip & " (" & tmpBuseEtalon.couleur & ")")
            'controleBanc_buse1.Items.Add(objComboItem)
            'controleBanc_buse2.Items.Add(objComboItem)
            'controleBanc_buse3.Items.Add(objComboItem)
            'controleBanc_buse4.Items.Add(objComboItem)
            'controleBanc_buse5.Items.Add(objComboItem)
            'controleBanc_buse6.Items.Add(objComboItem)
        Next
        controleBanc_buse1.SelectedIndex = -1
        controleBanc_buse2.SelectedIndex = -1
        controleBanc_buse3.SelectedIndex = -1
        controleBanc_buse4.SelectedIndex = -1
        controleBanc_buse5.SelectedIndex = -1
        controleBanc_buse6.SelectedIndex = -1

        '###########################################################
        '################### Chargement des bancs ##################
        '###########################################################
        Dim arrBanc As List(Of Banc)
        arrBanc = BancManager.getBancByAgent(agentCourant, True)
        GlobalsCRODIP.GLOB_NETWORKAVAILABLE = CSEnvironnement.checkNetwork()
        For Each tmpBanc As Banc In arrBanc
            If GlobalsCRODIP.GLOB_NETWORKAVAILABLE Then
                'Lecture du WS si connecté
                tmpBanc = BancManager.WSgetById(tmpBanc.uid, tmpBanc.aid)
            End If
            Dim objComboItem As New objComboItem(tmpBanc.id, tmpBanc.marque & " (" & tmpBanc.id & ")")
            controleBanc_numBanc.Items.Add(objComboItem)
        Next
        If arrBanc.Count = 1 Then
            controleBanc_numBanc.SelectedIndex = 0
        End If
        ' Création du controlebanc
        m_oControleBanc = New ControleBanc()
        m_bsControleBanc.Add(m_oControleBanc)
    End Sub


#Region " Boutons "

    ' Validation du contrôle
    Private Sub btn_controleBanc_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleBanc_valider.Click
        GlobalsCRODIP.GLOB_NETWORKAVAILABLE = CSEnvironnement.checkNetwork()
        If GlobalsCRODIP.GLOB_NETWORKAVAILABLE Then
            ' Numéro du banc
            If controleBanc_numBanc.Text <> "" Then
                ' Températures obligatoires
                Dim bTemp As Boolean
                bTemp = Not String.IsNullOrEmpty(controleBanc_extTemp.Text)
                bTemp = bTemp And (Not String.IsNullOrEmpty(controleBanc_eauTemp.Text))
                bTemp = bTemp And (IsNumeric(controleBanc_extTemp.Text))
                bTemp = bTemp And (IsNumeric(controleBanc_eauTemp.Text))
                If bTemp Then
                    '5 buses Minimum
                    Dim obuse As Buse
                    Dim nBuse As Integer = 0
                    For i As Integer = 1 To 6
                        Try
                            ' On récupère les controles
                            Dim cbxBuseList As ComboBox = CSForm.getControlByName("controleBanc_buse" & i, Me)
                            If cbxBuseList.SelectedItem IsNot Nothing Then
                                ' On récupère la buse
                                obuse = TryCast(cbxBuseList.SelectedItem, Buse)
                                If obuse IsNot Nothing Then
                                    nBuse = nBuse + 1
                                End If
                            End If

                        Catch ex As Exception
                            CSDebug.dispError("controle_banc::btn_controleBanc_valider_Click(Flag) : " & ex.Message)
                        End Try
                    Next

                    If nBuse >= 5 Then
                        If m_oControleBanc.isComplet() Then
                            valider()
                        Else
                            MsgBox(GlobalsCRODIP.CONST_INFO_CTRLBANC_ERR_MESURES)
                        End If
                    Else
                        MsgBox(GlobalsCRODIP.CONST_INFO_CTRLBANC_ERR_5BUSES)

                    End If

                Else
                    MsgBox(GlobalsCRODIP.CONST_INFO_CTRLBANC_ERR_NOTEMP)
                End If
            Else
                MsgBox(GlobalsCRODIP.CONST_INFO_CTRLBANC_ERR_NOBANCNUM)
            End If
        Else
            MsgBox("Vous devez être connecté à internet pour valider votre controle", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
        End If

    End Sub
    Private Sub valider()
        Dim oBuse As Buse
        m_oControleBanc.tempEau = controleBanc_eauTemp.Text
        m_oControleBanc.tempExt = controleBanc_extTemp.Text
        m_oControleBanc.DateVerif = CSDate.GetDateForWS(dtpDateVerif.Value)

        ' On récupère le banc
        Dim curBanc As Banc = BancManager.getBancById(controleBanc_numBanc.SelectedItem.Id.ToString)

        ' Mise a jour de l'objet Banc
        Try
            curBanc.etat = m_oControleBanc.bResultat
            curBanc.dateDernierControleS = m_oControleBanc.DateVerif
            BancManager.save(curBanc)
        Catch ex As Exception
            CSDebug.dispFatal("controle_banc::btn_controleBanc_valider_Click : " & ex.Message)
        End Try

        ' construction de l'objet FicheDeVie "Controle"
        Dim oEtat As New EtatFVBanc(m_oControleBanc)
        Dim sFileName As String = oEtat.buildPDF(curBanc, agentCourant)
        Dim oFV As FVBanc
        oFV = curBanc.creerfFicheVieControle(agentCourant, m_oControleBanc, sFileName)
        If oFV.FVFileName <> "" Then
            CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE & oFV.FVFileName)
        End If

        ' On marque les buses comme etant utilisées
        For i As Integer = 1 To 6
            Try

                ' On récupère les controles
                Dim cbxBuseList As ComboBox = CSForm.getControlByName("controleBanc_buse" & i, Me)
                If cbxBuseList.SelectedItem IsNot Nothing Then
                    ' On récupère la buse
                    oBuse = TryCast(cbxBuseList.SelectedItem, Buse)
                    If oBuse IsNot Nothing Then
                        BuseManager.setUtilise(oBuse)
                    End If
                End If

            Catch ex As Exception
                CSDebug.dispError("controle_banc::btn_controleBanc_valider_Click(Flag) : " & ex.Message)
            End Try
        Next
        'Synchronisation 
        If CSEnvironnement.checkNetwork() Then
            Dim oBancReturn As Banc = Nothing
            BancManager.WSSend(curBanc, oBancReturn)
            BancManager.save(oBancReturn, True)
            Dim oFVReturn As FVBanc = Nothing
            FVBancManager.WSSend(oFV, oFVReturn)
            FVBancManager.SendEtats(oFV)
            If oFVReturn IsNot Nothing Then
                FVBancManager.save(oFVReturn, True)
            End If
        End If


        TryCast(MdiParent, parentContener).ReturnToAccueil()

    End Sub
    ' Annulation
    Private Sub btn_controleBanc_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleBanc_annuler.Click
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

#End Region


#Region " Events "

    ' activation du contrôle si Banc selectionné
    Private Sub controleBanc_numBanc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles controleBanc_numBanc.SelectedIndexChanged
        grp_verification.Enabled = True
    End Sub

#Region " Contrôles de saisie "

    Private Sub controleBanc_extTemp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles controleBanc_extTemp.KeyPress
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub

    Private Sub controleBanc_eauTemp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles controleBanc_eauTemp.KeyPress
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub

#End Region

#Region " Colorisation des moyennes "


    Private Sub controleBanc_buse1_3bar_moyenne_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub controleBanc_buse2_3bar_moyenne_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub controleBanc_buse3_3bar_moyenne_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub controleBanc_buse4_3bar_moyenne_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub controleBanc_buse5_3bar_moyenne_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub controleBanc_buse6_3bar_moyenne_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

#End Region

#Region " Inputs de mesures "
    Private Sub controleBanc_buse1_3bar_mesure_TextChanged(sender As Object, e As EventArgs) Handles controleBanc_buse1_3bar_mesure3.TextChanged, controleBanc_buse1_3bar_mesure1.TextChanged, controleBanc_buse1_3bar_mesure2.TextChanged
        If IsNumeric(sender.Text) Then
            calc_moy_buse1()
        End If
    End Sub
    Private Sub controleBanc_buse2_3bar_mesure_TextChanged(sender As Object, e As EventArgs) Handles controleBanc_buse2_3bar_mesure3.TextChanged, controleBanc_buse2_3bar_mesure1.TextChanged, controleBanc_buse2_3bar_mesure2.TextChanged
        If IsNumeric(sender.Text) Then
            calc_moy_buse2()
        End If
    End Sub
    Private Sub controleBanc_buse3_3bar_mesure_TextChanged(sender As Object, e As EventArgs) Handles controleBanc_buse3_3bar_mesure1.TextChanged, controleBanc_buse3_3bar_mesure2.TextChanged, controleBanc_buse3_3bar_mesure3.TextChanged
        If IsNumeric(sender.Text) Then
            calc_moy_buse3()
        End If
    End Sub
    Private Sub controleBanc_buse4_3bar_mesure_TextChanged(sender As Object, e As EventArgs) Handles controleBanc_buse4_3bar_mesure1.TextChanged, controleBanc_buse4_3bar_mesure2.TextChanged, controleBanc_buse4_3bar_mesure3.TextChanged
        If IsNumeric(sender.Text) Then
            calc_moy_buse4()
        End If
    End Sub
    Private Sub controleBanc_buse5_3bar_mesure_TextChanged(sender As Object, e As EventArgs) Handles controleBanc_buse5_3bar_mesure1.TextChanged, controleBanc_buse5_3bar_mesure2.TextChanged, controleBanc_buse5_3bar_mesure3.TextChanged
        If IsNumeric(sender.Text) Then
            calc_moy_buse5()
        End If
    End Sub
    Private Sub controleBanc_buse6_3bar_mesure_TextChanged(sender As Object, e As EventArgs) Handles controleBanc_buse6_3bar_mesure1.TextChanged, controleBanc_buse6_3bar_mesure2.TextChanged, controleBanc_buse6_3bar_mesure3.TextChanged
        If IsNumeric(sender.Text) Then
            calc_moy_buse6()
        End If
    End Sub


#End Region

#End Region

#Region " Calculs "



#Region " Calcul des moyennes "
    Private Sub calc_moy_buse1()
        m_oControleBanc.calc1()
        m_bsControleBanc.ResetCurrentItem()
        If m_oControleBanc.b1_3bar_conformite Then
            controleBanc_buse1_3bar_moyenne.BackColor = CONST_COLOR_CELL_OK
        Else
            controleBanc_buse1_3bar_moyenne.BackColor = CONST_COLOR_CELL_NOK
        End If
    End Sub
    Private Sub calc_moy_buse2()
        m_oControleBanc.calc2()
        m_bsControleBanc.ResetCurrentItem()
        If m_oControleBanc.b2_3bar_conformite Then
            controleBanc_buse2_3bar_moyenne.BackColor = CONST_COLOR_CELL_OK
        Else
            controleBanc_buse2_3bar_moyenne.BackColor = CONST_COLOR_CELL_NOK

        End If
    End Sub
    Private Sub calc_moy_buse3()
        m_oControleBanc.calc3()
        m_bsControleBanc.ResetCurrentItem()
        If m_oControleBanc.b3_3bar_conformite Then
            controleBanc_buse3_3bar_moyenne.BackColor = CONST_COLOR_CELL_OK
        Else
            controleBanc_buse3_3bar_moyenne.BackColor = CONST_COLOR_CELL_NOK

        End If
    End Sub
    Private Sub calc_moy_buse4()
        m_oControleBanc.calc4()
        m_bsControleBanc.ResetCurrentItem()
        If m_oControleBanc.b4_3bar_conformite Then
            controleBanc_buse4_3bar_moyenne.BackColor = CONST_COLOR_CELL_OK
        Else
            controleBanc_buse4_3bar_moyenne.BackColor = CONST_COLOR_CELL_NOK

        End If
    End Sub
    Private Sub calc_moy_buse5()
        m_oControleBanc.calc5()
        m_bsControleBanc.ResetCurrentItem()
        If m_oControleBanc.b5_3bar_conformite Then
            controleBanc_buse5_3bar_moyenne.BackColor = CONST_COLOR_CELL_OK
        Else
            controleBanc_buse5_3bar_moyenne.BackColor = CONST_COLOR_CELL_NOK

        End If
    End Sub
    Private Sub calc_moy_buse6()
        m_oControleBanc.calc6()
        m_bsControleBanc.ResetCurrentItem()
        If m_oControleBanc.b6_3bar_conformite Then
            controleBanc_buse6_3bar_moyenne.BackColor = CONST_COLOR_CELL_OK
        Else
            controleBanc_buse6_3bar_moyenne.BackColor = CONST_COLOR_CELL_NOK

        End If
    End Sub
#End Region

#End Region

#Region " Autres Controles "

#Region " Sélection des buses "
    Private Sub controleBanc_buse1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles controleBanc_buse1.SelectedIndexChanged
        Try
            ' On commence par récupérer la buse sélectionnée
            Dim oBuse As Buse
            oBuse = controleBanc_buse1.SelectedItem
            If oBuse IsNot Nothing Then
                m_oControleBanc.setbuse1(oBuse)
                m_bsControleBanc.ResetCurrentItem()

                controleBanc_buse1_3bar_mesure1.Enabled = True
                controleBanc_buse1_3bar_mesure2.Enabled = True
                controleBanc_buse1_3bar_mesure3.Enabled = True
            End If
        Catch ex As Exception
            CSDebug.dispError("Selection buse : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub controleBanc_buse2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles controleBanc_buse2.SelectedIndexChanged
        Try
            ' On commence par récupérer la buse sélectionnée
            Dim oBuse As Buse
            oBuse = controleBanc_buse2.SelectedItem
            If oBuse IsNot Nothing Then
                m_oControleBanc.setbuse2(oBuse)
                m_bsControleBanc.ResetCurrentItem()

                controleBanc_buse2_3bar_mesure1.Enabled = True
                controleBanc_buse2_3bar_mesure2.Enabled = True
                controleBanc_buse2_3bar_mesure3.Enabled = True

            End If
        Catch ex As Exception
            CSDebug.dispError("Selection buse : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub controleBanc_buse3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles controleBanc_buse3.SelectedIndexChanged
        Try
            ' On commence par récupérer la buse sélectionnée
            Dim oBuse As Buse
            oBuse = controleBanc_buse3.SelectedItem
            If oBuse IsNot Nothing Then
                m_oControleBanc.setbuse3(oBuse)
                m_bsControleBanc.ResetCurrentItem()

                controleBanc_buse3_3bar_mesure1.Enabled = True
                controleBanc_buse3_3bar_mesure2.Enabled = True
                controleBanc_buse3_3bar_mesure3.Enabled = True

            End If
        Catch ex As Exception
            CSDebug.dispError("Selection buse3 : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub controleBanc_buse4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles controleBanc_buse4.SelectedIndexChanged
        Try
            ' On commence par récupérer la buse sélectionnée
            Dim oBuse As Buse
            oBuse = controleBanc_buse4.SelectedItem
            If oBuse IsNot Nothing Then
                m_oControleBanc.setbuse4(oBuse)
                m_bsControleBanc.ResetCurrentItem()

                controleBanc_buse4_3bar_mesure1.Enabled = True
                controleBanc_buse4_3bar_mesure2.Enabled = True
                controleBanc_buse4_3bar_mesure3.Enabled = True

            End If
        Catch ex As Exception
            CSDebug.dispError("Selection buse 4 : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub controleBanc_buse5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles controleBanc_buse5.SelectedIndexChanged
        Try
            ' On commence par récupérer la buse sélectionnée
            Dim oBuse As Buse
            oBuse = controleBanc_buse5.SelectedItem
            If oBuse IsNot Nothing Then
                m_oControleBanc.setbuse5(oBuse)
                m_bsControleBanc.ResetCurrentItem()

                controleBanc_buse5_3bar_mesure1.Enabled = True
                controleBanc_buse5_3bar_mesure2.Enabled = True
                controleBanc_buse5_3bar_mesure3.Enabled = True

            End If
        Catch ex As Exception
            CSDebug.dispError("Selection buse : " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub controleBanc_buse6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles controleBanc_buse6.SelectedIndexChanged
        Try
            ' On commence par récupérer la buse sélectionnée
            Dim oBuse As Buse
            oBuse = controleBanc_buse6.SelectedItem
            If oBuse IsNot Nothing Then
                m_oControleBanc.setbuse6(oBuse)
                m_bsControleBanc.ResetCurrentItem()

                controleBanc_buse6_3bar_mesure1.Enabled = True
                controleBanc_buse6_3bar_mesure2.Enabled = True
                controleBanc_buse6_3bar_mesure3.Enabled = True

            End If
        Catch ex As Exception
            CSDebug.dispError("Selection buse 6 : " & ex.Message.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' Affichage du résultat
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub controleBanc_resultat_TextChanged(sender As Object, e As EventArgs) Handles controleBanc_resultat.TextChanged
        Dim oLabel As Label
        oLabel = TryCast(sender, Label)
        If oLabel IsNot Nothing Then
            If m_oControleBanc.bResultat Then
                oLabel.ForeColor = System.Drawing.Color.Green
            Else
                oLabel.ForeColor = System.Drawing.Color.Red
            End If
        End If
    End Sub

#End Region

#End Region







    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub
End Class
