Imports System.Device.Location
Imports System.Globalization
Imports System.IO.Ports
Imports System.Text

''' <summary>
''' Le GPSMAnager Fait l'interface avec l'antenne GPS
''' Il charge les données GPS à chaque notification et indique qu'il a des nouvelles données
''' 
''' </summary>
Public Class GPSManager
    ' Attribut GPSActif
    Private _GPSActif As Boolean
    Private _lstTracesGPX As List(Of String)
    Public Property GPSActif As Boolean
        Get
            Return _GPSActif
        End Get
        Set(value As Boolean)
            If _GPSActif <> value Then
                _GPSActif = value
            End If
        End Set
    End Property

    ' Distance et temps écoulé
    Public distance As Double
    '    Public elapsedTime As TimeSpan
    '   Private startTime As DateTime

    ' Dernières coordonnées GPS
    Public startTime As DateTime
    Public EndTime As DateTime
    Public startLatitude As String
    Public startLongitude As String
    Public Latitude As String
    Public Longitude As String


    ' Port série pour la lecture des données GPS
    Private serialPort As SerialPort

    ' Constructeur
    Public Sub New()
        ' Initialement, le GPS est inactif
        GPSActif = False
        distance = 0.0
        bDataUpdated = False

        ' Configurer le port série
        serialPort = New SerialPort()
        _lstTracesGPX = New List(Of String)
        init()
        AddHandler serialPort.DataReceived, AddressOf OnSerialDataReceived
    End Sub

    ' Méthode pour configurer le port série
    Public Sub ConfigurerPortSerie(portName As String, baudRate As Integer)
        serialPort.PortName = portName
        serialPort.BaudRate = baudRate
        serialPort.ReadTimeout = My.Settings.intervalGPS * 10

        If Not serialPort.IsOpen Then
            serialPort.Open()
        End If
        If My.Settings.ActiveSBAS_GPS Then
            ' UBX-CFG-SBAS : activer SBAS (WAAS/EGNOS)
            ' Trame binaire UBX (exemple pour u-blox 7/8)
            'ChatGPT 28/08/2025
            Dim enableSBAS() As Byte = {
            &HB5, &H62, &H6, &H16, &H8, &H0,
            &H1, &H0, &H1, &H0, &H1, &H0, &H1, &H0,
            &H27, &H1E
        }

            serialPort.Write(enableSBAS, 0, enableSBAS.Length)
            serialPort.Close()
            serialPort.Open()
        End If

    End Sub
    Public Sub Close()
        If serialPort.IsOpen Then
            RemoveHandler serialPort.DataReceived, AddressOf OnSerialDataReceived
            serialPort.Close()
        End If
    End Sub
    ' Gestionnaire d'événements pour les données série reçues
    Public Sub OnSerialDataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        If serialPort.IsOpen() Then
            Dim serialData As String
            Dim bContinue = True
            'Lecture du port Serie tant qu'il y a de la donnée
            While bContinue
                Try
                    serialData = serialPort.ReadLine() 'Utiliser un ReadLine plutot qu'un readexisting
                    Dim breturn As Boolean
                    breturn = ProcessNMEAData(serialData)
                    If breturn And Not GPSActif Then
                        'Déclarer le GPS Actif
                        GPSActif = True
                    End If
                    bContinue = False
                Catch ex As Exception
                    bContinue = False
                End Try
            End While
        Else
            Console.WriteLine("SerialPort Close")
        End If
    End Sub
    Public bDataUpdated As Boolean
    ' Méthode pour traiter les données NMEA
    Public Function ProcessNMEAData(data As String) As Boolean
        ' Processus de traitement des données NMEA
        ' Exemple simplifié pour extraire et afficher les données NMEA GPGGA/GNGGA ou GPRMC/ GNRMC 
        Dim breturn As Boolean = False
        Dim lines As String() = data.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        For Each line As String In lines
            If line.StartsWith("$GPGGA") OrElse line.StartsWith("$GPRMC") OrElse line.StartsWith("$GNGGA") OrElse line.StartsWith("$GNRMC") Then
                Dim nmeaFields As String() = line.Split(","c)
                If nmeaFields.Length > 9 Then
                    Select Case nmeaFields(0)
                        Case "$GPGGA", "$GNGGA"
                            If My.Settings.ProcessGPGGA Then
                                TraceMsg(line)
                                breturn = ProcessNMEA_GGA(nmeaFields)
                                If breturn Then
                                    _lstTracesGPX.Add(line)
                                End If
                            End If
                        Case "$GPRMC", "$GNRMC"
                            If My.Settings.ProcessGPRMC Then
                                TraceMsg(line)
                                breturn = ProcessNMEA_RMC(nmeaFields)
                            End If
                    End Select
                End If
                If breturn Then
                    'on signale une nouvelle donnée
                    bDataUpdated = True
                End If
            End If
        Next
        Return breturn
    End Function

    ' Méthode pour traiter les données GPGGA
    Private Function ProcessNMEA_GGA(fields As String()) As Boolean
        Dim heureGPS As String = fields(1) 'Date et heure de la trame GPS
        Dim typePositionnement As String = fields(6) '0=invalide,1 = GPS, 2=GPS Différentiel, 4 = PPS
        Dim NbreSatelites As String = fields(7)
        Dim PrecisHorizontale As String = fields(8)
        Dim bReturn As Boolean
        Try
            'TraceMsg("[ProcessGPGGA]TypePositionnement=" & typePositionnement)
            'TraceMsg("[ProcessGPGGA]nbSattelites=" & NbreSatelites)
            'TraceMsg("[ProcessGPGGA]HDOP=" & PrecisHorizontale)
            If typePositionnement = "1" Or typePositionnement = "2" Then
                If CInt(NbreSatelites) > My.Settings.NbSatellitesMin Then
                    If CDec(PrecisHorizontale.Replace(".", ",")) < My.Settings.HDOPMax Then
                        ' Extraction de la latitude et de la longitude
                        '           TraceMsg("[ProcessGPGGA]Latitude1=" & fields(2) & fields(3))
                        '          TraceMsg("[ProcessGPGGA]Longitude1=" & fields(4) & fields(5))
                        Dim slatitude As String = fields(2) & fields(3)
                        Dim slongitude As String = fields(4) & fields(5)


                        ' Calculer la distance parcourue
                        distance = CalculateDistance(heureGPS, slatitude, slongitude)

                        '         TraceMsg("[ProcessGPGGA] Start=(" & startLatitude & ";" & startLongitude & ") Lue=(" & latitudeM & ";" & longitudeM & ") Distance=" & distance)
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

    ' Méthode pour traiter les données GPRMC
    Private Function ProcessNMEA_RMC(fields As String()) As Boolean
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
                Dim latitudeM As String = fields(3) & fields(4)
                Dim longitudeM As String = fields(5) & fields(6)

                ' Calculer la distance parcourue
                distance = CalculateDistance(heureGPS, latitudeM, longitudeM)

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
    Private Shared Function ConvertToDecimalDegrees(degreesMinutes As String) As Double
        'Dim dotIndex As Integer = degreesMinutes.IndexOf("."c)
        Dim direction As String
        Dim coordinate As String
        Dim degrees As Double
        Dim minutes As Double
        direction = degreesMinutes.Last()
        coordinate = degreesMinutes.Substring(0, degreesMinutes.Length - 1).Replace(".", ",")
        'If direction = "S" OrElse direction = "N" Then
        '    'Latitude (00->90)
        '    degrees = Convert.ToDouble(degreesMinutes.Substring(0, 2))
        '    minutes = Convert.ToDouble(degreesMinutes.Substring(2).Replace(".", ","))
        'Else
        '    'Longitude (000->180)
        '    degrees = Convert.ToDouble(degreesMinutes.Substring(0, 3))
        '    minutes = Convert.ToDouble(degreesMinutes.Substring(3).Replace(".", ","))
        'End If

        'Dim decimalDegrees As Double = degrees + (minutes / 60)
        'If direction = "S" OrElse direction = "W" Then
        '    decimalDegrees *= -1
        'End If
        'Return decimalDegrees
        ' Convertir les coordonnées NMEA (DDMM.MMMM) en degrés décimaux
        degrees = Math.Floor(CDbl(coordinate) / 100)
        minutes = (CDbl(coordinate) - (degrees * 100)) / 60.0
        Dim decimalDegrees As Double = degrees + minutes

        ' Ajuster selon l'hémisphère
        If direction = "S" OrElse direction = "W" Then
            decimalDegrees *= -1
        End If

        Return decimalDegrees
    End Function
    Function ConvertGPSTimeToDateTime(gpggaTime As String) As DateTime
        Dim dReturn As DateTime
        ' Vérifier que la chaîne a le bon format
        If gpggaTime.Length = 9 Then

            ' Extraire les composants de l'heure
            Dim hours As Integer = Integer.Parse(gpggaTime.Substring(0, 2))
            Dim minutes As Integer = Integer.Parse(gpggaTime.Substring(2, 2))
            'Dim seconds As Double = Double.Parse(gpggaTime.Substring(4), CultureInfo.InvariantCulture)
            Dim seconds As Integer = Integer.Parse(gpggaTime.Substring(4, 2))

            ' Créer un objet DateTime avec l'heure extraite
            dReturn = New DateTime(1, 1, 1, hours, minutes, seconds)
        Else
            dReturn = DateTime.Now()
        End If
        ' Retourner l'objet DateTime
        Return dReturn
    End Function
    ' Calculer la distance entre deux points GPS en mètres
    Private Function CalculateDistance(pTimeGPS As String, pEndLat As String, pEndLong As String) As Double
        Dim distanceMeters As Double = 0D
        Dim GPSDate As DateTime
        GPSDate = ConvertGPSTimeToDateTime(pTimeGPS)
        If startLatitude = "" And startLongitude = "" Then
            Me.startTime = GPSDate
            Me.startLatitude = pEndLat
            Me.startLongitude = pEndLong
        End If

        Me.EndTime = GPSDate
        Me.Latitude = pEndLat
        Me.Longitude = pEndLong

        If My.Settings.CalculHaversine Then
            distanceMeters = CalculateDistanceHaversine(startLatitude, startLongitude, pEndLat, pEndLong)
        Else
            distanceMeters = CalculateDistance2(startLatitude, startLongitude, pEndLat, pEndLong)
        End If

        Return distanceMeters
    End Function
    Public Shared Function CalculateDistance2(pstartLatitude As String, pStartLongitude As String, pEndLat As String, pEndLong As String) As Double
        Dim pStartLatitude2 As Decimal = ConvertToDecimalDegrees(pstartLatitude)
        Dim pStartLongitude2 As Decimal = ConvertToDecimalDegrees(pStartLongitude)
        Dim pEndLatitude2 As Decimal = ConvertToDecimalDegrees(pEndLat)
        Dim pEndLongitude2 As Decimal = ConvertToDecimalDegrees(pEndLong)
        Dim StartCoord As New GeoCoordinate(pStartLatitude2, pStartLongitude2)
        Dim endCoord As New GeoCoordinate(pEndLatitude2, pEndLongitude2)
        Return StartCoord.GetDistanceTo(endCoord)
    End Function
    Public Shared Function CalculateDistanceHaversine(pstartLatitude As String, pStartLongitude As String, pEndLat As String, pEndLong As String) As Double
        Dim distanceMeters As Double
        Dim R As Double = 6371 ' Rayon de la Terre en kilomètres
        'Convertir Les Coordonnées GPS
        Dim pStartLatitude2 As Decimal = ConvertToDecimalDegrees(pstartLatitude)
        Dim pStartLongitude2 As Decimal = ConvertToDecimalDegrees(pStartLongitude)
        Dim pEndLatitude2 As Decimal = ConvertToDecimalDegrees(pEndLat)
        Dim pEndLongitude2 As Decimal = ConvertToDecimalDegrees(pEndLong)
        ' Convertir les degrés en radians
        Dim lat1 As Double = pStartLatitude2 * Math.PI / 180.0
        Dim lon1 As Double = pStartLongitude2 * Math.PI / 180.0
        Dim lat2 As Double = pEndLatitude2 * Math.PI / 180.0
        Dim lon2 As Double = pEndLongitude2 * Math.PI / 180.0

        ' Différence de latitude et de longitude
        Dim dDiffLat As Double = (pEndLatitude2 - pStartLatitude2) * Math.PI / 180.0
        Dim dDiffLon As Double = (pEndLongitude2 - pStartLongitude2) * Math.PI / 180.0

        ' Formule de Haversine
        Dim a As Double = Math.Sin(dDiffLat / 2) * Math.Sin(dDiffLat / 2) +
                  Math.Cos(lat1) * Math.Cos(lat2) *
                  Math.Sin(dDiffLon / 2) * Math.Sin(dDiffLon / 2)

        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))

        Dim distanceKm As Double = R * c
        distanceMeters = distanceKm * 1000

        Return distanceMeters
    End Function
    ' Méthode pour trouver le port série sur lequel est branchée l'antenne GPS
    Public Function TrouverPortGPS(pPortName As String) As String

        If Not String.IsNullOrEmpty(pPortName) Then
            If TestPort(pPortName) Then
                Return pPortName
            Else
                Return Nothing
            End If
        Else
            For Each portName As String In SerialPort.GetPortNames()
                If TestPort(portName) Then
                    GPSActif = True
                    Return portName
                End If
            Next
            Return Nothing
        End If
    End Function
    Private Function TestPort(pPortNAme As String) As Boolean
        Dim bReturn As Boolean
        bReturn = False
        Try

            Using Port As New SerialPort(pPortNAme, My.Settings.VitessePort)
                Port.Open()
                ' Lire pendant une courte période (2sec) pour vérifier que l'on reçoit  les trames NMEA
                Dim start As DateTime = DateTime.Now
                While (DateTime.Now - start).TotalSeconds < 2 And Not bReturn
                    Dim Data As String
                    Dim bContinue As Boolean
                    bContinue = True
                    While bContinue
                        Try
                            Port.ReadTimeout = My.Settings.intervalGPS / 2
                            Data = Port.ReadLine()
                        Catch ex As Exception
                            Data = ""
                            bContinue = False
                        End Try
                        'Dim data As String = Port.ReadLine() 'utiliser un readLine plutot qu'un readExisting
                        Console.WriteLine("GpsManager.testPort(" & pPortNAme & ") data=" & Data)
                        If Data.Contains("$GPGGA") OrElse Data.Contains("$GPRMC") OrElse Data.Contains("$GNGGA") OrElse Data.Contains("$GNRMC") Then
                            GPSActif = True
                            bReturn = True
                        End If
                    End While
                End While
                Port.Close()
            End Using
        Catch ex As Exception

        End Try
        Return bReturn
    End Function

    Private Sub TraceMsg(pMessage As String)
        Console.WriteLine(DateTime.Now.ToLongTimeString() & ":" & pMessage)
        If My.Settings.Log Then
            Try
                System.IO.File.AppendAllText("./GPS.LOG", DateTime.Now.ToLongTimeString() & ":" & pMessage & vbCrLf)
            Catch ex As Exception

            End Try

        End If
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
    Public Sub init(Optional pPrendreEnCompteLADerniereTraceGGA As Boolean = False)
        Me.startLatitude = ""
        Me.startLongitude = ""
        Me.startTime = DateTime.MinValue
        Me.EndTime = DateTime.MinValue
        _tabVitesse = New Queue(Of Decimal)
        If pPrendreEnCompteLADerniereTraceGGA Then
            If _lstTracesGPX.Count > 0 Then
                Dim traceGGA As String
                traceGGA = _lstTracesGPX.Last()
                ProcessNMEAData(traceGGA)
                _lstTracesGPX.Clear()
                _lstTracesGPX.Add(traceGGA)
            End If
        Else
            _lstTracesGPX.Clear()

        End If
    End Sub
    Private _tabVitesse As New Queue(Of Decimal)
    Public VitesseConstante As Boolean = False
    Public Sub ajouteVitesse(pVitesse As Decimal)
        If _tabVitesse.Count >= My.Settings.nbIntervalleVitesseConstante Then
            _tabVitesse.Dequeue()
        End If
        _tabVitesse.Enqueue(pVitesse)
        If _tabVitesse.Count >= My.Settings.nbIntervalleVitesseConstante Then
            'Calcule de la vitesse Moyenne
            Dim moy As Decimal = _tabVitesse.Average
            Dim bEcart As Boolean = True
            'Vérification s'il y a un ecart de plus de 5% par rapport à la moyenne
            If ((pVitesse - moy) / moy) > My.Settings.EcartMAx Then
                bEcart = False
            End If
            Me.VitesseConstante = bEcart
        Else
            Me.VitesseConstante = False
        End If
    End Sub
    Public Function getVitesse() As Decimal
        If _tabVitesse.Count = My.Settings.nbIntervalleVitesseConstante Then
            Return _tabVitesse.Average()
        Else
            Return 0D
        End If
    End Function


    Public Function calculeVitesse(pdistance As Decimal, pTemps As Double) As Decimal
        Dim dReturn As Decimal = 0
        If pTemps <> 0 And pdistance <> 0 Then
            dReturn = (pdistance / 1000 / (pTemps * 1000)) * 3600
        End If
        Return dReturn
    End Function

    Public Function getTraces() As List(Of String)
        'Pour être certains de ne pas lire les trace pendant l'écriture, on passe par une fonction , Qui extrait les traces, vide la collection
        Dim lstReturn = New List(Of String)
        lstReturn.AddRange(_lstTracesGPX)
        _lstTracesGPX.Clear()
        Return lstReturn
    End Function

    Public Function init2() As Boolean
        Dim bReturn As Boolean
        Try
            Dim traceGGA As String
            traceGGA = _lstTracesGPX.Last()
            ProcessNMEAData(traceGGA)

            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try

        Return bReturn

    End Function

End Class
