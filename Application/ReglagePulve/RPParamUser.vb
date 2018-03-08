Public Class RPParamUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            tbFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub tbGenerer_Click(sender As Object, e As EventArgs) Handles tbGenerer.Click
        Dim oReglagePulve As New ParamReglagePulve
        Dim oUser As New RPUser()
        oUser.Code = tbCode.Text
        oUser.setPassword(tbPassword.Text)
        oUser.setDateExp(dtExpiration.Value)
        oReglagePulve.coluser.Add(oUser)

        ParamReglagePulve.GenerateXML(tbFolder.Text, oReglagePulve)

    End Sub

    Private Sub tbAnnuler_Click(sender As Object, e As EventArgs) Handles tbAnnuler.Click
        Me.Close()
    End Sub
End Class