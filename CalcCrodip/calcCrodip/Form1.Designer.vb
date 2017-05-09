<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.BTN_RAMPE = New System.Windows.Forms.Button()
        Me.BTN_ARBO = New System.Windows.Forms.Button()
        Me.BTN_DOS = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BTN_RAMPE
        '
        Me.BTN_RAMPE.Location = New System.Drawing.Point(13, 13)
        Me.BTN_RAMPE.Name = "BTN_RAMPE"
        Me.BTN_RAMPE.Size = New System.Drawing.Size(324, 86)
        Me.BTN_RAMPE.TabIndex = 0
        Me.BTN_RAMPE.Text = "Rampe"
        Me.BTN_RAMPE.UseVisualStyleBackColor = True
        '
        'BTN_ARBO
        '
        Me.BTN_ARBO.Location = New System.Drawing.Point(13, 105)
        Me.BTN_ARBO.Name = "BTN_ARBO"
        Me.BTN_ARBO.Size = New System.Drawing.Size(324, 80)
        Me.BTN_ARBO.TabIndex = 1
        Me.BTN_ARBO.Text = "ArboViti"
        Me.BTN_ARBO.UseVisualStyleBackColor = True
        '
        'BTN_DOS
        '
        Me.BTN_DOS.Location = New System.Drawing.Point(13, 191)
        Me.BTN_DOS.Name = "BTN_DOS"
        Me.BTN_DOS.Size = New System.Drawing.Size(324, 105)
        Me.BTN_DOS.TabIndex = 2
        Me.BTN_DOS.Text = "Pulvé à dos"
        Me.BTN_DOS.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 308)
        Me.Controls.Add(Me.BTN_DOS)
        Me.Controls.Add(Me.BTN_ARBO)
        Me.Controls.Add(Me.BTN_RAMPE)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTN_RAMPE As System.Windows.Forms.Button
    Friend WithEvents BTN_ARBO As System.Windows.Forms.Button
    Friend WithEvents BTN_DOS As System.Windows.Forms.Button

End Class
