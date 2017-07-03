<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPRapport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RPRapport))
        Me.Label_diagnostic_21 = New System.Windows.Forms.Label()
        Me.lbSections = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbImg = New System.Windows.Forms.TextBox()
        Me.m_bsRPDiagnostic = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnChoisirImg = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbReferences = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbPath = New System.Windows.Forms.TextBox()
        Me.tbChoisirPath = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.m_dlgImage = New System.Windows.Forms.OpenFileDialog()
        Me.m_FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.m_bsRPDiagnostic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_diagnostic_21
        '
        Me.Label_diagnostic_21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_21.Image = CType(resources.GetObject("Label_diagnostic_21.Image"), System.Drawing.Image)
        Me.Label_diagnostic_21.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_21.Location = New System.Drawing.Point(12, 9)
        Me.Label_diagnostic_21.Name = "Label_diagnostic_21"
        Me.Label_diagnostic_21.Size = New System.Drawing.Size(323, 23)
        Me.Label_diagnostic_21.TabIndex = 16
        Me.Label_diagnostic_21.Text = "     Sélectionner les sections à imprimer :"
        '
        'lbSections
        '
        Me.lbSections.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbSections.FormattingEnabled = True
        Me.lbSections.Items.AddRange(New Object() {"Contrôle du capteur de vitesse /DPAE", "Contrôle du capteur de vitesse /Controle de volume hectare", "Contrôle du débitmètre /DPAE", "Contrôle du débitmètre / Contrôle du volume hectare", "Synhtèse de la mesure du débit des buses", "Contrôle des pressions", "Contrôle du manomètre", "Défauts", "Commentaires", "Feuille de calcul"})
        Me.lbSections.Location = New System.Drawing.Point(15, 35)
        Me.lbSections.Name = "lbSections"
        Me.lbSections.Size = New System.Drawing.Size(649, 154)
        Me.lbSections.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(12, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(323, 23)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "     Image à faire appraitre sur l'état :"
        '
        'tbImg
        '
        Me.tbImg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbImg.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "imagePath", True))
        Me.tbImg.Location = New System.Drawing.Point(15, 229)
        Me.tbImg.Name = "tbImg"
        Me.tbImg.Size = New System.Drawing.Size(549, 20)
        Me.tbImg.TabIndex = 19
        '
        'm_bsRPDiagnostic
        '
        Me.m_bsRPDiagnostic.DataSource = GetType(Crodip_agent.RPDiagnostic)
        '
        'btnChoisirImg
        '
        Me.btnChoisirImg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChoisirImg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnChoisirImg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.btnChoisirImg.Location = New System.Drawing.Point(575, 229)
        Me.btnChoisirImg.Name = "btnChoisirImg"
        Me.btnChoisirImg.Size = New System.Drawing.Size(93, 23)
        Me.btnChoisirImg.TabIndex = 20
        Me.btnChoisirImg.Text = "Choisir"
        Me.btnChoisirImg.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label2.Location = New System.Drawing.Point(12, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(323, 23)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "     Vos références :"
        '
        'tbReferences
        '
        Me.tbReferences.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbReferences.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "Reference", True))
        Me.tbReferences.Location = New System.Drawing.Point(15, 287)
        Me.tbReferences.Multiline = True
        Me.tbReferences.Name = "tbReferences"
        Me.tbReferences.Size = New System.Drawing.Size(349, 166)
        Me.tbReferences.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label3.Location = New System.Drawing.Point(12, 455)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(323, 23)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "     Rapport à sauvegarder dans :"
        '
        'tbPath
        '
        Me.tbPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPath.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "FilePath", True))
        Me.tbPath.Location = New System.Drawing.Point(12, 481)
        Me.tbPath.Name = "tbPath"
        Me.tbPath.Size = New System.Drawing.Size(549, 20)
        Me.tbPath.TabIndex = 24
        '
        'tbChoisirPath
        '
        Me.tbChoisirPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbChoisirPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.tbChoisirPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.tbChoisirPath.Location = New System.Drawing.Point(575, 479)
        Me.tbChoisirPath.Name = "tbChoisirPath"
        Me.tbChoisirPath.Size = New System.Drawing.Size(93, 23)
        Me.tbChoisirPath.TabIndex = 25
        Me.tbChoisirPath.Text = "Choisir"
        Me.tbChoisirPath.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(15, 540)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(546, 32)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Afficher le rapport"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.Location = New System.Drawing.Point(9, 508)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(255, 19)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "     Nom du fichier :"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsRPDiagnostic, "FileName", True))
        Me.TextBox1.Location = New System.Drawing.Point(158, 507)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(206, 20)
        Me.TextBox1.TabIndex = 28
        '
        'm_dlgImage
        '
        Me.m_dlgImage.Filter = "Fichiers Image|*.jpg;*.jpeg;*.png;*.bmp"
        '
        'RPRapport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 584)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbChoisirPath)
        Me.Controls.Add(Me.tbPath)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbReferences)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnChoisirImg)
        Me.Controls.Add(Me.tbImg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbSections)
        Me.Controls.Add(Me.Label_diagnostic_21)
        Me.Name = "RPRapport"
        Me.Text = "RPRapport"
        CType(Me.m_bsRPDiagnostic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_diagnostic_21 As System.Windows.Forms.Label
    Friend WithEvents lbSections As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbImg As System.Windows.Forms.TextBox
    Friend WithEvents btnChoisirImg As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbReferences As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbPath As System.Windows.Forms.TextBox
    Friend WithEvents tbChoisirPath As System.Windows.Forms.Button
    Friend WithEvents m_bsRPDiagnostic As System.Windows.Forms.BindingSource
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents m_dlgImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents m_dlgPathPDF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents m_FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
End Class
