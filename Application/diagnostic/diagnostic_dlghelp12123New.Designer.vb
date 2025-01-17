Imports CRODIPWS

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class diagnostic_dlghelp12123new

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_dlghelp12123new))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl12123 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.listImg_flags = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_PompeSuivante = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TbNumeric5 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TbNumeric4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TbNumeric3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.pnlDetailPompe = New System.Windows.Forms.Panel()
        Me.laEcartMoyen = New System.Windows.Forms.Label()
        Me.tbEcartMoyen = New CRODIP_ControlLibrary.TBNumeric()
        Me.m_bsrcPompes = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnValiderNbMesures = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.m_bsrcMesures = New System.Windows.Forms.BindingSource(Me.components)
        Me.laResultat = New System.Windows.Forms.Label()
        Me.TbNumeric10 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TbNumeric9 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TbNumeric1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TbNumeric2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nupMesures = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TbNumeric8 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TbNumeric7 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pctResultat = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nupNbPompes = New System.Windows.Forms.NumericUpDown()
        Me.laResultatGlobal = New System.Windows.Forms.Label()
        Me.btnvaliderNbPompes = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.m_bsrcH12123 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ImageDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReglageDispositif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DebitTheoriqueRND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempsMesure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QteEauPulveriseeRND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MasseInitiale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MasseAspire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QteProduitConso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DosageReelRND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EcartReglageRND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnl12123.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlDetailPompe.SuspendLayout()
        CType(Me.m_bsrcPompes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcMesures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupMesures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctResultat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupNbPompes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcH12123, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnl12123.Controls.Add(Me.laResultatGlobal)
        Me.pnl12123.Controls.Add(Me.btnvaliderNbPompes)
        Me.pnl12123.Controls.Add(Me.Label18)
        Me.pnl12123.Controls.Add(Me.Label1)
        Me.pnl12123.Controls.Add(Me.btnAnnuler)
        Me.pnl12123.Controls.Add(Me.btnValider)
        Me.pnl12123.Location = New System.Drawing.Point(6, 4)
        Me.pnl12123.Name = "pnl12123"
        Me.pnl12123.Size = New System.Drawing.Size(954, 603)
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_PompeSuivante)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TbNumeric5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TbNumeric4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TbNumeric3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlDetailPompe)
        Me.SplitContainer1.Size = New System.Drawing.Size(938, 497)
        Me.SplitContainer1.SplitterDistance = 111
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
        Me.TreeView1.Size = New System.Drawing.Size(109, 501)
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
        Me.btn_PompeSuivante.Location = New System.Drawing.Point(565, 456)
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
        Me.Label6.Location = New System.Drawing.Point(8, 446)
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
        Me.TbNumeric5.Location = New System.Drawing.Point(214, 474)
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
        Me.TbNumeric4.Location = New System.Drawing.Point(110, 474)
        Me.TbNumeric4.Name = "TbNumeric4"
        Me.TbNumeric4.ReadOnly = True
        Me.TbNumeric4.Size = New System.Drawing.Size(98, 20)
        Me.TbNumeric4.TabIndex = 115
        Me.TbNumeric4.TabStop = False
        Me.TbNumeric4.Text = "Zone calculée"
        '
        'TbNumeric3
        '
        Me.TbNumeric3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TbNumeric3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TbNumeric3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbNumeric3.ForceBindingOnTextChanged = False
        Me.TbNumeric3.Location = New System.Drawing.Point(6, 474)
        Me.TbNumeric3.Name = "TbNumeric3"
        Me.TbNumeric3.ReadOnly = True
        Me.TbNumeric3.Size = New System.Drawing.Size(98, 20)
        Me.TbNumeric3.TabIndex = 114
        Me.TbNumeric3.TabStop = False
        Me.TbNumeric3.Text = "Zone récupérée"
        '
        'pnlDetailPompe
        '
        Me.pnlDetailPompe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetailPompe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDetailPompe.Controls.Add(Me.laEcartMoyen)
        Me.pnlDetailPompe.Controls.Add(Me.tbEcartMoyen)
        Me.pnlDetailPompe.Controls.Add(Me.btnValiderNbMesures)
        Me.pnlDetailPompe.Controls.Add(Me.Label2)
        Me.pnlDetailPompe.Controls.Add(Me.DataGridView1)
        Me.pnlDetailPompe.Controls.Add(Me.laResultat)
        Me.pnlDetailPompe.Controls.Add(Me.TbNumeric10)
        Me.pnlDetailPompe.Controls.Add(Me.Label14)
        Me.pnlDetailPompe.Controls.Add(Me.TbNumeric9)
        Me.pnlDetailPompe.Controls.Add(Me.Label13)
        Me.pnlDetailPompe.Controls.Add(Me.TbNumeric1)
        Me.pnlDetailPompe.Controls.Add(Me.Label8)
        Me.pnlDetailPompe.Controls.Add(Me.TbNumeric2)
        Me.pnlDetailPompe.Controls.Add(Me.Label9)
        Me.pnlDetailPompe.Controls.Add(Me.nupMesures)
        Me.pnlDetailPompe.Controls.Add(Me.Label3)
        Me.pnlDetailPompe.Controls.Add(Me.Label12)
        Me.pnlDetailPompe.Controls.Add(Me.TbNumeric8)
        Me.pnlDetailPompe.Controls.Add(Me.TbNumeric7)
        Me.pnlDetailPompe.Controls.Add(Me.Label11)
        Me.pnlDetailPompe.Controls.Add(Me.pctResultat)
        Me.pnlDetailPompe.Controls.Add(Me.Label10)
        Me.pnlDetailPompe.Location = New System.Drawing.Point(6, 3)
        Me.pnlDetailPompe.Name = "pnlDetailPompe"
        Me.pnlDetailPompe.Size = New System.Drawing.Size(814, 405)
        Me.pnlDetailPompe.TabIndex = 78
        '
        'laEcartMoyen
        '
        Me.laEcartMoyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laEcartMoyen.AutoSize = True
        Me.laEcartMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laEcartMoyen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.laEcartMoyen.Location = New System.Drawing.Point(564, 123)
        Me.laEcartMoyen.Name = "laEcartMoyen"
        Me.laEcartMoyen.Size = New System.Drawing.Size(119, 20)
        Me.laEcartMoyen.TabIndex = 114
        Me.laEcartMoyen.Text = "Ecart moyen :"
        '
        'tbEcartMoyen
        '
        Me.tbEcartMoyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbEcartMoyen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbEcartMoyen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEcartMoyen.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "EcartReglageMoyen", True))
        Me.tbEcartMoyen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEcartMoyen.ForceBindingOnTextChanged = False
        Me.tbEcartMoyen.Location = New System.Drawing.Point(707, 121)
        Me.tbEcartMoyen.Name = "tbEcartMoyen"
        Me.tbEcartMoyen.ReadOnly = True
        Me.tbEcartMoyen.Size = New System.Drawing.Size(100, 26)
        Me.tbEcartMoyen.TabIndex = 113
        Me.tbEcartMoyen.TabStop = False
        '
        'm_bsrcPompes
        '
        Me.m_bsrcPompes.DataMember = "lstPompes"
        Me.m_bsrcPompes.DataSource = Me.m_bsrcH12123
        '
        'btnValiderNbMesures
        '
        Me.btnValiderNbMesures.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValiderNbMesures.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValiderNbMesures.ForeColor = System.Drawing.Color.White
        Me.btnValiderNbMesures.Image = CType(resources.GetObject("btnValiderNbMesures.Image"), System.Drawing.Image)
        Me.btnValiderNbMesures.Location = New System.Drawing.Point(679, 182)
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
        Me.Label2.Location = New System.Drawing.Point(348, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "MESURES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ImageDataGridViewImageColumn, Me.Column2, Me.ReglageDispositif, Me.DebitTheoriqueRND, Me.TempsMesure, Me.QteEauPulveriseeRND, Me.MasseInitiale, Me.MasseAspire, Me.QteProduitConso, Me.DosageReelRND, Me.EcartReglageRND})
        Me.DataGridView1.DataSource = Me.m_bsrcMesures
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.Location = New System.Drawing.Point(4, 209)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 30
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(803, 194)
        Me.DataGridView1.TabIndex = 109
        '
        'm_bsrcMesures
        '
        Me.m_bsrcMesures.DataMember = "lstMesures"
        Me.m_bsrcMesures.DataSource = Me.m_bsrcPompes
        '
        'laResultat
        '
        Me.laResultat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laResultat.AutoSize = True
        Me.laResultat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "LabelResultat", True))
        Me.laResultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laResultat.ForeColor = System.Drawing.Color.OliveDrab
        Me.laResultat.Location = New System.Drawing.Point(730, 8)
        Me.laResultat.Name = "laResultat"
        Me.laResultat.Size = New System.Drawing.Size(77, 20)
        Me.laResultat.TabIndex = 108
        Me.laResultat.Text = "Resultat"
        Me.laResultat.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TbNumeric10
        '
        Me.TbNumeric10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbNumeric10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TbNumeric10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "DebitTotalRND", True))
        Me.TbNumeric10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbNumeric10.ForceBindingOnTextChanged = False
        Me.TbNumeric10.Location = New System.Drawing.Point(707, 95)
        Me.TbNumeric10.Name = "TbNumeric10"
        Me.TbNumeric10.ReadOnly = True
        Me.TbNumeric10.Size = New System.Drawing.Size(100, 26)
        Me.TbNumeric10.TabIndex = 90
        Me.TbNumeric10.TabStop = False
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(589, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 20)
        Me.Label14.TabIndex = 89
        Me.Label14.Text = "Débit total : "
        '
        'TbNumeric9
        '
        Me.TbNumeric9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TbNumeric9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "DebitReelRND", True))
        Me.TbNumeric9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbNumeric9.ForceBindingOnTextChanged = False
        Me.TbNumeric9.Location = New System.Drawing.Point(284, 95)
        Me.TbNumeric9.Name = "TbNumeric9"
        Me.TbNumeric9.ReadOnly = True
        Me.TbNumeric9.Size = New System.Drawing.Size(100, 26)
        Me.TbNumeric9.TabIndex = 88
        Me.TbNumeric9.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(196, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 20)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Débit réel :"
        '
        'TbNumeric1
        '
        Me.TbNumeric1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbNumeric1.BackColor = System.Drawing.Color.White
        Me.TbNumeric1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "NbBuses", True))
        Me.TbNumeric1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbNumeric1.ForceBindingOnTextChanged = False
        Me.TbNumeric1.Location = New System.Drawing.Point(707, 69)
        Me.TbNumeric1.Name = "TbNumeric1"
        Me.TbNumeric1.Size = New System.Drawing.Size(100, 26)
        Me.TbNumeric1.TabIndex = 86
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(577, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 20)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Nb de buses :"
        '
        'TbNumeric2
        '
        Me.TbNumeric2.BackColor = System.Drawing.Color.White
        Me.TbNumeric2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "PressionMoyenne", True))
        Me.TbNumeric2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbNumeric2.ForceBindingOnTextChanged = False
        Me.TbNumeric2.Location = New System.Drawing.Point(284, 69)
        Me.TbNumeric2.Name = "TbNumeric2"
        Me.TbNumeric2.Size = New System.Drawing.Size(100, 26)
        Me.TbNumeric2.TabIndex = 84
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(53, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(225, 20)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Pression moyenne à la rampe :"
        '
        'nupMesures
        '
        Me.nupMesures.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nupMesures.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupMesures.Location = New System.Drawing.Point(604, 182)
        Me.nupMesures.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
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
        Me.Label3.Location = New System.Drawing.Point(494, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 20)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Nb mesures"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(166, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Débit mesuré :"
        '
        'TbNumeric8
        '
        Me.TbNumeric8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbNumeric8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TbNumeric8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "PressionMesure", True))
        Me.TbNumeric8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbNumeric8.ForceBindingOnTextChanged = False
        Me.TbNumeric8.Location = New System.Drawing.Point(707, 43)
        Me.TbNumeric8.Name = "TbNumeric8"
        Me.TbNumeric8.ReadOnly = True
        Me.TbNumeric8.Size = New System.Drawing.Size(100, 26)
        Me.TbNumeric8.TabIndex = 6
        Me.TbNumeric8.TabStop = False
        '
        'TbNumeric7
        '
        Me.TbNumeric7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TbNumeric7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbNumeric7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcPompes, "debitMesure", True))
        Me.TbNumeric7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbNumeric7.ForceBindingOnTextChanged = False
        Me.TbNumeric7.Location = New System.Drawing.Point(284, 43)
        Me.TbNumeric7.Name = "TbNumeric7"
        Me.TbNumeric7.ReadOnly = True
        Me.TbNumeric7.Size = New System.Drawing.Size(100, 26)
        Me.TbNumeric7.TabIndex = 5
        Me.TbNumeric7.TabStop = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(526, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(157, 20)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Pression de mesure :"
        '
        'pctResultat
        '
        Me.pctResultat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctResultat.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.m_bsrcPompes, "Image", True))
        Me.pctResultat.Image = Global.Crodip_agent.Resources.PuceVerteT
        Me.pctResultat.Location = New System.Drawing.Point(695, 10)
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
        Me.laResultatGlobal.Location = New System.Drawing.Point(826, 127)
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
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(212, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(522, 33)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Contrôle du dispositif de dosage"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.btnAnnuler.Location = New System.Drawing.Point(804, 571)
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
        Me.btnValider.Location = New System.Drawing.Point(644, 571)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(138, 25)
        Me.btnValider.TabIndex = 42
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = False
        '
        'm_bsrcH12123
        '
        Me.m_bsrcH12123.DataSource = GetType(CRODIPWS.DiagnosticHelp12123)
        '
        'ImageDataGridViewImageColumn
        '
        Me.ImageDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ImageDataGridViewImageColumn.DataPropertyName = "Image"
        Me.ImageDataGridViewImageColumn.HeaderText = "Image"
        Me.ImageDataGridViewImageColumn.Name = "ImageDataGridViewImageColumn"
        Me.ImageDataGridViewImageColumn.Width = 50
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.DataPropertyName = "numeroMesurestr"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.FillWeight = 707.5645!
        Me.Column2.HeaderText = "N°"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.Width = 80
        '
        'ReglageDispositif
        '
        Me.ReglageDispositif.DataPropertyName = "ReglageDispositif"
        Me.ReglageDispositif.FillWeight = 43.0!
        Me.ReglageDispositif.HeaderText = "Réglage dispo. dosage(%)"
        Me.ReglageDispositif.Name = "ReglageDispositif"
        '
        'DebitTheoriqueRND
        '
        Me.DebitTheoriqueRND.DataPropertyName = "DebitTheoriqueRND"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.DebitTheoriqueRND.DefaultCellStyle = DataGridViewCellStyle3
        Me.DebitTheoriqueRND.FillWeight = 36.95059!
        Me.DebitTheoriqueRND.HeaderText = "Debit théo. (L)"
        Me.DebitTheoriqueRND.Name = "DebitTheoriqueRND"
        Me.DebitTheoriqueRND.ReadOnly = True
        '
        'TempsMesure
        '
        Me.TempsMesure.DataPropertyName = "TempsMesure"
        Me.TempsMesure.FillWeight = 36.95059!
        Me.TempsMesure.HeaderText = "Temps mesuré (S)"
        Me.TempsMesure.Name = "TempsMesure"
        '
        'QteEauPulveriseeRND
        '
        Me.QteEauPulveriseeRND.DataPropertyName = "QteEauPulveriseeRND"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.QteEauPulveriseeRND.DefaultCellStyle = DataGridViewCellStyle4
        Me.QteEauPulveriseeRND.FillWeight = 36.95059!
        Me.QteEauPulveriseeRND.HeaderText = "Qte eau pulvé."
        Me.QteEauPulveriseeRND.Name = "QteEauPulveriseeRND"
        Me.QteEauPulveriseeRND.ReadOnly = True
        '
        'MasseInitiale
        '
        Me.MasseInitiale.DataPropertyName = "MasseInitiale"
        Me.MasseInitiale.FillWeight = 36.95059!
        Me.MasseInitiale.HeaderText = "Masse init(+) (kg)"
        Me.MasseInitiale.Name = "MasseInitiale"
        '
        'MasseAspire
        '
        Me.MasseAspire.DataPropertyName = "MasseAspire"
        Me.MasseAspire.FillWeight = 36.95059!
        Me.MasseAspire.HeaderText = "Masse aspi (-) (kg)"
        Me.MasseAspire.Name = "MasseAspire"
        '
        'QteProduitConso
        '
        Me.QteProduitConso.DataPropertyName = "QteProduitConso"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.QteProduitConso.DefaultCellStyle = DataGridViewCellStyle5
        Me.QteProduitConso.FillWeight = 36.95059!
        Me.QteProduitConso.HeaderText = "Produit conso."
        Me.QteProduitConso.Name = "QteProduitConso"
        Me.QteProduitConso.ReadOnly = True
        '
        'DosageReelRND
        '
        Me.DosageReelRND.DataPropertyName = "DosageReelRND"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DosageReelRND.DefaultCellStyle = DataGridViewCellStyle6
        Me.DosageReelRND.FillWeight = 36.95059!
        Me.DosageReelRND.HeaderText = "Dos. réel (%)"
        Me.DosageReelRND.Name = "DosageReelRND"
        Me.DosageReelRND.ReadOnly = True
        '
        'EcartReglageRND
        '
        Me.EcartReglageRND.DataPropertyName = "EcartReglageRND"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.EcartReglageRND.DefaultCellStyle = DataGridViewCellStyle7
        Me.EcartReglageRND.FillWeight = 36.95059!
        Me.EcartReglageRND.HeaderText = "Ecart (%)"
        Me.EcartReglageRND.Name = "EcartReglageRND"
        '
        'diagnostic_dlghelp12123new
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(967, 612)
        Me.Controls.Add(Me.pnl12123)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diagnostic_dlghelp12123new"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Controle du dispositif de dosage"
        Me.pnl12123.ResumeLayout(False)
        Me.pnl12123.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlDetailPompe.ResumeLayout(False)
        Me.pnlDetailPompe.PerformLayout()
        CType(Me.m_bsrcPompes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcMesures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupMesures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctResultat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupNbPompes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcH12123, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents m_bsrcH12123 As System.Windows.Forms.BindingSource
    Friend WithEvents pnl12123 As System.Windows.Forms.Panel
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents btnValider As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnvaliderNbPompes As System.Windows.Forms.Label
    Friend WithEvents listImg_flags As System.Windows.Forms.ImageList
    Friend WithEvents laResultatGlobal As System.Windows.Forms.Label
    Friend WithEvents nupNbPompes As System.Windows.Forms.NumericUpDown
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlDetailPompe As System.Windows.Forms.Panel
    Friend WithEvents nupMesures As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric8 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents TbNumeric7 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pctResultat As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric10 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric9 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents laResultat As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents m_bsrcMesures As System.Windows.Forms.BindingSource
    Friend WithEvents MasseApresAspiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MasseApresComplementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents m_bsrcPompes As System.Windows.Forms.BindingSource
    Friend WithEvents btnValiderNbMesures As System.Windows.Forms.Label
    Friend WithEvents tbEcartMoyen As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents laEcartMoyen As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric5 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents TbNumeric4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents TbNumeric3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents btn_PompeSuivante As System.Windows.Forms.Label
    Friend WithEvents ImageDataGridViewImageColumn As DataGridViewImageColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents ReglageDispositif As DataGridViewTextBoxColumn
    Friend WithEvents DebitTheoriqueRND As DataGridViewTextBoxColumn
    Friend WithEvents TempsMesure As DataGridViewTextBoxColumn
    Friend WithEvents QteEauPulveriseeRND As DataGridViewTextBoxColumn
    Friend WithEvents MasseInitiale As DataGridViewTextBoxColumn
    Friend WithEvents MasseAspire As DataGridViewTextBoxColumn
    Friend WithEvents QteProduitConso As DataGridViewTextBoxColumn
    Friend WithEvents DosageReelRND As DataGridViewTextBoxColumn
    Friend WithEvents EcartReglageRND As DataGridViewTextBoxColumn
End Class
