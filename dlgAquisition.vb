Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class dlgAquisition

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim olst As New List(Of Acquiring)
        For Each oAcq As Acquiring In BindingSource1
            olst.Add(oAcq)
        Next
        AcquiringManager.Save(olst)
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgAquisition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Chargement du contenu de la base
        BindingSource1.Add(AcquiringManager.GetAcquiring())
    End Sub
End Class
