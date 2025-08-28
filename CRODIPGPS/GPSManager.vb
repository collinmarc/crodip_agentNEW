Imports System.Globalization
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
    Public startTime As DateTime
    Public EndTime As DateTime
    Public startLatitude As Double
    Public startLongitude As Double
    Public Latitude As Double
    Public Longitude As Double

    Private QLatt As New Queue(Of Double)
    Private QLong As New Queue(Of Double)

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
        init()
    End Sub

    ' Gestionnaire d'événements pour les données série reçues
    Private Sub OnSerialDataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Dim serialData As String = serialPort.ReadExisting()
        '        TraceMsg(serialData)
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
                            If My.Settings.ProcessGPGGA Then
                                TraceMsg(data)
                                breturn = ProcessGPGGA(nmeaFields)
                            End If
                        Case "$GPRMC"
                            If My.Settings.ProcessGPRMC Then
                                TraceMsg(data)
                                breturn = ProcessGPRMC(nmeaFields)
                            End If
                    End Select
                End If
            End If
        Next
        Return breturn
    End Function

    ' Méthode pour traiter les données GPGGA
    Private Function ProcessGPGGA(fields As String()) As Boolean
        Dim heureGPS As String = fields(1) 'Date et heure de la trame GPS
        Dim typePositionnement As String = fields(6) '0=invalide,1 = GPS, 2=GPS Différentiel, 4 = PPS
        Dim NbreSatelites As String = fields(7)
        Dim PrecisHorizontale As String = fields(8)
        Dim bReturn As Boolean
        Try
            TraceMsg("[ProcessGPGGA]TypePositionnement=" & typePositionnement)
            TraceMsg("[ProcessGPGGA]nbSattelites=" & NbreSatelites)
            TraceMsg("[ProcessGPGGA]HDOP=" & PrecisHorizontale)
            If typePositionnement = "1" Then
                If CInt(NbreSatelites) > My.Settings.NbSatellitesMin Then
                    If CDec(PrecisHorizontale.Replace(".", ",")) < My.Settings.HDOPMax Then
                        ' Extraction de la latitude et de la longitude
                        TraceMsg("[ProcessGPGGA]Latitude1=" & fields(2) & fields(3))
                        TraceMsg("[ProcessGPGGA]Longitude1=" & fields(4) & fields(5))
                        Dim latitude As Double = ConvertToDecimalDegrees(fields(2), fields(3))
                        Dim longitude As Double = ConvertToDecimalDegrees(fields(4), fields(5))
                        Dim latitudeM As Double = LattMoyenne(latitude)
                        Dim longitudeM As Double = LongMoyenne(longitude)


                        ' Calculer la distance parcourue
                        distance = CalculateDistance(heureGPS, latitudeM, longitudeM)

                        TraceMsg("[ProcessGPGGA] Start=(" & startLatitude & ";" & startLongitude & ") Lue=(" & latitudeM & ";" & longitudeM & ") Distance=" & distance)
                        bReturn = True
                    Else
                        TraceMsg("Précision Horizontale Trop faible:" & fields.ToString())
                    End If
                Else
                    TraceMsg("Nbre de satellites incorrect:" & fields.ToString())
                End If

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
    Private Function LattMoyenne(pLatt As Double) As Double
        QLatt.Enqueue(pLatt)
        If QLatt.Count > 10 Then
            QLatt.Dequeue()
        End If
        Return QLatt.Average()
    End Function
    Private Function LongMoyenne(pLong As Double) As Double
        QLong.Enqueue(pLong)
        If QLong.Count > 10 Then
            QLong.Dequeue()
        End If
        Return QLong.Average()
    End Function

    ' Méthode pour traiter les données GPRMC
    Private Function ProcessGPRMC(fields As String()) As Boolean
        ' Extraction de l'heure et de la date
        Dim heureGPS As String = fields(1)
        Dim dateStr As String = fields(9)
        Dim etatDonnees As String = fields(2) 'A=données valides, b=Données invalides
        Dim bReturn As Boolean
        Try
            TraceMsg("[ProcessGPRMC]etatdonnees=" & etatDonnees)

            If etatDonnees = "A" Then
                ' Extraction de la latitude et de la longitude
                TraceMsg("[ProcessGPRMC]Latitude1=" & fields(3) & fields(4))
                TraceMsg("[ProcessGPRMC]Longitude1=" & fields(5) & fields(6))
                ' Conversion en decimal
                Dim latitude As Double = ConvertToDecimalDegrees(fields(3), fields(4))
                Dim longitude As Double = ConvertToDecimalDegrees(fields(5), fields(6))

                ' Calculer la distance parcourue
                distance = CalculateDistance(heureGPS, latitude, longitude)

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
    Function ConvertGPSTimeToDateTime(gpggaTime As String) As DateTime
        Dim dReturn As DateTime
        ' Vérifier que la chaîne a le bon format
        If gpggaTime.Length < 6 Then

            ' Extraire les composants de l'heure
            Dim hours As Integer = Integer.Parse(gpggaTime.Substring(0, 2))
            Dim minutes As Integer = Integer.Parse(gpggaTime.Substring(2, 2))
            Dim seconds As Double = Double.Parse(gpggaTime.Substring(4), CultureInfo.InvariantCulture)

            ' Créer un objet DateTime avec l'heure extraite
            Dim dateTime As DateTime = New DateTime(1, 1, 1, hours, minutes, 0)
            dReturn = dateTime.AddSeconds(seconds)
        Else
            dReturn = DateTime.Now()
        End If
        ' Retourner l'objet DateTime
        Return dReturn
    End Function
    ' Calculer la distance entre deux points GPS en mètres
    Private Function CalculateDistance(pTimeGPS As String, pEndLat As Double, pEndLong As Double) As Double
        Dim distanceMeters As Double = 0D
        If startLatitude = 0 And startLongitude = 0 Then
            Me.startTime = ConvertGPSTimeToDateTime(pTimeGPS)
            Me.startLatitude = pEndLat
            Me.startLongitude = pEndLong
            Me.EndTime = ConvertGPSTimeToDateTime(pTimeGPS)
            Me.Latitude = pEndLat
            Me.Longitude = pEndLong
        Else
            Me.EndTime = ConvertGPSTimeToDateTime(pTimeGPS)
            Me.Latitude = pEndLat
            Me.Longitude = pEndLong
            Dim R As Double = 6371 ' Rayon de la Terre en kilomètres
            ' Convertir les degrés en radians
            Dim lat1 As Double = startLatitude * Math.PI / 180.0
            Dim lon1 As Double = startLongitude * Math.PI / 180.0
            Dim lat2 As Double = pEndLat * Math.PI / 180.0
            Dim lon2 As Double = pEndLong * Math.PI / 180.0

            ' Différence de latitude et de longitude
            Dim dDiffLat As Double = (pEndLat - startLatitude) * Math.PI / 180.0
            Dim dDiffLon As Double = (pEndLong - startLongitude) * Math.PI / 180.0

            ' Formule de Haversine
            Dim a As Double = Math.Sin(dDiffLat / 2) * Math.Sin(dDiffLat / 2) +
                      Math.Cos(lat1) * Math.Cos(lat2) *
                      Math.Sin(dDiffLon / 2) * Math.Sin(dDiffLon / 2)

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
                    If My.Settings.ActiveSBAS_GPS Then
                        ' UBX-CFG-SBAS : activer SBAS (WAAS/EGNOS)
                        ' Trame binaire UBX (exemple pour u-blox 7/8)
                        'ChatGPT 28/08/2025
                        Dim enableSBAS() As Byte = {
            &HB5, &H62, &H6, &H16, &H8, &H0,
            &H1, &H0, &H1, &H0, &H1, &H0, &H1, &H0,
            &H27, &H1E
        }

                        testPort.Write(enableSBAS, 0, enableSBAS.Length)
                        testPort.Close()
                        testPort.Open()
                    End If
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
    Public Sub init()
        Me.startLatitude = 0
        Me.startLongitude = 0
        Me.startTime = DateTime.MinValue
        Me.EndTime = DateTime.MinValue
    End Sub
End Class
