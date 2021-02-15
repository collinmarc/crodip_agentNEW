Public Class gestion_tarifs_addPresta
    Inherits System.Windows.Forms.Form

    Public categorieId As String
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCategorie As System.Windows.Forms.Label
    Private _Tarif As PrestationTarif
    Public Property Tarif() As PrestationTarif
        Get
            Return _Tarif
        End Get
        Set(ByVal value As PrestationTarif)
            _Tarif = value
        End Set
    End Property

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal tmpCategorieId As String)
        MyBase.New()

        categorieId = tmpCategorieId

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_description As System.Windows.Forms.TextBox
    Friend WithEvents tb_tarifHT As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tb_TVA As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tb_tarifTTC As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_gestionTarif_valider As System.Windows.Forms.Label
    Friend WithEvents btn_gestionTarif_annuler As System.Windows.Forms.Label
    Friend WithEvents erreur_montant As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestion_tarifs_addPresta))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_description = New System.Windows.Forms.TextBox()
        Me.tb_tarifHT = New CRODIP_ControlLibrary.TBNumeric()
        Me.tb_TVA = New CRODIP_ControlLibrary.TBNumeric()
        Me.tb_tarifTTC = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_gestionTarif_valider = New System.Windows.Forms.Label()
        Me.btn_gestionTarif_annuler = New System.Windows.Forms.Label()
        Me.erreur_montant = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCategorie = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "     Ajout d'une prestation"
        '
        'Label104
        '
        Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label104.Location = New System.Drawing.Point(16, 66)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(127, 16)
        Me.Label104.TabIndex = 7
        Me.Label104.Text = "Description"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tarif HT"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Taux de TVA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(16, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tarif TTC"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tb_description
        '
        Me.tb_description.Location = New System.Drawing.Point(152, 66)
        Me.tb_description.Name = "tb_description"
        Me.tb_description.Size = New System.Drawing.Size(224, 20)
        Me.tb_description.TabIndex = 0
        '
        'tb_tarifHT
        '
        Me.tb_tarifHT.Location = New System.Drawing.Point(152, 92)
        Me.tb_tarifHT.Name = "tb_tarifHT"
        Me.tb_tarifHT.Size = New System.Drawing.Size(100, 20)
        Me.tb_tarifHT.TabIndex = 1
        '
        'tb_TVA
        '
        Me.tb_TVA.Location = New System.Drawing.Point(152, 116)
        Me.tb_TVA.Name = "tb_TVA"
        Me.tb_TVA.Size = New System.Drawing.Size(100, 20)
        Me.tb_TVA.TabIndex = 2
        '
        'tb_tarifTTC
        '
        Me.tb_tarifTTC.Enabled = False
        Me.tb_tarifTTC.Location = New System.Drawing.Point(152, 140)
        Me.tb_tarifTTC.Name = "tb_tarifTTC"
        Me.tb_tarifTTC.ReadOnly = True
        Me.tb_tarifTTC.Size = New System.Drawing.Size(100, 20)
        Me.tb_tarifTTC.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(256, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(8, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "€"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(256, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(8, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "€"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(256, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "%"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_gestionTarif_valider
        '
        Me.btn_gestionTarif_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionTarif_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionTarif_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionTarif_valider.Image = CType(resources.GetObject("btn_gestionTarif_valider.Image"), System.Drawing.Image)
        Me.btn_gestionTarif_valider.Location = New System.Drawing.Point(254, 194)
        Me.btn_gestionTarif_valider.Name = "btn_gestionTarif_valider"
        Me.btn_gestionTarif_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionTarif_valider.TabIndex = 4
        Me.btn_gestionTarif_valider.Text = "    Valider / Quitter"
        Me.btn_gestionTarif_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_gestionTarif_annuler
        '
        Me.btn_gestionTarif_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionTarif_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionTarif_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_gestionTarif_annuler.Image = CType(resources.GetObject("btn_gestionTarif_annuler.Image"), System.Drawing.Image)
        Me.btn_gestionTarif_annuler.Location = New System.Drawing.Point(6, 194)
        Me.btn_gestionTarif_annuler.Name = "btn_gestionTarif_annuler"
        Me.btn_gestionTarif_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionTarif_annuler.TabIndex = 31
        Me.btn_gestionTarif_annuler.Text = "    Annuler"
        Me.btn_gestionTarif_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'erreur_montant
        '
        Me.erreur_montant.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.erreur_montant.ForeColor = System.Drawing.Color.Red
        Me.erreur_montant.Location = New System.Drawing.Point(16, 171)
        Me.erreur_montant.Name = "erreur_montant"
        Me.erreur_montant.Size = New System.Drawing.Size(360, 23)
        Me.erreur_montant.TabIndex = 32
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(16, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 16)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Catégorie"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategorie
        '
        Me.lblCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategorie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCategorie.Location = New System.Drawing.Point(149, 47)
        Me.lblCategorie.Name = "lblCategorie"
        Me.lblCategorie.Size = New System.Drawing.Size(127, 16)
        Me.lblCategorie.TabIndex = 34
        Me.lblCategorie.Text = "lblCatégorie"
        Me.lblCategorie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gestion_tarifs_addPresta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(394, 227)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblCategorie)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.erreur_montant)
        Me.Controls.Add(Me.btn_gestionTarif_valider)
        Me.Controls.Add(Me.btn_gestionTarif_annuler)
        Me.Controls.Add(Me.tb_description)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_tarifHT)
        Me.Controls.Add(Me.tb_TVA)
        Me.Controls.Add(Me.tb_tarifTTC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "gestion_tarifs_addPresta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Ajout d'une prestation"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Calcul tarif TTC"

    Sub calctarifTTC()

        If tb_tarifHT.Text <> "" And tb_TVA.Text <> "" Then
            tb_tarifTTC.Text = (CType(tb_tarifHT.Text.Replace(".", ","), Double) + (CType(tb_tarifHT.Text.Replace(".", ","), Double) * (CType(tb_TVA.Text.Replace(".", ","), Double) / 100))).ToString
        End If

    End Sub
    Private Sub addPresta_tarifHT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_tarifHT.TextChanged
        calctarifTTC()
    End Sub
    Private Sub addPresta_TVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_TVA.TextChanged
        calctarifTTC()
    End Sub

#End Region

    ' Validation
    Private Sub btn_gestionTarif_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionTarif_valider.Click
        'If addPresta_tarifHT.Text = "0" Then
        'erreur_montant.Text = "Montant incorrect"
        Me.Cursor = Cursors.WaitCursor
        If tb_description.Text <> "" And tb_tarifHT.Text <> "" And tb_TVA.Text <> "" Then
            Tarif = New PrestationTarif
            Tarif.idCategorie = CType(categorieId, Integer)
            Tarif.idStructure = agentCourant.idStructure
            Tarif.description = tb_description.Text
            Tarif.tarifHT = tb_tarifHT.DecimalValue
            Tarif.tarifTTC = tb_tarifTTC.DecimalValue
            Tarif.tva = tb_TVA.DecimalValue
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Cursor = Cursors.Default
            Me.Close()
        End If
    End Sub

    ' Annulation
    Private Sub btn_gestionTarif_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionTarif_annuler.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#Region " Controles de saisie "
    Private Sub forceDot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_tarifHT.KeyPress, tb_TVA.KeyPress
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub
#End Region

    Private Sub gestion_tarifs_addPresta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tb_TVA.Text = My.Settings.TxTVADefaut
        Dim oCat As PrestationCategorie
        oCat = PrestationCategorieManager.getCategoryById(categorieId, agentCourant.idStructure)
        If Not oCat Is Nothing Then
            lblCategorie.Text = oCat.description
        End If
    End Sub
End Class
