Public Class liste_diagnosticPulve
    Inherits System.Windows.Forms.Form

    Private m_oDiag As Diagnostic = Nothing
    Private _Puverisateur As Pulverisateur
    Private _DiagMode As Globals.DiagMode
    Public Property DiagMode() As Globals.DiagMode
        Get
            Return _DiagMode
        End Get
        Set(ByVal value As Globals.DiagMode)
            _DiagMode = value
        End Set
    End Property
    Public Property oPulve() As Pulverisateur
        Get
            Return _Puverisateur
        End Get
        Set(ByVal value As Pulverisateur)
            _Puverisateur = value
        End Set
    End Property
    Private _Exploit As Exploitation
    Friend WithEvents listDiagnostic_col_RI As ColumnHeader

    Friend WithEvents listDiagnostic_col_SM As ColumnHeader

    Friend WithEvents listDiagnostic_CC As ColumnHeader
    Friend WithEvents m_ImageList As ImageList
    Friend WithEvents DataGridView1 As DataGridView

    Friend WithEvents m_bsrcDiag As BindingSource
    Friend WithEvents id As DataGridViewTextBoxColumn

    Friend WithEvents controleDateDebut As DataGridViewTextBoxColumn

    Friend WithEvents controleEtat As DataGridViewTextBoxColumn

    Friend WithEvents Col_RI As DataGridViewImageColumn

    Friend WithEvents col_SM As DataGridViewImageColumn

    Friend WithEvents col_Contrat As DataGridViewImageColumn

    Public Property oExploit() As Exploitation
        Get
            Return _Exploit
        End Get
        Set(ByVal value As Exploitation)
            _Exploit = value
        End Set
    End Property
    Private _Agent As Agent
    Public Property oAgent() As Agent
        Get
            Return _Agent
        End Get
        Set(ByVal value As Agent)
            _Agent = value
        End Set
    End Property

