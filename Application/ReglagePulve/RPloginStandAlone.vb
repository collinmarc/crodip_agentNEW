Imports System.IO
Imports System.Text.RegularExpressions

Public Class RPloginStandAlone
    Inherits Form

    Private _RPUser As Agent
    Public ReadOnly Property RPuser As Agent
        Get
            Return _RPUser
        End Get
    End Property
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents formLogin As System.Windows.Forms.Panel
    Friend WithEvents picto_profil As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_login_seConnecter As System.Windows.Forms.Label
    'Friend WithEvents cr_facture As CrystalDecisions.Windows.Forms.CrystalReportViewer
    '   Friend WithEvents cr_debitBuses As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Lbl_Version As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents pnlLoginControls As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents tbUser As TextBox
    Friend WithEvents btnAnnuler As Label
    Friend WithEvents lblError As Label
    Friend WithEvents lbl_WS As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RPloginStandAlone))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.formLogin = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblError = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlLoginControls = New System.Windows.Forms.Panel()
        Me.btnAnnuler = New System.Windows.Forms.Label()
        Me.tbUser = New System.Windows.Forms.TextBox()
        Me.btn_login_seConnecter = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_Version = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picto_profil = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_WS = New System.Windows.Forms.Label()
        Me.formLogin.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLoginControls.SuspendLayout()
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
        Me.Label1.Text = "        Outil de réglage pulvérisateur"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Crodip_Agent.Resources.login_bg
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.lblError)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.pnlLoginControls)
        Me.Panel1.Controls.Add(Me.Lbl_Version)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.picto_profil)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lbl_WS)
        Me.Panel1.Location = New System.Drawing.Point(0, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 616)
        Me.Panel1.TabIndex = 0
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.BackColor = System.Drawing.Color.Transparent
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Maroon
        Me.lblError.Location = New System.Drawing.Point(459, 188)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(276, 17)
        Me.lblError.TabIndex = 34
        Me.lblError.Text = "Utilisateur ou Mot de passe incorrect"
        Me.lblError.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Crodip_Agent.Resources.logo
        Me.PictureBox2.Location = New System.Drawing.Point(24, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(168, 187)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = False
        '
        'pnlLoginControls
        '
        Me.pnlLoginControls.BackColor = System.Drawing.Color.Transparent
        Me.pnlLoginControls.Controls.Add(Me.btnAnnuler)
        Me.pnlLoginControls.Controls.Add(Me.tbUser)
        Me.pnlLoginControls.Controls.Add(Me.btn_login_seConnecter)
        Me.pnlLoginControls.Controls.Add(Me.Label5)
        Me.pnlLoginControls.Controls.Add(Me.tbPassword)
        Me.pnlLoginControls.Controls.Add(Me.Label4)
        Me.pnlLoginControls.Location = New System.Drawing.Point(459, 216)
        Me.pnlLoginControls.Name = "pnlLoginControls"
        Me.pnlLoginControls.Size = New System.Drawing.Size(436, 111)
        Me.pnlLoginControls.TabIndex = 32
        '
        'btnAnnuler
        '
        Me.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Image = Crodip_Agent.Resources.btn_annuler
        Me.btnAnnuler.Location = New System.Drawing.Point(168, 75)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(128, 24)
        Me.btnAnnuler.TabIndex = 4
        Me.btnAnnuler.Text = "      Annuler"
        Me.btnAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbUser
        '
        Me.tbUser.Location = New System.Drawing.Point(188, 15)
        Me.tbUser.Name = "tbUser"
        Me.tbUser.Size = New System.Drawing.Size(241, 20)
        Me.tbUser.TabIndex = 1
        '
        'btn_login_seConnecter
        '
        Me.btn_login_seConnecter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_login_seConnecter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login_seConnecter.ForeColor = System.Drawing.Color.White
        Me.btn_login_seConnecter.Image = CType(resources.GetObject("btn_login_seConnecter.Image"), System.Drawing.Image)
        Me.btn_login_seConnecter.Location = New System.Drawing.Point(302, 75)
        Me.btn_login_seConnecter.Name = "btn_login_seConnecter"
        Me.btn_login_seConnecter.Size = New System.Drawing.Size(128, 24)
        Me.btn_login_seConnecter.TabIndex = 3
        Me.btn_login_seConnecter.Text = "       Se connecter"
        Me.btn_login_seConnecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(190, 41)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(240, 20)
        Me.tbPassword.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(66, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Code utilisateur :"
        '
        'Lbl_Version
        '
        Me.Lbl_Version.AutoSize = True
        Me.Lbl_Version.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Version.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Lbl_Version.Location = New System.Drawing.Point(870, 594)
        Me.Lbl_Version.Name = "Lbl_Version"
        Me.Lbl_Version.Size = New System.Drawing.Size(101, 15)
        Me.Lbl_Version.TabIndex = 30
        Me.Lbl_Version.Text = "Version - Build"
        Me.Lbl_Version.TextAlign = System.Drawing.ContentAlignment.BottomRight
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
        'lbl_WS
        '
        Me.lbl_WS.AutoSize = True
        Me.lbl_WS.BackColor = System.Drawing.Color.Transparent
        Me.lbl_WS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_WS.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lbl_WS.Location = New System.Drawing.Point(653, 594)
        Me.lbl_WS.Name = "lbl_WS"
        Me.lbl_WS.Size = New System.Drawing.Size(183, 15)
        Me.lbl_WS.TabIndex = 31
        Me.lbl_WS.Text = "http://serveur_crodip/Server"
        Me.lbl_WS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RPloginStandAlone
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 680)
        Me.ControlBox = False
        Me.Controls.Add(Me.formLogin)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RPloginStandAlone"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.formLogin.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLoginControls.ResumeLayout(False)
        Me.pnlLoginControls.PerformLayout()
        CType(Me.picto_profil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Fonction de login"
    Private Function doLogin() As Boolean
        Dim bOK As Boolean = False
        Try
            ' On récupère l'agent sélèctionné
            If tbUser.Text <> "" Then
                Dim objParamRP As ParamReglagePulve = ParamReglagePulve.ReadXML(".")
                Dim objRPUser As RPUser = objParamRP.getUSer(tbUser.Text)
                If objRPUser IsNot Nothing Then
                    If objRPUser.TestPassword(tbPassword.Text) Then
                        If objRPUser.TestDateExp(Now) Then
                            bOK = True
                            _RPUser = New Agent()
                            _RPUser.nom = objRPUser.Code
                            _RPUser.motDePasse = objRPUser.PasswordCrypted
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        Return bOK
    End Function
#End Region
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub



    ' Connexion a son profil
    Private Sub login_password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            doLogin()

        End If
    End Sub
    Private Sub btn_login_seConnecter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login_seConnecter.Click
        If doLogin() Then
            Me.Close()
        Else
            lblError.Visible = True
        End If


    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Application.Exit()
    End Sub
End Class
