Imports CRODIPWS

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGestLieuxControle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGestLieuxControle))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxSite2 = New System.Windows.Forms.ComboBox()
        Me.m_bsLieuxControle = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxCommunes2 = New System.Windows.Forms.ComboBox()
        Me.m_bsCommune = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbcodePostal = New System.Windows.Forms.TextBox()
        Me.tbnomSite = New System.Windows.Forms.TextBox()
        Me.ckisRecuperationResidus = New System.Windows.Forms.CheckBox()
        Me.ckisSiteSecurise = New System.Windows.Forms.CheckBox()
        Me.lbLieux = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btn_Ajouter = New System.Windows.Forms.Button()
        Me.btnSuppimer = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.m_bsLieuxControle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsCommune, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.cbxSite2)
        Me.GroupBox1.Controls.Add(Me.cbxCommunes2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbcodePostal)
        Me.GroupBox1.Controls.Add(Me.tbnomSite)
        Me.GroupBox1.Controls.Add(Me.ckisRecuperationResidus)
        Me.GroupBox1.Controls.Add(Me.ckisSiteSecurise)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(360, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 198)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lieu de contrôle"
        '
        'cbxSite2
        '
        Me.cbxSite2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsLieuxControle, "Site", True))
        Me.cbxSite2.FormattingEnabled = True
        Me.cbxSite2.Location = New System.Drawing.Point(131, 67)
        Me.cbxSite2.Name = "cbxSite2"
        Me.cbxSite2.Size = New System.Drawing.Size(160, 21)
        Me.cbxSite2.TabIndex = 9
        '
        'm_bsLieuxControle
        '
        Me.m_bsLieuxControle.DataSource = GetType(LieuxControle)
        '
        'cbxCommunes2
        '
        Me.cbxCommunes2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxCommunes2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCommunes2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsLieuxControle, "Commune", True))
        Me.cbxCommunes2.DataSource = Me.m_bsCommune
        Me.cbxCommunes2.DisplayMember = "Nom"
        Me.cbxCommunes2.FormattingEnabled = True
        Me.cbxCommunes2.Location = New System.Drawing.Point(131, 38)
        Me.cbxCommunes2.Name = "cbxCommunes2"
        Me.cbxCommunes2.Size = New System.Drawing.Size(160, 21)
        Me.cbxCommunes2.TabIndex = 8
        '
        'm_bsCommune
        '
        Me.m_bsCommune.DataSource = GetType(Commune)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Commune : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Code postal : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Site : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nom du site : "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'tbcodePostal
        '
        Me.tbcodePostal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsLieuxControle, "CodePostal", True))
        Me.tbcodePostal.Location = New System.Drawing.Point(131, 14)
        Me.tbcodePostal.Name = "tbcodePostal"
        Me.tbcodePostal.Size = New System.Drawing.Size(56, 20)
        Me.tbcodePostal.TabIndex = 0
        '
        'tbnomSite
        '
        Me.tbnomSite.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsLieuxControle, "Nom", True))
        Me.tbnomSite.Location = New System.Drawing.Point(131, 94)
        Me.tbnomSite.Name = "tbnomSite"
        Me.tbnomSite.Size = New System.Drawing.Size(160, 20)
        Me.tbnomSite.TabIndex = 3
        '
        'ckisRecuperationResidus
        '
        Me.ckisRecuperationResidus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckisRecuperationResidus.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsLieuxControle, "Recupdechets", True))
        Me.ckisRecuperationResidus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ckisRecuperationResidus.Location = New System.Drawing.Point(12, 142)
        Me.ckisRecuperationResidus.Name = "ckisRecuperationResidus"
        Me.ckisRecuperationResidus.Size = New System.Drawing.Size(136, 37)
        Me.ckisRecuperationResidus.TabIndex = 7
        Me.ckisRecuperationResidus.Text = "Récupération des résidus :"
        Me.ckisRecuperationResidus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ckisSiteSecurise
        '
        Me.ckisSiteSecurise.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckisSiteSecurise.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.m_bsLieuxControle, "SiteSecurise", True))
        Me.ckisSiteSecurise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ckisSiteSecurise.Location = New System.Drawing.Point(12, 120)
        Me.ckisSiteSecurise.Name = "ckisSiteSecurise"
        Me.ckisSiteSecurise.Size = New System.Drawing.Size(136, 16)
        Me.ckisSiteSecurise.TabIndex = 6
        Me.ckisSiteSecurise.Text = "Site sécurisé :"
        Me.ckisSiteSecurise.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lbLieux
        '
        Me.lbLieux.DataSource = Me.m_bsLieuxControle
        Me.lbLieux.DisplayMember = "Nom"
        Me.lbLieux.FormattingEnabled = True
        Me.lbLieux.Location = New System.Drawing.Point(12, 37)
        Me.lbLieux.Name = "lbLieux"
        Me.lbLieux.Size = New System.Drawing.Size(182, 199)
        Me.lbLieux.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(9, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(185, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Liste des lieux répertoriés"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnValider
        '
        Me.btnValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValider.BackColor = System.Drawing.Color.Transparent
        Me.btnValider.BackgroundImage = Global.Crodip_agent.Resources.btn_valider
        Me.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnValider.FlatAppearance.BorderSize = 0
        Me.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnValider.ForeColor = System.Drawing.Color.White
        Me.btnValider.Location = New System.Drawing.Point(534, 249)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(133, 36)
        Me.btnValider.TabIndex = 16
        Me.btnValider.Text = "Valider"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.BackColor = System.Drawing.Color.Transparent
        Me.btnAnnuler.BackgroundImage = Global.Crodip_agent.Resources.btn_annuler
        Me.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.FlatAppearance.BorderSize = 0
        Me.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnuler.ForeColor = System.Drawing.Color.White
        Me.btnAnnuler.Location = New System.Drawing.Point(12, 249)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(133, 36)
        Me.btnAnnuler.TabIndex = 17
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'btn_Ajouter
        '
        Me.btn_Ajouter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Ajouter.BackColor = System.Drawing.Color.Transparent
        Me.btn_Ajouter.BackgroundImage = Global.Crodip_agent.Resources.btn_suivant
        Me.btn_Ajouter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Ajouter.FlatAppearance.BorderSize = 0
        Me.btn_Ajouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Ajouter.ForeColor = System.Drawing.Color.White
        Me.btn_Ajouter.Location = New System.Drawing.Point(208, 66)
        Me.btn_Ajouter.Name = "btn_Ajouter"
        Me.btn_Ajouter.Size = New System.Drawing.Size(146, 36)
        Me.btn_Ajouter.TabIndex = 18
        Me.btn_Ajouter.Text = "Ajouter"
        Me.btn_Ajouter.UseVisualStyleBackColor = True
        '
        'btnSuppimer
        '
        Me.btnSuppimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSuppimer.BackColor = System.Drawing.Color.Transparent
        Me.btnSuppimer.BackgroundImage = Global.Crodip_agent.Resources.btn_delete
        Me.btnSuppimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSuppimer.FlatAppearance.BorderSize = 0
        Me.btnSuppimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuppimer.ForeColor = System.Drawing.Color.White
        Me.btnSuppimer.Location = New System.Drawing.Point(208, 132)
        Me.btnSuppimer.Name = "btnSuppimer"
        Me.btnSuppimer.Size = New System.Drawing.Size(146, 36)
        Me.btnSuppimer.TabIndex = 19
        Me.btnSuppimer.Text = "Supprimer"
        Me.btnSuppimer.UseVisualStyleBackColor = True
        '
        'frmGestLieuxControle
        '
        Me.AcceptButton = Me.btnValider
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New System.Drawing.Size(679, 296)
        Me.Controls.Add(Me.btnSuppimer)
        Me.Controls.Add(Me.btn_Ajouter)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnValider)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbLieux)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGestLieuxControle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestion des lieux de contrôle"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.m_bsLieuxControle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsCommune, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbLieux As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbcodePostal As TextBox
    Friend WithEvents tbnomSite As TextBox
    Friend WithEvents ckisRecuperationResidus As CheckBox
    Friend WithEvents ckisSiteSecurise As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents m_bsLieuxControle As BindingSource
    Friend WithEvents m_bsCommune As BindingSource
    Friend WithEvents cbxSite2 As ComboBox
    Friend WithEvents cbxCommunes2 As ComboBox
    Friend WithEvents btnValider As Button
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btn_Ajouter As Button
    Friend WithEvents btnSuppimer As Button
End Class
