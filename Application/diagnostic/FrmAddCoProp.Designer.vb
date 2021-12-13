<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddCoProp
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
        Me.components = New System.ComponentModel.Container()
        Me.pnlListCoProp = New System.Windows.Forms.Panel()
        Me.btnImprimer = New System.Windows.Forms.Button()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.btnAjoutExploitant = New System.Windows.Forms.Button()
        Me.btnSupprCoProp = New System.Windows.Forms.Button()
        Me.btnNewExploitant = New System.Windows.Forms.Button()
        Me.m_dgvCoProp = New System.Windows.Forms.DataGridView()
        Me.RaisonSocialeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomExploitantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrenomExploitantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommuneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_bsrcExploitant = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlListCoProp.SuspendLayout()
        CType(Me.m_dgvCoProp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcExploitant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListCoProp
        '
        Me.pnlListCoProp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlListCoProp.Controls.Add(Me.btnImprimer)
        Me.pnlListCoProp.Controls.Add(Me.btnValider)
        Me.pnlListCoProp.Controls.Add(Me.btnAjoutExploitant)
        Me.pnlListCoProp.Controls.Add(Me.btnSupprCoProp)
        Me.pnlListCoProp.Controls.Add(Me.btnNewExploitant)
        Me.pnlListCoProp.Controls.Add(Me.m_dgvCoProp)
        Me.pnlListCoProp.Location = New System.Drawing.Point(2, 2)
        Me.pnlListCoProp.Name = "pnlListCoProp"
        Me.pnlListCoProp.Size = New System.Drawing.Size(622, 373)
        Me.pnlListCoProp.TabIndex = 67
        '
        'btnImprimer
        '
        Me.btnImprimer.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnImprimer.BackgroundImage = Global.Crodip_agent.Resources.btn_divers_print
        Me.btnImprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimer.ForeColor = System.Drawing.Color.White
        Me.btnImprimer.Location = New System.Drawing.Point(231, 334)
        Me.btnImprimer.Name = "btnImprimer"
        Me.btnImprimer.Size = New System.Drawing.Size(189, 30)
        Me.btnImprimer.TabIndex = 72
        Me.btnImprimer.Text = "Imprimer"
        Me.btnImprimer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimer.UseVisualStyleBackColor = False
        '
        'btnValider
        '
        Me.btnValider.BackgroundImage = Global.Crodip_agent.Resources.btn_valider
        Me.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnValider.ForeColor = System.Drawing.Color.White
        Me.btnValider.Location = New System.Drawing.Point(484, 334)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(135, 30)
        Me.btnValider.TabIndex = 70
        Me.btnValider.Text = "Valider"
        Me.btnValider.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'btnAjoutExploitant
        '
        Me.btnAjoutExploitant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAjoutExploitant.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnAjoutExploitant.ForeColor = System.Drawing.Color.White
        Me.btnAjoutExploitant.Location = New System.Drawing.Point(101, 286)
        Me.btnAjoutExploitant.Name = "btnAjoutExploitant"
        Me.btnAjoutExploitant.Size = New System.Drawing.Size(105, 29)
        Me.btnAjoutExploitant.TabIndex = 65
        Me.btnAjoutExploitant.Text = "Ajouter existant"
        Me.btnAjoutExploitant.UseVisualStyleBackColor = False
        '
        'btnSupprCoProp
        '
        Me.btnSupprCoProp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSupprCoProp.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnSupprCoProp.ForeColor = System.Drawing.Color.White
        Me.btnSupprCoProp.Location = New System.Drawing.Point(212, 286)
        Me.btnSupprCoProp.Name = "btnSupprCoProp"
        Me.btnSupprCoProp.Size = New System.Drawing.Size(116, 29)
        Me.btnSupprCoProp.TabIndex = 64
        Me.btnSupprCoProp.Text = "Supprimer"
        Me.btnSupprCoProp.UseVisualStyleBackColor = False
        '
        'btnNewExploitant
        '
        Me.btnNewExploitant.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnNewExploitant.ForeColor = System.Drawing.Color.White
        Me.btnNewExploitant.Location = New System.Drawing.Point(8, 287)
        Me.btnNewExploitant.Name = "btnNewExploitant"
        Me.btnNewExploitant.Size = New System.Drawing.Size(87, 29)
        Me.btnNewExploitant.TabIndex = 51
        Me.btnNewExploitant.Text = "Nouveau"
        Me.btnNewExploitant.UseVisualStyleBackColor = False
        '
        'm_dgvCoProp
        '
        Me.m_dgvCoProp.AllowUserToAddRows = False
        Me.m_dgvCoProp.AllowUserToDeleteRows = False
        Me.m_dgvCoProp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_dgvCoProp.AutoGenerateColumns = False
        Me.m_dgvCoProp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.m_dgvCoProp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.m_dgvCoProp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RaisonSocialeDataGridViewTextBoxColumn, Me.NomExploitantDataGridViewTextBoxColumn, Me.PrenomExploitantDataGridViewTextBoxColumn, Me.CodePostalDataGridViewTextBoxColumn, Me.CommuneDataGridViewTextBoxColumn})
        Me.m_dgvCoProp.DataSource = Me.m_bsrcExploitant
        Me.m_dgvCoProp.Location = New System.Drawing.Point(8, 0)
        Me.m_dgvCoProp.MultiSelect = False
        Me.m_dgvCoProp.Name = "m_dgvCoProp"
        Me.m_dgvCoProp.ReadOnly = True
        Me.m_dgvCoProp.RowHeadersVisible = False
        Me.m_dgvCoProp.Size = New System.Drawing.Size(612, 281)
        Me.m_dgvCoProp.TabIndex = 42
        '
        'RaisonSocialeDataGridViewTextBoxColumn
        '
        Me.RaisonSocialeDataGridViewTextBoxColumn.DataPropertyName = "raisonSociale"
        Me.RaisonSocialeDataGridViewTextBoxColumn.HeaderText = "Raison sociale"
        Me.RaisonSocialeDataGridViewTextBoxColumn.Name = "RaisonSocialeDataGridViewTextBoxColumn"
        Me.RaisonSocialeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NomExploitantDataGridViewTextBoxColumn
        '
        Me.NomExploitantDataGridViewTextBoxColumn.DataPropertyName = "nomExploitant"
        Me.NomExploitantDataGridViewTextBoxColumn.HeaderText = "Nom "
        Me.NomExploitantDataGridViewTextBoxColumn.Name = "NomExploitantDataGridViewTextBoxColumn"
        Me.NomExploitantDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PrenomExploitantDataGridViewTextBoxColumn
        '
        Me.PrenomExploitantDataGridViewTextBoxColumn.DataPropertyName = "prenomExploitant"
        Me.PrenomExploitantDataGridViewTextBoxColumn.HeaderText = "Prénom"
        Me.PrenomExploitantDataGridViewTextBoxColumn.Name = "PrenomExploitantDataGridViewTextBoxColumn"
        Me.PrenomExploitantDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CodePostalDataGridViewTextBoxColumn
        '
        Me.CodePostalDataGridViewTextBoxColumn.DataPropertyName = "codePostal"
        Me.CodePostalDataGridViewTextBoxColumn.HeaderText = "Code postal"
        Me.CodePostalDataGridViewTextBoxColumn.Name = "CodePostalDataGridViewTextBoxColumn"
        Me.CodePostalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CommuneDataGridViewTextBoxColumn
        '
        Me.CommuneDataGridViewTextBoxColumn.DataPropertyName = "commune"
        Me.CommuneDataGridViewTextBoxColumn.HeaderText = "Commune"
        Me.CommuneDataGridViewTextBoxColumn.Name = "CommuneDataGridViewTextBoxColumn"
        Me.CommuneDataGridViewTextBoxColumn.ReadOnly = True
        '
        'm_bsrcExploitant
        '
        Me.m_bsrcExploitant.DataSource = GetType(Crodip_agent.Exploitation)
        '
        'FrmAddCoProp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 378)
        Me.Controls.Add(Me.pnlListCoProp)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddCoProp"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edition du document de CoPropriété"
        Me.pnlListCoProp.ResumeLayout(False)
        CType(Me.m_dgvCoProp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcExploitant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlListCoProp As Panel
    Friend WithEvents btnAjoutExploitant As Button
    Friend WithEvents btnSupprCoProp As Button
    Friend WithEvents btnNewExploitant As Button
    Friend WithEvents m_dgvCoProp As DataGridView
    Friend WithEvents RaisonSocialeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NomExploitantDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrenomExploitantDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CommuneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents m_bsrcExploitant As BindingSource
    Friend WithEvents btnValider As Button
    Friend WithEvents btnImprimer As Button
End Class