#Region " Code généré par le Concepteur Windows Form "
    Public Sub setcontexte(pPulve As Pulverisateur, pExploit As Exploitation, pagent As Agent)
        oPulve = pPulve
        oExploit = pExploit
        oAgent = pagent
    End Sub
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
    Friend WithEvents listDiagnostic_col_resultat As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents listPulveDiagnostic As System.Windows.Forms.ListView
    Friend WithEvents listDiagnostic_col_numDiag As System.Windows.Forms.ColumnHeader
    Friend WithEvents listDiagnostic_col_dateDiagnotic As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_selectDiagnostic_VisuDiag As System.Windows.Forms.Label
    Friend WithEvents btn_selectDiagnostic_annuler As System.Windows.Forms.Label
    Friend WithEvents btnSignature As Label
    Friend WithEvents listControle_search As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(liste_diagnosticPulve))
        Me.listDiagnostic_col_resultat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listControle_search = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.listPulveDiagnostic = New System.Windows.Forms.ListView()
        Me.listDiagnostic_col_numDiag = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listDiagnostic_col_dateDiagnotic = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listDiagnostic_col_RI = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listDiagnostic_col_SM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listDiagnostic_CC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_selectDiagnostic_VisuDiag = New System.Windows.Forms.Label()
        Me.btn_selectDiagnostic_annuler = New System.Windows.Forms.Label()
        Me.btnSignature = New System.Windows.Forms.Label()
        Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.m_bsrcDiag = New System.Windows.Forms.BindingSource(Me.components)
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.controleDateDebut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.controleEtat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_RI = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_SM = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_Contrat = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listDiagnostic_col_resultat
        '
        Me.listDiagnostic_col_resultat.Text = "Résultat"
        Me.listDiagnostic_col_resultat.Width = 76
        '
        'listControle_search
        '
        Me.listControle_search.Location = New System.Drawing.Point(409, 16)
        Me.listControle_search.Name = "listControle_search"
        Me.listControle_search.Size = New System.Drawing.Size(152, 20)
        Me.listControle_search.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(321, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "N° contrôle : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(9, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(288, 25)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "     Sélectionnez un contrôle"
        '
        'listPulveDiagnostic
        '
        Me.listPulveDiagnostic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listPulveDiagnostic.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.listDiagnostic_col_numDiag, Me.listDiagnostic_col_dateDiagnotic, Me.listDiagnostic_col_resultat, Me.listDiagnostic_col_RI, Me.listDiagnostic_col_SM, Me.listDiagnostic_CC})
        Me.listPulveDiagnostic.FullRowSelect = True
        Me.listPulveDiagnostic.GridLines = True
        Me.listPulveDiagnostic.Location = New System.Drawing.Point(9, 52)
        Me.listPulveDiagnostic.MultiSelect = False
        Me.listPulveDiagnostic.Name = "listPulveDiagnostic"
        Me.listPulveDiagnostic.Size = New System.Drawing.Size(551, 106)
        Me.listPulveDiagnostic.TabIndex = 15
        Me.listPulveDiagnostic.UseCompatibleStateImageBehavior = False
        Me.listPulveDiagnostic.View = System.Windows.Forms.View.Details
        '
        'listDiagnostic_col_numDiag
        '
        Me.listDiagnostic_col_numDiag.Text = "N°"
        Me.listDiagnostic_col_numDiag.Width = 163
        '
        'listDiagnostic_col_dateDiagnotic
        '
        Me.listDiagnostic_col_dateDiagnotic.Text = "Date"
        Me.listDiagnostic_col_dateDiagnotic.Width = 141
        '
        'listDiagnostic_col_RI
        '
        Me.listDiagnostic_col_RI.Text = "Rapport"
        '
        'listDiagnostic_col_SM
        '
        Me.listDiagnostic_col_SM.Text = "Synthese"
        '
        'listDiagnostic_CC
        '
        Me.listDiagnostic_CC.Text = "Contrat"
        '
        'btn_selectDiagnostic_VisuDiag
        '
        Me.btn_selectDiagnostic_VisuDiag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_selectDiagnostic_VisuDiag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_selectDiagnostic_VisuDiag.ForeColor = System.Drawing.Color.White
        Me.btn_selectDiagnostic_VisuDiag.Image = CType(resources.GetObject("btn_selectDiagnostic_VisuDiag.Image"), System.Drawing.Image)
        Me.btn_selectDiagnostic_VisuDiag.Location = New System.Drawing.Point(376, 392)
        Me.btn_selectDiagnostic_VisuDiag.Name = "btn_selectDiagnostic_VisuDiag"
        Me.btn_selectDiagnostic_VisuDiag.Size = New System.Drawing.Size(180, 24)
        Me.btn_selectDiagnostic_VisuDiag.TabIndex = 51
        Me.btn_selectDiagnostic_VisuDiag.Text = "       Visualisation d’un contrôle"
        Me.btn_selectDiagnostic_VisuDiag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_selectDiagnostic_annuler
        '
        Me.btn_selectDiagnostic_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_selectDiagnostic_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_selectDiagnostic_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_selectDiagnostic_annuler.Image = CType(resources.GetObject("btn_selectDiagnostic_annuler.Image"), System.Drawing.Image)
        Me.btn_selectDiagnostic_annuler.Location = New System.Drawing.Point(8, 392)
        Me.btn_selectDiagnostic_annuler.Name = "btn_selectDiagnostic_annuler"
        Me.btn_selectDiagnostic_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_selectDiagnostic_annuler.TabIndex = 50
        Me.btn_selectDiagnostic_annuler.Text = "    Annuler"
        Me.btn_selectDiagnostic_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSignature
        '
        Me.btnSignature.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignature.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignature.ForeColor = System.Drawing.Color.White
        Me.btnSignature.Image = Global.Crodip_agent.Resources.btn_Signture
        Me.btnSignature.Location = New System.Drawing.Point(174, 392)
        Me.btnSignature.Name = "btnSignature"
        Me.btnSignature.Size = New System.Drawing.Size(160, 24)
        Me.btnSignature.TabIndex = 52
        Me.btnSignature.Text = "         Signatures"
        Me.btnSignature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_ImageList
        '
        Me.m_ImageList.ImageStream = CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.m_ImageList.Images.SetKeyName(0, "favicon-pdf.ico")
        Me.m_ImageList.Images.SetKeyName(1, "PDF.png")
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.controleDateDebut, Me.controleEtat, Me.Col_RI, Me.col_SM, Me.col_Contrat})
        Me.DataGridView1.DataSource = Me.m_bsrcDiag
        Me.DataGridView1.Location = New System.Drawing.Point(8, 173)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(552, 150)
        Me.DataGridView1.TabIndex = 53
        '
        'm_bsrcDiag
        '
        Me.m_bsrcDiag.DataSource = GetType(Crodip_agent.Diagnostic)
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "N°"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        '
        'controleDateDebut
        '
        Me.controleDateDebut.DataPropertyName = "controleDateDebut"
        Me.controleDateDebut.HeaderText = "Date"
        Me.controleDateDebut.Name = "controleDateDebut"
        Me.controleDateDebut.ReadOnly = True
        '
        'controleEtat
        '
        Me.controleEtat.DataPropertyName = "controleEtat"
        Me.controleEtat.HeaderText = "Résultat"
        Me.controleEtat.Name = "controleEtat"
        Me.controleEtat.ReadOnly = True
        '
        'Col_RI
        '
        Me.Col_RI.HeaderText = "Rapport"
        Me.Col_RI.Name = "Col_RI"
        Me.Col_RI.ReadOnly = True
        '
        'col_SM
        '
        Me.col_SM.HeaderText = "Synthèse"
        Me.col_SM.Name = "col_SM"
        Me.col_SM.ReadOnly = True
        '
        'col_Contrat
        '
        Me.col_Contrat.HeaderText = "Contrat"
        Me.col_Contrat.Name = "col_Contrat"
        Me.col_Contrat.ReadOnly = True
        '
        'liste_diagnosticPulve
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(570, 424)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSignature)
        Me.Controls.Add(Me.btn_selectDiagnostic_VisuDiag)
        Me.Controls.Add(Me.btn_selectDiagnostic_annuler)
        Me.Controls.Add(Me.listControle_search)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.listPulveDiagnostic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "liste_diagnosticPulve"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Crodip .::. Liste des contrôles"
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcDiag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Function getDiagnostic() As Diagnostic
        Return m_oDiag
    End Function

    Sub searchDiagnostic(ByVal param As String)
        Try
            Dim query As String
            If param = "" Then
                query = "SELECT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat, RIFileName, SMFileName, CCFileName FROM Diagnostic WHERE Diagnostic.pulverisateurId='" & pulverisateurCourant.id & "' AND Diagnostic.organismePresId =" & agentCourant.idStructure
            Else
                query = "SELECT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat, RIFileName, SMFileName, CCFileName FROM Diagnostic WHERE Diagnostic.pulverisateurId='" & pulverisateurCourant.id & "' AND Diagnostic.organismePresId=" & agentCourant.idStructure & " AND Diagnostic.id LIKE '" & param & "%'"
            End If
            query = query & " ORDER BY Diagnostic.controleDateFin DESC"
            Dim bdd As New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s(query)
            listPulveDiagnostic.Items.Clear()
            While dataResults.Read()
                Dim oDiag As New Diagnostic()
                Dim oItem As ListViewItem
                oItem = listPulveDiagnostic.Items.Add(Trim(dataResults.Item(0).ToString))  ' num 
                oItem.Tag = Trim(dataResults.Item(0).ToString)
                oItem.SubItems.Add(CSDate.mysql2access(Trim(dataResults.Item(1).ToString))) ' date
                Select Case Trim(dataResults.Item(2).ToString)
                    Case "-1"
                        oItem.SubItems.Add("NOK")
                        oItem.ForeColor = System.Drawing.Color.Red
                    Case "0"
                        oItem.SubItems.Add("CV")
                        oItem.ForeColor = System.Drawing.Color.Orange
                    Case "1"
                        oItem.SubItems.Add("OK")
                        oItem.ForeColor = System.Drawing.Color.Green
                End Select

                For i As Int32 = 0 To dataResults.FieldCount - 1
                    oDiag.Fill(dataResults.GetName(i), dataResults.GetValue(i))
                Next
                m_bsrcDiag.Add(oDiag)
            End While
            dataResults.Close()
            bdd.free()
            bdd = Nothing
            For Each oRow As DataGridViewRow In DataGridView1.Rows
                oRow.Cells(3).Value = New Bitmap("R:\crodip_agentNEW\img\ico\pdf.png")
                oRow.Cells(4).Value = New Bitmap("R:\crodip_agentNEW\img\ico\pdf.png")
                oRow.Cells(5).Value = New Bitmap("R:\crodip_agentNEW\img\ico\pdf.png")
            Next
        Catch ex As Exception
            CSDebug.dispError("liste_diagnosticPulve::searchDiagnostic : " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub liste_diagnosticPulve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' On récupère la liste des diagnostic du pulvé par notre agent
        btnSignature.Enabled = False
        btn_selectDiagnostic_VisuDiag.Enabled = False
        btnSignature.Visible = oAgent.isSignElecActive
        searchDiagnostic("")
    End Sub

    Private Sub btn_selectDiagnostic_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectDiagnostic_annuler.Click
        Statusbar.clear()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_selectDiagnostic_VisuDiag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectDiagnostic_VisuDiag.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        If listPulveDiagnostic.SelectedItems().Count > 0 Then
            Try
                ' On récupère le Diagnostic selectionné
                Me.DiagMode = Globals.DiagMode.CTRL_VISU
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception
                CSDebug.dispError("Visualisation Diagnostic - getDiagnosticById" & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub listControle_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listControle_search.TextChanged
        searchDiagnostic(Trim(listControle_search.Text.Replace(" ", "")))
    End Sub

    Private Sub btnSignature_Click(sender As Object, e As EventArgs) Handles btnSignature.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        If listPulveDiagnostic.SelectedItems().Count > 0 Then
            Try
                ' On récupère le Diagnostic selectionné
                Me.DiagMode = Globals.DiagMode.CTRL_SIGNATURE
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception
                CSDebug.dispError("Visualisation Diagnostic - getDiagnosticById" & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub listPulveDiagnostic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listPulveDiagnostic.SelectedIndexChanged
        Dim idDiag As String

        If listPulveDiagnostic.SelectedItems.Count() > 0 Then
            idDiag = listPulveDiagnostic.SelectedItems().Item(0).Tag.ToString
            m_oDiag = DiagnosticManager.getDiagnosticById(idDiag)
            If m_oDiag.id = idDiag Then
                btnSignature.Enabled = Not (m_oDiag.isSignCCAgent And m_oDiag.isSignCCClient And m_oDiag.isSignRIAgent And m_oDiag.isSignRIClient)
                btn_selectDiagnostic_VisuDiag.Enabled = True
            End If
        Else
            btnSignature.Enabled = False
            btn_selectDiagnostic_VisuDiag.Enabled = False

        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim oDiag As Diagnostic = m_bsrcDiag.Item(e.RowIndex)
            oDiag.getPDFs(oDiag.RIFileName)
            CSFile.open(Globals.CONST_PATH_EXP & "\" & oDiag.RIFileName)
        End If

    End Sub
End Class
