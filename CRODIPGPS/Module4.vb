Module Module4
    Public Sub Main()
        Dim gpsManager As New GPSManager()
    Dim portName As String = gpsManager.TrouverPortGPS()

        If portName IsNot Nothing Then
            gpsManager.ConfigurerPortSerie(portName, 9600)
            gpsManager.ActiverGPS()
            Console.WriteLine("GPS activé sur le port " & portName)
        Else
            Console.WriteLine("Antenne GPS non trouvée.")
        End If
    End Sub

End Module
