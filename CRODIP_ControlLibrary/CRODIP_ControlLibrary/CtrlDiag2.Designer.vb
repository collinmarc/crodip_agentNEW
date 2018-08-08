<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrlDiag2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtrlDiag2))
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CtrlDiag2_RB1 = New CRODIP_ControlLibrary.CtrlDiag2_RB()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(0, 0)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(166, 19)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(135, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 13)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Flch.png")
        Me.ImageList1.Images.SetKeyName(1, "1.jpg")
        Me.ImageList1.Images.SetKeyName(2, "2.jpg")
        Me.ImageList1.Images.SetKeyName(3, "3.jpg")
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "Cause du défaut"
        '
        'CtrlDiag2_RB1
        '
        Me.CtrlDiag2_RB1.bCause1 = False
        Me.CtrlDiag2_RB1.bCause2 = False
        Me.CtrlDiag2_RB1.bCause3 = False
        Me.CtrlDiag2_RB1.NombreCauses = "0"
        Me.CtrlDiag2_RB1.Dock = System.Windows.Forms.DockStyle.Right
        Me.CtrlDiag2_RB1.Location = New System.Drawing.Point(51, 0)
        Me.CtrlDiag2_RB1.Margin = New System.Windows.Forms.Padding(0)
        Me.CtrlDiag2_RB1.Name = "CtrlDiag2_RB1"
        Me.CtrlDiag2_RB1.Size = New System.Drawing.Size(115, 19)
        Me.CtrlDiag2_RB1.TabIndex = 3
        Me.CtrlDiag2_RB1.value = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.ZERO
        Me.CtrlDiag2_RB1.Visible = False
        '
        'CtrlDiag2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CtrlDiag2_RB1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "CtrlDiag2"
        Me.Size = New System.Drawing.Size(166, 19)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CtrlDiag2_RB1 As CRODIP_ControlLibrary.CtrlDiag2_RB
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
