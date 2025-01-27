Imports System.Collections.Generic
Imports System.Linq
Imports CRODIPWS

Public Class fiche_buse
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Dim BuseCourant As Buse
    Friend WithEvents imagesEtatMateriel As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbEtat As System.Windows.Forms.PictureBox
    Friend WithEvents btnActiver As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ficheBuse_dateActivation As System.Windows.Forms.Label
    Friend WithEvents cbxPool As CheckedListBox
    Friend WithEvents Label9 As Label
    Friend WithEvents m_bsrcPool As BindingSource
    Friend WithEvents pnlPool As Panel
    Dim isAjout As Boolean

    Public Sub New(ByVal _BuseCourant As Buse)
        MyBase.New()

        ' On load le mano
        BuseCourant = _BuseCourant

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        cbxPool.DataSource = m_bsrcPool
        cbxPool.DisplayMember = "Libelle"

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub
    Public Sub New(ByVal _BuseCourant As Buse, ByVal _isAjout As Boolean)
        Me.New(_BuseCourant)
        isAjout = _isAjout
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_valider As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_supprimer As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ficheBuse_couleur As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ficheBuse_dateAchat As System.Windows.Forms.DateTimePicker
    Friend WithEvents ficheBuse_pressionReference As System.Windows.Forms.TextBox
    Friend WithEvents ficheBuse_debitReference As System.Windows.Forms.TextBox
    Friend WithEvents ficheBuse_idCrodip As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fiche_buse))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_ficheMano_valider = New System.Windows.Forms.Label()
        Me.btn_ficheMano_supprimer = New System.Windows.Forms.Label()
        Me.ficheBuse_dateAchat = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ficheBuse_couleur = New System.Windows.Forms.ComboBox()
        Me.ficheBuse_pressionReference = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ficheBuse_debitReference = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ficheBuse_idCrodip = New System.Windows.Forms.TextBox()
        Me.imagesEtatMateriel = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbEtat = New System.Windows.Forms.PictureBox()
        Me.btnActiver = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ficheBuse_dateActivation = New System.Windows.Forms.Label()
        Me.cbxPool = New System.Windows.Forms.CheckedListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.m_bsrcPool = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlPool = New System.Windows.Forms.Panel()
        CType(Me.pbEtat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcPool, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPool.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(336, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "     Fiche Buse"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(57, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Identifiant :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(57, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Date d'achat :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btn_ficheMano_valider
        '
        Me.btn_ficheMano_valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ficheMano_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_valider.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_valider.Image = CType(resources.GetObject("btn_ficheMano_valider.Image"), System.Drawing.Image)
        Me.btn_ficheMano_valider.Location = New System.Drawing.Point(383, 383)
        Me.btn_ficheMano_valider.Name = "btn_ficheMano_valider"
        Me.btn_ficheMano_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_valider.TabIndex = 0
        Me.btn_ficheMano_valider.Text = "    Valider/Quitter"
        Me.btn_ficheMano_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_ficheMano_supprimer
        '
        Me.btn_ficheMano_supprimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ficheMano_supprimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_supprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_supprimer.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_supprimer.Image = CType(resources.GetObject("btn_ficheMano_supprimer.Image"), System.Drawing.Image)
        Me.btn_ficheMano_supprimer.Location = New System.Drawing.Point(249, 383)
        Me.btn_ficheMano_supprimer.Name = "btn_ficheMano_supprimer"
        Me.btn_ficheMano_supprimer.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_supprimer.TabIndex = 7
        Me.btn_ficheMano_supprimer.Text = "    Supprimer"
        Me.btn_ficheMano_supprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ficheBuse_dateAchat
        '
        Me.ficheBuse_dateAchat.Enabled = False
        Me.ficheBuse_dateAchat.Location = New System.Drawing.Point(201, 162)
        Me.ficheBuse_dateAchat.Name = "ficheBuse_dateAchat"
        Me.ficheBuse_dateAchat.Size = New System.Drawing.Size(200, 20)
        Me.ficheBuse_dateAchat.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(57, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Couleur :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheBuse_couleur
        '
        Me.ficheBuse_couleur.Enabled = False
        Me.ficheBuse_couleur.Location = New System.Drawing.Point(201, 72)
        Me.ficheBuse_couleur.Name = "ficheBuse_couleur"
        Me.ficheBuse_couleur.Size = New System.Drawing.Size(200, 21)
        Me.ficheBuse_couleur.Sorted = True
        Me.ficheBuse_couleur.TabIndex = 3
        '
        'ficheBuse_pressionReference
        '
        Me.ficheBuse_pressionReference.Enabled = False
        Me.ficheBuse_pressionReference.Location = New System.Drawing.Point(201, 112)
        Me.ficheBuse_pressionReference.Name = "ficheBuse_pressionReference"
        Me.ficheBuse_pressionReference.ReadOnly = True
        Me.ficheBuse_pressionReference.Size = New System.Drawing.Size(200, 20)
        Me.ficheBuse_pressionReference.TabIndex = 4
        Me.ficheBuse_pressionReference.Text = "3"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(10, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Pression d’étalonnage :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheBuse_debitReference
        '
        Me.ficheBuse_debitReference.Enabled = False
        Me.ficheBuse_debitReference.Location = New System.Drawing.Point(201, 136)
        Me.ficheBuse_debitReference.Name = "ficheBuse_debitReference"
        Me.ficheBuse_debitReference.Size = New System.Drawing.Size(200, 20)
        Me.ficheBuse_debitReference.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(33, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Débit étalonné :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheBuse_idCrodip
        '
        Me.ficheBuse_idCrodip.Location = New System.Drawing.Point(201, 48)
        Me.ficheBuse_idCrodip.MaxLength = 5
        Me.ficheBuse_idCrodip.Name = "ficheBuse_idCrodip"
        Me.ficheBuse_idCrodip.ReadOnly = True
        Me.ficheBuse_idCrodip.Size = New System.Drawing.Size(200, 20)
        Me.ficheBuse_idCrodip.TabIndex = 2
        '
        'imagesEtatMateriel
        '
        Me.imagesEtatMateriel.ImageStream = CType(resources.GetObject("imagesEtatMateriel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesEtatMateriel.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesEtatMateriel.Images.SetKeyName(0, "")
        Me.imagesEtatMateriel.Images.SetKeyName(1, "")
        Me.imagesEtatMateriel.Images.SetKeyName(2, "g.jpg")
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(33, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Etat :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pbEtat
        '
        Me.pbEtat.Location = New System.Drawing.Point(200, 189)
        Me.pbEtat.Name = "pbEtat"
        Me.pbEtat.Size = New System.Drawing.Size(16, 16)
        Me.pbEtat.TabIndex = 33
        Me.pbEtat.TabStop = False
        '
        'btnActiver
        '
        Me.btnActiver.Location = New System.Drawing.Point(228, 188)
        Me.btnActiver.Name = "btnActiver"
        Me.btnActiver.Size = New System.Drawing.Size(52, 22)
        Me.btnActiver.TabIndex = 34
        Me.btnActiver.Text = "Activer"
        Me.btnActiver.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 16)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Date activation :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheBuse_dateActivation
        '
        Me.ficheBuse_dateActivation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ficheBuse_dateActivation.ForeColor = System.Drawing.Color.Black
        Me.ficheBuse_dateActivation.Location = New System.Drawing.Point(203, 241)
        Me.ficheBuse_dateActivation.Name = "ficheBuse_dateActivation"
        Me.ficheBuse_dateActivation.Size = New System.Drawing.Size(200, 16)
        Me.ficheBuse_dateActivation.TabIndex = 35
        Me.ficheBuse_dateActivation.Text = "01/01/2011"
        Me.ficheBuse_dateActivation.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbxPool
        '
        Me.cbxPool.FormattingEnabled = True
        Me.cbxPool.Location = New System.Drawing.Point(163, 10)
        Me.cbxPool.Name = "cbxPool"
        Me.cbxPool.Size = New System.Drawing.Size(202, 49)
        Me.cbxPool.TabIndex = 40
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(3, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 16)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Pool :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'm_bsrcPool
        '
        Me.m_bsrcPool.DataSource = GetType(CRODIPWS.Pool)
        '
        'pnlPool
        '
        Me.pnlPool.Controls.Add(Me.Label9)
        Me.pnlPool.Controls.Add(Me.cbxPool)
        Me.pnlPool.Location = New System.Drawing.Point(36, 260)
        Me.pnlPool.Name = "pnlPool"
        Me.pnlPool.Size = New System.Drawing.Size(384, 76)
        Me.pnlPool.TabIndex = 41
        '
        'fiche_buse
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(523, 416)
        Me.Controls.Add(Me.pnlPool)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ficheBuse_dateActivation)
        Me.Controls.Add(Me.btnActiver)
        Me.Controls.Add(Me.pbEtat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ficheBuse_idCrodip)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ficheBuse_couleur)
        Me.Controls.Add(Me.ficheBuse_dateAchat)
        Me.Controls.Add(Me.btn_ficheMano_valider)
        Me.Controls.Add(Me.btn_ficheMano_supprimer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ficheBuse_pressionReference)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ficheBuse_debitReference)
        Me.Controls.Add(Me.Label11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fiche_buse"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Fiche Buse"
        CType(Me.pbEtat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcPool, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPool.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub fiche_buse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '#################################################################################
        '########                   Chargement des marques,etc...                 ########
        '#################################################################################
        Dim oLst As List(Of Pool)
        oLst = PoolManager.GetListe(BuseCourant.uidstructure)
        m_bsrcPool.Clear()
        oLst.ForEach(Sub(p)
                         m_bsrcPool.Add(p)
                     End Sub)
        If Not My.Settings.GestionDesPools Then
            pnlPool.Visible = False
        End If


        DisplayBuse()
    End Sub

    Private Sub DisplayBuse()
        Me.Text = Me.Text & "[aid" & BuseCourant.idCrodip & ",uid" & BuseCourant.uid & "]"
        ficheBuse_idCrodip.Text = BuseCourant.numeroNational
        ficheBuse_couleur.Text = BuseCourant.couleur
        ficheBuse_pressionReference.Text = "3"
        ficheBuse_debitReference.Text = BuseCourant.debitEtalonnage
        Try
            ficheBuse_dateAchat.Text = CSDate.ToCRODIPString(BuseCourant.dateAchat)
        Catch
            ficheBuse_dateAchat.Text = ficheBuse_dateAchat.MinDate
        End Try
        If BuseCourant.jamaisServi Then
            pbEtat.Image = imagesEtatMateriel.Images(2) 'Gris
        Else
            If BuseCourant.etat Then
                pbEtat.Image = imagesEtatMateriel.Images(1) 'Vert
            Else
                pbEtat.Image = imagesEtatMateriel.Images(0) 'Rouge
            End If
        End If
        btnActiver.Visible = BuseCourant.jamaisServi
        If CSDate.isDateNull(BuseCourant.dateActivation) Or BuseCourant.jamaisServi Then
            ficheBuse_dateActivation.Text = ""
        Else
            ficheBuse_dateActivation.Text = CSDate.ToCRODIPString(BuseCourant.dateActivation)
        End If

        'Parcours de la Liste des Pools pour checker ceux qui sont les Pool du manoCourant
        Dim index As Integer = 0
        For index = 0 To cbxPool.Items.Count() - 1
            Dim obj As Pool = cbxPool.Items(index)
            If BuseCourant.lstPools.Where(Function(p)
                                              Return (p.idCrodip.Equals(obj.idCrodip))
                                          End Function).Count() > 0 Then
                cbxPool.SetItemChecked(index, True)
            Else
                cbxPool.SetItemChecked(index, False)
            End If
        Next


    End Sub
    ' Validation/enregistrement
    Private Sub btn_ficheMano_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_valider.Click
        ' On enregistre les infos
        If ficheBuse_pressionReference.Text <> "" And ficheBuse_debitReference.Text <> "" And ficheBuse_dateAchat.Text <> "" Then
            Try
                BuseCourant.couleur = ficheBuse_couleur.Text
                BuseCourant.pressionEtalonnage = CType(ficheBuse_pressionReference.Text.Replace(".", ","), Double)
                BuseCourant.debitEtalonnage = CType(ficheBuse_debitReference.Text.Replace(".", ","), Double)
                BuseCourant.dateAchat = CSDate.ToCRODIPString(ficheBuse_dateAchat.Value)
                BuseManager.save(BuseCourant)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Catch ex As Exception
                CSDebug.dispFatal("Fiche Buse - Enregistrement : " & ex.Message.ToString)
            End Try
        Else
            MsgBox("Vous devez remplir tous les champs !", MsgBoxStyle.Information, "Erreur")
        End If
    End Sub

#Region " Controle de saisie "

    Private Sub ficheBuse_pressionReference_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheBuse_pressionReference.KeyPress
        CSForm.typeAllowed(e, "numerique")
    End Sub

    Private Sub ficheBuse_debitReference_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ficheBuse_debitReference.KeyPress
        CSForm.typeAllowed(e, "numerique")
    End Sub

    Private Sub ficheBuse_debitMoyenAccred_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "numerique")
    End Sub

    Private Sub ficheBuse_debitMoyenControle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "numerique")
    End Sub

#End Region

    Private Sub btn_ficheMano_supprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_supprimer.Click
        MsgBox("Contacter le CRODIP pour supprimer votre équipement")

        'Dim oFRM As SuppressionMateriel
        'oFRM = New SuppressionMateriel(BuseCourant)
        'If oFRM.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        '    Me.Close()
        'End If
    End Sub

    Private Sub btnActiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActiver.Click
        If MsgBox("Etes-vous sur de vouloir activer ce matériel ?", MsgBoxStyle.YesNo, "Activation de matériel") = MsgBoxResult.Yes Then
            BuseCourant.ActiverMateriel(Now, agentCourant)
            DisplayBuse()
        End If
    End Sub

    Private Sub pbEtat_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbEtat.MouseDown
#If DEBUG Then
        If e.Button = Windows.Forms.MouseButtons.Right Then
            BuseCourant.etat = Not BuseCourant.etat
            BuseCourant.dateDernierControleS = CSDate.ToCRODIPString(Now).ToString()
            DisplayBuse()
        End If
#End If
    End Sub
End Class
