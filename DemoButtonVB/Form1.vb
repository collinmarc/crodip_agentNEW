Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AfficheFenetre()
    End Sub
    Private Sub AfficheFenetre()
        Dim penDataType As Integer
        Dim penTimeData As List(Of wgssSTU.IPenDataTimeCountSequence) = Nothing
        Dim penData As List(Of wgssSTU.IPenData) = Nothing
        Dim usbDevices As wgssSTU.UsbDevices = New wgssSTU.UsbDevices()

        If usbDevices.Count <> 0 Then

            Try
                Dim usbDevice As wgssSTU.IUsbDevice = usbDevices(0)
                Dim demo As SignatureForm = New SignatureForm(usbDevice, False)
                demo.ShowDialog()


                demo.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("No STU devices attached")
        End If
    End Sub
End Class
