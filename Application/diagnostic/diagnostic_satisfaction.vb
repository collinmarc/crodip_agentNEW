Imports System.Threading
Imports System.IO
Imports System.Collections.Generic

Public Class diagnostic_satisfaction
    Inherits frmCRODIP

#Region " Variables "

    Private m_Diagnostic As Diagnostic
    Private m_Agent As Agent
    Dim isPrinted As Boolean = False
    Friend WithEvents btn_ContreVisite As System.Windows.Forms.Label
    Friend WithEvents info_typeControle_complet As System.Windows.Forms.CheckBox
    Friend WithEvents btn_DocCoProp As System.Windows.Forms.Label
    Friend WithEvents tbTypePulve As System.Windows.Forms.TextBox
    Friend WithEvents info_typeControle_partiel As System.Windows.Forms.CheckBox
    '    Private objInfos(15) As Object

#End Region

#Region " Code généré par le Concepteur Windows Form "


    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        '        Me.objInfos = _objInfos



    End Sub
    Public Sub Setcontext(pDiag As Diagnostic, pAgent As Agent)
        m_Diagnostic = pDiag
        m_Agent = pAgent

        info_raisonSociale.Text = m_Diagnostic.proprietaireRaisonSociale
        info_nomPrenom.Text = m_Diagnostic.proprietaireNom & " " & m_Diagnostic.proprietairePrenom
        info_adresse.Text = m_Diagnostic.proprietaireAdresse & " - " & m_Diagnostic.proprietaireCodePostal & ", " & m_Diagnostic.proprietaireCommune
        info_email.Text = m_Diagnostic.proprietaireEmail
        info_dateControle.Text = m_Diagnostic.controleDateDebut

        If m_Diagnostic.controleIsComplet Then
            info_typeControle_complet.Checked = True
            info_typeControle_partiel.Checked = False
        Else
            info_typeControle_complet.Checked = False
            info_typeControle_partiel.Checked = True
        End If
        If m_Diagnostic.isContrevisiteImmediate Then
            info_typeControle_complet.Checked = True
            info_typeControle_partiel.Checked = True
        End If


        tbTypePulve.Text = m_Diagnostic.pulverisateurType
        info_inspecteur_organisme.Text = m_Diagnostic.organismePresNom
        info_inspecteur_nomPrenom.Text = m_Diagnostic.inspecteurNom & " " & m_Diagnostic.inspecteurPrenom

        'Le bouton contrevisite n'est activé que si le Diag echoue
        If m_Diagnostic.controleEtat = Diagnostic.controleEtatNOKCV Then
            btn_ContreVisite.Enabled = True
            btn_ContreVisite.Visible = True
        Else
            btn_ContreVisite.Enabled = False
            btn_ContreVisite.Visible = False

        End If


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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label_diagnostic_61 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents info_raisonSociale As System.Windows.Forms.Label
    Friend WithEvents info_nomPrenom As System.Windows.Forms.Label
    Friend WithEvents info_adresse As System.Windows.Forms.Label
    Friend WithEvents info_email As System.Windows.Forms.Label
    Friend WithEvents info_dateControle As System.Windows.Forms.Label
    Friend WithEvents info_inspecteur_organisme As System.Windows.Forms.Label
    Friend WithEvents info_inspecteur_nomPrenom As System.Windows.Forms.Label
    Friend WithEvents satisfaction_commentaires As System.Windows.Forms.TextBox
    Friend WithEvents satisfaction_suggestions As System.Windows.Forms.TextBox
    Friend WithEvents satisfaction_tresSatisfait As System.Windows.Forms.RadioButton
    Friend WithEvents satisfaction_satisfait As System.Windows.Forms.RadioButton
    Friend WithEvents satisfaction_aAmeliorer As System.Windows.Forms.RadioButton
    Friend WithEvents satisfaction_insatisfait As System.Windows.Forms.RadioButton
    Friend WithEvents btn_satisfaction_valider As System.Windows.Forms.Label
    Friend WithEvents btn_satisfaction_imprimer As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_satisfaction))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.info_nomPrenom = New System.Windows.Forms.Label()
        Me.info_adresse = New System.Windows.Forms.Label()
        Me.info_email = New System.Windows.Forms.Label()
        Me.info_raisonSociale = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.info_dateControle = New System.Windows.Forms.Label()
        Me.Label_diagnostic_61 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.info_inspecteur_organisme = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.info_inspecteur_nomPrenom = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.satisfaction_commentaires = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.satisfaction_suggestions = New System.Windows.Forms.TextBox()
        Me.satisfaction_tresSatisfait = New System.Windows.Forms.RadioButton()
        Me.satisfaction_satisfait = New System.Windows.Forms.RadioButton()
        Me.satisfaction_aAmeliorer = New System.Windows.Forms.RadioButton()
        Me.satisfaction_insatisfait = New System.Windows.Forms.RadioButton()
        Me.btn_satisfaction_valider = New System.Windows.Forms.Label()
        Me.btn_satisfaction_imprimer = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.info_typeControle_partiel = New System.Windows.Forms.CheckBox()
        Me.info_typeControle_complet = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_ContreVisite = New System.Windows.Forms.Label()
        Me.btn_DocCoProp = New System.Windows.Forms.Label()
        Me.tbTypePulve = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(296, 24)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "     Enquête de satisfaction"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(52, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(144, 16)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Raison sociale : "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(52, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Nom - Prénom : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(508, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Adresse : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(508, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Adresse E-Mail : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'info_nomPrenom
        '
        Me.info_nomPrenom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_nomPrenom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_nomPrenom.Location = New System.Drawing.Point(204, 80)
        Me.info_nomPrenom.Name = "info_nomPrenom"
        Me.info_nomPrenom.Size = New System.Drawing.Size(296, 16)
        Me.info_nomPrenom.TabIndex = 24
        Me.info_nomPrenom.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'info_adresse
        '
        Me.info_adresse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_adresse.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_adresse.Location = New System.Drawing.Point(660, 56)
        Me.info_adresse.Name = "info_adresse"
        Me.info_adresse.Size = New System.Drawing.Size(296, 16)
        Me.info_adresse.TabIndex = 24
        Me.info_adresse.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'info_email
        '
        Me.info_email.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_email.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_email.Location = New System.Drawing.Point(660, 80)
        Me.info_email.Name = "info_email"
        Me.info_email.Size = New System.Drawing.Size(296, 16)
        Me.info_email.TabIndex = 24
        Me.info_email.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'info_raisonSociale
        '
        Me.info_raisonSociale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_raisonSociale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_raisonSociale.Location = New System.Drawing.Point(204, 56)
        Me.info_raisonSociale.Name = "info_raisonSociale"
        Me.info_raisonSociale.Size = New System.Drawing.Size(296, 16)
        Me.info_raisonSociale.TabIndex = 24
        Me.info_raisonSociale.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(52, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 16)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Date du contrôle : "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'info_dateControle
        '
        Me.info_dateControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_dateControle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_dateControle.Location = New System.Drawing.Point(204, 120)
        Me.info_dateControle.Name = "info_dateControle"
        Me.info_dateControle.Size = New System.Drawing.Size(296, 16)
        Me.info_dateControle.TabIndex = 26
        Me.info_dateControle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label_diagnostic_61
        '
        Me.Label_diagnostic_61.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_61.Image = CType(resources.GetObject("Label_diagnostic_61.Image"), System.Drawing.Image)
        Me.Label_diagnostic_61.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_61.Location = New System.Drawing.Point(24, 160)
        Me.Label_diagnostic_61.Name = "Label_diagnostic_61"
        Me.Label_diagnostic_61.Size = New System.Drawing.Size(184, 16)
        Me.Label_diagnostic_61.TabIndex = 27
        Me.Label_diagnostic_61.Text = "     Type de contrôle : "
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label11.Image = CType(resources.GetObject("Label11.Image"), System.Drawing.Image)
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label11.Location = New System.Drawing.Point(24, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(256, 16)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "     Type de pulvérisateur : "
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label12.Location = New System.Drawing.Point(24, 304)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(184, 16)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "     Inspecteur : "
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(112, 336)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Organisme : "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'info_inspecteur_organisme
        '
        Me.info_inspecteur_organisme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_inspecteur_organisme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_inspecteur_organisme.Location = New System.Drawing.Point(264, 336)
        Me.info_inspecteur_organisme.Name = "info_inspecteur_organisme"
        Me.info_inspecteur_organisme.Size = New System.Drawing.Size(208, 16)
        Me.info_inspecteur_organisme.TabIndex = 30
        Me.info_inspecteur_organisme.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(528, 336)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 16)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Nom - Prénom : "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'info_inspecteur_nomPrenom
        '
        Me.info_inspecteur_nomPrenom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_inspecteur_nomPrenom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_inspecteur_nomPrenom.Location = New System.Drawing.Point(680, 336)
        Me.info_inspecteur_nomPrenom.Name = "info_inspecteur_nomPrenom"
        Me.info_inspecteur_nomPrenom.Size = New System.Drawing.Size(208, 16)
        Me.info_inspecteur_nomPrenom.TabIndex = 30
        Me.info_inspecteur_nomPrenom.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label18.Image = CType(resources.GetObject("Label18.Image"), System.Drawing.Image)
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label18.Location = New System.Drawing.Point(24, 384)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(448, 16)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "     Avez-vous été satisfait de la prestation réalisée par l’inspecteur :"
        '
        'satisfaction_commentaires
        '
        Me.satisfaction_commentaires.Enabled = False
        Me.satisfaction_commentaires.Location = New System.Drawing.Point(32, 440)
        Me.satisfaction_commentaires.Multiline = True
        Me.satisfaction_commentaires.Name = "satisfaction_commentaires"
        Me.satisfaction_commentaires.Size = New System.Drawing.Size(450, 200)
        Me.satisfaction_commentaires.TabIndex = 32
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label19.Image = CType(resources.GetObject("Label19.Image"), System.Drawing.Image)
        Me.Label19.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label19.Location = New System.Drawing.Point(512, 384)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(448, 16)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "     Vos remarques et suggestions pour améliorer nos prestations :"
        '
        'satisfaction_suggestions
        '
        Me.satisfaction_suggestions.Enabled = False
        Me.satisfaction_suggestions.Location = New System.Drawing.Point(512, 416)
        Me.satisfaction_suggestions.Multiline = True
        Me.satisfaction_suggestions.Name = "satisfaction_suggestions"
        Me.satisfaction_suggestions.Size = New System.Drawing.Size(450, 224)
        Me.satisfaction_suggestions.TabIndex = 32
        '
        'satisfaction_tresSatisfait
        '
        Me.satisfaction_tresSatisfait.Enabled = False
        Me.satisfaction_tresSatisfait.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.satisfaction_tresSatisfait.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.satisfaction_tresSatisfait.Location = New System.Drawing.Point(12, 8)
        Me.satisfaction_tresSatisfait.Name = "satisfaction_tresSatisfait"
        Me.satisfaction_tresSatisfait.Size = New System.Drawing.Size(96, 16)
        Me.satisfaction_tresSatisfait.TabIndex = 35
        Me.satisfaction_tresSatisfait.Text = "Très satisfait"
        '
        'satisfaction_satisfait
        '
        Me.satisfaction_satisfait.Enabled = False
        Me.satisfaction_satisfait.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.satisfaction_satisfait.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.satisfaction_satisfait.Location = New System.Drawing.Point(116, 8)
        Me.satisfaction_satisfait.Name = "satisfaction_satisfait"
        Me.satisfaction_satisfait.Size = New System.Drawing.Size(96, 16)
        Me.satisfaction_satisfait.TabIndex = 35
        Me.satisfaction_satisfait.Text = "Satisfait"
        '
        'satisfaction_aAmeliorer
        '
        Me.satisfaction_aAmeliorer.Enabled = False
        Me.satisfaction_aAmeliorer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.satisfaction_aAmeliorer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.satisfaction_aAmeliorer.Location = New System.Drawing.Point(220, 8)
        Me.satisfaction_aAmeliorer.Name = "satisfaction_aAmeliorer"
        Me.satisfaction_aAmeliorer.Size = New System.Drawing.Size(96, 16)
        Me.satisfaction_aAmeliorer.TabIndex = 35
        Me.satisfaction_aAmeliorer.Text = "A améliorer"
        '
        'satisfaction_insatisfait
        '
        Me.satisfaction_insatisfait.Enabled = False
        Me.satisfaction_insatisfait.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.satisfaction_insatisfait.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.satisfaction_insatisfait.Location = New System.Drawing.Point(324, 8)
        Me.satisfaction_insatisfait.Name = "satisfaction_insatisfait"
        Me.satisfaction_insatisfait.Size = New System.Drawing.Size(96, 16)
        Me.satisfaction_insatisfait.TabIndex = 35
        Me.satisfaction_insatisfait.Text = "Insatisfait"
        '
        'btn_satisfaction_valider
        '
        Me.btn_satisfaction_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_satisfaction_valider.Enabled = False
        Me.btn_satisfaction_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_satisfaction_valider.ForeColor = System.Drawing.Color.White
        Me.btn_satisfaction_valider.Image = CType(resources.GetObject("btn_satisfaction_valider.Image"), System.Drawing.Image)
        Me.btn_satisfaction_valider.Location = New System.Drawing.Point(872, 648)
        Me.btn_satisfaction_valider.Name = "btn_satisfaction_valider"
        Me.btn_satisfaction_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_satisfaction_valider.TabIndex = 37
        Me.btn_satisfaction_valider.Text = "    Valider"
        Me.btn_satisfaction_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_satisfaction_imprimer
        '
        Me.btn_satisfaction_imprimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_satisfaction_imprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_satisfaction_imprimer.ForeColor = System.Drawing.Color.White
        Me.btn_satisfaction_imprimer.Image = CType(resources.GetObject("btn_satisfaction_imprimer.Image"), System.Drawing.Image)
        Me.btn_satisfaction_imprimer.Location = New System.Drawing.Point(490, 648)
        Me.btn_satisfaction_imprimer.Name = "btn_satisfaction_imprimer"
        Me.btn_satisfaction_imprimer.Size = New System.Drawing.Size(180, 24)
        Me.btn_satisfaction_imprimer.TabIndex = 38
        Me.btn_satisfaction_imprimer.Text = "      Imprimer l'enquête"
        Me.btn_satisfaction_imprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.info_typeControle_partiel)
        Me.Panel1.Controls.Add(Me.info_typeControle_complet)
        Me.Panel1.Location = New System.Drawing.Point(244, 184)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 32)
        Me.Panel1.TabIndex = 39
        '
        'info_typeControle_partiel
        '
        Me.info_typeControle_partiel.AutoSize = True
        Me.info_typeControle_partiel.Enabled = False
        Me.info_typeControle_partiel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_typeControle_partiel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_typeControle_partiel.Location = New System.Drawing.Point(364, 9)
        Me.info_typeControle_partiel.Name = "info_typeControle_partiel"
        Me.info_typeControle_partiel.Size = New System.Drawing.Size(97, 17)
        Me.info_typeControle_partiel.TabIndex = 36
        Me.info_typeControle_partiel.Text = "Contre visite"
        Me.info_typeControle_partiel.UseVisualStyleBackColor = True
        '
        'info_typeControle_complet
        '
        Me.info_typeControle_complet.AutoSize = True
        Me.info_typeControle_complet.Enabled = False
        Me.info_typeControle_complet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.info_typeControle_complet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.info_typeControle_complet.Location = New System.Drawing.Point(23, 9)
        Me.info_typeControle_complet.Name = "info_typeControle_complet"
        Me.info_typeControle_complet.Size = New System.Drawing.Size(121, 17)
        Me.info_typeControle_complet.TabIndex = 35
        Me.info_typeControle_complet.Text = "Contrôle complet"
        Me.info_typeControle_complet.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tbTypePulve)
        Me.Panel2.Location = New System.Drawing.Point(136, 256)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(736, 32)
        Me.Panel2.TabIndex = 40
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.satisfaction_aAmeliorer)
        Me.Panel3.Controls.Add(Me.satisfaction_insatisfait)
        Me.Panel3.Controls.Add(Me.satisfaction_tresSatisfait)
        Me.Panel3.Controls.Add(Me.satisfaction_satisfait)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(32, 408)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(432, 32)
        Me.Panel3.TabIndex = 41
        '
        'btn_ContreVisite
        '
        Me.btn_ContreVisite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ContreVisite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ContreVisite.ForeColor = System.Drawing.Color.White
        Me.btn_ContreVisite.Image = CType(resources.GetObject("btn_ContreVisite.Image"), System.Drawing.Image)
        Me.btn_ContreVisite.Location = New System.Drawing.Point(676, 648)
        Me.btn_ContreVisite.Name = "btn_ContreVisite"
        Me.btn_ContreVisite.Size = New System.Drawing.Size(190, 24)
        Me.btn_ContreVisite.TabIndex = 42
        Me.btn_ContreVisite.Text = "    Contre-Visite immédiate"
        Me.btn_ContreVisite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_DocCoProp
        '
        Me.btn_DocCoProp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_DocCoProp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DocCoProp.ForeColor = System.Drawing.Color.White
        Me.btn_DocCoProp.Image = CType(resources.GetObject("btn_DocCoProp.Image"), System.Drawing.Image)
        Me.btn_DocCoProp.Location = New System.Drawing.Point(304, 648)
        Me.btn_DocCoProp.Name = "btn_DocCoProp"
        Me.btn_DocCoProp.Size = New System.Drawing.Size(180, 24)
        Me.btn_DocCoProp.TabIndex = 43
        Me.btn_DocCoProp.Text = "     Document de Co-propriété"
        Me.btn_DocCoProp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbTypePulve
        '
        Me.tbTypePulve.Enabled = False
        Me.tbTypePulve.Location = New System.Drawing.Point(108, 4)
        Me.tbTypePulve.Name = "tbTypePulve"
        Me.tbTypePulve.ReadOnly = True
        Me.tbTypePulve.Size = New System.Drawing.Size(520, 20)
        Me.tbTypePulve.TabIndex = 0
        '
        'diagnostic_satisfaction
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_DocCoProp)
        Me.Controls.Add(Me.btn_ContreVisite)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_satisfaction_imprimer)
        Me.Controls.Add(Me.btn_satisfaction_valider)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.satisfaction_commentaires)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.info_inspecteur_organisme)
        Me.Controls.Add(Me.Label_diagnostic_61)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.info_dateControle)
        Me.Controls.Add(Me.info_nomPrenom)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.info_adresse)
        Me.Controls.Add(Me.info_email)
        Me.Controls.Add(Me.info_raisonSociale)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.info_inspecteur_nomPrenom)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.satisfaction_suggestions)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "diagnostic_satisfaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "diagnostic_satisfaction"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Boutons "

    ' Finalisation du contrôle
    Private Sub btn_satisfaction_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_satisfaction_valider.Click
        sender.Enabled = False

        Try

            ' On rempli l'objet d'infos
            'Me.objInfos(7) = diagnosticCourant.pulverisateurLargeur
            'Me.objInfos(8) = diagnosticCourant.buseNbBuses

            ' On ouvre le form
            TryCast(Me.MdiParent, parentContener).Action(New ActionFDiagNext())

            Me.Close()
        Catch ex As Exception
            CSDebug.dispError("diag_recap::btn_finalisationDiag_valider_Click : " & ex.Message)
            sender.Enabled = True
        End Try

    End Sub

    ' Impression de l'enquete
    Private Sub btn_satisfaction_imprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_satisfaction_imprimer.Click
        btn_satisfaction_valider.Enabled = True
        genereEnquete()
    End Sub
    Private Sub btn_DocCoProp_Click(sender As Object, e As EventArgs) Handles btn_DocCoProp.Click
        GenereDocumentCoPropriete()
    End Sub

