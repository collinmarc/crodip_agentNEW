<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSignClientTelephone
    Inherits frmSignClient

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
    Public Overrides Sub InitializeComponent()
        Me.pctSignature = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.dtpDateSignature = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckConserverSignature = New System.Windows.Forms.CheckBox()
        CType(Me.pctSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pctSignature
        '
        Me.pctSignature.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctSignature.BackColor = System.Drawing.Color.White
        Me.pctSignature.Location = New System.Drawing.Point(11, 6)
        Me.pctSignature.Name = "pctSignature"
        Me.pctSignature.Size = New System.Drawing.Size(604, 148)
        Me.pctSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctSignature.TabIndex = 0
        Me.pctSignature.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(16, 195)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 48)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Quitter"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnValider
        '
        Me.btnValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValider.Location = New System.Drawing.Point(484, 197)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(112, 46)
        Me.btnValider.TabIndex = 2
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(256, 196)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 48)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Effacer"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'dtpDateSignature
        '
        Me.dtpDateSignature.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpDateSignature.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateSignature.Location = New System.Drawing.Point(152, 160)
        Me.dtpDateSignature.Name = "dtpDateSignature"
        Me.dtpDateSignature.Size = New System.Drawing.Size(89, 20)
        Me.dtpDateSignature.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Date de signature :"
        '
        'ckConserverSignature
        '
        Me.ckConserverSignature.AutoSize = True
        Me.ckConserverSignature.Checked = True
        Me.ckConserverSignature.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckConserverSignature.Location = New System.Drawing.Point(271, 162)
        Me.ckConserverSignature.Name = "ckConserverSignature"
        Me.ckConserverSignature.Size = New System.Drawing.Size(131, 17)
        Me.ckConserverSignature.TabIndex = 7
        Me.ckConserverSignature.Text = "Conserver la signature"
        Me.ckConserverSignature.UseVisualStyleBackColor = True
        '
        'frmSignClientTelephone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 250)
        Me.Controls.Add(Me.ckConserverSignature)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDateSignature)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnValider)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pctSignature)
        Me.Name = "frmSignClientTelephone"
        Me.Text = "[T]Signature Client"
        CType(Me.pctSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pctSignature As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnValider As Button
    Friend WithEvents btnClear As Button

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Friend WithEvents dtpDateSignature As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents ckConserverSignature As CheckBox
End Class
