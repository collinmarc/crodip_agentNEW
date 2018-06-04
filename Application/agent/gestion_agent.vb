Public Class gestion_agent
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
    Friend WithEvents panel_clientele_ficheClient_fichePulve As System.Windows.Forms.Panel
    Friend WithEvents grp_fichePulve_classe As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_fichePulve_idCrodip As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ficheAgent_numeroNational As System.Windows.Forms.TextBox
    Friend WithEvents ficheAgent_prenom As System.Windows.Forms.TextBox
    Friend WithEvents ficheAgent_nom As System.Windows.Forms.TextBox
    Friend WithEvents ficheAgent_telephonePortable As System.Windows.Forms.TextBox
    Friend WithEvents ficheAgent_email As System.Windows.Forms.TextBox
    Friend WithEvents btn_ficheInspecteur_annuler As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestion_agent))
        Me.panel_clientele_ficheClient_fichePulve = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grp_fichePulve_classe = New System.Windows.Forms.GroupBox()
        Me.ficheAgent_prenom = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ficheAgent_nom = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ficheAgent_telephonePortable = New System.Windows.Forms.TextBox()
        Me.ficheAgent_email = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ficheAgent_numeroNational = New System.Windows.Forms.TextBox()
        Me.lbl_fichePulve_idCrodip = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_ficheInspecteur_annuler = New System.Windows.Forms.Label()
        Me.panel_clientele_ficheClient_fichePulve.SuspendLayout()
        Me.grp_fichePulve_classe.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_clientele_ficheClient_fichePulve
        '
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.Label10)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.grp_fichePulve_classe)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.ficheAgent_numeroNational)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.lbl_fichePulve_idCrodip)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.Label1)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.btn_ficheInspecteur_annuler)
        Me.panel_clientele_ficheClient_fichePulve.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_clientele_ficheClient_fichePulve.Location = New System.Drawing.Point(0, 0)
        Me.panel_clientele_ficheClient_fichePulve.Name = "panel_clientele_ficheClient_fichePulve"
        Me.panel_clientele_ficheClient_fichePulve.Size = New System.Drawing.Size(536, 288)
        Me.panel_clientele_ficheClient_fichePulve.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(312, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(208, 48)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Pour tout changement de coordonnées, contactez l’organisme CRODIP"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_fichePulve_classe
        '
        Me.grp_fichePulve_classe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_fichePulve_classe.Controls.Add(Me.ficheAgent_prenom)
        Me.grp_fichePulve_classe.Controls.Add(Me.Label16)
        Me.grp_fichePulve_classe.Controls.Add(Me.ficheAgent_nom)
        Me.grp_fichePulve_classe.Controls.Add(Me.Label15)
        Me.grp_fichePulve_classe.Controls.Add(Me.Label9)
        Me.grp_fichePulve_classe.Controls.Add(Me.ficheAgent_telephonePortable)
        Me.grp_fichePulve_classe.Controls.Add(Me.ficheAgent_email)
        Me.grp_fichePulve_classe.Controls.Add(Me.Label11)
        Me.grp_fichePulve_classe.Controls.Add(Me.Label2)
        Me.grp_fichePulve_classe.Controls.Add(Me.TextBox1)
        Me.grp_fichePulve_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_fichePulve_classe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.grp_fichePulve_classe.Location = New System.Drawing.Point(8, 80)
        Me.grp_fichePulve_classe.Name = "grp_fichePulve_classe"
        Me.grp_fichePulve_classe.Size = New System.Drawing.Size(520, 152)
        Me.grp_fichePulve_classe.TabIndex = 11
        Me.grp_fichePulve_classe.TabStop = False
        Me.grp_fichePulve_classe.Text = "Inspecteur"
        '
        'ficheAgent_prenom
        '
        Me.ficheAgent_prenom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheAgent_prenom.Location = New System.Drawing.Point(353, 24)
        Me.ficheAgent_prenom.Name = "ficheAgent_prenom"
        Me.ficheAgent_prenom.ReadOnly = True
        Me.ficheAgent_prenom.Size = New System.Drawing.Size(144, 20)
        Me.ficheAgent_prenom.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(265, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 16)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Prénom :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheAgent_nom
        '
        Me.ficheAgent_nom.Location = New System.Drawing.Point(105, 24)
        Me.ficheAgent_nom.Name = "ficheAgent_nom"
        Me.ficheAgent_nom.ReadOnly = True
        Me.ficheAgent_nom.Size = New System.Drawing.Size(144, 20)
        Me.ficheAgent_nom.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(49, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Nom :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(8, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Tel. fixe et/ou portable :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheAgent_telephonePortable
        '
        Me.ficheAgent_telephonePortable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheAgent_telephonePortable.Location = New System.Drawing.Point(168, 120)
        Me.ficheAgent_telephonePortable.Name = "ficheAgent_telephonePortable"
        Me.ficheAgent_telephonePortable.ReadOnly = True
        Me.ficheAgent_telephonePortable.Size = New System.Drawing.Size(328, 20)
        Me.ficheAgent_telephonePortable.TabIndex = 20
        '
        'ficheAgent_email
        '
        Me.ficheAgent_email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheAgent_email.Location = New System.Drawing.Point(104, 88)
        Me.ficheAgent_email.Name = "ficheAgent_email"
        Me.ficheAgent_email.ReadOnly = True
        Me.ficheAgent_email.Size = New System.Drawing.Size(392, 20)
        Me.ficheAgent_email.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(24, 88)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "E-mail :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(56, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Niveau de qualification :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(200, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(296, 20)
        Me.TextBox1.TabIndex = 14
        '
        'ficheAgent_numeroNational
        '
        Me.ficheAgent_numeroNational.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheAgent_numeroNational.Location = New System.Drawing.Point(144, 46)
        Me.ficheAgent_numeroNational.Name = "ficheAgent_numeroNational"
        Me.ficheAgent_numeroNational.ReadOnly = True
        Me.ficheAgent_numeroNational.Size = New System.Drawing.Size(144, 20)
        Me.ficheAgent_numeroNational.TabIndex = 4
        '
        'lbl_fichePulve_idCrodip
        '
        Me.lbl_fichePulve_idCrodip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fichePulve_idCrodip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lbl_fichePulve_idCrodip.Location = New System.Drawing.Point(8, 48)
        Me.lbl_fichePulve_idCrodip.Name = "lbl_fichePulve_idCrodip"
        Me.lbl_fichePulve_idCrodip.Size = New System.Drawing.Size(128, 16)
        Me.lbl_fichePulve_idCrodip.TabIndex = 3
        Me.lbl_fichePulve_idCrodip.Text = "N° identifiant CRODIP :"
        Me.lbl_fichePulve_idCrodip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "     Coordonnées de l’inspecteur"
        '
        'btn_ficheInspecteur_annuler
        '
        Me.btn_ficheInspecteur_annuler.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ficheInspecteur_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheInspecteur_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheInspecteur_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_ficheInspecteur_annuler.Image = CType(resources.GetObject("btn_ficheInspecteur_annuler.Image"), System.Drawing.Image)
        Me.btn_ficheInspecteur_annuler.Location = New System.Drawing.Point(204, 248)
        Me.btn_ficheInspecteur_annuler.Name = "btn_ficheInspecteur_annuler"
        Me.btn_ficheInspecteur_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheInspecteur_annuler.TabIndex = 27
        Me.btn_ficheInspecteur_annuler.Text = "    Fermer"
        Me.btn_ficheInspecteur_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestion_agent
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 288)
        Me.Controls.Add(Me.panel_clientele_ficheClient_fichePulve)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "gestion_agent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Coordonnées de l’inspecteur"
        Me.TopMost = True
        Me.panel_clientele_ficheClient_fichePulve.ResumeLayout(False)
        Me.panel_clientele_ficheClient_fichePulve.PerformLayout()
        Me.grp_fichePulve_classe.ResumeLayout(False)
        Me.grp_fichePulve_classe.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub gestion_agent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' On charge les infos de l'agent
        ficheAgent_numeroNational.Text = agentCourant.numeroNational
        ficheAgent_nom.Text = agentCourant.nom
        ficheAgent_prenom.Text = agentCourant.prenom
        ficheAgent_telephonePortable.Text = agentCourant.telephonePortable
        ficheAgent_email.Text = agentCourant.eMail
    End Sub

#Region "controls de saisie"

    Private Sub ficheAgent_telephonePortable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheAgent_telephonePortable.KeyPress
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 10)
        End If
    End Sub

#End Region

    ' Annulation
    Private Sub btn_ficheInspecteur_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheInspecteur_annuler.Click
        Statusbar.clear()
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

    ' Validation
    Private Sub btn_ficheInspecteur_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Statusbar.display(Globals.CONST_STATUTMSG_FICHEAGENT_ENCOURS, True)
        Try
            ' On enregistre les données de l'agent
            agentCourant.numeroNational = ficheAgent_numeroNational.Text
            agentCourant.nom = ficheAgent_nom.Text
            agentCourant.prenom = ficheAgent_prenom.Text
            agentCourant.telephonePortable = ficheAgent_telephonePortable.Text
            agentCourant.eMail = ficheAgent_email.Text
            ' On met à jour en base
            AgentManager.save(agentCourant)

            ' On enregistre les données SMTP
            'globalConfig.createRoot("root")
            'globalConfig.addElement("/root", "smtp", 0)
            'globalConfig.addElement("/root/smtp", "smtpHost", agent_smtp_host.Text)
            'globalConfig.addElement("/root/smtp", "smtpPort", agent_smtp_port.Text)
            'globalConfig.addElement("/root/smtp", "smtpUser", agent_smtp_user.Text)
            'globalConfig.addElement("/root/smtp", "smtpPass", agent_smtp_pass.Text)
            Statusbar.display(Globals.CONST_STATUTMSG_FICHEAGENT_OK, False)

            ' On ferme le formulaire
            Me.Close()
        Catch ex As Exception
            Statusbar.display(Globals.CONST_STATUTMSG_FICHEAGENT_FAILED, False)
        End Try
    End Sub
End Class
