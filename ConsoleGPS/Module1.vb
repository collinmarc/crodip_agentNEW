Imports System.Device.Location

Module Module1

    Sub Main1()
        ' Crée une nouvelle instance de GeoCoordinateWatcher
        Dim watcher As New GeoCoordinateWatcher()

        ' Abonnez-vous à l'événement StatusChanged
        AddHandler watcher.StatusChanged, AddressOf Watcher_StatusChanged

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
                Console.WriteLine("Le service de localisation est prêt. Une antenne GPS pourrait être branchée.")
        End Select
    End Sub

End Module
