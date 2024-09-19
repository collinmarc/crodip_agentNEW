Public Class PressionCtrl
    Private _FondEchelle As Integer
    Public Property FondEchelle() As Integer
        Get
            Return _FondEchelle
        End Get
        Set(ByVal value As Integer)
            _FondEchelle = value
        End Set
    End Property
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
    Private _Num As Integer
    Public Property Num() As Integer
        Get
            Return _Num
        End Get
        Set(ByVal value As Integer)
            _Num = value
        End Set
    End Property
    Private _Pression As Decimal
    Public Property Pression() As Decimal
        Get
            Return _Pression
        End Get
        Set(ByVal value As Decimal)
            _Pression = value
        End Set
    End Property
    Private _PressionRef As Decimal
    Public Property PressionRef() As Decimal
        Get
            Return _PressionRef
        End Get
        Set(ByVal value As Decimal)
            _PressionRef = value
        End Set
    End Property
    Private _Incertude As Decimal
    Public Property Incertitude() As Decimal
        Get
            Return _Incertude
        End Get
        Set(ByVal value As Decimal)
            _Incertude = value
        End Set
    End Property
    Private _EMT As Decimal
    Public Property EMT() As Decimal
        Get
            Return _EMT
        End Get
        Set(ByVal value As Decimal)
            _EMT = value
        End Set
    End Property
    Private _Err As Decimal
    Public Property Err() As Decimal
        Get
            Return _Err
        End Get
        Set(ByVal value As Decimal)
            _Err = value
        End Set
    End Property
End Class
