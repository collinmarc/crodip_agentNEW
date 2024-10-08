Public Class AgentRequest2
    Private _uid As Integer
    Public Property uid() As Integer
        Get
            Return _uid
        End Get
        Set(ByVal value As Integer)
            _uid = value
        End Set
    End Property
    Private _aid As String
    Public Property aid() As String
        Get
            Return _aid
        End Get
        Set(ByVal value As String)
            _aid = value
        End Set
    End Property
    Private _idProfilAgent As String
    Public Property idProfilAgent() As String
        Get
            Return _idProfilAgent
        End Get
        Set(ByVal value As String)
            _idProfilAgent = value
        End Set
    End Property
    Private _nom As String
    Public Property nom() As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property




End Class
