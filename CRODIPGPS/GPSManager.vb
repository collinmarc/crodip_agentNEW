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
                '                If _GPSActif Then
                '               RaiseEvent GPSActifEvent(Me, EventArgs.Empty)
                '          End If
            End If
        End Set
    End Property

    ' Événement GPSActifEvent
    '    Public Event GPSActifEvent As EventHandler

    ' Distance et temps écoulé
    Public distance As Double
    '    Public elapsedTime As TimeSpan
    '   Private startTime As DateTime

    ' Dernières coordonnées GPS
    Public startLatitude As Double
    Public startLongitude As Double
    Public Latitude As Double
    Public Longitude As Double

    ' Port série pour la lecture des données GPS
    Private serialPort As SerialPort

    ' Constructeur
    Public Sub New()
        ' Initialement, le GPS est inactif
        GPSActif = False
        distance = 0.0
        '        elapsedTime = TimeSpan.Zero

        ' Initialiser le Timer
        'timer = New Timer(1)
        'AddHandler timer.Elapsed, AddressOf OnTimedEvent

        ' Configurer le port série
        serialPort = New SerialPort()
        AddHandler serialPort.DataReceived, AddressOf OnSerialDataReceived
    End Sub

    ' Méthode pour configurer le port série
    Public Sub ConfigurerPortSerie(portName As String, baudRate As Integer)
        serialPort.PortName = portName
        serialPort.BaudRate = baudRate
        If Not serialPort.IsOpen Then
            serialPort.Open()
        End If
    End Sub


    ' Méthode pour désactiver le GPS
    Public Sub DesactiverGPS()
        GPSActif = False
        '        timer.Stop()
        serialPort.Close()
    End Sub
    Public Sub StartMesure()
        startLatitude = 0
        startLongitude = 0
    End Sub

    ' Gestionnaire d'événements pour les données série reçues
    Private Sub OnSerialDataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Dim serialData As String = serialPort.ReadExisting()
        TraceMsg(serialData)
        Dim breturn As Boolean
        breturn = ProcessNMEAData(serialData)
        If breturn And Not GPSActif Then
            'Déclarer le GPS Actif
            GPSActif = True
        End If
    End Sub

    ' Méthode pour traiter les données NMEA
    Private Function ProcessNMEAData(data As String) As Boolean
        ' Processus de traitement des données NMEA
        ' Exemple simplifié pour extraire et afficher les données NMEA GPGGA ou GPRMC
        Dim breturn As Boolean = False
        Dim lines As String() = data.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        For Each line As String In lines
            If line.StartsWith("$GPGGA") OrElse line.StartsWith("$GPRMC") Then
                Dim nmeaFields As String() = line.Split(","c)
                If nmeaFields.Length > 0 Then
                    Select Case nmeaFields(0)
                        Case "$GPGGA"
                            breturn = ProcessGPGGA(nmeaFields)
                        Case "$GPRMC"
                            breturn = ProcessGPRMC(nmeaFields)
                    End Select
                End If
            End If
        Next
        Return breturn
    End Function

    ' Méthode pour traiter les données GPGGA
    Private Function ProcessGPGGA(fields As String()) As Boolean
        Dim typePositionnement As String = fields(6) '0=invalide,1 = GPS, 2=GPS Différentiel, 4 = PPS
        Dim NbreSatelittes As String = fields(7)
        Dim bReturn As Boolean
        Try
            TraceMsg("[ProcessGPGGA]TypePositionnement=" & typePositionnement)
            TraceMsg("[ProcessGPGGA]nbSattelites=" & NbreSatelittes)
            If typePositionnement = "1" Then

                ' Extraction de la latitude et de la longitude
                TraceMsg("[ProcessGPGGA]Latitude1=" & fields(2) & fields(3))
                TraceMsg("[ProcessGPGGA]Longitude1=" & fields(4) & fields(5))
                Dim latitude As Double = ConvertToDecimalDegrees(fields(2), fields(3))
                Dim longitude As Double = ConvertToDecimalDegrees(fields(4), fields(5))

                ' Calculer la distance parcourue
                distance = CalculateDistance(latitude, longitude)

                TraceMsg("[ProcessGPGGA] Start=(" & startLatitude & ";" & startLongitude & ") Lue=(" & latitude & ";" & longitude & ") Distance=" & distance)
                bReturn = True
            Else
                TraceMsg("Trame incorrecte:" & fields.ToString())
                bReturn = False
            End If
        Catch ex As Exception
            TraceMsg("GPSManager.ProcessGPGGA ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Méthode pour traiter les données GPRMC
    Private Function ProcessGPRMC(fields As String()) As Boolean
        ' Extraction de l'heure et de la date
        Dim timeStr As String = fields(1)
        Dim dateStr As String = fields(9)
        Dim etatDonnees As String = fields(2) 'A=données valides, b=Données invalides
        Dim bReturn As Boolean
        Try
            TraceMsg("[ProcessGPRMC]etatdonnees=" & etatDonnees)

            If etatDonnees = "A" Then
                Dim dateTimeStr As String = dateStr & " " & timeStr
                'If DateTime.TryParseExact(dateTimeStr, "ddMMyy HHmmss.fff", Nothing, Globalization.DateTimeStyles.None, dateTime) Then
                'elapsedTime = dateTime - startTime
                'End If

                ' Extraction de la latitude et de la longitude
                Dim latitude As Double = ConvertToDecimalDegrees(fields(3), fields(4))
                Dim longitude As Double = ConvertToDecimalDegrees(fields(5), fields(6))

                ' Calculer la distance parcourue
                distance = CalculateDistance(latitude, longitude)

                ' Mettre à jour les dernières coordonnées
                TraceMsg("[ProcessGPRMC] Start=(" & startLatitude & ";" & startLongitude & ") Lue=(" & latitude & ";" & longitude & ") Distance=" & distance)
                bReturn = True
            Else
                TraceMsg("Données invalides" & fields.ToString())
                bReturn = False
            End If
        Catch ex As Exception
            TraceMsg("GPSManager.ProcessGPRMC ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function

    ' Convertir les coordonnées en degrés décimaux
    Private Function ConvertToDecimalDegrees(degreesMinutes As String, direction As String) As Double
        Dim dotIndex As Integer = degreesMinutes.IndexOf("."c)
        Dim degrees As Double = Convert.ToDouble(degreesMinutes.Substring(0, dotIndex - 2))
        Dim minutes As Double = Convert.ToDouble(degreesMinutes.Substring(dotIndex - 2).Replace(".", ","))
        Dim seconds As Double = Convert.ToDouble(degreesMinutes.Substring(dotIndex + 2).Replace(".", ",")) * 60 / 10000
        '        Dim decimalDegrees As Double = degrees + (minutes / 60) + (seconds / 3600)
        Dim decimalDegrees As Double = degrees + (minutes / 60)
        If direction = "S" OrElse direction = "W" Then
            decimalDegrees *= -1
        End If
        Return decimalDegrees
    End Function

    ' Calculer la distance entre deux points GPS en mètres
    Private Function CalculateDistance(lat2 As Double, lon2 As Double) As Double
        Dim distanceMeters As Double = 0D
        If startLatitude = 0 And startLongitude = 0 Then
            startLatitude = lat2
            startLongitude = lon2
        Else
            Latitude = lat2
            Longitude = lon2
            Dim R As Double = 6371 ' Rayon de la Terre en kilomètres
            Dim dLat As Double = (lat2 - startLatitude) * (Math.PI / 180)
            Dim dLon As Double = (lon2 - startLongitude) * (Math.PI / 180)
            Dim a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                              Math.Cos(startLatitude * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) *
                              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
            Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
            Dim distanceKm As Double = R * c
            distanceMeters = distanceKm * 1000
        End If

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
                            testPort.Close()
                            GPSActif = True
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
    Private Sub TraceMsg(pMessage As String)
        Console.WriteLine(pMessage)
        System.IO.File.AppendAllText("./GPS.LOG", pMessage & vbCrLf)
    End Sub
    Public Function IsSerialPortOpen() As Boolean
        Return serialPort.IsOpen
    End Function
    Public ReadOnly Property PositionDepart() As String

        Get
            Return startLatitude & "," & startLongitude
        End Get
    End Property
    Public ReadOnly Property PositionArrivee() As String

        Get
            Return Latitude & "," & Longitude
        End Get
    End Property
End Class
