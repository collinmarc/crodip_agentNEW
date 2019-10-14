Public Class tool_ParamModeSimplifie
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim oresult As DialogResult = m_FolderBrowserDialog1.ShowDialog
        If oresult = DialogResult.OK Then
            tbFolder.Text = m_FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub tbGenerer_Click(sender As Object, e As EventArgs) Handles tbGenerer.Click
        Dim oReglagePulve As New ParamReglagePulve
        Dim oUser As New RPUser()
        oUser.Code = ""
        oUser.setPassword("")
        oUser.setDateExp(dtExpiration.Value)
        oReglagePulve.coluser.Add(oUser)

        ParamReglagePulve.XMLFileName = "zsxedc.crodip"
        ParamReglagePulve.GenerateXML(tbFolder.Text, oReglagePulve)
        Me.Close()

    End Sub

    Private Sub tbAnnuler_Click(sender As Object, e As EventArgs) Handles tbAnnuler.Click
        Me.Close()
    End Sub
End Class