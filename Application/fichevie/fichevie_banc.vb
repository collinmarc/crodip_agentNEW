Public Class fichevie_banc
    Inherits System.Windows.Forms.Form

    Dim tmpFicheVieBanc() As FVBanc
    Dim tmpBancId As String

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal myBancId As String, ByVal myFicheVieBanc As Object)
        MyBase.New()

        Try
            tmpFicheVieBanc = myFicheVieBanc
            tmpBancId = myBancId
        Catch ex As Exception

        End Try

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
    Friend WithEvents ListFichevie As System.Windows.Forms.ListView
    Friend WithEvents col_date As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_type As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_auteur As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_caracteristiques As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents manoId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents manoMarque As System.Windows.Forms.TextBox
    Friend WithEvents manoModele As System.Windows.Forms.TextBox
    Friend WithEvents manoDate As System.Windows.Forms.TextBox
    Friend WithEvents btn_ficheVieBanc_quitter As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(fichevie_banc))
        Me.ListFichevie = New System.Windows.Forms.ListView
        Me.col_date = New System.Windows.Forms.ColumnHeader
        Me.col_type = New System.Windows.Forms.ColumnHeader
        Me.col_auteur = New System.Windows.Forms.ColumnHeader
        Me.col_caracteristiques = New System.Windows.Forms.ColumnHeader
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.manoId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.manoMarque = New System.Windows.Forms.TextBox
        Me.manoModele = New System.Windows.Forms.TextBox
        Me.manoDate = New System.Windows.Forms.TextBox
        Me.btn_ficheVieBanc_quitter = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListFichevie
        '
        Me.ListFichevie.CausesValidation = False
        Me.ListFichevie.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_date, Me.col_type, Me.col_auteur, Me.col_caracteristiques})
        Me.ListFichevie.FullRowSelect = True
        Me.ListFichevie.GridLines = True
        Me.ListFichevie.HideSelection = False
        Me.ListFichevie.Location = New System.Drawing.Point(8, 112)
        Me.ListFichevie.MultiSelect = False
        Me.ListFichevie.Name = "ListFichevie"
        Me.ListFichevie.Size = New System.Drawing.Size(560, 320)
        Me.ListFichevie.TabIndex = 25
        Me.ListFichevie.View = System.Windows.Forms.View.Details
        '
        'col_date
        '
        Me.col_date.Text = "Date"
        Me.col_date.Width = 110
        '
        'col_type
        '
        Me.col_type.Text = "Type"
        Me.col_type.Width = 141
        '
        'col_auteur
        '
        Me.col_auteur.Text = "Auteur"
        Me.col_auteur.Width = 75
        '
        'col_caracteristiques
        '
        Me.col_caracteristiques.Text = "Caractéristiques"
        Me.col_caracteristiques.Width = 230
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.manoId)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.manoMarque)
        Me.GroupBox1.Controls.Add(Me.manoModele)
        Me.GroupBox1.Controls.Add(Me.manoDate)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 96)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Banc de mesure"
        '
        'manoId
        '
        Me.manoId.BackColor = System.Drawing.SystemColors.Control
        Me.manoId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoId.Enabled = False
        Me.manoId.Location = New System.Drawing.Point(128, 24)
        Me.manoId.Name = "manoId"
        Me.manoId.Size = New System.Drawing.Size(128, 13)
        Me.manoId.TabIndex = 10
        Me.manoId.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "N°"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Marque"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
        Me.Label3.Location = New System.Drawing.Point(280, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Modèle"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
        Me.Label4.Location = New System.Drawing.Point(280, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Date d'achat"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'manoMarque
        '
        Me.manoMarque.BackColor = System.Drawing.SystemColors.Control
        Me.manoMarque.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoMarque.Enabled = False
        Me.manoMarque.Location = New System.Drawing.Point(128, 48)
        Me.manoMarque.Name = "manoMarque"
        Me.manoMarque.Size = New System.Drawing.Size(128, 13)
        Me.manoMarque.TabIndex = 10
        Me.manoMarque.Text = ""
        '
        'manoModele
        '
        Me.manoModele.BackColor = System.Drawing.SystemColors.Control
        Me.manoModele.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoModele.Enabled = False
        Me.manoModele.Location = New System.Drawing.Point(400, 24)
        Me.manoModele.Name = "manoModele"
        Me.manoModele.Size = New System.Drawing.Size(144, 13)
        Me.manoModele.TabIndex = 10
        Me.manoModele.Text = ""
        '
        'manoDate
        '
        Me.manoDate.BackColor = System.Drawing.SystemColors.Control
        Me.manoDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoDate.Enabled = False
        Me.manoDate.Location = New System.Drawing.Point(400, 48)
        Me.manoDate.Name = "manoDate"
        Me.manoDate.Size = New System.Drawing.Size(144, 13)
        Me.manoDate.TabIndex = 10
        Me.manoDate.Text = ""
        '
        'btn_ficheVieBanc_quitter
        '
        Me.btn_ficheVieBanc_quitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheVieBanc_quitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheVieBanc_quitter.ForeColor = System.Drawing.Color.White
        Me.btn_ficheVieBanc_quitter.Image = CType(resources.GetObject("btn_ficheVieBanc_quitter.Image"), System.Drawing.Image)
        Me.btn_ficheVieBanc_quitter.Location = New System.Drawing.Point(440, 440)
        Me.btn_ficheVieBanc_quitter.Name = "btn_ficheVieBanc_quitter"
        Me.btn_ficheVieBanc_quitter.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheVieBanc_quitter.TabIndex = 27
        Me.btn_ficheVieBanc_quitter.Text = "    Quitter"
        Me.btn_ficheVieBanc_quitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fichevie_banc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 468)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_ficheVieBanc_quitter)
        Me.Controls.Add(Me.ListFichevie)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fichevie_banc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Fiche de vie banc de mesure"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub fichevie_banc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objBanc As Banc = BancManager.getBancById(tmpBancId)
        ' On récupère le manomètre en question
        If objBanc.id <> "" Then
            ' On affiche les infos sur notre mano
            manoId.Text = objBanc.id
            manoMarque.Text = objBanc.marque
            manoModele.Text = objBanc.modele
            manoDate.Text = objBanc.dateAchat
            ' On peuple notre liste
            For i As Integer = 0 To (tmpFicheVieBanc.Length - 1)
                ListFichevie.Items.Add(tmpFicheVieBanc(i).dateModif)  ' Date
                ListFichevie.Items(i).SubItems.Add(tmpFicheVieBanc(i).type) ' Type
                ListFichevie.Items(i).SubItems.Add(tmpFicheVieBanc(i).auteur) ' Auteur
                ListFichevie.Items(i).SubItems.Add(tmpFicheVieBanc(i).caracteristiques) ' Caractéristiques
                If tmpFicheVieBanc(i).blocage = True Then
                    ListFichevie.Items(i).BackColor = System.Drawing.Color.Red
                End If
            Next
        End If
    End Sub

    ' Quitter
    Private Sub btn_ficheVieBanc_quitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheVieBanc_quitter.Click
        Me.Close()
    End Sub

End Class
