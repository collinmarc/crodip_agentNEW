<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSignClientTablette
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
    Private Sub InitializeComponent()
        Me.pctSignature = New System.Windows.Forms.PictureBox()
        Me.btnQuitter = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.dtpDateSignature = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pctSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pctSignature
        '
        Me.pctSignature.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctSignature.BackColor = System.Drawing.Color.White
        Me.pctSignature.Location = New System.Drawing.Point(-1, -2)
        Me.pctSignature.Name = "pctSignature"
        Me.pctSignature.Size = New System.Drawing.Size(626, 214)
        Me.pctSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctSignature.TabIndex = 0
        Me.pctSignature.TabStop = False
        '
        'btnQuitter
        '
        Me.btnQuitter.Location = New System.Drawing.Point(11, 100)
        Me.btnQuitter.Name = "btnQuitter"
        Me.btnQuitter.Size = New System.Drawing.Size(112, 48)
        Me.btnQuitter.TabIndex = 1
        Me.btnQuitter.Text = "Quitter"
        Me.btnQuitter.UseVisualStyleBackColor = True
        '
        'btnValider
        '
        Me.btnValider.Location = New System.Drawing.Point(11, 54)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(112, 46)
        Me.btnValider.TabIndex = 2
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(11, 6)
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
        Me.dtpDateSignature.Location = New System.Drawing.Point(150, 218)
        Me.dtpDateSignature.Name = "dtpDateSignature"
        Me.dtpDateSignature.Size = New System.Drawing.Size(89, 20)
        Me.dtpDateSignature.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Date : "
        '
        'frmSignClientTablette
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 250)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDateSignature)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnValider)
        Me.Controls.Add(Me.btnQuitter)
        Me.Controls.Add(Me.pctSignature)
        Me.Name = "frmSignClientTablette"
        Me.Text = "[TG] Signature Client"
        CType(Me.pctSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pctSignature As PictureBox
    Friend WithEvents btnQuitter As Button
    Friend WithEvents btnValider As Button
    Friend WithEvents btnClear As Button

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Friend WithEvents dtpDateSignature As DateTimePicker
    Friend WithEvents Label1 As Label
End Class
