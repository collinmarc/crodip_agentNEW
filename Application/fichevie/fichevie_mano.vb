Public Class fichevie_mano
    Inherits System.Windows.Forms.Form

    Dim tmpFicheVieManoEtalon() As FVManometreEtalon
    Dim tmpFicheVieManoControle() As FVManometreControle
    Dim tmpManoId As String
    Dim tmpTypeMano As String

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal sManoId As String, ByVal ficheVieMano As Object, ByVal typeMano As String)
        MyBase.New()

        Try
            tmpTypeMano = typeMano
            Select Case typeMano
                Case "etalon"
                    tmpFicheVieManoEtalon = ficheVieMano
                Case "controle"
                    tmpFicheVieManoControle = ficheVieMano
            End Select
            tmpManoId = sManoId
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ListFichevie As System.Windows.Forms.ListView
    Friend WithEvents col_type As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_date As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_auteur As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_caracteristiques As System.Windows.Forms.ColumnHeader
    Friend WithEvents manoId As System.Windows.Forms.TextBox
    Friend WithEvents manoMarque As System.Windows.Forms.TextBox
    Friend WithEvents manoModele As System.Windows.Forms.TextBox
    Friend WithEvents manoFondEchelle As System.Windows.Forms.TextBox
    Friend WithEvents manoClasse As System.Windows.Forms.TextBox
    Friend WithEvents btn_ficheVieMano_quitter As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(fichevie_mano))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.manoId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.manoMarque = New System.Windows.Forms.TextBox
        Me.manoModele = New System.Windows.Forms.TextBox
        Me.manoFondEchelle = New System.Windows.Forms.TextBox
        Me.manoClasse = New System.Windows.Forms.TextBox
        Me.ListFichevie = New System.Windows.Forms.ListView
        Me.col_date = New System.Windows.Forms.ColumnHeader
        Me.col_type = New System.Windows.Forms.ColumnHeader
        Me.col_auteur = New System.Windows.Forms.ColumnHeader
        Me.col_caracteristiques = New System.Windows.Forms.ColumnHeader
        Me.btn_ficheVieMano_quitter = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.manoId)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.manoMarque)
        Me.GroupBox1.Controls.Add(Me.manoModele)
        Me.GroupBox1.Controls.Add(Me.manoFondEchelle)
        Me.GroupBox1.Controls.Add(Me.manoClasse)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manomètre"
        '
        'manoId
        '
        Me.manoId.BackColor = System.Drawing.SystemColors.Control
        Me.manoId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoId.Enabled = False
        Me.manoId.Location = New System.Drawing.Point(128, 24)
        Me.manoId.Name = "manoId"
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
        Me.Label3.Location = New System.Drawing.Point(16, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Modèle"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
        Me.Label5.Location = New System.Drawing.Point(280, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fond d'échelle"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
        Me.Label4.Location = New System.Drawing.Point(280, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Classe"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'manoMarque
        '
        Me.manoMarque.BackColor = System.Drawing.SystemColors.Control
        Me.manoMarque.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoMarque.Enabled = False
        Me.manoMarque.Location = New System.Drawing.Point(128, 48)
        Me.manoMarque.Name = "manoMarque"
        Me.manoMarque.TabIndex = 10
        Me.manoMarque.Text = ""
        '
        'manoModele
        '
        Me.manoModele.BackColor = System.Drawing.SystemColors.Control
        Me.manoModele.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoModele.Enabled = False
        Me.manoModele.Location = New System.Drawing.Point(128, 72)
        Me.manoModele.Name = "manoModele"
        Me.manoModele.TabIndex = 10
        Me.manoModele.Text = ""
        '
        'manoFondEchelle
        '
        Me.manoFondEchelle.BackColor = System.Drawing.SystemColors.Control
        Me.manoFondEchelle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoFondEchelle.Enabled = False
        Me.manoFondEchelle.Location = New System.Drawing.Point(400, 24)
        Me.manoFondEchelle.Name = "manoFondEchelle"
        Me.manoFondEchelle.TabIndex = 10
        Me.manoFondEchelle.Text = ""
        '
        'manoClasse
        '
        Me.manoClasse.BackColor = System.Drawing.SystemColors.Control
        Me.manoClasse.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manoClasse.Enabled = False
        Me.manoClasse.Location = New System.Drawing.Point(400, 48)
        Me.manoClasse.Name = "manoClasse"
        Me.manoClasse.TabIndex = 10
        Me.manoClasse.Text = ""
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
        Me.ListFichevie.TabIndex = 1
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
        'btn_ficheVieMano_quitter
        '
        Me.btn_ficheVieMano_quitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheVieMano_quitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheVieMano_quitter.ForeColor = System.Drawing.Color.White
        Me.btn_ficheVieMano_quitter.Image = CType(resources.GetObject("btn_ficheVieMano_quitter.Image"), System.Drawing.Image)
        Me.btn_ficheVieMano_quitter.Location = New System.Drawing.Point(440, 440)
        Me.btn_ficheVieMano_quitter.Name = "btn_ficheVieMano_quitter"
        Me.btn_ficheVieMano_quitter.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheVieMano_quitter.TabIndex = 28
        Me.btn_ficheVieMano_quitter.Text = "    Quitter"
        Me.btn_ficheVieMano_quitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fichevie_mano
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 468)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_ficheVieMano_quitter)
        Me.Controls.Add(Me.ListFichevie)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fichevie_mano"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Fiche de vie manomètre"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub fichevie_mano_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objMano As Object
        ' On récupère le manomètre en question
        If tmpTypeMano = "controle" Then
            objMano = ManometreControleManager.getManometreControleById(tmpManoId)
        ElseIf tmpTypeMano = "etalon" Then
            objMano = ManometreEtalonManager.getManometreEtalonById(tmpManoId)
        End If
        If objMano.numeroNational <> "" Then
            ' On affiche les infos sur notre mano
            manoId.Text = objMano.numeroNational
            manoMarque.Text = objMano.marque
            manoModele.Text = objMano.modele
            If tmpTypeMano = "controle" Then
                manoFondEchelle.Text = objMano.fondEchelle
            ElseIf tmpTypeMano = "etalon" Then
                manoFondEchelle.Text = objMano.fondEchelleDilate & " / " & objMano.fondEchelleMaximale
            End If
            manoClasse.Text = objMano.classe
            ' On peuple notre liste
            If tmpTypeMano = "controle" Then
                For i As Integer = 0 To (tmpFicheVieManoControle.Length - 1)
                    ListFichevie.Items.Add(tmpFicheVieManoControle(i).dateModif)  ' Date
                    ListFichevie.Items(i).SubItems.Add(tmpFicheVieManoControle(i).type) ' Type
                    ListFichevie.Items(i).SubItems.Add(tmpFicheVieManoControle(i).auteur) ' Auteur
                    ListFichevie.Items(i).SubItems.Add(tmpFicheVieManoControle(i).caracteristiques) ' Caractéristiques
                    If tmpFicheVieManoControle(i).blocage = True Then
                        ListFichevie.Items(i).BackColor = System.Drawing.Color.Red
                    End If
                Next
            ElseIf tmpTypeMano = "etalon" Then
                For i As Integer = 0 To (tmpFicheVieManoEtalon.Length - 1)
                    ListFichevie.Items.Add(tmpFicheVieManoEtalon(i).dateModif)  ' Date
                    ListFichevie.Items(i).SubItems.Add(tmpFicheVieManoEtalon(i).type) ' Type
                    ListFichevie.Items(i).SubItems.Add(tmpFicheVieManoEtalon(i).auteur) ' Auteur
                    ListFichevie.Items(i).SubItems.Add(tmpFicheVieManoEtalon(i).caracteristiques) ' Caractéristiques
                    If tmpFicheVieManoEtalon(i).blocage = True Then
                        ListFichevie.Items(i).BackColor = System.Drawing.Color.Red
                    End If
                Next
            End If
        End If

    End Sub

    ' Quitter
    Private Sub btn_ficheVieMano_quitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheVieMano_quitter.Click
        Me.Close()
    End Sub

End Class
