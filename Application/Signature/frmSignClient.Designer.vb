<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSignClient
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
        Me.pctSignature = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        CType(Me.pctSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pctSignature
        '
        Me.pctSignature.Location = New System.Drawing.Point(11, 6)
        Me.pctSignature.Name = "pctSignature"
        Me.pctSignature.Size = New System.Drawing.Size(450, 214)
        Me.pctSignature.TabIndex = 0
        Me.pctSignature.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 48)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Quitter"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnValider
        '
        Me.btnValider.Location = New System.Drawing.Point(338, 242)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(122, 46)
        Me.btnValider.TabIndex = 2
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(150, 242)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(169, 48)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Effacer"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'frmSignClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 295)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnValider)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pctSignature)
        Me.Name = "frmSignClient"
        Me.Text = "Signature Client"
        CType(Me.pctSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
End Class
