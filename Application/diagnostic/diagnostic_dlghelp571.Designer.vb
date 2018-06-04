<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagnostic_dlghelp571

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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnl_Pression = New System.Windows.Forms.Panel()
        Me.laResultPRS = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TbNumeric5 = New CRODIP_ControlLibrary.TBNumeric()
        Me.TbNumeric4 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbNumeric3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.TbNumeric2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TbNumeric1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.laTitre = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnl_Debit = New System.Windows.Forms.Panel()
        Me.laResultDEB = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbErreurVitesseDEB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnl_Pression.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnl_Debit.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnAnnuler)
        Me.Panel2.Controls.Add(Me.btnValider)
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Location = New System.Drawing.Point(5, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(629, 336)
        Me.Panel2.TabIndex = 42
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAnnuler.BackgroundImage = Crodip_Agent.Resources.btn_annuler
        Me.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.FlatAppearance.BorderSize = 0
        Me.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Location = New System.Drawing.Point(490, 301)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(131, 29)
        Me.btnAnnuler.TabIndex = 43
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = False
        '
        'btnValider
        '
        Me.btnValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValider.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnValider.BackgroundImage = Crodip_Agent.Resources.btn_valider
        Me.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnValider.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnValider.FlatAppearance.BorderSize = 0
        Me.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnValider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValider.ForeColor = System.Drawing.Color.White
        Me.btnValider.Location = New System.Drawing.Point(336, 301)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(137, 29)
        Me.btnValider.TabIndex = 42
        Me.btnValider.Text = "OK"
        Me.btnValider.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(629, 288)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.pnl_Pression)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(621, 262)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pression"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pnl_Pression
        '
        Me.pnl_Pression.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnl_Pression.Controls.Add(Me.laResultPRS)
        Me.pnl_Pression.Controls.Add(Me.Label8)
        Me.pnl_Pression.Controls.Add(Me.TextBox7)
        Me.pnl_Pression.Controls.Add(Me.GroupBox3)
        Me.pnl_Pression.Controls.Add(Me.GroupBox2)
        Me.pnl_Pression.Controls.Add(Me.GroupBox1)
        Me.pnl_Pression.Controls.Add(Me.laTitre)
        Me.pnl_Pression.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Pression.Location = New System.Drawing.Point(3, 3)
        Me.pnl_Pression.Name = "pnl_Pression"
        Me.pnl_Pression.Size = New System.Drawing.Size(613, 254)
        Me.pnl_Pression.TabIndex = 2
        '
        'laResultPRS
        '
        Me.laResultPRS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laResultPRS.AutoSize = True
        Me.laResultPRS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laResultPRS.ForeColor = System.Drawing.Color.Red
        Me.laResultPRS.Location = New System.Drawing.Point(534, 226)
        Me.laResultPRS.Name = "laResultPRS"
        Me.laResultPRS.Size = New System.Drawing.Size(65, 16)
        Me.laResultPRS.TabIndex = 66
        Me.laResultPRS.Text = "Résultat"
        Me.laResultPRS.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(82, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Erreur de globale :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ErreurGlobalePRSRND", True))
        Me.TextBox7.Enabled = False
        Me.TextBox7.Location = New System.Drawing.Point(211, 222)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(100, 13)
        Me.TextBox7.TabIndex = 64
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(Crodip_agent.DiagnosticHelp571)
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 163)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(607, 49)
        Me.GroupBox3.TabIndex = 63
        Me.GroupBox3.TabStop = False
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ErreurDebitPRSRND", True))
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(496, 12)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(100, 13)
        Me.TextBox4.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(378, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Erreur de débit :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ErreurVitessePRS", True))
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(195, 11)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(100, 13)
        Me.TextBox3.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(66, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Erreur de vitesse :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TbNumeric5)
        Me.GroupBox2.Controls.Add(Me.TbNumeric4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(607, 55)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        '
        'TbNumeric5
        '
        Me.TbNumeric5.BackColor = System.Drawing.Color.White
        Me.TbNumeric5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "DebitBuseProgrammePRS", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, ""))
        Me.TbNumeric5.ForceBindingOnTextChanged = False
        Me.TbNumeric5.Location = New System.Drawing.Point(496, 12)
        Me.TbNumeric5.Name = "TbNumeric5"
        Me.TbNumeric5.Size = New System.Drawing.Size(100, 20)
        Me.TbNumeric5.TabIndex = 53
        '
        'TbNumeric4
        '
        Me.TbNumeric4.BackColor = System.Drawing.Color.White
        Me.TbNumeric4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PressionMoyennePRS", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, ""))
        Me.TbNumeric4.ForceBindingOnTextChanged = False
        Me.TbNumeric4.Location = New System.Drawing.Point(195, 12)
        Me.TbNumeric4.Name = "TbNumeric4"
        Me.TbNumeric4.Size = New System.Drawing.Size(100, 20)
        Me.TbNumeric4.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(319, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 16)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Débit des buses programmé :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 16)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Pression moyenne à la rampe :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TbNumeric3)
        Me.GroupBox1.Controls.Add(Me.Label61)
        Me.GroupBox1.Controls.Add(Me.TbNumeric2)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.TbNumeric1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 58)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buses"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(408, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Débit Réel :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbNumeric3
        '
        Me.TbNumeric3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TbNumeric3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TbNumeric3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "DebitReelPRSRND", True))
        Me.TbNumeric3.Enabled = False
        Me.TbNumeric3.ForceBindingOnTextChanged = False
        Me.TbNumeric3.Location = New System.Drawing.Point(496, 19)
        Me.TbNumeric3.Name = "TbNumeric3"
        Me.TbNumeric3.ReadOnly = True
        Me.TbNumeric3.Size = New System.Drawing.Size(100, 13)
        Me.TbNumeric3.TabIndex = 60
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(224, 20)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(91, 16)
        Me.Label61.TabIndex = 45
        Me.Label61.Text = "Débit mesuré :"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbNumeric2
        '
        Me.TbNumeric2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TbNumeric2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TbNumeric2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "DebitMesurePRS", True))
        Me.TbNumeric2.Enabled = False
        Me.TbNumeric2.ForceBindingOnTextChanged = False
        Me.TbNumeric2.Location = New System.Drawing.Point(322, 20)
        Me.TbNumeric2.Name = "TbNumeric2"
        Me.TbNumeric2.ReadOnly = True
        Me.TbNumeric2.Size = New System.Drawing.Size(80, 13)
        Me.TbNumeric2.TabIndex = 59
        '
        'Label58
        '
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label58.Location = New System.Drawing.Point(4, 20)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(127, 16)
        Me.Label58.TabIndex = 47
        Me.Label58.Text = "Pression de mesure :"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbNumeric1
        '
        Me.TbNumeric1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TbNumeric1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TbNumeric1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PressionMesurePRS", True))
        Me.TbNumeric1.Enabled = False
        Me.TbNumeric1.ForceBindingOnTextChanged = False
        Me.TbNumeric1.Location = New System.Drawing.Point(138, 19)
        Me.TbNumeric1.Name = "TbNumeric1"
        Me.TbNumeric1.ReadOnly = True
        Me.TbNumeric1.Size = New System.Drawing.Size(80, 13)
        Me.TbNumeric1.TabIndex = 58
        '
        'laTitre
        '
        Me.laTitre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laTitre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.laTitre.Location = New System.Drawing.Point(7, 4)
        Me.laTitre.Name = "laTitre"
        Me.laTitre.Size = New System.Drawing.Size(603, 29)
        Me.laTitre.TabIndex = 56
        Me.laTitre.Text = "DPAE avec capteur de pression"
        Me.laTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pnl_Debit)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(621, 262)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Débit"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnl_Debit
        '
        Me.pnl_Debit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnl_Debit.Controls.Add(Me.laResultDEB)
        Me.pnl_Debit.Controls.Add(Me.Label11)
        Me.pnl_Debit.Controls.Add(Me.TextBox8)
        Me.pnl_Debit.Controls.Add(Me.GroupBox4)
        Me.pnl_Debit.Controls.Add(Me.Label13)
        Me.pnl_Debit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Debit.Location = New System.Drawing.Point(3, 3)
        Me.pnl_Debit.Name = "pnl_Debit"
        Me.pnl_Debit.Size = New System.Drawing.Size(615, 256)
        Me.pnl_Debit.TabIndex = 3
        '
        'laResultDEB
        '
        Me.laResultDEB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laResultDEB.AutoSize = True
        Me.laResultDEB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laResultDEB.ForeColor = System.Drawing.Color.Red
        Me.laResultDEB.Location = New System.Drawing.Point(531, 226)
        Me.laResultDEB.Name = "laResultDEB"
        Me.laResultDEB.Size = New System.Drawing.Size(65, 16)
        Me.laResultDEB.TabIndex = 69
        Me.laResultDEB.Text = "Résultat"
        Me.laResultDEB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(73, 175)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Erreur de globale :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "erreurGlobaleDEB", True))
        Me.TextBox8.Enabled = False
        Me.TextBox8.Location = New System.Drawing.Point(202, 174)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(100, 13)
        Me.TextBox8.TabIndex = 67
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.tbErreurVitesseDEB)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 100)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(603, 49)
        Me.GroupBox4.TabIndex = 63
        Me.GroupBox4.TabStop = False
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "erreurDebitDEB", True))
        Me.TextBox5.Location = New System.Drawing.Point(489, 12)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(100, 13)
        Me.TextBox5.TabIndex = 52
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(371, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 16)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Erreur de débit :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbErreurVitesseDEB
        '
        Me.tbErreurVitesseDEB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbErreurVitesseDEB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbErreurVitesseDEB.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "erreurVitesseDEB", True))
        Me.tbErreurVitesseDEB.Location = New System.Drawing.Point(195, 11)
        Me.tbErreurVitesseDEB.Name = "tbErreurVitesseDEB"
        Me.tbErreurVitesseDEB.ReadOnly = True
        Me.tbErreurVitesseDEB.Size = New System.Drawing.Size(100, 13)
        Me.tbErreurVitesseDEB.TabIndex = 50
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(66, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Erreur de vitesse :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(7, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(589, 29)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "DPAE avec capteur de débit"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diagnostic_dlghelp571
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(640, 347)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diagnostic_dlghelp571"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.pnl_Pression.ResumeLayout(False)
        Me.pnl_Pression.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.pnl_Debit.ResumeLayout(False)
        Me.pnl_Debit.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents btnValider As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents pnl_Pression As System.Windows.Forms.Panel
    Friend WithEvents laResultPRS As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TbNumeric5 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents TbNumeric4 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents TbNumeric1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents laTitre As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents pnl_Debit As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbErreurVitesseDEB As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents laResultDEB As System.Windows.Forms.Label

End Class
