<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tool_ParamModeSimplifie
    Inherits System.Windows.Forms.Form

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
        Me.dtExpiration = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.m_FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbFolder = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbGenerer = New System.Windows.Forms.Button()
        Me.tbAnnuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dtExpiration
        '
        Me.dtExpiration.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtExpiration.Location = New System.Drawing.Point(96, 6)
        Me.dtExpiration.Name = "dtExpiration"
        Me.dtExpiration.Size = New System.Drawing.Size(100, 20)
        Me.dtExpiration.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Date expiration :"
        '
        'm_FolderBrowserDialog1
        '
        Me.m_FolderBrowserDialog1.Description = "Choisissez l'emplacement de génération"
        Me.m_FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Emplacement : "
        '
        'tbFolder
        '
        Me.tbFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFolder.Location = New System.Drawing.Point(96, 40)
        Me.tbFolder.Name = "tbFolder"
        Me.tbFolder.Size = New System.Drawing.Size(394, 20)
        Me.tbFolder.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(496, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 21)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Parcourir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbGenerer
        '
        Me.tbGenerer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbGenerer.Location = New System.Drawing.Point(502, 78)
        Me.tbGenerer.Name = "tbGenerer"
        Me.tbGenerer.Size = New System.Drawing.Size(75, 27)
        Me.tbGenerer.TabIndex = 9
        Me.tbGenerer.Text = "Générer"
        Me.tbGenerer.UseVisualStyleBackColor = True
        '
        'tbAnnuler
        '
        Me.tbAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAnnuler.Location = New System.Drawing.Point(417, 80)
        Me.tbAnnuler.Name = "tbAnnuler"
        Me.tbAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.tbAnnuler.TabIndex = 10
        Me.tbAnnuler.Text = "Annuler"
        Me.tbAnnuler.UseVisualStyleBackColor = True
        '
        'tool_ParamModeSimplifie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 117)
        Me.Controls.Add(Me.tbAnnuler)
        Me.Controls.Add(Me.tbGenerer)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbFolder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtExpiration)
        Me.Name = "tool_ParamModeSimplifie"
        Me.Text = "Paramétrage Date expiration du mode simplifié"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtExpiration As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents m_FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents tbFolder As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents tbGenerer As Button
    Friend WithEvents tbAnnuler As Button
End Class
