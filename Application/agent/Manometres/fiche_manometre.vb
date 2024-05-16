Imports System.Collections.Generic
Imports System.Linq

Public Class fiche_manometre
    Inherits System.Windows.Forms.Form

    Dim manometreCourant As Manometre
    Friend WithEvents LabelManoEtalon As System.Windows.Forms.Label
    Friend WithEvents lblIncertitude As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbEtat As System.Windows.Forms.PictureBox
    Friend WithEvents btnActiver As System.Windows.Forms.Button
    Friend WithEvents imagesEtatMateriel As System.Windows.Forms.ImageList
    Dim isAjout As Boolean
    Friend WithEvents ficheMano_type As TextBox
    Friend WithEvents m_bsrcPool As BindingSource
    Friend WithEvents Label9 As Label
    Friend WithEvents cbxPool As CheckedListBox
    Friend WithEvents pnlManoControle As Panel
    Friend WithEvents rbTypeRaccordRV As RadioButton
    Friend WithEvents rbTypeRaccordRA As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents nupNumTraca As CRODIP_ControlLibrary.NumericUpDown2
    Friend WithEvents rbTypeTracaH As RadioButton
    Friend WithEvents rbTypeTracaB As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Dim bManoMAJ As Boolean

    Public Sub New(ByVal _manometreCourant As Manometre)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        cbxPool.DataSource = m_bsrcPool
        cbxPool.DisplayMember = "Libelle"

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        ' On load le mano
        manometreCourant = _manometreCourant
        If TypeOf (manometreCourant) Is ManometreControle Then
            m_TypeMano = TYPEMANO.MANOCONTROLE
        Else
            m_TypeMano = TYPEMANO.MANOETALON
        End If

    End Sub
    Public Sub New(ByVal _manometreCourant As Manometre, ByVal _isAjout As Boolean)
        Me.New(_manometreCourant)
        isAjout = _isAjout
    End Sub

