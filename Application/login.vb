Imports System.IO
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
'Imports System.Drawing
'Imports System.Drawing.Imaging
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Collections.Generic
Imports CRODIPWS
Imports System.Linq

Public Class login
    Inherits frmCRODIP
    Private _LocalAgent As Agent

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()
        panel_splashSynchro.Visible = False

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
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents login_profil As System.Windows.Forms.ComboBox
    Friend WithEvents login_password As System.Windows.Forms.TextBox
    Friend WithEvents picto_profil As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_login_seConnecter As System.Windows.Forms.Label
    Friend WithEvents btn_login_ajouterProfil As System.Windows.Forms.Label
    Public WithEvents panel_splashSynchro As System.Windows.Forms.Panel
    Friend WithEvents lbl_environnement_ws As System.Windows.Forms.Label
    Friend WithEvents lbl_environnement_debugType As System.Windows.Forms.Label
    Friend WithEvents lbl_environnement_debugLvl As System.Windows.Forms.Label
    'Friend WithEvents cr_facture As CrystalDecisions.Windows.Forms.CrystalReportViewer
    '   Friend WithEvents cr_debitBuses As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Lbl_Version As System.Windows.Forms.Label
    Friend WithEvents GroupBox_test As System.Windows.Forms.GroupBox
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnTestDiagContext As System.Windows.Forms.Button
    Friend WithEvents pnlLoginControls As System.Windows.Forms.Panel
    Friend WithEvents cbTestRIFin As Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents brnTestDiagRecap As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnTesttrtSemences As System.Windows.Forms.Button
    Friend WithEvents bntGetWSDiag As System.Windows.Forms.Button
    Friend WithEvents btn_dlgAcquisition As Button
    Friend WithEvents lblMode As Label
    Friend WithEvents btnTSTSignature As Button
    Friend WithEvents lblBaseDonnee As Label
    Friend WithEvents btnLieuxControles As Button
    Friend WithEvents btnExploitant As Button
    Friend WithEvents btnTestFacture As Button
    Friend WithEvents pnlPools As Panel
    Friend WithEvents dgvPools As DataGridView
    Friend WithEvents m_bsrcPools As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents pctSynchro As PictureBox
    Friend WithEvents lblSynchro As Label
    Friend WithEvents btn_login_seConnecter2 As Label
    Friend WithEvents idPool As DataGridViewTextBoxColumn
    Friend WithEvents libelle As DataGridViewTextBoxColumn
    Friend WithEvents aidbanc As DataGridViewTextBoxColumn
    Friend WithEvents lbl_WS As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.pnlPools = New System.Windows.Forms.Panel()
        Me.btn_login_seConnecter2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPools = New System.Windows.Forms.DataGridView()
        Me.m_bsrcPools = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblBaseDonnee = New System.Windows.Forms.Label()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.pnlLoginControls = New System.Windows.Forms.Panel()
        Me.btn_login_seConnecter = New System.Windows.Forms.Label()
        Me.btn_login_ajouterProfil = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.login_password = New System.Windows.Forms.TextBox()
        Me.login_profil = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_Version = New System.Windows.Forms.Label()
        Me.lbl_environnement_ws = New System.Windows.Forms.Label()
        Me.GroupBox_test = New System.Windows.Forms.GroupBox()
        Me.btnTestFacture = New System.Windows.Forms.Button()
        Me.btnExploitant = New System.Windows.Forms.Button()
        Me.btnLieuxControles = New System.Windows.Forms.Button()
        Me.btnTSTSignature = New System.Windows.Forms.Button()
        Me.btn_dlgAcquisition = New System.Windows.Forms.Button()
        Me.bntGetWSDiag = New System.Windows.Forms.Button()
        Me.btnTesttrtSemences = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.brnTestDiagRecap = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbTestRIFin = New System.Windows.Forms.Button()
        Me.btnTestDiagContext = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.panel_splashSynchro = New System.Windows.Forms.Panel()
        Me.pctSynchro = New System.Windows.Forms.PictureBox()
        Me.lblSynchro = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picto_profil = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_environnement_debugType = New System.Windows.Forms.Label()
        Me.lbl_environnement_debugLvl = New System.Windows.Forms.Label()
        Me.lbl_WS = New System.Windows.Forms.Label()
        Me.idPool = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.libelle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aidbanc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlPrincipal.SuspendLayout()
        Me.pnlPools.SuspendLayout()
        CType(Me.dgvPools, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcPools, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLoginControls.SuspendLayout()
        Me.GroupBox_test.SuspendLayout()
        Me.panel_splashSynchro.SuspendLayout()
        CType(Me.pctSynchro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picto_profil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(202, 25)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 23)
        Me.Button3.TabIndex = 32
        Me.Button3.Text = "Synth sans DM"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrincipal.BackgroundImage = Global.Crodip_agent.Resources.login_bgVide
        Me.pnlPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPrincipal.Controls.Add(Me.pnlPools)
        Me.pnlPrincipal.Controls.Add(Me.lblBaseDonnee)
        Me.pnlPrincipal.Controls.Add(Me.lblMode)
        Me.pnlPrincipal.Controls.Add(Me.pnlLoginControls)
        Me.pnlPrincipal.Controls.Add(Me.Lbl_Version)
        Me.pnlPrincipal.Controls.Add(Me.lbl_environnement_ws)
        Me.pnlPrincipal.Controls.Add(Me.GroupBox_test)
        Me.pnlPrincipal.Controls.Add(Me.panel_splashSynchro)
        Me.pnlPrincipal.Controls.Add(Me.Label6)
        Me.pnlPrincipal.Controls.Add(Me.picto_profil)
        Me.pnlPrincipal.Controls.Add(Me.Label3)
        Me.pnlPrincipal.Controls.Add(Me.lbl_environnement_debugType)
        Me.pnlPrincipal.Controls.Add(Me.lbl_environnement_debugLvl)
        Me.pnlPrincipal.Controls.Add(Me.lbl_WS)
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1008, 680)
        Me.pnlPrincipal.TabIndex = 0
        '
        'pnlPools
        '
        Me.pnlPools.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.pnlPools.Controls.Add(Me.btn_login_seConnecter2)
        Me.pnlPools.Controls.Add(Me.Label1)
        Me.pnlPools.Controls.Add(Me.dgvPools)
        Me.pnlPools.Location = New System.Drawing.Point(459, 349)
        Me.pnlPools.Name = "pnlPools"
        Me.pnlPools.Size = New System.Drawing.Size(436, 139)
        Me.pnlPools.TabIndex = 35
        Me.pnlPools.Visible = False
        '
        'btn_login_seConnecter2
        '
        Me.btn_login_seConnecter2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_login_seConnecter2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login_seConnecter2.ForeColor = System.Drawing.Color.White
        Me.btn_login_seConnecter2.Image = CType(resources.GetObject("btn_login_seConnecter2.Image"), System.Drawing.Image)
        Me.btn_login_seConnecter2.Location = New System.Drawing.Point(304, 104)
        Me.btn_login_seConnecter2.Name = "btn_login_seConnecter2"
        Me.btn_login_seConnecter2.Size = New System.Drawing.Size(128, 24)
        Me.btn_login_seConnecter2.TabIndex = 4
        Me.btn_login_seConnecter2.Text = "       Se connecter"
        Me.btn_login_seConnecter2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(436, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "        S�lectionner le mat�riel que vous utilisez :"
        '
        'dgvPools
        '
        Me.dgvPools.AllowUserToAddRows = False
        Me.dgvPools.AllowUserToDeleteRows = False
        Me.dgvPools.AllowUserToResizeColumns = False
        Me.dgvPools.AllowUserToResizeRows = False
        Me.dgvPools.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPools.AutoGenerateColumns = False
        Me.dgvPools.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPools.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.dgvPools.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPools.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idPool, Me.libelle, Me.aidbanc})
        Me.dgvPools.DataSource = Me.m_bsrcPools
        Me.dgvPools.Location = New System.Drawing.Point(0, 27)
        Me.dgvPools.MultiSelect = False
        Me.dgvPools.Name = "dgvPools"
        Me.dgvPools.ReadOnly = True
        Me.dgvPools.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPools.Size = New System.Drawing.Size(436, 71)
        Me.dgvPools.TabIndex = 0
        '
        'm_bsrcPools
        '
        Me.m_bsrcPools.AllowNew = False
        Me.m_bsrcPools.DataSource = GetType(CRODIPWS.Pool)
        '
        'lblBaseDonnee
        '
        Me.lblBaseDonnee.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBaseDonnee.AutoSize = True
        Me.lblBaseDonnee.BackColor = System.Drawing.Color.Transparent
        Me.lblBaseDonnee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBaseDonnee.ForeColor = System.Drawing.Color.Silver
        Me.lblBaseDonnee.Location = New System.Drawing.Point(189, 656)
        Me.lblBaseDonnee.Name = "lblBaseDonnee"
        Me.lblBaseDonnee.Size = New System.Drawing.Size(118, 15)
        Me.lblBaseDonnee.TabIndex = 34
        Me.lblBaseDonnee.Text = "Base de donn�es"
        Me.lblBaseDonnee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMode
        '
        Me.lblMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMode.AutoSize = True
        Me.lblMode.BackColor = System.Drawing.Color.Transparent
        Me.lblMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMode.ForeColor = System.Drawing.Color.Silver
        Me.lblMode.Location = New System.Drawing.Point(428, 656)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(112, 15)
        Me.lblMode.TabIndex = 33
        Me.lblMode.Text = "Mode : Simplifi�"
        Me.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlLoginControls
        '
        Me.pnlLoginControls.BackColor = System.Drawing.Color.Transparent
        Me.pnlLoginControls.Controls.Add(Me.btn_login_seConnecter)
        Me.pnlLoginControls.Controls.Add(Me.btn_login_ajouterProfil)
        Me.pnlLoginControls.Controls.Add(Me.Label5)
        Me.pnlLoginControls.Controls.Add(Me.login_password)
        Me.pnlLoginControls.Controls.Add(Me.login_profil)
        Me.pnlLoginControls.Controls.Add(Me.Label4)
        Me.pnlLoginControls.Location = New System.Drawing.Point(459, 216)
        Me.pnlLoginControls.Name = "pnlLoginControls"
        Me.pnlLoginControls.Size = New System.Drawing.Size(436, 111)
        Me.pnlLoginControls.TabIndex = 32
        '
        'btn_login_seConnecter
        '
        Me.btn_login_seConnecter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_login_seConnecter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login_seConnecter.ForeColor = System.Drawing.Color.White
        Me.btn_login_seConnecter.Image = CType(resources.GetObject("btn_login_seConnecter.Image"), System.Drawing.Image)
        Me.btn_login_seConnecter.Location = New System.Drawing.Point(105, 77)
        Me.btn_login_seConnecter.Name = "btn_login_seConnecter"
        Me.btn_login_seConnecter.Size = New System.Drawing.Size(128, 24)
        Me.btn_login_seConnecter.TabIndex = 2
        Me.btn_login_seConnecter.Text = "       Se connecter"
        Me.btn_login_seConnecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_login_ajouterProfil
        '
        Me.btn_login_ajouterProfil.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_login_ajouterProfil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login_ajouterProfil.ForeColor = System.Drawing.Color.White
        Me.btn_login_ajouterProfil.Image = CType(resources.GetObject("btn_login_ajouterProfil.Image"), System.Drawing.Image)
        Me.btn_login_ajouterProfil.Location = New System.Drawing.Point(252, 77)
        Me.btn_login_ajouterProfil.Name = "btn_login_ajouterProfil"
        Me.btn_login_ajouterProfil.Size = New System.Drawing.Size(180, 24)
        Me.btn_login_ajouterProfil.TabIndex = 3
        Me.btn_login_ajouterProfil.Text = "      Ajouter un nouveau profil"
        Me.btn_login_ajouterProfil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(63, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Mot de passe :"
        '
        'login_password
        '
        Me.login_password.Location = New System.Drawing.Point(190, 41)
        Me.login_password.Name = "login_password"
        Me.login_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.login_password.Size = New System.Drawing.Size(240, 20)
        Me.login_password.TabIndex = 1
        '
        'login_profil
        '
        Me.login_profil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.login_profil.Location = New System.Drawing.Point(190, 14)
        Me.login_profil.Name = "login_profil"
        Me.login_profil.Size = New System.Drawing.Size(240, 21)
        Me.login_profil.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(126, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Profil :"
        '
        'Lbl_Version
        '
        Me.Lbl_Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Version.AutoSize = True
        Me.Lbl_Version.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Version.ForeColor = System.Drawing.Color.Silver
        Me.Lbl_Version.Location = New System.Drawing.Point(804, 656)
        Me.Lbl_Version.Name = "Lbl_Version"
        Me.Lbl_Version.Size = New System.Drawing.Size(101, 15)
        Me.Lbl_Version.TabIndex = 30
        Me.Lbl_Version.Text = "Version - Build"
        Me.Lbl_Version.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lbl_environnement_ws
        '
        Me.lbl_environnement_ws.BackColor = System.Drawing.Color.Transparent
        Me.lbl_environnement_ws.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_environnement_ws.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_environnement_ws.Location = New System.Drawing.Point(680, 8)
        Me.lbl_environnement_ws.Name = "lbl_environnement_ws"
        Me.lbl_environnement_ws.Size = New System.Drawing.Size(320, 16)
        Me.lbl_environnement_ws.TabIndex = 28
        Me.lbl_environnement_ws.Text = "Environnement webservice..............: D�veloppement"
        Me.lbl_environnement_ws.Visible = False
        '
        'GroupBox_test
        '
        Me.GroupBox_test.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_test.Controls.Add(Me.btnTestFacture)
        Me.GroupBox_test.Controls.Add(Me.btnExploitant)
        Me.GroupBox_test.Controls.Add(Me.btnLieuxControles)
        Me.GroupBox_test.Controls.Add(Me.btnTSTSignature)
        Me.GroupBox_test.Controls.Add(Me.btn_dlgAcquisition)
        Me.GroupBox_test.Controls.Add(Me.bntGetWSDiag)
        Me.GroupBox_test.Controls.Add(Me.btnTesttrtSemences)
        Me.GroupBox_test.Controls.Add(Me.Button4)
        Me.GroupBox_test.Controls.Add(Me.brnTestDiagRecap)
        Me.GroupBox_test.Controls.Add(Me.Button2)
        Me.GroupBox_test.Controls.Add(Me.Button1)
        Me.GroupBox_test.Controls.Add(Me.cbTestRIFin)
        Me.GroupBox_test.Controls.Add(Me.btnTestDiagContext)
        Me.GroupBox_test.Controls.Add(Me.btnTest)
        Me.GroupBox_test.Location = New System.Drawing.Point(12, 376)
        Me.GroupBox_test.Name = "GroupBox_test"
        Me.GroupBox_test.Size = New System.Drawing.Size(294, 261)
        Me.GroupBox_test.TabIndex = 27
        Me.GroupBox_test.TabStop = False
        Me.GroupBox_test.Text = "Tests"
        '
        'btnTestFacture
        '
        Me.btnTestFacture.BackColor = System.Drawing.SystemColors.Control
        Me.btnTestFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestFacture.Location = New System.Drawing.Point(159, 173)
        Me.btnTestFacture.Name = "btnTestFacture"
        Me.btnTestFacture.Size = New System.Drawing.Size(104, 23)
        Me.btnTestFacture.TabIndex = 40
        Me.btnTestFacture.Text = "Facture 2"
        Me.btnTestFacture.UseVisualStyleBackColor = False
        '
        'btnExploitant
        '
        Me.btnExploitant.Location = New System.Drawing.Point(159, 142)
        Me.btnExploitant.Name = "btnExploitant"
        Me.btnExploitant.Size = New System.Drawing.Size(101, 23)
        Me.btnExploitant.TabIndex = 39
        Me.btnExploitant.Text = "Exploitant"
        Me.btnExploitant.UseVisualStyleBackColor = True
        '
        'btnLieuxControles
        '
        Me.btnLieuxControles.Location = New System.Drawing.Point(159, 115)
        Me.btnLieuxControles.Name = "btnLieuxControles"
        Me.btnLieuxControles.Size = New System.Drawing.Size(101, 23)
        Me.btnLieuxControles.TabIndex = 38
        Me.btnLieuxControles.Text = "LieuxControles"
        Me.btnLieuxControles.UseVisualStyleBackColor = True
        '
        'btnTSTSignature
        '
        Me.btnTSTSignature.Location = New System.Drawing.Point(33, 173)
        Me.btnTSTSignature.Name = "btnTSTSignature"
        Me.btnTSTSignature.Size = New System.Drawing.Size(107, 23)
        Me.btnTSTSignature.TabIndex = 37
        Me.btnTSTSignature.Text = "Signature"
        Me.btnTSTSignature.UseVisualStyleBackColor = True
        '
        'btn_dlgAcquisition
        '
        Me.btn_dlgAcquisition.Location = New System.Drawing.Point(12, 143)
        Me.btn_dlgAcquisition.Name = "btn_dlgAcquisition"
        Me.btn_dlgAcquisition.Size = New System.Drawing.Size(128, 23)
        Me.btn_dlgAcquisition.TabIndex = 36
        Me.btn_dlgAcquisition.Text = "dlgAcquisition"
        Me.btn_dlgAcquisition.UseVisualStyleBackColor = True
        '
        'bntGetWSDiag
        '
        Me.bntGetWSDiag.Location = New System.Drawing.Point(14, 115)
        Me.bntGetWSDiag.Name = "bntGetWSDiag"
        Me.bntGetWSDiag.Size = New System.Drawing.Size(128, 23)
        Me.bntGetWSDiag.TabIndex = 35
        Me.bntGetWSDiag.Text = "ListeDiags"
        Me.bntGetWSDiag.UseVisualStyleBackColor = True
        '
        'btnTesttrtSemences
        '
        Me.btnTesttrtSemences.Location = New System.Drawing.Point(159, 204)
        Me.btnTesttrtSemences.Name = "btnTesttrtSemences"
        Me.btnTesttrtSemences.Size = New System.Drawing.Size(128, 23)
        Me.btnTesttrtSemences.TabIndex = 34
        Me.btnTesttrtSemences.Text = "TrtSemences"
        Me.btnTesttrtSemences.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(135, 77)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 23)
        Me.Button4.TabIndex = 33
        Me.Button4.Text = "DiagHelp12123(SansPMP)"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'brnTestDiagRecap
        '
        Me.brnTestDiagRecap.BackColor = System.Drawing.SystemColors.Control
        Me.brnTestDiagRecap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.brnTestDiagRecap.Location = New System.Drawing.Point(24, 77)
        Me.brnTestDiagRecap.Name = "brnTestDiagRecap"
        Me.brnTestDiagRecap.Size = New System.Drawing.Size(104, 23)
        Me.brnTestDiagRecap.TabIndex = 32
        Me.brnTestDiagRecap.Text = "Diag Recap"
        Me.brnTestDiagRecap.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(24, 209)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 23)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "AjoutPulve"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(134, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 23)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "CtrlMano2"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cbTestRIFin
        '
        Me.cbTestRIFin.BackColor = System.Drawing.SystemColors.Control
        Me.cbTestRIFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbTestRIFin.Location = New System.Drawing.Point(24, 48)
        Me.cbTestRIFin.Name = "cbTestRIFin"
        Me.cbTestRIFin.Size = New System.Drawing.Size(104, 23)
        Me.cbTestRIFin.TabIndex = 28
        Me.cbTestRIFin.Text = "RI (Fin)"
        Me.cbTestRIFin.UseVisualStyleBackColor = False
        '
        'btnTestDiagContext
        '
        Me.btnTestDiagContext.Location = New System.Drawing.Point(135, 18)
        Me.btnTestDiagContext.Name = "btnTestDiagContext"
        Me.btnTestDiagContext.Size = New System.Drawing.Size(128, 23)
        Me.btnTestDiagContext.TabIndex = 27
        Me.btnTestDiagContext.Text = "DiagContext"
        Me.btnTestDiagContext.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.BackColor = System.Drawing.SystemColors.Control
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTest.Location = New System.Drawing.Point(24, 19)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(104, 23)
        Me.btnTest.TabIndex = 26
        Me.btnTest.Text = "Diag"
        Me.btnTest.UseVisualStyleBackColor = False
        '
        'panel_splashSynchro
        '
        Me.panel_splashSynchro.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.panel_splashSynchro.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.panel_splashSynchro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_splashSynchro.CausesValidation = False
        Me.panel_splashSynchro.Controls.Add(Me.pctSynchro)
        Me.panel_splashSynchro.Controls.Add(Me.lblSynchro)
        Me.panel_splashSynchro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.panel_splashSynchro.Location = New System.Drawing.Point(402, 506)
        Me.panel_splashSynchro.Name = "panel_splashSynchro"
        Me.panel_splashSynchro.Size = New System.Drawing.Size(468, 102)
        Me.panel_splashSynchro.TabIndex = 25
        Me.panel_splashSynchro.Visible = False
        '
        'pctSynchro
        '
        Me.pctSynchro.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.pctSynchro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.pctSynchro.Image = CType(resources.GetObject("pctSynchro.Image"), System.Drawing.Image)
        Me.pctSynchro.Location = New System.Drawing.Point(120, 70)
        Me.pctSynchro.Name = "pctSynchro"
        Me.pctSynchro.Size = New System.Drawing.Size(220, 19)
        Me.pctSynchro.TabIndex = 4
        Me.pctSynchro.TabStop = False
        '
        'lblSynchro
        '
        Me.lblSynchro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSynchro.ForeColor = System.Drawing.Color.White
        Me.lblSynchro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSynchro.Location = New System.Drawing.Point(7, -1)
        Me.lblSynchro.Name = "lblSynchro"
        Me.lblSynchro.Size = New System.Drawing.Size(448, 68)
        Me.lblSynchro.TabIndex = 3
        Me.lblSynchro.Text = "Veuillez patienter pendant que votre logiciel se synchronise avec le Crodip."
        Me.lblSynchro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(312, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Profil existant"
        '
        'picto_profil
        '
        Me.picto_profil.BackgroundImage = CType(resources.GetObject("picto_profil.BackgroundImage"), System.Drawing.Image)
        Me.picto_profil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picto_profil.Location = New System.Drawing.Point(312, 216)
        Me.picto_profil.Name = "picto_profil"
        Me.picto_profil.Size = New System.Drawing.Size(102, 146)
        Me.picto_profil.TabIndex = 7
        Me.picto_profil.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label3.Location = New System.Drawing.Point(456, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(512, 32)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "        Pour acc�der au logiciel, veuillez s�lectionner votre profil ci-dessous e" &
    "t indiquer votre mot de passe :"
        '
        'lbl_environnement_debugType
        '
        Me.lbl_environnement_debugType.BackColor = System.Drawing.Color.Transparent
        Me.lbl_environnement_debugType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_environnement_debugType.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_environnement_debugType.Location = New System.Drawing.Point(680, 24)
        Me.lbl_environnement_debugType.Name = "lbl_environnement_debugType"
        Me.lbl_environnement_debugType.Size = New System.Drawing.Size(320, 16)
        Me.lbl_environnement_debugType.TabIndex = 28
        Me.lbl_environnement_debugType.Text = "Environnement webservice..............: D�veloppement"
        Me.lbl_environnement_debugType.Visible = False
        '
        'lbl_environnement_debugLvl
        '
        Me.lbl_environnement_debugLvl.BackColor = System.Drawing.Color.Transparent
        Me.lbl_environnement_debugLvl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_environnement_debugLvl.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_environnement_debugLvl.Location = New System.Drawing.Point(680, 40)
        Me.lbl_environnement_debugLvl.Name = "lbl_environnement_debugLvl"
        Me.lbl_environnement_debugLvl.Size = New System.Drawing.Size(320, 16)
        Me.lbl_environnement_debugLvl.TabIndex = 28
        Me.lbl_environnement_debugLvl.Text = "Environnement webservice..............: D�veloppement"
        Me.lbl_environnement_debugLvl.Visible = False
        '
        'lbl_WS
        '
        Me.lbl_WS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_WS.AutoSize = True
        Me.lbl_WS.BackColor = System.Drawing.Color.Transparent
        Me.lbl_WS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_WS.ForeColor = System.Drawing.Color.Silver
        Me.lbl_WS.Location = New System.Drawing.Point(566, 656)
        Me.lbl_WS.Name = "lbl_WS"
        Me.lbl_WS.Size = New System.Drawing.Size(183, 15)
        Me.lbl_WS.TabIndex = 31
        Me.lbl_WS.Text = "http://serveur_crodip/Server"
        Me.lbl_WS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'idPool
        '
        Me.idPool.DataPropertyName = "idPool"
        Me.idPool.HeaderText = "Num�ro"
        Me.idPool.Name = "idPool"
        Me.idPool.ReadOnly = True
        '
        'libelle
        '
        Me.libelle.DataPropertyName = "Libelle"
        Me.libelle.HeaderText = "Libelle"
        Me.libelle.Name = "libelle"
        Me.libelle.ReadOnly = True
        '
        'aidbanc
        '
        Me.aidbanc.DataPropertyName = "aidbanc"
        Me.aidbanc.HeaderText = "Banc"
        Me.aidbanc.Name = "aidbanc"
        Me.aidbanc.ReadOnly = True
        '
        'login
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 680)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlPrincipal.PerformLayout()
        Me.pnlPools.ResumeLayout(False)
        CType(Me.dgvPools, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcPools, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLoginControls.ResumeLayout(False)
        Me.pnlLoginControls.PerformLayout()
        Me.GroupBox_test.ResumeLayout(False)
        Me.panel_splashSynchro.ResumeLayout(False)
        CType(Me.pctSynchro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picto_profil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region






#Region "Fonction de login"
    Private Sub doLogin()

        pnlLoginControls.Enabled = False
        ' On r�cup�re le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent
        Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_ENCOURS, True)
        Dim bAgentExistant As Boolean = False
        Dim idAgent As Integer
        Try
            ' On r�cup�re l'agent s�l�ctionn�

            _LocalAgent = AgentManager.getAgentByNumeroNational(login_profil.SelectedItem.Id)
            idAgent = _LocalAgent.id
            If _LocalAgent.numeroNational.ToString <> "" Then
                If CSEnvironnement.checkWebService() = True Then
                    'If CSEnvironnement.checkWebService() = True And Not GlobalsCRODIP.GLOB_ENV_DEBUG Then
                    ' On commence par redescendre le pass de l'agent courant
                    Dim oAgentSrv As New Agent
                    Try
                        oAgentSrv = AgentManager.WSgetByNumeroNational(_LocalAgent.numeroNational, True)
                        If oAgentSrv.id > 0 And oAgentSrv.isActif And Not oAgentSrv.isSupprime Then
                            _LocalAgent.duppliqueInfosAgent(oAgentSrv, False)
                            'If CSDate.FromCrodipString(_LocalAgent.dateDerniereSynchro).Year = 1970 Then
                            '    _LocalAgent.dateDerniereSynchro = oAgentSrv.dateDerniereSynchro
                            'End If
                            AgentManager.save(_LocalAgent, True)
                            bAgentExistant = True
                        Else
                            bAgentExistant = False
                            If oAgentSrv.id > 0 Then
                                If oAgentSrv.isSupprime Then
                                    'Suppression de l'agent en base
                                    AgentManager.save(oAgentSrv)
                                End If
                                If Not oAgentSrv.isActif Then
                                    Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a �t� d�sactiv� par le Crodip.", False)
                                    MsgBox(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a �t� d�sactiv� , contactez le Crodip")
                                    'On recharge la Liste des profils 
                                    FillCbxAgent()
                                    login_password.Clear()
                                    pnlLoginControls.Enabled = True
                                End If
                            Else
                                Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a �t� d�sactiv� par le Crodip.", False)
                                MsgBox(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Le service de synchronisation n'est pas accessible, d�connectez-vous d'internet pour continuer d'utiliser le logiciel")
                                'On recharge la Liste des profils 
                                FillCbxAgent()
                                login_password.Clear()
                                pnlLoginControls.Enabled = True
                            End If
                            Exit Sub
                        End If
                    Catch ex As Exception
                        CSDebug.dispError("doLogin():: GetAgent mot de passe : " & ex.Message.ToString)
                        Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Le service de synchronisation n'est pas accessible", False)
                        MsgBox(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Le service de synchronisation n'est pas accessible, d�connectez-vous d'internet pour continuer d'utiliser le logiciel")

                        Application.Exit()
                    End Try
                Else
                    'Pas de WS => on consid�re que l'agent est OK
                    bAgentExistant = True
                End If
                If bAgentExistant Then
                    If CSCrypt.encode(login_password.Text, "sha256") = _LocalAgent.motDePasse Or GlobalsCRODIP.GLOB_ENV_DEBUG Then
                        ' Mot de passe correct => On le met en "session"
                        agentCourant = _LocalAgent
                        ' On met � jour le num�ro de version du logiciel agent
                        If _LocalAgent.versionLogiciel <> GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD Then
                            _LocalAgent.versionLogiciel = GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD
                            CSDebug.dispInfo("Login.doLogin():: Save Agent Version : " & _LocalAgent.dateModificationAgent)
                            AgentManager.save(_LocalAgent)
                        End If

                        Dim lstPool As New List(Of Pool)
                        Dim oPcRef As AgentPc
                        If My.Settings.aqw = "zsx" Then
                            oPcRef = AgentPcManager.GetListe(_LocalAgent.idStructure)(0)
                            lstPool = PoolManager.GetListe(_LocalAgent.idStructure)
                            _LocalAgent.oPCcourant = oPcRef
                            If lstPool.Count() = 1 Then   'C'est le cas normal
                                _LocalAgent.oPool = lstPool(0)
                                SynchroEtSuite(_LocalAgent)
                            End If

                            If lstPool.Count > 1 Then
                                m_bsrcPools.Clear()
                                lstPool.ForEach(Sub(p)
                                                    m_bsrcPools.Add(p)
                                                End Sub)
                                'il y a plus d'un pool, on demande � l'inspecteur de choisir
                                btn_login_seConnecter.Enabled = False
                                btn_login_seConnecter2.Enabled = True
                                pnlPools.Visible = True
                                _LocalAgent.oPool = Nothing
                            End If
                        Else

                            oPcRef = AgentPcManager.GetAgentPCFromRegistry()
                            If oPcRef IsNot Nothing Then
                                'Cas particulier : 1ere connexion , il y a un PC mais pas de poolpc
                                Dim olstPoolPc As List(Of PoolPc) = PoolPcManager.getListeByStructure(_LocalAgent.uidstructure)
                                If olstPoolPc.Count = 0 Then
                                    'On r�cup�re les poolPc depuis les WS
                                    olstPoolPc = PoolPcManager.WSGetListByPC(_LocalAgent, oPcRef)
                                    For Each oPoolPc As PoolPc In olstPoolPc
                                        'On r�cup�re les Pool depuis les PoolPc si n�cessaire
                                        Dim oPool As Pool
                                        oPool = PoolManager.getPoolByuid(oPoolPc.uidpool)
                                        If oPool Is Nothing Then
                                            oPool = PoolManager.WSgetById(oPoolPc.uid, oPoolPc.aid)
                                            PoolManager.Save(oPool)
                                        End If
                                        PoolPcManager.Save(oPoolPc)
                                    Next
                                End If

                                _LocalAgent.oPCcourant = oPcRef 'Le PC Encours est celui en base de registre
                                'MAJ de la date de derniere synchro si elle est vide (1ere connexion)
                                If oPcRef.dateDerniereSynchro = DateTime.MinValue Then
                                    oPcRef.dateDerniereSynchro = _LocalAgent.dateDerniereSynchro
                                End If

                                'R�cup�ration de la liste des pools de l'agent relatif � ce pc
                                If CSEnvironnement.checkWebService Then
                                    Dim olstPC As List(Of PoolPc)
                                    lstPool = New List(Of Pool)()
                                    olstPC = PoolPcManager.WSGetListByPC(_LocalAgent, oPcRef)
                                    For Each oPoolPc As PoolPc In olstPC
                                        Dim oPool As Pool
                                        oPool = PoolManager.WSgetById(oPoolPc.uidpool, "")
                                        If oPool IsNot Nothing Then
                                            If oPool.CheckPool(_LocalAgent) Then
                                                lstPool.Add(oPool)
                                            End If
                                        End If
                                    Next
                                Else
                                    lstPool = _LocalAgent.getPoolList(oPcRef)
                                End If


                                If lstPool.Count() = 0 Then
                                    _LocalAgent.oPool = Nothing
                                    Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Pool non trouv�", False)
                                    MsgBox(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Pool non trouv�, contactez le crodip")
                                End If

                                If lstPool.Count() = 1 Then   'C'est le cas normal
                                    _LocalAgent.oPool = lstPool(0)
                                    SynchroEtSuite(_LocalAgent)
                                End If

                                If lstPool.Count > 1 Then
                                    m_bsrcPools.Clear()
                                    lstPool.ForEach(Sub(p)
                                                        m_bsrcPools.Add(p)
                                                    End Sub)
                                    'il y a plus d'un pool, on demande � l'inspecteur de choisir
                                    btn_login_seConnecter.Enabled = False
                                    btn_login_seConnecter2.Enabled = True
                                    pnlPools.Visible = True
                                    _LocalAgent.oPool = Nothing
                                End If
                            Else
                                Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : PC non reconnu ", False)
                            End If
                        End If
                    Else
                        ' On met � jour la barre de status
                        Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Mauvais mot de passe", False)
                        MsgBox(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Mauvais mot de passe")
                        login_password.Text = ""
                    End If 'Mot de passe
                End If 'bAgentExistant
            End If 'bAgentOK
        Catch ex As Exception
            ' On met � jour la barre de status
            Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : " & ex.Message, False)
            CSDebug.dispError("login::doLogin : " & ex.Message)
        End Try
        'On r�active la fen�tre , si la proc�dure de Cnx a fonctionner, cette fen�tre est cach�e
        pnlLoginControls.Enabled = True

    End Sub
#End Region
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CSDebug.dispInfo("login.Load: Start")
        ' Debug
        GroupBox_test.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG
        lbl_environnement_ws.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG
        lbl_environnement_debugType.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG
        lbl_environnement_debugLvl.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG
        lbl_environnement_debugType.Text = "Type de sortie debug..................: " & GlobalsCRODIP.GLOB_ENV_DEBUGTYPE
        lbl_environnement_debugLvl.Text = "Niveau de sortie debug................: " & GlobalsCRODIP.GLOB_ENV_DEBUGLVL
        Try
            lbl_WS.Text = WSCrodip.getWS().Url

        Catch ex As Exception

        End Try
        lblMode.Visible = False
        pnlPrincipal.BackgroundImage = Crodip_agent.Resources.Login_bgcrodipIndigo
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
            lblMode.Visible = True
            pnlPrincipal.BackgroundImage = Crodip_agent.Resources.login_bgcrodip
        End If
        If GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            lblMode.Visible = True
            lblMode.Text = "Mode : Formation"
            pnlPrincipal.BackgroundImage = Crodip_agent.Resources.login_bgVide
            lbl_WS.Visible = False
        End If


        If Not GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            CSDebug.dispInfo("Login.Load: CheckWS()")
            If Not CSEnvironnement.checkWebService() Then
                lbl_WS.Text = WSCrodip.getWS().Url
                lbl_WS.ForeColor = Drawing.Color.Red
            End If
            Lbl_Version.Text = GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD
            If Not My.Settings.AutoSync Then
                Lbl_Version.Text = Lbl_Version.Text & " SYNC OFF"
            Else
                Lbl_Version.Text = Lbl_Version.Text & " SYNC ON"
            End If
        End If
        If GlobalsCRODIP.GLOB_ENV_DEBUG Then
            Dim oCSDB As New CSDb(False)
            lblBaseDonnee.Text = oCSDB.getConnection().ConnectionString
        Else
            lblBaseDonnee.Text = ""
        End If

        'BUG sur le DataGridView (suppresson des derni�res col)
        For i As Integer = dgvPools.Columns.GetColumnCount(DataGridViewElementStates.Displayed) - 1 To 3 Step -1
            dgvPools.Columns.RemoveAt(i)
        Next

        InitRegistry()

        ' Chargement de la statusbar
        Statusbardisplay("Chargement de la liste de profils...", True)


        FillCbxAgent()
        'Statusbardisplay("Chargement r�ussi de " & nbProfils & " profil(s)", False)
        Statusbarclear()

    End Sub
    ''' <summary>
    ''' initialisation de la registry si n�cessaire
    ''' </summary>
    Private Sub InitRegistry()
        Dim strNumPc As String = ""
        If AgentPcManager.IsRegistryVide Then
            'Pas de AgentPC de reference sur le PC = > PC � VIDE !!!!
            While (strNumPc.Length <> 5 Or Not IsNumeric(strNumPc))
                strNumPc = InputBox("Veuillez entrer le num�ro CRODIP du PC (5 chiffres) ", "Saisie du num�ro CRODIP du PC")
                If strNumPc.Length = 0 Then
                    'On sort si on click sur Annul
                    login_password.Text = ""
                    pnlLoginControls.Enabled = True
                    Exit Sub
                Else
                    'R�cup�ration du PCRef sur le Serveur
                    Dim oPcRef As AgentPc = AgentPcManager.WSgetById(-1, strNumPc)
                    If oPcRef IsNot Nothing Then
                        If Not oPcRef.SaveRegistry() Then
                            Statusbar.display("ERREUR REGISTRY")
                            strNumPc = ""
                        End If
                        Dim oPCReturn As AgentPc = Nothing
                        AgentPcManager.WSSend(oPcRef, oPCReturn)
                        AgentPcManager.Save(oPcRef, True) 'on consid�re que c'est une synhcro
                    Else
                        Statusbar.display("PC non r�f�renc�")
                        strNumPc = ""
                    End If

                End If
            End While
        End If
    End Sub
    Private Sub Statusbardisplay(pMsg As String, pisLoader As Boolean)
        If Statusbar IsNot Nothing Then
            Statusbar.display(pMsg, pisLoader)
        End If
    End Sub
    Private Sub Statusbardisplay(pMsg As String)
        If Statusbar IsNot Nothing Then
            Statusbar.display(pMsg)
        End If
    End Sub
    Private Sub Statusbarclear()
        If Statusbar IsNot Nothing Then
            Statusbar.clear()
        End If
    End Sub
    Private Sub FillCbxAgent()
        Dim oAgentList As AgentList
        Dim olstStruct As List(Of [Structure])
        olstStruct = StructureManager.getList()
        For Each oStruct As [Structure] In olstStruct
            oAgentList = AgentManager.getAgentList(oStruct.id)
            login_profil.Items.Clear()
            For Each curAgent As Agent In oAgentList.items
                If Not curAgent.isSupprime Then
                    ' On ajoute le profil � la liste d�roulante
                    Dim libelleAccount As String = curAgent.nom & " " & curAgent.prenom
                    libelleAccount = libelleAccount & "(" & curAgent.NomStructure & ")"
                    Dim objComboItem As New objComboItem(curAgent.numeroNational, libelleAccount)
                    login_profil.Items.Add(objComboItem)
                End If
            Next
        Next

    End Sub

    ' Connexion a son profil
    Private Sub login_password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles login_password.KeyPress
        If Asc(e.KeyChar) = 13 Then
            doLogin()
        End If
    End Sub
    Private Sub btn_login_seConnecter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login_seConnecter.Click
        doLogin()
    End Sub

    ' Ajout d'un nouveau profil
    Private Sub btn_login_ajouterProfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login_ajouterProfil.Click
        Dim formAjouter_profil As New ajouter_profil
        formAjouter_profil.MdiParent = Me.MdiParent
        formAjouter_profil.Show()
        Me.Close()
    End Sub





    Public Function formatNumbers(ByVal number As Double) As String
        Dim returnString As String
        returnString = CType(Math.Round(CType(number, Double), 2), String)

        Dim RegexObj As Regex = New Regex("^[0-9]+[\,|\.][0-9]{1}$")
        If RegexObj.IsMatch(returnString) Then
            returnString = returnString & "0"
        End If

        Return returnString
    End Function

#Region " Tests "


    Private Sub btntest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiag As Diagnostic
        oPulve = PulverisateurManager.getPulverisateurById("2-81-22")
        oPulve.type = "Cultures basses"
        'oPulve.categorie = "Traitement des semences"
        'oPulve.buseFonctionnement = "CUILLERE"
        oPulve.isPompesDoseuses = True
        oPulve.nbPompesDoseuses = 2
        'oPulve.buseNbniveaux = 1
        'oPulve.nombreBuses = 2
        agentCourant = AgentManager.getAgentByNumeroNational("MCII")
        If oPulve IsNot Nothing Then
            oExploit = ExploitationManager.GetExploitationByPulverisateurId(oPulve.id)
            oDiag = New Diagnostic(agentCourant, oPulve, oExploit)
            Dim oFrm As New FrmDiagnostique()
            oFrm.SetContexte(oDiag, GlobalsCRODIP.DiagMode.CTRL_COMPLET, oPulve, oExploit)

            Dim oDiag12123 As New DiagnosticHelp12123()
            oFrm.ShowDialog()

        End If
    End Sub

    Private Sub btnTestDiagHelp12123_Click(sender As Object, e As EventArgs) Handles btnTestDiagContext.Click

        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation = Nothing
        Dim oDiag As Diagnostic = Nothing
        oPulve = PulverisateurManager.getPulverisateurById("2-81-22")
        oPulve.type = "Cultures basses"
        'oPulve.categorie = "Traitement des semences"
        'oPulve.buseFonctionnement = "CUILLERE"
        oPulve.isPompesDoseuses = True
        oPulve.nbPompesDoseuses = 2
        'oPulve.buseNbniveaux = 1
        'oPulve.nombreBuses = 2
        agentCourant = AgentManager.getAgentByNumeroNational("MCII")
        If oPulve IsNot Nothing Then
            oExploit = ExploitationManager.GetExploitationByPulverisateurId(oPulve.id)
            oDiag = New Diagnostic(agentCourant, oPulve, oExploit)
        End If

        Dim oFrm As New diagnostic_contexte(GlobalsCRODIP.DiagMode.CTRL_COMPLET, oDiag, oPulve, oExploit, False)
        oFrm.Show()


    End Sub

    Private Sub cbTestRIFin_Click(sender As Object, e As EventArgs) Handles cbTestRIFin.Click
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem
        Dim oAgent As Agent

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()
        oExploit = ExploitationManager.getExploitationById("2-81-32")
        '        oPulve = PulverisateurManager.getPulverisateurById("2-1-51") 'Culture mara�ch�res paliss�es
        'oPulve = PulverisateurManager.getPulverisateurById("2-81-63") 'Pulv�risateurs combin�s
        '        oPulve = PulverisateurManager.getPulverisateurById("2-81-50") 'Cultures basses
        oPulve = PulverisateurManager.getPulverisateurById("2-1083-7") 'Vigne
        oAgent = AgentManager.getAgentById("1110")
        oDiag = New Diagnostic(oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Rep�sentant"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'D�fauts sur le Pulv�
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libell� est sur plusieurs lignes et tout doit apparaoitre m�me ces derni�rs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        oEtat.genereEtat()
        oEtat.Open()

    End Sub




#End Region


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim oAgent As Agent

        oAgent = AgentManager.getAgentById("1110")

        Dim ofrm As New frmControleManometresNew(oAgent)
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim oAgent As Agent

        oAgent = AgentManager.getAgentById("1110")

        Dim oPulve As New Pulverisateur()
        oPulve.modeUtilisation = "Co-Propri�t�"
        Dim oExploit As New Exploitation()
        Dim ofrm As New ajout_pulve2()
        ofrm.setContexte(ajout_pulve2.MODE.AJOUT, oAgent, oPulve, oExploit, Nothing)
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)

    End Sub

    Private Sub btnTestFacturation_Click(sender As Object, e As EventArgs)

        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiag As Diagnostic
        Dim oAgent As Agent

        oPulve = PulverisateurManager.getPulverisateurById("2-81-50")
        oPulve.modeUtilisation = "Co-Propri�t�"
        oPulve.nombreExploitants = 3
        oAgent = AgentManager.getAgentByNumeroNational("MCII")
        If oPulve IsNot Nothing Then
            oExploit = ExploitationManager.GetExploitationByPulverisateurId(oPulve.id)
            oDiag = New Diagnostic(oAgent, oPulve, oExploit)

            Dim oFrm As New diagnostic_ContratCommercial()
            oFrm.setContexte(oDiag, oExploit, oAgent)

            oFrm.ShowDialog()

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim oFRM As diagnostic_dlghelp12123new
        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.calcule()


        oFRM = New diagnostic_dlghelp12123new()
        oFRM.setContexte(oDiag12123, False)
        oFRM.ShowDialog()

    End Sub

    Private Sub brnTestDiagRecap_Click(sender As Object, e As EventArgs) Handles brnTestDiagRecap.Click
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem
        Dim oAgent As Agent

        oPulve = New Pulverisateur()
        oExploit = New Exploitation()
        oExploit = ExploitationManager.getExploitationById("2-81-32")
        '        oPulve = PulverisateurManager.getPulverisateurById("2-1-51") 'Culture mara�ch�res paliss�es
        'oPulve = PulverisateurManager.getPulverisateurById("2-81-63") 'Pulv�risateurs combin�s
        '        oPulve = PulverisateurManager.getPulverisateurById("2-81-50") 'Cultures basses
        oPulve = PulverisateurManager.getPulverisateurById("2-1083-7") 'Vigne
        oAgent = AgentManager.getAgentById("1110")
        oAgent.isSignElecActive = True
        oDiag = New Diagnostic(oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Rep�sentant"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'D�fauts sur le Pulv�
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libell� est sur plusieurs lignes et tout doit apparaoitre m�me ces derni�rs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "257", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "258", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "259", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "260", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "261", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "262", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "263", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "264", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        Dim ofrm As frmdiagnostic_recap
        ofrm = New frmdiagnostic_recap(GlobalsCRODIP.DiagMode.CTRL_COMPLET, oDiag, oPulve, oExploit, oAgent, Nothing)
        ofrm.setbTest(True)
        ofrm.Show()


    End Sub

    Private Sub btnTesttrtSemences_Click(sender As Object, e As EventArgs) Handles btnTesttrtSemences.Click
        Dim oFRM As diagnostic_dlghelp12123newTrtSem
        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.fonctionnementBuses = "INJECTEURS"
        Dim oP1 As DiagnosticHelp12123PompeTrtSem = oDiag12123.AjoutePompeTrtSem()
        Dim oMesure As DiagnosticHelp12123MesuresTrtSem
        oMesure = oP1.lstMesures(0)
        oMesure = oP1.lstMesures(1)
        'oMesure = oP1.lstMesures(2)
        'Dim oP2 As DiagnosticHelp12123PompeTrtSem = oDiag12123.AjoutePompeTrtSem()
        'oDiag12123.calcule()


        oFRM = New diagnostic_dlghelp12123newTrtSem
        oFRM.setContexte(oDiag12123, False)
        oFRM.ShowDialog()

    End Sub

    Private Sub bntGetWSDiag_Click(sender As Object, e As EventArgs) Handles bntGetWSDiag.Click
        Dim oDiag As New Diagnostic()
        Dim oAgent As Agent = AgentManager.getAgentById("1110")
        Dim oPulve As New Pulverisateur()
        Dim oExploit As New Exploitation()
        oExploit = ExploitationManager.getExploitationById("2-81-17") 'QUEZADA NICOLE
        '        oPulve = PulverisateurManager.getPulverisateurById("2-1-51") 'Culture mara�ch�res paliss�es
        'oPulve = PulverisateurManager.getPulverisateurById("2-81-63") 'Pulv�risateurs combin�s
        '        oPulve = PulverisateurManager.getPulverisateurById("2-81-50") 'Cultures basses
        oPulve = PulverisateurManager.getPulverisateurById("2-81-25") '

        Dim ofrm As New liste_diagnosticPulve2()
        ofrm.setcontexte(GlobalsCRODIP.DiagMode.CTRL_VISU, oPulve, oExploit, oAgent)
        ofrm.Show()

    End Sub

    Private Sub btn_dlgAcquisition_Click(sender As Object, e As EventArgs) Handles btn_dlgAcquisition.Click
        Dim odlg As Form = New dlgAquisition()
        odlg.Show()
    End Sub

    Private Sub btnTSTSignature_Click(sender As Object, e As EventArgs) Handles btnTSTSignature.Click
        Dim oFrm As frmSignClient
        Dim oDiag As New Diagnostic()
        Dim oAgent As Agent = AgentManager.getAgentById("1110")
        Dim oPulve As New Pulverisateur()
        Dim oExploit As New Exploitation()
        oExploit = ExploitationManager.getExploitationById("2-81-17") 'QUEZADA NICOLE
        '        oPulve = PulverisateurManager.getPulverisateurById("2-1-51") 'Culture mara�ch�res paliss�es
        'oPulve = PulverisateurManager.getPulverisateurById("2-81-63") 'Pulv�risateurs combin�s
        '        oPulve = PulverisateurManager.getPulverisateurById("2-81-50") 'Cultures basses
        oPulve = PulverisateurManager.getPulverisateurById("2-1083-7") 'Vigne
        oDiag = New Diagnostic(oAgent, oPulve, oExploit)
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateDebut = Now()
        oDiag.CalculDateProchainControle()
        My.Settings.ModeSignature = "wacom"

        oFrm = frmSignClient.getfrmSignature(oDiag, SignMode.RIAGENT, oAgent)
        oFrm.ShowDialog()
        oFrm = frmSignClient.getfrmSignature(oDiag, SignMode.RICLIENT, oAgent)
        oFrm.ShowDialog()
        If oFrm.DialogResult = DialogResult.OK Then
            Dim oEtat As EtatRapportInspection
            oEtat = New EtatRapportInspection(oDiag)
            oEtat.genereEtat()
            oEtat.Open()
        End If


    End Sub

    Private Sub btnLieuxControles_Click(sender As Object, e As EventArgs) Handles btnLieuxControles.Click
        Dim dlg As New frmGestLieuxControle()
        GlobalsCRODIP.GLOB_XML_CONFIG = New CSXml("config\config.xml")
        dlg.ShowDialog(Me)
    End Sub

    Private Sub btnExploitant_Click(sender As Object, e As EventArgs) Handles btnExploitant.Click
        Dim dlg As New fiche_exploitant()
        agentCourant = AgentManager.getAgentById("1110")
        dlg.setContexte(False, New Exploitation(), agentCourant, Nothing)
        dlg.ShowDialog(Me)
    End Sub

    Private Sub btnTestFacture_Click(sender As Object, e As EventArgs) Handles btnTestFacture.Click
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oAgent As Agent

        oAgent = AgentManager.getAgentById("1110")
        oAgent.isSignElecActive = True

        oExploit = ExploitationManager.getExploitationById("2-1110-3")
        oPulve = PulverisateurManager.getPulverisateurById("2-1110-3")
        oPulve.modeUtilisation = Pulverisateur.CO_PRORIETE
        PulverisateurManager.save(oPulve, oExploit, oAgent)
        oDiag = New Diagnostic(oAgent, oPulve, oExploit)
        oDiag.oContratCommercial.Lignes.Add(New FactureItem("TEST", "TEST", 15, 2, 0.2, ""))
        DiagnosticManager.save(oDiag)

        Dim ofrm As frmdiagnostic_facturationCoProp
        ofrm = New frmdiagnostic_facturationCoProp()
        ofrm.setContexte(oDiag, oAgent)
        ofrm.Show()

    End Sub

    Private Sub btnConnect2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub SynchroEtSuite(pAgent As Agent)
        Debug.Assert(pAgent IsNot Nothing, "Agent doit �tre initialis�")
        Debug.Assert(pAgent.oPool IsNot Nothing, "Pool doit �tre initialis�")
        Dim bContinue As Boolean = True

        ''V�rification du Pool s'il contient bien l'agent et le Pc
        'bContinue = pAgent.oPool.CheckPool(pAgent)
        'If Not bContinue Then
        '    'Le pool Selectionn� n'est plus valide, comme on ne le recevra plus par synchro
        '    'on marque comme is-supprim�
        '    pAgent.oPool.isSupprime = True
        '    PoolManager.Save(pAgent.oPool)
        '    pAgent.oPool = Nothing
        'End If

        If bContinue Then
            'V�rification du PC (Registre)
            Dim oPC As AgentPc
            oPC = pAgent.oPCcourant
            If My.Settings.aqw <> "zsx" Then
                bContinue = oPC.checkRegistry()
                If Not bContinue Then
                    CSDebug.dispError("Login.SynchroEtSuite Err : PC incorrect [" & pAgent.oPCcourant.uid & "]")
                End If
            Else
                bContinue = True
            End If
        End If
        If Not bContinue Then
            Application.Exit()
        Else
            'Synchronisation 
            If GlobalsCRODIP.GLOB_ENV_AUTOSYNC = True And Not pAgent.isGestionnaire Then
                If CSEnvironnement.checkWebService() = True Then

                    lblSynchro.Visible = True
                    pctSynchro.Visible = True
                    panel_splashSynchro.Visible = True
                    panel_splashSynchro.Refresh()
                    Threading.Thread.Sleep(500) ' Pause de 500ms

                    ' On v�rifie les mises � jour
                    Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_SYNCHRO_ENCOURS, True)
                    Me.Cursor = Cursors.WaitCursor
                    Dim oSynchro As New Synchronisation(pAgent)
                    oSynchro.ajouteObservateur(TryCast(Me.MdiParent, parentContener))
                    '###### SYNCHRO ######
                    oSynchro.Synchro(True, True)
                    oSynchro.Notice("")
                    Me.Cursor = Cursors.Default
                End If
            End If
            agentCourant = pAgent
            lblSynchro.Visible = False
            pctSynchro.Visible = False
            panel_splashSynchro.Visible = False
            ' On met � jour la barre de status
            Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_OK, False)
            CSDebug.dispInfo("Connexion r�ussie " & pAgent.nom)
            ' On met a jour la date de derni�re connexion
            pAgent.dateDerniereConnexion = CSDate.ToCRODIPString(Date.Now)
            AgentManager.save(pAgent)
            ' On affiche le formulaire d'accueil de l'application
            Dim formAccueil As New accueil
            globFormAccueil = formAccueil
            formAccueil.MdiParent = Me.MdiParent
            formAccueil.Init(pAgent) '' initialisation de la fen�tre avant l'affichage
            TryCast(MdiParent, parentContener).DisplayForm(formAccueil)
            Me.Hide()
        End If

    End Sub

    Private Sub dgvPools_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPools.CellDoubleClick
        SelectPool()
    End Sub

    Private Sub SelectPool()
        Dim oPool As Pool
        dgvPools.Enabled = False
        oPool = m_bsrcPools.Current
        _LocalAgent.oPool = oPool
        AgentManager.save(_LocalAgent)
        If Not _LocalAgent.checkPC() Then
            CSDebug.dispFatal("Le PC n'est pas reconnu")
            MsgBox("Connexion impossible, mat�riel non reconnu", MsgBoxStyle.Critical, "Logiciel CrodipAgent")
            Application.Exit()
        Else
            'L'agent � un Pool et est reconnu
            SynchroEtSuite(_LocalAgent)
        End If
    End Sub

    Private Sub lbl_WS_Click(sender As Object, e As EventArgs) Handles lbl_WS.Click
        If CSEnvironnement.checkWebService() Then
            GlobalsCRODIP.GLOB_NETWORKAVAILABLE = True
            lbl_WS.ForeColor = Drawing.Color.White
        Else
            GlobalsCRODIP.GLOB_NETWORKAVAILABLE = False
            lbl_WS.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Private Sub btn_login_seConnecter2_Click(sender As Object, e As EventArgs) Handles btn_login_seConnecter2.Click
        SelectPool()
    End Sub
End Class
