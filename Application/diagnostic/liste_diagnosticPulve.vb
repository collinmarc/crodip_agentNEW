Public Class liste_diagnosticPulve
    Inherits System.Windows.Forms.Form

    Private m_oDiag As Diagnostic = Nothing


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
    Friend WithEvents listDiagnostic_col_resultat As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents listPulveDiagnostic As System.Windows.Forms.ListView
    Friend WithEvents listDiagnostic_col_numDiag As System.Windows.Forms.ColumnHeader
    Friend WithEvents listDiagnostic_col_dateDiagnotic As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_selectDiagnostic_VisuDiag As System.Windows.Forms.Label
    Friend WithEvents btn_selectDiagnostic_annuler As System.Windows.Forms.Label
    Friend WithEvents listControle_search As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(liste_diagnosticPulve))
        Me.listDiagnostic_col_resultat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listControle_search = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.listPulveDiagnostic = New System.Windows.Forms.ListView()
        Me.listDiagnostic_col_numDiag = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listDiagnostic_col_dateDiagnotic = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_selectDiagnostic_VisuDiag = New System.Windows.Forms.Label()
        Me.btn_selectDiagnostic_annuler = New System.Windows.Forms.Label()
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
        Me.listPulveDiagnostic.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.listDiagnostic_col_numDiag, Me.listDiagnostic_col_dateDiagnotic, Me.listDiagnostic_col_resultat})
        Me.listPulveDiagnostic.FullRowSelect = True
        Me.listPulveDiagnostic.GridLines = True
        Me.listPulveDiagnostic.Location = New System.Drawing.Point(9, 52)
        Me.listPulveDiagnostic.MultiSelect = False
        Me.listPulveDiagnostic.Name = "listPulveDiagnostic"
        Me.listPulveDiagnostic.Size = New System.Drawing.Size(551, 328)
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
        'liste_diagnosticPulve
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(570, 424)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Function getDiagnostic() As Diagnostic
        Return m_oDiag
    End Function

    Function searchDiagnostic(ByVal param As String)
        Try
            Dim query As String
            If param = "" Then
                query = "SELECT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat FROM Diagnostic WHERE Diagnostic.pulverisateurId='" & pulverisateurCourant.id & "' AND Diagnostic.organismePresId =" & agentCourant.idStructure
            Else
                query = "SELECT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat FROM Diagnostic WHERE Diagnostic.pulverisateurId='" & pulverisateurCourant.id & "' AND Diagnostic.organismePresId=" & agentCourant.idStructure & " AND Diagnostic.id LIKE '" & param & "%'"
            End If
            query = query & " ORDER BY Diagnostic.controleDateFin DESC"
            Dim bdd As New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResults(query)
            Dim i As Integer = 0
            listPulveDiagnostic.Items.Clear()
            While dataResults.Read()
                listPulveDiagnostic.Items.Add(Trim(dataResults.Item(0).ToString))  ' num 
                listPulveDiagnostic.Items(i).Tag = Trim(dataResults.Item(0).ToString)
                listPulveDiagnostic.Items(i).SubItems.Add(CSDate.mysql2access(Trim(dataResults.Item(1).ToString))) ' date
                Select Case Trim(dataResults.Item(2).ToString)
                    Case "-1"
                        listPulveDiagnostic.Items(i).SubItems.Add("NOK")
                        listPulveDiagnostic.Items(i).ForeColor = System.Drawing.Color.Red
                    Case "0"
                        listPulveDiagnostic.Items(i).SubItems.Add("CV")
                        listPulveDiagnostic.Items(i).ForeColor = System.Drawing.Color.Orange
                    Case "1"
                        listPulveDiagnostic.Items(i).SubItems.Add("OK")
                        listPulveDiagnostic.Items(i).ForeColor = System.Drawing.Color.Green
                End Select
                i = i + 1
            End While
            bdd = Nothing
        Catch ex As Exception
            CSDebug.dispError("liste_diagnosticPulve::searchDiagnostic : " & ex.Message.ToString)
        End Try
    End Function

    Private Sub liste_diagnosticPulve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' On récupère la liste des diagnostic du pulvé par notre agent
        searchDiagnostic("")
    End Sub

    Private Sub btn_selectDiagnostic_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectDiagnostic_annuler.Click
        Statusbar.clear()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_selectDiagnostic_VisuDiag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectDiagnostic_VisuDiag.Click
        ' On récupère le formulaire contener
        Dim myFormParentContener = Me.MdiParent

        ' Mise à jour de la barre de status
        'Statusbar.display("Nouveau diagnostic (Contre-Visite)")
        m_oDiag = Nothing
        DialogResult = Windows.Forms.DialogResult.Cancel
        If listPulveDiagnostic.SelectedItems().Count > 0 Then
            Try
                ' On récupère le pulvé selectionné
                Dim idDiag As String
                idDiag = listPulveDiagnostic.SelectedItems().Item(0).Tag.ToString
                m_oDiag = DiagnosticManager.getDiagnosticById(idDiag)
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
End Class
