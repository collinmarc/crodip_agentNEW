Imports System.IO.Ports
Imports System.Timers

Public Class GPSManager
    ' Attribut GPSActif
    Private _GPSActif As Boolean
    Public Property GPSActif As Boolean
        Get
            Return _GPSActif
        End Get
        Set(value As Boolean)
            If _GPSActif <> value Then
                _GPSActif = value
                If _GPSActif Then
                    RaiseEvent GPSActifEvent(Me, EventArgs.Empty)
                End If
            End If
        End Set
    End Property

    ' Événement GPSActifEvent
    Public Event GPSActifEvent As EventHandler

    ' Timer pour enregistrer les données toutes les millisecondes
    Private WithEvents timer As Timer

    ' Distance et temps écoulé
    Public distance As Double
    '    Public elapsedTime As TimeSpan
    '   Private startTime As DateTime

    ' Dernières coordonnées GPS
    Public lastLatitude As Double
    Public lastLongitude As Double

    ' Port série pour la lecture des données GPS
    Private serialPort As SerialPort

    ' Constructeur
    Public Sub New()
        ' Initialement, le GPS est inactif
        GPSActif = False
        distance = 0.0
        '        elapsedTime = TimeSpan.Zero

        ' Initialiser le Timer
        timer = New Timer(1)
        AddHandler timer.Elapsed, AddressOf OnTimedEvent

        ' Configurer le port série
        serialPort = New SerialPort()
        AddHandler serialPort.DataReceived, AddressOf OnSerialDataReceived
    End Sub

    ' Méthode pour configurer le port série
    Public Sub ConfigurerPortSerie(portName As String, baudRate As Integer)
        If serialPort.IsOpen Then
            serialPort.Close()
        End If
        serialPort.PortName = portName
        serialPort.BaudRate = baudRate
    End Sub

    ' Méthode pour activer le GPS
    Public Sub ActiverGPS()
        GPSActif = True
        '        startTime = DateTime.Now
        serialPort.Open()
        timer.Start()
    End Sub

    ' Méthode pour désactiver le GPS
    Public Sub DesactiverGPS()
        GPSActif = False
        timer.Stop()
        serialPort.Close()
    End Sub

    ' Méthode Ecoute() qui enregistre la distance et le temps écoulé
    Public Sub Ecoute()
        If GPSActif Then
            ' Enregistrer la distance et le temps écoulé
            '            elapsedTime = DateTime.Now - startTime
        End If
    End Sub

    ' Gestionnaire d'événements pour le Timer
    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        Ecoute()
        ' Afficher les données pour vérification (peut être enlevé pour l'utilisation réelle)
        Console.WriteLine($"Distance: {distance} mètres")
    End Sub

    ' Gestionnaire d'événements pour les données série reçues
    Private Sub OnSerialDataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Dim serialData As String = serialPort.ReadExisting()
        ProcessNMEAData(serialData)
    End Sub

    ' Méthode pour traiter les données NMEA
    Private Sub ProcessNMEAData(data As String)
        ' Processus de traitement des données NMEA
        ' Exemple simplifié pour extraire et afficher les données NMEA GPGGA ou GPRMC
        Dim lines As String() = data.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        For Each line As String In lines
            If line.StartsWith("$GPGGA") OrElse line.StartsWith("$GPRMC") Then
                Dim nmeaFields As String() = line.Split(","c)
                If nmeaFields.Length > 0 Then
                    Select Case nmeaFields(0)
                        Case "$GPGGA"
                            ProcessGPGGA(nmeaFields)
                        Case "$GPRMC"
                            ProcessGPRMC(nmeaFields)
                    End Select
                End If
            End If
        Next
    End Sub

    ' Méthode pour traiter les données GPGGA
    Private Sub ProcessGPGGA(fields As String())
        Dim typePositionnement As String = fields(6) '0=invalide,1 = GPS, 2=GPS Différentiel, 4 = PPS
        Dim NbreSatelittes As String = fields(7)
        If typePositionnement = "1" Then

            ' Extraction de la latitude et de la longitude
            Dim latitude As Double = ConvertToDecimalDegrees(fields(2), fields(3))
            Dim longitude As Double = ConvertToDecimalDegrees(fields(4), fields(5))

            ' Calculer la distance parcourue
            If lastLatitude <> 0 AndAlso lastLongitude <> 0 Then
                distance += CalculateDistance(lastLatitude, lastLongitude, latitude, longitude)
            End If

            ' Mettre à jour les dernières coordonnées
            lastLatitude = latitude
            lastLongitude = longitude
        Else
            Console.Write("Trame incorrecte:" & fields.ToString())
        End If
    End Sub

    ' Méthode pour traiter les données GPRMC
    Private Sub ProcessGPRMC(fields As String())
        ' Extraction de l'heure et de la date
        Dim timeStr As String = fields(1)
        Dim dateStr As String = fields(9)

        Dim etatDonnees As String = fields(2) 'A=données valides, b=Données invalides
        If etatDonnees = "A" Then
            Dim dateTimeStr As String = dateStr & " " & timeStr
            Dim dateTime As DateTime
            'If DateTime.TryParseExact(dateTimeStr, "ddMMyy HHmmss.fff", Nothing, Globalization.DateTimeStyles.None, dateTime) Then
            'elapsedTime = dateTime - startTime
            'End If

            ' Extraction de la latitude et de la longitude
            Dim latitude As Double = ConvertToDecimalDegrees(fields(3), fields(4))
            Dim longitude As Double = ConvertToDecimalDegrees(fields(5), fields(6))

            ' Calculer la distance parcourue
            If lastLatitude <> 0 AndAlso lastLongitude <> 0 Then
                distance += CalculateDistance(lastLatitude, lastLongitude, latitude, longitude)
            End If

            ' Mettre à jour les dernières coordonnées
            lastLatitude = latitude
            lastLongitude = longitude
        Else
            Console.Write("Données invalides" & fields.ToString())
        End If
    End Sub

    ' Convertir les coordonnées en degrés décimaux
    Private Function ConvertToDecimalDegrees(value As String, direction As String) As Double
        Dim degrees As Double = Convert.ToDouble(value.Substring(0, 2))
        Dim minutes As Double = Convert.ToDouble(value.Substring(0, 2)) / 60
        Dim decimalDegrees As Double = degrees + minutes
        If direction = "S" OrElse direction = "W" Then
            decimalDegrees *= -1
        End If
        Return decimalDegrees
    End Function

    ' Calculer la distance entre deux points GPS en mètres
    Private Function CalculateDistance(lat1 As Double, lon1 As Double, lat2 As Double, lon2 As Double) As Double
        Dim R As Double = 6371 ' Rayon de la Terre en kilomètres
        Dim dLat As Double = (lat2 - lat1) * (Math.PI / 180)
        Dim dLon As Double = (lon2 - lon1) * (Math.PI / 180)
        Dim a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                          Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) *
                          Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        Dim distanceKm As Double = R * c
        Dim distanceMeters As Double = distanceKm * 1000
        Return distanceMeters
    End Function
    ' Méthode pour trouver le port série sur lequel est branchée l'antenne GPS
    Public Function TrouverPortGPS() As String
        For Each portName As String In SerialPort.GetPortNames()
            Try
                Using testPort As New SerialPort(portName, 9600)
                    testPort.Open()
                    ' Lire pendant une courte période pour vérifier les trames NMEA
                    Dim start As DateTime = DateTime.Now
                    While (DateTime.Now - start).TotalSeconds < 2
                        Dim data As String = testPort.ReadExisting()
                        If data.Contains("$GPGGA") OrElse data.Contains("$GPRMC") Then
                            Return portName
                        End If
                    End While
                End Using
            Catch ex As Exception
                ' Ignorer les exceptions pour les ports non valides
            End Try
        Next
        Return Nothing
    End Function
End Class
