Imports System.Windows.Forms
Imports System.ComponentModel

Public Class tool_importData
    Private m_oAgent As Agent
    Public Sub setcontexte(pagent As Agent)
        m_oAgent = pagent
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub cbBrowse_Click(sender As Object, e As EventArgs) Handles cbBrowse.Click
        If m_opfdlg.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = m_opfdlg.FileName
        End If
    End Sub

    Private Sub btnimportClick_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim FileName As String
        FileName = TextBox1.Text
        If System.IO.File.Exists(FileName) Then
            Cursor = Cursors.WaitCursor
            BackgroundWorker1.RunWorkerAsync(FileName)
        End If

    End Sub
    Private oResult As importCRODIP.ImportCrodipResult
    Public Sub importer(pfileNAme As String)
        oResult = importCRODIP.import(pfileNAme, m_oAgent, BackgroundWorker1)
    End Sub

    Private Sub OK_Button_Click_1(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim FileName As String
        FileName = e.Argument.ToString()
        importer(FileName)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MsgBox("Import terminé")
        m_bsImportResult.Clear()
        m_bsImportResult.Add(oResult)
        TextBox1.Text = ""
        Cursor = Cursors.Default
        OK_Button.Enabled = True
    End Sub

    Private Sub btn_AnnulerImport_Click(sender As Object, e As EventArgs) Handles btn_AnnulerImport.Click
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Dim ctrl As LinkLabel = sender
            System.Diagnostics.Process.Start(ctrl.Text)

        Catch

        End Try
    End Sub
End Class
