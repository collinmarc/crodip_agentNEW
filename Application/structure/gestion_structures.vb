Public Class gestion_structures
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_fichePulve_idCrodip As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ficheStructure_responsableTelFixe As System.Windows.Forms.TextBox
    Friend WithEvents ficheStructure_responsableCommune As System.Windows.Forms.TextBox
    Friend WithEvents ficheStructure_responsableCodePostal As System.Windows.Forms.TextBox
    Friend WithEvents ficheStructure_responsableAdresse As System.Windows.Forms.TextBox
    Friend WithEvents ficheStructure_responsableEmail As System.Windows.Forms.TextBox
    Friend WithEvents ficheStructure_nom As System.Windows.Forms.TextBox
    Friend WithEvents ficheStructure_id As System.Windows.Forms.TextBox
    Friend WithEvents label_ficheStructure_responsableTelPort As System.Windows.Forms.Label
    Friend WithEvents ficheStructure_responsableTelPort As System.Windows.Forms.TextBox
    Friend WithEvents label_ficheStructure_responsableTelFax As System.Windows.Forms.Label
    Friend WithEvents ficheStructure_responsableTelFax As System.Windows.Forms.TextBox
    Friend WithEvents grpContact As System.Windows.Forms.GroupBox
    Friend WithEvents grpResponsable As System.Windows.Forms.GroupBox
    Friend WithEvents ficheStructure_responsableNom As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ficheStructure_type As System.Windows.Forms.ComboBox
    Friend WithEvents btn_ficheStructure_annuler As System.Windows.Forms.Label
    Friend WithEvents ficheStructure_contactNom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ficheStructure_contactPrenom As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbCommentaire As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ficheStructure_idCrodip As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestion_structures))
        Me.panel_clientele_ficheClient_fichePulve = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ficheStructure_type = New System.Windows.Forms.ComboBox()
        Me.grpContact = New System.Windows.Forms.GroupBox()
        Me.ficheStructure_responsableTelFixe = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ficheStructure_responsableCommune = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ficheStructure_responsableCodePostal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ficheStructure_responsableAdresse = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.label_ficheStructure_responsableTelPort = New System.Windows.Forms.Label()
        Me.ficheStructure_responsableTelPort = New System.Windows.Forms.TextBox()
        Me.label_ficheStructure_responsableTelFax = New System.Windows.Forms.Label()
        Me.ficheStructure_responsableTelFax = New System.Windows.Forms.TextBox()
        Me.ficheStructure_responsableEmail = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ficheStructure_contactNom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ficheStructure_contactPrenom = New System.Windows.Forms.TextBox()
        Me.ficheStructure_nom = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_fichePulve_idCrodip = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpResponsable = New System.Windows.Forms.GroupBox()
        Me.ficheStructure_responsableNom = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btn_ficheStructure_annuler = New System.Windows.Forms.Label()
        Me.ficheStructure_idCrodip = New System.Windows.Forms.TextBox()
        Me.ficheStructure_id = New System.Windows.Forms.TextBox()
        Me.tbCommentaire = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.panel_clientele_ficheClient_fichePulve.SuspendLayout()
        Me.grpContact.SuspendLayout()
        Me.grpResponsable.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_clientele_ficheClient_fichePulve
        '
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.tbCommentaire)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.Label13)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.Label10)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.ficheStructure_type)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.grpContact)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.ficheStructure_nom)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.Label3)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.Label2)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.lbl_fichePulve_idCrodip)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.Label1)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.grpResponsable)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.btn_ficheStructure_annuler)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.ficheStructure_idCrodip)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.ficheStructure_id)
        Me.panel_clientele_ficheClient_fichePulve.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_clientele_ficheClient_fichePulve.Location = New System.Drawing.Point(0, 0)
        Me.panel_clientele_ficheClient_fichePulve.Name = "panel_clientele_ficheClient_fichePulve"
        Me.panel_clientele_ficheClient_fichePulve.Size = New System.Drawing.Size(536, 491)
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
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Pour tout changement de coordonnées, contactez l’organisme CRODIP"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ficheStructure_type
        '
        Me.ficheStructure_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ficheStructure_type.Enabled = False
        Me.ficheStructure_type.Location = New System.Drawing.Point(144, 72)
        Me.ficheStructure_type.Name = "ficheStructure_type"
        Me.ficheStructure_type.Size = New System.Drawing.Size(144, 21)
        Me.ficheStructure_type.TabIndex = 23
        '
        'grpContact
        '
        Me.grpContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContact.Controls.Add(Me.ficheStructure_responsableTelFixe)
        Me.grpContact.Controls.Add(Me.Label8)
        Me.grpContact.Controls.Add(Me.ficheStructure_responsableCommune)
        Me.grpContact.Controls.Add(Me.Label7)
        Me.grpContact.Controls.Add(Me.ficheStructure_responsableCodePostal)
        Me.grpContact.Controls.Add(Me.Label5)
        Me.grpContact.Controls.Add(Me.ficheStructure_responsableAdresse)
        Me.grpContact.Controls.Add(Me.Label6)
        Me.grpContact.Controls.Add(Me.label_ficheStructure_responsableTelPort)
        Me.grpContact.Controls.Add(Me.ficheStructure_responsableTelPort)
        Me.grpContact.Controls.Add(Me.label_ficheStructure_responsableTelFax)
        Me.grpContact.Controls.Add(Me.ficheStructure_responsableTelFax)
        Me.grpContact.Controls.Add(Me.ficheStructure_responsableEmail)
        Me.grpContact.Controls.Add(Me.Label11)
        Me.grpContact.Controls.Add(Me.ficheStructure_contactNom)
        Me.grpContact.Controls.Add(Me.Label4)
        Me.grpContact.Controls.Add(Me.Label9)
        Me.grpContact.Controls.Add(Me.ficheStructure_contactPrenom)
        Me.grpContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpContact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.grpContact.Location = New System.Drawing.Point(3, 216)
        Me.grpContact.Name = "grpContact"
        Me.grpContact.Size = New System.Drawing.Size(520, 232)
        Me.grpContact.TabIndex = 11
        Me.grpContact.TabStop = False
        Me.grpContact.Text = "Contact"
        '
        'ficheStructure_responsableTelFixe
        '
        Me.ficheStructure_responsableTelFixe.Location = New System.Drawing.Point(228, 112)
        Me.ficheStructure_responsableTelFixe.Name = "ficheStructure_responsableTelFixe"
        Me.ficheStructure_responsableTelFixe.ReadOnly = True
        Me.ficheStructure_responsableTelFixe.Size = New System.Drawing.Size(144, 20)
        Me.ficheStructure_responsableTelFixe.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(148, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Tél. Fixe :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheStructure_responsableCommune
        '
        Me.ficheStructure_responsableCommune.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheStructure_responsableCommune.Location = New System.Drawing.Point(276, 72)
        Me.ficheStructure_responsableCommune.Name = "ficheStructure_responsableCommune"
        Me.ficheStructure_responsableCommune.ReadOnly = True
        Me.ficheStructure_responsableCommune.Size = New System.Drawing.Size(224, 20)
        Me.ficheStructure_responsableCommune.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(188, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Commune :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheStructure_responsableCodePostal
        '
        Me.ficheStructure_responsableCodePostal.Location = New System.Drawing.Point(108, 72)
        Me.ficheStructure_responsableCodePostal.Name = "ficheStructure_responsableCodePostal"
        Me.ficheStructure_responsableCodePostal.ReadOnly = True
        Me.ficheStructure_responsableCodePostal.Size = New System.Drawing.Size(64, 20)
        Me.ficheStructure_responsableCodePostal.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(20, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Code Postal :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheStructure_responsableAdresse
        '
        Me.ficheStructure_responsableAdresse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheStructure_responsableAdresse.Location = New System.Drawing.Point(108, 48)
        Me.ficheStructure_responsableAdresse.Name = "ficheStructure_responsableAdresse"
        Me.ficheStructure_responsableAdresse.ReadOnly = True
        Me.ficheStructure_responsableAdresse.Size = New System.Drawing.Size(392, 20)
        Me.ficheStructure_responsableAdresse.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(28, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Adresse :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'label_ficheStructure_responsableTelPort
        '
        Me.label_ficheStructure_responsableTelPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_ficheStructure_responsableTelPort.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.label_ficheStructure_responsableTelPort.Location = New System.Drawing.Point(148, 136)
        Me.label_ficheStructure_responsableTelPort.Name = "label_ficheStructure_responsableTelPort"
        Me.label_ficheStructure_responsableTelPort.Size = New System.Drawing.Size(72, 16)
        Me.label_ficheStructure_responsableTelPort.TabIndex = 19
        Me.label_ficheStructure_responsableTelPort.Text = "Tél. Port. :"
        Me.label_ficheStructure_responsableTelPort.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheStructure_responsableTelPort
        '
        Me.ficheStructure_responsableTelPort.Location = New System.Drawing.Point(228, 136)
        Me.ficheStructure_responsableTelPort.Name = "ficheStructure_responsableTelPort"
        Me.ficheStructure_responsableTelPort.ReadOnly = True
        Me.ficheStructure_responsableTelPort.Size = New System.Drawing.Size(144, 20)
        Me.ficheStructure_responsableTelPort.TabIndex = 20
        '
        'label_ficheStructure_responsableTelFax
        '
        Me.label_ficheStructure_responsableTelFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_ficheStructure_responsableTelFax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.label_ficheStructure_responsableTelFax.Location = New System.Drawing.Point(148, 160)
        Me.label_ficheStructure_responsableTelFax.Name = "label_ficheStructure_responsableTelFax"
        Me.label_ficheStructure_responsableTelFax.Size = New System.Drawing.Size(72, 16)
        Me.label_ficheStructure_responsableTelFax.TabIndex = 19
        Me.label_ficheStructure_responsableTelFax.Text = "Fax :"
        Me.label_ficheStructure_responsableTelFax.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheStructure_responsableTelFax
        '
        Me.ficheStructure_responsableTelFax.Location = New System.Drawing.Point(228, 160)
        Me.ficheStructure_responsableTelFax.Name = "ficheStructure_responsableTelFax"
        Me.ficheStructure_responsableTelFax.ReadOnly = True
        Me.ficheStructure_responsableTelFax.Size = New System.Drawing.Size(144, 20)
        Me.ficheStructure_responsableTelFax.TabIndex = 20
        '
        'ficheStructure_responsableEmail
        '
        Me.ficheStructure_responsableEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheStructure_responsableEmail.Location = New System.Drawing.Point(108, 200)
        Me.ficheStructure_responsableEmail.Name = "ficheStructure_responsableEmail"
        Me.ficheStructure_responsableEmail.ReadOnly = True
        Me.ficheStructure_responsableEmail.Size = New System.Drawing.Size(392, 20)
        Me.ficheStructure_responsableEmail.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(28, 200)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "E-mail :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheStructure_contactNom
        '
        Me.ficheStructure_contactNom.Location = New System.Drawing.Point(108, 16)
        Me.ficheStructure_contactNom.Name = "ficheStructure_contactNom"
        Me.ficheStructure_contactNom.ReadOnly = True
        Me.ficheStructure_contactNom.Size = New System.Drawing.Size(144, 20)
        Me.ficheStructure_contactNom.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(60, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Nom :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(292, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Prénom :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheStructure_contactPrenom
        '
        Me.ficheStructure_contactPrenom.Location = New System.Drawing.Point(356, 16)
        Me.ficheStructure_contactPrenom.Name = "ficheStructure_contactPrenom"
        Me.ficheStructure_contactPrenom.ReadOnly = True
        Me.ficheStructure_contactPrenom.Size = New System.Drawing.Size(144, 20)
        Me.ficheStructure_contactPrenom.TabIndex = 10
        '
        'ficheStructure_nom
        '
        Me.ficheStructure_nom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheStructure_nom.Location = New System.Drawing.Point(144, 99)
        Me.ficheStructure_nom.Name = "ficheStructure_nom"
        Me.ficheStructure_nom.ReadOnly = True
        Me.ficheStructure_nom.Size = New System.Drawing.Size(376, 20)
        Me.ficheStructure_nom.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(96, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Nom :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(40, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Type :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
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
        Me.lbl_fichePulve_idCrodip.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "     Coordonnées de l’organisme"
        '
        'grpResponsable
        '
        Me.grpResponsable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResponsable.Controls.Add(Me.ficheStructure_responsableNom)
        Me.grpResponsable.Controls.Add(Me.Label12)
        Me.grpResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpResponsable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.grpResponsable.Location = New System.Drawing.Point(0, 154)
        Me.grpResponsable.Name = "grpResponsable"
        Me.grpResponsable.Size = New System.Drawing.Size(520, 56)
        Me.grpResponsable.TabIndex = 11
        Me.grpResponsable.TabStop = False
        Me.grpResponsable.Text = "Responsable"
        '
        'ficheStructure_responsableNom
        '
        Me.ficheStructure_responsableNom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ficheStructure_responsableNom.Location = New System.Drawing.Point(108, 24)
        Me.ficheStructure_responsableNom.Name = "ficheStructure_responsableNom"
        Me.ficheStructure_responsableNom.ReadOnly = True
        Me.ficheStructure_responsableNom.Size = New System.Drawing.Size(392, 20)
        Me.ficheStructure_responsableNom.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(52, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 16)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Nom :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btn_ficheStructure_annuler
        '
        Me.btn_ficheStructure_annuler.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ficheStructure_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheStructure_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheStructure_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_ficheStructure_annuler.Image = CType(resources.GetObject("btn_ficheStructure_annuler.Image"), System.Drawing.Image)
        Me.btn_ficheStructure_annuler.Location = New System.Drawing.Point(204, 451)
        Me.btn_ficheStructure_annuler.Name = "btn_ficheStructure_annuler"
        Me.btn_ficheStructure_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheStructure_annuler.TabIndex = 26
        Me.btn_ficheStructure_annuler.Text = "    Fermer"
        Me.btn_ficheStructure_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ficheStructure_idCrodip
        '
        Me.ficheStructure_idCrodip.Location = New System.Drawing.Point(144, 46)
        Me.ficheStructure_idCrodip.Name = "ficheStructure_idCrodip"
        Me.ficheStructure_idCrodip.ReadOnly = True
        Me.ficheStructure_idCrodip.Size = New System.Drawing.Size(144, 20)
        Me.ficheStructure_idCrodip.TabIndex = 28
        '
        'ficheStructure_id
        '
        Me.ficheStructure_id.Location = New System.Drawing.Point(144, 46)
        Me.ficheStructure_id.Name = "ficheStructure_id"
        Me.ficheStructure_id.ReadOnly = True
        Me.ficheStructure_id.Size = New System.Drawing.Size(144, 20)
        Me.ficheStructure_id.TabIndex = 4
        Me.ficheStructure_id.Visible = False
        '
        'tbCommentaire
        '
        Me.tbCommentaire.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCommentaire.Location = New System.Drawing.Point(144, 125)
        Me.tbCommentaire.Name = "tbCommentaire"
        Me.tbCommentaire.ReadOnly = True
        Me.tbCommentaire.Size = New System.Drawing.Size(376, 20)
        Me.tbCommentaire.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(43, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 20)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Commentaire :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'gestion_structures
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 491)
        Me.ControlBox = False
        Me.Controls.Add(Me.panel_clientele_ficheClient_fichePulve)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "gestion_structures"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Coordonnées de l’organisme"
        Me.TopMost = True
        Me.panel_clientele_ficheClient_fichePulve.ResumeLayout(False)
        Me.panel_clientele_ficheClient_fichePulve.PerformLayout()
        Me.grpContact.ResumeLayout(False)
        Me.grpContact.PerformLayout()
        Me.grpResponsable.ResumeLayout(False)
        Me.grpResponsable.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub gestion_structures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' On récupère la structure de l'agent courant
        Dim objStructure As New Structuree
        objStructure = StructureManager.getStructureById(agentCourant.idStructure)
        ' On charge les données
        ficheStructure_id.Text = objStructure.id
        ficheStructure_idCrodip.Text = objStructure.idCrodip
        ficheStructure_nom.Text = objStructure.nom
        ficheStructure_type.Text = objStructure.type
        ficheStructure_responsableNom.Text = objStructure.nomResponsable
        ficheStructure_contactNom.Text = objStructure.nomContact
        ficheStructure_contactPrenom.Text = objStructure.prenomContact
        ficheStructure_responsableAdresse.Text = objStructure.adresse
        ficheStructure_responsableCodePostal.Text = objStructure.codePostal
        ficheStructure_responsableCommune.Text = objStructure.commune
        ficheStructure_responsableTelFixe.Text = objStructure.telephoneFixe
        ficheStructure_responsableTelPort.Text = objStructure.telephonePortable
        ficheStructure_responsableTelFax.Text = objStructure.telephoneFax
        ficheStructure_responsableEmail.Text = objStructure.eMail
        tbCommentaire.Text = objStructure.commentaire
    End Sub

    Private Sub ficheStructure_responsableTelFixe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheStructure_responsableTelFixe.KeyPress
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 10)
        End If
    End Sub

    Private Sub ficheStructure_responsableTelPort_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheStructure_responsableTelPort.KeyPress
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 10)
        End If
    End Sub

    Private Sub ficheStructure_responsableTelFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheStructure_responsableTelFax.KeyPress
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 10)
        End If
    End Sub

    ' Validation
    Private Sub btn_ficheStructure_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_FICHESTRUCTURE_ENCOURS, True)
        Try
            Dim objStructure As New Structuree
            ' On enregistre les données
            objStructure.id = CInt(ficheStructure_id.Text)
            objStructure.idCrodip = ficheStructure_idCrodip.Text
            objStructure.nom = ficheStructure_nom.Text
            objStructure.type = ficheStructure_type.Text
            objStructure.nomResponsable = ficheStructure_responsableNom.Text
            objStructure.nomContact = ficheStructure_contactNom.Text
            objStructure.prenomContact = ficheStructure_contactPrenom.Text
            objStructure.adresse = ficheStructure_responsableAdresse.Text()
            objStructure.codePostal = ficheStructure_responsableCodePostal.Text
            objStructure.commune = ficheStructure_responsableCommune.Text
            objStructure.telephoneFixe = ficheStructure_responsableTelFixe.Text
            objStructure.telephonePortable = ficheStructure_responsableTelPort.Text
            objStructure.telephoneFax = ficheStructure_responsableTelFax.Text
            objStructure.eMail = ficheStructure_responsableEmail.Text
            objStructure.commentaire = tbCommentaire.Text

            StructureManager.save(objStructure)

            Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_FICHESTRUCTURE_OK, False)

            ' On ferme le formulaire
            Me.Close()
        Catch ex As Exception
            CSDebug.dispError("Fiche structure - Save : " & ex.Message)
            Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_FICHESTRUCTURE_FAILED, False)
        End Try
    End Sub

    ' Annulation
    Private Sub btn_ficheStructure_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheStructure_annuler.Click
        Statusbar.clear()
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

End Class
