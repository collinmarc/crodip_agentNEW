Imports CRODIPWS

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmlstLieuxControle
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
        Me.m_bsLieuxControle = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbLieuxControles = New System.Windows.Forms.ListBox()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        CType(Me.m_bsLieuxControle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_bsLieuxControle
        '
        Me.m_bsLieuxControle.AllowNew = False
        Me.m_bsLieuxControle.DataSource = GetType(LieuxControle)
        '
        'lbLieuxControles
        '
        Me.lbLieuxControles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbLieuxControles.DataSource = Me.m_bsLieuxControle
        Me.lbLieuxControles.DisplayMember = "Nom"
        Me.lbLieuxControles.FormattingEnabled = True
        Me.lbLieuxControles.Location = New System.Drawing.Point(2, 13)
        Me.lbLieuxControles.Name = "lbLieuxControles"
        Me.lbLieuxControles.Size = New System.Drawing.Size(270, 264)
        Me.lbLieuxControles.TabIndex = 0
        '
        'btnValider
        '
        Me.btnValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnValider.BackgroundImage = Global.Crodip_agent.Resources.btn_valider
        Me.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnValider.FlatAppearance.BorderSize = 0
        Me.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnValider.Location = New System.Drawing.Point(2, 283)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(132, 29)
        Me.btnValider.TabIndex = 1
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.BackgroundImage = Global.Crodip_agent.Resources.btn_annuler
        Me.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.FlatAppearance.BorderSize = 0
        Me.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnuler.Location = New System.Drawing.Point(140, 283)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(132, 29)
        Me.btnAnnuler.TabIndex = 2
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'frmlstLieuxControle
        '
        Me.AcceptButton = Me.btnValider
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New System.Drawing.Size(280, 318)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnValider)
        Me.Controls.Add(Me.lbLieuxControles)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frmlstLieuxControle"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liste des lieux de contrôle"
        CType(Me.m_bsLieuxControle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents m_bsLieuxControle As BindingSource
    Friend WithEvents lbLieuxControles As ListBox
    Friend WithEvents btnValider As Button
    Friend WithEvents btnAnnuler As Button
End Class
