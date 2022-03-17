<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMigrationBDD
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProgressBarN2 = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblProgressN2 = New System.Windows.Forms.Label()
        Me.ProgressBarN1 = New System.Windows.Forms.ProgressBar()
        Me.lblProgressN1 = New System.Windows.Forms.Label()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(189, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Migration des données"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBarN2
        '
        Me.ProgressBarN2.Location = New System.Drawing.Point(21, 75)
        Me.ProgressBarN2.Name = "ProgressBarN2"
        Me.ProgressBarN2.Size = New System.Drawing.Size(764, 23)
        Me.ProgressBarN2.TabIndex = 1
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'lblProgressN2
        '
        Me.lblProgressN2.AutoSize = True
        Me.lblProgressN2.Location = New System.Drawing.Point(377, 101)
        Me.lblProgressN2.Name = "lblProgressN2"
        Me.lblProgressN2.Size = New System.Drawing.Size(0, 13)
        Me.lblProgressN2.TabIndex = 2
        '
        'ProgressBarN1
        '
        Me.ProgressBarN1.Location = New System.Drawing.Point(21, 12)
        Me.ProgressBarN1.Name = "ProgressBarN1"
        Me.ProgressBarN1.Size = New System.Drawing.Size(764, 23)
        Me.ProgressBarN1.TabIndex = 3
        '
        'lblProgressN1
        '
        Me.lblProgressN1.AutoSize = True
        Me.lblProgressN1.Location = New System.Drawing.Point(377, 38)
        Me.lblProgressN1.Name = "lblProgressN1"
        Me.lblProgressN1.Size = New System.Drawing.Size(0, 13)
        Me.lblProgressN1.TabIndex = 4
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Location = New System.Drawing.Point(241, 160)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(175, 23)
        Me.btnAnnuler.TabIndex = 5
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        Me.btnAnnuler.Visible = False
        '
        'FrmMigrationBDD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 203)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.lblProgressN1)
        Me.Controls.Add(Me.ProgressBarN1)
        Me.Controls.Add(Me.lblProgressN2)
        Me.Controls.Add(Me.ProgressBarN2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmMigrationBDD"
        Me.Text = "Migration de la base de données"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ProgressBarN2 As ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblProgressN2 As Label
    Friend WithEvents ProgressBarN1 As ProgressBar
    Friend WithEvents lblProgressN1 As Label
    Friend WithEvents btnAnnuler As Button
End Class
