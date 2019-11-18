Public Class frmMAJVersion
    Public Sub Setcontexte(pUpdateInfo As UpdateInfo)
        m_bsUpdateInfo.Clear()
        m_bsUpdateInfo.Add(pUpdateInfo)
        WebBrowser1.DocumentText = pUpdateInfo.Contenu
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class