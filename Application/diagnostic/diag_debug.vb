Public Class diag_debug
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub
 
    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents btnDebug_close As System.Windows.Forms.Button
    Friend WithEvents btnDebug_checkAllGreen As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnDebug_checkAllGreen = New System.Windows.Forms.Button
        Me.btnDebug_close = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDebug_checkAllGreen
        '
        Me.btnDebug_checkAllGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDebug_checkAllGreen.Location = New System.Drawing.Point(24, 32)
        Me.btnDebug_checkAllGreen.Name = "btnDebug_checkAllGreen"
        Me.btnDebug_checkAllGreen.Size = New System.Drawing.Size(152, 23)
        Me.btnDebug_checkAllGreen.TabIndex = 0
        Me.btnDebug_checkAllGreen.Text = "Tout cocher en vert "
        '
        'btnDebug_close
        '
        Me.btnDebug_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDebug_close.Location = New System.Drawing.Point(1, 240)
        Me.btnDebug_close.Name = "btnDebug_close"
        Me.btnDebug_close.Size = New System.Drawing.Size(208, 24)
        Me.btnDebug_close.TabIndex = 1
        Me.btnDebug_close.Text = "Fermer ce panneau"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(24, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Passer en mode ""Rampe"""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDebug_checkAllGreen)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 112)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Checkboxes"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 104)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Type de contrôle"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(24, 64)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Passer en mode ""Arbo/viti"""
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(24, 64)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(152, 23)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Check Answers"
        '
        'diag_debug
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(210, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDebug_close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diag_debug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diagnostic .::. Panneau de debug"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnDebug_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDebug_close.Click
        Me.Close()
    End Sub


    Private Sub btnDebug_checkAllGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDebug_checkAllGreen.Click
        ToutCocherEnVert()
    End Sub
    Public Sub ToutCocherenVert()
        globFormDiagnostic.RadioButton_diagnostic_2110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2120.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2130.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2220.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2230.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2240.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2250.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2410.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2510.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2520.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2310.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_2320.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_3110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_3210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_3220.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_3230.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4120.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4310.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_6110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_7110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_7210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_7310.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_7410.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_9110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_9120.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_9210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_9220.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_10110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_10120.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_10210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_10220.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5220.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5310.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5320.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5410.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5420.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5510.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5520.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5610.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8120.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8130.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8220.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8230.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8310.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8320.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8330.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5620.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8160.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8150.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8170.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_5710.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4320.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4410.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4420.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4510.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4520.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4610.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4620.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4630.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_4640.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_8170.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_11110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_11120.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_11130.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_11140.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_12110.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_12120.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_12130.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_12210.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_12220.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_12310.Checked = True
        globFormDiagnostic.RadioButton_diagnostic_12320.Checked = True

    End Sub

    Public Function getAllRadio(ByVal contener As Object)
        For Each test As System.Windows.Forms.Control In contener.Controls
            Dim foo As Object = test.GetType.ToString
            If test.GetType.ToString <> "System.Windows.Forms.RadioButton" Then
                getAllRadio(test)
            Else
                Dim bar As Object = test.Name.ToString
            End If
        Next
    End Function

    Public Function getAllCheckbox(ByVal contener As Object)
        For Each test As System.Windows.Forms.Control In contener.Controls
            Dim foo As Object = test.GetType.ToString
            If test.GetType.ToString <> "System.Windows.Forms.CheckBox" Then
                getAllCheckbox(test)
            Else
                Dim bar As Object = test.Name.ToString
            End If
        Next
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        globFormDiagnostic.RadioButton_diagnostic_10213.ForeColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(135, Byte), CType(15, Byte))
        globFormDiagnostic.RadioButton_diagnostic_10222.ForeColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(135, Byte), CType(15, Byte))
        globFormDiagnostic.RadioButton_diagnostic_10223.ForeColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(135, Byte), CType(15, Byte))
        globFormDiagnostic.GroupBox_diagnostic_811.Enabled = True
        globFormDiagnostic.GroupBox_diagnostic_812.Enabled = True
        globFormDiagnostic.GroupBox_diagnostic_813.Enabled = True
        globFormDiagnostic.GroupBox_diagnostic_814.Enabled = False
        globFormDiagnostic.GroupBox_diagnostic_821.Enabled = True
        globFormDiagnostic.GroupBox_diagnostic_822.Enabled = True
        globFormDiagnostic.GroupBox_diagnostic_823.Enabled = True
        globFormDiagnostic.RadioButton_diagnostic_8312.Enabled = True
        globFormDiagnostic.RadioButton_diagnostic_8313.Enabled = True
        '        globFormDiagnostic.diagBuses_tab_pressionTroncons_rampe.Visible = True
        globFormDiagnostic.tab_833.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        globFormDiagnostic.RadioButton_diagnostic_10213.ForeColor = System.Drawing.Color.FromArgb(CType(242, Byte), CType(84, Byte), CType(23, Byte))
        globFormDiagnostic.RadioButton_diagnostic_10222.ForeColor = System.Drawing.Color.FromArgb(CType(242, Byte), CType(84, Byte), CType(23, Byte))
        globFormDiagnostic.RadioButton_diagnostic_10223.ForeColor = System.Drawing.Color.FromArgb(CType(242, Byte), CType(84, Byte), CType(23, Byte))
        globFormDiagnostic.GroupBox_diagnostic_811.Enabled = False
        globFormDiagnostic.GroupBox_diagnostic_812.Enabled = False
        globFormDiagnostic.GroupBox_diagnostic_813.Enabled = False
        globFormDiagnostic.GroupBox_diagnostic_814.Enabled = True
        globFormDiagnostic.GroupBox_diagnostic_821.Enabled = False
        globFormDiagnostic.GroupBox_diagnostic_822.Enabled = False
        globFormDiagnostic.GroupBox_diagnostic_823.Enabled = False
        globFormDiagnostic.RadioButton_diagnostic_8312.Enabled = False
        globFormDiagnostic.RadioButton_diagnostic_8313.Enabled = False
        '        globFormDiagnostic.diagBuses_tab_pressionTroncons_rampe.Visible = False
        globFormDiagnostic.tab_833.Visible = True
    End Sub


 End Class
