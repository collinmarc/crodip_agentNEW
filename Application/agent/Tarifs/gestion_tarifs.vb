Imports CRODIPWS

Public Class gestion_tarifs
    Inherits frmCRODIP

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
    Friend WithEvents panel_clientele_ficheClient_fichePulve As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip_addPrestation As System.Windows.Forms.ToolTip
    Friend WithEvents btn_gestionTarif_valider As System.Windows.Forms.Label
    Friend WithEvents btn_gestionTarif_annuler As System.Windows.Forms.Label
    Friend WithEvents btn_gestionTarif_ajouterCategorie As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents m_bsTarif As System.Windows.Forms.BindingSource
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_gestionTarif_ajouterPrestation As System.Windows.Forms.Label
    Friend WithEvents ckCVGratuite As System.Windows.Forms.CheckBox
    Friend WithEvents isCategorie As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tarifHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tarifTTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDelete As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents erreur_montant As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestion_tarifs))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel_clientele_ficheClient_fichePulve = New System.Windows.Forms.Panel()
        Me.ckCVGratuite = New System.Windows.Forms.CheckBox()
        Me.btn_gestionTarif_ajouterPrestation = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.isCategorie = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tarifHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tarifTTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.m_bsTarif = New System.Windows.Forms.BindingSource(Me.components)
        Me.erreur_montant = New System.Windows.Forms.Label()
        Me.btn_gestionTarif_ajouterCategorie = New System.Windows.Forms.Label()
        Me.btn_gestionTarif_valider = New System.Windows.Forms.Label()
        Me.btn_gestionTarif_annuler = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip_addPrestation = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.panel_clientele_ficheClient_fichePulve.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsTarif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel_clientele_ficheClient_fichePulve
        '
        Me.panel_clientele_ficheClient_fichePulve.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.ckCVGratuite)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.btn_gestionTarif_ajouterPrestation)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.DataGridView1)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.erreur_montant)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.btn_gestionTarif_ajouterCategorie)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.btn_gestionTarif_valider)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.btn_gestionTarif_annuler)
        Me.panel_clientele_ficheClient_fichePulve.Controls.Add(Me.Label1)
        Me.panel_clientele_ficheClient_fichePulve.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_clientele_ficheClient_fichePulve.Location = New System.Drawing.Point(0, 0)
        Me.panel_clientele_ficheClient_fichePulve.Name = "panel_clientele_ficheClient_fichePulve"
        Me.panel_clientele_ficheClient_fichePulve.Size = New System.Drawing.Size(714, 472)
        Me.panel_clientele_ficheClient_fichePulve.TabIndex = 4
        '
        'ckCVGratuite
        '
        Me.ckCVGratuite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckCVGratuite.AutoSize = True
        Me.ckCVGratuite.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckCVGratuite.Location = New System.Drawing.Point(518, 410)
        Me.ckCVGratuite.Name = "ckCVGratuite"
        Me.ckCVGratuite.Size = New System.Drawing.Size(172, 17)
        Me.ckCVGratuite.TabIndex = 40
        Me.ckCVGratuite.Text = "Contre-visite immédiate gratuite"
        Me.ckCVGratuite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckCVGratuite.UseVisualStyleBackColor = True
        '
        'btn_gestionTarif_ajouterPrestation
        '
        Me.btn_gestionTarif_ajouterPrestation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_gestionTarif_ajouterPrestation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionTarif_ajouterPrestation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionTarif_ajouterPrestation.ForeColor = System.Drawing.Color.White
        Me.btn_gestionTarif_ajouterPrestation.Image = CType(resources.GetObject("btn_gestionTarif_ajouterPrestation.Image"), System.Drawing.Image)
        Me.btn_gestionTarif_ajouterPrestation.Location = New System.Drawing.Point(194, 440)
        Me.btn_gestionTarif_ajouterPrestation.Name = "btn_gestionTarif_ajouterPrestation"
        Me.btn_gestionTarif_ajouterPrestation.Size = New System.Drawing.Size(180, 24)
        Me.btn_gestionTarif_ajouterPrestation.TabIndex = 39
        Me.btn_gestionTarif_ajouterPrestation.Text = "       Ajouter une prestation"
        Me.btn_gestionTarif_ajouterPrestation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(230, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.isCategorie, Me.DescriptionDataGridViewTextBoxColumn, Me.tarifHT, Me.tva, Me.tarifTTC, Me.colDelete})
        Me.DataGridView1.DataSource = Me.m_bsTarif
        Me.DataGridView1.Location = New System.Drawing.Point(21, 48)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 10
        Me.DataGridView1.Size = New System.Drawing.Size(669, 356)
        Me.DataGridView1.TabIndex = 36
        '
        'isCategorie
        '
        Me.isCategorie.HeaderText = ""
        Me.isCategorie.Name = "isCategorie"
        Me.isCategorie.Width = 20
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        '
        'tarifHT
        '
        Me.tarifHT.DataPropertyName = "tarifHTS"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.tarifHT.DefaultCellStyle = DataGridViewCellStyle2
        Me.tarifHT.HeaderText = "Prix(HT)"
        Me.tarifHT.Name = "tarifHT"
        '
        'tva
        '
        Me.tva.DataPropertyName = "tvaS"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.tva.DefaultCellStyle = DataGridViewCellStyle3
        Me.tva.HeaderText = "TVA(%)"
        Me.tva.Name = "tva"
        '
        'tarifTTC
        '
        Me.tarifTTC.DataPropertyName = "tarifTTCS"
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.tarifTTC.DefaultCellStyle = DataGridViewCellStyle4
        Me.tarifTTC.HeaderText = "Prix(TTC)"
        Me.tarifTTC.Name = "tarifTTC"
        '
        'colDelete
        '
        Me.colDelete.HeaderText = ""
        Me.colDelete.Image = Global.Crodip_agent.Resources.delete
        Me.colDelete.Name = "colDelete"
        Me.colDelete.Width = 20
        '
        'm_bsTarif
        '
        Me.m_bsTarif.DataSource = GetType(Tarif)
        '
        'erreur_montant
        '
        Me.erreur_montant.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.erreur_montant.ForeColor = System.Drawing.Color.Red
        Me.erreur_montant.Location = New System.Drawing.Point(200, 440)
        Me.erreur_montant.Name = "erreur_montant"
        Me.erreur_montant.Size = New System.Drawing.Size(216, 24)
        Me.erreur_montant.TabIndex = 35
        '
        'btn_gestionTarif_ajouterCategorie
        '
        Me.btn_gestionTarif_ajouterCategorie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_gestionTarif_ajouterCategorie.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionTarif_ajouterCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionTarif_ajouterCategorie.ForeColor = System.Drawing.Color.White
        Me.btn_gestionTarif_ajouterCategorie.Image = CType(resources.GetObject("btn_gestionTarif_ajouterCategorie.Image"), System.Drawing.Image)
        Me.btn_gestionTarif_ajouterCategorie.Location = New System.Drawing.Point(8, 440)
        Me.btn_gestionTarif_ajouterCategorie.Name = "btn_gestionTarif_ajouterCategorie"
        Me.btn_gestionTarif_ajouterCategorie.Size = New System.Drawing.Size(180, 24)
        Me.btn_gestionTarif_ajouterCategorie.TabIndex = 33
        Me.btn_gestionTarif_ajouterCategorie.Text = "       Ajouter une catégorie"
        Me.btn_gestionTarif_ajouterCategorie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_gestionTarif_valider
        '
        Me.btn_gestionTarif_valider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_gestionTarif_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionTarif_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionTarif_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionTarif_valider.Image = CType(resources.GetObject("btn_gestionTarif_valider.Image"), System.Drawing.Image)
        Me.btn_gestionTarif_valider.Location = New System.Drawing.Point(576, 440)
        Me.btn_gestionTarif_valider.Name = "btn_gestionTarif_valider"
        Me.btn_gestionTarif_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionTarif_valider.TabIndex = 32
        Me.btn_gestionTarif_valider.Text = "    Valider / Quitter"
        Me.btn_gestionTarif_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_gestionTarif_annuler
        '
        Me.btn_gestionTarif_annuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_gestionTarif_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionTarif_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionTarif_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_gestionTarif_annuler.Image = CType(resources.GetObject("btn_gestionTarif_annuler.Image"), System.Drawing.Image)
        Me.btn_gestionTarif_annuler.Location = New System.Drawing.Point(432, 440)
        Me.btn_gestionTarif_annuler.Name = "btn_gestionTarif_annuler"
        Me.btn_gestionTarif_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionTarif_annuler.TabIndex = 31
        Me.btn_gestionTarif_annuler.Text = "    Annuler"
        Me.btn_gestionTarif_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "     Gestion de mes tarifs"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "puce_h2.jpg")
        '
        'gestion_tarifs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(714, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.panel_clientele_ficheClient_fichePulve)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "gestion_tarifs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Gestion de mes tarifs"
        Me.TopMost = True
        Me.panel_clientele_ficheClient_fichePulve.ResumeLayout(False)
        Me.panel_clientele_ficheClient_fichePulve.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsTarif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim maxElements As Integer = 14
    Private m_Agent As Agent
    ''' <summary>
    ''' Contexte de la fenêtre : Agent courant
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <remarks></remarks>
    Public Sub setContexte(ByVal pAgent As Agent)
        m_Agent = pAgent
    End Sub
    Private Sub gestion_tarifs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ckCVGratuite.Checked = System.IO.File.Exists("ContreVisiteGratuite")
        FillForm()
    End Sub


    Private Sub AddPrestation()
        If Not DataGridView1.CurrentRow Is Nothing Then
            Dim categorieId As Integer
            Dim oTarif As Tarif = m_bsTarif.Current
            Dim nIndex As Integer = m_bsTarif.Position
            If oTarif.isCategorie Then
                categorieId = oTarif.id
                'Recherche du dernier tarif de la categorie
                Dim bFin As Boolean = False
                Dim obj As Tarif
                While Not bFin
                    nIndex = nIndex + 1
                    If nIndex >= m_bsTarif.Count Then
                        bFin = True
                    Else
                        obj = m_bsTarif(nIndex)
                        If obj.isCategorie Then
                            bFin = True
                        End If
                    End If
                End While
            Else
                Dim oPresta As PrestationTarif = m_bsTarif.Current
                categorieId = oPresta.idCategorie
                nIndex = nIndex + 1
            End If
            Dim formAddPresta As New gestion_tarifs_addPresta(categorieId)
            If formAddPresta.ShowDialog() = Windows.Forms.DialogResult.OK Then
                m_bsTarif.Insert(nIndex, formAddPresta.Tarif)
            End If
        End If
    End Sub

    ' Validation
    Private Sub btn_gestionTarif_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionTarif_valider.Click
        Valider()
    End Sub

    Private Sub Valider()
        Dim oTarif As Tarif
        Dim oCategorie As PrestationCategorie
        Dim oPrestation As PrestationTarif

        Me.Cursor = Cursors.WaitCursor
        Dim index As Integer = 0
        For Each oTarif In m_bsTarif
            If oTarif.isCategorie Then
                oCategorie = oTarif
                Dim bNew As Boolean = False
                If oCategorie.id = 0 Then
                    bNew = True
                End If
                PrestationCategorieManager.save(oCategorie, m_Agent)
                If bNew Then
                    'il Faut mettre l'id Categorie pour toutes les presta qui suivent
                    For n As Integer = index + 1 To m_bsTarif.Count() - 1
                        oTarif = m_bsTarif(n)
                        If oTarif.isCategorie Then
                            Exit For
                        Else
                            oPrestation = oTarif
                            oPrestation.idCategorie = oCategorie.id

                        End If
                    Next
                End If
            Else
                oPrestation = oTarif
                PrestationTarifManager.save(oPrestation, m_Agent)
            End If
            index = index + 1
        Next

        Try
            If ckCVGratuite.Checked Then
                If Not System.IO.File.Exists("ContreVisiteGratuite") Then
                    System.IO.File.CreateText("ContreVisiteGratuite").Close()
                End If
            Else
                If System.IO.File.Exists("ContreVisiteGratuite") Then
                    System.IO.File.Delete("ContreVisiteGratuite")
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("Gestion-tarifs.Valider ERR : " & ex.Message)
        End Try

        'Remise à zéro des information de dernier controle
        My.Settings.Save()
        Me.Cursor = Me.DefaultCursor
        TryCast(MdiParent, parentContener).ReturnToAccueil()

    End Sub

    ' Annulation
    Private Sub btn_gestionTarif_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionTarif_annuler.Click
        TryCast(Me.MdiParent, parentContener).ReturnToAccueil()
    End Sub

    ' Ajout d'une categorie
    Private Sub btn_gestionTarif_ajouterCategorie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionTarif_ajouterCategorie.Click
        Dim formAddCategorie As New gestion_tarifs_addCategorie()
        formAddCategorie.SetContext(m_Agent)
        If formAddCategorie.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_bsTarif.Add(formAddCategorie.Categorie)
        End If
    End Sub

    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        refreshDataGridView()
    End Sub

    Private Sub refreshDataGridView()
        Dim Rowindex As Integer
        Dim oTarif As Tarif
        Rowindex = 0
        m_bsTarif.SuspendBinding()
        For Each oTarif In m_bsTarif
            If oTarif.getEtat() = Tarif.BDEtat.ETATDELETED Then
                DataGridView1.Rows(Rowindex).Visible = False
            Else
                If oTarif.isCategorie Then
                    DataGridView1.Rows(Rowindex).Cells(0).Value = ImageList1.Images(0)
                    DataGridView1.Rows(Rowindex).Cells(2).ReadOnly = True
                    DataGridView1.Rows(Rowindex).Cells(3).ReadOnly = True
                    DataGridView1.Rows(Rowindex).Cells(4).ReadOnly = True
                    DataGridView1.Rows(Rowindex).Cells(2).Style.ForeColor = Color.Transparent
                    DataGridView1.Rows(Rowindex).Cells(2).Style.BackColor = Color.LightGray
                    DataGridView1.Rows(Rowindex).Cells(3).Style.ForeColor = Color.Transparent
                    DataGridView1.Rows(Rowindex).Cells(3).Style.BackColor = Color.LightGray
                    DataGridView1.Rows(Rowindex).Cells(4).Style.ForeColor = Color.Transparent
                    DataGridView1.Rows(Rowindex).Cells(4).Style.BackColor = Color.LightGray
                    DataGridView1.Rows(Rowindex).Tag = "Categorie"
                Else
                    DataGridView1.Rows(Rowindex).Cells(0) = New DataGridViewTextBoxCell()
                    DataGridView1.Rows(Rowindex).Cells(0).Value = ""
                    DataGridView1.Rows(Rowindex).Cells(0).ReadOnly = True
                    DataGridView1.Rows(Rowindex).Cells(0).Style.ForeColor = Color.Transparent
                    DataGridView1.Rows(Rowindex).Cells(0).Style.BackColor = Color.LightGray
                    DataGridView1.Rows(Rowindex).Tag = "Prestation"
                End If
            End If
            Rowindex = Rowindex + 1
        Next
        m_bsTarif.ResumeBinding()

    End Sub
    ''' <summary>
    ''' Chargement de la fenêtre
    '''  bonding source
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillForm()
        Debug.Assert(m_Agent IsNot Nothing, "L'agent doit être renseigné")
        'Chargement du tableau
        Try
            m_bsTarif.Clear()
            m_bsTarif.ResetBindings(False)
            Dim arrCategories() As PrestationCategorie = PrestationCategorieManager.getArrayByStructureId(m_Agent.idStructure)

            For Each tmpCategorie As PrestationCategorie In arrCategories

                m_bsTarif.Add(tmpCategorie)

                ' On boucle les prestations
                'Dim arrPrestations() As objTarifPrestation = TarifsManager.getCategoriePrestations(tmpCategorie.id)
                Dim arrPrestations() As PrestationTarif = PrestationTarifManager.getArrayByCategorieId(tmpCategorie.id)
                For Each tmpPrestation As PrestationTarif In arrPrestations
                    m_bsTarif.Add(tmpPrestation)

                Next

            Next
        Catch Ex As Exception
            CSDebug.dispError(Ex.Message)
        End Try
    End Sub

    Private Sub btn_gestionTarif_ajouterPrestation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gestionTarif_ajouterPrestation.Click
        AddPrestation()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 And e.ColumnIndex = 5 Then
            Delete(e.RowIndex)
            'DataGridView1.Rows.RemoveAt(e.RowIndex)
            DataGridView1.Rows(e.RowIndex).Visible = False
            If DataGridView1.Rows(e.RowIndex).Tag = "Categorie" Then
                'on Rend les lignes suivantes invisibles
                For n As Integer = e.RowIndex + 1 To DataGridView1.Rows.Count() - 1
                    If DataGridView1.Rows(n).Tag = "Categorie" Then
                        Exit For
                    Else
                        DataGridView1.Rows(n).Visible = False
                    End If

                Next
            End If
        End If
    End Sub

    Private Sub Delete(pRowindex As Integer)
        Dim oTarif As Tarif
        If Not m_bsTarif.Current Is Nothing Then
            oTarif = m_bsTarif.Current
            oTarif.setEtat(Tarif.BDEtat.ETATDELETED)
            'If oTarif.isCategorie Then
            '    For Each oTarifPrest As Tarif In m_bsTarif
            '        If Not oTarifPrest.isCategorie Then
            '            Dim oPresta As PrestationTarif
            '            oPresta = oTarifPrest
            '            If oPresta.idCategorie = oTarif.id Then
            '                oPresta.setEtat(Tarif.BDEtat.ETATDELETED)
            '            End If
            '        End If
            '    Next
            'End If
            Dim index As Integer = m_bsTarif.Position
            For index = index - 1 To 1 Step -1
                oTarif = m_bsTarif(index)
                If oTarif.getEtat() <> Tarif.BDEtat.ETATDELETED Then
                    Exit For
                End If
            Next
            m_bsTarif.Position = index
        End If
    End Sub

End Class
