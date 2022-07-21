
Public Class gestion_bancs
    Inherits frmCRODIP

    Private m_arrBanc As System.Collections.Generic.List(Of Banc)
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
    Friend WithEvents Panel64 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents pnlFondBleu As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel68 As System.Windows.Forms.Panel
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gestionBanc_panel_dateAchat As System.Windows.Forms.Panel
    Friend WithEvents gestionBanc_panel_modele As System.Windows.Forms.Panel
    Friend WithEvents gestionBanc_panel_marque As System.Windows.Forms.Panel
    Friend WithEvents gestionBanc_panel_id As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents gestionBanc_panel_showFV As System.Windows.Forms.Panel
    Friend WithEvents imagesPictos As System.Windows.Forms.ImageList
    Friend WithEvents ToolTipShowFichevie As System.Windows.Forms.ToolTip
    Friend WithEvents btn_gestionBanc_valider As System.Windows.Forms.Label
    Friend WithEvents Panel67 As System.Windows.Forms.Panel
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents gestionBanc_panel_etat As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderHisto As Panel
    Friend WithEvents lblHisto As Label
    Friend WithEvents pnlHisto As Panel
    Friend WithEvents imagesEtatMateriel As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestion_bancs))
        Me.Panel64 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.pnlFondBleu = New System.Windows.Forms.Panel()
        Me.Panel67 = New System.Windows.Forms.Panel()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.gestionBanc_panel_etat = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.gestionBanc_panel_showFV = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gestionBanc_panel_dateAchat = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gestionBanc_panel_modele = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gestionBanc_panel_marque = New System.Windows.Forms.Panel()
        Me.Panel68 = New System.Windows.Forms.Panel()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.gestionBanc_panel_id = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_gestionBanc_valider = New System.Windows.Forms.Label()
        Me.imagesPictos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTipShowFichevie = New System.Windows.Forms.ToolTip(Me.components)
        Me.imagesEtatMateriel = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlHeaderHisto = New System.Windows.Forms.Panel()
        Me.lblHisto = New System.Windows.Forms.Label()
        Me.pnlHisto = New System.Windows.Forms.Panel()
        Me.Panel64.SuspendLayout()
        Me.pnlFondBleu.SuspendLayout()
        Me.Panel67.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel68.SuspendLayout()
        Me.pnlHeaderHisto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel64
        '
        Me.Panel64.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel64.Controls.Add(Me.pnlHeaderHisto)
        Me.Panel64.Controls.Add(Me.Panel13)
        Me.Panel64.Controls.Add(Me.pnlFondBleu)
        Me.Panel64.Controls.Add(Me.Label7)
        Me.Panel64.Controls.Add(Me.btn_gestionBanc_valider)
        Me.Panel64.Location = New System.Drawing.Point(0, -1)
        Me.Panel64.Name = "Panel64"
        Me.Panel64.Size = New System.Drawing.Size(1025, 680)
        Me.Panel64.TabIndex = 20
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel13.Location = New System.Drawing.Point(8, 602)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(992, 3)
        Me.Panel13.TabIndex = 18
        '
        'pnlFondBleu
        '
        Me.pnlFondBleu.AutoScroll = True
        Me.pnlFondBleu.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.pnlFondBleu.Controls.Add(Me.pnlHisto)
        Me.pnlFondBleu.Controls.Add(Me.Panel67)
        Me.pnlFondBleu.Controls.Add(Me.gestionBanc_panel_etat)
        Me.pnlFondBleu.Controls.Add(Me.Panel6)
        Me.pnlFondBleu.Controls.Add(Me.gestionBanc_panel_showFV)
        Me.pnlFondBleu.Controls.Add(Me.Panel5)
        Me.pnlFondBleu.Controls.Add(Me.gestionBanc_panel_dateAchat)
        Me.pnlFondBleu.Controls.Add(Me.Panel3)
        Me.pnlFondBleu.Controls.Add(Me.gestionBanc_panel_modele)
        Me.pnlFondBleu.Controls.Add(Me.Panel1)
        Me.pnlFondBleu.Controls.Add(Me.gestionBanc_panel_marque)
        Me.pnlFondBleu.Controls.Add(Me.Panel68)
        Me.pnlFondBleu.Controls.Add(Me.gestionBanc_panel_id)
        Me.pnlFondBleu.Location = New System.Drawing.Point(100, 48)
        Me.pnlFondBleu.Name = "pnlFondBleu"
        Me.pnlFondBleu.Size = New System.Drawing.Size(900, 528)
        Me.pnlFondBleu.TabIndex = 10
        '
        'Panel67
        '
        Me.Panel67.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel67.Controls.Add(Me.Label80)
        Me.Panel67.Location = New System.Drawing.Point(721, 0)
        Me.Panel67.Name = "Panel67"
        Me.Panel67.Size = New System.Drawing.Size(88, 40)
        Me.Panel67.TabIndex = 38
        '
        'Label80
        '
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label80.Location = New System.Drawing.Point(8, 8)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(71, 24)
        Me.Label80.TabIndex = 8
        Me.Label80.Text = "Etat après vérification"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionBanc_panel_etat
        '
        Me.gestionBanc_panel_etat.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBanc_panel_etat.Location = New System.Drawing.Point(721, 41)
        Me.gestionBanc_panel_etat.Name = "gestionBanc_panel_etat"
        Me.gestionBanc_panel_etat.Size = New System.Drawing.Size(88, 487)
        Me.gestionBanc_panel_etat.TabIndex = 37
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(30, 40)
        Me.Panel6.TabIndex = 36
        '
        'gestionBanc_panel_showFV
        '
        Me.gestionBanc_panel_showFV.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBanc_panel_showFV.Location = New System.Drawing.Point(0, 41)
        Me.gestionBanc_panel_showFV.Name = "gestionBanc_panel_showFV"
        Me.gestionBanc_panel_showFV.Size = New System.Drawing.Size(30, 487)
        Me.gestionBanc_panel_showFV.TabIndex = 35
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(505, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(215, 40)
        Me.Panel5.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Date d'achat / Auto-construction"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionBanc_panel_dateAchat
        '
        Me.gestionBanc_panel_dateAchat.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBanc_panel_dateAchat.Location = New System.Drawing.Point(505, 41)
        Me.gestionBanc_panel_dateAchat.Name = "gestionBanc_panel_dateAchat"
        Me.gestionBanc_panel_dateAchat.Size = New System.Drawing.Size(215, 487)
        Me.gestionBanc_panel_dateAchat.TabIndex = 26
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(313, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(191, 40)
        Me.Panel3.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Modèle"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionBanc_panel_modele
        '
        Me.gestionBanc_panel_modele.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBanc_panel_modele.Location = New System.Drawing.Point(313, 41)
        Me.gestionBanc_panel_modele.Name = "gestionBanc_panel_modele"
        Me.gestionBanc_panel_modele.Size = New System.Drawing.Size(191, 487)
        Me.gestionBanc_panel_modele.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(121, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(191, 40)
        Me.Panel1.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Marque"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionBanc_panel_marque
        '
        Me.gestionBanc_panel_marque.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBanc_panel_marque.Location = New System.Drawing.Point(121, 41)
        Me.gestionBanc_panel_marque.Name = "gestionBanc_panel_marque"
        Me.gestionBanc_panel_marque.Size = New System.Drawing.Size(191, 487)
        Me.gestionBanc_panel_marque.TabIndex = 22
        '
        'Panel68
        '
        Me.Panel68.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel68.Controls.Add(Me.Label81)
        Me.Panel68.Location = New System.Drawing.Point(31, 0)
        Me.Panel68.Name = "Panel68"
        Me.Panel68.Size = New System.Drawing.Size(89, 40)
        Me.Panel68.TabIndex = 19
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label81.Location = New System.Drawing.Point(8, 8)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(72, 24)
        Me.Label81.TabIndex = 6
        Me.Label81.Text = "N° identifiant banc"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionBanc_panel_id
        '
        Me.gestionBanc_panel_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBanc_panel_id.Location = New System.Drawing.Point(31, 41)
        Me.gestionBanc_panel_id.Name = "gestionBanc_panel_id"
        Me.gestionBanc_panel_id.Size = New System.Drawing.Size(89, 487)
        Me.gestionBanc_panel_id.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(8, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(288, 25)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "     Gestion des bancs"
        '
        'btn_gestionBanc_valider
        '
        Me.btn_gestionBanc_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionBanc_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionBanc_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionBanc_valider.Image = CType(resources.GetObject("btn_gestionBanc_valider.Image"), System.Drawing.Image)
        Me.btn_gestionBanc_valider.Location = New System.Drawing.Point(872, 632)
        Me.btn_gestionBanc_valider.Name = "btn_gestionBanc_valider"
        Me.btn_gestionBanc_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionBanc_valider.TabIndex = 28
        Me.btn_gestionBanc_valider.Text = "    Valider / Quitter"
        Me.btn_gestionBanc_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imagesPictos
        '
        Me.imagesPictos.ImageStream = CType(resources.GetObject("imagesPictos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesPictos.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesPictos.Images.SetKeyName(0, "")
        Me.imagesPictos.Images.SetKeyName(1, "")
        Me.imagesPictos.Images.SetKeyName(2, "eyeSupprime.png")
        Me.imagesPictos.Images.SetKeyName(3, "PDF.png")
        '
        'imagesEtatMateriel
        '
        Me.imagesEtatMateriel.ImageStream = CType(resources.GetObject("imagesEtatMateriel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesEtatMateriel.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesEtatMateriel.Images.SetKeyName(0, "")
        Me.imagesEtatMateriel.Images.SetKeyName(1, "")
        Me.imagesEtatMateriel.Images.SetKeyName(2, "g.jpg")
        '
        'pnlHeaderHisto
        '
        Me.pnlHeaderHisto.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.pnlHeaderHisto.Controls.Add(Me.lblHisto)
        Me.pnlHeaderHisto.Location = New System.Drawing.Point(910, 48)
        Me.pnlHeaderHisto.Name = "pnlHeaderHisto"
        Me.pnlHeaderHisto.Size = New System.Drawing.Size(88, 40)
        Me.pnlHeaderHisto.TabIndex = 39
        '
        'lblHisto
        '
        Me.lblHisto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHisto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblHisto.Location = New System.Drawing.Point(8, 8)
        Me.lblHisto.Name = "lblHisto"
        Me.lblHisto.Size = New System.Drawing.Size(72, 24)
        Me.lblHisto.TabIndex = 8
        Me.lblHisto.Text = "Historique"
        Me.lblHisto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlHisto
        '
        Me.pnlHisto.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.pnlHisto.Location = New System.Drawing.Point(810, 41)
        Me.pnlHisto.Name = "pnlHisto"
        Me.pnlHisto.Size = New System.Drawing.Size(88, 487)
        Me.pnlHisto.TabIndex = 39
        '
        'gestion_bancs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1025, 679)
        Me.Controls.Add(Me.Panel64)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gestion_bancs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des bancs"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel64.ResumeLayout(False)
        Me.pnlFondBleu.ResumeLayout(False)
        Me.Panel67.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel68.ResumeLayout(False)
        Me.pnlHeaderHisto.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Boutons communs "

    ' Validation
    Private Sub btn_gestionBanc_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionBanc_valider.Click
        TryCast(MdiParent, parentContener).ReturnToAccueil()

    End Sub

#End Region

    Private Sub gestion_bancs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Sauvegarde des controles de base

        Dim arrMarquesControls(0) As ComboBox
        Dim arrModelesControls(0) As ComboBox

        DisplayListe()
        '#################################################################################
        '########                   Chargement des marques,etc...                 ########
        '#################################################################################
        'MarquesManager.populateCombobox(GlobalsCRODIP.GLOB_XML_MARQUES_BANC, arrMarquesControls)
        'MarquesManager.populateCombobox(GlobalsCRODIP.GLOB_XML_MODELES_BANC, arrModelesControls)
    End Sub

    Private Function DisplayListe() As Boolean
        Dim bReturn As Boolean
        Try
            gestionBanc_panel_showFV.Controls.Clear()
            gestionBanc_panel_id.Controls.Clear()
            gestionBanc_panel_marque.Controls.Clear()
            gestionBanc_panel_modele.Controls.Clear()
            gestionBanc_panel_dateAchat.Controls.Clear()
            gestionBanc_panel_etat.Controls.Clear()

            ' On récupère les bancs de l'agent
            If BancCourant Is Nothing Then
                m_arrBanc = BancManager.getBancByAgent(agentCourant, True)
                'Ajout des banc Jamais Servi
                m_arrBanc.AddRange(BancManager.getBancByStructureIdJamaisServi(agentCourant.idStructure))
            Else
                m_arrBanc = New Generic.List(Of Banc)
                m_arrBanc.Add(BancCourant)
            End If
            ' Création des contrôles a la volée
            Dim positionTop As Integer = 0
            For Each tmpBanc As Banc In m_arrBanc

                If positionTop = 0 Then
                    positionTop = 8
                Else
                    positionTop = positionTop + 24
                End If

                '## Show FV
                Dim tmpShowFV As New PictureBox
                tmpShowFV.Name = "banc_" & tmpBanc.id & "_showFV"
                tmpShowFV.Image = imagesPictos.Images(0)
                Controls.Add(tmpShowFV)
                tmpShowFV.Parent = gestionBanc_panel_showFV
                tmpShowFV.Width = 16
                tmpShowFV.Height = 16
                tmpShowFV.Left = 8
                tmpShowFV.Top = positionTop
                AddHandler tmpShowFV.Click, AddressOf EditBanc
                AddHandler tmpShowFV.MouseHover, AddressOf setCursorHand
                AddHandler tmpShowFV.MouseLeave, AddressOf setCursorDefault
                ToolTipShowFichevie.SetToolTip(tmpShowFV, "Voir la fiche de ce banc de mesure.")
                ToolTipShowFichevie.Active = True

                '## Le label
                Dim tmpLabel As New Label
                tmpLabel.Name = "banc_" & tmpBanc.id & "_id"
                tmpLabel.Text = tmpBanc.id
                Controls.Add(tmpLabel)
                ' Position
                tmpLabel.Parent = gestionBanc_panel_id
                tmpLabel.Left = 8
                tmpLabel.Top = positionTop
                ' Taille
                tmpLabel.Width = 72
                ' Apparence
                tmpLabel.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## La marque
                Dim tmpMarque As New Label
                tmpMarque.Name = "banc_" & tmpBanc.id & "_marque"
                tmpMarque.Text = tmpBanc.marque
                Controls.Add(tmpMarque)
                'arrMarquesControls(arrMarquesControls.Length - 1) = tmpMarque
                'ReDim Preserve arrMarquesControls(arrMarquesControls.Length)
                ' Position
                tmpMarque.Parent = gestionBanc_panel_marque
                tmpMarque.Left = 8
                tmpMarque.Top = positionTop
                ' Taille
                tmpMarque.Width = 176
                ' Apparence
                tmpMarque.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpMarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Le modele
                Dim tmpModele As New Label
                tmpModele.Name = "banc_" & tmpBanc.id & "_modele"
                tmpModele.Text = tmpBanc.modele
                Controls.Add(tmpModele)
                'arrModelesControls(arrModelesControls.Length - 1) = tmpModele
                'ReDim Preserve arrModelesControls(arrModelesControls.Length)
                ' Position
                tmpModele.Parent = gestionBanc_panel_modele
                tmpModele.Left = 8
                tmpModele.Top = positionTop
                ' Taille
                tmpModele.Width = 176
                ' Apparence
                tmpModele.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpModele.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## La date
                Dim tmpDateAchat As New Label
                tmpDateAchat.Name = "banc_" & tmpBanc.id & "_dateAchat"
                If Not String.IsNullOrEmpty(tmpBanc.dateAchat) Then
                    tmpDateAchat.Text = CDate(tmpBanc.dateAchat).ToString("dd/MM/yyyy")
                End If
                Controls.Add(tmpDateAchat)
                ' Position
                tmpDateAchat.Parent = gestionBanc_panel_dateAchat
                tmpDateAchat.Left = 8
                tmpDateAchat.Top = positionTop
                ' Taille
                tmpDateAchat.Width = 200
                ' Apparence
                tmpDateAchat.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpDateAchat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Etat
                Dim tmpState As New PictureBox
                tmpState.Name = "banc_" & tmpBanc.id & "_etat"
                'tmpState.Image = imagesEtatMateriel.Images(1)
                If tmpBanc.jamaisServi Then
                    tmpState.Image = imagesEtatMateriel.Images(2) 'Gris
                Else
                    If tmpBanc.etat Then
                        tmpState.Image = imagesEtatMateriel.Images(1) 'Vert
                    Else
                        tmpState.Image = imagesEtatMateriel.Images(0) 'Rouge
                    End If
                End If
                Controls.Add(tmpState)
                tmpState.Parent = gestionBanc_panel_etat
                tmpState.Width = 16
                tmpState.Height = 16
                tmpState.Left = 36
                tmpState.Top = positionTop

                '## Show FV
                Dim tmpShowHisto As New PictureBox
                tmpShowHisto.Name = "banc_" & tmpBanc.id & "_showHisto"
                tmpShowHisto.Image = imagesPictos.Images(3)
                Controls.Add(tmpShowHisto)
                tmpShowHisto.Parent = pnlHisto
                tmpShowHisto.Width = 16
                tmpShowHisto.Height = 16
                tmpShowHisto.Left = 36
                tmpShowHisto.Top = positionTop
                AddHandler tmpShowHisto.Click, AddressOf HistoBanc
                AddHandler tmpShowHisto.MouseHover, AddressOf setCursorHand
                AddHandler tmpShowHisto.MouseLeave, AddressOf setCursorDefault
                ToolTipShowFichevie.SetToolTip(tmpShowHisto, "Voir l'historique de vérification de ce banc de mesure.")
                ToolTipShowFichevie.Active = True

            Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Gestion_bancs.DisplayListe Error" + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Sub EditBanc(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim bancId As String = sender.name.ToString.Replace("banc_", "").Replace("_showFV", "")
            Dim formFicheBanc As New fiche_banc(BancManager.getBancById(bancId))
            '            formFicheBanc.MdiParent = Me.MdiParent
            '            formFicheBanc.setSendersForm(Me)
            If formFicheBanc.ShowDialog(Me) <> Windows.Forms.DialogResult.Cancel Then
                DisplayListe()
            End If
        Catch ex As Exception
            CSDebug.dispError("Gestion_banc.EditBanc ERR : " & ex.Message)
        End Try
    End Sub
    Private Sub HistoBanc(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim bancId As String = sender.name.ToString.Replace("banc_", "").Replace("_showHisto", "")
            Dim frmHistoBanc As New HistoBanc(BancManager.getBancById(bancId))
            '            formFicheBanc.MdiParent = Me.MdiParent
            '            formFicheBanc.setSendersForm(Me)
            If frmHistoBanc.ShowDialog(Me) <> Windows.Forms.DialogResult.Cancel Then
                DisplayListe()
            End If
        Catch ex As Exception
            CSDebug.dispError("Gestion_banc.HistoBanc ERR : " & ex.Message)
        End Try
    End Sub
    Private Sub setCursorHand(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.Hand
        Catch ex As Exception
            CSDebug.dispError("Gestion_banc.EditBanc ERR : " & ex.Message)
        End Try
    End Sub
    Private Sub setCursorDefault(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            CSDebug.dispError("Gestion_banc.EditBanc ERR : " & ex.Message)
        End Try
    End Sub

End Class
