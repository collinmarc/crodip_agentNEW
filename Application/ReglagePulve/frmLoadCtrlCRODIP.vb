Public Class frmLoadCtrlCRODIP

    Public m_oDiag As RPDiagnostic
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim oDiag As RPDiagnostic
        oDiag = DiagnosticManager.getDiagnosticById(TextBox1.Text)
        m_oDiag = oDiag
    End Sub
End Class