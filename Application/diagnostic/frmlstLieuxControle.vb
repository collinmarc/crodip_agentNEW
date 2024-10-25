Imports System.IO
Imports System.Linq
Imports CRODIPWS
Imports CsvHelper

Public Class frmlstLieuxControle
    Private m_LieuSelectionne As LieuxControle

    Public Function getItemSelected() As LieuxControle
        Return m_LieuSelectionne
    End Function

    Private Sub frmlstLieuxControle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chargerLieuxControle()
    End Sub

    Public Sub chargerLieuxControle()
        Try

            If File.Exists(GlobalsCRODIP.PATH_TO_LIEUXCONTROLE) Then
                Using reader As StreamReader = New StreamReader(GlobalsCRODIP.PATH_TO_LIEUXCONTROLE)
                    Using csv As CsvReader = New CsvReader(reader, Globalization.CultureInfo.InvariantCulture)
                        csv.GetRecords(Of LieuxControle)().ToList().ForEach(Sub(lieu) m_bsLieuxControle.Add(lieu))
                    End Using
                End Using
            End If
        Catch ex As Exception
            CSDebug.dispError("frmLstLieuxControle.chargerLieuxControle ERR", ex)
        End Try

    End Sub

    Private Sub lbLieuxControles_DoubleClick(sender As Object, e As EventArgs) Handles lbLieuxControles.DoubleClick
        Valider()
    End Sub

    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        Valider()
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Annuler()
    End Sub
    Private Sub Valider()
        m_LieuSelectionne = m_bsLieuxControle.Current
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Annuler()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class