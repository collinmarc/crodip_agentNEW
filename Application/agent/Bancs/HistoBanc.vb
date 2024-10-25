Imports System.Collections.Generic
Imports System.Linq
Imports CRODIPWS

Public Class HistoBanc
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Dim BancCourant As Banc
    Friend WithEvents m_bsrcFVBanc As BindingSource
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridViewDisableButtonColumn1 As DataGridViewDisableButtonColumn
    Friend WithEvents col_Blocage As DataGridViewImageColumn
    Friend WithEvents col_dateModifS As DataGridViewTextBoxColumn
    Friend WithEvents col_FVFileName As DataGridViewDisableButtonColumn
    Friend WithEvents IdBancMesureDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PressionControleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ValeursMesureesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdManometreControleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdBuseEtalonDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AuteurDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdAgentControleurDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CaracteristiquesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModifDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModifSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BlocageDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents DateModificationAgentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModificationCrodipDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModificationAgentSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateModificationCrodipSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FVFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents imagesEtatMateriel As System.Windows.Forms.ImageList


    Public Sub New(ByVal _BancCourant As Banc)
        MyBase.New()

        ' On load le mano
        BancCourant = _BancCourant

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        For n As Integer = DataGridView1.Columns.GetColumnCount(DataGridViewElementStates.None) - 1 To 3 Step -1
            DataGridView1.Columns.RemoveAt(n)
        Next
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

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
    Friend WithEvents btn_ficheMano_valider As System.Windows.Forms.Label
    Friend WithEvents ficheBanc_id As System.Windows.Forms.TextBox
    Friend WithEvents ficheBanc_marque As System.Windows.Forms.ComboBox
    Friend WithEvents ficheBanc_dateActivation As System.Windows.Forms.Label
    Friend WithEvents ficheBanc_dateControle As System.Windows.Forms.Label
    Friend WithEvents ficheBanc_modele As System.Windows.Forms.TextBox
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ficheBanc_marque = New System.Windows.Forms.ComboBox()
        Me.ficheBanc_dateActivation = New System.Windows.Forms.Label()
        Me.ficheBanc_dateControle = New System.Windows.Forms.Label()
        Me.btn_ficheMano_valider = New System.Windows.Forms.Label()
        Me.ficheBanc_modele = New System.Windows.Forms.TextBox()
        Me.imagesEtatMateriel = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.m_bsrcFVBanc = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewDisableButtonColumn1 = New Crodip_agent.DataGridViewDisableButtonColumn()
        Me.col_Blocage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_dateModifS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_FVFileName = New Crodip_agent.DataGridViewDisableButtonColumn()
        Me.IdBancMesureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PressionControleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValeursMesureesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdManometreControleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdBuseEtalonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AuteurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdAgentControleurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaracteristiquesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModifDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModifSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlocageDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DateModificationAgentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationCrodipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationAgentSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationCrodipSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FVFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcFVBanc, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ficheBanc_modele
        '
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_Blocage, Me.col_dateModifS, Me.col_FVFileName, Me.IdBancMesureDataGridViewTextBoxColumn, Me.PressionControleDataGridViewTextBoxColumn, Me.ValeursMesureesDataGridViewTextBoxColumn, Me.IdManometreControleDataGridViewTextBoxColumn, Me.IdBuseEtalonDataGridViewTextBoxColumn, Me.IdDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn, Me.AuteurDataGridViewTextBoxColumn, Me.IdAgentControleurDataGridViewTextBoxColumn, Me.CaracteristiquesDataGridViewTextBoxColumn, Me.DateModifDataGridViewTextBoxColumn, Me.DateModifSDataGridViewTextBoxColumn, Me.BlocageDataGridViewCheckBoxColumn, Me.DateModificationAgentDataGridViewTextBoxColumn, Me.DateModificationCrodipDataGridViewTextBoxColumn, Me.DateModificationAgentSDataGridViewTextBoxColumn, Me.DateModificationCrodipSDataGridViewTextBoxColumn, Me.FVFileNameDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.m_bsrcFVBanc
        Me.DataGridView1.Location = New System.Drawing.Point(13, 126)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(403, 131)
        Me.DataGridView1.TabIndex = 15
        '
        'm_bsrcFVBanc
        '
        Me.m_bsrcFVBanc.DataSource = GetType(FVBanc)
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
        Me.DataGridViewDisableButtonColumn1.ToolTipText = "Visualiser la fiche de vérification"
        Me.DataGridViewDisableButtonColumn1.UseColumnTextForButtonValue = True
        '
        'col_Blocage
        '
        Me.col_Blocage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col_Blocage.HeaderText = "Résultat"
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
        Me.col_dateModifS.Width = 17
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
        Me.col_FVFileName.ToolTipText = "Visualiser la fiche de vérification"
        Me.col_FVFileName.UseColumnTextForButtonValue = True
        Me.col_FVFileName.Width = 17
        '
        'IdBancMesureDataGridViewTextBoxColumn
        '
        Me.IdBancMesureDataGridViewTextBoxColumn.DataPropertyName = "idBancMesure"
        Me.IdBancMesureDataGridViewTextBoxColumn.HeaderText = "idBancMesure"
        Me.IdBancMesureDataGridViewTextBoxColumn.Name = "IdBancMesureDataGridViewTextBoxColumn"
        Me.IdBancMesureDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PressionControleDataGridViewTextBoxColumn
        '
        Me.PressionControleDataGridViewTextBoxColumn.DataPropertyName = "pressionControle"
        Me.PressionControleDataGridViewTextBoxColumn.HeaderText = "pressionControle"
        Me.PressionControleDataGridViewTextBoxColumn.Name = "PressionControleDataGridViewTextBoxColumn"
        Me.PressionControleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ValeursMesureesDataGridViewTextBoxColumn
        '
        Me.ValeursMesureesDataGridViewTextBoxColumn.DataPropertyName = "valeursMesurees"
        Me.ValeursMesureesDataGridViewTextBoxColumn.HeaderText = "valeursMesurees"
        Me.ValeursMesureesDataGridViewTextBoxColumn.Name = "ValeursMesureesDataGridViewTextBoxColumn"
        Me.ValeursMesureesDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdManometreControleDataGridViewTextBoxColumn
        '
        Me.IdManometreControleDataGridViewTextBoxColumn.DataPropertyName = "idManometreControle"
        Me.IdManometreControleDataGridViewTextBoxColumn.HeaderText = "idManometreControle"
        Me.IdManometreControleDataGridViewTextBoxColumn.Name = "IdManometreControleDataGridViewTextBoxColumn"
        Me.IdManometreControleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdBuseEtalonDataGridViewTextBoxColumn
        '
        Me.IdBuseEtalonDataGridViewTextBoxColumn.DataPropertyName = "idBuseEtalon"
        Me.IdBuseEtalonDataGridViewTextBoxColumn.HeaderText = "idBuseEtalon"
        Me.IdBuseEtalonDataGridViewTextBoxColumn.Name = "IdBuseEtalonDataGridViewTextBoxColumn"
        Me.IdBuseEtalonDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TypeDataGridViewTextBoxColumn
        '
        Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "type"
        Me.TypeDataGridViewTextBoxColumn.HeaderText = "type"
        Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
        Me.TypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AuteurDataGridViewTextBoxColumn
        '
        Me.AuteurDataGridViewTextBoxColumn.DataPropertyName = "auteur"
        Me.AuteurDataGridViewTextBoxColumn.HeaderText = "auteur"
        Me.AuteurDataGridViewTextBoxColumn.Name = "AuteurDataGridViewTextBoxColumn"
        Me.AuteurDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdAgentControleurDataGridViewTextBoxColumn
        '
        Me.IdAgentControleurDataGridViewTextBoxColumn.DataPropertyName = "idAgentControleur"
        Me.IdAgentControleurDataGridViewTextBoxColumn.HeaderText = "idAgentControleur"
        Me.IdAgentControleurDataGridViewTextBoxColumn.Name = "IdAgentControleurDataGridViewTextBoxColumn"
        Me.IdAgentControleurDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CaracteristiquesDataGridViewTextBoxColumn
        '
        Me.CaracteristiquesDataGridViewTextBoxColumn.DataPropertyName = "caracteristiques"
        Me.CaracteristiquesDataGridViewTextBoxColumn.HeaderText = "caracteristiques"
        Me.CaracteristiquesDataGridViewTextBoxColumn.Name = "CaracteristiquesDataGridViewTextBoxColumn"
        Me.CaracteristiquesDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateModifDataGridViewTextBoxColumn
        '
        Me.DateModifDataGridViewTextBoxColumn.DataPropertyName = "dateModif"
        Me.DateModifDataGridViewTextBoxColumn.HeaderText = "dateModif"
        Me.DateModifDataGridViewTextBoxColumn.Name = "DateModifDataGridViewTextBoxColumn"
        Me.DateModifDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateModifSDataGridViewTextBoxColumn
        '
        Me.DateModifSDataGridViewTextBoxColumn.DataPropertyName = "dateModifS"
        Me.DateModifSDataGridViewTextBoxColumn.HeaderText = "dateModifS"
        Me.DateModifSDataGridViewTextBoxColumn.Name = "DateModifSDataGridViewTextBoxColumn"
        Me.DateModifSDataGridViewTextBoxColumn.ReadOnly = True
        '
        'BlocageDataGridViewCheckBoxColumn
        '
        Me.BlocageDataGridViewCheckBoxColumn.DataPropertyName = "blocage"
        Me.BlocageDataGridViewCheckBoxColumn.HeaderText = "blocage"
        Me.BlocageDataGridViewCheckBoxColumn.Name = "BlocageDataGridViewCheckBoxColumn"
        Me.BlocageDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'DateModificationAgentDataGridViewTextBoxColumn
        '
        Me.DateModificationAgentDataGridViewTextBoxColumn.DataPropertyName = "dateModificationAgent"
        Me.DateModificationAgentDataGridViewTextBoxColumn.HeaderText = "dateModificationAgent"
        Me.DateModificationAgentDataGridViewTextBoxColumn.Name = "DateModificationAgentDataGridViewTextBoxColumn"
        Me.DateModificationAgentDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateModificationCrodipDataGridViewTextBoxColumn
        '
        Me.DateModificationCrodipDataGridViewTextBoxColumn.DataPropertyName = "dateModificationCrodip"
        Me.DateModificationCrodipDataGridViewTextBoxColumn.HeaderText = "dateModificationCrodip"
        Me.DateModificationCrodipDataGridViewTextBoxColumn.Name = "DateModificationCrodipDataGridViewTextBoxColumn"
        Me.DateModificationCrodipDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateModificationAgentSDataGridViewTextBoxColumn
        '
        Me.DateModificationAgentSDataGridViewTextBoxColumn.DataPropertyName = "dateModificationAgentS"
        Me.DateModificationAgentSDataGridViewTextBoxColumn.HeaderText = "dateModificationAgentS"
        Me.DateModificationAgentSDataGridViewTextBoxColumn.Name = "DateModificationAgentSDataGridViewTextBoxColumn"
        Me.DateModificationAgentSDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateModificationCrodipSDataGridViewTextBoxColumn
        '
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.DataPropertyName = "dateModificationCrodipS"
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.HeaderText = "dateModificationCrodipS"
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.Name = "DateModificationCrodipSDataGridViewTextBoxColumn"
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FVFileNameDataGridViewTextBoxColumn
        '
        Me.FVFileNameDataGridViewTextBoxColumn.DataPropertyName = "FVFileName"
        Me.FVFileNameDataGridViewTextBoxColumn.HeaderText = "FVFileName"
        Me.FVFileNameDataGridViewTextBoxColumn.Name = "FVFileNameDataGridViewTextBoxColumn"
        Me.FVFileNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'HistoBanc
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
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ficheBanc_dateActivation)
        Me.Controls.Add(Me.ficheBanc_dateControle)
        Me.Controls.Add(Me.ficheBanc_modele)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "HistoBanc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Historique de vérification du Banc"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcFVBanc, System.ComponentModel.ISupportInitialize).EndInit()
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

        dispBancCourant()
    End Sub
    Private Sub dispBancCourant()
        Try

            ficheBanc_id.Text = BancCourant.id
            ficheBanc_marque.Text = BancCourant.marque
            ficheBanc_modele.Text = BancCourant.modele

            m_bsrcFVBanc.Clear()
            Dim olst As List(Of FVBanc) = FVBancManager.getlstFVBancByBancId(BancCourant.id)
            For Each oFV As FVBanc In olst
                m_bsrcFVBanc.Add(oFV)
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
            CSDebug.dispError("fiche_banc.dispBancCourant ERR" & ex.Message)
        End Try
    End Sub

    ' Validation/enregistrement
    Private Sub btn_ficheMano_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheMano_valider.Click
        ' On enregistre les infos
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = col_FVFileName.Index Then
            Dim oFV As FVBanc = m_bsrcFVBanc.Current
            EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE, oFV.FVFileName)
            CSFile.open(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE & "/" & oFV.FVFileName)
        End If
    End Sub
End Class
