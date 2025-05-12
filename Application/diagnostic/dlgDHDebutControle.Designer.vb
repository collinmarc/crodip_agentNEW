<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDHDebutControle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgDHDebutControle))
        Me.dtpHeuredebutcontrole = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateDebutControle = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_retour = New System.Windows.Forms.Label()
        Me.btn_poursuivre = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpHeuredebutcontrole
        '
        Me.dtpHeuredebutcontrole.CustomFormat = "HH':'mm"
        Me.dtpHeuredebutcontrole.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHeuredebutcontrole.Location = New System.Drawing.Point(200, 38)
        Me.dtpHeuredebutcontrole.Name = "dtpHeuredebutcontrole"
        Me.dtpHeuredebutcontrole.ShowUpDown = True
        Me.dtpHeuredebutcontrole.Size = New System.Drawing.Size(70, 20)
        Me.dtpHeuredebutcontrole.TabIndex = 12
        '
        'dtpDateDebutControle
        '
        Me.dtpDateDebutControle.Location = New System.Drawing.Point(200, 12)
        Me.dtpDateDebutControle.Name = "dtpDateDebutControle"
        Me.dtpDateDebutControle.Size = New System.Drawing.Size(196, 20)
        Me.dtpDateDebutControle.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(14, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(183, 20)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Date de début de contrôle : "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(14, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(183, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Heure de début de contrôle : "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btn_retour
        '
        Me.btn_retour.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_retour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_retour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_retour.ForeColor = System.Drawing.Color.White
        Me.btn_retour.Image = CType(resources.GetObject("btn_retour.Image"), System.Drawing.Image)
        Me.btn_retour.Location = New System.Drawing.Point(12, 81)
        Me.btn_retour.Name = "btn_retour"
        Me.btn_retour.Size = New System.Drawing.Size(128, 24)
        Me.btn_retour.TabIndex = 15
        Me.btn_retour.Text = "    Retour"
        Me.btn_retour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_poursuivre
        '
        Me.btn_poursuivre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_poursuivre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_poursuivre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_poursuivre.ForeColor = System.Drawing.Color.White
        Me.btn_poursuivre.Image = CType(resources.GetObject("btn_poursuivre.Image"), System.Drawing.Image)
        Me.btn_poursuivre.Location = New System.Drawing.Point(291, 81)
        Me.btn_poursuivre.Name = "btn_poursuivre"
        Me.btn_poursuivre.Size = New System.Drawing.Size(140, 24)
        Me.btn_poursuivre.TabIndex = 16
        Me.btn_poursuivre.Text = "    Poursuivre"
        Me.btn_poursuivre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dialog1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 114)
        Me.Controls.Add(Me.btn_poursuivre)
        Me.Controls.Add(Me.btn_retour)
        Me.Controls.Add(Me.dtpHeuredebutcontrole)
        Me.Controls.Add(Me.dtpDateDebutControle)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Création d'un contrôle"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpHeuredebutcontrole As DateTimePicker
    Friend WithEvents dtpDateDebutControle As DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_retour As Label
    Friend WithEvents btn_poursuivre As Label
End Class
