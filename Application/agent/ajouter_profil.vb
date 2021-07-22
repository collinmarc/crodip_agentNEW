Public Class ajouter_profil
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picto_profil As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents formLogin As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents addProfil_password As System.Windows.Forms.TextBox
    Friend WithEvents addProfil_identifiant As System.Windows.Forms.TextBox
    Friend WithEvents btn_ajouterProfil_seConnecter As System.Windows.Forms.Label
    Friend WithEvents btn_ajouterProfil_retour As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ajouter_profil))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_ajouterProfil_retour = New System.Windows.Forms.Label
        Me.addProfil_identifiant = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.picto_profil = New System.Windows.Forms.PictureBox
        Me.addProfil_password = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_ajouterProfil_seConnecter = New System.Windows.Forms.Label
        Me.formLogin = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.formLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.btn_ajouterProfil_retour)
        Me.Panel1.Controls.Add(Me.addProfil_identifiant)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.picto_profil)
        Me.Panel1.Controls.Add(Me.addProfil_password)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btn_ajouterProfil_seConnecter)
        Me.Panel1.Location = New System.Drawing.Point(-3, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1011, 616)
        Me.Panel1.TabIndex = 1
        '
        'btn_ajouterProfil_retour
        '
        Me.btn_ajouterProfil_retour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ajouterProfil_retour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ajouterProfil_retour.ForeColor = System.Drawing.Color.White
        Me.btn_ajouterProfil_retour.Image = CType(resources.GetObject("btn_ajouterProfil_retour.Image"), System.Drawing.Image)
        Me.btn_ajouterProfil_retour.Location = New System.Drawing.Point(680, 312)
        Me.btn_ajouterProfil_retour.Name = "btn_ajouterProfil_retour"
        Me.btn_ajouterProfil_retour.Size = New System.Drawing.Size(128, 24)
        Me.btn_ajouterProfil_retour.TabIndex = 26
        Me.btn_ajouterProfil_retour.Text = "    Retour"
        Me.btn_ajouterProfil_retour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'addProfil_identifiant
        '
        Me.addProfil_identifiant.Location = New System.Drawing.Point(560, 224)
        Me.addProfil_identifiant.Name = "addProfil_identifiant"
        Me.addProfil_identifiant.Size = New System.Drawing.Size(240, 20)
        Me.addProfil_identifiant.TabIndex = 9
        Me.addProfil_identifiant.Text = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(304, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Nouveau profil"
        '
        'picto_profil
        '
        Me.picto_profil.BackgroundImage = CType(resources.GetObject("picto_profil.BackgroundImage"), System.Drawing.Image)
        Me.picto_profil.Location = New System.Drawing.Point(312, 216)
        Me.picto_profil.Name = "picto_profil"
        Me.picto_profil.Size = New System.Drawing.Size(116, 164)
        Me.picto_profil.TabIndex = 7
        Me.picto_profil.TabStop = False
        '
        'addProfil_password
        '
        Me.addProfil_password.Location = New System.Drawing.Point(560, 272)
        Me.addProfil_password.Name = "addProfil_password"
        Me.addProfil_password.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.addProfil_password.Size = New System.Drawing.Size(240, 20)
        Me.addProfil_password.TabIndex = 4
        Me.addProfil_password.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(456, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Mot de passe :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(472, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Identifiant :"
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
        Me.Label3.Size = New System.Drawing.Size(552, 32)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "        Pour activer un nouveau profil, veuillez saisir les identifiants qui vous" & _
        " ont été communiqués par le CRODIP. Vous devez être connecté à Internet pour réa" & _
        "liser cette opération."
        '
        'btn_ajouterProfil_seConnecter
        '
        Me.btn_ajouterProfil_seConnecter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ajouterProfil_seConnecter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ajouterProfil_seConnecter.ForeColor = System.Drawing.Color.White
        Me.btn_ajouterProfil_seConnecter.Image = CType(resources.GetObject("btn_ajouterProfil_seConnecter.Image"), System.Drawing.Image)
        Me.btn_ajouterProfil_seConnecter.Location = New System.Drawing.Point(544, 312)
        Me.btn_ajouterProfil_seConnecter.Name = "btn_ajouterProfil_seConnecter"
        Me.btn_ajouterProfil_seConnecter.Size = New System.Drawing.Size(128, 24)
        Me.btn_ajouterProfil_seConnecter.TabIndex = 25
        Me.btn_ajouterProfil_seConnecter.Text = "       Se connecter"
        Me.btn_ajouterProfil_seConnecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'formLogin
        '
        Me.formLogin.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
        Me.formLogin.Controls.Add(Me.Label2)
        Me.formLogin.Controls.Add(Me.Label1)
        Me.formLogin.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(123, Byte), CType(193, Byte))
        Me.formLogin.Location = New System.Drawing.Point(1, 0)
        Me.formLogin.Name = "formLogin"
        Me.formLogin.Size = New System.Drawing.Size(1008, 64)
        Me.formLogin.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(123, Byte), CType(191, Byte))
        Me.Label2.Location = New System.Drawing.Point(472, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CRODIP"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(123, Byte), CType(191, Byte))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(400, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "        Banc de mesure de débits informatisés"
        '
        'ajouter_profil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.Controls.Add(Me.formLogin)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ajouter_profil"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip"
        Me.Panel1.ResumeLayout(False)
        Me.formLogin.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Se Connecter
    Private Sub btn_ajouterProfil_seConnecter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ajouterProfil_seConnecter.Click
        Dim objAgent As New Agent
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_ENCOURS, True)
        If CSEnvironnement.checkNetwork() = True Then
            If addProfil_identifiant.Text <> "" And addProfil_password.Text <> "" Then
                Try
                    ' on récupère notre agent via WS
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_LINK_ENCOURS, True)
                    objAgent = AgentManager.getWSAgentById(addProfil_identifiant.Text)
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_LOAD_ENCOURS, True)
                    If objAgent.numeroNational <> "" Then
                        ' Ok, profil trouvé et chargé. On vérifie le password
                        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_VERIF_ENCOURS, True)
                        If objAgent.motDePasse = CSCrypt.encode(addProfil_password.Text, "sha256") Then
                            ' On vérifie que l'agent n'existe pas déjà en base
                            Dim existsAgent As Agent
                            existsAgent = AgentManager.getAgentByNumeroNational(objAgent.numeroNational)
                            If existsAgent.numeroNational = "" Then
                                ' Création d'un agent avec l'Id et le numéro national
                                AgentManager.createAgent(objAgent.id, objAgent.numeroNational, "Nouveau", 0)
                                objAgent.dateDerniereSynchro = "01/01/1970"
                                'Update de cet agent avec l'agent recu pas WS
                                AgentManager.save(objAgent)
                                MsgBox("Un nouvel inspecteur vient d'être ajouté. Rendez-vous sur l'écran de connexion pour vous authentifier.")
                                Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_OK, False)
                            Else
                                Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_ERROR_EXISTS, False)
                                MsgBox("Erreur: Cet inspecteur est déjà présent en base." & existsAgent.numeroNational)
                            End If
                        Else
                            Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_ERROR_PASSNOTMATCH, False)
                            MsgBox("Erreur: Les mots de passe ne correspondent pas.")
                        End If
                    Else
                        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_ERROR_NOPROFIL, False)
                        MsgBox("Aucun profil trouvé pour l'identifiant : " & addProfil_identifiant.Text)
                    End If
                Catch ex As Exception
                    Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_ERROR_NOPROFIL, False)
                    MsgBox("Erreur: Aucun profil trouvé pour l'identifiant : " & addProfil_identifiant.Text)
                End Try
            End If
        Else
            Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_ADDAGENT_ERROR_NOTCONNECT, False)
            MsgBox("Erreur: Vous devez être connecté à internet pour ajouter un nouveau profil.")
        End If
    End Sub

    ' Retours
    Private Sub btn_ajouterProfil_retour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ajouterProfil_retour.Click
        ' On récupère le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent
        Dim formLogin As New login
        formLogin.MdiParent = Me.MdiParent
        Statusbar.clear()
        formLogin.Show()
        Me.Hide()
    End Sub

End Class
