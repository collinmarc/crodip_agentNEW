<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagnostic_dlghelp12123newTrtSem

    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mesure1", 2, 2)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mesure2", 0, 0)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mesure3", 3, 3)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pompe1", 2, 2, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mesure1", 0, 0)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mesure2", 3, 2)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mesure3", 2, 2)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pompe2", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_dlghelp12123newTrtSem))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl12123 = New System.Windows.Forms.Panel()
        Me.rbFonctionnementCuillère = New System.Windows.Forms.RadioButton()
        Me.m_bsrcH12123 = New System.Windows.Forms.BindingSource(Me.components)
        Me.rbFonctinonementInjection = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.listImg_flags = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_PompeSuivante = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TbNumeric5 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TbNumeric4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.pnlDetailPompe = New System.Windows.Forms.Panel()
        Me.btnSupprimer = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDiagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BCalculeDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NumPompeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numeroMesurestr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QteGrainsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DebitSouhaiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pesee1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ecart1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pesee2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ecart2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pesee3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ecart3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeseeMoyenneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EcartMoyenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResultatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.m_bsrcMesures = New System.Windows.Forms.BindingSource(Me.components)
        Me.m_bsrcPompes = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbEcartMoyen = New CRODIP_ControlLibrary.TBNumeric()
        Me.laEcartMoyen = New System.Windows.Forms.Label()
        Me.tbPeseeMoyenne = New CRODIP_ControlLibrary.TBNumeric()
        Me.laPesseMoyenne = New System.Windows.Forms.Label()
        Me.btnValiderNbMesures = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.laResultat = New System.Windows.Forms.Label()
        Me.nupMesures = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pctResultat = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nupNbPompes = New System.Windows.Forms.NumericUpDown()
        Me.laResultatGlobal = New System.Windows.Forms.Label()
        Me.btnvaliderNbPompes = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.pnl12123.SuspendLayout()
        CType(Me.m_bsrcH12123, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlDetailPompe.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcMesures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcPompes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupMesures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctResultat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupNbPompes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl12123
        '
        Me.pnl12123.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl12123.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnl12123.Controls.Add(Me.rbFonctionnementCuillère)
        Me.pnl12123.Controls.Add(Me.rbFonctinonementInjection)
        Me.pnl12123.Controls.Add(Me.Label4)
        Me.pnl12123.Controls.Add(Me.Label1)
        Me.pnl12123.Controls.Add(Me.SplitContainer1)
        Me.pnl12123.Controls.Add(Me.nupNbPompes)
        Me.pnl12123.Controls.Add(Me.laResultatGlobal)
        Me.pnl12123.Controls.Add(Me.btnvaliderNbPompes)
        Me.pnl12123.Controls.Add(Me.Label18)
        Me.pnl12123.Controls.Add(Me.btnAnnuler)
        Me.pnl12123.Controls.Add(Me.btnValider)
        Me.pnl12123.Location = New System.Drawing.Point(6, 4)
        Me.pnl12123.Name = "pnl12123"
        Me.pnl12123.Size = New System.Drawing.Size(1027, 603)
        Me.pnl12123.TabIndex = 43
        '
        'rbFonctionnementCuillère
        '
        Me.rbFonctionnementCuillère.AutoSize = True
        Me.rbFonctionnementCuillère.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsrcH12123, "isCuillere", True))
        Me.rbFonctionnementCuillère.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFonctionnementCuillère.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.rbFonctionnementCuillère.Location = New System.Drawing.Point(752, 40)
        Me.rbFonctionnementCuillère.Name = "rbFonctionnementCuillère"
        Me.rbFonctionnementCuillère.Size = New System.Drawing.Size(87, 24)
        Me.rbFonctionnementCuillère.TabIndex = 84
        Me.rbFonctionnementCuillère.TabStop = True
        Me.rbFonctionnementCuillère.Text = "Cuillère"
        Me.rbFonctionnementCuillère.UseVisualStyleBackColor = True
        '
        'm_bsrcH12123
        '
        Me.m_bsrcH12123.DataSource = GetType(Crodip_agent.DiagnosticHelp12123)
        '
        'rbFonctinonementInjection
        '
        Me.rbFonctinonementInjection.AutoSize = True
        Me.rbFonctinonementInjection.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsrcH12123, "isInjection", True))
        Me.rbFonctinonementInjection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFonctinonementInjection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.rbFonctinonementInjection.Location = New System.Drawing.Point(655, 40)
        Me.rbFonctinonementInjection.Name = "rbFonctinonementInjection"
        Me.rbFonctinonementInjection.Size = New System.Drawing.Size(96, 24)
        Me.rbFonctinonementInjection.TabIndex = 83
        Me.rbFonctinonementInjection.TabStop = True
        Me.rbFonctinonementInjection.Text = "Injection"
        Me.rbFonctinonementInjection.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(436, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(223, 20)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Mode de fonctionnement : "
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(218, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(514, 26)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Controle du dispositif de dosage : Traitement des semences"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(11, 68)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_PompeSuivante)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TbNumeric5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TbNumeric4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlDetailPompe)
        Me.SplitContainer1.Size = New System.Drawing.Size(1011, 497)
        Me.SplitContainer1.SplitterDistance = 119
        Me.SplitContainer1.TabIndex = 79
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.listImg_flags
        Me.TreeView1.Location = New System.Drawing.Point(0, 3)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 2
        TreeNode1.Name = "Nœud1"
        TreeNode1.SelectedImageIndex = 2
        TreeNode1.Text = "Mesure1"
        TreeNode2.ImageIndex = 0
        TreeNode2.Name = "Nœud2"
        TreeNode2.SelectedImageIndex = 0
        TreeNode2.Text = "Mesure2"
        TreeNode3.ImageIndex = 3
        TreeNode3.Name = "Nœud3"
        TreeNode3.SelectedImageIndex = 3
        TreeNode3.Text = "Mesure3"
        TreeNode4.ImageIndex = 2
        TreeNode4.Name = "Nœud0"
        TreeNode4.SelectedImageIndex = 2
        TreeNode4.Text = "Pompe1"
        TreeNode5.ImageIndex = 0
        TreeNode5.Name = "Nœud5"
        TreeNode5.SelectedImageIndex = 0
        TreeNode5.Text = "Mesure1"
        TreeNode6.ImageIndex = 3
        TreeNode6.Name = "Nœud6"
        TreeNode6.SelectedImageIndex = 2
        TreeNode6.Text = "Mesure2"
        TreeNode7.ImageIndex = 2
        TreeNode7.Name = "Nœud7"
        TreeNode7.SelectedImageIndex = 2
        TreeNode7.Text = "Mesure3"
        TreeNode8.Name = "Nœud4"
        TreeNode8.Text = "Pompe2"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode8})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.Size = New System.Drawing.Size(117, 501)
        Me.TreeView1.TabIndex = 77
        '
        'listImg_flags
        '
        Me.listImg_flags.ImageStream = CType(resources.GetObject("listImg_flags.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.listImg_flags.TransparentColor = System.Drawing.Color.Transparent
        Me.listImg_flags.Images.SetKeyName(0, "MAJEUR")
        Me.listImg_flags.Images.SetKeyName(1, "OK")
        Me.listImg_flags.Images.SetKeyName(2, "MINEUR")
        Me.listImg_flags.Images.SetKeyName(3, "GRIS")
        '
        'btn_PompeSuivante
        '
        Me.btn_PompeSuivante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_PompeSuivante.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_PompeSuivante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_PompeSuivante.ForeColor = System.Drawing.Color.White
        Me.btn_PompeSuivante.Image = Global.Crodip_agent.Resources.btn_suivantGrd
        Me.btn_PompeSuivante.Location = New System.Drawing.Point(630, 456)
        Me.btn_PompeSuivante.Name = "btn_PompeSuivante"
        Me.btn_PompeSuivante.Size = New System.Drawing.Size(247, 24)
        Me.btn_PompeSuivante.TabIndex = 118
        Me.btn_PompeSuivante.Text = "    Pompe suivante"
        Me.btn_PompeSuivante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(13, 462)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Légende :"
        '
        'TbNumeric5
        '
        Me.TbNumeric5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TbNumeric5.BackColor = System.Drawing.Color.White
        Me.TbNumeric5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric5.ForceBindingOnTextChanged = False
        Me.TbNumeric5.Location = New System.Drawing.Point(210, 460)
        Me.TbNumeric5.Name = "TbNumeric5"
        Me.TbNumeric5.ReadOnly = True
        Me.TbNumeric5.Size = New System.Drawing.Size(100, 20)
        Me.TbNumeric5.TabIndex = 116
        Me.TbNumeric5.Text = "Zone de saisie"
        '
        'TbNumeric4
        '
        Me.TbNumeric4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TbNumeric4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TbNumeric4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric4.ForceBindingOnTextChanged = False
        Me.TbNumeric4.Location = New System.Drawing.Point(106, 460)
        Me.TbNumeric4.Name = "TbNumeric4"
        Me.TbNumeric4.ReadOnly = True
        Me.TbNumeric4.Size = New System.Drawing.Size(98, 20)
        Me.TbNumeric4.TabIndex = 115
        Me.TbNumeric4.TabStop = False
        Me.TbNumeric4.Text = "Zone calculée"
        '
        'pnlDetailPompe
        '
        Me.pnlDetailPompe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetailPompe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetailPompe.Controls.Add(Me.btnSupprimer)
        Me.pnlDetailPompe.Controls.Add(Me.DataGridView1)
        Me.pnlDetailPompe.Controls.Add(Me.tbEcartMoyen)
        Me.pnlDetailPompe.Controls.Add(Me.laEcartMoyen)
        Me.pnlDetailPompe.Controls.Add(Me.tbPeseeMoyenne)
        Me.pnlDetailPompe.Controls.Add(Me.laPesseMoyenne)
        Me.pnlDetailPompe.Controls.Add(Me.btnValiderNbMesures)
        Me.pnlDetailPompe.Controls.Add(Me.Label2)
        Me.pnlDetailPompe.Controls.Add(Me.laResultat)
        Me.pnlDetailPompe.Controls.Add(Me.nupMesures)
        Me.pnlDetailPompe.Controls.Add(Me.Label3)
        Me.pnlDetailPompe.Controls.Add(Me.pctResultat)
        Me.pnlDetailPompe.Controls.Add(Me.Label10)
        Me.pnlDetailPompe.Location = New System.Drawing.Point(6, 3)
        Me.pnlDetailPompe.Name = "pnlDetailPompe"
        Me.pnlDetailPompe.Size = New System.Drawing.Size(879, 405)
        Me.pnlDetailPompe.TabIndex = 78
        '
        'btnSupprimer
        '
        Me.btnSupprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupprimer.ForeColor = System.Drawing.Color.White
        Me.btnSupprimer.Image = Global.Crodip_agent.Resources.btn_delete
        Me.btnSupprimer.Location = New System.Drawing.Point(4, 30)
        Me.btnSupprimer.Name = "btnSupprimer"
        Me.btnSupprimer.Size = New System.Drawing.Size(128, 24)
        Me.btnSupprimer.TabIndex = 117
        Me.btnSupprimer.Text = "    Supprimer"
        Me.btnSupprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.IdDiagDataGridViewTextBoxColumn, Me.BCalculeDataGridViewCheckBoxColumn, Me.NumPompeDataGridViewTextBoxColumn, Me.numeroMesurestr, Me.QteGrainsDataGridViewTextBoxColumn, Me.DebitSouhaiteDataGridViewTextBoxColumn, Me.Pesee1DataGridViewTextBoxColumn, Me.Ecart1DataGridViewTextBoxColumn, Me.Pesee2DataGridViewTextBoxColumn, Me.Ecart2DataGridViewTextBoxColumn, Me.Pesee3DataGridViewTextBoxColumn, Me.Ecart3DataGridViewTextBoxColumn, Me.PeseeMoyenneDataGridViewTextBoxColumn, Me.EcartMoyenDataGridViewTextBoxColumn, Me.ResultatDataGridViewTextBoxColumn, Me.ImageDataGridViewImageColumn})
        Me.DataGridView1.DataSource = Me.m_bsrcMesures
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.Location = New System.Drawing.Point(8, 88)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(861, 150)
        Me.DataGridView1.TabIndex = 116
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'IdDiagDataGridViewTextBoxColumn
        '
        Me.IdDiagDataGridViewTextBoxColumn.DataPropertyName = "idDiag"
        Me.IdDiagDataGridViewTextBoxColumn.HeaderText = "idDiag"
        Me.IdDiagDataGridViewTextBoxColumn.Name = "IdDiagDataGridViewTextBoxColumn"
        Me.IdDiagDataGridViewTextBoxColumn.Visible = False
        '
        'BCalculeDataGridViewCheckBoxColumn
        '
        Me.BCalculeDataGridViewCheckBoxColumn.DataPropertyName = "bCalcule"
        Me.BCalculeDataGridViewCheckBoxColumn.HeaderText = "bCalcule"
        Me.BCalculeDataGridViewCheckBoxColumn.Name = "BCalculeDataGridViewCheckBoxColumn"
        Me.BCalculeDataGridViewCheckBoxColumn.Visible = False
        '
        'NumPompeDataGridViewTextBoxColumn
        '
        Me.NumPompeDataGridViewTextBoxColumn.DataPropertyName = "numPompe"
        Me.NumPompeDataGridViewTextBoxColumn.HeaderText = "numPompe"
        Me.NumPompeDataGridViewTextBoxColumn.Name = "NumPompeDataGridViewTextBoxColumn"
        Me.NumPompeDataGridViewTextBoxColumn.Visible = False
        '
        'numeroMesurestr
        '
        Me.numeroMesurestr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.numeroMesurestr.DataPropertyName = "numeroMesurestr"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.numeroMesurestr.DefaultCellStyle = DataGridViewCellStyle2
        Me.numeroMesurestr.HeaderText = "Mesure"
        Me.numeroMesurestr.Name = "numeroMesurestr"
        Me.numeroMesurestr.ReadOnly = True
        Me.numeroMesurestr.Width = 87
        '
        'QteGrainsDataGridViewTextBoxColumn
        '
        Me.QteGrainsDataGridViewTextBoxColumn.DataPropertyName = "qteGrains"
        Me.QteGrainsDataGridViewTextBoxColumn.HeaderText = "Qté grains (kg)"
        Me.QteGrainsDataGridViewTextBoxColumn.Name = "QteGrainsDataGridViewTextBoxColumn"
        '
        'DebitSouhaiteDataGridViewTextBoxColumn
        '
        Me.DebitSouhaiteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DebitSouhaiteDataGridViewTextBoxColumn.DataPropertyName = "DebitSouhaite"
        Me.DebitSouhaiteDataGridViewTextBoxColumn.HeaderText = "Débit souhaité"
        Me.DebitSouhaiteDataGridViewTextBoxColumn.Name = "DebitSouhaiteDataGridViewTextBoxColumn"
        Me.DebitSouhaiteDataGridViewTextBoxColumn.Width = 80
        '
        'Pesee1DataGridViewTextBoxColumn
        '
        Me.Pesee1DataGridViewTextBoxColumn.DataPropertyName = "Pesee1"
        Me.Pesee1DataGridViewTextBoxColumn.HeaderText = "Pesée 1"
        Me.Pesee1DataGridViewTextBoxColumn.Name = "Pesee1DataGridViewTextBoxColumn"
        '
        'Ecart1DataGridViewTextBoxColumn
        '
        Me.Ecart1DataGridViewTextBoxColumn.DataPropertyName = "Ecart1"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.Ecart1DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.Ecart1DataGridViewTextBoxColumn.HeaderText = "Ecart 1 %"
        Me.Ecart1DataGridViewTextBoxColumn.Name = "Ecart1DataGridViewTextBoxColumn"
        Me.Ecart1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Pesee2DataGridViewTextBoxColumn
        '
        Me.Pesee2DataGridViewTextBoxColumn.DataPropertyName = "Pesee2"
        Me.Pesee2DataGridViewTextBoxColumn.HeaderText = "Pesée 2"
        Me.Pesee2DataGridViewTextBoxColumn.Name = "Pesee2DataGridViewTextBoxColumn"
        '
        'Ecart2DataGridViewTextBoxColumn
        '
        Me.Ecart2DataGridViewTextBoxColumn.DataPropertyName = "Ecart2"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.Ecart2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.Ecart2DataGridViewTextBoxColumn.HeaderText = "Ecart 2 %"
        Me.Ecart2DataGridViewTextBoxColumn.Name = "Ecart2DataGridViewTextBoxColumn"
        Me.Ecart2DataGridViewTextBoxColumn.ReadOnly = True
        '
        'Pesee3DataGridViewTextBoxColumn
        '
        Me.Pesee3DataGridViewTextBoxColumn.DataPropertyName = "Pesee3"
        Me.Pesee3DataGridViewTextBoxColumn.HeaderText = "Pesée 3"
        Me.Pesee3DataGridViewTextBoxColumn.Name = "Pesee3DataGridViewTextBoxColumn"
        '
        'Ecart3DataGridViewTextBoxColumn
        '
        Me.Ecart3DataGridViewTextBoxColumn.DataPropertyName = "Ecart3"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.Ecart3DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.Ecart3DataGridViewTextBoxColumn.HeaderText = "Ecart 3 %"
        Me.Ecart3DataGridViewTextBoxColumn.Name = "Ecart3DataGridViewTextBoxColumn"
        Me.Ecart3DataGridViewTextBoxColumn.ReadOnly = True
        '
        'PeseeMoyenneDataGridViewTextBoxColumn
        '
        Me.PeseeMoyenneDataGridViewTextBoxColumn.DataPropertyName = "PeseeMoyenne"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.PeseeMoyenneDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.PeseeMoyenneDataGridViewTextBoxColumn.HeaderText = "Pesée Moy."
        Me.PeseeMoyenneDataGridViewTextBoxColumn.Name = "PeseeMoyenneDataGridViewTextBoxColumn"
        Me.PeseeMoyenneDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EcartMoyenDataGridViewTextBoxColumn
        '
        Me.EcartMoyenDataGridViewTextBoxColumn.DataPropertyName = "EcartMoyen"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.EcartMoyenDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.EcartMoyenDataGridViewTextBoxColumn.HeaderText = "Ecart Moy."
        Me.EcartMoyenDataGridViewTextBoxColumn.Name = "EcartMoyenDataGridViewTextBoxColumn"
        Me.EcartMoyenDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ResultatDataGridViewTextBoxColumn
        '
        Me.ResultatDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ResultatDataGridViewTextBoxColumn.DataPropertyName = "ResultatLabel"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.ResultatDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.ResultatDataGridViewTextBoxColumn.HeaderText = "Résultat"
        Me.ResultatDataGridViewTextBoxColumn.Name = "ResultatDataGridViewTextBoxColumn"
        Me.ResultatDataGridViewTextBoxColumn.ReadOnly = True
        Me.ResultatDataGridViewTextBoxColumn.Width = 80
        '
        'ImageDataGridViewImageColumn
        '
        Me.ImageDataGridViewImageColumn.DataPropertyName = "Image"
        Me.ImageDataGridViewImageColumn.HeaderText = ""
        Me.ImageDataGridViewImageColumn.Name = "ImageDataGridViewImageColumn"
        '
        'm_bsrcMesures
        '
        Me.m_bsrcMesures.DataMember = "lstMesures"
        Me.m_bsrcMesures.DataSource = Me.m_bsrcPompes
        '
        'm_bsrcPompes
        '
        Me.m_bsrcPompes.DataMember = "lstPompesTrtSem"
        Me.m_bsrcPompes.DataSource = Me.m_bsrcH12123
        '
        'tbEcartMoyen
        '
        Me.tbEcartMoyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbEcartMoyen.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tbEcartMoyen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEcartMoyen.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "EcartReglageMoyen", True))
        Me.tbEcartMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEcartMoyen.ForceBindingOnTextChanged = False
        Me.tbEcartMoyen.Location = New System.Drawing.Point(726, 281)
        Me.tbEcartMoyen.Name = "tbEcartMoyen"
        Me.tbEcartMoyen.ReadOnly = True
        Me.tbEcartMoyen.Size = New System.Drawing.Size(98, 26)
        Me.tbEcartMoyen.TabIndex = 115
        Me.tbEcartMoyen.TabStop = False
        '
        'laEcartMoyen
        '
        Me.laEcartMoyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laEcartMoyen.AutoSize = True
        Me.laEcartMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laEcartMoyen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laEcartMoyen.Location = New System.Drawing.Point(614, 283)
        Me.laEcartMoyen.Name = "laEcartMoyen"
        Me.laEcartMoyen.Size = New System.Drawing.Size(106, 20)
        Me.laEcartMoyen.TabIndex = 114
        Me.laEcartMoyen.Text = "Ecart moyen :"
        '
        'tbPeseeMoyenne
        '
        Me.tbPeseeMoyenne.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tbPeseeMoyenne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPeseeMoyenne.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "PeseeMoyenne", True))
        Me.tbPeseeMoyenne.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPeseeMoyenne.ForceBindingOnTextChanged = False
        Me.tbPeseeMoyenne.Location = New System.Drawing.Point(311, 281)
        Me.tbPeseeMoyenne.Name = "tbPeseeMoyenne"
        Me.tbPeseeMoyenne.ReadOnly = True
        Me.tbPeseeMoyenne.Size = New System.Drawing.Size(100, 26)
        Me.tbPeseeMoyenne.TabIndex = 113
        Me.tbPeseeMoyenne.TabStop = False
        '
        'laPesseMoyenne
        '
        Me.laPesseMoyenne.AutoSize = True
        Me.laPesseMoyenne.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laPesseMoyenne.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laPesseMoyenne.Location = New System.Drawing.Point(171, 283)
        Me.laPesseMoyenne.Name = "laPesseMoyenne"
        Me.laPesseMoyenne.Size = New System.Drawing.Size(131, 20)
        Me.laPesseMoyenne.TabIndex = 112
        Me.laPesseMoyenne.Text = "Pesée moyenne :"
        '
        'btnValiderNbMesures
        '
        Me.btnValiderNbMesures.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValiderNbMesures.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValiderNbMesures.ForeColor = System.Drawing.Color.White
        Me.btnValiderNbMesures.Image = CType(resources.GetObject("btnValiderNbMesures.Image"), System.Drawing.Image)
        Me.btnValiderNbMesures.Location = New System.Drawing.Point(741, 49)
        Me.btnValiderNbMesures.Name = "btnValiderNbMesures"
        Me.btnValiderNbMesures.Size = New System.Drawing.Size(128, 24)
        Me.btnValiderNbMesures.TabIndex = 111
        Me.btnValiderNbMesures.Text = "    Valider"
        Me.btnValiderNbMesures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(345, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "MESURES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'laResultat
        '
        Me.laResultat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laResultat.AutoSize = True
        Me.laResultat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "LabelResultat", True))
        Me.laResultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laResultat.ForeColor = System.Drawing.Color.OliveDrab
        Me.laResultat.Location = New System.Drawing.Point(795, 8)
        Me.laResultat.Name = "laResultat"
        Me.laResultat.Size = New System.Drawing.Size(77, 20)
        Me.laResultat.TabIndex = 108
        Me.laResultat.Text = "Resultat"
        Me.laResultat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'nupMesures
        '
        Me.nupMesures.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nupMesures.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupMesures.Location = New System.Drawing.Point(666, 49)
        Me.nupMesures.Name = "nupMesures"
        Me.nupMesures.Size = New System.Drawing.Size(40, 26)
        Me.nupMesures.TabIndex = 77
        Me.nupMesures.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(556, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 20)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Nb mesures"
        '
        'pctResultat
        '
        Me.pctResultat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctResultat.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.m_bsrcPompes, "Image", True))
        Me.pctResultat.Image = Global.Crodip_agent.Resources.PuceVerteT
        Me.pctResultat.Location = New System.Drawing.Point(760, 10)
        Me.pctResultat.Name = "pctResultat"
        Me.pctResultat.Size = New System.Drawing.Size(18, 20)
        Me.pctResultat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctResultat.TabIndex = 1
        Me.pctResultat.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "Nom", True))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(4, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Pompe 1 "
        '
        'nupNbPompes
        '
        Me.nupNbPompes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupNbPompes.Location = New System.Drawing.Point(193, 42)
        Me.nupNbPompes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupNbPompes.Name = "nupNbPompes"
        Me.nupNbPompes.Size = New System.Drawing.Size(40, 26)
        Me.nupNbPompes.TabIndex = 75
        Me.nupNbPompes.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'laResultatGlobal
        '
        Me.laResultatGlobal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laResultatGlobal.AutoSize = True
        Me.laResultatGlobal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcH12123, "LabelResultat", True))
        Me.laResultatGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laResultatGlobal.ForeColor = System.Drawing.Color.Red
        Me.laResultatGlobal.Location = New System.Drawing.Point(899, 127)
        Me.laResultatGlobal.Name = "laResultatGlobal"
        Me.laResultatGlobal.Size = New System.Drawing.Size(113, 16)
        Me.laResultatGlobal.TabIndex = 74
        Me.laResultatGlobal.Text = "Résultat global"
        Me.laResultatGlobal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnvaliderNbPompes
        '
        Me.btnvaliderNbPompes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnvaliderNbPompes.ForeColor = System.Drawing.Color.White
        Me.btnvaliderNbPompes.Image = CType(resources.GetObject("btnvaliderNbPompes.Image"), System.Drawing.Image)
        Me.btnvaliderNbPompes.Location = New System.Drawing.Point(239, 42)
        Me.btnvaliderNbPompes.Name = "btnvaliderNbPompes"
        Me.btnvaliderNbPompes.Size = New System.Drawing.Size(128, 24)
        Me.btnvaliderNbPompes.TabIndex = 48
        Me.btnvaliderNbPompes.Text = "    Valider"
        Me.btnvaliderNbPompes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(8, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(181, 20)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "Nb pompes doseuses"
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAnnuler.BackgroundImage = Global.Crodip_agent.Resources.btn_annuler
        Me.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.FlatAppearance.BorderSize = 0
        Me.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Location = New System.Drawing.Point(877, 571)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(134, 25)
        Me.btnAnnuler.TabIndex = 43
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = False
        '
        'btnValider
        '
        Me.btnValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValider.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnValider.BackgroundImage = Global.Crodip_agent.Resources.btn_valider
        Me.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnValider.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnValider.FlatAppearance.BorderSize = 0
        Me.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnValider.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValider.ForeColor = System.Drawing.Color.White
        Me.btnValider.Location = New System.Drawing.Point(717, 571)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(138, 25)
        Me.btnValider.TabIndex = 42
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = False
        '
        'diagnostic_dlghelp12123newTrtSem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 612)
        Me.Controls.Add(Me.pnl12123)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diagnostic_dlghelp12123newTrtSem"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Controle du dispositif de dosage"
        Me.pnl12123.ResumeLayout(False)
        Me.pnl12123.PerformLayout()
        CType(Me.m_bsrcH12123, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlDetailPompe.ResumeLayout(False)
        Me.pnlDetailPompe.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcMesures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcPompes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupMesures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctResultat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupNbPompes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents m_bsrcH12123 As System.Windows.Forms.BindingSource
    Friend WithEvents pnl12123 As System.Windows.Forms.Panel
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents btnValider As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnvaliderNbPompes As System.Windows.Forms.Label
    Friend WithEvents listImg_flags As System.Windows.Forms.ImageList
    Friend WithEvents laResultatGlobal As System.Windows.Forms.Label
    Friend WithEvents nupNbPompes As System.Windows.Forms.NumericUpDown
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlDetailPompe As System.Windows.Forms.Panel
    Friend WithEvents nupMesures As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pctResultat As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents laResultat As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents m_bsrcMesures As System.Windows.Forms.BindingSource
    Friend WithEvents MasseApresAspiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MasseApresComplementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents m_bsrcPompes As System.Windows.Forms.BindingSource
    Friend WithEvents btnValiderNbMesures As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric5 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents TbNumeric4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents btn_PompeSuivante As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbEcartMoyen As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents laEcartMoyen As System.Windows.Forms.Label
    Friend WithEvents tbPeseeMoyenne As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents laPesseMoyenne As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDiagDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BCalculeDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NumPompeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numeroMesurestr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QteGrainsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitSouhaiteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pesee1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ecart1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pesee2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ecart2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pesee3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ecart3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeseeMoyenneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EcartMoyenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ResultatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents rbFonctionnementCuillère As System.Windows.Forms.RadioButton
    Friend WithEvents rbFonctinonementInjection As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSupprimer As System.Windows.Forms.Label

End Class
