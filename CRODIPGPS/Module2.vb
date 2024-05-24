Imports System.Device.Location

Module Module2

    Sub Main()
        ' Crée une nouvelle instance de GeoCoordinateWatcher
        Dim watcher As New GeoCoordinateWatcher()

        ' Abonnez-vous aux événements StatusChanged et PositionChanged
        AddHandler watcher.StatusChanged, AddressOf Watcher_StatusChanged
        AddHandler watcher.PositionChanged, AddressOf Watcher_PositionChanged

        ' Démarrer l'observateur
        watcher.Start()

        ' Empêche l'application de se fermer immédiatement
        Console.WriteLine("Appuyez sur Entrée pour quitter.")
        Console.ReadLine()
    End Sub

    ' Gérer l'événement StatusChanged
    Private Sub Watcher_StatusChanged(ByVal sender As Object, ByVal e As GeoPositionStatusChangedEventArgs)
        Select Case e.Status
            Case GeoPositionStatus.Disabled
                Console.WriteLine("Le service de localisation est désactivé.")
            Case GeoPositionStatus.Initializing
                Console.WriteLine("Le service de localisation est en cours d'initialisation.")
            Case GeoPositionStatus.NoData
                Console.WriteLine("Aucune donnée de localisation disponible.")
            Case GeoPositionStatus.Ready
                Console.WriteLine("Le service de localisation est prêt.")
        End Select
    End Sub

    ' Gérer l'événement PositionChanged
    Private Sub Watcher_PositionChanged(ByVal sender As Object, ByVal e As GeoPositionChangedEventArgs(Of GeoCoordinate))
        If Not e.Position.Location.IsUnknown Then
            Dim coord As GeoCoordinate = e.Position.Location
            Console.WriteLine($"Latitude : {coord.Latitude}, Longitude : {coord.Longitude}, Précision : {coord.HorizontalAccuracy} mètres")
        Else
            Console.WriteLine("La position est inconnue.")
        End If
    End Sub

End Module
