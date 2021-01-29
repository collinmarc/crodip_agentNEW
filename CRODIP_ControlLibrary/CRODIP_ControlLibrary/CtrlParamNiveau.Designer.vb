<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrlParamNiveau
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtrlParamNiveau))
        Me.pctBloc = New System.Windows.Forms.PictureBox()
        Me.lblBloc = New System.Windows.Forms.Label()
        Me.ckValidBloc = New System.Windows.Forms.CheckBox()
        Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.pctBloc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pctBloc
        '
        Me.pctBloc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pctBloc.Location = New System.Drawing.Point(4, 4)
        Me.pctBloc.Margin = New System.Windows.Forms.Padding(0)
        Me.pctBloc.Name = "pctBloc"
        Me.pctBloc.Size = New System.Drawing.Size(16, 16)
        Me.pctBloc.TabIndex = 0
        Me.pctBloc.TabStop = False
        '
        'lblBloc
        '
        Me.lblBloc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBloc.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.lblBloc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.lblBloc.Location = New System.Drawing.Point(20, 0)
        Me.lblBloc.Margin = New System.Windows.Forms.Padding(0)
        Me.lblBloc.Name = "lblBloc"
        Me.lblBloc.Size = New System.Drawing.Size(230, 25)
        Me.lblBloc.TabIndex = 1
        Me.lblBloc.Text = "Label1"
        '
        'ckValidBloc
        '
        Me.ckValidBloc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckValidBloc.AutoSize = True
        Me.ckValidBloc.Location = New System.Drawing.Point(253, 9)
        Me.ckValidBloc.Name = "ckValidBloc"
        Me.ckValidBloc.Size = New System.Drawing.Size(15, 14)
        Me.ckValidBloc.TabIndex = 2
        Me.ckValidBloc.UseVisualStyleBackColor = True
        '
        'm_ImageList
        '
        Me.m_ImageList.ImageStream = CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.m_ImageList.Images.SetKeyName(0, "puce_h1.jpg")
        Me.m_ImageList.Images.SetKeyName(1, "puce_h2.jpg")
        '
        'CtrlParamNiveau
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ckValidBloc)
        Me.Controls.Add(Me.pctBloc)
        Me.Controls.Add(Me.lblBloc)
        Me.Name = "CtrlParamNiveau"
        Me.Size = New System.Drawing.Size(271, 35)
        CType(Me.pctBloc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pctBloc As PictureBox
    Friend WithEvents lblBloc As Label
    Friend WithEvents ckValidBloc As CheckBox
    Friend WithEvents m_ImageList As ImageList
End Class
