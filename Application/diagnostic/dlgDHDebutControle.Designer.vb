<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDHDebutControle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgDHDebutControle))
        Me.dtpHeuredebutcontrole = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_retour = New System.Windows.Forms.Label()
        Me.btn_poursuivre = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.laDateFinDernControle = New System.Windows.Forms.Label()
        Me.pctbx_Docs_refresh = New System.Windows.Forms.PictureBox()
        CType(Me.pctbx_Docs_refresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpHeuredebutcontrole
        '
        Me.dtpHeuredebutcontrole.CustomFormat = "HH':'mm"
        Me.dtpHeuredebutcontrole.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHeuredebutcontrole.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHeuredebutcontrole.Location = New System.Drawing.Point(312, 48)
        Me.dtpHeuredebutcontrole.Name = "dtpHeuredebutcontrole"
        Me.dtpHeuredebutcontrole.ShowUpDown = True
        Me.dtpHeuredebutcontrole.Size = New System.Drawing.Size(119, 47)
        Me.dtpHeuredebutcontrole.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(30, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(276, 66)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Heure de début de contrôle : "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btn_retour
        '
        Me.btn_retour.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_retour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_retour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_retour.ForeColor = System.Drawing.Color.White
        Me.btn_retour.Image = CType(resources.GetObject("btn_retour.Image"), System.Drawing.Image)
        Me.btn_retour.Location = New System.Drawing.Point(12, 112)
        Me.btn_retour.Name = "btn_retour"
        Me.btn_retour.Size = New System.Drawing.Size(128, 24)
        Me.btn_retour.TabIndex = 15
        Me.btn_retour.Text = "    Retour"
        Me.btn_retour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_poursuivre
        '
        Me.btn_poursuivre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_poursuivre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_poursuivre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_poursuivre.ForeColor = System.Drawing.Color.White
        Me.btn_poursuivre.Image = CType(resources.GetObject("btn_poursuivre.Image"), System.Drawing.Image)
        Me.btn_poursuivre.Location = New System.Drawing.Point(351, 112)
        Me.btn_poursuivre.Name = "btn_poursuivre"
        Me.btn_poursuivre.Size = New System.Drawing.Size(140, 24)
        Me.btn_poursuivre.TabIndex = 16
        Me.btn_poursuivre.Text = "    Valider"
        Me.btn_poursuivre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(30, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 19)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Date de fin du dernier contrôle : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'laDateFinDernControle
        '
        Me.laDateFinDernControle.AutoSize = True
        Me.laDateFinDernControle.Location = New System.Drawing.Point(266, 5)
        Me.laDateFinDernControle.Name = "laDateFinDernControle"
        Me.laDateFinDernControle.Size = New System.Drawing.Size(114, 13)
        Me.laDateFinDernControle.TabIndex = 18
        Me.laDateFinDernControle.Text = "laDateFinDernControle"
        '
        'pctbx_Docs_refresh
        '
        Me.pctbx_Docs_refresh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctbx_Docs_refresh.Image = CType(resources.GetObject("pctbx_Docs_refresh.Image"), System.Drawing.Image)
        Me.pctbx_Docs_refresh.Location = New System.Drawing.Point(437, 48)
        Me.pctbx_Docs_refresh.Name = "pctbx_Docs_refresh"
        Me.pctbx_Docs_refresh.Size = New System.Drawing.Size(54, 47)
        Me.pctbx_Docs_refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctbx_Docs_refresh.TabIndex = 36
        Me.pctbx_Docs_refresh.TabStop = False
        '
        'dlgDHDebutControle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 145)
        Me.Controls.Add(Me.pctbx_Docs_refresh)
        Me.Controls.Add(Me.laDateFinDernControle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_poursuivre)
        Me.Controls.Add(Me.btn_retour)
        Me.Controls.Add(Me.dtpHeuredebutcontrole)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgDHDebutControle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Création d'un contrôle"
        CType(Me.pctbx_Docs_refresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpHeuredebutcontrole As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_retour As Label
    Friend WithEvents btn_poursuivre As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents laDateFinDernControle As Label
    Friend WithEvents pctbx_Docs_refresh As PictureBox
End Class
