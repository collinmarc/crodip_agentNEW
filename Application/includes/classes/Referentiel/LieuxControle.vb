Public Class LieuxControle
    Private _Nom As String
    Public Property Nom() As String
        Get
            Return _Nom
        End Get
        Set(ByVal value As String)
            _Nom = value
        End Set
    End Property
    Private _codepostal As String
    Public Property CodePostal() As String
        Get
            Return _codepostal
        End Get
        Set(ByVal value As String)
            _codepostal = value
        End Set
    End Property
    Private _Commune As String
    Public Property Commune() As String
        Get
            Return _Commune
        End Get
        Set(ByVal value As String)
            _Commune = value
        End Set
    End Property
    Private _Site As String
    Public Property Site() As String
        Get
            Return _Site
        End Get
        Set(ByVal value As String)
            _Site = value
        End Set
    End Property

End Class
