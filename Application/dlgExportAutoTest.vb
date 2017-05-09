Imports System.Windows.Forms

Public Class dlgExportAutoTest

    Public Function getDateDeb() As Date
        Return dtp_Ddeb.Value
    End Function
    Public Function getDateFin() As Date
        Return dtpDFin.Value
    End Function

    Public Function getFileName() As String
        Return tbFilePath.Text
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgExportAutoTest_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged

    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        SaveFileDialog1.FileName = System.IO.Path.GetFileName(tbFilePath.Text)
        SaveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(tbFilePath.Text)
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            tbFilePath.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub dlgExportAutoTest_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Insertion du répertoire courant
        tbFilePath.Text = System.Environment.CurrentDirectory & "/" & My.Settings.AutoTestDefaultFileName
    End Sub
End Class
