Imports System.IO.Ports

Module Module2

    Sub Main2()
        ' Nom du port série où l'antenne GPS G-MOUSE est connectée
        Dim portName As String = "COM4"

        ' Vitesse du port série (baud rate) pour G-MOUSE
        Dim baudRate As Integer = 9600

        ' Initialiser le port série
        Dim serialPort As New SerialPort(portName, baudRate)

        ' Configurer les événements et ouvrir le port
        AddHandler serialPort.DataReceived, AddressOf SerialPort_DataReceived
        Try
            serialPort.Open()
            Console.WriteLine($"Port {portName} ouvert. En attente des données de l'antenne GPS G-MOUSE...")
        Catch ex As Exception
            Console.WriteLine($"Erreur à l'ouverture du port {portName}: {ex.Message}")
            Return
        End Try

        ' Empêche l'application de se fermer immédiatement
        Console.WriteLine("Appuyez sur Entrée pour quitter.")
        Console.ReadLine()

        ' Fermer le port série à la fermeture de l'application
        If serialPort.IsOpen Then
            serialPort.Close()
        End If
    End Sub

    ' Gestionnaire de l'événement DataReceived
    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Dim sp As SerialPort = CType(sender, SerialPort)
        Dim indata As String = sp.ReadExisting()
        Console.WriteLine($"Données reçues : {indata}")

        ' Appeler la fonction de parsing pour analyser les données NMEA
        ParseNMEA(indata)
    End Sub

    ' Fonction pour analyser les données NMEA
    Private Sub ParseNMEA(ByVal data As String)
        Dim lines() As String = data.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        For Each line As String In lines
            If line.StartsWith("$GPGGA") Then
                Dim parts() As String = line.Split(","c)
                If parts.Length > 9 Then
                    ' Exemple de parsing des données GPGGA
                    Dim time As String = parts(1)
                    Dim latitude As String = ConvertToDecimalDegrees(parts(2), parts(3))
                    Dim longitude As String = ConvertToDecimalDegrees(parts(4), parts(5))
                    Dim fixQuality As String = parts(6)
                    Dim numSatellites As String = parts(7)
                    Dim altitude As String = parts(9) & " " & parts(10)

                    Console.WriteLine($"Time: {time}, Latitude: {latitude}, Longitude: {longitude}, Fix Quality: {fixQuality}, Satellites: {numSatellites}, Altitude: {altitude}")
                End If
            End If
        Next
    End Sub

    ' Fonction pour convertir les coordonnées NMEA en degrés décimaux
    Private Function ConvertToDecimalDegrees(ByVal coordinate As String, ByVal direction As String) As String
        Dim degrees As Double = Convert.ToDouble(coordinate.Substring(0, 2))
        Dim minutes As Double = Convert.ToDouble(coordinate.Substring(0,2)) / 60
        Dim decimalDegrees As Double = degrees + minutes

        If direction = "S" Or direction = "W" Then
            decimalDegrees *= -1
        End If

        Return decimalDegrees.ToString()
    End Function

End Module
