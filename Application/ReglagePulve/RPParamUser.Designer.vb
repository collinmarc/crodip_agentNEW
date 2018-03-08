<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPParamUser
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.dtExpiration = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbFolder = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbGenerer = New System.Windows.Forms.Button()
        Me.tbAnnuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code : "
        '
        'tbCode
        '
        Me.tbCode.Location = New System.Drawing.Point(103, 10)
        Me.tbCode.Name = "tbCode"
        Me.tbCode.Size = New System.Drawing.Size(100, 20)
        Me.tbCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mot de passe : "
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(103, 43)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(100, 20)
        Me.tbPassword.TabIndex = 3
        '
        'dtExpiration
        '
        Me.dtExpiration.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtExpiration.Location = New System.Drawing.Point(103, 79)
        Me.dtExpiration.Name = "dtExpiration"
        Me.dtExpiration.Size = New System.Drawing.Size(100, 20)
        Me.dtExpiration.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Date expiration :"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Choisissez l'emplacement de génération"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Emplacement : "
        '
        'tbFolder
        '
        Me.tbFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFolder.Location = New System.Drawing.Point(103, 113)
        Me.tbFolder.Name = "tbFolder"
        Me.tbFolder.Size = New System.Drawing.Size(398, 20)
        Me.tbFolder.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(507, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 21)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Parcourir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbGenerer
        '
        Me.tbGenerer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbGenerer.Location = New System.Drawing.Point(511, 155)
        Me.tbGenerer.Name = "tbGenerer"
        Me.tbGenerer.Size = New System.Drawing.Size(76, 27)
        Me.tbGenerer.TabIndex = 9
        Me.tbGenerer.Text = "Générer"
        Me.tbGenerer.UseVisualStyleBackColor = True
        '
        'tbAnnuler
        '
        Me.tbAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAnnuler.Location = New System.Drawing.Point(426, 157)
        Me.tbAnnuler.Name = "tbAnnuler"
        Me.tbAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.tbAnnuler.TabIndex = 10
        Me.tbAnnuler.Text = "Annuler"
        Me.tbAnnuler.UseVisualStyleBackColor = True
        '
        'RPParamUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 197)
        Me.Controls.Add(Me.tbAnnuler)
        Me.Controls.Add(Me.tbGenerer)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbFolder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtExpiration)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbCode)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RPParamUser"
        Me.Text = "Paramétrage Utilisateur Reglage Pulvé"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents dtExpiration As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents tbFolder As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents tbGenerer As Button
    Friend WithEvents tbAnnuler As Button
End Class