#End Region

#Region " Divers "

    'Private Sub satisfaction_commentaires_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles satisfaction_commentaires.GotFocus
    '    If sender.text = "Commentaires..." Then
    '        sender.text = ""
    '    End If
    'End Sub
    'Private Sub satisfaction_commentaires_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles satisfaction_commentaires.LostFocus
    '    If sender.text = "" Then
    '        sender.text = "Commentaires..."
    '    End If
    'End Sub

    Private Sub toggleEnableForm(ByVal statement As Boolean)
        'satisfaction_tresSatisfait.Enabled = statement
        'satisfaction_satisfait.Enabled = statement
        'satisfaction_aAmeliorer.Enabled = statement
        'satisfaction_insatisfait.Enabled = statement
        btn_satisfaction_valider.Enabled = statement
        btn_satisfaction_imprimer.Enabled = statement
    End Sub


#End Region


#Region " construction de l'enquete de satisfaction et du document de coProp"

    Private Sub genereEnquete()
        Dim oEtat As New EtatEnquete(m_Diagnostic)
        If oEtat.GenereEtat() Then
            oEtat.Open()
        End If
        DiagnosticManager.UpdateFileNames(m_Diagnostic)
    End Sub
    ''' <summary>
    ''' Génération du document de co-propriété
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GenereDocumentCoPropriete()
        Dim ofrm As New FrmAddCoProp()
        ofrm.Setcontext(m_Diagnostic, m_Agent)
        ofrm.ShowDialog(Me)

    End Sub

#End Region

    Private Sub btn_ContreVisite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ContreVisite.Click

        'Création d'un nouveau diagnostic à partir du courant
        diagnosticCourant = m_Diagnostic.Clone()
        diagnosticCourant.SetAsContreVisite(agentCourant)
        diagnosticCourant.isContrevisiteImmediate = True
        diagnosticCourant.RIFileName = ""
        diagnosticCourant.SMFileName = ""
        diagnosticCourant.CCFileName = ""


        'On Change le Diag de départ
        TryCast(MdiParent, parentContener).oEtatFDiag.oDiag = diagnosticCourant
        TryCast(MdiParent, parentContener).Action(New ActionFDiagCVImmediate())



    End Sub

    Private Sub diagnostic_satisfaction_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Propriété a mettre obligatoirement par programme
        Me.WindowState = FormWindowState.Maximized
        Me.ControlBox = False
        btn_DocCoProp.Visible = False
        'Activiation du bouton en cas de co-proprété
        'Comme c'est du texte et qu'il peut changer, je préférence juste tester les 2 première lettres
        If m_Diagnostic.pulverisateurModeUtilisation.ToUpper().StartsWith("CO") Then
            btn_DocCoProp.Visible = True
        End If
    End Sub

End Class
