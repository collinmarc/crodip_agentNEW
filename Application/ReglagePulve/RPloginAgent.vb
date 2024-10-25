'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
'Imports System.Drawing
'Imports System.Drawing.Imaging

Imports System.Data.Common
Imports CRODIPWS

Public Class RPloginAgent
    Inherits Form
    Private _Agent As Agent
    Public Property AgentCourant() As Agent
        Get
            Return _Agent
        End Get
        Set(ByVal value As Agent)
            _Agent = value
        End Set
    End Property
#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents login_profil As System.Windows.Forms.ComboBox
    Friend WithEvents login_password As System.Windows.Forms.TextBox
    Friend WithEvents picto_profil As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_login_seConnecter As System.Windows.Forms.Label
    Friend WithEvents lbl_environnement_ws As System.Windows.Forms.Label
    Friend WithEvents lbl_environnement_debugType As System.Windows.Forms.Label
    Friend WithEvents lbl_environnement_debugLvl As System.Windows.Forms.Label
    'Friend WithEvents cr_facture As CrystalDecisions.Windows.Forms.CrystalReportViewer
    '   Friend WithEvents cr_debitBuses As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Lbl_Version As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents pnlLoginControls As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnAnnuler As Label
    Friend WithEvents lbl_WS As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RPloginAgent))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlLoginControls = New System.Windows.Forms.Panel()
        Me.btnAnnuler = New System.Windows.Forms.Label()
        Me.btn_login_seConnecter = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.login_password = New System.Windows.Forms.TextBox()
        Me.login_profil = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_Version = New System.Windows.Forms.Label()
        Me.lbl_environnement_ws = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picto_profil = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_environnement_debugType = New System.Windows.Forms.Label()
        Me.lbl_environnement_debugLvl = New System.Windows.Forms.Label()
        Me.lbl_WS = New System.Windows.Forms.Label()
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
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.pnlLoginControls)
        Me.Panel1.Controls.Add(Me.Lbl_Version)
        Me.Panel1.Controls.Add(Me.lbl_environnement_ws)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.picto_profil)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lbl_environnement_debugType)
        Me.Panel1.Controls.Add(Me.lbl_environnement_debugLvl)
        Me.Panel1.Controls.Add(Me.lbl_WS)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 681)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Crodip_agent.Resources.logo
        Me.PictureBox2.Location = New System.Drawing.Point(24, 13)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(175, 208)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = False
        '
        'pnlLoginControls
        '
        Me.pnlLoginControls.BackColor = System.Drawing.Color.Transparent
        Me.pnlLoginControls.Controls.Add(Me.btnAnnuler)
        Me.pnlLoginControls.Controls.Add(Me.btn_login_seConnecter)
        Me.pnlLoginControls.Controls.Add(Me.Label5)
        Me.pnlLoginControls.Controls.Add(Me.login_password)
        Me.pnlLoginControls.Controls.Add(Me.login_profil)
        Me.pnlLoginControls.Controls.Add(Me.Label4)
        Me.pnlLoginControls.Location = New System.Drawing.Point(459, 216)
        Me.pnlLoginControls.Name = "pnlLoginControls"
        Me.pnlLoginControls.Size = New System.Drawing.Size(436, 111)
        Me.pnlLoginControls.TabIndex = 32
        '
        'btnAnnuler
        '
        Me.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.btnAnnuler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Image = Crodip_agent.Resources.btn_annuler
        Me.btnAnnuler.Location = New System.Drawing.Point(158, 74)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(128, 24)
        Me.btnAnnuler.TabIndex = 3
        Me.btnAnnuler.Text = "       Annuler"
        Me.btnAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_login_seConnecter
        '
        Me.btn_login_seConnecter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_login_seConnecter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login_seConnecter.ForeColor = System.Drawing.Color.White
        Me.btn_login_seConnecter.Image = CType(resources.GetObject("btn_login_seConnecter.Image"), System.Drawing.Image)
        Me.btn_login_seConnecter.Location = New System.Drawing.Point(302, 74)
        Me.btn_login_seConnecter.Name = "btn_login_seConnecter"
        Me.btn_login_seConnecter.Size = New System.Drawing.Size(128, 24)
        Me.btn_login_seConnecter.TabIndex = 2
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
        'login_password
        '
        Me.login_password.Location = New System.Drawing.Point(190, 41)
        Me.login_password.Name = "login_password"
        Me.login_password.PasswordChar = Microsoft.VisualBasic.ChrW(42)
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
        Me.Lbl_Version.ForeColor = System.Drawing.SystemColors.GrayText
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
        Me.lbl_environnement_ws.Text = "Environnement webservice..............: D�veloppement"
        Me.lbl_environnement_ws.Visible = False
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
        'RPloginAgent
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 680)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RPloginAgent"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
        Dim bok As Boolean = False
        pnlLoginControls.Enabled = False
        ' On r�cup�re le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent
        Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_ENCOURS, True)
        Try
            ' On r�cup�re l'agent s�l�ctionn�
            Dim selectedAgent As Agent
            If login_profil.Text <> "" Then
                selectedAgent = AgentManager.getAgentByNumeroNational(login_profil.SelectedItem.Id)
                If selectedAgent.numeroNational.ToString <> "" Then
                    If login_password.Text <> "" Then
                        If CSEnvironnement.checkWebService() = True Then
                            ' On commence par redescendre le pass de l'agent courant
                            Dim tmpObject As New Agent
                            Try
                                tmpObject = AgentManager.WSgetByNumeroNational(selectedAgent.numeroNational)
                                If tmpObject.id <> 0 And Not String.IsNullOrEmpty(tmpObject.motDePasse) Then
                                    selectedAgent.duppliqueInfosAgent(tmpObject, False)

                                    AgentManager.save(selectedAgent)
                                End If
                                If tmpObject.id <> selectedAgent.id Then
                                    CSDebug.dispError("Login.doLogin : incoh�rence d'id entre le serveur et l'agent : Agent=" & selectedAgent.id & " Serveur : " & tmpObject.id)
                                    MsgBox("Une incoh�rence dans votre base a �t� d�tect�e, pr�venir le CRODIP le plus rapidement possible", MsgBoxStyle.Critical)
                                End If
                            Catch ex As Exception
                                CSDebug.dispError("doLogin():: GetAgent mot de passe : " & ex.Message.ToString)
                            End Try
                        End If
                        If CSCrypt.encode(login_password.Text, "sha256") = selectedAgent.motDePasse Then
                            ' On le met en "session"
                            AgentCourant = selectedAgent
                            ' On met � jour le num�ro de version du logiciel agent
                            If AgentCourant.versionLogiciel <> GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD Then
                                AgentCourant.versionLogiciel = GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD
                                'CSDebug.dispInfo("Login.doLogin():: Save Agent Version : " & agentCourant.dateModificationAgent)
                                'AgentManager.save(agentCourant)
                            End If
                            If AgentCourant.isActif And Not AgentCourant.isSupprime Then
                                ' On met � jour la barre de status
                                Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_OK, False)
                                CSDebug.dispInfo("Connexion r�ussie " & AgentCourant.nom)
                                ' On met a jour la date de derni�re connexion
                                AgentCourant.dateDerniereConnexion = CSDate.ToCRODIPString(Date.Now).ToString
                                'CSDebug.dispInfo("Login.doLogin():: Save Agent Date Derni�re connexion : " & agentCourant.dateDerniereConnexion)
                                'AgentManager.save(agentCourant)
                                Me.Close()
                                'Me.Close()
                                Me.AgentCourant = AgentCourant
                                bok = True
                            Else

                                ' On met � jour la barre de status
                                Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a �t� d�sactiv� par le Crodip.", False)
                                MsgBox(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Votre profil a �t� d�sactiv� par le Crodip.")
                                'On recharge la Liste des profils 
                                FillCbxAgent()
                                login_password.Clear()
                            End If

                        Else
                            ' On met � jour la barre de status
                            Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Mauvais mot de passe", False)
                            MsgBox(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Mauvais mot de passe")
                        End If
                    Else
                        Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Veuillez renseigner un mot de passe.", False)
                    End If
                Else
                    Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Aucun agent correspondant", False)
                End If
            Else
                Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : Veuillez s�lectionner un profil.", False)
            End If
        Catch ex As Exception
            ' On met � jour la barre de status
            Statusbardisplay(GlobalsCRODIP.CONST_STATUTMSG_LOGIN_FAILED & " : " & ex.Message, False)
            CSDebug.dispError("login::doLogin : " & ex.Message)
        End Try
        'On r�active la fen�tre , si la proc�dure de Cnx a fonctionner, cette fen�tre est cach�e
        pnlLoginControls.Enabled = True
        Return bok
    End Function
#End Region
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Debug
        lbl_environnement_ws.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG
        lbl_environnement_debugType.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG
        lbl_environnement_debugLvl.Visible = GlobalsCRODIP.GLOB_ENV_DEBUG
        lbl_environnement_debugType.Text = "Type de sortie debug..................: " & GlobalsCRODIP.GLOB_ENV_DEBUGTYPE
        lbl_environnement_debugLvl.Text = "Niveau de sortie debug................: " & GlobalsCRODIP.GLOB_ENV_DEBUGLVL
        lbl_WS.Text = WSCrodip.getWS().Url

        If Not CSEnvironnement.checkWebService() Then
            lbl_WS.ForeColor = Drawing.Color.Red
        End If
        Lbl_Version.Text = GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GlobalsCRODIP.GLOB_APPLI_BUILD
        ' On r�cup�re le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent
        ' Initialisation des variables
        ' FIN --- Initialisation des variables

        ' Chargement de la statusbar
        Statusbardisplay("Chargement de la liste de profils...", True)

        ' On r�cup�re le nombre d'organismes
        Dim nbStructures As Integer = 0
        Dim CSDb As New CSDb(True)
        nbStructures = CSDb.getValue("SELECT count(*) FROM Structure")
        CSDb.free()
        FillCbxAgent()
        'Statusbardisplay("Chargement r�ussi de " & nbProfils & " profil(s)", False)
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
        'Dim oAgentList As AgentList
        'oAgentList = AgentManager.getAgentList()
        'login_profil.Items.Clear()
        'For Each curAgent As Agent In oAgentList.items
        '    ' On ajoute le profil � la liste d�roulante
        '    Dim libelleAccount As String = curAgent.nom & " " & curAgent.prenom
        '    libelleAccount = libelleAccount & "(" & curAgent.NomStructure & ")"
        '    Dim objComboItem As New objComboItem(curAgent.numeroNational, libelleAccount)
        '    login_profil.Items.Add(objComboItem)
        'Next

    End Sub

    ' Connexion a son profil
    Private Sub login_password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles login_password.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            doLogin()
        End If
    End Sub
    Private Sub btn_login_seConnecter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login_seConnecter.Click
        doLogin()
    End Sub


    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Application.Exit()
    End Sub





End Class
