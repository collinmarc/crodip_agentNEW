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
        Me.cbMesure = New MaterialSkin.Controls.MaterialButton()
        Me.rbMesure1 = New MaterialSkin.Controls.MaterialRadioButton()
        Me.rbMesure2 = New MaterialSkin.Controls.MaterialRadioButton()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        Me.laVitesseMesuree = New MaterialSkin.Controls.MaterialLabel()
        Me.tbDistance = New MaterialSkin.Controls.MaterialTextBox()
        Me.tbTemps = New MaterialSkin.Controls.MaterialTextBox()
        Me.tbVitesseMesuree = New MaterialSkin.Controls.MaterialTextBox()
        Me.CbMesureSuivante = New MaterialSkin.Controls.MaterialButton()
        Me.cbSauvegarder = New MaterialSkin.Controls.MaterialButton()
        Me.cbQuitter = New MaterialSkin.Controls.MaterialButton()
        Me.pbMesure = New MaterialSkin.Controls.MaterialProgressBar()
        Me.TimerLectureGPS = New System.Windows.Forms.Timer(Me.components)
        Me.ckGPSActif = New MaterialSkin.Controls.MaterialCheckbox()
        Me.ckVitessseStable = New MaterialSkin.Controls.MaterialCheckbox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.CkTest = New MaterialSkin.Controls.MaterialCheckbox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PnlCacheCkTest = New System.Windows.Forms.Panel()
        Me.tbVitesseLue = New MaterialSkin.Controls.MaterialTextBox()
        Me.laVitesseLue = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel5 = New MaterialSkin.Controls.MaterialLabel()
        Me.lblNumPulvé = New MaterialSkin.Controls.MaterialLabel()
        Me.m_bsrcGPSMesure = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.m_bsrcGPSMesure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbMesure
        '
        Me.cbMesure.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMesure.AutoSize = False
        Me.cbMesure.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cbMesure.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.cbMesure.Depth = 0
        Me.cbMesure.Enabled = False
        Me.cbMesure.HighEmphasis = True
        Me.cbMesure.Icon = Nothing
        Me.cbMesure.Location = New System.Drawing.Point(6, 225)
        Me.cbMesure.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbMesure.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbMesure.Name = "cbMesure"
        Me.cbMesure.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbMesure.Size = New System.Drawing.Size(405, 126)
        Me.cbMesure.TabIndex = 0
        Me.cbMesure.Text = "Démarrer"
        Me.cbMesure.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbMesure.UseAccentColor = False
        Me.cbMesure.UseVisualStyleBackColor = True
        '
        'rbMesure1
        '
        Me.rbMesure1.AutoSize = True
        Me.rbMesure1.Checked = True
        Me.rbMesure1.Depth = 0
        Me.rbMesure1.Location = New System.Drawing.Point(90, 170)
        Me.rbMesure1.Margin = New System.Windows.Forms.Padding(0)
        Me.rbMesure1.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.rbMesure1.MouseState = MaterialSkin.MouseState.HOVER
        Me.rbMesure1.Name = "rbMesure1"
        Me.rbMesure1.Ripple = True
        Me.rbMesure1.Size = New System.Drawing.Size(100, 37)
        Me.rbMesure1.TabIndex = 1
        Me.rbMesure1.TabStop = True
        Me.rbMesure1.Text = "Mesure 1"
        Me.rbMesure1.UseVisualStyleBackColor = True
        '
        'rbMesure2
        '
        Me.rbMesure2.AutoSize = True
        Me.rbMesure2.Depth = 0
        Me.rbMesure2.Location = New System.Drawing.Point(214, 170)
        Me.rbMesure2.Margin = New System.Windows.Forms.Padding(0)
        Me.rbMesure2.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.rbMesure2.MouseState = MaterialSkin.MouseState.HOVER
        Me.rbMesure2.Name = "rbMesure2"
        Me.rbMesure2.Ripple = True
        Me.rbMesure2.Size = New System.Drawing.Size(100, 37)
        Me.rbMesure2.TabIndex = 2
        Me.rbMesure2.TabStop = True
        Me.rbMesure2.Text = "Mesure 2"
        Me.rbMesure2.UseVisualStyleBackColor = True
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel1.Location = New System.Drawing.Point(87, 400)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(100, 19)
        Me.MaterialLabel1.TabIndex = 3
        Me.MaterialLabel1.Text = "Distance (m) :"
        '
        'MaterialLabel2
        '
        Me.MaterialLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MaterialLabel2.AutoSize = True
        Me.MaterialLabel2.Depth = 0
        Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel2.Location = New System.Drawing.Point(106, 451)
        Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel2.Name = "MaterialLabel2"
        Me.MaterialLabel2.Size = New System.Drawing.Size(81, 19)
        Me.MaterialLabel2.TabIndex = 4
        Me.MaterialLabel2.Text = "Temps (s) :"
        '
        'laVitesseMesuree
        '
        Me.laVitesseMesuree.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.laVitesseMesuree.AutoSize = True
        Me.laVitesseMesuree.Depth = 0
        Me.laVitesseMesuree.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.laVitesseMesuree.Location = New System.Drawing.Point(10, 567)
        Me.laVitesseMesuree.MouseState = MaterialSkin.MouseState.HOVER
        Me.laVitesseMesuree.Name = "laVitesseMesuree"
        Me.laVitesseMesuree.Size = New System.Drawing.Size(177, 19)
        Me.laVitesseMesuree.TabIndex = 5
        Me.laVitesseMesuree.Text = "Vitesse mesurée (km/h) :"
        Me.laVitesseMesuree.Visible = False
        '
        'tbDistance
        '
        Me.tbDistance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbDistance.AnimateReadOnly = True
        Me.tbDistance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbDistance.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Distance", True))
        Me.tbDistance.Depth = 0
        Me.tbDistance.Enabled = False
        Me.tbDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbDistance.LeadingIcon = Nothing
        Me.tbDistance.Location = New System.Drawing.Point(193, 383)
        Me.tbDistance.MaxLength = 50
        Me.tbDistance.MouseState = MaterialSkin.MouseState.OUT
        Me.tbDistance.Multiline = False
        Me.tbDistance.Name = "tbDistance"
        Me.tbDistance.Size = New System.Drawing.Size(100, 50)
        Me.tbDistance.TabIndex = 6
        Me.tbDistance.Text = "154.90"
        Me.tbDistance.TrailingIcon = Nothing
        '
        'tbTemps
        '
        Me.tbTemps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbTemps.AnimateReadOnly = False
        Me.tbTemps.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbTemps.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Temps", True))
        Me.tbTemps.Depth = 0
        Me.tbTemps.Enabled = False
        Me.tbTemps.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbTemps.LeadingIcon = Nothing
        Me.tbTemps.Location = New System.Drawing.Point(193, 439)
        Me.tbTemps.MaxLength = 50
        Me.tbTemps.MouseState = MaterialSkin.MouseState.OUT
        Me.tbTemps.Multiline = False
        Me.tbTemps.Name = "tbTemps"
        Me.tbTemps.Size = New System.Drawing.Size(100, 50)
        Me.tbTemps.TabIndex = 7
        Me.tbTemps.Text = "90"
        Me.tbTemps.TrailingIcon = Nothing
        '
        'tbVitesseMesuree
        '
        Me.tbVitesseMesuree.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbVitesseMesuree.AnimateReadOnly = False
        Me.tbVitesseMesuree.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbVitesseMesuree.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Vitesse", True))
        Me.tbVitesseMesuree.Depth = 0
        Me.tbVitesseMesuree.Enabled = False
        Me.tbVitesseMesuree.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbVitesseMesuree.ForeColor = System.Drawing.Color.DodgerBlue
        Me.tbVitesseMesuree.LeadingIcon = Nothing
        Me.tbVitesseMesuree.Location = New System.Drawing.Point(193, 552)
        Me.tbVitesseMesuree.MaxLength = 50
        Me.tbVitesseMesuree.MouseState = MaterialSkin.MouseState.OUT
        Me.tbVitesseMesuree.Multiline = False
        Me.tbVitesseMesuree.Name = "tbVitesseMesuree"
        Me.tbVitesseMesuree.Size = New System.Drawing.Size(100, 50)
        Me.tbVitesseMesuree.TabIndex = 8
        Me.tbVitesseMesuree.Text = "16.5"
        Me.tbVitesseMesuree.TrailingIcon = Nothing
        Me.tbVitesseMesuree.Visible = False
        '
        'CbMesureSuivante
        '
        Me.CbMesureSuivante.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbMesureSuivante.AutoSize = False
        Me.CbMesureSuivante.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CbMesureSuivante.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.CbMesureSuivante.Depth = 0
        Me.CbMesureSuivante.HighEmphasis = True
        Me.CbMesureSuivante.Icon = Nothing
        Me.CbMesureSuivante.Location = New System.Drawing.Point(64, 611)
        Me.CbMesureSuivante.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.CbMesureSuivante.MouseState = MaterialSkin.MouseState.HOVER
        Me.CbMesureSuivante.Name = "CbMesureSuivante"
        Me.CbMesureSuivante.NoAccentTextColor = System.Drawing.Color.Empty
        Me.CbMesureSuivante.Size = New System.Drawing.Size(294, 126)
        Me.CbMesureSuivante.TabIndex = 9
        Me.CbMesureSuivante.Text = "Mesure suivante"
        Me.CbMesureSuivante.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.CbMesureSuivante.UseAccentColor = False
        Me.CbMesureSuivante.UseVisualStyleBackColor = True
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
        Me.cbSauvegarder.Location = New System.Drawing.Point(4, 6)
        Me.cbSauvegarder.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbSauvegarder.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbSauvegarder.Name = "cbSauvegarder"
        Me.cbSauvegarder.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbSauvegarder.Size = New System.Drawing.Size(193, 131)
        Me.cbSauvegarder.TabIndex = 10
        Me.cbSauvegarder.Text = "Sauvegarder"
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
        Me.cbQuitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbQuitter.HighEmphasis = True
        Me.cbQuitter.Icon = Nothing
        Me.cbQuitter.Location = New System.Drawing.Point(205, 6)
        Me.cbQuitter.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbQuitter.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbQuitter.Name = "cbQuitter"
        Me.cbQuitter.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbQuitter.Size = New System.Drawing.Size(194, 131)
        Me.cbQuitter.TabIndex = 11
        Me.cbQuitter.Text = "Quitter"
        Me.cbQuitter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbQuitter.UseAccentColor = False
        Me.cbQuitter.UseVisualStyleBackColor = True
        '
        'pbMesure
        '
        Me.pbMesure.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMesure.Depth = 0
        Me.pbMesure.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbMesure.Location = New System.Drawing.Point(7, 360)
        Me.pbMesure.MouseState = MaterialSkin.MouseState.HOVER
        Me.pbMesure.Name = "pbMesure"
        Me.pbMesure.Size = New System.Drawing.Size(405, 5)
        Me.pbMesure.TabIndex = 12
        '
        'TimerLectureGPS
        '
        Me.TimerLectureGPS.Interval = 1000
        '
        'ckGPSActif
        '
        Me.ckGPSActif.AutoSize = True
        Me.ckGPSActif.Depth = 0
        Me.ckGPSActif.Enabled = False
        Me.ckGPSActif.Location = New System.Drawing.Point(133, 71)
        Me.ckGPSActif.Margin = New System.Windows.Forms.Padding(0)
        Me.ckGPSActif.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.ckGPSActif.MouseState = MaterialSkin.MouseState.HOVER
        Me.ckGPSActif.Name = "ckGPSActif"
        Me.ckGPSActif.ReadOnly = False
        Me.ckGPSActif.Ripple = True
        Me.ckGPSActif.Size = New System.Drawing.Size(101, 37)
        Me.ckGPSActif.TabIndex = 14
        Me.ckGPSActif.Text = "&GPS OK"
        Me.ckGPSActif.UseVisualStyleBackColor = True
        Me.ckGPSActif.Visible = False
        '
        'ckVitessseStable
        '
        Me.ckVitessseStable.AutoSize = True
        Me.ckVitessseStable.Depth = 0
        Me.ckVitessseStable.Enabled = False
        Me.ckVitessseStable.Location = New System.Drawing.Point(267, 71)
        Me.ckVitessseStable.Margin = New System.Windows.Forms.Padding(0)
        Me.ckVitessseStable.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.ckVitessseStable.MouseState = MaterialSkin.MouseState.HOVER
        Me.ckVitessseStable.Name = "ckVitessseStable"
        Me.ckVitessseStable.ReadOnly = False
        Me.ckVitessseStable.Ripple = True
        Me.ckVitessseStable.Size = New System.Drawing.Size(141, 37)
        Me.ckVitessseStable.TabIndex = 15
        Me.ckVitessseStable.Text = "&VitesseStable"
        Me.ckVitessseStable.UseVisualStyleBackColor = True
        Me.ckVitessseStable.Visible = False
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'CkTest
        '
        Me.CkTest.AutoSize = True
        Me.CkTest.Depth = 0
        Me.CkTest.Location = New System.Drawing.Point(3, 71)
        Me.CkTest.Margin = New System.Windows.Forms.Padding(0)
        Me.CkTest.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.CkTest.MouseState = MaterialSkin.MouseState.HOVER
        Me.CkTest.Name = "CkTest"
        Me.CkTest.ReadOnly = False
        Me.CkTest.Ripple = True
        Me.CkTest.Size = New System.Drawing.Size(120, 37)
        Me.CkTest.TabIndex = 16
        Me.CkTest.Text = "Mode &Test"
        Me.CkTest.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cbSauvegarder, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbQuitter, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 746)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(403, 143)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'PnlCacheCkTest
        '
        Me.PnlCacheCkTest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlCacheCkTest.Location = New System.Drawing.Point(6, 71)
        Me.PnlCacheCkTest.Name = "PnlCacheCkTest"
        Me.PnlCacheCkTest.Size = New System.Drawing.Size(124, 37)
        Me.PnlCacheCkTest.TabIndex = 18
        '
        'tbVitesseLue
        '
        Me.tbVitesseLue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbVitesseLue.AnimateReadOnly = False
        Me.tbVitesseLue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbVitesseLue.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "VitesseLue", True))
        Me.tbVitesseLue.Depth = 0
        Me.tbVitesseLue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbVitesseLue.ForeColor = System.Drawing.Color.DodgerBlue
        Me.tbVitesseLue.LeadingIcon = Nothing
        Me.tbVitesseLue.Location = New System.Drawing.Point(193, 495)
        Me.tbVitesseLue.MaxLength = 50
        Me.tbVitesseLue.MouseState = MaterialSkin.MouseState.OUT
        Me.tbVitesseLue.Multiline = False
        Me.tbVitesseLue.Name = "tbVitesseLue"
        Me.tbVitesseLue.Size = New System.Drawing.Size(100, 50)
        Me.tbVitesseLue.TabIndex = 20
        Me.tbVitesseLue.Text = "16.5"
        Me.tbVitesseLue.TrailingIcon = Nothing
        '
        'laVitesseLue
        '
        Me.laVitesseLue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.laVitesseLue.AutoSize = True
        Me.laVitesseLue.Depth = 0
        Me.laVitesseLue.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.laVitesseLue.Location = New System.Drawing.Point(49, 508)
        Me.laVitesseLue.MouseState = MaterialSkin.MouseState.HOVER
        Me.laVitesseLue.Name = "laVitesseLue"
        Me.laVitesseLue.Size = New System.Drawing.Size(138, 19)
        Me.laVitesseLue.TabIndex = 19
        Me.laVitesseLue.Text = "Vitesse lue (km/h) :"
        '
        'MaterialLabel5
        '
        Me.MaterialLabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MaterialLabel5.AutoSize = True
        Me.MaterialLabel5.Depth = 0
        Me.MaterialLabel5.Font = New System.Drawing.Font("Roboto Medium", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        Me.MaterialLabel5.Location = New System.Drawing.Point(6, 124)
        Me.MaterialLabel5.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel5.Name = "MaterialLabel5"
        Me.MaterialLabel5.Size = New System.Drawing.Size(231, 24)
        Me.MaterialLabel5.TabIndex = 21
        Me.MaterialLabel5.Text = "Numero du pulvérisateur :"
        Me.MaterialLabel5.UseAccent = True
        '
        'lblNumPulvé
        '
        Me.lblNumPulvé.AutoSize = True
        Me.lblNumPulvé.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "NumPulve", True))
        Me.lblNumPulvé.Depth = 0
        Me.lblNumPulvé.Font = New System.Drawing.Font("Roboto Medium", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNumPulvé.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        Me.lblNumPulvé.ForeColor = System.Drawing.Color.Maroon
        Me.lblNumPulvé.Location = New System.Drawing.Point(272, 124)
        Me.lblNumPulvé.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblNumPulvé.Name = "lblNumPulvé"
        Me.lblNumPulvé.Size = New System.Drawing.Size(136, 24)
        Me.lblNumPulvé.TabIndex = 22
        Me.lblNumPulvé.Text = "MaterialLabel6"
        '
        'm_bsrcGPSMesure
        '
        Me.m_bsrcGPSMesure.DataSource = GetType(CRODIPGPS.GPSMesure)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 914)
        Me.Controls.Add(Me.lblNumPulvé)
        Me.Controls.Add(Me.MaterialLabel5)
        Me.Controls.Add(Me.tbVitesseLue)
        Me.Controls.Add(Me.laVitesseLue)
        Me.Controls.Add(Me.PnlCacheCkTest)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.CkTest)
        Me.Controls.Add(Me.ckVitessseStable)
        Me.Controls.Add(Me.ckGPSActif)
        Me.Controls.Add(Me.pbMesure)
        Me.Controls.Add(Me.CbMesureSuivante)
        Me.Controls.Add(Me.tbVitesseMesuree)
        Me.Controls.Add(Me.tbTemps)
        Me.Controls.Add(Me.tbDistance)
        Me.Controls.Add(Me.laVitesseMesuree)
        Me.Controls.Add(Me.MaterialLabel2)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Controls.Add(Me.rbMesure2)
        Me.Controls.Add(Me.rbMesure1)
        Me.Controls.Add(Me.cbMesure)
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Acquisition GPS CRODIP"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.m_bsrcGPSMesure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbMesure As MaterialSkin.Controls.MaterialButton
    Friend WithEvents rbMesure1 As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents rbMesure2 As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents laVitesseMesuree As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents tbDistance As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents tbTemps As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents tbVitesseMesuree As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents CbMesureSuivante As MaterialSkin.Controls.MaterialButton
    Friend WithEvents cbSauvegarder As MaterialSkin.Controls.MaterialButton
    Friend WithEvents cbQuitter As MaterialSkin.Controls.MaterialButton
    Friend WithEvents pbMesure As MaterialSkin.Controls.MaterialProgressBar
    Friend WithEvents TimerLectureGPS As Timer
    Friend WithEvents m_bsrcGPSMesure As BindingSource
    Friend WithEvents ckGPSActif As MaterialSkin.Controls.MaterialCheckbox
    Friend WithEvents ckVitessseStable As MaterialSkin.Controls.MaterialCheckbox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CkTest As MaterialSkin.Controls.MaterialCheckbox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PnlCacheCkTest As Panel
    Friend WithEvents tbVitesseLue As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents laVitesseLue As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel5 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents lblNumPulvé As MaterialSkin.Controls.MaterialLabel
End Class
