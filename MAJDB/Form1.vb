Imports Crodip_agent
Imports CRODIPWS
Imports System.Data.Common
Imports System.Data.OleDb
Public Class frmMAJDB
    Private Sub btnExec_Click(sender As Object, e As EventArgs) Handles btnExec.Click
        Dim ocsDB As CSDb
        Dim oReader As DbDataReader
        Try
            Me.Cursor = Cursors.WaitCursor
            ocsDB = New CSDb()
            ocsDB.getInstance()
            oReader = ocsDB.getResult2s(tbSQL.Text)
            Dim oBS As BindingSource = New BindingSource(oReader, Nothing)

            dgvResult.DataSource = oBS
            dgvResult.Show()
            ocsDB.free()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub frmMAJDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oCSDB As New CSDb()
        Me.Text = Me.Text & "[" & oCSDB.getbddPathName() & "]"
        oCSDB.free()
    End Sub

    Private Sub dgvResult_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResult.DataError

    End Sub


End Class
