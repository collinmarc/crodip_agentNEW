Imports System.Collections.Generic
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

    Public Sub New(ByVal _manometreCourant As Manometre)
        MyBase.New()

        ' On load le mano
        manometreCourant = _manometreCourant
        If TypeOf (manometreCourant) Is ManometreControle Then
            m_TypeMano = TYPEMANO.MANOCONTROLE
        Else
            m_TypeMano = TYPEMANO.MANOETALON
        End If
        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

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
    Friend WithEvents ficheMano_type As System.Windows.Forms.ComboBox
    Friend WithEvents ficheMano_dateActivation As System.Windows.Forms.Label
    Friend WithEvents ficheMano_dateControle As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_valider As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_supprimer As System.Windows.Forms.Label
    Friend WithEvents ficheMano_fondEchelle As System.Windows.Forms.TextBox
    Friend WithEvents btn_ficheMano_ficheVie As System.Windows.Forms.Label
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
        Me.ficheMano_type = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ficheMano_dateActivation = New System.Windows.Forms.Label()
        Me.ficheMano_dateControle = New System.Windows.Forms.Label()
        Me.btn_ficheMano_valider = New System.Windows.Forms.Label()
        Me.btn_ficheMano_supprimer = New System.Windows.Forms.Label()
        Me.ficheMano_fondEchelle = New System.Windows.Forms.TextBox()
        Me.btn_ficheMano_ficheVie = New System.Windows.Forms.Label()
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
        CType(Me.pbEtat, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ficheMano_type
        '
        Me.ficheMano_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ficheMano_type.Enabled = False
        Me.ficheMano_type.Location = New System.Drawing.Point(128, 125)
        Me.ficheMano_type.Name = "ficheMano_type"
        Me.ficheMano_type.Size = New System.Drawing.Size(256, 21)
        Me.ficheMano_type.Sorted = True
        Me.ficheMano_type.TabIndex = 4
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
        Me.btn_ficheMano_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_valider.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_valider.Image = CType(resources.GetObject("btn_ficheMano_valider.Image"), System.Drawing.Image)
        Me.btn_ficheMano_valider.Location = New System.Drawing.Point(288, 299)
        Me.btn_ficheMano_valider.Name = "btn_ficheMano_valider"
        Me.btn_ficheMano_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_valider.TabIndex = 0
        Me.btn_ficheMano_valider.Text = "    Valider/Quitter"
        Me.btn_ficheMano_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheMano_supprimer
        '
        Me.btn_ficheMano_supprimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_supprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_supprimer.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_supprimer.Image = CType(resources.GetObject("btn_ficheMano_supprimer.Image"), System.Drawing.Image)
        Me.btn_ficheMano_supprimer.Location = New System.Drawing.Point(153, 299)
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
        'btn_ficheMano_ficheVie
        '
        Me.btn_ficheMano_ficheVie.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_ficheVie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_ficheVie.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_ficheVie.Image = CType(resources.GetObject("btn_ficheMano_ficheVie.Image"), System.Drawing.Image)
        Me.btn_ficheMano_ficheVie.Location = New System.Drawing.Point(16, 299)
        Me.btn_ficheMano_ficheVie.Name = "btn_ficheMano_ficheVie"
        Me.btn_ficheMano_ficheVie.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_ficheVie.TabIndex = 7
        Me.btn_ficheMano_ficheVie.Text = "    Fiche de vie"
        Me.btn_ficheMano_ficheVie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_ficheMano_ficheVie.Visible = False
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
        'fiche_manometre
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(501, 353)
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
        Me.Controls.Add(Me.ficheMano_type)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ficheMano_dateActivation)
        Me.Controls.Add(Me.ficheMano_dateControle)
        Me.Controls.Add(Me.ficheMano_fondEchelle)
        Me.Controls.Add(Me.btn_ficheMano_ficheVie)
        Me.Controls.Add(Me.ficheMano_classe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fiche_manometre"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Fiche Manomètre Contrôle"
        CType(Me.pbEtat, System.ComponentModel.ISupportInitialize).EndInit()
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
            'C'est le libelle de résolution qui détient la bonne position
            '            lblResolution.Location = New Point(8, 177)
            Me.Text = "Crodip .::. Fiche Manomètre Contrôle"
            MarquesManager.populateCombobox(GLOB_XML_MARQUES_MANOCONT, ficheMano_marque)
            MarquesManager.populateCombobox(GLOB_XML_MODELES_MANOCONT, ficheMano_type)
            ' On charge les infos
            '    If manometreCourant.numeroNational = "" Then
            '        manometreCourant.numeroNational = ManometreControleManager.getNewNumeroNational()
            '    End If
        Else
            LabelManoEtalon.Visible = True
            LabelManoControle.Visible = False
            LabelManoEtalon.Location = New Point(8, 8)
            lblResolution.Visible = False
            lblIncertitude.Visible = True
            'C'est le libelle de résolution qui détient la bonne position
            lblIncertitude.Location = lblResolution.Location
            Me.Text = "Crodip .::. Fiche Manomètre Etalon"
            MarquesManager.populateCombobox(GLOB_XML_MARQUES_MANOETA, ficheMano_marque)
            MarquesManager.populateCombobox(GLOB_XML_MODELES_MANOETA, ficheMano_type)
            '    ' On charge les infos
            '    If manometreCourant.numeroNational = "" Then
            '        manometreCourant.numeroNational = ManometreEtalonManager.getNewNumeroNational()
            '    End If
        End If
        DisplayManoCourant()



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
        If Not CSDate.isDateNull(manometreCourant.DateActivation) Then
            ficheMano_dateActivation.Text = CSDate.mysql2access(manometreCourant.DateActivation)
        End If
        If Not CSDate.isDateNull(manometreCourant.dateDernierControle) Then
            ficheMano_dateControle.Text = CSDate.mysql2access(manometreCourant.dateDernierControle)
        End If

    End Sub

    Private Sub btn_ficheMano_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_valider.Click

        ' On enregistre les infos

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
            manometreCourant.dateModificationAgent = CSDate.mysql2access(Date.Now)
            If m_TypeMano = TYPEMANO.MANOCONTROLE Then
                ManometreControleManager.save(manometreCourant)
            Else
                ManometreEtalonManager.save(manometreCourant)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            CSDebug.dispFatal("Fiche Mano Controle - Enregistrement : " & ex.Message.ToString)
        End Try

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
        Dim oFrm As SuppressionMateriel
        oFrm = New SuppressionMateriel(manometreCourant)
        If oFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
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
            DisplayManoCourant()
        End If
    End Sub



    Private Sub pbEtat_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbEtat.MouseDown
#If DEBUG Then
        If e.Button = Windows.Forms.MouseButtons.Right Then
            manometreCourant.etat = Not manometreCourant.etat
            DisplayManoCourant()
        End If
#End If
    End Sub
End Class
