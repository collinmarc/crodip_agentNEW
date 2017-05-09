Public Class RPCalculVolumeHa
    Inherits System.Windows.Forms.Form
    Implements IfrmCRODIP

    Private m_oDiag As RPDiagnostic

#Region " Code généré par le Concepteur Windows Form "
    Friend WithEvents GroupBox_infos As System.Windows.Forms.GroupBox
    Friend WithEvents infosListBusesUsees As System.Windows.Forms.ListBox
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
    Friend WithEvents infosDebitMoyPressionMesure As System.Windows.Forms.TextBox
    Friend WithEvents infosPressionTravailMoinsPerteCharge As System.Windows.Forms.TextBox
    Friend WithEvents infosPressionTravail As System.Windows.Forms.TextBox
    Friend WithEvents infosVitesseReelle1 As System.Windows.Forms.TextBox
    Friend WithEvents infosVitesseReelle2 As System.Windows.Forms.TextBox
    Friend WithEvents infosLargeur As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents infosNbBuses As System.Windows.Forms.TextBox
    Friend WithEvents infosVolHaPressionMesure As System.Windows.Forms.TextBox
    Friend WithEvents infosVolHaPressionTravail As System.Windows.Forms.TextBox
    Friend WithEvents infosNbNiveauxBuses As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents infosPressionMesure As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cbxLargeurPlantation As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents nupNbreNiveaux As System.Windows.Forms.NumericUpDown
    Friend WithEvents nupNbreBuses As System.Windows.Forms.NumericUpDown
    Friend WithEvents nupNbreDescentes As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label39 As System.Windows.Forms.Label
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents calcDeb1PressionConnue As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb1DebitMoyConnu As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb1Vitesse As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb1Ecartement As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb1VolEauHa As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb2Vitesse As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb2Pression As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb2Ecartement As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb2Debit As System.Windows.Forms.TextBox
    Friend WithEvents calcDeb2VolEauHa As System.Windows.Forms.TextBox
    Friend WithEvents calcVitesseTemps As System.Windows.Forms.TextBox
    Friend WithEvents calcVitesseDistance As System.Windows.Forms.TextBox
    Friend WithEvents calcVitesseVitesse As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_calcAuto As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RPCalculVolumeHa))
        Me.GroupBox_calcAuto = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.calcDeb1PressionConnue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.calcDeb1DebitMoyConnu = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.calcDeb1Vitesse = New System.Windows.Forms.TextBox()
        Me.calcDeb1Ecartement = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.calcDeb1VolEauHa = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.calcDeb2Vitesse = New System.Windows.Forms.TextBox()
        Me.calcDeb2Pression = New System.Windows.Forms.TextBox()
        Me.calcDeb2Ecartement = New System.Windows.Forms.TextBox()
        Me.calcDeb2Debit = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.calcDeb2VolEauHa = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.calcVitesseTemps = New System.Windows.Forms.TextBox()
        Me.calcVitesseDistance = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.calcVitesseVitesse = New System.Windows.Forms.TextBox()
        Me.GroupBox_infos = New System.Windows.Forms.GroupBox()
        Me.infosListBusesUsees = New System.Windows.Forms.ListBox()
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
        Me.infosDebitMoyPressionMesure = New System.Windows.Forms.TextBox()
        Me.infosPressionTravailMoinsPerteCharge = New System.Windows.Forms.TextBox()
        Me.infosPressionTravail = New System.Windows.Forms.TextBox()
        Me.infosVitesseReelle1 = New System.Windows.Forms.TextBox()
        Me.infosVitesseReelle2 = New System.Windows.Forms.TextBox()
        Me.infosLargeur = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.infosNbBuses = New System.Windows.Forms.TextBox()
        Me.infosVolHaPressionMesure = New System.Windows.Forms.TextBox()
        Me.infosVolHaPressionTravail = New System.Windows.Forms.TextBox()
        Me.infosNbNiveauxBuses = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.infosPressionMesure = New System.Windows.Forms.TextBox()
        Me.m_bsRPDiagnostic = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nupNbreNiveaux = New System.Windows.Forms.NumericUpDown()
        Me.nupNbreBuses = New System.Windows.Forms.NumericUpDown()
        Me.nupNbreDescentes = New System.Windows.Forms.NumericUpDown()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cbxLargeurPlantation = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox_calcAuto.SuspendLayout()
        Me.GroupBox_infos.SuspendLayout()
        CType(Me.m_bsRPDiagnostic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nupNbreNiveaux, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupNbreBuses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupNbreDescentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_calcAuto
        '
        Me.GroupBox_calcAuto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label16)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1PressionConnue)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label3)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1DebitMoyConnu)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label15)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1Vitesse)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1Ecartement)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label17)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label18)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb1VolEauHa)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label19)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label20)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label21)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2Vitesse)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2Pression)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2Ecartement)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2Debit)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label22)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label23)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label24)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label25)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcDeb2VolEauHa)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label26)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label27)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label28)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label29)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label31)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label32)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label33)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcVitesseTemps)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcVitesseDistance)
        Me.GroupBox_calcAuto.Controls.Add(Me.Label34)
        Me.GroupBox_calcAuto.Controls.Add(Me.calcVitesseVitesse)
        Me.GroupBox_calcAuto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_calcAuto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GroupBox_calcAuto.Location = New System.Drawing.Point(12, 389)
        Me.GroupBox_calcAuto.Name = "GroupBox_calcAuto"
        Me.GroupBox_calcAuto.Size = New System.Drawing.Size(968, 381)
        Me.GroupBox_calcAuto.TabIndex = 1
        Me.GroupBox_calcAuto.TabStop = False
        Me.GroupBox_calcAuto.Text = "Calculs automatiques"
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
        Me.Label16.Size = New System.Drawing.Size(264, 16)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "       Calcul du débit (à la pression de mesure)"
        '
        'calcDeb1PressionConnue
        '
        Me.calcDeb1PressionConnue.Location = New System.Drawing.Point(312, 48)
        Me.calcDeb1PressionConnue.Name = "calcDeb1PressionConnue"
        Me.calcDeb1PressionConnue.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb1PressionConnue.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(304, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Pression connue (p1) :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'calcDeb1DebitMoyConnu
        '
        Me.calcDeb1DebitMoyConnu.Location = New System.Drawing.Point(312, 72)
        Me.calcDeb1DebitMoyConnu.Name = "calcDeb1DebitMoyConnu"
        Me.calcDeb1DebitMoyConnu.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb1DebitMoyConnu.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(304, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Débit moyen connu (d1) :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'calcDeb1Vitesse
        '
        Me.calcDeb1Vitesse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb1Vitesse.Location = New System.Drawing.Point(808, 48)
        Me.calcDeb1Vitesse.Name = "calcDeb1Vitesse"
        Me.calcDeb1Vitesse.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb1Vitesse.TabIndex = 2
        '
        'calcDeb1Ecartement
        '
        Me.calcDeb1Ecartement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb1Ecartement.Location = New System.Drawing.Point(808, 72)
        Me.calcDeb1Ecartement.Name = "calcDeb1Ecartement"
        Me.calcDeb1Ecartement.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb1Ecartement.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Location = New System.Drawing.Point(496, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(304, 16)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Ecartement * :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.Location = New System.Drawing.Point(496, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(304, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Vitesse :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'calcDeb1VolEauHa
        '
        Me.calcDeb1VolEauHa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb1VolEauHa.Location = New System.Drawing.Point(808, 104)
        Me.calcDeb1VolEauHa.Name = "calcDeb1VolEauHa"
        Me.calcDeb1VolEauHa.ReadOnly = True
        Me.calcDeb1VolEauHa.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb1VolEauHa.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Location = New System.Drawing.Point(496, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(304, 16)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Volume eau/ha :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 96)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(424, 24)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "     p1 : attention il s'agit ici de caculer le volume à la pression de contrôle " & _
    "(pression lors de la mesure) et non à la pression de travail (au manomètre du pu" & _
    "lvéristeur)"
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 120)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(424, 24)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "     * : l'écartement correspond à la distance entre 2 buses (puvérisateur à ramp" & _
    "e) ou à la largeur de pulvérisation (pulvérisateur à rampe ou arbo-viti)"
        '
        'calcDeb2Vitesse
        '
        Me.calcDeb2Vitesse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb2Vitesse.Location = New System.Drawing.Point(808, 192)
        Me.calcDeb2Vitesse.Name = "calcDeb2Vitesse"
        Me.calcDeb2Vitesse.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb2Vitesse.TabIndex = 5
        '
        'calcDeb2Pression
        '
        Me.calcDeb2Pression.Location = New System.Drawing.Point(312, 169)
        Me.calcDeb2Pression.Name = "calcDeb2Pression"
        Me.calcDeb2Pression.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb2Pression.TabIndex = 4
        '
        'calcDeb2Ecartement
        '
        Me.calcDeb2Ecartement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb2Ecartement.Location = New System.Drawing.Point(808, 216)
        Me.calcDeb2Ecartement.Name = "calcDeb2Ecartement"
        Me.calcDeb2Ecartement.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb2Ecartement.TabIndex = 6
        '
        'calcDeb2Debit
        '
        Me.calcDeb2Debit.Location = New System.Drawing.Point(312, 196)
        Me.calcDeb2Debit.Name = "calcDeb2Debit"
        Me.calcDeb2Debit.ReadOnly = True
        Me.calcDeb2Debit.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb2Debit.TabIndex = 1
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
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.Location = New System.Drawing.Point(496, 192)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(304, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Vitesse :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 264)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(424, 24)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "     * : l'écartement correspond à la distance entre 2 buses (puvérisateur à ramp" & _
    "e) ou à la largeur de pulvérisation (pulvérisateur à rampe ou arbo-viti)"
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.Location = New System.Drawing.Point(496, 248)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(304, 16)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Volume eau/ha :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'calcDeb2VolEauHa
        '
        Me.calcDeb2VolEauHa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcDeb2VolEauHa.Location = New System.Drawing.Point(808, 248)
        Me.calcDeb2VolEauHa.Name = "calcDeb2VolEauHa"
        Me.calcDeb2VolEauHa.ReadOnly = True
        Me.calcDeb2VolEauHa.Size = New System.Drawing.Size(100, 20)
        Me.calcDeb2VolEauHa.TabIndex = 1
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
        Me.Label26.Text = "       Recherche d'un nouveau débit (à partir des données 1 )"
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
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 240)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(424, 24)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "     p1 : attention il s'agit ici de caculer le volume à la pression de contrôle " & _
    "(pression lors de la mesure) et non à la pression de travail (au manomètre du pu" & _
    "lvéristeur)"
        '
        'Label29
        '
        Me.Label29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.Location = New System.Drawing.Point(496, 216)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(304, 16)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Ecartement * :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(8, 317)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(304, 16)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "Distance parcourue avec l'appareil  :"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label32.Image = CType(resources.GetObject("Label32.Image"), System.Drawing.Image)
        Me.Label32.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label32.Location = New System.Drawing.Point(16, 288)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(360, 16)
        Me.Label32.TabIndex = 11
        Me.Label32.Text = "       Calcul de la vitesse"
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(8, 340)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(304, 16)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Temps passé pour effectuer la distance :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'calcVitesseTemps
        '
        Me.calcVitesseTemps.Location = New System.Drawing.Point(312, 339)
        Me.calcVitesseTemps.Name = "calcVitesseTemps"
        Me.calcVitesseTemps.Size = New System.Drawing.Size(100, 20)
        Me.calcVitesseTemps.TabIndex = 8
        '
        'calcVitesseDistance
        '
        Me.calcVitesseDistance.Location = New System.Drawing.Point(312, 316)
        Me.calcVitesseDistance.Name = "calcVitesseDistance"
        Me.calcVitesseDistance.Size = New System.Drawing.Size(100, 20)
        Me.calcVitesseDistance.TabIndex = 7
        '
        'Label34
        '
        Me.Label34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.Location = New System.Drawing.Point(496, 336)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(304, 16)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "Vitesse :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'calcVitesseVitesse
        '
        Me.calcVitesseVitesse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcVitesseVitesse.Location = New System.Drawing.Point(808, 336)
        Me.calcVitesseVitesse.Name = "calcVitesseVitesse"
        Me.calcVitesseVitesse.ReadOnly = True
        Me.calcVitesseVitesse.Size = New System.Drawing.Size(100, 20)
        Me.calcVitesseVitesse.TabIndex = 1
        '
        'GroupBox_infos
        '
        Me.GroupBox_infos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_infos.Controls.Add(Me.infosListBusesUsees)
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
        Me.GroupBox_infos.Controls.Add(Me.infosPressionTravail)
        Me.GroupBox_infos.Controls.Add(Me.infosVitesseReelle1)
        Me.GroupBox_infos.Controls.Add(Me.infosVitesseReelle2)
        Me.GroupBox_infos.Controls.Add(Me.infosLargeur)
        Me.GroupBox_infos.Controls.Add(Me.Label13)
        Me.GroupBox_infos.Controls.Add(Me.infosNbBuses)
        Me.GroupBox_infos.Controls.Add(Me.infosVolHaPressionMesure)
        Me.GroupBox_infos.Controls.Add(Me.infosVolHaPressionTravail)
        Me.GroupBox_infos.Controls.Add(Me.infosNbNiveauxBuses)
        Me.GroupBox_infos.Controls.Add(Me.Label14)
        Me.GroupBox_infos.Controls.Add(Me.Label30)
        Me.GroupBox_infos.Controls.Add(Me.infosPressionMesure)
        Me.GroupBox_infos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_infos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GroupBox_infos.Location = New System.Drawing.Point(12, 134)
        Me.GroupBox_infos.Name = "GroupBox_infos"
        Me.GroupBox_infos.Size = New System.Drawing.Size(968, 249)
        Me.GroupBox_infos.TabIndex = 0
        Me.GroupBox_infos.TabStop = False
        Me.GroupBox_infos.Text = "Informations sur les mesures"
        '
        'infosListBusesUsees
        '
        Me.infosListBusesUsees.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infosListBusesUsees.Location = New System.Drawing.Point(488, 160)
        Me.infosListBusesUsees.Name = "infosListBusesUsees"
        Me.infosListBusesUsees.Size = New System.Drawing.Size(456, 56)
        Me.infosListBusesUsees.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 48)
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
        Me.Label6.Location = New System.Drawing.Point(8, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(304, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Vitesse réelle 2 (en km/h) : "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(304, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Vitesse réelle 1 (en km/h) : "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(304, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Largeur :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(496, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(304, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Nombre de buses sur l'appareil :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Location = New System.Drawing.Point(496, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(304, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Volume hectare à la pression de travail : "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(496, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(304, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Volume hectare à la pression de mesure :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(496, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(304, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Nombre de niveaux de buses :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'infosDebitMoyPressionMesure
        '
        Me.infosDebitMoyPressionMesure.Location = New System.Drawing.Point(312, 48)
        Me.infosDebitMoyPressionMesure.Name = "infosDebitMoyPressionMesure"
        Me.infosDebitMoyPressionMesure.Size = New System.Drawing.Size(100, 20)
        Me.infosDebitMoyPressionMesure.TabIndex = 1
        '
        'infosPressionTravailMoinsPerteCharge
        '
        Me.infosPressionTravailMoinsPerteCharge.Location = New System.Drawing.Point(312, 104)
        Me.infosPressionTravailMoinsPerteCharge.Name = "infosPressionTravailMoinsPerteCharge"
        Me.infosPressionTravailMoinsPerteCharge.Size = New System.Drawing.Size(100, 20)
        Me.infosPressionTravailMoinsPerteCharge.TabIndex = 3
        '
        'infosPressionTravail
        '
        Me.infosPressionTravail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "manometrePressionTravail", True))
        Me.infosPressionTravail.Location = New System.Drawing.Point(312, 80)
        Me.infosPressionTravail.Name = "infosPressionTravail"
        Me.infosPressionTravail.Size = New System.Drawing.Size(100, 20)
        Me.infosPressionTravail.TabIndex = 2
        '
        'infosVitesseReelle1
        '
        Me.infosVitesseReelle1.Location = New System.Drawing.Point(312, 136)
        Me.infosVitesseReelle1.Name = "infosVitesseReelle1"
        Me.infosVitesseReelle1.Size = New System.Drawing.Size(100, 20)
        Me.infosVitesseReelle1.TabIndex = 4
        '
        'infosVitesseReelle2
        '
        Me.infosVitesseReelle2.Location = New System.Drawing.Point(312, 160)
        Me.infosVitesseReelle2.Name = "infosVitesseReelle2"
        Me.infosVitesseReelle2.Size = New System.Drawing.Size(100, 20)
        Me.infosVitesseReelle2.TabIndex = 5
        '
        'infosLargeur
        '
        Me.infosLargeur.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "pulverisateurLargeur", True))
        Me.infosLargeur.Location = New System.Drawing.Point(312, 192)
        Me.infosLargeur.Name = "infosLargeur"
        Me.infosLargeur.Size = New System.Drawing.Size(100, 20)
        Me.infosLargeur.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 208)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(424, 38)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "la largeur correspond correspond à celle de l'appareil (puvérisateur à rampe) ou " & _
    "à la largeur de pulvérisation (pulvérisateur à rampe ou arbo-viti)"
        '
        'infosNbBuses
        '
        Me.infosNbBuses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infosNbBuses.Location = New System.Drawing.Point(808, 24)
        Me.infosNbBuses.Name = "infosNbBuses"
        Me.infosNbBuses.Size = New System.Drawing.Size(100, 20)
        Me.infosNbBuses.TabIndex = 7
        '
        'infosVolHaPressionMesure
        '
        Me.infosVolHaPressionMesure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infosVolHaPressionMesure.Location = New System.Drawing.Point(808, 56)
        Me.infosVolHaPressionMesure.Name = "infosVolHaPressionMesure"
        Me.infosVolHaPressionMesure.ReadOnly = True
        Me.infosVolHaPressionMesure.Size = New System.Drawing.Size(100, 20)
        Me.infosVolHaPressionMesure.TabIndex = 8
        '
        'infosVolHaPressionTravail
        '
        Me.infosVolHaPressionTravail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infosVolHaPressionTravail.Location = New System.Drawing.Point(808, 80)
        Me.infosVolHaPressionTravail.Name = "infosVolHaPressionTravail"
        Me.infosVolHaPressionTravail.ReadOnly = True
        Me.infosVolHaPressionTravail.Size = New System.Drawing.Size(100, 20)
        Me.infosVolHaPressionTravail.TabIndex = 9
        '
        'infosNbNiveauxBuses
        '
        Me.infosNbNiveauxBuses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infosNbNiveauxBuses.Location = New System.Drawing.Point(808, 112)
        Me.infosNbNiveauxBuses.Name = "infosNbNiveauxBuses"
        Me.infosNbNiveauxBuses.Size = New System.Drawing.Size(100, 20)
        Me.infosNbNiveauxBuses.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Location = New System.Drawing.Point(496, 136)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(304, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "N° des buses usées par niveau : "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(8, 24)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(304, 16)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Pression de mesure :"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'infosPressionMesure
        '
        Me.infosPressionMesure.Location = New System.Drawing.Point(312, 24)
        Me.infosPressionMesure.Name = "infosPressionMesure"
        Me.infosPressionMesure.Size = New System.Drawing.Size(100, 20)
        Me.infosPressionMesure.TabIndex = 0
        '
        'm_bsRPDiagnostic
        '
        Me.m_bsRPDiagnostic.DataSource = GetType(Crodip_agent.RPDiagnostic)
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
        Me.GroupBox1.Controls.Add(Me.nupNbreNiveaux)
        Me.GroupBox1.Controls.Add(Me.nupNbreBuses)
        Me.GroupBox1.Controls.Add(Me.nupNbreDescentes)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.cbxLargeurPlantation)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(971, 92)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'nupNbreNiveaux
        '
        Me.nupNbreNiveaux.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nupNbreNiveaux.Location = New System.Drawing.Point(684, 68)
        Me.nupNbreNiveaux.Name = "nupNbreNiveaux"
        Me.nupNbreNiveaux.Size = New System.Drawing.Size(33, 20)
        Me.nupNbreNiveaux.TabIndex = 10
        '
        'nupNbreBuses
        '
        Me.nupNbreBuses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nupNbreBuses.Location = New System.Drawing.Point(684, 42)
        Me.nupNbreBuses.Name = "nupNbreBuses"
        Me.nupNbreBuses.Size = New System.Drawing.Size(33, 20)
        Me.nupNbreBuses.TabIndex = 9
        '
        'nupNbreDescentes
        '
        Me.nupNbreDescentes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nupNbreDescentes.Location = New System.Drawing.Point(684, 16)
        Me.nupNbreDescentes.Name = "nupNbreDescentes"
        Me.nupNbreDescentes.Size = New System.Drawing.Size(33, 20)
        Me.nupNbreDescentes.TabIndex = 8
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.Location = New System.Drawing.Point(485, 67)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(193, 17)
        Me.Label39.TabIndex = 7
        Me.Label39.Text = "Nbre de niveaux par descente :"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.Location = New System.Drawing.Point(485, 41)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(193, 17)
        Me.Label38.TabIndex = 6
        Me.Label38.Text = "Nbre de buses par descente :"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Location = New System.Drawing.Point(485, 15)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(139, 17)
        Me.Label37.TabIndex = 5
        Me.Label37.Text = "Nbre de descentes :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(387, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(75, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(241, 16)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(139, 32)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Vitesse de rotation de la prise de force :"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbxLargeurPlantation
        '
        Me.cbxLargeurPlantation.FormattingEnabled = True
        Me.cbxLargeurPlantation.Location = New System.Drawing.Point(154, 16)
        Me.cbxLargeurPlantation.Name = "cbxLargeurPlantation"
        Me.cbxLargeurPlantation.Size = New System.Drawing.Size(81, 21)
        Me.cbxLargeurPlantation.TabIndex = 2
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(8, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(139, 17)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "Largeur de plantation "
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RPCalculVolumeHa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 801)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox_calcAuto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox_infos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "RPCalculVolumeHa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "tool_calcVolHa"
        Me.GroupBox_calcAuto.ResumeLayout(False)
        Me.GroupBox_calcAuto.PerformLayout()
        Me.GroupBox_infos.ResumeLayout(False)
        Me.GroupBox_infos.PerformLayout()
        CType(Me.m_bsRPDiagnostic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nupNbreNiveaux, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupNbreBuses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupNbreDescentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " - Chargement - "
    Private Sub tool_calcVolHa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        formload()
    End Sub
#End Region


#Region " - Tests - "

    Private Function isFilled_calcDeb1()
        If infosNbBuses.Text <> "" And infosDebitMoyPressionMesure.Text <> "" And infosLargeur.Text <> "" And infosVitesseReelle1.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function isFilled_calcDeb2()
        If infosNbBuses.Text <> "" And calcDeb2Debit.Text <> "" And infosLargeur.Text <> "" And infosVitesseReelle1.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function isFilled_calc_Deb2Debit()
        If calcDeb1PressionConnue.Text <> "" And calcDeb1DebitMoyConnu.Text <> "" And calcDeb2Pression.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function isFilled_calcVitesse()
        If calcVitesseDistance.Text <> "" And calcVitesseTemps.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

#Region " - Calculs - "

    Private Sub calc_Deb1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcDeb1PressionConnue.TextChanged, calcDeb1DebitMoyConnu.TextChanged, calcDeb1Vitesse.TextChanged, calcDeb1Ecartement.TextChanged, infosDebitMoyPressionMesure.TextChanged, infosLargeur.TextChanged, infosNbBuses.TextChanged, infosPressionMesure.TextChanged, infosVitesseReelle1.TextChanged
        If isFilled_calcDeb1() Then
            Try

                ' On récupère les valeurs
                Dim tmpInfosNbBuses As Decimal = CType(infosNbBuses.Text.Replace(".", ","), Decimal)
                Dim tmpInfosDebitMoyPressionMesure As Decimal = CType(infosDebitMoyPressionMesure.Text.Replace(".", ","), Decimal)
                Dim tmpInfosLargeur As Decimal = CType(infosLargeur.Text.Replace(".", ","), Decimal)
                Dim tmpInfosVitesseReelle1 As Decimal = CType(infosVitesseReelle1.Text.Replace(".", ","), Decimal)

                ' On calcul
                calcDeb1VolEauHa.Text = Math.Round(((tmpInfosNbBuses * tmpInfosDebitMoyPressionMesure) * 600) / (tmpInfosLargeur * tmpInfosVitesseReelle1), 2)
                infosVolHaPressionMesure.Text = calcDeb1VolEauHa.Text

            Catch ex As Exception
                CSDebug.dispError("Calcul Vol/Ha :: calcDeb1 : " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub calc_Deb2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcDeb2Pression.TextChanged, calcDeb2Debit.TextChanged, calcDeb2Vitesse.TextChanged, calcDeb2Ecartement.TextChanged, infosPressionTravailMoinsPerteCharge.TextChanged
        If isFilled_calcDeb2() Then
            Try

                ' On récupère les valeurs
                Dim tmpInfosNbBuses As Decimal = CType(infosNbBuses.Text.Replace(".", ","), Decimal)
                Dim tmpInfosDebitMoyPressionMesure As Decimal = CType(calcDeb2Debit.Text.Replace(".", ","), Decimal)
                Dim tmpInfosLargeur As Decimal = CType(infosLargeur.Text.Replace(".", ","), Decimal)
                Dim tmpInfosVitesseReelle1 As Decimal = CType(infosVitesseReelle1.Text.Replace(".", ","), Decimal)

                ' On calcul
                calcDeb2VolEauHa.Text = Math.Round(((tmpInfosNbBuses * tmpInfosDebitMoyPressionMesure) * 600) / (tmpInfosLargeur * tmpInfosVitesseReelle1), 2)
                infosVolHaPressionTravail.Text = calcDeb2VolEauHa.Text

            Catch ex As Exception
                CSDebug.dispError("Calcul Vol/Ha :: calcDeb2 : " & ex.Message)
            End Try
        End If
    End Sub
    Private Sub calc_Vitesse(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcVitesseDistance.TextChanged, calcVitesseTemps.TextChanged
        If isFilled_calcVitesse() Then
            Try

                ' On récupère les valeurs
                Dim tmpCalcVitesseDistance As Decimal = CType(calcVitesseDistance.Text.Replace(".", ","), Decimal)
                Dim tmpCalcVitesseTemps As Decimal = CType(calcVitesseTemps.Text.Replace(".", ","), Decimal)

                ' On calcul
                calcVitesseVitesse.Text = Math.Round((3.6 * tmpCalcVitesseDistance) / tmpCalcVitesseTemps, 2)

            Catch ex As Exception
                CSDebug.dispError("Calcul Vol/Ha :: calcVitesse : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub calc_Deb2Debit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcDeb1PressionConnue.TextChanged, calcDeb1DebitMoyConnu.TextChanged, calcDeb2Pression.TextChanged
        If isFilled_calc_Deb2Debit() Then
            Try

                ' On récupère les valeurs
                Dim tmpcalcDeb1PressionConnue As Decimal = CType(calcDeb1PressionConnue.Text.Replace(".", ","), Decimal)
                Dim tmpCalcDeb1DebitMoyConnu As Decimal = CType(calcDeb1DebitMoyConnu.Text.Replace(".", ","), Decimal)
                Dim tmpCalcDeb2Pression As Decimal = CType(calcDeb2Pression.Text.Replace(".", ","), Decimal)

                ' On calcul
                calcDeb2Debit.Text = Math.Round(Math.Sqrt((tmpCalcDeb1DebitMoyConnu * tmpCalcDeb1DebitMoyConnu * tmpCalcDeb2Pression) / tmpcalcDeb1PressionConnue), 2)

                ' On met à jour les champs
                calc_Deb2(sender, e)

            Catch ex As Exception
                CSDebug.dispError("Calcul Vol/Ha :: calc_Deb2Debit : " & ex.Message)
            End Try
        End If
    End Sub

#End Region

#Region " - MAJ Champs - "

    Private Sub infosPressionMesure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcDeb1PressionConnue.Text = sender.text
    End Sub

    Private Sub infosDebitMoyPressionMesure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcDeb1DebitMoyConnu.Text = sender.text
    End Sub

    Private Sub infosVitesseReelle1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcDeb1Vitesse.TextChanged, calcDeb2Vitesse.TextChanged
        If sender.name <> "infosVitesseReelle1" Then
            infosVitesseReelle1.Text = sender.text
        End If
        If sender.name <> "calcDeb1Vitesse" Then
            calcDeb1Vitesse.Text = sender.text
        End If
        If sender.name <> "calcDeb2Vitesse" Then
            calcDeb2Vitesse.Text = sender.text
        End If
    End Sub

    Private Sub infosLargeur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcDeb1Ecartement.TextChanged, calcDeb2Ecartement.TextChanged
        If sender.name <> "infosLargeur" Then
            infosLargeur.Text = sender.text
        End If
        If sender.name <> "calcDeb1Ecartement" Then
            calcDeb1Ecartement.Text = sender.text
        End If
        If sender.name <> "calcDeb2Ecartement" Then
            calcDeb2Ecartement.Text = sender.text
        End If
    End Sub

    Private Sub infosPressionTravailMoinsPerteCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcDeb2Pression.Text = sender.text
    End Sub

#End Region


    Public Overridable Sub setContexte(pDiag As RPDiagnostic)
        m_oDiag = pDiag
        m_bsRPDiagnostic.Add(m_oDiag)
    End Sub
    Protected Overridable Sub formload() Implements IfrmCRODIP.formLoad
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

End Class
