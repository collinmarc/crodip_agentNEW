Public Class NiveauBusePulve

    Private _Marque As String
    Public Property Marque() As String
        Get
            Return _Marque
        End Get
        Set(ByVal value As String)
            _Marque = value
        End Set
    End Property
    Private _Modele As String
    Public Property Modelele() As String
        Get
            Return _Modele
        End Get
        Set(ByVal value As String)
            _Modele = value
        End Set
    End Property
    Private _type As String
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property
    Private _Angle As String
    Public Property Angle() As String
        Get
            Return _Angle
        End Get
        Set(ByVal value As String)
            _Angle = value
        End Set
    End Property
    Private _ISO As String
    Public Property ISO() As String
        Get
            Return _ISO
        End Get
        Set(ByVal value As String)
            _ISO = value
        End Set
    End Property
    Private _Couleur As String
    Public Property Couleur() As String
        Get
            Return _Couleur
        End Get
        Set(ByVal value As String)
            _Couleur = value
        End Set
    End Property
    Private _Age As String
    Public Property Age() As String
        Get
            Return _Age
        End Get
        Set(ByVal value As String)
            _Age = value
        End Set
    End Property
    Private _NbBuses As Integer
    Public Property NbBuses() As Integer
        Get
            Return _NbBuses
        End Get
        Set(ByVal value As Integer)
            _NbBuses = value
        End Set
    End Property
End Class
