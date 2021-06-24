Imports System.Collections.Generic

Public Class diagnostic_contexte
    Inherits System.Windows.Forms.Form

#Region " - Vars - "
    Private m_DiagMode As Globals.DiagMode
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbNomPrenomRepresentant As System.Windows.Forms.TextBox
    Friend WithEvents LabelInspecteurPrecedent As System.Windows.Forms.Label
    Friend WithEvents tbCtrlPart_Inspecteur As System.Windows.Forms.TextBox
    Friend WithEvents tbCtrlPart_Organisme As System.Windows.Forms.TextBox
    Friend WithEvents LabelOrganismePrecedent As System.Windows.Forms.Label
    Friend WithEvents btnChezProp As System.Windows.Forms.Button
    Friend WithEvents btnDernControle As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxModeUtilisation As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxNbreExploitants As System.Windows.Forms.ComboBox
    Friend WithEvents lblNbreExploitants As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlreparOuiNon As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rbReparNon As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
    Friend WithEvents rbReparOui As System.Windows.Forms.RadioButton
    Friend WithEvents pnlAutoControleOuiNon As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbAutoControleNon As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbAutoControleOui As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlprecontroleOuiNon As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbPrecontroleNon As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrecontroleOui As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private m_Retour As Boolean

    Private m_NextForm As Form

    Protected m_diagnostic As Diagnostic
    Protected m_Pulverisateur As Pulverisateur
    Friend WithEvents m_bsCommune As BindingSource
    Protected ClientCourant As Exploitation
