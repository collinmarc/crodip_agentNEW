Public Class GPSMesure
    Private _VitesseConstante As Boolean
    Private _tabVitesse As New Queue(Of Decimal)(My.Settings.nbIntervalleVitesseConstante)
    Public Property VitesseConstante() As Boolean
        Get
            Return _VitesseConstante
        End Get
        Set(ByVal value As Boolean)
            _VitesseConstante = value
        End Set
    End Property
    Private _num As Integer
    Public Property Num() As Integer
        Get
            Return _num
        End Get
        Set(ByVal value As Integer)
            _num = value
        End Set
    End Property
    Public Property IsNum1() As Boolean
        Get
            Return Num = 1
        End Get
        Set(ByVal value As Boolean)
            Num = 1
        End Set
    End Property
    Public Property IsNum2() As Boolean
        Get
            Return Num = 2
        End Get
        Set(ByVal value As Boolean)
            Num = 2
        End Set
    End Property
    Private _distance As Decimal
    Public Property Distance() As Decimal
        Get
            Return Math.Round(_distance, 1)
        End Get
        Set(ByVal value As Decimal)
            If value <> _distance Then
                _distance = value
                Vitesse = calculeVitesse(Distance, Temps)
            End If
        End Set
    End Property
    Public ReadOnly Property TempAffichage As Decimal
        Get
            Return Decimal.Round(CDec(_temps / 1000), 3)
        End Get
    End Property

    Private _temps As Double
    ''' <summary>
    ''' Le Temps écoulé en millisecondes
    ''' </summary>
    ''' <returns></returns>
    Public Property Temps() As Double
        Get
            Return _temps
        End Get
        Set(ByVal value As Double)
            If value <> _temps Then
                _temps = value
                Vitesse = calculeVitesse(Distance, Temps)
            End If
        End Set
    End Property
    Public Function calculeVitesse(pdistance As Decimal, pTemps As Double) As Decimal
        Dim dReturn As Decimal = 0
        If pTemps <> 0 And pdistance <> 0 Then
            dReturn = (pdistance / 1000 / (pTemps * 1000)) * 3600
        End If
        Return dReturn
    End Function

    Private _vitesse As Decimal
    ''' <summary>
    ''' Vitesse en Km/h
    ''' </summary>
    ''' <returns></returns>
    Public Property Vitesse() As Decimal
        Get
            Return Math.Round(_vitesse, 2)
        End Get
        Set(ByVal value As Decimal)

            _vitesse = value
        End Set
    End Property
    Private _VitessseLue As Decimal
    Public Property VitesseLue() As Decimal
        Get
            Return _VitessseLue
        End Get
        Set(ByVal value As Decimal)
            _VitessseLue = value
        End Set
    End Property

    Public Sub New()
        _tabVitesse.Clear()

    End Sub

    Private _NumPulve As String
    Public Property NumPulve() As String
        Get
            Return _NumPulve
        End Get
        Set(ByVal value As String)
            _NumPulve = value
        End Set
    End Property
    Private _HeureDepart As DateTime
    Public Property HeureDepart() As DateTime
        Get
            Return _HeureDepart
        End Get
        Set(ByVal value As DateTime)
            _HeureDepart = value
        End Set
    End Property
    Private _PositionDepart As String
    Public Property PositionDepart() As String
        Get
            Return _PositionDepart
        End Get
        Set(ByVal value As String)
            _PositionDepart = value
        End Set
    End Property
    Private _HeureArrivee As DateTime
    Public Property HeureArrivee() As DateTime
        Get
            Return _HeureArrivee
        End Get
        Set(ByVal value As DateTime)
            _HeureArrivee = value
        End Set
    End Property
    Private _PositionArrivee As String
    Public Property PositionArrivee() As String
        Get
            Return _PositionArrivee
        End Get
        Set(ByVal value As String)
            _PositionArrivee = value
        End Set
    End Property
    Public Function ToCsv(pFile As String) As Boolean
        Dim bReturn As Boolean
        Try

            System.IO.File.AppendAllText(pFile, NumPulve & ";" & Num & ";" & Distance & ";" & Temps & ";" & Vitesse & ";" & VitesseLue & ";" & PositionDepart & ";" & PositionArrivee & vbCrLf)
            bReturn = True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Sub ajouteVitesse(pVitesse As Decimal)
        If _tabVitesse.Count >= My.Settings.nbIntervalleVitesseConstante Then
            _tabVitesse.Dequeue()
        End If
        _tabVitesse.Enqueue(pVitesse)
        If _tabVitesse.Count = My.Settings.nbIntervalleVitesseConstante Then
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
    Public ReadOnly Property Text() As String
        Get
            Return "E:" & PositionArrivee & "S:" & PositionDepart & "D:" & Distance & "V:" & Vitesse
        End Get
    End Property


End Class
