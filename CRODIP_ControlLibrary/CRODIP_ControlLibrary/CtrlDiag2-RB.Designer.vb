<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrlDiag2_RB
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.rb1 = New System.Windows.Forms.RadioButton()
        Me.rb2 = New System.Windows.Forms.RadioButton()
        Me.rb3 = New System.Windows.Forms.RadioButton()
        Me.rb0 = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'rb1
        '
        Me.rb1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rb1.BackColor = System.Drawing.Color.Green
        Me.rb1.FlatAppearance.BorderSize = 0
        Me.rb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb1.ForeColor = System.Drawing.Color.White
        Me.rb1.Location = New System.Drawing.Point(29, 0)
        Me.rb1.Margin = New System.Windows.Forms.Padding(0)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(29, 20)
        Me.rb1.TabIndex = 1
        Me.rb1.TabStop = True
        Me.rb1.Text = " 1"
        Me.rb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.rb1, "Impossibilité de contrôle liée à la conception")
        Me.rb1.UseVisualStyleBackColor = False
        '
        'rb2
        '
        Me.rb2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rb2.BackColor = System.Drawing.Color.Red
        Me.rb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb2.ForeColor = System.Drawing.Color.White
        Me.rb2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rb2.Location = New System.Drawing.Point(58, 0)
        Me.rb2.Margin = New System.Windows.Forms.Padding(0)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(29, 20)
        Me.rb2.TabIndex = 2
        Me.rb2.TabStop = True
        Me.rb2.Text = " 2"
        Me.rb2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.rb2, "Impossibilité de contrôle liée à la maintenance")
        Me.rb2.UseVisualStyleBackColor = False
        '
        'rb3
        '
        Me.rb3.Appearance = System.Windows.Forms.Appearance.Button
        Me.rb3.BackColor = System.Drawing.Color.Green
        Me.rb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb3.ForeColor = System.Drawing.Color.White
        Me.rb3.Location = New System.Drawing.Point(87, 0)
        Me.rb3.Margin = New System.Windows.Forms.Padding(0)
        Me.rb3.Name = "rb3"
        Me.rb3.Size = New System.Drawing.Size(29, 20)
        Me.rb3.TabIndex = 3
        Me.rb3.TabStop = True
        Me.rb3.Text = " 3"
        Me.rb3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rb3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.ToolTip1.SetToolTip(Me.rb3, "Défaut lié à la conception")
        Me.rb3.UseVisualStyleBackColor = False
        '
        'rb0
        '
        Me.rb0.Appearance = System.Windows.Forms.Appearance.Button
        Me.rb0.BackColor = System.Drawing.Color.Silver
        Me.rb0.Location = New System.Drawing.Point(0, 0)
        Me.rb0.Margin = New System.Windows.Forms.Padding(0)
        Me.rb0.Name = "rb0"
        Me.rb0.Size = New System.Drawing.Size(29, 20)
        Me.rb0.TabIndex = 0
        Me.rb0.TabStop = True
        Me.rb0.Text = " "
        Me.rb0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.rb0, "Pas de cause identifiée")
        Me.rb0.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "Cause du défaut"
        '
        'CtrlDiag2_RB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rb1)
        Me.Controls.Add(Me.rb2)
        Me.Controls.Add(Me.rb3)
        Me.Controls.Add(Me.rb0)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "CtrlDiag2_RB"
        Me.Size = New System.Drawing.Size(115, 19)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rb0 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb3 As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
