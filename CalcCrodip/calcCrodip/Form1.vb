Public Class Form1

    Private Sub BTN_RAMPE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_RAMPE.Click
        Dim oFrm As frmRampe
        oFrm = New frmRampe()
        oFrm.Top = Me.Top
        oFrm.Left = Me.Left
        oFrm.Show()



    End Sub
End Class
