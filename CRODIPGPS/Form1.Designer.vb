<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits MaterialSkin.Controls.MaterialForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TimerLectureGPS = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PnlCacheCkTest = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.laMesure = New MaterialSkin.Controls.MaterialLabel()
        Me.ckVitessseStable = New MaterialSkin.Controls.MaterialCheckbox()
        Me.ckGPSActif = New MaterialSkin.Controls.MaterialCheckbox()
        Me.lblNumPulvé = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel5 = New MaterialSkin.Controls.MaterialLabel()
        Me.cbMesure = New MaterialSkin.Controls.MaterialButton()
        Me.CbMesureSuivante = New MaterialSkin.Controls.MaterialButton()
        Me.pbMesure = New MaterialSkin.Controls.MaterialProgressBar()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        Me.laVitesseLue = New MaterialSkin.Controls.MaterialLabel()
        Me.laVitesseMesuree = New MaterialSkin.Controls.MaterialLabel()
        Me.tbVitesseMesuree = New MaterialSkin.Controls.MaterialTextBox()
        Me.cbValiderVitesseLue = New MaterialSkin.Controls.MaterialButton()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbSauvegarder = New MaterialSkin.Controls.MaterialButton()
        Me.cbQuitter = New MaterialSkin.Controls.MaterialButton()
        Me.TableLayoutPanelMesures = New System.Windows.Forms.TableLayoutPanel()
        Me.rbMesure2 = New MaterialSkin.Controls.MaterialRadioButton()
        Me.rbMesure1 = New MaterialSkin.Controls.MaterialRadioButton()
        Me.CkTest = New MaterialSkin.Controls.MaterialCheckbox()
        Me.TableLayoutPanelVitesseLue = New System.Windows.Forms.TableLayoutPanel()
        Me.tbVitesseLue = New MaterialSkin.Controls.MaterialTextBox()
        Me.VitesseLueMoins = New MaterialSkin.Controls.MaterialButton()
        Me.VitesseLuePlus = New MaterialSkin.Controls.MaterialButton()
        Me.cbReset = New MaterialSkin.Controls.MaterialButton()
        Me.laDistance = New MaterialSkin.Controls.MaterialLabel()
        Me.laVitesse = New MaterialSkin.Controls.MaterialLabel()
        Me.m_bsrcGPSMesure = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanelMesures.SuspendLayout()
        Me.TableLayoutPanelVitesseLue.SuspendLayout()
        CType(Me.m_bsrcGPSMesure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerLectureGPS
        '
        Me.TimerLectureGPS.Interval = 1000
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'PnlCacheCkTest
        '
        Me.PnlCacheCkTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlCacheCkTest.Location = New System.Drawing.Point(257, 27)
        Me.PnlCacheCkTest.Name = "PnlCacheCkTest"
        Me.PnlCacheCkTest.Size = New System.Drawing.Size(392, 37)
        Me.PnlCacheCkTest.TabIndex = 34
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel2.Controls.Add(Me.laMesure, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ckVitessseStable, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ckGPSActif, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNumPulvé, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.MaterialLabel5, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cbMesure, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.CbMesureSuivante, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.pbMesure, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.MaterialLabel1, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.MaterialLabel2, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.laVitesseLue, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.laVitesseMesuree, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.tbVitesseMesuree, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.cbValiderVitesseLue, 2, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanelMesures, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.CkTest, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanelVitesseLue, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.cbReset, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.laDistance, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.laVitesse, 1, 7)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(11, 67)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 12
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(386, 530)
        Me.TableLayoutPanel2.TabIndex = 35
        '
        'laMesure
        '
        Me.laMesure.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.laMesure, 3)
        Me.laMesure.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Text", True))
        Me.laMesure.Depth = 0
        Me.laMesure.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.laMesure.Location = New System.Drawing.Point(3, 41)
        Me.laMesure.MouseState = MaterialSkin.MouseState.HOVER
        Me.laMesure.Name = "laMesure"
        Me.laMesure.Size = New System.Drawing.Size(32, 19)
        Me.laMesure.TabIndex = 44
        Me.laMesure.Text = "Text"
        Me.laMesure.Visible = False
        '
        'ckVitessseStable
        '
        Me.ckVitessseStable.AutoSize = True
        Me.ckVitessseStable.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsrcGPSMesure, "VitesseConstante", True))
        Me.ckVitessseStable.Depth = 0
        Me.ckVitessseStable.Enabled = False
        Me.ckVitessseStable.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVitessseStable.Location = New System.Drawing.Point(256, 0)
        Me.ckVitessseStable.Margin = New System.Windows.Forms.Padding(0)
        Me.ckVitessseStable.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.ckVitessseStable.MouseState = MaterialSkin.MouseState.HOVER
        Me.ckVitessseStable.Name = "ckVitessseStable"
        Me.ckVitessseStable.ReadOnly = False
        Me.ckVitessseStable.Ripple = True
        Me.ckVitessseStable.Size = New System.Drawing.Size(130, 37)
        Me.ckVitessseStable.TabIndex = 36
        Me.ckVitessseStable.Text = "&VitesseStable"
        Me.ckVitessseStable.UseVisualStyleBackColor = True
        Me.ckVitessseStable.Visible = False
        '
        'ckGPSActif
        '
        Me.ckGPSActif.AutoSize = True
        Me.ckGPSActif.Depth = 0
        Me.ckGPSActif.Enabled = False
        Me.ckGPSActif.Location = New System.Drawing.Point(128, 0)
        Me.ckGPSActif.Margin = New System.Windows.Forms.Padding(0)
        Me.ckGPSActif.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.ckGPSActif.MouseState = MaterialSkin.MouseState.HOVER
        Me.ckGPSActif.Name = "ckGPSActif"
        Me.ckGPSActif.ReadOnly = False
        Me.ckGPSActif.Ripple = True
        Me.ckGPSActif.Size = New System.Drawing.Size(101, 37)
        Me.ckGPSActif.TabIndex = 35
        Me.ckGPSActif.Text = "&GPS OK"
        Me.ckGPSActif.UseVisualStyleBackColor = True
        '
        'lblNumPulvé
        '
        Me.lblNumPulvé.AutoSize = True
        Me.lblNumPulvé.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "NumPulve", True))
        Me.lblNumPulvé.Depth = 0
        Me.lblNumPulvé.Font = New System.Drawing.Font("Roboto Medium", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNumPulvé.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        Me.lblNumPulvé.ForeColor = System.Drawing.Color.Maroon
        Me.lblNumPulvé.Location = New System.Drawing.Point(259, 61)
        Me.lblNumPulvé.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblNumPulvé.Name = "lblNumPulvé"
        Me.lblNumPulvé.Size = New System.Drawing.Size(78, 24)
        Me.lblNumPulvé.TabIndex = 32
        Me.lblNumPulvé.Text = "E001123"
        '
        'MaterialLabel5
        '
        Me.MaterialLabel5.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.MaterialLabel5, 2)
        Me.MaterialLabel5.Depth = 0
        Me.MaterialLabel5.Font = New System.Drawing.Font("Roboto Medium", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        Me.MaterialLabel5.Location = New System.Drawing.Point(3, 61)
        Me.MaterialLabel5.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel5.Name = "MaterialLabel5"
        Me.MaterialLabel5.Size = New System.Drawing.Size(231, 24)
        Me.MaterialLabel5.TabIndex = 31
        Me.MaterialLabel5.Text = "Numero du pulvérisateur :"
        Me.MaterialLabel5.UseAccent = True
        '
        'cbMesure
        '
        Me.cbMesure.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 2)
        Me.cbMesure.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.cbMesure.Depth = 0
        Me.cbMesure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbMesure.Enabled = False
        Me.cbMesure.HighEmphasis = True
        Me.cbMesure.Icon = Nothing
        Me.cbMesure.Location = New System.Drawing.Point(4, 148)
        Me.cbMesure.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbMesure.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbMesure.Name = "cbMesure"
        Me.cbMesure.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbMesure.Size = New System.Drawing.Size(248, 77)
        Me.cbMesure.TabIndex = 28
        Me.cbMesure.Text = "Démarrer"
        Me.cbMesure.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbMesure.UseAccentColor = False
        Me.cbMesure.UseVisualStyleBackColor = True
        '
        'CbMesureSuivante
        '
        Me.CbMesureSuivante.AutoSize = False
        Me.CbMesureSuivante.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.SetColumnSpan(Me.CbMesureSuivante, 3)
        Me.CbMesureSuivante.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.CbMesureSuivante.Depth = 0
        Me.CbMesureSuivante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CbMesureSuivante.HighEmphasis = True
        Me.CbMesureSuivante.Icon = Nothing
        Me.CbMesureSuivante.Location = New System.Drawing.Point(4, 447)
        Me.CbMesureSuivante.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.CbMesureSuivante.MouseState = MaterialSkin.MouseState.HOVER
        Me.CbMesureSuivante.Name = "CbMesureSuivante"
        Me.CbMesureSuivante.NoAccentTextColor = System.Drawing.Color.Empty
        Me.CbMesureSuivante.Size = New System.Drawing.Size(378, 41)
        Me.CbMesureSuivante.TabIndex = 25
        Me.CbMesureSuivante.Text = "Mesure suivante"
        Me.CbMesureSuivante.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.CbMesureSuivante.UseAccentColor = False
        Me.CbMesureSuivante.UseVisualStyleBackColor = True
        '
        'pbMesure
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.pbMesure, 3)
        Me.pbMesure.Depth = 0
        Me.pbMesure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbMesure.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbMesure.Location = New System.Drawing.Point(3, 234)
        Me.pbMesure.MouseState = MaterialSkin.MouseState.HOVER
        Me.pbMesure.Name = "pbMesure"
        Me.pbMesure.Size = New System.Drawing.Size(380, 5)
        Me.pbMesure.TabIndex = 24
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel1.Location = New System.Drawing.Point(14, 256)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(100, 19)
        Me.MaterialLabel1.TabIndex = 3
        Me.MaterialLabel1.Text = "Distance (m) :"
        '
        'MaterialLabel2
        '
        Me.MaterialLabel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MaterialLabel2.AutoSize = True
        Me.MaterialLabel2.Depth = 0
        Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel2.Location = New System.Drawing.Point(23, 306)
        Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel2.Name = "MaterialLabel2"
        Me.MaterialLabel2.Size = New System.Drawing.Size(81, 19)
        Me.MaterialLabel2.TabIndex = 4
        Me.MaterialLabel2.Text = "Temps (s) :"
        '
        'laVitesseLue
        '
        Me.laVitesseLue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.laVitesseLue.AutoSize = True
        Me.laVitesseLue.Depth = 0
        Me.laVitesseLue.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.laVitesseLue.Location = New System.Drawing.Point(3, 356)
        Me.laVitesseLue.MouseState = MaterialSkin.MouseState.HOVER
        Me.laVitesseLue.Name = "laVitesseLue"
        Me.laVitesseLue.Size = New System.Drawing.Size(122, 19)
        Me.laVitesseLue.TabIndex = 19
        Me.laVitesseLue.Text = "Vitesse lue (km/h) :"
        '
        'laVitesseMesuree
        '
        Me.laVitesseMesuree.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.laVitesseMesuree.AutoSize = True
        Me.laVitesseMesuree.Depth = 0
        Me.laVitesseMesuree.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.laVitesseMesuree.Location = New System.Drawing.Point(3, 406)
        Me.laVitesseMesuree.MouseState = MaterialSkin.MouseState.HOVER
        Me.laVitesseMesuree.Name = "laVitesseMesuree"
        Me.laVitesseMesuree.Size = New System.Drawing.Size(122, 19)
        Me.laVitesseMesuree.TabIndex = 5
        Me.laVitesseMesuree.Text = "Vitesse mesurée (km/h) :"
        Me.laVitesseMesuree.Visible = False
        '
        'tbVitesseMesuree
        '
        Me.tbVitesseMesuree.AnimateReadOnly = False
        Me.tbVitesseMesuree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbVitesseMesuree.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Vitesse", True))
        Me.tbVitesseMesuree.Depth = 0
        Me.tbVitesseMesuree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbVitesseMesuree.Enabled = False
        Me.tbVitesseMesuree.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbVitesseMesuree.ForeColor = System.Drawing.Color.DodgerBlue
        Me.tbVitesseMesuree.LeadingIcon = Nothing
        Me.tbVitesseMesuree.Location = New System.Drawing.Point(131, 394)
        Me.tbVitesseMesuree.MaxLength = 50
        Me.tbVitesseMesuree.MouseState = MaterialSkin.MouseState.OUT
        Me.tbVitesseMesuree.Multiline = False
        Me.tbVitesseMesuree.Name = "tbVitesseMesuree"
        Me.tbVitesseMesuree.Size = New System.Drawing.Size(122, 50)
        Me.tbVitesseMesuree.TabIndex = 8
        Me.tbVitesseMesuree.Text = "16.5"
        Me.tbVitesseMesuree.TrailingIcon = Nothing
        Me.tbVitesseMesuree.Visible = False
        '
        'cbValiderVitesseLue
        '
        Me.cbValiderVitesseLue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbValiderVitesseLue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cbValiderVitesseLue.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.cbValiderVitesseLue.Depth = 0
        Me.cbValiderVitesseLue.HighEmphasis = True
        Me.cbValiderVitesseLue.Icon = Nothing
        Me.cbValiderVitesseLue.Location = New System.Drawing.Point(260, 347)
        Me.cbValiderVitesseLue.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbValiderVitesseLue.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbValiderVitesseLue.Name = "cbValiderVitesseLue"
        Me.cbValiderVitesseLue.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbValiderVitesseLue.Size = New System.Drawing.Size(122, 38)
        Me.cbValiderVitesseLue.TabIndex = 23
        Me.cbValiderVitesseLue.Text = "Valider"
        Me.cbValiderVitesseLue.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbValiderVitesseLue.UseAccentColor = False
        Me.cbValiderVitesseLue.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel3, 3)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.cbSauvegarder, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cbQuitter, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 497)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(380, 30)
        Me.TableLayoutPanel3.TabIndex = 37
        '
        'cbSauvegarder
        '
        Me.cbSauvegarder.AutoSize = False
        Me.cbSauvegarder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cbSauvegarder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.cbSauvegarder.Depth = 0
        Me.cbSauvegarder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbSauvegarder.HighEmphasis = True
        Me.cbSauvegarder.Icon = Nothing
        Me.cbSauvegarder.Location = New System.Drawing.Point(194, 6)
        Me.cbSauvegarder.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbSauvegarder.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbSauvegarder.Name = "cbSauvegarder"
        Me.cbSauvegarder.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbSauvegarder.Size = New System.Drawing.Size(182, 18)
        Me.cbSauvegarder.TabIndex = 29
        Me.cbSauvegarder.Text = "Importer"
        Me.cbSauvegarder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbSauvegarder.UseAccentColor = False
        Me.cbSauvegarder.UseVisualStyleBackColor = True
        '
        'cbQuitter
        '
        Me.cbQuitter.AutoSize = False
        Me.cbQuitter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cbQuitter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.cbQuitter.Depth = 0
        Me.cbQuitter.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cbQuitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbQuitter.HighEmphasis = True
        Me.cbQuitter.Icon = Nothing
        Me.cbQuitter.Location = New System.Drawing.Point(4, 6)
        Me.cbQuitter.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbQuitter.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbQuitter.Name = "cbQuitter"
        Me.cbQuitter.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbQuitter.Size = New System.Drawing.Size(182, 18)
        Me.cbQuitter.TabIndex = 28
        Me.cbQuitter.Text = "Quitter"
        Me.cbQuitter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbQuitter.UseAccentColor = False
        Me.cbQuitter.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelMesures
        '
        Me.TableLayoutPanelMesures.ColumnCount = 2
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanelMesures, 3)
        Me.TableLayoutPanelMesures.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelMesures.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelMesures.Controls.Add(Me.rbMesure2, 0, 0)
        Me.TableLayoutPanelMesures.Controls.Add(Me.rbMesure1, 0, 0)
        Me.TableLayoutPanelMesures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelMesures.Location = New System.Drawing.Point(3, 95)
        Me.TableLayoutPanelMesures.Name = "TableLayoutPanelMesures"
        Me.TableLayoutPanelMesures.RowCount = 1
        Me.TableLayoutPanelMesures.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelMesures.Size = New System.Drawing.Size(380, 44)
        Me.TableLayoutPanelMesures.TabIndex = 38
        '
        'rbMesure2
        '
        Me.rbMesure2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsrcGPSMesure, "IsNum2", True))
        Me.rbMesure2.Depth = 0
        Me.rbMesure2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbMesure2.Location = New System.Drawing.Point(190, 0)
        Me.rbMesure2.Margin = New System.Windows.Forms.Padding(0)
        Me.rbMesure2.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.rbMesure2.MouseState = MaterialSkin.MouseState.HOVER
        Me.rbMesure2.Name = "rbMesure2"
        Me.rbMesure2.Ripple = True
        Me.rbMesure2.Size = New System.Drawing.Size(190, 44)
        Me.rbMesure2.TabIndex = 31
        Me.rbMesure2.TabStop = True
        Me.rbMesure2.Text = "Mesure 2"
        Me.rbMesure2.UseVisualStyleBackColor = True
        '
        'rbMesure1
        '
        Me.rbMesure1.Checked = True
        Me.rbMesure1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsrcGPSMesure, "IsNum1", True))
        Me.rbMesure1.Depth = 0
        Me.rbMesure1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbMesure1.Location = New System.Drawing.Point(0, 0)
        Me.rbMesure1.Margin = New System.Windows.Forms.Padding(0)
        Me.rbMesure1.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.rbMesure1.MouseState = MaterialSkin.MouseState.HOVER
        Me.rbMesure1.Name = "rbMesure1"
        Me.rbMesure1.Ripple = True
        Me.rbMesure1.Size = New System.Drawing.Size(190, 44)
        Me.rbMesure1.TabIndex = 30
        Me.rbMesure1.TabStop = True
        Me.rbMesure1.Text = "Mesure 1"
        Me.rbMesure1.UseVisualStyleBackColor = True
        '
        'CkTest
        '
        Me.CkTest.AutoSize = True
        Me.CkTest.Depth = 0
        Me.CkTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CkTest.Location = New System.Drawing.Point(0, 0)
        Me.CkTest.Margin = New System.Windows.Forms.Padding(0)
        Me.CkTest.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.CkTest.MouseState = MaterialSkin.MouseState.HOVER
        Me.CkTest.Name = "CkTest"
        Me.CkTest.ReadOnly = False
        Me.CkTest.Ripple = True
        Me.CkTest.Size = New System.Drawing.Size(128, 41)
        Me.CkTest.TabIndex = 34
        Me.CkTest.Text = "Mode &Test"
        Me.CkTest.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelVitesseLue
        '
        Me.TableLayoutPanelVitesseLue.ColumnCount = 3
        Me.TableLayoutPanelVitesseLue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanelVitesseLue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelVitesseLue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanelVitesseLue.Controls.Add(Me.tbVitesseLue, 1, 0)
        Me.TableLayoutPanelVitesseLue.Controls.Add(Me.VitesseLueMoins, 0, 0)
        Me.TableLayoutPanelVitesseLue.Controls.Add(Me.VitesseLuePlus, 2, 0)
        Me.TableLayoutPanelVitesseLue.Location = New System.Drawing.Point(131, 344)
        Me.TableLayoutPanelVitesseLue.Name = "TableLayoutPanelVitesseLue"
        Me.TableLayoutPanelVitesseLue.RowCount = 1
        Me.TableLayoutPanelVitesseLue.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelVitesseLue.Size = New System.Drawing.Size(122, 44)
        Me.TableLayoutPanelVitesseLue.TabIndex = 41
        '
        'tbVitesseLue
        '
        Me.tbVitesseLue.AnimateReadOnly = False
        Me.tbVitesseLue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbVitesseLue.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "VitesseLue", True))
        Me.tbVitesseLue.Depth = 0
        Me.tbVitesseLue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbVitesseLue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbVitesseLue.LeadingIcon = Nothing
        Me.tbVitesseLue.Location = New System.Drawing.Point(28, 3)
        Me.tbVitesseLue.MaxLength = 50
        Me.tbVitesseLue.MouseState = MaterialSkin.MouseState.OUT
        Me.tbVitesseLue.Multiline = False
        Me.tbVitesseLue.Name = "tbVitesseLue"
        Me.tbVitesseLue.Size = New System.Drawing.Size(66, 36)
        Me.tbVitesseLue.TabIndex = 0
        Me.tbVitesseLue.Text = "8.5"
        Me.tbVitesseLue.TrailingIcon = Nothing
        Me.tbVitesseLue.UseTallSize = False
        '
        'VitesseLueMoins
        '
        Me.VitesseLueMoins.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.VitesseLueMoins.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.VitesseLueMoins.Depth = 0
        Me.VitesseLueMoins.HighEmphasis = True
        Me.VitesseLueMoins.Icon = Nothing
        Me.VitesseLueMoins.Location = New System.Drawing.Point(4, 6)
        Me.VitesseLueMoins.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.VitesseLueMoins.MouseState = MaterialSkin.MouseState.HOVER
        Me.VitesseLueMoins.Name = "VitesseLueMoins"
        Me.VitesseLueMoins.NoAccentTextColor = System.Drawing.Color.Empty
        Me.VitesseLueMoins.Size = New System.Drawing.Size(17, 32)
        Me.VitesseLueMoins.TabIndex = 1
        Me.VitesseLueMoins.Text = "-"
        Me.VitesseLueMoins.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.VitesseLueMoins.UseAccentColor = False
        Me.VitesseLueMoins.UseVisualStyleBackColor = True
        '
        'VitesseLuePlus
        '
        Me.VitesseLuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.VitesseLuePlus.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.VitesseLuePlus.Depth = 0
        Me.VitesseLuePlus.HighEmphasis = True
        Me.VitesseLuePlus.Icon = Nothing
        Me.VitesseLuePlus.Location = New System.Drawing.Point(101, 6)
        Me.VitesseLuePlus.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.VitesseLuePlus.MouseState = MaterialSkin.MouseState.HOVER
        Me.VitesseLuePlus.Name = "VitesseLuePlus"
        Me.VitesseLuePlus.NoAccentTextColor = System.Drawing.Color.Empty
        Me.VitesseLuePlus.Size = New System.Drawing.Size(17, 32)
        Me.VitesseLuePlus.TabIndex = 2
        Me.VitesseLuePlus.Text = "+"
        Me.VitesseLuePlus.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.VitesseLuePlus.UseAccentColor = False
        Me.VitesseLuePlus.UseVisualStyleBackColor = True
        '
        'cbReset
        '
        Me.cbReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cbReset.BackColor = System.Drawing.Color.Red
        Me.cbReset.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.cbReset.Depth = 0
        Me.cbReset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbReset.HighEmphasis = True
        Me.cbReset.Icon = CType(resources.GetObject("cbReset.Icon"), System.Drawing.Image)
        Me.cbReset.Location = New System.Drawing.Point(260, 148)
        Me.cbReset.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbReset.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbReset.Name = "cbReset"
        Me.cbReset.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbReset.Size = New System.Drawing.Size(122, 77)
        Me.cbReset.TabIndex = 42
        Me.cbReset.Text = "STOP"
        Me.cbReset.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.cbReset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbReset.UseAccentColor = False
        Me.cbReset.UseVisualStyleBackColor = False
        '
        'laDistance
        '
        Me.laDistance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laDistance.BackColor = System.Drawing.SystemColors.Window
        Me.laDistance.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Distance", True))
        Me.laDistance.Depth = 0
        Me.laDistance.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.laDistance.Location = New System.Drawing.Point(131, 244)
        Me.laDistance.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.laDistance.MouseState = MaterialSkin.MouseState.HOVER
        Me.laDistance.Name = "laDistance"
        Me.laDistance.Size = New System.Drawing.Size(122, 47)
        Me.laDistance.TabIndex = 45
        Me.laDistance.Text = "154.80"
        Me.laDistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'laVitesse
        '
        Me.laVitesse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.laVitesse.BackColor = System.Drawing.SystemColors.Window
        Me.laVitesse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "TempAffichage", True))
        Me.laVitesse.Depth = 0
        Me.laVitesse.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.laVitesse.Location = New System.Drawing.Point(131, 294)
        Me.laVitesse.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.laVitesse.MouseState = MaterialSkin.MouseState.HOVER
        Me.laVitesse.Name = "laVitesse"
        Me.laVitesse.Size = New System.Drawing.Size(122, 47)
        Me.laVitesse.TabIndex = 46
        Me.laVitesse.Text = "90"
        Me.laVitesse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_bsrcGPSMesure
        '
        Me.m_bsrcGPSMesure.DataSource = GetType(CRODIPGPS.GPSMesure)
        '
        'Form1
        '
        Me.AcceptButton = Me.cbSauvegarder
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cbQuitter
        Me.ClientSize = New System.Drawing.Size(408, 603)
        Me.Controls.Add(Me.PnlCacheCkTest)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Acquisition GPS CRODIP"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanelMesures.ResumeLayout(False)
        Me.TableLayoutPanelVitesseLue.ResumeLayout(False)
        Me.TableLayoutPanelVitesseLue.PerformLayout()
        CType(Me.m_bsrcGPSMesure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerLectureGPS As Timer
    Friend WithEvents m_bsrcGPSMesure As BindingSource
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PnlCacheCkTest As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ckVitessseStable As MaterialSkin.Controls.MaterialCheckbox
    Friend WithEvents ckGPSActif As MaterialSkin.Controls.MaterialCheckbox
    Friend WithEvents lblNumPulvé As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel5 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents cbMesure As MaterialSkin.Controls.MaterialButton
    Friend WithEvents CbMesureSuivante As MaterialSkin.Controls.MaterialButton
    Friend WithEvents pbMesure As MaterialSkin.Controls.MaterialProgressBar
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents laVitesseLue As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents laVitesseMesuree As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents tbVitesseMesuree As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents cbValiderVitesseLue As MaterialSkin.Controls.MaterialButton
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents cbSauvegarder As MaterialSkin.Controls.MaterialButton
    Friend WithEvents cbQuitter As MaterialSkin.Controls.MaterialButton
    Friend WithEvents TableLayoutPanelMesures As TableLayoutPanel
    Friend WithEvents rbMesure2 As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents rbMesure1 As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents CkTest As MaterialSkin.Controls.MaterialCheckbox
    Friend WithEvents TableLayoutPanelVitesseLue As TableLayoutPanel
    Friend WithEvents tbVitesseLue As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents VitesseLueMoins As MaterialSkin.Controls.MaterialButton
    Friend WithEvents VitesseLuePlus As MaterialSkin.Controls.MaterialButton
    Friend WithEvents cbReset As MaterialSkin.Controls.MaterialButton
    Friend WithEvents laMesure As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents laDistance As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents laVitesse As MaterialSkin.Controls.MaterialLabel
End Class
