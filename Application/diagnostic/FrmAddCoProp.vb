Imports System.Collections.Generic
Public Class FrmAddCoProp

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Ajouter(tbRaisonSociale.Text, tbNomPrenom.Text)
        tbRaisonSociale.Text = ""
        tbNomPrenom.Text = ""
    End Sub

    Public Sub Ajouter(pRaisonSociale As String, pNomPrenom As String)
        lbCoProp.Items.Add(pRaisonSociale & " / " & pNomPrenom)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lbCoProp.SelectedItem IsNot Nothing Then
            lbCoProp.Items.RemoveAt(lbCoProp.SelectedIndex)
        End If
    End Sub

    Public Function getListeCoProp() As List(Of String)
        Dim oReturn As New List(Of String)
        For Each Str As String In lbCoProp.Items
            oReturn.Add(Str)
        Next
        Return oReturn
    End Function

    Private Sub bntOK_Click(sender As Object, e As EventArgs) Handles bntOK.Click
        Me.Close()
    End Sub


    Private Sub tbNomPrenom_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNomPrenom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Ajouter(tbRaisonSociale.Text, tbNomPrenom.Text)
            tbRaisonSociale.Text = ""
            tbNomPrenom.Text = ""
            tbRaisonSociale.Select()
        End If
    End Sub
End Class