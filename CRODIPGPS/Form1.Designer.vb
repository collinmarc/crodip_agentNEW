<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits MaterialSkin.Controls.MaterialForm

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
        Me.cbMesure = New MaterialSkin.Controls.MaterialButton()
        Me.rbMesure1 = New MaterialSkin.Controls.MaterialRadioButton()
        Me.rbMesure2 = New MaterialSkin.Controls.MaterialRadioButton()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialLabel3 = New MaterialSkin.Controls.MaterialLabel()
        Me.tbDistance = New MaterialSkin.Controls.MaterialTextBox()
        Me.tbTemps = New MaterialSkin.Controls.MaterialTextBox()
        Me.MaterialTextBox1 = New MaterialSkin.Controls.MaterialTextBox()
        Me.CbMesureSuivante = New MaterialSkin.Controls.MaterialButton()
        Me.cbExporter = New MaterialSkin.Controls.MaterialButton()
        Me.cbQuitter = New MaterialSkin.Controls.MaterialButton()
        Me.pbMesure = New MaterialSkin.Controls.MaterialProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ckGPSActif = New MaterialSkin.Controls.MaterialCheckbox()
        Me.ckVitessseStable = New MaterialSkin.Controls.MaterialCheckbox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.m_bsrcGPSMesure = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.cbMesure.Location = New System.Drawing.Point(7, 191)
        Me.cbMesure.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbMesure.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbMesure.Name = "cbMesure"
        Me.cbMesure.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbMesure.Size = New System.Drawing.Size(438, 49)
        Me.cbMesure.TabIndex = 0
        Me.cbMesure.Text = "Démarer"
        Me.cbMesure.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbMesure.UseAccentColor = False
        Me.cbMesure.UseVisualStyleBackColor = True
        '
        'rbMesure1
        '
        Me.rbMesure1.AutoSize = True
        Me.rbMesure1.Checked = True
        Me.rbMesure1.Depth = 0
        Me.rbMesure1.Location = New System.Drawing.Point(44, 81)
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
        Me.rbMesure2.Location = New System.Drawing.Point(168, 81)
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
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel1.Location = New System.Drawing.Point(52, 290)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(100, 19)
        Me.MaterialLabel1.TabIndex = 3
        Me.MaterialLabel1.Text = "Distance (m) :"
        '
        'MaterialLabel2
        '
        Me.MaterialLabel2.AutoSize = True
        Me.MaterialLabel2.Depth = 0
        Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel2.Location = New System.Drawing.Point(52, 341)
        Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel2.Name = "MaterialLabel2"
        Me.MaterialLabel2.Size = New System.Drawing.Size(81, 19)
        Me.MaterialLabel2.TabIndex = 4
        Me.MaterialLabel2.Text = "Temps (s) :"
        '
        'MaterialLabel3
        '
        Me.MaterialLabel3.AutoSize = True
        Me.MaterialLabel3.Depth = 0
        Me.MaterialLabel3.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel3.Location = New System.Drawing.Point(41, 417)
        Me.MaterialLabel3.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel3.Name = "MaterialLabel3"
        Me.MaterialLabel3.Size = New System.Drawing.Size(113, 19)
        Me.MaterialLabel3.TabIndex = 5
        Me.MaterialLabel3.Text = "Vitesse (km/h) :"
        '
        'tbDistance
        '
        Me.tbDistance.AnimateReadOnly = False
        Me.tbDistance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbDistance.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Distance", True))
        Me.tbDistance.Depth = 0
        Me.tbDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbDistance.LeadingIcon = Nothing
        Me.tbDistance.Location = New System.Drawing.Point(168, 273)
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
        Me.tbTemps.AnimateReadOnly = False
        Me.tbTemps.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbTemps.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Temps", True))
        Me.tbTemps.Depth = 0
        Me.tbTemps.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbTemps.LeadingIcon = Nothing
        Me.tbTemps.Location = New System.Drawing.Point(168, 329)
        Me.tbTemps.MaxLength = 50
        Me.tbTemps.MouseState = MaterialSkin.MouseState.OUT
        Me.tbTemps.Multiline = False
        Me.tbTemps.Name = "tbTemps"
        Me.tbTemps.Size = New System.Drawing.Size(100, 50)
        Me.tbTemps.TabIndex = 7
        Me.tbTemps.Text = "90"
        Me.tbTemps.TrailingIcon = Nothing
        '
        'MaterialTextBox1
        '
        Me.MaterialTextBox1.AnimateReadOnly = False
        Me.MaterialTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MaterialTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcGPSMesure, "Vitesse", True))
        Me.MaterialTextBox1.Depth = 0
        Me.MaterialTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.MaterialTextBox1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.MaterialTextBox1.LeadingIcon = Nothing
        Me.MaterialTextBox1.Location = New System.Drawing.Point(168, 403)
        Me.MaterialTextBox1.MaxLength = 50
        Me.MaterialTextBox1.MouseState = MaterialSkin.MouseState.OUT
        Me.MaterialTextBox1.Multiline = False
        Me.MaterialTextBox1.Name = "MaterialTextBox1"
        Me.MaterialTextBox1.Size = New System.Drawing.Size(100, 50)
        Me.MaterialTextBox1.TabIndex = 8
        Me.MaterialTextBox1.Text = "16.5"
        Me.MaterialTextBox1.TrailingIcon = Nothing
        '
        'CbMesureSuivante
        '
        Me.CbMesureSuivante.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbMesureSuivante.AutoSize = False
        Me.CbMesureSuivante.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CbMesureSuivante.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.CbMesureSuivante.Depth = 0
        Me.CbMesureSuivante.HighEmphasis = True
        Me.CbMesureSuivante.Icon = Nothing
        Me.CbMesureSuivante.Location = New System.Drawing.Point(55, 489)
        Me.CbMesureSuivante.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.CbMesureSuivante.MouseState = MaterialSkin.MouseState.HOVER
        Me.CbMesureSuivante.Name = "CbMesureSuivante"
        Me.CbMesureSuivante.NoAccentTextColor = System.Drawing.Color.Empty
        Me.CbMesureSuivante.Size = New System.Drawing.Size(327, 73)
        Me.CbMesureSuivante.TabIndex = 9
        Me.CbMesureSuivante.Text = "Mesure suivante"
        Me.CbMesureSuivante.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.CbMesureSuivante.UseAccentColor = False
        Me.CbMesureSuivante.UseVisualStyleBackColor = True
        '
        'cbExporter
        '
        Me.cbExporter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbExporter.AutoSize = False
        Me.cbExporter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cbExporter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.cbExporter.Depth = 0
        Me.cbExporter.HighEmphasis = True
        Me.cbExporter.Icon = Nothing
        Me.cbExporter.Location = New System.Drawing.Point(10, 583)
        Me.cbExporter.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbExporter.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbExporter.Name = "cbExporter"
        Me.cbExporter.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbExporter.Size = New System.Drawing.Size(178, 73)
        Me.cbExporter.TabIndex = 10
        Me.cbExporter.Text = "Exporter"
        Me.cbExporter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbExporter.UseAccentColor = False
        Me.cbExporter.UseVisualStyleBackColor = True
        '
        'cbQuitter
        '
        Me.cbQuitter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbQuitter.AutoSize = False
        Me.cbQuitter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cbQuitter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.cbQuitter.Depth = 0
        Me.cbQuitter.HighEmphasis = True
        Me.cbQuitter.Icon = Nothing
        Me.cbQuitter.Location = New System.Drawing.Point(260, 583)
        Me.cbQuitter.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbQuitter.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbQuitter.Name = "cbQuitter"
        Me.cbQuitter.NoAccentTextColor = System.Drawing.Color.Empty
        Me.cbQuitter.Size = New System.Drawing.Size(176, 73)
        Me.cbQuitter.TabIndex = 11
        Me.cbQuitter.Text = "Quitter"
        Me.cbQuitter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.cbQuitter.UseAccentColor = False
        Me.cbQuitter.UseVisualStyleBackColor = True
        '
        'pbMesure
        '
        Me.pbMesure.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMesure.Depth = 0
        Me.pbMesure.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbMesure.Location = New System.Drawing.Point(7, 249)
        Me.pbMesure.MouseState = MaterialSkin.MouseState.HOVER
        Me.pbMesure.Name = "pbMesure"
        Me.pbMesure.Size = New System.Drawing.Size(438, 5)
        Me.pbMesure.TabIndex = 12
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'ckGPSActif
        '
        Me.ckGPSActif.AutoSize = True
        Me.ckGPSActif.Depth = 0
        Me.ckGPSActif.Location = New System.Drawing.Point(358, 81)
        Me.ckGPSActif.Margin = New System.Windows.Forms.Padding(0)
        Me.ckGPSActif.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.ckGPSActif.MouseState = MaterialSkin.MouseState.HOVER
        Me.ckGPSActif.Name = "ckGPSActif"
        Me.ckGPSActif.ReadOnly = False
        Me.ckGPSActif.Ripple = True
        Me.ckGPSActif.Size = New System.Drawing.Size(91, 37)
        Me.ckGPSActif.TabIndex = 14
        Me.ckGPSActif.Text = "GPS OK"
        Me.ckGPSActif.UseVisualStyleBackColor = True
        '
        'ckVitessseStable
        '
        Me.ckVitessseStable.AutoSize = True
        Me.ckVitessseStable.Depth = 0
        Me.ckVitessseStable.Location = New System.Drawing.Point(318, 118)
        Me.ckVitessseStable.Margin = New System.Windows.Forms.Padding(0)
        Me.ckVitessseStable.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.ckVitessseStable.MouseState = MaterialSkin.MouseState.HOVER
        Me.ckVitessseStable.Name = "ckVitessseStable"
        Me.ckVitessseStable.ReadOnly = False
        Me.ckVitessseStable.Ripple = True
        Me.ckVitessseStable.Size = New System.Drawing.Size(131, 37)
        Me.ckVitessseStable.TabIndex = 15
        Me.ckVitessseStable.Text = "VitesseStable"
        Me.ckVitessseStable.UseVisualStyleBackColor = True
        '
        'm_bsrcGPSMesure
        '
        Me.m_bsrcGPSMesure.DataSource = GetType(CRODIPGPS.GPSMesure)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 665)
        Me.Controls.Add(Me.ckVitessseStable)
        Me.Controls.Add(Me.ckGPSActif)
        Me.Controls.Add(Me.pbMesure)
        Me.Controls.Add(Me.cbQuitter)
        Me.Controls.Add(Me.cbExporter)
        Me.Controls.Add(Me.CbMesureSuivante)
        Me.Controls.Add(Me.MaterialTextBox1)
        Me.Controls.Add(Me.tbTemps)
        Me.Controls.Add(Me.tbDistance)
        Me.Controls.Add(Me.MaterialLabel3)
        Me.Controls.Add(Me.MaterialLabel2)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Controls.Add(Me.rbMesure2)
        Me.Controls.Add(Me.rbMesure1)
        Me.Controls.Add(Me.cbMesure)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Acquisition GPS CRODIP"
        CType(Me.m_bsrcGPSMesure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbMesure As MaterialSkin.Controls.MaterialButton
    Friend WithEvents rbMesure1 As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents rbMesure2 As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel3 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents tbDistance As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents tbTemps As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents MaterialTextBox1 As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents CbMesureSuivante As MaterialSkin.Controls.MaterialButton
    Friend WithEvents cbExporter As MaterialSkin.Controls.MaterialButton
    Friend WithEvents cbQuitter As MaterialSkin.Controls.MaterialButton
    Friend WithEvents pbMesure As MaterialSkin.Controls.MaterialProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents m_bsrcGPSMesure As BindingSource
    Friend WithEvents Timer2 As Timer
    Friend WithEvents ckGPSActif As MaterialSkin.Controls.MaterialCheckbox
    Friend WithEvents ckVitessseStable As MaterialSkin.Controls.MaterialCheckbox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
