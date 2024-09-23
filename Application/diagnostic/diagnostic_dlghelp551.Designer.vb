<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagnostic_dlghelp551
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
        Me.pnl_help551 = New System.Windows.Forms.Panel()
        Me.btnAcquisition = New System.Windows.Forms.Button()
        Me.lblCodeDefaut = New System.Windows.Forms.Label()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.laTitre = New System.Windows.Forms.Label()
        Me.help551_m2_result = New System.Windows.Forms.Label()
        Me.help551_m2_vitesseLue = New CRODIP_ControlLibrary.TBNumeric()
        Me.help551_m2_temps = New CRODIP_ControlLibrary.TBNumeric()
        Me.help551_m2_distance = New CRODIP_ControlLibrary.TBNumeric()
        Me.help551_m2_ecart = New CRODIP_ControlLibrary.TBNumeric()
        Me.help551_m2_vitesseReelle = New CRODIP_ControlLibrary.TBNumeric()
        Me.help551_m1_result = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.help551_m1_vitesseLue = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.help551_m1_temps = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.help551_m1_distance = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.help551_m1_ecart = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.help551_m1_vitesseReelle = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.help551_result = New System.Windows.Forms.Label()
        Me.help551_erreurMoyenne = New CRODIP_ControlLibrary.TBNumeric()
        Me.pnl_help551.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_help551
        '
        Me.pnl_help551.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_help551.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnl_help551.Controls.Add(Me.btnAcquisition)
        Me.pnl_help551.Controls.Add(Me.lblCodeDefaut)
        Me.pnl_help551.Controls.Add(Me.btnAnnuler)
        Me.pnl_help551.Controls.Add(Me.btnValider)
        Me.pnl_help551.Controls.Add(Me.laTitre)
        Me.pnl_help551.Controls.Add(Me.help551_m2_result)
        Me.pnl_help551.Controls.Add(Me.help551_m2_vitesseLue)
        Me.pnl_help551.Controls.Add(Me.help551_m2_temps)
        Me.pnl_help551.Controls.Add(Me.help551_m2_distance)
        Me.pnl_help551.Controls.Add(Me.help551_m2_ecart)
        Me.pnl_help551.Controls.Add(Me.help551_m2_vitesseReelle)
        Me.pnl_help551.Controls.Add(Me.help551_m1_result)
        Me.pnl_help551.Controls.Add(Me.Label56)
        Me.pnl_help551.Controls.Add(Me.help551_m1_vitesseLue)
        Me.pnl_help551.Controls.Add(Me.Label57)
        Me.pnl_help551.Controls.Add(Me.Label58)
        Me.pnl_help551.Controls.Add(Me.help551_m1_temps)
        Me.pnl_help551.Controls.Add(Me.Label59)
        Me.pnl_help551.Controls.Add(Me.help551_m1_distance)
        Me.pnl_help551.Controls.Add(Me.Label60)
        Me.pnl_help551.Controls.Add(Me.help551_m1_ecart)
        Me.pnl_help551.Controls.Add(Me.Label61)
        Me.pnl_help551.Controls.Add(Me.help551_m1_vitesseReelle)
        Me.pnl_help551.Controls.Add(Me.Label85)
        Me.pnl_help551.Controls.Add(Me.help551_result)
        Me.pnl_help551.Controls.Add(Me.help551_erreurMoyenne)
        Me.pnl_help551.Location = New System.Drawing.Point(5, 5)
        Me.pnl_help551.Name = "pnl_help551"
        Me.pnl_help551.Size = New System.Drawing.Size(488, 258)
        Me.pnl_help551.TabIndex = 1
        '
        'btnAcquisition
        '
        Me.btnAcquisition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAcquisition.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAcquisition.BackgroundImage = Global.Crodip_agent.Resources.btn_valider
        Me.btnAcquisition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAcquisition.Enabled = Global.Crodip_agent.MySettings.Default.AcquisitionGPS
        Me.btnAcquisition.FlatAppearance.BorderSize = 0
        Me.btnAcquisition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAcquisition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAcquisition.ForeColor = System.Drawing.Color.White
        Me.btnAcquisition.Location = New System.Drawing.Point(23, 222)
        Me.btnAcquisition.Name = "btnAcquisition"
        Me.btnAcquisition.Size = New System.Drawing.Size(164, 29)
        Me.btnAcquisition.TabIndex = 60
        Me.btnAcquisition.Text = "      Mesure GPS"
        Me.btnAcquisition.UseVisualStyleBackColor = False
        Me.btnAcquisition.Visible = Global.Crodip_agent.MySettings.Default.AcquisitionGPS
        '
        'lblCodeDefaut
        '
        Me.lblCodeDefaut.AutoSize = True
        Me.lblCodeDefaut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblCodeDefaut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCodeDefaut.Location = New System.Drawing.Point(7, 4)
        Me.lblCodeDefaut.Name = "lblCodeDefaut"
        Me.lblCodeDefaut.Size = New System.Drawing.Size(19, 13)
        Me.lblCodeDefaut.TabIndex = 59
        Me.lblCodeDefaut.Text = "..."
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAnnuler.BackgroundImage = Global.Crodip_agent.Resources.btn_annuler
        Me.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.FlatAppearance.BorderSize = 0
        Me.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Location = New System.Drawing.Point(350, 222)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(131, 29)
        Me.btnAnnuler.TabIndex = 58
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
        Me.btnValider.Location = New System.Drawing.Point(207, 222)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(137, 29)
        Me.btnValider.TabIndex = 57
        Me.btnValider.Text = "OK"
        Me.btnValider.UseVisualStyleBackColor = False
        '
        'laTitre
        '
        Me.laTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laTitre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.laTitre.Location = New System.Drawing.Point(69, 4)
        Me.laTitre.Name = "laTitre"
        Me.laTitre.Size = New System.Drawing.Size(405, 29)
        Me.laTitre.TabIndex = 56
        Me.laTitre.Text = "Titre"
        Me.laTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'help551_m2_result
        '
        Me.help551_m2_result.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help551_m2_result.ForeColor = System.Drawing.Color.Red
        Me.help551_m2_result.Location = New System.Drawing.Point(317, 159)
        Me.help551_m2_result.Name = "help551_m2_result"
        Me.help551_m2_result.Size = New System.Drawing.Size(134, 16)
        Me.help551_m2_result.TabIndex = 55
        Me.help551_m2_result.Text = "IMPRECISION"
        Me.help551_m2_result.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'help551_m2_vitesseLue
        '
        Me.help551_m2_vitesseLue.ForceBindingOnTextChanged = False
        Me.help551_m2_vitesseLue.Location = New System.Drawing.Point(315, 108)
        Me.help551_m2_vitesseLue.Name = "help551_m2_vitesseLue"
        Me.help551_m2_vitesseLue.Size = New System.Drawing.Size(136, 20)
        Me.help551_m2_vitesseLue.TabIndex = 53
        '
        'help551_m2_temps
        '
        Me.help551_m2_temps.ForceBindingOnTextChanged = False
        Me.help551_m2_temps.Location = New System.Drawing.Point(315, 60)
        Me.help551_m2_temps.Name = "help551_m2_temps"
        Me.help551_m2_temps.Size = New System.Drawing.Size(136, 20)
        Me.help551_m2_temps.TabIndex = 51
        '
        'help551_m2_distance
        '
        Me.help551_m2_distance.ForceBindingOnTextChanged = False
        Me.help551_m2_distance.Location = New System.Drawing.Point(315, 36)
        Me.help551_m2_distance.Name = "help551_m2_distance"
        Me.help551_m2_distance.Size = New System.Drawing.Size(136, 20)
        Me.help551_m2_distance.TabIndex = 50
        '
        'help551_m2_ecart
        '
        Me.help551_m2_ecart.ForceBindingOnTextChanged = False
        Me.help551_m2_ecart.Location = New System.Drawing.Point(315, 132)
        Me.help551_m2_ecart.Name = "help551_m2_ecart"
        Me.help551_m2_ecart.ReadOnly = True
        Me.help551_m2_ecart.Size = New System.Drawing.Size(136, 20)
        Me.help551_m2_ecart.TabIndex = 54
        Me.help551_m2_ecart.TabStop = False
        '
        'help551_m2_vitesseReelle
        '
        Me.help551_m2_vitesseReelle.ForceBindingOnTextChanged = False
        Me.help551_m2_vitesseReelle.Location = New System.Drawing.Point(315, 84)
        Me.help551_m2_vitesseReelle.Name = "help551_m2_vitesseReelle"
        Me.help551_m2_vitesseReelle.ReadOnly = True
        Me.help551_m2_vitesseReelle.Size = New System.Drawing.Size(136, 20)
        Me.help551_m2_vitesseReelle.TabIndex = 52
        Me.help551_m2_vitesseReelle.TabStop = False
        '
        'help551_m1_result
        '
        Me.help551_m1_result.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help551_m1_result.ForeColor = System.Drawing.Color.Red
        Me.help551_m1_result.Location = New System.Drawing.Point(170, 159)
        Me.help551_m1_result.Name = "help551_m1_result"
        Me.help551_m1_result.Size = New System.Drawing.Size(136, 16)
        Me.help551_m1_result.TabIndex = 43
        Me.help551_m1_result.Text = "IMPRECISION"
        Me.help551_m1_result.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label56
        '
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label56.Location = New System.Drawing.Point(16, 108)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(144, 16)
        Me.Label56.TabIndex = 44
        Me.Label56.Text = "Vitesse lue (en km/h)"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help551_m1_vitesseLue
        '
        Me.help551_m1_vitesseLue.ForceBindingOnTextChanged = False
        Me.help551_m1_vitesseLue.Location = New System.Drawing.Point(168, 108)
        Me.help551_m1_vitesseLue.Name = "help551_m1_vitesseLue"
        Me.help551_m1_vitesseLue.Size = New System.Drawing.Size(136, 20)
        Me.help551_m1_vitesseLue.TabIndex = 41
        '
        'Label57
        '
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label57.Location = New System.Drawing.Point(16, 156)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(144, 16)
        Me.Label57.TabIndex = 46
        Me.Label57.Text = "Résultat"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label58.Location = New System.Drawing.Point(16, 60)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(144, 16)
        Me.Label58.TabIndex = 47
        Me.Label58.Text = "Temps (s)"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help551_m1_temps
        '
        Me.help551_m1_temps.ForceBindingOnTextChanged = False
        Me.help551_m1_temps.Location = New System.Drawing.Point(168, 60)
        Me.help551_m1_temps.Name = "help551_m1_temps"
        Me.help551_m1_temps.Size = New System.Drawing.Size(136, 20)
        Me.help551_m1_temps.TabIndex = 39
        '
        'Label59
        '
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label59.Location = New System.Drawing.Point(16, 36)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(144, 16)
        Me.Label59.TabIndex = 48
        Me.Label59.Text = "Distance (m)"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help551_m1_distance
        '
        Me.help551_m1_distance.ForceBindingOnTextChanged = False
        Me.help551_m1_distance.Location = New System.Drawing.Point(168, 36)
        Me.help551_m1_distance.Name = "help551_m1_distance"
        Me.help551_m1_distance.Size = New System.Drawing.Size(136, 20)
        Me.help551_m1_distance.TabIndex = 38
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label60.Location = New System.Drawing.Point(16, 132)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(144, 16)
        Me.Label60.TabIndex = 49
        Me.Label60.Text = "Ecart (%)"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help551_m1_ecart
        '
        Me.help551_m1_ecart.ForceBindingOnTextChanged = False
        Me.help551_m1_ecart.Location = New System.Drawing.Point(168, 132)
        Me.help551_m1_ecart.Name = "help551_m1_ecart"
        Me.help551_m1_ecart.ReadOnly = True
        Me.help551_m1_ecart.Size = New System.Drawing.Size(136, 20)
        Me.help551_m1_ecart.TabIndex = 42
        Me.help551_m1_ecart.TabStop = False
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(16, 84)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(144, 16)
        Me.Label61.TabIndex = 45
        Me.Label61.Text = "Vitesse réelle (en km/h)"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help551_m1_vitesseReelle
        '
        Me.help551_m1_vitesseReelle.ForceBindingOnTextChanged = False
        Me.help551_m1_vitesseReelle.Location = New System.Drawing.Point(168, 84)
        Me.help551_m1_vitesseReelle.Name = "help551_m1_vitesseReelle"
        Me.help551_m1_vitesseReelle.ReadOnly = True
        Me.help551_m1_vitesseReelle.Size = New System.Drawing.Size(136, 20)
        Me.help551_m1_vitesseReelle.TabIndex = 40
        Me.help551_m1_vitesseReelle.TabStop = False
        '
        'Label85
        '
        Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label85.Location = New System.Drawing.Point(4, 186)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(156, 16)
        Me.Label85.TabIndex = 32
        Me.Label85.Text = "Erreur moyenne (%) :"
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'help551_result
        '
        Me.help551_result.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help551_result.ForeColor = System.Drawing.Color.Red
        Me.help551_result.Location = New System.Drawing.Point(315, 186)
        Me.help551_result.Name = "help551_result"
        Me.help551_result.Size = New System.Drawing.Size(136, 16)
        Me.help551_result.TabIndex = 30
        Me.help551_result.Text = "IMPRECISION"
        Me.help551_result.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'help551_erreurMoyenne
        '
        Me.help551_erreurMoyenne.ForceBindingOnTextChanged = False
        Me.help551_erreurMoyenne.Location = New System.Drawing.Point(168, 185)
        Me.help551_erreurMoyenne.Name = "help551_erreurMoyenne"
        Me.help551_erreurMoyenne.ReadOnly = True
        Me.help551_erreurMoyenne.Size = New System.Drawing.Size(136, 20)
        Me.help551_erreurMoyenne.TabIndex = 33
        Me.help551_erreurMoyenne.TabStop = False
        '
        'diagnostic_dlghelp551
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(498, 268)
        Me.Controls.Add(Me.pnl_help551)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diagnostic_dlghelp551"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.pnl_help551.ResumeLayout(False)
        Me.pnl_help551.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_help551 As System.Windows.Forms.Panel
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents help551_result As System.Windows.Forms.Label
    Friend WithEvents help551_erreurMoyenne As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help551_m2_result As System.Windows.Forms.Label
    Friend WithEvents help551_m2_vitesseLue As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help551_m2_temps As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help551_m2_distance As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help551_m2_ecart As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help551_m2_vitesseReelle As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents help551_m1_result As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents help551_m1_vitesseLue As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents help551_m1_temps As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents help551_m1_distance As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents help551_m1_ecart As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents help551_m1_vitesseReelle As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents laTitre As System.Windows.Forms.Label
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents btnValider As System.Windows.Forms.Button
    Friend WithEvents lblCodeDefaut As System.Windows.Forms.Label
    Friend WithEvents btnAcquisition As Button
End Class
