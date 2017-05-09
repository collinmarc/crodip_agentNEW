Public Class frmCRODIP
    Inherits Form

    Public Sub initWindowsProperties()
        'Propriété à mettre obligatoirement par programme dans le Lod (Bug windows ?)
        Me.WindowState = FormWindowState.Maximized
        Me.ControlBox = False
        '--
    End Sub

    Private Sub frmCRODIP_Load(sender As Object, e As EventArgs) Handles Me.Load
        initWindowsProperties()
    End Sub
End Class