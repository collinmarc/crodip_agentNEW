﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.rbMD2 = New System.Windows.Forms.RadioButton()
        Me.rbITEQ = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.AcquisitionValueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbNiveaux = New System.Windows.Forms.TextBox()
        Me.rbAAMS = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowPanelAAMS = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbNbreBuseParNiveauAAMS = New System.Windows.Forms.TextBox()
        Me.rbERECA = New System.Windows.Forms.RadioButton()
        Me.rbIteq2 = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AcquisitionValueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowPanelAAMS.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbMD2
        '
        Me.rbMD2.AutoSize = True
        Me.rbMD2.Location = New System.Drawing.Point(12, 17)
        Me.rbMD2.Name = "rbMD2"
        Me.rbMD2.Size = New System.Drawing.Size(48, 17)
        Me.rbMD2.TabIndex = 0
        Me.rbMD2.TabStop = True
        Me.rbMD2.Text = "MD2"
        Me.rbMD2.UseVisualStyleBackColor = True
        '
        'rbITEQ
        '
        Me.rbITEQ.AutoSize = True
        Me.rbITEQ.Location = New System.Drawing.Point(66, 17)
        Me.rbITEQ.Name = "rbITEQ"
        Me.rbITEQ.Size = New System.Drawing.Size(50, 17)
        Me.rbITEQ.TabIndex = 1
        Me.rbITEQ.TabStop = True
        Me.rbITEQ.Text = "ITEQ"
        Me.rbITEQ.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(622, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "TEST"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NiveauDataGridViewTextBoxColumn, Me.NumBuseDataGridViewTextBoxColumn, Me.DebitDataGridViewTextBoxColumn, Me.PressionDataGridViewTextBoxColumn, Me.RefDataGridViewTextBoxColumn, Me.HVDataGridViewTextBoxColumn, Me.MarqueTypeFonctionementDataGridViewTextBoxColumn, Me.CalibreDataGridViewTextBoxColumn, Me.PressionCtrlDataGridViewTextBoxColumn, Me.DebitNominalDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.AcquisitionValueBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(3, 71)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(887, 255)
        Me.DataGridView1.TabIndex = 3
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
        'AcquisitionValueBindingSource
        '
        Me.AcquisitionValueBindingSource.DataSource = GetType(CRODIPAcquisition.AcquisitionValue)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nb de niveaux :"
        '
        'tbNiveaux
        '
        Me.tbNiveaux.Location = New System.Drawing.Point(93, 39)
        Me.tbNiveaux.Name = "tbNiveaux"
        Me.tbNiveaux.ReadOnly = True
        Me.tbNiveaux.Size = New System.Drawing.Size(272, 20)
        Me.tbNiveaux.TabIndex = 5
        '
        'rbAAMS
        '
        Me.rbAAMS.AutoSize = True
        Me.rbAAMS.Location = New System.Drawing.Point(122, 17)
        Me.rbAAMS.Name = "rbAAMS"
        Me.rbAAMS.Size = New System.Drawing.Size(55, 17)
        Me.rbAAMS.TabIndex = 6
        Me.rbAAMS.TabStop = True
        Me.rbAAMS.Text = "AAMS"
        Me.rbAAMS.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nbre de buses par niveau :"
        '
        'FlowPanelAAMS
        '
        Me.FlowPanelAAMS.Controls.Add(Me.Label2)
        Me.FlowPanelAAMS.Controls.Add(Me.tbNbreBuseParNiveauAAMS)
        Me.FlowPanelAAMS.Location = New System.Drawing.Point(376, 8)
        Me.FlowPanelAAMS.Name = "FlowPanelAAMS"
        Me.FlowPanelAAMS.Size = New System.Drawing.Size(211, 26)
        Me.FlowPanelAAMS.TabIndex = 9
        Me.FlowPanelAAMS.Visible = False
        '
        'tbNbreBuseParNiveauAAMS
        '
        Me.tbNbreBuseParNiveauAAMS.Location = New System.Drawing.Point(145, 0)
        Me.tbNbreBuseParNiveauAAMS.Margin = New System.Windows.Forms.Padding(0)
        Me.tbNbreBuseParNiveauAAMS.Name = "tbNbreBuseParNiveauAAMS"
        Me.tbNbreBuseParNiveauAAMS.Size = New System.Drawing.Size(39, 20)
        Me.tbNbreBuseParNiveauAAMS.TabIndex = 8
        '
        'rbERECA
        '
        Me.rbERECA.AutoSize = True
        Me.rbERECA.Location = New System.Drawing.Point(179, 17)
        Me.rbERECA.Name = "rbERECA"
        Me.rbERECA.Size = New System.Drawing.Size(61, 17)
        Me.rbERECA.TabIndex = 10
        Me.rbERECA.TabStop = True
        Me.rbERECA.Text = "ERECA"
        Me.rbERECA.UseVisualStyleBackColor = True
        '
        'rbIteq2
        '
        Me.rbIteq2.AutoSize = True
        Me.rbIteq2.Location = New System.Drawing.Point(246, 16)
        Me.rbIteq2.Name = "rbIteq2"
        Me.rbIteq2.Size = New System.Drawing.Size(56, 17)
        Me.rbIteq2.TabIndex = 11
        Me.rbIteq2.TabStop = True
        Me.rbIteq2.Text = "ITEQ2"
        Me.rbIteq2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 338)
        Me.Controls.Add(Me.rbIteq2)
        Me.Controls.Add(Me.rbERECA)
        Me.Controls.Add(Me.FlowPanelAAMS)
        Me.Controls.Add(Me.rbAAMS)
        Me.Controls.Add(Me.tbNiveaux)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rbITEQ)
        Me.Controls.Add(Me.rbMD2)
        Me.Name = "Form1"
        Me.Text = "Test Modules D'acquisition"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AcquisitionValueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowPanelAAMS.ResumeLayout(False)
        Me.FlowPanelAAMS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rbMD2 As RadioButton
    Friend WithEvents rbITEQ As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
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
    Friend WithEvents AcquisitionValueBindingSource As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents tbNiveaux As TextBox
    Friend WithEvents rbAAMS As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents FlowPanelAAMS As FlowLayoutPanel
    Friend WithEvents tbNbreBuseParNiveauAAMS As TextBox
    Friend WithEvents rbERECA As RadioButton
    Friend WithEvents rbIteq2 As RadioButton
End Class
