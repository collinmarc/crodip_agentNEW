Imports System.Collections.Generic
Imports System.Linq
Imports CRODIPWS

Public Class HistoMano
    Inherits System.Windows.Forms.Form

#Region " Code g�n�r� par le Concepteur Windows Form "

    Dim ManoCourant As ManometreControle
    Friend WithEvents m_bsrcFVMano As BindingSource
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridViewDisableButtonColumn1 As DataGridViewDisableButtonColumn
    Friend WithEvents col_Blocage As DataGridViewImageColumn
    Friend WithEvents col_dateModifS As DataGridViewTextBoxColumn
    Friend WithEvents col_FVFileName As DataGridViewDisableButtonColumn
    Friend WithEvents imagesEtatMateriel As System.Windows.Forms.ImageList


    Public Sub New(ByVal _ManoCourant As ManometreControle)
        MyBase.New()

        ' On load le mano
        ManoCourant = _ManoCourant

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()
        For n As Integer = DataGridView1.Columns.GetColumnCount(DataGridViewElementStates.None) - 1 To 3 Step -1
            DataGridView1.Columns.RemoveAt(n)
        Next
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
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

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_ficheMano_valider As System.Windows.Forms.Label
    Friend WithEvents ficheBanc_id As System.Windows.Forms.TextBox
    Friend WithEvents ficheBanc_marque As System.Windows.Forms.ComboBox
    Friend WithEvents ficheBanc_dateActivation As System.Windows.Forms.Label
    Friend WithEvents ficheBanc_dateControle As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoMano))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ficheBanc_id = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ficheBanc_marque = New System.Windows.Forms.ComboBox()
        Me.ficheBanc_dateActivation = New System.Windows.Forms.Label()
        Me.ficheBanc_dateControle = New System.Windows.Forms.Label()
        Me.btn_ficheMano_valider = New System.Windows.Forms.Label()
        Me.imagesEtatMateriel = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.m_bsrcFVMano = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewDisableButtonColumn1 = New Crodip_agent.DataGridViewDisableButtonColumn()
        Me.col_Blocage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_dateModifS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_FVFileName = New Crodip_agent.DataGridViewDisableButtonColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcFVMano, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Text = "     Manom�tre de contr�le"
        '
        'ficheBanc_id
        '
        Me.ficheBanc_id.Location = New System.Drawing.Point(160, 48)
        Me.ficheBanc_id.MaxLength = 5
        Me.ficheBanc_id.Name = "ficheBanc_id"
        Me.ficheBanc_id.ReadOnly = True
        Me.ficheBanc_id.Size = New System.Drawing.Size(256, 20)
        Me.ficheBanc_id.TabIndex = 1
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
        'ficheBanc_marque
        '
        Me.ficheBanc_marque.Enabled = False
        Me.ficheBanc_marque.Location = New System.Drawing.Point(160, 72)
        Me.ficheBanc_marque.Name = "ficheBanc_marque"
        Me.ficheBanc_marque.Size = New System.Drawing.Size(256, 21)
        Me.ficheBanc_marque.Sorted = True
        Me.ficheBanc_marque.TabIndex = 2
        '
        'ficheBanc_dateActivation
        '
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
        Me.btn_ficheMano_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheMano_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheMano_valider.ForeColor = System.Drawing.Color.White
        Me.btn_ficheMano_valider.Image = CType(resources.GetObject("btn_ficheMano_valider.Image"), System.Drawing.Image)
        Me.btn_ficheMano_valider.Location = New System.Drawing.Point(288, 275)
        Me.btn_ficheMano_valider.Name = "btn_ficheMano_valider"
        Me.btn_ficheMano_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheMano_valider.TabIndex = 0
        Me.btn_ficheMano_valider.Text = "    Valider/Quitter"
        Me.btn_ficheMano_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imagesEtatMateriel
        '
        Me.imagesEtatMateriel.ImageStream = CType(resources.GetObject("imagesEtatMateriel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagesEtatMateriel.TransparentColor = System.Drawing.Color.Transparent
        Me.imagesEtatMateriel.Images.SetKeyName(0, "")
        Me.imagesEtatMateriel.Images.SetKeyName(1, "")
        Me.imagesEtatMateriel.Images.SetKeyName(2, "g.jpg")
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_Blocage, Me.col_dateModifS, Me.col_FVFileName})
        Me.DataGridView1.DataSource = Me.m_bsrcFVMano
        Me.DataGridView1.Location = New System.Drawing.Point(13, 126)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(403, 131)
        Me.DataGridView1.TabIndex = 15
        '
        'm_bsrcFVMano
        '
        Me.m_bsrcFVMano.DataSource = GetType(CRODIPWS.FVManometreControle)
        Me.m_bsrcFVMano.Sort = "dateModif DESC"
        '
        'DataGridViewDisableButtonColumn1
        '
        Me.DataGridViewDisableButtonColumn1.DataPropertyName = "FVFileName"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.DataGridViewDisableButtonColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewDisableButtonColumn1.HeaderText = "FVFileName"
        Me.DataGridViewDisableButtonColumn1.Name = "DataGridViewDisableButtonColumn1"
        Me.DataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewDisableButtonColumn1.Text = "Visualiser"
        Me.DataGridViewDisableButtonColumn1.ToolTipText = "Visualiser la fiche de v�rification"
        Me.DataGridViewDisableButtonColumn1.UseColumnTextForButtonValue = True
        '
        'col_Blocage
        '
        Me.col_Blocage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col_Blocage.HeaderText = "R�sultat"
        Me.col_Blocage.Image = Global.Crodip_agent.Resources.PuceVerteT
        Me.col_Blocage.Name = "col_Blocage"
        Me.col_Blocage.ReadOnly = True
        Me.col_Blocage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_Blocage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col_Blocage.Width = 71
        '
        'col_dateModifS
        '
        Me.col_dateModifS.DataPropertyName = "dateModif"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.col_dateModifS.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_dateModifS.HeaderText = "Date"
        Me.col_dateModifS.Name = "col_dateModifS"
        Me.col_dateModifS.ReadOnly = True
        '
        'col_FVFileName
        '
        Me.col_FVFileName.DataPropertyName = "FVFileName"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.col_FVFileName.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_FVFileName.HeaderText = "Rapport"
        Me.col_FVFileName.Name = "col_FVFileName"
        Me.col_FVFileName.ReadOnly = True
        Me.col_FVFileName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_FVFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col_FVFileName.Text = "Visualiser"
        Me.col_FVFileName.ToolTipText = "Visualiser la fiche de v�rification"
        Me.col_FVFileName.UseColumnTextForButtonValue = True
        '
        'HistoMano
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(441, 326)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_ficheMano_valider)
        Me.Controls.Add(Me.ficheBanc_marque)
        Me.Controls.Add(Me.ficheBanc_id)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ficheBanc_dateActivation)
        Me.Controls.Add(Me.ficheBanc_dateControle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "HistoMano"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Historique de v�rification du Manom�tre de controle"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcFVMano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub fiche_manometreControle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '#################################################################################
        '########                   Chargement des marques,etc...                 ########
        '#################################################################################
        'MarquesManager.populateCombobox(GlobalsCRODIP.GLOB_XML_MARQUES_BANC, ficheBanc_marque)
        'Chargement des modules d'acquisisition

        dispManoCourant()
    End Sub
    Private Sub dispManoCourant()
        Try

            ficheBanc_id.Text = ManoCourant.numeroNational
            ficheBanc_marque.Text = ManoCourant.marque

            m_bsrcFVMano.Clear()
            Dim olst As List(Of FVManometreControle) = FVManometreControleManager.getLstFVManometreControleByidCrodip(ManoCourant)
            For Each oFV As FVManometreControle In olst
                m_bsrcFVMano.Add(oFV)
                Dim oCell As DataGridViewDisableButtonCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(col_FVFileName.Index)
                oCell.Enabled = Not String.IsNullOrEmpty(oFV.FVFileName)
                Dim oCell2 As DataGridViewImageCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(col_Blocage.Index)
                If oFV.blocage Then
                    oCell2.Value = imagesEtatMateriel.Images(0)
                Else
                    oCell2.Value = imagesEtatMateriel.Images(1)
                End If

            Next

        Catch ex As Exception
            CSDebug.dispError("HistoMano.dispManoCourant ERR" & ex.Message)
        End Try
    End Sub

    ' Validation/enregistrement
    Private Sub btn_ficheMano_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_valider.Click
        ' On enregistre les infos
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = col_FVFileName.Index Then
            Dim oFV As FVManometreControle = m_bsrcFVMano.Current
            EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE, oFV.FVFileName)
            CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE & "/" & oFV.FVFileName)
        End If
    End Sub
End Class
