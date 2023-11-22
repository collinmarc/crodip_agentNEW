Public Class FrmMigrationBDD
    Dim bFini As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If bFini Then
            If Not BackgroundWorker1.CancellationPending Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = DialogResult.Abort
            End If
        Else
            Me.Cursor = Cursors.WaitCursor
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim oBDD As New BDDTransfert() With {.bgw = BackgroundWorker1}

        Crodip_agent.CSDebug.dispInfo("BDDTransfert Start")
        If Not BackgroundWorker1.CancellationPending Then
            Crodip_agent.CSDebug.dispInfo("Diagnostic")
            BackgroundWorker1.ReportProgress(170, "Diagnostic")
            oBDD.TransfertDiagnosticALL()
        End If

        Crodip_agent.CSDebug.dispInfo("BDDTransfert End")
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try

            If e.ProgressPercentage <= 100 Then
                Me.ProgressBarN2.Value = e.ProgressPercentage
                lblProgressN2.Text = e.UserState
            Else
                Me.ProgressBarN1.Value = e.ProgressPercentage - 100
                lblProgressN1.Text = e.UserState

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Me.ProgressBarN2.Value = Me.ProgressBarN2.Maximum
            lblProgressN2.Text = "Transfert Terminé"
            Me.Button1.Text = "Poursuivre"
            Me.Cursor = Cursors.Default
            bFini = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
        End If

    End Sub
End Class
