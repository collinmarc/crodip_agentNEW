Public Class dlgIdentifiantPulverisateur
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Dim m_IdentifiantPulve As IdentifiantPulverisateur
    Friend WithEvents m_bsIdentifiantPulveristeur As System.Windows.Forms.BindingSource
    Friend WithEvents tbNumeroNational As System.Windows.Forms.TextBox
    Friend WithEvents cbxEtat As System.Windows.Forms.ComboBox
    Friend WithEvents tbLibelle As System.Windows.Forms.TextBox
    Friend WithEvents dtDateUtilisation As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Dim isAjout As Boolean = False

    Public Sub New(ByVal pIdentifiantPulve As IdentifiantPulverisateur)
        MyBase.New()

        ' On load le mano
        m_IdentifiantPulve = pIdentifiantPulve

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
    Friend WithEvents lblTitre As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_valider As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_Quitter As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgIdentifiantPulverisateur))
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.btn_ficheMano_valider = New System.Windows.Forms.Label()
        Me.btn_ficheMano_Quitter = New System.Windows.Forms.Label()
        Me.tbNumeroNational = New System.Windows.Forms.TextBox()
        Me.cbxEtat = New System.Windows.Forms.ComboBox()
        Me.tbLibelle = New System.Windows.Forms.TextBox()
        Me.dtDateUtilisation = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.m_bsIdentifiantPulveristeur = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.m_bsIdentifiantPulveristeur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitre
        '
        Me.lblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.lblTitre.Image = CType(resources.GetObject("lblTitre.Image"), System.Drawing.Image)
        Me.lblTitre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTitre.Location = New System.Drawing.Point(8, 8)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(336, 24)
        Me.lblTitre.TabIndex = 3
        Me.lblTitre.Text = "     Identifiant Pulvérisateur"
        '
        'btn_ficheMano_valider
        '
        Me.btn_ficheMano_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_valider.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_valider.Image = CType(resources.GetObject("btn_ficheMano_valider.Image"), System.Drawing.Image)
        Me.btn_ficheMano_valider.Location = New System.Drawing.Point(286, 255)
        Me.btn_ficheMano_valider.Name = "btn_ficheMano_valider"
        Me.btn_ficheMano_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_valider.TabIndex = 4
        Me.btn_ficheMano_valider.Text = "    Valider"
        Me.btn_ficheMano_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheMano_Quitter
        '
        Me.btn_ficheMano_Quitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_Quitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_Quitter.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_Quitter.Image = CType(resources.GetObject("btn_ficheMano_Quitter.Image"), System.Drawing.Image)
        Me.btn_ficheMano_Quitter.Location = New System.Drawing.Point(10, 255)
        Me.btn_ficheMano_Quitter.Name = "btn_ficheMano_Quitter"
        Me.btn_ficheMano_Quitter.Size = New System.Drawing.Size(132, 24)
        Me.btn_ficheMano_Quitter.TabIndex = 5
        Me.btn_ficheMano_Quitter.Text = "    Quitter"
        Me.btn_ficheMano_Quitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbNumeroNational
        '
        Me.tbNumeroNational.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsIdentifiantPulveristeur, "numeroNational", True))
        Me.tbNumeroNational.Location = New System.Drawing.Point(126, 49)
        Me.tbNumeroNational.Name = "tbNumeroNational"
        Me.tbNumeroNational.ReadOnly = True
        Me.tbNumeroNational.Size = New System.Drawing.Size(159, 20)
        Me.tbNumeroNational.TabIndex = 6
        '
        'cbxEtat
        '
        Me.cbxEtat.CausesValidation = False
        Me.cbxEtat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsIdentifiantPulveristeur, "etat", True))
        Me.cbxEtat.FormattingEnabled = True
        Me.cbxEtat.Items.AddRange(New Object() {"INUTILISE", "UTILISE", "INUTILISABLE"})
        Me.cbxEtat.Location = New System.Drawing.Point(126, 85)
        Me.cbxEtat.Name = "cbxEtat"
        Me.cbxEtat.Size = New System.Drawing.Size(159, 21)
        Me.cbxEtat.TabIndex = 7
        '
        'tbLibelle
        '
        Me.tbLibelle.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsIdentifiantPulveristeur, "libelle", True))
        Me.tbLibelle.Location = New System.Drawing.Point(126, 159)
        Me.tbLibelle.Multiline = True
        Me.tbLibelle.Name = "tbLibelle"
        Me.tbLibelle.Size = New System.Drawing.Size(288, 55)
        Me.tbLibelle.TabIndex = 8
        '
        'dtDateUtilisation
        '
        Me.dtDateUtilisation.CustomFormat = "yyyy-MM-dd"
        Me.dtDateUtilisation.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.m_bsIdentifiantPulveristeur, "dateUtilisation", True))
        Me.dtDateUtilisation.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDateUtilisation.Location = New System.Drawing.Point(126, 123)
        Me.dtDateUtilisation.Name = "dtDateUtilisation"
        Me.dtDateUtilisation.Size = New System.Drawing.Size(159, 20)
        Me.dtDateUtilisation.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Numéro national"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Etat"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Date utilisation"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Commentaire"
        '
        'm_bsIdentifiantPulveristeur
        '
        Me.m_bsIdentifiantPulveristeur.DataSource = GetType(Crodip_agent.IdentifiantPulverisateur)
        '
        'dlgIdentifiantPulverisateur
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(426, 288)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtDateUtilisation)
        Me.Controls.Add(Me.tbLibelle)
        Me.Controls.Add(Me.cbxEtat)
        Me.Controls.Add(Me.tbNumeroNational)
        Me.Controls.Add(Me.btn_ficheMano_valider)
        Me.Controls.Add(Me.btn_ficheMano_Quitter)
        Me.Controls.Add(Me.lblTitre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgIdentifiantPulverisateur"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Identifiant Pulvérisateur"
        CType(Me.m_bsIdentifiantPulveristeur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub dlgIdentifiantPulverisateur_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Debug.Assert(Not m_IdentifiantPulve Is Nothing)
        CSEnvironnement.checkDateTimePicker(dtDateUtilisation)

        m_bsIdentifiantPulveristeur.Add(m_IdentifiantPulve)
    End Sub

    Private Sub btn_ficheMano_supprimer_Click(sender As System.Object, e As System.EventArgs) Handles btn_ficheMano_Quitter.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_ficheMano_valider_Click(sender As System.Object, e As System.EventArgs) Handles btn_ficheMano_valider.Click
        m_bsIdentifiantPulveristeur.EndEdit()
        IdentifiantPulverisateurManager.Save(m_IdentifiantPulve)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cbxEtat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEtat.SelectedIndexChanged
        m_bsIdentifiantPulveristeur.EndEdit() 'Valide la saisie
        If m_IdentifiantPulve.isEtatINUTILISE Then
            m_IdentifiantPulve.dateUtilisation = ""
            dtDateUtilisation.Enabled = False
        Else
            m_IdentifiantPulve.dateUtilisation = CSDate.ToCRODIPString(Date.Now)
            dtDateUtilisation.Enabled = True
        End If
        m_bsIdentifiantPulveristeur.ResetCurrentItem()
    End Sub
End Class
