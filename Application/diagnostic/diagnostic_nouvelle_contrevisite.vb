Imports System.Collections.Generic
Public Class diagnostic_nouvelle_contrevisite
    Inherits System.Windows.Forms.Form


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
    Friend WithEvents listDiagnostic_col_numDiag As System.Windows.Forms.ColumnHeader
    Friend WithEvents listDiagnostic_col_dateDiagnotic As System.Windows.Forms.ColumnHeader
    Friend WithEvents listDiagnostic_col_resultat As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents listPulveDiagnostic As System.Windows.Forms.ListView
    Friend WithEvents btn_selectDiagnostic_annuler As System.Windows.Forms.Label
    Friend WithEvents btn_selectDiagnostic_reprendreDiag As System.Windows.Forms.Label
    Friend WithEvents listControle_search As System.Windows.Forms.TextBox
    Friend WithEvents isNonReference As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_nouvelle_contrevisite))
        Me.listPulveDiagnostic = New System.Windows.Forms.ListView()
        Me.listDiagnostic_col_numDiag = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listDiagnostic_col_dateDiagnotic = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.listDiagnostic_col_resultat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.listControle_search = New System.Windows.Forms.TextBox()
        Me.btn_selectDiagnostic_annuler = New System.Windows.Forms.Label()
        Me.btn_selectDiagnostic_reprendreDiag = New System.Windows.Forms.Label()
        Me.isNonReference = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'listPulveDiagnostic
        '
        Me.listPulveDiagnostic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listPulveDiagnostic.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.listDiagnostic_col_numDiag, Me.listDiagnostic_col_dateDiagnotic, Me.listDiagnostic_col_resultat})
        Me.listPulveDiagnostic.FullRowSelect = True
        Me.listPulveDiagnostic.GridLines = True
        Me.listPulveDiagnostic.Location = New System.Drawing.Point(8, 48)
        Me.listPulveDiagnostic.MultiSelect = False
        Me.listPulveDiagnostic.Name = "listPulveDiagnostic"
        Me.listPulveDiagnostic.Size = New System.Drawing.Size(551, 328)
        Me.listPulveDiagnostic.TabIndex = 9
        Me.listPulveDiagnostic.UseCompatibleStateImageBehavior = False
        Me.listPulveDiagnostic.View = System.Windows.Forms.View.Details
        '
        'listDiagnostic_col_numDiag
        '
        Me.listDiagnostic_col_numDiag.Text = "N°"
        Me.listDiagnostic_col_numDiag.Width = 114
        '
        'listDiagnostic_col_dateDiagnotic
        '
        Me.listDiagnostic_col_dateDiagnotic.Text = "Date"
        Me.listDiagnostic_col_dateDiagnotic.Width = 135
        '
        'listDiagnostic_col_resultat
        '
        Me.listDiagnostic_col_resultat.Text = "Résultat"
        Me.listDiagnostic_col_resultat.Width = 75
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(288, 25)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "     Sélectionnez un contrôle"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(320, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "N° contrôle : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'listControle_search
        '
        Me.listControle_search.Location = New System.Drawing.Point(408, 16)
        Me.listControle_search.Name = "listControle_search"
        Me.listControle_search.Size = New System.Drawing.Size(152, 20)
        Me.listControle_search.TabIndex = 12
        '
        'btn_selectDiagnostic_annuler
        '
        Me.btn_selectDiagnostic_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_selectDiagnostic_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_selectDiagnostic_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_selectDiagnostic_annuler.Image = CType(resources.GetObject("btn_selectDiagnostic_annuler.Image"), System.Drawing.Image)
        Me.btn_selectDiagnostic_annuler.Location = New System.Drawing.Point(8, 384)
        Me.btn_selectDiagnostic_annuler.Name = "btn_selectDiagnostic_annuler"
        Me.btn_selectDiagnostic_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_selectDiagnostic_annuler.TabIndex = 48
        Me.btn_selectDiagnostic_annuler.Text = "    Annuler"
        Me.btn_selectDiagnostic_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_selectDiagnostic_reprendreDiag
        '
        Me.btn_selectDiagnostic_reprendreDiag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_selectDiagnostic_reprendreDiag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_selectDiagnostic_reprendreDiag.ForeColor = System.Drawing.Color.White
        Me.btn_selectDiagnostic_reprendreDiag.Image = CType(resources.GetObject("btn_selectDiagnostic_reprendreDiag.Image"), System.Drawing.Image)
        Me.btn_selectDiagnostic_reprendreDiag.Location = New System.Drawing.Point(376, 384)
        Me.btn_selectDiagnostic_reprendreDiag.Name = "btn_selectDiagnostic_reprendreDiag"
        Me.btn_selectDiagnostic_reprendreDiag.Size = New System.Drawing.Size(180, 24)
        Me.btn_selectDiagnostic_reprendreDiag.TabIndex = 49
        Me.btn_selectDiagnostic_reprendreDiag.Text = "       Reprendre le contrôle"
        Me.btn_selectDiagnostic_reprendreDiag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'isNonReference
        '
        Me.isNonReference.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.isNonReference.Location = New System.Drawing.Point(192, 384)
        Me.isNonReference.Name = "isNonReference"
        Me.isNonReference.Size = New System.Drawing.Size(144, 24)
        Me.isNonReference.TabIndex = 50
        Me.isNonReference.Text = "Contrôle non-référencé"
        '
        'diagnostic_nouvelle_contrevisite
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(570, 424)
        Me.Controls.Add(Me.isNonReference)
        Me.Controls.Add(Me.btn_selectDiagnostic_reprendreDiag)
        Me.Controls.Add(Me.btn_selectDiagnostic_annuler)
        Me.Controls.Add(Me.listControle_search)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.listPulveDiagnostic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diagnostic_nouvelle_contrevisite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Contrôle"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Sub searchDiagnostic(ByVal param As String)
        Try
            Dim colDiag As List(Of Diagnostic)
            colDiag = DiagnosticManager.getDiagnosticPourContreVisite(pulverisateurCourant.id, agentCourant.idStructure, param)
            Dim oDiag As Diagnostic

            Dim i As String = 0
            listPulveDiagnostic.Items.Clear()
            For Each oDiag In colDiag
                listPulveDiagnostic.Items.Add(oDiag.id)  ' Id 
                listPulveDiagnostic.Items(CInt(i)).Tag = oDiag.id
                listPulveDiagnostic.Items(CInt(i)).SubItems.Add(oDiag.controleDateFin) ' date
                Select Case Trim(oDiag.controleEtat)
                    Case Diagnostic.controleEtatNOKCC
                        listPulveDiagnostic.Items(CInt(i)).SubItems.Add("NOK")
                        listPulveDiagnostic.Items(CInt(i)).ForeColor = System.Drawing.Color.Red
                    Case Diagnostic.controleEtatNOKCV
                        listPulveDiagnostic.Items(CInt(i)).SubItems.Add("CV")
                        listPulveDiagnostic.Items(CInt(i)).ForeColor = System.Drawing.Color.Orange
                    Case Diagnostic.controleEtatOK
                        listPulveDiagnostic.Items(CInt(i)).SubItems.Add("OK")
                        listPulveDiagnostic.Items(CInt(i)).ForeColor = System.Drawing.Color.Green
                End Select
                i = i + 1
            Next oDiag
        Catch ex As Exception
            CSDebug.dispError("Liste des CV - searchDiagnostic : " & ex.Message)
        End Try
    End Sub

    Private Sub btn_selectDiagnostic_reprendreDiag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectDiagnostic_reprendreDiag.Click

        ' On récupère le formulaire contener
        Dim myFormParentContener As Form = Me.MdiParent

        If isNonReference.Checked = True Then
            Try
                ' Création d'un nouveau diagnostic
                diagnosticCourant = New Diagnostic(agentCourant, pulverisateurCourant, clientCourant)
                diagnosticCourant.controleIsComplet = False
                diagnosticCourant.controleIsPremierControle = False
                diagnosticCourant.controleDateDernierControle = ""
                diagnosticCourant.SetAsContreVisite(agentCourant)


            Catch ex As Exception
                Statusbar.clear()
                CSDebug.dispError("Nouveau diagnostic partiel : " & ex.Message)
            End Try
        Else
            If listPulveDiagnostic.SelectedItems().Count > 0 Then
                Try
                    ' On récupère le diagnostic selectionné
                    Dim oDiagOri As Diagnostic
                    oDiagOri = DiagnosticManager.getDiagnosticById(listPulveDiagnostic.SelectedItems().Item(0).Tag.ToString)
                    diagnosticCourant = oDiagOri.Clone()
                    diagnosticCourant.SetAsContreVisite(agentCourant)
                    ' Mise à jour de la barre de status
                    Statusbar.display("Nouveau contrôle (Contre Visite)")
                Catch ex As Exception
                    Statusbar.clear()
                    CSDebug.dispError("Visualisation Diagnostic - getDiagnosticById : " & ex.Message.ToString)
                End Try
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btn_selectDiagnostic_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectDiagnostic_annuler.Click
        Statusbar.clear()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub diagnostic_nouvelle_contrevisite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' On récupère la liste des diagnostic du pulvé par notre agent
        searchDiagnostic("")
        btn_selectDiagnostic_reprendreDiag.Enabled = False
    End Sub

    Private Sub listControle_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listControle_search.TextChanged
        searchDiagnostic(Trim(listControle_search.Text.Replace(" ", "")))
    End Sub

    Private Sub listPulveDiagnostic_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listPulveDiagnostic.SelectedIndexChanged
        If listPulveDiagnostic.SelectedItems.Count = 1 Then
            btn_selectDiagnostic_reprendreDiag.Enabled = True
        Else
            btn_selectDiagnostic_reprendreDiag.Enabled = False
        End If
    End Sub

    Private Sub isNonReference_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isNonReference.CheckedChanged
        If isNonReference.Checked = True Then
            btn_selectDiagnostic_reprendreDiag.Enabled = True
        End If
    End Sub
End Class
