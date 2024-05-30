Imports System.IO.Ports

Module Module3

    Public Sub Main3()
        ' Obtenir tous les ports série disponibles
        Dim ports As String() = SerialPort.GetPortNames()
        Console.WriteLine("Ports série disponibles : " & String.Join(", ", ports))

        For Each portName In ports
            If TestPortForGPS(portName) Then
                Console.WriteLine($"Antenne GPS trouvée sur le port {portName}.")
                Exit For
            End If
        Next

        Console.WriteLine("Appuyez sur Entrée pour quitter.")
        Console.ReadLine()
    End Sub

    Function TestPortForGPS(portName As String) As Boolean
        Dim serialPort As New SerialPort(portName, 9600)
        Dim isGPSThroughPort As Boolean = False

        Try
            ' Configurer le port série et ouvrir
            serialPort.Open()
            Console.WriteLine($"Port {portName} ouvert. Vérification des données...")

            ' Lire les données pendant un certain temps
            Dim startTime As DateTime = DateTime.Now
            While (DateTime.Now - startTime).TotalSeconds < 5 ' Attendre 5 secondes pour les données
                If serialPort.BytesToRead > 0 Then
                    Dim indata As String = serialPort.ReadExisting()
                    If indata.Contains("$GPGGA") Or indata.Contains("$GPRMC") Then
                        ' Données NMEA GPS trouvées
                        isGPSThroughPort = True
                        Exit While
                    End If
                End If
            End While
        Catch ex As Exception
            Console.WriteLine($"Erreur à l'ouverture du port {portName}: {ex.Message}")
        Finally
            If serialPort.IsOpen Then
                serialPort.Close()
            End If
        End Try

        Return isGPSThroughPort
    End Function

End Module
