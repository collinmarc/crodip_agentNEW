Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports System.IO
Imports System.Globalization

Public Class diagnostic_recap
    Inherits frmCRODIP
#Region " Variables "
    Private m_DiagMode As DiagMode
    Private m_diagnostic As Diagnostic
    Private m_Exploit As Exploitation
    Private m_Pulverisateur As Pulverisateur
    Dim isValider As Boolean = False
    Dim conclusionDiagnostique As enumConclusionDiag
    Friend WithEvents btn_finalisationDiag_imprimerSynthese As System.Windows.Forms.Label
    'Private objInfos(15) As Object
    Friend WithEvents diagnosticRecap_materiel_categorie As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_materiel_type As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_proprietaire_representant As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_materiel_Attelage As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_foncBuse As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_typeBuse As System.Windows.Forms.TextBox
    Friend WithEvents btn_voirFiche_Pulve As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_materiel_Pulverisation As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_materiel_Regulation As System.Windows.Forms.TextBox
    Friend WithEvents btn_voirFicheExploitant As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_organisme_dateControle As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbModeUtilisation As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_synthese_CumulErreurs As System.Windows.Forms.TextBox
    Friend WithEvents cbx_diagnosticRecap_materiel_EmplacementIdentification As System.Windows.Forms.ComboBox

#End Region

