Public Class frmLoadCtrlCRODIP

    Public m_oDiag As RPDiagnostic
    Public NumCTRL As String
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim oRPDiag As RPDiagnostic
        If tbNumCtrl.Text <> "" Then
            NumCTRL = tbNumCtrl.Text
            DialogResult = vbOK
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = vbCancel
        Close()

    End Sub
End Class