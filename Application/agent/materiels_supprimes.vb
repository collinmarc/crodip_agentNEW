Public Class materiels_supprimes
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
    Friend WithEvents btn_gestionManometresEtalon_valider As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents dgv_ManoControleSuppr As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_gestionManometresControle_valider As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents dgvManoEtalonSuppr As System.Windows.Forms.DataGridView
    Friend WithEvents dgvBusesSuppr As System.Windows.Forms.DataGridView
    Friend WithEvents dgvBancsSuppr As System.Windows.Forms.DataGridView
    Friend WithEvents m_bsrcManoEtalonSuppr As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsrcBuseSuppr As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsrcManoControlSuppr As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsrcBancSuppr As System.Windows.Forms.BindingSource
    Friend WithEvents idCrodip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgentSuppressionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RaisonSuppressionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateSuppressionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCrodipDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgentSuppressionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RaisonSuppressionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateSuppressionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCrodipDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgentSuppressionDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RaisonSuppressionDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateSuppressionDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgentSuppressionDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RaisonSuppressionDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateSuppressionDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_ValiderQuitter As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(materiels_supprimes))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgv_ManoControleSuppr = New System.Windows.Forms.DataGridView()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvManoEtalonSuppr = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_gestionManometresEtalon_valider = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvBusesSuppr = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvBancsSuppr = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_ValiderQuitter = New System.Windows.Forms.Label()
        Me.btn_gestionManometresControle_valider = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.idCrodip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AgentSuppressionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RaisonSuppressionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSuppressionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_bsrcManoControlSuppr = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdCrodipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AgentSuppressionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RaisonSuppressionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSuppressionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_bsrcManoEtalonSuppr = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdCrodipDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AgentSuppressionDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RaisonSuppressionDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSuppressionDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_bsrcBuseSuppr = New System.Windows.Forms.BindingSource(Me.components)
        Me.AgentSuppressionDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RaisonSuppressionDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSuppressionDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_bsrcBancSuppr = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv_ManoControleSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvManoEtalonSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvBusesSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvBancsSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcManoControlSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcManoEtalonSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcBuseSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcBancSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(997, 602)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.dgv_ManoControleSuppr)
        Me.TabPage1.Controls.Add(Me.Label82)
        Me.TabPage1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(989, 576)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Manomètres de contrôle"
        '
        'dgv_ManoControleSuppr
        '
        Me.dgv_ManoControleSuppr.AllowUserToAddRows = False
        Me.dgv_ManoControleSuppr.AllowUserToDeleteRows = False
        Me.dgv_ManoControleSuppr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_ManoControleSuppr.AutoGenerateColumns = False
        Me.dgv_ManoControleSuppr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_ManoControleSuppr.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ManoControleSuppr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ManoControleSuppr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ManoControleSuppr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCrodip, Me.AgentSuppressionDataGridViewTextBoxColumn, Me.RaisonSuppressionDataGridViewTextBoxColumn, Me.DateSuppressionDataGridViewTextBoxColumn})
        Me.dgv_ManoControleSuppr.DataSource = Me.m_bsrcManoControlSuppr
        Me.dgv_ManoControleSuppr.Location = New System.Drawing.Point(10, 45)
        Me.dgv_ManoControleSuppr.Name = "dgv_ManoControleSuppr"
        Me.dgv_ManoControleSuppr.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ManoControleSuppr.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_ManoControleSuppr.Size = New System.Drawing.Size(965, 519)
        Me.dgv_ManoControleSuppr.TabIndex = 38
        '
        'Label82
        '
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label82.Image = CType(resources.GetObject("Label82.Image"), System.Drawing.Image)
        Me.Label82.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label82.Location = New System.Drawing.Point(8, 8)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(608, 25)
        Me.Label82.TabIndex = 37
        Me.Label82.Text = "     Liste des manomètres de contrôle/calibrateur supprimés"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.dgvManoEtalonSuppr)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.btn_gestionManometresEtalon_valider)
        Me.TabPage2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(989, 576)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Manomètre étalon"
        '
        'dgvManoEtalonSuppr
        '
        Me.dgvManoEtalonSuppr.AllowUserToAddRows = False
        Me.dgvManoEtalonSuppr.AllowUserToDeleteRows = False
        Me.dgvManoEtalonSuppr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvManoEtalonSuppr.AutoGenerateColumns = False
        Me.dgvManoEtalonSuppr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvManoEtalonSuppr.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvManoEtalonSuppr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvManoEtalonSuppr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvManoEtalonSuppr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCrodipDataGridViewTextBoxColumn, Me.AgentSuppressionDataGridViewTextBoxColumn1, Me.RaisonSuppressionDataGridViewTextBoxColumn1, Me.DateSuppressionDataGridViewTextBoxColumn1})
        Me.dgvManoEtalonSuppr.DataSource = Me.m_bsrcManoEtalonSuppr
        Me.dgvManoEtalonSuppr.Location = New System.Drawing.Point(8, 37)
        Me.dgvManoEtalonSuppr.Name = "dgvManoEtalonSuppr"
        Me.dgvManoEtalonSuppr.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvManoEtalonSuppr.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvManoEtalonSuppr.Size = New System.Drawing.Size(965, 519)
        Me.dgvManoEtalonSuppr.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(608, 25)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "     Liste des manomètres étalons supprimés"
        '
        'btn_gestionManometresEtalon_valider
        '
        Me.btn_gestionManometresEtalon_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionManometresEtalon_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionManometresEtalon_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionManometresEtalon_valider.Image = CType(resources.GetObject("btn_gestionManometresEtalon_valider.Image"), System.Drawing.Image)
        Me.btn_gestionManometresEtalon_valider.Location = New System.Drawing.Point(152, 616)
        Me.btn_gestionManometresEtalon_valider.Name = "btn_gestionManometresEtalon_valider"
        Me.btn_gestionManometresEtalon_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionManometresEtalon_valider.TabIndex = 39
        Me.btn_gestionManometresEtalon_valider.Text = "    Valider / Quitter"
        Me.btn_gestionManometresEtalon_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.dgvBusesSuppr)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(989, 576)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Buses Etalon"
        '
        'dgvBusesSuppr
        '
        Me.dgvBusesSuppr.AllowUserToAddRows = False
        Me.dgvBusesSuppr.AllowUserToDeleteRows = False
        Me.dgvBusesSuppr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBusesSuppr.AutoGenerateColumns = False
        Me.dgvBusesSuppr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBusesSuppr.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBusesSuppr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvBusesSuppr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusesSuppr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCrodipDataGridViewTextBoxColumn2, Me.AgentSuppressionDataGridViewTextBoxColumn3, Me.RaisonSuppressionDataGridViewTextBoxColumn3, Me.DateSuppressionDataGridViewTextBoxColumn3})
        Me.dgvBusesSuppr.DataSource = Me.m_bsrcBuseSuppr
        Me.dgvBusesSuppr.Location = New System.Drawing.Point(12, 29)
        Me.dgvBusesSuppr.Name = "dgvBusesSuppr"
        Me.dgvBusesSuppr.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBusesSuppr.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvBusesSuppr.Size = New System.Drawing.Size(965, 519)
        Me.dgvBusesSuppr.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(8, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(608, 25)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "     Liste des buses étalons supprimées"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.dgvBancsSuppr)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(989, 576)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Bancs de mesure"
        '
        'dgvBancsSuppr
        '
        Me.dgvBancsSuppr.AllowUserToAddRows = False
        Me.dgvBancsSuppr.AllowUserToDeleteRows = False
        Me.dgvBancsSuppr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBancsSuppr.AutoGenerateColumns = False
        Me.dgvBancsSuppr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBancsSuppr.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBancsSuppr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvBancsSuppr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBancsSuppr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.AgentSuppressionDataGridViewTextBoxColumn2, Me.RaisonSuppressionDataGridViewTextBoxColumn2, Me.DateSuppressionDataGridViewTextBoxColumn2})
        Me.dgvBancsSuppr.DataSource = Me.m_bsrcBancSuppr
        Me.dgvBancsSuppr.Location = New System.Drawing.Point(12, 29)
        Me.dgvBancsSuppr.Name = "dgvBancsSuppr"
        Me.dgvBancsSuppr.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBancsSuppr.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvBancsSuppr.Size = New System.Drawing.Size(965, 519)
        Me.dgvBancsSuppr.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(8, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(608, 25)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "     Liste des bancs de mesure supprimés"
        '
        'btn_ValiderQuitter
        '
        Me.btn_ValiderQuitter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ValiderQuitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ValiderQuitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ValiderQuitter.ForeColor = System.Drawing.Color.White
        Me.btn_ValiderQuitter.Image = CType(resources.GetObject("btn_ValiderQuitter.Image"), System.Drawing.Image)
        Me.btn_ValiderQuitter.Location = New System.Drawing.Point(869, 635)
        Me.btn_ValiderQuitter.Name = "btn_ValiderQuitter"
        Me.btn_ValiderQuitter.Size = New System.Drawing.Size(128, 24)
        Me.btn_ValiderQuitter.TabIndex = 37
        Me.btn_ValiderQuitter.Text = "    Valider / Quitter"
        Me.btn_ValiderQuitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_gestionManometresControle_valider
        '
        Me.btn_gestionManometresControle_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionManometresControle_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionManometresControle_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionManometresControle_valider.Image = CType(resources.GetObject("btn_gestionManometresControle_valider.Image"), System.Drawing.Image)
        Me.btn_gestionManometresControle_valider.Location = New System.Drawing.Point(761, 553)
        Me.btn_gestionManometresControle_valider.Name = "btn_gestionManometresControle_valider"
        Me.btn_gestionManometresControle_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionManometresControle_valider.TabIndex = 37
        Me.btn_gestionManometresControle_valider.Text = "    Valider / Quitter"
        Me.btn_gestionManometresControle_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel13.Location = New System.Drawing.Point(0, 608)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(992, 10)
        Me.Panel13.TabIndex = 38
        '
        'idCrodip
        '
        Me.idCrodip.DataPropertyName = "idCrodip"
        Me.idCrodip.HeaderText = "Identifiant"
        Me.idCrodip.Name = "idCrodip"
        Me.idCrodip.ReadOnly = True
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "Identifiant"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        '
        'AgentSuppressionDataGridViewTextBoxColumn
        '
        Me.AgentSuppressionDataGridViewTextBoxColumn.DataPropertyName = "AgentSuppression"
        Me.AgentSuppressionDataGridViewTextBoxColumn.HeaderText = "Nom de l'agent"
        Me.AgentSuppressionDataGridViewTextBoxColumn.Name = "AgentSuppressionDataGridViewTextBoxColumn"
        Me.AgentSuppressionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RaisonSuppressionDataGridViewTextBoxColumn
        '
        Me.RaisonSuppressionDataGridViewTextBoxColumn.DataPropertyName = "RaisonSuppression"
        Me.RaisonSuppressionDataGridViewTextBoxColumn.HeaderText = "Raison de la suppression"
        Me.RaisonSuppressionDataGridViewTextBoxColumn.Name = "RaisonSuppressionDataGridViewTextBoxColumn"
        Me.RaisonSuppressionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateSuppressionDataGridViewTextBoxColumn
        '
        Me.DateSuppressionDataGridViewTextBoxColumn.DataPropertyName = "dateSuppression"
        Me.DateSuppressionDataGridViewTextBoxColumn.HeaderText = "Date de la suppression"
        Me.DateSuppressionDataGridViewTextBoxColumn.Name = "DateSuppressionDataGridViewTextBoxColumn"
        Me.DateSuppressionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'm_bsrcManoControlSuppr
        '
        Me.m_bsrcManoControlSuppr.DataSource = GetType(Crodip_agent.ManometreControle)
        '
        'IdCrodipDataGridViewTextBoxColumn
        '
        Me.IdCrodipDataGridViewTextBoxColumn.DataPropertyName = "idCrodip"
        Me.IdCrodipDataGridViewTextBoxColumn.HeaderText = "Identifiant"
        Me.IdCrodipDataGridViewTextBoxColumn.Name = "IdCrodipDataGridViewTextBoxColumn"
        Me.IdCrodipDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AgentSuppressionDataGridViewTextBoxColumn1
        '
        Me.AgentSuppressionDataGridViewTextBoxColumn1.DataPropertyName = "AgentSuppression"
        Me.AgentSuppressionDataGridViewTextBoxColumn1.HeaderText = "Nom de l'agent"
        Me.AgentSuppressionDataGridViewTextBoxColumn1.Name = "AgentSuppressionDataGridViewTextBoxColumn1"
        Me.AgentSuppressionDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'RaisonSuppressionDataGridViewTextBoxColumn1
        '
        Me.RaisonSuppressionDataGridViewTextBoxColumn1.DataPropertyName = "RaisonSuppression"
        Me.RaisonSuppressionDataGridViewTextBoxColumn1.HeaderText = "Raison de la suppression"
        Me.RaisonSuppressionDataGridViewTextBoxColumn1.Name = "RaisonSuppressionDataGridViewTextBoxColumn1"
        Me.RaisonSuppressionDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DateSuppressionDataGridViewTextBoxColumn1
        '
        Me.DateSuppressionDataGridViewTextBoxColumn1.DataPropertyName = "dateSuppression"
        Me.DateSuppressionDataGridViewTextBoxColumn1.HeaderText = "date de la suppression"
        Me.DateSuppressionDataGridViewTextBoxColumn1.Name = "DateSuppressionDataGridViewTextBoxColumn1"
        Me.DateSuppressionDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'm_bsrcManoEtalonSuppr
        '
        Me.m_bsrcManoEtalonSuppr.DataSource = GetType(Crodip_agent.ManometreEtalon)
        '
        'IdCrodipDataGridViewTextBoxColumn2
        '
        Me.IdCrodipDataGridViewTextBoxColumn2.DataPropertyName = "idCrodip"
        Me.IdCrodipDataGridViewTextBoxColumn2.HeaderText = "Identifiant"
        Me.IdCrodipDataGridViewTextBoxColumn2.Name = "IdCrodipDataGridViewTextBoxColumn2"
        Me.IdCrodipDataGridViewTextBoxColumn2.ReadOnly = True
        '
        'AgentSuppressionDataGridViewTextBoxColumn3
        '
        Me.AgentSuppressionDataGridViewTextBoxColumn3.DataPropertyName = "AgentSuppression"
        Me.AgentSuppressionDataGridViewTextBoxColumn3.HeaderText = "Nom de l'agent"
        Me.AgentSuppressionDataGridViewTextBoxColumn3.Name = "AgentSuppressionDataGridViewTextBoxColumn3"
        Me.AgentSuppressionDataGridViewTextBoxColumn3.ReadOnly = True
        '
        'RaisonSuppressionDataGridViewTextBoxColumn3
        '
        Me.RaisonSuppressionDataGridViewTextBoxColumn3.DataPropertyName = "RaisonSuppression"
        Me.RaisonSuppressionDataGridViewTextBoxColumn3.HeaderText = "Raison de la suppression"
        Me.RaisonSuppressionDataGridViewTextBoxColumn3.Name = "RaisonSuppressionDataGridViewTextBoxColumn3"
        Me.RaisonSuppressionDataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DateSuppressionDataGridViewTextBoxColumn3
        '
        Me.DateSuppressionDataGridViewTextBoxColumn3.DataPropertyName = "dateSuppression"
        Me.DateSuppressionDataGridViewTextBoxColumn3.HeaderText = "Date de la suppression"
        Me.DateSuppressionDataGridViewTextBoxColumn3.Name = "DateSuppressionDataGridViewTextBoxColumn3"
        Me.DateSuppressionDataGridViewTextBoxColumn3.ReadOnly = True
        '
        'm_bsrcBuseSuppr
        '
        Me.m_bsrcBuseSuppr.DataSource = GetType(Crodip_agent.Buse)
        '
        'AgentSuppressionDataGridViewTextBoxColumn2
        '
        Me.AgentSuppressionDataGridViewTextBoxColumn2.DataPropertyName = "AgentSuppression"
        Me.AgentSuppressionDataGridViewTextBoxColumn2.HeaderText = "Nom de l'agent"
        Me.AgentSuppressionDataGridViewTextBoxColumn2.Name = "AgentSuppressionDataGridViewTextBoxColumn2"
        Me.AgentSuppressionDataGridViewTextBoxColumn2.ReadOnly = True
        '
        'RaisonSuppressionDataGridViewTextBoxColumn2
        '
        Me.RaisonSuppressionDataGridViewTextBoxColumn2.DataPropertyName = "RaisonSuppression"
        Me.RaisonSuppressionDataGridViewTextBoxColumn2.HeaderText = "Raison de la suppression"
        Me.RaisonSuppressionDataGridViewTextBoxColumn2.Name = "RaisonSuppressionDataGridViewTextBoxColumn2"
        Me.RaisonSuppressionDataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DateSuppressionDataGridViewTextBoxColumn2
        '
        Me.DateSuppressionDataGridViewTextBoxColumn2.DataPropertyName = "dateSuppression"
        Me.DateSuppressionDataGridViewTextBoxColumn2.HeaderText = "Date de la suppression"
        Me.DateSuppressionDataGridViewTextBoxColumn2.Name = "DateSuppressionDataGridViewTextBoxColumn2"
        Me.DateSuppressionDataGridViewTextBoxColumn2.ReadOnly = True
        '
        'm_bsrcBancSuppr
        '
        Me.m_bsrcBancSuppr.DataSource = GetType(Crodip_agent.Banc)
        '
        'materiels_supprimes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.btn_ValiderQuitter)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "materiels_supprimes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liste des matériels supprimés"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv_ManoControleSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvManoEtalonSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvBusesSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvBancsSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcManoControlSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcManoEtalonSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcBuseSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcBancSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btn_ValiderQuitter_Click(sender As System.Object, e As System.EventArgs) Handles btn_ValiderQuitter.Click
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

    Private Sub materiels_supprimes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Chargement des matériels supprimés
        Dim oCol1 As Collection
        oCol1 = ManometreControleManager.getMaterielsSupprimes(agentCourant.idStructure)
        For Each oManoC As ManometreControle In oCol1
            m_bsrcManoControlSuppr.Add(oManoC)
        Next
        oCol1 = ManometreEtalonManager.getMaterielsSupprimes(agentCourant.idStructure)
        For Each oManoE As ManometreEtalon In oCol1
            m_bsrcManoEtalonSuppr.Add(oManoE)
        Next
        oCol1 = BuseManager.getMaterielsSupprimes(agentCourant.idStructure)
        For Each oBuse As Buse In oCol1
            m_bsrcBuseSuppr.Add(oBuse)
        Next
        oCol1 = BancManager.getMaterielsSupprimes(agentCourant.idStructure)
        For Each oBanc As Banc In oCol1
            m_bsrcBancSuppr.Add(oBanc)
        Next
    End Sub

    Private Sub m_bsrcBancSuppr_CurrentChanged(sender As System.Object, e As System.EventArgs) Handles m_bsrcBancSuppr.CurrentChanged

    End Sub
End Class
