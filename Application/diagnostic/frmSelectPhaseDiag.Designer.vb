<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectPhaseDiag
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
        Me.ckExploitant = New System.Windows.Forms.CheckBox()
        Me.ckPulve = New System.Windows.Forms.CheckBox()
        Me.ckContexte = New System.Windows.Forms.CheckBox()
        Me.ckContrat = New System.Windows.Forms.CheckBox()
        Me.ckDefaut = New System.Windows.Forms.CheckBox()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ckExploitant
        '
        Me.ckExploitant.AutoSize = True
        Me.ckExploitant.Location = New System.Drawing.Point(12, 13)
        Me.ckExploitant.Name = "ckExploitant"
        Me.ckExploitant.Size = New System.Drawing.Size(72, 17)
        Me.ckExploitant.TabIndex = 0
        Me.ckExploitant.Text = "Exploitant"
        Me.ckExploitant.UseVisualStyleBackColor = True
        '
        'ckPulve
        '
        Me.ckPulve.AutoSize = True
        Me.ckPulve.Location = New System.Drawing.Point(12, 36)
        Me.ckPulve.Name = "ckPulve"
        Me.ckPulve.Size = New System.Drawing.Size(87, 17)
        Me.ckPulve.TabIndex = 1
        Me.ckPulve.Text = "Pulvérisateur"
        Me.ckPulve.UseVisualStyleBackColor = True
        '
        'ckContexte
        '
        Me.ckContexte.AutoSize = True
        Me.ckContexte.Location = New System.Drawing.Point(12, 59)
        Me.ckContexte.Name = "ckContexte"
        Me.ckContexte.Size = New System.Drawing.Size(124, 17)
        Me.ckContexte.TabIndex = 2
        Me.ckContexte.Text = "Contexte du contrôle"
        Me.ckContexte.UseVisualStyleBackColor = True
        '
        'ckContrat
        '
        Me.ckContrat.AutoSize = True
        Me.ckContrat.Location = New System.Drawing.Point(12, 82)
        Me.ckContrat.Name = "ckContrat"
        Me.ckContrat.Size = New System.Drawing.Size(117, 17)
        Me.ckContrat.TabIndex = 3
        Me.ckContrat.Text = "Contrat Commercial"
        Me.ckContrat.UseVisualStyleBackColor = True
        '
        'ckDefaut
        '
        Me.ckDefaut.AutoSize = True
        Me.ckDefaut.Checked = True
        Me.ckDefaut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckDefaut.Enabled = False
        Me.ckDefaut.Location = New System.Drawing.Point(12, 105)
        Me.ckDefaut.Name = "ckDefaut"
        Me.ckDefaut.Size = New System.Drawing.Size(117, 17)
        Me.ckDefaut.TabIndex = 4
        Me.ckDefaut.Text = "Défauts et mesures"
        Me.ckDefaut.UseVisualStyleBackColor = True
        '
        'btnValider
        '
        Me.btnValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnValider.FlatAppearance.BorderSize = 0
        Me.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnValider.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnValider.Image = Global.Crodip_agent.Resources.btn_valider
        Me.btnValider.Location = New System.Drawing.Point(184, 169)
        Me.btnValider.Margin = New System.Windows.Forms.Padding(0)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(130, 31)
        Me.btnValider.TabIndex = 42
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.FlatAppearance.BorderSize = 0
        Me.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnuler.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAnnuler.Image = Global.Crodip_agent.Resources.btn_delete
        Me.btnAnnuler.Location = New System.Drawing.Point(54, 169)
        Me.btnAnnuler.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(130, 31)
        Me.btnAnnuler.TabIndex = 44
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'frmSelectPhaseDiag
        '
        Me.AcceptButton = Me.btnValider
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New System.Drawing.Size(323, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnValider)
        Me.Controls.Add(Me.ckDefaut)
        Me.Controls.Add(Me.ckContrat)
        Me.Controls.Add(Me.ckContexte)
        Me.Controls.Add(Me.ckPulve)
        Me.Controls.Add(Me.ckExploitant)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectPhaseDiag"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sélection des élements à modifier"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ckExploitant As CheckBox
    Friend WithEvents ckPulve As CheckBox
    Friend WithEvents ckContexte As CheckBox
    Friend WithEvents ckContrat As CheckBox
    Friend WithEvents ckDefaut As CheckBox
    Friend WithEvents btnValider As Button
    Friend WithEvents btnAnnuler As Button
End Class
