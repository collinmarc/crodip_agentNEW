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
        Me.CtrlParamNiveau4 = New CRODIP_ControlLibrary.CtrlParamNiveau()
        Me.CtrlParamNiveau3 = New CRODIP_ControlLibrary.CtrlParamNiveau()
        Me.CtrlParamNiveau2 = New CRODIP_ControlLibrary.CtrlParamNiveau()
        Me.CtrlParamNiveau1 = New CRODIP_ControlLibrary.CtrlParamNiveau()
        Me.SuspendLayout()
        '
        'CtrlParamNiveau4
        '
        Me.CtrlParamNiveau4.bValidBloc = True
        Me.CtrlParamNiveau4.Checked = False
        Me.CtrlParamNiveau4.Label = "Niveau2 avec Valid"
        Me.CtrlParamNiveau4.Location = New System.Drawing.Point(13, 150)
        Me.CtrlParamNiveau4.Name = "CtrlParamNiveau4"
        Me.CtrlParamNiveau4.Niveau = 2
        Me.CtrlParamNiveau4.Size = New System.Drawing.Size(235, 25)
        Me.CtrlParamNiveau4.TabIndex = 3
        '
        'CtrlParamNiveau3
        '
        Me.CtrlParamNiveau3.bValidBloc = False
        Me.CtrlParamNiveau3.Checked = False
        Me.CtrlParamNiveau3.Label = "Niveau2 Sans Valid"
        Me.CtrlParamNiveau3.Location = New System.Drawing.Point(13, 108)
        Me.CtrlParamNiveau3.Name = "CtrlParamNiveau3"
        Me.CtrlParamNiveau3.Niveau = 2
        Me.CtrlParamNiveau3.Size = New System.Drawing.Size(235, 26)
        Me.CtrlParamNiveau3.TabIndex = 2
        '
        'CtrlParamNiveau2
        '
        Me.CtrlParamNiveau2.bValidBloc = False
        Me.CtrlParamNiveau2.Checked = False
        Me.CtrlParamNiveau2.Label = "Niveau1 avec Valid"
        Me.CtrlParamNiveau2.Location = New System.Drawing.Point(13, 55)
        Me.CtrlParamNiveau2.Name = "CtrlParamNiveau2"
        Me.CtrlParamNiveau2.Niveau = 1
        Me.CtrlParamNiveau2.Size = New System.Drawing.Size(235, 28)
        Me.CtrlParamNiveau2.TabIndex = 1
        '
        'CtrlParamNiveau1
        '
        Me.CtrlParamNiveau1.bValidBloc = False
        Me.CtrlParamNiveau1.Checked = False
        Me.CtrlParamNiveau1.Label = "Niveau 1 Sans Valid"
        Me.CtrlParamNiveau1.Location = New System.Drawing.Point(13, 13)
        Me.CtrlParamNiveau1.Name = "CtrlParamNiveau1"
        Me.CtrlParamNiveau1.Niveau = 1
        Me.CtrlParamNiveau1.Size = New System.Drawing.Size(235, 35)
        Me.CtrlParamNiveau1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CtrlParamNiveau4)
        Me.Controls.Add(Me.CtrlParamNiveau3)
        Me.Controls.Add(Me.CtrlParamNiveau2)
        Me.Controls.Add(Me.CtrlParamNiveau1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CtrlParamNiveau1 As CRODIP_ControlLibrary.CtrlParamNiveau
    Friend WithEvents CtrlParamNiveau2 As CRODIP_ControlLibrary.CtrlParamNiveau
    Friend WithEvents CtrlParamNiveau3 As CRODIP_ControlLibrary.CtrlParamNiveau
    Friend WithEvents CtrlParamNiveau4 As CRODIP_ControlLibrary.CtrlParamNiveau
End Class
