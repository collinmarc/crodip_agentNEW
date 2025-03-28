Imports System.Collections.Generic
Imports CRODIPWS

Public Class tool_diagBuses
    Inherits frmCRODIP

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        globFormToolBuses = Me
        'm_oRefBuses = New ReferentielBusesCSV()

    End Sub
    Public Sub New(ByVal _objInfos As Object, ByVal _formFichePedagogique As diagnostic_infosInspecteur)
        Me.New()
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
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents diagBuses_conf_pressionMesure As System.Windows.Forms.TextBox
    Friend WithEvents diagBuses_tab_categories As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents fichePulve_buses_marque As System.Windows.Forms.ComboBox
    Friend WithEvents Panel121 As System.Windows.Forms.Panel
    Friend WithEvents Panel65 As System.Windows.Forms.Panel
    Friend WithEvents Panel68 As System.Windows.Forms.Panel
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Panel70 As System.Windows.Forms.Panel
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Panel69 As System.Windows.Forms.Panel
    Friend WithEvents diagBuses_mesureDebit_2_debit As System.Windows.Forms.TextBox
    Friend WithEvents Panel71 As System.Windows.Forms.Panel
    Friend WithEvents diagBuses_mesureDebit_1_debit As System.Windows.Forms.TextBox
    Friend WithEvents Panel38 As System.Windows.Forms.Panel
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Panel49 As System.Windows.Forms.Panel
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Panel66 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel67 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel97 As System.Windows.Forms.Panel
    Friend WithEvents TextBox31 As System.Windows.Forms.TextBox
    Friend WithEvents Panel98 As System.Windows.Forms.Panel
    Friend WithEvents TextBox32 As System.Windows.Forms.TextBox
    Friend WithEvents Panel99 As System.Windows.Forms.Panel
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Panel100 As System.Windows.Forms.Panel
    Friend WithEvents TextBox33 As System.Windows.Forms.TextBox
    Friend WithEvents Panel101 As System.Windows.Forms.Panel
    Friend WithEvents TextBox34 As System.Windows.Forms.TextBox
    Friend WithEvents Panel102 As System.Windows.Forms.Panel
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Panel103 As System.Windows.Forms.Panel
    Friend WithEvents TextBox35 As System.Windows.Forms.TextBox
    Friend WithEvents Panel104 As System.Windows.Forms.Panel
    Friend WithEvents TextBox36 As System.Windows.Forms.TextBox
    Friend WithEvents Panel105 As System.Windows.Forms.Panel
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Panel106 As System.Windows.Forms.Panel
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Panel107 As System.Windows.Forms.Panel
    Friend WithEvents TextBox37 As System.Windows.Forms.TextBox
    Friend WithEvents Panel108 As System.Windows.Forms.Panel
    Friend WithEvents TextBox38 As System.Windows.Forms.TextBox
    Friend WithEvents Panel109 As System.Windows.Forms.Panel
    Friend WithEvents TextBox39 As System.Windows.Forms.TextBox
    Friend WithEvents Panel110 As System.Windows.Forms.Panel
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Panel111 As System.Windows.Forms.Panel
    Friend WithEvents TextBox40 As System.Windows.Forms.TextBox
    Friend WithEvents Panel112 As System.Windows.Forms.Panel
    Friend WithEvents TextBox41 As System.Windows.Forms.TextBox
    Friend WithEvents Panel113 As System.Windows.Forms.Panel
    Friend WithEvents TextBox42 As System.Windows.Forms.TextBox
    Friend WithEvents Panel114 As System.Windows.Forms.Panel
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Panel115 As System.Windows.Forms.Panel
    Friend WithEvents TextBox44 As System.Windows.Forms.TextBox
    Friend WithEvents Panel116 As System.Windows.Forms.Panel
    Friend WithEvents TextBox45 As System.Windows.Forms.TextBox
    Friend WithEvents Panel117 As System.Windows.Forms.Panel
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Panel118 As System.Windows.Forms.Panel
    Friend WithEvents TextBox46 As System.Windows.Forms.TextBox
    Friend WithEvents Panel119 As System.Windows.Forms.Panel
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Panel120 As System.Windows.Forms.Panel
    Friend WithEvents TextBox47 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents validerNbBuses As System.Windows.Forms.Label
    Friend WithEvents TextBox48 As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TextBox49 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBox50 As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents TextBox51 As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label216 As System.Windows.Forms.Label
    Friend WithEvents Label217 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label218 As System.Windows.Forms.Label
    Friend WithEvents Label219 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents diagBuses_conf_nbCategories As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents diagBuses_conf_validNbCategories As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents diagBuses_nbBusesUsees As System.Windows.Forms.TextBox
    Friend WithEvents Label213 As System.Windows.Forms.Label
    Friend WithEvents diagBuses_usureMoyBuses As System.Windows.Forms.TextBox
    Friend WithEvents Label214 As System.Windows.Forms.Label
    Friend WithEvents Label215 As System.Windows.Forms.Label
    Friend WithEvents diagBuses_debitMoyen As System.Windows.Forms.TextBox
    Friend WithEvents diagBuses_resultat As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents btn_diagnostic_acquisitionDonnees As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents buses_listManoControle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFermer As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tool_diagBuses))
        Me.Panel64 = New System.Windows.Forms.Panel()
        Me.btnFermer = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.diagBuses_conf_pressionMesure = New System.Windows.Forms.TextBox()
        Me.diagBuses_tab_categories = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.fichePulve_buses_marque = New System.Windows.Forms.ComboBox()
        Me.Panel121 = New System.Windows.Forms.Panel()
        Me.Panel65 = New System.Windows.Forms.Panel()
        Me.Panel68 = New System.Windows.Forms.Panel()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Panel70 = New System.Windows.Forms.Panel()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel69 = New System.Windows.Forms.Panel()
        Me.diagBuses_mesureDebit_2_debit = New System.Windows.Forms.TextBox()
        Me.Panel71 = New System.Windows.Forms.Panel()
        Me.diagBuses_mesureDebit_1_debit = New System.Windows.Forms.TextBox()
        Me.Panel38 = New System.Windows.Forms.Panel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Panel49 = New System.Windows.Forms.Panel()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Panel66 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel67 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel97 = New System.Windows.Forms.Panel()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.Panel98 = New System.Windows.Forms.Panel()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.Panel99 = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Panel100 = New System.Windows.Forms.Panel()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.Panel101 = New System.Windows.Forms.Panel()
        Me.TextBox34 = New System.Windows.Forms.TextBox()
        Me.Panel102 = New System.Windows.Forms.Panel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Panel103 = New System.Windows.Forms.Panel()
        Me.TextBox35 = New System.Windows.Forms.TextBox()
        Me.Panel104 = New System.Windows.Forms.Panel()
        Me.TextBox36 = New System.Windows.Forms.TextBox()
        Me.Panel105 = New System.Windows.Forms.Panel()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Panel106 = New System.Windows.Forms.Panel()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Panel107 = New System.Windows.Forms.Panel()
        Me.TextBox37 = New System.Windows.Forms.TextBox()
        Me.Panel108 = New System.Windows.Forms.Panel()
        Me.TextBox38 = New System.Windows.Forms.TextBox()
        Me.Panel109 = New System.Windows.Forms.Panel()
        Me.TextBox39 = New System.Windows.Forms.TextBox()
        Me.Panel110 = New System.Windows.Forms.Panel()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Panel111 = New System.Windows.Forms.Panel()
        Me.TextBox40 = New System.Windows.Forms.TextBox()
        Me.Panel112 = New System.Windows.Forms.Panel()
        Me.TextBox41 = New System.Windows.Forms.TextBox()
        Me.Panel113 = New System.Windows.Forms.Panel()
        Me.TextBox42 = New System.Windows.Forms.TextBox()
        Me.Panel114 = New System.Windows.Forms.Panel()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Panel115 = New System.Windows.Forms.Panel()
        Me.TextBox44 = New System.Windows.Forms.TextBox()
        Me.Panel116 = New System.Windows.Forms.Panel()
        Me.TextBox45 = New System.Windows.Forms.TextBox()
        Me.Panel117 = New System.Windows.Forms.Panel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Panel118 = New System.Windows.Forms.Panel()
        Me.TextBox46 = New System.Windows.Forms.TextBox()
        Me.Panel119 = New System.Windows.Forms.Panel()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Panel120 = New System.Windows.Forms.Panel()
        Me.TextBox47 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.validerNbBuses = New System.Windows.Forms.Label()
        Me.TextBox48 = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TextBox49 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox50 = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.TextBox51 = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label216 = New System.Windows.Forms.Label()
        Me.Label217 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label218 = New System.Windows.Forms.Label()
        Me.Label219 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.diagBuses_conf_nbCategories = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.diagBuses_conf_validNbCategories = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.diagBuses_nbBusesUsees = New System.Windows.Forms.TextBox()
        Me.Label213 = New System.Windows.Forms.Label()
        Me.diagBuses_usureMoyBuses = New System.Windows.Forms.TextBox()
        Me.Label214 = New System.Windows.Forms.Label()
        Me.Label215 = New System.Windows.Forms.Label()
        Me.diagBuses_debitMoyen = New System.Windows.Forms.TextBox()
        Me.diagBuses_resultat = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.btn_diagnostic_acquisitionDonnees = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.buses_listManoControle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel64.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.diagBuses_tab_categories.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel65.SuspendLayout()
        Me.Panel68.SuspendLayout()
        Me.Panel70.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel69.SuspendLayout()
        Me.Panel71.SuspendLayout()
        Me.Panel38.SuspendLayout()
        Me.Panel49.SuspendLayout()
        Me.Panel66.SuspendLayout()
        Me.Panel67.SuspendLayout()
        Me.Panel97.SuspendLayout()
        Me.Panel98.SuspendLayout()
        Me.Panel99.SuspendLayout()
        Me.Panel100.SuspendLayout()
        Me.Panel101.SuspendLayout()
        Me.Panel102.SuspendLayout()
        Me.Panel103.SuspendLayout()
        Me.Panel104.SuspendLayout()
        Me.Panel105.SuspendLayout()
        Me.Panel106.SuspendLayout()
        Me.Panel107.SuspendLayout()
        Me.Panel108.SuspendLayout()
        Me.Panel109.SuspendLayout()
        Me.Panel110.SuspendLayout()
        Me.Panel111.SuspendLayout()
        Me.Panel112.SuspendLayout()
        Me.Panel113.SuspendLayout()
        Me.Panel114.SuspendLayout()
        Me.Panel115.SuspendLayout()
        Me.Panel116.SuspendLayout()
        Me.Panel117.SuspendLayout()
        Me.Panel118.SuspendLayout()
        Me.Panel119.SuspendLayout()
        Me.Panel120.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel64
        '
        Me.Panel64.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel64.Controls.Add(Me.btnFermer)
        Me.Panel64.Controls.Add(Me.Panel11)
        Me.Panel64.Controls.Add(Me.btn_diagnostic_acquisitionDonnees)
        Me.Panel64.Controls.Add(Me.Label76)
        Me.Panel64.Controls.Add(Me.buses_listManoControle)
        Me.Panel64.Location = New System.Drawing.Point(0, 56)
        Me.Panel64.Name = "Panel64"
        Me.Panel64.Size = New System.Drawing.Size(1008, 623)
        Me.Panel64.TabIndex = 20
        '
        'btnFermer
        '
        Me.btnFermer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFermer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFermer.ForeColor = System.Drawing.Color.White
        Me.btnFermer.Image = CType(resources.GetObject("btnFermer.Image"), System.Drawing.Image)
        Me.btnFermer.Location = New System.Drawing.Point(856, 584)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(128, 24)
        Me.btnFermer.TabIndex = 29
        Me.btnFermer.Text = "    Fermer l'outil"
        Me.btnFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Controls.Add(Me.diagBuses_conf_pressionMesure)
        Me.Panel11.Controls.Add(Me.diagBuses_tab_categories)
        Me.Panel11.Controls.Add(Me.diagBuses_conf_nbCategories)
        Me.Panel11.Controls.Add(Me.Label23)
        Me.Panel11.Controls.Add(Me.diagBuses_conf_validNbCategories)
        Me.Panel11.Controls.Add(Me.Label52)
        Me.Panel11.Controls.Add(Me.diagBuses_nbBusesUsees)
        Me.Panel11.Controls.Add(Me.Label213)
        Me.Panel11.Controls.Add(Me.diagBuses_usureMoyBuses)
        Me.Panel11.Controls.Add(Me.Label214)
        Me.Panel11.Controls.Add(Me.Label215)
        Me.Panel11.Controls.Add(Me.diagBuses_debitMoyen)
        Me.Panel11.Controls.Add(Me.diagBuses_resultat)
        Me.Panel11.Controls.Add(Me.Label55)
        Me.Panel11.Controls.Add(Me.Label53)
        Me.Panel11.Location = New System.Drawing.Point(0, 56)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1008, 435)
        Me.Panel11.TabIndex = 28
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(464, 8)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(152, 16)
        Me.Label33.TabIndex = 28
        Me.Label33.Text = "Pression de mesure (bar) :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_conf_pressionMesure
        '
        Me.diagBuses_conf_pressionMesure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_conf_pressionMesure.Location = New System.Drawing.Point(624, 8)
        Me.diagBuses_conf_pressionMesure.Name = "diagBuses_conf_pressionMesure"
        Me.diagBuses_conf_pressionMesure.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_conf_pressionMesure.TabIndex = 29
        '
        'diagBuses_tab_categories
        '
        Me.diagBuses_tab_categories.Controls.Add(Me.TabPage3)
        Me.diagBuses_tab_categories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_tab_categories.Location = New System.Drawing.Point(8, 40)
        Me.diagBuses_tab_categories.Name = "diagBuses_tab_categories"
        Me.diagBuses_tab_categories.SelectedIndex = 0
        Me.diagBuses_tab_categories.Size = New System.Drawing.Size(992, 352)
        Me.diagBuses_tab_categories.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.fichePulve_buses_marque)
        Me.TabPage3.Controls.Add(Me.Panel121)
        Me.TabPage3.Controls.Add(Me.Panel65)
        Me.TabPage3.Controls.Add(Me.TextBox12)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.TextBox13)
        Me.TabPage3.Controls.Add(Me.TextBox14)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.validerNbBuses)
        Me.TabPage3.Controls.Add(Me.TextBox48)
        Me.TabPage3.Controls.Add(Me.Label48)
        Me.TabPage3.Controls.Add(Me.Label49)
        Me.TabPage3.Controls.Add(Me.TextBox49)
        Me.TabPage3.Controls.Add(Me.TextBox11)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.TextBox50)
        Me.TabPage3.Controls.Add(Me.Label50)
        Me.TabPage3.Controls.Add(Me.TextBox51)
        Me.TabPage3.Controls.Add(Me.Label51)
        Me.TabPage3.Controls.Add(Me.Label216)
        Me.TabPage3.Controls.Add(Me.Label217)
        Me.TabPage3.Controls.Add(Me.ComboBox1)
        Me.TabPage3.Controls.Add(Me.Label218)
        Me.TabPage3.Controls.Add(Me.Label219)
        Me.TabPage3.Controls.Add(Me.ComboBox2)
        Me.TabPage3.Controls.Add(Me.ComboBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(984, 326)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Niveau 1"
        '
        'fichePulve_buses_marque
        '
        Me.fichePulve_buses_marque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fichePulve_buses_marque.Location = New System.Drawing.Point(712, 16)
        Me.fichePulve_buses_marque.Name = "fichePulve_buses_marque"
        Me.fichePulve_buses_marque.Size = New System.Drawing.Size(96, 21)
        Me.fichePulve_buses_marque.TabIndex = 28
        '
        'Panel121
        '
        Me.Panel121.Location = New System.Drawing.Point(16, 255)
        Me.Panel121.Name = "Panel121"
        Me.Panel121.Size = New System.Drawing.Size(952, 24)
        Me.Panel121.TabIndex = 27
        '
        'Panel65
        '
        Me.Panel65.AutoScroll = True
        Me.Panel65.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel65.Controls.Add(Me.Panel68)
        Me.Panel65.Controls.Add(Me.Panel70)
        Me.Panel65.Controls.Add(Me.Panel12)
        Me.Panel65.Controls.Add(Me.Panel13)
        Me.Panel65.Location = New System.Drawing.Point(16, 72)
        Me.Panel65.Name = "Panel65"
        Me.Panel65.Size = New System.Drawing.Size(952, 200)
        Me.Panel65.TabIndex = 24
        '
        'Panel68
        '
        Me.Panel68.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel68.Controls.Add(Me.Label81)
        Me.Panel68.Location = New System.Drawing.Point(0, 0)
        Me.Panel68.Name = "Panel68"
        Me.Panel68.Size = New System.Drawing.Size(72, 40)
        Me.Panel68.TabIndex = 19
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label81.Location = New System.Drawing.Point(16, 12)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(40, 16)
        Me.Label81.TabIndex = 6
        Me.Label81.Text = "N°"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel70
        '
        Me.Panel70.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel70.Controls.Add(Me.Label80)
        Me.Panel70.Location = New System.Drawing.Point(0, 41)
        Me.Panel70.Name = "Panel70"
        Me.Panel70.Size = New System.Drawing.Size(72, 71)
        Me.Panel70.TabIndex = 16
        '
        'Label80
        '
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label80.Location = New System.Drawing.Point(8, 27)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(56, 16)
        Me.Label80.TabIndex = 8
        Me.Label80.Text = "Débit"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel12.Controls.Add(Me.Label79)
        Me.Panel12.Location = New System.Drawing.Point(0, 113)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(72, 71)
        Me.Panel12.TabIndex = 16
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label79.Location = New System.Drawing.Point(4, 27)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(64, 16)
        Me.Label79.TabIndex = 9
        Me.Label79.Text = "Usure (%)"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel13
        '
        Me.Panel13.AutoScroll = True
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel13.Controls.Add(Me.Panel69)
        Me.Panel13.Controls.Add(Me.Panel71)
        Me.Panel13.Controls.Add(Me.Panel38)
        Me.Panel13.Controls.Add(Me.Panel49)
        Me.Panel13.Controls.Add(Me.Panel66)
        Me.Panel13.Controls.Add(Me.Panel67)
        Me.Panel13.Controls.Add(Me.Panel97)
        Me.Panel13.Controls.Add(Me.Panel98)
        Me.Panel13.Controls.Add(Me.Panel99)
        Me.Panel13.Controls.Add(Me.Panel100)
        Me.Panel13.Controls.Add(Me.Panel101)
        Me.Panel13.Controls.Add(Me.Panel102)
        Me.Panel13.Controls.Add(Me.Panel103)
        Me.Panel13.Controls.Add(Me.Panel104)
        Me.Panel13.Controls.Add(Me.Panel105)
        Me.Panel13.Controls.Add(Me.Panel106)
        Me.Panel13.Controls.Add(Me.Panel107)
        Me.Panel13.Controls.Add(Me.Panel108)
        Me.Panel13.Controls.Add(Me.Panel109)
        Me.Panel13.Controls.Add(Me.Panel110)
        Me.Panel13.Controls.Add(Me.Panel111)
        Me.Panel13.Controls.Add(Me.Panel112)
        Me.Panel13.Controls.Add(Me.Panel113)
        Me.Panel13.Controls.Add(Me.Panel114)
        Me.Panel13.Controls.Add(Me.Panel115)
        Me.Panel13.Controls.Add(Me.Panel116)
        Me.Panel13.Controls.Add(Me.Panel117)
        Me.Panel13.Controls.Add(Me.Panel118)
        Me.Panel13.Controls.Add(Me.Panel119)
        Me.Panel13.Controls.Add(Me.Panel120)
        Me.Panel13.Location = New System.Drawing.Point(72, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(880, 184)
        Me.Panel13.TabIndex = 25
        '
        'Panel69
        '
        Me.Panel69.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel69.Controls.Add(Me.diagBuses_mesureDebit_2_debit)
        Me.Panel69.Location = New System.Drawing.Point(89, 41)
        Me.Panel69.Name = "Panel69"
        Me.Panel69.Size = New System.Drawing.Size(87, 71)
        Me.Panel69.TabIndex = 18
        '
        'diagBuses_mesureDebit_2_debit
        '
        Me.diagBuses_mesureDebit_2_debit.Location = New System.Drawing.Point(15, 25)
        Me.diagBuses_mesureDebit_2_debit.Name = "diagBuses_mesureDebit_2_debit"
        Me.diagBuses_mesureDebit_2_debit.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_mesureDebit_2_debit.TabIndex = 15
        '
        'Panel71
        '
        Me.Panel71.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel71.Controls.Add(Me.diagBuses_mesureDebit_1_debit)
        Me.Panel71.Location = New System.Drawing.Point(1, 41)
        Me.Panel71.Name = "Panel71"
        Me.Panel71.Size = New System.Drawing.Size(87, 71)
        Me.Panel71.TabIndex = 17
        '
        'diagBuses_mesureDebit_1_debit
        '
        Me.diagBuses_mesureDebit_1_debit.Location = New System.Drawing.Point(15, 25)
        Me.diagBuses_mesureDebit_1_debit.Name = "diagBuses_mesureDebit_1_debit"
        Me.diagBuses_mesureDebit_1_debit.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_mesureDebit_1_debit.TabIndex = 14
        '
        'Panel38
        '
        Me.Panel38.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel38.Controls.Add(Me.TextBox5)
        Me.Panel38.Location = New System.Drawing.Point(1, 113)
        Me.Panel38.Name = "Panel38"
        Me.Panel38.Size = New System.Drawing.Size(87, 71)
        Me.Panel38.TabIndex = 17
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox5.Location = New System.Drawing.Point(15, 25)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(56, 20)
        Me.TextBox5.TabIndex = 14
        '
        'Panel49
        '
        Me.Panel49.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel49.Controls.Add(Me.TextBox6)
        Me.Panel49.Location = New System.Drawing.Point(89, 113)
        Me.Panel49.Name = "Panel49"
        Me.Panel49.Size = New System.Drawing.Size(87, 71)
        Me.Panel49.TabIndex = 18
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(15, 25)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(56, 20)
        Me.TextBox6.TabIndex = 15
        '
        'Panel66
        '
        Me.Panel66.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel66.Controls.Add(Me.Label17)
        Me.Panel66.Location = New System.Drawing.Point(89, 0)
        Me.Panel66.Name = "Panel66"
        Me.Panel66.Size = New System.Drawing.Size(87, 40)
        Me.Panel66.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(29, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 16)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "2"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel67
        '
        Me.Panel67.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel67.Controls.Add(Me.Label18)
        Me.Panel67.Location = New System.Drawing.Point(1, 0)
        Me.Panel67.Name = "Panel67"
        Me.Panel67.Size = New System.Drawing.Size(87, 40)
        Me.Panel67.TabIndex = 20
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(29, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(28, 16)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "1"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel97
        '
        Me.Panel97.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel97.Controls.Add(Me.TextBox31)
        Me.Panel97.Location = New System.Drawing.Point(177, 113)
        Me.Panel97.Name = "Panel97"
        Me.Panel97.Size = New System.Drawing.Size(87, 71)
        Me.Panel97.TabIndex = 18
        '
        'TextBox31
        '
        Me.TextBox31.Location = New System.Drawing.Point(15, 25)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.ReadOnly = True
        Me.TextBox31.Size = New System.Drawing.Size(56, 20)
        Me.TextBox31.TabIndex = 15
        '
        'Panel98
        '
        Me.Panel98.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel98.Controls.Add(Me.TextBox32)
        Me.Panel98.Location = New System.Drawing.Point(177, 41)
        Me.Panel98.Name = "Panel98"
        Me.Panel98.Size = New System.Drawing.Size(87, 71)
        Me.Panel98.TabIndex = 18
        '
        'TextBox32
        '
        Me.TextBox32.Location = New System.Drawing.Point(15, 25)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New System.Drawing.Size(56, 20)
        Me.TextBox32.TabIndex = 15
        '
        'Panel99
        '
        Me.Panel99.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel99.Controls.Add(Me.Label40)
        Me.Panel99.Location = New System.Drawing.Point(177, 0)
        Me.Panel99.Name = "Panel99"
        Me.Panel99.Size = New System.Drawing.Size(87, 40)
        Me.Panel99.TabIndex = 21
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(29, 12)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(28, 16)
        Me.Label40.TabIndex = 13
        Me.Label40.Text = "2"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel100
        '
        Me.Panel100.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel100.Controls.Add(Me.TextBox33)
        Me.Panel100.Location = New System.Drawing.Point(265, 113)
        Me.Panel100.Name = "Panel100"
        Me.Panel100.Size = New System.Drawing.Size(87, 71)
        Me.Panel100.TabIndex = 18
        '
        'TextBox33
        '
        Me.TextBox33.Location = New System.Drawing.Point(15, 25)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.ReadOnly = True
        Me.TextBox33.Size = New System.Drawing.Size(56, 20)
        Me.TextBox33.TabIndex = 15
        '
        'Panel101
        '
        Me.Panel101.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel101.Controls.Add(Me.TextBox34)
        Me.Panel101.Location = New System.Drawing.Point(265, 41)
        Me.Panel101.Name = "Panel101"
        Me.Panel101.Size = New System.Drawing.Size(87, 71)
        Me.Panel101.TabIndex = 18
        '
        'TextBox34
        '
        Me.TextBox34.Location = New System.Drawing.Point(15, 25)
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New System.Drawing.Size(56, 20)
        Me.TextBox34.TabIndex = 15
        '
        'Panel102
        '
        Me.Panel102.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel102.Controls.Add(Me.Label41)
        Me.Panel102.Location = New System.Drawing.Point(265, 0)
        Me.Panel102.Name = "Panel102"
        Me.Panel102.Size = New System.Drawing.Size(87, 40)
        Me.Panel102.TabIndex = 21
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(29, 12)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(28, 16)
        Me.Label41.TabIndex = 13
        Me.Label41.Text = "2"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel103
        '
        Me.Panel103.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel103.Controls.Add(Me.TextBox35)
        Me.Panel103.Location = New System.Drawing.Point(353, 113)
        Me.Panel103.Name = "Panel103"
        Me.Panel103.Size = New System.Drawing.Size(87, 71)
        Me.Panel103.TabIndex = 18
        '
        'TextBox35
        '
        Me.TextBox35.Location = New System.Drawing.Point(15, 25)
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.ReadOnly = True
        Me.TextBox35.Size = New System.Drawing.Size(56, 20)
        Me.TextBox35.TabIndex = 15
        '
        'Panel104
        '
        Me.Panel104.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel104.Controls.Add(Me.TextBox36)
        Me.Panel104.Location = New System.Drawing.Point(353, 41)
        Me.Panel104.Name = "Panel104"
        Me.Panel104.Size = New System.Drawing.Size(87, 71)
        Me.Panel104.TabIndex = 18
        '
        'TextBox36
        '
        Me.TextBox36.Location = New System.Drawing.Point(15, 25)
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New System.Drawing.Size(56, 20)
        Me.TextBox36.TabIndex = 15
        '
        'Panel105
        '
        Me.Panel105.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel105.Controls.Add(Me.Label42)
        Me.Panel105.Location = New System.Drawing.Point(353, 0)
        Me.Panel105.Name = "Panel105"
        Me.Panel105.Size = New System.Drawing.Size(87, 40)
        Me.Panel105.TabIndex = 21
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(29, 12)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(28, 16)
        Me.Label42.TabIndex = 13
        Me.Label42.Text = "2"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel106
        '
        Me.Panel106.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel106.Controls.Add(Me.Label43)
        Me.Panel106.Location = New System.Drawing.Point(441, 0)
        Me.Panel106.Name = "Panel106"
        Me.Panel106.Size = New System.Drawing.Size(87, 40)
        Me.Panel106.TabIndex = 21
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label43.Location = New System.Drawing.Point(29, 12)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(28, 16)
        Me.Label43.TabIndex = 13
        Me.Label43.Text = "2"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel107
        '
        Me.Panel107.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel107.Controls.Add(Me.TextBox37)
        Me.Panel107.Location = New System.Drawing.Point(441, 113)
        Me.Panel107.Name = "Panel107"
        Me.Panel107.Size = New System.Drawing.Size(87, 71)
        Me.Panel107.TabIndex = 18
        '
        'TextBox37
        '
        Me.TextBox37.Location = New System.Drawing.Point(15, 25)
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.ReadOnly = True
        Me.TextBox37.Size = New System.Drawing.Size(56, 20)
        Me.TextBox37.TabIndex = 15
        '
        'Panel108
        '
        Me.Panel108.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel108.Controls.Add(Me.TextBox38)
        Me.Panel108.Location = New System.Drawing.Point(441, 41)
        Me.Panel108.Name = "Panel108"
        Me.Panel108.Size = New System.Drawing.Size(87, 71)
        Me.Panel108.TabIndex = 18
        '
        'TextBox38
        '
        Me.TextBox38.Location = New System.Drawing.Point(15, 25)
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New System.Drawing.Size(56, 20)
        Me.TextBox38.TabIndex = 15
        '
        'Panel109
        '
        Me.Panel109.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel109.Controls.Add(Me.TextBox39)
        Me.Panel109.Location = New System.Drawing.Point(529, 113)
        Me.Panel109.Name = "Panel109"
        Me.Panel109.Size = New System.Drawing.Size(87, 71)
        Me.Panel109.TabIndex = 18
        '
        'TextBox39
        '
        Me.TextBox39.Location = New System.Drawing.Point(15, 25)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.ReadOnly = True
        Me.TextBox39.Size = New System.Drawing.Size(56, 20)
        Me.TextBox39.TabIndex = 15
        '
        'Panel110
        '
        Me.Panel110.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel110.Controls.Add(Me.Label44)
        Me.Panel110.Location = New System.Drawing.Point(529, 0)
        Me.Panel110.Name = "Panel110"
        Me.Panel110.Size = New System.Drawing.Size(87, 40)
        Me.Panel110.TabIndex = 21
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(29, 12)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(28, 16)
        Me.Label44.TabIndex = 13
        Me.Label44.Text = "2"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel111
        '
        Me.Panel111.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel111.Controls.Add(Me.TextBox40)
        Me.Panel111.Location = New System.Drawing.Point(529, 41)
        Me.Panel111.Name = "Panel111"
        Me.Panel111.Size = New System.Drawing.Size(87, 71)
        Me.Panel111.TabIndex = 18
        '
        'TextBox40
        '
        Me.TextBox40.Location = New System.Drawing.Point(15, 25)
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New System.Drawing.Size(56, 20)
        Me.TextBox40.TabIndex = 15
        '
        'Panel112
        '
        Me.Panel112.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel112.Controls.Add(Me.TextBox41)
        Me.Panel112.Location = New System.Drawing.Point(617, 113)
        Me.Panel112.Name = "Panel112"
        Me.Panel112.Size = New System.Drawing.Size(87, 71)
        Me.Panel112.TabIndex = 18
        '
        'TextBox41
        '
        Me.TextBox41.Location = New System.Drawing.Point(15, 25)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.ReadOnly = True
        Me.TextBox41.Size = New System.Drawing.Size(56, 20)
        Me.TextBox41.TabIndex = 15
        '
        'Panel113
        '
        Me.Panel113.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel113.Controls.Add(Me.TextBox42)
        Me.Panel113.Location = New System.Drawing.Point(617, 41)
        Me.Panel113.Name = "Panel113"
        Me.Panel113.Size = New System.Drawing.Size(87, 71)
        Me.Panel113.TabIndex = 18
        '
        'TextBox42
        '
        Me.TextBox42.Location = New System.Drawing.Point(15, 25)
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New System.Drawing.Size(56, 20)
        Me.TextBox42.TabIndex = 15
        '
        'Panel114
        '
        Me.Panel114.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel114.Controls.Add(Me.Label45)
        Me.Panel114.Location = New System.Drawing.Point(617, 0)
        Me.Panel114.Name = "Panel114"
        Me.Panel114.Size = New System.Drawing.Size(87, 40)
        Me.Panel114.TabIndex = 21
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(29, 12)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(28, 16)
        Me.Label45.TabIndex = 13
        Me.Label45.Text = "2"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel115
        '
        Me.Panel115.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel115.Controls.Add(Me.TextBox44)
        Me.Panel115.Location = New System.Drawing.Point(705, 113)
        Me.Panel115.Name = "Panel115"
        Me.Panel115.Size = New System.Drawing.Size(87, 71)
        Me.Panel115.TabIndex = 18
        '
        'TextBox44
        '
        Me.TextBox44.Location = New System.Drawing.Point(15, 25)
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.ReadOnly = True
        Me.TextBox44.Size = New System.Drawing.Size(56, 20)
        Me.TextBox44.TabIndex = 15
        '
        'Panel116
        '
        Me.Panel116.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel116.Controls.Add(Me.TextBox45)
        Me.Panel116.Location = New System.Drawing.Point(705, 41)
        Me.Panel116.Name = "Panel116"
        Me.Panel116.Size = New System.Drawing.Size(87, 71)
        Me.Panel116.TabIndex = 18
        '
        'TextBox45
        '
        Me.TextBox45.Location = New System.Drawing.Point(15, 25)
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Size = New System.Drawing.Size(56, 20)
        Me.TextBox45.TabIndex = 15
        '
        'Panel117
        '
        Me.Panel117.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel117.Controls.Add(Me.Label46)
        Me.Panel117.Location = New System.Drawing.Point(705, 0)
        Me.Panel117.Name = "Panel117"
        Me.Panel117.Size = New System.Drawing.Size(87, 40)
        Me.Panel117.TabIndex = 21
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(29, 12)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(28, 16)
        Me.Label46.TabIndex = 13
        Me.Label46.Text = "2"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel118
        '
        Me.Panel118.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel118.Controls.Add(Me.TextBox46)
        Me.Panel118.Location = New System.Drawing.Point(793, 113)
        Me.Panel118.Name = "Panel118"
        Me.Panel118.Size = New System.Drawing.Size(87, 71)
        Me.Panel118.TabIndex = 18
        '
        'TextBox46
        '
        Me.TextBox46.Location = New System.Drawing.Point(15, 25)
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.ReadOnly = True
        Me.TextBox46.Size = New System.Drawing.Size(56, 20)
        Me.TextBox46.TabIndex = 15
        '
        'Panel119
        '
        Me.Panel119.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel119.Controls.Add(Me.Label47)
        Me.Panel119.Location = New System.Drawing.Point(793, 0)
        Me.Panel119.Name = "Panel119"
        Me.Panel119.Size = New System.Drawing.Size(87, 40)
        Me.Panel119.TabIndex = 21
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label47.Location = New System.Drawing.Point(29, 12)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(28, 16)
        Me.Label47.TabIndex = 13
        Me.Label47.Text = "2"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel120
        '
        Me.Panel120.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel120.Controls.Add(Me.TextBox47)
        Me.Panel120.Location = New System.Drawing.Point(793, 41)
        Me.Panel120.Name = "Panel120"
        Me.Panel120.Size = New System.Drawing.Size(87, 71)
        Me.Panel120.TabIndex = 18
        '
        'TextBox47
        '
        Me.TextBox47.Location = New System.Drawing.Point(15, 25)
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New System.Drawing.Size(56, 20)
        Me.TextBox47.TabIndex = 15
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(136, 8)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(56, 20)
        Me.TextBox12.TabIndex = 21
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(8, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 16)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "Nombre de buses : "
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TextBox13
        '
        Me.TextBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(592, 16)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(56, 20)
        Me.TextBox13.TabIndex = 22
        '
        'TextBox14
        '
        Me.TextBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox14.Location = New System.Drawing.Point(368, 16)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(56, 20)
        Me.TextBox14.TabIndex = 20
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(432, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(152, 16)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "Ecart toléré (10 ou 15 %) :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(208, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(152, 16)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Débit nominal constructeur :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'validerNbBuses
        '
        Me.validerNbBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.validerNbBuses.ForeColor = System.Drawing.Color.White
        Me.validerNbBuses.Image = CType(resources.GetObject("validerNbBuses.Image"), System.Drawing.Image)
        Me.validerNbBuses.Location = New System.Drawing.Point(40, 32)
        Me.validerNbBuses.Name = "validerNbBuses"
        Me.validerNbBuses.Size = New System.Drawing.Size(128, 24)
        Me.validerNbBuses.TabIndex = 26
        Me.validerNbBuses.Text = "    Valider"
        Me.validerNbBuses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox48
        '
        Me.TextBox48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox48.Location = New System.Drawing.Point(368, 40)
        Me.TextBox48.Name = "TextBox48"
        Me.TextBox48.ReadOnly = True
        Me.TextBox48.Size = New System.Drawing.Size(56, 20)
        Me.TextBox48.TabIndex = 20
        '
        'Label48
        '
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label48.Location = New System.Drawing.Point(208, 40)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(152, 16)
        Me.Label48.TabIndex = 17
        Me.Label48.Text = "Débit nominal pour calcul * :"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label49.Location = New System.Drawing.Point(432, 40)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(152, 16)
        Me.Label49.TabIndex = 16
        Me.Label49.Text = "Pression de mesure (bar) :"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TextBox49
        '
        Me.TextBox49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox49.Location = New System.Drawing.Point(592, 40)
        Me.TextBox49.Name = "TextBox49"
        Me.TextBox49.Size = New System.Drawing.Size(56, 20)
        Me.TextBox49.TabIndex = 22
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(912, 288)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(56, 20)
        Me.TextBox11.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(752, 288)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 16)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Usure moyenne des buses :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TextBox50
        '
        Me.TextBox50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox50.Location = New System.Drawing.Point(184, 288)
        Me.TextBox50.Name = "TextBox50"
        Me.TextBox50.ReadOnly = True
        Me.TextBox50.Size = New System.Drawing.Size(56, 20)
        Me.TextBox50.TabIndex = 20
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label50.Location = New System.Drawing.Point(96, 288)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(80, 16)
        Me.Label50.TabIndex = 17
        Me.Label50.Text = "Débit moyen :"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TextBox51
        '
        Me.TextBox51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox51.Location = New System.Drawing.Point(680, 288)
        Me.TextBox51.Name = "TextBox51"
        Me.TextBox51.ReadOnly = True
        Me.TextBox51.Size = New System.Drawing.Size(56, 20)
        Me.TextBox51.TabIndex = 20
        '
        'Label51
        '
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label51.Location = New System.Drawing.Point(576, 288)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(96, 16)
        Me.Label51.TabIndex = 17
        Me.Label51.Text = "Nb buses usées :"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label216
        '
        Me.Label216.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label216.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label216.Location = New System.Drawing.Point(656, 16)
        Me.Label216.Name = "Label216"
        Me.Label216.Size = New System.Drawing.Size(56, 16)
        Me.Label216.TabIndex = 16
        Me.Label216.Text = "Marque :"
        Me.Label216.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label217
        '
        Me.Label217.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label217.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label217.Location = New System.Drawing.Point(656, 40)
        Me.Label217.Name = "Label217"
        Me.Label217.Size = New System.Drawing.Size(56, 16)
        Me.Label217.TabIndex = 16
        Me.Label217.Text = "Genre :"
        Me.Label217.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Location = New System.Drawing.Point(712, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(96, 21)
        Me.ComboBox1.TabIndex = 28
        '
        'Label218
        '
        Me.Label218.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label218.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label218.Location = New System.Drawing.Point(824, 16)
        Me.Label218.Name = "Label218"
        Me.Label218.Size = New System.Drawing.Size(56, 16)
        Me.Label218.TabIndex = 16
        Me.Label218.Text = "Couleur :"
        Me.Label218.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label219
        '
        Me.Label219.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label219.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label219.Location = New System.Drawing.Point(824, 40)
        Me.Label219.Name = "Label219"
        Me.Label219.Size = New System.Drawing.Size(56, 16)
        Me.Label219.TabIndex = 16
        Me.Label219.Text = "Calibre :"
        Me.Label219.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Location = New System.Drawing.Point(880, 16)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(96, 21)
        Me.ComboBox2.TabIndex = 28
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Location = New System.Drawing.Point(880, 40)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(96, 21)
        Me.ComboBox3.TabIndex = 28
        '
        'diagBuses_conf_nbCategories
        '
        Me.diagBuses_conf_nbCategories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_conf_nbCategories.Location = New System.Drawing.Point(200, 8)
        Me.diagBuses_conf_nbCategories.Name = "diagBuses_conf_nbCategories"
        Me.diagBuses_conf_nbCategories.Size = New System.Drawing.Size(100, 20)
        Me.diagBuses_conf_nbCategories.TabIndex = 1
        Me.diagBuses_conf_nbCategories.Text = "1"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(16, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(184, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Nombre de niveaux de buses :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_conf_validNbCategories
        '
        Me.diagBuses_conf_validNbCategories.Cursor = System.Windows.Forms.Cursors.Hand
        Me.diagBuses_conf_validNbCategories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_conf_validNbCategories.ForeColor = System.Drawing.Color.White
        Me.diagBuses_conf_validNbCategories.Image = CType(resources.GetObject("diagBuses_conf_validNbCategories.Image"), System.Drawing.Image)
        Me.diagBuses_conf_validNbCategories.Location = New System.Drawing.Point(304, 8)
        Me.diagBuses_conf_validNbCategories.Name = "diagBuses_conf_validNbCategories"
        Me.diagBuses_conf_validNbCategories.Size = New System.Drawing.Size(128, 24)
        Me.diagBuses_conf_validNbCategories.TabIndex = 26
        Me.diagBuses_conf_validNbCategories.Text = "    Valider"
        Me.diagBuses_conf_validNbCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label52.Location = New System.Drawing.Point(656, 408)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(168, 16)
        Me.Label52.TabIndex = 17
        Me.Label52.Text = "Résultat du jeu de buse : "
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_nbBusesUsees
        '
        Me.diagBuses_nbBusesUsees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_nbBusesUsees.Location = New System.Drawing.Point(344, 408)
        Me.diagBuses_nbBusesUsees.Name = "diagBuses_nbBusesUsees"
        Me.diagBuses_nbBusesUsees.ReadOnly = True
        Me.diagBuses_nbBusesUsees.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_nbBusesUsees.TabIndex = 20
        '
        'Label213
        '
        Me.Label213.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label213.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label213.Location = New System.Drawing.Point(240, 408)
        Me.Label213.Name = "Label213"
        Me.Label213.Size = New System.Drawing.Size(96, 16)
        Me.Label213.TabIndex = 17
        Me.Label213.Text = "Nb buses usées :"
        Me.Label213.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_usureMoyBuses
        '
        Me.diagBuses_usureMoyBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_usureMoyBuses.Location = New System.Drawing.Point(576, 408)
        Me.diagBuses_usureMoyBuses.Name = "diagBuses_usureMoyBuses"
        Me.diagBuses_usureMoyBuses.ReadOnly = True
        Me.diagBuses_usureMoyBuses.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_usureMoyBuses.TabIndex = 20
        '
        'Label214
        '
        Me.Label214.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label214.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label214.Location = New System.Drawing.Point(416, 408)
        Me.Label214.Name = "Label214"
        Me.Label214.Size = New System.Drawing.Size(152, 16)
        Me.Label214.TabIndex = 17
        Me.Label214.Text = "Usure moyenne des buses :"
        Me.Label214.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label215
        '
        Me.Label215.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label215.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label215.Location = New System.Drawing.Point(16, 408)
        Me.Label215.Name = "Label215"
        Me.Label215.Size = New System.Drawing.Size(144, 16)
        Me.Label215.TabIndex = 17
        Me.Label215.Text = "Débit moyen à 0,0bar :"
        Me.Label215.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagBuses_debitMoyen
        '
        Me.diagBuses_debitMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_debitMoyen.Location = New System.Drawing.Point(168, 408)
        Me.diagBuses_debitMoyen.Name = "diagBuses_debitMoyen"
        Me.diagBuses_debitMoyen.ReadOnly = True
        Me.diagBuses_debitMoyen.Size = New System.Drawing.Size(56, 20)
        Me.diagBuses_debitMoyen.TabIndex = 20
        '
        'diagBuses_resultat
        '
        Me.diagBuses_resultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagBuses_resultat.ForeColor = System.Drawing.Color.Red
        Me.diagBuses_resultat.Location = New System.Drawing.Point(832, 408)
        Me.diagBuses_resultat.Name = "diagBuses_resultat"
        Me.diagBuses_resultat.Size = New System.Drawing.Size(168, 16)
        Me.diagBuses_resultat.TabIndex = 27
        Me.diagBuses_resultat.Text = "USURE GLOBALE"
        Me.diagBuses_resultat.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label55
        '
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label55.Location = New System.Drawing.Point(832, 408)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(168, 16)
        Me.Label55.TabIndex = 27
        Me.Label55.Text = "OK"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label53
        '
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label53.Location = New System.Drawing.Point(832, 408)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(168, 16)
        Me.Label53.TabIndex = 17
        Me.Label53.Text = "USURE PARTIELLE"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btn_diagnostic_acquisitionDonnees
        '
        Me.btn_diagnostic_acquisitionDonnees.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_diagnostic_acquisitionDonnees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_diagnostic_acquisitionDonnees.ForeColor = System.Drawing.Color.White
        Me.btn_diagnostic_acquisitionDonnees.Image = CType(resources.GetObject("btn_diagnostic_acquisitionDonnees.Image"), System.Drawing.Image)
        Me.btn_diagnostic_acquisitionDonnees.Location = New System.Drawing.Point(808, 16)
        Me.btn_diagnostic_acquisitionDonnees.Name = "btn_diagnostic_acquisitionDonnees"
        Me.btn_diagnostic_acquisitionDonnees.Size = New System.Drawing.Size(180, 24)
        Me.btn_diagnostic_acquisitionDonnees.TabIndex = 27
        Me.btn_diagnostic_acquisitionDonnees.Text = "       Acquisition de données"
        Me.btn_diagnostic_acquisitionDonnees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label76
        '
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label76.Location = New System.Drawing.Point(48, 16)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(152, 16)
        Me.Label76.TabIndex = 6
        Me.Label76.Text = "Sélection du manomètre : "
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'buses_listManoControle
        '
        Me.buses_listManoControle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.buses_listManoControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buses_listManoControle.Location = New System.Drawing.Point(208, 16)
        Me.buses_listManoControle.Name = "buses_listManoControle"
        Me.buses_listManoControle.Size = New System.Drawing.Size(232, 21)
        Me.buses_listManoControle.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "     Contrôle jeu de buses supplémentaire"
        '
        'tool_diagBuses
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.Controls.Add(Me.Panel64)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "tool_diagBuses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "tool_calcVolHa"
        Me.Panel64.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.diagBuses_tab_categories.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel65.ResumeLayout(False)
        Me.Panel68.ResumeLayout(False)
        Me.Panel70.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel69.ResumeLayout(False)
        Me.Panel69.PerformLayout()
        Me.Panel71.ResumeLayout(False)
        Me.Panel71.PerformLayout()
        Me.Panel38.ResumeLayout(False)
        Me.Panel38.PerformLayout()
        Me.Panel49.ResumeLayout(False)
        Me.Panel49.PerformLayout()
        Me.Panel66.ResumeLayout(False)
        Me.Panel67.ResumeLayout(False)
        Me.Panel97.ResumeLayout(False)
        Me.Panel97.PerformLayout()
        Me.Panel98.ResumeLayout(False)
        Me.Panel98.PerformLayout()
        Me.Panel99.ResumeLayout(False)
        Me.Panel100.ResumeLayout(False)
        Me.Panel100.PerformLayout()
        Me.Panel101.ResumeLayout(False)
        Me.Panel101.PerformLayout()
        Me.Panel102.ResumeLayout(False)
        Me.Panel103.ResumeLayout(False)
        Me.Panel103.PerformLayout()
        Me.Panel104.ResumeLayout(False)
        Me.Panel104.PerformLayout()
        Me.Panel105.ResumeLayout(False)
        Me.Panel106.ResumeLayout(False)
        Me.Panel107.ResumeLayout(False)
        Me.Panel107.PerformLayout()
        Me.Panel108.ResumeLayout(False)
        Me.Panel108.PerformLayout()
        Me.Panel109.ResumeLayout(False)
        Me.Panel109.PerformLayout()
        Me.Panel110.ResumeLayout(False)
        Me.Panel111.ResumeLayout(False)
        Me.Panel111.PerformLayout()
        Me.Panel112.ResumeLayout(False)
        Me.Panel112.PerformLayout()
        Me.Panel113.ResumeLayout(False)
        Me.Panel113.PerformLayout()
        Me.Panel114.ResumeLayout(False)
        Me.Panel115.ResumeLayout(False)
        Me.Panel115.PerformLayout()
        Me.Panel116.ResumeLayout(False)
        Me.Panel116.PerformLayout()
        Me.Panel117.ResumeLayout(False)
        Me.Panel118.ResumeLayout(False)
        Me.Panel118.PerformLayout()
        Me.Panel119.ResumeLayout(False)
        Me.Panel120.ResumeLayout(False)
        Me.Panel120.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private m_oRefBuses As New ReferentielBusesCSV()

    ' Chargement de l'outil
    Private Sub tool_diagBuses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_oRefBuses.load()
        ' On vide les onglets
        diagBuses_tab_categories.TabPages.Clear()
        ' On charge les mano de contrôle de la strcuture
        Dim arrManoControle As List(Of ManometreControle) = ManometreControleManager.getlstByAgent(agentCourant, False)
        Dim positionTop As Integer = 0
        For Each tmpManoControle As ManometreControle In arrManoControle
            Dim objComboItem As New objComboItem(tmpManoControle.numeroNational, tmpManoControle.idCrodip & " - " & tmpManoControle.type & " (" & tmpManoControle.marque & ")")
            buses_listManoControle.Items.Add(objComboItem)
        Next
    End Sub

    ' Module d'acquisition des données
    Private Sub btn_diagnostic_acquisitionDonnees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_diagnostic_acquisitionDonnees.Click
        doAcqiring()
    End Sub


#Region " Events "

    ' Validation du nombre de niveaux de buses
    Private Sub diagBuses_conf_validNbCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diagBuses_conf_validNbCategories.Click
        Try

            ' Récupération des variables
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmDiagnostique))
            Dim tabCategories As TabControl = diagBuses_tab_categories
            tabCategories.TabPages.Clear()
            Dim nbCategories As Integer = diagBuses_conf_nbCategories.Text

            ' On ajoute les onglets
            Dim nbCatMax As Integer = 50
            If nbCategories > nbCatMax Then
                nbCategories = nbCatMax
            End If
            For i As Integer = 1 To nbCategories

                ' On créé un nouvel onglet pour notre tabControl
                Dim ongletCategorie As New TabPage
                ongletCategorie.Text = "Niveau n°" & i
                ongletCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                tabCategories.TabPages.Add(ongletCategorie)

                '
                'Label "Nombre de buses"
                '
                Dim label_nbBuses As New Label
                Controls.Add(label_nbBuses)
                label_nbBuses.Parent = ongletCategorie
                label_nbBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_nbBuses.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_nbBuses.Location = New System.Drawing.Point(8, 8)
                label_nbBuses.Name = "label_nbBuses_" & i
                label_nbBuses.Size = New System.Drawing.Size(120, 16)
                label_nbBuses.Text = "Nombre de buses : "
                label_nbBuses.TextAlign = System.Drawing.ContentAlignment.BottomRight
                '
                'TextBox "Nombre de buses"
                '
                Dim TextBox_nbBuses As New TextBox
                Controls.Add(TextBox_nbBuses)
                TextBox_nbBuses.Parent = ongletCategorie
                TextBox_nbBuses.Location = New System.Drawing.Point(136, 8)
                TextBox_nbBuses.Name = "TextBox_nbBuses_" & i
                TextBox_nbBuses.Size = New System.Drawing.Size(56, 20)
                TextBox_nbBuses.Text = ""
                '
                'Button "Valider"
                '
                Dim Button_valider_nbBuses As New Label
                Controls.Add(Button_valider_nbBuses)
                Button_valider_nbBuses.Parent = ongletCategorie
                Button_valider_nbBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Button_valider_nbBuses.ForeColor = System.Drawing.Color.White
                Button_valider_nbBuses.Image = CType(resources.GetObject("validerNbBuses.Image"), System.Drawing.Image)
                Button_valider_nbBuses.Location = New System.Drawing.Point(40, 32)
                Button_valider_nbBuses.Name = "Button_valider_nbBuses_" & i
                Button_valider_nbBuses.Size = New System.Drawing.Size(128, 24)
                Button_valider_nbBuses.Text = "    Valider"
                Button_valider_nbBuses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                AddHandler Button_valider_nbBuses.Click, AddressOf validerNbBuses_Click

                'Débit nominal constructeur
                Dim label_DebitNominalCONSTructeur As New Label
                Controls.Add(label_DebitNominalCONSTructeur)
                label_DebitNominalCONSTructeur.Parent = ongletCategorie
                label_DebitNominalCONSTructeur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_DebitNominalCONSTructeur.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_DebitNominalCONSTructeur.Location = New System.Drawing.Point(208, 16)
                label_DebitNominalCONSTructeur.Name = "label_DebitNominalCONSTructeur_" & i
                label_DebitNominalCONSTructeur.Size = New System.Drawing.Size(152, 16)
                label_DebitNominalCONSTructeur.Text = "Débit nominal constructeur :"
                label_DebitNominalCONSTructeur.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim TextBox_debitNominalCONSTructeur As New TextBox
                Controls.Add(TextBox_debitNominalCONSTructeur)
                TextBox_debitNominalCONSTructeur.Parent = ongletCategorie
                TextBox_debitNominalCONSTructeur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                TextBox_debitNominalCONSTructeur.Location = New System.Drawing.Point(368, 16)
                TextBox_debitNominalCONSTructeur.Name = "TextBox_debitNominalCONSTructeur_" & i
                TextBox_debitNominalCONSTructeur.Size = New System.Drawing.Size(56, 20)
                TextBox_debitNominalCONSTructeur.Text = ""
                AddHandler TextBox_debitNominalCONSTructeur.TextChanged, AddressOf DebitNominalCONSTructeur_TextChanged
                AddHandler TextBox_debitNominalCONSTructeur.KeyPress, AddressOf diagBuses_KeyPress

                'Débit nominal pour calcul *
                Dim label_debitNominal As New Label
                Controls.Add(label_debitNominal)
                label_debitNominal.Parent = ongletCategorie
                label_debitNominal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_debitNominal.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_debitNominal.Location = New System.Drawing.Point(208, 40)
                label_debitNominal.Name = "label_debitNominal_" & i
                label_debitNominal.Size = New System.Drawing.Size(152, 16)
                label_debitNominal.Text = "Débit nominal pour calcul * :"
                label_debitNominal.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim TextBox_debitNominal As New TextBox
                Controls.Add(TextBox_debitNominal)
                TextBox_debitNominal.Parent = ongletCategorie
                TextBox_debitNominal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                TextBox_debitNominal.Location = New System.Drawing.Point(368, 40)
                TextBox_debitNominal.Name = "TextBox_debitNominal_" & i
                TextBox_debitNominal.Size = New System.Drawing.Size(56, 20)
                TextBox_debitNominal.Text = ""
                TextBox_debitNominal.ReadOnly = True

                'Ecart toléré (10 ou 15 %)
                Dim label_ecartTolere As New Label
                Controls.Add(label_ecartTolere)
                label_ecartTolere.Parent = ongletCategorie
                label_ecartTolere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_ecartTolere.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_ecartTolere.Location = New System.Drawing.Point(432, 16)
                label_ecartTolere.Name = "label_ecartTolere_" & i
                label_ecartTolere.Size = New System.Drawing.Size(152, 16)
                label_ecartTolere.Text = "Ecart toléré (10 ou 15 %) :"
                label_ecartTolere.TextAlign = System.Drawing.ContentAlignment.BottomRight

                'Dim TextBox_ecartTolere As New TextBox
                'Controls.Add(TextBox_ecartTolere)
                'TextBox_ecartTolere.Parent = ongletCategorie
                'TextBox_ecartTolere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'TextBox_ecartTolere.Location = New System.Drawing.Point(592, 16)
                'TextBox_ecartTolere.Name = "TextBox_ecartTolere_" & i
                'TextBox_ecartTolere.Size = New System.Drawing.Size(56, 20)
                'TextBox_ecartTolere.Text = ""
                'AddHandler TextBox_ecartTolere.TextChanged, AddressOf ecartTolere_TextChanged

                Dim TextBox_ecartTolere As New ComboBox
                Controls.Add(TextBox_ecartTolere)
                TextBox_ecartTolere.Parent = ongletCategorie
                TextBox_ecartTolere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                TextBox_ecartTolere.Location = New System.Drawing.Point(592, 16)
                TextBox_ecartTolere.Name = "TextBox_ecartTolere_" & i
                TextBox_ecartTolere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                TextBox_ecartTolere.Items.AddRange(New Object() {"10", "15"})
                TextBox_ecartTolere.Size = New System.Drawing.Size(56, 21)
                TextBox_ecartTolere.Text = ""
                AddHandler TextBox_ecartTolere.TextChanged, AddressOf ecartTolere_SelectedIndexChanged


                'Pression de mesure (bar)
                'Dim label_pressionMesure As New Label
                'Controls.Add(label_pressionMesure)
                'label_pressionMesure.Parent = ongletCategorie
                'label_pressionMesure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'label_pressionMesure.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                'label_pressionMesure.Location = New System.Drawing.Point(432, 40)
                'label_pressionMesure.Name = "label_pressionMesure_" & i
                'label_pressionMesure.Size = New System.Drawing.Size(152, 16)
                'label_pressionMesure.Text = "Pression de mesure (bar) :"
                'label_pressionMesure.TextAlign = System.Drawing.ContentAlignment.BottomRight

                'Dim TextBox_pressionMesure As New TextBox
                'Controls.Add(TextBox_pressionMesure)
                'TextBox_pressionMesure.Parent = ongletCategorie
                'TextBox_pressionMesure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'TextBox_pressionMesure.Location = New System.Drawing.Point(592, 40)
                'TextBox_pressionMesure.Name = "TextBox_pressionMesure_" & i
                'TextBox_pressionMesure.Size = New System.Drawing.Size(56, 20)
                'TextBox_pressionMesure.TabIndex = 22
                'TextBox_pressionMesure.Text = ""

                'Marque
                Dim label_marque As New Label
                label_marque.Name = "label_marque_" & i
                Controls.Add(label_marque)
                label_marque.Parent = ongletCategorie
                label_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_marque.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_marque.Location = New System.Drawing.Point(656, 16)
                label_marque.Size = New System.Drawing.Size(56, 16)
                label_marque.Text = "Marque :"
                label_marque.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim ComboBox_marque As New ComboBox
                Controls.Add(ComboBox_marque)
                ComboBox_marque.Parent = ongletCategorie
                ComboBox_marque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                ComboBox_marque.Location = New System.Drawing.Point(712, 16)
                ComboBox_marque.Name = "ComboBox_marque_" & i
                ComboBox_marque.Size = New System.Drawing.Size(96, 21)
                AddHandler ComboBox_marque.SelectedIndexChanged, AddressOf changeMarqueBuseSelected


                'Genre
                Dim label_genre As New Label
                label_genre.Name = "label_genre_" & i
                Controls.Add(label_genre)
                label_genre.Parent = ongletCategorie
                label_genre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_genre.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_genre.Location = New System.Drawing.Point(656, 40)
                label_genre.Size = New System.Drawing.Size(56, 16)
                label_genre.Text = "Genre :"
                label_genre.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim ComboBox_genre As New ComboBox
                Controls.Add(ComboBox_genre)
                ComboBox_genre.Parent = ongletCategorie
                ComboBox_genre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                ComboBox_genre.Location = New System.Drawing.Point(712, 40)
                ComboBox_genre.Name = "ComboBox_genre_" & i
                ComboBox_genre.Size = New System.Drawing.Size(96, 21)


                'Couleur
                Dim label_couleur As New Label
                label_couleur.Name = "label_couleur_" & i
                Controls.Add(label_couleur)
                label_couleur.Parent = ongletCategorie
                label_couleur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_couleur.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_couleur.Location = New System.Drawing.Point(824, 16)
                label_couleur.Size = New System.Drawing.Size(56, 16)
                label_couleur.Text = "Couleur :"
                label_couleur.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim ComboBox_couleur As New ComboBox
                Controls.Add(ComboBox_couleur)
                ComboBox_couleur.Parent = ongletCategorie
                ComboBox_couleur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                ComboBox_couleur.Location = New System.Drawing.Point(880, 16)
                ComboBox_couleur.Name = "ComboBox_couleur_" & i
                ComboBox_couleur.Size = New System.Drawing.Size(96, 21)


                'Calibre
                Dim label_calibre As New Label
                label_calibre.Name = "label_calibre_" & i
                Controls.Add(label_calibre)
                label_calibre.Parent = ongletCategorie
                label_calibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_calibre.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_calibre.Location = New System.Drawing.Point(824, 40)
                label_calibre.Size = New System.Drawing.Size(56, 16)
                label_calibre.Text = "Calibre :"
                label_calibre.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim ComboBox_calibre As New TextBox
                Controls.Add(ComboBox_calibre)
                ComboBox_calibre.Parent = ongletCategorie
                'ComboBox_calibre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                ComboBox_calibre.Location = New System.Drawing.Point(880, 40)
                ComboBox_calibre.Name = "ComboBox_calibre_" & i
                ComboBox_calibre.Size = New System.Drawing.Size(96, 21)



                'Débit moyen
                Dim label_debitMoyen As New Label
                Controls.Add(label_debitMoyen)
                label_debitMoyen.Parent = ongletCategorie
                label_debitMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_debitMoyen.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_debitMoyen.Location = New System.Drawing.Point(96, 288)
                label_debitMoyen.Name = "label_debitMoyen_" & i
                label_debitMoyen.Size = New System.Drawing.Size(80, 16)
                label_debitMoyen.Text = "Débit moyen :"
                label_debitMoyen.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim TextBox_debitMoyen As New TextBox
                Controls.Add(TextBox_debitMoyen)
                TextBox_debitMoyen.Parent = ongletCategorie
                TextBox_debitMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                TextBox_debitMoyen.Location = New System.Drawing.Point(184, 288)
                TextBox_debitMoyen.Name = "TextBox_debitMoyen_" & i
                TextBox_debitMoyen.ReadOnly = True
                TextBox_debitMoyen.Size = New System.Drawing.Size(56, 20)
                TextBox_debitMoyen.Text = ""



                'Nb buses usées
                Dim label_nbBusesUsees As New Label
                Controls.Add(label_nbBusesUsees)
                label_nbBusesUsees.Parent = ongletCategorie
                label_nbBusesUsees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_nbBusesUsees.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_nbBusesUsees.Location = New System.Drawing.Point(576, 288)
                label_nbBusesUsees.Name = "label_nbBusesUsees_" & i
                label_nbBusesUsees.Size = New System.Drawing.Size(96, 16)
                label_nbBusesUsees.Text = "Nb buses usées :"
                label_nbBusesUsees.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim TextBox_nbBusesUsees As New TextBox
                Controls.Add(TextBox_nbBusesUsees)
                TextBox_nbBusesUsees.Parent = ongletCategorie
                TextBox_nbBusesUsees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                TextBox_nbBusesUsees.Location = New System.Drawing.Point(680, 288)
                TextBox_nbBusesUsees.Name = "TextBox_nbBusesUsees_" & i
                TextBox_nbBusesUsees.ReadOnly = True
                TextBox_nbBusesUsees.Size = New System.Drawing.Size(56, 20)
                TextBox_nbBusesUsees.Text = ""



                'Usure moyenne des buses
                Dim label_usureMoyenneBuses As New Label
                Controls.Add(label_usureMoyenneBuses)
                label_usureMoyenneBuses.Parent = ongletCategorie
                label_usureMoyenneBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_usureMoyenneBuses.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_usureMoyenneBuses.Location = New System.Drawing.Point(752, 288)
                label_usureMoyenneBuses.Name = "label_usureMoyenneBuses_" & i
                label_usureMoyenneBuses.Size = New System.Drawing.Size(152, 16)
                label_usureMoyenneBuses.Text = "Usure moyenne des buses :"
                label_usureMoyenneBuses.TextAlign = System.Drawing.ContentAlignment.BottomRight

                Dim TextBox_usureMoyenneBuses As New TextBox
                Controls.Add(TextBox_usureMoyenneBuses)
                TextBox_usureMoyenneBuses.Parent = ongletCategorie
                TextBox_usureMoyenneBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                TextBox_usureMoyenneBuses.Location = New System.Drawing.Point(912, 288)
                TextBox_usureMoyenneBuses.Name = "TextBox_usureMoyenneBuses_" & i
                TextBox_usureMoyenneBuses.ReadOnly = True
                TextBox_usureMoyenneBuses.Size = New System.Drawing.Size(56, 20)
                TextBox_usureMoyenneBuses.Text = ""

                '
                'Panel principal liste des buses
                '
                Dim Panel_listePrincipale As New Panel
                Controls.Add(Panel_listePrincipale)
                Panel_listePrincipale.Parent = ongletCategorie
                Panel_listePrincipale.AutoScroll = True
                Panel_listePrincipale.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(123, Byte), CType(191, Byte))
                Panel_listePrincipale.Location = New System.Drawing.Point(16, 72)
                Panel_listePrincipale.Name = "Panel_listePrincipale_" & i
                Panel_listePrincipale.Size = New System.Drawing.Size(952, 184)
                '
                'Panel titre : "N°"
                '
                Dim Panel_titreNum As New Panel
                Controls.Add(Panel_titreNum)
                Panel_titreNum.Parent = Panel_listePrincipale
                Panel_titreNum.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
                Panel_titreNum.Location = New System.Drawing.Point(0, 0)
                Panel_titreNum.Name = "Panel_titreNum_" & i
                Panel_titreNum.Size = New System.Drawing.Size(72, 40)
                '
                'Label titre : "N°"
                '
                Dim label_titreNum As New Label
                Controls.Add(label_titreNum)
                label_titreNum.Parent = Panel_titreNum
                label_titreNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_titreNum.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_titreNum.Location = New System.Drawing.Point(16, 12)
                label_titreNum.Name = "label_titreNum_" & i
                label_titreNum.Size = New System.Drawing.Size(40, 16)
                label_titreNum.Text = "N°"
                label_titreNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

                '
                'Panel titre : "Débit"
                '
                Dim Panel_titreDebit As New Panel
                Controls.Add(Panel_titreDebit)
                Panel_titreDebit.Parent = Panel_listePrincipale
                Panel_titreDebit.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
                Panel_titreDebit.Location = New System.Drawing.Point(0, 41)
                Panel_titreDebit.Name = "Panel_titreDebit_" & i
                Panel_titreDebit.Size = New System.Drawing.Size(72, 71)
                '
                'Label titre : "Débit"
                '
                Dim label_titreDebit As New Label
                Controls.Add(label_titreDebit)
                label_titreDebit.Parent = Panel_titreDebit
                label_titreDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_titreDebit.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_titreDebit.Location = New System.Drawing.Point(8, 27)
                label_titreDebit.Name = "label_titreDebit_" & i
                label_titreDebit.Size = New System.Drawing.Size(56, 16)
                label_titreDebit.Text = "Débit"
                label_titreDebit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

                '
                'Panel titre : "Usure"
                '
                Dim Panel_titreUsure As New Panel
                Controls.Add(Panel_titreUsure)
                Panel_titreUsure.Parent = Panel_listePrincipale
                Panel_titreUsure.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
                Panel_titreUsure.Location = New System.Drawing.Point(0, 113)
                Panel_titreUsure.Name = "Panel_titreUsure_" & i
                Panel_titreUsure.Size = New System.Drawing.Size(72, 71)
                '
                'Label titre : "Usure"
                '
                Dim label_titreUsure As New Label
                Controls.Add(label_titreUsure)
                label_titreUsure.Parent = Panel_titreUsure
                label_titreUsure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                label_titreUsure.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                label_titreUsure.Location = New System.Drawing.Point(4, 27)
                label_titreUsure.Name = "label_titreUsure_" & i
                label_titreUsure.Size = New System.Drawing.Size(64, 16)
                label_titreUsure.Text = "Usure (%)"
                label_titreUsure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

                '
                'Panel secondaire liste des buses
                '
                Dim Panel_listeSecondaire As New Panel
                Controls.Add(Panel_listeSecondaire)
                Panel_listeSecondaire.Parent = Panel_listePrincipale
                Panel_listeSecondaire.AutoScroll = True
                Panel_listeSecondaire.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(123, Byte), CType(191, Byte))
                Panel_listeSecondaire.Location = New System.Drawing.Point(72, 0)
                Panel_listeSecondaire.Name = "Panel_listeSecondaire_" & i
                Panel_listeSecondaire.Size = New System.Drawing.Size(880, 184)

                ' On charge les infos dans les combo
                loadReferentielBuses(i)

            Next

        Catch ex As Exception
            CSDebug.dispError("diagnostic::validNbCategories : " & ex.Message)
        End Try
    End Sub

    ' Valide le nombre de buses dans un niveau
    Private Sub validerNbBuses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' On récupère le numéro du lot
        Dim lotId As Integer = CType(sender.Name.ToString.Replace("Button_valider_nbBuses_", ""), Integer)
        ' On récupère le nombre de buses pour ce lot
        Dim input_nbBuses As TextBox = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
        If input_nbBuses.Text = "" Then
            MsgBox("Vous devez saisir un nombre valide !")
            Exit Sub
        End If
        Dim nbBuses As Integer = CType(input_nbBuses.Text, Integer)
        If nbBuses > 100 Then
            nbBuses = 100
        End If
        ' On récupère le panel de la liste des buses
        Dim Panel_listeSecondaire As Panel = CSForm.getControlByName("Panel_listeSecondaire_" & lotId, diagBuses_tab_categories)
        ' On ajoute dynamiquement les controles pour la saisie des buses
        Dim positionY As Integer = 1
        For x As Integer = 1 To nbBuses

            If x = 1 Then
                positionY = 1
            Else
                positionY = positionY + 88
            End If

            '
            'Panel value : "Numéro de buse"
            '
            Dim Panel_valueNumBuse As New Panel
            Controls.Add(Panel_valueNumBuse)
            Panel_valueNumBuse.Parent = Panel_listeSecondaire
            Panel_valueNumBuse.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            Panel_valueNumBuse.Location = New System.Drawing.Point(positionY, 0)
            Panel_valueNumBuse.Name = "Panel_valueNumBuse_" & lotId & "_" & x
            Panel_valueNumBuse.Size = New System.Drawing.Size(87, 40)
            '
            'Panel value : "Débit"
            '
            Dim Panel_valueDebit As New Panel
            Controls.Add(Panel_valueDebit)
            Panel_valueDebit.Parent = Panel_listeSecondaire
            Panel_valueDebit.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            Panel_valueDebit.Location = New System.Drawing.Point(positionY, 41)
            Panel_valueDebit.Name = "Panel_valueDebit_" & lotId & "_" & x
            Panel_valueDebit.Size = New System.Drawing.Size(87, 71)
            '
            'Panel value : "Usure"
            '
            Dim Panel_valueUsure As New Panel
            Controls.Add(Panel_valueUsure)
            Panel_valueUsure.Parent = Panel_listeSecondaire
            Panel_valueUsure.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            Panel_valueUsure.Location = New System.Drawing.Point(positionY, 113)
            Panel_valueUsure.Name = "Panel_valueUsure_" & lotId & "_" & x
            Panel_valueUsure.Size = New System.Drawing.Size(87, 71)

            '
            'Label value : "Numéro de buse"
            '
            Dim label_valueNumBuse As New Label
            Controls.Add(label_valueNumBuse)
            label_valueNumBuse.Parent = Panel_valueNumBuse
            label_valueNumBuse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label_valueNumBuse.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            label_valueNumBuse.Location = New System.Drawing.Point(29, 12)
            label_valueNumBuse.Name = "label_valueNumBuse_" & lotId & "_" & x
            label_valueNumBuse.Size = New System.Drawing.Size(28, 16)
            label_valueNumBuse.Text = x
            label_valueNumBuse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'diagBuses_mesureDebit_1_debit
            '
            Dim Textbox_mesureDebit_debit As New TextBox
            Controls.Add(Textbox_mesureDebit_debit)
            Textbox_mesureDebit_debit.Parent = Panel_valueDebit
            Textbox_mesureDebit_debit.Location = New System.Drawing.Point(15, 25)
            Textbox_mesureDebit_debit.Name = "diagBuses_mesureDebit_" & lotId & "_" & x & "_debit"
            Textbox_mesureDebit_debit.Size = New System.Drawing.Size(56, 20)
            Textbox_mesureDebit_debit.Text = ""
            AddHandler Textbox_mesureDebit_debit.TextChanged, AddressOf calcDebitMoyenBuse_TextChanged
            AddHandler Textbox_mesureDebit_debit.TextChanged, AddressOf calcUsureBuse_TextChanged
            AddHandler Textbox_mesureDebit_debit.KeyPress, AddressOf diagBuses_KeyPress

            '
            'diagBuses_mesureDebit_1_usure
            '
            Dim Textbox_mesureDebit_usure As New TextBox
            Controls.Add(Textbox_mesureDebit_usure)
            Textbox_mesureDebit_usure.Parent = Panel_valueUsure
            Textbox_mesureDebit_usure.Location = New System.Drawing.Point(15, 25)
            Textbox_mesureDebit_usure.Name = "diagBuses_mesureDebit_" & lotId & "_" & x & "_usure"
            Textbox_mesureDebit_usure.Size = New System.Drawing.Size(56, 20)
            Textbox_mesureDebit_usure.Text = ""
            Textbox_mesureDebit_usure.BackColor = System.Drawing.SystemColors.Control
            AddHandler Textbox_mesureDebit_usure.KeyPress, AddressOf usureBuseReadOnly_KeyPress

        Next

    End Sub

    '#####################################################

    ' Changement debit nominal constructeur
    Private Sub DebitNominalCONSTructeur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lotId As Integer = CType(sender.name.replace("TextBox_debitNominalCONSTructeur_", ""), Integer)
        fillDebitNom(lotId)
        mutCalcNbBusesUsed()
        mutCalcUsureMoyBuses()
    End Sub
    ' Changement ecart tolere
    Private Sub ecartTolere_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.text <> "" Then
            mutCalcNbBusesUsed()
            mutCalcUsureMoyBuses()
        End If
    End Sub
    Private Sub ecartTolere_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.text <> "" Then
            mutCalcNbBusesUsed()
            mutCalcUsureMoyBuses()
        End If
    End Sub

    '#####################################################

    ' Calcul de l'usure d'une buse
    Private Sub calcUsureBuse_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' On récupère le lot et le numero de buse
            Dim infosIds As String() = sender.Name.ToString.Replace("diagBuses_mesureDebit_", "").Replace("_debit", "").Split("_")
            Dim lotId As Integer = infosIds(0)
            Dim buseId As Integer = infosIds(1)
            ' On calcul
            mutCalcUsure(lotId, buseId)
            mutCalcIsUsed(lotId, buseId)
            mutCalcNbBusesUsed()
            mutCalcUsureMoyBuses()
        Catch ex As Exception
            CSDebug.dispError("diagnostic::calcUsureBuse_TextChanged : " & ex.Message)
        End Try
    End Sub

    ' Calcul du debit moyen de la buse
    Private Sub calcDebitMoyenBuse_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mutCalcDebitMoy()
    End Sub

    '#####################################################

    ' UsureReadOnly
    Private Sub usureBuseReadOnly_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

#End Region

#Region " Calculs "

    ' Calcul le % d'usure d'une buse
    Private Function mutCalcUsure(ByVal lotId As Integer, ByVal buseId As Integer) As Double
        ' On récupère les contrôles pour cette buse
        Dim debitTextbox As TextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_debit", diagBuses_tab_categories)
        If debitTextbox.Text <> "" Then
            Dim debitValue As Double = CType(debitTextbox.Text, Double)
            Dim usureTextbox As TextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_usure", diagBuses_tab_categories)
            Dim debitNominalTextbox As TextBox = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)
            Dim debitNominalValue As Double = CType(debitNominalTextbox.Text, Double)
            'debitNominalValue = 1.08
            Dim ecartTolereTextbox As ComboBox = CSForm.getControlByName("TextBox_ecartTolere_" & lotId, diagBuses_tab_categories)
            Dim ecartTolereValue As Double = CType(ecartTolereTextbox.Text, Double)
            ' On calcul l'usure
            Dim usurePourcent As Double = Math.Round(((debitValue - debitNominalValue) * 100) / debitNominalValue, 2)
            usureTextbox.Text = usurePourcent
            Return usurePourcent
        Else
            Return 0
        End If

    End Function

    ' Retourn TRUE si une buse est usée, sinon FALSE
    Private Function mutCalcIsUsed(ByVal lotId As Integer, ByVal buseId As Integer) As Integer
        Try
            ' On récupère les contrôles pour cette buse
            Dim debitTextbox As TextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_debit", diagBuses_tab_categories)
            If debitTextbox.Text <> "" Then
                Dim debitValue As Double = CType(debitTextbox.Text, Double)
                Dim debitNominalTextbox As TextBox = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)
                Dim debitNominalValue As Double = CType(debitNominalTextbox.Text, Double)
                Dim ecartTolereTextbox As ComboBox = CSForm.getControlByName("TextBox_ecartTolere_" & lotId, diagBuses_tab_categories)
                Dim ecartTolereValue As Double = CType(ecartTolereTextbox.Text, Double)
                Dim usureTextbox As TextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_usure", diagBuses_tab_categories)
                ' On Calcul
                Dim tmpEcartPourcentage As Decimal = CType(Math.Abs(CType(debitValue, Decimal) - CType(debitNominalValue, Decimal)) * CType(100, Decimal) / CType(debitNominalValue, Decimal), Decimal)
                CSDebug.dispInfo("Tab 9.2.2 :: Calc Is Used : " & tmpEcartPourcentage)
                If tmpEcartPourcentage < CType(ecartTolereValue, Decimal) Or CType(ecartTolereValue, Decimal) = tmpEcartPourcentage Then
                    usureTextbox.BackColor = System.Drawing.Color.Green
                    Return False
                Else
                    usureTextbox.BackColor = System.Drawing.Color.Red
                    Return True
                End If
            End If
        Catch ex As Exception
            CSDebug.dispWarn("tool_diagBuses::mutCalcIsUsed : " & ex.Message)
        End Try
    End Function


    ' Calcul le nombre de buses d'un lot
    Private Function mutCalcNbBuses(ByVal lotId As Integer) As Double
        ' Récupération des controles
        Dim nbBusesTextbox As TextBox = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
        If nbBusesTextbox.Text <> "" Then
            Dim nbBusesValue As Double = CType(nbBusesTextbox.Text, Integer)
            Return nbBusesValue
        Else
            Return 0
        End If
    End Function
    Private Function mutCalcNbBuses() As Integer
        Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
        Dim nbBuses As Integer = 0
        For i As Integer = 1 To nbLots
            Try
                nbBuses += mutCalcNbBuses(i)
            Catch ex As Exception
                CSDebug.dispWarn("diagnostic::mutCalcNbBuses : " & ex.Message)
            End Try
        Next
        Return nbBuses
    End Function

    ' Calcul le nombre de buses usées d'un lot
    Private Function mutCalcNbBusesUsed(ByVal lotId As Integer) As Integer
        ' Récupération des controles
        Dim nbBusesTextbox As TextBox = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
        If nbBusesTextbox.Text <> "" Then
            Dim nbBusesValue As Double = CType(nbBusesTextbox.Text, Integer)
            Dim nbBusesUseesTextbox As TextBox = CSForm.getControlByName("TextBox_nbBusesUsees_" & lotId, diagBuses_tab_categories)
            ' On calcul le nombre de buses usées
            Dim nbBusesUsees As Integer = 0
            For i As Integer = 1 To nbBusesValue
                Try
                    If mutCalcIsUsed(lotId, i) Then
                        nbBusesUsees += 1
                    End If
                Catch ex As Exception
                    CSDebug.dispWarn("diagnostic::mutCalcNbBusesUsed : " & ex.Message)
                End Try
            Next
            nbBusesUseesTextbox.Text = nbBusesUsees
            Return nbBusesUsees
        Else
            Return 0
        End If
    End Function
    ' Calcul le nombre de buses usées du jeu de buses
    Dim tabBuses_isOk As Integer = -1
    Private Function mutCalcNbBusesUsed() As Integer
        Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
        Dim nbBusesUsees As Integer = 0
        For i As Integer = 1 To nbLots
            Try
                nbBusesUsees += mutCalcNbBusesUsed(i)
            Catch ex As Exception
                CSDebug.dispWarn("diagnostic::mutCalcNbBusesUsed : " & ex.Message)
            End Try
        Next
        If nbBusesUsees > 0 Then
            If (nbBusesUsees / mutCalcNbBuses()) < 1 / 3 Then
                diagBuses_resultat.Text = "USURE PARTIELLE"
                diagBuses_resultat.ForeColor = System.Drawing.Color.Red
                tabBuses_isOk = 0
            Else
                diagBuses_resultat.Text = "USURE GLOBALE"
                diagBuses_resultat.ForeColor = System.Drawing.Color.Red
                tabBuses_isOk = 0
            End If
        Else
            diagBuses_resultat.Text = "OK"
            diagBuses_resultat.ForeColor = System.Drawing.Color.Green
            tabBuses_isOk = 1
        End If
        diagBuses_nbBusesUsees.Text = nbBusesUsees
        diagnosticCourant.syntheseNbBusesUsees = nbBusesUsees.ToString
        Return nbBusesUsees
    End Function

    ' Calcul l'usure moyenne d'un lot de buses
    Private Function mutCalcUsureMoyBuses(ByVal lotId As Integer) As Double
        ' Récupération des controles
        Dim nbBusesTextbox As TextBox = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
        Dim nbBusesValue As Double = CType(nbBusesTextbox.Text, Integer)
        Dim usureMoyBusesTextbox As TextBox = CSForm.getControlByName("TextBox_usureMoyenneBuses_" & lotId, diagBuses_tab_categories)
        ' On calcul le nombre de buses usées
        Dim usureMoy As Double = 0
        For i As Integer = 1 To nbBusesValue
            Try
                Dim tmpUsure As Double = mutCalcUsure(lotId, i)
                If tmpUsure <> 0 Then
                    usureMoy = (usureMoy + tmpUsure)
                End If
            Catch ex As Exception
                CSDebug.dispWarn("diagnostic::mutCalcUsureMoyBuses : " & ex.Message)
            End Try
        Next
        usureMoy = Math.Round(usureMoy / nbBusesValue, 2)
        usureMoyBusesTextbox.Text = usureMoy
        Return usureMoy
    End Function
    ' Calcul l'usure moyenne du jeu de buses
    Private Function mutCalcUsureMoyBuses() As Double
        Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
        Dim usureMoyBuses As Double = 0
        For i As Integer = 1 To nbLots
            Try
                usureMoyBuses += mutCalcUsureMoyBuses(i)
            Catch ex As Exception
                CSDebug.dispWarn("diagnostic::mutCalcUsureMoyBuses : " & ex.Message)
            End Try
        Next
        usureMoyBuses = Math.Round(usureMoyBuses / nbLots, 2)
        diagBuses_usureMoyBuses.Text = usureMoyBuses
        diagnosticCourant.syntheseUsureMoyenneBuses = usureMoyBuses
        fillArrBusesUsed()
        Return usureMoyBuses
    End Function

    ' Calcul le debit moyen d'un lot de buses
    Private Function mutCalcDebitMoy(ByVal lotId As Integer) As Double
        ' Récupération des controles
        Dim nbBusesTextbox As TextBox = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
        Dim nbBusesValue As Double = CType(nbBusesTextbox.Text, Integer)
        Dim debitMoyBusesTextbox As TextBox = CSForm.getControlByName("TextBox_debitMoyen_" & lotId, diagBuses_tab_categories)
        ' On calcul le debit moyen des buses
        Dim debitMoy As Double = 0
        For i As Integer = 1 To nbBusesValue
            Try
                Dim debitTextbox As TextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & i & "_debit", diagBuses_tab_categories)
                If debitTextbox.Text <> "" Then
                    debitMoy = (debitMoy + CType(debitTextbox.Text, Double))
                End If
            Catch ex As Exception
                CSDebug.dispWarn("diagnostic::mutCalcDebitMoy : " & ex.Message)
            End Try
        Next
        debitMoy = Math.Round(debitMoy / nbBusesValue, 3)
        debitMoyBusesTextbox.Text = debitMoy
        fillDebitNom(lotId)
        Return debitMoy
    End Function
    ' Calcul le debit moyen du jeu de buses
    Private Function mutCalcDebitMoy() As Double
        Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
        Dim debitMoyBuses As Double = 0
        For i As Integer = 1 To nbLots
            Try
                debitMoyBuses += mutCalcDebitMoy(i)
            Catch ex As Exception
                CSDebug.dispWarn("diagnostic::mutCalcDebitMoy : " & ex.Message)
            End Try
        Next
        debitMoyBuses = Math.Round(debitMoyBuses / nbLots, 2)
        diagBuses_debitMoyen.Text = debitMoyBuses
        Return debitMoyBuses
    End Function

    ' rempli le debit nominal pour calcul
    Private Sub fillDebitNom(ByVal lotId As Integer)
        Dim debitNomCONSTTextbox As TextBox = CSForm.getControlByName("TextBox_debitNominalCONSTructeur_" & lotId, diagBuses_tab_categories)
        Dim debitNomCalcTextbox As TextBox = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)
        Dim debitMoyBusesTextbox As TextBox = CSForm.getControlByName("TextBox_debitMoyen_" & lotId, diagBuses_tab_categories)
        If debitNomCONSTTextbox.Text = "" Then
            debitNomCalcTextbox.Text = debitMoyBusesTextbox.Text
        Else
            debitNomCalcTextbox.Text = debitNomCONSTTextbox.Text
        End If
    End Sub

    ' Numéro des buses usées
    Private Sub fillArrBusesUsed()

        '------------------------------------------------------
        '--- On boucle les lots
        '------------------------------------------------------
        Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
        ' On reset le tableau
        ReDim arrBusesUsed(nbLots)
        Dim curNumeroBuse As Integer = 0
        For lotId As Integer = 1 To nbLots
            Try
                '------------------------------------------------------
                '--- On boucle les buses
                '------------------------------------------------------
                Dim nbBusesTextbox As TextBox = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
                If nbBusesTextbox.Text <> "" Then
                    Dim nbBusesValue As Double = CType(nbBusesTextbox.Text, Integer)
                    ' On calcul le nombre de buses usées
                    For buseId As Integer = 1 To nbBusesValue
                        Try
                            '------------------------------------------------------
                            '--- Calcul si la  buse est usée
                            '------------------------------------------------------
                            curNumeroBuse += 1
                            Try
                                ' On récupère les contrôles pour cette buse
                                Dim debitTextbox As TextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_debit", diagBuses_tab_categories)
                                If debitTextbox.Text <> "" Then
                                    Dim debitValue As Double = CType(debitTextbox.Text, Double)
                                    Dim debitNominalTextbox As TextBox = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)
                                    Dim debitNominalValue As Double = CType(debitNominalTextbox.Text, Double)
                                    Dim ecartTolereTextbox As ComboBox = CSForm.getControlByName("TextBox_ecartTolere_" & lotId, diagBuses_tab_categories)
                                    Dim ecartTolereValue As Double = CType(ecartTolereTextbox.Text, Double)
                                    Dim usureTextbox As TextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_usure", diagBuses_tab_categories)
                                    ' On Calcul
                                    Dim tmpEcartPourcentage As Decimal = CType(Math.Abs(CType(debitValue, Decimal) - CType(debitNominalValue, Decimal)) * CType(100, Decimal) / CType(debitNominalValue, Decimal), Decimal)
                                    If tmpEcartPourcentage < CType(ecartTolereValue, Decimal) Or CType(ecartTolereValue, Decimal) = tmpEcartPourcentage Then
                                        ' Buse pas usée
                                    Else
                                        ' Buse usée
                                        arrBusesUsed(lotId) = arrBusesUsed(lotId) & curNumeroBuse.ToString & " ; "
                                    End If
                                End If
                            Catch ex As Exception
                                CSDebug.dispWarn("tool_diagBuses::fillArrBusesUsed : " & ex.Message)
                            End Try
                            '------------------------------------------------------
                            '--- FIN -- Calcul si la  buse est usée
                            '------------------------------------------------------
                        Catch ex As Exception
                            CSDebug.dispWarn("tool_diagBuses::fillArrBusesUsed: " & ex.Message)
                        End Try
                    Next
                End If
                '------------------------------------------------------
                '--- FIN -- On boucle les buses
                '------------------------------------------------------
            Catch ex As Exception
                CSDebug.dispWarn("diagnostic::mutCalcNbBusesUsed : " & ex.Message)
            End Try
        Next
        '------------------------------------------------------
        '--- FIN -- On boucle les lots
        '------------------------------------------------------

    End Sub

