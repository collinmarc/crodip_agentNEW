Imports System.Collections.Generic
Public Class frmGestIdentifiantsPulve
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
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents btn_gestionManometresControle_valider As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents m_bsrcManoControlSuppr As System.Windows.Forms.BindingSource
    Friend WithEvents DateSuppressionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateSuppressionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateSuppressionDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateSuppressionDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_ManoControleSuppr As System.Windows.Forms.DataGridView
    Friend WithEvents NumeroNationalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents etat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateUtilisationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_ValiderQuitter As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGestIdentifiantsPulve))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_gestionManometresControle_valider = New System.Windows.Forms.Label()
        Me.dgv_ManoControleSuppr = New System.Windows.Forms.DataGridView()
        Me.m_bsrcManoControlSuppr = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btn_ValiderQuitter = New System.Windows.Forms.Label()
        Me.NumeroNationalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.etat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateUtilisationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_ManoControleSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcManoControlSuppr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_gestionManometresControle_valider
        '
        Me.btn_gestionManometresControle_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_gestionManometresControle_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gestionManometresControle_valider.ForeColor = System.Drawing.Color.White
        Me.btn_gestionManometresControle_valider.Image = CType(resources.GetObject("btn_gestionManometresControle_valider.Image"), System.Drawing.Image)
        Me.btn_gestionManometresControle_valider.Location = New System.Drawing.Point(761, 553)
        Me.btn_gestionManometresControle_valider.Name = "btn_gestionManometresControle_valider"
        Me.btn_gestionManometresControle_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_gestionManometresControle_valider.TabIndex = 37
        Me.btn_gestionManometresControle_valider.Text = "    Valider / Quitter"
        Me.btn_gestionManometresControle_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv_ManoControleSuppr
        '
        Me.dgv_ManoControleSuppr.AllowUserToAddRows = False
        Me.dgv_ManoControleSuppr.AllowUserToDeleteRows = False
        Me.dgv_ManoControleSuppr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_ManoControleSuppr.AutoGenerateColumns = False
        Me.dgv_ManoControleSuppr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_ManoControleSuppr.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ManoControleSuppr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ManoControleSuppr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ManoControleSuppr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumeroNationalDataGridViewTextBoxColumn, Me.etat, Me.DateUtilisationDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn})
        Me.dgv_ManoControleSuppr.DataSource = Me.m_bsrcManoControlSuppr
        Me.dgv_ManoControleSuppr.Location = New System.Drawing.Point(12, 37)
        Me.dgv_ManoControleSuppr.MultiSelect = False
        Me.dgv_ManoControleSuppr.Name = "dgv_ManoControleSuppr"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ManoControleSuppr.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_ManoControleSuppr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ManoControleSuppr.Size = New System.Drawing.Size(975, 562)
        Me.dgv_ManoControleSuppr.TabIndex = 39
        '
        'm_bsrcManoControlSuppr
        '
        Me.m_bsrcManoControlSuppr.AllowNew = False
        Me.m_bsrcManoControlSuppr.DataSource = GetType(Crodip_agent.IdentifiantPulverisateur)
        '
        'Label82
        '
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label82.Image = CType(resources.GetObject("Label82.Image"), System.Drawing.Image)
        Me.Label82.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label82.Location = New System.Drawing.Point(12, 9)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(608, 25)
        Me.Label82.TabIndex = 37
        Me.Label82.Text = "     Liste des identifiants pulvérisateurs"
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel13.Location = New System.Drawing.Point(0, 608)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(992, 10)
        Me.Panel13.TabIndex = 38
        '
        'btn_ValiderQuitter
        '
        Me.btn_ValiderQuitter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ValiderQuitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ValiderQuitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ValiderQuitter.ForeColor = System.Drawing.Color.White
        Me.btn_ValiderQuitter.Image = CType(resources.GetObject("btn_ValiderQuitter.Image"), System.Drawing.Image)
        Me.btn_ValiderQuitter.Location = New System.Drawing.Point(869, 635)
        Me.btn_ValiderQuitter.Name = "btn_ValiderQuitter"
        Me.btn_ValiderQuitter.Size = New System.Drawing.Size(128, 24)
        Me.btn_ValiderQuitter.TabIndex = 37
        Me.btn_ValiderQuitter.Text = "    Valider / Quitter"
        Me.btn_ValiderQuitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumeroNationalDataGridViewTextBoxColumn
        '
        Me.NumeroNationalDataGridViewTextBoxColumn.DataPropertyName = "numeroNational"
        Me.NumeroNationalDataGridViewTextBoxColumn.HeaderText = "numeroNational"
        Me.NumeroNationalDataGridViewTextBoxColumn.Name = "NumeroNationalDataGridViewTextBoxColumn"
        Me.NumeroNationalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'etat
        '
        Me.etat.DataPropertyName = "etat"
        Me.etat.HeaderText = "Etat"
        Me.etat.Name = "etat"
        '
        'DateUtilisationDataGridViewTextBoxColumn
        '
        Me.DateUtilisationDataGridViewTextBoxColumn.DataPropertyName = "dateUtilisation"
        Me.DateUtilisationDataGridViewTextBoxColumn.HeaderText = "Date utilisation"
        Me.DateUtilisationDataGridViewTextBoxColumn.Name = "DateUtilisationDataGridViewTextBoxColumn"
        Me.DateUtilisationDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Commentaire"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frmGestIdentifiantsPulve
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgv_ManoControleSuppr)
        Me.Controls.Add(Me.Label82)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.btn_ValiderQuitter)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGestIdentifiantsPulve"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des identifiants pulvérisateurs"
        CType(Me.dgv_ManoControleSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcManoControlSuppr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Evenements"


    Private Sub btn_ValiderQuitter_Click(sender As System.Object, e As System.EventArgs) Handles btn_ValiderQuitter.Click
        Quitter()
    End Sub

    Private Sub frmIdentifiantPulve_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        formLoad()
    End Sub
#If DEBUG Then
    ''' <summary>
    ''' Création de 10 Identifiant Pulvéristaeurs (Test Only)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Label82_MouseClick(sender As Object, e As MouseEventArgs) Handles Label82.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            TestCreateIdentifiantPulve()
        End If
    End Sub
#End If

    Private Sub dgv_ManoControleSuppr_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_ManoControleSuppr.RowHeaderMouseDoubleClick
        EditIdentifiantPulve()
    End Sub

    Private Sub dgv_ManoControleSuppr_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ManoControleSuppr.CellDoubleClick
        EditIdentifiantPulve()
    End Sub
#End Region 'Evenements
#Region "Actions"
    Private Function Quitter() As Boolean
        Dim bReturn As Boolean
        Try
            TryCast(MdiParent, parentContener).ReturnToAccueil()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmGestIndentifiantPulveristaeur.quitter ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Function formLoad() As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCol1 As List(Of IdentifiantPulverisateur)
            oCol1 = IdentifiantPulverisateurManager.getListe(agentCourant)
            For Each oIdent As IdentifiantPulverisateur In oCol1
                m_bsrcManoControlSuppr.Add(oIdent)
            Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmGestIndentifiantPulveristaeur.quitter ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Function TestCreateIdentifiantPulve() As Boolean
        Dim bReturn As Boolean
        Try
            'Création de Quelques Identifiant Pulvé
            For i As Integer = 0 To 10
                Dim oIdent As New IdentifiantPulverisateur()
                oIdent.id = i
                oIdent.idStructure = agentCourant.idStructure
                oIdent.numeroNational = "E001" & Format(i, "000000")
                oIdent.SetEtatINUTILISE()
                IdentifiantPulverisateurManager.Save(oIdent)
            Next

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmGestIndentifiantPulveristaeur.quitter ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Function EditIdentifiantPulve() As Boolean
        Dim bReturn As Boolean
        Try
            Dim odlg As New dlgIdentifiantPulverisateur(m_bsrcManoControlSuppr.Current)
            odlg.ShowDialog()

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmGestIndentifiantPulveristaeur.quitter ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


#End Region 'Action
End Class
