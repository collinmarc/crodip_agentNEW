Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports System.IO
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
'Imports System.Drawing
'Imports System.Drawing.Imaging
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents login_profil As System.Windows.Forms.ComboBox
    Friend WithEvents login_password As System.Windows.Forms.TextBox
    Friend WithEvents formLogin As System.Windows.Forms.Panel
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
    Friend WithEvents lbl_WS As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.formLogin = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.formLogin.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        'formLogin
        '
        Me.formLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.formLogin.Controls.Add(Me.Label2)
        Me.formLogin.Controls.Add(Me.Label1)
        Me.formLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.formLogin.Location = New System.Drawing.Point(0, 0)
        Me.formLogin.Name = "formLogin"
        Me.formLogin.Size = New System.Drawing.Size(1008, 64)
        Me.formLogin.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(416, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CRODIP"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(400, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "        Banc de mesure de débits informatisés"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.pnlLoginControls)
        Me.Panel1.Controls.Add(Me.Lbl_Version)
        Me.Panel1.Controls.Add(Me.lbl_environnement_ws)
        Me.Panel1.Controls.Add(Me.GroupBox_test)
        Me.Panel1.Controls.Add(Me.panel_splashSynchro)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.picto_profil)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lbl_environnement_debugType)
        Me.Panel1.Controls.Add(Me.lbl_environnement_debugLvl)
        Me.Panel1.Controls.Add(Me.lbl_WS)
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 616)
        Me.Panel1.TabIndex = 0
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
        Me.Lbl_Version.AutoSize = True
        Me.Lbl_Version.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Version.ForeColor = System.Drawing.Color.Silver
        Me.Lbl_Version.Location = New System.Drawing.Point(870, 594)
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
        Me.GroupBox_test.Controls.Add(Me.btnTestDiagHelp12123)
        Me.GroupBox_test.Controls.Add(Me.btnTest)
        Me.GroupBox_test.Location = New System.Drawing.Point(192, 471)
        Me.GroupBox_test.Name = "GroupBox_test"
        Me.GroupBox_test.Size = New System.Drawing.Size(793, 120)
        Me.GroupBox_test.TabIndex = 27
        Me.GroupBox_test.TabStop = False
        Me.GroupBox_test.Text = "Tests"
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
        Me.lbl_WS.AutoSize = True
        Me.lbl_WS.BackColor = System.Drawing.Color.Transparent
        Me.lbl_WS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_WS.ForeColor = System.Drawing.Color.Silver
        Me.lbl_WS.Location = New System.Drawing.Point(653, 594)
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
        Me.Controls.Add(Me.formLogin)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.formLogin.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
        Statusbardisplay(CONST_STATUTMSG_LOGIN_ENCOURS, True)
        Try
            ' On récupère l'agent sélèctionné
            Dim selectedAgent As Agent
            If login_profil.Text <> "" Then
                selectedAgent = AgentManager.getAgentByNumeroNational(login_profil.SelectedItem.Id)
                If selectedAgent.numeroNational.ToString <> "" Then
                    If login_password.Text <> "" Then
                        If CSEnvironnement.checkWebService() = True Then
                            ' On commence par redescendre le pass de l'agent courant
                            Dim tmpObject As New Agent
                            Try
                                tmpObject = AgentManager.getWSAgentById(selectedAgent.numeroNational)
                                If tmpObject.id <> 0 And Not String.IsNullOrEmpty(tmpObject.motDePasse) Then
                                    selectedAgent.duppliqueInfosAgent(tmpObject, False)

                                    AgentManager.save(selectedAgent)
                                End If
                                If tmpObject.id <> selectedAgent.id Then
                                    CSDebug.dispError("Login.doLogin : incohérence d'id entre le serveur et l'agent : Agent=" & selectedAgent.id & " Serveur : " & tmpObject.id)
                                    MsgBox("Une incohérence dans votre base a été détectée, prévenir le CRODIP le plus rapidement possible", MsgBoxStyle.Critical)
                                End If
                            Catch ex As Exception
                                CSDebug.dispError("doLogin():: GetAgent mot de passe : " & ex.Message.ToString)
                            End Try
                        End If
                        If CSCrypt.encode(login_password.Text, "sha256") = selectedAgent.motDePasse Or GLOB_ENV_DEBUG Then
                            ' On le met en "session"
                            agentCourant = selectedAgent
                            ' On met à jour le numéro de version du logiciel agent
                            If agentCourant.versionLogiciel <> GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD Then
                                agentCourant.versionLogiciel = GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD
                                CSDebug.dispInfo("Login.doLogin():: Save Agent Version : " & agentCourant.dateModificationAgent)
                                AgentManager.save(agentCourant)
                            End If
                            If agentCourant.isActif And Not agentCourant.isSupprime Then
                                If GLOB_ENV_AUTOSYNC = True And Not agentCourant.isGestionnaire Then
                                    If CSEnvironnement.checkNetwork() = True Then
                                        If CSEnvironnement.checkWebService() = True Then

                                            panel_splashSynchro.Visible = True
                                            CSTime.pause(500) ' Pause de 500ms

                                            ' On vérifie les mises à jour
                                            Statusbardisplay(CONST_STATUTMSG_SYNCHRO_ENCOURS, True)
                                            Try
                                                Me.Cursor = Cursors.WaitCursor
                                                Dim oSynchro As New Synchronisation(agentCourant)
                                                oSynchro.ajouteObservateur(TryCast(Me.MdiParent, parentContener))
                                                '#######################################################################
                                                '######################### Synchro Montantes ###########################
                                                '#######################################################################
                                                oSynchro.runAscSynchro()

                                                '#######################################################################
                                                '####################### Synchro Descendantes ##########################
                                                '#######################################################################
                                                oSynchro.runDescSynchro()
                                                oSynchro.Notice("")
                                                Me.Cursor = Cursors.Default
                                            Catch ex As Exception
                                                CSDebug.dispError("Synchronisation : " & ex.Message.ToString)
                                                Statusbardisplay(CONST_STATUTMSG_SYNCHRO_FAILED, False)
                                            End Try
                                        Else
                                            Statusbardisplay(CONST_STATUTMSG_SYNCHRO_UNAVAILABLE, False)
                                            MsgBox("Synchronisation impossible, serveur Crodip momentanément indisponible.", MsgBoxStyle.Exclamation)
                                        End If
                                    Else
                                        ' Pas de connexion
                                    End If
                                End If
                                panel_splashSynchro.Visible = False
                                ' On met à jour la barre de status
                                Statusbardisplay(CONST_STATUTMSG_LOGIN_OK, False)
                                CSDebug.dispInfo("Connexion réussie " & agentCourant.nom)
                                ' On met a jour la date de dernière connexion
                                agentCourant.dateDerniereConnexion = CSDate.ToCRODIPString(Date.Now).ToString
                                CSDebug.dispInfo("Login.doLogin():: Save Agent Date Dernière connexion : " & agentCourant.dateDerniereConnexion)
                                AgentManager.save(agentCourant)
                                ' On affiche le formulaire d'accueil de l'application
                                Dim formAccueil As New accueil
                                globFormAccueil = formAccueil
                                formAccueil.MdiParent = Me.MdiParent
                                formAccueil.Init() '' initialisation de la fenêtre avant l'affichage
                                TryCast(MdiParent, parentContener).DisplayForm(formAccueil)
                                '                                formAccueil.Show()
                                Me.Hide()
                                'Me.Close()
                            Else

                                ' On met à jour la barre de status
                                Statusbardisplay(CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a été désactivé par le Crodip.", False)
                                MsgBox(CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a été désactivé par le Crodip.")
                                'On recharge la Liste des profils 
                                FillCbxAgent()
                                login_password.Clear()
                            End If

                        Else
                            ' On met à jour la barre de status
                            Statusbardisplay(CONST_STATUTMSG_LOGIN_FAILED & " : Mauvais mot de passe", False)
                            MsgBox(CONST_STATUTMSG_LOGIN_FAILED & " : Mauvais mot de passe")
                        End If
                    Else
                        Statusbardisplay(CONST_STATUTMSG_LOGIN_FAILED & " : Veuillez renseigner un mot de passe.", False)
                    End If
                Else
                    Statusbardisplay(CONST_STATUTMSG_LOGIN_FAILED & " : Aucun agent correspondant", False)
                End If
            Else
                Statusbardisplay(CONST_STATUTMSG_LOGIN_FAILED & " : Veuillez sélectionner un profil.", False)
            End If
        Catch ex As Exception
            ' On met à jour la barre de status
            Statusbardisplay(CONST_STATUTMSG_LOGIN_FAILED & " : " & ex.Message, False)
            CSDebug.dispError("login::doLogin : " & ex.Message)
        End Try
        'On réactive la fenêtre , si la procédure de Cnx a fonctionner, cette fenêtre est cachée
        pnlLoginControls.Enabled = True

    End Sub
#End Region
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Debug
        GroupBox_test.Visible = GLOB_ENV_DEBUG
        lbl_environnement_ws.Visible = GLOB_ENV_DEBUG
        lbl_environnement_debugType.Visible = GLOB_ENV_DEBUG
        lbl_environnement_debugLvl.Visible = GLOB_ENV_DEBUG
        lbl_environnement_debugType.Text = "Type de sortie debug..................: " & GLOB_ENV_DEBUGTYPE
        lbl_environnement_debugLvl.Text = "Niveau de sortie debug................: " & GLOB_ENV_DEBUGLVL
        lbl_WS.Text = WSCrodip.getWS().Url

        If Not CSEnvironnement.checkWebService() Then
            lbl_WS.ForeColor = Drawing.Color.Red
        End If
        Lbl_Version.Text = GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD
        ' On récupère le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent
        ' Initialisation des variables
        ' FIN --- Initialisation des variables

        ' Chargement de la statusbar
        Statusbardisplay("Chargement de la liste de profils...", True)

        ' On récupère le nombre d'organismes
        Dim nbStructures As Integer = 0
        Dim CSDb As New CSDb(True)
        Dim dataListStructure As System.Data.OleDb.OleDbDataReader = CSDb.getResults("SELECT count(*) FROM Structure")
        While dataListStructure.Read()
            nbStructures = CType(dataListStructure.Item(0), Integer)
        End While
        CSDb.free()
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
        oPulve.type = "Arbres"
        agentCourant = AgentManager.getAgentByNumeroNational("MCII")
        If oPulve IsNot Nothing Then
            oExploit = ExploitationManager.GetExploitationByPulverisateurId(oPulve.id)
            oDiag = New Diagnostic(agentCourant, oPulve, oExploit)
            Dim oFrm As New frmDiagnostique()
            oFrm.setContexte(oDiag, DiagMode.CTRL_COMPLET, oPulve, oExploit)

            oFrm.ShowDialog()
        End If
    End Sub

    Private Sub btnTestDiagHelp12123_Click(sender As Object, e As EventArgs) Handles btnTestDiagHelp12123.Click

        Dim oFRM As diagnostic_dlghelp12123
        Dim oDiag12123 As New DiagnosticHelp12123()
        oDiag12123.debitMesure = 1.006
        oDiag12123.PressionMesure = 2
        oDiag12123.PressionMoyenne = 2.2
        oDiag12123.NbBuses = 8

        oFRM = New diagnostic_dlghelp12123()
        oFRM.setContexte(oDiag12123, True)
        oFRM.ShowDialog()


    End Sub




#End Region


End Class