#End Region

#Region " Contrôles saisie "

    Private Sub diagBuses_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles diagBuses_conf_pressionMesure.KeyPress
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub

#End Region

#Region " Chargement référentiel buses "

    Private Sub refBuses_loadMarques(ByVal lotId As Integer)

        Dim oRefBuses As New ReferentielBusesCSV()
        oRefBuses.load()
        ' On récupère tous les contrôles
        Dim controlToPopulate As ComboBox = CSForm.getControlByName("ComboBox_marque_" & lotId, diagBuses_tab_categories)
        controlToPopulate.Items.Clear()
        controlToPopulate.Items.AddRange(oRefBuses.getMarques().ToArray)
        '        ReferentielBuseManager.populateCombo("marque", controlToPopulate)

        Dim inputGenres As ComboBox = CSForm.getControlByName("ComboBox_genre_" & lotId, diagBuses_tab_categories)
        Dim inputCouleurs As ComboBox = CSForm.getControlByName("ComboBox_couleur_" & lotId, diagBuses_tab_categories)
        inputGenres.Enabled = False
        inputCouleurs.Enabled = False

    End Sub
    Private Sub refBuses_loadGenres(ByVal lotId As Integer, ByVal marque As String)

        ' On récupère tous les contrôles
        Dim controlToPopulate As ComboBox = CSForm.getControlByName("ComboBox_genre_" & lotId, diagBuses_tab_categories)
        controlToPopulate.Items.Clear()
        controlToPopulate.Items.AddRange(m_oRefBuses.getModeles(marque).ToArray())

        controlToPopulate.Enabled = True

    End Sub
    Private Sub refBuses_loadCouleurs(ByVal lotId As Integer, ByVal marque As String, pModele As String)

        ' On récupère tous les contrôles
        Dim controlToPopulate As ComboBox = CSForm.getControlByName("ComboBox_couleur_" & lotId, diagBuses_tab_categories)
        '        ReferentielBuseManager.populateCombo("couleur", controlToPopulate, marque)
        controlToPopulate.Items.Clear()
        controlToPopulate.Items.AddRange(m_oRefBuses.getCouleursBuseByMarqueModele(marque, pModele).ToArray)

        controlToPopulate.Enabled = True

    End Sub
    Private Sub loadReferentielBuses(ByVal lotId As Integer)
        refBuses_loadMarques(lotId)
    End Sub

    Private Sub changeMarqueBuseSelected(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' On récupère les contrôles
        Dim inputMarques As ComboBox = sender

        ' On récupère l'id du lot
        Dim lotId As Integer = CType(inputMarques.Name.Replace("ComboBox_marque_", ""), Integer)

        ' On charge les genres et couleurs
        refBuses_loadGenres(lotId, inputMarques.Text)

    End Sub

#End Region

#Region " Acquisition des données "

    Public Sub doAcqiring()
        Dim isok As Boolean = True
        If isok Then
            ' On récupère les buses de la table d'échange
            Dim oModule As CRODIPAcquisition.ModuleAcq = CRODIPAcquisition.ModuleAcq.GetModule("MD2")
            Dim arrBuses As List(Of CRODIPAcquisition.AcquisitionValue) = oModule.getValues()
            Dim curIdBuse As Integer = 0
            Dim prevIdNiveau As Integer = 0
            For Each tmpResponse As CRODIPAcquisition.AcquisitionValue In arrBuses
                Try
                    If tmpResponse.NumBuse <> 0 Then
                        ' On transmet le tout au diag
                        Try


                            Dim x As Control
                            x = CSForm.getControlByName("diagBuses_mesureDebit_" & tmpResponse.Niveau & "_" & tmpResponse.NumBuse & "_debit", globFormToolBuses)
                            x.Text = tmpResponse.Debit.ToString
                        Catch ex As Exception
                            CSDebug.dispError("tool_diagBuses.doAcquiring : " & ex.Message)
                        End Try
                    End If
                Catch ex As Exception
                    CSDebug.dispError("tool_diagBuses.doAcquiring : " & ex.Message.ToString)
                End Try
            Next
            ' On vide la table d'échange
            oModule.clearResults()
        Else
            MsgBox("Le nombre de buses saisi et le nombre de buses acquises est différent. Veuillez vérifiez.")
        End If
    End Sub

#End Region
    Private Sub btnFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFermer.Click
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
