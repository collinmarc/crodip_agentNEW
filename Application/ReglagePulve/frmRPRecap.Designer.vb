<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRPRecap
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRPRecap))
        Me.Label_diagnostic_21 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.m_bsDiagnostic = New System.Windows.Forms.BindingSource(Me.components)
        Me.TreeView3state1 = New TreeView
        CType(Me.m_bsDiagnostic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_diagnostic_21
        '
        Me.Label_diagnostic_21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_21.Image = CType(resources.GetObject("Label_diagnostic_21.Image"), System.Drawing.Image)
        Me.Label_diagnostic_21.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_21.Location = New System.Drawing.Point(9, 9)
        Me.Label_diagnostic_21.Name = "Label_diagnostic_21"
        Me.Label_diagnostic_21.Size = New System.Drawing.Size(224, 30)
        Me.Label_diagnostic_21.TabIndex = 15
        Me.Label_diagnostic_21.Text = "     Défauts à corriger :"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(12, 316)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "     Commentaires :"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsDiagnostic, "Commentaires", True))
        Me.RichTextBox1.Location = New System.Drawing.Point(14, 344)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(680, 179)
        Me.RichTextBox1.TabIndex = 17
        Me.RichTextBox1.Text = ""
        '
        'm_bsDiagnostic
        '
        Me.m_bsDiagnostic.DataSource = GetType(Crodip_agent.RPDiagnostic)
        '
        'TreeView3state1
        '
        Me.TreeView3state1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView3state1.CheckBoxes = True
        Me.TreeView3state1.Location = New System.Drawing.Point(15, 29)
        Me.TreeView3state1.Name = "TreeView3state1"
        Me.TreeView3state1.Size = New System.Drawing.Size(670, 271)
        Me.TreeView3state1.TabIndex = 19
        '
        'frmRPRecap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(707, 535)
        Me.ControlBox = False
        Me.Controls.Add(Me.TreeView3state1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label_diagnostic_21)
        Me.MinimizeBox = False
        Me.Name = "frmRPRecap"
        Me.Text = "Défauts / Commentaires"
        CType(Me.m_bsDiagnostic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_diagnostic_21 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents m_bsDiagnostic As System.Windows.Forms.BindingSource
    Friend WithEvents TreeView3state1 As TreeView
End Class
