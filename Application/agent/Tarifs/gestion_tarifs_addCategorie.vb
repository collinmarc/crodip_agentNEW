Public Class gestion_tarifs_addCategorie
    Inherits System.Windows.Forms.Form

    Private m_Agent As Agent

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents addPresta_description As System.Windows.Forms.TextBox
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents btn_gestionTarif_valider As System.Windows.Forms.Label
    Friend WithEvents btn_gestionTarif_annuler As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(gestion_tarifs_addCategorie))
        Me.Label1 = New System.Windows.Forms.Label
        Me.addPresta_description = New System.Windows.Forms.TextBox
        Me.Label104 = New System.Windows.Forms.Label
        Me.btn_gestionTarif_valider = New System.Windows.Forms.Label
        Me.btn_gestionTarif_annuler = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "     Ajout d'une catégorie de prestations"
        '
        'addPresta_description
        '
        Me.addPresta_description.Location = New System.Drawing.Point(120, 38)
        Me.addPresta_description.Name = "addPresta_description"
        Me.addPresta_description.Size = New System.Drawing.Size(232, 20)
        Me.addPresta_description.TabIndex = 26
        Me.addPresta_description.Text = ""
        '
        'Label104
        '
        Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
        Me.Label104.Location = New System.Drawing.Point(16, 40)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(96, 16)
        Me.Label104.TabIndex = 25
        Me.Label104.Text = "Description"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_gestionTarif_valider
        '
        Me.btn_gestionTarif_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionTarif_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionTarif_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionTarif_valider.Image = CType(resources.GetObject("btn_gestionTarif_valider.Image"), System.Drawing.Image)
        Me.btn_gestionTarif_valider.Location = New System.Drawing.Point(240, 80)
        Me.btn_gestionTarif_valider.Name = "btn_gestionTarif_valider"
        Me.btn_gestionTarif_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionTarif_valider.TabIndex = 30
        Me.btn_gestionTarif_valider.Text = "    Valider / Quitter"
        Me.btn_gestionTarif_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_gestionTarif_annuler
        '
        Me.btn_gestionTarif_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionTarif_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionTarif_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_gestionTarif_annuler.Image = CType(resources.GetObject("btn_gestionTarif_annuler.Image"), System.Drawing.Image)
        Me.btn_gestionTarif_annuler.Location = New System.Drawing.Point(8, 80)
        Me.btn_gestionTarif_annuler.Name = "btn_gestionTarif_annuler"
        Me.btn_gestionTarif_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionTarif_annuler.TabIndex = 29
        Me.btn_gestionTarif_annuler.Text = "    Annuler"
        Me.btn_gestionTarif_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gestion_tarifs_addCategorie
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(378, 112)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_gestionTarif_valider)
        Me.Controls.Add(Me.btn_gestionTarif_annuler)
        Me.Controls.Add(Me.addPresta_description)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "gestion_tarifs_addCategorie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Ajouter une catégorie de prestations"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub SetContext(pAgent As Agent)
        m_Agent = pAgent
    End Sub

    ' Annulation
    Private Sub btn_gestionTarif_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionTarif_annuler.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' Validation
    Private Sub btn_gestionTarif_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionTarif_valider.Click
        Debug.Assert(m_Agent IsNot Nothing, "L'agent doit être renseigné")
        If addPresta_description.Text <> "" Then
            Dim newObject As PrestationCategorie = New PrestationCategorie

            newObject.idStructure = m_Agent.idStructure
            newObject.description = addPresta_description.Text
            PrestationCategorieManager.save(newObject, m_Agent)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

End Class
