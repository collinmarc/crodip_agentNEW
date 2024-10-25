Imports System.IO
Imports CsvHelper
Imports System.Linq
Imports System.Globalization
Imports System.Collections.Generic
Imports CsvHelper.Configuration
Imports CRODIPWS

Public Class frmGestLieuxControle

    Private Sub frmLieuxControle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initFenetre()
    End Sub
    Private Sub initFenetre()
        MarquesManager.populateCombobox(GlobalsCRODIP.GLOB_XML_CONFIG, cbxSite2, "/root/sites_proprietaire")
        chargerLieuxControle()
        If m_bsLieuxControle.Current IsNot Nothing Then
            LoadCommunes(m_bsLieuxControle.Current.codePostal)
            cbxCommunes2.Text = m_bsLieuxControle.Current.Commune
        Else
            AjouterNouveauLieu()
        End If

    End Sub
    Public Sub chargerLieuxControle()
        m_bsLieuxControle.Clear()
        Try

            If File.Exists(GlobalsCRODIP.PATH_TO_LIEUXCONTROLE) Then
                Using reader As StreamReader = New StreamReader(GlobalsCRODIP.PATH_TO_LIEUXCONTROLE)
                    Using csv As CsvReader = New CsvReader(reader, CultureInfo.InvariantCulture)
                        csv.GetRecords(Of LieuxControle)().ToList().ForEach(Sub(lieu) m_bsLieuxControle.Add(lieu))
                    End Using
                End Using
            End If
        Catch ex As Exception

            CSDebug.dispError("frmGestLieuxControle.ChargerLieuxControle ERR : ", ex)
        End Try

    End Sub

    Private Sub AjouterNouveauLieu()
        Dim oLieu As New LieuxControle()
        oLieu.Nom = "Nouveau"
        m_bsLieuxControle.Add(oLieu)
        m_bsLieuxControle.MoveLast()
    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs)
    End Sub
    Private Sub SupprimerLieu()
        If m_bsLieuxControle.Current IsNot Nothing Then
            m_bsLieuxControle.RemoveCurrent()
        End If
    End Sub
    Private Sub SauvegarderLieuxControle()

        Using wr As StreamWriter = New StreamWriter(GlobalsCRODIP.PATH_TO_LIEUXCONTROLE)
            Using csv As New CsvWriter(wr, Globalization.CultureInfo.InvariantCulture)

                csv.WriteRecords(m_bsLieuxControle.List)

            End Using
        End Using

    End Sub

    Private Sub tbcodePostal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbcodePostal.KeyPress
        CSForm.typeAllowed(e, "integer")
        If e.Handled = False Then
            CSForm.maxSize(e, sender, 5)
        End If

    End Sub


    Private Sub tbcodePostal_Validated(sender As Object, e As EventArgs) Handles tbcodePostal.Validated
        If sender.text <> "" Then
            LoadCommunes(sender.text)
        End If

    End Sub
    Protected Sub LoadCommunes(pCodePostal As String)
        Dim oReferentiel As ReferentielCommunesCSV
        Dim lstCommunes As List(Of Commune)
        oReferentiel = New ReferentielCommunesCSV()
        m_bsCommune.Clear()
        If Not String.IsNullOrEmpty(pCodePostal) Then
            lstCommunes = oReferentiel.getCommunes(pCodePostal)
            cbxCommunes2.SuspendLayout()
            Dim n As Integer = 0
            lstCommunes.ForEach(
                Sub(c) m_bsCommune.Add(c)
                    )
            cbxCommunes2.ResumeLayout()
        End If
    End Sub



    Private Sub m_bsLieuxControle_CurrentChanged(sender As Object, e As EventArgs) Handles m_bsLieuxControle.CurrentChanged
        If m_bsLieuxControle.Current IsNot Nothing Then
            LoadCommunes(m_bsLieuxControle.Current.CodePostal)
            cbxCommunes2.Text = m_bsLieuxControle.Current.Commune
        End If
    End Sub

    Private Sub cbxSite2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSite2.SelectedIndexChanged
    End Sub

    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        SauvegarderLieuxControle()
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub btn_Ajouter_Click(sender As Object, e As EventArgs) Handles btn_Ajouter.Click
        AjouterNouveauLieu()
    End Sub

    Private Sub btnSuppimer_Click(sender As Object, e As EventArgs) Handles btnSuppimer.Click
        SupprimerLieu()
    End Sub
End Class