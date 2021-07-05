<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaisieNumFact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaisieNumFact))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_facturation_suivant = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbNumFact = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbDernNumFact = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.Location = New System.Drawing.Point(12, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "    Annuler"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_facturation_suivant
        '
        Me.btn_facturation_suivant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_facturation_suivant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_facturation_suivant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_facturation_suivant.ForeColor = System.Drawing.Color.White
        Me.btn_facturation_suivant.Image = CType(resources.GetObject("btn_facturation_suivant.Image"), System.Drawing.Image)
        Me.btn_facturation_suivant.Location = New System.Drawing.Point(180, 89)
        Me.btn_facturation_suivant.Name = "btn_facturation_suivant"
        Me.btn_facturation_suivant.Size = New System.Drawing.Size(128, 24)
        Me.btn_facturation_suivant.TabIndex = 34
        Me.btn_facturation_suivant.Text = "    Valider"
        Me.btn_facturation_suivant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Numéro de facture :"
        '
        'tbNumFact
        '
        Me.tbNumFact.Location = New System.Drawing.Point(200, 19)
        Me.tbNumFact.Name = "tbNumFact"
        Me.tbNumFact.Size = New System.Drawing.Size(108, 20)
        Me.tbNumFact.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Dernier numéro de facture utilisé"
        '
        'tbDernNumFact
        '
        Me.tbDernNumFact.Enabled = False
        Me.tbDernNumFact.Location = New System.Drawing.Point(200, 45)
        Me.tbDernNumFact.Name = "tbDernNumFact"
        Me.tbDernNumFact.ReadOnly = True
        Me.tbDernNumFact.Size = New System.Drawing.Size(108, 20)
        Me.tbDernNumFact.TabIndex = 38
        '
        'frmSaisieNumFact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 122)
        Me.Controls.Add(Me.tbDernNumFact)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbNumFact)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_facturation_suivant)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmSaisieNumFact"
        Me.Text = "Saisie du numéro de facture"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_facturation_suivant As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbNumFact As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbDernNumFact As System.Windows.Forms.TextBox
End Class
