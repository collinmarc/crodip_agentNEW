Public Class GPSMesure
    Private _num As Integer
    Public Property Num() As Integer
        Get
            Return _num
        End Get
        Set(ByVal value As Integer)
            _num = value
        End Set
    End Property
    Private _distance As Decimal
    Public Property Distance() As Decimal
        Get
            Return _distance
        End Get
        Set(ByVal value As Decimal)
            _distance = value
        End Set
    End Property
    Private _temps As Decimal
    Public Property Temps() As Decimal
        Get
            Return _temps
        End Get
        Set(ByVal value As Decimal)
            _temps = value
        End Set
    End Property
    Private _vitesse As Decimal
    Public Property Vitesse() As Decimal
        Get
            Return Math.Round(_vitesse, 3)
        End Get
        Set(ByVal value As Decimal)
            _vitesse = value
        End Set
    End Property
    Public Sub SetValues(pDistance As Decimal, pTemps As Decimal)
        _distance = pDistance
        _temps = pTemps
        'Vitesse = Distance(m)/Temps(S)*(3600 / 1000)
        Vitesse = Distance / Temps * 3.6

    End Sub
End Class
