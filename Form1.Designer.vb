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
        Me.CtrlDiag21 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.SuspendLayout()
        '
        'CtrlDiag21
        '
        Me.CtrlDiag21.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.CtrlDiag21.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.CtrlDiag21.cause1 = False
        Me.CtrlDiag21.cause2 = False
        Me.CtrlDiag21.cause3 = True
        Me.CtrlDiag21.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CtrlDiag21.Checked = False
        Me.CtrlDiag21.Code = Nothing
        Me.CtrlDiag21.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.CtrlDiag21.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CtrlDiag21.Libelle = Nothing
        Me.CtrlDiag21.LibelleLong = Nothing
        Me.CtrlDiag21.Location = New System.Drawing.Point(62, 67)
        Me.CtrlDiag21.Margin = New System.Windows.Forms.Padding(0)
        Me.CtrlDiag21.Name = "CtrlDiag21"
        Me.CtrlDiag21.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.CtrlDiag21.Size = New System.Drawing.Size(166, 19)
        Me.CtrlDiag21.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 338)
        Me.Controls.Add(Me.CtrlDiag21)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrlDiag21 As CRODIP_ControlLibrary.CtrlDiag2
End Class
