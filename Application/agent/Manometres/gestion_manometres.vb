Imports System.Collections.Generic
Public Class gestion_manometres
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel65 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel67 As System.Windows.Forms.Panel
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Panel68 As System.Windows.Forms.Panel
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gestionManoControle_panel_fondEchelle As System.Windows.Forms.Panel
    Friend WithEvents gestionManoControle_panel_modele As System.Windows.Forms.Panel
    Friend WithEvents gestionManoControle_panel_marque As System.Windows.Forms.Panel
    Friend WithEvents gestionManoControle_panel_id As System.Windows.Forms.Panel
    Friend WithEvents gestionManoControle_panel_classe As System.Windows.Forms.Panel
    Friend WithEvents gestionManoControle_panel_etat As System.Windows.Forms.Panel
    Friend WithEvents gestionManoEtalon_panel_fondEchelleDilate As System.Windows.Forms.Panel
    Friend WithEvents gestionManoEtalon_panel_classe As System.Windows.Forms.Panel
    Friend WithEvents gestionManoEtalon_panel_modele As System.Windows.Forms.Panel
    Friend WithEvents gestionManoEtalon_panel_marque As System.Windows.Forms.Panel
    Friend WithEvents gestionManoEtalon_panel_id As System.Windows.Forms.Panel
    Friend WithEvents ToolTipShowFichevie As System.Windows.Forms.ToolTip
    Friend WithEvents imagesEtatMateriel As System.Windows.Forms.ImageList
    Friend WithEvents gestionManoControle_panel_showFV As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents imagesPictos As System.Windows.Forms.ImageList
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents gestionManoEtalon_panel_showFV As System.Windows.Forms.Panel
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn_gestionManometresEtalon_valider As System.Windows.Forms.Label
    Friend WithEvents gestionManoEtalon_panel_etat As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestion_manometres))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel65 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gestionManoControle_panel_classe = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gestionManoControle_panel_fondEchelle = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gestionManoControle_panel_modele = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gestionManoControle_panel_marque = New System.Windows.Forms.Panel()
        Me.Panel67 = New System.Windows.Forms.Panel()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Panel68 = New System.Windows.Forms.Panel()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.gestionManoControle_panel_id = New System.Windows.Forms.Panel()
        Me.gestionManoControle_panel_etat = New System.Windows.Forms.Panel()
        Me.gestionManoControle_panel_showFV = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gestionManoEtalon_panel_etat = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gestionManoEtalon_panel_fondEchelleDilate = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gestionManoEtalon_panel_classe = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gestionManoEtalon_panel_modele = New System.Windows.Forms.Panel()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gestionManoEtalon_panel_marque = New System.Windows.Forms.Panel()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gestionManoEtalon_panel_id = New System.Windows.Forms.Panel()
        Me.gestionManoEtalon_panel_showFV = New System.Windows.Forms.Panel()
        Me.ToolTipShowFichevie = New System.Windows.Forms.ToolTip(Me.components)
        Me.imagesEtatMateriel = New System.Windows.Forms.ImageList(Me.components)
        Me.imagesPictos = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_gestionManometresEtalon_valider = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel65.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel67.SuspendLayout()
        Me.Panel68.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1014, 637)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Label82)
        Me.TabPage1.Controls.Add(Me.Panel13)
        Me.TabPage1.Controls.Add(Me.Panel65)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1006, 611)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Manomètres de contrôle"
        '
        'Label82
        '
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label82.Image = CType(resources.GetObject("Label82.Image"), System.Drawing.Image)
        Me.Label82.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label82.Location = New System.Drawing.Point(8, 8)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(480, 25)
        Me.Label82.TabIndex = 37
        Me.Label82.Text = "     Gestion des manomètres de contrôle/calibrateur"
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel13.Location = New System.Drawing.Point(7, 584)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(992, 3)
        Me.Panel13.TabIndex = 23
        '
        'Panel65
        '
        Me.Panel65.AutoScroll = True
        Me.Panel65.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel65.Controls.Add(Me.Panel7)
        Me.Panel65.Controls.Add(Me.gestionManoControle_panel_classe)
        Me.Panel65.Controls.Add(Me.Panel5)
        Me.Panel65.Controls.Add(Me.gestionManoControle_panel_fondEchelle)
        Me.Panel65.Controls.Add(Me.Panel3)
        Me.Panel65.Controls.Add(Me.gestionManoControle_panel_modele)
        Me.Panel65.Controls.Add(Me.Panel1)
        Me.Panel65.Controls.Add(Me.gestionManoControle_panel_marque)
        Me.Panel65.Controls.Add(Me.Panel67)
        Me.Panel65.Controls.Add(Me.Panel68)
        Me.Panel65.Controls.Add(Me.gestionManoControle_panel_id)
        Me.Panel65.Controls.Add(Me.gestionManoControle_panel_etat)
        Me.Panel65.Controls.Add(Me.gestionManoControle_panel_showFV)
        Me.Panel65.Controls.Add(Me.Panel4)
        Me.Panel65.Location = New System.Drawing.Point(123, 40)
        Me.Panel65.Name = "Panel65"
        Me.Panel65.Size = New System.Drawing.Size(760, 536)
        Me.Panel65.TabIndex = 11
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Location = New System.Drawing.Point(552, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(119, 40)
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
        Me.Label4.Text = "Classe"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoControle_panel_classe
        '
        Me.gestionManoControle_panel_classe.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoControle_panel_classe.Location = New System.Drawing.Point(552, 41)
        Me.gestionManoControle_panel_classe.Name = "gestionManoControle_panel_classe"
        Me.gestionManoControle_panel_classe.Size = New System.Drawing.Size(119, 495)
        Me.gestionManoControle_panel_classe.TabIndex = 28
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(424, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(127, 40)
        Me.Panel5.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fond d'échelle"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoControle_panel_fondEchelle
        '
        Me.gestionManoControle_panel_fondEchelle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoControle_panel_fondEchelle.Location = New System.Drawing.Point(424, 41)
        Me.gestionManoControle_panel_fondEchelle.Name = "gestionManoControle_panel_fondEchelle"
        Me.gestionManoControle_panel_fondEchelle.Size = New System.Drawing.Size(127, 495)
        Me.gestionManoControle_panel_fondEchelle.TabIndex = 26
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(280, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(143, 40)
        Me.Panel3.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoControle_panel_modele
        '
        Me.gestionManoControle_panel_modele.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoControle_panel_modele.Location = New System.Drawing.Point(280, 41)
        Me.gestionManoControle_panel_modele.Name = "gestionManoControle_panel_modele"
        Me.gestionManoControle_panel_modele.Size = New System.Drawing.Size(143, 495)
        Me.gestionManoControle_panel_modele.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(120, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(159, 40)
        Me.Panel1.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Marque"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoControle_panel_marque
        '
        Me.gestionManoControle_panel_marque.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoControle_panel_marque.Location = New System.Drawing.Point(120, 41)
        Me.gestionManoControle_panel_marque.Name = "gestionManoControle_panel_marque"
        Me.gestionManoControle_panel_marque.Size = New System.Drawing.Size(159, 495)
        Me.gestionManoControle_panel_marque.TabIndex = 22
        '
        'Panel67
        '
        Me.Panel67.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel67.Controls.Add(Me.Label80)
        Me.Panel67.Location = New System.Drawing.Point(672, 0)
        Me.Panel67.Name = "Panel67"
        Me.Panel67.Size = New System.Drawing.Size(88, 40)
        Me.Panel67.TabIndex = 20
        '
        'Label80
        '
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label80.Location = New System.Drawing.Point(8, 8)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(72, 24)
        Me.Label80.TabIndex = 8
        Me.Label80.Text = "Etat"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel68
        '
        Me.Panel68.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel68.Controls.Add(Me.Label81)
        Me.Panel68.Location = New System.Drawing.Point(31, 0)
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
        Me.Label81.Text = "N° identifiant manomètre"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoControle_panel_id
        '
        Me.gestionManoControle_panel_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoControle_panel_id.Location = New System.Drawing.Point(31, 41)
        Me.gestionManoControle_panel_id.Name = "gestionManoControle_panel_id"
        Me.gestionManoControle_panel_id.Size = New System.Drawing.Size(88, 495)
        Me.gestionManoControle_panel_id.TabIndex = 16
        '
        'gestionManoControle_panel_etat
        '
        Me.gestionManoControle_panel_etat.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoControle_panel_etat.Location = New System.Drawing.Point(672, 41)
        Me.gestionManoControle_panel_etat.Name = "gestionManoControle_panel_etat"
        Me.gestionManoControle_panel_etat.Size = New System.Drawing.Size(88, 495)
        Me.gestionManoControle_panel_etat.TabIndex = 17
        '
        'gestionManoControle_panel_showFV
        '
        Me.gestionManoControle_panel_showFV.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoControle_panel_showFV.Location = New System.Drawing.Point(0, 41)
        Me.gestionManoControle_panel_showFV.Name = "gestionManoControle_panel_showFV"
        Me.gestionManoControle_panel_showFV.Size = New System.Drawing.Size(30, 495)
        Me.gestionManoControle_panel_showFV.TabIndex = 16
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(30, 40)
        Me.Panel4.TabIndex = 19
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Panel9)
        Me.TabPage2.Controls.Add(Me.Panel10)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1006, 611)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Manomètre étalon"
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(616, 552)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(376, 56)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Attention ! Un manomètre étalon ne doit pas être utilisé sur le ""terrain"". Il doi" & _
            "t rester dans un endroit sécurisé, afin de garantir sa fiabilité."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(376, 25)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "     Gestion des manomètres étalons"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel9.Location = New System.Drawing.Point(11, 555)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(992, 3)
        Me.Panel9.TabIndex = 29
        '
        'Panel10
        '
        Me.Panel10.AutoScroll = True
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel10.Controls.Add(Me.Panel2)
        Me.Panel10.Controls.Add(Me.gestionManoEtalon_panel_etat)
        Me.Panel10.Controls.Add(Me.Panel6)
        Me.Panel10.Controls.Add(Me.Panel20)
        Me.Panel10.Controls.Add(Me.gestionManoEtalon_panel_fondEchelleDilate)
        Me.Panel10.Controls.Add(Me.Panel14)
        Me.Panel10.Controls.Add(Me.gestionManoEtalon_panel_classe)
        Me.Panel10.Controls.Add(Me.Panel16)
        Me.Panel10.Controls.Add(Me.gestionManoEtalon_panel_modele)
        Me.Panel10.Controls.Add(Me.Panel18)
        Me.Panel10.Controls.Add(Me.gestionManoEtalon_panel_marque)
        Me.Panel10.Controls.Add(Me.Panel21)
        Me.Panel10.Controls.Add(Me.gestionManoEtalon_panel_id)
        Me.Panel10.Controls.Add(Me.gestionManoEtalon_panel_showFV)
        Me.Panel10.Location = New System.Drawing.Point(121, 40)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(765, 509)
        Me.Panel10.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Location = New System.Drawing.Point(677, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(88, 40)
        Me.Panel2.TabIndex = 36
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(8, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 24)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Etat après vérification"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoEtalon_panel_etat
        '
        Me.gestionManoEtalon_panel_etat.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoEtalon_panel_etat.Location = New System.Drawing.Point(677, 41)
        Me.gestionManoEtalon_panel_etat.Name = "gestionManoEtalon_panel_etat"
        Me.gestionManoEtalon_panel_etat.Size = New System.Drawing.Size(88, 468)
        Me.gestionManoEtalon_panel_etat.TabIndex = 35
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(30, 40)
        Me.Panel6.TabIndex = 34
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel20.Controls.Add(Me.Label9)
        Me.Panel20.Location = New System.Drawing.Point(556, 0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(120, 40)
        Me.Panel20.TabIndex = 31
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(8, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 24)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Fond d'échelle"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoEtalon_panel_fondEchelleDilate
        '
        Me.gestionManoEtalon_panel_fondEchelleDilate.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoEtalon_panel_fondEchelleDilate.Location = New System.Drawing.Point(556, 41)
        Me.gestionManoEtalon_panel_fondEchelleDilate.Name = "gestionManoEtalon_panel_fondEchelleDilate"
        Me.gestionManoEtalon_panel_fondEchelleDilate.Size = New System.Drawing.Size(120, 468)
        Me.gestionManoEtalon_panel_fondEchelleDilate.TabIndex = 30
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel14.Controls.Add(Me.Label6)
        Me.Panel14.Location = New System.Drawing.Point(428, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(127, 40)
        Me.Panel14.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 24)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Classe"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoEtalon_panel_classe
        '
        Me.gestionManoEtalon_panel_classe.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoEtalon_panel_classe.Location = New System.Drawing.Point(428, 41)
        Me.gestionManoEtalon_panel_classe.Name = "gestionManoEtalon_panel_classe"
        Me.gestionManoEtalon_panel_classe.Size = New System.Drawing.Size(127, 468)
        Me.gestionManoEtalon_panel_classe.TabIndex = 26
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel16.Controls.Add(Me.Label7)
        Me.Panel16.Location = New System.Drawing.Point(284, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(143, 40)
        Me.Panel16.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(8, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 24)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Type"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoEtalon_panel_modele
        '
        Me.gestionManoEtalon_panel_modele.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoEtalon_panel_modele.Location = New System.Drawing.Point(284, 41)
        Me.gestionManoEtalon_panel_modele.Name = "gestionManoEtalon_panel_modele"
        Me.gestionManoEtalon_panel_modele.Size = New System.Drawing.Size(143, 468)
        Me.gestionManoEtalon_panel_modele.TabIndex = 24
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel18.Controls.Add(Me.Label8)
        Me.Panel18.Location = New System.Drawing.Point(124, 0)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(159, 40)
        Me.Panel18.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 24)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Marque"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoEtalon_panel_marque
        '
        Me.gestionManoEtalon_panel_marque.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoEtalon_panel_marque.Location = New System.Drawing.Point(124, 41)
        Me.gestionManoEtalon_panel_marque.Name = "gestionManoEtalon_panel_marque"
        Me.gestionManoEtalon_panel_marque.Size = New System.Drawing.Size(159, 468)
        Me.gestionManoEtalon_panel_marque.TabIndex = 22
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel21.Controls.Add(Me.Label10)
        Me.Panel21.Location = New System.Drawing.Point(31, 0)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(92, 40)
        Me.Panel21.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(8, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 24)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "N° identifiant manomètre"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestionManoEtalon_panel_id
        '
        Me.gestionManoEtalon_panel_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoEtalon_panel_id.Location = New System.Drawing.Point(31, 41)
        Me.gestionManoEtalon_panel_id.Name = "gestionManoEtalon_panel_id"
        Me.gestionManoEtalon_panel_id.Size = New System.Drawing.Size(92, 468)
        Me.gestionManoEtalon_panel_id.TabIndex = 16
        '
        'gestionManoEtalon_panel_showFV
        '
        Me.gestionManoEtalon_panel_showFV.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.gestionManoEtalon_panel_showFV.Location = New System.Drawing.Point(0, 41)
        Me.gestionManoEtalon_panel_showFV.Name = "gestionManoEtalon_panel_showFV"
        Me.gestionManoEtalon_panel_showFV.Size = New System.Drawing.Size(30, 468)
        Me.gestionManoEtalon_panel_showFV.TabIndex = 32
        '
        'imagesEtatMateriel
        '
        Me.imagesEtatMateriel.ImageStream = CType(resources.GetObject("imagesEtatMateriel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesEtatMateriel.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesEtatMateriel.Images.SetKeyName(0, "")
        Me.imagesEtatMateriel.Images.SetKeyName(1, "")
        Me.imagesEtatMateriel.Images.SetKeyName(2, "g.jpg")
        '
        'imagesPictos
        '
        Me.imagesPictos.ImageStream = CType(resources.GetObject("imagesPictos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesPictos.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesPictos.Images.SetKeyName(0, "")
        Me.imagesPictos.Images.SetKeyName(1, "")
        '
        'btn_gestionManometresEtalon_valider
        '
        Me.btn_gestionManometresEtalon_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionManometresEtalon_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionManometresEtalon_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionManometresEtalon_valider.Image = CType(resources.GetObject("btn_gestionManometresEtalon_valider.Image"), System.Drawing.Image)
        Me.btn_gestionManometresEtalon_valider.Location = New System.Drawing.Point(762, 653)
        Me.btn_gestionManometresEtalon_valider.Name = "btn_gestionManometresEtalon_valider"
        Me.btn_gestionManometresEtalon_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionManometresEtalon_valider.TabIndex = 40
        Me.btn_gestionManometresEtalon_valider.Text = "    Valider / Quitter"
        Me.btn_gestionManometresEtalon_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestion_manometres
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.Controls.Add(Me.btn_gestionManometresEtalon_valider)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "gestion_manometres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gestion_manometres"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel65.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel67.ResumeLayout(False)
        Me.Panel68.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub gestion_manometres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'globFormGestionMano = Me

        'Dim arrMarquesControls(0) As ComboBox
        'Dim arrTypesControls(0) As ComboBox

        '#################################################################################
        '########                    Manomètres de contrôle                       ########
        '#################################################################################
        '        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(gestion_manometres))
        ' On récupère les mano de controle de l'agent
        displaylisteManoControle()
        '#################################################################################
        '########                       Manomètres étalons                        ########
        '#################################################################################
        ' On récupère les mano de controle de l'agent
        displayListeManoEtalon()
        '#################################################################################
        '########                   Chargement des marques,etc...                 ########
        '#################################################################################
        'MarquesManager.populateCombobox(GLOB_XML_MARQUES_MANO, arrMarquesControls)
        'MarquesManager.populateCombobox(GLOB_XML_MODELES_MANO, arrTypesControls)
    End Sub
    Private Function displayListeManoEtalon() As Boolean
        Dim bReturn As Boolean
        Try
            gestionManoEtalon_panel_showFV.Controls.Clear()
            gestionManoEtalon_panel_id.Controls.Clear()
            gestionManoEtalon_panel_marque.Controls.Clear()
            gestionManoEtalon_panel_classe.Controls.Clear()
            gestionManoEtalon_panel_modele.Controls.Clear()
            gestionManoEtalon_panel_fondEchelleDilate.Controls.Clear()
            gestionManoEtalon_panel_etat.Controls.Clear()
            Dim arrManoEtalon As List(Of ManometreEtalon) = ManometreEtalonManager.getManometreEtalonByStructureId(agentCourant.idStructure, True)
            ' Création des contrôles a la volée
            Dim positionTop As Integer = 0
            positionTop = 0
            For Each tmpManoEtalon As ManometreEtalon In arrManoEtalon

                If positionTop = 0 Then
                    positionTop = 8
                Else
                    positionTop = positionTop + 24
                End If

                '## Show FV
                Dim tmpShowFV As New PictureBox
                tmpShowFV.Name = "buseEtalon_" & tmpManoEtalon.numeroNational & "_showFV"
                tmpShowFV.Image = imagesPictos.Images(0)
                Controls.Add(tmpShowFV)
                tmpShowFV.Parent = gestionManoEtalon_panel_showFV
                tmpShowFV.Width = 16
                tmpShowFV.Height = 16
                tmpShowFV.Left = 8
                tmpShowFV.Top = positionTop
                tmpShowFV.Tag = "me"
                AddHandler tmpShowFV.Click, AddressOf dispFichevie
                ToolTipShowFichevie.SetToolTip(tmpShowFV, "Voir la fiche de ce manomètre.")
                ToolTipShowFichevie.Active = True

                '## Le label
                Dim tmpLabel As New Label
                tmpLabel.Name = "manoEtalon_" & tmpManoEtalon.numeroNational & "_numeroNational"
                Controls.Add(tmpLabel)
                ' Position
                tmpLabel.Parent = gestionManoEtalon_panel_id
                tmpLabel.Left = 8
                tmpLabel.Top = positionTop
                ' Taille
                tmpLabel.Width = 80
                tmpLabel.Text = tmpManoEtalon.idCrodip
                ' Apparence
                tmpLabel.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Marque
                Dim tmpMarque As New Label
                tmpMarque.Name = "manoEtalon_" & tmpManoEtalon.numeroNational & "_marque"
                tmpMarque.Text = tmpManoEtalon.marque
                Controls.Add(tmpMarque)
                'arrMarquesControls(arrMarquesControls.Length - 1) = tmpMarque
                'ReDim Preserve arrMarquesControls(arrMarquesControls.Length)
                ' Position
                tmpMarque.Parent = gestionManoEtalon_panel_marque
                tmpMarque.Left = 8
                tmpMarque.Top = positionTop
                ' Taille
                tmpMarque.Width = 144
                ' Apparence
                tmpMarque.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpMarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Modele
                Dim tmpType As New Label
                tmpType.Name = "manoEtalon_" & tmpManoEtalon.numeroNational & "_type"
                tmpType.Text = tmpManoEtalon.type
                Controls.Add(tmpType)
                'arrTypesControls(arrTypesControls.Length - 1) = tmpType
                'ReDim Preserve arrTypesControls(arrTypesControls.Length)
                ' Position
                tmpType.Parent = gestionManoEtalon_panel_modele
                tmpType.Left = 8
                tmpType.Top = positionTop
                ' Taille
                tmpType.Width = 128
                ' Apparence
                tmpType.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Classe
                'Dim tmpClasse As New ComboBox
                Dim tmpClasse As New Label
                tmpClasse.Name = "manoEtalon_" & tmpManoEtalon.numeroNational & "_classe"
                tmpClasse.Text = tmpManoEtalon.classe
                Controls.Add(tmpClasse)
                ' Position
                tmpClasse.Parent = gestionManoEtalon_panel_classe
                tmpClasse.Left = 8
                tmpClasse.Top = positionTop
                ' Taille
                tmpClasse.Width = 112
                ' Apparence
                tmpClasse.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpClasse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Fond D'échelle
                Dim tmpFondEchelleDilate As New Label
                tmpFondEchelleDilate.Name = "manoEtalon_" & tmpManoEtalon.numeroNational & "_fondEchelleDilate"
                tmpFondEchelleDilate.Text = tmpManoEtalon.fondEchelle
                Controls.Add(tmpFondEchelleDilate)
                ' Position
                tmpFondEchelleDilate.Parent = gestionManoEtalon_panel_fondEchelleDilate
                tmpFondEchelleDilate.Left = 8
                tmpFondEchelleDilate.Top = positionTop
                ' Taille
                tmpFondEchelleDilate.Width = 104
                ' Apparence
                tmpFondEchelleDilate.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpFondEchelleDilate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Etat
                Dim tmpState As New PictureBox
                tmpState.Name = "manoEtalon_" & tmpManoEtalon.numeroNational & "_etat"
                If tmpManoEtalon.JamaisServi Then
                    tmpState.Image = imagesEtatMateriel.Images(2)
                Else
                    If tmpManoEtalon.etat Then
                        tmpState.Image = imagesEtatMateriel.Images(1)
                    Else
                        tmpState.Image = imagesEtatMateriel.Images(0)
                    End If
                End If
                Controls.Add(tmpState)
                tmpState.Parent = gestionManoEtalon_panel_etat
                tmpState.Width = 16
                tmpState.Height = 16
                tmpState.Left = 36
                tmpState.Top = positionTop
            Next
        Catch ex As Exception
            CSDebug.dispError("Gestion_Manometre.DisplayListeManoEtalon Error" + ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    Private Function displaylisteManoControle() As Boolean
        Dim bReturn As Boolean
        Try
            gestionManoControle_panel_showFV.Controls.Clear()
            gestionManoControle_panel_id.Controls.Clear()
            gestionManoControle_panel_marque.Controls.Clear()
            gestionManoControle_panel_modele.Controls.Clear()
            gestionManoControle_panel_fondEchelle.Controls.Clear()
            gestionManoControle_panel_classe.Controls.Clear()
            gestionManoControle_panel_etat.Controls.Clear()

            Dim arrManoControle As List(Of ManometreControle) = ManometreControleManager.getManoControleByStructureId(agentCourant.idStructure, True)
            'Ajout des Mano JamaisServi
            arrManoControle.AddRange(ManometreControleManager.getManoControleByStructureIdJamaisServi(agentCourant.idStructure))
            ' Création des contrôles a la volée
            Dim positionTop As Integer = 0
            For Each tmpManoControle As ManometreControle In arrManoControle

                If positionTop = 0 Then
                    positionTop = 8
                Else
                    positionTop = positionTop + 24
                End If

                '## Show FV
                Dim tmpShowFV As New PictureBox
                tmpShowFV.Name = "buseEtalon_" & tmpManoControle.numeroNational & "_showFV"
                tmpShowFV.Image = imagesPictos.Images(0)
                Controls.Add(tmpShowFV)
                tmpShowFV.Parent = gestionManoControle_panel_showFV
                tmpShowFV.Width = 16
                tmpShowFV.Height = 16
                tmpShowFV.Left = 8
                tmpShowFV.Top = positionTop
                tmpShowFV.Tag = "mc"
                AddHandler tmpShowFV.Click, AddressOf dispFichevie
                ToolTipShowFichevie.SetToolTip(tmpShowFV, "Voir la fiche de ce manomètre.")
                ToolTipShowFichevie.Active = True

                '## Le label
                Dim tmpLabel As New Label
                tmpLabel.Name = "buseEtalon_" & tmpManoControle.numeroNational & "_numeroNational"
                Controls.Add(tmpLabel)
                ' Position
                tmpLabel.Parent = gestionManoControle_panel_id
                tmpLabel.Left = 8
                tmpLabel.Top = positionTop
                ' Taille
                tmpLabel.Width = 72
                tmpLabel.Text = tmpManoControle.idCrodip
                ' Apparence
                tmpLabel.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Marque
                'Dim tmpMarque As New ComboBox
                Dim tmpMarque As New Label
                tmpMarque.Name = "buseEtalon_" & tmpManoControle.numeroNational & "_marque"
                tmpMarque.Text = tmpManoControle.marque
                Controls.Add(tmpMarque)
                'arrMarquesControls(arrMarquesControls.Length - 1) = tmpMarque
                'ReDim Preserve arrMarquesControls(arrMarquesControls.Length)
                ' Position
                tmpMarque.Parent = gestionManoControle_panel_marque
                tmpMarque.Left = 8
                tmpMarque.Top = positionTop
                ' Taille
                tmpMarque.Width = 144
                ' Apparence
                tmpMarque.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpMarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Type
                'Dim tmpType As New ComboBox
                Dim tmpType As New Label
                tmpType.Name = "buseEtalon_" & tmpManoControle.numeroNational & "_type"
                tmpType.Text = tmpManoControle.type
                Controls.Add(tmpType)
                'arrTypesControls(arrTypesControls.Length - 1) = tmpType
                'ReDim Preserve arrTypesControls(arrTypesControls.Length)
                ' Position
                tmpType.Parent = gestionManoControle_panel_modele
                tmpType.Left = 8
                tmpType.Top = positionTop
                ' Taille
                tmpType.Width = 128
                ' Apparence
                tmpType.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Fond D'échelle
                'Dim tmpFondEchelle As New ComboBox
                'Dim tmpFondEchelle As New TextBox
                Dim tmpFondEchelle As New Label
                tmpFondEchelle.Name = "buseEtalon_" & tmpManoControle.numeroNational & "_fondEchelle"
                tmpFondEchelle.Text = tmpManoControle.fondEchelle
                Controls.Add(tmpFondEchelle)
                ' Position
                tmpFondEchelle.Parent = gestionManoControle_panel_fondEchelle
                tmpFondEchelle.Left = 8
                tmpFondEchelle.Top = positionTop
                ' Taille
                tmpFondEchelle.Width = 112
                ' Apparence
                tmpFondEchelle.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpFondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Classe
                'Dim tmpClasse As New ComboBox
                'Dim tmpClasse As New TextBox
                Dim tmpClasse As New Label
                tmpClasse.Name = "buseEtalon_" & tmpManoControle.numeroNational & "_classe"
                tmpClasse.Text = tmpManoControle.classe
                Controls.Add(tmpClasse)
                ' Position
                tmpClasse.Parent = gestionManoControle_panel_classe
                tmpClasse.Left = 8
                tmpClasse.Top = positionTop
                ' Taille
                tmpClasse.Width = 104
                ' Apparence
                tmpClasse.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpClasse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                '## Etat
                Dim tmpState As New PictureBox
                tmpState.Name = "buseEtalon_" & tmpManoControle.numeroNational & "_etat"
                If tmpManoControle.JamaisServi Then
                    tmpState.Image = imagesEtatMateriel.Images(2) 'Gris
                Else
                    If tmpManoControle.etat Then
                        tmpState.Image = imagesEtatMateriel.Images(1) 'Vert
                    Else
                        tmpState.Image = imagesEtatMateriel.Images(0) 'Rouge
                    End If
                End If
                Controls.Add(tmpState)
                tmpState.Parent = gestionManoControle_panel_etat
                tmpState.Width = 16
                tmpState.Height = 16
                tmpState.Left = 36
                tmpState.Top = positionTop
            Next
        Catch ex As Exception
            CSDebug.dispError("Gestion_Manometre.DisplayListeControle Error" + ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    Private Sub dispFichevie(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            'Dim manoId As String = sender.text.ToString
            Dim manoId As String = sender.name.ToString.Replace("buseEtalon_", "").Replace("_showFV", "")
            Dim manoType As String = sender.tag
            If manoId <> "" And manoType <> "" Then

                Dim formFicheMano As fiche_manometre
                Dim oMano As Manometre
                If manoType = "mc" Then ' ManoControle
                    oMano = ManometreControleManager.getManometreControleByNumeroNational(manoId)
                ElseIf manoType = "me" Then ' ManoEtalon
                    oMano = ManometreEtalonManager.getManometreEtalonByNumeroNational(manoId)
                End If
                formFicheMano = New fiche_manometre(oMano)
                '        formFicheMano.MdiParent = Me.MdiParent
                '       formFicheMano.setSendersForm(Me)
                If formFicheMano.ShowDialog(Me) <> Windows.Forms.DialogResult.Cancel Then
                    If manoType = "mc" Then ' ManoControle
                        displaylisteManoControle()
                    ElseIf manoType = "me" Then ' ManoEtalon
                        displayListeManoEtalon()
                    End If

                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("Affichage fiche de vie : " & ex.Message)
        End Try

    End Sub

    'Validation (mano controle)
    Private Sub btn_gestionManometres_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Validation (mano etalon)
    Private Sub btn_gestionManometresEtalon_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_gestionManometresControle_nouveau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newMano As New ManometreControle
        Dim formFicheMano As New fiche_manometre(newMano, True)
        If formFicheMano.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            displaylisteManoControle()
        End If
    End Sub

    Private Sub btn_gestionManometresEtalon_nouveau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newMano As New ManometreEtalon
        Dim formFicheMano As New fiche_manometre(newMano, True)
        If formFicheMano.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            displayListeManoEtalon()
        End If
    End Sub

    Private Sub btn_gestionManometresEtalon_valider_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionManometresEtalon_valider.Click
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

    Private Sub Label80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label80.Click

    End Sub
End Class