#End Region

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub
    Public Sub New(ByVal pDiagMode As Globals.DiagMode, pDiag As Diagnostic, pPulve As Pulverisateur, pExploit As Exploitation, ByVal pRetour As Boolean)
        Me.New()
        Me.m_Retour = pRetour
        Me.m_DiagMode = pDiagMode
        m_diagnostic = pDiag
        m_Pulverisateur = pPulve
        ClientCourant = pExploit
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_retour As System.Windows.Forms.Label
    Friend WithEvents btn_poursuivre As System.Windows.Forms.Label
    Friend WithEvents isPremierControle As System.Windows.Forms.CheckBox
    Friend WithEvents dateDernierControleComplet As System.Windows.Forms.DateTimePicker
    Friend WithEvents isControleComplet As System.Windows.Forms.RadioButton
    Friend WithEvents isControlePartiel As System.Windows.Forms.RadioButton
    Friend WithEvents dateDernierControlePartiel As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelDateDernierControle As System.Windows.Forms.Label
    Friend WithEvents labelDateDernierControlePartiel As System.Windows.Forms.Label
    Friend WithEvents tbcodePostal As System.Windows.Forms.TextBox
    Friend WithEvents tbnomSite As System.Windows.Forms.TextBox
    Friend WithEvents ckisRecuperationResidus As System.Windows.Forms.CheckBox
    Friend WithEvents ckisSiteSecurise As System.Windows.Forms.CheckBox
    Friend WithEvents cbxSite As System.Windows.Forms.ComboBox
    Friend WithEvents cbxcommune As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_contexte))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnChezProp = New System.Windows.Forms.Button()
        Me.btnDernControle = New System.Windows.Forms.Button()
        Me.tbNomPrenomRepresentant = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxcommune = New System.Windows.Forms.ComboBox()
        Me.m_bsCommune = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbcodePostal = New System.Windows.Forms.TextBox()
        Me.tbnomSite = New System.Windows.Forms.TextBox()
        Me.ckisRecuperationResidus = New System.Windows.Forms.CheckBox()
        Me.ckisSiteSecurise = New System.Windows.Forms.CheckBox()
        Me.cbxSite = New System.Windows.Forms.ComboBox()
        Me.isPremierControle = New System.Windows.Forms.CheckBox()
        Me.labelDateDernierControle = New System.Windows.Forms.Label()
        Me.dateDernierControleComplet = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabelInspecteurPrecedent = New System.Windows.Forms.Label()
        Me.tbCtrlPart_Inspecteur = New System.Windows.Forms.TextBox()
        Me.tbCtrlPart_Organisme = New System.Windows.Forms.TextBox()
        Me.LabelOrganismePrecedent = New System.Windows.Forms.Label()
        Me.isControleComplet = New System.Windows.Forms.RadioButton()
        Me.isControlePartiel = New System.Windows.Forms.RadioButton()
        Me.dateDernierControlePartiel = New System.Windows.Forms.DateTimePicker()
        Me.labelDateDernierControlePartiel = New System.Windows.Forms.Label()
        Me.btn_poursuivre = New System.Windows.Forms.Label()
        Me.btn_retour = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbxNbreExploitants = New System.Windows.Forms.ComboBox()
        Me.lblNbreExploitants = New System.Windows.Forms.Label()
        Me.cbxModeUtilisation = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.pnlreparOuiNon = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.rbReparNon = New System.Windows.Forms.RadioButton()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.rbReparOui = New System.Windows.Forms.RadioButton()
        Me.pnlAutoControleOuiNon = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbAutoControleNon = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.rbAutoControleOui = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlprecontroleOuiNon = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rbPrecontroleNon = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.rbPrecontroleOui = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.m_bsCommune, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.pnlreparOuiNon.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlAutoControleOuiNon.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlprecontroleOuiNon.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnChezProp)
        Me.GroupBox1.Controls.Add(Me.btnDernControle)
        Me.GroupBox1.Controls.Add(Me.tbNomPrenomRepresentant)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbxcommune)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbcodePostal)
        Me.GroupBox1.Controls.Add(Me.tbnomSite)
        Me.GroupBox1.Controls.Add(Me.ckisRecuperationResidus)
        Me.GroupBox1.Controls.Add(Me.ckisSiteSecurise)
        Me.GroupBox1.Controls.Add(Me.cbxSite)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(484, 198)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lieu de contrôle"
        '
        'btnChezProp
        '
        Me.btnChezProp.Location = New System.Drawing.Point(11, 62)
        Me.btnChezProp.Name = "btnChezProp"
        Me.btnChezProp.Size = New System.Drawing.Size(82, 40)
        Me.btnChezProp.TabIndex = 9
        Me.btnChezProp.Text = "Chez Propriétaire"
        Me.btnChezProp.UseVisualStyleBackColor = True
        '
        'btnDernControle
        '
        Me.btnDernControle.Location = New System.Drawing.Point(11, 16)
        Me.btnDernControle.Name = "btnDernControle"
        Me.btnDernControle.Size = New System.Drawing.Size(82, 40)
        Me.btnDernControle.TabIndex = 8
        Me.btnDernControle.Text = "Dernier contrôle"
        Me.btnDernControle.UseVisualStyleBackColor = True
        '
        'tbNomPrenomRepresentant
        '
        Me.tbNomPrenomRepresentant.Location = New System.Drawing.Point(193, 149)
        Me.tbNomPrenomRepresentant.Name = "tbNomPrenomRepresentant"
        Me.tbNomPrenomRepresentant.Size = New System.Drawing.Size(232, 20)
        Me.tbNomPrenomRepresentant.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 38)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Nom et prénom du représentant du propriétaire :"
        '
        'cbxcommune
        '
        Me.cbxcommune.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxcommune.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxcommune.DataSource = Me.m_bsCommune
        Me.cbxcommune.DisplayMember = "Nom"
        Me.cbxcommune.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxcommune.Location = New System.Drawing.Point(193, 42)
        Me.cbxcommune.Name = "cbxcommune"
        Me.cbxcommune.Size = New System.Drawing.Size(160, 21)
        Me.cbxcommune.TabIndex = 1
        '
        'm_bsCommune
        '
        Me.m_bsCommune.DataSource = GetType(Crodip_agent.Commune)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Commune : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Code postal : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(80, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Site : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(80, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nom du site : "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbcodePostal
        '
        Me.tbcodePostal.Location = New System.Drawing.Point(193, 16)
        Me.tbcodePostal.Name = "tbcodePostal"
        Me.tbcodePostal.Size = New System.Drawing.Size(56, 20)
        Me.tbcodePostal.TabIndex = 0
        '
        'tbnomSite
        '
        Me.tbnomSite.Location = New System.Drawing.Point(193, 96)
        Me.tbnomSite.Name = "tbnomSite"
        Me.tbnomSite.Size = New System.Drawing.Size(160, 20)
        Me.tbnomSite.TabIndex = 3
        '
        'ckisRecuperationResidus
        '
        Me.ckisRecuperationResidus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckisRecuperationResidus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ckisRecuperationResidus.Location = New System.Drawing.Point(200, 175)
        Me.ckisRecuperationResidus.Name = "ckisRecuperationResidus"
        Me.ckisRecuperationResidus.Size = New System.Drawing.Size(227, 17)
        Me.ckisRecuperationResidus.TabIndex = 7
        Me.ckisRecuperationResidus.Text = "Récupération des résidus"
        Me.ckisRecuperationResidus.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ckisSiteSecurise
        '
        Me.ckisSiteSecurise.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckisSiteSecurise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ckisSiteSecurise.Location = New System.Drawing.Point(39, 176)
        Me.ckisSiteSecurise.Name = "ckisSiteSecurise"
        Me.ckisSiteSecurise.Size = New System.Drawing.Size(136, 16)
        Me.ckisSiteSecurise.TabIndex = 6
        Me.ckisSiteSecurise.Text = "Site sécurisé"
        Me.ckisSiteSecurise.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cbxSite
        '
        Me.cbxSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSite.Location = New System.Drawing.Point(193, 69)
        Me.cbxSite.Name = "cbxSite"
        Me.cbxSite.Size = New System.Drawing.Size(160, 21)
        Me.cbxSite.TabIndex = 2
        '
        'isPremierControle
        '
        Me.isPremierControle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.isPremierControle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.isPremierControle.Location = New System.Drawing.Point(180, 24)
        Me.isPremierControle.Name = "isPremierControle"
        Me.isPremierControle.Size = New System.Drawing.Size(104, 16)
        Me.isPremierControle.TabIndex = 1
        Me.isPremierControle.Text = "1er contrôle ?"
        Me.isPremierControle.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'labelDateDernierControle
        '
        Me.labelDateDernierControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelDateDernierControle.Location = New System.Drawing.Point(37, 38)
        Me.labelDateDernierControle.Name = "labelDateDernierControle"
        Me.labelDateDernierControle.Size = New System.Drawing.Size(161, 20)
        Me.labelDateDernierControle.TabIndex = 1
        Me.labelDateDernierControle.Text = "Date du dernier contrôle : "
        Me.labelDateDernierControle.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'dateDernierControleComplet
        '
        Me.dateDernierControleComplet.Location = New System.Drawing.Point(204, 40)
        Me.dateDernierControleComplet.Name = "dateDernierControleComplet"
        Me.dateDernierControleComplet.Size = New System.Drawing.Size(196, 20)
        Me.dateDernierControleComplet.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LabelInspecteurPrecedent)
        Me.GroupBox2.Controls.Add(Me.tbCtrlPart_Inspecteur)
        Me.GroupBox2.Controls.Add(Me.tbCtrlPart_Organisme)
        Me.GroupBox2.Controls.Add(Me.LabelOrganismePrecedent)
        Me.GroupBox2.Controls.Add(Me.isControleComplet)
        Me.GroupBox2.Controls.Add(Me.isPremierControle)
        Me.GroupBox2.Controls.Add(Me.dateDernierControleComplet)
        Me.GroupBox2.Controls.Add(Me.labelDateDernierControle)
        Me.GroupBox2.Controls.Add(Me.isControlePartiel)
        Me.GroupBox2.Controls.Add(Me.dateDernierControlePartiel)
        Me.GroupBox2.Controls.Add(Me.labelDateDernierControlePartiel)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 284)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(485, 173)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Type de contrôle"
        '
        'LabelInspecteurPrecedent
        '
        Me.LabelInspecteurPrecedent.Enabled = False
        Me.LabelInspecteurPrecedent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInspecteurPrecedent.Location = New System.Drawing.Point(34, 144)
        Me.LabelInspecteurPrecedent.Name = "LabelInspecteurPrecedent"
        Me.LabelInspecteurPrecedent.Size = New System.Drawing.Size(161, 15)
        Me.LabelInspecteurPrecedent.TabIndex = 8
        Me.LabelInspecteurPrecedent.Text = "Inspecteur :"
        Me.LabelInspecteurPrecedent.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbCtrlPart_Inspecteur
        '
        Me.tbCtrlPart_Inspecteur.Location = New System.Drawing.Point(201, 142)
        Me.tbCtrlPart_Inspecteur.Name = "tbCtrlPart_Inspecteur"
        Me.tbCtrlPart_Inspecteur.Size = New System.Drawing.Size(196, 20)
        Me.tbCtrlPart_Inspecteur.TabIndex = 7
        '
        'tbCtrlPart_Organisme
        '
        Me.tbCtrlPart_Organisme.Location = New System.Drawing.Point(201, 116)
        Me.tbCtrlPart_Organisme.Name = "tbCtrlPart_Organisme"
        Me.tbCtrlPart_Organisme.Size = New System.Drawing.Size(196, 20)
        Me.tbCtrlPart_Organisme.TabIndex = 6
        '
        'LabelOrganismePrecedent
        '
        Me.LabelOrganismePrecedent.Enabled = False
        Me.LabelOrganismePrecedent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOrganismePrecedent.Location = New System.Drawing.Point(34, 118)
        Me.LabelOrganismePrecedent.Name = "LabelOrganismePrecedent"
        Me.LabelOrganismePrecedent.Size = New System.Drawing.Size(161, 15)
        Me.LabelOrganismePrecedent.TabIndex = 5
        Me.LabelOrganismePrecedent.Text = "Organisme d'inspection :"
        Me.LabelOrganismePrecedent.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'isControleComplet
        '
        Me.isControleComplet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.isControleComplet.Checked = True
        Me.isControleComplet.Location = New System.Drawing.Point(48, 24)
        Me.isControleComplet.Name = "isControleComplet"
        Me.isControleComplet.Size = New System.Drawing.Size(124, 16)
        Me.isControleComplet.TabIndex = 0
        Me.isControleComplet.TabStop = True
        Me.isControleComplet.Text = "Contrôle complet"
        Me.isControleComplet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'isControlePartiel
        '
        Me.isControlePartiel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.isControlePartiel.Location = New System.Drawing.Point(57, 72)
        Me.isControlePartiel.Name = "isControlePartiel"
        Me.isControlePartiel.Size = New System.Drawing.Size(112, 16)
        Me.isControlePartiel.TabIndex = 3
        Me.isControlePartiel.Text = "Contrôle partiel"
        Me.isControlePartiel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dateDernierControlePartiel
        '
        Me.dateDernierControlePartiel.Enabled = False
        Me.dateDernierControlePartiel.Location = New System.Drawing.Point(201, 88)
        Me.dateDernierControlePartiel.Name = "dateDernierControlePartiel"
        Me.dateDernierControlePartiel.Size = New System.Drawing.Size(196, 20)
        Me.dateDernierControlePartiel.TabIndex = 4
        '
        'labelDateDernierControlePartiel
        '
        Me.labelDateDernierControlePartiel.Enabled = False
        Me.labelDateDernierControlePartiel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelDateDernierControlePartiel.Location = New System.Drawing.Point(51, 92)
        Me.labelDateDernierControlePartiel.Name = "labelDateDernierControlePartiel"
        Me.labelDateDernierControlePartiel.Size = New System.Drawing.Size(144, 16)
        Me.labelDateDernierControlePartiel.TabIndex = 1
        Me.labelDateDernierControlePartiel.Text = "Suite à un contrôle du : "
        Me.labelDateDernierControlePartiel.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btn_poursuivre
        '
        Me.btn_poursuivre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_poursuivre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_poursuivre.ForeColor = System.Drawing.Color.White
        Me.btn_poursuivre.Image = CType(resources.GetObject("btn_poursuivre.Image"), System.Drawing.Image)
        Me.btn_poursuivre.Location = New System.Drawing.Point(364, 605)
        Me.btn_poursuivre.Name = "btn_poursuivre"
        Me.btn_poursuivre.Size = New System.Drawing.Size(128, 24)
        Me.btn_poursuivre.TabIndex = 4
        Me.btn_poursuivre.Text = "    Poursuivre"
        Me.btn_poursuivre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_retour
        '
        Me.btn_retour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_retour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_retour.ForeColor = System.Drawing.Color.White
        Me.btn_retour.Image = CType(resources.GetObject("btn_retour.Image"), System.Drawing.Image)
        Me.btn_retour.Location = New System.Drawing.Point(12, 605)
        Me.btn_retour.Name = "btn_retour"
        Me.btn_retour.Size = New System.Drawing.Size(128, 24)
        Me.btn_retour.TabIndex = 3
        Me.btn_retour.Text = "    Retour"
        Me.btn_retour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbxNbreExploitants)
        Me.GroupBox3.Controls.Add(Me.lblNbreExploitants)
        Me.GroupBox3.Controls.Add(Me.cbxModeUtilisation)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(8, 212)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(484, 66)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        '
        'cbxNbreExploitants
        '
        Me.cbxNbreExploitants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNbreExploitants.Location = New System.Drawing.Point(315, 42)
        Me.cbxNbreExploitants.Name = "cbxNbreExploitants"
        Me.cbxNbreExploitants.Size = New System.Drawing.Size(84, 21)
        Me.cbxNbreExploitants.TabIndex = 7
        '
        'lblNbreExploitants
        '
        Me.lblNbreExploitants.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNbreExploitants.Location = New System.Drawing.Point(8, 39)
        Me.lblNbreExploitants.Name = "lblNbreExploitants"
        Me.lblNbreExploitants.Size = New System.Drawing.Size(211, 16)
        Me.lblNbreExploitants.TabIndex = 6
        Me.lblNbreExploitants.Text = "Nombre d'exploitants :"
        Me.lblNbreExploitants.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cbxModeUtilisation
        '
        Me.cbxModeUtilisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxModeUtilisation.Location = New System.Drawing.Point(219, 15)
        Me.cbxModeUtilisation.Name = "cbxModeUtilisation"
        Me.cbxModeUtilisation.Size = New System.Drawing.Size(180, 21)
        Me.cbxModeUtilisation.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(211, 16)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Mode d'utilisation du pulvérisateur : "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.pnlreparOuiNon)
        Me.GroupBox4.Controls.Add(Me.pnlAutoControleOuiNon)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.pnlprecontroleOuiNon)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 463)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(482, 135)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        '
        'pnlreparOuiNon
        '
        Me.pnlreparOuiNon.Controls.Add(Me.Label13)
        Me.pnlreparOuiNon.Controls.Add(Me.rbReparNon)
        Me.pnlreparOuiNon.Controls.Add(Me.Panel6)
        Me.pnlreparOuiNon.Controls.Add(Me.rbReparOui)
        Me.pnlreparOuiNon.Location = New System.Drawing.Point(382, 99)
        Me.pnlreparOuiNon.Name = "pnlreparOuiNon"
        Me.pnlreparOuiNon.Size = New System.Drawing.Size(91, 23)
        Me.pnlreparOuiNon.TabIndex = 21
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(-380, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(383, 17)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Un pré-contrôle a été réalisé par un professionel ? "
        '
        'rbReparNon
        '
        Me.rbReparNon.AutoSize = True
        Me.rbReparNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbReparNon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbReparNon.Location = New System.Drawing.Point(46, 3)
        Me.rbReparNon.Name = "rbReparNon"
        Me.rbReparNon.Size = New System.Drawing.Size(46, 17)
        Me.rbReparNon.TabIndex = 8
        Me.rbReparNon.TabStop = True
        Me.rbReparNon.Text = "non"
        Me.rbReparNon.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.RadioButton8)
        Me.Panel6.Controls.Add(Me.RadioButton9)
        Me.Panel6.Location = New System.Drawing.Point(3, 23)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(91, 23)
        Me.Panel6.TabIndex = 11
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RadioButton8.Location = New System.Drawing.Point(46, 3)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(46, 17)
        Me.RadioButton8.TabIndex = 8
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Text = "non"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RadioButton9.Location = New System.Drawing.Point(6, 3)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(42, 17)
        Me.RadioButton9.TabIndex = 7
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Text = "oui"
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'rbReparOui
        '
        Me.rbReparOui.AutoSize = True
        Me.rbReparOui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbReparOui.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbReparOui.Location = New System.Drawing.Point(6, 3)
        Me.rbReparOui.Name = "rbReparOui"
        Me.rbReparOui.Size = New System.Drawing.Size(42, 17)
        Me.rbReparOui.TabIndex = 7
        Me.rbReparOui.TabStop = True
        Me.rbReparOui.Text = "oui"
        Me.rbReparOui.UseVisualStyleBackColor = True
        '
        'pnlAutoControleOuiNon
        '
        Me.pnlAutoControleOuiNon.Controls.Add(Me.Label12)
        Me.pnlAutoControleOuiNon.Controls.Add(Me.rbAutoControleNon)
        Me.pnlAutoControleOuiNon.Controls.Add(Me.Panel4)
        Me.pnlAutoControleOuiNon.Controls.Add(Me.rbAutoControleOui)
        Me.pnlAutoControleOuiNon.Location = New System.Drawing.Point(381, 70)
        Me.pnlAutoControleOuiNon.Name = "pnlAutoControleOuiNon"
        Me.pnlAutoControleOuiNon.Size = New System.Drawing.Size(91, 23)
        Me.pnlAutoControleOuiNon.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(-380, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(383, 17)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Un pré-contrôle a été réalisé par un professionel ? "
        '
        'rbAutoControleNon
        '
        Me.rbAutoControleNon.AutoSize = True
        Me.rbAutoControleNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAutoControleNon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbAutoControleNon.Location = New System.Drawing.Point(46, 3)
        Me.rbAutoControleNon.Name = "rbAutoControleNon"
        Me.rbAutoControleNon.Size = New System.Drawing.Size(46, 17)
        Me.rbAutoControleNon.TabIndex = 8
        Me.rbAutoControleNon.TabStop = True
        Me.rbAutoControleNon.Text = "non"
        Me.rbAutoControleNon.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.RadioButton4)
        Me.Panel4.Controls.Add(Me.RadioButton5)
        Me.Panel4.Location = New System.Drawing.Point(3, 23)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(91, 23)
        Me.Panel4.TabIndex = 11
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RadioButton4.Location = New System.Drawing.Point(46, 3)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(46, 17)
        Me.RadioButton4.TabIndex = 8
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "non"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RadioButton5.Location = New System.Drawing.Point(6, 3)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(42, 17)
        Me.RadioButton5.TabIndex = 7
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "oui"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'rbAutoControleOui
        '
        Me.rbAutoControleOui.AutoSize = True
        Me.rbAutoControleOui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAutoControleOui.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbAutoControleOui.Location = New System.Drawing.Point(6, 3)
        Me.rbAutoControleOui.Name = "rbAutoControleOui"
        Me.rbAutoControleOui.Size = New System.Drawing.Size(42, 17)
        Me.rbAutoControleOui.TabIndex = 7
        Me.rbAutoControleOui.TabStop = True
        Me.rbAutoControleOui.Text = "oui"
        Me.rbAutoControleOui.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(141, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(235, 17)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = " le pulvérisateur a été réparé ?"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(45, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(333, 17)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Le propriétaire a effectué un auto-contrôle ?"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(1, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(383, 17)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Un pré-contrôle a été réalisé par un professionel ? "
        '
        'pnlprecontroleOuiNon
        '
        Me.pnlprecontroleOuiNon.Controls.Add(Me.Label9)
        Me.pnlprecontroleOuiNon.Controls.Add(Me.rbPrecontroleNon)
        Me.pnlprecontroleOuiNon.Controls.Add(Me.Panel2)
        Me.pnlprecontroleOuiNon.Controls.Add(Me.rbPrecontroleOui)
        Me.pnlprecontroleOuiNon.Location = New System.Drawing.Point(381, 41)
        Me.pnlprecontroleOuiNon.Name = "pnlprecontroleOuiNon"
        Me.pnlprecontroleOuiNon.Size = New System.Drawing.Size(91, 23)
        Me.pnlprecontroleOuiNon.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(-380, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(383, 17)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Un pré-contrôle a été réalisé par un professionel ? "
        '
        'rbPrecontroleNon
        '
        Me.rbPrecontroleNon.AutoSize = True
        Me.rbPrecontroleNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPrecontroleNon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbPrecontroleNon.Location = New System.Drawing.Point(46, 3)
        Me.rbPrecontroleNon.Name = "rbPrecontroleNon"
        Me.rbPrecontroleNon.Size = New System.Drawing.Size(46, 17)
        Me.rbPrecontroleNon.TabIndex = 8
        Me.rbPrecontroleNon.TabStop = True
        Me.rbPrecontroleNon.Text = "non"
        Me.rbPrecontroleNon.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Location = New System.Drawing.Point(3, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(91, 23)
        Me.Panel2.TabIndex = 11
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RadioButton1.Location = New System.Drawing.Point(46, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(46, 17)
        Me.RadioButton1.TabIndex = 8
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "non"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RadioButton2.Location = New System.Drawing.Point(6, 3)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(42, 17)
        Me.RadioButton2.TabIndex = 7
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "oui"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'rbPrecontroleOui
        '
        Me.rbPrecontroleOui.AutoSize = True
        Me.rbPrecontroleOui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPrecontroleOui.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbPrecontroleOui.Location = New System.Drawing.Point(6, 3)
        Me.rbPrecontroleOui.Name = "rbPrecontroleOui"
        Me.rbPrecontroleOui.Size = New System.Drawing.Size(42, 17)
        Me.rbPrecontroleOui.TabIndex = 7
        Me.rbPrecontroleOui.TabStop = True
        Me.rbPrecontroleOui.Text = "oui"
        Me.rbPrecontroleOui.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(1, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(204, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Dans l’optique du contrôle,"
        '
        'diagnostic_contexte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 635)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btn_retour)
        Me.Controls.Add(Me.btn_poursuivre)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diagnostic_contexte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Contexte du contrôle"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.m_bsCommune, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.pnlreparOuiNon.ResumeLayout(False)
        Me.pnlreparOuiNon.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlAutoControleOuiNon.ResumeLayout(False)
        Me.pnlAutoControleOuiNon.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlprecontroleOuiNon.ResumeLayout(False)
        Me.pnlprecontroleOuiNon.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region



    ' Chargement
    Private Sub diagnostic_contexte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CSEnvironnement.checkDateTimePicker(dateDernierControleComplet)
        CSEnvironnement.checkDateTimePicker(dateDernierControlePartiel)

        If Globals.GLOB_ENV_MODESIMPLIFIE Then
            Me.Text = Me.Text & " - Mode Simplifié - "
        End If



        ' Chargement des comboBox
        Try
            Globals.GLOB_XML_CONFIG = New CSXml("config\config.xml")

            MarquesManager.populateCombobox(Globals.GLOB_XML_CONFIG, cbxSite, "/root/sites_proprietaire")
            '            MarquesManager.populateCombobox(Globals.GLOB_XML_CONFIG, cbxterritoire, "/root/territoires_proprietaire")
            'ModeUtilisation
            MarquesManager.populateCombobox(Globals.GLOB_XML_MODEUTILISATION, cbxModeUtilisation, "/root", True)
        Catch ex As Exception
            CSDebug.dispError("[Diag. Contexte] - Erreur chargement comboBox : " & ex.Message.ToString)
        End Try

        Try
            isControleComplet.Checked = m_diagnostic.controleIsComplet
            isControlePartiel.Checked = Not m_diagnostic.controleIsComplet
            If m_diagnostic.controleIsComplet Then
                If Not m_diagnostic.controleIsPremierControle Then
                    isPremierControle.Checked = False
                    dateDernierControleComplet.Text = m_diagnostic.controleDateDernierControle
                Else
                    isPremierControle.Checked = True
                End If
            Else
                dateDernierControlePartiel.Text = m_diagnostic.controleDateDernierControle
                tbCtrlPart_Organisme.Text = m_diagnostic.organismeOriginePresNom
                tbCtrlPart_Inspecteur.Text = m_diagnostic.inspecteurOrigineNom
            End If

            '            dateDernierControlePartiel.MinDate = DateAdd(DateInterval.Month, -4, Date.Today)
            'Rappel des derniers infos du contexte
            'If My.Settings.DernierControleInfosChezProp Then
            ' RappelInfosChezProprietaire()
            'Else
            'RappelInfosDernierControle()
            'End If
#If DEBUG Then
            cbxModeUtilisation.Text = "Individuel"
            rbAutoControleNon.Checked = CheckState.Checked
            rbPrecontroleOui.Checked = CheckState.Checked
            rbReparNon.Checked = CheckState.Checked
#End If


            cbxModeUtilisation.Text = m_diagnostic.pulverisateurModeUtilisation
            cbxNbreExploitants.Text = m_diagnostic.pulverisateurNbreExploitants
            'If m_Retour = False Then
            '    Exit Try
            'End If
            ' Chargement des infos
            tbcodePostal.Text = m_diagnostic.controleCodePostal
            If tbcodePostal.Text <> "" Then
                LoadCommunes(tbcodePostal.Text)
            End If
            cbxcommune.Text = m_diagnostic.controleCommune
            cbxSite.Text = m_diagnostic.controleSite
            tbnomSite.Text = m_diagnostic.controleNomSite
            tbNomPrenomRepresentant.Text = m_diagnostic.proprietaireRepresentant

            '            cbxterritoire.Text = m_diagnostic.controleTerritoire
            ckisSiteSecurise.Checked = m_diagnostic.controleIsSiteSecurise
            ckisRecuperationResidus.Checked = m_diagnostic.controleIsRecupResidus
            isPremierControle.Checked = m_diagnostic.controleIsPremierControle

            If m_diagnostic.isContrevisiteImmediate Or m_diagnostic.diagRemplacementId <> "" Then
                If m_diagnostic.controleIsPulveRepare Then
                    rbReparOui.Checked = CheckState.Checked
                Else
                    rbReparNon.Checked = CheckState.Checked
                End If
                If m_diagnostic.controleIsPreControleProfessionel Then
                    rbPrecontroleOui.Checked = CheckState.Checked
                Else
                    rbPrecontroleNon.Checked = CheckState.Checked
                End If
                If m_diagnostic.controleIsAutoControle Then
                    rbAutoControleOui.Checked = CheckState.Checked
                Else
                    rbAutoControleNon.Checked = CheckState.Checked
                End If
            End If

        Catch ex As Exception
            CSDebug.dispError("Diagnostic Contexte (loading data): " & ex.Message.ToString)
        End Try

    End Sub

    Private Function submitForm() As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            If isControlePartiel.Checked Then
                If tbCtrlPart_Inspecteur.Text = "" Or tbCtrlPart_Organisme.Text = "" Then
                    MsgBox("Vous devez renseigner l'organisme et l'inspecteur du controle d'origine")
                    bReturn = False
                End If
            End If
            'Insérrez ici tous les controles obligatoires
            If tbcodePostal.Text = "" Or cbxcommune.Text = "" Then
                MsgBox("Vous devez renseigner Le code postal et la commune du lieu du controle")
                bReturn = False
            End If
            If (rbAutoControleNon.Checked = CheckState.Unchecked And rbAutoControleOui.Checked = CheckState.Unchecked) Or
                (rbPrecontroleOui.Checked = CheckState.Unchecked And rbPrecontroleNon.Checked = CheckState.Unchecked) Or
                (rbReparNon.Checked = CheckState.Unchecked And rbReparOui.Checked = CheckState.Unchecked) Then

                MsgBox("Vous devez renseigner les actions préalables au contrôle (Pre-controle,Auto-controle,Réparation)")
                bReturn = False
            End If
            If cbxModeUtilisation.Text = "" Or (cbxNbreExploitants.Visible And cbxNbreExploitants.Text = "") Then
                MsgBox("Vous devez renseigner le mode d'utilisation du pulvérisateur")
                bReturn = False
            End If
            If bReturn Then
                m_diagnostic.controleCommune = cbxcommune.Text
                m_diagnostic.controleCodePostal = tbcodePostal.Text
                m_diagnostic.controleSite = cbxSite.Text
                m_diagnostic.controleNomSite = tbnomSite.Text
                m_diagnostic.controleLieu = tbcodePostal.Text & ", " & cbxcommune.Text
                'm_diagnostic.controleTerritoire = cbxterritoire.Text
                m_diagnostic.controleIsSiteSecurise = ckisSiteSecurise.Checked
                m_diagnostic.controleIsRecupResidus = ckisRecuperationResidus.Checked
                m_diagnostic.controleIsPremierControle = isPremierControle.Checked
                m_diagnostic.controleIsComplet = isControleComplet.Checked
                If isControleComplet.Checked Then
                    If Not isPremierControle.Checked Then
                        m_diagnostic.controleDateDernierControle = dateDernierControleComplet.Value.ToShortDateString
                    End If
                Else
                    m_diagnostic.organismeOriginePresNom = tbCtrlPart_Organisme.Text
                    m_diagnostic.inspecteurOrigineNom = tbCtrlPart_Inspecteur.Text
                    m_diagnostic.controleDateDernierControle = dateDernierControlePartiel.Value.ToShortDateString
                End If
                m_diagnostic.controleIsPulveRepare = rbReparOui.Checked
                m_diagnostic.controleIsPreControleProfessionel = rbPrecontroleOui.Checked
                m_diagnostic.controleIsAutoControle = rbAutoControleOui.Checked
                m_diagnostic.proprietaireRepresentant = Trim(tbNomPrenomRepresentant.Text)

                m_diagnostic.pulverisateurModeUtilisation = cbxModeUtilisation.Text
                m_diagnostic.pulverisateurNbreExploitants = cbxNbreExploitants.Text
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispError("Diagnostic Contexte : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Poursuivre
    Private Sub btn_poursuivre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_poursuivre.Click
        btn_poursuivre.Enabled = False
        If submitForm() Then
            Me.Cursor = Cursors.WaitCursor
            My.Settings.DernierControleCodePostal = tbcodePostal.Text
            My.Settings.DernierControleCommune = cbxcommune.Text
            My.Settings.DernierControleSite = cbxSite.Text
            My.Settings.DernierControleNomDuSite = tbnomSite.Text
            My.Settings.DernierControleNomRepresentant = tbNomPrenomRepresentant.Text
            'My.Settings.DernierControleTerritoire = cbxterritoire.Text
            My.Settings.DernierControleSiteSecurise = ckisSiteSecurise.Checked
            My.Settings.DernierControleRecupResidus = ckisRecuperationResidus.Checked
            My.Settings.Save()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            'Me.Close() elle sera fermée par la fenêtre appelante
            Me.Cursor = Cursors.Default

        Else
            btn_poursuivre.Enabled = True
        End If
    End Sub
    Public Function getNextForm() As Form
        Return m_NextForm
    End Function

    ' Retour
    Private Sub btn_retour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_retour.Click
        Statusbar.clear()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' 1er contrôle complet ?
    Private Sub isPremierControle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isPremierControle.CheckedChanged
        Dim checkBox As CheckBox = sender
        ' si controle complet, on desactive le reste
        If checkBox.Checked = True Then
            labelDateDernierControle.Enabled = False
            dateDernierControleComplet.Enabled = False
        Else
            labelDateDernierControle.Enabled = True
            dateDernierControleComplet.Enabled = True
        End If
    End Sub

    Private Sub isControleComplet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isControleComplet.CheckedChanged
        Dim checkBox As RadioButton = sender
        If checkBox.Checked = True Then
            isPremierControle.Enabled = True
            labelDateDernierControle.Enabled = True
            dateDernierControleComplet.Enabled = True
            labelDateDernierControlePartiel.Enabled = False
            dateDernierControlePartiel.Enabled = False
            LabelOrganismePrecedent.Enabled = True
            LabelInspecteurPrecedent.Enabled = True
            tbCtrlPart_Organisme.Enabled = False
            tbCtrlPart_Inspecteur.Enabled = False
        End If
    End Sub

    Private Sub isControlePartiel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isControlePartiel.CheckedChanged
        Dim checkBox As RadioButton = sender
        If checkBox.Checked = True Then
            isPremierControle.Enabled = False
            labelDateDernierControle.Enabled = False
            dateDernierControleComplet.Enabled = False
            labelDateDernierControlePartiel.Enabled = True
            dateDernierControlePartiel.Enabled = True
            LabelOrganismePrecedent.Enabled = True
            LabelInspecteurPrecedent.Enabled = True
            tbCtrlPart_Organisme.Enabled = True
            tbCtrlPart_Inspecteur.Enabled = True
        End If
    End Sub

    Private Sub isPrecontrolePro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub codePostal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbcodePostal.KeyPress
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 5)
        End If
    End Sub

    Private Sub btnDernControle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDernControle.Click
        RappelInfosDernierControle()
    End Sub

    Private Sub RappelInfosDernierControle()
        tbcodePostal.Text = My.Settings.DernierControleCodePostal
        m_bsCommune.Clear()
        Dim oReferentiel As ReferentielCommunesCSV
        Dim lstCommunes As List(Of Commune)
        oReferentiel = New ReferentielCommunesCSV()
        oReferentiel.load()
        m_bsCommune.Clear()
        lstCommunes = oReferentiel.getCommunes(My.Settings.DernierControleCodePostal)
        For Each sCommune As Commune In lstCommunes
            m_bsCommune.Add(sCommune)
        Next

        cbxcommune.Text = My.Settings.DernierControleCommune
        cbxSite.Text = My.Settings.DernierControleSite
        tbnomSite.Text = My.Settings.DernierControleNomDuSite
        tbNomPrenomRepresentant.Text = My.Settings.DernierControleNomRepresentant
        'cbxterritoire.Text = My.Settings.DernierControleTerritoire
        ckisSiteSecurise.Checked = My.Settings.DernierControleSiteSecurise
        ckisRecuperationResidus.Checked = My.Settings.DernierControleRecupResidus
        My.Settings.DernierControleInfosChezProp = False
    End Sub
    Private Sub RappelInfosChezProprietaire()
        tbcodePostal.Text = ClientCourant.codePostal
        m_bsCommune.Clear()
        m_bsCommune.Add(New Commune(ClientCourant.commune, "", ClientCourant.codePostal))
        cbxSite.Text = "Chez propriétaire"
        tbnomSite.Text = ""
        tbNomPrenomRepresentant.Text = ""
        'cbxterritoire.Text = ""
        ckisSiteSecurise.Checked = False
        ckisRecuperationResidus.Checked = False

        My.Settings.DernierControleInfosChezProp = True
    End Sub

    Private Sub btnChezProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChezProp.Click
        RappelInfosChezProprietaire()
    End Sub

    Private Sub cbxModeUtilisation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxModeUtilisation.SelectedIndexChanged
        FillNbreExploitants()
    End Sub

    Private Function FillNbreExploitants() As Boolean
        Dim bReturn As Boolean
        Try

            Dim strXPath As String
            Dim oLst As System.Xml.XmlNode
            strXPath = "//PulverisateurModeUtilisation[libelle=""%MODE%""]/Valeurs"
            strXPath = strXPath.Replace("%MODE%", cbxModeUtilisation.Text)
            cbxNbreExploitants.Items.Clear()
            oLst = Globals.GLOB_XML_MODEUTILISATION.getXmlNode(strXPath)
            For Each oVal As String In oLst.InnerText.Split(",")
                cbxNbreExploitants.Items.Add(oVal)
            Next
            If cbxNbreExploitants.Text = "" Then
                cbxNbreExploitants.Text = cbxNbreExploitants.Items(0)
            End If

            strXPath = "//PulverisateurModeUtilisation[libelle=""%MODE%""]/saisieNbre"
            strXPath = strXPath.Replace("%MODE%", cbxModeUtilisation.Text)
            oLst = Globals.GLOB_XML_MODEUTILISATION.getXmlNode(strXPath)
            If CBool(oLst.InnerText) Then
                lblNbreExploitants.Visible = True
                cbxNbreExploitants.Visible = True
            Else
                lblNbreExploitants.Visible = False
                cbxNbreExploitants.Visible = False
                cbxNbreExploitants.Text = "1"
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_contexte.FillNbreExploitants ERR:" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    Private Sub tbcodePostal_Validated(sender As Object, e As EventArgs) Handles tbcodePostal.Validated
        Try
            If sender.text <> "" Then
                LoadCommunes(sender.text)
            End If
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_contexte.tbcodePostal_Validated ERR: " & ex.Message)
        End Try

    End Sub
    Protected Sub LoadCommunes(pCodePostal As String)
        Debug.Assert(Not String.IsNullOrEmpty(pCodePostal))
        Dim oReferentiel As ReferentielCommunesCSV
        Dim lstCommunes As List(Of Commune)
        oReferentiel = New ReferentielCommunesCSV()
        oReferentiel.load()
        m_bsCommune.Clear()
        lstCommunes = oReferentiel.getCommunes(pCodePostal)
        For Each sCommune As Commune In lstCommunes
            m_bsCommune.Add(sCommune)
        Next
    End Sub
End Class
