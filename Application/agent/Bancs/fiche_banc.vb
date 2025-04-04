Imports System.Collections.Generic
Imports System.Linq
Imports CRODIPWS

Public Class fiche_banc
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Dim BancCourant As Banc
    Friend WithEvents imagesEtatMateriel As System.Windows.Forms.ImageList
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pbEtat As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbxModulesAcquisition As ComboBox
    Friend WithEvents m_bsrcBanc As BindingSource
    Friend WithEvents btnActiver As System.Windows.Forms.Button


    Public Sub New(ByVal pBancCourant As Banc)
        MyBase.New()


        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        ' On load le mano
        m_bsrcBanc.Clear()
        BancCourant = pBancCourant
        m_bsrcBanc.Add(BancCourant)

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDateAchat As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_valider As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_supprimer As System.Windows.Forms.Label
    Friend WithEvents ficheBanc_id As System.Windows.Forms.TextBox
    Friend WithEvents ficheBanc_marque As System.Windows.Forms.ComboBox
    Friend WithEvents ficheBanc_dateAchat As System.Windows.Forms.DateTimePicker
    Friend WithEvents ficheBanc_dateActivation As System.Windows.Forms.Label
    Friend WithEvents ficheBanc_dateControle As System.Windows.Forms.Label
    Friend WithEvents ficheBanc_modele As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fiche_banc))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ficheBanc_id = New System.Windows.Forms.TextBox()
        Me.m_bsrcBanc = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDateAchat = New System.Windows.Forms.Label()
        Me.ficheBanc_marque = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ficheBanc_dateActivation = New System.Windows.Forms.Label()
        Me.ficheBanc_dateControle = New System.Windows.Forms.Label()
        Me.btn_ficheMano_valider = New System.Windows.Forms.Label()
        Me.btn_ficheMano_supprimer = New System.Windows.Forms.Label()
        Me.ficheBanc_dateAchat = New System.Windows.Forms.DateTimePicker()
        Me.ficheBanc_modele = New System.Windows.Forms.TextBox()
        Me.imagesEtatMateriel = New System.Windows.Forms.ImageList(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pbEtat = New System.Windows.Forms.PictureBox()
        Me.btnActiver = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxModulesAcquisition = New System.Windows.Forms.ComboBox()
        CType(Me.m_bsrcBanc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEtat, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Text = "     Fiche banc de mesure"
        '
        'ficheBanc_id
        '
        Me.ficheBanc_id.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcBanc, "id", True))
        Me.ficheBanc_id.Location = New System.Drawing.Point(160, 48)
        Me.ficheBanc_id.MaxLength = 5
        Me.ficheBanc_id.Name = "ficheBanc_id"
        Me.ficheBanc_id.ReadOnly = True
        Me.ficheBanc_id.Size = New System.Drawing.Size(256, 20)
        Me.ficheBanc_id.TabIndex = 1
        '
        'm_bsrcBanc
        '
        Me.m_bsrcBanc.DataSource = GetType(CRODIPWS.Banc)
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(32, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Identifiant :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(32, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Marque :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(32, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Modèle :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblDateAchat
        '
        Me.lblDateAchat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateAchat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lblDateAchat.Location = New System.Drawing.Point(8, 120)
        Me.lblDateAchat.Name = "lblDateAchat"
        Me.lblDateAchat.Size = New System.Drawing.Size(218, 24)
        Me.lblDateAchat.TabIndex = 14
        Me.lblDateAchat.Text = "Date d’achat / Auto-construction :"
        Me.lblDateAchat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ficheBanc_marque
        '
        Me.ficheBanc_marque.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcBanc, "marque", True))
        Me.ficheBanc_marque.Enabled = False
        Me.ficheBanc_marque.Location = New System.Drawing.Point(160, 72)
        Me.ficheBanc_marque.Name = "ficheBanc_marque"
        Me.ficheBanc_marque.Size = New System.Drawing.Size(256, 21)
        Me.ficheBanc_marque.Sorted = True
        Me.ficheBanc_marque.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(-21, 205)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Date activation :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(-6, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Date dernier contrôle :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ficheBanc_dateActivation
        '
        Me.ficheBanc_dateActivation.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcBanc, "DateActivation", True))
        Me.ficheBanc_dateActivation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ficheBanc_dateActivation.ForeColor = System.Drawing.Color.Black
        Me.ficheBanc_dateActivation.Location = New System.Drawing.Point(157, 208)
        Me.ficheBanc_dateActivation.Name = "ficheBanc_dateActivation"
        Me.ficheBanc_dateActivation.Size = New System.Drawing.Size(160, 16)
        Me.ficheBanc_dateActivation.TabIndex = 14
        Me.ficheBanc_dateActivation.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ficheBanc_dateControle
        '
        Me.ficheBanc_dateControle.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcBanc, "dateDernierControle", True))
        Me.ficheBanc_dateControle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ficheBanc_dateControle.ForeColor = System.Drawing.Color.Black
        Me.ficheBanc_dateControle.Location = New System.Drawing.Point(157, 229)
        Me.ficheBanc_dateControle.Name = "ficheBanc_dateControle"
        Me.ficheBanc_dateControle.Size = New System.Drawing.Size(160, 16)
        Me.ficheBanc_dateControle.TabIndex = 14
        Me.ficheBanc_dateControle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btn_ficheMano_valider
        '
        Me.btn_ficheMano_valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ficheMano_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_valider.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_valider.Image = CType(resources.GetObject("btn_ficheMano_valider.Image"), System.Drawing.Image)
        Me.btn_ficheMano_valider.Location = New System.Drawing.Point(288, 341)
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
        Me.btn_ficheMano_supprimer.Location = New System.Drawing.Point(149, 341)
        Me.btn_ficheMano_supprimer.Name = "btn_ficheMano_supprimer"
        Me.btn_ficheMano_supprimer.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_supprimer.TabIndex = 6
        Me.btn_ficheMano_supprimer.Text = "    Supprimer"
        Me.btn_ficheMano_supprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ficheBanc_dateAchat
        '
        Me.ficheBanc_dateAchat.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcBanc, "dateAchat", True))
        Me.ficheBanc_dateAchat.Enabled = False
        Me.ficheBanc_dateAchat.Location = New System.Drawing.Point(232, 120)
        Me.ficheBanc_dateAchat.Name = "ficheBanc_dateAchat"
        Me.ficheBanc_dateAchat.Size = New System.Drawing.Size(184, 20)
        Me.ficheBanc_dateAchat.TabIndex = 4
        '
        'ficheBanc_modele
        '
        Me.ficheBanc_modele.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcBanc, "modele", True))
        Me.ficheBanc_modele.Enabled = False
        Me.ficheBanc_modele.Location = New System.Drawing.Point(160, 96)
        Me.ficheBanc_modele.MaxLength = 100
        Me.ficheBanc_modele.Name = "ficheBanc_modele"
        Me.ficheBanc_modele.Size = New System.Drawing.Size(256, 20)
        Me.ficheBanc_modele.TabIndex = 3
        '
        'imagesEtatMateriel
        '
        Me.imagesEtatMateriel.ImageStream = CType(resources.GetObject("imagesEtatMateriel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesEtatMateriel.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesEtatMateriel.Images.SetKeyName(0, "")
        Me.imagesEtatMateriel.Images.SetKeyName(1, "")
        Me.imagesEtatMateriel.Images.SetKeyName(2, "g.jpg")
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(32, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Etat :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pbEtat
        '
        Me.pbEtat.Location = New System.Drawing.Point(160, 184)
        Me.pbEtat.Name = "pbEtat"
        Me.pbEtat.Size = New System.Drawing.Size(20, 18)
        Me.pbEtat.TabIndex = 16
        Me.pbEtat.TabStop = False
        '
        'btnActiver
        '
        Me.btnActiver.Location = New System.Drawing.Point(196, 184)
        Me.btnActiver.Name = "btnActiver"
        Me.btnActiver.Size = New System.Drawing.Size(60, 21)
        Me.btnActiver.TabIndex = 17
        Me.btnActiver.Text = "Activer"
        Me.btnActiver.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Module d'acquisition :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxModulesAcquisition
        '
        Me.cbxModulesAcquisition.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsrcBanc, "ModuleAcquisition", True))
        Me.cbxModulesAcquisition.Enabled = False
        Me.cbxModulesAcquisition.Location = New System.Drawing.Point(160, 143)
        Me.cbxModulesAcquisition.Name = "cbxModulesAcquisition"
        Me.cbxModulesAcquisition.Size = New System.Drawing.Size(256, 21)
        Me.cbxModulesAcquisition.Sorted = True
        Me.cbxModulesAcquisition.TabIndex = 19
        '
        'fiche_banc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(441, 374)
        Me.Controls.Add(Me.cbxModulesAcquisition)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnActiver)
        Me.Controls.Add(Me.pbEtat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ficheBanc_dateAchat)
        Me.Controls.Add(Me.btn_ficheMano_valider)
        Me.Controls.Add(Me.btn_ficheMano_supprimer)
        Me.Controls.Add(Me.ficheBanc_marque)
        Me.Controls.Add(Me.ficheBanc_id)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDateAchat)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ficheBanc_dateActivation)
        Me.Controls.Add(Me.ficheBanc_dateControle)
        Me.Controls.Add(Me.ficheBanc_modele)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fiche_banc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Fiche Banc"
        CType(Me.m_bsrcBanc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEtat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub fiche_banc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '#################################################################################
        '########                   Chargement des marques,etc...                 ########
        '#################################################################################
        'MarquesManager.populateCombobox(GlobalsCRODIP.GLOB_XML_MARQUES_BANC, ficheBanc_marque)
        'Chargement des modules d'acquisisition
        Dim olstModules As New List(Of CRODIPAcquisition.ModuleAcq)

        olstModules = CRODIPAcquisition.ModuleAcq.GetlstModules()

        For Each oMod As CRODIPAcquisition.ModuleAcq In olstModules
            cbxModulesAcquisition.Items.Add(oMod.Nom)
        Next
    End Sub
    Private Sub dispBancCourant()
        Try

            '            ficheBanc_id.Text = BancCourant.id
            '           ficheBanc_marque.Text = BancCourant.marque
            '          ficheBanc_modele.Text = BancCourant.modele
            '         If Not String.IsNullOrEmpty(BancCourant.dateAchat) Then
            '        ficheBanc_dateAchat.Text = CSDate.TOCRODIPString(BancCourant.dateAchat)
            '       Else
            '      lblDateAchat.Visible = False
            '     ficheBanc_dateAchat.Enabled = False
            '    ficheBanc_dateAchat.Visible = False
            '   End If
            If BancCourant.jamaisServi Then
                pbEtat.Image = imagesEtatMateriel.Images(2) 'Gris
            Else
                If BancCourant.etat Then
                    pbEtat.Image = imagesEtatMateriel.Images(1) 'Vert
                Else
                    pbEtat.Image = imagesEtatMateriel.Images(0) 'Rouge
                End If
            End If
            btnActiver.Visible = BancCourant.jamaisServi
            '  If Not CSDate.isDateNull(BancCourant.DateActivation) Then
            ' ficheBanc_dateActivation.Text = CSDate.TOCRODIPString(BancCourant.DateActivation)
            'End If
            ' If Not CSDate.isDateNull(BancCourant.dateDernierControleS) Then
            'ficheBanc_dateControle.Text = CSDate.TOCRODIPString(BancCourant.dateDernierControleS)
            'End If
            'cbxModulesAcquisition.Text = BancCourant.ModuleAcquisition

        Catch ex As Exception
            CSDebug.dispError("fiche_banc.dispBancCourant ERR" & ex.Message)
        End Try
    End Sub

    ' Validation/enregistrement
    Private Sub btn_ficheMano_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_valider.Click
        ' On enregistre les infos
        If ficheBanc_marque.Text <> "" And ficheBanc_modele.Text <> "" And ficheBanc_dateAchat.Text <> "" Then
            Try
                'On ne met pas a jour les Id de bancs
                '               If BancCourant.idStructure = 0 Then
                'BancCourant.idStructure = agentCourant.idStructure
                'End If
                '                BancCourant.id = ficheBanc_id.Text
                '                BancCourant.marque = ficheBanc_marque.Text
                '                BancCourant.modele = ficheBanc_modele.Text
                '               BancCourant.ModuleAcquisition = cbxModulesAcquisition.Text
                '              If (ficheBanc_dateAchat.Visible) Then
                '             BancCourant.dateAchat = CSDate.TOCRODIPString(ficheBanc_dateAchat.Value)
                '    End If
                BancManager.save(BancCourant)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Catch ex As Exception
                CSDebug.dispFatal("Fiche Banc - Enregistrement : " & ex.Message.ToString)
            End Try
        Else
            MsgBox("Vous devez remplir tous les champs !", MsgBoxStyle.Information, "Erreur")
        End If
    End Sub


    Private Sub btn_ficheMano_supprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_supprimer.Click
        MsgBox("Contacter le CRODIP pour supprimer votre équipement")

        'Try
        '    Dim oFRM As SuppressionMateriel
        '    oFRM = New SuppressionMateriel(BancCourant)
        '    If oFRM.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '        Me.DialogResult = Windows.Forms.DialogResult.OK
        '        Me.Close()
        '    End If
        'Catch ex As Exception
        '    CSDebug.dispError("fiche_banc::btn_ficheMano_supprimer_Click : " & ex.Message.ToString)
        'End Try
    End Sub

    Private Sub btnActiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActiver.Click
        If MsgBox("Etes-vous sur de vouloir activer ce matériel ?", MsgBoxStyle.YesNo, "Activation de matériel") = MsgBoxResult.Yes Then
            BancCourant.ActiverMateriel(Now, agentCourant)
            dispBancCourant()
        End If
    End Sub



    Private Sub pbEtat_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbEtat.MouseDown
#If DEBUG Then
        If e.Button = Windows.Forms.MouseButtons.Right Then
            BancCourant.etat = Not BancCourant.etat
            BancCourant.dateDernierControleS = CSDate.ToCRODIPString(Now).ToString()
            dispBancCourant()
        End If
#End If
    End Sub

    Private Sub fiche_banc_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed
        '        CSEnvironnement.checkDateTimePicker(ficheBanc_dateAchat)

    End Sub
End Class
