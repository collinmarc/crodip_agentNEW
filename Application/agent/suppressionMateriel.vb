Imports CRODIPWS

Public Class SuppressionMateriel
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Dim m_MaterielCourant As Materiel
    Friend WithEvents lblMatASupprimer As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbRaisonSuppression As System.Windows.Forms.TextBox
    Dim isAjout As Boolean = False

    Public Sub New(ByVal pMaterielCourant As Materiel)
        MyBase.New()

        ' On load le mano
        m_MaterielCourant = pMaterielCourant

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_valider As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_supprimer As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SuppressionMateriel))
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_ficheMano_valider = New System.Windows.Forms.Label()
        Me.btn_ficheMano_supprimer = New System.Windows.Forms.Label()
        Me.lblMatASupprimer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbRaisonSuppression = New System.Windows.Forms.TextBox()
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
        Me.lblTitre.Text = "     Suppression de matériel agent"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(10, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(322, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "ATTENTION : Vous allez supprimer le matériel suivant"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btn_ficheMano_valider
        '
        Me.btn_ficheMano_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_valider.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_valider.Image = CType(resources.GetObject("btn_ficheMano_valider.Image"), System.Drawing.Image)
        Me.btn_ficheMano_valider.Location = New System.Drawing.Point(15, 248)
        Me.btn_ficheMano_valider.Name = "btn_ficheMano_valider"
        Me.btn_ficheMano_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_valider.TabIndex = 4
        Me.btn_ficheMano_valider.Text = "    Annuler"
        Me.btn_ficheMano_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheMano_supprimer
        '
        Me.btn_ficheMano_supprimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_supprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_supprimer.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_supprimer.Image = CType(resources.GetObject("btn_ficheMano_supprimer.Image"), System.Drawing.Image)
        Me.btn_ficheMano_supprimer.Location = New System.Drawing.Point(282, 248)
        Me.btn_ficheMano_supprimer.Name = "btn_ficheMano_supprimer"
        Me.btn_ficheMano_supprimer.Size = New System.Drawing.Size(132, 24)
        Me.btn_ficheMano_supprimer.TabIndex = 5
        Me.btn_ficheMano_supprimer.Text = "    Supprimer"
        Me.btn_ficheMano_supprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMatASupprimer
        '
        Me.lblMatASupprimer.AutoSize = True
        Me.lblMatASupprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatASupprimer.ForeColor = System.Drawing.Color.Red
        Me.lblMatASupprimer.Location = New System.Drawing.Point(12, 80)
        Me.lblMatASupprimer.Name = "lblMatASupprimer"
        Me.lblMatASupprimer.Size = New System.Drawing.Size(228, 25)
        Me.lblMatASupprimer.TabIndex = 15
        Me.lblMatASupprimer.Text = "Matériel à supprimer"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(399, 49)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Ce matériel ne sera plus utilisable par la suite dans le logiciel.  Si pour confi" &
    "rmer la suppression, indiquez la raison et cliquez sur le bouton Supprimer, sino" &
    "n cliquez sur le bouton Annuler"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(15, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Raison de la suppression :"
        '
        'tbRaisonSuppression
        '
        Me.tbRaisonSuppression.Location = New System.Drawing.Point(18, 186)
        Me.tbRaisonSuppression.Name = "tbRaisonSuppression"
        Me.tbRaisonSuppression.Size = New System.Drawing.Size(381, 20)
        Me.tbRaisonSuppression.TabIndex = 18
        '
        'SuppressionMateriel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(426, 288)
        Me.Controls.Add(Me.tbRaisonSuppression)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblMatASupprimer)
        Me.Controls.Add(Me.btn_ficheMano_valider)
        Me.Controls.Add(Me.btn_ficheMano_supprimer)
        Me.Controls.Add(Me.lblTitre)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SuppressionMateriel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Supression de matériel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region




    Private Sub SuppressionMateriel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Debug.Assert(Not m_MaterielCourant Is Nothing)
        lblMatASupprimer.Text = m_MaterielCourant.Libelle
    End Sub

    Private Sub btn_ficheMano_supprimer_Click(sender As System.Object, e As System.EventArgs) Handles btn_ficheMano_supprimer.Click
        If String.IsNullOrEmpty(Me.tbRaisonSuppression.Text) Then
            MsgBox("Vous devez saisir la raison de la suppression de ce matériel")
        Else
            If MsgBox("Attention, vous allez supprimer définitivement ce matériel. Confirmez-vous ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                m_MaterielCourant.DeleteMateriel(agentCourant, Me.tbRaisonSuppression.Text)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        End If

    End Sub

    Private Sub btn_ficheMano_valider_Click(sender As System.Object, e As System.EventArgs) Handles btn_ficheMano_valider.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
