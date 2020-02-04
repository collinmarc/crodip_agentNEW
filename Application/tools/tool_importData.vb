Imports System.Windows.Forms

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
        Cursor = Cursors.WaitCursor
        Dim FileName As String
        FileName = TextBox1.Text
        If System.IO.File.Exists(FileName) Then
            importer(FileName)
            OK_Button.Enabled = True
            TextBox1.Text = ""
        End If
        Cursor = Cursors.Default


    End Sub

    Private Sub importer(pfileNAme As String)
        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import(pfileNAme, m_oAgent)
        m_bsImportResult.Clear()
        m_bsImportResult.Add(oResult)
    End Sub

    Private Sub OK_Button_Click_1(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.Close()
    End Sub
End Class
