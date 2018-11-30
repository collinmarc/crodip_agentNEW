<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class diagnostic_dlghelp12123newTrtSem

    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.pnl12123 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.listImg_flags = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlDetailPompe = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.m_bsrcMesures = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TbNumeric10 = New CRODIP_ControlLibrary.TBNumeric()
        Me.m_bsrcPompes = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TbNumeric9 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nupMesures = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nupNbPompes = New System.Windows.Forms.NumericUpDown()
        Me.lblResultat12123 = New System.Windows.Forms.Label()
        Me.btnvaliderNbPompes = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDiagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BCalculeDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ResultatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.LstPompesTrtSemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnl12123.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlDetailPompe.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcMesures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcPompes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupMesures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupNbPompes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LstPompesTrtSemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl12123
        '
        Me.pnl12123.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl12123.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnl12123.Controls.Add(Me.SplitContainer1)
        Me.pnl12123.Controls.Add(Me.nupNbPompes)
        Me.pnl12123.Controls.Add(Me.lblResultat12123)
        Me.pnl12123.Controls.Add(Me.btnvaliderNbPompes)
        Me.pnl12123.Controls.Add(Me.Label18)
        Me.pnl12123.Controls.Add(Me.Label1)
        Me.pnl12123.Controls.Add(Me.btnAnnuler)
        Me.pnl12123.Controls.Add(Me.btnValider)
        Me.pnl12123.Location = New System.Drawing.Point(6, 4)
        Me.pnl12123.Name = "pnl12123"
        Me.pnl12123.Size = New System.Drawing.Size(713, 517)
        Me.pnl12123.TabIndex = 43
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlDetailPompe)
        Me.SplitContainer1.Size = New System.Drawing.Size(697, 411)
        Me.SplitContainer1.SplitterDistance = 101
        Me.SplitContainer1.TabIndex = 79
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.listImg_flags
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
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
        Me.TreeView1.Size = New System.Drawing.Size(101, 411)
        Me.TreeView1.TabIndex = 77
        '
        'listImg_flags
        '
        Me.listImg_flags.ImageStream = CType(resources.GetObject("listImg_flags.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.listImg_flags.TransparentColor = System.Drawing.Color.Transparent
        Me.listImg_flags.Images.SetKeyName(0, "")
        Me.listImg_flags.Images.SetKeyName(1, "")
        Me.listImg_flags.Images.SetKeyName(2, "")
        Me.listImg_flags.Images.SetKeyName(3, "")
        '
        'pnlDetailPompe
        '
        Me.pnlDetailPompe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetailPompe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetailPompe.Controls.Add(Me.Label2)
        Me.pnlDetailPompe.Controls.Add(Me.DataGridView1)
        Me.pnlDetailPompe.Controls.Add(Me.Label16)
        Me.pnlDetailPompe.Controls.Add(Me.TbNumeric10)
        Me.pnlDetailPompe.Controls.Add(Me.Label14)
        Me.pnlDetailPompe.Controls.Add(Me.TbNumeric9)
        Me.pnlDetailPompe.Controls.Add(Me.Label13)
        Me.pnlDetailPompe.Controls.Add(Me.nupMesures)
        Me.pnlDetailPompe.Controls.Add(Me.Label3)
        Me.pnlDetailPompe.Controls.Add(Me.PictureBox1)
        Me.pnlDetailPompe.Controls.Add(Me.Label10)
        Me.pnlDetailPompe.Location = New System.Drawing.Point(6, 3)
        Me.pnlDetailPompe.Name = "pnlDetailPompe"
        Me.pnlDetailPompe.Size = New System.Drawing.Size(585, 405)
        Me.pnlDetailPompe.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(256, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "MESURES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.IdDiagDataGridViewTextBoxColumn, Me.BCalculeDataGridViewCheckBoxColumn, Me.ResultatDataGridViewTextBoxColumn, Me.ImageDataGridViewImageColumn})
        Me.DataGridView1.DataSource = Me.m_bsrcMesures
        Me.DataGridView1.Location = New System.Drawing.Point(6, 83)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(575, 227)
        Me.DataGridView1.TabIndex = 109
        '
        'm_bsrcMesures
        '
        Me.m_bsrcMesures.DataSource = Me.LstPompesTrtSemBindingSource
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.OliveDrab
        Me.Label16.Location = New System.Drawing.Point(461, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(28, 16)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "OK"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TbNumeric10
        '
        Me.TbNumeric10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbNumeric10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TbNumeric10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric10.ForceBindingOnTextChanged = False
        Me.TbNumeric10.Location = New System.Drawing.Point(483, 316)
        Me.TbNumeric10.Name = "TbNumeric10"
        Me.TbNumeric10.ReadOnly = True
        Me.TbNumeric10.Size = New System.Drawing.Size(98, 20)
        Me.TbNumeric10.TabIndex = 90
        Me.TbNumeric10.TabStop = False
        '
        'm_bsrcPompes
        '
        Me.m_bsrcPompes.DataSource = GetType(Crodip_agent.DiagnosticHelp12123)
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(409, 318)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 89
        Me.Label14.Text = "Ecart moyen :"
        '
        'TbNumeric9
        '
        Me.TbNumeric9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TbNumeric9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric9.ForceBindingOnTextChanged = False
        Me.TbNumeric9.Location = New System.Drawing.Point(242, 316)
        Me.TbNumeric9.Name = "TbNumeric9"
        Me.TbNumeric9.ReadOnly = True
        Me.TbNumeric9.Size = New System.Drawing.Size(100, 20)
        Me.TbNumeric9.TabIndex = 88
        Me.TbNumeric9.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(147, 318)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Pesée moyenne :"
        '
        'nupMesures
        '
        Me.nupMesures.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nupMesures.Location = New System.Drawing.Point(522, 57)
        Me.nupMesures.Name = "nupMesures"
        Me.nupMesures.Size = New System.Drawing.Size(40, 20)
        Me.nupMesures.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(436, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Nb mesures"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Crodip_agent.Resources.PuceVerteT
        Me.PictureBox1.Location = New System.Drawing.Point(410, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(18, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(4, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Pompe 1 "
        '
        'nupNbPompes
        '
        Me.nupNbPompes.Location = New System.Drawing.Point(148, 42)
        Me.nupNbPompes.Name = "nupNbPompes"
        Me.nupNbPompes.Size = New System.Drawing.Size(40, 20)
        Me.nupNbPompes.TabIndex = 75
        '
        'lblResultat12123
        '
        Me.lblResultat12123.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResultat12123.AutoSize = True
        Me.lblResultat12123.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultat12123.ForeColor = System.Drawing.Color.Red
        Me.lblResultat12123.Location = New System.Drawing.Point(548, 46)
        Me.lblResultat12123.Name = "lblResultat12123"
        Me.lblResultat12123.Size = New System.Drawing.Size(113, 16)
        Me.lblResultat12123.TabIndex = 74
        Me.lblResultat12123.Text = "Résultat global"
        Me.lblResultat12123.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnvaliderNbPompes
        '
        Me.btnvaliderNbPompes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnvaliderNbPompes.ForeColor = System.Drawing.Color.White
        Me.btnvaliderNbPompes.Image = CType(resources.GetObject("btnvaliderNbPompes.Image"), System.Drawing.Image)
        Me.btnvaliderNbPompes.Location = New System.Drawing.Point(194, 38)
        Me.btnvaliderNbPompes.Name = "btnvaliderNbPompes"
        Me.btnvaliderNbPompes.Size = New System.Drawing.Size(128, 24)
        Me.btnvaliderNbPompes.TabIndex = 48
        Me.btnvaliderNbPompes.Text = "    Valider"
        Me.btnvaliderNbPompes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(8, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 13)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "Nb pompes doseuses"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(61, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(514, 26)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Controle du dispositif de dosage : Traitement des semences"
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
        Me.btnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Location = New System.Drawing.Point(563, 485)
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
        Me.btnValider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValider.ForeColor = System.Drawing.Color.White
        Me.btnValider.Location = New System.Drawing.Point(403, 485)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(138, 25)
        Me.btnValider.TabIndex = 42
        Me.btnValider.Text = "OK"
        Me.btnValider.UseVisualStyleBackColor = False
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        '
        'IdDiagDataGridViewTextBoxColumn
        '
        Me.IdDiagDataGridViewTextBoxColumn.DataPropertyName = "idDiag"
        Me.IdDiagDataGridViewTextBoxColumn.HeaderText = "idDiag"
        Me.IdDiagDataGridViewTextBoxColumn.Name = "IdDiagDataGridViewTextBoxColumn"
        '
        'BCalculeDataGridViewCheckBoxColumn
        '
        Me.BCalculeDataGridViewCheckBoxColumn.DataPropertyName = "bCalcule"
        Me.BCalculeDataGridViewCheckBoxColumn.HeaderText = "bCalcule"
        Me.BCalculeDataGridViewCheckBoxColumn.Name = "BCalculeDataGridViewCheckBoxColumn"
        '
        'ResultatDataGridViewTextBoxColumn
        '
        Me.ResultatDataGridViewTextBoxColumn.DataPropertyName = "Resultat"
        Me.ResultatDataGridViewTextBoxColumn.HeaderText = "Resultat"
        Me.ResultatDataGridViewTextBoxColumn.Name = "ResultatDataGridViewTextBoxColumn"
        '
        'ImageDataGridViewImageColumn
        '
        Me.ImageDataGridViewImageColumn.DataPropertyName = "Image"
        Me.ImageDataGridViewImageColumn.HeaderText = "Image"
        Me.ImageDataGridViewImageColumn.Name = "ImageDataGridViewImageColumn"
        Me.ImageDataGridViewImageColumn.ReadOnly = True
        '
        'LstPompesTrtSemBindingSource
        '
        Me.LstPompesTrtSemBindingSource.DataMember = "lstPompesTrtSem"
        Me.LstPompesTrtSemBindingSource.DataSource = Me.m_bsrcPompes
        '
        'diagnostic_dlghelp12123newTrtSem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(726, 526)
        Me.Controls.Add(Me.pnl12123)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diagnostic_dlghelp12123newTrtSem"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.pnl12123.ResumeLayout(False)
        Me.pnl12123.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlDetailPompe.ResumeLayout(False)
        Me.pnlDetailPompe.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcMesures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcPompes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupMesures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupNbPompes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LstPompesTrtSemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents m_bsrcPompes As System.Windows.Forms.BindingSource
    Friend WithEvents pnl12123 As System.Windows.Forms.Panel
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents btnValider As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents listImg_flags As System.Windows.Forms.ImageList
    Friend WithEvents lblResultat12123 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents m_bsrcMesures As System.Windows.Forms.BindingSource
    Friend WithEvents pnlDetailPompe As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label16 As Label
    Friend WithEvents TbNumeric10 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label14 As Label
    Friend WithEvents TbNumeric9 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label13 As Label
    Friend WithEvents nupMesures As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents nupNbPompes As NumericUpDown
    Friend WithEvents btnvaliderNbPompes As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDiagDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BCalculeDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ResultatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents LstPompesTrtSemBindingSource As System.Windows.Forms.BindingSource
End Class
