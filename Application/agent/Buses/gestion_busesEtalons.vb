Imports System.Collections.Generic
Imports CRODIPWS

Public Class gestion_busesEtalons
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
    Friend WithEvents Panel64 As System.Windows.Forms.Panel
    Friend WithEvents Panel65 As System.Windows.Forms.Panel
    Friend WithEvents Panel66 As System.Windows.Forms.Panel
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Panel68 As System.Windows.Forms.Panel
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents gestionBusesEtalon_panel_pressionControle As System.Windows.Forms.Panel
    Friend WithEvents gestionBusesEtalon_panel_debitReference As System.Windows.Forms.Panel
    Friend WithEvents gestionBusesEtalon_panel_id As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btn_gestionBuses_valider As System.Windows.Forms.Label
    Friend WithEvents gestionBusesEtalon_panel_couleur As System.Windows.Forms.Panel
    Friend WithEvents imagesEtatMateriel As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gestionBusesEtalon_panel_Etat As System.Windows.Forms.Panel
    Friend WithEvents imagesPictos As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestion_busesEtalons))
        Me.Panel64 = New System.Windows.Forms.Panel()
        Me.gestionBusesEtalon_panel_Etat = New System.Windows.Forms.Panel()
        Me.btn_gestionBuses_valider = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel65 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gestionBusesEtalon_panel_pressionControle = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gestionBusesEtalon_panel_couleur = New System.Windows.Forms.Panel()
        Me.Panel66 = New System.Windows.Forms.Panel()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Panel68 = New System.Windows.Forms.Panel()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.gestionBusesEtalon_panel_debitReference = New System.Windows.Forms.Panel()
        Me.gestionBusesEtalon_panel_id = New System.Windows.Forms.Panel()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.imagesPictos = New System.Windows.Forms.ImageList(Me.components)
        Me.imagesEtatMateriel = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel64.SuspendLayout()
        Me.Panel65.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel66.SuspendLayout()
        Me.Panel68.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel64
        '
        Me.Panel64.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel64.Controls.Add(Me.gestionBusesEtalon_panel_Etat)
        Me.Panel64.Controls.Add(Me.btn_gestionBuses_valider)
        Me.Panel64.Controls.Add(Me.Panel13)
        Me.Panel64.Controls.Add(Me.Panel65)
        Me.Panel64.Controls.Add(Me.Label82)
        Me.Panel64.Location = New System.Drawing.Point(0, 0)
        Me.Panel64.Name = "Panel64"
        Me.Panel64.Size = New System.Drawing.Size(1008, 680)
        Me.Panel64.TabIndex = 19
        '
        'gestionBusesEtalon_panel_Etat
        '
        Me.gestionBusesEtalon_panel_Etat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gestionBusesEtalon_panel_Etat.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBusesEtalon_panel_Etat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gestionBusesEtalon_panel_Etat.Location = New System.Drawing.Point(741, 89)
        Me.gestionBusesEtalon_panel_Etat.Name = "gestionBusesEtalon_panel_Etat"
        Me.gestionBusesEtalon_panel_Etat.Size = New System.Drawing.Size(116, 510)
        Me.gestionBusesEtalon_panel_Etat.TabIndex = 33
        '
        'btn_gestionBuses_valider
        '
        Me.btn_gestionBuses_valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_gestionBuses_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionBuses_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionBuses_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionBuses_valider.Image = CType(resources.GetObject("btn_gestionBuses_valider.Image"), System.Drawing.Image)
        Me.btn_gestionBuses_valider.Location = New System.Drawing.Point(872, 640)
        Me.btn_gestionBuses_valider.Name = "btn_gestionBuses_valider"
        Me.btn_gestionBuses_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionBuses_valider.TabIndex = 32
        Me.btn_gestionBuses_valider.Text = "    Valider / Quitter"
        Me.btn_gestionBuses_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel13.Location = New System.Drawing.Point(8, 609)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(987, 3)
        Me.Panel13.TabIndex = 18
        '
        'Panel65
        '
        Me.Panel65.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel65.AutoScroll = True
        Me.Panel65.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel65.Controls.Add(Me.Panel2)
        Me.Panel65.Controls.Add(Me.Panel7)
        Me.Panel65.Controls.Add(Me.gestionBusesEtalon_panel_pressionControle)
        Me.Panel65.Controls.Add(Me.Panel3)
        Me.Panel65.Controls.Add(Me.gestionBusesEtalon_panel_couleur)
        Me.Panel65.Controls.Add(Me.Panel66)
        Me.Panel65.Controls.Add(Me.Panel68)
        Me.Panel65.Controls.Add(Me.gestionBusesEtalon_panel_debitReference)
        Me.Panel65.Controls.Add(Me.gestionBusesEtalon_panel_id)
        Me.Panel65.Location = New System.Drawing.Point(269, 48)
        Me.Panel65.Name = "Panel65"
        Me.Panel65.Size = New System.Drawing.Size(588, 551)
        Me.Panel65.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(472, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(115, 40)
        Me.Panel2.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(21, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Etat"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Location = New System.Drawing.Point(233, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(117, 40)
        Me.Panel7.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Pression étalonnage"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionBusesEtalon_panel_pressionControle
        '
        Me.gestionBusesEtalon_panel_pressionControle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gestionBusesEtalon_panel_pressionControle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBusesEtalon_panel_pressionControle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gestionBusesEtalon_panel_pressionControle.Location = New System.Drawing.Point(233, 41)
        Me.gestionBusesEtalon_panel_pressionControle.Name = "gestionBusesEtalon_panel_pressionControle"
        Me.gestionBusesEtalon_panel_pressionControle.Size = New System.Drawing.Size(117, 510)
        Me.gestionBusesEtalon_panel_pressionControle.TabIndex = 28
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(89, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(143, 40)
        Me.Panel3.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Couleur"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionBusesEtalon_panel_couleur
        '
        Me.gestionBusesEtalon_panel_couleur.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gestionBusesEtalon_panel_couleur.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBusesEtalon_panel_couleur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gestionBusesEtalon_panel_couleur.Location = New System.Drawing.Point(89, 41)
        Me.gestionBusesEtalon_panel_couleur.Name = "gestionBusesEtalon_panel_couleur"
        Me.gestionBusesEtalon_panel_couleur.Size = New System.Drawing.Size(143, 510)
        Me.gestionBusesEtalon_panel_couleur.TabIndex = 24
        '
        'Panel66
        '
        Me.Panel66.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel66.Controls.Add(Me.Label79)
        Me.Panel66.Location = New System.Drawing.Point(351, 0)
        Me.Panel66.Name = "Panel66"
        Me.Panel66.Size = New System.Drawing.Size(119, 40)
        Me.Panel66.TabIndex = 21
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label79.Location = New System.Drawing.Point(21, 8)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(66, 24)
        Me.Label79.TabIndex = 9
        Me.Label79.Text = "Débit         étalonné"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel68
        '
        Me.Panel68.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel68.Controls.Add(Me.Label81)
        Me.Panel68.Location = New System.Drawing.Point(0, 0)
        Me.Panel68.Name = "Panel68"
        Me.Panel68.Size = New System.Drawing.Size(88, 40)
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
        Me.Label81.Text = "N° identifiant buse"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionBusesEtalon_panel_debitReference
        '
        Me.gestionBusesEtalon_panel_debitReference.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gestionBusesEtalon_panel_debitReference.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBusesEtalon_panel_debitReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gestionBusesEtalon_panel_debitReference.Location = New System.Drawing.Point(351, 41)
        Me.gestionBusesEtalon_panel_debitReference.Name = "gestionBusesEtalon_panel_debitReference"
        Me.gestionBusesEtalon_panel_debitReference.Size = New System.Drawing.Size(119, 510)
        Me.gestionBusesEtalon_panel_debitReference.TabIndex = 18
        '
        'gestionBusesEtalon_panel_id
        '
        Me.gestionBusesEtalon_panel_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gestionBusesEtalon_panel_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionBusesEtalon_panel_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gestionBusesEtalon_panel_id.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gestionBusesEtalon_panel_id.Location = New System.Drawing.Point(0, 41)
        Me.gestionBusesEtalon_panel_id.Name = "gestionBusesEtalon_panel_id"
        Me.gestionBusesEtalon_panel_id.Size = New System.Drawing.Size(88, 510)
        Me.gestionBusesEtalon_panel_id.TabIndex = 16
        '
        'Label82
        '
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label82.Image = CType(resources.GetObject("Label82.Image"), System.Drawing.Image)
        Me.Label82.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label82.Location = New System.Drawing.Point(8, 8)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(376, 25)
        Me.Label82.TabIndex = 4
        Me.Label82.Text = "     Gestion des buses / pastilles étalon "
        '
        'imagesPictos
        '
        Me.imagesPictos.ImageStream = CType(resources.GetObject("imagesPictos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesPictos.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesPictos.Images.SetKeyName(0, "")
        Me.imagesPictos.Images.SetKeyName(1, "")
        '
        'imagesEtatMateriel
        '
        Me.imagesEtatMateriel.ImageStream = CType(resources.GetObject("imagesEtatMateriel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesEtatMateriel.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesEtatMateriel.Images.SetKeyName(0, "")
        Me.imagesEtatMateriel.Images.SetKeyName(1, "")
        Me.imagesEtatMateriel.Images.SetKeyName(2, "g.jpg")
        '
        'gestion_busesEtalons
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.Controls.Add(Me.Panel64)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gestion_busesEtalons"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Gestion des buses étalons"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel64.ResumeLayout(False)
        Me.Panel65.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel66.ResumeLayout(False)
        Me.Panel68.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Validation
    Private Sub btn_gestionBuses_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionBuses_valider.Click
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

    Private Sub gestion_busesEtalons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DisplayListe()
    End Sub

    Private Function DisplayListe() As Boolean
        Dim bReturn As Boolean
        Try

            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(gestion_busesEtalons))
            ' On récupère les buses étalon de l'agent
            Dim arrBusesEtalon As List(Of Buse) = BuseManager.getLstByAgent(agentCourant, True)
            'arrBusesEtalon.AddRange(BuseManager.getLstByAgentJamaisServi(agentCourant))

            '            gestionBanc_panel_showFV.Controls.Clear()
            gestionBusesEtalon_panel_id.Controls.Clear()
            gestionBusesEtalon_panel_id.Controls.Clear()
            gestionBusesEtalon_panel_couleur.Controls.Clear()
            gestionBusesEtalon_panel_pressionControle.Controls.Clear()
            gestionBusesEtalon_panel_debitReference.Controls.Clear()
            gestionBusesEtalon_panel_Etat.Controls.Clear()


            ' Création des contrôles a la volée
            Dim positionTop As Integer = 0
            For Each tmpBuseEtalon As Buse In arrBusesEtalon

                If positionTop = 0 Then
                    positionTop = 8
                Else
                    positionTop = positionTop + 24
                End If

                '## Le picto "fiche"
                Dim tmpPictoFiche As New PictureBox
                tmpPictoFiche.Name = "buseEtalon_" & tmpBuseEtalon.numeroNational & "_showFiche"
                tmpPictoFiche.Tag = tmpBuseEtalon
                tmpPictoFiche.Image = imagesPictos.Images(0)
                Controls.Add(tmpPictoFiche)
                tmpPictoFiche.Parent = gestionBusesEtalon_panel_id
                tmpPictoFiche.Location = New System.Drawing.Point(4, (positionTop - 2))
                tmpPictoFiche.Size = New System.Drawing.Size(16, 16)
                AddHandler tmpPictoFiche.Click, AddressOf dispFicheBuse

                '## Le label
                Dim tmpLabel As New Label
                tmpLabel.Name = "buseEtalon_" & tmpBuseEtalon.numeroNational & "_numeroNational"
                tmpLabel.Text = tmpBuseEtalon.numeroNational
                Controls.Add(tmpLabel)
                ' Position
                tmpLabel.Parent = gestionBusesEtalon_panel_id
                tmpLabel.Left = 25
                tmpLabel.Top = positionTop
                ' Taille
                tmpLabel.Width = 54
                ' Apparence
                tmpLabel.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## La couleur
                Dim tmpCouleur As New Label
                tmpCouleur.Name = "buseEtalon_" & tmpBuseEtalon.numeroNational & "_couleur"
                tmpCouleur.Text = tmpBuseEtalon.couleur
                Controls.Add(tmpCouleur)
                'arrCouleurControls(arrCouleurControls.Length - 1) = tmpCouleur
                'ReDim Preserve arrCouleurControls(arrCouleurControls.Length)
                ' Position
                tmpCouleur.Parent = gestionBusesEtalon_panel_couleur
                tmpCouleur.Left = 8
                tmpCouleur.Top = positionTop
                ' Taille
                tmpCouleur.Width = 128
                ' Apparence
                tmpCouleur.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpCouleur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Pression controle
                Dim tmpPressionControle As New Label
                tmpPressionControle.Name = "buseEtalon_" & tmpBuseEtalon.numeroNational & "_pressionControle"
                tmpPressionControle.Text = tmpBuseEtalon.pressionEtalonnage
                Controls.Add(tmpPressionControle)
                ' Position
                tmpPressionControle.Parent = gestionBusesEtalon_panel_pressionControle
                tmpPressionControle.Left = 8
                tmpPressionControle.Top = positionTop
                ' Taille
                tmpPressionControle.Width = 104
                ' Apparence
                tmpPressionControle.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpPressionControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Debit reference
                Dim tmpDebitRef As New Label
                tmpDebitRef.Name = "buseEtalon_" & tmpBuseEtalon.numeroNational & "_debitReference"
                tmpDebitRef.Text = tmpBuseEtalon.debitEtalonnage
                Controls.Add(tmpDebitRef)
                ' Position
                tmpDebitRef.Parent = gestionBusesEtalon_panel_debitReference
                tmpDebitRef.Left = 8
                tmpDebitRef.Top = positionTop
                ' Taille
                tmpDebitRef.Width = 104
                ' Apparence
                tmpDebitRef.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpDebitRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Etat
                Dim tmpState As New PictureBox
                tmpState.Name = "buseEtalon_" & tmpBuseEtalon.numeroNational & "_etat"
                'tmpState.Image = imagesEtatMateriel.Images(1)
                If tmpBuseEtalon.jamaisServi Then
                    tmpState.Image = imagesEtatMateriel.Images(2) 'Gris
                Else
                    If tmpBuseEtalon.etat Then
                        tmpState.Image = imagesEtatMateriel.Images(1) 'Vert
                    Else
                        tmpState.Image = imagesEtatMateriel.Images(0) 'Rouge
                    End If
                End If
                Controls.Add(tmpState)
                tmpState.Parent = gestionBusesEtalon_panel_Etat
                tmpState.Width = 16
                tmpState.Height = 16
                tmpState.Left = 20
                tmpState.Top = positionTop

            Next

        Catch ex As Exception
            CSDebug.dispError("Gestion_busesEtalons.DisplayListe Error" + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Sub dispFicheBuse(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim obuse As Buse = sender.Tag
            Dim formFicheBuse As New fiche_buse(obuse)
            If formFicheBuse.ShowDialog(Me) <> Windows.Forms.DialogResult.Cancel Then
                DisplayListe()
            End If
        Catch ex As Exception
            CSDebug.dispError("Affichage fiche Buse : " & ex.Message)
        End Try
    End Sub

    Private Sub btn_gestionBuses_nouveau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newBuse As New Buse
        newBuse.etat = True
        Dim formFicheBuse As New fiche_buse(newBuse, True)
        If formFicheBuse.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DisplayListe()
        End If
    End Sub
End Class
