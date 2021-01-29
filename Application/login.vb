Imports System.IO
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
'Imports System.Drawing
'Imports System.Drawing.Imaging
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Collections.Generic


Public Class login
    Inherits frmCRODIP

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        panel_splashSynchro.Visible = False

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
    Friend WithEvents title_alertes As System.Windows.Forms.Label
    Public WithEvents panel_splashSynchro As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_environnement_ws As System.Windows.Forms.Label
    Friend WithEvents lbl_environnement_debugType As System.Windows.Forms.Label
    Friend WithEvents lbl_environnement_debugLvl As System.Windows.Forms.Label
    'Friend WithEvents cr_facture As CrystalDecisions.Windows.Forms.CrystalReportViewer
    '   Friend WithEvents cr_debitBuses As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Lbl_Version As System.Windows.Forms.Label
    Friend WithEvents GroupBox_test As System.Windows.Forms.GroupBox
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnTestDiagHelp12123 As System.Windows.Forms.Button
    Friend WithEvents pnlLoginControls As System.Windows.Forms.Panel
    Friend WithEvents cbTestRIFin As Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnTestFacturation As System.Windows.Forms.Button
    Friend WithEvents brnTestDiagRecap As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnTesttrtSemences As System.Windows.Forms.Button
    Friend WithEvents bntGetWSDiag As System.Windows.Forms.Button
    Friend WithEvents btn_dlgAcquisition As Button
    Friend WithEvents lblMode As Label
    Friend WithEvents btnTSTSignature As Button
    Friend WithEvents lblBaseDonnee As Label
    Friend WithEvents lbl_WS As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
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
        Me.btnTSTSignature = New System.Windows.Forms.Button()
        Me.btn_dlgAcquisition = New System.Windows.Forms.Button()
        Me.bntGetWSDiag = New System.Windows.Forms.Button()
        Me.btnTesttrtSemences = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.brnTestDiagRecap = New System.Windows.Forms.Button()
        Me.btnTestFacturation = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbTestRIFin = New System.Windows.Forms.Button()
        Me.btnTestDiagHelp12123 = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.panel_splashSynchro = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.title_alertes = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picto_profil = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_environnement_debugType = New System.Windows.Forms.Label()
        Me.lbl_environnement_debugLvl = New System.Windows.Forms.Label()
        Me.lbl_WS = New System.Windows.Forms.Label()
        Me.pnlPrincipal.SuspendLayout()
        Me.pnlLoginControls.SuspendLayout()
        Me.GroupBox_test.SuspendLayout()
        Me.panel_splashSynchro.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblBaseDonnee
        '
        Me.lblBaseDonnee.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBaseDonnee.AutoSize = True
        Me.lblBaseDonnee.BackColor = System.Drawing.Color.Transparent
        Me.lblBaseDonnee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBaseDonnee.ForeColor = System.Drawing.Color.Silver
        Me.lblBaseDonnee.Location = New System.Drawing.Point(189, 656)
        Me.lblBaseDonnee.Name = "lblBaseDonnee"
        Me.lblBaseDonnee.Size = New System.Drawing.Size(112, 15)
        Me.lblBaseDonnee.TabIndex = 34
        Me.lblBaseDonnee.Text = "Mode : Simplifié"
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
        Me.lblMode.Text = "Mode : Simplifié"
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
        Me.lbl_environnement_ws.Text = "Environnement webservice..............: Développement"
        Me.lbl_environnement_ws.Visible = False
        '
        'GroupBox_test
        '
        Me.GroupBox_test.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_test.Controls.Add(Me.btnTSTSignature)
        Me.GroupBox_test.Controls.Add(Me.btn_dlgAcquisition)
        Me.GroupBox_test.Controls.Add(Me.bntGetWSDiag)
        Me.GroupBox_test.Controls.Add(Me.btnTesttrtSemences)
        Me.GroupBox_test.Controls.Add(Me.Button4)
        Me.GroupBox_test.Controls.Add(Me.brnTestDiagRecap)
        Me.GroupBox_test.Controls.Add(Me.btnTestFacturation)
        Me.GroupBox_test.Controls.Add(Me.Button2)
        Me.GroupBox_test.Controls.Add(Me.Button1)
        Me.GroupBox_test.Controls.Add(Me.cbTestRIFin)
        Me.GroupBox_test.Controls.Add(Me.btnTestDiagHelp12123)
        Me.GroupBox_test.Controls.Add(Me.btnTest)
        Me.GroupBox_test.Location = New System.Drawing.Point(192, 471)
        Me.GroupBox_test.Name = "GroupBox_test"
        Me.GroupBox_test.Size = New System.Drawing.Size(793, 120)
        Me.GroupBox_test.TabIndex = 27
        Me.GroupBox_test.TabStop = False
        Me.GroupBox_test.Text = "Tests"
        '
        'btnTSTSignature
        '
        Me.btnTSTSignature.Location = New System.Drawing.Point(396, 77)
        Me.btnTSTSignature.Name = "btnTSTSignature"
        Me.btnTSTSignature.Size = New System.Drawing.Size(128, 23)
        Me.btnTSTSignature.TabIndex = 37
        Me.btnTSTSignature.Text = "Signature"
        Me.btnTSTSignature.UseVisualStyleBackColor = True
        '
        'btn_dlgAcquisition
        '
        Me.btn_dlgAcquisition.Location = New System.Drawing.Point(375, 47)
        Me.btn_dlgAcquisition.Name = "btn_dlgAcquisition"
        Me.btn_dlgAcquisition.Size = New System.Drawing.Size(128, 23)
        Me.btn_dlgAcquisition.TabIndex = 36
        Me.btn_dlgAcquisition.Text = "dlgAcquisition"
        Me.btn_dlgAcquisition.UseVisualStyleBackColor = True
        '
        'bntGetWSDiag
        '
        Me.bntGetWSDiag.Location = New System.Drawing.Point(377, 19)
        Me.bntGetWSDiag.Name = "bntGetWSDiag"
        Me.bntGetWSDiag.Size = New System.Drawing.Size(128, 23)
        Me.bntGetWSDiag.TabIndex = 35
        Me.bntGetWSDiag.Text = "ListeDiags"
        Me.bntGetWSDiag.UseVisualStyleBackColor = True
        '
        'btnTesttrtSemences
        '
        Me.btnTesttrtSemences.Location = New System.Drawing.Point(267, 77)
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
        'btnTestFacturation
        '
        Me.btnTestFacturation.BackColor = System.Drawing.SystemColors.Control
        Me.btnTestFacturation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestFacturation.Location = New System.Drawing.Point(267, 19)
        Me.btnTestFacturation.Name = "btnTestFacturation"
        Me.btnTestFacturation.Size = New System.Drawing.Size(104, 23)
        Me.btnTestFacturation.TabIndex = 31
        Me.btnTestFacturation.Text = "Facturation"
        Me.btnTestFacturation.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(244, 48)
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
        'btnTestDiagHelp12123
        '
        Me.btnTestDiagHelp12123.Location = New System.Drawing.Point(135, 18)
        Me.btnTestDiagHelp12123.Name = "btnTestDiagHelp12123"
        Me.btnTestDiagHelp12123.Size = New System.Drawing.Size(128, 23)
        Me.btnTestDiagHelp12123.TabIndex = 27
        Me.btnTestDiagHelp12123.Text = "DiagHelp12123"
        Me.btnTestDiagHelp12123.UseVisualStyleBackColor = True
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
        Me.panel_splashSynchro.Controls.Add(Me.PictureBox1)
        Me.panel_splashSynchro.Controls.Add(Me.title_alertes)
        Me.panel_splashSynchro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.panel_splashSynchro.Location = New System.Drawing.Point(270, 410)
        Me.panel_splashSynchro.Name = "panel_splashSynchro"
        Me.panel_splashSynchro.Size = New System.Drawing.Size(468, 102)
        Me.panel_splashSynchro.TabIndex = 25
        Me.panel_splashSynchro.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.PictureBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(123, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(220, 19)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'title_alertes
        '
        Me.title_alertes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_alertes.ForeColor = System.Drawing.Color.White
        Me.title_alertes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.title_alertes.Location = New System.Drawing.Point(9, -12)
        Me.title_alertes.Name = "title_alertes"
        Me.title_alertes.Size = New System.Drawing.Size(448, 68)
        Me.title_alertes.TabIndex = 1
        Me.title_alertes.Text = "Veuillez patienter pendant que votre logiciel se synchronise avec le Crodip."
        Me.title_alertes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label3.Text = "        Pour accéder au logiciel, veuillez sélectionner votre profil ci-dessous e" &
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
        Me.lbl_environnement_debugType.Text = "Environnement webservice..............: Développement"
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
        Me.lbl_environnement_debugLvl.Text = "Environnement webservice..............: Développement"
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
        Me.pnlLoginControls.ResumeLayout(False)
        Me.pnlLoginControls.PerformLayout()
        Me.GroupBox_test.ResumeLayout(False)
        Me.panel_splashSynchro.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picto_profil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region






#Region "Fonction de login"
    Private Sub doLogin()
        pnlLoginControls.Enabled = False
        ' On récupère le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent
        Statusbardisplay(Globals.CONST_STATUTMSG_LOGIN_ENCOURS, True)
        Dim bAgentExistant As Boolean = False
        Dim idAgent As Integer
        Try
            ' On récupère l'agent sélèctionné
            Dim selectedAgent As Agent
            selectedAgent = AgentManager.getAgentByNumeroNational(login_profil.SelectedItem.Id)
            idAgent = selectedAgent.id
            If selectedAgent.numeroNational.ToString <> "" Then
                If CSEnvironnement.checkWebService() = True Then
                    ' On commence par redescendre le pass de l'agent courant
                    Dim tmpObject As New Agent
                    Try
                        tmpObject = AgentManager.getWSAgentById(selectedAgent.numeroNational)
                        If tmpObject.id > 0 And tmpObject.isActif And Not tmpObject.isSupprime Then
                            selectedAgent.duppliqueInfosAgent(tmpObject, False)
                            AgentManager.save(selectedAgent)
                            bAgentExistant = True
                        Else
                            bAgentExistant = False
                            If tmpObject.id > 0 And tmpObject.isSupprime Then
                                'Suppression de l'agent en base
                                AgentManager.save(tmpObject)
                            End If
                            Statusbardisplay(Globals.CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a été désactivé par le Crodip.", False)
                            MsgBox(Globals.CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a été désactivé par le Crodip.")
                            'On recharge la Liste des profils 
                            FillCbxAgent()
                            login_password.Clear()
                            pnlLoginControls.Enabled = True

                            Exit Sub
                        End If
                    Catch ex As Exception
                        CSDebug.dispError("doLogin():: GetAgent mot de passe : " & ex.Message.ToString)
                    End Try
                Else
                    'Pas de WS => on considère que l'agent est OK
                    bAgentExistant = True
                End If
                If bAgentExistant Then
                    If CSCrypt.encode(login_password.Text, "sha256") = selectedAgent.motDePasse Or Globals.GLOB_ENV_DEBUG Then
                        ' Mot de passe correct => On le met en "session"
                        agentCourant = selectedAgent
                        ' On met à jour le numéro de version du logiciel agent
                        If selectedAgent.versionLogiciel <> Globals.GLOB_APPLI_VERSION & "-" & Globals.GLOB_APPLI_BUILD Then
                            selectedAgent.versionLogiciel = Globals.GLOB_APPLI_VERSION & "-" & Globals.GLOB_APPLI_BUILD
                            CSDebug.dispInfo("Login.doLogin():: Save Agent Version : " & selectedAgent.dateModificationAgent)
                            AgentManager.save(selectedAgent)
                        End If
                        'Synchronisation 
                        If Globals.GLOB_ENV_AUTOSYNC = True And Not selectedAgent.isGestionnaire Then
                            If CSEnvironnement.checkWebService() = True Then
                                panel_splashSynchro.Visible = True
                                CSTime.pause(500) ' Pause de 500ms

                                ' On vérifie les mises à jour
                                Statusbardisplay(Globals.CONST_STATUTMSG_SYNCHRO_ENCOURS, True)
                                Me.Cursor = Cursors.WaitCursor
                                Dim oSynchro As New Synchronisation(selectedAgent)
                                oSynchro.ajouteObservateur(TryCast(Me.MdiParent, parentContener))
                                '###### SYNCHRO ######
                                oSynchro.Synchro(True, True)
                                oSynchro.Notice("")
                                Me.Cursor = Cursors.Default
                            End If
                        End If
                        agentCourant = AgentManager.getAgentById(idAgent)
                        panel_splashSynchro.Visible = False
                        ' On met à jour la barre de status
                        Statusbardisplay(Globals.CONST_STATUTMSG_LOGIN_OK, False)
                        CSDebug.dispInfo("Connexion réussie " & selectedAgent.nom)
                        ' On met a jour la date de dernière connexion
                        selectedAgent.dateDerniereConnexion = CSDate.ToCRODIPString(Date.Now)
                        AgentManager.save(agentCourant)
                        ' On affiche le formulaire d'accueil de l'application
                        Dim formAccueil As New accueil
                        globFormAccueil = formAccueil
                        formAccueil.MdiParent = Me.MdiParent
                        formAccueil.Init(idAgent) '' initialisation de la fenêtre avant l'affichage
                        TryCast(MdiParent, parentContener).DisplayForm(formAccueil)
                        Me.Hide()

                    Else
                        ' On met à jour la barre de status
                        Statusbardisplay(Globals.CONST_STATUTMSG_LOGIN_FAILED & " : Mauvais mot de passe", False)
                        MsgBox(Globals.CONST_STATUTMSG_LOGIN_FAILED & " : Mauvais mot de passe")
                        login_password.Text = ""
                    End If 'Mot de passe
                End If 'bAgentExistant
            End If 'bAgentOK
        Catch ex As Exception
            ' On met à jour la barre de status
            Statusbardisplay(Globals.CONST_STATUTMSG_LOGIN_FAILED & " : " & ex.Message, False)
            CSDebug.dispError("login::doLogin : " & ex.Message)
        End Try
        'On réactive la fenêtre , si la procédure de Cnx a fonctionner, cette fenêtre est cachée
        pnlLoginControls.Enabled = True

    End Sub
#End Region
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CSDebug.dispInfo("login.Load: Start")
        ' Debug
        GroupBox_test.Visible = Globals.GLOB_ENV_DEBUG
        lbl_environnement_ws.Visible = Globals.GLOB_ENV_DEBUG
        lbl_environnement_debugType.Visible = Globals.GLOB_ENV_DEBUG
        lbl_environnement_debugLvl.Visible = Globals.GLOB_ENV_DEBUG
        lbl_environnement_debugType.Text = "Type de sortie debug..................: " & Globals.GLOB_ENV_DEBUGTYPE
        lbl_environnement_debugLvl.Text = "Niveau de sortie debug................: " & Globals.GLOB_ENV_DEBUGLVL
        lbl_WS.Text = WSCrodip.getWS().Url
        lblMode.Visible = False
        pnlPrincipal.BackgroundImage = Crodip_agent.Resources.Login_bgcrodipIndigo
        If Globals.GLOB_ENV_MODESIMPLIFIE Then
            lblMode.Visible = True
            pnlPrincipal.BackgroundImage = Crodip_agent.Resources.login_bgcrodip
        End If
        If Globals.GLOB_ENV_MODEFORMATION Then
            lblMode.Visible = True
            lblMode.Text = "Mode : Formation"
            pnlPrincipal.BackgroundImage = Crodip_agent.Resources.login_bgVide
            lbl_WS.Visible = False
        End If


        If Not Globals.GLOB_ENV_MODEFORMATION Then
            CSDebug.dispInfo("Login.Load: CheckWS()")
            If Not CSEnvironnement.checkWebService() Then
                lbl_WS.Text = WSCrodip.getWS().Url
                lbl_WS.ForeColor = Drawing.Color.Red
            End If
            Lbl_Version.Text = Globals.GLOB_APPLI_VERSION & "-" & Globals.GLOB_APPLI_BUILD
            If Not My.Settings.AutoSync Then
                Lbl_Version.Text = Lbl_Version.Text & " SYNC OFF"
            Else
                Lbl_Version.Text = Lbl_Version.Text & " SYNC ON"
            End If
        End If
        If Globals.GLOB_ENV_DEBUG Then
            Dim oCSDB As New CSDb(False)
            lblBaseDonnee.Text = oCSDB.getbddPathName()
        Else
            lblBaseDonnee.Text = ""
        End If

        ' Chargement de la statusbar
        Statusbardisplay("Chargement de la liste de profils...", True)


        FillCbxAgent()
        'Statusbardisplay("Chargement réussi de " & nbProfils & " profil(s)", False)
        Statusbarclear()

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
        oAgentList = AgentManager.getAgentList()
        login_profil.Items.Clear()
        For Each curAgent As Agent In oAgentList.items
            ' On ajoute le profil à la liste déroulante
            Dim libelleAccount As String = curAgent.nom & " " & curAgent.prenom
            libelleAccount = libelleAccount & "(" & curAgent.NomStructure & ")"
            Dim objComboItem As New objComboItem(curAgent.numeroNational, libelleAccount)
            login_profil.Items.Add(objComboItem)
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
            oFrm.SetContexte(oDiag, Globals.DiagMode.CTRL_COMPLET, oPulve, oExploit)

            Dim oDiag12123 As New DiagnosticHelp12123()
            oFrm.ShowDialog()

        End If
    End Sub

    Private Sub btnTestDiagHelp12123_Click(sender As Object, e As EventArgs) Handles btnTestDiagHelp12123.Click

        Dim oFRM As diagnostic_dlghelp12123new
        Dim oDiag12123 As New DiagnosticHelp12123()
        Dim oP1 As DiagnosticHelp12123Pompe = oDiag12123.AjoutePompe()
        oP1.debitMesure = 10
        oP1.PressionMesure = 5
        oP1.PressionMoyenne = 15
        oP1.NbBuses = 5
        Dim oMesure As DiagnosticHelp12123Mesure = oP1.lstMesures(0)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 13
        oMesure.MasseAspire = 3.492
        oMesure = oP1.lstMesures(1)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 3.756
        oMesure.MasseAspire = 3.492
        oMesure = oP1.lstMesures(2)
        oMesure.ReglageDispositif = 23
        oMesure.TempsMesure = 30
        oMesure.MasseInitiale = 13
        oMesure.MasseAspire = 3.492
        Dim oP2 As DiagnosticHelp12123Pompe = oDiag12123.AjoutePompe()
        oP2.debitMesure = 12
        oP2.PressionMesure = 7
        oP2.PressionMoyenne = 15
        oP2.NbBuses = 5
        oDiag12123.calcule()


        oFRM = New diagnostic_dlghelp12123new()
        oFRM.setContexte(oDiag12123, False)
        oFRM.ShowDialog()


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
        '        oPulve = PulverisateurManager.getPulverisateurById("2-1-51") 'Culture maraîchères palissées
        'oPulve = PulverisateurManager.getPulverisateurById("2-81-63") 'Pulvérisateurs combinés
        '        oPulve = PulverisateurManager.getPulverisateurById("2-81-50") 'Cultures basses
        oPulve = PulverisateurManager.getPulverisateurById("2-1083-7") 'Vigne
        oAgent = AgentManager.getAgentById("1110")
        oDiag = New Diagnostic(oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libellé est sur plusieurs lignes et tout doit apparaoitre même ces dernièrs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "2", "1", "O")
        oDiagItem.LibelleCourt = "LIBCourt2562"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2562 a a a a a a a a a a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a  a a aa  a aa  aa a a a a a a a a a a a a a a a a a a a a a a a a aa a aa a   b b b bb b b b b b b b b b b b b b b b b  b bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb bb b bb b bb b bb b b bbbbbbb cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc Z"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        oEtat = New EtatRapportInspection(oDiag)
        oEtat.GenereEtat()
        oEtat.Open()

    End Sub




#End Region


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim oAgent As Agent

        oAgent = AgentManager.getAgentById("1110")

        Dim ofrm As New frmControleManometres2(oAgent)
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim oAgent As Agent

        oAgent = AgentManager.getAgentById("1110")

        Dim oPulve As New Pulverisateur()
        Dim oExploit As New Exploitation()
        Dim ofrm As New ajout_pulve2()
        ofrm.setContexte(ajout_pulve2.MODE.AJOUT, oAgent, oPulve, oExploit, Nothing)
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)

    End Sub

    Private Sub btnTestFacturation_Click(sender As Object, e As EventArgs) Handles btnTestFacturation.Click

        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiag As Diagnostic
        Dim oAgent As Agent

        oPulve = PulverisateurManager.getPulverisateurById("2-81-50")
        oPulve.modeUtilisation = "Co-Propriété"
        oPulve.nombreExploitants = 3
        oAgent = AgentManager.getAgentByNumeroNational("MCII")
        If oPulve IsNot Nothing Then
            oExploit = ExploitationManager.GetExploitationByPulverisateurId(oPulve.id)
            oDiag = New Diagnostic(oAgent, oPulve, oExploit)
            Dim oFrm As New diagnostic_facturation()
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
        '        oPulve = PulverisateurManager.getPulverisateurById("2-1-51") 'Culture maraîchères palissées
        'oPulve = PulverisateurManager.getPulverisateurById("2-81-63") 'Pulvérisateurs combinés
        '        oPulve = PulverisateurManager.getPulverisateurById("2-81-50") 'Cultures basses
        oPulve = PulverisateurManager.getPulverisateurById("2-1083-7") 'Vigne
        oAgent = AgentManager.getAgentById("1110")
        oAgent.isSignElecActive = True
        oDiag = New Diagnostic(oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiag.controleIsPreControleProfessionel = True
        oDiag.proprietaireRepresentant = "Repésentant"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = 2.5
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.inspecteurOrigineNom = "RAULT"
        oDiag.inspecteurOriginePrenom = "MA"
        oDiag.organismeOriginePresNom = "CRODIP"
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libellé est sur plusieurs lignes et tout doit apparaoitre même ces dernièrs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"
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
        ofrm = New frmdiagnostic_recap(Globals.DiagMode.CTRL_COMPLET, oDiag, oPulve, oExploit, oAgent, Nothing)
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
        '        oPulve = PulverisateurManager.getPulverisateurById("2-1-51") 'Culture maraîchères palissées
        'oPulve = PulverisateurManager.getPulverisateurById("2-81-63") 'Pulvérisateurs combinés
        '        oPulve = PulverisateurManager.getPulverisateurById("2-81-50") 'Cultures basses
        oPulve = PulverisateurManager.getPulverisateurById("2-81-25") '

        Dim ofrm As New liste_diagnosticPulve2()
        ofrm.setcontexte(Globals.DiagMode.CTRL_VISU, oPulve, oExploit, oAgent)
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
        '        oPulve = PulverisateurManager.getPulverisateurById("2-1-51") 'Culture maraîchères palissées
        'oPulve = PulverisateurManager.getPulverisateurById("2-81-63") 'Pulvérisateurs combinés
        '        oPulve = PulverisateurManager.getPulverisateurById("2-81-50") 'Cultures basses
        oPulve = PulverisateurManager.getPulverisateurById("2-1083-7") 'Vigne
        oDiag = New Diagnostic(oAgent, oPulve, oExploit)
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV
        oDiag.controleDateDebut = Now()
        oDiag.CalculDateProchainControle()

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
End Class