#Region " Code généré par le Concepteur Windows Form "

    Private Sub New()
        MyBase.New()

        'objInfos = _objInfos

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    Public Sub New(pDiagMode As DiagMode, pDiag As Diagnostic, pPulve As Pulverisateur, pExploit As Exploitation)
        MyBase.New()
        m_DiagMode = pDiagMode

        m_diagnostic = pDiag
        m_Pulverisateur = pPulve
        m_Exploit = pExploit

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label_diagnostic_61 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpSynthese As System.Windows.Forms.GroupBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ImageList_Etat As System.Windows.Forms.ImageList
    Private WithEvents btn_finalisationDiag_valider As System.Windows.Forms.Label
    Friend WithEvents btn_finalisationDiag_imprimerRapport As System.Windows.Forms.Label
    Friend WithEvents btn_finalisationDiag_modifierDiag As System.Windows.Forms.Label
    Friend WithEvents grpDefauts As System.Windows.Forms.GroupBox
    Friend WithEvents grpMateriel As System.Windows.Forms.GroupBox
    Friend WithEvents grpOrganisme As System.Windows.Forms.GroupBox
    Friend WithEvents grpProprio As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_organisme_inspecteur As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_organisme_lieuControle As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_organisme_heureDebut As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_organisme_heureFin As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_proprietaire_adresse As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_proprietaire_nom As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_proprietaire_codeApe As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_proprietaire_numSiren As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_organisme_nom As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_organisme_agrement As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_modele As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_identifiant As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_nbRangs As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_capacite As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_debitBuse As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_age As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_materiel_marque As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_proprietaire_ville As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_proprietaire_codePostal As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents label_pulveBonEtat As System.Windows.Forms.Label
    Friend WithEvents conclusion_pictoEtat As System.Windows.Forms.PictureBox
    Friend WithEvents list_diagnostic_bilan_P As System.Windows.Forms.ListView
    Friend WithEvents Items As System.Windows.Forms.ColumnHeader
    Friend WithEvents list_diagnostic_bilan_O As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_proprietaire_raisonSociale As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_organisme_inspecteurNum As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents controleIsComplet As System.Windows.Forms.CheckBox
    Friend WithEvents controleIsPartiel As System.Windows.Forms.CheckBox
    Friend WithEvents diagnosticRecap_materiel_largeurRampe As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_synthese_errMoyMano As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_synthese_errMaxMano As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_synthese_perteChargeMoy As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_synthese_perteChargeMax As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_synthese_errDebitmetre As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_synthese_errMoyCine As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_synthese_usureMoyBuses As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_synthese_nbBusesUsees As System.Windows.Forms.TextBox
    '    Friend WithEvents cr_debitBuses As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_recap))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_diagnostic_61 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpSynthese = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_synthese_CumulErreurs = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_synthese_errMoyMano = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_synthese_errMaxMano = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_synthese_perteChargeMoy = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_synthese_perteChargeMax = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_synthese_errDebitmetre = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_synthese_errMoyCine = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_synthese_usureMoyBuses = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_synthese_nbBusesUsees = New System.Windows.Forms.TextBox()
        Me.conclusion_pictoEtat = New System.Windows.Forms.PictureBox()
        Me.label_pulveBonEtat = New System.Windows.Forms.Label()
        Me.ImageList_Etat = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_finalisationDiag_valider = New System.Windows.Forms.Label()
        Me.btn_finalisationDiag_imprimerRapport = New System.Windows.Forms.Label()
        Me.btn_finalisationDiag_modifierDiag = New System.Windows.Forms.Label()
        Me.grpDefauts = New System.Windows.Forms.GroupBox()
        Me.list_diagnostic_bilan_P = New System.Windows.Forms.ListView()
        Me.Items = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.list_diagnostic_bilan_O = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpMateriel = New System.Windows.Forms.GroupBox()
        Me.tbModeUtilisation = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification = New System.Windows.Forms.ComboBox()
        Me.diagnosticRecap_materiel_Regulation = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_Pulverisation = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.btn_voirFiche_Pulve = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_typeBuse = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_materiel_foncBuse = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_materiel_Attelage = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_categorie = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_type = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_modele = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_identifiant = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_materiel_nbRangs = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_capacite = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_materiel_debitBuse = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_age = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_marque = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_materiel_largeurRampe = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.grpOrganisme = New System.Windows.Forms.GroupBox()
        Me.diagnosticRecap_organisme_dateControle = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.controleIsComplet = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_organisme_inspecteur = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_organisme_lieuControle = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_organisme_heureDebut = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_organisme_heureFin = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.controleIsPartiel = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_organisme_nom = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_organisme_agrement = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_organisme_inspecteurNum = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.grpProprio = New System.Windows.Forms.GroupBox()
        Me.btn_voirFicheExploitant = New System.Windows.Forms.Label()
        Me.diagnosticRecap_proprietaire_representant = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_proprietaire_adresse = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_proprietaire_nom = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_proprietaire_codeApe = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_proprietaire_numSiren = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_proprietaire_ville = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_proprietaire_codePostal = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_proprietaire_raisonSociale = New System.Windows.Forms.TextBox()
        Me.btn_finalisationDiag_imprimerSynthese = New System.Windows.Forms.Label()
        Me.grpSynthese.SuspendLayout()
        CType(Me.conclusion_pictoEtat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDefauts.SuspendLayout()
        Me.grpMateriel.SuspendLayout()
        Me.grpOrganisme.SuspendLayout()
        Me.grpProprio.SuspendLayout()
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
        Me.Label3.Size = New System.Drawing.Size(344, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "     Visualisation du contrôle"
        '
        'Label_diagnostic_61
        '
        Me.Label_diagnostic_61.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_61.Image = CType(resources.GetObject("Label_diagnostic_61.Image"), System.Drawing.Image)
        Me.Label_diagnostic_61.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_61.Location = New System.Drawing.Point(8, 24)
        Me.Label_diagnostic_61.Name = "Label_diagnostic_61"
        Me.Label_diagnostic_61.Size = New System.Drawing.Size(472, 16)
        Me.Label_diagnostic_61.TabIndex = 20
        Me.Label_diagnostic_61.Text = "     Défauts sans nécessité de nouveau contrôle dans un délai de 4 mois"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(496, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(472, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "     Défauts nécessitant un nouveau contrôle dans un délai de 4 mois"
        '
        'grpSynthese
        '
        Me.grpSynthese.Controls.Add(Me.Label43)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_CumulErreurs)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_errMoyMano)
        Me.grpSynthese.Controls.Add(Me.Label83)
        Me.grpSynthese.Controls.Add(Me.Label2)
        Me.grpSynthese.Controls.Add(Me.Label4)
        Me.grpSynthese.Controls.Add(Me.Label5)
        Me.grpSynthese.Controls.Add(Me.Label6)
        Me.grpSynthese.Controls.Add(Me.Label7)
        Me.grpSynthese.Controls.Add(Me.Label8)
        Me.grpSynthese.Controls.Add(Me.Label9)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_errMaxMano)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_perteChargeMoy)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_perteChargeMax)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_errDebitmetre)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_errMoyCine)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_usureMoyBuses)
        Me.grpSynthese.Controls.Add(Me.diagnosticRecap_synthese_nbBusesUsees)
        Me.grpSynthese.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSynthese.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpSynthese.Location = New System.Drawing.Point(11, 522)
        Me.grpSynthese.Name = "grpSynthese"
        Me.grpSynthese.Size = New System.Drawing.Size(984, 104)
        Me.grpSynthese.TabIndex = 5
        Me.grpSynthese.TabStop = False
        Me.grpSynthese.Text = "Synthèse des mesures"
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label43.Location = New System.Drawing.Point(669, 75)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(143, 16)
        Me.Label43.TabIndex = 14
        Me.Label43.Text = "Cumul des erreurs (%) : "
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_synthese_CumulErreurs
        '
        Me.diagnosticRecap_synthese_CumulErreurs.Location = New System.Drawing.Point(816, 74)
        Me.diagnosticRecap_synthese_CumulErreurs.Name = "diagnosticRecap_synthese_CumulErreurs"
        Me.diagnosticRecap_synthese_CumulErreurs.ReadOnly = True
        Me.diagnosticRecap_synthese_CumulErreurs.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_CumulErreurs.TabIndex = 15
        Me.diagnosticRecap_synthese_CumulErreurs.TabStop = False
        '
        'diagnosticRecap_synthese_errMoyMano
        '
        Me.diagnosticRecap_synthese_errMoyMano.Location = New System.Drawing.Point(256, 24)
        Me.diagnosticRecap_synthese_errMoyMano.Name = "diagnosticRecap_synthese_errMoyMano"
        Me.diagnosticRecap_synthese_errMoyMano.ReadOnly = True
        Me.diagnosticRecap_synthese_errMoyMano.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_errMoyMano.TabIndex = 13
        Me.diagnosticRecap_synthese_errMoyMano.TabStop = False
        '
        'Label83
        '
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label83.Location = New System.Drawing.Point(45, 25)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(208, 16)
        Me.Label83.TabIndex = 12
        Me.Label83.Text = "Erreur moyenne manomètre (bar) : "
        Me.Label83.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(358, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Erreur maxi manomètre (bar) : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(53, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Perte de charge moyenne (%) : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(376, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(164, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Perte de charge maxi (%) : "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(397, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Erreur débit mètre (%) : "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(50, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(200, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Erreur moyenne cinémomètre (%) : "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(651, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 16)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Nombre buses usées : "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(648, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Usure moyenne buses (%) : "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_synthese_errMaxMano
        '
        Me.diagnosticRecap_synthese_errMaxMano.Location = New System.Drawing.Point(544, 24)
        Me.diagnosticRecap_synthese_errMaxMano.Name = "diagnosticRecap_synthese_errMaxMano"
        Me.diagnosticRecap_synthese_errMaxMano.ReadOnly = True
        Me.diagnosticRecap_synthese_errMaxMano.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_errMaxMano.TabIndex = 13
        Me.diagnosticRecap_synthese_errMaxMano.TabStop = False
        '
        'diagnosticRecap_synthese_perteChargeMoy
        '
        Me.diagnosticRecap_synthese_perteChargeMoy.Location = New System.Drawing.Point(256, 48)
        Me.diagnosticRecap_synthese_perteChargeMoy.Name = "diagnosticRecap_synthese_perteChargeMoy"
        Me.diagnosticRecap_synthese_perteChargeMoy.ReadOnly = True
        Me.diagnosticRecap_synthese_perteChargeMoy.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_perteChargeMoy.TabIndex = 13
        Me.diagnosticRecap_synthese_perteChargeMoy.TabStop = False
        '
        'diagnosticRecap_synthese_perteChargeMax
        '
        Me.diagnosticRecap_synthese_perteChargeMax.Location = New System.Drawing.Point(544, 48)
        Me.diagnosticRecap_synthese_perteChargeMax.Name = "diagnosticRecap_synthese_perteChargeMax"
        Me.diagnosticRecap_synthese_perteChargeMax.ReadOnly = True
        Me.diagnosticRecap_synthese_perteChargeMax.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_perteChargeMax.TabIndex = 13
        Me.diagnosticRecap_synthese_perteChargeMax.TabStop = False
        '
        'diagnosticRecap_synthese_errDebitmetre
        '
        Me.diagnosticRecap_synthese_errDebitmetre.Location = New System.Drawing.Point(544, 73)
        Me.diagnosticRecap_synthese_errDebitmetre.Name = "diagnosticRecap_synthese_errDebitmetre"
        Me.diagnosticRecap_synthese_errDebitmetre.ReadOnly = True
        Me.diagnosticRecap_synthese_errDebitmetre.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_errDebitmetre.TabIndex = 13
        Me.diagnosticRecap_synthese_errDebitmetre.TabStop = False
        '
        'diagnosticRecap_synthese_errMoyCine
        '
        Me.diagnosticRecap_synthese_errMoyCine.Location = New System.Drawing.Point(256, 73)
        Me.diagnosticRecap_synthese_errMoyCine.Name = "diagnosticRecap_synthese_errMoyCine"
        Me.diagnosticRecap_synthese_errMoyCine.ReadOnly = True
        Me.diagnosticRecap_synthese_errMoyCine.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_errMoyCine.TabIndex = 13
        Me.diagnosticRecap_synthese_errMoyCine.TabStop = False
        '
        'diagnosticRecap_synthese_usureMoyBuses
        '
        Me.diagnosticRecap_synthese_usureMoyBuses.Location = New System.Drawing.Point(816, 24)
        Me.diagnosticRecap_synthese_usureMoyBuses.Name = "diagnosticRecap_synthese_usureMoyBuses"
        Me.diagnosticRecap_synthese_usureMoyBuses.ReadOnly = True
        Me.diagnosticRecap_synthese_usureMoyBuses.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_usureMoyBuses.TabIndex = 13
        Me.diagnosticRecap_synthese_usureMoyBuses.TabStop = False
        '
        'diagnosticRecap_synthese_nbBusesUsees
        '
        Me.diagnosticRecap_synthese_nbBusesUsees.Location = New System.Drawing.Point(816, 48)
        Me.diagnosticRecap_synthese_nbBusesUsees.Name = "diagnosticRecap_synthese_nbBusesUsees"
        Me.diagnosticRecap_synthese_nbBusesUsees.ReadOnly = True
        Me.diagnosticRecap_synthese_nbBusesUsees.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_synthese_nbBusesUsees.TabIndex = 13
        Me.diagnosticRecap_synthese_nbBusesUsees.TabStop = False
        '
        'conclusion_pictoEtat
        '
        Me.conclusion_pictoEtat.Image = CType(resources.GetObject("conclusion_pictoEtat.Image"), System.Drawing.Image)
        Me.conclusion_pictoEtat.Location = New System.Drawing.Point(571, 632)
        Me.conclusion_pictoEtat.Name = "conclusion_pictoEtat"
        Me.conclusion_pictoEtat.Size = New System.Drawing.Size(16, 16)
        Me.conclusion_pictoEtat.TabIndex = 13
        Me.conclusion_pictoEtat.TabStop = False
        '
        'label_pulveBonEtat
        '
        Me.label_pulveBonEtat.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_pulveBonEtat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_pulveBonEtat.Location = New System.Drawing.Point(587, 629)
        Me.label_pulveBonEtat.Name = "label_pulveBonEtat"
        Me.label_pulveBonEtat.Size = New System.Drawing.Size(311, 24)
        Me.label_pulveBonEtat.TabIndex = 12
        Me.label_pulveBonEtat.Text = "Pulvérisateur en bon état"
        Me.label_pulveBonEtat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageList_Etat
        '
        Me.ImageList_Etat.ImageStream = CType(resources.GetObject("ImageList_Etat.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Etat.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Etat.Images.SetKeyName(0, "")
        Me.ImageList_Etat.Images.SetKeyName(1, "")
        '
        'btn_finalisationDiag_valider
        '
        Me.btn_finalisationDiag_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_valider.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_valider.Image = CType(resources.GetObject("btn_finalisationDiag_valider.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_valider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_finalisationDiag_valider.Location = New System.Drawing.Point(868, 629)
        Me.btn_finalisationDiag_valider.Name = "btn_finalisationDiag_valider"
        Me.btn_finalisationDiag_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_finalisationDiag_valider.TabIndex = 9
        Me.btn_finalisationDiag_valider.Text = "    Valider"
        Me.btn_finalisationDiag_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_finalisationDiag_imprimerRapport
        '
        Me.btn_finalisationDiag_imprimerRapport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_imprimerRapport.Enabled = False
        Me.btn_finalisationDiag_imprimerRapport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_imprimerRapport.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_imprimerRapport.Image = CType(resources.GetObject("btn_finalisationDiag_imprimerRapport.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_imprimerRapport.Location = New System.Drawing.Point(194, 629)
        Me.btn_finalisationDiag_imprimerRapport.Name = "btn_finalisationDiag_imprimerRapport"
        Me.btn_finalisationDiag_imprimerRapport.Size = New System.Drawing.Size(184, 24)
        Me.btn_finalisationDiag_imprimerRapport.TabIndex = 7
        Me.btn_finalisationDiag_imprimerRapport.Text = "      Imprimer le rapport"
        Me.btn_finalisationDiag_imprimerRapport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_finalisationDiag_modifierDiag
        '
        Me.btn_finalisationDiag_modifierDiag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_modifierDiag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_modifierDiag.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_modifierDiag.Image = CType(resources.GetObject("btn_finalisationDiag_modifierDiag.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_modifierDiag.Location = New System.Drawing.Point(5, 629)
        Me.btn_finalisationDiag_modifierDiag.Name = "btn_finalisationDiag_modifierDiag"
        Me.btn_finalisationDiag_modifierDiag.Size = New System.Drawing.Size(184, 24)
        Me.btn_finalisationDiag_modifierDiag.TabIndex = 6
        Me.btn_finalisationDiag_modifierDiag.Text = "       Modifier le contrôle"
        Me.btn_finalisationDiag_modifierDiag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDefauts
        '
        Me.grpDefauts.Controls.Add(Me.list_diagnostic_bilan_P)
        Me.grpDefauts.Controls.Add(Me.Label1)
        Me.grpDefauts.Controls.Add(Me.Label_diagnostic_61)
        Me.grpDefauts.Controls.Add(Me.list_diagnostic_bilan_O)
        Me.grpDefauts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDefauts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpDefauts.Location = New System.Drawing.Point(8, 368)
        Me.grpDefauts.Name = "grpDefauts"
        Me.grpDefauts.Size = New System.Drawing.Size(984, 148)
        Me.grpDefauts.TabIndex = 4
        Me.grpDefauts.TabStop = False
        Me.grpDefauts.Text = "Synthèse du contrôle"
        '
        'list_diagnostic_bilan_P
        '
        Me.list_diagnostic_bilan_P.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Items})
        Me.list_diagnostic_bilan_P.FullRowSelect = True
        Me.list_diagnostic_bilan_P.HideSelection = False
        Me.list_diagnostic_bilan_P.Location = New System.Drawing.Point(496, 48)
        Me.list_diagnostic_bilan_P.MultiSelect = False
        Me.list_diagnostic_bilan_P.Name = "list_diagnostic_bilan_P"
        Me.list_diagnostic_bilan_P.Size = New System.Drawing.Size(480, 93)
        Me.list_diagnostic_bilan_P.TabIndex = 1
        Me.list_diagnostic_bilan_P.TabStop = False
        Me.list_diagnostic_bilan_P.UseCompatibleStateImageBehavior = False
        Me.list_diagnostic_bilan_P.View = System.Windows.Forms.View.Details
        '
        'Items
        '
        Me.Items.Text = "Items"
        Me.Items.Width = 456
        '
        'list_diagnostic_bilan_O
        '
        Me.list_diagnostic_bilan_O.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.list_diagnostic_bilan_O.FullRowSelect = True
        Me.list_diagnostic_bilan_O.HideSelection = False
        Me.list_diagnostic_bilan_O.Location = New System.Drawing.Point(8, 48)
        Me.list_diagnostic_bilan_O.MultiSelect = False
        Me.list_diagnostic_bilan_O.Name = "list_diagnostic_bilan_O"
        Me.list_diagnostic_bilan_O.Size = New System.Drawing.Size(480, 93)
        Me.list_diagnostic_bilan_O.TabIndex = 0
        Me.list_diagnostic_bilan_O.TabStop = False
        Me.list_diagnostic_bilan_O.UseCompatibleStateImageBehavior = False
        Me.list_diagnostic_bilan_O.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Items"
        Me.ColumnHeader1.Width = 455
        '
        'grpMateriel
        '
        Me.grpMateriel.Controls.Add(Me.tbModeUtilisation)
        Me.grpMateriel.Controls.Add(Me.Label24)
        Me.grpMateriel.Controls.Add(Me.cbx_diagnosticRecap_materiel_EmplacementIdentification)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_Regulation)
        Me.grpMateriel.Controls.Add(Me.Label42)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_Pulverisation)
        Me.grpMateriel.Controls.Add(Me.Label41)
        Me.grpMateriel.Controls.Add(Me.btn_voirFiche_Pulve)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_typeBuse)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_foncBuse)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_Attelage)
        Me.grpMateriel.Controls.Add(Me.Label38)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_categorie)
        Me.grpMateriel.Controls.Add(Me.Label29)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_type)
        Me.grpMateriel.Controls.Add(Me.Label11)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_modele)
        Me.grpMateriel.Controls.Add(Me.Label25)
        Me.grpMateriel.Controls.Add(Me.Label26)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_identifiant)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_nbRangs)
        Me.grpMateriel.Controls.Add(Me.Label27)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_capacite)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_debitBuse)
        Me.grpMateriel.Controls.Add(Me.Label28)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_age)
        Me.grpMateriel.Controls.Add(Me.Label30)
        Me.grpMateriel.Controls.Add(Me.Label31)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_marque)
        Me.grpMateriel.Controls.Add(Me.Label36)
        Me.grpMateriel.Controls.Add(Me.Label12)
        Me.grpMateriel.Controls.Add(Me.Label32)
        Me.grpMateriel.Controls.Add(Me.Label33)
        Me.grpMateriel.Controls.Add(Me.diagnosticRecap_materiel_largeurRampe)
        Me.grpMateriel.Controls.Add(Me.Label35)
        Me.grpMateriel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMateriel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpMateriel.Location = New System.Drawing.Point(8, 184)
        Me.grpMateriel.Name = "grpMateriel"
        Me.grpMateriel.Size = New System.Drawing.Size(984, 176)
        Me.grpMateriel.TabIndex = 3
        Me.grpMateriel.TabStop = False
        Me.grpMateriel.Text = "Matériel"
        '
        'tbModeUtilisation
        '
        Me.tbModeUtilisation.Location = New System.Drawing.Point(802, 68)
        Me.tbModeUtilisation.Name = "tbModeUtilisation"
        Me.tbModeUtilisation.ReadOnly = True
        Me.tbModeUtilisation.Size = New System.Drawing.Size(158, 20)
        Me.tbModeUtilisation.TabIndex = 70
        Me.tbModeUtilisation.TabStop = False
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(702, 68)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(94, 16)
        Me.Label24.TabIndex = 69
        Me.Label24.Text = "Utilisation : "
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cbx_diagnosticRecap_materiel_EmplacementIdentification
        '
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.FormattingEnabled = True
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.Location = New System.Drawing.Point(536, 119)
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.Name = "cbx_diagnosticRecap_materiel_EmplacementIdentification"
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.Size = New System.Drawing.Size(425, 21)
        Me.cbx_diagnosticRecap_materiel_EmplacementIdentification.TabIndex = 68
        '
        'diagnosticRecap_materiel_Regulation
        '
        Me.diagnosticRecap_materiel_Regulation.Location = New System.Drawing.Point(494, 93)
        Me.diagnosticRecap_materiel_Regulation.Name = "diagnosticRecap_materiel_Regulation"
        Me.diagnosticRecap_materiel_Regulation.ReadOnly = True
        Me.diagnosticRecap_materiel_Regulation.Size = New System.Drawing.Size(196, 20)
        Me.diagnosticRecap_materiel_Regulation.TabIndex = 11
        Me.diagnosticRecap_materiel_Regulation.TabStop = False
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(394, 93)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(85, 16)
        Me.Label42.TabIndex = 67
        Me.Label42.Text = "Régulation : "
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_materiel_Pulverisation
        '
        Me.diagnosticRecap_materiel_Pulverisation.Location = New System.Drawing.Point(802, 40)
        Me.diagnosticRecap_materiel_Pulverisation.Name = "diagnosticRecap_materiel_Pulverisation"
        Me.diagnosticRecap_materiel_Pulverisation.ReadOnly = True
        Me.diagnosticRecap_materiel_Pulverisation.Size = New System.Drawing.Size(158, 20)
        Me.diagnosticRecap_materiel_Pulverisation.TabIndex = 7
        Me.diagnosticRecap_materiel_Pulverisation.TabStop = False
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(702, 41)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(94, 16)
        Me.Label41.TabIndex = 65
        Me.Label41.Text = "Pulvérisation : "
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btn_voirFiche_Pulve
        '
        Me.btn_voirFiche_Pulve.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_voirFiche_Pulve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_voirFiche_Pulve.ForeColor = System.Drawing.Color.White
        Me.btn_voirFiche_Pulve.Image = CType(resources.GetObject("btn_voirFiche_Pulve.Image"), System.Drawing.Image)
        Me.btn_voirFiche_Pulve.Location = New System.Drawing.Point(832, 146)
        Me.btn_voirFiche_Pulve.Name = "btn_voirFiche_Pulve"
        Me.btn_voirFiche_Pulve.Size = New System.Drawing.Size(128, 24)
        Me.btn_voirFiche_Pulve.TabIndex = 1
        Me.btn_voirFiche_Pulve.Text = "    Voir la fiche"
        Me.btn_voirFiche_Pulve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diagnosticRecap_materiel_typeBuse
        '
        Me.diagnosticRecap_materiel_typeBuse.Location = New System.Drawing.Point(160, 97)
        Me.diagnosticRecap_materiel_typeBuse.Name = "diagnosticRecap_materiel_typeBuse"
        Me.diagnosticRecap_materiel_typeBuse.ReadOnly = True
        Me.diagnosticRecap_materiel_typeBuse.Size = New System.Drawing.Size(168, 20)
        Me.diagnosticRecap_materiel_typeBuse.TabIndex = 12
        Me.diagnosticRecap_materiel_typeBuse.TabStop = False
        '
        'diagnosticRecap_materiel_foncBuse
        '
        Me.diagnosticRecap_materiel_foncBuse.Location = New System.Drawing.Point(160, 123)
        Me.diagnosticRecap_materiel_foncBuse.Name = "diagnosticRecap_materiel_foncBuse"
        Me.diagnosticRecap_materiel_foncBuse.ReadOnly = True
        Me.diagnosticRecap_materiel_foncBuse.Size = New System.Drawing.Size(168, 20)
        Me.diagnosticRecap_materiel_foncBuse.TabIndex = 14
        Me.diagnosticRecap_materiel_foncBuse.TabStop = False
        '
        'diagnosticRecap_materiel_Attelage
        '
        Me.diagnosticRecap_materiel_Attelage.Location = New System.Drawing.Point(802, 14)
        Me.diagnosticRecap_materiel_Attelage.Name = "diagnosticRecap_materiel_Attelage"
        Me.diagnosticRecap_materiel_Attelage.ReadOnly = True
        Me.diagnosticRecap_materiel_Attelage.Size = New System.Drawing.Size(158, 20)
        Me.diagnosticRecap_materiel_Attelage.TabIndex = 3
        Me.diagnosticRecap_materiel_Attelage.TabStop = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(340, 126)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(195, 13)
        Me.Label38.TabIndex = 60
        Me.Label38.Text = "Emplacement de l'identification : "
        '
        'diagnosticRecap_materiel_categorie
        '
        Me.diagnosticRecap_materiel_categorie.Location = New System.Drawing.Point(494, 43)
        Me.diagnosticRecap_materiel_categorie.Name = "diagnosticRecap_materiel_categorie"
        Me.diagnosticRecap_materiel_categorie.ReadOnly = True
        Me.diagnosticRecap_materiel_categorie.Size = New System.Drawing.Size(196, 20)
        Me.diagnosticRecap_materiel_categorie.TabIndex = 6
        Me.diagnosticRecap_materiel_categorie.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(422, 47)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 13)
        Me.Label29.TabIndex = 58
        Me.Label29.Text = "Catégorie : "
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'diagnosticRecap_materiel_type
        '
        Me.diagnosticRecap_materiel_type.Location = New System.Drawing.Point(232, 43)
        Me.diagnosticRecap_materiel_type.Name = "diagnosticRecap_materiel_type"
        Me.diagnosticRecap_materiel_type.ReadOnly = True
        Me.diagnosticRecap_materiel_type.Size = New System.Drawing.Size(168, 20)
        Me.diagnosticRecap_materiel_type.TabIndex = 5
        Me.diagnosticRecap_materiel_type.TabStop = False
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(174, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Type : "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_materiel_modele
        '
        Me.diagnosticRecap_materiel_modele.Location = New System.Drawing.Point(494, 17)
        Me.diagnosticRecap_materiel_modele.Name = "diagnosticRecap_materiel_modele"
        Me.diagnosticRecap_materiel_modele.ReadOnly = True
        Me.diagnosticRecap_materiel_modele.Size = New System.Drawing.Size(196, 20)
        Me.diagnosticRecap_materiel_modele.TabIndex = 2
        Me.diagnosticRecap_materiel_modele.TabStop = False
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(439, 17)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 16)
        Me.Label25.TabIndex = 16
        Me.Label25.Text = "Modèle : "
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(8, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 16)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Identifiant : "
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_materiel_identifiant
        '
        Me.diagnosticRecap_materiel_identifiant.Location = New System.Drawing.Point(86, 17)
        Me.diagnosticRecap_materiel_identifiant.Name = "diagnosticRecap_materiel_identifiant"
        Me.diagnosticRecap_materiel_identifiant.ReadOnly = True
        Me.diagnosticRecap_materiel_identifiant.Size = New System.Drawing.Size(82, 20)
        Me.diagnosticRecap_materiel_identifiant.TabIndex = 0
        Me.diagnosticRecap_materiel_identifiant.TabStop = False
        '
        'diagnosticRecap_materiel_nbRangs
        '
        Me.diagnosticRecap_materiel_nbRangs.Location = New System.Drawing.Point(86, 43)
        Me.diagnosticRecap_materiel_nbRangs.Name = "diagnosticRecap_materiel_nbRangs"
        Me.diagnosticRecap_materiel_nbRangs.ReadOnly = True
        Me.diagnosticRecap_materiel_nbRangs.Size = New System.Drawing.Size(82, 20)
        Me.diagnosticRecap_materiel_nbRangs.TabIndex = 4
        Me.diagnosticRecap_materiel_nbRangs.TabStop = False
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(3, 44)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(77, 16)
        Me.Label27.TabIndex = 13
        Me.Label27.Text = "Lg/Nrangs : "
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_materiel_capacite
        '
        Me.diagnosticRecap_materiel_capacite.Location = New System.Drawing.Point(494, 68)
        Me.diagnosticRecap_materiel_capacite.Name = "diagnosticRecap_materiel_capacite"
        Me.diagnosticRecap_materiel_capacite.ReadOnly = True
        Me.diagnosticRecap_materiel_capacite.Size = New System.Drawing.Size(196, 20)
        Me.diagnosticRecap_materiel_capacite.TabIndex = 10
        Me.diagnosticRecap_materiel_capacite.TabStop = False
        '
        'diagnosticRecap_materiel_debitBuse
        '
        Me.diagnosticRecap_materiel_debitBuse.Location = New System.Drawing.Point(160, 149)
        Me.diagnosticRecap_materiel_debitBuse.Name = "diagnosticRecap_materiel_debitBuse"
        Me.diagnosticRecap_materiel_debitBuse.ReadOnly = True
        Me.diagnosticRecap_materiel_debitBuse.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_materiel_debitBuse.TabIndex = 15
        Me.diagnosticRecap_materiel_debitBuse.TabStop = False
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(12, 150)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(140, 16)
        Me.Label28.TabIndex = 13
        Me.Label28.Text = "Débit buse : "
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_materiel_age
        '
        Me.diagnosticRecap_materiel_age.Location = New System.Drawing.Point(232, 68)
        Me.diagnosticRecap_materiel_age.Name = "diagnosticRecap_materiel_age"
        Me.diagnosticRecap_materiel_age.ReadOnly = True
        Me.diagnosticRecap_materiel_age.Size = New System.Drawing.Size(168, 20)
        Me.diagnosticRecap_materiel_age.TabIndex = 9
        Me.diagnosticRecap_materiel_age.TabStop = False
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(411, 69)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(84, 16)
        Me.Label30.TabIndex = 15
        Me.Label30.Text = "Capacité : "
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(174, 69)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 16)
        Me.Label31.TabIndex = 16
        Me.Label31.Text = "Année : "
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_materiel_marque
        '
        Me.diagnosticRecap_materiel_marque.Location = New System.Drawing.Point(232, 17)
        Me.diagnosticRecap_materiel_marque.Name = "diagnosticRecap_materiel_marque"
        Me.diagnosticRecap_materiel_marque.ReadOnly = True
        Me.diagnosticRecap_materiel_marque.Size = New System.Drawing.Size(168, 20)
        Me.diagnosticRecap_materiel_marque.TabIndex = 1
        Me.diagnosticRecap_materiel_marque.TabStop = False
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(170, 17)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(62, 16)
        Me.Label36.TabIndex = 15
        Me.Label36.Text = "Marque : "
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(719, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 16)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Attelage : "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(10, 124)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(142, 16)
        Me.Label32.TabIndex = 13
        Me.Label32.Text = "Fonctionnement buses : "
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(14, 97)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(82, 16)
        Me.Label33.TabIndex = 13
        Me.Label33.Text = "Type buse :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_materiel_largeurRampe
        '
        Me.diagnosticRecap_materiel_largeurRampe.Location = New System.Drawing.Point(86, 68)
        Me.diagnosticRecap_materiel_largeurRampe.Name = "diagnosticRecap_materiel_largeurRampe"
        Me.diagnosticRecap_materiel_largeurRampe.ReadOnly = True
        Me.diagnosticRecap_materiel_largeurRampe.Size = New System.Drawing.Size(82, 20)
        Me.diagnosticRecap_materiel_largeurRampe.TabIndex = 8
        Me.diagnosticRecap_materiel_largeurRampe.TabStop = False
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(11, 69)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(69, 16)
        Me.Label35.TabIndex = 13
        Me.Label35.Text = "Largeur : "
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'grpOrganisme
        '
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_dateControle)
        Me.grpOrganisme.Controls.Add(Me.Label15)
        Me.grpOrganisme.Controls.Add(Me.Label16)
        Me.grpOrganisme.Controls.Add(Me.Label17)
        Me.grpOrganisme.Controls.Add(Me.controleIsComplet)
        Me.grpOrganisme.Controls.Add(Me.Label18)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_inspecteur)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_lieuControle)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_heureDebut)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_heureFin)
        Me.grpOrganisme.Controls.Add(Me.Label19)
        Me.grpOrganisme.Controls.Add(Me.controleIsPartiel)
        Me.grpOrganisme.Controls.Add(Me.Label22)
        Me.grpOrganisme.Controls.Add(Me.Label23)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_nom)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_agrement)
        Me.grpOrganisme.Controls.Add(Me.diagnosticRecap_organisme_inspecteurNum)
        Me.grpOrganisme.Controls.Add(Me.Label34)
        Me.grpOrganisme.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpOrganisme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpOrganisme.Location = New System.Drawing.Point(8, 34)
        Me.grpOrganisme.Name = "grpOrganisme"
        Me.grpOrganisme.Size = New System.Drawing.Size(488, 144)
        Me.grpOrganisme.TabIndex = 1
        Me.grpOrganisme.TabStop = False
        Me.grpOrganisme.Text = "Organisme d'inspection"
        '
        'diagnosticRecap_organisme_dateControle
        '
        Me.diagnosticRecap_organisme_dateControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagnosticRecap_organisme_dateControle.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.diagnosticRecap_organisme_dateControle.Location = New System.Drawing.Point(344, 24)
        Me.diagnosticRecap_organisme_dateControle.Name = "diagnosticRecap_organisme_dateControle"
        Me.diagnosticRecap_organisme_dateControle.Size = New System.Drawing.Size(129, 20)
        Me.diagnosticRecap_organisme_dateControle.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(8, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Inspecteur : "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(216, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 16)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Date du contrôle : "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(206, 50)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(130, 16)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Heure début / fin : "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'controleIsComplet
        '
        Me.controleIsComplet.Enabled = False
        Me.controleIsComplet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.controleIsComplet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.controleIsComplet.Location = New System.Drawing.Point(216, 100)
        Me.controleIsComplet.Name = "controleIsComplet"
        Me.controleIsComplet.Size = New System.Drawing.Size(128, 16)
        Me.controleIsComplet.TabIndex = 8
        Me.controleIsComplet.TabStop = False
        Me.controleIsComplet.Text = "Contrôle complet"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(216, 76)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(120, 16)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Lieu du contrôle : "
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_organisme_inspecteur
        '
        Me.diagnosticRecap_organisme_inspecteur.Location = New System.Drawing.Point(104, 72)
        Me.diagnosticRecap_organisme_inspecteur.Name = "diagnosticRecap_organisme_inspecteur"
        Me.diagnosticRecap_organisme_inspecteur.ReadOnly = True
        Me.diagnosticRecap_organisme_inspecteur.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_organisme_inspecteur.TabIndex = 2
        Me.diagnosticRecap_organisme_inspecteur.TabStop = False
        '
        'diagnosticRecap_organisme_lieuControle
        '
        Me.diagnosticRecap_organisme_lieuControle.Location = New System.Drawing.Point(344, 76)
        Me.diagnosticRecap_organisme_lieuControle.Name = "diagnosticRecap_organisme_lieuControle"
        Me.diagnosticRecap_organisme_lieuControle.Size = New System.Drawing.Size(128, 20)
        Me.diagnosticRecap_organisme_lieuControle.TabIndex = 2
        '
        'diagnosticRecap_organisme_heureDebut
        '
        Me.diagnosticRecap_organisme_heureDebut.Location = New System.Drawing.Point(344, 50)
        Me.diagnosticRecap_organisme_heureDebut.Name = "diagnosticRecap_organisme_heureDebut"
        Me.diagnosticRecap_organisme_heureDebut.Size = New System.Drawing.Size(56, 20)
        Me.diagnosticRecap_organisme_heureDebut.TabIndex = 1
        '
        'diagnosticRecap_organisme_heureFin
        '
        Me.diagnosticRecap_organisme_heureFin.Location = New System.Drawing.Point(416, 50)
        Me.diagnosticRecap_organisme_heureFin.Name = "diagnosticRecap_organisme_heureFin"
        Me.diagnosticRecap_organisme_heureFin.Size = New System.Drawing.Size(56, 20)
        Me.diagnosticRecap_organisme_heureFin.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(401, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(14, 16)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "/"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'controleIsPartiel
        '
        Me.controleIsPartiel.Enabled = False
        Me.controleIsPartiel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.controleIsPartiel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.controleIsPartiel.Location = New System.Drawing.Point(344, 98)
        Me.controleIsPartiel.Name = "controleIsPartiel"
        Me.controleIsPartiel.Size = New System.Drawing.Size(120, 16)
        Me.controleIsPartiel.TabIndex = 9
        Me.controleIsPartiel.TabStop = False
        Me.controleIsPartiel.Text = "Contrôle partiel"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(8, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 16)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "N°Agrément : "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(8, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 16)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Nom : "
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_organisme_nom
        '
        Me.diagnosticRecap_organisme_nom.Location = New System.Drawing.Point(104, 24)
        Me.diagnosticRecap_organisme_nom.Name = "diagnosticRecap_organisme_nom"
        Me.diagnosticRecap_organisme_nom.ReadOnly = True
        Me.diagnosticRecap_organisme_nom.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_organisme_nom.TabIndex = 0
        Me.diagnosticRecap_organisme_nom.TabStop = False
        '
        'diagnosticRecap_organisme_agrement
        '
        Me.diagnosticRecap_organisme_agrement.Location = New System.Drawing.Point(104, 48)
        Me.diagnosticRecap_organisme_agrement.Name = "diagnosticRecap_organisme_agrement"
        Me.diagnosticRecap_organisme_agrement.ReadOnly = True
        Me.diagnosticRecap_organisme_agrement.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_organisme_agrement.TabIndex = 1
        Me.diagnosticRecap_organisme_agrement.TabStop = False
        Me.diagnosticRecap_organisme_agrement.Text = "E001"
        '
        'diagnosticRecap_organisme_inspecteurNum
        '
        Me.diagnosticRecap_organisme_inspecteurNum.Location = New System.Drawing.Point(104, 96)
        Me.diagnosticRecap_organisme_inspecteurNum.Name = "diagnosticRecap_organisme_inspecteurNum"
        Me.diagnosticRecap_organisme_inspecteurNum.ReadOnly = True
        Me.diagnosticRecap_organisme_inspecteurNum.Size = New System.Drawing.Size(96, 20)
        Me.diagnosticRecap_organisme_inspecteurNum.TabIndex = 3
        Me.diagnosticRecap_organisme_inspecteurNum.TabStop = False
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(8, 96)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(88, 16)
        Me.Label34.TabIndex = 13
        Me.Label34.Text = "N° Inspecteur : "
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'grpProprio
        '
        Me.grpProprio.Controls.Add(Me.btn_voirFicheExploitant)
        Me.grpProprio.Controls.Add(Me.diagnosticRecap_proprietaire_representant)
        Me.grpProprio.Controls.Add(Me.Label37)
        Me.grpProprio.Controls.Add(Me.diagnosticRecap_proprietaire_adresse)
        Me.grpProprio.Controls.Add(Me.Label14)
        Me.grpProprio.Controls.Add(Me.Label13)
        Me.grpProprio.Controls.Add(Me.diagnosticRecap_proprietaire_nom)
        Me.grpProprio.Controls.Add(Me.diagnosticRecap_proprietaire_codeApe)
        Me.grpProprio.Controls.Add(Me.Label20)
        Me.grpProprio.Controls.Add(Me.diagnosticRecap_proprietaire_numSiren)
        Me.grpProprio.Controls.Add(Me.Label21)
        Me.grpProprio.Controls.Add(Me.diagnosticRecap_proprietaire_ville)
        Me.grpProprio.Controls.Add(Me.Label39)
        Me.grpProprio.Controls.Add(Me.diagnosticRecap_proprietaire_codePostal)
        Me.grpProprio.Controls.Add(Me.Label40)
        Me.grpProprio.Controls.Add(Me.Label10)
        Me.grpProprio.Controls.Add(Me.diagnosticRecap_proprietaire_raisonSociale)
        Me.grpProprio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpProprio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpProprio.Location = New System.Drawing.Point(502, 8)
        Me.grpProprio.Name = "grpProprio"
        Me.grpProprio.Size = New System.Drawing.Size(488, 170)
        Me.grpProprio.TabIndex = 2
        Me.grpProprio.TabStop = False
        Me.grpProprio.Text = "Propriétaire du matériel"
        '
        'btn_voirFicheExploitant
        '
        Me.btn_voirFicheExploitant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_voirFicheExploitant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_voirFicheExploitant.ForeColor = System.Drawing.Color.White
        Me.btn_voirFicheExploitant.Image = CType(resources.GetObject("btn_voirFicheExploitant.Image"), System.Drawing.Image)
        Me.btn_voirFicheExploitant.Location = New System.Drawing.Point(338, 143)
        Me.btn_voirFicheExploitant.Name = "btn_voirFicheExploitant"
        Me.btn_voirFicheExploitant.Size = New System.Drawing.Size(128, 24)
        Me.btn_voirFicheExploitant.TabIndex = 0
        Me.btn_voirFicheExploitant.Text = "    Voir la fiche"
        Me.btn_voirFicheExploitant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diagnosticRecap_proprietaire_representant
        '
        Me.diagnosticRecap_proprietaire_representant.Location = New System.Drawing.Point(110, 115)
        Me.diagnosticRecap_proprietaire_representant.Name = "diagnosticRecap_proprietaire_representant"
        Me.diagnosticRecap_proprietaire_representant.ReadOnly = True
        Me.diagnosticRecap_proprietaire_representant.Size = New System.Drawing.Size(356, 20)
        Me.diagnosticRecap_proprietaire_representant.TabIndex = 7
        Me.diagnosticRecap_proprietaire_representant.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(19, 118)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(91, 13)
        Me.Label37.TabIndex = 17
        Me.Label37.Text = "Représentant :"
        '
        'diagnosticRecap_proprietaire_adresse
        '
        Me.diagnosticRecap_proprietaire_adresse.Location = New System.Drawing.Point(110, 70)
        Me.diagnosticRecap_proprietaire_adresse.Name = "diagnosticRecap_proprietaire_adresse"
        Me.diagnosticRecap_proprietaire_adresse.ReadOnly = True
        Me.diagnosticRecap_proprietaire_adresse.Size = New System.Drawing.Size(357, 20)
        Me.diagnosticRecap_proprietaire_adresse.TabIndex = 4
        Me.diagnosticRecap_proprietaire_adresse.TabStop = False
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(46, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 16)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Adresse : "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(22, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Nom-Prénom : "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_proprietaire_nom
        '
        Me.diagnosticRecap_proprietaire_nom.Location = New System.Drawing.Point(110, 47)
        Me.diagnosticRecap_proprietaire_nom.Name = "diagnosticRecap_proprietaire_nom"
        Me.diagnosticRecap_proprietaire_nom.ReadOnly = True
        Me.diagnosticRecap_proprietaire_nom.Size = New System.Drawing.Size(160, 20)
        Me.diagnosticRecap_proprietaire_nom.TabIndex = 1
        Me.diagnosticRecap_proprietaire_nom.TabStop = False
        '
        'diagnosticRecap_proprietaire_codeApe
        '
        Me.diagnosticRecap_proprietaire_codeApe.Location = New System.Drawing.Point(362, 24)
        Me.diagnosticRecap_proprietaire_codeApe.Name = "diagnosticRecap_proprietaire_codeApe"
        Me.diagnosticRecap_proprietaire_codeApe.ReadOnly = True
        Me.diagnosticRecap_proprietaire_codeApe.Size = New System.Drawing.Size(104, 20)
        Me.diagnosticRecap_proprietaire_codeApe.TabIndex = 2
        Me.diagnosticRecap_proprietaire_codeApe.TabStop = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(282, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 16)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Code APE : "
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_proprietaire_numSiren
        '
        Me.diagnosticRecap_proprietaire_numSiren.Location = New System.Drawing.Point(362, 48)
        Me.diagnosticRecap_proprietaire_numSiren.Name = "diagnosticRecap_proprietaire_numSiren"
        Me.diagnosticRecap_proprietaire_numSiren.ReadOnly = True
        Me.diagnosticRecap_proprietaire_numSiren.Size = New System.Drawing.Size(104, 20)
        Me.diagnosticRecap_proprietaire_numSiren.TabIndex = 3
        Me.diagnosticRecap_proprietaire_numSiren.TabStop = False
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(282, 48)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 16)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "N° SIREN : "
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_proprietaire_ville
        '
        Me.diagnosticRecap_proprietaire_ville.Location = New System.Drawing.Point(248, 93)
        Me.diagnosticRecap_proprietaire_ville.Name = "diagnosticRecap_proprietaire_ville"
        Me.diagnosticRecap_proprietaire_ville.ReadOnly = True
        Me.diagnosticRecap_proprietaire_ville.Size = New System.Drawing.Size(219, 20)
        Me.diagnosticRecap_proprietaire_ville.TabIndex = 6
        Me.diagnosticRecap_proprietaire_ville.TabStop = False
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(187, 94)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(64, 16)
        Me.Label39.TabIndex = 16
        Me.Label39.Text = "Ville : "
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_proprietaire_codePostal
        '
        Me.diagnosticRecap_proprietaire_codePostal.Location = New System.Drawing.Point(110, 93)
        Me.diagnosticRecap_proprietaire_codePostal.Name = "diagnosticRecap_proprietaire_codePostal"
        Me.diagnosticRecap_proprietaire_codePostal.ReadOnly = True
        Me.diagnosticRecap_proprietaire_codePostal.Size = New System.Drawing.Size(71, 20)
        Me.diagnosticRecap_proprietaire_codePostal.TabIndex = 5
        Me.diagnosticRecap_proprietaire_codePostal.TabStop = False
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(38, 94)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(72, 16)
        Me.Label40.TabIndex = 16
        Me.Label40.Text = "CP : "
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(5, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 16)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Raison sociale : "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_proprietaire_raisonSociale
        '
        Me.diagnosticRecap_proprietaire_raisonSociale.Location = New System.Drawing.Point(110, 24)
        Me.diagnosticRecap_proprietaire_raisonSociale.Name = "diagnosticRecap_proprietaire_raisonSociale"
        Me.diagnosticRecap_proprietaire_raisonSociale.ReadOnly = True
        Me.diagnosticRecap_proprietaire_raisonSociale.Size = New System.Drawing.Size(160, 20)
        Me.diagnosticRecap_proprietaire_raisonSociale.TabIndex = 0
        Me.diagnosticRecap_proprietaire_raisonSociale.TabStop = False
        '
        'btn_finalisationDiag_imprimerSynthese
        '
        Me.btn_finalisationDiag_imprimerSynthese.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_imprimerSynthese.Enabled = False
        Me.btn_finalisationDiag_imprimerSynthese.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_imprimerSynthese.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_imprimerSynthese.Image = CType(resources.GetObject("btn_finalisationDiag_imprimerSynthese.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_imprimerSynthese.Location = New System.Drawing.Point(381, 629)
        Me.btn_finalisationDiag_imprimerSynthese.Name = "btn_finalisationDiag_imprimerSynthese"
        Me.btn_finalisationDiag_imprimerSynthese.Size = New System.Drawing.Size(184, 24)
        Me.btn_finalisationDiag_imprimerSynthese.TabIndex = 8
        Me.btn_finalisationDiag_imprimerSynthese.Text = "      Synthèse des mesures"
        Me.btn_finalisationDiag_imprimerSynthese.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diagnostic_recap
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_finalisationDiag_valider)
        Me.Controls.Add(Me.btn_finalisationDiag_imprimerSynthese)
        Me.Controls.Add(Me.label_pulveBonEtat)
        Me.Controls.Add(Me.grpDefauts)
        Me.Controls.Add(Me.btn_finalisationDiag_modifierDiag)
        Me.Controls.Add(Me.btn_finalisationDiag_imprimerRapport)
        Me.Controls.Add(Me.grpSynthese)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grpMateriel)
        Me.Controls.Add(Me.grpOrganisme)
        Me.Controls.Add(Me.grpProprio)
        Me.Controls.Add(Me.conclusion_pictoEtat)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diagnostic_recap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "diagnostic_recap"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpSynthese.ResumeLayout(False)
        Me.grpSynthese.PerformLayout()
        CType(Me.conclusion_pictoEtat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDefauts.ResumeLayout(False)
        Me.grpMateriel.ResumeLayout(False)
        Me.grpMateriel.PerformLayout()
        Me.grpOrganisme.ResumeLayout(False)
        Me.grpOrganisme.PerformLayout()
        Me.grpProprio.ResumeLayout(False)
        Me.grpProprio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub diagnostic_recap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Propriété a mettre obligatoirement par programme
        Me.WindowState = FormWindowState.Maximized
        Me.ControlBox = False
        diagnosticRecap_organisme_agrement.Text = GLOB_DIAG_NUMAGR

        '###########################################################################
        '########               Chargement Organisme d'inspection           ########
        '###########################################################################
        Try
            diagnosticRecap_organisme_nom.Text = GLOB_DIAG_NOMAGR
            diagnosticRecap_organisme_agrement.Text = GLOB_DIAG_NUMAGR
            diagnosticRecap_organisme_inspecteur.Text = m_diagnostic.inspecteurPrenom & " " & m_diagnostic.inspecteurNom
            diagnosticRecap_organisme_inspecteurNum.Text = agentCourant.numeroNational
            diagnosticRecap_organisme_dateControle.Text = CDate(m_diagnostic.controleDateDebut).ToShortDateString()
            diagnosticRecap_organisme_lieuControle.Text = m_diagnostic.controleCodePostal & ", " & m_diagnostic.controleCommune
            diagnosticRecap_organisme_heureDebut.Text = CDate(m_diagnostic.controleDateDebut).ToShortTimeString
            m_diagnostic.controleDateFin = CSDate.mysql2access(Date.Now)
            diagnosticRecap_organisme_heureFin.Text = CDate(m_diagnostic.controleDateFin).ToShortTimeString
        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap - Chargement Organisme d'inspection : " & ex.Message.ToString)
        End Try

        '###########################################################################
        '########             Chargement Propriétaire du materiel           ########
        '###########################################################################
        AfficheProprietaire()
        '###########################################################################
        '########                   Chargement contexte controle            ########
        '###########################################################################
        Try
            controleIsComplet.Checked = m_diagnostic.controleIsComplet
            controleIsPartiel.Checked = Not m_diagnostic.controleIsComplet
        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap - Chargement contexte controle : " & ex.Message.ToString)
        End Try

        '###########################################################################
        '########                     Chargement Materiel                   ########
        '###########################################################################
        AffichePulverisateur()
        '###########################################################################
        '########               Chargement du bilan (treeview)              ########
        '###########################################################################
        Try
            '

            ' On efface les items précédent
            list_diagnostic_bilan_O.Items.Clear()
            list_diagnostic_bilan_P.Items.Clear()
            ' On parcourt chaque résultat
            For Each tmpDiagnosticItem As DiagnosticItem In m_diagnostic.diagnosticItemsLst.items
                If Not tmpDiagnosticItem Is Nothing Then
                    If Not tmpDiagnosticItem.itemCodeEtat Is Nothing Then
                        ' Si on a un code état différent de OK, on l'affiche dans le bilan
                        If tmpDiagnosticItem.itemCodeEtat <> DiagnosticItem.EtatDiagItemOK Then

                            ' On ajoute les items aux deux listes
                            Dim ongletId As String = tmpDiagnosticItem.idItem.Substring(0, tmpDiagnosticItem.idItem.Length - 2)
                            Dim titleId As String = tmpDiagnosticItem.idItem.Substring(0, ongletId.Length + 1)
                            Dim groupBoxId As String = tmpDiagnosticItem.idItem.Substring(0, titleId.Length + 1)
                            Dim itemId As String = tmpDiagnosticItem.idItem & "" & tmpDiagnosticItem.itemValue

                            ' On récupère le libellé de l'item
                            Dim tmpItemObject As Object
                            Dim tmpItemLabel As String
                            tmpDiagnosticItem.LibelleLong = CRODIP_ControlLibrary.ParamCtrlDiag.getLibelleLong(itemId, My.Settings.RepertoireParametres & "/" & m_diagnostic.ParamDiag.fichierConfig)
                            tmpDiagnosticItem.LibelleCourt = CRODIP_ControlLibrary.ParamCtrlDiag.getLibelleLong(itemId, My.Settings.RepertoireParametres & "/" & m_diagnostic.ParamDiag.fichierConfig)
                            'ATTENTION , il ne faut pas qu'il y ait de group à plus de 10 elements sinon ça ne fonctionnera plus
                            If itemId.Length > 4 Then
                                tmpItemLabel = itemId & " - " & tmpDiagnosticItem.LibelleLong
                            Else
                                tmpItemLabel = " " & itemId & " - " & tmpDiagnosticItem.LibelleLong
                            End If




                            ' On récupère l'état (1) ou (2) ou (3)
                            Dim itemCode As String = ""
                            If tmpDiagnosticItem.cause = "1" Then
                                itemCode = "(1)"
                                tmpDiagnosticItem.itemCodeEtat = "O"  ' Pourquoi ?
                            End If
                            If tmpDiagnosticItem.cause = "2" Then
                                itemCode = "(2)"
                            End If
                            If tmpDiagnosticItem.cause = "3" Then
                                itemCode = "(3)"
                                tmpDiagnosticItem.itemCodeEtat = "O" ' Pourquoi ?
                            End If

                            ' On alimente la liste 
                            If tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMINEUR Then
                                'Défaut Mineur
                                list_diagnostic_bilan_O.Items.Add(tmpItemLabel & itemCode)
                            End If
                            If tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR Or tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJPRELIM Then
                                'Défaut Majeur et Preliminaire
                                list_diagnostic_bilan_P.Items.Add(tmpItemLabel & itemCode)
                            End If

                            ' on calcule la conclusion
                            'On n'a pas d'item OK, ils ont été éliminés auparavant
                            'Select Case typeCheckbox
                            '    Case CHK_OK
                            '        curDiagnosticItem.itemCodeEtat = "B"
                            '    Case CHK_DEFAUT_MINEUR
                            '        curDiagnosticItem.itemCodeEtat = "O"
                            '    Case CHK_DEFAUT_MAJEUR
                            '        curDiagnosticItem.itemCodeEtat = "P"
                            '    Case CHK_DEFAUT_MAJEURPRELIM
                            '        curDiagnosticItem.itemCodeEtat = "3" ' Déafut Majeur dans les preliminaires
                            'End Select

                            If tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMINEUR Then
                                'Mineur
                                If conclusionDiagnostique = enumConclusionDiag.OK Then
                                    conclusionDiagnostique = enumConclusionDiag.OK_AVECMINEEUR
                                End If
                            End If
                            If tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR Then
                                'Majeur
                                conclusionDiagnostique = enumConclusionDiag.NOK
                            End If
                            If tmpDiagnosticItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJPRELIM Then
                                'Majeur Prelim
                                conclusionDiagnostique = enumConclusionDiag.NOK_PRELIM
                            End If
                        End If

                    End If
                End If
            Next
        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap - Chargement du bilan (treeview) : " & ex.Message.ToString)
        End Try
        ' Triage des listes de defauts
        Static OrdreDeTri As System.Windows.Forms.SortOrder
        OrdreDeTri = 1 - OrdreDeTri
        list_diagnostic_bilan_O.ListViewItemSorter = New CSListViewItemComparer(0, OrdreDeTri)
        list_diagnostic_bilan_P.ListViewItemSorter = New CSListViewItemComparer(0, OrdreDeTri)

        '###########################################################################
        '########               Chargement du bilan (syntheses)             ########
        '###########################################################################
        Try
            diagnosticRecap_synthese_errDebitmetre.Text = m_diagnostic.syntheseErreurDebitmetre
            diagnosticRecap_synthese_errMaxMano.Text = m_diagnostic.syntheseErreurMaxiMano
            diagnosticRecap_synthese_errMoyCine.Text = m_diagnostic.syntheseErreurMoyenneCinemometre
            diagnosticRecap_synthese_errMoyMano.Text = m_diagnostic.syntheseErreurMoyenneMano
            diagnosticRecap_synthese_nbBusesUsees.Text = m_diagnostic.syntheseNbBusesUsees
            diagnosticRecap_synthese_perteChargeMax.Text = m_diagnostic.synthesePerteChargeMaxi
            diagnosticRecap_synthese_perteChargeMoy.Text = m_diagnostic.synthesePerteChargeMoyenne
            diagnosticRecap_synthese_usureMoyBuses.Text = m_diagnostic.syntheseUsureMoyenneBuses
            If (m_diagnostic.diagnosticHelp571.ErreurGlobalePRSRND.HasValue) Then
                diagnosticRecap_synthese_CumulErreurs.Text = m_diagnostic.diagnosticHelp571.ErreurGlobalePRSRND
            Else
                If (m_diagnostic.diagnosticHelp571.ErreurGlobaleDEBRND.HasValue) Then
                    diagnosticRecap_synthese_CumulErreurs.Text = m_diagnostic.diagnosticHelp571.ErreurGlobaleDEBRND
                End If

            End If

        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap - Chargement du bilan (syntheses) : " & ex.Message.ToString)
        End Try

        ' Conclusion sur l'etat du controle
        Select Case conclusionDiagnostique
            Case enumConclusionDiag.OK
                m_diagnostic.controleEtat = Diagnostic.controleEtatOK
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(1)
                label_pulveBonEtat.Text = "Pulvérisateur en bon état"
            Case enumConclusionDiag.OK_AVECMINEEUR
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(1)
                m_diagnostic.controleEtat = Diagnostic.controleEtatOK
                label_pulveBonEtat.Text = "Pulvérisateur en bon état"
            Case enumConclusionDiag.NOK
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(0)
                m_diagnostic.controleEtat = Diagnostic.controleEtatNOKCV
                label_pulveBonEtat.Text = "Défaut(s) sur le pulvérisateur"
            Case enumConclusionDiag.NOK_PRELIM
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(0)
                m_diagnostic.controleEtat = Diagnostic.controleEtatNOKCC
                label_pulveBonEtat.Text = "Défaut(s) sur le pulvérisateur"
            Case Else
                conclusion_pictoEtat.Image = ImageList_Etat.Images.Item(0)
                m_diagnostic.controleEtat = Diagnostic.controleEtatNOKCV
                label_pulveBonEtat.Text = "Défaut(s) sur le pulvérisateur"

        End Select
        'Me.SelectNextControl(diagnosticRecap_organisme_lieuControle, True, True, True, True)
        btn_finalisationDiag_modifierDiag.Focus()
        btn_finalisationDiag_modifierDiag.Select()
        If m_DiagMode = DiagMode.CTRL_VISU Then
            grpOrganisme.Enabled = False
            grpProprio.Enabled = False
            grpMateriel.Enabled = False
            grpDefauts.Enabled = False
            grpSynthese.Enabled = False
            btn_finalisationDiag_modifierDiag.Enabled = False
            btn_finalisationDiag_valider.Text = "Retour"
        End If
        btn_finalisationDiag_modifierDiag.Enabled = m_DiagMode <> DiagMode.CTRL_VISU

    End Sub

    Private Sub AffichePulverisateur()
        Try
            MarquesManager.populateCombobox(GLOB_XML_EMPLACEMENTIDENTIFICATION, cbx_diagnosticRecap_materiel_EmplacementIdentification, "/root", True)
            diagnosticRecap_materiel_identifiant.Text = m_Pulverisateur.numeroNational
            diagnosticRecap_materiel_marque.Text = m_diagnostic.pulverisateurMarque
            diagnosticRecap_materiel_modele.Text = m_diagnostic.pulverisateurModele
            diagnosticRecap_materiel_age.Text = m_diagnostic.pulverisateurAnneeAchat
            diagnosticRecap_materiel_capacite.Text = m_diagnostic.pulverisateurCapacite
            If Not String.IsNullOrEmpty(m_diagnostic.pulverisateurLargeur) Then
                diagnosticRecap_materiel_nbRangs.Text = m_diagnostic.pulverisateurLargeur
            End If
            If Not String.IsNullOrEmpty(m_diagnostic.pulverisateurNbRangs) Then
                diagnosticRecap_materiel_nbRangs.Text = m_diagnostic.pulverisateurNbRangs
            End If
            diagnosticRecap_materiel_largeurRampe.Text = m_diagnostic.pulverisateurLargeurPlantation
            'Categorie
            diagnosticRecap_materiel_type.Text = m_diagnostic.pulverisateurType
            diagnosticRecap_materiel_categorie.Text = m_diagnostic.pulverisateurCategorie
            'Attelage
            diagnosticRecap_materiel_Attelage.Text = m_diagnostic.pulverisateurAttelage
            'Régulation
            diagnosticRecap_materiel_Regulation.Text = m_diagnostic.pulverisateurRegulation & Replace(m_diagnostic.pulverisateurRegulationOptions, "|", ",")
            'Type buse
            diagnosticRecap_materiel_typeBuse.Text = m_diagnostic.buseType
            'Fonctionnement des buses
            diagnosticRecap_materiel_foncBuse.Text = m_diagnostic.buseFonctionnement
            ' Pulverisation
            diagnosticRecap_materiel_Pulverisation.Text = m_diagnostic.pulverisateurPulverisation


            diagnosticRecap_materiel_debitBuse.Text = m_diagnostic.buseDebit
            'Emplacement Identification
            cbx_diagnosticRecap_materiel_EmplacementIdentification.Text = m_diagnostic.pulverisateurEmplacementIdentification

            If String.IsNullOrEmpty(m_diagnostic.pulverisateurNbreExploitants) Then
                tbModeUtilisation.Text = m_diagnostic.pulverisateurModeUtilisation
            Else
                tbModeUtilisation.Text = m_diagnostic.pulverisateurModeUtilisation & " (" & m_diagnostic.pulverisateurNbreExploitants & ")"
            End If


        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap.AffichePulveristeur ERR : " & ex.Message.ToString)
        End Try


    End Sub
    ' Modifier le diag
    Private Sub btn_finalisationDiag_modifierDiag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_modifierDiag.Click
        'Récupération des infos de la fenêtre
        GetInfos()
        Dim ofrmDiag As Form
        If m_diagnostic.controleEtat <> Diagnostic.controleEtatNOKCC Then
            'Activation de la fenêtre
            For Each oForm As Form In MdiParent.MdiChildren
                If TypeOf oForm Is frmDiagnostique Then
                    ofrmDiag = oForm
                    Exit For
                End If
            Next
        Else
            For Each oForm As Form In MdiParent.MdiChildren
                If TypeOf oForm Is controle_preliminaire Then
                    ofrmDiag = oForm
                    Exit For
                End If
            Next
        End If
        If ofrmDiag IsNot Nothing Then
            ofrmDiag.WindowState = FormWindowState.Maximized
            ofrmDiag.Activate()
            Me.Close()
        End If
    End Sub

    ' Validation
    Private Sub btn_finalisationDiag_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_valider.Click
        sender.Enabled = False
        If m_DiagMode = DiagMode.CTRL_VISU Then
            CloseDiagnostic()
            Exit Sub
        End If
        If isValider Then

            Try

                ' On rempli l'objet d'infos
                'objInfos(7) = diagnosticCourant.pulverisateurLargeur
                'objInfos(8) = diagnosticCourant.buseNbBuses

                ' On ouvre le form
                Dim ofrm As New diagnostic_satisfaction(m_diagnostic.proprietaireRaisonSociale, m_diagnostic.proprietaireNom & " " & m_diagnostic.proprietairePrenom, m_diagnostic.proprietaireAdresse & " - " & m_diagnostic.proprietaireCodePostal & ", " & m_diagnostic.proprietaireCommune, m_diagnostic.proprietaireEmail, m_diagnostic.controleDateDebut, m_diagnostic.controleIsComplet, m_Pulverisateur.type, m_diagnostic.organismePresNom, m_diagnostic.inspecteurNom & " " & m_diagnostic.inspecteurPrenom)
                TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)

                Statusbar.clear()
            Catch ex As Exception
                CSDebug.dispError("diag_recap::btn_finalisationDiag_valider_Click 1 : " & ex.Message)
            End Try
            Try
                If Not globFormDiagnostic Is Nothing Then
                    CSDebug.dispInfo("Closing globFormDiagnostic")
                    globFormDiagnostic.Close()
                End If
                If Not globFormControlePreliminaire Is Nothing Then
                    globFormControlePreliminaire.Close()
                End If
            Catch ex As Exception
                CSDebug.dispError("diag_recap::btn_finalisationDiag_valider_Click 2 : " & ex.Message)
            End Try
            Try
                globFormAccueil.loadListPulveExploitation(False)
            Catch ex As Exception
                CSDebug.dispError("Diag. Recap - Reloading list pulvé : Error")
            End Try
            Me.Close()
        Else
            If checkForm() Then
                If MsgBox("Attention, la validation du contrôle est définitive, vous ne pourrez plus revenir en arrière. Etes-vous sûr ?", MsgBoxStyle.YesNo, "Validation du contrôle") = MsgBoxResult.Yes Then
                    diagnosticRecap_organisme_heureDebut.Enabled = False
                    diagnosticRecap_organisme_heureFin.Enabled = False
                    cbx_diagnosticRecap_materiel_EmplacementIdentification.Enabled = False
                    diagnosticRecap_organisme_dateControle.Enabled = False
                    diagnosticRecap_organisme_lieuControle.Enabled = False
                    SauvegarderDiagnostic()
                    MsgBox("Vous pouvez maintenant imprimer le rapport.", MsgBoxStyle.Information)
                End If
            End If


            sender.Enabled = True
        End If
    End Sub
    Private Function SauvegarderDiagnostic() As Boolean
        Dim bReturn As Boolean
        Try
            Try
                Statusbar.display(CONST_STATUTMSG_DIAG_SAVING, True)
                'Lecture de la fenêtre
                GetInfos()
                '
                'Calcul de la date de prochain controle
                m_diagnostic.CalculDateProchainControle()

                Statusbar.display("Mise à jour de l'exploitant", True)
                m_Exploit.numeroSiren = m_diagnostic.proprietaireNumeroSiren
                m_Exploit.dateDernierControle = m_diagnostic.controleDateDebut
                ExploitationManager.save(m_Exploit, agentCourant)

                Statusbar.display("Mise à jour du pulvérisateur", True)
                'Calcul de la date de prochain controle
                m_Pulverisateur.dateProchainControle = m_diagnostic.pulverisateurDateProchainControle
                m_Pulverisateur.emplacementIdentification = m_diagnostic.pulverisateurEmplacementIdentification
                m_Pulverisateur.SetControleEtat(m_diagnostic)
                m_Pulverisateur.DecodageAutomatiqueDefauts(m_diagnostic.diagnosticItemsLst.Values)
                PulverisateurManager.save(m_Pulverisateur, m_Exploit.id, agentCourant)


                ' Enregistrement du diag
                Statusbar.display("Récupération d'un nouvel ID", True)
                Dim tmpNewDiagId As String
                'tmpNewDiagId = InputBox("DiagID", "Entrez le numéro du diag", agentCourant.idStructure & "-" & agentCourant.id & "-")
                tmpNewDiagId = DiagnosticManager.getNewId(agentCourant)
                m_diagnostic.id = tmpNewDiagId

                Statusbar.display("Génération du rapport d'inspection", True)
                If createRapportInspection_cr() Then
                    Statusbar.display("Génération du rapport de synthèse des mesures", True)
                    If Not createEtatSyntheseDesMesures() Then
                        CSDebug.dispError("Erreur en génération de l'état de synthèse des mesures")
                    End If

                    'diagnosticCourant.controleTarif = diagnosticCourantTarif.ToString
                    m_diagnostic.dateModificationAgent = CSDate.mysql2access(Date.Now)
                    m_diagnostic.dateModificationCrodip = "01/01/1900"
                    Statusbar.display("Sauvegarde du diagnostic" & m_diagnostic.id, True)
                    'on remet les Id à "" pour forcer la création d'un nouvel ID
                    m_diagnostic.diagnosticHelp551.id = ""
                    m_diagnostic.diagnosticHelp5621.id = ""
                    m_diagnostic.diagnosticHelp552.id = ""
                    m_diagnostic.diagnosticHelp5622.id = ""
                    m_diagnostic.diagnosticHelp811.id = ""
                    m_diagnostic.diagnosticHelp8312.id = ""
                    m_diagnostic.diagnosticInfosComplementaires.id = ""
                    Dim bSave As Boolean
                    bSave = DiagnosticManager.save(m_diagnostic)
                    If Not bSave Then
                        CSDebug.dispFatal("Diagnostic-recap.btn_finalisationDiag_valider_Click ERR : ERREUR EN SAUVEGARDE DE DIAGNOSTIQUE=> FERMERTURE DE l'APPLICATION, CONTACTER LE CRODIP")
                        MsgBox("ERREUR EN SAUVEGARDE DE DIAGNOSTIQUE => FERMERTURE DE l'APPLICATION, CONTACTER LE CRODIP")
                        Application.Exit()
                    End If

                    Statusbar.display("Mise à jour du manomètre et banc de mesures", True)
                    m_diagnostic.setUtiliseBancEtMano(agentCourant)


                    ' On met en place les boutons
                    btn_finalisationDiag_valider.Text = "Poursuivre"
                    btn_finalisationDiag_imprimerRapport.Enabled = True
                    btn_finalisationDiag_modifierDiag.Enabled = False
                    btn_finalisationDiag_imprimerSynthese.Enabled = True
                    isValider = True


                    'Incrément du nombre de diag réalisé
                    My.Settings.nbControlesAvantAlerte = My.Settings.nbControlesAvantAlerte + 1
                    My.Settings.Save()
                    Statusbar.display("", False)
                    bReturn = True
                Else
                    CSDebug.dispFatal("Erreur en génération de rapport, recommencez. En cas de récidive, prevenez le CRODIP")
                End If
            Catch ex As Exception
                CSDebug.dispFatal("Erreur lors de l'enregistrement du diag : " & ex.Message.ToString)
                Statusbar.display("Erreur lors de l'enregistrement du contrôle.", False)
                bReturn = False
            End Try

        Catch ex As Exception
            CSDebug.dispFatal("Diagnostic_recap.SauvegarderDiagnostic ERR : " & ex.Message.ToString)
            bReturn = False

        End Try
    End Function
    Private Function GetInfos() As Boolean
        Dim bReturn As Boolean
        Try
            'Dates de Controles
            m_diagnostic.controleDateDebut = CDate(diagnosticRecap_organisme_dateControle.Text).ToShortDateString()
            m_diagnostic.controleDateFin = CDate(diagnosticRecap_organisme_dateControle.Text).ToShortDateString()
            If m_diagnostic.controleEtat = "" Then
                m_diagnostic.controleEtat = Diagnostic.controleEtatNOKCV
            End If
            Dim szH = diagnosticRecap_organisme_heureDebut.Text
            If Not String.IsNullOrEmpty(szH) Then
                Dim dDiag, dH As Date
                dH = CDate(szH)
                dDiag = CDate(m_diagnostic.controleDateDebut)
                m_diagnostic.controleDateDebut = dDiag.ToShortDateString() & " " & dH.ToShortTimeString()
            End If
            szH = diagnosticRecap_organisme_heureFin.Text
            If Not String.IsNullOrEmpty(szH) Then
                Dim dDiag, dH As Date
                dH = CDate(szH)
                dDiag = CDate(m_diagnostic.controleDateFin)
                m_diagnostic.controleDateFin = dDiag.ToShortDateString() & " " & dH.ToShortTimeString()
            End If
            'Emplacemement identification
            m_diagnostic.pulverisateurEmplacementIdentification = CSDb.secureString(cbx_diagnosticRecap_materiel_EmplacementIdentification.Text)
            'Emplacemement Numéo de SIREN
            m_diagnostic.proprietaireNumeroSiren = CSDb.secureString(diagnosticRecap_proprietaire_numSiren.Text)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_recap.GetInfos ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' génération du rapport de synthèses des mesures
    ''' </summary>
    ''' <remarks></remarks>
    Private Function createEtatSyntheseDesMesures() As Boolean
        Dim _PathToSynthesePDF As String
        Dim bReturn = False
        Try
            Dim oEtat As New EtatSyntheseMesures(m_diagnostic)
            oEtat.GenereEtat()
            _PathToSynthesePDF = oEtat.getFileName()
            m_diagnostic.SMFileName = _PathToSynthesePDF
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("createEtatSyntheseDesMesures ERR : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ' rapport D'inspection
    Private Function createRapportInspection_cr() As Boolean
        Dim bReturn As Boolean
        Dim pathRapport As String
        Try
            Dim oEtat As New EtatRapportInspection(m_diagnostic)
            oEtat.GenereEtat()
            pathRapport = oEtat.getFileName()
            m_diagnostic.RIFileName = pathRapport
            bReturn = File.Exists(CONST_PATH_EXP & pathRapport)
        Catch ex As Exception
            CSDebug.dispError("createRapportInspection_cr ERR : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function 'createRapportInspection_cr
    'Private Function createRapportInspection()
    '    Dim pdfReader As PdfReader
    '    Dim pdfStamper As PdfStamper
    '    Dim pdfFormFields As AcroFields
    '    Dim lstSortedDiagItem As New SortedList()
    '    Try
    '        '

    '        'Cette boucle est une copie épurée de celle de la section D plus bas. 
    '        'J'ai du la reprendre pour connaitre le nombre de défauts avant de choisir le template a appliquer sans passer des heures a modifier le code
    '        Dim tmp_O As Integer = 0
    '        Dim tmp_PC As Integer = 0
    '        Try
    '            ' On parcourt chaque résultat
    '            Dim nombreColonnes As Integer = 1

    '            For Each tmpDiagnosticItem As DiagnosticItem In diagnosticCourant.diagnosticItemsLst.items
    '                If Not tmpDiagnosticItem Is Nothing Then
    '                    If Not tmpDiagnosticItem.itemCodeEtat Is Nothing Then
    '                        ' Si on a un code état différent de OK, on l'affiche dans le bilan
    '                        If tmpDiagnosticItem.itemCodeEtat = "O" Or tmpDiagnosticItem.itemCodeEtat = "P" Or tmpDiagnosticItem.itemCodeEtat = "C" Then
    '                            If tmpDiagnosticItem.itemCodeEtat = "O" Then
    '                                tmp_O += 1
    '                            ElseIf tmpDiagnosticItem.itemCodeEtat = "P" Or tmpDiagnosticItem.itemCodeEtat = "C" Then
    '                                tmp_PC += 1
    '                            End If
    '                            'On Remplit la liste Triée
    '                            lstSortedDiagItem.Add(tmpDiagnosticItem.getItemCode(), tmpDiagnosticItem)
    '                        End If
    '                    End If
    '                End If
    '            Next
    '        Catch ex As Exception
    '            CSDebug.dispFatal("printRapportInspection - Synthèse du controle : " & ex.Message.ToString)
    '        End Try

    '        Dim pdfTemplate As String
    '        If tmp_O > 8 Or tmp_PC > 8 Then
    '            If diagnosticCourant.controleIsComplet Then
    '                pdfTemplate = CONST_PATH_DOCS & CONST_DOC_RAPINSP_COMPLET_2P & ".pdf"
    '            Else
    '                pdfTemplate = CONST_PATH_DOCS & CONST_DOC_RAPINSP_CONTREVISITE_2P & ".pdf"
    '            End If
    '        Else
    '            If diagnosticCourant.controleIsComplet Then
    '                pdfTemplate = CONST_PATH_DOCS & CONST_DOC_RAPINSP_COMPLET & ".pdf"
    '            Else
    '                pdfTemplate = CONST_PATH_DOCS & CONST_DOC_RAPINSP_CONTREVISITE & ".pdf"
    '            End If
    '        End If

    '        'pathRapport = CONST_PATH_EXP & CONST_DOC_RAPINSP & "_" & CSDate.getDateId(Date.Now) & "_" & diagnosticCourant.id & ".pdf"
    '        pathRapport = CONST_PATH_EXP & CSDiagPdf.makeFilename(pulverisateurCourant.id, CSDiagPdf.TYPE_RAPPORT_INSPECTION) & ".pdf"
    '        Dim newFile As String = pathRapport
    '        ' Ouverture des pdf
    '        pdfReader = New PdfReader(pdfTemplate)
    '        pdfStamper = New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create))
    '        pdfFormFields = pdfStamper.AcroFields

    '        ' A - Informations organisme d'inspection
    '        pdfFormFields.SetField("orgaI_insp_nomPrenom", diagnosticCourant.inspecteurPrenom & " " & diagnosticCourant.inspecteurNom)
    '        pdfFormFields.SetField("orgaI_insp_num", agentCourant.numeroNational)
    '        pdfFormFields.SetField("controle_date", CDate(diagnosticCourant.controleDateDebut).ToShortDateString())
    '        pdfFormFields.SetField("controle_lieu", diagnosticCourant.controleCodePostal & ", " & diagnosticCourant.controleCommune)
    '        pdfFormFields.SetField("controle_heureDeb", CDate(diagnosticCourant.controleDateDebut).ToShortTimeString())
    '        pdfFormFields.SetField("controle_heureFin", CDate(diagnosticCourant.controleDateFin).ToShortTimeString())
    '        'Realisation d'un précontrole
    '        If diagnosticCourant.controleIsPreControleProfessionel Then
    '            pdfFormFields.SetField("controle_isPreControle", "Yes")
    '        End If

    '        pdfFormFields.SetField("controle_numero", diagnosticCourant.id)

    '        ' B - Informations sur le propriétaire
    '        pdfFormFields.SetField("proprio_raisonSociale", diagnosticCourant.proprietaireRaisonSociale)
    '        pdfFormFields.SetField("proprio_nomPrenom", diagnosticCourant.proprietaireNom & " " & diagnosticCourant.proprietairePrenom)
    '        pdfFormFields.SetField("proprio_representePar", diagnosticCourant.proprietaireRepresentant)
    '        pdfFormFields.SetField("proprio_adresse", diagnosticCourant.proprietaireAdresse)
    '        pdfFormFields.SetField("proprio_codePostal", diagnosticCourant.proprietaireCodePostal)
    '        pdfFormFields.SetField("proprio_ville", diagnosticCourant.proprietaireCommune)
    '        pdfFormFields.SetField("proprio_numSiren", diagnosticCourant.proprietaireNumeroSiren)
    '        pdfFormFields.SetField("proprio_codeApe", diagnosticCourant.proprietaireCodeApe)

    '        ' Type de controle 
    '        If diagnosticCourant.controleIsComplet Then
    '            pdfFormFields.SetField("controle_isComplet", "Yes")
    '        Else
    '            pdfFormFields.SetField("controle_datePrecedentControle", CDate(diagnosticCourant.controleDateDernierControle).ToShortDateString())
    '            pdfFormFields.SetField("controle_OrgaPrecedentControle", diagnosticCourant.organismeOriginePresNom)
    '            pdfFormFields.SetField("controle_InspPrecedentControle", diagnosticCourant.inspecteurOrigineNom & " " & diagnosticCourant.inspecteurOriginePrenom)

    '        End If

    '        ' Date dernier contrôle
    '        If diagnosticCourant.controleIsComplet Then
    '            pdfFormFields.SetField("controle_isPartiel_date", "")
    '        Else
    '            pdfFormFields.SetField("controle_isPartiel_date", "Suite à un contrôle du : " & diagnosticCourant.controleDateDernierControle)
    '            pdfFormFields.SetField("phrase_controle_isPartiel", "Ce document constitue le rapport d'inspection suite à une contre visite; il doit être accompagné du rapport de visite initial")
    '        End If

    '        ' C - Information sur le materiel
    '        pdfFormFields.SetField("materiel_identifiant", pulverisateurCourant.numeroNational)
    '        pdfFormFields.SetField("ancienidentifiant", diagnosticCourant.pulverisateurAncienId)
    '        pdfFormFields.SetField("materiel_marque", diagnosticCourant.pulverisateurMarque)
    '        pdfFormFields.SetField("materiel_modele", diagnosticCourant.pulverisateurModele)
    '        pdfFormFields.SetField("materiel_capacite", diagnosticCourant.pulverisateurCapacite)
    '        pdfFormFields.SetField("materiel_largeur", diagnosticCourant.pulverisateurLargeur)
    '        pdfFormFields.SetField("materiel_nbRangs", diagnosticCourant.pulverisateurNbRangs)
    '        pdfFormFields.SetField("materiel_annee", diagnosticCourant.pulverisateurAnneeAchat)
    '        pdfFormFields.SetField("materiel_type", diagnosticCourant.pulverisateurType)
    '        pdfFormFields.SetField("materiel_categorie", pulverisateurCourant.categorie)
    '        pdfFormFields.SetField("materiel_attelage", diagnosticCourant.pulverisateurAttelage)
    '        pdfFormFields.SetField("materiel_regulation", pulverisateurCourant.getRegulation())
    '        pdfFormFields.SetField("materiel_typeBuses", diagnosticCourant.buseType)
    '        '            pdfFormFields.SetField("materiel_fonctionnement", pulverisateurCourant.buseFonctionnement)
    '        pdfFormFields.SetField("materiel_typeJet", pulverisateurCourant.getPulverisation())
    '        'Debit buses
    '        pdfFormFields.SetField("materiel_debitBuses", diagnosticCourant.buseDebit)





    '        ' Type de buse 
    '        pdfFormFields.SetField("materiel_fonctionnement", diagnosticCourant.buseFonctionnement)

    '        pdfFormFields.SetField("materiel_emplacementIdentifiant", diagnosticCourant.pulverisateurEmplacementIdentification)

    '        ' D - Synthèse du controle
    '        Try
    '            ' On parcourt chaque résultat
    '            Dim nombreColonnes As Integer = 1
    '            Dim tmpIdCol_O As Integer = 1
    '            Dim tmpIdCol_PC As Integer = 1
    '            For Each oItem As DictionaryEntry In lstSortedDiagItem
    '                Dim tmpDiagnosticItem As DiagnosticItem = oItem.Value
    '                If Not tmpDiagnosticItem Is Nothing Then
    '                    If Not tmpDiagnosticItem.itemCodeEtat Is Nothing Then
    '                        ' Si on a un code état différent de OK, on l'affiche dans le bilan
    '                        If tmpDiagnosticItem.itemCodeEtat = "O" Or tmpDiagnosticItem.itemCodeEtat = "P" Or tmpDiagnosticItem.itemCodeEtat = "C" Then


    '                            ' On ajoute les items aux deux listes
    '                            Dim ongletId As String = tmpDiagnosticItem.idItem.Substring(0, tmpDiagnosticItem.idItem.Length - 2)
    '                            Dim titleId As String = tmpDiagnosticItem.idItem.Substring(0, ongletId.Length + 1)
    '                            Dim groupBoxId As String = tmpDiagnosticItem.idItem.Substring(0, titleId.Length + 1)
    '                            Dim itemId As String = tmpDiagnosticItem.idItem & "" & tmpDiagnosticItem.itemValue

    '                            ' On récupère le libellé de l'item
    '                            Dim tmpItemObject As Object
    '                            Dim tmpItemLabel As String
    '                            'If ongletId = "1" Then
    '                            '    tmpItemObject = CSForm.getControlByName("RadioButton_controlePreliminaire_" & itemId, globFormControlePreliminaire)
    '                            '    tmpItemLabel = tmpItemObject.text
    '                            'Else
    '                            '    tmpItemObject = CSForm.getControlByName("RadioButton_diagnostic_" & itemId, globFormDiagnostic)
    '                            '    tmpItemLabel = tmpItemObject.text
    '                            'End If
    '                            tmpItemLabel = itemId & " - " & CRODIP_ControlLibrary.ParamCtrlDiag.getLibelleLong(itemId, My.Settings.RepertoireParametres & "/" & diagnosticCourant.ParamDiag.fichierConfig)

    '                            '=================================

    '                            ' On ajoute les items aux deux listes
    '                            Dim itemCode As String = ""
    '                            If tmpDiagnosticItem.cause = "1" Then
    '                                itemCode = "(1)"
    '                                tmpDiagnosticItem.itemCodeEtat = "O"
    '                            End If
    '                            If tmpDiagnosticItem.cause = "2" Then
    '                                itemCode = "(2)"
    '                            End If
    '                            If tmpDiagnosticItem.cause = "3" Then
    '                                itemCode = "(3)"
    '                            End If


    '                            If tmpDiagnosticItem.itemCodeEtat = "O" Then
    '                                pdfFormFields.SetField("controle_listO_" & tmpIdCol_O, pdfFormFields.GetField("controle_listO_" & tmpIdCol_O) & tmpItemLabel & " " & itemCode & vbNewLine)
    '                                If tmpIdCol_O = nombreColonnes Then
    '                                    tmpIdCol_O = 1
    '                                Else
    '                                    tmpIdCol_O += 1
    '                                End If
    '                            ElseIf tmpDiagnosticItem.itemCodeEtat = "P" Or tmpDiagnosticItem.itemCodeEtat = "C" Then
    '                                pdfFormFields.SetField("controle_listPC_" & tmpIdCol_PC, pdfFormFields.GetField("controle_listPC_" & tmpIdCol_PC) & tmpItemLabel & " " & itemCode & vbNewLine)
    '                                If tmpIdCol_PC = nombreColonnes Then
    '                                    tmpIdCol_PC = 1
    '                                Else
    '                                    tmpIdCol_PC += 1
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            Next
    '        Catch ex As Exception
    '            CSDebug.dispFatal("printRapportInspection - Synthèse du controle : " & ex.Message.ToString)
    '        End Try

    '        ' Dbis - Synthese des mesures
    '        pdfFormFields.SetField("controle_errMoyMano", diagnosticCourant.syntheseErreurMoyenneMano)
    '        pdfFormFields.SetField("controle_errMaxMano", diagnosticCourant.syntheseErreurMaxiMano)
    '        pdfFormFields.SetField("controle_errDebitmetre", diagnosticCourant.syntheseErreurDebitmetre)
    '        pdfFormFields.SetField("controle_errMoyCine", diagnosticCourant.syntheseErreurMoyenneCinemometre)
    '        pdfFormFields.SetField("controle_usureMoyBuses", diagnosticCourant.syntheseUsureMoyenneBuses)
    '        pdfFormFields.SetField("controle_nbBusesUsees", diagnosticCourant.syntheseNbBusesUsees)
    '        pdfFormFields.SetField("controle_perteChargeMoy", diagnosticCourant.synthesePerteChargeMoyenne)
    '        pdfFormFields.SetField("controle_perteChargeMax", diagnosticCourant.synthesePerteChargeMaxi)

    '        ' E - Conclusions
    '        If conclusionEtat = "B" Or conclusionEtat = "O" Then
    '            pdfFormFields.SetField("controle_isBonEtat", "Yes")
    '        Else
    '            If conclusionEtat = "P" Then
    '                pdfFormFields.SetField("controle_isCtrlPartiel", "Yes")
    '            Else
    '                pdfFormFields.SetField("controle_isCtrlComplet", "Yes")
    '            End If
    '        End If
    '        If conclusionEtat <> "B" And conclusionEtat <> "O" Then
    '            pdfFormFields.SetField("controle_dateLimiteCtrl", Date.Now.AddMonths(4).ToShortDateString)
    '        End If
    '        pdfFormFields.SetField("controle_dateNow", Date.Now.ToShortDateString)



    '        ' On affiche le PDF rempli
    '        'CSFile.open(newFile)
    '    Catch ex As Exception
    '        Console.Write("[Erreur] - Génération Rapport d'Inspection : " & ex.Message.ToString & vbNewLine)
    '    End Try
    '    ' On referme le PDF
    '    pdfStamper.FormFlattening = True
    '    pdfStamper.Close()
    '    pdfReader.Close()
    'End Function
    Private Sub btn_finalisationDiag_imprimerRapport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_imprimerRapport.Click
        Try
            ' On affiche le PDF rempli
            CSFile.open(CONST_PATH_EXP & m_diagnostic.RIFileName)
        Catch ex As Exception
            Console.Write("[Erreur] - Génération Rapport d'Inspection : " & ex.Message.ToString & vbNewLine)
        End Try
    End Sub

    ' Enregistrement de la facture (pour synchronisation)
    Private Function createFacture()
        Try

            '############################################################
            ' Sauvegarde des infos générales de la facture
            Dim newFacture As DiagnosticFacture = New DiagnosticFacture
            newFacture.id = m_diagnostic.id

            newFacture.factureReference = ""
            newFacture.factureDate = ""
            newFacture.factureTotal = ""

            newFacture.emetteurOrganisme = ""
            newFacture.emetteurOrganismeAdresse = ""
            newFacture.emetteurOrganismeCpVille = ""
            newFacture.emetteurOrganismeTelFax = ""
            newFacture.emetteurOrganismeSiren = ""
            newFacture.emetteurOrganismeTva = ""
            newFacture.emetteurOrganismeRcs = ""

            newFacture.recepteurRaisonSociale = ""
            newFacture.recepteurProprio = ""
            newFacture.recepteurCpVille = ""

            DiagnosticFactureManager.save(newFacture)
            '############################################################
            ' Sauvegarde des items de la facture


        Catch ex As Exception
            CSDebug.dispError("DiagnosticRecap.createFacture() : " & ex.Message)
        End Try
    End Function

    Private Sub btn_finalisationDiag_imprimerSynthese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_imprimerSynthese.Click
        Dim strFilePath As String


        Try
            Statusbar.display("Affichage du rapport de synthèse", True)
            ' On affiche le PDF rempli
            CSFile.open(CONST_PATH_EXP & m_diagnostic.SMFileName)
            Statusbar.display("", True)
        Catch ex As Exception
            CSDebug.dispError("Erreur lors de la génération de l'état des Debit de buses : " & ex.Message.ToString)
        End Try

    End Sub
    Private Function checkForm() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        If cbx_diagnosticRecap_materiel_EmplacementIdentification.Text = "" Then
            MsgBox("Vous devez renseigner l'emplacement de l'identification")
            cbx_diagnosticRecap_materiel_EmplacementIdentification.Focus()
            bReturn = False
        End If
        If diagnosticRecap_proprietaire_numSiren.Text = "" Then
            MsgBox("Vous devez renseigner le numéro de SIREN du propriétaire")
            diagnosticRecap_proprietaire_numSiren.Focus()
            bReturn = False
        Else
            If Not CSCheck.numSIREN(diagnosticRecap_proprietaire_numSiren.Text) Then
                MsgBox("Vous devez entrer un numéro de SIREN valide.")
                diagnosticRecap_proprietaire_numSiren.Focus()
                bReturn = False

            End If

        End If
        'Vérification des heures de controle
        If Not CSDate.CheckHours(diagnosticRecap_organisme_heureDebut.Text) Then

            MsgBox("Format heure début incorrect : HH:MM")
            bReturn = False
        End If
        If Not CSDate.CheckHours(diagnosticRecap_organisme_heureFin.Text) Then

            MsgBox("Format heure fin incorrect : HH:MM")
            bReturn = False
        End If
        If bReturn Then
            If DateDiff(DateInterval.Minute, CDate(diagnosticRecap_organisme_heureDebut.Text), CDate(diagnosticRecap_organisme_heureFin.Text)) < 0 Then
                MsgBox("L'heure de fin doit être supérieure à l'heure de début")
                bReturn = False

            End If
        End If

        Return bReturn
    End Function

    Private Sub diagnosticRecap_proprietaire_numSiren_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles diagnosticRecap_proprietaire_numSiren.KeyPress
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 9)
        End If

    End Sub

    Private Sub diagnosticRecap_materiel_EmplacementIdentification_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "Alphanumerique")
    End Sub

    Private Sub btn_FichePulve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub fichePulve_isPneumatique_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub fichePulve_isJetPorte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub fichePulve_isJetProjete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_voirFiche_Pulve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_voirFiche_Pulve.Click
        displayFichePulve()
    End Sub
    Private Function displayFichePulve()
        ' Mise à jour de la barre de status
        Statusbar.display("Chargement du pulvérisateur n°" & m_diagnostic.pulverisateurId)

        'Recupération de l'emplacement de l'identification 
        m_Pulverisateur.emplacementIdentification = cbx_diagnosticRecap_materiel_EmplacementIdentification.Text
        ' Affichage de la fiche du pulvérisateur

        Dim formEdition_fiche_pulve As New ajout_pulve2()
        formEdition_fiche_pulve.setContexte(ajout_pulve2.MODE.VERIF, agentCourant, m_Pulverisateur, m_diagnostic)
        formEdition_fiche_pulve.ShowDialog(Me.MdiParent)
        m_diagnostic.setPulverisateur(m_Pulverisateur)
        AffichePulverisateur()
    End Function



    Private Sub btn_voirFicheExploitant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_voirFicheExploitant.Click
        ' Mise à jour de la barre de status
        Statusbar.display("Chargement de l'exploitant n°" & m_diagnostic.proprietaireId)

        ' Affichage de la fiche du pulvérisateur
        'Récupératino du numéri de SIREN
        m_Exploit.numeroSiren = diagnosticRecap_proprietaire_numSiren.Text
        Dim formEdition_fiche_pulve As New fiche_exploitant()
        formEdition_fiche_pulve.setContexte(True, m_Exploit)
        formEdition_fiche_pulve.DisplayNomEtPrenomduRepresentant(True)
        '        formEdition_fiche_pulve.SetFormRecapDiag(True)
        formEdition_fiche_pulve.ShowDialog(Me.MdiParent)
        m_diagnostic.SetProprietaire(m_Exploit)
        AfficheProprietaire()

    End Sub

    Private Sub AfficheProprietaire()
        Try
            diagnosticRecap_proprietaire_raisonSociale.Text = m_diagnostic.proprietaireRaisonSociale
            diagnosticRecap_proprietaire_nom.Text = m_diagnostic.proprietaireNom & " " & m_diagnostic.proprietairePrenom
            diagnosticRecap_proprietaire_codeApe.Text = m_diagnostic.proprietaireCodeApe
            diagnosticRecap_proprietaire_numSiren.Text = m_diagnostic.proprietaireNumeroSiren
            If String.IsNullOrEmpty(m_diagnostic.proprietaireNumeroSiren) Then
                diagnosticRecap_proprietaire_numSiren.Enabled = True
                diagnosticRecap_proprietaire_numSiren.ReadOnly = False
            End If
            diagnosticRecap_proprietaire_ville.Text = m_diagnostic.proprietaireCommune
            diagnosticRecap_proprietaire_codePostal.Text = m_diagnostic.proprietaireCodePostal
            diagnosticRecap_proprietaire_adresse.Text = m_diagnostic.proprietaireAdresse
            diagnosticRecap_proprietaire_representant.Text = m_diagnostic.proprietaireRepresentant
        Catch ex As Exception
            CSDebug.dispError("Contrôle Récap - Chargement Propriétaire du materiel : " & ex.Message.ToString)
        End Try

    End Sub
    Private Sub CloseDiagnostic()
        ' On vide les infos de session
        m_diagnostic = Nothing
        m_Pulverisateur = Nothing
        'Fermeture de fenpetres Filles de diag
        Dim ofrm As Form
        Dim ofrmAccueil As accueil
        For Each ofrm In MdiParent.MdiChildren
            If Not TypeOf ofrm Is accueil Then
                ofrm.Close()
            Else
                ofrmAccueil = ofrm
                ofrmAccueil.LoadListeExploitation()
                ofrmAccueil.loadListPulveExploitation(False)
                ofrmAccueil.WindowState = FormWindowState.Maximized
            End If
        Next

        ' On ferme le contrôle
        Statusbar.clear()

    End Sub
End Class