#Region " Code généré par le Concepteur Windows Form "

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
    Friend WithEvents LabelManoControle As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ficheMano_marque As System.Windows.Forms.ComboBox
    Friend WithEvents ficheMano_dateActivation As System.Windows.Forms.Label
    Friend WithEvents ficheMano_dateControle As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_valider As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_supprimer As System.Windows.Forms.Label
    Friend WithEvents ficheMano_fondEchelle As System.Windows.Forms.TextBox
    Friend WithEvents ficheMano_classe As System.Windows.Forms.TextBox
    Friend WithEvents ficheMano_idCrodip As System.Windows.Forms.TextBox
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents ficheMano_resolution As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fiche_manometre))
        Me.LabelManoControle = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ficheMano_marque = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ficheMano_dateActivation = New System.Windows.Forms.Label()
        Me.ficheMano_dateControle = New System.Windows.Forms.Label()
        Me.btn_ficheMano_valider = New System.Windows.Forms.Label()
        Me.btn_ficheMano_supprimer = New System.Windows.Forms.Label()
        Me.ficheMano_fondEchelle = New System.Windows.Forms.TextBox()
        Me.ficheMano_classe = New System.Windows.Forms.TextBox()
        Me.ficheMano_idCrodip = New System.Windows.Forms.TextBox()
        Me.lblResolution = New System.Windows.Forms.Label()
        Me.ficheMano_resolution = New System.Windows.Forms.TextBox()
        Me.LabelManoEtalon = New System.Windows.Forms.Label()
        Me.lblIncertitude = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbEtat = New System.Windows.Forms.PictureBox()
        Me.btnActiver = New System.Windows.Forms.Button()
        Me.imagesEtatMateriel = New System.Windows.Forms.ImageList(Me.components)
        Me.ficheMano_type = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxPool = New System.Windows.Forms.CheckedListBox()
        Me.pnlManoControle = New System.Windows.Forms.Panel()
        Me.nupNumTraca = New CRODIP_ControlLibrary.NumericUpDown2()
        Me.rbTypeTracaH = New System.Windows.Forms.RadioButton()
        Me.rbTypeTracaB = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rbTypeRaccordRV = New System.Windows.Forms.RadioButton()
        Me.rbTypeRaccordRA = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.m_bsrcPool = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.pbEtat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlManoControle.SuspendLayout()
        CType(Me.nupNumTraca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.m_bsrcPool, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelManoControle
        '
        Me.LabelManoControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelManoControle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.LabelManoControle.Image = CType(resources.GetObject("LabelManoControle.Image"), System.Drawing.Image)
        Me.LabelManoControle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelManoControle.Location = New System.Drawing.Point(8, 8)
        Me.LabelManoControle.Name = "LabelManoControle"
        Me.LabelManoControle.Size = New System.Drawing.Size(408, 24)
        Me.LabelManoControle.TabIndex = 3
        Me.LabelManoControle.Text = "     Fiche manomètre de contrôle/calibrateur"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Identifiant :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Marque :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Classe :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Type :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(8, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Fond d'échelle :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheMano_marque
        '
        Me.ficheMano_marque.Enabled = False
        Me.ficheMano_marque.Location = New System.Drawing.Point(128, 72)
        Me.ficheMano_marque.Name = "ficheMano_marque"
        Me.ficheMano_marque.Size = New System.Drawing.Size(256, 21)
        Me.ficheMano_marque.Sorted = True
        Me.ficheMano_marque.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(5, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Date activation :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(5, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Dernier contrôle :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheMano_dateActivation
        '
        Me.ficheMano_dateActivation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ficheMano_dateActivation.ForeColor = System.Drawing.Color.Black
        Me.ficheMano_dateActivation.Location = New System.Drawing.Point(141, 234)
        Me.ficheMano_dateActivation.Name = "ficheMano_dateActivation"
        Me.ficheMano_dateActivation.Size = New System.Drawing.Size(160, 16)
        Me.ficheMano_dateActivation.TabIndex = 14
        Me.ficheMano_dateActivation.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ficheMano_dateControle
        '
        Me.ficheMano_dateControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ficheMano_dateControle.ForeColor = System.Drawing.Color.Black
        Me.ficheMano_dateControle.Location = New System.Drawing.Point(141, 258)
        Me.ficheMano_dateControle.Name = "ficheMano_dateControle"
        Me.ficheMano_dateControle.Size = New System.Drawing.Size(160, 16)
        Me.ficheMano_dateControle.TabIndex = 14
        Me.ficheMano_dateControle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btn_ficheMano_valider
        '
        Me.btn_ficheMano_valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ficheMano_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_valider.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_valider.Image = CType(resources.GetObject("btn_ficheMano_valider.Image"), System.Drawing.Image)
        Me.btn_ficheMano_valider.Location = New System.Drawing.Point(377, 455)
        Me.btn_ficheMano_valider.Name = "btn_ficheMano_valider"
        Me.btn_ficheMano_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_valider.TabIndex = 0
        Me.btn_ficheMano_valider.Text = "    Valider/Quitter"
        Me.btn_ficheMano_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheMano_supprimer
        '
        Me.btn_ficheMano_supprimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ficheMano_supprimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_supprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_supprimer.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_supprimer.Image = CType(resources.GetObject("btn_ficheMano_supprimer.Image"), System.Drawing.Image)
        Me.btn_ficheMano_supprimer.Location = New System.Drawing.Point(242, 455)
        Me.btn_ficheMano_supprimer.Name = "btn_ficheMano_supprimer"
        Me.btn_ficheMano_supprimer.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_supprimer.TabIndex = 8
        Me.btn_ficheMano_supprimer.Text = "    Supprimer"
        Me.btn_ficheMano_supprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ficheMano_fondEchelle
        '
        Me.ficheMano_fondEchelle.Enabled = False
        Me.ficheMano_fondEchelle.Location = New System.Drawing.Point(128, 152)
        Me.ficheMano_fondEchelle.MaxLength = 2
        Me.ficheMano_fondEchelle.Name = "ficheMano_fondEchelle"
        Me.ficheMano_fondEchelle.Size = New System.Drawing.Size(48, 20)
        Me.ficheMano_fondEchelle.TabIndex = 5
        '
        'ficheMano_classe
        '
        Me.ficheMano_classe.Enabled = False
        Me.ficheMano_classe.Location = New System.Drawing.Point(128, 99)
        Me.ficheMano_classe.MaxLength = 4
        Me.ficheMano_classe.Name = "ficheMano_classe"
        Me.ficheMano_classe.Size = New System.Drawing.Size(48, 20)
        Me.ficheMano_classe.TabIndex = 3
        '
        'ficheMano_idCrodip
        '
        Me.ficheMano_idCrodip.Location = New System.Drawing.Point(128, 44)
        Me.ficheMano_idCrodip.MaxLength = 5
        Me.ficheMano_idCrodip.Name = "ficheMano_idCrodip"
        Me.ficheMano_idCrodip.ReadOnly = True
        Me.ficheMano_idCrodip.Size = New System.Drawing.Size(256, 20)
        Me.ficheMano_idCrodip.TabIndex = 1
        '
        'lblResolution
        '
        Me.lblResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolution.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lblResolution.Location = New System.Drawing.Point(8, 178)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(104, 16)
        Me.lblResolution.TabIndex = 29
        Me.lblResolution.Text = "Résolution :"
        Me.lblResolution.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheMano_resolution
        '
        Me.ficheMano_resolution.Enabled = False
        Me.ficheMano_resolution.Location = New System.Drawing.Point(128, 177)
        Me.ficheMano_resolution.MaxLength = 15
        Me.ficheMano_resolution.Name = "ficheMano_resolution"
        Me.ficheMano_resolution.Size = New System.Drawing.Size(120, 20)
        Me.ficheMano_resolution.TabIndex = 6
        '
        'LabelManoEtalon
        '
        Me.LabelManoEtalon.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelManoEtalon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.LabelManoEtalon.Image = CType(resources.GetObject("LabelManoEtalon.Image"), System.Drawing.Image)
        Me.LabelManoEtalon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelManoEtalon.Location = New System.Drawing.Point(70, -4)
        Me.LabelManoEtalon.Name = "LabelManoEtalon"
        Me.LabelManoEtalon.Size = New System.Drawing.Size(336, 24)
        Me.LabelManoEtalon.TabIndex = 31
        Me.LabelManoEtalon.Text = "     Fiche manomètre de étalon"
        '
        'lblIncertitude
        '
        Me.lblIncertitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncertitude.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lblIncertitude.Location = New System.Drawing.Point(8, 168)
        Me.lblIncertitude.Name = "lblIncertitude"
        Me.lblIncertitude.Size = New System.Drawing.Size(104, 16)
        Me.lblIncertitude.TabIndex = 32
        Me.lblIncertitude.Text = "Incertitude  :"
        Me.lblIncertitude.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Etat :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pbEtat
        '
        Me.pbEtat.Location = New System.Drawing.Point(128, 207)
        Me.pbEtat.Name = "pbEtat"
        Me.pbEtat.Size = New System.Drawing.Size(16, 16)
        Me.pbEtat.TabIndex = 34
        Me.pbEtat.TabStop = False
        '
        'btnActiver
        '
        Me.btnActiver.Location = New System.Drawing.Point(156, 207)
        Me.btnActiver.Name = "btnActiver"
        Me.btnActiver.Size = New System.Drawing.Size(61, 19)
        Me.btnActiver.TabIndex = 35
        Me.btnActiver.Text = "Activer"
        Me.btnActiver.UseVisualStyleBackColor = True
        '
        'imagesEtatMateriel
        '
        Me.imagesEtatMateriel.ImageStream = CType(resources.GetObject("imagesEtatMateriel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesEtatMateriel.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesEtatMateriel.Images.SetKeyName(0, "")
        Me.imagesEtatMateriel.Images.SetKeyName(1, "")
        Me.imagesEtatMateriel.Images.SetKeyName(2, "g.jpg")
        '
        'ficheMano_type
        '
        Me.ficheMano_type.Enabled = False
        Me.ficheMano_type.Location = New System.Drawing.Point(128, 126)
        Me.ficheMano_type.Name = "ficheMano_type"
        Me.ficheMano_type.Size = New System.Drawing.Size(256, 20)
        Me.ficheMano_type.TabIndex = 36
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(5, 284)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 16)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Pool :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cbxPool
        '
        Me.cbxPool.FormattingEnabled = True
        Me.cbxPool.Location = New System.Drawing.Point(144, 284)
        Me.cbxPool.Name = "cbxPool"
        Me.cbxPool.Size = New System.Drawing.Size(143, 49)
        Me.cbxPool.TabIndex = 38
        '
        'pnlManoControle
        '
        Me.pnlManoControle.Controls.Add(Me.Panel2)
        Me.pnlManoControle.Controls.Add(Me.Panel1)
        Me.pnlManoControle.Controls.Add(Me.Label11)
        Me.pnlManoControle.Controls.Add(Me.nupNumTraca)
        Me.pnlManoControle.Controls.Add(Me.Label10)
        Me.pnlManoControle.Location = New System.Drawing.Point(8, 339)
        Me.pnlManoControle.Name = "pnlManoControle"
        Me.pnlManoControle.Size = New System.Drawing.Size(497, 85)
        Me.pnlManoControle.TabIndex = 46
        '
        'nupNumTraca
        '
        Me.nupNumTraca.Location = New System.Drawing.Point(218, 3)
        Me.nupNumTraca.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nupNumTraca.Name = "nupNumTraca"
        Me.nupNumTraca.Size = New System.Drawing.Size(54, 20)
        Me.nupNumTraca.TabIndex = 47
        '
        'rbTypeTracaH
        '
        Me.rbTypeTracaH.AutoSize = True
        Me.rbTypeTracaH.Location = New System.Drawing.Point(42, 5)
        Me.rbTypeTracaH.Name = "rbTypeTracaH"
        Me.rbTypeTracaH.Size = New System.Drawing.Size(33, 17)
        Me.rbTypeTracaH.TabIndex = 46
        Me.rbTypeTracaH.TabStop = True
        Me.rbTypeTracaH.Text = "H"
        Me.rbTypeTracaH.UseVisualStyleBackColor = True
        '
        'rbTypeTracaB
        '
        Me.rbTypeTracaB.AutoSize = True
        Me.rbTypeTracaB.Location = New System.Drawing.Point(4, 5)
        Me.rbTypeTracaB.Name = "rbTypeTracaB"
        Me.rbTypeTracaB.Size = New System.Drawing.Size(32, 17)
        Me.rbTypeTracaB.TabIndex = 45
        Me.rbTypeTracaB.TabStop = True
        Me.rbTypeTracaB.Text = "B"
        Me.rbTypeTracaB.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 16)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Tracabilité :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'rbTypeRaccordRV
        '
        Me.rbTypeRaccordRV.AutoSize = True
        Me.rbTypeRaccordRV.Location = New System.Drawing.Point(40, 3)
        Me.rbTypeRaccordRV.Name = "rbTypeRaccordRV"
        Me.rbTypeRaccordRV.Size = New System.Drawing.Size(40, 17)
        Me.rbTypeRaccordRV.TabIndex = 50
        Me.rbTypeRaccordRV.TabStop = True
        Me.rbTypeRaccordRV.Text = "RV"
        Me.rbTypeRaccordRV.UseVisualStyleBackColor = True
        '
        'rbTypeRaccordRA
        '
        Me.rbTypeRaccordRA.AutoSize = True
        Me.rbTypeRaccordRA.Location = New System.Drawing.Point(1, 3)
        Me.rbTypeRaccordRA.Name = "rbTypeRaccordRA"
        Me.rbTypeRaccordRA.Size = New System.Drawing.Size(40, 17)
        Me.rbTypeRaccordRA.TabIndex = 49
        Me.rbTypeRaccordRA.TabStop = True
        Me.rbTypeRaccordRA.Text = "RA"
        Me.rbTypeRaccordRA.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(1, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 16)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Type de raccord :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbTypeTracaB)
        Me.Panel1.Controls.Add(Me.rbTypeTracaH)
        Me.Panel1.Location = New System.Drawing.Point(127, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(85, 25)
        Me.Panel1.TabIndex = 51
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbTypeRaccordRV)
        Me.Panel2.Controls.Add(Me.rbTypeRaccordRA)
        Me.Panel2.Location = New System.Drawing.Point(127, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(85, 22)
        Me.Panel2.TabIndex = 52
        '
        'm_bsrcPool
        '
        Me.m_bsrcPool.DataSource = GetType(Crodip_agent.Pool)
        '
        'fiche_manometre
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(517, 488)
        Me.Controls.Add(Me.pnlManoControle)
        Me.Controls.Add(Me.cbxPool)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ficheMano_type)
        Me.Controls.Add(Me.btnActiver)
        Me.Controls.Add(Me.pbEtat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblIncertitude)
        Me.Controls.Add(Me.LabelManoEtalon)
        Me.Controls.Add(Me.ficheMano_resolution)
        Me.Controls.Add(Me.lblResolution)
        Me.Controls.Add(Me.ficheMano_idCrodip)
        Me.Controls.Add(Me.btn_ficheMano_valider)
        Me.Controls.Add(Me.btn_ficheMano_supprimer)
        Me.Controls.Add(Me.ficheMano_marque)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LabelManoControle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ficheMano_dateActivation)
        Me.Controls.Add(Me.ficheMano_dateControle)
        Me.Controls.Add(Me.ficheMano_fondEchelle)
        Me.Controls.Add(Me.ficheMano_classe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fiche_manometre"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Fiche Manomètre Contrôle"
        CType(Me.pbEtat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlManoControle.ResumeLayout(False)
        CType(Me.nupNumTraca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.m_bsrcPool, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Enum TYPEMANO
        MANOCONTROLE = 0
        MANOETALON = 1
    End Enum
    Dim sendersForm As Form
    Private m_TypeMano As TYPEMANO
    Public Sub SetTypeMano(ByVal pTypeMano As TYPEMANO)
        m_TypeMano = pTypeMano
    End Sub

    Public Sub setSendersForm(ByVal _sendersForm As Form)
        sendersForm = _sendersForm
    End Sub
    Private Sub fiche_manometreControle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_TypeMano = TYPEMANO.MANOCONTROLE Then
            LabelManoEtalon.Visible = False
            LabelManoControle.Visible = True
            LabelManoControle.Location = New Point(8, 8)
            lblResolution.Visible = True
            lblIncertitude.Visible = False
            Me.Text = "Crodip .::. Fiche Manomètre Contrôle"
            Me.pnlManoControle.Visible = True
        Else
            LabelManoEtalon.Visible = True
            LabelManoControle.Visible = False
            LabelManoEtalon.Location = New Point(8, 8)
            lblResolution.Visible = False
            lblIncertitude.Visible = True
            'C'est le libelle de résolution qui détient la bonne position
            lblIncertitude.Location = lblResolution.Location
            Me.Text = "Crodip .::. Fiche Manomètre Etalon"
            Me.pnlManoControle.Visible = False
        End If
        Dim oLst As List(Of Pool)
        oLst = PoolManager.GetListe(manometreCourant.idStructure)
        m_bsrcPool.Clear()
        oLst.ForEach(Sub(p)
                         m_bsrcPool.Add(p)
                     End Sub)

        DisplayManoCourant()
        bManoMAJ = False


    End Sub
    Private Sub DisplayManoCourant()
        ficheMano_idCrodip.Text = manometreCourant.idCrodip
        ficheMano_marque.Text = manometreCourant.marque
        ficheMano_classe.Text = manometreCourant.classe
        ficheMano_type.Text = manometreCourant.type
        ficheMano_fondEchelle.Text = manometreCourant.fondEchelle
        If m_TypeMano = TYPEMANO.MANOETALON Then
            Dim oMano As ManometreEtalon = CType(manometreCourant, ManometreEtalon)
            ficheMano_resolution.Text = oMano.incertitudeEtalon
        Else
            Dim oMano As ManometreControle = CType(manometreCourant, ManometreControle)
            ficheMano_resolution.Text = oMano.resolution
        End If

        If manometreCourant.JamaisServi Then
            pbEtat.Image = imagesEtatMateriel.Images(2)
        Else
            If manometreCourant.etat Then
                pbEtat.Image = imagesEtatMateriel.Images(1)
            Else
                pbEtat.Image = imagesEtatMateriel.Images(0)
            End If
        End If

        btnActiver.Visible = manometreCourant.JamaisServi
        If Not manometreCourant.JamaisServi Then
            If Not CSDate.isDateNull(manometreCourant.DateActivation) Then
                ficheMano_dateActivation.Text = CSDate.ToCRODIPString(manometreCourant.DateActivation)
            End If
        End If
        If Not CSDate.isDateNull(manometreCourant.dateDernierControleS) Then
            ficheMano_dateControle.Text = CSDate.ToCRODIPString(manometreCourant.dateDernierControleS)
        End If

        'Parcours de la Liste des Pools pour checker ceux qui sont les Pool du manoCourant
        Dim index As Integer = 0
        For index = 0 To cbxPool.Items.Count() - 1
            Dim obj As Pool = cbxPool.Items(index)
            If manometreCourant.lstPools.Where(Function(p)
                                                   Return (p.idCrodip.Equals(obj.idCrodip))
                                               End Function).Count() > 0 Then
                cbxPool.SetItemChecked(index, True)
            Else
                cbxPool.SetItemChecked(index, False)
            End If
        Next
        If m_TypeMano = TYPEMANO.MANOCONTROLE Then
            Dim oMano As ManometreControle = CType(manometreCourant, ManometreControle)
            rbTypeTracaB.Checked = oMano.IsTypeTracaB
            rbTypeTracaH.Checked = oMano.IsTypeTracaH
            nupNumTraca.tb.Text = oMano.numTraca
            rbTypeRaccordRA.Checked = oMano.IsTypeRaccordRA
            rbTypeRaccordRV.Checked = oMano.IsTypeRaccordRV


        End If

    End Sub

    Private Sub btn_ficheMano_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_valider.Click

        ' On enregistre les infos
        If bManoMAJ Then
            Try
                '                    manometreCourant.numeroNational = ficheMano_numeroNational.Text
                '                   manometreCourant.idCrodip = ficheMano_idCrodip.Text
                manometreCourant.marque = ficheMano_marque.Text
                manometreCourant.classe = ficheMano_classe.Text
                manometreCourant.type = ficheMano_type.Text
                manometreCourant.fondEchelle = ficheMano_fondEchelle.Text
                If m_TypeMano = TYPEMANO.MANOCONTROLE Then
                    CType(manometreCourant, ManometreControle).resolution = ficheMano_resolution.Text
                Else
                    CType(manometreCourant, ManometreEtalon).incertitudeEtalon = ficheMano_resolution.Text
                End If
                manometreCourant.dateModificationAgent = CSDate.ToCRODIPString(Date.Now)
                manometreCourant.lstPools.Clear()
                For Each oItem As Pool In cbxPool.CheckedItems
                    manometreCourant.lstPools.Add(oItem)
                Next

                If m_TypeMano = TYPEMANO.MANOCONTROLE Then
                    Dim oMano As ManometreControle = CType(manometreCourant, ManometreControle)
                    oMano.IsTypeTracaB = rbTypeTracaB.Checked
                    oMano.IsTypeTracaH = rbTypeTracaH.Checked
                    oMano.numTraca = nupNumTraca.tb.Text
                    oMano.IsTypeRaccordRA = rbTypeRaccordRA.Checked
                    oMano.IsTypeRaccordRV = rbTypeRaccordRV.Checked
                End If


                If m_TypeMano = TYPEMANO.MANOCONTROLE Then
                    ManometreControleManager.save(manometreCourant)
                Else
                    ManometreEtalonManager.save(manometreCourant)
                End If
            Catch ex As Exception
                CSDebug.dispFatal("Fiche Mano Controle - Enregistrement : " & ex.Message.ToString)
            End Try
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    'Private Sub btn_ficheMano_ficheVie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_ficheVie.Click
    '    Dim tmpFichevieManoControle As List(Of FVManometreControle) = FVManometreControleManager.getArrFVManometreControle(manometreCourant.numeroNational)
    '    Dim formFichevie As New fichevie_mano(manometreCourant.numeroNational, tmpFichevieManoControle, "controle")
    '    formFichevie.ShowDialog()
    'End Sub

    Private Sub btn_ficheMano_supprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_supprimer.Click
        'If MsgBox("Attention, vous allez supprimer définitivement ce manomètre. Confirmez-vous ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Try
        '        If ManometreControleManager.deleteManometreControle(manometreCourant) Then
        '            MsgBox("Votre manomètre à bien été supprimé.")
        '        Else
        '            MsgBox("Vous ne pouvez pas supprimer ce manomètre car il a déjà été utilisé !")
        '        End If
        '        Me.Close()
        '    Catch ex As Exception
        '        CSDebug.dispFatal("fiche_manometreControle::btn_ficheMano_supprimer_Click : " & ex.Message.ToString)
        '    End Try
        'End If
        MsgBox("Contacter le CRODIP pour supprimer votre équipement")
        'Dim oFrm As SuppressionMateriel
        'oFrm = New SuppressionMateriel(manometreCourant)
        'If oFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        '    Me.Close()
        'End If
    End Sub


    Private Sub ficheMano_classe_ForceDot(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheMano_classe.KeyPress
        CSForm.forceDot(e, sender)
    End Sub

    Private Sub ficheMano_resolution_ForceDot(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheMano_resolution.KeyPress
        CSForm.forceDot(e, sender)
    End Sub

    Private Sub ficheMano_resolution_TypeAllowed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheMano_resolution.KeyPress
        CSForm.typeAllowed(e, "numerique")
    End Sub

    Private Sub btnActiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActiver.Click
        If MsgBox("Etes-vous sur de vouloir activer ce matériel ?", MsgBoxStyle.YesNo, "Activation de matériel") = MsgBoxResult.Yes Then
            manometreCourant.ActiverMateriel(Now, agentCourant)
            bManoMAJ = True
            DisplayManoCourant()
        End If
    End Sub



    Private Sub pbEtat_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbEtat.MouseDown
#If DEBUG Then
        If e.Button = Windows.Forms.MouseButtons.Right Then
            manometreCourant.etat = Not manometreCourant.etat
            bManoMAJ = True
            DisplayManoCourant()
        End If
#End If
    End Sub

    Private Sub cbxPool_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles cbxPool.ItemCheck
        bManoMAJ = True
    End Sub

    Private Sub rbTypeTracaB_CheckedChanged(sender As Object, e As EventArgs) Handles rbTypeTracaB.CheckedChanged
        bManoMAJ = True

    End Sub

    Private Sub rbTypeTracaH_CheckedChanged(sender As Object, e As EventArgs) Handles rbTypeTracaH.CheckedChanged
        bManoMAJ = True

    End Sub

    Private Sub nupNumTraca_ValueChanged(sender As Object, e As EventArgs) Handles nupNumTraca.ValueChanged
        bManoMAJ = True

    End Sub

    Private Sub rbTypeRaccordRA_CheckedChanged(sender As Object, e As EventArgs) Handles rbTypeRaccordRA.CheckedChanged
        bManoMAJ = True

    End Sub

    Private Sub rbTypeRaccordRV_CheckedChanged(sender As Object, e As EventArgs) Handles rbTypeRaccordRV.CheckedChanged
        bManoMAJ = True

    End Sub
End Class
