<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgAquisition
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NiveauDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumBuseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DebitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PressionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HVDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarqueTypeFonctionementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalibreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PressionCtrlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DebitNominalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(310, 249)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CRODIPAcquisition.AcquisitionValue)
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NiveauDataGridViewTextBoxColumn, Me.NumBuseDataGridViewTextBoxColumn, Me.DebitDataGridViewTextBoxColumn, Me.PressionDataGridViewTextBoxColumn, Me.RefDataGridViewTextBoxColumn, Me.HVDataGridViewTextBoxColumn, Me.MarqueTypeFonctionementDataGridViewTextBoxColumn, Me.CalibreDataGridViewTextBoxColumn, Me.PressionCtrlDataGridViewTextBoxColumn, Me.DebitNominalDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Location = New System.Drawing.Point(13, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(444, 213)
        Me.DataGridView1.TabIndex = 1
        '
        'NiveauDataGridViewTextBoxColumn
        '
        Me.NiveauDataGridViewTextBoxColumn.DataPropertyName = "Niveau"
        Me.NiveauDataGridViewTextBoxColumn.HeaderText = "Niveau"
        Me.NiveauDataGridViewTextBoxColumn.Name = "NiveauDataGridViewTextBoxColumn"
        '
        'NumBuseDataGridViewTextBoxColumn
        '
        Me.NumBuseDataGridViewTextBoxColumn.DataPropertyName = "NumBuse"
        Me.NumBuseDataGridViewTextBoxColumn.HeaderText = "NumBuse"
        Me.NumBuseDataGridViewTextBoxColumn.Name = "NumBuseDataGridViewTextBoxColumn"
        '
        'DebitDataGridViewTextBoxColumn
        '
        Me.DebitDataGridViewTextBoxColumn.DataPropertyName = "Debit"
        Me.DebitDataGridViewTextBoxColumn.HeaderText = "Debit"
        Me.DebitDataGridViewTextBoxColumn.Name = "DebitDataGridViewTextBoxColumn"
        '
        'PressionDataGridViewTextBoxColumn
        '
        Me.PressionDataGridViewTextBoxColumn.DataPropertyName = "Pression"
        Me.PressionDataGridViewTextBoxColumn.HeaderText = "Pression"
        Me.PressionDataGridViewTextBoxColumn.Name = "PressionDataGridViewTextBoxColumn"
        '
        'RefDataGridViewTextBoxColumn
        '
        Me.RefDataGridViewTextBoxColumn.DataPropertyName = "Ref"
        Me.RefDataGridViewTextBoxColumn.HeaderText = "Ref"
        Me.RefDataGridViewTextBoxColumn.Name = "RefDataGridViewTextBoxColumn"
        '
        'HVDataGridViewTextBoxColumn
        '
        Me.HVDataGridViewTextBoxColumn.DataPropertyName = "HV"
        Me.HVDataGridViewTextBoxColumn.HeaderText = "HV"
        Me.HVDataGridViewTextBoxColumn.Name = "HVDataGridViewTextBoxColumn"
        '
        'MarqueTypeFonctionementDataGridViewTextBoxColumn
        '
        Me.MarqueTypeFonctionementDataGridViewTextBoxColumn.DataPropertyName = "MarqueTypeFonctionement"
        Me.MarqueTypeFonctionementDataGridViewTextBoxColumn.HeaderText = "MarqueTypeFonctionement"
        Me.MarqueTypeFonctionementDataGridViewTextBoxColumn.Name = "MarqueTypeFonctionementDataGridViewTextBoxColumn"
        '
        'CalibreDataGridViewTextBoxColumn
        '
        Me.CalibreDataGridViewTextBoxColumn.DataPropertyName = "Calibre"
        Me.CalibreDataGridViewTextBoxColumn.HeaderText = "Calibre"
        Me.CalibreDataGridViewTextBoxColumn.Name = "CalibreDataGridViewTextBoxColumn"
        '
        'PressionCtrlDataGridViewTextBoxColumn
        '
        Me.PressionCtrlDataGridViewTextBoxColumn.DataPropertyName = "PressionCtrl"
        Me.PressionCtrlDataGridViewTextBoxColumn.HeaderText = "PressionCtrl"
        Me.PressionCtrlDataGridViewTextBoxColumn.Name = "PressionCtrlDataGridViewTextBoxColumn"
        '
        'DebitNominalDataGridViewTextBoxColumn
        '
        Me.DebitNominalDataGridViewTextBoxColumn.DataPropertyName = "DebitNominal"
        Me.DebitNominalDataGridViewTextBoxColumn.HeaderText = "DebitNominal"
        Me.DebitNominalDataGridViewTextBoxColumn.Name = "DebitNominalDataGridViewTextBoxColumn"
        '
        'dlgAquisition
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(468, 290)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAquisition"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Simulation de l'acquisition"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents NiveauDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NumBuseDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DebitDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PressionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RefDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HVDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MarqueTypeFonctionementDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CalibreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PressionCtrlDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DebitNominalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
