Imports CRODIPWS

Public Class frmRPCalculVolumeHa
    Inherits System.Windows.Forms.Form
    Implements IfrmCRODIP

    Private m_oDiag As RPDiagnostic

#Region " Code généré par le Concepteur Windows Form "
    Friend WithEvents GroupBox_infos As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents infosDebitMoyPressionMesure As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents infosPressionTravailMoinsPerteCharge As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbPressionTravail As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents infosVitesseReelle1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents infosVitesseReelle2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents infosLargeur As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents infosNbBuses As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbVolhaPMV1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbVolHaPTV1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbNbNiveauxBuses As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents infosPressionMesure As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents nupNbreNiveaux As System.Windows.Forms.NumericUpDown
    Friend WithEvents nupNbreDescentes As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents calcDeb2Debit As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents calcDeb2Largeur As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents calcDeb2Pression As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents calcDeb2Vitesse As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents calcDeb1VolEauHa As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents calcDeb1Largeur As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents calcDeb1Vitesse As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents calcDeb1DebitMoyConnu As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents calcDeb1PressionConnue As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_calcAuto As System.Windows.Forms.GroupBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents tbVolhaPTV2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbLargeurPlantation As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents tbDebitPTMoinsPC As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbVolHa2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Button2 As Button
    Friend WithEvents TbNumeric1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label14 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents m_bsRPDiagnostic As System.Windows.Forms.BindingSource

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRPCalculVolumeHa))
        Me.GroupBox_infos = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.tbDebitPTMoinsPC = New CRODIP_ControlLibrary.TBNumeric()
        Me.m_bsRPDiagnostic = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tbVolhaPTV2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TextBox2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.infosDebitMoyPressionMesure = New CRODIP_ControlLibrary.TBNumeric()
        Me.infosPressionTravailMoinsPerteCharge = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbPressionTravail = New CRODIP_ControlLibrary.TBNumeric()
        Me.infosVitesseReelle1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.infosVitesseReelle2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.infosLargeur = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.infosNbBuses = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbVolhaPMV1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbVolHaPTV1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbNbNiveauxBuses = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.infosPressionMesure = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TbNumeric1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbLargeurPlantation = New CRODIP_ControlLibrary.TBNumeric()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.nupNbreNiveaux = New System.Windows.Forms.NumericUpDown()
        Me.nupNbreDescentes = New System.Windows.Forms.NumericUpDown()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TextBox1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox_calcAuto = New System.Windows.Forms.GroupBox()
        Me.tbVolHa2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb1PressionConnue = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb1DebitMoyConnu = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb1Vitesse = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb1Largeur = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb1VolEauHa = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb2Vitesse = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb2Pression = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb2Largeur = New CRODIP_ControlLibrary.TBNumeric()
        Me.calcDeb2Debit = New CRODIP_ControlLibrary.TBNumeric()
        Me.GroupBox_infos.SuspendLayout()
        CType(Me.m_bsRPDiagnostic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nupNbreNiveaux, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupNbreDescentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_calcAuto.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_infos
        '
        Me.GroupBox_infos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_infos.Controls.Add(Me.Button2)
        Me.GroupBox_infos.Controls.Add(Me.Label33)
        Me.GroupBox_infos.Controls.Add(Me.tbDebitPTMoinsPC)
        Me.GroupBox_infos.Controls.Add(Me.Label32)
        Me.GroupBox_infos.Controls.Add(Me.tbVolhaPTV2)
        Me.GroupBox_infos.Controls.Add(Me.TextBox2)
        Me.GroupBox_infos.Controls.Add(Me.Label31)
        Me.GroupBox_infos.Controls.Add(Me.Label4)
        Me.GroupBox_infos.Controls.Add(Me.Label5)
        Me.GroupBox_infos.Controls.Add(Me.Label1)
        Me.GroupBox_infos.Controls.Add(Me.Label6)
        Me.GroupBox_infos.Controls.Add(Me.Label7)
        Me.GroupBox_infos.Controls.Add(Me.Label8)
        Me.GroupBox_infos.Controls.Add(Me.Label9)
        Me.GroupBox_infos.Controls.Add(Me.Label10)
        Me.GroupBox_infos.Controls.Add(Me.Label11)
        Me.GroupBox_infos.Controls.Add(Me.Label12)
        Me.GroupBox_infos.Controls.Add(Me.infosDebitMoyPressionMesure)
        Me.GroupBox_infos.Controls.Add(Me.infosPressionTravailMoinsPerteCharge)
        Me.GroupBox_infos.Controls.Add(Me.tbPressionTravail)
        Me.GroupBox_infos.Controls.Add(Me.infosVitesseReelle1)
        Me.GroupBox_infos.Controls.Add(Me.infosVitesseReelle2)
        Me.GroupBox_infos.Controls.Add(Me.infosLargeur)
        Me.GroupBox_infos.Controls.Add(Me.Label13)
        Me.GroupBox_infos.Controls.Add(Me.infosNbBuses)
        Me.GroupBox_infos.Controls.Add(Me.tbVolhaPMV1)
        Me.GroupBox_infos.Controls.Add(Me.tbVolHaPTV1)
        Me.GroupBox_infos.Controls.Add(Me.tbNbNiveauxBuses)
        Me.GroupBox_infos.Controls.Add(Me.Label30)
        Me.GroupBox_infos.Controls.Add(Me.infosPressionMesure)
        Me.GroupBox_infos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_infos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GroupBox_infos.Location = New System.Drawing.Point(12, 134)
        Me.GroupBox_infos.Name = "GroupBox_infos"
        Me.GroupBox_infos.Size = New System.Drawing.Size(969, 277)
        Me.GroupBox_infos.TabIndex = 0
        Me.GroupBox_infos.TabStop = False
        Me.GroupBox_infos.Text = "Informations sur les mesures"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(809, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "ReCalcul"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(8, 127)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(304, 29)
        Me.Label33.TabIndex = 16
        Me.Label33.Text = "Débit à la pression de travail moins la perte de charge moyenne :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label33.Visible = False
        '
        'tbDebitPTMoinsPC
        '
        Me.tbDebitPTMoinsPC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcDebitPTlMoinsPC", True))
        Me.tbDebitPTMoinsPC.ForceBindingOnTextChanged = False
        Me.tbDebitPTMoinsPC.Location = New System.Drawing.Point(312, 127)
        Me.tbDebitPTMoinsPC.Name = "tbDebitPTMoinsPC"
        Me.tbDebitPTMoinsPC.ReadOnly = True
        Me.tbDebitPTMoinsPC.Size = New System.Drawing.Size(100, 20)
        Me.tbDebitPTMoinsPC.TabIndex = 17
        Me.tbDebitPTMoinsPC.Visible = False
        '
        'm_bsRPDiagnostic
        '
        Me.m_bsRPDiagnostic.DataSource = GetType(Crodip_agent.RPDiagnostic)
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.Location = New System.Drawing.Point(501, 101)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(304, 16)
        Me.Label32.TabIndex = 15
        Me.Label32.Text = "Volume/ha à la pression de travail (V2): "
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tbVolhaPTV2
        '
        Me.tbVolhaPTV2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVolhaPTV2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVolHaPTV2", True))
        Me.tbVolhaPTV2.ForceBindingOnTextChanged = False
        Me.tbVolhaPTV2.Location = New System.Drawing.Point(809, 100)
        Me.tbVolhaPTV2.Name = "tbVolhaPTV2"
        Me.tbVolhaPTV2.ReadOnly = True
        Me.tbVolhaPTV2.Size = New System.Drawing.Size(100, 20)
        Me.tbVolhaPTV2.TabIndex = 14
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVolHaPMV2", True))
        Me.TextBox2.ForceBindingOnTextChanged = False
        Me.TextBox2.Location = New System.Drawing.Point(809, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 13
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.Location = New System.Drawing.Point(501, 45)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(304, 16)
        Me.Label31.TabIndex = 12
        Me.Label31.Text = "Volume/ha à la pression de mesure (V2):"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(5, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(304, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Débit moyen à la pression de mesure :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(304, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Pression de travail :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(304, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pression de travail moins la perte de charge moyenne :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(304, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "V2 = Vitesse réelle (en km/h) : "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(304, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "V1 = Vitesse réelle (en km/h)  : "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(304, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Largeur :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(501, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(304, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Nombre de buses sur l'appareil :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Location = New System.Drawing.Point(501, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(304, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Volume/ha à la pression de travail (V1): "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(501, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(304, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Volume/ha à la pression de mesure (V1):"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(501, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(304, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Nombre de niveaux de buses :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'infosDebitMoyPressionMesure
        '
        Me.infosDebitMoyPressionMesure.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcDebitMoyenPM", True))
        Me.infosDebitMoyPressionMesure.ForceBindingOnTextChanged = False
        Me.infosDebitMoyPressionMesure.Location = New System.Drawing.Point(312, 44)
        Me.infosDebitMoyPressionMesure.Name = "infosDebitMoyPressionMesure"
        Me.infosDebitMoyPressionMesure.ReadOnly = True
        Me.infosDebitMoyPressionMesure.Size = New System.Drawing.Size(100, 20)
        Me.infosDebitMoyPressionMesure.TabIndex = 1
        '
        'infosPressionTravailMoinsPerteCharge
        '
        Me.infosPressionTravailMoinsPerteCharge.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcPressionTravailMoinsPC", True))
        Me.infosPressionTravailMoinsPerteCharge.ForceBindingOnTextChanged = False
        Me.infosPressionTravailMoinsPerteCharge.Location = New System.Drawing.Point(312, 104)
        Me.infosPressionTravailMoinsPerteCharge.Name = "infosPressionTravailMoinsPerteCharge"
        Me.infosPressionTravailMoinsPerteCharge.Size = New System.Drawing.Size(100, 20)
        Me.infosPressionTravailMoinsPerteCharge.TabIndex = 3
        '
        'tbPressionTravail
        '
        Me.tbPressionTravail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcPressionTravail", True))
        Me.tbPressionTravail.ForceBindingOnTextChanged = False
        Me.tbPressionTravail.Location = New System.Drawing.Point(312, 80)
        Me.tbPressionTravail.Name = "tbPressionTravail"
        Me.tbPressionTravail.Size = New System.Drawing.Size(100, 20)
        Me.tbPressionTravail.TabIndex = 2
        '
        'infosVitesseReelle1
        '
        Me.infosVitesseReelle1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVitesseReelle1", True))
        Me.infosVitesseReelle1.ForceBindingOnTextChanged = False
        Me.infosVitesseReelle1.Location = New System.Drawing.Point(312, 156)
        Me.infosVitesseReelle1.Name = "infosVitesseReelle1"
        Me.infosVitesseReelle1.ReadOnly = True
        Me.infosVitesseReelle1.Size = New System.Drawing.Size(100, 20)
        Me.infosVitesseReelle1.TabIndex = 4
        '
        'infosVitesseReelle2
        '
        Me.infosVitesseReelle2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVitesseReelle2", True))
        Me.infosVitesseReelle2.ForceBindingOnTextChanged = False
        Me.infosVitesseReelle2.Location = New System.Drawing.Point(312, 180)
        Me.infosVitesseReelle2.Name = "infosVitesseReelle2"
        Me.infosVitesseReelle2.ReadOnly = True
        Me.infosVitesseReelle2.Size = New System.Drawing.Size(100, 20)
        Me.infosVitesseReelle2.TabIndex = 5
        '
        'infosLargeur
        '
        Me.infosLargeur.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcLargeurApp", True))
        Me.infosLargeur.ForceBindingOnTextChanged = False
        Me.infosLargeur.Location = New System.Drawing.Point(312, 212)
        Me.infosLargeur.Name = "infosLargeur"
        Me.infosLargeur.Size = New System.Drawing.Size(100, 20)
        Me.infosLargeur.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 228)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(424, 38)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "la largeur correspond correspond à la largeur de pulvérisation (pulvérisateur à r" &
    "ampe ou arbo-viti)"
        '
        'infosNbBuses
        '
        Me.infosNbBuses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infosNbBuses.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcNombreBuses", True))
        Me.infosNbBuses.ForceBindingOnTextChanged = False
        Me.infosNbBuses.Location = New System.Drawing.Point(809, 136)
        Me.infosNbBuses.Name = "infosNbBuses"
        Me.infosNbBuses.ReadOnly = True
        Me.infosNbBuses.Size = New System.Drawing.Size(100, 20)
        Me.infosNbBuses.TabIndex = 7
        '
        'tbVolhaPMV1
        '
        Me.tbVolhaPMV1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVolhaPMV1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVolHaPMV1", True))
        Me.tbVolhaPMV1.ForceBindingOnTextChanged = False
        Me.tbVolhaPMV1.Location = New System.Drawing.Point(809, 19)
        Me.tbVolhaPMV1.Name = "tbVolhaPMV1"
        Me.tbVolhaPMV1.ReadOnly = True
        Me.tbVolhaPMV1.Size = New System.Drawing.Size(100, 20)
        Me.tbVolhaPMV1.TabIndex = 8
        '
        'tbVolHaPTV1
        '
        Me.tbVolHaPTV1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVolHaPTV1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVolHaPTV1", True))
        Me.tbVolHaPTV1.ForceBindingOnTextChanged = False
        Me.tbVolHaPTV1.Location = New System.Drawing.Point(809, 74)
        Me.tbVolHaPTV1.Name = "tbVolHaPTV1"
        Me.tbVolHaPTV1.ReadOnly = True
        Me.tbVolHaPTV1.Size = New System.Drawing.Size(100, 20)
        Me.tbVolHaPTV1.TabIndex = 9
        '
        'tbNbNiveauxBuses
        '
        Me.tbNbNiveauxBuses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNbNiveauxBuses.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcNombreNiveauxBuses", True))
        Me.tbNbNiveauxBuses.ForceBindingOnTextChanged = False
        Me.tbNbNiveauxBuses.Location = New System.Drawing.Point(809, 156)
        Me.tbNbNiveauxBuses.Name = "tbNbNiveauxBuses"
        Me.tbNbNiveauxBuses.ReadOnly = True
        Me.tbNbNiveauxBuses.Size = New System.Drawing.Size(100, 20)
        Me.tbNbNiveauxBuses.TabIndex = 10
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(8, 21)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(304, 16)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Pression de mesure :"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'infosPressionMesure
        '
        Me.infosPressionMesure.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcPressionDeMesure", True))
        Me.infosPressionMesure.ForceBindingOnTextChanged = False
        Me.infosPressionMesure.Location = New System.Drawing.Point(312, 19)
        Me.infosPressionMesure.Name = "infosPressionMesure"
        Me.infosPressionMesure.ReadOnly = True
        Me.infosPressionMesure.Size = New System.Drawing.Size(100, 20)
        Me.infosPressionMesure.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(4, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "     Calcul du volume / Ha"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TbNumeric1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.tbLargeurPlantation)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.nupNbreNiveaux)
        Me.GroupBox1.Controls.Add(Me.nupNbreDescentes)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(972, 92)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'TbNumeric1
        '
        Me.TbNumeric1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcRegimeMoteur", True))
        Me.TbNumeric1.ForceBindingOnTextChanged = False
        Me.TbNumeric1.Location = New System.Drawing.Point(380, 20)
        Me.TbNumeric1.Name = "TbNumeric1"
        Me.TbNumeric1.Size = New System.Drawing.Size(75, 20)
        Me.TbNumeric1.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(235, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(139, 20)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Régime moteur :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(802, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 30)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Détails"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbLargeurPlantation
        '
        Me.tbLargeurPlantation.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcLargeurPlantation", True))
        Me.tbLargeurPlantation.ForceBindingOnTextChanged = False
        Me.tbLargeurPlantation.Location = New System.Drawing.Point(166, 20)
        Me.tbLargeurPlantation.Name = "tbLargeurPlantation"
        Me.tbLargeurPlantation.ReadOnly = True
        Me.tbLargeurPlantation.Size = New System.Drawing.Size(35, 20)
        Me.tbLargeurPlantation.TabIndex = 13
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsRPDiagnostic, "CalcEmplacementPriseAir", True))
        Me.CheckBox1.Location = New System.Drawing.Point(11, 56)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(168, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Emplacement prise d'air :"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'nupNbreNiveaux
        '
        Me.nupNbreNiveaux.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nupNbreNiveaux.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.m_bsRPDiagnostic, "CalcNbreNiveauParDescente", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.nupNbreNiveaux.Location = New System.Drawing.Point(685, 55)
        Me.nupNbreNiveaux.Name = "nupNbreNiveaux"
        Me.nupNbreNiveaux.Size = New System.Drawing.Size(43, 20)
        Me.nupNbreNiveaux.TabIndex = 9
        '
        'nupNbreDescentes
        '
        Me.nupNbreDescentes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nupNbreDescentes.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.m_bsRPDiagnostic, "CalcNbreDescentes", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.nupNbreDescentes.Location = New System.Drawing.Point(685, 20)
        Me.nupNbreDescentes.Name = "nupNbreDescentes"
        Me.nupNbreDescentes.Size = New System.Drawing.Size(43, 20)
        Me.nupNbreDescentes.TabIndex = 8
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.Location = New System.Drawing.Point(471, 54)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(208, 22)
        Me.Label38.TabIndex = 6
        Me.Label38.Text = "Nbre de niveaux par descente :"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Location = New System.Drawing.Point(540, 20)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(139, 17)
        Me.Label37.TabIndex = 5
        Me.Label37.Text = "Nbre de descentes :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVitesseRotation", True))
        Me.TextBox1.ForceBindingOnTextChanged = False
        Me.TextBox1.Location = New System.Drawing.Point(380, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(75, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(235, 44)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(139, 32)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Vitesse de rotation de la prise de force :"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(8, 20)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(140, 17)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "Largeur de plantation  :"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label29
        '
        Me.Label29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.Location = New System.Drawing.Point(496, 216)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(305, 16)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Largeur :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 240)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(424, 24)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "     p1 : attention il s'agit ici de caculer le volume à la pression de contrôle " &
    "(pression lors de la mesure) et non à la pression de travail (au manomètre du pu" &
    "lvéristeur)"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(8, 173)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(304, 16)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Nouvelle pression (p2) :"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label26.Image = CType(resources.GetObject("Label26.Image"), System.Drawing.Image)
        Me.Label26.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label26.Location = New System.Drawing.Point(16, 144)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(360, 16)
        Me.Label26.TabIndex = 11
        Me.Label26.Text = "       Recherche d'un nouveau débit "
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.Location = New System.Drawing.Point(496, 248)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(305, 16)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Volume /ha :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 264)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(424, 24)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "     * : l'écartement correspond à la largeur de pulvérisation (pulvérisateur à r" &
    "ampe ou arbo-viti)"
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.Location = New System.Drawing.Point(496, 192)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(305, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Vitesse :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 197)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(304, 16)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Débit correspondant (d2) :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 120)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(424, 24)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "     * : l'écartement correspond à la largeur de pulvérisation (pulvérisateur à r" &
    "ampe ou arbo-viti)"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 96)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(424, 24)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "     p1 : attention il s'agit ici de caculer le volume à la pression de contrôle " &
    "(pression lors de la mesure) et non à la pression de travail (au manomètre du pu" &
    "lvéristeur)"
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Location = New System.Drawing.Point(496, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(305, 16)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Volume /ha :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.Location = New System.Drawing.Point(496, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(305, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Vitesse :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Location = New System.Drawing.Point(496, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(305, 16)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Largeur :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(304, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Débit correspondant (d1) :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(304, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nouvelle  pression (p1) :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label16.Location = New System.Drawing.Point(16, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(319, 16)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "       Calcul du débit "
        '
        'GroupBox_calcAuto
        '
        Me.GroupBox_calcAuto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_calcAuto.Controls.Add(Me.tbVolHa2)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label16)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1PressionConnue)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label3)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1DebitMoyConnu)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label15)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1Vitesse)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1Largeur)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label17)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label18)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1VolEauHa)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label19)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label20)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label21)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2Vitesse)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2Pression)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2Largeur)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2Debit)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label22)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label23)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label24)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label25)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label26)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label27)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label28)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label29)
        Me.GroupBox_calcAuto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_calcAuto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GroupBox_calcAuto.Location = New System.Drawing.Point(12, 409)
        Me.GroupBox_calcAuto.Name = "GroupBox_calcAuto"
        Me.GroupBox_calcAuto.Size = New System.Drawing.Size(969, 292)
        Me.GroupBox_calcAuto.TabIndex = 0
        Me.GroupBox_calcAuto.TabStop = False
        Me.GroupBox_calcAuto.Text = "Calculs automatiques"
        '
        'tbVolHa2
        '
        Me.tbVolHa2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVolHa2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVolEauHa2", True))
        Me.tbVolHa2.ForceBindingOnTextChanged = False
        Me.tbVolHa2.Location = New System.Drawing.Point(809, 248)
        Me.tbVolHa2.Name = "tbVolHa2"
        Me.tbVolHa2.ReadOnly = True
        Me.tbVolHa2.Size = New System.Drawing.Size(101, 20)
        Me.tbVolHa2.TabIndex = 12
        '
        'calcDeb1PressionConnue
        '
        Me.calcDeb1PressionConnue.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcPression1", True))
        Me.calcDeb1PressionConnue.ForceBindingOnTextChanged = False
        Me.calcDeb1PressionConnue.Location = New System.Drawing.Point(312, 48)
        Me.calcDeb1PressionConnue.Name = "calcDeb1PressionConnue"
        Me.calcDeb1PressionConnue.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb1PressionConnue.TabIndex = 0
        '
        'calcDeb1DebitMoyConnu
        '
        Me.calcDeb1DebitMoyConnu.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcDebit1", True))
        Me.calcDeb1DebitMoyConnu.ForceBindingOnTextChanged = False
        Me.calcDeb1DebitMoyConnu.Location = New System.Drawing.Point(312, 72)
        Me.calcDeb1DebitMoyConnu.Name = "calcDeb1DebitMoyConnu"
        Me.calcDeb1DebitMoyConnu.ReadOnly = True
        Me.calcDeb1DebitMoyConnu.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb1DebitMoyConnu.TabIndex = 1
        Me.calcDeb1DebitMoyConnu.TabStop = False
        '
        'calcDeb1Vitesse
        '
        Me.calcDeb1Vitesse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb1Vitesse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVitesse1", True))
        Me.calcDeb1Vitesse.ForceBindingOnTextChanged = False
        Me.calcDeb1Vitesse.Location = New System.Drawing.Point(808, 48)
        Me.calcDeb1Vitesse.Name = "calcDeb1Vitesse"
        Me.calcDeb1Vitesse.Size = New System.Drawing.Size(101, 20)
        Me.calcDeb1Vitesse.TabIndex = 2
        '
        'calcDeb1Largeur
        '
        Me.calcDeb1Largeur.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb1Largeur.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcLargeur1", True))
        Me.calcDeb1Largeur.ForceBindingOnTextChanged = False
        Me.calcDeb1Largeur.Location = New System.Drawing.Point(808, 72)
        Me.calcDeb1Largeur.Name = "calcDeb1Largeur"
        Me.calcDeb1Largeur.Size = New System.Drawing.Size(101, 20)
        Me.calcDeb1Largeur.TabIndex = 3
        '
        'calcDeb1VolEauHa
        '
        Me.calcDeb1VolEauHa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb1VolEauHa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVolEauHa1", True))
        Me.calcDeb1VolEauHa.ForceBindingOnTextChanged = False
        Me.calcDeb1VolEauHa.Location = New System.Drawing.Point(808, 104)
        Me.calcDeb1VolEauHa.Name = "calcDeb1VolEauHa"
        Me.calcDeb1VolEauHa.ReadOnly = True
        Me.calcDeb1VolEauHa.Size = New System.Drawing.Size(101, 20)
        Me.calcDeb1VolEauHa.TabIndex = 4
        '
        'calcDeb2Vitesse
        '
        Me.calcDeb2Vitesse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb2Vitesse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcVitesse2", True))
        Me.calcDeb2Vitesse.ForceBindingOnTextChanged = False
        Me.calcDeb2Vitesse.Location = New System.Drawing.Point(808, 192)
        Me.calcDeb2Vitesse.Name = "calcDeb2Vitesse"
        Me.calcDeb2Vitesse.Size = New System.Drawing.Size(101, 20)
        Me.calcDeb2Vitesse.TabIndex = 5
        '
        'calcDeb2Pression
        '
        Me.calcDeb2Pression.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcPression2", True))
        Me.calcDeb2Pression.ForceBindingOnTextChanged = False
        Me.calcDeb2Pression.Location = New System.Drawing.Point(312, 169)
        Me.calcDeb2Pression.Name = "calcDeb2Pression"
        Me.calcDeb2Pression.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb2Pression.TabIndex = 4
        '
        'calcDeb2Largeur
        '
        Me.calcDeb2Largeur.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb2Largeur.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcLargeur2", True))
        Me.calcDeb2Largeur.ForceBindingOnTextChanged = False
        Me.calcDeb2Largeur.Location = New System.Drawing.Point(808, 216)
        Me.calcDeb2Largeur.Name = "calcDeb2Largeur"
        Me.calcDeb2Largeur.Size = New System.Drawing.Size(101, 20)
        Me.calcDeb2Largeur.TabIndex = 6
        '
        'calcDeb2Debit
        '
        Me.calcDeb2Debit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "CalcDebit2", True))
        Me.calcDeb2Debit.ForceBindingOnTextChanged = False
        Me.calcDeb2Debit.Location = New System.Drawing.Point(312, 196)
        Me.calcDeb2Debit.Name = "calcDeb2Debit"
        Me.calcDeb2Debit.ReadOnly = True
        Me.calcDeb2Debit.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb2Debit.TabIndex = 1
        Me.calcDeb2Debit.TabStop = False
        '
        'frmRPCalculVolumeHa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1009, 713)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox_calcAuto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox_infos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmRPCalculVolumeHa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcul volume/ha"
        Me.GroupBox_infos.ResumeLayout(False)
        Me.GroupBox_infos.PerformLayout()
        CType(Me.m_bsRPDiagnostic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nupNbreNiveaux, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupNbreDescentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_calcAuto.ResumeLayout(False)
        Me.GroupBox_calcAuto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " - Chargement - "

    Private Sub frmRPCalculVolumeHa_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        initCalculs()
        m_bsRPDiagnostic.ResetBindings(False)
    End Sub
    Private Sub tool_calcVolHa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        formload()
    End Sub
#End Region


#Region " - Tests - "

    Private Function isFilled_calcDeb1() As Boolean
        If infosNbBuses.Text <> "" And infosDebitMoyPressionMesure.Text <> "" And infosLargeur.Text <> "" And infosVitesseReelle1.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function isFilled_calcDeb2() As Boolean
        If infosNbBuses.Text <> "" And calcDeb2Debit.Text <> "" And infosLargeur.Text <> "" And infosVitesseReelle1.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function isFilled_calc_Deb2Debit() As Boolean
        If calcDeb1PressionConnue.Text <> "" And calcDeb1DebitMoyConnu.Text <> "" And calcDeb2Pression.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

#Region " - Calculs - "


    Private Sub Calculs()
        m_oDiag.CalcVolumeHa()
        m_bsRPDiagnostic.ResetBindings(False)
    End Sub

#End Region

#Region " - MAJ Champs - "

    Private Sub infosPressionMesure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        calcDeb1PressionConnue.Text = sender.text
    End Sub

    Private Sub infosDebitMoyPressionMesure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '       calcDeb1DebitMoyConnu.Text = sender.text
    End Sub

    Private Sub infosVitesseReelle1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '      If sender.name <> "infosVitesseReelle1" Then
        ' infosVitesseReelle1.Text = sender.text
        ' End If
        ' If sender.name <> "calcDeb1Vitesse" Then
        ' calcDeb1Vitesse.Text = sender.text
        ' End If
        'If sender.name <> "calcDeb2Vitesse" Then
        ' calcDeb2Vitesse.Text = sender.text
        'End If
    End Sub

    Private Sub infosLargeur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sender.name <> "infosLargeur" Then
        ' infosLargeur.Text = sender.text
        ' End If
        'If sender.name <> "calcDeb1Largeur" Then
        'calcDeb1Largeur.Text = sender.text
        'End If
        'If sender.name <> "calcDeb2Largeur" Then
        'calcDeb2Largeur.Text = sender.text
        'End If
    End Sub

    Private Sub infosPressionTravailMoinsPerteCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'calcDeb2Pression.Text = sender.text
    End Sub

#End Region


    Public Overridable Sub setContexte(pDiag As RPDiagnostic)
        m_oDiag = pDiag
        m_bsRPDiagnostic.Clear()
        m_bsRPDiagnostic.Add(m_oDiag)
    End Sub
    Protected Overridable Sub formload() Implements IfrmCRODIP.formLoad
        MinimizeBox = False
        MaximizeBox = False

    End Sub
    Private Sub initCalculs()
        If Not String.IsNullOrEmpty(m_oDiag.pulverisateurLargeurPlantation) Then
            m_oDiag.CalcLargeurPlantation = GlobalsCRODIP.StringToDouble(m_oDiag.pulverisateurLargeurPlantation)
        End If
        If Not String.IsNullOrEmpty(m_oDiag.manometrePressionTravail) Then
            m_oDiag.CalcPressionDeMesure = GlobalsCRODIP.StringToDouble(m_oDiag.manometrePressionTravail)
        End If
        If Not String.IsNullOrEmpty(m_oDiag.buseDebit) Then
            m_oDiag.CalcDebitMoyenPM = GlobalsCRODIP.StringToDouble(m_oDiag.buseDebitMoyenPM)
        End If
        If Not String.IsNullOrEmpty(m_oDiag.diagnosticHelp551.VitesseReelle1) Then
            m_oDiag.CalcVitesseReelle1 = GlobalsCRODIP.StringToDouble(m_oDiag.diagnosticHelp551.VitesseReelle1)
        End If
        If Not String.IsNullOrEmpty(m_oDiag.diagnosticHelp551.VitesseReelle2) Then
            m_oDiag.CalcVitesseReelle2 = GlobalsCRODIP.StringToDouble(m_oDiag.diagnosticHelp551.VitesseReelle2)
        End If
        If Not String.IsNullOrEmpty(m_oDiag.pulverisateurLargeur) Then
            m_oDiag.CalcLargeurApp = GlobalsCRODIP.StringToDouble(m_oDiag.pulverisateurLargeur)
        End If
        m_oDiag.CalcNombreBuses = 0
        m_oDiag.CalclstBuseUsees = ""
        For Each oDiagBuse As DiagnosticBuses In m_oDiag.diagnosticBusesList.Liste
            m_oDiag.CalcNombreBuses = m_oDiag.CalcNombreBuses + oDiagBuse.nombre
            For Each oDiagBusedetail As DiagnosticBusesDetail In oDiagBuse.diagnosticBusesDetailList.Liste
                If oDiagBusedetail.usee Then
                    If Not String.IsNullOrEmpty(m_oDiag.CalclstBuseUsees) Then
                        m_oDiag.CalclstBuseUsees = m_oDiag.CalclstBuseUsees & ";"
                    End If
                    m_oDiag.CalclstBuseUsees = m_oDiag.CalclstBuseUsees & oDiagBusedetail.idLot & "/" & oDiagBusedetail.idBuse
                End If
            Next
        Next
        m_oDiag.CalcNombreNiveauxBuses = m_oDiag.diagnosticBusesList.Liste.Count
        If String.IsNullOrEmpty(m_oDiag.CalcPression1) Then
            m_oDiag.CalcPression1 = GlobalsCRODIP.StringToDouble(m_oDiag.CalcPressionDeMesure)
        End If
        If String.IsNullOrEmpty(m_oDiag.CalcPression2) Then
            m_oDiag.CalcPression2 = GlobalsCRODIP.StringToDouble(m_oDiag.CalcPressionDeMesure)
        End If
        If String.IsNullOrEmpty(m_oDiag.CalcLargeur1) Then
            m_oDiag.CalcLargeur1 = GlobalsCRODIP.StringToDouble(m_oDiag.pulverisateurLargeur)
        End If
        If String.IsNullOrEmpty(m_oDiag.CalcLargeur2) Then
            m_oDiag.CalcLargeur2 = GlobalsCRODIP.StringToDouble(m_oDiag.pulverisateurLargeur)
        End If

    End Sub
    Protected Overridable Function Valider() As Boolean Implements IfrmCRODIP.Valider
        Dim bReturn As Boolean
        Try
            m_oDiag.oRPParam.bSectionCalculs = True
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("RPCalculVolumeHa.Valider Err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Protected Overridable Sub Annuler() Implements IfrmCRODIP.Annuler

    End Sub


    Private Sub infosPressionTravailMoinsPerteCharge_Validated(sender As Object, e As EventArgs) Handles infosPressionTravailMoinsPerteCharge.Validated
        Calculs()
    End Sub

    Private Sub infosLargeur_Validated(sender As Object, e As EventArgs) Handles infosLargeur.Validated
        Calculs()
    End Sub

    Private Sub tbPressionTravail_Validated(sender As Object, e As EventArgs) Handles tbPressionTravail.Validated
        Calculs()
    End Sub

    Private Sub calcDeb1PressionConnue_Validated(sender As Object, e As EventArgs) Handles calcDeb1PressionConnue.Validated
        Calculs()
    End Sub

    Private Sub calcDeb1DebitMoyConnu_Validated(sender As Object, e As EventArgs) Handles calcDeb1DebitMoyConnu.Validated
        Calculs()
    End Sub

    Private Sub calcDeb1Vitesse_Validated(sender As Object, e As EventArgs) Handles calcDeb1Vitesse.Validated
        Calculs()
    End Sub

    Private Sub calcDeb1Largeur_Validated(sender As Object, e As EventArgs) Handles calcDeb1Largeur.Validated
        Calculs()
    End Sub

    Private Sub calcDeb2Pression_Validated(sender As Object, e As EventArgs) Handles calcDeb2Pression.Validated
        Calculs()
    End Sub


    Private Sub calcDeb2Debit_Validated(sender As Object, e As EventArgs) Handles calcDeb2Debit.Validated
        Calculs()
    End Sub

    Private Sub calcDeb2Vitesse_Validated(sender As Object, e As EventArgs) Handles calcDeb2Vitesse.Validated
        Calculs()
    End Sub

    Private Sub calcDeb2Largeur_Validated(sender As Object, e As EventArgs) Handles calcDeb2Largeur.Validated
        Calculs()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim oFrm As frmRPInfosBuses
        oFrm = New frmRPInfosBuses()
        oFrm.setContexte(m_oDiag)
        oFrm.StartPosition = FormStartPosition.CenterParent
        oFrm.ShowDialog(Me)



    End Sub
End Class
